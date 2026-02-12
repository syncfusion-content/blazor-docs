---
layout: post
title: Blazor Gantt Chart Connected to MySQL via EF | Syncfusion
description: Bind MySQL data to Blazor Gantt Chart using Entity Framework Core with complete CRUD, filtering, sorting, and advanced data operations.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Connecting MySQL Server to Blazor Gantt Chart Using Entity Framework

The [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart) supports binding data from a MySQL Server database using Entity Framework Core (EF Core). This modern approach is more maintainable and type-safe alternative to raw SQL queries.

**What is Entity Framework Core?**

Entity Framework Core (EF Core) is an ORM (object-relational mapper) for .NET that maps C# classes to database tables and LINQ queries to SQL.

**Key Benefits of Entity Framework Core**

- **Automatic SQL Generation**: Entity Framework Core generates optimized SQL queries automatically, eliminating the need to write raw SQL code.
- **Type Safety**: Work with strongly-typed objects instead of raw SQL strings, reducing errors.
- **Built-in Security**: Automatic parameterization prevents SQL injection attacks.
- **Version Control for Databases**: Manage database schema changes version-by-version through migrations.
- **Familiar Syntax**: Use LINQ (Language Integrated Query) syntax, which is more intuitive than raw SQL strings.

**What is Pomelo MySQL?**

**Pomelo MySQL** is a software library that helps .NET applications work with a MySQL database using Entity Framework Core. It acts as a bridge between Entity Framework Core and MySQL, allowing applications to read, write, update, and delete data in a MySQL database.

## Prerequisites

Ensure the following software and packages are installed before proceeding:

| Software/Package | Version | Purpose |
|-----------------|---------|---------|
| Visual Studio 2026 | 18.2.1 or later | Development IDE with Blazor workload |
| .NET SDK | net10.0 or compatible | Runtime and build tools |
| MySQL Server | 8.0.41 or later | Database server |
| Syncfusion.Blazor.Gantt | {{site.blazorversion}} | Gantt Chart and UI components |
| Syncfusion.Blazor.Themes | {{site.blazorversion}} | Styling for Gantt Chart components |
| Microsoft.EntityFrameworkCore | 10.0.2 or later | Core framework for database operations |
| Microsoft.EntityFrameworkCore.Tools |10.0.2 or later | Tools for managing database migrations |
| Pomelo.EntityFrameworkCore.MySql | 10.0.2 or later | MySQL provider for Entity Framework Core |

## Setting up the MySQL environment for Entity Framework Core

### Step 1: Create the database and table in MySQL server

First, the **MySQL database** structure must be created to store task data.

**Instructions:**
1. Open MySQL Workbench or any MySQL client.
2. Create a new database named `ganttdb`.
3. Define a `task_data` table with the specified schema.
4. Insert sample data for testing.

Run the following SQL script:

```sql
-- Create Database
CREATE DATABASE IF NOT EXISTS ganttdb;
USE ganttdb;

-- Create TaskData Table
CREATE TABLE IF NOT EXISTS task_data (
    TaskID INT AUTO_INCREMENT PRIMARY KEY,
    TaskName VARCHAR(50) NOT NULL, 
    StartDate DATETIME,
    EndDate DATETIME,
    ParentID INT NULL,
    Duration VARCHAR(10) NOT NULL,
    Predecessor VARCHAR(100) NULL,   
    Progress INT NOT NULL  
);

-- Insert Sample Data (Optional)

INSERT INTO task_data (TaskName, StartDate, EndDate, ParentID, Duration, Predecessor, Progress)
VALUES
('Product concept', '2026-04-02', '2026-04-08', NULL, '5', NULL, 0),
('Define the product usage', '2026-04-02', '2026-04-08', 1, '3','1FS', 30),
```

After executing this script, the task records are stored in the `task_data` table within the `ganttdb` database. The database is now ready for integration with the Blazor application.

---

### Step 2: Install required NuGet packages

Before installing the necessary NuGet packages, a new Blazor Web Application must be created using the default template.
This template automatically generates essential starter files—such as **Program.cs, appsettings.json, the wwwroot folder, and the Components folder**.

For this guide, a Blazor application named **GanttMySql** has been created. Once the project is set up, the next step involves installing the required NuGet packages. NuGet packages are software libraries that add functionality to the application. These packages enable Entity Framework Core and MySQL integration.

**Method 1: Using Package Manager Console**

1. Open Visual Studio 2026.
2. Navigate to **Tools → NuGet Package Manager → Package Manager Console**.
3. Run the following commands:

```powershell
Install-Package Microsoft.EntityFrameworkCore -Version 10.0.2
Install-Package Microsoft.EntityFrameworkCore.Tools -Version 10.0.2
Install-Package Pomelo.EntityFrameworkCore.MySql -Version 10.0.2
Install-Package Syncfusion.Blazor.Gantt -Version {{site.blazorversion}}
Install-Package Syncfusion.Blazor.Themes -Version {{site.blazorversion}}
```

**Method 2: Using NuGet Package Manager UI**

1. Open **Visual Studio 2026 → Tools → NuGet Package Manager → Manage NuGet Packages for Solution**.
2. Search for and install each package individually:
   - **Microsoft.EntityFrameworkCore** (version 10.0.2 or later)
   - **Microsoft.EntityFrameworkCore.Tools** (version 10.0.2 or later)
   - **Pomelo.EntityFrameworkCore.MySql** (version 10.0.2 or later)
   - **Syncfusion.Blazor.Gantt** (version {{site.blazorversion}})
   - **Syncfusion.Blazor.Themes** (version {{site.blazorversion}})

All required packages are now installed.

### Step 3: Create the Data Model

A data model is a C# class that represents the structure of a database table. This model defines the properties that correspond to the columns in the `task_data` table.

**Instructions:**

1. Create a new folder named `Data` in the Blazor application project.
2. Inside the `Data` folder, create a new file named **TaskDataModel.cs**.
3. Define the **TaskDataModel** class with the following code:

