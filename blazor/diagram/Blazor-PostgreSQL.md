---
layout: post
title: Loading Blazor Diagram from PostgreSQL database | Syncfusion®
description: Fetch organizational-chart layout data from PostgreSQL and bind it to a .NET API-backed Syncfusion Blazor Diagram for Server and WASM samples.
platform: Blazor
control: Diagram
documentation: ug
---

# Loading a Syncfusion Blazor Diagram from PostgreSQL

This guide shows how the sample in this repository loads organizational-chart layout data from PostgreSQL and renders it with the Syncfusion Blazor Diagram component. It follows the same structured style as the DataGrid PostgreSQL example and covers database creation, API backend, EF Core migrations, and how the Blazor Server and WASM projects consume the API.

> Note: The API returns objects with fields `id`, `parentId` (C#) / `parent_id` (DB) and `role`. The diagram's `DataSourceSettings` expects this parent–child shape.

## Prerequisites

Ensure the following software and packages are available:

| Software / Package | Version | Purpose |
|---|---:|---|
| Visual Studio / Code | Latest | Development IDE with .NET workloads |
| .NET SDK | 10.0 or later | Build & run projects |
| PostgreSQL Server | 12.x or later | Stores org-chart data |
| pgAdmin 4 (optional) | Latest | DB management UI |
| Syncfusion.Blazor.Diagram | {{site.blazorversion}} | Diagram component |
| Syncfusion.Blazor.Themes | {{site.blazorversion}} | Styling for Syncfusion components |
| Microsoft.EntityFrameworkCore | 10.x | EF Core runtime |
| Npgsql.EntityFrameworkCore.PostgreSQL | 10.x | EF provider for PostgreSQL |

## Project layout (workspace-relative)

- Blazor Server host (contains API/controller, DbContext and seed): [BlazorServerStyle](BlazorServerStyle)
- Blazor WASM host (server + client folders): [BlazorWASMStyle/BlazorWASMStyle](BlazorWASMStyle/BlazorWASMStyle)
- Model (Server): [BlazorServerStyle/Models/LayoutNode.cs](BlazorServerStyle/Models/LayoutNode.cs)
- Model (WASM): [BlazorWASMStyle/BlazorWASMStyle/Models/LayoutNode.cs](BlazorWASMStyle/BlazorWASMStyle/Models/LayoutNode.cs)

Note: this sample places the API controller and EF Core `DbContext` inside the host projects (see each host's `Controllers/` and `Data/` folders). There is no separate `Api` project in this workspace.

## Database setup

You can create the database and table manually (pgAdmin/psql) or apply the EF Core migrations included in the Api project.

### Option A — Manual (pgAdmin / psql)

1. Create a database `org_chart_db`.
2. Create the table:

```sql
CREATE TABLE IF NOT EXISTS org_chart_layout (
  id text PRIMARY KEY,
  role text NOT NULL,
  parent_id text NULL
);
```

3. Insert sample rows (the Api seed contains the same records). Example:

```sql
INSERT INTO org_chart_layout (id, role, parent_id) VALUES
('parent','Board',NULL),
('1','General Manager','parent')
ON CONFLICT (id) DO UPDATE SET role = EXCLUDED.role, parent_id = EXCLUDED.parent_id;
```

### Option B — Automated (EF Core migrations + seed)

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

## Backend (host projects)

- DbContext (example): [BlazorServerStyle/Data/AppDbContext.cs](BlazorServerStyle/Data/AppDbContext.cs) — configures the `org_chart_layout` entity and seed data.
- Controller (example): [BlazorServerStyle/Controllers/LayoutController.cs](BlazorServerStyle/Controllers/LayoutController.cs) — exposes GET `/api/layout`.
- Connection string: update `DefaultConnection` in the host project's `appsettings.Development.json` (e.g. [BlazorServerStyle/appsettings.Development.json](BlazorServerStyle/appsettings.Development.json)).
- CORS & hosting: see the host project's `Program.cs` (for example [BlazorServerStyle/Program.cs](BlazorServerStyle/Program.cs)) — each host configures controllers and any CORS policies.

### API endpoint

- GET `/api/layout` — returns an array of `LayoutNode` objects ordered by `Id`.

Example response:

```json
[
  { "id": "parent", "parentId": null, "role": "Board" },
  { "id": "1", "parentId": "parent", "role": "General Manager" }
]
```

## Blazor integration

Both Blazor hosts call a small `LayoutService` that requests `/api/layout` and returns a `List<LayoutNode>`. That list is then used as the `DataSource` for the `SfDiagramComponent`.

Key files:

- Shared model: [Shared/Models/LayoutNode.cs](Shared/Models/LayoutNode.cs)
- Blazor Server (hosts API + pages): [BlazorServerStyle/Program.cs](BlazorServerStyle/Program.cs), [BlazorServerStyle/Components/Pages/Home.razor](BlazorServerStyle/Components/Pages/Home.razor), [BlazorServerStyle/Services/LayoutService.cs](BlazorServerStyle/Services/LayoutService.cs)
- Blazor WASM (host + client): [BlazorWASMStyle/BlazorWASMStyle/Program.cs](BlazorWASMStyle/BlazorWASMStyle/Program.cs), [BlazorWASMStyle/BlazorWASMStyle/BlazorWASMStyle.Client/Program.cs](BlazorWASMStyle/BlazorWASMStyle/BlazorWASMStyle.Client/Program.cs), [BlazorWASMStyle/BlazorWASMStyle/BlazorWASMStyle.Client/Services/LayoutService.cs](BlazorWASMStyle/BlazorWASMStyle/BlazorWASMStyle.Client/Services/LayoutService.cs)

 - Model (Server): [BlazorServerStyle/Models/LayoutNode.cs](BlazorServerStyle/Models/LayoutNode.cs)
 - Model (WASM): [BlazorWASMStyle/BlazorWASMStyle/Models/LayoutNode.cs](BlazorWASMStyle/BlazorWASMStyle/Models/LayoutNode.cs)

### Host configuration snippets

Blazor Server — `Program.cs` (service registration and `HttpClient` used by `LayoutService`):

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
  client.BaseAddress = new Uri("http://localhost:5069/");   // change to your API HTTP port if needed
});

