---
layout: post
title: Getting Started with WPF Blazor App in Visual Studio | Syncfusion
description: Check out the documentation for getting started with WPF Blazor App and Syncfusion Blazor Components in Visual Studio and much more.
platform: Blazor
component: Common
documentation: ug
---

# Getting Started with WPF Blazor Application

This section describes how to create and run a WPF Blazor application (.NET WPF Blazor) that integrates Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components.

To get started quickly with a WPF Blazor app, watch the following video.

{% youtube
"youtube:https://www.youtube.com/watch?v=MxSGEbPUbMg" %}

## What is WPF Blazor App?

A WPF Blazor App hosts a `Blazor Web App` inside a WPF Application using the `BlazorWebView` control. This enables the Blazor Web App to integrate with desktop platform features and WPF UI. The `BlazorWebView` can be added on any WPF page and pointed to the Blazor app's root component. Blazor components executes in the .NET process and render their web UI into the embedded web-view control. WPF Blazor Apps run on platforms supported by WPF.

Visual Studio provides the **WPF Application** template to create WPF Blazor Apps.

## Prerequisites

* [Supported platforms (WPF documentation)](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/overview/?view=netdesktop-8.0)
* [Visual Studio 2022](https://visualstudio.microsoft.com/vs/) or [Visual Studio 2026](https://visualstudio.microsoft.com/downloads/)

## Create a new WPF Blazor App in Visual Studio

To create a **WPF Blazor App** using Visual Studio, follow the comprehensive steps in the [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/hybrid/tutorials/wpf?view=aspnetcore-8.0) documentation. Ensuring and understanding each step in the official guide establishes the foundation required to continue with this documentation.

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Grid and Themes NuGet in the App

To add the **Blazor DataGrid** component in the app, open the NuGet Package Manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), then search and install [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes). Alternatively, run the following commands in the Package Manager Console to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Grid -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Ensure the package [Microsoft.AspNetCore.Components.WebView.Wpf](https://www.nuget.org/packages/Microsoft.AspNetCore.Components.WebView.Wpf) is installed at version `8.0.16` or later. For details, see the package page in NuGet.

![WPF Blazor App NuGet package reference](images/wpf/wpf-blazor-package-reference.png)

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the available NuGet package list with component details.

## Add Import Namespaces

Open the `~/_Imports.razor` file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Grids` namespaces.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

{% endhighlight %}
{% endtabs %}

## Register Syncfusion Blazor Service

Register the Syncfusion Blazor service in the `MainWindow.xaml.cs` file of the WPF Blazor App.

{% tabs %}
{% highlight C# tabtitle="~/MainWindow.xaml.cs" hl_lines="1 3" %}

using Syncfusion.Blazor;
....
serviceCollection.AddSyncfusionBlazor();
....

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet in the <head> and the script at the end of the <body> in the **~wwwroot/index.html** file as shown below:

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

<body>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in the Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

## Add Syncfusion Blazor component

Add a Syncfusion Blazor component to any Razor file in the Blazor project. The example below adds the Blazor Grid component into `~/Counter.razor` file.

{% tabs %}
{% highlight razor %}

<SfGrid DataSource="@Orders" />

@code {
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 5).Select(x => new Order()
        {
            OrderID = 0 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }

    }
}

{% endhighlight %}
{% endtabs %}

In the Visual Studio toolbar, click the Start button (or press <kbd>F5</kbd>) to build and run the application.

![Build and run WPF Blazor App](images/wpf/start-button.png)

![WPF Blazor App with Syncfusion Blazor Components](images/wpf/wpf-blazor-datagrid.png)

N> View Sample in [GitHub](https://github.com/SyncfusionExamples/blazor-general-cross-platform-wpf)
