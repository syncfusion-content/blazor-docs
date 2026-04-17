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

1. **[DataGrid](#1-datagrid)** - Tabular data display with sorting, filtering, editing, and grouping
2. **[TreeGrid](#2-treegrid)** - Hierarchical data display in a grid format
3. **[Charts](#3-charts)** - Data visualization with various chart types
4. **[Scheduler](#4-scheduler)** - Calendar and appointment scheduling
5. **[Diagram](#5-diagram)** - Visual diagramming and flowchart creation
6. **[RichTextEditor](#6-richtexteditor)** - Rich text editing with formatting capabilities

Each component section includes package installation, theme setup, service registration, and basic rendering code for both platforms.

### 1. DataGrid

For detailed explanation, refer to the [WPF DataGrid getting started guide](https://help.syncfusion.com/wpf/datagrid/getting-started) and [Blazor DataGrid getting started guide](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-server-app).

#### Migration overview

| Aspect | WPF | Blazor |
|---|---|---|
| **Package** | `Syncfusion.SfGrid.WPF` | `Syncfusion.Blazor.Grid` |
| **Namespace** | XAML: `xmlns:syncfusion` | Razor: `@using Syncfusion.Blazor.Grids` |
| **Binding** | `ItemsSource="{Binding}"` | `DataSource="@Orders"` |
| **Theme approach** | ResourceDictionary | CSS file |
| **Steps** | 3 steps | 5 steps |

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

<Window xmlns:syncfusion="http://schemas.syncfusion.com/wpf">
    <syncfusion:SfDataGrid x:Name="dataGrid" 
                           ItemsSource="{Binding Orders}"
                           AutoGenerateColumns="True" />
</Window>

{% endhighlight %}
{% endtabs %}

**Blazor equivalent (Orders.razor):**

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

@page "/orders"
@rendermode InteractiveServer

<SfGrid DataSource="@Orders" >
  <GridColumns>
      <GridColumn Field="OrderID" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
      <GridColumn Field="CustomerID" HeaderText="Customer ID" Width="100"></GridColumn>
      <GridColumn Field="OrderDate" HeaderText="Order Date" Width="100"></GridColumn>
      <GridColumn Field="Freight" HeaderText="Freight" Width="120"></GridColumn>
  </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 10).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }
    
    public class Order {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
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

| Aspect | WPF | Blazor |
|---|---|---|
| **Package** | `Syncfusion.SfGrid.WPF` | `Syncfusion.Blazor.TreeGrid` |
| **Namespace** | XAML: `xmlns:syncfusion` | Razor: `@using Syncfusion.Blazor.TreeGrid` |
| **Hierarchy binding** | `ChildPropertyName="Children"` | `IdMapping` + `ParentIdMapping` |
| **Data structure** | Self-referencing or nested | Self-referencing (flat collection) |
| **Steps** | 3 steps | 4 steps |

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

<Window xmlns:syncfusion="http://schemas.syncfusion.com/wpf">
    <syncfusion:SfTreeGrid x:Name="treeGrid"
                           ItemsSource="{Binding Employees}"
                           ChildPropertyName="Children"
                           AutoGenerateColumns="True" />
</Window>

{% endhighlight %}
{% endtabs %}

**Blazor equivalent (Employees.razor):**

{% tabs %}
{% highlight razor tabtitle="Employees.razor" %}

@page "/employees"
@rendermode InteractiveServer

<SfTreeGrid DataSource="@TreeData" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1">
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="5" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="30" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code
{
    public class BusinessObject
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public int? ParentId { get; set; }
    }

    public List<BusinessObject> TreeData = new List<BusinessObject>();

    protected override void OnInitialized()
    {
        TreeData.Add(new BusinessObject() { TaskId = 1, TaskName = "Parent Task 1", ParentId = null });
        TreeData.Add(new BusinessObject() { TaskId = 2, TaskName = "Child task 1", ParentId = 1 });
        TreeData.Add(new BusinessObject() { TaskId = 3, TaskName = "Child Task 2", ParentId = 1, });
        TreeData.Add(new BusinessObject() { TaskId = 4, TaskName = "Parent Task 2", ParentId = null });
        TreeData.Add(new BusinessObject() { TaskId = 5, TaskName = "Child Task 5", ParentId = 4 });
        TreeData.Add(new BusinessObject() { TaskId = 6, TaskName = "Child Task 6", ParentId = 5 });
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

| Aspect | WPF | Blazor |
|---|---|---|
| **Package** | `Syncfusion.SfChart.WPF` | `Syncfusion.Blazor.Charts` |
| **Namespace** | XAML: `xmlns:chart` | Razor: `@using Syncfusion.Blazor.Charts` |
| **Series definition** | Nested XAML elements | Razor components |
| **Data binding** | `ItemsSource` + `XBindingPath` | `DataSource` + `XName` |
| **Steps** | 3 steps | 4 steps |

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

<Window xmlns:chart="http://schemas.syncfusion.com/wpf">
    <chart:SfChart>
        <chart:SfChart.PrimaryAxis>
            <chart:CategoryAxis />
        </chart:SfChart.PrimaryAxis>
        <chart:SfChart.SecondaryAxis>
            <chart:NumericalAxis />
        </chart:SfChart.SecondaryAxis>
        <chart:SfChart.Series>
            <chart:ColumnSeries ItemsSource="{Binding SalesData}"
                               XBindingPath="Month"
                               YBindingPath="Sales" />
        </chart:SfChart.Series>
    </chart:SfChart>
</Window>

{% endhighlight %}
{% endtabs %}

**Blazor equivalent (Sales.razor):**

{% tabs %}
{% highlight razor tabtitle="Sales.razor" %}

@page "/sales"
@rendermode InteractiveServer

<SfChart Title="Sales (USD)">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="Data"
                     XName="Month" YName="Amount"
                     Type="Syncfusion.Blazor.Charts.ChartSeriesType.Column"
                     Name="Sales" />
    </ChartSeriesCollection>
</SfChart>

@code {
    public List<Point> Data { get; set; } = new()
    {
        new("Jan", 42500), new("Feb", 39100), new("Mar", 45900),
        new("Apr", 54400), new("May", 49350), new("Jun", 61200)
    };

    public record Point(string Month, double Amount);
}

{% endhighlight %}
{% endtabs %}

### 4. Scheduler

For detailed explanation, refer to the [WPF Scheduler getting started guide](https://help.syncfusion.com/wpf/scheduler/getting-started) and [Blazor Scheduler getting started guide](https://blazor.syncfusion.com/documentation/scheduler/getting-started).

#### Migration overview

| Aspect | WPF | Blazor |
|---|---|---|
| **Package** | `Syncfusion.SfSchedule.WPF` | `Syncfusion.Blazor.Schedule` |
| **Namespace** | XAML: `xmlns:syncfusion` | Razor: `@using Syncfusion.Blazor.Schedule` |
| **Appointment model** | `ScheduleAppointment` | Custom model with `TValue` |
| **View configuration** | `ScheduleType` enum | `ScheduleView` components |
| **Steps** | 3 steps | 4 steps |

#### Step-by-step migration

##### Step 1: Package installation

Install the Scheduler NuGet package to enable calendar and appointment scheduling features.

**WPF approach:**

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.SfSchedule.WPF

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

<Window xmlns:syncfusion="http://schemas.syncfusion.com/wpf">
    <syncfusion:SfScheduler x:Name="scheduler"
                            ScheduleType="Week"
                            ItemsSource="{Binding Appointments}">
        <syncfusion:SfScheduler.AppointmentMapping>
            <syncfusion:AppointmentMapping 
                SubjectMapping="Subject"
                StartTimeMapping="StartTime"
                EndTimeMapping="EndTime" />
        </syncfusion:SfScheduler.AppointmentMapping>
    </syncfusion:SfScheduler>
</Window>

{% endhighlight %}
{% endtabs %}

**Blazor equivalent (Calendar.razor):**

{% tabs %}
{% highlight razor tabtitle="Calendar.razor" %}

@page "/calendar"
@rendermode InteractiveServer

<SfSchedule TValue=AppointmentData>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>
@code {
    public class AppointmentData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public bool IsAllDay { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

### 5. Diagram

For detailed explanation, refer to the [WPF Diagram getting started guide](https://help.syncfusion.com/wpf/diagram/getting-started) and [Blazor Diagram getting started guide](https://blazor.syncfusion.com/documentation/diagram/getting-started).

#### Migration overview

| Aspect | WPF | Blazor |
|---|---|---|
| **Package** | `Syncfusion.SfDiagram.WPF` | `Syncfusion.Blazor.Diagram` |
| **Namespace** | XAML: `xmlns:syncfusion` | Razor: `@using Syncfusion.Blazor.Diagram` |
| **Node definition** | `NodeCollection` in XAML | `DiagramObjectCollection<Node>` in code |
| **Connector definition** | `ConnectorCollection` in XAML | `DiagramObjectCollection<Connector>` in code |
| **Steps** | 3 steps | 4 steps |

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

<Window xmlns:syncfusion="http://schemas.syncfusion.com/wpf">
    <syncfusion:SfDiagram x:Name="diagram">
        <syncfusion:SfDiagram.Nodes>
            <syncfusion:NodeCollection>
                <syncfusion:NodeViewModel UnitHeight="100" 
                                         UnitWidth="100" 
                                         OffsetX="100" 
                                         OffsetY="100" 
                                         Shape="{syncfusion:FlowChartShape ShapeType=Process}" />
            </syncfusion:NodeCollection>
        </syncfusion:SfDiagram.Nodes>
    </syncfusion:SfDiagram>
</Window>

{% endhighlight %}
{% endtabs %}

**Blazor equivalent (Flow.razor):**

{% tabs %}
{% highlight razor tabtitle="Flow.razor" %}

@page "/flow"
@rendermode InteractiveServer

<SfDiagramComponent Height="600px" 
                    Width="100%" 
                    Nodes="@nodes" 
                    Connectors="@connectors">
    <SnapSettings>
        <HorizontalGridLines LineColor="#e0e0e0" />
        <VerticalGridLines LineColor="#e0e0e0" />
    </SnapSettings>
</SfDiagramComponent>

@code {
    DiagramObjectCollection<Node> nodes = new DiagramObjectCollection<Node>();
    DiagramObjectCollection<Connector> connectors = new DiagramObjectCollection<Connector>();
    
    protected override void OnInitialized()
    {
        // Create node
        Node node1 = new Node()
        {
            ID = "node1",
            Height = 100,
            Width = 100,
            OffsetX = 300,
            OffsetY = 100,
            Shape = new FlowShape() 
            { 
                Type = NodeShapes.Flow, 
                Shape = NodeFlowShapes.Process 
            },
            Style = new ShapeStyle() 
            { 
                Fill = "#6495ED", 
                StrokeColor = "#6495ED" 
            }
        };
        nodes.Add(node1);
        
        // Create connector
        Connector connector1 = new Connector()
        {
            ID = "connector1",
            SourceID = "node1",
            TargetID = "node2",
            Type = ConnectorSegmentType.Orthogonal
        };
        connectors.Add(connector1);
    }
}

{% endhighlight %}
{% endtabs %}

### 6. RichTextEditor

For detailed explanation, refer to the [WPF RichTextBox getting started guide](https://help.syncfusion.com/wpf/richtextbox/getting-started) and [Blazor RichTextEditor getting started guide](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started).

#### Migration overview

| Aspect | WPF | Blazor |
|---|---|---|
| **Package** | `Syncfusion.SfRichTextBoxAdv.WPF` | `Syncfusion.Blazor.RichTextEditor` |
| **Component name** | `SfRichTextBoxAdv` | `SfRichTextEditor` |
| **Namespace** | XAML: `xmlns:syncfusion` | Razor: `@using Syncfusion.Blazor.RichTextEditor` |
| **Content binding** | `Document` property | `@bind-Value` |
| **Toolbar** | Built-in ribbon UI | Configurable toolbar |
| **Steps** | 3 steps | 4 steps |

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

<Window xmlns:syncfusion="http://schemas.syncfusion.com/wpf">
    <syncfusion:SfRichTextBoxAdv x:Name="richTextBox"
                                 LayoutType="Pages">
        <syncfusion:SfRichTextBoxAdv.RibbonUI>
            <syncfusion:SfRichTextRibbonUI />
        </syncfusion:SfRichTextBoxAdv.RibbonUI>
    </syncfusion:SfRichTextBoxAdv>
</Window>

{% endhighlight %}
{% endtabs %}

**Blazor equivalent (Editor.razor):**

{% tabs %}
{% highlight razor tabtitle="Editor.razor" %}

@page "/editor"
@rendermode InteractiveServer

<SfRichTextEditor @bind-Value="@EditorContent" Height="500px">
    <RichTextEditorToolbarSettings Items="@Tools" />
</SfRichTextEditor>

@code {
    private string EditorContent { get; set; } = "<p>Start typing here...</p>";
    
    private List<ToolbarItemModel> Tools = new List<ToolbarItemModel>()
    {
        new ToolbarItemModel() { Command = ToolbarCommand.Bold },
        new ToolbarItemModel() { Command = ToolbarCommand.Italic },
        new ToolbarItemModel() { Command = ToolbarCommand.Underline },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.Formats },
        new ToolbarItemModel() { Command = ToolbarCommand.Alignments },
        new ToolbarItemModel() { Command = ToolbarCommand.OrderedList },
        new ToolbarItemModel() { Command = ToolbarCommand.UnorderedList },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.CreateLink },
        new ToolbarItemModel() { Command = ToolbarCommand.Image },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },
        new ToolbarItemModel() { Command = ToolbarCommand.SourceCode },
        new ToolbarItemModel() { Command = ToolbarCommand.Undo },
        new ToolbarItemModel() { Command = ToolbarCommand.Redo }
    };
    
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

---

## Detailed DataGrid migration

The following sections provide **in-depth migration guidance** for the **Syncfusion DataGrid**, covering data binding, columns, editing, sorting, filtering, paging, events, styling, and performance optimization.

### Key DataGrid property concepts

Before diving into detailed migration, understanding the **intent and migration relevance** of major DataGrid properties is essential:

| Property / Feature | Intent | Migration Relevance |
|---|---|---|
| **ItemsSource / DataSource** | Binds the grid to a data collection | WPF uses `ItemsSource` with `ObservableCollection`; Blazor uses `DataSource` with `List<T>` or `IEnumerable<T>` |
| **AutoGenerateColumns** | Automatically creates columns from data model properties | WPF: `AutoGenerateColumns="True"`; Blazor: Manual `<GridColumns>` definition recommended for control |
| **AllowEditing / GridEditSettings** | Enables inline, batch, or dialog editing | WPF: `AllowEditing="True"`; Blazor: `<GridEditSettings AllowEditing="true" Mode="EditMode.Normal">` |
| **AllowSorting / AllowFiltering** | Enables user-driven sorting and filtering | Direct property mapping from WPF to Blazor with similar syntax |
| **SelectionMode / GridSelectionSettings** | Controls single or multiple row/cell selection | WPF: `SelectionMode` property; Blazor: `<GridSelectionSettings Mode="...">` |
| **AllowPaging / GridPageSettings** | Enables pagination | WPF uses external `SfDataPager`; Blazor has built-in `<GridPageSettings>` |
| **Validation (IDataErrorInfo / ValidationRules)** | Enforces data integrity during editing | WPF: `IDataErrorInfo` interface; Blazor: `ValidationRules` property on columns |
| **Events (GridEvents)** | Handles user actions (row click, edit, save, delete) | WPF: Event handlers in code-behind; Blazor: `<GridEvents TValue="...">` component |

### Data binding

#### WPF data binding

{% tabs %}
{% highlight c# tabtitle="OrderViewModel.cs" %}

// WPF ViewModel
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
        <syncfusion:GridTextColumn    HeaderText="Order ID"  MappingName="OrderID" />
        <syncfusion:GridTextColumn    HeaderText="Customer"  MappingName="CustomerID" />
        <syncfusion:GridNumericColumn HeaderText="Freight"   MappingName="Freight" />
    </syncfusion:SfDataGrid.Columns>
</syncfusion:SfDataGrid>

{% endhighlight %}
{% endtabs %}

#### Blazor data binding

{% tabs %}
{% highlight c# tabtitle="Order.cs" %}

// Order.cs — reusable from WPF without modification
public class Order
{
    public int    OrderID    { get; set; }
    public string CustomerID { get; set; }
    public double Freight    { get; set; }
    public string ShipCity   { get; set; }
    public DateTime OrderDate { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

@page "/orders"
@rendermode InteractiveServer
@inject OrderService OrderService

<SfGrid TValue="Order" DataSource="@Orders" AllowSorting="true" AllowPaging="true">
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)"    HeaderText="Order ID"   IsPrimaryKey="true"      Width="120" />
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer"                            Width="150" />
        <GridColumn Field="@nameof(Order.Freight)"    HeaderText="Freight"    Format="C2"              Width="120" />
        <GridColumn Field="@nameof(Order.OrderDate)"  HeaderText="Order date" Format="d" Type="ColumnType.Date" Width="150" />
    </GridColumns>
</SfGrid>

@code {
    private List<Order> Orders { get; set; } = new();

    protected override async Task OnInitializedAsync()
    {
        Orders = await OrderService.GetOrdersAsync();
    }
}

{% endhighlight %}
{% endtabs %}

#### Data binding comparison

| Feature | WPF (`SfDataGrid`) | Blazor ([`SfGrid<TValue>`](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-server-app)) |
|---|---|---|
| **Bind property** | `ItemsSource="{Binding Orders}"` | `DataSource="@Orders"` |
| **Collection type** | `ObservableCollection<T>` | `List<T>`, `IEnumerable<T>` |
| **Change notification** | `INotifyPropertyChanged` | `StateHasChanged()` |
| **Column definition** | `SfDataGrid.Columns` (XAML) | `<GridColumns>` (Razor) |
| **Field mapping** | `MappingName="OrderID"` | `Field="@nameof(Order.OrderID)"` |
| **Async loading** | BackgroundWorker / Task + Dispatcher | `OnInitializedAsync()` |
| **Generic type** | Inferred from `ItemsSource` | Explicit `TValue="Order"` required |

### Columns and column types

#### Column type mapping

| WPF column type | Blazor equivalent | Notes |
|---|---|---|
| `GridTextColumn` | [`GridColumn`](https://blazor.syncfusion.com/documentation/datagrid/columns/column-types) (default) | Text / string data |
| `GridNumericColumn` | `GridColumn` with `Format="N2"` | Numeric data |
| `GridCurrencyColumn` | `GridColumn` with `Format="C2"` | Currency data |
| `GridDateTimeColumn` | `GridColumn` with `Type="ColumnType.Date"` | Date / DateTime |
| `GridCheckBoxColumn` | `GridColumn` with `Type="ColumnType.Boolean"` | Boolean / checkbox |
| `GridComboBoxColumn` | `GridColumn` with `EditType="EditType.DropDownEdit"` | Dropdown editing |
| `GridTemplateColumn` | [`GridTemplateColumn`](https://blazor.syncfusion.com/documentation/datagrid/columns/column-template) | Custom cell templates |
| `GridImageColumn` | `GridTemplateColumn` | Image rendering |
| `GridHyperlinkColumn` | `GridTemplateColumn` | Hyperlink rendering |
| `GridUnboundColumn` | `GridColumn` with `Template` | Computed / unbound data |

#### Template column example

**WPF:**

{% tabs %}
{% highlight xml tabtitle="OrderView.xaml" %}

<syncfusion:GridTemplateColumn MappingName="ShipCity" HeaderText="Ship City">
    <syncfusion:GridTemplateColumn.CellTemplate>
        <DataTemplate>
            <TextBlock Text="{Binding ShipCity}" Foreground="Blue" />
        </DataTemplate>
    </syncfusion:GridTemplateColumn.CellTemplate>
</syncfusion:GridTemplateColumn>

{% endhighlight %}
{% endtabs %}

**Blazor:**

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

<GridColumn Field="@nameof(Order.ShipCity)" HeaderText="Ship City">
    <Template>
        @{ var order = context as Order; }
        <span style="color: blue; font-weight: 500;">@order?.ShipCity</span>
    </Template>
</GridColumn>

{% endhighlight %}
{% endtabs %}

#### Column formatting reference

| Data type | WPF | Blazor `Format` |
|---|---|---|
| Currency | `GridCurrencyColumn` | `Format="C2"` |
| Integer | `GridNumericColumn` | `Format="N0"` |
| Decimal | `GridNumericColumn` | `Format="N2"` |
| Short date | `GridDateTimeColumn` | `Format="d"` |
| Date-time | `GridDateTimeColumn` | `Format="g"` |

### Editing

#### WPF editing configuration

{% tabs %}
{% highlight xml tabtitle="OrderView.xaml" %}

<syncfusion:SfDataGrid AllowEditing="True" AddNewRowPosition="Top"
                       EditMode="Cell" ItemsSource="{Binding Orders}" />

{% endhighlight %}
{% endtabs %}

#### Blazor editing configuration

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

@page "/orders"
@rendermode InteractiveServer
@inject OrderService OrderService

<SfGrid TValue="Order" @ref="Grid" DataSource="@Orders"
        AllowPaging="true" Toolbar="@ToolbarItems">
    <GridEditSettings AllowAdding="true" AllowEditing="true"
                      AllowDeleting="true" Mode="EditMode.Normal" />
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)"    HeaderText="Order ID"
                    IsPrimaryKey="true" IsIdentity="true" Width="120" />
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer"
                    ValidationRules="@(new ValidationRules { Required = true, MinLength = 3 })"
                    Width="150" />
        <GridColumn Field="@nameof(Order.Freight)"    HeaderText="Freight"
                    Format="C2" EditType="EditType.NumericEdit"
                    ValidationRules="@(new ValidationRules { Required = true, Min = 0 })"
                    Width="120" />
        <GridColumn Field="@nameof(Order.OrderDate)"  HeaderText="Order date"
                    Format="d" Type="ColumnType.Date"
                    EditType="EditType.DatePickerEdit" Width="150" />
    </GridColumns>
    <GridEvents TValue="Order" OnActionComplete="OnActionComplete" />
</SfGrid>

@code {
    private SfGrid<Order> Grid;
    private List<Order> Orders { get; set; } = new();
    private List<string> ToolbarItems = new() { "Add", "Edit", "Delete", "Update", "Cancel" };

    protected override async Task OnInitializedAsync()
    {
        Orders = await OrderService.GetOrdersAsync();
    }

    private async Task OnActionComplete(ActionEventArgs<Order> args)
    {
        if (args.RequestType == Action.Save)
        {
            if (args.Action == "Add")
                await OrderService.AddOrderAsync(args.Data);
            else
                await OrderService.UpdateOrderAsync(args.Data);
        }
        if (args.RequestType == Action.Delete)
            await OrderService.DeleteOrderAsync(args.Data.FirstOrDefault());
    }
}

{% endhighlight %}
{% endtabs %}

#### Editing mode comparison

| Edit mode | WPF | Blazor | Notes |
|---|---|---|---|
| **Cell editing** | `EditMode.Cell` | `EditMode.Batch` | Commit on navigation |
| **Row editing** | `EditMode.Row` | `EditMode.Normal` | Full row edit state |
| **Dialog editing** | Custom | `EditMode.Dialog` | Built-in modal |
| **Add row** | `AddNewRowPosition="Top"` | `AllowAdding="true"` + Toolbar `"Add"` | |
| **Validation** | `IDataErrorInfo` | [`ValidationRules`](https://blazor.syncfusion.com/documentation/datagrid/editing/validation) property | Built-in client-side |

#### Edit types for columns

| Data type | `EditType` | Description |
|---|---|---|
| String | `EditType.DefaultEdit` | Standard text input |
| Number | `EditType.NumericEdit` | Numeric input with spinner |
| Date | `EditType.DatePickerEdit` | Date picker |
| DateTime | `EditType.DateTimePickerEdit` | Date and time picker |
| Boolean | `EditType.BooleanEdit` | Checkbox |
| Enum / List | `EditType.DropDownEdit` | Dropdown list |

### Sorting, filtering, and grouping

#### WPF configuration

{% tabs %}
{% highlight xml tabtitle="OrderView.xaml" %}

<syncfusion:SfDataGrid AllowSorting="True" AllowMultiSorting="True"
                       AllowFiltering="True" AllowGrouping="True"
                       ShowGroupDropArea="True" ItemsSource="{Binding Orders}" />

{% endhighlight %}
{% endtabs %}

#### Blazor configuration

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

<SfGrid TValue="Order" DataSource="@Orders"
        AllowSorting="true" AllowMultiSorting="true"
        AllowFiltering="true" AllowGrouping="true">
    <GridFilterSettings Type="FilterType.Excel" />
    <GridGroupSettings ShowDropArea="true" ShowGroupedColumn="true" />
    <GridSortSettings>
        <GridSortColumns>
            <GridSortColumn Field="OrderID" Direction="SortDirection.Ascending" />
        </GridSortColumns>
    </GridSortSettings>
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)"    HeaderText="Order ID"  Width="120" />
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer"  Width="150" />
        <GridColumn Field="@nameof(Order.Freight)"    HeaderText="Freight"   Format="C2" Width="120" />
        <GridColumn Field="@nameof(Order.ShipCity)"   HeaderText="Ship city" Width="150" />
    </GridColumns>
</SfGrid>

{% endhighlight %}
{% endtabs %}

#### Feature comparison

| Feature | WPF | Blazor |
|---|---|---|
| **Sorting** | `AllowSorting="True"` | [`AllowSorting="true"`](https://blazor.syncfusion.com/documentation/datagrid/sorting) |
| **Multi-column sort** | `AllowMultiSorting="True"` | `AllowMultiSorting="true"` |
| **Initial sort** | `SortColumnDescriptions` | `GridSortSettings > GridSortColumns` |
| **Filter UI** | `FilterRowPosition`, `FilterMode` | [`GridFilterSettings.Type`](https://blazor.syncfusion.com/documentation/datagrid/filtering/filter-bar) (Row, Excel, Menu, CheckBox) |
| **Group drop area** | `ShowGroupDropArea="True"` | [`GridGroupSettings.ShowDropArea="true"`](https://blazor.syncfusion.com/documentation/datagrid/grouping) |
| **Group caption** | `GroupCaptionTextFormat` | `GridGroupSettings.CaptionTemplate` |

### Selection

#### WPF selection

{% tabs %}
{% highlight xml tabtitle="OrderView.xaml" %}

<syncfusion:SfDataGrid SelectionMode="Extended" SelectionUnit="Row"
                       ItemsSource="{Binding Orders}" />

{% endhighlight %}
{% endtabs %}

#### Blazor selection

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

<SfGrid TValue="Order" @ref="Grid" DataSource="@Orders" AllowSelection="true">
    <GridSelectionSettings Mode="SelectionMode.Multiple" Type="SelectionType.Row" />
    <GridEvents TValue="Order" RowSelected="OnRowSelected" RowDeselected="OnRowDeselected" />
    <GridColumns>
        @* ...columns... *@
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<Order> Grid;

    private void OnRowSelected(RowSelectEventArgs<Order> args)
        => Console.WriteLine($"Selected: {args.Data?.CustomerID}");

    private void OnRowDeselected(RowDeselectEventArgs<Order> args)
        => Console.WriteLine($"Deselected: {args.Data?.CustomerID}");

    private async Task GetSelected()
        => await Grid.GetSelectedRecordsAsync();

    private async Task SelectFirstRow()
        => await Grid.SelectRowAsync(0);
}

{% endhighlight %}
{% endtabs %}

#### Selection comparison

| Feature | WPF | Blazor |
|---|---|---|
| **Selection mode** | `SelectionMode` (Single, Multiple, Extended) | [`GridSelectionSettings.Mode`](https://blazor.syncfusion.com/documentation/datagrid/selection/row-selection) (Single, Multiple) |
| **Selection unit** | `SelectionUnit` (Row, Cell, Any) | `GridSelectionSettings.Type` (Row, Cell) |
| **Get selected rows** | `SelectedItems` property | `GetSelectedRecordsAsync()` method |
| **Programmatic select** | `SelectedIndex`, `SelectedItem` | `SelectRowAsync()`, `SelectRowsAsync()` |
| **Clear selection** | `ClearSelections()` | `ClearSelectionAsync()` |
| **Checkbox selection** | `GridCheckBoxColumn` as first column | `GridSelectionSettings.CheckboxMode` |

### Paging and virtualization

#### WPF paging (external `SfDataPager`)

{% tabs %}
{% highlight xml tabtitle="OrderView.xaml" %}

<syncfusion:SfDataPager x:Name="dataPager" PageSize="20"
                        Source="{Binding Orders}" />
<syncfusion:SfDataGrid ItemsSource="{Binding ElementName=dataPager, Path=PagedSource}" />

{% endhighlight %}
{% endtabs %}

#### Blazor standard paging

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

<SfGrid TValue="Order" DataSource="@Orders" AllowPaging="true">
    <GridPageSettings PageSize="20" PageSizes="@(new int[] { 10, 20, 50, 100 })" />
    <GridColumns>
        @* ...columns... *@
    </GridColumns>
</SfGrid>

{% endhighlight %}
{% endtabs %}

#### Blazor row and column virtualization

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

<SfGrid TValue="Order" DataSource="@LargeOrders"
        EnableVirtualization="true" EnableColumnVirtualization="true" Height="600px">
    <GridColumns>
        @* ...columns... *@
    </GridColumns>
</SfGrid>

{% endhighlight %}
{% endtabs %}

> N> When using [`EnableVirtualization`](https://blazor.syncfusion.com/documentation/datagrid/virtual-scrolling), the `Height` property must be set. Do not enable paging and virtualization simultaneously.

#### Blazor infinite scrolling

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

<SfGrid TValue="Order" DataSource="@Orders"
        EnableInfiniteScrolling="true" Height="500px">
    <GridInfiniteScrollSettings InitialBlocks="5" />
    <GridColumns>
        @* ...columns... *@
    </GridColumns>
</SfGrid>

{% endhighlight %}
{% endtabs %}

#### Paging / virtualization comparison

| Feature | WPF | Blazor |
|---|---|---|
| **Paging** | External `SfDataPager` control | Built-in [`AllowPaging`](https://blazor.syncfusion.com/documentation/datagrid/paging) + `GridPageSettings` |
| **Row virtualization** | `EnableDataVirtualization` | `EnableVirtualization` |
| **Column virtualization** | `EnableColumnVirtualization` | `EnableColumnVirtualization` |
| **Infinite scroll** | Manual implementation | `EnableInfiniteScrolling` |
| **Page size dropdown** | Not built-in | `GridPageSettings.PageSizes` |

### Events and commands

#### WPF events and commands

{% tabs %}
{% highlight c# tabtitle="OrderViewModel.cs" %}

public ICommand RowDoubleClickCommand { get; }
public OrderViewModel()
{
    RowDoubleClickCommand = new RelayCommand<Order>(OnRowDoubleClick);
}
private void OnRowDoubleClick(Order order) { /* handle */ }

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight xml tabtitle="OrderView.xaml" %}

<syncfusion:SfDataGrid CurrentCellActivated="OnCellActivated"
                       SelectionChanged="OnSelectionChanged">
    <syncfusion:SfDataGrid.InputBindings>
        <MouseBinding MouseAction="LeftDoubleClick"
                      Command="{Binding RowDoubleClickCommand}" />
    </syncfusion:SfDataGrid.InputBindings>
</syncfusion:SfDataGrid>

{% endhighlight %}
{% endtabs %}

#### Blazor events via `GridEvents`

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

<SfGrid TValue="Order" DataSource="@Orders" AllowPaging="true" AllowSorting="true">
    <GridEvents TValue="Order"
                OnRecordDoubleClick="OnRecordDoubleClick"
                RowSelected="OnRowSelected"
                OnActionBegin="OnActionBegin"
                OnActionComplete="OnActionComplete"
                RowDataBound="OnRowDataBound" />
    <GridColumns>
        @* ...columns... *@
    </GridColumns>
</SfGrid>

@code {
    private void OnRowSelected(RowSelectEventArgs<Order> args)
        => Console.WriteLine($"Selected: {args.Data?.CustomerID}");

    private void OnRecordDoubleClick(RecordDoubleClickEventArgs<Order> args)
        => Console.WriteLine($"Double-clicked OrderID: {args.RowData?.OrderID}");

    private void OnActionBegin(ActionEventArgs<Order> args)
    {
        if (args.RequestType == Action.Save)
        {
            // Set args.Cancel = true to prevent save
        }
    }

    private async Task OnActionComplete(ActionEventArgs<Order> args)
    {
        if (args.RequestType == Action.Delete)
            await OrderService.DeleteOrderAsync(args.Data.FirstOrDefault());

        if (args.RequestType == Action.Save && args.Action == "Add")
            await OrderService.AddOrderAsync(args.Data);
    }

    private void OnRowDataBound(RowDataBoundEventArgs<Order> args)
    {
        if (args.Data.Freight > 500)
            args.Row.AddClass(new string[] { "high-freight-row" });
    }
}

{% endhighlight %}
{% endtabs %}

#### Events comparison

| WPF event / command | Blazor `GridEvents` callback | Notes |
|---|---|---|
| `CurrentCellActivated` | `CellSelected` | Cell focus |
| `SelectionChanged` | `RowSelected` / `RowDeselected` | Row selection change |
| `RecordDeleted` | `OnActionComplete` | `RequestType == Action.Delete` |
| `RecordAdded` | `OnActionComplete` | `RequestType == Action.Save`, `Action == "Add"` |
| `SortColumnsChanging` | `OnActionBegin` | `RequestType == Action.Sorting` |
| `FilterChanging` | `OnActionBegin` | `RequestType == Action.Filtering` |
| `MouseDoubleClick` / `ICommand` | `OnRecordDoubleClick` | `RecordDoubleClickEventArgs<T>` |
| `CellBeginEdit` | `OnActionBegin` | `RequestType == Action.BeginEdit` |
| `RowValidating` | `OnActionBegin` + `args.Cancel` | Set `args.Cancel = true` to prevent save |
| `QueryRowStyle` | `RowDataBound` | `args.Row.AddClass()` for CSS |

### Styling and theming

#### WPF theming

{% tabs %}
{% highlight xml tabtitle="App.xaml" %}

<Application.Resources>
    <ResourceDictionary>
        <ResourceDictionary.MergedDictionaries>
            <syncfusion:FluentThemeDictionary />
        </ResourceDictionary.MergedDictionaries>
    </ResourceDictionary>
</Application.Resources>

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight xml tabtitle="OrderView.xaml" %}

<syncfusion:GridTextColumn MappingName="Freight">
    <syncfusion:GridTextColumn.CellStyle>
        <Style TargetType="syncfusion:GridCell">
            <Setter Property="Background" Value="LightYellow" />
            <Setter Property="FontWeight" Value="Bold" />
        </Style>
    </syncfusion:GridTextColumn.CellStyle>
</syncfusion:GridTextColumn>

{% endhighlight %}
{% endtabs %}

#### Blazor theming

{% tabs %}
{% highlight html tabtitle="App.razor" %}

<!-- Fluent (closest to WPF Fluent) -->
<link href="_content/Syncfusion.Blazor.Themes/fluent.css" rel="stylesheet" />

<!-- Bootstrap 5 (default) -->
<link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />

{% endhighlight %}
{% endtabs %}

**Available [themes](https://blazor.syncfusion.com/documentation/appearance/themes):**

| Theme | CSS file |
|---|---|
| Bootstrap 5 | `bootstrap5.css` / `bootstrap5-dark.css` |
| Fluent | `fluent.css` / `fluent-dark.css` |
| Material 3 | `material3.css` / `material3-dark.css` |
| Tailwind | `tailwind.css` |
| High contrast | `highcontrast.css` |

**Column-level styling via `CustomAttributes`:**

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

<GridColumn Field="@nameof(Order.Freight)" HeaderText="Freight" Format="C2"
            CustomAttributes='@(new Dictionary<string, object> { { "class", "freight-col" } })' />

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight css tabtitle="app.css" %}

.freight-col       { background-color: lightyellow; font-weight: bold; }
.high-freight-row  { background-color: #fff3cd; color: #856404; }
.e-altrow          { background-color: #f9f9f9; }  /* Alternating rows */

{% endhighlight %}
{% endtabs %}

**Row-level conditional styling:**

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

<GridEvents TValue="Order" RowDataBound="OnRowDataBound" />

@code {
    private void OnRowDataBound(RowDataBoundEventArgs<Order> args)
    {
        if (args.Data.Freight > 500)
            args.Row.AddClass(new string[] { "high-freight-row" });
    }
}

{% endhighlight %}
{% endtabs %}

#### Theming comparison

| Concept | WPF | Blazor |
|---|---|---|
| **Theme application** | `ResourceDictionary` in `App.xaml` | CSS `<link>` in `Components/App.razor` |
| **Cell style** | `GridColumn.CellStyle` (XAML Style) | `CustomAttributes` + CSS class |
| **Row style** | `RowStyle` / `AlternatingRowStyle` | `RowDataBound` + CSS class |
| **Dynamic styling** | XAML `DataTriggers` | `RowDataBound` + `AddClass()` |
| **Custom theme** | Override XAML brushes | Override [CSS custom properties](https://blazor.syncfusion.com/documentation/appearance/theme-studio) |
| **Dark mode** | Theme variant assembly | Dark theme CSS file variant |

### Performance optimization

#### Blazor performance techniques

**1. Row and column virtualization (large in-memory datasets):**

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

<SfGrid TValue="Order" DataSource="@LargeOrders"
        EnableVirtualization="true" EnableColumnVirtualization="true" Height="600px">
    <GridColumns>
        @* ...columns... *@
    </GridColumns>
</SfGrid>

{% endhighlight %}
{% endtabs %}

**2. Remote data with `SfDataManager` (server-side operations):**

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

<SfGrid TValue="Order" AllowPaging="true" AllowSorting="true" AllowFiltering="true">
    <SfDataManager Url="/api/orders" Adaptor="Adaptors.WebApiAdaptor" />
    <GridPageSettings PageSize="50" />
    <GridFilterSettings Type="FilterType.Excel" />
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)"    HeaderText="Order ID" Width="120" />
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer" Width="150" />
        <GridColumn Field="@nameof(Order.Freight)"    HeaderText="Freight"  Format="C2" Width="120" />
    </GridColumns>
</SfGrid>

{% endhighlight %}
{% endtabs %}

> **Best practice:** Use [`SfDataManager`](https://blazor.syncfusion.com/documentation/datagrid/data-binding/webapi-service-binding) with `WebApiAdaptor` for datasets over 50,000 rows.

**3. Frozen columns:**

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

<SfGrid TValue="Order" DataSource="@Orders" FrozenColumns="2">
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)"    IsFrozen="true" Width="120" />
        <GridColumn Field="@nameof(Order.CustomerID)" IsFrozen="true" Width="150" />
        <GridColumn Field="@nameof(Order.Freight)"    Format="C2"     Width="120" />
    </GridColumns>
</SfGrid>

{% endhighlight %}
{% endtabs %}

**4. Render optimization and disposal:**

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

@implements IDisposable

@code {
    private SfGrid<Order> Grid;
    private bool _suppressRender = false;

    protected override bool ShouldRender() => !_suppressRender;

    private async Task BulkUpdate()
    {
        _suppressRender = true;
        Orders = await OrderService.GetOrdersAsync();
        _suppressRender = false;
        StateHasChanged();
    }

    public void Dispose() => Grid = null;
}

{% endhighlight %}
{% endtabs %}

#### Performance comparison

| Technique | WPF | Blazor |
|---|---|---|
| **Row virtualization** | `EnableDataVirtualization` | [`EnableVirtualization`](https://blazor.syncfusion.com/documentation/datagrid/virtual-scrolling) |
| **Column virtualization** | `EnableColumnVirtualization` | `EnableColumnVirtualization` |
| **Server-side operations** | WCF / REST + Dispatcher | [`SfDataManager`](https://blazor.syncfusion.com/documentation/datagrid/data-binding/webapi-service-binding) + `WebApiAdaptor` |
| **Frozen columns** | `FrozenColumnCount` | `GridColumn.IsFrozen` / `FrozenColumns` |
| **Deferred scroll** | `ScrollMode="Deferred"` | Handled by virtualization engine |
| **Render control** | WPF rendering pipeline | `ShouldRender()` override |
| **Memory management** | Explicit disposal | `IDisposable.Dispose()` |

## See also

- [Syncfusion WPF DataGrid - Getting started](https://help.syncfusion.com/wpf/datagrid/getting-started)
- [Syncfusion Blazor DataGrid - Getting started (Server)](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-server-app)
- [Syncfusion Blazor DataGrid - API reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html)
- [ASP.NET Core Blazor hosting models](https://learn.microsoft.com/en-us/aspnet/core/blazor/hosting-models)
- [Syncfusion Blazor themes](https://blazor.syncfusion.com/documentation/appearance/themes)
- [Syncfusion Blazor DataGrid - Editing](https://blazor.syncfusion.com/documentation/datagrid/editing/inline-editing)
- [Syncfusion Blazor DataGrid - Filtering](https://blazor.syncfusion.com/documentation/datagrid/filtering/filter-bar)
- [Syncfusion Blazor DataGrid - Virtualization](https://blazor.syncfusion.com/documentation/datagrid/virtual-scrolling)