---
layout: post
title: Blazor Gantt Chart with SQL using Entity Framework | Syncfusion
description: Bind SQL Server data to Blazor Gantt Chart using Entity Framework core with CRUD, filtering and sorting.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Connecting SQL Server to Blazor Gantt Chart via Entity Framework

The Syncfusion Blazor Gantt Chart supports binding data from SQL Server using Entity Framework Core (EF Core) with REST API endpoints via UrlAdaptor. This approach enables clean separation of UI and data layers while supporting full data operations.

**What is Entity Framework Core?**

Entity Framework Core (EF Core) is a data access technology for .NET that simplifies working with databases like SQL Server by mapping C# classes to database tables and generating SQL at runtime.

**Key Benefits of Entity Framework Core**

- Automatic SQL generation with optimized queries
- Strongly typed models for compile-time safety
- Parameterization to mitigate SQL injection
- Migrations to version database schema changes
- LINQ queries for expressive data access

**What is Entity Framework Core SQL Server Provider?**

The Microsoft.EntityFrameworkCore.SqlServer package is the provider that connects Entity Framework core to SQL Server, enabling CRUD and SQL Server-specific features.

**What is UrlAdaptor?**

UrlAdaptor is a DataManager adaptor that communicates with REST API endpoints for all gantt operations. The Gantt Chart sends read, insert, update, delete, and batch requests to controller actions, which use Entity Framework core to access SQL Server.

## Prerequisites

Ensure the following software and packages are installed before proceeding:

| Software/Package | Version | Purpose |
|-----------------|---------|---------|
| Visual Studio 2026 | 18.2.1 or later | Development IDE with Blazor workload |
| .NET SDK | net10.0 or compatible | Runtime and build tools |
| SQL Server | 2021 or later | Database server |
| Syncfusion.Blazor.Gantt | {{site.blazorversion}} | Gantt Chart and UI components |
| Syncfusion.Blazor.Themes | {{site.blazorversion}} | Styling for Gantt Chart components |
| Microsoft.EntityFrameworkCore | 10.0.2 | Core framework for database operations |
| Microsoft.EntityFrameworkCore.SqlServer | 10.0.2 | SQL Server provider for Entity Framework Core |

## Setting Up the SQL Server Environment for Entity Framework Core

### Step 1: Create the Database and Table in SQL Server

First, the SQL Server database structure must be created to store task data.

Instructions:
1. Open SQL Server Management Studio (SSMS) or any SQL Server client.
2. Create a new database named `GanttDB`.
3. Define a `TaskData` table with the specified schema.
4. Insert sample data for testing.

Run the following SQL script:

```sql
-- Create Database
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'GanttDB')
BEGIN
    CREATE DATABASE GanttDB;
END
GO

USE GanttDB;
GO

-- Create TaskData Table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'TaskData')
BEGIN
    CREATE TABLE dbo.TaskData (
        TaskId INT PRIMARY KEY,
        TaskName VARCHAR(50) NOT NULL,
        StartDate DATETIME NULL,
        EndDate DATETIME NULL,
        ParentId INT NULL,
        Duration VARCHAR(50) NOT NULL,
        Predecessor VARCHAR(50) NULL,
        Progress INT NOT NULL
    );
END
GO

-- Insert Sample Data (Optional)
INSERT INTO TaskData (TaskName, StartDate, EndDate, ParentId, Duration, Predecessor, Progress)
VALUES
('Product concept', '2026-04-02', '2026-04-08', NULL, '5', NULL, 0),
('Define the product usage', '2026-04-02', '2026-04-08', 1, '3','1FS', 30),
GO
```

After executing this script, the records are stored in the `TaskData` table within the `GanttDB` database. The database is now ready for integration with the Blazor application.

### Step 2: Install Required NuGet Packages

Before installing the necessary NuGet packages, a new Blazor Web Application must be created using the default template. This template automatically generates essential starter files—such as **Program.cs**, **appsettings.json**, **wwwroot**, and **Components**.

