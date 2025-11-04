---
layout: post
title: Getting Started with Syncfusion Blazor Dashboard Layout in Web App
description: Checkout and learn about the documentation for getting started with Blazor Dashboard Layout Component in Blazor Web App.
platform: Blazor
component: Dashboard Layout
documentation: ug
---

# Getting Started with Blazor Dashboard Layout Component in Web App

This section briefly explains about how to include [Blazor Dashboard Layout](https://www.syncfusion.com/blazor-components/blazor-dashboard) component in your Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/) and Visual Studio Code.

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio

You can create a **Blazor Web App** using Visual Studio 2022 via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

You need to configure the corresponding [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-8.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-8.0&pivots=vs) while creating a Blazor Web Application.

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Layouts and Themes NuGet in the Blazor Web App

To add **Blazor Dashboard Layout** component in the app, open the NuGet package manager in Visual Studio (*Tools → NuGet Package Manager → Manage NuGet Packages for Solution*), search and install [Syncfusion.Blazor.Layouts](https://www.nuget.org/packages/Syncfusion.Blazor.Layouts/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/).

If you utilize `WebAssembly or Auto` render modes in the Blazor Web App need to be install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components NuGet packages within the client project.

Alternatively, you can utilize the following package manager command to achieve the same.

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Layouts -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

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

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Layouts and Themes NuGet in the App

If you utilize `WebAssembly` or `Auto` render modes in the Blazor Web App need to be install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components NuGet packages within the client project.

* Press <kbd>Ctrl</kbd>+<kbd>`</kbd> to open the integrated terminal in Visual Studio Code.
* Ensure you’re in the project root directory where your `.csproj` file is located.
* Run the following command to install a [Syncfusion.Blazor.Layouts](https://www.nuget.org/packages/Syncfusion.Blazor.Layouts) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet package and ensure all dependencies are installed.

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.Layouts -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
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

Import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Layouts` namespace.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Layouts

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

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the stylesheet reference in the `<head>` section and the script reference at the end of the `<body>` in the **~/Components/App.razor** file as shown below:

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>
....
<body>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in your Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

## Add Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Dashboard Layout component

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Dashboard Layout component in `.razor` file inside the `Pages` folder. If an interactivity location as `Per page/component` in the web app, define a render mode at top of the component, as follows:

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

@using Syncfusion.Blazor.Layouts

<SfDashboardLayout>
    <DashboardLayoutPanels>
        <DashboardLayoutPanel>
        </DashboardLayoutPanel>
    </DashboardLayoutPanels>
</SfDashboardLayout>

{% endhighlight %}
{% endtabs %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. This will render the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Dashboard Layout component in your default web browser.

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjVpXihOLKRGIhFf?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Dashboard Layout Component](images/blazor-dashboard-layout-component.png)" %}

## Defining panels

A Dashboard Layout can be rendered with multiple panels to design a template with its basic properties.

A Dashboard Layout panel consists of two sections, which are Header and Content section. [`HeaderTemplate`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutPanel.html#Syncfusion_Blazor_Layouts_DashboardLayoutPanel_HeaderTemplate) is used to render the Header section and [`ContentTemplate`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutPanel.html#Syncfusion_Blazor_Layouts_DashboardLayoutPanel_ContentTemplate) is used to render the content section.

Also, it is easy to interact with the panels by dragging, floating, and resizing functionality of panels.

### Panels with simple data

A Dashboard Layout panel is rendered with simple data. The header of a panel is defined by [`HeaderTemplate`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutPanel.html#Syncfusion_Blazor_Layouts_DashboardLayoutPanel_HeaderTemplate) and content of a panel is defined by [`ContentTemplate`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutPanel.html#Syncfusion_Blazor_Layouts_DashboardLayoutPanel_ContentTemplate).

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Layouts

<SfDashboardLayout>
    <DashboardLayoutPanels>
        <DashboardLayoutPanel>
            <HeaderTemplate><div>Panel 1</div></HeaderTemplate>
            <ContentTemplate><div>Content</div></ContentTemplate>
        </DashboardLayoutPanel>
    </DashboardLayoutPanels>
</SfDashboardLayout>

<style>
    .e-panel-header {
        background-color: rgba(0, 0, 0, .1);
        text-align: center;
    }
    .e-panel-content {
        text-align: center;
        margin-top: 10px;
    }
</style>

{% endhighlight %}
{% endtabs %}

The Dashboard Layout with simple content will be rendered in the web browser as demonstrated in the following screenshot.

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDLzXChErUwBJvMB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Dashboard Layout with Single Data](images/blazor-dashboard-layout-single-content.png)" %}

### Panels with components

A Dashboard Layout can be rendered with the components like the chart, grids, maps, gauge, and more as a content of Dashboard Layout panel.

These complex data (components) are placed as the panel content by assigning the corresponding component element as the [`ContentTemplate`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutPanel.html#Syncfusion_Blazor_Layouts_DashboardLayoutPanel_ContentTemplate) of the panel.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Charts
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Layouts

<div class="content">
    <SfDashboardLayout Columns="6" CellSpacing="@(new double[]{10 ,10 })">
        <DashboardLayoutPanels>
            <DashboardLayoutPanel Id="Panel1" SizeX="4" SizeY="2">
                <HeaderTemplate><div class='header'> Customers Count </div></HeaderTemplate>
                <ContentTemplate>
                    <div style="height:100%; width:100%;">
                        <SfChart ID="linechart" @ref="linechartObj">
                            <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime">
                            </ChartPrimaryXAxis>
                            <ChartSeriesCollection>
                                <ChartSeries DataSource="@DataSource" XName="XValue" YName="YValue" Type="ChartSeriesType.Line">
                                    <ChartMarker Visible="true">
                                        <ChartDataLabel Visible="true" Position="Syncfusion.Blazor.Charts.LabelPosition.Top">
                                        </ChartDataLabel>
                                    </ChartMarker>
                                </ChartSeries>
                            </ChartSeriesCollection>
                        </SfChart>
                    </div>
                </ContentTemplate>
            </DashboardLayoutPanel>
            <DashboardLayoutPanel Id="Panel2" SizeX="2" SizeY="2" Column="4">
                <HeaderTemplate><div class='header'> Product sales in Years </div></HeaderTemplate>
                <ContentTemplate>
                    <div style="height:100%; width:100%;">
                        <SfRangeNavigator ID="range" @ref="rangeObj" Value="@Value" ValueType="Syncfusion.Blazor.Charts.RangeValueType.DateTime" IntervalType="RangeIntervalType.Years" LabelFormat="yyyy">
                            <RangeNavigatorSeriesCollection>
                                <RangeNavigatorSeries DataSource="@DataSource" XName="XValue" Type="RangeNavigatorType.Area" YName="YValue"></RangeNavigatorSeries>
                            </RangeNavigatorSeriesCollection>
                        </SfRangeNavigator>
                    </div>
                </ContentTemplate>
            </DashboardLayoutPanel>
            <DashboardLayoutPanel Id="Panel3" SizeX="3" SizeY="2" Row=2 Column=3>
                <HeaderTemplate><div class='header'> Sales Ratio in Countries </div></HeaderTemplate>
                <ContentTemplate>
                    <div style="height:100%; width:100%;">
                        <SfChart ID="chart" @ref="barchartObj">
                            <ChartPrimaryXAxis Title="Country" EnableTrim="true" ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
                                <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
                            </ChartPrimaryXAxis>
                            <ChartSeriesCollection>
                                <ChartSeries DataSource="@DataSource" XName="X" YName="Y" Type="ChartSeriesType.Bar">
                                </ChartSeries>
                            </ChartSeriesCollection>
                        </SfChart>
                    </div>

                </ContentTemplate>
            </DashboardLayoutPanel>
            <DashboardLayoutPanel Id="Panel4" SizeX=3 SizeY=2 Row=2 Column=0>
                <HeaderTemplate><div class='header'> Sales Comparison in Products  </div></HeaderTemplate>
                <ContentTemplate>
                    <div style="height:100%; width:100%;">
                        <SfChart ID="chart1" @ref="chartObj" Width="100%" Height="100%">
                            <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
                            <ChartSeriesCollection>
                                <ChartSeries DataSource="@DataSource" Name="Editors" XName="X1" YName="YValue" Type="ChartSeriesType.StackingColumn">
                                </ChartSeries>
                                <ChartSeries DataSource="@DataSource" Name="Layouts" XName="X1" YName="YValue" Type="ChartSeriesType.StackingColumn">
                                </ChartSeries>
                                <ChartSeries DataSource="@DataSource" Name="Grids" XName="X1" YName="YValue" Type="ChartSeriesType.StackingColumn">
                                </ChartSeries>
                            </ChartSeriesCollection>
                        </SfChart>
                    </div>
                </ContentTemplate>
            </DashboardLayoutPanel>
            <DashboardLayoutPanel Id="Panel5" SizeX=6 SizeY=2 Column=6 Row=4>
                <HeaderTemplate><div class='header'> Top Customers Details</div></HeaderTemplate>
                <ContentTemplate>
                    <div style="height:100%; width:100%;">
                        <SfGrid ID="grid" DataSource="@Orders">
                            <GridPageSettings></GridPageSettings>
                            <GridColumns>
                                <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
                                <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="130"></GridColumn>
                                <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="150"></GridColumn>
                                <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
                            </GridColumns>
                        </SfGrid>
                    </div>
                </ContentTemplate>
            </DashboardLayoutPanel>
        </DashboardLayoutPanels>
    </SfDashboardLayout>
</div>
@code
 { SfChart chartObj;
    SfChart barchartObj;
    SfRangeNavigator rangeObj;
    SfChart linechartObj;
    private object[] Value = new object[] { new DateTime(2006, 01, 01), new DateTime(2008, 01, 01) };
    public class ChartData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
        public string X { get; set; }
        public double Y { get; set; }
        public string Country { get; set; }
        public string X1 { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }
        public double Y4 { get; set; }
    }
    public List<ChartData> DataSource = new List<ChartData>
{
        new ChartData { XValue = new DateTime(2005, 01, 01), YValue = 21, X = "USA", Y =300.2, Country = "USA: 72", X1= "2012"},
        new ChartData { XValue = new DateTime(2006, 01, 01), YValue = 24, X = "Russia", Y = 103.1, Country = "RUS: 103.1", X1= "2013"},
        new ChartData { XValue = new DateTime(2007, 01, 01), YValue = 36, X = "Brazil", Y = 139.1, Country = "BRZ: 139.1", X1= "2014"},
        new ChartData { XValue = new DateTime(2008, 01, 01), YValue = 38, X = "India", Y = 262.1, Country = "IND: 262.1", X1= "2015"},
        };
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 6).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        await Task.Delay(3000); // simulate the async operations
        this.chartObj.RefreshAsync();
        this.linechartObj.RefreshAsync();
        this.barchartObj.RefreshAsync();
    }
 }

<style>
    #linechart, #grid, #chart1, #chart, #range {
        height: 100% !important;
        width: 100% !important;
    }
</style>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNLSDIVjTEDbFVUJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Dashboard Layout displays Chart Component Content](images/blazor-dashboard-layout-with-chart-component.png)" %}

N> While using the **SfRangeNavigator** component in this sample, ensure that the [Syncfusion.Blazor.RangeNavigator](https://www.nuget.org/packages/Syncfusion.Blazor.RangeNavigator) NuGet package is installed in your project. You can install the package from [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor).

To get started quickly with designing a Blazor Dashboard Layout with UI Components, you can check the video below.

{% youtube
"youtube:https://www.youtube.com/watch?v=KOetW4f6_v4" %}

By default, the Dashboard Layout component is rendered with auto adjustable and [responsive](https://blazor.syncfusion.com/documentation/dashboard-layout/responsive-adaptive) according to the parent dimensions.

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/DashboardLayout).

## See also

1. [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for client-side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)
2. [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for client-side in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-visual-studio)
3. [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for server-side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)

