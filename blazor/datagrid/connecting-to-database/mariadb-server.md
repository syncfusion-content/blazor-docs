---
layout: post
title: Blazor Data Grid connected to MariaDB via Entity Framework | Syncfusion
description: Bind MariaDB data to Blazor Data Grid using Entity Framework Core with complete CRUD, filtering, sorting, paging, and advanced data operations.
platform: Blazor
control: DataGrid
documentation: ug
---

# Connecting MariaDB Server to Blazor Data Grid Using Entity Framework

The [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) supports binding data from a MariaDB Server database using Entity Framework Core (EF Core). This modern approach provides a more maintainable and type-safe alternative to raw SQL queries.

**What is Entity Framework Core?**

Entity Framework Core (EF Core) is a software tool that simplifies database operations in .NET applications. It serves as a bridge between C# code and databases like MariaDB.

**Key Benefits of Entity Framework Core**

- **Automatic SQL Generation**: Entity Framework Core generates optimized SQL queries automatically, eliminating the need to write raw SQL code.
- **Type Safety**: Work with strongly-typed objects instead of raw SQL strings, reducing errors.
- **Built-in Security**: Automatic parameterization prevents SQL injection attacks.
- **Version Control for Databases**: Manage database schema changes version-by-version through migrations.
- **Familiar Syntax**: Use LINQ (Language Integrated Query) syntax, which is more intuitive than raw SQL strings.

**What is Pomelo for MariaDB?**

**Pomelo.EntityFrameworkCore.MySql** is a software library that helps .NET applications work with a MariaDB database using Entity Framework Core. It acts as a bridge between Entity Framework Core and MariaDB (which is MySQL-compatible), allowing applications to read, write, update, and delete data in a MariaDB database.

## Prerequisites

Ensure the following software and packages are installed before proceeding:

| Software/Package | Version | Purpose |
|-----------------|---------|---------|
| Visual Studio 2026 | 18.0 or later | Development IDE with Blazor workload |
| .NET SDK | net10.0 or compatible | Runtime and build tools |
| MariaDB Server | 10.5 or later | Database server |
| Syncfusion.Blazor.Grid | {{site.blazorversion}} | DataGrid and UI components |
| Syncfusion.Blazor.Themes | {{site.blazorversion}} | Styling for DataGrid components |
| Microsoft.EntityFrameworkCore | 9.0.0 or later | Core framework for database operations |
| Microsoft.EntityFrameworkCore.Tools | 9.0.0 or later | Tools for managing database migrations |
| Pomelo.EntityFrameworkCore.MySql | 9.0.0 or later | MariaDB provider for Entity Framework Core |

## Setting Up the MariaDB Environment for Entity Framework Core

### Step 1: Create the database and Table in MariaDB server

First, the **MariaDB database** structure must be created to store subscription records.

**Instructions:**
1. Open MariaDB client or any MariaDB management tool.
2. Create a new database named `subscriptiondb`.
3. Define a `subscriptions` table with the specified schema.
4. Insert sample data for testing.

Run the following SQL script:

```sql
-- Create Database
CREATE DATABASE IF NOT EXISTS subscriptiondb;
USE subscriptiondb;

-- Create Subscriptions Table
CREATE TABLE IF NOT EXISTS subscriptions (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    PublicID VARCHAR(50) NOT NULL UNIQUE,
    CustomerId INT NULL,
    SubscriptionID INT NULL,
    InvoiceNumber VARCHAR(100) NULL,
    Description VARCHAR(500) NULL,
    Amount DECIMAL(15, 2) NOT NULL,
    CurrencyCode VARCHAR(10) DEFAULT 'INR',
    SubscriptionType VARCHAR(50) NULL,
    PaymentGateway VARCHAR(100) NULL,
    SubscriptionStartDate DATETIME NULL,
    SubscriptionEndDate DATETIME NULL,
    Status VARCHAR(50) NULL
);

-- Insert Sample Data (Optional)
INSERT INTO subscriptions (PublicID, CustomerId, SubscriptionID, InvoiceNumber, Description, Amount, CurrencyCode, SubscriptionType, PaymentGateway, SubscriptionStartDate, SubscriptionEndDate, Status) 
VALUES
('SUB26021901001', 1001, 50001, 'INV-2026-001', 'Premium Plan Annual', 12999.00, 'INR', 'ACTIVE', 'Razorpay', '2026-02-19 10:15:30', '2027-02-19 10:15:30', 'ACTIVE'),
('SUB26021901002', 1002, 50002, 'INV-2026-002', 'Basic Plan Monthly', 299.00, 'INR', 'ACTIVE', 'Stripe', '2026-02-19 11:20:10', '2026-03-19 11:20:10', 'ACTIVE');
```

After executing this script, the subscription records are stored in the `subscriptions` table within the `subscriptiondb` database. The database is now ready for integration with the Blazor application.

---

### Step 2: Install Required NuGet Packages

Before installing the necessary NuGet packages, a new Blazor Web Application must be created using the default template.
This template automatically generates essential starter files—such as **Program.cs, appsettings.json, the wwwroot folder, and the Components folder**.

For this guide, a Blazor application named **Grid_MariaDB** has been created. Once the project is set up, the next step involves installing the required NuGet packages. NuGet packages are software libraries that add functionality to the application. These packages enable Entity Framework Core and MariaDB integration.

**Method 1: Using Package Manager Console**

1. Open Visual Studio 2026.
2. Navigate to **Tools → NuGet Package Manager → Package Manager Console**.
3. Run the following commands:

```powershell
Install-Package Microsoft.EntityFrameworkCore -Version 9.0.0
Install-Package Microsoft.EntityFrameworkCore.Tools -Version 9.0.0
Install-Package Pomelo.EntityFrameworkCore.MySql -Version 9.0.0
Install-Package Syncfusion.Blazor.Grid -Version {{site.blazorversion}}
Install-Package Syncfusion.Blazor.Themes -Version {{site.blazorversion}}
```

