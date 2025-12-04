---
layout: post
title: Collaborative editing in Blazor Diagram Component | Syncfusion
description: Checkout and Learn all about collaborative editing in Syncfusion Blazor Diagram component and many more details.
platform: Blazor
control: Diagram
documentation: ug
---

# Collaborative Editing with Redis in Blazor Diagram

Collaborative editing enables multiple users to work on the same diagram at the same time. Changes are reflected in real-time, allowing collaborators to see updates as they happen. This approach significantly improves efficiency by eliminating the need to wait for others to finish their edits, fostering seamless teamwork.

## Prerequisites

To enable collaborative editing in the diagram component, you need:

* SignalR 
* Redis 

## SignalR

Real-time communication is the backbone of collaborative editing. It ensures that users can instantly view changes made by others. SignalR provides a reliable framework for real-time data exchange between the client and server, handling complexities such of connection management and offering reliable communication channels.

To make SignalR work in a distributed environment (with more than one server instance), it needs to be configured with either Azure SignalR Service or a Redis backplane.

### Scale-out SignalR using Azure SignalR service

Azure SignalR Service is a fully managed, scalable solution for enabling real-time communication in web applications. It facilitates instant messaging between web clients (browsers) and your server-side application, even when deployed across multiple servers.

To configure Azure SignalR in an ASP.NET Core application, use the **AddAzureSignalR** method:

```csharp
builder.Services.AddSignalR() .AddAzureSignalR("<your-azure-signalr-service-connection-string>", options => { 
    // Specify the channel name 
    options.Channels.Add("diagram-editor");
 }); 
```

### Scale-out SignalR using Redis

When you need horizontal scaling without relying on Azure services, Redis backplane is an excellent choice. SignalR uses Redis to broadcast messages across multiple servers, ensuring all connected clients receive updates with minimal latency.

In the SignalR app, install the following NuGet package:
* `Microsoft.AspNetCore.SignalR.StackExchangeRedis`

Below is a code snippet to configure Redis backplane in an ASP.NET Core application using the ```AddStackExchangeRedis ``` method.

```csharp
builder.Services.AddSignalR().AddStackExchangeRedis("<your_redis_connection_string>");
```
Configure options as needed:

The following example shows how to add a channel prefix in the ConfigurationOptions object. 

```csharp
builder.Services.AddDistributedMemoryCache().AddSignalR().AddStackExchangeRedis(connectionString, options =>
  {
      options.Configuration.ChannelPrefix = "diagram-editor";
  });
```

## Redis

Redis is used as a temporary data store to manage real-time collaborative editing operations. It helps queue editing actions and resolve conflicts through versioning mechanisms.

All diagram editing operations performed during collaboration are cached in Redis. To prevent excessive memory usage, old versioning data is periodically removed from the Redis cache.

Redis imposes limits on concurrent connections. Select an appropriate Redis configuration based on your expected user load to maintain optimal performance and avoid connection bottlenecks.

## How to enable collaborative editing in client side

### Step 1: Enable collaborative editing in Blazor Diagram
To enable collaborative editing, set the `EnableCollaborativeEditing` property to true in the `SfDiagramComponent`. 

When collaborative editing is enabled:
* Use the `SerializeDiagramChanges` method in the HistoryChanged event to serialize modified diagram data.
* Send the serialized data to other clients through a SignalR hub.
* Apply remote changes on the client using the `ApplyRemoteDiagramChangesAsync` method.

```cshtml
<SfDiagramComponent EnableCollaborativeEditing="true"></SfDiagramComponent>
```

## Step 2: Configure SignalR to send and receive changes

To broadcast changes made in the diagram and receive updates from remote users, configure SignalR as shown below.

1) **Enable Collaborative Editing in the Diagram Component**
```cshtml
<SfDiagramComponent EnableCollaborativeEditing="true"></SfDiagramComponent>
```
2) **Initialize SignalR Connections**
Use the OnAfterRenderAsync lifecycle method to establish the SignalR connection when the component is first rendered.

```cshtml
protected override async Task OnAfterRenderAsync(bool firstRender)
{
     await base.OnAfterRenderAsync(firstRender);
     if (firstRender)
     {
         await InitializeSignalR();
     }
}
private async Task InitializeSignalR()
{
    if (connection == null)
    {
        connection = new HubConnectionBuilder()
                    .WithUrl("// Add your server url", options =>
                    {
                        options.SkipNegotiation = false;
                        options.Transports = Microsoft.AspNetCore.Http.Connections.HttpTransportType.WebSockets |
                                Microsoft.AspNetCore.Http.Connections.HttpTransportType.LongPolling;
                    })
                    .WithAutomaticReconnect()
                    .Build();
        connection.On<string>("OnConnectedAsync", OnConnectedAsync);
        connection.On<List<string>>("ReceiveData", async (diagramChanges) =>
        {
            await OnReceiveDiagramUpdate(diagramChanges);
        });
        await connection.StartAsync();
    }
}
private async Task OnConnectedAsync(string connectionId)
{
    if (!string.IsNullOrEmpty(connectionId))
    {
        // Join the room after connection is established
        await connection.SendAsync("JoinDiagram", roomName);
    }
}
private async Task OnReceiveDiagramUpdate(List<string> diagramChanges)
{
    await DiagramInstance.ApplyRemoteDiagramChangesAsync(diagramChanges);
}
```

