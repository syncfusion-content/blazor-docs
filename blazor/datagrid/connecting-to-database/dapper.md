---
layout: post
title: Blazor Data Grid connected to SQL Server via Dapper | Syncfusion
description: Bind SQL Server data to Blazor Data Grid using Dapper with complete CRUD, filtering, sorting, paging, grouping, and advanced data operations.
platform: Blazor
control: DataGrid
documentation: ug
---

# Connecting SQL Server to Blazor Data Grid Using Dapper

The [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) supports binding data from SQL Server using the lightweight Dapper micro‑ORM. This modern approach provides a simpler, more direct alternative where raw SQL control is preferred.

**What is Dapper?**

Dapper is a lightweight, high-performance ORM (Object-Relational Mapper) that provides a minimal abstraction over ADO.NET. It maps query results directly to C# objects with minimal overhead, making it ideal for applications where performance and control over SQL are critical.

**Key Benefits of Dapper**

- **High Performance**: Minimal overhead with direct ADO.NET access, resulting in faster query execution.
- **SQL Control**: Write raw SQL queries when needed, giving developers full control over database operations.
- **Simple and Lightweight**: Requires minimal configuration and learning curve compared to full ORMs.
- **Flexible Mapping**: Automatically maps query results to C# objects with minimal configuration.
- **Built-in Security**: Parameterized queries prevent SQL injection attacks.

## Prerequisites

Ensure the following software and packages are installed before proceeding:

| Software/Package | Version | Purpose |
|-----------------|---------|---------|
| Visual Studio 2022 | 17.0 or later | Development IDE with Blazor workload |
| .NET SDK | net8.0 or compatible | Runtime and build tools |
| SQL Server | 2019 or later | Database server |
| Syncfusion.Blazor.Grids | {{site.blazorversion}} | DataGrid and UI components |
| Syncfusion.Blazor.Themes | {{site.blazorversion}} | Styling for DataGrid components |
| Microsoft.Data.SqlClient | Latest | SQL Server ADO.NET provider |
| Dapper | Latest | Lightweight micro-ORM for SQL mapping |

## Setting Up the SQL Server Environment with Dapper

### Step 1: Create the database and table in SQL Server

First, the **SQL Server database** structure must be created to store reservation records.

**Instructions:**
1. Open SQL Server Management Studio or any SQL Server client.
2. Create a new database named `HotelBookingDB`.
3. Define a `Rooms` table with the specified schema.
4. Insert sample data for testing.

Run the following SQL script:

```sql
-- Create Database
IF NOT EXISTS (SELECT * FROM sys.databases WHERE name = 'HotelBookingDB')
BEGIN
    CREATE DATABASE HotelBookingDB;
END
GO

USE HotelBookingDB;
GO

-- Create Rooms table
IF NOT EXISTS (SELECT * FROM sys.tables WHERE name = 'Rooms')
BEGIN
    CREATE TABLE dbo.Rooms (
        Id INT IDENTITY(1,1) PRIMARY KEY,
        ReservationId VARCHAR(50) NOT NULL,
        GuestName VARCHAR(100) NOT NULL,
        GuestEmail VARCHAR(250) NULL,
        CheckInDate DATE NOT NULL,
        CheckOutDate DATE NULL,
        RoomType VARCHAR(100) NULL,
        RoomNumber VARCHAR(20) NULL,
        AmountPerDay DECIMAL(18,2) NULL,
        NoOfDays INT NULL,
        TotalAmount DECIMAL(18,2) NULL,
        PaymentStatus VARCHAR(50) NOT NULL,
        ReservationStatus VARCHAR(50) NOT NULL
    );

-- Insert Sample Data (Optional)
INSERT INTO dbo.Rooms (ReservationId, GuestName, GuestEmail, CheckInDate, CheckOutDate, RoomType, RoomNumber, AmountPerDay, NoOfDays, TotalAmount, PaymentStatus, ReservationStatus)
VALUES
('RES001001', 'John Doe', 'john.doe@example.com', '2026-01-13', '2026-01-15', 'Deluxe Suite', 'D-204', 150.00, 2, 300.00, 'Paid', 'Confirmed'),
('RES001002', 'Mary Smith', 'mary.smith@example.com', '2026-01-14', '2026-01-17', 'Standard Room', 'S-108', 90.00, 3, 270.00, 'Pending', 'Confirmed');
GO
```

After executing this script, the reservation records are stored in the `Rooms` table within the `HotelBookingDB` database. The database is now ready for integration with the Blazor application.

---

### Step 2: Install Required NuGet Packages

Before installing the necessary NuGet packages, a new Blazor Web Application must be created using the default template.
This template automatically generates essential starter files—such as **Program.cs, appsettings.json, the wwwroot folder, and the Components folder**.

For this guide, a Blazor application named **Grid_Dapper** has been created. Once the project is set up, the next step involves installing the required NuGet packages. NuGet packages are software libraries that add functionality to the application. These packages enable Dapper and SQL Server integration.

**Method 1: Using Package Manager Console**

1. Open Visual Studio 2022.
2. Navigate to **Tools → NuGet Package Manager → Package Manager Console**.
3. Run the following commands:

```powershell
Install-Package Microsoft.Data.SqlClient -Version Latest
Install-Package Dapper -Version Latest
Install-Package Syncfusion.Blazor.Grids -Version {{site.blazorversion}}
Install-Package Syncfusion.Blazor.Themes -Version {{site.blazorversion}}
```

**Method 2: Using NuGet Package Manager UI**

1. Open **Visual Studio 2022 → Tools → NuGet Package Manager → Manage NuGet Packages for Solution**.
2. Search for and install each package individually:
   - **Microsoft.Data.SqlClient** (Latest version)
   - **Dapper** (Latest version)
   - **Syncfusion.Blazor.Grids** (version {{site.blazorversion}})
   - **Syncfusion.Blazor.Themes** (version {{site.blazorversion}})

All required packages are now installed.

### Step 3: Create the Data Model

A data model is a C# class that represents the structure of a database table. This model defines the properties that correspond to the columns in the `Rooms` table.

**Instructions:**

1. Create a new folder named `Data` in the Blazor application project.
2. Inside the `Data` folder, create a new file named **Reservation.cs**.
3. Define the **Reservation** class with the following code:

```csharp
using System.ComponentModel.DataAnnotations;

namespace Grid_Dapper.Data
{
    /// <summary>
    /// Represents a reservation record mapped to the 'Rooms' table in the database.
    /// This model defines the structure of reservation-related data used throughout the application.
    /// </summary>
    public class Reservation
    {
        /// <summary>
        /// Gets or sets the unique identifier for the reservation record.
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// Gets or sets the unique reservation reference generated by the system.
        /// </summary>
        public string? ReservationId { get; set; }

        /// <summary>
        /// Gets or sets the name of the guest making the reservation.
        /// </summary>
        public string? GuestName { get; set; }

        /// <summary>
        /// Gets or sets the email address of the guest.
        /// </summary>
        public string? GuestEmail { get; set; }

        /// <summary>
        /// Gets or sets the check-in date for the reservation.
        /// </summary>
        public DateTime? CheckInDate { get; set; }

        /// <summary>
        /// Gets or sets the check-out date for the reservation.
        /// </summary>
        public DateTime? CheckOutDate { get; set; }

        /// <summary>
        /// Gets or sets the type of room (e.g., Standard, Deluxe, Suite).
        /// </summary>
        public string? RoomType { get; set; }

        /// <summary>
        /// Gets or sets the room number assigned to the reservation.
        /// </summary>
        public string? RoomNumber { get; set; }

        /// <summary>
        /// Gets or sets the cost per day for the room.
        /// </summary>
        public decimal? AmountPerDay { get; set; }

        /// <summary>
        /// Gets or sets the number of days for the stay (calculated from check-in and check-out dates).
        /// </summary>
        public int? NoOfDays { get; set; }

        /// <summary>
        /// Gets or sets the total amount for the reservation (calculated as AmountPerDay × NoOfDays).
        /// </summary>
        public decimal? TotalAmount { get; set; }

        /// <summary>
        /// Gets or sets the payment status (e.g., Pending, Paid, Failed).
        /// </summary>
        public string? PaymentStatus { get; set; }

        /// <summary>
        /// Gets or sets the reservation status (e.g., Confirmed, Cancelled, Completed).
        /// </summary>
        public string? ReservationStatus { get; set; }
    }
}
```

**Explanation:**
- The `[Key]` attribute marks the `Id` property as the primary key (a unique identifier for each record).
- Each property represents a column in the database table.
- The `?` symbol indicates that a property is nullable (can be empty).
- XML documentation comments describe each property's purpose.

The data model has been successfully created.

### Step 4: Configure the Connection String

A connection string contains the information needed to connect the application to the SQL Server database, including the server address, database name, and credentials.

**Instructions:**

1. Open the `appsettings.json` file in the project root.
2. Add or update the `ConnectionStrings` section with the SQL Server connection details:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Data Source=localhost;Initial Catalog=HotelBookingDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
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
| Initial Catalog | The database name (in this case, `HotelBookingDB`) |
| Integrated Security | Set to `True` for Windows Authentication; use `False` with Username/Password for SQL Authentication |
| Connect Timeout | Connection timeout in seconds (default is 15) |
| Encrypt | Enables encryption for the connection (set to `True` for production environments) |
| Trust Server Certificate | Whether to trust the server certificate (set to `False` for security) |
| Application Intent | Set to `ReadWrite` for normal operations or `ReadOnly` for read-only scenarios |
| Multi Subnet Failover | Used in failover clustering scenarios (typically `False`) ||

The database connection string has been configured successfully.

---

### Step 5: Create the Repository Class

A repository class is an intermediary layer that handles all database operations. With Dapper, this class uses raw SQL queries with ADO.NET to communicate with the database.

**Instructions:**

1. Inside the `Data` folder, create a new file named **ReservationRepository.cs**.
2. Define the **ReservationRepository** class with the following code: 

```csharp
using Dapper;
using System.Data;

namespace Grid_Dapper.Data
{
    /// <summary>
    /// Repository pattern implementation for Reservation using Dapper
    /// Handles all CRUD operations and business logic for hotel room reservations
    /// </summary>
    public class ReservationRepository
    {
        private readonly IDbConnection _connection;

        public ReservationRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        /// <summary>
        /// Retrieves all reservations from the database ordered by id descending
        /// </summary>
        /// <returns>List of all reservations</returns>
        public async Task<List<Reservation>> GetReservationsAsync()
        {
            try
            {
                const string query = @"SELECT * FROM [dbo].[Rooms] ORDER BY Id DESC";
                var reservations = await _connection.QueryAsync<Reservation>(query);
                return reservations.ToList();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving reservations: {ex.Message}");
                throw;
            }
        }

        /// <summary>
        /// Adds a new reservation to the database
        /// </summary>
        /// <param name="value">The reservation model to add</param>
        public async Task AddReservationAsync(Reservation value)
        {
            // Handle logic to add a new reservation to the database
        }

        /// <summary>
        /// Updates an existing reservation
        /// </summary>
        /// <param name="value">The reservation model with updated values</param>
        public async Task UpdateReservationAsync(Reservation value)
        {
            // Handle logic to update an existing reservation to the database
        }

        /// <summary>
        /// Deletes a reservation from the database
        /// </summary>
        /// <param name="key">The reservation ID to delete</param>
        public async Task RemoveReservationAsync(int? key)
        {
           // Handle logic to delete an existing reservation from the database
        }
    }
}
```
The repository class manages all interactions with the database and is now ready for implementation.

---

### Step 6: Register Services in Program.cs

The `Program.cs` file is where application services are registered and configured. This file must be updated to enable Dapper and the repository pattern.

**Instructions:**

1. Open the `Program.cs` file at the project root.
2. Add the following code after the line `var builder = WebApplication.CreateBuilder(args);`:

