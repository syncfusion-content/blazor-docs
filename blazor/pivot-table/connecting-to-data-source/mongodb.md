---
layout: post
title: Blazor Pivot Table with MongoDB via URL Adaptor | Syncfusion®
description: Bind a MongoDB database to the Blazor Pivot Table through an ASP.NET Core API and the Syncfusion URL Adaptor.
platform: Blazor
control: PivotTable
documentation: ug
---

# Connect MongoDB to a Blazor Pivot Table Using the URL Adaptor

The [Blazor Pivot Table](https://www.syncfusion.com/blazor-components/blazor-pivot-table) can load and edit MongoDB data through an ASP.NET Core API. [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) sends HTTP requests to the API, and the API uses [`MongoDB.Driver`](https://www.nuget.org/packages/MongoDB.Driver/) to access the MongoDB database.

This guide uses same-origin relative API URLs. The sample read action returns the complete `Orders` collection and does not apply `DataManagerRequest` operations. Add server-side filtering, sorting, and paging before using this design with large datasets.

## Prerequisites

The sample was tested with the following versions and configuration:

| Software or package | Version | Notes |
|---|---:|---|
| .NET SDK | 10.0 | Required to target `net10.0` |
| Visual Studio | 2026 18.0 or later | Required to target `net10.0`; install the ASP.NET and web development workload. VS Code and the .NET CLI are also supported |
| MongoDB Community Server | 8.0 or later | The MongoDB daemon (`mongod`) supplies the document database runtime; install it as a service or run it manually |
| MongoDB Compass | Latest | The official MongoDB GUI used to create, inspect, and import data into collections |
| Syncfusion.Blazor.PivotTable | 34.1.33 | [.NET 10 support starts with 31.2.10](https://blazor.syncfusion.com/documentation/common/how-to/version-compatibility); keep all Syncfusion packages on the same version |
| Syncfusion.Blazor.Themes | 34.1.33 | Provides the component theme |
| MongoDB.Driver | 3.10.0 | Official MongoDB C# driver used by the API to read and write documents |

The application uses the Blazor Web App template with Interactive Server rendering. Syncfusion packages from NuGet.org require a valid license or trial key; follow the [license-key registration instructions](https://blazor.syncfusion.com/documentation/getting-started/license-key/how-to-register-in-an-application).

## MongoDB Architecture

The data flows through the following layers:

```text
Blazor Pivot Table
        ↓
   SfDataManager
        ↓
    UrlAdaptor
        ↓
  OrderController
        ↓
   MongoDB.Driver
        ↓
      MongoDB → OrderDB (database) → Orders (collection)
```

The Blazor Pivot Table renders aggregated data and issues read and write requests through `SfDataManager`. The `UrlAdaptor` serializes those requests as HTTP `POST` calls to the `OrderController` API. The controller uses `MongoDB.Driver` to run find, insert, update, and delete operations against the `OrderDB` database and its `Orders` collection, and returns JSON responses that the adaptor understands.

## MongoDB Database Setup

### Step 1: Install MongoDB Community Server

Download MongoDB Community Server from the [MongoDB download page](https://www.mongodb.com/try/download/community) and install it for your platform. On Windows, accept the option to run MongoDB as a service so that the daemon (`mongod`) starts automatically and listens on the default port `27017`.

Verify the server is running. If the MongoDB installer did not add the `bin` folder to your `PATH` (it usually does not on Windows), run the command from the installation directory, for example `C:\Program Files\MongoDB\Server\8.0\bin`:

```powershell
mongod --version
```

> **Tip:** To run `mongod` from any directory, add `C:\Program Files\MongoDB\Server\8.0\bin` to your system `PATH` and restart the terminal.

Confirm the service is listening:

```powershell
Get-Service MongoDB
```

### Step 2: Install MongoDB Compass

Download MongoDB Compass from the [MongoDB Compass download page](https://www.mongodb.com/try/download/compass) and install it. Compass is the official MongoDB GUI used to browse databases, inspect collections, and import documents.

### Step 3: Connect to MongoDB

Open MongoDB Compass and connect to the local server using the default connection string:

```text
mongodb://localhost:27017
```

> **Note:** If you enabled authentication during installation, use a connection string that includes the database, username, and password, for example `mongodb://username:password@localhost:27017/?authSource=admin`.

### Step 4: Create the Database and Collection

In MongoDB Compass:

1. Click **Create Database**.
2. Enter the database name `OrderDB`.
3. Enter the collection name `Orders`.
4. Click **Create Database**.

You can also create the database and collection from the `mongosh` shell:

```javascript
use OrderDB
db.createCollection("Orders")
```

### Step 5: Import Sample Order Documents

Each document in the `Orders` collection represents a single order. Import the following sample documents into the `Orders` collection through MongoDB Compass (**Add Data > Import JSON File**) or `mongosh`:

```javascript
db.Orders.insertMany([
    { orderId: 1, customerName: "Toms",    employeeId: 1, freight: 35.30, shipCity: "New York" },
    { orderId: 2, customerName: "Ravi",    employeeId: 2, freight: 80.20, shipCity: "London"   },
    { orderId: 3, customerName: "Sven",    employeeId: 1, freight: 52.10, shipCity: "Berlin"   },
    { orderId: 4, customerName: "Sara",    employeeId: 3, freight: 18.40, shipCity: "Madrid"   },
    { orderId: 5, customerName: "Paul",    employeeId: 2, freight: 64.75, shipCity: "Tokyo"    }
])
```

### Step 6: Verify the Data

In MongoDB Compass, select the `OrderDB` database and the `Orders` collection. The documents should appear as:

| _id (ObjectId) | orderId | customerName | employeeId | freight | shipCity |
|---|---:|---|---:|---:|---|
| (auto) | 1 | Toms | 1 | 35.30 | New York |
| (auto) | 2 | Ravi | 2 | 80.20 | London |
| (auto) | 3 | Sven | 1 | 52.10 | Berlin |
| (auto) | 4 | Sara | 3 | 18.40 | Madrid |
| (auto) | 5 | Paul | 2 | 64.75 | Tokyo |

> **Note:** MongoDB automatically generates a unique `_id` (ObjectId) for each document when one is not supplied. The application maps `_id` to the `Id` property of the `Order` model, and uses the business key `orderId` for update and delete operations.

## Create the Blazor Web App

Create an Interactive Server Blazor Web App.

```powershell
dotnet new blazor -n PivotTableMongoDB -f net10.0 -i Server -ai
cd PivotTableMongoDB
```

In Visual Studio, the equivalent choices are **Blazor Web App**, **.NET 10**, **Interactive render mode: Server**, and **Interactivity location: Global**.

## Install the Required NuGet Packages

Run these commands in the `PivotTableMongoDB` project directory.

```powershell
dotnet add package Syncfusion.Blazor.PivotTable --version 34.1.33
dotnet add package Syncfusion.Blazor.Themes --version 34.1.33
dotnet add package MongoDB.Driver --version 3.10.0
```

> **Note:** The Syncfusion Blazor packages 34.1.33 are published to the public NuGet.org feed. If your environment only resolves a private NuGet source, add the Syncfusion feed or set the `nuget.org` source (`https://api.nuget.org/v3/index.json`) as a package source before running the commands above. Restore packages after adding them so the project references resolve:

```powershell
dotnet restore
```

The project file should contain:

```xml
<ItemGroup>
  <PackageReference Include="Syncfusion.Blazor.PivotTable" Version="34.1.33" />
  <PackageReference Include="Syncfusion.Blazor.Themes" Version="34.1.33" />
  <PackageReference Include="MongoDB.Driver" Version="3.10.0" />
</ItemGroup>
```

## Configure the Connection String

Store the MongoDB connection string and the database and collection names in `appsettings.json`:

```json
{
  "ConnectionStrings": {
    "MongoDB": "mongodb://localhost:27017"
  },
  "MongoDbSettings": {
    "DatabaseName": "OrderDB",
    "CollectionName": "Orders"
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

> **Note:** Use `mongodb://localhost:27017` for a local MongoDB server without authentication. For a remote or secured MongoDB instance, replace the connection string with the appropriate URI, for example `mongodb+srv://<user>:<password>@cluster0.example.net/?retryWrites=true&w=majority`. Keep production connection strings out of source control through user secrets or environment variables.

To override the connection string for local development without committing it to source, add an `appsettings.Development.json` file (already git-ignored by the Blazor template) or use the user-secrets store:

```powershell
dotnet user-secrets init
dotnet user-secrets set "ConnectionStrings:MongoDB" "mongodb://localhost:27017"
```

`appsettings.Development.json`:

```json
{
  "ConnectionStrings": {
    "MongoDB": "mongodb://localhost:27017"
  }
}
```

A `MongoDbSettings:DatabaseName` value of `OrderDB` and a `MongoDbSettings:CollectionName` value of `Orders` must match the database and collection created in [Step 4](#step-4-create-the-database-and-collection).

## Create the API Controller

Create a `Controllers` folder at the project root, and then create `Controllers/OrderController.cs`. In this sample, the `Order` model and the `CRUDModel<T>` wrapper are defined inside `OrderController.cs` rather than in a separate file. The same `Order` shape is also declared in the Pivot Table page (`Home.razor`) so the component can strongly type its data source. Defining the model alongside the code that consumes it keeps the contract between the controller and the page clear.

```csharp
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;

namespace PivotTableMongoDB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrderController : ControllerBase
    {
        private readonly IMongoCollection<Order> ordersCollection;

        public OrderController(IConfiguration configuration)
        {
            string connectionString =
                configuration.GetConnectionString("MongoDB")
                ?? throw new InvalidOperationException(
                    "The MongoDB connection string is not configured.");

            string databaseName =
                configuration["MongoDbSettings:DatabaseName"]
                ?? "OrderDB";

            string collectionName =
                configuration["MongoDbSettings:CollectionName"]
                ?? "Orders";

            MongoClient client = new(connectionString);
            IMongoDatabase database = client.GetDatabase(databaseName);

            ordersCollection =
                database.GetCollection<Order>(collectionName);
        }

        [HttpPost]
        public object Post([FromBody] DataManagerRequest request)
        {
            _ = request;

            List<Order> dataSource = ordersCollection
                .Find(_ => true)
                .SortBy(x => x.OrderID)
                .ToList();

            return new
            {
                result = dataSource,
                count = dataSource.Count
            };
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

            Order? lastRecord = ordersCollection
                .Find(_ => true)
                .SortByDescending(x => x.OrderID)
                .FirstOrDefault();

            order.OrderID = lastRecord?.OrderID + 1 ?? 1;

            ordersCollection.InsertOne(order);

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

            UpdateDefinition<Order> update =
                Builders<Order>.Update
                    .Set(x => x.CustomerName, order.CustomerName)
                    .Set(x => x.EmployeeID, order.EmployeeID)
                    .Set(x => x.Freight, order.Freight)
                    .Set(x => x.ShipCity, order.ShipCity);

            UpdateResult result =
                ordersCollection.UpdateOne(
                    x => x.OrderID == order.OrderID,
                    update);

            return result.MatchedCount == 0
                ? NotFound()
                : Ok(order);
        }

        [HttpPost("Delete")]
        public IActionResult Delete([FromBody] CRUDModel<Order> value)
        {
            if (!int.TryParse(
                value.Key?.ToString(),
                out int orderId))
            {
                return ValidationProblem(
                    "A numeric order key is required.");
            }

            DeleteResult result =
                ordersCollection.DeleteOne(
                    x => x.OrderID == orderId);

            return result.DeletedCount == 0
                ? NotFound()
                : NoContent();
        }

        public class Order
        {
            [BsonId]
            [BsonRepresentation(BsonType.ObjectId)]
            public string? Id { get; set; }

            [BsonElement("orderId")]
            public int? OrderID { get; set; }

            [BsonElement("customerName")]
            public string? CustomerName { get; set; }

            [BsonElement("employeeId")]
            public int? EmployeeID { get; set; }

            [BsonElement("freight")]
            public double? Freight { get; set; }

            [BsonElement("shipCity")]
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

The controller exposes the read, insert, update, and delete endpoints described in the [API Contract](#api-contract). The `OrderController` constructor resolves the MongoDB connection string, database name, and collection name from configuration, creates a `MongoClient`, and caches the `IMongoCollection<Order>` used by every action. The exception middleware configured in [Configure Program.cs](#configure-programcs) returns generic problem responses without exposing connection strings or driver details.

## Configure Program.cs

Replace `Program.cs` with:

```csharp
using PivotTableMongoDB.Components;
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
    app.UseExceptionHandler();
    app.UseHsts();
}
else
{
    // The developer exception page shows stack traces during local development.
    app.UseDeveloperExceptionPage();
}

app.UseExceptionHandler();

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapControllers();

app.MapStaticAssets();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
```

Key registration points:

- `AddSyncfusionBlazor()` registers the Syncfusion Blazor services required by the Pivot Table.
- `AddRazorComponents().AddInteractiveServerComponents()` enables Interactive Server rendering.
- `AddControllers()` registers the API controllers, including `OrderController`.
- `AddProblemDetails()` and `UseExceptionHandler()` log unhandled failures and return generic `ProblemDetails` error responses.
- `UseAntiforgery()` is registered before `MapControllers()` so the antiforgery middleware is in the pipeline for any endpoint that opts into validation. The sample API actions do not require it, but ordering it correctly now avoids surprises if you later add cookie authentication.
- `MapControllers()` routes requests to the API endpoints.
- `MapStaticAssets()` maps the application's static web assets, including assets supplied by referenced component packages.

> **Note:** Remove the comment markers and fill in your Syncfusion license or trial key in `Program.cs` before running the application. Follow the [license-key registration instructions](https://blazor.syncfusion.com/documentation/getting-started/license-key/how-to-register-in-an-application) for details.

## Configure the Pivot Table

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

Add the Syncfusion script immediately before `</body>`, after the template's existing `_framework/blazor.web.js` reference.

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
    <link rel="stylesheet" href="@Assets["PivotTableMongoDB.styles.css"]" />
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
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.PivotView

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

The `BeginDrillThrough` event is used to mark `OrderID` as the primary key on the drill-through grid. This tells the DataManager which column uniquely identifies each record so that insert, update, and delete requests carry the correct key. Without this configuration, the write operations cannot target the intended document.

> **Note:** The `Order` class declared in `Home.razor` mirrors the shape sent by the API, but it does not include the MongoDB `_id` field. The Pivot Table only needs the business fields for aggregation and editing; MongoDB's internal `_id` is preserved on the server and never modified by the controller.

## MongoDB Document Structure

Each row in the Pivot Table corresponds to one document in the `Orders` collection. A sample document (matching the records imported in [Step 5](#step-5-import-sample-order-documents)) looks like:

```json
{
  "_id": "65a1f2c3b7d8e9f0a1b2c3d4",
  "orderId": 1,
  "customerName": "Toms",
  "employeeId": 1,
  "freight": 35.30,
  "shipCity": "New York"
}
```

| Field | Type | Description |
|---|---|---|
| `_id` | ObjectId | MongoDB-generated unique identifier for each document. Mapped to `Order.Id` with `[BsonId]` and `[BsonRepresentation(BsonType.ObjectId)]`; never edited by the Pivot Table. |
| `orderId` | Integer | Business key used by the read, insert, update, and delete operations. Auto-incremented on insert from the highest existing `orderId`; mapped to `Order.OrderID` with `[BsonElement("orderId")]`. |
| `customerName` | String | Name of the customer; required for insert and update; mapped to `Order.CustomerName` with `[BsonElement("customerName")]`. |
| `employeeId` | Integer | Identifier of the employee who placed the order; required for insert and update; mapped to `Order.EmployeeID` with `[BsonElement("employeeId")]`. |
| `freight` | Double | Shipping cost aggregated by the Pivot Table; mapped to `Order.Freight` with `[BsonElement("freight")]`. |
| `shipCity` | String | Destination city; mapped to `Order.ShipCity` with `[BsonElement("shipCity")]`. |

> **Note:** The `[BsonElement]` attributes control the field names written to MongoDB. The `[BsonId]` and `[BsonRepresentation]` attributes tell the driver that `Id` is the document primary key and should be stored as an `ObjectId`. Mismatched element names are the most common cause of empty Pivot Tables, so keep the attribute names in sync with the fields imported in [Step 5](#step-5-import-sample-order-documents).

## CRUD Operations

The action methods below are defined in the `OrderController` class shown in [Create the API Controller](#create-the-api-controller). Each subsection reproduces a single method and explains how it implements the corresponding read, insert, update, or delete operation.

### Read

The read operation returns every document in the `Orders` collection to the Pivot Table:

```csharp
[HttpPost]
public object Post([FromBody] DataManagerRequest request)
{
    _ = request;

    List<Order> dataSource = ordersCollection
        .Find(_ => true)
        .SortBy(x => x.OrderID)
        .ToList();

    return new
    {
        result = dataSource,
        count = dataSource.Count
    };
}
```

How it works:

- `ordersCollection` resolves to the `OrderDB.Orders` collection configured in the constructor.
- `Find(_ => true)` matches all documents in the collection.
- `SortBy(x => x.OrderID)` orders the results by `orderId` so rows appear in a stable order in the drill-through grid.
- The action wraps the documents in a `{ result, count }` envelope that the UrlAdaptor expects.

### Insert

The insert operation creates a new document and assigns the next available `orderId`:

```csharp
[HttpPost("Insert")]
public IActionResult Insert([FromBody] CRUDModel<Order> value)
{
    if (value.Value is not Order order
        || string.IsNullOrWhiteSpace(order.CustomerName)
        || !order.EmployeeID.HasValue)
    {
        return ValidationProblem(
            "CustomerName and EmployeeID are required.");
    }

    Order? lastRecord = ordersCollection
        .Find(_ => true)
        .SortByDescending(x => x.OrderID)
        .FirstOrDefault();

    order.OrderID = lastRecord?.OrderID + 1 ?? 1;

    ordersCollection.InsertOne(order);

    return Ok(order);
}
```

How it works:

- The action validates that `CustomerName` and `EmployeeID` are present before writing.
- It locates the document with the highest `orderId` and computes the next value as `lastRecord.OrderID + 1`, or `1` when the collection is empty. MongoDB does not provide an auto-incrementing integer field, so the controller generates the business key.
- `InsertOne` writes the new document. MongoDB assigns the `_id` automatically because none is supplied.
- The inserted `Order` (with the generated `OrderID`) is returned so the Pivot Table can update its local copy.

### Update

The update operation modifies an existing document by `orderId` while preserving the MongoDB `_id`:

```csharp
[HttpPost("Update")]
public IActionResult Update([FromBody] CRUDModel<Order> value)
{
    if (value.Value is not Order order
        || !order.OrderID.HasValue
        || string.IsNullOrWhiteSpace(order.CustomerName)
        || !order.EmployeeID.HasValue)
    {
        return ValidationProblem(
            "OrderID, CustomerName and EmployeeID are required.");
    }

    UpdateDefinition<Order> update =
        Builders<Order>.Update
            .Set(x => x.CustomerName, order.CustomerName)
            .Set(x => x.EmployeeID, order.EmployeeID)
            .Set(x => x.Freight, order.Freight)
            .Set(x => x.ShipCity, order.ShipCity);

    UpdateResult result =
        ordersCollection.UpdateOne(
            x => x.OrderID == order.OrderID,
            update);

    return result.MatchedCount == 0
        ? NotFound()
        : Ok(order);
}
```

How it works:

- The filter `x => x.OrderID == order.OrderID` locates the document by business key. Using `UpdateOne` instead of replacing the document keeps the original `_id` and any other unedited fields intact.
- `Builders<Order>.Update.Set` builds an update definition that changes only the editable fields.
- When no document matches the supplied `orderId`, the action returns `404` so the Pivot Table can surface the failure.

### Delete

The delete operation removes a document by `orderId`:

```csharp
[HttpPost("Delete")]
public IActionResult Delete([FromBody] CRUDModel<Order> value)
{
    if (!int.TryParse(
        value.Key?.ToString(),
        out int orderId))
    {
        return ValidationProblem(
            "A numeric order key is required.");
    }

    DeleteResult result =
        ordersCollection.DeleteOne(
            x => x.OrderID == orderId);

    return result.DeletedCount == 0
        ? NotFound()
        : NoContent();
}
```

How it works:

- The UrlAdaptor sends the primary key in the `key` property. The action parses it as an integer before querying.
- `DeleteOne` removes the matching document. The action returns `204` on success and `404` when no document matches the key.

## API Contract

| Method | Route | Payload | Success response | Failure response |
|---|---|---|---|---|
| `POST` | `/api/Order` | `DataManagerRequest` | `200` with `{ result, count }` | `500` when the database cannot be queried |
| `POST` | `/api/Order/Insert` | `CRUDModel<Order>` | `200` with the inserted record | `400` when required fields are missing; `500` on a database failure |
| `POST` | `/api/Order/Update` | `CRUDModel<Order>` | `200` with the updated record | `400` when required fields are missing; `404` when the key does not exist; `500` on a database failure |
| `POST` | `/api/Order/Delete` | `CRUDModel<Order>` | `204` with no body | `400` when the key is not numeric; `404` when the key does not exist; `500` on a database failure |

The API uses action-oriented routes because they match the URL Adaptor's `InsertUrl`, `UpdateUrl`, and `RemoveUrl` contract.

For write requests, `action` identifies the operation, `keyColumn` names the primary-key field, `key` carries the value used by delete operations, and `value` carries the inserted or updated record. The local `CRUDModel<T>` class also exposes `added`, `changed`, and `deleted` collections (used by the URL Adaptor in batch edit mode) and `params` for additional values. This sample uses normal editing and does not consume those optional properties.

Example read response:

```json
{
  "result": [
    {
      "id": "65a1f2c3b7d8e9f0a1b2c3d4",
      "orderID": 1,
      "customerName": "Toms",
      "employeeID": 1,
      "freight": 35.30,
      "shipCity": "New York"
    },
    {
      "id": "65a1f2c3b7d8e9f0a1b2c3d5",
      "orderID": 2,
      "customerName": "Ravi",
      "employeeID": 2,
      "freight": 80.20,
      "shipCity": "London"
    },
    {
      "id": "65a1f2c3b7d8e9f0a1b2c3d6",
      "orderID": 3,
      "customerName": "Sven",
      "employeeID": 1,
      "freight": 52.10,
      "shipCity": "Berlin"
    },
    {
      "id": "65a1f2c3b7d8e9f0a1b2c3d7",
      "orderID": 4,
      "customerName": "Sara",
      "employeeID": 3,
      "freight": 18.40,
      "shipCity": "Madrid"
    },
    {
      "id": "65a1f2c3b7d8e9f0a1b2c3d8",
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

> **Note:** The JSON payloads below use camelCase property names (`orderID`, `customerName`, `employeeID`, `freight`, `shipCity`) because the URL Adaptor serializes fields from the grid's camelCase wire format and the API deserializes them into the PascalCase C# properties of `Order` (`OrderID`, `CustomerName`, `EmployeeID`, `Freight`, `ShipCity`) through System.Text.Json's default case-insensitive binding. The `keyColumn` value (`orderID`) must match the field name the grid sends — the one you marked as `IsPrimaryKey` in the `BeginDrillThrough` handler — and not the C# property name.

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

The insert response returns the persisted record with the generated `orderID` and the MongoDB-assigned `id` populated.

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

After editing `Program.cs`, `Home.razor`, and `App.razor`, restore dependencies and build the project. Ensure the Syncfusion license or trial key has been registered in `Program.cs` (see [Configure Program.cs](#configure-programcs)) before building; an unregistered key does not fail the build, but the component will render a license warning at runtime.

```powershell
dotnet restore
dotnet build
dotnet run
```

Before launching the app, confirm the MongoDB service is reachable. The `OrderController` constructor opens the collection eagerly and will throw on the first request if MongoDB is not listening on `27017`:

```powershell
Get-Service MongoDB   # should report Status: Running
```

Open the URL shown in the terminal. Verify the following:

1. The Pivot Table displays `CustomerName` as rows, `EmployeeID` as columns, and the sum of `Freight` as values.
2. The browser Network panel shows `POST /api/Order` returning `200` with `result` and `count`.
3. Double-click a value (summary) cell to open its raw-record editor.
4. Add a record and confirm that `POST /api/Order/Insert` returns the generated, nonzero `orderID`.
5. Edit and delete records, and confirm the corresponding API requests succeed with that key.
6. Inspect the `Orders` collection in MongoDB Compass to confirm the changes were persisted. For deployed apps with no direct database access, re-open the drill-through editor and confirm that the rows reflect the changes.

## Production Considerations

MongoDB is ideal for document-oriented workloads and scales horizontally through sharding. Before using this design in production, consider the following:

- **Concurrency:** MongoDB supports concurrent readers and writers. For write-heavy workloads, prefer `UpdateOne` over `ReplaceOne` (whole-document replacement), and index the `orderId` field used by update and delete filters.
- **Server-side data operations:** The sample returns the entire `Orders` collection. Apply `DataManagerRequest` `where`, `sorted`, `skip`, and `take` parameters on the server before using this design with large datasets.
- **Connection string:** Store the MongoDB connection string through the hosting environment or a secrets manager rather than committing production URIs to source control.
- **Authentication and authorization:** Configure MongoDB authentication and protect the write endpoints with the authentication and authorization mechanism used by your application.
- **Antiforgery:** If cookie-authenticated API actions require antiforgery validation, configure `SfDataManager` to send the request token expected by the server. Add a custom header name in `Program.cs` and read it inside the action filter:

```csharp
builder.Services.AddAntiforgery(o => o.HeaderName = "X-CSRF-TOKEN");
```

Then configure the data manager to send the same header by adding a custom adaptor option (the default `UrlAdaptor` does not forward antiforgery tokens; a small custom adaptor is the cleanest way). For non-cookie authentication (bearer tokens, API keys) skip this step entirely.
- **Reverse proxy / load balancer:** When the app runs behind IIS, Nginx, or a cloud load balancer, the forwarded scheme and host are not visible to the app, and `UseHttpsRedirection` will redirect to the wrong port. Insert `app.UseForwardedHeaders()` immediately after `app.Build()` (and before the exception handler) and configure the forwarded headers options to trust the proxy range.
- **Schema validation:** Enforce a [JSON schema validator](https://www.mongodb.com/docs/manual/core/schema-validation/) on the `Orders` collection so that inserted and updated documents always match the `Order` model.
- **Deployment:** For cross-origin hosting, configure an explicit CORS policy that allows only the Blazor application's origin.
- **Atomic auto-increment:** The sample computes `orderId` from the highest existing value. For high-throughput inserts, switch to a dedicated `counters` collection with `FindOneAndUpdate` to assign `orderId` atomically.

## Troubleshooting

| Symptom | Resolution |
|---|---|
| MongoDB service is not running | Start the MongoDB service (`Start-Service MongoDB` on Windows, or run `mongod` manually) and confirm it is listening on `27017`. |
| MongoDB Compass connection failure | Confirm the connection string matches `mongodb://localhost:27017`. If authentication is enabled, include credentials and `authSource` in the URI. |
| Database not found | Create the `OrderDB` database (see [Step 4](#step-4-create-the-database-and-collection)) and confirm `MongoDbSettings:DatabaseName` matches. MongoDB creates a database lazily, but the sample read returns an empty result set until documents are inserted. |
| Collection not found | Create the `Orders` collection and confirm `MongoDbSettings:CollectionName` matches. |
| Pivot Table shows no data | Inspect `POST /api/Order` in the browser Network panel and check the server log. A `GET` request from the browser address bar returns `405`. |
| `405 Method Not Allowed` | Confirm `[HttpPost]`, `AddControllers()`, and `MapControllers()` are present. |
| `The MongoDB connection string is not configured.` | Add a `ConnectionStrings:MongoDB` entry to `appsettings.json` and restart the application. |
| Documents are inserted but fields appear as null | Confirm the `[BsonElement]` names match the document field names imported in [Step 5](#step-5-import-sample-order-documents) (`orderId`, `customerName`, `employeeId`, `freight`, `shipCity`). |
| `_id` mapping failures | Confirm the `Order.Id` property is decorated with `[BsonId]` and `[BsonRepresentation(BsonType.ObjectId)]`. Do not send `_id` from the Pivot Table; let MongoDB generate it. |
| Update returns `404` | Confirm that the supplied `OrderID` exists and that `OrderID` is marked as the primary key in the `BeginDrillThrough` event handler. |
| Duplicate `orderId` on insert | The sample computes `orderId` from the highest existing value. Concurrent inserts can collide; switch to an atomic counter document for high-throughput inserts. |
| CRUD returns `400` | Inspect the request JSON and confirm required fields (`CustomerName`, `EmployeeID`) and a numeric key are present. |
| CRUD returns `500` | Check the server log and verify the connection string, database and collection names, and MongoDB server status. |
| Browser reports mixed content or a redirect failure | Confirm `Home.razor` uses same-origin relative URLs (for example `/api/Order`) rather than hard-coded HTTP URLs. |
| Cross-origin request is blocked | Prefer same-origin relative URLs; otherwise configure `AddCors` and `UseCors` for the exact Blazor application origin. |
| Antiforgery validation fails | Configure the adaptor to send the expected request token, or use an appropriate non-cookie API authentication scheme. |
| Large datasets are slow | Process `DataManagerRequest` operations on the server (MongoDB `Filter`, `Sort`, `Skip`, and `Limit`) instead of returning the entire collection. |

For current component behavior, see the [Pivot Table editing documentation](https://blazor.syncfusion.com/documentation/pivot-table/editing) and [Pivot Table data-binding documentation](https://blazor.syncfusion.com/documentation/pivot-table/data-binding).

## Complete Sample Repository

A complete, working sample implementation is available in the [GitHub repository](https://github.com/SyncfusionExamples/syncfusion-blazor-pivot-table-mongodb/tree/master).

## Summary

This guide walked through binding a MongoDB database to the Syncfusion Blazor Pivot Table using the URL Adaptor. You installed MongoDB Community Server and MongoDB Compass, created the `OrderDB` database and `Orders` collection, imported sample documents, and built an ASP.NET Core API that uses `MongoDB.Driver` to read and write those documents. The Blazor Pivot Table consumed the API through `SfDataManager` and the `UrlAdaptor`, configured `OrderID` as the primary key for drill-through editing, and performed read, insert, update, and delete operations through same-origin relative API URLs. Use this sample as a starting point for adding server-side filtering, sorting, paging, authentication, and schema validation before deploying to production.
