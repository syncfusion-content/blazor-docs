---
layout: post
title: Blazor Data Grid connected to SQLite via Entity Framework | Syncfusion
description: Bind SQLite data to Blazor Data Grid using Entity Framework Core with complete CRUD, filtering, sorting, paging, and advanced data operations.
platform: Blazor
control: DataGrid
documentation: ug
---

# Connecting SQLite to Blazor Data Grid Using Entity Framework

The [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) supports binding data from a SQLite database using Entity Framework Core (EF Core). This approach provides a lightweight, serverless database solution ideal for mobile applications, desktop applications, and small-to-medium scale web applications.

**What is Entity Framework Core?**

Entity Framework Core (EF Core) is a software tool that simplifies database operations in .NET applications. It serves as a bridge between C# code and databases like SQLite.

**Key Benefits of Entity Framework Core**

- **Automatic SQL Generation**: Entity Framework Core generates optimized SQL queries automatically, eliminating the need to write raw SQL code.
- **Type Safety**: Work with strongly-typed objects instead of raw SQL strings, reducing errors.
- **Built-in Security**: Automatic parameterization prevents SQL injection attacks.
- **Version Control for Databases**: Manage database schema changes version-by-version through migrations.
- **Familiar Syntax**: Use LINQ (Language Integrated Query) syntax, which is more intuitive than raw SQL strings.

**What is SQLite?**

**SQLite** is a C-language library that implements a small, fast, self-contained, high-reliability, full-featured, SQL database engine. Unlike other database management systems, SQLite is not a client-server database engine. Rather, it is embedded into the end program.

## Prerequisites

Ensure the following software and packages are installed before proceeding:

| Software/Package | Version | Purpose |
|-----------------|---------|---------|
| Visual Studio 2022 | 17.0 or later | Development IDE with Blazor workload |
| .NET SDK | net9.0 or compatible | Runtime and build tools |
| SQLite | 3.0 or later | Embedded Database engine |
| Syncfusion.Blazor | {{site.blazorversion}} | DataGrid and UI components |
| Microsoft.EntityFrameworkCore | 9.0.0 or later | Core framework for database operations |
| Microsoft.EntityFrameworkCore.Tools | 9.0.0 or later | Tools for managing database migrations |
| Microsoft.EntityFrameworkCore.Sqlite | 9.0.0 or later | SQLite provider for Entity Framework Core |

## Setting Up the SQLite Environment for Entity Framework Core

### Step 1: Create the database and Table in SQLite

First, the **SQLite database** structure must be created to store asset records. Unlike server-based databases, a SQLite database is a single file on disk.

**Instructions:**
1. You can use a tool like **DB Browser for SQLite** or the `sqlite3` command line tool.
2. Create a new database file named `asset.db`.
3. Define a `assetinfo` table with the specified schema.
4. Insert sample data for testing.

Run the following SQL script:

```sql
-- Create Database asset.db
-- Create the IT Assets table (matches Asset entity)
CREATE TABLE IF NOT EXISTS assetinfo (
    Id              INTEGER PRIMARY KEY AUTOINCREMENT,
    AssetID         TEXT NOT NULL UNIQUE,
    AssetName       TEXT NOT NULL,
    AssetType       TEXT NOT NULL,
    Model           TEXT,
    SerialNumber    TEXT NOT NULL,
    InvoiceID       TEXT,
    AssignedTo      TEXT,
    Department      TEXT,
    PurchaseDate    DATE,
    PurchaseCost    REAL,
    WarrantyExpiry  DATE,
    Condition       TEXT CHECK(Condition IN ('New', 'Good', 'Fair', 'Poor')) DEFAULT 'New',
    LastMaintenance DATE,
    Status          TEXT CHECK(Status IN ('Active', 'In Repair', 'Retired', 'Available')) DEFAULT 'Available'
);

-- Insert sample realistic data (20 records)
INSERT INTO assetinfo (Id, AssetID, AssetName, AssetType, Model, SerialNumber, InvoiceID, AssignedTo, Department, PurchaseDate, PurchaseCost, WarrantyExpiry, Condition, LastMaintenance, Status) VALUES
('1', 'AST-001', 'Dell Latitude Laptop', 'Laptop', 'Latitude 5520', 'SN-DEL-2024-001', 'INV-2023-0015', 'John Smith', 'IT', '2023-01-15', 1250.00, '2026-01-15', 'Good', '2024-06-10', 'Active'),
('2', 'AST-002', 'HP ProBook Laptop', 'Laptop', 'ProBook 450 G8', 'SN-HP-2024-002', 'INV-2023-0042', 'Sarah Johnson', 'Finance', '2023-03-20', 1100.00, '2026-03-20', 'Good', '2024-05-15', 'Active'),
```

After executing this script, the asset records are stored in the `assetinfo` table within the `asset.db` database. The database is now ready for integration with the Blazor application.

---

### Step 2: Install Required NuGet Packages

Before installing the necessary NuGet packages, a new Blazor Web Application must be created using the default template.
This template automatically generates essential starter files—such as **Program.cs, appsettings.json, the wwwroot folder, and the Components folder**.

For this guide, a Blazor application named **Grid_SQLite** has been created. Once the project is set up, the next step involves installing the required NuGet packages. NuGet packages are software libraries that add functionality to the application. These packages enable Entity Framework Core and SQLite integration.

**Method 1: Using Package Manager Console**

1. Open Visual Studio 2022.
2. Navigate to **Tools → NuGet Package Manager → Package Manager Console**.
3. Run the following commands:

```powershell
Install-Package Microsoft.EntityFrameworkCore -Version 9.0.0
Install-Package Microsoft.EntityFrameworkCore.Tools -Version 9.0.0
Install-Package Microsoft.EntityFrameworkCore.Sqlite -Version 9.0.0
Install-Package Syncfusion.Blazor.Grids -Version {{site.blazorversion}}
Install-Package Syncfusion.Blazor.Themes -Version {{site.blazorversion}}
```

