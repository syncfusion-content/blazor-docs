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

For Server render mode, if your app's interactivity location is set to `Per page/component`, add the following directive at the top of each **~Pages/*.razor** file that requires interactive Server components.

**Per‑page directive (Server)**

{% tabs %}
{% highlight razor %}

@* Define the desired render mode here *@
@rendermode InteractiveServer

{% endhighlight %}
{% endtabs %}

N> If the `interactivity location` is set to `Global` and the app is configured for Server render mode, no per‑page directive is required.

## Integrate DataGrid and PDF Viewer

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> PDF Viewer and DataGrid components to any `.razor` file in the server project's `Pages` folder (for example, **~/Pages/Home.razor**).

The example below displays a **DataGrid** with sample order data, selecting a row generates and loads a detailed PDF for that order in the **PDF Viewer**.

{% tabs %}
{% highlight razor %}

@page "/"
@rendermode InteractiveServer

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.SfPdfViewer
@using Syncfusion.Pdf
@using Syncfusion.Pdf.Graphics
@using Syncfusion.Pdf.Grid
@using Syncfusion.Drawing

<PageTitle>Dynamic PDF Viewer</PageTitle>

<div class="container-fluid">
    <h2 class="mb-4">Order Management System</h2>

    <!-- DataGrid Section -->
    <div class="row">
        <div class="col-12 mb-4">
            <h4>Orders - DataGrid</h4>
            <p class="text-muted">Click on any row to view detailed order information in the PDF viewer below</p>
            
            <SfGrid DataSource="@Orders" TValue="Order" AllowSelection="true">
                <GridSelectionSettings Type="SelectionType.Single"></GridSelectionSettings>
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
            <SfPdfViewer2 @ref="PdfViewer" Height="600px" Width="100%"></SfPdfViewer2>
        </div>
    </div>
</div>

