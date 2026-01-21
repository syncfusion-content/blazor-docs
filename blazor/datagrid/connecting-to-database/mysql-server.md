---
layout: post
title: MySQL Server Data Binding in Blazor DataGrid Component using Entity Framework | Syncfusion
description: Learn about connecting MySQL Server with Entity Framework Core and binding data to Syncfusion Blazor DataGrid with complete CRUD operations.
platform: Blazor
control: DataGrid
documentation: ug
---

# Connecting MySQL Server data to Blazor DataGrid Component

The [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) component supports binding data from a MySQL Server database using Entity Framework Core (EF Core). This modern approach provides a more maintainable and type-safe alternative to raw SQL queries.

Entity Framework Core is an Object-Relational Mapper (ORM) that simplifies database operations by:
- Automatic SQL Generation: EF Core generates optimized SQL queries automatically.
- Type Safety: Work with strongly-typed objects instead of raw SQL strings.
- Built-in Protections: Automatic parameterization prevents SQL injection attacks.
- Migration Support: Manage database schema changes version-by-version.
- LINQ Queries: Use familiar LINQ syntax instead of SQL strings.

## Prerequisites

Ensure the following software and packages are installed before proceeding:

| Software/Package | Version | Purpose |
|-----------------|---------|---------|
| Visual Studio 2022 | 17.0 or later | Development IDE with Blazor workload |
| .NET SDK | net8.0 or compatible | Runtime and build tools |
| MySQL Server| 8.0.41 or later | Database server |
| Syncfusion.Blazor | 28.1.33 or later | DataGrid and UI components |
| Microsoft.EntityFrameworkCore | 9.0.0 or later | Defining DbContext and running LINQ queries |
| Pomelo.EntityFrameworkCore.MySql | 9.0.0 or later | MySQL EF Core provider |

## MySQL server environment

This project uses a MySQL database with Entity Framework Core (Pomelo) to store and manage payment transaction records and to support server-side CRUD, searching, filtering, sorting, grouping, and paging for the transactions table.

### Step 1: Create database and table in MySQL server

Create a MySQL database named **transactiondb** and a **transactions** table to store payment records. Run the below script on MySQL Workbench.

```sql
    -- Create Database
    CREATE DATABASE IF NOT EXISTS transactiondb;
    USE transactiondb;

    -- Create Transaction Table
    CREATE TABLE IF NOT EXISTS transactions (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    TransactionId VARCHAR(50) NOT NULL UNIQUE,
    CustomerId INT NOT NULL,
    OrderId INT NULL,
    InvoiceNumber VARCHAR(50) NULL,
    Description VARCHAR(500) NULL,
    Amount DECIMAL(15, 2) NOT NULL,
    CurrencyCode VARCHAR(10) NULL,
    TransactionType VARCHAR(50) NULL,
    PaymentGateway VARCHAR(100) NULL,
    CreatedAt DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
    CompletedAt DATETIME NULL,
    Status VARCHAR(50) NULL);

    -- Insert Sample Data (Optional)
    INSERT INTO transactions (TransactionId, CustomerId, OrderId, InvoiceNumber, Description, Amount, CurrencyCode, TransactionType, PaymentGateway, CreatedAt, CompletedAt, Status) VALUES
('TXN260113001', 1001, 50001, 'INV-2026-001', 'Samsung S25 Ultra', 153399.00, 'INR', 'SALE', 'Razorpay', '2026-01-13 10:15:30', '2026-01-13 10:16:55', 'SUCCESS'),
('TXN260113002', 1002, 50002, 'INV-2026-002', 'MacBook Pro M4', 224199.00, 'INR', 'SALE', 'Stripe', '2026-01-13 11:20:10', '2026-01-13 11:21:40', 'SUCCESS');
```
The above script stores the transaction records in the transactions table within the transactiondb database.

### Step 2: Install required NuGet packages

Open the Package Manager Console in Visual Studio and install the necessary packages:

```powershell
Install-Package Microsoft.EntityFrameworkCore -Version 9.0.0 ;
Install-Package Pomelo.EntityFrameworkCore.MySql -Version 9.0.0
```
Alternatively, use NuGet Package Manager UI:

1. Open **Visual Studio 2022 → Tools → NuGet Package Manager → Manage NuGet Packages for Solution**
2. Search for and install **Microsoft.EntityFrameworkCore** (version 9.0.0 or later)
3. Search for and install **Pomelo.EntityFrameworkCore.MySql** (version 9.0.0 or later)

Now the required packages are installed for the server setup.

### Step 3: Create the data model

Create a **Data** folder and add **Transaction.cs** file. Now define a model class named "TransactionModel" with appropriate properties and data annotations that represents the database entity.

```csharp
using System.ComponentModel.DataAnnotations;

namespace Transaction.Data
{
    public class TransactionModel
    {
        [Key]
        public int Id { get; set; }

        public string? TransactionId { get; set; }
        public int? CustomerId { get; set; }
        public int? OrderId { get; set; }
        public string? InvoiceNumber { get; set; }
        public string? Description { get; set; }
        public decimal Amount { get; set; }
        public string? CurrencyCode { get; set; }
        public string? TransactionType { get; set; }
        public string? PaymentGateway { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? CompletedAt { get; set; }
        public string? Status { get; set; }
    }
}
```
Now Model class for the transactions table has been created.

### Step 4: Configure the DbContext

The `DbContext` is the Entity Framework Core class that manages database connections and translates application-level operations into MySQL commands.

Create the **Data/TransactionDbContext.cs** file and define the DbContext class "TransactionDbContext". This class defines entity configurations of MySQL database.

```csharp
using Microsoft.EntityFrameworkCore;

namespace Transaction.Data
{
    /// <summary>
    /// DbContext for Transaction entity
    /// Manages database connections and entity configurations
    /// </summary>
    public class TransactionDbContext : DbContext
    {
        public TransactionDbContext(DbContextOptions<TransactionDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// DbSet for Transaction entities
        /// </summary>
        public DbSet<TransactionModel> Transactions => Set<TransactionModel>();

        /// <summary>
        /// Configures the entity mappings and constraints
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Transaction entity
            modelBuilder.Entity<TransactionModel>(entity =>
            {
                // Primary Key
                entity.HasKey(e => e.Id);

                // Auto-increment for Primary Key
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                // Column configurations
                entity.Property(e => e.TransactionId)
                    .HasMaxLength(50)
                    .IsRequired(true);

                entity.Property(e => e.InvoiceNumber)
                    .HasMaxLength(100)
                    .IsRequired(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .IsRequired(false);

                entity.Property(e => e.CurrencyCode)
                    .HasMaxLength(3)
                    .HasDefaultValue("INR");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(50)
                    .IsRequired(false);

                entity.Property(e => e.PaymentGateway)
                    .HasMaxLength(50)
                    .IsRequired(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsRequired(false);

                entity.Property(e => e.Amount)
                    .HasPrecision(10, 2);

                entity.Property(e => e.CustomerId)
                    .IsRequired(false);

                entity.Property(e => e.OrderId)
                    .IsRequired(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .IsRequired(false);

                entity.Property(e => e.CompletedAt)
                    .HasColumnType("datetime")
                    .IsRequired(false);

                entity.ToTable("transactions");
            });
        }
    }
}
```

### Step 5: Configure the connection string

The connection string specifies the information that connects the database like MySQL server location, credentials, and database name in the runtime.
Update **appsettings.json** file with MySQL connection string:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=transactiondb;User=root;Password=your_password;"
  },
}
```

**Connection String Components:**
- Server: MySQL server address (localhost for local development)
- Port: MySQL port (default is 3306)
- Database: Database name (transactiondb)
- User: MySQL username (root)
- Password: MySQL password

Now data base connection has been completed.

### Step 6: Create the repository pattern class

Create a repository class in **Data/TransactionRepository.cs** to handle all data operations with Entity Framework Core:

```csharp
using Microsoft.EntityFrameworkCore;