**Method 2: Using NuGet Package Manager UI**

1. Open **Visual Studio 2022 → Tools → NuGet Package Manager → Manage NuGet Packages for Solution**.
2. Search for and install each package individually:
   - **Microsoft.EntityFrameworkCore** (version 9.0.0 or later)
   - **Microsoft.EntityFrameworkCore.Tools** (version 9.0.0 or later)
   - **Microsoft.EntityFrameworkCore.Sqlite** (version 9.0.0 or later)
   - **Syncfusion.Blazor.Grids** (version {{site.blazorversion}})
   - **Syncfusion.Blazor.Themes** (version {{site.blazorversion}})

All required packages are now installed.

### Step 3: Create the Data Model

A data model is a C# class that represents the structure of a database table. This model defines the properties that correspond to the columns in the `assetinfo` table.

**Instructions:**

1. Create a new folder named `Data` in the Blazor application project.
2. Inside the `Data` folder, create a new file named **Asset.cs**.
3. Define the **Asset** class with the following code:

```csharp
using System.ComponentModel.DataAnnotations;

namespace Grid_SQLite.Data
{
 /// <summary>
    /// Represents an asset record mapped to the 'assetinfo' table in the database.
    /// This model defines the structure of asset-related data used throughout the application.
    /// </summary>
    public class Asset
    {
        /// <summary>
        /// Gets or sets the unique identifier for the Asset record.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique asset reference generated by the system.
        /// Format: AST-XXXXX (e.g., AST-001, AST-002)
        /// </summary>
        public string AssetID { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Name/description of the asset
        /// </summary>
        public string AssetName { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Type/category of the asset (Laptop, Desktop, Monitor, Printer, etc.)
        /// </summary>
        public string AssetType { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Model/specification of the asset
        /// </summary>
        public string? Model { get; set; }

        /// <summary>
        /// Gets or sets the Serial number/unique identifier from manufacturer
        /// </summary>
        public string SerialNumber { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the Invoice/purchase order number
        /// </summary>
        public string? InvoiceID { get; set; }

        /// <summary>
        /// Gets or sets the Name/person the asset is assigned to
        /// </summary>
        public string? AssignedTo { get; set; }

        /// <summary>
        /// Gets or sets the Department that owns/uses the asset
        /// Values: IT, Finance, Marketing, HR, Design, Sales, Operations, Executive, Training
        /// </summary>
        public string? Department { get; set; }

        /// <summary>
        /// Gets or sets the Date when the asset was purchased
        /// </summary>
        public DateTime? PurchaseDate { get; set; }

        /// <summary>
        /// Gets or sets the Purchase cost in currency units
        /// Stored with 2 decimal places
        /// </summary>
        public decimal? PurchaseCost { get; set; }

        /// <summary>
        /// Gets or sets the Date when the warranty expires
        /// </summary>
        public DateTime? WarrantyExpiry { get; set; }

        /// <summary>
        /// Gets or sets the Current condition of the asset
        /// Values: New, Good, Fair, Poor
        /// </summary>
        public string? Condition { get; set; } = "New";

        /// <summary>
        /// Gets or sets the Date of the last maintenance performed
        /// </summary>
        public DateTime? LastMaintenance { get; set; }

        /// <summary>
        /// Gets or sets the Current status of the asset
        /// Values: Active, In Repair, Retired, Available
        /// </summary>
        public string Status { get; set; } = "Available";
    }
}
```

**Explanation:**
- The `[Key]` attribute marks the `Id` property as the primary key (a unique identifier for each record).
- Each property represents a column in the database table.
- The `?` symbol indicates that a property is nullable (can be empty).

The data model has been successfully created.

### Step 4: Configure the DbContext

A `DbContext` is a special class that manages the connection between the application and the SQLite database. It handles all database operations such as saving, updating, deleting, and retrieving data.

**Instructions:**

1. Inside the `Data` folder, create a new file named **AssetDbContext.cs**.
2. Define the `AssetDbContext` class with the following code:

```csharp
using Microsoft.EntityFrameworkCore;

namespace Grid_SQLite.Data
{
    /// <summary>
    /// DbContext for Asset entity
    /// Manages database connections and entity configurations for SQLite
    /// </summary>
    public class AssetDbContext : DbContext
    {
        public AssetDbContext(DbContextOptions<AssetDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// DbSet for Asset entities
        /// </summary>
        public DbSet<Asset> Assets => Set<Asset>();

        /// <summary>
        /// Configures the entity mappings and constraints
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Asset entity
            modelBuilder.Entity<Asset>(entity =>
            {
                // Primary Key
                entity.HasKey(e => e.Id);

                // Auto-increment for Primary Key
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                // Column configurations
                entity.Property(e => e.AssetID)
                    .HasMaxLength(20)
                    .IsRequired(true);

                entity.Property(e => e.AssetName)
                    .HasMaxLength(255)
                    .IsRequired(true);

                entity.Property(e => e.AssetType)
                    .HasMaxLength(100)
                    .IsRequired(true);

                entity.Property(e => e.Model)
                    .HasMaxLength(150)
                    .IsRequired(false);

                entity.Property(e => e.SerialNumber)
                    .HasMaxLength(100)
                    .IsRequired(true);

                entity.Property(e => e.InvoiceID)
                    .HasMaxLength(100)
                    .IsRequired(false);

                entity.Property(e => e.AssignedTo)
                    .HasMaxLength(150)
                    .IsRequired(false);

                entity.Property(e => e.Department)
                    .HasMaxLength(50)
                    .IsRequired(false);

                entity.Property(e => e.PurchaseDate)
                    .HasColumnType("DATE")
                    .IsRequired(false);

                entity.Property(e => e.PurchaseCost)
                    .HasPrecision(12, 2)
                    .IsRequired(false);

                entity.Property(e => e.WarrantyExpiry)
                    .HasColumnType("DATE")
                    .IsRequired(false);

                entity.Property(e => e.Condition)
                    .HasMaxLength(50)
                    .IsRequired(false)
                    .HasDefaultValue("New");

                entity.Property(e => e.LastMaintenance)
                    .HasColumnType("DATE")
                    .IsRequired(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsRequired(true)
                    .HasDefaultValue("Available");

                // Table name
                entity.ToTable("assetinfo");
            });
        }
    }
}
```

