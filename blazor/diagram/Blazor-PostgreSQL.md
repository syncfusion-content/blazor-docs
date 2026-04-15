---
layout: post
title: Loading Blazor Diagram from PostgreSQL database | Syncfusion®
description: Fetch organizational chart layout data from PostgreSQL and bind it to a .NET API-backed Syncfusion® Blazor Diagram for Server and WASM samples.
platform: Blazor
control: Diagram
documentation: ug
---

# Loading Blazor Diagram from PostgreSQL Database

This guide explains how to display an organizational chart using data stored in a PostgreSQL database and visualize it with the Syncfusion® Blazor Diagram component.

It covers:
* Design and store organizational chart data in a database.
* Connect the application to the database using Entity Framework Core.
* Make the data available through a backend API.
* Display the organizational chart in Blazor Server and Blazor WebAssembly (WASM) applications.

> **Note**: The REST API must to return an array of JSON objects with **id**, **parent_id**, and **role** fields for correct data binding.

**What is Entity Framework Core?**

Entity Framework Core (EF Core) is a software tool that simplifies database operations in .NET applications. It acts as a bridge between C# code and databases such as PostgreSQL.

**Key Benefits of Entity Framework Core**

- **Automatic SQL Generation**: Entity Framework Core generates optimized SQL queries automatically, eliminating the need to write raw SQL code.
- **Type Safety**: Work with strongly typed C# objects instead of SQL strings, which helps reduce runtime errors.
- **Built-in Security**: Automatic query parameterization helps protect applications from SQL injection attacks.
- **Database Versioning with Migrations**: Database schema changes can be tracked, applied, and rolled back using migrations.
- **Familiar Syntax**: LINQ (Language Integrated Query) provides a readable and intuitive way to query data using C#.

**What is Npgsql Entity Framework Core Provider?**

The **Npgsql.EntityFrameworkCore.PostgreSQL** package is the official Entity Framework Core provider for PostgreSQL. It acts as a bridge between Entity Framework Core and PostgreSQL, allowing applications to read, write, update, and delete data in a PostgreSQL database.

## Prerequisites

Ensure that the following software and packages are installed:

| Software / Package | Version | Purpose |
|---|---|---|
| Visual Studio / Code | Latest | Development IDE with .NET workloads |
| .NET SDK | 10.0 or later | Build & run projects |
| PostgreSQL Server | 12.x or later | Stores organizational chart data |
| pgAdmin 4 (optional) | Latest | DB management UI |
| Syncfusion.Blazor.Diagram | {{site.blazorversion}} | Diagram component |
| Syncfusion.Blazor.Themes | {{site.blazorversion}} | Styling for Syncfusion® Blazor components |
| Microsoft.EntityFrameworkCore.Design | 10.x | EF Core runtime |
| Microsoft.EntityFrameworkCore.Tools | 10.x | EF Core runtime |
| Npgsql.EntityFrameworkCore.PostgreSQL | 10.x | EF provider for PostgreSQL |

## Installing PostgreSQL

