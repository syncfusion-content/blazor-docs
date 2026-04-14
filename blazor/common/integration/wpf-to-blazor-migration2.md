---
layout: post
title: Migrating from WPF to Blazor using Syncfusion DataGrid
description: A comprehensive enterprise migration guide covering data binding, columns, editing, sorting, filtering, grouping, selection, paging, virtualization, events, styling, performance, and deployment using Syncfusion Blazor DataGrid in Visual Studio Code.
platform: Blazor
component: DataGrid
documentation: ug
---

# Migrating from WPF to Blazor using Syncfusion® DataGrid

## Overview

Migrating enterprise applications from **[WPF (Windows Presentation Foundation)](https://learn.microsoft.com/en-us/dotnet/desktop/wpf/overview/)** to **[Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/)** is a significant architectural transition—moving from a thick-client, XAML-based desktop framework to a component-driven, cross-platform web framework running on .NET. This guide provides a **structured, step-by-step migration path** focused on replacing the **[Syncfusion WPF DataGrid (`SfDataGrid`)](https://www.syncfusion.com/wpf-controls/datagrid)** with the **[Syncfusion Blazor DataGrid (`SfGrid<TValue>`)](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-server-app)**, developed using **[Visual Studio Code](https://code.visualstudio.com/)**.

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

> **Key insight:** The Syncfusion Blazor DataGrid ([`SfGrid<TValue>`](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-server-app)) is a **functionally equivalent, feature-rich replacement** for `SfDataGrid` in WPF, with comparable APIs for binding, editing, sorting, filtering, grouping, virtualization, and theming—while adding web-native capabilities such as remote data adapters, Excel-style filtering, and infinite scrolling.

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

## Installing and configuring Syncfusion DataGrid

### Step 1 — Install NuGet packages

**WPF:**

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.SfGrid.WPF

{% endhighlight %}
{% endtabs %}

**Blazor:**

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Grid -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

> N> In WPF, a single package covers the grid and its built-in themes. In Blazor, themes are distributed as a separate NuGet package (`Syncfusion.Blazor.Themes`) and referenced via a CSS link.

### Step 2 — Register services / startup configuration

**WPF** — Register the Syncfusion license key in `App.xaml.cs` (the application entry point). No additional service container registration is required.

{% tabs %}
{% highlight c# tabtitle="App.xaml.cs" %}

public partial class App : Application
{
    protected override void OnStartup(StartupEventArgs e)
    {
        // Register Syncfusion license
        Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR-LICENSE-KEY");
        base.OnStartup(e);
    }
}

{% endhighlight %}
{% endtabs %}

**Blazor** — Register Syncfusion services using the built-in dependency injection container in `Program.cs`.

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}

....
using Syncfusion.Blazor;
....
// Register Syncfusion license (before AddSyncfusionBlazor)
Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("YOUR-LICENSE-KEY");
builder.Services.AddSyncfusionBlazor();
....

{% endhighlight %}
{% endtabs %}

> **Key difference:** WPF uses `OnStartup` in `App.xaml.cs` for license registration. Blazor uses the ASP.NET Core DI pipeline in `Program.cs`, with `AddSyncfusionBlazor()` handling component registration alongside the license call.

### Step 3 — Apply theme

**WPF** — Apply the Syncfusion theme globally via a `ResourceDictionary` in `App.xaml`.

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

**Blazor** — Reference the Syncfusion theme CSS file in `App.razor` (the root HTML shell), along with the Syncfusion Blazor core script.

{% tabs %}
{% highlight html tabtitle="App.razor" %}

<!-- Syncfusion theme stylesheet (Fluent2 — closest to WPF Fluent theme) -->
<link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />

<!-- Syncfusion Blazor core script (required for DataGrid and most components) -->
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

> **Key difference:** WPF merges XAML resource dictionaries at runtime. Blazor references static CSS files, which are served directly from the NuGet package's static web assets.

### Step 4 — Declare namespaces / global usings

**WPF** — Declare the Syncfusion XML namespace on each XAML window or user control where the grid is used.

{% tabs %}
{% highlight xml tabtitle="MainWindow.xaml" %}

<Window xmlns:syncfusion="http://schemas.syncfusion.com/wpf">
    ...
</Window>

{% endhighlight %}
{% endtabs %}

**Blazor** — Add global `@using` directives once in `_Imports.razor`. These apply to every `.razor` file in the project, eliminating per-file declarations.

{% tabs %}
{% highlight razor tabtitle="_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

{% endhighlight %}
{% endtabs %}

> **Key difference:** WPF requires the `xmlns` declaration on every XAML file that uses Syncfusion controls. Blazor's `_Imports.razor` provides a single central location for global usings—equivalent to a `GlobalUsings.cs` file.

### Step 5 — Enable interactivity on pages

**WPF** — All WPF windows are interactive by default. No additional declaration is required to handle user input or trigger code-behind logic.

{% tabs %}
{% highlight xml tabtitle="OrderView.xaml" %}

<!-- WPF: No render mode declaration needed.
     All controls are interactive by default through the WPF rendering pipeline. -->
<Window x:Class="MyWpfApp.Views.OrderView"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:syncfusion="http://schemas.syncfusion.com/wpf">
    <syncfusion:SfDataGrid ItemsSource="{Binding Orders}" />
</Window>

{% endhighlight %}
{% endtabs %}

**Blazor** — In .NET 8+, components are static by default. Add `@rendermode InteractiveServer` to each page that requires real-time interactivity (event handling, data editing, SignalR connection).

{% tabs %}
{% highlight razor tabtitle="Orders.razor" %}

@page "/orders"
@rendermode InteractiveServer

{% endhighlight %}
{% endtabs %}

> **Key difference:** WPF has a single, always-interactive native rendering pipeline. Blazor 8+ introduces granular render modes (`Static`, `InteractiveServer`, `InteractiveWebAssembly`, `InteractiveAuto`). The Syncfusion `SfGrid` requires `InteractiveServer` (or another interactive mode) for full functionality such as editing, sorting, and event callbacks.

### Configuration comparison

| Step | WPF | Blazor |
|---|---|---|
| **1. Package** | `dotnet add package Syncfusion.SfGrid.WPF` | `dotnet add package Syncfusion.Blazor.Grid` + `Syncfusion.Blazor.Themes` |
| **2. Service registration / License** | `SyncfusionLicenseProvider.RegisterLicense()` in `App.xaml.cs` `OnStartup` | `RegisterLicense()` + `AddSyncfusionBlazor()` in `Program.cs` |
| **3. Theme** | `<ResourceDictionary>` merged in `App.xaml` | CSS `<link>` in `Components/App.razor` |
| **4. Namespace / Usings** | `xmlns:syncfusion=` on each `.xaml` file | `@using` once in `_Imports.razor` |
| **5. Interactivity** | Always-on (native rendering pipeline) | `@rendermode InteractiveServer` per page |

## Data binding

### WPF data binding

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

### Blazor data binding

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

### Data binding comparison

| Feature | WPF (`SfDataGrid`) | Blazor ([`SfGrid<TValue>`](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-server-app)) |
|---|---|---|
| **Bind property** | `ItemsSource="{Binding Orders}"` | `DataSource="@Orders"` |
| **Collection type** | `ObservableCollection<T>` | `List<T>`, `IEnumerable<T>` |
| **Change notification** | `INotifyPropertyChanged` | `StateHasChanged()` |
| **Column definition** | `SfDataGrid.Columns` (XAML) | `<GridColumns>` (Razor) |
| **Field mapping** | `MappingName="OrderID"` | `Field="@nameof(Order.OrderID)"` |
| **Async loading** | BackgroundWorker / Task + Dispatcher | `OnInitializedAsync()` |
| **Generic type** | Inferred from `ItemsSource` | Explicit `TValue="Order"` required |

## Columns and column types

### Column type mapping

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

### Template column example

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

### Column formatting reference

| Data type | WPF | Blazor `Format` |
|---|---|---|
| Currency | `GridCurrencyColumn` | `Format="C2"` |
| Integer | `GridNumericColumn` | `Format="N0"` |
| Decimal | `GridNumericColumn` | `Format="N2"` |
| Short date | `GridDateTimeColumn` | `Format="d"` |
| Date-time | `GridDateTimeColumn` | `Format="g"` |

## Editing

### WPF editing configuration

{% tabs %}
{% highlight xml tabtitle="OrderView.xaml" %}

<syncfusion:SfDataGrid AllowEditing="True" AddNewRowPosition="Top"
                       EditMode="Cell" ItemsSource="{Binding Orders}" />

{% endhighlight %}
{% endtabs %}

### Blazor editing configuration

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

### Editing mode comparison

| Edit mode | WPF | Blazor | Notes |
|---|---|---|---|
| **Cell editing** | `EditMode.Cell` | `EditMode.Batch` | Commit on navigation |
| **Row editing** | `EditMode.Row` | `EditMode.Normal` | Full row edit state |
| **Dialog editing** | Custom | `EditMode.Dialog` | Built-in modal |
| **Add row** | `AddNewRowPosition="Top"` | `AllowAdding="true"` + Toolbar `"Add"` | |
| **Validation** | `IDataErrorInfo` | [`ValidationRules`](https://blazor.syncfusion.com/documentation/datagrid/editing/validation) property | Built-in client-side |

### Edit types for columns

| Data type | `EditType` | Description |
|---|---|---|
| String | `EditType.DefaultEdit` | Standard text input |
| Number | `EditType.NumericEdit` | Numeric input with spinner |
| Date | `EditType.DatePickerEdit` | Date picker |
| DateTime | `EditType.DateTimePickerEdit` | Date and time picker |
| Boolean | `EditType.BooleanEdit` | Checkbox |
| Enum / List | `EditType.DropDownEdit` | Dropdown list |

## Sorting, filtering, and grouping

### WPF configuration

{% tabs %}
{% highlight xml tabtitle="OrderView.xaml" %}

<syncfusion:SfDataGrid AllowSorting="True" AllowMultiSorting="True"
                       AllowFiltering="True" AllowGrouping="True"
                       ShowGroupDropArea="True" ItemsSource="{Binding Orders}" />

{% endhighlight %}
{% endtabs %}

### Blazor configuration

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

### Feature comparison

| Feature | WPF | Blazor |
|---|---|---|
| **Sorting** | `AllowSorting="True"` | [`AllowSorting="true"`](https://blazor.syncfusion.com/documentation/datagrid/sorting) |
| **Multi-column sort** | `AllowMultiSorting="True"` | `AllowMultiSorting="true"` |
| **Initial sort** | `SortColumnDescriptions` | `GridSortSettings > GridSortColumns` |
| **Filter UI** | `FilterRowPosition`, `FilterMode` | [`GridFilterSettings.Type`](https://blazor.syncfusion.com/documentation/datagrid/filtering/filter-bar) (Row, Excel, Menu, CheckBox) |
| **Group drop area** | `ShowGroupDropArea="True"` | [`GridGroupSettings.ShowDropArea="true"`](https://blazor.syncfusion.com/documentation/datagrid/grouping) |
| **Group caption** | `GroupCaptionTextFormat` | `GridGroupSettings.CaptionTemplate` |

## Selection

### WPF selection

{% tabs %}
{% highlight xml tabtitle="OrderView.xaml" %}

<syncfusion:SfDataGrid SelectionMode="Extended" SelectionUnit="Row"
                       ItemsSource="{Binding Orders}" />

{% endhighlight %}
{% endtabs %}

### Blazor selection

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

### Selection comparison

| Feature | WPF | Blazor |
|---|---|---|
| **Selection mode** | `SelectionMode` (Single, Multiple, Extended) | [`GridSelectionSettings.Mode`](https://blazor.syncfusion.com/documentation/datagrid/selection/row-selection) (Single, Multiple) |
| **Selection unit** | `SelectionUnit` (Row, Cell, Any) | `GridSelectionSettings.Type` (Row, Cell) |
| **Get selected rows** | `SelectedItems` property | `GetSelectedRecordsAsync()` method |
| **Programmatic select** | `SelectedIndex`, `SelectedItem` | `SelectRowAsync()`, `SelectRowsAsync()` |
| **Clear selection** | `ClearSelections()` | `ClearSelectionAsync()` |
| **Checkbox selection** | `GridCheckBoxColumn` as first column | `GridSelectionSettings.CheckboxMode` |

## Paging and virtualization

### WPF paging (external `SfDataPager`)

{% tabs %}
{% highlight xml tabtitle="OrderView.xaml" %}

<syncfusion:SfDataPager x:Name="dataPager" PageSize="20"
                        Source="{Binding Orders}" />
<syncfusion:SfDataGrid ItemsSource="{Binding ElementName=dataPager, Path=PagedSource}" />

{% endhighlight %}
{% endtabs %}

### Blazor standard paging

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

### Blazor row and column virtualization

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

### Blazor infinite scrolling

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

### Paging / virtualization comparison

| Feature | WPF | Blazor |
|---|---|---|
| **Paging** | External `SfDataPager` control | Built-in [`AllowPaging`](https://blazor.syncfusion.com/documentation/datagrid/paging) + `GridPageSettings` |
| **Row virtualization** | `EnableDataVirtualization` | `EnableVirtualization` |
| **Column virtualization** | `EnableColumnVirtualization` | `EnableColumnVirtualization` |
| **Infinite scroll** | Manual implementation | `EnableInfiniteScrolling` |
| **Page size dropdown** | Not built-in | `GridPageSettings.PageSizes` |

## Events and commands

### WPF events and commands

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

### Blazor events via `GridEvents`

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

### Events comparison

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

## Styling and theming

### WPF theming

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

### Blazor theming

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

### Theming comparison

| Concept | WPF | Blazor |
|---|---|---|
| **Theme application** | `ResourceDictionary` in `App.xaml` | CSS `<link>` in `Components/App.razor` |
| **Cell style** | `GridColumn.CellStyle` (XAML Style) | `CustomAttributes` + CSS class |
| **Row style** | `RowStyle` / `AlternatingRowStyle` | `RowDataBound` + CSS class |
| **Dynamic styling** | XAML `DataTriggers` | `RowDataBound` + `AddClass()` |
| **Custom theme** | Override XAML brushes | Override [CSS custom properties](https://blazor.syncfusion.com/documentation/appearance/theme-studio) |
| **Dark mode** | Theme variant assembly | Dark theme CSS file variant |

## Performance optimization

### Blazor performance techniques

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

### Performance comparison

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

- [Syncfusion WPF DataGrid — Getting started](https://help.syncfusion.com/wpf/datagrid/getting-started)
- [Syncfusion Blazor DataGrid — Getting started (Server)](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-server-app)
- [Syncfusion Blazor DataGrid — API reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html)
- [ASP.NET Core Blazor hosting models](https://learn.microsoft.com/en-us/aspnet/core/blazor/hosting-models)
- [Syncfusion Blazor themes](https://blazor.syncfusion.com/documentation/appearance/themes)
- [Syncfusion Blazor DataGrid — Editing](https://blazor.syncfusion.com/documentation/datagrid/editing/inline-editing)
- [Syncfusion Blazor DataGrid — Filtering](https://blazor.syncfusion.com/documentation/datagrid/filtering/filter-bar)
- [Syncfusion Blazor DataGrid — Virtualization](https://blazor.syncfusion.com/documentation/datagrid/virtual-scrolling)