---
layout: post
title: Blazor Pivot Table Firebase Realtime Binding | Syncfusion®
description: Bind a Firebase Realtime Database to the Blazor Pivot Table through an ASP.NET Core API and the Syncfusion URL Adaptor.
platform: Blazor
control: PivotTable
documentation: ug
---

# Connect Firebase Realtime to Blazor Pivot Table

The [Blazor Pivot Table](https://www.syncfusion.com/blazor-components/blazor-pivot-table) can load and edit Firebase Realtime Database data through an ASP.NET Core API. [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) sends HTTP requests to the API, and the API uses the [Firebase Realtime Database REST API](https://firebase.google.com/docs/database/rest/save-data) to read and persist JSON records stored under an `Orders` node.

This guide uses same-origin relative API URLs. The sample read action returns the complete `Orders` node and does not apply `DataManagerRequest` operations. Add server-side filtering, sorting, and paging before using this design with large datasets.

## Prerequisites

The sample was tested with the following versions and configuration:

| Software or package | Version | Notes |
|---|---:|---|
| .NET SDK | 10.0 | Required to target `net10.0` |
| Visual Studio | 2026 18.0 or later | Required to target `net10.0`; install the ASP.NET and web development workload. VS Code and the .NET CLI are also supported |
| Firebase project | Active project | A Firebase project with Realtime Database enabled is required to host the data |
| Syncfusion.Blazor.PivotTable | 34.1.33 (31.2.10 or later) | [.NET 10 support starts with 31.2.10](https://blazor.syncfusion.com/documentation/common/how-to/version-compatibility); keep all Syncfusion packages on the same version |
| Syncfusion.Blazor.Themes | 34.1.33 (31.2.10 or later) | Provides the component theme |
| Newtonsoft.Json | 13.0.4 | Transitive dependency of the Syncfusion packages; the controller uses `System.Text.Json` for serialization |

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

Open the [Firebase Console](https://console.firebase.google.com/) and create a new project (for example, `pivottablerealtimedatabase`). Accept the default Google Analytics configuration or disable it; the Realtime Database does not require Analytics.

### Step 3: Create the Realtime Database

In the Firebase Console, navigate to **Build → Realtime Database** and click **Create Database**. Select **Start in test mode** so the REST API can read and write during development, and choose a region close to your users (for example, `asia-southeast1`).

> **Note:** Test mode opens read and write access to the database for 30 days. Configure [Firebase Security Rules](https://firebase.google.com/docs/database/security) before deploying the application.

After the database is provisioned, copy the database URL from the **Data** tab. This URL is required in `appsettings.json` later in this guide.

### Step 4: Create the Orders Node and Import Sample Data

The Realtime Database stores data as a hierarchical JSON tree. Each order is stored as a child of a root node keyed by its `orderId`.

Create a root node named:

```text
Orders
```

Use the Firebase console **Import JSON** panel to import the following sample data into the `Orders` node:

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

### Step 5: Install the Required NuGet Packages

Run these commands in the `PivotTableRealtimeDatabase` project directory:

```powershell
dotnet add package Syncfusion.Blazor.PivotTable --version 34.1.33
dotnet add package Syncfusion.Blazor.Themes --version 34.1.33
dotnet add package Newtonsoft.Json --version 13.0.4
```

The project file should contain:

```xml
<ItemGroup>
  <PackageReference Include="Newtonsoft.Json" Version="13.0.4" />
  <PackageReference Include="Syncfusion.Blazor.PivotTable" Version="34.1.33" />
  <PackageReference Include="Syncfusion.Blazor.Themes" Version="34.1.33" />
</ItemGroup>
```

The sample accesses the Realtime Database directly through the REST API using `HttpClient`, so no Firebase client SDK package is required.

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

> **Note:** Replace `<YOUR_FIREBASE_REALTIME_DATABASE_URL>` with the Realtime Database URL copied from the Firebase Console **Data** tab (for example, `https://<project-id>-default-rtdb.<region>.firebasedatabase.app`). A relative URL is not supported here because the URL points to the Firebase host, not the application host.

### Step 7: Create the API Controller

Create a `Controllers` folder at the project root, and then create `Controllers/OrderController.cs`. In this sample, the `Order` model and the `CRUDModel<T>` wrapper are defined inside `OrderController.cs` rather than in a separate file. The same `Order` shape is also declared in the Pivot Table page (`Home.razor`) so the component can strongly type its data source. Keeping the model close to the code that uses it makes the contract between the controller and the page easy to follow.

The controller reads the `FirebaseSettings:DatabaseUrl` configuration value and uses a single `HttpClient` instance to call the Realtime Database REST API. Before showing the full file, here is a summary of what each endpoint does:

| Endpoint | HTTP verb | Firebase REST call | Action |
|---|---|---|---|
| `Post` | `POST /api/Order` | `GET {databaseUrl}/Orders.json` | Returns the entire `Orders` node as `{ result, count }`. The `DataManagerRequest` is intentionally ignored. |
| `Insert` | `POST /api/Order/Insert` | `PUT {databaseUrl}/Orders/{nextOrderId}.json` | Computes the next `orderId` from the existing node, writes the new record, and returns it with the generated key. |
| `Update` | `POST /api/Order/Update` | `PUT {databaseUrl}/Orders/{OrderID}.json` | Replaces the node at the supplied key path with the incoming record. |
| `Delete` | `POST /api/Order/Delete` | `DELETE {databaseUrl}/Orders/{orderId}.json` | Removes the node at the supplied key path. |

The complete `OrderController.cs` is shown below:

```csharp
using System.ComponentModel.DataAnnotations;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;

namespace PivotTableRealtimeDatabase.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly HttpClient httpClient;
        private readonly string databaseUrl;

        public OrderController(IConfiguration configuration)
        {
            databaseUrl =
                configuration["FirebaseSettings:DatabaseUrl"]
                ?? throw new InvalidOperationException(
                    "Firebase Realtime Database URL is not configured.");

            httpClient = new HttpClient();
        }

        [HttpPost]
        public async Task<object> Post([FromBody] DataManagerRequest request)
        {
            _ = request;

            string url = $"{databaseUrl}/Orders.json";

            string json = await httpClient.GetStringAsync(url);

            List<Order?>? firebaseData =
                JsonSerializer.Deserialize<List<Order?>>(json);

            List<Order> orders =
                firebaseData?
                    .Where(x => x != null)
                    .Cast<Order>()
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

            string url = $"{databaseUrl}/Orders.json";

            string json = await httpClient.GetStringAsync(url);

            List<Order?>? firebaseData =
                JsonSerializer.Deserialize<List<Order?>>(json);

            int nextOrderId =
                firebaseData?
                    .Where(x => x != null)
                    .Max(x => x!.OrderID ?? 0) + 1
                ?? 1;

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
            if (value.Value is not Order order || !order.OrderID.HasValue)
            {
                return BadRequest();
            }

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

            HttpResponseMessage response = await httpClient.DeleteAsync(
                $"{databaseUrl}/Orders/{orderId}.json");

            return response.IsSuccessStatusCode ? NoContent() : NotFound();
        }

        public class Order
        {
            [Key]
            [JsonPropertyName("orderId")]
            public int? OrderID { get; set; }

            [JsonPropertyName("customerName")]
            public string? CustomerName { get; set; }

            [JsonPropertyName("employeeId")]
            public int? EmployeeID { get; set; }

            [JsonPropertyName("freight")]
            public double? Freight { get; set; }

            [JsonPropertyName("shipCity")]
            public string? ShipCity { get; set; }
        }

        public class CRUDModel<T> where T : class
        {
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
}
```

The controller exposes the read, insert, update, and delete endpoints described in the [API Contract](#api-contract). The exception middleware configured in the next step logs unhandled failures and returns generic problem responses without exposing Firebase URLs or request details.

#### Read Operation

The `Post` action calls the Realtime Database REST endpoint `GET {databaseUrl}/Orders.json`, which returns the entire `Orders` node as JSON. Because the sample uses numeric keys under the `Orders` node, the controller deserializes the REST response into `List<Order?>` so that any missing index positions (for example, a missing `0` entry) are represented as `null` and filtered out before the result is ordered by `OrderID` and returned as `{ result, count }`. The Pivot Table URL Adaptor calls this `Post` action to perform the read and bind the Pivot Table.

> The URL Adaptor sends a `DataManagerRequest` object, but the sample intentionally discards it (`_ = request;`) and returns the complete `Orders` collection. The Pivot Table performs aggregation and client-side processing after the data is loaded.

#### Insert Operation

The `Insert` action reads the existing `Orders` node to compute the next `orderId`, serializes the incoming record, and writes it to `{databaseUrl}/Orders/{nextOrderId}.json` using a `PUT` request. Because `PUT` overwrites the node at the specified key path, each insertion targets `{databaseUrl}/Orders/{orderId}.json`, and the controller returns the inserted record with the generated `OrderID` populated.

#### Update Operation

The `Update` action serializes the incoming record and performs a `PUT` request to `{databaseUrl}/Orders/{OrderID}.json`, replacing the existing node. `PUT` writes the entire object at the supplied key path, so the controller requires a non-null `OrderID` to target the correct node and returns the updated record on a successful response.

#### Delete Operation

The `Delete` action parses the numeric key from the URL Adaptor request and performs a `DELETE` request to `{databaseUrl}/Orders/{orderId}.json`, removing the matching node. It returns `204 No Content` on success or `404 Not Found` when the key does not exist.

#### Order Model and CRUDModel

The `Order` model maps .NET properties to Realtime Database JSON fields through `[JsonPropertyName]` attributes, and `OrderID` carries `[Key]` so the Pivot Table can identify the primary key for update and delete requests. `Freight` is declared as `double?` to match the Realtime Database JSON values.

The `CRUDModel<T>` wrapper carries the URL Adaptor `action`, `keyColumn`, `key`, and `value` fields the controller uses for write operations, together with the optional `added`, `changed`, `deleted`, and `params` collections supported by the Syncfusion model. This sample uses normal editing and does not consume those optional properties.

### Step 8: Configure Program.cs

Replace `Program.cs` with:

```csharp
using PivotTableRealtimeDatabase.Components;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Register the Syncfusion license before builder.Build().
// Syncfusion packages require a valid license or trial key.
// Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(
//     "YOUR LICENSE KEY");

builder.Services.AddSyncfusionBlazor();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddControllers();
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
- `AddProblemDetails()` and `UseExceptionHandler()` log unhandled failures and return generic error responses.
- `MapControllers()` routes requests to the API endpoints.
- `MapStaticAssets()` maps the application's static web assets, including assets supplied by referenced component packages.

> **Note:** Remove the comment markers and fill in your Syncfusion license or trial key in `Program.cs` before running the application. Follow the [license-key registration instructions](https://blazor.syncfusion.com/documentation/getting-started/license-key/how-to-register-in-an-application) for details.

### Step 9: Configure the Pivot Table

Add these namespaces to `Components/_Imports.razor`:

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.PivotView
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
    private void BeginDrillThrough(BeginDrillThroughEventArgs args)
    {
        // Identify the key used by URL Adaptor update and delete requests.
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

    public class Order
    {
        public int? OrderID { get; set; }
        public string? CustomerName { get; set; }
        public int? EmployeeID { get; set; }
        public double? Freight { get; set; }
        public string? ShipCity { get; set; }
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

The API uses action-oriented routes because they match the URL Adaptor's `InsertUrl`, `UpdateUrl`, and `RemoveUrl` contract.

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
6. Open the Realtime Database **Data** tab in the Firebase Console and confirm that the `Orders` node reflects the added, updated, and deleted records.

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
| Unable to connect to Realtime Database | Verify the `DatabaseUrl` value matches the URL shown in the Firebase Console **Data** tab, including the region segment, and confirm the application host has outbound HTTPS access to `*.firebasedatabase.app`. |
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

This guide demonstrated how to bind a Firebase Realtime Database to the Syncfusion Blazor Pivot Table through an ASP.NET Core API and the URL Adaptor. The Realtime Database REST API exposes the `Orders` node as JSON, and `OrderController` performs read and CRUD operations against that node using `HttpClient`. `SfDataManager` resolves the same-origin relative API URLs through the URL Adaptor. The Pivot Table displays `CustomerName` as rows, `EmployeeID` as columns, and the sum of `Freight` as values, with drill-through editing that inserts, updates, and deletes records that are persisted back to the Realtime Database.
