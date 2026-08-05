---
layout: post
title: Blazor Pivot Table Firebase Realtime Database Binding | Syncfusion®
description: Bind a Firebase Realtime Database to the Blazor Pivot Table through an ASP.NET Core API and the Syncfusion UrlAdaptor.
platform: Blazor
control: PivotTable
documentation: ug
---

# Connect Firebase Realtime Database to Blazor Pivot Table

The [Blazor Pivot Table](https://www.syncfusion.com/blazor-components/blazor-pivot-table) can load and edit Firebase Realtime Database data through an ASP.NET Core API. [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) sends HTTP requests to the API, and the API uses the [Firebase Realtime Database REST API](https://firebase.google.com/docs/database/rest/save-data) to read and persist JSON records stored under an `Orders` node.

This guide uses same-origin relative API URLs. The sample read action returns the complete `Orders` node and does not apply `DataManagerRequest` operations. Add server-side filtering, sorting, and paging before using this design with large datasets.

## Prerequisites

The sample was tested with the following versions and configuration:

| Software or package | Version | Notes |
|---|---:|---|
| .NET SDK | 10.0 | Required to target `net10.0`. `MapStaticAssets()` requires .NET 9 or later. |
| Visual Studio | 2026 (version 18.0) or later | Required to target `net10.0`; install the ASP.NET and web development workload. VS Code and the .NET CLI are also supported |
| Firebase project | Active project | A Firebase project with Realtime Database enabled is required to host the data |
| Syncfusion.Blazor.PivotTable | 34.1.33 (31.2.10 or later) | [.NET 10 support starts with 31.2.10](https://blazor.syncfusion.com/documentation/common/how-to/version-compatibility); keep all Syncfusion packages on the same version |
| Syncfusion.Blazor.Themes | 34.1.33 (31.2.10 or later) | Provides the component theme |

The application uses the Blazor Web App template with Interactive Server rendering. Syncfusion packages from NuGet.org require a valid license or trial key; follow the [license-key registration instructions](https://blazor.syncfusion.com/documentation/getting-started/license-key/how-to-register-in-an-application).

## Firebase Realtime Database Setup and Application Configuration

### Step 1: Create the Blazor Web App

Create an Interactive Server Blazor Web App:

```powershell
dotnet new blazor -n PivotTableRealtimeDatabase -f net10.0 -int Server -ai
cd PivotTableRealtimeDatabase
```

In Visual Studio, the equivalent choices are **Blazor Web App**, **.NET 10**, **Interactive render mode: Server**, and **Interactivity location: Global**.

### Step 2: Create the Firebase Project

Open the [Firebase console](https://console.firebase.google.com/) and create a new project (for example, `pivottablerealtimedatabase`). Accept the default Google Analytics configuration or disable it; the Realtime Database does not require Analytics.

### Step 3: Create the Realtime Database

In the Firebase console, navigate to **Build → Realtime Database** and click **Create Database**. Select **Start in test mode** so the REST API can read and write during development, and choose a region close to your users (for example, `asia-southeast1`).

> **Note:** Test mode opens read and write access to the database for 30 days. Configure [Firebase Security Rules](https://firebase.google.com/docs/database/security) before deploying the application. See Step 3.5 for a sample production ruleset.

After the database is provisioned, copy the database URL from the **Data** tab. This URL is required in `appsettings.json` later in this guide. The URL follows the format `https://<project-id>-default-rtdb.<region>.firebasedatabase.app`; projects created before February 2025 may use the legacy `https://<project-id>.firebaseio.com` host instead.

### Step 4: Create the Orders Node and Import Sample Data

The Realtime Database stores data as a hierarchical JSON tree. Each order is stored as a child of a root node keyed by its `orderId`.

Create a root node named:

```text
Orders
```

Use the Firebase console **Import JSON** panel to import the following sample data into the `Orders` node (the keys under `Orders` are numeric strings, e.g. `"1"`, `"2"`):

```json
{
  "Orders": {
    "1": {
      "orderId": 1,
      "customerName": "John Smith",
      "employeeId": 101,
      "freight": 32.5,
      "shipCity": "New York"
    },
    "2": {
      "orderId": 2,
      "customerName": "Toms",
      "employeeId": 102,
      "freight": 80.2,
      "shipCity": "London"
    },
    "3": {
      "orderId": 3,
      "customerName": "Sven",
      "employeeId": 101,
      "freight": 52.1,
      "shipCity": "Berlin"
    },
    "4": {
      "orderId": 4,
      "customerName": "Sara",
      "employeeId": 103,
      "freight": 18.4,
      "shipCity": "Madrid"
    },
    "5": {
      "orderId": 5,
      "customerName": "Paul",
      "employeeId": 102,
      "freight": 64.75,
      "shipCity": "Tokyo"
    }
  }
}
```

Verify the imported data in the **Data** tab:

| Key | orderId | customerName | employeeId | freight | shipCity |
|---:|---:|---|---:|---:|---|
| 1 | 1 | John Smith | 101 | 32.50 | New York |
| 2 | 2 | Toms | 102 | 80.20 | London |
| 3 | 3 | Sven | 101 | 52.10 | Berlin |
| 4 | 4 | Sara | 103 | 18.40 | Madrid |
| 5 | 5 | Paul | 102 | 64.75 | Tokyo |

> **Note:** The sample uses numeric keys (`1`–`5`) under the `Orders` node. The controller is implemented to deserialize the resulting REST API response shape; see the Read Operation in Step 7 for details.

### Step 3.5: Add a Production Security Ruleset (Recommended Before Continuing)

The test-mode ruleset allows unrestricted read and write access for 30 days. Before you start building, replace the rules with a minimum locked-down ruleset that allows only the operations this sample needs. In the Firebase console, open **Build → Realtime Database → Rules** and replace the body with:

```json
{
  "rules": {
    "Orders": {
      ".read": true,
      ".write": true,
      ".indexOn": ["orderId"]
    }
  }
}
```

> **Note:** The `.read: true` / `.write: true` rules above still expose the database to anonymous clients and are only suitable for local development. For production, gate access behind an authentication provider (for example, Firebase Auth ID tokens) and restrict the rules to authenticated requests with the structure shown in the [Firebase Security Rules quickstart](https://firebase.google.com/docs/database/security). The `.indexOn` entry enables efficient `WhereEqualTo` queries against the `orderId` field once you switch to a query-based controller.

### Step 5: Install the Required NuGet Packages

Run these commands in the `PivotTableRealtimeDatabase` project directory:

```powershell
dotnet add package Syncfusion.Blazor.PivotTable --version 34.1.33
dotnet add package Syncfusion.Blazor.Themes --version 34.1.33
dotnet restore
```

The project file should contain:

```xml
<ItemGroup>
  <PackageReference Include="Syncfusion.Blazor.PivotTable" Version="34.1.33" />
  <PackageReference Include="Syncfusion.Blazor.Themes" Version="34.1.33" />
</ItemGroup>
```

The sample accesses the Realtime Database directly through the REST API using `HttpClient`, so no Firebase client SDK package is required. The controller uses `System.Text.Json`, so no `Newtonsoft.Json` reference is needed.

> **Note:** If you are behind a corporate proxy or use an internal NuGet feed (for example, a Nexus or Artifactory mirror), pass `--source https://api.nuget.org/v3/index.json` to each `dotnet add package` command so the public Syncfusion packages are resolved from nuget.org. Confirm with `dotnet nuget list source` that the desired source appears first.

### Step 6: Configure the Realtime Database URL

Store the Realtime Database URL in `appsettings.json`:

```json
{
  "FirebaseSettings": {
    "DatabaseUrl": "<YOUR_FIREBASE_REALTIME_DATABASE_URL>"
  },
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*"
}
```

The required key is `FirebaseSettings:DatabaseUrl`. The other top-level keys (`Logging`, `AllowedHosts`) are the standard ASP.NET Core defaults. If `appsettings.Development.json` exists, it overrides these values when the app runs under the `Development` environment.

> **Note:** Replace `<YOUR_FIREBASE_REALTIME_DATABASE_URL>` with the Realtime Database URL copied from the Firebase console **Data** tab (for example, `https://<project-id>-default-rtdb.<region>.firebasedatabase.app`). Older projects (created before February 2025) use the legacy host `https://<project-id>.firebaseio.com`; the controller works with either host. A relative URL is not supported here because the URL points to the Firebase host, not the application host.

### Step 7: Create the API Controller

Create a `Controllers` folder and a `Models` folder at the project root. The `Order` model and the `CRUDModel<T>` wrapper live in `Models/Order.cs` and `Models/CRUDModel.cs` so the same types can be referenced from `OrderController` and the Pivot Table page. The controller uses `IHttpClientFactory` so the underlying `HttpClient` is properly pooled and disposed, applies a 30-second timeout, and sends an `Accept: application/json` header on every request.

Before showing the full files, here is a summary of what each endpoint does:

| Endpoint | HTTP verb | Firebase REST call | Action |
|---|---|---|---|
| `Post` | `POST /api/Order` | `GET {databaseUrl}/Orders.json` | Returns the entire `Orders` node as `{ result, count }`. The `DataManagerRequest` is intentionally ignored. |
| `Insert` | `POST /api/Order/Insert` | `PUT {databaseUrl}/Orders/{nextOrderId}.json` | Computes the next `orderId` from the existing node, writes the new record, and returns it with the generated key. |
| `Update` | `POST /api/Order/Update` | `PUT {databaseUrl}/Orders/{OrderID}.json` | Replaces the node at the supplied key path with the incoming record. |
| `Delete` | `POST /api/Order/Delete` | `DELETE {databaseUrl}/Orders/{orderId}.json` | Removes the node at the supplied key path. |

The endpoint behavior is also described in the [API Contract](#api-contract) section; the table above is a quick reference.

**Models/Order.cs**

```csharp
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace PivotTableRealtimeDatabase.Models
{
    public class Order
    {
        [Key]
        [JsonPropertyName("orderId")]
        public int OrderID { get; set; }

        [JsonPropertyName("customerName")]
        public string? CustomerName { get; set; }

        [JsonPropertyName("employeeId")]
        public int EmployeeID { get; set; }

        [JsonPropertyName("freight")]
        public double Freight { get; set; }

        [JsonPropertyName("shipCity")]
        public string? ShipCity { get; set; }
    }
}
```

**Models/CRUDModel.cs**

```csharp
using System.Text.Json.Serialization;

namespace PivotTableRealtimeDatabase.Models
{
    public class CRUDModel<T> where T : class
    {
        // One of "insert", "update", or "remove". The controller uses the
        // route (Insert/Update/Delete) rather than this value, but the field
        // is kept for compatibility with the UrlAdaptor payload shape.
        [JsonPropertyName("action")]
        public string? Action { get; set; }

        [JsonPropertyName("keyColumn")]
        public string? KeyColumn { get; set; }

        [JsonPropertyName("key")]
        public object? Key { get; set; }

        [JsonPropertyName("value")]
        public T? Value { get; set; }

        [JsonPropertyName("added")]
        public List<T>? Added { get; set; }

        [JsonPropertyName("changed")]
        public List<T>? Changed { get; set; }

        [JsonPropertyName("deleted")]
        public List<T>? Deleted { get; set; }

        [JsonPropertyName("params")]
        public IDictionary<string, object>? Params { get; set; }
    }
}
```

**Controllers/OrderController.cs**

```csharp
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using PivotTableRealtimeDatabase.Models;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;

namespace PivotTableRealtimeDatabase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    // See the antiforgery note in Step 8: SfDataManager does not attach an
    // antiforgery token, so bypass the global token check for these endpoints.
    [IgnoreAntiforgeryToken]
    public class OrderController : ControllerBase
    {
        private readonly IHttpClientFactory httpClientFactory;
        private readonly string databaseUrl;

        public OrderController(
            IConfiguration configuration,
            IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;

            databaseUrl =
                configuration["FirebaseSettings:DatabaseUrl"]
                ?? throw new InvalidOperationException(
                    "Firebase Realtime Database URL is not configured.");
        }

        private HttpClient CreateClient()
        {
            HttpClient client = httpClientFactory.CreateClient();
            client.Timeout = TimeSpan.FromSeconds(30);
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue(
                    "application/json"));
            return client;
        }

        [HttpPost]
        public async Task<object> Post([FromBody] DataManagerRequest request)
        {
            _ = request;

            HttpClient httpClient = CreateClient();

            string url = $"{databaseUrl}/Orders.json";

            string json = await httpClient.GetStringAsync(url);

            List<Order?>? firebaseData =
                JsonSerializer.Deserialize<List<Order?>>(json);

            List<Order> orders =
                firebaseData?
                    .Where(x => x != null)
                    .Select(x => x!)
                    .OrderBy(x => x.OrderID)
                    .ToList()
                ?? new();

            return new
            {
                result = orders,
                count = orders.Count
            };
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] CRUDModel<Order> value)
        {
            if (value.Value is not Order order)
            {
                return BadRequest();
            }

            HttpClient httpClient = CreateClient();

            string url = $"{databaseUrl}/Orders.json";

            string json = await httpClient.GetStringAsync(url);

            List<Order?>? firebaseData =
                JsonSerializer.Deserialize<List<Order?>>(json);

            // Use DefaultIfEmpty so the Max call never throws on an empty
            // collection. If the database has no records, the next id is 1.
            int nextOrderId = (firebaseData ?? new List<Order?>())
                .Where(x => x != null)
                .Select(x => x!.OrderID)
                .DefaultIfEmpty(0)
                .Max() + 1;

            order.OrderID = nextOrderId;

            string orderJson = JsonSerializer.Serialize(order);

            await httpClient.PutAsync(
                $"{databaseUrl}/Orders/{nextOrderId}.json",
                new StringContent(
                    orderJson,
                    System.Text.Encoding.UTF8,
                    "application/json"));

            return Ok(order);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update([FromBody] CRUDModel<Order> value)
        {
            if (value.Value is not Order order)
            {
                return BadRequest();
            }

            HttpClient httpClient = CreateClient();

            string orderJson = JsonSerializer.Serialize(order);

            HttpResponseMessage response = await httpClient.PutAsync(
                $"{databaseUrl}/Orders/{order.OrderID}.json",
                new StringContent(
                    orderJson,
                    System.Text.Encoding.UTF8,
                    "application/json"));

            return response.IsSuccessStatusCode ? Ok(order) : BadRequest();
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete([FromBody] CRUDModel<Order> value)
        {
            if (!int.TryParse(value.Key?.ToString(), out int orderId))
            {
                return BadRequest();
            }

            HttpClient httpClient = CreateClient();

            HttpResponseMessage response = await httpClient.DeleteAsync(
                $"{databaseUrl}/Orders/{orderId}.json");

            return response.IsSuccessStatusCode ? NoContent() : NotFound();
        }
    }
}
```

The controller exposes the read, insert, update, and delete endpoints described in the [API Contract](#api-contract). The exception middleware configured in the next step logs unhandled failures and returns generic problem responses without exposing Firebase URLs or request details.

The `Post` action deserializes the REST response into `List<Order?>` so any missing numeric positions in the `Orders` node are represented as `null` and filtered out. The `Insert` action uses `DefaultIfEmpty(0).Max() + 1` so it is safe on an empty database (the first insert is assigned `orderId = 1`).

> The `Insert` action reads the entire `Orders` node on every insert to compute the next id. For large datasets, append `?shallow=true` to the read URL and count the keys client-side to avoid a full payload transfer.

#### Order Model and CRUDModel

The `Order` model maps .NET properties to Realtime Database JSON fields through `[JsonPropertyName]`, and `OrderID` carries `[Key]` so the Pivot Table can identify the primary key for update and delete requests. `OrderID` is declared as non-nullable `int`; the UrlAdaptor uses the key to target the correct document path and requires a value. `Freight` is declared as `double` to match the Realtime Database JSON values.

The `CRUDModel<T>.Action` field is one of `"insert"`, `"update"`, or `"remove"` and identifies the operation; this sample routes writes by controller route (`/Insert`, `/Update`, `/Delete`) rather than reading `Action`, so the field is preserved for compatibility with the UrlAdaptor payload shape. The other properties (`added`, `changed`, `deleted`, `params`) are used for batch editing, which this sample does not enable.

### Step 8: Configure Program.cs

Replace `Program.cs` with:

```csharp
using PivotTableRealtimeDatabase.Components;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Register the Syncfusion license before builder.Build().
// Load the license from configuration (or an environment variable) so the
// key never lives in source control. Leave the line commented out if you
// do not have a key yet — the app runs with a license banner only.
string? syncfusionLicense =
    builder.Configuration["Syncfusion:LicenseKey"]
    ?? Environment.GetEnvironmentVariable("SYNCFUSION_LICENSE_KEY");
if (!string.IsNullOrWhiteSpace(syncfusionLicense))
{
    Syncfusion.Licensing.SyncfusionLicenseProvider
        .RegisterLicense(syncfusionLicense);
}

builder.Services.AddSyncfusionBlazor();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddControllers();

// IHttpClientFactory is consumed by OrderController to avoid socket
// exhaustion under sustained load. Add a named client if you want to
// centralize the base address and default headers for the Firebase REST
// API in one place.
builder.Services.AddHttpClient();
builder.Services.AddProblemDetails();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseHsts();
}

app.UseExceptionHandler();
app.UseHttpsRedirection();

app.MapControllers();

app.UseAntiforgery();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
```

Key registration points:

- `AddSyncfusionBlazor()` registers the Syncfusion Blazor services required by the Pivot Table.
- `AddRazorComponents().AddInteractiveServerComponents()` enables Interactive Server rendering.
- `AddControllers()` registers the API controllers, including `OrderController`.
- `AddHttpClient()` registers `IHttpClientFactory`, which `OrderController` resolves in its constructor. The factory pools underlying handlers, so a fresh client per request is safe.
- `AddProblemDetails()` and `UseExceptionHandler()` log unhandled failures and return generic error responses.
- `MapControllers()` routes requests to the API endpoints.
- `MapStaticAssets()` is a .NET 9+ API; it maps the application's static web assets, including assets supplied by referenced component packages.

> **Note:** Remove the comment markers and fill in your Syncfusion license or trial key in `Program.cs` before running the application. The recommended way is to store the key in `appsettings.json` (for example, `"Syncfusion": { "LicenseKey": "..." }`) or in the `SYNCFUSION_LICENSE_KEY` environment variable so the key never appears in source control. Follow the [license-key registration instructions](https://blazor.syncfusion.com/documentation/getting-started/license-key/how-to-register-in-an-application) for details.

> **Note:** `app.UseHttpsRedirection()` requires `Properties/launchSettings.json` to define an HTTPS `applicationUrl` (for example, `"https://localhost:5001"`) and a trusted ASP.NET Core development certificate. On Windows, run `dotnet dev-certs https --trust` once after installing the SDK so the redirect does not fail with `ERR_CERT_AUTHORITY_INVALID` on first launch. The default `dotnet new blazor` launch profile already includes both, but confirm the file has not been edited away.

> **Note:** `app.UseAntiforgery()` protects form posts and Razor component actions, but `SfDataManager` does not automatically attach an antiforgery token to its POSTs. For the API endpoints in this sample, leave the global antiforgery middleware in place and add an `[IgnoreAntiforgeryToken]` attribute on `OrderController` (or apply a named policy) so the controller actions remain callable from the Pivot Table. If you later authenticate the API with cookies, configure the adaptor to send the antiforgery token and remove the ignore attribute.

### Step 9: Configure the Pivot Table

Add these namespaces to `Components/_Imports.razor`:

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.PivotView
@using PivotTableRealtimeDatabase.Models
```

In `Components/App.razor`, add the Syncfusion stylesheet inside `<head>`:

```html
<link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css"
      rel="stylesheet" />
```

Add the Syncfusion script immediately before `</body>`, after the template's existing `_framework/blazor.web.js` reference:

```html
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"
        type="text/javascript"></script>
```

Do not add a second `_framework/blazor.web.js` reference if the template already contains one. The completed `App.razor` should look like:

```html
<!DOCTYPE html>
<html lang="en">

<head>
    <meta charset="utf-8" />
    <meta name="viewport" content="width=device-width, initial-scale=1.0" />
    <base href="/" />
    <link rel="stylesheet" href="@Assets["lib/bootstrap/dist/css/bootstrap.min.css"]" />
    <link rel="stylesheet" href="@Assets["app.css"]" />
    <link rel="stylesheet" href="@Assets["PivotTableRealtimeDatabase.styles.css"]" />
    <ImportMap />
    <link rel="icon" type="image/png" href="favicon.png" />
    <HeadOutlet @rendermode="InteractiveServer" />
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

<body>
    <Routes @rendermode="InteractiveServer" />
    <script src="_framework/blazor.web.js"></script>
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>

</html>
```

Replace `Components/Pages/Home.razor` with the following markup. The `SfDataManager` URLs use same-origin relative paths (`/api/Order`, `/api/Order/Insert`, etc.) so they resolve against whatever port the application is launched on, avoiding hard-coded development ports and HTTP-to-HTTPS mixed-content failures:

```cshtml
@page "/"
@using PivotTableRealtimeDatabase.Models

<SfPivotView TValue="Order" Width="1000" Height="300" ShowFieldList="true">
    <PivotViewDataSourceSettings TValue="Order" ExpandAll="false" EnableSorting="true">
        <SfDataManager Url="/api/Order"
                       InsertUrl="/api/Order/Insert"
                       UpdateUrl="/api/Order/Update"
                       RemoveUrl="/api/Order/Delete"
                       Adaptor="Adaptors.UrlAdaptor">
        </SfDataManager>
        <PivotViewColumns>
            <PivotViewColumn Name="EmployeeID"></PivotViewColumn>
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="CustomerName"></PivotViewRow>
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="Freight" Caption="Freight"></PivotViewValue>
        </PivotViewValues>
    </PivotViewDataSourceSettings>
    <PivotViewGridSettings ColumnWidth="120"></PivotViewGridSettings>
    <PivotViewEvents TValue="Order" BeginDrillThrough="BeginDrillThrough"></PivotViewEvents>
    <PivotViewCellEditSettings AllowEditing="true"
                               AllowAdding="true"
                               AllowDeleting="true"
                               Mode="EditMode.Normal">
    </PivotViewCellEditSettings>
</SfPivotView>

@code {
    // The BeginDrillThrough event fires when the user double-clicks a
    // summary value cell to open the drill-through editor. The handler
    // marks the OrderID column as the primary key on the drill-through
    // grid so the UrlAdaptor can target update and delete requests.
    private void BeginDrillThrough(BeginDrillThroughEventArgs args)
    {
        for (int i = 0; i < args.GridObj.Columns.Count; i++)
        {
            if (args.GridObj.Columns[i].Field == "OrderID")
            {
                args.GridObj.Columns[i].IsPrimaryKey = true;
            }
            else
            {
                args.GridObj.Columns[i].Visible = true;
            }
        }
    }
}
```

The `BeginDrillThrough` event is used to mark `OrderID` as the primary key on the drill-through grid. This tells the DataManager which column uniquely identifies each record so that insert, update, and delete requests carry the correct key. Without this configuration, the write operations cannot target the intended row.

## API Contract

| Method | Route | Payload | Success response |
|---|---|---|---|
| `POST` | `/api/Order` | `DataManagerRequest` | `200` with `{ result, count }` |
| `POST` | `/api/Order/Insert` | `CRUDModel<Order>` | `200` with the inserted record |
| `POST` | `/api/Order/Update` | `CRUDModel<Order>` | `200` with the updated record |
| `POST` | `/api/Order/Delete` | `CRUDModel<Order>` | `204` with no body |

The API uses action-oriented routes because they match the UrlAdaptor's `InsertUrl`, `UpdateUrl`, and `RemoveUrl` contract.

For write requests, `action` identifies the operation, `keyColumn` names the primary-key field, `key` carries the value used by delete operations, and `value` carries the inserted or updated record. The Syncfusion model also supports `added`, `changed`, and `deleted` collections for batch editing, `params` for additional values, and `table` for an optional table name; this sample uses normal editing and does not consume those optional properties.

| Route | Failure response |
|---|---|
| `/api/Order` | `500` when the Realtime Database cannot be queried |
| `/api/Order/Insert` | `400` when the request is missing the order value; `500` on a Realtime Database failure |
| `/api/Order/Update` | `400` when required fields are missing or the `OrderID` is null; `500` on a Realtime Database failure |
| `/api/Order/Delete` | `400` when the key is not numeric; `404` when the key does not exist; `500` on a Realtime Database failure |

Example read response:

```json
{
  "result": [
    {
      "orderId": 1,
      "customerName": "John Smith",
      "employeeId": 101,
      "freight": 32.5,
      "shipCity": "New York"
    },
    {
      "orderId": 2,
      "customerName": "Toms",
      "employeeId": 102,
      "freight": 80.2,
      "shipCity": "London"
    },
    {
      "orderId": 3,
      "customerName": "Sven",
      "employeeId": 101,
      "freight": 52.1,
      "shipCity": "Berlin"
    },
    {
      "orderId": 4,
      "customerName": "Sara",
      "employeeId": 103,
      "freight": 18.4,
      "shipCity": "Madrid"
    },
    {
      "orderId": 5,
      "customerName": "Paul",
      "employeeId": 102,
      "freight": 64.75,
      "shipCity": "Tokyo"
    }
  ],
  "count": 5
}
```

Example insert request:

```json
{
  "action": "insert",
  "keyColumn": "orderId",
  "value": {
    "customerName": "Mei Chen",
    "employeeId": 104,
    "shipCity": "Sydney",
    "freight": 142.50
  }
}
```

The insert response returns the persisted record with the generated `orderId` populated.

Example update request:

```json
{
  "action": "update",
  "keyColumn": "orderId",
  "value": {
    "orderId": 3,
    "customerName": "Sven",
    "employeeId": 101,
    "shipCity": "Hamburg",
    "freight": 60.00
  }
}
```

Example delete request:

```json
{
  "action": "remove",
  "keyColumn": "orderId",
  "key": 5
}
```

## Run and Verify the Application

Build and run the project:

```powershell
dotnet build
dotnet run
```

Open the URL shown in the terminal. Verify the following:

1. The Pivot Table displays `CustomerName` as rows, `EmployeeID` as columns, and the sum of `Freight` as values.
2. The browser Network panel shows `POST /api/Order` returning `200` with `result` and `count`.
3. Double-click a value (summary) cell to open its raw-record editor.
4. Add a record and confirm that `POST /api/Order/Insert` returns the generated, nonzero `orderId`.
5. Edit and delete records, and confirm the corresponding API requests succeed with that key.
6. Open the Realtime Database **Data** tab in the Firebase console and confirm that the `Orders` node reflects the added, updated, and deleted records.

## Production Considerations

Firebase Realtime Database is a JSON tree database suitable for real-time JSON storage and small-to-medium workloads. Before using this design in production, consider the following:

- **Security rules:** Test mode opens the database for 30 days. Configure [Firebase Security Rules](https://firebase.google.com/docs/database/security) that allow only the operations your application requires before deploying.
- **Authentication and authorization:** This sample accesses the Realtime Database through anonymous REST requests that rely on test-mode rules. Production deployments should configure appropriate Firebase Realtime Database security rules, use a server-side authentication strategy appropriate for the application, protect the write endpoints with the application's authorization mechanism, and avoid exposing unrestricted write access.
- **Server-side data operations:** The sample returns the entire `Orders` node. Apply `DataManagerRequest` `where`, `sorted`, `skip`, and `take` parameters on the server before using this design with large datasets.
- **HTTP client lifetime:** The sample instantiates `HttpClient` per controller. For higher-throughput deployments, use `IHttpClientFactory` to avoid socket exhaustion and to centralize retry and timeout policies.
- **Database URL:** Store the Realtime Database URL through the hosting environment or a secrets manager rather than committing production URLs to source control.
- **Antiforgery:** If cookie-authenticated API actions require antiforgery validation, configure `SfDataManager` to send the request token expected by the server.
- **Region and latency:** Select a Realtime Database region close to your application host to reduce REST API latency.
- **Deployment:** For cross-origin hosting, configure an explicit CORS policy that allows only the Blazor application's origin.

## Troubleshooting

| Symptom | Resolution |
|---|---|
| **Configuration and routing** | |
| `Firebase Realtime Database URL is not configured.` | Add a `FirebaseSettings:DatabaseUrl` entry to `appsettings.json` and restart the application. |
| `405 Method Not Allowed` | Confirm `[HttpPost]`, `AddControllers()`, and `MapControllers()` are present. |
| UrlAdaptor request fails | Confirm `Home.razor` uses same-origin relative URLs (for example `/api/Order`) and that the Syncfusion stylesheet and script are registered in `App.razor`. |
| **Database and network connectivity** | |
| Unable to connect to Realtime Database | Verify the `DatabaseUrl` value matches the URL shown in the Firebase console **Data** tab, including the region segment, and confirm the application host has outbound HTTPS access to `*.firebasedatabase.app`. |
| Realtime Database permission denied | Verify the Firebase Realtime Database rules allow the requested operation, or test in development with test mode. |
| Browser reports mixed content or a redirect failure | Confirm `Home.razor` uses same-origin relative URLs rather than hard-coded HTTP URLs, and that `appsettings.json` uses an HTTPS Realtime Database URL. |
| Cross-origin request is blocked | Prefer same-origin relative URLs; otherwise configure `AddCors` and `UseCors` for the exact Blazor application origin. |
| **Data and CRUD operations** | |
| Pivot Table shows no data | Inspect `POST /api/Order` in the browser Network panel and check the server log. Confirm the `Orders` node exists in the Realtime Database. |
| CRUD returns `400` | Inspect the request JSON and confirm required fields are present, and that delete requests carry a numeric `key`. |
| CRUD returns `404` on delete | Confirm that the supplied `orderId` exists in the `Orders` node and that `OrderID` is marked as the primary key in the `BeginDrillThrough` event handler. |
| CRUD returns `500` | Check the server log and verify the Realtime Database URL and security rules. |
| JSON deserialization errors | Confirm the `Orders` node uses sequential numeric keys. The controller deserializes the REST response into `List<Order?>`; non-sequential or string keys require a different deserialization strategy. |
| **Auth, antiforgery, and performance** | |
| Antiforgery validation fails | Configure the adaptor to send the expected request token, or use an appropriate non-cookie API authentication scheme. |
| Large datasets are slow | Process `DataManagerRequest` operations on the server instead of returning the entire `Orders` node. |

For current component behavior, see the [Pivot Table editing documentation](https://blazor.syncfusion.com/documentation/pivot-table/editing) and [Pivot Table data-binding documentation](https://blazor.syncfusion.com/documentation/pivot-table/data-binding).

## Complete Sample Repository

A complete, working sample implementation is available in the [GitHub repository](https://github.com/SyncfusionExamples/syncfusion-blazor-pivot-table-firebase-realtime/tree/master).

## Summary

This guide demonstrated how to bind a Firebase Realtime Database to the Syncfusion Blazor Pivot Table through an ASP.NET Core API and the UrlAdaptor. The Realtime Database REST API exposes the `Orders` node as JSON, and `OrderController` performs read and CRUD operations against that node using `HttpClient`. `SfDataManager` resolves the same-origin relative API URLs through the UrlAdaptor. The Pivot Table displays `CustomerName` as rows, `EmployeeID` as columns, and the sum of `Freight` as values, with drill-through editing that inserts, updates, and deletes records that are persisted back to the Realtime Database.
