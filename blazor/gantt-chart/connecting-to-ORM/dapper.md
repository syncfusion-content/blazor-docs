---
layout: post
title: Blazor Gantt Chart Connected to SQL Server via Dapper | Syncfusion
description: Bind SQL Server data to Blazor Gantt Chart using Dapper with complete CRUD, filtering, sorting, paging and advanced data operations.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Connecting SQL Server to Blazor Gantt Chart Using Dapper

The [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart) supports binding data from SQL Server using the lightweight Dapper micro‑ORM. This modern approach provides a simpler, more direct alternative where raw SQL control is preferred.

**What is Dapper?**

Dapper is a lightweight, high-performance ORM (Object-Relational Mapper) that provides a minimal abstraction over ADO.NET. It maps query results directly to C# objects with minimal overhead, making it ideal for applications where performance and control over SQL are critical.

**Key Benefits of Dapper**

- **High Performance**: Minimal overhead with direct ADO.NET access, resulting in faster query execution.
- **SQL Control**: Write raw SQL queries when needed, giving developers full control over database operations.
- **Simple and Lightweight**: Requires minimal configuration and learning curve compared to full ORMs.
- **Flexible Mapping**: Automatically maps query results to C# objects with minimal configuration.
- **Built-in Security**: Parameterized queries prevent SQL injection attacks.

## Prerequisites

Ensure the following software and packages are installed before proceeding:

| Software/Package | Version | Purpose |
|-----------------|---------|---------|
| Visual Studio 2026 | 18.2.1 or later | Development IDE with Blazor workload |
| .NET SDK | net10.0 or compatible | Runtime and build tools |
| SQL Server | 2021 or later | Database server |
| Syncfusion.Blazor.Gantt | {{site.blazorversion}} | Gantt Chart and UI components |
| Syncfusion.Blazor.Themes | {{site.blazorversion}} | Styling for Gantt Chart components |
| Microsoft.Data.SqlClient | Latest | SQL Server ADO.NET provider |
| Dapper | Latest | Lightweight micro-ORM for SQL mapping |

## Setting up the SQL Server Environment with Dapper

### Step 1: Create the database and table in SQL Server

First, the **SQL Server database** structure must be created to store records.

**Instructions:**
1. Open SQL Server Management Studio or any SQL Server client.
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

-- Create TaskData table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'TaskData')
BEGIN
    CREATE TABLE dbo.TaskData (
        TaskID INT PRIMARY KEY,
        TaskName VARCHAR(50) NOT NULL,
        StartDate DATETIME NULL,
        EndDate DATETIME NULL,
        ParentID INT NULL,
        Duration VARCHAR(50) NOT NULL,
        Predecessor VARCHAR(50) NULL,
        Progress INT NOT NULL
    );
END
GO

