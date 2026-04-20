---
layout: post
title: Migrating from WPF to Blazor | Syncfusion
description: Guide to migrating Syncfusion WPF apps to Blazor, covering key components and detailed DataGrid migration.
platform: Blazor
component: Common
documentation: ug
---

# Migrating from WPF to Blazor

## Overview

Migrating enterprise applications from **[WPF (Windows Presentation Foundation)](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/overview/)** to **[Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/)** is a significant architectural transition, moving from a rich, XAML-based desktop client framework to a component-driven, cross-platform web framework running on .NET. This guide provides a **structured, step-by-step migration path** for **[Syncfusion WPF components](https://www.syncfusion.com/wpf-controls)** to their **[Syncfusion Blazor equivalents](https://www.syncfusion.com/blazor-components)**, developed using **[Visual Studio Code](https://code.visualstudio.com/)**.

This document covers:
* Architectural differences between WPF and Blazor
* Initial rendering setup for major Syncfusion components
* Detailed DataGrid migration with feature parity mapping

### Why migrate from WPF to Blazor?

| Dimension | WPF | Blazor |
|---|---|---|
| **Runtime** | Windows-only (.NET Framework / .NET) | Cross-platform (browser, desktop via MAUI Hybrid) |
| **Deployment** | Per-machine installation | Browser or server deployment |
| **UI technology** | XAML + Code-behind | Razor components (HTML + C#) |
| **Communication model** | Direct in-process | SignalR (Server) / WebAssembly |
| **Modern tooling** | Visual Studio (recommended) | Visual Studio Code, Visual Studio |
| **Scalability** | Desktop scalability | Web-scale, multi-user |
| **Updates** | ClickOnce / MSIX rollout | Redeploy once; all users get latest instantly |
| **Cross-browser access** | Not applicable | Chrome, Edge, Firefox, Safari |

### Key architectural differences

| Concept | WPF | Blazor Server |
|---|---|---|
| **UI definition** | XAML (`.xaml`) | Razor (`.razor`) |
| **Code-behind / logic** | `.xaml.cs` or ViewModel | `@code {}` block or `.razor.cs` partial class |
| **Pattern** | MVVM (strongly recommended) | Component-based (MVVM optional) |
| **Data context** | `DataContext = ViewModel` | `@bind`, `[Parameter]`, cascading values |
| **State management** | ViewModel + `INotifyPropertyChanged` | Component state + `StateHasChanged()` |
| **Dependency injection** | Unity, Prism, MEF | Built-in [`IServiceCollection`](https://learn.microsoft.com/en-us/dotnet/api/microsoft.extensions.dependencyinjection.iservicecollection) |
| **Navigation** | WPF `Frame` / Prism `RegionManager` | [`NavigationManager`](https://learn.microsoft.com/en-us/aspnet/core/blazor/fundamentals/routing) + `@page` routing |
| **Render mode** | Native rendering pipeline | [`@rendermode InteractiveServer`](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes) (Blazor 8+) |

## Development environment setup

### Prerequisites for Blazor

* [.NET 8 SDK or later](https://dotnet.microsoft.com/en-us/download/dotnet)
* [Visual Studio Code](https://code.visualstudio.com/) with [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension

**Verify installation:**

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet --version   # Expected: 8.0.x or later
dotnet new list blazor

{% endhighlight %}
{% endtabs %}

## Project structure comparison

### WPF project structure

```
MyWpfApp/
├── App.xaml / App.xaml.cs
├── MainWindow.xaml / MainWindow.xaml.cs
├── ViewModels/OrderViewModel.cs
├── Models/Order.cs
├── Views/OrderView.xaml
├── Services/OrderService.cs
└── MyWpfApp.csproj
```

### Blazor Server project structure (.NET 8)

```
MyBlazorApp/
├── Program.cs                        ← Entry point + DI (replaces App.xaml.cs)
├── Components/
│   ├── App.razor                     ← Root component (replaces App.xaml)
│   ├── Routes.razor                  ← Router (replaces WPF navigation)
│   ├── _Imports.razor                ← Global using directives
│   ├── Layout/
│   │   ├── MainLayout.razor          ← Shell layout (replaces MainWindow.xaml)
│   │   └── NavMenu.razor
│   └── Pages/
│       └── Orders.razor              ← Page component (replaces OrderView.xaml)
├── Models/Order.cs                   ← No changes required
├── Services/OrderService.cs          ← Register via DI
├── wwwroot/css/app.css               ← Global styles (replaces ResourceDictionary)
└── MyBlazorApp.csproj
```

### One-to-one structural mapping

| WPF artifact | Blazor equivalent | Notes |
|---|---|---|
| `App.xaml` | `Components/App.razor` | Root application definition |
| `App.xaml.cs` | `Program.cs` | Startup and DI configuration |
| `MainWindow.xaml` | `Components/Layout/MainLayout.razor` | Shell/layout component |
| `Views/*.xaml` | `Components/Pages/*.razor` | Page views with `@page` routing |
| `ViewModels/*.cs` | `@code {}` or `*.razor.cs` | Logic layer |
| `Models/*.cs` | `Models/*.cs` | **No change required** |
| `Services/*.cs` | `Services/*.cs` | Register via `IServiceCollection` |
| `ResourceDictionary` | `wwwroot/css/*.css` | Global styles |
| `UserControl` | Razor component (`.razor`) | Reusable UI components |
| `ICommand` / `RelayCommand` | C# method in `@code {}` | Direct event binding |
| `INotifyPropertyChanged` | `StateHasChanged()` | Triggers re-render |

## Getting started: project creation

### Creating a Blazor Server project in VS Code

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet new blazor -n MyBlazorApp --interactivity Server
cd MyBlazorApp
code .
dotnet watch   # Hot reload during development

{% endhighlight %}
{% endtabs %}

> N> The `--interactivity Server` flag configures [SignalR](https://learn.microsoft.com/en-us/aspnet/core/signalr/introduction)-based interactivity—the closest equivalent to WPF's server-side execution model.

## Migrating key Syncfusion components from WPF to Blazor

This section provides **step-by-step migration guidance** for the following six Syncfusion components, with side-by-side WPF and Blazor code examples:

1. **[DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid)** - Tabular data display with sorting, filtering, editing, and grouping
2. **[TreeGrid](https://www.syncfusion.com/blazor-components/blazor-tree-grid)** - Hierarchical data display in a grid format
3. **[Charts](https://www.syncfusion.com/blazor-components/blazor-charts)** - Data visualization with various chart types
4. **[Scheduler](https://www.syncfusion.com/blazor-components/blazor-scheduler)** - Calendar and appointment scheduling
5. **[Diagram](https://www.syncfusion.com/blazor-components/blazor-diagram)** - Visual diagramming and flowchart creation
6. **[RichTextEditor](https://www.syncfusion.com/blazor-components/blazor-rich-text-editor)** - Rich text editing with formatting capabilities

Each component section includes package installation, theme setup, service registration, and basic rendering code for both platforms.

### 1. DataGrid

For detailed explanation, refer to the [WPF DataGrid getting started guide](https://help.syncfusion.com/wpf/datagrid/getting-started) and [Blazor DataGrid getting started guide](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-server-app).

#### Migration overview

| Aspect | WPF (SfDataGrid) | Blazor (SfGrid / SfGrid<TValue>) |
|---|---:|---|
| Package | `Syncfusion.SfGrid.WPF` | `Syncfusion.Blazor.Grid` |
| Namespace / usage | XAML: `xmlns:syncfusion="clr-namespace:..."` | Razor: `@using Syncfusion.Blazor.Grids` |
| Component declaration | `<syncfusion:SfDataGrid>` (XAML) | `<SfGrid>` / `<SfGrid TValue="T">` (Razor) |
| Data binding | `ItemsSource` / DataContext / INotifyPropertyChanged | `DataSource="@..."` + component state (`OnInitialized[Async]`, `StateHasChanged()`) |
| Collection type | `ObservableCollection<T>` for change notifications | `List<T>` / `IEnumerable<T>`; UI updates via re-render or StateHasChanged |
| Columns | Typed columns (GridTextColumn, GridNumericColumn, GridTemplateColumn) | `GridColumn` / `GridTemplateColumn`, `Field="@nameof(...)"`, `Format`/`EditType` |
| Templates | XAML DataTemplate | Razor <Template> sections |
| Editing & API | XAML boolean props, code‑behind events, direct object refs (x:Name) | `GridEditSettings`, `GridEvents`, EventCallback<T>, `@ref` async APIs |
| Events & commands | CLR events / ICommand | EventCallback-based handlers (async) |
| Theming & assets | ResourceDictionary / SfSkinManager | CSS theme files + Syncfusion JS; register AddSyncfusionBlazor() |
| Paging / virtualization | SfDataPager / native virtualization | `GridPageSettings`, `EnableVirtualization`, `SfDataManager` for remote ops |
| Lifecycle & refs | constructor / Loaded event / x:Name | `OnInitialized[Async]`, DI, `@ref` and async methods |

#### Step-by-step migration

##### Step 1: Package installation

Install the DataGrid NuGet package to enable grid functionality in your project.

**WPF approach:**

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.SfGrid.WPF

{% endhighlight %}
{% endtabs %}

**Blazor equivalent:**

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Grid -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

> **Migration note:** Blazor requires separate theme package. WPF themes are embedded in component package.

##### Step 2: Theme 

Configure the visual theme by linking CSS stylesheets (Blazor) or resource dictionaries (WPF).

**WPF approach (MainWindow.xaml):**

{% tabs %}
{% highlight xml tabtitle="MainWindow.xaml" %}

<Window x:Class="GettingStarted.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:syncfusion="http://schemas.syncfusion.com/wpf"
        xmlns:syncfusionskin="clr-namespace:Syncfusion.SfSkinManager;assembly=Syncfusion.SfSkinManager.WPF"
        syncfusionskin:SfSkinManager.Theme="{syncfusionskin:SkinManagerExtension ThemeName=FluentLight}">
</Window>

{% endhighlight %}
{% endtabs %}

**Blazor equivalent (App.razor):**

{% tabs %}
{% highlight html tabtitle="App.razor" %}

<link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

> **Migration note:** WPF applies themes using `SfSkinManager.Theme` attached property at Window level; Blazor requires CSS file references in `App.razor`. Blazor also requires JavaScript interop file for component interactivity.

##### Step 3: Service registration (Blazor-specific)

Register Syncfusion services in the dependency injection container to enable component functionality.

**Blazor requirement:**

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}

using Syncfusion.Blazor;

builder.Services.AddSyncfusionBlazor();

{% endhighlight %}
{% endtabs %}

**Additional step (Blazor only):**

{% tabs %}
{% highlight razor tabtitle="_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

{% endhighlight %}
{% endtabs %}

> **Migration note:** WPF doesn't require this step. Blazor uses dependency injection for service registration and global using directives.

##### Step 4: Component rendering

Add the DataGrid component to your page with data binding and column definitions.

**WPF approach (MainWindow.xaml):**

{% tabs %}
{% highlight xml tabtitle="MainWindow.xaml" %}

<Window x:Class="WpfDataGridApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:syncfusion="clr-namespace:Syncfusion.UI.Xaml.Grid;assembly=Syncfusion.SfGrid.WPF"
        xmlns:syncfusionskin="clr-namespace:Syncfusion.SfSkinManager;assembly=Syncfusion.SfSkinManager.WPF"
        syncfusionskin:SfSkinManager.Theme="{syncfusionskin:SkinManagerExtension ThemeName=FluentLight}"
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

> **Key migration differences:**

> - `ItemsSource` becomes `DataSource`
> - `AutoGenerateColumns` not recommended; define columns explicitly
> - Add `@rendermode InteractiveServer` for SignalR interactivity
> - Data loading moved to `OnInitializedAsync()` lifecycle method

### 2. TreeGrid

For detailed explanation, refer to the [WPF TreeGrid getting started guide](https://help.syncfusion.com/wpf/treegrid/getting-started) and [Blazor TreeGrid getting started guide](https://blazor.syncfusion.com/documentation/treegrid/getting-started).

#### Migration overview

| Aspect | WPF (SfTreeGrid) | Blazor (SfTreeGrid) |
|---|---:|---|
| Package | `Syncfusion.SfGrid.WPF` | `Syncfusion.Blazor.TreeGrid` |
| Namespace | XAML: `xmlns:syncfusion` | Razor: `@using Syncfusion.Blazor.TreeGrid` |
| Component declaration | `<syncfusion:SfTreeGrid>` (XAML) | `<SfTreeGrid>` (Razor) |
| Hierarchy mapping | `ChildPropertyName` / `ParentPropertyName` (+ SelfRelationRootValue sentinel) | `IdMapping` + `ParentIdMapping` (nullable parent IDs preferred) |
| Data shape | Nested children collections OR self‑referencing flat lists | Optimized for flat self‑referencing lists; nested requires mapping/flattening |
| Tree column | Automatic tree UI bound to hierarchical column | `TreeColumnIndex` to specify expand/collapse column |
| Columns & templates | TreeGridTextColumn, TreeGridNumericColumn | `TreeGridColumn` + Razor templates |
| Expand/collapse state | `IsExpanded` on data items | Programmatic via `ExpandedRowIndexes` / API |
| Virtualization / performance | Native WPF rendering | Virtual scrolling / load‑on‑demand; set Height for virtualization |
| Events | CLR events | EventCallback-based GridEvents |

#### Step-by-step migration

##### Step 1: Package installation

Install the TreeGrid NuGet package to enable hierarchical data display in grid format.

**WPF approach:**

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.SfGrid.WPF

{% endhighlight %}
{% endtabs %}

**Blazor equivalent:**

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.TreeGrid -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

> **Migration note:** TreeGrid is included in WPF Grid package but requires separate package in Blazor.

##### Step 2: Theme configuration

Configure the visual theme by linking CSS stylesheets (Blazor) or resource dictionaries (WPF).

**WPF approach (MainWindow.xaml):**

{% tabs %}
{% highlight xml tabtitle="MainWindow.xaml" %}

<Window x:Class="GettingStarted.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:syncfusion="http://schemas.syncfusion.com/wpf"
        xmlns:syncfusionskin="clr-namespace:Syncfusion.SfSkinManager;assembly=Syncfusion.SfSkinManager.WPF"
        syncfusionskin:SfSkinManager.Theme="{syncfusionskin:SkinManagerExtension ThemeName=FluentLight}">
</Window>

{% endhighlight %}
{% endtabs %}

**Blazor equivalent (App.razor):**

{% tabs %}
{% highlight html tabtitle="App.razor" %}

<link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

##### Step 3: Service registration (Blazor-specific)

Register Syncfusion services in the dependency injection container to enable component functionality.

**Blazor requirement:**

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}

using Syncfusion.Blazor;

builder.Services.AddSyncfusionBlazor();

{% endhighlight %}
{% endtabs %}

**Additional step (Blazor only):**

{% tabs %}
{% highlight razor tabtitle="_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.TreeGrid

{% endhighlight %}
{% endtabs %}

##### Step 4: Component rendering

Add the TreeGrid component with self-referencing data structure using IdMapping and ParentIdMapping.

**WPF approach (MainWindow.xaml):**

{% tabs %}
{% highlight xml tabtitle="MainWindow.xaml" %}

<Window x:Class="WpfTreeGridApp.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:syncfusion="clr-namespace:Syncfusion.UI.Xaml.TreeGrid;assembly=Syncfusion.SfGrid.WPF"
        xmlns:syncfusionskin="clr-namespace:Syncfusion.SfSkinManager;assembly=Syncfusion.SfSkinManager.WPF"
        syncfusionskin:SfSkinManager.Theme="{syncfusionskin:SkinManagerExtension ThemeName=FluentLight}"
        Title="Tree Grid - Employees" Height="450" Width="800">

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

> **Key migration differences:**
> - `ChildPropertyName` → `IdMapping` + `ParentIdMapping`
> - Blazor uses flat collection with self-referencing IDs instead of nested objects
> - `TreeColumnIndex` specifies which column displays the tree structure
> - Columns must be defined explicitly

### 3. Charts

For detailed explanation, refer to the [WPF Charts getting started guide](https://help.syncfusion.com/wpf/charts/getting-started) and [Blazor Charts getting started guide](https://blazor.syncfusion.com/documentation/chart/getting-started).

#### Migration overview

| Aspect | WPF (SfChart) | Blazor (SfChart) |
|---|---:|---|
| Package | `Syncfusion.SfChart.WPF` | `Syncfusion.Blazor.Charts` |
| Namespace | XAML: `xmlns:chart` | Razor: `@using Syncfusion.Blazor.Charts` |
| Component model | Nested XAML elements (PrimaryAxis, Series elements) | Razor components (ChartPrimaryXAxis, ChartSeries, ChartSeriesCollection) |
| Axis & series declaration | Axis elements (CategoryAxis, NumericalAxis), series types via element names | Axis components with `ValueType`, `ChartSeries` with `Type="ChartSeriesType.*"` |
| Data binding | `ItemsSource` + `XBindingPath` / `YBindingPath` | `DataSource` + `XName` / `YName` |
| Markers / adornments | `AdornmentsInfo` nested config | `ChartMarker`, `ChartTooltipSettings` components |
| Tooltip & animation | Series‑level properties and templates | Centralized `ChartTooltipSettings`, `ChartSeriesAnimation` component |
| Responsiveness | Window sizing | CSS-based sizing (Width="100%") and responsive containers |
| Events | CLR events | EventCallback handlers (OnPointClick, TooltipRender, etc.) |

#### Step-by-step migration

##### Step 1: Package installation

Install the Charts NuGet package to enable data visualization capabilities.

**WPF approach:**

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.SfChart.WPF

{% endhighlight %}
{% endtabs %}

**Blazor equivalent:**

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Charts -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

##### Step 2: Theme configuration

Configure the visual theme by linking CSS stylesheets (Blazor) or resource dictionaries (WPF).

**WPF approach (MainWindow.xaml):**

{% tabs %}
{% highlight xml tabtitle="MainWindow.xaml" %}

<Window x:Class="GettingStarted.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:syncfusion="http://schemas.syncfusion.com/wpf"
        xmlns:syncfusionskin="clr-namespace:Syncfusion.SfSkinManager;assembly=Syncfusion.SfSkinManager.WPF"
        syncfusionskin:SfSkinManager.Theme="{syncfusionskin:SkinManagerExtension ThemeName=FluentLight}">
</Window>

{% endhighlight %}
{% endtabs %}

**Blazor equivalent (App.razor):**

{% tabs %}
{% highlight html tabtitle="App.razor" %}

<link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

##### Step 3: Service registration (Blazor-specific)

Register Syncfusion services in the dependency injection container to enable component functionality.

**Blazor requirement:**

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}

using Syncfusion.Blazor;

builder.Services.AddSyncfusionBlazor();

{% endhighlight %}
{% endtabs %}

**Additional step (Blazor only):**

{% tabs %}
{% highlight razor tabtitle="_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Charts

{% endhighlight %}
{% endtabs %}

##### Step 4: Component rendering

Add the Chart component with axis configuration, series definition, and data binding.

**WPF approach (MainWindow.xaml):**

{% tabs %}
{% highlight xml tabtitle="MainWindow.xaml" %}

<Window x:Class="WpfChart.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:syncfusion="http://schemas.syncfusion.com/wpf"
        xmlns:syncfusionskin="clr-namespace:Syncfusion.SfSkinManager;assembly=Syncfusion.SfSkinManager.WPF"
        syncfusionskin:SfSkinManager.Theme="{syncfusionskin:SkinManagerExtension ThemeName=FluentLight}"
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

For detailed explanation, refer to the [WPF Scheduler getting started guide](https://help.syncfusion.com/wpf/scheduler/getting-started) and [Blazor Scheduler getting started guide](https://blazor.syncfusion.com/documentation/scheduler/getting-started).

#### Migration overview

| Aspect | WPF (SfScheduler) | Blazor (SfSchedule<TValue>) |
|---|---:|---|
| Package | `Syncfusion.SfSchedule.WPF` | `Syncfusion.Blazor.Schedule` |
| Namespace | XAML: `xmlns:syncfusion` | Razor: `@using Syncfusion.Blazor.Schedule` |
| Component declaration | `<syncfusion:SfScheduler>` (XAML, ScheduleAppointment model) | `<SfSchedule TValue="TModel">` (Razor, generic model) |
| Appointment model | `ScheduleAppointment` / SchedulerAppointmentCollection | Custom model type `TValue` + explicit `ScheduleEventSettings` field mappings |
| Views / configuration | `ViewType` enum (single prop) | `ScheduleViews` collection with `ScheduleView` elements |
| Field mapping | Implicit for ScheduleAppointment or mapping props | Explicit mapping (`SubjectField`, `StartTimeField`, `EndTimeField`, etc.) |
| Templates & editors | XAML DataTemplate / built‑in editors | `AppointmentTemplate`, `TimeSlotTemplate` Razor templates; `RecurrenceEditor` component |
| Resources & grouping | `ResourceCollection` + mapping | `ScheduleResources` / `ScheduleResource` components |
| Events & callbacks | CLR events | EventCallback-based events (OnActionBegin, OnCellClick) |
| Data & performance | Native large‑set handling | Virtualization / lazy loading recommended for large datasets |

#### Step-by-step migration

##### Step 1: Package installation

Install the Scheduler NuGet package to enable calendar and appointment scheduling features.

**WPF approach:**

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.SfScheduler.WPF

{% endhighlight %}
{% endtabs %}

**Blazor equivalent:**

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Schedule -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

##### Step 2: Theme configuration

Configure the visual theme by linking CSS stylesheets (Blazor) or resource dictionaries (WPF).

**WPF approach (MainWindow.xaml):**

{% tabs %}
{% highlight xml tabtitle="MainWindow.xaml" %}

<Window x:Class="GettingStarted.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:syncfusion="http://schemas.syncfusion.com/wpf"
        xmlns:syncfusionskin="clr-namespace:Syncfusion.SfSkinManager;assembly=Syncfusion.SfSkinManager.WPF"
        syncfusionskin:SfSkinManager.Theme="{syncfusionskin:SkinManagerExtension ThemeName=FluentLight}">
</Window>

{% endhighlight %}
{% endtabs %}

**Blazor equivalent (App.razor):**

{% tabs %}
{% highlight html tabtitle="App.razor" %}

<link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

##### Step 3: Service registration (Blazor-specific)

Register Syncfusion services in the dependency injection container to enable component functionality.

**Blazor requirement:**

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}

using Syncfusion.Blazor;

builder.Services.AddSyncfusionBlazor();

{% endhighlight %}
{% endtabs %}

**Additional step (Blazor only):**

{% tabs %}
{% highlight razor tabtitle="_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Schedule

{% endhighlight %}
{% endtabs %}

##### Step 4: Component rendering

Add the Scheduler component with view configuration, appointment data binding, and field mappings.

**WPF approach (MainWindow.xaml):**

{% tabs %}
{% highlight xml tabtitle="MainWindow.xaml" %}

<Window x:Class="WpfScheduler.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:syncfusion="clr-namespace:Syncfusion.UI.Xaml.Scheduler;assembly=Syncfusion.SfScheduler.WPF"
        xmlns:syncfusionskin="clr-namespace:Syncfusion.SfSkinManager;assembly=Syncfusion.SfSkinManager.WPF"
        syncfusionskin:SfSkinManager.Theme="{syncfusionskin:SkinManagerExtension ThemeName=FluentLight}"
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
|---|---:|---|
| Package | `Syncfusion.SfDiagram.WPF` | `Syncfusion.Blazor.Diagram` |
| Namespace | XAML: `xmlns:syncfusion` | Razor: `@using Syncfusion.Blazor.Diagram` |
| Node definition | `NodeCollection` in XAML (declarative) | `DiagramObjectCollection<Node>` in code (`@code` / OnInitialized) |
| Connector definition | `ConnectorCollection` in XAML | `DiagramObjectCollection<Connector>` in code |
| Shape specification | XAML Shape enums / ViewModels | Shape objects (FlowShape, Path) and `ShapeStyle` objects in code |
| Positioning | Attributes `OffsetX`, `OffsetY` in XAML | Properties set in Node objects (OffsetX/OffsetY) in code |
| Ports & constraints | Declared in XAML | Programmatic `Ports` + `NodeConstraints` enum flags |
| Layouts | `LayoutManager` XAML settings | `DiagramLayout` component with `LayoutType` and options |
| Data binding / auto‑generate | `DataSourceSettings` mapping in XAML | `DataSourceSettings` + `SfDataManager` support; code mapping required |
| Events & serialization | Routed events, Save/Load methods | EventCallback callbacks; `SaveDiagram()` / `LoadDiagram()` async JSON APIs |

#### Step-by-step migration

##### Step 1: Package installation

Install the Diagram NuGet package to enable visual diagramming and flowchart creation.

**WPF approach:**

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.SfDiagram.WPF

{% endhighlight %}
{% endtabs %}

**Blazor equivalent:**

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Diagram -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

##### Step 2: Theme configuration

Configure the visual theme by linking CSS stylesheets (Blazor) or resource dictionaries (WPF).

**WPF approach (MainWindow.xaml):**

{% tabs %}
{% highlight xml tabtitle="MainWindow.xaml" %}

<Window x:Class="GettingStarted.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:syncfusion="http://schemas.syncfusion.com/wpf"
        xmlns:syncfusionskin="clr-namespace:Syncfusion.SfSkinManager;assembly=Syncfusion.SfSkinManager.WPF"
        syncfusionskin:SfSkinManager.Theme="{syncfusionskin:SkinManagerExtension ThemeName=FluentLight}">
</Window>

{% endhighlight %}
{% endtabs %}

**Blazor equivalent (App.razor):**

{% tabs %}
{% highlight html tabtitle="App.razor" %}

<link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

##### Step 3: Service registration (Blazor-specific)

Register Syncfusion services in the dependency injection container to enable component functionality.

**Blazor requirement:**

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}

using Syncfusion.Blazor;

builder.Services.AddSyncfusionBlazor();

{% endhighlight %}
{% endtabs %}

**Additional step (Blazor only):**

{% tabs %}
{% highlight razor tabtitle="_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Diagram

{% endhighlight %}
{% endtabs %}

##### Step 4: Component rendering

Add the Diagram component and define nodes and connectors programmatically in the code block.

**WPF approach (MainWindow.xaml):**

{% tabs %}
{% highlight xml tabtitle="MainWindow.xaml" %}

<Window x:Class="WpfDiagram.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:syncfusion="http://schemas.syncfusion.com/wpf"
        xmlns:syncfusionskin="clr-namespace:Syncfusion.SfSkinManager;assembly=Syncfusion.SfSkinManager.WPF"
        syncfusionskin:SfSkinManager.Theme="{syncfusionskin:SkinManagerExtension ThemeName=FluentLight}"
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

For detailed explanation, refer to the [WPF RichTextBox getting started guide](https://help.syncfusion.com/wpf/richtextbox/getting-started) and [Blazor RichTextEditor getting started guide](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started).

#### Migration overview

| Aspect | WPF (SfRichTextBoxAdv) | Blazor (SfRichTextEditor) |
|---|---:|---|
| Package | `Syncfusion.SfRichTextBoxAdv.WPF` | `Syncfusion.Blazor.RichTextEditor` |
| Namespace | XAML: `xmlns:syncfusion` | Razor: `@using Syncfusion.Blazor.RichTextEditor` |
| Component name | `SfRichTextBoxAdv` (Document model) | `SfRichTextEditor` (HTML value model) |
| Content model | `Document` / DocumentAdv (DOCX/RTF native) | HTML string via `Value` / `@bind-Value` |
| Load / Save | Stream-based Load/Save (DOCX/RTF/HTML) | Value string; import/export via converters or server-side processing |
| Toolbar & UI | RibbonBar + command bindings | `ToolbarSettings` with configurable items; Razor templates for dialogs |
| Images | Embedded images or file paths | Base64 or URLs; requires image upload endpoint (ImageSettings) |
| Spell-check & print | Native spell checker; direct printing | Browser spell-check; print via browser APIs / PrintAsync |
| Templates / dialogs | XAML DataTemplates | Razor templates + JS interop for custom dialogs |
| Undo/Redo & keyboard | Native undo stack & full OS shortcuts | Built-in undo/redo; browser shortcut limitations |
| Performance | Native large‑doc support | Browser limits for very large HTML; consider server conversion/pagination |

#### Step-by-step migration

##### Step 1: Package installation

Install the RichTextEditor NuGet package to enable rich text editing with formatting capabilities.

**WPF approach:**

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.SfRichTextBoxAdv.WPF

{% endhighlight %}
{% endtabs %}

**Blazor equivalent:**

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.RichTextEditor -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

##### Step 2: Theme configuration

Configure the visual theme by linking CSS stylesheets (Blazor) or resource dictionaries (WPF).

**WPF approach (MainWindow.xaml):**

{% tabs %}
{% highlight xml tabtitle="MainWindow.xaml" %}

<Window x:Class="GettingStarted.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:syncfusion="http://schemas.syncfusion.com/wpf"
        xmlns:syncfusionskin="clr-namespace:Syncfusion.SfSkinManager;assembly=Syncfusion.SfSkinManager.WPF"
        syncfusionskin:SfSkinManager.Theme="{syncfusionskin:SkinManagerExtension ThemeName=FluentLight}">
</Window>

{% endhighlight %}
{% endtabs %}

**Blazor equivalent (App.razor):**

{% tabs %}
{% highlight html tabtitle="App.razor" %}

<link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

##### Step 3: Service registration (Blazor-specific)

Register Syncfusion services in the dependency injection container to enable component functionality.

**Blazor requirement:**

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}

using Syncfusion.Blazor;

builder.Services.AddSyncfusionBlazor();

{% endhighlight %}
{% endtabs %}

**Additional step (Blazor only):**

{% tabs %}
{% highlight razor tabtitle="_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.RichTextEditor

{% endhighlight %}
{% endtabs %}

##### Step 4: Component rendering

Add the RichTextEditor component with toolbar configuration and content binding.

**WPF approach (MainWindow.xaml):**

{% tabs %}
{% highlight xml tabtitle="MainWindow.xaml" %}

<Window x:Class="WpfRichText.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:syncfusion="clr-namespace:Syncfusion.Windows.Controls.RichTextBoxAdv;assembly=Syncfusion.SfRichTextBoxAdv.WPF"
        xmlns:syncfusionskin="clr-namespace:Syncfusion.SfSkinManager;assembly=Syncfusion.SfSkinManager.WPF"
        syncfusionskin:SfSkinManager.Theme="{syncfusionskin:SkinManagerExtension ThemeName=FluentLight}"
        Title="RichTextEditor" Height="500" Width="800">

    <Grid>
        <Grid.RowDefinitions>
            <RowDefinition Height="Auto" />
            <RowDefinition Height="*" />
        </Grid.RowDefinitions>

        <syncfusion:RibbonBar Grid.Row="0">
            <syncfusion:RibbonTab Caption="Home" IsChecked="True">
                <syncfusion:RibbonBar Items="{Binding ElementName=richTextBoxAdv, Path=RibbonCommands}" />
            </syncfusion:RibbonTab>
        </syncfusion:RibbonBar>

        <syncfusion:SfRichTextBoxAdv x:Name="richTextBoxAdv" Grid.Row="1" />
    </Grid>

</Window>

{% endhighlight %}
{% highlight cs tabtitle="MainWindow.xaml.cs" %}

using Syncfusion.Windows.Controls.RichTextBoxAdv;
using System.IO;
using System.Text;
using System.Windows;

namespace WpfRichText
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
            string htmlContent = "<p><b>Welcome!</b> Start editing your document here...</p>";
            byte[] htmlBytes = Encoding.UTF8.GetBytes(htmlContent);

            using (MemoryStream stream = new MemoryStream(htmlBytes))
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


### Initial rendering summary

| Component | WPF NuGet Package | Blazor NuGet Package | WPF Getting Started | Blazor Getting Started |
|---|---|---|---|---|
| **DataGrid** | `Syncfusion.SfGrid.WPF` | `Syncfusion.Blazor.Grid` | [Link](https://help.syncfusion.com/wpf/datagrid/getting-started) | [Link](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-server-app) |
| **TreeGrid** | `Syncfusion.SfGrid.WPF` | `Syncfusion.Blazor.TreeGrid` | [Link](https://help.syncfusion.com/wpf/treegrid/getting-started) | [Link](https://blazor.syncfusion.com/documentation/treegrid/getting-started) |
| **Charts** | `Syncfusion.SfChart.WPF` | `Syncfusion.Blazor.Charts` | [Link](https://help.syncfusion.com/wpf/charts/getting-started) | [Link](https://blazor.syncfusion.com/documentation/chart/getting-started) |
| **Scheduler** | `Syncfusion.SfSchedule.WPF` | `Syncfusion.Blazor.Schedule` | [Link](https://help.syncfusion.com/wpf/scheduler/getting-started) | [Link](https://blazor.syncfusion.com/documentation/scheduler/getting-started) |
| **Diagram** | `Syncfusion.SfDiagram.WPF` | `Syncfusion.Blazor.Diagram` | [Link](https://help.syncfusion.com/wpf/diagram/getting-started) | [Link](https://blazor.syncfusion.com/documentation/diagram/getting-started) |
| **RichTextEditor** | `Syncfusion.SfRichTextBoxAdv.WPF` | `Syncfusion.Blazor.RichTextEditor` | [Link](https://help.syncfusion.com/wpf/richtextbox/getting-started) | [Link](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started) |

> N> All Blazor components require `Syncfusion.Blazor.Themes` for theming and `@rendermode InteractiveServer` (or another interactive mode) for full interactivity.

## Detailed DataGrid migration

The following sections provide **in-depth migration guidance** for the **Syncfusion DataGrid**, covering data binding, columns, editing, sorting, filtering, paging, events, styling, and performance optimization.

### Data binding

**WPF implementation:**

{% tabs %}
{% highlight c# tabtitle="OrderViewModel.cs" %}

public class OrderViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Order> _orders;
    public ObservableCollection<Order> Orders
    {
        get => _orders;
        set { _orders = value; OnPropertyChanged(); }
    }
    
    public OrderViewModel()
    {
        Orders = new ObservableCollection<Order>(OrderService.GetOrders());
    }
    
    public event PropertyChangedEventHandler PropertyChanged;
    protected void OnPropertyChanged([CallerMemberName] string name = null)
        => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
}

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight xml tabtitle="OrderView.xaml" %}

<syncfusion:SfDataGrid ItemsSource="{Binding Orders}" AutoGenerateColumns="False">
    <syncfusion:SfDataGrid.Columns>
        <syncfusion:GridTextColumn HeaderText="Order ID" MappingName="OrderID" />
        <syncfusion:GridTextColumn HeaderText="Customer" MappingName="CustomerID" />
        <syncfusion:GridNumericColumn HeaderText="Freight" MappingName="Freight" />
    </syncfusion:SfDataGrid.Columns>
</syncfusion:SfDataGrid>

{% endhighlight %}
{% endtabs %}

**Blazor implementation:**

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

@page "/orders"
@rendermode InteractiveServer

<SfGrid TValue="Order" DataSource="@Orders" Height="400">
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" Width="100" />
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer ID" Width="150" />
        <GridColumn Field="@nameof(Order.Freight)" HeaderText="Freight" Format="C2" Width="120" />
    </GridColumns>
</SfGrid>

@code {
    private List<Order> Orders = new List<Order>
    {
        new Order { OrderID = 10248, CustomerID = "VINET", Freight = 32.38 },
        new Order { OrderID = 10249, CustomerID = "TOMSP", Freight = 11.61 },
        new Order { OrderID = 10250, CustomerID = "HANAR", Freight = 65.83 }
    };

    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public double Freight { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

**Key migration changes:**
- `ItemsSource` → `DataSource`
- `ObservableCollection<T>` → `List<T>` or `IEnumerable<T>`
- `INotifyPropertyChanged` → `StateHasChanged()`
- `MappingName` → `Field="@nameof(...)"`

### Column types and formatting

**WPF implementation:**

{% tabs %}
{% highlight xml tabtitle="OrderView.xaml" %}

<syncfusion:SfDataGrid ItemsSource="{Binding Orders}">
    <syncfusion:SfDataGrid.Columns>
        <syncfusion:GridTextColumn MappingName="OrderID" HeaderText="Order ID" />
        <syncfusion:GridNumericColumn MappingName="Freight" HeaderText="Freight" NumberDecimalDigits="2" />
        <syncfusion:GridCurrencyColumn MappingName="Amount" HeaderText="Amount" CurrencyDecimalDigits="2" />
        <syncfusion:GridDateTimeColumn MappingName="OrderDate" HeaderText="Order Date" />
        <syncfusion:GridCheckBoxColumn MappingName="IsShipped" HeaderText="Shipped" />
    </syncfusion:SfDataGrid.Columns>
</syncfusion:SfDataGrid>

{% endhighlight %}
{% endtabs %}

**Blazor implementation:**

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

<SfGrid TValue="Order" DataSource="@Orders">
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" Width="120" />
        <GridColumn Field="@nameof(Order.Freight)" HeaderText="Freight" Format="N2" Width="120" />
        <GridColumn Field="@nameof(Order.Amount)" HeaderText="Amount" Format="C2" Width="120" />
        <GridColumn Field="@nameof(Order.OrderDate)" HeaderText="Order Date" Format="d" Type="ColumnType.Date" Width="150" />
        <GridColumn Field="@nameof(Order.IsShipped)" HeaderText="Shipped" Type="ColumnType.Boolean" Width="100" />
    </GridColumns>
</SfGrid>

{% endhighlight %}
{% endtabs %}

**Column type mappings:**
- `GridTextColumn` → `GridColumn` (default)
- `GridNumericColumn` → `GridColumn` with `Format="N2"`
- `GridCurrencyColumn` → `GridColumn` with `Format="C2"`
- `GridDateTimeColumn` → `GridColumn` with `Type="ColumnType.Date"`
- `GridCheckBoxColumn` → `GridColumn` with `Type="ColumnType.Boolean"`

### Template columns

**WPF implementation:**

{% tabs %}
{% highlight xml tabtitle="OrderView.xaml" %}

<syncfusion:GridTemplateColumn MappingName="ShipCity" HeaderText="Ship City">
    <syncfusion:GridTemplateColumn.CellTemplate>
        <DataTemplate>
            <StackPanel Orientation="Horizontal">
                <Image Source="/Images/location.png" Width="16" Height="16" Margin="0,0,5,0" />
                <TextBlock Text="{Binding ShipCity}" Foreground="Blue" FontWeight="Bold" />
            </StackPanel>
        </DataTemplate>
    </syncfusion:GridTemplateColumn.CellTemplate>
</syncfusion:GridTemplateColumn>

{% endhighlight %}
{% endtabs %}

**Blazor implementation:**

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

<GridColumn Field="@nameof(Order.ShipCity)" HeaderText="Ship City" Width="200">
    <Template>
        @{
            var order = context as Order;
        }
        <div style="display: flex; align-items: center;">
            <img src="/images/location.png" style="width: 16px; height: 16px; margin-right: 5px;" />
            <span style="color: blue; font-weight: bold;">@order?.ShipCity</span>
        </div>
    </Template>
</GridColumn>

{% endhighlight %}
{% endtabs %}

### Editing

**WPF implementation:**

{% tabs %}
{% highlight xml tabtitle="OrderView.xaml" %}

<syncfusion:SfDataGrid x:Name="OrdersGrid"
                       ItemsSource="{Binding Orders}"
                       AllowEditing="True"
                       EditTrigger="OnTap"                    
                       EditorSelectionBehavior="SelectAll"         
                       LostFocusBehavior="Default"                 
                       CurrentCellBeginEdit="OrdersGrid_CurrentCellBeginEdit"
                       CurrentCellEndEdit="OrdersGrid_CurrentCellEndEdit"
                       CurrentCellValueChanged="OrdersGrid_CurrentCellValueChanged"
                       CellTapped="OrdersGrid_CellTapped"
                       CellDoubleTapped="OrdersGrid_CellDoubleTapped">
    <syncfusion:SfDataGrid.Columns>
        <syncfusion:GridTextColumn MappingName="OrderID" HeaderText="Order ID" AllowEditing="False" />
        <syncfusion:GridTextColumn MappingName="CustomerID" HeaderText="Customer" />
        <syncfusion:GridNumericColumn MappingName="Freight" HeaderText="Freight" />
    </syncfusion:SfDataGrid.Columns>
</syncfusion:SfDataGrid>

{% endhighlight %}
{% highlight cs tabtitle="OrderView.xaml.cs" %}

private void OrdersGrid_CurrentCellBeginEdit(object sender, CurrentCellBeginEditEventArgs e)
{
    // Use e.RowColumnIndex and e.Column to customize or cancel cell editing using e.Cancel.
}

private void OrdersGrid_CurrentCellEndEdit(object sender, CurrentCellEndEditEventArgs e)
{
    // Use e.RowColumnIndex to perform validation or post‑edit processing when editing ends.
}

private void OrdersGrid_CurrentCellValueChanged(object sender, CurrentCellValueChangedEventArgs e)
{
    // Use e.RowColumnIndex and e.Column to respond to value changes in editable cells.
}

private void OrdersGrid_CellTapped(object sender, GridCellTappedEventArgs e)
{
    // Use e.RowColumnIndex, e.Column, and e.Record to handle single‑click or tap interactions.
}

private void OrdersGrid_CellDoubleTapped(object sender, GridCellDoubleTappedEventArgs e)
{
    // Use e.RowColumnIndex, e.Column, and e.Record to initiate editing or perform double‑click actions.
}

{% endhighlight %}
{% endtabs %}

**Blazor implementation:**

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

<SfGrid TValue="Order"
        @ref="OrdersGrid"
        DataSource="@Orders">

    <GridEditSettings AllowEditing="true"
                      AllowAdding="true"
                      AllowDeleting="true"
                      Mode="EditMode.Normal">
    </GridEditSettings>

    <GridEvents TValue="Order"
                OnRecordClick="RecordClickHandler"
                OnRecordDoubleClick="RecordDoubleClickHandler"
                OnCellEdit="CellEditHandler"
                OnCellSave="CellSaveHandler"
                CellSaved="CellSavedHandler">
    </GridEvents>

    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)"
                    HeaderText="Order ID"
                    IsPrimaryKey="true"
                    AllowEditing="false"
                    Width="120" />

        <GridColumn Field="@nameof(Order.CustomerID)"
                    HeaderText="Customer"
                    Width="150" />

        <GridColumn Field="@nameof(Order.Freight)"
                    HeaderText="Freight"
                    EditType="EditType.NumericEdit"
                    TextAlign="TextAlign.Right"
                    Width="120" />
    </GridColumns>

</SfGrid>

@code {
    private SfGrid<Order> OrdersGrid;
    private List<Order> Orders = new();

    private void RecordClickHandler(RecordClickEventArgs<Order> args)
    {
        // Use args.RowData and args.RowIndex to handle single‑click record interactions.
    }

    private void RecordDoubleClickHandler(RecordDoubleClickEventArgs<Order> args)
    {
        // Use args.RowData and args.RowIndex to initiate editing or perform record‑level actions.
    }

    private void CellEditHandler(CellEditArgs<Order> args)
    {
        // Use args.ColumnName and args.RowData to customize or cancel editing using args.Cancel.
    }

    private void CellSaveHandler(CellSaveArgs<Order> args)
    {
        // Validate args.Value and set args.Cancel to prevent saving if needed.
    }

    private void CellSavedHandler(CellSavedArgs<Order> args)
    {
        // Use args.Data and args.ColumnName to perform actions after the cell value is saved.
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

**Key migration changes:**
- `AllowEditing="True"` → `GridEditSettings` component
- `EditMode="Cell"` → `Mode="EditMode.Batch"` (or `EditMode.Normal` for row editing)
- `IDataErrorInfo` validation → `ValidationRules` property
- Add/Edit/Delete buttons via `Toolbar` property

### Sorting and filtering

**WPF implementation:**

{% tabs %}
{% highlight xml tabtitle="OrderView.xaml" %}

<syncfusion:SfDataGrid ItemsSource="{Binding Orders}"
                       AllowSorting="True"
                       ShowSortNumbers="True"
                       SortClickAction="DoubleClick"
                       AllowFiltering="True"
                       AutoGenerateColumns="True"
                       FilterPopupStyle="{StaticResource  gridFilterControlStyle}"
                       FilterRowPosition="FixedTop">
    <syncfusion:SfDataGrid.SortColumnDescriptions>
        <syncfusion:SortColumnDescription ColumnName="OrderID" SortDirection="Ascending" />
        <syncfusion:SortColumnDescription ColumnName="CustomerName" SortDirection="Descending" />
    </syncfusion:SfDataGrid.SortColumnDescriptions>
</syncfusion:SfDataGrid>

{% endhighlight %}
{% endtabs %}

**Blazor implementation:**

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

<SfGrid TValue="Order" DataSource="@Orders"
        AllowSorting="true"
        AllowMultiSorting="true"
        AllowFiltering="true">
    <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Excel" />
    <GridSortSettings>
        <GridSortColumns>
            <GridSortColumn Field="OrderID" Direction="SortDirection.Ascending" />
            <GridSortColumn Field="CustomerName" Direction="SortDirection.Descending" />
        </GridSortColumns>
    </GridSortSettings>
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" Width="120" />
        <GridColumn Field="@nameof(Order.CustomerName)" HeaderText="Customer" Width="150" />
        <GridColumn Field="@nameof(Order.Freight)" HeaderText="Freight" Format="C2" Width="120" />
    </GridColumns>
</SfGrid>

{% endhighlight %}
{% endtabs %}

**Key migration changes:**
- Initial sort: `SortColumnDescriptions` → `GridSortSettings > GridSortColumns`
- Filter UI: `FilterRowPosition` → `GridFilterSettings.Type` (Excel, Menu, CheckBox, Row)

### Grouping

**WPF implementation:**

{% tabs %}
{% highlight xml tabtitle="OrderView.xaml" %}

<syncfusion:SfDataGrid ItemsSource="{Binding Orders}"
                       AllowGrouping="True"
                       ShowGroupDropArea="True">
    <syncfusion:SfDataGrid.GroupColumnDescriptions>
        <syncfusion:GroupColumnDescription ColumnName="OrderID" />
        <syncfusion:GroupColumnDescription ColumnName="CustomerID" />
    </syncfusion:SfDataGrid.GroupColumnDescriptions>
</syncfusion:SfDataGrid>

{% endhighlight %}
{% endtabs %}

**Blazor implementation:**

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

<SfGrid TValue="Order" DataSource="@Orders" AllowGrouping="true" Height="450px">
    <GridGroupSettings ShowDropArea="true"
                       ShowGroupedColumn="true"
                       Columns="@Initial" />
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" Width="120" />
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer" Width="150" />
        <GridColumn Field="@nameof(Order.Freight)" HeaderText="Freight" Format="C2" Width="120" />
    </GridColumns>
</SfGrid>

@code {
    private IEnumerable<Order> Orders;
    private readonly string[] Initial = new[] { nameof(Order.OrderID), nameof(Order.CustomerID) };

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
}

{% endhighlight %}
{% endtabs %}

### Selection

**WPF implementation:**

{% tabs %}
{% highlight xml tabtitle="OrderView.xaml" %}

<syncfusion:SfDataGrid x:Name="dataGrid"
                       ItemsSource="{Binding Orders}"
                       SelectionUnit="Any"
                       SelectionMode="Extended"
                       ShowRowHeader="True"
                       EnableExcelLikeSelection="True"
                       SelectionChanged="DataGrid_SelectionChanged"
                       AutoGenerateColumns="False">
    <syncfusion:SfDataGrid.Columns>
        <syncfusion:GridTextColumn MappingName="OrderID" HeaderText="Order ID" Width="100" />
        <syncfusion:GridTextColumn MappingName="CustomerID" HeaderText="Customer" Width="150" />
        <syncfusion:GridNumericColumn MappingName="Freight" HeaderText="Freight" NumberDecimalDigits="2" Width="120" />
    </syncfusion:SfDataGrid.Columns>
</syncfusion:SfDataGrid>

{% endhighlight %}
{% highlight c# tabtitle="OrderView.xaml.cs" %}

using Syncfusion.UI.Xaml.Grid;
using System.Collections;

private void DataGrid_SelectionChanged(object sender, GridSelectionChangedEventArgs e)
{
    var grid = (SfDataGrid)sender;
    IList selected = grid.SelectedItems;           // selected rows (IList)
    if (selected.Count > 0 && selected[0] is Order o)
    {
        // use selected order
    }

    var current = grid.CurrentCellManager.CurrentCell; // current cell info
    var currentRow = current?.RowData as Order;
}
{% endhighlight %}
{% endtabs %}

**Blazor implementation:**

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

<SfGrid TValue="Order" @ref="Grid" DataSource="@Orders" Height="320" AllowSelection="true">
    <GridSelectionSettings Type="SelectionType.Single" Mode="SelectionMode.Row" />
    <GridEvents TValue="Order" RowSelected="OnRowSelected" RowDeselected="OnRowDeselected" />
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" Width="120" />
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer" Width="150" />
        <GridColumn Field="@nameof(Order.Freight)" HeaderText="Freight" Format="C2" Width="120" TextAlign="TextAlign.Right" />
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<Order> Grid;
    private List<Order> Orders = new()
    {
        new Order{ OrderID = 10248, CustomerID = "VINET", Freight = 32.38 },
        new Order{ OrderID = 10249, CustomerID = "TOMSP", Freight = 11.61 }
    };

    private void OnRowSelected(RowSelectEventArgs<Order> args)
    {
        // Use args.Data for the selected row
    }

    private void OnRowDeselected(RowDeselectEventArgs<Order> args)
    {
        // Use args.Data for the deselected row
    }

    private async Task<IEnumerable<Order>> GetSelected()
    {
        // Returns the currently selected records from the grid
        return await Grid.GetSelectedRecordsAsync();
    }

    public class Order { public int OrderID { get; set; } public string CustomerID { get; set; } public double Freight { get; set; } }
}

{% endhighlight %}
{% endtabs %}

**Key migration changes:**
- `SelectionMode` → `GridSelectionSettings.Mode`
- `SelectionUnit` → `GridSelectionSettings.Type`
- `SelectedItems` property → `GetSelectedRecordsAsync()` method

### Paging

**WPF implementation:**

{% tabs %}
{% highlight xml tabtitle="OrderView.xaml" %}

<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="*" />
        <RowDefinition Height="Auto" />
    </Grid.RowDefinitions>

    <syncfusion:SfDataGrid Grid.Row="0" 
                           ItemsSource="{Binding ElementName=dataPager, Path=PagedSource}" />
    
    <syncfusion:SfDataPager Grid.Row="1"
                            x:Name="dataPager"
                            PageSize="20"
                            Source="{Binding Orders}" />
</Grid>

{% endhighlight %}
{% endtabs %}

**Blazor implementation:**

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

<SfGrid TValue="Order" DataSource="@Orders" AllowPaging="true">
    <GridPageSettings PageSize="20"  PageSizes="true" />
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" Width="120" />
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer" Width="150" />
        <GridColumn Field="@nameof(Order.Freight)" HeaderText="Freight" Format="C2" Width="120" />
    </GridColumns>
</SfGrid>

{% endhighlight %}
{% endtabs %}

**Key migration changes:**
- External `SfDataPager` → Built-in `GridPageSettings`
- `PageSize` property → `GridPageSettings.PageSize`
- Page size dropdown via `PageSizes` property

### Virtualization

**WPF implementation:**

{% tabs %}
{% highlight xml tabtitle="OrderView.xaml" %}

<syncfusion:SfDataGrid ItemsSource="{Binding Orders}"
                       EnableDataVirtualization="True">
</syncfusion:SfDataGrid>

{% endhighlight %}
{% endtabs %}

**Blazor implementation:**

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

<SfGrid TValue="Order" DataSource="@LargeOrders"
        EnableVirtualization="true"
        EnableColumnVirtualization="true"
        Height="600px">
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" Width="120" />
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer" Width="150" />
        <GridColumn Field="@nameof(Order.Freight)" HeaderText="Freight" Format="C2" Width="120" />
    </GridColumns>
</SfGrid>

{% endhighlight %}
{% endtabs %}

> N> When using `EnableVirtualization`, the `Height` property must be set.

### Styling - Cell level

**WPF implementation:**

{% tabs %}
{% highlight xml tabtitle="OrderView.xaml" %}

<syncfusion:GridTextColumn MappingName="Freight" HeaderText="Freight">
    <syncfusion:GridTextColumn.CellStyle>
        <Style TargetType="syncfusion:GridCell">
            <Setter Property="Background" Value="LightYellow" />
            <Setter Property="FontWeight" Value="Bold" />
        </Style>
    </syncfusion:GridTextColumn.CellStyle>
</syncfusion:GridTextColumn>

{% endhighlight %}
{% endtabs %}

**Blazor implementation:**

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

<GridColumn Field="@nameof(Order.Freight)" 
            HeaderText="Freight" 
            Format="C2"
            CustomAttributes='@(new Dictionary<string, object> { { "class", "freight-col" } })' 
            Width="120" />

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight css tabtitle="app.css" %}

.freight-col {
    background-color: lightyellow;
    font-weight: bold;
}

{% endhighlight %}
{% endtabs %}

### Styling - Row level

**WPF implementation:**

{% tabs %}
{% highlight xml tabtitle="OrderView.xaml" %}

<Window.Resources>
    <Style TargetType="syncfusion:VirtualizingCellsControl" x:Key="alternatingRowStyle">
        <Setter Property="Background" Value="LightBlue"/>
    </Style>

    <Style TargetType="syncfusion:VirtualizingCellsControl" x:Key="RowStyle">
        <Setter Property="Background" Value="Bisque"/>
    </Style>
</Window.Resources>

<syncfusion:SfDataGrid x:Name="dataGrid" 
                       AlternatingRowStyle="{StaticResource alternatingRowStyle}" 
                       AlternationCount="3"
                       RowStyle="{StaticResource RowStyle}"
                       ItemsSource="{Binding Orders}"/>

{% endhighlight %}
{% endtabs %}

**Blazor implementation:**

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

<SfGrid TValue="Order" DataSource="@Orders">
    <GridEvents TValue="Order" RowDataBound="OnRowDataBound" />
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" Width="120" />
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer" Width="150" />
        <GridColumn Field="@nameof(Order.Freight)" HeaderText="Freight" Format="C2" Width="120" />
    </GridColumns>
</SfGrid>

@code {
    private void OnRowDataBound(RowDataBoundEventArgs<Order> args)
    {
        if (args.Data.Freight > 500)
            args.Row.AddClass(new string[] { "high-freight-row" });
    }
}

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight css tabtitle="app.css" %}

.high-freight-row {
    background-color: #fff3cd;
    color: #856404;
}

{% endhighlight %}
{% endtabs %}

### Performance - Frozen columns

**WPF implementation:**

{% tabs %}
{% highlight xml tabtitle="OrderView.xaml" %}

<syncfusion:SfDataGrid ItemsSource="{Binding Orders}" FrozenColumnCount="2">
    <syncfusion:SfDataGrid.Columns>
        <syncfusion:GridTextColumn MappingName="OrderID" HeaderText="Order ID" />
        <syncfusion:GridTextColumn MappingName="CustomerID" HeaderText="Customer" />
        <syncfusion:GridTextColumn MappingName="ShipCity" HeaderText="Ship City" />
    </syncfusion:SfDataGrid.Columns>
</syncfusion:SfDataGrid>

{% endhighlight %}
{% endtabs %}

**Blazor implementation:**

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

<SfGrid TValue="Order" DataSource="@Orders"  Height="300px" EnableHover="false" RowHeight="38" EnableVirtualization="true" EnableColumnVirtualization="true" EnableVirtualMaskRow="true">
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" IsFrozen="true" Width="120" />
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer" IsFrozen="true" Width="150" />
        <GridColumn Field="@nameof(Order.ShipCity)" HeaderText="Ship City" Width="150" />
    </GridColumns>
</SfGrid>

{% endhighlight %}
{% endtabs %}

## See also

- [Syncfusion WPF DataGrid - Getting started](https://help.syncfusion.com/wpf/datagrid/getting-started)
- [Syncfusion Blazor DataGrid - Getting started](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-server-app)
- [Syncfusion Blazor DataGrid - Editing](https://blazor.syncfusion.com/documentation/datagrid/editing/inline-editing)
- [Syncfusion Blazor DataGrid - Filtering](https://blazor.syncfusion.com/documentation/datagrid/filtering/filter-bar)
- [Syncfusion Blazor DataGrid - Virtualization](https://blazor.syncfusion.com/documentation/datagrid/virtual-scrolling)
- [ASP.NET Core Blazor hosting models](https://learn.microsoft.com/en-us/aspnet/core/blazor/hosting-models)