**Method 2: Using NuGet Package Manager UI**

1. Open **Visual Studio 2026 → Tools → NuGet Package Manager → Manage NuGet Packages for Solution**.
2. Search for and install each package individually:
   - **Microsoft.EntityFrameworkCore** (version 9.0.0 or later)
   - **Microsoft.EntityFrameworkCore.Tools** (version 9.0.0 or later)
   - **Pomelo.EntityFrameworkCore.MySql** (version 9.0.0 or later)
   - **[Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid/)** (version {{site.blazorversion}})
   - **[Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)** (version {{site.blazorversion}})

All required packages are now installed.

### Step 3: Create the Data Model

A data model is a C# class that represents the structure of a database table. This model defines the properties that correspond to the columns in the `subscriptions` table.

**Instructions:**

1. Create a new folder named `Data` in the Blazor application project.
2. Inside the `Data` folder, create a new file named **Subscription.cs**.
3. Define the **SubscriptionModel** class with the following code:

```csharp
using System.ComponentModel.DataAnnotations;

namespace Grid_MariaDB.Data
{
    public class SubscriptionModel
    {
        [Key]
        public int Id { get; set; }

        public string? PublicID { get; set; }

        public int? CustomerId { get; set; }

        public int? SubscriptionID { get; set; }

        public string? InvoiceNumber { get; set; }

        public string? Description { get; set; }

        public decimal Amount { get; set; }

        public string? CurrencyCode { get; set; }

        public string? SubscriptionType { get; set; }

        public string? PaymentGateway { get; set; }

        public DateTime? SubscriptionStartDate { get; set; }

        public DateTime? SubscriptionEndDate { get; set; }

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

A `DbContext` is a special class that manages the connection between the application and the MariaDB database. It handles all database operations such as saving, updating, deleting, and retrieving data.

**Instructions:**

1. Inside the `Data` folder, create a new file named **SubscriptionDbContext.cs**.
2. Define the `SubscriptionDbContext` class with the following code:

```csharp
using Microsoft.EntityFrameworkCore;

namespace Grid_MariaDB.Data
{
    /// <summary>
    /// DbContext for Subscription entity
    /// Manages database connections and entity configurations
    /// </summary>
    public class SubscriptionDbContext : DbContext
    {
        public SubscriptionDbContext(DbContextOptions<SubscriptionDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// DbSet for Subscription entities
        /// </summary>
        public DbSet<SubscriptionModel> Subscriptions => Set<SubscriptionModel>();

        /// <summary>
        /// Configures the entity mappings and constraints
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Subscription entity
            modelBuilder.Entity<SubscriptionModel>(entity =>
            {
                // Primary Key
                entity.HasKey(e => e.Id);

                // Auto-increment for Primary Key
                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd();

                // Column configurations
                entity.Property(e => e.PublicID)
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

                entity.Property(e => e.SubscriptionType)
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

                entity.Property(e => e.SubscriptionID)
                    .IsRequired(false);

                entity.Property(e => e.SubscriptionStartDate)
                    .HasColumnType("datetime")
                    .IsRequired(false);

                entity.Property(e => e.SubscriptionEndDate)
                    .HasColumnType("datetime")
                    .IsRequired(false);

                entity.ToTable("subscriptions");
            });
        }
    }
}
```

**Explanation:**
- The `DbContext` class inherits from Entity Framework's `DbContext` base class.
- The `Subscriptions` property represents the `subscriptions` table in the database.
- The `OnModelCreating` method configures how the database columns should behave (maximum length, required/optional, default values, etc.).

The **SubscriptionDbContext** class is required because:

- It **connects** the application to the database.
- It **manages** all database operations.
- It **maps** C# models to actual database tables.
- It **configures** how data should look inside the database.

Without this class, Entity Framework Core will not know where to save data or how to create the subscriptions table. The DbContext has been successfully configured.

### Step 5: Configure the Connection String

A connection string contains the information needed to connect the application to the MariaDB database, including the server address, port, database name, and credentials.

**Instructions:**

1. Open the `appsettings.json` file in the project root.
2. Add or update the `ConnectionStrings` section with the MariaDB connection details:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Port=3306;Database=subscriptiondb;Uid=root;Pwd=mariadb@123;AllowUserVariables=true;"
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
| Server | The address of the MariaDB server (use `localhost` for local development) |
| Port | The MariaDB port number (default is `3306`) |
| Database | The database name (in this case, `subscriptiondb`) |
| Uid | The MariaDB username (default is `root`) |
| Pwd | The MariaDB password |
| AllowUserVariables | Allows user-defined variables in queries |

The database connection string has been configured successfully.

### Step 6: Create the Repository Class

A repository class is an intermediary layer that handles all database operations. This class uses Entity Framework Core to communicate with the database.

**Instructions:**

1. Inside the `Data` folder, create a new file named **SubscriptionRepository.cs**.
2. Define the **SubscriptionRepository** class with the following code:

```csharp
using Microsoft.EntityFrameworkCore;

namespace Grid_MariaDB.Data
{
    /// <summary>
    /// Repository pattern implementation for Subscription entity using Entity Framework Core
    /// Handles all CRUD operations and business logic for subscriptions
    /// </summary>
    public class SubscriptionRepository
    {
        private readonly SubscriptionDbContext _context;

