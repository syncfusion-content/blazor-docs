---
layout: post
title: Blazor DataGrid with SQL via EF Core and REST API | Syncfusion
description: Bind SQL Server data to Blazor DataGrid using EF Core and REST API (UrlAdaptor) with CRUD, filtering, sorting, paging, and grouping.
platform: Blazor
control: DataGrid
documentation: ug
---

# Connecting SQL Server to Blazor DataGrid via EF Core and REST API

The Syncfusion Blazor DataGrid supports binding data from SQL Server using Entity Framework Core (EF Core) with REST API endpoints via UrlAdaptor. This approach enables clean separation of UI and data layers while supporting full data operations.

**What is Entity Framework Core?**

Entity Framework Core (EF Core) is a data access technology for .NET that simplifies working with databases like SQL Server by mapping C# classes to database tables and generating SQL at runtime.

**Key Benefits of Entity Framework Core**

- Automatic SQL generation with optimized queries
- Strongly typed models for compile-time safety
- Parameterization to mitigate SQL injection
- Migrations to version database schema changes
- LINQ queries for expressive data access

**What is Entity Framework Core SQL Server Provider?**

The Microsoft.EntityFrameworkCore.SqlServer package is the provider that connects EF Core to SQL Server, enabling CRUD, transactions, and SQL Server-specific features.

**What is UrlAdaptor?**

UrlAdaptor is a DataManager adaptor that communicates with REST API endpoints for all grid operations. The DataGrid sends read, insert, update, delete, and batch requests to controller actions, which use EF Core to access SQL Server.

## Prerequisites

Ensure the following software and packages are installed before proceeding:

| Software/Package | Version | Purpose |
|-----------------|---------|---------|
| Visual Studio 2022 | 17.0 or later | Development IDE with Blazor workload |
| .NET SDK | net10.0 or compatible | Runtime and build tools |
| SQL Server | 2019 or later | Database server |
| Syncfusion.Blazor.Grid | {{site.blazorversion}} | DataGrid and UI components |
| Syncfusion.Blazor.Themes | {{site.blazorversion}} | Styling for DataGrid components |
| Microsoft.EntityFrameworkCore | 10.0.2 | Core framework for database operations |
| Microsoft.EntityFrameworkCore.SqlServer | 10.0.2 | SQL Server provider for Entity Framework Core |

## Setting Up the SQL Server Environment for Entity Framework Core

### Step 1: Create the Database and Table in SQL Server

First, the SQL Server database structure must be created to store order records.

Instructions:
1. Open SQL Server Management Studio (SSMS) or any SQL Server client.
2. Create a new database named `OrderDB`.
3. Define an `Order` table with the specified schema.
4. Insert sample data for testing.

Run the following SQL script:

```sql
-- Create Database
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'OrderDB')
BEGIN
    CREATE DATABASE OrderDB;
END
GO

USE OrderDB;
GO

-- Create [Order] Table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Order' AND schema_id = SCHEMA_ID('dbo'))
BEGIN
    CREATE TABLE dbo.[Order] (
        OrderID INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
        CustomerID NVARCHAR(50) NOT NULL,
        EmployeeID INT NOT NULL,
        Freight DECIMAL(18,2) NOT NULL,
        ShipCity NVARCHAR(100) NOT NULL
    );
END
GO

-- Insert Sample Data (Optional)
INSERT INTO dbo.[Order] (CustomerID, EmployeeID, Freight, ShipCity)
VALUES
(N'ALFKI', 5, 32.50, N'Berlin'),
(N'BONAP', 7, 120.00, N'Marseille');
GO
```

After executing this script, the order records are stored in the `Order` table within the `OrderDB` database. The database is now ready for integration with the Blazor application.

### Step 2: Install Required NuGet Packages

Before installing the necessary NuGet packages, a new Blazor Web Application must be created using the default template. This template automatically generates essential starter files—such as **Program.cs**, **appsettings.json**, **wwwroot**, and **Components**.

For this guide, a Blazor application named **Grid_EF_UrlAdaptor** has been created. Once the project is set up, the next step involves installing the required NuGet packages. These packages enable Entity Framework Core with SQL Server provider and add Syncfusion UI components.

**Method 1: Using Package Manager Console**

1. Open Visual Studio 2022.
2. Navigate to Tools → NuGet Package Manager → Package Manager Console.
3. Run the following commands:

```powershell
Install-Package Microsoft.EntityFrameworkCore -Version 10.0.2;
Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 10.0.2;
Install-Package Syncfusion.Blazor.Grid -Version {{site.blazorversion}};
Install-Package Syncfusion.Blazor.Themes -Version {{site.blazorversion}}
```

**Method 2: Using NuGet Package Manager UI**

