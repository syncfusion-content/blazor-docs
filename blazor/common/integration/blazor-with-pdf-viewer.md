---
layout: post
title: Syncfusion® Blazor PDF Viewer and DataGrid Integration
description: Step-by-step guide to integrate the Syncfusion Blazor PDF Viewer and DataGrid in Blazor Web App (Server).
platform: Blazor
control: Common
documentation: ug
---

# Integrating Syncfusion® Blazor DataGrid with PDF Viewer

This article explains how to integrate the **[Syncfusion® Blazor PDF Viewer](https://www.syncfusion.com/pdf-viewer-sdk/blazor-pdf-viewer)** together with the **[Syncfusion® Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid)** in a Blazor Web App using the Server render mode.

This guide uses [Visual Studio Code](https://code.visualstudio.com/). If you haven’t created a Blazor Web app yet, follow the [Blazor getting started guide](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=visual-studio-code) to create your project.

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements): Ensure your development environment meets the required system specifications for using Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components.

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor PDF Viewer, DataGrid, and Themes NuGet packages

From the server project folder (where the `.csproj` is located), install the required packages:
 * [Syncfusion.Blazor.SfPdfViewer](https://www.nuget.org/packages/Syncfusion.Blazor.SfPdfViewer) 
 * [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid)
 * [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)
 * [SkiaSharp.Views.Blazor](https://www.nuget.org/packages/SkiaSharp.Views.Blazor)

{% tabs %}

{% highlight c# tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.SfPdfViewer -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Grid -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet add package SkiaSharp.Views.Blazor
dotnet restore

{% endhighlight %}

{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the available NuGet package list with component details. Verify the latest versions before installation.

## Add required namespaces

Add Syncfusion<sup style="font-size:70%">&reg;</sup> namespaces in the server project's **~/Components/_Imports.razor** file.

{% tabs %}
{% highlight razor tabtitle="_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.SfPdfViewer
@using Syncfusion.Blazor.Grids

{% endhighlight %}
{% endtabs %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service

Register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in your server app’s **~/Program.cs** file.

{% tabs %}
{% highlight c# tabtitle="Program.cs" hl_lines="2 9 11 13" %}

...
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents() 
    .AddInteractiveServerComponents();
// Configure SignalR to support large PDF file transfers
builder.Services.AddSignalR(o => { o.MaximumReceiveMessageSize = 102400000; });

builder.Services.AddMemoryCache();
//Add Syncfusion Blazor service to the container.
builder.Services.AddSyncfusionBlazor();

...

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

Add the following stylesheet and script references in the server app's **~/Components/App.razor** (inside the head/body as appropriate). Ensure no other Syncfusion theme CSS (e.g., bootstrap5.css, material.css) is referenced to avoid conflicts.

{% tabs %}
{% highlight html tabtitle="App.razor" hl_lines="3 8 11" %}

<head>
    <!-- Syncfusion theme stylesheet -->
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
</head>

<body>
    <!-- Syncfusion Blazor PDF Viewer component script -->
    <script src="_content/Syncfusion.Blazor.SfPdfViewer/scripts/syncfusion-blazor-sfpdfviewer.min.js" type="text/javascript"></script>

    <!-- Syncfusion Blazor Core script (required for most components, including DataGrid) -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>

{% endhighlight %}
{% endtabs %}

## Configure render mode (Server)

For Server render mode, if your app's interactivity location is set to `Per page/component`, add the following directive at the top of each **~Pages/*.razor** file that requires interactive Server components:

**Per‑page directive (Server)**

{% tabs %}
{% highlight razor %}

@* Define the desired render mode here *@
@rendermode InteractiveServer

{% endhighlight %}
{% endtabs %}

N> If the `interactivity location` is set to `Global` and the app is configured for Server render mode, no per‑page directive is required.

## Add Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor PDF Viewer and DataGrid components

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> PDF Viewer and DataGrid components to a `.razor` file in the server project's `Pages` folder (for example, **~/Pages/Home.razor**):

{% tabs %}
{% highlight razor %}

@page "/"
@rendermode InteractiveServer

<h1>PDF Viewer</h1>

<SfPdfViewer2 DocumentPath="https://cdn.syncfusion.com/content/pdf/pdf-succinctly.pdf"
              Height="100%"
              Width="100%">
</SfPdfViewer2>

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

N> In Syncfusion PDF Viewer, if the [DocumentPath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfPdfViewer.PdfViewerBase.html#Syncfusion_Blazor_SfPdfViewer_PdfViewerBase_DocumentPath) property is not set, the PDF Viewer renders without loading a PDF. Use the **Open** toolbar option to browse and open a PDF.

## Run the application

```

dotnet run

```

The app launches and renders the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor PDF Viewer and DataGrid in your default browser.

![Blazor DataGrid with PDF Viewer](images/blazor-datagrid-with-pdf-viewer-integration.webp)

## Use cases

Integrating the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid with PDF Viewer provides powerful solutions for various business scenarios:

### Invoice management system

Display a list of invoices in the DataGrid with columns for invoice number, customer name, date, and amount. When a user selects an invoice row, the PDF Viewer loads and displays the corresponding invoice PDF document. This allows users to quickly browse through invoices in the grid and view detailed invoice documents without leaving the page.

### Document repository and archive

Create a document management system where the DataGrid shows metadata such as document title, author, category, upload date, and file size. Users can click on a document row to preview the PDF in the viewer, enabling efficient document browsing and quick access to content without downloading files.

### Report viewing dashboard

Build a reporting dashboard where the DataGrid lists available reports (sales reports, financial statements, analytics) with filters for date range, department, or report type. Selecting a report row dynamically loads the PDF report in the viewer, providing a seamless experience for business users to access and review multiple reports.

### Contract and agreement management

Implement a contract management system displaying contract records in the DataGrid with contract number, party names, start date, end date, and status. Users can select contracts to view the full PDF document in the viewer, making it easy to manage and review legal documents, track renewals, and maintain compliance.

### Educational material distribution

Develop an e-learning platform where the DataGrid shows course materials, assignments, or lecture notes with columns for title, subject, instructor, and upload date. Students can click on any material to view the PDF content directly in the viewer, streamlining access to educational resources.

### Healthcare patient records

Implement a patient record system where lab reports, prescriptions, and medical documents are displayed in a DataGrid with patient details, document type, date, and status. Healthcare professionals can select a record to view the full PDF instantly, improving diagnosis support, documentation accuracy, and patient care coordination.

## See also

* [Getting Started with Syncfusion Blazor PDF Viewer in Blazor WASM](https://help.syncfusion.com/document-processing/pdf/pdf-viewer/blazor/getting-started/web-assembly-application)
* [Getting Started with Syncfusion Blazor DataGrid in Blazor WASM](https://blazor.syncfusion.com/documentation/datagrid/getting-started)
* [Blazor DataGrid Demo – Overview](https://blazor.syncfusion.com/demos/datagrid/overview?theme=fluent2) 