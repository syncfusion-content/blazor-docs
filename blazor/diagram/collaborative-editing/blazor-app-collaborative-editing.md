---
layout: post
title: Collaborative Editing Configuration in Blazor Diagram | Syncfusion
description: Checkout and learn to configure SignalR and Redis for real-time collaborative editing in Syncfusion Blazor Diagram.
platform: Blazor
control: Diagram
documentation: ug
---

# SignalR Hub Configuration in Blazor Application

## Overview
This guide explains how to configure SignalR Hub in a Blazor application for real-time collaborative diagram editing.

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## How to Create Blazor sample

To create a Blazor Web App, follow the steps outlined in the Blazor Web App [Getting Started](https://blazor.syncfusion.com/documentation/diagram/getting-started-with-web-app) documentation.

## How to Add Packages in the Blazor Application

Open the NuGet package manager in Visual Studio (Tools → NuGet Package Manager → Manage NuGet Packages for Solution) of the client project, then search and install the following packages.

* Microsoft.AspNetCore.SignalR.Client
* Syncfusion.Blazor.Diagram
* Syncfusion.Blazor.Themes

## Configure SignalR Service in Blazor Application

To enable real-time collaboration, configure SignalR HubConnection in your Blazor component as follows:

* Initialize the `HubConnection` during the component’s first render (`OnAfterRenderAsync`) and start it using `StartAsync`.
* Connect to the `/diagramHub` endpoint with option WebSockets `SkipNegotiation = true` and enable automatic reconnect to handle transient network issues.
* Subscribe to the `OnConnectedAsync` callback to receive the unique connection ID, confirming a successful handshake with the server.
* Join a SignalR group by calling `JoinDiagram(roomName)` after connecting. This ensures updates are shared only with users in the same diagram session.
* Refer to Create Blazor [Simple Diagram](https://blazor.syncfusion.com/documentation/diagram/getting-started-with-web-app#how-to-create-blazor-flowchart-diagram)

```csharp
@using Microsoft.AspNetCore.SignalR.Client
@using Microsoft.AspNetCore.Components
@inject NavigationManager NavigationManager

@code {
    private HubConnection? _connection;
    private string _roomName = "Syncfusion";

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender) 
        { 
            if (_connection == null)
            {
                // Run the hub service and Add your service url like "/diagramHub" in the connection
                _connection = new HubConnectionBuilder()
                            .WithUrl("<<Your ServiceURL>>", options =>
                            {
                                options.SkipNegotiation = true;
                                options.Transports = Microsoft.AspNetCore.Http.Connections.HttpTransportType.WebSockets;
                            })
                            .WithAutomaticReconnect()
                            .Build();
                // Triggered when the connection to the SignalR Hub is successfully established
                _connection.On<string>("OnConnectedAsync", OnConnectedAsync);
                await _connection.StartAsync();
            }
        }
    }
    private async Task OnConnectedAsync(string connectionId)
    {
        if(!string.IsNullOrEmpty(connectionId))
        {
            // Join the room after connection is established
            await _connection!.SendAsync("JoinDiagram", _roomName);
        }
    }
}
```

>**Notes:**
>* Use a unique `roomName` per diagram (e.g., a diagram ID) to isolate sessions.
>* If `WebSockets` may be unavailable, remove `SkipNegotiation` so SignalR can fall back to SSE or Long Polling.
>* Consider handling reconnecting/disconnected states in the UI and securing the connection with authentication if required.


## Sending and Applying Real-Time Diagram Changes

* The Blazor Diagram component triggers the [HistoryChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_HistoryChanged) event whenever the diagram is modified (e.g., add, delete, move, resize, or edit nodes/connectors).
* Use [GetDiagramUpdates](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_GetDiagramUpdates_Syncfusion_Blazor_Diagram_HistoryChangedEventArgs_) to produce a compact set of incremental updates (JSON-formatted changes) representing just the changes, not the entire diagram.
* Send these changes to the hub method `BroadcastToOtherUsers`, which relays them to all users joined to the same SignalR group (room).
* Each remote user listens for ReceiveData and applies the incoming changes with [SetDiagramUpdatesAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SetDiagramUpdatesAsync_System_Collections_Generic_List_System_String__), keeping their view synchronized without reloading the full diagram.
* Enable [EnableGroupActions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramHistoryManager.html#Syncfusion_Blazor_Diagram_DiagramHistoryManager_EnableGroupActions) in [DiagramHistoryManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramHistoryManager.html) to treat multi-step edits (like drag/resize sequences or batch changes) as a single operation.

```csharp
<SfDiagramComponent @ref="_diagramInstance" ID="@_diagramId" HistoryChanged="@OnHistoryChange">
    <DiagramHistoryManager EnableGroupActions="true"></DiagramHistoryManager>
</SfDiagramComponent>

@code {
    private SfDiagramComponent? _diagramInstance;
    private string _diagramId = "diagram";
    private string _roomName = "Syncfusion";

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender) 
        { 
            if (_connection == null)
            {
                // Initialize and start the SignalR connection here
                // ...
                
                // Receive remote changes from diagram hub
                _connection.On<List<string>>("ReceiveData", async (diagramChanges) =>
                {
                    await ApplyRemoteDiagramChanges(diagramChanges);
                });
            }
        }
    }

    private async Task ApplyRemoteDiagramChanges(List<string> diagramChanges)
    {
        // Sets diagram updates to current diagram
        if (_diagramInstance != null)
        {
            await _diagramInstance.SetDiagramUpdatesAsync(diagramChanges);
        }
    }
    
    private async Task OnHistoryChange(HistoryChangedEventArgs args)
    {
        if (args != null && _diagramInstance != null)
        {
            List<string> diagramChanges = _diagramInstance.GetDiagramUpdates(args);
            // When EnableGroupActions is enabled, retrieve diagramChanges only after the group action completes.
            if (diagramChanges.Count > 0)
            {
                // Send changes to the SignalR Hub for broadcasting
                await _connection!.SendAsync("BroadcastToOtherUsers", diagramChanges, _roomName);
            }
        }
    }
}
```

## Conflict policy (optimistic concurrency) in Blazor Application

To maintain consistency during collaborative editing, each user applies incoming changes using `SetDiagramUpdatesAsync`. After applying changes, the blazor sample synchronizes its `userVersion` with the  `serverVersion` through the `UpdateVersion` event. This version-based approach ensures conflicts are resolved without locking, allowing real-time responsiveness while preserving data integrity.

Add the following code in the Blazor sample application:
```csharp
// Version tracking for optimistic concurrency
private long _userVersion;

protected override async Task OnAfterRenderAsync(bool firstRender)
{
    if (firstRender) 
    { 
        if (_connection == null)
        {
            // Initialize connection and handlers as needed
            // ...
            
            _connection.On<List<string>, long>("ReceiveData", async (diagramChanges, serverVersion) =>
            {
                await ApplyRemoteDiagramChanges(diagramChanges, serverVersion);
            });
            // Conflict notification
            _connection.On("ShowConflict", () => ShowConflict());

            // Explicit version sync (optional if version is included in ReceiveData)
            _connection.On<long>("UpdateVersion", UpdateVersion);
        }
    }
}

private async Task ApplyRemoteDiagramChanges(List<string> diagramChanges, long serverVersion)
{
    // Sets diagram updates to current diagram
    if (_diagramInstance != null)
    {
        await _diagramInstance.SetDiagramUpdatesAsync(diagramChanges);
    }
    _userVersion = serverVersion;
}

// Capture local changes and send with version and edited IDs
public async Task OnHistoryChange(HistoryChangedEventArgs args)
{
    if (_diagramInstance == null)
        return;

    List<string> diagramChanges = _diagramInstance.GetDiagramUpdates(args);
    if (diagramChanges.Count > 0)
    {
        List<string> editedElements = GetEditedElements(args);
        await _connection!.SendAsync("BroadcastToOtherUsers", diagramChanges, _userVersion, editedElements, _roomName);
    }
}

private List<string> GetEditedElements(HistoryChangedEventArgs args)
{
    // Extract and return IDs of affected nodes/connectors from args
    // TODO: implement extraction logic based on HistoryChangedEventArgs
    return new List<string>();
}

private void UpdateVersion(long serverVersion) => _userVersion = serverVersion;

private void ShowConflict()
{
    // Display a notification to inform the user their update was rejected due to overlap
}
```