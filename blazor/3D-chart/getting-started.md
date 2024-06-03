---
layout: post
title: Getting Stared with Blazor 3D Chart Component | Syncfusion
description: Checkout and learn about getting started with Blazor 3D Chart component in Blazor Server App using Visual Studio and more.
platform: Blazor
control: 3D Chart
documentation: ug
---

<!-- markdownlint-disable MD040 -->

# Getting Started with Blazor 3D Chart Component in Blazor Server App

This section briefly explains about how to include `Blazor 3D Chart` component in your Blazor Server App using Visual Studio.

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio

You can create a **Blazor Server App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0) or the [Syncfusion Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

## Install Syncfusion Blazor 3D Chart NuGet in the App

To add **Blazor 3D Chart** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install `Syncfusion.Blazor.Chart3D`. Alternatively, you can utilize the following package manager command to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Chart3D -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

## Register Syncfusion Blazor Service

Open **~/_Imports.razor** file and import the Syncfusion.Blazor namespace.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Chart3D

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

## Add Blazor 3D Chart Component

Add the Syncfusion Blazor 3D Chart component in the **~/Pages/Index.razor** file.

{% tabs %}
{% highlight razor %}

<SfChart3D>

</SfChart3D>

{% endhighlight %}
{% endtabs %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the Syncfusion Blazor 3D Chart component in your default web browser.

## Populate Blazor 3D Chart with data

To bind data for the 3D chart component, you can assign a IEnumerable object to the `DataSource` property. It can also be provided as an instance of the `DataManager`.

{% tabs %}
{% highlight razor %}

public class SalesInfo
{
    public string Month { get; set; }
    public double SalesValue { get; set; }
}

public List<SalesInfo> Sales = new List<SalesInfo>
{
    new SalesInfo { Month = "Jan", SalesValue = 35 },
    new SalesInfo { Month = "Feb", SalesValue = 28 },
    new SalesInfo { Month = "Mar", SalesValue = 34 },
    new SalesInfo { Month = "Apr", SalesValue = 32 },
    new SalesInfo { Month = "May", SalesValue = 40 },
    new SalesInfo { Month = "Jun", SalesValue = 32 },
    new SalesInfo { Month = "Jul", SalesValue = 35 }
};

{% endhighlight %}
{% endtabs %}

Now, map the data fields  `Month` and `Sales` to the series `XName` and `YName` properties, then set the data to the `DataSource` property, and the `chart type` to **Column** because we will be viewing the data in a column chart.

{% tabs %}
{% highlight razor %}

<SfChart3D>
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category"></Chart3DPrimaryXAxis>
    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="Chart3DSeriesType.Column">
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code {
    public class SalesInfo
    {
        public string Month { get; set;}
        public double SalesValue { get; set;}
    }

    public List<SalesInfo> Sales = new List<SalesInfo>
    {
        new SalesInfo { Month = "Jan", SalesValue = 35 },
        new SalesInfo { Month = "Feb", SalesValue = 28 },
        new SalesInfo { Month = "Mar", SalesValue = 34 },
        new SalesInfo { Month = "Apr", SalesValue = 32 },
        new SalesInfo { Month = "May", SalesValue = 40 },
        new SalesInfo { Month = "Jun", SalesValue = 32 },
        new SalesInfo { Month = "Jul", SalesValue = 35 }
    };
}

{% endhighlight %}
{% endtabs %}

## Add 3D Chart title

You can add a title using `Title` property, you can add a title to the chart and the axes to provide the user with quick information about the data plotted in the chart.

{% tabs %}
{% highlight razor %}

<SfChart3D Title="Sales Analysis">
    <Chart3DPrimaryXAxis Title="Month" ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category"></Chart3DPrimaryXAxis>
    
     <Chart3DPrimaryYAxis Title="Sales in Dollar"><Chart3DPrimaryYAxis>
    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="Chart3DSeriesType.Column">
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

{% endhighlight %}
{% endtabs %}

## Enable legend

You can use legend for the 3D Chart by setting the `Visible` property to **true** in `Chart3DLegendSettings`. The legend name can be changed by using the `Name` property in the series.

{% tabs %}
{% highlight razor %}

<SfChart3D Title="Sales Analysis">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category"></Chart3DPrimaryXAxis>
    <Chart3DLegendSettings Visible="true"></Chart3DLegendSettings>
    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@Sales" Name="Sales" XName="Month" YName="SalesValue" Type="Chart3DSeriesType.Column">
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

{% endhighlight %}
{% endtabs %}

## Add data label

You can add data labels to improve the readability of the 3D Chart. This can be achieved by setting the `Visible` property to **true** in the `Chart3DDataLabel`. Now, the data labels are arranged smartly based on series.

{% tabs %}
{% highlight razor %}

<SfChart3D Title="Sales Analysis">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category"></Chart3DPrimaryXAxis>
    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="Chart3DSeriesType.Column">
            <Chart3DDataLabel Visible="true"></Chart3DDataLabel>
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

{% endhighlight %}
{% endtabs %}

## Enable tooltip

The tooltip is useful when you cannot display information by using the data labels due to space constraints. You can enable tooltip by setting the `Enable` property in `Chart3DTooltipSettings` to **true**.

{% tabs %}
{% highlight razor %}

<SfChart3D Title="Sales Analysis">
    <Chart3DPrimaryXAxis Title="Month" ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category"></Chart3DPrimaryXAxis>
    <Chart3DPrimaryYAxis Title="Sales in Dollar"></Chart3DPrimaryYAxis>
    <Chart3DTooltipSettings Enable="true"></Chart3DTooltipSettings>
    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="Chart3DSeriesType.Column">
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

{% endhighlight %}
{% endtabs %}

## See also

* [Getting Started with Syncfusion Blazor for Client-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-dotnet-cli)
* [Getting Started with Syncfusion Blazor for Server-Side in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)
* [Getting Started with Syncfusion Blazor for Server-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-dotnet-cli)
