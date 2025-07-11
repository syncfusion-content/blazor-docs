---
layout: post
title: Getting Started with Syncfusion Blazor 3D Chart Component in WebApp
description: Checkout and learn about the documentation for getting started with Blazor 3D Chart Component in Blazor Web App.
platform: Blazor
component: 3D Chart
documentation: ug
---

# Getting Started with Blazor 3D Chart Component in Web App

This section briefly explains about how to include `Blazor 3D Chart` component in your Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/) and Visual Studio Code.

To get started quickly with Blazor 3D Chart component, check on the following video:

{% youtube
"youtube:https://www.youtube.com/watch?v=iCWdoRnu-6s" %}

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio

You can create a **Blazor Web App** using Visual Studio 2022 via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

You need to configure the corresponding [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vs) while creating a Blazor Web Application.

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor 3D Chart NuGet in the Blazor Web App

To add **Blazor 3D Chart** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.Chart3D](https://www.nuget.org/packages/Syncfusion.Blazor.Chart3D).

If you utilize `WebAssembly or Auto` render modes in the Blazor Web App need to be install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components NuGet packages within the client project.

Alternatively, you can utilize the following package manager command to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Chart3D -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio Code

You can create a **Blazor Web App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project).

You need to configure the corresponding [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vsc) while creating a Blazor Web Application.

For example, in a Blazor Web App with the `Auto` interactive render mode, use the following commands.

{% tabs %}
{% highlight c# tabtitle="Blazor Web App" %}

dotnet new blazor -o BlazorWebApp -int Auto
cd BlazorWebApp
cd BlazorWebApp.Client

{% endhighlight %}
{% endtabs %}

N> For more information on creating a **Blazor Web App** with various interactive modes and locations, refer to this [link](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=visual-studio-code#render-interactive-modes).

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Chart3D NuGet in the App

If you utilize `WebAssembly` or `Auto` render modes in the Blazor Web App need to be install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components NuGet packages within the client project.

* Press <kbd>Ctrl</kbd>+<kbd>`</kbd> to open the integrated terminal in Visual Studio Code.
* Ensure you’re in the project root directory where your `.csproj` file is located.
* Run the following command to install a [Syncfusion.Blazor.Chart3D](https://www.nuget.org/packages/Syncfusion.Blazor.Chart3D) NuGet package and ensure all dependencies are installed.

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.Chart3D -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

{% endtabcontent %}

{% endtabcontents %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

| Interactive Render Mode | Description |
| -- | -- |
| WebAssembly or Auto | Open **~/_Imports.razor** file from the client project.|
| Server | Open **~/_import.razor** file, which is located in the `Components` folder.|

Import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Chart3D` namespace.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Chart3D

{% endhighlight %}
{% endtabs %}

Now, register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service in the **~/Program.cs** file of your Blazor Web App.

If the **Interactive Render Mode** is set to `WebAssembly` or `Auto`, you need to register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in both **~/Program.cs** files of your Blazor Web App.

{% tabs %}
{% highlight c# tabtitle="Server(~/_Program.cs)" hl_lines="3 11" %}

...
...
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
....

{% endhighlight %}
{% highlight c# tabtitle="Client(~/_Program.cs)" hl_lines="2 5" %}

...
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSyncfusionBlazor();

await builder.Build().RunAsync();

{% endhighlight %}
{% endtabs %}

If the **Interactive Render Mode** is set to `Server`, your project will contain a single **~/Program.cs** file. So, you should register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service only in that **~/Program.cs** file.

{% tabs %}
{% highlight c# tabtitle="~/_Program.cs" hl_lines="2 9" %}

...
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
....

{% endhighlight %}
{% endtabs %}

## Add script resources

The script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the script reference at the end of the `<body>` in the **~/Components/App.razor** file as shown below:

```html
<head>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>
```

N> Check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

## Add Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor 3D Chart component

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor 3D Chart component in `.razor` file inside the `Pages` folder. If an interactivity location as `Per page/component` in the web app, define a render mode at top of the component, as follows:

| Interactivity location | RenderMode | Code |
| --- | --- | --- |
| Per page/component | Auto | @rendermode InteractiveAuto |
|  | WebAssembly | @rendermode InteractiveWebAssembly |
|  | Server | @rendermode InteractiveServer |
|  | None | --- |

N> If an **Interactivity Location** is set to `Global` and the **Render Mode** is set to `Auto` or `WebAssembly` or `Server`, the render mode is configured in the `App.razor` file by default.

{% tabs %}
{% highlight razor %}

@* desired render mode define here *@
@rendermode InteractiveAuto

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight razor %}

<SfChart3D>

</SfChart3D>

{% endhighlight %}
{% endtabs %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor 3D Chart component in your default web browser.

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

## Add 3D Chart title

Using the `Title` property, you can add a title to the chart and the axes to provide the user with quick information about the data plotted in the chart.

{% tabs %}
{% highlight razor %}

<SfChart3D Title="Sales Analysis">
    <Chart3DPrimaryXAxis Title="Month" ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category"></Chart3DPrimaryXAxis>
    <Chart3DPrimaryYAxis Title="Sales in Dollar"></Chart3DPrimaryYAxis>
    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="Chart3DSeriesType.Column">
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtLfNRsgCVjHdioT?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDhpDRiKMriVAFPn?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtrfDxCqCLizaoKV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXLzXHWUiVMwxISt?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## See also

1. [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for client-side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-dotnet-cli)
2. [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for client-side in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-visual-studio)
3. [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for server-side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-dotnet-cli)

