---
layout: post
title: Syncfusion® Blazor Document Editor and Data Grid Integration
description: Step-by-step guide to integrating Syncfusion Blazor Document Editor and Data Grid in Blazor applications.
platform: Blazor
control: common
documentation: ug
---

# Integrating Syncfusion® Data Grid with Document Editor in Blazor Apps

This guide explains how to integrate the **Syncfusion® Blazor Document Editor** (Word Processor – `SfDocumentEditorContainer`) together with the **Syncfusion® Blazor Data Grid**(`SfGrid`) into:

- **Blazor Web App** (.NET 8 / 9 / 10) using interactive render modes (**Auto**, **WebAssembly**, **Server**)
- **Blazor Server App**
- **Standalone Blazor WebAssembly(WASM) App**

The component provides Microsoft Word-like editing features: formatting, tables, images, headers/footers, **change tracking**, **comments/collaboration**, and **SFDT/Word import/export**.

> Use the dedicated `Syncfusion.Blazor.WordProcessor` package. **Do not** combine it with the all-in-one `Syncfusion.Blazor` package in the same project (causes ambiguity errors).

## Prerequisites

- [Syncfusion Blazor system requirements](https://blazor.syncfusion.com/documentation/system-requirements): Make sure your development environment meets the required system specifications for using Syncfusion Blazor components.

{% tabcontents %}

{% tabcontent Visual Studio %}

## Create Project

- Open **Visual Studio** → **Create a new project**.
- Search for and select:
  - **Blazor Web App** (for modern .NET 8/9/10 with render modes)
  - **Blazor Server App** (for classic server-side)
  - **Blazor WebAssembly App** (for standalone WASM)
- Configure [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) (Auto / Server / WebAssembly) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vs) (Global / Per page/component) when applicable. Follow the Syncfusion guide for creating and setting up a **Blazor App** in Visual Studio:  
  [Getting started with Syncfusion Blazor App – Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=visual-studio) 
- Alternatively, use the [Syncfusion® Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio) / [Template](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) for pre-configured setup.

## Install NuGet Packages

