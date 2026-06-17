---
layout: post
title: Getting Started Blazor Smith Chart in Blazor WASM App | Syncfusion
description: Checkout and learn about getting started with Blazor Smith Chart component in Blazor WebAssembly Application.
platform: Blazor
control: Smith Chart
documentation: ug
---

# Getting Started with Blazor Smith Chart in Blazor WASM App

This section briefly explains about how to include [Blazor Smith Chart](https://www.syncfusion.com/blazor-components/blazor-smith-chart) component in a Blazor WebAssembly App using [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/), and the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

## Create a new Blazor WASM App

{% tabcontents %}

{% tabcontent Visual Studio %}

Create a **Blazor WebAssembly App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio). For detailed instructions, refer to the [Blazor WebAssembly App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app) documentation.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Run the following command to create a new Blazor WebAssembly App.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet new blazorwasm -o BlazorApp

{% endhighlight %}
{% endtabs %}

Alternatively, create a **Blazor WebAssembly App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc), the [Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project), or the [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension.

{% endtabcontent %}

{% tabcontent .NET CLI %}

Run the following command to create a new Blazor WebAssembly App.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet new blazorwasm -o BlazorApp

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

## Install the required Blazor packages

Install [Syncfusion.Blazor.SmithChart](https://www.nuget.org/packages/Syncfusion.Blazor.SmithChart/) NuGet package. All Syncfusion Blazor packages are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for details.

{% tabcontents %}

{% tabcontent Visual Studio %}

1. Go to *Tools → NuGet Package Manager → Manage NuGet Packages for Solution*.
2. Search the required NuGet package (`Syncfusion.Blazor.SmithChart`) and install it.

Alternatively, you can install the same package using the Package Manager Console with the following command.

{% tabs %}
{% highlight razor tabtitle="Package Manager Console" %}

Install-Package Syncfusion.Blazor.SmithChart -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Open the terminal and run the following command.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet add package Syncfusion.Blazor.SmithChart -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent .NET CLI %}

Open the command prompt and run the following command.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet add package Syncfusion.Blazor.SmithChart -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

## Add import namespaces

After the package is installed, open the **~/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Charts` namespaces.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Charts

{% endhighlight %}
{% endtabs %}

## Register the Blazor service

Open the **Program.cs** file in Blazor WebAssembly App and register the Blazor service.

{% tabs %}
{% highlight C# tabtitle="Program.cs" %}

....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....

{% endhighlight %}
{% endtabs %}

## Add script resources

The script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the [script references](https://blazor.syncfusion.com/documentation/common/adding-script-references) in the **~wwwroot/index.html** file.

{% tabs %}
{% highlight html tabtitle="index.html" %}

<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

N> Check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in the Blazor application.

## Add Blazor Smith Chart component

Open a Razor file located in the **~/Pages/*Index.razor** and add the [Blazor Smith Chart](https://www.syncfusion.com/blazor-components/blazor-smith-chart) component inside the razor file.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Charts

<SfSmithchart>

</SfSmithchart>

{% endhighlight %}
{% endtabs %}

## Adding series to Blazor Smith Chart

`Smith Chart` series can be added in two ways. Use either [Points](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeries.html#Syncfusion_Blazor_Charts_SmithChartSeries_Points) or [Datasource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeries.html#Syncfusion_Blazor_Charts_SmithChartSeries_DataSource) in the [SmithChartSeries](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeries.html).

If you add using [Datasource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeries.html#Syncfusion_Blazor_Charts_SmithChartSeries_DataSource) property, additionally you need to specify data source mapping fields using [Reactance](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeries.html#Syncfusion_Blazor_Charts_SmithChartSeries_Reactance) and [Resistance](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeries.html#Syncfusion_Blazor_Charts_SmithChartSeries_Resistance) properties.

If you are using [Points](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeries.html#Syncfusion_Blazor_Charts_SmithChartSeries_Points), you don't need to specify mapping fields as like in [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeries.html#Syncfusion_Blazor_Charts_SmithChartSeries_DataSource). But the [Points](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeries.html#Syncfusion_Blazor_Charts_SmithChartSeries_Points) collection should be `SmithChartPoint` type and define `Resistance` and `Reactance` properties mandatorily.

The following sample demonstrates adding two series to Smith Chart in both ways.

* First series `Transmission1` shows `DataSource` bound series.
* Second series `Transmission2` shows `Points` bound series.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Charts

<SfSmithChart>
    <SmithChartSeriesCollection>
        <SmithChartSeries Name="Transmission1"
                          Reactance="Reactance"
                          Resistance="Resistance"
                          DataSource="@FirstTransmissionSeries">
        </SmithChartSeries>
        <SmithChartSeries Name="Transmission2"
                          Points="@SecondTransmissionSeries">
        </SmithChartSeries>
    </SmithChartSeriesCollection>
</SfSmithChart>

@code {
    public class SmithDataSource
    {
        public double Resistance { get; set; }
        public double Reactance { get; set; }
    };
    public List<SmithDataSource> FirstTransmissionSeries = new List<SmithDataSource> {
        new SmithDataSource { Resistance= 10, Reactance= 25 },
        new SmithDataSource { Resistance= 8, Reactance= 6 },
        new SmithDataSource { Resistance= 6, Reactance= 4.5 },
        new SmithDataSource { Resistance= 4.5, Reactance= 2 },
        new SmithDataSource { Resistance= 3.5, Reactance= 1.6 },
        new SmithDataSource { Resistance= 2.5, Reactance= 1.3 },
        new SmithDataSource { Resistance= 2, Reactance= 1.2 },
        new SmithDataSource { Resistance= 1.5, Reactance= 1 },
        new SmithDataSource { Resistance= 1, Reactance= 0.8 },
        new SmithDataSource { Resistance= 0.5, Reactance= 0.4 },
        new SmithDataSource { Resistance= 0.3, Reactance= 0.2 },
        new SmithDataSource { Resistance= 0.001, Reactance= 0.15 }
    };
    public List<SmithChartPoint> SecondTransmissionSeries = new List<SmithChartPoint> {
        new SmithChartPoint { Resistance= 20, Reactance= -50 },
        new SmithChartPoint { Resistance= 10, Reactance= -10 },
        new SmithChartPoint { Resistance= 9, Reactance= -4.5 },
        new SmithChartPoint { Resistance= 8, Reactance= -3.5 },
        new SmithChartPoint { Resistance= 7, Reactance= -2.5 },
        new SmithChartPoint { Resistance= 6, Reactance= -1.5 },
        new SmithChartPoint { Resistance= 5, Reactance= -1 },
        new SmithChartPoint { Resistance= 4.5, Reactance= -0.5 },
        new SmithChartPoint { Resistance= 2, Reactance= 0.5 },
        new SmithChartPoint { Resistance= 1.5, Reactance= 0.4 },
        new SmithChartPoint { Resistance= 1, Reactance= 0.4 },
        new SmithChartPoint { Resistance= 0.5, Reactance= 0.2 },
        new SmithChartPoint { Resistance= 0.3, Reactance= 0.1 },
        new SmithChartPoint { Resistance= 0.001, Reactance= 0.05 }
    };
}

{% endhighlight %}
{% endtabs %}

**Run the application**

{% tabcontents %}

{% tabcontent Visual Studio %}

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. The Blazor Smith Chart component will render in your default web browser.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Open the terminal and run the following command.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet run

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent .NET CLI %}

Open the command prompt and run the following command.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet run

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjLzXCAtAueCOnlF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Smith Chart with Transmission Series](./images/blazor-smith-chart-series.webp)" %}

## Adding Title

Title can be added to the Smith Chart to provide a quick information to the users about the context of the rendered component. Add a title by using the [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartTitle.html#Syncfusion_Blazor_Charts_SmithChartTitle_Text) property in the [SmithChartTitle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartTitle.html).

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Charts

<SfSmithChart>
    <SmithChartTitle Text="Impedance Transmission">
    </SmithChartTitle>
    <SmithChartSeriesCollection>
        <SmithChartSeries Name="Transmission1"
                          Reactance="Reactance"
                          Resistance="Resistance"
                          DataSource="@FirstTransmissionSeries">
        </SmithChartSeries>
        <SmithChartSeries Name="Transmission2"
                          Points="@SecondTransmissionSeries">
        </SmithChartSeries>
    </SmithChartSeriesCollection>
</SfSmithChart>

{% endhighlight %}
{% endtabs %}

N> Refer to the [code block](#adding-series-to-smith-chart) to know about the property value of `FirstTransmissionSeries` and `SecondTransmissionSeries`.

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZBJXMUNfrbavmEP?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Smith Chart with Title](./images/blazor-smith-chart-with-title.webp)" %}

## Enable Marker

To display marker for particular series, set the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesMarker.html#Syncfusion_Blazor_Charts_SmithChartSeriesMarker_Visible) property to **true** in the [SmithChartSeriesMarker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesMarker.html).

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Charts

<SfSmithChart>
    <SmithChartTitle Text="Impedance Transmission">
    </SmithChartTitle>
    <SmithChartSeriesCollection>
        <SmithChartSeries Name="Transmission1"
                          Reactance="Reactance"
                          Resistance="Resistance"
                          DataSource="@FirstTransmissionSeries">
            <SmithChartSeriesMarker Visible="true"></SmithChartSeriesMarker>
        </SmithChartSeries>
        <SmithChartSeries Name="Transmission2"
                          Points="@SecondTransmissionSeries">
        </SmithChartSeries>
    </SmithChartSeriesCollection>
</SfSmithChart>

{% endhighlight %}
{% endtabs %}

N> Refer to the [code block](#adding-series-to-smith-chart) to know about the property value of `FirstTransmissionSeries` and `SecondTransmissionSeries`.

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjBJZMANTVYSwBSX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Smith Chart with Marker](./images/blazor-smith-chart-marker.webp)" %}

## Enable Data Label

To display data label for particular marker series, set the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesDatalabel.html#Syncfusion_Blazor_Charts_SmithChartSeriesDatalabel_Visible) property to **true** in the [SmithChartSeriesDatalabel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesDatalabel.html).

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Charts

<SfSmithChart>
    <SmithChartTitle Text="Impedance Transmission">
    </SmithChartTitle>
    <SmithChartSeriesCollection>
        <SmithChartSeries Name="Transmission1"
                          Reactance="Reactance"
                          Resistance="Resistance"
                          DataSource="@FirstTransmissionSeries">
            <SmithChartSeriesMarker Visible="true">
                <SmithChartSeriesDatalabel Visible="true">
                </SmithChartSeriesDatalabel>
            </SmithChartSeriesMarker>
        </SmithChartSeries>
        <SmithChartSeries Name="Transmission2" Points="@SecondTransmissionSeries">
        </SmithChartSeries>
    </SmithChartSeriesCollection>
</SfSmithChart>

{% endhighlight %}
{% endtabs %}

N> Refer to the [code block](#adding-series-to-smith-chart) to know the property value of `FirstTransmissionSeries` and `SecondTransmissionSeries`.

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZLzjCANJgZtmWaL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Smith Chart with Data Label](./images/blazor-smith-chart-data-label.webp)" %}

## Enable Legend

Use legend for the Smith Chart by setting the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartLegendSettings.html#Syncfusion_Blazor_Charts_SmithChartLegendSettings_Visible) property to **true** in the [SmithChartLegendSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartLegendSettings.html). The legend name can be changed by using the [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithchartSeries.html#Syncfusion_Blazor_Charts_SmithChartSeries_Name) property in the [SmithChartSeries](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithchartSeries.html).

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Charts

<SfSmithChart>
    <SmithChartLegendSettings Visible="true"></SmithChartLegendSettings>
    <SmithChartTitle Text="Impedance Transmission"></SmithChartTitle>
    <SmithChartSeriesCollection>
        <SmithChartSeries Name="Transmission1"
                          Reactance="Reactance"
                          Resistance="Resistance"
                          DataSource="@FirstTransmissionSeries">
            <SmithChartSeriesMarker Visible="true">
                <SmithChartSeriesDatalabel Visible="true">
                </SmithChartSeriesDatalabel>
            </SmithChartSeriesMarker>
        </SmithChartSeries>
        <SmithChartSeries Name="Transmission2" Points="@SecondTransmissionSeries">
        </SmithChartSeries>
    </SmithChartSeriesCollection>
</SfSmithChart>

{% endhighlight %}
{% endtabs %}

N> Refer to the [code block](#adding-series-to-smith-chart) to know the property value of the `FirstTransmissionSeries` and the `SecondTransmissionSeries`.

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNLfDCAjfUjfvoAi?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Smith Chart with Legend](./images/blazor-smith-chart-legend.webp)" %}

## Enable Tooltip

When space constraints prevents from displaying information using data labels, the tooltip comes in handy. The tooltip can be enabled by setting the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesTooltip.html#Syncfusion_Blazor_Charts_SmithChartSeriesTooltip_Visible) property to **true** in the [SmithChartSeriesTooltip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesTooltip.html).

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Charts

<SfSmithChart>
    <SmithChartLegendSettings Visible="true"></SmithChartLegendSettings>
    <SmithChartTitle Text="Impedance Transmission"></SmithChartTitle>
    <SmithChartSeriesCollection>
        <SmithChartSeries Name="Transmission1"
                          Reactance="Reactance"
                          Resistance="Resistance"
                          DataSource="@FirstTransmissionSeries">
            <SmithChartSeriesMarker Visible="true">
                <SmithChartSeriesDatalabel Visible="true">
                </SmithChartSeriesDatalabel>
            </SmithChartSeriesMarker>
            <SmithChartSeriesTooltip Visible="true">
            </SmithChartSeriesTooltip>
        </SmithChartSeries>
        <SmithChartSeries Name="Transmission2" Points="@SecondTransmissionSeries">
        </SmithChartSeries>
    </SmithChartSeriesCollection>
</SfSmithChart>

{% endhighlight %}
{% endtabs %}

N> Refer to the [code block](#adding-series-to-smith-chart) to know about the property value of the `FirstTransmissionSeries` and the `SecondTransmissionSeries`.

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNhztsKjJAXFyuof?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Smith Chart with Tooltip](./images/blazor-smith-chart-tooltip.webp)" %}

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/SmithChart).

## See also

* [Getting Started with Blazor for Client-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)

* [Getting Started with Blazor for Server-Side in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)

* [Getting Started with Blazor for Server-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)