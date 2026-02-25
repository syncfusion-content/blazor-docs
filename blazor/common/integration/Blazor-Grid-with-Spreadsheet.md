---
layout: post
title: Syncfusion® Blazor Spreadsheet and Data Grid Integration
description: Step-by-step guide to integrating the Syncfusion Blazor Spreadsheet and Data Grid in Blazor applications.
platform: Blazor
control: Common
documentation: ug

---

# Integrating Blazor DataGrid Component into the Spreadsheet

This guide demonstrates how to integrate the **Syncfusion® Blazor DataGrid** with the **Syncfusion® Blazor Spreadsheet** component to enable a data workflow within a Blazor application.

The workflow includes exporting grid data to an Excel file, opening the file through Spreadsheet UI, and performing interactive editing.

This guidance applies to the following Blazor project types:
* Blazor Web App 
  * Render modes: Auto, WebAssembly, Server
* Blazor WebAssembly (WASM)
* Blazor Server

If you haven't created your Blazor app yet, follow the [Blazor getting started guide](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=visual-studio-code) to create a project.

## Prerequisites
Make sure your development environment meets the [system requirements](https://blazor.syncfusion.com/documentation/system-requirements) for Syncfusion® Blazor components.

## Install Required Syncfusion Packages
Install the necessary Syncfusion packages based on your project type.

### Installation Locations
| Project Type | Where to Install Packages | Notes |
|--------------|---------------------------|-------|
| Blazor Web App – Auto | Client project | Components execute in client context |
| Blazor Web App – Server | Server project | Components run on server |
| Blazor WebAssembly | Main project | All packages go into the WASM project |
| Blazor Server | Main project | Executes entirely on server |

### Install via CLI

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.Spreadsheet -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Grid -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}

### Install via NuGet
* [Syncfusion.Blazor.Spreadsheet](https://www.nuget.org/packages/Syncfusion.Blazor.Spreadsheet)
 * [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid)
 * [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

## Add Required Namespaces
Add these namespaces to the appropriate `/_Imports.razor` file depending on the project type:

| Project Type | Where to Install Packages | 
|--------------|---------------------------|
| WebAssembly or Auto | ~/_Imports.razor in the client project |
| Server | ~/Components/_Imports.razor |
| Standalone Blazor WASM | ~/_Imports.razor |

Add the following namespaces: 

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Spreadsheet
@using Syncfusion.Blazor.Grids

{% endhighlight %}
{% endtabs %}

## Register Syncfusion Blazor Service

Register the Syncfusion Blazor Service in the `Program.cs` file of your Blazor App.

{% tabs %}
{% highlight razor tabtitle="~/Program.cs" hl_lines="1 5" %}

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

Add the Syncfusion theme CSS and required scripts to the **host page** for your project type. Use one of the supported themes (e.g., bootstrap5.css). The Spreadsheet requires its specific script in addition to the core script. 

| Project Type | File to add scripts & stylesheet | 
|--------------|---------------------------|
| WebAssembly or Auto | ~/Components/App.razor |
| Server | wwwroot/index.html |
| Standalone Blazor WASM | Pages/_Host.cshtml |

{% tabs %}
{% highlight html  %}

<head>
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"></script>
    <script src="_content/Syncfusion.Blazor.Spreadsheet/scripts/syncfusion-blazor-spreadsheet.min.js"></script>
</head>

{% endhighlight %}
{% endtabs %}

## Integrating DataGrid and Spreadsheet

If your Blazor Web App uses **Per page/Component Interactivity**, you must specify the appropriate **@rendermode** directive at the top of the component. 

You may choose one of the following based on your scenario: 

* InteractiveAuto — Automatically selects WASM or Server 
* InteractiveWebAssembly — Forces client-side execution 
* InteractiveServer — Forces server-side execution 

N> If Global interactivity is configured in **App.razor**, this directive is not required 

**Example (per page):**

{% tabs %}
{% highlight razor %}

@* Define the desired render mode here *@
@rendermode InteractiveAuto

{% endhighlight %}
{% endtabs %}


Add Spreadsheet and Data Grid component into the any **.razor** file.  

The example below displays a **Data Grid** with sample data, exports to Excel, and lets users open the exported file in **Spreadsheet** via the ribbon (File → Open). 

{% tabs %}
{% highlight razor %}

@page "/"
@rendermode InteractiveServer

@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Spreadsheet

<h3>Simple Blazor DataGrid ➜ Spreadsheet Preview</h3>

<div class="mb-2">
    <SfButton CssClass="e-primary" @onclick="PreviewGridInSpreadsheet">Export Grid in Excel</SfButton>
    <span class="ms-3 text-muted">(Use Spreadsheet Ribbon → File to Open/Save as XLSX/CSV)</span>
</div>

<h5>DataGrid</h5>
<SfGrid TItem="Order" @ref="GridRef" DataSource="Orders" AllowPaging="true" AllowExcelExport="true">
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

```
dotnet run
```

**Expected Behavior**
* DataGrid renders with sample records.
* Clicking **Export Grid to Excel** downloads an `.xlsx` file.
* In the Spreadsheet, open it via **Ribbon → File → Open**.
* Spreadsheet displays the workbook for editing.

**OutPut:**
![Blazor DataGrid With Spreadsheet](./images/Datagrid%20with%20spreadsheet.gif)
