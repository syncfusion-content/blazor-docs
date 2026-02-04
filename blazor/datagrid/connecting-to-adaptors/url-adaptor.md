---
layout: post
title: Bind data and perform CRUD using UrlAdaptor in Syncfusion DataGrid
description: Learn about bind data and performing CRUD operations using UrlAdaptor in Syncfusion Blazor DataGrid.
platform: Blazor
control: DataGrid
keywords: adaptors, urladaptor, url adaptor, remotedata 
documentation: ug
---

# Remote Data Binding with UrlAdaptor in Syncfusion Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid uses the [UrlAdaptor](https://blazor.syncfusion.com/documentation/data/adaptors#url-adaptor) to establish communication with REST-based API endpoints for remote data binding.

The `UrlAdaptor` is the base adaptor for enabling communication between remote data services and UI components in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid. This adaptor supports seamless data binding and interaction with custom API services or any remote service through URLs. The `UrlAdaptor` is especially useful when a custom API service is used to handle data and CRUD operations, allowing for custom logic on the server side. The data must be returned in the `result` and `count` format for display in the DataGrid.

The section outlines the configuration workflow for data binding, processing server‑side data operations, and performing CRUD actions using `UrlAdaptor`.

## Why choose UrlAdaptor for remote data binding?

The UrlAdaptor enables the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid to retrieve data from custom API endpoints without relying on OData-specific conventions. It supports flexible interaction with any REST-based service capable of returning data in the expected `result` and `count` structure. The adaptor ensures that every data operation performed in the DataGrid generates a consistent and predictable request payload, allowing the server to determine how data should be processed. This makes the `UrlAdaptor` suitable for applications that require centralized, secure, and scalable server-side logic.

**Key advantages**

* **Performance**: Processes data in smaller segments, such as one page per request, allowing smooth rendering even when working with large collections.

* **Customization**: Serves as the underlying adaptor used by Syncfusion<sup style="font-size:70%">&reg;</sup> data connectors. Custom request headers, authentication mechanisms, or transformation logic can be implemented in the API layer without modifying the adaptor.

* **Scalability**: Well‑suited for enterprise applications that require secure and centralized server‑side execution of operations such as sorting, filtering, paging, grouping, and searching.

* **Built‑in data operation support**: Automatically generates structured parameters for all DataGrid operations, enabling the server to receive consistent inputs for actions such as sorting, filtering, searching, paging, and grouping. These parameters are delivered through the [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html) model, removing the need for manual query construction. After the server processes these inputs and returns the required JSON structure, the DataGrid binds directly to the resulting collection.

## Who should use UrlAdaptor?

The `UrlAdaptor` is suitable for applications where data operations must be executed on the server instead of the client. It supports systems designed with centralized business logic, distributed data sources, or large datasets that require efficient server-side computation. Applications relying on **REST-based endpoints** or custom services that expose data through HTTP interfaces benefit from the structured request and response patterns used by the `UrlAdaptor`.

**Intended audience**

* Frontend scenarios that require consistent communication between the Syncfusion® Blazor DataGrid and REST API endpoints.
* Full-stack solutions where the server processes DataManagerRequest parameters to apply filtering, sorting, paging, searching, or grouping.
* Enterprise architectures that prioritize scalability, security, and centralized data processing.
* Applications backed by remote services returning collections in the result and count structure.

## Supporting Database List

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid integrates with any database exposed through a REST‑based API when configured with the `UrlAdaptor`. The adaptor is backend‑agnostic and operates with services that return data in a JSON structure containing `result` and `count`. The DataGrid communicates exclusively with the API layer, enabling consistent integration with a wide range of data platforms.

Supported database environments include:

* **Microsoft SQL Server**: A relational database engine designed for enterprise workloads and complex querying requirements.
* **MySQL**: An open‑source relational database suited for scalable and high‑performance applications.
* **PostgreSQL**: An advanced relational database offering extensibility, advanced indexing capabilities, and robust query support.
* **SQLite**: A lightweight, file‑based database appropriate for embedded systems or small‑scale data storage.
* **Dapper with SQL databases**: A .NET micro‑ORM that provides high‑performance data access patterns for relational databases.
* **Any EF Core–supported database**: Includes SQL Server, MySQL, PostgreSQL, Oracle, SQLite, Cosmos DB, or any provider supported by Entity Framework Core, provided the API returns data in the required JSON structure.

A RESTful API endpoint is required to receive `DataManagerRequest` parameters, process server‑side operations, and return a JSON response containing both the processed collection in `result` and the total count in `count`.

## Setting up the API service for UrlAdaptor

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can be configured to interact with a server-side API using the `UrlAdaptor`. The following steps outline how to create an API service for data binding and CRUD operations:

### Expected JSON response structure for UrlAdaptor APIs

The API must return JSON data in a specific structure:

* **result** — A collection representing the processed records for the current request.
* **count** — The total number of records in the underlying data source, required for paging calculations.

A valid JSON response is:

