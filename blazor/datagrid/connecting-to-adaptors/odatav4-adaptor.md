---
layout: post
title: Bind data and perform CRUD action with ODataV4Adaptor in Syncfusion Blazor DataGrid
description: Learn about bind data and performing CRUD operations using ODataV4Adaptor in Syncfusion Blazor DataGrid.
platform: Blazor
control: DataGrid
documentation: ug
---

# ODataV4Adaptor in Syncfusion Blazor DataGrid

The [ODataV4Adaptor](https://blazor.syncfusion.com/documentation/data/adaptors#odatav4-adaptor) in the Syncfusion Blazor DataGrid enables seamless integration of the DataGrid with OData V4 services, facilitating efficient data fetching and manipulation. This guide provides detailed instructions for binding data and performing CRUD (Create, Read, Update, and Delete) actions using the `ODataV4Adaptor` in your Syncfusion Blazor DataGrid.

## Configuring an OData V4 Service

To configure a server with Syncfusion Blazor DataGrid, follow these steps:

**1. Create a Blazor web app**

You can create a **Blazor Web App** named **ODataV4Adaptor** using Visual Studio 2022, either via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio). Ensure you configure the appropriate [interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=windows).

**2. Install NuGet packages**

Using the NuGet package manager in Visual Studio (Tools → NuGet Package Manager → Manage NuGet Packages for Solution), install the `Microsoft.AspNetCore.OData` NuGet package.

**3. Create a model class**
 
Create a new folder named **Models**. Then, add a model class named **OrdersDetails.cs** in the **Models** folder to represent the order data.
 
```csharp
namespace ODataV4Adaptor.Models
{
    public class OrdersDetails
    {
        public static List<OrdersDetails> order = new List<OrdersDetails>();
        public OrdersDetails() { }
        public OrdersDetails(
        int OrderID, string CustomerId, int EmployeeId, string ShipCountry)
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

To construct the Entity Data Model for your OData service, use the `ODataConventionModelBuilder` to define the model’s structure in the `Program.cs` file. Start by creating an instance of the `ODataConventionModelBuilder`, then register the entity set **Orders** using the `EntitySet<T>` method, where `OrdersDetails` represents the CLR type containing order details.

```csharp
// Create an ODataConventionModelBuilder to build the OData model.
var modelBuilder = new ODataConventionModelBuilder();

// Register the "Grid" entity set with the OData model builder.
modelBuilder.EntitySet<OrdersDetails>("Grid");
```

**5. Register the OData services**

After building the Entity Data Model, register the OData services in your application. Follow these steps:

```cs
// Add controllers with OData support to the service collection.
builder.Services.AddControllers().AddOData(
    options => options
        .Count()
        .AddRouteComponents("odata", modelBuilder.GetEdmModel()));
```
 
**6. Create an API controller**
 
Create a new folder named **Controllers**. Then, add a controller named **GridController.cs** in the **Controllers** folder to handle data communication.
 
```csharp
 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ODataV4Adaptor.Models;

