---
layout: post
title: Collaborative editing in Blazor Diagram Component | Syncfusion
description: Checkout and Learn all about collaborative editing in Syncfusion Blazor Diagram component and many more details.
platform: Blazor
control: Diagram
documentation: ug
---

# Collaborative Editing with Redis in Blazor Diagram

Collaborative editing allows multiple users to work on the same diagram simultaneously. All changes are synchronized in real-time, ensuring that collaborators can instantly see updates as they occur. This feature enhances productivity by removing the need to wait for others to finish their edits and promotes seamless teamwork.
By leveraging Redis as the real-time data store, the application ensures fast and reliable communication between clients, making collaborative diagram editing smooth and efficient.

## Prerequisites

Following things are needed to enable collaborative editing in Diagram Component

* SignalR
* Redis

## SignalR

In collaborative editing, real-time communication is essential for users to see each other’s changes instantly. We use a real-time transport protocol to efficiently send and receive data as edits occur. For this, we utilize SignalR, which supports real-time data exchange between the client and server. SignalR ensures that updates are transmitted immediately, allowing seamless collaboration by handling the complexities of connection management and offering reliable communication channels.

To make SignalR work in a distributed environment (with more than one server instance), it needs to be configured with either AspNetCore SignalR Service or a Redis backplane.

## Redis

Redis is used as a temporary data store to manage real-time diagram collaborative editing operations. It helps queue editing actions and resolve conflicts through versioning mechanisms.

All diagram editing operations performed during collaboration are cached in Redis. To prevent excessive memory usage, old versioning data is periodically removed from the Redis cache.

Redis imposes limits on concurrent connections. Select an appropriate Redis configuration based on your expected user load to maintain optimal performance and avoid connection bottlenecks.

## NuGet packages required

- Client (Blazor):
  - Microsoft.AspNetCore.SignalR.Client
  - Syncfusion.Blazor.Diagram
- Server:
  - Microsoft.AspNetCore.SignalR
  - Microsoft.AspNetCore.SignalR.StackExchangeRedis
  - StackExchange.Redis

## How to enable collaborative editing in client side
### Step 1: Configure SignalR Connection
To enable real-time collaboration, you need to establish a SignalR connection that can send and receive diagram updates. This connection will allow the client to join a SignalR group (room) for collaborative editing, ensuring changes are shared only among users working on the same diagram.

The `RoomName` represents the unique group name for the diagram session, and all users editing the same diagram should join this group to share updates within that session. The `OnConnectedAsync` method is triggered after the client successfully connects to the server and receives a unique connection ID, confirming the connection. After that, the `JoinDiagram` method is called to add the client to the specified SignalR group, enabling the client to send and receive real-time updates with other users in the same room.

```csharp
@using Microsoft.AspNetCore.SignalR.Client

@code {
    HubConnection? connection;
    string RoomName = "Syncfusion";

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
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
                        .WithUrl(NavigationManager.ToAbsoluteUri("/diagramHub"), options =>
                        {
                            options.SkipNegotiation = true;
                            options.Transports = Microsoft.AspNetCore.Http.Connections.HttpTransportType.WebSockets;
                        })
                        .WithAutomaticReconnect()
                        .Build();
            // Triggered when the connection to the server is successfully established
            connection.On<string>("OnConnectedAsync", OnConnectedAsync);
            await connection.StartAsync();
        }
    }
    private async Task OnConnectedAsync(string connectionId)
    {
        if(!string.IsNullOrEmpty(connectionId))
        {
            // Join the room after connection is established
            await connection.SendAsync("JoinDiagram", RoomName);
        }
    }
}
```

### Step 3: Broadcast Current Editing Changes to Remote Users

To keep all collaborators in sync, changes made on the client-side must be sent to the server, which then broadcasts them to other connected users. This is done by handling the `HistoryChanged` event of the Blazor Diagram component and using the `GetDiagramUpdates` method to serialize changes into JSON format for transmission. The server-side method `BroadcastToOtherClients` then sends these updates to all clients in the same SignalR group (room).

The `HistoryChanged` event is triggered whenever a change occurs in the diagram, such as adding, deleting, or modifying shapes or connectors. The `GetDiagramUpdates` method converts these changes into a JSON format suitable for sending to the server, ensuring updates can be easily applied by other clients. Finally, the `BroadcastToOtherClients` method on the server broadcasts these updates to other users in the same collaborative session. Each remote user receives the changes through the `ReceiveData` listener and applies them to their diagram using `SetDiagramUpdatesAsync(diagramChanges)`.

For grouped interactions (e.g., multiple changes in a single operation), enable `EnableGroupActions` in `DiagramHistoryManager`. This ensures `StartGroupAction` and `EndGroupAction` notifications are included in the `HistoryChanged` event, allowing you to broadcast changes only after the group action completes.