1. Open Visual Studio 2022 → Tools → NuGet Package Manager → Manage NuGet Packages for Solution.
2. Search for and install each package individually:
   - **Microsoft.EntityFrameworkCore** (version 10.0.2)
   - **Microsoft.EntityFrameworkCore.SqlServer** (version 10.0.2)
   - **Syncfusion.Blazor.Grid** (version {{site.blazorversion}})
   - **Syncfusion.Blazor.Themes** (version {{site.blazorversion}})

All required packages are now installed.

### Step 3: Create the Data Model

A data model is a C# class that represents the structure of a database table. This model defines the properties that correspond to the columns in the `Order` table.

**Instructions:**

1. Create a new folder named `Data` in the Blazor application project.
2. Inside the `Data` folder, create a new file named **Order.cs**.
3. Define the **Order** class with the following code:

```csharp
using System.ComponentModel.DataAnnotations.Schema;

namespace Grid_EF_UrlAdaptor.Data
{
    [Table("Order")]
    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public int EmployeeID { get; set; }
        public decimal Freight { get; set; }
        public string ShipCity { get; set; }
    }
}
```

**Explanation:**
- `[Table("Order")]` maps the entity explicitly to the SQL table named `Order`.
- Each property represents a column in the table.
- `OrderID` is the identifier used as the primary key in the table script created earlier.

The data model has been successfully created.

### Step 4: Configure the DbContext

A `DbContext` is a special class that manages the connection between the application and the SQL Server database. It handles all database operations such as saving, updating, deleting, and retrieving data.

**Instructions:**

1. Inside the `Data` folder, create a new file named **OrderDbContext.cs**.
2. Define the `OrderDbContext` class with the following code:

```csharp
using Microsoft.EntityFrameworkCore;

namespace Grid_EF_UrlAdaptor.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions<OrderDbContext> options) : base(options) { }
        public DbSet<Order> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Explicitly map DbSet<Order> to the [Order] table
            modelBuilder.Entity<Order>().ToTable("Order");
        }
    }
}
```

**Explanation:**
- `OrderDbContext` inherits from `DbContext` and exposes `DbSet<Order>` to query and save `Order` entities.
- `modelBuilder.Entity<Order>().ToTable("Order")` ensures EF Core maps the entity to the `Order` table.

The DbContext has been successfully configured.

### Step 5: Configure the Connection String

A connection string contains the information needed to connect the application to the SQL Server database, including the server address, database name, and authentication credentials.

**Instructions:**

1. Open the **appsettings.json** file in the project root.
2. Add or verify the `ConnectionStrings` section with the SQL Server connection details:

```json
{
  "ConnectionStrings": {
    "ConnectionString": "Data Source=CustomSQLServer;Initial Catalog=OrderDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False;Command Timeout=30"
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

**Connection String Components:**

| Component | Description |
|-----------|-------------|
| Data Source | The SQL Server instance (e.g., `CustomSQLServer`) |
| Initial Catalog | The database name (`OrderDB`) |
| Integrated Security | `True` for Windows Authentication |
| Connect Timeout | Connection timeout in seconds |
| Encrypt | Enables encryption for the connection |
| Trust Server Certificate | Whether to trust the server certificate |
| Application Intent | `ReadWrite` for normal operations |
| Multi Subnet Failover | Typically `False` unless using multi-subnet clustering |
| Command Timeout | Command execution timeout in seconds |

The database connection string has been configured successfully.


### Step 6: Create the Grid API Controller

A controller exposes REST API endpoints for the grid to read data. This step adds minimal GET and POST endpoints that return empty results. Additional CRUD and batch endpoints will be added later when configuring UrlAdaptor.

**Instructions:**

1. Create a new folder named `Controllers` in the project.
2. Inside the `Controllers` folder, create a new file named **GridController.cs**.
3. Add the following code:

```csharp
using Microsoft.AspNetCore.Mvc;
using Grid_EF_UrlAdaptor.Data;
using System.Collections.Generic;

namespace Grid_EF_UrlAdaptor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GridController : ControllerBase
    {
        private readonly OrderDbContext _context;

        public GridController(OrderDbContext context)
        {
            _context = context;
        }

        // GET: api/Grid
        [HttpGet]
        public ActionResult<List<Order>> Get()
        {
            return Ok(new List<Order>());
        }

        // POST: api/Grid (DataManager read)
        [HttpPost]
        public ActionResult<object> Post([FromBody] DataManagerRequest dataManagerRequest)
        {
            return Ok(new { result = new List<Order>(), count = 0 });
        }
    }
}
```

The controller has been created with basic GET and POST endpoints.

### Step 7: Register Services in Program.cs

The `Program.cs` file is where application services are registered and configured. This step enables Entity Framework Core, controllers, Syncfusion Blazor, and maps controller routes.

**Instructions:**

1. Open the **Program.cs** file at the project root.
2. Add the following code after the line `var builder = WebApplication.CreateBuilder(args);`:

```csharp
using Grid_EF_UrlAdaptor.Components;
using Grid_EF_UrlAdaptor.Data;
using Microsoft.EntityFrameworkCore;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddControllers();

