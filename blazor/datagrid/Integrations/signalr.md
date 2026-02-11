---
layout: post
title: Blazor Data Grid with Real-time Updates Using SignalR | Syncfusion
description: Bind real-time stock market data to Blazor Data Grid using SignalR hub with complete bidirectional communication, live updates, and in-memory data operations.
platform: Blazor
control: DataGrid
documentation: ug
---

# Connecting Real-Time Data to Blazor Data Grid Using SignalR

The [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) supports real-time data binding using **SignalR**, a powerful library for bi-directional communication between servers and clients. This approach enables live data updates without page refreshes, making it ideal for applications that require instant information delivery such as stock tickers, live dashboards, and real-time notifications.

**What is SignalR?**

SignalR is an open-source .NET library that simplifies adding real-time web functionality to applications. It automatically handles the best transport method (WebSockets, Server-Sent Events, or Long Polling) and provides a high-level API for server-to-client and client-to-server communication. SignalR enables persistent two-way connections between clients and servers, allowing instant data synchronization without polling.

**Key Benefits of SignalR**

- **Real-Time Communication**: Establish persistent connections for instant data updates across all connected clients.
- **Bidirectional**: Support both server-to-client (broadcasting) and client-to-server (commands) communication.
- **Automatic Transport Selection**: Intelligently choose the best transport protocol (WebSockets, SSE, Long Polling) based on browser and server capabilities.
- **Scalable Broadcasting**: Efficiently broadcast updates to multiple clients simultaneously using SignalR groups.
- **Built-in Reconnection**: Automatically handles client reconnection with exponential back off retry logic.
- **No Page Refresh Required**: Update UI dynamically without reloading the page.
- **Cross-Platform**: Works across browsers, mobile devices, and desktop applications.

## Prerequisites

Ensure the following software and packages are installed before proceeding:

| Software/Package | Version | Purpose |
|-----------------|---------|---------|
| Visual Studio 2026 | 18.0 or later | Development IDE with Blazor workload |
| .NET SDK | net9.0 or later | Runtime and build tools |
| Microsoft.AspNetCore.SignalR.Client | 9.0.0 or later | SignalR client library for Blazor |
| Syncfusion.Blazor.Grid | {{site.blazorversion}} | DataGrid component |
| Syncfusion.Blazor.Themes | {{site.blazorversion}} | Styling for DataGrid |

## Setting Up SignalR with Real-Time Data

### Step 1: Install Required NuGet Packages

SignalR packages are essential for implementing real-time communication. The client library runs in the browser, while the server library manages the hub and broadcasts.

**Instructions:**

**Method 1: Using Package Manager Console**

1. Open Visual Studio 2026.
2. Navigate to **Tools → NuGet Package Manager → Package Manager Console**.
3. Run the following commands:

```powershell
Install-Package Microsoft.AspNetCore.SignalR.Client -Version 9.0.0
Install-Package Syncfusion.Blazor.Grid -Version {{site.blazorversion}}
Install-Package Syncfusion.Blazor.Themes -Version {{site.blazorversion}}
```

**Method 2: Using NuGet Package Manager UI**

1. Open **Visual Studio 2026 → Tools → NuGet Package Manager → Manage NuGet Packages for Solution**.
2. Search for and install each package:
   - **Microsoft.AspNetCore.SignalR.Client** (9.0.0 or later)
   - **[Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid/)** (version {{site.blazorversion}})
   - **[Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)** (version {{site.blazorversion}})

All required packages are now installed. The `Microsoft.AspNetCore.SignalR` server library is automatically included with the ASP.NET Core runtime.

### Step 2: Create the Data Model

A data model represents the structure of real-time data that will be transmitted between server and clients. For this guide, use a **Stock** model to represent stock market data.

**Instructions:**