```razor
<SfDiagramComponent @ref="@DiagramInstance" ID="@DiagramId" HistoryChanged="@OnHistoryChange" >
    <DiagramHistoryManager EnableGroupActions="true"></DiagramHistoryManager>
</SfDiagramComponent>

@code {
    private async Task InitializeSignalR()
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
            // Triggers when connection established to server
            connection.On<string>("OnConnectedAsync", OnConnectedAsync);
            // Apply remote changes to current diagram.
            connection.On<List<string>>("ReceiveData", async (diagramChanges) =>
            {
                await DiagramInstance.SetDiagramUpdatesAsync(diagramChanges);
            });
            await connection.StartAsync();
        }
    }
    public async void OnHistoryChange(HistoryChangedEventArgs args)
    {
        if (args != null)
        {
            List<string> parsedData = DiagramInstance.GetDiagramUpdates(args);
            if (parsedData.Count > 0)
            {
                // Send changes to the server for broadcasting
                await connection.SendAsync("BroadcastToOtherClients", parsedData, roomName);
            }
        }
    }
}
```

## Server configuration
### Step 1: Register services, Redis backplane, CORS, and map the hub (Program.cs)

Add these registrations to your server Program.cs so clients can connect and scale via Redis. Adjust policies/connection strings to your environment.
* Register Redis for shared state and backplane support.
* Configure SignalR with Redis for distributed messaging.
* Add your application services (like RedisService).
* Map the SignalR hub so clients can connect.

```csharp
var builder = WebApplication.CreateBuilder(args);

// Redis (shared connection)
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var cs = builder.Configuration.GetConnectionString("RedisConnectionString");
    return ConnectionMultiplexer.Connect(cs);
});

// SignalR + Redis backplane
builder.Services
    .AddSignalR()
    .AddStackExchangeRedis(builder.Configuration.GetConnectionString("RedisConnectionString"));

// App services
builder.Services.AddScoped<IRedisService, RedisService>(); // your implementation

var app = builder.Build();

app.MapHub<DiagramHub>("/diagramHub");

app.Run();
```

Notes:
- Ensure WebSockets are enabled on the host/proxy, or remove SkipNegotiation on the client to allow fallback transports.
- Use a singleton IConnectionMultiplexer to respect Redis connection limits.

### Step 2: Configure Redis Cache Connection String at the Application Level
To enable collaborative editing with real-time synchronization, configure Redis as the temporary data store. Redis ensures fast and reliable communication between multiple server instances when scaling the application.

Add your Redis connection string in the `appsettings.json` file:
```json
{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "RedisConnectionString": "<<Your Redis connection string>>"
  }
}
```

### Step 3: Configure SignalR Hub to Create Rooms for Collaborative Editing Sessions
Create a folder named Hubs and add a file DiagramHub.cs. This hub manages SignalR groups (rooms) per diagram and broadcasts updates to connected clients.

The following key methods are implemented on the server side:
* **OnConnectedAsync:** It will trigger when a new client connects. Sends the generated connection ID to the client so it can be used as a session identifier.
* **JoinDiagram(roomName):** Adds the current connection to a SignalR group (room) identified by roomName. Also records the mapping so the connection can be removed later.
* **BroadcastToOtherClients(payloads, roomName):** Sends updates to other clients in the same room (excludes the sender).
* **OnDisconnectedAsync:** Triggered when a client disconnects. The hub removes the connection from any rooms it had joined.

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

        public override Task OnConnectedAsync()
        {
            // Send session id to client.
            Clients.Caller.SendAsync("OnConnectedAsync", Context.ConnectionId);
            return base.OnConnectedAsync();
        }
        public async Task JoinDiagram(string roomName)
        {
            try
            {
                string userId = Context.ConnectionId;
                // Store room name in current context.
                Context.Items["roomName"] = roomName;

                // Add to SignalR group
                await Groups.AddToGroupAsync(userId, roomName);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
            }
        }
        public async Task BroadcastToOtherClients(List<string> payloads, string roomName)
        {
            try
            {
                // Broadcast diagram changes to other connected clients in same room.
                await Clients.OthersInGroup(roomName).SendAsync("ReceiveData", payloads);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
            }
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            try
            {
                // Get roomName from context
                string roomName = Context.Items["roomName"].ToString();
                // Remove from SignalR group
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
                await base.OnDisconnectedAsync(exception);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex);
            }
        }
    }
}
```
## Conflict policy (optimistic concurrency)

To handle conflicts during collaborative editing, we use an optimistic concurrency strategy with versioning:

* **Versioning**: Each update carries the client’s clientVersion and the list of editedElementIds.
* **Client Update:** The client sends serialized diagram changes, clientVersion, and editedElementIds to the server.

* **Server Validation:** The server compares the incoming clientVersion with the latest version stored in Redis.
    * **If stale and overlapping elements exist:** reject the update, instruct the client to revert, and show a conflict notice.
    * **If stale but no overlap:** accept the update and increment the version atomically.
* **Client Synchronization:** After acceptance, the client must update its local clientVersion to the server version.

This approach keeps collaborators in sync without locking, while ensuring deterministic conflict handling.

**Client (Blazor) – Send updates & apply remote changes**
```razor
@using Microsoft.AspNetCore.SignalR.Client
<SfDiagramComponent @ref="@DiagramInstance" ID="@DiagramId" HistoryChanged="@OnHistoryChange" >
    <DiagramHistoryManager EnableGroupActions="true"></DiagramHistoryManager>