namespace Transaction.Data
{
    /// <summary>
    /// Repository pattern implementation for Transaction entity using Entity Framework Core
    /// Handles all CRUD operations and business logic for transactions
    /// </summary>
    public class TransactionRepository
    {
        private readonly TransactionDbContext _context;

        public TransactionRepository(TransactionDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all transactions from the database ordered by ID descending
        /// </summary>
        /// <returns>List of all transactions</returns>
        public async Task<List<TransactionModel>> GetTransactionsAsync()
        {
            return await _context.Transactions
                .OrderByDescending(t => t.Id)
                .ToListAsync();
        }
    }
}
```

### Step 7: Register DbContext

Register APIs via dependency injection.

Configure Entity Framework Core in **Program.cs** file:

```csharp
using Microsoft.EntityFrameworkCore;

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<TransactionDbContext>(options =>
{
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    );
});
```
Now Services registration have been completed.

## Integrating Syncfusion Blazor DataGrid

### Step 1: Install required NuGet packages and register Syncfusion services
Open the Package Manager Console in Visual Studio and install the necessary packages:

```powershell
Install-Package Syncfusion.Blazor -Version 28.1.33
```
Registers the Syncfusion component services required by the DataGrid at runtime and exposes grid APIs via dependency injection.

Configure Syncfusion services in **Program.cs**:

```csharp
using Syncfusion.Blazor;

// Register Syncfusion Blazor services
builder.Services.AddSyncfusionBlazor();
```

Add required namespaces in **Components/_Imports.razor**:
 
```csharp
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
```
 
Add stylesheet and script resources in **Components/App.razor**
 
```html
<!-- Syncfusion Blazor CSS -->
<link href="_content/Syncfusion.Blazor/styles/tailwind3.css" rel="stylesheet" />
<!-- Syncfusion Blazor Scripts -->
<script src="_content/Syncfusion.Blazor/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
```
Service registration and namespace imports have been completed.

### Step 2: Binding data from MySQL Server using CustomAdaptor

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can bind data from a **MySQL Server** database using [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) and set the [Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Adaptors.html) property to [CustomAdaptor](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/custom-adaptor) for scenarios that require full control over data operations.
The Custom Adaptor serves as the bridge between DataGrid UI interactions and MySQL Server database operations. When users interact with the grid (search, filter, sort, page), the adaptor intercepts these requests and executes corresponding MySQL operations.

### Implement custom adaptor

Create a Custom Adaptor class in **Components/Pages/Home.razor** that bridges DataGrid actions with MySQL Server operations:

```csharp
    public class CustomAdaptor : DataAdaptor
    {
        public static TransactionRepository? _transactionService { get; set; }
        public TransactionRepository? TransactionService 
        { 
            get => _transactionService;
            set => _transactionService = value;
        }

        /// <summary>
        /// ReadAsync - Retrieves records from MySQL Server and applies data operations
        /// Executes on grid initialization and when user performs search, filter, sort, page operations
        /// </summary>
        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
        {
            // Fetch all records from MySQL Server via data layer
            IEnumerable <TransactionModel> dataSource = await _transactionService!.GetTransactionsAsync();

            // Apply data operations (search, filter, sort, aggregate, paging, grouping) as requested
            // Detailed implementations for each operation follow in subsequent sections

            // Calculate total record count for pagination metadata
            int totalRecordsCount = dataSource.Cast<TransactionModel>().Count();

            // Return DataResult containing filtered/sorted records and total count
            return dataManagerRequest.RequiresCounts 
                ? new DataResult() { Result = dataSource, Count = totalRecordsCount } 
                : (object)dataSource;
        } 
    }
