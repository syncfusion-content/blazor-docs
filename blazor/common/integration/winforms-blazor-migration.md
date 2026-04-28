---
layout: post
title: Migrating from WinForms to Blazor | Syncfusion®
description: Step-by-step guide to migrate Syncfusion® WinForms apps to Syncfusion® Blazor, with detailed DataGrid migration.
platform: Blazor
component: Common
documentation: ug
---

# Migrating from WinForms to Blazor

This guide provides a step‑by‑step approach to migrating a Windows Forms (WinForms) application to Syncfusion® Blazor. It is designed to help developers modernize existing desktop applications by moving to a web‑based architecture while continuing to use familiar .NET and C# skills.

It explains key architectural differences, project structure changes, and shows practical examples of converting common WinForms controls to their Syncfusion® Blazor equivalents, making the migration process easy to understand.

## Why Migrate from WinForms to Syncfusion® Blazor?

| Aspect | WinForms | Syncfusion® Blazor | Benefit of Migration |
|------|----------|------------------|----------------------|
| Platform Support | Windows only | Web, Desktop, Cloud, Cross‑platform | Application accessible from any browser or device |
| UI Technology | Legacy desktop UI | Modern web‑based UI | Improved look and user experience |
| Architecture | Form‑centric, tightly coupled | Component‑based, modular | Better maintainability and scalability |
| Accessibility | Requires local installation | Runs in a web browser | No client‑side installation required |
| Development Model | Event‑driven programming | Data binding and reactive UI | Cleaner and more readable code |
| UI Controls | Limited built‑in controls | 80+ Syncfusion® UI components | Rich enterprise‑ready UI features |
| Responsiveness | Fixed desktop layouts | Responsive web layouts | Works across different screen sizes |
| Maintenance | Hard to extend and update | Easy to maintain and enhance | Lower long‑term maintenance effort |
| Cloud Readiness | Minimal support | Designed for cloud deployment | Enables modern hosting scenarios |
| Code Reusability | Low reusability | High reusability via components and services | Faster development and testing |
| Future Support | Legacy technology | Actively developed framework | Long‑term application sustainability |

## Key Architectural Differences

Understanding the architectural differences between WinForms and Syncfusion® Blazor is essential before starting the migration. WinForms follows a traditional desktop‑based, event‑driven architecture, while Blazor uses a modern, component‑based web architecture designed for scalability and maintainability.

| Area | WinForms Architecture | Syncfusion® Blazor Architecture |
|-----|----------------------|--------------------------------|
| Application Type | Desktop application | Web application |
| UI Model | Form‑based controls | Component‑based UI |
| Platform Dependency | Windows only | Cross‑platform |
| Code Organization | UI and business logic often tightly coupled | Clear separation of UI, services, and models |
| Rendering Engine | OS‑based rendering (GDI+/Windows) | Browser‑based rendering (HTML/CSS) |
| State Management | Control state managed automatically | State‑driven UI with data binding |
| Event Handling | Traditional event handlers | Declarative event binding |
| Layout System | Fixed, pixel‑based layout | Responsive, CSS‑based layout |
| Navigation | Open and close forms | URL‑based routing |

## Project structure comparison

When migrating from WinForms to Blazor, one of the first changes you will notice is the project structure. WinForms applications are designed for desktop environments, whereas Blazor applications follow a component‑based web architecture. Understanding how files and responsibilities map between the two frameworks helps simplify the migration process.

| WinForms | Blazor | Description |
|---|---|---|
| `Program.cs` | `Program.cs` | Defines the application entry point and configures startup logic |
| `Form1.cs` | `Pages/*.razor` | Represents a UI page or view |
| `Form1.Designer.cs` | Defines the UI layout and component hierarchy |
| UserControl | Razor component | Reusable UI components |
| Event handlers | Component methods | Handles UI events, typically implemented as async methods |

## Creating a Blazor project

To migrate a WinForms application, you first need to create a Syncfusion® Blazor project. Blazor is a modern web framework that allows you to build interactive user interfaces using C# and .NET, instead of JavaScript.

You can create a new Blazor project using the .NET Command Line Interface (CLI). Run the following command in a terminal or command prompt:

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet new blazor -n WinFormsToBlazor

{% endhighlight %}
{% endtabs %}

## Package installation

This section explains how Syncfusion® packages are referenced in WinForms and Blazor applications, and highlights the key differences in how components, themes, and runtime dependencies are delivered in each framework.

### WinForms: Package installation

In WinForms applications, Syncfusion® controls are installed as platform‑specific NuGet packages. Typically, each control (or a group of related controls) is provided as a separate package.

These WinForms packages include the following:

- Native WinForms rendering logic
- Control‑specific assemblies
- Windows‑only dependencies

Because WinForms applications run only on Windows, the packages are tightly coupled with the Windows desktop environment.

