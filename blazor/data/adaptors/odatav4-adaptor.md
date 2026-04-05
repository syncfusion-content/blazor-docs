---
layout: post
title: Blazor DataManager - ODataV4 Adaptor | Syncfusion
description: Blazor DataManager ODataV4 provides server-side integration with REST APIs by detailing the backend setup and endpoint configuration required for data operations.
platform: Blazor
control: ODataV4 Adaptor
keywords: adaptors, ODataV4adaptor, ODataV4 adaptor, remotedata 
documentation: ug
---

# OData Remote Data Binding in Syncfusion Blazor Components

OData (Open Data Protocol) is an open standard for building and consuming RESTful APIs. It defines a consistent format for requests and responses, making it easier to query, filter, sort, and manage data across different platforms and technologies.

## Why Choose OData V4?

OData V4 is a widely adopted open standard that provides a consistent way to query, filter, sort, and manipulate data across RESTful services. When using Syncfusion Blazor with `SfDataManager` and the `ODataV4Adaptor`, OData V4 offers several practical advantages over traditional REST APIs and other adaptors. The benefits include:

- Eliminates manual request construction.
- Ensures OData V4 protocol compliance.
- Reduces boilerplate code.
- Provides seamless DataGrid-to-OData communication.

Automated functionality in OData V4 includes:
- URL construction and query string formatting.
- OData query syntax parsing and validation.
- HTTP verb handling for CRUD operations (GET, POST, PATCH, DELETE).
- Request-response transformation between DataGrid and OData service.

This guide outlines the complete process for configuring the `OdataV4Adaptor` by detailing the backend API setup and the server‑side endpoints required to support data operations.

### REST vs OData Query comparison

When exposing data through APIs, two common styles are used:

- **Traditional REST APIs**: Use custom query parameters that differ between implementations (e.g., ?country=, ?sort=, ?page=).
<... trimmed for brevity ...>
- **OData**: An open standard (OASIS) built on REST that provides a consistent query syntax using "$‑prefixed" parameters.

**Quick comparison of REST and OData**:

| Goal                          | Traditional REST API Style | OData Standard Query                                                                 |
|-------------------------------|-------------------------------------------------------------|--------------------------------------------------------------------------------------|
| Get all orders                | `/api/orders`                                               | `/odata/Orders`                                                                      |
| Filter by country             | `/api/orders?country=Denmark`                               | `/odata/Orders?$filter=ShipCountry eq 'Denmark'`                                     |
| Sort by ID descending         | `/api/orders?sort=-orderId` or `sort=orderId desc`          | `/odata/Orders?$orderby=OrderID desc`                                                |
| Page 2 (10 items per page)    | `/api/orders?page=2&size=10`                                | `/odata/Orders?$skip=10&$top=10`                                                     |
| All together                  | `/api/orders?country=Denmark&sort=-id&page=2&size=10`       | `/odata/Orders?$filter=ShipCountry eq 'Denmark'&$orderby=OrderID desc&$skip=10&$top=10` |

The following benefits apply when using OData protocol:

- **Standardization**: Uniform query syntax across all OData services.
- **Reduced complexity**: Eliminates need for custom filtering and sorting logic.
- **Client flexibility**: Clients control data retrieval requirements.
- **Efficiency**: Minimizes data transfer by requesting only necessary fields and rows.

## Prerequisites

Ensure the following software and packages are installed before proceeding:

| Software/Package | Version | Purpose |
|-----------------|---------|---------|
| Visual Studio 2026 | 18.0 or later | Development IDE with Blazor workload |
| .NET SDK | net8.0 or compatible | Runtime and build tools |

## Backend setup (Configuring an OData V4 Service)

To configure a server with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, follow these steps:

### Step 1: Create a Blazor web app

You can create a **Blazor Web App** named **ODataV4Adaptor** using Visual Studio 2022, either via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio). Make sure to configure the appropriate [interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=windows).

### Step 2: Install NuGet packages

To install the required package, go to **Tools → NuGet Package Manager → Manage NuGet Packages for Solution**. 

In the **Browse** tab, search for `Microsoft.AspNetCore.OData` and select it from the results. In the right panel, check the box for the server project, then click **Install**. When prompted, accept the license terms to complete the installation.

**Package functionality:** The `Microsoft.AspNetCore.OData` package enables OData V4 support by providing query parsing, EDM model creation, response formatting, and processing of OData options such as `$filter`, `$orderby`, and `$select`.

### Step 3: Create a model class
 
Create a new folder named **Models**. Then, add a model class named **OrdersDetails.cs** to the **Models** folder under `ODataV4Adaptor.Client` to represent the order data.
 