@code {
    private SfPdfViewer2? PdfViewer;
    private Random _random = new Random();
    public List<Order> Orders { get; set; } = new();
    
    // Load welcome PDF when the page first renders
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender)
        {
            var welcomePdf = GenerateWelcomePdf();
            using var pdfStream = new MemoryStream(welcomePdf);
            await PdfViewer!.LoadAsync(pdfStream);
        }
    }

    // Initialize sample order data
    protected override void OnInitialized()
    {
        string[] customers = { "ALFKI|Alfreds Futterkiste", "ANANTR|Ana Trujillo Emparedados", 
                              "ANTON|Antonio Moreno Taquería", "BLONP|Blondel père et fils", 
                              "BOLID|Bólido Comidas preparadas" };
        
        Orders = Enumerable.Range(1, 5).Select(x => {
            var custData = customers[x - 1].Split('|');
            return new Order()
            {
                OrderID = 1000 + x,
                CustomerID = custData[0],
                CustomerName = custData[1],
                ShippingCost = Math.Round(15.5 + (x * 8.25), 2),
                OrderDate = DateTime.Now.AddDays(-x * 2),
                ShipAddress = $"{100 + x} Commerce Street",
                ShipCity = RandomPick("Berlin", "Madrid", "Paris", "London", "Rome"),
                ShipCountry = RandomPick("Germany", "Spain", "France", "UK", "Italy"),
                ShipPostalCode = $"{10000 + x * 100}",
                EmployeeName = RandomPick("John Smith", "Jane Doe", "Bob Wilson", "Alice Brown", "Mike Johnson"),
                OrderItems = GenerateItems(x)
            };
        }).ToList();
    }

    private string RandomPick(params string[] items) => items[_random.Next(items.Length)];

    // Generate random order items for demonstration purposes
    private List<OrderItem> GenerateItems(int seed)
    {
        string[] products = { "Laptop Computer", "Wireless Mouse", "Mechanical Keyboard", "LED Monitor", 
                             "Gaming Headset", "USB Hub", "Webcam", "External SSD" };
        var rnd = new Random(seed * 100);
        return Enumerable.Range(0, rnd.Next(4, 8)).Select(_ => new OrderItem()
        {
            ProductName = products[rnd.Next(products.Length)],
            Quantity = rnd.Next(1, 8),
            UnitPrice = rnd.Next(25, 450),
            Discount = rnd.Next(0, 20)
        }).ToList();
    }

    // Handle grid row selection and generate PDF
    private async Task OnRowSelected(RowSelectEventArgs<Order> args)
    {
        var pdfBytes = GenerateOrderPdf(args.Data);
        using var pdfStream = new MemoryStream(pdfBytes);
        await PdfViewer!.LoadAsync(pdfStream);
    }

    // Generate a welcome PDF shown on initial page load
    private byte[] GenerateWelcomePdf()
    {
        using (PdfDocument doc = new PdfDocument())
        {
            var page = doc.Pages.Add();
            var g = page.Graphics;
            var titleFont = new PdfStandardFont(PdfFontFamily.Helvetica, 24, PdfFontStyle.Bold);
            var textFont = new PdfStandardFont(PdfFontFamily.Helvetica, 12);

            // Draw title
            g.DrawString("Welcome to Order Management System", titleFont, PdfBrushes.DarkBlue, 
                new PointF(40, 90));

            // Draw instructions
            string instructions = "Please select an order from the grid above to view detailed information here.\n\n" +
                                "Each order contains comprehensive details including customer information, shipping details, " +
                                "and a complete breakdown of all items in the order with pricing information.";

            g.DrawString(instructions, textFont, PdfBrushes.Black, 
                new RectangleF(40, 140, page.GetClientSize().Width - 80, 100));

            using var ms = new MemoryStream();
            doc.Save(ms);
            return ms.ToArray();
        }
    }

    // Generate a detailed order PDF document
    private byte[] GenerateOrderPdf(Order order)
    {
        using (PdfDocument doc = new PdfDocument())
        {
            var page = doc.Pages.Add();
            var g = page.Graphics;
            float margin = 30, y = margin, pageWidth = page.GetClientSize().Width;

            // Define fonts
            var titleFont = new PdfStandardFont(PdfFontFamily.Helvetica, 22, PdfFontStyle.Bold);
            var textFont = new PdfStandardFont(PdfFontFamily.Helvetica, 11);
            var headerFont = new PdfStandardFont(PdfFontFamily.Helvetica, 12, PdfFontStyle.Bold);
            var labelFont = new PdfStandardFont(PdfFontFamily.Helvetica, 10, PdfFontStyle.Bold);

            // Draw title
            g.DrawString($"Order #{order.OrderID}", titleFont, PdfBrushes.DarkBlue, new PointF(margin, y));
            y += 35;

            // Draw description
            string description = 
                $"This document contains the complete order summary for Order #{order.OrderID} placed by {order.CustomerName} on {order.OrderDate:MMMM dd, yyyy}. " +
                $"The order is being processed by {order.EmployeeName} and will be shipped to {order.ShipCity}, {order.ShipCountry}. " +
                $"Below you will find detailed information about each item including quantities, pricing, and applicable discounts.";

            g.DrawString(description, textFont, PdfBrushes.Black, 
                new RectangleF(margin, y, pageWidth - (2 * margin), 80));
            y += 60;

            // Draw order information section with background
            g.DrawRectangle(new PdfPen(Color.LightGray, 1), new PdfSolidBrush(Color.LightSteelBlue), 
                new RectangleF(margin, y, pageWidth - (2 * margin), 80));
            
            y += 10;
            float col1 = margin + 10, col2 = margin + 250;

            // Order details - Row 1
            g.DrawString("Customer:", labelFont, PdfBrushes.Black, new PointF(col1, y));
            g.DrawString(order.CustomerName, textFont, PdfBrushes.Black, new PointF(col1 + 80, y));
            g.DrawString("Order Date:", labelFont, PdfBrushes.Black, new PointF(col2, y));
            g.DrawString(order.OrderDate.ToString("MM/dd/yyyy"), textFont, PdfBrushes.Black, new PointF(col2 + 80, y));
            y += 20;

            // Order details - Row 2
            g.DrawString("Sales Rep:", labelFont, PdfBrushes.Black, new PointF(col1, y));
            g.DrawString(order.EmployeeName, textFont, PdfBrushes.Black, new PointF(col1 + 80, y));
            g.DrawString("Shipping Cost:", labelFont, PdfBrushes.Black, new PointF(col2, y));
            g.DrawString($"${order.ShippingCost:F2}", textFont, PdfBrushes.Black, new PointF(col2 + 100, y));
            y += 20;

            // Order details - Row 3
            g.DrawString("Ship To:", labelFont, PdfBrushes.Black, new PointF(col1, y));
            g.DrawString($"{order.ShipAddress}, {order.ShipCity}, {order.ShipPostalCode}", 
                textFont, PdfBrushes.Black, new PointF(col1 + 80, y));
            y += 40;

            // Order items section header
            g.DrawString("Order Items Details", headerFont, PdfBrushes.DarkSlateGray, new PointF(margin, y));
            y += 25;

            // Create table grid for order items
            PdfGrid grid = new PdfGrid();
            grid.Columns.Add(5);
            grid.Columns[0].Width = 160;  // Product
            grid.Columns[1].Width = 60;   // Quantity
            grid.Columns[2].Width = 75;   // Unit Price
            grid.Columns[3].Width = 70;   // Discount
            grid.Columns[4].Width = 85;   // Line Total

            // Add and style header row
            PdfGridRow headerRow = grid.Headers.Add(1)[0];
            headerRow.Cells[0].Value = "Product";
            headerRow.Cells[1].Value = "Quantity";
            headerRow.Cells[2].Value = "Unit Price";
            headerRow.Cells[3].Value = "Discount";
            headerRow.Cells[4].Value = "Line Total";

            PdfGridCellStyle headerStyle = new PdfGridCellStyle
            {
                BackgroundBrush = PdfBrushes.DarkGray,
                TextBrush = PdfBrushes.White,
                Font = headerFont
            };
            
            for (int i = 0; i < headerRow.Cells.Count; i++)
            {
                headerRow.Cells[i].Style = headerStyle;
                // Center-align Quantity and Discount headers
                if (i == 1 || i == 3)
                    headerRow.Cells[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
                // Right-align Unit Price and Line Total headers
                else if (i == 2 || i == 4)
                    headerRow.Cells[i].StringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);
            }

            // Add data rows with alternating colors
            decimal subtotal = 0;
            int rowIndex = 0;

            foreach (var item in order.OrderItems)
            {
                decimal lineTotal = item.Quantity * item.UnitPrice * (1 - item.Discount / 100m);
                subtotal += lineTotal;

                PdfGridRow row = grid.Rows.Add();
                row.Cells[0].Value = item.ProductName;
                row.Cells[1].Value = item.Quantity.ToString();
                row.Cells[2].Value = $"${item.UnitPrice:F2}";
                row.Cells[3].Value = $"{item.Discount}%";
                row.Cells[4].Value = $"${lineTotal:F2}";

                // Center-align Quantity and Discount columns
                row.Cells[1].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
                row.Cells[3].StringFormat = new PdfStringFormat(PdfTextAlignment.Center, PdfVerticalAlignment.Middle);
                
                // Right-align Unit Price and Line Total columns
                row.Cells[2].StringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);
                row.Cells[4].StringFormat = new PdfStringFormat(PdfTextAlignment.Right, PdfVerticalAlignment.Middle);

                // Alternate row colors
                if (rowIndex++ % 2 == 1)
                    for (int i = 0; i < row.Cells.Count; i++)
                        row.Cells[i].Style.BackgroundBrush = PdfBrushes.LightGray;
            }

            // Apply grid styling
            grid.Style = new PdfGridStyle
            {
                Font = textFont,
                CellPadding = new PdfPaddings(5, 5, 5, 5)
            };

             // Draw the grid
            var layout = grid.Draw(page, new PointF(margin, y));
            y = layout.Bounds.Bottom + 20;

            // Draw totals section with right alignment
            float totalsLabelX = pageWidth - 230;
            float totalsValueX = pageWidth - margin - 10;

            // Subtotal
            g.DrawString("Subtotal:", headerFont, PdfBrushes.Black, new PointF(totalsLabelX, y));
            var subtotalText = $"${subtotal:F2}";
            var subtotalWidth = textFont.MeasureString(subtotalText).Width;
            g.DrawString(subtotalText, textFont, PdfBrushes.Black, 
                new PointF(totalsValueX - subtotalWidth, y));
            y += 20;

            // Shipping Cost
            g.DrawString("Shipping Cost:", headerFont, PdfBrushes.Black, new PointF(totalsLabelX, y));
            var shippingCostText = $"${order.ShippingCost:F2}";
            var shippingCostWidth = textFont.MeasureString(shippingCostText).Width;
            g.DrawString(shippingCostText, textFont, PdfBrushes.Black, 
                new PointF(totalsValueX - shippingCostWidth, y));
            y += 25;

            // Draw grand total with highlight
            g.DrawRectangle(new PdfPen(Color.DarkGreen, 2), new RectangleF(totalsLabelX - 10, y - 5, 220, 25));
            var totalFont = new PdfStandardFont(PdfFontFamily.Helvetica, 14, PdfFontStyle.Bold);
            g.DrawString("Grand Total:", totalFont, PdfBrushes.DarkGreen, new PointF(totalsLabelX, y));
            
            var grandTotalText = $"${(subtotal + (decimal)order.ShippingCost):F2}";
            var grandTotalWidth = totalFont.MeasureString(grandTotalText).Width;
            g.DrawString(grandTotalText, totalFont, PdfBrushes.DarkGreen, 
                new PointF(totalsValueX - grandTotalWidth, y));

            using var ms = new MemoryStream();
            doc.Save(ms);
            return ms.ToArray();
        }
    }

    // Data models
    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; } = "";
        public string CustomerName { get; set; } = "";
        public DateTime OrderDate { get; set; }
        public double ShippingCost { get; set; }
        public string ShipAddress { get; set; } = "";
        public string ShipCity { get; set; } = "";
        public string ShipPostalCode { get; set; } = "";
        public string ShipCountry { get; set; } = "";
        public string EmployeeName { get; set; } = "";
        public List<OrderItem> OrderItems { get; set; } = new();
    }

    public class OrderItem
    {
        public string ProductName { get; set; } = "";
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Discount { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

## Run the application

```

dotnet run

```

The app launches and renders the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor PDF Viewer and DataGrid in your default browser.

![Blazor DataGrid with PDF Viewer](images/datagrid-with-pdfviewer.webp)

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

* [Getting Started with Syncfusion Blazor PDF Viewer in Blazor WASM](https://help.syncfusion.com/document-processing/pdf/pdf-viewer/blazor/getting-started/web-assembly-application)
* [Getting Started with Syncfusion Blazor DataGrid in Blazor WASM](https://blazor.syncfusion.com/documentation/datagrid/getting-started)
* [Blazor DataGrid Demo – Overview](https://blazor.syncfusion.com/demos/datagrid/overview?theme=fluent2)