For this guide, a Blazor application named **Gantt_EF_UrlAdaptor** has been created. Once the project is set up, the next step involves installing the required NuGet packages. These packages enable Entity Framework Core with SQL Server provider and add Syncfusion UI components.

**Method 1: Using Package Manager Console**

1. Open Visual Studio 2026.
2. Navigate to Tools → NuGet Package Manager → Package Manager Console.
3. Run the following commands:

```powershell
Install-Package Microsoft.EntityFrameworkCore -Version 10.0.2;
Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 10.0.2;
Install-Package Syncfusion.Blazor.Gantt -Version {{site.blazorversion}};
Install-Package Syncfusion.Blazor.Themes -Version {{site.blazorversion}}
```

**Method 2: Using NuGet Package Manager UI**

1. Open Visual Studio 2026 → Tools → NuGet Package Manager → Manage NuGet Packages for Solution.
2. Search for and install each package individually:
   - **Microsoft.EntityFrameworkCore** (version 10.0.2)
   - **Microsoft.EntityFrameworkCore.SqlServer** (version 10.0.2)
   - **Syncfusion.Blazor.Gantt** (version {{site.blazorversion}})
   - **Syncfusion.Blazor.Themes** (version {{site.blazorversion}})

All required packages are now installed.

### Step 3: Create the Data Model

A data model is a C# class that represents the structure of a database table. This model defines the properties that correspond to the columns in the `TaskData` table.

**Instructions:**

1. Create a new folder named `Data` in the Blazor application project.
2. Inside the `Data` folder, create a new file named **TaskDataModel.cs**.
3. Define the **TaskDataModel** class with the following code:

```csharp
using System.ComponentModel.DataAnnotations.Schema;

namespace Gantt_EF_UrlAdaptor.Data
{
    [Table("TaskData")]
    public class TaskDataModel
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? ParentId { get; set; }
        public int Progress { get; set; }
        public string? Predecessor { get; set; }
        public string Duration { get; set; }
    }
}
```

**Explanation:**
- `[Table("TaskData")]` maps the entity explicitly to the SQL table named `TaskData`.
- Each property represents a column in the table.
- `TaskId` is the identifier used as the primary key in the table script created earlier.

The data model has been successfully created.

### Step 4: Configure the DbContext

A `DbContext` is a special class that manages the connection between the application and the SQL Server database. It handles all database operations such as saving, updating, deleting, and retrieving data.

**Instructions:**

1. Inside the `Data` folder, create a new file named **TaskDbContext.cs**.
2. Define the `TaskDbContext` class with the following code:

```csharp
using Microsoft.EntityFrameworkCore;

namespace Gantt_EF_UrlAdaptor.Data
{
    public class TaskDbContext : DbContext
    {
        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }
        public DbSet<TaskDataModel> Task { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            // Explicitly map DbSet<TaskDataModel> to the [TaskData] table
            modelBuilder.Entity<TaskDataModel>().ToTable("TaskData");
        }
    }
}
```

**Explanation:**
- `TaskDbContext` inherits from `DbContext` and exposes `DbSet<TaskDataModel>` to query and save `TaskData` entities.
- `modelBuilder.Entity<TaskDataModel>().ToTable("TaskData")` ensures Entity Framework core maps the entity to the `TaskData` table.

The DbContext has been successfully configured.

### Step 5: Configure the Connection String

A connection string contains the information needed to connect the application to the SQL Server database, including the server address, database name, and authentication credentials.

**Instructions:**

1. Open the **appsettings.json** file in the project root.
2. Add or verify the `ConnectionStrings` section with the SQL Server connection details:

