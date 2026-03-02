---
layout: post
title: Loading Blazor Diagram from PostgreSQL database | Syncfusion®
description: Fetch organizational data from PostgreSQL and bind it to a .NET API-backed Syncfusion Blazor Diagram for Server and WASM samples.
platform: Blazor
control: Diagram
documentation: ug
---

# Loading Blazor Diagram from PostgreSQL database

This guide shows how the sample projects in this repository load organizational-chart layout data from PostgreSQL and render it with the Syncfusion Blazor Diagram component. It covers both Blazor Server and Blazor WebAssembly (WASM) render modes and explains the backend API, database initialization, and where to find the sample code.

> Note: The REST API returns an array of JSON objects with fields `id`, `parent_id` (or `parentId` in C#), and `role` — this shape is required by the diagram's `DataSourceSettings`.

## Overview

This sample connects three parts:

- **PostgreSQL** — stores the org chart data.
- **Api** — ASP.NET Core Web API project that exposes `/api/layout` and hosts EF Core migrations and seeding.
- **Blazor samples** — two consumer apps:
  - **Blazor Server**: [BlazorServerStyle](BlazorServerStyle)
  - **Blazor WebAssembly**: [BlazorWASMStyle](BlazorWASMStyle/BlazorWASMStyle)

The Blazor pages use a small `LayoutService` to call the API and bind results to `SfDiagramComponent`.

## Prerequisites

- .NET SDK 10.0 or later
- PostgreSQL 12.x or later
- (Optional) the `dotnet-ef` CLI (install with `dotnet tool install --global dotnet-ef`) if you want to run migrations manually.
- A running PostgreSQL server and credentials for a user that can create databases (or create the database manually with pgAdmin)

## PostgreSQL database setup

### Installing PostgreSQL

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

Two options are available to create a database:
  * Manual (pgAdmin 4)
  * Automated initialization and seeding (seed script).

### Option A: Manual (pgAdmin 4)

#### Opening pgAdmin

PostgreSQL includes pgAdmin 4, a graphical tool for database management. Open pgAdmin 4 from the Windows Start menu or application launcher.

![Opening pgAdmin 4](images/pgadmin-start.jpg)

#### Creating the database

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

#### Creating the table

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

#### Inserting sample data

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

#### Verifying data insertion

Run a **SELECT** query to confirm the data insertion:

```sql
SELECT * FROM org_chart_layout;
```

The query should return 18 rows. Parent–child relationships are indicated by the **parent_id** column, which references the **id** of the parent node (NULL for root nodes).

![Verify Data Query Results](images/verify-data-results.jpg)

### Option B: Automated (EF Core migrations + seed)

The `Api` project already contains EF Core migrations and a seed embedded in `AppDbContext.OnModelCreating()`.

- Check connection string at: [Api/appsettings.Development.json](Api/appsettings.Development.json).

To apply migrations and seed data:

```powershell
cd src/Api
dotnet restore
dotnet build
dotnet ef database update
```

If the database does not exist, `dotnet ef database update` (with proper DB server access) will create the database and apply the migration that defines the `org_chart_layout` table and seed rows (the seed is configured with `HasData` in the `AppDbContext`). If **Entity Framework** is not installed, install it with:

```powershell
dotnet tool install --global dotnet-ef
```

Alternatively create the DB manually (Option A) and then run `dotnet ef database update` to create schema and seed.

## Backend implementation (Api project)

- DbContext: [Api/Data/AppDbContext.cs](Api/Data/AppDbContext.cs)
  - Configures the `org_chart_layout` table, column mappings, index on `parent_id`, and `HasData` seed.
- Model: [Shared/Models/LayoutNode.cs](Shared/Models/LayoutNode.cs)
  - C# shape used by both API and Blazor apps.
- Connection string: [Api/appsettings.Development.json](Api/appsettings.Development.json)
  - Update the `DefaultConnection` value to match your PostgreSQL username/password/host/port.
- CORS & hosting: [Api/Program.cs](Api/Program.cs)
  - The API opens CORS for the two sample Blazor host origins (http://localhost:5069 and https://localhost:7042). Adjust if you run apps on different ports.

### API endpoints

- GET `/api/layout` — returns all nodes ordered by `Id`.
  - Implementation: [Api/Controllers/LayoutController.cs](Api/Controllers/LayoutController.cs)

Example response shape:

```json
[
  { "id": "parent", "parentId": null, "role": "Board" },
  { "id": "1", "parentId": "parent", "role": "General Manager" },
  ...
]
```

## Blazor integration

Both samples use a small `LayoutService` which requests the API and returns a `List<LayoutNode>` that is used as the `DataSource` for the `SfDiagramComponent`.

- Blazor Server service registration: [BlazorServerStyle/Program.cs](BlazorServerStyle/Program.cs)
  - `LayoutService` is registered and an `HttpClient` named `Api` is configured with `BaseAddress` pointing to the API (default `http://localhost:5176/`).
  - The server app runs on `http://localhost:5069` by default ([BlazorServerStyle/Properties/launchSettings.json](BlazorServerStyle/Properties/launchSettings.json)).

- Blazor WASM service usage: [BlazorWASMStyle/BlazorWASMStyle/BlazorWASMStyle.Client/Program.cs](BlazorWASMStyle/BlazorWASMStyle/BlazorWASMStyle.Client/Program.cs) and [BlazorWASMStyle/BlazorWASMStyle/BlazorWASMStyle.Client/Services/LayoutService.cs](BlazorWASMStyle/BlazorWASMStyle/BlazorWASMStyle.Client/Services/LayoutService.cs)
  - Ensure a `HttpClient` is available and its `BaseAddress` points to your API host (or the service builds an absolute URI). The hosting project's launch profile is `https://localhost:7042;http://localhost:5252` by default.

### Diagram binding (Home page)

Both Blazor projects include a `Home.razor` that demonstrates the binding. Key file locations:

- [BlazorServerStyle/Components/Pages/Home.razor](BlazorServerStyle/Components/Pages/Home.razor)
- [BlazorWASMStyle/BlazorWASMStyle/BlazorWASMStyle.Client/Pages/Home.razor](BlazorWASMStyle/BlazorWASMStyle/BlazorWASMStyle.Client/Pages/Home.razor)

What the component does:

- Calls `LayoutService.GetOrgChartAsync()` on initialization.
- Supplies the returned `List<LayoutNode>` to the diagram via `<DataSourceSettings ID="Id" ParentID="ParentId" DataSource="@_dataSource" />`.
- Customizes `NodeCreating` and `ConnectorCreating` callbacks to style nodes and connectors.
- Uses `<Layout Type="LayoutType.OrganizationalChart">` to arrange nodes.

## Run the sample locally

1. Start PostgreSQL and ensure credential/port are reachable.
2. Update connection string: [Api/appsettings.Development.json](Api/appsettings.Development.json).
3. Apply database migrations and seed:

```powershell
cd src/Api
dotnet restore
dotnet build
dotnet ef database update
```

4. Run the API:

```powershell
dotnet run
# Api listens on http://localhost:5176 and https://localhost:7117 by default (see Api/Properties/launchSettings.json)
```

5. In a new terminal start the Blazor Server sample:

```powershell
cd src/BlazorServerStyle
dotnet run
# App will be available at http://localhost:5069 (see launchSettings.json)
```

6. Or run the Blazor WASM host (serves the client):

```powershell
cd src/BlazorWASMStyle/BlazorWASMStyle
dotnet run
# Default URLs: http://localhost:5252 and https://localhost:7042
```

7. Open the Blazor app in a browser and navigate to the Home page — the organizational chart should load from the API and render via the Syncfusion Blazor Diagram.

## Troubleshooting

- API connection errors:
  - Verify PostgreSQL server is running and the connection string in [Api/appsettings.Development.json](Api/appsettings.Development.json) is correct.
  - If the DB does not exist, create it manually or use:
  ```powershell
  dotnet ef database update
  ```

- CORS errors:
  - Confirm the API CORS policy in [Api/Program.cs](Api/Program.cs) includes the Blazor app origin (adjust if necessary).

- Missing data in diagram:
  - Confirm `/api/layout` returns rows in JSON (open the URL in browser or Postman).
  - Check that `LayoutService.GetOrgChartAsync()` is pointing to the correct API base address.

## Key files

- API
  - [Api/Program.cs](Api/Program.cs)
  - [Api/Data/AppDbContext.cs](Api/Data/AppDbContext.cs)
  - [Api/Controllers/LayoutController.cs](Api/Controllers/LayoutController.cs)
  - [Api/Properties/launchSettings.json](Api/Properties/launchSettings.json)
  - [Api/appsettings.Development.json](Api/appsettings.Development.json)
- Shared model
  - [Shared/Models/LayoutNode.cs](Shared/Models/LayoutNode.cs)
- Blazor Server
  - [BlazorServerStyle/Program.cs](BlazorServerStyle/Program.cs)
  - [BlazorServerStyle/Components/Pages/Home.razor](BlazorServerStyle/Components/Pages/Home.razor)
  - [BlazorServerStyle/Services/LayoutService.cs](BlazorServerStyle/Services/LayoutService.cs)
- Blazor WASM
  - [BlazorWASMStyle/BlazorWASMStyle/BlazorWASMStyle.Client/Program.cs](BlazorWASMStyle/BlazorWASMStyle/BlazorWASMStyle.Client/Program.cs)
  - [BlazorWASMStyle/BlazorWASMStyle/BlazorWASMStyle.Client/Pages/Home.razor](BlazorWASMStyle/BlazorWASMStyle/BlazorWASMStyle.Client/Pages/Home.razor)
  - [BlazorWASMStyle/BlazorWASMStyle/BlazorWASMStyle.Client/Services/LayoutService.cs](BlazorWASMStyle/BlazorWASMStyle/BlazorWASMStyle.Client/Services/LayoutService.cs)

## Next steps / Customization

- If you host the API on a different origin, update `Api/Program.cs` CORS policy and `LayoutService` base address.
- To change seed data, edit the seed in `AppDbContext.OnModelCreating()` and create a new migration:

```powershell
cd src/Api
dotnet ef migrations add UpdateSeed
dotnet ef database update
```

- Explore Syncfusion Blazor Diagram properties to change node templates, layout orientation, or styling.
---

A complete working sample can be downloaded from [GitHub](https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/Samples/OrganizationalChartPostgresql)

## See Also

- [Data Binding](https://blazor.syncfusion.com/documentation/diagram/data-binding#how-to-specify-parent-child-relationship-in-data-source)
- [Organizational Chart Layout](https://blazor.syncfusion.com/documentation/diagram/layout/organizational-chart)