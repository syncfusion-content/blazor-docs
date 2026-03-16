---
layout: post
title: Collaborative editing in Blazor Diagram Component | Syncfusion
description: Check out and Learn all about collaborative editing in Syncfusion Blazor Diagram component and many more details.
platform: Blazor
control: Diagram
documentation: ug
---

# Collaborative Editing with Redis in Blazor Diagram

Collaborative editing enables multiple users to work on the same diagram at the same time. Changes are reflected in real-time, allowing collaborators to see updates as they happen. This approach significantly improves efficiency by eliminating the need to wait for others to finish their edits, fostering seamless teamwork.

## Prerequisites

The following are needed to enable collaborative editing in the Diagram component:

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

To make SignalR work in a distributed environment (with more than one server instance), it needs to be configured with either ASP.NET Core SignalR service or a Redis backplane.

### Scale-out SignalR using ASP.NET Core SignalR service

ASP.NET Core SignalR service is a scalable, managed service for real-time communication in web applications. It enables real-time messaging between web clients (browsers) and your server-side application(across multiple servers).

Below is a code snippet to configure SignalR in a Blazor application using AddSignalR:

```csharp
builder.Services.AddSignalR(options =>
{
    options.EnableDetailedErrors = true;
});
```



### Scale-out SignalR using Redis

Using a Redis backplane, you can achieve horizontal scaling of your SignalR application. SignalR leverages Redis to efficiently broadcast messages across multiple servers. This allows your application to handle large user bases with minimal latency.

In the SignalR app, install the following NuGet package:

`Microsoft.AspNetCore.SignalR.StackExchangeRedis`

Below is a code snippet to configure Redis backplane in a Blazor server application using the AddStackExchangeRedis method

```csharp
builder.Services.AddSingleton<IConnectionMultiplexer>(provider =>
{
    var connectionString = builder.Configuration.GetConnectionString("Redis") ?? "localhost:6379,abortConnect=false";
    return ConnectionMultiplexer.Connect(connectionString);
});
builder.Services.AddScoped<IRedisService, RedisService>();
```

## Redis

Redis is used as a temporary data store to manage real-time collaborative editing operations. It helps queue editing actions and resolve conflicts through versioning mechanisms.

All diagram editing operations performed during collaboration are cached in Redis. To prevent excessive memory usage, old versioning data is periodically removed from the Redis cache.

Redis imposes limits on concurrent connections. Select an appropriate Redis configuration based on your expected user load to maintain optimal performance and avoid connection bottlenecks.

## How to enable collaborative editing on the client side

### Step 1: Configure SignalR to send and receive changes

To broadcast the changes made and receive changes from remote users, configure SignalR as shown below.

```csharp
@code {
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
            connection.On<string>("OnSaveDiagramState", OnSaveDiagramState);
            connection.On("ShowConflict", ShowConflict);
            connection.On("RevertCurrentChanges", RevertCurrentChanges);
            connection.On<string>("OnConnectedAsync", OnConnectedAsync);
            connection.On<long>("UpdateVersion", UpdateVersion);
            connection.On<List<string>>("CurrentUsers", CurrentUsers);
            connection.On<DiagramData>("LoadDiagramData", OnLoadDiagramData);
            connection.On<List<string>, long, SelectionEvent>("ReceiveData", async (diagramChanges, serverVersion, selectionEvent) =>
            {
                await InvokeAsync(() => OnReceiveDiagramUpdate(diagramChanges, serverVersion, selectionEvent));
            });
            connection.On<string>("UserJoined", ShowUserJoined);
            connection.On<string>("UserLeft", ShowUserLeft);
            connection.On("UpdateSelectionHighlighter", SendCurrentSelectorBoundsToOtherClient);
            connection.On<List<SelectionEvent>>("PeerSelectionsBootstrap", async list =>
            {
                foreach (var evt in list)
                    _peerSelections[evt.ConnectionId] = (evt.UserName ?? "User", evt.ElementIds?.ToHashSet() ?? new(), evt.SelectorBounds);
                await InvokeAsync(StateHasChanged);
            });

            connection.On<SelectionEvent>("PeerSelectionChanged", async (evt) =>
            {
                await InvokeAsync(() =>
                {
                    PeerSelectionChanged(evt);
                    StateHasChanged();
                }
                );
            });

            connection.On<SelectionEvent>("PeerSelectionCleared", async evt =>
            {
                if (evt != null)
                {
                    _peerSelections.Remove(evt.ConnectionId);
                    await InvokeAsync(StateHasChanged);
                }
            });
            await connection.StartAsync();
        }
    }
```

### Step 2: Join SignalR room while opening the diagram

