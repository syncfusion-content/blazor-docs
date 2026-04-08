---
layout: post
title: Blazor DataManager - URL Adaptor  | Syncfusion
description: Blazor DataManager UrlAdaptor enables server-side integration with REST APIs, detailing backend setup and endpoint configuration for data operations.
platform: Blazor
control: Url Adaptor
documentation: ug
---

# Custom REST API Remote Data Binding in Syncfusion Blazor Components

The `UrlAdaptor` in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides a straightforward way to connect the DataGrid to custom REST API endpoints. It acts as the communication layer that controls how requests are sent and how responses are received. By organizing this interaction, it ensures reliable and efficient data handling across different Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components, regardless of the server setup.

The adaptor automatically transforms component actions such as filtering, sorting, paging, and CRUD into HTTP POST requests. The server returns JSON data, which the `SfDataManager` processes and supplies back to the component. This mechanism enables reliable and efficient remote data binding without custom request handling.

This documentation outlines the complete process for configuring the `UrlAdaptor` by detailing the backend API setup and the server‑side endpoints required to support data operations.

## Why use UrlAdaptor?

The `UrlAdaptor` works **any custom REST API** (no OData or GraphQL required). Benefits include:

1. **Backend agnostic**: Works with any backend technology.
2. **Server-side processing**: Enables efficient handling of large datasets by running operations on the server.
3. **Automatic requests**: Client-side actions generate structured HTTP requests automatically.
4. **Full CRUD support**: Manage insert, update and delete operations are supported out of the box.
5. **Extensible**: Easy to add authentication, caching, or custom request/response transformations.

## Who should use UrlAdaptor?

The `UrlAdaptor` is designed for projects that rely on custom REST APIs and need flexible communication between Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components and backend services. It is most relevant for applications where standard protocols like OData or GraphQL are not part of the design, and where direct control over request and response handling is required.

It is particularly useful in scenarios such as:

- Custom REST API implementations that expose endpoints in JSON format.
- Large-scale datasets (100K+ records) requiring server-side execution of operations like filtering, sorting, and paging for performance and scalability.
- Integration with existing backend services where APIs are already defined and must be connected without redesign.
- CRUD operations with custom validation involving business rules, authentication, or transformation logic.
- Extensible architectures that need additional features such as caching, security headers, or custom request/response transformations.

## Supported Databases

The `UrlAdaptor` is **completely backend-agnostic**. It connects to any database through a REST API that returns the required JSON format. Commonly integrated databases include:

| Database | Use Case | Notes |
|----------|----------|-------|
| **SQL Server** | Enterprise applications | Robust querying, stored procedures support |
| **MySQL** | Web applications | Open-source, high performance |
| **PostgreSQL** | Complex data models | Advanced features, JSON support |
| **SQLite** | Embedded applications | Lightweight, serverless |
| **MongoDB** | Document databases | NoSQL, flexible schema |
| **Oracle** | Enterprise systems | High scalability, reliability |
| **Azure SQL Database** | Cloud applications | Managed service, auto-scaling |

> The `UrlAdaptor` is **backend-agnostic**. Compatibility exists with any technology stack that:
> 1. Accepts HTTP POST requests with JSON body.
> 2. Parses request parameters (filters, sorts, page info).
> 3. Returns data in the required `{result, count}` format.

## Prerequisites

Ensure the following software and packages are installed before proceeding:

| Software/Package | Version | Purpose |
|-----------------|---------|---------|
| Visual Studio 2026 | 18.0 or later | Development IDE with Blazor workload |
| .NET SDK | net8.0 or compatible | Runtime and build tools |

## Backend setup (Creating an API Service)

To configure a server with the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components, follow these steps:

### Step 1: Create a Blazor web app
 
You can create a **Blazor Web App** named **URLAdaptor** using Visual Studio 2022, either via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio). Make sure to configure the appropriate [interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=windows).

### Step 2: Create data model class
 
1. In Solution Explorer, right-click the **Server** project, choose **Add** → **New Folder**, and name it **Models**.

2. Right-click the **Models** folder, select **Add → Class**, name it **OrdersDetails.cs**, and replace its default content with the provided implementation.
 
