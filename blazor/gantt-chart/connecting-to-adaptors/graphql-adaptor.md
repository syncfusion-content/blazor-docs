---
layout: post
title: GraphQLAdaptor with CRUD Operations in Blazor Gantt Chart | Syncfusion®
description: Learn how to bind data and perform CRUD operations using the GraphQLAdaptor in the Blazor Gantt Chart component and much more.
platform: Blazor
control: Gantt Chart
keywords: adaptors, graphqladaptor, graphql adaptor, hot chocolate, remotedata
documentation: ug
---

# Connect Syncfusion Blazor Gantt Chart with GraphQL using Hot Chocolate

GraphQL is a query language that allows applications to request exactly the data needed, nothing more and nothing less. Unlike traditional REST APIs that return fixed data structures, GraphQL enables the client to specify the shape and content of the response.

**Traditional REST APIs** and **GraphQL** differ mainly in how data is requested and returned: **REST APIs expose** multiple endpoints that return fixed data structures, often including unnecessary fields and requiring several requests to fetch related data, while **GraphQL** uses a single endpoint where queries define the exact fields needed, enabling precise responses and allowing related data to be retrieved efficiently in one request. This makes **GraphQL** especially useful for **Blazor Gantt Chart integration**, the **reason** is data‑centric UI components require well‑structured and selective datasets to support efficient filtering, reduce network calls, and improve overall performance.

**Key GraphQL Concepts**

- **Queries**: A query is a request to read data. Queries do not modify data; they only retrieve it.
- **Mutations**: A mutation is a request to modify data. Mutations create, update, or delete records.
- **Resolvers**: Each query or mutation is handled by a resolver, which is a function responsible for fetching data or executing an operation. **Query resolvers** handle **read operations**, while **mutation resolvers** handle **write operations**.
- **Schema**: Defines the structure of the API. The schema describes available data types, the fields within those types, and the operations that can be executed. Query definitions specify how data can be retrieved, and mutation definitions specify how data can be modified. 