```json
{
  "ConnectionStrings": {
    "ConnectionString": "Data Source=SQLEXPRESS;Initial Catalog=GanttDB;Connect Timeout=30;Encrypt=False;Integrated Security=True;TrustServerCertificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"
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
| Data Source | The SQL Server instance (e.g., `SQLEXPRESS`) |
| Initial Catalog | The database name (`GanttDB`) |
| Integrated Security | `True` for Windows Authentication |
| Connect Timeout | Connection timeout in seconds |
| Encrypt | Enables encryption for the connection |
| Trust Server Certificate | Whether to trust the server certificate |
| Application Intent | `ReadWrite` for normal operations |
| Multi Subnet Failover | Typically `False` unless using multi-subnet clustering |
| Command Timeout | Command execution timeout in seconds |

The database connection string has been configured successfully.


### Step 6: Create the Gantt API Controller

A controller exposes REST API endpoints for the gantt to read data. This step adds minimal `POST` endpoint that return empty results. Additional CRUD and batch endpoints will be added later when configuring UrlAdaptor.

**Instructions:**

1. Create a new folder named `Controllers` in the project.
2. Inside the `Controllers` folder, create a new file named **GanttController.cs**.
3. Add the following code:

```csharp
using Microsoft.AspNetCore.Mvc;
using Gantt_EF_UrlAdaptor.Data;
using System.Collections.Generic;

