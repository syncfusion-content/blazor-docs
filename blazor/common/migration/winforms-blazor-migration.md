---
layout: post
title: Migrating from Windows Forms (WinForms) to Blazor | Syncfusion®
description: Step-by-step guide to migrate a Windows Forms (WinForms) application to Blazor, covering architectural differences, project setup, package installation, theming, service registration, component rendering, and a WinForms-to-Blazor component mapping reference.
platform: Blazor
component: Common
documentation: ug
---

# Migrating from Windows Forms to Blazor

This guide provides a step‑by‑step approach to migrating a [Windows Forms (WinForms)](https://www.syncfusion.com/winforms-ui-controls) application to [Blazor](https://www.syncfusion.com/blazor-components) application. It is designed to help developers modernize existing desktop applications by moving to a web based architecture while continuing to use familiar .NET and C# skills.

**This document covers:**

* Architectural differences between Windows Forms and Blazor
* Project structure mapping
* Step-by-step migration of Blazor components.

## Why Migrate from WinForms to Blazor?

| Aspect | WinForms | Blazor | Benefit of Migration |
|------|----------|------------------|----------------------|
| Platform Support | Windows only | Web, Desktop, Cloud, Cross‑platform | Application accessible from any browser or device |
| UI Technology | Legacy desktop UI | Modern web based UI | Improved look and user experience |
| Architecture | Form‑centric, tightly coupled | Component based, modular | Better maintainability and scalability |
| Accessibility | Requires local installation | Runs in a web browser | No client‑side installation required |
| Development Model | Event‑driven programming | Data binding and reactive UI | Cleaner and more readable code |
| UI Controls | Limited built‑in controls | 80+ Syncfusion® UI components | Rich enterprise‑ready UI features |
| Responsiveness | Fixed desktop layouts | Responsive web layouts | Works across different screen sizes |
| Maintenance | Hard to extend and update | Easy to maintain and enhance | Lower long term maintenance effort |
| Cloud Readiness | Minimal support | Designed for cloud deployment | Enables modern hosting scenarios |
| Code Reusability | Low reusability | High reusability via components and services | Faster development and testing |
| Future Support | Limited continued development | Actively developed framework | Long‑term application sustainability |

## Key architectural differences

Understanding the architectural differences between **WinForms** and **Blazor** is essential before starting the migration. WinForms follows a traditional desktop‑based, event‑driven architecture, while Blazor uses a modern, component‑based web architecture designed for scalability and maintainability.

| Area | WinForms Architecture | Blazor Architecture |
|-----|----------------------|--------------------------------|
| Application Type | Desktop application | Web application |
| UI Model | Form‑based controls | Component based UI |
| Platform Dependency | Windows only | Cross‑platform |
| Code Organization | UI and business logic often tightly coupled | Clear separation of UI, services, and models |
| Rendering Engine | OS‑based rendering (GDI+/Windows) | Browser‑based rendering (HTML/CSS) |
| State Management | Control state managed automatically | State‑driven UI with data binding |
| Event Handling | Traditional event handlers | Declarative event binding |
| Layout System | Fixed, pixel‑based layout | Responsive, CSS based layout |
| Navigation | Open and close forms | URL based routing |

## Project structure comparison

When migrating from WinForms to Blazor, one of the first changes you will notice is the project structure. WinForms applications are designed for desktop environments, whereas Blazor applications follow a component‑based web architecture. Understanding how files and responsibilities map between the two frameworks helps simplify the migration process.

| **WinForms** | **Blazor** | **Description** |
|---|---|---|
| `Program.cs` | `Program.cs` | Defines the application entry point and configures startup logic |
| `Form1.cs` | `Pages/*.razor` | Represents a UI page or view |
| `Form1.Designer.cs` | `.razor` markup section | Defines the UI layout and component hierarchy |
| `UserControl` | Razor component (`.razor`) | Reusable UI components |
| Event handlers | Component methods | Handles UI events, typically implemented as async methods |

## Creating a Blazor project

To migrate a WinForms application, you first need to create a Blazor project. Blazor is a modern web framework that allows you to build interactive user interfaces using C# and .NET, instead of JavaScript.

You can create a new Blazor project using the .NET Command Line Interface (CLI). Run the following command in a terminal or command prompt:

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet new blazor -n WinFormsToBlazor --interactivity Server

{% endhighlight %}
{% endtabs %}

## Package installation

This section explains how Syncfusion® packages are referenced in WinForms and Blazor applications, and highlights the key differences in how components, themes, and runtime dependencies are delivered in each framework.

**WinForms**

In WinForms applications, Syncfusion® controls are installed as platform specific NuGet packages. Typically, each control (or a group of related controls) is provided as a separate package.

These WinForms packages include the following:

- Native WinForms rendering logic
- Control‑specific assemblies
- Windows‑only dependencies

Because WinForms applications run only on Windows, the packages are tightly coupled with the Windows desktop environment.

- [Syncfusion.SfDataGrid.WinForms](https://www.nuget.org/packages/Syncfusion.SfDataGrid.WinForms)

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.SfDataGrid.WinForms

{% endhighlight %}
{% endtabs %}

**Blazor application**

In Blazor applications, Blazor components are delivered as web‑based UI components. Instead of native Windows rendering, these components use HTML, CSS, and JavaScript and integrate with C# through the Blazor framework.

Blazor packages are grouped into the following categories:

- Component packages (Grid, Charts, Scheduler, etc.)
- Theme packages (CSS‑based)

To use Blazor components in a Blazor application, install the base component package and the theme package.

- [Syncfusion.Blazor.Grids](https://www.nuget.org/packages/Syncfusion.Blazor.Grid/)
- [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Grids -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

## Applying themes 

This section explains how themes are applied and managed in WinForms and Blazor applications. It also highlights the key conceptual shift from desktop based theme managers to CSS based theming used in web applications.

**WinForms**

In WinForms applications, Syncfusion® themes are applied using theme managers or control properties. All styling logic is handled inside the desktop runtime and tightly integrated with the Windows rendering system.

Key characteristics of WinForms theming include:

- Themes are applied at the form level or the application level
- UI rendering is handled by Windows graphics
- No external CSS or JavaScript files are required

{% tabs %}
{% highlight c# tabtitle="Form1.cs" %}

using Syncfusion.WinForms.Controls;

SfSkinManager.SetVisualStyle(this, VisualStyles.FluentLight);

{% endhighlight %}
{% endtabs %}

**Blazor application**

In Blazor applications, UI styling is separated from application logic and handled using web standards. Instead of theme managers, styles are applied through CSS files and supporting JavaScript.

Themes in Blazor are applied by

- Referencing a theme CSS file
- Loading the Blazor JavaScript runtime

This approach follows standard web development practices and enables flexible styling across different devices and browsers.

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

This step is required only for Blazor applications and replaces the implicit component initialization mechanism used in WinForms.

To enable Blazor components, register the Syncfusion® Blazor service in the `Program.cs` file.

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

This section explains how user interface elements are rendered in WinForms and Blazor applications. It demonstrates the transition from control‑based rendering in desktop applications to state‑driven component rendering in Blazor.

**WinForms: Component rendering**

In WinForms, user interface elements are created as controls and rendered immediately when they are added to a form. The Windows runtime manages rendering through the message loop, and control state is maintained automatically.

{% tabs %}
{% highlight c# tabtitle="Form1.cs" %}

using Syncfusion.WinForms.DataGrid;
using System.Collections.Generic;


public partial class MainForm
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

In Blazor, the UI is rendered using Razor components. Components are declared declaratively in markup, and rendering is handled by the Blazor rendering engine.

Instead of rendering immediately, Blazor renders components based on state changes. Whenever the component state changes, the framework updates only the required parts of the UI.

Key characteristics of Blazor rendering include

- UI is declared using Razor markup
- Rendering is based on component state
- UI updates occur automatically when data changes

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/"
@rendermode InteractiveServer

<h3>Orders</h3>

<SfGrid DataSource="@Orders">
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" />
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer" />
        <GridColumn Field="@nameof(Order.Freight)" HeaderText="Freight" Format="N2" />
    </GridColumns>
</SfGrid>

@code {
    private List<Order> Orders = new()
    {
        new Order { OrderID = 10248, CustomerID = "VINET", Freight = 32.38 },
        new Order { OrderID = 10249, CustomerID = "TOMSP", Freight = 11.61 }
    };
}

{% endhighlight %}
{% endtabs %}

## Rendering multiple components

This section explains how multiple components are added and rendered in WinForms and Blazor applications. 

**WinForms: Rendering multiple components**

In WinForms, multiple controls are added to a form programmatically. Each control is placed into the form’s control collection, and the rendering order depends on the sequence in which controls are added.

{% tabs %}
{% highlight c# tabtitle="Form1.cs" %}

this.Controls.Add(dataGrid);
this.Controls.Add(chart);

{% endhighlight %}
{% endtabs %}

**Blazor component: Rendering multiple components**

In Blazor, multiple components are rendered declaratively using Razor markup. Components are displayed in the order they appear in the markup and are arranged using standard web layout rules.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

<SfGrid DataSource="@Orders" />
<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Sales" XName="Month" YName="SalesValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

{% endhighlight %}
{% endtabs %}

## Run the application

Run the application using the following .NET CLI command from the project root directory.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet run

{% endhighlight %}
{% endtabs %}

## Migrating key Syncfusion® components from WinForms to Blazor component mapping

This document provides a comprehensive reference table that maps **WinForms controls** to their **Blazor equivalents**.  

It is intended to help developers **plan, assess, and execute** WinForms to Blazor migrations efficiently.

### Data Management and Grids

| WinForms control | Blazor component | Notes |
|---|---|---|
| [SfDataGrid](https://help.syncfusion.com/windowsforms/datagrid/gettingstarted) | [SfGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) | Supports sorting, filtering, grouping, paging, editing |
| [SfDataPager](https://help.syncfusion.com/windowsforms/datagrid/paging) | [SfGrid](https://blazor.syncfusion.com/documentation/datagrid/paging) | Paging is handled using [GridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PageSettings) |
| [Virtual Grid](https://help.syncfusion.com/windowsforms/grid-control/virtual-grid) | [SfGrid](https://blazor.syncfusion.com/documentation/datagrid/virtual-scrolling) | Virtual scrolling can be enabled by setting [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization) to **true**. |

### Charts and Data Visualization

| WinForms control | Blazor component | Notes |
|---|---|---|
| [ChartControl](https://help.syncfusion.com/windowsforms/chart/getting-started) | [SfChart](https://www.syncfusion.com/blazor-components/blazor-charts) | Supports column, line, bar, pie, area charts |
| [Sparkline](https://help.syncfusion.com/windowsforms/sparkline/gettingstarted) | [SfSparkline](https://www.syncfusion.com/blazor-components/blazor-sparkline) | Lightweight inline charts |
| [Gauge](https://help.syncfusion.com/windowsforms/radial-gauge/overview) | [SfLinearGauge](https://www.syncfusion.com/blazor-components/blazor-linear-gauge), [SfCircularGauge](https://www.syncfusion.com/blazor-components/blazor-circular-gauge) | SVG‑based rendering |
| [Maps](https://help.syncfusion.com/windowsforms/map/getting-started) | [SfMaps](https://www.syncfusion.com/blazor-components/blazor-maps) | Interactive maps |

### Scheduling and Time Management

| WinForms control | Blazor component | Notes |
|---|---|---|
| [ScheduleControl](https://help.syncfusion.com/windowsforms/scheduler/getting-started) | [SfSchedule](https://www.syncfusion.com/blazor-components/blazor-scheduler) | Appointment based scheduling |

### Navigation and Layout controls

| WinForms control | Blazor component | Notes |
|---|---|---|
| [TabControlAdv](https://help.syncfusion.com/windowsforms/tabcontrol/getting-started) | [SfTab](https://www.syncfusion.com/blazor-components/blazor-tabs) | Tab navigation |
| [DockingManager](https://help.syncfusion.com/windowsforms/docking-manager/getting-started) | CSS Layout + Components | Requires layout redesign |
| [SplitContainerAdv](https://help.syncfusion.com/windowsforms/splitcontainer/creating-splitcontaineradv) | [SfSplitter](https://www.syncfusion.com/blazor-components/blazor-splitter) | Horizontal/vertical splitting |

### Editors and Input controls

| WinForms control | Blazor component | Notes |
|---|---|---|
| [TextBoxExt](https://help.syncfusion.com/windowsforms/textbox/getting-started) | [SfTextBox](https://www.syncfusion.com/blazor-components/blazor-textbox) | Text input |
| [SfNumericTextBox](https://help.syncfusion.com/windowsforms/numeric-textbox/gettingstarted) | [SfNumericTextBox](https://www.syncfusion.com/blazor-components/blazor-numeric-textbox) | Numeric input |
| [SfDateTimeEdit](https://help.syncfusion.com/windowsforms/datetimepicker/getting-started) | [SfDateTimePicker](https://www.syncfusion.com/blazor-components/blazor-datetime-picker) | Date and time picker |
| [SfComboBox](https://help.syncfusion.com/windowsforms/combobox/gettingstarted) | [SfComboBox](https://blazor.syncfusion.com/documentation/combobox/getting-started) | Virtualized dropdown |
| [AutoComplete](https://help.syncfusion.com/windowsforms/autocomplete/getting-started) | [SfAutoComplete](https://www.syncfusion.com/blazor-components/blazor-combobox) | Input suggestions |

### Buttons and Commands

| WinForms control | Blazor component | Notes |
|---|---|---|
| [SfButton](https://help.syncfusion.com/windowsforms/button/getting-started) | [SfButton](https://www.syncfusion.com/blazor-components/blazor-button) | Standard button |
| [SplitButton](https://help.syncfusion.com/windowsforms/split-button/getting-started) | [SfSplitButton](https://www.syncfusion.com/blazor-components/blazor-split-button) | Button with dropdown actions |
| [ToggleButton](https://help.syncfusion.com/windowsforms/toggle-button/getting-started) | [SfSwitch](https://www.syncfusion.com/blazor-components/blazor-toggle-switch-button) | Managed by state in Blazor |

### Dialogs and Notifications

| WinForms control | Blazor component | Notes |
|---|---|---|
| [MessageBoxAdv](https://help.syncfusion.com/windowsforms/messagebox/getting-started) | [SfDialog](https://www.syncfusion.com/blazor-components/blazor-diagram) | Async open/close |
| [ProgressBarAdv](https://help.syncfusion.com/windowsforms/progress-bar/creating-progressbaradv) | [SfProgressBar](https://blazor.syncfusion.com/documentation/progress-bar/getting-started) | Progress indicator |

### File, Document, and Spreadsheet controls

| WinForms control | Blazor component | Notes |
|---|---|---|
| [PdfViewerControl](https://help.syncfusion.com/document-processing/pdf/pdf-viewer/winforms/getting-started) | [SfPdfViewer2](https://help.syncfusion.com/document-processing/pdf/pdf-viewer/blazor/getting-started/web-assembly-application) | PDF viewer |
| [Spreadsheet](https://help.syncfusion.com/document-processing/excel/spreadsheet/winforms/getting-started) | [SfSpreadsheet](https://help.syncfusion.com/document-processing/excel/spreadsheet/blazor/getting-started) | Excel‑like UI |

### Diagram and Visual Modeling

| WinForms control | Blazor component | Notes |
|---|---|---|
| [Diagram](https://help.syncfusion.com/windowsforms/diagram/getting-started) | [SfDiagramComponent](https://blazor.syncfusion.com/documentation/diagram/getting-started-with-wasm-app) | Nodes and connectors |

### Lists and Tree controls

| WinForms control | Blazor component | Notes |
|---|---|---|
| [TreeViewAdv](https://help.syncfusion.com/windowsforms/treeview/getting-started) | [SfTreeView](https://www.syncfusion.com/blazor-components/blazor-treeview) | Hierarchical navigation |
| [SfListView](https://help.syncfusion.com/windowsforms/listview/gettingstarted) | [SfListView](https://www.syncfusion.com/blazor-components/blazor-listview) | Virtualized lists |
| [Menu](https://help.syncfusion.com/windowsforms/menu/getting-started) | [SfMenu](https://www.syncfusion.com/blazor-components/blazor-menu-bar) | Menu navigation |

## See also

- [Getting started with Blazor DataGrid in Web App](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app)
- [Getting started with Blazor Components](https://blazor.syncfusion.com/documentation/introduction)
- [Getting started with Syncfusion® Essential® Windows Forms](https://help.syncfusion.com/windowsforms/overview)

