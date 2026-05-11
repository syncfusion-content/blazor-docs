---
layout: post
title: Migrating Syncfusion WPF Components to Blazor
description: Guide to migrate Syncfusion WPF controls to Syncfusion Blazor components on .NET 8+, with setup, config, and examples.
platform: Blazor
component: Common
documentation: ug
---

# Migrating Syncfusion® WPF Components to Blazor

Migrating enterprise applications from **[WPF (Windows Presentation Foundation)](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/overview/)** to **[Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/)** involves a significant architectural transition, moving from a rich, XAML-based desktop client framework to a component-driven, cross-platform web framework running on .NET. This guide provides a structured, step-by-step migration path for **[Syncfusion WPF components](https://www.syncfusion.com/wpf-controls)** to their **[Syncfusion Blazor equivalents](https://www.syncfusion.com/blazor-components)** using **[Visual Studio](https://visualstudio.microsoft.com/vs/)** or **[Visual Studio Code](https://code.visualstudio.com/)**.

It focuses on key architectural differences and demonstrates the essential setup and rendering patterns required to successfully migrate major Syncfusion UI components from WPF to Blazor.

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

## Development environment setup

### Prerequisites for Blazor

* [.NET 8 SDK or later](https://dotnet.microsoft.com/en-us/download/dotnet)
* [Visual Studio](https://visualstudio.microsoft.com/vs/)
* [Visual Studio Code](https://code.visualstudio.com/) with [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension

**Verify installation:**

Run the following commands to verify that the installed .NET SDK version is 8.0 or later and that Blazor project templates are available.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet --version   # Print installed .NET SDK version (should be 8.0 or later)
dotnet new list blazor   # List available/installed Blazor project templates

{% endhighlight %}
{% endtabs %}

N> This guide is tested with .NET 8.0 and later versions. Ensure that your installed SDK version is 8.0 or higher.

## Project structure comparison

WPF and Blazor use different application models. The table below shows the closest functional equivalents, not a strict one-to-one match.

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
| `ICommand` and `RelayCommand` | Event handlers, `EventCallback`, or injected services | Handles user actions and command logic |
| `INotifyPropertyChanged` | Component state and re-rendering | Updates the UI when state changes |

## Creating a Blazor Web App with Interactive Server in Visual Studio Code

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet new blazor -n MyBlazorApp --interactivity Server
cd MyBlazorApp
code .
dotnet watch   # Hot reload during development

{% endhighlight %}
{% endtabs %}

N> The `--interactivity Server` flag configures SignalR-based interactivity and provides behavior similar to WPF's immediate UI update model, but over the network.

## Migrating key Syncfusion components from WPF to Blazor

The following shared setup applies to all six Syncfusion components and covers the common configuration required before moving on to the [component-specific migration steps](./wpf-blazor-migration#1-datagrid).
 
### Common package installation

Use the following commands to install the required packages for each component.

| Component | WPF package command | Blazor package command |
|---|---|---|
| DataGrid | `dotnet add package Syncfusion.SfGrid.WPF` | `dotnet add package Syncfusion.Blazor.Grid -v {{ site.releaseversion }}` |
| TreeGrid | `dotnet add package Syncfusion.SfGrid.WPF` | `dotnet add package Syncfusion.Blazor.TreeGrid -v {{ site.releaseversion }}` |
| Charts | `dotnet add package Syncfusion.SfChart.WPF` | `dotnet add package Syncfusion.Blazor.Charts -v {{ site.releaseversion }}` |
| Scheduler | `dotnet add package Syncfusion.SfScheduler.WPF` | `dotnet add package Syncfusion.Blazor.Schedule -v {{ site.releaseversion }}` |
| Diagram | `dotnet add package Syncfusion.SfDiagram.WPF` | `dotnet add package Syncfusion.Blazor.Diagram -v {{ site.releaseversion }}` |
| RichTextEditor | `dotnet add package Syncfusion.SfRichTextBoxAdv.WPF` | `dotnet add package Syncfusion.Blazor.RichTextEditor -v {{ site.releaseversion }}` |
| Themes | — | `dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}` |

N> Install `Syncfusion.Blazor.Themes` once at the application level. This package is required for the Blazor components used in this migration guide.

### Script and theme configuration

Use the same Blazor theme and script setup for all migrated components.

{% tabs %}
{% highlight razor tabtitle="App.razor" %}

<head>
    ...
    <!-- Syncfusion theme stylesheet -->
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
    ...
</head>

<body>
    ...
    <!-- Syncfusion Blazor core script (required for most UI components) -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>

{% endhighlight %}
{% endtabs %}

### Blazor service registration

Register Syncfusion services once for all six components.

{% tabs %}
{% highlight C# tabtitle="Program.cs" %}
...
using Syncfusion.Blazor;
...
builder.Services.AddSyncfusionBlazor();
...
{% endhighlight %}
{% endtabs %}

### Namespace imports

Add the following namespaces to `_Imports.razor` so the Syncfusion Blazor components are available throughout the application.

| Component | Required namespaces |
|---|---|
| DataGrid | `@using Syncfusion.Blazor`<br>`@using Syncfusion.Blazor.Grids` |
| TreeGrid | `@using Syncfusion.Blazor`<br>`@using Syncfusion.Blazor.TreeGrid` |
| Charts | `@using Syncfusion.Blazor`<br>`@using Syncfusion.Blazor.Charts` |
| Scheduler | `@using Syncfusion.Blazor`<br>`@using Syncfusion.Blazor.Schedule` |
| Diagram | `@using Syncfusion.Blazor`<br>`@using Syncfusion.Blazor.Diagram` |
| RichTextEditor | `@using Syncfusion.Blazor`<br>`@using Syncfusion.Blazor.RichTextEditor` |

### 1. DataGrid

For detailed explanation, refer to the [WPF DataGrid getting started guide](https://help.syncfusion.com/wpf/datagrid/getting-started) and [Blazor DataGrid getting started guide](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-server-app).

#### Migration overview

| Aspect | WPF (SfDataGrid) | Blazor (SfGrid) |
|---|---|---|
| Namespace | `Syncfusion.UI.Xaml.Grid` | `Syncfusion.Blazor.Grids` |
| Component declaration | `<syncfusion:SfDataGrid>` | `<SfGrid>` |
| Data binding | `ItemsSource` with `DataContext` or a view model | `DataSource` with component state |
| Collection type | `ObservableCollection<T>` is commonly used | `List<T>` or `IEnumerable<T>` is commonly used |
| Columns | `GridTextColumn`, `GridNumericColumn`, `GridTemplateColumn` | `GridColumn` with `Field`, `Format`, and `EditType` |
| Templates | XAML `DataTemplate` | Razor `<Template>` |
| Editing and events | Code-behind events and properties | `GridEditSettings`, `GridEvents`, and event callbacks |
| Paging and virtualization | `SfDataPager` and native virtualization | `GridPageSettings`, `EnableVirtualization`, and `EnableColumnVirtualization` |
| Styling | `ResourceDictionary`, styles, and triggers | CSS, CSS isolation, and callback-based styling |

#### Component rendering

Render the DataGrid and configure the required columns.

In WPF, the DataGrid control is defined in XAML and the data collection is assigned programmatically using the [ItemsSource](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfDataGrid.html#Syncfusion_UI_Xaml_Grid_SfDataGrid_ItemsSource) property.

In Blazor, the DataGrid component is declared in Razor markup and receives its data through the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) parameter.

**WPF approach (MainWindow.xaml):**

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

**Blazor equivalent (Orders.razor):**

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

### 2. TreeGrid

For detailed explanation, refer to the [WPF TreeGrid getting started guide](https://help.syncfusion.com/wpf/treegrid/getting-started) and [Blazor TreeGrid getting started guide](https://blazor.syncfusion.com/documentation/treegrid/getting-started-with-server-app).

#### Migration overview

| Aspect | WPF (SfTreeGrid) | Blazor (SfTreeGrid) |
|---|---|---|
| Namespace | `Syncfusion.UI.Xaml.TreeGrid` | `Syncfusion.Blazor.TreeGrid` |
| Component declaration | `<syncfusion:SfTreeGrid>` | `<SfTreeGrid>` |
| Data structure | Nested collections or self-referencing flat data | Self-referencing flat data is the common approach |
| Hierarchy mapping | `ChildPropertyName`, `ParentPropertyName`, and `SelfRelationRootValue` | `IdMapping` and `ParentIdMapping` |
| Tree column | Built-in hierarchical display | `TreeColumnIndex` |
| Columns | `TreeGridTextColumn`, `TreeGridNumericColumn` | `TreeGridColumn` |
| Templates | XAML templates | Razor templates |
| Events | WPF routed events and CLR events | `GridEvents` and event callbacks |
| Performance | Native desktop rendering | Virtual scrolling and load-on-demand |

#### Component rendering

Render the TreeGrid and configure the required columns to display hierarchical data using a self-referencing data structure.

In WPF, the TreeGrid control is defined in XAML, and the hierarchical data collection is assigned programmatically using the [ItemsSource](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.TreeGrid.SfTreeGrid.html#Syncfusion_UI_Xaml_TreeGrid_SfTreeGrid_ItemsSource) property along with parent-child mapping properties.

In Blazor, the TreeGrid component is declared in Razor markup and receives its hierarchical data through the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_DataSource) parameter, using [IdMapping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_IdMapping) and [ParentIdMapping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_ParentIdMapping) to establish relationships.

**WPF approach (MainWindow.xaml):**

{% tabs %}
{% highlight xml tabtitle="MainWindow.xaml" %}

<Window x:Class="WpfTreeGridApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:syncfusion="clr-namespace:Syncfusion.UI.Xaml.TreeGrid;assembly=Syncfusion.SfGrid.WPF"
        Title="Tree Grid - Tasks" Height="450" Width="800">

    <syncfusion:SfTreeGrid x:Name="treeGrid"
                           AutoGenerateColumns="False"
                           ChildPropertyName="TaskID"
                           ParentPropertyName="ParentID"
                           SelfRelationRootValue="-1"
                           AllowEditing="True"
                           AddNewRowPosition="Top">

        <syncfusion:SfTreeGrid.Columns>
            <syncfusion:TreeGridTextColumn MappingName="TaskID"
                                           HeaderText="Task ID"
                                           IsPrimaryKey="True"
                                           Width="100" />
            <syncfusion:TreeGridTextColumn MappingName="TaskName"
                                           HeaderText="Task Name"
                                           Width="200" />
            <syncfusion:TreeGridNumericColumn MappingName="Duration"
                                              HeaderText="Duration"
                                              Width="100" />
        </syncfusion:SfTreeGrid.Columns>

    </syncfusion:SfTreeGrid>

</Window>

{% endhighlight %}
{% highlight cs tabtitle="MainWindow.xaml.cs" %}

using Syncfusion.UI.Xaml.TreeGrid;
using System.Collections.ObjectModel;
using System.Windows;

namespace WpfTreeGridApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            treeGrid.ItemsSource = GetTaskData();
        }

        private ObservableCollection<TaskInfo> GetTaskData()
        {
            return new ObservableCollection<TaskInfo>
            {
                new TaskInfo { TaskID = 1, TaskName = "Planning", Duration = 5, ParentID = -1 },
                new TaskInfo { TaskID = 2, TaskName = "Plan timeline", Duration = 3, ParentID = 1 },
                new TaskInfo { TaskID = 3, TaskName = "Plan budget", Duration = 2, ParentID = 1 },
                new TaskInfo { TaskID = 4, TaskName = "Development", Duration = 10, ParentID = -1 },
                new TaskInfo { TaskID = 5, TaskName = "Implementation", Duration = 7, ParentID = 4 }
            };
        }
    }

    public class TaskInfo
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public int Duration { get; set; }
        public int ParentID { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

**Blazor equivalent (Employees.razor):**

{% tabs %}
{% highlight razor tabtitle="Employees.razor" %}

@page "/employees"
@rendermode InteractiveServer

<SfTreeGrid DataSource="@TreeData" IdMapping="TaskID" ParentIdMapping="ParentID" TreeColumnIndex="1">
    <TreeGridEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true"></TreeGridEditSettings>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskID" HeaderText="Task ID" Width="100" IsPrimaryKey="true"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="200"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code {
    public List<TaskInfo> TreeData { get; set; } = new();
    
    protected override void OnInitialized()
    {
        TreeData = new List<TaskInfo>
        {
            new TaskInfo { TaskID = 1, TaskName = "Planning", Duration = 5, ParentID = null },
            new TaskInfo { TaskID = 2, TaskName = "Plan timeline", Duration = 3, ParentID = 1 },
            new TaskInfo { TaskID = 3, TaskName = "Plan budget", Duration = 2, ParentID = 1 },
            new TaskInfo { TaskID = 4, TaskName = "Development", Duration = 10, ParentID = null },
            new TaskInfo { TaskID = 5, TaskName = "Implementation", Duration = 7, ParentID = 4 }
        };
    }
    
    public class TaskInfo
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public int Duration { get; set; }
        public int? ParentID { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

### 3. Charts

For detailed explanation, refer to the [WPF Charts getting started guide](https://help.syncfusion.com/wpf/charts/getting-started) and [Blazor Charts getting started guide](https://blazor.syncfusion.com/documentation/chart/getting-started).

#### Migration overview

| Aspect | WPF (SfChart) | Blazor (SfChart) |
|---|---|---|
| Namespace | `Syncfusion.UI.Xaml.Charts` | `Syncfusion.Blazor.Charts` |
| Component declaration | `<syncfusion:SfChart>` | `<SfChart>` |
| Data binding | `ItemsSource` with `XBindingPath` and `YBindingPath` | `DataSource` with `XName` and `YName` |
| Axis and series | Nested axis and series elements | `ChartPrimaryXAxis`, `ChartPrimaryYAxis`, and `ChartSeriesCollection` |
| Series types | `ColumnSeries`, `LineSeries`, and similar series types | `ChartSeries` with `Type="ChartSeriesType.*"` |
| Markers and tooltips | Series-level settings and adornments | `ChartMarker` and `ChartTooltipSettings` |
| Events | CLR events | Event callbacks such as point and tooltip events |
| Responsiveness | Window-based layout | CSS-based responsive layout |

#### Component rendering

Render the chart and configure the required axes, series, and visualization settings.

In WPF, the Chart control is defined using nested XAML elements, and data is assigned through the [ItemsSource](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ChartSeriesBase.html#Syncfusion_UI_Xaml_Charts_ChartSeriesBase_ItemsSource) property using binding paths for the X and Y values.

In Blazor, the Chart component is declared in Razor markup, with axes and series configured using child components, and data supplied through the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) parameter.

**WPF approach (MainWindow.xaml):**

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

**Blazor equivalent (Sales.razor):**

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

### 4. Scheduler

For detailed explanation, refer to the [WPF Scheduler getting started guide](https://help.syncfusion.com/wpf/scheduler/getting-started) and [Blazor Scheduler getting started guide](https://blazor.syncfusion.com/documentation/scheduler/getting-started-with-server-app?tabcontent=visual-studio-code).

#### Migration overview

| Aspect | WPF (SfScheduler) | Blazor (SfSchedule<TValue>) |
|---|---|---|
| Namespace | `Syncfusion.UI.Xaml.Scheduler` | `Syncfusion.Blazor.Schedule` |
| Component declaration | `<syncfusion:SfScheduler>` | `<SfSchedule TValue="TModel">` |
| Appointment model | Built-in `ScheduleAppointment` | Custom model mapped with `ScheduleEventSettings` |
| View configuration | `ViewType` | `ScheduleViews` and `ScheduleView` |
| Date and time binding | `DisplayDate` and related properties | `SelectedDate` and `CurrentDate` |
| Data source | `ItemsSource` | `DataSource` |
| Resources and grouping | `ResourceCollection` with mappings | `ScheduleResources` and `ScheduleResource` |
| Events | CLR events | Event callbacks such as action and cell events |
| Large data handling | Native desktop behavior | Virtualization and lazy loading are commonly used |

#### Component rendering

Render the Scheduler and configure the required views, date settings, and appointment data.

In WPF, the Scheduler control is defined in XAML, with the active view and display date configured through properties, and appointments assigned programmatically using the [ItemsSource](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Scheduler.SfScheduler.html#Syncfusion_UI_Xaml_Scheduler_SfScheduler_ItemsSource) property.

In Blazor, the Scheduler component is declared in Razor markup, views are configured using child components, and appointment data is supplied through the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEventSettings-1.html#Syncfusion_Blazor_Schedule_ScheduleEventSettings_1_DataSource) parameter.

**WPF approach (MainWindow.xaml):**

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

**Blazor equivalent (Calendar.razor):**

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

### 5. Diagram

For detailed explanation, refer to the [WPF Diagram getting started guide](https://help.syncfusion.com/wpf/diagram/getting-started) and [Blazor Diagram getting started guide](https://blazor.syncfusion.com/documentation/diagram/getting-started).

#### Migration overview

| Aspect | WPF (SfDiagram) | Blazor (SfDiagramComponent) |
|---|---|---|
| Namespace | `Syncfusion.UI.Xaml.Diagram` | `Syncfusion.Blazor.Diagram` |
| Component declaration | `<syncfusion:SfDiagram>` | `<SfDiagramComponent>` |
| Element model | `NodeCollection` and `ConnectorCollection` | `DiagramObjectCollection<Node>` and `DiagramObjectCollection<Connector>` |
| Positioning | `OffsetX`, `OffsetY`, `UnitWidth`, and `UnitHeight` | `OffsetX`, `OffsetY`, `Width`, and `Height` |
| Data binding | XAML-based configuration and data mapping | Component parameters and programmatic configuration |
| Layouts | `LayoutManager` settings | `LayoutType` and layout options |
| Ports and constraints | Declared in XAML | Configured in code with ports and constraints |
| Events | Routed events and CLR events | Event callbacks |
| Save and load | Built-in diagram persistence | Component methods for persistence |

#### Component rendering

Render the Diagram component and define its visual elements, such as nodes and connectors.

In WPF, the Diagram control is declared in XAML, with nodes and connectors defined using nested collections.

In Blazor, the Diagram component is declared in Razor markup, and nodes and connectors are created programmatically and supplied through component parameters.

**WPF approach (MainWindow.xaml):**

{% tabs %}
{% highlight xml tabtitle="MainWindow.xaml" %}

<Window x:Class="WpfDiagram.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:syncfusion="http://schemas.syncfusion.com/wpf"
        Title="Diagram" Height="600" Width="1000">

    <syncfusion:SfDiagram x:Name="diagram">
        <syncfusion:SfDiagram.Nodes>
            <syncfusion:NodeCollection>
                <syncfusion:NodeViewModel ID="node1" 
                                          UnitHeight="60" 
                                          UnitWidth="100"
                                          OffsetX="100" 
                                          OffsetY="100" />
                <syncfusion:NodeViewModel ID="node2" 
                                          UnitHeight="60" 
                                          UnitWidth="100"
                                          OffsetX="300" 
                                          OffsetY="100" />
            </syncfusion:NodeCollection>
        </syncfusion:SfDiagram.Nodes>
        
        <syncfusion:SfDiagram.Connectors>
            <syncfusion:ConnectorCollection>
                <syncfusion:ConnectorViewModel SourceNodeID="node1" 
                                               TargetNodeID="node2" />
            </syncfusion:ConnectorCollection>
        </syncfusion:SfDiagram.Connectors>
    </syncfusion:SfDiagram>

</Window>

{% endhighlight %}
{% highlight cs tabtitle="MainWindow.xaml.cs" %}

using Syncfusion.UI.Xaml.Diagram;
using System.Windows;

namespace WpfDiagram
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
    }
}

{% endhighlight %}
{% endtabs %}

**Blazor equivalent (Flow.razor):**

{% tabs %}
{% highlight razor tabtitle="Flow.razor" %}

@page "/flow"
@rendermode InteractiveServer

<SfDiagramComponent Height="600px" Width="100%" Nodes="@nodes" Connectors="@connectors">
</SfDiagramComponent>

@code {
    private DiagramObjectCollection<Node> nodes;
    private DiagramObjectCollection<Connector> connectors;
    
    protected override void OnInitialized()
    {
        nodes = new DiagramObjectCollection<Node>();
        connectors = new DiagramObjectCollection<Connector>();

        Node node1 = new Node()
        {
            ID = "node1",
            Height = 60,
            Width = 100,
            OffsetX = 100,
            OffsetY = 100
        };
        
        Node node2 = new Node()
        {
            ID = "node2",
            Height = 60,
            Width = 100,
            OffsetX = 300,
            OffsetY = 100
        };
        nodes.Add(node1);
        nodes.Add(node2);

        Connector connector1 = new Connector()
        {
            ID = "connector1",
            SourceID = "node1",
            TargetID = "node2"
        };
        connectors.Add(connector1);
    }
}

{% endhighlight %}
{% endtabs %}

### 6. RichTextEditor

For detailed explanation, refer to the [WPF RichTextBox getting started guide](https://help.syncfusion.com/document-processing/word/word-processor/wpf/getting-started) and [Blazor RichTextEditor getting started guide](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started-with-server-app).

#### Migration overview

| Aspect | WPF (SfRichTextBoxAdv) | Blazor (SfRichTextEditor) |
|---|---|---|
| Namespace | `Syncfusion.Windows.Controls.RichTextBoxAdv` | `Syncfusion.Blazor.RichTextEditor` |
| Component declaration | `<syncfusion:SfRichTextBoxAdv>` | `<SfRichTextEditor>` |
| Content model | Document-based content | HTML string content |
| Data binding | Stream-based load and save | `Value` and `@bind-Value` |
| Toolbar | Ribbon-style and command-based UI | `ToolbarSettings` with toolbar items |
| Templates | WPF control templates and commands | Razor templates and component content |
| Import and export | Native document formats | HTML-based content with conversion options |
| Events | CLR and routed events | Event callbacks |

N> WPF `SfRichTextBoxAdv` uses a native document object model for Word-like documents. Blazor `SfRichTextEditor` uses HTML as its content format. If your WPF app relies on complex DOCX features (sections, headers/footers, advanced styles), you may need server-side conversion or alternative components.

#### Component rendering

Render the RichTextEditor and configure its editing surface for rich text content.

In WPF, the RichTextEditor control is declared directly in XAML, and the initial content is loaded programmatically using a stream.

In Blazor, the RichTextEditor component is declared in Razor markup, and the editor content is initialized and synchronized using two-way binding with the [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_Value) property.

**WPF approach (MainWindow.xaml):**

{% tabs %}
{% highlight xml tabtitle="MainWindow.xaml" %}

<Window x:Class="WpfRichTextEditor.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:syncfusion="clr-namespace:Syncfusion.Windows.Controls.RichTextBoxAdv;assembly=Syncfusion.SfRichTextBoxAdv.WPF"
        Title="RichTextEditor" Height="500" Width="800">

    <Grid>
        <syncfusion:SfRichTextBoxAdv x:Name="richTextBoxAdv"
                                     LayoutType="Continuous" />
    </Grid>
</Window>

{% endhighlight %}
{% highlight cs tabtitle="MainWindow.xaml.cs" %}

using Syncfusion.Windows.Controls.RichTextBoxAdv;
using System.IO;
using System.Text;
using System.Windows;

namespace WpfRichTextEditor
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            LoadInitialContent();
        }

        private void LoadInitialContent()
        {
            string htmlContent =
                "<p><b>Welcome!</b> Start editing your document here...</p>";

            using (MemoryStream stream =
                   new MemoryStream(Encoding.UTF8.GetBytes(htmlContent)))
            {
                richTextBoxAdv.Load(stream, FormatType.Html);
            }
        }
    }
}

{% endhighlight %}
{% endtabs %}

**Blazor equivalent (Editor.razor):**

{% tabs %}
{% highlight razor tabtitle="Editor.razor" %}

@page "/editor"
@rendermode InteractiveServer

<SfRichTextEditor @bind-Value="@HtmlContent" Height="500px">
</SfRichTextEditor>

@code {
    private string HtmlContent { get; set; } = "<p><b>Welcome!</b> Start editing your document here...</p>";
}

{% endhighlight %}
{% endtabs %}

## See also

- [Blazor DataGrid Demos](https://blazor.syncfusion.com/demos/datagrid/overview?theme=fluent2)
- [Blazor TreeGrid Demos](https://blazor.syncfusion.com/demos/tree-grid/overview?theme=fluent2)
- [Blazor Chart Demos](https://blazor.syncfusion.com/demos/chart/overview?theme=fluent2)
- [Blazor Scheduler Demos](https://blazor.syncfusion.com/demos/scheduler/overview?theme=fluent2)
- [Blazor RichTextEditor Demos](https://blazor.syncfusion.com/demos/rich-text-editor/overview)
- [Blazor Diagram Demos](https://blazor.syncfusion.com/demos/diagram/flowchart)
 