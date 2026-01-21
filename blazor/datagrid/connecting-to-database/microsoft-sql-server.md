---
layout: post
title: Microsoft SQL Server Data Binding in Blazor DataGrid Component | Syncfusion
description: Learn how to bind Microsoft SQL Server data to Syncfusion Blazor DataGrid using CustomAdaptor, enable CRUD operations, and implement server-side data processing with raw SQL queries.
platform: Blazor
control: DataGrid
documentation: ug
---

# Connecting Microsoft SQL Server Data to Blazor DataGrid Using Custom Adaptor

Syncfusion Blazor DataGrid provides seamless integration with Microsoft SQL Server databases through a Custom Adaptor pattern. This guide demonstrates implement SQL Server data directly to the grid, implement server-side data operations (searching, filtering, sorting, paging, grouping), and enable full CRUD (Create, Read, Update, Delete) functionality using raw SQL queries via SqlClient.

---

## Use Microsoft SQL Server with Blazor DataGrid

Microsoft SQL Server offers enterprise-grade capabilities for building scalable, secure data-driven applications with Blazor. Integrating SQL Server directly with Syncfusion DataGrid provides significant advantages:

- Performance optimization: Process large datasets server-side before transmitting filtered, sorted, and paginated results to the client, reducing bandwidth and improving response times.
- Direct SQL execution: Use raw SQL queries with SqlClient for precise database control without ORM abstraction layers, enabling transparent query debugging and optimization.
- Enterprise security: Leverage SQL Server's built-in encryption, role-based access control, and authentication mechanisms to protect sensitive ticket data.
- Scalability: Handle growing data volumes efficiently through server-side filtering, aggregation, and pagination operations.
- CRUD integration: Enable users to create, read, update, and delete records directly from the DataGrid UI with automatic database synchronization.
- Server-side operations: Implement searching, filtering, sorting, grouping, and aggregation on the database server, reducing client-side processing overhead.

## Prerequisites for integration

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

Open SQL Server Management Studio (SSMS) and execute the following script to create the database and Tickets table:

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

### Step 2: Install required NuGet packages

Open the Package Manager Console in Visual Studio and install the necessary packages:

```powershell
Install-Package Syncfusion.Blazor -Version 28.1.33 ;
Install-Package Microsoft.Data.SqlClient -Version 5.2.0
```

Alternatively, use NuGet Package Manager UI:
1. Navigate to **Tools** → **NuGet Package Manager** → **Manage NuGet Packages for Solution**
2. Search for and install **Syncfusion.Blazor** (latest stable version)
3. Search for and install **Microsoft.Data.SqlClient** (version 5.2.0 or later)

### Step 3: Define the data model

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

### Step 4: Configure connection string

Define the SQL Server connection string in `Data/TicketData.cs`:

```csharp
public class TicketData
{
    private string connectionString = "Data Source=YOUR_SERVER;Initial Catalog=YOUR_DATABASE;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
}
```

**Connection string parameters**:
- `Data Source=YOUR_SERVER` - SQL Server instance name (e.g., `localhost\SQLEXPRESS`, `DESKTOP-ABC123`, `192.168.1.100`)
- `Initial Catalog=YOUR_DATABASE` - Target database name (e.g., `NetworkSupportDB`)
- `Integrated Security=True` - Enable Windows Authentication
- `Connect Timeout=30` - Connection timeout in seconds
- `Encrypt=False` - Disable SSL encryption for development environments (enable for production)

### Step 5: Create data access layer (TicketData.cs)
Implement the `GetTicketsData()` method in `Data/TicketData.cs` to fetch records from SQL Server:

```csharp
using Microsoft.Data.SqlClient;
using System.Data;

public class TicketData
{
    private string connectionString = "Data Source=YOUR_SERVER;Initial Catalog=YOUR_DATABASE;Integrated Security=True;Connect Timeout=30;Encrypt=False;";

    public async Task<List<Tickets>> GetTicketsData()
    {
        // Define SELECT query
        string queryString = "SELECT * FROM dbo.Tickets ORDER BY TicketId";
        
        // Establish SQL connection
        using (SqlConnection sqlConnection = new SqlConnection(connectionString))
        {
            sqlConnection.Open();
            
            // Create SQL command
            using (SqlCommand sqlCommand = new SqlCommand(queryString, sqlConnection))
            {
                // Execute query and populate DataTable via SqlDataAdapter
                using (SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                {
                    DataTable dataTable = new DataTable();
                    sqlDataAdapter.Fill(dataTable);
                    
                    // Map DataTable rows to Tickets model using LINQ projection
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

**Key implementation details**:
- Use `using` statements to ensure automatic disposal of SqlConnection, SqlCommand, and SqlDataAdapter
- Execute `sqlDataAdapter.Fill(dataTable)` to populate the DataTable with query results
- Handle null values using `DBNull.Value` checks for nullable DateTime fields
- Return `List<Tickets>` to adaptor for DataGrid binding

### Step 6: Register Syncfusion services

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
@using Microsoft.Data.SqlClient
```

### Step 7: Implement custom adaptor

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
- `ReadAsync(DataManagerRequest)` - Retrieve and process records (search, filter, sort, page, group)
- `InsertAsync(DataManager, object)` - Create new records in SQL Server
- `UpdateAsync(DataManager, object, string, string)` - Edit existing records in SQL Server
- `RemoveAsync(DataManager, object, string, string)` - Delete records from SQL Server
- `BatchUpdateAsync(DataManager, object, object, object, string, string, int?)` - Handle bulk operations

Bind the adaptor to the DataGrid markup in `Home.razor`:

```html
<SfGrid TValue="Tickets" AllowSorting="true" AllowFiltering="true" AllowPaging="true" 
        Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" })">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field="@nameof(Tickets.TicketId)" HeaderText="ID" IsPrimaryKey="true" IsIdentity="true"></GridColumn>
        <GridColumn Field="@nameof(Tickets.PublicTicketId)" HeaderText="Ticket #"></GridColumn>
        <GridColumn Field="@nameof(Tickets.Title)" HeaderText="Subject"></GridColumn>
        <GridColumn Field="@nameof(Tickets.Status)" HeaderText="Status"></GridColumn>
        <GridColumn Field="@nameof(Tickets.Priority)" HeaderText="Priority"></GridColumn>
        <GridColumn Field="@nameof(Tickets.DueDate)" HeaderText="Due Date" Type="ColumnType.Date"></GridColumn>
    </GridColumns>
</SfGrid>
```

---

## Connecting Syncfusion Blazor DataGrid to Microsoft SQL Server

The Custom Adaptor serves as the bridge between DataGrid UI interactions and SQL Server database operations. When users interact with the grid (search, filter, sort, page), the adaptor intercepts these requests and executes corresponding SQL operations.

**Data flow architecture**:

1. User interaction → Grid detects user action (click, type, scroll)
2. DataManagerRequest creation → Grid creates request object with operation parameters
3. Custom Adaptor invocation → SfDataManager calls appropriate adaptor method
4. Data Layer execution → Adaptor calls TicketData methods to execute SQL queries
5. Result processing → Adaptor applies data transformations and returns DataResult
6. Grid rendering → Grid displays processed data in UI

The Custom Adaptor implementation centralizes all database logic, enabling consistent SQL execution, error handling, and performance optimization across all grid operations.
## Handling data operations

Server-side data operations optimize performance by processing data before transmission to the client. Each operation in the Custom Adaptor's `ReadAsync` method handles specific grid functionality.

---

### Implement searching

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

---

### Apply filtering

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

---

### Enable sorting

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

---

### Configure aggregates

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

---

### Add paging support

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

---

### Enable grouping

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

---
## Handling CRUD operations

Custom Adaptor methods enable users to create, read, update, and delete records directly from the DataGrid. Each operation calls corresponding data layer methods in TicketData.cs to execute SQL commands.

### Create (Insert) records

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

In `Data/TicketData.cs`, implement the insert method:

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

### Read (Retrieve) records

The `ReadAsync` method is implemented in Step 7, retrieving and processing records from SQL Server.

### Update (Edit) records

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

In `Data/TicketData.cs`, implement the update method:

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

### Delete (Remove) records

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

In `Data/TicketData.cs`, implement the delete method:

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

---

## Run the application

Build and launch the Blazor application:

```powershell
dotnet build ; dotnet run
```

Navigate to the application URL (e.g., `https://localhost:5001`) to view the DataGrid with SQL Server data binding.
