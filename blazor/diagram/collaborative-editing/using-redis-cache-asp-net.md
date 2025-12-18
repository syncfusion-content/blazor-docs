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

## NuGet packages required

- Client (Blazor):
  - Microsoft.AspNetCore.SignalR.Client
  - Syncfusion.Blazor.Diagram
- Server:
  - Microsoft.AspNetCore.SignalR
  - Microsoft.AspNetCore.SignalR.StackExchangeRedis
  - StackExchange.Redis

## SignalR

In collaborative editing, real-time communication is essential for users to see each other’s changes instantly. We use a real-time transport protocol to efficiently send and receive data as edits occur. For this, we utilize SignalR, which supports real-time data exchange between the client and server. SignalR ensures that updates are transmitted immediately, allowing seamless collaboration by handling the complexities of connection management and offering reliable communication channels.

To make SignalR work in a distributed environment (with more than one server instance), it needs to be configured with either AspNetCore SignalR Service or a Redis backplane.

## Redis

Redis is used as a temporary data store to manage real-time diagram collaborative editing operations. It helps queue editing actions and resolve conflicts through versioning mechanisms.

All diagram editing operations performed during collaboration are cached in Redis. To prevent excessive memory usage, old versioning data is periodically removed from the Redis cache.

Redis imposes limits on concurrent connections. Select an appropriate Redis configuration based on your expected user load to maintain optimal performance and avoid connection bottlenecks.

## How to enable collaborative editing in client side

### Step 1: Configure SignalR to send and receive changes

To enable real-time collaboration, you need to configure SignalR to broadcast changes made by one user and receive updates from other users. Below is an example implementation:

```csharp
@using Microsoft.AspNetCore.SignalR.Client

@code {
    HubConnection? connection;
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
            connection.On<string>("OnConnectedAsync", OnConnectedAsync);
            connection.On<List<string>>("ReceiveData", async (diagramChanges) =>
            {
                await DiagramInstance.SetDiagramUpdatesAsync(diagramChanges);

            });
            await connection.StartAsync();
        }
    }
}
```

**Explanation**
* **OnConnectedAsync:** Triggered when the client successfully connects to the server and receives a unique connection ID. This ID can be used to join specific rooms for collaborative sessions.
* **ReceiveData:** Invoked whenever another user makes changes to the diagram. The received data contains the updates, which you can apply to your local diagram instance using SetDiagramUpdatesAsync(modifiedData).

By wiring these methods during the connection setup, you enable the server to broadcast updates to all connected clients, ensuring real-time synchronization.

### Step 2: Join SignalR room when opening the diagram

When a diagram is opened, you can join a SignalR group (room) to enable collaborative editing. This allows sending and receiving updates only within that specific group, ensuring that changes are shared among users working on the same diagram.

```csharp
    string roomName = "syncfusion";

    private async Task OnConnectedAsync(string connectionId)
    {
        if(!string.IsNullOrEmpty(connectionId))
        {
            // Join the room after connection is established
            await connection.SendAsync("JoinDiagram", roomName);
        }
    }
```
**Explanation**

* **roomName:** Represents the unique group name for the diagram session. All users editing the same diagram should join this group.
* **OnConnectedAsync:** This method is triggered after the client successfully connects to the server and receives a unique connection ID.
* **JoinDiagram:** Invokes the server-side method to add the client to the specified SignalR group. Once joined, the client can send and receive updates within this group.

Using SignalR groups ensures that updates are scoped to the relevant diagram, preventing unnecessary broadcasts to all connected clients.

### Step 3: Broadcast Current Editing Changes to Remote Users

To keep all collaborators in sync, changes made on the client-side must be sent to the server, which then broadcasts them to other connected users. This can be achieved using the `HistoryChanged` event of the Blazor Diagram component and the `GetDiagramUpdates` method.

```razor
<SfDiagramComponent @ref="@DiagramInstance" ID="@DiagramId" HistoryChanged="@OnHistoryChange" >
    <DiagramHistoryManager EnableGroupActions="true"></DiagramHistoryManager>
</SfDiagramComponent>

@code {
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
**Explanation**
* **HistoryChanged Event:** Triggered whenever a change occurs in the diagram (e.g., adding, deleting, or modifying shapes/connectors).
* **GetDiagramUpdates:** Serializes the diagram changes into a JSON format suitable for transmission to the server. This ensures that updates can be easily processed and applied by other clients.
* **BroadcastToOtherClients:** A server-side SignalR method that sends updates to all clients in the same SignalR group (room).

**Grouped Interactions**
To optimize broadcasting during grouped actions (e.g., multiple changes in a single operation):

Enable `EnableGroupActions` in DiagramHistoryManager
```razor
<DiagramHistoryManager EnableGroupActions="true"></DiagramHistoryManager>
```
This ensures `StartGroupAction` and `EndGroupAction` notifications are included in `HistoryChangedEvent`, allowing you to broadcast changes only after the group action completes.

## Server configuration

### Step 1: Configure SignalR Hub to Create Rooms for Collaborative Editing Sessions

To manage SignalR groups for each diagram, create a folder named Hubs and add a file named DiagramHub.cs inside it. This hub will handle group management and broadcasting updates to connected clients.

Use the `JoinDiagram` method to join a SignalR group (room) based on the unique connection ID.

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

### Step 2: Register services, Redis backplane, CORS, and map the hub (Program.cs)

Add these registrations to your server Program.cs so clients can connect and scale via Redis. Adjust policies/connection strings to your environment.

```csharp
var builder = WebApplication.CreateBuilder(args);

