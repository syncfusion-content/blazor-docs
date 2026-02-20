---
layout: post
title: Integrating Syncfusion Blazor PDF Viewer with Blazor Web App
description: Step-by-step guide to integrate the Syncfusion Blazor PDF Viewer (SfPdfViewer2) component into a Blazor Web App project created in Auto render mode.
platform: Blazor
control: Common
documentation: ug
---

# Integrating Syncfusion Blazor PDF Viewer into a Blazor Web App

This article explains how to integrate the Syncfusion<sup style="font-size:70%">&reg;</sup> `Blazor PDF Viewer` component into a Blazor Web App using [Visual Studio Code](https://code.visualstudio.com/). Before proceeding, ensure you have set up a Blazor Web App in `Auto` render mode. For detailed instructions on creating a Blazor Web App in `Auto` mode using Visual Studio Code, refer to the [Blazor getting started guide](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=visual-studio-code).

The following steps guide you through integrating the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor PDF Viewer(SfPdfViewer2) into your existing Blazor Web App project.

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements): Ensure your development environment meets the system requirements for Blazor components.

### Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor SfPdfViewer and Themes NuGet Packages in the App

If using the `WebAssembly` or `Auto` render modes in the Blazor Web App, install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor component NuGet packages in the client project.

* Ensure you’re in the project root directory where your `.csproj` file is located.
* Run the following command to install the [Syncfusion.Blazor.SfPdfViewer](https://www.nuget.org/packages/Syncfusion.Blazor.SfPdfViewer) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet packages and ensure all dependencies are installed.
* Before installing the Syncfusion.Blazor.Themes package, ensure that it is not already installed in your project.

```
dotnet add package Syncfusion.Blazor.SfPdfViewer -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

```

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the available NuGet package list with component details. Always verify the latest versions on nuget.org before installation.

{% endtabcontent %}

{% tabcontent .NET CLI %}

### Add Import Namespaces

Open the **~/_Imports.razor** file in the client project and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.SfPdfViewer` namespaces.

```
@using Syncfusion.Blazor
@using Syncfusion.Blazor.SfPdfViewer

```

### Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

Register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service in the **~/Program.cs** file of your Blazor Web App.

If the **Interactive Render Mode** is set to `WebAssembly` or `Auto`, register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in both **~/Program.cs** files of the Blazor Web App.

{% tabs %}
{% highlight c# tabtitle="Server(~/_Program.cs)" hl_lines="3 11 13" %}

...
...
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddMemoryCache();
//Add Syncfusion Blazor service to the container.
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
....

{% endhighlight %}
{% highlight c# tabtitle="Client(~/_Program.cs)" hl_lines="2 6 8" %}

...
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddMemoryCache();
//Add Syncfusion Blazor service to the container
builder.Services.AddSyncfusionBlazor();

await builder.Build().RunAsync();

{% endhighlight %}
{% endtabs %}

### Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Before adding the stylesheet reference, ensure no Syncfusion theme (e.g. bootstrap5.css, material.css, etc.) is already included in the `<head>` section to avoid duplicate or conflicting styles, then include the stylesheet reference in the `<head>` section and the script reference at the end of the `<body>` tag in the **~/Components/App.razor** file as shown below:

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

<body>
    ....
    <script src="_content/Syncfusion.Blazor.SfPdfViewer/scripts/syncfusion-blazor-sfpdfviewer.min.js" type="text/javascript"></script>
</body>

```

### Add Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor PDF Viewer component

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor PDF Viewer component in the **~/Components/Pages/*.razor** file. If the interactivity location is set to `Per page/component` in the Web App, define a render mode at the top of the `~Pages/*.razor` component, as follows:

<table style="width:100%">
<tr>
<th style="width:30%">Interactivity location</th>
<th style="width:20%">RenderMode</th>
<th style="width:50%">Code</th>
</tr>
<tr>
<td>Per page/component</td>
<td>Auto</td>
<td>@rendermode InteractiveAuto</td>
</tr>
<tr>
<td></td>
<td>WebAssembly</td>
<td>@rendermode InteractiveWebAssembly</td>
</tr>
<tr>
<td></td>
<td>Server</td>
<td>@rendermode InteractiveServer</td>
</tr>
<tr>
<td></td>
<td>None</td>
<td>---</td>
</tr>
</table>

N> If an **Interactivity Location** is set to `Global` and the **Render Mode** is set to `Auto` or `WebAssembly`, the render mode is configured in the `App.razor` file by default.

{% tabs %}
{% highlight razor %}

@* desired render mode define here *@
@rendermode InteractiveAuto

{% endhighlight %}
{% endtabs %}

Add the Syncfusion® PDF Viewer component in a `.razor` file within the **client project**.  
You can either modify an existing file or create a new `.razor` file in the `Pages` folder or in `Components/Pages` depending on your project structure.

{% tabs %}
{% highlight razor %}

@page "/"

<SfPdfViewer2 DocumentPath="https://cdn.syncfusion.com/content/pdf/pdf-succinctly.pdf"
              Height="100%"
              Width="100%">
</SfPdfViewer2>

{% endhighlight %}
{% endtabs %}


###  Run the Application

```

dotnet run

```

This will render the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor PDF Viewer component in the default web browser. 