// ========== ENTITY FRAMEWORK CORE CONFIGURATION ==========
// Get connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("ConnectionString");
// Register DbContext with SQL Server provider
builder.Services.AddDbContext<OrderDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});
// ========================================================

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();
app.MapControllers();
app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
```

**Explanation:**

- `AddControllers()` registers MVC controllers for REST endpoints.
- `AddDbContext<OrderDbContext>()` configures EF Core to use SQL Server with the `ConnectionString` from appsettings.json.
- `MapControllers()` exposes routes like `/api/Grid`.
- Syncfusion Blazor and Razor components are registered for the UI.

## Integrating Syncfusion Blazor DataGrid with UrlAdaptor

### Step 1: Install and Configure Blazor DataGrid Components

Syncfusion is a library that provides pre-built UI components like DataGrid, which is used to display data in a table format.

**Instructions:**

1. The **Syncfusion.Blazor.Grid** and **Syncfusion.Blazor.Themes** packages were installed in Step 2 of the previous section.
2. Import the required namespaces in the `Components/_Imports.razor` file:

```csharp
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
```

3. Add the Syncfusion stylesheet and scripts in the `Components/App.razor` file. Find the `<head>` section and add:

```html
<!-- Syncfusion Blazor Stylesheet -->
<link href="_content/Syncfusion.Blazor.Themes/fluent.css" rel="stylesheet" />

<!-- Syncfusion Blazor Scripts -->
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
```

For this project, the **fluent** theme is used. A different theme can be selected or customized based on project requirements. Refer to the [Syncfusion Blazor Components Appearance](https://blazor.syncfusion.com/documentation/appearance/themes) documentation to learn more about theming and customization options.

Syncfusion components are now configured and ready to use. For additional guidance, refer to the Grid component's [getting‑started](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app) documentation.

### Step 2: Update the Blazor DataGrid

The `Home.razor` component will display the order data in a Syncfusion Blazor DataGrid with search, filter, sort, paging, and CRUD capabilities using UrlAdaptor to communicate with REST API endpoints.

**Instructions:**

1. Open the file named `Home.razor` in the `Components/Pages` folder.
2. Replace the entire content with the following code:

```cshtml
@page "/"

<SfGrid TValue="Order" AllowPaging="true" AllowFiltering="true" AllowSorting="true" AllowGrouping="true"
        Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" })" Width="100%" Height="600px">
    <SfDataManager Url="http://localhost:5175/api/Grid"
                   InsertUrl="http://localhost:5175/api/Grid/Insert"
                   UpdateUrl="http://localhost:5175/api/Grid/Update"
                   RemoveUrl="http://localhost:5175/api/Grid/Delete"
                   BatchUrl="http://localhost:5175/api/Grid/BatchUpdate"
                   Adaptor="Adaptors.UrlAdaptor">
    </SfDataManager>
    <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Menu"></GridFilterSettings>
    <GridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="EditMode.Normal"></GridEditSettings>

    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsIdentity="true" IsPrimaryKey="true"
                    TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.EmployeeID) HeaderText="Employee ID" TextAlign="TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" TextAlign="TextAlign.Right" Format="C2" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
    </GridColumns>
    <GridPageSettings PageSize="10"></GridPageSettings>
</SfGrid>

```

**Component Explanation:**

- **`<SfGrid>`**: The DataGrid component that displays order data in rows and columns.
- **`<SfDataManager>`**: Manages data communication with REST API endpoints using UrlAdaptor. The `Url` property points to the read endpoint, while `InsertUrl`, `UpdateUrl`, `RemoveUrl`, and `BatchUrl` point to CRUD endpoints.
- **`AllowPaging="true"`**: Enables pagination to display records in pages of 10 records each.
- **`AllowFiltering="true"`**: Enables column filtering with menu-based filters.
- **`AllowSorting="true"`**: Enables column sorting by clicking headers.
- **`AllowGrouping="true"`**: Allows grouping by dragging columns to the group area.
- **`<GridColumns>`**: Defines the columns displayed in the grid, mapped to `Order` model properties.
- **`<GridPageSettings>`**: Configures pagination with 10 records per page.
- **`<GridFilterSettings>`**: Configures filter type as `Menu` for dropdown-style filtering.
- **`<GridEditSettings>`**: Enables inline editing in `Normal` mode (edit one row at a time).
- **`Toolbar`**: "Add", "Edit", "Delete", "Update", "Cancel", "Search" for CRUD and search operations.

### Step 3: Implement the Endpoints for UrlAdaptor

The UrlAdaptor communicates with REST API endpoints for grid operations rather than executing logic in the component. The grid sends requests to endpoints defined in a controller. Below is the controller structure with the same decorators and signatures as in the project, with placeholder comments to add logic.

Open the file named **Controllers/GridController.cs** and use the following structure:

```csharp
using Grid_EF_UrlAdaptor.Data;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;
using System.Text.Json.Serialization;

