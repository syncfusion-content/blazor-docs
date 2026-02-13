---

layout: post
title: Blazor Chart connected to SQLite via Dapper | Syncfusion
description: Learn how to bind SQLite data to Syncfusion Blazor Charts using Dapper.
platform: Blazor
control: Chart
documentation: ug

---

# Connecting SQLite to Blazor Chart Using Dapper


This guide explains how to connect a **SQLite database** to the **Syncfusion Blazor Charts** component using **Dapper**, a micro‑ORM known for its simplicity and performance. You will learn how to set up the database, retrieve data using Dapper, and display the results as interactive column chart.  
Each step is explained in detail to help beginners and experienced developers alike understand the purpose, reasoning, and expected output

**What is Dapper?**

Dapper is a lightweight ORM library developed by the StackExchange team. Unlike full‑scale ORMs such as Entity Framework, Dapper focuses solely on **performance and simplicity**, making it ideal for scenarios where:

- You want to write **your own SQL queries**
- You need **fast execution** with minimal overhead
- You prefer **manual control** over database operations  
- You want **automatic mapping** from SQL rows to C# objects

Because it operates on top of ADO.NET, Dapper maintains near‑native performance while adding a convenient abstraction for parameter binding and result mapping.

**Key Benefits of Dapper**

Each benefit plays a crucial role in applications dealing with Chart visualizations:

### **High Performance**  
Dapper has almost no overhead. It runs SQL queries directly using ADO.NET under the hood, ensuring fast data access even when working with large datasets used in chart data.

### **SQLite Control**  
Since SQLite is a lightweight, file‑based database, Dapper’s raw SQL approach provides full control over the schema, queries, and indexing—helpful when handling chart data.

### **Simple and Lightweight**  
There is no change tracking or lazy loading. You work directly with SQL, making it a minimalistic and predictable solution ideal for projects where performance matters more than ORM automation.

### **Flexible Mapping**  
Dapper charts query results to C# classes without configuration, letting you easily bind database results such as name, SnapChartValues to the Chart component.

### **Built-in Security**  
By default, Dapper uses parameterized SQL commands, offering protection against SQL injection—especially when you use parameterized queries.

## Prerequisites

Ensure the following software and packages are installed before proceeding:

| Software/Package | Version | Purpose |
|-----------------|---------|---------|
| Visual Studio 2026 | 18.0 or later | Development IDE with Blazor workload |
| .NET SDK | net8.0 or compatible | Runtime and build tools |
| Syncfusion.Blazor.Charts | {{site.blazorversion}} | Chart and UI components |
| Syncfusion.Blazor.Themes | {{site.blazorversion}} | Styling for Chart components |
| Microsoft.Data.Sqlite | Latest | SQL Server ADO.NET provider |
| Dapper | Latest | Lightweight micro-ORM for SQL mapping |

> Note: Install these tools and packages before you begin. The examples target .NET 8 and Visual Studio 2026, but the core code works with compatible .NET versions.

### Step 1: Create the Blazor Server Project

1. File ▸ New ▸ Project → Blazor Server App
2. Project name: Chart_Dappers
3. Framework: .NET 8.0 or later
4. Authentication: None
5. Create.

### Step 2: Install Required NuGet Packages

Before installing the necessary NuGet packages, a new Blazor Web Application must be created using the default template.
This template automatically generates essential starter files—such as **Program.cs, the wwwroot folder, and the Components folder**.

For this guide, a Blazor application named **Chart_Dappers** has been created. Once the project is set up, the next step involves installing the required NuGet packages. NuGet packages are software libraries that add functionality to the application. These packages enable Dapper and SQL Server integration.

**Method 1: Using Package Manager Console**

1. Open Visual Studio 2026.
2. Navigate to **Tools → NuGet Package Manager → Package Manager Console**.
3. Run the following commands:

> Explanation: Run the following commands in the Package Manager Console to add the SQLite provider, Dapper, and Syncfusion packages to your project.

```powershell
Install-Package Microsoft.Data.Sqlite -Version Latest
Install-Package Dapper -Version Latest
Install-Package Syncfusion.Blazor.Charts -Version {{site.blazorversion}}
Install-Package Syncfusion.Blazor.Themes -Version {{site.blazorversion}}
```

**Method 2: Using NuGet Package Manager UI**

1. Open **Visual Studio 2026 → Tools → NuGet Package Manager → Manage NuGet Packages for Solution**.
2. Search for and install each package individually:
   - **Microsoft.Data.Sqlite** (Latest version)
   - **Dapper** (Latest version)
   - **[Syncfusion.Blazor.Charts](https://www.nuget.org/packages/Syncfusion.Blazor.Charts/)** (version {{site.blazorversion}})
   - **[Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)** (version {{site.blazorversion}})

All required packages are now installed.

### Step 3: Add Syncfusion to the App

**Method 1: Register Syncfusion in Program.cs**

> Register Syncfusion and your DB services in the dependency injection container. `AddSyncfusionBlazor()` enables Syncfusion components across the app. The `IDbConnectionFactory` and `ICityRepository` registrations make database access injectable.

```
using Syncfusion.Blazor;
using Microsoft.Data.Sqlite; // for SQLite provider

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor(); // register Syncfusion components

// Add a DB connection.
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

> The connection factory centralizes SQLite access, creates the database file if missing, and seeds initial data the first time the app runs. This keeps file and schema creation out of business logic.

```


using System.Data;
using Microsoft.Data.Sqlite;

namespace Charts_Dappers.Services
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
        string DbPath { get; }
    }

    public class SqliteConnectionFactory : IDbConnectionFactory
    {
        public string DbPath { get; }

        public SqliteConnectionFactory(IWebHostEnvironment env)
        {
            // Put the SQLite file in the app content root: ./Data/cities.db
            DbPath = Path.Combine(env.ContentRootPath, "Data", "cities.db");
            Directory.CreateDirectory(Path.GetDirectoryName(DbPath)!);
            EnsureDatabase();
        }

        public IDbConnection CreateConnection()
            => new SqliteConnection($"Data Source={DbPath}");

        private void EnsureDatabase()
        {
            var needSeed = !File.Exists(DbPath);
            using var conn = new SqliteConnection($"Data Source={DbPath}");
            conn.Open();
            using var cmd = conn.CreateCommand();
            cmd.CommandText = @"
            CREATE TABLE IF NOT EXISTS Cities(
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                SnapChartValues INTEGER NULL
            );";
            cmd.ExecuteNonQuery();

            if (needSeed)
            {
                using var insert = conn.CreateCommand();
                insert.CommandText = @"
                INSERT INTO Cities (Name, SnapChartValues) VALUES
                ('United States', 102),
                ('India', 28),
                ('United Kingdom', 18),
                ('Mexico', 16),
                ('Japan', 31),
                ('Mexico', 26),
                ('Brazil', 13),
                ('Germany', 11),
                ('Russia', 8),
                ('Philippines', 8),
                ('Iraq', 7),
                ('Egypt', 7);";
                insert.ExecuteNonQuery();
            }
        }
    }
}

