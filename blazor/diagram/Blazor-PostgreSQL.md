---
layout: post
title: Loading Blazor Diagram from PostgreSQL database | Syncfusion®
description: Fetch organizational-chart layout data from PostgreSQL and bind it to a .NET API-backed Syncfusion Blazor Diagram for Server and WASM samples.
platform: Blazor
control: Diagram
documentation: ug
---

# Loading a Syncfusion Blazor Diagram from PostgreSQL

This guide shows how the sample in this repository loads organizational-chart layout data from PostgreSQL and renders it with the Syncfusion Blazor Diagram component. It covers database creation, API backend, EF Core migrations, and how the Blazor Server and WASM projects consume the API.

> Note: The API returns objects with fields `id`, `parentId` (C#) / `parent_id` (DB) and `role`. The diagram's `DataSourceSettings` expects this parent–child shape.

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

Ensure the following software and packages are available:

| Software / Package | Version | Purpose |
|---|---|---|
| Visual Studio / Code | Latest | Development IDE with .NET workloads |
| .NET SDK | 10.0 or later | Build & run projects |
| PostgreSQL Server | 12.x or later | Stores org-chart data |
| pgAdmin 4 (optional) | Latest | DB management UI |
| Syncfusion.Blazor.Diagram | {{site.blazorversion}} | Diagram component |
| Syncfusion.Blazor.Themes | {{site.blazorversion}} | Styling for Syncfusion components |
| Microsoft.EntityFrameworkCore | 10.x | EF Core runtime |
| Npgsql.EntityFrameworkCore.PostgreSQL | 10.x | EF provider for PostgreSQL |

## Setting Up the PostgreSQL Environment for Entity Framework Core

You can create the database and table manually (pgAdmin/psql) or apply the EF Core migrations included in the Api project.

### Step 1: Create the database and Table in PostgreSQL

#### Option A — Manual (pgAdmin / psql)

First, the **PostgreSQL database** structure must be created to store purchase order records.

**UI Instructions (Using pgAdmin 4):**

1. **Open pgAdmin 4** and connect to the PostgreSQL server.
2. **Create Database**:
   - Right-click on **Databases** → Select **Create** → **Database**
   - Enter name: `org_chart_db`
   - Click **Save**
3. **Create Table**:
   - Expand `org_chart_db` → Right-click on **Schemas** → **public** → **Tables**
   - Click **Create** → **Table**
   - Enter table name: `org_chart_layout`
   - Define columns as per the script below
4. **Execute SQL Script** (Alternative method):
   - Right-click on `org_chart_db` → **Query Tool**
   - Copy and paste the SQL script below
   - Execute (F5 or Run button)

**SQL Script for PostgreSQL:**

```sql
-- Create Database
CREATE DATABASE org_chart_db

-- Connect to the database
\c org_chart_db;

-- Create PurchaseOrder Table
CREATE TABLE IF NOT EXISTS org_chart_layout (
  id text PRIMARY KEY,
  role text NOT NULL,
  parent_id text NULL
);

INSERT INTO org_chart_layout (id, role, parent_id) VALUES
('parent','Board',NULL),
('1','General Manager','parent')
ON CONFLICT (id) DO UPDATE SET role = EXCLUDED.role, parent_id = EXCLUDED.parent_id;

```

#### Option B — Automated (EF Core migrations + seed)

Apply the EF Core migrations included in the host project that contains `AppDbContext` (the Server host includes migrations by default). Update the connection string in the host's `appsettings.Development.json` and run migrations from that project directory.

Example (Blazor Server host):

```powershell
cd src/BlazorServerStyle
dotnet restore
dotnet build
dotnet ef database update
```

If you prefer the WASM host (it also contains the server + migrations), run:

```powershell
cd src/BlazorWASMStyle/BlazorWASMStyle
dotnet restore
dotnet build
dotnet ef database update
```

If `dotnet-ef` is not installed:

```powershell
dotnet tool install --global dotnet-ef
```

---

### Step 2: Install Required NuGet Packages

Before installing the necessary NuGet packages, a new Blazor Web Application must be created using the default template.
This template automatically generates essential starter files—such as **Program.cs, appsettings.json, the wwwroot folder, and the Components folder**.

For this guide, a Blazor application named **BlazorServerStyle** has been created. Once the project is set up, the next step involves installing the required NuGet packages. NuGet packages are software libraries that add functionality to the application. These packages enable Entity Framework Core and PostgreSQL integration.

**Method 1: Using Package Manager Console**

1. Open Visual Studio 2026.
2. Navigate to **Tools → NuGet Package Manager → Package Manager Console**.
3. Run the following commands:

```powershell
Install-Package Microsoft.EntityFrameworkCore -Version 10.0.2; 
Install-Package Npgsql.EntityFrameworkCore.PostgreSQL -Version 10.0.0; 
Install-Package Syncfusion.Blazor.Diagram -Version {{site.blazorversion}}; 
Install-Package Syncfusion.Blazor.Themes -Version {{site.blazorversion}}
```

**Method 2: Using NuGet Package Manager UI**

1. Open **Visual Studio 2026 → Tools → NuGet Package Manager → Manage NuGet Packages for Solution**.
2. Search for and install each package individually:
   - **Microsoft.EntityFrameworkCore** (version 10.0.2 or later)
   - **Npgsql.EntityFrameworkCore.PostgreSQL** (version 10.0.0 or later)
   - **[Syncfusion.Blazor.Diagram](https://www.nuget.org/packages/Syncfusion.Blazor.Diagram/)** (version {{site.blazorversion}})
   - **[Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)** (version {{site.blazorversion}})

**Project File Reference**

The installed packages are reflected in the **BlazorServerStyle.csproj** file:

```xml
<ItemGroup>
    <PackageReference Include="Microsoft.EntityFrameworkCore" Version="10.0.2" />
    <PackageReference Include="Npgsql.EntityFrameworkCore.PostgreSQL" Version="10.0.0" />
    <PackageReference Include="Syncfusion.Blazor.Diagram" Version="*" />
    <PackageReference Include="Syncfusion.Blazor.Themes" Version="*" />
</ItemGroup>
```

All required packages are now installed.

### Step 3: Create the Data Model

A data model is a C# class that represents the structure of a database table. This model defines the properties that correspond to the columns in the `LayoutNode` table.

**Instructions:**

1. Create a new folder named `Models` in the Blazor application project.
2. Inside the `Models` folder, create a new file named **LayoutNode.cs**.
3. Define the **LayoutNode** class with the following code:

```csharp
using System.ComponentModel.DataAnnotations;

namespace BlazorServerStyle.Models;

public class LayoutNode
{
    public string Id { get; set; } = null!;
    public string? ParentId { get; set; }
    public string Role { get; set; } = null!;
}
```

**Explanation:**
- Each property represents a column in the database table.
- The `?` symbol indicates that a property is nullable (can be empty).
- The model includes comprehensive XML documentation for each property.

The data model has been successfully created.

### Step 4: Configure the DbContext

A `DbContext` is a special class that manages the connection between the application and the PostgreSQL database. It handles all database operations such as saving, updating, deleting, and retrieving data.

**Instructions:**

1. Inside the `Data` folder, create a new file named **AppDbContext.cs**.
2. Define the `AppDbContext` class with the following code:

```csharp
using Microsoft.EntityFrameworkCore;
using BlazorServerStyle.Models;  // Or your namespace

namespace BlazorServerStyle.Data;

public class AppDbContext : DbContext
{
    public DbSet<LayoutNode> OrgChartLayouts { get; set; } = null!;

    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<LayoutNode>()
            .ToTable("org_chart_layout")
            .HasKey(n => n.Id);

        modelBuilder.Entity<LayoutNode>()
            .Property(n => n.ParentId)
            .HasColumnName("parent_id");

        modelBuilder.Entity<LayoutNode>()
            .Property(n => n.Role)
            .HasColumnName("role")
            .IsRequired();

        modelBuilder.Entity<LayoutNode>()
            .HasIndex(n => n.ParentId);

        // Seed data
        modelBuilder.Entity<LayoutNode>().HasData(
            new LayoutNode { Id = "parent", ParentId = null, Role = "Board" },
            new LayoutNode { Id = "1",      ParentId = "parent", Role = "General Manager" },
            new LayoutNode { Id = "2",      ParentId = "1",      Role = "Human Resource Manager" },
            new LayoutNode { Id = "3",      ParentId = "2",      Role = "Trainers" },
            new LayoutNode { Id = "4",      ParentId = "2",      Role = "Recruiting Team" },
            new LayoutNode { Id = "5",      ParentId = "2",      Role = "Finance Asst. Manager" },
            new LayoutNode { Id = "6",      ParentId = "1",      Role = "Design Manager" },
            new LayoutNode { Id = "7",      ParentId = "6",      Role = "Design Supervisor" },
            new LayoutNode { Id = "8",      ParentId = "6",      Role = "Development Supervisor" },
            new LayoutNode { Id = "9",      ParentId = "6",      Role = "Drafting Supervisor" },
            new LayoutNode { Id = "10",     ParentId = "1",      Role = "Operations Manager" },
            new LayoutNode { Id = "11",     ParentId = "10",     Role = "Statistics Department" },
            new LayoutNode { Id = "12",     ParentId = "10",     Role = "Logistics Department" },
            new LayoutNode { Id = "16",     ParentId = "1",      Role = "Marketing Manager" },
            new LayoutNode { Id = "17",     ParentId = "16",     Role = "Overseas Sales Manager" },
            new LayoutNode { Id = "18",     ParentId = "16",     Role = "Petroleum Manager" },
            new LayoutNode { Id = "20",     ParentId = "16",     Role = "Service Department Manager" },
            new LayoutNode { Id = "21",     ParentId = "16",     Role = "Quality Control Department" }
        );
    }
}
```

**Explanation:**
- The `DbContext` class inherits from Entity Framework's `DbContext` base class.
- The `OrgChartLayouts` property represents the `org_chart_layout` table in the database.
- The `OnModelCreating` method configures how the database columns should behave (maximum length, required/optional, default values, data types, indexes, etc.).
- Database indexes are configured for improved query performance on frequently accessed columns.

The **AppDbContext** class is required because:

- It **connects** the application to the PostgreSQL database.
- It **manages** all database operations.
- It **maps** C# models to actual database tables.
- It **configures** how data should look inside the database.
- It **enables** PostgreSQL-specific features like indexes and default value functions.

Without this class, Entity Framework Core will not know where to save data or how to create the org_chart_layout table. The DbContext has been successfully configured.

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

### Step 6: Create the LayoutService Class

A LayoutService class is an intermediary layer that handles all database operations. This class uses Entity Framework Core to communicate with the PostgreSQL database.

**Instructions:**

1. Inside the `Data` folder, create a new file named **LayoutService.cs**.
2. Define the **LayoutService** class with the following code:

```csharp
using BlazorServerStyle.Models;
using System.Net.Http.Json;

namespace Services;   // change namespace for WASM project

public class LayoutService
{
    private readonly HttpClient _http;

    public LayoutService(HttpClient http)
    {
        _http = http;
    }

    public async Task<List<LayoutNode>?> GetOrgChartAsync()
    {
        return await _http.GetFromJsonAsync<List<LayoutNode>>("api/layout");
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
using BlazorServerStyle.Components;
using Syncfusion.Blazor;
using Services;
using Microsoft.EntityFrameworkCore;
using BlazorServerStyle.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped<LayoutService>();
builder.Services.AddHttpClient<LayoutService>("Api", client =>
{
    client.BaseAddress = new Uri("http://localhost:5069/");   // ← change to your actual API HTTP port (from dotnet run output)
});
// Add controllers and EF DbContext
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseStatusCodePagesWithReExecute("/not-found", createScopeForStatusCodePages: true);
app.UseHttpsRedirection();

app.UseAntiforgery();

app.UseAuthorization();

app.MapControllers();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
```

**Explanation:**

- **`AddSyncfusionBlazor()`**: Registers Syncfusion Blazor components (Diagram, themes, etc.).
- **`AddDbContext<AppDbContext>`**: Registers the DbContext with PostgreSQL as the database provider using `UseNpgsql()`.
- **Connection String Validation**: Ensures the connection string is configured before attempting to connect.
- **`AddScoped<LayoutService>`**: Registers the repository as a scoped service, creating a new instance for each HTTP request.
- **`AddRazorComponents()` and `AddInteractiveServerComponents()`**: Enables Blazor server-side rendering with interactive components.

The service registration has been completed successfully.

---

## Integrating Syncfusion Blazor Diagram

### Step 1: Install and Configure Blazor Diagram Component

Syncfusion is a library that provides pre-built UI components like Diagram, which is used to display data as a diagram.

**Instructions:**

* The Syncfusion.Blazor.Diagram package was installed in **Step 2** of the previous section.
* Import the required namespaces in the `Components/_Imports.razor` file:

```csharp
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Diagram
```

* Add the Syncfusion stylesheet and scripts in the `Components/App.razor` file. Find the `<head>` section and add:

```html
<!-- Syncfusion Blazor Stylesheet -->
<link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />

<!-- Syncfusion Blazor Scripts -->
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
```
For this project, the bootstrap5 theme is used. A different theme can be selected or the existing theme can be customized based on project requirements. Refer to the [Syncfusion Blazor Components Appearance](https://blazor.syncfusion.com/documentation/appearance/themes) documentation to learn more about theming and customization options.

Syncfusion components are now configured and ready to use. For additional guidance, refer to the Diagram component's [getting-started](https://blazor.syncfusion.com/documentation/diagram/getting-started-with-web-app) documentation.

### Step 2: Update the Blazor Diagram

The `Home.razor` component will display the data in a Syncfusion Blazor Diagram Organization chart.

**Instructions:**

1. Open the file named `Home.razor` in the `Components/Pages` folder.
2. Add the following code to create a Diagram:

```cshtml
@page "/"
@using Services
@using Syncfusion.Blazor.Diagram
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Inputs
@using BlazorServerStyle.Models
@inject LayoutService LayoutService

@if (loading)
{
    <p>Loading organizational chart...</p>
}
else if (!string.IsNullOrEmpty(errorMessage))
{
    <div style="color: red;">Error: @errorMessage</div>
}
else if (_dataSource == null || !_dataSource.Any())
{
    <p>No data available</p>
}
else
{
    <SfDiagramComponent ID="OrgChartDiagram" @ref="_diagram" Width="100%" Height="1000px" NodeCreating="@OnNodeCreating" ConnectorCreating="@OnConnectorCreating">
        <DataSourceSettings ID="Id" ParentID="ParentId" DataSource="@_dataSource"></DataSourceSettings>
        <SnapSettings>
            <HorizontalGridLines LineColor="white" LineDashArray="2,2">
            </HorizontalGridLines>
            <VerticalGridLines LineColor="white" LineDashArray="2,2">
            </VerticalGridLines>
        </SnapSettings>
        <Layout Type="LayoutType.OrganizationalChart" @bind-HorizontalSpacing="@_horizontalSpacing" @bind-VerticalSpacing="@_verticalSpacing">
        </Layout>
    </SfDiagramComponent>
}
@code
{
    //Initializing layout.
    private int _horizontalSpacing = 40;
    private int _verticalSpacing = 50;

    //Creates node with some default values.
    private void OnNodeCreating(IDiagramObject obj)
    {
        Node node = obj as Node;
        node.Height = 50;
        node.Width = 150;
        LayoutNode Data = node.Data as LayoutNode;
        node.Annotations = new DiagramObjectCollection<ShapeAnnotation>(){
            new ShapeAnnotation(){
                Content = Data.Role,
            }
        };
        node.Style = new ShapeStyle() { Fill = "#6495ED", StrokeWidth = 1, StrokeColor = "Black" };
    }

    //Creates connectors with some default values.
    private void OnConnectorCreating(IDiagramObject connector)
    {
        Connector connectors = connector as Connector;
        connectors.Type = ConnectorSegmentType.Orthogonal;
        connectors.Style = new TextStyle() { StrokeColor = "#6495ED", StrokeWidth = 1 };
        connectors.TargetDecorator = new DecoratorSettings
        {
            Shape = DecoratorShape.None,
            Style = new ShapeStyle() { Fill = "#6495ED", StrokeColor = "#6495ED", }
        };
    }
    private List<LayoutNode>? _dataSource;
    private bool loading = true;
    private string? errorMessage;
    private SfDiagramComponent _diagram;

    protected override async Task OnInitializedAsync()
    {
        try
        {
            _dataSource = await LayoutService.GetOrgChartAsync();
        }
        catch (Exception ex)
        {
            errorMessage = ex.Message;
        }
        finally
        {
            loading = false;
        }

        await base.OnInitializedAsync();
    }
}
```

**Component Explanation:**

- **`@inject LayoutService`**: Injects the repository to access database methods.
- **`<SfDiagramComponent>`**: The Diagram component that displays data as layout.
- **`<DataSourceSettings>`**: Represents the settings that specify the data source and define how the parent and child relationship will be generated in the diagram layout.
- **`<SnapSettings>`**: Customize and control the grid lines and snap behavior of the diagram.
- **`<Layout>`**: Class for arranging the nodes and connectors in a tree structure.

The Home component has been updated successfully with Diagram.

---

## Run the sample locally

1. Ensure PostgreSQL is running and reachable; update the `DefaultConnection` in the host project's `appsettings.Development.json`.

2. Apply migrations and seed (choose the host project that contains `Migrations`):

```powershell
dotnet tool install --global dotnet-ef
cd src/BlazorServerStyle
dotnet restore
dotnet build
dotnet ef database update
```

3. Run the Server host (this project also exposes the API endpoints at `/api/layout`):

```powershell
cd src/BlazorServerStyle
dotnet run
```

By default the Server app uses the launch settings shown in `BlazorServerStyle/Properties/launchSettings.json` and will be available on `http://localhost:5069` (HTTP) and `https://localhost:7269` (HTTPS).

4. Or run the WASM host (which serves the client and hosts the API):

```powershell
cd src/BlazorWASMStyle/BlazorWASMStyle
dotnet run
```

Typical WASM host URLs in this workspace are `http://localhost:5252` and `https://localhost:7042` .

5. Open the app in a browser and navigate to the Home page — the organizational chart should load from the host's `/api/layout` endpoint and render via the Syncfusion Blazor Diagram.

## Troubleshooting

- API connection errors: confirm PostgreSQL is running and `appsettings.Development.json` contains correct credentials.
- CORS errors: check CORS configuration in `Program.cs` and ensure the Blazor host origin is allowed.
- No data in diagram: open `/api/layout` in a browser or Postman to confirm JSON is returned; verify `LayoutService` base address.

## Next steps / customization

- Change API origin: update CORS in `Program.cs` and `LayoutService` base address in the Blazor hosts.
- Modify seed data: edit `AppDbContext.OnModelCreating()` and create a new migration:

```powershell
cd src/Api
dotnet ef migrations add UpdateSeed
dotnet ef database update
```

- Explore Syncfusion Diagram properties to alter templates, orientation, spacing, or styles.

---

## Complete Sample Repository

A complete, working sample implementation is available in the [GitHub repository](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/Samples/OrganizationalChartPostgresql).

## Summary

This guide demonstrates how to:

1. Create a PostgreSQL database with layout Nodes using pgAdmin 4. [🔗](#step-1-create-the-database-and-table-in-postgresql)
2. Install necessary NuGet packages for Entity Framework Core with Npgsql and Syncfusion. [🔗](#step-2-install-required-nuget-packages)
3. Create data models and DbContext for database communication with PostgreSQL-specific configuration. [🔗](#step-3-create-the-data-model)
4. Configure connection strings and register services. [🔗](#step-5-configure-the-connection-string)
5. Implement the repository pattern for data access with helper methods. [🔗](#step-6-create-the-LayoutService-class)
6. Create a Blazor component with a Diagram that visualizes data as a Organization layout. [🔗](#step-1-install-and-configure-blazor-Diagram-component)


The application now provides a complete solution for visualizing data from as a organization chart layout integrated with PostgreSQL.

## See also

- Data Binding: https://blazor.syncfusion.com/documentation/diagram/data-binding#how-to-specify-parent-child-relationship-in-data-source
- Organizational Chart Layout: https://blazor.syncfusion.com/documentation/diagram/layout/organizational-chart