namespace Grid_EF_UrlAdaptor.Controllers
{
    [ApiController]
    public class GridController : ControllerBase
    {
        private readonly OrderDbContext _context;

        public GridController(OrderDbContext context)
        {
            _context = context; // implement logic here
        }

        /// <summary>
        /// Returns data with search, filter, sort, and paging operations
        /// </summary>
        [HttpPost]
        [Route("api/[controller]")]
        public object Post([FromBody] DataManagerRequest dataManagerRequest)
        {
            // implement logic here
            return new { }; // placeholder
        }

        /// <summary>
        /// Retrieves all order data from the database
        /// </summary>
        [HttpGet]
        [Route("api/[controller]")]
        public List<Order> GetOrderData()
        {
            // implement logic here
            return new List<Order>();
        }

        /// <summary>
        /// Inserts a new order record
        /// </summary>
        [HttpPost("Insert")]
        [Route("api/[controller]/Insert")]
        public void Insert([FromBody] CRUDModel<Order> value)
        {
            // implement logic here
        }

        /// <summary>
        /// Updates an existing order record
        /// </summary>
        [HttpPost("Update")]
        [Route("api/[controller]/Update")]
        public void Update([FromBody] CRUDModel<Order> value)
        {
            // implement logic here
        }

        /// <summary>
        /// Deletes an order record
        /// </summary>
        [HttpPost("Delete")]
        [Route("api/[controller]/Delete")]
        public void Delete([FromBody] CRUDModel<Order> value)
        {
            // implement logic here
        }

        /// <summary>
        /// Batch operations for Insert, Update, and Delete
        /// </summary>
        [HttpPost("Batch")]
        [Route("api/[controller]/BatchUpdate")]
        public void Batch([FromBody] CRUDModel<Order> value)
        {
            // implement logic here
        }
    }

    /// <summary>
    /// CRUD Model for handling data operations
    /// </summary>
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
```

The `CRUDModel<T>` is the payload contract used by UrlAdaptor for insert, update, delete, and batch requests.
It carries the primary key, single entity (Value), and collections (Added, Changed, Deleted) for batch operations.

This controller exposes the endpoints used by `<SfDataManager>` in **Home.razor**. Logic will be added in later steps when wiring CRUD and batch operations.

### Step 4: Implement Paging Feature

Paging divides large datasets into smaller pages to improve performance and usability.

**Instructions:**

1. Ensure the grid has paging enabled with `AllowPaging="true"`.
2. Configure the page size using `GridPageSettings`.

```cshtml
<SfGrid TValue="Order" AllowPaging="true">
    <SfDataManager Url="http://localhost:5175/api/Grid" Adaptor="Adaptors.UrlAdaptor"></SfDataManager>
    <GridColumns>
        <!-- Columns configuration -->
    </GridColumns>

    <GridPageSettings PageSize="10"></GridPageSettings>
</SfGrid>
```

3. Update the `Post` action in **Controllers/GridController.cs** to apply only paging using `Skip` and `Take` from `DataManagerRequest`:

```csharp
[HttpPost]
[Route("api/[controller]")]
public object Post([FromBody] DataManagerRequest dataManagerRequest)
{
    IEnumerable<Order> dataSource = GetOrderData();

    int totalRecordsCount = dataSource.Count();

    // Handling Paging
    if (dataManagerRequest.Skip != 0)
    {
        dataSource = DataOperations.PerformSkip(dataSource, dataManagerRequest.Skip);
    }

    if (dataManagerRequest.Take != 0)
    {
        dataSource = DataOperations.PerformTake(dataSource, dataManagerRequest.Take);
    }

