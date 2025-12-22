---
layout: post
title: Collaborative editing in Blazor Diagram Component | Syncfusion
description: Learn how to implement collaborative editing in the Syncfusion Blazor Diagram component using SignalR and Redis.
platform: Blazor
control: Diagram
documentation: ug
---

# How to enable collaborative editing in Blazor Application

## Configure SignalR HubConnection

* Initialize a SignalR `HubConnection` on the component’s first render (`OnAfterRenderAsync`) and starts it with `StartAsync`.
* Connects to the `/diagramHub` endpoint via `WebSockets (SkipNegotiation = true)` and enables automatic reconnect to handle transient network issues.
* Subscribes to the `OnConnectedAsync` SignalR Hub callback to receive the unique connection ID, confirming a successful handshake.
* After connecting, calls `JoinDiagram(roomName)` to join a dedicated SignalR group(room) so updates are shared only with users in the same diagram session.

```csharp
@using Microsoft.AspNetCore.SignalR.Client

@code {
    private HubConnection? connection;
    private string roomName = "Syncfusion";

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender) 
        { 
            if (connection == null)
            {
                connection = new HubConnectionBuilder()
                            .WithUrl(NavigationManager.ToAbsoluteUri("/diagramHub"), options =>
                            {
                                options.SkipNegotiation = true;
                                options.Transports = Microsoft.AspNetCore.Http.Connections.HttpTransportType.WebSockets;
                            })
                            .WithAutomaticReconnect()
                            .Build();
                // Triggered when the connection to the SignalR Hub is successfully established
                connection.On<string>("OnConnectedAsync", OnConnectedAsync);
                await connection.StartAsync();
            }
        }
    }
    private async Task OnConnectedAsync(string connectionId)
    {
        if(!string.IsNullOrEmpty(connectionId))
        {
            // Join the room after connection is established
            await connection.SendAsync("JoinDiagram", roomName);
        }
    }
}
```

>**Notes:**
>* Use a unique `roomName` per diagram (e.g., a diagram ID) to isolate sessions.
>* If `WebSockets` may be unavailable, remove `SkipNegotiation` so SignalR can fall back to SSE or Long Polling.
>* Consider handling reconnecting/disconnected states in the UI and securing the connection with authentication if required.

## Sending and Applying Real-Time Diagram Changes

* The Blazor Diagram component triggers the `HistoryChanged` event whenever the diagram is modified (e.g., add, delete, move, resize, or edit nodes/connectors).
* Use [GetDiagramUpdates](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_GetDiagramUpdates_Syncfusion_Blazor_Diagram_HistoryChangedEventArgs_) to produce a compact set of incremental updates (JSON-formatted changes) representing just the changes, not the entire diagram.
* Send these changes to the hub method `BroadcastToOtherUsers`, which relays them to all users joined to the same SignalR group (room).
* Each remote user listens for ReceiveData and applies the incoming changes with [SetDiagramUpdatesAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.SfDiagramComponent.html#Syncfusion_Blazor_Diagram_SfDiagramComponent_SetDiagramUpdatesAsync_System_Collections_Generic_List_System_String__), keeping their view synchronized without reloading the full diagram.
* Enable [EnableGroupActions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramHistoryManager.html#Syncfusion_Blazor_Diagram_DiagramHistoryManager_EnableGroupActions) in [DiagramHistoryManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Diagram.DiagramHistoryManager.html) to treat multi-step edits (like drag/resize sequences or batch changes) as a single operation.

```csharp
<SfDiagramComponent @ref="@DiagramInstance" ID="@DiagramId" HistoryChanged="@OnHistoryChange" >
    <DiagramHistoryManager EnableGroupActions="true"></DiagramHistoryManager>
</SfDiagramComponent>

@code {
    
    public SfDiagramComponent DiagramInstance;

    private async Task InitializeSignalR()
    {
        if (connection == null)
        {
            // Receive remote changes from diagram hub
            connection.On<List<string>, long>("ReceiveData", async (diagramChanges, serverVersion) =>
            {
                await ApplyRemoteDiagramChanges(diagramChanges, serverVersion);
            });
        }
    }

    private async Task ApplyRemoteDiagramChanges(List<string> diagramChanges, long newVersion)
    {
        // Sets diagram updates to current diagram
        await DiagramInstance.SetDiagramUpdatesAsync(diagramChanges);
    }
    
    private async void OnHistoryChange(HistoryChangedEventArgs args)
    {
        if (args != null)
        {
            List<string> diagramChanges = DiagramInstance.GetDiagramUpdates(args);
            // When EnableGroupActions is enabled, retrieve diagramChanges only after the group action completes.
            if (diagramChanges.Count > 0)
            {
                // Send changes to the SignalR Hub for broadcasting
                await connection.SendAsync("BroadcastToOtherUsers", parsedData, roomName);
            }
        }
    }
}
```

## Asp.NET Core Hub configuration

### Configure SignalR with Redis and Map the Diagram Hub

To enable real-time collaboration, add your `Redis` connection string in `appsettings.json`, register a singleton `IConnectionMultiplexer` to reuse the Redis connection, configure `SignalR` for hub communication, use Redis-backed services to store version history, and finally map the hub at `/diagramHub` so clients can connect.

Add the following configuration to the appsettings.json file:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning",
      "Microsoft.Hosting.Lifetime": "Information"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "RedisConnectionString": "<<Your Redis connection string>>"
  }
}
```

Add the following configuration to the Program.cs file:
```csharp
using StackExchange.Redis;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

