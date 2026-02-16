---

layout: post
title: Blazor Maps connected to SQLite via Dapper | Syncfusion
description: A step‑by‑step guide to binding SQLite data to Syncfusion Blazor Maps using Dapper, covering setup, database creation, and data binding.
platform: Blazor
control: Maps
documentation: ug

---

# Connecting SQLite to Blazor Maps Using Dapper


This guide explains how to connect a **SQLite database** to the **Syncfusion Blazor Maps** component using **Dapper**, a micro‑ORM known for its simplicity and performance. You will learn how to set up the database, retrieve data using Dapper, and display the results as interactive map markers.  
Each step is explained in detail to help beginners and experienced developers alike understand the purpose, reasoning, and expected output

**What is Dapper?**


Dapper is a lightweight ORM library developed by the StackExchange team. Unlike full‑scale ORMs such as Entity Framework, Dapper focuses solely on **performance and simplicity**, making it ideal for scenarios where:

- You want to write **your own SQL queries**
- You need **fast execution** with minimal overhead
- You prefer **manual control** over database operations  
- You want **automatic mapping** from SQL rows to C# objects

Because it operates on top of ADO.NET, Dapper maintains near‑native performance while adding a convenient abstraction for parameter binding and result mapping.

**Key Benefits of Dapper**

Each benefit plays a crucial role in applications dealing with map visualizations:

### **High Performance**  
Dapper has almost no overhead. It runs SQL queries directly using ADO.NET under the hood, ensuring fast data access even when working with large datasets used in map layers or marker clustering.

### **SQLite Control**  
Since SQLite is a lightweight, file‑based database, Dapper’s raw SQL approach provides full control over the schema, queries, and indexing—helpful when handling geo-location data.

### **Simple and Lightweight**  
There is no change tracking or lazy loading. You work directly with SQL, making it a minimalistic and predictable solution ideal for projects where performance matters more than ORM automation.

### **Flexible Mapping**  
Dapper maps query results to C# classes without configuration, letting you easily bind database results such as latitude, longitude, and marker values to the Maps component.

### **Built-in Security**  
By default, Dapper uses parameterized SQL commands, offering protection against SQL injection—especially when you use parameterized queries.

## Prerequisites

Ensure the following software and packages are installed before proceeding:

| Software/Package | Version | Purpose |
|-----------------|---------|---------|
| Visual Studio 2026 | 18.0 or later | Development IDE with Blazor workload |
| .NET SDK | net8.0 or compatible | Runtime and build tools |
| Syncfusion.Blazor.Maps | {{site.blazorversion}} | Maps and UI components |
| Syncfusion.Blazor.Themes | {{site.blazorversion}} | Styling for Maps components |
| Microsoft.Data.Sqlite | Latest | SQL Server ADO.NET provider |
| Dapper | Latest | Lightweight micro-ORM for SQL mapping |

### Step 1: Create the Blazor Server Project

1. File ▸ New ▸ Project → Blazor Server App
2. Project name: Maps_Dappers
3. Framework: .NET 8.0 or later
4. Authentication: None
5. Create.

### Step 2: Install Required NuGet Packages

Before installing the necessary NuGet packages, a new Blazor Web Application must be created using the default template.
This template automatically generates essential starter files—such as **Program.cs, the wwwroot folder, and the Components folder**.

For this guide, a Blazor application named **Maps_Dappers** has been created. Once the project is set up, the next step involves installing the required NuGet packages. NuGet packages are software libraries that add functionality to the application. These packages enable Dapper and SQL Server integration.

**Method 1: Using Package Manager Console**

1. Open Visual Studio 2026.
2. Navigate to **Tools → NuGet Package Manager → Package Manager Console**.
3. Run the following commands:

```powershell
Install-Package Microsoft.Data.Sqlite -Version Latest
Install-Package Dapper -Version Latest
Install-Package Syncfusion.Blazor.Maps -Version {{site.blazorversion}}
Install-Package Syncfusion.Blazor.Themes -Version {{site.blazorversion}}
```

**Method 2: Using NuGet Package Manager UI**