    return new { result = dataSource, count = totalRecordsCount };
}
```

**How Paging Works:**
- The grid posts `Skip` and `Take` to `http://localhost:5175/api/Grid`.
- The controller returns the paged `result` and total `count` for correct pager UI.
- Only paging logic is shown here; other operations will be covered in later steps.

### Step 5: Implement Searching Feature

Searching allows the user to find records by entering keywords in the search box, which filters data across all columns.

**Instructions:**

1. Ensure the toolbar includes the "Search" item.

```cshtml
<SfGrid TValue="Order" 
        AllowPaging="true"
        Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" })">
    <SfDataManager Url="http://localhost:5175/api/Grid" Adaptor="Adaptors.UrlAdaptor"></SfDataManager>
    <GridPageSettings PageSize="10"></GridPageSettings>
</SfGrid>
```

2. Update the `Post` action in **Controllers/GridController.cs** to handle searching:

```csharp
[HttpPost]
[Route("api/[controller]")]
public object Post([FromBody] DataManagerRequest dataManagerRequest)
{
    try
    {
        IEnumerable<Order> dataSource = GetOrderData();

        // Handling Searching
        if (dataManagerRequest.Search != null && dataManagerRequest.Search.Count > 0)
        {
            dataSource = DataOperations.PerformSearching(dataSource, dataManagerRequest.Search);
        }

        int totalRecordsCount = dataSource.Count();

        // Handling Paging
        if (dataManagerRequest.Skip != 0)
        {
            dataSource = DataOperations.PerformSkip(dataSource, dataManagerRequest.Skip);
        }

        if (dataManagerRequest.Take != 0)
        {
            dataSource = DataOperations.PerformTake(dataSource, dataManagerRequest.Take);
        }

        return new { result = dataSource, count = totalRecordsCount };
    }
    catch (Exception ex)
    {
        return new { error = ex.Message, innerError = ex.InnerException?.Message };
    }
}
```

**How Searching Works:**

- When the user enters text in the search box and presses Enter, the DataGrid sends a search request to the REST API.
- The `Post` method receives the search criteria in `dataManagerRequest.Search`.
- The `DataOperations.PerformSearching()` method filters the data based on the search term across all columns.
- Results are returned and displayed in the DataGrid with pagination applied.

Searching feature is now active.

---

### Step 6: Implement Filtering Feature

Filtering allows the user to restrict data based on column values using a menu interface.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Add the [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowFiltering) property and [GridFilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridFilterSettings.html) to the `<SfGrid>` component:

```cshtml
<SfGrid TValue="Order" 
        AllowPaging="true" 
        AllowFiltering="true"
        Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" })">
    <SfDataManager Url="http://localhost:5175/api/Grid" Adaptor="Adaptors.UrlAdaptor"></SfDataManager>
    <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Menu"></GridFilterSettings>
    <GridPageSettings PageSize="10"></GridPageSettings>
</SfGrid>
```

3. Update the `Post` action in **Controllers/GridController.cs** to handle filtering:

```csharp
[HttpPost]
[Route("api/[controller]")]
public object Post([FromBody] DataManagerRequest dataManagerRequest)
{
    try
    {
        IEnumerable<Order> dataSource = GetOrderData();

        // Handling Searching
        if (dataManagerRequest.Search != null && dataManagerRequest.Search.Count > 0)
        {
            dataSource = DataOperations.PerformSearching(dataSource, dataManagerRequest.Search);
        }

        // Handling Filtering
        if (dataManagerRequest.Where != null && dataManagerRequest.Where.Count > 0)
        {
            foreach (var condition in dataManagerRequest.Where)
            {
                foreach (var predicate in condition.predicates)
                {
                    dataSource = DataOperations.PerformFiltering(dataSource, dataManagerRequest.Where, predicate.Operator);
                }
            }
        }

        int totalRecordsCount = dataSource.Count();

        // Handling Paging
        if (dataManagerRequest.Skip != 0)
        {
            dataSource = DataOperations.PerformSkip(dataSource, dataManagerRequest.Skip);
        }

        if (dataManagerRequest.Take != 0)
        {
            dataSource = DataOperations.PerformTake(dataSource, dataManagerRequest.Take);
        }

        return new { result = dataSource, count = totalRecordsCount };
    }
    catch (Exception ex)
    {
        return new { error = ex.Message, innerError = ex.InnerException?.Message };
    }
}
```

**How Filtering Works:**

- Click on the dropdown arrow in any column header to open the filter menu.
- Select filtering criteria (equals, contains, greater than, less than, etc.).
- Click the "Filter" button to apply the filter.
- The `Post` method receives the filter criteria in `dataManagerRequest.Where`.
- The `DataOperations.PerformFiltering()` method applies the filter conditions to the data.
- Results are filtered accordingly and displayed in the DataGrid.

Filtering feature is now active.

---

### Step 7: Implement Sorting Feature

Sorting enables the user to arrange records in ascending or descending order based on column values.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Add the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) property to the `<SfGrid>` component:

```cshtml
<SfGrid TValue="Order" 
        AllowPaging="true" 
        AllowSorting="true"
        AllowFiltering="true"
        Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" })">
    <SfDataManager Url="http://localhost:5175/api/Grid"Adaptor="Adaptors.UrlAdaptor"></SfDataManager>
    <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Menu"></GridFilterSettings>
    <GridPageSettings PageSize="10"></GridPageSettings>
</SfGrid>
```

3. Update the `Post` action in **Controllers/GridController.cs** to handle sorting:

```csharp
[HttpPost]
[Route("api/[controller]")]
public object Post([FromBody] DataManagerRequest dataManagerRequest)
{
    try
    {
        IEnumerable<Order> dataSource = GetOrderData();

        // Handling Searching
        if (dataManagerRequest.Search != null && dataManagerRequest.Search.Count > 0)
        {
            dataSource = DataOperations.PerformSearching(dataSource, dataManagerRequest.Search);
        }

        // Handling Filtering
        if (dataManagerRequest.Where != null && dataManagerRequest.Where.Count > 0)
        {
            foreach (var condition in dataManagerRequest.Where)
            {
                foreach (var predicate in condition.predicates)
                {
                    dataSource = DataOperations.PerformFiltering(dataSource, dataManagerRequest.Where, predicate.Operator);
                }
            }
        }

        // Handling Sorting
        if (dataManagerRequest.Sorted != null && dataManagerRequest.Sorted.Count > 0)
        {
            dataSource = DataOperations.PerformSorting(dataSource, dataManagerRequest.Sorted);
        }

        int totalRecordsCount = dataSource.Count();

        // Handling Paging
        if (dataManagerRequest.Skip != 0)
        {
            dataSource = DataOperations.PerformSkip(dataSource, dataManagerRequest.Skip);
        }

        if (dataManagerRequest.Take != 0)
        {
            dataSource = DataOperations.PerformTake(dataSource, dataManagerRequest.Take);
        }

        return new { result = dataSource, count = totalRecordsCount };
    }
    catch (Exception ex)
    {
        return new { error = ex.Message, innerError = ex.InnerException?.Message };
    }
}
```

**How Sorting Works:**

- Click on the column header to sort in ascending order.
- Click again to sort in descending order.
- The `Post` method receives the sort criteria in `dataManagerRequest.Sorted`.
- The `DataOperations.PerformSorting()` method sorts the data based on the specified column and direction.
- Records are sorted accordingly and displayed in the DataGrid.

Sorting feature is now active.

---

### Step 8: Implement Grouping Feature

Grouping organizes records into hierarchical groups based on column values.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Add the [AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowGrouping) property to the `<SfGrid>` component:

```cshtml
<SfGrid TValue="Order" 
        AllowPaging="true" 
        AllowSorting="true"
        AllowFiltering="true"
        AllowGrouping="true"
        Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" })" 
        Width="100%" Height="600px">
    <SfDataManager Url="http://localhost:5175/api/Grid" Adaptor="Adaptors.UrlAdaptor"></SfDataManager>
    <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Menu"></GridFilterSettings>
    <GridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridPageSettings PageSize="10"></GridPageSettings>
</SfGrid>
```

3. Update the `Post` action in **Controllers/GridController.cs** to handle grouping:

```csharp
[HttpPost]
[Route("api/[controller]")]
public object Post([FromBody] DataManagerRequest dataManagerRequest)
{
    try
    {
        IEnumerable<Order> dataSource = GetOrderData();

        // Handling Searching
        if (dataManagerRequest.Search != null && dataManagerRequest.Search.Count > 0)
        {
            dataSource = DataOperations.PerformSearching(dataSource, dataManagerRequest.Search);
        }

        // Handling Filtering
        if (dataManagerRequest.Where != null && dataManagerRequest.Where.Count > 0)
        {
            foreach (var condition in dataManagerRequest.Where)
            {
                foreach (var predicate in condition.predicates)
                {
                    dataSource = DataOperations.PerformFiltering(dataSource, dataManagerRequest.Where, predicate.Operator);
                }
            }
        }

        // Handling Sorting
        if (dataManagerRequest.Sorted != null && dataManagerRequest.Sorted.Count > 0)
        {
            dataSource = DataOperations.PerformSorting(dataSource, dataManagerRequest.Sorted);
        }

        // Handling Grouping
        if (dataManagerRequest.Group != null && dataManagerRequest.Group.Count > 0)
        {
            dataSource = (IEnumerable<Order>)DataOperations.PerformGrouping(dataSource, dataManagerRequest.Group);
        }

        int totalRecordsCount = dataSource.Cast<Order>().Count();

        // Handling Aggregation
        IDictionary<string, object> aggregates = null;
        if (dataManagerRequest.Aggregates != null)
        {
            aggregates = DataUtil.PerformAggregation(dataSource, dataManagerRequest.Aggregates);
        }

        // Handling Paging
        if (dataManagerRequest.Skip != 0)
        {
            dataSource = DataOperations.PerformSkip(dataSource, dataManagerRequest.Skip);
        }

        if (dataManagerRequest.Take != 0)
        {
            dataSource = DataOperations.PerformTake(dataSource, dataManagerRequest.Take);
        }

        return new { result = dataSource, count = totalRecordsCount, aggregates = aggregates };
    }
    catch (Exception ex)
    {
        return new { error = ex.Message, innerError = ex.InnerException?.Message };
    }
}
```

**How Grouping Works:**

- Columns can be grouped by dragging the column header into the group drop area.
- Each group can be expanded or collapsed by clicking on the group header.
- The `Post` method receives the grouping instructions through `dataManagerRequest.Group`.
- The grouping operation is processed using **DataOperations.PerformGrouping**, which organizes the records into hierarchical groups based on the selected column.
- Grouping is performed after search, filter, and sort operations, ensuring the grouped data reflects all applied conditions.
- The processed grouped result is then returned to the **Grid** and displayed in a structured, hierarchical format.