1. Create a new folder named `Models` in the Blazor application project (if it doesn't exist).
2. Inside the `Models` folder, create a new file named **Stock.cs**.
3. Define the **Stock** class with the following code:

```csharp
namespace Grid_SignalR.Models;

/// <summary>
/// Represents a stock record in the real-time stock market data.
/// This model is used for both server-side storage and client-side display.
/// </summary>
public class Stock
{
    /// <summary>
    /// Gets or sets the unique identifier for the stock.
    /// </summary>
    public int StockId { get; set; }

    /// <summary>
    /// Gets or sets the ticker symbol of the stock (e.g., AAPL, MSFT).
    /// </summary>
    public string Symbol { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the full company name.
    /// </summary>
    public string Company { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the current price of the stock.
    /// </summary>
    public decimal CurrentPrice { get; set; }

    /// <summary>
    /// Gets or sets the previous price before the last update.
    /// Used to calculate price changes.
    /// </summary>
    public decimal PreviousPrice { get; set; }

    /// <summary>
    /// Gets or sets the price change in absolute value.
    /// Calculated as CurrentPrice - PreviousPrice.
    /// </summary>
    public decimal Change { get; set; }

    /// <summary>
    /// Gets or sets the percentage change of the stock price.
    /// Calculated as (Change / PreviousPrice) * 100.
    /// </summary>
    public decimal ChangePercent { get; set; }

    /// <summary>
    /// Gets or sets the trading volume (number of shares traded).
    /// </summary>
    public long Volume { get; set; }

    /// <summary>
    /// Gets or sets the timestamp of the last price update.
    /// </summary>
    public DateTime LastUpdated { get; set; }
}
```

**Explanation:**
- The `Stock` class contains properties representing all data points needed for real-time display.
- The `Change` and `ChangePercent` properties are calculated on the server before transmission to avoid computational overhead on clients.
- `LastUpdated` tracks when each stock price was last updated for audit and real-time verification.

The data model has been successfully created.

### Step 3: Create the Data Service

A data service manages in-memory stock data and handles price updates. This service simulates real-time market data and is shared across the application via dependency injection.

**Instructions:**

1. Create a new folder named `Services` in the Blazor application project.
2. Inside the `Services` folder, create a new file named **StockDataService.cs**.
3. Define the **StockDataService** class with the following code:

```csharp
using Grid_SignalR.Models;

namespace Grid_SignalR.Services;

/// <summary>
/// Service that manages stock data in-memory and handles price updates.
/// This service simulates real-time market data with random price fluctuations.
/// </summary>
public class StockDataService
{
    private readonly List<Stock> _stocks = [];
    private readonly Random _random = new();
    
    public StockDataService()
    {
        InitializeStocks();
    }

    /// <summary>
    /// Initializes the stock collection with seed data from major markets.
    /// Includes stocks from Technology, Finance, Healthcare, Energy, and other sectors.
    /// </summary>
    private void InitializeStocks()
    {
        var stockData = new[]
        {
            ("AAPL", "Apple Inc.", 190.50m),
            ("MSFT", "Microsoft Corporation", 380.25m),
            ("GOOGL", "Alphabet Inc.", 140.75m),
            ("AMZN", "Amazon.com Inc.", 180.50m),
            ("NVDA", "NVIDIA Corporation", 870.20m),
            ("META", "Meta Platforms Inc.", 520.15m),
            ("TSLA", "Tesla Inc.", 242.80m),
            ("JPM", "JPMorgan Chase & Co.", 195.75m),
            ("JNJ", "Johnson & Johnson", 158.45m),
            ("XOM", "Exxon Mobil Corporation", 118.40m),
            // ... Additional stocks
        };

        int id = 1;
        foreach (var (symbol, company, price) in stockData)
        {
            _stocks.Add(new Stock
            {
                StockId = id++,
                Symbol = symbol,
                Company = company,
                CurrentPrice = price,
                PreviousPrice = price,
                Change = 0,
                ChangePercent = 0,
                Volume = _random.Next(1000000, 100000000),
                LastUpdated = DateTime.Now
            });
        }
    }

    /// <summary>
    /// Retrieves all stocks from memory, sorted by symbol.
    /// </summary>
    /// <returns>A list of all stocks sorted alphabetically by symbol.</returns>
    public List<Stock> GetAllStocks()
    {
        return _stocks.OrderBy(s => s.Symbol).ToList();
    }

    /// <summary>
    /// Updates all stock prices with simulated market fluctuations.
    /// This method simulates real-time market changes.
    /// </summary>
    public void UpdateStockPrices()
    {
        var now = DateTime.Now;
        
        foreach (var stock in _stocks)
        {
            stock.PreviousPrice = stock.CurrentPrice;
            
            decimal changePercent = (decimal)(_random.NextDouble() - 0.5) * 0.04m;
            decimal newPrice = stock.CurrentPrice * (1 + changePercent);

            stock.CurrentPrice = decimal.Round(newPrice, 2);
            stock.Change = decimal.Round(stock.CurrentPrice - stock.PreviousPrice, 2);
            stock.ChangePercent = decimal.Round((stock.Change / stock.PreviousPrice) * 100, 2);
            stock.Volume = _random.Next(1000000, 100000000);
            stock.LastUpdated = now;
        }
    }
}
```

**Explanation:**
- `InitializeStocks()`: Populates the in-memory collection with diversified stock data from multiple sectors.
- `GetAllStocks()`: Returns all stocks sorted by symbol for consistent ordering in the DataGrid.
- `UpdateStockPrices()`: Simulates real-time market changes with random price fluctuations between -2% and +2%.

The data service is now ready to provide real-time stock data.

### Step 4: Create the SignalR Hub

A SignalR Hub is the server-side component that manages client connections and broadcasts data to connected clients. It acts as a communication bridge between the server and all connected clients.

**Instructions:**

1. Create a new folder named `Hubs` in the Blazor application project.
2. Inside the `Hubs` folder, create a new file named **StockHub.cs**.
3. Define the **StockHub** class with the following code:

```csharp
using Grid_SignalR.Models;
using Grid_SignalR.Services;
using Microsoft.AspNetCore.SignalR;

namespace Grid_SignalR.Hubs;

/// <summary>
/// SignalR Hub for real-time stock market updates.
/// Manages client connections, subscriptions, and broadcasts stock data to connected clients.
/// </summary>
public class StockHub : Hub
{
    private readonly StockDataService _stockDataService;

    public StockHub(StockDataService stockDataService)
    {
        _stockDataService = stockDataService;
    }

    /// <summary>
    /// Called when a client connects to the hub.
    /// Sends initial stock data to the connecting client immediately.
    /// </summary>
    public override async Task OnConnectedAsync()
    {
        await base.OnConnectedAsync();
        var stocks = _stockDataService.GetAllStocks();
        await Clients.Client(Context.ConnectionId).SendAsync("InitializeStocks", stocks);
    }

    /// <summary>
    /// Called by the client to subscribe to real-time stock updates.
    /// Adds the client connection to the "StockTraders" group for efficient broadcasting.
    /// </summary>
    public async Task SubscribeToStocks()
    {
        // Add this client to the "StockTraders" group
        await Groups.AddToGroupAsync(Context.ConnectionId, "StockTraders");
        
        // Send current stock data to the subscribing client
        var stocks = _stockDataService.GetAllStocks();
        await Clients.Caller.SendAsync("InitializeStocks", stocks);
    }

    /// <summary>
    /// Called by the client to unsubscribe from real-time stock updates.
    /// Removes the client connection from the "StockTraders" group.
    /// </summary>
    public async Task UnsubscribeFromStocks()
    {
        await Groups.RemoveFromGroupAsync(Context.ConnectionId, "StockTraders");
    }
}
```

**Explanation:**
- `OnConnectedAsync()`: Automatically invoked when a client connects. Sends initial stock data immediately.
- `SubscribeToStocks()`: Adds the client to the "StockTraders" group for receiving broadcast updates. This method is called from the Blazor component during initialization.
- `UnsubscribeFromStocks()`: Removes the client from the group when they disconnect or unsubscribe. This prevents unnecessary network traffic.
- `Clients.Caller`: Sends data only to the calling client.
- `Clients.Group("StockTraders")`: Sends data to all clients in the "StockTraders" group (broadcast).

**How SignalR Methods are Called:**

The hub methods are invoked from the Blazor component using the HubConnection object. When the component calls `await hubConnection.SendAsync("SubscribeToStocks")`, the `SubscribeToStocks()` method on the hub is executed server-side.

The hub is now ready to manage real-time connections.

### Step 5: Create the Background Service

A background service continuously runs in the background and periodically updates stock prices, then broadcasts them to all connected clients via SignalR. This service simulates real-time market updates.

**Instructions:**

1. Inside the `Services` folder, create a new file named **StockUpdateBackgroundService.cs**.
2. Define the **StockUpdateBackgroundService** class with the following code:

```csharp
using Grid_SignalR.Hubs;
using Microsoft.AspNetCore.SignalR;

namespace Grid_SignalR.Services;

/// <summary>
/// Background service that periodically updates stock prices and broadcasts them to clients.
/// This service runs continuously in the background and simulates real-time market updates.
/// </summary>
public class StockUpdateBackgroundService : BackgroundService
{
    private readonly IServiceProvider _serviceProvider;
    private readonly ILogger<StockUpdateBackgroundService> _logger;
    
    /// <summary>
    /// Update interval in milliseconds. Updates are sent every 1 second.
    /// </summary>
    private const int UpdateIntervalMs = 1000;

    public StockUpdateBackgroundService(IServiceProvider serviceProvider, ILogger<StockUpdateBackgroundService> logger)
    {
        _serviceProvider = serviceProvider ?? throw new ArgumentNullException(nameof(serviceProvider));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    /// <summary>
    /// Main execution method that runs indefinitely until the application stops.
    /// Periodically updates stock prices and broadcasts them to all connected clients.
    /// </summary>
    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        _logger.LogInformation("Stock Update Background Service started");

        while (!stoppingToken.IsCancellationRequested)
        {
            try
            {
                // Wait for the update interval before processing the next update
                await Task.Delay(UpdateIntervalMs, stoppingToken);

                // Create a new scope to get fresh instances of scoped services
                using (var scope = _serviceProvider.CreateScope())
                {
                    // Retrieve services from the dependency injection container
                    var stockDataService = scope.ServiceProvider.GetRequiredService<StockDataService>();
                    var hubContext = scope.ServiceProvider.GetRequiredService<IHubContext<StockHub>>();

                    // Update stock prices on the server
                    stockDataService.UpdateStockPrices();
                    
                    // Get the updated stocks list
                    var stocks = stockDataService.GetAllStocks();

                    // Broadcast updated stocks to all clients in the "StockTraders" group
                    await hubContext.Clients.Group("StockTraders").SendAsync(
                        "ReceiveStockUpdate", 
                        stocks, 
                        cancellationToken: stoppingToken
                    );
                }
            }
            catch (OperationCanceledException)
            {
                // Expected when the service is stopping
                break;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error updating stocks");
                // Continue the loop to attempt the next update
            }
        }

        _logger.LogInformation("Stock Update Background Service stopped");
    }
}
```

**Explanation:**
- **Lifetime**: Implements `BackgroundService`, which runs continuously until the application stops.
- **Update Interval**: Updates stock prices every 1 second (1000ms).
- **Scope Management**: Creates a new dependency injection scope for each update to ensure thread-safe access to services.
- **Broadcasting**: Uses `IHubContext<StockHub>` to send updates to all clients in the "StockTraders" group.
- **Error Handling**: Logs errors but continues the update loop to ensure resilience.

The background service ensures real-time updates are delivered continuously to all connected clients.

### Step 6: Register Services in Program.cs

The `Program.cs` file is where application services are registered and configured for dependency injection. This file must be updated to enable SignalR and register all required services.

**Instructions:**

1. Open the `Program.cs` file at the project root.
2. Update the service registration code to include SignalR and background services:

```csharp
using Grid_SignalR.Components;
using Grid_SignalR.Services;
using Grid_SignalR.Hubs;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
    
// Register Syncfusion Blazor components
builder.Services.AddSyncfusionBlazor();

// Register custom services
// StockDataService: Manages in-memory stock data (Singleton for shared state)
builder.Services.AddSingleton<StockDataService>();

// StockAdaptor: Custom adaptor for DataGrid operations (Scoped per request)
builder.Services.AddScoped<StockAdaptor>();

// Add SignalR for real-time communication
builder.Services.AddSignalR(options =>
{
    options.MaximumReceiveMessageSize = 32 * 1024;      // 32 KB – adjust if sending large stock lists
    options.EnableDetailedErrors = builder.Environment.IsDevelopment();
});

// Register the background service that continuously updates stock prices
builder.Services.AddHostedService<StockUpdateBackgroundService>();

var app = builder.Build();

// Configure the HTTP request pipeline
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
    app.UseHttpsRedirection();
}

app.UseAntiforgery();

app.MapStaticAssets();

// Map Razor components for interactive server-side rendering
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Map the SignalR Hub to the "/stockhub" endpoint
app.MapHub<StockHub>("/stockhub");

app.Run();
```

**Explanation:**
- **`AddSingleton<StockDataService>`**: Registers as a singleton so the same instance is shared across all requests and the background service.
- **`AddScoped<StockAdaptor>`**: Registers as scoped so each request gets its own adaptor instance.
- **`AddSignalR()`**: Enables SignalR functionality with default configuration.
- **`AddHostedService<StockUpdateBackgroundService>`**: Registers the background service to run continuously.
- **`MapHub<StockHub>("/stockhub")`**: Maps the hub to the WebSocket endpoint at "/stockhub".

Service registration is now complete.

---

## Integrating Syncfusion Blazor DataGrid

### Step 1: Install and Configure Blazor DataGrid Components

Syncfusion is a library that provides pre-built UI components like DataGrid, which is used to display data in a table format.

**Instructions:**

1. The Syncfusion.Blazor package was installed in **Step 1** of the previous heading.
2. Import the required namespaces in the `Components/_Imports.razor` file:

```csharp
@using Grid_SignalR.Models
@using Grid_SignalR.Services
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
```

3. Add the Syncfusion stylesheet and scripts in the `Components/App.razor` file. Find the `<head>` section and add:

```html
<!-- Syncfusion Blazor Stylesheet -->
<link href="_content/Syncfusion.Blazor.Themes/tailwind3.css" rel="stylesheet" />

<!-- Syncfusion Blazor Scripts -->
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
```

For this project, the tailwind3 theme is used. A different theme can be selected or the existing theme can be customized based on project requirements. Refer to the [Syncfusion Blazor Components Appearance](https://blazor.syncfusion.com/documentation/appearance/themes) documentation to learn more about theming and customization options.

Syncfusion components are now configured and ready to use. For additional guidance, refer to the Grid component's [getting‑started](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app) documentation.

### Step 2: Update the Blazor DataGrid

The `Home.razor` component displays the stock market data in a Syncfusion DataGrid and establishes a SignalR connection for real-time updates.

**Instructions:**

1. Open the file named `Home.razor` in the `Components/Pages` folder.
2. Add the following complete code for the component:

```cshtml
@page "/"
@using Microsoft.AspNetCore.SignalR.Client
@using Microsoft.AspNetCore.Http.Connections
@rendermode InteractiveServer
@implements IAsyncDisposable

<PageTitle>Stock Market - Real-time Updates</PageTitle>

<div class="container-fluid mt-4">
    <div class="card shadow-lg">
        <div class="card-body">

            <!-- Syncfusion DataGrid -->
            <SfGrid @ref="grid" TValue="Stock" Height="500" AllowSorting="true" AllowFiltering="true" Toolbar=@ToolbarItems>
                <SfDataManager AdaptorInstance="@typeof(StockAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
                <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Menu"></GridFilterSettings>

                <GridColumns>
                   //columns configuration
                </GridColumns>
            </SfGrid>
            
        </div>
    </div>
</div>

@code {
    //Hub Connection has been initialized in next steps
}
```

**Component Explanation:**

- **`@rendermode InteractiveServer`**: Enables interactive server-side rendering for the component.
- **`@implements IAsyncDisposable`**: Implements the async disposal pattern to clean up resources.
- **`HubConnection`**: Manages the SignalR connection to the server.
- **Connection Status Indicator**: Displays the current connection state (Connected, Connecting, Disconnected).
- **DataGrid Integration**: Uses the `StockAdaptor` to retrieve and display data.
- **Real-Time Updates**: Receives "ReceiveStockUpdate" messages from the server and refreshes the grid.
- **Automatic Reconnection**: Implements exponential back off retry logic for network resilience.

### Step 3: Create the CustomAdaptor for SignalR

The CustomAdaptor bridges the Syncfusion DataGrid with SignalR by implementing the DataAdaptor interface. It handles data retrieval, searching, filtering, and sorting operations required by the DataGrid.

**Instructions:**

1. Inside the `Services` folder, create a new file named **StockAdaptor.cs**.
2. Define the **StockAdaptor** class with the following code:

```csharp
using System.Collections;
using Grid_SignalR.Models;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;

namespace Grid_SignalR.Services;

/// <summary>
/// Custom adaptor for Syncfusion DataGrid that handles data operations for real-time stock data.
/// Implements reading, searching, filtering, and sorting operations.
/// </summary>
public class StockAdaptor : DataAdaptor
{
    private readonly StockDataService _stockDataService;

    public StockAdaptor(StockDataService stockDataService)
    {
        _stockDataService = stockDataService ?? throw new ArgumentNullException(nameof(stockDataService));
    }

    /// <summary>
    /// Handles data retrieval and processing for the DataGrid.
    /// This method applies search, filter, sort, and paging operations.
    /// </summary>
    /// <param name="dataManagerRequest">Contains information about requested operations (search, filter, sort, page).</param>
    /// <param name="key">Optional key for specific operations.</param>
    /// <returns>Processed data with total count for pagination.</returns>
    public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
    {
        ArgumentNullException.ThrowIfNull(dataManagerRequest);

        // Retrieve all stocks from the service
        IEnumerable stocks = _stockDataService.GetAllStocks();

        // Apply search operation if search criteria exists
        if (dataManagerRequest.Search?.Count > 0)
        {
            stocks = DataOperations.PerformSearching(stocks, dataManagerRequest.Search);
        }

        // Apply filter operation if filter criteria exists
        if (dataManagerRequest.Where?.Count > 0)
        {
            stocks = DataOperations.PerformFiltering(stocks, dataManagerRequest.Where, dataManagerRequest.Where[0].Operator);
        }

        // Apply sort operation if sort criteria exists
        if (dataManagerRequest.Sorted?.Count > 0)
        {
            stocks = DataOperations.PerformSorting(stocks, dataManagerRequest.Sorted);
        }

        // Calculate total record count before paging for accurate pagination metadata
        int totalRecordsCount = stocks.Cast<Stock>().Count();

        // Apply paging skip operation (skip X records)
        if (dataManagerRequest.Skip != 0)
        {
            stocks = DataOperations.PerformSkip(stocks, dataManagerRequest.Skip);
        }

        // Apply paging take operation (retrieve next X records)
        if (dataManagerRequest.Take != 0)
        {
            stocks = DataOperations.PerformTake(stocks, dataManagerRequest.Take);
        }

        // Return DataResult with total count for pagination metadata
        return dataManagerRequest.RequiresCounts 
            ? new DataResult() { Result = stocks, Count = totalRecordsCount } 
            : (object)stocks;
    }
}
```

**Explanation:**
- **ReadAsync**: Core method called by the DataGrid to retrieve and process data.
- **Data Operations**: Uses `DataOperations` static methods to apply transformations:
  - `PerformSearching`: Filters data based on search keywords across all searchable columns.
  - `PerformFiltering`: Applies column-based filter conditions.
  - `PerformSorting`: Sorts data by specified columns and directions.
  - `PerformSkip/Take`: Handles pagination by skipping and taking records.

The adaptor is now ready to provide data operations for the DataGrid.

### Step 4: Establish SignalR Connection

The `OnInitializedAsync()` method is a Blazor lifecycle method that executes when the component is initialized. This is where the SignalR connection is established and configured. Here's a detailed breakdown of each step:

**Step 1: Build the Hub URL**

```csharp
@code {

[Inject] private NavigationManager NavigationManager { get; set; } = default!;

    protected override async Task OnInitializedAsync()
    {
        var hubUri = NavigationManager.ToAbsoluteUri("/stockhub");
    }
}
```

**Explanation:**
- `NavigationManager.BaseUri` retrieves the application's base URL (e.g., `https://localhost:7018/`).
- The URL is converted to HTTP protocol (SignalR requires HTTP/WebSocket protocol).
- The trailing slash is removed and `/stockhub` is appended to form the complete hub endpoint URL.
- **Result**: The hub URL becomes `http://localhost:7018/stockhub`, which matches the mapping configured in `Program.cs` (`app.MapHub<StockHub>("/stockhub")`).

The hub URL must match exactly with the server-side hub mapping. Any mismatch will cause connection failures.

**Step 2: Create and Configure the HubConnection**

```csharp
@code {
    private HubConnection? hubConnection;

    protected override async Task OnInitializedAsync()
    {
        var hubUri = NavigationManager.ToAbsoluteUri("/stockhub");

        hubConnection = new HubConnectionBuilder()
        .WithUrl(hubUri, options =>
        {
            options.Transports = HttpTransportType.WebSockets;
        })
        .WithAutomaticReconnect(new[]
        {
            TimeSpan.FromSeconds(0),
            TimeSpan.FromSeconds(2),
            TimeSpan.FromSeconds(10),
            TimeSpan.FromSeconds(30),
        })
        .Build();
    }
}
```

**Explanation:**
- **`HubConnectionBuilder()`**: Creates a builder object to configure the connection.
- **`.WithUrl(hubUrl, options)`**: Specifies the server hub endpoint and transport configuration.
  - **`HttpTransportType.WebSockets`**: Primary transport using WebSocket protocol (full-duplex, low latency, most efficient).
  - **`HttpTransportType.LongPolling`**: Fallback transport for browsers/environments that don't support WebSockets. SignalR automatically falls back if WebSocket fails.
- **`.WithAutomaticReconnect()`**: Configures automatic reconnection with exponential back off intervals:
- **`.Build()`**: Finalizes the configuration and creates the HubConnection instance.

**Why this matters**: 
- WebSocket provides real-time, full-duplex communication with minimal overhead.
- Automatic reconnection ensures the application continues working even during brief network interruptions.

**Step 3: Register Message Handlers**

```csharp
code {
    private HubConnection? hubConnection;

    protected override async Task OnInitializedAsync()
    {
        var hubUri = NavigationManager.ToAbsoluteUri("/stockhub");

        hubConnection = new HubConnectionBuilder()
        .WithUrl(hubUri, options =>
        {
            options.Transports = HttpTransportType.WebSockets;
        })
        .WithAutomaticReconnect(new[]
        {
            TimeSpan.Zero, 
            TimeSpan.FromSeconds(2),
            TimeSpan.FromSeconds(5),
            TimeSpan.FromSeconds(10),
            TimeSpan.FromSeconds(30)
        })
        .Build();

        hubConnection.On<List<Stock>>("ReceiveStockUpdate", async (_) => await RefreshGrid());
        hubConnection.On<List<Stock>>("InitializeStocks", async (_) => await RefreshGrid());
            }
}
```

**Explanation:**
- **`hubConnection.On<List<Stock>>()`**: Registers a handler for a specific message type from the server.
- **`"ReceiveStockUpdate"`**: The server sends this message periodically (every 1 second from `StockUpdateBackgroundService`) to broadcast updated stock data to all connected clients.
  - When received, `RefreshGrid()` is called to update the DataGrid with the latest prices.
- **`"InitializeStocks"`**: The server sends this message when a client first connects (from `OnConnectedAsync()` in `StockHub`) and when a client subscribes (from `SubscribeToStocks()` in `StockHub`).
  - When received, the DataGrid is initialized with the current stock data.

**Why two handlers?**
- `InitializeStocks`: Used for initial data load and manual refresh operations.
- `ReceiveStockUpdate`: Used for continuous, real-time updates broadcast from the background service.

**Message Flow Example:**
```
Timeline:
t=0ms:   Client connects → Server calls OnConnectedAsync() → Sends "InitializeStocks" message
t=10ms:  Client receives "InitializeStocks" → Calls RefreshGrid() → Grid displays initial data
t=1000ms: Background service updates prices → Sends "ReceiveStockUpdate" to all clients
t=1005ms: Client receives "ReceiveStockUpdate" → Calls RefreshGrid() → Grid displays updated prices
t=2000ms: Background service updates prices again → Sends "ReceiveStockUpdate" to all clients
... (repeats every second)
```

**Step 4: Register Connection Event Handlers**

```csharp
code {
    private HubConnection? hubConnection;

    protected override async Task OnInitializedAsync()
    {
        var hubUri = NavigationManager.ToAbsoluteUri("/stockhub");

        hubConnection = new HubConnectionBuilder()
        .WithUrl(hubUri, options =>
        {
            options.Transports = HttpTransportType.WebSockets;
        })
        .WithAutomaticReconnect(new[]
        {
            TimeSpan.Zero, 
            TimeSpan.FromSeconds(2),
            TimeSpan.FromSeconds(5),
            TimeSpan.FromSeconds(10),
            TimeSpan.FromSeconds(30)
        })
        .Build();

        hubConnection.On<List<Stock>>("ReceiveStockUpdate", async (_) => await RefreshGrid());
        hubConnection.On<List<Stock>>("InitializeStocks", async (_) => await RefreshGrid());
        hubConnection.Reconnected += async (_) =>
        {
            await hubConnection.SendAsync("SubscribeToStocks");
        };
        hubConnection.Closed += async (error) =>
        {
            if (error != null)
            {
                Console.Error.WriteLine($"Hub connection closed with error: {error.Message}");
            }
            
            // Wait before attempting to reconnect with random backoff
            await Task.Delay(ReconnectRandom.Next(0, 5000));
            try
            {
                await hubConnection.StartAsync();
            }
            catch
            {
                // Connection failed, will retry on next interval
            }
        };

        try
        {
            await hubConnection.StartAsync();
            await hubConnection.SendAsync("SubscribeToStocks");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"SignalR start failed: {ex.Message}");
        }
}
```

**Explanation:**

**`Reconnected` Event:**
- Fires when the client successfully reconnects to the server after a disconnection.
- Calls `SubscribeToStocks()` to rejoin the "StockTraders" group and resume receiving broadcasts.
- Logs "Hub reconnected" for debugging purposes.

**Why this matters**: After reconnection, the client needs to resubscribe to the broadcast group to resume receiving updates. Without this, the client would receive "InitializeStocks" but not "ReceiveStockUpdate" messages.

**`Closed` Event:**
- Fires when the connection is closed (either by the server or due to network issues).
- If an error occurred, it logs the error message.
- Adds a random delay (0-5000ms) before attempting manual reconnection to prevent overwhelming the server with simultaneous reconnection attempts from multiple clients.
- Attempts to restart the connection via `hubConnection.StartAsync()`.

**Reconnection Workflow:**
```
Connection Lost
    ↓
Closed event fires
    ↓
Random delay (0-5000ms) 
    ↓
Manual reconnection attempt via StartAsync()
    ↓
Success → Reconnected event fires → Subscribe to updates
    ↓
Failure → Waits for next automatic retry (configured in WithAutomaticReconnect)
```

**Why random delay?** If 100 clients lose connection simultaneously, without a random delay, all 100 would attempt to reconnect at exactly the same time, potentially overwhelming the server. Random delays stagger the reconnection attempts across time, distributing the load evenly.

**Start the Connection and Subscribe**
- **`hubConnection.StartAsync()`**: Establishes the actual connection to the server.
  - Attempts to use WebSocket first.
  - If WebSocket fails, falls back to Long Polling.
  - If both fail, throws an exception.
- **`hubConnection.SendAsync("SubscribeToStocks")`**: Sends a message to the server invoking the `SubscribeToStocks()` method on `StockHub`.
  - Server adds this client to the "StockTraders" group.
  - Server sends current stock data via `InitializeStocks` message.
- **Exception Handling**: Catches connection failures and logs them. The application continues running even if the initial connection fails; automatic reconnection will retry periodically.

**Connection Establishment Timeline:**
```
t=0ms:   StartAsync() called
t=50ms:  WebSocket connection established
t=60ms:  SendAsync("SubscribeToStocks") called
t=70ms:  Server's SubscribeToStocks() executes
t=75ms:  Client added to "StockTraders" group
t=80ms:  Server sends "InitializeStocks" message
t=90ms:  Client's "InitializeStocks" handler receives data
t=95ms:  RefreshGrid() called
t=100ms: Grid displays initial stock data
t=1000ms: Background service sends first "ReceiveStockUpdate"
```

**Step 5: Thread Safety**
The `InvokeAsync()` call in `RefreshGrid()` ensures that UI updates are marshaled to the main Blazor rendering thread:
```csharp
code {
    private async Task RefreshGrid()
    {
        if (grid != null)
        {
            await InvokeAsync(StateHasChanged);
        }
    }
}
```

### Step 5: Complete SignalR Lifecycle

Here's the complete lifecycle of SignalR communication from component initialization to real-time updates:

```
┌─────────────────────────────────────────────────────────────────────┐
│ 1. INITIALIZATION (OnInitializedAsync)                              │
├─────────────────────────────────────────────────────────────────────┤
│   - Build hub URL                                                   │
│   - Create HubConnection with WebSocket/LongPolling transports      │
│   - Register message handlers (ReceiveStockUpdate, InitializeStocks)│
│   - Register connection event handlers (Reconnected, Closed)        │
│   - Call StartAsync() to establish connection                       │
│   - Send SubscribeToStocks() to join "StockTraders" group           │
└─────────────────────────────────────────────────────────────────────┘
                                   ↓
┌─────────────────────────────────────────────────────────────────────┐
│ 2. SERVER RESPONSE                                                  │
├─────────────────────────────────────────────────────────────────────┤
│   - Server receives SubscribeToStocks() call                        │
│   - Server adds client to "StockTraders" group                      │
│   - Server sends InitializeStocks message with current stock data   │
└─────────────────────────────────────────────────────────────────────┘
                                   ↓
┌─────────────────────────────────────────────────────────────────────┐
│ 3. CLIENT INITIALIZATION                                            │
├─────────────────────────────────────────────────────────────────────┤
│   - Client receives InitializeStocks message                        │
│   - Handler calls RefreshGrid()                                     │
│   - Grid displays initial stock data                                │
└─────────────────────────────────────────────────────────────────────┘
                                   ↓
┌─────────────────────────────────────────────────────────────────────┐
│ 4. CONTINUOUS REAL-TIME UPDATES (Every 1 Second)                    │
├─────────────────────────────────────────────────────────────────────┤
│   - Background service updates stock prices                         │
│   - Service sends ReceiveStockUpdate to "StockTraders" group        │
│   - All connected clients receive ReceiveStockUpdate message        │
│   - Each client's handler calls RefreshGrid()                       │
│   - Grid refreshes with latest prices                               │
│   - Visual indicators (green/red) show price changes                │
└─────────────────────────────────────────────────────────────────────┘
                                   ↓
┌─────────────────────────────────────────────────────────────────────┐
│ 5. NETWORK INTERRUPTION HANDLING                                    │
├─────────────────────────────────────────────────────────────────────┤
│   - Network connection drops                                        │
│   - Closed event fires                                              │
│   - Random delay applied (0-5000ms)                                 │
│   - Manual reconnection attempt via StartAsync()                    │
│   - If successful: Reconnected event fires                          │
│   - Client automatically resubscribes to "StockTraders" group       │
│   - Updates resume normally                                         │
│   - If failed: Waits for automatic retry (0s, 2s, 10s, 30s)         │
└─────────────────────────────────────────────────────────────────────┘
                                   ↓
┌─────────────────────────────────────────────────────────────────────┐
│ 6. CLEANUP (DisposeAsync)                                           │
├─────────────────────────────────────────────────────────────────────┤
│   - Component disposed (navigation or page close)                   │
│   - hubConnection.DisposeAsync() called                             │
│   - Connection closed gracefully                                    │
│   - Server removes client from "StockTraders" group                 │
│   - Resources freed                                                 │
└─────────────────────────────────────────────────────────────────────┘
```

**Message Serialization:**
SignalR automatically serialize and deserialize messages. When calling:
```csharp
hubConnection.On<List<Stock>>("ReceiveStockUpdate", async (stocks) => { ... })
```
SignalR automatically converts the JSON message from the server into a `List<Stock>` object, making it easy to work with strongly-typed data.

**Transport Protocol Selection:**
The order in `WithUrl()` determines fallback behavior:
1. SignalR attempts WebSocket (most efficient)
2. If WebSocket fails, tries Server-Sent Events (SSE)
3. If SSE fails, uses Long Polling (least efficient but works everywhere)

This automatic fallback ensures compatibility with all browsers and network environments.

### Step 6: Add Styling for Real-Time Visual Feedback

Add CSS to visualize price changes with color coding and icons.

**Instructions:**

1. Open or create the `Components/Pages/Home.razor.css` file.
2. Add the following styles:

```css
/* Price cell styling */
.price-cell {
    font-weight: 600;
    font-size: 1.1em;
}

/* Positive change styling (green) */
.change-cell-positive,
.change-percent-positive {
    color: #28a745;
    font-weight: 600;
}

/* Negative change styling (red) */
.change-cell-negative,
.change-percent-negative {
    color: #dc3545;
    font-weight: 600;
}

/* Connection status styling */
.badge {
    padding: 0.5em 0.75em;
    font-size: 0.9em;
}

/* DataGrid container styling */
.card {
    border-radius: 8px;
    border: 1px solid #e3e6f0;
}

.card-body {
    padding: 1.5rem;
}

/* Title styling */
h1 {
    color: #2c3e50;
    font-weight: 700;
}

.badge-success {
    background-color: #28a745;
}
```

Styling is now applied for enhanced visual feedback.

---

## How SignalR Real-Time Updates Work

### Data Flow Architecture

```
┌─────────────────────────────────────────────────────────────┐
│                    Server (Program.cs)                      │
├─────────────────────────────────────────────────────────────┤
│  1. StockUpdateBackgroundService runs every 1 second        │
│  2. Calls StockDataService.UpdateStockPrices()              │
│  3. Broadcasts to all clients via IHubContext               │
└─────────────────────────────────────────────────────────────┘
                           ▼ WebSocket
┌─────────────────────────────────────────────────────────────┐
│                 Client (Blazor Component)                   │
├─────────────────────────────────────────────────────────────┤
│  1. Receives "ReceiveStockUpdate" message                   │
│  2. Calls RefreshGrid()                                     │
│  3. Grid refreshes via StockAdaptor.ReadAsync()             │
│  4. New data displayed with updated prices                  │
└─────────────────────────────────────────────────────────────┘
```

### Bidirectional Communication Flow

**Server-to-Client (Broadcasting):**
1. Background service updates stock prices every 1 second
2. Calls `hubContext.Clients.Group("StockTraders").SendAsync("ReceiveStockUpdate", stocks)`
3. All connected clients receive the update message
4. DataGrid automatically refreshes with new data

**Client-to-Server (Subscription):**
1. Client establishes connection: `await hubConnection.StartAsync()`
2. Client subscribes: `await hubConnection.SendAsync("SubscribeToStocks")`
3. Server adds client to "StockTraders" group
4. Server sends initial data: `await Clients.Caller.SendAsync("InitializeStocks", stocks)`

### Handling Reconnection and Network Issues

The component implements automatic reconnection with exponential backoff:

```
Connection Lost
    ↓
Wait 0 seconds → Reconnect (Attempt 1)
    ↓ (if failed)
Wait 2 seconds → Reconnect (Attempt 2)
    ↓ (if failed)
Wait 10 seconds → Reconnect (Attempt 3)
    ↓ (if failed)
Wait 30 seconds → Reconnect (Attempt 4)
```

This strategy prevents overwhelming the server during network issues.

---

## Complete Code
```cshtml
@page "/"
@using Microsoft.AspNetCore.SignalR.Client
@using Microsoft.AspNetCore.Http.Connections
@rendermode InteractiveServer
@implements IAsyncDisposable

<PageTitle>Stock Market - Real-time Updates</PageTitle>

<div class="container-fluid mt-4">
    <h1 class="mb-4">
        <span class="badge bg-success">📈 Live Stock Market</span>
    </h1>

    <div class="card shadow-lg">
        <div class="card-body">

            <!-- Syncfusion DataGrid -->
            <SfGrid @ref="grid" TValue="Stock" Height="500" AllowSorting="true" AllowFiltering="true" Toolbar=@ToolbarItems>
                <SfDataManager AdaptorInstance="@typeof(StockAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
                <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Menu"></GridFilterSettings>

                <GridColumns>
                    <GridColumn Field=@nameof(Stock.StockId) HeaderText="ID" IsPrimaryKey="true" Width="60"></GridColumn>
                    
                    <GridColumn Field=@nameof(Stock.Symbol) HeaderText="Symbol" Width="80" AllowSorting="true" AllowFiltering="true"></GridColumn>
                    
                    <GridColumn Field=@nameof(Stock.Company) HeaderText="Company" Width="200" AllowSorting="true" AllowFiltering="true"></GridColumn>

                    <GridColumn Field=@nameof(Stock.CurrentPrice) HeaderText="Current Price" Width="120" Format="N2" AllowSorting="true">
                        <Template>
                            @{
                                var stock = context as Stock;
                                <span class="price-cell">
                                    $@stock?.CurrentPrice.ToString("N2")
                                </span>
                            }
                        </Template>
                    </GridColumn>

                    <GridColumn Field=@nameof(Stock.Change) HeaderText="Change" Width="100" Format="N2" AllowSorting="true">
                        <Template>
                            @{
                                var stock = context as Stock;
                                var isPositive = stock?.Change >= 0;
                                var cssClass = isPositive ? "change-cell-positive" : "change-cell-negative";
                                var symbol = isPositive ? "▲" : "▼";
                                <span class="@cssClass">
                                    @symbol $@stock?.Change.ToString("N2")
                                </span>
                            }
                        </Template>
                    </GridColumn>

                    <GridColumn Field=@nameof(Stock.ChangePercent) HeaderText="Change %" Width="100" Format="N2" AllowSorting="true">
                        <Template>
                            @{
                                var stock = context as Stock;
                                var isPositive = stock?.ChangePercent >= 0;
                                var cssClass = isPositive ? "change-percent-positive" : "change-percent-negative";
                                var symbol = isPositive ? "+" : "";
                                <span class="@cssClass">
                                    @symbol@stock?.ChangePercent%
                                </span>
                            }
                        </Template>
                    </GridColumn>

                    <GridColumn Field=@nameof(Stock.Volume) HeaderText="Volume" Width="120" Format="N0" AllowSorting="true"></GridColumn>

                    <GridColumn Field=@nameof(Stock.LastUpdated) HeaderText="Last Updated" Width="150"
                                Format="yyyy-MM-dd HH:mm:ss" AllowSorting="true"></GridColumn>
                </GridColumns>
            </SfGrid>
        </div>
    </div>
</div>
```
> * Set [IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsPrimaryKey) to **true** for a column that contains unique values.
> * [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Type) property of the `GridColumn` component  specifies the data type of a grid column.
> * The [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html?_gl=1*8q6kap*_gcl_au*ODcxNTU4MzMyLjE3Njc1ODkwOTk.*_ga*NjA2MTg0NzMuMTc1OTc1MDUyNg..*_ga_41J4HFMX1J*czE3Njk1MzE3NTAkbzY1JGcxJHQxNzY5NTMzMDg0JGozMCRsMCRoMA..#Syncfusion_Blazor_Grids_GridColumn_Template) property that allows rendering custom elements in a column instead of the default field value. [🔗](https://blazor.syncfusion.com/documentation/datagrid/column-template)

```csharp
@code {
    private SfGrid<Stock>? grid;
    private HubConnection? hubConnection;
    private static readonly Random ReconnectRandom = new();
    private static readonly List<string> ToolbarItems = new() { "Search" };

    [Inject]
    private NavigationManager NavigationManager { get; set; } = default!;

    /// <summary>
    /// Initializes the component by establishing the SignalR connection.
    /// Called when the component is initialized.
    /// </summary>
    protected override async Task OnInitializedAsync()
    {
        // Construct the SignalR hub URL from the base URI
        var baseUri = NavigationManager.BaseUri;
        var hubUrl = baseUri.Replace("https://", "http://").TrimEnd('/') + "/stockhub";

        // Create a new HubConnection for real-time communication
        hubConnection = new HubConnectionBuilder()
            .WithUrl(hubUrl, options =>
            {
                // Configure transport methods in order of preference
                options.Transports = HttpTransportType.WebSockets | HttpTransportType.LongPolling;
            })
            .WithAutomaticReconnect(new[]
            {
                TimeSpan.FromSeconds(0),
                TimeSpan.FromSeconds(2),
                TimeSpan.FromSeconds(10),
                TimeSpan.FromSeconds(30),
            })
            .Build();

        // Register the handler for receiving stock updates from the server
        hubConnection.On<List<Stock>>("ReceiveStockUpdate", async (stocks) =>
        {
            await RefreshGrid();
        });

        // Register the handler for receiving initial stock data when connecting
        hubConnection.On<List<Stock>>("InitializeStocks", async (stocks) =>
        {
            await RefreshGrid();
        });

        // Handle reconnection events
        hubConnection.Reconnected += async (connectionId) =>
        {
            Console.WriteLine("Hub reconnected");
            await hubConnection.SendAsync("SubscribeToStocks");
        };

        // Handle disconnection events
        hubConnection.Closed += async (error) =>
        {
            if (error != null)
            {
                Console.Error.WriteLine($"Hub connection closed with error: {error.Message}");
            }
            
            // Wait before attempting to reconnect with random backoff
            await Task.Delay(ReconnectRandom.Next(0, 5000));
            try
            {
                await hubConnection.StartAsync();
            }
            catch
            {
                // Connection failed, will retry on next interval
            }
        };

        try
        {
            // Start the SignalR connection
            await hubConnection.StartAsync();
            // Subscribe to stock updates
            await hubConnection.SendAsync("SubscribeToStocks");
        }
        catch (Exception ex)
        {
            Console.Error.WriteLine($"Failed to start hub connection: {ex.Message}");
        }
    }

    /// <summary>
    /// Refreshes the DataGrid by calling its Refresh method.
    /// This forces the DataGrid to re-fetch data and re-render.
    /// </summary>
    private async Task RefreshGrid()
    {
        if (grid != null)
        {
            await InvokeAsync(StateHasChanged);
        }
    }

    /// <summary>
    /// Cleans up resources when the component is disposed.
    /// Ensures the SignalR connection is properly closed.
    /// </summary>
    async ValueTask IAsyncDisposable.DisposeAsync()
    {
        if (hubConnection is not null)
        {
            await hubConnection.DisposeAsync();
        }
    }
}
```


## Running the Application

**Build the Application**

1. Open the terminal or Package Manager Console.
2. Navigate to the project directory.
3. Run the following command:

```powershell
dotnet build
```

**Run the Application**

Execute the following command:

```powershell
dotnet run
```

The output will be similar to:
```
info: Grid_SignalR.Services.StockUpdateBackgroundService[0]
      Stock Update Background Service started
```

**Access the Application**

1. Open a web browser.
2. Navigate to `https://localhost:7018` (or the port shown in the terminal).
3. The application will show:
   - A DataGrid with stock data
   - Prices updating every second in real-time

---

**Available Features**

- **Real-Time Updates**: Stock prices update every second across all connected clients
- **Search**: Find stocks by symbol or company name
- **Filter**: Filter by price range, change percentage, or volume
- **Sort**: Sort by any column in ascending or descending order
- **Responsive Design**: Works on desktop, tablet, and mobile devices
- **Connection Status**: Visual indicator shows SignalR connection status
- **Automatic Reconnection**: Handles network interruptions gracefully
- **Bidirectional Communication**: Supports both server-to-client and client-to-server messaging

---

## Summary

This guide demonstrates how to:

1. Create a real-time data model for stock market data. [🔗](#step-2-create-the-data-model)
2. Implement a data service to manage in-memory stock data. [🔗](#step-3-create-the-data-service)
3. Build a SignalR Hub for server-client communication. [🔗](#step-4-create-the-signalr-hub)
4. Create a background service for continuous updates. [🔗](#step-5-create-the-background-service)
5. Develop a CustomAdaptor for DataGrid operations. [🔗](#step-3-create-the-customadaptor-for-signalr)
6. Register services in the application configuration. [🔗](#step-6-register-services-in-programcs)
7. Build a Blazor component with real-time data binding. [🔗](#step-2-create-the-blazor-component-with-signalr-integration)
8. Implement bidirectional SignalR communication. [🔗](#how-signalr-real-time-updates-work)

The application now provides a complete solution for displaying real-time stock market data with a modern, user-friendly interface using SignalR for high-performance bidirectional communication.

---

## Reference Links

- [SignalR Documentation](https://learn.microsoft.com/en-us/aspnet/core/signalr/introduction)
- [Syncfusion Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid)
- [ASP.NET Core Background Services](https://learn.microsoft.com/en-us/aspnet/core/fundamentals/host/hosted-services)

## Troubleshooting Common SignalR + Blazor DataGrid Issues

This section covers the most frequent problems developers encounter when combining SignalR with Blazor InteractiveServer mode in .NET 8 / .NET 9.

| # | Symptom / Error Message                                                                 | Most Common Cause(s)                                                                 | Quick Fix / Check                                                                 |
|---|------------------------------------------------------------------------------------------|--------------------------------------------------------------------------------------|-----------------------------------------------------------------------------------|
| 1 | "Failed to start hub connection: WebSocket failed to connect" or connection stays "Connecting" | HTTPS → HTTP downgrade attempt, reverse proxy / firewall blocking WebSocket, wrong hub path | Use `NavigationManager.ToAbsoluteUri("/stockhub")` instead of manual replace. Ensure the app runs over **HTTPS** locally (dotnet dev-certs https --trust). Check browser console → Network tab for 400/403/502 on ws:// or wss:// |
| 2 | "The request matched multiple endpoints" (AmbiguousMatchException)                       | `MapHub<...>` placed **before** `MapRazorComponents(...).AddInteractiveServerRenderMode()` | Move `app.MapHub<StockHub>("/stockhub")` **after** the `MapRazorComponents` line in Program.cs |
| 3 | "Cannot read properties of null (reading 'invoke')", "hubConnection is null"            | Component disposed before connection starts / race condition                         | Check `hubConnection` is not null before calling `StartAsync()`. Move connection logic to `OnAfterRenderAsync(firstRender: true)` if timing issues persist |
| 4 | Reconnection loops endlessly or never resumes updates after network drop                 | Missing `Reconnected` handler or not resubscribing to group                          | Add: `hubConnection.Reconnected += async _ => await hubConnection.SendAsync("SubscribeToStocks");` |
| 5 | "401 Unauthorized" or "403 Forbidden" on SignalR connection                              | Authentication required but no token/cookie sent                                     | If using auth: Ensure `AddAuthentication()` + `AddAuthorization()` are configured. For JWT: pass token via `AccessTokenProvider`. For cookies: ensure SameSite=None + Secure when cross-origin |
| 6 | High CPU / memory on server when many clients connected                                  | Sending very large messages repeatedly or no message size limit                     | Set `options.MaximumReceiveMessageSize = 32 * 1024;` (or appropriate value) in `AddSignalR(options => ...)` |
| 7 | "Transport fallback to LongPolling" even though WebSockets should work                   | Server or reverse proxy (nginx, IIS, Azure) does not support WebSockets              | Verify WebSocket protocol is enabled. For IIS: install WebSocket module. For nginx: add `proxy_http_version 1.1;` + `proxy_set_header Upgrade $http_upgrade;` + `proxy_set_header Connection "upgrade";` |
| 8 | Updates arrive but are very delayed (seconds to minutes)                                 | Using LongPolling fallback + high latency, or background service not scoped correctly | Force WebSockets-only transport. Ensure background service uses fresh scope: `using var scope = _serviceProvider.CreateScope();` |
|9 | "JsonException: The JSON value could not be converted to List<Stock>"                    | Mismatched property names / casing between server & client model                     | Use `[JsonPropertyName("...")]` or make sure `Stock` class is identical on both sides (or use shared class library) |

**Quick Diagnostic Steps (always start here)**

1. Open browser DevTools → **Network** tab → filter by **WS** (WebSocket)
2. Look for connection to `/stockhub` — check status code and whether it upgrades to WebSocket (101 Switching Protocols)
3. Check **Console** tab for SignalR logs (enable with `options.LoggerFactory.AddConsole();` in HubConnectionBuilder if needed)
4. Verify the server logs: look for `Stock Update Background Service started` and any SignalR hub connection messages
5. Temporarily comment out `options.Transports = HttpTransportType.WebSockets;` and allow fallback — does it start working? (helps isolate transport issues)

Most real-time issues in Blazor + SignalR setups are solved by:
- Correct endpoint order in Program.cs
- Using `ToAbsoluteUri()` for hub URL
- Ensuring WebSocket support in the hosting environment