When opening a diagram, we need to generate a unique ID for each diagram. These unique IDs are then used to create rooms using SignalR, which facilitates sending and receiving data from the server.

```csharp
    string diagramId = "diagram";
    string currentUser = string.Empty;
    string roomName = "diagram_group";

    private async Task OnConnectedAsync(string connectionId)
    {
        if(!string.IsNullOrEmpty(connectionId))
        {
            this.ConnectionId = connectionId;
            currentUser = string.IsNullOrEmpty(currentUser) ? $"{userCount}" : currentUser;
            // Join the room after connection is established
            await connection.SendAsync("JoinDiagram", roomName, diagramId, currentUser);
        }
    }
```

### Step 3: Broadcast current editing changes to remote users

Changes made on the client-side need to be sent to the server-side to broadcast them to other connected users. To send the changes made to the server, use the method shown below from the diagram using the `HistoryChange` event.

```razor
                <SfDiagramComponent @ref="@DiagramInstance" ID="@DiagramId" HistoryChanged="@OnHistoryChange" >
                    <DiagramHistoryManager EnableGroupActions="true"></DiagramHistoryManager>
                </SfDiagramComponent>

@code {
    public async void OnHistoryChange(HistoryChangedEventArgs args)
    {
        if (args != null && DiagramInstance != null && !isLoadDiagram && !isRevertingCurrentChanges)
        {
            bool isUndo = args.ActionTrigger == HistoryChangedAction.Undo;
            bool isStartGroup = args.EntryType == (isUndo ? HistoryEntryType.EndGroup : HistoryEntryType.StartGroup);
            bool isEndGroup = args.EntryType == (isUndo ? HistoryEntryType.StartGroup : HistoryEntryType.EndGroup);

            if (isStartGroup) { editedElements = new(); isGroupAction = true; }
            List<string> parsedData = DiagramInstance.GetDiagramUpdates(args);
            editedElements.AddRange(GetEditedElementIds(args).ToList());
            if (parsedData.Count > 0)
            {
                var (selectedElementIds, selectorBounds) = await UpdateOtherClientSelectorBounds();
                SelectionEvent currentSelectionDetails = new SelectionEvent() { ElementIds = selectedElementIds, SelectorBounds = selectorBounds };
                if (connection.State != HubConnectionState.Disconnected)
                    await connection.SendAsync("BroadcastToOtherClients", parsedData, clientVersion, editedElements, currentSelectionDetails, roomName);
            }
            if (isEndGroup || !isGroupAction) { editedElements = new(); isGroupAction = false; }
        }
    }
}
```

## How to enable collaborative editing in Blazor

### Step 1: Configure SignalR hub to create room for collaborative editing session

To manage groups for each diagram, create a folder named “Hubs” and add a file named “DiagramHub.cs” inside it. Add the following code to the file to manage SignalR groups using room names.

Join the group by using unique id of the diagram by using `JoinGroup` method.