        public SubscriptionRepository(SubscriptionDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all subscriptions from the database ordered by ID in descending order
        /// </summary>
        /// <returns>List of all subscriptions</returns>
        public async Task<List<SubscriptionModel>> GetSubscriptionsAsync()
        {
            return await _context.Subscriptions
                .OrderByDescending(t => t.Id)
                .ToListAsync();
        }

        /// <summary>
        /// Adds a new subscription to the database
        /// </summary>
        public async Task AddSubscriptionAsync(SubscriptionModel? subscription)
        {
            // Handle logic to add a new subscription to the database
        }

        /// <summary>
        /// Updates an existing subscription in the database
        /// </summary>
        public async Task UpdateSubscriptionAsync(SubscriptionModel? subscription)
        {
            // Handle logic to update an existing subscription to the database
        }

        /// <summary>
        /// Deletes a subscription from the database
        /// </summary>
        public async Task RemoveSubscriptionAsync(int? subscriptionId)
        {
            // Handle logic to delete an existing subscription to the database
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
using Grid_MariaDB.Data;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Get connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// Register DbContext with MariaDB database
builder.Services.AddDbContext<SubscriptionDbContext>(options =>
{
    options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    );
});

// Register the repository for dependency injection
builder.Services.AddScoped<SubscriptionRepository>();

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

* The Syncfusion.Blazor.Grid package was installed in **Step 2** of the previous heading.
* Import the required namespaces in the `Components/_Imports.razor` file:

```csharp
@using Grid_MariaDB.Data
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.DropDowns
```

* Add the Syncfusion stylesheet and scripts in the `Components/App.razor` file. Find the `<head>` section and add:

```html
<!-- Syncfusion Blazor Stylesheet -->
<link href="_content/Syncfusion.Blazor.Themes/tailwind3.css" rel="stylesheet" />

<!-- Syncfusion Blazor Scripts -->
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
```

For this project, the tailwind3 theme is used. A different theme can be selected or the existing theme can be customized based on project requirements. Refer to the [Syncfusion Blazor Components Appearance](https://blazor.syncfusion.com/documentation/appearance/themes) documentation to learn more about theming and customization options.

Syncfusion components are now configured and ready to use. For additional guidance, refer to the Grid component’s [getting‑started](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app) documentation.

### Step 2: Update the Blazor DataGrid

The `Home.razor` component will display the subscription data in a Syncfusion Blazor DataGrid with search, filter, sort, and pagination capabilities.

**Instructions:**

* Open the file named `Home.razor` in the `Components/Pages` folder.
* Add the following code to create a basic DataGrid:

```cshtml
@page "/"
@rendermode InteractiveServer
@inject SubscriptionRepository SubscriptionService

<PageTitle>Subscription Management System</PageTitle>

<div class="container-fluid p-4">
    <h1 class="mb-4">Subscription Management System</h1>
    <p class="mb-3">Manage and view all subscription records from the database.</p>
    
    <!-- Syncfusion Blazor DataGrid Component -->
    <SfGrid TValue="SubscriptionModel" AllowPaging="true" AllowSorting="true" AllowFiltering="true">
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
- **`@inject SubscriptionRepository`**: Injects the repository to access database methods.
- **`<SfGrid>`**: The DataGrid component that displays data in rows and columns.
- **`<GridColumns>`**: Defines individual columns in the DataGrid.
- **`<GridPageSettings>`**: Configures pagination with 10 records per page.

The Home component has been updated successfully with DataGrid.

---

### Step 3: Implement the CustomAdaptor

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can bind data from a **MariaDB Server** database using [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) and set the [Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Adaptors.html) property to `CustomAdaptor` for scenarios that require full control over data operations.

The `CustomAdaptor` is a bridge between the DataGrid and the database. It handles all data operations including reading, searching, filtering, sorting, paging, and CRUD operations. Each operation in the CustomAdaptor's `ReadAsync` method handles specific grid functionality. The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid sends operation details to the API through a [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html) object. These details can be applied to the data source using methods from the [DataOperations](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html) class.

**Instructions:**

* Open the `Components/Pages/Home.razor` file.
* Add the following `CustomAdaptor` class code inside the `@code` block:

```csharp
@code {

    private static SubscriptionRepository? _subscriptionService;

    /// <summary>
    /// CustomAdaptor class bridges DataGrid interactions with database operations.
    /// This adaptor handles all data retrieval and manipulation for the DataGrid.
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        public SubscriptionRepository? SubscriptionService
        {
            get => _subscriptionService;
            set => _subscriptionService = value;
        }

        /// <summary>
        /// ReadAsync retrieves records from the database and applies data operations.
        /// This method executes when the grid initializes and when filtering, searching, sorting, or paging occurs.
        /// </summary>
        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
        {
            try
            {
                // Fetch all subscriptions from the database
                IEnumerable dataSource = await _subscriptionService!.GetSubscriptionsAsync();

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
                int totalRecordsCount = dataSource.Cast<SubscriptionModel>().Count();

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

                // Handling Group operation in CustomAdaptor.
                if (dataManagerRequest.Group != null)
                {
                    foreach (var group in dataManagerRequest.Group)
                    {
                        dataSource = DataUtil.Group<SubscriptionModel>(dataSource, group, dataManagerRequest.Aggregates, 0, dataManagerRequest.GroupByFormatter);
                        //Add custom logic here if needed and remove above method
                    }
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

* Open the `Components/Pages/Home.razor` file.
* Update the `<SfGrid>` component to include the [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Toolbar) property with CRUD and search options:

```cshtml
<SfGrid TValue="SubscriptionModel" 
        AllowPaging="true" 
        AllowSorting="true" 
        AllowFiltering="true" 
        Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    
    <!-- Grid columns configuration -->
</SfGrid>
```

* Add the toolbar items list in the `@code` block:

```csharp
@code {
    private List<string> ToolbarItems = new List<string> { "Add", "Edit", "Delete", "Update", "Cancel", "Search"};

    // CustomAdaptor class code...
}
```

**Toolbar Items Explanation:**

| Item | Function |
|------|----------|
| `Add` | Opens a form to add a new subscription record. |
| `Edit` | Enables editing of the selected record. |
| `Delete` | Deletes the selected record from the database. |
| `Update` | Saves changes made to the selected record. |
| `Cancel` | Cancels the current edit or add operation. |
| `Search` | Displays a search box to find records. |

The toolbar has been successfully added.

---

### Step 5: Running the Application

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
2. Navigate to `https://localhost:5001` (or the port shown in the terminal).
3. The subscription management application is now running and ready to use.

![Basic DataGrid displaying subscriptions from the MariaDB Server database](../images/blazor-datagrid-mariadb.png)

### Step 6: Implement Paging Feature

Paging divides large datasets into smaller pages to improve performance and usability.

**Instructions:**

* The paging feature is already partially enabled in the `<SfGrid>` component with [AllowPaging="true"](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowPaging).
* The page size is configured with [GridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html).
* No additional code changes are required from the previous steps.

```cshtml
<SfGrid TValue="SubscriptionModel" 
        AllowPaging="true">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridPageSettings PageSize="10"></GridPageSettings>
    
    <!-- Grid columns configuration -->
</SfGrid>
```
* Update the `ReadAsync` method in the `CustomAdaptor` class to handle paging:

```csharp
@code {  
    
    /// <summary>
    /// CustomAdaptor class to handle grid data operations with MariaDB using Entity Framework
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        public static SubscriptionRepository? _subscriptionService { get; set; }
        public SubscriptionRepository? SubscriptionService 
        { 
            get => _subscriptionService;
            set => _subscriptionService = value;
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
        {
            IEnumerable dataSource = await _subscriptionService!.GetSubscriptionsAsync();        

            int totalRecordsCount = dataSource.Cast<SubscriptionModel>().Count();
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
}
```

Fetches subscription data by calling the **GetSubscriptionsAsync** method, which is implemented in the **SubscriptionRepository.cs** file.

```csharp
/// <summary>
/// Retrieves all subscriptions from the database ordered by ID descending
/// </summary>
/// <returns>List of all subscriptions</returns>
public async Task<List<SubscriptionModel>> GetSubscriptionsAsync()
{
    try
    {
        return await _context.Subscriptions
            .OrderByDescending(t => t.Id)
            .ToListAsync();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error retrieving subscriptions: {ex.Message}");
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

### Step 7: Implement Searching feature

Searching allows the user to find records by entering keywords in the search box.

**Instructions:**

* The search functionality is already enabled in the CustomAdaptor's `ReadAsync` method.
* Ensure the toolbar includes the "Search" item.
* No additional code changes are required.

```cshtml
<SfGrid TValue="SubscriptionModel"        
        AllowPaging="true
        Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridPageSettings PageSize="10"></GridPageSettings>
    <!-- Grid columns configuration -->
</SfGrid>
```
* Update the `ReadAsync` method in the `CustomAdaptor` class to handle searching:

```csharp
@code {
    private List<string> ToolbarItems = new List<string> { "Search"};
    
    /// <summary>
    /// CustomAdaptor class to handle grid data operations with MariaDB using Entity Framework
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        public static SubscriptionRepository? _subscriptionService { get; set; }
        public SubscriptionRepository? SubscriptionService 
        { 
            get => _subscriptionService;
            set => _subscriptionService = value;
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
        {
            IEnumerable dataSource = await _subscriptionService!.GetSubscriptionsAsync();

            // Handling Search
            if (dataManagerRequest.Search != null && dataManagerRequest.Search.Count > 0)
            {
                dataSource = DataOperations.PerformSearching(dataSource, dataManagerRequest.Search);
            }

            int totalRecordsCount = dataSource.Cast<SubscriptionModel>().Count();
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

### Step 8: Implement Filtering feature

Filtering allows the user to restrict data based on column values using a menu interface.

**Instructions:**

* Open the `Components/Pages/Home.razor` file.
* Add the [AllowFiltering]((https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowFiltering)) property and [GridFilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridFilterSettings.html) to the `<SfGrid>` component:

```cshtml
<SfGrid TValue="SubscriptionModel" 
        AllowPaging="true"         
        AllowFiltering="true"
        Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    
    <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Menu"></GridFilterSettings>
    
    <!-- Grid columns configuration -->
</SfGrid>
```

* Update the `ReadAsync` method in the `CustomAdaptor` class to handle filtering:

```csharp
/// <summary>
/// CustomAdaptor class to handle grid data operations with MariaDB using Entity Framework
/// </summary>
public class CustomAdaptor : DataAdaptor
{
    public static SubscriptionRepository? _subscriptionService { get; set; }
    public SubscriptionRepository? SubscriptionService 
    { 
        get => _subscriptionService;
        set => _subscriptionService = value;
    }

    public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
    {
        IEnumerable dataSource = await _subscriptionService!.GetSubscriptionsAsync();

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
        
        int totalRecordsCount = dataSource.Cast<SubscriptionModel>().Count();
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

### Step 9: Implement Sorting feature

Sorting enables the user to arrange records in ascending or descending order based on column values.

**Instructions:**

* Open the `Components/Pages/Home.razor` file.
* Add the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) property to the `<SfGrid>` component:

```cshtml
<SfGrid TValue="SubscriptionModel" 
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

* Update the `ReadAsync` method in the `CustomAdaptor` class to handle sorting:

```csharp
/// <summary>
/// CustomAdaptor class to handle grid data operations with MariaDB using Entity Framework
/// </summary>
public class CustomAdaptor : DataAdaptor
{
    public static SubscriptionRepository? _subscriptionService { get; set; }
    public SubscriptionRepository? SubscriptionService 
    { 
        get => _subscriptionService;
        set => _subscriptionService = value;
    }

    public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
    {
        IEnumerable dataSource = await _subscriptionService!.GetSubscriptionsAsync();

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
        
        int totalRecordsCount = dataSource.Cast<SubscriptionModel>().Count();
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

### Step 10: Implement Grouping feature

Grouping organizes records into hierarchical groups based on column values.

**Instructions:**

* Open the `Components/Pages/Home.razor` file.
* Add the [AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowGrouping) property to the `<SfGrid>` component:

```cshtml
<SfGrid TValue="SubscriptionModel" 
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
* Update the `ReadAsync` method in the `CustomAdaptor` class to handle grouping:


```csharp
/// <summary>
/// CustomAdaptor class to handle grid data operations with MariaDB using Entity Framework
/// </summary>
public class CustomAdaptor : DataAdaptor
{
    public static SubscriptionRepository? _subscriptionService { get; set; }
    public SubscriptionRepository? SubscriptionService 
    { 
        get => _subscriptionService;
        set => _subscriptionService = value;
    }

    public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
    {
        IEnumerable dataSource = await _subscriptionService!.GetSubscriptionsAsync();

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

        int totalRecordsCount = dataSource.Cast<SubscriptionModel>().Count();
        
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

        // Handling Group operation in CustomAdaptor.
        if (dataManagerRequest.Group != null)
        {
            foreach (var group in dataManagerRequest.Group)
            {
                dataSource = DataUtil.Group<SubscriptionModel>(dataSource, group, dataManagerRequest.Aggregates, 0, dataManagerRequest.GroupByFormatter);
            }
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

### Step 11: Perform CRUD operations

CustomAdaptor methods enable users to create, read, update, and delete records directly from the DataGrid. Each operation calls corresponding data layer methods in **SubscriptionRepository.cs** to execute MariaDB commands.

Add the Grid **EditSettings** and **Toolbar** configuration to enable create, read, update, and delete (CRUD) operations.

```cshtml
<SfGrid TValue="SubscriptionModel" 
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

Record insertion allows new subscriptions to be added directly through the DataGrid component. The adaptor processes the insertion request, performs any required business‑logic validation, and saves the newly created record to the MariaDB Server database.

In **Home.razor**, implement the `InsertAsync` method to handle record deletion within the `CustomAdaptor` class:

```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> InsertAsync(DataManager dataManager, object value, string key)
    {
        await _subscriptionService!.AddSubscriptionAsync(value as SubscriptionModel);
        return value;
    }
}
```
In **Data/SubscriptionRepository.cs**, implement the insert method:

```csharp
public async Task AddSubscriptionAsync(SubscriptionModel? subscription)
{
    if (subscription == null)
        throw new ArgumentNullException(nameof(subscription), "Subscription cannot be null");

    if (subscription.SubscriptionStartDate == null)
        subscription.SubscriptionStartDate = DateTime.Now;

    if (string.IsNullOrWhiteSpace(subscription.CurrencyCode))
        subscription.CurrencyCode = "INR";

    string temporaryPublicID = GeneratePublicSubscriptionId(subscription.SubscriptionStartDate, 99999);
    subscription.PublicID = temporaryPublicID;

    _context.Subscriptions.Add(subscription);

    await _context.SaveChangesAsync();

    string finalPublicID = GeneratePublicSubscriptionId(subscription.SubscriptionStartDate, subscription.Id);

    subscription.PublicID = finalPublicID;

    _context.Subscriptions.Update(subscription);
    await _context.SaveChangesAsync();
}

private string GeneratePublicSubscriptionId(DateTime? SubscriptionStartDate, int primaryKeyId)
{
    DateTime dateToUse = SubscriptionStartDate ?? DateTime.Now;
    string datepart = dateToUse.ToString("yyMMdd");

    string formattedId = primaryKeyId.ToString("D5");

    string publicID = $"{PublicSubscriptionIdPrefix}{datepart}{formattedId}";

    return publicID;
}
```

**Helper methods explanation:**
- `GeneratePublicSubscriptionId()`: A new PublicID is generated using SubscriptionStartDate and primaryKeyId.

**What happens behind the scenes:**

1. The form data is collected and validated in the CustomAdaptor's `InsertAsync()` method.
2. The `SubscriptionRepository.AddSubscriptionAsync()` method is called.
3. The new record is added to the `_context.Subscriptions` collection.
4. `SaveChangesAsync()` persists the record to the MariaDB database.
5. The DataGrid automatically refreshes to display the new record.

Now the new subscription is persisted to the database and reflected in the grid.

**Update**

Record modification allows subscription details to be updated directly within the DataGrid. The adaptor processes the edited row, validates the updated values, and applies the changes to the **MariaDB Server database** while ensuring data integrity is preserved.

In **Home.razor**, implement the `UpdateAsync` method to handle record deletion within the `CustomAdaptor` class:


```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> UpdateAsync(DataManager dataManager, object value, string keyField, string key)
    {
        await _subscriptionService!.UpdateSubscriptionAsync(value as SubscriptionModel);
        return value;
    }
}
```
In **Data/SubscriptionRepository.cs**, implement the update method:

```csharp
public async Task UpdateSubscriptionAsync(SubscriptionModel? subscription)
{
    if (subscription == null)
        throw new ArgumentNullException(nameof(subscription), "Subscription cannot be null");

    var existingSubscription = await _context.Subscriptions.FindAsync(subscription.Id);
    if (existingSubscription == null)
        throw new KeyNotFoundException($"Subscription with ID {subscription.Id} not found in the database.");

    existingSubscription.PublicID = subscription.PublicID;
    existingSubscription.CustomerId = subscription.CustomerId;
    existingSubscription.SubscriptionID = subscription.SubscriptionID;
    existingSubscription.InvoiceNumber = subscription.InvoiceNumber;
    existingSubscription.Description = subscription.Description;
    existingSubscription.Amount = subscription.Amount;
    existingSubscription.CurrencyCode = subscription.CurrencyCode;
    existingSubscription.SubscriptionType = subscription.SubscriptionType;
    existingSubscription.PaymentGateway = subscription.PaymentGateway;
    existingSubscription.SubscriptionEndDate = subscription.SubscriptionEndDate;
    existingSubscription.Status = subscription.Status;

    _context.Subscriptions.Update(existingSubscription);

    await _context.SaveChangesAsync();
}
```

**What happens behind the scenes:**

1. The modified data is collected from the form.
2. The CustomAdaptor's `UpdateAsync()` method is called.
3. The `SubscriptionRepository.UpdateSubscriptionAsync()` method is called.
4. The existing record is retrieved from the database by ID.
5. All properties are updated with the new values (except ID and SubscriptionStartDate).
6. `SaveChangesAsync()` persists the changes to the MariaDB database.
7. The DataGrid refreshes to display the updated record.

Now modifications are synchronized to the database and reflected in the grid UI.

**Delete**

Record deletion allows subscriptions to be removed directly from the DataGrid. The adaptor captures the delete request, executes the corresponding **MariaDB DELETE** operation, and updates both the database and the grid to reflect the removal.

In **Home.razor**, implement the `RemoveAsync` method to handle record deletion within the `CustomAdaptor` class:

```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> RemoveAsync(DataManager dataManager, object value, string keyField, string key)
    {
        await _subscriptionService!.RemoveSubscriptionAsync(value as int?);
        return value;
    }
}
```
In **Data/SubscriptionRepository.cs**, implement the delete method:

```csharp
public async Task RemoveSubscriptionAsync(int? key)
{
    try
    {
        if (key == null || key <= 0)
            throw new ArgumentException("Subscription ID cannot be null or invalid", nameof(key));

        var subscription = await _context.Subscriptions.FindAsync(key);
        if (subscription == null)
            throw new KeyNotFoundException($"Subscription with ID {key} not found");

        _context.Subscriptions.Remove(subscription);
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateException ex)
    {
        Console.WriteLine($"Database error while deleting subscription: {ex.Message}");
        throw;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error deleting subscription: {ex.Message}");
        throw;
    }
}
```
**What happens behind the scenes:**

1. The user selects a record and clicks "Delete".
2. A confirmation dialog appears (built into the DataGrid).
3. If confirmed, the CustomAdaptor's `RemoveAsync()` method is called.
4. The `SubscriptionRepository.RemoveSubscriptionAsync()` method is called.
5. The record is located in the database by its ID.
6. The record is removed from the `_context.Subscriptions` collection.
7. `SaveChangesAsync()` executes the DELETE statement in MariaDB.
8. The DataGrid refreshes to remove the deleted record from the UI.

Now subscriptions are removed from the database and the grid UI reflects the changes immediately.

**Batch update**

Batch operations combine multiple insert, update, and delete actions into a single request, minimizing network overhead and ensuring transactional consistency by applying all changes atomically to the MariaDB Server database.

In **Home.razor**, implement the `BatchUpdateAsync` method to handle multiple record updates in a single request within the `CustomAdaptor` class:

```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> BatchUpdateAsync(DataManager dataManager, object changed, object added, object deleted, string keyField, string key, int? dropIndex)
    {
        // Process updated records
        if (changed != null)
        {
            foreach (var record in (IEnumerable<SubscriptionModel>)changed)
            {
                await _subscriptionService!.UpdateSubscriptionAsync(record);
            }
        }

        // Process newly added records
        if (added != null)
        {
            foreach (var record in (IEnumerable<SubscriptionModel>)added)
            {
                await _subscriptionService!.AddSubscriptionAsync(record);
            }
        }

        // Process deleted records
        if (deleted != null)
        {
            foreach (var record in (IEnumerable<SubscriptionModel>)deleted)
            {
                await _subscriptionService!.RemoveSubscriptionAsync(record.Id);
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
- Each modified record is processed using `SubscriptionRepository.UpdateSubscriptionAsync()`.
- Each newly added record is saved using `SubscriptionRepository.AddSubscriptionAsync()`.
- Each deleted record is removed using `SubscriptionRepository.RemoveSubscriptionAsync()`.
- All repository operations persist changes to the MySQL Server database.
- The DataGrid refreshes to display the updated, added, and removed records in a single response.

Now the adaptor supports bulk modifications with atomic database synchronization. All CRUD operations are now fully implemented, enabling comprehensive data management capabilities within the Blazor DataGrid.

**Reference links**
- [InsertAsync(DataManager, object)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_InsertAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_) - Create new records in MariaDB Server
- [UpdateAsync(DataManager, object, string, string)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_UpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) - Edit existing records in MariaDB Server
- [RemoveAsync(DataManager, object, string, string)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_RemoveAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) - Delete records from MariaDB Server
- [BatchUpdateAsync(DataManager, object, object, object, string, string, int?)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_BatchUpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_Object_System_Object_System_String_System_String_System_Nullable_System_Int32__) - Handle bulk operations

---

### Step 12: Complete code
Here is the complete and final `Home.razor` component with all features integrated:

```cshtml
@page "/"
@rendermode InteractiveServer
@using System.Collections
@inject SubscriptionRepository SubscriptionService

<SfGrid TValue="SubscriptionModel" AllowSorting="true" AllowFiltering="true" AllowGrouping="true" AllowPaging="true"
    Height="500px" Width="100%" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" })">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Menu"></GridFilterSettings>
    <GridEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridPageSettings PageSize="10"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(SubscriptionModel.Id) IsPrimaryKey="true" ShowInColumnChooser="false" ShowColumnMenu="false"></GridColumn>
        <GridColumn Field=@nameof(SubscriptionModel.PublicID) HeaderText="Subscription ID" Width="170" TextAlign="TextAlign.Left" AllowAdding="false" AllowEditing="false">
            <Template>
                @{
                    var data = (SubscriptionModel)context;
                }   
                <a class="status-text status-ticket-id">
                    @data.PublicID
                </a>
            </Template>
        </GridColumn>
        <GridColumn Field=@nameof(SubscriptionModel.CustomerId) HeaderText="Customer ID" Width="140" ValidationRules="@(new ValidationRules { Required = true })" EditType="EditType.NumericEdit" />
        <GridColumn Field=@nameof(SubscriptionModel.SubscriptionID) HeaderText="Subscription ID" Width="120" ValidationRules="@(new ValidationRules { Required = true })" EditType="EditType.NumericEdit" />
        <GridColumn Field=@nameof(SubscriptionModel.InvoiceNumber) HeaderText="Invoice No" Width="130" EditType="EditType.DefaultEdit" />
        <GridColumn Field=@nameof(SubscriptionModel.Description) HeaderText="Description" Width="180" EditType="EditType.DefaultEdit" />
        <GridColumn Field=@nameof(SubscriptionModel.Amount) HeaderText="Amount" Width="130" ValidationRules="@(new ValidationRules { Required = true })" Format="N2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit">
            <Template>
                @{
                    var amount = (context as SubscriptionModel)?.Amount ?? 0;
                    var amountClass = amount < 0 ? "amnt-negative" : "amnt-positive";
                }
                <span class="@amountClass">@amount.ToString("N2")</span>
            </Template>
        </GridColumn>
        <GridColumn Field=@nameof(SubscriptionModel.CurrencyCode) HeaderText="Curr" Width="100" TextAlign="TextAlign.Center" EditType="EditType.DefaultEdit" />
        <GridColumn Field=@nameof(SubscriptionModel.SubscriptionType) HeaderText="Type" Width="100" EditType="EditType.DropDownEdit" EditorSettings="@TypeDropDownParams">
            <Template>
                @{
                    var data = (SubscriptionModel)context;
                }
                <span class="chip @GetCategoryClass(data)">
                    @data.SubscriptionType
                </span>
            </Template>
        </GridColumn>
        <GridColumn Field=@nameof(SubscriptionModel.PaymentGateway) HeaderText="Gateway" Width="130" EditType="EditType.DropDownEdit" EditorSettings="@GatewayDropDownParams" />
        <GridColumn Field=@nameof(SubscriptionModel.SubscriptionStartDate) HeaderText="Start Date" Width="170" Format="dd-MMM-yy hh:mm tt" TextAlign="TextAlign.Right" Type="ColumnType.DateTime" AllowEditing="false" />
        <GridColumn Field=@nameof(SubscriptionModel.SubscriptionEndDate) HeaderText="End Date" Width="170" Format="dd-MMM-yy hh:mm tt" TextAlign="TextAlign.Right" Type="ColumnType.DateTime" EditType="EditType.DateTimePickerEdit" />

        <GridColumn Field=@nameof(SubscriptionModel.Status) HeaderText="Status" Width="110" ValidationRules="@(new ValidationRules { Required = true })" EditType="EditType.DropDownEdit" EditorSettings="@StatusDropDownParams">
            <Template>
                @{
                    var status = (context as SubscriptionModel)?.Status;
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
> * The [EditType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.EditType.html?_gl=1*4kxqtd*_gcl_au*ODcxNTU4MzMyLjE3Njc1ODkwOTk.*_ga*NjA2MTg0NzMuMTc1OTc1MDUyNg..*_ga_41J4HFMX1J*czE3Njk1MzE3NTAkbzY1JGcxJHQxNzY5NTMyOTMwJGo2MCRsMCRoMA..) property can be used to specify the desired editor for each column. [🔗](https://blazor.syncfusion.com/documentation/datagrid/edit-types)
> * The behavior of default editors can be customized using the [EditorSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_EditorSettings) property of the `GridColumn` component. [🔗](https://blazor.syncfusion.com/documentation/datagrid/edit-types#customizing-the-default-editors)
> * [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Type) property of the `GridColumn` component  specifies the data type of a grid column.
> * The [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html?_gl=1*8q6kap*_gcl_au*ODcxNTU4MzMyLjE3Njc1ODkwOTk.*_ga*NjA2MTg0NzMuMTc1OTc1MDUyNg..*_ga_41J4HFMX1J*czE3Njk1MzE3NTAkbzY1JGcxJHQxNzY5NTMzMDg0JGozMCRsMCRoMA..#Syncfusion_Blazor_Grids_GridColumn_Template) property that allows rendering custom elements in a column instead of the default field value. [🔗](https://blazor.syncfusion.com/documentation/datagrid/column-template)


```csharp
@code {
    private CustomAdaptor? _customAdaptor;

    protected override void OnInitialized()
    {
        // Initialize the CustomAdaptor with the injected SubscriptionRepository
        _customAdaptor = new CustomAdaptor { SubscriptionService = SubscriptionService };
    }


    /// <summary>
    /// CustomAdaptor class to handle grid data operations with MariaDB using Entity Framework
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        public static SubscriptionRepository? _subscriptionService { get; set; }
        public SubscriptionRepository? SubscriptionService 
        { 
            get => _subscriptionService;
            set => _subscriptionService = value;
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
        {
            IEnumerable dataSource = await _subscriptionService!.GetSubscriptionsAsync();

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

            int totalRecordsCount = dataSource.Cast<SubscriptionModel>().Count();

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

            // Handling Group operation in CustomAdaptor.
            if (dataManagerRequest.Group != null)
            {
                foreach (var group in dataManagerRequest.Group)
                {
                    dataSource = DataUtil.Group<SubscriptionModel>(dataSource, group, dataManagerRequest.Aggregates, 0, dataManagerRequest.GroupByFormatter);
                    //Add custom logic here if needed and remove above method
                }
            }

            return dataManagerRequest.RequiresCounts 
                ? new DataResult() { Result = dataSource, Count = totalRecordsCount } 
                : (object)dataSource;
        }

        public override async Task<object> InsertAsync(DataManager dataManager, object value, string? key)
        {
            await _subscriptionService!.AddSubscriptionAsync(value as SubscriptionModel);
            return value;
        }

        public override async Task<object> UpdateAsync(DataManager dataManager, object value, string? keyField, string key)
        {
            await _subscriptionService!.UpdateSubscriptionAsync(value as SubscriptionModel);
            return value;
        }

        public override async Task<object> RemoveAsync(DataManager dataManager, object value, string? keyField, string key)
        {
            await _subscriptionService!.RemoveSubscriptionAsync(value as int?);
            return value;
        }

        public override async Task<object> BatchUpdateAsync(DataManager dataManager, object changedRecords, object addedRecords, object deletedRecords, string? keyField, string key, int? dropIndex)
        {
            if (changedRecords != null)
            {
                foreach (var record in (IEnumerable<SubscriptionModel>)changedRecords)
                {
                    await _subscriptionService!.UpdateSubscriptionAsync(record as SubscriptionModel);
                }
            }
            if (addedRecords != null)
            {
                foreach (var record in (IEnumerable<SubscriptionModel>)addedRecords)
                {
                    await _subscriptionService!.AddSubscriptionAsync(record as SubscriptionModel);
                }
            }
            if (deletedRecords != null)
            {
                foreach (var record in (IEnumerable<SubscriptionModel>)deletedRecords)
                {
                    await _subscriptionService!.RemoveSubscriptionAsync((record as SubscriptionModel).Id);
                }
            }
            return key;
        }
    }

    /// <summary>
    /// Provides a list of payment gateway options used as a data source for the Gateway dropdown editor in the grid.
    /// </summary>
    private static List<SubscriptionModel> CustomGateway = new List<SubscriptionModel> {
        new SubscriptionModel() { PaymentGateway = "Provider1" },
        new SubscriptionModel() { PaymentGateway= "Provider2" },
        new SubscriptionModel() { PaymentGateway= "Provider3" },
        new SubscriptionModel() { PaymentGateway= "Provider4" },
        new SubscriptionModel() { PaymentGateway= "Provider5" },
    };

    /// <summary>
    /// Provides a list of subscription types used as a data source for the Type dropdown editor in the grid.
    /// </summary>
    private static List<SubscriptionModel> CustomType = new List<SubscriptionModel> {
        new SubscriptionModel() { SubscriptionType = "ACTIVE" },
        new SubscriptionModel() { SubscriptionType = "PAUSED" },
        new SubscriptionModel() { SubscriptionType = "EXPIRED" },
        new SubscriptionModel() { SubscriptionType = "CANCELLED" },
    };

    /// <summary>
    /// Provides a list of subscription statuses used as a data source for the Status dropdown editor in the grid.
    /// </summary>
    private static List<SubscriptionModel> CustomStatus = new List<SubscriptionModel> {
        new SubscriptionModel() { Status = "SUCCESS" },
        new SubscriptionModel() { Status = "PROCESSING" },
        new SubscriptionModel() { Status = "PENDING" },
        new SubscriptionModel() { Status = "FAILED" },
    };

    /// <summary>
    /// Dropdown editor settings configured with payment gateway options for the PaymentGateway column in grid edit mode.
    /// </summary>
    private IEditorSettings GatewayDropDownParams = new DropDownEditCellParams
    {
        Params = new DropDownListModel<object, object>() { DataSource = CustomGateway, Query = new Syncfusion.Blazor.Data.Query() },
    };

    /// <summary>
    /// Dropdown editor settings configured with subscription type options for the SubscriptionType column in grid edit mode.
    /// </summary>
    private IEditorSettings TypeDropDownParams = new DropDownEditCellParams
    {
        Params = new DropDownListModel<object, object>() { DataSource = CustomType, Query = new Syncfusion.Blazor.Data.Query() },
    };

    /// <summary>
    /// Dropdown editor settings configured with subscription status options for the Status column in grid edit mode.
    /// </summary>
    private IEditorSettings StatusDropDownParams = new DropDownEditCellParams
    {
        Params = new DropDownListModel<object, object>() { DataSource = CustomStatus, Query = new Syncfusion.Blazor.Data.Query() },
    };

    /// <summary>
    /// Returns a CSS class name based on the subscription type to apply visual styling in the grid template.
    /// </summary>
    private string GetCategoryClass(SubscriptionModel data)
    {
        return data.SubscriptionType?.ToLower() switch
        {
            "active" => "category-active",
            "paused" => "category-paused",
            "expired" => "category-expired",
            "cancelled" => "category-cancelled",
            _ => ""
        };
    }
}
```
---

## Complete Sample Repository

A complete, working sample implementation is available in the [GitHub repository](https://github.com/SyncfusionExamples/connecting-databases-to-blazor-datagrid-component/tree/master/Binding%20MariaDB%20using%20CustomAdaptor).

---

## Summary

This guide demonstrates how to:
1. Create a MariaDB database with subscription records. [🔗](#step-1-create-the-database-and-table-in-mariadb-server)
2. Install necessary NuGet packages for Entity Framework Core and Syncfusion. [🔗](#step-2-install-required-nuget-packages)
3. Create data models and DbContext for database communication. [🔗](#step-3-create-the-data-model)
4. Configure connection strings and register services. [🔗](#step-5-configure-the-connection-string)
5. Implement the repository pattern for data access. [🔗](#step-6-create-the-repository-class)
6. Create a Blazor component with a DataGrid that supports searching, filtering, sorting, paging, and CRUD operations. [🔗](#step-1-install-and-configure-syncfusion-blazor-grid-components)
7. Handle bulk operations and batch updates. [🔗](#step-11-perform-crud-operations)

The application now provides a complete solution for managing subscription data with a modern, user-friendly interface.