```
**Custom Adaptor methods reference**:
- [ReadAsync(DataManagerRequest)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_ReadAsync_Syncfusion_Blazor_DataManagerRequest_System_String_) - Retrieve and process records (search, filter, sort, page, group)
- [InsertAsync(DataManager, object)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_InsertAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_) - Create new records in MySQL Server
- [UpdateAsync(DataManager, object, string, string)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_UpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) - Edit existing records in MySQL Server
- [RemoveAsync(DataManager, object, string, string)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_RemoveAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) - Delete records from MySQL Server
- [BatchUpdateAsync(DataManager, object, object, object, string, string, int?)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_BatchUpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_Object_System_Object_System_String_System_String_System_Nullable_System_Int32__) - Handle bulk operations

Bind the adaptor to the DataGrid markup in **Home.razor**:

```html
<SfGrid TValue="TransactionModel" Height="500px" Width="100%" 
    Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel"})">
    
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.CheckBox"></GridFilterSettings>
    <GridEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true" Mode="EditMode.Normal"></GridEditSettings>
    
    <GridColumns>
    <GridColumn Field=@nameof(TransactionModel.Id) IsPrimaryKey="true" ShowInColumnChooser="false" ShowColumnMenu="false"></GridColumn>

    <GridColumn Field=@nameof(TransactionModel.TransactionId) HeaderText="Transaction ID" Width="170" TextAlign="TextAlign.Left" AllowAdding="false" AllowEditing="false" FilterSettings="IdFilterSettings">
        <Template>
            @{
                var data = (TransactionModel)context;
            }   
            <a class="status-text status-ticket-id">
                @data.TransactionId
            </a>
        </Template>
    </GridColumn>

    <GridColumn Field=@nameof(TransactionModel.CustomerId) HeaderText="Customer ID" ValidationRules="@(new ValidationRules { Required = true })" Width="140" EditType="EditType.NumericEdit" FilterSettings="NumberFilterSettings" />

    <GridColumn Field=@nameof(TransactionModel.OrderId) HeaderText="Order ID" Width="120" ValidationRules="@(new ValidationRules { Required = true })" EditType="EditType.NumericEdit" FilterSettings="NumberFilterSettings" />

    <GridColumn Field=@nameof(TransactionModel.InvoiceNumber) HeaderText="Invoice No" Width="130" EditType="EditType.DefaultEdit" FilterSettings="IdFilterSettings" />

    <GridColumn Field=@nameof(TransactionModel.Description) HeaderText="Description" Width="180" EditType="EditType.DefaultEdit" />

    <GridColumn Field=@nameof(TransactionModel.Amount) HeaderText="Amount" Width="130" Format="N2" FilterSettings="NumberFilterSettings" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit">
        <Template>
            @{
                var amount = (context as TransactionModel)?.Amount ?? 0;
                var amountClass = amount < 0 ? "amnt-negative" : "amnt-positive";
            }
            <span class="@amountClass">@amount.ToString("N2")</span>
        </Template>
    </GridColumn>

    <GridColumn Field=@nameof(TransactionModel.CurrencyCode) HeaderText="Curr" Width="100" TextAlign="TextAlign.Center" EditType="EditType.DefaultEdit" />

    <GridColumn Field=@nameof(TransactionModel.TransactionType) HeaderText="Type" Width="100" ValidationRules="@(new ValidationRules { Required = true })" EditType="EditType.DropDownEdit" EditorSettings="@TypeDropDownParams">
        <Template>
            @{
                var data = (TransactionModel)context;
            }
            <span class="chip @GetCategoryClass(data)">
                @data.TransactionType
            </span>
        </Template>
    </GridColumn>

    <GridColumn Field=@nameof(TransactionModel.PaymentGateway) HeaderText="Gateway" Width="130" EditType="EditType.DropDownEdit" EditorSettings="@GatewayDropDownParams" />

    <GridColumn Field=@nameof(TransactionModel.CreatedAt) HeaderText="Created" Width="165" FilterSettings="NumberFilterSettings" Format="dd-MMM-yy hh:mm tt" ValidationRules="@(new ValidationRules { Required = true })" TextAlign="TextAlign.Right" Type="ColumnType.DateTime" AllowEditing="false" />

    <GridColumn Field=@nameof(TransactionModel.CompletedAt) HeaderText="Completed" Width="165" FilterSettings="NumberFilterSettings" Format="dd-MMM-yy hh:mm tt" TextAlign="TextAlign.Right" Type="ColumnType.DateTime" EditType="EditType.DateTimePickerEdit" />

    <GridColumn Field=@nameof(TransactionModel.Status) HeaderText="Status" Width="110" ValidationRules="@(new ValidationRules { Required = true })" EditType="EditType.DropDownEdit" EditorSettings="@StatusDropDownParams">
        <Template>
            @{
                var status = (context as TransactionModel)?.Status;
                var badgeClass = status?.ToLower() switch
                {
                    "success" => "e-badge e-badge-success",
                    "failed" => "e-badge e-badge-danger",
                    "pending" => "e-badge e-badge-warning",
                    "processing" => "e-badge e-badge-info",
                    _ => "e-badge"
                };
            }
            <span class="@badgeClass">@status</span>
        </Template>
    </GridColumn>