namespace Gantt_EF_UrlAdaptor.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GanttController : ControllerBase
    {
        private readonly TaskDbContext _context;

        public GanttController(TaskDbContext context)
        {
            _context = context;
        }

        // POST: api/Gantt (DataManager read)
        [HttpPost]
        public ActionResult<object> Post([FromBody] DataManagerRequest dataManagerRequest)
        {
            return Ok(new { result = new List<TaskDataModel>(), count = 0 });
        }
    }
}
```

The controller has been created with basic endpoint.

### Step 7: Register Services in Program.cs

The `Program.cs` file is where application services are registered and configured. This step enables Entity Framework Core, controllers, Syncfusion Blazor, and maps controller routes.

**Instructions:**

1. Open the **Program.cs** file at the project root.
2. Add the following code after the line `var builder = WebApplication.CreateBuilder(args);`:

```csharp
using Gantt_EF_UrlAdaptor.Components;
using Gantt_EF_UrlAdaptor.Data;
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
builder.Services.AddDbContext<TaskDbContext>(options =>
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
- `AddDbContext<TaskDbContext>()` configures Entity Framework core to use SQL Server with the `ConnectionString` from appsettings.json.
- `MapControllers()` exposes routes like `/api/Gantt`.
- Syncfusion Blazor and Razor components are registered for the UI.

## Integrating Syncfusion Blazor Gantt Chart with UrlAdaptor

### Step 1: Install and Configure Blazor Gantt Chart Components

Syncfusion is a library that provides pre-built UI components like Gantt Chart, which visualizes project schedules, task hierarchies, dependencies, baselines, and progress on a timeline.

**Instructions:**

1. The **Syncfusion.Blazor.Gantt** and **Syncfusion.Blazor.Themes** packages were installed in Step 2 of the previous section.
2. Import the required namespaces in the `Components/_Imports.razor` file:

```csharp
@using Syncfusion.Blazor.Gantt
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

Syncfusion components are now configured and ready to use. For additional guidance, refer to the Gantt component's [getting‑started](https://blazor.syncfusion.com/documentation/gantt-chart/getting-started-with-web-app) documentation.

### Step 2: Update the Blazor Gantt Chart

The `Home.razor` component will display the task data in a Syncfusion Blazor Gantt Chart with search, filter, sort, and CRUD capabilities using UrlAdaptor to communicate with REST API endpoints.

**Instructions:**

1. Open the file named `Home.razor` in the `Components/Pages` folder.
2. Replace the entire content with the following code:

```cshtml

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor

<SfGantt TValue="TaskDataModel" AllowFiltering="true" AllowSorting="true"
        Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" })" Width="100%" Height="600px">
    <SfDataManager Url="/api/Gantt"
                   InsertUrl="/api/Gantt/Insert"
                   UpdateUrl="/api/Gantt/Update"
                   RemoveUrl="/api/Gantt/Delete"
                   BatchUrl="/api/Gantt/BatchUpdate"
                   Adaptor="Adaptors.UrlAdaptor">
    </SfDataManager>    
    <GanttEditSettings AllowAdding="true" AllowEditing="true" AllowTaskbarEditing="true" AllowDeleting="true" />
    <GanttColumns>
        <GanttColumn Field="TaskId" HeaderText="Task ID" Width="90"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Task Name" Width="220"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date" Width="140" Format="d"></GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date" Width="140" Format="d"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration" Width="110"></GanttColumn>
        <GanttColumn Field="Predecessor" HeaderText="Predecessor" Width="140"></GanttColumn>
        <GanttColumn Field="Progress" HeaderText="Progress" Width="110"></GanttColumn>
    </GanttColumns>    
</SfGantt>
```

**Component Explanation:**

- **`<SfGantt>`**: The Gantt Chart component displays hierarchical tasks, dependencies, baselines, durations, and progress on an interactive timeline for scheduling.
- **`<SfDataManager>`**: Manages data communication with REST API endpoints using UrlAdaptor. The `Url` property points to the read endpoint, while `InsertUrl`, `UpdateUrl`, `RemoveUrl`, and `BatchUrl` point to CRUD endpoints.
- **`AllowFiltering="true"`**: Enables column filtering with menu-based filters.
- **`AllowSorting="true"`**: Enables column sorting by clicking headers.
- **`<GanttColumns>`**: Defines the columns displayed in the gantt, mapped to `TaskDataModel` properties.
- **`<GanttEditSettings>`**: Enables adding, deleting and inline editing .
- **`Toolbar`**: "Add", "Edit", "Delete", "Update", "Cancel", "Search" for CRUD and search operations.

> In **URL Adaptor**, the Gantt Chart component handles grouping and aggregation operations automatically.

### Step 3: Implement the Endpoints for UrlAdaptor

The UrlAdaptor communicates with REST API endpoints for Gantt operations rather than executing logic in the component. The Gantt sends requests to endpoints defined in a controller. Below is the controller structure with the same decorators and signatures as in the project, with placeholder comments to add logic.

Open the file named **Controllers/GanttController.cs** and use the following structure:

```csharp
using Gantt_EF_UrlAdaptor.Data;
using Microsoft.AspNetCore.Mvc;
using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;
using System.Text.Json.Serialization;

namespace Gantt_EF_UrlAdaptor.Controllers
{
    [ApiController]
    public class GanttController : ControllerBase
    {
        private readonly TaskDbContext _context;

        public GanttController(TaskDbContext context)
        {
            _context = context; // implement logic here
        }

        /// <summary>
        /// Returns data with search, filter, sort, operations
        /// </summary>
        [HttpPost]
        [Route("api/[controller]")]
        public object Post([FromBody] DataManagerRequest dataManagerRequest)
        {
            // implement logic here
            return new { }; // placeholder
        }

        /// <summary>
        /// Retrieves all task data from the database
        /// </summary>
        [HttpGet]
        [Route("api/[controller]")]
        public List<TaskDataModel> GetTaskData()
        {
            // implement logic here
            return new List<TaskDataModel>();
        }

        /// <summary>
        /// Inserts a new task data
        /// </summary>
        [HttpPost("Insert")]
        [Route("api/[controller]/Insert")]
        public void Insert([FromBody] CRUDModel<TaskDataModel> value)
        {
            // implement logic here
        }

        /// <summary>
        /// Updates an existing task data
        /// </summary>
        [HttpPost("Update")]
        [Route("api/[controller]/Update")]
        public void Update([FromBody] CRUDModel<TaskDataModel> value)
        {
            // implement logic here
        }

        /// <summary>
        /// Deletes an record
        /// </summary>
        [HttpPost("Delete")]
        [Route("api/[controller]/Delete")]
        public void Delete([FromBody] CRUDModel<TaskDataModel> value)
        {
            // implement logic here
        }

        /// <summary>
        /// Batch operations for Insert, Update, and Delete
        /// </summary>
        [HttpPost("Batch")]
        [Route("api/[controller]/BatchUpdate")]
        public void Batch([FromBody] CRUDModel<TaskDataModel> value)
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

### Step 4: Implement Searching Feature

Searching helps to find records by entering keywords in the search box, which filters data across all columns.

**Instructions:**

1. Ensure the toolbar includes the "Search" item.

```cshtml
<SfGantt TValue="TaskDataModel"
        Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" })">
    <SfDataManager Url="/api/Gantt" Adaptor="Adaptors.UrlAdaptor"></SfDataManager>
</SfGantt>
```

2. Update the `Post` action in **Controllers/GanttController.cs** to handle searching:

```csharp
[HttpPost]
[Route("api/[controller]")]
public object Post([FromBody] DataManagerRequest dataManagerRequest)
{
    try
    {
        IEnumerable<TaskDataModel> dataSource = GetTaskData();

        // Handling Searching
        if (dataManagerRequest.Search != null && dataManagerRequest.Search.Count > 0)
        {
            dataSource = DataOperations.PerformSearching(dataSource, dataManagerRequest.Search);
        }

        int totalRecordsCount = dataSource.Count();
        
        if (dataManagerRequest.Skip != 0)
        {
            dataSource = DataOperations.PerformSkip(dataSource, dataManagerRequest.Skip);
        }

        if (dataManagerRequest.Take != 0)
        {
            dataSource = DataOperations.PerformTake(dataSource, dataManagerRequest.Take);
        }

        return dataManagerRequest.RequiresCounts ? new DataResult() { Result = dataSource, Count = totalRecordsCount} : (object)dataSource
    }
    catch (Exception ex)
    {
        return new { error = ex.Message, innerError = ex.InnerException?.Message };
    }
}
```

**How Searching Works:**

- When a text is entered in the search box and presses Enter, the Gantt Chart sends a search request to the REST API.
- The `Post` method receives the search criteria in `dataManagerRequest.Search`.
- The `DataOperations.PerformSearching()` method filters the data based on the search term across all columns.
- Results are returned and displayed in the Gantt Chart.

Searching feature is now active.

---

### Step 5: Implement Filtering Feature

Filtering allows to restrict data based on column values using a menu interface.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Add the [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AllowFiltering) property to the `<SfGantt>` component:

```cshtml
<SfGantt TValue="TaskDataModel"
        AllowFiltering="true"
        Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" })">
    <SfDataManager Url="/api/Gantt" Adaptor="Adaptors.UrlAdaptor"></SfDataManager>
</SfGantt>
```

3. Update the `Post` action in **Controllers/GanttController.cs** to handle filtering:

```csharp
[HttpPost]
[Route("api/[controller]")]
public object Post([FromBody] DataManagerRequest dataManagerRequest)
{
    try
    {
        IEnumerable<TaskDataModel> dataSource = GetTaskData();

        // Handling Searching
        if (dataManagerRequest.Search != null && dataManagerRequest.Search.Count > 0)
        {
            dataSource = DataOperations.PerformSearching(dataSource, dataManagerRequest.Search);
        }

        // Handling Filtering
        if (dataManagerRequest.Where != null && dataManagerRequest.Where.Count > 0)
        {
            dataSource = DataOperations.PerformFiltering(dataSource, dataManagerRequest.Where, dataManagerRequest.Where[0].Operator);
        }

        int totalRecordsCount = dataSource.Count();
        
        if (dataManagerRequest.Skip != 0)
        {
            dataSource = DataOperations.PerformSkip(dataSource, dataManagerRequest.Skip);
        }

        if (dataManagerRequest.Take != 0)
        {
            dataSource = DataOperations.PerformTake(dataSource, dataManagerRequest.Take);
        }

        return dataManagerRequest.RequiresCounts ? new DataResult() { Result = dataSource, Count = totalRecordsCount} : (object)dataSource
    }
    catch (Exception ex)
    {
        return new { error = ex.Message, innerError = ex.InnerException?.Message };
    }
}
```

**How Filtering Works:**

- Click on the filter icon in any column header to open the filter menu.
- Select filtering criteria (equals, contains, greater than, less than, etc.).
- Click the "Filter" button to apply the filter.
- The `Post` method receives the filter criteria in `dataManagerRequest.Where`.
- The `DataOperations.PerformFiltering()` method applies the filter conditions to the data.
- Results are filtered accordingly and displayed in the Gantt Chart.

Filtering feature is now active.

---

### Step 6: Implement Sorting Feature

Sorting enables the records to arrange in ascending or descending order based on column values.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Add the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AllowSorting) property to the `<SfGantt>` component:

```cshtml
<SfGantt TValue="TaskDataModel"
        AllowSorting="true"
        AllowFiltering="true"
        Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" })">
    <SfDataManager Url="/api/Gantt"Adaptor="Adaptors.UrlAdaptor"></SfDataManager>    
</SfGantt>
```

3. Update the `Post` action in **Controllers/GanttController.cs** to handle sorting:

```csharp
[HttpPost]
[Route("api/[controller]")]
public object Post([FromBody] DataManagerRequest dataManagerRequest)
{
    try
    {
        IEnumerable<TaskDataModel> dataSource = GetTaskData();

        // Handling Searching
        if (dataManagerRequest.Search != null && dataManagerRequest.Search.Count > 0)
        {
            dataSource = DataOperations.PerformSearching(dataSource, dataManagerRequest.Search);
        }

        // Handling Filtering
        if (dataManagerRequest.Where != null && dataManagerRequest.Where.Count > 0)
        {
            dataSource = DataOperations.PerformFiltering(dataSource, dataManagerRequest.Where, dataManagerRequest.Where[0].Operator);
        }

        // Handling Sorting
        if (dataManagerRequest.Sorted != null && dataManagerRequest.Sorted.Count > 0)
        {
            dataSource = DataOperations.PerformSorting(dataSource, dataManagerRequest.Sorted);
        }

        int totalRecordsCount = dataSource.Count();
        
        if (dataManagerRequest.Skip != 0)
        {
            dataSource = DataOperations.PerformSkip(dataSource, dataManagerRequest.Skip);
        }

        if (dataManagerRequest.Take != 0)
        {
            dataSource = DataOperations.PerformTake(dataSource, dataManagerRequest.Take);
        }

        return dataManagerRequest.RequiresCounts ? new DataResult() { Result = dataSource, Count = totalRecordsCount} : (object)dataSource
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
- Records are sorted accordingly and displayed in the Gantt Chart.

Sorting feature is now active.

---

### Step 7: Perform CRUD Operations

CRUD operations (Create, Read, Update, Delete) enable the data to manage directly from the Gantt Chart. The REST API endpoints in the controller handle all database operations using Entity Framework Core.

**Instructions:**

1. Update the `<SfGantt>` component in `Home.razor` to include [GanttEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEditSettings.html):

```cshtml
<SfGantt TValue="TaskDataModel" 
        AllowSorting="true"
        AllowFiltering="true"
        Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" })" 
        Width="100%" Height="600px">
    <SfDataManager Url="/api/Gantt"
                   InsertUrl="/api/Gantt/Insert"
                   UpdateUrl="/api/Gantt/Update"
                   RemoveUrl="/api/Gantt/Delete"
                   BatchUrl="/api/Gantt/BatchUpdate"
                   Adaptor="Adaptors.UrlAdaptor">
    </SfDataManager>    
    <GanttEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" AllowTaskbarEditing="true" ></GanttEditSettings>
    <GanttColumns>
        // Add Columns
    </GanttColumns>
</SfGantt>
```

**Insert (Create)**

Record insertion allows new tasks to be added directly through the Gantt Chart component. The `Insert` endpoint processes the insertion request and saves the newly created record to the SQL Server database.

In **Controllers/GanttController.cs**, the insert method is implemented as:

```csharp
/// <summary>
/// Inserts a new task data
/// </summary>
[HttpPost("Insert")]
[Route("api/[controller]/Insert")]
public void Insert([FromBody] CRUDModel<TaskDataModel> value)
{
    try
    {
        _context.TaskData.Add(value.Value);
        _context.SaveChanges();
    }
    catch (Exception ex)
    {
        throw new Exception($"Error inserting task: {ex.Message}");
    }
}
```

**What happens behind the scenes:**

1. Clicks the "Add" button and fills Dialog.
2. The Gantt Chart sends a POST request to `/api/Gantt/Insert`.
3. The `Insert` method receives the new task data in `value.Value`.
4. Entity Framework Core adds the record to the `_context.TaskData` collection.
5. `SaveChanges()` persists the record to the SQL Server database.
6. The Gantt Chart automatically refreshes to display the new record.

**Update (Edit)**

Record modification allows task details to be updated directly within the Gantt Chart. The `Update` endpoint processes the edited row and applies the changes to the SQL Server database.

In **Controllers/GanttController.cs**, the update method is implemented as:

```csharp
/// <summary>
/// Updates an existing task data
/// </summary>
[HttpPost("Update")]
[Route("api/[controller]/Update")]
public void Update([FromBody] CRUDModel<TaskDataModel> value)
{
    try
    {
        var existingTask = _context.TaskData.Find(value.Value.TaskId);
        if (existingTask != null)
        {
            _context.Entry(existingTask).CurrentValues.SetValues(value.Value);
            _context.SaveChanges();
        }
    }
    catch (Exception ex)
    {
        throw new Exception($"Error updating task: {ex.Message}");
    }
}
```

**What happens behind the scenes:**

1. Clicks the "Edit" button and modifies the record.
2. The Gantt Chart sends a POST request to `/api/Gantt/Update`.
3. The `Update` method receives the modified task data in `value.Value`.
4. The existing task is retrieved from the database by its TaskId.
5. The properties are updated with the new values using `SetValues()`.
6. `SaveChanges()` persists the changes to the SQL Server database.
7. The Gantt Chart refreshes to display the updated task.

**Delete (Remove)**

Record deletion allows tasks to be removed directly from the Gantt Chart. The `Delete` endpoint executes the corresponding SQL Server DELETE operation and updates both the database and the gantt.

In **Controllers/GanttController.cs**, the delete method is implemented as:

```csharp
/// <summary>
/// Deletes a task data
/// </summary>
[HttpPost("Delete")]
[Route("api/[controller]/Delete")]
public void Delete([FromBody] CRUDModel<TaskDataModel> value)
{
    try
    {
        int taskId = Convert.ToInt32(value.Key.ToString());
        var task = _context.TaskData.Find(taskId);
        if (task != null)
        {
            _context.TaskData.Remove(task);
            _context.SaveChanges();
        }
    }
    catch (Exception ex)
    {
        throw new Exception($"Error deleting task: {ex.Message}");
    }
}
```

**What happens behind the scenes:**

1. Select a record and click "Delete".
2. A confirmation dialog appears (built into the Gantt Chart).
3. If confirmed, the Gantt Chart sends a POST request to `/api/Gantt/Delete`.
4. The `Delete` method extracts the TaskId from `value.Key`.
5. The task is located in the database by its TaskId.
6. The task is removed from the `_context.TaskData` collection.
7. `SaveChanges()` executes the DELETE statement in SQL Server.
8. The Gantt Chart refreshes to remove the deleted task from the UI.

**Batch Operations (Multiple CRUD in one request)**

Batch operations combine multiple insert, update, and delete actions into a single request, minimizing network overhead and ensuring transactional consistency.

In **Controllers/GanttController.cs**, the batch method is implemented as:

```csharp
/// <summary>
/// Batch operations for Insert, Update, and Delete
/// </summary>
[HttpPost("Batch")]
[Route("api/[controller]/BatchUpdate")]
public void Batch([FromBody] CRUDModel<TaskDataModel> value)
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
            _context.TaskData.AddRange(value.Added);
        }

        if (value.Deleted != null)
        {
            foreach (var record in value.Deleted)
            {
                var existingTask = _context.TaskData.Find(record.TaskId);
                if (existingTask != null)
                {
                    _context.TaskData.Remove(existingTask);
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

- The Gantt Chart collects all added, edited, and deleted records.
- All changes are sent in a single POST request to `/api/Gantt/BatchUpdate`.
- The `Batch` method processes changed records using `UpdateRange()`.
- The `Batch` method processes added records using `AddRange()`.
- The `Batch` method processes deleted records using `Remove()`.
- All operations are saved to the database in a single `SaveChanges()` call for transactional consistency.
- The Gantt Chart refreshes to display all changes.

All CRUD operations are now fully implemented, enabling comprehensive data management capabilities within the Blazor Gantt Chart.

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

The application will start, and the console will display the local URL (`https://localhost:xxxx` where`xxxx`- port shown in the terminal).

**Step 3: Access the Application**

1. Open a web browser.
2. Navigate to the URL displayed in the console.
3. The Gantt Chart application is now running and ready to use.

**Available Features**

- **View Data**: All tasks from the SQL Server database are displayed in the Gantt Chart.
- **Search**: Use the search box to find tasks by any field.
- **Filter**: Click on column headers to apply filters.
- **Sort**: Click on column headers to sort data in ascending or descending order.
- **Add**: Click the "Add" button to create a new task.
- **Edit**: Click the "Edit" button to modify existing task.
- **Delete**: Click the "Delete" button to remove task.

---

## Complete Sample Repository

A complete, working sample implementation is available in the [GitHub repository](https://github.com/SyncfusionExamples/connecting-databases-to-blazor-Gantt-Chart-component/tree/master/Bindind%20SQL%20database%20using%20EF%20and%20UrlAdaptor).

---

## Summary

This guide demonstrates how to:

1. Create a SQL Server database with task records. [🔗](#step-1-create-the-database-and-table-in-sql-server)
2. Install necessary NuGet packages for Entity Framework Core and Syncfusion. [🔗](#step-2-install-required-nuget-packages)
3. Create data models and DbContext for database communication. [🔗](#step-3-create-the-data-model)
4. Configure connection strings and register services in Program.cs. [🔗](#step-5-configure-the-connection-string)
5. Create REST API endpoints in a controller for CRUD operations. [🔗](#step-6-create-the-gantt-api-controller)
6. Implement searching, filtering, and sorting in the REST API. [🔗](#step-5-implement-searching-feature)
7. Perform complete CRUD operations (Create, Read, Update, Delete) via REST API. [🔗](#step-7-perform-crud-operations)
8. Handle batch operations for bulk data modifications. [🔗](#step-8-perform-crud-operations)

The application now provides a complete solution for managing tasks with a modern, user-friendly interface using Entity Framework Core with SQL Server and REST API endpoints via UrlAdaptor.

---

## Alternative Approach: Custom Adaptor

For a client-side data operations approach without REST API endpoints, refer to the [Blazor Gantt Chart with SQL Server using Entity Framework and Custom Adaptor](https://blazor.syncfusion.com/documentation/Gantt Chart/connecting-to-database/microsoft-sql-server) documentation. This approach executes search, filter, sort, and grouping operations directly in the Blazor component, providing a tightly integrated alternative to the REST API pattern.

---