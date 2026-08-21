---
layout: post
title: Add a Blazor DataGrid to an Existing ASP.NET Core MVC App | Syncfusion®
description: Learn how to add a Syncfusion Blazor DataGrid component to an existing ASP.NET Core MVC application using the built-in component tag helper in Visual Studio.
platform: Blazor
control: Common
documentation: ug
---

# Add a Blazor DataGrid to an Existing ASP.NET Core MVC Application

This guide explains how to add a [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) component to an existing ASP.NET Core MVC application.

## Prerequisites

* [.NET SDK](https://dotnet.microsoft.com/en-us/download/visual-studio-sdks) (version 8.0 or later).
* [Visual Studio](https://visualstudio.microsoft.com/downloads/) 2022 or later.

## Steps to integrate DataGrid component

Open the existing ASP.NET Core MVC application in Visual Studio, and follow this steps one by one.

### Install the Blazor NuGet packages

* Go to *Tools → NuGet Package Manager → Manage NuGet Packages for Solution*.
* Search the required NuGet packages ([Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) and install them.

Alternatively, you can install the same packages using the Package Manager Console with the following commands.

{% tabs %}
{% highlight razor tabtitle="Package Manager Console" %}

Install-Package Syncfusion.Blazor.Grid -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

### Add the Blazor namespaces to the project

Create a new file named **`_Imports.razor`** at the project root and include the following namespaces.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using System.Net.Http
@using Microsoft.AspNetCore.Authorization
@using Microsoft.AspNetCore.Components.Authorization
@using Microsoft.AspNetCore.Components.Forms
@using Microsoft.AspNetCore.Components.Routing
@using Microsoft.AspNetCore.Components.Web
@using Microsoft.AspNetCore.Components.Web.Virtualization
@using Microsoft.JSInterop
@using AspCoreMvcApp
@using AspCoreMvcApp.Components
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

{% endhighlight %}
{% endtabs %}

### Register the Blazor Server and Blazor services in `~/Program.cs`

Open the **Program.cs** file and include the required namespace reference `using Syncfusion.Blazor;` at the top then register the services on the `WebApplicationBuilder`.

{% tabs %}
{% highlight C# tabtitle="Program.cs" %}

builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();

{% endhighlight %}
{% endtabs %}

### Map the Blazor hubs and Razor Pages in `~/Program.cs`

{% tabs %}
{% highlight C# tabtitle="Program.cs" %}

app.MapRazorPages();
app.MapBlazorHub();

{% endhighlight %}
{% endtabs %}


### Add the theme stylesheet and script references in `~/Views/Shared/_Layout.cshtml`

{% tabs %}
{% highlight C# tabtitle="_Layout.cshtml" %}
    <head>
        ...
        <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
        <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"></script>
    </head>
    <body>
        ...
        <script src="_framework/blazor.server.js"></script>
        ...
    </body>
{% endhighlight %}
{% endtabs %}

### Create a Razor Component that hosts the Blazor DataGrid.

* Right-click the project root, choose **Add** → **New Folder**, and name it **Components**.
* Right-click the **Components** folder and choose **Add** → **Razor Component**.
* Name the file **`MyGrid.razor`**. The file name becomes the component class name (for example, `MyGrid`).
* Replace the contents of `MyGrid.razor` with:

{% tabs %}
{% highlight razor tabtitle="MyGrid.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true">
    <GridPageSettings PageSize="5"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" Width="120" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerName) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Width="130" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" Width="120" TextAlign="TextAlign.Right"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        var customers = new string[] { "James Hopper", "Michael Smith", "Sarah Johnson", "Robert Davis", "Emily Wilson" };
        var cities = new string[] { "New York", "Los Angeles", "Chicago", "Houston", "Phoenix" };
        var rng = new Random();
        Orders = Enumerable.Range(1, 50).Select(x => new Order
        {
            OrderID = 1000 + x,
            CustomerName = customers[rng.Next(customers.Length)],
            ShipCity = cities[rng.Next(cities.Length)],
            Freight = Math.Round(10.5 + (x * 7.3), 2),
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string? CustomerName { get; set; }
        public string? ShipCity { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
{% endhighlight %}
{% endtabs %}

### Insert the component into the MVC view using the component tag helper

Open **~/Views/Home/Index.cshtml** and add the following at the top, then place the `<component>` tag where the Blazor DataGrid should appear.

{% tabs %}
{% highlight razor tabtitle="Index.cshtml" %}

@using AspCoreMvcApp.Components

<component type="typeof(MyGrid)" render-mode="ServerPrerendered" />

{% endhighlight %}
{% endtabs %}

### Run the application

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> in Visual Studio to launch the MVC application. Navigate to the MVC page where you placed the `<component>` tag. The [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) renders inside the MVC view.

![Blazor DataGrid rendered on an ASP.NET Core MVC application](images/asp-mvc-grid.webp)

## See also

* [Component Tag Helper in ASP.NET Core](https://learn.microsoft.com/en-us/aspnet/core/mvc/views/tag-helpers/built-in/component-tag-helper)
* [Integrating Blazor components into existing ASP.NET Core MVC apps](https://devblogs.microsoft.com/premier-developer/integrating-blazor-components-into-existing-asp-net-core-mvc-apps/)
* [Getting started with the Blazor DataGrid in a Blazor Web App](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app)
