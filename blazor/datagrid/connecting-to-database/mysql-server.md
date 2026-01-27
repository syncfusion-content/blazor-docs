---
layout: post
title: Blazor Data Grid connected to MySQL via Entity Framework | Syncfusion
description: Bind MySQL data to Blazor Data Grid using Entity Framework Core with complete CRUD, filtering, sorting, paging, and advanced data operations.
platform: Blazor
control: DataGrid
documentation: ug
---

# Connecting MySQL Server to Blazor Data Grid Using Entity Framework

The [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) supports binding data from a MySQL Server database using Entity Framework Core (EF Core). This modern approach provides a more maintainable and type-safe alternative to raw SQL queries.

**What is Entity Framework Core?**

Entity Framework Core (EF Core) is a software tool that simplifies database operations in .NET applications. It serves as a bridge between C# code and databases like MySQL.

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
| Visual Studio 2022 | 17.0 or later | Development IDE with Blazor workload |
| .NET SDK | net8.0 or compatible | Runtime and build tools |
| MySQL Server | 8.0.41 or later | Database server |
| Syncfusion.Blazor.Grids | {{site.blazorversion}} | DataGrid and UI components |
| Syncfusion.Blazor.Themes | {{site.blazorversion}} | Styling for DataGrid components |
| Microsoft.EntityFrameworkCore | 9.0.0 or later | Core framework for database operations |
| Microsoft.EntityFrameworkCore.Tools | 9.0.0 or later | Tools for managing database migrations |
| Pomelo.EntityFrameworkCore.MySql | 9.0.0 or later | MySQL provider for Entity Framework Core |

## Setting Up the MySQL Environment for Entity Framework Core

### Step 1: Create the database and Table in MySQL server

First, the **MySQL database** structure must be created to store transaction records.

**Instructions:**
1. Open MySQL Workbench or any MySQL client.
2. Create a new database named `transactiondb`.
3. Define a `transactions` table with the specified schema.
4. Insert sample data for testing.

Run the following SQL script:

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
    Status VARCHAR(50) NULL
);

-- Insert Sample Data (Optional)
INSERT INTO transactions (TransactionId, CustomerId, OrderId, InvoiceNumber, Description, Amount, CurrencyCode, TransactionType, PaymentGateway, CreatedAt, CompletedAt, Status) VALUES
('TXN260113001', 1001, 50001, 'INV-2026-001', 'Samsung S25 Ultra', 153399.00, 'INR', 'SALE', 'Razorpay', '2026-01-13 10:15:30', '2026-01-13 10:16:55', 'SUCCESS'),
('TXN260113002', 1002, 50002, 'INV-2026-002', 'MacBook Pro M4', 224199.00, 'INR', 'SALE', 'Stripe', '2026-01-13 11:20:10', '2026-01-13 11:21:40', 'SUCCESS');
```

After executing this script, the transaction records are stored in the `transactions` table within the `transactiondb` database. The database is now ready for integration with the Blazor application.

---

### Step 2: Install Required NuGet Packages

Before installing the necessary NuGet packages, a new Blazor Web Application must be created using the default template.
This template automatically generates essential starter files—such as **Program.cs, appsettings.json, the wwwroot folder, and the Components folder**.

For this guide, a Blazor application named **Grid_MySQL** has been created. Once the project is set up, the next step involves installing the required NuGet packages. NuGet packages are software libraries that add functionality to the application. These packages enable Entity Framework Core and MySQL integration.

**Method 1: Using Package Manager Console**

1. Open Visual Studio 2022.
2. Navigate to **Tools → NuGet Package Manager → Package Manager Console**.
3. Run the following commands:

```powershell
Install-Package Microsoft.EntityFrameworkCore -Version 9.0.0
Install-Package Microsoft.EntityFrameworkCore.Tools -Version 9.0.0
Install-Package Pomelo.EntityFrameworkCore.MySql -Version 9.0.0
Install-Package Syncfusion.Blazor.Grids -Version {{site.blazorversion}}
Install-Package Syncfusion.Blazor.Themes -Version {{site.blazorversion}}
```

**Method 2: Using NuGet Package Manager UI**

1. Open **Visual Studio 2022 → Tools → NuGet Package Manager → Manage NuGet Packages for Solution**.
2. Search for and install each package individually:
   - **Microsoft.EntityFrameworkCore** (version 9.0.0 or later)
   - **Microsoft.EntityFrameworkCore.Tools** (version 9.0.0 or later)
   - **Pomelo.EntityFrameworkCore.MySql** (version 9.0.0 or later)
   - **Syncfusion.Blazor.Grids** (version {{site.blazorversion}})
   - **Syncfusion.Blazor.Themes** (version {{site.blazorversion}})

All required packages are now installed.

### Step 3: Create the Data Model

A data model is a C# class that represents the structure of a database table. This model defines the properties that correspond to the columns in the `transactions` table.

**Instructions:**

1. Create a new folder named `Data` in the Blazor application project.
2. Inside the `Data` folder, create a new file named **TransactionModel.cs**.
3. Define the **TransactionModel** class with the following code:

```csharp