```csharp
using Microsoft.Data.SqlClient;
using Grid_Dapper.Data;
using Syncfusion.Blazor;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSyncfusionBlazor();

// Get connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
if (string.IsNullOrEmpty(connectionString))
{
    throw new InvalidOperationException("Connection string 'DefaultConnection' not found in configuration.");
}

// Register IDbConnection for Dapper
builder.Services.AddScoped<IDbConnection>(sp => new SqlConnection(connectionString));

// Register the repository for dependency injection
builder.Services.AddScoped<ReservationRepository>();

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

**Explanation:**
- **`AddScoped<IDbConnection>`**: Dapper requires an ADO.NET connection object, registered as a scoped service so each request gets its own connection.
- **`AddScoped<ReservationRepository>`**: Makes the ReservationRepository available for dependency injection throughout the application.
- **`AddSyncfusionBlazor()`**: Registers Syncfusion Blazor components.
- **`AddRazorComponents()` and `AddInteractiveServerComponents()`**: Enables Blazor server-side rendering with interactive components.


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
<link href="_content/Syncfusion.Blazor/Themes/tailwind3.css" rel="stylesheet" />

<!-- Syncfusion Blazor Scripts -->
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
```
For this project, the tailwind3 theme is used. A different theme can be selected or the existing theme can be customized based on project requirements. Refer to the [Syncfusion Blazor Components Appearance](https://blazor.syncfusion.com/documentation/appearance/themes) documentation to learn more about theming and customization options.

Syncfusion components are now configured and ready to use. For additional guidance, refer to the Grid component's [getting‑started](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app) documentation.

### Step 2: Update the Blazor DataGrid

The `Home.razor` component will display the reservation data in a Syncfusion Blazor DataGrid with search, filter, sort, and pagination capabilities.

**Instructions:**

1. Open the file named `Home.razor` in the `Components/Pages` folder.
2. Add the following code to create a DataGrid with CustomAdaptor:

```cshtml
@page "/"
@rendermode InteractiveServer
@inject ReservationRepository ReservationService

<PageTitle>Reservation Management System</PageTitle>

<div class="container-fluid p-4">

    <!-- Syncfusion Blazor DataGrid Component -->
    <SfGrid TValue="Reservation" AllowPaging="true" AllowSorting="true" AllowFiltering="true" AllowGrouping="true">
        <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
        
        <GridColumns>
            <!-- Columns configuration -->
        </GridColumns>
    </SfGrid>
</div>

@code {
    // CustomAdaptor class will be added in the next step
}
```

**Component Explanation:**

- **`@rendermode InteractiveServer`**: Enables interactive server-side rendering for the component.
- **`@inject ReservationRepository`**: Injects the repository to access database methods.
- **`<SfGrid>`**: The DataGrid component that displays data in rows and columns.
- **`<GridColumns>`**: Defines individual columns in the DataGrid.

The Home component has been updated successfully with DataGrid.

### Step 3: Implement the CustomAdaptor

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can bind data from a **SQL Server** database using [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) and set the [Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Adaptors.html) property to [CustomAdaptor](https://blazor.syncfusion.com/documentation/datagrid/connecting-to-adaptors/custom-adaptor) for scenarios that require full control over data operations.

The `CustomAdaptor` is a bridge between the DataGrid and the database. It handles all data operations including reading, searching, filtering, sorting, paging, and CRUD operations. Each operation in the CustomAdaptor's `ReadAsync` method handles specific grid functionality. The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid sends operation details to the API through a [DataManagerRequest](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManagerRequest.html) object. These details can be applied to the data source using methods from the [DataOperations](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataOperations.html) class.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Add the following `CustomAdaptor` class code inside the `@code` block:

```csharp
@code {

    private CustomAdaptor? _customAdaptor;

    protected override void OnInitialized()
    {
        // Initialize the CustomAdaptor with the injected ReservationRepository
        _customAdaptor = new CustomAdaptor { ReservationService = ReservationService };
    }

    /// <summary>
    /// CustomAdaptor class bridges DataGrid interactions with database operations using Dapper.
    /// This adaptor handles all data retrieval and manipulation for the DataGrid.
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        public static ReservationRepository? _reservationService;

        public ReservationRepository? ReservationService
        {
            get => _reservationService;
            set => _reservationService = value;
        }

        /// <summary>
        /// ReadAsync retrieves records from the database and applies data operations.
        /// This method executes when the grid initializes and when filtering, searching, sorting, or paging occurs.
        /// </summary>
        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
        {
            try
            {
                // Fetch all reservations from the database
                IEnumerable dataSource = await _reservationService!.GetReservationsAsync();

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
                int totalRecordsCount = dataSource.Cast<Reservation>().Count();

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
                        dataSource = DataUtil.Group<Reservation>(dataSource, group, dataManagerRequest.Aggregates, 0, dataManagerRequest.GroupByFormatter);
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

1. Open the `Components/Pages/Home.razor` file.
2. Update the `<SfGrid>` component to include the [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Toolbar) property with CRUD and search options:

```cshtml
<SfGrid TValue="Reservation" 
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
| `Add` | Opens a form to add a new reservation record. |
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
2. The page size is configured with [GridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html).
3. No additional code changes are required from the previous steps.

```cshtml
<SfGrid TValue="Reservation" 
        AllowPaging="true">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridPageSettings PageSize="20"></GridPageSettings>
    
    <!-- Grid columns configuration -->
</SfGrid>
```

4. Update the `ReadAsync` method in the `CustomAdaptor` class to handle paging:

```csharp
@code {
    /// <summary>
    /// CustomAdaptor class to handle grid data operations with SQL Server using Entity Framework
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        public static ReservationRepository? _reservationRepository;
 
        public ReservationRepository? ReservationRepository 
        { 
            get => _reservationRepository; 
            set => _reservationRepository = value; 
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string Key = null)
        {

            IEnumerable dataSource = await _reservationRepository.GetReservationsAsync();

            int totalRecordsCount = dataSource.Cast<Reservation>().Count();

            // Handling paging
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

Fetches reservation data by calling the **GetReservationsAsync** method, which is implemented in the **ReservationRepository.cs** file.

```csharp
/// <summary>
/// Retrieves all reservations from the database ordered by check-in date descending
/// </summary>
/// <returns>List of all reservations</returns>
public async Task<List<Reservation>> GetReservationsAsync()
{
    try
    {
        const string query = @"SELECT * FROM [dbo].[Rooms] ORDER BY Id DESC";
        var reservations = await _connection.QueryAsync<Reservation>(query);
        return reservations.ToList();
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error retrieving reservations: {ex.Message}");
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

Paging feature is now active with 10 records per page.

---

### Step 6: Implement Searching feature

Searching allows the user to find records by entering keywords in the search box.

1. Ensure the toolbar includes the "Search" item.

```cshtml
<SfGrid TValue="Reservation"
        AllowPaging="true"
        Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GridPageSettings PageSize="20"></GridPageSettings>
    <!-- Grid columns configuration -->
</SfGrid>
```

2. Update the `ReadAsync` method in the `CustomAdaptor` class to handle searching:

```csharp
@code {
    private List<string> ToolbarItems = new List<string> { "Search"}

    /// <summary>
    /// CustomAdaptor class to handle grid data operations with SQL Server using Entity Framework
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        public static ReservationRepository? _reservationRepository;
 
        public ReservationRepository? ReservationRepository 
        { 
            get => _reservationRepository; 
            set => _reservationRepository = value; 
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string Key = null)
        {

            IEnumerable dataSource = await _reservationRepository!.GetReservationsAsync();

            // Handling search
            if (dataManagerRequest.Search != null && dataManagerRequest.Search.Count > 0)
            {
                dataSource = DataOperations.PerformSearching(dataSource, dataManagerRequest.Search);
            }

            int totalRecordsCount = dataSource.Cast<Reservation>().Count();

            // Handling paging
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
- The `DataOperations.PerformSearching()` method filters the data based on the search term.
- Results are returned and displayed in the DataGrid.

Searching feature is now active.

---

### Step 7: Implement Filtering feature

Filtering allows the user to restrict data based on column values using a menu interface.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Add the [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowFiltering) property and [GridFilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridFilterSettings.html) to the `<SfGrid>` component:

```cshtml
<SfGrid TValue="Reservation" 
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
    /// <summary>
    /// CustomAdaptor class to handle grid data operations with SQL Server using Entity Framework
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        public static ReservationRepository? _reservationRepository;
 
        public ReservationRepository? ReservationRepository 
        { 
            get => _reservationRepository; 
            set => _reservationRepository = value; 
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string Key = null)
        {

            IEnumerable dataSource = await _reservationRepository.GetReservationsAsync();

            // Handling search
            if (dataManagerRequest.Search != null && dataManagerRequest.Search.Count > 0)
            {
                dataSource = DataOperations.PerformSearching(dataSource, dataManagerRequest.Search);
            }

            // Handling filtering
            if (dataManagerRequest.Where != null && dataManagerRequest.Where.Count > 0)
            {
                dataSource = DataOperations.PerformFiltering(dataSource, dataManagerRequest.Where, dataManagerRequest.Where[0].Operator);
            }

            int totalRecordsCount = dataSource.Cast<Reservation>().Count();

            // Handling paging
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
- Results are filtered accordingly and displayed in the DataGrid.

Filtering feature is now active.

---

### Step 8: Implement Sorting feature

Sorting enables the user to arrange records in ascending or descending order based on column values.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Add the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) property to the `<SfGrid>` component:

```cshtml
<SfGrid TValue="Reservation" 
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
@code {
    public class CustomAdaptor : DataAdaptor
    {
        public static ReservationRepository? _reservationRepository;
 
        public ReservationRepository? ReservationRepository 
        { 
            get => _reservationRepository; 
            set => _reservationRepository = value; 
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string Key = null)
        {

            IEnumerable dataSource = await _reservationRepository.GetReservationsAsync();

            // Handling search
            if (dataManagerRequest.Search != null && dataManagerRequest.Search.Count > 0)
            {
                dataSource = DataOperations.PerformSearching(dataSource, dataManagerRequest.Search);
            }

            // Handling filtering
            if (dataManagerRequest.Where != null && dataManagerRequest.Where.Count > 0)
            {
                dataSource = DataOperations.PerformFiltering(dataSource, dataManagerRequest.Where, dataManagerRequest.Where[0].Operator);
            }

            // Handling sorting
            if (dataManagerRequest.Sorted != null && dataManagerRequest.Sorted.Count > 0)
            {
                dataSource = DataOperations.PerformSorting(dataSource, dataManagerRequest.Sorted);
            }

            int totalRecordsCount = dataSource.Cast<Reservation>().Count();

            // Handling paging
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

Sorting feature is now active.

---

### Step 9: Implement Grouping feature

Grouping organizes records into hierarchical groups based on column values.

**Instructions:**

1. Open the `Components/Pages/Home.razor` file.
2. Add the [AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowGrouping) property to the `<SfGrid>` component:

```cshtml
<SfGrid TValue="Reservation" 
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
@code {
    /// <summary>
    /// CustomAdaptor class to handle grid data operations with SQL Server using Entity Framework
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        public static ReservationRepository? _reservationRepository;
 
        public ReservationRepository? ReservationRepository 
        { 
            get => _reservationRepository; 
            set => _reservationRepository = value; 
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string Key = null)
        {

            IEnumerable dataSource = await _reservationRepository.GetReservationsAsync();

            // Handling search
            if (dataManagerRequest.Search != null && dataManagerRequest.Search.Count > 0)
            {
                dataSource = DataOperations.PerformSearching(dataSource, dataManagerRequest.Search);
            }

            // Handling filtering
            if (dataManagerRequest.Where != null && dataManagerRequest.Where.Count > 0)
            {
                dataSource = DataOperations.PerformFiltering(dataSource, dataManagerRequest.Where, dataManagerRequest.Where[0].Operator);
            }

            // Handling sorting
            if (dataManagerRequest.Sorted != null && dataManagerRequest.Sorted.Count > 0)
            {
                dataSource = DataOperations.PerformSorting(dataSource, dataManagerRequest.Sorted);
            }

            int totalRecordsCount = dataSource.Cast<Reservation>().Count();

           // Apply paging skip operation
            if (dataManagerRequest.Skip != 0)
            {
                dataSource = DataOperations.PerformSkip(dataSource, dataManagerRequest.Skip);
            }

            if (dataManagerRequest.Take != 0)
            {
                dataSource = DataOperations.PerformTake(dataSource, dataManagerRequest.Take);
            }

            // Handling Group operation in CustomAdaptor.
            if (dataManagerRequest.Group != null)
            {
                foreach (var group in dataManagerRequest.Group)
                {
                    dataSource = DataUtil.Group<Reservation>(dataSource, group, dataManagerRequest.Aggregates, 0, dataManagerRequest.GroupByFormatter);
                }
            }

            return dataManagerRequest.RequiresCounts 
                ? new DataResult() { Result = dataSource, Count = totalRecordsCount } 
                : (object)dataSource;
        }
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

CustomAdaptor methods enable users to create, read, update, and delete records directly from the DataGrid. Each operation calls corresponding data layer methods in **ReservationRepository.cs** to execute SQL commands through Dapper.

Add the Grid **EditSettings** and **Toolbar** configuration to enable create, read, update, and delete (CRUD) operations.

```cshtml
<SfGrid TValue="Reservation" 
        AllowPaging="true" 
        AllowSorting="true" 
        AllowFiltering="true" 
        AllowGrouping="true"
        Toolbar="@ToolbarItems">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
     <GridPageSettings PageSize="20"></GridPageSettings>
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

Record insertion allows new reservations to be added directly through the DataGrid component. The adaptor processes the insertion request, performs any required business‑logic validation, and saves the newly created record to the SQL Server database via Dapper.

In **Home.razor**, implement the `InsertAsync` method within the `CustomAdaptor` class:

```csharp
public class CustomAdaptor : DataAdaptor
{
     public override async Task<object> InsertAsync(DataManager dataManager, object value, string key)
    {
        await _reservationRepository!.AddReservationAsync(value as Reservation);
        return value;
    }
}
```

In **Data/ReservationRepository.cs**, the insert method is implemented as:

```csharp
public async Task AddReservationAsync(Reservation value)
{
    if (value == null)
        throw new ArgumentNullException(nameof(value), "Reservation cannot be null");

    if (string.IsNullOrEmpty(value.GuestName))
        throw new ArgumentException("Guest name is required", nameof(value));

    if (value.CheckInDate == null || value.CheckInDate == default)
    {
        value.CheckInDate = DateTime.Now;
    }

    string generatedReservationId = await GenerateReservationIdAsync();
    value.ReservationId = generatedReservationId;

    if (value.CheckInDate != default && value.CheckOutDate != default)
    {
        value.NoOfDays = CalculateNoOfDays((DateTime)value.CheckInDate, (DateTime)value.CheckOutDate);
    }

    if (value.AmountPerDay.HasValue && value.NoOfDays.HasValue && value.NoOfDays > 0)
    {
        value.TotalAmount = value.AmountPerDay.Value * value.NoOfDays.Value;
    }

    if (string.IsNullOrEmpty(value.PaymentStatus))
        value.PaymentStatus = "Pending";

    if (string.IsNullOrEmpty(value.ReservationStatus))
        value.ReservationStatus = "Confirmed";

    const string query = @"
        INSERT INTO [dbo].[Rooms] 
        (ReservationId, GuestName, GuestEmail, CheckInDate, CheckOutDate,
        RoomType, RoomNumber, AmountPerDay, NoOfDays, TotalAmount, PaymentStatus, ReservationStatus)
        VALUES 
        (@ReservationId, @GuestName, @GuestEmail, @CheckInDate, @CheckOutDate,
        @RoomType, @RoomNumber, @AmountPerDay, @NoOfDays, @TotalAmount, @PaymentStatus, @ReservationStatus)";

    await _connection.ExecuteAsync(query, value);
}

private async Task<string> GenerateReservationIdAsync()
{
    var existingReservations = await GetReservationsAsync();

    int maxNumber = existingReservations
        .Where(reservation => !string.IsNullOrEmpty(reservation.ReservationId) && reservation.ReservationId.StartsWith(ReservationIdPrefix))
        .Select(reservation =>
        {
            string numberPart = reservation.ReservationId.Substring((ReservationIdPrefix).Length);
            if (int.TryParse(numberPart, out int number))
                return number;
            return 0;
        })
        .DefaultIfEmpty(ReservationIdStartNumber - 1)
        .Max();

    int nextNumber = maxNumber + 1;
    string newReservationId = $"{ReservationIdPrefix}00{nextNumber}";

    return newReservationId;
}

private int CalculateNoOfDays(DateTime checkInDate, DateTime checkOutDate)
{
    TimeSpan dateDifference = checkOutDate.Date - checkInDate.Date;
    int noOfDays = (int)dateDifference.TotalDays;
    return noOfDays < 1 ? 1 : noOfDays;
}
```


**Helper methods explanation:**
- `GenerateReservationIdAsync()`: A new ReservationId is auto-generated using the current date and record count.
-  `CalculateNoOfDays()`: NoOfDays is calculated from check-in and check-out dates.

**What happens behind the scenes:**

1. The form data is collected and validated in the CustomAdaptor's `InsertAsync()` method.
2. The `ReservationRepository.AddReservationAsync()` method is called.
3. Dapper's `ExecuteAsync()` method executes the INSERT query with parameterized values.
4. The DataGrid automatically refreshes to display the new record.

Now the new reservation is persisted to the database and reflected in the grid.

**Update**

Record modification allows reservation details to be updated directly within the DataGrid. The adaptor processes the edited row, validates the updated values, and applies the changes to the **SQL Server database** via Dapper while ensuring data integrity is preserved.

In **Home.razor**, implement the `UpdateAsync` method within the `CustomAdaptor` class:

```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> UpdateAsync(DataManager dataManager, object value, string keyField, string key)
    {    
        await _reservationRepository!.UpdateReservationAsync(value as Reservation);
        return value;
    }
}
```

In **Data/ReservationRepository.cs**, the update method is implemented as:

```csharp
public async Task UpdateReservationAsync(Reservation value)
{
    try
    {
        if (value == null)
            throw new ArgumentNullException(nameof(value), "Reservation cannot be null");

        if (value.Id <= 0)
            throw new ArgumentException("Reservation ID must be valid", nameof(value));

        const string checkQuery = "SELECT COUNT(*) FROM [dbo].[Rooms] WHERE Id = @Id";
        var exists = await _connection.QueryFirstOrDefaultAsync<int>(checkQuery, new { value.Id });
        
        if (exists == 0)
            throw new KeyNotFoundException($"Reservation with ID {value.Id} not found");

        if (value.CheckInDate != default && value.CheckOutDate != default)
        {
            value.NoOfDays = CalculateNoOfDays((DateTime)value.CheckInDate, (DateTime)value.CheckOutDate);
        }

        if (value.AmountPerDay.HasValue && value.NoOfDays.HasValue && value.NoOfDays > 0)
        {
            value.TotalAmount = value.AmountPerDay.Value * value.NoOfDays.Value;
        }

        const string query = @"
            UPDATE [dbo].[Rooms]
            SET ReservationId = @ReservationId, GuestName = @GuestName, 
                GuestEmail = @GuestEmail, CheckInDate = @CheckInDate, CheckOutDate = @CheckOutDate,
                RoomType = @RoomType, RoomNumber = @RoomNumber, AmountPerDay = @AmountPerDay, 
                NoOfDays = @NoOfDays, TotalAmount = @TotalAmount, PaymentStatus = @PaymentStatus, 
                ReservationStatus = @ReservationStatus
            WHERE Id = @Id";

        await _connection.ExecuteAsync(query, value);
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error updating reservation: {ex.Message}");
        throw;
    }
}
```

**What happens behind the scenes:**

1. The modified data is collected from the form.
2. The CustomAdaptor's `UpdateAsync()` method is called.
3. The `ReservationRepository.UpdateReservationAsync()` method validates the reservation exists.
4. NoOfDays and TotalAmount are recalculated based on updated dates and amounts.
5. Dapper's `ExecuteAsync()` method executes the UPDATE query with parameterized values.
6. The DataGrid refreshes to display the updated record.

Now modifications are synchronized to the database and reflected in the grid UI.

**Delete**

Record deletion allows reservations to be removed directly from the DataGrid. The adaptor captures the delete request, executes the corresponding **SQL Server DELETE** operation via Dapper, and updates both the database and the grid to reflect the removal.

In **Home.razor**, implement the `RemoveAsync` method within the `CustomAdaptor` class:

```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> RemoveAsync(DataManager dataManager, object value, string? keyField, string key)
    {
        await _reservationRepository!.RemoveReservationAsync(value as int?);
        return value;
    }
}
```

In **Data/ReservationRepository.cs**, the delete method is implemented as:

```csharp
public async Task RemoveReservationAsync(int? key)
{
    try
    {
        if (key == null || key <= 0)
            throw new ArgumentException("Reservation ID cannot be null or invalid", nameof(key));

        const string checkQuery = "SELECT COUNT(*) FROM [dbo].[Rooms] WHERE Id = @Id";
        var exists = await _connection.QueryFirstOrDefaultAsync<int>(checkQuery, new { Id = key });
        
        if (exists == 0)
            throw new KeyNotFoundException($"Reservation with ID {key} not found");

        const string query = "DELETE FROM [dbo].[Rooms] WHERE Id = @Id";
        await _connection.ExecuteAsync(query, new { Id = key });
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error deleting reservation: {ex.Message}");
        throw;
    }
}
```

**What happens behind the scenes:**

1. The user selects a record and clicks "Delete".
2. A confirmation dialog appears (built into the DataGrid).
3. If confirmed, the CustomAdaptor's `RemoveAsync()` method is called.
4. The `ReservationRepository.RemoveReservationAsync()` method validates the reservation exists.
5. Dapper's `ExecuteAsync()` method executes the DELETE query.
6. The DataGrid refreshes to remove the deleted record from the UI.

Now reservations are removed from the database and the grid UI reflects the changes immediately.

**Batch update**

Batch operations combine multiple insert, update, and delete actions into a single request, minimizing network overhead and ensuring all changes are processed together to the SQL Server database via Dapper.

In **Home.razor**, implement the `BatchUpdateAsync` method within the `CustomAdaptor` class:

```csharp
public class CustomAdaptor : DataAdaptor
{
    public override async Task<object> BatchUpdateAsync(DataManager dataManager, object changed, object added, object deleted, string keyField, string key, int? dropIndex)
    {
        // Handle updated records
        if (changed != null && _reservationRepository != null)
        {
            foreach (var record in (IEnumerable<Reservation>)changed)
            {
                await _reservationRepository.UpdateReservationAsync(record);
            }
        }

        // Handle new records
        if (added != null && _reservationRepository != null)
        {
            foreach (var record in (IEnumerable<Reservation>)added)
            {
                await _reservationRepository.AddReservationAsync(record);
            }
        }

        // Handle deleted records
        if (deleted != null && _reservationRepository != null)
        {
            foreach (var record in (IEnumerable<Reservation>)deleted)
            {
                await _reservationRepository.RemoveReservationAsync(record.Id);
            }
        }
        return key;
    }
}
```
> This method is triggered when the DataGrid is operating in [Batch](https://blazor.syncfusion.com/documentation/datagrid/batch-editing) Edit mode.

**What happens behind the scenes:**

- The DataGrid collects all added, edited, and deleted records in Batch Edit mode.
- The combined batch request is passed to the CustomAdaptor's `BatchUpdateAsync()` method.
- Each modified record is processed using `ReservationRepository.UpdateReservationAsync()`.
- Each newly added record is saved using `ReservationRepository.AddReservationAsync()`.
- Each deleted record is removed using `ReservationRepository.RemoveReservationAsync()`.
- All repository operations persist changes to the SQL Server database via Dapper.
- The DataGrid refreshes to display the updated, added, and removed records in a single response.

Now the adaptor supports bulk modifications with database synchronization. All CRUD operations are now fully implemented, enabling comprehensive data management capabilities within the Blazor DataGrid.

**Reference links**

- [InsertAsync(DataManager, object)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_InsertAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_) - Create new records in SQL Server
- [UpdateAsync(DataManager, object, string, string)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_UpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) - Edit existing records in SQL Server
- [RemoveAsync(DataManager, object, string, string)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_RemoveAsync_Syncfusion_Blazor_DataManager_System_Object_System_String_System_String_) - Delete records from SQL Server
- [BatchUpdateAsync(DataManager, object, object, object, string, string, int?)](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataAdaptor.html#Syncfusion_Blazor_DataAdaptor_BatchUpdateAsync_Syncfusion_Blazor_DataManager_System_Object_System_Object_System_Object_System_String_System_String_System_Nullable_System_Int32__) - Handle bulk operations

---

## Step 11: Complete code

Here is the complete and final `Home.razor` component with all features integrated:

```cshtml
@page "/"
@rendermode InteractiveServer
@using Grid_Dapper.Data
@inject ReservationRepository ReservationService

<PageTitle>Reservation Management System</PageTitle>

<div class="container-fluid p-4">
    
    <!-- Syncfusion Blazor DataGrid Component -->
    <SfGrid TValue="Reservation" AllowSorting="true" AllowFiltering="true" AllowGrouping="true" AllowPaging="true"
        Height="500px" Width="100%" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" })">
        <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
        <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Menu"></GridFilterSettings>
        <GridEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true" Mode="EditMode.Normal"></GridEditSettings>
        <GridPageSettings PageSize="20"></GridPageSettings>
        <GridColumns>
            <GridColumn Field=@nameof(Reservation.Id) IsPrimaryKey="true" IsIdentity="true" Visible="false"></GridColumn>
            <GridColumn Field=@nameof(Reservation.ReservationId) HeaderText="Reservation ID" AllowAdding="false" AllowEditing="false" Width="170">
                <Template>
                    @{
                        var data = (Reservation)context;
                    }
                    <span class="badge badge-info">@data.ReservationId</span>
                </Template>
            </GridColumn>
            <GridColumn Field=@nameof(Reservation.GuestName) HeaderText="Guest Name" Width="160" ValidationRules="@(new ValidationRules { Required = true, MinLength = 3 })" EditType="EditType.DefaultEdit" />
            <GridColumn Field=@nameof(Reservation.GuestEmail) HeaderText="Email" Width="200" EditType="EditType.DefaultEdit" />
            <GridColumn Field=@nameof(Reservation.CheckInDate) HeaderText="Check-In" Width="140" Format="dd-MMM-yyyy" Type="ColumnType.Date" EditType="EditType.DatePickerEdit" />
            <GridColumn Field=@nameof(Reservation.CheckOutDate) HeaderText="Check-Out" Width="140" Format="dd-MMM-yyyy" Type="ColumnType.Date" EditType="EditType.DatePickerEdit" />
            <GridColumn Field=@nameof(Reservation.RoomType) HeaderText="Room Type" Width="130" EditType="EditType.DropDownEdit" EditorSettings="@RoomDropDownParams" />
            <GridColumn Field=@nameof(Reservation.RoomNumber) HeaderText="Room #" Width="120" EditType="EditType.DefaultEdit" />
            <GridColumn Field=@nameof(Reservation.AmountPerDay) HeaderText="Amount/Day" Width="140" Format="N2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" />
            <GridColumn Field=@nameof(Reservation.NoOfDays) HeaderText="Days" Width="140" TextAlign="TextAlign.Right" AllowEditing="false" />
            <GridColumn Field=@nameof(Reservation.TotalAmount) HeaderText="Total" Width="140" Format="N2" TextAlign="TextAlign.Right" AllowEditing="false" />
            <GridColumn Field=@nameof(Reservation.PaymentStatus) HeaderText="Payment" Width="110" EditType="EditType.DropDownEdit" EditorSettings="@PaymentDropDownParams">
                <Template>
                    @{
                        var status = (context as Reservation)?.PaymentStatus;
                        var badgeClass = status?.ToLower() switch
                        {
                            "paid" => "e-badge e-badge-success",
                            "pending" => "e-badge e-badge-warning",
                            "failed" => "e-badge e-badge-danger",
                            _ => "e-badge"
                        };
                    }
                    <span class="@badgeClass">@status</span>
                </Template>
            </GridColumn>
            <GridColumn Field=@nameof(Reservation.ReservationStatus) HeaderText="Status" Width="120" EditType="EditType.DropDownEdit" EditorSettings="@StatusDropDownParams">
                <Template>
                    @{
                        var status = (context as Reservation)?.ReservationStatus;
                        var badgeClass = status?.ToLower() switch
                        {
                            "confirmed" => "e-badge e-badge-success",
                            "pending" => "e-badge e-badge-warning",
                            "cancelled" => "e-badge e-badge-danger",
                            _ => "e-badge"
                        };
                    }
                    <span class="@badgeClass">@status</span>
                </Template>
            </GridColumn>
        </GridColumns>
    </SfGrid>
</div>
```

> * Set [IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsPrimaryKey) to **true** for a column that contains unique values.
> * Set [IsIdentity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsIdentity) to **true** for auto-generated columns to disable editing during add or update operations.
> * The [EditType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.EditType.html?_gl=1*4kxqtd*_gcl_au*ODcxNTU4MzMyLjE3Njc1ODkwOTk.*_ga*NjA2MTg0NzMuMTc1OTc1MDUyNg..*_ga_41J4HFMX1J*czE3Njk1MzE3NTAkbzY1JGcxJHQxNzY5NTMyOTMwJGo2MCRsMCRoMA..) property can be used to specify the desired editor for each column. [🔗](https://blazor.syncfusion.com/documentation/datagrid/edit-types)
> * The behavior of default editors can be customized using the [EditorSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_EditorSettings) property of the `GridColumn` component. [🔗](https://blazor.syncfusion.com/documentation/datagrid/edit-types#customizing-the-default-editors)
> * [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Type) property of the `GridColumn` component  specifies the data type of a grid column.
> * The [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html?_gl=1*8q6kap*_gcl_au*ODcxNTU4MzMyLjE3Njc1ODkwOTk.*_ga*NjA2MTg0NzMuMTc1OTc1MDUyNg..*_ga_41J4HFMX1J*czE3Njk1MzE3NTAkbzY1JGcxJHQxNzY5NTMzMDg0JGozMCRsMCRoMA..#Syncfusion_Blazor_Grids_GridColumn_Template) property that allows rendering custom elements in a column instead of the default field value. [🔗](https://blazor.syncfusion.com/documentation/datagrid/column-template)

```csharp
@code {
    private CustomAdaptor? _customAdaptor;

    protected override void OnInitialized()
    {
        // Initialize the CustomAdaptor with the injected ReservationRepository
        _customAdaptor = new CustomAdaptor { ReservationService = ReservationService };
    }

    /// <summary>
    /// CustomAdaptor class bridges DataGrid interactions with database operations using Dapper.
    /// </summary>
    public class CustomAdaptor : DataAdaptor
    {
        public static ReservationRepository? _reservationService;
        public ReservationRepository? ReservationService 
        { 
            get => _reservationService;
            set => _reservationService = value;
        }

        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string? key = null)
        {
            IEnumerable dataSource = await _reservationService!.GetReservationsAsync();

            if (dataManagerRequest.Search != null && dataManagerRequest.Search.Count > 0)
                dataSource = DataOperations.PerformSearching(dataSource, dataManagerRequest.Search);

            if (dataManagerRequest.Where != null && dataManagerRequest.Where.Count > 0)
                dataSource = DataOperations.PerformFiltering(dataSource, dataManagerRequest.Where, dataManagerRequest.Where[0].Operator);

            if (dataManagerRequest.Sorted != null && dataManagerRequest.Sorted.Count > 0)
                dataSource = DataOperations.PerformSorting(dataSource, dataManagerRequest.Sorted);

            int totalRecordsCount = dataSource.Cast<Reservation>().Count();

            if (dataManagerRequest.Skip != 0)
            {
                dataSource = DataOperations.PerformSkip(dataSource, dataManagerRequest.Skip);
            }

            if (dataManagerRequest.Take != 0)
            {
                dataSource = DataOperations.PerformTake(dataSource, dataManagerRequest.Take);
            }

            if (dataManagerRequest.Group != null)
            {
                foreach (var group in dataManagerRequest.Group)
                {
                    dataSource = DataUtil.Group<Reservation>(dataSource, group, dataManagerRequest.Aggregates, 0, dataManagerRequest.GroupByFormatter);
                }
            }

            return dataManagerRequest.RequiresCounts 
                ? new DataResult() { Result = dataSource, Count = totalRecordsCount } 
                : (object)dataSource;
        }

        public override async Task<object> InsertAsync(DataManager dataManager, object value, string? key)
        {
            await _reservationService!.AddReservationAsync(value as Reservation);
            return value;
        }

        public override async Task<object> UpdateAsync(DataManager dataManager, object value, string? keyField, string key)
        {
            await _reservationService!.UpdateReservationAsync(value as Reservation);
            return value;
        }

        public override async Task<object> RemoveAsync(DataManager dataManager, object value, string? keyField, string key)
        {
            await _reservationService!.RemoveReservationAsync(value as int?);
            return value;
        }

        public override async Task<object> BatchUpdateAsync(DataManager dataManager, object changedRecords, object addedRecords, object deletedRecords, string? keyField, string key, int? dropIndex)
        {
            if (changedRecords != null)
                foreach (var record in (IEnumerable<Reservation>)changedRecords)
                    await _reservationService!.UpdateReservationAsync(record as Reservation);

            if (addedRecords != null)
                foreach (var record in (IEnumerable<Reservation>)addedRecords)
                    await _reservationService!.AddReservationAsync(record as Reservation);

            if (deletedRecords != null)
                foreach (var record in (IEnumerable<Reservation>)deletedRecords)
                    await _reservationService!.RemoveReservationAsync((record as Reservation).Id);

            return key;
        }
    }

    /// <summary>
    /// Provides a list of room types used as a data source for the RoomType dropdown editor in the grid.
    /// </summary>
    private static List<Reservation> CustomRooms = new List<Reservation> {
        new Reservation() { RoomType = "Standard Room" },
        new Reservation() { RoomType = "Deluxe Room" },
        new Reservation() { RoomType = "Ocean View" },
        new Reservation() { RoomType = "Suite" },
        new Reservation() { RoomType = "Premium Suite" },
    };

    /// <summary>
    /// Provides a list of payment statuses used as a data source for the PaymentStatus dropdown editor in the grid.
    /// </summary>
    private static List<Reservation> CustomPaymentStatus = new List<Reservation> {
        new Reservation() { PaymentStatus = "Paid" },
        new Reservation() { PaymentStatus = "Pending" },
        new Reservation() { PaymentStatus = "Failed" },
    };

    /// <summary>
    /// Provides a list of reservation statuses used as a data source for the ReservationStatus dropdown editor in the grid.
    /// </summary>
    private static List<Reservation> CustomReservationStatus = new List<Reservation> {
        new Reservation() { ReservationStatus = "Confirmed" },
        new Reservation() { ReservationStatus = "Pending" },
        new Reservation() { ReservationStatus = "Cancelled" },
    };

    /// <summary>
    /// Dropdown editor settings configured with room type options for the RoomType column in grid edit mode.
    /// </summary>
    private IEditorSettings RoomDropDownParams = new DropDownEditCellParams
    {
        Params = new DropDownListModel<object, object>() { DataSource = CustomRooms, Query = new Syncfusion.Blazor.Data.Query() },
    };

    /// <summary>
    /// Dropdown editor settings configured with payment status options for the PaymentStatus column in grid edit mode.
    /// </summary>
    private IEditorSettings PaymentDropDownParams = new DropDownEditCellParams
    {
        Params = new DropDownListModel<object, object>() { DataSource = CustomPaymentStatus, Query = new Syncfusion.Blazor.Data.Query() },
    };

    /// <summary>
    /// Dropdown editor settings configured with reservation status options for the ReservationStatus column in grid edit mode.
    /// </summary>
    private IEditorSettings StatusDropDownParams = new DropDownEditCellParams
    {
        Params = new DropDownListModel<object, object>() { DataSource = CustomReservationStatus, Query = new Syncfusion.Blazor.Data.Query() },
    };
}
```
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
3. The reservation management application is now running and ready to use.

**Available Features**

- **View Data**: All reservations from the SQL Server database are displayed in the DataGrid.
- **Search**: Use the search box to find reservations by any field.
- **Filter**: Click on column headers to apply filters.
- **Sort**: Click on column headers to sort data in ascending or descending order.
- **Pagination**: Navigate through records using page numbers.
- **Add**: Click the "Add" button to create a new reservation.
- **Edit**: Click the "Edit" button to modify existing reservations.
- **Delete**: Click the "Delete" button to remove reservations.

---

## Complete Sample Repository

A complete, working sample implementation is available in the [GitHub repository](https://github.com/SyncfusionExamples/connecting-databases-to-blazor-datagrid-component/tree/master/Binding%20Dapper%20using%20CustomAdaptor).

---

## Summary

This guide demonstrates how to:
1. Create a SQL Server database with reservation records. [🔗](#step-1-create-the-database-and-table-in-sql-server)
2. Install necessary NuGet packages for Dapper and Syncfusion. [🔗](#step-2-install-required-nuget-packages)
3. Create data models for database mapping. [🔗](#step-3-create-the-data-model)
4. Configure connection strings for SQL Server. [🔗](#step-4-configure-the-connection-string)
5. Implement the repository pattern with Dapper for efficient data access. [🔗](#step-5-create-the-repository-class)
6. Create a Blazor component with a DataGrid that supports searching, filtering, sorting, paging, and CRUD operations. [🔗](#step-1-install-and-configure-blazor-datagrid-components)
7. Handle bulk operations and batch updates. [🔗](#step-10-perform-crud-operations)

The application now provides a complete solution for managing reservation data with a modern, user-friendly interface using Dapper for high-performance database access.