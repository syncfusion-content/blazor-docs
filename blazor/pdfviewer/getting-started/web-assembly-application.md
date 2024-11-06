---
layout: post
title: Getting Started with PDF Viewer in Blazor WASM App | Syncfusion
description: Checkout and learn about getting started with Blazor PDF Viewer component in Blazor WebAssembly (WASM) App using Visual Studio and more.
platform: Blazor
control: PDF Viewer
documentation: ug
---

N> Syncfusion recommends using [Blazor PDF Viewer (NextGen)](https://blazor.syncfusion.com/documentation/pdfviewer-2/getting-started/server-side-application) Component which provides fast rendering of pages and improved performance. Also, there is no need of external Web service for processing the files and ease out the deployment complexity. It can be used in Blazor Server, WASM and MAUI applications without any changes.

# Getting Started with Blazor PDF Viewer Component in Blazor WASM App

This section briefly explains about how to include [Blazor PDF Viewer](https://www.syncfusion.com/blazor-components/blazor-pdf-viewer) component in your Blazor WebAssembly (WASM) App using Visual Studio.

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Integrate PDF Viewer into Blazor WebAssembly App

1. Start Visual Studio and select **Create a new project**.
2. For a Blazor WebAssembly experience, choose the **Blazor WebAssembly App** template and select **Next**.
![Create-a-new-WASM-app](gettingstarted-images/Create-new-WASM-app.png)
3. Provide a **Project name** and confirm that the *Location* is correct. Select **Next**.
![Set-project-name](gettingstarted-images/Set-WASM-project-name.png)
4. In **Additional information dialog**, set target framework.
![Addition-information-WASM](gettingstarted-images/Additional_information_WASM.png)

## Install Blazor PDFViewer NuGet package in WASM App

To add Blazor PDF Viewer component in Blazor WebAssembly App, use `SfPdfViewer` component in [Syncfusion.Blazor.PdfViewer](https://www.nuget.org/packages/Syncfusion.Blazor.PdfViewer) NuGet package.

N> This component requires server-side processing to render the PDF files through web service

## Register Syncfusion Blazor Service

Open **~/_Imports.razor** file and import the Syncfusion.Blazor namespace.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor

{% endhighlight %}
{% endtabs %}

Now, register the Syncfusion Blazor Service in the Blazor WebAssembly App. Here, Syncfusion Blazor Service is registered by setting [IgnoreScriptIsolation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.GlobalOptions.html#Syncfusion_Blazor_GlobalOptions_IgnoreScriptIsolation) property as true to load the scripts externally in the [next steps](#add-script-reference).

N> From 2022 Vol-1 (20.1) version, the default value of `IgnoreScriptIsolation` is changed to `true`. It is not necessary to set the `IgnoreScriptIsolation` property to refer scripts externally, since the default value has already been changed to true, and this property is obsolete.

* Open **~/Program.cs** file and register the Syncfusion Blazor Service in the client web app.

{% tabs %}
{% highlight C# tabtitle=".NET 6 & .NET 7 (~/Program.cs)" hl_lines="3 11" %}

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSyncfusionBlazor();
await builder.Build().RunAsync();
....

{% endhighlight %}

{% highlight c# tabtitle=".NET 5 & .NET 3.X (~/Program.cs)" hl_lines="1 10" %}

using Syncfusion.Blazor;

namespace WebApplication1
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            ....
            builder.Services.AddSyncfusionBlazor();
            await builder.Build().RunAsync();
        }
    }
}

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
{% highlight html tabtitle="~/index.html" hl_lines="4" %}

<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor.PdfViewer/scripts/syncfusion-blazor-pdfviewer.min.js" type="text/javascript"></script>
</head>

{% endhighlight %}
{% endtabs %}

N> Checkout [Adding Script Reference topic](https://blazor.syncfusion.com/documentation/common/adding-script-references) to learn different ways to add script reference in Blazor Application.

N> Syncfusion recommends to reference scripts using [Static Web Assets](https://blazor.syncfusion.com/documentation/common/adding-script-references#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/common/adding-script-references#cdn-reference) and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator) by [disabling JavaScript isolation](https://blazor.syncfusion.com/documentation/common/adding-script-references#disable-javascript-isolation) for better loading performance of the Blazor application.

## Add Blazor PDF Viewer Component

* Open **~/_Imports.razor** file or any other page under the `~/Pages` folder where the component is to be added and import the **Syncfusion.Blazor.PdfViewer** namespace.

{% tabs %}
{% highlight razor tabtitle="~/Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.PdfViewer

{% endhighlight %}
{% endtabs %}

* Now, add the Syncfusion PDF Viewer component in razor file. Here, the PDF Viewer component is added in the **~/Pages/Index.razor** file under the **~/Pages** folder.

{% tabs %}
{% highlight razor %}

<SfPdfViewer DocumentPath="PDF_Succinctly.pdf" ServiceUrl="https://ej2services.syncfusion.com/production/web-services/api/pdfviewer" Height="500px" Width="1060px"></SfPdfViewer>

{% endhighlight %}
{% endtabs %}

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-classic-examples/tree/master/Getting%20Started/Client-side%20application).

## Server side processing

Since Syncfusion PDF Viewer (Blazor WebAssembly) component depends on server-side processing to render the PDF files, it is mandatory to create a web service as mentioned [here](https://support.syncfusion.com/kb/article/8997/how-to-create-pdf-viewer-web-service-application-in-aspnet-core).

N> [View web service sample in GitHub](https://github.com/SyncfusionExamples/EJ2-PDFViewer-WebServices)

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the application. Then, the Syncfusion `Blazor PDF Viewer` component will be rendered in the default web browser.

![Blazor PDF Viewer Component](gettingstarted-images/blazor-pdfviewer.png)

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/PDFViewer).

## Load the desired PDF at initial loading and change the document path at runtime

You can load your PDF document for initial loading as well as change the document at run-time in PDF Viewer WebAssembly projects. To achieve that, you need to create the web services and add your documents to that web service project. Then mention that web service localhost path as the service URL in your web assembly project.

Refer,[How to create PDF Viewer Web Service](https://support.syncfusion.com/kb/article/9766/how-to-create-pdf-viewer-web-service-in-net-core-31-and-above).

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.PdfViewer
@using System.Web
@inject HttpClient Http

<SfButton OnClick="LoadAnotherDocument">Load Another Document</SfButton>

<!--ServiceUrl must be the webservice output path and you have to run the webservice first to get the serviceurl. Also it should be in runnable state-->
<SfPdfViewer DocumentPath="@DocumentPath"
             ServiceUrl="https://localhost:5001/pdfviewer"
             Height="500px" Width="1060px"></SfPdfViewer>

@code
{
    SfPdfViewer PdfViewer;

    //Sets the PDF document path for initial loading.
    private string DocumentPath { get; set; } = "PDF Succinctly.pdf";

    private async Task LoadAnotherDocument()
    {
        //Sends a GET request to a specified Uri and return the response body as a byte array.
        byte[] byteArray = await Http.GetByteArrayAsync("Data/FormFillingDocument.pdf");
        //Converts the byte array into base64 string.
        string base64String = Convert.ToBase64String(byteArray);
        //Sets the base64 string as document path for the PDF Viewer.
        DocumentPath = "data:application/pdf;base64," + base64String;
    }
}
```

N> [View sample in GitHub](https://github.com/SyncfusionExamples/blazor-pdf-viewer-classic-examples/tree/master/Load%20and%20Save/Load%20a%20PDF%20file%20using%20local%20service).