-- Insert Sample Data (Optional)
INSERT INTO TaskData (TaskName, StartDate, EndDate, ParentID, Duration, Predecessor, Progress)
VALUES
('Product concept', '2026-04-02', '2026-04-08', NULL, '5', NULL, 0),
('Define the product usage', '2026-04-02', '2026-04-08', 1, '3','1FS', 30),
GO
```

After executing this script, the task data are stored in the `TaskData` table within the `GanttDB` database. The database is now ready for integration with the Blazor application.

---

### Step 2: Install required NuGet packages

Before installing the necessary NuGet packages, a new Blazor Web Application must be created using the default template.
This template automatically generates essential starter files—such as **Program.cs, appsettings.json, the wwwroot folder, and the Components folder**.

For this guide, a Blazor application named **GanttDapper** has been created. Once the project is set up, the next step involves installing the required NuGet packages. NuGet packages are software libraries that add functionality to the application. These packages enable Dapper and SQL Server integration.

**Method 1: Using Package Manager Console**

1. Open Visual Studio 2026.
2. Navigate to **Tools → NuGet Package Manager → Package Manager Console**.
3. Run the following commands:

```powershell
Install-Package Microsoft.Data.SqlClient -Version Latest
Install-Package Dapper -Version Latest
Install-Package Syncfusion.Blazor.Gantt -Version {{site.blazorversion}}
Install-Package Syncfusion.Blazor.Themes -Version {{site.blazorversion}}
```

**Method 2: Using NuGet Package Manager UI**

1. Open **Visual Studio 2026 → Tools → NuGet Package Manager → Manage NuGet Packages for Solution**.
2. Search for and install each package individually:
   - **Microsoft.Data.SqlClient** (Latest version)
   - **Dapper** (Latest version)
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
using System.ComponentModel.DataAnnotations;

namespace GanttDapper.Data
{
    /// <summary>
    /// Represents a record mapped to the 'TaskData' table in the database.
    /// </summary>
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

### Step 4: Configure the connection string

A connection string contains the information needed to connect the application to the SQL Server database, including the server address, database name, and credentials.

**Instructions:**

1. Open the `appsettings.json` file in the project root.
2. Add or update the `ConnectionStrings` section with the SQL Server connection details:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=localhost;Initial Catalog=GanttDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
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
| Data Source | The address of the SQL Server instance (server name, IP address, or localhost) |
| Initial Catalog | The database name (in this case, `GanttDB`) |
| Integrated Security | Set to `True` for Windows Authentication; use `False` with Username/Password for SQL Authentication |
| Connect Timeout | Connection timeout in seconds (default is 15) |
| Encrypt | Enables encryption for the connection (set to `True` for production environments) |
| Trust Server Certificate | Whether to trust the server certificate (set to `False` for security) |
| Application Intent | Set to `ReadWrite` for normal operations or `ReadOnly` for read-only scenarios |
| Multi Subnet Failover | Used in failover clustering scenarios (typically `False`) |

The database connection string has been configured successfully.

### Step 5: Create the repository class

A repository class is an intermediary layer that handles all database operations. With Dapper, this class uses raw SQL queries with ADO.NET to communicate with the database.

**Instructions:**

1. Inside the `Data` folder, create a new file named **TaskRepository.cs**.
2. Define the **TaskRepository** class with the following code: 

```csharp
using Dapper;
using System.Data;

namespace GanttDapper.Data
{
    /// <summary>
    /// Repository implementation for TaskDataModel using EF Core.
    /// Handles CRUD operations and simple task business rules.
    /// </summary>
    public class TaskRepository
    {
        private readonly IDbConnection _connection;

        public TaskRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// Retrieves all task data from the database ordered by id descending
        /// </summary>
        /// <returns>List of all task data</returns>
        public async Task<List<TaskDataModel>> GetTaskData()
        {
            try
            {
                const string query = @"SELECT * FROM [dbo].[TaskData] ORDER BY TaskID DESC";
                var task = await _connection.QueryAsync<TaskDataModel>(query);
                return task.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving task: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Adds a new task to the database
        /// </summary>
        /// <param name="value">The task model to add</param>
        public async Task AddTaskAsync(TaskDataModel value)
        {
            // Handle logic to add a new task to the database
        }

        /// <summary>
        /// Updates an existing task data
        /// </summary>
        /// <param name="value">The task data model with updated values</param>
        public async Task UpdateTaskAsync(TaskDataModel value)
        {
            // Handle logic to update an existing task to the database
        }

        /// <summary>
        /// Deletes a task from the database
        /// </summary>
        /// <param name="key">The TaskID to delete</param>
        public async Task RemoveTaskAsync(int? key)
        {
           // Handle logic to delete an existing task from the database
        }
    }
}
```

**QueryAsync&lt;T&gt;** is a Dapper extension method on IDbConnection that:
- Executes a SQL query asynchronously (uses **ADO.NET** async under the hood).
- Maps each row in the result set to an instance of T (here, TaskDataModel) by matching column names to property names.
- Returns an **IEnumerable&lt;T&gt;**.

The repository class manages all interactions with the database and is now ready for implementation.

---

### Step 6: Register services in Program.cs

The `Program.cs` file is where application services are registered and configured. This file must be updated to enable Dapper and the repository pattern.

**Instructions:**

1. Open the `Program.cs` file at the project root.
2. Add the following code after the line `var builder = WebApplication.CreateBuilder(args);`:

```csharp
using Microsoft.Data.SqlClient;
using GanttDapper.Data;
using Syncfusion.Blazor;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSyncfusionBlazor();

// Get connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found in configuration.");
}

// Register IDbConnection for Dapper
builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(connectionString));

