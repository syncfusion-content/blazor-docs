---
layout: post
title: Syncfusion® Blazor components with Azure Functions | Syncfusion
description: Step-by-step guide to integrate Azure Functions as a serverless backend for Blazor WebAssembly with Syncfusion components (Grid, Scheduler, DatePicker).
platform: Blazor
control: Common
documentation: ug
---

# Integrating Syncfusion® Blazor Components with Azure Functions

This guide explains how to integrate [Syncfusion® Blazor components](https://www.syncfusion.com/blazor-components) with [Azure Functions](https://learn.microsoft.com/en-us/azure/azure-functions/functions-overview) as a serverless backend in a Blazor WebAssembly application.

## Prerequisites

* [.NET SDK](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks) (version 8.0 or later, this guide uses .NET 10.0)
* [Azure Functions Core Tools](https://learn.microsoft.com/en-us/azure/azure-functions/functions-run-local) (version 4.x or later)
* [Azure CLI](https://learn.microsoft.com/en-us/cli/azure/install-azure-cli-windows?view=azure-cli-latest&pivots=msi#install-or-update)
* [Visual Studio](https://visualstudio.microsoft.com/downloads/) 2022 or later or [Visual Studio Code](https://code.visualstudio.com/) with [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension

Ensure the .NET SDK and Azure Functions Core Tools are compatible with each other. Refer to the [Azure Functions supported versions](https://learn.microsoft.com/en-us/azure/azure-functions/supported-languages) to verify compatibility for your environment.

## Create the projects

In this section, you will create two projects:

* A Blazor WebAssembly (WASM) client application.
* An Azure Functions project using the isolated worker model.

Keeping both projects in the same folder makes development and debugging easier. Run the commands from your terminal in a new, empty directory.

**Step 1: Create the Blazor WebAssembly client project**

Run the following command to create a Blazor WebAssembly application named **Client**.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet new blazorwasm -o Client -f net10.0

{% endhighlight %}
{% endtabs %}

**Step 2: Create the Azure Functions project (isolated worker)**

Create an Azure Functions project named **Functions** using the isolated worker model, then add an HTTP triggered function.

{% tabs %}
{% highlight bash tabtitle="CLI" %}

func init Functions --worker-runtime dotnet-isolated
cd Functions
func new --name OrdersApi --template "HTTP trigger" --authlevel function

{% endhighlight %}
{% endtabs %}

## Install required NuGet packages

Install required packages in your project using the NuGet Package Manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), or the integrated terminal in Visual Studio Code (`dotnet add package`), or the .NET CLI.

**Syncfusion® packages:**

Navigate into the Blazor WASM project (`Client`) directory and install the necessary Syncfusion packages.

* [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid)
* [Syncfusion.Blazor.Schedule](https://www.nuget.org/packages/Syncfusion.Blazor.Schedule)
* [Syncfusion.Blazor.Calendars](https://www.nuget.org/packages/Syncfusion.Blazor.Calendars)
* [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes)

**Microsoft packages:**

Navigate to the Functions project and install the necessary packages for isolated worker runtime Azure Functions with HTTP triggers.

* [Microsoft.Azure.Functions.Worker](https://www.nuget.org/packages/Microsoft.Azure.Functions.Worker)
* [Microsoft.Azure.Functions.Worker.Extensions.Http](https://www.nuget.org/packages/Microsoft.Azure.Functions.Worker.Extensions.Http)

## Add required namespaces

Open the `Client/_Imports.razor` file from WASM project and import the below namespaces.

{% tabs %}
{% highlight razor tabtitle="Client/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Calendars
@using Syncfusion.Blazor.Schedule

{% endhighlight %}
{% endtabs %}

## Register Syncfusion® Blazor service

Add the Syncfusion Blazor service to the `Client/Program.cs` file to enable Syncfusion components in the application.

{% tabs %}
{% highlight cs tabtitle="Program.cs" %}

using Syncfusion.Blazor;
...
builder.Services.AddSyncfusionBlazor();
// For production: read base address from configuration
builder.Services.AddScoped(sp => new HttpClient {  BaseAddress = new Uri("http://localhost:7071/") });

{% endhighlight %}
{% endtabs %}

N> The `BaseAddress` is set to `http://localhost:7071/` for local development. In production, update this to your Azure Function App URL (e.g., `https://myapp.azurewebsites.net`). Consider reading this from configuration.

## Add stylesheet and script resources

Add the Syncfusion theme CSS and required scripts to the `wwwroot/index.html` file from WASM project.

{% tabs %}
{% highlight html  %}

<head>
    ...
    <!-- Syncfusion® theme stylesheet -->
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
    ...
</head>
<body>
    ...
    <!-- Syncfusion® Blazor core script (required for UI components) -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"></script>
    ...
</body>

{% endhighlight %}
{% endtabs %}

## Implement simple Azure Functions endpoints

This example shows two minimal HTTP triggered functions. The GET `/api/orders` returns demo orders filtered by optional from and to query parameters (format yyyy‑MM‑dd), and POST `/api/orders` accepts and echoes a JSON payload. These functions include development-only CORS handling and basic logging. Configure CORS and authentication in Azure for production.

Add the following file to your Azure Functions project (e.g., `OrdersApi.cs`).

{% tabs %}
{% highlight cs tabtitle="OrdersApi.cs" %}

using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Globalization;
using System.Net;

public static class OrdersApi
{
    [Function("GetOrders")]
    public static async Task<HttpResponseData> GetOrders(
        [HttpTrigger(AuthorizationLevel.Function, "get", "options", Route = "orders")] HttpRequestData req,
        FunctionContext ctx)
    {
        // Handle CORS preflight
        if (req.Method.Equals("OPTIONS", StringComparison.OrdinalIgnoreCase))
        {
            var preflight = req.CreateResponse(HttpStatusCode.NoContent);
            preflight.Headers.Add("Access-Control-Allow-Origin", "*");//For local testing only; configure precise origins in production.
            preflight.Headers.Add("Access-Control-Allow-Methods", "GET,POST,OPTIONS");
            preflight.Headers.Add("Access-Control-Allow-Headers", "Content-Type,Authorization");
            return preflight;
        }

        var baseDate = DateTime.UtcNow.Date;
        // Generate demo orders
        var allOrders = Enumerable.Range(1, 10).Select(i => new OrderDto
        {
            Id = i,
            Date = baseDate.AddDays(-(i % 7)),
            Customer = i % 3 == 0 ? "Contoso" : i % 2 == 0 ? "Tailspin" : "ACME",
            Total = Math.Round(20 + i * 15.75, 2)
        }).ToArray();

        // Parse optional query parameters (expected yyyy-MM-dd)
        DateTime? from = null; DateTime? to = null;
        try {
            var query = (req.Url.Query ?? string.Empty).TrimStart('?');
            if (!string.IsNullOrEmpty(query))
            {
                var pairs = query.Split('&', StringSplitOptions.RemoveEmptyEntries);
                foreach (var pair in pairs)
                {
                    var pair_value = pair.Split('=', 2);
                    if (pair_value.Length == 0) continue;
                    var key = WebUtility.UrlDecode(pair_value[0]).Trim();
                    var val = pair_value.Length > 1 ? WebUtility.UrlDecode(pair_value[1]).Trim() : string.Empty;
                    if (string.Equals(key, "from", StringComparison.OrdinalIgnoreCase) && DateTime.TryParseExact(val, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var from_date))
                        from = from_date.Date;
                    if (string.Equals(key, "to", StringComparison.OrdinalIgnoreCase) && DateTime.TryParseExact(val, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var to_date))
                        to = to_date.Date;
                }
            }
        } catch {
            // Ignore parse errors and return unfiltered results
        }

        var orders = allOrders.Where(order =>
            (!from.HasValue || order.Date.Date >= from.Value) &&
            (!to.HasValue || order.Date.Date <= to.Value)).ToArray();

        try {
            var logger = ctx.GetLogger("GetOrders");
            logger.LogInformation($"Returning {orders.Length} orders (from={from?.ToString("yyyy-MM-dd") ?? ""}, to={to?.ToString("yyyy-MM-dd") ?? ""})");
        } catch {
            // Ignore logging failures
        }

        var resp = req.CreateResponse(HttpStatusCode.OK);
        resp.Headers.Add("Content-Type", "application/json; charset=utf-8");
        resp.Headers.Add("Access-Control-Allow-Origin", "*");
        await resp.WriteStringAsync(JsonSerializer.Serialize(orders));
        return resp;
    }

    [Function("PostOrder")]
    public static async Task<HttpResponseData> PostOrder(
        [HttpTrigger(AuthorizationLevel.Function, "post", "options", Route = "orders/add")] HttpRequestData req,
        FunctionContext ctx)
    {
        if (req.Method.Equals("OPTIONS", StringComparison.OrdinalIgnoreCase))
        {
            var preflight = req.CreateResponse(HttpStatusCode.NoContent);
            preflight.Headers.Add("Access-Control-Allow-Origin", "*");
            preflight.Headers.Add("Access-Control-Allow-Methods", "GET,POST,OPTIONS");
            preflight.Headers.Add("Access-Control-Allow-Headers", "Content-Type,Authorization");
            return preflight;
        }

        var body = await new StreamReader(req.Body).ReadToEndAsync();
        object? order = null;
        try {
            order = JsonSerializer.Deserialize<object>(body);
        } catch {
            // Keep behavior: if deserialization fails, return the raw body as a string
            order = body;
        }

        var resp = req.CreateResponse(HttpStatusCode.Created);
        resp.Headers.Add("Access-Control-Allow-Origin", "*");
        await resp.WriteStringAsync(JsonSerializer.Serialize(order));
        return resp;
    }

    private sealed class OrderDto
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string? Customer { get; set; }
        public double Total { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

N> The above code example uses `Access-Control-Allow- : *` for development convenience only. In production, replace `"*"` with your Blazor client's origin (e.g., `https://myapp.azurewebsites.net`) in *Azure Portal → Function App → API → CORS*. Never use wildcards in production.

## Integrating Syncfusion® components in the application

This example demonstrates the use of components, including a [DatePicker](https://www.syncfusion.com/blazor-components/blazor-datepicker) to select a date range, a [DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) to display orders, and a [Scheduler](https://www.syncfusion.com/blazor-components/blazor-scheduler) to present events.

The page expects `HttpClient` to be configured with the Azure Functions host URL as its BaseAddress. It uses JSON data returned from the Functions API to populate both the grid and the scheduler. The sample injects the `HttpClient` instance that was registered earlier in `Program.cs` where the `BaseAddress` points to the Azure Functions host.

Add the following Razor page to your Blazor WebAssembly project.

{% tabs %}
{% highlight razor  %}

@page "/"

@using System.Net.Http.Headers
@inject HttpClient Http
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Calendars
@using Syncfusion.Blazor.Schedule

<div style="display:flex;gap:12px;align-items:center;margin-bottom:12px">
  <SfDatePicker TValue="DateTime?" @bind-Value="From" Placeholder="From" />
  <SfDatePicker TValue="DateTime?" @bind-Value="To" Placeholder="To" />
  <button class="e-control e-btn" @onclick="Load">Load</button>
</div>

<SfGrid DataSource="@OrdersList" AllowPaging="true" Height="300">
  <GridColumns>
    <GridColumn Field="Id" HeaderText="ID" Width="80"></GridColumn>
    <GridColumn Field="Date" HeaderText="Date" Format="d" Width="150"></GridColumn>
    <GridColumn Field="Customer" HeaderText="Customer" Width="200"></GridColumn>
    <GridColumn Field="Total" HeaderText="Total" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
  </GridColumns>
</SfGrid>

<SfSchedule TValue="EventItem" Height="300px" SelectedDate="@DateTime.Today">
  <ScheduleEventSettings DataSource="@EventItems"></ScheduleEventSettings>
</SfSchedule>

@code {

  private List<Order> OrdersList = new();
  private List<EventItem> EventItems = new();
  private DateTime? From = DateTime.Today.AddDays(-7);
  private DateTime? To = DateTime.Today;
  class Order { public int Id { get; set; } public DateTime Date { get; set; } public string? Customer { get; set; } public double Total { get; set; } }
  // Use property names expected by Syncfusion Schedule (StartTime/EndTime/Subject)
  class EventItem { public DateTime StartTime { get; set; } public DateTime EndTime { get; set; } public string? Subject { get; set; } }

  private async Task Load()
  {
    try {
      // For local development: AuthorizationLevel.Function requires only a function key.
      // For production with Microsoft Entra ID, add: Http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
      Http.DefaultRequestHeaders.Authorization = null;
      // Try common development ports: 7071 for Azure Functions, 5298 for Blazor client.
      string[] portsToTry = new[] { "5298", "7071" };
      string body = string.Empty;
      HttpResponseMessage resp = null!;
      bool found = false;
      foreach (var port in portsToTry)
      {
        // This port is for testing only. In production, use HttpClient BaseAddress from configuration.
        var tryUrl = $"http://localhost:{port}/api/orders?from={From:yyyy-MM-dd}&to={To:yyyy-MM-dd}";
        try {
          resp = await Http.GetAsync(tryUrl);
          body = await resp.Content.ReadAsStringAsync();
          if (resp.IsSuccessStatusCode)
          {
            var trimmed = (body ?? string.Empty).TrimStart();
            if (trimmed.StartsWith("[") || trimmed.StartsWith("{"))
            {
              // Valid JSON response
              try {
                OrdersList = System.Text.Json.JsonSerializer.Deserialize<List<Order>>(trimmed) ?? new List<Order>();
                found = true;
                break;
              } catch (Exception jex) {
                Console.WriteLine($"JSON parse failed from {tryUrl}: {jex}");
              }
            }
          }
        } catch (Exception e) {
          Console.WriteLine($"Request to {tryUrl} failed: {e.Message}");
        }
      }

      if (!found)
      {
        OrdersList = new List<Order>();
      }
      EventItems = OrdersList.Select(order => new EventItem { StartTime = order.Date, EndTime = order.Date.AddHours(1), Subject = $"{order.Customer} ({order.Total:C2})" }).ToList();
      StateHasChanged();
    } catch (Exception ex) {
      Console.WriteLine($"Load failed: {ex}");
    }
  }
}

{% endhighlight %}
{% endtabs %}

For browser calls, add the Blazor origin to Function App CORS (*Azure Portal → Function App → API → CORS*).

## Run the application

**Start Functions project:**

{% tabs %}
{% highlight bash tabtitle="CLI" %}

cd Functions
func start

{% endhighlight %}
{% endtabs %}

**In a new terminal, start the Blazor project:**

{% tabs %}
{% highlight bash tabtitle="CLI" %}

cd ../Client
dotnet run

{% endhighlight %}
{% endtabs %}

**Output:**

* Open the client URL in a browser.
* The page displays two date pickers (From/To) and a Load button.
* Select a date range and click **Load**.
* The grid below populates with demo orders, and the schedule shows events (one per order).

![Blazor components with Azure Function](./images/azure-functions.webp)

## See also

* [Getting started with Syncfusion DataGrid](https://blazor.syncfusion.com/documentation/datagrid/getting-started)
* [Getting started with Syncfusion Scheduler](https://blazor.syncfusion.com/documentation/scheduler/getting-started)
* [Getting started with Syncfusion DatePicker](https://blazor.syncfusion.com/documentation/datepicker/getting-started)
