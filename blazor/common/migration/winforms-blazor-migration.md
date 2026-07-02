---
layout: post
title: Migrating from Windows Forms (WinForms) to Blazor App | Syncfusion®
description: Step-by-step guide to migrate a WinForms app to Blazor, covering architecture, project setup, theming, service registration, and component mapping.
platform: Blazor
control: Common
documentation: ug
---

# Migrating from Windows Forms to Blazor

Migrating enterprise applications from [Windows Forms (WinForms)](https://learn.microsoft.com/en-us/dotnet/desktop/winforms/overview/) to [Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-10.0) involves a significant architectural shift, transitioning from a traditional event driven desktop UI framework to a modern, component based web framework running on .NET. This guide provides a structured, step-by-step migration approach for [WinForms controls](https://www.syncfusion.com/winforms-ui-controls) to their corresponding [Blazor components](https://www.syncfusion.com/blazor-components) with the **Blazor Web App (Interactive Server)** rendering mode.

## Why Migrate from WinForms to Blazor?

| Aspect | WinForms | Blazor | Benefit of Migration |
|---|---|---|---|
| Platform Support | Windows only | Web, Desktop, Cloud, Cross platform | Application accessible from any browser or device |
| UI Technology | Legacy desktop UI | Modern web based UI | Improved look and user experience |
| Architecture | Form centric, tightly coupled | Component based, modular | Better maintainability and scalability |
| Deployment | Requires local installation | Runs in a web browser | No client side installation required |
| Development Model | Event driven programming | Data binding and reactive UI | Cleaner and more readable code |
| Responsiveness | Fixed desktop layouts | Responsive web layouts | Works across different screen sizes |
| Maintenance | Hard to extend and update | Easy to maintain and enhance | Lower long term maintenance effort |
| Cloud Readiness | Minimal support | Designed for cloud deployment | Enables modern hosting scenarios |
| Code Reusability | Low reusability | High reusability via components and services | Faster development and testing |
| Future Support | Limited continued development | Actively developed framework | Long term application sustainability |

## Prerequisites for Blazor

* [.NET 8 SDK or later](https://dotnet.microsoft.com/en-us/download/dotnet)
* [Visual Studio](https://visualstudio.microsoft.com/downloads/) 2022 or later or [Visual Studio Code](https://code.visualstudio.com/) with [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension

## Project structure comparison

WinForms and Blazor Web Apps follow different application architectures. The following table maps common WinForms artifacts to their Blazor equivalents and describes their roles in a Blazor Web App.

| **WinForms** | **Blazor** | **Description** |
|---|---|---|
| `Program.cs` (with `Application.Run`) | `Program.cs` and `App.razor` | Defines startup and root rendering |
| `Form1.cs` | `App.razor`, `MainLayout.razor`, and `Routes.razor` | Represents the application shell and routing structure |
| `Form1.Designer.cs` | `.razor` markup section | Defines the UI layout and component hierarchy |
| Event handlers and business logic | Services, component state, `.razor.cs`, and component lifecycle methods | Contains UI logic, event handling, and state management |
| `Models/*.cs` | `Models/*.cs` | Usually reusable without changes |
| `Services/*.cs` or business layer | `Services/*.cs` | Handles shared application logic through dependency injection |
| `Resources` folder or `Resources.resx` | `wwwroot` folder and static assets | Manages images, icons, and static resources |
| `UserControl` | Razor component (`.razor`) | Reusable UI component |
| Event handlers (`EventArgs`) | `EventCallback`, component methods, or custom services | Handles user interaction, events, and validation logic |

## Migrating components from Windows Forms to Blazor

Create a Blazor project using one of the following getting started guides.

* [Getting Started with Blazor Web App](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)
* [Getting Started with Blazor Server App](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)
* [Getting Started with Blazor WebAssembly App](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)

This migration guide focuses on the **Blazor Web App (Interactive Server)** approach, which provides a straightforward migration path from WinForms applications by keeping business logic and state management on the server. Interactive Server rendering uses SignalR to synchronize UI interactions between the browser and server, making it suitable for enterprise applications that are traditionally built as desktop applications.

The following shared setup applies to all components and covers the common configuration required before proceeding to the [component specific migration steps](#component-specific-migration-steps).

### Package installation

In WinForms applications, controls are installed as platform specific [WinForms NuGet packages](https://help.syncfusion.com/windowsforms/installation/install-nuget-packages).

In Blazor applications, components are also provided as individual NuGet packages, which helps improve performance and reduces application size. For the complete list of available packages, refer to the [Blazor NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages).

Additionally, install the [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes) NuGet package for styling support.

### Service registration

In Blazor applications, components must be registered with the built-in dependency injection system. This registration enables component rendering, state management, and required runtime behavior.

This step applies only to Blazor applications. It replaces the explicit control initialization and setup performed in WinForms.

To enable Blazor components, register the Blazor service in the `Program.cs` file.

{% tabs %}
{% highlight c# tabtitle="Program.cs" hl_lines="1 4" %}

using Syncfusion.Blazor;
...
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSyncfusionBlazor();
var app = builder.Build();
...

{% endhighlight %}
{% endtabs %}

### Add required namespace

In Blazor, namespaces are commonly imported globally using the `_Imports.razor` file. This step makes the Blazor components available throughout the application.

{% tabs %}
{% highlight razor tabtitle="_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Charts
@using Syncfusion.Blazor.Schedule

{% endhighlight %}
{% endtabs %}

### Applying themes

In WinForms, themes are typically applied using [SkinManager](https://help.syncfusion.com/windowsforms/skins/getting-started). The following example shows how to apply a theme programmatically:

{% tabs %}
{% highlight c# tabtitle="Form1.cs" %}

using Syncfusion.Windows.Forms;

namespace WinFormsApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            // Create SkinManager instance.
            SkinManager skinManager1 = new SkinManager(this.components);
            
            // Apply theme to entire form (all controls).
            skinManager1.Controls = this;
            skinManager1.VisualTheme = VisualTheme.HighContrast;
        }
    }
}

{% endhighlight %}
{% endtabs %}

In Blazor, the theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the [stylesheet](https://blazor.syncfusion.com/documentation/appearance/themes) and [script references](https://blazor.syncfusion.com/documentation/common/adding-script-references) in the **App.razor** file.

{% tabs %}
{% highlight razor tabtitle="App.razor" %}

<head>
    ...
    <!-- Theme stylesheet -->
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
    ...
</head>

<body>
    ...
    <!-- Blazor core component's script reference -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
    ...
</body>

{% endhighlight %}
{% endtabs %}

## Understanding data binding: WinForms data sources vs Blazor component state

Data binding is a fundamental concept in both WinForms and Blazor. However, the way data is managed and updated differs because WinForms follows a form centric architecture, while Blazor uses component state and rendering.

### WinForms data binding approach

In WinForms, controls are commonly bound to data through the `DataSource` property. The bound data can come from collections, `DataTable` objects, datasets, or data retrieved from a database. The form typically acts as the central location for managing and updating application state.

{% tabs %}
{% highlight c# tabtitle="Form1.cs" %}

using Syncfusion.WinForms.DataGrid;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace WinFormsDataBindingApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            SfDataGrid dataGrid = new SfDataGrid();
            dataGrid.Dock = DockStyle.Fill;

            dataGrid.DataSource = GetOrders();

            Controls.Add(dataGrid);
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
        public string? CustomerID { get; set; }
        public double Freight { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

### Blazor data binding approach

In Blazor, components receive data through parameters and component state. Data is commonly loaded during component initialization and supplied directly to UI components. When the underlying state changes, Blazor automatically updates the rendered UI.

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

@page "/orders"
@rendermode InteractiveServer
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders">
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field="@nameof(Order.Freight)" HeaderText="Freight" Format="N2" TextAlign="TextAlign.Right" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private List<Order> Orders = new();
    
    protected override void OnInitialized()
    {
        // Component state is initialized with data
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

### Key differences

| Aspect | WinForms | Blazor |
|---|---|---|
| Application model | Form-based desktop application | Component-based web application |
| Data binding scope | Form or control level | Component level |
| Binding mechanism | `DataSource`, `BindingSource`, and control bindings | Component parameters, `DataSource`, and `@bind` |
| Data flow | Event-driven data updates | State-driven UI rendering |
| UI updates | Triggered by control notifications and data source changes | Triggered by component re-rendering and state changes |
| Change notification | `INotifyPropertyChanged`, `IBindingList`, and `INotifyCollectionChanged` | `INotifyPropertyChanged`, `INotifyCollectionChanged`, and component re-rendering |
| Initialization | Form constructor or `Load` event | `OnInitialized` or `OnInitializedAsync` |
| Shared state | Typically managed through forms and helper classes | Commonly managed through dependency-injected services |
| Event handling | CLR events and event handlers | Event callbacks and component events |

## Component specific migration steps

### DataGrid

[WinForms DataGrid](https://www.syncfusion.com/winforms-ui-controls/datagrid) is a high performance tabular control for Windows Forms applications, while [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) is the web first Razor component for building responsive, interactive, data driven web interfaces.

For additional details, refer to the [WinForms DataGrid getting started guide](https://help.syncfusion.com/windowsforms/datagrid/gettingstarted) and [Blazor DataGrid getting started guide](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-server-app).

| Aspect | WinForms | Blazor |
|---|---|---|
| Package (NuGet) | [Syncfusion.SfDataGrid.WinForms](https://www.nuget.org/packages/Syncfusion.SfDataGrid.WinForms) | [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid) |
| Component declaration | `SfDataGrid` (programmatic or Designer) | `<SfGrid>` |
| Data binding | Direct `DataSource` property assignment | [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) with component state |
| Collection type | ObservableCollection<T>, BindingList<T>, DataTable | List<T>, IEnumerable<T>, ObservableCollection<T> |
| Columns | Designer based column definitions or code behind | [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) with [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field), [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Format), and [EditType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_EditType) |
| Templates | `CellTemplate` and `EditTemplate` | Razor `<Template>` |
| Editing and events | Event handlers (`CellClick`, `ValueChanged`, etc.) | [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html#Syncfusion_Blazor_Grids_GridEditSettings), [GridEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html), and event callbacks |
| Paging and virtualization | Built-in paging with `SfDataPager` | [GridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PageSettings), [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization), and [EnableColumnVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableColumnVirtualization) |

#### Component rendering

The [WinForms DataGrid](https://www.syncfusion.com/winforms-ui-controls/datagrid) control can be added programmatically or via the Visual Studio Designer. Columns are configured in the Designer or programmatically, and data is assigned through the `DataSource` property.

The [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) component is declared in Razor markup, and it receives data through the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) parameter.

**WinForms approach**

{% tabs %}
{% highlight c# tabtitle="Form1.cs" %}

using Syncfusion.WinForms.DataGrid;
using System.Collections.ObjectModel;
using System.Windows.Forms;

namespace WinFormsDataGridApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
            SfDataGrid dataGrid = new SfDataGrid();
            dataGrid.Dock = DockStyle.Fill;
            dataGrid.DataSource = GetOrders();
            Controls.Add(dataGrid);
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
        public string? CustomerID { get; set; }
        public double Freight { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

**Blazor equivalent**

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

@page "/Orders"

<SfGrid DataSource="@Orders">
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
        public string? CustomerID { get; set; }
        public double Freight { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

### Charts

[WinForms Charts](https://www.syncfusion.com/winforms-ui-controls/charts) is a comprehensive charting control for rich desktop visualizations, while [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) is the Razor based component for creating responsive, interactive charts on the web.

For additional details, refer to the [WinForms Charts getting started guide](https://help.syncfusion.com/windowsforms/chart/getting-started) and [Blazor Charts getting started guide](https://blazor.syncfusion.com/documentation/chart/getting-started).

| Aspect | WinForms | Blazor |
|---|---|---|
| Package (NuGet) | [Syncfusion.Chart.Windows](https://www.nuget.org/packages/Syncfusion.Chart.Windows) | [Syncfusion.Blazor.Charts](https://www.nuget.org/packages/Syncfusion.Blazor.Charts) |
| Component declaration | `ChartControl` (programmatic or Designer) | `<SfChart>` |
| Data binding | `DataSource` property with `XValues` and `YValues` | [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) with [XName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_XName) and [YName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_YName) |
| Axis and series | Designer based or programmatic configuration | [ChartPrimaryXAxis](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartPrimaryXAxis.html), [ChartPrimaryYAxis](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartPrimaryYAxis.html), and [ChartSeriesCollection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesCollection.html) |
| Series types | Built in series types (Column, Line, Bar, etc.) | [ChartSeries](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html) with `Type="ChartSeriesType.*"` |
| Markers and tooltips | Series level settings | [ChartMarker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartMarker.html) and [ChartTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html) |
| Events | CLR events | Event callbacks such as point and tooltip events |
| Responsiveness | Fixed size based on form design | CSS-based responsive layout |

#### Component rendering

The [WinForms Chart](https://www.syncfusion.com/winforms-ui-controls/charts) control can be added programmatically or via the Visual Studio Designer. Axes and series are configured programmatically or in the Designer, and data is assigned through the `DataSource` property.

The [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) component is declared in Razor markup, with axes and series configured using child components, and data supplied through the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) parameter.

**WinForms approach**

{% tabs %}
{% highlight c# tabtitle="Form1.cs" %}

using Syncfusion.Windows.Forms.Chart;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsChartApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ChartControl chart = new ChartControl();
            chart.Dock = DockStyle.Fill;

            var salesData = new List<SalesInfo>
            {
                new SalesInfo { Month = "Jan", Sales = 35 },
                new SalesInfo { Month = "Feb", Sales = 28 },
                new SalesInfo { Month = "Mar", Sales = 34 },
                new SalesInfo { Month = "Apr", Sales = 32 },
                new SalesInfo { Month = "May", Sales = 40 }
            };

            ChartSeries series = new ChartSeries("Sales", ChartSeriesType.Column);
            foreach (var item in salesData)
            {
                series.Points.Add(item.Month, item.Sales);
            }
            chart.Series.Add(series);
            chart.PrimaryXAxis.Title = "Month";
            chart.PrimaryYAxis.Title = "Sales";

            Controls.Add(chart);
        }
    }

    public class SalesInfo
    {
        public string? Month { get; set; }
        public double Sales { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

**Blazor equivalent**

{% tabs %}
{% highlight razor tabtitle="Sales.razor" %}

@page "/Sales"

<SfChart Title="Sales Analysis">
    <ChartPrimaryXAxis Title="Month" ValueType="@Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
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
        public string? Month { get; set; }
        public double Sales { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

### Scheduler

[WinForms Scheduler](https://www.syncfusion.com/winforms-ui-controls/scheduler) is a feature rich scheduling control for managing appointments and resources in Windows desktop applications, while [Blazor Scheduler](https://www.syncfusion.com/blazor-components/blazor-scheduler) is the Blazor component designed for calendar and scheduling scenarios in web applications.

For additional details, refer to the [WinForms Scheduler getting started guide](https://help.syncfusion.com/windowsforms/scheduler/getting-started) and [Blazor Scheduler getting started guide](https://blazor.syncfusion.com/documentation/scheduler/getting-started-with-server-app).

| Aspect | WinForms | Blazor |
|---|---|---|
| Package (NuGet) | [Syncfusion.Schedule.Windows](https://www.nuget.org/packages/Syncfusion.Schedule.Windows) | [Syncfusion.Blazor.Schedule](https://www.nuget.org/packages/Syncfusion.Blazor.Schedule) |
| Component declaration | `ScheduleControl` (programmatic or Designer) | `<SfSchedule TValue="TModel">` |
| Appointment model | Built in [ScheduleAppointment](https://help.syncfusion.com/windowsforms/scheduler/getting-started#schedule-appointment) | Custom model mapped with [ScheduleEventSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEventSettings-1.html) |
| Date and time binding | `SelectedDate` and `CurrentDate` | [SelectedDate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.SfSchedule-1.html#Syncfusion_Blazor_Schedule_SfSchedule_1_SelectedDate) (two-way binding via `@bind-SelectedDate`) |
| Data source | `DataSource` property | [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEventSettings-1.html#Syncfusion_Blazor_Schedule_ScheduleEventSettings_1_DataSource) |
| Resources and grouping | `ResourceCollection` with mappings | [ScheduleResources](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleResources.html) and [ScheduleResource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleResource-2.html) |
| Events | CLR events | Event callbacks such as action and cell events |
| Large data handling | Native desktop behavior | Virtualization and lazy loading are commonly used |

#### Component rendering

The [WinForms Scheduler](https://www.syncfusion.com/winforms-ui-controls/scheduler) control can be added programmatically or via the Visual Studio Designer. Views and appointments are configured programmatically or in the Designer, and data is assigned through the `DataSource` property.

The [Blazor Scheduler](https://www.syncfusion.com/blazor-components/blazor-scheduler) component is declared in Razor markup, where views are configured using child components, and appointment data is supplied through the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEventSettings-1.html#Syncfusion_Blazor_Schedule_ScheduleEventSettings_1_DataSource) parameter.

**WinForms approach**

{% tabs %}
{% highlight c# tabtitle="Form1.cs" %}

using Syncfusion.Windows.Forms.Schedule;
using System;
using System.Windows.Forms;

namespace WinFormsSchedulerApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            ScheduleControl schedule = new ScheduleControl();
            schedule.Dock = DockStyle.Fill;
            schedule.ViewType = ScheduleViewType.WeekView;
            schedule.SelectedDate = DateTime.Today;

            schedule.Appointments.Add(new ScheduleAppointment
            {
                Subject = "Project Meeting",
                StartTime = DateTime.Today.AddHours(10),
                EndTime = DateTime.Today.AddHours(11)
            });

            schedule.Appointments.Add(new ScheduleAppointment
            {
                Subject = "Client Call",
                StartTime = DateTime.Today.AddHours(14),
                EndTime = DateTime.Today.AddHours(15)
            });

            Controls.Add(schedule);
        }
    }
}

{% endhighlight %}
{% endtabs %}

**Blazor equivalent**

{% tabs %}
{% highlight razor tabtitle="Schedule.razor" %}

@page "/Schedule"

<SfSchedule TValue="AppointmentData" Height="650px" @bind-SelectedDate="@CurrentDate">
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code {
    DateTime CurrentDate = new DateTime(2025, 2, 14);
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Team Meeting", StartTime = new DateTime(2025, 2, 13, 10, 0, 0) , EndTime = new DateTime(2025, 2, 13, 12, 0, 0) },
        new AppointmentData { Id = 2, Subject = "Client Presentation", StartTime = new DateTime(2025, 2, 15, 10, 0, 0) , EndTime = new DateTime(2025, 2, 15, 12, 0, 0) }
    };
    public class AppointmentData
    {
        public int Id { get; set; }
        public string? Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

## Migration limitations and considerations

Migrating from WinForms to Blazor involves more than replacing desktop controls with web components. WinForms and Blazor use different rendering models, lifecycle patterns, and layout systems. The following considerations should be evaluated before migration.

### UI layout differences: desktop layouts vs responsive CSS layouts

#### WinForms approach

WinForms applications commonly use coordinate based layouts through properties such as `Location`, `Size`, `Anchor`, and `Dock`. These layouts are typically optimized for fixed desktop screen resolutions.

{% tabs %}
{% highlight c# tabtitle="Form1.cs" %}

button1.Location = new Point(20, 20);
button1.Size = new Size(120, 40);

{% endhighlight %}
{% endtabs %}

#### Blazor approach

Blazor renders components as HTML and CSS in a web browser. Instead of placing controls at specific coordinates, layouts are usually built using CSS technologies such as Flexbox and Grid.

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

<div style="display:flex; gap:10px;">
    <button>Save</button>
    <button>Cancel</button>
</div>

{% endhighlight %}
{% endtabs %}

### Different lifecycle and event models

#### WinForms lifecycle

WinForms follows a desktop oriented, event driven programming model. Application logic is commonly executed through form and control events such as `Load`, `Click`, `Shown`, and `FormClosing`. User interactions are handled through event handlers that are attached directly to controls, and UI updates are performed by modifying control properties at runtime.

{% tabs %}
{% highlight c# tabtitle="Form1.cs" %}

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace WinFormsApp
{
    public partial class OrdersForm : Form
    {
        private List<Order> Orders = new();

        public OrdersForm()
        {
            InitializeComponent();
            this.Load += OrdersForm_Load;
            this.FormClosing += OrdersForm_FormClosing;
        }

        private void OrdersForm_Load(object sender, EventArgs e)
        {
            // Initialize data when the form loads.
            Orders = GetOrders();
            sfDataGrid1.DataSource = Orders;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SaveOrders();
        }

        private void OrdersForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cleanup resources before closing.
            DisposeResources();
        }

        private List<Order> GetOrders()
        {
            return new List<Order>
            {
                new Order { OrderID = 10248, CustomerID = "VINET" },
                new Order { OrderID = 10249, CustomerID = "TOMSP" }
            };
        }

        private void SaveOrders()
        {
            MessageBox.Show("Orders saved");
        }

        private void DisposeResources()
        {
            // Cleanup logic
        }
    }

    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

#### Blazor lifecycle

Blazor uses a component based lifecycle that is designed for web applications. Instead of form events, components provide lifecycle methods such as `OnInitializedAsync`, `OnParametersSetAsync`, and `OnAfterRenderAsync`. User interactions are handled through event callbacks, and the framework automatically updates the user interface when component state changes.

Blazor components use lifecycle methods and event callbacks.

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

@page "/sample"
@rendermode InteractiveServer
@using Syncfusion.Blazor.Grids

<SfGrid @ref="gridRef" DataSource="@Orders" OnActionBegin="@OnActionBegin">
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" IsPrimaryKey="true"></GridColumn>
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer ID"></GridColumn>
        <GridColumn Field="@nameof(Order.Freight)" HeaderText="Freight" Format="N2"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<Order> gridRef;
    private List<Order> Orders = new();

    protected override async Task OnInitializedAsync()
    {
        // Called once when the component is first initialized.
        await LoadDataAsync();
    }

    protected override void OnParametersSet()
    {
        // Called when the component receives new parameters.
        RefreshData();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        // Called after the component is rendered to the DOM.
        if (firstRender)
        {
            await InitializeAsync();
        }
    }

    private async Task OnActionBegin(ActionEventArgs<Order> args)
    {
        // Asynchronous event handling using EventCallback.
        if (args.RequestType == Syncfusion.Blazor.Grids.Action.Save)
        {
            await SaveDataAsync(args.Data);
        }
    }

    private async Task LoadDataAsync()
    {
        // Async data loading from a service or database.
        await Task.Delay(100);
        Orders = new List<Order>
        {
            new Order { OrderID = 10248, CustomerID = "VINET", Freight = 32.38 }
        };
    }

    private void RefreshData()
    {
        // Data refresh logic.
    }

    private async Task InitializeAsync()
    {
        // Post-render initialization (e.g., JavaScript interop).
        await Task.CompletedTask;
    }

    private async Task SaveDataAsync(Order order)
    {
        // Async save operation.
        await Task.Delay(100);
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

### Platform limitations

WinForms applications run directly on Windows and have access to operating system resources, desktop APIs, and local hardware. Blazor applications run in a web browser and operate within browser security boundaries. Because of this architectural difference, some desktop-specific capabilities do not have direct equivalents in web applications and may require alternative implementations.

The following areas should be reviewed carefully during migration:

* **Windows-specific APIs** – Functionality that depends on Windows libraries, registry access, or native Win32 APIs cannot be accessed directly from Blazor components and may require server side services or platform specific integrations.
* **Desktop window management** – Features such as multiple independent windows, modal desktop dialogs, system tray integration, and custom window behavior do not directly translate to browser based applications.
* **Local file system access** – Web applications have limited access to user files and folders and must use browser supported file upload and download mechanisms.
* **Hardware and peripheral integration** – Direct communication with devices such as serial ports, scanners, printers, USB devices, and other hardware may require browser-supported APIs, specialized middleware, or server side components.
* **Desktop automation and inter-process communication** – Scenarios that interact with other desktop applications, processes, or Windows services generally require architectural redesign when moving to a web application.
* **Operating system-specific functionality** – Features tightly coupled to Windows user interfaces, shell integrations, drag-and-drop behaviors, or desktop workflows may require alternative web based user experiences.

## Run the application

Run the application using the following .NET CLI command from the project root directory.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet run

{% endhighlight %}
{% endtabs %}

## See also

- [Getting started with Blazor DataGrid in Web App](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app)
- [Getting started with Blazor Chart in Web App](https://blazor.syncfusion.com/documentation/chart/getting-started-with-web-app)
- [Getting started with Blazor Scheduler in Web App](https://blazor.syncfusion.com/documentation/scheduler/getting-started-webapp)
- [Getting started with Blazor Components](https://blazor.syncfusion.com/documentation/introduction)
