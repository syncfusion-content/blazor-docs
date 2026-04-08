---
layout: post
title: Blazor DataManager - GraphQL Adaptor | Syncfusion
description:  Blazor DataManager GraphQL enables server-side data handling, explaining backend setup and endpoint configuration for REST-based operations.
control: GraphQL Adaptor 
platform: blazor
documentation: ug
---

# GraphQL Remote Data Binding in Syncfusion Blazor Components
 
The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components provides seamless integration with GraphQL services, enabling modern, efficient data operations through a flexible query language. This comprehensive guide demonstrates configuring and using GraphQL with the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components to perform server-side operations including querying, mutations, filtering, sorting, paging, and complete CRUD functionality.

## Understanding GraphQL

[GraphQL](https://graphql.org/learn/introduction/) is a query language that allows applications to request exactly the data needed, nothing more and nothing less. Unlike traditional REST APIs that return fixed data structures, GraphQL enables the client to specify the shape and content of the response.

**Traditional REST APIs** and **GraphQL** differ mainly in how data is requested and returned: **REST APIs expose** multiple endpoints that return fixed data structures, often including unnecessary fields and requiring several requests to fetch related data, while **GraphQL** uses a single endpoint where queries define the exact fields needed, enabling precise responses and allowing related data to be retrieved efficiently in one request. This makes **GraphQL** especially useful for **Blazor DataGrid integration**, the **reason** is data‑centric UI components require well‑structured and selective datasets to support efficient filtering, reduce network calls, and improve overall performance.

**Key GraphQL Concepts**

- **Queries**: A query is a request to read data. Queries do not modify data; they only retrieve it.
- **Mutations**: A mutation is a request to modify data. Mutations create, update, or delete records.
- **Resolvers**: Each query or mutation is handled by a resolver, which is a function responsible for fetching data or executing an operation. **Query resolvers** handle **read operations**, while **mutation resolvers** handle **write operations**.
- **Schema**: Defines the structure of the API. The schema describes available data types, the fields within those types, and the operations that can be executed. Query definitions specify how data can be retrieved, and mutation definitions specify how data can be modified. 

[Hot Chocolate](https://chillicream.com/docs/hotchocolate/v15) is an open‑source GraphQL server framework for .NET. Hot Chocolate enables the creation of GraphQL APIs using ASP.NET Core and integrates seamlessly with modern .NET applications, including Blazor.

### GraphQL vs REST comparison
 
Understanding the key differences between GraphQL and REST helps appreciate the benefits of using GraphQL with Syncfusion components:
 
| Aspect | REST API | GraphQL |
|--------|----------|---------|
| **Endpoints** | Multiple endpoints (/api/orders, /api/customers). | Single endpoint (/graphql). |
| **Data fetching** | Fixed data structure per endpoint. | Flexible, client specifies exact data needs. |
| **Over-fetching** | Common (gets unnecessary data). | Eliminated (requests only needed fields). |
| **Under-fetching** | Requires multiple requests. | Single request for complex data. |
| **Versioning** | Requires API versioning (v1, v2). | Schema evolution without versioning. |
| **Type system** | Not built-in | Strongly typed schema. |
| **Query format** | URL parameters | Structured query language. |
| **Real-time** | Requires separate solution. | Built-in subscriptions support. |
 
**GraphQL Query example:**
```text
query {
  getOrders {
    result {
      OrderID
      CustomerID
      ShipCity
    }
    count
  }
}
```

The following benefits apply when using GraphQL protocol:

- **Precise data retrieval**: Request only the fields needed, reducing bandwidth.
- **Single request**: Fetch related data in one query instead of multiple REST calls.
- **Strong typing**: Schema provides clear contract between client and server.
- **Self-documentation**: Introspection enables automatic API documentation.
- **Rapid development**: Faster iteration with flexible queries.
- **Reduced over-fetching**: Eliminates unnecessary data transfer.
 
### GraphQLAdaptor Overview

The `GraphQLAdaptor` is a specialized adaptor in Syncfusion<sup style="font-size:70%">&reg;</sup> DataManager that enables seamless communication between Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components and GraphQL servers. It automatically converts component operations into GraphQL queries and mutations. The process works as follows:
 
1. **Client action**: User performs operation (filter, sort, page, edit, etc.).
2. **Query construction**: `GraphQLAdaptor` builds GraphQL query with variables.
3. **Server request**: POST request sent to GraphQL endpoint.
4. **Query execution**: GraphQL server processes query and executes resolvers.
5. **Response processing**: `GraphQLAdaptor` extracts data from response.
6. **Component rendering**: Component displays updated data.
 
The following example illustrates how Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components handle data operations through `GraphQLAdaptor`:

- **Filter**: Sends `datamanager.where` variable with filter predicates.
- **Sort**: Sends `datamanager.sorted` variable with field and direction.
- **Page**: Sends `datamanager.skip` and `datamanager.take` variables.
- **CRUD**: Executes mutations (createOrder, updateOrder, deleteOrder).
 
The following integration benefits are gained when using GraphQL:

- Automatic query variable management.
- Built-in support for filtering, sorting, and paging.
- Simplified CRUD operations through mutations.
- Flexible response mapping.
- Reduced boilerplate code.

## Prerequisites

Install the following software and packages before starting the process:

| Software/Package | Version | Purpose |
|-----------------|---------|---------|
| Visual Studio 2026 | 18.0 or later | Development IDE with Blazor workload |
| .NET SDK | net8.0 or compatible | Runtime and build tools |
| HotChocolate.AspNetCore | 15.1 or later | GraphQL server framework |

**Package purposes:**

- `HotChocolate.AspNetCore`: Core GraphQL server implementation for ASP.NET Core, providing schema execution, middleware integration, and HTTP request handling.

## Setting Up the GraphQL Backend

### Step 1: Install Required NuGet Packages and Configure Launch Settings

Before installing NuGet packages, a new Blazor Web Application must be created using the default template. The template automatically generates essential starter files—such as **Program.cs, appsettings.json, launchSettings.json, the wwwroot folder, and the Components folder**.

For this guide, a Blazor application named **GraphQLAdaptor** has been created.

**Install NuGet Packages**

NuGet packages are software libraries that add functionality to applications. The following packages enable GraphQL server functionality+ and Syncfusion Blazor Components.

**Required Packages:**

- **HotChocolate.AspNetCore** (version 15.1 or later) - GraphQL server framework

**Method 1: Using Package Manager Console**

1. Open Visual Studio 2026.
2. Navigate to **Tools → NuGet Package Manager → Package Manager Console**.
3. Run the following commands:

```powershell
Install-Package HotChocolate.AspNetCore -Version 15.1.12
```

**Method 2: Using NuGet Package Manager UI**

1. Open **Visual Studio 2026 → Tools → NuGet Package Manager → Manage NuGet Packages for Solution**.
2. Search for and install each package individually:
   - **HotChocolate.AspNetCore** (version 15.1.12 or later)   

---

**Package purposes:**

- `HotChocolate.AspNetCore`: Core GraphQL server implementation for ASP.NET Core, providing schema execution, middleware integration, and HTTP request handling.

> The HotChocolate packages are required for GraphQL functionality. Refer to the [HotChocolate documentation](https://chillicream.com/docs/hotchocolate/v13) for more details.

### Step 2: Register Hot Chocolate Services in Program.cs

The `Program.cs` file configures and registers the GraphQL services.

**Instructions:**

1. Open the `Program.cs` file at the project root.
2. Add the following code after `var builder = WebApplication.CreateBuilder(args);`:

```csharp
[Program.cs]

using GraphQLAdaptor.Models;
using HotChocolate.Execution.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Register Hot Chocolate GraphQL services
builder.Services
    .AddGraphQLServer()    
    .AddQueryType<GraphQLQuery>()   // Register query resolver.   
    .AddMutationType<GraphQLMutation>(); // Register mutation resolver.

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

**File Location:** `Models/ExpenseRecord.cs`

```csharp
namespace Grid_GraphQLAdaptor.Models
{
    /// <summary>
    /// Represents a single expense record stored in the database.
    /// Each property corresponds to a database column.
    /// </summary>
    public class ExpenseRecord
    {
        /// <summary>
        /// Unique identifier for each expense record.
        /// This is the primary key in the database.
        /// </summary>
        public string ExpenseId { get; set; }

        /// <summary>
        /// Name of the employee who submitted the expense.
        /// </summary>
        public string EmployeeName { get; set; }

        /// <summary>
        /// Email address of the employee.
        /// </summary>
        public string EmployeeEmail { get; set; }

        /// <summary>
        /// Department to which the employee belongs.
        /// </summary>
        public string Department { get; set; }

        /// <summary>
        /// Category of the expense (e.g., Travel, Meals, Office Supplies).
        /// </summary>
        public string Category { get; set; }

        /// <summary>
        /// Base amount of the expense before tax.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Tax percentage applied to the expense.
        /// </summary>
        public decimal TaxPct { get; set; }

        /// <summary>
        /// Total amount including tax (calculated: Amount + (Amount * TaxPct / 100)).
        /// </summary>
        public decimal TotalAmount { get; set; }        
    }
}
```
**Property Mapping Reference**

The following table shows how C# properties map to database columns and GraphQL field names:

| Property Name (C#) | Database Column | GraphQL Field Name | Data Type | Purpose |
|---|---|---|---|---|
| `ExpenseId` | `expense_id` | `expenseId` | `String` | Unique identifier for the expense record |
| `EmployeeName` | `employee_name` | `employeeName` | `String` | Name of the employee submitting the expense |
| `EmployeeEmail` | `employee_email` | `employeeEmail` | `String` | Email address for contact purposes |
| `Department` | `department` | `department` | `String` | Organizational department |
| `Category` | `category` | `category` | `String` | Type or classification of expense |
| `Amount` | `amount` | `amount` | `Decimal` | Base expense amount before tax |
| `TaxPct` | `tax_pct` | `taxPct` | `Decimal` | Tax percentage applied |
| `TotalAmount` | `total_amount` | `totalAmount` | `Decimal` | Final amount including tax |

**Important Convention: Camel Case Conversion**

**Hot Chocolate GraphQL** automatically converts C# property names (**PascalCase**) to GraphQL field names (**camelCase**). This convention ensures consistent naming in the GraphQL schema:

- C# Property: `EmployeeName` → GraphQL Field: `employeeName`
- C# Property: `ExpenseId` → GraphQL Field: `expenseId`
- C# Property: `TotalAmount` → GraphQL Field: `totalAmount`

**Explanation**:

- The [Key] attribute marks the `ExpenseId` property as the primary key (a unique identifier for each record).
- Each property represents a column in the database table.
- The model provides the data structure that GraphQL uses to process queries and mutations.

The expense data model has been successfully created.

---

### Step 5: GraphQL Query Resolvers

A query resolver is a method in the backend that handles read requests from the client. When the Blazor components needs to fetch data, it sends a GraphQL query to the server. The query resolver receives this request, processes it, and returns the appropriate data. Query resolvers do not modify data; they only retrieve and return it.

In simple terms, a **GraphQL query** asks a question,
and a **resolver** is the one who answers it.

**Instructions:**

1. Inside the **Models** folder, create a new file named **GraphQLQuery.cs**.
2. Add the following code to define the query resolver:

```csharp
[Models/GraphQLQuery.cs]

using GraphQLAdaptor.Models;

public class GraphQLQuery
{
    /// <summary>
    /// Query resolver for fetching expense record data with data operations support.
    /// </summary>
    public ExpenseRecordDataResponse GetExpenseRecordData(DataManagerRequestInput dataManager)
    {
        // Retrieve all expense records from the data source.
        List<ExpenseRecord> dataSource = ExpenseRecord.GetAllRecords();

        // Apply search, filter, sort, and paging operations as provided by the Blazor components.
        // Operations are applied sequentially: search → filter → sort → paging.

        // Store the total count before paging.
        int totalRecords = dataSource.Count;

        // Return response with total count and paginated data.
        return new ExpenseRecordDataResponse
        {
            Count = totalRecords,
            Result = dataSource
        };
    }
}

/// <summary>
/// Response structure for query results. Must include Count (total records) and Result (current page).
/// </summary>
public class ExpenseRecordDataResponse
{
    public int Count { get; set; }
    public List<ExpenseRecord> Result { get; set; } = new List<ExpenseRecord>();
}
```

**Details:**

- The `GetExpenseRecordData` method receives `DataManagerRequestInput`, which contains filter, sort, search, and paging parameters from the Blazor components.
- Hot Chocolate automatically converts the method name `GetExpenseRecordData` to camelCase: `expenseRecordData` in the GraphQL schema.
- The response must contain `Count` (total records) and `Result` (current page data) for the component to process pagination.

The query resolver has been created successfully.

---

### Step 6: Create the DataManagerRequestInput Class

A **DataManagerRequestInput** class is a GraphQL input type that represents all the parameters the Syncfusion Blazor components sends to the backend when requesting data. This class acts as a container for filtering, sorting, searching, paging, and other data operation parameters.

**Purpose**
When the component performs operations like pagination, sorting, filtering, or searching, it packages all these parameters into a `DataManagerRequestInput` object and sends it to the GraphQL backend. The backend then uses these parameters to fetch and return only the data the component needs.

**Instructions**:

1. Inside the **Models** folder, create a new file named **DataManagerRequestInput.cs**.
2. Define the **DataManagerRequestInput** class and supporting classes with the following code:

```csharp
namespace GraphQLAdaptor.Models;

/// <summary>
/// Represents the input structure for data manager requests from the Syncfusion Blazor component.
/// Contains all parameters needed for data operations like filtering, sorting, paging, and searching.
/// </summary>
public class DataManagerRequestInput
{
    /// <summary>
    /// Number of records to skip from the beginning (used for pagination).
    /// Example: Skip=10 means start from the 11th record.
    /// </summary>
    [GraphQLName("Skip")]
    public int Skip { get; set; }

    /// <summary>
    /// Number of records to retrieve (page size).
    /// Example: Take=10 means retrieve 10 records per page.
    /// </summary>
    [GraphQLName("Take")]
    public int Take { get; set; }

    /// <summary>
    /// Indicates whether the total record count should be calculated.
    /// Set to true when pagination requires knowing the total number of records.
    /// </summary>
    [GraphQLName("RequiresCounts")]
    public bool RequiresCounts { get; set; } = false;

    /// <summary>
    /// Search criteria for finding specific records.
    /// Contains the search text and which fields to search in.
    /// </summary>
    [GraphQLName("Search")]
    public List<SearchFilter>? Search { get; set; }

    // Add other parameters

}

/// <summary>
/// Represents an aggregate operation (Sum, Average, Min, Max, Count).
/// Used to calculate aggregate values on specified fields.
/// </summary>
public class Aggregate
{
    /// <summary>
    /// Field name to aggregate (e.g., "Amount", "TotalAmount").
    /// </summary>
    [GraphQLName("Field")]
    public string? Field { get; set; }

    /// <summary>
    /// Type of aggregation: Sum, Average, Min, Max, Count.
    /// </summary>
    [GraphQLName("Type")]
    public string? Type { get; set; }
}

/// <summary>
/// Represents search criteria for finding records.
/// Allows searching across multiple fields with specified operators.
/// </summary>
public class SearchFilter
{
    /// <summary>
    /// Fields to search in (e.g., ["EmployeeName", "Department"]).
    /// </summary>
    [GraphQLName("Fields")]
    public List<string>? Fields { get; set; }

    /// <summary>
    /// The search keyword entered by the user.
    /// </summary>
    [GraphQLName("Key")]
    public string? Key { get; set; }

    /// <summary>
    /// Comparison operator (contains, equals, startsWith, etc.).
    /// </summary>
    [GraphQLName("Operator")]
    public string? Operator { get; set; }

    /// <summary>
    /// Whether the search should ignore case (case-insensitive search).
    /// </summary>
    [GraphQLName("IgnoreCase")]
    public bool IgnoreCase { get; set; }

    /// <summary>
    /// Indicates whether to ignore accent marks and diacritic characters during search operations
    /// </summary>
    [GraphQLName("IgnoreAccent")]
    public bool IgnoreAccent { get; set; }
}

/// <summary>
/// Represents sorting instructions for ordering records.
/// Defines which field to sort by and in which direction.
/// </summary>
public class Sort
{
    /// <summary>
    /// Field name to sort by (e.g., "Amount", "EmployeeName").
    /// </summary>
    [GraphQLName("Name")]
    public string? Name { get; set; }

    /// <summary>
    /// Sort direction: "Ascending" or "Descending".
    /// </summary>
    [GraphQLName("Direction")]
    public string? Direction { get; set; }

    // Add other properties
}

/// <summary>
/// Represents a filter condition for narrowing down records.
/// Supports complex nested conditions (AND/OR logic) for advanced filtering.
/// </summary>
public class WhereFilter
{
    /// <summary>
    /// Field name to filter by (e.g., "Department", "Amount").
    /// </summary>
    [GraphQLName("Field")]
    public string? Field { get; set; }

    /// <summary>
    /// Ignore case sensitivity in comparisons.
    /// </summary>
    [GraphQLName("IgnoreCase")]
    public bool? IgnoreCase { get; set; }

    // Add other properties
}

// Add other classes

```

**Understanding the DataManagerRequestInput Class**

**Example Scenario:** A sequence of operations is performed on the DataGrid as follows:

- Searches for **"Finance"** in the Department column.
- Filters for amounts greater than 1000.
- Sorts by Amount in descending order.
- Navigates to page 2 (showing records 11-20).
- Resulting **DataManagerRequestInput** Parameters:

```json
{
    "dataManager": {
        "Skip": 10,
        "Take": 10,
        "RequiresCounts": true,
        "Search": [
            {
                "Fields": ["Department"],
                "Key": "Finance",
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
                        "Field": "Amount",
                        "Operator": "greaterThan",
                        "Value": 1000,
                        "Predicates": []
                    }
                ]
            }
        ],
        "Sorted": [
            {
                "Name": "Amount",
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
| `Group` | Grouping configuration | `List<string>` | Field names to group by |

**Key Attributes Explained**
[GraphQLName]: Maps C# property names to GraphQL schema field names. **Hot Chocolate** automatically converts PascalCase to camelCase.

Example: **RequiresCounts → requiresCounts**
[GraphQLType(typeof(AnyType))]: Allows flexible typing for complex nested structures that can contain various data types.

### Step 7: GraphQL Mutation Resolvers

A **GraphQL mutation resolver** is a method in the backend that handles write requests (data modifications) from the client. While queries only read data, mutations create, update, or delete records. When the Blazor DataGrid performs add, edit, or delete operations, it sends a GraphQL mutation to the server. The mutation resolver receives this request, processes it, and persists the changes to the data source.

In simple terms, a **GraphQL mutation** asks for a change, and a **resolver** is the one who makes it.

**Instructions:**
1. Inside the Models folder, create a new file named **GraphQLMutation.cs**.
2. Define the **GraphQLMutation** class with the following code:

```csharp
using GraphQLAdaptor.Models;
using HotChocolate.Types;

namespace GraphQLAdaptor.Models
{
    /// <summary>
    /// GraphQL Mutation class that handles all write operations (Create, Update, Delete).
    /// Each method is a resolver that processes data modification requests from the DataGrid.
    /// </summary>
    public class GraphQLMutation
    {
        /// <summary>
        /// Mutation resolver for creating a new expense record.
        /// Called when a user clicks the "Add" button in the DataGrid and submits a new record.
        /// </summary>
        public ExpenseRecord CreateExpense(
            ExpenseRecord record,
            int index,
            string action,
            [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters)
        {
            // Add logic to create new expense record        
            return record;
        }

        /// <summary>
        /// Mutation resolver for updating an existing expense record.
        /// Called when a user clicks the "Edit" button, modifies values, and submits the changes.
        /// </summary>
        public ExpenseRecord UpdateExpense(
            ExpenseRecord record,
            string action,
            string primaryColumnName,
            string primaryColumnValue,
            [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters)
        {
            // Add logic to update existing expense record        
            
            return record;
        }

        /// <summary>
        /// Mutation resolver for deleting an expense record.
        /// Called when a user clicks the "Delete" button and confirms the deletion.
        /// </summary>
        public bool DeleteExpense(
            string primaryColumnValue,
            [GraphQLType(typeof(AnyType))] IDictionary<string, object> additionalParameters)
        {
            // Add logic to delete existing expense record       
            
            return true;
        }
    }
}
```

A mutation resolver is a C# method decorated with GraphQL attributes that:

- **Receives input parameters** from the components(record data, primary keys, etc.).
- **Processes the operation** (validation, calculation, data modification).
- **Persists changes** to the data source (database, file, memory).
- **Returns results** to the client (modified record or success/failure status).

The GraphQL Mutation class has been successfully created and is ready to handle all data modification operations from the Syncfusion Blazor Components.

---

### Step 8: GraphQL service verification

Run the application in Visual Studio by pressing **F5** or clicking the **Run** button and the application launches and opens in default browser at **https://localhost:xxxx**. 

### Step 9: Verify GraphQL endpoint 

Navigate to **https://localhost:xxxx/graphql** to access the Banana Cake Pop GraphQL IDE (built-in HotChocolate GraphQL playground).

**Test query example:**

```text
query {
  orders {
    items {
      orderID
      customerID
      employeeID
      freight
      shipCity
      verified
      orderDate
      shipName
      shipCountry
      shippedDate
      shipAddress
    }
    pageInfo {
      hasNextPage
      hasPreviousPage
    }
    totalCount
  }
}
```

### Step 10: Understanding the required response format

When using the `GraphQLAdaptor`, every backend API endpoint must return data in a specific JSON structure. This ensures that Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataManager can correctly interpret the response and bind it to the component. The expected format is:

```json
{
  "result": [
    { "OrderID": 10001, "CustomerID": "ALFKI", "ShipCity": "Berlin" },
    { "OrderID": 10002, "CustomerID": "ANATR", "ShipCity": "Madrid" },
    ...
    ...
  ],
  "count": 45
}
```

**Test filtering example:**

```text
query {
  orders(where: { shipCity: { eq: "Berlin" } }) {
    items {
      orderID
      customerID
      shipCity
    }
    totalCount
  }
}
```

**Test sorting example:**

```text
query {
  orders(order: { freight: DESC }) {
    items {
      orderID
      freight
    }
  }
}
```

**Test pagination example:**

```text
query {
  orders(skip: 0, take: 10) {
    items {
      orderID
      customerID
    }
    pageInfo {
      hasNextPage
    }
    totalCount
  }
}
```

## Integration with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Components

To integrate the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components with the `GraphQLAdaptor`, refer to the documentation below:

- [DataGrid](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/graphql-adaptor#integrating-syncfusion-blazor-datagrid)