**Explanation:**
- The `DbContext` class inherits from Entity Framework's `DbContext` base class.
- The `Assets` property represents the `assetinfo` table in the database.
- The `OnModelCreating` method configures how the database columns should behave (maximum length, required/optional, default values, etc.).

The **AssetDbContext** class is required because:

- It **connects** the application to the database.
- It **manages** all database operations.
- It **maps** C# models to actual database tables.
- It **configures** how data should look inside the database.

Without this class, Entity Framework Core will not know where to save data or how to create the assets table. The DbContext has been successfully configured.

### Step 5: Configure the Connection String

A connection string contains the information needed to connect the application to the SQLite database, which is typically the path to the database file.

**Instructions:**

1. Open the `appsettings.json` file in the project root.
2. Add or update the `ConnectionStrings` section with the SQLite connection details:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=C:\\Users\\AmrishDharmaraj\\OneDrive - Syncfusion\\Desktop\\db\\asset.db"
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

**Note:** Ensure the path to `asset.db` is correct for your environment.

The database connection string has been configured successfully.

### Step 6: Create the Repository Class

A repository class is an intermediary layer that handles all database operations. This class uses Entity Framework Core to communicate with the database.

**Instructions:**

1. Inside the `Data` folder, create a new file named **AssetRepository.cs**.
2. Define the **AssetRepository** class with the following code:

```csharp
using Microsoft.EntityFrameworkCore;

namespace Grid_SQLite.Data
{
    /// <summary>
    /// Repository pattern implementation for Asset entity using Entity Framework Core
    /// Handles all CRUD operations and business logic for assets
    /// </summary>
    public class AssetRepository
    {
        private readonly AssetDbContext _context;

        public AssetRepository(AssetDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all assets from the database ordered by AssetID descending
        /// </summary>
        /// <returns>List of all assets</returns>
        public async Task<List<Asset>> GetAssetsAsync()
        {
            try
            {
                return await _context.Assets
                    .OrderByDescending(a => a.Id)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving assets: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Adds a new asset to the database
        /// </summary>
        /// <param name="asset">The asset model to add</param>
        public async Task AddAssetAsync(Asset asset)
        {
             // Handle logic to add a new asset to the database
        }

        /// <summary>
        /// UPDATE Operation: Modifies an existing asset in the database.
        /// </summary>
        /// <param name="asset">The asset object with updated values.</param>
        public async Task UpdateAssetAsync(Asset asset)
        {
            // Handle logic to update an existing asset to the database
        }

        /// <summary>
        /// Deletes an asset from the database
        /// </summary>
        /// <param name="key">The asset ID to delete</param>
        public async Task RemoveAssetAsync(int? key)
        {
             // Handle logic to delete an existing asset to the database
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
using Grid_SQLite.Components;
using Grid_SQLite.Data;
using Syncfusion.Blazor;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSyncfusionBlazor();

// Get connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register DbContext with SQLite provider
builder.Services.AddDbContext<AssetDbContext>(options =>
{
    options.UseSqlite(connectionString);

    // Enable detailed error messages in development
    if (builder.Environment.IsDevelopment())
    {
        options.EnableSensitiveDataLogging();
    }
});

// Register Repository for dependency injection
builder.Services.AddScoped<AssetRepository>();

var app = builder.Build();


if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.MapStaticAssets();
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

1. The Syncfusion.Blazor package was installed in **Step 2** of the previous heading.
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

The Home component will display the asset data in a Syncfusion Blazor DataGrid with search, filter, sort, and pagination capabilities.

**Instructions:**

1. Open the file named `Home.razor` in the `Components/Pages` folder.
2. Add the following code to create a basic DataGrid:

```html
@page "/"
@rendermode InteractiveServer
@inject AssetRepository AssetService

<PageTitle>IT Asset Management</PageTitle>

<div class="container-fluid p-4">
    <h1 class="mb-4">IT Asset Management</h1>
    
    <!-- Syncfusion Blazor DataGrid Component -->
    <SfGrid TValue="Asset" AllowPaging="true" AllowSorting="true" AllowFiltering="true" AllowGrouping="true">
        <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
        
        <GridColumns>
           //columns configuration
        </GridColumns>
        
        <GridPageSettings PageSize="20"></GridPageSettings>
    </SfGrid>
</div>

