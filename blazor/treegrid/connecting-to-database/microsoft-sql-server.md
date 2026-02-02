---
layout: post
title: Blazor TreeGrid connected to SQL via Entity Framework | Syncfusion
description: Bind SQL Server data to Blazor TreeGrid using Entity Framework Core with complete CRUD, filtering, sorting, paging, and advanced data operations.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Connecting SQL Server to Blazor TreeGrid Using Entity Framework

The [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid](https://www.syncfusion.com/blazor-components/blazor-tree-grid) supports binding data from a SQL Server database using Entity Framework Core (EF Core). This modern approach provides a more maintainable and type-safe alternative to raw SQL queries.

**What is Entity Framework Core?**

Entity Framework Core (EF Core) is a software tool that simplifies database operations in .NET applications. It serves as a bridge between C# code and databases like SQL Server.

**Key Benefits of Entity Framework Core**

- **Automatic SQL Generation**: Entity Framework Core generates optimized SQL queries automatically, eliminating the need to write raw SQL code.
- **Type Safety**: Work with strongly-typed objects instead of raw SQL strings, reducing errors.
- **Built-in Security**: Automatic parameterization prevents SQL injection attacks.
- **Version Control for Databases**: Manage database schema changes version-by-version through migrations.
- **Familiar Syntax**: Use LINQ (Language Integrated Query) syntax, which is more intuitive than raw SQL strings.

**What is Entity Framework Core SQL Server Provider?**

The **Microsoft.EntityFrameworkCore.SqlServer** package is the official Entity Framework Core provider for SQL Server. It acts as a bridge between Entity Framework Core and SQL Server, allowing applications to read, write, update, and delete data in a SQL Server database.

## Prerequisites

Ensure the following software and packages are installed before proceeding:

| Software/Package | Version | Purpose |
|-----------------|---------|---------|
| Visual Studio 2022 | 17.0 or later | Development IDE with Blazor workload |
| .NET SDK | net8.0 or compatible | Runtime and build tools |
| SQL Server | 2019 or later | Database server |
| Syncfusion.Blazor.TreeGrid | {{site.blazorversion}} | TreeGrid and UI components |
| Syncfusion.Blazor.Themes | {{site.blazorversion}} | Styling for TreeGrid components |
| Microsoft.EntityFrameworkCore | 9.0.0 or later | Core framework for database operations |
| Microsoft.EntityFrameworkCore.Tools | 9.0.0 or later | Tools for managing database migrations |
| Microsoft.EntityFrameworkCore.SqlServer | 9.0.0 or later | SQL Server provider for Entity Framework Core |

## Setting Up the SQL Server Environment for Entity Framework Core

### Step 1: Create the database and Table in SQL Server

First, the **SQL Server database** structure must be created to store ticket records.

**Instructions:**
1. Open SQL Server Management Studio (SSMS) or any SQL Server client.
2. Create a new database named `NetworkSupportDB`.
3. Define a `Support_Ticket` table with the specified schema.
4. Insert sample data for testing.

Run the following SQL script:

```sql
-- Create Database
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'NetworkSupportDB')
BEGIN
    CREATE DATABASE NetworkSupportDB;
END
GO

USE NetworkSupportDB;
GO

-- Create table (MS SQL)
CREATE TABLE dbo.Support_Ticket (
    TicketID INT IDENTITY(1,1) PRIMARY KEY,
    Title VARCHAR(255) NOT NULL,
    ParentTicketID INT NULL,
    Category VARCHAR(100) NULL,
    Priority VARCHAR(50) NULL,
    Status VARCHAR(50) NULL,
    Assignee VARCHAR(100) NULL,
    CustomerName VARCHAR(200) NULL,
    CreatedAt DATETIME NULL,
    DueDate DATETIME NULL,
    EstimatedHours DECIMAL(6,2) NULL,
    Description NVARCHAR(MAX) NULL,
    HasChildren BIT NOT NULL DEFAULT(0)
);
GO

-- Insert sample rows (uses DATEADD/GETDATE to simulate offsets)
INSERT INTO dbo.Support_Ticket
(TicketID, Title, ParentTicketID, Category, Priority, Status, Assignee, CustomerName, CreatedAt, DueDate, EstimatedHours, Description, HasChildren)
VALUES
(57301, 'Server Infrastructure Issues', NULL, 'Technical', 'High', 'In Progress', 'Alex Rivera', 'Zorath Industries', DATEADD(day, -15, GETDATE()), DATEADD(hour, -1, GETDATE()), 16.00, 'Server Infrastructure Issues', 1),
(57302, 'Email Service Down', 57301, 'Technical', 'Critical', 'Open', 'Alex Rivera', 'Zorath Industries', DATEADD(day, -12, GETDATE()), DATEADD(hour, 2, GETDATE()), 4.00, 'The email service has stopped functioning, impacting communication across the organization.', 0),
(57303, 'Database Connection Issues', 57301, 'Technical', 'High', 'In Progress', 'Jordan Lee', 'Zorath Industries', DATEADD(day, -11, GETDATE()), DATEADD(hour, 6, GETDATE()), 8.00, 'Users experiencing intermittent errors when connecting to the primary database server.', 0),
(57304, 'Load Balancer Configuration', 57301, 'Technical', 'Medium', 'Resolved', 'Alex Rivera', 'Zorath Industries', DATEADD(day, -10, GETDATE()), DATEADD(day, 1, GETDATE()), 6.00, 'Misconfigured load balancer causing uneven distribution of incoming traffic.', 0),
(57305, 'DNS Resolution Problems', 57301, 'Technical', 'High', 'Open', 'Casey Kim', 'Zorath Industries', DATEADD(day, -9, GETDATE()), DATEADD(day, 1, GETDATE()), 5.00, 'DNS servers failing to resolve domain names, resulting in website access issues.', 0),
(57306, 'CDN Performance Issues', 57301, 'Technical', 'Medium', 'In Progress', 'Taylor Morgan', 'Zorath Industries', DATEADD(day, -8, GETDATE()), DATEADD(day, 2, GETDATE()), 10.00, 'Increased latency in the content delivery network, slowing down page load times.', 0),
(57307, 'Application Bug Reports', NULL, 'Software', 'Medium', 'Open', 'Casey Kim', 'Keldrix Systems', DATEADD(day, -14, GETDATE()), DATEADD(day, 1, GETDATE()), 12.00, 'Application Bug Reports', 1),
(57308, 'Login Authentication Error', 57307, 'Software', 'High', 'Escalated', 'Casey Kim', 'Keldrix Systems', DATEADD(day, -13, GETDATE()), DATEADD(hour, 4, GETDATE()), 6.00, 'Users unable to authenticate due to token mismatch during login process.', 0),
(57309, 'Data Export Functionality', 57307, 'Software', 'Low', 'Open', 'Taylor Morgan', 'Keldrix Systems', DATEADD(day, -12, GETDATE()), DATEADD(day, 3, GETDATE()), 4.00, 'Export feature failing to generate accurate CSV files with all data.', 0),
(57310, 'UI Rendering Issues', 57307, 'Software', 'Medium', 'In Progress', 'Casey Kim', 'Keldrix Systems', DATEADD(day, -11, GETDATE()), DATEADD(day, 2, GETDATE()), 8.00, 'UI elements not rendering correctly on the latest browser versions.', 0),
(57311, 'API Integration Problems', 57307, 'Software', 'Critical', 'Open', 'Riley Patel', 'Keldrix Systems', DATEADD(day, -10, GETDATE()), DATEADD(hour, 12, GETDATE()), 15.00, 'External API calls returning internal server errors (500).', 0),
(57312, 'File Upload Memory Leak', 57307, 'Software', 'High', 'In Progress', 'Jordan Lee', 'Keldrix Systems', DATEADD(day, -9, GETDATE()), DATEADD(day, 1, GETDATE()), 12.00, 'Memory usage spikes after multiple file uploads, leading to crashes.', 0),
(57313, 'Session Timeout Bug', 57307, 'Software', 'Medium', 'Resolved', 'Taylor Morgan', 'Keldrix Systems', DATEADD(day, -8, GETDATE()), DATEADD(day, 3, GETDATE()), 7.00, 'User sessions expiring too early, causing unexpected logouts.', 0),
(57314, 'Network Connectivity Problems', NULL, 'Network', 'Medium', 'Open', 'Riley Patel', 'Quorvex Networks', DATEADD(day, -13, GETDATE()), DATEADD(day, 1, GETDATE()), 8.00, 'Network Connectivity Problems', 1),
(57315, 'VPN Connection Timeout', 57314, 'Network', 'Medium', 'In Progress', 'Riley Patel', 'Quorvex Networks', DATEADD(day, -12, GETDATE()), DATEADD(hour, 8, GETDATE()), 3.00, 'VPN sessions dropping after short periods of inactivity.', 0);
GO

```

After executing this script, the ticket records are stored in the `Support_Ticket` table within the `NetworkSupportDB` database. The database is now ready for integration with the Blazor application.

---

### Step 2: Install Required NuGet Packages

Before installing the necessary NuGet packages, a new Blazor Web Application must be created using the default template.
This template automatically generates essential starter files—such as **Program.cs, appsettings.json, the wwwroot folder, and the Components folder**.

For this guide, a Blazor application named **TreeGrid_MSSQL** has been created. Once the project is set up, the next step involves installing the required NuGet packages. NuGet packages are software libraries that add functionality to the application. These packages enable Entity Framework Core and SQL Server integration.

**Method 1: Using Package Manager Console**

1. Open Visual Studio 2022.
2. Navigate to **Tools → NuGet Package Manager → Package Manager Console**.
3. Run the following commands:

```powershell
Install-Package Microsoft.EntityFrameworkCore -Version 9.0.0; 
Install-Package Microsoft.EntityFrameworkCore.Tools -Version 9.0.0; 
Install-Package Microsoft.EntityFrameworkCore.SqlServer -Version 9.0.0; 
Install-Package Syncfusion.Blazor.TreeGrid -Version {{site.blazorversion}}; 
Install-Package Syncfusion.Blazor.Themes -Version {{site.blazorversion}}
```

**Method 2: Using NuGet Package Manager UI**

1. Open **Visual Studio 2022 → Tools → NuGet Package Manager → Manage NuGet Packages for Solution**.
2. Search for and install each package individually:
   - **Microsoft.EntityFrameworkCore** (version 9.0.0 or later)
   - **Microsoft.EntityFrameworkCore.Tools** (version 9.0.0 or later)
   - **Microsoft.EntityFrameworkCore.SqlServer** (version 9.0.0 or later)
   - **Syncfusion.Blazor.TreeGrid** (version {{site.blazorversion}})
   - **Syncfusion.Blazor.Themes** (version {{site.blazorversion}})

All required packages are now installed.

### Step 3: Create the Data Model

A data model is a C# class that represents the structure of a database table. This model defines the properties that correspond to the columns in the `Tickets` table.

**Instructions:**

1. Create a new folder named `Data` in the Blazor application project.
2. Inside the `Data` folder, create a new file named **Tickets.cs**.
3. Define the **Tickets** class with the following code:

```csharp
using System.ComponentModel.DataAnnotations;

namespace TreeGrid_MSSQL.Data
{

    /// <summary>
    /// Represents a ticket record mapped to the 'Tickets' table in the database.
    /// This model defines the structure of ticket-related data used throughout the application.
    /// </summary>
    public class Tickets
    {
        /// <summary>
        /// Gets or sets the unique identifier for the ticket record.
        /// </summary>
        [Key]
        public int TicketID { get; set; }

        /// <summary>
        /// Gets or sets the public-facing ticket identifier (e.g., NET-1001).
        /// </summary>
        public int? ParentTicketID { get; set; }

        /// <summary>
        /// Gets or sets the ticket title or subject.
        /// </summary>
        public string? Title { get; set; }

        /// <summary>
        /// Gets or sets a detailed description of the ticket.
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Gets or sets the category of the issue (e.g., Network, Hardware, Software).
        /// </summary>
        public string? Category { get; set; }

        /// <summary>
        /// Gets or sets the name of the agent assigned to the ticket.
        /// </summary>
        public string? Assignee { get; set; }

        /// <summary>
        /// Gets or sets the current status of the ticket (e.g., Open, In Progress, Resolved, Closed).
        /// </summary>
        public string? Status { get; set; }

        /// <summary>
        /// Gets or sets the priority level of the ticket (e.g., Critical, High, Medium, Low).
        /// </summary>
        public string? Priority { get; set; }

        /// <summary>
        /// Gets or sets the deadline for resolving the ticket.
        /// </summary>
        public DateTime? DueDate { get; set; }

        /// <summary>
        /// Gets or sets the timestamp indicating when the ticket was created.
        /// </summary>
        public DateTime? CreatedAt { get; set; }

        /// <summary>
        /// Gets or sets the Customer name when the ticket was created.
        /// </summary>
        public String? CustomerName { get; set; }

        /// <summary>
        /// Gets or sets the EstimatedHours indicating when the ticket was created.
        /// </summary>
        public decimal? EstimatedHours { get; set; } = 0;

        /// <summary>
        /// Gets or sets the HasChildren as true or false when the ticket was created.
        /// </summary>
        public bool HasChildren { get; set; }

    }
}
```

**Explanation:**
- The `[Key]` attribute marks the `TicketID` property as the primary key (a unique identifier for each record).
- Each property represents a column in the database table.
- The `?` symbol indicates that a property is nullable (can be empty).
- The model includes comprehensive XML documentation for each property.

The data model has been successfully created.

### Step 4: Configure the DbContext

A `DbContext` is a special class that manages the connection between the application and the SQL Server database. It handles all database operations such as saving, updating, deleting, and retrieving data.

**Instructions:**

1. Inside the `Data` folder, create a new file named **TicketsDbContext.cs**.
2. Define the `TicketsDbContext` class with the following code:

```csharp
using Microsoft.EntityFrameworkCore;

namespace TreeGrid_MSSQL.Data
{
    /// <summary>
    /// DbContext for Tickets entity
    /// Manages database connections and entity configurations for the Network Support Ticket System
    /// </summary>
    public class TicketsDbContext : DbContext
    {
        public TicketsDbContext(DbContextOptions<TicketsDbContext> options)
            : base(options)
        {
        }

        /// <summary>
        /// DbSet for Ticket entities
        /// </summary>
        public DbSet<Tickets> Tickets => Set<Tickets>();

        /// <summary>
        /// Configures the entity mappings and constraints
        /// </summary>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configure Tickets entity
            modelBuilder.Entity<Tickets>(entity =>
            {
                // Primary Key
                entity.HasKey(e => e.TicketID);

                // Auto-increment for Primary Key
                entity.Property(e => e.TicketID)
                    .ValueGeneratedOnAdd();

                // Column configurations

                entity.Property(e => e.Title)
                    .HasMaxLength(200)
                    .IsRequired(false);

                entity.Property(e => e.Description)
                    .HasColumnType("nvarchar(max)")
                    .IsRequired(false);

                entity.Property(e => e.Category)
                    .HasMaxLength(100)
                    .IsRequired(false);

                entity.Property(e => e.Assignee)
                    .HasMaxLength(100)
                    .IsRequired(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsRequired(false)
                    .HasDefaultValue("Open");

                entity.Property(e => e.Priority)
                    .HasMaxLength(50)
                    .IsRequired(false)
                    .HasDefaultValue("Medium");

                entity.Property(e => e.DueDate)
                    .HasColumnType("datetime2")
                    .IsRequired(false);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime2")
                    .IsRequired(false)
                    .HasDefaultValueSql("GETDATE()");

                // Add indexes for frequently queried columns
                entity.HasIndex(e => e.ParentTicketID)
                    .HasDatabaseName("IX_ParentTicketID");

                entity.HasIndex(e => e.Status)
                    .HasDatabaseName("IX_Status");

                entity.HasIndex(e => e.CreatedAt)
                    .HasDatabaseName("IX_CreatedAt");

                // Table name and schema
                entity.ToTable("Support_Ticket", schema: "dbo");
            });
        }
    }
}
```

**Explanation:**
- The `DbContext` class inherits from Entity Framework's `DbContext` base class.
- The `Tickets` property represents the `Tickets` table in the database.
- The `OnModelCreating` method configures how the database columns should behave (maximum length, required/optional, default values, data types, indexes, etc.).
- SQL Server-specific configurations include `datetime2` for timestamp columns and `GETDATE()` for default values.
- Database indexes are configured for improved query performance on frequently accessed columns.

The **TicketsDbContext** class is required because:

- It **connects** the application to the database.
- It **manages** all database operations.
- It **maps** C# models to actual database tables.
- It **configures** how data should look inside the database.
- It **enables** SQL Server-specific features like indexes and default value functions.

Without this class, Entity Framework Core will not know where to save data or how to create the Tickets table. The DbContext has been successfully configured.

### Step 5: Configure the Connection String

A connection string contains the information needed to connect the application to the SQL Server database, including the server address, database name, and authentication credentials.

**Instructions:**

1. Open the `appsettings.json` file in the project root.
2. Add or update the `ConnectionStrings` section with the SQL Server connection details:

```json
{
    "ConnectionStrings": {
    "DefaultConnection": "Data Source=SYNCLAPN-41983;Initial Catalog=NetworkSupportDB;Integrated Security=True;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False"
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
| Data Source | The address of the SQL Server instance (server name, IP address, or localhost) |
| Initial Catalog | The database name (in this case, `NetworkSupportDB`) |
| Integrated Security | Set to `True` for Windows Authentication; use `False` with Username/Password for SQL Authentication |
| Connect Timeout | Connection timeout in seconds (default is 15) |
| Encrypt | Enables encryption for the connection (set to `True` for production environments) |
| Trust Server Certificate | Whether to trust the server certificate (set to `False` for security) |
| Application Intent | Set to `ReadWrite` for normal operations or `ReadOnly` for read-only scenarios |
| Multi Subnet Failover | Used in failover clustering scenarios (typically `False`) |

The database connection string has been configured successfully.

### Step 6: Create the Repository Class

A repository class is an intermediary layer that handles all database operations. This class uses Entity Framework Core to communicate with the database.

**Instructions:**

1. Inside the `Data` folder, create a new file named **TicketRepository.cs**.
2. Define the **TicketRepository** class with the following code:

```csharp
using Microsoft.EntityFrameworkCore;

namespace TreeGrid_MSSQL.Data
{
    /// <summary>
    /// Repository pattern implementation for Tickets entity using Entity Framework Core
    /// Handles all CRUD operations and business logic for network support tickets
    /// </summary>
    public class TicketRepository
    {
        private readonly TicketsDbContext _context;

        public TicketRepository(TicketsDbContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Retrieves all tickets from the database ordered by ID descending
        /// </summary>
        /// <returns>List of all tickets</returns>
        public async Task<List<Tickets>> GetTicketsDataAsync()
        {
            try
            {
                return await _context.Tickets.ToListAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving tickets: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Adds a new ticket to the database
        /// </summary>
        /// <param name="value">The ticket model to add</param>
        public async Task AddTicketAsync(Tickets value)
        {
            // Handle logic to add a new ticket to the database
        }

        /// <summary>
        /// Updates an existing ticket
        /// </summary>
        /// <param name="value">The ticket model with updated values</param>
        public async Task UpdateTicketAsync(Tickets value)
        {
            // Handle logic to update an existing ticket to the database
        }

        /// <summary>
        /// Deletes a ticket from the database
        /// </summary>
        /// <param name="key">The ticket ID to delete</param>
        public async Task RemoveTicketAsync(int? key)
        {
            // Handle logic to delete an existing ticket to the database
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
using Syncfusion.Blazor;
using TreeGrid_MSSQL.Components;
using TreeGrid_MSSQL.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSyncfusionBlazor();

// ========== ENTITY FRAMEWORK CORE CONFIGURATION ==========
// Get connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found in configuration.");
}

// Register DbContext with SQL Server provider
builder.Services.AddDbContext<TicketsDbContext>(options =>
{
    options.UseSqlServer(connectionString);

    // Enable detailed error messages in development
    if (builder.Environment.IsDevelopment())
    {
        options.EnableSensitiveDataLogging();
    }
});

// Register Repository for dependency injection
builder.Services.AddScoped<TicketRepository>();
// ========================================================

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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

- **`AddDbContext<TicketsDbContext>`**: Registers the DbContext with SQL Server as the database provider using `UseSqlServer()`.
- **`EnableSensitiveDataLogging()`**: Enabled in development to log detailed information about database operations (useful for debugging).
- **`AddScoped<TicketRepository>`**: Registers the repository as a scoped service, creating a new instance for each HTTP request.
- **`AddSyncfusionBlazor()`**: Registers Syncfusion Blazor components.
- **`AddRazorComponents()` and `AddInteractiveServerComponents()`**: Enables Blazor server-side rendering with interactive components.

The service registration has been completed successfully.

---

## Integrating Syncfusion Blazor TreeGrid

### Step 1: Install and Configure Blazor TreeGrid Components

Syncfusion is a library that provides pre-built UI components like TreeGrid, which is used to display data in a table format.

**Instructions:**

1. The Syncfusion.Blazor.TreeGrid package was installed in **Step 2** of the previous heading.
2. Import the required namespaces in the `Components/_Imports.razor` file:

```csharp
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Data
```

3. Add the Syncfusion stylesheet and scripts in the `Components/App.razor` file. Find the `<head>` section and add:

```html
<!-- Syncfusion Blazor Stylesheet -->
<link href="_content/Syncfusion.Blazor.Themes/styles/tailwind3.css" rel="stylesheet" />

<!-- Syncfusion Blazor Scripts -->
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
```

Syncfusion components are now configured and ready to use. For additional guidance, refer to the TreeGrid component's [getting‑started](https://blazor.syncfusion.com/documentation/treegrid/getting-started-webapp) documentation.

### Step 2: Update the Blazor TreeGrid in the Home Component

The Home component will display the ticket data in a Syncfusion Blazor TreeGrid with search, filter, sort, and pagination capabilities.

**Instructions:**

1. Open the file named `Home.razor` in the `Components/Pages` folder.
2. Add the following code to create a basic TreeGrid:

```html
@page "/"
@rendermode InteractiveServer
@inject TicketRepository TicketService

<PageTitle>Network Support Ticket System</PageTitle>

<section class="bg-gray-50 dark:bg-gray-950">
    <div class="mx-auto w-full py-12 sm:px-6 px-4">
        <h1 class="mb-4 text-3xl font-bold">Network Support Ticket System</h1>
        <p class="mb-3 text-gray-600">Manage and view all support tickets from the database.</p>
        <!-- Syncfusion Blazor TreeGrid Component -->
        <SfTreeGrid TValue="Tickets" Width="100%" Height="500px" AllowSorting="true" AllowFiltering="true" AllowPaging="true" ParentIdMapping="ParentTicketID" IdMapping="TicketID" HasChildMapping="HasChildren">
            <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>

            <TreeGridColumns>
                <!-- Columns configuration -->
            </TreeGridColumns>

            <TreeGridPageSettings PageSize="2"></TreeGridPageSettings>
        </SfTreeGrid>
    </div>
</section>
@code {
    // CustomAdaptor class will be added in the next step
}
```

**Component Explanation:**

- **`@rendermode InteractiveServer`**: Enables interactive server-side rendering for the component.
- **`@inject TicketRepository`**: Injects the repository to access database methods.
- **`<SfTreeGrid>`**: The TreeGrid component that displays data in rows and columns.
- **`<TreeGridColumns>`**: Defines individual columns in the TreeGrid.
- **`<TreeGridPageSettings>`**: Configures pagination with 2 root parent records per page.

The Home component has been updated successfully with TreeGrid.

---

### Step 3: Implement the CustomAdaptor

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid can bind data from a **SQL Server** database using [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) and set the [Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Adaptors.html) property to [CustomAdaptor](https://blazor.syncfusion.com/documentation/treegrid/custom-binding#inject-service-into-custom-adaptor) for scenarios that require full control over data operations.

The `CustomAdaptor` is a bridge between the TreeGrid and the database. It handles all data operations including reading, searching, filtering, sorting, paging, and CRUD operations. Each operation in the CustomAdaptor's `ReadAsync` method handles specific TreeGrid functionality. The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid sends operation details to the API through a [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html) object. These details can be applied to the data source using methods from the [DataOperations](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html) class.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Add the following `CustomAdaptor` class code inside the `@code` block:

```csharp
@code {

    private CustomAdaptor? _customAdaptor;

    protected override void OnInitialized()
    {
        // Initialize the CustomAdaptor with the injected TicketRepository
        _customAdaptor = new CustomAdaptor { TicketService = TicketService };
    }

    /// <summary>
    /// CustomAdaptor class bridges TreeGrid interactions with database operations.
    /// This adaptor handles all data retrieval and manipulation for the TreeGrid.
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        public static TicketRepository? _ticketService { get; set; }

        public TicketRepository? TicketService
        {
            get => _ticketService;
            set => _ticketService = value;
        }

        /// <summary>
        /// ReadAsync retrieves records from the database and applies data operations.
        /// This method executes when the TreeGrid initializes and when filtering, searching, sorting, or paging occurs.
        /// </summary>
        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
        {
            try
            {
                // Fetch all tickets from the database
                IEnumerable<Tickets> dataSource = await _ticketService!.GetTicketsDataAsync();

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
                int totalRecordsCount = dataSource.Cast<Tickets>().Count();

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

                // Handling Aggregates
                IDictionary<string, object>? aggregates = null;
                if (dataManagerRequest.Aggregates != null)
                {
                    aggregates = DataUtil.PerformAggregation(dataSource, dataManagerRequest.Aggregates);
                }

                // Return the result with total count for pagination metadata
                return dataManagerRequest.RequiresCounts ? new DataResult() { Result = dataSource, Count = totalRecordsCount, Aggregates = aggregates } : (object)dataSource;
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
2. Update the `<SfTreeGrid>` component to include the [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_Toolbar) property with CRUD and search options:

```html
<SfTreeGrid TValue="Tickets" Width="100%" Height="500px" AllowSorting="true"   AllowFiltering="true" AllowPaging="true" ParentIdMapping="ParentTicketID" IdMapping="TicketID" HasChildMapping="HasChildren"
        Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    
    <!-- TreeGrid columns configuration -->
</SfTreeGrid>
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
| `Add` | Opens a form to add a new ticket record. |
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

1. The paging feature is already partially enabled in the `<SfTreeGrid>` component with [AllowPaging="true"](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_AllowPaging).
2. The page size is configured with [<TreeGridPageSettings>](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridPageSettings.html).
3. No additional code changes are required from the previous steps.

```html
<SfTreeGrid TValue="Tickets" AllowPaging="true" ParentIdMapping="ParentTicketID" IdMapping="TicketID" HasChildMapping="HasChildren">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <TreeGridPageSettings PageSize="2"></TreeGridPageSettings>
    
    <!-- TreeGrid columns configuration -->
</SfTreeGrid>
```

4. Update the `ReadAsync` method in the `CustomAdaptor` class to handle paging:

```csharp
@code {
    /// <summary>
    /// CustomAdaptor class to handle TreeGrid data operations with SQL Server using Entity Framework
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        public static TicketRepository? _ticketService { get; set; }
        public TicketRepository? TicketService
        {
            get => _ticketService;
            set => _ticketService = value;
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
        {
            IEnumerable<Tickets> dataSource = await _ticketService!.GetTicketsDataAsync();

            int totalRecordsCount = dataSource.Cast<Tickets>().Count();
            
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

Fetches ticket data by calling the **GetTicketsDataAsync** method, which is implemented in the **TicketRepository.cs** file.

```csharp
/// <summary>
/// Retrieves all tickets from the database ordered by ID descending
/// </summary>
/// <returns>List of all tickets</returns>
public async Task<List<Tickets>> GetTicketsDataAsync()
{
    try
    {
        return await _context.Tickets.ToListAsync();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error retrieving tickets: {ex.Message}");
        throw;
    }
}
```

**How Paging Works:**

- The TreeGrid displays 2 root parent records per page (as set in `TreeGridPageSettings`).
- Navigation buttons allow the user to move between pages.
- When a page is requested, the `ReadAsync` method receives skip and take values.
- The `DataOperations.PerformSkip()` and `DataOperations.PerformTake()` methods handle pagination.
- Only the requested page of records is transmitted from the server.

Paging feature is now active with 2 root parent records per page.

---

### Step 6: Implement Searching feature

Searching allows the user to find records by entering keywords in the search box.

**Instructions:**

1. Ensure the toolbar includes the "Search" item.

```html
<SfTreeGrid TValue="Tickets"  AllowPaging="true" ParentIdMapping="ParentTicketID" IdMapping="TicketID" HasChildMapping="HasChildren"
        Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <!-- TreeGrid columns configuration -->
</SfTreeGrid>
```

2. Update the `ReadAsync` method in the `CustomAdaptor` class to handle searching:

```csharp
@code {
    private List<string> ToolbarItems = new List<string> { "Search"};
    
    /// <summary>
    /// CustomAdaptor class to handle treegrid data operations with SQL using Entity Framework
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        public static TicketRepository? _ticketService { get; set; }
        public TicketRepository? TicketService { get => _ticketService; set => _ticketService = value; }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
        {
            IEnumerable<Tickets> dataSource = await _ticketService!.GetTicketsDataAsync();

            // Handling Search
            if (dataManagerRequest.Search != null && dataManagerRequest.Search.Count > 0)
            {
                dataSource = DataOperations.PerformSearching(dataSource, dataManagerRequest.Search);
            }

            int totalRecordsCount = dataSource.Cast<Tickets>().Count();
            
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

- When the user enters text in the search box and presses Enter, the TreeGrid sends a search request to the CustomAdaptor.
- The `ReadAsync` method receives the search criteria in `dataManagerRequest.Search`.
- The `DataOperations.PerformSearching()` method filters the data based on the search term across all columns.
- Results are returned and displayed in the TreeGrid.

Searching feature is now active.

---

### Step 7: Implement Filtering feature

Filtering allows the user to restrict data based on column values using a menu interface.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Add the [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_AllowFiltering) property and [TreeGridFilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridFilterSettings.html) to the `<SfTreeGrid>` component:

```html
<SfTreeGrid TValue="Tickets" Width="100%" Height="500px"  AllowFiltering="true" AllowPaging="true" ParentIdMapping="ParentTicketID" IdMapping="TicketID" HasChildMapping="HasChildren"
        Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    
    <TreeGridFilterSettings Type="Syncfusion.Blazor.TreeGrid.FilterType.Menu"></TreeGridFilterSettings>
    
    <!-- TreeGrid columns configuration -->
</SfTreeGrid>
```

3. Update the `ReadAsync` method in the `CustomAdaptor` class to handle filtering:

```csharp
@code {
    private List<string> ToolbarItems = new List<string> { "Search"};
    
    /// <summary>
    /// CustomAdaptor class to handle treegrid data operations with SQL using Entity Framework
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        public static TicketRepository? _ticketService { get; set; }
        public TicketRepository? TicketService { get => _ticketService; set => _ticketService = value; }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
        {
            IEnumerable<Tickets> dataSource = await _ticketService!.GetTicketsDataAsync();

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

            int totalRecordsCount = dataSource.Cast<Tickets>().Count();

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
- Results are filtered accordingly and displayed in the TreeGrid.

Filtering feature is now active.

---

### Step 8: Implement Sorting feature

Sorting enables the user to arrange records in ascending or descending order based on column values.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Add the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_AllowSorting) property to the `<SfTreeGrid>` component:

```html
<SfTreeGrid TValue="Tickets" Width="100%" Height="500px"  AllowSorting="true" AllowFiltering="true" AllowPaging="true" ParentIdMapping="ParentTicketID" IdMapping="TicketID" HasChildMapping="HasChildren"
        Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
 
     <TreeGridPageSettings PageSize="2"></TreeGridPageSettings>
     <TreeGridFilterSettings Type="Syncfusion.Blazor.TreeGrid.FilterType.Menu"></TreeGridFilterSettings>
    
    <!-- TreeGrid columns configuration -->
</TreeSfGrid>
```

3. Update the `ReadAsync` method in the `CustomAdaptor` class to handle sorting:

```csharp
@code {
    public class CustomAdaptor : DataAdaptor
    {
        public static TicketRepository? _ticketService { get; set; }
        public TicketRepository? TicketService { get => _ticketService; set => _ticketService = value; }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
        {
            IEnumerable<Tickets> dataSource = await _ticketService!.GetTicketsDataAsync();

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

            int totalRecordsCount = dataSource.Cast<Tickets>().Count();

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
- Records are sorted accordingly and displayed in the TreeGrid.

Sorting feature is now active.

---

### Step 09: Perform CRUD operations

CustomAdaptor methods enable users to create, read, update, and delete records directly from the TreeGrid. Each operation calls corresponding data layer methods in **TicketRepository.cs** to execute SQL Server commands.

Add the TreeGrid **EditSettings** and **Toolbar** configuration to enable create, read, update, and delete (CRUD) operations.

```html
<SfTreeGrid TValue="Tickets" Width="100%" Height="500px" AllowSorting="true" AllowFiltering="true" AllowPaging="true" ParentIdMapping="ParentTicketID" IdMapping="TicketID" HasChildMapping="HasChildren"
    Toolbar="@ToolbarItems">
    <TreeGridFilterSettings Type="Syncfusion.Blazor.TreeGrid.FilterType.Menu"></TreeGridFilterSettings>
    <TreeGridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="Syncfusion.Blazor.TreeGrid.EditMode.Batch"></TreeGridEditSettings>
    <TreeGridPageSettings PageSize="2"></TreeGridPageSettings>
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <!-- TreeGrid columns  -->
</SfTreeGrid>
```

Add the toolbar items list in the `@code` block:

```csharp
@code {
    private List<string> ToolbarItems = new List<string> { "Add", "Edit", "Delete", "Update", "Cancel", "Search"};

    // CustomAdaptor class code...
}
```

**Insert**

Record insertion allows new tickets to be added directly through the TreeGrid component. The adaptor processes the insertion request, performs any required business‑logic validation, and saves the newly created record to the SQL Server database.

In **Home.razor**, implement the `InsertAsync` method within the `CustomAdaptor` class:

```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> InsertAsync(DataManager dataManager, object value, string? key)
    {
        if (value is Tickets ticket)
        {
            await _ticketService!.AddTicketAsync(ticket);
        }
        return value;
    }
}
```

In **Data/TicketRepository.cs**, the insert method is implemented as:

```csharp
public async Task AddTicketAsync(Tickets value)
{
    try
    {
        // Handle logic to add a new ticket to the database
        if (value == null) throw new ArgumentNullException(nameof(value));


        int generatedPublicTicketId = await GeneratePublicTicketIdAsync();
        value.ParentTicketID = generatedPublicTicketId;

        // ensure CreatedDate if not set
        if (value.CreatedAt == default) value.CreatedAt = DateTime.UtcNow;

        _context.Tickets.Add(value);
        await _context.SaveChangesAsync();
    }

    catch (DbUpdateException ex)
    {
        Console.WriteLine($"Database error while adding ticket: {ex.Message}");
        throw;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error adding ticket: {ex.Message}");
        throw;
    }
}
```

**What happens behind the scenes:**

1. The form data is collected and validated in the CustomAdaptor's `InsertAsync()` method.
2. The `TicketRepository.AddTicketAsync()` method is called.
3. The new record is added to the `_context.Tickets` collection.
4. `SaveChangesAsync()` persists the record to the SQL Server database.
5. The TreeGrid automatically refreshes to display the new record.

Now the new ticket is persisted to the database and reflected in the TreeGrid.

**Update**

Record modification allows ticket details to be updated directly within the TreeGrid. The adaptor processes the edited row, validates the updated values, and applies the changes to the **SQL Server database** while ensuring data integrity is preserved.

In **Home.razor**, implement the `UpdateAsync` method within the `CustomAdaptor` class:

```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> UpdateAsync(DataManager DataManager, object value, string keyField, string key)
    {
        // Add your update logic here
        if (value is Tickets ticket)
        {
            await _ticketService!.UpdateTicketAsync(ticket);
        }
        return value;
    }
}
```

In **Data/TicketRepository.cs**, the update method is implemented as:

```csharp
public async Task UpdateTicketAsync(Tickets value)
{
    try {
        if (value == null) throw new ArgumentNullException(nameof(value));

        var existing = await _context.Tickets.FindAsync(value.TicketID);
        if (value.TicketID <= 0)
            throw new ArgumentException("Ticket ID must be valid", nameof(value.TicketID));
        if (existing == null) throw new KeyNotFoundException($"Ticket {value.TicketID} not found.");

        // update mutable fields (preserve CreatedDate and TicketID)
        existing.Title = value.Title;
        existing.ParentTicketID = value.ParentTicketID;
        existing.Category = value.Category;
        existing.Priority = value.Priority;
        existing.Status = value.Status;
        existing.Assignee = value.Assignee;
        existing.CustomerName = value.CustomerName;
        existing.DueDate = value.DueDate;
        existing.EstimatedHours = value.EstimatedHours;
        existing.Description = value.Description;

        _context.Tickets.Update(existing);
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException ex)
    {
        Console.WriteLine($"Concurrency error while updating ticket: {ex.Message}");
        throw;
    }
    catch (DbUpdateException ex)
    {
        Console.WriteLine($"Database error while updating ticket: {ex.Message}");
        throw;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error updating ticket: {ex.Message}");
        throw;
    }
}
```

**What happens behind the scenes:**

1. The modified data is collected from the form.
2. The CustomAdaptor's `UpdateAsync()` method is called.
3. The `TicketRepository.UpdateTicketAsync()` method is called.
4. The existing record is retrieved from the database by ID.
5. All properties are updated with the new values.
6. `SaveChangesAsync()` persists the changes to the SQL Server database.
7. The TreeGrid refreshes to display the updated record.

Now modifications are synchronized to the database and reflected in the TreeGrid UI.

**Delete**

Record deletion allows tickets to be removed directly from the TreeGrid. The adaptor captures the delete request, executes the corresponding **SQL Server DELETE** operation, and updates both the database and the TreeGrid to reflect the removal.

In **Home.razor**, implement the `RemoveAsync` method within the `CustomAdaptor` class:

```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> RemoveAsync(DataManager dataManager, object value, string? keyField, string key)
    {
        // This method will be invoked when deleting existing records from the Blazor TreeGrid component.
        int? recordId = null;
        if (value is int intValue)
        {
            recordId = intValue;
        }
        else if (value is Tickets ticket)
        {
            recordId = ticket.TicketID;
        }
        else if (int.TryParse(value?.ToString(), out int parsedValue))
        {
            recordId = parsedValue;
        }

        if (recordId.HasValue && recordId.Value > 0)
        {
            await _ticketService!.RemoveTicketAsync(recordId);
        }
        return value;
    }
}
```

In **Data/TicketRepository.cs**, the delete method is implemented as:

```csharp
public async Task RemoveTicketAsync(int? key)
{
    try
    {
        if (key == null || key <= 0)
            throw new ArgumentException("Ticket ID cannot be null or invalid", nameof(key));

        var ticket = await _context.Tickets.FindAsync(key);
        if (ticket == null) throw new KeyNotFoundException($"Ticket {key} not found.");

        var hasChildren = await _context.Tickets.AnyAsync(t => t.ParentTicketID == key);
        if (hasChildren)
            throw new InvalidOperationException("Cannot delete ticket that has child tickets. Delete or reassign children first.");

        _context.Tickets.Remove(ticket);
        await _context.SaveChangesAsync();
    }
    catch (DbUpdateException ex)
    {
        Console.WriteLine($"Database error while deleting ticket: {ex.Message}");
        throw;
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error deleting ticket: {ex.Message}");
        throw;
    }
}
```

**What happens behind the scenes:**

1. The user selects a record and clicks "Delete".
2. A confirmation dialog appears (built into the TreeGrid).
3. If confirmed, the CustomAdaptor's `RemoveAsync()` method is called.
4. The `TicketRepository.RemoveTicketAsync()` method is called.
5. The record is located in the database by its ID.
6. The record is removed from the `_context.Tickets` collection.
7. `SaveChangesAsync()` executes the DELETE statement in SQL Server.
8. The TreeGrid refreshes to remove the deleted record from the UI.

Now tickets are removed from the database and the TreeGrid UI reflects the changes immediately.

**Batch update**

Batch operations combine multiple insert, update, and delete actions into a single request, minimizing network overhead and ensuring transactional consistency by applying all changes atomically to the SQL Server database.

In **Home.razor**, implement the `BatchUpdateAsync` method within the `CustomAdaptor` class:

```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> BatchUpdateAsync(DataManager dataManager, object changed, object added, object deleted, string? keyField, string key, int? dropIndex)
    {
        // Process updated records
        if (changed != null)
        {
            foreach (var record in (IEnumerable<Tickets>)changed)
            {
                await _ticketService!.UpdateTicketAsync(record);
            }
        }

        // Process newly added records
        if (added != null)
        {
            foreach (var record in (IEnumerable<Tickets>)added)
            {
                await _ticketService!.AddTicketAsync(record);
            }
        }

        // Process deleted records
        if (deleted != null)
        {
            foreach (var record in (IEnumerable<Tickets>)deleted)
            {
                await _ticketService!.RemoveTicketAsync(record.TicketId);
            }
        }
        return key;
    }
}
```

> This method is triggered when the TreeGrid is operating in [Batch](https://blazor.syncfusion.com/documentation/treegrid/editing/batch-editing) Edit mode.

**What happens behind the scenes:**

- The TreeGrid collects all added, edited, and deleted records in Batch Edit mode.
- The combined batch request is passed to the CustomAdaptor's `BatchUpdateAsync()` method.
- Each modified record is processed using `TicketRepository.UpdateTicketAsync()`.
- Each newly added record is saved using `TicketRepository.AddTicketAsync()`.
- Each deleted record is removed using `TicketRepository.RemoveTicketAsync()`.
- All repository operations persist changes to the SQL Server database.
- The TreeGrid refreshes to display the updated, added, and removed records in a single response.

Now the adaptor supports bulk modifications with atomic database synchronization. All CRUD operations are now fully implemented, enabling comprehensive data management capabilities within the Blazor TreeGrid.

**Reference links**

- [InsertAsync(DataManager, object)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_InsertAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_) - Create new records in SQL Server
- [UpdateAsync(DataManager, object, string, string)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_UpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) - Edit existing records in SQL Server
- [RemoveAsync(DataManager, object, string, string)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_RemoveAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) - Delete records from SQL Server
- [BatchUpdateAsync(DataManager, object, object, object, string, string, int?)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_BatchUpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_Object_System_Object_System_String_System_String_System_Nullable_System_Int32__) - Handle bulk operations

---

### Step 10: Complete Home.razor Code

Here is the complete and final `Home.razor` component with all features integrated. This component uses the exact implementation from the Grid_MSSQL project:

```html
@page "/"
@rendermode InteractiveServer
@using System.Collections
@using TreeGrid_MSSQL.Data
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.DropDowns

@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Adaptors
@inject TicketRepository TicketService
<PageTitle>Network Support Ticket System</PageTitle>

<section class="bg-gray-50 dark:bg-gray-950">
    <div class="mx-auto w-full py-12 sm:px-6 px-4">
        <h1 class="mb-4 text-3xl font-bold">Network Support Ticket System</h1>
        <p class="mb-3 text-gray-600">Manage and view all support tickets from the database.</p>
        <SfTreeGrid @ref="TreeGrid" TValue="Tickets" Width="100%" Height="500px" AllowSorting="true" AllowFiltering="true" AllowPaging="true" ParentIdMapping="ParentTicketID" IdMapping="TicketID" HasChildMapping="HasChildren"
            Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" })">
            <TreeGridFilterSettings Type="Syncfusion.Blazor.TreeGrid.FilterType.Menu"></TreeGridFilterSettings>
            <TreeGridEditSettings AllowEditing="true" AllowDeleting="true" AllowAdding="true" Mode="Syncfusion.Blazor.TreeGrid.EditMode.Batch"></TreeGridEditSettings>
            <TreeGridPageSettings PageSize="2"></TreeGridPageSettings>
            <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
            <TreeGridColumns>
                <TreeGridColumn Field=@nameof(Tickets.TicketID) HeaderText="Ticket ID" Width="140" IsPrimaryKey="true"></TreeGridColumn>
                
                <TreeGridColumn Field=@nameof(Tickets.Title) HeaderText="Subject" Width="280" ClipMode="ClipMode.EllipsisWithTooltip" EditType="EditType.DefaultEdit"></TreeGridColumn>
                <TreeGridColumn Field=@nameof(Tickets.Category) HeaderText="Category" Width="180" EditType="EditType.DropDownEdit" EditorSettings="@CategoryDropDownParams">
                    <Template>
                        @{
                            var data = (Tickets)context;
                        }
                        <span class="chip @GetCategoryClass(data)">
                            @data.Category
                        </span>
                    </Template>
                </TreeGridColumn>
                <TreeGridColumn Field=@nameof(Tickets.Priority) HeaderText="Priority" Width="160" EditType="EditType.DropDownEdit" EditorSettings="@PriorityDropDownParams">
                    <Template>
                        @{
                            var data = (Tickets)context;
                        }
                        <span class="priority-pill @GetPriorityClass(data)" title="@GetPriorityDescription(data)">
                            <span class="priority-icon" aria-hidden="true"></span>
                            @data.Priority
                        </span>
                    </Template>
                </TreeGridColumn>
                <TreeGridColumn Field=@nameof(Tickets.Status) HeaderText="Status" Width="180" EditType="EditType.DropDownEdit" EditorSettings="@StatusDropDownParams">
                    <Template>
                        @{
                            var data = (Tickets)context;
                        }
                        <span class="status-text @GetStatusClass(data)" title="@GetStatusDescription(data)">
                            @data.Status
                        </span>
                    </Template>
                </TreeGridColumn>
                <TreeGridColumn Field=@nameof(Tickets.Assignee) HeaderText="Agent" Width="160"></TreeGridColumn>
                <TreeGridColumn Field=@nameof(Tickets.CustomerName) HeaderText="Customer Name" Width="180" ></TreeGridColumn> 
                <TreeGridColumn Field=@nameof(Tickets.CreatedAt) HeaderText="Created On" Width="200" Type="ColumnType.DateTime" Format="MMM d, yyyy, h:mm tt" EditType="EditType.DateTimePickerEdit"></TreeGridColumn> 
                <TreeGridColumn Field=@nameof(Tickets.DueDate) HeaderText="Resolution Due" Width="200" Type="ColumnType.DateTime" Format="MMM d, yyyy, h:mm tt" EditType="EditType.DateTimePickerEdit"></TreeGridColumn>
            </TreeGridColumns>
        </SfTreeGrid>
    </div>
</section>

```


> * Set [IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_IsPrimaryKey) to **true** for a column that contains unique values.
> * The [EditType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.EditType.html?_gl=1*4kxqtd*_gcl_au*ODcxNTU4MzMyLjE3Njc1ODkwOTk.*_ga*NjA2MTg0NzMuMTc1OTc1MDUyNg..*_ga_41J4HFMX1J*czE3Njk1MzE3NTAkbzY1JGcxJHQxNzY5NTMyOTMwJGo2MCRsMCRoMA..) property can be used to specify the desired editor for each column. [🔗](https://blazor.syncfusion.com/documentation/treegrid/editing/cell-edit-types)
> * The behavior of default editors can be customized using the [EditorSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_EditorSettings) property of the `TreeGridColumn` component. [🔗](https://blazor.syncfusion.com/documentation/treegrid/editing/cell-edit-types)
> * [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_Type) property of the `TreeGridColumn` component  specifies the data type of a TreeGrid column.
> * The [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_Template) property that allows rendering custom elements in a column instead of the default field value. [🔗](https://blazor.syncfusion.com/documentation/datagrid/column-template)


```csharp
@code {
    private CustomAdaptor? _customAdaptor;

    public SfTreeGrid<Tickets>? TreeGrid { get; set; }
    protected override void OnInitialized()
    {
        // Initialize the CustomAdaptor with the injected TicketRepository
        _customAdaptor = new CustomAdaptor { TicketService = TicketService };
    }

    public class CustomAdaptor : DataAdaptor
    {
private TicketRepository? _ticketService;

public TicketRepository? TicketService
{
    get => _ticketService;
    set => _ticketService = value;
}

        /// <summary>
        /// Returns the data collection after performing data operations based on request from <see cref="DataManagerRequest"/>
        /// </summary>
        /// <param name="DataManagerRequest">DataManagerRequest contains the information regarding paging, grouping, filtering, searching, sorting which is handled on the Blazor DataTreeGrid component side</param>
        /// <param name="Key">An optional parameter that can be used to perform additional data operations.</param>
        /// <returns>The data collection's type is determined by how this method has been implemented.</returns>
        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string Key = null)
        {
            IEnumerable<Tickets> dataSource = await _ticketService!.GetTicketsDataAsync();

            // Handling Searching in CustomAdaptor.
            if (dataManagerRequest.Search != null && dataManagerRequest.Search.Count > 0)
            {
                dataSource = DataOperations.PerformSearching(dataSource, dataManagerRequest.Search);
            }

            // Handling Filtering in CustomAdaptor.
            if (dataManagerRequest.Where != null && dataManagerRequest.Where.Count > 0)
            {
                dataSource = DataOperations.PerformFiltering(dataSource, dataManagerRequest.Where, dataManagerRequest.Where[0].Operator);
            }

            // Handling Sorting in CustomAdaptor.
            if (dataManagerRequest.Sorted != null && dataManagerRequest.Sorted.Count > 0)
            {
                dataSource = DataOperations.PerformSorting(dataSource, dataManagerRequest.Sorted);
            }

            // Handling Aggregates
            IDictionary<string, object>? aggregates = null;
            if (dataManagerRequest.Aggregates != null)
            {
                aggregates = DataUtil.PerformAggregation(dataSource, dataManagerRequest.Aggregates);
            }

            int totalRecordsCount = dataSource.Count();
            DataResult dataObject = new DataResult();
            // Handling Group operation in CustomAdaptor.
            if (dataManagerRequest.Group != null)
            {
                IEnumerable ResultData = dataSource.ToList();
                foreach (var group in dataManagerRequest.Group)
                {
                    ResultData = DataUtil.Group<Tickets>(ResultData, group, dataManagerRequest.Aggregates, 0, dataManagerRequest.GroupByFormatter);
                }
                dataObject.Result = ResultData;
                dataObject.Count = totalRecordsCount;
                return dataManagerRequest.RequiresCounts ? dataObject : (object)ResultData;
            }
            // Handling paging in CustomAdaptor.
            if (dataManagerRequest.Skip != 0)
            {
                dataSource = DataOperations.PerformSkip(dataSource, dataManagerRequest.Skip);
            }
            if (dataManagerRequest.Take != 0)
            {
                dataSource = DataOperations.PerformTake(dataSource, dataManagerRequest.Take);
            }
            return dataManagerRequest.RequiresCounts ? new DataResult() { Result = dataSource, Count = totalRecordsCount, Aggregates = aggregates } : (object)dataSource;
        }

        /// <summary>
        /// Inserts a new data item into the data collection.
        /// </summary>
        /// <param name="DataManager">The DataManager is a data management component used for performing data operations in application.</param>
        /// <param name="value">The new record which is need to be inserted.</param>
        /// <param name="key">An optional parameter that can be used to perform additional data operations.</param>
        /// <returns>Returns the newly inserted record details.</returns>
        public override async Task<object> InsertAsync(DataManager DataManager, object value, string key)
        {
            // Add your insert logic here
            await _ticketService!.AddTicketAsync(value as Tickets);
            return value;
        }

        /// <summary>
        /// Updates an existing data item in the data collection.
        /// </summary>
        /// <param name="DataManager">The DataManager is a data management component used for performing data operations in application.</param>
        /// <param name="value">The modified record which is need to be updated.</param>
        /// <param name="keyField">The primary column name specifies the field name of the primary column.</param>
        /// <param name="key">An optional parameter that can be used to perform additional data operations.</param>
        /// <returns>Returns the updated data item.</returns>
        public override async Task<object> UpdateAsync(DataManager DataManager, object value, string keyField, string key)
        {
            // Add your update logic here
            if (value is Tickets ticket)
            {
                await _ticketService!.UpdateTicketAsync(ticket);
            }
            return value;
        }

        /// <summary>
        /// Removes a data item from the data collection.
        /// </summary>
        /// <param name="dataManager">The DataManager is a data management component used for performing data operations in application.</param>
        /// <param name="value">The Value specifies the primary column value which is needs to be removed from the TreeGrid record.</param>
        /// <param name="keyField">The KeyField specifies the field name of the primary column.</param>
        /// <param name="key">An optional parameter that can be used to perform additional data operations.</param>
        /// <returns>Returns the removed data item.</returns>
        public override async Task<object> RemoveAsync(DataManager dataManager, object value, string keyField, string key)
        {
            // This method will be invoked when deleting existing records from the Blazor TreeGrid component.
            int? recordId = null;
            if (value is int intValue)
            {
                recordId = intValue;
            }
            else if (value is Tickets ticket)
            {
                recordId = ticket.TicketID;
            }
            else if (int.TryParse(value?.ToString(), out int parsedValue))
            {
                recordId = parsedValue;
            }

            if (recordId.HasValue && recordId.Value > 0)
            {
                await _ticketService!.RemoveTicketAsync(recordId);
            }
            return value;
      
        }

        /// <summary>
        /// Batchupdate (Insert, Update, Delete) a collection of data items from the data collection.
        /// </summary>
        /// <param name="dataManager">The DataManager is a data management component used for performing data operations in application.</param>
        /// <param name="changed">The Changed specifies the collection of record updated in batch mode which needs to be updated from the TreeGrid record.</param>
        /// <param name="added">The Added specifies the collection of record inserted in batch mode which needs to be inserted from the TreeGrid record.</param>
        /// <param name="deleted">The Deleted specifies the collection of record deleted in batch mode which needs to be removed from the TreeGrid record.</param>
        /// <param name="keyField">The KeyField specifies the field name of the primary column.</param>
        /// <param name="key">An optional parameter that can be used to perform additional data operations.</param>
        /// <param name="dropIndex">An optional parameter that can be used to perform row drag and drop operation.</param>
        /// <returns>Returns the removed data item.</returns>
        public override async Task<object> BatchUpdateAsync(DataManager dataManager, object changed, object added, object deleted, string keyField, string key, int? dropIndex)
        {
            if (changed != null)
            {
                foreach (var record in (IEnumerable<Tickets>)changed)
                {
                    await _ticketService!.UpdateTicketAsync(record as Tickets);
                }
            }
            if (added != null)
            {
                foreach (var record in (IEnumerable<Tickets>)added)
                {
                    await _ticketService!.AddTicketAsync(record as Tickets);
                }
            }
            if (deleted != null)
            {
foreach (var record in (IEnumerable<Tickets>)deleted)
            {
                await _ticketService!.RemoveTicketAsync(record.TicketID);
            }
            }
            return key;
        }
    }

    /// <summary>
    /// Provides a list of status options used as the data source for the Status dropdown editor in the TreeGrid.
    /// </summary>
    private static List<Tickets> StatusCustomData = new List<Tickets> {
            new Tickets() { Status= "Open" },
            new Tickets() { Status= "InProgress" },
            new Tickets() { Status= "Resolved" },
        };

    /// <summary>
    /// Configures the dropdown editor used by the Status column via EditorSettings="@StatusDropDownParams".
    /// </summary>
    private IEditorSettings StatusDropDownParams = new DropDownEditCellParams
    {
        Params = new DropDownListModel<object, object>() { DataSource = StatusCustomData, Query = new Syncfusion.Blazor.Data.Query(), ShowClearButton = true, AllowFiltering = true, Value="Open" }
    };

    /// <summary>
    /// Provides a list of priority options used as the data source for the Priority dropdown editor in the TreeGrid.
    /// </summary>
    private static List<Tickets> PriorityCustomData = new List<Tickets> {
            new Tickets() { Priority= "Critical" },
            new Tickets() { Priority= "High" },
            new Tickets() { Priority= "Medium" },
            new Tickets() { Priority= "Low" },
        };

    /// <summary>
    /// Configures the dropdown editor used by the Priority column via EditorSettings="@PriorityDropDownParams".
    /// </summary>
    private IEditorSettings PriorityDropDownParams = new DropDownEditCellParams
    {
        Params = new DropDownListModel<object, object>() { DataSource = PriorityCustomData, Query = new Syncfusion.Blazor.Data.Query(), ShowClearButton = true, AllowFiltering = true, Value="Low"}
    };

    /// <summary>
    /// Provides a list of category options used as the data source for the Category dropdown editor in the TreeGrid.
    /// </summary>
    private static List<Tickets> CategoryCustomData = new List<Tickets> {
            new Tickets() { Category= "Network Issue" },
            new Tickets() { Category= "Network" },
            new Tickets() { Category= "Performance" },
            new Tickets() { Category= "VPN" },
            new Tickets() { Category= "Hardware" },
            new Tickets() { Category= "Server issue" },
            new Tickets() { Category= "Server" },
            new Tickets() { Category= "Security" },
            new Tickets() { Category= "Connectivity" },
            new Tickets() { Category= "Software" },
            new Tickets() { Category= "Email" },
            new Tickets() { Category= "Access" },
            new Tickets() { Category= "Backup" },
            new Tickets() { Category= "Database" },
        };

    /// <summary>
    /// Configures the dropdown editor used by the Category column via EditorSettings="@CategoryDropDownParams".
    /// </summary>
    private IEditorSettings CategoryDropDownParams = new DropDownEditCellParams
    {
        Params = new DropDownListModel<object, object>() { DataSource = CategoryCustomData, Query = new Syncfusion.Blazor.Data.Query(), ShowClearButton = true, AllowFiltering = true, }
    };

    /// <summary>
    /// Returns a CSS class name based on ticket status to style the Status column template.
    /// </summary>
    private string GetStatusClass(Tickets data)
    {
        return data.Status?.ToLower() switch
        {
            "open" => "status-open",
            "inprogress" => "status-inprogress",
            "waitingforcustomer" => "status-waiting-customer",
            "waitingforagent" => "status-waiting-agent",
            "resolved" => "status-resolved",
            "closed" => "status-closed",
            _ => ""
        };
    }

    /// <summary>
    /// Returns the tooltip text shown for status in the Status column template.
    /// </summary>
    private string GetStatusDescription(Tickets data)
    {
        return data.Status ?? "";
    }

    /// <summary>
    /// Returns a CSS class name based on ticket priority to style the Priority column template.
    /// </summary>
    private string GetPriorityClass(Tickets data)
    {
        return data.Priority?.ToLower() switch
        {
            "critical" => "priority-critical",
            "high" => "priority-high",
            "medium" => "priority-medium",
            "low" => "priority-low",
            _ => ""
        };
    }

    /// <summary>
    /// Returns the tooltip text shown for priority in the Priority column template.
    /// </summary>
    private string GetPriorityDescription(Tickets data)
    {
        return data.Priority ?? "";
    }

    /// <summary>
    /// Returns a CSS class name based on ticket category to style the Category column template.
    /// </summary>
    private string GetCategoryClass(Tickets data)
    {
        return data.Category?.ToLower() switch
        {
            "network issue" => "category-network",
            "network" => "category-network",
            "performance" => "category-performance",
            "vpn" => "category-vpn",
            "hardware" => "category-hardware",
            "server issue" => "category-server",
            "server" => "category-server",
            "security" => "category-security",
            "connectivity" => "category-connectivity",
            "software" => "category-software",
            "email" => "category-email",
            "access" => "category-access",
            "backup" => "category-backup",
            "database" => "category-database",
            _ => ""
        };
    }
}
```

> * Set [IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridColumn.html#Syncfusion_Blazor_TreeGrid_TreeGridColumn_IsPrimaryKey) to **true** for a column that contains unique values.
---

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
3. The Network Support Ticket System is now running and ready to use.

### Available Features

- **View Data**: All tickets from the SQL Server database are displayed in the TreeGrid.
- **Search**: Use the search box to find tickets by any field.
- **Filter**: Click on column headers to apply filters.
- **Sort**: Click on column headers to sort data in ascending or descending order.
- **Pagination**: Navigate through records using page numbers.
- **Add**: Click the "Add" button to create a new ticket.
- **Edit**: Click the "Edit" button to modify existing tickets.
- **Delete**: Click the "Delete" button to remove tickets.

---

## Complete Sample Repository

A complete, working sample implementation is available in the [GitHub repository](#).

---
## Summary

This guide demonstrates how to:

1. Create a SQL Server database with ticket records. [🔗](#step-1-create-the-database-and-table-in-sql-server)
2. Install necessary NuGet packages for Entity Framework Core and Syncfusion. [🔗](#step-2-install-required-nuget-packages)
3. Create data models and DbContext for database communication. [🔗](#step-3-create-the-data-model)
4. Configure connection strings and register services. [🔗](#step-5-configure-the-connection-string)
5. Implement the repository pattern for data access. [🔗](#step-6-create-the-repository-class)
6. Create a Blazor component with a TreeGrid that supports searching, filtering, sorting, paging, and CRUD operations. [🔗](#step-1-install-and-configure-blazor-treegrid-components)
7. Handle bulk operations and batch updates. [🔗](#step-09-perform-crud-operations)

The application now provides a complete solution for managing network support tickets with a modern, user-friendly interface integrated with SQL Server.
