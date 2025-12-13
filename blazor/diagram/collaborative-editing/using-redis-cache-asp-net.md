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

Following things are needed to enable collaborative editing in Diagram Component

* SignalR
* Redis

## SignalR

In collaborative editing, real-time communication is essential for users to see each other’s changes instantly. We use a real-time transport protocol to efficiently send and receive data as edits occur. For this, we utilize SignalR, which supports real-time data exchange between the client and server. SignalR ensures that updates are transmitted immediately, allowing seamless collaboration by handling the complexities of connection management and offering reliable communication channels.

To make SignalR work in a distributed environment (with more than one server instance), it needs to be configured with either Azure SignalR Service or a Redis backplane.

### Scale-out SignalR using Azure SignalR service

Azure SignalR Service is a scalable, managed service for real-time communication in web applications. It enables real-time messaging between web clients (browsers) and your server-side application(across multiple servers).

Below is a code snippet to configure Azure SignalR in an ASP.NET Core application using the AddAzureSignalR method

```csharp
builder.Services.AddSignalR().AddAzureSignalR("<your-azure-signalr-service-connection-string>", options => {
    // Specify the channel name 
    options.Channels.Add("diagram-editor");
});
```

### Scale-out SignalR using Redis

Using a Redis backplane, you can achieve horizontal scaling of your SignalR application. The SignalR leverages Redis to efficiently broadcast messages across multiple servers. This allows your application to handle large user bases with minimal latency.

In the SignalR app, install the following NuGet package:

`Microsoft.AspNetCore.SignalR.StackExchangeRedis`

Below is a code snippet to configure Redis backplane in an ASP.NET Core application using the AddStackExchangeRedis method

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

To enable collaborative editing, inject CollaborativeEditingHandler and set the property `EnableCollaborativeEditing` to true in the Diagram, like in the code snippet below.

```razor
<SfDiagramComponent @ref="@Diagram" Width="100%" Height="500px" EnableCollaborativeEditing=true>
</SfDiagramComponent>
@code {
    SfDiagramComponent Diagram;
}
```

### Step 2: Configure SignalR to send and receive changes

To broadcast the changes made and receive changes from remote users, configure SignalR like below.

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
        if(connection == null)
        {
            connection = new HubConnectionBuilder()
                        .WithUrl("", options =>
                        {
                            options.SkipNegotiation = false;
                            options.Transports = Microsoft.AspNetCore.Http.Connections.HttpTransportType.WebSockets | 
                                    Microsoft.AspNetCore.Http.Connections.HttpTransportType.LongPolling;
                        })
                        .WithAutomaticReconnect()
                        .Build();
            connection.On<string>("OnSaveDiagramState", OnSaveDiagramState);
            connection.On("ShowConflict", ShowConflict);
            connection.On<long>("UpdateVersion", UpdateVersion);
            connection.On("RevertCurrentChanges", RevertCurrentChanges);
            connection.On<string>("OnConnectedAsync", OnConnectedAsync);
            connection.On<DiagramData>("LoadDiagramData", OnLoadDiagramData);
            connection.On<string>("SendData", async (diagramChanges) =>
            {
                await InvokeAsync(() => OnReceiveDiagramUpdate(diagramChanges));
            });

            connection.Reconnected += async newId =>
            {
                Console.WriteLine($"Reconnected. New ConnectionId: {newId}");
            };
            await connection.StartAsync();
        }
    }
    public async ValueTask DisposeAsync()
    {
        if (hubConnection is not null)
        {
            await hubConnection.DisposeAsync();
        }
    }
}
```

### Step 3: Join SignalR room while opening the diagram

When opening a diagram, we need to generate a unique ID for each diagram. These unique IDs are then used to create rooms using SignalR, which facilitates sending and receiving data from the server.

```csharp
    string diagramId = "diagram";
    string currentUser = string.Empty;
    string roomName = "diagram_group";
    protected override async Task OnInitializedAsync()
    {
        // Generate or use provided diagram ID
        currentUser = string.IsNullOrEmpty(currentUser) ? $"User_{Random.Shared.Next(1000, 9999)}" : currentUser;
    }
    private async Task OnConnectedAsync(string connectionId)
    {
        if(!string.IsNullOrEmpty(connectionId))
        {
            // Join the room after connection is established
            await connection.SendAsync("JoinDiagram", roomName, diagramId, currentUser);
        }
    }