@code {
    // CustomAdaptor class will be added in the next step
}
```

**Component Explanation:**

- **`@rendermode InteractiveServer`**: Enables interactive server-side rendering for the component.
- **`@inject AssetRepository`**: Injects the repository to access database methods.
- **`<SfGrid>`**: The DataGrid component that displays data in rows and columns.
- **`<GridColumns>`**: Defines individual columns in the DataGrid.
- **`<GridPageSettings>`**: Configures pagination with 10 records per page.

The Home component has been updated successfully with DataGrid.

---

### Step 3: Implement the CustomAdaptor

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can bind data from a **SQLite** database using [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) and set the [Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Adaptors.html) property to `CustomAdaptor` for scenarios that require full control over data operations.

The `CustomAdaptor` is a bridge between the DataGrid and the database. It handles all data operations including reading, searching, filtering, sorting, paging, and CRUD operations. Each operation in the CustomAdaptor's `ReadAsync` method handles specific grid functionality. The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid sends operation details to the API through a [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html) object. These details can be applied to the data source using methods from the [DataOperations](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html) class.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Add the following `CustomAdaptor` class code inside the `@code` block:

```csharp
@code {

    private static AssetRepository? _assetService;

    /// <summary>
    /// CustomAdaptor class bridges DataGrid interactions with database operations.
    /// This adaptor handles all data retrieval and manipulation for the DataGrid.
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        public AssetRepository? AssetService
        {
            get => _assetService;
            set => _assetService = value;
        }

        /// <summary>
        /// ReadAsync retrieves records from the database and applies data operations.
        /// This method executes when the grid initializes and when filtering, searching, sorting, or paging occurs.
        /// </summary>
        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
        {
            try
            {
                // Fetch all assets from the database
                IEnumerable<Asset> dataSource = await _assetService!.GetAssetsAsync();

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
                int totalRecordsCount = dataSource.Cast<Asset>().Count();

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

```html
<SfGrid TValue="Asset" 
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
| `Add` | Opens a form to add a new asset record. |
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

```html
<SfGrid TValue="Asset" 
        AllowPaging="true">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridPageSettings PageSize="20"></GridPageSettings>
    
    <!-- Grid columns configuration -->
</SfGrid>
```

4. Update the `ReadAsync` method in the `CustomAdaptor` class to handle paging:

```csharp
/// <summary>
/// CustomAdaptor class to handle grid data operations with SQLite using Entity Framework
/// </summary>
public class CustomAdaptor : DataAdaptor
{
    public static AssetRepository? _assetService { get; set; }
    public AssetRepository? AssetService
    {
        get => _assetService;
        set => _assetService = value;
    }

    public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
    {
        IEnumerable<Asset> dataSource = await _assetService!.GetAssetsAsync();

        int totalRecordsCount = dataSource.Cast<Asset>().Count();
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

Fetches asset data by calling the **GetAssetsAsync** method, which is implemented in the **AssetRepository.cs** file.

```csharp
/// <summary>
/// Retrieves all assets from the database ordered by ID descending
/// </summary>
/// <returns>List of all assets</returns>
public async Task<List<Asset>> GetAssetsAsync()
{
    try
    {
        return await _context.Assets
            .OrderByDescending(a => a.Id)
            .ToListAsync();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error retrieving assets: {ex.Message}");
        throw;
    }
}
```

**How Paging Works:**

- The DataGrid displays 20 records per page (as set in `GridPageSettings`).
- Navigation buttons allow the user to move between pages.
- When a page is requested, the `ReadAsync` method receives skip and take values.
- The `DataOperations.PerformSkip()` and `DataOperations.PerformTake()` methods handle pagination.
- Only the requested page of records is transmitted from the server.

Paging feature is now active with 20 records per page.

---

### Step 6: Implement Searching feature

Searching allows the user to find records by entering keywords in the search box.

**Instructions:**

1. The search functionality is already enabled in the CustomAdaptor's `ReadAsync` method.
2. Ensure the toolbar includes the "Search" item.
3. No additional code changes are required.

```html
<SfGrid TValue="Asset"        
        AllowPaging="true"
        Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridPageSettings PageSize="20"></GridPageSettings>
    <!-- Grid columns configuration -->
</SfGrid>
```

4. Update the `ReadAsync` method in the `CustomAdaptor` class to handle searching:

```csharp
@code {
    private List<string> ToolbarItems = new List<string> { "Search"};
    
    /// <summary>
    /// CustomAdaptor class to handle grid data operations with SQLite using Entity Framework
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        public static AssetRepository? _assetService { get; set; }
        public AssetRepository? AssetService
        {
            get => _assetService;
            set => _assetService = value;
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
        {
            IEnumerable<Asset> dataSource = await _assetService!.GetAssetsAsync();

            // Handling Search
            if (dataManagerRequest.Search != null && dataManagerRequest.Search.Count > 0)
            {
                dataSource = DataOperations.PerformSearching(dataSource, dataManagerRequest.Search);
            }

            int totalRecordsCount = dataSource.Cast<Asset>().Count();

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
2. Add the [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowFiltering) property and [GridFilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridFilterSettings.html) to the `<SfGrid>` component:

```html
<SfGrid TValue="Asset" 
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
/// CustomAdaptor class to handle grid data operations with SQLite using Entity Framework
/// </summary>
public class CustomAdaptor : DataAdaptor
{
    public static AssetRepository? _assetService { get; set; }
    public AssetRepository? AssetService
    {
        get => _assetService;
        set => _assetService = value;
    }

    public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
    {
        IEnumerable<Asset> dataSource = await _assetService!.GetAssetsAsync();

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

        int totalRecordsCount = dataSource.Cast<Asset>().Count();

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

```html
<SfGrid TValue="Asset" 
        AllowPaging="true" 
        AllowSorting="true" 
        AllowFiltering="true" 
        Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
 
     <GridPageSettings PageSize="20"></GridPageSettings>
     <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Menu"></GridFilterSettings>
    
    <!-- Grid columns configuration -->
</SfGrid>
```

3. Update the `ReadAsync` method in the `CustomAdaptor` class to handle sorting:

```csharp
/// <summary>
/// CustomAdaptor class to handle grid data operations with SQLite using Entity Framework
/// </summary>
public class CustomAdaptor : DataAdaptor
{
    public static AssetRepository? _assetService { get; set; }
    public AssetRepository? AssetService
    {
        get => _assetService;
        set => _assetService = value;
    }

    public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
    {
        IEnumerable<Asset> dataSource = await _assetService!.GetAssetsAsync();

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

        int totalRecordsCount = dataSource.Cast<Asset>().Count();

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

```html
<SfGrid TValue="Asset" 
        AllowPaging="true" 
        AllowSorting="true" 
        AllowFiltering="true" 
        AllowGrouping="true"
        Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
     <GridPageSettings PageSize="20"></GridPageSettings>
     <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Menu"></GridFilterSettings>
    <!-- Grid columns  -->
</SfGrid>
```

3. Update the `ReadAsync` method in the `CustomAdaptor` class to handle grouping:


```csharp
/// <summary>
/// CustomAdaptor class to handle grid data operations with SQLite using Entity Framework
/// </summary>
public class CustomAdaptor : DataAdaptor
{
    public static AssetRepository? _assetService { get; set; }
    public AssetRepository? AssetService
    {
        get => _assetService;
        set => _assetService = value;
    }

    public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
    {
        IEnumerable<Asset> dataSource = await _assetService!.GetAssetsAsync();

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

        int totalRecordsCount = dataSource.Cast<Asset>().Count();

        // Handling Grouping
        DataResult dataObject = new DataResult();

        if (dataManagerRequest.Group != null)
        {
            IEnumerable ResultData = dataSource.ToList();
            foreach (var group in dataManagerRequest.Group)
            {
                ResultData = DataUtil.Group<Asset>(ResultData, group, dataManagerRequest.Aggregates, 0, dataManagerRequest.GroupByFormatter);
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

CustomAdaptor methods enable users to create, read, update, and delete records directly from the DataGrid. Each operation calls corresponding data layer methods in **AssetRepository.cs** to execute SQLite commands.

Add the Grid **EditSettings** and **Toolbar** configuration to enable create, read, update, and delete (CRUD) operations.

```html
<SfGrid TValue="Asset" 
        AllowPaging="true" 
        AllowSorting="true" 
        AllowFiltering="true" 
        AllowGrouping="true"
        Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
     <GridPageSettings PageSize="20"></GridPageSettings>
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

Record insertion allows new assets to be added directly through the DataGrid component. The adaptor processes the insertion request, performs any required business‑logic validation, and saves the newly created record to the SQLite database.

In **Home.razor**, implement the `InsertAsync` method within the `CustomAdaptor` class:

```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> InsertAsync(DataManager dataManager, object value, string? key)
    {
        await _assetService!.AddAssetAsync(value as Asset);
        return value;
    }
}
```
In **Data/AssetRepository.cs**, implement the insert method:

```csharp
public async Task AddAssetAsync(Asset asset)
{
    if (asset == null)
    throw new ArgumentNullException(nameof(asset), "Asset cannot be null");

    if (string.IsNullOrWhiteSpace(asset.AssetID))
    {
        asset.AssetID = GenerateTemporaryAssetId();
    }

    if (string.IsNullOrWhiteSpace(asset.SerialNumber))
    {
        asset.SerialNumber = GenerateSerialNumber(asset.AssetType, asset.PurchaseDate, asset.AssetID);
    }

    if (string.IsNullOrWhiteSpace(asset.Condition))
        asset.Condition = "New";

    if (string.IsNullOrWhiteSpace(asset.Status))
        asset.Status = "Available";

    _context.Assets.Add(asset);
    await _context.SaveChangesAsync();

    string finalAssetId = GenerateAssetId(asset.Id);
    asset.AssetID = finalAssetId;

    asset.SerialNumber = GenerateSerialNumber(asset.AssetType, asset.PurchaseDate, finalAssetId);

    _context.Assets.Update(asset);
    await _context.SaveChangesAsync();
}
```

**What happens behind the scenes:**

1. The form data is collected and validated in the CustomAdaptor's `InsertAsync()` method.
2. The `AssetRepository.AddAssetAsync()` method is called.
3. The new record is added to the `_context.Assets` collection.
4. `SaveChangesAsync()` persists the record to the SQLite database.
5. The DataGrid automatically refreshes to display the new record.

Now the new asset is persisted to the database and reflected in the grid.

**Update**

Record modification allows asset details to be updated directly within the DataGrid. The adaptor processes the edited row, validates the updated values, and applies the changes to the **SQLite database**.

In **Home.razor**, implement the `UpdateAsync` method within the `CustomAdaptor` class:

```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> UpdateAsync(DataManager dataManager, object value, string? keyField, string key)
    {
        await _assetService!.UpdateAssetAsync(value as Asset);
        return value;
    }
}
```
In **Data/AssetRepository.cs**, implement the update method:

```csharp
public async Task UpdateAssetAsync(Asset asset)
{
    if (asset == null)
        throw new ArgumentNullException(nameof(asset), "Asset cannot be null");

    var existingAsset = await _context.Assets.FindAsync(asset.Id);
    if (existingAsset == null)
        throw new KeyNotFoundException($"Asset with ID {asset.Id} not found");

    existingAsset.AssetName = asset.AssetName;
    existingAsset.AssetType = asset.AssetType;
    existingAsset.Model = asset.Model;
    existingAsset.SerialNumber = asset.SerialNumber;
    existingAsset.InvoiceID = asset.InvoiceID;
    existingAsset.AssignedTo = asset.AssignedTo;
    existingAsset.Department = asset.Department;
    existingAsset.PurchaseCost = asset.PurchaseCost;
    existingAsset.WarrantyExpiry = asset.WarrantyExpiry;
    existingAsset.Condition = asset.Condition;
    existingAsset.LastMaintenance = asset.LastMaintenance;
    existingAsset.Status = asset.Status;

    _context.Assets.Update(existingAsset);

    await _context.SaveChangesAsync();
}
```

**What happens behind the scenes:**

1. The modified data is collected from the form.
2. The CustomAdaptor's `UpdateAsync()` method is called.
3. The `AssetRepository.UpdateAssetAsync()` method is called.
4. The existing record is retrieved from the database by ID.
5. All properties are updated with the new values (except ID and Purchase Date).
6. `SaveChangesAsync()` persists the changes to the SQLite database.
7. The DataGrid refreshes to display the updated record.

Now modifications are synchronized to the database and reflected in the grid UI.


**Delete**

Record deletion allows assets to be removed directly from the DataGrid. The adaptor captures the delete request, executes the corresponding **SQLite DELETE** operation, and updates both the database and the grid to reflect the removal.

In **Home.razor**, implement the `RemoveAsync` method within the `CustomAdaptor` class:

```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> RemoveAsync(DataManager dataManager, object value, string? keyField, string key)
    {
        await _assetService!.RemoveAssetAsync(value as int?);
        return value;
    }
}
```
In **Data/AssetRepository.cs**, implement the delete method:

```csharp
  public async Task RemoveAssetAsync(int? key)
  {
      try
      {
          if (key == null || key <= 0)
              throw new ArgumentException("Asset ID cannot be null or invalid", nameof(key));

          var asset = await _context.Assets.FindAsync(key);
          if (asset == null)
              throw new KeyNotFoundException($"Asset with ID {key} not found");

          _context.Assets.Remove(asset);
          await _context.SaveChangesAsync();
      }
      catch (DbUpdateException ex)
      {
          Console.WriteLine($"Database error while deleting asset: {ex.Message}");
          throw;
      }
      catch (Exception ex)
      {
          Console.WriteLine($"Error deleting asset: {ex.Message}");
          throw;
      }
  }
```

**What happens behind the scenes:**

1. The user selects a record and clicks "Delete".
2. A confirmation dialog appears (built into the DataGrid).
3. If confirmed, the CustomAdaptor's `RemoveAsync()` method is called.
4. The `AssetRepository.RemoveAssetAsync()` method is called.
5. The record is located in the database by its ID.
6. The record is removed from the `_context.Assets` collection.
7. `SaveChangesAsync()` executes the DELETE statement in SQLite.
8. The DataGrid refreshes to remove the deleted record from the UI.

Now Assets are removed from the database and the grid UI reflects the changes immediately.

**Batch Update**

Batch operations combine multiple insert, update, and delete actions into a single request, minimizing network overhead and ensuring assest consistency by applying all changes automically to the SQLite Server

In **Home.razor**, implement the `BatchUpdateAsync` method within the `CustomAdaptor` class:

```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> BatchUpdateAsync(DataManager dataManager, object changedRecords, object addedRecords, object deletedRecords, string? keyField, string key, int? dropIndex)
    {
        if (changedRecords != null)
        {
            foreach (var record in (IEnumerable<Asset>)changedRecords)
            {
                await _assetService!.UpdateAssetAsync(record as Asset);
            }
        }
        if (addedRecords != null)
        {
            foreach (var record in (IEnumerable<Asset>)addedRecords)
            {
                await _assetService!.AddAssetAsync(record as Asset);
            }
        }
        if (deletedRecords != null)
        {
            foreach (var record in (IEnumerable<Asset>)deletedRecords)
            {
                await _assetService!.RemoveAssetAsync((record as Asset)?.Id);
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
- Each modified record is processed using `AssetRepository.UpdateAssetAsync()`.
- Each newly added record is saved using `AssetRepository.AddAssetAsync()`.
- Each deleted record is removed using `AssetRepository.RemoveAssetAsync()`.
- All repository operations persist changes to the SQLite Server database.
- The DataGrid refreshes to display the updated, added, and removed records in a single response.

Now the adaptor supports bulk modifications with atomic database synchronization. All CRUD operations are now fully implemented, enabling comprehensive data management capabilities within the Blazor DataGrid.

**Reference links**
- [InsertAsync(DataManager, object)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_InsertAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_) - Create new records in SQLite Server
- [UpdateAsync(DataManager, object, string, string)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_UpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) - Edit existing records in SQLite Server
- [RemoveAsync(DataManager, object, string, string)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_RemoveAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) - Delete records from SQLite Server
- [BatchUpdateAsync(DataManager, object, object, object, string, string, int?)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_BatchUpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_Object_System_Object_System_String_System_String_System_Nullable_System_Int32__) - Handle bulk operations

---

### Step 11: Complete code
Here is the complete and final `Home.razor` component with all features integrated. This component uses the exact implementation from the Grid_SQLite project:

```html
@page "/"
@rendermode InteractiveServer
@using System.Collections
@using Grid_SQLite.Data
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns
@inject AssetRepository AssetService

<SfGrid TValue="Asset" AllowSorting="true" AllowFiltering="true" AllowGrouping="true" AllowPaging="true"
    Height="500px" Width="100%" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" })">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Menu"></GridFilterSettings>
    <GridEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridPageSettings PageSize="20"></GridPageSettings>
        
    <GridColumns>
        <GridColumn Field=@nameof(Asset.Id) IsPrimaryKey="true" ShowInColumnChooser="false" ShowColumnMenu="false"></GridColumn>
        <GridColumn Field="@nameof(Asset.AssetID)" HeaderText="Asset ID" Width="120" TextAlign="TextAlign.Left" AllowAdding="false" AllowEditing="false">
            <Template>
                @{
                    var data = (Asset)context;
                }
                <a class="status-text status-ticket-id">
                    @data.AssetID
                </a>
            </Template>
        </GridColumn>
            
        <GridColumn Field="@nameof(Asset.AssetName)" HeaderText="Asset Name" Width="180" TextAlign="TextAlign.Left" ValidationRules="@(new ValidationRules { Required = true })"></GridColumn>
            
        <GridColumn Field="@nameof(Asset.AssetType)" HeaderText="Type" Width="130" TextAlign="TextAlign.Left" ValidationRules="@(new ValidationRules { Required = true })" AllowEditing="false"></GridColumn>
            
        <GridColumn Field="@nameof(Asset.Model)" HeaderText="Model" Width="150" ValidationRules="@(new ValidationRules { Required = true })" TextAlign="TextAlign.Left"></GridColumn>
            
        <GridColumn Field="@nameof(Asset.SerialNumber)" HeaderText="Serial Number" Width="160" TextAlign="TextAlign.Left" AllowAdding="false" AllowEditing="false"></GridColumn>
            
        <GridColumn Field="@nameof(Asset.InvoiceID)" HeaderText="Invoice ID" Width="130" TextAlign="TextAlign.Left"></GridColumn>
            
        <GridColumn Field="@nameof(Asset.AssignedTo)" HeaderText="Assigned To" Width="150" TextAlign="TextAlign.Left"></GridColumn>
            
        <GridColumn Field="@nameof(Asset.Department)" HeaderText="Department" Width="130" TextAlign="TextAlign.Left" EditType="EditType.DropDownEdit" EditorSettings="@DepartmentDropDownParams" />
            
        <GridColumn Field="@nameof(Asset.PurchaseDate)" HeaderText="Purchase Date" Width="140" TextAlign="TextAlign.Center" ValidationRules="@(new ValidationRules { Required = true })" Format="yyyy-MM-dd" Type="ColumnType.Date" EditType="EditType.DatePickerEdit" AllowEditing="false"></GridColumn>
            
        <GridColumn Field="@nameof(Asset.PurchaseCost)" HeaderText="Cost" Width="120" TextAlign="TextAlign.Right" Format="C0" EditType="EditType.NumericEdit"></GridColumn>
            
        <GridColumn Field="@nameof(Asset.WarrantyExpiry)" HeaderText="Warranty Expiry" Width="150" TextAlign="TextAlign.Center" Format="yyyy-MM-dd" Type="ColumnType.Date" EditType="EditType.DatePickerEdit"></GridColumn>
            
        <GridColumn Field="@nameof(Asset.Condition)" HeaderText="Condition" Width="120" TextAlign="TextAlign.Center" EditType="EditType.DropDownEdit" EditorSettings="@ConditionDropDownParams">
            <Template>
                @{
                    var asset = context as Asset;
                    var badgeClass = asset?.Condition switch
                    {
                        "New" => "badge bg-success",
                        "Good" => "badge bg-primary",
                        "Fair" => "badge bg-warning text-dark",
                        "Poor" => "badge bg-danger",
                        _ => "badge bg-secondary"
                    };
                }
                <span class="@badgeClass">@asset?.Condition</span>
            </Template>
        </GridColumn>
            
        <GridColumn Field="@nameof(Asset.LastMaintenance)" HeaderText="Last Maintenance" Width="150" TextAlign="TextAlign.Center" Format="yyyy-MM-dd" Type="ColumnType.Date" EditType="EditType.DatePickerEdit"></GridColumn>
            
        <GridColumn Field="@nameof(Asset.Status)" HeaderText="Status" Width="120" TextAlign="TextAlign.Center" EditType="EditType.DropDownEdit" EditorSettings="@StatusDropDownParams">
            <Template>
                @{
                    var asset = context as Asset;
                    var badgeClass = asset?.Status switch
                    {
                        "Active" => "badge bg-success",
                        "In Repair" => "badge bg-warning text-dark",
                        "Retired" => "badge bg-secondary",
                        "Available" => "badge bg-info",
                        _ => "badge bg-secondary"
                    };
                }
                <span class="@badgeClass">@asset?.Status</span>
            </Template>
        </GridColumn>
    </GridColumns>

</SfGrid>
```
> * Set [IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsPrimaryKey) to **true** for a column that contains unique values.
> * If the database includes an **auto-generated column**, set [IsIdentity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsIdentity) for that column to disable editing during **add** or **update** operations.
> * The [EditType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.EditType.html?_gl=1*4kxqtd*_gcl_au*ODcxNTU4MzMyLjE3Njc1ODkwOTk.*_ga*NjA2MTg0NzMuMTc1OTc1MDUyNg..*_ga_41J4HFMX1J*czE3Njk1MzE3NTAkbzY1JGcxJHQxNzY5NTMyOTMwJGo2MCRsMCRoMA..) property can be used to specify the desired editor for each column. [🔗](https://blazor.syncfusion.com/documentation/datagrid/edit-types)
> * The behavior of default editors can be customized using the [EditorSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_EditorSettings) property of the `GridColumn` component. [🔗](https://blazor.syncfusion.com/documentation/datagrid/edit-types#customizing-the-default-editors)
> * [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Type) property of the `GridColumn` component  specifies the data type of a grid column.
> * The [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html?_gl=1*8q6kap*_gcl_au*ODcxNTU4MzMyLjE3Njc1ODkwOTk.*_ga*NjA2MTg0NzMuMTc1OTc1MDUyNg..*_ga_41J4HFMX1J*czE3Njk1MzE3NTAkbzY1JGcxJHQxNzY5NTMzMDg0JGozMCRsMCRoMA..#Syncfusion_Blazor_Grids_GridColumn_Template) property that allows rendering custom elements in a column instead of the default field value. [🔗](https://blazor.syncfusion.com/documentation/datagrid/column-template)

```csharp

@code {
    private CustomAdaptor? _customAdaptor;

    protected override void OnInitialized()
    {
        _customAdaptor = new CustomAdaptor { AssetService = AssetService };
    }

    /// <summary>
    /// CustomAdaptor class to handle grid data operations with SQLite using Entity Framework
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        public static AssetRepository? _assetService { get; set; }
        public AssetRepository? AssetService
        {
            get => _assetService;
            set => _assetService = value;
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
        {
            IEnumerable<Asset> dataSource = await _assetService!.GetAssetsAsync();

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

            // Handling Aggregation
            IDictionary<string, object>? aggregates = null;
            if (dataManagerRequest.Aggregates != null)
            {
                aggregates = DataUtil.PerformAggregation(dataSource, dataManagerRequest.Aggregates);
            }

            int totalRecordsCount = dataSource.Cast<Asset>().Count();

            // Handling Grouping
            DataResult dataObject = new DataResult();

            if (dataManagerRequest.Group != null)
            {
                IEnumerable ResultData = dataSource.ToList();
                foreach (var group in dataManagerRequest.Group)
                {
                    ResultData = DataUtil.Group<Asset>(ResultData, group, dataManagerRequest.Aggregates, 0, dataManagerRequest.GroupByFormatter);
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
            await _assetService!.AddAssetAsync(value as Asset);
            return value;
        }

        public override async Task<object> UpdateAsync(DataManager dataManager, object value, string? keyField, string key)
        {
            await _assetService!.UpdateAssetAsync(value as Asset);
            return value;
        }

        public override async Task<object> RemoveAsync(DataManager dataManager, object value, string? keyField, string key)
        {
            await _assetService!.RemoveAssetAsync(value as int?);
            return value;
        }

        public override async Task<object> BatchUpdateAsync(DataManager dataManager, object changedRecords, object addedRecords, object deletedRecords, string? keyField, string key, int? dropIndex)
        {
            if (changedRecords != null)
            {
                foreach (var record in (IEnumerable<Asset>)changedRecords)
                {
                    await _assetService!.UpdateAssetAsync(record as Asset);
                }
            }
            if (addedRecords != null)
            {
                foreach (var record in (IEnumerable<Asset>)addedRecords)
                {
                    await _assetService!.AddAssetAsync(record as Asset);
                }
            }
            if (deletedRecords != null)
            {
                foreach (var record in (IEnumerable<Asset>)deletedRecords)
                {
                    await _assetService!.RemoveAssetAsync((record as Asset)?.Id);
                }
            }
            return key;
        }
    }

    /// <summary>
    /// Provides a list of Departments options used as a data source for the Department editor in the grid.
    /// </summary>
    public static List<Asset> CustomDepartments = new List<Asset>
    {
        new Asset { Department = "IT" },
        new Asset { Department = "Finance" },
        new Asset { Department = "Marketing" },
        new Asset { Department = "HR" },
        new Asset { Department = "Design" },
        new Asset { Department = "Sales" },
        new Asset { Department = "Operations" },
        new Asset { Department = "Executive" },
        new Asset { Department = "Training" },
        new Asset { Department = "Engineering" },
        new Asset { Department = "Legal" },
        new Asset { Department = "Customer Support" },
    };

    /// <summary>
    /// Provides a list of Conditions options used as a data source for the Conditions editor in the grid.
    /// </summary>
    public static List<Asset> CustomConditions = new List<Asset>
    {
        new Asset { Condition = "New" },
        new Asset { Condition = "Good" },
        new Asset { Condition = "Fair" },
        new Asset { Condition = "Poor" }
    };

    /// <summary>
    /// Provides a list of Status options used as a data source for the Status editor in the grid.
    /// </summary>
    public static List<Asset> CustomStatuses = new List<Asset>
    {
        new Asset { Status = "Active" },
        new Asset { Status = "In Repair" },
        new Asset { Status = "Retired" },
        new Asset { Status = "Available" }
    };


    /// <summary>
    /// Dropdown editor settings configured with Department options for the Department column in grid edit mode.
    /// </summary>
    public IEditorSettings DepartmentDropDownParams = new DropDownEditCellParams
    {
        Params = new DropDownListModel<object, object>() { DataSource = CustomDepartments, Query = new Syncfusion.Blazor.Data.Query() }
    };


    /// <summary>
    /// Dropdown editor settings configured with Condition options for the Condition column in grid edit mode.
    /// </summary>
    public IEditorSettings ConditionDropDownParams = new DropDownEditCellParams
    {
        Params = new DropDownListModel<object, object>() { DataSource = CustomConditions, Query = new Syncfusion.Blazor.Data.Query() }
    };


    /// <summary>
    /// Dropdown editor settings configured with Status options for the Status column in grid edit mode.
    /// </summary>
    public IEditorSettings StatusDropDownParams = new DropDownEditCellParams
    {
        Params = new DropDownListModel<object, object>() { DataSource = CustomStatuses, Query = new Syncfusion.Blazor.Data.Query() }
    };
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
3. The IT Asset Management application is now running and ready to use.

### Available Features

- **View Data**: All assets from the SQLite database are displayed in the DataGrid.
- **Search**: Use the search box to find assets by any field.
- **Filter**: Click on column headers to apply filters.
- **Sort**: Click on column headers to sort data in ascending or descending order.
- **Pagination**: Navigate through records using page numbers.
- **Add**: Click the "Add" button to create a new asset.
- **Edit**: Click the "Edit" button to modify existing assets.
- **Delete**: Click the "Delete" button to remove assets.

---

## Complete Sample Repository

A complete, working sample implementation is available in the [GitHub repository](https://github.com/SyncfusionExamples/connecting-databases-to-blazor-datagrid-component/tree/master/Binding%20SQLite%20using%20CustomAdaptor).

---

## Summary

This guide demonstrates how to:
1. Create a SQLite database with asset records. [🔗](#step-1-create-the-database-and-table-in-sqlite)
2. Install necessary NuGet packages for Entity Framework Core and Syncfusion. [🔗](#step-2-install-required-nuget-packages)
3. Create data models and DbContext for database communication. [🔗](#step-3-create-the-data-model)
4. Configure connection strings and register services. [🔗](#step-5-configure-the-connection-string)
5. Implement the repository pattern for data access. [🔗](#step-6-create-the-repository-class)
6. Create a Blazor component with a DataGrid that supports searching, filtering, sorting, paging, and CRUD operations. [🔗](#step-1-install-and-configure-blazor-datagrid-components)
7. Handle bulk operations and batch updates. [🔗](#step-10-perform-crud-operations)

The application now provides a complete solution for managing asset data with a modern, user-friendly interface.