---
layout: post
title: Getting Started with Blazor Dashboard Layout Component | Syncfusion
description: Checkout and learn more details about getting started with the Blazor Dashboard Layout component of Syncfusion.
platform: Blazor
control: Dashboard Layout
documentation: ug
---

# Getting Started with Blazor Dashboard Layout Component

This section briefly explains about how to include a `Dashboard Layout` component in your `Blazor server-side application`. You can refer [Getting Started with Syncfusion Blazor for Server-Side in Visual Studio 2019](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio-2019/) page for introduction and configuring the common specifications.

## Importing Syncfusion Blazor component in the application

### Using Syncfusion.Blazor NuGet Package [Old standard]

* Install **Syncfusion.Blazor** NuGet package to the application by using the `NuGet Package Manager`.

* You can add the client-side style resources using NuGet package to the `<head>` element of the `~/wwwroot/index.html` page in Blazor WebAssembly app or `~/Pages/_Host.cshtml` page in Blazor Server app.

    > You can also add the client-side style resources through CDN.

    ```html
    <head>
        ....
        ....
        <link href="_content/Syncfusion.Blazor/styles/bootstrap4.css" rel="stylesheet" />
    </head>
    ```

    ```html
    <head>
        <link href="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/styles/bootstrap4.css" rel="stylesheet" />
    </head>
    ```

* For `Internet Explorer 11`, kindly refer the polyfills. Refer the [documentation](https://blazor.syncfusion.com/documentation/common/how-to/render-blazor-server-app-in-ie/) for more information.

    ```html
    <head>
        <link href="_content/Syncfusion.Blazor/styles/bootstrap4.css" rel="stylesheet" />
        <script src="https://github.com/Daddoon/Blazor.Polyfill/releases/download/3.0.1/blazor.polyfill.min.js"></script>
    </head>
    ```

### Using Syncfusion.Blazor NuGet Package [New standard]

* Install **Syncfusion.Blazor.Layouts** NuGet package to the application by using the `NuGet Package Manager`.

    W> `Syncfusion.Blazor` package should not be installed along with [individual NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages/). Hence, you have to add the below `Syncfusion.Blazor.Themes` static web assets (styles) in the application.

* You can add the client-side style resources using NuGet package to the `<head>` element of the `~/wwwroot/index.html` page in Blazor WebAssembly app or `~/Pages/_Host.cshtml` page in Blazor Server app.

    ```html
    <head>
        ....
        ....
        <link href="_content/Syncfusion.Blazor.Themes/bootstrap4.css" rel="stylesheet" />
    </head>
    ```

    W> If you prefer the above new standard (individual NuGet packages), then skip this section. Using both old and new standards in the same application will throw ambiguous compilation errors.

## Add Syncfusion Blazor service in Startup.cs (Server-side application)

Open the **Startup.cs** file and add services required by Syncfusion components using `services.AddSyncfusionBlazor()` method. Add this method in the **ConfigureServices** function as follows.

```csharp
using Syncfusion.Blazor;

namespace BlazorApplication
{
    public class Startup
    {
        ....
        ....
        public void ConfigureServices(IServiceCollection services)
        {
            ....
            ....
            services.AddSyncfusionBlazor();
        }
    }
}

```

## Add Syncfusion Blazor service in Program.cs (Client-side application)

Open the **Program.cs** file and add services required by Syncfusion components using `builder.services.AddSyncfusionBlazor()` method. Add this method in the **Main** function as follows.

```csharp
using Syncfusion.Blazor;

namespace BlazorApplication
{
    public class Program
    {
        ....
        ....
        public static async Task Main(string[] args)
        {
            ....
            ....
            builder.Services.AddSyncfusionBlazor();
        }
    }
}

```

> To enable custom client side resource loading from CRG or CDN. You need to disable resource loading by **AddSyncfusionBlazor(true)** and load the scripts to the `<head>` element of the **~/wwwroot/index.html** page in Blazor WebAssembly app or **~/Pages/_Host.cshtml** page in Blazor Server app.

```html
<head>
    <script src="https://cdn.syncfusion.com/blazor/{{ site.blazorversion }}/syncfusion-blazor.min.js"></script>
</head>
```

## Adding Dashboard Layout component namespace to the application

Open `~/_Imports.razor` file and import the `Syncfusion.Blazor.Layouts` package.

```cshtml
@using Syncfusion.Blazor.Layouts
```

## Initialize the Dashboard Layout component

It is easy to initialize a dashboard layout component with panel. To render a dashboard layout component with default `Row` and `Column` (Row=0, Column=0) value of panels, refer to the following code section.

### [Pages/Index.razor]

```cshtml

@using Syncfusion.Blazor.Layouts

<SfDashboardLayout>
    <DashboardLayoutPanels>
        <DashboardLayoutPanel>
        </DashboardLayoutPanel>
    </DashboardLayoutPanels>
</SfDashboardLayout>

```

> There is no need to assign default value for panels. Refer to the [Panels](./panels/position-sizing-of-panels/#panels) section to learn about default value.

## Run the application

After successful compilation of your application, simply press `F5` to run the application.

The simple Dashboard panel is rendered with whole dimension of parent element.

![Blazor DashboardLayout Component](images/blazor-dashboard-layout-component.png)

## Defining panels

A dashboard layout can be rendered with multiple panels to design a template with its basic properties.

A dashboard layout panel consists of two sections, which are Header and Content section. `HeaderTemplate` is used to render the Header section and `ContentTemplate` is used to render the content section.

Also, it is easy to interact with the panels by dragging, floating, and resizing functionality of panels.

### Panels with simple data

A dashboard layout panel is rendered with simple data. The header of a panel is defined by `HeaderTemplate` and content of a panel is defined by `ContentTemplate`.

```cshtml
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

```

The Dashboard layout with simple content will be rendered in the web browser as demonstrated in the following screenshot.

![Blazor DashboardLayout with Single Data](images/blazor-dashboard-layout-single-content.png)

### Panels with components

A dashboard layout can be rendered with the components like the chart, grids, maps, gauge, and more as a content of dashboard layout panel.

These complex data (components) are placed as the panel content by assigning the corresponding component element as the `ContentTemplate` of the panel.

```cshtml
@using Syncfusion.Blazor.Layouts
@using Syncfusion.Blazor.Charts
@using Syncfusion.Blazor.Grids

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
                                <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="yMd" Type="ColumnType.Date" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="150"></GridColumn>
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
        public DateTime XValue;
        public double YValue;
        public string X;
        public double Y;
        public string Country;
        public string X1;
        public double Y1;
        public double Y2;
        public double Y3;
        public double Y4;
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
        this.chartObj.Refresh();
        this.linechartObj.Refresh();
        this.barchartObj.Refresh();
    }
 }

<style>
    #linechart, #grid, #chart1, #chart, #range {
        height: 100% !important;
        width: 100% !important;
    }
</style>

```

Output for the Dashboard Layout Complex data (Blazor Components) will be as follows.

![Blazor DashboardLayout displays Chart Component Content](images/blazor-dashboard-layout-with-chart-component.png)

By default, the dashboard layout control is rendered with auto adjustable and [responsive](https://blazor.syncfusion.com/documentation/dashboard-layout/responsive-adaptive/) according to the parent dimensions.

## See Also

* [Getting Started with Syncfusion Blazor for Client-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-dotnet-cli/)

* [Getting Started with Syncfusion Blazor for Client-Side in Visual Studio 2019](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-visual-studio-2019/)

* [Getting Started with Syncfusion Blazor for Server-Side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-dotnet-cli/)