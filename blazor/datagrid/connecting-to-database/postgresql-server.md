---
layout: post
title: Blazor Data Grid with PostgreSQL via Entity Framework | Syncfusion
description: Bind PostgreSQL data to Blazor Data Grid using Entity Framework Core with complete CRUD, filtering, sorting, paging, and advanced data operations.
platform: Blazor
control: DataGrid
documentation: ug
---

# Connecting PostgreSQL to Blazor Data Grid Using Entity Framework

The [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) supports binding data from a PostgreSQL database using Entity Framework Core (EF Core). This modern approach provides a more maintainable and type-safe alternative to raw SQL queries.

**What is Entity Framework Core?**

Entity Framework Core (EF Core) is a software tool that simplifies database operations in .NET applications. It serves as a bridge between C# code and databases like PostgreSQL.

**Key Benefits of Entity Framework Core**

- **Automatic SQL Generation**: Entity Framework Core generates optimized SQL queries automatically, eliminating the need to write raw SQL code.
- **Type Safety**: Work with strongly-typed objects instead of raw SQL strings, reducing errors.
- **Built-in Security**: Automatic parameterization prevents SQL injection attacks.
- **Version Control for Databases**: Manage database schema changes version-by-version through migrations.
- **Familiar Syntax**: Use LINQ (Language Integrated Query) syntax, which is more intuitive than raw SQL strings.

**What is Npgsql Entity Framework Core Provider?**

The **Npgsql.EntityFrameworkCore.PostgreSQL** package is the official Entity Framework Core provider for PostgreSQL. It acts as a bridge between Entity Framework Core and PostgreSQL, allowing applications to read, write, update, and delete data in a PostgreSQL database.

## Prerequisites

Ensure the following software and packages are installed before proceeding:

| Software/Package | Version | Purpose |
|-----------------|---------|---------|
| Visual Studio 2022 | 17.0 or later | Development IDE with Blazor workload |
| .NET SDK | net10.0 or compatible | Runtime and build tools |
| PostgreSQL Server | 12 or later | Database server |
| pgAdmin 4 | Latest | PostgreSQL GUI management tool |
| Syncfusion.Blazor.Grid | {{site.blazorversion}} | DataGrid and UI components |
| Syncfusion.Blazor.Themes | {{site.blazorversion}} | Styling for DataGrid components |
| Microsoft.EntityFrameworkCore | 10.0.2 or later | Core framework for database operations |
| Npgsql.EntityFrameworkCore.PostgreSQL | 10.0.0 or later | PostgreSQL provider for Entity Framework Core |

## Setting Up the PostgreSQL Environment for Entity Framework Core

### Step 1: Create the database and Table in PostgreSQL

First, the **PostgreSQL database** structure must be created to store purchase order records.

**UI Instructions (Using pgAdmin 4):**

1. **Open pgAdmin 4** and connect to your PostgreSQL server.
2. **Create Database**:
   - Right-click on **Databases** → Select **Create** → **Database**
   - Enter name: `PurchaseOrderDB`
   - Click **Save**
3. **Create Table**:
   - Expand `PurchaseOrderDB` → Right-click on **Schemas** → **public** → **Tables**
   - Click **Create** → **Table**
   - Enter table name: `PurchaseOrder`
   - Define columns as per the script below
4. **Execute SQL Script** (Alternative method):
   - Right-click on `PurchaseOrderDB` → **Query Tool**
   - Copy and paste the SQL script below
   - Execute (F5 or Run button)

**SQL Script for PostgreSQL:**

```sql
-- Create Database
CREATE DATABASE PurchaseOrderDB

-- Connect to the database
\c PurchaseOrderDB;

-- Create PurchaseOrder Table
CREATE TABLE public.PurchaseOrder (
    PurchaseOrderId SERIAL PRIMARY KEY,
    PoNumber VARCHAR(30) NOT NULL UNIQUE,
    VendorID VARCHAR(50) NOT NULL,
    ItemName VARCHAR(200) NOT NULL,
    ItemCategory VARCHAR(100),
    Quantity INTEGER NOT NULL,
    UnitPrice NUMERIC(12,2) NOT NULL,
    TotalAmount NUMERIC(14,2),
    Status VARCHAR(30) NOT NULL DEFAULT 'Pending',
    OrderedBy VARCHAR(100) NOT NULL,
    ApprovedBy VARCHAR(100),
    OrderDate DATE NOT NULL,
    ExpectedDeliveryDate DATE,
    CreatedAt TIMESTAMP NOT NULL DEFAULT NOW(),
    UpdatedAt TIMESTAMP NOT NULL DEFAULT NOW()
);

-- Insert Sample Data (Optional)
INSERT INTO public."PurchaseOrder" ("PoNumber", "VendorID", "ItemName", "ItemCategory", "Quantity", "UnitPrice", "TotalAmount", "Status", "OrderedBy", "ApprovedBy", "OrderDate", "ExpectedDeliveryDate", "CreatedAt", "UpdatedAt")
VALUES
('PO-2025-0001', 'VEN-9001', 'FHD Laptop', 'Electronics', 5, 899.99, 4499.95, 'Pending', 'Alice Johnson', 'Carol Davis', '2025-01-10', '2025-01-20', NOW(), NOW()),
('PO-2025-0002', 'VEN-9002', 'Fibre Cables', 'Networking', 100, 15.50, 1550.00, 'Approved', 'Bob Smith', 'Alice Johnson', '2025-01-09', '2025-01-17', NOW(), NOW());
```

After executing this script, the purchase order records are stored in the `PurchaseOrder` table within the `PurchaseOrderDB` database. The database is now ready for integration with the Blazor application.

---

### Step 2: Install Required NuGet Packages

Before installing the necessary NuGet packages, a new Blazor Web Application must be created using the default template.
This template automatically generates essential starter files—such as **Program.cs, appsettings.json, the wwwroot folder, and the Components folder**.

For this guide, a Blazor application named **Grid_PostgreSQL** has been created. Once the project is set up, the next step involves installing the required NuGet packages. NuGet packages are software libraries that add functionality to the application. These packages enable Entity Framework Core and PostgreSQL integration.

**Method 1: Using Package Manager Console**

1. Open Visual Studio 2022.
2. Navigate to **Tools → NuGet Package Manager → Package Manager Console**.
3. Run the following commands:

```powershell
Install-Package Microsoft.EntityFrameworkCore -Version 10.0.2; 
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL -Version 10.0.0; 
Install-Package Syncfusion.Blazor.Grid -Version {{site.blazorversion}}; 
Install-Package Syncfusion.Blazor.Themes -Version {{site.blazorversion}}
```

**Method 2: Using NuGet Package Manager UI**

1. Open **Visual Studio 2022 → Tools → NuGet Package Manager → Manage NuGet Packages for Solution**.
2. Search for and install each package individually:
   - **Microsoft.EntityFrameworkCore** (version 10.0.2 or later)
   - **Npgsql.EntityFrameworkCore.PostgreSQL** (version 10.0.0 or later)
   - **Syncfusion.Blazor.Grid** (version {{site.blazorversion}})
   - **Syncfusion.Blazor.Themes** (version {{site.blazorversion}})

**Project File Reference**

The installed packages are reflected in the **Grid_PostgreSQL.csproj** file:

```xml
<ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="10.0.2" />
    <PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="10.0.0" />
    <PackageReference Include="Syncfusion.Blazor.Grid" Version="*" />
    <PackageReference Include="Syncfusion.Blazor.Themes" Version="*" />
</ItemGroup>
```

