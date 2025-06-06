---
layout: post
title: Getting Stared with Blazor TreeMap Component | Syncfusion
description: Checkout and learn about getting started with Blazor TreeMap component in Blazor WebAssembly Application.
platform: Blazor
control: TreeMap
documentation: ug
---

# Getting Started with Blazor TreeMap Component

This section briefly explains about how to include [Blazor TreeMap](https://www.syncfusion.com/blazor-components/blazor-treemap) component in your Blazor WebAssembly App using Visual Studio and Visual Studio Code.

To get started quickly with Blazor TreeMap component, check on the following video:

{% youtube
"youtube:https://www.youtube.com/watch?v=j01ZNzIe4eo"%}

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor App in Visual Studio

You can create a **Blazor WebAssembly App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-7.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeMap NuGet in the App

To add **Blazor TreeMap** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.TreeMap](https://www.nuget.org/packages/Syncfusion.Blazor.TreeMap). Alternatively, you can utilize the following package manager command to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.TreeMap -Version {{ site.releaseversion }}

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

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeMap NuGet in the App

* Press <kbd>Ctrl</kbd>+<kbd>`</kbd> to open the integrated terminal in Visual Studio Code.
* Ensure you’re in the project root directory where your `.csproj` file is located.
* Run the following command to install a [Syncfusion.Blazor.TreeMap](https://www.nuget.org/packages/Syncfusion.Blazor.TreeMap) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet package and ensure all dependencies are installed.

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.TreeMap -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

{% endtabcontent %}

{% endtabcontents %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

Open **~/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.TreeMap` namespace.

{% tabs %}
{% highlight razor tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.TreeMap

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

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSyncfusionBlazor();
await builder.Build().RunAsync();
....

{% endhighlight %}
{% endtabs %}

## Add script resources

The script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the script reference in the `<head>` section of the **~/index.html** file.

```html
<head>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>
```
N> Check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

## Add Blazor TreeMap component

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeMap component in the **~/Pages/Index.razor** file.

* You can use the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.SfTreeMap-1.html#Syncfusion_Blazor_TreeMap_SfTreeMap_1_DataSource) property to load the car sales details in the TreeMap component. Specify a field name from the data source in the [WeightValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.SfTreeMap-1.html#Syncfusion_Blazor_TreeMap_SfTreeMap_1_WeightValuePath) property to calculate the TreeMap item size.

{% tabs %}
{% highlight razor %}

<SfTreeMap DataSource="GrowthReport"
            WeightValuePath="GDP"
            TValue="Country">
</SfTreeMap>

@code {
    public class Country
    {
        public string Name { get; set; }
        public double GDP { get; set; }
    }
    public List<Country> GrowthReport = new List<Country> {
        new Country  {Name="United States", GDP=17946 },
        new Country  {Name="China", GDP=10866 },
        new Country  {Name="Japan", GDP=4123 },
        new Country  {Name="Germany", GDP=3355 },
        new Country  {Name="United Kingdom", GDP=2848 },
        new Country  {Name="France", GDP=2421 },
        new Country  {Name="India", GDP=2073 },
        new Country  {Name="Italy", GDP=1814 },
        new Country  {Name="Brazil", GDP=1774 },
        new Country  {Name="Canada", GDP=1550 }
    };
}

{% endhighlight %}
{% endtabs %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeMap component in your default web browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtLzNCgtfcrsSecB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor TreeMap Component](images/blazor-treemap.png)" %}

## Adding labels in Blazor TreeMap items

Add label text to the leaf items in the TreeMap component by setting the field name from data source in the [LabelPath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.TreeMapLeafItemSettings.html#Syncfusion_Blazor_TreeMap_TreeMapLeafItemSettings_LabelPath) property in the [TreeMapLeafItemSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.TreeMapLeafItemSettings.html), and it provides information to the user about the leaf items.

{% tabs %}
{% highlight razor %}

<SfTreeMap DataSource="GrowthReport"
            WeightValuePath="GDP"
            TValue="Country">
    <TreeMapLeafItemSettings LabelPath="Name" Fill="lightgray"></TreeMapLeafItemSettings>
</SfTreeMap>

{% endhighlight %}
{% endtabs %}

N> Refer to the [code block](#adding-treemap-component) to know about the property value of the **GrowthReport**.

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtBpXWUjTGrcfQex?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor TreeMap with Label](images/blazor-treemap-with-label.png)" %}

## Adding title to Blazor TreeMap

Add a title using the [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.TreeMapTitleSettings.html#Syncfusion_Blazor_TreeMap_TreeMapTitleSettings_Text) property in the [TreeMapTitleSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.TreeMapTitleSettings.html) to provide quick information to the user about the items rendered in the TreeMap.

{% tabs %}
{% highlight razor %}

<SfTreeMap DataSource="GrowthReport"
            WeightValuePath="GDP"
            TValue="Country">
    <TreeMapTitleSettings Text="Top 10 countries by GDP Nominal - 2015"></TreeMapTitleSettings>
    <TreeMapLeafItemSettings LabelPath="Name" Fill="lightgray"></TreeMapLeafItemSettings>
</SfTreeMap>

{% endhighlight %}
{% endtabs %}

N> Refer to the [code block](#adding-treemap-component) to know the property value of the **GrowthReport**.

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDVJNWgtfGUUNerG?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor TreeMap with Title](images/blazor-treemap-with-title.png)" %}

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/TreeMap).

## Apply color mapping

The color mapping supports customization of item colors based on the underlying value received from the bound data source. Specify the field name from which the values have to be compared for the items in the [RangeColorValuePath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.SfTreeMap-1.html#Syncfusion_Blazor_TreeMap_SfTreeMap_1_RangeColorValuePath) property in [SfTreeMap](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.SfTreeMap-1.html). Also, specify range value and color in the [TreeMapLeafColorMapping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.TreeMapLeafColorMapping.html). Here, in this example, **"Orange"** is specified for the range **"0 - 3000"** and **"Green"** is specified for the range **"3000 - 20000"**.

{% tabs %}
{% highlight razor %}

<SfTreeMap DataSource="GrowthReport"
            WeightValuePath="GDP"
            TValue="Country"
            RangeColorValuePath="GDP">
    <TreeMapTitleSettings Text="Top 10 countries by GDP Nominal - 2015"></TreeMapTitleSettings>
    <TreeMapLeafItemSettings LabelPath="Name" Fill="lightgray">
        <TreeMapLeafColorMappings>
            <TreeMapLeafColorMapping StartRange="0" EndRange="3000" Color="@(new string[] { "Orange" })"></TreeMapLeafColorMapping>
            <TreeMapLeafColorMapping StartRange="3000" EndRange="20000" Color="@(new string[] { "Green" })"></TreeMapLeafColorMapping>
        </TreeMapLeafColorMappings>
    </TreeMapLeafItemSettings>
</SfTreeMap>

{% endhighlight %}
{% endtabs %}

N> Refer to the [code block](#adding-treemap-component) to know about the property value of the **GrowthReport**.

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZBpZWAjTGKvLKSK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor TreeMap with Color Mapping](images/blazor-treemap-color-mapping.png)" %}

## Enable legend

Legend items are used to denote the color mapping categories and show the legend for the TreeMap by setting the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.TreeMapLegendSettings.html#Syncfusion_Blazor_TreeMap_TreeMapLegendSettings_Visible) property to **true** in the [TreeMapLegendSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.TreeMapLegendSettings.html).

{% tabs %}
{% highlight razor %}

<SfTreeMap DataSource="GrowthReport"
            WeightValuePath="GDP"
            TValue="Country"
            RangeColorValuePath="GDP">
    <TreeMapTitleSettings Text="Top 10 countries by GDP Nominal - 2015"></TreeMapTitleSettings>
    <TreeMapLeafItemSettings LabelPath="Name" Fill="lightgray">
        <TreeMapLeafColorMappings>
            <TreeMapLeafColorMapping StartRange="0" EndRange="3000" Color="@(new string[] { "Orange" })"></TreeMapLeafColorMapping>
            <TreeMapLeafColorMapping StartRange="3000" EndRange="20000" Color="@(new string[] { "Green" })"></TreeMapLeafColorMapping>
        </TreeMapLeafColorMappings>
    </TreeMapLeafItemSettings>
    <TreeMapLegendSettings Visible="true"></TreeMapLegendSettings>
</SfTreeMap>

{% endhighlight %}
{% endtabs %}

N> Refer to the [code block](#adding-treemap-component) to know about the property value of the **GrowthReport**.

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjBpDCqDJcJzjaSL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor TreeMap with Legend](images/blazor-treemap-legend.png)" %}

## Enable tooltip

When space constraints prevents from displaying information using data labels, the tooltip comes in handy. The tooltip can be enabled by setting the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.TreeMapTooltipSettings.html#Syncfusion_Blazor_TreeMap_TreeMapTooltipSettings_Visible) property to **true** in the [TreeMapTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeMap.TreeMapTooltipSettings.html).

{% tabs %}
{% highlight razor %}

<SfTreeMap DataSource="GrowthReport"
            WeightValuePath="GDP"
            TValue="Country"
            RangeColorValuePath="GDP">
    <TreeMapTitleSettings Text="Top 10 countries by GDP Nominal - 2015"></TreeMapTitleSettings>
    <TreeMapLeafItemSettings LabelPath="Name" Fill="lightgray">
        <TreeMapLeafColorMappings>
            <TreeMapLeafColorMapping StartRange="0" EndRange="3000" Color="@(new string[] { "Orange" })"></TreeMapLeafColorMapping>
            <TreeMapLeafColorMapping StartRange="3000" EndRange="20000" Color="@(new string[] { "Green" })"></TreeMapLeafColorMapping>
        </TreeMapLeafColorMappings>
    </TreeMapLeafItemSettings>
    <TreeMapLegendSettings Visible="true"></TreeMapLegendSettings>
    <TreeMapTooltipSettings Visible="true"></TreeMapTooltipSettings>
</SfTreeMap>

{% endhighlight %}
{% endtabs %}

N> Refer to the [code block](#adding-treemap-component) to know about the property value of the **GrowthReport**.

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZBJXCUDJGTEuBNf?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor TreeMap with Tooltip](images/blazor-treemap-tooltip.png)" %}

N> You can also explore our [Blazor TreeMap example](https://blazor.syncfusion.com/demos/treemap/default-functionalities?theme=bootstrap5) that shows you how to render and configure the treemap.

## See also

* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for Client-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-dotnet-cli)

* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for Server-Side in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)

* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for Server-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-dotnet-cli)
