---
layout: post
title: Blazor Pivot Table with SQL Server via URL Adaptor | Syncfusion®
description: Bind Microsoft SQL Server data to the Blazor Pivot Table through an ASP.NET Core API and the Syncfusion URL Adaptor.
platform: Blazor
control: PivotTable
documentation: ug
---

# Connect SQL Server to a Blazor Pivot Table Using the URL Adaptor

The [Blazor Pivot Table](https://www.syncfusion.com/blazor-components/blazor-pivot-table) can load and edit SQL Server data through an ASP.NET Core API. [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) sends HTTP requests to the API, and the API uses [`Microsoft.Data.SqlClient`](https://www.nuget.org/packages/Microsoft.Data.SqlClient/) to access SQL Server.

This guide uses same-origin relative API URLs. The sample read action returns the complete `Orders` table and does not apply `DataManagerRequest` operations. Add server-side filtering, sorting, and paging before using this design with large datasets.

## Prerequisites

The sample was tested with the following versions and configuration:

| Software or package | Version | Notes |
|---|---:|---|
| .NET SDK | 10.0 | Required to target `net10.0` |
| Visual Studio | 2022 17.14 or later | Install the ASP.NET and web development workload; VS Code and the .NET CLI are also supported |
| SQL Server | 2019 or later | LocalDB, Express, Developer, and supported remote editions can be used |
| SQL Server Management Studio | Current release | Optional; another SQL client can run the scripts |
| Syncfusion.Blazor.PivotTable | `{{site.blazorversion}}` | Keep all Syncfusion packages on the same version |
| Syncfusion.Blazor.Themes | `{{site.blazorversion}}` | Provides the component theme |
| Microsoft.Data.SqlClient | 6.1.1 | SQL Server ADO.NET provider |

The application uses the Blazor Web App template with Interactive Server rendering. Syncfusion packages from NuGet.org require a valid license or trial key; follow the [license-key registration instructions](https://blazor.syncfusion.com/documentation/getting-started/license-key/how-to-register-in-an-application).

## Microsoft SQL Server Database Setup and Application Configuration

### Step 1: Create the Blazor Web App

Create an Interactive Server Blazor Web App:

```powershell
dotnet new blazor -n PivotTableMsSQL -f net10.0 -int Server
cd PivotTableMsSQL
```

In Visual Studio, the equivalent choices are **Blazor Web App**, **.NET 10**, **Interactive render mode: Server**, and **Interactivity location: Global**.

### Step 2: Create the Database

Start SQL Server and connect with an account that can create a database. Run:

```sql
IF DB_ID(N'OrderDB') IS NULL
BEGIN
    CREATE DATABASE OrderDB;
END;
GO

USE OrderDB;
GO

IF OBJECT_ID(N'dbo.Orders', N'U') IS NULL
BEGIN
    CREATE TABLE dbo.Orders
    (
        OrderID      INT IDENTITY(1, 1) NOT NULL
            CONSTRAINT PK_Orders PRIMARY KEY,
        CustomerName VARCHAR(100) NOT NULL,
        EmployeeID   INT NOT NULL,
        ShipCity     VARCHAR(100) NULL,
        Freight      DECIMAL(10, 2) NULL
    );
END;
GO

IF NOT EXISTS (SELECT 1 FROM dbo.Orders)
BEGIN
    INSERT INTO dbo.Orders (CustomerName, EmployeeID, ShipCity, Freight)
    VALUES
        ('Toms', 1, 'New York', 35.30),
        ('Ravi', 2, 'London', 80.20),
        ('Sven', 1, 'Berlin', 52.10),
        ('Sara', 3, 'Madrid', 18.40),
        ('Paul', 2, 'Tokyo', 64.75);
END;
GO

SELECT OrderID, CustomerName, EmployeeID, ShipCity, Freight
FROM dbo.Orders
ORDER BY OrderID;
GO
```

The application login needs `SELECT`, `INSERT`, `UPDATE`, and `DELETE` permission on `dbo.Orders`. For example, after creating or selecting an appropriate database user:

```sql
USE OrderDB;
GO
GRANT SELECT, INSERT, UPDATE, DELETE ON dbo.Orders TO [YourDatabaseUser];
GO
```

Use an account appropriate for your environment. Do not use a highly privileged login such as `sa` for the application.

### Step 3: Install the Packages

Run these commands in the `PivotTableMsSQL` project directory:

```powershell
dotnet add package Syncfusion.Blazor.PivotTable --version {{site.blazorversion}}
dotnet add package Syncfusion.Blazor.Themes --version {{site.blazorversion}}
dotnet add package Microsoft.Data.SqlClient --version 6.1.1
```

The project file should contain:

```xml
<ItemGroup>
  <PackageReference Include="Microsoft.Data.SqlClient" Version="6.1.1" />
  <PackageReference Include="Syncfusion.Blazor.PivotTable" Version="{{site.blazorversion}}" />
  <PackageReference Include="Syncfusion.Blazor.Themes" Version="{{site.blazorversion}}" />
</ItemGroup>
```

### Step 4: Configure the Connection String

For local development, store the connection string with .NET user secrets:

```powershell
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:SQLServer" "Server=localhost;Database=OrderDB;Integrated Security=True;TrustServerCertificate=True;"
```

Common local alternatives are:

```text
# LocalDB
Server=(localdb)\MSSQLLocalDB;Database=OrderDB;Integrated Security=True;TrustServerCertificate=True;

# SQL Server Express
Server=.\SQLEXPRESS;Database=OrderDB;Integrated Security=True;TrustServerCertificate=True;

# SQL Server authentication
Server=localhost;Database=OrderDB;User Id=YOUR_USER;Password=YOUR_PASSWORD;TrustServerCertificate=True;
```

`TrustServerCertificate=True` is suitable for local development with an untrusted development certificate. Use a trusted server certificate in production. For deployment, provide `ConnectionStrings__SQLServer` through the hosting environment or a secrets manager rather than committing credentials to source control.

### Step 5: Create the API Controller

Create a `Controllers` folder at the project root, and then create `Controllers/OrderController.cs`:

```csharp
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;

namespace PivotTableMsSQL.Controllers;

[ApiController]
[Route("api/[controller]")]
public sealed class OrderController : ControllerBase
{
    private readonly string connectionString;
    private readonly ILogger<OrderController> logger;

    public OrderController(
        IConfiguration configuration,
        ILogger<OrderController> logger)
    {
        connectionString = configuration.GetConnectionString("SQLServer")
            ?? throw new InvalidOperationException(
                "ConnectionStrings:SQLServer is not configured.");
        this.logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Read(
        [FromBody] DataManagerRequest request,
        CancellationToken cancellationToken)
    {
        _ = request;

        try
        {
            List<Order> orders = await GetOrdersAsync(cancellationToken);
            return Ok(new { result = orders, count = orders.Count });
        }
        catch (SqlException exception)
        {
            logger.LogError(exception, "Unable to read orders.");
            return Problem(
                title: "The order data could not be read.",
                statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost("Insert")]
    public async Task<IActionResult> Insert(
        [FromBody] CrudModel<Order> request,
        CancellationToken cancellationToken)
    {
        Order? order = request.Value;
        if (order is null || order.EmployeeID <= 0
            || string.IsNullOrWhiteSpace(order.CustomerName))
        {
            return BadRequest("CustomerName and EmployeeID are required.");
        }

        const string sql = """
            INSERT INTO dbo.Orders
                (CustomerName, EmployeeID, ShipCity, Freight)
            OUTPUT INSERTED.OrderID
            VALUES
                (@CustomerName, @EmployeeID, @ShipCity, @Freight);
            """;

        try
        {
            await using SqlConnection connection = new(connectionString);
            await connection.OpenAsync(cancellationToken);
            await using SqlCommand command = new(sql, connection);
            AddOrderParameters(command, order);

            object? result = await command.ExecuteScalarAsync(cancellationToken);
            order.OrderID = Convert.ToInt32(result);
            return Ok(order);
        }
        catch (SqlException exception)
        {
            logger.LogError(exception, "Unable to insert an order.");
            return Problem(
                title: "The order could not be inserted.",
                statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost("Update")]
    public async Task<IActionResult> Update(
        [FromBody] CrudModel<Order> request,
        CancellationToken cancellationToken)
    {
        Order? order = request.Value;
        if (order is null || order.OrderID <= 0 || order.EmployeeID <= 0
            || string.IsNullOrWhiteSpace(order.CustomerName))
        {
            return BadRequest(
                "OrderID, CustomerName, and EmployeeID are required.");
        }

        const string sql = """
            UPDATE dbo.Orders
            SET CustomerName = @CustomerName,
                EmployeeID = @EmployeeID,
                ShipCity = @ShipCity,
                Freight = @Freight
            WHERE OrderID = @OrderID;
            """;

        try
        {
            await using SqlConnection connection = new(connectionString);
            await connection.OpenAsync(cancellationToken);
            await using SqlCommand command = new(sql, connection);
            AddOrderParameters(command, order);
            command.Parameters.Add("@OrderID", System.Data.SqlDbType.Int).Value =
                order.OrderID;

            int affected = await command.ExecuteNonQueryAsync(cancellationToken);
            return affected == 0 ? NotFound() : Ok(order);
        }
        catch (SqlException exception)
        {
            logger.LogError(exception, "Unable to update order {OrderID}.", order.OrderID);
            return Problem(
                title: "The order could not be updated.",
                statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost("Delete")]
    public async Task<IActionResult> Delete(
        [FromBody] CrudModel<Order> request,
        CancellationToken cancellationToken)
    {
        if (!int.TryParse(request.Key?.ToString(), out int orderID)
            || orderID <= 0)
        {
            return BadRequest("A numeric order key is required.");
        }

        const string sql =
            "DELETE FROM dbo.Orders WHERE OrderID = @OrderID;";

        try
        {
            await using SqlConnection connection = new(connectionString);
            await connection.OpenAsync(cancellationToken);
            await using SqlCommand command = new(sql, connection);
            command.Parameters.Add("@OrderID", System.Data.SqlDbType.Int).Value =
                orderID;

            int affected = await command.ExecuteNonQueryAsync(cancellationToken);
            return affected == 0 ? NotFound() : NoContent();
        }
        catch (SqlException exception)
        {
            logger.LogError(exception, "Unable to delete order {OrderID}.", orderID);
            return Problem(
                title: "The order could not be deleted.",
                statusCode: StatusCodes.Status500InternalServerError);
        }
    }

    private async Task<List<Order>> GetOrdersAsync(
        CancellationToken cancellationToken)
    {
        const string sql = """
            SELECT OrderID, CustomerName, EmployeeID, ShipCity, Freight
            FROM dbo.Orders
            ORDER BY OrderID;
            """;

        List<Order> orders = [];
        await using SqlConnection connection = new(connectionString);
        await connection.OpenAsync(cancellationToken);
        await using SqlCommand command = new(sql, connection);
        await using SqlDataReader reader =
            await command.ExecuteReaderAsync(cancellationToken);

        int orderID = reader.GetOrdinal("OrderID");
        int customerName = reader.GetOrdinal("CustomerName");
        int employeeID = reader.GetOrdinal("EmployeeID");
        int shipCity = reader.GetOrdinal("ShipCity");
        int freight = reader.GetOrdinal("Freight");

        while (await reader.ReadAsync(cancellationToken))
        {
            orders.Add(new Order
            {
                OrderID = reader.GetInt32(orderID),
                CustomerName = reader.GetString(customerName),
                EmployeeID = reader.GetInt32(employeeID),
                ShipCity = reader.IsDBNull(shipCity)
                    ? null
                    : reader.GetString(shipCity),
                Freight = reader.IsDBNull(freight)
                    ? null
                    : reader.GetDecimal(freight)
            });
        }

        return orders;
    }

    private static void AddOrderParameters(
        SqlCommand command,
        Order order)
    {
        command.Parameters
            .Add("@CustomerName", System.Data.SqlDbType.VarChar, 100)
            .Value = order.CustomerName;
        command.Parameters
            .Add("@EmployeeID", System.Data.SqlDbType.Int)
            .Value = order.EmployeeID;
        command.Parameters
            .Add("@ShipCity", System.Data.SqlDbType.VarChar, 100)
            .Value = (object?)order.ShipCity ?? DBNull.Value;

        SqlParameter freight = command.Parameters.Add(
            "@Freight",
            System.Data.SqlDbType.Decimal);
        freight.Precision = 10;
        freight.Scale = 2;
        freight.Value = (object?)order.Freight ?? DBNull.Value;
    }

    public sealed class Order
    {
        [Key]
        public int OrderID { get; set; }

        [Required]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        public int EmployeeID { get; set; }

        public string? ShipCity { get; set; }

        public decimal? Freight { get; set; }
    }

    public sealed class CrudModel<T> where T : class
    {
        public string? Action { get; set; }
        public string? KeyColumn { get; set; }
        public object? Key { get; set; }
        public T? Value { get; set; }
        public List<T>? Added { get; set; }
        public List<T>? Changed { get; set; }
        public List<T>? Deleted { get; set; }
        public IDictionary<string, object>? Params { get; set; }
    }
}
```

`DataManagerRequest` is accepted to satisfy the URL Adaptor read contract, but this sample intentionally returns all rows. The write actions use explicit SQL parameter types, return the generated identity after insert, log SQL failures, and return `400`, `404`, or `500` responses when appropriate.

The `Added`, `Changed`, and `Deleted` collections support batch requests; `Params` carries custom adaptor parameters. This sample uses Normal edit mode and therefore handles the single-record `Value` and `Key` properties.

### Step 6: Register Services and Endpoints

Replace `Program.cs` with:

```csharp
using PivotTableMsSQL.Components;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSyncfusionBlazor();
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddControllers();

// Register the Syncfusion license before builder.Build().
// Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense(
//     "YOUR LICENSE KEY");

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();
app.MapStaticAssets();
app.MapControllers();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
```

The API is same-origin, so CORS configuration is not required. If the API is later hosted on another origin, configure an explicit CORS policy that allows only the Blazor application's origin.

Protect the write endpoints with the authentication and authorization mechanism used by your application before production deployment. If cookie-authenticated API actions require antiforgery validation, configure `SfDataManager` to send the request token expected by the server.

### Step 7: Add Imports and Theme Resources

Add these namespaces to `Components/_Imports.razor`:

```cshtml
@using System.ComponentModel.DataAnnotations
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

Do not add a second `_framework/blazor.web.js` reference if the template already contains one.

### Step 8: Configure the Pivot Table

Replace `Components/Pages/Home.razor` with:

```cshtml
@page "/"

<SfPivotView TValue="Order"
             Width="1000"
             Height="300"
             ShowFieldList="true">
    <PivotViewDataSourceSettings TValue="Order"
                                 ExpandAll="false"
                                 EnableSorting="true">
        <SfDataManager Url="/api/Order"
                       InsertUrl="/api/Order/Insert"
                       UpdateUrl="/api/Order/Update"
                       RemoveUrl="/api/Order/Delete"
                       Adaptor="Adaptors.UrlAdaptor" />
        <PivotViewColumns>
            <PivotViewColumn Name="EmployeeID" />
        </PivotViewColumns>
        <PivotViewRows>
            <PivotViewRow Name="CustomerName" />
        </PivotViewRows>
        <PivotViewValues>
            <PivotViewValue Name="Freight" Caption="Freight" />
        </PivotViewValues>
    </PivotViewDataSourceSettings>
    <PivotViewGridSettings ColumnWidth="120" />
    <PivotViewCellEditSettings AllowEditing="true"
                               AllowAdding="true"
                               AllowDeleting="true"
                               Mode="EditMode.Normal" />
</SfPivotView>

@code {
    public sealed class Order
    {
        [Key]
        public int OrderID { get; set; }

        [Required]
        public string CustomerName { get; set; } = string.Empty;

        [Required]
        public int EmployeeID { get; set; }

        public string? ShipCity { get; set; }

        public decimal? Freight { get; set; }
    }
}
```

The `[Key]` attribute identifies `OrderID` as the record key. Do not configure the key through `BeginDrillThroughEventArgs.GridObj`; current Syncfusion Pivot Table versions return `GridObj` as `null` in that event.

The relative URLs follow the active scheme, host, port, and path base, avoiding hard-coded development ports and HTTP-to-HTTPS mixed-content failures.

### Step 9: Run and Verify the Application

Restore, build, and run the project:

```powershell
dotnet restore
dotnet build
dotnet run
```

Open the URL shown in the terminal. Verify the following:

1. The Pivot Table displays `CustomerName` as rows, `EmployeeID` as columns, and the sum of `Freight` as values.
2. The browser Network panel shows `POST /api/Order` returning `200` with `result` and `count`.
3. Double-click a value cell to open its raw-record editor.
4. Add, edit, and delete a record, and confirm the corresponding API request succeeds.
5. Query `dbo.Orders` to confirm the change was persisted.

Example read response:

```json
{
  "result": [
    {
      "orderID": 1,
      "customerName": "Toms",
      "employeeID": 1,
      "shipCity": "New York",
      "freight": 35.30
    }
  ],
  "count": 1
}
```

Example insert request:

```json
{
  "action": "insert",
  "keyColumn": "orderID",
  "value": {
    "customerName": "Karen Lee",
    "employeeID": 3,
    "shipCity": "Berlin",
    "freight": 110.00
  }
}
```

Example update request:

```json
{
  "action": "update",
  "keyColumn": "orderID",
  "value": {
    "orderID": 1,
    "customerName": "Toms",
    "employeeID": 1,
    "shipCity": "Boston",
    "freight": 40.00
  }
}
```

Example delete request:

```json
{
  "action": "remove",
  "keyColumn": "orderID",
  "key": 1
}
```

![Blazor Pivot Table](../images/blazor-pivot-table-MSSQL.webp)

## API Reference

| Method | Route | Payload | Success response |
|---|---|---|---|
| `POST` | `/api/Order` | `DataManagerRequest` | `200` with `{ result, count }` |
| `POST` | `/api/Order/Insert` | `CrudModel<Order>` | `200` with the inserted record and generated `OrderID` |
| `POST` | `/api/Order/Update` | `CrudModel<Order>` | `200` with the updated record |
| `POST` | `/api/Order/Delete` | `CrudModel<Order>` | `204` with no body |

The API uses action-oriented routes because they match the URL Adaptor's `InsertUrl`, `UpdateUrl`, and `RemoveUrl` contract.

## Troubleshooting

| Symptom | Resolution |
|---|---|
| Pivot Table shows no data | Inspect `POST /api/Order` in the browser Network panel and check the server log. Navigating to the URL with an address-bar `GET` returns `405`. |
| `405 Method Not Allowed` | Confirm `[HttpPost]`, `AddControllers()`, and `MapControllers()` are present. |
| SQL connection or login failure | Confirm that SQL Server is running, the connection string is correct, and the login is mapped to an `OrderDB` user with the required table permissions. |
| `Invalid object name 'dbo.Orders'` | Run the database script against `OrderDB` and confirm the connection string selects that database. |
| Certificate-chain error | Use `TrustServerCertificate=True` only for local development, or install a trusted SQL Server certificate. |
| CRUD returns `400` | Inspect the request JSON and confirm required fields and the numeric key are present. |
| CRUD returns `404` | Confirm that the supplied `OrderID` exists and that `OrderID` is marked with `[Key]` in the component model. |
| CRUD returns `500` | Check the structured server log and verify the table schema, connection string, and database permissions. |
| Browser reports mixed content or a redirect failure | Confirm `Home.razor` uses relative `/api/Order` URLs rather than hard-coded HTTP URLs. |
| Cross-origin request is blocked | Prefer same-origin relative URLs; otherwise configure `AddCors` and `UseCors` for the exact Blazor application origin. |
| Antiforgery validation fails | Configure the adaptor to send the expected request token, or use an appropriate non-cookie API authentication scheme. |
| Large datasets are slow | Process `DataManagerRequest` operations on the server instead of returning the entire table. |

For current component behavior, see the [Pivot Table editing documentation](https://blazor.syncfusion.com/documentation/pivot-table/editing) and [Pivot Table data-binding documentation](https://blazor.syncfusion.com/documentation/pivot-table/data-binding).

## Complete Sample Repository

A complete, working sample implementation is available in the [GitHub repository](https://github.com/SyncfusionExamples/syncfusion-blazor-pivot-table-mssql-database-binding-sample).