```csharp
namespace URLAdaptor.Models
{
    public class OrdersDetails
    {
        public static List<OrdersDetails> order = new List<OrdersDetails>(); 

        public OrdersDetails() { }
 
        public OrdersDetails(int OrderID, string CustomerId, int EmployeeId, double Freight, bool Verified, DateTime OrderDate, string ShipCity, string ShipName, string ShipCountry, DateTime ShippedDate, string ShipAddress)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerId;
            this.EmployeeID = EmployeeId;
            this.Freight = Freight;
            this.ShipCity = ShipCity;
            this.Verified = Verified;
            this.OrderDate = OrderDate;
            this.ShipName = ShipName;
            this.ShipCountry = ShipCountry;
            this.ShippedDate = ShippedDate;
            this.ShipAddress = ShipAddress;
        }

        public static List<OrdersDetails> GetAllRecords()
        {
            if (order.Count() == 0)
            {
                int code = 10000;
                for (int i = 1; i < 10; i++)
                {
                    order.Add(new OrdersDetails(code + 1, "ALFKI", i + 0, 2.3 * i, false, new DateTime(1991, 05, 15), "Berlin", "Simons bistro", "Denmark", new DateTime(1996, 7, 16), "Kirchgasse 6"));
                    order.Add(new OrdersDetails(code + 2, "ANATR", i + 2, 3.3 * i, true, new DateTime(1990, 04, 04), "Madrid", "Queen Cozinha", "Brazil", new DateTime(1996, 9, 11), "Avda. Azteca 123"));
                    order.Add(new OrdersDetails(code + 3, "ANTON", i + 1, 4.3 * i, true, new DateTime(1957, 11, 30), "Cholchester", "Frankenversand", "Germany", new DateTime(1996, 10, 7), "Carrera 52 con Ave. Bolívar #65-98 Llano Largo"));
                    order.Add(new OrdersDetails(code + 4, "BLONP", i + 3, 5.3 * i, false, new DateTime(1930, 10, 22), "Marseille", "Ernst Handel", "Austria", new DateTime(1996, 12, 30), "Magazinweg 7"));
                    order.Add(new OrdersDetails(code + 5, "BOLID", i + 4, 6.3 * i, true, new DateTime(1953, 02, 18), "Tsawassen", "Hanari Carnes", "Switzerland", new DateTime(1997, 12, 3), "1029 - 12th Ave. S."));
                    code += 5;
                }
            }
            return order;
        }
 
        public int? OrderID { get; set; }
        public string? CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public double? Freight { get; set; }
        public string? ShipCity { get; set; }
        public bool? Verified { get; set; }
        public DateTime OrderDate { get; set; }
        public string? ShipName { get; set; }
        public string? ShipCountry { get; set; }
        public DateTime ShippedDate { get; set; }
        public string? ShipAddress { get; set; }
    }
}
```
>  This example uses a static in-memory list (`order`) for simplicity. In real applications, replace `GetAllRecords()` with database queries using Entity Framework Core, Dapper, or the preferred data access layer.

### Step 3: Create an API controller
 
Create an API controller (aka, **DataController.cs**) file under **Controllers** folder that helps to establish data communication with the Blazor Components.
 
```csharp
 
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Blazor.Data;
using Syncfusion.Blazor;
using URLAdaptor.Models;
 
namespace URLAdaptor.Controllers
{   
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        /// <summary>
        /// Retrieves the list of orders.
        /// </summary>
        /// <returns>Retrieve data from the data source.</returns>
        [HttpGet]
        public List<OrdersDetails> GetOrderData()
        {
            return OrdersDetails.GetAllRecords().ToList();
        }
 
        /// <summary>
        /// Handles server-side data operations such as filtering, sorting, paging, and returns the processed data.
        /// </summary>
        /// <returns>Returns the data and total count in result and count format.</returns>
        [HttpPost]
        [Route("api/[controller]")]
        public object Post([FromBody] DataManagerRequest DataManagerRequest)
        {
            // Retrieve data source and convert to queryable.(replace with the database query).
            IQueryable<OrdersDetails> DataSource = GetOrderData().AsQueryable();
 
           // Get total records count BEFORE paging.
            int totalRecordsCount = DataSource.Count();
           // Apply server-side operations here (will be added later).
           // For now, return all data with count.

            // Return in {result, count} format (see Step 7 for details).
            return new { result = DataSource, count = totalRecordsCount };
        }
    }
}
 
```
 
> The server response must include `result` for the current data and `count` for the total records to enable proper pagination.

**Key Points:**
- **[FromBody] DataManagerRequest**: This parameter receives all operation details (filters, sorts, page info).
- **IQueryable&lt;OrdersDetails&gt;**: Use `IQueryable` for efficient database queries.
-  **result**: Returns the data records for the current page/request displayed in the UI.
- **count**: Must be total count before paging (not just current page count).
- **HttpPost**: Client sends `POST` requests by default for data operations.

### Step 4: Register controllers in `Program.cs`
 
The `Program.cs` file is where application services are registered and configured. Add the following lines in the `Program.cs` file to register controllers:
 
```csharp
// Register controllers in the service container.
builder.Services.AddControllers();
 
// Map controller routes.
app.MapControllers();

```
**Explanation:**

- `AddControllers()` registers MVC controllers for REST endpoints.
- `MapControllers()` exposes routes like `/api/Grid`.
- Syncfusion Blazor and Razor components are registered for the UI.

### Step 5: Test the backend API

Run the application in Visual Studio, accessible on a URL like **https://localhost:xxxx**. Verify the API returns order data at **https://localhost:xxxx/api/data**, where **xxxx** is the port. 

### Step 6: Understanding the required response format

When using the `UrlAdaptor`, every backend API endpoint must return data in a specific JSON structure. This ensures that Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataManager can correctly interpret the response and bind it to the component. The expected format is:

```json
{
  "result": [
    { "OrderID": 10001, "CustomerID": "ALFKI", "ShipCity": "Berlin" },
    { "OrderID": 10002, "CustomerID": "ANATR", "ShipCity": "Madrid" },
    ...
    ...
  ],
  "count": 10
}
```

- **result**: Returns the data records for the current page/request displayed in the UI.
- **count**: Indicates the total number of records in the dataset, enabling accurate pagination.

> * Without the `count` field, paging and virtual scrolling cannot function correctly.
> * APIs returning just an array `[{...}, {...}]` instead of `{result: [...], count: ...}` will prevent proper data display. Responses must wrap in the required structure.

## Troubleshooting

| Issue             | Resolution                                                                 |
|-------------------|-----------------------------------------------------------------------------|
| **Empty response** | Check if "GetAllRecords()" is populating data.                             |
| **404 Error**      | Verify controller route is `[Route("api/[controller]")]`.                  |
| **500 Error**      | Check server logs in the Visual Studio Output window.                      |

## Integration with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components

To integrate the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components with the `UrlAdaptor`, refer to the documentation below:

- [DataGrid](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/url-adaptor)



