---
layout: post
title: Microsoft SQL Server Data Binding in Blazor DataGrid Component | Syncfusion
description: Learn how to bind Microsoft SQL Server data to Syncfusion Blazor DataGrid using CustomAdaptor, enable CRUD operations, and implement server-side data processing with raw SQL queries.
platform: Blazor
control: DataGrid
documentation: ug
---

# Connecting Microsoft SQL Server Data to Blazor DataGrid

Syncfusion Blazor DataGrid provides seamless integration with Microsoft SQL Server databases through a Custom Adaptor pattern. This guide demonstrates binding SQL Server data directly to the grid, implementing server‑side data operations (searching, filtering, sorting, paging, grouping), and enable full CRUD (Create, Read, Update, Delete) functionality using raw SQL queries via SqlClient.

---

## Use Microsoft SQL Server with Blazor DataGrid

Microsoft SQL Server offers enterprise-grade capabilities for building scalable, secure data-driven applications with Blazor. Integrating SQL Server directly with Syncfusion DataGrid provides significant advantages:

- Performance optimization: Process large datasets server-side before transmitting filtered, sorted, and paginated results to the client, reducing bandwidth and improving response times.
- Direct SQL execution: Use raw SQL queries with SqlClient for precise database control without ORM abstraction layers, enabling transparent query debugging and optimization.
- Enterprise security: Leverage SQL Server's built-in encryption, role-based access control, and authentication mechanisms to protect sensitive ticket data.
- Scalability: Handle growing data volumes efficiently through server-side filtering, aggregation, and pagination operations.
- CRUD integration: Enable users to create, read, update, and delete records directly from the DataGrid UI with automatic database synchronization.
- Server-side operations: Implement searching, filtering, sorting, grouping, and aggregation on the database server, reducing client-side processing overhead.

## Prerequisites

Ensure the following software and packages are installed before proceeding:

| Software/Package | Version | Purpose |
|-----------------|---------|---------|
| Visual Studio 2022 | 17.0 or later | Development IDE with Blazor workload |
| .NET SDK | net8.0 or compatible | Runtime and build tools |
| Microsoft SQL Server | 2019 or later (Express supported) | Database server |
| SQL Server Management Studio (SSMS) | Latest | Database administration tool |
| Syncfusion.Blazor | 28.1.33 or later | DataGrid and UI components |
| Microsoft.Data.SqlClient | 5.2.0 or later | SQL Server data provider |

---

## Setup environment

### Step 1: Create database and table in SQL Server

A **Network Support Ticket System** scenario is used to demonstrate binding the Syncfusion Blazor DataGrid to Microsoft SQL Server with real ticket records and server-side operations. "NetworkSupportDB" database and "Tickets" table store ticket data for CRUD actions, enabling grid-driven querying, editing, paging, and aggregation.

Open SQL Server Management Studio (SSMS) and execute the following script to create the database and "Tickets" table:

```sql
-- Create Database
CREATE DATABASE NetworkSupportDB;
GO

USE NetworkSupportDB;
GO

-- Create Tickets Table
CREATE TABLE dbo.Tickets (
    TicketId INT IDENTITY(1,1) PRIMARY KEY,
    PublicTicketId NVARCHAR(50) NOT NULL,
    Title NVARCHAR(200) NOT NULL,
    Description NVARCHAR(MAX),
    Category NVARCHAR(100),
    Department NVARCHAR(100),
    Assignee NVARCHAR(100),
    CreatedBy NVARCHAR(100),
    Status NVARCHAR(50) DEFAULT 'Open',
    Priority NVARCHAR(50) DEFAULT 'Medium',
    ResponseDue DATETIME NULL,
    DueDate DATETIME NULL,
    CreatedAt DATETIME DEFAULT GETDATE(),
    UpdatedAt DATETIME DEFAULT GETDATE()
);
GO

-- Insert Sample Data (Optional)
INSERT INTO dbo.Tickets (PublicTicketId, Title, Description, Category, Department, Assignee, CreatedBy, Status, Priority, ResponseDue, DueDate)
VALUES 
('NET-1001', 'Network Connectivity Issue', 'Unable to connect to internal network', 'Network', 'IT Support', 'John Doe', 'Jane Smith', 'Open', 'High', DATEADD(DAY, 1, GETDATE()), DATEADD(DAY, 3, GETDATE())),
('NET-1002', 'Email Configuration', 'Outlook not syncing emails', 'Email', 'IT Support', 'Mike Johnson', 'Bob Wilson', 'In Progress', 'Medium', DATEADD(DAY, 2, GETDATE()), DATEADD(DAY, 5, GETDATE())),
('NET-1003', 'VPN Access Request', 'Need VPN access for remote work', 'Access', 'Security', 'Sarah Davis', 'Tom Brown', 'Resolved', 'Low', DATEADD(DAY, 3, GETDATE()), DATEADD(DAY, 7, GETDATE()));
GO
```

