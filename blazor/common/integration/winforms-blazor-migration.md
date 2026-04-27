---
layout: post
title: Migrating from WinForms to Blazor | Syncfusion
description: Step-by-step guide to migrate Syncfusion WinForms apps to Syncfusion Blazor, with detailed DataGrid migration.
platform: Blazor
component: Common
documentation: ug
---

# Migrating from WinForms to Blazor

This guide provides a simple, step‑by‑step approach to migrating a Windows Forms (WinForms) application to Syncfusion Blazor, helping developers modernize legacy desktop applications using familiar .NET and C# skills. It explains key architectural differences, project structure changes, and shows practical examples of converting common WinForms controls to their Syncfusion Blazor equivalents, making the migration process easy to understand.

## Why Migrate from WinForms to Syncfusion Blazor?

| Aspect | WinForms | Syncfusion Blazor | Benefit of Migration |
|------|----------|------------------|----------------------|
| Platform Support | Windows only | Web, Desktop, Cloud, Cross‑platform | Application accessible from any browser or device |
| UI Technology | Legacy desktop UI | Modern web‑based UI | Improved look and user experience |
| Architecture | Form‑centric, tightly coupled | Component‑based, modular | Better maintainability and scalability |
| Accessibility | Requires local installation | Runs in a web browser | No client‑side installation required |
| Development Model | Event‑driven programming | Data binding and reactive UI | Cleaner and more readable code |
| UI Controls | Limited built‑in controls | 80+ Syncfusion UI components | Rich enterprise‑ready UI features |
| Responsiveness | Fixed desktop layouts | Responsive web layouts | Works across different screen sizes |
| Maintenance | Hard to extend and update | Easy to maintain and enhance | Lower long‑term maintenance effort |
| Cloud Readiness | Minimal support | Designed for cloud deployment | Enables modern hosting scenarios |
| Code Reusability | Low reusability | High reusability via components and services | Faster development and testing |
| Future Support | Legacy technology | Actively developed framework | Long‑term application sustainability |

## Key Architectural Differences

Understanding the architectural differences between WinForms and Syncfusion Blazor is essential before starting the migration. WinForms follows a traditional desktop‑based, event‑driven architecture, while Blazor uses a modern, component‑based web architecture designed for scalability and maintainability.

| Area | WinForms Architecture | Syncfusion Blazor Architecture |
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

| WinForms | Blazor | Notes |
|---|---|---|
| `Program.cs` | `Program.cs` | App startup |
| `Form1.cs` | `Pages/*.razor` | UI page |
| `Form1.Designer.cs` | Razor markup | Component tree |
| UserControl | Razor component | Reusable UI |
| Event handlers | Component methods | Often async |
| App.config | `appsettings.json` | Configuration |
| Resources.resx | `wwwroot` | Static assets |


## Creating a project

### WinForms project creation

WinForms projects are created as desktop applications.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet new winforms -n WinFormsApp

{% endhighlight %}
{% endtabs %}

- Application launches a native window
- UI lifecycle managed by Windows

### Syncfusion Blazor project creation

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet new blazor -n WinFormsToBlazor --interactivity Server

{% endhighlight %}
{% endtabs %}

- UI rendered in browser
- Component lifecycle managed by Blazor

## Package installation

This step explains how Syncfusion packages are referenced in WinForms and Blazor, and highlights the key differences in how components and themes are delivered.

### WinForms: Package installatio
In WinForms applications, Syncfusion controls are installed as platform‑specific NuGet packages, typically one package per control (or control group). These packages contain:

Native WinForms rendering logic
Control‑specific assemblies
Windows‑only dependencies

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.WinForms.DataGrid

{% endhighlight %}
{% endtabs %}

### Syncfusion Blazor: Package installation

In Blazor, Syncfusion components are delivered as web‑based UI components, split into:

Component packages (Grid, Charts, Scheduler, etc.)
Theme packages (CSS‑based)
Shared runtime JavaScript

Unlike WinForms, all UI rendering happens through HTML, CSS, and JavaScript in the browser.