```csharp
namespace GanttMySql.Data
{
    public class TaskDataModel
    {
        [Key]
        public int TaskID { get; set; }
        public string? TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? ParentID { get; set; }
        public string Predecessor { get; set; }
        public string? Duration { get; set; }    
        public int Progress { get; set; }
    }
}

```

**Explanation:**
- The `[Key]` attribute marks the `TaskID` property as the primary key (a unique identifier for each record).
- Each property represents a column in the database table.
- The `?` symbol indicates that a property is nullable (can be empty).

The data model has been successfully created.

### Step 4: Configure the DbContext

A `DbContext` is a special class that manages the connection between the application and the MySQL database. It handles all database operations such as saving, updating, deleting, and retrieving data.

**Instructions:**

1. Inside the `Data` folder, create a new file named **TaskDbContext.cs**.
2. Define the `TaskDbContext` class with the following code:

```csharp
using Microsoft.EntityFrameworkCore;

namespace GanttMySql.Data
{
    /// <summary>
    /// DbContext for task_data table.
    /// Manages DB connection and entity configuration for TaskDataModel.
    /// </summary>
    public class TaskDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of <see cref="TaskDbContext"/>.
        /// </summary>
        /// <param name="options">The options for this context.</param>
        public TaskDbContext(DbContextOptions<TaskDbContext> options)
            : base(options)
        {
        }

         /// <summary>
        /// Gets the <see cref="DbSet{TaskDataModel}"/> representing the task_data table.
        /// </summary>
        public DbSet<TaskDataModel> TaskData => Set<TaskDataModel>();

        /// <summary>
        /// Configures entity mappings and constraints.
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<TaskDataModel>(entity =>
            {
                // Table name
                entity.ToTable("task_data");

                // Primary Key
                entity.HasKey(e => e.TaskID);

                // Auto-increment for Primary Key
                entity.Property(e => e.TaskID)
                      .ValueGeneratedOnAdd();

                // TaskName (NOT NULL, VARCHAR(50))
                entity.Property(e => e.TaskName)
                      .HasMaxLength(50)
                      .IsRequired();

                // StartDate (DATETIME, nullable)
                entity.Property(e => e.StartDate)
                      .HasColumnType("datetime")
                      .IsRequired(false);

                // EndDate (DATETIME, nullable)
                entity.Property(e => e.EndDate)
                      .HasColumnType("datetime")
                      .IsRequired(false);

                // ParentID (INT, nullable)
                entity.Property(e => e.ParentID)
                      .IsRequired(false);

                // Predecessor (VARCHAR(100), nullable)
                entity.Property(e => e.Predecessor)
                      .HasMaxLength(100)
                      .IsRequired(false);

                // Duration (NOT NULL, VARCHAR(10))
                entity.Property(e => e.Duration)
                      .HasMaxLength(10)
                      .IsRequired();

                // Progress (NOT NULL, INT)
                entity.Property(e => e.Progress)
                      .HasColumnType("int")
                      .IsRequired();

                // Helpful indexes
                entity.HasIndex(e => e.ParentID).HasDatabaseName("IX_Task_ParentID");
                entity.HasIndex(e => e.StartDate).HasDatabaseName("IX_Task_StartDate");
            });
        }
    }
}
```

**Explanation:**
- The `DbContext` class inherits from Entity Framework's `DbContext` base class.
- The `TaskData` property represents the `task_data` table in the database.
- The `OnModelCreating` method configures how the database columns should behave (maximum length, required/optional, default values, etc.).

The **TaskDbContext** class is required because:

- It **connects** the application to the database.
- It **manages** all database operations.
- It **maps** C# models to actual database tables.
- It **configures** how data should look inside the database.

Without this class, Entity Framework Core will not know where to save data or how to create the task_data table. The DbContext has been successfully configured.

### Step 5: Configure the connection string

A connection string contains the information needed to connect the application to the MySQL database, including the server address, port, database name, and credentials.

**Instructions:**

1. Open the `appsettings.json` file in the project root.
2. Add or update the `ConnectionStrings` section with the MySQL connection details:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=ganttdb;Uid=root;Pwd=<pwd>;SslMode=None;ConvertZeroDateTime=false;"
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
| Server | The address of the MySQL server (use `localhost` for local development) |
| Port | The MySQL port number (default is `3306`) |
| Database | The database name (in this case, `ganttdb`) |
| Uid | The MySQL username (default is `root`) |
| Pwd | The MySQL password |
| SslMode | SSL encryption mode (set to `None` for local development) |
| ConvertZeroDateTime | Converts zero datetime values to NULL |

The database connection string has been configured successfully.

### Step 6: Create the repository class

A repository class is an intermediary layer that handles all database operations. This class uses Entity Framework Core to communicate with the database.

**Instructions:**

1. Inside the `Data` folder, create a new file named **TaskRepository.cs**.
2. Define the **TaskRepository** class with the following code:

```csharp
using Microsoft.EntityFrameworkCore;

namespace GanttMySql.Data
{
    /// <summary>
    /// Repository implementation for TaskDataModel using EF Core.
    /// Handles CRUD operations and simple task business rules.
    /// </summary>
    public class TaskRepository
    {
        private readonly TaskDbContext _context;
    
        /// <summary>
        /// Initializes a new instance of <see cref="TaskRepository"/>.
        /// </summary>
        /// <param name="context">The <see cref="TaskDbContext"/> used to access the database.</param>
        public TaskRepository(TaskDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all tasks ordered for hierarchical display.
        /// </summary>
        /// <returns>A list of <see cref="TaskDataModel"/> instances.</returns>
        public async Task<List<TaskDataModel>> GetTasksAsync()
        {
            return await _context.TaskData
                .OrderByDescending(t => t.TaskID)
                .ToListAsync();
        }

        /// <summary>
        /// Adds a new task to the database with defaults and validation.
        /// </summary>
        /// <param name="task">The task to add.</param>
        public async Task AddTaskAsync(TaskDataModel task)
        {
            // Handle logic to add a new task to the database
        }

        /// <summary>
        /// Updates an existing task in the database.
        /// </summary>
        /// <param name="task">Updated task data (TaskID must identify an existing task).</param>
        public async Task UpdateTaskAsync(TaskDataModel task)
        {
            // Handle logic to update an existing task to the database
        }

        /// <summary>
        /// Deletes a task by TaskID.
        /// </summary>
        /// <param name="key">Task identifier to remove; null or invalid values are ignored.</param>
        public async Task RemoveTaskAsync(int? key)
        {
            // Handle logic to delete an existing task to the database
        }
    }
}
```

