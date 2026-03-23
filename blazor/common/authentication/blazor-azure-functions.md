--- 
layout: post
title: Blazor WebAssembly with Azure Functions | Syncfusion
description: Step-by-step guide to use Azure Functions as a serverless backend for Blazor WebAssembly with Syncfusion components (Grid, Scheduler, DatePicker).
platform: Blazor
control: Common
documentation: ug
---

# Blazor with Azure Functions

This guide shows how to build a runnable Blazor WebAssembly app that uses Azure Functions as a serverless backend and integrates Syncfusion Blazor components (`Grid`, `Scheduler`, `DatePicker`). It focuses on practical steps for local development, security options (Function keys), calling functions from Blazor, CORS, error/retry handling, and a compact example (Orders list + Scheduler).

## What is Azure Functions?

Azure Functions is a serverless compute service designed to run small pieces of code (“functions”) without managing infrastructure. Azure automatically handles hosting, scaling, and execution. Functions run on demand triggered by HTTP requests, timers, queues, or other Azure events making them ideal for lightweight APIs, background tasks, and event-driven workflows.

## Why use Azure Functions with Blazor?

Azure Functions scale independently from the UI and require minimal operational overhead, making them ideal for small backend APIs to serve Blazor WebAssembly. They integrate well with Syncfusion components like `SfGrid` and `SfSchedule` by exposing lightweight HTTP endpoints that return JSON.

## Prerequisites

* .NET 10 SDK
* Azure Functions Core Tools (v4.x)
* Azure CLI
* Visual Studio 2022 or VS Code with C# extension