</GridColumns>
</SfGrid>
```

**Data flow architecture**:

![Blazor DataGrid component bound with Microsoft MySQL Server data](../images/blazor-Grid-Ms-SQl-databinding-architecture-Png.png)

The Custom Adaptor implementation centralizes all database logic, enabling consistent MySQL execution, error handling, and performance optimization across all grid operations.

### Handling data operations

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports server-side operations such as searching, filtering, sorting, paging, and aggregating when using the CustomAdaptor by overriding the `ReadAsync` method of the `DataAdaptor` abstract class.

The `DataManagerRequest` object supplies the necessary details for each operation, and the built‑in methods in the `DataOperations` and `DataUtil` classes apply those details accordingly.

**Common methods in dataoperations**

* [PerformSearching](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSearching__1_System_Linq_IQueryable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_SearchFilter__) - Applies search criteria to the collection.
* [PerformFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformFiltering__1_System_Linq_IQueryable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_WhereFilter__System_String_) - Filters data based on conditions.
* [PerformSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSorting__1_System_Linq_IQueryable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_Sort__) - Sorts data by one or more fields.
* [PerformSkip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSkip__1_System_Linq_IQueryable___0__System_Int32_) - Skips a defined number of records for paging.
* [PerformTake](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformTake__1_System_Linq_IQueryable___0__System_Int32_) - Retrieves a specified number of records for paging.
* [PerformAggregation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.DataUtil.html#Syncfusion_Blazor_Data_DataUtil_PerformAggregation_System_Collections_IEnumerable_System_Collections_Generic_List_Syncfusion_Blazor_Data_Aggregate__) – Calculates aggregate values such as Sum, Average, Min, and Max.

---

### Handling searching operation

Enables keyword-based query across configured fields, allowing the grid to delegate search criteria to the adaptor for efficient server-side filtering. The built-in `PerformSearching` method of the `DataOperations` class applies search criteria from the `DataManagerRequest` to the data source.

```csharp
public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
{
    IEnumerable <TransactionModel> dataSource = await _transactionService!.GetTransactionsAsync();

    // Handling Searching
    if (dataManagerRequest.Search != null && dataManagerRequest.Search.Count > 0)
    {
        dataSource = DataOperations.PerformSearching(dataSource, dataManagerRequest.Search);
    }   

    return dataManagerRequest.RequiresCounts 
        ? new DataResult() { Result = dataSource, Count = totalRecordsCount } 
        : (object)dataSource;
}
```

Enable the search toolbar in DataGrid markup:

```html
<SfGrid TValue="TransactionModel" Toolbar="@(new List<string>() { "Search" })">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <!-- Grid configuration -->
</SfGrid>
```
---

### Handling filtering operation

Provides column-level criteria evaluation so the adaptor can restrict datasets at the source for precise, efficient retrieval. The built-in `PerformFiltering` method in the `DataOperations` class applies filter criteria from the `DataManagerRequest` to the data collection.

```csharp
public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
{
    IEnumerable <TransactionModel> dataSource = await _transactionService!.GetTransactionsAsync();

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

    return dataManagerRequest.RequiresCounts 
        ? new DataResult() { Result = dataSource, Count = totalRecordsCount } 
        : (object)dataSource;
}
```

Enable filtering in DataGrid markup:

```html
<SfGrid TValue="TransactionModel" AllowFiltering="true" Toolbar="@(new List<string>() { "Search" })">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridFilterSettings Type="FilterType.Menu"></GridFilterSettings>
    <!-- Grid columns -->