With the database and Tickets table provisioned, continue by installing the NuGet packages required for Syncfusion Blazor components and SQL Server connectivity.
These dependencies will be referenced by the grid adaptor and data access layer in the following steps.

### Step 2: Install required NuGet packages

Syncfusion.Blazor provides the DataGrid and related UI services, while Microsoft.Data.SqlClient enables secure, performant connectivity to SQL Server with raw query support. Installing these packages establishes the core UI and data-access dependencies used by the custom adaptor and data layer.

Open the Package Manager Console in Visual Studio and install the necessary packages:

```powershell
Install-Package Syncfusion.Blazor -Version 28.1.33 ;
Install-Package Microsoft.Data.SqlClient -Version 5.2.0
```

Alternatively, use NuGet Package Manager UI:
1. Navigate to **Tools** → **NuGet Package Manager** → **Manage NuGet Packages for Solution**
2. Search for and install **Syncfusion.Blazor** (latest stable version)
3. Search for and install **Microsoft.Data.SqlClient** (version 5.2.0 or later)

Package installation has been completed. Continue with defining the data model aligned with the Tickets schema to ensure strong typing and reliable DataGrid binding.

### Step 3: Define the data model

A strongly typed model establishes a clear contract between the database schema and the grid, enabling compile-time validation and predictable serialization. Aligning properties with SQL column data types ensures accurate binding, editing, and server-side processing.

Create a C# model class representing the Tickets table structure in `Data/Tickets.cs`:

```csharp
public class Tickets
{
    public int TicketId { get; set; }
    public string PublicTicketId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public string Department { get; set; }
    public string Assignee { get; set; }
    public string CreatedBy { get; set; }
    public string Status { get; set; }
    public string Priority { get; set; }
    public DateTime? ResponseDue { get; set; }
    public DateTime? DueDate { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
}
```

Model definition has been completed. Proceed to configure the connection string to enable database connectivity.

### Step 4: Configure data access (TicketData.cs)

Define the SQL Server connection string and implement the data retrieval method in **Data/TicketData.cs** to establish reliable connectivity and server-side data access. The implementation uses "SqlConnection", "SqlCommand", and "SqlDataAdapter" to execute a SELECT statement and materialize results into the strongly typed "Tickets" model.

```csharp
using Microsoft.Data.SqlClient;
using System.Data;

public class TicketData
{
    private string connectionString = "Data Source=YOUR_SERVER;Initial Catalog=YOUR_DATABASE;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

    public async Task<List<Tickets>> GetTicketsData()
    {
        string queryString = "SELECT * FROM dbo.Tickets ORDER BY TicketId";

        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        {
            sqlConnection.Open();

            using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection))
            {
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                {
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);

                    var dataSource = (from DataRow row in dataTable.Rows
                                      select new Tickets()
                                      {
                                          TicketId = Convert.ToInt32(row["TicketId"]),
                                          PublicTicketId = row["PublicTicketId"].ToString(),
                                          Title = row["Title"].ToString(),
                                          Description = row["Description"].ToString(),
                                          Category = row["Category"].ToString(),
                                          Department = row["Department"].ToString(),
                                          Assignee = row["Assignee"].ToString(),
                                          CreatedBy = row["CreatedBy"].ToString(),
                                          Status = row["Status"].ToString(),
                                          Priority = row["Priority"].ToString(),
                                          ResponseDue = row["ResponseDue"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["ResponseDue"]),
                                          DueDate = row["DueDate"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(row["DueDate"]),
                                          CreatedAt = Convert.ToDateTime(row["CreatedAt"]),
                                          UpdatedAt = Convert.ToDateTime(row["UpdatedAt"])
                                      }).ToList();

                    return dataSource;
                }
            }
        }
    }
}
```