```csharp

using System.ComponentModel.DataAnnotations;

namespace ODataV4Adaptor.Client.Models
{
    public class OrdersDetails
    {
        public static List<OrdersDetails> order = new List<OrdersDetails>();

        public OrdersDetails() { }
        
        public OrdersDetails(int OrderID, string CustomerId, int EmployeeId, string ShipCountry)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerId;
            this.EmployeeID = EmployeeId;
            this.ShipCountry = ShipCountry;
        }

        public static List<OrdersDetails> GetAllRecords()
        {
            if (order.Count() == 0)
            {
                int code = 10000;
                for (int i = 1; i < 10; i++)
                {
                    order.Add(new OrdersDetails(code + 1, "ALFKI", i + 0, "Denmark"));
                    order.Add(new OrdersDetails(code + 2, "ANATR", i + 2, "Brazil"));
                    order.Add(new OrdersDetails(code + 3, "ANTON", i + 1, "Germany"));
                    order.Add(new OrdersDetails(code + 4, "BLONP", i + 3, "Austria"));
                    order.Add(new OrdersDetails(code + 5, "BOLID", i + 4, "Switzerland"));
                    code += 5;
                }
            }
            return order;
        }

        [Key]
        public int OrderID { get; set; }
        public string? CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public string? ShipCountry { get; set; }
    }
}

```

### Step 4:  OData service configuration

To construct the Entity Data Model for your OData service, use the `ODataConventionModelBuilder` to define the model’s structure in the `Program.cs` file of the `ODataV4Adaptor` project. Start by creating an instance of the `ODataConventionModelBuilder`, and then register the entity set **Orders** using the `EntitySet<T>` method, where `OrdersDetails` represents the CLR type containing order details.

**Entity data model overview:**

The EDM serves as a metadata blueprint describing the data structure exposed by the OData service. It defines available entities (data types), their properties, relationships, and query capabilities. 

```csharp
// Create an ODataConventionModelBuilder to build the OData model.
var modelBuilder = new ODataConventionModelBuilder();

// Register the "Grid" entity set with the OData model builder.
// "Grid" will be the name used in URLs (e.g., /odata/Grid).
modelBuilder.EntitySet<OrdersDetails>("Grid");
```

**Register the OData services**

After building the Entity Data Model, register the OData services in the `Program.cs` file of your application. Follow these steps:

```cs
// Add controllers with OData support to the service collection.
builder.Services.AddControllers().AddOData(
    options => options
        .Select()    // Enables $select to choose specific fields.
        .Filter()    // Enables $filter for filtering data.
        .OrderBy()   // Enables $orderby for sorting.
        .Expand()    // Enables $expand for related data.
        .Count()     // Enables $count to get total record count.
        .SetMaxTop(100) // Limits maximum records per request.
        .AddRouteComponents("odata", modelBuilder.GetEdmModel())); // Maps routes with "odata" prefix.
```

**Configuration details:**
- `AddControllers()`: Registers MVC controller services in the dependency injection container.
- `AddOData()`: Integrates OData middleware and service infrastructure.
- `.Select()`: Enables `$select` query option for column projection.
- `.Filter()`: Enables `$filter` query option for data filtering.
- `.OrderBy()`: Enables `$orderby` query option for result ordering.
- `.Expand()`: Enables `$expand` query option for navigating related entities.
- `.Count()`: Enables `$count` query option for total record count retrieval.
- `.SetMaxTop(100)`: Establishes maximum record limit per request (prevents server overload).
- `AddRouteComponents("odata", ...)`: Configures "odata" as the URL prefix for all OData endpoints.
- `modelBuilder.GetEdmModel()`: Provides the previously constructed Entity Data Model.

**Best practice:** Enable only required query options based on application requirements to optimize security and performance.

**Complete Program.cs implementation:**

The complete **Program.cs** file should resemble the following structure:

```cs
using Microsoft.AspNetCore.OData;
using ODataV4Adaptor.Client.Models;
using Microsoft.OData.ModelBuilder;

var builder = WebApplication.CreateBuilder(args);

// Build OData Model.
var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<OrdersDetails>("Grid");

// Add services.
builder.Services.AddControllers().AddOData(
    options => options
        .Select()
        .Filter()
        .OrderBy()
        .Expand()
        .Count()
        .SetMaxTop(100)
        .AddRouteComponents("odata", modelBuilder.GetEdmModel()));

var app = builder.Build();

// Configure middleware.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}

app.UseHttpsRedirection();
app.UseCors();
app.UseAuthorization();
app.MapControllers();

app.Run();

```

### Step 5: OData controller implementation
 
Create an API controller (aka, **GridController.cs**) file under the **Controllers** folder within the `ODataV4Adaptor` project. This controller facilitates data communication with the Blazor DataGrid.
 