```csharp
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace DiagramServerApplication.Hubs
{
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

        public async Task JoinDiagram(string roomName, string diagramId, string userName)
        {
            try
            {
                string userId = Context.ConnectionId;
                if (_diagramUsers.TryGetValue(userId, out var existingUser))
                {
                    if (existingUser != null)
                    {
                        _diagramUsers.TryRemove(userId, out _);
                        await Groups.RemoveFromGroupAsync(userId, roomName);
                        _logger.LogInformation("Removed existing connection for user {UserId} before adding new one", userId);
                    }
                }

                // Add to SignalR group
                await Groups.AddToGroupAsync(userId, roomName);

                // Store connection context
                Context.Items["DiagramId"] = diagramId;
                Context.Items["UserId"] = userId;
                Context.Items["UserName"] = userName;
                Context.Items["RoomName"] = roomName;

                // Track user in diagram
                var diagramUser = new DiagramUser
                {
                    ConnectionId = Context.ConnectionId,
                    UserName = userName,
                };
                bool userExists = _diagramUsers?.Count > 0;
                if (!userExists)
                    await ClearConnectionsFromRedis();
                _diagramUsers.AddOrUpdate(userId, diagramUser,
                    (key, existingValue) => diagramUser
                );
                await RequestAndLoadStateAsync(roomName, diagramId, Context.ConnectionId, Context.ConnectionAborted);

                long currentServerVersion = await GetDiagramVersion();
                await Clients.Caller.SendAsync("UpdateVersion", currentServerVersion);
                await Clients.OthersInGroup(roomName).SendAsync("UserJoined", userName);
                await SendCurrentSelectionsToCaller();
                List<string> activeUsers = GetCurrentUsers();
                await Clients.Group(roomName).SendAsync("CurrentUsers", activeUsers);
                _logger.LogInformation("User {UserId} ({UserName}) joined diagram {DiagramId}. Total users: {UserCount}", userId, userName, diagramId, _diagramUsers.Count);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error joining diagram {DiagramId} for user {UserId}", diagramId, Context.ConnectionId);
                await Clients.Caller.SendAsync("JoinError", "Failed to join diagram");
            }
        }

        public async Task BroadcastToOtherClients(List<string> payloads, long clientVersion, List<string>? elementIds, SelectionEvent currentSelection, string roomName)
        {
            var connId = Context.ConnectionId;
            var gate = GetConnectionLock(connId);
            await gate.WaitAsync();
            try
            {
                var versionKey = "diagram:version";

                var (acceptedSingle, serverVersionSingle) = await _redisService.CompareAndIncrementAsync(versionKey, clientVersion);
                long serverVersionFinal = serverVersionSingle;

                if (!acceptedSingle)
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
                        await Clients.Caller.SendAsync("RevertCurrentChanges", elementIds);
                        await Clients.Caller.SendAsync("ShowConflict");
                        return;
                    }

                    var (_, newServerVersion) = await _redisService.CompareAndIncrementAsync(versionKey, serverVersionSingle);
                    serverVersionFinal = newServerVersion;
                }

                var update = new DiagramUpdateMessage
                {
                    SourceConnectionId = connId,
                    Version = serverVersionFinal,
                    ModifiedElementIds = elementIds
                };

                await StoreUpdateInRedis(update, connId);
                SelectionEvent selectionEvent = BuildSelectedElementEvent(currentSelection.ElementIds, currentSelection.SelectorBounds);
                await UpdateSelectionBoundsInRedis(selectionEvent, currentSelection.ElementIds, currentSelection.SelectorBounds);
                await Clients.OthersInGroup(roomName).SendAsync("ReceiveData", payloads, serverVersionFinal, selectionEvent);
                await RemoveOldUpdates(serverVersionFinal);
            }
            finally
            {
                gate.Release();
            }
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            try
            {
                string roomName = Context.Items["RoomName"]?.ToString();
                string userName = Context.Items["UserName"]?.ToString();

                await Clients.OthersInGroup(roomName)
                                        .SendAsync("PeerSelectionCleared", new SelectionEvent
                                        {
                                            ConnectionId = Context.ConnectionId,
                                            ElementIds = new()
                                        });
                await Clients.OthersInGroup(roomName).SendAsync("UserLeft", userName);

                // Remove from SignalR group
                await Groups.RemoveFromGroupAsync(Context.ConnectionId, roomName);
                await _redisService.DeleteAsync(SelectionKey(Context.ConnectionId));

                // Remove from diagram users tracking
                if (_diagramUsers.TryGetValue(Context.ConnectionId, out var user))
                {
                    if (user != null)
                        _diagramUsers.TryRemove(Context.ConnectionId, out _);
                }
                List<string> activeUsers = GetCurrentUsers();
                await Clients.Group(roomName).SendAsync("CurrentUsers", activeUsers);
                // Clear context
                Context.Items.Remove("DiagramId");
                Context.Items.Remove("UserId");
                Context.Items.Remove("UserName");
                await base.OnDisconnectedAsync(exception);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error during disconnect cleanup for connection {ConnectionId}", Context.ConnectionId);
            }
            await base.OnDisconnectedAsync(exception);
        }
    }
}
```

### Step 2: Register services, Redis backplane, CORS, and map the hub (Program.cs)

Add these registrations to your server's Program.cs so clients can connect and scale via Redis. Adjust policies/connection strings to your environment.

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

### Step 3: Configure Redis cache connection string at the application level

Configure the Redis that stores temporary data for the collaborative editing session. Provide the Redis connection string in `appsettings.json` file.

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


## Model types used in the sample (minimal)

Define the following models used by the snippets:

```csharp
public sealed class SelectionEvent
{
    public string ConnectionId { get; set; } = string.Empty;
    public string? UserName { get; set; }
    public List<string>? ElementIds { get; set; }
    public Rect? SelectorBounds { get; set; } // define Rect for your app
}

public sealed class DiagramUser
{
    public string ConnectionId { get; set; } = string.Empty;
    public string UserName { get; set; } = "User";
}

public sealed class DiagramUpdateMessage
{
    public string SourceConnectionId { get; set; } = string.Empty;
    public long Version { get; set; }
    public List<string>? ModifiedElementIds { get; set; }
    public DateTimeOffset Timestamp { get; set; } = DateTimeOffset.UtcNow;
}

public sealed class DiagramData
{
    public string DiagramId { get; set; } = string.Empty;
    public string? SerializedState { get; set; }
    public long Version { get; set; }
}
```