```

### Step 4: Broadcast current editing changes to remote users

Changes made on the client-side need to be sent to the server-side to broadcast them to other connected users. To send the changes made to the server, use the method shown below from the diagram using the `HistoryChange` event.

```razor
<SfDiagramComponent @ref="@Diagram" Width="100%" Height="500px" EnableCollaborativeEditing=true HistoryChange="@OnHistoryChange">
</SfDiagramComponent>

@code {
    private async void HistoryChanged(HistoryChangedEventArgs args)
    {
        if (args != null && DInstance.EnableCollaborativeEditing && canRender && !isRevertingCurrentChanges)
        {
            List<string> parsedData = DInstance.SerializeDiagramChanges(args);
            var editedElements = GetEditedElementIds(args).ToList();
            await connection.SendAsync("BroadcastToOtherClients", parsedData, clientVersion, editedElements, args.EntryType.ToString());
        }
    }
    private List<NodeBase> GetChangedObjects(HistoryChangedEventArgs args, HistoryEntryBase historyEntry)
    {
        if (args.ActionTrigger is not (HistoryChangedAction.Undo or HistoryChangedAction.Redo))
        {
            return args.Source;
        }

        IDiagramObject? historyObject = (args.ActionTrigger == HistoryChangedAction.Undo)
                                ? historyEntry.UndoObject
                                : historyEntry.RedoObject;

        switch (historyObject)
        {
            case DiagramSelectionSettings selectionSettings:
                {
                    var objects = new List<NodeBase>();

                    objects.AddRange(selectionSettings.Nodes);
                    objects.AddRange(selectionSettings.Connectors);
                    objects.AddRange(selectionSettings.Swimlanes);
                    objects.AddRange(selectionSettings.Phases);
                    objects.AddRange(selectionSettings.Lanes);

                    if (selectionSettings.Header != null)
                    {
                        objects.Add(selectionSettings.Header);
                    }

                    return objects;
                }
            case NodeBase nodeBase:
                {
                    return new List<NodeBase> { nodeBase };
                }
            default:
                {
                    return args.Source;
                }
        }
    }

    private (List<Node> Nodes, List<Swimlane> Swimlanes, List<Connector> Connectors, List<Phase> Phases, List<Lane> Lanes, List<SwimlaneHeader> Headers)
    ExtractObjects(List<NodeBase> changedObjects, HistoryChangedEventArgs args, HistoryEntryBase historyEntry)
    {
        var nodes = new List<Node>();
        var swimlanes = new List<Swimlane>();
        var connectors = new List<Connector>();
        var phases = new List<Phase>();
        var lanes = new List<Lane>();
        var headers = new List<SwimlaneHeader>();

        if (changedObjects == null) return (nodes, swimlanes, connectors, phases, lanes, headers);

        foreach (var obj in changedObjects)
        {
            switch (obj)
            {
                case Swimlane swimlane:
                    swimlanes.Add(swimlane);
                    break;
                case Node node:
                    nodes.Add(node);
                    break;
                case Connector connector:
                    connectors.Add(connector);
                    break;
                case Phase phase:
                    phases.Add(phase);
                    break;
                case Lane lane:
                    lanes.Add(lane);
                    break;
                case SwimlaneHeader header:
                    headers.Add(header);
                    break;
            }
        }
        return (nodes, swimlanes, connectors, phases, lanes, headers);
    }
}
```

## How to enable collaborative editing in ASP.NET Core

### Step 1: Configure SignalR in ASP.NET Core

We are using Microsoft SignalR to broadcast the changes. Please add the following configuration to your application’s `Program.cs` file.

```csharp
using Microsoft.AspNetCore.SignalR;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddSignalR();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
app.MapHub<DiagramHub>("/diagramhub");

app.Run();
```

### Step 2: Configure SignalR hub to create room for collaborative editing session

To manage groups for each diagram, create a folder named “Hubs” and add a file named “DiagramHub.cs” inside it. Add the following code to the file to manage SignalR groups using room names.

Join the group by using unique id of the diagram by using `JoinGroup` method.

```csharp
using Microsoft.AspNetCore.SignalR;
using System.Collections.Concurrent;

namespace DiagramServerApplication.Hubs
{
    public class DiagramHub : Hub
    {
        private static readonly ConcurrentDictionary<string, HashSet<string>> Rooms = new ConcurrentDictionary<string, HashSet<string>>();