Ensure the .NET SDK and Functions Core [Tools compatibility](https://learn.microsoft.com/azure/azure-functions/functions-run-local).

## Secure Azure Functions

Protect endpoints using Function keys for simple, quick authorization or Microsoft Entra ID for token-based, per-user authorization and auditing. EasyAuth (App Service Authentication) lets Azure validate tokens for you. For server-side validation in isolated worker functions use `Microsoft.IdentityModel.Tokens` and `System.IdentityModel.Tokens.Jwt` (or `Microsoft.Identity.Web` for richer features). EasyAuth can validate tokens at platform level so your functions don't need to parse JWTs.

### Function-level authorization

Function keys are simple shared secrets passed via `?code=` or the `x-functions-key` header, but they offer no user identity or fine‑grained access control, so they shouldn’t be used as production‑level authorization. Reserve function keys for trusted server-to-server or internal automation workflows.

Examples:

* Query string

```
 GET /api/orders?code=YOUR_FUNCTION_KEY
```

* HTTP header: 
Request-side (C#):

```cs
builder.Services.AddScoped(sp => {
  var client = new HttpClient { BaseAddress = new Uri("http://localhost:7071/") };
  client.DefaultRequestHeaders.Add("x-functions-key", Environment.GetEnvironmentVariable("FUNCTION_KEY") ?? "YOUR_FUNCTION_KEY");
  return client;
});
```

Blazor HttpClient (add before call): 

```cs
var req = new HttpRequestMessage(HttpMethod.Get, "/api/orders?...");
req.Headers.Add("x-functions-key", "YOUR_FUNCTION_KEY");
await Http.SendAsync(req);
```
For production, prefer Entra ID (Azure AD) bearer tokens and managed identities.

### EasyAuth / Entra ID

Register an application in Entra ID and configure the Function App Authentication provider (EasyAuth) to require tokens, or keep EasyAuth off and validate JWTs inside functions with `Microsoft.IdentityModel.Tokens`. For production, Entra ID and managed identities provide better security and auditability than function keys.

Refer to the below:
 
* [Microsoft Entra ID App Registration](https://learn.microsoft.com/azure/active-directory/develop/quickstart-register-app)
* [App Service Authentication (EasyAuth)](https://learn.microsoft.com/azure/app-service/overview-authentication-authorization)
* [Functions CORS and app settings](https://learn.microsoft.com/azure/azure-functions/functions-how-to-use-azure-function-app-settings#cors)

Use EasyAuth (platform) for standard token validation; validate JWTs in-function when you need custom claims or fine‑grained checks.

## Working with Function Apps in a Real‑World Blazor App

This sample exposes `GET /api/orders` and `POST /api/orders`. The Blazor page uses `SfDatePicker` to select date ranges, `SfGrid` to list orders, `SfSchedule` to show order events. Keep functions single-purpose, persist real data in storage, and enable Application Insights for telemetry.

### Azure Functions with Blazor Components Example

**Create solution and projects**

Create a Blazor WASM client and isolated Azure Functions project using below:

```
dotnet new blazorwasm -o Client -f net10.0
func init Functions --worker-runtime dotnet-isolated
cd Functions
func new --name OrdersApi --template "HTTP trigger" --authlevel function
```

### Add NuGet packages (client and functions)

**Client: Syncfusion and optional MSAL for Entra ID auth**

```
cd Client
dotnet add package Syncfusion.Blazor
dotnet add package Syncfusion.Blazor.Themes 
cd ..
```

**Functions: worker and HTTP extension (if missing)**

```
cd Functions
dotnet add package Microsoft.Azure.Functions.Worker
dotnet add package Microsoft.Azure.Functions.Worker.Extensions.Http
cd ..
```

## Add Required Namespaces

Open the `Client/_Imports.razor` file and import the below namespaces.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Calendars
@using Syncfusion.Blazor.Schedule

{% endhighlight %}
{% endtabs %}

## Register Syncfusion Blazor Service

Register the Syncfusion Blazor Service in the `Client/Program.cs` file of your Blazor App.

```cs

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Client;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSyncfusionBlazor();
// Configure Functions API base URL
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:7071/") });


await builder.Build().RunAsync();

```

## Add Stylesheet and Script Resources

Add the Syncfusion theme CSS and required scripts to the `wwwroot/index.html` file. 

{% tabs %}
{% highlight html  %}

<head>
     <!-- Syncfusion theme style sheet -->
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
</head>

<body>
    <!-- Syncfusion Blazor component's script reference -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"></script>
</body>

{% endhighlight %}
{% endtabs %}

### Implement simple Azure Functions endpoints

This example shows two minimal HTTP-triggered functions: GET `/api/orders` returns demo orders filtered by optional from/to query parameters (format yyyy‑MM‑dd), and POST `/api/orders` accepts and echoes a JSON payload. The functions include development-only CORS handling and basic logging; configure CORS and authentication in Azure for production.

```cs

using System.Text.Json;
using Microsoft.Extensions.Logging;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using System.Globalization;
using System.Net;
using Microsoft.AspNetCore.Mvc;

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
        try
        {
            var query = (req.Url.Query ?? string.Empty).TrimStart('?');
            if (!string.IsNullOrEmpty(query))
            {
                var pairs = query.Split('&', StringSplitOptions.RemoveEmptyEntries);
                foreach (var p in pairs)
                {
                    var kv = p.Split('=', 2);
                    if (kv.Length == 0) continue;
                    var key = WebUtility.UrlDecode(kv[0]).Trim();
                    var val = kv.Length > 1 ? WebUtility.UrlDecode(kv[1]).Trim() : string.Empty;
                    if (string.Equals(key, "from", StringComparison.OrdinalIgnoreCase) && DateTime.TryParseExact(val, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var f))
                        from = f.Date;
                    if (string.Equals(key, "to", StringComparison.OrdinalIgnoreCase) && DateTime.TryParseExact(val, "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal, out var t))
                        to = t.Date;
                }
            }
        }
        catch
        {
            // ignore parse errors and return unfiltered results
        }

        var orders = allOrders.Where(o =>
            (!from.HasValue || o.Date.Date >= from.Value) &&
            (!to.HasValue || o.Date.Date <= to.Value)).ToArray();

        try
        {
            var logger = ctx.GetLogger("GetOrders");
            logger.LogInformation($"Returning {orders.Length} orders (from={from?.ToString("yyyy-MM-dd") ?? ""}, to={to?.ToString("yyyy-MM-dd") ?? ""})");
        }
        catch
        {
            // ignore logging failures
        }

        var resp = req.CreateResponse(HttpStatusCode.OK);
        resp.Headers.Add("Content-Type", "application/json; charset=utf-8");
        resp.Headers.Add("Access-Control-Allow-Origin", "*");//For local testing only; configure precise origins in production.
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
            preflight.Headers.Add("Access-Control-Allow-Origin", "*");//For local testing only; configure precise origins in production.
            preflight.Headers.Add("Access-Control-Allow-Methods", "GET,POST,OPTIONS");
            preflight.Headers.Add("Access-Control-Allow-Headers", "Content-Type,Authorization");
            return preflight;
        }

        var body = await new StreamReader(req.Body).ReadToEndAsync();
        object? order = null;
        try
        {
            order = JsonSerializer.Deserialize<object>(body);
        }
        catch
        {
            // keep behavior: if deserialization fails, return the raw body as string
            order = body;
        }

        try
        {
            var logger = ctx.GetLogger("PostOrder");
            logger.LogInformation("Received PostOrder request");
        }
        catch
        {
        }

        var resp = req.CreateResponse(HttpStatusCode.Created);
        resp.Headers.Add("Access-Control-Allow-Origin", "*");//For local testing only; configure precise origins in production.
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

```

### Create the Blazor page using Syncfusion components

This example demonstrates using Syncfusion controls: two SfDatePicker components to choose a range, an SfGrid to list orders, and an SfSchedule to show events. It expects `HttpClient` to be configured with the Functions host as BaseAddress and uses JSON binding to populate the grid and scheduler. The sample injects `HttpClient` the earlier `Program.cs` scoped `HttpClient` whose `BaseAddress` points to the Functions host.

{% tabs %}
{% highlight razor  %}

@page "/"
@using System.Net.Http.Headers
@inject HttpClient Http
@using Microsoft.AspNetCore.Components.WebAssembly.Authentication
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Calendars
@using Syncfusion.Blazor.Notifications
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
    try
    {
      // Bypass authentication for local dev; ensure no Authorization header is set.
      Http.DefaultRequestHeaders.Authorization = null;

      string[] portsToTry = new[] { "5298", "7071" };
      string body = string.Empty;
      HttpResponseMessage resp = null!;
      bool found = false;
      foreach (var port in portsToTry)
      {
        var tryUrl = $"http://localhost:{port}/api/orders?from={From:yyyy-MM-dd}&to={To:yyyy-MM-dd}";
        try
        {
          resp = await Http.GetAsync(tryUrl);
          Console.WriteLine($"GET {tryUrl} => {(int)resp.StatusCode} {resp.ReasonPhrase}");
          body = await resp.Content.ReadAsStringAsync();
          Console.WriteLine($"Response body (truncated): {body?.Substring(0, Math.Min(400, body.Length))}");
          if (resp.IsSuccessStatusCode)
          {
            var trimmed = (body ?? string.Empty).TrimStart();
            if (trimmed.StartsWith("[") || trimmed.StartsWith("{"))
            {
              // valid JSON response
              try
              {
                OrdersList = System.Text.Json.JsonSerializer.Deserialize<List<Order>>(trimmed) ?? new List<Order>();
                found = true;
                break;
              }
              catch (Exception jex)
              {
                Console.WriteLine($"JSON parse failed from {tryUrl}: {jex}");
              }
            }
            else
            {
              Console.WriteLine($"Response from {tryUrl} does not appear to be JSON.");
            }
          }
        }
        catch (Exception e)
        {
          Console.WriteLine($"Request to {tryUrl} failed: {e.Message}");
        }
      }

      if (!found)
      {
        OrdersList = new List<Order>();
        Console.WriteLine("No valid response received from local Functions host on tested ports.");
      }
      EventItems = OrdersList.Select(o => new EventItem { StartTime = o.Date, EndTime = o.Date.AddHours(1), Subject = $"{o.Customer} ({o.Total:C2})" }).ToList();
      StateHasChanged();
      Console.WriteLine($"Orders loaded: {OrdersList.Count}");
    }
    catch (Exception ex)
    {
      Console.WriteLine($"Load failed: {ex}");
    }
  }
}

{% endhighlight %}
{% endtabs %}

For browser calls, add the Blazor origin to Function App CORS (Azure Portal → Function App → API → CORS).

## Run the application

**Start Functions:**

```
cd Functions
func start
```

**Run client:**

```
cd ../Client
dotnet run
```

**Output:**

* Open the client URL
* Select a date range and click Load — the grid fills with demo orders and the schedule shows one event per order.

[!Blazor components with Azure Function](./images/azure-functions.webp)