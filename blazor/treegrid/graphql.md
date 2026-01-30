---
layout: post
title: Blazor Tree Grid with GraphQL: CRUD & Data Operations | Syncfusion
description: Build Blazor apps with GraphQL and Syncfusion Tree Grid to enable CRUD, filtering, sorting, and paging for seamless data operations.
control: TreeGrid
platform: blazor
documentation: ug
---

# Connecting the TreeGrid with GraphQL Backend using Hot Chocolate

GraphQL is a query language that allows applications to request exactly the data needed, nothing more and nothing less. Unlike traditional REST APIs that return fixed data structures, GraphQL enables the client to specify the shape and content of the response.

**Traditional REST APIs** and **GraphQL** differ mainly in how data is requested and returned: **REST APIs expose** multiple endpoints that return fixed data structures, often including unnecessary fields and requiring several requests to fetch related data, while **GraphQL** uses a single endpoint where queries define the exact fields needed, enabling precise responses and allowing related data to be retrieved efficiently in one request. This makes **GraphQL** especially useful for **Blazor TreeGrid integration**, the **reason** is data‑centric UI components require well‑structured and selective datasets to support efficient filtering, reduce network calls, and improve overall performance.

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
| Visual Studio 2022 | 17.0 or later | Development IDE with Blazor workload |
| .NET SDK | net8.0 or compatible | Runtime and build tools |
| HotChocolate.AspNetCore | 15.1 or later | GraphQL server framework |
| Syncfusion.Blazor.Grids | {{site.blazorversion}} | DataGrid component |
| Syncfusion.Blazor.TreeGrid | {{site.blazorversion}} | TreeGrid component |
| Syncfusion.Blazor.Themes | {{site.blazorversion}} | Styling for TreeGrid |

## Setting Up the GraphQL Backend

### Step 1: Install Required NuGet Packages and Configure Launch Settings

Before installing NuGet packages, a new Blazor Web Application must be created using the default template. The template automatically generates essential starter files—such as **Program.cs, appsettings.json, launchSettings.json, the wwwroot folder, and the Components folder**.

For this guide, a Blazor application named **TreeGrid_GraphQLAdaptor** has been created.

**Install NuGet Packages**

NuGet packages are software libraries that add functionality to applications. The following packages enable GraphQL server functionality+ and Syncfusion TreeGrid components.

**Required Packages:**

- **HotChocolate.AspNetCore** (version 15.1 or later) - GraphQL server framework
- **Syncfusion.Blazor.Grids** (version {{site.blazorversion}}) - DataGrid component
- **Syncfusion.Blazor.TreeGrid** (version {{site.blazorversion}}) - TreeGrid component
- **Syncfusion.Blazor.Themes** (version {{site.blazorversion}}) - Styling for TreeGrid

**Method 1: Using Package Manager Console**

1. Open Visual Studio 2022.
2. Navigate to **Tools → NuGet Package Manager → Package Manager Console**.
3. Run the following commands:

```powershell
Install-Package HotChocolate.AspNetCore -Version 15.1.12
Install-Package Syncfusion.Blazor.Grids -Version {{site.blazorversion}}
Install-Package Syncfusion.Blazor.TreeGrid -Version {{site.blazorversion}}
Install-Package Syncfusion.Blazor.Themes -Version {{site.blazorversion}}
```

**Method 2: Using NuGet Package Manager UI**

1. Open **Visual Studio 2022 → Tools → NuGet Package Manager → Manage NuGet Packages for Solution**.
2. Search for and install each package individually:
   - **HotChocolate.AspNetCore** (version 15.1.12 or later)   
   - **Syncfusion.Blazor.Grids** (version {{site.blazorversion}})
   - **Syncfusion.Blazor.TreeGrid** (version {{site.blazorversion}})
   - **Syncfusion.Blazor.Themes** (version {{site.blazorversion}})

All required packages are now installed.

---

### Step 2: Register Hot Chocolate Services in Program.cs

The `Program.cs` file configures and registers the GraphQL services.

**Instructions:**

1. Open the `Program.cs` file at the project root.
2. Add the following code after `var builder = WebApplication.CreateBuilder(args);`:

```csharp
[Program.cs]

using TreeGrid_GraphQLAdaptor.Models;
using HotChocolate.Execution.Configuration;

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

- `AddGraphQLServer()` - Initializes the Hot Chocolate GraphQL server
- `AddQueryType<GraphQLQuery>()` - Registers query resolvers for read operations
- `AddMutationType<GraphQLMutation>()` - Registers mutation resolvers for write operations
- `MapGraphQL()` - Exposes the GraphQL endpoint at `/graphql`

The GraphQL backend is now configured and ready. The GraphQL endpoint is accessible at `https://localhost:xxxx/graphql`.

---

### Step 3: Configure Launch Settings (Port Configuration)

The **launchsettings.json** file controls the port number where the application runs. This file is located in the **Properties** folder at **Properties/launchsettings.json**.

**Instructions to Change the Port:**

1. Open the **Properties** folder in the project root.
2. Double-click **launchsettings.json** to open the file.
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
   - `https://localhost:7001` - HTTPS port (change 7001 to desired port)
   - `http://localhost:5001` - HTTP port (change 5001 to desired port)

5. Example configuration with custom ports:

```json
"https": {
  "commandName": "Project",
  "dotnetRunMessages": true,
  "launchBrowser": true,
  "applicationUrl": "https://localhost:7777;http://localhost:5555",
  "environmentVariables": {
    "ASPNETCORE_ENVIRONMENT": "Development"
  }
}
```

6. Save the file and restart the application for the changes to take effect.

**Important Notes:**

- Port numbers must be between 1024 and 65535.
- Avoid using ports already in use by other applications.
- The GraphQL endpoint will be accessible at the configured HTTPS URL (e.g., `https://localhost:7777/graphql`).

All configuration steps are now complete.

---

### Step 4: Create the Data Model

A data model represents the structure of data that the application stores. It defines the properties (fields) that make up a record. Each property corresponds to a column in the database table. The data model acts as the blueprint for how data is organized and accessed throughout the application.

In the context of an expense tracker, the data model defines what information is stored for each expense entry. Properties include the expense identifier, employee details, department, category, and financial amounts.

**Instructions**:

1. Create a new folder named **Models** in the project root directory.
2. Inside the **Models** folder, create a new file named **ExpenseRecord.cs**.
3. Define the **ExpenseRecord** class with the following code:

**File Location:** `Models/EmployeeData.cs`

```csharp
namespace TreeGrid_GraphQLAdaptor.Models
{
    public class EmployeeData
    {
        [GraphQLName("employeeID")]
        public string EmployeeID { get; set; } = default!; // EMP001, EMP002, ...

        [GraphQLName("firstName")]
        public string? FirstName { get; set; }

        [GraphQLName("lastName")]
        public string? LastName { get; set; }

        [GraphQLName("title")]
        public string? Title { get; set; }

        // Parent reference as EMP###
        [GraphQLName("managerID")]
        public string? ManagerID { get; set; }

        [GraphQLName("hasChild")]
        public bool HasChild { get; set; }

        [GraphQLName("name")]
        public string? Name { get; set; }

        [GraphQLName("location")]
        public string? Location { get; set; }

        [GraphQLName("dateJoined")]
        public DateTime? DateJoined { get; set; }

        [GraphQLName("salaryPerMonth")]
        public decimal? SalaryPerMonth { get; set; }

        [GraphQLName("email")]
        public string? Email { get; set; }

        [GraphQLName("projectDetails")]
        public string? ProjectDetails { get; set; }

        [GraphQLName("projectStatus")]
        public string? ProjectStatus { get; set; }

        [GraphQLName("priority")]
        public string? Priority { get; set; } // Low, Medium, High, Critical

        [GraphQLName("progress")]
        public int? Progress { get; set; } // 0..100

        [GraphQLName("projectStartDate")]
        public DateTime? ProjectStartDate { get; set; }

        [GraphQLName("projectEndDate")]
        public DateTime? ProjectEndDate { get; set; }

        [GraphQLName("projectId")]
        public string? ProjectId { get; set; } // PRJ001 ...

        private static readonly object _sync = new();
        private static List<EmployeeData>? _employeesData;

        private static string EmpId(int n) => $"EMP{n:000}";
        private static string PrjId(int n) => $"PRJ{n:000}";

        // Name pools (48 * 32 = 1536 unique full-name combinations)
        private static readonly string[] FirstNames =
        {
            "Ava","Liam","Olivia","Noah","Emma","Elijah","Sophia","Lucas","Isabella","Mason",
            "Mia","James","Amelia","Benjamin","Charlotte","Ethan","Harper","Henry","Evelyn","Alexander",
            "Abigail","Michael","Emily","Daniel","Elizabeth","Logan","Sofia","Jackson","Avery","Sebastian",
            "Ella","Jack","Scarlett","Aiden","Grace","Owen","Chloe","Samuel","Lily","Matthew",
            "Hannah","Joseph","Victoria","Levi","Aria","David","Nora","Wyatt"
        };

        private static readonly string[] LastNames =
        {
            "Anderson","Baker","Campbell","Diaz","Edwards","Foster","Garcia","Harris","Ibrahim","Johnson",
            "Kim","Lopez","Miller","Nguyen","Owens","Patel","Quinn","Rodriguez","Smith","Turner",
            "Upton","Vasquez","Walker","Xu","Young","Zimmerman","Clark","Parker","Carter","Howard",
            "Brooks","Murphy"
        };

        // Simple, non‑technical project names (short and clear)
        private static readonly string[] SimpleProjectNames =
        {
            "Website Redesign",
            "Online Store",
            "Customer Portal",
            "Employee Portal",
            "Help Center",
            "Booking System",
            "Payment System",
            "Inventory Tracker",
            "Order Tracker",
            "Reporting Dashboard",
            "Mobile App",
            "Chat Support",
            "Email Notices",
            "File Sharing",
            "Maps & Locations",
            "Video Library",
            "Search Tool",
            "Survey Tool",
            "Learning Portal",
            "HR System",
            "Scheduling App",
            "Billing & Invoices",
            "Ticket System",
            "News & Blog",
            "Profile Manager",
            "Settings Panel",
            "Theme Builder",
            "Docs Site",
            "Admin Dashboard",
            "Data Import",
            "Data Export",
            "Backup Service",
            "Alerts Center",
            "Task Manager",
            "Calendar",
            "Feedback Board",
            "Onboarding Guide"
        };

        // Scrambled unique full name for index n (1-based)
        private static (string first, string last, string full) UniquePersonName(int n)
        {
            int idx = n - 1; // zero-based
            int F = FirstNames.Length;
            int L = LastNames.Length;

            int i = idx % F;          // first-name index cycles fastest
            int q = idx / F;          // advances every F items
            int j = (q + 13 * i) % L; // interleave last names to avoid blocks

            string first = FirstNames[i];
            string last = LastNames[j];
            return (first, last, $"{first} {last}");
        }

        // Pick a short, clear project name
        private static string ProjectName(int n)
        {
            // Use a stride to mix names; wraps automatically
            return SimpleProjectNames[(n * 5) % SimpleProjectNames.Length];
        }

        // Parent + Children only (no grandchildren)
        public static List<EmployeeData> GetAllRecords()
        {
            if (_employeesData != null) return _employeesData;

            lock (_sync)
            {
                if (_employeesData != null) return _employeesData;

                var list = new List<EmployeeData>();
                int next = 0; // sequential counter for EMP ids

                string[] locations = { "Seattle", "Chicago", "New York", "Boston", "San Francisco", "Austin", "Denver", "London", "Berlin", "Paris" };
                string[] priorities = { "Low", "Medium", "High", "Critical" };
                string[] statuses = { "Open", "In Progress", "Started", "Validated", "Closed" };
                string[] titles = { "Executive", "Director", "Manager", "Lead", "Engineer", "Analyst" };

                int rootCount = 100;        // number of parents
                int childrenPerRoot = 9;    // children per parent

                for (int r = 0; r < rootCount; r++)
                {
                    string rootPriority = (r % 3) switch { 0 => "High", 1 => "Critical", _ => "Medium" };
                    string rootStatus = (r % 2 == 0) ? "Open" : "In Progress";

                    var rootEmpId = EmpId(++next);
                    var rootName = UniquePersonName(next);

                    var root = new EmployeeData
                    {
                        EmployeeID = rootEmpId,
                        FirstName = rootName.first,
                        LastName = rootName.last,
                        Name = rootName.full,
                        Title = titles[r % titles.Length],
                        ManagerID = null,
                        HasChild = true,
                        Location = locations[r % locations.Length],
                        DateJoined = new DateTime(2016 + (r % 5), 1 + (r % 12), 5 + (r % 20)),
                        SalaryPerMonth = 15000 + (r % 4) * 1200,
                        Email = $"{rootName.first.ToLower()}.{rootName.last.ToLower()}{next:000}@company.com",
                        ProjectDetails = ProjectName(next),
                        ProjectStatus = rootStatus,
                        Priority = rootPriority,
                        Progress = 60 + (r * 7) % 41,
                        ProjectStartDate = new DateTime(2024, 1 + (r % 6), 1 + (r % 28)),
                        ProjectEndDate = new DateTime(2025, 1 + ((r + 6) % 12), 1 + (r % 28)),
                        ProjectId = PrjId(next)
                    };
                    list.Add(root);

                    // Children
                    for (int c = 0; c < childrenPerRoot; c++)
                    {
                        string childPriority = priorities[(c + r) % priorities.Length];
                        string childStatus = statuses[(c + r) % statuses.Length];

                        var childEmpId = EmpId(++next);
                        var childName = UniquePersonName(next);

                        var child = new EmployeeData
                        {
                            EmployeeID = childEmpId,
                            FirstName = childName.first,
                            LastName = childName.last,
                            Name = childName.full,
                            Title = (c % 2 == 0) ? "Manager" : "Lead",
                            ManagerID = rootEmpId,
                            HasChild = false,
                            Location = locations[(r + c + 1) % locations.Length],
                            DateJoined = new DateTime(2018 + (c % 5), 1 + ((c + 2) % 12), 1 + ((c + 5) % 28)),
                            SalaryPerMonth = 8500 + (c % 6) * 700,
                            Email = $"{childName.first.ToLower()}.{childName.last.ToLower()}{next:000}@company.com",
                            ProjectDetails = ProjectName(next),
                            ProjectStatus = childStatus,
                            Priority = childPriority,
                            Progress = (c * 13) % 101,
                            ProjectStartDate = DateTime.Today.AddDays(-(c % 200)),
                            ProjectEndDate = DateTime.Today.AddDays((c % 200) + 30),
                            ProjectId = PrjId(next)
                        };
                        list.Add(child);
                    }
                }

                var parentsWithChildren = list
                    .Where(e => !string.IsNullOrWhiteSpace(e.ManagerID))
                    .Select(e => e.ManagerID!)
                    .Distinct(StringComparer.OrdinalIgnoreCase)
                    .ToHashSet(StringComparer.OrdinalIgnoreCase);

                foreach (var e in list)
                    e.HasChild = parentsWithChildren.Contains(e.EmployeeID);

                _employeesData = list;
                return _employeesData;
            }
        }
    }
}
```
**Property Mapping Reference**

