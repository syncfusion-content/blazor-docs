---
layout: post
title: Syncfusion® Blazor DocumentEditor and DataGrid Integration
description: Step-by-step guide to integrate Syncfusion® Blazor DocumentEditor and DataGrid in Blazor applications.
platform: Blazor
control: common
documentation: ug
---

# Integrating Syncfusion® DataGrid with DocumentEditor in Blazor App

This guide shows how to integrate the **[Syncfusion® Blazor DocumentEditor](https://www.syncfusion.com/docx-editor-sdk/blazor-docx-editor)** (WordProcessor) together with the **[Syncfusion® Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid)** in a Blazor Web App using `Server` interactivity.

If you haven't created your Blazor App yet, follow the [Blazor getting started guide](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=visual-studio-code) to create a project.

## Install Syncfusion® NuGet packages

From the server project folder (where the `.csproj` file is located), install the following packages:

* [Syncfusion.Blazor.WordProcessor](https://www.nuget.org/packages/Syncfusion.Blazor.WordProcessor)
* [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid)
* [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

{% tabs %}
{% highlight bash tabtitle="Terminal" %}

dotnet add package Syncfusion.Blazor.WordProcessor -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Grid -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}
{% endtabs %}

> Do not install [Syncfusion.Blazor](https://www.nuget.org/packages/Syncfusion.Blazor/) together with [Syncfusion.Blazor.WordProcessor](https://www.nuget.org/packages/Syncfusion.Blazor.WordProcessor). They conflict and produce ambiguity errors.

## Add required namespaces

Open the `~/Components/_Imports.razor` file and import the Syncfusion® namespaces.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.DocumentEditor
@using Syncfusion.Blazor.Grids

{% endhighlight %}
{% endtabs %}

## Register Syncfusion® Blazor service

Add the Syncfusion® Blazor service to the `~/Program.cs` file to enable Syncfusion® components in the application.

{% tabs %}
{% highlight c# tabtitle="~/_Program.cs" hl_lines="1 8" %}

using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddSyncfusionBlazor();
....

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

To apply styles and enable Syncfusion® features, reference the theme CSS and scripts within the `~/Components/App.razor` file.

{% tabs %}
{% highlight html  %}

<head>
    <!-- Syncfusion theme stylesheet -->
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
</head>

<body>
    <!-- Syncfusion Blazor DocumentEditor component's script reference-->
    <script src="_content/Syncfusion.Blazor.WordProcessor/scripts/syncfusion-blazor-documenteditor.min.js" type="text/javascript"></script>

    <!-- Syncfusion Blazor DataGrid component's script reference -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>

{% endhighlight %}
{% endtabs %}

## Configure render mode

If your app’s interactivity location is set to `Per page/component`, add a render mode directive at the top of `~Pages/*.razor` where you need interactivity. 

{% tabs %}
{% highlight razor %}

@rendermode InteractiveServer

{% endhighlight %}
{% endtabs %}

N> If the `interactivity location` is set to `Global` and the app is configured for Server render mode, no per‑page directive is required.

## Integrate DataGrid and DocumentEditor

Add the Syncfusion® Blazor **DocumentEditor** and **DataGrid** components to a `.razor` file within your app. 

In this example, clicking the Invoice button in the **DataGrid** row generates an invoice for that order and displays it in the **DocumentEditor** for preview.

{% tabs %}
{% highlight razor %}
{% raw %}

@page "/"
@rendermode InteractiveServer

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DocumentEditor

<h4 class="mt-4">Invoice Generator</h4>

<SfGrid TItem="Order" DataSource="@Orders" AllowPaging="true">

    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" Width="120" />
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer" Width="150" />
        <GridColumn Field="@nameof(Order.Freight)" HeaderText="Freight" Width="120" Format="C2" />
        <GridColumn Field="@nameof(Order.ShipCity)" HeaderText="City" Width="150" />

        <GridColumn HeaderText="Invoice" Width="130">
            <Template>
                @{
                    var row = context as Order;
                }
                <button class="btn btn-success btn-sm" @onclick="@(() => GenerateInvoice(row))">
                    Generate Invoice
                </button>
            </Template>
        </GridColumn>
    </GridColumns>

</SfGrid>

<h4 class="mt-4">Invoice Preview</h4>

<SfDocumentEditorContainer @ref="EditorContainer" EnableToolbar="true">
</SfDocumentEditorContainer>

@code {
    private SfDocumentEditorContainer? EditorContainer;

    private List<Order> Orders = new()
    {
        new() { OrderID = 10001, CustomerID = "ALFKI", Freight = 110.50, ShipCity = "Denmark" },
        new() { OrderID = 10002, CustomerID = "ANATR", Freight = 220.00, ShipCity = "Brazil" },
        new() { OrderID = 10003, CustomerID = "ANTON", Freight = 330.75, ShipCity = "Germany" },
        new() { OrderID = 10004, CustomerID = "BLONP", Freight = 180.90, ShipCity = "USA" },
        new() { OrderID = 10005, CustomerID = "BOLID", Freight = 440.00, ShipCity = "Brazil" }
    };

    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; } = "";
        public double Freight { get; set; }
        public string ShipCity { get; set; } = "";
    }

    private async Task GenerateInvoice(Order order)
    {
        if (EditorContainer?.DocumentEditor == null)
            return;
        
        var sfdt = BuildInvoice(order);
        await EditorContainer.DocumentEditor.OpenAsync(sfdt);
    }

    private string BuildInvoice(Order o)
    {
        // Generate the invoice in SFDT format.
        return $$"""
        {
            "sections": [
                {
                    "blocks": [
                        { "paragraphFormat": { "textAlignment": "Center" },
                        "inlines": [ { "text": "My Orders PVT LTD", "bold": true, "fontSize": 24 } ] },
                        
                        { "paragraphFormat": { "textAlignment": "Center" },
                        "inlines": [ { "text": "No.123, Main Street, Business City" } ] },
                        
                        { "paragraphFormat": { "textAlignment": "Center" },
                        "inlines": [ { "text": "Phone: +1 234 567 8900\n" } ] },
                        
                        { "inlines": [ { "text": "INVOICE", "bold": true, "fontSize": 22 } ] },
                        { "inlines": [ { "text": "Invoice No: INV-{{o.OrderID}}" } ] },
                        { "inlines": [ { "text": "Customer ID: {{o.CustomerID}}" } ] },
                        { "inlines": [ { "text": "City: {{o.ShipCity}}" } ] },
                        { "inlines": [ { "text": "Date: {{DateTime.Now:dd-MMM-yyyy}}" } ] },
                        { "inlines": [ { "text": "Amount: ${{o.Freight:F2}}" } ] },
                        { "inlines": [ { "text": "Notes: Thank you for your business." } ] },
                        
                        { "inlines": [ { "text": "\n" } ] },
                        
                        { "inlines": [ { "text": "Authorized Signature", "bold": true } ] },
                        { "inlines": [ { "text": "______________________________" } ] }
                    ]
                }
            ]
        }
        """;
    }
}

{% endraw %}
{% endhighlight %}
{% endtabs %}

> By default, the `SfDocumentEditorContainer` component initializes an `SfDocumentEditor` instance internally. If you like to use the events of `SfDocumentEditor` component, then you can set `UseDefaultEditor` property as **false** and define your own `SfDocumentEditor` instance with event hooks in the application (Razor file).

## Run the application

Use the following command to run the application in the browser.

{% tabs %}
{% highlight bash tabtitle="Terminal" %}

dotnet run

{% endhighlight %}
{% endtabs %}

The app launches and renders the **[Syncfusion® Blazor DocumentEditor](https://www.syncfusion.com/docx-editor-sdk/blazor-docx-editor)** and **[Syncfusion® Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid)** in your default browser.

![Blazor DataGrid with DocumentEditor](images/documenteditor-with-datagrid.webp)

## Use cases

Integrating the Syncfusion® Blazor **DataGrid** with the **DocumentEditor** enables users to transform structured data into fully editable Word style documents within a single workflow. Users can browse, filter, and select records in the DataGrid and instantly generate or update documents without switching applications.

### Invoice and quotation generation

Display order or billing records in the DataGrid with details such as order ID, customer name, items, quantity, and pricing. When a user selects a record, the DocumentEditor loads a formatted invoice or quotation template populated with the selected data. Users can then edit text, adjust formatting, add terms, and finalize the document for export or sharing.

### HR record management

Create an HR management system where the DataGrid lists employee records such as employee ID, name, department, role, and status. Selecting an employee record opens an editable document in the DocumentEditor for offer letters, appraisal reports, employment contracts, or disciplinary notices. HR teams can quickly personalize documents while ensuring consistency and accuracy.

### Customer support

Build a customer support application where the DataGrid displays support tickets with fields like ticket ID, customer name, issue type, status, and priority. Selecting a ticket opens a case summary document in the DocumentEditor, allowing agents to write incident reports, resolution summaries, or customer communication letters directly from the case data.

### Legal agreement and contract drafting

Use the DataGrid to manage legal records such as contracts, agreements, or compliance documents. Each row can represent a contract with details like contract number, parties involved, effective date, and status. Selecting a record loads a contract template in the DocumentEditor where legal teams can review, edit clauses, add signatures, and prepare the document for approval.

### Business reports

Present business data such as project details, financial summaries, or operational metrics in the DataGrid. Users can select one or more records to generate structured reports, summaries, or approval documents in the DocumentEditor. This enables teams to convert raw data into polished, professional documents without manual copying or formatting errors.

## See also

- [Getting started with Syncfusion® Blazor DocumentEditor in Web App](https://help.syncfusion.com/document-processing/word/word-processor/blazor/getting-started/web-app)

- [Getting started with Syncfusion® Blazor DataGrid in Web App](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app)