using System.ComponentModel.DataAnnotations;

namespace Transaction.Data
{
    /// <summary>
    /// Represents a transaction record mapped to the 'transactions' table in the database.
    /// This model defines the structure of transaction-related data used throughout the application.
    /// </summary>
    public class TransactionModel
    {
        /// <summary>
        /// Gets or sets the unique identifier for the transaction record.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique transaction reference generated by the system or payment gateway.
        /// </summary>
        public string? TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the customer associated with the transaction.
        /// </summary>
        public int? CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the identifier of the order linked to this transaction.
        /// </summary>
        public int? OrderId { get; set; }

        /// <summary>
        /// Gets or sets the invoice number associated with the transaction.
        /// </summary>
        public string? InvoiceNumber { get; set; }

        /// <summary>
        /// Gets or sets a description or additional details about the transaction.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the monetary amount of the transaction.
        /// </summary>
        public decimal Amount { get; set; }

        /// <summary>
        /// Gets or sets the currency code (e.g., USD, INR, EUR) for the transaction.
        /// </summary>
        public string? CurrencyCode { get; set; }

        /// <summary>
        /// Gets or sets the type of transaction (e.g., Payment, Refund).
        /// </summary>
        public string? TransactionType { get; set; }

        /// <summary>
        /// Gets or sets the payment gateway used to process the transaction.
        /// </summary>
        public string? PaymentGateway { get; set; }

        /// <summary>
        /// Gets or sets the timestamp indicating when the transaction was created.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the timestamp indicating when the transaction was completed.
        /// </summary>
        public DateTime? CompletedAt { get; set; }

        /// <summary>
        /// Gets or sets the current status of the transaction (e.g., Pending, Completed, Failed).
        /// </summary>
        public string? Status { get; set; }
    }
}

```

**Explanation:**
- The `[Key]` attribute marks the `Id` property as the primary key (a unique identifier for each record).
- Each property represents a column in the database table.
- The `?` symbol indicates that a property is nullable (can be empty).

The data model has been successfully created.

### Step 4: Configure the DbContext

A `DbContext` is a special class that manages the connection between the application and the MySQL database. It handles all database operations such as saving, updating, deleting, and retrieving data.

**Instructions:**

1. Inside the `Data` folder, create a new file named **TransactionDbContext.cs**.
2. Define the `TransactionDbContext` class with the following code:

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

**Explanation:**
- The `DbContext` class inherits from Entity Framework's `DbContext` base class.
- The `Transactions` property represents the `transactions` table in the database.
- The `OnModelCreating` method configures how the database columns should behave (maximum length, required/optional, default values, etc.).

The **TransactionDbContext** class is required because:

- It **connects** the application to the database.
- It **manages** all database operations.
- It **maps** C# models to actual database tables.
- It **configures** how data should look inside the database.

Without this class, Entity Framework Core will not know where to save data or how to create the transactions table. The DbContext has been successfully configured.

### Step 5: Configure the Connection String

A connection string contains the information needed to connect the application to the MySQL database, including the server address, port, database name, and credentials.

**Instructions:**

1. Open the `appsettings.json` file in the project root.
2. Add or update the `ConnectionStrings` section with the MySQL connection details:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=transactiondb;Uid=root;Pwd=Amrish_arjun11;SslMode=None;ConvertZeroDateTime=false;"
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
| Database | The database name (in this case, `transactiondb`) |
| Uid | The MySQL username (default is `root`) |
| Pwd | The MySQL password |
| SslMode | SSL encryption mode (set to `None` for local development) |
| ConvertZeroDateTime | Converts zero datetime values to NULL |

The database connection string has been configured successfully.

### Step 6: Create the Repository Class

A repository class is an intermediary layer that handles all database operations. This class uses Entity Framework Core to communicate with the database.

**Instructions:**

1. Inside the `Data` folder, create a new file named **TransactionRepository.cs**.
2. Define the **TransactionRepository** class with the following code:

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
        /// Retrieves all transactions from the database ordered by ID in descending order
        /// </summary>
        /// <returns>List of all transactions</returns>
        public async Task<List<TransactionModel>> GetTransactionsAsync()
        {
            return await _context.Transactions
                .OrderByDescending(t => t.Id)
                .ToListAsync();
        }

        /// <summary>
        /// Adds a new transaction to the database
        /// </summary>
        public async Task AddTransactionAsync(TransactionModel transaction)
        {
            // Handle logic to add a new transaction to the database
        }

        /// <summary>
        /// Updates an existing transaction in the database
        /// </summary>
        public async Task UpdateTransactionAsync(TransactionModel transaction)
        {
            // Handle logic to update an existing transaction to the database
        }

        /// <summary>
        /// Deletes a transaction from the database
        /// </summary>
        public async Task RemoveTransactionAsync(int? transactionId)
        {
            // Handle logic to delete an existing transaction to the database
        }
    }
}
```

The repository class has been created.

### Step 7: Register Services in Program.cs

The `Program.cs` file is where application services are registered and configured. This file must be updated to enable Entity Framework Core and the repository pattern.

**Instructions:**