The repository class has been created.

### Step 7: Register services in Program.cs

The `Program.cs` file is where application services are registered and configured. This file must be updated to enable Entity Framework Core and the repository pattern.

**Instructions:**

1. Open the `Program.cs` file at the project root.
2. Add the following code after the line `var builder = WebApplication.CreateBuilder(args);`:

```csharp
using Microsoft.EntityFrameworkCore;
using GanttMySql.Data;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Get connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register DbContext with MySQL database
builder.Services.AddDbContext<TaskDbContext>(options =>
{
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    );
});

// Register the repository for dependency injection
builder.Services.AddScoped<TaskRepository>();

// Register Syncfusion Blazor services
builder.Services.AddSyncfusionBlazor();

// Add other services as needed
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
```

The service registration has been completed successfully.

---

## Integrating Syncfusion Blazor Gantt Chart

### Step 1: Install and configure Blazor Gantt Chart Components

Syncfusion is a library that provides pre-built UI components like Gantt Chart, which visualizes project schedules, task hierarchies, dependencies, baselines, and progress on a timeline.

**Instructions:**

1. The Syncfusion.Blazor.Gantt package was installed in **Step 2** of the previous heading.
2. Import the required namespaces in the `Components/_Imports.razor` file:

```csharp
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Data
```

3. Add the Syncfusion stylesheet and scripts in the `Components/App.razor` file. Find the `<head>` section and add:

```html
<!-- Syncfusion Blazor Stylesheet -->
<link href="_content/Syncfusion.Blazor.Themes/tailwind3.css" rel="stylesheet" />

<!-- Syncfusion Blazor Scripts -->
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
```

