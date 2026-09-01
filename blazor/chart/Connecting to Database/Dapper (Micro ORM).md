---
layout: post
title: Data Integration in Blazor Charts Using Dapper and SQLite
description: This document demonstrates how to integrate Syncfusion Blazor Charts (SfChart) with a SQLite database using Dapper. The application retrieves data from a SQLite database through a repository layer and visualizes it using a column chart.
platform: Blazor
control: Chart
documentation: ug
---

# Data Integration in Blazor Charts Using Dapper and SQLite

## What is Dapper?
Dapper is a lightweight, high-performance Micro ORM (Object Relational Mapper) for .NET. It simplifies database access by executing SQL queries and automatically mapping query results to C# objects.
Unlike traditional ADO.NET, which requires manual data reading and object mapping, Dapper reduces boilerplate code and provides a simpler way to retrieve data from relational databases such as:

* SQL Server
* SQLite
* PostgreSQL
* MySQL
* Oracle

## Prerequisites
Before proceeding, ensure the following are installed:

* .NET 8 or later
* Visual Studio 2026
* Syncfusion Blazor NuGet packages
* Dapper NuGet package
* Microsoft.Data.Sqlite package

## Step 1: Create a Blazor Web App

Create a new Blazor Web App project.

## Step 2: Install Required NuGet Packages

Install the following packages:

* dotnet add package Syncfusion.Blazor
* dotnet add package Dapper
* dotnet add package Microsoft.Data.Sqlite

## Step 3: Create the Model Class

Create a folder named Services and add a model class named City.cs.

```c#
namespace Charts_Dappers.Services
{
    public class City
    {
        public long Id { get; set; }

        public string Name { get; set; } = default!;

        public int? SnapChartValues { get; set; }
    }
}
```

### Purpose
This model represents records stored in the database table.

## Step 4: Create a Database Connection Factory

Create a file named DbConnectionFactory.cs and implement a interface.

``
using System.Data;

namespace Charts_Dappers.Services
{
    public interface IDbConnectionFactory
    {
        IDbConnection CreateConnection();
        string DbPath { get; }
    }
}
``

using Microsoft.Data.Sqlite;
using System.Data;

namespace Charts_Dappers.Services
{
    public class SqliteConnectionFactory : IDbConnectionFactory
    {
        public string DbPath { get; }

        public SqliteConnectionFactory(IWebHostEnvironment env)
        {
            DbPath = Path.Combine(env.ContentRootPath, "Data", "cities.db");

            Directory.CreateDirectory(Path.GetDirectoryName(DbPath)!);

            EnsureDatabase();
        }

        public IDbConnection CreateConnection()
            => new SqliteConnection($"Data Source={DbPath}");
    }
}
``

### Purpose
The connection factory centralizes database connection creation throughout the application.

## Step 5: Create and Seed the SQLite Database

Inside the EnsureDatabase() method, create the database schema.

``
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
}
``
### Purpose
This creates the Cities table if it does not already exist.

Seed Sample Data
Add the following sample records:
``
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
    ('Brazil', 13),
    ('Germany', 11),
    ('Russia', 8),
    ('Philippines', 8),
    ('Iraq', 7),
    ('Egypt', 7);";

    insert.ExecuteNonQuery();
}
``
### Purpose
The sample data is inserted when the database is created for the first time. These records will be retrieved using Dapper and displayed in the Syncfusion Blazor Chart.

## Step 6: Create a Repository Using Dapper

Create a file named CityRepository.cs.

Define the Repository Interface

``
using Dapper;

namespace Charts_Dappers.Services
{
    public interface ICityRepository
    {
        Task<IEnumerable<City>> GetAllAsync(
            CancellationToken ct = default);
    }
}
``

Implement the Repository

``
using Dapper;

namespace Charts_Dappers.Services
{
    public class CityRepository : ICityRepository
    {
        private readonly IDbConnectionFactory factory;

        public CityRepository(IDbConnectionFactory factory)
        {
            this.factory = factory;
        }

        public async Task<IEnumerable<City>> GetAllAsync(
            CancellationToken ct = default)
        {
            using var conn = factory.CreateConnection();

            var sql = @"
                SELECT Id,
                       Name,
                       SnapChartValues
                FROM Cities
                ORDER BY Name";

            return await conn.QueryAsync<City>(sql);
        }
    }
}
``

### Purpose
This repository uses Dapper's QueryAsync<T>() method to retrieve data from the SQLite database and automatically map the result set to City objects.

## Step 7: Register Services

Open Program.cs and register the required services.

``
builder.Services.AddSyncfusionBlazor();

builder.Services.AddSingleton<IDbConnectionFactory,SqliteConnectionFactory>();

builder.Services.AddScoped<ICityRepository,CityRepository>();
``

## Step 8: Create a Blazor Page

Open Home.razor.

Add the following namespaces and dependency injection.

``
@page "/"

@rendermode InteractiveServer

@using Syncfusion.Blazor.Charts
@using Charts_Dappers.Services

@inject ICityRepository Repo
``

## Step 9: Load Data Using Dapper

Add the following code section.

``
@code {

    private IEnumerable<City> cities =
        Enumerable.Empty<City>();

    protected override async Task OnInitializedAsync()
    {
        cities = await Repo.GetAllAsync();
    }
}
``

## Step 10: Bind Data to the Syncfusion Blazor Chart

Add the following chart component.

```cshtml
<SfChart Title="Snapchat Social Media Users">

    <ChartPrimaryXAxis
        ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>

        <ChartSeries DataSource="@cities"
                     XName="Name"
                     YName="SnapChartValues"
                     Type="ChartSeriesType.Column">

            <ChartMarker>
                <ChartDataLabel Visible="true"></ChartDataLabel>
            </ChartMarker>

        </ChartSeries>

    </ChartSeriesCollection>

    <ChartTooltipSettings Enable="true"
                          Format="${point.x} : ${point.y}M users">
    </ChartTooltipSettings>

</SfChart>
```

Run the Application by ``dotnet run``, then chart displays social media user statistics for different countries using data retrieved from a SQLite database through Dapper.

# Conclusion

This example demonstrates how Dapper can be used as a lightweight data access layer to retrieve records from a SQLite database and visualize them using the Syncfusion Blazor Chart component. Dapper executes SQL queries and maps results to C# objects, while SfChart consumes those objects through its DataSource property to create interactive data visualizations.