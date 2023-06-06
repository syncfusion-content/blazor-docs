---
layout: post
title: Getting Started with SfPdfViewer2 in Blazor WASM App | Syncfusion
description: Checkout and learn about getting started with Blazor SfPdfViewer2 component in Blazor WebAssembly (WASM) App using Visual Studio and more.
platform: Blazor
control: SfPdfViewer2
documentation: ug
---

# Getting Started with Blazor SfPdfViewer2 Component in Blazor WASM App

This section briefly explains about how to include [Blazor SfPdfViewer2](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) component in your Blazor WebAssembly (WASM) App using Visual Studio.

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Integrate SfPdfViewer2 into Blazor WebAssembly App

1. Start Visual Studio and select **Create a new project**.

2. For a Blazor WebAssembly experience, choose the **Blazor WebAssembly App** template and select **Next**. 
![Create-a-new-WASM-app](GettingStarted_images/Create-new-WASM-app.png)

3. Provide a **Project name** and confirm that the *Location* is correct. Select **Next**.
![Set-project-name](GettingStarted_images/Set-WASM-project-name.png)

4. In **Additional information dialog**, set target framework.  
![Addition-information-WASM](GettingStarted_images/Additional_information_WASM.png)

## Install Blazor SfPdfViewer2 NuGet package in WASM App

Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). To use Syncfusion Blazor components in the application, add reference to the corresponding NuGet. Refer to [NuGet packages topic](https://blazor.syncfusion.com/documentation/nuget-packages) for available NuGet packages list with component details and [Benefits of using individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages#benefits-of-using-individual-nuget-packages).

To add Blazor `SfPdfViewer2` component in Blazor WebAssembly App, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search for [Syncfusion.Blazor.SfPdfViewer](https://www.nuget.org/packages/Syncfusion.Blazor.SfPdfViewer) and then install it. and also install [SkiaSharp.NativeAssets.WebAssembly](https://www.nuget.org/packages/SkiaSharp.NativeAssets.WebAssembly) to include the SkiaSharp assemblies in your project.

N> This component requires server-side processing to render the PDF files through web service

## Register Syncfusion Blazor Service

Open **~/_Imports.razor** file and import the **Syncfusion.Blazor** and **Syncfusion.Blazor.SfPdfViewer** namespace.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" hl_lines="2" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.SfPdfViewer

{% endhighlight %}
{% endtabs %}

* Open **~/Program.cs** file and register the Syncfusion Blazor Service in the client web application.

{% tabs %}
{% highlight C# tabtitle=".NET 6 & .NET 7 (~/Program.cs)" hl_lines="3 12" %}

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Add Syncfusion Blazor service to the container.
builder.Services.AddSyncfusionBlazor();
builder.Services.AddMemoryCache();
await builder.Build().RunAsync();

{% endhighlight %}
{% endtabs %}

## Add Style Sheet

To add theme to the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search for [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) and then install it. Then, the theme style sheet from NuGet can be referred as follows,

Refer the theme style sheet from NuGet in the `<head>` of **wwwroot/index.html** file in the client web app.

{% tabs %}
{% highlight cshtml tabtitle="~/index.html" %}

<head>
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

{% endhighlight %}
{% endtabs %}

N> Checkout the [Blazor Themes topic](https://blazor.syncfusion.com/documentation/appearance/themes) to learn different ways ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference) and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) to refer themes in Blazor application, and to have the expected appearance for Syncfusion Blazor components. Here, the theme is referred using [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Refer to [Enable static web assets usage](https://blazor.syncfusion.com/documentation/appearance/themes#enable-static-web-assets-usage) topic to use static assets in your project.

## Add Script Reference

In this getting started walk-through, the required scripts are referred using [Static Web Assets](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets) externally inside the `<head>` as follows. Refer to [Enable static web assets usage](https://blazor.syncfusion.com/documentation/common/adding-script-references#enable-static-web-assets-usage) topic to use static assets in your project.

Refer script in the `<head>` of the **~/index.html** file.

{% tabs %}
{% highlight html tabtitle="~/index.html" hl_lines="3" %}

<head>
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor.PdfViewer/scripts/syncfusion-blazor-sfpdfviewer.min.js" type="text/javascript"></script>
</head>

{% endhighlight %}
{% endtabs %}

N> Checkout [Adding Script Reference topic](https://blazor.syncfusion.com/documentation/common/adding-script-references) to learn different ways to add script reference in Blazor Application. 

N> Syncfusion recommends to reference scripts using [Static Web Assets](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/common/adding-script-references#cdn-reference) and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator) by [disabling JavaScript isolation](https://blazor.syncfusion.com/documentation/common/adding-script-references#disable-javascript-isolation) for better loading performance of the Blazor application.

## Add Blazor SfPdfViewer2 Component

Add the Syncfusion SfPdfViewer2 component in razor file. Here, the SfPdfViewer2 component is added in the **~/Pages/Index.razor** file under the **~/Pages** folder.

{% tabs %}
{% highlight html tabtitle="~/Index.razor" %}

@page "/"

<SfPdfViewer2 
    DocumentPath="@DocumentPath" 
    ServiceUrl="https://ej2services.syncfusion.com/production/web-services/api/pdfviewer" 
    Height="100%" 
    Width="100%">
</SfPdfViewer2>

{% endhighlight %}
{% endtabs %}

N> If the `DocumentPath` property value is not provided, the SfPdfViewer2 component will be rendered without loading the PDF document. The users can then use the open option from the toolbar to browse and open the PDF as required.

N> [View Sample in GitHub]().

## Server side processing

Since Syncfusion SfPdfViewer2 (Blazor WebAssembly) component depends on server-side processing to render the PDF files, it is mandatory to create a web service as mentioned [here](https://www.syncfusion.com/kb/10346/how-to-create-pdf-viewer-web-service-application-in-asp-net-core).

N> [View web service sample in GitHub](https://github.com/SyncfusionExamples/EJ2-PDFViewer-WebServices)

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the application. Then, the Syncfusion `Blazor SfPdfViewer2` component will be rendered in the default web browser.

![Blazor SfPdfViewer2 Component](GettingStarted_images/blazor-pdfviewer.png)

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/PDFViewer).