---
layout: post
title: Getting Started with SfPdfViewer in Blazor WASM App | Syncfusion
description: Checkout and learn about getting started with Blazor SfPdfViewer component in Blazor WebAssembly (WASM) App using Visual Studio and more.
platform: Blazor
control: SfPdfViewer
documentation: ug
---

# View PDF files using PDF Viewer Component in the Blazor WASM app

In this section, we'll guide you through the process of adding Syncfusion's Blazor PDF Viewer (Next Gen) component to your Blazor WebAssembly (WASM) app. We'll break it down into simple steps to make it easy to follow. Additionally, you can find a fully functional example project on our [GitHub repository](https://github.com/SyncfusionExamples/blazor-pdf-viewer-examples/tree/master/Getting%20Started/Client-side%20application-SfPdfViewer).

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

* To use the PDF Viewer (Next Gen) component in a Blazor WebAssembly application with SkiaSharp, make sure to have the required .NET workloads installed by executing the following commands in the command prompt.
    * dotnet workload install wasm-tools
    * dotnet workload install wasm-tools-net6

## Create a new Blazor App in Visual Studio    

Create a new Blazor WebAssembly app and name it **PDFViewerGettingStarted**.

N> The PDF Viewer (Next Gen) component is supported from .NET 6.0 onwards.

## Install Blazor PDF Viewer NuGet package in Blazor WASM App

Add the following NuGet packages into the Blazor WebAssembly app.

* [Syncfusion.Blazor.SfPdfViewer](https://www.nuget.org/packages/Syncfusion.Blazor.SfPdfViewer) 
* [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes)
* [SkiaSharp.Views.Blazor](https://www.nuget.org/packages/SkiaSharp.Views.Blazor)

## Add the following PropertyGroup and ItemGroup:

{% tabs %}
{% highlight c# hl_lines="2 3 7" %}

<PropertyGroup>
	<WasmNativeStrip>true</WasmNativeStrip>
	<WasmBuildNative>true</WasmBuildNative>
</PropertyGroup>

<ItemGroup>
    <NativeFileReference Include="$(SkiaSharpStaticLibraryPath)\2.0.23\*.a" />
</ItemGroup>

{% endhighlight %}
{% endtabs %}

## Register Syncfusion Blazor Service

* In the **~/_Imports.razor** file, add the following namespaces:

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor;
@using Syncfusion.Blazor.SfPdfViewer;

{% endhighlight %}
{% endtabs %}

* Register the Syncfusion Blazor Service in the program.cs file.

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
    <!-- Syncfusion Blazor PDF Viewer (Next Gen) control's theme style sheet -->
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <!-- Syncfusion Blazor PDF Viewer (Next Gen) control's scripts -->
    <script src="_content/Syncfusion.Blazor.SfPdfViewer/scripts/syncfusion-blazor-sfpdfviewer.min.js" type="text/javascript"></script>
</head>

{% endhighlight %}
{% endtabs %}

## Adding Blazor PDF Viewer (Next Gen) Component

Add the Syncfusion PDF Viewer (Next Gen) component in the **~/Pages/Index.razor** file.

{% tabs %}
{% highlight razor %}

@page "/"

<SfPdfViewer2 DocumentPath="https://cdn.syncfusion.com/content/pdf/pdf-succinctly.pdf"
              Height="100%"
              Width="100%">
</SfPdfViewer2>

{% endhighlight %}
{% endtabs %}

N> If you don't provide the `DocumentPath` property value, the PDF Viewer (Next Gen) component will be rendered without loading the PDF document. Users can then use the **open** option from the toolbar to browse and open the PDF as required.

## Run the application

Run the application, and the PDF file will be displayed using Syncfusion's Blazor PDF Viewer (Next Gen) component in your browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZVzNWqXLSZpnuzc?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor SfPdfViewer Component](GettingStarted_images/blazor-pdfviewer.png)" %}

## See also

* [Getting Started with Blazor PDF Viewer (Next Gen) Component in Blazor Server App](./server-side-application)

* [Getting Started with Blazor PDF Viewer (Next Gen) Component in WSL mode](./wsl-application)