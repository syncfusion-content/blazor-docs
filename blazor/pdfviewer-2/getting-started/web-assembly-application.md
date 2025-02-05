---
layout: post
title: Getting Started with SfPdfViewer in Blazor WASM App | Syncfusion
description: Checkout and learn about getting started with Blazor SfPdfViewer component in Blazor WebAssembly (WASM) App using Visual Studio and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# View PDF files using PDF Viewer Component in the Blazor WASM app

In this section, we'll guide you through the process of adding Syncfusion&reg; Blazor PDF Viewer component to your Blazor WebAssembly (WASM) app. We'll break it down into simple steps to make it easy to follow. Additionally, you can find a fully functional example project on our [GitHub repository](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Getting%20Started/Client-side%20application).

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

* To use the PDF Viewer component in a Blazor WebAssembly application with SkiaSharp, make sure to have the required .NET workloads installed by executing the following commands in the command prompt.
    * dotnet workload install wasm-tools
    * dotnet workload install wasm-tools-net6

{% tabcontents %}

{% tabcontent Visual Studio %}

## Create a new Blazor App in Visual Studio    

You can create a **Blazor WebAssembly App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

N> The PDF Viewer component is supported from .NET 6.0 onwards.

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor SfPdfViewer and Themes NuGet in the App

To add **Blazor PDFViewer** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install 

* [Syncfusion.Blazor.SfPdfViewer](https://www.nuget.org/packages/Syncfusion.Blazor.SfPdfViewer) 
* [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes)
* [SkiaSharp.Views.Blazor](https://www.nuget.org/packages/SkiaSharp.Views.Blazor)

N> On the Syncfusion<sup style="font-size:70%">&reg;</sup> side, we are using SkiaSharp.Views.Blazor version 3.116.1. Please make sure to reference this version as well.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Create a new Blazor App in Visual Studio Code

You can create a **Blazor WebAssembly App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project).

Alternatively, you can create a WebAssembly application using the following command in the terminal(<kbd>Ctrl</kbd>+<kbd>`</kbd>).

{% tabs %}

{% highlight c# tabtitle="Blazor WASM App" %}

dotnet new blazorwasm -o BlazorApp
cd BlazorApp

{% endhighlight %}

{% endtabs %}

N> The PDF Viewer component is supported from .NET 6.0 onwards.

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet Package in the App

* Press <kbd>Ctrl</kbd>+<kbd>`</kbd> to open the integrated terminal in Visual Studio Code.
* Ensure you’re in the project root directory where your `.csproj` file is located.
* Run the following command to install a [Syncfusion.Blazor.SfPdfViewer](https://www.nuget.org/packages/Syncfusion.Blazor.SfPdfViewer), [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) and [SkiaSharp.Views.Blazor](https://www.nuget.org/packages/SkiaSharp.Views.Blazor) NuGet package and ensure all dependencies are installed.

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.SfPdfViewer -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet add package SkiaSharp.Views.Blazor -v 3.116.1
dotnet restore

{% endhighlight %}

{% endtabs %}

N> On the Syncfusion<sup style="font-size:70%">&reg;</sup> side, we are using SkiaSharp.Views.Blazor version 3.116.1. Please make sure to reference this version as well.

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

{% endtabcontent %}

{% endtabcontents %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

* In the **~/_Imports.razor** file, add the following namespaces:

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor;
@using Syncfusion.Blazor.SfPdfViewer;

{% endhighlight %}
{% endtabs %}

* Register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service in the program.cs file.

{% tabs %}
{% highlight C# tabtitle=".NET 6 & .NET 7 (~/Program.cs)" hl_lines="3 9 13" %}

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
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

## Adding stylesheet and script

Add the following stylesheet and script to the head section of the **wwwroot/index.html** file.

{% tabs %}
{% highlight cshtml %}

<head>
    <!-- Syncfusion Blazor PDF Viewer control's theme style sheet -->
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <!-- Syncfusion Blazor PDF Viewer control's scripts -->
    <script src="_content/Syncfusion.Blazor.SfPdfViewer/scripts/syncfusion-blazor-sfpdfviewer.min.js" type="text/javascript"></script>
</head>

{% endhighlight %}
{% endtabs %}

## Adding Blazor PDF Viewer Component

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> PDF Viewer (Next Gen) component in the **~/Pages/Index.razor** file.

{% tabs %}
{% highlight razor %}

@page "/"

<SfPdfViewer2 DocumentPath="https://cdn.syncfusion.com/content/pdf/pdf-succinctly.pdf"
              Height="100%"
              Width="100%">
</SfPdfViewer2>

{% endhighlight %}
{% endtabs %}

N> If you don't provide the [DocumentPath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_DocumentPath) property value, the PDF Viewer component will be rendered without loading the PDF document. Users can then use the **open** option from the toolbar to browse and open the PDF as required.

## Run the application

Run the application, and the PDF file will be displayed using Syncfusion&reg; Blazor PDF Viewer component in your browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZVzNWqXLSZpnuzc?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor SfPdfViewer Component](gettingstarted-images/blazor-pdfviewer.png)" %}

## See also

* [Getting Started with Blazor PDF Viewer Component in Blazor Server App](./server-side-application)

* [Getting Started with Blazor PDF Viewer (Next Gen) Component in WSL mode](./wsl-application)

* [.NET 9 Native Linking Issues with SkiaSharp and Emscripten 3.1.56](https://help.syncfusion.com/document-processing/faq/how-to-fix-skiasharp-native-reference-issue-in-blazor-net90-app)