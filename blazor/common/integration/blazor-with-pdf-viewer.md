---
layout: post
title: Syncfusion® Blazor PDF Viewer and DataGrid Integration
description: Step-by-step guide to integrate the Syncfusion Blazor PDF Viewer and DataGrid in Blazor Web App (Server).
platform: Blazor
control: Common
documentation: ug
---

# Integrating Syncfusion® Blazor DataGrid with PDF Viewer

This article explains how to integrate the **[Syncfusion® Blazor PDF Viewer](https://www.syncfusion.com/pdf-viewer-sdk/blazor-pdf-viewer)** together with the **[Syncfusion® Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid)** in a Blazor Web App using Server render mode.

If you haven’t created a Blazor Web app yet, follow the [Blazor getting started guide](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=visual-studio-code) to create your project.

## Prerequisites

* [.NET 8.0 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0) or later
* .NET CLI or [Visual Studio Code](https://code.visualstudio.com/)
* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor PDF Viewer, DataGrid, and Themes NuGet packages

From the server project folder (where the `.csproj` is located), install the required packages:
 * [Syncfusion.Blazor.SfPdfViewer](https://www.nuget.org/packages/Syncfusion.Blazor.SfPdfViewer) 
 * [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid)
 * [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

{% tabs %}

{% highlight c# tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.SfPdfViewer -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Grid -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the available NuGet package list with component details. Verify the latest versions before installation.

## Add required namespaces

Add Syncfusion<sup style="font-size:70%">&reg;</sup> and required .NET namespaces in the `~/Components/_Imports.razor` file.

{% tabs %}
{% highlight razor tabtitle="_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.SfPdfViewer
@using Syncfusion.Blazor.Grids
@using System.IO
@using Microsoft.AspNetCore.Hosting

{% endhighlight %}
{% endtabs %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service

Register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in your server app’s `~/Program.cs` file.

{% tabs %}
{% highlight c# tabtitle="Program.cs" hl_lines="2 9 11 13" %}

...
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents() 
    .AddInteractiveServerComponents();
// Configure SignalR to support large PDF file transfers
builder.Services.AddSignalR(o => { o.MaximumReceiveMessageSize = 102400000; });
// Add memory cache for PDF Viewer component caching
builder.Services.AddMemoryCache();
//Add Syncfusion Blazor service to the container.
builder.Services.AddSyncfusionBlazor();
...

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

Add the following stylesheet and script references in the server app's `~/Components/App.razor` (inside the head/body as appropriate). Ensure no other Syncfusion theme CSS (e.g., bootstrap5.css, material.css) is referenced to avoid conflicts.

{% tabs %}
{% highlight html tabtitle="App.razor" hl_lines="3 8 10" %}

<head>
    <!-- Syncfusion theme stylesheet -->
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
</head>

<body>
    <!-- Syncfusion Blazor Core script (required for most components, including DataGrid) -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
    <!-- Syncfusion Blazor PDF Viewer component script -->
    <script src="_content/Syncfusion.Blazor.SfPdfViewer/scripts/syncfusion-blazor-sfpdfviewer.min.js" type="text/javascript"></script>
</body>

{% endhighlight %}
{% endtabs %}

N> Ensure the `Syncfusion.Blazor.Core` script is loaded before the `SfPdfViewer` script, as shown above. The PDF Viewer component depends on core Blazor functionality.

## Configure render mode (Server)

For Server render mode, if your app's interactivity location is set to `Per page/component`, add the following directive at the top of each `~Pages/*.razor` file that requires interactive Server components.

**Per‑page directive (Server)**

{% tabs %}
{% highlight razor %}

@* Define the desired render mode here *@
@rendermode InteractiveServer

{% endhighlight %}
{% endtabs %}

N> If the `interactivity location` is set to `Global` and the app is configured for Server render mode, no per‑page directive is required.

## Integrate DataGrid and PDF Viewer

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> PDF Viewer and DataGrid components to any `.razor` file in the server project's `Pages` folder (for example, `~/Pages/Home.razor`).

The example below displays a **DataGrid** with sample order data, selecting a row generates and loads a detailed PDF for that order in the **PDF Viewer**.

N> Ensure that PDF files are placed in the **wwwroot/PDFs** folder of your Blazor project. The PDF filename must match the `PdfFileName` property value from the selected order record. For example, if the `PdfFileName` is `Order_1001.pdf`, the file should exist at `wwwroot/PDFs/Order_1001.pdf`.

{% tabs %}
{% highlight razor %}

@page "/"
@rendermode InteractiveServer

@* Inject IWebHostEnvironment to access the web root path for locating PDF files *@
@inject IWebHostEnvironment WebHostEnvironment

<PageTitle>Dynamic PDF Viewer</PageTitle>

<div class="container-fluid">
    <h2 class="mb-4">Order Management System</h2>

    <!-- DataGrid Section -->
    <div class="row">
        <div class="col-12 mb-4">
            <h4>Orders - DataGrid</h4>
            <p class="text-muted">Click on any row to view detailed order information in the PDF viewer below</p>
            
            <!-- Syncfusion DataGrid with single row selection enabled -->
            <SfGrid DataSource="@Orders" TValue="Order" AllowSelection="true">
                <GridSelectionSettings Type="SelectionType.Single"></GridSelectionSettings>
                <!-- Event handler triggered when a row is selected -->
                <GridEvents TValue="Order" RowSelected="OnRowSelected"></GridEvents>
                <GridColumns>
                    <GridColumn Field="OrderID" HeaderText="Order ID" Width="120"></GridColumn>
                    <GridColumn Field="CustomerName" HeaderText="Customer" Width="150"></GridColumn>
                    <GridColumn Field="EmployeeName" HeaderText="Sales Rep" Width="150"></GridColumn>
                    <GridColumn Field="OrderDate" HeaderText="Order Date" Format="d" Width="130"></GridColumn>
                    <GridColumn Field="ShipCity" HeaderText="Ship City" Width="120"></GridColumn>
                    <GridColumn Field="ShippingCost" HeaderText="Shipping Cost" Format="C2" Width="120"></GridColumn>
                </GridColumns>
            </SfGrid>
        </div>
    </div>

    <!-- PDF Viewer Section -->
    <div class="row">
        <div class="col-12">
            <h4>Order Details - PDF Viewer</h4>
            @if (!string.IsNullOrEmpty(ErrorMessage))
            {
                <div class="alert alert-danger">@ErrorMessage</div>
            }
            <!-- Syncfusion PDF Viewer component for displaying order PDFs -->
            <SfPdfViewer2 @ref="PdfViewer" Height="600px" Width="100%"></SfPdfViewer2>
        </div>
    </div>
</div>

@code {
    // Reference to the PDF Viewer component for programmatic access
    private SfPdfViewer2? PdfViewer;
    
    // Collection of orders to display in the grid
    public List<Order> Orders { get; set; } = new();
    
    // Error message for user feedback
    private string ErrorMessage = string.Empty;

    // Initialize sample order data on component load
    protected override void OnInitialized()
    {
        // Define customer names
        string[] customers = { 
            "Alfreds Futterkiste", 
            "Ana Trujillo Emparedados", 
            "Antonio Moreno Taquería", 
            "Blondel père et fils", 
            "Bólido Comidas preparadas" 
        };

        // Define cities
        string[] cities = { "Berlin", "Madrid", "Paris", "London", "Rome" };

        // Define employee names for sales representatives
        string[] employees = { "John Smith", "Jane Doe", "Bob Wilson", "Alice Brown", "Mike Johnson" };
        
        // Create 5 sample orders with sequential data
        Orders = Enumerable.Range(1, 5).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerName = customers[x - 1],
            EmployeeName = employees[x - 1],
            OrderDate = DateTime.Now.AddDays(-x * 2),
            ShipCity = cities[x - 1],
            ShippingCost = Math.Round(15.5 + (x * 8.25), 2),
            PdfFileName = $"Order_{1000 + x}.pdf"
        }).ToList();
    }

    // Event handler for grid row selection - loads the corresponding PDF file
    private async Task OnRowSelected(RowSelectEventArgs<Order> args)
    {
        // Clear any previous error messages
        ErrorMessage = string.Empty;
        
        try
        {
            // Construct the full path to the PDF file
            // Note: PDF files should be placed in the wwwroot/PDFs folder of your Blazor project
            // The filename must match the PdfFileName property value from the selected order
            string pdfFilePath = Path.Combine(WebHostEnvironment.WebRootPath, "PDFs", args.Data.PdfFileName);
            
            // Check if the PDF file exists before attempting to load
            if (File.Exists(pdfFilePath))
            {
                // Read the PDF file as a byte array
                var pdfBytes = await File.ReadAllBytesAsync(pdfFilePath);
                
                // Create a memory stream from the PDF bytes
                using var pdfStream = new MemoryStream(pdfBytes);
                
                // Load the PDF into the viewer component
                if (PdfViewer != null)
                {
                    await PdfViewer.LoadAsync(pdfStream);
                }
            }
            else
            {
                // Display error if PDF file is not found
                ErrorMessage = $"PDF file not found: {args.Data.PdfFileName}";
                // For production apps, use ILogger instead of Console.WriteLine
                Console.WriteLine($"PDF file not found: {pdfFilePath}");
            }
        }
        catch (Exception ex)
        {
            // Handle and display any errors during PDF loading
            ErrorMessage = $"Error loading PDF: {ex.Message}";
            // For production apps, use ILogger instead of Console.WriteLine
            Console.WriteLine($"Error loading PDF: {ex.Message}");
        }
    }

    // Data model representing an order with shipping and customer details
    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; } = "";
        public string EmployeeName { get; set; } = "";
        public DateTime OrderDate { get; set; }
        public string ShipCity { get; set; } = "";
        public double ShippingCost { get; set; }
        // PDF filename that corresponds to this order
        // Important: The actual PDF file with this name must exist in wwwroot/PDFs folder
        public string PdfFileName { get; set; } = "";
    }
}

{% endhighlight %}
{% endtabs %}

N> This example uses direct file system access for simplicity. In production applications, consider implementing a dedicated file service with proper security, caching, and error handling. Ensure PDF files are stored in a secure location with appropriate access controls.

## Run the application

```

dotnet run

```

The app launches and renders the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor PDF Viewer and DataGrid in your default browser.

![Blazor DataGrid with PDF Viewer](images/datagrid-with-pdfviewer.webp)

**Expected behavior:**
1. The DataGrid displays 5 sample orders on page load
2. Clicking any row in the grid triggers the [RowSelected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowSelected) event
3. The PDF Viewer loads the corresponding PDF file (if it exists in `wwwroot/PDFs`)
4. If the PDF file is not found, an error message displays above the viewer

N> To fully test this example, create sample PDF files named `Order_1001.pdf` through `Order_1005.pdf` and place them in the `wwwroot/PDFs` folder of your project. You can use any PDF files for testing purposes.

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

## See also

* [Getting Started with Syncfusion Blazor PDF Viewer in Blazor Web App](https://help.syncfusion.com/document-processing/pdf/pdf-viewer/blazor/getting-started/web-app)
* [Getting Started with Syncfusion Blazor PDF Viewer in Blazor WASM](https://help.syncfusion.com/document-processing/pdf/pdf-viewer/blazor/getting-started/web-assembly-application)
* [Getting Started with Syncfusion Blazor DataGrid in Blazor Web App](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app)
* [Getting Started with Syncfusion Blazor DataGrid in Blazor WASM](https://blazor.syncfusion.com/documentation/datagrid/getting-started)
* [Blazor PDF Viewer Demo](https://liveviewereditorblazorapp.azurewebsites.net/demos/pdf-viewer/blazor-server/pdf-viewer/default-functionalities)
* [Blazor DataGrid Demo – Overview](https://blazor.syncfusion.com/demos/datagrid/overview?theme=fluent2)
 