1. Open the `Program.cs` file at the project root.
2. Add the following code after the line `var builder = WebApplication.CreateBuilder(args);`:

```csharp
using Microsoft.EntityFrameworkCore;
using Transaction.Data;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Get connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register DbContext with MySQL database
builder.Services.AddDbContext<TransactionDbContext>(options =>
{
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    );
});

// Register the repository for dependency injection
builder.Services.AddScoped<TransactionRepository>();

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

## Integrating Syncfusion Blazor DataGrid

### Step 1: Install and Configure Blazor DataGrid Components

Syncfusion is a library that provides pre-built UI components like DataGrid, which is used to display data in a table format.

**Instructions:**

1. The Syncfusion.Blazor.Grids package was installed in **Step 2** of the previous heading.
2. Import the required namespaces in the `Components/_Imports.razor` file:

```csharp
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
```

3. Add the Syncfusion stylesheet and scripts in the `Components/App.razor` file. Find the `<head>` section and add:

```html
<!-- Syncfusion Blazor Stylesheet -->
<link href="_content/Syncfusion.Blazor/styles/tailwind3.css" rel="stylesheet" />

<!-- Syncfusion Blazor Scripts -->
<script src="_content/Syncfusion.Blazor/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
```

Syncfusion components are now configured and ready to use. For additional guidance, refer to the Grid component’s [getting‑started](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app) documentation.

### Step 2: Update the Blazor DataGrid in the Home Component

The Home component will display the transaction data in a Syncfusion Blazor DataGrid with search, filter, sort, and pagination capabilities.

**Instructions:**

1. open the file named `Home.razor` in the `Components/Pages` folder.
2. Add the following code to create a basic DataGrid:

```razor
@page "/"
@rendermode InteractiveServer
@inject TransactionRepository TransactionService

<PageTitle>Transaction Management System</PageTitle>

<div class="container-fluid p-4">
    <h1 class="mb-4">Transaction Management System</h1>
    <p class="mb-3">Manage and view all transaction records from the database.</p>
    
    <!-- Syncfusion Blazor DataGrid Component -->
    <SfGrid TValue="TransactionModel" AllowPaging="true" AllowSorting="true" AllowFiltering="true">
        <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
        
        <GridColumns>
           //columns configuration
        </GridColumns>
        
        <GridPageSettings PageSize="10"></GridPageSettings>
    </SfGrid>
</div>