</SfDiagramComponent>

@code {
    HubConnection? connection;
    private long clientVersion = 0;

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
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
                        .WithUrl(NavigationManager.ToAbsoluteUri("/diagramHub"), options =>
                        {
                            options.SkipNegotiation = true;
                            options.Transports = Microsoft.AspNetCore.Http.Connections.HttpTransportType.WebSockets;
                        })
                        .WithAutomaticReconnect()
                        .Build();
            // Show conflict notification
            connection.On("ShowConflict", ShowConflict);
            // Update the client version to the latest server version.
            connection.On<long>("UpdateVersion", UpdateVersion);
            // Receive remote changes with the new server version
            connection.On<List<string, long>>("ReceiveData", async (diagramChanges, serverVersion) =>
            {
                await ApplyRemoteDiagramChanges(diagramChanges);
            });
            await connection.StartAsync();
        }
    }
    private async Task ApplyRemoteDiagramChanges(List<string> diagramChanges, long newVersion)
    {
        // Apply remote diagram changes to local diagram
        await DiagramInstance.SetDiagramUpdatesAsync(diagramChanges);
        // Update to latest server version
        this.clientVersion = newVersion;
    }
    public async Task OnHistoryChange(HistoryChangedEventArgs args)
    {
        if (args != null)
        {
            List<string> parsedData = DiagramInstance.GetDiagramUpdates(args);
            if (parsedData.Count > 0)
            {
                List<string> editedElements = GetEditedElements(args);
                // Send changes to the server for broadcasting
                await connection.SendAsync("BroadcastToOtherClients", parsedData, clientVersion, editedElements, roomName);
            }
        }
    }
    private void UpdateVersion(long newVersion)
    {
        this.clientVersion = newVersion;
    }
    private void ShowConflict()
    {
        // Show a dialog telling the user their change was rejected due to overlap
    }
    private List<string> GetEditedElements(HistoryChangedEventArgs args)
    {
        // TODO: extract IDs from args (nodes/connectors edited)
        return new List<string>();
    }
}
```
**Server (SignalR Hub) – Validate with Redis and broadcast**
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
    private readonly IRedisService _redisService;
    private readonly ILogger<DiagramHub> _logger;

    public DiagramHub(IRedisService redis, ILogger<DiagramHub> logger)
    {
        _redisService = redis;
        _logger = logger;
    }
    public async Task BroadcastToOtherClients(List<string> payloads, long clientVersion, List<string>? elementIds, string roomName)
    {
        try
        {
            var versionKey = "diagram:version";
            // Try to accept based on expected version (CAS via Lua)
            var (accepted, serverVersion) = await _redisService.CompareAndIncrementAsync(versionKey, clientVersion);

            if (!accepted)
            {
                // Check for overlaps since client's version
                var recentUpdates = await GetUpdatesSinceVersionAsync(clientVersion, maxScan: 200);
                var recentlyTouched = new HashSet<string>(StringComparer.Ordinal);
                foreach (var upd in recentUpdates)
                {
                    if (upd.ModifiedElementIds == null) continue;
                    foreach (var id in upd.ModifiedElementIds)
                        recentlyTouched.Add(id);
                }

                var overlaps = elementIds?.Where(id => recentlyTouched.Contains(id)).Distinct().ToList();
                if (overlaps?.Count > 0)
                {
                    // Reject & notify caller of conflict
                    await Clients.Caller.SendAsync("ShowConflict");
                    return;
                }

                // Accept non-overlapping stale update: increment once more
                var (_, newServerVersion) = await _redisService.CompareAndIncrementAsync(versionKey, serverVersion);
                serverVersion = newServerVersion;
            }
            // Store update in Redis history
            var update = new DiagramUpdateMessage
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
**Redis service interface & implementation**
* The IRedisService interface defines `CompareAndIncrementAsync(string key, long expectedVersion)`.
This method checks if the current version stored in Redis matches the version we expect. If it matches, it increases the version by 1.
* **Purpose:** This is used in collaborative applications to avoid conflicts when multiple users edit the same element. It ensures only one update happens at a time.
```csharp
using StackExchange.Redis;

