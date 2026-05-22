---
layout: post
title: Migrating from Windows Forms (WinForms) to Blazor Guide | Syncfusion®
description: Step-by-step guide to migrate a WinForms app to Blazor, covering architecture, project setup, theming, service registration, and component mapping.
platform: Blazor
control: Common
documentation: ug
---

# Migrating from Windows Forms to Blazor

This guide provides a step‑by‑step approach to migrating a [Windows Forms (WinForms)](https://www.syncfusion.com/winforms-ui-controls) application to a [Blazor](https://www.syncfusion.com/blazor-components) application. It helps developers modernize existing desktop applications by transitioning to a web based architecture.     

## Why Migrate from WinForms to Blazor?

| Aspect | WinForms | Blazor | Benefit of Migration |
|------|----------|------------------|----------------------|
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

## Key architectural differences

Understanding the architectural differences between **WinForms** and **Blazor** is essential before starting the migration. WinForms follows a traditional desktop based, event driven architecture, while Blazor uses a modern, component based web architecture designed for scalability and maintainability.

| Area | WinForms Architecture | Blazor Architecture |
|-----|----------------------|--------------------------------|
| Application Type | Desktop application | Web application |
| UI Model | Form based controls | Component based UI |
| Platform Dependency | Windows only | Cross platform |
| Code Organization | UI and business logic often tightly coupled | Clear separation of UI, services, and models |
| Rendering Engine | OS based rendering (GDI+/Windows) | Browser based rendering (HTML/CSS) |
| State Management | Control state managed automatically | State driven UI with data binding |
| Event Handling | Traditional event handlers | Declarative event binding |
| Layout System | Fixed, pixel based layout | Responsive, CSS based layout |
| Navigation | Open and close forms | URL based routing |

## Project structure comparison

When migrating from WinForms to Blazor, one of the first changes you will notice is the project structure. WinForms applications are designed for desktop environments, whereas Blazor applications follow a component based web architecture. Understanding how files and responsibilities map between the two frameworks helps simplify the migration process.

| **WinForms** | **Blazor** | **Description** |
|---|---|---|
| `Program.cs` | `Program.cs` | Defines the application entry point and configures startup logic |
| `Form1.cs` | `Pages/*.razor` | Represents a UI page or view |
| `Form1.Designer.cs` | `.razor` markup section | Defines the UI layout and component hierarchy |
| `UserControl` | Razor component (`.razor`) | Reusable UI components |
| Event handlers | Component methods | Handles UI events, typically implemented as async methods |

## Creating a Blazor project

To migrate a WinForms application, you first need to create a Blazor project. Blazor is a modern web framework that allows you to build interactive user interfaces using C# and .NET, instead of JavaScript.

You can create a new Blazor project using the .NET Command Line Interface (CLI). Run the following command in a terminal or command prompt.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet new blazor -n WinFormsToBlazor --interactivity Server

{% endhighlight %}
{% endtabs %}

## Package installation

This section explains how packages are referenced in WinForms and Blazor applications, and highlights the key differences in how components, themes, and runtime dependencies are delivered in each framework.

**WinForms**

In WinForms applications, controls are installed as platform specific NuGet packages. Typically, each control (or a group of related controls) is provided as a separate package.

These WinForms packages include native WinForms rendering logic, control specific assemblies, and Windows only dependencies. Because WinForms applications run exclusively on Windows, the packages are tightly coupled with the Windows desktop environment.

For example, you can install the DataGrid for WinForms using the following NuGet package.

- [Syncfusion.SfDataGrid.WinForms](https://www.nuget.org/packages/Syncfusion.SfDataGrid.WinForms)

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.SfDataGrid.WinForms

{% endhighlight %}
{% endtabs %}

**Blazor application**

In Blazor applications, Blazor components are delivered as web based UI components. Instead of native Windows rendering, these components use HTML, CSS, and JavaScript and integrate with C# through the Blazor framework.

To use Blazor components in a Blazor application, install the component package and the theme package.

- [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid/)
- [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Grid -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

## Applying themes 

This section explains how themes are applied and managed in WinForms and Blazor applications. It also highlights the key conceptual shift from desktop based theme managers to CSS based theming used in web applications.

**WinForms**

In WinForms applications, themes are applied using theme managers or control properties. All styling logic is handled inside the desktop runtime and tightly integrated with the Windows rendering system.

Themes in WinForms can be applied at the form level or across the entire application, depending on requirements. UI rendering is managed by the Windows graphics system, and there is no need for external CSS or JavaScript files, as all styling is handled within the application itself.

{% tabs %}
{% highlight c# tabtitle="Form1.cs" %}

using Syncfusion.WinForms.Controls;

SfSkinManager.SetVisualStyle(this, VisualStyles.FluentLight);

{% endhighlight %}
{% endtabs %}

**Blazor application**

In Blazor applications, UI styling is separated from application logic and handled using web standards. Instead of theme managers, styles are applied through CSS files and supporting JavaScript.

Themes in Blazor are applied by referencing a theme CSS file and loading the Blazor JavaScript runtime. This approach follows standard web development practices and enables flexible styling across different devices and browsers.

To apply styles and enable required features, reference the theme CSS file and scripts in the `App.razor` file located under the Components folder.

{% tabs %}
{% highlight html tabtitle="App.razor" %}

<head>
    ....
    <!-- Theme stylesheet -->
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
    ....
</head>

<body>
    ....
    <!-- Blazor core component's script reference -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
    ....
</body>

{% endhighlight %}
{% endtabs %}

## Service registration

In Blazor applications, Blazor components must be registered with the built‑in dependency injection system. This registration enables component rendering, state management, and required runtime behavior.

This step is required only for Blazor applications and replaces the explicit control initialization and setup performed in WinForms.

To enable Blazor components, register the **Syncfusion® Blazor service** in the `Program.cs` file.

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}

using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....

{% endhighlight %}
{% endtabs %}

In Blazor, namespaces are commonly imported globally using the `_Imports.razor` file.

This step makes the Blazor components available throughout the application.

{% tabs %}
{% highlight razor tabtitle="_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

{% endhighlight %}
{% endtabs %}

## Component rendering

This section explains how user interface elements are rendered in WinForms and Blazor applications. It demonstrates the transition from control based rendering in desktop applications to state driven component rendering in Blazor.

**WinForms: Component rendering**

In WinForms, user interface elements are created as controls and rendered immediately when they are added to a form. The Windows runtime manages rendering through the message loop, and control state is maintained automatically.

{% tabs %}
{% highlight c# tabtitle="Form1.cs" %}

using Syncfusion.WinForms.DataGrid;
using System.Collections.Generic;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        SfDataGrid dataGrid = new SfDataGrid();
        dataGrid.Dock = DockStyle.Fill;
        dataGrid.DataSource = GetOrders();

        Controls.Add(dataGrid);
    }

    private List<Order> GetOrders()
    {
        return new List<Order>
        {
            new Order { OrderID = 10248, CustomerID = "VINET", Freight = 32.38 },
            new Order { OrderID = 10249, CustomerID = "TOMSP", Freight = 11.61 }
        };
    }
}

public class Order
{
    public int OrderID { get; set; }
    public string? CustomerID { get; set; }
    public double Freight { get; set; }
}

{% endhighlight %}
{% endtabs %}

**Blazor application: Component rendering**

In Blazor, the UI is rendered using Razor components. Components are defined in markup, and rendering is handled by the Blazor rendering engine.

Instead of rendering immediately, Blazor renders components based on state changes. Whenever the component state changes, the framework updates only the required parts of the UI.

In this approach, the UI is declared using Razor markup, rendering is driven by the component state, and updates occur automatically whenever the underlying data changes.

The following example uses the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) component to render a list of orders.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/"
@rendermode InteractiveServer
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders">
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" />
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer" />
        <GridColumn Field="@nameof(Order.Freight)" HeaderText="Freight" Format="N2" />
    </GridColumns>
</SfGrid>

@code 
{
    private List<Order> Orders = new()
    {
        new Order { OrderID = 10248, CustomerID = "VINET", Freight = 32.38 },
        new Order { OrderID = 10249, CustomerID = "TOMSP", Freight = 11.61 }
    };

    public class Order
    {
        public int OrderID { get; set; }
        public string? CustomerID { get; set; }
        public double Freight { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

## Rendering multiple components

This section explains how multiple components are added and rendered in WinForms and Blazor applications. 

**WinForms: Rendering multiple components**

In WinForms, multiple controls are added to a form programmatically. Each control is placed into the form’s control collection, and the rendering order depends on the sequence in which controls are added.

{% tabs %}
{% highlight c# tabtitle="Form1.cs" %}

using Syncfusion.WinForms.DataGrid;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        // Initialize DataGrid.
        SfDataGrid dataGrid = new SfDataGrid();
        dataGrid.Dock = DockStyle.Top;
        dataGrid.Height = 200;
        dataGrid.DataSource = GetOrders();

        // Initialize Chart.
        Chart chart = new Chart();
        chart.Dock = DockStyle.Fill;

        ChartArea chartArea = new ChartArea();
        chart.ChartAreas.Add(chartArea);

        Series series = new Series
        {
            Name = "Sales",
            XValueMember = "CustomerID",
            YValueMembers = "Freight",
            ChartType = SeriesChartType.Column
        };

        chart.Series.Add(series);
        chart.DataSource = GetOrders();

        // Add controls to the form.
        this.Controls.Add(chart);
        this.Controls.Add(dataGrid);
    }

    private List<Order> GetOrders()
    {
        return new List<Order>
        {
            new Order { OrderID = 10248, CustomerID = "VINET", Freight = 32.38 },
            new Order { OrderID = 10249, CustomerID = "TOMSP", Freight = 11.61 }
        };
    }
}

public class Order
{
    public int OrderID { get; set; }
    public string? CustomerID { get; set; }
    public double Freight { get; set; }
}

{% endhighlight %}
{% endtabs %}

**Blazor application: Rendering multiple components**

In Blazor, multiple components are rendered declaratively using Razor markup. Components are displayed in the order they appear in the markup and are arranged using standard web layout rules.

The following example renders a [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) component alongside the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid).

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/"
@rendermode InteractiveServer
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Charts

<SfGrid DataSource="@Orders">
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" />
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer" />
        <GridColumn Field="@nameof(Order.Freight)" HeaderText="Freight" Format="N2" />
    </GridColumns>
</SfGrid>

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    private List<Order> Orders = new()
    {
        new Order { OrderID = 10248, CustomerID = "VINET", Freight = 32.38 },
        new Order { OrderID = 10249, CustomerID = "TOMSP", Freight = 11.61 }
    };

    private List<SalesData> Sales = new()
    {
        new SalesData { Month = "Jan", SalesValue = 35 },
        new SalesData { Month = "Feb", SalesValue = 28 }
    };

    public class Order
    {
        public int OrderID { get; set; }
        public string? CustomerID { get; set; }
        public double Freight { get; set; }
    }

    public class SalesData
    {
        public string Month { get; set; } = string.Empty;
        public double SalesValue { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

## Run the application

Run the application using the following .NET CLI command from the project root directory.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet run

{% endhighlight %}
{% endtabs %}

## WinForms to Blazor component mapping reference

This section provides a comprehensive reference table that maps **WinForms controls** to their **Blazor equivalents**.  

It is intended to help developers **plan, assess, and execute** WinForms to Blazor migrations efficiently.

### Data Management and Grids

| WinForms control | Blazor component | Notes |
|---|---|---|
| [SfDataGrid](https://help.syncfusion.com/windowsforms/datagrid/gettingstarted) | [SfGrid](https://blazor.syncfusion.com/documentation/datagrid/getting-started) | Supports features such as sorting, filtering, grouping, paging, and editing |
| [SfDataPager](https://help.syncfusion.com/windowsforms/datagrid/paging) | [SfGrid](https://blazor.syncfusion.com/documentation/datagrid/paging) | Paging is handled using [GridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PageSettings) |
| [Virtual Grid](https://help.syncfusion.com/windowsforms/grid-control/virtual-grid) | [SfGrid](https://blazor.syncfusion.com/documentation/datagrid/virtual-scrolling) | Virtual scrolling can be enabled by setting [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization) to **true**. |

### Charts and Data Visualization

| WinForms control | Blazor component | Notes |
|---|---|---|
| [ChartControl](https://help.syncfusion.com/windowsforms/chart/getting-started) | [SfChart](https://blazor.syncfusion.com/documentation/chart/getting-started-wasm) | Supports column, line, bar, pie, area charts |
| [Sparkline](https://help.syncfusion.com/windowsforms/sparkline/gettingstarted) | [SfSparkline](https://blazor.syncfusion.com/documentation/sparkline/getting-started) | Lightweight inline charts |
| [Gauge](https://help.syncfusion.com/windowsforms/radial-gauge/overview) | [SfLinearGauge](https://blazor.syncfusion.com/documentation/linear-gauge/getting-started), [SfCircularGauge](https://blazor.syncfusion.com/documentation/circular-gauge/getting-started) | SVG based rendering |
| [Maps](https://help.syncfusion.com/windowsforms/map/getting-started) | [SfMaps](https://blazor.syncfusion.com/documentation/maps/getting-started) | Interactive maps |

### Scheduling and Time Management

| WinForms control | Blazor component | Notes |
|---|---|---|
| [ScheduleControl](https://help.syncfusion.com/windowsforms/scheduler/getting-started) | [SfScheduler](https://blazor.syncfusion.com/documentation/scheduler/getting-started) | Appointment based scheduling |

### Navigation and Layout controls

| WinForms control | Blazor component | Notes |
|---|---|---|
| [TabControlAdv](https://help.syncfusion.com/windowsforms/tabcontrol/getting-started) | [SfTab](https://blazor.syncfusion.com/documentation/tabs/getting-started) | Tab navigation |
| [DockingManager](https://help.syncfusion.com/windowsforms/docking-manager/getting-started) | CSS Layout + Components | Requires layout redesign |
| [SplitContainerAdv](https://help.syncfusion.com/windowsforms/splitcontainer/creating-splitcontaineradv) | [SfSplitter](https://blazor.syncfusion.com/documentation/splitter/getting-started) | Horizontal/vertical splitting |

### Editors and Input controls

| WinForms control | Blazor component | Notes |
|---|---|---|
| [TextBoxExt](https://help.syncfusion.com/windowsforms/textbox/getting-started) | [SfTextBox](https://blazor.syncfusion.com/documentation/textbox/getting-started) | Text input |
| [SfNumericTextBox](https://help.syncfusion.com/windowsforms/numeric-textbox/gettingstarted) | [SfNumericTextBox](https://blazor.syncfusion.com/documentation/numeric-textbox/getting-started) | Numeric input |
| [SfDateTimeEdit](https://help.syncfusion.com/windowsforms/datetimepicker/getting-started) | [SfDateTimePicker](https://blazor.syncfusion.com/documentation/datetime-picker/getting-started) | Date and time picker |
| [SfComboBox](https://help.syncfusion.com/windowsforms/combobox/gettingstarted) | [SfComboBox](https://blazor.syncfusion.com/documentation/combobox/getting-started) | Virtualized dropdown |
| [AutoComplete](https://help.syncfusion.com/windowsforms/autocomplete/getting-started) | [SfAutoComplete](https://blazor.syncfusion.com/documentation/autocomplete/getting-started) | Input suggestions |

### Buttons and Commands

| WinForms control | Blazor component | Notes |
|---|---|---|
| [SfButton](https://help.syncfusion.com/windowsforms/button/getting-started) | [SfButton](https://blazor.syncfusion.com/documentation/button/getting-started) | Standard button |
| [SplitButton](https://help.syncfusion.com/windowsforms/split-button/getting-started) | [SfSplitButton](https://blazor.syncfusion.com/documentation/split-button/getting-started) | Button with dropdown actions |
| [ToggleButton](https://help.syncfusion.com/windowsforms/toggle-button/getting-started) | [SfSwitch](https://blazor.syncfusion.com/documentation/toggle-switch-button/getting-started) | Managed by state in Blazor |

### Dialogs and Notifications

| WinForms control | Blazor component | Notes |
|---|---|---|
| [MessageBoxAdv](https://help.syncfusion.com/windowsforms/messagebox/getting-started) | [SfDialog](https://blazor.syncfusion.com/documentation/dialog/getting-started) | Async open/close |
| [ProgressBarAdv](https://help.syncfusion.com/windowsforms/progress-bar/creating-progressbaradv) | [SfProgressBar](https://blazor.syncfusion.com/documentation/progress-bar/getting-started) | Progress indicator |

### File, Document, and Spreadsheet controls

| WinForms control | Blazor component | Notes |
|---|---|---|
| [PdfViewerControl](https://help.syncfusion.com/document-processing/pdf/pdf-viewer/winforms/getting-started) | [SfPdfViewer2](https://help.syncfusion.com/document-processing/pdf/pdf-viewer/blazor/getting-started/web-assembly-application) | PDF viewer |
| [Spreadsheet](https://help.syncfusion.com/document-processing/excel/spreadsheet/winforms/getting-started) | [SfSpreadsheet](https://help.syncfusion.com/document-processing/excel/spreadsheet/blazor/getting-started) | Excel like UI |

### Diagram and Visual Modeling

| WinForms control | Blazor component | Notes |
|---|---|---|
| [Diagram](https://help.syncfusion.com/windowsforms/diagram/getting-started) | [SfDiagramComponent](https://blazor.syncfusion.com/documentation/diagram/getting-started-with-wasm-app) | Nodes and connectors |

### Lists and Tree controls

| WinForms control | Blazor component | Notes |
|---|---|---|
| [TreeViewAdv](https://help.syncfusion.com/windowsforms/treeview/getting-started) | [SfTreeView](https://blazor.syncfusion.com/documentation/treeview/getting-started) | Hierarchical navigation |
| [SfListView](https://help.syncfusion.com/windowsforms/listview/gettingstarted) | [SfListView](https://blazor.syncfusion.com/documentation/listview/getting-started) | Virtualized lists |
| [Menu](https://help.syncfusion.com/windowsforms/menu/getting-started) | [SfMenu](https://blazor.syncfusion.com/documentation/menu-bar/getting-started) | Menu navigation |

## See also

- [Getting started with Blazor DataGrid in Web App](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app)
- [Getting started with Blazor Chart in Web App](https://blazor.syncfusion.com/documentation/chart/getting-started-with-web-app)
- [Getting started with Blazor Components](https://blazor.syncfusion.com/documentation/introduction)

