---
layout: post
title: Getting started with Sparkline in Blazor Web App | Syncfusion®
description: Check out the documentation for getting started with Blazor Sparkline Component in Blazor Web App and much more details.
platform: Blazor
control: Sparkline Charts
documentation: ug
---

# Getting Started with Blazor Sparkline in Blazor Web App

This section briefly explains about how to include [Blazor Sparkline](https://www.syncfusion.com/blazor-components/blazor-sparkline) component in your Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/), and the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio

Create a **Blazor Web App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Syncfusion® Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio). For detailed instructions, refer to the [Blazor Web App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app) documentation.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio Code

Create a **Blazor Web App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc) or the [Syncfusion® Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project). For detailed instructions, refer to the [Blazor Web App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=visual-studio-code) documentation.

For example, in a Blazor Web App with the `Auto` interactive render mode, use the following commands in the integrated terminal (<kbd>Ctrl</kbd>+<kbd>`</kbd>):

{% tabs %}
{% highlight c# tabtitle="Blazor Web App" %}

dotnet new blazor -o BlazorWebApp -int Auto
cd BlazorWebApp
cd BlazorWebApp.Client

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent .NET CLI %}

## Prerequisites

Install the latest version of [.NET SDK](https://dotnet.microsoft.com/en-us/download). If you previously installed the SDK, determine the installed version by executing the following command in a command prompt (Windows) or terminal (macOS) or command shell (Linux).

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet --version

{% endhighlight %}
{% endtabs %}

## Create a Blazor Web App using .NET CLI

Run the following command to create a new Blazor Web App in a command prompt (Windows) or terminal (macOS) or command shell (Linux). For detailed instructions, refer to the [Blazor Web App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=.net-cli) documentation.

For example, in a Blazor Web App with the `Auto` interactive render mode, use the following commands:

{% tabs %}
{% highlight c# tabtitle="Blazor Web App" %}

dotnet new blazor -o BlazorWebApp -int Auto
cd BlazorWebApp
cd BlazorWebApp.Client

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

N> Configure the appropriate [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-10.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) while creating a Blazor Web App. For detailed information, refer to the [interactive render mode documentation](https://blazor.syncfusion.com/documentation/common/interactive-render-mode).

## Install required Blazor packages

Install the [Syncfusion.Blazor.Sparkline](https://www.nuget.org/packages/Syncfusion.Blazor.Sparkline) NuGet package using one of the following methods.

**Visual Studio (NuGet Package Manager)**:

1. Go to *Tools → NuGet Package Manager → Manage NuGet Packages for Solution*.
2. Search the required NuGet package (`Syncfusion.Blazor.Sparkline`) and install it.

**Visual Studio Code or .NET CLI**:

Open the terminal or command prompt and run the following command:

{% tabs %}
{% highlight C# tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Sparkline -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

If using the `WebAssembly` or `Auto` render modes in the Blazor Web App, install this package in the client project.

N> All Syncfusion Blazor packages are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for details.

## Add import namespaces

After the packages are installed, open the **~/_Imports.razor** file in the client project and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Charts` namespaces.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Charts

{% endhighlight %}
{% endtabs %}

## Register Blazor service

Register the Blazor service in the **Program.cs** file of your Blazor Web App.

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}

....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....

{% endhighlight %}
{% endtabs %}

N> If the **Interactive Render Mode** is set to `WebAssembly` or `Auto`, register the Blazor service in **Program.cs** files of both the server and client projects in your Blazor Web App.

## Add script resources

The script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the script reference in the **~/Components/App.razor** file.

```html

<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

```

N> Check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

## Add Blazor Sparkline component

* Open a Razor file located in the **~/Components/Pages** (for example, **Home.razor**) and add the Blazor Sparkline component inside the razor file.
* If the interactivity location is set to `Per page/component` in the Web App, define a render mode at the top of the razor file. (For example, `InteractiveServer`, `InteractiveWebAssembly` or `InteractiveAuto`).

N> If the **Interactivity Location** is set to `Global` with `Auto` or `WebAssembly`, the render mode is automatically configured in the `App.razor` file by default.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@rendermode InteractiveAuto

<SfSparkline>

</SfSparkline>

{% endhighlight %}
{% endtabs %}

## Populate Blazor Sparkline with Data

To bind data for the Sparkline component, assign a `IEnumerable` object to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfSparkline-1.html#Syncfusion_Blazor_Charts_SfSparkline_1_DataSource) property. It can also be provided as an instance of the [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html).

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@code {
    public class WeatherReport
    {
        public string Month { get; set; }
        public double Celsius { get; set; }
    };
    public List<WeatherReport> ClimateData = new List<WeatherReport> {
        new  WeatherReport { Month= "Jan", Celsius= 34 },
        new  WeatherReport { Month= "Feb", Celsius= 36 },
        new  WeatherReport { Month= "Mar", Celsius= 32 },
        new  WeatherReport { Month= "Apr", Celsius= 35 },
        new  WeatherReport { Month= "May", Celsius= 40 },
        new  WeatherReport { Month= "Jun", Celsius= 38 },
        new  WeatherReport { Month= "Jul", Celsius= 33 },
        new  WeatherReport { Month= "Aug", Celsius= 37 },
        new  WeatherReport { Month= "Sep", Celsius= 34 },
        new  WeatherReport { Month= "Oct", Celsius= 31 },
        new  WeatherReport { Month= "Nov", Celsius= 30 },
        new  WeatherReport { Month= "Dec", Celsius= 29}
    };
}

