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

Migrating enterprise applications from **[WPF (Windows Presentation Foundation)](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/overview/)** to **[Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/)** involves a significant architectural transition, moving from a rich, XAML-based desktop client framework to a component-driven, cross-platform web framework running on .NET. This guide provides a **structured, step-by-step migration path** for **[Syncfusion WPF components](https://www.syncfusion.com/wpf-controls)** to their **[Syncfusion Blazor equivalents](https://www.syncfusion.com/blazor-components)**, developed using **[Visual Studio Code](https://code.visualstudio.com/)**.

This document covers:
* Architectural differences between WPF and Blazor
* Initial rendering setup for major Syncfusion components
* Detailed DataGrid migration with feature parity mapping

### Why migrate from WPF to Blazor?

| Dimension | WPF | Blazor |
|---|---|---|
| **Runtime** | Windows‑only (runs on .NET Framework and on modern .NET (Core / 5+)) | Cross‑platform: Blazor Server runs on .NET on the server; Blazor WebAssembly runs client‑side in the browser; MAUI Blazor Hybrid hosts Blazor in native apps |
| **Deployment** | Desktop installation (MSIX, MSI, installer; ClickOnce still available but legacy) | Web‑hosted (browser) or packaged/hybrid (MAUI Blazor Hybrid, PWAs) |
| **UI technology** | XAML + code‑behind | Razor components (HTML + C#) |
| **Communication model** | Direct in‑process calls | Blazor Server: SignalR (real‑time circuits); Blazor WebAssembly: client executes in browser and communicates via HTTP/SignalR to backends |
| **Modern tooling** | Visual Studio (recommended) | Visual Studio, Visual Studio Code (both supported) |
| **Scalability** | Optimized for single‑user desktop apps | Designed for multi‑user web scenarios; note Blazor Server requires server resources per connection (circuit) |
| **Updates** | App binaries updated via installer/MSIX/auto‑update mechanism | Blazor Server: immediate after deploy; Blazor WebAssembly: client cache/service‑worker may require cache invalidation or versioning |
| **Cross‑browser access** | Windows desktop only (no browser compatibility concerns) | Supported on modern browsers (Chrome, Edge, Firefox, Safari). Blazor WebAssembly does not support legacy IE browsers |

### Key architectural differences

| Concept | WPF | Blazor Server |
|---|---|---|
| **UI definition** | XAML (`.xaml`) | Razor (`.razor`) |
| **Code-behind / logic** | `.xaml.cs` or ViewModel | `@code { }` block or `.razor.cs` partial class |
| **Pattern** | MVVM (widely adopted) + code‑behind | Component-based (MVVM optional) |
| **Data context** | `DataContext = ViewModel` | `@bind`, `[Parameter]`, cascading values |
| **State management** | ViewModel + `INotifyPropertyChanged` | Component state + `StateHasChanged()`; in Blazor Server the state is stored per server circuit (per connection) |
| **Dependency injection** | Typically third‑party containers (Unity, Prism, MEF, etc.) | Built‑in `IServiceCollection` / DI container |
| **Navigation** | WPF `Frame` / Prism `RegionManager` | `NavigationManager` + `@page` routing |
| **Render mode** | Native rendering pipeline | Use server render modes (e.g., `@rendermode InteractiveServer` / `[RenderModeInteractiveServer]`) for .NET 8+; Blazor WebAssembly uses client rendering |

## Development environment setup

### Prerequisites for Blazor

* [.NET 8 SDK or later](https://dotnet.microsoft.com/en-us/download/dotnet)
* [Visual Studio Code](https://code.visualstudio.com/) with [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension

**Verify installation:**

Run the following commands to verify that the installed .NET SDK version is 8.0 or later and that Blazor project templates are available.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet --version   # Print installed .NET SDK version (should be 8.0.x or later)
dotnet new list blazor   # List available/installed Blazor project templates

{% endhighlight %}
{% endtabs %}

## Project structure comparison

### One-to-one structural mapping

| WPF artifact | Blazor equivalent | Notes |
|---|---|---|
| `App.xaml` | `App.razor` | Root app file (typically at project root; not necessarily in a `Components` folder). |
| `App.xaml.cs` | `Program.cs` | Startup, DI and host configuration. |
| `MainWindow.xaml` | `MainLayout.razor` | Layout/shell component (commonly under `Shared` or `Layouts`). |
| `Views/*.xaml` | `Pages/*.razor` | Page components use `@page` routing. |
| `ViewModels/*.cs` | `*.razor.cs` / services / ViewModel classes | MVVM can be preserved, but Blazor favors component code-behind (`.razor.cs`) or injected services; ViewModels still valid. |
| `Models/*.cs` | `Models/*.cs` | Typically unchanged; validation attributes work with `EditForm`. |
| `Services/*.cs` | `Services/*.cs` | Register via `builder.Services` (`IServiceCollection`). |
| `ResourceDictionary` | `wwwroot/css/*.css` (+ `_content/*` static assets) | Map XAML resources to CSS, CSS isolation, and theme CSS/JS files. |
| `UserControl` | Razor component (`.razor`) | Reusable UI component. |
| `ICommand` / `RelayCommand` | C# methods + `EventCallback` / injected services | Use EventCallback / async methods; ICommand can be used but is not the primary pattern. |
| `INotifyPropertyChanged` | Component state + `StateHasChanged()` (or subscribe `CollectionChanged`) | Blazor re-renders via lifecycle and StateHasChanged; for ObservableCollection subscribe and call InvokeAsync(StateHasChanged). |

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

> N> The `--interactivity Server` flag configures SignalR-based interactivity and provides behavior similar to WPF's immediate UI update model, but over the network.

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
|---|---|---|
| Package (NuGet) | `Syncfusion.SfGrid.WPF` | `Syncfusion.Blazor.Grid` |
| Namespace | XAML: `xmlns:syncfusion="..."` | Razor: `@using Syncfusion.Blazor.Grids` |
| Component declaration | `<syncfusion:SfDataGrid>` (XAML) | `<SfGrid>` / `<SfGrid TValue="T">` (Razor) |
| Data binding | `ItemsSource` / DataContext / `INotifyPropertyChanged` | `DataSource="@..."` + component state (`OnInitialized[Async]`, `StateHasChanged()`) |
| Collection type | `ObservableCollection<T>` (raises collection-change notifications; items should implement `INotifyPropertyChanged` for property updates) | `List<T>` / `IEnumerable<T>` (call `StateHasChanged()` after mutations); `ObservableCollection<T>` requires manual `CollectionChanged` subscription |
| Columns | Typed columns (e.g. `GridTextColumn`, `GridNumericColumn`, `GridTemplateColumn`) | `GridColumn` with `Field="@nameof(...)"`, `Format`, `EditType` |
| Templates | XAML `DataTemplate` | Razor `<Template>` / `RenderFragment<T>` sections |
| Editing & API | XAML properties, code‑behind events, `x:Name` refs | `GridEditSettings`, `GridEvents`, `EventCallback<T>`, `@ref` async APIs |
| Events & commands | CLR events / `ICommand` | EventCallback-based handlers (async) |
| Theming & assets | `ResourceDictionary` / `SfSkinManager` | CSS theme files + Syncfusion JS; register `AddSyncfusionBlazor()` |
| Paging / virtualization | `SfDataPager` / native virtualization | `GridPageSettings`, `EnableVirtualization`, `SfDataManager` for remote operations |
| Lifecycle & refs | Constructor / `Loaded` event / `x:Name` | `OnInitialized[Async]`, DI, `@ref` and async methods |

#### Step-by-step migration

##### Step 1: Package installation

Install the required Syncfusion NuGet packages to enable DataGrid functionality in your application.
In WPF, the [DataGrid control](https://www.syncfusion.com/wpf-controls/datagrid) is available through a single package. In Blazor, the [DataGrid component](https://www.syncfusion.com/blazor-components/blazor-datagrid) and its theme styles are provided as separate packages, and both need to be installed.

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

##### Step 2: Theme 

Configure the visual theme to ensure that the DataGrid follows a consistent and modern appearance across the application.
In WPF, themes are applied at the window level using the [SfSkinManager](https://help.syncfusion.com/wpf/themes/skin-manager), while Blazor applications apply themes by referencing the required Syncfusion CSS files during application startup.

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

Register the Syncfusion services in the Blazor dependency injection container to activate component rendering and runtime behavior.
This step is required only for Blazor applications and replaces the implicit component initialization mechanism used in WPF.

**Blazor requirement:**

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}
....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....
{% endhighlight %}
{% endtabs %}

**Additional step (Blazor only):**

{% tabs %}
{% highlight razor tabtitle="_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

{% endhighlight %}
{% endtabs %}

##### Step 4: Component rendering

Render the DataGrid and configure the required columns.
In WPF, the DataGrid control is defined in XAML and the data collection is assigned programmatically using the [ItemsSource](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfDataGrid.html#Syncfusion_UI_Xaml_Grid_SfDataGrid_ItemsSource) property. In Blazor, the DataGrid component is declared in Razor markup and receives its data through the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) parameter.

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

### 2. TreeGrid

For detailed explanation, refer to the [WPF TreeGrid getting started guide](https://help.syncfusion.com/wpf/treegrid/getting-started) and [Blazor TreeGrid getting started guide](https://blazor.syncfusion.com/documentation/treegrid/getting-started).

#### Migration overview

| Aspect | WPF (SfTreeGrid) | Blazor (SfTreeGrid) |
|---|---|---|
| Package (NuGet) | `Syncfusion.SfGrid.WPF` | `Syncfusion.Blazor.TreeGrid` |
| Namespace | XAML: `xmlns:syncfusion="..."` | Razor: `@using Syncfusion.Blazor.TreeGrid` |
| Component declaration | `<syncfusion:SfTreeGrid>` (XAML) | `<SfTreeGrid>` (Razor) |
| Hierarchy mapping | `ChildPropertyName` / `ParentPropertyName` (use `SelfRelationRootValue` for root nodes) | `IdMapping` + `ParentIdMapping` (nullable parent IDs for root nodes) |
| Data shape | Nested children collections OR self‑referencing flat lists | Optimized for flat self‑referencing lists; nested requires mapping/flattening |
| Tree column | Automatic tree UI bound to hierarchical column | `TreeColumnIndex` to specify expand/collapse column |
| Columns & templates | `TreeGridTextColumn`, `TreeGridNumericColumn` | `TreeGridColumn` + Razor templates |
| Virtualization / performance | Native WPF rendering | Virtual scrolling / load‑on‑demand; set Height for virtualization |
| Events | CLR events | EventCallback-based GridEvents |

#### Step-by-step migration

##### Step 1: Package installation

Install the required Syncfusion NuGet packages to enable TreeGrid functionality for displaying hierarchical data in a grid format.
In WPF, the [TreeGrid control](https://www.syncfusion.com/wpf-controls/treegrid) is included as part of the Syncfusion Grid package. In Blazor, the [TreeGrid component](https://www.syncfusion.com/blazor-components/blazor-tree-grid) and its theme styles are available as separate packages, and both need to be installed.

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

##### Step 2: Theme configuration

Configure the visual theme to ensure that the TreeGrid follows a consistent and modern appearance across the application.
In WPF, themes are applied at the window level using the [SfSkinManager](https://help.syncfusion.com/wpf/themes/skin-manager). In Blazor, themes are applied by referencing the appropriate Syncfusion CSS files during application startup.

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

Register the Syncfusion services in the Blazor dependency injection container to enable TreeGrid component initialization and runtime functionality.
This step is required only for Blazor applications and replaces the implicit component setup used in WPF.

**Blazor requirement:**

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}
....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....
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

Render the TreeGrid and configure the required columns to display hierarchical data using a self‑referencing data structure.
In WPF, the TreeGrid control is defined in XAML, and the hierarchical data collection is assigned programmatically using the [ItemsSource](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.TreeGrid.SfTreeGrid.html#Syncfusion_UI_Xaml_TreeGrid_SfTreeGrid_ItemsSource) property along with parent‑child mapping properties. In Blazor, the TreeGrid component is declared in Razor markup and receives its hierarchical data through the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_DataSource) parameter, using [IdMapping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_IdMapping) and [ParentIdMapping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_ParentIdMapping) to establish relationships.

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

### 3. Charts

For detailed explanation, refer to the [WPF Charts getting started guide](https://help.syncfusion.com/wpf/charts/getting-started) and [Blazor Charts getting started guide](https://blazor.syncfusion.com/documentation/chart/getting-started).

#### Migration overview

| Aspect | WPF (SfChart) | Blazor (SfChart) |
|---|---|---|
| Package (NuGet) | `Syncfusion.SfChart.WPF` | `Syncfusion.Blazor.Charts` |
| Namespace | XAML: `xmlns:syncfusion="..."` | Razor: `@using Syncfusion.Blazor.Charts` |
| Component model | Nested XAML elements (PrimaryAxis, Series elements) | Razor components (ChartPrimaryXAxis, ChartSeries, ChartSeriesCollection) |
| Axis & series declaration | Axis elements (CategoryAxis, NumericalAxis), series types via element names | Axis components with `ValueType`, `ChartSeries` with `Type="ChartSeriesType.*"` |
| Data binding | `ItemsSource` + `XBindingPath` / `YBindingPath` | `DataSource` + `XName` / `YName` |
| Markers / adornments | `AdornmentsInfo` nested config | `ChartMarker`, `ChartTooltipSettings` components |
| Tooltip & animation | Series‑level properties and templates | Centralized `ChartTooltipSettings`, `ChartSeriesAnimation` component |
| Responsiveness | Window sizing | CSS-based sizing (Width="100%") and responsive containers |
| Events | CLR events | EventCallback handlers (OnPointClick, TooltipRender, etc.) |

#### Step-by-step migration

##### Step 1: Package installation

Install the required Syncfusion NuGet packages to enable charting and data visualization capabilities in your application.
In WPF, the [Chart control](https://www.syncfusion.com/wpf-controls/charts) is available through a single package. In Blazor, the [Chart component](https://www.syncfusion.com/blazor-components/blazor-charts) and its theme styles are provided as separate packages.

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

Configure the visual theme to ensure that the charts follow a consistent and modern appearance across the application.
In WPF, themes are applied at the window level using the [SfSkinManager](https://help.syncfusion.com/wpf/themes/skin-manager). In Blazor, themes are applied by referencing the required Syncfusion CSS files during application startup.

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

Register the Syncfusion services in the Blazor dependency injection container to enable chart component initialization and interactive features.
This step is required only for Blazor applications and replaces the implicit component setup used in WPF.

**Blazor requirement:**

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}
....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....
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

Render the chart and configure the required axes, series, and visualization settings.
In WPF, the Chart control is defined using nested XAML elements, and data is assigned through the [ItemsSource](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Charts.ChartSeriesBase.html#Syncfusion_UI_Xaml_Charts_ChartSeriesBase_ItemsSource) property using binding paths for the X and Y values. In Blazor, the Chart component is declared in Razor markup, with axes and series configured using child components, and data supplied through the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) parameter.

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

For detailed explanation, refer to the [WPF Scheduler getting started guide](https://help.syncfusion.com/wpf/scheduler/getting-started) and [Blazor Scheduler getting started guide](https://blazor.syncfusion.com/documentation/scheduler/getting-started-with-server-app?tabcontent=visual-studio-code).

#### Migration overview

| Aspect | WPF (SfScheduler) | Blazor (SfSchedule<TValue>) |
|---|---|---|
| Package (NuGet) | `Syncfusion.SfScheduler.WPF` | `Syncfusion.Blazor.Schedule` |
| Namespace | XAML: `xmlns:syncfusion="..."` | Razor: `@using Syncfusion.Blazor.Schedule` |
| Component declaration | `<syncfusion:SfScheduler>` (XAML, ScheduleAppointment model) | `<SfSchedule TValue="TModel">` (Razor, generic model) |
| Appointment model | `ScheduleAppointment` (built-in model) | Custom POCO with `ScheduleEventSettings` mappings (Id, Subject, StartTime, EndTime, etc.) |
| Views / configuration | `ViewType` enum (single prop) | `ScheduleViews` collection with `ScheduleView` elements |
| Resources & grouping | `ResourceCollection` + mapping | `ScheduleResources` / `ScheduleResource` components |
| Events & callbacks | CLR events | EventCallback-based events (OnActionBegin, OnCellClick) |
| Data & performance | Native large‑set handling | Virtualization / lazy loading recommended for large datasets |

#### Step-by-step migration

##### Step 1: Package installation

Install the required Syncfusion NuGet packages to enable calendar and appointment scheduling functionality in your application.
In WPF, the [Scheduler control](https://www.syncfusion.com/wpf-controls/scheduler) is available through a single package. In Blazor, the [Scheduler component](https://www.syncfusion.com/blazor-components/blazor-scheduler) and its theme styles are provided as separate packages, and both need to be installed.

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

Configure the visual theme to ensure that the Scheduler follows a consistent and modern appearance across the application.
In WPF, themes are applied at the window level using the [SfSkinManager](https://help.syncfusion.com/wpf/themes/skin-manager). In Blazor, themes are applied by referencing the required Syncfusion CSS files during application startup.

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

Register the Syncfusion services in the Blazor dependency injection container to enable Scheduler component initialization and interactive features.
This step is required only for Blazor applications and replaces the implicit component setup used in WPF.

**Blazor requirement:**

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}
....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....
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

Render the Scheduler and configure the required views, date settings, and appointment data.
In WPF, the Scheduler control is defined in XAML, with the active view and display date configured through properties, and appointments assigned programmatically using the [ItemsSource](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Scheduler.SfScheduler.html#Syncfusion_UI_Xaml_Scheduler_SfScheduler_ItemsSource) property. In Blazor, the Scheduler component is declared in Razor markup, views are configured using child components, and appointment data is supplied through the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEventSettings-1.html#Syncfusion_Blazor_Schedule_ScheduleEventSettings_1_DataSource) parameter.

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
|---|---|---|
| Package (NuGet) | `Syncfusion.SfDiagram.WPF` | `Syncfusion.Blazor.Diagram` |
| Namespace | XAML: `xmlns:syncfusion="..."` | Razor: `@using Syncfusion.Blazor.Diagram` |
| Node definition | `NodeCollection` in XAML (declarative) | `DiagramObjectCollection<Node>` in code (`@code` / OnInitialized) |
| Connector definition | `ConnectorCollection` in XAML | `DiagramObjectCollection<Connector>` in code |
| Shape specification | XAML Shape enums / ViewModels | Shape objects (FlowShape, Path) and `ShapeStyle` objects in code |
| Positioning | Attributes `OffsetX`, `OffsetY` in XAML | Properties set in Node objects (OffsetX/OffsetY) in code |
| Ports & constraints | Declared in XAML | Programmatic `Ports` + `NodeConstraints` enum flags |
| Layouts | `LayoutManager` XAML settings | `LayoutType` and options |
| Data binding / auto‑generate | `DataSourceSettings` mapping in XAML | `DataSourceSettings` + `SfDataManager` support; code mapping required |
| Events & serialization | Routed events, Save/Load methods | EventCallback callbacks; `SaveDiagram()` / `LoadDiagram()` async JSON APIs |

#### Step-by-step migration

##### Step 1: Package installation

Install the required Syncfusion NuGet packages to enable diagramming and visual flowchart creation in your application.
In WPF, the [Diagram control](https://www.syncfusion.com/wpf-controls/diagram) is available through a single package. In Blazor, the [Diagram component](https://www.syncfusion.com/blazor-components/blazor-diagram) and its theme styles are provided as separate packages, and both need to be installed.

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

Configure the visual theme to ensure that the Diagram follows a consistent and modern appearance across the application.
In WPF, themes are applied at the window level using the [SfSkinManager](https://help.syncfusion.com/wpf/themes/skin-manager). In Blazor, themes are applied by referencing the required Syncfusion CSS files during application startup.

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

Register the Syncfusion services in the Blazor dependency injection container to enable Diagram component initialization and interactive features.
This step is required only for Blazor applications and replaces the implicit component setup used in WPF.

**Blazor requirement:**

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}
....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....
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

Render the Diagram component and define its visual elements, such as nodes and connectors.
In WPF, the Diagram control is declared in XAML, with nodes and connectors defined using nested collections. In Blazor, the Diagram component is declared in Razor markup, and nodes and connectors are created programmatically and supplied through component parameters.

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

For detailed explanation, refer to the [WPF RichTextBox getting started guide](https://help.syncfusion.com/wpf/richtextbox/getting-started) and [Blazor RichTextEditor getting started guide](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started-with-server-app).

#### Migration overview

| Aspect | WPF (SfRichTextBoxAdv) | Blazor (SfRichTextEditor) |
|---|---|---|
| Package (NuGet) | `Syncfusion.SfRichTextBoxAdv.WPF` | `Syncfusion.Blazor.RichTextEditor` |
| Namespace | XAML: `xmlns:syncfusion="clr-namespace:Syncfusion.Windows.Controls.RichTextBoxAdv;assembly=Syncfusion.SfRichTextBoxAdv.WPF"` | Razor: `@using Syncfusion.Blazor.RichTextEditor` |
| Component name | `SfRichTextBoxAdv` (Document model) | `SfRichTextEditor` (HTML value model) |
| Content model | `Document` / DocumentAdv (DOCX/RTF native) | HTML string via `Value` / `@bind-Value` |
| Load / Save | Stream-based Load/Save (DOCX/RTF/HTML) | Value string; import/export via converters or server-side processing |
| Toolbar & UI | RibbonBar + command bindings | `ToolbarSettings` with configurable items; Razor templates for dialogs |
| Toolbar configuration | Built-in RibbonBar with Mini Toolbar; customizable via command bindings | `RichTextEditorToolbarSettings` with predefined/custom toolbar items array |

> **Warning:** WPF `SfRichTextBoxAdv` uses a native Document Object Model for Word-like documents. Blazor `SfRichTextEditor` uses HTML as its content format. If your WPF app relies on complex DOCX features (sections, headers/footers, advanced styles), you may need server-side conversion or alternative components.

#### Step-by-step migration

##### Step 1: Package installation

Install the required Syncfusion NuGet packages to enable rich text editing with formatting and content authoring capabilities in your application.
In WPF, the [RichTextEditor control](https://www.syncfusion.com/docx-editor-sdk/wpf-docx-editor) is available through a single package. In Blazor, the [RichTextEditor component](https://www.syncfusion.com/blazor-components/blazor-rich-text-editor) and its theme styles are provided as separate packages, and both need to be installed.

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

Configure the visual theme to ensure that the RichTextEditor follows a consistent and modern appearance across the application.
In WPF, themes are applied at the window level using the [SfSkinManager](https://help.syncfusion.com/wpf/themes/skin-manager). In Blazor, themes are applied by referencing the required Syncfusion CSS files during application startup.

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

Register the Syncfusion services in the Blazor dependency injection container to enable RichTextEditor component initialization and interactive features.
This step is required only for Blazor applications and replaces the implicit component setup used in WPF.

**Blazor requirement:**

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}
....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....
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

Render the RichTextEditor and configure its editing surface for rich text content.
In WPF, the RichTextEditor control is declared directly in XAML, and the initial content is loaded programmatically using a stream. In Blazor, the RichTextEditor component is declared in Razor markup, and the editor content is initialized and synchronized using two‑way binding with the [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_Value) property.

**WPF approach (MainWindow.xaml):**

{% tabs %}
{% highlight xml tabtitle="MainWindow.xaml" %}

<Window x:Class="WpfRichTextEditor.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:syncfusion="clr-namespace:Syncfusion.Windows.Controls.RichTextBoxAdv;assembly=Syncfusion.SfRichTextBoxAdv.WPF"
        xmlns:syncfusionskin="clr-namespace:Syncfusion.SfSkinManager;assembly=Syncfusion.SfSkinManager.WPF"
        syncfusionskin:SfSkinManager.Theme="{syncfusionskin:SkinManagerExtension ThemeName=FluentLight}"
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

## Detailed DataGrid migration

The following sections provide **in-depth migration guidance** for the **Syncfusion DataGrid**, covering data binding, columns, editing, sorting, filtering, paging, styling, and performance optimization.

### Data binding

**WPF implementation:**

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
{% highlight c# tabtitle="OrderViewModel.cs" %}

using System.ComponentModel;
using System.Runtime.CompilerServices; 

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
- `ItemsSource` → `DataSource` on `<SfGrid>` / `<SfGrid TValue="T">`.
- `ObservableCollection<T>` → `List<T>` / `IEnumerable<T>` for typical Blazor components. If you keep `ObservableCollection<T>`, subscribe to `CollectionChanged` and call `InvokeAsync(StateHasChanged)` to force re-render.
- `INotifyPropertyChanged` (ViewModel reactivity) → component state and lifecycle methods; call `StateHasChanged()` when component state changes.
- `MappingName` → `Field="@nameof(...)"` on `GridColumn`.
- Load and initialize data in `OnInitialized` / `OnInitializedAsync` rather than constructors or WPF `Loaded` handlers.

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

**Key migration changes:**
- `GridTextColumn` → `GridColumn` (default). Specify `Field="@nameof(...)"`.
- `GridNumericColumn` → `GridColumn` with `Format` (e.g., `Format="N2"`) and `EditType` for numeric editors.
- `GridCurrencyColumn` → `GridColumn` with `Format="C2"`.
- `GridDateTimeColumn` → `GridColumn` with `Type="ColumnType.Date"` and an appropriate `Format`.
- `GridCheckBoxColumn` → `GridColumn` with `Type="ColumnType.Boolean"`.
- Use `Width`, `TextAlign`, `CustomAttributes`, and `<Template>` to control layout and rendering in Razor.

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

**Key migration changes:**

- XAML `<DataTemplate>` → Razor `<Template>` / `RenderFragment<T>` (row object accessible as `context`).
- Replace WPF controls with HTML/CSS and Blazor components; images use `wwwroot` paths (for example, `/images/...`).
- Move complex UI logic from XAML to component code (`@code` / `.razor.cs`).

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
- WPF edit flags (`AllowEditing`, `AddNewRowPosition`) → `GridEditSettings` (`AllowEditing`, `AllowAdding`, `AllowDeleting`, `Mode`).
- WPF edit events (`CurrentCellBeginEdit`, `CurrentCellEndEdit`, `CurrentCellValueChanged`) → Blazor Grid events via `GridEvents`, such as `OnCellEdit`, `OnCellSave`, `CellSaved`.
- Row/record interactions (`CellTapped`, `CellDoubleTapped`) → `OnRecordClick`, `OnRecordDoubleClick`.
- Validation: `IDataErrorInfo` / `INotifyDataErrorInfo` → `EditForm` + DataAnnotations or grid-level validation using `OnActionBegin` / `OnActionComplete`.
- Use component `@ref` and async APIs (for example, `await Grid.BeginEditAsync(...)`, `await Grid.SaveRowAsync()`) for programmatic editing.

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
- `SortColumnDescriptions` → `GridSortSettings` / `<GridSortColumn Field="..." Direction="SortDirection.*" />`.
- `AllowSorting` / `ShowSortNumbers` → `AllowSorting="true"`, `AllowMultiSorting="true"`, and `GridSortSettings`.
- Filter UI differences: WPF `FilterRowPosition` / `FilterPopupStyle` → `GridFilterSettings` (`Type="FilterType.Excel|Menu|Checkbox|Row"`) and filter-specific settings.
- For remote sorting/filtering, use `SfDataManager` with `WebApiAdaptor`, `ODataV4Adaptor`, or `UrlAdaptor`, or handle server requests in `OnActionBegin`.

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

**Key migration changes:**

- `AllowGrouping` / `ShowGroupDropArea` → `AllowGrouping="true"` and `GridGroupSettings.ShowDropArea="true"`.
- `GroupColumnDescription` → `GridGroupSettings.Columns` or programmatic grouping through the grid API.
- Aggregates and group summaries: client-side aggregation via grid settings; for server-side grouping use `SfDataManager` or server aggregation endpoints.

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
- `SelectionMode` → `GridSelectionSettings.Mode` (e.g., `SelectionMode.Row`, `SelectionMode.Cell`).
- `SelectionUnit` → `GridSelectionSettings.Type` (e.g., `SelectionType.Single`, `SelectionType.Multiple`).
- `SelectedItems` → use `await Grid.GetSelectedRecordsAsync()` or `await Grid.GetSelectedRowIndexesAsync()` to retrieve selection.
- WPF `SelectionChanged` → Blazor `RowSelected`, `RowDeselected`, `RowSelecting` via `GridEvents`.

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
- External `SfDataPager` (WPF) → built-in `GridPageSettings` (`PageSize`, `PageSizes`, `AllowPaging`) on `<SfGrid>`.
- For server paging use `SfDataManager` or handle paging requests by intercepting `ActionBegin` and fetching pages from the server.

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

> N> When using `EnableVirtualization="true"`, you must set an explicit `Height` on the grid (e.g., `Height="500px"`). 

**Key migration changes:**

- `EnableDataVirtualization` → `EnableVirtualization="true"` and `EnableColumnVirtualization="true"` on `<SfGrid>`.
- Virtualization requires explicit `Height` (or container sizing) to work in browsers.
- For very large datasets, prefer server virtual scrolling via `SfDataManager` / remote adaptor; virtual DOM recycling means DOM-dependent assumptions (for example, querying rows by index) may not hold.

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
{% highlight css tabtitle="app.css" %}

.high-freight-row {
    background-color: #fff3cd;
    color: #856404;
}

{% endhighlight %}
{% endtabs %}

**Key migration changes:**

- WPF `CellStyle` / `RowStyle` / triggers → use `CustomAttributes` on `GridColumn`, `QueryCellInfo` / `RowDataBound` callbacks to add CSS classes or attributes.
- Apply visual rules in CSS (in `wwwroot/css`) and add classes from `QueryCellInfo` / `OnRowDataBound` using `args.Cell.AddClass(...)` / `args.Row.AddClass(...)`.
- Alternate row styling: use CSS selectors (`tr:nth-child(odd)`) or add classes in `RowDataBound`.

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

**Key migration changes:**

- `FrozenColumnCount` (WPF) → per-column `IsFrozen="true"` (`<GridColumn IsFrozen="true" />`) in Blazor.
- Combining frozen columns with virtualization requires `EnableVirtualization`, `EnableColumnVirtualization`, and potentially `EnableVirtualMaskRow` - test across browsers for scroll/layout behavior.
- Tune `RowHeight`, `EnableHover`, column widths, and virtualization settings for best performance in web scenarios.

## See also

- [Blazor DataGrid Demos](https://blazor.syncfusion.com/demos/datagrid/overview?theme=fluent2)
- [Blazor TreeGrid Demos](https://blazor.syncfusion.com/demos/tree-grid/overview?theme=fluent2)
- [Blazor Chart Demos](https://blazor.syncfusion.com/demos/chart/overview?theme=fluent2)
- [Blazor Scheduler Demos](https://blazor.syncfusion.com/demos/scheduler/default-functionalities?theme=fluent2)
- [Blazor RichTextEditor Demos](https://blazor.syncfusion.com/demos/rich-text-editor/overview)
- [Blazor Diagram Demos](https://blazor.syncfusion.com/demos/diagram/flowchart)
 