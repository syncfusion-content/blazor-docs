---
layout: post
title: Getting Started with Syncfusion® Blazor Components in JetBrains Rider
description: Step-by-step guide to integrate Syncfusion® Blazor DataGrid in Blazor applications using JetBrains Rider.
platform: Blazor
control: common
documentation: ug
---

# Getting Started with JetBrains Rider and Syncfusion® Blazor Components

This section explains how to use [JetBrains Rider](https://www.jetbrains.com/rider/) which is a cross-platform IDE to develop Blazor applications with [Syncfusion® Blazor components](https://www.syncfusion.com/blazor-components).

To quickly get started with Blazor WebAssembly application using JetBrains Rider and Syncfusion® Blazor components, watch the following video:

{% youtube
"youtube:https://www.youtube.com/watch?v=hLBBg-mkC2Y" %}

## Setting up JetBrains Rider for Blazor

Before you start developing a Blazor application, you need to install **JetBrains Rider** on your system.

**Step to install JetBrains Rider**

- Go to the official [JetBrains Rider](https://www.jetbrains.com/rider/) website.
- Download the installer suitable for your operating system.
- Run the installer and follow the on‑screen instructions to complete the installation.
- Once the installation is complete, launch JetBrains Rider to begin your Blazor development.

After launching Rider, you can create or open a Blazor project and start integrating Syncfusion® Blazor components.

## Creating a Blazor application

This section explains how to create a new **Blazor WebAssembly Standalone App** using **JetBrains Rider**.

Follow these steps to create a Blazor application in Rider:

- Open **JetBrains Rider**.
- On the welcome screen, click **New Solution**.
- Select the **.NET SDK version** that you want to use.
- From the available project templates, choose **Blazor WebAssembly Standalone App**.
- Enter your project name.
- Click **Create** to generate the project.

Once the project is created, Rider opens the solution and restores the required dependencies automatically.

## Adding Syncfusion® Blazor NuGet packages

After creating the Blazor project, you must install the required Syncfusion® Blazor NuGet packages to use Syncfusion® UI components.

**Install required Syncfusion® NuGet packages**

- In the **Solution Explorer**, right‑click the project name.
- Select **Manage NuGet Packages** from the context menu.
- In the Browse tab, search for and install the following packages:

    - [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid)
    - [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

Once the installation is complete, the Syncfusion® Blazor components are ready to be used in your application.

## Register the Syncfusion® services

Add the Syncfusion® Blazor service to the `Program.cs` file to enable Syncfusion® components in the application.

{% tabs %}
{% highlight c# tabtitle="Program.cs" hl_lines="3 9" %}

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder =  WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddSyncfusionBlazor();
....

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

To apply styles and enable Syncfusion® features, reference the theme CSS and scripts within the `wwwroot/index.html` file.

{% tabs %}
{% highlight html  %}

<head>
    ....
    <!-- Syncfusion® theme stylesheet -->
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
    ....
</head>

<body>
    ....
    <!-- Syncfusion® Blazor core script (required for UI components, including DataGrid) -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
    ....
</body>

{% endhighlight %}
{% endtabs %}

## Connect the Syncfusion® Blazor DataGrid

Add the **[Syncfusion® Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid)** components to a `.razor` file within your app. 

{% tabs %}
{% highlight razor tabtitle="Pages/Home.razor"  %}

@page "/"

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" />
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="100" />
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" Width="100" />
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120" />
    </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 12).Select(i => new Order {
            OrderID = 1000 + i,
            CustomerID = new[] { "ALFKI","ANATR","ANTON","BLONP","BOLID" }[Random.Shared.Next(5)],
            OrderDate = DateTime.Today.AddDays(-i),
            Freight = Math.Round(25 + 15 * Random.Shared.NextDouble(), 2)
        }).ToList();
    }

    public class Order
    {
        public int OrderID { get; set; }
        public string? CustomerID { get; set; }
        public DateTime OrderDate { get; set; }
        public double Freight { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

## Run the application

- In JetBrains Rider, click the **Run** button on the toolbar.
- Rider builds the project and starts the built‑in development server automatically.
- Once the application starts, a local URL is displayed in the Run window.
- The default browser opens the application using this URL. If it does not open automatically, copy the URL and open it manually in a browser.

The app launches and renders the **[Syncfusion® Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid)** in your default browser.

![Blazor DataGrid in JetBrains Rider](images/jetbrains-datagrid.webp)

## See also

- [Getting started with Syncfusion® Blazor DataGrid in WASM App](https://blazor.syncfusion.com/documentation/datagrid/getting-started)
- [Integrating Syncfusion® Blazor Components with Azure Functions](https://blazor.syncfusion.com/documentation/common/integration/blazor-azure-functions)
- [Blazor WebAssembly with JetBrains Rider and Syncfusion®](https://www.syncfusion.com/webinars/blazor-webassembly-with-jetbrains-rider-and-syncfusion)

