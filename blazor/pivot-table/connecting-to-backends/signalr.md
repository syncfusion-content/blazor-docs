---
layout: post
title: Blazor Pivot Table Real-time Updates Using SignalR | Syncfusion
description: Learn how to use SignalR to push real-time updates into the Syncfusion Blazor Pivot Table with live data synchronization and automatic refresh.
platform: Blazor
control: PivotTable
documentation: ug
---

# Real-time Updates using SignalR in Blazor Pivot Table

The [Blazor Pivot Table](https://www.syncfusion.com/blazor-components/blazor-pivot-table) supports real-time data binding using **SignalR**, a library for bidirectional communication between servers and clients. This approach enables live aggregation updates without page refreshes, making it useful for live dashboards, monitoring surfaces, and real-time analytics.

The sample ships with **runtime controls** (Start/Stop and a configurable Feed Delay input) so users can pause, resume, and re-tune the live update interval directly from the UI. The Pivot Table is kept in sync automatically by calling `RefreshAsync(true)` whenever the hub broadcasts new data, and the background loop mutates **all** records each cycle so the changes are immediately visible across rows and columns.

## What Is SignalR?

SignalR is an open-source .NET library that simplifies adding real-time web functionality to applications. It negotiates an available transport, such as WebSockets, Server-Sent Events, or Long Polling, and provides a high-level API for server-to-client and client-to-server communication. In this Interactive Server sample, the .NET `HubConnection` runs on the server as part of the Blazor component circuit; it is not a browser-hosted .NET client.

## Key Benefits of SignalR

- **Real-Time Communication**: Establish persistent connections for instant data updates across all connected clients.
- **Bidirectional**: Support both server-to-client (broadcasting) and client-to-server (commands) communication.
- **Automatic Transport Selection**: Intelligently choose the best transport protocol (WebSockets, SSE, Long Polling) based on browser and server capabilities.
- **Scalable Broadcasting**: Efficiently broadcast updates to multiple clients simultaneously using SignalR groups.
- **Built-in Reconnection**: Supports configurable reconnect attempts after an established connection is lost. The default policy tries after 0, 2, 10, and 30 seconds, then stops; it does not retry an initial `StartAsync` failure.
- **No Page Refresh Required**: Update the Pivot Table dynamically without reloading the page.
- **Runtime Update Control**: Pause, resume, and submit a new update interval from the UI without reloading the application. The UI minimum is 2000 ms.

## Prerequisites

Ensure the following software and packages are installed before proceeding:

| Software/Package | Version | Purpose |
|-----------------|---------|---------|
| Visual Studio | 2026 (18.0) or later | Development IDE with the ASP.NET and web development workload |
| .NET SDK | 10.0.x | SDK for a project that targets `net10.0` |
| Microsoft.AspNetCore.SignalR.Client | 10.0.10 | Tested SignalR .NET client version |
| Syncfusion.Blazor.PivotTable | {{site.blazorversion}} | Tested Pivot Table component version |
| Syncfusion.Blazor.Themes | {{site.blazorversion}} | Tested theme package version; keep it aligned with the Pivot Table package |

This guide assumes a .NET 10 Blazor Web App named `Pivot_SignalR` with global Interactive Server rendering. Create that baseline with `dotnet new blazor -n Pivot_SignalR -f net10.0 --interactivity Server --all-interactive`, or adapt the `Pivot_SignalR` namespaces throughout the guide to match an existing project. Per-page interactivity also works, but `Home.razor` must then use the `InteractiveServer` render mode.

Syncfusion components require a valid license. Obtain a [Syncfusion license key](https://blazor.syncfusion.com/documentation/getting-started/license-key/how-to-register-in-an-application) before running the sample, and register it during application startup. Do not commit production license keys to source control; load the key from an appropriate secret or configuration provider.

## Setting Up SignalR with Real-Time Data

### Step 1: Install Required NuGet Packages

SignalR packages are essential for implementing real-time communication. In this Interactive Server sample, the .NET client library runs inside the server-side Blazor circuit, while ASP.NET Core hosts the hub and broadcasts messages. A Blazor WebAssembly implementation has different hosting and security considerations and is outside this guide's scope.

**Instructions:**

**Method 1: Using Package Manager Console**

1. Open Visual Studio 2026.
2. Navigate to **Tools → NuGet Package Manager → Package Manager Console**.
3. Run the following commands:

```powershell
Install-Package Microsoft.AspNetCore.SignalR.Client -Version 10.0.10
Install-Package Syncfusion.Blazor.PivotTable -Version {{site.blazorversion}}
Install-Package Syncfusion.Blazor.Themes -Version {{site.blazorversion}}
```

**Method 2: Using NuGet Package Manager UI**

1. Open **Visual Studio 2026 → Tools → NuGet Package Manager → Manage NuGet Packages for Solution**.
2. Search for and install each package:
   - **Microsoft.AspNetCore.SignalR.Client** (10.0.10 or later)
   - **[Syncfusion.Blazor.PivotTable](https://www.nuget.org/packages/Syncfusion.Blazor.PivotTable/)** (version {{site.blazorversion}})
   - **[Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)** (version {{site.blazorversion}})

All required packages are now installed. Only the **client** package (`Microsoft.AspNetCore.SignalR.Client`) needs a manual install — the `Microsoft.AspNetCore.SignalR` **server** library ships automatically with the ASP.NET Core runtime (`Microsoft.NET.Sdk.Web`), so `AddSignalR()` in `Program.cs` needs no extra package reference.

### Step 2: Create the Data Model

A data model represents the structure of real-time data that will be transmitted between server and clients. For this guide, use an **Order** model to represent order records displayed in the Pivot Table.

**Instructions:**

1. Create a new folder named `Models` in the Blazor application project (if it doesn't exist).
2. Inside the `Models` folder, create a new file named **Order.cs**.
3. Define the **Order** class with the following code:

```csharp
namespace Pivot_SignalR.Models;

/// <summary>
/// Represents an order used in the Pivot Table SignalR sample.
/// </summary>
public class Order
{
    /// <summary>
    /// Gets or sets the unique order identifier.
    /// </summary>
    public int OrderID { get; set; }

    /// <summary>
    /// Gets or sets the customer name.
    /// </summary>
    public string CustomerName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the employee identifier.
    /// </summary>
    public int EmployeeID { get; set; }

    /// <summary>
    /// Gets or sets the freight amount.
    /// </summary>
    public double Freight { get; set; }

    /// <summary>
    /// Gets or sets the shipping city.
    /// </summary>
    public string ShipCity { get; set; } = string.Empty;
}
```

**Explanation:**
- The `Order` class contains the fields that the Pivot Table aggregates: `CustomerName`, `EmployeeID`, and `Freight`.
- `OrderID` uniquely identifies each record.
- `ShipCity` is available for additional pivoting if required.
- Fields are simple POCO properties so SignalR can serialize the payload without custom converters.

The data model has been successfully created.

### Step 3: Create the Data Service

A data service manages in-memory order data. This service holds the shared state that both the Pivot Table adaptor and the background push service read from, and is shared across the application via dependency injection.

**Instructions:**

1. Create a new folder named `Services` in the Blazor application project.
2. Inside the `Services` folder, create a new file named **OrderDataService.cs**.
3. Define the **OrderDataService** class with the following code:

```csharp
using Pivot_SignalR.Models;

namespace Pivot_SignalR.Services;

public class OrderDataService
{
    private readonly List<Order> orders =
    [
        new() { OrderID = 1, CustomerName = "John Smith", EmployeeID = 101, Freight = 32.50, ShipCity = "New York" },
        new() { OrderID = 2, CustomerName = "Andrew Fuller", EmployeeID = 102, Freight = 45.75, ShipCity = "London" },
        new() { OrderID = 3, CustomerName = "Nancy Davolio", EmployeeID = 103, Freight = 28.25, ShipCity = "Berlin" },
        new() { OrderID = 4, CustomerName = "Robert King", EmployeeID = 104, Freight = 62.00, ShipCity = "Paris" },
        new() { OrderID = 5, CustomerName = "Margaret Peacock", EmployeeID = 105, Freight = 19.80, ShipCity = "Madrid" },
        new() { OrderID = 6, CustomerName = "Steven Buchanan", EmployeeID = 106, Freight = 75.40, ShipCity = "Rome" },
        new() { OrderID = 7, CustomerName = "Laura Callahan", EmployeeID = 107, Freight = 88.90, ShipCity = "Tokyo" },
        new() { OrderID = 8, CustomerName = "Michael Suyama", EmployeeID = 108, Freight = 54.25, ShipCity = "Sydney" },
        new() { OrderID = 9, CustomerName = "Janet Leverling", EmployeeID = 109, Freight = 29.50, ShipCity = "Toronto" },
        new() { OrderID = 10, CustomerName = "Anne Dodsworth", EmployeeID = 110, Freight = 66.75, ShipCity = "Singapore" },
        new() { OrderID = 11, CustomerName = "David Wilson", EmployeeID = 111, Freight = 41.20, ShipCity = "Dubai" },
        new() { OrderID = 12, CustomerName = "Emma Thompson", EmployeeID = 112, Freight = 93.60, ShipCity = "Amsterdam" },
        new() { OrderID = 13, CustomerName = "Chris Martin", EmployeeID = 113, Freight = 22.10, ShipCity = "Brussels" },
        new() { OrderID = 14, CustomerName = "Sophia Brown", EmployeeID = 114, Freight = 71.85, ShipCity = "Stockholm" },
        new() { OrderID = 15, CustomerName = "Daniel Green", EmployeeID = 115, Freight = 58.30, ShipCity = "Oslo" },
        new() { OrderID = 16, CustomerName = "Olivia Harris", EmployeeID = 116, Freight = 49.90, ShipCity = "Helsinki" },
        new() { OrderID = 17, CustomerName = "Liam Walker", EmployeeID = 117, Freight = 85.45, ShipCity = "Copenhagen" },
        new() { OrderID = 18, CustomerName = "Ava Scott", EmployeeID = 118, Freight = 38.70, ShipCity = "Vienna" },
        new() { OrderID = 19, CustomerName = "Noah Adams", EmployeeID = 119, Freight = 77.15, ShipCity = "Prague" },
        new() { OrderID = 20, CustomerName = "Mia Baker", EmployeeID = 120, Freight = 26.95, ShipCity = "Budapest" },
        new() { OrderID = 21, CustomerName = "Ethan Clark", EmployeeID = 121, Freight = 68.40, ShipCity = "Warsaw" },
        new() { OrderID = 22, CustomerName = "Charlotte Lewis", EmployeeID = 122, Freight = 44.80, ShipCity = "Athens" },
        new() { OrderID = 23, CustomerName = "James Hall", EmployeeID = 123, Freight = 91.25, ShipCity = "Lisbon" },
        new() { OrderID = 24, CustomerName = "Amelia Young", EmployeeID = 124, Freight = 35.60, ShipCity = "Zurich" },
        new() { OrderID = 25, CustomerName = "Benjamin Allen", EmployeeID = 125, Freight = 59.75, ShipCity = "Dublin" }
    ];

    public List<Order> GetOrders()
    {
        return orders;
    }
}
```

**Explanation:**
- `orders`: An in-memory `List<Order>` seeded with 25 sample orders across 25 cities.
- `GetOrders()`: Returns the shared list so the adaptor and background service always read the latest state.
- Registered as a **singleton** in [Step 7: Register Services in Program.cs](#step-7-register-services-in-programcs) so all clients and the background service share one copy.

> **Thread-safety note:** The `orders` list is a mutable `List<Order>` shared by the background service and adaptor, so the sample is not thread-safe. Locking only inside `GetOrders()` would be insufficient because it returns the same list for later enumeration and mutation. For production, perform mutation and snapshot creation under the same synchronization boundary, then return and broadcast an immutable or copied snapshot.

The data service is now ready to provide real-time order data.

### Step 4: Create the SignalR Hub

A SignalR Hub is the server-side component that manages client connections and broadcasts data to connected clients. It acts as a communication bridge between the server and all connected clients, and exposes an RPC method that lets any connected client reconfigure the live update loop at runtime.

> **Note:** This step's `PivotHub` class injects `UpdateConfiguration`, which is defined in [Step 5](#step-5-create-the-updateconfiguration-service). Create `UpdateConfiguration.cs` before compiling the hub; both files must exist before the application builds.

**Instructions:**

1. Create a new folder named `Hubs` in the Blazor application project.
2. Inside the `Hubs` folder, create a new file named **PivotHub.cs**.
3. Define the **PivotHub** class with the following code:

```csharp
using Microsoft.AspNetCore.SignalR;
using Pivot_SignalR.Services;

namespace Pivot_SignalR.Hubs;

public class PivotHub : Hub
{
    private readonly UpdateConfiguration configuration;

    public PivotHub(UpdateConfiguration configuration)
    {
        this.configuration = configuration;
    }

    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
    }

    public override async Task OnDisconnectedAsync(Exception? exception)
    {
        await base.OnDisconnectedAsync(exception);
    }

    public async Task SubscribeToOrders()
    {
        await Groups.AddToGroupAsync(
            Context.ConnectionId,
            "Orders");
    }

    public async Task UnsubscribeFromOrders()
    {
        await Groups.RemoveFromGroupAsync(
            Context.ConnectionId,
            "Orders");
    }

    public Task UpdateSettings(bool isRunning, int interval)
    {
        configuration.IsRunning = isRunning;
        configuration.Interval = interval;

        return Task.CompletedTask;
    }
}
```

**Explanation:**
- `OnConnectedAsync()`: Invoked when a client connects. Allows base connection lifecycle handling.
- `OnDisconnectedAsync()`: Invoked when a client disconnects. Allows cleanup logging if required.
- `SubscribeToOrders()`: Adds the client connection to the `"Orders"` group for receiving broadcast updates. Clients call this method after `StartAsync()` to scope updates to interested dashboards only.
- `UnsubscribeFromOrders()`: Removes the client from the `"Orders"` group when they no longer want updates.
- `UpdateSettings(bool isRunning, int interval)`: Changes the application-wide update state and interval by writing to the shared `UpdateConfiguration` singleton. An interval change is read when the background loop begins its next delay; it does not shorten or cancel a delay already in progress.

> **Security and validation:** The sample hub is unauthenticated, performs no server-side interval validation, and lets any connected client change settings for every user. Before production use, require authorization, restrict access to this method, validate the interval against an accepted range, and reject unauthorized or invalid calls.

> **Note:** This sample broadcasts to `Clients.All` from the background service (see Step 6), so the subscription methods are not called by the implemented client. If a production version uses `Clients.Group("Orders")`, call `SubscribeToOrders` after the initial connection and again from the `Reconnected` handler because a reconnected client receives a new connection ID and does not retain its previous group membership.

The hub is now ready to manage real-time connections.

### Step 5: Create the UpdateConfiguration Service

A small shared configuration object coordinates the live update behavior between the hub (which receives runtime changes from clients) and the background service (which runs the push loop). It is registered as a singleton so all components read and write the same state.

**Instructions:**

1. Inside the `Services` folder, create a new file named **UpdateConfiguration.cs**.
2. Define the **UpdateConfiguration** class with the following code:

```csharp
namespace Pivot_SignalR.Services;

public class UpdateConfiguration
{
    public bool IsRunning { get; set; } = true;

    public int Interval { get; set; } = 5000;
}
```

**Explanation:**
- `IsRunning`: When `true` (default), the background loop mutates data and broadcasts each cycle. When `false`, the loop skips the mutation/broadcast step — effectively pausing live updates without stopping the service.
- `Interval`: Delay in milliseconds between update cycles. It defaults to `5000` ms (5 seconds). The UI suggests a minimum of `2000` ms, but the hub does not enforce that limit. A non-UI client can submit zero, a negative number, or an excessively large value; zero can create a tight loop, and invalid values can fail the delay. Validate a documented server-side range before storing the value.

> **Concurrency note:** `UpdateConfiguration` is a singleton read by the background service and written by hub invocations. The sample properties are not synchronized. For production, protect reads and writes with a lock, an immutable snapshot, or suitable atomic synchronization. No application restart is required, but an interval change does not affect a delay already in progress.

The configuration service is now ready. Its DI registration is shown in Step 7 (`Program.cs`).

### Step 6: Create the OrderUpdateBackgroundService

A background service continuously runs in the background, periodically mutates the order data, and broadcasts the full order collection to all connected clients via SignalR. This service simulates a live data producer (for example, an order intake system). Its update interval and running state are driven dynamically by the shared `UpdateConfiguration` singleton.

**Instructions:**

1. Inside the `Services` folder, create a new file named **OrderUpdateBackgroundService.cs**.
2. Define the **OrderUpdateBackgroundService** class with the following code:

```csharp
using Microsoft.AspNetCore.SignalR;
using Pivot_SignalR.Hubs;

namespace Pivot_SignalR.Services;

public class OrderUpdateBackgroundService : BackgroundService
{
    private readonly IHubContext<PivotHub> hubContext;
    private readonly OrderDataService orderDataService;
    private readonly UpdateConfiguration configuration;
    private readonly Random random = new();

    public OrderUpdateBackgroundService(IHubContext<PivotHub> hubContext,
                                         OrderDataService orderDataService,
                                         UpdateConfiguration configuration)
    {
        this.hubContext = hubContext;
        this.orderDataService = orderDataService;
        this.configuration = configuration;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            // The delay is controlled dynamically through UpdateConfiguration.Interval.
            await Task.Delay(configuration.Interval, stoppingToken);

            // Start/Stop support — skip the cycle when paused.
            if (!configuration.IsRunning)
            {
                continue;
            }

            var orders = orderDataService.GetOrders();

            if (orders.Count > 0)
            {
                // Update all records each cycle so changes are visible across the grid.
                foreach (var order in orders)
                {
                    order.Freight += random.Next(1, 10);
                }
            }

            // Broadcast the updated data to all connected clients.
            await hubContext.Clients.All.SendAsync("ReceiveOrderUpdate", orders, cancellationToken: stoppingToken);
        }
    }
}
```

**Explanation:**
- **Lifetime**: Implements `BackgroundService`, which runs continuously until the application stops.
- **Dynamic Delay**: `await Task.Delay(configuration.Interval, stoppingToken)` reads the interval before each delay. A new value applies after the current delay and cycle complete; changing an in-progress delay requires a separate cancellation mechanism. The sample UI suggests 2000 ms as the minimum, but only server-side validation can enforce it.
- **Start/Stop Support**: The `if (!configuration.IsRunning) { continue; }` guard skips the mutation and broadcast when updates are paused. Clients toggle this through the hub's `UpdateSettings` RPC.
- **Mutation**: Updates **all** orders each cycle. As written, `Random.Next(1, 10)` increments each `Freight` value by an integer from 1 through 9 because the upper bound is exclusive.
- **Broadcasting**: Uses `IHubContext<PivotHub>` to send the full order collection to all connected clients via the `ReceiveOrderUpdate` event.

The background service ensures real-time updates are delivered continuously to all connected clients.

### Step 7: Register Services in Program.cs

The `Program.cs` file is where application services are registered and configured for dependency injection. This file must be updated to enable SignalR and register all required services.

**Instructions:**

1. Open the `Program.cs` file at the project root.
2. Update the service registration code to include SignalR and background services:

```csharp
using Pivot_SignalR.Components;
using Pivot_SignalR.Hubs;
using Pivot_SignalR.Services;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// Register Syncfusion
builder.Services.AddSyncfusionBlazor();

// Register application services
builder.Services.AddSingleton<OrderDataService>();

// Register Custom Adaptor
builder.Services.AddScoped<OrderAdaptor>();

// Register shared update configuration (IsRunning + Interval)
builder.Services.AddSingleton<UpdateConfiguration>();

// Register SignalR
builder.Services.AddSignalR();

// Register Background Service
builder.Services.AddHostedService<OrderUpdateBackgroundService>();

var app = builder.Build();

// Register Syncfusion license
// Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR LICENSE KEY");

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Map SignalR Hub
app.MapHub<PivotHub>("/pivothub");

app.Run();
```

**Explanation:**
- **`AddSyncfusionBlazor()`**: Registers the Syncfusion Blazor components, including `SfPivotView`.
- **`AddSingleton<OrderDataService>`**: Registers as a singleton so the same in-memory list is shared across all requests and the background service.
- **`AddScoped<OrderAdaptor>`**: Registers as scoped so each connection gets its own adaptor instance, while still reading from the shared singleton data service.
- **`AddSingleton<UpdateConfiguration>`**: Registers the shared `IsRunning` / `Interval` state as a singleton so the hub and background service read and write the same values.
- **`AddSignalR()`**: Enables SignalR functionality with default configuration.
- **`AddHostedService<OrderUpdateBackgroundService>`**: Registers the background service that mutates data and broadcasts updates.
- **`MapHub<PivotHub>("/pivothub")`**: Maps the SignalR hub endpoint at `/pivothub`; the negotiated transport can be WebSockets, Server-Sent Events, or Long Polling.

> **Important:** Map the hub exactly once to a unique route. Endpoint mapping order does not normally cause `AmbiguousMatchException`; that exception indicates duplicate or otherwise conflicting route registrations.

Service registration is now complete.

## Integrating the Blazor Pivot Table

### Integration Step 1: Configure Blazor Pivot Table Components

Syncfusion provides the `SfPivotView` component used to display aggregated data in a pivot layout. The Syncfusion.Blazor packages were installed in [Step 1: Install Required NuGet Packages](#step-1-install-required-nuget-packages) under the [Setting Up SignalR with Real-Time Data](#setting-up-signalr-with-real-time-data) heading, and `AddSyncfusionBlazor()` is registered in [Step 7: Register Services in Program.cs](#step-7-register-services-in-programcs) of the same heading.

**Instructions:**

* Import the required namespaces in the `Components/_Imports.razor` file. Append the following lines at the bottom of the existing `@using` directives (the Blazor template ships with some `@using` lines already present — keep them and add these below):

```csharp
@using Pivot_SignalR
@using Syncfusion.Blazor
```

* Add the following stylesheet and scripts inside the existing `<head>` element of the `Components/App.razor` file:

```html
<!-- Blazor Stylesheet -->
<link rel="stylesheet" href="_content/Syncfusion.Blazor.Themes/fluent2.css" />

<!-- Blazor Scripts -->
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
```

For this project, the **Fluent2** theme is used. A different theme can be selected or the existing theme can be customized based on project requirements. Refer to the [Blazor Components Appearance](https://blazor.syncfusion.com/documentation/appearance/themes) documentation to learn more about theming and customization options.

Blazor components are now configured and ready to use. For additional guidance, refer to the Pivot Table component's [getting‑started](https://blazor.syncfusion.com/documentation/pivot-table/getting-started-webapp) documentation.

### Integration Step 2: Create the Custom Adaptor for the Pivot Table

The Custom Adaptor bridges the Pivot Table with the in-memory data service by extending `DataAdaptor`. It returns the current order collection to the `SfDataManager` whenever the Pivot Table requests data. Create this adaptor before configuring the Pivot Table markup, since the markup references it.

**Instructions:**

* Inside the `Services` folder, create a new file named **OrderAdaptor.cs**.
* Define the **OrderAdaptor** class with the following code:

```csharp
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;
using Pivot_SignalR.Models;

namespace Pivot_SignalR.Services;

public class OrderAdaptor : DataAdaptor
{
    private readonly OrderDataService orderDataService;

    public OrderAdaptor(OrderDataService orderDataService)
    {
        this.orderDataService = orderDataService;
    }

    public override object Read(DataManagerRequest dataManagerRequest, string? key = null)
    {
        var orders = orderDataService.GetOrders();

        return new DataResult
        {
            Result = orders,
            Count = orders.Count
        };
    }

    public override Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
    {
        var orders = orderDataService.GetOrders();

        return Task.FromResult<object>(
            new DataResult
            {
                Result = orders,
                Count = orders.Count
            });
    }
}
```

**Explanation:**
- **`Read` / `ReadAsync`**: Methods called by the `SfDataManager` to fetch data for the Pivot Table.
- **`DataResult`**: Wraps the `Result` collection and the `Count`, which the Pivot Table uses for aggregation.
- The adaptor reads from the shared singleton `OrderDataService`, so every data request returns the latest in-memory state — including after the background service mutates a `Freight` value.

The adaptor is now ready to provide data for the Pivot Table.

### Integration Step 3: Configure the Blazor Pivot Table

The `Home.razor` component markup in this step displays the order data and live update controls. The SignalR connection and event handlers are added in the next step.

**Instructions:**

* Open the file named `Home.razor` in the `Components/Pages` folder.
* Add the following markup for the live update controls, the Pivot Table, and the data source configuration:

```cshtml
@page "/"

@using Microsoft.AspNetCore.SignalR.Client
@using Pivot_SignalR.Models
@using Pivot_SignalR.Services
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.PivotView
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

@implements IAsyncDisposable

@inject NavigationManager Navigation

<div class="head">
    <strong style="font-size:14px">
        Feed Delay (ms) :
    </strong>

    <SfNumericTextBox TValue="int" @bind-Value="FeedDelay" Width="150px" Min="2000" Step="1000"
                      Format="N0">
    </SfNumericTextBox>

    <SfButton CssClass="updatePivotData" OnClick="StartUpdating" Disabled="@IsRunning">
        Start Updating...
    </SfButton>

    <SfButton CssClass="updatePivotData" OnClick="StopUpdating" Disabled="@(!IsRunning)">
        Stop Updating...
    </SfButton>
</div>

<SfPivotView @ref="PivotObj" TValue="Order" Width="1000" Height="500" ShowFieldList="true">

    <PivotViewDataSourceSettings TValue="Order" ExpandAll="false" EnableSorting="true">

        <SfDataManager Adaptor="Adaptors.CustomAdaptor" AdaptorInstance="@typeof(OrderAdaptor)">
        </SfDataManager>

        <PivotViewRows>
            <PivotViewRow Name="CustomerName"></PivotViewRow>
        </PivotViewRows>

        <PivotViewColumns>
            <PivotViewColumn Name="EmployeeID"></PivotViewColumn>
        </PivotViewColumns>

        <PivotViewValues>
            <PivotViewValue Name="Freight"
                            Caption="Freight">
            </PivotViewValue>
        </PivotViewValues>

    </PivotViewDataSourceSettings>

    <PivotViewGridSettings ColumnWidth="120">
    </PivotViewGridSettings>

</SfPivotView>

<style>
    .head {
        margin-bottom: 10px;
    }

    .updatePivotData {
        margin-left: 10px !important;
    }
</style>
```

**Component Explanation:**

- **`@implements IAsyncDisposable`**: Implements the async disposal pattern to clean up the `HubConnection`.
- **`@inject NavigationManager Navigation`**: Used to build the absolute hub URL.
- **`<div class="head">`**: A small CSS class (defined in the `<style>` block at the end of the component) that adds a `10px` margin below the controls row to separate it from the Pivot Table.
- **`SfNumericTextBox`**: Bound to the `FeedDelay` field with `Min="2000"`, `Step="1000"`, and `Format="N0"`. `Min` is a UI constraint, not server-side validation. Editing the value alone does not send it to the hub; the sample sends the current value only when the user clicks Start or Stop.
- **`SfButton` (Start Updating...)**: Calls `StartUpdating`, which sets `IsRunning = true` (so this button becomes disabled and the Stop button becomes enabled) and invokes the hub's `UpdateSettings(true, FeedDelay)` RPC via `SendAsync`. The `CssClass="updatePivotData"` adds a 10px left margin (defined in the `<style>` block), and `Disabled="@IsRunning"` keeps the two buttons mutually exclusive.
- **`SfButton` (Stop Updating...)**: Calls `StopUpdating`, which sets `IsRunning = false` (toggling which button is disabled) and invokes `UpdateSettings(false, FeedDelay)` to pause updates without reloading the application. `Disabled="@(!IsRunning)"` ensures the Stop button is only clickable while updates are running.
- **`IsRunning`**: A `bool` field declared in the `@code` block (default `true`) that tracks whether the live loop is currently running and drives the `Disabled` state of both buttons.
- **`SfPivotView`**: The Syncfusion Pivot Table bound to `Order`.
- **`ShowFieldList="true"`**: Enables the built-in Field List so end users can drag-and-drop fields between rows, columns, and values at runtime.
- **`SfDataManager`**: Binds the Pivot Table to the custom `OrderAdaptor` instead of a REST URL.
- **`PivotViewRows`**: `CustomerName` is placed on rows.
- **`PivotViewColumns`**: `EmployeeID` is placed on columns.
- **`PivotViewValues`**: `Freight` is aggregated (sum by default) under the caption "Freight".
- **`PivotViewGridSettings`**: Sets a 120px column width for the rendered pivot grid.
- **`<style>` block**: Scope-limited CSS for `.head` (wrapper margin) and `.updatePivotData` (button left margin) so the controls sit with consistent spacing without affecting the rest of the page.

### Integration Step 4: Establish the SignalR Connection

The `OnInitializedAsync()` method is a Blazor lifecycle method that executes when the component is initialized. This is where the SignalR connection is established and configured, and where the `ReceiveOrderUpdate` handler triggers a full Pivot engine refresh via `RefreshAsync(true)`.

**Instructions:**

* In the `@code` block of `Home.razor`, add the `HubConnection` field, the `SfPivotView` reference, the `FeedDelay` and `IsRunning` fields, the `StartUpdating` / `StopUpdating` handlers, and the `OnInitializedAsync` lifecycle method:

```csharp
@code {
    private HubConnection? hubConnection;

    private SfPivotView<Order>? PivotObj;

    private int FeedDelay = 5000;

    private bool IsRunning = true;

    protected override async Task OnInitializedAsync()
    {
        hubConnection = new HubConnectionBuilder()
            .WithUrl(Navigation.ToAbsoluteUri("/pivothub"))
            .WithAutomaticReconnect()
            .Build();

        hubConnection.On<List<Order>>(
            "ReceiveOrderUpdate",
            async _ =>
            {
                if (PivotObj != null)
                {
                    // RefreshAsync(true) performs a full Pivot engine refresh
                    // and re-executes the Custom Adaptor, so the latest
                    // in-memory data is reflected immediately — no browser refresh.
                    await PivotObj.RefreshAsync(true);
                }

                await InvokeAsync(StateHasChanged);
            });

        await hubConnection.StartAsync();
    }

    private async Task StartUpdating()
    {
        IsRunning = true;

        if (hubConnection != null)
        {
            // SendAsync is fire-and-forget — the handler does not await the server's
            // acknowledgement before returning control to the UI thread.
            await hubConnection.SendAsync("UpdateSettings", true, FeedDelay);
        }
    }

    private async Task StopUpdating()
    {
        IsRunning = false;

        if (hubConnection != null)
        {
            await hubConnection.SendAsync("UpdateSettings", false, FeedDelay);
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

**Explanation:**

- **`HubConnectionBuilder().WithUrl(Navigation.ToAbsoluteUri("/pivothub"))`**: Builds the hub URL from the application's base URI and the `/pivothub` endpoint mapped in `Program.cs`. Using `ToAbsoluteUri` ensures the URL matches the host scheme and port.
- **`.WithAutomaticReconnect()`**: Enables reconnect attempts after an established connection is lost, using the default delays of 0, 2, 10, and 30 seconds. It does not retry the initial `StartAsync` call and stops after four failed attempts. Production UI should handle `Reconnecting`, `Reconnected`, and `Closed`, and provide a manual or custom retry path.
- **`.Build()`**: Finalizes the configuration and creates the `HubConnection` instance.
- **`FeedDelay`**: Two-way bound to the `SfNumericTextBox`. The default is `5000` ms, and the UI suggests a minimum of `2000` ms. The value is sent only on a Start/Stop click; changing the input alone has no server effect.
- **`IsRunning`**: A `bool` field (default `true`) that tracks the local UI state and drives `Disabled="@IsRunning"` / `Disabled="@(!IsRunning)"`. The sample changes it before sending the hub invocation, so a failed send can leave the UI inconsistent with server state.
- **`hubConnection.On<List<Order>>("ReceiveOrderUpdate", ...)`**: Registers a handler for the `ReceiveOrderUpdate` event broadcast by `OrderUpdateBackgroundService`. When the event fires, the handler:
  1. Calls `PivotObj.RefreshAsync(true)` directly (still on the SignalR background thread) so the Pivot Table performs a **full engine refresh** and re-executes the Custom Adaptor — the latest in-memory data (including the just-applied mutations) is reflected immediately without refreshing the browser.
  2. Marshals only `StateHasChanged` to the renderer thread via `await InvokeAsync(StateHasChanged);`.

  The handler parameter is named `_` (discard) on purpose: the broadcast payload (`List<Order>`) is ignored, and the Pivot Table re-reads the current state from `OrderDataService` via `OrderAdaptor`. The single shared in-memory list is the source of truth, so the pushed payload would only duplicate it.
- **`StartUpdating`**: Sets local `IsRunning = true`, then sends `UpdateSettings(true, FeedDelay)`. Production code should update or restore the UI based on the operation result.
- **`StopUpdating`**: Sets local `IsRunning = false`, then sends `UpdateSettings(false, FeedDelay)`. Production code should handle a disconnected connection or failed send and keep the UI consistent with server state.
- **`SendAsync` vs `InvokeAsync`**: The awaited `SendAsync` completes when the invocation has been sent; it does not wait for a return value from the hub method. Use `InvokeAsync` when the client needs a server result or completion semantics, and handle exceptions from either operation.
- **`await hubConnection.StartAsync()`**: Establishes a SignalR connection using the negotiated transport. WebSockets is preferred when available, but SignalR can fall back to Server-Sent Events or Long Polling.
- **`DisposeAsync`**: Disposes the `HubConnection` when the component is destroyed, closing the connection gracefully.

> **Production tip:** `StartAsync()` throws if the server is unreachable (for example, an untrusted HTTPS certificate or a blocked port). In production, wrap it in a `try/catch` and surface a connection-lost banner so the user can retry, rather than letting the exception crash the component:

```csharp
try
{
    await hubConnection.StartAsync();
}
catch (Exception ex)
{
    // Show a "Connection lost — click to retry" banner to the user.
    Console.Error.WriteLine($"Hub connection failed: {ex.Message}");
}
```

**Why `InvokeAsync` matters:** SignalR callbacks can run outside the Blazor renderer context. The shown sample marshals only `StateHasChanged`; for production, marshal both the Pivot Table refresh and `StateHasChanged` together through the component's `InvokeAsync` dispatcher and handle refresh exceptions.

**Why `RefreshAsync(true)`:** The boolean parameter is named `isDataRefresh`. Passing `true` requests a **complete Pivot engine refresh** — the Custom Adaptor (`OrderAdaptor.ReadAsync`) is executed again during the cycle, the Pivot Table re-aggregates from the freshly read data, and the updated values render in place. This enables true real-time updates with SignalR — no browser refresh required.

Passing `false` (the default behavior of the parameterless `RefreshAsync()` overload) re-renders the Pivot Table from its already-cached aggregated state **without** re-querying the Custom Adaptor. Use `false` when only the layout/styling changed (for example, after a Field List drag) and the underlying data is unchanged; use `true` — as this sample does on every `ReceiveOrderUpdate` broadcast — when the underlying `List<Order>` has been mutated and the Pivot Table must re-read the latest values.

### Integration Step 5: Pivot Refresh Flow on Push

Here is the refresh flow triggered when the server pushes an update:

The flow below shows the production-safe renderer-dispatch intent. The unchanged sample callback above calls `RefreshAsync(true)` before `InvokeAsync`; as noted above, production code should dispatch both operations together.

```text
OrderUpdateBackgroundService mutates ALL orders' Freight each cycle
         ↓
hubContext.Clients.All.SendAsync("ReceiveOrderUpdate", orders)
         ↓
Client HubConnection receives "ReceiveOrderUpdate"
         ↓
InvokeAsync(() => { PivotObj.RefreshAsync(true); StateHasChanged(); })
         ↓
SfPivotView performs a full Pivot engine refresh (Custom Adaptor re-executes)
         ↓
OrderAdaptor reads current List<Order> from OrderDataService
         ↓
Pivot Table re-aggregates Freight (sum) by CustomerName × EmployeeID
         ↓
Updated cells render in place — no manual refresh, no page reload
```

This loop repeats at the configured interval (default 5000 ms; UI minimum 2000 ms) while `UpdateConfiguration.IsRunning` is `true`. Users can pause, resume, or submit a new interval with the Start/Stop buttons. Server-side validation is required to enforce the minimum.

> **Performance note:** `RefreshAsync(true)` triggers a **full re-aggregation** of the pivot (no incremental diff) and re-executes the Custom Adaptor. At the demo interval (one push per 5000 ms; UI minimum 2000 ms), this is negligible, but for high-frequency producers (>1 Hz) consider throttling broadcasts or batching the mutations so the client isn't forced to re-aggregate on every single change.

### Integration Step 6: End-to-End Data and Control Flow

The diagram below shows how data and control pass through the sample on each broadcast cycle:

```text
SfPivotView
      ↓
 SfDataManager
      ↓
  OrderAdaptor
      ↓
OrderDataService
      ↓
OrderUpdateBackgroundService
      ↓
     PivotHub
      ↓
    SignalR
      ↓
 Blazor Client
```

**Server-to-Client (Broadcasting)**

1. `OrderUpdateBackgroundService` runs at the configured interval (default 5000 ms; UI minimum 2000 ms) and only when `UpdateConfiguration.IsRunning` is `true`.
2. It mutates **all** orders' `Freight` values, incrementing each by a random integer from 1 through 9, in the shared `OrderDataService` list.
3. It calls `hubContext.Clients.All.SendAsync("ReceiveOrderUpdate", orders)`. See **Integration Step 5** above for the resulting client-side refresh sequence.

**Client-to-Server (Subscription)**

1. Client opens the page → `OnInitializedAsync` builds the hub URL.
2. Client calls `await hubConnection.StartAsync()` to connect.
3. (Optional) Client calls `SubscribeToOrders` to join the `"Orders"` group for scoped broadcasts:

   ```csharp
   // Optional — only needed when the background service broadcasts to
   // Clients.Group("Orders") instead of Clients.All.
   await hubConnection.InvokeAsync("SubscribeToOrders");
   ```
4. Server adds the client to the group via `PivotHub.SubscribeToOrders`.

**Client-to-Server (Runtime Control)**

1. Client changes the **Feed Delay (ms)** value and then clicks **Start Updating...** or **Stop Updating...** to submit it. The 2000 ms minimum is enforced only by the UI.
2. The `StartUpdating` / `StopUpdating` handlers invoke the hub's `UpdateSettings(bool isRunning, int interval)` RPC.
3. The hub writes the new values into the shared `UpdateConfiguration` singleton.
4. The next `OrderUpdateBackgroundService` loop iteration reads the updated `IsRunning` / `Interval` and behaves accordingly — no application reload required.

> **Note:** See the troubleshooting table below for quick WS/Negotiate diagnostics.

## Live Update Controls

The sample includes runtime controls that let users pause, resume, and submit a live update interval without reloading the application. The controls are wired through the hub's application-wide `UpdateSettings(bool, int)` RPC method into the shared `UpdateConfiguration` singleton.

**Required namespaces:** The `SfNumericTextBox` and `SfButton` controls live in the `Syncfusion.Blazor.Inputs` and `Syncfusion.Blazor.Buttons` namespaces. These `@using` directives must appear at the top of `Home.razor` (in addition to `Syncfusion.Blazor.Data` and `Syncfusion.Blazor.PivotView` already used by the Pivot Table):

```csharp
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Inputs
```

> **Note:** Both directives are already included in the `Home.razor` markup shown in [Integration Step 3: Configure the Blazor Pivot Table](#integration-step-3-configure-the-blazor-pivot-table). They are listed here so the prerequisite is visible alongside the controls that require them.

### Controls Reference

| Control | Type | Purpose |
|---------|------|---------|
| Feed Delay (ms) | `SfNumericTextBox` | Set the interval sent by the next Start/Stop click. `Min="2000"`, `Step="1000"`, `Format="N0"`; the minimum is UI-only. |
| Start Updating... | `SfButton` | Resume the background push loop by invoking `UpdateSettings(true, FeedDelay)`. |
| Stop Updating... | `SfButton` | Pause the background push loop by invoking `UpdateSettings(false, FeedDelay)`. |

### Capabilities

- **Dynamic update interval**: Users can modify the update interval at runtime. The change flows through the hub into `UpdateConfiguration.Interval` and applies on the next background loop cycle.
- **Pause and resume**: `Start Updating...` and `Stop Updating...` toggle `UpdateConfiguration.IsRunning`. The background loop keeps running but skips the mutation and broadcast while paused.
- **In-flight broadcasts are not cancelled**: Clicking `Stop Updating...` only stops **future** broadcast cycles. If the server had already started a `SendAsync("ReceiveOrderUpdate", ...)` call moments before the Stop RPC arrived, that in-flight broadcast will still be delivered and the client's `ReceiveOrderUpdate` handler will still run a `RefreshAsync(true)`. There is no global "abort" signal — the next cycle after `IsRunning=false` is simply skipped.
- **No reload**: Both controls take effect without reloading the application.
- **Minimum interval**: The `SfNumericTextBox` applies `Min="2000"` in the UI, but the sample hub does not enforce that threshold for other clients.

> **Note:** The control markup is shown in **Integration Step 3 (Configure the Blazor Pivot Table)** and the handlers are shown in **Integration Step 4 (Establish the SignalR Connection)**. Refer to those steps for the complete `Home.razor` implementation.

## Running the Sample

### Build the Application

1. Open the terminal or Package Manager Console.
2. Navigate into the project directory:

   ```powershell
   cd Pivot_SignalR
   ```

3. Run the following command:

```powershell
dotnet build
```

### Run the Application

Return to the directory that contains the `Pivot_SignalR` project folder, then execute the following command. If you remain inside the project directory, use `dotnet run` instead.

```powershell
dotnet run --project Pivot_SignalR
```

### Access the Application

1. Open a web browser.
2. Navigate to the HTTPS URL printed in the terminal (typically `https://localhost:5xxx`).
3. The Pivot Table will render with order data aggregated as:
   - **Rows:** `CustomerName`
   - **Columns:** `EmployeeID`
   - **Values:** `Freight` (sum)
4. At the configured interval (default 5000 ms; UI minimum 2000 ms), **all** orders' `Freight` values increase by 1–9 and the Pivot Table refreshes automatically in place via `RefreshAsync(true)`.

### Additional Things to Try at Runtime

- Open the app in two browser tabs to confirm broadcast fan-out to multiple clients simultaneously.
- Use the built-in Field List (`ShowFieldList="true"`) to drag `ShipCity` or other fields between rows, columns, and values at runtime.
- Enter a **Feed Delay (ms)** value (UI minimum 2000 ms), then use **Start Updating...** or **Stop Updating...** to submit it while pausing or resuming updates.

## Troubleshooting Common SignalR + Blazor Pivot Table Issues

The issues below are grouped into two tables: connection and rendering problems, and live update controls / refresh problems.

### Connection and Rendering

| # | Symptom / Error Message | Most Common Cause(s) | Quick Fix / Check |
|---|---|---|---|
| 1 | "Failed to start hub connection" or connection stays disconnected | Wrong hub path, untrusted development certificate, blocked negotiated transport, or initial start failure | Confirm `Navigation.ToAbsoluteUri("/pivothub")` matches the mapped route, trust the development certificate, and inspect ASP.NET Core/SignalR server logs. This sample's .NET client runs on the server, so its transport is not the browser's custom `/pivothub` request. |
| 2 | "The request matched multiple endpoints" (`AmbiguousMatchException`) | The same hub route or another conflicting endpoint was registered more than once | Search endpoint registrations, map `/pivothub` exactly once, and ensure no component or controller uses the same route. |
| 3 | Pivot Table renders empty | `OrderAdaptor.ReadAsync` returning empty, or `SfDataManager.AdaptorInstance` not set | Verify `OrderDataService.GetOrders()` is not empty. Confirm `AdaptorInstance="@typeof(OrderAdaptor)"` and `Adaptor="Adaptors.CustomAdaptor"` are both set. |
| 4 | No real-time updates | Background service not registered | Confirm `builder.Services.AddHostedService<OrderUpdateBackgroundService>();` is present in `Program.cs`. |
| 5 | `NullReferenceException` or renderer-context exception in the handler | Component reference is not initialized or is being disposed; UI work is running outside the renderer context | Guard component/connection state and marshal both refresh and rendering through the component's `InvokeAsync` dispatcher. |
| 6 | Syncfusion licensing warning at startup | License not registered | Uncomment the `SyncfusionLicenseProvider.RegisterLicense(...)` line in `Program.cs` and add your key. |
| 7 | `dotnet restore` fails | .NET 10 SDK missing | Install the .NET 10 SDK and confirm with `dotnet --version` (must list a 10.x SDK). |

### Live Update Controls and Refresh

| # | Symptom / Error Message | Most Common Cause(s) | Quick Fix / Check |
|---|---|---|---|
| 1 | Pivot Table does not refresh on push | `PivotObj` is null when the handler fires, or handler not on renderer thread, or `RefreshAsync` called without `true` | Null-check `PivotObj` before `RefreshAsync(true)` (full engine refresh). Wrap the refresh in `InvokeAsync(async () => { ... })` before `StateHasChanged`. |
| 2 | Aggregations look stale after pivot change | Field List change not re-reading from the adaptor | Call `PivotObj.RefreshAsync(true)` after programmatic field changes; rely on the `ReceiveOrderUpdate` handler for push refreshes. |
| 3 | Updates stop unexpectedly | `UpdateConfiguration.IsRunning` set to `false` by a Stop click or `UpdateSettings(false, ...)` call | Click **Start Updating...** on the page, or invoke `UpdateSettings(true, interval)` on the hub from any client. |
| 4 | Interval change does not take effect | Value below 2000 ms, or `UpdateSettings` RPC not invoked | The `SfNumericTextBox` enforces `Min="2000"`. Confirm the Start/Stop handlers call `hubConnection.SendAsync("UpdateSettings", isRunning, FeedDelay)`. The new interval applies on the next background cycle. |

### Quick Diagnostic Steps

1. Check the application output for ASP.NET Core, SignalR, and Blazor exceptions. Because this Interactive Server sample creates the .NET `HubConnection` on the server, browser DevTools do not expose that connection as a separate browser `/pivothub` request.
2. Confirm the absolute hub URL resolves from the server process and matches the `/pivothub` endpoint.
3. Enable structured logging and verify that `OrderUpdateBackgroundService` starts, mutates data, and completes each broadcast.
4. Confirm the handler runs after `PivotObj` is initialized and marshal component work through the renderer dispatcher.
5. Confirm `OrderAdaptor` is registered (`AddScoped<OrderAdaptor>`), `OrderDataService` is registered (`AddSingleton<OrderDataService>`), and `UpdateConfiguration` is registered (`AddSingleton<UpdateConfiguration>`).

Most real-time issues in Blazor + SignalR Pivot Table setups are solved by:
- A unique, correctly matched hub route in `Program.cs`
- Using `Navigation.ToAbsoluteUri("/pivothub")` for the hub URL
- Marshaling the refresh through `InvokeAsync`
- Trusting the local HTTPS dev certificate

## Complete Sample Repository

A complete, working sample implementation is available in the [GitHub repository](https://github.com/SyncfusionExamples/blazor-pivot-table-integrations/tree/master).

## See also

- [ASP.NET Core SignalR .NET client](https://learn.microsoft.com/en-us/aspnet/core/signalr/dotnet-client?view=aspnetcore-10.0&tabs=visual-studio)
- [Getting Started with Pivot Table in a Blazor Web App](https://blazor.syncfusion.com/documentation/pivot-table/getting-started-webapp)