public interface IRedisService
{
    Task<(bool accepted, long version)> CompareAndIncrementAsync(string key, long expectedVersion);
}
```
```csharp
using Microsoft.Extensions.Logging;
using StackExchange.Redis;
using System.Text.Json;

    public class RedisService : IRedisService
    {
        private readonly IDatabase _database;
        private readonly ILogger<RedisService> _logger;

        public RedisService(IConnectionMultiplexer redis, ILogger<RedisService> logger)
        {
            _database = redis.GetDatabase();
            _logger = logger;
        }

        public async Task<(bool accepted, long version)> CompareAndIncrementAsync(string key, long expectedVersion)
        {
            const string lua = @"
local v = redis.call('GET', KEYS[1])
if not v then
  v = 0
else
  v = tonumber(v) or 0
end

local expected = tonumber(ARGV[1]) or -1

if v == expected then
  local newv = redis.call('INCR', KEYS[1])
  return {1, newv}
else
  return {0, v}
end
";
            try
            {
                var result = (StackExchange.Redis.RedisResult[])await _database.ScriptEvaluateAsync(
                    lua,
                    keys: new StackExchange.Redis.RedisKey[] { key },
                    values: new StackExchange.Redis.RedisValue[] { expectedVersion.ToString() });

                bool accepted = (int)result[0] == 1;

                long version;
                if (result[1].Type == StackExchange.Redis.ResultType.Integer)
                    version = (long)result[1];
                else
                    version = long.Parse((string)result[1]);

                return (accepted, version);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error in CompareAndIncrementAsync for key {Key}", key);
            }
        }
    }
```

## Cleanup strategy for Redis

To prevent unbounded memory growth and maintain optimal performance, implement one or both of the following strategies:
* **Keep Only the Last K Versions**
    * Maintain a fixed-size history list (e.g., last 200 updates) by trimming older entries after each push.
    * This ensures that only recent updates are retained for conflict resolution.
* **Set TTL (Time-to-Live) on Update Keys**
    * Apply an expiration policy to Redis keys storing version and history data.
    * This bounds memory usage and automatically cleans up stale sessions.
```csharp
// In IRedisService
Task<bool> SetAsync<T>(string key, T value, TimeSpan? expiry = null);
// In RedisService
public async Task<bool> SetAsync<T>(string key, T value, TimeSpan? expiry = null)
{
    try
    {
        var serializedValue = JsonSerializer.Serialize(value);
        return await _database.StringSetAsync(key, serializedValue, expiry);
    }
    catch (Exception ex)
    {
        _logger.LogError(ex, "Error setting key {Key}", key);
        return false;
    }
}

// Applying TTL to the version key
const string versionKey = "diagram:version";
long version = 5;
await _redisService.SetAsync(versionKey, version, TimeSpan.FromHours(1));
```

## Hosting, transport, and serialization

To ensure reliable and efficient collaborative editing, consider the following best practices:
* **1. Hosting**
    * Enable WebSockets on your hosting environment and reverse proxy (e.g., Nginx, IIS, Azure App Service).
    * Configure keep-alives to maintain long-lived connections and prevent timeouts during idle periods.
* **2. Transport**
    * **Preferred:** WebSockets for low-latency, full-duplex communication.
    * **Fallback:** If WebSockets are unavailable, remove SkipNegotiation on the client to allow SignalR to fall back to Server-Sent Events (SSE) or Long Polling.
* **3. Serialization**
    * For large payloads, enable MessagePack on both server and client for efficient binary serialization.
    * Consider sending diffs (incremental changes) instead of full diagram state to reduce bandwidth usage.

## Limitations
* **Single-Server Hosting Only**
    * The current implementation does not support multiple server instances. SignalR connections and Redis-based versioning are designed for a single-node setup. Scaling out requires configuring a SignalR backplane (e.g., Redis backplane) and ensuring consistent state across nodes.
* **Zoom and Pan Not Collaborative**
    * Zoom and pan actions are local to each client and are not synchronized across users. This means collaborators may view different portions of the diagram independently.
* **Unsupported Diagram Settings**
    * Changes to properties such as PageSettings, ContextMenu, DiagramHistoryManager, SnapSettings, Rulers, UmlSequenceDiagram, Layout, and ScrollSettings are not propagated to other users and will only apply locally.

>**Note:** 
> * Collaboration is currently supported only for actions that trigger the HistoryChanged event.

The full version of the code can be found in the GitHub location below.

GitHub Example: [Collaborative editing examples](https://github.com/syncfusion/blazor-showcase-diagram-collaborative-editing).