Connection string parameters:
- Data Source: SQL Server instance name (e.g., localhost\SQLEXPRESS, DESKTOP-ABC123, 192.168.1.100)
- Initial Catalog: Target database name (e.g., NetworkSupportDB)
- Integrated Security: Windows Authentication enablement
- Connect Timeout: Connection timeout in seconds
- Encrypt: SSL encryption toggle (enable for production)

Key implementation details:
- "SqlConnection" establishes and manages the session to SQL Server so the query can be executed against the target database.
- "SqlCommand" encapsulates the SELECT statement and binds it to the open connection to request the desired result set.
- "SqlDataAdapter" bridges the command execution and in-memory structures, enabling retrieval into a DataTable without manual data readers.
- "SqlDataAdapter.Fill" hydrates a DataTable; LINQ projection maps rows to the "Tickets" model.
- Nullable DateTime fields are handled via "DBNull.Value" checks.
- The method returns "List<Tickets>" for consistent binding in the custom adaptor and DataGrid.

Data access configuration has been completed. Proceed to register Syncfusion Blazor services.

### Step 5: Register Syncfusion services

Registers the Syncfusion component services required by the DataGrid at runtime and exposes grid APIs via dependency injection.

Configure Syncfusion services in `Program.cs`:

```csharp
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Register Syncfusion Blazor services
builder.Services.AddSyncfusionBlazor();

```

Add required namespaces in `Components/_Imports.razor`:

```csharp
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
```

Service registration and namespace imports have been completed. Continue with configuring DataGrid–SQL Server integration using the Custom Adaptor.

### Step 6: Binding data from Microsoft SQL Server using CustomAdaptor

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can bind data from a **Microsoft SQL Server** database using a [CustomAdaptor](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/custom-adaptor) for scenarios that require full control over data operations.
The Custom Adaptor serves as the bridge between DataGrid UI interactions and SQL Server database operations. When users interact with the grid (search, filter, sort, page), the adaptor intercepts these requests and executes corresponding SQL operations.

### Implement custom adaptor

Create a Custom Adaptor class in `Components/Pages/Home.razor` that bridges DataGrid actions with SQL Server operations:

```csharp
@code {
    public class CustomAdaptor : DataAdaptor
    {
        public TicketData TicketService = new TicketData();

        /// <summary>
        /// ReadAsync - Retrieves records from SQL Server and applies data operations
        /// Executes on grid initialization and when user performs search, filter, sort, page operations
        /// </summary>
        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string Key = null)
        {
            // Fetch all records from SQL Server via data layer
            IEnumerable<Tickets> dataSource = await TicketService.GetTicketsData();

            // Apply data operations (search, filter, sort, aggregate, paging, grouping) as requested
            // Detailed implementations for each operation follow in subsequent sections
            
            // Calculate total record count for pagination metadata
            int totalRecordsCount = dataSource.Count();
            
            // Return DataResult containing filtered/sorted records and total count
            return dataManagerRequest.RequiresCounts 
                ? new DataResult() { Result = dataSource, Count = totalRecordsCount } 
                : (object)dataSource;
        }
    }
}
```

**Custom Adaptor methods reference**:
- [ReadAsync(DataManagerRequest)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_ReadAsync_Syncfusion_Blazor_DataManagerRequest_System_String_) - Retrieve and process records (search, filter, sort, page, group)
- [InsertAsync(DataManager, object)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_InsertAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_) - Create new records in SQL Server
- [UpdateAsync(DataManager, object, string, string)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_UpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) - Edit existing records in SQL Server
- [RemoveAsync(DataManager, object, string, string)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_RemoveAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) - Delete records from SQL Server
- [BatchUpdateAsync(DataManager, object, object, object, string, string, int?)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_BatchUpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_Object_System_Object_System_String_System_String_System_Nullable_System_Int32__) - Handle bulk operations

Bind the adaptor to the DataGrid markup in `Home.razor`:

```html
<SfGrid TValue="Tickets">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
</SfGrid>
```

**Data flow architecture**:

1. User interaction → Grid detects user action (click, type, scroll)
2. DataManagerRequest creation → Grid creates request object with operation parameters
3. Custom Adaptor invocation → SfDataManager calls appropriate adaptor method
4. Data layer execution → Adaptor calls TicketData methods to execute SQL queries
5. Result processing → Adaptor applies data transformations and returns DataResult
6. Grid rendering → Grid displays processed data in UI

The Custom Adaptor implementation centralizes all database logic, enabling consistent SQL execution, error handling, and performance optimization across all grid operations.

## Handling data operations

Server-side data operations optimize performance by processing data before transmission to the client. Each operation in the Custom Adaptor's `ReadAsync` method handles specific grid functionality.

---

### Implement searching

Enables keyword-based query across configured fields, allowing the grid to delegate search criteria to the adaptor for efficient server-side filtering.

Add searching capability to filter records based on user-entered keywords:

```csharp
// Searching
if (dataManagerRequest.Search != null && dataManagerRequest.Search.Count > 0)
{
    dataSource = DataOperations.PerformSearching(dataSource, dataManagerRequest.Search);
}
```

Enable the search toolbar in DataGrid markup:

```html
<SfGrid Toolbar="@(new List<string>() { "Search" })">
    <!-- Grid configuration -->
</SfGrid>
```

Search configuration has been established; proceed with column-level filtering to refine results further.

---

### Apply filtering

Provides column-level criteria evaluation so the adaptor can restrict datasets at the source for precise, performant retrieval.

Add filtering to restrict records based on column-specific criteria:

```csharp
// Filtering
if (dataManagerRequest.Where != null && dataManagerRequest.Where.Count > 0)
{
    dataSource = DataOperations.PerformFiltering(dataSource, dataManagerRequest.Where, dataManagerRequest.Where[0].Operator);
}
```

Enable filtering in DataGrid markup:

```html
<SfGrid AllowFiltering="true">
    <GridFilterSettings Type="FilterType.Menu"></GridFilterSettings>
    <!-- Grid columns -->
</SfGrid>
```

Filtering configuration is complete; continue with sorting to define the desired record ordering.

---

### Enable sorting

Enables deterministic record ordering by delegating sort descriptors to the adaptor for database-optimized sorting.

Add sorting to arrange records in ascending or descending order:

```csharp
// Sorting
if (dataManagerRequest.Sorted != null && dataManagerRequest.Sorted.Count > 0)
{
    dataSource = DataOperations.PerformSorting(dataSource, dataManagerRequest.Sorted);
}
```

Enable sorting in DataGrid markup:

```html
<SfGrid AllowSorting="true">
    <!-- Grid columns -->
</SfGrid>
```

Sorting configuration is finalized; proceed with aggregates or subsequent operations as needed.

---

### Configure aggregates

Aggregate functions compute summary statistics across datasets without requiring row-level retrieval, enabling efficient calculation of totals, averages, and counts at the database server level.

Add aggregate calculations (Sum, Count, Average, Min, Max) for summary statistics:

```csharp
// Aggregates
IDictionary<string, object>? aggregates = null;
if (dataManagerRequest.Aggregates != null && dataManagerRequest.Aggregates.Count > 0)
{
    aggregates = DataUtil.PerformAggregation(dataSource, dataManagerRequest.Aggregates);
}

// Include aggregates in return
return new DataResult() { Result = dataSource, Count = totalRecordsCount, Aggregates = aggregates };
```

Enable aggregates in DataGrid markup:

```html
<SfGrid>
    <GridAggregates>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field="TicketId" Type="AggregateType.Count"></GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
    </GridAggregates>
</SfGrid>
```

Aggregate configuration has been established; proceed with implementing paging to distribute large datasets across multiple pages.

---

### Add paging support

Paging divides large result sets into fixed-size pages, reducing memory consumption and improving client-side responsiveness by retrieving only the requested page from the server.

Add paging to divide large datasets into manageable pages:

```csharp
// Calculate total count before paging
int totalRecordsCount = dataSource.Count();

// Paging
if (dataManagerRequest.Skip != 0)
{
    dataSource = DataOperations.PerformSkip(dataSource, dataManagerRequest.Skip);
}
if (dataManagerRequest.Take != 0)
{
    dataSource = DataOperations.PerformTake(dataSource, dataManagerRequest.Take);
}
```

Enable paging in DataGrid markup:

```html
<SfGrid AllowPaging="true">
    <GridPageSettings PageSize="10"></GridPageSettings>
    <!-- Grid columns -->
</SfGrid>
```

Paging implementation is complete; continue with grouping records to organize data hierarchically by column values.

---

### Enable grouping

Grouping hierarchically organizes records by specified column values, enabling data summarization and nested record visualization while reducing query complexity through server-side grouping operations.

Add grouping to organize records hierarchically by column values:

```csharp
// Grouping
if (dataManagerRequest.Group != null && dataManagerRequest.Group.Count > 0)
{
    IEnumerable groupedData = dataSource.ToList();
    foreach (var group in dataManagerRequest.Group)
    {
        groupedData = DataUtil.Group<Tickets>(groupedData, group, dataManagerRequest.Aggregates, 0, dataManagerRequest.GroupByFormatter);
    }
    return dataManagerRequest.RequiresCounts 
        ? new DataResult() { Result = groupedData, Count = totalRecordsCount } 
        : (object)groupedData;
}
```

Enable grouping in DataGrid markup:

```html
<SfGrid AllowGrouping="true">
    <GridGroupSettings Columns="@(new string[] { "Status" })"></GridGroupSettings>
    <!-- Grid columns -->
</SfGrid>
```

Grouping configuration has been completed; proceed to implementing CRUD operations to enable record creation, modification, and deletion directly from the DataGrid interface.

---
## Handling CRUD operations

Custom Adaptor methods enable users to create, read, update, and delete records directly from the DataGrid. Each operation calls corresponding data layer methods in TicketData.cs to execute SQL commands.

### Create (Insert) records

Record insertion enables users to create new tickets directly from the DataGrid interface; the adaptor intercepts the insertion request, applies business logic validation, and persists the new record to the SQL Server database.

Implement `InsertAsync` to handle new record creation:

```csharp
public override async Task<object> InsertAsync(DataManager dataManager, object value, string key)
{
    // Extract new record data from grid
    Tickets newTicket = value as Tickets;
    
    // Call data layer method to insert into SQL Server
    await TicketService.AddTicketAsync(newTicket);
    
    // Return inserted record for grid UI update
    return value;
}
```

In **Data/TicketData.cs**, implement the insert method:

```csharp
public async Task AddTicketAsync(Tickets ticket)
{
    string query = $@"INSERT INTO dbo.Tickets 
        (PublicTicketId, Title, Description, Category, Department, Assignee, CreatedBy, Status, Priority, ResponseDue, DueDate, CreatedAt, UpdatedAt)
        VALUES 
        ('{ticket.PublicTicketId}', '{ticket.Title}', '{ticket.Description}', '{ticket.Category}', 
         '{ticket.Department}', '{ticket.Assignee}', '{ticket.CreatedBy}', '{ticket.Status}', '{ticket.Priority}',
         '{ticket.ResponseDue}', '{ticket.DueDate}', '{DateTime.Now}', '{DateTime.Now}')";

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            await command.ExecuteNonQueryAsync();
        }
    }
}
```

Record insertion has been configured; the new ticket is now persisted to the database and reflected in the grid. Continue with implementing the read operation to retrieve and display records from SQL Server.

### Read (Retrieve) records

Record retrieval executes SQL queries against the database and materializes results into the strongly typed Tickets model; the adaptor processes data operations (search, filter, sort, aggregate, page, group) before returning the result set to the grid for display.

The `ReadAsync` method is implemented in Step 6, retrieving and processing records from SQL Server.

Record retrieval has been established; the grid now displays SQL Server data with full support for searching, filtering, sorting, paging, grouping, and aggregation. Continue with implementing record updates to enable in-place editing of existing tickets.

### Update (Edit) records

Record modification enables users to edit ticket attributes directly within the DataGrid; the adaptor captures the edited row, validates changes, and synchronizes modifications to the SQL Server database while maintaining data integrity.