Grouping feature is now active.

---

### Step 9: Perform CRUD Operations

CRUD operations (Create, Read, Update, Delete) enable users to manage data directly from the DataGrid. The REST API endpoints in the controller handle all database operations using Entity Framework Core.

**Instructions:**

1. Update the `<SfGrid>` component in `Home.razor` to include [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html):

```cshtml
<SfGrid TValue="Order" 
        AllowPaging="true" 
        AllowSorting="true"
        AllowFiltering="true"
        AllowGrouping="true"
        Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" })" 
        Width="100%" Height="600px">
    <SfDataManager Url="http://localhost:5175/api/Grid"
                   InsertUrl="http://localhost:5175/api/Grid/Insert"
                   UpdateUrl="http://localhost:5175/api/Grid/Update"
                   RemoveUrl="http://localhost:5175/api/Grid/Delete"
                   BatchUrl="http://localhost:5175/api/Grid/BatchUpdate"
                   Adaptor="Adaptors.UrlAdaptor">
    </SfDataManager>
    <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Menu"></GridFilterSettings>
    <GridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridPageSettings PageSize="10"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsIdentity="true" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.EmployeeID) HeaderText="Employee ID" TextAlign="TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" TextAlign="TextAlign.Right" Format="C2" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>
```

**Insert (Create)**

Record insertion allows new orders to be added directly through the DataGrid component. The `Insert` endpoint processes the insertion request and saves the newly created record to the SQL Server database.

In **Controllers/GridController.cs**, the insert method is implemented as:

```csharp
/// <summary>
/// Inserts a new order record
/// </summary>
[HttpPost("Insert")]
[Route("api/[controller]/Insert")]
public void Insert([FromBody] CRUDModel<Order> value)
{
    try
    {
        _context.Orders.Add(value.Value);
        _context.SaveChanges();
    }
    catch (Exception ex)
    {
        throw new Exception($"Error inserting order: {ex.Message}");
    }
}
```

**What happens behind the scenes:**

1. The user clicks the "Add" button and fills in the form.
2. The DataGrid sends a POST request to `http://localhost:5175/api/Grid/Insert`.
3. The `Insert` method receives the new order data in `value.Value`.
4. Entity Framework Core adds the record to the `_context.Orders` collection.
5. `SaveChanges()` persists the record to the SQL Server database.
6. The DataGrid automatically refreshes to display the new order.

**Update (Edit)**

Record modification allows order details to be updated directly within the DataGrid. The `Update` endpoint processes the edited row and applies the changes to the SQL Server database.

In **Controllers/GridController.cs**, the update method is implemented as:

```csharp
/// <summary>
/// Updates an existing order record
/// </summary>
[HttpPost("Update")]
[Route("api/[controller]/Update")]
public void Update([FromBody] CRUDModel<Order> value)
{
    try
    {
        var existingOrder = _context.Orders.Find(value.Value.OrderID);
        if (existingOrder != null)
        {
            _context.Entry(existingOrder).CurrentValues.SetValues(value.Value);
            _context.SaveChanges();
        }
    }
    catch (Exception ex)
    {
        throw new Exception($"Error updating order: {ex.Message}");
    }
}
```

**What happens behind the scenes:**

1. The user clicks the "Edit" button and modifies the record.
2. The DataGrid sends a POST request to `http://localhost:5175/api/Grid/Update`.
3. The `Update` method receives the modified order data in `value.Value`.
4. The existing order is retrieved from the database by its ID.
5. The properties are updated with the new values using `SetValues()`.
6. `SaveChanges()` persists the changes to the SQL Server database.
7. The DataGrid refreshes to display the updated order.

**Delete (Remove)**

Record deletion allows orders to be removed directly from the DataGrid. The `Delete` endpoint executes the corresponding SQL Server DELETE operation and updates both the database and the grid.

In **Controllers/GridController.cs**, the delete method is implemented as:

```csharp
/// <summary>
/// Deletes an order record
/// </summary>
[HttpPost("Delete")]
[Route("api/[controller]/Delete")]
public void Delete([FromBody] CRUDModel<Order> value)
{
    try
    {
        int orderId = Convert.ToInt32(value.Key.ToString());
        var order = _context.Orders.Find(orderId);
        if (order != null)
        {
            _context.Orders.Remove(order);
            _context.SaveChanges();
        }
    }
    catch (Exception ex)
    {
        throw new Exception($"Error deleting order: {ex.Message}");
    }
}
```

**What happens behind the scenes:**

1. The user selects an order and clicks "Delete".
2. A confirmation dialog appears (built into the DataGrid).
3. If confirmed, the DataGrid sends a POST request to `http://localhost:5175/api/Grid/Delete`.
4. The `Delete` method extracts the order ID from `value.Key`.
5. The order is located in the database by its ID.
6. The order is removed from the `_context.Orders` collection.
7. `SaveChanges()` executes the DELETE statement in SQL Server.
8. The DataGrid refreshes to remove the deleted order from the UI.