        public async Task JoinDiagram(string roomName, string diagramId, string userName)
        {
            try
            {
                string userId = Context.ConnectionId;
                // Check if user is already in the diagram (prevent duplicates)
                if (_diagramUsers.TryGetValue(userId, out var existingUser))
                {
                    if (existingUser != null)
                    {
                        // Remove old connection if it exists
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
                    JoinedAt = DateTime.UtcNow
                };
                bool userExists = _diagramUsers?.Count > 0;
                if (!userExists)
                    await ClearConnectionsFromRedis();


                _diagramUsers.AddOrUpdate(userId, diagramUser, 
                    (key, existingValue) => diagramUser // Value to update if key exists
                );

                await RequestAndLoadStateAsync(
    roomName,
    diagramId,
    Context.ConnectionId,
    Context.ConnectionAborted);

                long currentServerVersion = await GetDiagramVersion();
                await Clients.Caller.SendAsync("UpdateVersion", currentServerVersion);
                await Clients.OthersInGroup(roomName).SendAsync("UserJoined", userName);
                await SendCurrentSelectionsToCaller();

                _logger.LogInformation("User {UserId} ({UserName}) joined diagram {DiagramId}. Total users: {UserCount}",
                    userId, userName, diagramId, _diagramUsers.Count);
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
                var versionKey = "diagram:version_4000";
                
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

                    var overlaps = elementIds.Where(id => recentlyTouched.Contains(id)).Distinct().ToList();
                    if (overlaps.Count > 0)
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
                    Timestamp = DateTime.UtcNow,
                    Version = serverVersionFinal,
                    ModifiedElementIds = elementIds
                };

                await StoreUpdateInRedis(update, connId);
                await Clients.OthersInGroup(roomName).SendAsync("ReceiveData", payloads);
                await Clients.Caller.SendAsync("UpdateSelectionHighlighter");
                await SelectElements(currentSelection.ElementIds, currentSelection.SelectorBounds, true);
                await Clients.Groups(roomName).SendAsync("UpdateVersion", serverVersionFinal);

                await RemoveOldUpdates(serverVersionFinal);
            }
            finally
            {
                gate.Release();
            }
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            foreach (var room in Rooms)
            {
                if (room.Value.Contains(Context.ConnectionId))
                {
                    room.Value.Remove(Context.ConnectionId);
                    await Groups.RemoveFromGroupAsync(Context.ConnectionId, room.Key);
                    await Clients.Group(room.Key).SendAsync("UserLeft", Context.ConnectionId);
                    if (room.Value.Count == 0)
                    {
                        Rooms.TryRemove(room.Key, out _);
                    }
                    break;
                }
            }
            await base.OnDisconnectedAsync(exception);
        }
    }
}
```

### Step 3: Configure Redis cache connection string in application level

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

### Step 4: Configure Web API actions for collaborative editing

#### Import File

When opening a diagram, check the Redis cache for pending operations and retrieve them for the collaborative editing session.
If pending operations exist, apply them to the `Diagram` instance using the `UpdateActions` method before converting it to the SFDT format.

```csharp
[HttpGet("LoadDiagram/{diagramId}")]
public async Task<IActionResult> LoadDiagram(string diagramId)
{
    var diagramData = await _redisService.GetAsync(DIAGRAM_UPDATES_CHANNEL_PREFIX + diagramId);
    if (diagramData == null)
    { 
        // Load default diagram or from permanent storage
        return Ok(new { DiagramData = "{}", Version = 0 });
    }
    return Ok(new { DiagramData = diagramData, Version = await _redisService.GetAsync<long>(DIAGRAM_OPERATIONS_COUNT_PREFIX + diagramId) });
}
```

#### Update editing records to Redis cache

Each edit operation made by the user is sent to the server and pushed into a Redis list data structure. Each operation is assigned a version number upon insertion into Redis.

After inserting the records to the server, the position of the current editing operation must be transformed relative to any previous editing operations not yet synced with the client using the `TransformOperation` method to resolve any potential conflicts with the help of the Operational Transformation algorithm.

Once the conflict is resolved, the current operation is broadcast to all connected users within the group.

```csharp
[HttpPost("UpdateDiagram/{diagramId}")]
public async Task<IActionResult> UpdateDiagram(string diagramId, [FromBody] List<string> changes)
{
    await _redisService.SetAsync(DIAGRAM_UPDATES_CHANNEL_PREFIX + diagramId, System.Text.Json.JsonSerializer.Serialize(changes));
    await _redisService.IncrementAsync(DIAGRAM_OPERATIONS_COUNT_PREFIX + diagramId);
    await _hubContext.Clients.Group(diagramId).SendAsync("ReceiveDiagramChanges", changes);
    return Ok();
}
```

The full version of the code discussed can be found in the GitHub location below.

GitHub Example: Collaborative editing examples