// Redis connection
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    string connectionString = builder.Configuration.GetConnectionString("RedisConnectionString");
    return ConnectionMultiplexer.Connect(connectionString);
});

// SignalR configuration
builder.Services.AddSignalR();

// App services
builder.Services.AddScoped<IRedisService, RedisService>(); // your implementation

WebApplication app = builder.Build();

app.MapHub<DiagramHub>("/diagramHub");

app.Run();
```

### Configure SignalR Hub to Create Rooms for Collaborative Editing Sessions

The hub manages SignalR groups (rooms) for each diagram session by generating a unique session ID for every connection, allowing users to join specific rooms, broadcasting updates to all participants in the same room (excluding the sender), and cleaning up group memberships when users disconnect to prevent stale sessions.

```csharp
using Microsoft.AspNetCore.SignalR;

namespace DiagramServerApplication.Hubs
{
    public class DiagramHub : Hub
    {
        private readonly ILogger<DiagramHub> _logger;

        public DiagramHub(ILogger<DiagramHub> logger)
        {
            _logger = logger;
        }

        // 1) Triggers when a user connects to the hub
        public override Task OnConnectedAsync()
        {
            // Send a unique connection ID back to the user
            Clients.Caller.SendAsync("OnConnectedAsync", Context.ConnectionId);
            return base.OnConnectedAsync();
        }

        // 2) Add the current connection to a SignalR group (room)
        public async Task JoinDiagram(string roomName)
        {
            try
            {
                string userId = Context.ConnectionId;

                // Store the room name in the connection context for later retrieval (e.g., on disconnect)
                Context.Items["roomName"] = roomName;

                // Add this connection to the specified group (room)
                await Groups.AddToGroupAsync(userId, roomName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error joining room {Room}", roomName);
            }
        }

        // 3) Broadcasts updates to other users in the same room (excludes the sender)
        public async Task BroadcastToOtherUsers(List<string> payloads, string roomName)
        {
            try
            {
                // Send the updates to all other connections in the room
                await Clients.OthersInGroup(roomName).SendAsync("ReceiveData", payloads);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error broadcasting to room {Room}", roomName);
            }
        }

        // 4) Removes the connection from its room when the user disconnects
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            try
            {
                // Retrieve previously stored room name
                string? roomName = Context.Items.TryGetValue("roomName", out var value) ? value as string : null;

                if (!string.IsNullOrEmpty(roomName))
                {
                    await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
                }

                await base.OnDisconnectedAsync(exception);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during disconnect");
            }
        }
    }
}
```
## Conflict policy (optimistic concurrency)

Collaborative edits use version-based optimistic concurrency, where each update includes the user’s current userVersion, the serialized diagram changes, and the IDs of elements affected by the edit (editedElementIds). This approach prevents conflicts without locking by allowing the server to validate versions and reject or rebase changes when discrepancies occur, ensuring consistency while maintaining real-time responsiveness.

Add the following code in the DiagramHub class:

```csharp
using Microsoft.AspNetCore.SignalR;

