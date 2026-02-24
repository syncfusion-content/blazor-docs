---
layout: post
title: Integrating Syncfusion Blazor Document Editor in Blazor Web App, Blazor Server, and Blazor WASM
description: Step-by-step guide to integrate Syncfusion Blazor Document Editor (SfDocumentEditorContainer) into Blazor Web App (Auto/Server/WebAssembly), Blazor Server, and standalone Blazor WebAssembly projects. 
platform: Blazor
control: Document Editor
documentation: ug
---

# Integrating Syncfusion® Blazor Document Editor

This guide explains how to integrate the **Syncfusion® Blazor Document Editor** (Word Processor – `SfDocumentEditorContainer`) into:

- **Blazor Web App** (.NET 8 / 9 / 10) using interactive render modes (**Auto**, **WebAssembly**, **Server**)
- **Blazor Server** App
- **Standalone Blazor WebAssembly** (WASM) App

The component provides Microsoft Word-like editing features: formatting, tables, images, headers/footers, **change tracking**, **comments/collaboration**, and **SFDT/Word import/export**.

> Use the dedicated `Syncfusion.Blazor.WordProcessor` package. **Do not** combine it with the all-in-one `Syncfusion.Blazor` package in the same project (causes ambiguity errors).

## Prerequisites

- [Syncfusion Blazor system requirements](https://blazor.syncfusion.com/documentation/system-requirements)


{% tabcontents %}

{% tabcontent Visual Studio %}

## Create Project

- Open **Visual Studio** → **Create a new project**.
- Search for and select:
  - **Blazor Web App** (for modern .NET 8+ with render modes)
  - **Blazor Server App** (for classic server-side)
  - **Blazor WebAssembly App** (for standalone WASM)
- Configure [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) (Auto / Server / WebAssembly) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vs) (Global / Per page/component) when applicable.
- Alternatively, use the **[Syncfusion® Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio)** / **[Template Studio](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vs)** for pre-configured setup.

## Install NuGet Packages

- Go to **Tools → NuGet Package Manager → Manage NuGet Packages for Solution**.
- Search and install:
  - `Syncfusion.Blazor.WordProcessor` -v {{ site.releaseversion }}
  - `Syncfusion.Blazor.Themes` -v {{ site.releaseversion }}

**For Blazor Web App (WebAssembly / Auto modes)** → install in the **Client** project.

Alternatively, use Package Manager Console:
{% tabs %}
{% highlight powershell tabtitle="Package Manager Console" %}
Install-Package Syncfusion.Blazor.WordProcessor -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}
{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Create Project

Use Visual Studio Code with the .NET SDK installed.

- For **Blazor Web App** (e.g., Auto mode): Use **[Syncfusion® Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio)** or manually create via template (but follow VS steps above if possible).
- Open terminal in VS Code (**Ctrl + `**) and navigate to desired folder.
- For **standalone Blazor WASM** or **Blazor Server**, refer to Syncfusion VS Code extension documentation for project creation assistance.

## Install NuGet Packages

- Open integrated terminal (**Ctrl + `**).
- Navigate to project folder (where `.csproj` is, or **Client** subfolder for Web App WebAssembly/Auto).
- Run:
{% tabs %}
{% highlight bash tabtitle="Terminal" %}
dotnet add package Syncfusion.Blazor.WordProcessor -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore
{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

## Add Required Namespaces

Add to the appropriate `_Imports.razor` file:

- Blazor Web App:
  - WebAssembly / Auto → `~/Client/_Imports.razor`
  - Server → `~/Components/_Imports.razor` or root `_Imports.razor`
- Standalone WASM / Server → `~/_Imports.razor`

```razor
@using Syncfusion.Blazor
@using Syncfusion.Blazor.DocumentEditor
```

## Register Syncfusion Blazor Service

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

**Blazor Web App** → add to `~/Components/App.razor` (or `~/App.razor`)

**Standalone WASM** → add to `wwwroot/index.html`

**Blazor Server** (older style) → add to `~/Pages/_Host.cshtml` or `~/Pages/_Layout.cshtml`

```html
<head>
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

<body>
    ...
    <script src="_content/Syncfusion.Blazor.WordProcessor/scripts/syncfusion-blazor-documenteditor.min.js"></script>
</body>
```

(Choose other themes like material, tailwind, etc., if preferred.)

## Add Document Editor Component

If Interactivity location is set to `Per page/component`, specify a render mode at the top of each `~Pages/*.razor` component as needed:

| Interactivity location | RenderMode | Code |
| --- | --- | --- |
| Per page/component | Auto | @rendermode InteractiveAuto |
|  | WebAssembly | @rendermode InteractiveWebAssembly |
|  | Server | @rendermode InteractiveServer |
|  | None | --- |

{% tabs %}
{% highlight razor %}

@* Define the desired render mode here *@
@rendermode InteractiveAuto

{% endhighlight %}
{% endtabs %}

N> If an **Interactivity Location** is set to `Global` and the **Render Mode** is set to `Auto` or `WebAssembly`, the render mode is configured in the `App.razor` file by default. No per‑page directive is necessary.

```razor
<SfDocumentEditorContainer EnableToolbar="true" Height="600px" Width="100%" />
```
Note: By default, the SfDocumentEditorContainer component initializes an SfDocumentEditor instance internally. If you like to use the events of SfDocumentEditor component, then you can set UseDefaultEditor property as false and define your own SfDocumentEditor instance with event hooks in the application (Razor file).


## Run the Application

- Visual Studio: **Ctrl + F5** (or **F5** to debug).
- VS Code: Run via `dotnet run` in terminal or use launch profile.

The Document Editor renders with full editing capabilities. Initial WASM load may take a few seconds due to component size.
