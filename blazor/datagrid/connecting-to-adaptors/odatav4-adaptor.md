---
layout: post
title: Bind data and perform CRUD using ODataV4Adaptor in Syncfusion DataGrid
description: Learn about bind data and performing CRUD operations using ODataV4Adaptor in Syncfusion Blazor DataGrid.
platform: Blazor
control: DataGrid
keywords: adaptors, ODataV4adaptor, ODataV4 adaptor, remotedata 
documentation: ug
---

# Remote Data Binding with ODataV4Adaptor in Syncfusion Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor `DataGrid` integrates with OData V4 services using the [ODataV4Adaptor](https://blazor.syncfusion.com/documentation/data/adaptors#odatav4-adaptor). This adaptor enables the DataGrid to communicate with **RESTful endpoints** that expose structured data through the **OData V4 protocol**. It manages query translation, request formatting, server‑side execution, and response processing, providing a consistent workflow for large data collections.

This section describes how to configure the DataGrid to connect to an OData V4 service, and how server‑side operations such as **filtering**, **sorting**, **paging**, **searching**, and **CRUD** operations are executed using the `ODataV4Adaptor`.

## What Is OData V4?

* **OData V4 (Open Data Protocol Version 4)** is a REST‑based data access standard used for querying and modifying structured collections over **HTTP**. The protocol defines consistent URL formats, query options, payload structures, and metadata rules that support predictable communication with remote data services.

* OData V4 supports server‑side data operations such as **filtering**, **sorting**, **paging**, and selecting specific fields through standardized query parameters including `$filter`, `$orderby`, `$skip`, `$top`, and `$select`.

* OData V4 uses the **Entity Data Model (EDM)** to define the structure and relationships of the exposed data, ensuring a consistent representation of entity types and their properties.

## Why Choose ODataV4Adaptor for Remote Data Binding?

The `ODataV4Adaptor` provides built‑in support for connecting the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid to APIs that implement the OData V4 protocol. The adaptor converts DataGrid operations—such as **filtering**, **sorting**, **paging**, **grouping**, **searching**, and **CRUD** actions—into OData‑compliant query parameters, ensuring that all operations are processed at the server. This improves performance, reduces client‑side load, and allows consistent handling of large data collections.

The adaptor also manages request formatting, metadata interpretation, and response parsing in alignment with OData V4 standards. This ensures that DataGrid binding behaves consistently with the underlying RESTful service and supports enterprise‑grade data operations.

**Key Advantages of ODataV4Adaptor**

* **Standards‑based integration**: Supports APIs built on the OData V4 protocol, ensuring compatibility with widely adopted enterprise systems.

* **Server‑side Data Processing**: Transforms DataGrid actions such as **filtering**, **sorting**, **paging**, **searching**, and **CRUD** into OData‑compliant queries, including `$filter`, `$orderby`, `$top`, `$skip`, `$select`, and `$count`, enabling high‑performance remote data processing.

* **Automatic metadata‑driven behavior**: Leverages OData metadata (CSDL) to understand entity structure, field types, and relationships, reducing manual configuration.

* **Optimized for large datasets**: Delegates heavy operations to the API, minimizing browser memory usage and improving responsiveness. OData also supports pagination and delta queries, which help manage large data efficiently.

* **RESTful and JSON‑friendly**: Works seamlessly with modern web architectures, following standardized URL conventions, HTTP operations, and JSON payload formats defined by OData.

* **Low‑Code Integration**: Removes the need for custom query building or URL formatting by managing request construction and response parsing internally.

* **Cross‑platform compatibility**: Supported by any client that implements OData v4, making it suitable for enterprise‑level integration across multiple platforms.

* **Search Fallback Mechanism**: Enables global search by generating OData `$filter` queries across multiple fields, providing search support even though OData V4 does not include a native search operator.

## Who Should Use ODataV4Adaptor?