Download PostgreSQL from the official website: [https://www.postgresql.org/download/](https://www.postgresql.org/download/)

**Installation Steps:**

1. Download the installer for the preferred version (12.x or higher recommended)
2. Run the installer and follow the setup wizard
3. During installation:
  - Set a password for the PostgreSQL (example: **postgres123**) and remember it.
  - Keep the default port **5432**.
  - Next, the Select Components screen will open.
  - By default, all options are selected, as shown in the image:
    ![Select Components](images/select-component-Package.png)
  - Uncheck the **Stack Builder** option — it is not necessary for this setup.
  - Ensure **PostgreSQL Server**, **pgAdmin 4**, and **Command Line Tools** are selected.
4. Complete the installation.


## PostgreSQL Database Setup

Two options are available to create a database:
  * Manual (pgAdmin 4)
  * Automated initialization and seeding (seed script).

### Option A: Manual (pgAdmin 4)

#### Opening pgAdmin

PostgreSQL includes pgAdmin 4, a graphical tool for database management. Open pgAdmin 4 from the Windows Start menu or application launcher.

![Opening pgAdmin 4](images/pgadmin-start.jpg)

#### Creating the Database

Right-click on **Databases** option and select **Create** → **Database**.

![Create Database Menu](images/create-database-menu.png)

In the **Create - Database** dialog:
1. Enter **org_chart_db** as the database name. 
2. Click **Save** to create the database.

![Database Creation Dialog](images/database-creation-dialog.png)

After creating the database, right-click the **org_chart_db** database and choose **Query Tool** from the context menu.

**Quick procedure before running SQL:**

- Clear the editor (Ctrl+A → Delete) to remove any previous statements.
- Enter the SQL, then click **Execute / Execute Query** (or press **F5**) to run it.
- After execution, clear the editor again before entering the next statement.

Follow this simple sequence for every SQL in this guide.

#### Creating the Table

Run the following SQL to create the **org_chart_layout** table:

```sql
CREATE TABLE IF NOT EXISTS org_chart_layout (
  id text PRIMARY KEY,
  role text NOT NULL,
  parent_id text NULL
);
```
![Create Table Query](images/create-table-query.jpg)

The table structure includes:
- **id** - Primary key for unique node identification.
- **role** - Display text for the node in the organizational chart layout.
- **parent_id** - Foreign key reference to the parent node (NULL for root).

#### Inserting Sample Data

Add organizational chart data using the SQL **INSERT** statement. The sample data shows a typical organizational structure with board, management, and department levels.

```sql
INSERT INTO org_chart_layout (id, role, parent_id) VALUES
('parent', 'Board', NULL),
('1', 'General Manager', 'parent'),
('2', 'Human Resource Manager', '1'),
('3', 'Trainers', '2'),
('4', 'Recruiting Team', '2'),
('5', 'Finance Asst. Manager', '2'),
('6', 'Design Manager', '1'),
('7', 'Design Supervisor', '6'),
('8', 'Development Supervisor', '6'),
('9', 'Drafting Supervisor', '6'),
('10', 'Operations Manager', '1'),
('11', 'Statistics Department', '10'),
('12', 'Logistics Department', '10'),
('16', 'Marketing Manager', '1'),
('17', 'Overseas Sales Manager', '16'),
('18', 'Petroleum Manager', '16'),
('20', 'Service Department Manager', '16'),
('21', 'Quality Control Department', '16')
ON CONFLICT (id) DO UPDATE
SET role = EXCLUDED.role,
    parent_id = EXCLUDED.parent_id;
```

![Insert Data Query](images/insert-data-query.jpg)

#### Verifying Data Insertion

Run a **SELECT** query to confirm the data insertion:

```sql
SELECT * FROM org_chart_layout ORDER BY id;
```

The query should return 18 rows. Parent–child relationships are indicated by the **parent_id** column, which references the **id** of the parent node (NULL for root nodes).

![Verify Data Query Results](images/verify-data-results.jpg)

### Option B — Automated (EF Core migrations + seed)

This project includes an automated initialization script that handles database creation, table schema generation, and data seeding in one command.  

The script performs the following operations:
1. **Dynamic Database Provisioning**: Detects if the database exists and creates it automatically.
2. **Schema Generation**: Creates the **org_chart_layout** table with the required primary keys and organizational relationships.
3. **Data Seeding**: Populates the table with organizational data from a JSON source.

The implementation details for the automated initialization script are covered in the [Automated database initialization and seeding](#step-8-automated-database-initialization-and-seeding) section under Backend Implementation.
---

## Backend Implementation

### Step 1: Install Required NuGet Packages

Before installing the necessary NuGet packages, a new Blazor Web Application must be created using the default template. For full step-by-step instructions on creating a Blazor project, see the getting-started guide: [Getting Started](https://blazor.syncfusion.com/documentation/diagram/getting-started).

For this guide, a Blazor application named **BlazorServerStyle** has been created. Once the project is set up, the next step involves installing the required NuGet packages. These packages enable Entity Framework Core and PostgreSQL integration.

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

**Method 3: Using Integrated Terminal in Visual Studio Code**

Install NuGet packages from the VS Code terminal (run these from the project folder):

```powershell
dotnet add package Microsoft.EntityFrameworkCore --version 10.0.2
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL --version 10.0.0
dotnet add package Syncfusion.Blazor.Diagram --version <your-syncfusion-version>
dotnet add package Syncfusion.Blazor.Themes --version <your-syncfusion-version>
```

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

### Step 2: Create the Data Model

A data model is a C# class that represents the structure of a database table. This model defines the properties that correspond to the columns in the **org_chart_layout** table.

**Instructions:**

1. Create a new folder named `Models` in the Blazor application project.
2. Inside the `Models` folder, create a new file named `LayoutNode.cs`.
3. Define the `LayoutNode` class with the following code:

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

The data model is now ready. This model represents the structure of the **org_chart_layout** table and will be used by the **DbContext** in the next step.

### Step 3: Configure the DbContext

A `DbContext` is a special class that manages the connection between the Blazor application and the PostgreSQL database. It handles all database operations such as saving, updating, deleting, and retrieving data.

**Instructions:**

1. Create a new folder named `Data` in the Blazor application project.
2. Inside the `Data` folder, create a new file named `AppDbContext.cs`.
3. Define the `AppDbContext` class with the following code:

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
- The AppDbContext class connects the Blazor application to the PostgreSQL database.
- It maps the LayoutNode model to the org_chart_layout table.
- Column mappings, required fields, and table structure are configured in OnModelCreating.
- An index is added on the parent_id column to improve performance when loading hierarchical data.
- Sample organizational chart data is seeded so the diagram has data to display.

### Step 4: Configure the Connection String

A connection string contains the information needed to connect the application to the PostgreSQL database, including the server address, database name, and authentication credentials.

**Instructions:**

1. Open the `appsettings.json` file in the project root.
2. Update the `ConnectionStrings` section with the PostgreSQL connection details:

```json
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=5432;Database=org_chart_db;User Id=postgres;Password=postgresql@123"
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
| Database | The database name (for this guide, **org_chart_db**) |
| User Id | The PostgreSQL username (default is `postgres`) |
| Password | The password for the PostgreSQL user account |


> **Security Note:** For production environments, store sensitive credentials in environment variables or Azure Key Vault instead of storing them in appsettings.json. Example: `Password=${DB_PASSWORD}` and set the environment variable `DB_PASSWORD` on the deployment server.

The connection string is now configured. When the application starts, `AddDbContext<AppDbContext>` (registered in Program.cs, Step 7 below) will use this string to connect to PostgreSQL.

### Step 5: Create the API Controller

The `LayoutService` calls a `/api/layout` endpoint that must exist on the host. Create a controller file (e.g., **Controllers/LayoutController.cs**) in the host project to expose this endpoint:

```csharp
using BlazorServerStyle.Data;
using BlazorServerStyle.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BlazorServerStyle.Controllers;

[ApiController]
[Route("api/[controller]")]
public class LayoutController : ControllerBase
{
    private readonly AppDbContext _db;
    
    public LayoutController(AppDbContext db) => _db = db;

    [HttpGet]
    public async Task<IActionResult> Get() => Ok(await _db.OrgChartLayouts.ToListAsync());
}
```

**Explanation:**
- `[ApiController]` and `[Route("api/[controller]")]` expose the endpoint at `/api/layout`.
- `[HttpGet]` handles GET requests.
- The method queries `OrgChartLayouts` from the database and returns JSON.

After starting the host (see "Run the sample locally" section), verify the endpoint by opening `http://localhost:5069/api/layout` in a browser (adjust port if different). The controller exposes database data as JSON that the Blazor UI can consume. The Blazor **Home.razor** component will use `LayoutService` to call this endpoint and bind the data to the Diagram.

### Step 6: Create the LayoutService Class

A `LayoutService` class is an HTTP client wrapper that calls the API endpoint to fetch layout nodes. The Blazor component injects this service to load data from the host's `/api/layout` endpoint.

**Instructions:**

1. Inside the `Data` folder, create a new file named `LayoutService.cs`.
2. Define the `LayoutService` class with the following code:

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
The service class has been created. This keeps HTTP logic out of UI components. This service calls the API endpoint `/api/layout` to fetch organizational chart data. It will be injected into the Blazor component (Step 2 under "Integrating Syncfusion® Blazor Diagram") and registered in the next step (Step 7).


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
builder.Services.AddHttpClient<LayoutService>("Api", client =>
{
    client.BaseAddress = new Uri("http://localhost:5069/");   // ← use the port shown in dotnet run output or launchSettings.json
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

- **`AddSyncfusionBlazor()`**: Registers Syncfusion® Blazor components (Diagram, themes, etc.).
- **`AddDbContext<AppDbContext>`**: Registers the DbContext with PostgreSQL as the database provider using `UseNpgsql()`.
- **Connection String Validation**: Ensures the connection string is configured before attempting to connect.
- **`AddScoped<LayoutService>`**: Registers the repository as a scoped service, creating a new instance for each HTTP request.
 - **`AddHttpClient<LayoutService>(...)`**: Registers an `HttpClient` for `LayoutService` using `HttpClientFactory`; ensure `client.BaseAddress` matches the API host so `LayoutService` calls `api/layout` correctly.
- **`AddRazorComponents()` and `AddInteractiveServerComponents()`**: Enables Blazor server-side rendering with interactive components.

Service registration is complete. The host can now:
- Use `AppDbContext` to access the database via the connection string (Step 4).
- Handle HTTP requests via `AddControllers()`.
- Provide `LayoutService` to Blazor components to fetch data from the API.

Next, create the API controller to expose the `/api/layout` endpoint that `LayoutService` calls.

### Step 8: Automated Database Initialization and Seeding
This section explains the automated database initialization and seeding process that creates the database, applies the schema, and populates the initial organizational chart data.

Apply the EF Core migrations included in the host project that contains `AppDbContext` (the Server host includes migrations by default). Update the connection string in the host's **appsettings.Development.json** and run migrations from that project directory.

Example (Blazor Server host):

```powershell
cd src/BlazorServerStyle
dotnet restore
dotnet build
dotnet ef migrations add InitialCreate
dotnet ef database update
```

If you prefer the WASM host (it also contains the server + migrations), run:

```powershell
cd src/BlazorWASMStyle/BlazorWASMStyle
dotnet restore
dotnet build
dotnet ef migrations add InitialCreate
dotnet ef database update
```

If the database does not exist, `dotnet ef database update` (with proper DB server access) will create the database and apply the migration that defines the `orgchart_layout` table and seed rows (the seed is configured with **HasData** in the `AppDbContext`). If `dotnet ef` is not installed, install it with:

```powershell
dotnet tool install --global dotnet-ef
```
Running the commands above creates the database schema (including **org_chart_layout** table) and applies the seed data defined in `OnModelCreating()`. After successful migration, the database is ready for the application.

Alternatively create the DB manually (Option A) and then run `dotnet ef database update` to create schema and seed.
---

**Backend is now complete.** You have a PostgreSQL database, EF Core models, a DbContext, migrations, service registration in Program.cs, and an API controller. The next section sets up the Blazor frontend to consume this API and display the Diagram.

## Rendering the Blazor Diagram component

### Step 1: Install and Configure Blazor Diagram Component

Syncfusion® Blazor provides pre-built UI components. The Diagram component visualizes hierarchical data (parent–child relationships) as an organizational chart layout.

**Instructions:**

* The Syncfusion.Blazor.Diagram package was installed in **Step 2** of the previous section.
* Import the required namespaces in the **Components/_Imports.razor** file:

```csharp
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Diagram
```

* Add the Syncfusion® stylesheet and scripts to your host page head so assets load before components render. Use the host file for your project type:

- Blazor Server: add the links to **Pages/app.razor** (inside the `<head>` element).
- Blazor WebAssembly: add the links to **wwwroot/index.html** (inside the `<head>` element).

Example links to add inside the host `<head>`:

```html
<!-- Syncfusion Blazor Stylesheet -->
<link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />

<!-- Syncfusion Blazor Scripts -->
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
```
For this project, the bootstrap5 theme is used. A different theme can be selected or the existing theme can be customized based on project requirements. Refer to the [Syncfusion Blazor Components Appearance](https://blazor.syncfusion.com/documentation/appearance/themes) documentation to learn more about theming and customization options.

Syncfusion® components are now configured and ready to use. For additional guidance, refer to the Diagram component's [getting-started](https://blazor.syncfusion.com/documentation/diagram/getting-started-with-web-app) documentation.

### Step 2: Update the Blazor Diagram

The **Home.razor** component will display the organizational data using a Syncfusion® Blazor Diagram with organizational chart layout.

**Instructions:**

1. Open the file named **Home.razor** in the **Components/Pages** folder.
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

    //Creates nodes with default values.
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

    //Creates connectors with default styling.
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

- **`@inject LayoutService`**: Injects the service to call the `/api/layout` endpoint.
- **`<SfDiagramComponent>`**: The Syncfusion® Blazor Diagram component that renders the organizational chart.
- **`<DataSourceSettings>`**: Maps data source properties (`ID`, `ParentID`) to the component so it understands parent–child relationships.
- **`<SnapSettings>`**: Customizes grid lines and snap behavior for better user interaction.
- **`<Layout>`**: Arranges nodes and connectors in an organizational chart tree structure based on parent–child relationships.
- **`OnNodeCreating` / `OnConnectorCreating`**: Customize the appearance of nodes (boxes) and connectors (lines) — in this example, blue boxes with black borders.

The Home component has been updated successfully with Diagram. When the page loads, it injects `LayoutService`, calls `GetOrgChartAsync()` in `OnInitializedAsync()`, and passes the JSON data to the Diagram via `DataSourceSettings`.

---

## Run the Sample Locally

**Summary:** You now have all code in place. Follow these steps to build, run migrations, and launch the application.

**Prerequisites for this section:**
- PostgreSQL is running and reachable.
- Connection string in **appsettings.json** is correct (or use migrations to create the database).
- All steps above (1–7) are complete.

1. Ensure PostgreSQL is running and reachable; update the **DefaultConnection** in the host project's **appsettings.Development.json**.

2. Apply migrations and seed (choose the host project that contains **Migrations**):

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

By default the Server app uses the launch settings shown in **BlazorServerStyle/Properties/launchSettings.json** and will be available on `http://localhost:5069` (HTTP) and `https://localhost:7269` (HTTPS).

4. Or run the WASM host (which serves the client and hosts the API):

```powershell
cd src/BlazorWASMStyle/BlazorWASMStyle
dotnet run
```

Typical WASM host URLs (when running the sample project) are `http://localhost:5252` and `https://localhost:7042` .

5. Open the app in a browser and navigate to the Home page, the organizational chart should load from the host's `/api/layout` endpoint and render via the Blazor Diagram.

## Troubleshooting

**API connection errors:**
- Confirm PostgreSQL is running and reachable.
- Verify the connection string in **appsettings.json**: Server, Port, Database, User Id, and Password must match your PostgreSQL setup.
- Run `dotnet ef database update` from the host project to ensure migrations applied successfully.

**CORS errors (if Blazor and API are on different ports/domains):**
- Add CORS support to `Program.cs` before `app.UseAuthorization()`:
  ```csharp
  builder.Services.AddCors(options =>
  {
      options.AddDefaultPolicy(policy =>
      {
          policy.WithOrigins("http://localhost:5252")  // adjust WASM client URL
                .AllowAnyMethod()
                .AllowAnyHeader();
      });
  });
  ...
  app.UseCors();
  ```
- Ensure `LayoutService` `BaseAddress` in **Program.cs** matches your API host (e.g., `http://localhost:5069/`).

**No data in Diagram:**
- Open `http://localhost:5069/api/layout` (adjust your API port) in a browser to verify it returns a JSON array.
- Check browser console (F12) for error messages from `LayoutService`.
- Verify that migrations completed and the database contains seed data (check PostgreSQL directly if needed).

## Next Steps / Customization

- Change API origin: update CORS in **Program.cs** and `LayoutService` base address in the Blazor hosts.
- Modify seed data: edit **AppDbContext.OnModelCreating()** and create a new migration:

```powershell
cd src/Api
dotnet ef migrations add UpdateSeed
dotnet ef database update
```

- Explore Syncfusion® Diagram properties to alter templates, orientation, spacing, or styles.

---

## Complete Sample Repository

A complete, working sample implementation is available in the [GitHub repository](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/Samples/OrganizationalChartPostgresql).

## Summary

This guide demonstrates how to:

1. Install PostgreSQL. [🔗](#Installing-PostgreSQL)
2. Create a PostgreSQL database with layout Nodes using pgAdmin 4. [🔗](#PostgreSQL-database-setup)
3. Configure backend implementations. [🔗](#Backend-implementation)
4. Create data models and DbContext for database communication with PostgreSQL-specific configuration. [🔗](#step-2-create-the-data-model)
5. Configure connection strings and register services. [🔗](#step-4-configure-the-connection-string)
6. Implement the repository pattern for data access with helper methods. [🔗](#step-5-create-the-LayoutService-class)
7. Create a Blazor component with a Diagram that visualizes data as a Organizational layout. [🔗](#Rendering-the-Blazor-Diagram-component)

The application now provides a complete solution for visualizing organizational chart data from PostgreSQL.

## See also

- Data Binding: https://blazor.syncfusion.com/documentation/diagram/data-binding#how-to-specify-parent-child-relationship-in-data-source
- Organizational Chart Layout: https://blazor.syncfusion.com/documentation/diagram/layout/organizational-chart