For this project, the tailwind3 theme is used. A different theme can be selected or the existing theme can be customized based on project requirements. Refer to the [Syncfusion Blazor Components Appearance](https://blazor.syncfusion.com/documentation/appearance/themes) documentation to learn more about theming and customization options.

Syncfusion components are now configured and ready to use. For additional guidance, refer to the Gantt component’s [getting‑started](https://blazor.syncfusion.com/documentation/gantt-chart/getting-started-with-web-app) documentation.

### Step 2: Update the Blazor Gantt Chart

The `Home.razor` component will display the task data in a Syncfusion Blazor Gantt Chart with search, filter and sorting capabilities.

**Instructions:**

1. Open the file named `Home.razor` in the `Components/Pages` folder.
2. Add the following code to create a basic Gantt Chart:

```cshtml

@using System.Collections
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Gantt
@using GanttMySql.Data

@inject TaskRepository TaskService

<SfGantt TValue="TaskDataModel" Height="500px" Width="100%" AllowSorting="true" AllowFiltering="true" EnableContextMenu="true" 
         Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" })">

    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>

    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Progress="Progress" Duration="Duration" ParentID="ParentID" Dependency="Predecessor">
    </GanttTaskFields>

    <GanttEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" AllowTaskbarEditing="true" Mode="Syncfusion.Blazor.Gantt.EditMode.Auto"></GanttEditSettings>

    <GanttColumns>
        <GanttColumn Field=@nameof(TaskDataModel.TaskID) HeaderText="Task ID" IsPrimaryKey="true" Width="150" />
        <GanttColumn Field=@nameof(TaskDataModel.TaskName) HeaderText="Task Name" Width="220" />
        <GanttColumn Field=@nameof(TaskDataModel.StartDate) HeaderText="Start Date" Width="170" />
        <GanttColumn Field=@nameof(TaskDataModel.EndDate) HeaderText="End Date" Width="170" />
        <GanttColumn Field=@nameof(TaskDataModel.Duration) HeaderText="Duration" Width="130" />
        <GanttColumn Field=@nameof(TaskDataModel.Predecessor) HeaderText="Predecessor" Width="130" />
        <GanttColumn Field=@nameof(TaskDataModel.Progress) HeaderText="Progress" Width="120" />
    </GanttColumns>

</SfGantt>

@code {
    // CustomAdaptor class will be added in the next step
}
```

**Component Explanation:**

- **`@rendermode InteractiveServer`**: Enables interactive server-side rendering for the component.
- **`@inject TaskRepository`**: Injects the repository to access database methods.
- **`<SfGantt>`**: The Gantt Chart component displays hierarchical tasks, dependencies, baselines, durations, and progress on an interactive timeline for scheduling.
- **`<GanttColumns>`**: Defines individual columns in the Gantt Chart.
- **`<GanttEditSettings>`**: Configures Edit settings in Gantt Chart.

The Home component has been updated successfully with Gantt Chart.

---

### Step 3: Implement the custom adaptor

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Gantt Chart can bind data from a **MySQL Server** database using [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) and set the [Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Adaptors.html) property to `CustomAdaptor` for scenarios that require full control over data operations.

The `CustomAdaptor` is a bridge between the Gantt Chart and the database. It handles all data operations including reading, searching, filtering, sorting, and CRUD operations. Each operation in the CustomAdaptor's `ReadAsync` method handles specific Gantt Chart functionality. The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Gantt Chart sends operation details to the API through a [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html) object. These details can be applied to the data source using methods from the [DataOperations](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html) class.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Add the following `CustomAdaptor` class code inside the `@code` block:

```csharp
@code {

    private static TaskRepository? _taskService { get; set; }

    /// <summary>
    /// CustomAdaptor class bridges Gantt Chart interactions with database operations.
    /// This adaptor handles all data retrieval and manipulation for the Gantt Chart.
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        public TaskRepository? TaskService
        {
            get => _taskService;
            set => _taskService = value;
        }

        /// <summary>
        /// ReadAsync retrieves records from the database and applies data operations.
        /// This method executes when the Gantt Chart initializes and when filtering, searching, sorting occurs.
        /// </summary>
        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
        {
            try
            {
                // Fetch all tasks from the database
                IEnumerable<TaskDataModel> dataSource = await _taskService!.GetTasksAsync();

                // Apply search operation if search criteria exists
                if (dataManagerRequest.Search != null && dataManagerRequest.Search.Count > 0)
                {
                    dataSource = DataOperations.PerformSearching(dataSource, dataManagerRequest.Search);
                }

                // Apply filter operation if filter criteria exists
                if (dataManagerRequest.Where != null && dataManagerRequest.Where.Count > 0)
                {
                    dataSource = DataOperations.PerformFiltering(dataSource, dataManagerRequest.Where, dataManagerRequest.Where[0].Operator);
                }

                // Apply sort operation if sort criteria exists
                if (dataManagerRequest.Sorted != null && dataManagerRequest.Sorted.Count > 0)
                {
                    dataSource = DataOperations.PerformSorting(dataSource, dataManagerRequest.Sorted);
                }

                int totalRecordsCount = dataSource.Cast<TaskDataModel>().Count();

                // Apply skip operation
                if (dataManagerRequest.Skip != 0)
                {
                    dataSource = DataOperations.PerformSkip(dataSource, dataManagerRequest.Skip);
                }

                // Apply take operation to retrieve only the requested page size
                if (dataManagerRequest.Take != 0)
                {
                    dataSource = DataOperations.PerformTake(dataSource, dataManagerRequest.Take);
                }

                // Return the result with total count for pagination metadata
                return dataManagerRequest.RequiresCounts
                    ? new DataResult() { Result = dataSource, Count = totalRecordsCount }
                    : (object)dataSource;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving data: {ex.Message}");
            }
        }
    }
}
```

The `CustomAdaptor` class has been successfully implemented with all data operations.

**Common methods in data operations**

* [ReadAsync(DataManagerRequest)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_ReadAsync_Syncfusion_Blazor_DataManagerRequest_System_String_) - Retrieve and process records (search, filter, sort)

* [PerformSearching](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSearching__1_System_Linq_IQueryable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_SearchFilter__) - Applies search criteria to the collection.
* [PerformFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformFiltering__1_System_Linq_IQueryable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_WhereFilter__System_String_) - Filters data based on conditions.
* [PerformSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSorting__1_System_Linq_IQueryable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_Sort__) - Sorts data by one or more fields.
* [PerformSkip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSkip__1_System_Linq_IQueryable___0__System_Int32_) - Skips a defined number of records.
* [PerformTake](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformTake__1_System_Linq_IQueryable___0__System_Int32_) - Retrieves a specified number of records.

---

### Step 4: Add toolbar with CRUD and search options

The toolbar provides buttons for adding, editing, deleting records, and searching the data.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Update the `<SfGantt>` component to include the [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_Toolbar) property with CRUD and search options:

```cshtml
<SfGantt TValue="TaskDataModel"
        AllowSorting="true" 
        AllowFiltering="true" 
        Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GanttColumns>
        <!-- Gantt columns configuration -->
    </GanttColumns>
</SfGantt>
```

3. Add the toolbar items list in the `@code` block:

```csharp
@code {
    private List<string> ToolbarItems = new List<string> { "Add", "Edit", "Delete", "Update", "Cancel", "Search"};

    // CustomAdaptor class code...
}
```

**Toolbar Items Explanation:**

| Item | Function |
|------|----------|
| `Add` | Opens the Dialog tab to add a new task record. |
| `Edit` | Enables editing of the selected record. |
| `Delete` | Deletes the selected record from the database. |
| `Update` | Saves changes made to the selected record. |
| `Cancel` | Cancels the current edit or add operation. |
| `Search` | Displays a search box to find records. |

The toolbar has been successfully added.

---


### Step 5: Implement searching feature

Searching allows the user to find records by entering keywords in the search box.

**Instructions:**

1. The search functionality is already enabled in the CustomAdaptor's `ReadAsync` method.
2. Ensure the toolbar includes the "Search" item.
3. No additional code changes are required.

```cshtml
<SfGantt TValue="TaskDataModel"
        Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <!-- Gantt columns configuration -->
</SfGantt>
```
4. Update the `ReadAsync` method in the `CustomAdaptor` class to handle searching:

```csharp
@code {
    private List<string> ToolbarItems = new List<string> { "Search"};
    
    /// <summary>
    /// CustomAdaptor class to handle Gantt Chart data operations with MySQL using Entity Framework
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        private static TaskRepository? _taskService { get; set; }

        /// <summary>
        /// Task repository instance used to fulfill data operations.
        /// </summary>
        public TaskRepository? TaskService
        {
            get => _taskService;
            set => _taskService = value;
        }
        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
        {
            IEnumerable<TaskDataModel> dataSource = await _taskService!.GetTasksAsync();

            // Handling Search
            if (dataManagerRequest.Search != null && dataManagerRequest.Search.Count > 0)
            {
                dataSource = DataOperations.PerformSearching(dataSource, dataManagerRequest.Search);
            }

            int totalRecordsCount = dataSource.Cast<TaskDataModel>().Count();
            
            return dataManagerRequest.RequiresCounts 
                ? new DataResult() { Result = dataSource, Count = totalRecordsCount } 
                : (object)dataSource;
        }
    }
}
```

**How Searching Works:**

- When the user enters text in the search box and presses Enter, the Gantt Chart sends a search request to the CustomAdaptor.
- The `ReadAsync` method receives the search criteria in `dataManagerRequest.Search`.
- The `DataOperations.PerformSearching()` method filters the data based on the search term.
- Results are returned and displayed in the Gantt Chart.

Searching feature is now active.

---

### Step 6: Implement filtering feature

Filtering allows the user to restrict data based on column values using a menu interface.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Add the [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AllowFiltering) property to the `<SfGantt>` component:

```cshtml
<SfGantt TValue="TaskDataModel"       
        AllowFiltering="true"
        Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>    
    <!-- Gantt columns configuration -->
</SfGantt>

```

3. Update the `ReadAsync` method in the `CustomAdaptor` class to handle filtering:

```csharp
@code {
    private List<string> ToolbarItems = new List<string> { "Search"};
    /// <summary>
    /// CustomAdaptor class to handle Gantt Chart data operations with MySQL using Entity Framework
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        private static TaskRepository? _taskService { get; set; }

        /// <summary>
        /// Task repository instance used to fulfill data operations.
        /// </summary>
        public TaskRepository? TaskService
        {
            get => _taskService;
            set => _taskService = value;
        }    

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key =   null)
        {
            IEnumerable<TaskDataModel> dataSource = await _taskService!.GetTasksAsync();

            // Handling Search
            if (dataManagerRequest.Search != null && dataManagerRequest.Search.Count > 0)
            {
                dataSource = DataOperations.PerformSearching(dataSource, dataManagerRequest.Search);
            }

            // Handling Filtering
            if (dataManagerRequest.Where != null && dataManagerRequest.Where.Count > 0)
            {
                dataSource = DataOperations.PerformFiltering(dataSource, dataManagerRequest.Where,  dataManagerRequest.Where[0].Operator);
            }

            int totalRecordsCount = dataSource.Cast<TaskDataModel>().Count();            

            return dataManagerRequest.RequiresCounts 
                ? new DataResult() { Result = dataSource, Count = totalRecordsCount } 
                : (object)dataSource;
        }
    }
}
```

**How Filtering Works:**

- Click on the filter icon in any column header to open the filter menu.
- Select filtering criteria (equals, contains, greater than, less than, etc.).
- Click the "Filter" button to apply the filter.
- The `ReadAsync` method receives the filter criteria in `dataManagerRequest.Where`.
- Results are filtered accordingly and displayed in the Gantt Chart.

Filtering feature is now active.

---

### Step 7: Implement sorting feature

Sorting enables the user to arrange records in ascending or descending order based on column values.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Add the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AllowSorting) property to the `<SfGantt>` component:

```cshtml
<SfGantt TValue="TaskDataModel"
        AllowSorting="true" 
        AllowFiltering="true" 
        Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <!-- Gantt columns configuration -->
</SfGantt>
```

3. Update the `ReadAsync` method in the `CustomAdaptor` class to handle sorting:

```csharp
@code {
    private List<string> ToolbarItems = new List<string> { "Search"};
    /// <summary>
    /// CustomAdaptor class to handle Gantt Chart data operations with MySQL using Entity Framework
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        private static TaskRepository? _taskService { get; set; }

        /// <summary>
        /// Task repository instance used to fulfill data operations.
        /// </summary>
        public TaskRepository? TaskService
        {
            get => _taskService;
            set => _taskService = value;
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key =   null)
        {
            IEnumerable<TaskDataModel> dataSource = await _taskService!.GetTasksAsync();

            // Handling Search
            if (dataManagerRequest.Search != null && dataManagerRequest.Search.Count > 0)
            {
                dataSource = DataOperations.PerformSearching(dataSource, dataManagerRequest.Search);
            }

            // Handling Filtering
            if (dataManagerRequest.Where != null && dataManagerRequest.Where.Count > 0)
            {
                dataSource = DataOperations.PerformFiltering(dataSource, dataManagerRequest.Where,  dataManagerRequest.Where[0].Operator);
            }

             // Handling Sorting
            if (dataManagerRequest.Sorted != null && dataManagerRequest.Sorted.Count > 0)
            {
                dataSource = DataOperations.PerformSorting(dataSource, dataManagerRequest.Sorted);
            }

            int totalRecordsCount = dataSource.Cast<TaskDataModel>().Count();            

            return dataManagerRequest.RequiresCounts 
                ? new DataResult() { Result = dataSource, Count = totalRecordsCount } 
                : (object)dataSource;
        }
    }
}
```

**How Sorting Works:**

- Click on the column header to sort in ascending order.
- Click again to sort in descending order.
- The `ReadAsync` method receives the sort criteria in `dataManagerRequest.Sorted`.
- Records are sorted accordingly and displayed in the Gantt Chart.

Sorting feature is now active.

---

### Step 8: Perform CRUD operations

CustomAdaptor methods enable users to create, read, update, and delete records directly from the Gantt Chart. Each operation calls corresponding data layer methods in **TaskRepository.cs** to execute MySQL commands.

Add the Gantt **EditSettings** and **Toolbar** configuration to enable create, read, update, and delete (CRUD) operations.

```cshtml
<SfGantt TValue="TaskDataModel"
        AllowSorting="true" 
        AllowFiltering="true"
        Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>     
     <GanttEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" AllowTaskbarEditing="true"></GanttEditSettings>
    <!-- Gantt columns  -->
</SfGantt>
```
Add the toolbar items list in the `@code` block:

```csharp
@code {
    private List<string> ToolbarItems = new List<string> { "Add", "Edit", "Delete", "Update", "Cancel", "Search"};

    // CustomAdaptor class code...
}
```
**Insert**

Record insertion allows new tasks to be added directly through the Gantt Chart component. The adaptor processes the insertion request, performs any required business‑logic validation, and saves the newly created record to the MySQL Server database.

In **Home.razor**, implement the `InsertAsync` method to handle record insertion within the `CustomAdaptor` class:

```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> InsertAsync(DataManager dataManager, object value, string? key)
    {
        if (value is TaskDataModel task)
        {
            await _taskService!.AddTaskAsync(task);
        }
        return value;
    }
}
```
In **Data/TaskRepository.cs**, implement the insert method:

```csharp
public async Task AddTaskAsync(TaskData value)
{
     if (task == null)
     throw new ArgumentNullException(nameof(task), "Task cannot be null");

    // Ensure DB generates identity
    task.TaskID = 0;
    
    ApplyDefaults(task);
    
    _context.TaskData.Add(task);
    await _context.SaveChangesAsync();
}

/// <summary>
/// Applies default values and enforces simple business rules on a task instance.
/// </summary>
/// <param name="task">Task instance to modify in-place.</param>
private static void ApplyDefaults(TaskDataModel task)
{
    task.TaskName = string.IsNullOrWhiteSpace(task.TaskName) ? "New Task" : task.TaskName.Trim();
    task.StartDate ??= DateTime.Now;

    if (string.IsNullOrWhiteSpace(task.Duration))
        task.Duration = "1 day"; // or "1d"

    // Clamp progress 0..100
    if (task.Progress < 0) task.Progress = 0;
    if (task.Progress > 100) task.Progress = 100;

    if (task.EndDate != null && task.StartDate != null && task.EndDate < task.StartDate)
        task.EndDate = task.StartDate.Value.AddDays(1);
}
```

**Helper methods explanation:**
- `ApplyDefaults()`: Applies default values and enforces simple business rules on a task instance.

**What happens behind the scenes:**

1. The task data is collected and validated in the CustomAdaptor's `InsertAsync()` method.
2. The `TaskRepository.AddTaskAsync()` method is called.
3. The new record is added to the `_context.TaskData` collection.
4. `SaveChangesAsync()` persists the record to the MySQL database.
5. The Gantt Chart automatically refreshes to display the new record.

Now the new task is persisted to the database and reflected in the Gantt Chart.

**Update**

Record modification allows task details to be updated directly within the Gantt Chart. The adaptor processes the edited row, validates the updated values, and applies the changes to the **MySQL Server database** while ensuring data integrity is preserved.

In **Home.razor**, implement the `UpdateAsync` method to handle record updates within the `CustomAdaptor` class:


```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> UpdateAsync(DataManager dataManager, object value, string? keyField, string key)
    {
        if (value is TaskDataModel task)
        {
            await _taskService!.UpdateTaskAsync(task);
        }
        return value;
    }
}
```
In **Data/TaskRepository.cs**, implement the update method:

```csharp
/// <summary>
/// Updates an existing task in the database.
/// </summary>
/// <param name="task">Updated task data (TaskID must identify an existing task).</param>
public async Task UpdateTaskAsync(TaskDataModel task)
{
    if (task == null)
        throw new ArgumentNullException(nameof(task), "Task cannot be null");

    var existing = await _context.TaskData.FindAsync(task.TaskID);
    if (existing == null)
        throw new KeyNotFoundException($"Task with ID {task.TaskID} not found in the database.");

    ApplyDefaults(task);

    existing.TaskName = task.TaskName;
    existing.StartDate = task.StartDate;
    existing.EndDate = task.EndDate;
    existing.Duration = task.Duration;
    existing.Progress = task.Progress;
    existing.Predecessor = task.Predecessor;
    existing.ParentID = task.ParentID;

    await _context.SaveChangesAsync();
}
```

**What happens behind the scenes:**

1. The modified data is collected from the Dialog.
2. The CustomAdaptor's `UpdateAsync()` method is called.
3. The `TaskRepository.UpdateTaskAsync()` method is called.
4. The existing record is retrieved from the database by ID.
5. All properties are updated with the new values (except ID and CreatedAt).
6. `SaveChangesAsync()` persists the changes to the MySQL database.
7. The Gantt Chart refreshes to display the updated record.

Now modifications are synchronized to the database and reflected in the Gantt Chart UI.

**Delete**

Record deletion allows task to be removed directly from the Gantt Chart. The adaptor captures the delete request, executes the corresponding **MySQL DELETE** operation, and updates both the database and the Gantt Chart to reflect the removal.

In **Home.razor**, implement the `RemoveAsync` method to handle record deletion within the `CustomAdaptor` class:

```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> RemoveAsync(DataManager dm, object value, string? keyField, string key)
    {
        int? taskID = value switch
        {
            int i => i,
            long l => (int)l,
            string s when int.TryParse(s, out var id) => id,
            TaskDataModel t => t.TaskID,
            _ => null
        };

        await _taskService!.RemoveTaskAsync(taskID);
        return value;
    }
}
```
In **Data/TaskRepository.cs**, implement the delete method:

```csharp
/// <summary>
/// Deletes a task by TaskID.
/// </summary>
/// <param name="key">Task identifier to remove; null or invalid values are ignored.</param>
public async Task RemoveTaskAsync(int? key)
{
    if (key == null || key <= 0)
        return; // don’t throw for invalid key in UI flows

    try
    {
        var task = await _context.TaskData.FindAsync(key.Value);
       
        if (task == null)
            return;

        _context.TaskData.Remove(task);
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateException ex)
    {
        Console.WriteLine($"Database error while deleting task: {ex.Message}");
        throw;
    }
}
```
**What happens behind the scenes:**

1. The user selects a record and clicks "Delete".
2. A confirmation dialog appears (built into the Gantt Chart).
3. If confirmed, the CustomAdaptor's `RemoveAsync()` method is called.
4. The `TaskRepository.RemoveTaskAsync()` method is called.
5. The record is located in the database by its ID.
6. The record is removed from the `_context.TaskData` collection.
7. `SaveChangesAsync()` executes the DELETE statement in MySQL.
8. The Gantt Chart refreshes to remove the deleted record from the UI.

Now tasks are removed from the database and the Gantt Chart UI reflects the changes immediately.

**Batch update**

Batch operations combine multiple insert, update, and delete actions into a single request, minimizing network overhead and ensuring task consistency by applying all changes atomically to the MySQL Server database.

In **Home.razor**, implement the `BatchUpdateAsync` method to handle multiple record updates in a single request within the `CustomAdaptor` class:

```csharp
    /// <summary>
    /// Applies batch changes: updates, inserts, and deletes using the repository.
    /// </summary>
    /// <param name="dm">The DataManager instance (framework-provided).</param>
    /// <param name="changedRecords">Records that were modified.</param>
    /// <param name="addedRecords">Records that were added.</param>
    /// <param name="deletedRecords">Records that were deleted.</param>
    /// <param name="keyField">Optional key field name.</param>
    /// <param name="key">Key value used by the batch operation.</param>
    /// <param name="dropIndex">Optional drop index for drag-and-drop operations.</param>
    /// <returns>A task that yields the batch operation key or result.</returns>
    public override async Task<object> BatchUpdateAsync(DataManager dm, object changedRecords, object addedRecords, object deletedRecords,string? keyField, string key, int? dropIndex)
    {
        if (changedRecords is IEnumerable<TaskDataModel> changed)
        {
            foreach (var record in changed)
            {
                // Debug (optional)
                Console.WriteLine($"UPDATE TaskID={record.TaskID}, ParentID={record.ParentID}");
                await _taskService!.UpdateTaskAsync(record);
            }
        }

    if (addedRecords is IEnumerable<TaskDataModel> added)
    {
        foreach (var record in added)
        {
            // Debug (optional)
            Console.WriteLine($"INSERT TaskID={record.TaskID}, ParentID={record.ParentID}");

            record.TaskID = 0; // identity insert
            await _taskService!.AddTaskAsync(record);
        }
    }

    if (deletedRecords is IEnumerable<TaskDataModel> deleted)
    {
        foreach (var record in deleted)
            await _taskService!.RemoveTaskAsync(record.TaskID);
    }

    return key;
}
```

**What happens behind the scenes:**

- The Gantt Chart collects all added, edited, and deleted records in Batch Edit mode.
- The combined batch request is passed to the CustomAdaptor’s `BatchUpdateAsync()` method.
- Each modified record is processed using `TaskRepository.UpdateTaskAsync()`.
- Each newly added record is saved using `TaskRepository.AddTaskAsync()`.
- Each deleted record is removed using `TaskRepository.RemoveTaskAsync()`.
- All repository operations persist changes to the MySQL Server database.
- The Gantt Chart refreshes to display the updated, added, and removed records in a single response.

Now the adaptor supports bulk modifications with atomic database synchronization. All CRUD operations are now fully implemented, enabling comprehensive data management capabilities within the Blazor Gantt Chart.

**Reference links**
- [InsertAsync(DataManager, object)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_InsertAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_) - Create new records in MySQL Server
- [UpdateAsync(DataManager, object, string, string)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_UpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) - Edit existing records in MySQL Server
- [RemoveAsync(DataManager, object, string, string)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_RemoveAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) - Delete records from MySQL Server
- [BatchUpdateAsync(DataManager, object, object, object, string, string, int?)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_BatchUpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_Object_System_Object_System_String_System_String_System_Nullable_System_Int32__) - Handle bulk operations

---

### Step 9: Complete code
Here is the complete and final `Home.razor` component with all features integrated:

```cshtml

@using System.Collections
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Gantt
@using GanttMySql.Data

@inject TaskRepository TaskService

<SfGantt TValue="TaskDataModel" Height="500px" Width="100%" AllowSorting="true" AllowFiltering="true" EnableContextMenu="true" 
         Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" })">

    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>

    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Progress="Progress" Duration="Duration" ParentID="ParentID" Dependency="Predecessor">
    </GanttTaskFields>

    <GanttEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" AllowTaskbarEditing="true" Mode="Syncfusion.Blazor.Gantt.EditMode.Auto"></GanttEditSettings>

    <GanttColumns>
        <GanttColumn Field=@nameof(TaskDataModel.TaskID) HeaderText="Task ID" IsPrimaryKey="true" Width="150" />
        <GanttColumn Field=@nameof(TaskDataModel.TaskName) HeaderText="Task Name" Width="220" />
        <GanttColumn Field=@nameof(TaskDataModel.StartDate) HeaderText="Start Date" Width="170" />
        <GanttColumn Field=@nameof(TaskDataModel.EndDate) HeaderText="End Date" Width="170" />
        <GanttColumn Field=@nameof(TaskDataModel.Duration) HeaderText="Duration" Width="130" />
        <GanttColumn Field=@nameof(TaskDataModel.Predecessor) HeaderText="Predecessor" Width="130" />
        <GanttColumn Field=@nameof(TaskDataModel.Progress) HeaderText="Progress" Width="120" />
    </GanttColumns>

</SfGantt>
```
> * Set [IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html#Syncfusion_Blazor_Gantt_GanttColumn_IsPrimaryKey) to **true** for a column that contains unique values.
> * Set [IsIdentity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html#Syncfusion_Blazor_Gantt_GanttColumn_IsIdentity) to **true** for auto-generated columns to disable editing during add or update operations.
> * The behavior of default editors can be customized using the [GanttEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEditSettings.html) property of the `GanttColumn` component. [🔗](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html)


```csharp
@code {
    private CustomAdaptor? _customAdaptor;

    /// <summary>
    /// Initializes the component and sets up the custom adaptor with the injected TaskService.
    /// </summary>
    protected override void OnInitialized()
    {
        _customAdaptor = new CustomAdaptor { TaskService = TaskService };
    }   

    /// <summary>
    /// Custom DataAdaptor to handle Gantt data operations with MySQL using EF Core.
    /// Bridges Syncfusion DataManager requests to the repository.
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        private static TaskRepository? _taskService { get; set; }   

        /// <summary>
        /// Task repository instance used to fulfill data operations.
        /// </summary>
        public TaskRepository? TaskService
        {
            get => _taskService;
            set => _taskService = value;
        }   

        /// <summary>
        /// Reads data according to DataManagerRequest (search, sort, paging).
        /// </summary>
        /// <param name="dm">The DataManagerRequest containing query, paging, sorting, and search criteria.</param>
        /// <param name="key">Optional key value for single-record reads.</param>
        /// <returns>
        /// Returns either a <see cref="DataResult"/> (when counts are requested) or the IEnumerable of tasks as an object.
        /// </returns>
        public override async Task<object> ReadAsync(DataManagerRequest dm, string? key = null)
        {
            IEnumerable<TaskDataModel> dataSource = await _taskService!.GetTasksAsync();    

            // Search
            if (dm.Search != null && dm.Search.Count > 0)
                dataSource = DataOperations.PerformSearching(dataSource, dm.Search);    

            // Sort
            if (dm.Sorted != null && dm.Sorted.Count > 0)
                dataSource = DataOperations.PerformSorting(dataSource, dm.Sorted);  

            int count = dataSource.Cast<TaskDataModel>().Count();   

            if (dm.Skip != 0) dataSource = DataOperations.PerformSkip(dataSource, dm.Skip);
            if (dm.Take != 0) dataSource = DataOperations.PerformTake(dataSource, dm.Take); 

            return dm.RequiresCounts
                ? new DataResult() { Result = dataSource, Count = count }
                : (object)dataSource;
        }   

        /// <summary>
        /// Updates a task record using the repository.
        /// </summary>
        /// <param name="dm">The DataManager instance (framework-provided).</param>
        /// <param name="value">The updated object (expected <see cref="TaskDataModel"/>).</param>
        /// <param name="keyField">Optional key field name.</param>
        /// <param name="key">Key value identifying the record.</param>
        /// <returns>The updated object.</returns>
        public override async Task<object> UpdateAsync(DataManager dm, object value, string? keyField, string key)
        {
            await _taskService!.UpdateTaskAsync(value as TaskDataModel);
            return value;
        }   

        /// <summary>
        /// Removes a task record using the repository.
        /// </summary>
        /// <param name="dm">The DataManager instance (framework-provided).</param>
        /// <param name="value">The object representing the record to remove (various types supported).</param>
        /// <param name="keyField">Optional key field name.</param>
        /// <param name="key">Key value identifying the record.</param>
        /// <returns>The removed object.</returns>
        public override async Task<object> RemoveAsync(DataManager dm, object value, string? keyField, string key)
        {
            int? taskID = value switch
            {
                int i => i,
                long l => (int)l,
                string s when int.TryParse(s, out var id) => id,
                TaskDataModel t => t.TaskID,
                _ => null
            };  

            await _taskService!.RemoveTaskAsync(taskID);
            return value;
        }   

        /// <summary>
        /// Applies batch changes: updates, inserts, and deletes using the repository.
        /// </summary>
        /// <param name="dm">The DataManager instance (framework-provided).</param>
        /// <param name="changedRecords">Records that were modified.</param>
        /// <param name="addedRecords">Records that were added.</param>
        /// <param name="deletedRecords">Records that were deleted.</param>
        /// <param name="keyField">Optional key field name.</param>
        /// <param name="key">Key value used by the batch operation.</param>
        /// <param name="dropIndex">Optional drop index for drag-and-drop operations.</param>
        /// <returns>A task that yields the batch operation key or result.</returns>
        public override async Task<object> BatchUpdateAsync(DataManager dm, object changedRecords, object addedRecords, object deletedRecords, string? keyField, string key, int? dropIndex)
        {
            if (changedRecords is IEnumerable<TaskDataModel> changed)
            {
                foreach (var record in changed)
                {
                    // Debug (optional)
                    Console.WriteLine($"UPDATE TaskID={record.TaskID}, ParentID={record.ParentID}");
                    await _taskService!.UpdateTaskAsync(record);
                }
            }   

            if (addedRecords is IEnumerable<TaskDataModel> added)
            {
                foreach (var record in added)
                {
                    // Debug (optional)
                    Console.WriteLine($"INSERT TaskID={record.TaskID}, ParentID={record.ParentID}");    

                    record.TaskID = 0; // identity insert
                    await _taskService!.AddTaskAsync(record);
                }
            }   

            if (deletedRecords is IEnumerable<TaskDataModel> deleted)
            {
                foreach (var record in deleted)
                    await _taskService!.RemoveTaskAsync(record.TaskID);
            }   

            return key;
        }
    }
}

```

## Running the Application

**Step 1: Build the Application**

1. Open the terminal or Package Manager Console.
2. Navigate to the project directory.
3. Run the following command:

```powershell
dotnet build
```

**Step 2: Run the Application**

Execute the following command:

```powershell
dotnet run
```

**Step 3: Access the Application**

1. Open a web browser.
2. Navigate to `https://localhost:xxxx` (`xxxx`- port shown in the terminal).
3. The Gantt Chart is now running and ready to use.

**Available Features**

- **View Data**: All tasks from the SQL Server database are displayed in the Gantt Chart.
- **Search**: Use the search box to find tasks by any field.
- **Filter**: Click on column headers to apply filters.
- **Sort**: Click on column headers to sort data in ascending or descending order.
- **Add**: Click the "Add" button to create a new task.
- **Edit**: Click the "Edit" button to modify existing task.
- **Delete**: Click the "Delete" button to remove task.

---

## Summary

This guide demonstrates how to:
1. Create a MySQL database with task records. [🔗](#step-1-create-the-database-and-table-in-mysql-server)
2. Install necessary NuGet packages for Entity Framework Core and Syncfusion. [🔗](#step-2-install-required-nuget-packages)
3. Create data models and DbContext for database communication. [🔗](#step-3-create-the-data-model)
4. Configure connection strings and register services. [🔗](#step-5-configure-the-connection-string)
5. Implement the repository pattern for data access. [🔗](#step-6-create-the-repository-class)
6. Create a Blazor component with a Gantt Chart that supports searching, filtering, sorting and CRUD operations. [🔗](#step-1-install-and-configure-syncfusion-blazor-gantt-components)
7. Handle bulk operations and batch updates. [🔗](#step-10-perform-crud-operations)

The application now provides a complete solution for managing task data with a modern, user-friendly interface.