```csharp
 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ODataV4Adaptor.Models;

namespace ODataV4Adaptor.Controllers
{
    [ApiController]
    [Route("[controller]")]    
    public class GridController : ControllerBase
    {
        /// <summary>
        /// Retrieves all records available from the data source.
        /// </summary>
        /// <returns>
        /// Returns list of records.
        /// </returns>
        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            var data = OrdersDetails.GetAllRecords().AsQueryable();
            return Ok(data);
        }
    }
}
 
```
**Implementation analysis:**
- Inheritance from `ODataController`: Provides OData-specific controller capabilities and conventions.
- Routing configuration: OData routing handled automatically via Program.cs configuration; `[Route]` attribute unnecessary.
- Controller behavior: ODataController inherits functionality similar to `[ApiController]` attribute.
- `[HttpGet]`: Designates method to handle HTTP GET requests.
- `[EnableQuery]`: **Essential attribute** - enables OData query processing for `$filter`, `$orderby`, `$select`, and other query options.
- `AsQueryable()`: Converts collection to IQueryable interface, enabling deferred execution and OData query composition.
- `Ok(data)`: Returns HTTP 200 (OK) status with serialized data payload.

> The `[EnableQuery]` attribute is mandatory for OData query functionality. Without this attribute, manual implementation of filtering, sorting, pagination, and projection logic would be required.

### Step 6:  Register controllers in `Program.cs`**
 
Add the following lines in the `Program.cs` file under the `ODataV4Adaptor` project to register controllers:
 
```csharp
// Register controllers in the service container.
builder.Services.AddControllers();
 
// Map controller routes.
app.MapControllers();
```

### Step 7: OData service verification

Run the application in Visual Studio. It will be hosted at the URL **https://localhost:xxxx**. 

**OData endpoint verification:** After running the application, you can verify that the server-side API controller successfully returns the order data at the URL **https://localhost:xxxx/odata/Grid** (where **xxxx** represents the port number).

Test the following URLs to verify OData query functionality:

- **Get all orders**: `https://localhost:xxxx/odata/Grid`
- **Get top 5 orders**: `https://localhost:xxxx/odata/Grid?$top=5`
- **Filter by country**: `https://localhost:xxxx/odata/Grid?$filter=ShipCountry eq 'Denmark'`
- **Sort by OrderID**: `https://localhost:xxxx/odata/Grid?$orderby=OrderID desc`
- **Count records**: `https://localhost:xxxx/odata/Grid/$count`
- **Select specific columns**: `https://localhost:xxxx/odata/Grid?$select=OrderID,CustomerID`

Examples of OData query syntax references:

| Query Option | Purpose | Example |
|--------------|---------|---------|
| `$top=5` | Get first 5 records | `?$top=5` |
| `$skip=10` | Skip first 10 records | `?$skip=10` |
| `$filter=` | Filter records | `?$filter=OrderID gt 10005` |
| `$orderby=` | Sort records | `?$orderby=CustomerID desc` |
| `$select=` | Choose specific fields | `?$select=OrderID,CustomerID` |
| `$count` | Get total count | `/$count` or `?$count=true` |

OData filter operator query reference:
- `eq` - equals: `ShipCountry eq 'Denmark'`
- `ne` - not equals: `ShipCountry ne 'Denmark'`
- `gt` - greater than: `OrderID gt 10005`
- `lt` - less than: `OrderID lt 10010`
- `and` - logical AND: `ShipCountry eq 'Denmark' and OrderID gt 10005`
- `or` - logical OR: `ShipCountry eq 'Denmark' or ShipCountry eq 'Germany'`

![ODataV4Adaptor Data](../images/odatav4-adaptors-data.png)

### Step 8: Understanding the required response format

When using the `OdataV4Adaptor`, every backend API endpoint must return data in a specific JSON structure. This ensures that Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataManager can correctly interpret the response and bind it to the DataGrid. The expected format is:

```json
{
  "value": [
    { "OrderID": 10001, "CustomerID": "ALFKI", "ShipCity": "Berlin" },
    { "OrderID": 10002, "CustomerID": "ANATR", "ShipCity": "Madrid" },
    ...
  ],
  "@odata.count": 10
}
```

- **value**: Returns the data records for the current page/request displayed in the UI.
- **@odata.count**: Indicates the total number of records in the dataset, enabling accurate pagination.

## Troubleshooting common issues

### 404 not found

**Symptom:** Network tab displays 404 error on OData endpoint.

**Solutions:**
- Verify port number matches the server configuration.
- Confirm URL includes "odata" prefix: `/odata/Orders`.
- Ensure controller name matches entity set name.
- Verify server is running.

### Checklist for common OData errors

If errors occur, verify the following:

 - `Microsoft.AspNetCore.OData` NuGet package installation.
 - `[EnableQuery]` attribute applied to **Get** method.
 - Correct "odata" prefix inclusion in route configuration.

## Integration with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components
 
To integrate the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components with the `ODataV4Adaptor`, refer to the documentation below:

- [DataGrid](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/odatav4-adaptor)