</SfGrid>
```
---

### Handling sorting operation

Enables deterministic record ordering by delegating sort descriptors to the adaptor for database-optimized sorting. The built-in `PerformSorting` method in the `DataOperations` class applies sort criteria from the `DataManagerRequest` to the data collection.

```csharp
public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
{
    IEnumerable <TransactionModel> dataSource = await _transactionService!.GetTransactionsAsync();

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

    return dataManagerRequest.RequiresCounts 
        ? new DataResult() { Result = dataSource, Count = totalRecordsCount } 
        : (object)dataSource;
}
```
Enable sorting in DataGrid markup:

```html
<SfGrid TValue="TransactionModel" AllowFiltering="true" AllowSorting="True" Toolbar="@(new List<string>() { "Search" })">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridFilterSettings Type="FilterType.Menu"></GridFilterSettings>
    <!-- Grid columns -->
</SfGrid>
```
---

### Handling aggregation operation

Aggregate functions compute summary statistics across datasets without requiring row-level retrieval, enabling efficient calculation of totals, averages, and counts at the database server level. The built-in `PerformAggregation` method in the [DataUtil](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.DataUtil.html) class calculates aggregate values based on the criteria specified in the `DataManagerRequest`.

```csharp
public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
{
    IEnumerable <TransactionModel> dataSource = await _transactionService!.GetTransactionsAsync();

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

    // Handling Aggregation
    IDictionary<string, object>? aggregates = null;
    if (dataManagerRequest.Aggregates != null)
    {
        aggregates = DataUtil.PerformAggregation(dataSource, dataManagerRequest.Aggregates);
    }

    return dataManagerRequest.RequiresCounts 
        ? new DataResult() { Result = dataSource, Count = totalRecordsCount } 
        : (object)dataSource;
}
```
Enable aggregates in DataGrid markup:

```html
<SfGrid TValue="TransactionModel" AllowFiltering="true" AllowSorting="True" Toolbar="@(new List<string>() { "Search" })">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridFilterSettings Type="FilterType.Menu"></GridFilterSettings>
    <!-- Grid columns -->
    <GridAggregates>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field="Id" Type="AggregateType.Count"></GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
    </GridAggregates>
</SfGrid>
```
---

### Handling paging operation

Paging divides large result sets into fixed-size pages, reducing memory consumption and improving client-side responsiveness by retrieving only the requested page from the server.The built-in `PerformSkip`, `PerformTake` methods in the `DataOperations` class apply paging criteria from the `DataManagerRequest` to the data collection.

```csharp
public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
{
    IEnumerable <TransactionModel> dataSource = await _transactionService!.GetTransactionsAsync();

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

    // Handling Aggregation
    IDictionary<string, object>? aggregates = null;
    if (dataManagerRequest.Aggregates != null)
    {
        aggregates = DataUtil.PerformAggregation(dataSource, dataManagerRequest.Aggregates);
    }

    int totalRecordsCount = dataSource.Cast<TransactionModel>().Count();
  
    // Handling Paging
    if (dataManagerRequest.Skip != 0)
    {
        dataSource = DataOperations.PerformSkip(dataSource, dataManagerRequest.Skip);
        //Add custom logic here if needed and remove above method
    }

    if (dataManagerRequest.Take != 0)
    {
        dataSource = DataOperations.PerformTake(dataSource, dataManagerRequest.Take);
        //Add custom logic here if needed and remove above method
    }

    return dataManagerRequest.RequiresCounts 
        ? new DataResult() { Result = dataSource, Count = totalRecordsCount } 
        : (object)dataSource;
}
```
Enable paging in DataGrid markup:

```html
<SfGrid AllowFiltering="true" AllowSorting="True" AllowPaging="true" Toolbar="@(new List<string>() { "Search" })">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridFilterSettings Type="FilterType.Menu"></GridFilterSettings>
    <GridPageSettings PageSize="10"></GridPageSettings>
    <GridAggregates>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field="Id" Type="AggregateType.Count"></GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
    </GridAggregates>
    <!-- Grid columns -->