// Register the repository for dependency injection
builder.Services.AddScoped<TaskRepository>();

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

**Explanation:**
- **`AddScoped<IDbConnection>`**: Dapper requires an ADO.NET connection object, registered as a scoped service so each request gets its own connection.
- **`AddScoped<TaskRepository>`**: Makes the TaskRepository available for dependency injection throughout the application.
- **`AddSyncfusionBlazor()`**: Registers Syncfusion Blazor components.
- **`AddRazorComponents()` and `AddInteractiveServerComponents()`**: Enables Blazor server-side rendering with interactive components.


The service registration has been completed successfully.

---

## Integrating Syncfusion Blazor Gantt Chart

### Step 1: Install and configure Blazor Gantt Chart Component

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
<link href="_content/Syncfusion.Blazor/Themes/tailwind3.css" rel="stylesheet" />

<!-- Syncfusion Blazor Scripts -->
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
```
For this project, the tailwind3 theme is used. A different theme can be selected or the existing theme can be customized based on project requirements. Refer to the [Syncfusion Blazor Components Appearance](https://blazor.syncfusion.com/documentation/appearance/themes) documentation to learn more about theming and customization options.

Syncfusion components are now configured and ready to use. For additional guidance, refer to the Gantt Chart component's [getting‑started](https://blazor.syncfusion.com/documentation/gantt-chart/getting-started-with-web-app) documentation.

### Step 2: Update the Blazor Gantt Chart

The `Home.razor` component will display the task data in a Syncfusion Blazor Gantt Chart with search, filter, and sorting capabilities.

**Instructions:**

1. Open the file named `Home.razor` in the `Components/Pages` folder.
2. Add the following code to create a Gantt Chart with CustomAdaptor:

```cshtml

@using System.Collections
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Gantt
@using GanttDapper.Data

@inject TaskRepository TaskService

<SfGantt TValue="TaskData" Height="500px" Width="100%" AllowSorting="true" AllowFiltering="true">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>

    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Progress="Progress" Duration="Duration" ParentID="ParentID" Dependency="Predecessor">
    </GanttTaskFields>
    <GanttColumns>
        <!-- Columns configuration -->
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
- **`<GanttColumn>`**: Defines individual columns in the Gantt Chart.

The Home component has been updated successfully with Gantt Chart.

