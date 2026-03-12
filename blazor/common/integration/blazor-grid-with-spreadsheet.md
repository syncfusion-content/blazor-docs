---
layout: post
title: Syncfusion® Blazor Spreadsheet and DataGrid Integration
description: Step-by-step guide to integrating the Syncfusion Blazor Spreadsheet and DataGrid in Blazor applications.
platform: Blazor
control: Common
documentation: ug

---

# Integrating Blazor DataGrid Component into the Spreadsheet

This guide demonstrates how to integrate the **Syncfusion® Blazor DataGrid** with the **Syncfusion® Blazor Spreadsheet** component to enable a data workflow within a Blazor application.

The workflow includes exporting grid data to an Excel file, opening the file through Spreadsheet UI, and performing interactive editing.

If you haven't created your Blazor app yet, follow the [Blazor getting started guide](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio) to create a project.

## Prerequisites
Make sure your development environment meets the [system requirements](https://blazor.syncfusion.com/documentation/system-requirements) for Syncfusion® Blazor components.

## Install Required Syncfusion Packages

To add the Blazor DataGrid and Spreadsheet components to the app, open the NuGet Package Manager in Visual Studio (Tools → NuGet Package Manager → Manage NuGet Packages for Solution), then search for and install the NuGet packages listed below.

* [Syncfusion.Blazor.Spreadsheet](https://www.nuget.org/packages/Syncfusion.Blazor.Spreadsheet)
* [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid)
* [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

## Add Required Namespaces

Open the `~Components/_Imports.razor` file and import the below namespaces.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Spreadsheet
@using Syncfusion.Blazor.Grids

{% endhighlight %}
{% endtabs %}

## Register Syncfusion Blazor Service

Register the Syncfusion Blazor Service in the `Program.cs` file of your Blazor Server App.

{% tabs %}
{% highlight razor tabtitle="~/Program.cs" hl_lines="1 8" %}

using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
app.Run();

{% endhighlight %}
{% endtabs %}

## Add Stylesheet and Script Resources

Add the Syncfusion theme CSS and required scripts to the `~/Components/App.razor` file. The Spreadsheet requires its specific script in addition to the core script. 

{% tabs %}
{% highlight html  %}

<head>
     <!-- Syncfusion theme style sheet -->
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

<body>
    <!-- Syncfusion Blazor DataGrid component's script reference -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"></script>
    <!-- Syncfusion Blazor PDF Viewer component's script reference-->
    <script src="_content/Syncfusion.Blazor.Spreadsheet/scripts/syncfusion-blazor-spreadsheet.min.js"></script>
</body>

{% endhighlight %}
{% endtabs %}

## Integrating DataGrid and Spreadsheet

Add Spreadsheet and DataGrid component into the any **.razor** file.  

The example below displays a **DataGrid** with sample data, exports to Excel, and lets users open the exported file in **Spreadsheet** via the ribbon (File → Open). 

{% tabs %}
{% highlight razor %}

@page "/"
@rendermode InteractiveServer

@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Spreadsheet

<h3>Blazor DataGrid ➜ Spreadsheet Preview</h3>

<div class="mb-2">
    <SfButton CssClass="e-primary" @onclick="PreviewGridInSpreadsheet">Export Grid in Excel</SfButton>
    <span class="ms-3 text-muted">(Use Spreadsheet Ribbon → File to Open/Save as XLSX/CSV)</span>
</div>

<h5>DataGrid</h5>
<SfGrid TItem="Order" @ref="GridRef" DataSource="@Orders" AllowPaging="true" AllowExcelExport="true">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" />
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" Width="120" IsPrimaryKey="true" />
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer" Width="150" />
        <GridColumn Field="@nameof(Order.Freight)" HeaderText="Freight" Width="120" Format="C2" />
        <GridColumn Field="@nameof(Order.ShipCity)" HeaderText="Ship City" Width="150" />
    </GridColumns>
</SfGrid>

<h5>Spreadsheet</h5>
<div class="mt-3">
    <SfSpreadsheet AllowNumberFormatting="true"
                   AllowCellFormatting="true"
                   AllowAutofill="true"
                   Height="250px"
                   Width="auto">
        <SpreadsheetRibbon></SpreadsheetRibbon>
    </SfSpreadsheet>
</div>

@code {
    private SfGrid<Order>? GridRef;

    private List<Order> Orders = new()
    {
        new() { OrderID = 10001, CustomerID = "ALFKI", Freight = 2.30, ShipCity = "Denmark" },
        new() { OrderID = 10002, CustomerID = "ANATR", Freight = 3.30, ShipCity = "Brazil" },
        new() { OrderID = 10003, CustomerID = "ANTON", Freight = 4.30, ShipCity = "Germany" },
        new() { OrderID = 10004, CustomerID = "BLONP", Freight = 5.30, ShipCity = "USA" },
        new() { OrderID = 10005, CustomerID = "BOLID", Freight = 6.30, ShipCity = "Brazil" }
    };

    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; } = "";
        public double Freight { get; set; }
        public string ShipCity { get; set; } = "";
    }

    private async Task PreviewGridInSpreadsheet()
    {
        if (GridRef is not null)
        {
            await GridRef.ExportToExcelAsync();
        }
    }
}

{% endhighlight %}
{% endtabs %}

## Run the Application

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This renders the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, Spreadsheet components in the default web browser.

**Expected Behavior**
* DataGrid renders with sample records.
* Clicking **Export Grid to Excel** downloads an `.xlsx` file.
* In the Spreadsheet, open it via **Ribbon → File → Open**.
* Spreadsheet displays the workbook for editing.

**Output:**
![Blazor DataGrid With Spreadsheet](images/datagrid-with-spreadsheet.webp)