</SfGrid>
```
---

### Handling grouping operation

Grouping hierarchically organizes records by specified column values, enabling data summarization and nested record visualization while reducing query complexity through server-side grouping operations.The built-in `Group` method in the `DataUtil` class applies grouping logic based on the configuration in the `DataManagerRequest`.
```csharp
public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
{
    IEnumerable <TransactionModel> dataSource = await _transactionService!.GetTransactionsAsync();

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

    // Handling Aggregation
    IDictionary<string, object>? aggregates = null;
    if (dataManagerRequest.Aggregates != null)
    {
        aggregates = DataUtil.PerformAggregation(dataSource, dataManagerRequest.Aggregates);
    }

    int totalRecordsCount = dataSource.Cast<TransactionModel>().Count();

    // Handling Paging
    if (dataManagerRequest.Skip != 0)
    {
        dataSource = DataOperations.PerformSkip(dataSource, dataManagerRequest.Skip);
        //Add custom logic here if needed and remove above method
    }

    if (dataManagerRequest.Take != 0)
    {
        dataSource = DataOperations.PerformTake(dataSource, dataManagerRequest.Take);
        //Add custom logic here if needed and remove above method
    }

    DataResult dataObject = new DataResult();
    // Handling Grouping
    if (dataManagerRequest.Group != null)
    {
        IEnumerable ResultData = dataSource.ToList();
        foreach (var group in dataManagerRequest.Group)
        {
            ResultData = DataUtil.Group<TransactionModel>(ResultData, group, dataManagerRequest.Aggregates, 0, dataManagerRequest.GroupByFormatter);
            //Add custom logic here if needed and remove above method
        }
        dataObject.Result = ResultData;
        dataObject.Count = totalRecordsCount;
        dataObject.Aggregates = aggregates;
        return dataManagerRequest.RequiresCounts ? dataObject : (object)ResultData;
    }

    return dataManagerRequest.RequiresCounts 
        ? new DataResult() { Result = dataSource, Count = totalRecordsCount } 
        : (object)dataSource;
}
```

```html
<SfGrid TValue="TransactionModel" AllowFiltering="true" AllowSorting="True" AllowPaging="true" AllowGrouping="true" Toolbar="@(new List<string>() { "Search" })">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridFilterSettings Type="FilterType.Menu"></GridFilterSettings>
    <GridPageSettings PageSize="10"></GridPageSettings>
    <GridGroupSettings Columns="@(new string[] { "Status" })"></GridGroupSettings>
    <GridAggregates>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field="Id" Type="AggregateType.Count"></GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
    </GridAggregates>
    <!-- Grid columns -->
</SfGrid>
```

### Handling CRUD operations

Custom Adaptor methods enable users to create, read, update, and delete records directly from the DataGrid. Each operation calls corresponding data layer methods in TransactionRepository.cs to execute MySQL commands.

**Insert operation**

Record insertion enables users to create new transactions directly from the DataGrid interface; the adaptor intercepts the insertion request, applies business logic validation, and persists the new record to the MySQL Server database.

Implement `InsertAsync` to handle new record creation:

```csharp
public override async Task<object> InsertAsync(DataManager dataManager, object value, string key)
{
    if (value is TransactionModel transaction)
    {
        // Add your insert logic here
        // This method will be invoked when inserting new records into the Blazor DataGrid component.
        await _transactionService!.AddTransactionAsync(transaction);
    }
    return value;
}
```
In **Data/TransactionRepository.cs**, implement the insert method:

```csharp
    public async Task AddTransactionAsync(TransactionModel value)
    {
        // Add the transaction to the context
        _context.Transactions.Add(value);

        // Save changes to database
        await _context.SaveChangesAsync();
    }
