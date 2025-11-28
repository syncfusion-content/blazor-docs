---
layout: post
title: Bind data and perform CRUD action with ODataV4Adaptor in Syncfusion Blazor DataGrid
description: Learn about bind data and performing CRUD operations using ODataV4Adaptor in Syncfusion Blazor DataGrid.
platform: Blazor
control: DataGrid
keywords: adaptors, ODataV4adaptor, ODataV4 adaptor, remotedata 
documentation: ug
---

# ODataV4Adaptor in Syncfusion Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports integration with **OData V4** services through the [ODataV4Adaptor](https://blazor.syncfusion.com/documentation/data/adaptors#odatav4-adaptor) in [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component. This adaptor enables efficient communication between the DataGrid and OData-compliant endpoints, allowing server-side operations such as **read**, **create**, **update**, and **delete**. It is designed for applications that require standardized querying and data manipulation using **OData** protocols.

The ODataV4Adaptor ensures:

- Seamless data binding with **OData V4** services.
- Support for query options such as **$filter**, **$orderby**, **$skip**, **$top**, and **$count**.
- Compatibility with CRUD operations through **HTTP** methods like **GET**, **POST**, **PATCH**, and **DELETE**.

## Configuring an OData V4 Service

To enable OData V4 integration with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, configure a server-side OData service as follows:

**1. Create a Blazor web app**