- Go to **Tools → NuGet Package Manager → Manage NuGet Packages for Solution**.
- Search and install:
  * [Syncfusion.Blazor.WordProcessor](https://www.nuget.org/packages/Syncfusion.Blazor.WordProcessor)
  * [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes)
  * [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid)

**For Blazor Web App (WebAssembly / Auto modes)** → install in the **Client** project.

Alternatively, use Package Manager Console:

{% tabs %}
{% highlight powershell tabtitle="Package Manager Console" %}
Install-Package Syncfusion.Blazor.WordProcessor -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Grid -Version {{ site.releaseversion }}
{% endhighlight %}
{% endtabs %}

N> Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the available NuGet package list with component details. Verify the latest versions before installation.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Create Project

Use Visual Studio Code with the .NET SDK installed.

- For **Blazor App** (Blazor App in .NET 8/9/10+):  
  Follow the official Syncfusion guide for creating and setting up a **Blazor App** in Visual Studio Code:  
  [Getting started with Syncfusion Blazor App – Visual Studio Code](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=visual-studio-code)  

- Alternatively, manually create via the [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc) or the [Syncfusion® Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project).

## Install NuGet Packages

- Open integrated terminal (**Ctrl + `**).
- Navigate to project folder (where `.csproj` is, or **Client** subfolder for Web App WebAssembly/Auto).
- Run:

{% tabs %}
{% highlight bash tabtitle="Terminal" %}

dotnet add package Syncfusion.Blazor.WordProcessor -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Grid -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}
{% endtabs %}

N> Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the available NuGet package list with component details. Verify the latest versions before installation.

{% endtabcontent %}

{% endtabcontents %}

## Add Required Namespaces

Add Syncfusion namespaces in the appropriate **~/_Imports.razor** file depending on the project type:

- Blazor Web App:
  * WebAssembly / Auto → `~/Client/_Imports.razor`
  * Server → `~/Components/_Imports.razor` or root `_Imports.razor`
- Standalone WASM App/ Server App → `~/_Imports.razor`

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.DocumentEditor
@using Syncfusion.Blazor.Grids

{% endhighlight %}
{% endtabs %}

## Register Syncfusion Blazor Service

Register the Syncfusion Blazor service in your app’s **~/Program.cs**.

{% tabcontents %}

{% tabcontent Blazor Web App - Server Mode %}

In `~/Program.cs`:

```csharp
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
...
```

{% endtabcontent %}

{% tabcontent Blazor Web App - WebAssembly / Auto Mode %}

Register in **both** `Program.cs` files.

**Server project (`~/Program.cs`):**

```csharp
using Syncfusion.Blazor;

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();

builder.Services.AddSyncfusionBlazor();
```

**Client project (`~/Client/Program.cs`):**

```csharp
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
...
builder.Services.AddSyncfusionBlazor();
await builder.Build().RunAsync();
```

{% endtabcontent %}

{% tabcontent Standalone Blazor WASM %}

In `~/Program.cs`:

```csharp
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
...
builder.Services.AddSyncfusionBlazor();
await builder.Build().RunAsync();
```

{% endtabcontent %}

{% endtabcontents %}

## Add Stylesheet and Script Resources

Before adding the stylesheet, make sure no other Syncfusion theme CSS (e.g., bootstrap5.css, material.css) is already referenced to avoid conflicts.

**Blazor Web App** → add to `~/Components/App.razor` (or `~/App.razor`)

**Standalone WASM** → add to `wwwroot/index.html`

**Blazor Server** → add to `~/Pages/_Host.cshtml` or `~/Pages/_Layout.cshtml`

```html
<head>
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

<body>

   	<!-- Syncfusion Blazor Document Editor component's script reference-->
	<script src="_content/Syncfusion.Blazor.WordProcessor/scripts/syncfusion-blazor-documenteditor.min.js" type="text/javascript"></script>
	<!-- Syncfusion Blazor DataGrid component's script reference -->
	<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

## Configure Render Mode

If Interactivity location is set to `Per page/component`, specify a render mode at the top of each `~Pages/*.razor` component as needed:

| Interactivity location | RenderMode | Code |
| --- | --- | --- |
| Per page/component | Auto | @rendermode InteractiveAuto |
|  | WebAssembly | @rendermode InteractiveWebAssembly |
|  | Server | @rendermode InteractiveServer |
|  | None | --- |

**Example (per page):**

{% tabs %}
{% highlight razor %}

@* Define the desired render mode here *@
@rendermode InteractiveAuto

{% endhighlight %}
{% endtabs %}

N> If an **Interactivity Location** is set to `Global` and the **Render Mode** is set to `Auto` or `WebAssembly`, the render mode is configured in the `App.razor` file by default. No per‑page directive is necessary.

## Add Syncfusion Blazor Document Editor component and Data Grid component

Add the Syncfusion Document Editor and Data Grid components to a `.razor` file within your app: 

**Blazor Web App (WebAssembly or Auto Render Mode)**
Add to a `.razor` file inside the `client` project’s `Pages` folder.

**Blazor Web App (Server Render Mode) or Standalone WASM**
Add to `~/Pages/Home.razor` or any `.razor` file under the `Pages` folder.

{% tabs %}
{% highlight razor %}

@page "/"

<h1>DocumentEditor</h1>

<SfDocumentEditorContainer EnableToolbar=true></SfDocumentEditorContainer>

<h1>DataGrid</h1>

<SfGrid DataSource="@Orders" />

@code{
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 10).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

Note: By default, the `SfDocumentEditorContainer` component initializes an `SfDocumentEditor` instance internally. If you like to use the events of `SfDocumentEditor` component, then you can set `UseDefaultEditor` property as **false** and define your own `SfDocumentEditor` instance with event hooks in the application (Razor file).

## Run the Application

- Visual Studio: **Ctrl + F5** (or **F5** to debug).
- VS Code: Run via `dotnet run` in terminal or use launch profile.

The Document Editor renders with full editing capabilities. Initial WASM load may take a few seconds due to component size.


![Blazor DataGrid with Document Editor](../images/DocumentEditor-With-DataGrid.png)
