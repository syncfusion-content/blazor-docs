---
layout: post
title: Migrating from ASP.NET Web Forms to Blazor | Syncfusion
description: Guide to migrating Syncfusion ASP.NET Web Forms applications to Blazor, covering key components and detailed DataGrid migration.
platform: Blazor
control: Common
documentation: ug
---

# Migrating from ASP.NET Web Forms to Blazor

Migrating enterprise applications from **ASP.NET Web Forms** to **Blazor** is a major architectural transition from a page centric, post-back-based framework to a modern, component-driven web framework built on .NET. This guide provides a **structured, step-by-step migration path** for [Syncfusion Web Forms components](https://help.syncfusion.com/aspnet/overview) to their [Syncfusion Blazor equivalents](https://blazor.syncfusion.com/documentation/introduction).

This document covers:

* Architectural differences between Web Forms and Blazor
* Development environment and project structure mapping
* Step‑by‑step migration of Syncfusion components

## Why migrate from Web Forms to Blazor?

ASP.NET Web Forms relies heavily on **ViewState, server postback**, and a tightly coupled page lifecycle. While this model simplified early web development, it becomes increasingly difficult to scale, test, and maintain in modern applications.

Blazor replaces postback with **event-driven UI updates**, supports **reusable components**, and aligns with modern .NET development practices, making it the recommended migration path for long‑term investment.

| Dimension             | Web Forms       | Blazor                              |
| --------------------- | ---------------------- | ----------------------------------- |
| Runtime           | IIS + ASP.NET          | .NET (Server or WebAssembly)        |
| Deployment       | IIS-hosted web app     | Cloud, container, or static hosting |
| UI technology     | ASPX + Server controls | Razor components (HTML + C#)        |
| State management  | ViewState              | Component state                     |
| Interaction model | Postback / callbacks  | Event‑driven rendering              |
| Modern tooling    | Visual Studio          | Visual Studio / VS Code             |
| Scalability      | Server‑bound           | Web‑scale                           |
| Updates           | Requires app pool recycle   | Instant (Server) or cached (WASM)   |

## Key architectural differences

| Concept                  | Web Forms               | Blazor                      |
| ------------------------ | ---------------------- | --------------------------- |
| UI definition       | `.aspx`                | `.razor`                    |
| Code‑behind          | `.aspx.cs`             | `@code {}` / `.razor.cs`    |
| Lifecycle            | `Page_Load`, postback | Component lifecycle methods |
| State                | ViewState              | In‑memory component state   |
| Events               | Server callbacks       | EventCallback               |
| Dependency injection | Limited                | Built‑in DI                 |
| Navigation           | Page navigation        | Routing with `@page`        |

## Development environment setup

### Prerequisites for Blazor

* [.NET 8 SDK or later](https://dotnet.microsoft.com/en-us/download/dotnet)
* [Visual Studio](https://visualstudio.microsoft.com/downloads/) 2022 or later or [Visual Studio Code](https://code.visualstudio.com/) with [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension

Verify installation using the following .NET CLI command.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet --version
dotnet --info

{% endhighlight %}
{% endtabs %}

## Project structure comparison

 | Concept | Web Forms Artifact  | Blazor Equivalent           |
 | -----------------| ------------------ | ------------------------ |
 | UI Definition| `Default.aspx`     | `Components/Pages/Home.razor`            |
 | Code-behind| `Default.aspx.cs`  | Code block / `.razor.cs`    |
 | App startup | `Global.asax`      | `Program.cs`                  |
 | Configuration | `web.config`       | `appsettings.json`            |
 | Reusable UI | `UserControl.ascx` | Razor component               |
 | State storage | ViewState          | Component fields         |

## Creating a Blazor project

For Web Forms migrations, create a **Blazor** project, which runs server-side and preserves the familiar server-hosted execution model:

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet new blazor -n MyBlazorApp

{% endhighlight %}
{% endtabs %}

## Migrating Syncfusion Components from Web Forms to Blazor

This section provides **step‑by‑step migration guidance** for the following Syncfusion components:

*   **DataGrid**
*   **Scheduler**
*   **Rich Text Editor**

Each component includes package installation, configuration, and side‑by‑side comparisons.

### DataGrid

#### Migration overview

In Web Forms, most [DataGrid](https://help.syncfusion.com/aspnet/grid/overview) features such as paging, sorting, filtering, and grouping are executed on the server and rely on ViewState to preserve UI state across postbacks.

In [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid), the same features are implemented through component configuration and executed at runtime within the grid itself. This removes the dependency on postbacks and reduces payload size. The grid provides significantly better responsiveness while still supporting remote data operations through `SfDataManager` when required.

| Aspect / Feature       | Web Forms (`ej:Grid`)              | Blazor (`SfGrid<T>`)                   |
| ---------------------- | ---------------------------------- | -------------------------------------- |
| Package           | `Syncfusion.EJ.Web`                | `Syncfusion.Blazor.Grid`               |
| UI model           | Server control                     | Razor component                        |
| Rendering          | Server‑side                        | Client‑side / runtime                  |
| State handling     | ViewState                          | Component state                        |
| Event model        | Server callbacks                   | `EventCallback` (async)                |
| Data binding       | `DataSource` / `DataManager`       | `DataSource` / `SfDataManager`         |
| Paging             | `AllowPaging`, `PageSettings`      | `AllowPaging`, `GridPageSettings`      |
| Sorting            | `AllowSorting`, `SortSettings`     | `AllowSorting`, `GridSortSettings`     |
| Filtering          | `AllowFiltering`, FilterBar / Menu | `AllowFiltering`, `GridFilterSettings` |
| Grouping           | `AllowGrouping`, server‑processed  | `AllowGrouping`, Runtime (Server or WebAssembly)        |

#### Step‑by‑Step migration

**Step 1: Package installation**

In Web Forms, Syncfusion controls are installed as server‑side assemblies, which are compiled into the web application and rendered through ASP.NET server controls. These packages are referenced once and shared across all pages.

In Blazor, Syncfusion components are delivered as NuGet packages containing Razor components, static assets, and JavaScript interop, which must be restored as part of the .NET build.

**Web Forms**

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.EJ.Web

{% endhighlight %}
{% endtabs %}

**Blazor**

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Grid
dotnet add package Syncfusion.Blazor.Themes

{% endhighlight %}
{% endtabs %}

**Step 2: Service registration (Blazor‑specific)**

ASP.NET Web Forms initializes controls implicitly as part of the page lifecycle. There is no explicit service registration model.

Blazor uses dependency injection (DI), and Syncfusion components must be registered so the framework can resolve rendering, localization, and JavaScript interop services.

{% tabs %}
{% highlight cs tabtitle="Program.cs" %}

....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....

{% endhighlight %}
{% endtabs %}

**Step 3: Add import namespaces**

After the packages are installed, open the **/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Grids` namespaces.

{% tabs %}
{% highlight razor tabtitle="_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

{% endhighlight %}
{% endtabs %}

**Step 4: Theme / script configuration**

In Web Forms, Syncfusion scripts and styles are manually referenced in `.aspx pages` or `master pages`. The developer controls script order and dependency loading explicitly.

In Blazor, scripts and styles are served as static web assets and referenced once at the application level. Include the stylesheet and script references in the `App.razor` file.

**Web Forms**

{% tabs %}
{% highlight html tabtitle=".aspx" %}

<link href="Content/ej/web/default-theme/ej.web.all.min.css" rel="stylesheet" />
<script src='<%= Page.ResolveClientUrl("~/Scripts/jquery-3.3.1.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveClientUrl("~/Scripts/jsrender.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveClientUrl("~/Scripts/ej/ej.web.all.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveClientUrl("~/Scripts/ej/ej.webform.min.js")%>' type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

**Blazor**

{% tabs %}
{% highlight html tabtitle="App.razor" %}

<link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

**Step 5: Component rendering**

In Web Forms, the grid is a server control, while in Blazor it is a Razor component bound to in‑memory data.

**Web Forms**

{% tabs %}
{% highlight razor tabtitle="Default.aspx" %}

<ej:Grid runat="server" ID="Grid">                        
    <Columns>
        <ej:Column Field="FirstName" HeaderText="First Name"></ej:Column>
        <ej:Column Field="LastName" HeaderText="Last Name"></ej:Column>
        <ej:Column Field="Email" HeaderText="Email"></ej:Column>
    </Columns>          
</ej:Grid>

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight cs tabtitle="Default.aspx.cs" %}

namespace WebFormsGrid
{
    public partial class _Default : Page
    { 

        protected void Page_Load(object sender, EventArgs e)
        {
            List<Person> Persons = new List<Person>();

            Persons.Add(new Person() { FirstName = "John", LastName = "Beckett", Email = "john@syncfusion.com" });

            Persons.Add(new Person() { FirstName = "Ben", LastName = "Beckett", Email = "ben@syncfusion.com" });

            Persons.Add(new Person() { FirstName = "Andrew", LastName = "Beckett", Email = "andrew@syncfusion.com" });

            this.Grid.DataSource = Persons;

        }
    }
    public class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

**Blazor**

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page '/'

<SfGrid TValue="Order" DataSource="@Orders">
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" />
        <GridColumn Field="@nameof(Order.Customer)" HeaderText="Customer" />
    </GridColumns>
</SfGrid>

@code {
    List<Order> Orders = new()
    {
        new Order { OrderID = 1, Customer = "ALFKI" },
        new Order { OrderID = 2, Customer = "VINET" },
        new Order { OrderID = 3, Customer = "TOMSP" },
        new Order { OrderID = 4, Customer = "ANATR" },
        new Order { OrderID = 5, Customer = "ANTON" },
        new Order { OrderID = 6, Customer = "VICTE" },
        new Order { OrderID = 7, Customer = "FRANK" },
        new Order { OrderID = 8, Customer = "FRED" }
    };

    class Order
    {
        public int OrderID { get; set; }
        public string Customer { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

Web Forms grids depend on postback and ViewState to persist UI state.
Blazor grids rely on:

* Component parameters (DataSource)
* In‑memory state
* Automatic re‑rendering when data changes

This approach eliminates page refreshes and reduces payload size.

### Scheduler

#### Migration overview

In Web Forms, the [Scheduler](https://help.syncfusion.com/aspnet/schedule/overview) control relies on server‑side rendering, callbacks, and page lifecycle events to manage views, navigation, and appointment data. Appointment state is preserved across postback and refreshed whenever the view or date range changes.

In Blazor, the [Scheduler](https://www.syncfusion.com/blazor-components/blazor-scheduler) is implemented as a Razor component that renders and updates at runtime. Views, navigation, and appointment changes are handled through component configuration and event callbacks, eliminating postback while still supporting remote data sources through standard APIs.

| Aspect / Feature   | Web Forms (`ej:Schedule`)     | Blazor (`SfSchedule<TValue>`)      |
| ------------------ | ----------------------------- | ---------------------------------- |
| Package       | `Syncfusion.EJ.Web`           | `Syncfusion.Blazor.Schedule`       |
| UI model       | Server control                | Razor component                    |
| Rendering      | Server‑side                   | Runtime (Server or WebAssembly)            |
| State handling | ViewState                     | Component state                    |
| Event model    | Server callbacks              | `EventCallback` (async)            |
| Data binding   | `DataSource` / server objects | `ScheduleEventSettings.DataSource` |
| Views         | Single `CurrentView` property | `ScheduleViews` collection         |
| Navigation     | Server refresh                | Client‑side navigation             |
| Editing        | Server dialogs / callbacks    | Client dialogs / async callbacks   |
| Performance    | Server‑dependent              | Optimized runtime rendering        |

#### Step‑by‑Step migration

**Step 1: Package installation**

In Web Forms, the Scheduler is included as part of the Syncfusion Web Forms control set and loaded as a server‑side assembly. The control is rendered and managed through IIS and ASP.NET runtime services.

In Blazor, the Scheduler is delivered as a NuGet package that provides Razor components, styles, and client‑side logic required for rendering and interaction.

**Web Forms**

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.EJ.Web

{% endhighlight %}
{% endtabs %}

**Blazor**

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Schedule
dotnet add package Syncfusion.Blazor.Themes

{% endhighlight %}
{% endtabs %}

After migration, the Scheduler becomes part of the Blazor application build process and no longer depends on IIS‑specific control loading.

**Step 2: Service registration (Blazor‑specific)**

ASP.NET Web Forms initializes Scheduler functionality automatically during page execution. There is no explicit service registration or dependency injection configuration.

Blazor uses dependency injection to initialize Syncfusion services required for Scheduler rendering, localization, and JavaScript interop.

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}

...
using Syncfusion.Blazor;
...
builder.Services.AddSyncfusionBlazor();
...

{% endhighlight %}
{% endtabs %}

Without this registration, the Scheduler component cannot function correctly in a Blazor application.

**Step 3: Add import namespaces**

In Web Forms, namespaces are inferred from server control registration in the page or `web.config`. In Blazor, required namespaces are added to the **/_Imports.razor** file.

{% tabs %}
{% highlight razor tabtitle="_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Schedule

{% endhighlight %}
{% endtabs %}

This ensures Scheduler components and related types are available across Razor files.

**Step 4: Theme / script configuration**

In Web Forms, Scheduler styles and scripts are referenced explicitly in `.aspx` or master pages, and the correct order of script loading must be maintained to avoid runtime issues.

In Blazor, Scheduler styles are referenced once at the application level, and JavaScript interop dependencies are resolved automatically by the framework.

**Web Forms**

{% tabs %}
{% highlight html tabtitle=".aspx" %}

<link href="Content/ej/web/default-theme/ej.web.all.min.css" rel="stylesheet" />
<script src='<%= Page.ResolveClientUrl("~/Scripts/jquery-3.3.1.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveClientUrl("~/Scripts/jsrender.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveClientUrl("~/Scripts/ej/ej.web.all.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveClientUrl("~/Scripts/ej/ej.webform.min.js")%>' type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

**Blazor**

{% tabs %}
{% highlight html tabtitle="App.razor" %}

<link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"
type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

This change removes per‑page script management and ensures consistent Scheduler behavior throughout the application.

**Step 5: Component rendering**

In Web Forms, the Scheduler is defined as a server control and configured using properties such as `CurrentView` and server‑side appointment objects. Data is refreshed during postbacks when navigating dates or views.

**Web Forms**

{% tabs %}
{% highlight html tabtitle="Default.aspx" %}

<ej:Schedule ID="Schedule1" runat="server" CurrentView="Week">
</ej:Schedule>

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight cs tabtitle="Default.aspx.cs" %}

protected void Page_Load(object sender, EventArgs e)
{
    Schedule1.DataSource = new List<Appointment>
    {
        new Appointment
        {
            Subject = "Meeting",
            StartTime = DateTime.Now,
            EndTime = DateTime.Now.AddHours(1)
        }
    };
}

{% endhighlight %}
{% endtabs %}

**Blazor**

{% tabs %}
{% highlight razor tabtitle="Schedule.razor" %}

@page '/schedule'

<SfSchedule TValue="Meeting" Height="650px">
    <ScheduleViews>
        <ScheduleView Option="View.Day" />
        <ScheduleView Option="View.Week" />
        <ScheduleView Option="View.Month" />
    </ScheduleViews>

    <ScheduleEventSettings DataSource="@Meetings" />

</SfSchedule>

@code {
    List<Meeting> Meetings = new()
    {
        new Meeting
        {
            Id = 1,
            Subject = "Meeting",
            StartTime = DateTime.Now,
            EndTime = DateTime.Now.AddHours(1)
        }
    };

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

N> The event class (`Meeting`in this example) property names match the Scheduler's default field mappings. Alternatively, add an explicit `Fields` configuration in `ScheduleEventSettings` to map custom property names.

Web Forms Scheduler depends on postbacks and server callbacks to update views and appointments. 

Blazor Scheduler relies on component parameters, in‑memory data, and automatic re‑rendering, providing smoother navigation and improved scalability.

### Rich Text Editor

#### Migration overview

In Web Forms, the [Rich Text Editor](https://help.syncfusion.com/aspnet/richtexteditor/overview) is rendered as a server control and relies on server callbacks and postbacks to load, edit, and persist content. The editor content is typically processed on the server, and UI state is restored on every page lifecycle execution.

In Blazor, the [Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-rich-text-editor) is implemented as a Razor component that operates at runtime. Content is maintained in component state using an HTML string, and user interactions are handled through client‑side rendering and event callbacks, eliminating the need for postbacks.

| Aspect / Feature     | Web Forms (`ej:RTE`)      | Blazor (`SfRichTextEditor`)        |
| -------------------- | ------------------------- | ---------------------------------- |
| Package         | `Syncfusion.EJ.Web`       | `Syncfusion.Blazor.RichTextEditor` |
| UI model         | Server control            | Razor component                    |
| Rendering        | Server‑side               |  Runtime (Server or WebAssembly)            |
| State handling   | ViewState                 | Component state                    |
| Event model      | Server callbacks          | `EventCallback` (async)            |
| Content model    | ViewState / server callbacks    | HTML value binding                 |
| Editing workflow | Postback / callbacks     | Runtime rendering                  |
| Customization    | Code‑behind configuration | Component parameters               |
| Performance      | Server‑dependent          | Lightweight client updates         |

#### Step‑by‑Step migration

**Step 1: Package installation**

In Web Forms, the Rich Text Editor is included as part of the Syncfusion Web Forms control suite and loaded as a server‑side assembly. The editor is initialized and rendered by the ASP.NET runtime during page execution.

In Blazor, the Rich Text Editor is provided as a NuGet package that supplies Razor components, styles, and client‑side logic required for editing and formatting operations.

**Web Forms**

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.EJ.Web

{% endhighlight %}
{% endtabs %}

**Blazor**

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.RichTextEditor
dotnet add package Syncfusion.Blazor.Themes

{% endhighlight %}
{% endtabs %}

After migration, the editor becomes part of the Blazor application build process and no longer relies on IIS‑specific server control execution.

**Step 2: Service registration (Blazor‑specific)**

ASP.NET Web Forms initializes the Rich Text Editor implicitly as part of the page lifecycle. There is no explicit service registration mechanism.

Blazor requires registering Syncfusion services so the editor can resolve runtime services such as rendering and JavaScript interop.

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}

...
using Syncfusion.Blazor;
...
builder.Services.AddSyncfusionBlazor();
...

{% endhighlight %}
{% endtabs %}

This step is mandatory for all Syncfusion Blazor components, including the Rich Text Editor.

**Step 3: Add import namespaces**

In Web Forms, namespaces are resolved automatically through the server control configuration. In Blazor, required namespaces are added to the **/_Imports.razor** file.

{% tabs %}
{% highlight razor tabtitle="_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.RichTextEditor

{% endhighlight %}
{% endtabs %}

This ensures Rich Text Editor components and related APIs are available across Razor files.

**Step 4: Theme / script configuration**

In Web Forms, Rich Text Editor styles and scripts are manually referenced in `.aspx` or master pages, and correct script ordering is required for toolbar and formatting features to function correctly.

In Blazor, the required styles and scripts are referenced once at the application level, and JavaScript interop dependencies are resolved automatically.

**Web Forms**

{% tabs %}
{% highlight html tabtitle=".aspx" %}

<link href="Content/ej/web/default-theme/ej.web.all.min.css" rel="stylesheet" />
<script src='<%= Page.ResolveClientUrl("~/Scripts/jquery-3.3.1.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveClientUrl("~/Scripts/jsrender.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveClientUrl("~/Scripts/ej/ej.web.all.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveClientUrl("~/Scripts/ej/ej.webform.min.js")%>' type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

**Blazor**

{% tabs %}
{% highlight html tabtitle="App.razor" %}

<link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

This change removes repetitive script references and ensures consistent Rich Text Editor behavior across all pages.

**Step 5: Component rendering**

In Web Forms, the Rich Text Editor is declared as a server control and content is typically processed on the server during postback. Any change to the content triggers a round trip to persist or restore state.

**Web Forms**

{% tabs %}
{% highlight html tabtitle="Default.aspx" %}

<ej:RTE ID="Editor" runat="server">
</ej:RTE>

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight cs tabtitle="Default.aspx.cs" %}

protected void Page_Load(object sender, EventArgs e)
{
    Editor.Value = "<p>Welcome to Syncfusion Rich Text Editor</p>";
}

{% endhighlight %}
{% endtabs %}

**Blazor**

{% tabs %}
{% highlight razor tabtitle="Editor.razor" %}

@page '/rte'

<SfRichTextEditor @bind-Value="Content" Height="400px"></SfRichTextEditor>

@code {
    private string Content = "<p>Welcome to Syncfusion Rich Text Editor</p>";
}

{% endhighlight %}
{% endtabs %}

Web Forms Rich Text Editors depend on postback and ViewState to persist content.  

Blazor Rich Text Editors rely on component parameters, in‑memory state, and automatic UI re‑rendering, providing smoother editing and improved performance.

## See also

* [Blazor Server – Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)
* [DataGrid – Getting Started](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-server-app)
* [Scheduler – Getting Started](https://blazor.syncfusion.com/documentation/scheduler/getting-started-with-server-app)
* [Rich Text Editor – Getting Started](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started-with-server-app)