1. Open Visual Studio 2022.  
2. Choose **Blazor Web App** and name the project **ODataV4Adaptor**.
3. Use either [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-9.0&pivots=vs) or the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension to create the project.
4. Select the preferred [interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-9.0#render-modes) and [interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-9.0&pivots=vs).

**2. Install NuGet packages**

Install the **Microsoft.AspNetCore.OData** package using the NuGet Package Manager in Visual Studio:

*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*

**3. Create a model class**
 
Create a **Models** folder and add a class named **OrdersDetails.cs** under **ODataV4Adaptor.Client.Models** to represent order data:
 
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

**4. Build the Entity Data Model**

The **ODataConventionModelBuilder** in **Program.cs** defines the EDM:

```csharp
// Create an ODataConventionModelBuilder to build the OData model.
var modelBuilder = new ODataConventionModelBuilder();

// Register the "Grid" entity set with the OData model builder.
modelBuilder.EntitySet<OrdersDetails>("Grid");
```

**5. Register OData services**

Add OData services in **Program.cs**:

```cs
// Add controllers with OData support to the service collection.
builder.Services.AddControllers().AddOData(
    options => options
    .Count()
    .AddRouteComponents("odata", modelBuilder.GetEdmModel())
);
```
 
**6. Create an API controller**
 
Add **GridController.cs** under the **Controllers** folder to handle data operations.
 
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

**7. Register controllers in `Program.cs`**
 
```csharp
// Register controllers in the service container.
builder.Services.AddControllers();
 
// Map controller routes.
app.MapControllers();
```

**8. Run the application:**

Run the application in Visual Studio. The API will be available at a URL such as **https://localhost:xxxx/api/grid**, where **xxxx** represents the port number.

![ODataV4Adaptor Data](../images/odatav4-adaptors-data.png)

## Connecting Syncfusion Blazor DataGrid to an OData V4 Service

To bind the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid to a remote API using the [ODataV4Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Adaptors.html#Syncfusion_Blazor_Adaptors_ODataV4Adaptor), configure the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component with the API endpoint and adaptor type. The following steps outline the integration process:

**1. Install Required NuGet Packages**

* Install the required packages in the `ODataV4Adaptor.Client` project using the NuGet Package Manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), then search and install:

    - [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid/)
    - [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

* Alternatively, use the Package Manager Console:

```powershell
Install-Package Syncfusion.Blazor.Grid -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}
```

> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for a complete list of available packages.

**2. Register Syncfusion Blazor service**

- Add the required namespaces in **~/_Imports.razor**:

```cs
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
```

- For apps using **WebAssembly** or **Auto** (Server and WebAssembly) render modes, register the service in both **~/Program.cs** files.

```csharp
using Syncfusion.Blazor;

builder.Services.AddSyncfusionBlazor();
```

**3. Add stylesheet and script references**

Include the theme and script references in **App.razor**:

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>
....
<body>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

> * Refer to the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic for available methods to include themes, such as Static Web Assets, CDN, or CRG.
> * Set the render mode to **InteractiveServer** or **InteractiveAuto** in the Blazor Web App configuration.

**4. Configure DataGrid with ODataV4Adaptor**

The [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html) component provides multiple adaptors for remote data binding. For **OData V4** services, set the [Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Adaptor) property to [Adaptors.ODataV4Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Adaptors.html#Syncfusion_Blazor_Adaptors_ODataV4Adaptor) and specify the service endpoint in the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Url) property.

{% tabs %}
{% highlight razor tabtitle="Index.razor"%}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@using ODataV4Adaptor.Client.Models
 
<SfGrid TValue="OrderDetails" Height="348">
    <SfDataManager Url="https://localhost:xxxx/odata/grid" Adaptor="Adaptors.ODataV4Adaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" Width="100" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field="CustomerID" HeaderText="Customer Name" Width="100"></GridColumn>
        <GridColumn Field="EmployeeID" HeaderText="Employee ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field="ShipCountry" HeaderText="Ship Country" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
 
{% endhighlight %}
 
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
 
{% endhighlight %}
{% endtabs %}
 
> Replace **https://localhost:xxxx/odata/grid** with the actual API endpoint that returns data in **OData V4** format.
 
**5. Run the application**
 
When the application runs, the DataGrid displays data retrieved from the OData V4 service.

![ODataV4Adaptor Data](../images/blazor-odatav4-adaptors.gif)

## Perform data operations in ODataV4Adaptor

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports server-side operations such as **searching**, **sorting**, **filtering**, **paging**, and **CRUD** when connected to an **OData V4** service through the `ODataV4Adaptor`. These operations are executed on the server using **OData** query options:

* **$filter** – Applies **filter** conditions and **search** criteria from [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html) to the data source.
* **$orderby** – Applies **sort** descriptors from `DataManagerRequest` for **ascending** or **descending** order.
* **$skip, $top** – Applies **paging** details from `DataManagerRequest` to skip and retrieve records.
* **$count** – Requests the total record count for **paging** and **aggregation**.

The adaptor ensures efficient communication between the DataGrid and the **OData** service by generating appropriate query parameters for each operation, reducing client-side processing and improving performance for large datasets.

### Handling searching operation

**OData V4** does not natively support global search across all fields. To enable this functionality, configure the `EnableODataSearchFallback` option in the `ODataV4Adaptor`. This allows the Grid to perform a fallback search when the **$filter** query option cannot handle global search.

{% tabs %}
{% highlight cs tabtitle="program.cs" %}

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
{% highlight razor tabtitle="Index.razor"%}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@using ODataV4Adaptor.Client.Models
 
<SfGrid TValue="OrderDetails" Toolbar="@(new List<string>() { "Search" })" Height="348">
    <SfDataManager @ref="DataManager" Url="https://localhost:xxxx/odata/grid" Adaptor="Adaptors.ODataV4Adaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" Width="100" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field="CustomerID" HeaderText="Customer Name" Width="100"></GridColumn>
        <GridColumn Field="EmployeeID" HeaderText="Employee ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field="ShipCountry" HeaderText="Ship Country" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public SfDataManager? DataManager { get; set; }
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

## Handling filtering operation

Enable filtering by adding the **Filter** method in the OData configuration and setting [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowFiltering) property to **true** in [Grid](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html). The **$filter** query option retrieves records based on specified criteria.

{% tabs %}
{% highlight cs tabtitle="program.cs" %}

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
    // Enables $filter query option to allow filtering based on field values.
    .Filter() 
    .AddRouteComponents("odata", modelBuilder.GetEdmModel())
);

{% endhighlight %}
{% highlight razor tabtitle="Index.razor"%}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@using ODataV4Adaptor.Client.Models
 
<SfGrid TValue="OrderDetails" AllowFiltering="true" Height="348">
    <SfDataManager Url="https://localhost:xxxx/odata/grid" Adaptor="Adaptors.ODataV4Adaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" Width="100" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field="CustomerID" HeaderText="Customer Name" Width="100"></GridColumn>
        <GridColumn Field="EmployeeID" HeaderText="Employee ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field="ShipCountry" HeaderText="Ship Country" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

{% endhighlight %}
{% endtabs %}

**Single column filtering**
![Single column filtering](../images/odatav4-adaptor-filtering.png)

**Multi column filtering**
![Multi column filtering](../images/odatav4-adaptor-multi-filtering.png)

## Handling sorting operation

Enable sorting by adding the **OrderBy** method in the OData configuration and setting [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) property to **true** in [Grid](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html). The **$orderby** query option sorts records based on specified fields.

{% tabs %}
{% highlight cs tabtitle="program.cs" %}

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
    // Enables $orderby query option to allow sorting based on field values. 
    .OrderBy()
    .AddRouteComponents("odata", modelBuilder.GetEdmModel())
);

{% endhighlight %}
{% highlight razor tabtitle="Index.razor"%}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@using ODataV4Adaptor.Client.Models
 
<SfGrid TValue="OrderDetails" AllowSorting="true" Height="348">
    <SfDataManager Url="https://localhost:xxxx/odata/grid" Adaptor="Adaptors.ODataV4Adaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" Width="100" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field="CustomerID" HeaderText="Customer Name" Width="100"></GridColumn>
        <GridColumn Field="EmployeeID" HeaderText="Employee ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field="ShipCountry" HeaderText="Ship Country" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

{% endhighlight %}
{% endtabs %}

**Single column sorting**
![Single column sorting](../images/odatav4-adaptor-sorting.png)

**Multi column sorting**
![Multi column sorting](../images/odatav4-adaptor-multi-sorting.png)

## Handling paging operation

Paging can be enabled using the **SetMaxTop** method in the OData configuration and setting [AllowPaging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowPaging) property to **true** in [Grid](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html). The **$skip** and **$top** query options implement paging by skipping a specified number of records and retrieving the required count.

{% tabs %}
{% highlight cs tabtitle="program.cs" %}

// Create a new instance of the web application builder.
var builder = WebApplication.CreateBuilder(args);

// Create an ODataConventionModelBuilder to build the OData model.
var modelBuilder = new ODataConventionModelBuilder();

// Register the "Grid" entity set with the OData model builder.
modelBuilder.EntitySet<OrdersDetails>("Grid");

var recordCount= OrdersDetails.GetAllRecords().Count;

// Add services to the container.

// Add controllers with OData support to the service collection.
builder.Services.AddControllers().AddOData(
    options => options
    // Enables $count query option to retrieve total record count.
    .Count()
    // Limits the maximum number of records returned using $top.
    .SetMaxTop(recordCount)
    .AddRouteComponents(
        "odata",
        modelBuilder.GetEdmModel()
    )
);

{% endhighlight %}
{% highlight razor tabtitle="Index.razor"%}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@using ODataV4Adaptor.Client.Models
 
<SfGrid TValue="OrderDetails" AllowPaging="true" Height="348">
    <SfDataManager Url="https://localhost:xxxx/odata/grid" Adaptor="Adaptors.ODataV4Adaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" Width="100" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field="CustomerID" HeaderText="Customer Name" Width="100"></GridColumn>
        <GridColumn Field="EmployeeID" HeaderText="Employee ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field="ShipCountry" HeaderText="Ship Country" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

{% endhighlight %}
{% endtabs %}

![ODataV4Adaptor - Paging](../images/odatav4-adaptor-paging.png)

## Handling CRUD operations

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports Create, Read, Update, and Delete (CRUD) operations when configured with `ODataV4Adaptor`. These operations are automatically mapped to standard OData endpoints, and the server must implement corresponding **HTTP methods** to handle each action.

To support full CRUD functionality, define the following methods in the **GridController** class:

* **GET** – Retrieves data from the service
* **POST** – Inserts new records
* **PATCH** – Updates existing records
* **DELETE** – Removes records

To enable [editing](https://blazor.syncfusion.com/documentation/datagrid/editing) in the DataGrid, configure the [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) and [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Toolbar) properties to allow **adding**, **editing**, and **deleting** records.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@using ODataV4Adaptor.Client.Models

<SfGrid TValue="OrdersDetails" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })" Height="348">
    <SfDataManager Url="https://localhost:xxxx/odata/grid" Adaptor="Adaptors.ODataV4Adaptor"></SfDataManager>
    <GridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" IsPrimaryKey="true" Width="100" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field="CustomerID" HeaderText="Customer Name" Width="100"></GridColumn>
        <GridColumn Field="ShipCity" HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field="ShipCountry" HeaderText="Ship Country" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