The `ODataV4Adaptor` is suitable for applications that retrieve data from **OData V4–compliant services** and require server‑executed data operations in the Syncfusion Blazor DataGrid. It is intended for:

* **Applications built on OData V4 services** provided by frameworks such as ASP.NET Core OData, SAP OData endpoints, or Microsoft Dynamics services. OData V4 is an open, standardized REST protocol that defines structured querying, metadata, and JSON payload formats.

* **Projects requiring remote data processing**, where **filtering**, **sorting**, **paging**, **searching**, and **CRUD** actions must be handled by the server through OData query options. OData V4 supports server‑side query evaluation to improve scalability.

* **Enterprise applications dependent on metadata‑driven models**, leveraging OData’s CSDL schema to describe entities, relationships, and data types for consistent integration.

* **Solutions working with large datasets**, where delegating processing to the API improves performance and reduces client‑side overhead. OData’s design supports efficient server‑processed workflows.

* **Systems requiring interoperability across multiple clients**, as OData V4 services can be consumed by any compliant client using standardized URL conventions and JSON formatting.

## Setting up the API service for ODataV4Adaptor

This section explains how to create and configure an OData v4 service in the Server project of a **Blazor Web App**, supporting the data operations and CRUD functionality required by `ODataV4Adaptor` for remote data binding.

### Expected JSON response structure for ODataV4Adaptor APIs

The `ODataV4Adaptor` requires the API to return data in the standard OData V4 JSON format. The response must contain:

* **value** — a collection of entities returned from the request
* **@odata.context** — the metadata URL describing the entity set
* **@odata.count** (optional) — the total number of records when `$count=true` is requested

A typical OData V4 response for the DataGrid appears as:

```json
{
  "@odata.context": "https://localhost:xxxx/odata/$metadata#Grid",
  "value": [
    {
      "OrderID": 10248,
      "CustomerID": "VINET",
      "EmployeeID": 5,
      "ShipCountry": "France"
    }
  ],
  "@odata.count": 830
}
```

### Step 1: Create a Blazor web app