public class DiagramUpdateMessage
{
    public string SourceConnectionId { get; set; } = "";
    public long Version { get; set; }
    public List<string>? ModifiedElementIds { get; set; }
}

public class DiagramHub : Hub
{
    // Triggers the method when the user send the data to other users via signalR
    public async Task BroadcastToOtherUsers(List<string> payloads, long userVersion, List<string>? elementIds, string roomName)
    {
        try
        {
            string versionKey = "diagram:version";
            // Try to accept based on expected version (CAS via Lua script)
            (bool accepted, long serverVersion) = await _redisService.CompareAndIncrementAsync(versionKey, userVersion);

            if (!accepted)
            {
                // Check for overlaps since user's version
                List<DiagramUpdateMessage> recentUpdates = await GetUpdatesSinceVersionAsync(userVersion, maxScan: 200);
                HashSet<string> recentlyTouched = new HashSet<string>(StringComparer.Ordinal);
                foreach (DiagramUpdateMessage message in recentUpdates)
                {
                    if (message.ModifiedElementIds == null) continue;
                    foreach (string id in message.ModifiedElementIds)
                        recentlyTouched.Add(id);
                }

                List<string> overlaps = elementIds?.Where(id => recentlyTouched.Contains(id)).Distinct().ToList();
                if (overlaps?.Count > 0)
                {
                    // Reject and notify user to conflict message
                    await Clients.Caller.SendAsync("ShowConflict");
                    return;
                }

                // Accept non-overlapping stale update: increment once more
                (bool _, long newServerVersion) = await _redisService.CompareAndIncrementAsync(versionKey, serverVersion);
                serverVersion = newServerVersion;
            }
            // Store update in Redis history
            DiagramUpdateMessage update = new DiagramUpdateMessage
            {
                SourceConnectionId = connId,
                Version = serverVersion,
                ModifiedElementIds = elementIds
            };
            await StoreUpdateInRedis(update);
            // Broadcast to others in the same room, including serverVersion
            await Clients.OthersInGroup(roomName).SendAsync("ReceiveData", payloads, serverVersion);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
    }
}
```

* On acceptance, the hub broadcasts the diagram changes along with the authoritative serverVersion to all other users in the same room (ReceiveData). Each user applies the received changes using `SetDiagramUpdatesAsync` and updates its local userVersion based on the serverVersion provided in the payload or via the UpdateVersion event.

Add the following code in the Blazor sample application:
```csharp
private async Task InitializeSignalR()
{
    // Conflict notification
    connection.On("ShowConflict", ShowConflict);

    // Explicit version sync (optional if version is included in ReceiveData)
    connection.On<long>("UpdateVersion", UpdateVersion);
}

// Capture local changes and send with version and edited IDs
public async void OnHistoryChange(HistoryChangedEventArgs args)
{
    List<string> diagramChanges = DiagramInstance.GetDiagramUpdates(args);
    if (diagramChanges.Count == 0)
    {
        List<string> editedElements = GetEditedElements(args);
        await connection!.SendAsync("BroadcastToOtherUsers", diagramChanges, userVersion, editedElements, roomName);
    }
}

private List<string> GetEditedElements(HistoryChangedEventArgs args)
{
    // Extract and return IDs of affected nodes/connectors from args
    return new List<string>();
}

private void UpdateVersion(long newVersion) => userVersion = newVersion;

private void ShowConflict()
{
    // Display a notication to inform the user their update was rejected due to overlap
}
```

## Limitations

* Default deployment
    * By default, a single server instance works without additional setup. For multi-instance (scale-out) deployments, configure a `SignalR` backplane (e.g., Redis) and use a shared `Redis` store so all nodes share group messages and version state consistently.
* View-only interactions
    * Zoom and pan are local to each user and are not synchronized, so collaborators may view different areas of the diagram.
* Unsupported synchronized settings
    * Changes to `PageSettings`, `ContextMenu`, `DiagramHistoryManager`, `SnapSettings`, `Rulers`, `UmlSequenceDiagram`, `Layout`, and `ScrollSettings` are not propagated to other users and apply only locally.

>**Note:** 
> * Collaboration is supported for actions that raise the `HistoryChanged` event.

The full version of the code can be found in the GitHub location below.

GitHub Example: [Collaborative editing examples](https://github.com/syncfusion/blazor-showcase-diagram-collaborative-editing).