{% endhighlight %}
{% endtabs %}

> Normal or Inline editing is the default edit [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Mode) for the Grid. To enable CRUD operations, ensure that the [IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsPrimaryKey) property is set to **true** for a specific Grid column, ensuring that its value is unique.

**Insert Record:**

To insert a new record, implement the **HttpPost** method in the **GridController** class. This method receives the new record from the client and adds it to the data source.

{% tabs %}
{% highlight cs tabtitle="GridController.cs" %}

/// <summary>
/// Inserts a new order into the data collection.
/// </summary>
/// <param name="addRecord">The order record to be inserted.</param>
/// <returns>Returns the inserted record if successful; otherwise, a bad request response.</returns>
[HttpPost]
[EnableQuery]
public IActionResult Post([FromBody] OrdersDetails addRecord)
{
    // Validate the input and return a 400 Bad Request if the record is null.
    if (addRecord == null)
    {
      return BadRequest("Null order");
    }

    // Insert the new order record at the beginning of the data collection.
    OrdersDetails.GetAllRecords().Insert(0, addRecord);

    // Return the inserted record as a JSON result.
    return new JsonResult(addRecord);
}

{% endhighlight %}
{% endtabs %}

![Insert Record](../images/odatav4-adaptor-insert-record.png)

**Update Record:**

