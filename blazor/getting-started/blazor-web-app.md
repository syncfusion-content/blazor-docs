---
layout: post
title: Getting started with Syncfusion Blazor Web App in Visual Studio
description: Check out the documentation for getting started with Syncfusion Blazor Components in Blazor Web App.
platform: Blazor
component: Common
documentation: ug
---

# Getting Started with Blazor Web App

This article provides step-by-step instructions for building a Blazor Web App in Visual Studio and integrating the `Syncfusion® Blazor DataGrid`. Follow the steps in order.

To get started quickly with a Blazor Web App, watch the following video.

{% youtube
"youtube:https://www.youtube.com/watch?v=hjPGxApA5W8" %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## 1. Manually Creating a Project

1) Open Visual Studio → Create a new project → select Blazor Web App → Next.
2) Configure your project name and location → Next.
3) Select the framework: .NET 8/9/10.
4) Set the interactive render mode as **Server**.

Configure the appropriate [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vs) while creating a Blazor Web App.

## 2. Install Syncfusion packages

Install the following packages into your project:

* [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid/)
* [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

N> All Syncfusion Blazor packages are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for details.

## 3. Import namespaces

Open **~/_Imports.razor** and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Grids` namespaces.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
{% endhighlight %}
{% endtabs %}

## 4. Register Syncfusion services

Add the Syncfusion Blazor service registration in **~/Program.cs** file.

{% tabs %}
{% highlight c# tabtitle="Server (~/Program.cs)" hl_lines="3 11" %}
...
...
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
...
{% endhighlight %}
{% endtabs %}

## 5. Add theme stylesheet and script

Add the theme CSS and Syncfusion script to **~/Components/App.razor** using Static Web Assets. Place the CSS in the <head> and the script before </body>,

```html
<head>
    ...
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <!-- You can switch to any supported theme, e.g., material3, fluent2 -->
</head>

<body>
    ...
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

N> Learn more about [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) (Static Web Assets, CDN, CRG) and [Adding Script References](https://blazor.syncfusion.com/documentation/common/adding-script-references).

## 6. Add the DataGrid to a page

Add the DataGrid to a page in **~/Components/Pages/*.razor** file.

{% tabs %}
{% highlight razor tabtitle="Example page" %}
@rendermode InteractiveServer
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" AllowSorting="true">
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" IsPrimaryKey="true" Width="120" />
        <GridColumn Field="CustomerID" HeaderText="Customer" Width="150" />
        <GridColumn Field="OrderDate" HeaderText="Order Date" Type="ColumnType.Date" Format="d" Width="130" />
        <GridColumn Field="Freight" HeaderText="Freight" Format="C2" Width="120" />
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; } = new();

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 25).Select(x => new Order
        {
            OrderID = 1000 + x,
            CustomerID = new[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" }[Random.Shared.Next(5)],
            Freight = 2 * x,
            OrderDate = DateTime.Today.AddDays(-x)
        }).ToList();
    }

    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public double Freight { get; set; }
    }
}
{% endhighlight %}
{% endtabs %}

## 7. Run the app

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid component in the default web browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXVesWjwqtDJZluz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor DataGrid Component](images/blazor-datagrid-component.png)" %}