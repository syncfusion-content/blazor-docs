---
layout: post
title: Getting Stared with Blazor Accumulation Chart in Server | Syncfusion
description: Checkout and learn about getting started with Blazor Accumulation Chart component in Blazor WebAssembly App.
platform: Blazor
control: Accumulation Chart
documentation: ug
---

<!-- markdownlint-disable MD040 -->

# Getting Started with Blazor Accumulation Chart Component

This section briefly explains about how to include [Blazor Accumulation Chart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfAccumulationChart.html) component in your Blazor WebAssembly App using Visual Studio and Visual Studio Code.

To get started quickly with Blazor Accumulation Chart component, check on the following video:

{% youtube
"youtube:https://www.youtube.com/watch?v=ol8c_iH7ebk" %}

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio

You can create a **Blazor WebAssembly App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Charts and Themes NuGet in the App

To add **Blazor Accumulation Chart** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.Charts](https://www.nuget.org/packages/Syncfusion.Blazor.Charts/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/). Alternatively, you can utilize the following package manager command to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Charts -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio Code

You can create a **Blazor WebAssembly App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project).

Alternatively, you can create a WebAssembly application using the following command in the terminal(<kbd>Ctrl</kbd>+<kbd>`</kbd>).

{% tabs %}

{% highlight c# tabtitle="Blazor WASM App" %}

dotnet new blazorwasm -o BlazorApp
cd BlazorApp

{% endhighlight %}

{% endtabs %}

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Charts and Themes NuGet in the App

* Press <kbd>Ctrl</kbd>+<kbd>`</kbd> to open the integrated terminal in Visual Studio Code.
* Ensure you’re in the project root directory where your `.csproj` file is located.
* Run the following command to install a [Syncfusion.Blazor.Charts](https://www.nuget.org/packages/Syncfusion.Blazor.Charts/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet package and ensure all dependencies are installed.

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.Charts -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

{% endtabcontent %}

{% endtabcontents %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

Open **~/_Imports.razor** file and import the Syncfusion.Blazor namespace.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Charts

{% endhighlight %}
{% endtabs %}

Now, register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service in the **~/Program.cs** file of your Blazor WebAssembly App.

{% tabs %}
{% highlight C# tabtitle="~/Program.cs" hl_lines="3 11" %}

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(serviceProvider => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSyncfusionBlazor();
await builder.Build().RunAsync();
....

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet and script reference within the `<head>` section of the **~/index.html** file.

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>
```
N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in your Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

## Add Blazor Accumulation Chart component

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Accumulation Chart component in the **~/Pages/Index.razor** file.

{% tabs %}
{% highlight razor %}

<SfAccumulationChart>
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@MedalDetails" XName="Country" YName="Medals">
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
</SfAccumulationChart>

@code{
    public class ChartData
    {
        public string Country { get; set;}
        public double Medals { get; set;}
    }

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData { Country= "United States of America", Medals= 46 },
        new ChartData { Country= "Great Britain", Medals= 27 },
        new ChartData { Country= "China", Medals= 26 },
        new ChartData { Country= "United Kingdom", Medals= 23 },
        new ChartData { Country= "Australia", Medals= 16 },
        new ChartData { Country= "India", Medals= 36 },
        new ChartData { Country= "Nigeria", Medals= 12 },
        new ChartData { Country= "Brazil", Medals= 20 },
     };
}

{% endhighlight %}
{% endtabs %}

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Accumulation Chart component in your default web browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjhzDWVeVKeUbWGh?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Pie Chart](images/getting-started/blazor-pie-chart.png)" %}

## Add title

Using the [Title](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfAccumulationChart.html#Syncfusion_Blazor_Charts_SfAccumulationChart_Title) property, a title to the accumulation chart is added to provide the user with quick information about the data plotted in the chart.

{% tabs %}
{% highlight razor %}

<SfAccumulationChart Title="Olympic Medal Details">
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@MedalDetails" XName="Country" YName="Medals">
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
</SfAccumulationChart>
@code{
    public class ChartData
    {
        public string Country { get; set; }
        public double Medals { get; set; }
    }

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData { Country= "United States of America", Medals= 46 },
        new ChartData { Country= "Great Britain", Medals= 27 },
        new ChartData { Country= "China", Medals= 26 },
        new ChartData { Country= "United Kingdom", Medals= 23 },
        new ChartData { Country= "Australia", Medals= 16 },
        new ChartData { Country= "India", Medals= 36 },
        new ChartData { Country= "Nigeria", Medals= 12 },
        new ChartData { Country= "Brazil", Medals= 20 },
     };
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjhpjMhShUPfYVwX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Adding Title in Blazor Accumulation Chart](images/getting-started/blazor-accumulation-chart-with-title.png)" %}

## Add data label

The data labels are added to improve the readability of the accumulation chart. This can be achieved by setting the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationDataLabelSettings.html#Syncfusion_Blazor_Charts_AccumulationDataLabelSettings_Visible) property to `true` in the [AccumulationDataLabelSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationDataLabelSettings.html).

{% tabs %}
{% highlight razor %}

<SfAccumulationChart Title="Olympic Medal Details">
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@MedalDetails" XName="Country" YName="Medals">
            <AccumulationDataLabelSettings Visible="true"/>
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
</SfAccumulationChart>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDrJXWLorfzIwbIh?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Adding Data Label in Blazor Accumulation Chart](images/getting-started/blazor-accumulation-chart-data-label.png)" %}

## Enable Tooltip

When space constraints prevent from displaying the information using data labels, the tooltip comes in handy. The tooltip can be enabled by setting the [Enable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartTooltipSettings.html#Syncfusion_Blazor_Charts_AccumulationChartTooltipSettings_Enable) property in [AccumulationChartTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartTooltipSettings.html) to `true`.

{% tabs %}
{% highlight razor %}

<SfAccumulationChart Title="Olympic Medal Details">
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@MedalDetails" XName="Country" YName="Medals">
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
    <AccumulationChartTooltipSettings Enable="true"></AccumulationChartTooltipSettings>
</SfAccumulationChart>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXrJZMhyLfknWQpM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Accumulation Chart displays Tooltip](images/getting-started/blazor-accumulation-chart-tooltip.png)" %}

## Enable Legend

Legend is used for the accumulation chart by setting the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartLegendSettings.html#Syncfusion_Blazor_Charts_AccumulationChartLegendSettings_Visible) property to `true` in the [AccumulationChartLegendSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartLegendSettings.html).

{% tabs %}
{% highlight razor %}

<SfAccumulationChart Title="Olympic Medal Details">
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@MedalDetails" XName="Country" YName="Medals">
            <AccumulationDataLabelSettings Visible="true"></AccumulationDataLabelSettings>
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
    <AccumulationChartTooltipSettings Enable="true"></AccumulationChartTooltipSettings>
    <AccumulationChartLegendSettings Visible="true"></AccumulationChartLegendSettings>
</SfAccumulationChart>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjVzjCVSVyMUwbGm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Accumulation Chart with Legend](images/getting-started/blazor-accumulation-chart-legend.png)" %}

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/AccumulationChart).

## See also

* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Web Assembly App in Visual Studio or .NET CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)
* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Web App in Visual Studio or .NET CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)