To update an existing record, implement the **HttpPatch** method. This method performs a partial update based on the provided key and non-null fields.

{% tabs %}
{% highlight cs tabtitle="GridController.cs" %}

/// <summary>
/// Updates an existing order with the specified key.
/// </summary>
/// <param name="key">The unique identifier of the order to be updated.</param>
/// <param name="updateRecord">The object containing updated order values.</param>
/// <returns>It returns the updated order details.</returns>
[HttpPatch("{key}")]
public IActionResult Patch(int key, [FromBody] OrdersDetails updateRecord)
{
    // Validate the input data. Return a 400 Bad Request if the update record is null.
    if (updateRecord == null)
    {
        return BadRequest("No records");
    }

    // Retrieve the existing order by its key.
    var existingOrder = OrdersDetails.GetAllRecords().FirstOrDefault(order => order.OrderID == key);

    // If the order is found, perform partial update only on non-null fields.
    if (existingOrder != null)
    {
        // Perform the partial update by only replacing fields that are not null in the updateRecord.
        existingOrder.CustomerID = updateRecord.CustomerID ?? existingOrder.CustomerID;
        existingOrder.EmployeeID = updateRecord.EmployeeID ?? existingOrder.EmployeeID;
        existingOrder.ShipCountry = updateRecord.ShipCountry ?? existingOrder.ShipCountry;
    }

    // Return the updated order in JSON format.
    return new JsonResult(updateRecord);
}

{% endhighlight %}
{% endtabs %}

![Update Record](../images/odatav4-adaptor-update-record.png)

**Delete Record:**

To delete a record, implement the **HttpDelete** method. This method removes the record identified by the key from the data source.

{% tabs %}
{% highlight cs tabtitle="GridController.cs" %}

/// <summary>
/// Deletes an existing order based on the provided key.
/// </summary>
/// <param name="key">The unique identifier of the order to be deleted.</param>
/// <returns>Returns the details of the deleted record.</returns>
[HttpDelete("{key}")]
public IActionResult Delete(int key)
{
    // Retrieve the order to be deleted by its unique identifier.
    var deleteRecord = OrdersDetails.GetAllRecords().FirstOrDefault(order => order.OrderID == key);

    // Validate the input data. Return a 400 Bad Request if the record is not found.
    if (deleteRecord != null)
    {
        // Remove the order from the data source.
        OrdersDetails.GetAllRecords().Remove(deleteRecord);
    }

    // Return the deleted order in JSON format.
    return new JsonResult(deleteRecord);
}

{% endhighlight %}
{% endtabs %}

![Delete Record](../images/odatav4-adaptor-delete-record.png)

> The complete implementation is available in the [GitHub location](https://github.com/SyncfusionExamples/Binding-data-from-remote-service-to-blazor-data-grid/tree/master/ODataV4Adaptor).