@code {
    // CustomAdaptor class will be added in the next step
}
```

**Component Explanation:**

- **`@rendermode InteractiveServer`**: Enables interactive server-side rendering for the component.
- **`@inject TransactionRepository`**: Injects the repository to access database methods.
- **`<SfGrid>`**: The DataGrid component that displays data in rows and columns.
- **`<GridColumns>`**: Defines individual columns in the DataGrid.
- **`<GridPageSettings>`**: Configures pagination with 10 records per page.

The Home component has been updated successfully with DataGrid.

---

### Step 3: Implement the CustomAdaptor

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can bind data from a **MySQL Server** database using [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) and set the [Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Adaptors.html) property to [CustomAdaptor](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/custom-adaptor) for scenarios that require full control over data operations.

The `CustomAdaptor` is a bridge between the DataGrid and the database. It handles all data operations including reading, searching, filtering, sorting, paging, and CRUD operations. Each operation in the CustomAdaptor's `ReadAsync` method handles specific grid functionality. The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid sends operation details to the API through a [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html) object. These details can be applied to the data source using methods from the [DataOperations](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html) class.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Add the following `CustomAdaptor` class code inside the `@code` block:

```csharp
@code {

    private static TransactionRepository? _transactionService;

    /// <summary>
    /// CustomAdaptor class bridges DataGrid interactions with database operations.
    /// This adaptor handles all data retrieval and manipulation for the DataGrid.
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        public TransactionRepository? TransactionService
        {
            get => _transactionService;
            set => _transactionService = value;
        }

        /// <summary>
        /// ReadAsync retrieves records from the database and applies data operations.
        /// This method executes when the grid initializes and when filtering, searching, sorting, or paging occurs.
        /// </summary>
        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
        {
            try
            {
                // Fetch all transactions from the database
                IEnumerable<TransactionModel> dataSource = await _transactionService!.GetTransactionsAsync();

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
                int totalRecordsCount = dataSource.Cast<TransactionModel>().Count();

                // Apply paging skip operation
                if (dataManagerRequest.Skip != 0)
                {
                    dataSource = DataOperations.PerformSkip(dataSource, dataManagerRequest.Skip);
                }

                // Apply paging take operation to retrieve only the requested page size
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

```

The `CustomAdaptor` class has been successfully implemented with all data operations.

**Common methods in data operations**

* [ReadAsync(DataManagerRequest)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_ReadAsync_Syncfusion_Blazor_DataManagerRequest_System_String_) - Retrieve and process records (search, filter, sort, page, group)

* [PerformSearching](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSearching__1_System_Linq_IQueryable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_SearchFilter__) - Applies search criteria to the collection.
* [PerformFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformFiltering__1_System_Linq_IQueryable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_WhereFilter__System_String_) - Filters data based on conditions.
* [PerformSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSorting__1_System_Linq_IQueryable___0__System_Collections_Generic_List_Syncfusion_Blazor_Data_Sort__) - Sorts data by one or more fields.
* [PerformSkip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformSkip__1_System_Linq_IQueryable___0__System_Int32_) - Skips a defined number of records for paging.
* [PerformTake](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html#Syncfusion_Blazor_DataOperations_PerformTake__1_System_Linq_IQueryable___0__System_Int32_) - Retrieves a specified number of records for paging.
* [PerformAggregation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.DataUtil.html#Syncfusion_Blazor_Data_DataUtil_PerformAggregation_System_Collections_IEnumerable_System_Collections_Generic_List_Syncfusion_Blazor_Data_Aggregate__) – Calculates aggregate values such as Sum, Average, Min, and Max.

---

### Step 4: Add Toolbar with CRUD and search options

The toolbar provides buttons for adding, editing, deleting records, and searching the data.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Update the `<SfGrid>` component to include the [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Toolbar) property with CRUD and search options:

```razor
<SfGrid TValue="TransactionModel" 
        AllowPaging="true" 
        AllowSorting="true" 
        AllowFiltering="true" 
        Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    
    <!-- Grid columns configuration -->
</SfGrid>
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
| `Add` | Opens a form to add a new transaction record. |
| `Edit` | Enables editing of the selected record. |
| `Delete` | Deletes the selected record from the database. |
| `Update` | Saves changes made to the selected record. |
| `Cancel` | Cancels the current edit or add operation. |
| `Search` | Displays a search box to find records. |

The toolbar has been successfully added.

---

### Step 5: Implement Paging Feature

Paging divides large datasets into smaller pages to improve performance and usability.

**Instructions:**

1. The paging feature is already partially enabled in the `<SfGrid>` component with [AllowPaging="true"](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowPaging).
2. The page size is configured with [<GridPageSettings>](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html).
3. No additional code changes are required from the previous steps.

```razor
<SfGrid TValue="TransactionModel" 
        AllowPaging="true">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridPageSettings PageSize="10"></GridPageSettings>
    
    <!-- Grid columns configuration -->
</SfGrid>
```
4. Update the `ReadAsync` method in the `CustomAdaptor` class to handle paging:

```csharp
@code {
   
    
/// <summary>
/// CustomAdaptor class to handle grid data operations with MySQL using Entity Framework
/// </summary>
public class CustomAdaptor : DataAdaptor
{
    public static TransactionRepository? _transactionService { get; set; }
    public TransactionRepository? TransactionService 
    { 
        get => _transactionService;
        set => _transactionService = value;
    }

    public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
    {
        IEnumerable < TransactionModel > dataSource = await _transactionService!.GetTransactionsAsync();        

        int totalRecordsCount = dataSource.Cast<TransactionModel>().Count();
        DataResult dataObject = new DataResult();
        
        // Handling Paging
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

}
```

Fetches transaction data by calling the **GetTransactionsAsync** method, which is implemented in the **TransactionRepository.cs** file.

```csharp
/// <summary>
/// Retrieves all transactions from the database ordered by ID descending
/// </summary>
/// <returns>List of all transactions</returns>
public async Task<List<TransactionModel>> GetTransactionsAsync()
{
    try
    {
        return await _context.Transactions
            .OrderByDescending(t => t.Id)
            .ToListAsync();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error retrieving transactions: {ex.Message}");
        throw;
    }
}
```

**How Paging Works:**

- The DataGrid displays 10 records per page (as set in `GridPageSettings`).
- Navigation buttons allow the user to move between pages.
- When a page is requested, the `ReadAsync` method receives skip and take values.
- The `DataOperations.PerformSkip()` and `DataOperations.PerformTake()` methods handle pagination.
- Only the requested page of records is transmitted from the server.

Paging feature is now active with 10 records per page.

---

### Step 6: Implement Searching feature

Searching allows the user to find records by entering keywords in the search box.

**Instructions:**

1. The search functionality is already enabled in the CustomAdaptor's `ReadAsync` method.
2. Ensure the toolbar includes the "Search" item.
3. No additional code changes are required.

```razor
<SfGrid TValue="TransactionModel"        
        AllowPaging="true
        Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridPageSettings PageSize="10"></GridPageSettings>
    <!-- Grid columns configuration -->
</SfGrid>
```
4. Update the `ReadAsync` method in the `CustomAdaptor` class to handle searching:

```csharp
@code {
    private List<string> ToolbarItems = new List<string> { "Search"};
    
/// <summary>
/// CustomAdaptor class to handle grid data operations with MySQL using Entity Framework
/// </summary>
public class CustomAdaptor : DataAdaptor
{
    public static TransactionRepository? _transactionService { get; set; }
    public TransactionRepository? TransactionService 
    { 
        get => _transactionService;
        set => _transactionService = value;
    }

    public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
    {
        IEnumerable < TransactionModel > dataSource = await _transactionService!.GetTransactionsAsync();

        // Handling Search
        if (dataManagerRequest.Search != null && dataManagerRequest.Search.Count > 0)
        {
            dataSource = DataOperations.PerformSearching(dataSource, dataManagerRequest.Search);
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

}
```

**How Searching Works:**

- When the user enters text in the search box and presses Enter, the DataGrid sends a search request to the CustomAdaptor.
- The `ReadAsync` method receives the search criteria in `dataManagerRequest.Search`.
- The `DataOperations.PerformSearching()` method filters the data based on the search term.
- Results are returned and displayed in the DataGrid.

Searching feature is now active.

---

### Step 7: Implement Filtering feature

Filtering allows the user to restrict data based on column values using a menu interface.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Add the [AllowFiltering]((https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowFiltering)) property and [GridFilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridFilterSettings.html) to the `<SfGrid>` component:

```razor
<SfGrid TValue="TransactionModel" 
        AllowPaging="true"         
        AllowFiltering="true"
        Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    
    <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Menu"></GridFilterSettings>
    
    <!-- Grid columns configuration -->
</SfGrid>
```

3. Update the `ReadAsync` method in the `CustomAdaptor` class to handle filtering:

```csharp
/// <summary>
/// CustomAdaptor class to handle grid data operations with MySQL using Entity Framework
/// </summary>
public class CustomAdaptor : DataAdaptor
{
    public static TransactionRepository? _transactionService { get; set; }
    public TransactionRepository? TransactionService 
    { 
        get => _transactionService;
        set => _transactionService = value;
    }

    public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
    {
        IEnumerable < TransactionModel > dataSource = await _transactionService!.GetTransactionsAsync();

        // Handling Search
        if (dataManagerRequest.Search != null && dataManagerRequest.Search.Count > 0)
        {
            dataSource = DataOperations.PerformSearching(dataSource, dataManagerRequest.Search);
        }

        // Handling Filtering
        if (dataManagerRequest.Where != null && dataManagerRequest.Where.Count > 0)
        {
            dataSource = DataOperations.PerformFiltering(dataSource, dataManagerRequest.Where, dataManagerRequest.Where[0].Operator);
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

}
```

**How Filtering Works:**

- Click on the dropdown arrow in any column header to open the filter menu.
- Select filtering criteria (equals, contains, greater than, less than, etc.).
- Click the "Filter" button to apply the filter.
- The `ReadAsync` method receives the filter criteria in `dataManagerRequest.Where`.
- Results are filtered accordingly and displayed in the DataGrid.

Filtering feature is now active.

---

### Step 8: Implement Sorting feature

Sorting enables the user to arrange records in ascending or descending order based on column values.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Add the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) property to the `<SfGrid>` component:

```razor
<SfGrid TValue="TransactionModel" 
        AllowPaging="true" 
        AllowSorting="true" 
        AllowFiltering="true" 
        Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
 
     <GridPageSettings PageSize="10"></GridPageSettings>
     <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Menu"></GridFilterSettings>
    
    <!-- Grid columns configuration -->
</SfGrid>
```

3. Update the `ReadAsync` method in the `CustomAdaptor` class to handle sorting:

```csharp
/// <summary>
/// CustomAdaptor class to handle grid data operations with MySQL using Entity Framework
/// </summary>
public class CustomAdaptor : DataAdaptor
{
    public static TransactionRepository? _transactionService { get; set; }
    public TransactionRepository? TransactionService 
    { 
        get => _transactionService;
        set => _transactionService = value;
    }

    public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
    {
        IEnumerable < TransactionModel > dataSource = await _transactionService!.GetTransactionsAsync();

        // Handling Search
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

}
```

**How Sorting Works:**

- Click on the column header to sort in ascending order.
- Click again to sort in descending order.
- The `ReadAsync` method receives the sort criteria in `dataManagerRequest.Sorted`.
- Records are sorted accordingly and displayed in the DataGrid.

Sorting feature is now active.

---

### Step 9: Implement Grouping feature

Grouping organizes records into hierarchical groups based on column values.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Add the [AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowGrouping) property to the `<SfGrid>` component:

```razor
<SfGrid TValue="TransactionModel" 
        AllowPaging="true" 
        AllowSorting="true" 
        AllowFiltering="true" 
        AllowGrouping="true"
        Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
     <GridPageSettings PageSize="10"></GridPageSettings>
     <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Menu"></GridFilterSettings>
    <!-- Grid columns  -->
</SfGrid>
```
3. Update the `ReadAsync` method in the `CustomAdaptor` class to handle grouping:


```csharp
/// <summary>
/// CustomAdaptor class to handle grid data operations with MySQL using Entity Framework
/// </summary>
public class CustomAdaptor : DataAdaptor
{
    public static TransactionRepository? _transactionService { get; set; }
    public TransactionRepository? TransactionService 
    { 
        get => _transactionService;
        set => _transactionService = value;
    }

    public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
    {
        IEnumerable < TransactionModel > dataSource = await _transactionService!.GetTransactionsAsync();

        // Handling Search
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

        int totalRecordsCount = dataSource.Cast<TransactionModel>().Count();
        DataResult dataObject = new DataResult();
        // Handling Group operation in CustomAdaptor.
        if (dataManagerRequest.Group != null)
        {
            IEnumerable ResultData = dataSource.ToList();
            // Grouping
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

}
```


**How Grouping Works:**

- Columns can be grouped by dragging the column header into the group drop area.
- Each group can be expanded or collapsed by clicking on the group header.
- The `ReadAsync` method receives the grouping instructions through `dataManagerRequest.Group`.
- The grouping operation is processed using **DataUtil.Group**, which organizes the records into hierarchical groups based on the selected column.
- Grouping is performed after search, filter, and sort operations, ensuring the grouped data reflects all applied conditions.
- The processed grouped result is then returned to the **Grid** and displayed in a structured, hierarchical format.

Grouping feature is now active.

---

### Step 10: Perform CRUD operations

CustomAdaptor methods enable users to create, read, update, and delete records directly from the DataGrid. Each operation calls corresponding data layer methods in **TransactionRepository.cs** to execute MySQL commands.

Add the Grid **EditSettings** and **Toolbar** configuration to enable create, read, update, and delete (CRUD) operations.

```razor
<SfGrid TValue="TransactionModel" 
        AllowPaging="true" 
        AllowSorting="true" 
        AllowFiltering="true" 
        AllowGrouping="true"
        Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
     <GridPageSettings PageSize="10"></GridPageSettings>
     <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Menu"></GridFilterSettings>
     <GridEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true" Mode="EditMode.Normal"></GridEditSettings>
    <!-- Grid columns  -->
</SfGrid>
```
Add the toolbar items list in the `@code` block:

```csharp
@code {
    private List<string> ToolbarItems = new List<string> { "Add", "Edit", "Delete", "Update", "Cancel", "Search"};

    // CustomAdaptor class code...
}
```
**Insert**

Record insertion allows new transactions to be added directly through the DataGrid component. The adaptor processes the insertion request, performs any required business‑logic validation, and saves the newly created record to the MySQL Server database.

In **Home.razor**, implement the `InsertAsync` method to handle record deletion within the `CustomAdaptor` class:

```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> InsertAsync(DataManager dataManager, object value, string key)
    {
        if (value is TransactionModel transaction)
        {
            // This method will be invoked when inserting new records into the Blazor DataGrid component.
            await _transactionService!.AddTransactionAsync(transaction);
        }
        return value;
    }
}
```
In **Data/TransactionRepository.cs**, implement the insert method:

```csharp
public async Task AddTransactionAsync(TransactionModel value)
{
    // Validate required fields
    if (transaction == null)
        throw new ArgumentNullException(nameof(transaction), "Transaction cannot be null");

    // Set default values if not provided
    if (transaction.CreatedAt == null)
        transaction.CreatedAt = DateTime.Now;

    if (string.IsNullOrWhiteSpace(transaction.CurrencyCode))
        transaction.CurrencyCode = "INR";

    // IMPORTANT: Generate a temporary TransactionId BEFORE insert to satisfy NOT NULL constraint
    // This uses a temporary high sequence number that will be updated after getting the real ID
    string temporaryTransactionId = GeneratePublicTransactionId(transaction.CreatedAt, 99999);
    transaction.TransactionId = temporaryTransactionId;

    // Add the transaction to the context
    _context.Transactions.Add(transaction);

    // Save changes to get the generated ID
    await _context.SaveChangesAsync();

    // Generate the final TransactionId using the actual inserted ID and CreatedAt date
    string finalTransactionId = GeneratePublicTransactionId(transaction.CreatedAt, transaction.Id);

    // Update the transaction with the final TransactionId
    transaction.TransactionId = finalTransactionId;

    // Mark as modified and save changes
    _context.Transactions.Update(transaction);
    await _context.SaveChangesAsync();
}
```

**What happens behind the scenes:**

1. The form data is collected and validated in the CustomAdaptor's `InsertAsync()` method.
2. The `TransactionRepository.AddTransactionAsync()` method is called.
3. The new record is added to the `_context.Transactions` collection.
4. `SaveChangesAsync()` persists the record to the MySQL database.
5. The DataGrid automatically refreshes to display the new record.

Now the new transaction is persisted to the database and reflected in the grid.

**Update**

Record modification allows transaction details to be updated directly within the DataGrid. The adaptor processes the edited row, validates the updated values, and applies the changes to the **MySQL Server database** while ensuring data integrity is preserved.

In **Home.razor**, implement the `UpdateAsync` method to handle record deletion within the `CustomAdaptor` class:


```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> UpdateAsync(DataManager dataManager, object value, string keyField, string key)
    {
        if (value is TransactionModel transaction)
        {
            // This method will be invoked when updating existing records in the Blazor DataGrid component.
            await _transactionService!.UpdateTransactionAsync(transaction);
        }
        return value;
    }
}
```
In **Data/TransactionRepository.cs**, implement the update method:

```csharp
public async Task UpdateTransactionAsync(TransactionModel value)
{
    // Validate that the transaction object is not null
    if (transaction == null)
        throw new ArgumentNullException(nameof(transaction), "Transaction cannot be null");

    // Check if transaction exists in the database by its ID
    var existingTransaction = await _context.Transactions.FindAsync(transaction.Id);
    if (existingTransaction == null)
        throw new KeyNotFoundException($"Transaction with ID {transaction.Id} not found in the database.");

    existingTransaction.TransactionId = transaction.TransactionId;
    existingTransaction.CustomerId = transaction.CustomerId;
    existingTransaction.OrderId = transaction.OrderId;
    existingTransaction.InvoiceNumber = transaction.InvoiceNumber;
    existingTransaction.Description = transaction.Description;
    existingTransaction.Amount = transaction.Amount;
    existingTransaction.CurrencyCode = transaction  .CurrencyCode;
    existingTransaction.TransactionType = transaction.TransactionType;
    existingTransaction.PaymentGateway = transaction.PaymentGateway;
    existingTransaction.CompletedAt = transaction.CompletedAt;
    existingTransaction.Status = transaction.Status;
    // Note: CreatedAt is not updated as it should remain the original creation time

    // Mark the entity as modified
    _context.Transactions.Update(existingTransaction);

    // Save changes (existingTransaction is already tracked, so no need to call Update)
    await _context.SaveChangesAsync();
}
```

**What happens behind the scenes:**

1. The modified data is collected from the form.
2. The CustomAdaptor's `UpdateAsync()` method is called.
3. The `TransactionRepository.UpdateTransactionAsync()` method is called.
4. The existing record is retrieved from the database by ID.
5. All properties are updated with the new values (except ID and CreatedAt).
6. `SaveChangesAsync()` persists the changes to the MySQL database.
7. The DataGrid refreshes to display the updated record.

Now modifications are synchronized to the database and reflected in the grid UI.

**Delete**

Record deletion allows transactions to be removed directly from the DataGrid. The adaptor captures the delete request, executes the corresponding **MySQL DELETE** operation, and updates both the database and the grid to reflect the removal.

In **Home.razor**, implement the `RemoveAsync` method to handle record deletion within the `CustomAdaptor` class:

```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> RemoveAsync(DataManager dataManager, object value, string keyField, string key)
    {
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
}
```
In **Data/TransactionRepository.cs**, implement the delete method:

```csharp
public async Task RemoveTransactionAsync(int? key)
{
    // Validate input
    if (key == null || key <= 0)
        throw new ArgumentException("Transaction ID cannot be null or invalid", nameof(key));

    // Find the transaction
    var transaction = await _context.Transactions.FindAsync(key);
    if (transaction == null)
        throw new KeyNotFoundException($"Transaction with ID {key} not found");

    // Remove and save
    _context.Transactions.Remove(transaction);
    await _context.SaveChangesAsync();
}
```
**What happens behind the scenes:**

1. The user selects a record and clicks "Delete".
2. A confirmation dialog appears (built into the DataGrid).
3. If confirmed, the CustomAdaptor's `RemoveAsync()` method is called.
4. The `TransactionRepository.RemoveTransactionAsync()` method is called.
5. The record is located in the database by its ID.
6. The record is removed from the `_context.Transactions` collection.
7. `SaveChangesAsync()` executes the DELETE statement in MySQL.
8. The DataGrid refreshes to remove the deleted record from the UI.

Now transactions are removed from the database and the grid UI reflects the changes immediately.

**Batch update**

Batch operations combine multiple insert, update, and delete actions into a single request, minimizing network overhead and ensuring transactional consistency by applying all changes atomically to the MySQL Server database.

In **Home.razor**, implement the `BatchUpdateAsync` method to handle multiple record updates in a single request within the `CustomAdaptor` class:

```csharp
public class CustomAdaptor : DataAdaptor
{
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
}
```
> This method is triggered when the DataGrid is operating in [Batch](https://blazor.syncfusion.com/documentation/datagrid/batch-editing) Edit mode.

**What happens behind the scenes:**

- The DataGrid collects all added, edited, and deleted records in Batch Edit mode.
- The combined batch request is passed to the CustomAdaptor’s `BatchUpdateAsync()` method.
- Each modified record is processed using `TransactionRepository.UpdateTransactionAsync()`.
- Each newly added record is saved using `TransactionRepository.AddTransactionAsync()`.
- Each deleted record is removed using `TransactionRepository.RemoveTransactionAsync()`.
- All repository operations persist changes to the MySQL Server database.
- The DataGrid refreshes to display the updated, added, and removed records in a single response.

Now the adaptor supports bulk modifications with atomic database synchronization. All CRUD operations are now fully implemented, enabling comprehensive data management capabilities within the Blazor DataGrid.

**Reference links**
- [InsertAsync(DataManager, object)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_InsertAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_) - Create new records in MySQL Server
- [UpdateAsync(DataManager, object, string, string)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_UpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) - Edit existing records in MySQL Server
- [RemoveAsync(DataManager, object, string, string)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_RemoveAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) - Delete records from MySQL Server
- [BatchUpdateAsync(DataManager, object, object, object, string, string, int?)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_BatchUpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_Object_System_Object_System_String_System_String_System_Nullable_System_Int32__) - Handle bulk operations

---

### Step 11: Complete code
Here is the complete and final `Home.razor` component with all features integrated:

```razor

@using System.Collections
@using Transaction.Data
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@inject TransactionRepository TransactionService

<SfGrid TValue="TransactionModel" AllowSorting="true" AllowFiltering="true" AllowGrouping="true" AllowPaging="true"
    Height="500px" Width="100%" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" })">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.CheckBox"></GridFilterSettings>
    <GridEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridPageSettings PageSize="10"></GridPageSettings>
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
> * Set [IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsPrimaryKey) to **true** for a column that contains unique values.
> * If the database includes an **auto-generated column**, set [IsIdentity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsIdentity) for that column to disable editing during **add** or **update** operations.


```csharp

@code {
    private CustomAdaptor? _customAdaptor;

    protected override void OnInitialized()
    {
        // Initialize the CustomAdaptor with the injected TransactionRepository
        _customAdaptor = new CustomAdaptor { TransactionService = TransactionService };
    }


    /// <summary>
    /// CustomAdaptor class to handle grid data operations with MySQL using Entity Framework
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        public static TransactionRepository? _transactionService { get; set; }
        public TransactionRepository? TransactionService 
        { 
            get => _transactionService;
            set => _transactionService = value;
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
        {
            IEnumerable < TransactionModel > dataSource = await _transactionService!.GetTransactionsAsync();

            // Handling Search
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

            // Handling Aggregation in CustomAdaptor.
            IDictionary<string, object>? aggregates = null;
            if (dataManagerRequest.Aggregates != null) // Aggregation
            {
                aggregates = DataUtil.PerformAggregation(dataSource, dataManagerRequest.Aggregates);
            }

            int totalRecordsCount = dataSource.Cast<TransactionModel>().Count();
            DataResult dataObject = new DataResult();
            // Handling Group operation in CustomAdaptor.
            if (dataManagerRequest.Group != null)
            {
                IEnumerable ResultData = dataSource.ToList();
                // Grouping
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

        public override async Task<object> InsertAsync(DataManager dataManager, object value, string? key)
        {
            await _transactionService!.AddTransactionAsync(value as TransactionModel);
            return value;
        }

        public override async Task<object> UpdateAsync(DataManager dataManager, object value, string? keyField, string key)
        {
            await _transactionService!.UpdateTransactionAsync(value as TransactionModel);
            return value;
        }

        public override async Task<object> RemoveAsync(DataManager dataManager, object value, string? keyField, string key)
        {
            await _transactionService!.RemoveTransactionAsync(value as int?);
            return value;
        }

        public override async Task<object> BatchUpdateAsync(DataManager dataManager, object changedRecords, object addedRecords, object deletedRecords, string? keyField, string key, int? dropIndex)
        {
            if (changedRecords != null)
            {
                foreach (var record in (IEnumerable<TransactionModel>)changedRecords)
                {
                    await _transactionService!.UpdateTransactionAsync(record as TransactionModel);
                }
            }
            if (addedRecords != null)
            {
                foreach (var record in (IEnumerable<TransactionModel>)addedRecords)
                {
                    await _transactionService!.AddTransactionAsync(record as TransactionModel);
                }
            }
            if (deletedRecords != null)
            {
                foreach (var record in (IEnumerable<TransactionModel>)deletedRecords)
                {
                    await _transactionService!.RemoveTransactionAsync((record as TransactionModel).Id);
                }
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
2. Navigate to `https://localhost:5001` (or the port shown in the terminal).
3. The transaction management application is now running and ready to use.

### Available Features

- **View Data**: All transactions from the MySQL database are displayed in the DataGrid.
- **Search**: Use the search box to find transactions by any field.
- **Filter**: Click on column headers to apply filters.
- **Sort**: Click on column headers to sort data in ascending or descending order.
- **Pagination**: Navigate through records using page numbers.
- **Add**: Click the "Add" button to create a new transaction.
- **Edit**: Click the "Edit" button to modify existing transactions.
- **Delete**: Click the "Delete" button to remove transactions.

---

## Complete Sample Repository

A complete, working sample implementation is available in the [GitHub repository](https://github.com/SyncfusionExamples/connecting-databases-to-blazor-datagrid-component/tree/master/Binding%20MySQL%20database%20using%20CustomAdaptor).

---

## Summary

This guide demonstrates how to:
1. Create a MySQL database with transaction records. [🔗](#step-1-create-the-database-and-table-in-mysql-server)
2. Install necessary NuGet packages for Entity Framework Core and Syncfusion. [🔗](#step-2-install-required-nuget-packages)
3. Create data models and DbContext for database communication. [🔗](#step-3-create-the-data-model)
4. Configure connection strings and register services. [🔗](#step-5-configure-the-connection-string)
5. Implement the repository pattern for data access. [🔗](#step-6-create-the-repository-class)
6. Create a Blazor component with a DataGrid that supports searching, filtering, sorting, paging, and CRUD operations. [🔗](#step-1-install-and-configure-syncfusion-blazor-grid-components)
7. Handle bulk operations and batch updates. [🔗](#step-10-perform-crud-operations)

The application now provides a complete solution for managing transaction data with a modern, user-friendly interface.
