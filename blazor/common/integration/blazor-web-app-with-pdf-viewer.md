---
layout: post
title: Integrating Syncfusion Blazor PDF Viewer with Blazor Web App
description: Step-by-step guide to integrate the Syncfusion Blazor PDF Viewer (SfPdfViewer2) component into a Blazor Web App project created in Auto render mode, including NuGet installation, service registration, and component usage.
platform: Blazor
control: Common
documentation: ug
---

# Integration with Other Syncfusion Products: Using Blazor with PDF Viewer

This article explains how to integrate the Syncfusion<sup style="font-size:70%">&reg;</sup> `Blazor PDF Viewer` component into a Blazor Web App using [Visual Studio Code](https://code.visualstudio.com/). Before proceeding, ensure you have set up a Blazor Web App in `Auto` render mode. For detailed instructions on creating a Blazor Web App in `Auto` mode using Visual Studio Code, refer to the [Blazor getting started guide](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=visual-studio-code).

The following steps guide you through integrating the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor PDF Viewer(SfPdfViewer2) into your existing Blazor Web App project.

## Prerequisites

* .NET SDK: Use the latest .NET version (e.g., .NET 10 or .NET 11 preview, as applicable for your project; check compatibility with Syncfusion versions).
* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements): Ensure your development environment meets the system requirements for Blazor components.

### Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor SfPdfViewer and Themes NuGet Packages in the App

If using the `WebAssembly` or `Auto` render modes in the Blazor Web App, install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor component NuGet packages in the client project.

* Press <kbd>Ctrl</kbd>+<kbd>`</kbd> to open the integrated terminal in Visual Studio Code.
* Ensure you’re in the project root directory where your `.csproj` file is located.
* Run the following command to install the [Syncfusion.Blazor.SfPdfViewer](https://www.nuget.org/packages/Syncfusion.Blazor.SfPdfViewer) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet packages and ensure all dependencies are installed.

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.SfPdfViewer -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the available NuGet package list with component details. Always verify the latest versions on nuget.org before installation.

{% endtabcontent %}

{% tabcontent .NET CLI %}

### Add Import Namespaces

Open the **~/_Imports.razor** file in the client project and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.SfPdfViewer` namespaces.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.SfPdfViewer

{% endhighlight %}
{% endtabs %}

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

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet reference in the `<head>` section and the script reference at the end of the `<body>` in the **~/Components/App.razor** file as shown below:

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

{% tabs %}
{% highlight razor %}

@page "/"

<SfPdfViewer2 DocumentPath="https://cdn.syncfusion.com/content/pdf/pdf-succinctly.pdf"
              Height="100%"
              Width="100%">
</SfPdfViewer2>

{% endhighlight %}
{% endtabs %}

### Move the Razor file to the Client project
In a Blazor Web App using Auto or WebAssembly render mode, interactive components such as the Syncfusion SfPdfViewer2 must reside in the client project (typically named <YourApp>.Client) to function correctly.
Follow these steps:

* Move the Razor file that contains the <SfPdfViewer2> component (for example, Home.razor, Index.razor, or any custom page) from the main project’s Pages folder (or Components/Pages folder, depending on your project structure) to the corresponding folder in the client project — usually <YourApp>.Client/Pages or <YourApp>.Client/Components/Pages.
* If the target folder or file does not already exist in the client project:
    1. Create the necessary folder structure in the client project (e.g., Pages or Components/Pages).
    2. Move or paste the .razor file into that location.

After moving the file, ensure the following:

* The client project’s ~/_Imports.razor file includes the required Syncfusion namespaces (as configured earlier).
* If using per-page/component interactivity, the appropriate render mode directive remains at the top of the file:

{% tabs %}
{% highlight razor %}

@* desired render mode define here *@
@rendermode InteractiveAuto

{% endhighlight %}
{% endtabs %}

(or @rendermode InteractiveWebAssembly if preferred).

###  Run the Application

1. Open the terminal in VS Code (`Ctrl + ``).
2. Navigate to your project root (where the main `.csproj` is):
3. Run the app:

{% tabs %}
{% highlight c# tabtitle="Blazor Web App" %}

dotnet run

{% endhighlight %}
{% endtabs %}

This will render the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor PDF Viewer component in the default web browser.