### Step 3: Implement the custom adaptor

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Gantt Chart can bind data from a **SQL Server** database using [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) and set the [Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Adaptors.html) property to [CustomAdaptor](https://blazor.syncfusion.com/documentation/Gantt Chart/connecting-to-adaptors/custom-adaptor) for scenarios that require full control over data operations.

The `CustomAdaptor` is a bridge between the Gantt Chart and the database. It handles all data operations including reading, searching, filtering, sorting, and CRUD operations. Each operation in the CustomAdaptor's `ReadAsync` method handles specific Gantt Chart functionality. The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Gantt Chart sends operation details to the API through a [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html) object. These details can be applied to the data source using methods from the [DataOperations](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html) class.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Add the following `CustomAdaptor` class code inside the `@code` block:

```csharp
@code {

    private CustomAdaptor? _customAdaptor;

    protected override void OnInitialized()
    {
        // Initialize the CustomAdaptor with the injected TaskRepository
         _customAdaptor = new CustomAdaptor { TaskService = TaskService };
    }

    /// <summary>
    /// CustomAdaptor class bridges Gantt interactions with database operations.
    /// This adaptor handles all data retrieval and manipulation for the Gantt.
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        private static TaskRepository? _taskService { get; set; }

        public TaskRepository? TaskService
        {
            get => _taskService;
            set => _taskService = value;
        }

        /// <summary>
        /// ReadAsync retrieves records from the database and applies data operations.
        /// This method executes when the Gantt initializes and when filtering, searching, sorting, or paging occurs.
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

                // Calculate total record count before paging for accurate pagination
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

* [ReadAsync(DataManagerRequest)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_ReadAsync_Syncfusion_Blazor_DataManagerRequest_System_String_) - Retrieve and process records (search, filter, sort, page, group)

* [PerformSearching](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSearching__1_System_Linq_IQueryable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_SearchFilter__) - Applies search criteria to the collection.
* [PerformFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformFiltering__1_System_Linq_IQueryable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_WhereFilter__System_String_) - Filters data based on conditions.
* [PerformSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSorting__1_System_Linq_IQueryable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_Sort__) - Sorts data by one or more fields.
* [PerformSkip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSkip__1_System_Linq_IQueryable___0__System_Int32_) - Skips a defined number of records for paging.
* [PerformTake](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformTake__1_System_Linq_IQueryable___0__System_Int32_) - Retrieves a specified number of records for paging.

---

### Step 4: Add Toolbar with CRUD and search options

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
| `Add` | Opens the Dialog to add a new task data. |
| `Edit` | Enables editing of the selected record. |
| `Delete` | Deletes the selected record from the database. |
| `Update` | Saves changes made to the selected record. |
| `Cancel` | Cancels the current edit or add operation. |
| `Search` | Displays a search box to find records. |

The toolbar has been successfully added.

---

### Step 5: Implement searching feature

Searching helps to find records by entering keywords in the search box.

1. Ensure the toolbar includes the "Search" item.

```cshtml
<SfGantt TValue="TaskDataModel"
        Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GanttColumns>
        <!-- Gantt columns configuration -->
    </GanttColumns>
</SfGantt>
```

2. Update the `ReadAsync` method in the `CustomAdaptor` class to handle searching:

```csharp
@code {
    private List<string> ToolbarItems = new List<string> { "Search"};
    
    /// <summary>
    /// CustomAdaptor class to handle Gantt data operations with MSSQL with Dapper
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

- When a text is entered in the search box and press Enter, the Gantt Chart sends a search request to the CustomAdaptor.
- The `ReadAsync` method receives the search criteria in `dataManagerRequest.Search`.
- The `DataOperations.PerformSearching()` method filters the data based on the search term.
- Results are returned and displayed in the Gantt Chart.

Searching feature is now active.

---

### Step 6: Implement filtering feature

Filtering allows to restrict data based on column values using a menu interface.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Add the [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AllowFiltering) property to the `<SfGantt` component:

```cshtml
<SfGantt TValue="TaskDataModel"       
        AllowFiltering="true" >
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>    
    <GanttColumns>
        <!-- Gantt columns configuration -->
    </GanttColumns>
</SfGantt>
```
3. Update the `ReadAsync` method in the `CustomAdaptor` class to handle filtering:

```csharp
@code {
    /// <summary>
    /// CustomAdaptor class to handle Gantt data operations with MSSQL with Dapper
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

Sorting enables the records to arrange in ascending or descending order based on column values.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Add the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AllowSorting) property to the `<SfGantt>` component:

```cshtml
<SfGantt TValue="TaskDataModel"
        AllowSorting="true">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GanttColumns>
        <!-- Gantt columns configuration -->
    </GanttColumns>
</SfGantt>
```
3. Update the `ReadAsync` method in the `CustomAdaptor` class to handle sorting:

```csharp
@code {
    /// <summary>
    /// CustomAdaptor class to handle Gantt data operations with MSSQL with Dapper
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
- The `DataOperations.PerformSorting()` method sorts the data based on the specified column and direction.
- Records are sorted accordingly and displayed in the Gantt Chart.

Sorting feature is now active.

---

### Step 8: Perform CRUD operations

CustomAdaptor methods is used to create, read, update, and delete records directly from the Gantt Chart. Each operation calls corresponding data layer methods in **TaskRepository.cs** to execute SQL commands through Dapper.

Add the Gantt **EditSettings** and **Toolbar** configuration to enable create, read, update, and delete (CRUD) operations.

```cshtml
<SfGantt TValue="TaskDataModel"
        AllowSorting="true" 
        AllowFiltering="true"
        Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>     
     <GanttEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" AllowTaskbarEditing="true"></GanttEditSettings>
    <GanttColumns>
        <!-- Gantt columns configuration -->
    </GanttColumns>
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

Record insertion allows new tasks to be added directly through the Gantt Chart component. The adaptor processes the insertion request, performs any required business‑logic validation, and saves the newly created record to the SQL Server database via Dapper.

In **Home.razor**, implement the `InsertAsync` method within the `CustomAdaptor` class:

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

In **Data/TaskRepository.cs**, the insert method is implemented as:

```csharp
public async Task AddTaskAsync(TaskDataModel value)
{
    if (value == null)
        throw new ArgumentNullException(nameof(value), "Task cannot be null");

    value.TaskName ??= "New Task";
    value.Duration ??= "1";
    value.Progress ??= 0;
    value.StartDate ??= DateTime.Now;

    const string query = @"
        INSERT INTO [dbo].[TaskData] 
        (TaskName, StartDate, EndDate, ParentID, Duration, Predecessor, Progress)
        VALUES
        (@TaskID, @TaskName, @StartDate, @EndDate, @ParentID,
        @Duration, @Predecessor, @Progress)";

    await _connection.ExecuteAsync(query, value);
}

```

**What happens behind the scenes:**

1. The Dialog data is collected and validated in the CustomAdaptor's `InsertAsync()` method.
2. The `TaskRepository.AddTaskAsync()` method is called.
3. Dapper's `ExecuteAsync()` method executes the INSERT query with parameterized values.
4. The Gantt Chart automatically refreshes to display the new record.

Now the new task is persisted to the database and reflected in the gantt.

**Update**

Record modification allows task details to be updated directly within the Gantt Chart. The adaptor processes the edited task, validates the updated values, and applies the changes to the **SQL Server database** via Dapper while ensuring data integrity is preserved.

In **Home.razor**, implement the `UpdateAsync` method within the `CustomAdaptor` class:

```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> UpdateAsync(DataManager dataManager, object value, string keyField, string key)
    {    
        await _taskService!.UpdateTaskAsync(value as TaskDataModel);
        return value;
    }
}
```

In **Data/TaskRepository.cs**, the update method is implemented as:

```csharp
public async Task UpdateTaskAsync(TaskDataModel value)
{
    try
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value), "Task cannot be null");

        if (value.TaskID <= 0)
            throw new ArgumentException("TaskID must be valid", nameof(value));

        const string checkQuery = "SELECT COUNT(*) FROM [dbo].[TaskDate] WHERE TaskID = @TaskID";
        var exists = await _connection.QueryFirstOrDefaultAsync<int>(checkQuery, new { value.TaskID });
        
        if (exists == 0)
            throw new KeyNotFoundException($"Task with ID {value.TaskID} not found");
        
        const string query = @"
            UPDATE [dbo].[TaskData]
            SET TaskName = @TaskName, 
                StartDate = @StartDate, EndDate = @EndDate, Duration = @Duration,
                Predecessor = @Predecessor, Progress = @Progress, 
            WHERE TaskID = @TaskID;"

        await _connection.ExecuteAsync(query, value);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error updating task: {ex.Message}");
        throw;
    }
}
```

**What happens behind the scenes:**

1. The modified data is collected from the Dialog.
2. The CustomAdaptor's `UpdateAsync()` method is called.
3. The `TaskRepository.UpdateTaskAsync()` method validates the task exists.
4. Dapper's `ExecuteAsync()` method executes the UPDATE query with parameterized values.
6. The Gantt Chart refreshes to display the updated record.

Now modifications are synchronized to the database and reflected in the Gantt Chart UI.

**Delete**

Record deletion allows tasks to be removed directly from the Gantt Chart. The adaptor captures the delete request, executes the corresponding **SQL Server DELETE** operation via Dapper, and updates both the database and the Gantt Chart to reflect the removal.

In **Home.razor**, implement the `RemoveAsync` method within the `CustomAdaptor` class:

```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> RemoveAsync(DataManager dataManager, object value, string? keyField, string key)
    {
        await _taskService!.RemoveTaskAsync(value as int?);
        return value;
    }
}
```

In **Data/TaskRepository.cs**, the delete method is implemented as:

```csharp
public async Task RemoveTaskAsync(int? key)
{
    try
    {
        if (key == null || key <= 0)
            throw new ArgumentException("Task ID cannot be null or invalid", nameof(key));

        const string checkQuery = "SELECT COUNT(*) FROM [dbo].[TaskData] WHERE TaskID = @TaskID";
        var exists = await _connection.QueryFirstOrDefaultAsync<int>(checkQuery, new { TaskID = key });
        
        if (exists == 0)
            throw new KeyNotFoundException($"Task with ID {key} not found");

        const string query = "DELETE FROM [dbo].[TaskData] WHERE TaskID = @TaskID";
        await _connection.ExecuteAsync(query, new { TaskID = key });
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error deleting task: {ex.Message}");
        throw;
    }
}
```

**What happens behind the scenes:**

1. Select a record and click "Delete".
2. A confirmation dialog appears (built into the Gantt Chart).
3. If confirmed, the CustomAdaptor's `RemoveAsync()` method is called.
4. The `TaskRepository.RemoveTaskAsync()` method validates the task exists.
5. Dapper's `ExecuteAsync()` method executes the DELETE query.
6. The Gantt Chart refreshes to remove the deleted record from the UI.

Now tasks are removed from the database and the Gantt Chart UI reflects the changes immediately.

**Batch update**

Batch operations combine multiple insert, update, and delete actions into a single request, minimizing network overhead and ensuring all changes are processed together to the SQL Server database via Dapper.

In **Home.razor**, implement the `BatchUpdateAsync` method within the `CustomAdaptor` class:

```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> BatchUpdateAsync(DataManager dataManager, object changed, object added, object deleted, string keyField, string key, int? dropIndex)
    {
        // Handle updated records
        if (changed != null && _taskService != null)
        {
            foreach (var record in (IEnumerable<TaskDataModel>)changed)
            {
                await _taskService.UpdateTaskAsync(record);
            }
        }

        // Handle new records
        if (added != null && _taskService != null)
        {
            foreach (var record in (IEnumerable<TaskDataModel>)added)
            {
                await _taskService.AddTaskAsync(record);
            }
        }

        // Handle deleted records
        if (deleted != null && _taskService != null)
        {
            foreach (var record in (IEnumerable<TaskDataModel>)deleted)
            {
                await _taskService.RemoveTaskAsync(record.TaskID);
            }
        }
        return key;
    }
}
```

**What happens behind the scenes:**

- The Gantt Chart collects all added, edited, and deleted records in Batch Edit mode.
- The combined batch request is passed to the CustomAdaptor's `BatchUpdateAsync()` method.
- Each modified record is processed using `TaskRepository.UpdateTaskAsync()`.
- Each newly added record is saved using `TaskRepository.AddTaskAsync()`.
- Each deleted record is removed using `TaskRepository.RemoveTaskAsync()`.
- All repository operations persist changes to the SQL Server database via Dapper.
- The Gantt Chart refreshes to display the updated, added, and removed records in a single response.

Now the adaptor supports bulk modifications with database synchronization. All CRUD operations are now fully implemented, enabling comprehensive data management capabilities within the Blazor Gantt Chart.

**Reference links**

- [InsertAsync(DataManager, object)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_InsertAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_) - Create new records in SQL Server
- [UpdateAsync(DataManager, object, string, string)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_UpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) - Edit existing records in SQL Server
- [RemoveAsync(DataManager, object, string, string)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_RemoveAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) - Delete records from SQL Server
- [BatchUpdateAsync(DataManager, object, object, object, string, string, int?)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_BatchUpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_Object_System_Object_System_String_System_String_System_Nullable_System_Int32__) - Handle bulk operations

 > **ExecuteAsync** is used to run commands that don’t return result sets—typically **INSERT, UPDATE, DELETE, CREATE TABLE,** or **calling stored procedures** that return only the number of affected tasks.

---

### Step 9: Complete code

Here is the complete and final `Home.razor` component with all features integrated:

```cshtml