1. Open **Visual Studio 2026 → Tools → NuGet Package Manager → Manage NuGet Packages for Solution**.
2. Search for and install each package individually:
   - **Microsoft.Data.Sqlite** (Latest version)
   - **Dapper** (Latest version)
   - **[Syncfusion.Blazor.Maps](https://www.nuget.org/packages/Syncfusion.Blazor.Maps/)** (version {{site.blazorversion}})
   - **[Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)** (version {{site.blazorversion}})

All required packages are now installed.

### Step 3: Add Syncfusion to the App

**Method 1: Register Syncfusion in Program.cs**

```
using Syncfusion.Blazor;
using Microsoft.Data.Sqlite; // for SQLite provider

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor(); // register Syncfusion components

// Register app-specific services:
// - IDbConnectionFactory: creates SQLite connections and ensures DB file exists
// - ICityRepository: Dapper-based repository for fetching City records
builder.Services.AddSingleton<IDbConnectionFactory, SqliteConnectionFactory>();
builder.Services.AddScoped<ICityRepository, CityRepository>();

```
**Method 2: Add Syncfusion CSS**
In Pages/Component/App.razor, in the <head> section add the theme CSS. Either use a CDN or local package css:

```
<link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
```

### Step 4: Create the SQLite Database

**Create a Data folder and add a DB file**

1. Create folder: Data
2. We’ll create the database and table on first run if it’s missing.

**Connection factory**

Create Services/DbConnectionFactory.cs:

```
using System.Data;
using Microsoft.Data.Sqlite;

namespace Maps_Dappers.Services
{
    // Factory interface to create IDbConnection instances and expose DB path
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
        string DbPath { get; }
    }

    // Implementation that creates a SQLite file in the app content root
    // and ensures the schema and seed data exist on first run.
    public class SqliteConnectionFactory : IDbConnectionFactory
    {
        public string DbPath { get; }

        public SqliteConnectionFactory(IWebHostEnvironment env)
        {
            // Put the SQLite file in the app content root: ./Data/cities.db
            DbPath = Path.Combine(env.ContentRootPath, "Data", "cities.db");
            // Ensure the Data folder exists before attempting to create the file
            Directory.CreateDirectory(Path.GetDirectoryName(DbPath)!);
            // Create DB file, tables and seed rows if missing
            EnsureDatabase();
        }

        // Create a new SQLite connection using the file path
        public IDbConnection CreateConnection()
            => new SqliteConnection($"Data Source={DbPath}");

        private void EnsureDatabase()
        {
            // needSeed = true when DB file didn't exist before
            var needSeed = !File.Exists(DbPath);
            using var conn = new SqliteConnection($"Data Source={DbPath}");
            conn.Open();
            using var cmd = conn.CreateCommand();
            // Create table if it doesn't already exist. This is safe to run every startup.
            cmd.CommandText = @"
            CREATE TABLE IF NOT EXISTS Cities(
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                SnapChartValues INTEGER NULL,
                Latitude REAL NOT NULL,
                Longitude REAL NOT NULL
            );";
            cmd.ExecuteNonQuery();

            if (needSeed)
            {
                using var insert = conn.CreateCommand();
                // Seed a small set of sample cities. This only runs when the DB file is new.
                insert.CommandText = @"
                INSERT INTO Cities (Name, SnapChartValues, Latitude, Longitude) VALUES
                ('United States', 102, 38.9072, -77.0369),
                ('India', 28, 28.6139, 77.2090),
                ('United Kingdom', 18, 51.5074, -0.1278),
                ('Mexico', 16, 19.4326, -99.1332),
                ('Japan', 31, 35.6762, 139.6503),
                ('Mexico', 26, 19.4326, -99.1332),
                ('Brazil', 13, -15.7939, -47.8828),
                ('Germany', 11, 52.5200, 13.4050),
                ('Russia', 8, 55.7558, 37.6173),
                ('Philippines', 8, 14.5995, 120.9842),
                ('Iraq', 7, 33.3152, 44.3661),
                ('Egypt', 7, 30.0444, 31.2357);";
                insert.ExecuteNonQuery();
            }
        }
    }
}
```
### Step 5: Dapper Model and Repository

**City Model**

Represents data stored in the SQLite table. Each property corresponds to a column in the database. The model is used for strongly‑typed mapping when binding to the Maps component.

Create Models/City.cs:

```
// POCO model that maps to the Cities table columns
public class City
{
    // Primary key (SQLite INTEGER PRIMARY KEY maps to long)
    public long Id { get; set; }

    // Display name for the location (not nullable)
    public string Name { get; set; } = default!;

    // Geographic coordinates used by the Maps marker layer
    public double Latitude { get; set; }
    public double Longitude { get; set; }

    // Optional numerical value used for custom visualizations (nullable)
    public int? SnapChartValues { get; set; }
}
```
**Repository (Dapper)**

Encapsulates all SQL operations related to city data.  
In this example, the repository:

- Opens a SQLite connection
- Fetches all city rows
- Uses Dapper to map them into a `List<City>`
- Returns them to the UI layer

This ensures clean separation between database logic and UI components.

Create Services/CityRepository.cs:

```
// Repository abstraction for city data retrieval using Dapper
public interface ICityRepository
{
    // Returns all City rows. Cancellation token is optional for async calls.
    Task<IEnumerable<City>> GetAllAsync(CancellationToken ct = default);
}

// Simple Dapper-based implementation of ICityRepository
public class CityRepository : ICityRepository
{
    private readonly IDbConnectionFactory _factory;

    public CityRepository(IDbConnectionFactory factory)
    {
        // Injected factory ensures we create connections consistently
        _factory = factory;
    }

    public async Task<IEnumerable<City>> GetAllAsync(CancellationToken ct = default)
    {
        // Create and open a connection from the factory. Using statement ensures disposal.
        using var conn = _factory.CreateConnection();
        var sql = "SELECT Id, Name, SnapChartValues, Latitude, Longitude FROM Cities ORDER BY Name;";
        // Dapper will map rows directly to the City POCO properties
        return await conn.QueryAsync<City>(sql);
    }
}
```

### Step 6: Add the Syncfusion Map Component

This step integrates the data from SQLite directly into the Syncfusion Map.

### **How It Works**

- The map loads **world-map.json**, a common world map shape file.
- The repository retrieves all city records from SQLite.
- The data is stored in the `cities` collection during component initialization.
- The Markers layer uses:
  - **Latitude**
  - **Longitude**
  - **Name**
  - **SnapChartValues** (optional custom value)

Each database entry becomes a real marker on the map.  
Tooltips are enabled to show the city name when hovered.


Create a page Pages/Home.razor:

```
@using Maps_Dappers.Services
@inject ICityRepository Repo

<SfMaps>
    <MapsZoomSettings Enable="true">
    </MapsZoomSettings>
    <MapsLayers>
        <MapsLayer ShapeData='new { dataOptions = "https://cdn.syncfusion.com/maps/map-data/world-map.json" }' TValue="string" AnimationDuration="2000">
            <MapsMarkerSettings>
                <MapsMarker DataSource="@cities" Visible="true" Height="25" Width="25" TValue="City" EnableDrag="true" AnimationDuration="0" >
                    <MapsMarkerTooltipSettings Visible="true" ValuePath="Name"></MapsMarkerTooltipSettings>
                </MapsMarker>
            </MapsMarkerSettings>
            <MapsShapeSettings Fill="lightgray"></MapsShapeSettings>
        </MapsLayer>
    </MapsLayers>
</SfMaps>

@code {

    // Holds the markers fetched from the database
    private IEnumerable<City>? cities;
    // Example newCity instance (could be used for adding new markers)
    private City newCity = new();

    protected override async Task OnInitializedAsync()
    {
        // Load all city rows during component initialization
        cities = await Repo.GetAllAsync();
    }
}
```
How markers are bound: We set DataSource="cities" where each City object contains Latitude and Longitude.

### Step 7: Running the Application

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
3. After running, the Syncfusion Map renders with markers taken directly from SQLite, confirming full integration between the map UI and the database backend using Dapper.

### Summary

1. A new Blazor Server project is created using .NET 8 in Visual Studio. [🔗](#step-1-Create-the-Blazor-Server-Project)
2. Required NuGet packages are installed: SQLite provider, Dapper, Syncfusion Blazor Maps, and Syncfusion Themes. [🔗](#step-2-Install-Required-NuGet-Packages)
3. Syncfusion services are registered in Program.cs, and the appropriate theme stylesheet is added to the project. [🔗](#step-3-Add-Syncfusion-to-the-App)
4. A SQLite database setup is implemented through a connection factory, which creates the database file, generates the Cities table, and seeds initial sample data on first run. [🔗](#step-4-Create-the-SQLite-Database)
5. A City model is defined, and a Dapper-based repository retrieves city records from the SQLite database. [🔗](#step-5-Dapper-Model-and-Repository)
6. The Syncfusion Maps component is added to a Razor page, loading world map shapes and binding database data to map markers using latitude and longitude values. [🔗](#step-6-Add-the-Syncfusion-Map-Component)
7. The application is built and executed, displaying a world map in the browser with markers sourced directly from the SQLite database. [🔗](#step-7-Running-the-Application)
