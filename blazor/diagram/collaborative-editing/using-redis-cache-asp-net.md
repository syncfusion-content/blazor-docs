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
                await ApplyRemoteDiagramChanges(diagramChanges);
            });
            await connection.StartAsync();
        }
    }
    private async Task OnReceiveDiagramUpdate(List<string> diagramChanges, long newVersion)
    {
        await DiagramInstance.SetDiagramUpdatesAsync(diagramChanges);
        this.clientVersion = newVersion;
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
**GetDiagramUpdates:** Serializes the diagram changes into a JSON format suitable for transmission to the server. This ensures that updates can be easily processed and applied by other clients.
**BroadcastToOtherClients:** A server-side SignalR method that sends updates to all clients in the same SignalR group (room).

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

To handle conflicts during collaborative editing, we use an optimistic concurrency approach based on versioning:

* **Versioning**: Each update is associated with a clientVersion and the list of editedElementIds.
* **Client Update:** The client sends its changes along with the current clientVersion and the affected element IDs.

* **Server Validation:** The server compares the incoming clientVersion with the latest version stored in Redis.
    * If the update is stale and elements overlap:
        * The server rejects the update and instructs the client to revert changes.
        * A conflict notification is shown to the user.

    * If the update is stale but no overlap exists:
        * The server accepts the update and increments the version.

* **Client Synchronization:** After an update is accepted, the client must set its clientVersion to the latest version provided by the server.

This approach ensures consistency while allowing multiple users to edit collaboratively without locking resources.

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
            connection.On("ShowConflict", ShowConflict);
            connection.On<long>("UpdateVersion", UpdateVersion);
            connection.On<List<string>>("ReceiveData", async (diagramChanges) =>
            {
                await ApplyRemoteDiagramChanges(diagramChanges);
            });
            await connection.StartAsync();
        }
    }
```

```csharp
using Microsoft.AspNetCore.SignalR;
public class DiagramHub : Hub
{
    private readonly IDiagramService _diagramService;
    private readonly IRedisService _redisService;
    private readonly ILogger<DiagramHub> _logger;
    private readonly IHubContext<DiagramHub> _diagramHubContext;
    private static readonly ConcurrentDictionary<string, DiagramUser> _diagramUsers = new();

    public DiagramHub(
        IDiagramService diagramService, IRedisService redis,
        ILogger<DiagramHub> logger, IHubContext<DiagramHub> diagramHubContext)
    {
        _diagramService = diagramService;
        _redisService = redis;
        _logger = logger;
        _diagramHubContext = diagramHubContext;
    }

    public override Task OnConnectedAsync()
    {
        // Send session id to client.
        Clients.Caller.SendAsync("OnConnectedAsync", Context.ConnectionId);
        return base.OnConnectedAsync();
    }
    public async Task BroadcastToOtherClients(List<string> payloads, long clientVersion, List<string>? elementIds, string roomName)
    {
        try
        {
            var versionKey = "diagram:version";
            var (accepted, serverVersion) = await _redisService.CompareAndIncrementAsync(versionKey, clientVersion);

            if (!accepted)
            {
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
                    await Clients.Caller.SendAsync("ShowConflict");
                    return;
                }

                var (_, newServerVersion) = await _redisService.CompareAndIncrementAsync(versionKey, serverVersion);
                serverVersion = newServerVersion;
            }
            var update = new DiagramUpdateMessage
            {
                SourceConnectionId = connId,
                Version = serverVersion,
                ModifiedElementIds = elementIds
            };
            await StoreUpdateInRedis(update);
            await Clients.OthersInGroup(roomName).SendAsync("ReceiveData", payloads, serverVersion);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex);
        }
    }
    private async Task StoreUpdateInRedis(DiagramUpdateMessage updateMessage)
    {
        try
        {
            // Store in updates history list
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
## Cleanup strategy for Redis

- Keep only the last K versions (e.g., 200), or
- Set TTL on update keys to bound memory usage.

## Hosting, transport, and serialization

- Enable WebSockets on your host/reverse proxy; consider keep-alives.
- If WebSockets aren’t available, remove SkipNegotiation on the client to allow fallback transports.
- For large payloads, enable MessagePack on server (and client if applicable) and consider sending diffs.

## Security and rooms

- Derive roomName from diagramId (e.g., "diagram:" + diagramId) and validate/normalize on server.
- Consider authentication/authorization to join rooms.
- Rate-limit BroadcastToOtherClients if necessary.

The full version of the code can be found in the GitHub location below.

GitHub Example: Collaborative editing examples