```
Record insertion has been configured; the new transaction is now persisted to the database and reflected in the grid.

**Update operation**

Record modification enables users to edit transaction attributes directly within the DataGrid; the adaptor captures the edited row, validates changes, and synchronizes modifications to the MySQL Server database while maintaining data integrity.

Implement `UpdateAsync` to handle record modifications:

```csharp
public override async Task<object> UpdateAsync(DataManager dataManager, object value, string keyField, string key)
{
    if (value is TransactionModel transaction)
    {
        // Add your update logic here
        // This method will be invoked when updating existing records in the Blazor DataGrid component.
        await _transactionService!.UpdateTransactionAsync(transaction);
    }
    return value;
}
```
In **Data/TransactionRepository.cs**, implement the update method:

```csharp
public async Task UpdateTransactionAsync(TransactionModel value)
{
    // Check if transaction exists
    var existingTransaction = await _context.Transactions.FindAsync(value.Id);
    if (existingTransaction == null)
        throw new KeyNotFoundException($"Transaction with ID {value.Id} not found");

    // Update the entity
    _context.Transactions.Update(value);
    await _context.SaveChangesAsync();
}
```
Record updates have been configured; modifications are now synchronized to the database and reflected in the grid UI.

**Delete operation**

Record deletion enables users to remove transactions directly from the DataGrid; the adaptor intercepts the deletion request, executes corresponding MySQL DELETE statements, and removes the record from both the database and grid display.

Implement `RemoveAsync` to handle record deletion:

```csharp
public override async Task<object> RemoveAsync(DataManager dataManager, object value, string keyField, string key)
{
    // Add your delete logic here
    // This method will be invoked when deleting existing records from the Blazor DataGrid component.
    int? recordId = null;
    if (value is int intValue)
    {
        recordId = intValue;
    }
    else if (value is TransactionModel transaction)
    {
        recordId = transaction.Id;
    }
    else if (int.TryParse(value?.ToString(), out int parsedValue))
    {
        recordId = parsedValue;
    }

    if (recordId.HasValue && recordId.Value > 0)
    {
        await _transactionService!.RemoveTransactionAsync(recordId);
    }
    return value;
}
```
In **Data/TransactionRepository.cs**, implement the delete method:

```csharp
public async Task RemoveTransactionAsync(int? key)
{
    // Find the transaction
    var transaction = await _context.Transactions.FindAsync(key);
    if (transaction == null)
        throw new KeyNotFoundException($"Transaction with ID {key} not found");

    // Remove and save
    _context.Transactions.Remove(transaction);
    await _context.SaveChangesAsync();
}
```
Record deletion has been implemented; transactions are now removed from the database and the grid UI reflects the changes immediately.

**Batch update operation**

Batch operations aggregate multiple insertions, updates, and deletions into a single request, reducing network overhead and enabling transactional consistency by persisting all changes atomically to the MySQL Server database.

Implement `BatchUpdateAsync` to process multiple record changes in a single request:

```csharp
public override async Task<object> BatchUpdateAsync(DataManager dataManager, object changed, object added, object deleted, string keyField, string key, int? dropIndex)
{
    // Process updated records
    if (changed != null)
    {
        foreach (var record in (IEnumerable<TransactionModel>)changed)
        {
            await _transactionService!.UpdateTransactionAsync(record);
        }
    }

    // Process newly added records
    if (added != null)
    {
        foreach (var record in (IEnumerable<TransactionModel>)added)
        {
            await _transactionService!.AddTransactionAsync(record);
        }
    }

    // Process deleted records
    if (deleted != null)
    {
        foreach (var record in (IEnumerable<TransactionModel>)deleted)
        {
            await _transactionService!.RemoveTransactionAsync(record.Id);
        }
    }
    return key;
}
```

Batch operations have been configured; the adaptor now supports bulk modifications with atomic database synchronization. All CRUD operations are now fully implemented, enabling comprehensive data management capabilities within the Blazor DataGrid.

---
### Running the sample

Build and run the application:
   ```powershell
   dotnet build
   dotnet run
   ```
Navigate to the application URL (e.g., https://localhost:5001) to view the DataGrid with MySQL Server data binding.

> A complete sample implementation is available in the [GitHub](https://github.com/SyncfusionExamples/connecting-databases-to-blazor-datagrid-component/tree/master/Binding%20MS%20SQL%20database%20using%20CustomAdaptor) repository.