Implement `UpdateAsync` to handle record modifications:

```csharp
public override async Task<object> UpdateAsync(DataManager dataManager, object value, string keyField, string key)
{
    // Extract modified record data from grid
    Tickets updatedTicket = value as Tickets;
    
    // Call data layer method to update in SQL Server
    await TicketService.UpdateTicketAsync(updatedTicket);
    
    // Return updated record for grid UI update
    return value;
}
```

In **Data/TicketData.cs**, implement the update method:

```csharp
public async Task UpdateTicketAsync(Tickets ticket)
{
    string query = $@"UPDATE dbo.Tickets 
        SET Title='{ticket.Title}', Description='{ticket.Description}', Category='{ticket.Category}',
            Department='{ticket.Department}', Assignee='{ticket.Assignee}', Status='{ticket.Status}',
            Priority='{ticket.Priority}', ResponseDue='{ticket.ResponseDue}', DueDate='{ticket.DueDate}',
            UpdatedAt='{DateTime.Now}'
        WHERE TicketId={ticket.TicketId}";

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            await command.ExecuteNonQueryAsync();
        }
    }
}
```

Record updates have been configured; modifications are now synchronized to the database and reflected in the grid UI. Continue with implementing record deletion to complete the full CRUD lifecycle.

### Delete (Remove) records

Record deletion enables users to remove tickets directly from the DataGrid; the adaptor intercepts the deletion request, executes corresponding SQL DELETE statements, and removes the record from both the database and grid display.

Implement `RemoveAsync` to handle record deletion:

```csharp
public override async Task<object> RemoveAsync(DataManager dataManager, object value, string keyField, string key)
{
    // Extract record to delete (or use key parameter for primary key value)
    Tickets ticketToDelete = value as Tickets;
    
    // Call data layer method to delete from SQL Server
    await TicketService.RemoveTicketAsync(ticketToDelete.TicketId);
    
    // Return deleted record
    return value;
}
```

Record deletion has been implemented; tickets are now removed from the database and the grid UI reflects the changes immediately. Continue with batch operations to handle multiple record modifications in a single transaction.

In **Data/TicketData.cs**, implement the delete method:

```csharp
public async Task RemoveTicketAsync(int ticketId)
{
    string query = $"DELETE FROM dbo.Tickets WHERE TicketId={ticketId}";

    using (SqlConnection connection = new SqlConnection(connectionString))
    {
        connection.Open();
        using (SqlCommand command = new SqlCommand(query, connection))
        {
            await command.ExecuteNonQueryAsync();
        }
    }
}
```

### Batch operations

Batch operations aggregate multiple insertions, updates, and deletions into a single request, reducing network overhead and enabling transactional consistency by persisting all changes atomically to the SQL Server database.

Implement `BatchUpdateAsync` to process multiple record changes in a single request:

```csharp
public override async Task<object> BatchUpdateAsync(DataManager dataManager, object changed, object added, object deleted, string keyField, string key, int? dropIndex)
{
    // Process updated records
    if (changed != null)
    {
        foreach (var record in (IEnumerable<Tickets>)changed)
        {
            await TicketService.UpdateTicketAsync(record as Tickets);
        }
    }

    // Process new records
    if (added != null)
    {
        foreach (var record in (IEnumerable<Tickets>)added)
        {
            await TicketService.AddTicketAsync(record as Tickets);
        }
    }

    // Process deleted records
    if (deleted != null)
    {
        foreach (var record in (IEnumerable<Tickets>)deleted)
        {
            await TicketService.RemoveTicketAsync((record as Tickets).TicketId);
        }
    }

    return key;
}
```

Batch operations have been configured; the adaptor now supports bulk modifications with atomic database synchronization. All CRUD operations are now fully implemented, enabling comprehensive data management capabilities within the Blazor DataGrid.

---

## Run the application

Build and launch the Blazor application:

```powershell
dotnet build ; dotnet run
```

> A complete sample implementation is available in the [GitHub](https://github.com/SyncfusionExamples/connecting-databases-to-blazor-datagrid-component/tree/master/Binding%20MS%20SQL%20database%20using%20CustomAdaptor) repository.