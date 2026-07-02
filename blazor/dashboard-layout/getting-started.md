---
layout: post
title: Getting Started with Blazor Dashboard Layout in Blazor WASM App | Syncfusion
description: Checkout and learn about getting started with Blazor Dashboard Layout component in Blazor WebAssembly Application.
platform: Blazor
control: Dashboard Layout
documentation: ug
---

# Getting Started with Blazor Dashboard Layout component in Blazor WASM App

This section briefly explains about how to include [Blazor Dashboard Layout](https://www.syncfusion.com/blazor-components/blazor-dashboard) component in a Blazor WebAssembly App using [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/), and the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

## Create a new Blazor WebAssembly (Standalone) App

{% tabcontents %}

{% tabcontent Visual Studio %}

Create a **Blazor WebAssembly App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Run the following command to create a new Blazor WebAssembly App.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet new blazorwasm -o BlazorApp
cd BlazorApp

{% endhighlight %}
{% endtabs %}

Alternatively, create a **Blazor WebAssembly App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc) or the [Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project), or the [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension.

{% endtabcontent %}

{% tabcontent .NET CLI %}

Run the following command to create a new Blazor WebAssembly App.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet new blazorwasm -o BlazorApp
cd BlazorApp

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

## Install the required Blazor packages

Install the [Syncfusion.Blazor.Layouts](https://www.nuget.org/packages/Syncfusion.Blazor.Grid/), [Syncfusion.Blazor.Charts](https://www.nuget.org/packages/Syncfusion.Blazor.Charts/), [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid/), [Syncfusion.Blazor.RangeNavigator](https://www.nuget.org/packages/Syncfusion.Blazor.RangeNavigator) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet packages. All Syncfusion Blazor packages are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for details.

{% tabcontents %}

{% tabcontent Visual Studio %}

1. Go to *Tools → NuGet Package Manager → Manage NuGet Packages for Solution*.
2. Search the required NuGet packages (`Syncfusion.Blazor.Layouts`, `Syncfusion.Blazor.Charts`, `Syncfusion.Blazor.Grid`, `Syncfusion.Blazor.RangeNavigator` and `Syncfusion.Blazor.Themes`) and install them.

Alternatively, you can install the same packages using the Package Manager Console with the following commands.

{% tabs %}
{% highlight razor tabtitle="Package Manager Console" %}

Install-Package Syncfusion.Blazor.Layouts -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Charts -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Grid -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.RangeNavigator -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Open the terminal and run the following commands.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet add package Syncfusion.Blazor.Layouts -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Charts -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Grid -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.RangeNavigator -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent .NET CLI %}

Open the command prompt and run the following commands.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet add package Syncfusion.Blazor.Layouts -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Charts -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Grid -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.RangeNavigator -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

## Add import namespaces

After the packages are installed, open the **~/_Imports.razor** file and import the `Syncfusion.Blazor`, `Syncfusion.Blazor.Layouts`, `Syncfusion.Blazor.Charts` and `Syncfusion.Blazor.Grids` namespaces.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Layouts
@using Syncfusion.Blazor.Charts
@using Syncfusion.Blazor.Grids

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

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the [stylesheet](https://blazor.syncfusion.com/documentation/appearance/themes) and [script references](https://blazor.syncfusion.com/documentation/common/adding-script-references) in the **~wwwroot/index.html** file.

{% tabs %}
{% highlight html tabtitle="index.html" %}

...
<link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
...
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

## Add Blazor Dashboard Layout component

Open a Razor file located in the **~/Pages/*.razor** (for example, **Home.razor**) and add the [Blazor Dashboard Layout](https://www.syncfusion.com/blazor-components/blazor-dashboard) component inside the razor file.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Layouts

<SfDashboardLayout>
    <DashboardLayoutPanels>
        <DashboardLayoutPanel>
        </DashboardLayoutPanel>
    </DashboardLayoutPanels>
</SfDashboardLayout>

{% endhighlight %}
{% endtabs %}

N> There is no need to assign default value for panels. Refer to the [Panels](./panels/position-sizing-of-panels#panels) section to learn about default value.

**Run the application**

{% tabcontents %}

{% tabcontent Visual Studio %}

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. The Blazor Dashboard Layout component will render in your default web browser.

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtLxtRLUKlzqHcwQ?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Dashboard Layout Component](images/blazor-dashboard-layout-component.webp)" %}

N> [View sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/DashboardLayout).

## Defining Panels

The Dashboard Layout component renders multiple panels, each designed using basic properties. Each panel consists of two sections: a header and a content section. These are defined using the [`HeaderTemplate`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutPanel.html#Syncfusion_Blazor_Layouts_DashboardLayoutPanel_HeaderTemplate) and [`ContentTemplate`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutPanel.html#Syncfusion_Blazor_Layouts_DashboardLayoutPanel_ContentTemplate) properties, respectively.

Panels are interactive, supporting functionalities such as dragging, floating, and resizing.

## Panels with Simple Data

A basic Dashboard Layout panel can display simple data. The panel's header is defined by  [`HeaderTemplate`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutPanel.html#Syncfusion_Blazor_Layouts_DashboardLayoutPanel_HeaderTemplate), and its content by the [`ContentTemplate`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutPanel.html#Syncfusion_Blazor_Layouts_DashboardLayoutPanel_ContentTemplate).

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZBHNxhgKwFngyBq?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Dashboard Layout with Single Data](images/blazor-dashboard-layout-single-content.webp)" %}

## Panels with Components

A Dashboard Layout can also host complex UI components such as charts, grids, maps, or gauges within its panels.

These components are placed as panel content by assigning the corresponding Blazor component element as the [`ContentTemplate`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Layouts.DashboardLayoutPanel.html#Syncfusion_Blazor_Layouts_DashboardLayoutPanel_ContentTemplate) of the panel.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

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
 { 
    SfChart chartObj;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LthdjxLUqbWENRZr?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Dashboard Layout displays Chart Component Content](images/blazor-dashboard-layout-with-chart-component.webp)" %}

To get started quickly with designing a Blazor Dashboard Layout with UI Components, you can check the video below.

{% youtube
"youtube:https://www.youtube.com/watch?v=KOetW4f6_v4" %}

By default, the Dashboard Layout component is rendered with auto-adjustable and [responsive](https://blazor.syncfusion.com/documentation/dashboard-layout/responsive-adaptive) panels according to the parent dimensions.

## See also

1. [Getting Started with Blazor for Client-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)
2. [Getting Started with Blazor for Client-Side in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-visual-studio)
3. [Getting Started with Blazor for Server-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)