A **Blazor Web App** is required to host the API service that exposes the OData V4 endpoint for communication with the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid. The application can be created using **Visual Studio 2026** with the [Microsoft Blazor templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

**Steps to create the Blazor Web App**

1. Open **Visual Studio 2026**.
2. Select **Create a new project**.
3. Choose the **Blazor Web App** template.
4. Enter the project name as **ODataV4Adaptor**.
5. Choose a project location.
6. Select the appropriate .NET runtime version.
7. Configure the [interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-10.0#render-modes) based on project requirements.
8. Set the [interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) to **Per page/component** or **Global**.
9. Create the project.

For more guidance, refer to the [Microsoft documentation](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs).

> This Blazor Web App is configured to use **Auto** render mode, with the OData v4 service defined in the Server project.

### Step 2: Install NuGet Packages

Install the [Microsoft.AspNetCore.OData](https://www.nuget.org/packages/Microsoft.AspNetCore.OData/10.0.0-preview.2) package in the Server project of the Blazor Web App. This package provides OData v4 support and enables the project to expose an OData‑compliant endpoint used by `ODataV4Adaptor` for remote data binding, data operations, and CRUD functionality.

**Method 1: Using Package Manager Console**

1. Navigate to **Tools → NuGet Package Manager → Package Manager Console**.
2. Run the command:

```powershell

Install-Package Microsoft.AspNetCore.OData

```
**Method 2: Using NuGet Package Manager UI**

1. Navigate to **Tools → NuGet Package Manager → Manage NuGet Packages for Solution**.
2. Search for and install:

    * [Microsoft.AspNetCore.OData](https://www.nuget.org/packages/Microsoft.AspNetCore.OData/10.0.0-preview.2)

### Step 3: Create a Model Class
 
Create a **Models** folder and add a model class named **OrdersDetails.cs** under **ODataV4Adaptor.Client**. This class defines the entity structure and provides an in‑memory data source used by the OData endpoint.
 
{% tabs %}
{% highlight cs tabtitle="OrdersDetails.cs" %}

using System.ComponentModel.DataAnnotations;

namespace ODataV4Adaptor.Client.Models
{
    /// <summary>
    /// Represents an order entity and provides an in-memory seeded collection.
    /// </summary>
    public class OrdersDetails
    {
        // In-memory data store for demo purposes.
        private static readonly List<OrdersDetails> _orders = new();

        /// <summary>
        /// Initializes a new instance of the <see cref="OrdersDetails"/> class.
        /// </summary>
        public OrdersDetails()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="OrdersDetails"/> class with values.
        /// </summary>
        public OrdersDetails(int OrderID, string CustomerId, int EmployeeId, string ShipCountry)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerId;
            this.EmployeeID = EmployeeId;
            this.ShipCountry = ShipCountry;
        }

        /// <summary>
        /// Returns the seeded collection of orders, creating it on first access.
        /// </summary>
        public static List<OrdersDetails> GetAllRecords()
        {
            if (_orders.Count == 0)
            {
                int Code = 10000;
                for (int I = 1; I < 10; I++)
                {
                    _orders.Add(new OrdersDetails(Code + 1, "ALFKI", I,     "Denmark"));
                    _orders.Add(new OrdersDetails(Code + 2, "ANATR", I + 2, "Brazil"));
                    _orders.Add(new OrdersDetails(Code + 3, "ANTON", I + 1, "Germany"));
                    _orders.Add(new OrdersDetails(Code + 4, "BLONP", I + 3, "Austria"));
                    _orders.Add(new OrdersDetails(Code + 5, "BOLID", I + 4, "Switzerland"));
                    Code += 5;
                }
            }

            return _orders;
        }

        [Key]
        public int OrderID { get; set; }

        public string? CustomerID { get; set; }

        public int? EmployeeID { get; set; }

        public string? ShipCountry { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

### Step 4: Build the Entity Data Model

The Entity Data Model (EDM) defines the structure of the OData service and determines how the entity type is exposed to clients. Build the EDM in the **Program.cs** file of the server project by using the `ODataConventionModelBuilder` to register the **OrdersDetails** entity type as an entity set named **Grid**. The generated model is used by the OData pipeline when processing queries.

```csharp
using Microsoft.OData.ModelBuilder;
// Create an ODataConventionModelBuilder to build the OData model.
var modelBuilder = new ODataConventionModelBuilder();

// Register the "Grid" entity set with the OData model builder.
modelBuilder.EntitySet<OrdersDetails>("Grid");
```

### Step 5: Register OData services

Register the OData services in the **Program.cs** file of the server project to enable OData routing and query processing. The configuration adds controller support, enables required OData query options, and maps the OData route by using the EDM model created in the previous step.

```cs
// Add controllers with OData support to the service collection.
builder.Services.AddControllers().AddOData(
    options => options
        .Count()                                 // Enables $count query option to retrieve total record count.
        .AddRouteComponents("odata", modelBuilder.GetEdmModel())
);

```
 
### Step 6: Create an API Controller
 
Create a **GridController.cs** file in the **Controllers** folder of the server‑side project. This controller exposes the OData V4 endpoint and returns the entity collection for processing by the OData pipeline.
 
{% tabs %}
{% highlight cs tabtitle="GridController.cs" %}
 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ODataV4Adaptor.Client.Models;

namespace ODataV4Adaptor.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GridController : ControllerBase
    {
        /// <summary>
        /// Retrieves the complete entity collection exposed by the OData service.
        /// </summary>
        /// <returns>The entity collection.</returns>
        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            IQueryable<OrdersDetails> data = OrdersDetails.GetAllRecords().AsQueryable();
            return Ok(data);
        }
    }
}
 
{% endhighlight %}
{% endtabs %}

### Step 7: Register Controllers in Program.cs
 
Map the controller routes in the **Program.cs** file of the server‑side project to enable routing for the OData V4 endpoint

```csharp

// Map controller routes.
app.MapControllers();
```

### Step 8: Run the Application

Run the application in Visual Studio. The API will be accessible at a URL similar to: **https://localhost:xxxx/odata/grid**(where **xxxx** represents the port number).

![ODataV4Adaptor Data](../images/odatav4-adaptors-data.png)

## Integrating ODataV4Adaptor with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can be integrated with an OData V4 service by configuring [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html) with a remote endpoint and the `ODataV4Adaptor`. This configuration enables the DataGrid to retrieve data, perform server‑side operations, and process CRUD actions through the OData V4 service.

### Step 1: Install Syncfusion<sup style="font-size:70%">&reg;</sup> Packages

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid requires the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor component packages to be installed in the Client project.

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

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service must be registered in the project configuration to enable component rendering.

Add the required namespaces in the **_Imports.razor** file:

```cs
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
```

Register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in **Program.cs**:

```csharp
using Syncfusion.Blazor;

builder.Services.AddSyncfusionBlazor();
```

> For Blazor Web App configurations using **WebAssembly** or **Auto** render modes, the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service must be registered in both the **Client** and **Server** projects.

### Step 3: Add stylesheet and script resources

Add the required theme stylesheet and script references in **~/Components/App.razor**.

```html
<head>
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

<body>

    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

>* For this project, the **bootstrap5** theme is used. A different theme can be selected or the existing theme can be customized based on project requirements. Refer to the [Syncfusion Blazor Components Appearance](https://blazor.syncfusion.com/documentation/appearance/themes) documentation to learn more about theming and customization options.
>* For script reference options, see [Adding Script References](https://blazor.syncfusion.com/documentation/common/adding-script-references) documentation.

### Step 4: Add Blazor DataGrid and Configure with Server

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid establishes remote communication with OData V4 services through the [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html) component. Assigning the service endpoint to the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Url) property defines the entry point for retrieving data, while configuring the [Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Adaptor) property with [ODataV4Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Adaptors.html#Syncfusion_Blazor_Adaptors_ODataV4Adaptor) enables server‑executed operations. This configuration ensures that data actions and CRUD operations are processed according to OData V4 query conventions.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using ODataV4Adaptor.Client.Models;

<SfGrid TValue="OrdersDetails" Height="348">
    <SfDataManager Url="https://localhost:xxxx/odata/grid"
                   Adaptor="Adaptors.ODataV4Adaptor">
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
        <GridColumn Field="EmployeeID"
                    HeaderText="Employee ID"
                    Width="100"
                    TextAlign="TextAlign.Right">
        </GridColumn>
        <GridColumn Field="ShipCountry"
                    HeaderText="Ship Country"
                    Width="120">
        </GridColumn>
    </GridColumns>
</SfGrid>
 
{% endhighlight %}
{% endtabs %}
 
> Replace the placeholder URL (**https://localhost:xxxx/odata/grid**) with an endpoint that returns data in JSON format compatible with OData V4.
 
### Step 5: Run the application
 
Running the application starts the OData V4 service and enables the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid to retrieve data from the configured endpoint. After the service becomes accessible, the Grid loads the JSON response through the `DataManager` component and renders the data obtained from the OData V4 service.

![ODataV4Adaptor Data](../images/blazor-odatav4-adaptors.gif)

> Replace the placeholder URL (**https://localhost:xxxx/odata/**) with the actual endpoint of the OData V4 service.

## Perform data operations in ODataV4Adaptor

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports server‑side operations such as searching, sorting, filtering, paging, and CRUD operations. The `ODataV4Adaptor` transforms these operations into OData‑compliant queries, ensuring that all data actions are processed on the server according to OData V4 standards.

**OData V4 query parameters**

| Operation   | OData V4 Query Parameters | Use Case |
|-------------|----------------------------|------------------------------|
| Searching   | `$filter `(field-level predicates) | Locate records containing matching text. |
| Filtering   | `$filter` | Retrieve records that satisfy field conditions. |
| Sorting     | `$orderby` | Arrange records in ascending or descending order. |
| Paging      | `$skip`, `$top`, optional `$count=true` | Fetch only the records required for the current page. |

The adaptor ensures efficient communication between the DataGrid and the OData service by generating appropriate query parameters for each operation, reducing client-side processing and improving performance for large datasets.

### Searching

OData V4 does not include a built‑in global search operator. The `ODataV4Adaptor` provides a search fallback mechanism that enables global search behavior by generating OData `$filter` expressions across multiple fields when the `EnableODataSearchFallback` option is enabled. This mechanism allows the DataGrid to perform search operations by delegating predicate evaluation to the OData service.

To enable search support, the OData service must allow filtering by including the **Filter** option during service configuration. Once enabled, the service processes `$filter` parameters generated by the DataGrid during search actions.

{% tabs %}
{% highlight cs tabtitle="Program.cs" %}

// Create a new instance of the web application builder.
var builder = WebApplication.CreateBuilder(args);

// Create an ODataConventionModelBuilder to build the OData model.
var modelBuilder = new ODataConventionModelBuilder();

// Register the "Grid" entity set with the OData model builder.
modelBuilder.EntitySet<OrdersDetails>("Grid");

// Add services to the container.
// Add controllers with OData support to the service collection.
builder.Services.AddControllers().AddOData(
    options => options
    // Enables $count query option to retrieve total record count.
    .Count()
    // Enables $filter query option to allow searching based on field values.
    .Filter()
    .AddRouteComponents("odata", modelBuilder.GetEdmModel()
)
);

{% endhighlight %}
{% highlight razor tabtitle="Home.razor" %}

@using ODataV4Adaptor.Client.Models

<SfGrid TValue="OrdersDetails" Toolbar="@(new List<string>() { "Search" })" Height="348">
    <SfDataManager @ref="DataManager"
                   Url="https://localhost:xxxx/odata/grid"
                   Adaptor="Adaptors.ODataV4Adaptor">
    </SfDataManager>
    <GridColumns>
        <GridColumn Field="OrderID"
                    HeaderText="Order ID"
                    Width="100"
                    TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field="CustomerID"
                    HeaderText="Customer Name"
                    Width="100"></GridColumn>
        <GridColumn Field="EmployeeID"
                    HeaderText="Employee ID"
                    TextAlign="TextAlign.Right"
                    Width="100"></GridColumn>
        <GridColumn Field="ShipCountry"
                    HeaderText="Ship Country"
                    Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public SfDataManager? DataManager { get; set; }

    /// <summary>
    /// Enables OData search fallback after the initial render when the DataManager is available.
    /// Lifecycle methods first; members grouped and ordered for readability.
    /// </summary>
    /// <param name="firstRender">Indicates first render.</param>
    protected override void OnAfterRender(bool firstRender)
    {
        base.OnAfterRender(firstRender);

        if (DataManager?.DataAdaptor is ODataV4Adaptor odataAdaptor)
        {
            RemoteOptions options = odataAdaptor.Options;
            options.EnableODataSearchFallback = true;
            odataAdaptor.Options = options;
        }
    }
}

{% endhighlight %}
{% endtabs %}

![ODataV4Adaptor - Searching](../images/odatav4-adaptor-searching.png)

### Filtering

The `ODataV4Adaptor` processes filtering operations by generating OData‑compatible `$filter` expressions. These expressions are evaluated on the server to return records that satisfy the defined filter conditions. Filtering requires the OData service to enable the `Filter` option so the server can process `$filter` expressions generated by the Grid. 

Filtering is enabled in the DataGrid by setting the [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowFiltering) property to **true**.

{% tabs %}
{% highlight cs tabtitle="Program.cs" %}

// Create a new instance of the web application builder.
var builder = WebApplication.CreateBuilder(args);

// Create an ODataConventionModelBuilder to build the OData EDM model.
var modelBuilder = new ODataConventionModelBuilder();

// Register the "Grid" entity set in the OData model.
modelBuilder.EntitySet<OrdersDetails>("Grid");

// Add controllers with OData support to the service collection.
builder.Services.AddControllers().AddOData(
    options => options
        // Enables $count query option to retrieve total record count.
        .Count()
        // Enables $filter query option to allow filtering based on field values.
        .Filter()
        .AddRouteComponents("odata", modelBuilder.GetEdmModel()));

{% endhighlight %}
{% highlight razor tabtitle="Home.razor" %}

@using ODataV4Adaptor.Client.Models

<SfGrid TValue="OrdersDetails"
        AllowFiltering="true"
        Height="348">
    <SfDataManager Url="https://localhost:xxxx/odata/grid"
                   Adaptor="Adaptors.ODataV4Adaptor">
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
        <GridColumn Field="EmployeeID"
                    HeaderText="Employee ID"
                    Width="100"
                    TextAlign="TextAlign.Right">
        </GridColumn>
        <GridColumn Field="ShipCountry"
                    HeaderText="Ship Country"
                    Width="120">
        </GridColumn>
    </GridColumns>
</SfGrid>

{% endhighlight %}
{% endtabs %}

**Single column filtering**
![Single column filtering](../images/odatav4-adaptor-filtering.png)

**Multi column filtering**
![Multi column filtering](../images/odatav4-adaptor-multi-filtering.png)

## Sorting

The `ODataV4Adaptor` processes sorting operations by generating OData‑compliant `$orderby` expressions. These expressions are evaluated on the server to return records arranged in **ascending** or **descending** order based on the selected column. Sorting requires the OData service to enable the `OrderBy` option so the server can process `$orderby` expressions generated by the Grid.

Sorting is enabled in the DataGrid by setting the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) property to **true**.

{% tabs %}
{% highlight cs tabtitle="Program.cs" %}

using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using ODataV4Adaptor.Client.Models;

var builder = WebApplication.CreateBuilder(args);

// Build the OData EDM model
var modelBuilder = new ODataConventionModelBuilder();
modelBuilder.EntitySet<OrdersDetails>("Grid");

// Add controllers with OData support to the service collection.
builder.Services
    .AddControllers()
    .AddOData(options => options
        // Enables $count query option to retrieve the total record count.
        .Count()
        // Enables $orderby query option to allow sorting based on field values.
        .OrderBy()
        .AddRouteComponents("odata", modelBuilder.GetEdmModel()));

var app = builder.Build();

app.MapControllers();

app.Run();
{% endhighlight %}
{% highlight razor tabtitle="Home.razor" %}

@using ODataV4Adaptor.Client.Models
 
<SfGrid TValue="OrdersDetails"
        AllowSorting="true"
        Height="348">
    <SfDataManager Url="https://localhost:xxxx/odata/grid"
                   Adaptor="Adaptors.ODataV4Adaptor">
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
        <GridColumn Field="EmployeeID"
                    HeaderText="Employee ID"
                    Width="100"
                    TextAlign="TextAlign.Right">
        </GridColumn>
        <GridColumn Field="ShipCountry"
                    HeaderText="Ship Country"
                    Width="120">
        </GridColumn>
    </GridColumns>
</SfGrid>

{% endhighlight %}
{% endtabs %}

**Single column sorting**
![Single column sorting](../images/odatav4-adaptor-sorting.png)

**Multi column sorting**
![Multi column sorting](../images/odatav4-adaptor-multi-sorting.png)

### Paging

The `ODataV4Adaptor` processes paging by generating OData‑compliant `$skip` and `$top` parameters. These parameters are evaluated on the server to return the subset of records required for the current page. The OData configuration must support the `$top` and `$skip` query options so the service can return paged results efficiently. The `SetMaxTop` method must be added in the OData setup to specify the maximum record count allowed for `$top`, ensuring controlled server‑side paging.

Paging is enabled in the DataGrid by setting the [AllowPaging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowPaging) property to **true**.

{% tabs %}
{% highlight cs tabtitle="Program.cs" %}

using Microsoft.AspNetCore.OData;
using Microsoft.OData.ModelBuilder;
using ODataV4Adaptor.Client.Models;

var builder = WebApplication.CreateBuilder(args);

// Create an ODataConventionModelBuilder to build the OData EDM model.
var modelBuilder = new ODataConventionModelBuilder();

// Register the "Grid" entity set in the OData model.
modelBuilder.EntitySet<OrdersDetails>("Grid");

// Add controllers with OData support to the service collection.
builder.Services
    .AddControllers()
    .AddOData(options => options
        // Enables $count query option to retrieve the total record count.
        .Count()
        // Enables $top and $skip query options for server-side paging.
        .SetMaxTop(1000) // Example upper bound; adjust based on requirements
        .AddRouteComponents("odata", modelBuilder.GetEdmModel()));

var app = builder.Build();

app.MapControllers();

app.Run();

{% endhighlight %}
{% highlight razor tabtitle="Home.razor" %}

@using ODataV4Adaptor.Client.Models

<SfGrid TValue="OrdersDetails"
        AllowPaging="true"
        Height="348">
    <SfDataManager Url="https://localhost:xxxx/odata/grid"
                   Adaptor="Adaptors.ODataV4Adaptor">
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
        <GridColumn Field="EmployeeID"
                    HeaderText="Employee ID"
                    Width="100"
                    TextAlign="TextAlign.Right">
        </GridColumn>
        <GridColumn Field="ShipCountry"
                    HeaderText="Ship Country"
                    Width="120">
        </GridColumn>
    </GridColumns>
</SfGrid>

{% endhighlight %}
{% endtabs %}

![ODataV4Adaptor - Paging](../images/odatav4-adaptor-paging.png)

## Perform CRUD operations in ODataV4Adaptor

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports **Create**, **Read**, **Update**, and **Delete** (**CRUD**) operations when configured with the `ODataV4Adaptor`. CRUD requests generated by the DataGrid are translated into OData‑compliant endpoint calls, and the server processes these operations through the corresponding **HTTP methods** defined in the controller.

**CRUD mapping overview**

| DataGrid Action | HTTP Method | Use Case |
|-----------------|-------------|----------|
| Read            | `GET`         | Returns the entity collection. |
| Create          | `POST`        | Adds a new entity to the collection. |
| Update          | `PATCH`       | Updates the entity matching the key. |
| Delete          | `DELETE`      | Removes the entity matching the key. |

To enable editing in the DataGrid, configure the [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) and [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Toolbar) properties to allow adding, editing, and deleting records.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using ODataV4Adaptor.Client.Models

<SfGrid TValue="OrdersDetails"
        Toolbar="@(new List<string> { "Add", "Edit", "Delete", "Update", "Cancel" })"
        Height="348">
    <SfDataManager Url="https://localhost:xxxx/odata/grid"
                   Adaptor="Adaptors.ODataV4Adaptor">
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

> > Normal or Inline editing is the default edit `Mode` for the DataGrid. To enable CRUD operations, ensure the [IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsPrimaryKey) property is set to **true** for a unique column.

### Insert operation

To insert a new record, implement the `HttpPost` method in the **GridController** class. This method accepts the incoming entity and adds it to the data collection.

{% tabs %}
{% highlight cs tabtitle="GridController.cs" %}

/// <summary>
/// Inserts a new order into the data collection.
/// </summary>
/// <param name="addRecord">The order entity to insert.</param>
/// <returns>
/// 201 (Created) with the inserted entity on success;
/// 400 (Bad Request) if the payload is null;
/// 409 (Conflict) if an entity with the same key already exists.
/// </returns>
[HttpPost]
[EnableQuery]
public IActionResult Post([FromBody] OrdersDetails addRecord)
{
    // Validate request payload.
    if (addRecord is null)
    {
        return BadRequest("The insert payload cannot be null.");
    }

    // Validate primary key uniqueness (conflict if the key already exists).
    var records = OrdersDetails.GetAllRecords();
    bool keyExists = records.Any(o => o.OrderID == addRecord.OrderID);
    if (keyExists)
    {
        return Conflict($"An order with key '{addRecord.OrderID}' already exists.");
    }

    // Insert at the beginning for deterministic sample behavior.
    records.Insert(0, addRecord);

    // Return 201 Created with the inserted entity.
    // If a GET-by-key route exists, CreatedAtAction can reference it; otherwise Created is acceptable.
    return Created(string.Empty, addRecord);
}

{% endhighlight %}
{% endtabs %}

![Insert Record](../images/odatav4-adaptor-insert-record.png)

### Update operation

To update an existing record, implement the `HttpPatch` method in the **GridController** class. This method identifies the target record by its key and applies the provided values to the data collection.

{% tabs %}
{% highlight cs tabtitle="GridController.cs" %}

/// <summary>
/// Updates an existing order identified by the specified key using partial update (PATCH).
/// </summary>
/// <param name="key">The primary key of the order to update.</param>
/// <param name="updateRecord">The payload containing fields to update.</param>
/// <returns>
/// 200 (OK) with the updated entity on success; 400 (Bad Request) if the payload is null;
/// 404 (Not Found) if the entity does not exist.
/// </returns>
[HttpPatch("{key}")]
public IActionResult Patch(int key, [FromBody] OrdersDetails updateRecord)
{
    // Validate request payload.
    if (updateRecord is null)
    {
        return BadRequest("The update payload cannot be null.");
    }

    // Locate the existing entity by key.
    var existingOrder = OrdersDetails
        .GetAllRecords()
        .FirstOrDefault(order => order.OrderID == key);

    if (existingOrder is null)
    {
        return NotFound($"Order with key '{key}' was not found.");
    }

    // Apply partial updates (only non-null fields are applied).
    if (updateRecord.CustomerID is not null)
    {
        existingOrder.CustomerID = updateRecord.CustomerID;
    }

    if (updateRecord.EmployeeID.HasValue)
    {
        existingOrder.EmployeeID = updateRecord.EmployeeID;
    }

    if (updateRecord.ShipCountry is not null)
    {
        existingOrder.ShipCountry = updateRecord.ShipCountry;
    }

    // Return the updated entity.
    return Ok(existingOrder);
}

{% endhighlight %}
{% endtabs %}

![Update Record](../images/odatav4-adaptor-update-record.png)

### Delete operation

To delete an existing record, implement the `HttpDelete` method in the **GridController** class. This method locates the target record by its key, removes it from the data collection, and returns the deleted entity.

{% tabs %}
{% highlight cs tabtitle="GridController.cs" %}

/// <summary>
/// Deletes an existing order identified by the specified key.
/// </summary>
/// <param name="key">The primary key of the order to delete.</param>
/// <returns>
/// 200 (OK) with the deleted entity on success;
/// 404 (Not Found) if the entity does not exist.
/// </returns>
[HttpDelete("{key}")]
public IActionResult Delete(int key)
{
    // Locate the entity by key.
    var existingOrder = OrdersDetails
        .GetAllRecords()
        .FirstOrDefault(order => order.OrderID == key);

    // Return 404 if the entity does not exist.
    if (existingOrder is null)
    {
        return NotFound($"Order with key '{key}' was not found.");
    }

    // Remove the entity from the collection.
    OrdersDetails.GetAllRecords().Remove(existingOrder);

    // Return the deleted entity.
    return Ok(existingOrder);
}

{% endhighlight %}
{% endtabs %}

![Delete Record](../images/odatav4-adaptor-delete-record.png)

## See also

A complete sample is available at this [GitHub location](https://github.com/SyncfusionExamples/Binding-data-from-remote-service-to-blazor-data-grid/tree/master/ODataV4Adaptor).