All required packages are now installed.

### Step 3: Create the Data Model

A data model is a C# class that represents the structure of a database table. This model defines the properties that correspond to the columns in the `PurchaseOrder` table.

**Instructions:**

1. Create a new folder named `Data` in the Blazor application project.
2. Inside the `Data` folder, create a new file named **PurchaseOrder.cs**.
3. Define the **PurchaseOrder** class with the following code:

```csharp
using System.ComponentModel.DataAnnotations;

namespace Grid_PostgreSQL.Data
{
    /// <summary>
    /// Represents a purchase order record mapped to the 'PurchaseOrder' table in the database.
    /// This model defines the structure of purchase order-related data used throughout the application.
    /// </summary>
    public class PurchaseOrder
    {
        /// <summary>
        /// Gets or sets the unique identifier for the purchase order record.
        /// This is the primary key and auto-incremented by the database.
        /// </summary>
        [Key]
        public int PurchaseOrderId { get; set; }

        /// <summary>
        /// Gets or sets the public-facing purchase order number (e.g., PO-2025-0001).
        /// This is a unique identifier visible to users and external systems.
        /// </summary>
        public string? PoNumber { get; set; }

        /// <summary>
        /// Gets or sets the vendor identifier (e.g., VEN-9001).
        /// Links the purchase order to a specific vendor.
        /// </summary>
        public string? VendorID { get; set; }

        /// <summary>
        /// Gets or sets the name or description of the item being ordered.
        /// </summary>
        public string? ItemName { get; set; }

        /// <summary>
        /// Gets or sets the category of the item (e.g., Electronics, Office Supplies, Hardware).
        /// </summary>
        public string? ItemCategory { get; set; }

        /// <summary>
        /// Gets or sets the quantity of items being ordered.
        /// Must be a positive integer.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets or sets the unit price of each item (e.g., 899.99).
        /// Stored with precision of 12 digits and 2 decimal places.
        /// </summary>
        public decimal UnitPrice { get; set; }

        /// <summary>
        /// Gets or sets the total amount for the order (Quantity × UnitPrice).
        /// Auto-calculated and stored with precision of 14 digits and 2 decimal places.
        /// </summary>
        public decimal? TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the current status of the purchase order.
        /// Possible values: Pending, Approved, Ordered, Received, Canceled, Completed.
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        /// Gets or sets the name of the person who created the purchase order.
        /// </summary>
        public string? OrderedBy { get; set; }

        /// <summary>
        /// Gets or sets the name of the person who approved the purchase order.
        /// </summary>
        public string? ApprovedBy { get; set; }

        /// <summary>
        /// Gets or sets the date when the purchase order was placed.
        /// </summary>
        public DateTime OrderDate { get; set; }

        /// <summary>
        /// Gets or sets the expected delivery date for the ordered items.
        /// </summary>
        public DateTime? ExpectedDeliveryDate { get; set; }

        /// <summary>
        /// Gets or sets the timestamp indicating when the purchase order record was created.
        /// Auto-set to the current date and time by the database.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the timestamp indicating when the purchase order record was last updated.
        /// Auto-updated to the current date and time whenever a modification occurs.
        /// </summary>
        public DateTime UpdatedAt { get; set; }
    }
}
```

**Explanation:**
- The `[Key]` attribute marks the `PurchaseOrderId` property as the primary key (a unique identifier for each record).
- Each property represents a column in the database table.
- The `?` symbol indicates that a property is nullable (can be empty).
- The model includes comprehensive XML documentation for each property.
- Decimal properties use `decimal` type for accurate monetary calculations.

The data model has been successfully created.

### Step 4: Configure the DbContext

A `DbContext` is a special class that manages the connection between the application and the PostgreSQL database. It handles all database operations such as saving, updating, deleting, and retrieving data.

**Instructions:**

1. Inside the `Data` folder, create a new file named **PurchaseOrderDbContext.cs**.
2. Define the `PurchaseOrderDbContext` class with the following code:

```csharp
using Microsoft.EntityFrameworkCore;

namespace Grid_PostgreSQL.Data
{
    /// <summary>
    /// DbContext for Purchase Order entity
    /// Manages database connections and entity configurations for the Purchase Order Management System
    /// This context bridges the application with PostgreSQL database
    /// </summary>
    public class PurchaseOrderDbContext : DbContext
    {
        /// <summary>
        /// Initializes a new instance of the PurchaseOrderDbContext class.
        /// </summary>
        /// <param name="options">The options to be used by a DbContext</param>
        public PurchaseOrderDbContext(DbContextOptions<PurchaseOrderDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// Gets or sets the DbSet for Purchase Order entities.
        /// Represents the collection of all purchase orders in the database.
        /// </summary>
        public DbSet<PurchaseOrder> PurchaseOrders => Set<PurchaseOrder>();

        /// <summary>
        /// Configures the entity mappings, constraints, and database-specific configurations
        /// This method is called by Entity Framework Core during model creation.
        /// </summary>
        /// <param name="modelBuilder">Provides a simple API for configuring the EF model</param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                // Set table name and schema
                entity.ToTable("purchaseorder", schema: "public");

                entity.HasKey(e => e.PurchaseOrderId)
                    .HasName("pk_purchaseorder_id");

                entity.Property(e => e.PurchaseOrderId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("purchaseorderid")
                    .HasColumnType("integer");

                entity.Property(e => e.PoNumber)
                    .HasColumnName("ponumber")
                    .HasColumnType("character varying(30)")
                    .HasMaxLength(30)
                    .IsRequired(true);

                entity.HasIndex(e => e.PoNumber)
                    .IsUnique()
                    .HasDatabaseName("uq_purchaseorder_ponumber");

                entity.Property(e => e.VendorID)
                    .HasColumnName("vendorid")
                    .HasColumnType("character varying(50)")
                    .HasMaxLength(50)
                    .IsRequired(true);

                entity.Property(e => e.ItemName)
                    .HasColumnName("itemname")
                    .HasColumnType("character varying(200)")
                    .HasMaxLength(200)
                    .IsRequired(true);

                entity.Property(e => e.ItemCategory)
                    .HasColumnName("itemcategory")
                    .HasColumnType("character varying(100)")
                    .HasMaxLength(100)
                    .IsRequired(false);

                entity.Property(e => e.Quantity)
                    .HasColumnName("quantity")
                    .HasColumnType("integer")
                    .IsRequired(true);

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("unitprice")
                    .HasColumnType("numeric(12,2)")
                    .HasPrecision(12, 2)
                    .IsRequired(true);

                entity.Property(e => e.TotalAmount)
                    .HasColumnName("totalamount")
                    .HasColumnType("numeric(14,2)")
                    .HasPrecision(14, 2)
                    .IsRequired(false);

                entity.Property(e => e.Status)
                    .HasColumnName("status")
                    .HasColumnType("character varying(30)")
                    .HasMaxLength(30)
                    .IsRequired(true)
                    .HasDefaultValue("Pending");

                entity.Property(e => e.OrderedBy)
                    .HasColumnName("orderedby")
                    .HasColumnType("character varying(100)")
                    .HasMaxLength(100)
                    .IsRequired(true);

                entity.Property(e => e.ApprovedBy)
                    .HasColumnName("approvedby")
                    .HasColumnType("character varying(100)")
                    .HasMaxLength(100)
                    .IsRequired(false);

                entity.Property(e => e.OrderDate)
                    .HasColumnName("orderdate")
                    .HasColumnType("date")
                    .IsRequired(true);

                entity.Property(e => e.ExpectedDeliveryDate)
                    .HasColumnName("expecteddeliverydate")
                    .HasColumnType("date")
                    .IsRequired(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnName("createdat")
                    .HasColumnType("timestamp without time zone")
                    .IsRequired(true)
                    .HasDefaultValueSql("NOW()");

                entity.Property(e => e.UpdatedAt)
                    .HasColumnName("updatedat")
                    .HasColumnType("timestamp without time zone")
                    .IsRequired(true)
                    .HasDefaultValueSql("NOW()");

                entity.HasIndex(e => e.Status)
                    .HasDatabaseName("ix_purchaseorder_status");

                entity.HasIndex(e => e.VendorID)
                    .HasDatabaseName("ix_purchaseorder_vendorid");

                entity.HasIndex(e => e.OrderDate)
                    .HasDatabaseName("ix_purchaseorder_orderdate");

                entity.HasIndex(e => e.OrderedBy)
                    .HasDatabaseName("ix_purchaseorder_orderedby");

                entity.HasIndex(e => e.CreatedAt)
                    .HasDatabaseName("ix_purchaseorder_createdat");

                entity.HasIndex(e => new { e.Status, e.OrderDate })
                    .HasDatabaseName("ix_purchaseorder_status_orderdate");
            });
        }
    }
}
```

