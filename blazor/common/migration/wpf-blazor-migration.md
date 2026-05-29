---
layout: post
title: Migrating Syncfusion WPF Controls to Blazor Components
description: Step-by-step guide to migrate WPF controls to Blazor components on .NET 8+, including setup, configuration, and code examples.
platform: Blazor
component: Common
documentation: ug
---

# Migrating WPF Controls to Blazor Components

Migrating enterprise applications from **[WPF (Windows Presentation Foundation)](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/overview/)** to **[Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/)** involves a significant architectural transition, moving from a rich, XAML-based desktop client framework to a component-driven, cross-platform web framework running on .NET. This guide provides a structured, step-by-step migration approach for **[WPF Controls](https://www.syncfusion.com/wpf-controls)** to their corresponding **[Blazor components](https://www.syncfusion.com/blazor-components)**.

## Why migrate from WPF to Blazor?

| Dimension | WPF | Blazor Web App (Interactive Server) |
|---|---|---|
| Runtime | Windows desktop app on .NET Framework or modern .NET | Web app on .NET with interactive server rendering |
| UI definition | XAML-based UI with code-behind | Razor components with HTML and C# |
| Code-behind / logic | `.xaml.cs` files or view models | `@code { }` blocks or `.razor.cs` partial classes |
| Pattern | MVVM is commonly used | Component-based development is the standard approach |
| Data binding | Uses `DataContext` and view models | Uses component parameters, `@bind`, and cascading values |
| State management | Uses view model state and `INotifyPropertyChanged` | Uses component state and re-rendering |
| Navigation | Uses windows, `Frame`, or region-based navigation | Uses `@page` routing and `NavigationManager` |
| Dependency injection | Often uses external containers | Uses built-in .NET dependency injection |
| Rendering | Uses the native WPF rendering pipeline | Uses interactive rendering in the browser |
| Communication model | In-process desktop interaction | Server interaction over SignalR for interactivity |

## Prerequisites for Blazor

* [.NET 8 SDK or later](https://dotnet.microsoft.com/en-us/download/dotnet)
* [Visual Studio](https://visualstudio.microsoft.com/downloads/) 2022 or later or [Visual Studio Code](https://code.visualstudio.com/) with [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension

## Project structure comparison

WPF and Blazor follow different application models. The following table maps common WPF artifacts to their closest Blazor equivalents and describes their roles in a Blazor application.

| WPF artifact | Blazor equivalent | Description |
|---|---|---|
| `App.xaml` | `Program.cs` and `App.razor` | Defines startup and root rendering |
| `App.xaml.cs` | `Program.cs` | Configures services and host setup |
| `MainWindow.xaml` | `App.razor`, `MainLayout.razor`, and `Routes.razor` | Represents the application shell and routing structure |
| `Views/*.xaml` | `Pages/*.razor` | Defines route-enabled UI pages |
| `ViewModels/*.cs` | Services, component state, or `.razor.cs` | Contains UI logic and state |
| `Models/*.cs` | `Models/*.cs` | Usually reusable without changes |
| `Services/*.cs` | `Services/*.cs` | Handles shared application logic through dependency injection |
| `ResourceDictionary` | CSS, CSS isolation, and static assets | Manages styling and static resources |
| `UserControl` | Razor component (`.razor`) | Reusable UI component |
| `ICommand` and `RelayCommand` | Event handlers, `EventCallback`, component methods, or custom services | Implements user action handling and validation logic in Blazor using event callbacks or service methods |
| `INotifyPropertyChanged` | Component state and re-rendering | Updates the UI when state changes |

## Migrating components from WPF to Blazor

Create a Blazor project using one of the following getting started guides.

* [Getting Started with Blazor Web App](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)
* [Getting Started with Blazor Server App](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)
* [Getting Started with Blazor WebAssembly App](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)

The following shared setup applies to all components and covers the common configuration required before proceeding to the [component-specific migration steps](#component-specific-migration-steps).

### Package installation

In WPF applications, controls are typically installed as individual NuGet packages (for example, [Syncfusion.SfGrid.WPF](https://www.nuget.org/packages/Syncfusion.SfGrid.WPF) and [Syncfusion.SfChart.WPF](https://www.nuget.org/packages/Syncfusion.SfChart.WPF)) and referenced directly in XAML and code-behind.

In Blazor applications, components are also provided as individual NuGet packages (for example, [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid) and [Syncfusion.Blazor.Charts](https://www.nuget.org/packages/Syncfusion.Blazor.Charts)). Installing only the required component packages improves performance and reduces application size.

For the complete list of available packages, refer to the [Blazor NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages).

Additionally, install the [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes) NuGet package at the application level to enable styling.

### Theme and script configuration

In WPF, themes are typically applied using [SfSkinManager](https://help.syncfusion.com/wpf/themes/skin-manager), while additional styling can be managed through `ResourceDictionary` and XAML-based styling. Scripts are not required because rendering happens locally in the desktop runtime.

In Blazor, styles and scripts are delivered as static web assets from NuGet packages. Reference them once at the application level.

For the complete list of supported themes, refer to the [Blazor themes documentation](https://blazor.syncfusion.com/documentation/appearance/themes).

**WPF approach**

{% tabs %}
{% highlight xml tabtitle="MainWindow.xaml" %}

<Window x:Class="GettingStarted.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:syncfusionskin="clr-namespace:Syncfusion.SfSkinManager;assembly=Syncfusion.SfSkinManager.WPF"
        syncfusionskin:SfSkinManager.Theme="FluentLight">
    ...
</Window>

{% endhighlight %}
{% endtabs %}

**Blazor equivalent**

{% tabs %}
{% highlight html tabtitle="App.razor" %}

<head>
    ...
    <!-- Blazor theme stylesheet -->
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
    ...
</head>

<body>
    ...
    <!-- Blazor core script (required for UI components) -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"></script>
</body>

{% endhighlight %}
{% endtabs %}

## Component specific migration steps

### DataGrid

[WPF DataGrid](https://www.syncfusion.com/wpf-controls/datagrid) is a high-performance XAML-based tabular control for desktop applications, while [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) is the web-first Razor component for building responsive, interactive, data-driven web interfaces. 

For additional details, refer to the [WPF DataGrid getting started guide](https://help.syncfusion.com/wpf/datagrid/getting-started) and [Blazor DataGrid getting started guide](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-server-app).

| Aspect | WPF (SfDataGrid) | Blazor (SfGrid) |
|---|---|---|
| Package (NuGet) | [Syncfusion.SfGrid.WPF](https://www.nuget.org/packages/Syncfusion.SfGrid.WPF) | [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid) |
| Component declaration | `<syncfusion:SfDataGrid>` | `<SfGrid>` |
| Data binding | [ItemsSource](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfDataGrid.html#Syncfusion_UI_Xaml_Grid_SfDataGrid_ItemsSource) with `DataContext` or a view model | [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) with component state |
| Collection type | `ObservableCollection<T>` (automatic notifications) | `List<T>` or `IEnumerable<T>` (state updates trigger re-renders) |
| Columns | [GridTextColumn](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.GridTextColumn.html), [GridNumericColumn](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.GridNumericColumn.html), [GridTemplateColumn](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.GridTemplateColumn.html) | [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) with [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field), [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Format), and [EditType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_EditType) |
| Templates | XAML `DataTemplate` | Razor `<Template>` |
| Editing and events | Code-behind events and properties | [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings), [GridEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html), and event callbacks |
| Paging and virtualization | [SfDataPager](https://help.syncfusion.com/wpf/datapager/overview) and native virtualization | [GridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PageSettings), [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization), and [EnableColumnVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableColumnVirtualization) |
| Styling | `ResourceDictionary`, styles, and triggers | CSS, CSS isolation, and callback-based styling |

#### Component rendering

The [WPF DataGrid](https://www.syncfusion.com/wpf-controls/datagrid) control is defined in XAML, with its data collection assigned programmatically using the [ItemsSource](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfDataGrid.html#Syncfusion_UI_Xaml_Grid_SfDataGrid_ItemsSource) property.

The [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) component is declared in Razor markup, and it receives data through the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) parameter.

**WPF approach**

{% tabs %}
{% highlight xml tabtitle="MainWindow.xaml" %}

<Window x:Class="WpfDataGridApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:syncfusion="clr-namespace:Syncfusion.UI.Xaml.Grid;assembly=Syncfusion.SfGrid.WPF"
        Title="Orders" Height="450" Width="800">
    
    <syncfusion:SfDataGrid x:Name="dataGrid"
                           AutoGenerateColumns="False"
                           AllowEditing="True"
                           AddNewRowPosition="Top">
        
        <syncfusion:SfDataGrid.Columns>
            <syncfusion:GridTextColumn MappingName="OrderID"
                                       HeaderText="Order ID"
                                       IsPrimaryKey="True"
                                       Width="100" />
            <syncfusion:GridTextColumn MappingName="CustomerID"
                                       HeaderText="Customer ID"
                                       Width="120" />
            <syncfusion:GridNumericColumn MappingName="Freight"
                                          HeaderText="Freight"
                                          NumberDecimalDigits="2"
                                          Width="100" />
        </syncfusion:SfDataGrid.Columns>
        
    </syncfusion:SfDataGrid>
    
</Window>

{% endhighlight %}
{% highlight cs tabtitle="MainWindow.xaml.cs" %}

using Syncfusion.UI.Xaml.Grid;
using System.Collections.ObjectModel;
using System.Windows;

namespace WpfDataGridApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            dataGrid.ItemsSource = GetOrders();
        }

        private ObservableCollection<Order> GetOrders()
        {
            return new ObservableCollection<Order>
            {
                new Order { OrderID = 10248, CustomerID = "VINET", Freight = 32.38 },
                new Order { OrderID = 10249, CustomerID = "TOMSP", Freight = 11.61 },
                new Order { OrderID = 10250, CustomerID = "HANAR", Freight = 65.83 }
            };
        }
    }

    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public double Freight { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

**Blazor equivalent**

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

@page "/orders"
@rendermode InteractiveServer

<SfGrid DataSource="@Orders">
    <GridEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" IsPrimaryKey="true" Width="100"></GridColumn>
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field="@nameof(Order.Freight)" HeaderText="Freight" Format="N2" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; } = new();
    
    protected override void OnInitialized()
    {
        Orders = new List<Order>
        {
            new Order { OrderID = 10248, CustomerID = "VINET", Freight = 32.38 },
            new Order { OrderID = 10249, CustomerID = "TOMSP", Freight = 11.61 },
            new Order { OrderID = 10250, CustomerID = "HANAR", Freight = 65.83 }
        };
    }
    
    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public double Freight { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

### Charts

[WPF Charts](https://www.syncfusion.com/wpf-controls/charts) is a flexible XAML charting control for rich desktop visualizations, while [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) is the Razor-based component for creating responsive, interactive charts on the web. 

For additional details, refer to the [WPF Charts getting started guide](https://help.syncfusion.com/wpf/charts/getting-started) and [Blazor Charts getting started guide](https://blazor.syncfusion.com/documentation/chart/getting-started).

| Aspect | WPF (SfChart) | Blazor (SfChart) |
|---|---|---|
| Package (NuGet) | [Syncfusion.SfChart.WPF](https://www.nuget.org/packages/Syncfusion.SfChart.WPF) | [Syncfusion.Blazor.Charts](https://www.nuget.org/packages/Syncfusion.Blazor.Charts) |
| Component declaration | `<syncfusion:SfChart>` | `<SfChart>` |
| Data binding | [ItemsSource](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ChartSeriesBase.html#Syncfusion_UI_Xaml_Charts_ChartSeriesBase_ItemsSource) with [XBindingPath](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ChartSeriesBase.html#Syncfusion_UI_Xaml_Charts_ChartSeriesBase_XBindingPath) and [YBindingPath](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.XyDataSeries.html?tabs=tabid-1#Syncfusion_UI_Xaml_Charts_XyDataSeries_YBindingPath) | [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) with [XName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_XName) and [YName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_YName) |
| Axis and series | Nested axis and series elements | [ChartPrimaryXAxis](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartPrimaryXAxis.html), [ChartPrimaryYAxis](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartPrimaryYAxis.html), and [ChartSeriesCollection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesCollection.html) |
| Series types | [ColumnSeries](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ColumnSeries.html), [LineSeries](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.LineSeries.html), and similar series types | [ChartSeries](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html) with `Type="ChartSeriesType.*"` |
| Markers and tooltips | Series-level settings and adornments | [ChartMarker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartMarker.html) and [ChartTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html) |
| Events | CLR events | Event callbacks such as point and tooltip events |
| Responsiveness | Window-based layout | CSS-based responsive layout |

#### Component rendering

The [WPF Chart](https://www.syncfusion.com/wpf-controls/charts) control is defined using nested XAML elements, and data is assigned through the [ItemsSource](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ChartSeriesBase.html#Syncfusion_UI_Xaml_Charts_ChartSeriesBase_ItemsSource) property using binding paths for the X and Y values.

The [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) component is declared in Razor markup, with axes and series configured using child components, and data supplied through the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) parameter.

**WPF approach**

{% tabs %}
{% highlight xml tabtitle="MainWindow.xaml" %}

<Window x:Class="WpfChart.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:syncfusion="http://schemas.syncfusion.com/wpf"
        Title="Sales Analysis" Height="450" Width="800">

    <syncfusion:SfChart Header="Sales Analysis">

        <syncfusion:SfChart.PrimaryAxis>
            <syncfusion:CategoryAxis Header="Month" />
        </syncfusion:SfChart.PrimaryAxis>

        <syncfusion:SfChart.SecondaryAxis>
            <syncfusion:NumericalAxis Header="Sales" />
        </syncfusion:SfChart.SecondaryAxis>

        <syncfusion:SfChart.Legend>
            <syncfusion:ChartLegend Visibility="Visible" />
        </syncfusion:SfChart.Legend>

        <syncfusion:ColumnSeries ItemsSource="{Binding SalesData}"
                                 XBindingPath="Month"
                                 YBindingPath="Sales"
                                 Label="Sales 2024"
                                 ShowTooltip="True">
            <syncfusion:ColumnSeries.AdornmentsInfo>
                <syncfusion:ChartAdornmentInfo ShowMarker="True" 
                                               Symbol="Circle"
                                               SymbolInterior="White"
                                               SymbolStroke="{Binding Interior, RelativeSource={RelativeSource Mode=Self}}" />
            </syncfusion:ColumnSeries.AdornmentsInfo>
        </syncfusion:ColumnSeries>

    </syncfusion:SfChart>

</Window>

{% endhighlight %}
{% highlight cs tabtitle="MainWindow.xaml.cs" %}

using Syncfusion.UI.Xaml.Charts;
using System.Collections.ObjectModel;
using System.Windows;

namespace WpfChart
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<SalesInfo> SalesData { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            SalesData = new ObservableCollection<SalesInfo>
            {
                new SalesInfo { Month = "Jan", Sales = 35 },
                new SalesInfo { Month = "Feb", Sales = 28 },
                new SalesInfo { Month = "Mar", Sales = 34 },
                new SalesInfo { Month = "Apr", Sales = 32 },
                new SalesInfo { Month = "May", Sales = 40 }
            };
            DataContext = this;
        }
    }

    public class SalesInfo
    {
        public string Month { get; set; }
        public double Sales { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

**Blazor equivalent**

{% tabs %}
{% highlight razor tabtitle="Sales.razor" %}

@page "/sales"
@rendermode InteractiveServer

<SfChart Title="Sales Analysis">
    <ChartPrimaryXAxis Title="Month" ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartPrimaryYAxis Title="Sales"></ChartPrimaryYAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesData" 
                     XName="Month" 
                     YName="Sales" 
                     Type="ChartSeriesType.Column"
                     Name="Sales 2024">
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
    <ChartLegendSettings Visible="true"></ChartLegendSettings>
    <ChartTooltipSettings Enable="true"></ChartTooltipSettings>
</SfChart>

@code {
    public List<SalesInfo> SalesData { get; set; } = new();
    
    protected override void OnInitialized()
    {
        SalesData = new List<SalesInfo>
        {
            new SalesInfo { Month = "Jan", Sales = 35 },
            new SalesInfo { Month = "Feb", Sales = 28 },
            new SalesInfo { Month = "Mar", Sales = 34 },
            new SalesInfo { Month = "Apr", Sales = 32 },
            new SalesInfo { Month = "May", Sales = 40 }
        };
    }
    
    public class SalesInfo
    {
        public string Month { get; set; }
        public double Sales { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

### Scheduler

[WPF Scheduler](https://www.syncfusion.com/wpf-controls/scheduler) is a feature-rich desktop scheduling control for managing appointments and resources, while [Blazor Scheduler](https://www.syncfusion.com/blazor-components/blazor-scheduler) is the Blazor component designed for calendar and scheduling scenarios in web applications. 

For additional details, refer to the [WPF Scheduler getting started guide](https://help.syncfusion.com/wpf/scheduler/getting-started) and [Blazor Scheduler getting started guide](https://blazor.syncfusion.com/documentation/scheduler/getting-started-with-server-app).

| Aspect | WPF (SfScheduler) | Blazor (SfSchedule<TValue>) |
|---|---|---|
| Package (NuGet) | [Syncfusion.SfScheduler.WPF](https://www.nuget.org/packages/Syncfusion.SfScheduler.WPF) | [Syncfusion.Blazor.Schedule](https://www.nuget.org/packages/Syncfusion.Blazor.Schedule) |
| Component declaration | `<syncfusion:SfScheduler>` | `<SfSchedule TValue="TModel">` |
| Appointment model | Built-in [ScheduleAppointment](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Scheduler.ScheduleAppointment.html) | Custom model mapped with [ScheduleEventSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEventSettings-1.html) |
| View configuration | [ViewType](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Scheduler.SfScheduler.html#Syncfusion_UI_Xaml_Scheduler_SfScheduler_ViewType) | [ScheduleViews](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleViews.html) and [ScheduleView](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleView.html) |
| Date and time binding | [DisplayDate](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Scheduler.SfScheduler.html#Syncfusion_UI_Xaml_Scheduler_SfScheduler_DisplayDate) and related properties | [SelectedDate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.SfSchedule-1.html#Syncfusion_Blazor_Schedule_SfSchedule_1_SelectedDate) and `CurrentDate` |
| Data source | [ItemsSource](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Scheduler.SfScheduler.html#Syncfusion_UI_Xaml_Scheduler_SfScheduler_ItemsSource) | [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEventSettings-1.html#Syncfusion_Blazor_Schedule_ScheduleEventSettings_1_DataSource) |
| Resources and grouping | [ResourceCollection](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Scheduler.SfScheduler.html#Syncfusion_UI_Xaml_Scheduler_SfScheduler_ResourceCollection) with mappings | [ScheduleResources](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleResources.html) and [ScheduleResource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleResource-2.html) |
| Events | CLR events | Event callbacks such as action and cell events |
| Large data handling | Native desktop behavior | Virtualization and lazy loading are commonly used |

#### Component rendering

The [WPF Scheduler](https://www.syncfusion.com/wpf-controls/scheduler) control is defined in XAML, with the active view and display date configured through properties, and appointments are assigned programmatically using the [ItemsSource](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Scheduler.SfScheduler.html#Syncfusion_UI_Xaml_Scheduler_SfScheduler_ItemsSource) property.

The [Blazor Scheduler](https://www.syncfusion.com/blazor-components/blazor-scheduler) component is declared in Razor markup, where views are configured using child components, and appointment data is supplied through the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEventSettings-1.html#Syncfusion_Blazor_Schedule_ScheduleEventSettings_1_DataSource) parameter.

**WPF approach**

{% tabs %}
{% highlight xml tabtitle="MainWindow.xaml" %}

<Window x:Class="WpfScheduler.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:syncfusion="clr-namespace:Syncfusion.UI.Xaml.Scheduler;assembly=Syncfusion.SfScheduler.WPF"
        Title="Scheduler" Height="650" Width="1000">

    <syncfusion:SfScheduler x:Name="scheduler"
                            ViewType="Week"
                            DisplayDate="{Binding CurrentDate, Mode=TwoWay}" />

</Window>

{% endhighlight %}
{% highlight cs tabtitle="MainWindow.xaml.cs" %}

using Syncfusion.UI.Xaml.Scheduler;
using System;
using System.Windows;

namespace WpfScheduler
{
    public partial class MainWindow : Window
    {
        public DateTime CurrentDate { get; set; } = DateTime.Today;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            // Create appointments
            scheduler.ItemsSource = new SchedulerAppointmentCollection
            {
                new ScheduleAppointment
                {
                    Subject = "Project Meeting",
                    StartTime = DateTime.Today.AddHours(10),
                    EndTime = DateTime.Today.AddHours(11),
                    AppointmentBackground = System.Windows.Media.Brushes.LightBlue
                },
                new ScheduleAppointment
                {
                    Subject = "Client Call",
                    StartTime = DateTime.Today.AddHours(14),
                    EndTime = DateTime.Today.AddHours(15),
                    AppointmentBackground = System.Windows.Media.Brushes.LightGreen
                }
            };
        }
    }
}

{% endhighlight %}
{% endtabs %}

**Blazor equivalent**

{% tabs %}
{% highlight razor tabtitle="Calendar.razor" %}

@page "/calendar"
@rendermode InteractiveServer

<SfSchedule TValue="Meeting" Height="650px" @bind-SelectedDate="@CurrentDate">
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
    </ScheduleViews>
    <ScheduleEventSettings DataSource="@Appointments"></ScheduleEventSettings>
</SfSchedule>

@code {
    private DateTime CurrentDate = DateTime.Today;
    public List<Meeting> Appointments { get; set; } = new();
    
    protected override void OnInitialized()
    {
        Appointments = new List<Meeting>
        {
            new Meeting 
            { 
                Id = 1,
                Subject = "Project Meeting", 
                StartTime = DateTime.Today.AddHours(10), 
                EndTime = DateTime.Today.AddHours(11)
            },
            new Meeting 
            { 
                Id = 2,
                Subject = "Client Call", 
                StartTime = DateTime.Today.AddHours(14), 
                EndTime = DateTime.Today.AddHours(15)
            }
        };
    }
    
    public class Meeting
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

## Run the application

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the Blazor application.

Alternatively, run the application using the following .NET CLI command from the project root directory.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet run

{% endhighlight %}
{% endtabs %}

## See also

- [Getting started with Blazor DataGrid](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-server-app)
- [Getting started with Blazor TreeGrid](https://blazor.syncfusion.com/documentation/treegrid/getting-started-with-server-app)
- [Getting started with Blazor Charts](https://blazor.syncfusion.com/documentation/chart/getting-started)
- [Getting started with Blazor Scheduler](https://blazor.syncfusion.com/documentation/scheduler/getting-started-with-server-app)
- [Getting started with Blazor Diagram](https://blazor.syncfusion.com/documentation/diagram/getting-started)
- [Getting started with Blazor RichTextEditor](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started-with-server-app)

 