**Batch Operations (Multiple CRUD in one request)**

Batch operations combine multiple insert, update, and delete actions into a single request, minimizing network overhead and ensuring transactional consistency.

In **Controllers/GridController.cs**, the batch method is implemented as:

```csharp
/// <summary>
/// Batch operations for Insert, Update, and Delete
/// </summary>
[HttpPost("Batch")]
[Route("api/[controller]/BatchUpdate")]
public void Batch([FromBody] CRUDModel<Order> value)
{
    try
    {
        if (value.Changed != null)
        {
            foreach (var record in value.Changed)
            {
                _context.UpdateRange(record);
            }
        }

        if (value.Added != null)
        {
            _context.Orders.AddRange(value.Added);
        }

        if (value.Deleted != null)
        {
            foreach (var record in value.Deleted)
            {
                var existingOrder = _context.Orders.Find(record.OrderID);
                if (existingOrder != null)
                {
                    _context.Orders.Remove(existingOrder);
                }
            }
        }

        _context.SaveChanges();
    }
    catch (Exception ex)
    {
        throw new Exception($"Error in batch operations: {ex.Message}");
    }
}
```

**What happens behind the scenes:**

- The DataGrid collects all added, edited, and deleted records.
- All changes are sent in a single POST request to `http://localhost:5175/api/Grid/BatchUpdate`.
- The `Batch` method processes changed records using `UpdateRange()`.
- The `Batch` method processes added records using `AddRange()`.
- The `Batch` method processes deleted records using `Remove()`.
- All operations are saved to the database in a single `SaveChanges()` call for transactional consistency.
- The DataGrid refreshes to display all changes.

All CRUD operations are now fully implemented, enabling comprehensive data management capabilities within the Blazor DataGrid.

---

## Running the Application

**Step 1: Build the Application**

1. Open PowerShell or your terminal.
2. Navigate to the project directory.
3. Build the application:

```powershell
dotnet build
```

**Step 2: Run the Application**

Execute the following command:

```powershell
dotnet run
```

The application will start, and the console will display the local URL (typically `http://localhost:5175` or `https://localhost:5001`).

**Step 3: Access the Application**

1. Open a web browser.
2. Navigate to the URL displayed in the console.
3. The DataGrid application is now running and ready to use.

**Available Features**

- **View Data**: All orders from the SQL Server database are displayed in the DataGrid.
- **Search**: Use the search box to find orders by any field (CustomerID, ShipCity, etc.).
- **Filter**: Click on column headers to apply filters (equals, contains, etc.).
- **Sort**: Click on column headers to sort data in ascending or descending order.
- **Pagination**: Navigate through records using page numbers (10 records per page).
- **Add**: Click the "Add" button to create a new order.
- **Edit**: Click the "Edit" button to modify existing orders.
- **Delete**: Click the "Delete" button to remove orders.
- **Group**: Drag column headers to the group area to organize data hierarchically.

---

## Complete Sample Repository

A complete, working sample implementation is available in the [GitHub repository](https://github.com/SyncfusionExamples/connecting-databases-to-blazor-datagrid-component/tree/master/Bindind%20SQL%20database%20using%20EF%20and%20UrlAdaptor).

---

## Summary

This guide demonstrates how to:

1. Create a SQL Server database with order records. [🔗](#step-1-create-the-database-and-table-in-sql-server)
2. Install necessary NuGet packages for Entity Framework Core and Syncfusion. [🔗](#step-2-install-required-nuget-packages)
3. Create data models and DbContext for database communication. [🔗](#step-3-create-the-data-model)
4. Configure connection strings and register services in Program.cs. [🔗](#step-5-configure-the-connection-string)
5. Create REST API endpoints in a controller for CRUD operations. [🔗](#step-6-create-the-grid-api-controller)
6. Implement searching, filtering, and sorting in the REST API. [🔗](#step-5-implement-searching-feature)
7. Enable grouping and pagination for efficient data management. [🔗](#step-8-implement-grouping-feature)
8. Perform complete CRUD operations (Create, Read, Update, Delete) via REST API. [🔗](#step-9-perform-crud-operations)
9. Handle batch operations for bulk data modifications. [🔗](#step-9-perform-crud-operations)

The application now provides a complete solution for managing orders with a modern, user-friendly interface using Entity Framework Core with SQL Server and REST API endpoints via UrlAdaptor.

---

## Alternative Approach: Custom Adaptor

For a client-side data operations approach without REST API endpoints, refer to the [Blazor DataGrid with SQL Server using Entity Framework and Custom Adaptor](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-database/microsoft-sql-server) documentation. This approach executes search, filter, sort, and grouping operations directly in the Blazor component, providing a tightly integrated alternative to the REST API pattern.

---