Required base packages (Blazor)
Install these packages once for the application:

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

## Theme 

This step explains how themes are applied and managed in WinForms and Syncfusion Blazor, and highlights the major conceptual shift from desktop theme managers to CSS‑based theming

### WinForms: Theme configuration

In WinForms applications, Syncfusion themes are applied using control properties or theme managers, and styling is handled entirely within the desktop runtime.

Themes are applied at Form or Application level
Rendering is done via Windows graphics
No external CSS or scripts are required

Example: Applying a Syncfusion theme in WinForms

{% tabs %}
{% highlight c# tabtitle="Form1.cs" %}

using Syncfusion.WinForms.Controls;

SfSkinManager.SetVisualStyle(this, VisualStyles.FluentLight);

{% endhighlight %}
{% endtabs %}

### Syncfusion Blazor: Theme configuration

Unlike WinForms, UI styling is separated from logic and handled using web standards.
Themes are applied by:

Referencing a theme CSS file
Loading the Syncfusion Blazor JavaScript runtime

{% tabs %}
{% highlight html tabtitle="App.razor" %}

<link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

## Service registration

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

## Component rendering

This step demonstrates how UI components are rendered in WinForms and Syncfusion Blazor, and explains the shift from control‑based rendering to component‑based rendering.
Component rendering is the point where WinForms developers most clearly see the architectural difference between desktop and Blazor applications.

### WinForms: Component rendering
In WinForms, UI components are created as controls and rendered immediately when they are added to a Form.
Rendering is managed by the Windows message loop, and control state is maintained automatically.

{% tabs %}
{% highlight c# tabtitle="Form1.cs" %}

public partial class MainForm : Form
{
    public MainForm()
    {
        InitializeComponent();

        SfDataGrid dataGrid = new SfDataGrid();
        dataGrid.Dock = DockStyle.Fill;
        dataGrid.DataSource = GetOrders();

        this.Controls.Add(dataGrid);
    }
}

{% endhighlight %}
{% endtabs %}

### Syncfusion Blazor: Component rendering

In Blazor, UI is rendered using Razor components.
Components are declared declaratively in markup, and rendering is handled by the Blazor rendering engine.
Components are re‑rendered whenever their state changes.

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

### WinForms

{% tabs %}
{% highlight c# tabtitle="Form1.cs" %}

this.Controls.Add(dataGrid);
this.Controls.Add(chart);
``
{% endhighlight %}
{% endtabs %}

Controls are layered based on their z‑order and container layout.

### Syncfusion Blazor

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

<SfGrid DataSource="@Orders" />
<SfChart>
</SfChart>
``

{% endhighlight %}
{% endtabs %}

Components are rendered top‑to‑bottom following Razor markup and CSS rules.

## WinForms to Blazor Component Mapping

This document provides a **comprehensive reference table** that maps **Syncfusion WinForms controls** to their **Syncfusion Blazor equivalents**.  
It is intended to help developers **plan, assess, and execute** WinForms → Blazor migrations efficiently.

### Data Management and Grids

| Syncfusion WinForms Control | Syncfusion Blazor Component | Migration Notes |
|---|---|---|
| `SfDataGrid` | `SfGrid` | Supports sorting, filtering, grouping, paging, editing |
| `SfTreeGrid` | `SfTreeGrid` | Uses `IdMapping` and `ParentIdMapping` |
| `SfDataPager` | Built‑in Grid Paging | Paging via `GridPageSettings` |
| `SfVirtualGrid` | Grid Virtualization | Requires explicit grid height |

---

### Charts and Data Visualization

| Syncfusion WinForms Control | Syncfusion Blazor Component | Migration Notes |
|---|---|---|
| `SfChart` | `SfChart` | Supports column, line, bar, pie, area charts |
| `SfSparkline` | `SfSparkline` | Lightweight inline charts |
| `SfGauge` | `SfLinearGauge`, `SfCircularGauge` | SVG‑based rendering |
| `SfMaps` | `SfMaps` | Interactive maps |

---

### Scheduling and Time Management

| Syncfusion WinForms Control | Syncfusion Blazor Component | Migration Notes |
|---|---|---|
| `SfScheduler` | `SfSchedule<TValue>` | Uses custom POCO model |
| `ScheduleAppointment` | Custom Event Model | Mapping via `ScheduleEventSettings` |

---

### Navigation and Layout Controls

| Syncfusion WinForms Control | Syncfusion Blazor Component | Migration Notes |
|---|---|---|
| `SfTabControl` | `SfTab` | Tab navigation via Razor |
| `SfAccordion` | `SfAccordion` | Expand/collapse panels |
| `SfDockingManager` | CSS Layout + Components | Requires layout redesign |
| `SfSplitContainer` | `SfSplitter` | Horizontal/vertical splitting |

---

### Editors and Input Controls

| Syncfusion WinForms Control | Syncfusion Blazor Component | Migration Notes |
|---|---|---|
| `SfTextBoxExt` | `SfTextBox` | Two‑way binding via `@bind-Value` |
| `SfMaskedEdit` | `SfMaskedTextBox` | Web input masking |
| `SfNumericTextBox` | `SfNumericTextBox` | Numeric input |
| `SfDateTimeEdit` | `SfDateTimePicker` | Calendar UI |
| `SfComboBox` | `SfComboBox<T>` | Virtualized dropdown |
| `SfDropDownList` | `SfDropDownList<T>` | Selection lists |
| `SfAutoComplete` | `SfAutoComplete<T>` | Input suggestions |

---

### Buttons and Commands

| Syncfusion WinForms Control | Syncfusion Blazor Component | Migration Notes |
|---|---|---|
| `SfButton` | `SfButton` | Uses `OnClick` callback |
| `SfSplitButton` | `SfSplitButton` | Dropdown actions |
| `SfToggleButton` | Custom Toggle Logic | State‑based handling |

---

### Dialogs and Notifications

| Syncfusion WinForms Control | Syncfusion Blazor Component | Migration Notes |
|---|---|---|
| `SfDialog` | `SfDialog` | Async open/close |
| `SfMessageBox` | `SfDialog` | Replaces modal dialogs |
| `SfProgressBar` | `SfProgressBar` | CSS animation |
| `SfToast` | `SfToast` | Notifications |

---

## File, Document, and Spreadsheet Controls

| Syncfusion WinForms Control | Syncfusion Blazor Component | Migration Notes |
|---|---|---|
| `SfRichTextBoxAdv` | `SfRichTextEditor` | HTML‑based editor (not DOCX‑native) |
| `PdfViewerControl` | `SfPdfViewer` | Browser‑based PDF viewer |
| `SpreadsheetControl` | `SfSpreadsheet` | Excel‑like UI |
| `DocumentEditor` | `SfDocumentEditor` | Word‑style editor |

N > `SfRichTextBoxAdv` uses a DOCX object model, while Blazor `SfRichTextEditor` uses HTML. Server‑side document conversion may be required for complex documents.

### Diagram and Visual Modeling

| Syncfusion WinForms Control | Syncfusion Blazor Component | Migration Notes |
|---|---|---|
| `SfDiagram` | `SfDiagramComponent` | Nodes and connectors defined in code |
| `NodeViewModel` | `Node` | Programmatic configuration |
| `ConnectorViewModel` | `Connector` | Async APIs supported |

### Lists and Tree Controls

| Syncfusion WinForms Control | Syncfusion Blazor Component | Migration Notes |
|---|---|---|
| `SfTreeView` | `SfTreeView` | Hierarchical navigation |
| `SfListView` | `SfListView<T>` | Virtualized lists |
| `SfMenu` | `SfMenu` | Hierarchical menu |
| `SfToolbar` | `SfToolbar` | Action toolbar |

## See also

- Syncfusion Blazor Demos  
- Syncfusion Blazor Component Documentation  
- WinForms to Blazor Migration Guide  