**Example:**

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.WinForms.DataGrid

{% endhighlight %}
{% endtabs %}

### Syncfusion Blazor: Package installation

In Blazor applications, Syncfusion® components are delivered as web‑based UI components. Instead of native Windows rendering, these components use HTML, CSS, and JavaScript and integrate with C# through the Blazor framework.

Syncfusion® Blazor packages are grouped into the following categories

- Component packages (Grid, Charts, Scheduler, etc.)
- Theme packages (CSS‑based)
- Shared runtime JavaScript

To use Syncfusion® components in a Blazor application, install the base component package and the theme package.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

## Theme 

This section explains how themes are applied and managed in WinForms and Syncfusion® Blazor applications. It also highlights the key conceptual shift from desktop‑based theme managers to CSS‑based theming used in web applications.

### WinForms: Theme configuration

In WinForms applications, Syncfusion® themes are applied using theme managers or control properties. All styling logic is handled inside the desktop runtime and tightly integrated with the Windows rendering system.

Key characteristics of WinForms theming include

- Themes are applied at the form level or the application level
- UI rendering is handled by Windows graphics
- No external CSS or JavaScript files are required

**Example of applying a Syncfusion® theme in WinForms**

{% tabs %}
{% highlight c# tabtitle="Form1.cs" %}

using Syncfusion.WinForms.Controls;

SfSkinManager.SetVisualStyle(this, VisualStyles.FluentLight);

{% endhighlight %}
{% endtabs %}

### Syncfusion Blazor: Theme configuration

In Blazor applications, UI styling is separated from application logic and handled using web standards. Instead of theme managers, styles are applied through CSS files and supporting JavaScript.

Themes in Syncfusion® Blazor are applied by

- Referencing a Syncfusion® theme CSS file
- Loading the Syncfusion® Blazor JavaScript runtime

This approach follows standard web development practices and enables flexible styling across different devices and browsers.

To apply Syncfusion® styles and enable required features, reference the theme CSS file and scripts in the `App.razor` file located under the Components folder.

{% tabs %}
{% highlight html tabtitle="App.razor" %}

<head>
    <!-- Syncfusion theme stylesheet -->
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
</head>

<body>
    <!-- Syncfusion Blazor component's script reference -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>

{% endhighlight %}
{% endtabs %}

## Service registration

In Blazor applications, Syncfusion® components must be registered with the built‑in dependency injection system. This registration enables component rendering, state management, and required runtime behavior.

This step is required only for Blazor applications and replaces the implicit component initialization mechanism used in WinForms.

**Blazor requirement:**

To enable Syncfusion® Blazor components, register the Syncfusion® service in the `Program.cs` file.
This step makes the Syncfusion® components available throughout the application.

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}
....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....
{% endhighlight %}
{% endtabs %}

In Blazor, namespaces are commonly imported globally using the `_Imports.razor` file.