**Explanation:**
- The `DbContext` class inherits from Entity Framework's `DbContext` base class.
- The `PurchaseOrders` property represents the `PurchaseOrder` table in the database.
- The `OnModelCreating` method configures how the database columns should behave (maximum length, required/optional, default values, data types, indexes, etc.).
- PostgreSQL-specific configurations include:
  - `HasColumnType("character varying(30)")` for VARCHAR columns
  - `HasColumnType("timestamp without time zone")` for timestamp columns
  - `HasDefaultValueSql("NOW()")` for default current timestamp values
  - `HasPrecision(12, 2)` for NUMERIC columns with decimal precision
- Database indexes are configured for improved query performance on frequently accessed columns.

The **PurchaseOrderDbContext** class is required because:

- It **connects** the application to the PostgreSQL database.
- It **manages** all database operations.
- It **maps** C# models to actual database tables.
- It **configures** how data should look inside the database.
- It **enables** PostgreSQL-specific features like indexes and default value functions.

Without this class, Entity Framework Core will not know where to save data or how to create the PurchaseOrder table. The DbContext has been successfully configured.

### Step 5: Configure the Connection String

A connection string contains the information needed to connect the application to the PostgreSQL database, including the server address, database name, and authentication credentials.

**Instructions:**

1. Open the `appsettings.json` file in the project root.
2. Update the `ConnectionStrings` section with the PostgreSQL connection details:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=5432;Database=PurchaseOrderDB;User Id=postgres;Password=postgresql@123"
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
| Server | The address of the PostgreSQL server (localhost for local development) |
| Port | The port number on which PostgreSQL is running (default is 5432) |
| Database | The database name (in this case, `PurchaseOrderDB`) |
| User Id | The PostgreSQL username (default is `postgres`) |
| Password | The password for the PostgreSQL user account |


> **Security Note:** For production environments, store sensitive credentials in environment variables or Azure Key Vault instead of storing them in appsettings.json. Example: `Password=${DB_PASSWORD}` and set the environment variable `DB_PASSWORD` on the deployment server.

The database connection string has been configured successfully.

### Step 6: Create the Repository Class

A repository class is an intermediary layer that handles all database operations. This class uses Entity Framework Core to communicate with the PostgreSQL database.

**Instructions:**

1. Inside the `Data` folder, create a new file named **PurchaseOrderRepository.cs**.
2. Define the **PurchaseOrderRepository** class with the following code:

```csharp
using Microsoft.EntityFrameworkCore;

namespace Grid_PostgreSQL.Data
{
    /// <summary>
    /// Repository pattern implementation for PurchaseOrder entity using Entity Framework Core
    /// Handles all CRUD operations and business logic for purchase orders
    /// Communicates with PostgreSQL database through PurchaseOrderDbContext
    /// </summary>
    public class PurchaseOrderRepository
    {
        private readonly PurchaseOrderDbContext _context;

        public PurchaseOrderRepository(PurchaseOrderDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all purchase orders from the database ordered by ID descending
        /// </summary>
        /// <returns>List of all purchase orders</returns>
        public async Task<List<PurchaseOrder>> GetPurchaseOrdersDataAsync()
        {
            try
            {
                return await _context.PurchaseOrders
                    .OrderByDescending(p => p.PurchaseOrderId)
                    .ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving purchase orders: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Generates a unique purchase order number (PoNumber) in the format PO-YYYY-XXXX
        /// where YYYY is the current year and XXXX is a sequential 4-digit number
        /// </summary>
        /// <returns>A unique purchase order number</returns>
        private async Task<string> GeneratePoNumberAsync()
        {
            try
            {
                var currentYear = DateTime.Now.Year;
                var lastPo = await _context.PurchaseOrders
                    .Where(p => p.PoNumber!.StartsWith($"PO-{currentYear}"))
                    .OrderByDescending(p => p.PoNumber)
                    .FirstOrDefaultAsync();

                int nextNumber = 1;
                if (lastPo != null)
                {
                    var lastNumber = int.Parse(lastPo.PoNumber!.Split('-')[2]);
                    nextNumber = lastNumber + 1;
                }

                return $"PO-{currentYear}-{nextNumber:D4}";
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating PO number: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Adds a new purchase order to the database
        /// Auto-generates the PoNumber if not provided
        /// Sets CreatedAt and UpdatedAt timestamps
        /// </summary>
        /// <param name="value">The purchase order model to add</param>
        public async Task AddPurchaseOrderAsync(PurchaseOrder value)
        {
            // Add Logic for adding a new purchase order to the database 
        }

        /// <summary>
        /// Updates an existing purchase order in the database
        /// Validates that the purchase order exists before updating
        /// Updates the UpdatedAt timestamp automatically
        /// </summary>
        /// <param name="value">The purchase order model with updated values</param>
        public async Task UpdatePurchaseOrderAsync(PurchaseOrder value)
        {
            // Add Logic for updating an existing purchase order to the database 
        }

        /// <summary>
        /// Deletes a purchase order from the database
        /// Validates that the purchase order exists before deletion
        /// </summary>
        /// <param name="key">The purchase order ID to delete</param>
        public async Task RemovePurchaseOrderAsync(int? key)
        {
            // Add Logic for removing an existing purchase order to the database 
        }
    }
}
```
The repository class has been created.


### Step 7: Register Services in Program.cs

The `Program.cs` file is where application services are registered and configured. This file must be updated to enable Entity Framework Core with PostgreSQL and the repository pattern.

**Instructions:**

1. Open the `Program.cs` file at the project root.
2. Add the following code after the line `var builder = WebApplication.CreateBuilder(args);`:

```csharp
using Grid_PostgreSQL.Components;
using Grid_PostgreSQL.Data;
using Syncfusion.Blazor;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// ========== SYNCFUSION BLAZOR CONFIGURATION ==========
builder.Services.AddSyncfusionBlazor();

// ========== ENTITY FRAMEWORK CORE CONFIGURATION ==========
// Get connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found in configuration.");
}

// Register DbContext with PostgreSQL provider (Npgsql)
builder.Services.AddDbContext<PurchaseOrderDbContext>(options =>
{
    options.UseNpgsql(connectionString);

    // Enable detailed error messages in development
    if (builder.Environment.IsDevelopment())
    {
        options.EnableSensitiveDataLogging();
        options.EnableDetailedErrors();
    }
});

// Register Repository for dependency injection
builder.Services.AddScoped<PurchaseOrderRepository>();
// =======================================================

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

**Explanation:**

- **`AddSyncfusionBlazor()`**: Registers Syncfusion Blazor components (DataGrid, themes, etc.).
- **`AddDbContext<PurchaseOrderDbContext>`**: Registers the DbContext with PostgreSQL as the database provider using `UseNpgsql()`.
- **Connection String Validation**: Ensures the connection string is configured before attempting to connect.
- **`EnableSensitiveDataLogging()`**: Enabled in development to log detailed information about database operations (useful for debugging).
- **`EnableDetailedErrors()`**: Provides more detailed error messages during development.
- **`AddScoped<PurchaseOrderRepository>`**: Registers the repository as a scoped service, creating a new instance for each HTTP request.
- **`AddRazorComponents()` and `AddInteractiveServerComponents()`**: Enables Blazor server-side rendering with interactive components.

The service registration has been completed successfully.

---

## Integrating Syncfusion Blazor DataGrid

### Step 1: Install and Configure Blazor DataGrid Components

Syncfusion is a library that provides pre-built UI components like DataGrid, which is used to display data in a table format.

**Instructions:**

1. The Syncfusion.Blazor.Grid package was installed in **Step 2** of the previous section.
2. Import the required namespaces in the `Components/_Imports.razor` file:

```csharp
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
```

3. Add the Syncfusion stylesheet and scripts in the `Components/App.razor` file. Find the `<head>` section and add:

```html
<!-- Syncfusion Blazor Stylesheet -->
<link href="_content/Syncfusion.Blazor.Themes/tailwind3.css" rel="stylesheet" />

<!-- Syncfusion Blazor Scripts -->
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
```

Syncfusion components are now configured and ready to use. For additional guidance, refer to the Grid component's [getting-started](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app) documentation.

### Step 2: Update the Blazor DataGrid in the Home Component

The Home component will display the purchase order data in a Syncfusion Blazor DataGrid with search, filter, sort, and pagination capabilities.

**Instructions:**

1. Open the file named `Home.razor` in the `Components/Pages` folder.
2. Add the following code to create a DataGrid:

```cshtml
@page "/"
@using System.Collections
@using Grid_PostgreSQL.Data
@inject PurchaseOrderRepository PurchaseOrderService
<PageTitle>Purchase Order Management System</PageTitle>

<section class="bg-gray-50 dark:bg-gray-950">
    <div class="mx-auto w-full py-12 sm:px-6 px-4">
        <h1 class="mb-4 text-3xl font-bold">Purchase Order Management System</h1>
        <p class="mb-3 text-gray-600">Manage and view all purchase orders from the database.</p>
        
        <!-- Syncfusion Blazor DataGrid Component -->
        <SfGrid TValue="PurchaseOrder" AllowPaging="true" AllowSorting="true" AllowFiltering="true">
            <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
            
            <GridColumns>
                <!-- Columns configuration -->
            </GridColumns>
            
            <GridPageSettings PageSize="10"></GridPageSettings>
        </SfGrid>
    </div>
</section>