// Redis (shared connection)
builder.Services.AddSingleton<IConnectionMultiplexer>(sp =>
{
    var cs = builder.Configuration.GetConnectionString("RedisConnectionString")
             ?? "localhost:6379,abortConnect=false";
    return ConnectionMultiplexer.Connect(cs);
});

// SignalR + Redis backplane
builder.Services
    .AddSignalR()
    .AddStackExchangeRedis(builder.Configuration.GetConnectionString("RedisConnectionString")
                           ?? "localhost:6379,abortConnect=false");

// App services
builder.Services.AddScoped<IRedisService, RedisService>();
builder.Services.AddScoped<IDiagramService, DiagramService>(); // your implementation

var app = builder.Build();

app.MapHub<DiagramHub>("/diagramHub");

app.Run();
```

Notes:
- Ensure WebSockets are enabled on the host/proxy, or remove SkipNegotiation on the client to allow fallback transports.
- Use a singleton IConnectionMultiplexer to respect Redis connection limits.

### Step 3: Configure Redis Cache Connection String at the Application Level
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
            connection.On<string>("OnConnectedAsync", OnConnectedAsync);
            // Show conflict notification
            connection.On("ShowConflict", ShowConflict);
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
    private readonly IDiagramService _diagramService;
    private readonly IRedisService _redisService;
    private readonly ILogger<DiagramHub> _logger;
    private readonly IHubContext<DiagramHub> _diagramHubContext;
    private static readonly ConcurrentDictionary<string, DiagramUser> _diagramUsers = new();

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
    private async Task<IReadOnlyList<DiagramUpdateMessage>> GetUpdatesSinceVersionAsync(long sinceVersion, int maxScan = 200)
    {
        var historyKey = "diagram_updates_history";
        var length = await _redisService.ListLengthAsync(historyKey);
        if (length == 0) return Array.Empty<DiagramUpdateMessage>();

        long start = Math.Max(0, length - maxScan);
        long end = length - 1;

        var range = await _redisService.ListRangeAsync(historyKey, start, end);

        var results = new List<DiagramUpdateMessage>(range.Length);
        foreach (var item in range)
        {
            if (item.IsNullOrEmpty) continue;
            var update = JsonSerializer.Deserialize<DiagramUpdateMessage>(item.ToString());
            if (update is not null && update.Version > sinceVersion && update.SourceConnectionId != Context.ConnectionId)
                results.Add(update);
        }
        results.Sort((a, b) => a.Version.CompareTo(b.Version));
        return results;
    }
    private async Task StoreUpdateInRedis(DiagramUpdateMessage updateMessage)
    {
        try
        {
            // Store updates in redis
            var historyKey = "diagram_updates_history";
            await _redisService.ListPushAsync(historyKey, updateMessage);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "Error storing update in Redis for diagram");
        }
    }
}
```
**Redis service interface & implementation**
```csharp
using StackExchange.Redis;

public interface IRedisService
{
    Task<long> ListPushAsync<T>(string key, T value);
    Task<(bool accepted, long version)> CompareAndIncrementAsync(string key, long expectedVersion);
    Task<long> ListLengthAsync(string key);
    Task<RedisValue[]> ListRangeAsync(string key, long start = 0, long stop = -1);
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
        public async Task<long> ListPushAsync<T>(string key, T value)
        {
            try
            {
                var serializedValue = JsonSerializer.Serialize(value);
                return await _database.ListLeftPushAsync(key, serializedValue);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error pushing to list {Key}", key);
            }
        }
        public async Task<long> ListLengthAsync(string key)
        {
            try
            {
                return await _database.ListLengthAsync(key);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting list length {Key}", key);
                return 0;
            }
        }
        public async Task<RedisValue[]> ListRangeAsync(string key, long start = 0, long stop = -1)
        {
            try
            {
                return await _database.ListRangeAsync(key, start, stop);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error getting list range {Key}", key);
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

The full version of the code can be found in the GitHub location below.

GitHub Example: [Collaborative editing examples](https://github.com/syncfusion/blazor-showcase-diagram-collaborative-editing).
