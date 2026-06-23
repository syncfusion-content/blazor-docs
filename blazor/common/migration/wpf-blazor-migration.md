---
layout: post
title: Migrating WPF Controls to Blazor Components | Syncfusion
description: Step-by-step guide to migrate WPF controls to Blazor components on .NET 8+, including setup, configuration, code examples, and migration limitations.
platform: Blazor
component: Common
documentation: ug
---

# Migrating WPF Controls to Blazor Components

Migrating enterprise applications from **[WPF (Windows Presentation Foundation)](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/overview/)** to **[Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/)** involves a significant architectural transition, moving from a rich, XAML-based desktop client framework to a component-driven, cross-platform web framework running on .NET. This guide provides a structured, step-by-step migration approach for **[WPF Controls](https://www.syncfusion.com/wpf-controls)** to their corresponding **[Blazor components](https://www.syncfusion.com/blazor-components)** with the **Blazor Web App (Interactive Server)** rendering mode.

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

## Common setup and configuration

Create a Blazor project using one of the following getting started guides.

* [Getting Started with Blazor Web App](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)
* [Getting Started with Blazor Server App](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)
* [Getting Started with Blazor WebAssembly App](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)

This migration guide focuses on the **Blazor Web App (Interactive Server)** approach, which provides the most direct migration path from WPF by maintaining server-side logic and state management similar to traditional desktop applications. The interactive server rendering mode enables real-time server-client communication through SignalR, making it suitable for enterprise applications that require complex business logic and real-time updates.

The following shared setup applies to all components and covers the common configuration required before proceeding to the [component-specific migration steps](#component-specific-migration-steps).

### Package installation

In WPF applications, controls are typically installed as individual NuGet packages (for example, [Syncfusion.SfGrid.WPF](https://www.nuget.org/packages/Syncfusion.SfGrid.WPF) and [Syncfusion.SfChart.WPF](https://www.nuget.org/packages/Syncfusion.SfChart.WPF)) and referenced directly in XAML and code-behind.

In Blazor applications, components are also provided as individual NuGet packages (for example, [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid) and [Syncfusion.Blazor.Charts](https://www.nuget.org/packages/Syncfusion.Blazor.Charts)). Installing only the required component packages improves performance and reduces application size.

For the complete list of available packages, refer to the [Blazor NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages).

Additionally, install the [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes) NuGet package at the application level to enable styling.

### Service registration

In WPF, controls are usually declared in XAML and initialized in code-behind, so you do not need to register them explicitly. Application services are typically configured manually or through an external DI container.

Blazor uses the built-in .NET dependency injection (DI) system, so required services must be registered in the application's service container to enable component communication and framework functionality. When using **Blazor Web App (Interactive Server)**, ensure that services are registered with the appropriate lifetime scope to support interactive components and server-side state management.

In the `Program.cs` file, add the following namespace and register the required services.

{% tabs %}
{% highlight c# tabtitle="Program.cs" hl_lines="2 8" %}

...
using Syncfusion.Blazor;
...
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
// Register Blazor services
builder.Services.AddSyncfusionBlazor();
...

{% endhighlight %}
{% endtabs %}

### Add required namespaces

In Blazor applications, after installing the required packages and registering services, import the necessary namespaces in the `_Imports.razor` file.

{% tabs %}
{% highlight razor tabtitle="_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Charts
@using Syncfusion.Blazor.Schedule

{% endhighlight %}
{% endtabs %}

This example includes the namespaces used by the components covered in this guide. Import only the namespaces needed for the components used in your application.

### Theme and script configuration

**WPF approach**

In WPF, themes are typically applied using [SfSkinManager](https://help.syncfusion.com/wpf/themes/skin-manager), while additional styling can be managed through `ResourceDictionary` and XAML-based styling. Scripts are not required because rendering happens locally in the desktop runtime.

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

In Blazor, the theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the [stylesheet](https://blazor.syncfusion.com/documentation/appearance/themes) and [script references](https://blazor.syncfusion.com/documentation/common/adding-script-references) in the **App.razor** file.

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

## Understanding Data Binding Between DataContext and Blazor Parameters

Data binding is a fundamental concept in both WPF and Blazor, but the implementation approaches differ significantly.

### WPF DataContext approach

In WPF, the `DataContext` property is a powerful mechanism that enables declarative data binding. You set the `DataContext` to a view model instance that typically implements `INotifyPropertyChanged`, and XAML bindings automatically resolve against this object. This allows UI elements to automatically update when the underlying data changes.

When the data source implements `INotifyCollectionChanged` (such as `ObservableCollection<T>`), the `SfDataGrid` control automatically refreshes the UI when items are added, removed, or when the list is cleared. However, when using a standard `List<T>`, the grid will not automatically refresh when the collection is modified.

{% tabs %}
{% highlight c# tabtitle="MainWindow.xaml.cs" %}

using System.ComponentModel;
using System.Collections.ObjectModel;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        // Set the DataContext to bind XAML elements to the view model
        this.DataContext = new OrderViewModel();
    }
}

public class OrderViewModel : INotifyPropertyChanged
{
    private ObservableCollection<Order> orders;
    
    public ObservableCollection<Order> Orders
    {
        get { return orders; }
        set
        {
            if (orders != value)
            {
                orders = value;
                OnPropertyChanged(nameof(Orders));
            }
        }
    }
    
    public OrderViewModel()
    {
        Orders = new ObservableCollection<Order>
        {
            new Order { OrderID = 10248, CustomerID = "VINET", Freight = 32.38 },
            new Order { OrderID = 10249, CustomerID = "TOMSP", Freight = 11.61 },
            new Order { OrderID = 10250, CustomerID = "HANAR", Freight = 65.83 }
        };
    }

    public event PropertyChangedEventHandler PropertyChanged;
    
    private void OnPropertyChanged(string propertyName)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}

public class Order
{
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
}

{% endhighlight %}
{% endtabs %}

### Blazor parameter and binding approach

In Blazor, data flows through component parameters and the `@bind` directive. Instead of a global `DataContext`, each component explicitly defines its data dependencies through parameters. This approach provides more explicit data flow, better component composition, and type-safe binding.

The [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) supports binding to any `IEnumerable` collection such as `List<T>`, `ObservableCollection<T>`, collections of `ExpandoObject`, `DynamicObject`, or `DataTable`, directly to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property of the Grid. When using `ObservableCollection<T>`, the component automatically reflects changes made externally. For standard `List<T>`, call the [Refresh](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Refresh_System_Boolean_) method to reflect externally made changes to avoid tracking changes for performance considerations.

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

**Key differences in data binding**

| Aspect | WPF DataContext | Blazor Parameters |
|---|---|---|
| Scope | Global to window/control hierarchy | Explicit per component |
| Binding declaration | `{Binding PropertyName}` in XAML | `@PropertyName` or `@bind` in Razor |
| Property changes | `INotifyPropertyChanged` triggers UI updates | Component state changes trigger re-renders |
| Collection type | `ObservableCollection<T>` for automatic notifications | `List<T>` or `ObservableCollection<T>` (for `ObservableCollection<T>`, automatic notifications; for `List<T>`, call [Refresh()](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Refresh_System_Boolean_) method) |
| Type safety | Resolved at runtime | Type-safe at compile time |
| Two-way binding | `{Binding PropertyName, Mode=TwoWay}` | `@bind-Value="@PropertyName"` |
| Update notification | Automatic via `PropertyChanged` event | Automatic for `ObservableCollection<T>` or manual via `Refresh()` or re-assignment for `List<T>` |
| Data sources supported | Collections implementing `INotifyCollectionChanged` or `IEnumerable` | `IEnumerable` collections: `List<T>`, `ObservableCollection<T>`, `ExpandoObject`, `DynamicObject`, `DataTable` |

## Component-specific migration steps

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

**WPF approach**

The [WPF DataGrid](https://www.syncfusion.com/wpf-controls/datagrid) control is defined in XAML, with its data collection assigned programmatically using the [ItemsSource](https://help.syncfusion.com/cr/wpf/Syncfusion.UI.Xaml.Grid.SfDataGrid.html#Syncfusion_UI_Xaml_Grid_SfDataGrid_ItemsSource) property.

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

The [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) component is declared in Razor markup, and it receives data through the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) parameter. When using **Blazor Web App (Interactive Server)**, the component runs on the server and updates the UI through interactive re-rendering.

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

@page "/orders"
@rendermode InteractiveServer
@using Syncfusion.Blazor.Grids

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

## Migration limitations and considerations

Migrating from WPF to Blazor requires understanding key architectural differences that will impact how you design and structure your applications. While Blazor offers many advantages as a modern web framework, certain WPF-specific features and patterns have no direct equivalents in the web environment.

### UI layout differences: Pixel-based WPF vs. responsive CSS

**WPF approach**

WPF uses a device-independent pixel (DIP) measurement system with fixed positioning, providing pixel-perfect control over element dimensions, spacing, and layout. Elements maintain consistent sizes regardless of viewing context, relying on hardware-accelerated GPU rendering through the native WPF engine.

{% tabs %}
{% highlight xaml tabtitle="MainWindow.xaml" %}

<StackPanel>
    <TextBlock Width="200" Height="50" Margin="10,10,10,10" Text="Sample Text"/>
    <Button Width="100" Height="40" Margin="5,5,5,5" Content="Click Me"/>
</StackPanel>

{% endhighlight %}
{% endtabs %}

**Blazor approach**

Blazor components render as standard HTML and CSS in the browser, requiring a shift to responsive design principles. Dimensions are typically specified in flexible units (percentages, em, rem) rather than fixed pixels, allowing layouts to adapt seamlessly across different screen sizes and viewports. The browser's rendering engine handles layout calculations, with built-in DPI scaling support through CSS media queries and zoom levels.

{% tabs %}
{% highlight html tabtitle="Layout.razor" %}

<div style="display: flex; flex-direction: column;">
    <span style="width: 200px; height: 50px; margin: 10px; padding: 5px;">Sample Text</span>
    <button style="width: 100px; height: 40px; margin: 5px; padding: 5px;">Click Me</button>
</div>

{% endhighlight %}
{% endtabs %}

**Key differences**

| Aspect | WPF | Blazor |
|---|---|---|
| Layout model | Absolute positioning with layout panels | Flow-based CSS layout (Flexbox, Grid) |
| Responsive design | Limited and requires manual handling  | Native browser support |
| Units | Device-independent pixels (DIPs) | Pixels, percentages, em, rem |
| Scaling | Hardware-accelerated DPI scaling | Browser zoom and CSS media queries |
| Overflow handling | Controlled by layout panels (StackPanel, Grid, DockPanel) | CSS overflow properties |
| Rendering | GPU rendering via native engine | Browser rendering engine (hardware-accelerated) |

**Migration strategy**

* Replace fixed pixel dimensions with flexible CSS units (percentages, em, rem) where appropriate
* Use CSS Flexbox or CSS Grid in place of WPF layout panels (StackPanel, Grid, DockPanel)
* Implement CSS media queries for responsive layouts across different screen sizes
* Test your layouts across multiple browsers and device sizes
* Consider adopting CSS frameworks (Bootstrap, Tailwind CSS) to accelerate responsive design implementation

### Different lifecycle and event models

**WPF lifecycle**

WPF controls usually follow a synchronous lifecycle. Events like `Loaded` and `Unloaded` are used to start work, clean up resources, and respond to user actions directly on the UI thread. This approach is straightforward, but long-running tasks can block the interface if they are not handled carefully.

{% tabs %}
{% highlight c# tabtitle="MainWindow.xaml.cs" %}

public class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        this.Loaded += MainWindow_Loaded;
        this.Unloaded += MainWindow_Unloaded;
    }

    private void MainWindow_Loaded(object sender, RoutedEventArgs e)
    {
        // Called when the window is fully loaded and visible
        LoadData();
    }

    private void MainWindow_Unloaded(object sender, RoutedEventArgs e)
    {
        // Called when the window is being unloaded; cleanup here
        CleanupResources();
    }

    private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        // Synchronous event execution
        ProcessSelection(e.AddedItems);
    }
}

{% endhighlight %}
{% endtabs %}

**Blazor lifecycle**

Blazor uses an asynchronous lifecycle that fits browser rendering and server communication. Common lifecycle methods include `OnInitializedAsync`, `OnParametersSetAsync`, and `OnAfterRenderAsync`. Event handling is also flexible, so component logic can run synchronously or asynchronously depending on the task.

{% tabs %}
{% highlight razor tabtitle="Sample.razor" %}

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
        // Called once when the component is first initialized
        await LoadDataAsync();
    }

    protected override void OnParametersSet()
    {
        // Called when the component receives new parameters
        RefreshData();
    }

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {
        // Called after the component is rendered to the DOM
        if (firstRender)
        {
            await InitializeAsync();
        }
    }

    private async Task OnActionBegin(ActionEventArgs<Order> args)
    {
        // Asynchronous event handling using EventCallback
        if (args.RequestType == Syncfusion.Blazor.Grids.Action.Save)
        {
            await SaveDataAsync(args.Data);
        }
    }

    private async Task LoadDataAsync()
    {
        // Async data loading from a service or database
        await Task.Delay(100);
        Orders = new List<Order>
        {
            new Order { OrderID = 10248, CustomerID = "VINET", Freight = 32.38 }
        };
    }

    private void RefreshData()
    {
        // Data refresh logic
    }

    private async Task InitializeAsync()
    {
        // Post-render initialization (e.g., JavaScript interop)
        await Task.CompletedTask;
    }

    private async Task SaveDataAsync(Order order)
    {
        // Async save operation
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

**Key differences**

| Aspect | WPF | Blazor |
|---|---|---|
| Initialization | Synchronous `Loaded` event | Asynchronous `OnInitializedAsync` |
| Parameter changes | `DependencyProperty` change notifications | `OnParametersSetAsync` |
| Post-render operations | Direct event handler execution | `OnAfterRenderAsync` |
| Event handling | Synchronous routed events and delegates | Direct `EventCallback` properties such as `OnActionBegin` and `OnActionComplete` |
| Cleanup | `Unloaded` event | `IAsyncDisposable` interface |
| Rendering model | Immediate, blocking in UI thread | Server-side with SignalR client updates |
| Performance implications | Blocking operations freeze the UI | Async/await prevents server blocking |

**Migration strategy**

* Convert synchronous event handlers to asynchronous `EventCallback` methods
* Move initialization logic from `Loaded` to `OnInitializedAsync`
* Use `OnParametersSetAsync` for responding to parameter changes instead of `DependencyProperty` handlers
* Leverage `OnAfterRenderAsync` for DOM-dependent logic and JavaScript interop
* Implement `IAsyncDisposable` and use the `@implements` directive for proper resource cleanup
* Always use `async`/`await` in event handlers and lifecycle methods to prevent blocking the interactive server connection
* Test thoroughly for race conditions that may occur due to asynchronous re-rendering

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

 