The following table shows how C# properties map to database columns and GraphQL field names:

| Property Name (C#) | Database Column | GraphQL Field Name | Data Type | Purpose |
|---|---:|---|---|---|
| `EmployeeID` | `employee_id` | `employeeID` | `string` | Primary key (EMP###) |
| `FirstName` | `first_name` | `firstName` | `string?` | Given name |
| `LastName` | `last_name` | `lastName` | `string?` | Family name |
| `Title` | `title` | `title` | `string?` | Job title |
| `ManagerID` | `manager_id` | `managerID` | `string?` | Parent employee id (EMP###) |
| `HasChild` | `has_child` | `hasChild` | `bool` | Has direct reports |
| `Name` | `name` | `name` | `string?` | Full/display name |
| `Location` | `location` | `location` | `string?` | Office/location |
| `DateJoined` | `date_joined` | `dateJoined` | `DateTime?` | Hiring date |
| `SalaryPerMonth` | `salary_per_month` | `salaryPerMonth` | `decimal?` | Monthly salary |
| `Email` | `email` | `email` | `string?` | Contact email |
| `ProjectDetails` | `project_details` | `projectDetails` | `string?` | Short project description |
| `ProjectStatus` | `project_status` | `projectStatus` | `string?` | Project status |
| `Priority` | `priority` | `priority` | `string?` | Priority label |
| `Progress` | `progress` | `progress` | `int?` | Progress percent (0–100) |
| `ProjectStartDate` | `project_start_date` | `projectStartDate` | `DateTime?` | Project start date |
| `ProjectEndDate` | `project_end_date` | `projectEndDate` | `DateTime?` | Project end date |
| `ProjectId` | `project_id` | `projectId` | `string?` | Project identifier (PRJ###) |

**Important Convention: Camel Case Conversion**

**Hot Chocolate GraphQL** automatically converts C# property names (**PascalCase**) to GraphQL field names (**camelCase**). This convention ensures consistent naming in the GraphQL schema:

- C# Property: `EmployeeID` → GraphQL Field: `employeeID`
- C# Property: `FirstName` → GraphQL Field: `firstName`
- C# Property: `ProjectDetails` → GraphQL Field: `projectDetails`

**Explanation**:

- The [GraphQLName("...")] attribute on each EmployeeData property determines the field name exposed in the GraphQL schema.
- Each property represents a column in the database table.
- The model provides the data structure that GraphQL uses to process queries and mutations.

The employee data model has been successfully created.

---

### Step 5: GraphQL Query Resolvers

A query resolver is a method in the backend that handles read requests from the client. When the Blazor TreeGrid needs to fetch data, it sends a GraphQL query to the server. The query resolver receives this request, processes it, and returns the appropriate data. Query resolvers do not modify data; they only retrieve and return it.

In simple terms, a **GraphQL query** asks a question,
and a **resolver** is the one who answers it.

**Instructions:**

1. Inside the **Models** folder, create a new file named **GraphQLQuery.cs**.
2. Add the following code to define the query resolver:

```csharp
[Models/GraphQLQuery.cs]

using System.Text.Json;

namespace TreeGrid_GraphQLAdaptor.Models
{
    /// <summary>
    /// Represents the GraphQL query resolver for fetching employee data.
    /// </summary>
    public class GraphQLQuery
    {
        // SINGLE ENTRYPOINT: handles roots, children, expand/collapse, expandall, loadchildondemand, filtering, search, sort, paging
        public EmployeesDataResponse EmployeesData(DataManagerRequestInput dataManager)
        {
            EnsureDataLoaded();

            // Parent detection (params first, then ManagerID== in where)
            string? parentId = TryGetParentIdFromParams(dataManager?.Params)
                            ?? TryGetParentIdFromWhere(dataManager?.Where);

            // CHILDREN SLICE: return only direct children of requested parent
            if (!string.IsNullOrWhiteSpace(parentId))
            {
                var children = _data
                    .Where(d => string.Equals(d.ManagerID, parentId, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                return new EmployeesDataResponse
                {
                    Count = children.Count,
                    Result = children,
                    Items = children
                };
            }

            // ROOTS: proper root-only paging
            var roots = _data.Where(d => string.IsNullOrWhiteSpace(d.ManagerID)).ToList();
            int total = roots.Count;

            IEnumerable<EmployeeData> page = roots;
            if (dataManager?.Skip is int sk && dataManager.Take is int tk)
            {
                page = page.Skip(sk).Take(tk);
            }

            var list = page.ToList();
            return new EmployeesDataResponse
            {
                Count = total,
                Result = list,
                Items = list
            };
        }

        private static List<EmployeeData> _data = EnsureDataInternal();

        private static List<EmployeeData> EnsureDataInternal() => EmployeeData.GetAllRecords();

        private static void EnsureDataLoaded()
        {
            if (_data == null || _data.Count == 0) _data = EnsureDataInternal();
        }

        private static string? TryGetParentIdFromParams(object? prms)
        {
            if (!TryReadFromParams(prms, "parentId", out var v) || v is null) return null;
            return ToEmpId(v);
        }

        private static bool TryReadFromParams(object? prms, string key, out object? value)
        {
            value = null;
            if (prms == null) return false;

            // IDictionary<string, object>
            if (prms is IDictionary<string, object> dictObj)
                return dictObj.TryGetValue(key, out value);

            // IReadOnlyDictionary<string, object>
            if (prms is IReadOnlyDictionary<string, object> roDict)
                return roDict.TryGetValue(key, out value);

            // IDictionary<string, JsonElement>
            if (prms is IDictionary<string, JsonElement> dictJson)
            {
                if (dictJson.TryGetValue(key, out var je)) { value = je; return true; }
                return false;
            }

            // IEnumerable<KeyValuePair<string, object>>
            if (prms is IEnumerable<KeyValuePair<string, object>> kvs)
            {
                foreach (var kv in kvs)
                    if (string.Equals(kv.Key, key, StringComparison.OrdinalIgnoreCase))
                    { value = kv.Value; return true; }
            }

            // JsonElement object
            if (prms is JsonElement jeObj && jeObj.ValueKind == JsonValueKind.Object)
            {
                if (jeObj.TryGetProperty(key, out var je))
                { value = je; return true; }
            }

            return false;
        }

        private static string? TryGetParentIdFromWhere(List<WhereFilter>? where)
        {
            if (where == null || where.Count == 0) return null;

            foreach (var wf in where)
            {
                if (!string.IsNullOrWhiteSpace(wf.Field) &&
                    wf.Field.Equals("ManagerID", StringComparison.OrdinalIgnoreCase))
                {
                    var op = (wf.Operator ?? "equal").Trim().ToLowerInvariant();
                    if (op is "equal" or "eq")
                    {
                        if (wf.Value == null) return null;
                        return ToEmpId(wf.Value);
                    }
                }

                if (wf.Predicates != null && wf.Predicates.Count > 0)
                {
                    var nested = TryGetParentIdFromWhere(wf.Predicates);
                    if (nested != null || wf.Value == null) return nested;
                }
            }
            return null;
        }

        private static string? ToEmpId(object? v)
        {
            if (v == null) return null;
            if (v is string s)
            {
                if (int.TryParse(s, out var n)) return $"EMP{n:000}";
                return s;
            }
            if (v is int i) return $"EMP{i:000}";
            if (v is long l && l >= int.MinValue && l <= int.MaxValue) return $"EMP{(int)l:000}";
            if (v is JsonElement je)
            {
                return je.ValueKind switch
                {
                    JsonValueKind.Number => je.TryGetInt32(out var j) ? $"EMP{j:000}" : null,
                    JsonValueKind.String => int.TryParse(je.GetString(), out var k) ? $"EMP{k:000}" : je.GetString(),
                    JsonValueKind.Null => null,
                    _ => null
                };
            }
            return v.ToString();
        }
    }

    // Response type
    public class EmployeesDataResponse
    {
        [GraphQLName("count")]
        public int Count { get; set; }

        [GraphQLName("result")]
        public List<EmployeeData> Result { get; set; } = new();

        [GraphQLName("items")]
        public List<EmployeeData> Items { get; set; } = new();
    }
}
```

**Details:**

- The `EmployeesData` method receives `DataManagerRequestInput`, which contains filter, sort, search, and paging parameters from the TreeGrid
- Hot Chocolate automatically converts the method name `EmployeesData` to camelCase: `employeesData` in the GraphQL schema
- The response must contain `Count` (total records) and `Result` (current page data) for the TreeGrid to process pagination

The query resolver has been created successfully.

---

### Step 6: Create the DataManagerRequestInput Class

A **DataManagerRequestInput** class is a GraphQL input type that represents all the parameters the Syncfusion Blazor TreeGrid sends to the backend when requesting data. This class acts as a container for filtering, sorting, searching, paging, and other data operation parameters.

**Purpose**
When the TreeGrid performs operations like pagination, sorting, filtering, or searching, it packages all these parameters into a `DataManagerRequestInput` object and sends it to the GraphQL backend. The backend then uses these parameters to fetch and return only the data the tree grid needs.

**Instructions**:

1. Inside the **Models** folder, create a new file named **DataManagerRequestInput.cs**.
2. Define the **DataManagerRequestInput** class and supporting classes with the following code:

```csharp
namespace TreeGrid_GraphQLAdaptor.Models
{
        /// <summary>
        /// Represents the input structure for data manager requests.
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
            public IDictionary<string, object> Params { get; set; }

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
        /// Represents an aggregate operation in the data manager request.
        /// </summary>
        public class Aggregate
        {
            [GraphQLName("Field")]
            public string Field { get; set; }

            [GraphQLName("Type")]
            public string Type { get; set; }
        }

        /// <summary>
        /// Represents a search filter in the data manager request.
        /// </summary>
        public class SearchFilter
        {
            [GraphQLName("Fields")]
            public List<string> Fields { get; set; }

            [GraphQLName("Key")]
            public string Key { get; set; }

            [GraphQLName("Operator")]
            public string Operator { get; set; }

            [GraphQLName("IgnoreCase")]
            public bool IgnoreCase { get; set; }

            [GraphQLName("IgnoreAccent")]
            public bool? IgnoreAccent { get; set; }
        }

        /// <summary>
        /// Represents a sorting operation in the data manager request.
        /// </summary>
        public class Sort
        {
            [GraphQLName("Name")]
            public string Name { get; set; }

            [GraphQLName("Direction")]
            public string Direction { get; set; }

            [GraphQLName("Comparer")]
            [GraphQLType(typeof(AnyType))]
            public object Comparer { get; set; }
        }

        /// <summary>
        /// Represents a filter condition in the data manager request.
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
    
}
```

**Understanding the DataManagerRequestInput Class**

**Example Scenario:** A sequence of operations is performed on the TreeGrid as follows:

- Searches for **"Seattle"** in the Location column.
- Filters for monthly salary greater than 10000.
- Sorts by SalaryPerMonth in descending order.
- Resulting **DataManagerRequestInput** Parameters:

```json
{
  "dataManager": {
    "Skip": 10,
    "Take": 10,
    "RequiresCounts": true,
    "Search": [
      {
        "Fields": ["location"],
        "Key": "Seattle",
        "Operator": "contains",
        "IgnoreCase": true,
        "IgnoreAccent": true
      }
    ],
    "Where": [
      {
        "Condition": "and",
        "Predicates": [
          {
            "Field": "salaryPerMonth",
            "Operator": "greaterThan",
            "Value": 10000,
            "Predicates": []
          }
        ]
      }
    ],
    "Sorted": [
      {
        "Name": "salaryPerMonth",
        "Direction": "Descending"
      }
    ]
  }
}
```

**DataManagerRequestInput Properties:**

| Property | Purpose | Type | Example |
|----------|---------|------|---------|
| `Skip` | Number of records to skip (used for pagination) | `int` | `10` (skip first 10 records) |
| `Take` | Number of records to retrieve per page | `int` | `20` (fetch next 20 records) |
| `Search` | Search filter configuration | `List<SearchFilter>` | Search term and target fields |
| `Where` | Filter conditions for column filtering | `List<WhereFilter>` | Field name, operator, and value |
| `Sorted` | Sort specifications for ordering records | `List<SortDescriptor>` | Field name and direction (asc/desc) |


**Key Attributes Explained**
[GraphQLName]: Maps C# property names to GraphQL schema field names. **Hot Chocolate** automatically converts PascalCase to camelCase.

Example: **RequiresCounts → requiresCounts**
[GraphQLType(typeof(AnyType))]: Allows flexible typing for complex nested structures that can contain various data types.

### Step 7: GraphQL Mutation Resolvers

A **GraphQL mutation resolver** is a method in the backend that handles write requests (data modifications) from the client. While queries only read data, mutations create, update, or delete records. When the Blazor TreeGrid performs add, edit, or delete operations, it sends a GraphQL mutation to the server. The mutation resolver receives this request, processes it, and persists the changes to the data source.

In simple terms, a **GraphQL mutation** asks for a change, and a **resolver** is the one who makes it.

**Instructions:**
1. Inside the Models folder, create a new file named **GraphQLMutation.cs**.
2. Define the **GraphQLMutation** class with the following code:

```csharp
namespace TreeGrid_GraphQLAdaptor.Models
{
    public class GraphQLMutation
    {
        public EmployeeData CreateEmployee(
            EmployeeData record,
            int index,
            string action,
            [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters)
        {
            var employees = EmployeeData.GetAllRecords();

            // Accept provided values; caller should supply EmployeeID (e.g., EMP001) and optional ManagerID.
            var entity = new EmployeeData
            {
                EmployeeID = record.EmployeeID,
                FirstName = record.FirstName,
                LastName = record.LastName,
                Title = record.Title,
                ManagerID = record.ManagerID,
                HasChild = record.HasChild,
                Name = record.Name,
                Location = record.Location,
                DateJoined = record.DateJoined,
                SalaryPerMonth = record.SalaryPerMonth,
                Email = record.Email,
                ProjectDetails = record.ProjectDetails,
                ProjectStatus = record.ProjectStatus,
                Priority = record.Priority,
                Progress = record.Progress,
                ProjectStartDate = record.ProjectStartDate,
                ProjectEndDate = record.ProjectEndDate,
                ProjectId = record.ProjectId // e.g., PRJ001
            };

            if (!string.IsNullOrWhiteSpace(entity.ManagerID))
            {
                var manager = employees.FirstOrDefault(e => string.Equals(e.EmployeeID, entity.ManagerID, System.StringComparison.OrdinalIgnoreCase));
                if (manager != null) manager.HasChild = true;
            }

            if (index >= 0 && index <= employees.Count)
                employees.Insert(index, entity);
            else
                employees.Add(entity);

            return entity;
        }


        public EmployeeData? UpdateEmployee(
            EmployeeData record,
            string action,
            string primaryColumnName,
            string primaryColumnValue,
            [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters)
        {
            var employees = EmployeeData.GetAllRecords();

            var keyName = primaryColumnName?.ToLowerInvariant();
            var existing = keyName switch
            {
                "employeeid" => employees.FirstOrDefault(x => string.Equals(x.EmployeeID, primaryColumnValue, System.StringComparison.OrdinalIgnoreCase)),
                _ => employees.FirstOrDefault(x => string.Equals(x.EmployeeID, primaryColumnValue, System.StringComparison.OrdinalIgnoreCase))
            };
            if (existing == null) return null;

            if (record.FirstName != null) existing.FirstName = record.FirstName;
            if (record.LastName != null) existing.LastName = record.LastName;
            if (record.Title != null) existing.Title = record.Title;
            if (record.Name != null) existing.Name = record.Name;
            if (record.Location != null) existing.Location = record.Location;
            if (record.DateJoined.HasValue) existing.DateJoined = record.DateJoined;
            if (record.SalaryPerMonth.HasValue) existing.SalaryPerMonth = record.SalaryPerMonth;
            if (record.Email != null) existing.Email = record.Email;
            if (record.ProjectDetails != null) existing.ProjectDetails = record.ProjectDetails;
            if (record.ProjectStatus != null) existing.ProjectStatus = record.ProjectStatus;
            if (record.Priority != null) existing.Priority = record.Priority;
            if (record.Progress.HasValue) existing.Progress = record.Progress;
            if (record.ProjectStartDate.HasValue) existing.ProjectStartDate = record.ProjectStartDate;
            if (record.ProjectEndDate.HasValue) existing.ProjectEndDate = record.ProjectEndDate;
            if (record.ProjectId != null) existing.ProjectId = record.ProjectId;

            if (!string.IsNullOrWhiteSpace(record.ManagerID) &&
                !string.Equals(record.ManagerID, existing.ManagerID, System.StringComparison.OrdinalIgnoreCase))
            {
                var oldManagerId = existing.ManagerID;
                existing.ManagerID = record.ManagerID;

                if (!string.IsNullOrWhiteSpace(existing.ManagerID))
                {
                    var newManager = employees.FirstOrDefault(e => string.Equals(e.EmployeeID, existing.ManagerID, System.StringComparison.OrdinalIgnoreCase));
                    if (newManager != null) newManager.HasChild = true;
                }

                if (!string.IsNullOrWhiteSpace(oldManagerId))
                {
                    var oldManager = employees.FirstOrDefault(e => string.Equals(e.EmployeeID, oldManagerId, System.StringComparison.OrdinalIgnoreCase));
                    if (oldManager != null)
                    {
                        oldManager.HasChild = employees.Any(e => string.Equals(e.ManagerID, oldManager.EmployeeID, System.StringComparison.OrdinalIgnoreCase));
                    }
                }
            }

            if (record.HasChild) existing.HasChild = record.HasChild;

            return existing;
        }


        public EmployeeData? DeleteEmployee(
            string primaryColumnValue,
            string action,
            string primaryColumnName,
            [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters)
        {
            var employees = EmployeeData.GetAllRecords();

            var keyName = primaryColumnName?.ToLowerInvariant();
            var toDelete = keyName switch
            {
                "employeeid" => employees.FirstOrDefault(x => string.Equals(x.EmployeeID, primaryColumnValue, System.StringComparison.OrdinalIgnoreCase)),
                _ => employees.FirstOrDefault(x => string.Equals(x.EmployeeID, primaryColumnValue, System.StringComparison.OrdinalIgnoreCase))
            };
            if (toDelete == null) return null;

            var idsToRemove = new HashSet<string>(System.StringComparer.OrdinalIgnoreCase);
            CollectWithDescendants(employees, toDelete.EmployeeID, idsToRemove);

            employees.RemoveAll(e => idsToRemove.Contains(e.EmployeeID));

            if (!string.IsNullOrWhiteSpace(toDelete.ManagerID))
            {
                var manager = employees.FirstOrDefault(e => string.Equals(e.EmployeeID, toDelete.ManagerID, System.StringComparison.OrdinalIgnoreCase));
                if (manager != null)
                {
                    manager.HasChild = employees.Any(e => string.Equals(e.ManagerID, manager.EmployeeID, System.StringComparison.OrdinalIgnoreCase));
                }
            }

            return toDelete;
        }

        private static void CollectWithDescendants(List<EmployeeData> all, string rootId, HashSet<string> bag)
        {
            if (bag.Contains(rootId)) return;
            bag.Add(rootId);
            var children = all.Where(e => string.Equals(e.ManagerID, rootId, System.StringComparison.OrdinalIgnoreCase))
                              .Select(e => e.EmployeeID);
            foreach (var c in children)
                CollectWithDescendants(all, c, bag);
        }
    }
}
```

A mutation resolver is a C# method decorated with GraphQL attributes that:

- **Receives input parameters** from the TreeGrid (record data, primary keys, etc.).
- **Processes the operation** (validation, calculation, data modification).
- **Persists changes** to the data source (database, file, memory).
- **Returns results** to the client (modified record or success/failure status).

The GraphQL Mutation class has been successfully created and is ready to handle all data modification operations from the Syncfusion Blazor TreeGrid.

---

## Integrating Syncfusion Blazor TreeGrid

### Step 1: Install and Configure Blazor TreeGrid Components with GraphQL

Syncfusion is a library that provides pre-built UI components like TreeGrid, which is used to display data in a table format.

**Instructions:**

1. The Syncfusion.Blazor.Grids package was installed in **Step 1** of the previous heading.
2. Import the required namespaces in the `Components/_Imports.razor` file:

```csharp
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Data
```

3. Add the Syncfusion stylesheet and scripts in the `Components/App.razor` file. Find the `<head>` section and add:

```html
<!-- Syncfusion Blazor Stylesheet -->
<link href="_content/Syncfusion.Blazor.Themes/tailwind3.css" rel="stylesheet" />

<!-- Syncfusion Blazor Scripts -->
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
```

Syncfusion components are now configured and ready to use. For additional guidance, refer to the TreeGrid component’s [getting‑started](https://blazor.syncfusion.com/documentation/treegrid/getting-started-webapp) documentation.

### Step 2: Update the Blazor TreeGrid in the Home Component

The Home component will display the expense data in a Syncfusion Blazor TreeGrid with search, filter, sort, editing and pagination capabilities.

**Instructions:**

1. Open the file named `Home.razor` in the `Components/Pages` folder.
2. Add the following code to create a basic TreeGrid:

```razor
@page "/"
@rendermode InteractiveServer

<div class="page-wrap">
    <div class="toolbar">
        <span class="toolbar-title">Employees</span>
        <span class="label">Category:</span>

        <SfDropDownList TValue="string"
                        TItem="DropDownData"
                        Width="220px"
                        DataSource="@CategoryOptions"
                        @bind-Value="@SelectedCategory">
            <DropDownListEvents TValue="string" TItem="DropDownData" ValueChange="ModeChange" />
            <DropDownListFieldSettings Text="Name" Value="ID" />
        </SfDropDownList>
    </div>

    <SfTreeGrid @ref="tree"
                TValue="EmployeeData"
                IdMapping="EmployeeID"
                ParentIdMapping="ManagerID"
                HasChildMapping="HasChild"
                TreeColumnIndex="@treeindex"
                Height="340"
                RowHeight="40"
                AllowPaging="true">
        <SfDataManager Url="http://localhost:7213/graphql"
                       Adaptor="Adaptors.GraphQLAdaptor"
                       GraphQLAdaptorOptions="@adaptorOptions">
        </SfDataManager>
        <TreeGridPageSettings PageSize="5"></TreeGridPageSettings>
        <TreeGridColumns>
            <TreeGridColumn Field="EmployeeID" HeaderText="Employee ID" IsPrimaryKey="true" Width="140" Visible="@showHRColumns" />
            <TreeGridColumn Field="ProjectId" HeaderText="Project ID" Width="120" Visible="@showPMColumns" TextAlign="TextAlign.Center" />
            <TreeGridColumn Field="ProjectDetails" HeaderText="Project Details" Width="240" Visible="@showPMColumns" />
            <TreeGridColumn Field="Name" HeaderText="@headerName" Width="180" />
            <TreeGridColumn Field="LastName" HeaderText="Last Name" Width="140" Visible="@showHRColumns" />
            <TreeGridColumn Field="Title" HeaderText="Title" Width="170" Visible="@showHRColumns" />
            <TreeGridColumn Field="Location" HeaderText="Location" Width="140" Visible="@showHRColumns" />
            <TreeGridColumn Field="DateJoined" HeaderText="Hired Date" Type="ColumnType.Date" Format="d" Width="130" Visible="@showHRColumns" />
            <TreeGridColumn Field="SalaryPerMonth" HeaderText="Salary/Month" Type="ColumnType.Integer" Format="C0" Width="140" TextAlign="TextAlign.Right" Visible="@showHRColumns" />

            <!-- Priority with subtle, matte chips -->
            <TreeGridColumn Field="Priority" HeaderText="Priority" Width="150" Visible="@showPMColumns" TextAlign="TextAlign.Center">
                <Template>
                    @{
                        var e = (EmployeeData)context;
                        var p = (e.Priority ?? "Low").Trim().ToLowerInvariant();
                        var cls = p switch
                        {
                            "critical" => "chip chip-critical",
                            "high" => "chip chip-high",
                            "medium" => "chip chip-medium",
                            _ => "chip chip-low"
                        };
                        var label = string.IsNullOrWhiteSpace(e.Priority) ? "Low" : e.Priority!;
                    }
                    <span class="@cls" aria-label="Priority @label">@label</span>
                </Template>
            </TreeGridColumn>

            <!-- Progress bar like screenshot -->
            <TreeGridColumn Field="Progress" HeaderText="Progress" Width="220" Visible="@showPMColumns" TextAlign="TextAlign.Left">
                <Template>
                    @{
                        var e = (EmployeeData)context;
                        var pct = Math.Clamp(e.Progress ?? 0, 0, 100);
                        var barClass = pct >= 80 ? "progress-bar prog-high"
                        : pct >= 50 ? "progress-bar prog-mid"
                        : "progress-bar prog-low";
                    }
                    <div class="progress-row" role="group" aria-label="Progress">
                        <div class="progress-wrap" role="progressbar" aria-valuemin="0" aria-valuemax="100" aria-valuenow="@pct">
                            <div class="@barClass" style="width:@pct%"></div>
                        </div>
                        <span class="progress-text">@pct%</span>
                    </div>
                </Template>
            </TreeGridColumn>

            <TreeGridColumn Field="ProjectStatus" HeaderText="Status" Width="130" Visible="@showPMColumns" />
            <TreeGridColumn Field="ProjectStartDate" HeaderText="Start Date" Type="ColumnType.Date" Format="d" Width="130" Visible="@showPMColumns" />
            <TreeGridColumn Field="ProjectEndDate" HeaderText="End Date" Type="ColumnType.Date" Format="d" Width="130" Visible="@showPMColumns" />
            <TreeGridColumn Field="Email" HeaderText="Email" Width="240" Visible="@showEmail" />
        </TreeGridColumns>
    </SfTreeGrid>
</div>

@code {
    // GraphQLAdaptorOptions will be added in the next step
}
```

**Component Explanation:**

- **`@rendermode InteractiveServer`**: Enables interactive server-side rendering for the component.
- **`<SfTreeGrid>`**: The TreeGrid component that displays data in rows and columns.
- **`<TreeGridColumns>`**: Defines individual columns in the TreeGrid.
- **`<TreeGridPageSettings>`**: Configures pagination with 10 records per page.
- **`<TreeGridEditSettings>`**: Enable editing functionality directly within the TreeGrid by setting the AllowEditing, AllowAdding, and AllowDeleting properties within the TreeGridEditSettings to **true**.

The `SfDataManager` component connects the TreeGrid to the GraphQL backend using the adaptor options configured below:

```razor
<SfDataManager Url="http://localhost:7213/graphql" 
               GraphQLAdaptorOptions="@adaptorOptions" 
               Adaptor="Adaptors.GraphQLAdaptor">
</SfDataManager>
```

**Component Attributes Explained:**

| Attribute | Purpose | Value |
|-----------|---------|-------|
| `Url` | GraphQL endpoint location | `http://localhost:7213/graphql` (must match backend port) |
| `GraphQLAdaptorOptions` | References the adaptor configuration object | `@adaptorOptions` (defined in next heading) |
| `Adaptor` | Specifies adaptor type to use | `Adaptors.GraphQLAdaptor` (tells Syncfusion to use GraphQL adaptor) |

**Important Notes:**

- The `Url` must match the port configured in `launchSettings.json`.
- If backend runs on port 7213, then URL must be `https://localhost:7213/graphql`.
- The `/graphql` path is set by `app.MapGraphQL()` in Program.cs.

---

### Step 3: Configure GraphQL Adaptor and Data Binding

The GraphQL adaptor is a bridge that connects the Syncfusion Blazor TreeGrid with the GraphQL backend. The adaptor translates TreeGrid operations (filtering, sorting, paging, searching) into GraphQL queries and mutations. When the user interacts with the tree grid, the adaptor automatically sends the appropriate GraphQL request to the backend, receives the response, and updates the tree grid display.

**What is a GraphQL Adaptor?**

An adaptor is a translator between two different systems. The GraphQL adaptor specifically:

- Receives interaction events generated by the TreeGrid, including Add, Edit, Delete actions, as well as sorting and filtering operations.
- Converts these actions into GraphQL query or mutation syntax.
- Sends the **GraphQL request** to the backend **GraphQL endpoint**.
- Receives the response data from the backend.
- Formats the response back into a structure the TreeGrid understands.
- Updates the tree grid display with the new data.

The adaptor enables bidirectional communication between the frontend (TreeGrid) and backend (GraphQL server).

---

**GraphQL Adaptor Configuration**

The `@code` block in `Home.razor` contains C# code that configures how the adaptor behaves. This configuration is critical because it defines:

- Which GraphQL query to use for reading data.
- Which GraphQL mutations to use for creating, updating, and deleting data.
- How to connect to the GraphQL backend endpoint.

**Instructions:**

1. Open the `Home.razor` file located at `Components/Pages/Home.razor`.
2. Scroll to the `@code` block at the bottom of the file.
3. Add the following complete configuration:

```csharp
@code {
    
    public class DropDownData { public string ID { get; set; } = ""; public string Name { get; set; } = ""; }

    private readonly List<DropDownData> CategoryOptions = new()
  {
    new() { ID = "HR", Name = "HR" },
    new() { ID = "PM", Name = "Project Management" }
  };

    public bool expandState { get; set; }
    private string SelectedCategory { get; set; } = "HR";
    private int treeindex { get; set; } = 3;
    private bool showHRColumns = true;
    private bool showPMColumns = false;
    private bool showEmail = true;
    public string headerName { get; set; } = "Name";
    private SfTreeGrid<EmployeeData>? tree;

    // Revert to ONLY $dataManager; server reads TreeGrid flags from dataManager.Params
    private const string HrQuery = @"
    query employeesData($dataManager: DataManagerRequestInput!) {
      employeesData(dataManager: $dataManager) {
        count
        result {
          employeeID
          managerID
          hasChild
          name
          lastName
          title
          location
          dateJoined
          salaryPerMonth
          email
        }
      }
    }";

    private const string PmQuery = @"
    query employeesData($dataManager: DataManagerRequestInput!) {
      employeesData(dataManager: $dataManager) {
        count
        result {
          employeeID
          managerID
          hasChild
          name
          projectId
          projectDetails
          projectStatus
          priority
          progress
          projectStartDate
          projectEndDate
        }
      }
    }";

    private GraphQLAdaptorOptions adaptorOptions = new GraphQLAdaptorOptions
    {
        Query = HrQuery,
        
        // ResolverName should match the GraphQL field name (camelCase)
        ResolverName = "employeesData"
    };

    private async Task ModeChange(ChangeEventArgs<string, DropDownData> args)
    {
        SelectedCategory = args?.Value ?? "HR";
        if (SelectedCategory == "PM")
        {
            adaptorOptions.Query = PmQuery;
            showHRColumns = false; showPMColumns = true; treeindex = 1;
            showEmail = false;
            headerName = "Assigned To";
        }
        else
        {
            adaptorOptions.Query = HrQuery;
            showHRColumns = true; showPMColumns = false; treeindex = 3;
            showEmail = true;
            headerName = "Name";
            if (tree is not null) await tree.ClearFilteringAsync();
        }
        await tree.CallStateHasChangedAsync();
    }

    public class EmployeeData
    {
        [JsonPropertyName("employeeID")] public string EmployeeID { get; set; } = "";
        [JsonPropertyName("managerID")] public string? ManagerID { get; set; }
        [JsonPropertyName("hasChild")] public bool HasChild { get; set; }
        [JsonPropertyName("name")] public string? Name { get; set; }
        [JsonPropertyName("lastName")] public string? LastName { get; set; }
        [JsonPropertyName("title")] public string? Title { get; set; }
        [JsonPropertyName("location")] public string? Location { get; set; }
        [JsonPropertyName("dateJoined")] public DateTime? DateJoined { get; set; }
        [JsonPropertyName("salaryPerMonth")] public decimal? SalaryPerMonth { get; set; }
        [JsonPropertyName("email")] public string? Email { get; set; }
        [JsonPropertyName("projectId")] public string? ProjectId { get; set; }
        [JsonPropertyName("projectDetails")] public string? ProjectDetails { get; set; }
        [JsonPropertyName("projectStatus")] public string? ProjectStatus { get; set; }
        [JsonPropertyName("priority")] public string? Priority { get; set; }
        [JsonPropertyName("progress")] public int? Progress { get; set; }
        [JsonPropertyName("projectStartDate")] public DateTime? ProjectStartDate { get; set; }
        [JsonPropertyName("projectEndDate")] public DateTime? ProjectEndDate { get; set; }
    }
}
```

**GraphQL Query Structure Explained in Detail**

The Query property is critical for understanding how data flows. Let's break down each component:

```graphql
query expenseRecordData($dataManager: DataManagerRequestInput!) {}
```

**Line Breakdown:**
- `query` - GraphQL keyword indicating a read operation
- `employeesData` - Name of the query (must match resolver name with camelCase)
- `($dataManager: DataManagerRequestInput!)` - Parameter declaration
  - `$dataManager` - Variable name (referenced as $dataManager throughout the query)
  - `: DataManagerRequestInput!` - Type specification
  - `!` - Exclamation mark means this parameter is **required** (not optional)

```graphql
query employeesData($dataManager: DataManagerRequestInput!) {}
```

**Line Breakdown:**
- `employeesData(...)` - Calls the resolver method in backend
- `dataManager: $dataManager` - Passes the $dataManager variable to the resolver
- The resolver receives this object and uses it to apply filters, sorts, searches, and pagination

```graphql
count
result {
    employeeID
    managerID
    ...
}
```
- `count` - Returns total number of records (used for pagination)
  - Example: If 150 total expense records exist, count = 150
  - TreeGrid uses this to calculate how many pages exist
- `result` - Contains the array of expense records
  - `{ ... }` - List of fields to return for each record
  - Each field must exist in the EmployeeData class
  - Only requested fields are returned (no over-fetching)

---

**Response Structure Example**

When the backend executes the query, it returns a **JSON response** in this exact structure:

```json
{
  "data": {
    "employeesData": {
      "count": 100,
      "result": [
        {
          "employeeID": "EMP001",
          "managerID": null,
          "hasChild": true,
          "name": "Ava Anderson",
          "lastName": "Anderson",
          "title": "Executive",
          "location": "Seattle",
          "dateJoined": "2016-01-05T00:00:00.000Z",
          "salaryPerMonth": 15000,
          "email": "ava.anderson001@company.com"
        },
        {
          "employeeID": "EMP011",
          "managerID": null,
          "hasChild": true,
          "name": "Mia Campbell",
          "lastName": "Campbell",
          "title": "Director",
          "location": "Chicago",
          "dateJoined": "2017-02-06T00:00:00.000Z",
          "salaryPerMonth": 16200,
          "email": "mia.campbell011@company.com"
        }
      ]
    }
  }
}
```

**Response Structure Explanation:**

| Part | Purpose | Example |
|------|---------|---------|
| `data` | Root object containing the query result | Always present in successful response |
| `employeesData` | Matches the query name (camelCase) | Contains count and result |
| `count` | Total number of records available | 2 (in this example) |
| `result` | Array of ExpenseRecord objects | [ {...}, {...} ] |
| Each field in result | Matches GraphQL query field names | Field values from database |

---

### Step 4: Add Toolbar with CRUD and search options

The toolbar provides buttons for adding, editing, deleting records, and searching the data.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Update the `<SfTreeGrid>` component to include the [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_Toolbar) property with CRUD and search options:

```razor
 <SfTreeGrid @ref="tree"
             TValue="EmployeeData"
             IdMapping="EmployeeID"
             ParentIdMapping="ManagerID"
             HasChildMapping="HasChild"
             TreeColumnIndex="@treeindex"
             Height="340"
             RowHeight="40"
             AllowPaging="true" Toolbar="@ToolbarItems">
     <SfDataManager Url="https://localhost:7213/graphql/"
                    Adaptor="Adaptors.GraphQLAdaptor"
                    GraphQLAdaptorOptions="@adaptorOptions">
    
    <!-- TreeGrid columns configuration -->
</SfTreeGrid>
```

3. Add the toolbar items list in the `@code` block:

```csharp
@code {
    private List<string> ToolbarItems = new List<string> { "Add", "Edit", "Delete", "Update", "Cancel", "Search"};
}
```

### Step 5: Implement Paging Feature

Paging divides large datasets into smaller pages to improve performance and usability.

**Instructions:**

1. The paging feature is already partially enabled in the `<TreeGrid>` component with [AllowPaging="true"](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_AllowPaging).
2. The page size is configured with [TreeGridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridPageSettings.html).
3. No additional code changes are required from the previous steps.


```razor
<SfTreeGrid @ref="tree"
            TValue="EmployeeData"
            IdMapping="EmployeeID"
            ParentIdMapping="ManagerID"
            HasChildMapping="HasChild"
            TreeColumnIndex="@treeindex"
            Height="340"
            RowHeight="40"
            AllowPaging="true">
    <SfDataManager Url="https://localhost:7213/graphql/"
                   Adaptor="Adaptors.GraphQLAdaptor"
                   GraphQLAdaptorOptions="@adaptorOptions">
    </SfDataManager>
    <TreeGridPageSettings PageSize="5"></TreeGridPageSettings>
    <!-- TreeGrid columns configuration -->
</SfTreeGrid>
```

4. Update the `EmployeesData` method in the `GraphQLQuery` class to handle paging:

```csharp
using System.Text.Json;

namespace TreeGrid_GraphQLAdaptor.Models
{
    // Defines the GraphQL resolver for handling TreeGrid requests.
    public class GraphQLQuery
    {
        // SINGLE ENTRYPOINT: handles roots, children, expand/collapse, expandall, loadchildondemand, filtering, search, sort, paging
        public EmployeesDataResponse EmployeesData(DataManagerRequestInput dataManager)
        {
            EnsureDataLoaded();

            // Parent detection (params first, then ManagerID== in where)
            string? parentId = TryGetParentIdFromParams(dataManager?.Params)
                            ?? TryGetParentIdFromWhere(dataManager?.Where);

            // CHILDREN SLICE: return only direct children of requested parent
            if (!string.IsNullOrWhiteSpace(parentId))
            {
                var children = _data
                    .Where(d => string.Equals(d.ManagerID, parentId, StringComparison.OrdinalIgnoreCase))
                    .ToList();

                return new EmployeesDataResponse
                {
                    Count = children.Count,
                    Result = children,
                    Items = children
                };
            }

            // ROOTS: proper root-only paging
            var roots = _data.Where(d => string.IsNullOrWhiteSpace(d.ManagerID)).ToList();
            int total = roots.Count;

            IEnumerable<EmployeeData> page = roots;
            if (dataManager?.Skip is int sk && dataManager.Take is int tk)
            {
                page = page.Skip(sk).Take(tk);
            }

            var list = page.ToList();
            return new EmployeesDataResponse
            {
                Count = total,
                Result = list,
                Items = list
            };
        }

        private static List<EmployeeData> _data = EnsureDataInternal();

        private static List<EmployeeData> EnsureDataInternal() => EmployeeData.GetAllRecords();

        private static void EnsureDataLoaded()
        {
            if (_data == null || _data.Count == 0) _data = EnsureDataInternal();
        }

        private static string? TryGetParentIdFromParams(object? prms)
        {
            if (!TryReadFromParams(prms, "parentId", out var v) || v is null) return null;
            return ToEmpId(v);
        }

        private static bool TryReadFromParams(object? prms, string key, out object? value)
        {
            value = null;
            if (prms == null) return false;

            // IDictionary<string, object>
            if (prms is IDictionary<string, object> dictObj)
                return dictObj.TryGetValue(key, out value);

            // IReadOnlyDictionary<string, object>
            if (prms is IReadOnlyDictionary<string, object> roDict)
                return roDict.TryGetValue(key, out value);

            // IDictionary<string, JsonElement>
            if (prms is IDictionary<string, JsonElement> dictJson)
            {
                if (dictJson.TryGetValue(key, out var je)) { value = je; return true; }
                return false;
            }

            // IEnumerable<KeyValuePair<string, object>>
            if (prms is IEnumerable<KeyValuePair<string, object>> kvs)
            {
                foreach (var kv in kvs)
                    if (string.Equals(kv.Key, key, StringComparison.OrdinalIgnoreCase))
                    { value = kv.Value; return true; }
            }

            // JsonElement object
            if (prms is JsonElement jeObj && jeObj.ValueKind == JsonValueKind.Object)
            {
                if (jeObj.TryGetProperty(key, out var je))
                { value = je; return true; }
            }

            return false;
        }

        private static string? TryGetParentIdFromWhere(List<WhereFilter>? where)
        {
            if (where == null || where.Count == 0) return null;

            foreach (var wf in where)
            {
                if (!string.IsNullOrWhiteSpace(wf.Field) &&
                    wf.Field.Equals("ManagerID", StringComparison.OrdinalIgnoreCase))
                {
                    var op = (wf.Operator ?? "equal").Trim().ToLowerInvariant();
                    if (op is "equal" or "eq")
                    {
                        if (wf.Value == null) return null;
                        return ToEmpId(wf.Value);
                    }
                }

                if (wf.Predicates != null && wf.Predicates.Count > 0)
                {
                    var nested = TryGetParentIdFromWhere(wf.Predicates);
                    if (nested != null || wf.Value == null) return nested;
                }
            }
            return null;
        }

        private static string? ToEmpId(object? v)
        {
            if (v == null) return null;
            if (v is string s)
            {
                if (int.TryParse(s, out var n)) return $"EMP{n:000}";
                return s;
            }
            if (v is int i) return $"EMP{i:000}";
            if (v is long l && l >= int.MinValue && l <= int.MaxValue) return $"EMP{(int)l:000}";
            if (v is JsonElement je)
            {
                return je.ValueKind switch
                {
                    JsonValueKind.Number => je.TryGetInt32(out var j) ? $"EMP{j:000}" : null,
                    JsonValueKind.String => int.TryParse(je.GetString(), out var k) ? $"EMP{k:000}" : je.GetString(),
                    JsonValueKind.Null => null,
                    _ => null
                };
            }
            return v.ToString();
        }
    }

    // Response type
    public class EmployeesDataResponse
    {
        [GraphQLName("count")]
        public int Count { get; set; }

        [GraphQLName("result")]
        public List<EmployeeData> Result { get; set; } = new();

        [GraphQLName("items")]
        public List<EmployeeData> Items { get; set; } = new();
    }
    
}
```

Fetches employee data by calling the **GetAllRecords** method, which is implemented in the **EmployeeData.cs** file.

```csharp
private static List<EmployeeData>? _employeesData;
public static List<EmployeeData> GetAllRecords()
{
    // Add code to return a list of "ExpenseRecord" to process it further.
    return _employeesData;
}
```


| Part | Purpose |
|------|---------|
| `dataManager.Skip` | Number of records to skip from the start (used to jump to the correct page) |
| `dataManager.Take` | Number of records to return for the current page (page size) |
| `dataManager.RequiresCounts` | Indicates whether the server should also return the total record count |

**How Paging Variables are Passed:**

When the tree grid requests a specific page, it automatically sends:
```json
{
  "dataManager": {
    "Skip": 10,
    "Take": 10,
    "RequiresCounts": true
  }
}
```
The backend resolver applies **Skip** and **Take**, then returns `count` and the paged `result`. Paging feature is now active with 10 records per page.

---


### Step 6: Implement Searching feature

Searching provides the capability to find specific records by entering keywords into the search box.

**Instructions:**

1. Ensure the toolbar includes the "Search" item.

```razor
<SfTreeGrid @ref="tree"
            TValue="EmployeeData"
            IdMapping="EmployeeID"
            ParentIdMapping="ManagerID"
            HasChildMapping="HasChild"
            TreeColumnIndex="@treeindex"
            Height="340"
            RowHeight="40"
            AllowPaging="true" Toolbar="@ToolbarItems">
    <SfDataManager Url="https://localhost:7213/graphql/"
                   Adaptor="Adaptors.GraphQLAdaptor"
                   GraphQLAdaptorOptions="@adaptorOptions">
    </SfDataManager>
    <TreeGridPageSettings PageSize="5"></TreeGridPageSettings>
    <!-- TreeGrid columns configuration -->
</SfTreeGrid>
```

2. Update the `EmployeesData` method in the `GraphQLQuery` class to handle searching:

```csharp
using System.Text.Json;

namespace TreeGrid_GraphQLAdaptor.Models
{
    // Defines the GraphQL resolver for handling TreeGrid data requests.
    public class GraphQLQuery
    {
        // - Roots: search applied, then paged by Skip/Take
        // - Children slice: ManagerID=parentId, search applied;
        public EmployeesDataResponse EmployeesData(DataManagerRequestInput dataManager)
        {
            EnsureDataLoaded();

            // Detect explicit children request from params first, then ManagerID filter in where (only to detect parentId)
            string? parentId = TryGetParentIdFromParams(dataManager?.Params)
                               ?? TryGetParentIdFromWhere(dataManager?.Where);

            // CHILDREN SLICE: return only direct children of requested parent (no paging)
            if (!string.IsNullOrWhiteSpace(parentId))
            {
                IEnumerable<EmployeeData> children = _data
                    .Where(d => string.Equals(d.ManagerID, parentId, StringComparison.OrdinalIgnoreCase));

                // Apply search to the current level only
                children = ApplySearch(children, dataManager?.Search ?? new List<SearchFilter>());

                var list = children.ToList();
                return new EmployeesDataResponse
                {
                    Count = list.Count,
                    Result = list,
                    Items = list
                };
            }

            // ROOTS: search then paging
            IEnumerable<EmployeeData> roots = _data.Where(d => string.IsNullOrWhiteSpace(d.ManagerID));

            // Apply search to roots
            roots = ApplySearch(roots, dataManager?.Search ?? new List<SearchFilter>());

            int total = roots.Count();

            // Paging
            if (dataManager?.Skip is int sk && dataManager.Take is int tk)
            {
                roots = roots.Skip(sk).Take(tk);
            }

            var page = roots.ToList();
            return new EmployeesDataResponse
            {
                Count = total,
                Result = page,
                Items = page
            };
        }

        private static List<EmployeeData> _data = EnsureDataInternal();

        private static List<EmployeeData> EnsureDataInternal() => EmployeeData.GetAllRecords();

        private static void EnsureDataLoaded()
        {
            if (_data == null || _data.Count == 0) _data = EnsureDataInternal();
        }

        private static string? TryGetParentIdFromParams(object? prms)
        {
            if (!TryReadFromParams(prms, "parentId", out var v) || v is null) return null;
            return ToEmpId(v);
        }

        private static bool TryReadFromParams(object? prms, string key, out object? value)
        {
            value = null;
            if (prms == null) return false;

            if (prms is IDictionary<string, object> dictObj)
                return dictObj.TryGetValue(key, out value);

            if (prms is IReadOnlyDictionary<string, object> roDict)
                return roDict.TryGetValue(key, out value);

            if (prms is IDictionary<string, JsonElement> dictJson)
            {
                if (dictJson.TryGetValue(key, out var je)) { value = je; return true; }
                return false;
            }

            if (prms is IEnumerable<KeyValuePair<string, object>> kvs)
            {
                foreach (var kv in kvs)
                    if (string.Equals(kv.Key, key, StringComparison.OrdinalIgnoreCase))
                    { value = kv.Value; return true; }
            }

            if (prms is JsonElement jeObj && jeObj.ValueKind == JsonValueKind.Object)
            {
                if (jeObj.TryGetProperty(key, out var je))
                { value = je; return true; }
            }

            return false;
        }

        private static string? TryGetParentIdFromWhere(List<WhereFilter>? where)
        {
            if (where == null || where.Count == 0) return null;

            foreach (var wf in where)
            {
                if (!string.IsNullOrWhiteSpace(wf.Field) &&
                    wf.Field.Equals("ManagerID", StringComparison.OrdinalIgnoreCase))
                {
                    var op = (wf.Operator ?? "equal").Trim().ToLowerInvariant();
                    if (op is "equal" or "eq")
                    {
                        if (wf.Value == null) return null;
                        return ToEmpId(wf.Value);
                    }
                }

                if (wf.Predicates != null && wf.Predicates.Count > 0)
                {
                    var nested = TryGetParentIdFromWhere(wf.Predicates);
                    if (nested != null || wf.Value == null) return nested;
                }
            }
            return null;
        }

        // Search only
        private static IEnumerable<EmployeeData> ApplySearch(IEnumerable<EmployeeData> data, List<SearchFilter> searches)
        {
            if (searches == null || searches.Count == 0) return data;

            IEnumerable<EmployeeData> current = data;

            foreach (var s in searches)
            {
                if (s == null) continue;
                var key = s.Key ?? string.Empty;
                if (string.IsNullOrWhiteSpace(key)) continue;

                var cmp = s.IgnoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;

                // If no fields provided, search a reasonable set
                var fields = (s.Fields != null && s.Fields.Count > 0)
                    ? s.Fields
                    : new List<string> {
                    "employeeID","managerID","name","firstName","lastName",
                    "title","location","email","projectId","projectDetails",
                    "projectStatus","priority","progress"
                    };

                current = current.Where(e =>
                {
                    foreach (var f in fields)
                    {
                        var val = GetFieldString(e, f);
                        if (!string.IsNullOrEmpty(val) && val.IndexOf(key, cmp) >= 0)
                            return true;
                    }
                    return false;
                });
            }

            return current;
        }

        // Map field to string for search
        private static string? GetFieldString(EmployeeData e, string field)
        {
            if (string.IsNullOrWhiteSpace(field)) return null;

            switch (field)
            {
                case "employeeID":
                case "EmployeeID": return e.EmployeeID;
                case "managerID":
                case "ManagerID": return e.ManagerID;
                case "hasChild":
                case "HasChild": return e.HasChild ? "true" : "false";
                case "name":
                case "Name": return e.Name;
                case "firstName":
                case "FirstName": return e.FirstName;
                case "lastName":
                case "LastName": return e.LastName;
                case "title":
                case "Title": return e.Title;
                case "location":
                case "Location": return e.Location;
                case "dateJoined":
                case "DateJoined": return e.DateJoined?.ToString("o");
                case "salaryPerMonth":
                case "SalaryPerMonth": return e.SalaryPerMonth?.ToString();
                case "email":
                case "Email": return e.Email;
                case "projectId":
                case "ProjectId": return e.ProjectId;
                case "projectDetails":
                case "ProjectDetails": return e.ProjectDetails;
                case "projectStatus":
                case "ProjectStatus": return e.ProjectStatus;
                case "priority":
                case "Priority": return e.Priority;
                case "progress":
                case "Progress": return e.Progress?.ToString();
                case "projectStartDate":
                case "ProjectStartDate": return e.ProjectStartDate?.ToString("o");
                case "projectEndDate":
                case "ProjectEndDate": return e.ProjectEndDate?.ToString("o");
                default: return null;
            }
        }

        private static string? ToEmpId(object? v)
        {
            if (v == null) return null;
            if (v is string s)
            {
                if (int.TryParse(s, out var n)) return $"EMP{n:000}";
                return s;
            }
            if (v is int i) return $"EMP{i:000}";
            if (v is long l && l >= int.MinValue && l <= int.MaxValue) return $"EMP{(int)l:000}";
            if (v is JsonElement je)
            {
                return je.ValueKind switch
                {
                    JsonValueKind.Number => je.TryGetInt32(out var j) ? $"EMP{j:000}" : null,
                    JsonValueKind.String => int.TryParse(je.GetString(), out var k) ? $"EMP{k:000}" : je.GetString(),
                    JsonValueKind.Null => null,
                    _ => null
                };
            }
            return v.ToString();
        }
    }

    // Response type
    public class EmployeesDataResponse
    {
        [GraphQLName("count")]
        public int Count { get; set; }

        [GraphQLName("result")]
        public List<EmployeeData> Result { get; set; } = new();

        [GraphQLName("items")]
        public List<EmployeeData> Items { get; set; } = new();
    }

}
```
The backend resolver receives this and processes the search filter in the `EmployeesData` method. Searching feature is now active.

---
### Step 7: Implement Sorting feature

Sorting enables organizing records by selecting column headers, arranging the data in ascending or descending order.

**Instructions:**

1. Ensure the `<SfTreeGrid>` component has [AllowSorting="true"](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_AllowSorting).

```razor
<SfTreeGrid @ref="tree"
            TValue="EmployeeData"
            IdMapping="EmployeeID"
            ParentIdMapping="ManagerID"
            HasChildMapping="HasChild"
            TreeColumnIndex="@treeindex"
            Height="340"
            RowHeight="40"
            AllowSorting="true"
            AllowPaging="true" Toolbar="@ToolbarItems">
    <SfDataManager Url="https://localhost:7213/graphql/"
                    Adaptor="Adaptors.GraphQLAdaptor"
                    GraphQLAdaptorOptions="@adaptorOptions">
    </SfDataManager>
    <TreeGridPageSettings PageSize="5"></TreeGridPageSettings>
    <!-- TreeGrid columns configuration -->
</SfTreeGrid>
```

2. Update the `EmployeesData` method in the `GraphQLQuery` class to handle sorting:

```csharp
using System.Text.Json;
using TreeGrid_GraphQLAdaptor.Models;

public class GraphQLQuery
{
    // - Roots: paged by Skip/Take and sorted if dataManager.Sorted provided
    // - Children slice: direct children for a parentId; sorted if dataManager.Sorted provided;
    public EmployeesDataResponse EmployeesData(DataManagerRequestInput dataManager)
    {
        EnsureDataLoaded();

        string? parentId = TryGetParentIdFromParams(dataManager?.Params)
                        ?? TryGetParentIdFromWhere(dataManager?.Where);

        // CHILDREN SLICE (no paging)
        if (!string.IsNullOrWhiteSpace(parentId))
        {
            var children = _data
                .Where(d => string.Equals(d.ManagerID, parentId, StringComparison.OrdinalIgnoreCase))
                .ToList();

            children = SortListStable(children, dataManager?.Sorted);
            return new EmployeesDataResponse
            {
                Count = children.Count,
                Result = children,
                Items = children
            };
        }

        // ROOTS: paging + optional sorting
        var roots = _data.Where(d => string.IsNullOrWhiteSpace(d.ManagerID)).ToList();
        int total = roots.Count;

        roots = SortListStable(roots, dataManager?.Sorted);

        IEnumerable<EmployeeData> page = roots;
        if (dataManager?.Skip is int sk && dataManager.Take is int tk)
        {
            page = page.Skip(sk).Take(tk);
        }

        var list = page.ToList();
        return new EmployeesDataResponse
        {
            Count = total,
            Result = list,
            Items = list
        };
    }

    private static List<EmployeeData> _data = EnsureDataInternal();

    private static List<EmployeeData> EnsureDataInternal() => EmployeeData.GetAllRecords();

    private static void EnsureDataLoaded()
    {
        if (_data == null || _data.Count == 0) _data = EnsureDataInternal();
    }

    private static string? TryGetParentIdFromParams(object? prms)
    {
        if (!TryReadFromParams(prms, "parentId", out var v) || v is null) return null;
        return ToEmpId(v);
    }

    private static bool TryReadFromParams(object? prms, string key, out object? value)
    {
        value = null;
        if (prms == null) return false;

        if (prms is IDictionary<string, object> dictObj)
            return dictObj.TryGetValue(key, out value);

        if (prms is IReadOnlyDictionary<string, object> roDict)
            return roDict.TryGetValue(key, out value);

        if (prms is IDictionary<string, JsonElement> dictJson)
        {
            if (dictJson.TryGetValue(key, out var je)) { value = je; return true; }
            return false;
        }

        if (prms is IEnumerable<KeyValuePair<string, object>> kvs)
        {
            foreach (var kv in kvs)
                if (string.Equals(kv.Key, key, StringComparison.OrdinalIgnoreCase))
                { value = kv.Value; return true; }
        }

        if (prms is JsonElement jeObj && jeObj.ValueKind == JsonValueKind.Object)
        {
            if (jeObj.TryGetProperty(key, out var je))
            { value = je; return true; }
        }

        return false;
    }

    private static string? TryGetParentIdFromWhere(List<WhereFilter>? where)
    {
        if (where == null || where.Count == 0) return null;

        foreach (var wf in where)
        {
            if (!string.IsNullOrWhiteSpace(wf.Field) &&
                wf.Field.Equals("ManagerID", StringComparison.OrdinalIgnoreCase))
            {
                var op = (wf.Operator ?? "equal").Trim().ToLowerInvariant();
                if (op is "equal" or "eq")
                {
                    if (wf.Value == null) return null;
                    return ToEmpId(wf.Value);
                }
            }

            if (wf.Predicates != null && wf.Predicates.Count > 0)
            {
                var nested = TryGetParentIdFromWhere(wf.Predicates);
                if (nested != null || wf.Value == null) return nested;
            }
        }
        return null;
    }

    private static string? ToEmpId(object? v)
    {
        if (v == null) return null;
        if (v is string s)
        {
            if (int.TryParse(s, out var n)) return $"EMP{n:000}";
            return s;
        }
        if (v is int i) return $"EMP{i:000}";
        if (v is long l && l >= int.MinValue && l <= int.MaxValue) return $"EMP{(int)l:000}";
        if (v is JsonElement je)
        {
            return je.ValueKind switch
            {
                JsonValueKind.Number => je.TryGetInt32(out var j) ? $"EMP{j:000}" : null,
                JsonValueKind.String => int.TryParse(je.GetString(), out var k) ? $"EMP{k:000}" : je.GetString(),
                JsonValueKind.Null => null,
                _ => null
            };
        }
        return v.ToString();
    }

    private static List<EmployeeData> SortListStable(List<EmployeeData> list, List<Sort>? sorts)
    {
        if (sorts == null || sorts.Count == 0)
            return list.OrderBy(x => x.EmployeeID, StringComparer.OrdinalIgnoreCase).ToList();

        IOrderedEnumerable<EmployeeData>? ordered = null;

        for (int i = 0; i < sorts.Count; i++)
        {
            var s = sorts[i];
            bool desc = string.Equals(s.Direction, "desc", StringComparison.OrdinalIgnoreCase) ||
                        string.Equals(s.Direction, "descending", StringComparison.OrdinalIgnoreCase);

            Func<EmployeeData, object?> key = s.Name switch
            {
                "employeeID" => e => e.EmployeeID,
                "managerID" => e => e.ManagerID,
                "name" => e => e.Name,
                "firstName" => e => e.FirstName,
                "lastName" => e => e.LastName,
                "title" => e => e.Title,
                "location" => e => e.Location,
                "dateJoined" => e => e.DateJoined,
                "salaryPerMonth" => e => e.SalaryPerMonth,
                "email" => e => e.Email,
                "projectId" => e => e.ProjectId,
                "projectDetails" => e => e.ProjectDetails,
                "projectStatus" => e => e.ProjectStatus,
                "priority" => e => e.Priority,
                "progress" => e => e.Progress,
                "projectStartDate" => e => e.ProjectStartDate,
                "projectEndDate" => e => e.ProjectEndDate,
                _ => e => e.EmployeeID
            };

            ordered = i == 0
                ? (desc ? list.OrderByDescending(key) : list.OrderBy(key))
                : (desc ? ordered!.ThenByDescending(key) : ordered!.ThenBy(key));
        }

        return ordered!.ThenBy(x => x.EmployeeID, StringComparer.OrdinalIgnoreCase).ToList();
    }
}

// Response type
public class EmployeesDataResponse
{
    [GraphQLName("count")]
    public int Count { get; set; }

    [GraphQLName("result")]
    public List<EmployeeData> Result { get; set; } = new();

    [GraphQLName("items")]
    public List<EmployeeData> Items { get; set; } = new();
}
```

**How Sort Variables are Passed:**

When a column header is selected for sorting, the TreeGrid automatically sends:
```json
{
  "dataManager": {
      "Sorted": [
        {
          "Name": "EmployeeID",
          "Direction": "Descending"
        }
      ],
      "Skip": 0,
      "Take": 10,
      "RequiresCounts": true
    }
}
```

The backend resolver receives this and processes the sort specification in the `EmployeesData` method. Multiple sorting conditions can be applied sequentially by holding the **Ctrl** key and selecting additional column headers. Sorting feature is now active.

---

 ### Step 8: Implement Filtering feature
 
 Filtering enables narrowing down records by applying conditions to column values. Filtering can be performed by selecting checkbox-based filters or by using comparison operators such as equals, greater than, less than, and other supported operators.
 
 **Instructions:**
 
 1. Ensure the ``<SfTreeGrid>`` component has [AllowFiltering="true"](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_AllowFiltering).
 
 ``````razor
<SfTreeGrid @ref="tree"
            TValue="EmployeeData"
            IdMapping="EmployeeID"
            ParentIdMapping="ManagerID"
            HasChildMapping="HasChild"
            TreeColumnIndex="@treeindex"
            Height="340"
            RowHeight="40"
            AllowFiltering="true"
            AllowPaging="true" Toolbar="@ToolbarItems">
    <SfDataManager Url="https://localhost:7213/graphql/"
                   Adaptor="Adaptors.GraphQLAdaptor"
                   GraphQLAdaptorOptions="@adaptorOptions">
    </SfDataManager>
    <TreeGridPageSettings PageSize="5"></TreeGridPageSettings>
     <!-- TreeGrid columns configuration -->
 </SfTreeGrid>
 ``````

 2. Update the ``EmployeesData`` method in the ``GraphQLQuery`` class to handle filtering:

 ``````csharp
 // Defines the GraphQL resolver for handling TreeGrid requests.
using System.Text.Json;
using TreeGrid_GraphQLAdaptor.Models;

public class GraphQLQuery
{
    // - Roots: filters applied, then paged by Skip/Take
    // - Children slice: ManagerID=parentId, then filters applied; no paging
    public EmployeesDataResponse EmployeesData(DataManagerRequestInput dataManager)
    {
        EnsureDataLoaded();

        // Detect explicit children request from params first, then ManagerID filter in where
        string? parentId = TryGetParentIdFromParams(dataManager?.Params)
                            ?? TryGetParentIdFromWhere(dataManager?.Where);

        // CHILDREN SLICE: return only direct children of requested parent (no paging)
        if (!string.IsNullOrWhiteSpace(parentId))
        {
            var children = _data
                .Where(d => string.Equals(d.ManagerID, parentId, StringComparison.OrdinalIgnoreCase))
                .ToList();

            // Apply non-parent filters to the current level
            children = ApplyWhereExcludingParent(children, dataManager?.Where ?? new List<WhereFilter>()).ToList();

            return new EmployeesDataResponse
            {
                Count = children.Count,
                Result = children,
                Items = children
            };
        }

        // ROOTS: apply filters, then paging
        var roots = _data.Where(d => string.IsNullOrWhiteSpace(d.ManagerID)).ToList();
        roots = ApplyWhereExcludingParent(roots, dataManager?.Where ?? new List<WhereFilter>()).ToList();

        int total = roots.Count;

        IEnumerable<EmployeeData> page = roots;
        if (dataManager?.Skip is int sk && dataManager.Take is int tk)
        {
            page = page.Skip(sk).Take(tk);
        }

        var list = page.ToList();
        return new EmployeesDataResponse
        {
            Count = total,
            Result = list,
            Items = list
        };
    }

    private static List<EmployeeData> _data = EnsureDataInternal();

    private static List<EmployeeData> EnsureDataInternal() => EmployeeData.GetAllRecords();

    private static void EnsureDataLoaded()
    {
        if (_data == null || _data.Count == 0) _data = EnsureDataInternal();
    }

    private static string? TryGetParentIdFromParams(object? prms)
    {
        if (!TryReadFromParams(prms, "parentId", out var v) || v is null) return null;
        return ToEmpId(v);
    }

    private static bool TryReadFromParams(object? prms, string key, out object? value)
    {
        value = null;
        if (prms == null) return false;

        if (prms is IDictionary<string, object> dictObj)
            return dictObj.TryGetValue(key, out value);

        if (prms is IReadOnlyDictionary<string, object> roDict)
            return roDict.TryGetValue(key, out value);

        if (prms is IDictionary<string, JsonElement> dictJson)
        {
            if (dictJson.TryGetValue(key, out var je)) { value = je; return true; }
            return false;
        }

        if (prms is IEnumerable<KeyValuePair<string, object>> kvs)
        {
            foreach (var kv in kvs)
                if (string.Equals(kv.Key, key, StringComparison.OrdinalIgnoreCase))
                { value = kv.Value; return true; }
        }

        if (prms is JsonElement jeObj && jeObj.ValueKind == JsonValueKind.Object)
        {
            if (jeObj.TryGetProperty(key, out var je))
            { value = je; return true; }
        }

        return false;
    }

    private static string? TryGetParentIdFromWhere(List<WhereFilter>? where)
    {
        if (where == null || where.Count == 0) return null;

        foreach (var wf in where)
        {
            if (!string.IsNullOrWhiteSpace(wf.Field) &&
                wf.Field.Equals("ManagerID", StringComparison.OrdinalIgnoreCase))
            {
                var op = (wf.Operator ?? "equal").Trim().ToLowerInvariant();
                if (op is "equal" or "eq")
                {
                    if (wf.Value == null) return null;
                    return ToEmpId(wf.Value);
                }
            }

            if (wf.Predicates != null && wf.Predicates.Count > 0)
            {
                var nested = TryGetParentIdFromWhere(wf.Predicates);
                if (nested != null || wf.Value == null) return nested;
            }
        }
        return null;
    }

    // Apply structured Where (respect nested groups, AND/OR), ignoring ManagerID match here
    private static IEnumerable<EmployeeData> ApplyWhereExcludingParent(IEnumerable<EmployeeData> data, List<WhereFilter> where)
    {
        if (where == null || where.Count == 0) return data;

        bool Match(EmployeeData e, WhereFilter f)
        {
            // ignore ManagerID in non-parent filtering
            if ((f.Field ?? string.Empty).Equals("ManagerID", StringComparison.OrdinalIgnoreCase))
                return true;

            var op = (f.Operator ?? "equal").Trim().ToLowerInvariant();
            var ignoreCase = f.IgnoreCase ?? true;
            var cmp = ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;

            var right = f.Value?.ToString() ?? string.Empty;
            var left = GetFieldString(e, f.Field ?? string.Empty) ?? string.Empty;

            return op switch
            {
                "equal" or "==" or "eq" => string.Equals(left, right, cmp),
                "notequal" or "!=" or "ne" or "neq" => !string.Equals(left, right, cmp),
                "contains" => left.IndexOf(right, cmp) >= 0,
                "startswith" => left.StartsWith(right, cmp),
                "endswith" => left.EndsWith(right, cmp),
                _ => string.Equals(left, right, cmp)
            };
        }

        IEnumerable<EmployeeData> ApplyNode(IEnumerable<EmployeeData> src, WhereFilter f)
        {
            if (f.IsComplex == true && f.Predicates != null && f.Predicates.Count > 0)
            {
                var condition = (f.Condition ?? "and").Trim().ToLowerInvariant();

                if (condition == "or")
                {
                    var set = new HashSet<string>(StringComparer.OrdinalIgnoreCase);
                    var bag = new List<EmployeeData>();
                    foreach (var p in f.Predicates)
                    {
                        foreach (var item in ApplyNode(src, p))
                        {
                            if (set.Add(item.EmployeeID))
                                bag.Add(item);
                        }
                    }
                    return bag;
                }
                else
                {
                    var current = src;
                    foreach (var p in f.Predicates)
                        current = ApplyNode(current, p);
                    return current;
                }
            }
            else
            {
                return src.Where(e => Match(e, f));
            }
        }

        var result = data;
        foreach (var f in where)
            result = ApplyNode(result, f);

        return result;
    }

    // Map field name to string value for filtering
    private static string? GetFieldString(EmployeeData e, string field)
    {
        if (string.IsNullOrWhiteSpace(field)) return null;

        switch (field)
        {
            case "employeeID":
            case "EmployeeID": return e.EmployeeID;
            case "managerID":
            case "ManagerID": return e.ManagerID;
            case "hasChild":
            case "HasChild": return e.HasChild ? "true" : "false";
            case "name":
            case "Name": return e.Name;
            case "firstName":
            case "FirstName": return e.FirstName;
            case "lastName":
            case "LastName": return e.LastName;
            case "title":
            case "Title": return e.Title;
            case "location":
            case "Location": return e.Location;
            case "dateJoined":
            case "DateJoined": return e.DateJoined?.ToString("o");
            case "salaryPerMonth":
            case "SalaryPerMonth": return e.SalaryPerMonth?.ToString();
            case "email":
            case "Email": return e.Email;
            case "projectId":
            case "ProjectId": return e.ProjectId;
            case "projectDetails":
            case "ProjectDetails": return e.ProjectDetails;
            case "projectStatus":
            case "ProjectStatus": return e.ProjectStatus;
            case "priority":
            case "Priority": return e.Priority;
            case "progress":
            case "Progress": return e.Progress?.ToString();
            case "projectStartDate":
            case "ProjectStartDate": return e.ProjectStartDate?.ToString("o");
            case "projectEndDate":
            case "ProjectEndDate": return e.ProjectEndDate?.ToString("o");
            default: return null;
        }
    }

    private static string? ToEmpId(object? v)
    {
        if (v == null) return null;
        if (v is string s)
        {
            if (int.TryParse(s, out var n)) return $"EMP{n:000}";
            return s;
        }
        if (v is int i) return $"EMP{i:000}";
        if (v is long l && l >= int.MinValue && l <= int.MaxValue) return $"EMP{(int)l:000}";
        if (v is JsonElement je)
        {
            return je.ValueKind switch
            {
                JsonValueKind.Number => je.TryGetInt32(out var j) ? $"EMP{j:000}" : null,
                JsonValueKind.String => int.TryParse(je.GetString(), out var k) ? $"EMP{k:000}" : je.GetString(),
                JsonValueKind.Null => null,
                _ => null
            };
        }
        return v.ToString();
    }
}

// Response type
public class EmployeesDataResponse
{
    [GraphQLName("count")]
    public int Count { get; set; }

    [GraphQLName("result")]
    public List<EmployeeData> Result { get; set; } = new();

    [GraphQLName("items")]
    public List<EmployeeData> Items { get; set; } = new();
}
 ``````

  **Supported Filter Operators:**

 | Operator | Purpose | Example |
 |----------|---------|---------|
 | equal | Exact match | Amount equals 500 |
 | notequal | Not equal to value | Status not equal to "Rejected" |
 | contains | Contains substring (case-insensitive) | Description contains "travel" |
 | startswith | Starts with value | EmployeeName starts with "John" |
 | endswith | Ends with value | Category ends with "Supplies" |
 | greater than | Greater than numeric value | Amount > 1000 |
 | less than | Less than numeric value | TaxPct < 0.15 |
 | greater than equal | Greater than or equal | Amount >= 500 |
 | less than equal | Less than or equal | TaxPct <= 0.10 |

 **How Filter Variables are Passed:**

 When filter conditions are applied, the TreeGrid automatically sends:
 ``````json
{
   "dataManager": {
       "Where": [
            {
              "Condition": "and",
              "Predicates": [
                  {
                      "Field": "title",
                      "Operator": "equal",
                      "Value": "Director",
                      "Predicates": []
                  }
              ]
            }
        ],
       "Skip": 0,
       "Take": 10,
       "RequiresCounts": true
    }
}
 ``````

 **Filter Logic**

- Top-level "Where" is an array of filter groups; groups are combined with AND by the resolver.
- This specific group:
  - Condition: "and" — combine its predicates with AND.
  - Predicates: one predicate that filters the "title" field.
    - Field: "title" → maps to EmployeeData.Title (GraphQL / camelCase).
    - Operator: "equal" → exact match comparison.
    - Value: "Director" → filter value.
    - Predicates: [] → no nested filters under this predicate.
- Skip: 0 and Take: 10 — return the first page (offset 0, up to 10 items).
- RequiresCounts: true — request total matching count for paging UI.

 The backend resolver receives this and processes the filter conditions in the `EmployeesData` method using recursive evaluation to handle any depth of nesting. Filtering feature is now active.

 ---

### Perform CRUD Operations
 
 CRUD operations (Create, Read, Update, Delete) provide complete data‑management capabilities within the TreeGrid. The TreeGrid offers built‑in dialogs and action buttons to perform these operations, while backend resolvers execute the corresponding data modifications.

 Add the TreeGrid `TreeGridEditSettings` and `Toolbar` configuration to enable create, read, update, and delete (CRUD) operations.
 
 ``````razor
 <SfTreeGrid @ref="tree"
            TValue="EmployeeData"
            IdMapping="EmployeeID"
            ParentIdMapping="ManagerID"
            HasChildMapping="HasChild"
            TreeColumnIndex="@treeindex"
            Height="340"
            RowHeight="40"
            AllowFiltering="true"
            AllowPaging="true" Toolbar="@ToolbarItems">
    <SfDataManager Url="https://localhost:7213/graphql/"
                   Adaptor="Adaptors.GraphQLAdaptor"
                   GraphQLAdaptorOptions="@adaptorOptions">
    </SfDataManager>
    <TreeGridPageSettings PageSize="5"></TreeGridPageSettings>
    <TreeGridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></TreeGridEditSettings>
     <!-- TreeGrid columns configuration -->
 </SfTreeGrid>
 ``````
 
Add the toolbar items list in the `@code` block:

```csharp
@code {
    private List<string> ToolbarItems = new List<string> { "Add", "Edit", "Delete", "Update", "Cancel", "Search"};

    // CustomAdaptor class code...
}
```

**Insert**
 
 The Insert operation enables adding new expense records to the system. When the Add button in the toolbar is selected, the TreeGrid displays a dialog containing the required input fields. After the data is entered and submitted, a GraphQL mutation transmits the new record to the backend for creation.
 
 **Instructions:**
 
 1. Update the ``GraphQLAdaptorOptions`` in the ``@code`` block to include the Insert mutation:

 ``````csharp
 @code {
    private GraphQLAdaptorOptions adaptorOptions = new GraphQLAdaptorOptions
    {
        Query = HrQuery,
        
        // ResolverName should match the GraphQL field name (camelCase)
        ResolverName = "employeesData",

        Mutation = new GraphQLMutation
        {
            Insert = @"mutation create($record: EmployeeDataInput!, $index: Int!, $action: String!, $additionalParameters: Any) {
                createEmployee(record: $record, index: $index, action: $action, additionalParameters: $additionalParameters) {
                    employeeID
                    managerID
                    hasChild
                    name
                    lastName
                    title
                    location
                    dateJoined
                    salaryPerMonth
                    email
                    projectId
                    projectDetails
                    projectStatus
                    priority
                    progress
                    projectStartDate
                    projectEndDate
                }
            }"
        }
    };
 }
 ``````

 2. Implement the ``CreateEmployee`` method in the ``GraphQLMutation`` class:

 ``````csharp
 namespace TreeGrid_GraphQLAdaptor.Models
{
     public class GraphQLMutation
    {
        public EmployeeData CreateEmployee(
            EmployeeData record,
            int index,
            string action,
            [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters)
        {
            var employees = EmployeeData.GetAllRecords();

            // Accept provided values; caller should supply EmployeeID (e.g., EMP001) and optional ManagerID.
            var entity = new EmployeeData
            {
                EmployeeID = record.EmployeeID,
                FirstName = record.FirstName,
                LastName = record.LastName,
                Title = record.Title,
                ManagerID = record.ManagerID,
                HasChild = record.HasChild,
                Name = record.Name,
                Location = record.Location,
                DateJoined = record.DateJoined,
                SalaryPerMonth = record.SalaryPerMonth,
                Email = record.Email,
                ProjectDetails = record.ProjectDetails,
                ProjectStatus = record.ProjectStatus,
                Priority = record.Priority,
                Progress = record.Progress,
                ProjectStartDate = record.ProjectStartDate,
                ProjectEndDate = record.ProjectEndDate,
                ProjectId = record.ProjectId // e.g., PRJ001
            };

            if (!string.IsNullOrWhiteSpace(entity.ManagerID))
            {
                var manager = employees.FirstOrDefault(e => string.Equals(e.EmployeeID, entity.ManagerID, System.StringComparison.OrdinalIgnoreCase));
                if (manager != null) manager.HasChild = true;
            }

            if (index >= 0 && index <= employees.Count)
                employees.Insert(index, entity);
            else
                employees.Add(entity);

            return entity;
        }
    }
}
 ``````

**Insert Operation Logic Breakdown:**  

| Step | Purpose | Implementation |
|------|---------|----------------|
| **1. Receive Input** | Backend receives the new record object from the client | `CreateEmployee` receives `record: EmployeeData` — the client must supply `employeeID` (server does not auto‑generate IDs in this sample) |
| **2. Validate Manager** | Ensure manager state is consistent | If `ManagerID` is provided and a matching manager exists, set that manager's `HasChild = true` |
| **3. Insert Record** | Place the new record in the in‑memory list | Insert at `index` when 0 ≤ index ≤ count; otherwise append (`employees.Insert(index, entity)` or `employees.Add(entity)`) |
| **4. Return Created** | Return the created entity back to the client | `CreateEmployee` returns the created `EmployeeData` object (with the same fields supplied) |

 **How Insert Mutation Parameters are Passed:**

 Unlike data operations such as searching, filtering, and sorting—which rely on the **DataManagerRequestInput** structure—CRUD operations pass values directly to the corresponding **GraphQL mutation**. When the Add action is triggered, the dialog is completed, and the form is submitted, the GraphQL adaptor constructs the mutation using the provided field values and sends the following parameters:

 **GraphQL Mutation Request:**

 ```graphql
 mutation create($record: EmployeeDataInput!, $index: Int!, $action: String!, $additionalParameters: Any) {
    createEmployee(record: $record, index: $index, action: $action, additionalParameters: $additionalParameters) {
        employeeID
        managerID
        hasChild
        name
        lastName
        title
        location
        dateJoined
        salaryPerMonth
        email
        projectId
        projectDetails
        projectStatus
        priority
        progress
        projectStartDate
        projectEndDate
    }
}
 ```

 **Variables Sent with the Request:**

 ```json
 {
  "record": {
    "employeeID": "EMP2000",
    "managerID": null,
    "firstName": "Alice",
    "lastName": "Johnson",
    "name": "Alice Johnson",
    "title": "Engineer",
    "location": "Seattle",
    "dateJoined": "2024-06-01T00:00:00Z",
    "salaryPerMonth": 8500,
    "email": "alice.johnson151@company.com",
    "projectDetails": "Mobile App",
    "projectStatus": "Open",
    "priority": "High",
    "progress": 5,
    "projectStartDate": "2024-06-01T00:00:00Z",
    "projectEndDate": "2025-06-01T00:00:00Z",
    "projectId": "PRJ151",
    "hasChild": false
  },
  "index": 0,
  "action": "add",
  "additionalParameters": {}
}
 ```

 **Parameter Explanation:**

 | Parameter | Type | Purpose | Example |
 |-----------|------|---------|---------|
 | `record` | `EmployeeData` | New employee object; must include `employeeID` when using this sample implementation.| Expense data filled in the add form |
 | `index` | `int` | The position where the new record should be inserted (0 = top) | `0` for insert at beginning, `-1` or higher than count for append |
 | `action` | `string` | Type of action being performed (usually "add" for insert) | `"add"` |
 | `additionalParameters` | `Any` | Extra context or custom parameters from the TreeGrid | Empty object `{}` or additional metadata |

 **Backend Response:**

 The mutation returns the created record directly:

 ```json
 {
  "data": {
    "createEmployee": {
      "employeeID": "EMP2000",
      "managerID": null,
      "hasChild": false,
      "name": "Alice Johnson",
      "lastName": "Johnson",
      "title": "Engineer",
      "location": "Seattle",
      "dateJoined": "2024-06-01T00:00:00.000Z",
      "salaryPerMonth": 8500,
      "email": "alice.johnson151@company.com",
      "projectId": "PRJ151",
      "projectDetails": "Mobile App",
      "projectStatus": "Open",
      "priority": "High",
      "progress": 5,
      "projectStartDate": "2024-06-01T00:00:00.000Z",
      "projectEndDate": "2025-06-01T00:00:00.000Z"
    }
  }
}
 ```

**Update**
The Update operation enables modifying existing expense records. When the Edit action is selected from the toolbar and a row is chosen, the TreeGrid displays a dialog populated with the current record values. After the data is updated and the form is submitted, a GraphQL mutation transmits the modified record to the backend for processing.

**Instructions:**

1. Update the `GraphQLAdaptorOptions` in the `@code` block to include the Update mutation:

```csharp
@code {
    private GraphQLAdaptorOptions adaptorOptions = new GraphQLAdaptorOptions
    {
        Query = HrQuery,
        
        // ResolverName should match the GraphQL field name (camelCase)
        ResolverName = "employeesData",

        Mutation = new GraphQLMutation
        {
            Update = @"mutation update($record: EmployeeDataInput!, $action: String!, $primaryColumnName: String!, $primaryColumnValue: String!, $additionalParameters: Any) {
                updateEmployee(record: $record, action: $action, primaryColumnName: $primaryColumnName, primaryColumnValue: $primaryColumnValue, additionalParameters: $additionalParameters) {
                    employeeID
                    managerID
                    hasChild
                    name
                    lastName
                    title
                    location
                    dateJoined
                    salaryPerMonth
                    email
                    projectId
                    projectDetails
                    projectStatus
                    priority
                    progress
                    projectStartDate
                    projectEndDate
                }
            }"
        }
    };
}
```

2. Implement the `UpdateEmployee` method in the `GraphQLMutation` class:

```csharp
namespace TreeGrid_GraphQLAdaptor.Models
{
     public class GraphQLMutation
    {
       public EmployeeData? UpdateEmployee(
            EmployeeData record,
            string action,
            string primaryColumnName,
            string primaryColumnValue,
            [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters)
        {
            var employees = EmployeeData.GetAllRecords();

            var keyName = primaryColumnName?.ToLowerInvariant();
            var existing = keyName switch
            {
                "employeeid" => employees.FirstOrDefault(x => string.Equals(x.EmployeeID, primaryColumnValue, System.StringComparison.OrdinalIgnoreCase)),
                _ => employees.FirstOrDefault(x => string.Equals(x.EmployeeID, primaryColumnValue, System.StringComparison.OrdinalIgnoreCase))
            };
            if (existing == null) return null;

            if (record.FirstName != null) existing.FirstName = record.FirstName;
            if (record.LastName != null) existing.LastName = record.LastName;
            if (record.Title != null) existing.Title = record.Title;
            if (record.Name != null) existing.Name = record.Name;
            if (record.Location != null) existing.Location = record.Location;
            if (record.DateJoined.HasValue) existing.DateJoined = record.DateJoined;
            if (record.SalaryPerMonth.HasValue) existing.SalaryPerMonth = record.SalaryPerMonth;
            if (record.Email != null) existing.Email = record.Email;
            if (record.ProjectDetails != null) existing.ProjectDetails = record.ProjectDetails;
            if (record.ProjectStatus != null) existing.ProjectStatus = record.ProjectStatus;
            if (record.Priority != null) existing.Priority = record.Priority;
            if (record.Progress.HasValue) existing.Progress = record.Progress;
            if (record.ProjectStartDate.HasValue) existing.ProjectStartDate = record.ProjectStartDate;
            if (record.ProjectEndDate.HasValue) existing.ProjectEndDate = record.ProjectEndDate;
            if (record.ProjectId != null) existing.ProjectId = record.ProjectId;

            if (!string.IsNullOrWhiteSpace(record.ManagerID) &&
                !string.Equals(record.ManagerID, existing.ManagerID, System.StringComparison.OrdinalIgnoreCase))
            {
                var oldManagerId = existing.ManagerID;
                existing.ManagerID = record.ManagerID;

                if (!string.IsNullOrWhiteSpace(existing.ManagerID))
                {
                    var newManager = employees.FirstOrDefault(e => string.Equals(e.EmployeeID, existing.ManagerID, System.StringComparison.OrdinalIgnoreCase));
                    if (newManager != null) newManager.HasChild = true;
                }

                if (!string.IsNullOrWhiteSpace(oldManagerId))
                {
                    var oldManager = employees.FirstOrDefault(e => string.Equals(e.EmployeeID, oldManagerId, System.StringComparison.OrdinalIgnoreCase));
                    if (oldManager != null)
                    {
                        oldManager.HasChild = employees.Any(e => string.Equals(e.ManagerID, oldManager.EmployeeID, System.StringComparison.OrdinalIgnoreCase));
                    }
                }
            }

            if (record.HasChild) existing.HasChild = record.HasChild;

            return existing;
        }
    }
}
```

**Update Operation Logic Breakdown:**

| Step | Purpose | Implementation |
|------|---------|----------------|
| **1. Locate Record** | Find the existing employee by primary key | `UpdateEmployee` looks up by `primaryColumnName` (case‑insensitive); default lookup is by `employeeID` |
| **2. Validate Existence** | Ensure record exists before modifying | `if (existing == null) return null;` |
| **3. Apply Field Changes** | Copy only provided fields from incoming `record` | Each property is set only when the incoming value is non-null (or HasValue for nullable value types), e.g. `if (record.FirstName != null) existing.FirstName = record.FirstName;` |
| **4. Handle Manager Change** | Maintain parent/child relationship consistency | If `ManagerID` changes: assign `existing.ManagerID = record.ManagerID`; set `newManager.HasChild = true` when present; recompute `oldManager.HasChild` by checking remaining children |
| **5. Preserve Unchanged Data** | Avoid overwriting unspecified fields | Unspecified/null fields are left intact (ID is preserved) |
| **6. Update HasChild Flag** | Allow explicit HasChild updates from client | `if (record.HasChild) existing.HasChild = record.HasChild;` |
| **7. Return Updated** | Return the modified EmployeeData instance | The resolver returns the mutated `existing` object (or null if not found) |

**How Update Mutation Parameters are Passed:**

When the Edit action is invoked, the dialog is modified, and the changes are submitted, the **GraphQL adaptor** constructs the **mutation** using the following parameters:

**GraphQL Mutation Request:**

```graphql
mutation update($record: EmployeeDataInput!, $action: String!, $primaryColumnName: String!, $primaryColumnValue: String!, $additionalParameters: Any) {
    updateEmployee(record: $record, action: $action, primaryColumnName: $primaryColumnName, primaryColumnValue: $primaryColumnValue, additionalParameters: $additionalParameters) {
        employeeID
        managerID
        hasChild
        name
        lastName
        title
        location
        dateJoined
        salaryPerMonth
        email
        projectId
        projectDetails
        projectStatus
        priority
        progress
        projectStartDate
        projectEndDate
    }
}
```

**Variables Sent with the Request:**

```json
{
  "record": {
    "employeeID": "EMP021",
    "firstName": "Alice",
    "lastName": "Johnson",
    "name": "Alice Johnson",
    "hasChild": true
  },
  "action": "save",
  "primaryColumnName": "EmployeeID",
  "primaryColumnValue": "EMP021",
  "additionalParameters": {}
}
```

**Parameter Explanation:**

| Parameter | Type | Purpose | Example |
|-----------|------|---------|---------|
| `record` | `EmployeeData` | Object with fields to update; only non-null / HasValue fields are applied | See JSON `record` above |
| `action` | `string` | Action descriptor from the tree grid (commonly `"save"` for updates) | `"save"` |
| `primaryColumnName` | `string` | Name of the primary key column used by the tree grid/backend (case‑insensitive) | `"EmployeeID"` |
| `primaryColumnValue` | `string` | Primary key value identifying the record to update | `"EMP011"` |
| `additionalParameters` | `Any` | Optional free form metadata passed through by the adaptor | `{}` or custom context |

**Backend Response:**

The mutation returns the updated record with all changes applied:

```json
{
  "data": {
    "updateEmployee": {
      "employeeID": "EMP021",
      "managerID": null,
      "hasChild": true,
      "name": "Alice Johnson",
      "lastName": "Johnson",
      "title": "Manager",
      "location": "New York",
      "dateJoined": "2018-03-07T00:00:00.000Z",
      "salaryPerMonth": 17400,
      "email": "abigail.edwards021@company.com",
      "projectId": "PRJ021",
      "projectDetails": "Backup Service",
      "projectStatus": "Open",
      "priority": "Medium",
      "progress": 74,
      "projectStartDate": "2024-03-03T00:00:00.000Z",
      "projectEndDate": "2025-09-03T00:00:00.000Z"
    }
  }
}
```

---

**Delete**

The Delete operation enables removing expense records from the system. When the Delete action is selected from the toolbar, a GraphQL mutation issues a delete request to the backend using only the primary key value.

**Instructions:**

1. Update the `GraphQLAdaptorOptions` in the `@code` block to include the Delete mutation:

```csharp
@code {
    private GraphQLAdaptorOptions adaptorOptions = new GraphQLAdaptorOptions
    {
        Query = HrQuery,
        
        // ResolverName should match the GraphQL field name (camelCase)
        ResolverName = "employeesData",

        Mutation = new GraphQLMutation
        {
            Delete = @"mutation delete($primaryColumnValue: String!, $action: String!, $primaryColumnName: String!, $additionalParameters: Any) {
                deleteEmployee(primaryColumnValue: $primaryColumnValue, action: $action, primaryColumnName: $primaryColumnName, additionalParameters: $additionalParameters) {
                    employeeID
                    managerID
                    hasChild
                    name
                    lastName
                    title
                    location
                    dateJoined
                    salaryPerMonth
                    email
                    projectId
                    projectDetails
                    projectStatus
                    priority
                    progress
                    projectStartDate
                    projectEndDate
                }
            }"
        }
    };
}
```

2. Implement the `DeleteExpense` method in the `GraphQLMutation` class:

```csharp
namespace TreeGrid_GraphQLAdaptor.Models
{
    public class GraphQLMutation
    {
        public EmployeeData? DeleteEmployee(
            string primaryColumnValue,
            string action,
            string primaryColumnName,
            [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters)
        {
            var employees = EmployeeData.GetAllRecords();

            var keyName = primaryColumnName?.ToLowerInvariant();
            var toDelete = keyName switch
            {
                "employeeid" => employees.FirstOrDefault(x => string.Equals(x.EmployeeID, primaryColumnValue, System.StringComparison.OrdinalIgnoreCase)),
                _ => employees.FirstOrDefault(x => string.Equals(x.EmployeeID, primaryColumnValue, System.StringComparison.OrdinalIgnoreCase))
            };
            if (toDelete == null) return null;

            var idsToRemove = new HashSet<string>(System.StringComparer.OrdinalIgnoreCase);
            CollectWithDescendants(employees, toDelete.EmployeeID, idsToRemove);

            employees.RemoveAll(e => idsToRemove.Contains(e.EmployeeID));

            if (!string.IsNullOrWhiteSpace(toDelete.ManagerID))
            {
                var manager = employees.FirstOrDefault(e => string.Equals(e.EmployeeID, toDelete.ManagerID, System.StringComparison.OrdinalIgnoreCase));
                if (manager != null)
                {
                    manager.HasChild = employees.Any(e => string.Equals(e.ManagerID, manager.EmployeeID, System.StringComparison.OrdinalIgnoreCase));
                }
            }

            return toDelete;
        }
        private static void CollectWithDescendants(List<EmployeeData> all, string rootId, HashSet<string> bag)
        {
            if (bag.Contains(rootId)) return;
            bag.Add(rootId);
            var children = all.Where(e => string.Equals(e.ManagerID, rootId, System.StringComparison.OrdinalIgnoreCase))
                            .Select(e => e.EmployeeID);
            foreach (var c in children)
                CollectWithDescendants(all, c, bag);
        }
    }
}
```

**Delete Operation Logic Breakdown:**

| Step | Purpose | Implementation |
|------|---------|----------------|
| **1. Receive Key** | Backend receives the primary key identifying the record to delete | `DeleteEmployee` parameter `primaryColumnValue` contains the EmployeeID (string) |
| **2. Find Record & Collect Descendants** | Locate the record and all its descendants so child rows are removed too | Locate `toDelete` by matching primaryColumnName (case‑insensitive) to `EmployeeID`; call `CollectWithDescendants(employees, toDelete.EmployeeID, idsToRemove)` to gather subtree IDs |
| **3. Remove Records** | Remove the record and all collected descendants from the in‑memory list | `employees.RemoveAll(e => idsToRemove.Contains(e.EmployeeID))` |
| **4. Update Parent HasChild** | Recompute the parent's HasChild flag after deletion | If `toDelete.ManagerID` is not empty, find manager and set `manager.HasChild = employees.Any(e => e.ManagerID == manager.EmployeeID)` |
| **5. Return Deleted** | Return the deleted EmployeeData object for client consumption | `DeleteEmployee` returns the removed `toDelete` object (or `null` if not found) |

**GraphQL Mutation Request:**

```graphql
mutation delete($primaryColumnValue: String!, $action: String!, $primaryColumnName: String!, $additionalParameters: Any) {
    deleteEmployee(primaryColumnValue: $primaryColumnValue, action: $action, primaryColumnName: $primaryColumnName, additionalParameters: $additionalParameters) {
        employeeID
        managerID
        hasChild
        name
        lastName
        title
        location
        dateJoined
        salaryPerMonth
        email
        projectId
        projectDetails
        projectStatus
        priority
        progress
        projectStartDate
        projectEndDate
    }
}
```

**Variables Sent with the Request:**

```json
{
  "primaryColumnValue": "EMP021",
  "action": "delete",
  "primaryColumnName": "EmployeeID",
  "additionalParameters": {}
}
```

**Parameter Explanation:**

| Parameter | Type | Purpose | Example |
|-----------|------|---------|---------|
| `primaryColumnValue` | `string` | Primary key value identifying which employee to delete | `"EMP021"` |
| `action` | `string` | Action descriptor from the tree grid (commonly `"delete"`) | `"delete"` |
| `primaryColumnName` | `string` | Name of the primary key column used by tree grid/backend (case‑insensitive) | `"EmployeeID"` |
| `additionalParameters` | `Any` | Optional freeform metadata passed through by the adaptor | `{}` or custom context |

**Backend Response:**

The mutation returns a boolean success/failure indicator:

```json
{
  "data": {
    "deleteEmployee": {
      "employeeID": "EMP021",
      "managerID": null,
      "hasChild": true,
      "name": "Alice Johnson",
      "lastName": "Johnson",
      "title": "Manager",
      "location": "New York",
      "dateJoined": "2018-03-07T00:00:00.000Z",
      "salaryPerMonth": 17400,
      "email": "abigail.edwards021@company.com",
      "projectId": "PRJ021",
      "projectDetails": "Backup Service",
      "projectStatus": "Open",
      "priority": "Medium",
      "progress": 74,
      "projectStartDate": "2024-03-03T00:00:00.000Z",
      "projectEndDate": "2025-09-03T00:00:00.000Z"
    }
  }
}
```

If the record doesn't exist:

```json
{
  "data": {
    "deleteEmployee": null
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
2. Navigate to `https://localhost:7213` (or the port shown in the terminal).
3. The Expense Tracker System is now running and ready to use.

---

## Complete Sample Repository

A complete, working sample implementation is available in the [GitHub repository](#).

---
## Summary

This guide demonstrates how to:

1. Install required NuGet packages for Hot Chocolate and Syncfusion Blazor. [🔗](#step-1-install-required-nuget-packages-and-configure-launch-settings)
2. Register Hot Chocolate services and expose the GraphQL endpoint. [🔗](#step-2-register-hot-chocolate-services-in-programcs)
3. Configure launch settings and ports for the GraphQL endpoint. [🔗](#step-3-configure-launch-settings-port-configuration)
4. Create the ExpenseRecord data model used across the GraphQL schema. [🔗](#step-4-create-the-data-model)
5. Implement GraphQL query resolvers to read data. [🔗](#step-5-graphql-query-resolvers)
6. Create the DataManagerRequestInput input type to carry tree grid operations. [🔗](#step-6-create-the-datamanagerrequestinput-class)
7. Define GraphQL mutation resolvers for Create, Update, and Delete. [🔗](#step-7-define-graphql-mutation-resolvers)
8. Integrate Syncfusion Blazor TreeGrid and configure the GraphQL adaptor. [🔗](#step-3-configure-graphql-adaptor-and-data-binding)
9. Perform CRUD operations from the tree grid using GraphQL mutations. [🔗](#perform-crud-operations)

The application now provides a complete solution for managing employees with a modern Syncfusion Blazor TreeGrid integrated with a Hot Chocolate GraphQL backend.