{% tabs %}
{% highlight razor tabtitle="_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

{% endhighlight %}
{% endtabs %}

## Component rendering

This section explains how user interface elements are rendered in WinForms and Syncfusion Blazor applications. It demonstrates the transition from control‑based rendering in desktop applications to state‑driven component rendering in Blazor.

### WinForms Component rendering

In WinForms, user interface elements are created as controls and rendered immediately when they are added to a form. The Windows runtime manages rendering through the message loop, and control state is maintained automatically.

{% tabs %}
{% highlight c# tabtitle="Form1.cs" %}

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
    public string CustomerID { get; set; }
    public double Freight { get; set; }
}

{% endhighlight %}
{% endtabs %}

### Syncfusion Blazor: Component rendering

In Blazor, the UI is rendered using Razor components. Components are declared declaratively in markup, and rendering is handled by the Blazor rendering engine.
Instead of rendering immediately, Blazor renders components based on state changes. Whenever the component state changes, the framework updates only the required parts of the UI.

Key characteristics of Blazor rendering include

- UI is declared using Razor markup
- Rendering is based on component state
- UI updates occur automatically when data changes

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/orders"

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

This section explains how multiple components are added and rendered in WinForms and Syncfusion® Blazor applications. 

### WinForms

In WinForms, multiple controls are added to a form programmatically. Each control is placed into the form’s control collection, and the rendering order depends on the sequence in which controls are added.

{% tabs %}
{% highlight c# tabtitle="Form1.cs" %}

this.Controls.Add(dataGrid);
this.Controls.Add(chart);

{% endhighlight %}
{% endtabs %}

### Syncfusion Blazor component

In Blazor, multiple components are rendered declaratively using Razor markup. Components are displayed in the order they appear in the markup and are arranged using standard web layout rules.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

<SfGrid DataSource="@Orders" />
<SfChart>
</SfChart>

{% endhighlight %}
{% endtabs %}

## WinForms to Blazor Component Mapping

This document provides a **comprehensive reference table** that maps **Syncfusion® WinForms controls** to their **Syncfusion® Blazor equivalents**.  
It is intended to help developers **plan, assess, and execute** WinForms → Blazor migrations efficiently.

### Data Management and Grids

| WinForms Control | Syncfusion Blazor Component | Notes |
|---|---|---|
| `SfDataGrid` | `SfGrid` | Supports sorting, filtering, grouping, paging, editing |
| `SfTreeGrid` | `SfTreeGrid` | Uses `IdMapping` and `ParentIdMapping` |
| `SfDataPager` | Built‑in Grid Paging | Paging via `GridPageSettings` |
| `SfVirtualGrid` | Grid Virtualization | Requires explicit grid height |

### Charts and Data Visualization

| WinForms Control | Syncfusion Blazor Component | Notes |
|---|---|---|
| `SfChart` | `SfChart` | Supports column, line, bar, pie, area charts |
| `SfSparkline` | `SfSparkline` | Lightweight inline charts |
| `SfGauge` | `SfLinearGauge`, `SfCircularGauge` | SVG‑based rendering |
| `SfMaps` | `SfMaps` | Interactive maps |

### Scheduling and Time Management

| WinForms Control | Syncfusion Blazor Component | Notes |
|---|---|---|
| `SfScheduler` | `SfSchedule<TValue>` | Uses custom POCO model |
| `ScheduleAppointment` | Custom Event Model | Mapping via `ScheduleEventSettings` |

### Navigation and Layout Controls

| WinForms Control | Syncfusion Blazor Component | Notes |
|---|---|---|
| `SfTabControl` | `SfTab` | Tab navigation via Razor |
| `SfAccordion` | `SfAccordion` | Expand/collapse panels |
| `SfDockingManager` | CSS Layout + Components | Requires layout redesign |
| `SfSplitContainer` | `SfSplitter` | Horizontal/vertical splitting |

### Editors and Input Controls

| WinForms Control | Syncfusion Blazor Component | Notes |
|---|---|---|
| `SfTextBoxExt` | `SfTextBox` | Two‑way binding via `@bind-Value` |
| `SfMaskedEdit` | `SfMaskedTextBox` | Web input masking |
| `SfNumericTextBox` | `SfNumericTextBox` | Numeric input |
| `SfDateTimeEdit` | `SfDateTimePicker` | Calendar UI |
| `SfComboBox` | `SfComboBox<T>` | Virtualized dropdown |
| `SfDropDownList` | `SfDropDownList<T>` | Selection lists |
| `SfAutoComplete` | `SfAutoComplete<T>` | Input suggestions |

### Buttons and Commands

| WinForms Control | Syncfusion Blazor Component | Notes |
|---|---|---|
| `SfButton` | `SfButton` | Uses `OnClick` callback |
| `SfSplitButton` | `SfSplitButton` | Dropdown actions |
| `SfToggleButton` | Custom Toggle Logic | State‑based handling |

### Dialogs and Notifications

| WinForms Control | Syncfusion Blazor Component | Notes |
|---|---|---|
| `SfDialog` | `SfDialog` | Async open/close |
| `SfMessageBox` | `SfDialog` | Replaces modal dialogs |
| `SfProgressBar` | `SfProgressBar` | CSS animation |
| `SfToast` | `SfToast` | Notifications |

## File, Document, and Spreadsheet Controls

| WinForms Control | Syncfusion Blazor Component | Notes |
|---|---|---|
| `SfRichTextBoxAdv` | `SfRichTextEditor` | HTML‑based editor (not DOCX‑native) |
| `PdfViewerControl` | `SfPdfViewer` | Browser‑based PDF viewer |
| `SpreadsheetControl` | `SfSpreadsheet` | Excel‑like UI |
| `DocumentEditor` | `SfDocumentEditor` | Word‑style editor |

N > `SfRichTextBoxAdv` uses a DOCX object model, while Blazor `SfRichTextEditor` uses HTML. Server‑side document conversion may be required for complex documents.

### Diagram and Visual Modeling

| WinForms Control | Syncfusion Blazor Component | Notes |
|---|---|---|
| `SfDiagram` | `SfDiagramComponent` | Nodes and connectors defined in code |
| `NodeViewModel` | `Node` | Programmatic configuration |
| `ConnectorViewModel` | `Connector` | Async APIs supported |

### Lists and Tree Controls

| WinForms Control | Syncfusion Blazor Component | Notes |
|---|---|---|
| `SfTreeView` | `SfTreeView` | Hierarchical navigation |
| `SfListView` | `SfListView<T>` | Virtualized lists |
| `SfMenu` | `SfMenu` | Hierarchical menu |
| `SfToolbar` | `SfToolbar` | Action toolbar |

## See also

- [Getting started with Syncfusion® Blazor DataGrid in Web App](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-web-app)