// Add controllers and EF DbContext
builder.Services.AddControllers();
builder.Services.AddDbContext<AppDbContext>(options =>
  options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();
```

Blazor WASM client — `Program.cs` (client registration):

```csharp
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;
using Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSyncfusionBlazor();
builder.Services.AddScoped<LayoutService>();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
await builder.Build().RunAsync();
```

### LayoutService examples

Server-side `LayoutService` (`BlazorServerStyle/Services/LayoutService.cs`):

```csharp
using BlazorServerStyle.Models;
using System.Net.Http.Json;

namespace Services;

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

Client `LayoutService` (`BlazorWASMStyle.Client/Services/LayoutService.cs`) with retry:

```csharp
using BlazorWASMStyle.Client.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace Services;

public class LayoutService
{
  private readonly HttpClient _http;

  public LayoutService(HttpClient http)
  {
    _http = http;
  }

  public async Task<List<LayoutNode>?> GetOrgChartAsync()
  {
    const string relativeApi = "api/layout";
    for (int attempt = 0; attempt < 2; attempt++)
    {
      try
      {
        return await _http.GetFromJsonAsync<List<LayoutNode>>(relativeApi);
      }
      catch (HttpRequestException)
      {
        if (attempt == 1)
          throw;
        await Task.Delay(500);
      }
    }

    return null;
  }
}
```

## Run the sample locally

1. Ensure PostgreSQL is running and reachable; update the `DefaultConnection` in the host project's `appsettings.Development.json` (e.g. [BlazorServerStyle/appsettings.Development.json](BlazorServerStyle/appsettings.Development.json)).
2. Apply migrations and seed (choose the host project that contains `Migrations`):

```powershell
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

By default the Server app uses the launch settings shown in [BlazorServerStyle/Properties/launchSettings.json](BlazorServerStyle/Properties/launchSettings.json) and will be available on `http://localhost:5069` (HTTP) and `https://localhost:7269` (HTTPS).

4. Or run the WASM host (which serves the client and hosts the API):

```powershell
cd src/BlazorWASMStyle/BlazorWASMStyle
dotnet run
```

Typical WASM host URLs in this workspace are `http://localhost:5252` and `https://localhost:7042` (check [BlazorWASMStyle/BlazorWASMStyle/Properties/launchSettings.json](BlazorWASMStyle/BlazorWASMStyle/Properties/launchSettings.json) if present).

5. Open the app in a browser and navigate to the Home page — the organizational chart should load from the host's `/api/layout` endpoint and render via the Syncfusion Blazor Diagram.

## Troubleshooting

- API connection errors: confirm PostgreSQL is running and [Api/appsettings.Development.json](Api/appsettings.Development.json) contains correct credentials.
- CORS errors: check CORS configuration in [Api/Program.cs](Api/Program.cs) and ensure the Blazor host origin is allowed.
- No data in diagram: open `/api/layout` in a browser or Postman to confirm JSON is returned; verify `LayoutService` base address.

## Next steps / customization

- Change API origin: update CORS in [Api/Program.cs](Api/Program.cs) and `LayoutService` base address in the Blazor hosts.
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

## See also

- Data Binding: https://blazor.syncfusion.com/documentation/diagram/data-binding#how-to-specify-parent-child-relationship-in-data-source
- Organizational Chart Layout: https://blazor.syncfusion.com/documentation/diagram/layout/organizational-chart