@code {
    // CustomAdaptor class will be added in the next step
}
```

**Component Explanation:**

- **`@inject PurchaseOrderRepository`**: Injects the repository to access database methods.
- **`<SfGrid>`**: The DataGrid component that displays data in rows and columns.
- **`<GridColumns>`**: Defines individual columns in the DataGrid.
- **`<GridPageSettings>`**: Configures pagination with 10 records per page.

The Home component has been updated successfully with DataGrid.

---

### Step 3: Implement the CustomAdaptor

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can bind data from a **PostgreSQL** database using [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) and set the [Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Adaptors.html) property to [CustomAdaptor](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/custom-adaptor) for scenarios that require full control over data operations.

The `CustomAdaptor` is a bridge between the DataGrid and the PostgreSQL database. It handles all data operations including reading, searching, filtering, sorting, paging, and CRUD operations. Each operation in the CustomAdaptor's `ReadAsync` method handles specific grid functionality. The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid sends operation details to the API through a [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html) object. These details can be applied to the data source using methods from the [DataOperations](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html) class.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Add the following `CustomAdaptor` class code inside the `@code` block:

```csharp
@code {

    private CustomAdaptor? _customAdaptor;

    protected override void OnInitialized()
    {
        // Initialize the CustomAdaptor with the injected PurchaseOrderRepository
        _customAdaptor = new CustomAdaptor { PurchaseOrderService = PurchaseOrderService };
    }

    /// <summary>
    /// CustomAdaptor class bridges DataGrid interactions with database operations.
    /// This adaptor handles all data retrieval and manipulation for the DataGrid.
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        public static PurchaseOrderRepository? _purchaseOrderService { get; set; }

        public PurchaseOrderRepository? PurchaseOrderService
        {
            get => _purchaseOrderService;
            set => _purchaseOrderService = value;
        }

        /// <summary>
        /// ReadAsync retrieves records from the database and applies data operations.
        /// This method executes when the grid initializes and when filtering, searching, sorting, or paging occurs.
        /// </summary>
        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
        {
            try
            {
                // Fetch all purchase orders from the database
                IEnumerable<PurchaseOrder> dataSource = await _purchaseOrderService!.GetPurchaseOrdersDataAsync();

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
                int totalRecordsCount = dataSource.Cast<PurchaseOrder>().Count();

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

```cshtml
<SfGrid TValue="PurchaseOrder" 
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
| `Add` | Opens a form to add a new purchase order record. |
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

```cshtml
<SfGrid TValue="PurchaseOrder" 
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
    /// CustomAdaptor class to handle grid data operations with PostgreSQL using Entity Framework
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        public static PurchaseOrderRepository? _purchaseOrderService { get; set; }
        public PurchaseOrderRepository? PurchaseOrderService
        {
            get => _purchaseOrderService;
            set => _purchaseOrderService = value;
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
        {
            IEnumerable<PurchaseOrder> dataSource = await _purchaseOrderService!.GetPurchaseOrdersDataAsync();

            int totalRecordsCount = dataSource.Cast<PurchaseOrder>().Count();
            
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
}
```

Fetches purchase orders by calling the `GetPurchaseOrdersDataAsync` method implemented in `PurchaseOrderRepository.cs`.

**How Paging Works:**

- The DataGrid displays 10 records per page (as set in `GridPageSettings`).
- Navigation buttons allow the user to move between pages.
- When a page is requested, the `ReadAsync` method receives skip and take values.
- The `DataOperations.PerformSkip()` and `DataOperations.PerformTake()` methods handle pagination.
- Only the requested page of records is transmitted from the server.

Paging feature is now active with 10 records per page.

---

### Step 6: Implement Searching feature

Searching allows the user to find purchase order records by entering keywords in the search box.

**Instructions:**

1. Ensure the toolbar includes the "Search" item.

```cshtml
<SfGrid TValue="PurchaseOrder"
        AllowPaging="true"
        Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridPageSettings PageSize="10"></GridPageSettings>
    <!-- Grid columns configuration -->
</SfGrid>
```

2. Update the `ReadAsync` method in the `CustomAdaptor` class to handle searching:

```csharp
@code {
    private List<string> ToolbarItems = new List<string> { "Search"};
    
    /// <summary>
    /// CustomAdaptor class to handle grid data operations with PostgreSQL using Entity Framework
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        public static PurchaseOrderRepository? _purchaseOrderService { get; set; }
        public PurchaseOrderRepository? PurchaseOrderService { get => _purchaseOrderService; set => _purchaseOrderService = value; }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
        {
            IEnumerable<PurchaseOrder> dataSource = await _purchaseOrderService!.GetPurchaseOrdersDataAsync();

            // Handling Search
            if (dataManagerRequest.Search != null && dataManagerRequest.Search.Count > 0)
            {
                dataSource = DataOperations.PerformSearching(dataSource, dataManagerRequest.Search);
            }

            int totalRecordsCount = dataSource.Cast<PurchaseOrder>().Count();
            
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
}
```

**How Searching Works:**

- When the user enters text in the search box and presses Enter, the DataGrid sends a search request to the CustomAdaptor.
- The `ReadAsync` method receives the search criteria in `dataManagerRequest.Search`.
- The `DataOperations.PerformSearching()` method filters the data based on the search term across all columns (PoNumber, ItemName, Status, VendorID, etc.).
- Results are returned and displayed in the DataGrid.

Searching feature is now active.

---

### Step 7: Implement Filtering feature

Filtering allows the user to restrict purchase order data based on column values using a menu interface.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Add the [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowFiltering) property and [GridFilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridFilterSettings.html) to the `<SfGrid>` component:

```cshtml
<SfGrid TValue="PurchaseOrder" 
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
@code {
    private List<string> ToolbarItems = new List<string> { "Search"};
    
    /// <summary>
    /// CustomAdaptor class to handle grid data operations with PostgreSQL using Entity Framework
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        public static PurchaseOrderRepository? _purchaseOrderService { get; set; }
        public PurchaseOrderRepository? PurchaseOrderService { get => _purchaseOrderService; set => _purchaseOrderService = value; }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
        {
            IEnumerable<PurchaseOrder> dataSource = await _purchaseOrderService!.GetPurchaseOrdersDataAsync();

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

            int totalRecordsCount = dataSource.Cast<PurchaseOrder>().Count();

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
}
```

**How Filtering Works:**

- Click on the dropdown arrow in any column header to open the filter menu.
- Select filtering criteria (equals, contains, greater than, less than, etc.).
- Click the "Filter" button to apply the filter.
- The `ReadAsync` method receives the filter criteria in `dataManagerRequest.Where`.
- The `DataOperations.PerformFiltering()` method applies the filter conditions to the data.
- Results are filtered accordingly and displayed in the DataGrid.
- Common filter use cases: Filter by Status (Pending, Approved, Ordered, etc.), VendorID, ItemCategory, or OrderDate range.

Filtering feature is now active.

---

### Step 8: Implement Sorting feature

Sorting enables the user to arrange purchase order records in ascending or descending order based on column values.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Add the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) property to the `<SfGrid>` component:

```cshtml
<SfGrid TValue="PurchaseOrder" 
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
@code {
    public class CustomAdaptor : DataAdaptor
    {
        public static PurchaseOrderRepository? _purchaseOrderService { get; set; }
        public PurchaseOrderRepository? PurchaseOrderService { get => _purchaseOrderService; set => _purchaseOrderService = value; }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
        {
            IEnumerable<PurchaseOrder> dataSource = await _purchaseOrderService!.GetPurchaseOrdersDataAsync();

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

            int totalRecordsCount = dataSource.Cast<PurchaseOrder>().Count();

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
}
```

**How Sorting Works:**

- Click on the column header to sort in ascending order.
- Click again to sort in descending order.
- The `ReadAsync` method receives the sort criteria in `dataManagerRequest.Sorted`.
- The `DataOperations.PerformSorting()` method sorts the data based on the specified column and direction.
- Records are sorted accordingly and displayed in the DataGrid.
- Sorting can be applied to all columns: PoNumber, ItemName, Status, OrderDate, TotalAmount, etc.

Sorting feature is now active.

---

### Step 9: Implement Grouping feature

Grouping organizes purchase order records into hierarchical groups based on column values, providing a structured view of the data.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Add the [AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowGrouping) property to the `<SfGrid>` component:

```cshtml
<SfGrid TValue="PurchaseOrder" 
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
@code {
    public class CustomAdaptor : DataAdaptor
    {
        public static PurchaseOrderRepository? _purchaseOrderService { get; set; }
        public PurchaseOrderRepository? PurchaseOrderService { get => _purchaseOrderService; set => _purchaseOrderService = value; }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
        {
            IEnumerable<PurchaseOrder> dataSource = await _purchaseOrderService!.GetPurchaseOrdersDataAsync();

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

            int totalRecordsCount = dataSource.Cast<PurchaseOrder>().Count();

            // Handling Grouping
            if (dataManagerRequest.Group != null)
            {
                IEnumerable ResultData = dataSource.ToList();
                foreach (var group in dataManagerRequest.Group)
                {
                    ResultData = DataUtil.Group<PurchaseOrder>(ResultData, group, dataManagerRequest.Aggregates, 0, dataManagerRequest.GroupByFormatter);
                }
                var dataObject = new DataResult { Result = ResultData, Count = totalRecordsCount, Aggregates = aggregates };
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
                ? new DataResult() { Result = dataSource, Count = totalRecordsCount, Aggregates = aggregates }
                : (object)dataSource;
        }
    }
}
```

**How Grouping Works:**

- Columns can be grouped by dragging the column header into the group drop area.
- Common grouping scenarios: Group by Status (to see Pending, Approved, Ordered, Received, Canceled, Completed orders separately) or by ItemCategory.
- Each group can be expanded or collapsed by clicking on the group header.
- The `ReadAsync` method receives the grouping instructions through `dataManagerRequest.Group`.
- The grouping operation is processed using **DataUtil.Group**, which organizes the records into hierarchical groups based on the selected column.
- Grouping is performed after search, filter, and sort operations, ensuring the grouped data reflects all applied conditions.
- The processed grouped result is then returned to the **Grid** and displayed in a structured, hierarchical format.

Grouping feature is now active.

---

### Step 10: Perform CRUD operations

CustomAdaptor methods enable users to create, read, update, and delete purchase order records directly from the DataGrid. Each operation calls corresponding data layer methods in **PurchaseOrderRepository.cs** to execute PostgreSQL commands.

Add the Grid **EditSettings** and **Toolbar** configuration to enable create, read, update, and delete (CRUD) operations.

```cshtml
<SfGrid TValue="PurchaseOrder" 
        AllowPaging="true" 
        AllowSorting="true" 
        AllowFiltering="true" 
        AllowGrouping="true"
        Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
     <GridPageSettings PageSize="10"></GridPageSettings>
     <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Menu"></GridFilterSettings>
     <GridEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true" Mode="EditMode.Batch"></GridEditSettings>
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

Record insertion allows new purchase orders to be added directly through the DataGrid component. The adaptor processes the insertion request, performs any required business‑logic validation, and saves the newly created record to the PostgreSQL database.

In **Home.razor**, implement the `InsertAsync` method within the `CustomAdaptor` class:

```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> InsertAsync(DataManager dataManager, object value, string? key)
    {
        if (value is PurchaseOrder purchaseOrder)
        {
            await _purchaseOrderService!.AddPurchaseOrderAsync(purchaseOrder);
        }
        return value;
    }
}
```

In **Data/PurchaseOrderRepository.cs**, the insert method is implemented as:

```csharp
public async Task AddPurchaseOrderAsync(PurchaseOrder value)
{
    try
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value), "Purchase Order cannot be null");
        
        // Auto-generate the PoNumber if not provided
        if (string.IsNullOrEmpty(value.PoNumber))
        {
            value.PoNumber = await GeneratePoNumberAsync();
        }
        
        if (value.CreatedAt == default)
            value.CreatedAt = DateTime.Now;

        if (value.UpdatedAt == default)
            value.UpdatedAt = DateTime.Now;

        // Set default status if not provided
        if (string.IsNullOrEmpty(value.Status))
            value.Status = "Pending";

        _context.PurchaseOrders.Add(value);

        await _context.SaveChangesAsync();
    }
    catch (DbUpdateException ex)
    {
        Console.WriteLine($"Database error while adding purchase order: {ex.Message}");
        throw;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error adding purchase order: {ex.Message}");
        throw;
    }
}

/// <summary>
/// Generates a unique purchase order number based on the current count and date.
/// Format: PO-YYYY-XXXX (e.g., PO-2026-0001, PO-2026-0002)
/// </summary>
/// <returns>A unique purchase order number</returns>
/// <exception cref="Exception">Thrown when database query fails</exception>
private async Task<string> GeneratePoNumberAsync()
{
    try
    {
        // Get the current year
        int currentYear = DateTime.Now.Year;
        int count = await _context.PurchaseOrders
            .Where(p => p.OrderDate.HasValue && p.OrderDate.Value.Year == currentYear)
            .CountAsync();
        int nextNumber = count + 1;

        string poNumber = $"PO-{currentYear}-{nextNumber:D4}";

        while (await _context.PurchaseOrders.AnyAsync(p => p.PoNumber == poNumber))
        {
            nextNumber++;
            poNumber = $"PO-{currentYear}-{nextNumber:D4}";
        }

        return poNumber;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error generating PoNumber: {ex.Message}");
        throw;
    }
}

```

**What happens behind the scenes:**

1. The form data is collected and validated in the CustomAdaptor's `InsertAsync()` method.
2. The `PurchaseOrderRepository.AddPurchaseOrderAsync()` method is called.
3. The PoNumber is auto-generated if not provided using the `GeneratePoNumberAsync()` helper method.
4. Default values are set for timestamps and status.
5. The new record is added to the `_context.PurchaseOrders` collection.
6. `SaveChangesAsync()` persists the record to the PostgreSQL database.
7. The DataGrid automatically refreshes to display the new record.

Now the new purchase order is persisted to the database and reflected in the grid.

**Update**

Record modification allows purchase order details to be updated directly within the DataGrid. The adaptor processes the edited row, validates the updated values, and applies the changes to the **PostgreSQL database** while ensuring data integrity is preserved.

In **Home.razor**, implement the `UpdateAsync` method within the `CustomAdaptor` class:

```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> UpdateAsync(DataManager dataManager, object value, string? keyField, string key)
    {
        if (value is PurchaseOrder purchaseOrder)
        {
            await _purchaseOrderService!.UpdatePurchaseOrderAsync(purchaseOrder);
        }
        return value;
    }
}
```

In **Data/PurchaseOrderRepository.cs**, the update method is implemented as:

```csharp
public async Task UpdatePurchaseOrderAsync(PurchaseOrder value)
{
    try
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value), "Purchase Order cannot be null");

        if (value.PurchaseOrderId <= 0)
            throw new ArgumentException("Purchase Order ID must be valid", nameof(value.PurchaseOrderId));

        var existingPurchaseOrder = await _context.PurchaseOrders.FindAsync(value.PurchaseOrderId);
        if (existingPurchaseOrder == null)
            throw new KeyNotFoundException($"Purchase Order with ID {value.PurchaseOrderId} not found");

        existingPurchaseOrder.PoNumber = value.PoNumber;
        existingPurchaseOrder.VendorID = value.VendorID;
        existingPurchaseOrder.ItemName = value.ItemName;
        existingPurchaseOrder.ItemCategory = value.ItemCategory;
        existingPurchaseOrder.Quantity = value.Quantity;
        existingPurchaseOrder.UnitPrice = value.UnitPrice;
        existingPurchaseOrder.TotalAmount = value.TotalAmount;
        existingPurchaseOrder.Status = value.Status;
        existingPurchaseOrder.OrderedBy = value.OrderedBy;
        existingPurchaseOrder.ApprovedBy = value.ApprovedBy;
        existingPurchaseOrder.OrderDate = value.OrderDate;
        existingPurchaseOrder.ExpectedDeliveryDate = value.ExpectedDeliveryDate;
        existingPurchaseOrder.CreatedAt = value.CreatedAt;
        existingPurchaseOrder.UpdatedAt = DateTime.Now;

        await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException ex)
    {
        Console.WriteLine($"Concurrency error while updating purchase order: {ex.Message}");
        throw;
    }
    catch (DbUpdateException ex)
    {
        Console.WriteLine($"Database error while updating purchase order: {ex.Message}");
        throw;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error updating purchase order: {ex.Message}");
        throw;
    }
}
```

**What happens behind the scenes:**

1. The modified data is collected from the form.
2. The CustomAdaptor's `UpdateAsync()` method is called.
3. The `PurchaseOrderRepository.UpdatePurchaseOrderAsync()` method is called.
4. The existing record is retrieved from the database by ID.
5. All properties are updated with the new values.
6. The `UpdatedAt` timestamp is automatically set to the current time.
7. `SaveChangesAsync()` persists the changes to the PostgreSQL database.
8. The DataGrid refreshes to display the updated record.

Now modifications are synchronized to the database and reflected in the grid UI.

**Delete**

Record deletion allows purchase orders to be removed directly from the DataGrid. The adaptor captures the delete request, executes the corresponding **PostgreSQL DELETE** operation, and updates both the database and the grid to reflect the removal.

In **Home.razor**, implement the `RemoveAsync` method within the `CustomAdaptor` class:

```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> RemoveAsync(DataManager dataManager, object value, string? keyField, string key)
    {
        // This method will be invoked when deleting existing records from the Blazor DataGrid component.
        int? recordId = null;
        if (value is int intValue)
        {
            recordId = intValue;
        }
        else if (value is PurchaseOrder purchaseOrder)
        {
            recordId = purchaseOrder.PurchaseOrderId;
        }
        else if (int.TryParse(value?.ToString(), out int parsedValue))
        {
            recordId = parsedValue;
        }

        if (recordId.HasValue && recordId.Value > 0)
        {
            await _purchaseOrderService!.RemovePurchaseOrderAsync(recordId);
        }
        return value;
    }
}
```

In **Data/PurchaseOrderRepository.cs**, the delete method is implemented as:

```csharp
public async Task RemovePurchaseOrderAsync(int? key)
{
    try
    {
        if (key == null || key <= 0)
            throw new ArgumentException("Purchase Order ID cannot be null or invalid", nameof(key));

        var purchaseOrder = await _context.PurchaseOrders.FindAsync(key);
        if (purchaseOrder == null)
            throw new KeyNotFoundException($"Purchase Order with ID {key} not found");

        _context.PurchaseOrders.Remove(purchaseOrder);
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateException ex)
    {
        Console.WriteLine($"Database error while deleting purchase order: {ex.Message}");
        throw;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error deleting purchase order: {ex.Message}");
        throw;
    }
}
```

**What happens behind the scenes:**

1. The user selects a record and clicks "Delete".
2. A confirmation dialog appears (built into the DataGrid).
3. If confirmed, the CustomAdaptor's `RemoveAsync()` method is called.
4. The `PurchaseOrderRepository.RemovePurchaseOrderAsync()` method is called.
5. The record is located in the database by its ID.
6. The record is removed from the `_context.PurchaseOrders` collection.
7. `SaveChangesAsync()` executes the DELETE statement in PostgreSQL.
8. The DataGrid refreshes to remove the deleted record from the UI.

Now purchase orders are removed from the database and the grid UI reflects the changes immediately.

**Batch update**

Batch operations combine multiple insert, update, and delete actions into a single request, minimizing network overhead and ensuring transactional consistency by applying all changes atomically to the PostgreSQL database.

In **Home.razor**, implement the `BatchUpdateAsync` method within the `CustomAdaptor` class:

```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> BatchUpdateAsync(DataManager dataManager, object changed, object added, object deleted, string? keyField, string key, int? dropIndex)
    {
        // Process updated records
        if (changed != null)
        {
            foreach (var record in (IEnumerable<PurchaseOrder>)changed)
            {
                await _purchaseOrderService!.UpdatePurchaseOrderAsync(record);
            }
        }

        // Process newly added records
        if (added != null)
        {
            foreach (var record in (IEnumerable<PurchaseOrder>)added)
            {
                await _purchaseOrderService!.AddPurchaseOrderAsync(record);
            }
        }

        // Process deleted records
        if (deleted != null)
        {
            foreach (var record in (IEnumerable<PurchaseOrder>)deleted)
            {
                await _purchaseOrderService!.RemovePurchaseOrderAsync(record.PurchaseOrderId);
            }
        }
        return key;
    }
}
```

> This method is triggered when the DataGrid is operating in [Batch](https://blazor.syncfusion.com/documentation/datagrid/batch-editing) Edit mode.

---

## Complete Home.razor Implementation

Now that all the CustomAdaptor methods are implemented for CRUD operations, the complete Home.razor component includes GridColumns for all purchase order fields. The following is the complete Home.razor implementation that integrates all steps and features:

```cshtml
@page "/"
@using System.Collections
@using Grid_PostgreSQL.Data
@using Syncfusion.Blazor.Grids
@inject PurchaseOrderRepository PurchaseOrderService
<PageTitle>Purchase Order Management System</PageTitle>

<section class="bg-gray-50 dark:bg-gray-950">
    <div class="mx-auto w-full py-12 sm:px-6 px-4">
        <h1 class="mb-4 text-3xl font-bold">Purchase Order Management System</h1>
        <p class="mb-3 text-gray-600">Manage and view all purchase orders from the PostgreSQL database with full CRUD, search, filter, sort, and grouping capabilities.</p>
        
        <!-- Syncfusion Blazor DataGrid Component -->
        <SfGrid TValue="PurchaseOrder" 
                AllowPaging="true" 
                AllowSorting="true" 
                AllowFiltering="true" 
                AllowGrouping="true"
                Toolbar="@ToolbarItems">
            
            <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
            
            <GridPageSettings PageSize="10"></GridPageSettings>
            <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Menu"></GridFilterSettings>
            <GridEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true" Mode="EditMode.Batch"></GridEditSettings>
            
            <GridColumns>
                <GridColumn Field="@nameof(PurchaseOrder.PurchaseOrderId)" HeaderText="ID" Width="80" IsPrimaryKey="true"></GridColumn>
                <GridColumn Field="@nameof(PurchaseOrder.PoNumber)" HeaderText="PO Number" Width="120"></GridColumn>
                <GridColumn Field="@nameof(PurchaseOrder.VendorID)" HeaderText="Vendor ID" Width="110"></GridColumn>
                <GridColumn Field="@nameof(PurchaseOrder.ItemName)" HeaderText="Item Name" Width="150"></GridColumn>
                <GridColumn Field="@nameof(PurchaseOrder.ItemCategory)" HeaderText="Category" Width="120"></GridColumn>
                <GridColumn Field="@nameof(PurchaseOrder.Quantity)" HeaderText="Qty" Type="ColumnType.Decimal" Width="80"></GridColumn>
                <GridColumn Field="@nameof(PurchaseOrder.UnitPrice)" HeaderText="Unit Price" Type="ColumnType.Decimal" Format="C2" Width="110"></GridColumn>
                <GridColumn Field="@nameof(PurchaseOrder.TotalAmount)" HeaderText="Total Amount" Type="ColumnType.Decimal" Format="C2" Width="130"  AllowAdding="false" AllowEditing="false"></GridColumn>
                <GridColumn Field="@nameof(PurchaseOrder.Status)" HeaderText="Status" Width="110"></GridColumn>
                <GridColumn Field="@nameof(PurchaseOrder.OrderedBy)" HeaderText="Ordered By" Width="120"></GridColumn>
                <GridColumn Field="@nameof(PurchaseOrder.ApprovedBy)" HeaderText="Approved By" Width="120"></GridColumn>
                <GridColumn Field="@nameof(PurchaseOrder.OrderDate)" HeaderText="Order Date" Type="ColumnType.Date" Format="yMd" Width="120"></GridColumn>
                <GridColumn Field="@nameof(PurchaseOrder.ExpectedDeliveryDate)" HeaderText="Expected Delivery" Type="ColumnType.Date" Format="yMd" Width="140"></GridColumn>
                <GridColumn Field="@nameof(PurchaseOrder.CreatedAt)" HeaderText="Created At" Type="ColumnType.DateTime" Format="yMd HH:mm" Width="150"></GridColumn>
                <GridColumn Field="@nameof(PurchaseOrder.UpdatedAt)" HeaderText="Updated At" Type="ColumnType.DateTime" Format="yMd HH:mm" Width="150"></GridColumn>
            </GridColumns>
            
        </SfGrid>
    </div>
</section>

@code {
    private List<string> ToolbarItems = new List<string> { "Add", "Edit", "Delete", "Update", "Cancel", "Search" };
    private CustomAdaptor? _customAdaptor;

    protected override void OnInitialized()
    {
        _customAdaptor = new CustomAdaptor { PurchaseOrderService = PurchaseOrderService };
    }

    /// <summary>
    /// CustomAdaptor class bridges DataGrid interactions with database operations.
    /// This adaptor handles all data retrieval and manipulation for the DataGrid,
    /// including Search, Filter, Sort, Group, Paging, and CRUD operations.
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        public static PurchaseOrderRepository? _purchaseOrderService { get; set; }

        public PurchaseOrderRepository? PurchaseOrderService
        {
            get => _purchaseOrderService;
            set => _purchaseOrderService = value;
        }

        /// <summary>
        /// ReadAsync retrieves records from the database and applies data operations.
        /// This method executes when the grid initializes and when filtering, searching, sorting, or paging occurs.
        /// </summary>
        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
        {
            try
            {
                IEnumerable<PurchaseOrder> dataSource = await _purchaseOrderService!.GetPurchaseOrdersDataAsync();

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

                int totalRecordsCount = dataSource.Cast<PurchaseOrder>().Count();

                // Apply grouping if group criteria exists
                if (dataManagerRequest.Group != null && dataManagerRequest.Group.Count > 0)
                {
                    IEnumerable ResultData = dataSource.ToList();
                    foreach (var group in dataManagerRequest.Group)
                    {
                        ResultData = DataUtil.Group<PurchaseOrder>(ResultData, group, dataManagerRequest.Aggregates, 0, dataManagerRequest.GroupByFormatter);
                    }
                    return dataManagerRequest.RequiresCounts
                        ? new DataResult { Result = ResultData, Count = totalRecordsCount }
                        : (object)ResultData;
                }

                // Apply paging skip operation
                if (dataManagerRequest.Skip != 0)
                {
                    dataSource = DataOperations.PerformSkip(dataSource, dataManagerRequest.Skip);
                }

                // Apply paging take operation
                if (dataManagerRequest.Take != 0)
                {
                    dataSource = DataOperations.PerformTake(dataSource, dataManagerRequest.Take);
                }

                return dataManagerRequest.RequiresCounts
                    ? new DataResult() { Result = dataSource, Count = totalRecordsCount }
                    : (object)dataSource;
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while retrieving data: {ex.Message}");
            }
        }

        /// <summary>
        /// InsertAsync creates a new purchase order record in the database.
        /// </summary>
        public override async Task<object> InsertAsync(DataManager dataManager, object value, string? key)
        {
            if (value is PurchaseOrder purchaseOrder)
            {
                await _purchaseOrderService!.AddPurchaseOrderAsync(purchaseOrder);
            }
            return value;
        }

        /// <summary>
        /// UpdateAsync modifies an existing purchase order record in the database.
        /// </summary>
        public override async Task<object> UpdateAsync(DataManager dataManager, object value, string? keyField, string key)
        {
            if (value is PurchaseOrder purchaseOrder)
            {
                await _purchaseOrderService!.UpdatePurchaseOrderAsync(purchaseOrder);
            }
            return value;
        }

        /// <summary>
        /// RemoveAsync deletes a purchase order record from the database.
        /// </summary>
        public override async Task<object> RemoveAsync(DataManager dataManager, object value, string? keyField, string key)
        {
            int? recordId = null;
            if (value is int intValue)
            {
                recordId = intValue;
            }
            else if (value is PurchaseOrder purchaseOrder)
            {
                recordId = purchaseOrder.PurchaseOrderId;
            }
            else if (int.TryParse(value?.ToString(), out int parsedValue))
            {
                recordId = parsedValue;
            }

            if (recordId.HasValue && recordId.Value > 0)
            {
                await _purchaseOrderService!.RemovePurchaseOrderAsync(recordId);
            }
            return value;
        }

        /// <summary>
        /// BatchUpdateAsync processes multiple insert, update, and delete operations atomically.
        /// </summary>
        public override async Task<object> BatchUpdateAsync(DataManager dataManager, object changed, object added, object deleted, string? keyField, string key, int? dropIndex)
        {
            // Process updated records
            if (changed != null)
            {
                foreach (var record in (IEnumerable<PurchaseOrder>)changed)
                {
                    await _purchaseOrderService!.UpdatePurchaseOrderAsync(record);
                }
            }

            // Process newly added records
            if (added != null)
            {
                foreach (var record in (IEnumerable<PurchaseOrder>)added)
                {
                    await _purchaseOrderService!.AddPurchaseOrderAsync(record);
                }
            }

            // Process deleted records
            if (deleted != null)
            {
                foreach (var record in (IEnumerable<PurchaseOrder>)deleted)
                {
                    await _purchaseOrderService!.RemovePurchaseOrderAsync(record.PurchaseOrderId);
                }
            }
            return key;
        }
    }
}
```

**Key Features of the Complete Implementation:**

1. **GridColumns**: Defines 15 columns for all purchase order fields with appropriate data types and formatting.
2. **Toolbar**: Provides Add, Edit, Delete, Update, Cancel, and Search buttons for CRUD operations.
3. **Search**: Users can search across all columns using the search box.
4. **Filter**: Click column headers to apply menu-based filters (Status, Category, VendorID, etc.).
5. **Sort**: Click column headers to sort ascending or descending.
6. **Grouping**: Drag column headers to the group area to organize data by Status or Category.
7. **Paging**: Data is displayed in pages of 10 records each.
8. **CRUD Operations**: Add, Edit, Update, and Delete records with automatic timestamps and PoNumber generation.
9. **Batch Editing**: Multiple changes can be made and saved atomically.
10. **Error Handling**: Comprehensive exception handling with meaningful error messages.

---

## Running the Application

**Step 1: Ensure PostgreSQL Database is Ready**

1. Verify that PostgreSQL is running on your system.
2. Confirm that the `PurchaseOrderDB` database exists with the `PurchaseOrder` table (created in Step 1).
3. Verify the connection string in `appsettings.json` matches your PostgreSQL configuration.

**Step 2: Build the Application**

1. Open the terminal or Package Manager Console in Visual Studio.
2. Navigate to the project directory:

```powershell
cd "path/to/Grid_PostgreSQL"
```

3. Run the following command to restore packages and build:

```powershell
dotnet build
```

**Step 3: Run the Application**

Execute the following command:

```powershell
dotnet run
```

**Step 1: Ensure PostgreSQL Database is Ready**

1. Verify that PostgreSQL is running on your system.
2. Confirm that the `PurchaseOrderDB` database exists with the `PurchaseOrder` table (created in Step 1).
3. Verify the connection string in `appsettings.json` matches your PostgreSQL configuration.

**Step 2: Build the Application**

1. Open the terminal or Package Manager Console in Visual Studio.
2. Navigate to the project directory:

```powershell
cd "path/to/Grid_PostgreSQL"
```

3. Run the following command to restore packages and build:

```powershell
dotnet build
```

**Step 3: Run the Application**

Execute the following command:

```powershell
dotnet run
```

**Step 4: Access the Application**

1. Open a web browser.
2. Navigate to `https://localhost:5001` (or the port shown in the terminal).
3. The Purchase Order Management System is now running and ready to use.

### Available Features

- **View Data**: All purchase orders from the PostgreSQL database are displayed in the DataGrid.
- **Search**: Use the search box to find purchase orders by any field.
- **Filter**: Click on column headers to apply filters.
- **Sort**: Click on column headers to sort data in ascending or descending order.
- **Pagination**: Navigate through records using page numbers.
- **Add**: Click the "Add" button to create a new purchase order.
- **Edit**: Click the "Edit" button to modify existing purchase orders.
- **Delete**: Click the "Delete" button to remove purchase orders.

---

## Complete Sample Repository

A complete, working sample implementation is available in the [GitHub repository](https://github.com/SyncfusionExamples/connecting-databases-to-blazor-datagrid-component/tree/master/Binding%20PostgreSQL%20database%20using%20CustomAdaptor).

---

## Summary

This guide demonstrates how to:

1. Create a PostgreSQL database with purchase order records using pgAdmin 4. [🔗](#step-1-create-the-database-and-table-in-postgresql)
2. Install necessary NuGet packages for Entity Framework Core with Npgsql and Syncfusion. [🔗](#step-2-install-required-nuget-packages)
3. Create data models and DbContext for database communication with PostgreSQL-specific configuration. [🔗](#step-3-create-the-data-model)
4. Configure connection strings and register services. [🔗](#step-5-configure-the-connection-string)
5. Implement the repository pattern for data access with helper methods. [🔗](#step-6-create-the-repository-class)
6. Create a Blazor component with a DataGrid that supports searching, filtering, sorting, paging, and CRUD operations. [🔗](#step-1-install-and-configure-blazor-datagrid-components)
7. Handle bulk operations and batch updates. [🔗](#step-10-perform-crud-operations)

The application now provides a complete solution for managing purchase orders with a modern, user-friendly interface integrated with PostgreSQL.