{% endhighlight %}
{% endtabs %}

Now map the `Month` and the `Celsius` fields from the datasource to [XName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfSparkline-1.html#Syncfusion_Blazor_Charts_SfSparkline_1_XName) and [YName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfSparkline-1.html#Syncfusion_Blazor_Charts_SfSparkline_1_YName) properties for x-axis and y-axis in the Sparkline and then set the `ClimateData` to [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfSparkline-1.html#Syncfusion_Blazor_Charts_SfSparkline_1_DataSource) property. Because the `Month` field is a value-based category, the [ValueType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfSparkline-1.html#Syncfusion_Blazor_Charts_SfSparkline_1_ValueType) property is used to specify it.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

<SfSparkline XName="Month"
             YName="Celsius"
             ValueType="SparklineValueType.Category"
             TValue="WeatherReport"
             DataSource="ClimateData"
             Height="80px"
             Width="150px">
</SfSparkline>

{% endhighlight %}
{% endtabs %}

### Run the application

**Visual Studio**:

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. The Blazor Sparkline component will render in your default web browser.

**Visual Studio Code or .NET CLI**:

1. Open the terminal (Visual Studio Code) or command prompt (.NET CLI) and navigate to the `Client` project folder.
2. Run the following command:

    ```
    dotnet run
    ```
3. The application will start and display in your default web browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjrJXWqjfqKBvkdq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Sparkline Chart](./images/blazor-sparkline.webp)" %}

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/Sparkline).

## Blazor Sparkline chart types

Change the Sparkline type using the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfSparkline-1.html#Syncfusion_Blazor_Charts_SfSparkline_1_Type) property set to **Line**, **Column**, **WinLoss**, **Pie** or **Area**. Here, the Sparkline type is set to **Area**.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

<SfSparkline XName="Month"
             YName="Celsius"
             ValueType="SparklineValueType.Category"
             Type="SparklineType.Area"
             TValue="WeatherReport"
             DataSource="ClimateData"
             Height="80px"
             Width="150px">
</SfSparkline>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjLTtsqNTqqdYsqg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Sparkline Area Chart](./images/blazor-area-sparkline.webp)" %}

N> Refer to [code block](#populate-sparkline-with-data) to know about the property value of **ClimateData**.

## Adding Data Label

Add the Data Labels to improve the readability of the Sparkline component. This can be achieved by setting the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineDataLabelSettings.html#Syncfusion_Blazor_Charts_SparklineDataLabelSettings_Visible) property to **true** in the [SparklineDataLabelSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineDataLabelSettings.html).

Available types are:

* Start
* End
* All
* High
* Low
* Negative

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

<SfSparkline DataSource="ClimateData"
              TValue="WeatherReport"
              XName="Month"
              YName="Celsius"
              ValueType="SparklineValueType.Category"
              Height="80px"
              Width="150px">
    <SparklineDataLabelSettings Visible="new List<VisibleType> { VisibleType.Start, VisibleType.End }"></SparklineDataLabelSettings>
    <SparklinePadding Left="10" Right="10"></SparklinePadding>
</SfSparkline>

{% endhighlight %}
{% endtabs %}

N> Refer to the [code block](#populate-sparkline-with-data) to know about the property value of **ClimateData**.

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDrJXsqtfqzDdTTI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Sparkline Chart with Data Label](./images/blazor-sparkline-data-label.webp)" %}

## Enable tooltip

When space constraints prevent from displaying information using Data Labels, the tooltip comes in handy. The tooltip can be enabled by setting the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineTooltipSettings-1.html#Syncfusion_Blazor_Charts_SparklineTooltipSettings_1_Visible) property to **true** in the [SparklineTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineTooltipSettings-1.html).

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

<SfSparkline DataSource="ClimateData"
             TValue="WeatherReport"
             XName="Month"
             YName="Celsius"
             ValueType="SparklineValueType.Category"
             Height="80px"
             Width="150px">
    <SparklineDataLabelSettings Visible="new List<VisibleType> { VisibleType.Start, VisibleType.End }"></SparklineDataLabelSettings>
    <SparklinePadding Left="10" Right="10"></SparklinePadding>
    <SparklineTooltipSettings TValue="WeatherReport" Visible="true"></SparklineTooltipSettings>
</SfSparkline>

{% endhighlight %}
{% endtabs %}

N> Refer to the [code block](#populate-sparkline-with-data) to know about the property value of the **ClimateData**.

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZLfDsUNfgJpNFjr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Sparkline Chart with Tooltip](./images/blazor-sparkline-tooltip.webp)" %}

## See also

* [Getting Started with Blazor for Client-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-dotnet-cli)

* [Getting Started with Blazor for Server-Side in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)

* [Getting Started with Blazor for Server-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-dotnet-cli)

N> You can also explore our [Blazor Sparkline Chart example](https://blazor.syncfusion.com/demos/sparkline/default-functionalities?theme=bootstrap5) that shows you how to render and configure the sparkline chart.