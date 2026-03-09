---
layout: post
title: Loading Blazor Diagram from PostgreSQL database | Syncfusion®
description: Fetch organizational data from PostgreSQL and bind it to a .NET API-backed Syncfusion Blazor Diagram for Server and WASM samples.
platform: Blazor
control: Diagram
documentation: ug
---
# Loading a Syncfusion Blazor Diagram from PostgreSQL

This guide explains how the sample in this repository loads organizational-chart layout data from PostgreSQL and renders it with the Syncfusion Blazor Diagram component. It covers both Blazor Server and Blazor WebAssembly (WASM) host apps, the API backend, database initialization, and where to find the important files in the workspace.

> Note: The API returns objects with fields `id`, `parentId` (C#) / `parent_id` (DB) and `role`. The diagram's `DataSourceSettings` expects this parent–child shape.

## Overview

Three parts make up the sample:
- PostgreSQL — stores the org chart data.
- Api — ASP.NET Core Web API project that exposes `/api/layout`, hosts EF Core migrations and seed data.
- Blazor hosts — two consumer apps:
  - Blazor Server: [BlazorServerStyle](BlazorServerStyle)
  - Blazor WebAssembly (WASM): [BlazorWASMStyle/BlazorWASMStyle](BlazorWASMStyle/BlazorWASMStyle)

Both Blazor apps call a small `LayoutService` which fetches `/api/layout` and binds the returned `List<LayoutNode>` to the `SfDiagramComponent`.

## Prerequisites

- .NET SDK 10.0 or later
- PostgreSQL 12.x or later
- (Optional) `dotnet-ef` CLI for running migrations (`dotnet tool install --global dotnet-ef`)

## Database setup

You can either create the database and table manually (pgAdmin or psql) or use the EF Core migrations that are included in the Api project.

Option A — Manual (pgAdmin / psql):

- Create a database named `org_chart_db`.
- Create the table:

```sql
CREATE TABLE IF NOT EXISTS org_chart_layout (
  id text PRIMARY KEY,
  role text NOT NULL,
  parent_id text NULL
);
```

- Insert sample rows (example shown in the repository seed).

Option B — Automated (EF Core migrations + seed):

- The Api project contains migrations and a `HasData` seed in `AppDbContext.OnModelCreating()`.
- Update the connection string in [Api/appsettings.Development.json](Api/appsettings.Development.json) to point to your PostgreSQL server.

To apply migrations and seed:

```powershell
cd src/Api
dotnet restore
dotnet build
dotnet ef database update
```

If `dotnet-ef` is missing, install it:

```powershell
dotnet tool install --global dotnet-ef
```

## Backend

- DbContext: [Api/Data/AppDbContext.cs](Api/Data/AppDbContext.cs) — configures the table, mappings and seed data.
- Controller: [Api/Controllers/LayoutController.cs](Api/Controllers/LayoutController.cs) — exposes GET `/api/layout`.
- Connection string: [Api/appsettings.Development.json](Api/appsettings.Development.json) — update `DefaultConnection` for your server.
- CORS & hosting: [Api/Program.cs](Api/Program.cs) — CORS permits the Blazor sample origins by default.

Example response from `/api/layout`:

```json
[
  { "id": "parent", "parentId": null, "role": "Board" },
  { "id": "1", "parentId": "parent", "role": "General Manager" }
]
```

## Blazor integration

Both Blazor apps use `LayoutService` to call the API and bind the resulting `List<LayoutNode>` to the diagram's `DataSource`.

Key files (workspace-relative):
- Shared model: [Shared/Models/LayoutNode.cs](Shared/Models/LayoutNode.cs)
- API: [Api/Program.cs](Api/Program.cs), [Api/Data/AppDbContext.cs](Api/Data/AppDbContext.cs), [Api/Controllers/LayoutController.cs](Api/Controllers/LayoutController.cs), [Api/appsettings.Development.json](Api/appsettings.Development.json)
- Blazor Server: [BlazorServerStyle/Program.cs](BlazorServerStyle/Program.cs), [BlazorServerStyle/Components/Pages/Home.razor](BlazorServerStyle/Components/Pages/Home.razor), [BlazorServerStyle/Services/LayoutService.cs](BlazorServerStyle/Services/LayoutService.cs)
- Blazor WASM (client): [BlazorWASMStyle/BlazorWASMStyle/BlazorWASMStyle.Client/Program.cs](BlazorWASMStyle/BlazorWASMStyle/BlazorWASMStyle.Client/Program.cs), [BlazorWASMStyle/BlazorWASMStyle/BlazorWASMStyle.Client/Pages/Home.razor](BlazorWASMStyle/BlazorWASMStyle/BlazorWASMStyle.Client/Pages/Home.razor), [BlazorWASMStyle/BlazorWASMStyle/BlazorWASMStyle.Client/Services/LayoutService.cs](BlazorWASMStyle/BlazorWASMStyle/BlazorWASMStyle.Client/Services/LayoutService.cs)

Diagram binding (Home pages):

- The pages call `LayoutService.GetOrgChartAsync()` during initialization.
- The returned list is provided to the diagram via `<DataSourceSettings ID="Id" ParentID="ParentId" DataSource="@_dataSource" />`.
- Node and connector styling are applied via `NodeCreating` and `ConnectorCreating` callbacks.
- The layout uses `<Layout Type="LayoutType.OrganizationalChart">` to arrange nodes.

## Run the sample locally

1. Ensure PostgreSQL is running and reachable; update [Api/appsettings.Development.json](Api/appsettings.Development.json) with correct credentials.
2. Apply migrations and seed (or create DB manually):

```powershell
cd src/Api
dotnet restore
dotnet build
dotnet ef database update
```

3. Run the API:

```powershell
cd src/Api
dotnet run
# By default the Api listens on http://localhost:5176 and https://localhost:7117 (see Api/Properties/launchSettings.json)
```

4. Start the Blazor Server app in a new terminal:

```powershell
cd src/BlazorServerStyle
dotnet run
# Server app default: http://localhost:5069 (see BlazorServerStyle/Properties/launchSettings.json)
```

5. Or start the Blazor WASM host:

```powershell
cd src/BlazorWASMStyle/BlazorWASMStyle
dotnet run
# Default URLs: http://localhost:5252 and https://localhost:7042
```

6. Open the app in a browser and navigate to the Home page — the organizational chart should load from the API and render via the Syncfusion Blazor Diagram.

## Troubleshooting

- API connection errors: verify PostgreSQL is running and the connection string in [Api/appsettings.Development.json](Api/appsettings.Development.json) is correct.
- CORS errors: ensure the API CORS settings in [Api/Program.cs](Api/Program.cs) include the Blazor host origins used.
- Missing data in diagram: open `/api/layout` in a browser or Postman; confirm `LayoutService.GetOrgChartAsync()` is pointing to the correct base address.

## Next steps / customization

- Host the API on another origin: update CORS in [Api/Program.cs](Api/Program.cs) and the `LayoutService` base address in the Blazor projects.
- Edit seed data in `AppDbContext.OnModelCreating()` and create a migration:

```powershell
cd src/Api
dotnet ef migrations add UpdateSeed
dotnet ef database update
```

- Explore Syncfusion Diagram properties to change templates, orientation, or styling.

---

A complete working sample is available on GitHub: https://github.com/SyncfusionExamples/Blazor-Diagram-Examples/tree/master/Samples/OrganizationalChartPostgresql

## See also

- Data Binding: https://blazor.syncfusion.com/documentation/diagram/data-binding#how-to-specify-parent-child-relationship-in-data-source
- Organizational Chart Layout: https://blazor.syncfusion.com/documentation/diagram/layout/organizational-chart