```
### Step 5: Dapper Model and Repository

**City Model**

Represents data stored in the SQLite table. Each property corresponds to a column in the database. The model is used for strongly‑typed mapping when binding to the Charts component.

Create Models/City.cs:

> This is a simple POCO (Plain Old CLR Object) model. Dapper will map query columns to these properties by name.

```
public class City
{
    public long Id { get; set; }
    public string Name { get; set; } = default!;
    public int? SnapChartValues { get; set; }
}
```
**Repository (Dapper)**

Encapsulates all SQL operations related to city data.  
In this example, the repository:

- Opens a SQLite connection
- Fetches all city rows
- Uses Dapper to chart them into a `List<City>`
- Returns them to the UI layer

This ensures clean separation between database logic and UI components.

Create Services/CityRepository.cs:

> The repository uses Dapper's `QueryAsync<T>` to execute a SQL query and map the results to `City` objects. Keeping SQL in the repository makes it easier to test and maintain.

```
public interface ICityRepository
{
    Task<IEnumerable<City>> GetAllAsync(CancellationToken ct = default);
}

public class CityRepository : ICityRepository
{
    private readonly IDbConnectionFactory _factory;

    public CityRepository(IDbConnectionFactory factory)
    {
        _factory = factory;
    }

    public async Task<IEnumerable<City>> GetAllAsync(CancellationToken ct = default)
    {
        using var conn = _factory.CreateConnection();
        var sql = "SELECT Id, Name, SnapChartValues FROM Cities ORDER BY Name;";
        return await conn.QueryAsync<City>(sql);
    }
}
```


> Note: `QueryAsync<City>` is an extension method from Dapper. No ORM tracking is performed — the returned `IEnumerable<City>` is a plain result set mapped to objects.

### Step 6: Add the Syncfusion Charts Component

This step integrates the data from SQLite directly into the Syncfusion Charts.

### **How It Works**

- The repository retrieves all city records from SQLite.
- The data is stored in the `cities` collection during component initialization.
- The Charts Data uses:
  - **Name**
  - **SnapChartValues**
  
Tooltips are enabled to show the city name and user's count when hovered.

Create a page Pages/Home.razor:

> This Razor page injects the repository, fetches the `cities` on initialization, and binds them to an `SfChart` series. The X axis uses `Name` and the Y axis uses `SnapChartValues`.

```
@rendermode InteractiveServer
@using Syncfusion.Blazor.Charts
@using Charts_Dappers.Services
@inject ICityRepository Repo

<SfChart Title="Snapchart Social Media Users">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@cities" XName="Name" YName="SnapChartValues" Type="ChartSeriesType.Column"></ChartSeries>
    </ChartSeriesCollection>
    <ChartTooltipSettings Enable="true" Format="${point.x} : ${point.y}M users"></ChartTooltipSettings>
</SfChart>

@code {

    private IEnumerable<City>? cities;
    private City newCity = new();
    protected override async Task OnInitializedAsync()
    {
        cities = await Repo.GetAllAsync();
    }
}
```
How markers are bound: We set DataSource="cities" where each City object contains Name and SnapChartValues.

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
3. After running, the Syncfusion Chart renders with markers taken directly from SQLite, confirming full integration between the chart UI and the database backend using Dapper.

### Summary

1. A new Blazor Server project is created using .NET 8 in Visual Studio. [🔗](#step-1-Create-the-Blazor-Server-Project)
2. Required NuGet packages are installed: SQLite provider, Dapper, Syncfusion Blazor Charts, and Syncfusion Themes. [🔗](#step-2-Install-Required-NuGet-Packages)
3. Syncfusion services are registered in Program.cs, and the appropriate theme stylesheet is added to the project. [🔗](#step-3-Add-Syncfusion-to-the-App)
4. A SQLite database setup is implemented through a connection factory, which creates the database file, generates the Cities table, and seeds initial sample data on first run. [🔗](#step-4-Create-the-SQLite-Database)
5. A City model is defined, and a Dapper-based repository retrieves city records from the SQLite database. [🔗](#step-5-Dapper-Model-and-Repository)
6. The Syncfusion Charts component is added to a Razor page, binding database data to chart using Name and SnapChartValues values. [🔗](#step-6-Add-the-Syncfusion-Charts-Component)
7. The application is built and executed, displaying a Column chart in the browser with markers sourced directly from the SQLite database. [🔗](#step-7-Running-the-Application)