@using System.Collections
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Gantt
@using GanttDapper.Data

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

    protected override void OnInitialized()
    {
        // Initialize the CustomAdaptor with the injected TaskRepository
        _customAdaptor = new CustomAdaptor { TaskService = TaskService };
    }

    /// <summary>
    /// Custom DataAdaptor to handle Gantt data operations with MSSQL using Dapper.
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

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
        {
            IEnumerable dataSource = await _taskService!.GetTasksAsync();

            if (dataManagerRequest.Search != null && dataManagerRequest.Search.Count > 0)
                dataSource = DataOperations.PerformSearching(dataSource, dataManagerRequest.Search);

            if (dataManagerRequest.Where != null && dataManagerRequest.Where.Count > 0)
                dataSource = DataOperations.PerformFiltering(dataSource, dataManagerRequest.Where, dataManagerRequest.Where[0].Operator);

            if (dataManagerRequest.Sorted != null && dataManagerRequest.Sorted.Count > 0)
                dataSource = DataOperations.PerformSorting(dataSource, dataManagerRequest.Sorted);

            int totalRecordsCount = dataSource.Cast<TaskDataModel>().Count();

            if (dataManagerRequest.Skip != 0)
            {
                dataSource = DataOperations.PerformSkip(dataSource, dataManagerRequest.Skip);
            }

            if (dataManagerRequest.Take != 0)
            {
                dataSource = DataOperations.PerformTake(dataSource, dataManagerRequest.Take);
            }

            return dataManagerRequest.RequiresCounts 
                ? new DataResult() { Result = dataSource, Count = totalRecordsCount } 
                : (object)dataSource;
        }

        public override async Task<object> InsertAsync(DataManager dataManager, object value, string? key)
        {
            await _taskService!.AddTaskAsync(value as TaskDataModel);
            return value;
        }

        public override async Task<object> UpdateAsync(DataManager dataManager, object value, string? keyField, string key)
        {
            await _taskService!.UpdateTaskAsync(value as TaskDataModel);
            return value;
        }

        public override async Task<object> RemoveAsync(DataManager dataManager, object value, string? keyField, string key)
        {
            await _taskService!.RemoveTaskAsync(value as int?);
            return value;
        }

        public override async Task<object> BatchUpdateAsync(DataManager dataManager, object changedRecords, object addedRecords, object deletedRecords, string? keyField, string key, int? dropIndex)
        {
            if (changedRecords != null)
                foreach (var record in (IEnumerable<TaskDataModel>)changedRecords)
                    await _taskService!.UpdateTaskAsync(record as TaskDataModel);

            if (addedRecords != null)
                foreach (var record in (IEnumerable<TaskDataModel>)addedRecords)
                    await _taskService!.AddTaskAsync(record as TaskDataModel);

            if (deletedRecords != null)
                foreach (var record in (IEnumerable<TaskDataModel>)deletedRecords)
                    await _taskService!.RemoveTaskAsync((record as TaskDataModel).TaskID);

            return key;
        }
    }
}
```
---

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

## Summary

This guide demonstrates how to:
1. Create a SQL Server database with task data. [🔗](#step-1-create-the-database-and-table-in-sql-server)
2. Install necessary NuGet packages for Dapper and Syncfusion. [🔗](#step-2-install-required-nuget-packages)
3. Create data models for database mapping. [🔗](#step-3-create-the-data-model)
4. Configure connection strings for SQL Server. [🔗](#step-4-configure-the-connection-string)
5. Implement the repository pattern with Dapper for efficient data access. [🔗](#step-5-create-the-repository-class)
6. Create a Blazor component with a Gantt Chart that supports searching, filtering, sorting,  and CRUD operations. [🔗](#step-1-install-and-configure-blazor-gantt-chart-components)
7. Handle bulk operations and batch updates. [🔗](#step-8-perform-crud-operations)

The application now provides a complete solution for managing task data with a modern, user-friendly interface using Dapper for high-performance database access.