[Hot Chocolate](https://chillicream.com/docs/hotchocolate/v15) is an open‑source GraphQL server framework for .NET. Hot Chocolate enables the creation of GraphQL APIs using ASP.NET Core and integrates seamlessly with modern .NET applications, including Blazor.

## Prerequisites

Install the following software and packages before starting the process:

| Software/Package | Version | Purpose |
|-----------------|---------|---------|
| Visual Studio 2026 | 18.0 or later | Development IDE with Blazor workload |
| .NET SDK | net10.0 or compatible | Runtime and build tools |
| HotChocolate.AspNetCore | 15.1 or later | GraphQL server framework |
| Syncfusion.Blazor.Gantt | {{site.blazorversion}} | Gantt Chart component |
| Syncfusion.Blazor.Themes | {{site.blazorversion}} | Styling for Gantt Chart |

## Setting Up the GraphQL Backend

### Step 1: Install Required NuGet Packages

Before installing NuGet packages, create a new **Blazor Web App** using the default template. The template automatically generates essential starter files such as **Program.cs, appsettings.json, launchSettings.json, the wwwroot folder, and the Components folder**.

For this guide, a Blazor application named **Gantt_GraphQLAdaptor** is used.

**Required Packages:**

- **HotChocolate.AspNetCore** (version 15.1 or later) – GraphQL server framework
- **Syncfusion.Blazor.Gantt** (version {{site.blazorversion}}) – Gantt Chart component
- **Syncfusion.Blazor.Themes** (version {{site.blazorversion}}) – Styling for the Gantt Chart

**Method 1: Using Package Manager Console**

1. Open Visual Studio.
2. Navigate to **Tools → NuGet Package Manager → Package Manager Console**.
3. Run the following commands:

```powershell
Install-Package HotChocolate.AspNetCore -Version 15.1.12
Install-Package Syncfusion.Blazor.Gantt -Version {{site.blazorversion}}
Install-Package Syncfusion.Blazor.Themes -Version {{site.blazorversion}}
```

**Method 2: Using NuGet Package Manager UI**

1. Open **Visual Studio → Tools → NuGet Package Manager → Manage NuGet Packages for Solution**.
2. Search for and install each package individually:
   - **HotChocolate.AspNetCore** (version 15.1.12 or later)
   - **[Syncfusion.Blazor.Gantt](https://www.nuget.org/packages/Syncfusion.Blazor.Gantt/)** (version {{site.blazorversion}})
   - **[Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)** (version {{site.blazorversion}})

All required packages are now installed.

---

### Step 2: Register Hot Chocolate Services in Program.cs

The `Program.cs` file configures and registers the GraphQL services.

**Instructions:**

1. Open the `Program.cs` file at the project root.
2. Add the following code after `var builder = WebApplication.CreateBuilder(args);`:

```csharp
[Program.cs]

using Gantt_GraphQLAdaptor.Models;

var builder = WebApplication.CreateBuilder(args);

// Register Hot Chocolate GraphQL services
builder.Services
    .AddGraphQLServer()
    .AddQueryType<GraphQLQuery>()
    .AddMutationType<GraphQLMutation>();

var app = builder.Build();

// Map the GraphQL endpoint (default: /graphql)
app.MapGraphQL();

app.Run();
```

**Details:**

- `AddGraphQLServer()` – Initializes the Hot Chocolate GraphQL server.
- `AddQueryType<GraphQLQuery>()` – Registers query resolvers for read operations.
- `AddMutationType<GraphQLMutation>()` – Registers mutation resolvers for write operations.
- `MapGraphQL()` – Exposes the GraphQL endpoint at `/graphql`.

The GraphQL backend is now configured and ready. The GraphQL endpoint is accessible at `https://localhost:xxxx/graphql`.

---

### Step 3: Configure Launch Settings (Port Configuration)

The **launchSettings.json** file controls the port number where the application runs. This file is located in the **Properties** folder at **Properties/launchSettings.json**.

**Instructions to Change the Port:**

1. Open the **Properties** folder in the project root.
2. Double-click **launchSettings.json** to open the file.
3. Locate the `https` profile section:

```json
"https": {
  "commandName": "Project",
  "dotnetRunMessages": true,
  "launchBrowser": true,
  "applicationUrl": "https://localhost:7001;http://localhost:5001",
  "environmentVariables": {
    "ASPNETCORE_ENVIRONMENT": "Development"
  }
}
```

4. Modify the `applicationUrl` property to change the port numbers:
   - `https://localhost:7001` – HTTPS port (change 7001 to desired port)
   - `http://localhost:5001` – HTTP port (change 5001 to desired port)

5. Example configuration with custom ports:

```json
"https": {
  "commandName": "Project",
  "dotnetRunMessages": true,
  "launchBrowser": true,
  "applicationUrl": "https://localhost:5020;http://localhost:5021",
  "environmentVariables": {
    "ASPNETCORE_ENVIRONMENT": "Development"
  }
}
```

6. Save the file and restart the application for the changes to take effect.

**Important Notes:**

- Port numbers must be between 1024 and 65535.
- Avoid using ports already in use by other applications.
- The GraphQL endpoint will be accessible at the configured HTTPS URL (e.g., `https://localhost:5020/graphql`).

All configuration steps are now complete.

---

### Step 4: Create the Data Model

A data model represents the structure of data that the application stores. It defines the properties (fields) that make up a record. Each property corresponds to a column in the database table. The data model acts as the blueprint for how data is organized and accessed throughout the application.

In the context of a project task manager, the data model defines what information is stored for each task entry. Properties include the task identifier, task name, schedule dates, duration, progress, parent reference (for hierarchy).

**Instructions**:

1. Create a new folder named **Models** in the project root directory.
2. Inside the **Models** folder, create a new file named **TaskData.cs**.
3. Define the **TaskData** class with the following code:

**File Location:** `Models/TaskData.cs`

```csharp
using System.Text.Json.Serialization;

namespace Gantt_GraphQLAdaptor.Models
{
    public class TaskData
    {
        /// <summary>
        /// Static in-memory store for task records.
        /// </summary>
        private static List<TaskData> _taskStore = null!;

        public static List<TaskData> GetAllRecords()
        {
            if (_taskStore == null)
                InitializeStore();
            return _taskStore!;
        }

        private static void InitializeStore()
        {
            _taskStore = new List<TaskData>
            {
                new TaskData { TaskId = 1, TaskName = "Project Initiation", StartDate = new DateTime(2025, 1, 6),  EndDate = new DateTime(2025, 1, 17), Duration = 10, Progress = 100,   ParentId = null},
                new TaskData { TaskId = 2, TaskName = "Define Requirements", StartDate = new DateTime(2025, 1, 6), EndDate = new DateTime(2025, 1, 10), Duration = 5, Progress = 100, ParentId = 1 },
                new TaskData { TaskId = 3, TaskName = "System Design",       StartDate = new DateTime(2025, 1, 20), EndDate = new DateTime(2025, 2, 7), Duration = 15, Progress = 90, ParentId = null }
                // Additional seed records can be added here.
            };
        }

        [JsonPropertyName("taskId")]
        public int TaskId { get; set; }

        [JsonPropertyName("taskName")]
        public string? TaskName { get; set; }

        [JsonPropertyName("startDate")]
        public DateTime? StartDate { get; set; }

        [JsonPropertyName("endDate")]
        public DateTime? EndDate { get; set; }

        [JsonPropertyName("duration")]
        public int? Duration { get; set; }

        [JsonPropertyName("progress")]
        public int Progress { get; set; }

        [JsonPropertyName("parentId")]
        public int? ParentId { get; set; }
    }
}
```

**Property Mapping Reference**

The following table shows how C# properties map to GraphQL field names and Gantt task fields:

| Property Name (C#) | GraphQL Field Name | Gantt Task Field | Data Type | Purpose |
|---|---|---|---|---|
| `TaskId` | `taskId` | `Id` | `int` | Unique identifier for the task (primary key) |
| `TaskName` | `taskName` | `Name` | `string` | Display name of the task |
| `StartDate` | `startDate` | `StartDate` | `DateTime?` | Scheduled start date of the task |
| `EndDate` | `endDate` | `EndDate` | `DateTime?` | Scheduled end date of the task |
| `Duration` | `duration` | `Duration` | `int?` | Duration in days |
| `Progress` | `progress` | `Progress` | `int` | Completion percentage of the task |
| `ParentId` | `parentId` | `ParentID` | `int?` | Identifier of the parent task (builds hierarchy) |

**Important Convention: Camel Case Conversion**

Hot Chocolate automatically converts C# property names (**PascalCase**) to GraphQL field names (**camelCase**). This convention ensures consistent naming in the GraphQL schema:

- C# Property: `TaskName` → GraphQL Field: `taskName`
- C# Property: `StartDate` → GraphQL Field: `startDate`
- C# Property: `ParentId` → GraphQL Field: `parentId`

The task data model has been successfully created.

---

### Step 5: GraphQL Query Resolver

A query resolver is a method in the backend that handles read requests from the client. When the Blazor Gantt Chart needs to fetch data, it sends a GraphQL query to the server. The query resolver receives this request, processes it, and returns the appropriate data. Query resolvers do not modify data; they only retrieve and return it.

In simple terms, a **GraphQL query** asks a question, and a **resolver** is the one who answers it.

**Instructions:**

1. Inside the **Models** folder, create a new file named **GraphQLQuery.cs**.
2. Add the following code to define the query resolver:

```csharp
[Models/GraphQLQuery.cs]

using Gantt_GraphQLAdaptor.Models;

namespace Gantt_GraphQLAdaptor.Models;

public class GraphQLQuery
{
    /// <summary>
    /// Query resolver for fetching task data with data operations support.
    /// Hot Chocolate maps the method name GetTaskData to taskData in the GraphQL schema.
    /// </summary>
    public TaskDataResponse GetTaskData(DataManagerRequestInput dataManager)
    {
        List<TaskData> dataSource = TaskData.GetAllRecords();

        // 1. Search
        if (dataManager.Search != null && dataManager.Search.Count > 0)
        {
            foreach (var searchFilter in dataManager.Search)
            {
                dataSource = dataSource.Where(task =>
                    searchFilter.Fields.Any(field =>
                        task.GetType().GetProperty(field)?.GetValue(task)?.ToString()
                            .IndexOf(searchFilter.Key, StringComparison.OrdinalIgnoreCase) >= 0
                    )
                ).ToList();
            }
        }

        // 2. Sorting
        if (dataManager.Sorted != null && dataManager.Sorted.Count > 0)
        {
            foreach (var sort in dataManager.Sorted)
            {
                var property = typeof(TaskData).GetProperty(sort.Name);
                if (property != null)
                {
                    dataSource = sort.Direction?.ToLower() == "descending"
                        ? dataSource.OrderByDescending(x => property.GetValue(x)).ToList()
                        : dataSource.OrderBy(x => property.GetValue(x)).ToList();
                }
            }
        }

        // 3. Filtering
        if (dataManager.Where != null && dataManager.Where.Count > 0)
        {
            foreach (var filter in dataManager.Where)
            {
                dataSource = dataSource
                    .Where(task => EvaluateFilterGroup(task, filter.Predicates ?? new List<WhereFilter>()))
                    .ToList();
            }
        }

        int totalRecords = dataSource.Count;

        return new TaskDataResponse { Count = totalRecords, Result = dataSource };
    }

    private bool EvaluateFilterGroup(TaskData task, List<WhereFilter> predicates)
    {
        bool match = true;
        foreach (var predicate in predicates)
        {
            if (predicate.Predicates != null && predicate.Predicates.Count > 0)
            {
                bool nestedMatch = false;
                foreach (var nested in predicate.Predicates)
                    nestedMatch |= EvaluateSinglePredicate(task, nested);
                match &= nestedMatch;
            }
            else
            {
                match &= EvaluateSinglePredicate(task, predicate);
            }
        }
        return match;
    }

    private bool EvaluateSinglePredicate(TaskData task, WhereFilter predicate)
    {
        if (string.IsNullOrEmpty(predicate.Field) || string.IsNullOrEmpty(predicate.Operator))
            return false;

        var property = task.GetType().GetProperty(predicate.Field);
        if (property == null) return false;

        var propertyValue = property.GetValue(task);
        if (propertyValue == null) return false;

        var fieldValue = predicate.Value;
        var op = predicate.Operator.ToLower();

        return op switch
        {
            "equal" => propertyValue.ToString()!.Equals(fieldValue?.ToString(), StringComparison.OrdinalIgnoreCase),
            "notequal" => !propertyValue.ToString()!.Equals(fieldValue?.ToString(), StringComparison.OrdinalIgnoreCase),
            "contains" => propertyValue.ToString()!.Contains(fieldValue?.ToString() ?? "", StringComparison.OrdinalIgnoreCase),
            "startswith" => propertyValue.ToString()!.StartsWith(fieldValue?.ToString() ?? "", StringComparison.OrdinalIgnoreCase),
            "endswith" => propertyValue.ToString()!.EndsWith(fieldValue?.ToString() ?? "", StringComparison.OrdinalIgnoreCase),
            "greaterthan" => Convert.ToDouble(propertyValue) > Convert.ToDouble(fieldValue),
            "lessthan" => Convert.ToDouble(propertyValue) < Convert.ToDouble(fieldValue),
            "greaterthanorequal" => Convert.ToDouble(propertyValue) >= Convert.ToDouble(fieldValue),
            "lessthanorequal" => Convert.ToDouble(propertyValue) <= Convert.ToDouble(fieldValue),
            _ => false
        };
    }
}

/// <summary>
/// Response structure for query results. Must include Count (total records) and Result (current page).
/// </summary>
public class TaskDataResponse
{
    public int Count { get; set; }
    public List<TaskData> Result { get; set; } = new();
}
```

**Details:**

- The `GetTaskData` method receives `DataManagerRequestInput`, which contains filter, sort, search parameters from the Gantt Chart.
- Hot Chocolate automatically converts the method name `GetTaskData` to camelCase: `taskData` in the GraphQL schema.

The query resolver has been created successfully.

---

### Step 6: Create the DataManagerRequestInput Class

A **DataManagerRequestInput** class is a GraphQL input type that represents all the parameters the [Blazor Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart) sends to the backend when requesting data. This class acts as a container for filtering, sorting, searching and other data operation parameters.

**Purpose**
When the Gantt Chart performs operations like sorting, filtering, or searching, it packages all these parameters into a `DataManagerRequestInput` object and sends it to the GraphQL backend. The backend then uses these parameters to fetch and return only the data the chart needs.

**Instructions**:

1. Inside the **Models** folder, create a new file named **DataManagerRequestInput.cs**.
2. Define the **DataManagerRequestInput** class and supporting classes with the following code:

```csharp
[Models/DataManagerRequestInput.cs]

using HotChocolate;
using HotChocolate.Types;

namespace Gantt_GraphQLAdaptor.Models;

/// <summary>
/// Represents the input structure for data manager requests from the Blazor Gantt Chart.
/// Contains all parameters needed for data operations like filtering, sorting and searching.
/// </summary>
public class DataManagerRequestInput
{
    [GraphQLName("Skip")]
    public int Skip { get; set; }

    [GraphQLName("Take")]
    public int Take { get; set; }

    [GraphQLName("RequiresCounts")]
    public bool RequiresCounts { get; set; } = false;

    [GraphQLName("Params")]
    [GraphQLType(typeof(AnyType))]
    public IDictionary<string, object>? Params { get; set; }

    [GraphQLName("Aggregates")]
    [GraphQLType(typeof(AnyType))]
    public List<Aggregate>? Aggregates { get; set; }

    [GraphQLName("Search")]
    public List<SearchFilter>? Search { get; set; }

    [GraphQLName("Sorted")]
    public List<Sort>? Sorted { get; set; }

    [GraphQLName("Where")]
    [GraphQLType(typeof(AnyType))]
    public List<WhereFilter>? Where { get; set; }

    [GraphQLName("Group")]
    public List<string>? Group { get; set; }

    [GraphQLName("antiForgery")]
    public string? antiForgery { get; set; }

    [GraphQLName("Table")]
    public string? Table { get; set; }

    [GraphQLName("IdMapping")]
    public string? IdMapping { get; set; }

    [GraphQLName("Select")]
    public List<string>? Select { get; set; }

    [GraphQLName("Expand")]
    public List<string>? Expand { get; set; }

    [GraphQLName("Distinct")]
    public List<string>? Distinct { get; set; }

    [GraphQLName("ServerSideGroup")]
    public bool? ServerSideGroup { get; set; }

    [GraphQLName("LazyLoad")]
    public bool? LazyLoad { get; set; }

    [GraphQLName("LazyExpandAllGroup")]
    public bool? LazyExpandAllGroup { get; set; }
}

/// <summary>
/// Represents an aggregate operation (Sum, Average, Min, Max, Count).
/// </summary>
public class Aggregate
{
    [GraphQLName("Field")]
    public string? Field { get; set; }

    [GraphQLName("Type")]
    public string? Type { get; set; }
}

/// <summary>
/// Represents search criteria for finding records.
/// Allows searching across multiple fields with specified operators.
/// </summary>
public class SearchFilter
{
    [GraphQLName("Fields")]
    public List<string>? Fields { get; set; }

    [GraphQLName("Key")]
    public string? Key { get; set; }

    [GraphQLName("Operator")]
    public string? Operator { get; set; }

    [GraphQLName("IgnoreCase")]
    public bool IgnoreCase { get; set; }

    [GraphQLName("IgnoreAccent")]
    public bool IgnoreAccent { get; set; }
}

/// <summary>
/// Represents sorting instructions for ordering records.
/// </summary>
public class Sort
{
    [GraphQLName("Name")]
    public string? Name { get; set; }

    [GraphQLName("Direction")]
    public string? Direction { get; set; }

    [GraphQLName("Comparer")]
    [GraphQLType(typeof(AnyType))]
    public object? Comparer { get; set; }
}

/// <summary>
/// Represents a filter condition for narrowing down records.
/// Supports complex nested conditions (AND/OR logic) for advanced filtering.
/// </summary>
public class WhereFilter
{
    [GraphQLName("Field")]
    public string? Field { get; set; }

    [GraphQLName("IgnoreCase")]
    public bool? IgnoreCase { get; set; }

    [GraphQLName("IgnoreAccent")]
    public bool? IgnoreAccent { get; set; }

    [GraphQLName("IsComplex")]
    public bool? IsComplex { get; set; }

    [GraphQLName("Operator")]
    public string? Operator { get; set; }

    [GraphQLName("Condition")]
    public string? Condition { get; set; }

    [GraphQLName("Value")]
    [GraphQLType(typeof(AnyType))]
    public object? Value { get; set; }

    [GraphQLName("predicates")]
    public List<WhereFilter>? Predicates { get; set; }
}
```

**DataManagerRequestInput Properties Used by the Gantt Chart:**

| Property | Purpose | Type | Example |
|----------|---------|------|---------|
| `Take` | Number of records to retrieve per page | `int` | `20` (fetch next 20 records) |
| `RequiresCounts` | Whether the total record count should be returned | `bool` | `true` |
| `Search` | Search filter configuration | `List<SearchFilter>` | Search term and target fields |
| `Where` | Filter conditions for column filtering | `List<WhereFilter>` | Field name, operator, and value |
| `Sorted` | Sort specifications for ordering records | `List<Sort>` | Field name and direction (asc/desc) |
| `Group` | Grouping configuration | `List<string>` | Field names to group by |

**Key Attributes Explained**

- `[GraphQLName]` – Maps C# property names to GraphQL schema field names. Hot Chocolate automatically converts PascalCase to camelCase. For example, **RequiresCounts → requiresCounts**.
- `[GraphQLType(typeof(AnyType))]` – Allows flexible typing for complex nested structures (such as `Params`, `Where.Value`, and `Sort.Comparer`) that can contain various data types.

---

### Step 7: GraphQL Mutation Resolvers

A **GraphQL mutation resolver** is a method in the backend that handles write requests (data modifications) from the client. While queries only read data, mutations create, update, or delete records. When the Blazor Gantt Chart performs add, edit, delete, or taskbar-drag operations, it sends a GraphQL mutation to the server. The mutation resolver receives this request, processes it, and persists the changes to the data source.

In simple terms, a **GraphQL mutation** asks for a change, and a **resolver** is the one who makes it.

**Instructions:**
1. Inside the **Models** folder, create a new file named **GraphQLMutation.cs**.
2. Define the **GraphQLMutation** class with the following code:

```csharp
[Models/GraphQLMutation.cs]

using HotChocolate.Types;

namespace Gantt_GraphQLAdaptor.Models
{
    public class GraphQLMutation
    {
        public TaskData CreateTask(TaskData record, int index, string action,
            [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters)
        {
            var tasks = TaskData.GetAllRecords();

            if (record.TaskId == 0)
                record.TaskId = tasks.Count > 0 ? tasks.Max(t => t.TaskId) + 1 : 1;

            if (index >= 0 && index <= tasks.Count)
                tasks.Insert(index, record);
            else
                tasks.Add(record);

            return record;
        }

        public TaskData UpdateTask(TaskData record, string action, string primaryColumnName,
            string primaryColumnValue,
            [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters)
        {
            var tasks = TaskData.GetAllRecords();
            var existing = tasks.FirstOrDefault(t => t.TaskId.ToString() == primaryColumnValue);
            if (existing != null)
                UpdateProperties(existing, record);
            return existing!;
        }

        public bool DeleteTask(string primaryColumnValue,
            [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters)
        {
            var tasks = TaskData.GetAllRecords();
            var task = tasks.FirstOrDefault(t => t.TaskId.ToString() == primaryColumnValue);
            if (task != null) { tasks.Remove(task); return true; }
            return false;
        }

        public List<TaskData> BatchUpdate(List<TaskData>? changed, List<TaskData>? added,
            List<TaskData>? deleted, string action, string primaryColumnName,
            [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters,
            int? dropIndex)
        {
            var tasks = TaskData.GetAllRecords();

            if (changed != null)
                foreach (var item in changed)
                {
                    var existing = tasks.FirstOrDefault(t => t.TaskId == item.TaskId);
                    if (existing != null) UpdateProperties(existing, item);
                }

            if (added != null)
                foreach (var item in added)
                {
                    if (item.TaskId == 0)
                        item.TaskId = tasks.Count > 0 ? tasks.Max(t => t.TaskId) + 1 : 1;
                    if (dropIndex.HasValue && dropIndex >= 0 && dropIndex <= tasks.Count)
                        tasks.Insert(dropIndex.Value, item);
                    else
                        tasks.Add(item);
                }

            if (deleted != null)
                foreach (var item in deleted)
                {
                    var toRemove = tasks.FirstOrDefault(t => t.TaskId == item.TaskId);
                    if (toRemove != null) tasks.Remove(toRemove);
                }

            return tasks;
        }

        private void UpdateProperties(TaskData target, TaskData source)
        {
            target.TaskName   = source.TaskName;
            target.StartDate  = source.StartDate;
            target.EndDate    = source.EndDate;
            target.Duration   = source.Duration;
            target.Progress   = source.Progress;
            target.ParentId   = source.ParentId;
        }
    }
}
```

A mutation resolver is a C# method decorated with GraphQL attributes that:

- **Receives input parameters** from the Gantt Chart (record data, primary keys, indices, drop positions).
- **Processes the operation** (validation, ID generation, data modification).
- **Persists changes** to the data source (database, file, memory).
- **Returns results** to the client (modified record or list of records).

The GraphQL Mutation class has been successfully created and is ready to handle all data modification operations from the Blazor Gantt Chart.

---

## Integrating Blazor Gantt Chart

### Step 1: Install and Configure Blazor Gantt Chart Components with GraphQL

Syncfusion is a library that provides pre-built UI components like the Gantt Chart, which is used to display hierarchical project tasks with a timeline view.

**Instructions:**

* The **Syncfusion.Blazor.Gantt** package was installed in **Step 1** of the previous heading.
* Import the required namespaces in the `Components/_Imports.razor` file:

```csharp
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Data
@using Gantt_GraphQLAdaptor.Models
```

* Add the stylesheet and scripts in the `Components/App.razor` file. Find the `<head>` section and add:

```html
<!-- Blazor Stylesheet -->
<link href="_content/Syncfusion.Blazor.Themes/tailwind3.css" rel="stylesheet" />

<!-- Blazor Scripts -->
<script src="_content/Syncfusion.Blazor.Gantt/scripts/sf-gantt.min.js" type="text/javascript"></script>
```

For this project, the tailwind3 theme is used. A different theme can be selected or the existing theme can be customized based on project requirements. Refer to the [Blazor Components Appearance](https://blazor.syncfusion.com/documentation/appearance/themes) documentation to learn more about theming and customization options.

Blazor components are now configured and ready to use. For additional guidance, refer to the Gantt Chart component's [getting-started](https://blazor.syncfusion.com/documentation/gantt-chart/getting-started-with-web-app) documentation.

---

### Step 2: Update the Blazor Gantt Chart

The `Home.razor` component will display the project task data in a Blazor Gantt Chart with sort, filter, search, and CRUD capabilities. The `ParentId` field on the model is mapped through `GanttTaskFields.ParentID` to render the task hierarchy in the grid, tree, and timeline.

**Instructions:**

1. Open the file named `Home.razor` in the `Components/Pages` folder.
2. Add the following code to create a basic Gantt Chart connected to the GraphQL backend:

```cshtml
@page "/"

<SfGantt TValue="TaskData"
         Height="550px"
         Width="100%"
         TreeColumnIndex="1"
         AllowSorting="true"
         AllowFiltering="true"
         AllowReordering="true"
         AllowResizing="true"
         Toolbar="@ToolbarItems">

    <SfDataManager Url="http://localhost:5020/graphql"
                   GraphQLAdaptorOptions="@adaptorOptions"
                   Adaptor="Adaptors.GraphQLAdaptor">
    </SfDataManager>

    <GanttTaskFields Id="TaskId"
                     Name="TaskName"
                     StartDate="StartDate"
                     EndDate="EndDate"
                     Duration="Duration"
                     Progress="Progress"
                     ParentID="ParentId">
    </GanttTaskFields>

    <GanttEditSettings AllowAdding="true"
                       AllowEditing="true"
                       AllowDeleting="true"
                       AllowTaskbarEditing="true"
                       Mode="Syncfusion.Blazor.Gantt.EditMode.Auto">
    </GanttEditSettings>

    <GanttColumns>
        <GanttColumn Field="TaskId"    HeaderText="ID"         Width="70"></GanttColumn>
        <GanttColumn Field="TaskName"  HeaderText="Task Name"  Width="250"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date" Width="130"></GanttColumn>
        <GanttColumn Field="EndDate"   HeaderText="End Date"   Width="130"></GanttColumn>
        <GanttColumn Field="Duration"  HeaderText="Duration"   Width="100"></GanttColumn>
        <GanttColumn Field="Progress"  HeaderText="Progress"   Width="120"></GanttColumn>
    </GanttColumns>

    <GanttSplitterSettings Position="40%"></GanttSplitterSettings>
</SfGantt>

@code {
    private List<object> ToolbarItems = new() { "Add", "Edit", "Delete", "Update", "Cancel",
                                                  "ExpandAll", "CollapseAll", "Search" };

    // GraphQLAdaptorOptions will be added in the next step
}
```

**Component Explanation:**

- **`<SfGantt>`** – The Gantt Chart component that displays hierarchical tasks with a timeline.
- **`<SfDataManager>`** – Connects the Gantt Chart to the GraphQL backend through the GraphQL adaptor options.
- **`<GanttTaskFields>`** – Maps model fields to Gantt properties: `Id`, `Name`, `StartDate`, `EndDate`, `Duration`, `Progress`, and `ParentID` (for hierarchy).
- **`<GanttEditSettings>`** – Enables add, edit, delete, and taskbar editing (`AllowTaskbarEditing="true"` is Gantt-specific; it lets the user drag and resize taskbars, which calls the `UpdateTask` mutation).
- **`<GanttColumns>`** – Defines the columns shown in the grid section of the Gantt Chart.
- **`<GanttSplitterSettings>`** – Controls the position of the splitter between the grid and the timeline.
- **`Toolbar="@ToolbarItems"`** – Provides toolbar buttons for Add, Edit, Delete, ExpandAll, CollapseAll, and Search actions.

The `SfDataManager` component connects the Gantt Chart to the GraphQL backend using the adaptor options configured below:

```cshtml
<SfDataManager Url="http://localhost:5020/graphql"
               GraphQLAdaptorOptions="@adaptorOptions"
               Adaptor="Adaptors.GraphQLAdaptor">
</SfDataManager>
```

**Component Attributes Explained:**

| Attribute | Purpose | Value |
|-----------|---------|-------|
| `Url` | GraphQL endpoint location | `http://localhost:5020/graphql` (must match backend port) |
| `GraphQLAdaptorOptions` | References the adaptor configuration object | `@adaptorOptions` (defined in next step) |
| `Adaptor` | Specifies adaptor type to use | `Adaptors.GraphQLAdaptor` (tells Syncfusion to use the GraphQL adaptor) |

**Important Notes:**

- The `Url` must match the port configured in `launchSettings.json`. If the backend runs on port 5020, then the URL must be `https://localhost:5020/graphql`.
- The `/graphql` path is set by `app.MapGraphQL()` in `Program.cs`.

---

### Step 3: Configure the GraphQL Adaptor and Data Binding

The GraphQL adaptor is a bridge that connects the Blazor Gantt Chart with the GraphQL backend. The adaptor translates Gantt operations (sorting, filtering, searching and CRUD) into GraphQL queries and mutations. When the user interacts with the chart, the adaptor automatically sends the appropriate GraphQL request to the backend, receives the response, and updates the chart display.

**What is a GraphQL Adaptor?**

An adaptor is a translator between two different systems. The GraphQL adaptor specifically:

- Receives interaction events generated by the Gantt Chart, including Add, Edit, Delete, taskbar drag, and toolbar actions, as well as sorting and filtering operations.
- Converts these actions into GraphQL query or mutation syntax.
- Sends the **GraphQL request** to the backend **GraphQL endpoint**.
- Receives the response data from the backend.
- Formats the response back into a structure the Gantt Chart understands.
- Updates the chart display (grid, tree, and timeline) with the new data.

The adaptor enables bidirectional communication between the frontend (Gantt Chart) and backend (GraphQL server).

---

**GraphQL Adaptor Configuration**

The `@code` block in `Home.razor` contains C# code that configures how the adaptor behaves. This configuration is critical because it defines:

- Which GraphQL query to use for reading data.
- Which GraphQL mutations to use for creating, updating, deleting, and batch-saving data.
- The name of the resolver that returns the paged task data.

**Instructions:**

1. Open the `Home.razor` file located in `Components/Pages/Home.razor`.
2. Scroll to the `@code` block at the bottom of the file.
3. Add the following complete configuration:

```csharp
@code {
    private List<object> ToolbarItems = new() { "Add", "Edit", "Delete", "Update", "Cancel",
                                                  "ExpandAll", "CollapseAll", "Search" };

    private GraphQLAdaptorOptions adaptorOptions = new GraphQLAdaptorOptions
    {
        Query = @"query taskData($dataManager: DataManagerRequestInput!) {
                    taskData(dataManager: $dataManager) {
                        result {
                            taskId
                            taskName
                            startDate
                            endDate
                            duration
                            progress
                            parentId
                        }
                        count
                    }
                }",
        ResolverName = "taskData",
        Mutation = new Syncfusion.Blazor.Data.GraphQLMutation
        {
            Insert = @"mutation create($record: TaskDataInput!, $index: Int!, $action: String!, $additionalParameters: Any) {
                createTask(record: $record, index: $index, action: $action, additionalParameters: $additionalParameters) {
                    taskId taskName startDate endDate duration progress parentId
                }
            }",
            Update = @"mutation update($record: TaskDataInput!, $action: String!, $primaryColumnName: String!, $primaryColumnValue: String!, $additionalParameters: Any) {
                updateTask(record: $record, action: $action, primaryColumnName: $primaryColumnName, primaryColumnValue: $primaryColumnValue, additionalParameters: $additionalParameters) {
                    taskId taskName startDate endDate duration progress parentId
                }
            }",
            Delete = @"mutation delete($primaryColumnValue: String!, $additionalParameters: Any) {
                deleteTask(primaryColumnValue: $primaryColumnValue, additionalParameters: $additionalParameters)
            }",
            Batch = @"mutation batch($changed: [TaskDataInput!], $added: [TaskDataInput!], $deleted: [TaskDataInput!], $action: String!, $primaryColumnName: String!, $additionalParameters: Any, $dropIndex: Int) {
                batchUpdate(changed: $changed, added: $added, deleted: $deleted, action: $action, primaryColumnName: $primaryColumnName, additionalParameters: $additionalParameters, dropIndex: $dropIndex) {
                    taskId taskName startDate endDate duration progress parentId
                }
            }"
        }
    };
}
```

**GraphQL Query Structure Explained in Detail**

The `Query` property is critical for understanding how data flows. Each part is described below:

```
query taskData($dataManager: DataManagerRequestInput!) {}
```

- `query` – GraphQL keyword indicating a read operation.
- `taskData` – Name of the query. **Must match the resolver name in camelCase** (the backend method `GetTaskData` is mapped to `taskData` by Hot Chocolate).
- `($dataManager: DataManagerRequestInput!)` – Required parameter declaration.
  - `$dataManager` – Variable name (referenced as `$dataManager` throughout the query).
  - `: DataManagerRequestInput` – Type specification.
  - `!` – The parameter is **required** (not optional).

```
taskData(dataManager: $dataManager) {}
```

- `taskData(...)` – Calls the resolver method on the backend.
- `dataManager: $dataManager` – Passes the variable to the resolver. The resolver receives this object and uses it to apply filters, sorts, searches.

```
count
result {
    taskId
    taskName
    ...
}
```

- `count` – Returns the total number of records.
- `result` – Contains the array of task records.
  - Each field must exist in the `TaskData` class.
  - Only the requested fields are returned (no over-fetching).

**Response Structure Example**

When the backend executes the query, it returns a **JSON response** in this structure:

```json
{
  "data": {
    "taskData": {
      "count": 22,
      "result": [
        {
          "taskId": 1,
          "taskName": "Project Initiation",
          "startDate": "2025-01-06T00:00:00",
          "endDate": "2025-01-17T00:00:00",
          "duration": 10,
          "progress": 100,
          "parentId": null,
        },
        {
          "taskId": 2,
          "taskName": "Define Requirements",
          "startDate": "2025-01-06T00:00:00",
          "endDate": "2025-01-10T00:00:00",
          "duration": 5,
          "progress": 100,
          "parentId": 1,
        }
      ]
    }
  }
}
```

**Response Structure Explanation:**

| Part | Purpose | Example |
|------|---------|---------|
| `data` | Root object containing the query result | Always present in a successful response |
| `taskData` | Matches the query name (camelCase) | Contains `count` and `result` |
| `count` | Total number of records available | `22` (in this example) |
| `result` | Array of `TaskData` objects | `[ {...}, {...} ]` |
| Each field in `result` | Matches GraphQL query field names | Field values from the data source |

---

### Step 4: Running the Application

**Build the Application**

1. Open the terminal or Package Manager Console.
2. Navigate to the project directory.
3. Run the following command:

```powershell
dotnet build
```

**Run the Application**

Execute the following command:

```powershell
dotnet run
```

**Access the Application**

1. Open a web browser.
2. Navigate to `https://localhost:5020` (or the port shown in the terminal).
3. The Project Task Manager is now running and ready to use.

The Gantt Chart will display the project schedule and is ready to perform server-driven search, sort, filter, and CRUD operations through the GraphQL endpoint.

---

## How Data Operations Work with the GraphQL Adaptor

The Gantt Chart passes all data operation parameters (search, sort, filter) inside the `dataManager` input variable. The backend resolver reads this object and applies the operations in the same order: **search → sort → filter**.

### Searching

When the **Search** toolbar button is used to enter a keyword, the Gantt Chart sends a `Search` array with the target fields and key. The backend `GetTaskData` resolver iterates over the configured fields and applies a case-insensitive `IndexOf` check, then continues to sort, filter.

**Variables Sent with the Request:**

```json
{
  "dataManager": {
    "Search": [
      {
        "Fields": ["TaskName"],
        "Key": "design",
        "Operator": "contains",
        "IgnoreCase": true,
        "IgnoreAccent": true
      }
    ],
    "Skip": 0,
    "Take": 20,
    "RequiresCounts": true
  }
}
```

### Sorting

When a column header is selected for sorting, the Gantt Chart sends a `Sorted` array. The backend resolver reflectsively reads the property and applies `OrderBy` / `OrderByDescending` based on the `Direction`. Multiple sort conditions can be applied sequentially by holding the **Ctrl** key and selecting additional column headers.

**Variables Sent with the Request:**

```json
{
  "dataManager": {
    "Sorted": [
      { "Name": "StartDate", "Direction": "Ascending" },
      { "Name": "Progress",  "Direction": "Descending" }
    ],
    "Skip": 0,
    "Take": 20,
    "RequiresCounts": true
  }
}
```

### Filtering

Filtering is handled by the `Where` array. The backend resolver supports the standard operators (`equal`, `notequal`, `contains`, `startswith`, `endswith`, `greaterthan`, `lessthan`, `greaterthanorequal`, `lessthanorequal`) and combines nested predicates using **OR**, with top-level predicates combined using **AND**.

**Supported Filter Operators:**

| Operator | Purpose | Example |
|----------|---------|---------|
| `equal` | Exact match | `Progress equals "High"` |
| `notequal` | Not equal to value | `Progress notEqual "Completed"` |
| `contains` | Contains substring (case-insensitive) | `TaskName contains "design"` |
| `startswith` | Starts with value | `TaskName startsWith "Alice"` |
| `endswith` | Ends with value | `TaskName endsWith "Progress"` |
| `greaterthan` | Greater than numeric value | `Progress > 50` |
| `lessthan` | Less than numeric value | `Duration < 10` |
| `greaterthanorequal` | Greater than or equal | `Progress >= 75` |
| `lessthanorequal` | Less than or equal | `Duration <= 5` |

**Variables Sent with the Request:**

```json
{
  "dataManager": {
    "Where": [
      {
        "Condition": "and",
        "Predicates": [
          {
            "Operator": "or",
            "Predicates": [
              { "Field": "TaskId", "Value": "High",     "Operator": "equal" },
              { "Field": "TaskName", "Value": "Critical", "Operator": "equal" }
            ]
          }
        ]
      }
    ],
    "Skip": 0,
    "Take": 20,
    "RequiresCounts": true
  }
}
```

**Filter Logic with Multiple Checkbox Selections:**

- Top-level predicates are combined with **AND** logic.
- Nested predicates within a field are combined with **OR** logic.
- This allows expressions like: `(Progress = "100" OR "50")`.


**Backend Processing Order:**

1. **Search** – Filter records by search keywords.
2. **Sort** – Order records by the sort descriptors.
3. **Filter** – Apply column filters.

---

## Perform CRUD Operations

The Gantt Chart performs Create, Read, Update, and Delete operations through the four configured mutations: `Insert`, `Update`, `Delete`, and `Batch`. Unlike data operations (search/sort/filter) which travel through `DataManagerRequestInput`, CRUD operations pass values directly to the corresponding GraphQL mutation.

Enable CRUD on the Gantt Chart by setting `AllowAdding`, `AllowEditing`, `AllowDeleting`, and `AllowTaskbarEditing` to `true` in `<GanttEditSettings>` (as shown in **Step 2**). Toolbar buttons such as **Add**, **Edit**, **Delete**, and **Update** are added through the `Toolbar="@ToolbarItems"` list.

### Insert

The Insert operation adds a new task to the project schedule. When the **Add** button in the toolbar is selected, the Gantt opens a dialog (or row, depending on `EditMode`) for entering the new task. After the form is submitted, the `createTask` mutation is called with the new record.

**GraphQL Mutation Request:**

```
mutation create($record: TaskDataInput!, $index: Int!, $action: String!, $additionalParameters: Any) {
  createTask(record: $record, index: $index, action: $action, additionalParameters: $additionalParameters) {
    taskId taskName startDate endDate duration progress parentId
  }
}
```

**Variables Sent with the Request:**

```json
{
  "record": {
    "taskId": 0,
    "taskName": "Code Review",
    "startDate": "2025-03-10T00:00:00Z",
    "endDate": "2025-03-12T00:00:00Z",
    "duration": 3,
    "progress": 0,
    "parentId": 9,
  },
  "index": -1,
  "action": "add",
  "additionalParameters": {}
}
```

**Parameter Explanation:**

| Parameter | Type | Purpose | Example |
|-----------|------|---------|---------|
| `record` | `TaskData` | The new task record object with all field values | Task data filled in the dialog |
| `index` | `int` | The position where the new task should be inserted (`-1` or count+1 means append) | `-1` for append |
| `action` | `string` | Type of action being performed (usually `"add"` for insert) | `"add"` |
| `additionalParameters` | `Any` | Extra context or custom parameters from the Gantt Chart | Empty object `{}` |

**Insert Operation Logic Breakdown:**

| Step | Purpose | Implementation |
|------|---------|----------------|
| **1. Receive Input** | Backend receives new task data from the client | `CreateTask` method parameter `record` contains all field values |
| **2. Generate ID** | Auto-generate a unique `TaskId` when zero | `tasks.Max(t => t.TaskId) + 1` |
| **3. Insert Record** | Insert at the requested index, or append if out of range | `tasks.Insert(index, record)` or `tasks.Add(record)` |
| **4. Return Created** | Send back the created record with the generated `TaskId` | Return the `record` object |

---

### Update

The Update operation modifies an existing task. The Gantt Chart calls the `updateTask` mutation for both cell/row/dialog edits and **taskbar drag operations** (when `AllowTaskbarEditing="true"`), because dragging a taskbar updates the underlying start date, end date, and duration.

**GraphQL Mutation Request:**

```
mutation update($record: TaskDataInput!, $action: String!, $primaryColumnName: String!, $primaryColumnValue: String!, $additionalParameters: Any) {
  updateTask(record: $record, action: $action, primaryColumnName: $primaryColumnName, primaryColumnValue: $primaryColumnValue, additionalParameters: $additionalParameters) {
    taskId taskName startDate endDate duration progress parentId
  }
}
```

**Variables Sent with the Request:**

```json
{
  "record": {
    "taskId": 10,
    "taskName": "Backend API",
    "startDate": "2025-02-10T00:00:00Z",
    "endDate": "2025-02-28T00:00:00Z",
    "duration": 15,
    "progress": 85,
    "parentId": 9
  },
  "action": "save",
  "primaryColumnName": "TaskId",
  "primaryColumnValue": "10",
  "additionalParameters": {}
}
```

**Parameter Explanation:**

| Parameter | Type | Purpose | Example |
|-----------|------|---------|---------|
| `record` | `TaskData` | The modified task record with updated field values | Task data after edit or taskbar drag |
| `action` | `string` | Type of action being performed (usually `"save"` for update) | `"save"` |
| `primaryColumnName` | `string` | Name of the primary key column used to identify the record | `"TaskId"` |
| `primaryColumnValue` | `string` | Value of the primary key used to locate the task | `"10"` |
| `additionalParameters` | `Any` | Extra context or custom parameters from the Gantt Chart | Empty object `{}` |

**Update Operation Logic Breakdown:**

| Step | Purpose | Implementation |
|------|---------|----------------|
| **1. Find Record** | Locate the existing task using the primary key value | `FirstOrDefault(t => t.TaskId.ToString() == primaryColumnValue)` |
| **2. Validate Existence** | Ensure the record exists before updating | `if (existing != null)` check |
| **3. Update Properties** | Replace all property values with modified data | `UpdateProperties(existing, record)` |
| **4. Preserve ID** | Keep the original `TaskId` unchanged | `TaskId` is not updated, only used for lookup |
| **5. Return Updated** | Send back the modified record with new values | Return the `existing` object |

**Taskbar Editing Note:** When a user drags or resizes a taskbar, the Gantt Chart calls `updateTask` with the new `StartDate`, `EndDate`, and `Duration`. The same `UpdateTask` mutation handles both dialog edits and timeline edits, so no extra wiring is required.

---

### Delete

The Delete operation removes a task from the schedule. When the **Delete** button is selected and the user confirms, the `deleteTask` mutation is sent with only the primary key value.

**GraphQL Mutation Request:**

```
mutation delete($primaryColumnValue: String!, $additionalParameters: Any) {
  deleteTask(primaryColumnValue: $primaryColumnValue, additionalParameters: $additionalParameters)
}
```

**Variables Sent with the Request:**

```json
{
  "primaryColumnValue": "10",
  "additionalParameters": {}
}
```

**Parameter Explanation:**

| Parameter | Type | Purpose | Example |
|-----------|------|---------|---------|
| `primaryColumnValue` | `string` | Value of the primary key identifying which task to delete | `"10"` |
| `additionalParameters` | `Any` | Extra context or custom parameters from the Gantt Chart | Empty object `{}` |

**Backend Response:**

```json
{
  "data": {
    "deleteTask": true
  }
}
```

If the task does not exist, the response is `false`.

---

### Batch Update

The Batch Update operation allows adding, updating, and deleting multiple tasks in a single request. The Gantt Chart uses this when several changes are accumulated before being sent to the server in one round trip (for example, when the user applies a series of edits and then clicks **Update**).

**GraphQL Mutation Request:**

```
mutation batch($changed: [TaskDataInput!], $added: [TaskDataInput!], $deleted: [TaskDataInput!], $action: String!, $primaryColumnName: String!, $additionalParameters: Any, $dropIndex: Int) {
  batchUpdate(changed: $changed, added: $added, deleted: $deleted, action: $action, primaryColumnName: $primaryColumnName, additionalParameters: $additionalParameters, dropIndex: $dropIndex) {
    taskId taskName startDate endDate duration progress parentId
  }
}
```

**Variables Sent with the Request:**

```json
{
  "changed": [
    {
      "taskId": 10,
      "taskName": "Backend API",
      "startDate": "2025-02-10T00:00:00Z",
      "endDate": "2025-02-28T00:00:00Z",
      "duration": 15,
      "progress": 80,
      "parentId": 9
    }
  ],
  "added": [
    {
      "taskId": 0,
      "taskName": "Code Review",
      "startDate": "2025-03-10T00:00:00Z",
      "endDate": "2025-03-12T00:00:00Z",
      "duration": 3,
      "progress": 0,
      "parentId": 9
    }
  ],
  "deleted": [
    { "taskId": 22 }
  ],
  "action": "batch",
  "primaryColumnName": "TaskId",
  "additionalParameters": {},
  "dropIndex": 0
}
```

**Parameter Explanation:**

| Parameter | Type | Purpose | Example |
|-----------|------|---------|---------|
| `changed` | `[TaskData]` | Records to update | Modified rows with existing `TaskId` |
| `added` | `[TaskData]` | Records to insert | New rows, `TaskId` optional |
| `deleted` | `[TaskData]` | Records to delete | Objects with `TaskId` only |
| `action` | `string` | Batch action indicator | `"batch"` |
| `primaryColumnName` | `string` | Name of primary key column | `"TaskId"` |
| `additionalParameters` | `Any` | Extra context from the chart | `{}` |
| `dropIndex` | `Int` | Target index for insertion or reorder | `0` |

---

## Summary

This guide demonstrates how to:

1. Install the required NuGet packages for Hot Chocolate and Syncfusion Blazor Gantt. [🔗](#step-1-install-required-nuget-packages)
2. Register Hot Chocolate services and expose the GraphQL endpoint. [🔗](#step-2-register-hot-chocolate-services-in-programcs)
3. Configure launch settings and ports for the GraphQL endpoint. [🔗](#step-3-configure-launch-settings-port-configuration)
4. Create the `TaskData` data model used across the GraphQL schema. [🔗](#step-4-create-the-data-model)
5. Implement a GraphQL query resolver to read data. [🔗](#step-5-graphql-query-resolver)
6. Create the `DataManagerRequestInput` input type to carry chart operations. [🔗](#step-6-create-the-datamanagerrequestinput-class)
7. Define GraphQL mutation resolvers for Create, Update, Delete, and Batch. [🔗](#step-7-graphql-mutation-resolvers)
8. Integrate the Blazor Gantt Chart and configure the GraphQL adaptor. [🔗](#step-2-update-the-blazor-gantt-chart)
9. Perform CRUD operations from the chart using GraphQL mutations. [🔗](#perform-crud-operations)

The application now provides a complete solution for managing project tasks with a modern [Blazor Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart) integrated with a Hot Chocolate GraphQL backend.

## Benefits of using the GraphQLAdaptor with the Gantt Chart

- **Predictable, typed schema** – The GraphQL schema describes every task field, mutation argument, and return type, so the Gantt can be wired to a strongly typed backend without ad-hoc JSON contracts.
- **Selective field loading** – A Gantt schedule often has 30+ task fields (dates, duration, progress, predecessors, resources, custom indicators). With GraphQL the client asks for only the columns it currently renders, which reduces payload size for large projects.
- **Server-driven operations** – Searching across thousands of tasks, applying complex filters (for example, "tasks in phase X with progress less than 50%"), and sorting by calculated fields all happen on the server and are passed through `DataManagerRequestInput`.
- **Hierarchical data with a flat payload** – The Gantt renders parent/child trees from a flat result set; the adaptor returns tasks with a `ParentId` field, and the `GanttTaskFields.ParentID` mapping turns that into the chart, grid, and taskbar hierarchy.
- **Full CRUD out of the box** – Add (toolbar), edit (cell, row, dialog), delete, and taskbar drag operations on the Gantt are mapped to standard GraphQL mutations on the backend.
- **Strongly typed `TaskDataInput`** – Hot Chocolate generates a `TaskDataInput` type from the model, so insert, update, and batch operations are validated at the schema level.

## Real-world use cases

- **Enterprise project management** – Multi-phase project plans with thousands of tasks where business rules (dependencies, resource availability, schedule constraints) must be enforced on the server before tasks are returned.
- **Construction and engineering schedules** – Long-running Gantt views where the chart only needs the visible page plus filtered children, and the rest must be served on demand.
- **Manufacturing and production planning** – Work order hierarchies that must be filtered by shop, line, or shift, sorted and updated frequently with taskbar drag operations.
- **Multi-tenant SaaS applications** – Each request must be scoped to the authenticated tenant; the `GraphQLAdaptor` lets the server apply that filter before sorting are calculated.
- **Modern .NET backends** – Teams that have already adopted Hot Chocolate for their API layer and want to plug the Gantt Chart in without maintaining a parallel REST service.