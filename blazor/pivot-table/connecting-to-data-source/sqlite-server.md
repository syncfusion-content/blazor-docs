---
layout: post
title: SQLite in Blazor Pivot Table | Syncfusion
description: Learn how to load and edit SQLite data in the Blazor Pivot Table through an ASP.NET Core API that uses Microsoft.Data.Sqlite and the Syncfusion URL adaptor.
platform: Blazor
control: PivotTable
documentation: ug
---

# SQLite in Blazor Pivot Table

The [Blazor Pivot Table](https://www.syncfusion.com/blazor-components/blazor-pivot-table) can load and edit SQLite data through an ASP.NET Core API. [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) sends HTTP requests to the API, and the API uses [`Microsoft.Data.Sqlite`](https://www.nuget.org/packages/Microsoft.Data.Sqlite/) to access the SQLite database.

This guide uses same-origin relative API URLs. The sample read action returns the complete `Orders` table and does not apply `DataManagerRequest` operations. Add server-side filtering, sorting, and paging before using this design with large datasets.

## Prerequisites

The sample was tested with the following versions and configuration:

| Software or package | Version | Notes |
|---|---:|---|
| .NET SDK | 10.0 | Required to target `net10.0` |
| Visual Studio | 2026 18.0 or later | Required to target `net10.0`; install the ASP.NET and web development workload. VS Code and the .NET CLI are also supported |
| SQLite tools | 3.x or later | The `sqlite3` command-line shell or a GUI tool is needed to create and inspect the database; `Microsoft.Data.Sqlite` supplies the runtime provider and native engine |
| Syncfusion.Blazor.PivotTable | `{{site.blazorversion}}` (31.2.10 or later) | [.NET 10 support starts with 31.2.10](https://blazor.syncfusion.com/documentation/common/how-to/version-compatibility); keep all Syncfusion packages on the same version |
| Syncfusion.Blazor.Themes | `{{site.blazorversion}}` (31.2.10 or later) | Provides the component theme |
| Microsoft.Data.Sqlite | 10.0.10 | SQLite ADO.NET provider aligned with .NET 10 |

The application uses the Blazor Web App template with Interactive Server rendering. Syncfusion packages from NuGet.org require a valid license or trial key; follow the [license-key registration instructions](https://blazor.syncfusion.com/documentation/getting-started/license-key/how-to-register-in-an-application).

## SQLite Database Setup and Application Configuration

### Step 1: Create the Blazor Web App

Create an Interactive Server Blazor Web App:

```powershell
dotnet new blazor -n PivotTableSQLite -f net10.0 -int Server -ai
cd PivotTableSQLite
```

In Visual Studio, the equivalent choices are **Blazor Web App**, **.NET 10**, **Interactive render mode: Server**, and **Interactivity location: Global**.

### Step 2: Create the SQLite Database

SQLite stores an entire database in a single file, so there is no server to install or configure. Download the SQLite tools from the [SQLite download page](https://www.sqlite.org/download.html) and use either the `sqlite3` command-line shell or a GUI client such as DB Browser for SQLite.

Create the database file `Orders.db` and open it:

```powershell
sqlite3 Orders.db
```

Run the following script to create the `Orders` table and seed it with sample rows:

```sql
CREATE TABLE IF NOT EXISTS Orders
(
    OrderID      INTEGER PRIMARY KEY AUTOINCREMENT,
    CustomerName TEXT    NOT NULL,
    EmployeeID   INTEGER NOT NULL,
    ShipCity     TEXT    NULL,
    Freight      REAL    NULL
);

INSERT INTO Orders (CustomerName, EmployeeID, ShipCity, Freight)
SELECT * FROM (VALUES
    ('Toms', 1, 'New York', 35.30),
    ('Ravi', 2, 'London',   80.20),
    ('Sven', 1, 'Berlin',   52.10),
    ('Sara', 3, 'Madrid',   18.40),
    ('Paul', 2, 'Tokyo',    64.75)
) AS seed
WHERE NOT EXISTS (SELECT 1 FROM Orders);
```

Verify the inserted data:

```sql
SELECT OrderID, CustomerName, EmployeeID, ShipCity, Freight
FROM Orders
ORDER BY OrderID;

.quit
```

Expected output:

| OrderID | CustomerName | EmployeeID | ShipCity  | Freight |
|---:|---|---:|---|---:|
| 1 | Toms | 1 | New York | 35.30 |
| 2 | Ravi | 2 | London  | 80.20 |
| 3 | Sven | 1 | Berlin  | 52.10 |
| 4 | Sara | 3 | Madrid  | 18.40 |
| 5 | Paul | 2 | Tokyo   | 64.75 |

Copy the generated `Orders.db` file to a location the ASP.NET Core application can read, and use that path in the connection string configured in the next steps.

### Step 3: Install the Required NuGet Packages

Run these commands in the `PivotTableSQLite` project directory:

```powershell
dotnet add package Syncfusion.Blazor.PivotTable --version {{site.blazorversion}}
dotnet add package Syncfusion.Blazor.Themes --version {{site.blazorversion}}
dotnet add package Microsoft.Data.Sqlite --version 10.0.10
```

The project file should contain:

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.Data.Sqlite" Version="10.0.10" />
  <PackageReference Include="Syncfusion.Blazor.PivotTable" Version="{{site.blazorversion}}" />
  <PackageReference Include="Syncfusion.Blazor.Themes" Version="{{site.blazorversion}}" />
</ItemGroup>
```

### Step 4: Configure the Connection String

Store the SQLite connection string in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "SQLite": "Data Source=<DATABASE_FILE_NAME>"
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

> **Note:** Replace `<DATABASE_FILE_NAME>` with the actual SQLite database file name or the full path to the database file used in your environment. For example, `Data Source=Orders.db` for a file in the application working directory, or `Data Source=C:/Data/Orders.db` for an absolute path.

A relative `Data Source` path is resolved from the application's process working directory. Use an absolute path in deployments where the working directory can differ from the project directory.

### Step 5: Create the API Controller

Create a `Controllers` folder at the project root, and then create `Controllers/OrderController.cs`. In this sample, the `Order` model and the `CRUDModel<T>` wrapper are defined inside `OrderController.cs` rather than in a separate file. The same `Order` shape is also declared in the Pivot Table page (`Home.razor`) so the component can strongly type its data source. Keeping the model close to the code that uses it makes the contract between the controller and the page easy to follow.

```csharp
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.Sqlite;
using Syncfusion.Blazor.Data;
using Syncfusion.Blazor;

namespace PivotTableSQLite.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly string connectionString;

        public OrderController(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("SQLite")
                ?? throw new InvalidOperationException(
                    "The SQLite connection string is not configured.");
        }

        [HttpPost]
        public object Post([FromBody] DataManagerRequest request)
        {
            _ = request;

            List<Order> dataSource = GetOrderData();

            return new
            {
                result = dataSource,
                count = dataSource.Count
            };
        }

        private List<Order> GetOrderData()
        {
            List<Order> orders = new();

            const string query =
                @"SELECT
                    OrderID,
                    CustomerName,
                    EmployeeID,
                    Freight,
                    ShipCity
                  FROM Orders
                  ORDER BY OrderID";

            using SqliteConnection connection = new(connectionString);
            connection.Open();

            using SqliteCommand command = new(query, connection);
            using SqliteDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                orders.Add(new Order
                {
                    OrderID = reader.IsDBNull(0) ? null : reader.GetInt32(0),
                    CustomerName = reader.IsDBNull(1) ? null : reader.GetString(1),
                    EmployeeID = reader.IsDBNull(2) ? null : reader.GetInt32(2),
                    Freight = reader.IsDBNull(3) ? null : Convert.ToDecimal(reader.GetDouble(3)),
                    ShipCity = reader.IsDBNull(4) ? null : reader.GetString(4)
                });
            }

            return orders;
        }

        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] CRUDModel<Order> value)
        {
            if (value.Value is not Order order
                || string.IsNullOrWhiteSpace(order.CustomerName)
                || !order.EmployeeID.HasValue)
            {
                return BadRequest(
                    "CustomerName and EmployeeID are required.");
            }

            const string query =
                @"INSERT INTO Orders
                    (CustomerName, EmployeeID, Freight, ShipCity)
                  VALUES
                    (@CustomerName, @EmployeeID, @Freight, @ShipCity)";

            using SqliteConnection connection = new(connectionString);
            connection.Open();

            using SqliteCommand command = new(query, connection);

            command.Parameters.AddWithValue(
                "@CustomerName",
                order.CustomerName);

            command.Parameters.AddWithValue(
                "@EmployeeID",
                order.EmployeeID.Value);

            command.Parameters.AddWithValue(
                "@Freight",
                order.Freight.HasValue
                    ? order.Freight.Value
                    : DBNull.Value);

            command.Parameters.AddWithValue(
                "@ShipCity",
                order.ShipCity ?? (object)DBNull.Value);

            command.ExecuteNonQuery();

            using SqliteCommand keyCommand = new(
                "SELECT last_insert_rowid();",
                connection);

            order.OrderID = Convert.ToInt32(keyCommand.ExecuteScalar());

            return Ok(order);
        }

        [HttpPost("Update")]
        public IActionResult Update([FromBody] CRUDModel<Order> value)
        {
            if (value.Value is not Order order
                || !order.OrderID.HasValue
                || string.IsNullOrWhiteSpace(order.CustomerName)
                || !order.EmployeeID.HasValue)
            {
                return BadRequest(
                    "OrderID, CustomerName and EmployeeID are required.");
            }

            const string query =
                @"UPDATE Orders
                  SET CustomerName = @CustomerName,
                      EmployeeID = @EmployeeID,
                      Freight = @Freight,
                      ShipCity = @ShipCity
                  WHERE OrderID = @OrderID";

            using SqliteConnection connection = new(connectionString);
            connection.Open();

            using SqliteCommand command = new(query, connection);

            command.Parameters.AddWithValue(
                "@CustomerName",
                order.CustomerName);

            command.Parameters.AddWithValue(
                "@EmployeeID",
                order.EmployeeID.Value);

            command.Parameters.AddWithValue(
                "@Freight",
                order.Freight.HasValue
                    ? order.Freight.Value
                    : DBNull.Value);

            command.Parameters.AddWithValue(
                "@ShipCity",
                order.ShipCity ?? (object)DBNull.Value);

            command.Parameters.AddWithValue(
                "@OrderID",
                order.OrderID.Value);

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected == 0
                ? NotFound()
                : Ok(order);
        }

        [HttpPost("Delete")]
        public IActionResult Delete([FromBody] CRUDModel<Order> value)
        {
            if (!int.TryParse(value.Key?.ToString(), out int orderId))
            {
                return BadRequest(
                    "A numeric order key is required.");
            }

            const string query =
                @"DELETE FROM Orders
                  WHERE OrderID = @OrderID";

            using SqliteConnection connection = new(connectionString);
            connection.Open();

            using SqliteCommand command = new(query, connection);

            command.Parameters.AddWithValue(
                "@OrderID",
                orderId);

            int rowsAffected = command.ExecuteNonQuery();

            return rowsAffected == 0
                ? NotFound()
                : NoContent();
        }

        public class Order
        {
            [Key]
            public int? OrderID { get; set; }

            public string? CustomerName { get; set; }

            public int? EmployeeID { get; set; }

            public decimal? Freight { get; set; }

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

The controller exposes the read, insert, update, and delete endpoints described in the [API Contract](#api-contract). The exception middleware configured in the next step logs unhandled `SqliteException` instances and returns generic problem responses without exposing database paths or SQL details.

### Step 6: Configure Program.cs

Replace `Program.cs` with:

```csharp
using PivotTableSQLite.Components;
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

### Step 7: Configure the Pivot Table

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
    <link rel="stylesheet" href="@Assets["PivotTableSQLite.styles.css"]" />
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
        public decimal? Freight { get; set; }
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
| `/api/Order` | `500` when the database cannot be queried |
| `/api/Order/Insert` | `400` when required fields are missing; `500` on a database failure |
| `/api/Order/Update` | `400` when required fields are missing; `404` when the key does not exist; `500` on a database failure |
| `/api/Order/Delete` | `400` when the key is not numeric; `404` when the key does not exist; `500` on a database failure |

Example read response:

```json
{
  "result": [
    {
      "orderID": 1,
      "customerName": "Toms",
      "employeeID": 1,
      "freight": 35.30,
      "shipCity": "New York"
    },
    {
      "orderID": 2,
      "customerName": "Ravi",
      "employeeID": 2,
      "freight": 80.20,
      "shipCity": "London"
    },
    {
      "orderID": 3,
      "customerName": "Sven",
      "employeeID": 1,
      "freight": 52.10,
      "shipCity": "Berlin"
    },
    {
      "orderID": 4,
      "customerName": "Sara",
      "employeeID": 3,
      "freight": 18.40,
      "shipCity": "Madrid"
    },
    {
      "orderID": 5,
      "customerName": "Paul",
      "employeeID": 2,
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
  "keyColumn": "orderID",
  "value": {
    "customerName": "Mei Chen",
    "employeeID": 4,
    "shipCity": "Sydney",
    "freight": 142.50
  }
}
```

The insert response returns the persisted record with the generated `orderID` populated.

Example update request:

```json
{
  "action": "update",
  "keyColumn": "orderID",
  "value": {
    "orderID": 3,
    "customerName": "Sven",
    "employeeID": 1,
    "shipCity": "Hamburg",
    "freight": 60.00
  }
}
```

Example delete request:

```json
{
  "action": "remove",
  "keyColumn": "orderID",
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
4. Add a record and confirm that `POST /api/Order/Insert` returns the generated, nonzero `orderID`.
5. Edit and delete records, and confirm the corresponding API requests succeed with that key.
6. Query the `Orders` table (using your SQLite client) to confirm the changes were persisted locally. For deployed apps with no direct database access, re-open the drill-through editor and confirm that the rows reflect the changes.

## Production Considerations

SQLite is ideal for local development, embedded scenarios, and small-to-medium workloads. Before using this design in production, consider the following:

- **Concurrency:** SQLite allows multiple readers but serializes writers. For write-heavy workloads, switch to a client-server database such as SQL Server or PostgreSQL.
- **Server-side data operations:** The sample returns the entire `Orders` table. Apply `DataManagerRequest` `where`, `sorted`, `skip`, and `take` parameters on the server before using this design with large datasets.
- **Connection string:** Store the connection string through the hosting environment or a secrets manager rather than committing production paths to source control.
- **File location:** Place the database file on durable storage with appropriate backup and recovery procedures. SQLite keeps the entire database in a single file.
- **Authentication and authorization:** Protect the write endpoints with the authentication and authorization mechanism used by your application.
- **Antiforgery:** If cookie-authenticated API actions require antiforgery validation, configure `SfDataManager` to send the request token expected by the server.
- **WAL mode:** For better concurrent read/write performance, consider enabling Write-Ahead Logging (`PRAGMA journal_mode=WAL;`) on the database.
- **Deployment:** For cross-origin hosting, configure an explicit CORS policy that allows only the Blazor application's origin.

## Troubleshooting

| Symptom | Resolution |
|---|---|
| Pivot Table shows no data | Inspect `POST /api/Order` in the browser Network panel and check the server log. A `GET` request from the browser address bar returns `405`. |
| `405 Method Not Allowed` | Confirm `[HttpPost]`, `AddControllers()`, and `MapControllers()` are present. |
| `No such table: Orders` | Create the `Orders` table in the database file pointed to by the connection string and confirm the connection string selects that file. |
| `The SQLite connection string is not configured.` | Add a `ConnectionStrings:SQLite` entry to `appsettings.json` and restart the application. |
| `Unable to open database file` | Confirm the database file path is valid and that the application process has read/write permission on the file and its folder. |
| The database file is locked | Ensure no other process holds an exclusive lock, and consider enabling WAL mode for concurrent access. |
| CRUD returns `400` | Inspect the request JSON and confirm required fields (`CustomerName`, `EmployeeID`) and a numeric key are present. |
| CRUD returns `404` | Confirm that the supplied `OrderID` exists and that `OrderID` is marked as the primary key in the `BeginDrillThrough` event handler. |
| CRUD returns `500` | Check the server log and verify the table schema, connection string, and file permissions. |
| Browser reports mixed content or a redirect failure | Confirm `Home.razor` uses same-origin relative URLs (for example `/api/Order`) rather than hard-coded HTTP URLs. |
| Cross-origin request is blocked | Prefer same-origin relative URLs; otherwise configure `AddCors` and `UseCors` for the exact Blazor application origin. |
| Antiforgery validation fails | Configure the adaptor to send the expected request token, or use an appropriate non-cookie API authentication scheme. |
| Large datasets are slow | Process `DataManagerRequest` operations on the server instead of returning the entire table. |

For current component behavior, see the [Pivot Table editing documentation](https://blazor.syncfusion.com/documentation/pivot-table/editing) and [Pivot Table data-binding documentation](https://blazor.syncfusion.com/documentation/pivot-table/data-binding).

## Complete Sample Repository

A complete, working sample implementation is available in the [GitHub repository](https://github.com/SyncfusionExamples/syncfusion-blazor-pivot-table-sqlite-database-binding-sample/tree/master).