```json
{
  "result": [
    { "OrderID": 10001, "CustomerID": "ALFKI" },
    { "OrderID": 10002, "CustomerID": "ANATR" }
  ],
  "count": 45
}
```
If the API does not provide both `result` and `count`, the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid cannot retrieve or render data when operating with the `UrlAdaptor`. The `result` property must contain the final processed data after applying server‑side operations. The `count` property must represent the total available records before paging.

### Step 1: Create a Blazor web app

A **Blazor Web App** is required to host the API service that communicates with the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid. The application can be created using **Visual Studio 2026** with [Microsoft Blazor templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

1. Select the **Blazor Web App** template.
2. Configure the **project name** and storage location.
3. Select the desired .NET runtime version.
4. Set the [interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-10.0#render-modes) based on the application requirements.
5. Configure [interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs#interactivity-location) as **Per page/component** or **Global**.

### Step 2: Create a model class

Add a **Models** folder in the server‑side project and create a class named **OrdersDetails.cs**.

This class defines the order data structure used by the API service when processing remote data operations through the `UrlAdaptor`.

{% tabs %}
{% highlight razor tabtitle="OrdersDetails.cs" %}

namespace URLAdaptor.Models
{
    /// <summary>
    /// Represents an order record used by the UrlAdaptor samples.
    /// </summary>
    public sealed class OrdersDetails
    {
        // In-memory backing store for demo data (seeded on first access).
        private static readonly List<OrdersDetails> Data = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="OrdersDetails"/> class.
        /// </summary>
        public OrdersDetails()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrdersDetails"/> class with values.
        /// </summary>
        public OrdersDetails(
            int orderID,
            string customerId,
            int employeeId,
            double freight,
            bool verified,
            DateTime orderDate,
            string shipCity,
            string shipName,
            string shipCountry,
            DateTime shippedDate,
            string shipAddress)
        {
            OrderID = orderID;
            CustomerID = customerId;
            EmployeeID = employeeId;
            Freight = freight;
            Verified = verified;
            OrderDate = orderDate;
            ShipCity = shipCity;
            ShipName = shipName;
            ShipCountry = shipCountry;
            ShippedDate = shippedDate;
            ShipAddress = shipAddress;
        }

        /// <summary>
        /// Returns the in-memory collection of orders (seeded on first access).
        /// </summary>
        public static List<OrdersDetails> GetAllRecords()
        {
            if (Data.Count == 0)
            {
                Seed();
            }

            return Data;
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

        private static void Seed()
        {
            var code = 10000;

            for (var i = 1; i < 10; i++)
            {
                Data.Add(new OrdersDetails(code + 1, "ALFKI", i + 0, 2.3 * i, false,
                    new DateTime(1991, 05, 15), "Berlin", "Simons bistro", "Denmark",
                    new DateTime(1996, 7, 16), "Kirchgasse 6"));

                Data.Add(new OrdersDetails(code + 2, "ANATR", i + 2, 3.3 * i, true,
                    new DateTime(1990, 04, 04), "Madrid", "Queen Cozinha", "Brazil",
                    new DateTime(1996, 9, 11), "Avda. Azteca 123"));

                Data.Add(new OrdersDetails(code + 3, "ANTON", i + 1, 4.3 * i, true,
                    new DateTime(1957, 11, 30), "Colchester", "Frankenversand", "Germany",
                    new DateTime(1996, 10, 7), "Carrera 52 con Ave. Bolívar #65-98 Llano Largo"));

                Data.Add(new OrdersDetails(code + 4, "BLONP", i + 3, 5.3 * i, false,
                    new DateTime(1930, 10, 22), "Marseille", "Ernst Handel", "Austria",
                    new DateTime(1996, 12, 30), "Magazinweg 7"));

                Data.Add(new OrdersDetails(code + 5, "BOLID", i + 4, 6.3 * i, true,
                    new DateTime(1953, 02, 18), "Tsawassen", "Hanari Carnes", "Switzerland",
                    new DateTime(1997, 12, 3), "1029 - 12th Ave. S."));

                code += 5;
            }
        }
    }
}
{% endhighlight %} 
{% endtabs %}

### Step 3: Create an API controller

An API controller must be implemented to expose endpoints that respond to **GET** and **POST** requests from the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid when configured with the UrlAdaptor. Create a controller named **GridController.cs** in the **Controllers** folder of the server‑side project.

The controller must:

* Return the data through the **GET** endpoint.
* Process `DataManagerRequest` parameters in the **POST** endpoint.
* Apply server‑side searching, filtering, sorting, and paging through the `DataOperations` API provided by the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Data library to process the request.

The controller must always return JSON data in the { `result`, `count` } structure required by the `UrlAdaptor`.

{% tabs %}
{% highlight razor tabtitle="GridController.cs" %}

namespace URLAdaptor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GridController : ControllerBase
    {
        /// <summary>
        /// Retrieves the list of orders.
        /// </summary>
        /// <returns>Retrieves data from the data source.</returns>
        [HttpGet]
        public List<OrdersDetails> GetOrderData()
        {
            return OrdersDetails.GetAllRecords().ToList();
        }
        /// <summary>
        /// Handles server-side data operations such as filtering, sorting, and paging,
        /// and returns the processed data.
        /// </summary>
        /// <returns>Returns the data and total count in result and count format.</returns>
        [HttpPost]
        public object Post()
        {
            // Retrieve data source and convert to queryable.
            IQueryable<OrdersDetails> dataSource = GetOrderData().AsQueryable();

            // Get total records count.
            int totalRecordsCount = dataSource.Count();

            // Return data and count.
            return new { result = dataSource, count = totalRecordsCount };
        }
    }
}
{% endhighlight %} 
{% endtabs %}

> The `GetOrderData` method returns sample order records for demonstration purposes. This method can be replaced with application‑specific logic that retrieves data from a database or any other persistent storage mechanism.

### Step 4:. Register controllers in `Program.cs`**

Register the controller configuration in the server‑side project to enable routing for API endpoints used by the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid. The controller pipeline must be added to the service container and mapped during application startup.

```csharp
// Register controllers in the service container.
builder.Services.AddControllers();

// Map controller routes.
app.MapControllers();
```

This configuration ensures that all API endpoints exposed by the **GridController** are available for remote data binding when using the `UrlAdaptor`.

### Step 5: Run the application**

Run the application in Visual Studio. The API will be accessible at a URL similar to **https://localhost:xxxx/api/grid** (where **xxxx** represents the port number). Verify the API returns the expected JSON payload and that responses use the `result` and `count` format when required.

![UrlAdaptor Data](../images/blazor-datagrid-adaptors-data.png)

## Integrating UrlAdaptor with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can be integrated with a server‑side API by configuring [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html) with a remote endpoint and the `UrlAdaptor`. This configuration enables the DataGrid to retrieve data, perform server‑side operations, and process CRUD actions through API responses structured in the { `result`, `count` } format.

### Step 1: Install Syncfusion<sup style="font-size:70%">&reg;</sup> Packages

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid requires the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor component packages to be installed in the project.

**Method 1: Using Package Manager Console**

1. Navigate to **Tools → NuGet Package Manager → Package Manager Console**.
2. Run the following commands:

```powershell
Install-Package Syncfusion.Blazor.Grid -Version {{ site.releaseversion }};
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}
```

**Method 2: Using NuGet Package Manager UI**

1. Navigate to **Tools → NuGet Package Manager → Manage NuGet Packages for Solution**.
2. Search for and install the following packages individually:

    - [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid/)
    - [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

For projects using **WebAssembly** or **Auto** interactive render modes, ensure these packages are installed in the **Client** project.

> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). For a complete list of packages, refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages).

### Step 2: Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service must be registered in the project configuration to enable component rendering and license activation.

Add the required namespaces in the **_Imports.razor** file:

```cs
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
```

Register the Syncfusion Blazor service in **Program.cs**:

```csharp
using Syncfusion.Blazor;

builder.Services.AddSyncfusionBlazor();
```

> For Blazor Web App configurations, the Syncfusion<sup style="font-size:70%">&reg;</sup> service must be registered in both the **client** and **server** project when using **WebAssembly** or **Auto** render modes.

### Step 3: Add stylesheet and script resources

The necessary theme stylesheet and Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor script file must be added to the application to support DataGrid rendering and interactive behavior.

Add the required theme stylesheet and script references in **~/Components/App.razor**.

```html
<head>
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

<body>

    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

This configuration ensures that DataGrid components load their styles and client‑side script resources when rendered.

>* For this project, the **bootstrap5** theme is used. A different theme can be selected or the existing theme can be customized based on project requirements. Refer to the [Syncfusion Blazor Components Appearance](https://blazor.syncfusion.com/documentation/appearance/themes) documentation to learn more about theming and customization options.
>* For script reference options, see [Adding Script References](https://blazor.syncfusion.com/documentation/common/adding-script-references).

### Step 4: Add Blazor DataGrid and configure with server

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid establishes remote data communication through the [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html) component. The endpoint defined in the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Url) property serves as the API target, and assigning [UrlAdaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Adaptors.html#Syncfusion_Blazor_Adaptors_UrlAdaptor) to the [Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Adaptor) property enables server‑side data operations.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Data

<SfGrid TValue="OrderDetails" Height="348">
    <SfDataManager Url="https://localhost:xxxx/api/grid"
                   Adaptor="Adaptors.UrlAdaptor">
    </SfDataManager>
    <GridColumns>
        <GridColumn Field="OrderID"
                    HeaderText="Order ID"
                    Width="100"
                    TextAlign="TextAlign.Right">
        </GridColumn>
        <GridColumn Field="CustomerID"
                    HeaderText="Customer Name"
                    Width="100">
        </GridColumn>
        <GridColumn Field="ShipCity"
                    HeaderText="Ship City"
                    Width="100">
        </GridColumn>
        <GridColumn Field="ShipCountry"
                    HeaderText="Ship Country"
                    Width="120">
        </GridColumn>
    </GridColumns>
</SfGrid>
{% endhighlight %}
{% endtabs %}

> The **Syncfusion.Blazor.Data** package must be added to the API service project through the **NuGet Package Manager** in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*) by searching for and installing the package.

### Step 5: Run the application

Run the application and verify that the DataGrid displays data retrieved from the API.

![UrlAdaptor Data](../images/blazor-datagrid-adaptors.gif)

## Perform data operations in UrlAdaptor

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports server‑side operations such as **searching**, **sorting**, **filtering**, **aggregating**, and **paging**. These operations are executed on the server through structured requests sent using the [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html) object. The server applies the requested operations using built‑in methods from the [DataOperations](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html) class in the **Syncfusion.Blazor.Data** package and returns a JSON response containing a processed collection in `result` and the total record count in `count`.


| Operation | Method | Use Case |
|----------|--------|----------|
| Searching | [PerformSearching](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSearching__1_System_Linq_IQueryable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_SearchFilter__) | Applies search criteria from the request to the data source for server‑side searching. |
| Filtering | [PerformFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformFiltering__1_System_Linq_IQueryable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_WhereFilter__System_String_) | Filters the data source using conditions specified in the request, supporting both single‑column and multi‑column filtering. |
| Sorting | [PerformSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSorting__1_System_Linq_IQueryable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_Sort__) | Sorts the data source using one or more sort descriptors in ascending or descending order. |
| Grouping | [PerformGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformGrouping__1_System_Linq_IQueryable___0__System_Collections_Generic_List_System_String__) | Groups the data source based on the specified field. |
| Paging | [PerformSkip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSkip__1_System_Linq_IQueryable___0__System_Int32_), [PerformTake](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformTake__1_System_Linq_IQueryable___0__System_Int32_) | Retrieves a specified number of items and skips items based on the request to return only the required page of data. |

### Searching

To enable server‑side searching with the `UrlAdaptor`, apply search criteria from the [DataManagerRequest.Search ](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html#Syncfusion_Blazor_DataManagerRequest_Search)collection using the [PerformSearching](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSearching__1_System_Collections_Generic_IEnumerable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_SearchFilter__) method. This method processes each search descriptor and updates the data based on the configured search fields and operators.

![UrlAdaptor - Searching](../images/urladaptor-searching.png)

{% tabs %}
{% highlight cs tabtitle="GridController.cs" %}
/// <summary>
/// Handles server-side searching and returns the processed data.
/// </summary>
/// <param name="request">Request containing search descriptors.</param>
/// <returns>JSON result with the processed collection in 'result' and the total count in 'count'.</returns>
[HttpPost]
public IActionResult Post([FromBody] DataManagerRequest request)
{
    IQueryable<OrdersDetails> dataSource = OrdersDetails.GetAllRecords().AsQueryable();

    // Searching
    if (request.Search != null && request.Search.Count > 0)
    {
        dataSource = DataOperations.PerformSearching(dataSource, request.Search);
    }

    int totalRecordsCount = dataSource.Count();

    return Ok(new { result = dataSource, count = totalRecordsCount });
}

{% endhighlight %}

{% highlight razor tabtitle="Home.razor" %}
<SfGrid TValue="OrdersDetails"
        Toolbar="@(new List<string> { "Search" })"
        Height="348">
    <SfDataManager Url="https://localhost:xxxx/api/grid"
                   Adaptor="Adaptors.UrlAdaptor">
    </SfDataManager>
    <GridColumns>
        <GridColumn Field="OrderID"
                    HeaderText="Order ID"
                    Width="100"
                    TextAlign="TextAlign.Right">
        </GridColumn>
        <GridColumn Field="CustomerID"
                    HeaderText="Customer Name"
                    Width="100">
        </GridColumn>
        <GridColumn Field="ShipCity"
                    HeaderText="Ship City"
                    Width="100">
        </GridColumn>
        <GridColumn Field="ShipCountry"
                    HeaderText="Ship Country"
                    Width="120">
        </GridColumn>
    </GridColumns>
</SfGrid>

{% endhighlight %} 
{% endtabs %}

### Filtering

To enable server‑side filtering with the `UrlAdaptor`, apply filter conditions from the [DataManagerRequest.Where](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html#Syncfusion_Blazor_DataManagerRequest_Where) collection by using the [PerformFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformFiltering__1_System_Linq_IQueryable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_WhereFilter__System_String_) method. This method evaluates each predicate and updates the data based on the requested single‑column or multi‑column filtering.

**Single column filtering**
![Single column filtering](../images/urladaptor-filtering.png)

**Multi column filtering**
![Multi column filtering](../images/urladaptor-multi-filtering.png)

{% tabs %}
{% highlight cs tabtitle="GridController.cs" %}

/// <summary>
/// Handles server-side filtering and returns the processed data.
/// </summary>
/// <param name="request">Request containing filter predicates.</param>
/// <returns>JSON result with the processed collection in 'result' and the total count in 'count'.</returns>
[HttpPost]
public IActionResult Post([FromBody] DataManagerRequest request)
{
    IQueryable<OrdersDetails> dataSource = OrdersDetails.GetAllRecords().AsQueryable();

    // Filtering
    if (request.Where != null && request.Where.Count > 0)
    {
        foreach (var where in request.Where)
        {
            foreach (var predicate in where.predicates)
            {
                dataSource = DataOperations.PerformFiltering(dataSource, request.Where, predicate.Operator);
                // Place custom filtering logic here if required, instead of PerformFiltering.
            }
        }
    }

    int totalRecordsCount = dataSource.Count();

    return Ok(new { result = dataSource, count = totalRecordsCount });
}
{% endhighlight %}

{% highlight razor tabtitle="Home.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@using URLAdaptor.Models

<SfGrid TValue="OrdersDetails" AllowFiltering="true" Height="348">
    <SfDataManager Url="https://localhost:xxxx/api/grid"
                   Adaptor="Adaptors.UrlAdaptor">
    </SfDataManager>
    <GridColumns>
        <GridColumn Field="OrderID"
                    HeaderText="Order ID"
                    Width="100"
                    TextAlign="TextAlign.Right">
        </GridColumn>
        <GridColumn Field="CustomerID"
                    HeaderText="Customer Name"
                    Width="100">
        </GridColumn>
        <GridColumn Field="ShipCity"
                    HeaderText="Ship City"
                    Width="100">
        </GridColumn>
        <GridColumn Field="ShipCountry"
                    HeaderText="Ship Country"
                    Width="120">
        </GridColumn>
    </GridColumns>
</SfGrid>
{% endhighlight %} 
{% endtabs %}

### Sorting

To enable server‑side sorting with the `UrlAdaptor`, apply sort descriptors from the [DataManagerRequest.Sorted](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html#Syncfusion_Blazor_DataManagerRequest_Sorted) collection using the [PerformSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSorting__1_System_Collections_Generic_IEnumerable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_SortedColumn__) method. This method processes each sort instruction and updates the data according to the specified field and sort direction.

**Single column sorting**
![Single column sorting](../images/urladaptor-sorting.png)

**Multi column sorting**
![Multi column sorting](../images/urladaptor-multi-sorting.png)

{% tabs %}
{% highlight cs tabtitle="GridController.cs" %}

/// <summary>
/// Handles server-side sorting and returns the processed data.
/// </summary>
/// <param name="request">Request containing sort descriptors.</param>
/// <returns>JSON result with the processed collection in 'result' and the total count in 'count'.</returns>
[HttpPost]
public IActionResult Post([FromBody] DataManagerRequest request)
{
    IQueryable<OrdersDetails> dataSource = OrdersDetails.GetAllRecords().AsQueryable();

    // Sorting
    if (request.Sorted != null && request.Sorted.Count > 0)
    {
        dataSource = DataOperations.PerformSorting(dataSource, request.Sorted);
        // Place custom sorting logic here if required, instead of PerformSorting.
    }

    int totalRecordsCount = dataSource.Count();

    return Ok(new { result = dataSource, count = totalRecordsCount });
}

{% endhighlight %}

{% highlight razor tabtitle="Home.razor" %}

<SfGrid TValue="OrdersDetails" AllowSorting="true" Height="348">
    <SfDataManager Url="https://localhost:xxxx/api/grid"
                   Adaptor="Adaptors.UrlAdaptor">
    </SfDataManager>
    <GridColumns>
        <GridColumn Field="OrderID"
                    HeaderText="Order ID"
                    Width="100"
                    TextAlign="TextAlign.Right">
        </GridColumn>
        <GridColumn Field="CustomerID"
                    HeaderText="Customer Name"
                    Width="150">
        </GridColumn>
        <GridColumn Field="ShipCity"
                    HeaderText="Ship City"
                    Width="120">
        </GridColumn>
        <GridColumn Field="ShipCountry"
                    HeaderText="Ship Country"
                    Width="140">
        </GridColumn>
    </GridColumns>
</SfGrid>

{% endhighlight %} 
{% endtabs %}

### Paging

To enable server‑side paging with the `UrlAdaptor`, apply pagination values from the [DataManagerRequest.Skip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html#Syncfusion_Blazor_DataManagerRequest_Skip) and [DataManagerRequest.Take](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html#Syncfusion_Blazor_DataManagerRequest_Take) properties using the [PerformSkip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSkip__1_System_Linq_IQueryable___0__System_Int32_) and [PerformTake](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformTake__1_System_Linq_IQueryable___0__System_Int32_) methods. These methods adjust the data based on the requested page while preserving the total record count for accurate paging.

![UrlAdaptor - Paging](../images/urladaptor-paging.png)

{% tabs %}
{% highlight cs tabtitle="GridController.cs" %}

//// <summary>
/// Handles server-side paging and returns the processed data.
/// </summary>
/// <param name="request">Request containing pagination values.</param>
/// <returns>JSON result with the processed collection in 'result' and the total count in 'count'.</returns>
[HttpPost]
public IActionResult Post([FromBody] DataManagerRequest request)
{
    IQueryable<OrdersDetails> dataSource = OrdersDetails.GetAllRecords().AsQueryable();

    // Total count before paging
    int totalRecordsCount = dataSource.Count();

    // Paging
    if (request.Skip != 0)
    {
        dataSource = DataOperations.PerformSkip(dataSource, request.Skip);
        // Custom paging logic can be placed here if required.
    }

    if (request.Take != 0)
    {
        dataSource = DataOperations.PerformTake(dataSource, request.Take);
        // Custom paging logic can be placed here if required.
    }

    return Ok(new { result = dataSource, count = totalRecordsCount });
}

{% endhighlight %}

{% highlight razor tabtitle="Home.razor" %}

<SfGrid TValue="OrdersDetails" AllowPaging="true" Height="348">
    <SfDataManager Url="https://localhost:xxxx/api/grid"
                   Adaptor="Adaptors.UrlAdaptor">
    </SfDataManager>
    <GridColumns>
        <GridColumn Field="OrderID"
                    HeaderText="Order ID"
                    Width="100"
                    TextAlign="TextAlign.Right">
        </GridColumn>
        <GridColumn Field="CustomerID"
                    HeaderText="Customer Name"
                    Width="100">
        </GridColumn>
        <GridColumn Field="ShipCity"
                    HeaderText="Ship City"
                    Width="100">
        </GridColumn>
        <GridColumn Field="ShipCountry"
                    HeaderText="Ship Country"
                    Width="120">
        </GridColumn>
    </GridColumns>
</SfGrid>

{% endhighlight %}
{% endtabs %}

N> In URL Adaptor, the DataGrid component handles **grouping** and **aggregation** operations automatically. Customizable operations such as **searching**, **filtering**, **sorting**, and **paging** can be modified within the controller logic, but grouping and aggregation are managed directly by the DataGrid component.

## Perform CRUD operations in UrlAdaptor

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports **Create**, **Read**, **Update**, and **Delete** (CRUD) operations through the [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component. **CRUD** actions are processed on the server using the payload provided through the **CRUDModel<T>** structure, and each action modifies the underlying data based on the request details.

**CRUD Mapping Properties**

| Property   | Purpose | Description |
|------------|---------|-------------|
| [InsertUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_InsertUrl)  | Insert operation | Defines the endpoint used to add new data. |
| [UpdateUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_UpdateUrl)  | Update operation | Defines the endpoint used to update existing data. |
| [RemoveUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_RemoveUrl)  | Delete operation | Defines the endpoint used to delete data. |
| [CrudUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_CrudUrl)    | Unified CRUD operation | Defines a single endpoint used to process insert, update, and delete operations. |
| [BatchUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_BatchUrl)   | Batch editing | Defines the endpoint used to process batch changes in one request. |

To enable editing in the DataGrid, configure the [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) and [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Toolbar) properties to allow adding, editing, and deleting records. For configuration details, refer to the DataGrid [editing](https://blazor.syncfusion.com/documentation/datagrid/editing) documentation.

In this configuration, inline editing is enabled by setting the edit [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Mode) to [EditMode.Normal](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.EditMode.html).

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@using URLAdaptor.Models

<SfGrid TValue="OrdersDetails"
        Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })"
        Height="348">
    <SfDataManager Url="https://localhost:xxxx/api/grid"
                   InsertUrl="https://localhost:xxxx/api/grid/Insert"
                   UpdateUrl="https://localhost:xxxx/api/grid/Update"
                   RemoveUrl="https://localhost:xxxx/api/grid/Remove"
                   Adaptor="Adaptors.UrlAdaptor">
    </SfDataManager>
    <GridEditSettings AllowAdding="true"
                      AllowEditing="true"
                      AllowDeleting="true"
                      Mode="EditMode.Normal">
    </GridEditSettings>
    <GridColumns>
        <GridColumn Field="OrderID"
                    HeaderText="Order ID"
                    IsPrimaryKey="true"
                    Width="100"
                    TextAlign="TextAlign.Right">
        </GridColumn>
        <GridColumn Field="CustomerID"
                    HeaderText="Customer Name"
                    Width="100">
        </GridColumn>
        <GridColumn Field="ShipCity"
                    HeaderText="Ship City"
                    Width="100">
        </GridColumn>
        <GridColumn Field="ShipCountry"
                    HeaderText="Ship Country"
                    Width="120">
        </GridColumn>
    </GridColumns>
</SfGrid>

{% endhighlight %}
{% endtabs %}

> Normal or Inline editing is the default edit `Mode` for the DataGrid. To enable CRUD operations, ensure the [IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsPrimaryKey) property is set to **true** for a unique column.

The **CRUDModel<T>** class represents the data structure used during CRUD operations. It contains information about the requested action, key details, the affected record, and collections that hold newly added, updated, or removed entries.

```csharp
public class CRUDModel<T> where T : class
{
    public string? action { get; set; }
    public string? keyColumn { get; set; }
    public object? key { get; set; }
    public T? value { get; set; }
    public List<T>? added { get; set; }
    public List<T>? changed { get; set; }
    public List<T>? deleted { get; set; }
    public IDictionary<string, object>? @params { get; set; }
}   
```

### Insert operation

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid processes insert requests through the [InsertUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_InsertUrl) property in the `DataManager` configuration. The server receives the request payload in a **CRUDModel<T>** instance, where the `value` property contains the newly created record. The API endpoint mapped through `InsertUrl` adds this record to the target data collection.

![Insert Record](../images/urladaptor-insert-record.png)

{% tabs %}
{% highlight cs tabtitle="GridController.cs" %}

/// <summary>
/// Inserts a new record into the data collection.
/// </summary>
/// <param name="newRecord">
/// Contains the new record provided in the <c>value</c> property.
/// </param>
/// <returns>
/// Returns void.
/// </returns>
[HttpPost("Insert")]
public void Insert([FromBody] CRUDModel<OrdersDetails> newRecord)
{
    if (newRecord.value != null)
    {
        OrdersDetails.GetAllRecords().Insert(0, newRecord.value);
    }
}
{% endhighlight %}
{% endtabs %}

### Update operation

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid processes update requests through the [UpdateUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_UpdateUrl)  property in the `DataManager` configuration. The server receives the request payload in a **CRUDModel<T>** instance, where the `value` property contains the modified record. The API endpoint mapped through `UpdateUrl` identifies the corresponding entry in the target data collection and applies the updated field values.

![Update Record](../images/urladaptor-update-record.png)

{% tabs %}
{% highlight cs tabtitle="GridController.cs" %}

/// <summary>
/// Updates an existing record in the data collection.
/// </summary>
/// <param name="updatedRecord">
/// Contains the modified record provided in the <c>value</c> property.
/// </param>
/// <returns>
/// Returns void.
/// </returns>
[HttpPost("Update")]
public void Update([FromBody] CRUDModel<OrdersDetails> updatedRecord)
{
    var updated = updatedRecord.value;
    if (updated != null)
    {
        var target = OrdersDetails.GetAllRecords()
            .FirstOrDefault(or => or.OrderID == updated.OrderID);

        if (target != null)
        {
            target.OrderID = updated.OrderID;
            target.CustomerID = updated.CustomerID;
            target.ShipCity = updated.ShipCity;
            target.ShipCountry = updated.ShipCountry;
        }
    }
}

{% endhighlight %}
{% endtabs %}

### Delete operation

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid handles delete actions through the  [RemoveUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_RemoveUrl) property configured in the `DataManager`. The request payload is provided as a **CRUDModel<T>** instance, where the `key` property contains the primary key value of the record targeted for removal. The API endpoint mapped through `RemoveUrl` locates the corresponding entry in the data collection and removes it from the source.

![Delete Record](../images/urladaptor-delete-record.png)

{% tabs %}
{% highlight cs tabtitle="GridController.cs" %}

/// <summary>
/// Removes an existing record from the data collection based on the primary key.
/// </summary>
/// <param name="deletedRecord">
/// Contains the primary key value provided in the <c>key</c> property.
/// </param>
/// <returns>
/// Returns void.
/// </returns>
[HttpPost("Remove")]
public void Remove([FromBody] CRUDModel<OrdersDetails> deletedRecord)
{
    if (deletedRecord.key == null) return;

    if (int.TryParse(deletedRecord.key.ToString(), out var orderId))
    {
        var target = OrdersDetails.GetAllRecords()
            .FirstOrDefault(or => or.OrderID == orderId);

        if (target != null)
        {
            OrdersDetails.GetAllRecords().Remove(target);
        }
    }
}  
{% endhighlight %}
{% endtabs %}

### Single method for all CRUD operations

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports a unified CRUD workflow through the [CrudUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_CrudUrl) property. This configuration enables a single API endpoint to process **insert**, **update**, and **delete** actions based on the action field contained in the **CRUDModel<T>** instance.

* When action is **insert**, the API adds the record provided in the `value` property.
* When action is **update**, the API modifies the matching record in the data collection by applying the field values provided in the `value` property.
* When action is **remove**, the API removes the record identified by the `key` property.

This approach centralizes server‑side logic and simplifies request routing for CRUD operations.

![UrlAdaptor CRUD operations](../images/adaptor-crud-operation.gif)

{% tabs %}
{% highlight cs tabtitle="GridController.cs" %}
/// <summary>
/// Executes insert, update, or remove operations based on the specified action.
/// </summary>
/// <param name="request">
/// Contains the CRUD action in <c>action</c>, the record data in <c>value</c>,
/// and the primary key in <c>key</c>.
/// </param>
/// <returns>
/// Returns void.
/// </returns>
[HttpPost("CrudUpdate")]
public void CrudUpdate([FromBody] CRUDModel<OrdersDetails> request)
{
    if (request == null) return;

    if (request.action == "insert" && request.value != null)
    {
        OrdersDetails.GetAllRecords().Insert(0, request.value);
    }
    else if (request.action == "update" && request.value != null)
    {
        var updated = request.value;
        var target = OrdersDetails.GetAllRecords()
            .FirstOrDefault(or => or.OrderID == updated.OrderID);

        if (target != null)
        {
            target.OrderID = updated.OrderID;
            target.CustomerID = updated.CustomerID;
            target.ShipCity = updated.ShipCity;
            target.ShipCountry = updated.ShipCountry;
        }
    }
    else if (request.action == "remove" && request.key != null)
    {
        if (int.TryParse(request.key.ToString(), out var orderId))
        {
            var toRemove = OrdersDetails.GetAllRecords()
                .FirstOrDefault(or => or.OrderID == orderId);

            if (toRemove != null)
            {
                OrdersDetails.GetAllRecords().Remove(toRemove);
            }
        }
    }
}
{% endhighlight %}

{% highlight razor tabtitle="Home.razor" %}
<SfGrid TValue="OrdersDetails"
        Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })"
        Height="348">
    <SfDataManager Url="https://localhost:xxxx/api/grid"
                   CrudUrl="https://localhost:xxxx/api/grid/CrudUpdate"
                   Adaptor="Adaptors.UrlAdaptor">
    </SfDataManager>
    <GridEditSettings AllowEditing="true"
                      AllowDeleting="true"
                      AllowAdding="true"
                      Mode="EditMode.Normal">
    </GridEditSettings>
    <GridColumns>
        <GridColumn Field="OrderID"
                    HeaderText="Order ID"
                    IsPrimaryKey="true"
                    Width="100"
                    TextAlign="TextAlign.Right">
        </GridColumn>
        <GridColumn Field="CustomerID"
                    HeaderText="Customer Name"
                    Width="100">
        </GridColumn>
        <GridColumn Field="ShipCity"
                    HeaderText="Ship City"
                    Width="100">
        </GridColumn>
        <GridColumn Field="ShipCountry"
                    HeaderText="Ship Country"
                    Width="120">
        </GridColumn>
    </GridColumns>
</SfGrid>
{% endhighlight %}
{% endtabs %}

### Batch operation

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports batch editing through the [BatchUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_BatchUrl) property, enabling multiple inserts, updates, and deletions to be committed in a single request. When batch mode is enabled using the edit [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Mode) property set to [EditMode.Batch](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.EditMode.html), all changes are stored locally until the update action is triggered.

The server receives a **CRUDModel<T>** instance containing three optional collections:

* **added** — records to be inserted
* **changed** — records to be updated
* **deleted** — records to be removed

The API endpoint mapped through `BatchUrl` processes these collections sequentially, updating the underlying data collection to reflect all modifications in a single operation.

![UrlAdaptor - Batch Editing](../images/urladaptor-batch-editing.gif)

{% tabs %}
{% highlight cs tabtitle="GridController.cs" %}

/// <summary>
/// Applies batch insert, update, and delete operations in a single request.
/// </summary>
/// <param name="batchModel">
/// Contains the batch payload, including <c>added</c>, <c>changed</c>, and <c>deleted</c> collections.
/// </param>
/// <returns>
/// Returns a JSON result containing the processed batch payload.
/// </returns>
[HttpPost("BatchUpdate")]
public IActionResult BatchUpdate([FromBody] CRUDModel<OrdersDetails> batchModel)
{
    if (batchModel.added != null)
    {
        foreach (var record in batchModel.added)
        {
            OrdersDetails.GetAllRecords().Insert(0, record);
        }
    }

    if (batchModel.changed != null)
    {
        foreach (var changed in batchModel.changed)
        {
            var target = OrdersDetails.GetAllRecords()
                .FirstOrDefault(or => or.OrderID == changed.OrderID);

            if (target != null)
            {
                target.OrderID = changed.OrderID;
                target.CustomerID = changed.CustomerID;
                target.ShipCity = changed.ShipCity;
                target.ShipCountry = changed.ShipCountry;
            }
        }
    }

    if (batchModel.deleted != null)
    {
        foreach (var deleted in batchModel.deleted)
        {
            var toRemove = OrdersDetails.GetAllRecords()
                .FirstOrDefault(or => or.OrderID == deleted.OrderID);

            if (toRemove != null)
            {
                OrdersDetails.GetAllRecords().Remove(toRemove);
            }
        }
    }

    return new JsonResult(batchModel);
}

{% endhighlight %}

{% highlight razor tabtitle="Home.razor" %}
<SfGrid TValue="OrdersDetails"
        Toolbar="@(new List<string>() { "Add", "Delete", "Update", "Cancel" })"
        Height="348">
    <SfDataManager Url="https://localhost:xxxx/api/grid"
                   BatchUrl="https://localhost:xxxx/api/grid/BatchUpdate"
                   Adaptor="Adaptors.UrlAdaptor">
    </SfDataManager>
    <GridEditSettings AllowEditing="true"
                      AllowDeleting="true"
                      AllowAdding="true"
                      Mode="EditMode.Batch">
    </GridEditSettings>
    <GridColumns>
        <GridColumn Field="OrderID"
                    HeaderText="Order ID"
                    IsPrimaryKey="true"
                    Width="100"
                    TextAlign="TextAlign.Right">
        </GridColumn>
        <GridColumn Field="CustomerID"
                    HeaderText="Customer Name"
                    Width="100">
        </GridColumn>
        <GridColumn Field="ShipCity"
                    HeaderText="Ship City"
                    Width="100">
        </GridColumn>
        <GridColumn Field="ShipCountry"
                    HeaderText="Ship Country"
                    Width="120">
        </GridColumn>
    </GridColumns>
</SfGrid>
{% endhighlight %}
{% endtabs %}

## See also

A complete sample is available at this [GitHub location](https://github.com/SyncfusionExamples/Binding-data-from-remote-service-to-blazor-data-grid/tree/master/UrlAdaptor).