namespace ODataV4Adaptor.Controllers
{
    /// <summary>
    /// Handles HTTP requests for grid data operations via OData.
    /// </summary>
    [ApiController]
    [Route("[controller]")]    
    public class GridController : ControllerBase
    {
        /// <summary>
        /// Retrieves all order records from the data source.
        /// </summary>
        /// <remarks>
        /// This endpoint supports OData query options such as $filter, $orderby, $top, $skip, etc.,
        /// allowing clients to perform flexible queries directly from the client-side Grid.
        /// </remarks>
        /// <returns>
        /// Returns an IActionResult that contains a queryable list of ordersdetails.
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
 
Add the following lines in the `Program.cs` file to register controllers:
 
```csharp
// Register controllers in the service container.
builder.Services.AddControllers();
 
// Map controller routes.
app.MapControllers();
```

**8. Run the Application:**

Run the application in Visual Studio. It will be accessible on a URL like **https://localhost:xxxx**. 

After running the application, you can verify that the server-side API controller is successfully returning the order data in the URL(https://localhost:xxxx/odata/grid). Here **xxxx** denotes the port number.
 
**5. Run the application**
 
Run the application in Visual Studio. The API will be accessible at a URL like **https://localhost:xxxx/api/grid** (replace **xxxx** with the port number). Verify that the API returns the order data.
 
![ODataV4-Adaptor-data](../images/odatav4-adaptors-data.png)

## Connecting Syncfusion Blazor DataGrid to an OData V4 Service

To integrate the Syncfusion Blazor DataGrid into your project using Visual Studio, follow the below steps:

**1. Install Syncfusion Blazor Grid and Themes NuGet packages**

- Open the NuGet Package Manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*).
- Search for and install the following packages:
    - [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid/)
    - [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

Alternatively, use the following Package Manager commands:

```powershell
Install-Package Syncfusion.Blazor.Grid -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}
```

**2. Register Syncfusion Blazor service**

- Open the **~/_Imports.razor** file and import the required namespaces.

```razor
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
```

- Register the Syncfusion Blazor service in the **~/Program.cs** file.

```csharp
using Syncfusion.Blazor;

builder.Services.AddSyncfusionBlazor();
```

**3. Add stylesheet and script resources**

Include the theme stylesheet and script references in the **~/Components/App.razor** file.

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

> * Refer to the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic for various methods to include themes (e.g., Static Web Assets, CDN, or CRG).
> * Set the `rendermode` to **InteractiveServer** or **InteractiveAuto** in your Blazor Web App configuration.

**4. Map the OData V4 service URL to the DataGrid**

To connect the Blazor DataGrid to an OData V4 service, use the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Url) property of [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) and set the `Adaptor` property to `Adaptors.ODataV4Adaptor`. Update the **Index.razor** file as follows.

{% tabs %}
{% highlight razor tabtitle="Index.razor"%}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@using ODataV4Adaptor.Models
 
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
 
{% highlight c# tabtitle="GridController.cs"%}
 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ODataV4Adaptor.Models;

namespace ODataV4Adaptor.Controllers
{
    /// <summary>
    /// Handles HTTP requests for grid data operations via OData.
    /// </summary>
    [ApiController]
    [Route("[controller]")]    
    public class GridController : ControllerBase
    {
        /// <summary>
        /// Retrieves all order records from the data source.
        /// </summary>
        /// <remarks>
        /// This endpoint supports OData query options such as $filter, $orderby, $top, $skip, etc.,
        /// allowing clients to perform flexible queries directly from the client-side Grid.
        /// </remarks>
        /// <returns>
        /// Returns an IActionResult that contains a queryable list of ordersdetails.
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
 
> Replace https://localhost:xxxx/odata/grid with the actual URL of your API endpoint that provides the data in a consumable format (e.g., JSON).
 
**5. Run the application**
 
When you run the application, the Blazor DataGrid  will display data fetched from the OData V4 service.

![ODataV4-Adaptor-data](../images/blazor-odatav4-adaptors.gif)

> Replace `https://localhost:xxxx/odata/` with the actual URL of your OData V4 service.

> * The Syncfusion Blazor DataGrid supports server-side operations such as **searching**, **sorting**, **filtering**, **aggregating**, and **paging**. These operations are automatically handled by the ODataV4Adaptor in compliance with the OData V4 protocol.
> * Refer to the [ODataV4Adaptor documentation](https://blazor.syncfusion.com/documentation/data/adaptors#odatav4-adaptor) for more details on advanced configurations and features.

## Handling searching operation

To enable search operations in your web application using OData, you first need to configure the OData support in your service collection. This involves adding the `Filter` method within the OData setup, allowing you to filter data based on specified criteria. Once enabled, clients can utilize the **$filter** query option in their requests to search for specific data entries.
