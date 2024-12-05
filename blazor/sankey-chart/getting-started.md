---
layout: post
title: Getting Stared with Blazor Sankey Chart Component | Syncfusion
description: Checkout and learn about getting started with Blazor Sankey Chart component in Blazor Server App using Visual Studio and more.
platform: Blazor
control: Sankey Chart
documentation: ug
---

<!-- markdownlint-disable MD040 -->

# Getting Started with Blazor Sankey Chart Component in Blazor Server App

This section briefly explains about how to include [Blazor Sankey Charts](https://www.syncfusion.com/blazor-components/blazor-charts) component in your Blazor Server App using Visual Studio.

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio

You can create a **Blazor Server App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0) or the [Syncfusion Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

## Install Syncfusion Blazor SankeyChart NuGet in the App

To add **Blazor Sankey Chart** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.SankeyChart](https://www.nuget.org/packages/Syncfusion.Blazor.SankeyChart). Alternatively, you can utilize the following package manager command to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.SankeyChart -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

## Register Syncfusion Blazor Service

Open **~/_Imports.razor** file and import the Syncfusion.Blazor namespace.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.SankeyChart

{% endhighlight %}
{% endtabs %}

Now, register the Syncfusion Blazor Service in the **~/Program.cs** file of your Blazor Server App.

{% tabs %}
{% highlight C# tabtitle="Blazor Server App" hl_lines="3 10" %}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
....

{% endhighlight %}
{% endtabs %}

## Add script resources

The script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Reference the script in the `<head>` of the main page as follows:

* For **.NET 6** Blazor Server app, include it in **~/Pages/_Layout.cshtml** file.

* For **.NET 7** Blazor Server app, include it in the **~/Pages/_Host.cshtml** file.

```html
<head>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>
```
N> Check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

## Add Blazor Chart Component

Add the Syncfusion Blazor Chart component in the **~/Pages/Index.razor** file.

{% tabs %}
{% highlight razor %}

<SfSankeyChart DataSource="@SankeyData">
</SfSankeyChart>
@code {
    public SankeyChartData SankeyData { get; set; }

    protected override void OnInitialized()
    {
        SankeyData = new SankeyChartData
        {
                Nodes = new List<SankeyChartDataNode>
            {
                new SankeyChartDataNode { Id = "Solar", Label = new SankeyChartDataLabel { Text = "Solar" } },
                new SankeyChartDataNode { Id = "Coal", Label = new SankeyChartDataLabel { Text = "Coal" } },
                new SankeyChartDataNode { Id = "Electricity", Label = new SankeyChartDataLabel { Text = "Electricity" } },
                new SankeyChartDataNode { Id = "Residential", Label = new SankeyChartDataLabel { Text = "Residential" } }
            },
                Links = new List<SankeyChartDataLink>
            {
                new SankeyChartDataLink { SourceId = "Solar", TargetId = "Electricity", Value = 100 },
                new SankeyChartDataLink { SourceId = "Coal", TargetId = "Electricity", Value = 200 },
                new SankeyChartDataLink { SourceId = "Electricity", TargetId = "Residential", Value = 150 }
            }
        };
    }
}

{% endhighlight %}
{% endtabs %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the Syncfusion Blazor Sankey Chart component in your default web browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZLzNsLepwXKBvNw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Sankey Chart Component](images/getting-started/blazor-sankey-chart.png)" %}

## Populate Blazor SankeyChart with data

To bind data for the sankey chart component, you can assign a List to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) property. It can also be provided as an instance of the [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html).

{% tabs %}
{% highlight razor %}

public SankeyChartData SankeyData { get; set; } = new SankeyChartData
    {
        Nodes = new List<SankeyChartDataNode>
        {
            new SankeyChartDataNode { Id = "Solar", Label = new SankeyChartDataLabel { Text = "Solar" } },
            new SankeyChartDataNode { Id = "Coal", Label = new SankeyChartDataLabel { Text = "Coal" } },
            new SankeyChartDataNode { Id = "Electricity", Label = new SankeyChartDataLabel { Text = "Electricity" } },
            new SankeyChartDataNode { Id = "Residential", Label = new SankeyChartDataLabel { Text = "Residential" } }
        },
        Links = new List<SankeyChartDataLink>
        {
            new SankeyChartDataLink { SourceId = "Solar", TargetId = "Electricity", Value = 100 },
            new SankeyChartDataLink { SourceId = "Coal", TargetId = "Electricity", Value = 200 },
            new SankeyChartDataLink { SourceId = "Electricity", TargetId = "Residential", Value = 150 }
        }
    };

{% endhighlight %}
{% endtabs %}

## Add titles

Using the [Title](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_Title) property, you can add a title to the sankey chart to provide the user with quick information about the data plotted in the chart.

{% tabs %}
{% highlight razor %}

<SfSankeyChart Title="Energy Flow Diagram" DataSource="@SankeyData">
</SfSankeyChart>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNBJjihozcpDsXHf?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Sankey Chart with Title](images/getting-started/blazor-sankey-chart-title.png)" %}

## Enable tooltip

The tooltip can be enabled by setting the [Enable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html#Syncfusion_Blazor_Charts_ChartTooltipSettings_Enable) property in [SankeyChartTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html) to **true**.

{% tabs %}
{% highlight razor %}

<SfSankeyChart DataSource="@SankeyData">
    <SankeyChartTooltipSettings Enable="true"></SankeyChartTooltipSettings>
</SfSankeyChart>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjVTNChepGIwhetf?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Sankey Chart with Tooltip](images/getting-started/blazor-sankey-chart-tooltip.png)" %}

## Enable legend

You can use legend for the sankey chart by setting the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartLegendSettings.html#Syncfusion_Blazor_Charts_ChartLegendSettings_Visible) property to **true** in [SankeyChartLegendSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartLegendSettings.html). 

{% tabs %}
{% highlight razor %}

<SfSankeyChart DataSource="@SankeyData">
    <SankeyChartLegendSettings Visible="true"></SankeyChartLegendSettings>
</SfSankeyChart>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZrTDCLIpQHyGNEq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Sankey Chart with Legend](images/getting-started/blazor-sankey-chart-legend.png)" %}

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/Chart).

## See also

* [Getting Started with Syncfusion Blazor for Client-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-dotnet-cli)
* [Getting Started with Syncfusion Blazor for Server-Side in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)
* [Getting Started with Syncfusion Blazor for Server-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-dotnet-cli)
