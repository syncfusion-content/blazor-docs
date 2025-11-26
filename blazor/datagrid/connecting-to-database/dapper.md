---
layout: post
title: Bind SQL Data in Blazor DataGrid component using Dapper | Syncfusion
description: Learn about consuming data from SQL Server using Dapper and Microsoft SQL Client, binding it to Syncfusion components, and performing CRUD operations.
platform: Blazor
control: DataGrid
documentation: ug
---

# Connecting SQL data to a Blazor DataGrid Component using Dapper

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid component supports binding data from Microsoft SQL Server using [Dapper](https://github.com/DapperLib/Dapper) and [System.Data.SqlClient](https://www.nuget.org/packages/System.Data.SqlClient/4.8.6?_src=template). **Dapper** is a lightweight object-relational mapper (ORM) that simplifies executing SQL queries and mapping results to C# domain models.

Data from SQL Server can be integrated into the Blazor DataGrid using multiple approaches:

- Using the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property for local binding.
- [CustomAdaptor](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/custom-adaptor) for advanced customization of data operations.
- Remote data binding using adaptors such as [UrlAdaptor](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/url-adaptor).

This guide demonstrates two approaches for integrating SQL Server data with the Blazor DataGrid using **Dapper**:

* **Remote binding via API service using UrlAdaptor**

This approach connects the DataGrid to a REST API endpoint that returns data in the required format. The [UrlAdaptor](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/url-adaptor) handles communication between the component and the API, enabling server-side operations such as **paging**, **sorting**, and **filtering**.

* **Custom binding using CustomAdaptor**

This approach provides complete control over data operations by implementing a [CustomAdaptor](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/custom-adaptor) class. It allows overriding methods for reading, updating, inserting, and deleting data, making it suitable for scenarios requiring custom business logic or complex queries.

This guide demonstrates both approaches for integrating SQL Server data with the Blazor DataGrid using Dapper. Each approach supports built-in and customizable CRUD operations.

## Dapper Overview

Dapper is a lightweight, open-source micro ORM (Object-Relational Mapper) developed by the Stack Overflow team. It extends the functionality of the [IDbConnection interface](https://learn.microsoft.com/en-us/dotnet/api/system.data.idbconnection?view=net-8.0), enabling efficient execution of SQL queries and automatic mapping of query results to objects.

**Key characteristics of Dapper:**

* **Performance-focused**: Provides near raw ADO.NET performance while simplifying data access.
* **Cross-database support**: Compatible with Microsoft SQL Server, PostgreSQL, MySQL, and other relational databases.
* **Minimal overhead**: Does not require complex configurations or heavy abstractions.

Dapper simplifies database operations by:

* Executing SQL queries directly against the database.
* Mapping query results to strongly typed C# models without manual data transformation.
* Reducing boilerplate code compared to traditional ADO.NET approaches.

When combined with S**ystem.Data.SqlClient**, Dapper offers a streamlined way to interact with SQL Server in Blazor applications.

## Binding data using Dapper from Microsoft SQL Server via an API service.

This section explains how to retrieve data from a Microsoft SQL Server database using **Dapper** and expose it through an ASP.NET Core API service for remote binding in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid component. The API service acts as an intermediary between the database and the DataGrid, enabling server-side operations such as paging, sorting, filtering, and CRUD actions.

### Creating an API service

Follow these steps to create an ASP.NET Core API service that retrieves data from Microsoft SQL Server using Dapper:

**Step 1: Create an ASP.NET Core Web API Project**

In Visual Studio, create a new **ASP.NET Core Web API** project named **MyWebService**.

Refer to [Microsoft documentation](https://learn.microsoft.com/en-us/visualstudio/get-started/csharp/tutorial-aspnet-core?view=vs-2022) for detailed steps.

**Step 2: Install Required NuGet Packages**

- To enable **Dapper** and **SQL Server** access in the Blazor application, install the following packages:

    - [System.Data.SqlClient](https://www.nuget.org/packages/System.Data.SqlClient/4.8.6?_src=template)
    - [Dapper](https://www.nuget.org/packages/Dapper)

- Use **NuGet Package Manager** in Visual Studio:

*Tools → NuGet Package Manager → Manage NuGet Packages* for Solution, then search and install both packages.

- Alternatively, run these commands in the **Package Manager Console**:

```powershell
Install-Package System.Data.SqlClient
Install-Package Dapper
```

**Step3: Create an API Controller**

Create a controller named **GridController.cs** under the Controllers folder.

**Step 4: Implement Data Retrieval Logic**

In the controller, establish a connection to SQL Server using **SqlConnection** which implements IDbConnection interfface. Execute the query using **Dapper** and map the results to a strongly typed collection.

{% tabs %}
{% highlight razor tabtitle="GridController.cs"%}
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Syncfusion.Blazor.Data;
using Syncfusion.Blazor;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;
using System.Data;
using Dapper;
using System.Text.Json;
namespace MyWebService.Controllers
{
    [ApiController]
    public class GridController : ControllerBase
    {
        public class Order
        {
            [Key]
            public int? OrderID { get; set; }
            public string? CustomerID { get; set; }
            public int? EmployeeID { get; set; }
            public decimal? Freight { get; set; }
            public string? ShipCity { get; set; }
        }

        [Route("api/[controller]")]
        public List<Order> GetOrderData()
        {
            //TODO: Enter the connectionstring of database
            string ConnectionString = @"<Enter a valid connection string>";
            string Query = "SELECT * FROM dbo.Orders ORDER BY OrderID;";
            //Create SQL Connection
            using (IDbConnection Connection = new SqlConnection(ConnectionString))
            {
             Connection.Open();
             // Dapper automatically handles mapping to your Order class
             List<Order> orders = Connection.Query<Order>(Query).ToList();
             return orders;
            }
        }
    }
}
{% endhighlight %}
{% endtabs %}

5. **Run and test the application**

Start the API and access **https://localhost:xxxx/api/Grid** to view the data.

![Hosted API URL](../images/Ms-Sql-data.png)

### Connecting Blazor DataGrid to an API service

After hosting the API service, configure the Blazor DataGrid to consume data from the API endpoint using the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component and [UrlAdaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Adaptors.html#Syncfusion_Blazor_Adaptors_UrlAdaptor). This enables remote data binding and supports server-side operations such as **paging**, **sorting**, **filtering**, and **CRUD**.

**Prerequisites**

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

1. **Create a Blazor Web App**

Create a **Blazor Web App** using Visual Studio 2022. Use [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-9.0&pivots=vs) or the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension.

> Configure the [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-9.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-9.0&pivots=vs) during project creation.

2. **Install Syncfusion Packages**

* Open the NuGet Package Manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*). Search and install the following packages:

    - [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid/)
    - [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

* Alternatively, use the Package Manager Console:

```powershell
Install-Package Syncfusion.Blazor.Grid -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}
```

> When using **WebAssembly** or **Auto** render modes in a Blazor Web App, install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor component NuGet packages within the client project.

> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for a complete list of available packages.

3. **Register Syncfusion Blazor service**

- Add the required namespaces in **~/_Imports.razor**:

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
```

- For apps using **WebAssembly** or **Auto** (Server and WebAssembly) render modes, register the service in both **~/Program.cs** files.

```cshtml
using Syncfusion.Blazor;

builder.Services.AddSyncfusionBlazor();
```

4. **Add stylesheet and script resources**

Access the theme stylesheet and script from NuGet using [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet reference in the <head> section and the script reference at the end of the <body> in **~/Components/App.razor**:

```html
<head>
    <link href="_content/Syncfusion.Blazor.Themes/fluent.css" rel="stylesheet" />
</head>

<body>
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

> * Refer to [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) for additional methods such as [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator).
> * Set the render mode to **InteractiveServer** or **InteractiveAuto** in the Blazor Web App configuration.

5. **Configure DataGrid with UrlAdaptor**

The [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component supports multiple adaptors for remote data binding. For API services, set the [Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Adaptors.html) property to [Adaptors.UrlAdaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Adaptors.html#Syncfusion_Blazor_Adaptors_UrlAdaptor) and specify the service endpoint in the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Url) property.

{% tabs %}
{% highlight razor tabtitle="Index.razor"%}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor
@using Microsoft.Data.SqlClient;

<SfGrid @ref="Grid" TValue="Order" AllowPaging="true" AllowFiltering="true" AllowSorting="true" AllowGrouping="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" })">
    <SfDataManager Url="https://localhost:xxxx/api/Grid" InsertUrl="https://localhost:xxxx/api/Grid/Insert" UpdateUrl="https://localhost:xxxx/api/Grid/Update" RemoveUrl="https://localhost:xxxx/api/Grid/Delete" Adaptor="Adaptors.UrlAdaptor"></SfDataManager>
    <GridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridAggregates>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(Order.Freight) Type="AggregateType.Sum" Format="C2">
                    <FooterTemplate>
                        @{
                            var aggregate = (context as AggregateTemplateContext);
                            <div>
                                <p>Sum: @aggregate.Sum</p>
                            </div>
                        }
                    </FooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(Order.Freight) Type="AggregateType.Average" Format="C2">
                    <FooterTemplate>
                        @{
                            var aggregate = (context as AggregateTemplateContext);
                            <div>
                                <p>Average: @aggregate.Average</p>
                            </div>
                        }
                    </FooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
    </GridAggregates>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsIdentity="true" ValidationRules="@(new ValidationRules{ Required= true })" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required= true, MinLength = 3 })" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.EmployeeID) HeaderText="Employee ID" TextAlign="TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" TextAlign="TextAlign.Right" Format="C2" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    SfGrid<Order> Grid { get; set; }
    public List<Order> Orders { get; set; }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public decimal Freight { get; set; }
        public string ShipCity { get; set; }
    }
}
{% endhighlight %}
{% highlight c# tabtitle="GridController.cs"%}
    public class GridController : ControllerBase
    {
        /// <summary>
        /// Returns the data collection as result and count after performing data operations based on request from <see cref=DataManagerRequest”/>
        /// </summary>
        /// <param name="DataManagerRequest">DataManagerRequest contains the information regarding searching, filtering, sorting, aggregates and paging which is handled on the Blazor DataGrid component side</param>
        /// <returns>The data collection's type is determined by how this method has been implemented.</returns>
        [HttpPost]
        [Route("api/[controller]")]
        public object Post([FromBody] DataManagerRequest DataManagerRequest)
        {
            IEnumerable<Order> DataSource = GetOrderData();
            int TotalRecordsCount = DataSource.Cast<Order>().Count();
            return new { result = DataSource, count = TotalRecordsCount };
        }
    }
{% endhighlight %}
{% endtabs %}

> In the above Blazor DataGrid component, [AllowSearching](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowSearching), [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting), [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowFiltering), [AllowPaging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowPaging), [AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowGrouping) and CRUD-related properties have been enabled. The details on how to handle these actions are explained below.

![Blazor DataGrid component bound with Microsoft SQL Server data](../images/blazor-Grid-Ms-SQL-databinding.png)

### Handling data operations in UrlAdaptor

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports server-side operations such as **searching**, **sorting**, **filtering**, **aggregating**, and **paging** when using the [UrlAdaptor](https://blazor.syncfusion.com/documentation/data/adaptors#url-adaptor).

The [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html) object provides details for each operation, and these can be applied using built-in methods from the [DataOperations](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html) class:

* [PerformSearching](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSearching__1_System_Linq_IQueryable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_SearchFilter__) -Applies search criteria to the data source based on search filters.
* [PerformFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformFiltering__1_System_Linq_IQueryable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_WhereFilter__System_String_) - Filters the data source using conditions specified in the request.
* [PerformSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSorting__1_System_Linq_IQueryable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_Sort__) - Sorts the data source according to one or more sort descriptors.
* [PerformTake](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformTake__1_System_Linq_IQueryable___0__System_Int32_) - Retrieves a specified number of records for paging.
* [PerformSkip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSkip__1_System_Linq_IQueryable___0__System_Int32_) - Skips a defined number of records before returning results.

These methods enable efficient handling of large datasets by performing operations on the server side. The following sections demonstrate how to manage these operations using the `UrlAdaptor`.

> * To enable these operations, add the **Syncfusion.Blazor.Data** package to the API service project using NuGet Package Manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*).

### Handling searching operation

Enable server-side searching by implementing logic in the API controller with the [PerformSearching](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSearching__1_System_Collections_Generic_IEnumerable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_SearchFilter__) method from the [DataOperations](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html) class. This method applies search criteria to the collection based on filters specified in the incoming [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html).

{% highlight razor %}

[HttpPost]
[Route("api/[controller]")]
public object Post([FromBody] DataManagerRequest DataManagerRequest)
{
    IEnumerable<Order> DataSource = GetOrderData();
    // Handling Searching in UrlAdaptor.
    if (DataManagerRequest.Search != null && DataManagerRequest.Search.Count > 0)
    {
        // Searching
        DataSource = DataOperations.PerformSearching(DataSource, DataManagerRequest.Search);
        //Add custom logic here if needed and remove above method
    }
    int TotalRecordsCount = DataSource.Cast<Order>().Count();
    return new { result = DataSource, count = TotalRecordsCount };
}
{% endhighlight %}

### Handling filtering operation

Enable server-side filtering by implementing logic in the API controller using the [PerformFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformFiltering__1_System_Collections_Generic_IEnumerable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_WhereFilter__System_String_) method from the [DataOperations](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html) class. This method applies filter conditions to the collection based on the criteria specified in the incoming [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html).

{% highlight razor %}
[HttpPost]
[Route("api/[controller]")]
public object Post([FromBody] DataManagerRequest DataManagerRequest)
{
    IEnumerable<Order> DataSource = GetOrderData();
    // Handling Filtering in UrlAdaptor.
    if (DataManagerRequest.Where != null && DataManagerRequest.Where.Count > 0)
    {
        // Filtering
        DataSource = DataOperations.PerformFiltering(DataSource, DataManagerRequest.Where, DataManagerRequest.Where[0].Operator);
        //Add custom logic here if needed and remove above method
    }
    int TotalRecordsCount = DataSource.Cast<Order>().Count();
    return new { result = DataSource, count = TotalRecordsCount };
}

{% endhighlight %}

### Handling sorting operation

Enable server-side sorting by implementing logic in the API controller using the [PerformSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSorting__1_System_Collections_Generic_IEnumerable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_Sort__) method from the [DataOperations](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html) class. This method sorts the collection based on one or more sort descriptors specified in the incoming [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html).

{% highlight razor %}
[HttpPost]
[Route("api/[controller]")]
public object Post([FromBody] DataManagerRequest DataManagerRequest)
{
    IEnumerable<Order> DataSource = GetOrderData();
    // Handling Sorting in UrlAdaptor.
    if (DataManagerRequest.Sorted != null && DataManagerRequest.Sorted.Count > 0)
    {
        // Sorting
        DataSource = DataOperations.PerformSorting(DataSource, DataManagerRequest.Sorted);
        //Add custom logic here if needed and remove above method
    }
    int TotalRecordsCount = DataSource.Cast<Order>().Count();
    return new { result = DataSource, count = TotalRecordsCount };
}
{% endhighlight %}

### Handling aggregate operation

Enable server-side aggregation by implementing logic in the API controller using the [PerformAggregation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.DataUtil.html#Syncfusion_Blazor_Data_DataUtil_PerformAggregation_System_Collections_IEnumerable_System_Collections_Generic_List_Syncfusion_Blazor_Data_Aggregate__) method from the [DataUtil](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.DataUtil.html) class. This method calculates aggregate values such as **Sum**, **Average**, **Min**, and **Max** for the specified fields based on the incoming [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html).

{% highlight razor %}
 [HttpPost]
 [Route("api/[controller]")]
 public object Post([FromBody] DataManagerRequest DataManagerRequest)
 {
    IEnumerable<Order> DataSource = GetOrderData();
    int TotalRecordsCount = DataSource.Cast<Order>().Count();
    // Handling Aggregation in UrlAdaptor.
    IDictionary<string, object> Aggregates = null;
    if (DataManagerRequest.Aggregates != null) 
    {  
        // Aggregation
        Aggregates = DataUtil.PerformAggregation(DataSource, DataManagerRequest.Aggregates);
        //Add custom logic here if needed and remove above method                
    }
    return new { result = DataSource, count = TotalRecordsCount, aggregates = Aggregates };
 }
{% endhighlight %}

> The server-side implementation of the `PerformAggregation` method is required only for [Footer aggregates](https://blazor.syncfusion.com/documentation/datagrid/footer-aggregate). Explicit handling is not necessary for[ Group Footer aggregates](https://blazor.syncfusion.com/documentation/datagrid/group-and-caption-aggregate#group-footer-aggregates) or [Group Caption aggregates](https://blazor.syncfusion.com/documentation/datagrid/group-and-caption-aggregate#group-caption-aggregates).

### Handling paging operation

Enable server-side paging by implementing logic in the API controller using the [PerformSkip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSkip__1_System_Collections_Generic_IEnumerable___0__System_Int32_) and [PerformTake](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformTake__1_System_Collections_Generic_IEnumerable___0__System_Int32_) methods from the [DataOperations](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html) class. These methods apply paging based on the **Skip** and **Take** values provided in the incoming [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html).

{% highlight razor %}
[HttpPost]
[Route("api/[controller]")]
public object Post([FromBody] DataManagerRequest DataManagerRequest)
{
    IEnumerable<Order> DataSource = GetOrderData();
    int TotalRecordsCount = DataSource.Cast<Order>().Count();
    // Handling Paging in UrlAdaptor.
    if (DataManagerRequest.Skip != 0)
    {
        // Paging
        DataSource = DataOperations.PerformSkip(DataSource, DataManagerRequest.Skip);
        //Add custom logic here if needed and remove above method
    }
    if (DataManagerRequest.Take != 0)
    {
        DataSource = DataOperations.PerformTake(DataSource, DataManagerRequest.Take);
        //Add custom logic here if needed and remove above method
    }
    return new { result = DataSource, count = TotalRecordsCount };
}
{% endhighlight %}

N> For optimal performance, apply operations in the following sequence: **Searching → Filtering → Sorting → Aggregation → Paging → Grouping** in [ReadAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_ReadAsync_Syncfusion_Blazor_DataManagerRequest_System_String_) method.

### Handling CRUD operations

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports Create, Read, Update, and Delete operations through API endpoints. These operations can be implemented using **Dapper**, which executes parameterized queries and maps data efficiently, reducing boilerplate code and improving maintainability.

These operations are mapped to API endpoints using properties such as:

* [InsertUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_InsertUrl) – API endpoint for inserting new records.
* [UpdateUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_UpdateUrl) – API endpoint for updating existing records.
* [RemoveUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_UpdateUrl) – API endpoint for deleting records.
* [CrudUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_CrudUrl) – Single endpoint for all CRUD operations.
* [BatchUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_BatchUrl) – API endpoint for batch editing.

To enable editing, configure the [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Toolbar) and [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) properties, and set the Mode property to [EditMode.Normal](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.EditMode.html#Syncfusion_Blazor_Grids_EditMode_Normal) to allow adding, editing, and deleting records.

{% tabs %}
{% highlight razor %}
<SfGrid @ref="Grid" TValue="Order" AllowPaging="true" AllowFiltering="true" AllowSorting="true" AllowGrouping="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" })">
    <SfDataManager Url="https://localhost:xxxx/api/Grid" InsertUrl="https://localhost:xxxx/api/Grid/Insert" UpdateUrl="https://localhost:xxxx/api/Grid/Update" RemoveUrl="https://localhost:xxxx/api/Grid/Delete" BatchUrl="https://localhost:7033/api/Grid/Batch" Adaptor="Adaptors.UrlAdaptor"></SfDataManager>
    <GridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsIdentity="true" ValidationRules="@(new ValidationRules{ Required= true })" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required= true, MinLength = 3 })" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.EmployeeID) HeaderText="Employee ID" TextAlign="TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" TextAlign="TextAlign.Right" Format="C2" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>
{% endhighlight %}
{% endtabs %}

> * Normal(Inline) editing is the default [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Mode) for the Blazor DataGrid component.
> * To enable CRUD operations, set the [IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsPrimaryKey) property to **true** for a column that contains unique values.
> * If the database includes an auto-generated column, set the [IsIdentity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsIdentity) property for that column to disable editing during **add** or **update** operations.

**Insert Operation:**

To add a new record, click the **Add** toolbar button in the DataGrid. This displays the inline edit form. After entering the required values, click **Update** to submit the changes. The DataGrid sends a **POST** request to the API endpoint, which inserts the record into the Orders table using **Dapper**.

**Dapper** simplifies database interaction by executing parameterized queries and mapping results directly to objects, improving performance and maintainability.

{% tabs %}
{% highlight c# tabtitle="OrdersController.cs" %}
[HttpPost]
[Route("api/Grid/Insert")]
/// <summary>
/// Inserts a new data item into the data collection.
/// </summary>
/// <param name="CRUDModel<T>">The set of information along with new record detail which is need to be inserted.</param>
/// <returns>Returns void</returns>
public void Insert([FromBody] CRUDModel<Order> Value)
{
    //TODO: Enter the connectionstring of database
    string ConnectionString = @"<Enter a valid connection string>";
    //Create query to insert the specific into the database by accessing its properties
    string Query = "INSERT INTO Orders(CustomerID, Freight, ShipCity, EmployeeID) VALUES(@CustomerID, @Freight, @ShipCity, @EmployeeID)";
    using (IDbConnection Connection = new SqlConnection(ConnectionString))
    {
        Connection.Open();
        //Execute this code to reflect the changes into the database
        Connection.Execute(Query, Value.Value);
    }
    //Add custom logic here if needed and remove above method
}
{% endhighlight %}
{% endtabs %}

**Update Operation:**

To modify an existing record, select the row and click the **Edit** toolbar button. Update the required values in the inline edit form and click **Update**. The DataGrid sends a **POST** request to the API endpoint, which updates the record in the Orders table using **Dapper**.

{% tabs %}
{% highlight c# tabtitle="OrdersController.cs" %}
[HttpPost]
[Route("api/Grid/Update")]
/// <summary>
/// Update a existing data item from the data collection.
/// </summary>
/// <param name="CRUDModel<T>">The set of information along with updated record detail which is need to be updated.</param>
/// <returns>Returns void</returns>
public void Update([FromBody] CRUDModel<Order> Value)
{
    //TODO: Enter the connectionstring of database
    string ConnectionString = @"<Enter a valid connection string>";
    //Create query to update the changes into the database by accessing its properties
    string Query = "UPDATE Orders SET CustomerID = @CustomerID, Freight = @Freight, ShipCity = @ShipCity, EmployeeID = @EmployeeID WHERE OrderID = @OrderID";
    using (IDbConnection Connection = new SqlConnection(ConnectionString))
    {
        Connection.Open();
        //Execute this code to reflect the changes into the database
        Connection.Execute(Query, Value.Value);
    }
    //Add custom logic here if needed and remove above method
}
{% endhighlight %}
{% endtabs %}

**Delete Operation:**

To remove a record, select the row and click the **Delete** toolbar button. The DataGrid sends a **POST** request to the API endpoint, which deletes the record from the Orders table using **Dapper**.

{% tabs %}
{% highlight c# tabtitle="OrdersController.cs" %}
 [HttpPost]
[Route("api/Grid/Delete")]
/// <summary>
/// Remove a specific data item from the data collection.
/// </summary>
/// <param name="CRUDModel<T>">The set of information along with specific record detail which is need to be removed.</param>
/// <returns>Returns void</returns>
public void Delete([FromBody] CRUDModel<Order> Value)
{
    //TODO: Enter the connectionstring of database
    string ConnectionString = @"<Enter a valid connection string>";
    //Create query to remove the specific from database by passing the primary key column value.
    string Query = "DELETE FROM Orders WHERE OrderID = @OrderID";
    using (IDbConnection Connection = new SqlConnection(ConnectionString))
    {
        Connection.Open();
        int orderID = Convert.ToInt32(Value.Key.ToString());
        //Execute this code to reflect the changes into the database
        Connection.Execute(Query, new { OrderID = orderID });
    }
    //Add custom logic here if needed and remove above method
}
{% endhighlight %}
{% endtabs %}

**Batch Operation:**

To perform batch editing, set the [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Mode) property in [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) to **Batch** and specify the [BatchUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_BatchUrl) property in [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html).

- Use the **Add** toolbar button to insert a new row in batch mode.
- Double-click a cell to edit its value.
- Select a record and click **Delete** to remove it.

-All changes (insert, update, delete) are sent to the API in a single **POST** request when the **Update** toolbar button is clicked.

{% highlight razor %}
 [HttpPost]
[Route("api/Grid/Batch")]
/// <summary>
/// Batchupdate (Insert, Update, Delete) a collection of data items from the data collection.
/// </summary>
/// <param name="CRUDModel<T>">The set of information along with details about the CRUD actions to be executed from the database.</param>
/// <returns>Returns void</returns>
public void Batch([FromBody] CRUDModel<Order> Value)
{
    //TODO: Enter the connectionstring of database
    string ConnectionString = @"<Enter a valid connection string>";
    if (Value.Changed != null)
    {
        foreach (var Record in (IEnumerable<Order>)Value.Changed)
        {
            //Create query to update the changes into the database by accessing its properties
            string Query = "UPDATE Orders SET CustomerID = @CustomerID, Freight = @Freight, ShipCity = @ShipCity, EmployeeID = @EmployeeID WHERE OrderID = @OrderID";
            using (IDbConnection Connection = new SqlConnection(ConnectionString))
            {
                Connection.Open();
                //Execute this code to reflect the changes into the database
                Connection.Execute(Query, Record);
            }
            //Add custom logic here if needed and remove above method
        }

    }
    if (Value.Added != null)
    {
        foreach (var Record in (IEnumerable<Order>)Value.Added)
        {
            //Create query to insert the specific into the database by accessing its properties 
            string Query = "INSERT INTO Orders (CustomerID, Freight, ShipCity, EmployeeID) VALUES (@CustomerID, @Freight, @ShipCity, @EmployeeID)";
            using (IDbConnection Connection = new SqlConnection(ConnectionString))
            {
                Connection.Open();
                //Execute this code to reflect the changes into the database
                Connection.Execute(Query, Record);
            }
            //Add custom logic here if needed and remove above method
        }
    }
    if (Value.Deleted != null)
    {
        foreach (var Record in (IEnumerable<Order>)Value.Deleted)
        {
            //Create query to remove the specific from database by passing the primary key column value.
            string Query = "DELETE FROM Orders WHERE OrderID = @OrderID";
            using (IDbConnection Connection = new SqlConnection(ConnectionString))
            {
                Connection.Open();
                //Execute this code to reflect the changes into the database
                Connection.Execute(Query, new { OrderID = Record.OrderID });
            }
            //Add custom logic here if needed and remove above method
        }
    }
}
{% endhighlight %}

![Blazor DataGrid component bound with Microsoft SQL Server data using Dapper](../images/blazor-Grid-Ms-SQl-databinding-Gif.gif)

> Find the complete implementation in this [GitHub](https://github.com/SyncfusionExamples/connecting-databases-to-blazor-datagrid-component/tree/master/Binding%20Dapper%20using%20UrlAdaptor) repository.

## Binding data from Microsoft SQL Server using Dapper with CustomAdaptor

This section explains how to use **Dapper** with a [CustomAdaptor](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/custom-adaptor) to retrieve data from **Microsoft SQL Server** and bind it to the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid component.

**Step 1: Create the Blazor DataGrid Component**

Follow the procedure described in [Connecting Blazor DataGrid to an API service](#connecting-blazor-datagrid-to-an-api-service).

> * Set the rendermode to **InteractiveServer** or **InteractiveAuto** based on application configuration.

**Step 2: Install MySql NuGet Package**

Add the following packages to the Blazor application:

- [System.Data.SqlClient](https://www.nuget.org/packages/System.Data.SqlClient/4.8.6?_src=template)
- [Dapper](https://www.nuget.org/packages/Dapper)

Use **NuGet Package Manager** in Visual Studio:

*Tools → NuGet Package Manager → Manage NuGet Packages* for Solution, then search and install both packages.

**Step 3: Configure the DataGrid with CustomAdaptor**

Inject a custom service into the `CustomAdaptor` and configure the component as shown below:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@rendermode InteractiveServer

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor
@using Microsoft.Data.SqlClient;

<SfGrid TValue="Order" AllowSorting="true" AllowFiltering="true" AllowGrouping="true" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" })">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="@EditMode.Normal"></GridEditSettings>
    <GridAggregates>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(Order.Freight) Type="AggregateType.Sum" Format="C2">
                    <FooterTemplate>
                        @{
                            var aggregate = (context as AggregateTemplateContext);
                            <div>
                                <p>Sum: @aggregate.Sum</p>
                            </div>
                        }
                    </FooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(Order.Freight) Type="AggregateType.Average" Format="C2">
                    <FooterTemplate>
                        @{
                            var aggregate = (context as AggregateTemplateContext);
                            <div>
                                <p>Average: @aggregate.Average</p>
                            </div>
                        }
                    </FooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
    </GridAggregates>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsIdentity="true" ValidationRules="@(new ValidationRules{ Required= true })" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required= true, MinLength = 3 })" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.EmployeeID) HeaderText="Employee ID" TextAlign="TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" TextAlign="TextAlign.Right" Format="C2" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    SfGrid<Order> Grid { get; set; }
}
{% endhighlight %}
{% highlight razor tabtitle="Orderdata.cs"%}
  public class Order
  {
      public int? OrderID { get; set; }
      public string CustomerID { get; set; }
      public int EmployeeID { get; set; }
      public decimal Freight { get; set; }
      public string ShipCity { get; set; }
  }
{% endhighlight %}
{% endtabs %}

**Step 4: Implement Data Retrieval Logic**

Implement the [ReadAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_ReadAsync_Syncfusion_Blazor_DataManagerRequest_System_String_) method in `CustomAdaptor` to retrieve data from the database using **Dapper**.

- Establish a connection to Microsoft SQL Server using **SqlConnection**, which implements the [IDbConnection interface](https://learn.microsoft.com/en-us/dotnet/api/system.data.idbconnection?view=net-9.0).
- Prepare the SQL query string to fetch records from the database.
- Execute the query using **Dapper** and map the results directly to a strongly typed collection of Order objects.
- Return the response as a **Result** and **Count** pair in a [DataResult](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.DataResult-1.html) object within the `ReadAsync` method for binding to the Blazor DataGrid.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@rendermode InteractiveServer

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor
@using Microsoft.Data.SqlClient;

<SfGrid TValue="Order" AllowSorting="true" AllowFiltering="true" AllowGrouping="true" AllowPaging="true" Toolbar="@(new List<string>() { "Add","Edit", "Delete", "Update", "Cancel", "Search" })">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="@EditMode.Normal"></GridEditSettings>
    <GridAggregates>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(Order.Freight) Type="AggregateType.Sum" Format="C2">
                    <FooterTemplate>
                        @{
                            var aggregate = (context as AggregateTemplateContext);
                            <div>
                                <p>Sum: @aggregate.Sum</p>
                            </div>
                        }
                    </FooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(Order.Freight) Type="AggregateType.Average" Format="C2">
                    <FooterTemplate>
                        @{
                            var aggregate = (context as AggregateTemplateContext);
                            <div>
                                <p>Average: @aggregate.Average</p>
                            </div>
                        }
                    </FooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
    </GridAggregates>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsIdentity="true" ValidationRules="@(new ValidationRules{ Required= true })" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required= true, MinLength = 3 })" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.EmployeeID) HeaderText="Employee ID" TextAlign="TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" TextAlign="TextAlign.Right" Format="C2" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    /// <summary>
    /// Implementing CustomAdaptor by extending the <see cref=“DataAdaptor”/> class.
    /// The Blazor DataGrid component support for custom data binding, which enables the binding and manipulation of data in a personalized way, using user-defined methods.
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        public OrderData OrderService = new OrderData();
        /// <summary>
        /// Returns the data collection after performing data operations based on request from <see cref=”DataManagerRequest”/>
        /// </summary>
        /// <param name="DataManagerRequest">DataManagerRequest contains the information regarding paging, grouping, filtering, searching, sorting which is handled on the Blazor DataGrid component side</param>
        /// <param name="Key">An optional parameter that can be used to perform additional data operations.</param>
        /// <returns>The data collection's type is determined by how this method has been implemented.</returns>
        public override async Task<object> ReadAsync(DataManagerRequest DataManagerRequest, string Key = null)
        {
            IEnumerable<Order> DataSource = await OrderService.GetOrdersAsync();
            int TotalRecordsCount = DataSource.Cast<Order>().Count();
            //Here RequiresCount is passed from the control side itself, where ever the on-demand data fetching is needed then the RequiresCount is set as true in component side itself.
            return DataManagerRequest.RequiresCounts ? new DataResult() { Result = DataSource, Count = TotalRecordsCount } : (object)DataSource;
        }
    }
}
{% endhighlight %}
{% highlight razor tabtitle="OrderData.cs" %}
public class OrderData
{
    public async Task<List<Order>> GetOrdersAsync()
    {
        //Create query to fetch data from database
        string Query = "SELECT * FROM dbo.Orders ORDER BY OrderID;";
        //Create SQL Connection
        using (IDbConnection Connection = new SqlConnection(ConnectionString))
        {
            Connection.Open();
            // Dapper automatically handles mapping to your Order class
            List<Order> orders = Connection.Query<Order>(Query).ToList();
            return orders;
        }            
    }
}
{% endhighlight %}
{% endtabs %}

> * The `DataManagerRequest` encompasses details about the Blazor DataGrid component actions such as searching, filtering, sorting, aggregate, paging and grouping.
> * In the above Blazor DataGrid, [AllowSearching](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowSearching), [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting), [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowFiltering), [AllowPaging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowPaging), [AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowGrouping) and CRUD-related properties have been enabled. The details on how to handle these actions are explained below.

![Blazor DataGrid component bound with Microsoft SQL Server data](../images/blazor-Grid-Ms-SQL-databinding.png)

### Handling data operations in a Custom Adaptor

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports server-side operations such as **searching**, **filtering**, **sorting**, **paging**, and **aggregating** when using a `CustomAdaptor`. These operations are implemented by overriding the [Read](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_Read_Syncfusion_Blazor_DataManagerRequest_System_String_) or [ReadAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_ReadAsync_Syncfusion_Blazor_DataManagerRequest_System_String_) method of the [DataAdaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html) abstract class.

The [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html) object provides the necessary details for each operation, and these can be applied using built-in methods from the [DataOperations](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html) and [DataUtil](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.DataUtil.html) classes:

* [PerformSearching](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSearching__1_System_Collections_Generic_IEnumerable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_SearchFilter__) – Applies search criteria to the data source based on search filters.

* [PerformFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformFiltering__1_System_Collections_Generic_IEnumerable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_WhereFilter__System_String_) – Filters the data source using conditions specified in the request.

* [PerformSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSorting__1_System_Collections_Generic_IEnumerable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_SortedColumn__) – Sorts the data source according to one or more sort descriptors.

* [PerformSkip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSkip__1_System_Collections_Generic_IEnumerable___0__System_Int32_) – Retrieves a specified number of records for paging.

* [PerformTake](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformTake__1_System_Collections_Generic_IEnumerable___0__System_Int32_) – Skips a defined number of records before returning results.

* [PerformAggregation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.DataUtil.html#Syncfusion_Blazor_Data_DataUtil_PerformAggregation_System_Collections_IEnumerable_System_Collections_Generic_List_Syncfusion_Blazor_Data_Aggregate__) – Applies aggregate details to calculate summary values such as Sum, Average, Min, and Max.

When using **Dapper**, data retrieval is performed by executing parameterized SQL queries and mapping results directly to strongly typed objects. The ReadAsync method typically includes:

- Establishing a connection using **SqlConnection** (implements IDbConnection).
- Executing the query with **connection.QueryAsync<T>()** to fetch data.
- Applying operations such as searching, filtering, sorting, paging, and aggregation using the above methods.
- Returning the response as a `DataResult` object containing **Result** and **Count** for binding to the DataGrid.

N> To enable these operations, install the **Syncfusion.Blazor.Data** package using NuGet Package Manager in Visual Studio:

(*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*).

### Handling searching operation

When using `CustomAdaptor`, the searching operation is implemented by overriding the [Read](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_Read_Syncfusion_Blazor_DataManagerRequest_System_String_) or [ReadAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_ReadAsync_Syncfusion_Blazor_DataManagerRequest_System_String_) method of the [DataAdaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html) abstract class.

The built-in [PerformSearching](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSearching__1_System_Collections_Generic_IEnumerable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_SearchFilter__) method of the [DataOperations](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html) class applies search criteria from the [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html) to the data source. Custom logic can also be implemented to handle searching as required.

{% highlight razor %}
public class CustomAdaptor : DataAdaptor
{
    public OrderData OrderService = new OrderData();
    // Performs data read operation
    public override async Task<object> ReadAsync(DataManagerRequest DataManagerRequest, string Key = null)
    {
        IEnumerable<Order> DataSource = await OrderService.GetOrdersAsync();
        // Handling Searching in CustomAdaptor.
        if (DataManagerRequest.Search != null && DataManagerRequest.Search.Count > 0)
        {
            // Searching
            DataSource = DataOperations.PerformSearching(DataSource, DataManagerRequest.Search);
            //Add custom logic here if needed and remove above method
        }
        int TotalRecordsCount = DataSource.Cast<Order>().Count();
        //Here RequiresCount is passed from the control side itself, where ever the on-demand data fetching is needed then the RequiresCount is set as true in component side itself.
        return DataManagerRequest.RequiresCounts ? new DataResult() { Result = DataSource, Count = TotalRecordsCount } : (object)DataSource;
    }
}
{% endhighlight %}

### Handling filtering operation

When implementing `CustomAdaptor`, the filtering operation is managed by overriding the[Read](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_Read_Syncfusion_Blazor_DataManagerRequest_System_String_) or [ReadAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_ReadAsync_Syncfusion_Blazor_DataManagerRequest_System_String_) method of the [DataAdaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html) abstract class.

The built-in [PerformFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformFiltering__1_System_Collections_Generic_IEnumerable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_WhereFilter__System_String_) method in the [DataOperations](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html) class applies filter criteria from the [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html) to the data collection. Custom filtering logic can also be implemented to meet specific requirements.

{% highlight razor %}
public class CustomAdaptor : DataAdaptor
{
    public OrderData OrderService = new OrderData();
    // Performs data read operation
    public override async Task<object> ReadAsync(DataManagerRequest DataManagerRequest, string Key = null)
    {
        IEnumerable<Order> DataSource = await OrderService.GetOrdersAsync();
        // Handling Filtering in CustomAdaptor.
        if (DataManagerRequest.Where != null && DataManagerRequest.Where.Count > 0)
        {
            // Filtering
            DataSource = DataOperations.PerformFiltering(DataSource, DataManagerRequest.Where, DataManagerRequest.Where[0].Operator);
            //Add custom logic here if needed and remove above method
        }
        int TotalRecordsCount = DataSource.Cast<Order>().Count();
        //Here RequiresCount is passed from the control side itself, where ever the on-demand data fetching is needed then the RequiresCount is set as true in component side itself.
        return DataManagerRequest.RequiresCounts ? new DataResult() { Result = DataSource, Count = TotalRecordsCount } : (object)DataSource;
    }
}
{% endhighlight %}

### Handling sorting operation

When implementing `CustomAdaptor`, the sorting operation is handled by overriding the [Read](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_Read_Syncfusion_Blazor_DataManagerRequest_System_String_) or [ReadAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_ReadAsync_Syncfusion_Blazor_DataManagerRequest_System_String_) method of the [DataAdaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html) abstract class.

The built-in [PerformSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSorting__1_System_Collections_Generic_IEnumerable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_Sort__) method in the [DataOperations](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html) class applies sort criteria from the [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html) to the data collection. Custom sorting logic can also be implemented to meet specific requirements.

{% highlight razor %}
public class CustomAdaptor : DataAdaptor
{
    public OrderData OrderService = new OrderData();
    // Performs data read operation
    public override async Task<object> ReadAsync(DataManagerRequest DataManagerRequest, string Key = null)
    {
        IEnumerable<Order> DataSource = await OrderService.GetOrdersAsync();
        // Handling Sorting in CustomAdaptor.
        if (DataManagerRequest.Sorted != null && DataManagerRequest.Sorted.Count > 0)
        {
            // Sorting
            DataSource = DataOperations.PerformSorting(DataSource, DataManagerRequest.Sorted);
            //Add custom logic here if needed and remove above method
        }
        int TotalRecordsCount = DataSource.Cast<Order>().Count();
        //Here RequiresCount is passed from the control side itself, where ever the on-demand data fetching is needed then the RequiresCount is set as true in component side itself.
        return DataManagerRequest.RequiresCounts ? new DataResult() { Result = DataSource, Count = TotalRecordsCount } : (object)DataSource;
    }
}
{% endhighlight %}

### Handling aggregate operation

When implementing `CustomAdaptor`, aggregate operations are managed by overriding the [Read](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_Read_Syncfusion_Blazor_DataManagerRequest_System_String_) or [ReadAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_ReadAsync_Syncfusion_Blazor_DataManagerRequest_System_String_) method of the [DataAdaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor-1.html) abstract class.

The built-in [PerformAggregation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.DataUtil.html#Syncfusion_Blazor_Data_DataUtil_PerformAggregation_System_Collections_IEnumerable_System_Collections_Generic_List_Syncfusion_Blazor_Data_Aggregate__) method in the [DataUtil](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.DataUtil.html) class calculates aggregate values based on the criteria specified in the [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html). Custom aggregation logic can also be implemented when specific requirements exist.

The provided sample code illustrated how to implement the aggregate operation within `CustomAdaptor`,

{% highlight razor %}
public class CustomAdaptor : DataAdaptor
{
    public OrderData OrderService = new OrderData();
    // Performs data read operation
    public override async Task<object> ReadAsync(DataManagerRequest DataManagerRequest, string Key = null)
    {
        IEnumerable<Order> DataSource = await OrderService.GetOrdersAsync();
        int TotalRecordsCount = DataSource.Cast<Order>().Count();
        // Handling Aggregation in CustomAdaptor.
        IDictionary<string, object> Aggregates = null;
        if (DataManagerRequest.Aggregates != null) // Aggregation
        {
            Aggregates = DataUtil.PerformAggregation(DataSource, DataManagerRequest.Aggregates);
            //Add custom logic here if needed and remove above method
        }
        //Here RequiresCount is passed from the control side itself, where ever the on-demand data fetching is needed then the RequiresCount is set as true in component side itself.
        return DataManagerRequest.RequiresCounts ? new DataResult() { Result = DataSource, Count = TotalRecordsCount, Aggregates = Aggregates } : (object)DataSource;
    }
}
{% endhighlight %}

> The server-side implementation of the `PerformAggregation` method is required only for [Footer aggregates](https://blazor.syncfusion.com/documentation/datagrid/footer-aggregate). Explicit handling is not necessary for[ Group Footer aggregates](https://blazor.syncfusion.com/documentation/datagrid/group-and-caption-aggregate#group-footer-aggregates) or [Group Caption aggregates](https://blazor.syncfusion.com/documentation/datagrid/group-and-caption-aggregate#group-caption-aggregates).

### Handling paging operation

When implementing `CustomAdaptor`, paging is managed by overriding the [Read](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_Read_Syncfusion_Blazor_DataManagerRequest_System_String_) or [ReadAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_ReadAsync_Syncfusion_Blazor_DataManagerRequest_System_String_) method of the [DataAdaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html) abstract class.

The built-in [PerformSkip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSkip__1_System_Collections_Generic_IEnumerable___0__System_Int32_) and [PerformTake](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformTake__1_System_Collections_Generic_IEnumerable___0__System_Int32_) methods in the [DataOperations](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html) class apply paging criteria from the [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html) to the data collection. Custom paging logic can also be implemented when specific requirements exist.

{% highlight razor %}
public class CustomAdaptor : DataAdaptor
{
    public OrderData OrderService = new OrderData();
    // Performs data read operation
    public override async Task<object> ReadAsync(DataManagerRequest DataManagerRequest, string Key = null)
    {
        IEnumerable<Order> DataSource = await OrderService.GetOrdersAsync();
        int TotalRecordsCount = DataSource.Cast<Order>().Count();
        // Handling paging in CustomAdaptor.
        if (DataManagerRequest.Skip != 0)
        {
            // Paging
            DataSource = DataOperations.PerformSkip(DataSource, DataManagerRequest.Skip);
            //Add custom logic here if needed and remove above method
        }
        if (DataManagerRequest.Take != 0)
        {
            DataSource = DataOperations.PerformTake(DataSource, DataManagerRequest.Take);
            //Add custom logic here if needed and remove above method
        }
        //Here RequiresCount is passed from the control side itself, where ever the on-demand data fetching is needed then the RequiresCount is set as true in component side itself.
        return DataManagerRequest.RequiresCounts ? new DataResult() { Result = DataSource, Count = TotalRecordsCount } : (object)DataSource;
    }
}
{% endhighlight %}

### Handling grouping operation

When implementing `CustomAdaptor`, grouping is managed by overriding the [Read](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_Read_Syncfusion_Blazor_DataManagerRequest_System_String_) or [ReadAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_ReadAsync_Syncfusion_Blazor_DataManagerRequest_System_String_) method of the [DataAdaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html) abstract class.

The built-in [Group](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.DataUtil.html#Syncfusion_Blazor_Data_DataUtil_Group__1_System_Collections_IEnumerable_System_String_System_Collections_Generic_List_Syncfusion_Blazor_Data_Aggregate__System_Int32_System_Collections_Generic_IDictionary_System_String_System_String__System_Boolean_System_Boolean_) method in the [DataUtil](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.DataUtil.html) class applies grouping logic based on the configuration in the [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html). Custom grouping logic can also be implemented when specific requirements exist.

{% highlight razor %}
public class CustomAdaptor : DataAdaptor
{
    public OrderData OrderService = new OrderData();
    // Performs data read operation
    public override async Task<object> ReadAsync(DataManagerRequest DataManagerRequest, string Key = null)
    {
        IEnumerable<Order> DataSource = await OrderService.GetOrdersAsync();
        int TotalRecordsCount = DataSource.Cast<Order>().Count();
        DataResult DataObject = new DataResult();
        // Handling Group operation in CustomAdaptor.
        if (DataManagerRequest.Group != null)
        {
            IEnumerable ResultData = DataSource.ToList();
            // Grouping
            foreach (var group in DataManagerRequest.Group)
            {
                ResultData = DataUtil.Group<Order>(ResultData, group, DataManagerRequest.Aggregates, 0, DataManagerRequest.GroupByFormatter);
                //Add custom logic here if needed and remove above method
            }
            DataObject.Result = ResultData;
            DataObject.Count = TotalRecordsCount;
            return DataManagerRequest.RequiresCounts ? DataObject : (object)ResultData;
        }
        //Here RequiresCount is passed from the control side itself, where ever the on-demand data fetching is needed then the RequiresCount is set as true in component side itself.
        return DataManagerRequest.RequiresCounts ? new DataResult() { Result = DataSource, Count = TotalRecordsCount } : (object)DataSource;
    }
}
{% endhighlight %}

N> For optimal performance, apply operations in the following sequence: **Searching → Filtering → Sorting → Aggregation → Paging → Grouping** in [ReadAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_ReadAsync_Syncfusion_Blazor_DataManagerRequest_System_String_) method.

```cshtml
public class CustomAdaptor : DataAdaptor
{
    public OrderData OrderService = new OrderData();
    // Performs data Read operation
    public override async Task<object> ReadAsync(DataManagerRequest DataManagerRequest, string Key = null)
    {
        IEnumerable<Order> DataSource = await OrderService.GetOrdersAsync();
        int TotalRecordsCount = DataSource.Cast<Order>().Count();
        DataResult DataObject = new DataResult();
        // Handling both Grouping and Aggregation in CustomAdaptor.
        if (DataManagerRequest.Aggregates != null || DataManagerRequest.Group != null) // Aggregation
        {
            if (DataManagerRequest.Group != null)
            {
                IEnumerable ResultData = DataSource.ToList();
                // Grouping
                foreach (var group in DataManagerRequest.Group)
                {
                    ResultData = DataUtil.Group<Order>(ResultData, group, DataManagerRequest.Aggregates, 0, DataManagerRequest.GroupByFormatter);
                    //Add custom logic here if needed and remove above method
                }
                DataObject.Result = ResultData;
            }
            else
            {
                DataObject.Result = DataSource;
            }
            DataObject.Count = TotalRecordsCount;
            DataObject.Aggregates = DataUtil.PerformAggregation(DataSource, DataManagerRequest.Aggregates);

            return DataManagerRequest.RequiresCounts ? DataObject : (object)DataSource;
        }
        //Here RequiresCount is passed from the control side itself, where ever the on-demand data fetching is needed then the RequiresCount is set as true in component side itself.
        return DataManagerRequest.RequiresCounts ? new DataResult() { Result = DataSource, Count = TotalRecordsCount } : (object)DataSource;
    }
}
```

### Handling CRUD operations

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid component supports Create, Read, Update, and Delete (CRUD) operations through the [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) configuration. Multiple edit modes are available, including **Inline**, **Dialog**, and **Batch** editing. For details, refer to the [Editing](https://blazor.syncfusion.com/documentation/datagrid/editing) documentation.

When using `CustomAdaptor`, CRUD operations are implemented by overriding the following methods of the [DataAdaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor-1.html) class:

* [Insert](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_Insert_Syncfusion_Blazor_DataManager_System_Object_System_String_) / [InsertAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_InsertAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_) – Handles record insertion.
* [Update](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_Update_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) / [UpdateAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_UpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) – Handles record updates.
* [Remove](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_Remove_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) / [RemoveAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_RemoveAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) – Handles record deletion.
* [BatchUpdate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_BatchUpdate_Syncfusion_Blazor_DataManager_System_Object_System_Object_System_Object_System_String_System_String_System_Nullable_System_Int32__) / [BatchUpdateAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_BatchUpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_Object_System_Object_System_String_System_String_System_Nullable_System_Int32__) – Handles batch operations (insert, update, delete).

Each method can be customized to execute SQL commands against the Microsoft SQL Server database using **Dapper**, which simplifies database interaction by providing an easy-to-use interface for executing queries and mapping results to objects.

{% highlight razor %}
<SfGrid TValue="Order" AllowSorting="true" AllowFiltering="true" AllowGrouping="true" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" })">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="@EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsIdentity="true" ValidationRules="@(new ValidationRules{ Required= true })" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required= true, MinLength = 3 })" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.EmployeeID) HeaderText="Employee ID" TextAlign="TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" TextAlign="TextAlign.Right" Format="C2" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>
{% endhighlight %}

> * Normal(Inline) editing is the default [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings_Mode) for the Blazor DataGrid component.
> * To enable CRUD operations, set the [IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsPrimaryKey) property to **true** for a column that contains unique values.
> * If the database includes an auto-generated column, set the [IsIdentity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsIdentity) property for that column to disable editing during **add** or **update** operations.

**Insert Operation:**

To enable insertion in a Blazor DataGrid using a custom data binding approach, override the [Insert](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_Insert_Syncfusion_Blazor_DataManager_System_Object_System_String_) or [InsertAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_InsertAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_) method of the `CustomAdaptor` class. This method is invoked when a new record is added to the grid.

{% tabs %}
{% highlight razor tabtitle="Index.razor"%}
/// <summary>
/// Inserts a new data item into the data collection.
/// </summary>
/// <param name="DataManager">The DataManager is a data management component used for performing data operations in application.</param>
/// <param name="Value">The new record which is need to be inserted.</param>
/// <param name="Key">An optional parameter that can be used to perform additional data operations.</param>
/// <returns>Returns the newly inserted record details.</returns>
public override async Task<object> InsertAsync(DataManager DataManager, object Value, string Key)
{
    // Add your insert logic here
    // This method will be invoked when inserting new records into the Blazor DataGrid component.
    await OrderService.AddOrderAsync(Value as Order);
    return Value;
}
{% endhighlight %}
{% highlight razor tabtitle="Orderdata.cs"%}
public async Task AddOrderAsync(Order Value)
{
    //Create query to insert the specific into the database by accessing its properties
    string Query = "INSERT INTO Orders(CustomerID, Freight, ShipCity, EmployeeID) VALUES(@CustomerID, @Freight, @ShipCity, @EmployeeID)";
    using (IDbConnection Connection = new SqlConnection(ConnectionString))
    {
        Connection.Open();
        //Execute this code to reflect the changes into the database
        await Connection.ExecuteAsync(query, Value);
    }
}
{% endhighlight %}
{% endtabs %}

**Update Operation:**

To enable record updates in a Blazor DataGrid using a custom data binding approach, override the [Update](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_Update_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) or [UpdateAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_UpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) method of the `CustomAdaptor` class. This method is triggered when an existing record is modified in the grid.

{% tabs %}
{% highlight razor tabtitle="Index.razor"%}
/// <summary>
/// Updates an existing data item in the data collection.
/// </summary>
/// <param name="DataManager">The DataManager is a data management component used for performing data operations in application.</param>
/// <param name="Value">The modified record which is need to be updated.</param>
/// <param name="KeyField">The primary column name specifies the field name of the primary column.</param>
/// <param name="Key">An optional parameter that can be used to perform additional data operations.</param>
/// <returns>Returns the updated data item.</returns>
public override async Task<object> UpdateAsync(DataManager DataManager, object Value, string KeyField, string Key)
{
    // Add your update logic here
    // This method will be invoked when updating existing records in the Blazor DataGrid component.
    await OrderService.UpdateOrderAsync(Value as Order);
    return Value;
}
{% endhighlight %}
{% highlight razor tabtitle="Orderdata.cs"%}
public async Task UpdateOrderAsync(Order Value)
{
    //Create query to update the changes into the database by accessing its properties
    string Query = "UPDATE Orders SET CustomerID = @CustomerID, Freight = @Freight, EmployeeID = @EmployeeID, ShipCity = @ShipCity WHERE OrderID = @OrderID";
    using (IDbConnection Connection = new SqlConnection(ConnectionString))
    {
        connection.Open();
        //Execute this code to reflect the changes into the database
        await Connection.ExecuteAsync(Query, Value);
    }
}
{% endhighlight %}
{% endtabs %}

**Delete Operation:**

To enable deletion in a Blazor DataGrid using a custom data binding approach, override the [Remove](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_Remove_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) or [RemoveAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_RemoveAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_)  method of the `CustomAdaptor` class. This method is invoked when a record is removed from the grid.

{% tabs %}
{% highlight razor tabtitle="Index.razor"%}
/// <summary>
/// Removes a data item from the data collection.
/// </summary>
/// <param name="DataManager">The DataManager is a data management component used for performing data operations in application.</param>
/// <param name="Value">The Value specifies the primary column value which is needs to be removed from the grid record.</param>
/// <param name="KeyField">The KeyField specifies the field name of the primary column.</param>
/// <param name="Key">An optional parameter that can be used to perform additional data operations.</param>
/// <returns>Returns the removed data item.</returns>
public override async Task<object> RemoveAsync(DataManager DataManager, object Value, string KeyField, string Key)
{
    // Add your delete logic here
    // This method will be invoked when deleting existing records from the Blazor DataGrid component.
    await OrderService.RemoveOrderAsync(Value as int?);
    return Value;
}
{% endhighlight %}
{% highlight razor tabtitle="Orderdata.cs"%}
public async Task RemoveOrderAsync(int? Key)
{
    //Create query to remove the specific from database by passing the primary key column value.
    string Query = "DELETE FROM Orders WHERE OrderID = @OrderID";
    using (IDbConnection Connection = new SqlConnection(ConnectionString))
    {
        Connection.Open();
        //Execute this code to reflect the changes into the database
        await Connection.ExecuteAsync(Query, new { OrderID = Key });
    }
}
{% endhighlight %}
{% endtabs %}

**Batch Operation:**

To enable batch editing in a Blazor DataGrid using a custom data binding approach, override the [BatchUpdate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_BatchUpdate_Syncfusion_Blazor_DataManager_System_Object_System_Object_System_Object_System_String_System_String_System_Nullable_System_Int32__) or [BatchUpdateAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_BatchUpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_Object_System_Object_System_String_System_String_System_Nullable_System_Int32__) method of the `CustomAdaptor` class. This method is invoked when multiple records are added, updated, or deleted in batch mode.

{% highlight razor %}
/// <summary>
/// /// Batchupdate (Insert, Update, Delete) a collection of data items from the data collection.
/// </summary>
/// <param name="DataManager">The DataManager is a data management component used for performing data operations in application.</param>
/// <param name="Changed">The Changed specifies the collection of record updated in batch mode which needs to be updated from the grid record.</param>
/// <param name="Added">The Added specifies the collection of record inserted in batch mode which needs to be inserted from the grid record.</param>
/// <param name="Deleted">The Deleted specifies the collection of record deleted in batch mode which needs to be removed from the grid record.</param>
/// <param name="KeyField">The KeyField specifies the field name of the primary column.</param>
/// <param name="Key">An optional parameter that can be used to perform additional data operations.</param>
/// <param name="DropIndex">An optional parameter that can be used to perform row drag and drop operation.</param>
/// <returns>Returns the removed data item.</returns>
public override async Task<object> BatchUpdateAsync(DataManager DataManager, object Changed, object Added, object Deleted, string KeyField, string Key, int? DropIndex)
{
    if (Changed != null)
    {
        foreach (var record in (IEnumerable<Order>)Changed)
        {
            await OrderService.UpdateOrderAsync(record as Order);
        }
    }
    if (Added != null)
    {
        foreach (var record in (IEnumerable<Order>)Added)
        {
            await OrderService.AddOrderAsync(record as Order);
        }
    }
    if (Deleted != null)
    {
        foreach (var record in (IEnumerable<Order>)Deleted)
        {
            await OrderService.RemoveOrderAsync((record as Order).OrderID);
        }
    }
    return Key;
}
{% endhighlight %}

![Blazor DataGrid component bound with Microsoft SQL Server data using Dapper](../images/blazor-Grid-Ms-SQl-databinding-Gif.gif)

> The complete sample is available in this [GitHub](https://github.com/SyncfusionExamples/connecting-databases-to-blazor-datagrid-component/tree/master/Binding%20Dapper%20using%20CustomAdaptor) repository.
