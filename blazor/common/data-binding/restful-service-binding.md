---
layout: post
title: Bind data from web services to Syncfusion Blazor components
description: Learn how to retrieve data from a RESTful service, bind it to Syncfusion Blazor DataGrid using SfDataManager with ODataV4Adaptor, and perform CRUD operations.
platform: Blazor
control: Common
documentation: ug
---

# Bind data from RESTful web services to Syncfusion Blazor components

## Introduction

This section provides an overview of how to bind data from RESTful services to Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components. It explains the process of retrieving data from an OData service, integrating it with the Blazor DataGrid using [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) and [ODataV4Adaptor](https://blazor.syncfusion.com/documentation/data/adaptors#odatav4-adaptor), and enabling CRUD operations. The goal is to create a seamless data flow between the service and the UI components for building interactive and data-driven applications.

Select an adaptor that matches the RESTful service implementation. For details on available adaptors, refer to the SfDataManager [Adaptors documentation](https://blazor.syncfusion.com/documentation/data/adaptors).

## Prerequisite software

The following software and packages are required to implement data binding from RESTful services to Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components:

* [Visual Studio 2022 or later](https://visualstudio.microsoft.com/downloads/) (latest version with .NET 10 support)
* [.NET 8 or later](https://dotnet.microsoft.com/en-us/download/dotnet)
* SQL Server (LocalDB or any supported edition)

These components provide the development environment required for creating the database, building the OData service, and integrating the Blazor application.

## Create the database

Create a database named OrdersDetails in SQL Server to store order information.

1. Open **Visual Studio** and navigate to **View → SQL Server Object Explorer**.

![Add new database in Blazor](../images/odata-add-db.png)

2. Right-click the **Databases** node and select **Add New Database**. Enter the name **OrdersDetails**.

![Adding database name and location in Blazor](../images/odata-db-name.png)

3. Under the newly created database, right-click **Tables** and choose **Add New Table**.

![Add table in Blazor](../images/odata-add-table.png)

4. Use the following SQL script to define the **Orders** table:

```
CREATE TABLE Orders (
    OrderID BIGINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
    CustomerID VARCHAR(100) NOT NULL,
    Freight INT NULL,
    OrderDate DATETIME NULL
```

After applying the script, the table design will appear as shown:

![Database table design in Blazor](../images/odata-table-design.png)

Finally, click Update Database to apply changes.

![Update database in Blazor](../images/odata-update-db.png)

## OData Service Setup

Create an OData service to expose the **OrdersDetails** database for consumption by the Blazor application.

### Create ASP.NET Core Web API project

1. Open **Visual Studio 2022 or later** and create an **ASP.NET Core Web API** project named **ODataServiceProject**.

2. Select **.NET 8 or newer** as the target framework.

### Install required nuGet packages

Install the following NuGet packages:

    - [Microsoft.EntityFrameworkCore.Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools) – Provides scaffolding commands.
    - [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/) – Enables SQL Server support.
    - [Microsoft.AspNetCore.OData](https://www.nuget.org/packages/Microsoft.AspNetCore.OData/)

**Options to install**:

* Using **NuGet Package Manager** in Visual Studio:
Navigate to: **Tools → NuGet Package Manager → Manage NuGet Packages for Solution**.

* Using **Package Manager Console**:

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Microsoft.EntityFrameworkCore.Tools
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.AspNetCore.OData

{% endhighlight %}
{% endtabs %}

### Scaffold DbContext and Model Classes

Run the following command to generate **DbContext** and entity classes from the **OrdersDetails** database:

```powershell
Scaffold-DbContext "Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=OrdersDetails;Integrated Security=True" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
```

This command creates **OrdersDetailsContext.cs** and **Orders.cs** under the **Models** folder.

![Models folder in Blazor](../images/odata-models.png)

{% tabs %}
{% highlight c# tabtitle="OrdersDetailsContext.cs" hl_lines="24" %}

using Microsoft.EntityFrameworkCore;

namespace ODataServiceProject.Models
{
    public partial class OrdersDetailsContext : DbContext
    {
        public OrdersDetailsContext(DbContextOptions<OrdersDetailsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Orders> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Orders>(entity =>
            {
                entity.HasKey(e => e.OrderId);
                entity.Property(e => e.CustomerId).HasMaxLength(100);
                entity.Property(e => e.OrderDate).HasColumnType("datetime");
            });
        }
    }
}
{% endhighlight %}
{% endtabs %}


{% tabs %}
{% highlight c# tabtitle="Orders.cs" %}
using System;

namespace ODataServiceProject.Models
{
    public partial class Orders
    {
        public long OrderId { get; set; }
        public string CustomerId { get; set; } = string.Empty;
        public int? Freight { get; set; }
        public DateTime? OrderDate { get; set; }
    }
}
{% endhighlight %}
{% endtabs %}

### Configure Connection String

Move the connection string to **appsettings.json**:

```json
{
  "ConnectionStrings": {
    "OrdersDetailsDatabase": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OrdersDetails;Integrated Security=True"
  }
}
```

Register the DbContext in **Program.cs**:

{% tabs %}
{% highlight c# tabtitle="~/Program.cs" %}

builder.Services.AddDbContext<OrdersDetailsContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("OrdersDetailsDatabase")));

{% endhighlight %}
{% endtabs %}


### Add OData Controller

Create an **OrdersController** in the **Controllers** folder and implement CRUD operations:

{% tabs %}
{% highlight c# tabtitle="OrdersController.cs" %}

using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using ODataServiceProject.Models;

[Route("odata/[controller]")]
public class OrdersController : ODataController
{
    private readonly OrdersDetailsContext _db;

    public OrdersController(OrdersDetailsContext context)
    {
        _db = context;
    }

    [EnableQuery]
    [HttpGet]
    public IActionResult Get() => Ok(_db.Orders);

    [EnableQuery]
    [HttpPost]
    public IActionResult Post([FromBody] Orders order)
    {
        _db.Orders.Add(order);
        _db.SaveChanges();
        return Created(order);
    }

    [EnableQuery]
    [HttpPatch]
    public IActionResult Patch([FromODataUri] long key, [FromBody] Delta<Orders> order)
    {
        var entity = _db.Orders.Find(key);
        order.Patch(entity);
        _db.SaveChanges();
        return Updated(entity);
    }

    [HttpDelete]
    public IActionResult Delete([FromODataUri] long key)
    {
        var entity = _db.Orders.Find(key);
        _db.Orders.Remove(entity);
        _db.SaveChanges();
        return NoContent();
    }
}

{% endhighlight %}
{% endtabs %}

### Enable OData Routing

Configure OData in **Program.cs**:

{% tabs %}
{% highlight c# tabtitle="~/Program.cs" %}
builder.Services.AddControllers().AddOData(opt =>
    opt.AddRouteComponents("odata", GetEdmModel())
       .Count().Filter().OrderBy().Expand().Select().SetMaxTop(null));

static IEdmModel GetEdmModel()
{
    var builder = new ODataConventionModelBuilder();
    builder.EntitySet<Orders>("Orders");
    return builder.GetEdmModel();
}

{% endhighlight %}
{% endtabs %}

If the service is consumed by a **Blazor Web App**, enable **CORS**:

{% tabs %}
{% highlight c# tabtitle="~/Program.cs" %}
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazorApp", policy =>
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowBlazorApp");
{% endhighlight %}
{% endtabs %}

## Blazor App Setup

### Create a Blazor Application

Create a **Blazor Web App** using Visual Studio 2022 via [Microsoft templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

Configure the appropriate [interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes#render-modes) and [interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling#interactivity-location) when creating the Blazor Web App.

### Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Packages

Install the following NuGet packages:

- [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid/)
- [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

**Options to install**:

* **Using NuGet Package Manager in Visual Studio**

  Navigate to: **Tools → NuGet Package Manager → Manage NuGet Packages for Solution**.

* **Using Package Manager Console**:

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Grid -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N > Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) for a complete list.

### Configure Syncfusion<sup style="font-size:70%">&reg;</sup> Services

Import namespaces in **_Imports.razor**:

{% highlight razor %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

{% endhighlight %}

Register Syncfusion<sup style="font-size:70%">&reg;</sup> services in **Program.cs**:

```cshtml
using Syncfusion.Blazor;

builder.Services.AddSyncfusionBlazor();
```

* For **Auto** render mode, register Syncfusion services in both **Program.cs** files (client and server projects).
* For **Blazor Server**, register in the server-side **Program.cs** only.

### Add Theme Stylesheet

Include the Syncfusion theme in the <head> section:

{% highlight cshtml %}

<link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />

{% endhighlight %}

Add this stylesheet in the following locations based on the project type:

* **Blazor Web App**: **~/Components/App.razor**
* **Blazor WebAssembly**: **wwwroot/index.html**
* **Blazor Server**: **~/Pages/_Host.cshtml**


### Add Script Reference

Include the Syncfusion script at the end of the <body>:

```html
<body>

    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

## Binding Data to Blazor DataGrid Using ODataV4Adaptor

To bind data from the OData service to the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, use the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component with the [ODataV4Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Adaptors.html#Syncfusion_Blazor_Adaptors_ODataV4Adaptor). This enables seamless integration with OData endpoints for operations such as **querying**, **sorting**, **paging**, and **CRUD**.

**Define Render Mode**

If the interactivity location is set to **Per page/component**, specify the render mode at the top of the Razor page:

{% tabs %}
{% highlight razor %}

@rendermode InteractiveAuto

{% endhighlight %}
{% endtabs %}

If the interactivity location is set to **Global**, the render mode is configured during project creation and does not need to be defined in individual Razor pages.

**Add the DataGrid Component**

Insert the Syncfusion [DataGrid](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html) in a Razor page inside the **Pages** folder:

{% tabs %}
{% highlight razor %}

<SfGrid TValue="Orders"></SfGrid>

{% endhighlight %}
{% endtabs %}

**Bind data Using SfDataManager and WebApiAdaptor**

Include `SfDataManager` within the grid and specify the OData service URL and adaptor type.

{% tabs %}
{% highlight razor %}

<SfGrid TValue="Orders">
    <SfDataManager Url="https://localhost:44392/odata/orders" Adaptor="Adaptors.ODataV4Adaptor"></SfDataManager>
</SfGrid>

{% endhighlight %}
{% endtabs %}

N> Replace the localhost URL with the actual OData service endpoint.

**Define Grid Columns**

Configure columns using the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) component:

{% tabs %}
{% highlight razor %}

<SfGrid TValue="Orders">
    <SfDataManager Url="https://localhost:44392/odata/orders" Adaptor="Adaptors.ODataV4Adaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field=@nameof(Orders.OrderId) HeaderText="Order ID" IsPrimaryKey="true" Visible="false" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Orders.CustomerId) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Orders.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Orders.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public class Order
    {
        public long OrderId { get; set; }

        public string CustomerId { get; set; } = null!;

        public int? Freight { get; set; }

        public DateTime? OrderDate { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

When the application runs, the **Get()** method in the OData controller will be invoked:

{% tabs %}
{% highlight c# %}

[Route("api/[controller]")]
public class OrdersController : ODataController
{
    private OrdersDetailsContext _db;
    public OrdersController(OrdersDetailsContext context)
    {
        _db = context;
    }
    [HttpGet]
    [EnableQuery]
    public IActionResult Get()
    {
        return Ok(_db.Orders);
    }
    ...
}

{% endhighlight %}
{% endtabs %}

## Handling CRUD Operations in Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports full **CRUD** functionality when integrated with an OData service. Editing is enabled using the [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) component, and operations are performed through the OData controller methods.

**Enable Editing**

Configure editing in the grid using `GridEditSettings`. The grid supports multiple editing modes such as [Inline](https://blazor.syncfusion.com/documentation/datagrid/in-line-editing), [Dialog](https://blazor.syncfusion.com/documentation/datagrid/dialog-editing), and [Batch](https://blazor.syncfusion.com/documentation/datagrid/batch-editing). The example below uses Inline mode with the [Toolbar](https://blazor.syncfusion.com/documentation/datagrid/tool-bar) property to show toolbar items for editing.

{% tabs %}
{% highlight razor %}

<SfGrid TValue="Orders" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
    <SfDataManager Url="https://localhost:44392/odata/orders" Adaptor="Adaptors.ODataV4Adaptor"></SfDataManager>
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Orders.OrderId) HeaderText="Order ID" IsPrimaryKey="true" Visible="false" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Orders.CustomerId) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Orders.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Orders.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public class Order
    {
        public long OrderId { get; set; }

        public string CustomerId { get; set; } = null!;

        public int? Freight { get; set; }

        public DateTime? OrderDate { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

N> [IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsPrimaryKe) must be set to **true** for the column that holds a unique key.

### Insert a record

Click **Add** in the toolbar to create a new record. The grid sends a **POST** request to the OData controller:

![Insert Operation in Blazor](../images/odata-add-one.png)

Clicking the **Update** toolbar button will insert the record in the Orders table by calling the below **POST** method of the OData controller.

{% tabs %}
{% highlight c# tabtitle="OrdersController.cs" %}

[HttpPost]
public async Task<IActionResult> Post([FromBody] Orders order)
{
    _db.Orders.Add(order);
    await _db.SaveChangesAsync();
    return Created(order);
}

{% endhighlight %}
{% endtabs %}

![Insert Operation in Blazor](../images/odata-add-two.png)

### Update a record

Click **Edit** in the toolbar to modify an existing record. The grid sends a **PATCH** request:

{% tabs %}
{% highlight c# tabtitle="OrdersController.cs" %}

[HttpPatch]
public IActionResult Patch([FromODataUri] long key, [FromBody] Delta<Orders> order)
{
    var entity = _db.Orders.Find(key);
    order.Patch(entity);
    _db.SaveChanges();
    return Updated(entity);
}

{% endhighlight %}
{% endtabs %}

The resultant grid will look like below.

![Update Operation in Blazor](../images/odata-update-two.png)

### Delete a record

Click **Delete** in the toolbar to remove a record. The grid sends a **DELETE** request:

{% tabs %}
{% highlight c# tabtitle="OrdersController.cs" %}

[HttpDelete]
public IActionResult Delete([FromODataUri] long key)
{
    var entity = _db.Orders.Find(key);
    _db.Orders.Remove(entity);
    _db.SaveChanges();
    return NoContent();
}

{% endhighlight %}
{% endtabs %}

N> Find the sample at this [GitHub repository](https://github.com/SyncfusionExamples/binding-odata-services-and-perform-crud).
