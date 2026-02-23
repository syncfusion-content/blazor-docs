---
layout: post
title: Integrating Syncfusion Blazor PDF Viewer in Blazor Web App, Blazor Server, and Blazor WASM
description: Step-by-step guide to integrate the Syncfusion Blazor PDF Viewer (SfPdfViewer2) into Blazor Web App and Blazor WebAssembly (WASM) App.
platform: Blazor
control: Common
documentation: ug
---

# Integrating Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor PDF Viewer

This article explains how to integrate the Syncfusion<sup style="font-size:70%">&reg;</sup> `Blazor PDF Viewer` component into the following project types:
* Blazor Web App (using interactive render modes such as Auto, WebAssembly, or Server)
* Blazor WebAssembly (WASM) App

This guide uses [Visual Studio Code](https://code.visualstudio.com/). Before proceeding, ensure that you have created the appropriate Blazor application. For detailed instructions on creating a Blazor Web App using Visual Studio Code, refer to the [Blazor getting started guide](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=visual-studio-code).

### Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements): Make sure your development environment meets the required system specifications for using Syncfusion Blazor components.
* For Blazor WASM or Blazor Web App using Auto or WebAssembly modes, install SkiaSharp workloads:
    * dotnet workload install wasm-tools
    * dotnet workload install wasm-tools-net8
    * dotnet workload install wasm-tools-net9
    * dotnet workload install wasm-tools-net10

### Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor SfPdfViewer and Themes NuGet Packages in the App

If your Blazor Web App is using the `WebAssembly` or `Auto` render modes, ensure that all package installations are performed inside the `client` project.

* Ensure you're in the project’s root directory where the `.csproj` file is located.
* Run the following commands to install the [Syncfusion.Blazor.SfPdfViewer](https://www.nuget.org/packages/Syncfusion.Blazor.SfPdfViewer), [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/), and [SkiaSharp.Views.Blazor](https://www.nuget.org/packages/SkiaSharp.Views.Blazor) NuGet packages and ensure that all dependencies are installed.

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.SfPdfViewer -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet add package SkiaSharp.Views.Blazor -v 3.119.2
dotnet restore

{% endhighlight %}

{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the available NuGet package list with component details. Always verify the latest versions on nuget.org before installation.

N> Syncfusion&reg; uses [SkiaSharp.Views.Blazor](https://www.nuget.org/packages/SkiaSharp.Views.Blazor) version 3.119.2. Ensure this version is referenced.
* dotnet add package SkiaSharp.Views.Blazor -v 3.119.2

### Add Required Namespaces

Add Syncfusion<sup style="font-size:70%">&reg;</sup> namespaces in the appropriate **~/_Imports.razor** file depending on the project type:

**For Blazor Web App**

| Interactive Render Mode | Description |
| -- | -- |
| WebAssembly or Auto | Open **~/_Imports.razor** from the client project.|
| Server | Open **~/Components/_Imports.razor**.|

**For Standalone Blazor WASM**

Add the following to **~/_Imports.razor**:

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.SfPdfViewer

{% endhighlight %}
{% endtabs %}

### Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

Register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in your app’s **~/Program.cs** file(s) based on your project type and interactive render mode.

If the **Interactive Render Mode** is set to `WebAssembly` or `Auto`, register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in both **~/Program.cs** files of the Blazor Web App.

{% tabs %}
{% highlight c# tabtitle=".NET 8/.NET 9/.NET 10 (~/Program.cs) Server" hl_lines="2 9 11 13" %}

...
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents() 
    .AddInteractiveServerComponents();

builder.Services.AddSignalR(o => { o.MaximumReceiveMessageSize = 102400000; });

builder.Services.AddMemoryCache();
//Add Syncfusion Blazor service to the container.
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
...

{% endhighlight %}

{% highlight c# tabtitle=".NET 8/.NET 9/.NET 10 (~/Program.cs) WebAssembly" hl_lines="3 9 11" %}

...
...
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents()
.AddInteractiveWebAssemblyComponents();

builder.Services.AddMemoryCache();
//Add Syncfusion Blazor service to the container
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
....

{% endhighlight %}

{% highlight c# tabtitle=".NET 8/.NET 9/.NET 10 (~/Program.cs) Auto" hl_lines="3 9 11 13" %}

...
...
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents()
.AddInteractiveServerComponents() .AddInteractiveWebAssemblyComponents();

builder.Services.AddSignalR(o => { o.MaximumReceiveMessageSize = 102400000; });

builder.Services.AddMemoryCache();
//Add Syncfusion Blazor service to the container
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
....

{% endhighlight %}

{% highlight C# tabtitle=".NET 8/.NET 9/.NET 10 (~/Program.cs) Standalone WASM" hl_lines="3 9 13" %}

...
...
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddMemoryCache();
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Add Syncfusion Blazor service to the container.
builder.Services.AddSyncfusionBlazor();
await builder.Build().RunAsync();

{% endhighlight %}

{% endtabs %}

### Add stylesheet and script resources

Before adding the stylesheet reference, ensure that no other Syncfusion<sup style="font-size:70%">&reg;</sup> theme stylesheet (such as bootstrap5.css, material.css, etc.) is already included.

**For Blazor Web App**

Add the following to `~/Components/App.razor:` 

{% tabs %}
{% highlight html hl_lines="3 7" %}

<head>
    <!-- Syncfusion bootstrap theme style sheet -->
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

<body>
    <!-- Syncfusion Blazor PDF Viewer control's scripts -->
    <script src="_content/Syncfusion.Blazor.SfPdfViewer/scripts/syncfusion-blazor-sfpdfviewer.min.js" type="text/javascript"></script>
</body>

{% endhighlight %}
{% endtabs %}

**For Standalone WASM**

Add the same references to `wwwroot/index.html`.

### Add Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor PDF Viewer component

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor PDF Viewer component in the **~/Components/Pages/*.razor** file. If the interactivity location is set to `Per page/component` in the Web App, define a render mode at the top of the `~Pages/*.razor` component, as follows:

| Interactivity location | RenderMode | Code |
| --- | --- | --- |
| Per page/component | Auto | @rendermode InteractiveAuto |
|  | WebAssembly | @rendermode InteractiveWebAssembly |
|  | Server | @rendermode InteractiveServer |
|  | None | --- |

N> If an **Interactivity Location** is set to `Global` and the **Render Mode** is set to `Auto` or `WebAssembly`, the render mode is configured in the `App.razor` file by default.

{% tabs %}
{% highlight razor %}

@* Define the desired render mode here *@
@rendermode InteractiveAuto

{% endhighlight %}
{% endtabs %}

N> If the interactivity location is set to Global, a render mode does not need to be specified per page. The interactivity mode applies to the entire app.
<br />Enable interactivity only via client-side rendering (CSR) by using the WebAssembly or Auto option.

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> PDF Viewer (Next‑Gen) component to any `.razor` file inside the `Pages` folder, based on your application type:

**Blazor Web App (WebAssembly or Auto Render Mode)**
Add the component inside a `.razor` file located in the `Pages` folder of the `client` project.

**Blazor Web App (Server Render Mode)**
Add the component in the `~/Components/Pages/Home.razor file`, or in any .razor page within the `Pages` folder of the application.

**Blazor Web App (Standalone WASM)**
Add the component in the `~/Pages/Home.razor file`, or in any .razor page within the `Pages` folder of the application.

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