## Client essentials (versioning, reconnect, and revert)

```csharp
long clientVersion = 0;
bool isRevertingCurrentChanges = false;

private void UpdateVersion(long serverVersion)
{
    clientVersion = serverVersion;
}

private async Task RevertCurrentChanges(List<string> elementIds)
{
    isRevertingCurrentChanges = true;
    try
    {
        await ReloadElementsFromServerOrCache(elementIds);
    }
    finally
    {
        isRevertingCurrentChanges = false;
    }
}

// Rejoin the diagram room if connection drops and reconnects
connection.Reconnected += async _ =>
{
    await connection.SendAsync("JoinDiagram", roomName, diagramId, currentUser);
};
```

When using HistoryChange, declare:

```csharp
List<string> editedElements = new();
bool isGroupAction = false;
```

## Per-diagram versioning keys (server)

Avoid a global version key. Use per-diagram keys:

```csharp
private static string VersionKey(string diagramId) => $"diagram:{diagramId}:version";
private static string UpdateKey(long version, string diagramId) => $"diagram:{diagramId}:update:{version}";
private static string SelectionKey(string connectionId, string diagramId) => $"diagram:{diagramId}:selection:{connectionId}";
```

Read diagramId from Context.Items["DiagramId"] inside hub methods and use it for all keys.

## Conflict policy (optimistic concurrency)

- The client sends a payload with clientVersion and edited elementIds.
- Server compares with Redis version. If stale and elements overlap, ask client to revert and show conflict.
- If stale but no overlap, server increments and accepts.
- Clients must set clientVersion to the server version after each accepted update.

## Cleanup strategy for Redis

- Keep only the last K versions (e.g., 200), or
- Set a TTL on update keys to limit memory usage.

## Hosting, transport, and serialization

- Enable WebSockets on your host/reverse proxy; consider keep-alives.
- If WebSockets aren’t available, remove SkipNegotiation on the client to allow fallback transports.
- For large payloads, enable MessagePack on server (and client if applicable) and consider sending diffs.

## Security and rooms

- Derive roomName from diagramId (e.g., "diagram:" + diagramId) and validate/normalize on server.
- Consider authentication/authorization to join rooms.
- Rate-limit BroadcastToOtherClients if necessary.

## App settings example

```json
{
  "ConnectionStrings": {
    "RedisConnectionString": "<<Your Redis connection string>>"
  }
}
```

## CollaborationServer helper methods (required in the sample)

Implement or verify these server helpers exist in the Hub or related services; they are invoked in the snippets above:

- GetConnectionLock(string connectionId): returns a per-connection SemaphoreSlim for serializing updates.
- RequestAndLoadStateAsync(string roomName, string diagramId, string connectionId, CancellationToken abort): loads existing diagram state (from DB/Redis) and sends to caller via LoadDiagramData.
- GetDiagramVersion(): reads current version from Redis for the current diagram (use VersionKey(diagramId)); return 0 if missing.
- GetUpdatesSinceVersionAsync(long sinceVersion, int maxScan): reads recent DiagramUpdateMessage entries from Redis for conflict checks.
- StoreUpdateInRedis(DiagramUpdateMessage update, string connectionId): stores update under UpdateKey(update.Version, diagramId).
- UpdateSelectionBoundsInRedis(SelectionEvent evt, List<string>? elementIds, Rect? selectorBounds): persists the caller’s selection snapshot under SelectionKey(connectionId, diagramId).
- SendCurrentSelectionsToCaller(): gathers SelectionEvent for active peers in this diagram and sends PeerSelectionsBootstrap to the caller.
- GetCurrentUsers(): returns the display names of users in _diagramUsers for this diagram/group.
- RemoveOldUpdates(long latestVersion): trims old updates (keep last K versions or apply TTL) for this diagram.
- ClearConnectionsFromRedis(): clears stale selection keys for all users when the first user joins.
- SelectionKey(string connectionId): if you keep this overload, ensure it internally resolves diagramId; otherwise prefer SelectionKey(connectionId, diagramId).
- BuildSelectedElementEvent(IEnumerable<string>? elementIds, Rect? selectorBounds): constructs SelectionEvent with Context.ConnectionId and current user name.


The full version of the code discussed can be found in the GitHub location below.

GitHub Example: [Collaborative editing examples](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/UG-Samples/CollaborativeEditing/DiagramCollaborativeEditing/DiagramCollaborativeEditing)
