---
layout: post
title: Bind data to Blazor components using WebApiAdaptor | CRUD | Syncfusion
description: Learn how to retrieve data from a Web API, bind it to the Syncfusion Blazor DataGrid using SfDataManager with WebApiAdaptor, and perform CRUD operations.
platform: Blazor
control: Common
documentation: ug
---

# Bind data to Blazor components using WebApiAdaptor and perform CRUD

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports data binding through the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component configured with [WebApiAdaptor](https://blazor.syncfusion.com/documentation/data/adaptors#web-api-adaptor). This adaptor is designed for scenarios where data is retrieved from **HTTP based Web API endpoints** that support **OData** query options. Since `WebApiAdaptor` extends [ODataAdaptor](https://blazor.syncfusion.com/documentation/data/adaptors#odata-adaptor), the API must process OData formatted queries included in requests.

**Key Capabilities of WebApiAdaptor**

* Enables communication with RESTful APIs instead of direct database access.
* Supports OData query options for **filtering**, **sorting**, and **paging**.
* Recommended for **Blazor WebAssembly** and **Auto** render mode to maintain security and scalability.

**Why Use HTTP API with Auto Render Mode**

The **Auto render mode** combines **Server** and **WebAssembly** interactivity, enabling hybrid rendering for improved performance and flexibility. In this configuration:

* Database access must remain on the server to ensure security.
* All data operations should be performed through **HTTP API endpoints**, preventing exposure of sensitive logic to client-side components.

This approach maintains scalability and protects application integrity when using hybrid rendering.

For other interactive render modes and interactivity locations, refer to Render Modes [documentation](https://blazor.syncfusion.com/documentation/common/interactive-render-mode).

## Prerequisite software

Before configuring the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid with Web API services, ensure the following:

- [Visual Studio 2022](https://visualstudio.microsoft.com/downloads/)
- .[NET SDK](https://dotnet.microsoft.com/en-us/download/dotnet) (**version 8.0 or later**; supports **.NET 8**, **.NET 9**, and **.NET 10** for Blazor Web Apps and Blazor Server projects)

## Create SQL Server database

A **SQL Server** database is required to store order details for the Blazor application. The database will be used by the API controller to perform **CRUD** operations.

1. **Open SQL Server Object Explorer in Visual Studio**

   Navigate to: **View → SQL Server Object Explorer**.

2. **Create a New Database**

    * Right-click the **Databases** folder.
    * Select **Add New Database**.

    ![Add new database in Blazor](../images/odata-add-db.png)

    * Name the database **OrdersDetails**.

    ![Adding database name and location in Blazor](../images/odata-db-name.png)

3. **Add a New Table**

    * Right-click the **Tables** folder in the created database.
    * Select **Add New Table**.

    ![Add table in Blazor](../images/odata-add-table.png)

4. **Create Orders Table Using SQL Script**

    Use this script to create the table:

    ```
    CREATE TABLE Orders (
        OrderID BIGINT IDENTITY(1,1) PRIMARY KEY NOT NULL,
        CustomerID VARCHAR(100) NOT NULL,
        Freight INT NULL,
        OrderDate DATETIME NULL
    );
   ```

5. **Apply Changes**

    * Review the table design.
    * Select **Update** to apply changes.

    ![Database table design in Blazor](../images/odata-table-design.png)

    * Select **Update Database** to finalize the schema.

    ![Update database in Blazor](../images/odata-update-db.png)

N> **Download SQL Script**: ![Orders Table Script](../images/create-orders-table.sql)

## Set Up Blazor Web App

Create a Blazor Web App using Visual Studio 2022 with [Microsoft Blazor templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio) for streamlined project creation.

1. Open **Visual Studio 2022**.
2. Select **Create a new project**.
3. Choose the **Blazor Web App** template.
4. Configure project options such as **name**, **location**, and **.NET version**.
5. Set [interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-10.0#render-modes) to **Auto** for hybrid interactivity.
6. Define [interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs#interactivity-location) as **Per page/component** or **Global** based on requirements.

## Generate DbContext and model classes

**Entity Framework Core** is used to scaffold the **DbContext** and model classes from the **OrdersDetails** database. This configuration enables strongly typed interaction with **SQL Server**.

When using **Auto render mode** or **Blazor WebAssembly**:

* Do not access the database directly from client-side components.
* Keep DbContext and model classes in the **server-side project**.
* Use **HTTP API endpoints** for all data operations to maintain security and scalability.

**Steps**

1. **Install Required NuGet Packages**

   In the **server-side project**, install:

    - [Microsoft.EntityFrameworkCore.Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools) – Provides scaffolding commands.
   - [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/) – Enables SQL Server support.

   **Options to install:**

    * Using **NuGet Package Manager** in Visual Studio:

        Navigate to: *Tools → NuGet Package Manager → Manage NuGet Packages for Solution*.

    * Using **Package Manager Console**:

        {% tabs %}
        {% highlight C# tabtitle="Package Manager" %}

        Install-Package Microsoft.EntityFrameworkCore.Tools

        Install-Package Microsoft.EntityFrameworkCore.SqlServer

        {% endhighlight %}
        {% endtabs %}

2. **Run Scaffolding Command**

    Execute this command in the **Package Manager Console**:

    ```powershell
    Scaffold-DbContext "Server=localhost;Database=OrdersDetails;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data
    ```

    This creates:

    * **OrdersDetailsContext.cs** – Database context.
    * **Orders.cs** – Entity class for the Orders table.

    {% tabs %}
    {% highlight c# tabtitle="OrdersDetailsContext.cs" hl_lines="21 22 23" %}

    using Microsoft.EntityFrameworkCore;

    namespace BlazorWebApp.Shared.Data;

    public partial class OrdersDetailsContext : DbContext
    {
        public OrdersDetailsContext()
        {
        }

        public OrdersDetailsContext(DbContextOptions<OrdersDetailsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)=> optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=OrdersDetails;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
    .....
    }
    {% endhighlight %}
    {% endtabs %}

3. **Store Connection String in appsettings.json**

    Avoid hardcoding connection strings in **OnConfiguring**. Use **appsettings.json**:

    ```json
        {
        "ConnectionStrings": {
            "OrdersDetailsDatabase": "Server=(localdb)\\MSSQLLocalDB;Database=OrdersDetails;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
        }
        }
    ```

4. **Register DbContext in Program.cs**

    Configure the context using dependency injection:

    ```cshtml
    builder.Services.AddDbContext<OrdersDetailsContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("OrdersDetailsDatabase")));
    ```

N> **Security Best Practice**: Hardcoding sensitive information in source files is a security risk. Always use configuration files or secure secrets management.

### Create API Controller for CRUD operations

The API controller exposes endpoints for performing **Create**, **Read**, **Update**, and **Delete** (**CRUD**) operations on the **OrdersDetails** database. This ensures that Blazor components interact with the database through HTTP APIs rather than direct DbContext access, which is essential for **Auto** render mode and **Blazor WebAssembly**.

**Steps**

1. **Add a New API Controller**

    1. In the server-side project, right-click the **Controllers** folder.
    2. Select **Add → New Item → API Controller with read/write actions**.
    3. Name the controller **OrdersController**.

2. **Implement CRUD Operations**

    Replace the default code with this implementation:

    {% tabs %}
    {% highlight c# tabtitle="OrdersController.cs" %}

    using Microsoft.AspNetCore.Mvc;
    using System.Linq;
    using WebAPICRUDServerApp.Data;

    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly OrdersDetailsContext _context;

        public OrdersController(OrdersDetailsContext context)
        {
            _context = context;
        }

        // GET: api/Orders
        [HttpGet]
        public IActionResult Get()
        {
            var items = _context.Orders.ToList();
            return Ok(new { Items = items, Count = items.Count });
        }

        // POST: api/Orders
        [HttpPost]
        public IActionResult Post([FromBody] Orders order)
        {
            _context.Orders.Add(order);
            _context.SaveChanges();
            return Ok(order);
        }

        // PUT: api/Orders/{id}
        [HttpPut("{id}")]
        public IActionResult Put(long id, [FromBody] Orders order)
        {
            var existingOrder = _context.Orders.FirstOrDefault(x => x.OrderId == id);
            if (existingOrder == null) return NotFound();

            existingOrder.CustomerId = order.CustomerId;
            existingOrder.Freight = order.Freight;
            existingOrder.OrderDate = order.OrderDate;

            _context.SaveChanges();
            return Ok(existingOrder);
        }

        // DELETE: api/Orders/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var order = _context.Orders.FirstOrDefault(x => x.OrderId == id);
            if (order == null) return NotFound();

            _context.Orders.Remove(order);
            _context.SaveChanges();
            return Ok();
        }
    }

    {% endhighlight %}
    {% endtabs %}

3. **Ensure Response Format for DataGrid Integration**

    The GET method must return a **JSON** object with:

    * **Items**: A collection of entities.
    * **Count**: Total number of entities.

    ```
    {
    "Items": [{...}, {...}, {...}],
    "Count": 830
    }
    ```

4. **Register Controller Routes**

    In **Program.cs**, enable controller routing:

    {% tabs %}
    {% highlight c# tabtitle=".NET 8 or later (~/Program.cs)" %}

    builder.Services.AddControllers();
    app.MapControllers();

    {% endhighlight %}
    {% endtabs %}

<!--## Create Blazor Server Application

You can create a **Blazor Server App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

### Generate DbContext and model class from the database

Now, you need to scaffold **DbContext** and **model classes** from the existing **OrdersDetails** database. To perform scaffolding and work with the SQL Server database in our application, install the following NuGet packages.

* [Microsoft.EntityFrameworkCore.Tools](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.Tools): This package creates database context and model classes from the database.
* [Microsoft.EntityFrameworkCore.SqlServer](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/): The database provider that allows Entity Framework Core to work with SQL Server.

Run the following commands in the Package Manager Console.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Microsoft.EntityFrameworkCore.Tools

Install-Package Microsoft.EntityFrameworkCore.SqlServer

{% endhighlight %}
{% endtabs %}

```
Scaffold-DbContext “Server=localhost;Database=OrdersDetails;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False” Microsoft.EntityFrameworkCore.SqlServer -OutputDir Data
```

The above scaffolding command contains the following details for creating DbContext and model classes for the existing database and its tables.
* **Connection string**: Server=localhost;Database=OrdersDetails;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
* **Data provider**: Microsoft.EntityFrameworkCore.SqlServer
* **Output directory**: -OutputDir Data

After running the above command, **OrdersDetailsContext.cs** and **Orders.cs** files will be created under the **WebAPICRUDServerApp.Data** folder as follows.

![Data folder in Blazor](../images/webapi-data-folder.png)

You can see that OrdersDetailsContext.cs file contains the connection string details in the **OnConfiguring** method.

{% tabs %}
{% highlight c# tabtitle="OrdersDetailsContext.cs" hl_lines="25" %}

using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPICRUDServerApp.Data
{
    public partial class OrdersDetailsContext : DbContext
    {
        public OrdersDetailsContext()
        {
        }

        public OrdersDetailsContext(DbContextOptions<OrdersDetailsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Order> Orders { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OrdersDetails;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
            }
        }

        ...
    }
}

{% endhighlight %}
{% endtabs %}

It is not recommended to have a connection string with sensitive information in the OrdersDetailsContext.cs file, so the connection string is moved to the **appsettings.json** file.

{% tabs %}
{% highlight json tabtitle="appsettings.json" %}

{
  "Logging": {
    "LogLevel": {
      "Default": "Information",
      "Microsoft.AspNetCore": "Warning"
    }
  },
  "AllowedHosts": "*",
  "ConnectionStrings": {
    "OrdersDetailsDatabase": "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=OrdersDetails;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"
  }
}

{% endhighlight %}
{% endtabs %}

Now, the DbContext must be configured using connection string and registered as scoped service using the AddDbContext method in **Program.cs** file in .NET 6 and .NET 7 application.

{% tabs %}
{% highlight c# tabtitle=".NET 6 & .NET 7 (~/Program.cs)" %}

builder.Services.AddDbContext<OrdersDetailsContext>(option =>
                option.UseSqlServer(builder.Configuration.GetConnectionString("OrdersDetailsDatabase")));

{% endhighlight %}
{% endtabs %}

### Creating API Controller

The application is now configured to connect with the **OrdersDetails** database using Entity Framework. Now, it’s time to consume data from the OrdersDetails database. To do so, you need a Web API controller to serve data from the DbContext to the Blazor application.

To create a Web API controller, right-click the **Controller** folder in the Server project and select **Add -> New Item -> API controller with read/write actions** to create a new Web API controller. We are naming this controller as OrdersController as it returns Orders table records.

Now, replace the Web API controller with the following code which contains code to handle CRUD operations in the Orders table.

{% tabs %}
{% highlight c# tabtitle="OrdersController.cs" %}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPICRUDServerApp.Data;

namespace WebAPICRUDServerApp
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private OrdersDetailsContext _context;
        public OrdersController(OrdersDetailsContext context)
        {
            _context = context;
        }
        // GET: api/<OrdersController>
        [HttpGet]
        public object Get()
        {
            return new { Items = _context.Orders, Count = _context.Orders.Count() };
        }
        // POST api/<OrdersController>
        [HttpPost]
        public void Post([FromBody] Orders book)
        {
            _context.Orders.Add(book);
            _context.SaveChanges();
        }
        // PUT api/<OrdersController>
        [HttpPut]
        public void Put(long id, [FromBody] Orders book)
        {
            Orders _book = _context.Orders.Where(x => x.OrderId.Equals(book.OrderId)).FirstOrDefault();
            _book.CustomerId = book.CustomerId;
            _book.Freight = book.Freight;
            _book.OrderDate = book.OrderDate;
            _context.SaveChanges();
        }
        // DELETE api/<OrdersController>
        [HttpDelete("{id}")]
        public void Delete(long id)
        {
            Orders _book = _context.Orders.Where(x => x.OrderId.Equals(id)).FirstOrDefault();
            _context.Orders.Remove(_book);
            _context.SaveChanges();
        }
    }
}

{% endhighlight %}
{% endtabs %}

* For **.NET 6 and .NET 7** applications open **Program.cs** file and add **MapDefaultControllerRoute** method as follows.

{% tabs %}
{% highlight c# tabtitle=".NET 6 & .NET 7 (~/Program.cs)" %}

......

app.UseRouting();

app.MapDefaultControllerRoute();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

{% endhighlight %}
{% endtabs %}
-->

## Install Syncfusion Blazor Packages

**Steps to Install and Configure**

1. **Install Required NuGet Packages**

   * For **Blazor Server** projects, install the following packages in the **server** project:

    * [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid/)
    * [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

    * For **Blazor Web Apps** using **Auto** or **WebAssembly** render modes, install these packages in the **client** project.

    **Options to install:**

    * Using NuGet Package Manager in Visual Studio:

        Navigate to: *Tools → NuGet Package Manager → Manage NuGet Packages for Solution*
    
    * Using Package Manager Console:

        ```powershell
        Install-Package Syncfusion.Blazor.Grid -Version {{ site.releaseversion }}
        Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}
        ```
> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) for a complete list.

2. **Import Required Namespaces**

    Add the following namespaces in the **~/_Imports.razor** file:

    {% highlight razor %}

    @using Syncfusion.Blazor
    @using Syncfusion.Blazor.Grids

    {% endhighlight %}

3. **Register Syncfusion Services**

    Register Syncfusion Blazor services in the **Program.cs** file:

    ```cshtml
    using Syncfusion.Blazor;

    builder.Services.AddSyncfusionBlazor();
    ```

    * For **Auto** render mode, register Syncfusion services in both **Program.cs** files (client and server projects).
    * For **Blazor Server**, register in the server-side **Program.cs** only.

4. **Add Theme Stylesheet**

    Include the Syncfusion theme in the <head> section:

    {% highlight cshtml %}

    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />

    {% endhighlight %}

    Add this stylesheet in the following locations based on the project type:

    * **Blazor Web App**: **~/Components/App.razor**
    * **Blazor WebAssembly**: **wwwroot/index.html**
    * **Blazor Server**: **~/Pages/_Host.cshtml**

5. **Add Script Reference**

    Include the Syncfusion script at the end of the <body>:

    ```html
    <body>

        <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
    </body>
    ```

## Add Syncfusion Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can be added to a Razor page and configured to bind data using SfDataManager with WebApiAdaptor.

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

Use [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) with `WebApiAdaptor` to connect the grid to the API controller:

    {% tabs %}
    {% highlight razor %}

    <SfGrid TValue="Orders">
        <SfDataManager Url="api/Orders" Adaptor="Adaptors.WebApiAdaptor"></SfDataManager>
    </SfGrid>

    {% endhighlight %}
    {% endtabs %}

**Define Grid Columns**

Configure columns using the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) component:

{% tabs %}
{% highlight razor %}

<SfGrid TValue="Orders">
    <SfDataManager Url="api/Orders" Adaptor="Adaptors.WebApiAdaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field=@nameof(Orders.OrderId) HeaderText="Order ID" IsPrimaryKey="true" Visible="false" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Orders.CustomerId) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Orders.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Orders.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

{% endhighlight %}
{% endtabs %}

N> * References:

> * [Syncfusion Blazor DataGrid Documentation](https://blazor.syncfusion.com/documentation/datagrid/getting-started)
> * [Syncfusion Blazor DataManager Documentation](https://blazor.syncfusion.com/documentation/data/getting-started)

## Handling CRUD operations with our Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid component

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports editing through the [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html) component. Editing modes include:

* [Inline](https://blazor.syncfusion.com/documentation/datagrid/in-line-editing)
* [Dialog](https://blazor.syncfusion.com/documentation/datagrid/dialog-editing)
* [Batch](https://blazor.syncfusion.com/documentation/datagrid/batch-editing).

The [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Toolbar) property displays action buttons such as **Add**, **Edit**, **Delete**, **Update**, and **Cancel** for performing **CRUD** operations.

{% tabs %}
{% highlight razor %}

<SfGrid TValue="Orders" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })">
    <SfDataManager Url="api/Orders" Adaptor="Adaptors.WebApiAdaptor"></SfDataManager>
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Orders.OrderId) HeaderText="Order ID" IsPrimaryKey="true" Visible="false" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Orders.CustomerId) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Orders.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Orders.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

{% endhighlight %}
{% endtabs %}

N> **Normal editing** is the default mode. Set the [IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsPrimaryKe) property to **true** for the column that holds a unique key.

### Insert a row

Click **Add** in the toolbar to open a new row for data entry. After entering values, click **Update** to save the record. This triggers the **POST** method in the API controller:

![Insert Operation in Blazor](../images/odata-add-one.png)

{% tabs %}
{% highlight c# tabtitle="OrdersController.cs" %}

[HttpPost]
public IActionResult Post([FromBody] Orders order)
{
    _context.Orders.Add(order);
    _context.SaveChanges();
    return Ok(order);
}

{% endhighlight %}
{% endtabs %}

![Insert Operation in Blazor](../images/odata-add-two.png)

### Update a row

Select a row and click **Edit** to modify its values. After editing, click **Update** to apply changes. This invokes the **PUT** method:

![Update Operation in Blazor](../images/odata-update-one.png)

{% tabs %}
{% highlight c# tabtitle="OrdersController.cs" %}

[HttpPut("{id}")]
public IActionResult Put(long id, [FromBody] Orders order)
{
    var existingOrder = _context.Orders.FirstOrDefault(x => x.OrderId == id);
    if (existingOrder == null) return NotFound();
    existingOrder.CustomerId = order.CustomerId;
    existingOrder.Freight = order.Freight;
    existingOrder.OrderDate = order.OrderDate;
    _context.SaveChanges();
    return Ok(existingOrder);
}

{% endhighlight %}
{% endtabs %}

![Update Operation in Blazor](../images/odata-update-two.png)

### Delete a row

Select a row and click **Delete** in the toolbar. This sends a **DELETE** request to remove the record:

{% tabs %}
{% highlight c# tabtitle="OrdersController.cs" %}

[HttpDelete("{id}")]
public IActionResult Delete(long id)
{
    var order = _context.Orders.FirstOrDefault(x => x.OrderId == id);
    if (order == null) return NotFound();
    _context.Orders.Remove(order);
    _context.SaveChanges();
    return Ok();
}

{% endhighlight %}
{% endtabs %}

N> Find the complete sample in the [GitHub repository](https://github.com/SyncfusionExamples/binding-webapi-services-and-perform-crud).
