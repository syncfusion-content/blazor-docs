---
layout: post
title: Migrating Syncfusion ASP.NET Web Forms to Blazor | Syncfusion
description: Learn how to migrate Syncfusion ASP.NET Web Forms controls to Blazor components, including key concepts and a detailed migration approach.
platform: Blazor
control: Common
documentation: ug
---

# Migrating Syncfusion® ASP.NET Web Forms Controls to Blazor Components

Migrating enterprise applications from **ASP.NET Web Forms** to **Blazor** represents a significant architectural shift from a page centric, postback based framework to a modern, component driven framework built on .NET. This guide provides a **structured, step-by-step migration approach** for [Syncfusion® ASP.NET Web Forms controls](https://help.syncfusion.com/aspnet/overview) to their corresponding [Syncfusion® Blazor components](https://blazor.syncfusion.com/documentation/introduction).

## Why migrate from Web Forms to Blazor?

ASP.NET Web Forms relies heavily on **ViewState**, **server postback**, and a tightly coupled page lifecycle. While this model simplified early web development, it becomes increasingly difficult to scale, test, and maintain in modern applications.

Blazor replaces postback with **event-driven UI updates**, supports **reusable components**, and aligns with modern .NET development practices, making it the recommended migration path for long-term investment.

The following table summarizes the key architectural and functional differences between ASP.NET Web Forms and Blazor.

| Aspect | Web Forms | Blazor |
| --- | --- | --- |
| **Execution model** | Server centric (page postback) | Blazor Server (SignalR) or Blazor WebAssembly |
| **Hosting & deployment** | IIS-hosted only | Cloud, containers, IIS, or static hosting |
| **UI technology** | `.aspx` pages with server controls | Razor components (`.razor`, HTML + C#) |
| **UI definition** | Separate markup and code-behind (`.aspx`, `.aspx.cs`) | Component-based (`.razor` with optional `.razor.cs`) |
| **Lifecycle model** | `Page_Load`, postback events, `Page_Unload` | `OnInitialized{Async}`, `OnParametersSet{Async}`, `OnAfterRender{Async}`, `Dispose` |
| **State management** | ViewState (hidden fields, page level) | Component state (in-memory; persisted per connection in Blazor Server) |
| **User interaction** | Full or partial postback (page reload) | Event-driven UI updates (real-time in Blazor Server via SignalR) |
| **Event handling** | Server callbacks (AutoPostBack) | `EventCallback<T>` and delegates |
| **Dependency injection** | Limited or manual | Built-in with `IServiceCollection` |
| **Navigation model** | Page based navigation (`.aspx`) | SPA style routing using `@page` |
| **Tooling support** | Visual Studio | Visual Studio and Visual Studio Code |
| **Scalability** | Limited by server resources | Cloud native and horizontally scalable |
| **Application updates** | Requires restart for assembly changes | Blazor Server: immediate; WebAssembly: versioned deployment |

## Development environment setup

### Prerequisites for Blazor

* [.NET 8 SDK or later](https://dotnet.microsoft.com/en-us/download/dotnet)
* [Visual Studio](https://visualstudio.microsoft.com/downloads/) 2022 or later or [Visual Studio Code](https://code.visualstudio.com/) with [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension

Verify installation using the following .NET CLI command. Verify that the .NET version is 8.0.0 or later.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet --version
dotnet --info

{% endhighlight %}
{% endtabs %}

## Project Structure Comparison

ASP.NET Web Forms and Blazor Web Apps follow different application architectures. The following table shows the functional equivalents between Web Forms artifacts and Blazor, along with their roles in a Blazor Web App.

| Web Forms Artifact | Blazor Web App Equivalent | Description |
| --- | --- | --- |
| `Default.aspx` | `Components/Pages/Home.razor` | Represents the UI page and route entry point |
| `Default.aspx.cs` | `@code {}` block or `.razor.cs` file | Contains UI logic and event handling |
| `Global.asax` | `Program.cs` | Configures application startup, services, and middleware |
| `web.config` | `appsettings.json` | Stores configuration and environment settings |
| Master Page (`Site.Master`) | `MainLayout.razor` | Defines shared layout and structure across pages |
| `UserControl.ascx` | Razor component (`.razor`) | Defines reusable UI components |
| ViewState | Component state (fields/properties) | Maintains UI state in memory instead of hidden fields |
| CSS references (`<link>`) | `wwwroot/css`, `App.razor` or layout files | Defines global styles and static assets |
| Script references (`<script>`) | `wwwroot/js`, `App.razor` or layout files | Includes JavaScript files and interop scripts |
| Routing (`*.aspx`) | `@page` directive in `.razor` files | Enables route-based navigation |
| Navigation controls | `NavLink` and routing system | Handles navigation between components |
| Session / Application state | Scoped / Singleton services | Manages shared application state |

## Creating a Blazor project

### Creating a Blazor Web App with Interactive Server

For Web Forms migrations, create a **Blazor Web App with Interactive Server** option, which runs server-side and preserves the familiar server hosted execution model with real-time interactivity via SignalR:

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet new blazor -n MyBlazorApp --interactivity Server
cd MyBlazorApp

{% endhighlight %}
{% endtabs %}

> N> The `--interactivity Server` flag configures SignalR based interactivity, providing immediate UI updates similar to Web Forms postback behavior, but over a persistent connection instead of full page reloads.

## Migrating Syncfusion® Components from Web Forms to Blazor

The following shared setup applies to all three Syncfusion components and covers the common configuration required before proceeding to the [component specific migration steps](#add-syncfusion-datagrid-component).

### Package installation

Use the following commands to install the required packages for each component.

| Component | Web Forms package command | Blazor package command |
|---|---|---|
| DataGrid | `dotnet add package Syncfusion.AspNet` | `dotnet add package Syncfusion.Blazor.Grid -v {{ site.releaseversion }}` |
| Scheduler | `dotnet add package Syncfusion.AspNet` | `dotnet add package Syncfusion.Blazor.Schedule -v {{ site.releaseversion }}` |
| RichTextEditor | `dotnet add package Syncfusion.AspNet` | `dotnet add package Syncfusion.Blazor.RichTextEditor -v {{ site.releaseversion }}` |
| Themes | — | `dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}` |

N> Install `Syncfusion.Blazor.Themes` once at the application level. This package is required for the Blazor components used in this migration guide.

### Service registration

ASP.NET Web Forms initializes controls implicitly as part of the page lifecycle. There is no explicit service registration model, controls are automatically available through the runtime.

Blazor uses dependency injection (DI) from the ground up. Syncfusion components must be registered in the service container so the framework can resolve rendering engines, localization providers, and JavaScript interop services required for each component to function correctly.

In the `Program.cs` file, add the Syncfusion namespace and register services:

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}

using Syncfusion.Blazor;
...
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSyncfusionBlazor();  // Register Syncfusion services
var app = builder.Build();
...

{% endhighlight %}
{% endtabs %}

### Add import namespaces

After packages are installed and services are registered, import the required Syncfusion namespaces in the `/_Imports.razor` file.

| Component | Required namespaces |
|---|---|
| DataGrid | `@using Syncfusion.Blazor`<br>`@using Syncfusion.Blazor.Grids` |
| Scheduler | `@using Syncfusion.Blazor`<br>`@using Syncfusion.Blazor.Schedule` |
| RichTextEditor | `@using Syncfusion.Blazor`<br>`@using Syncfusion.Blazor.RichTextEditor` |

### Theme and script configuration

In Web Forms, Syncfusion scripts and styles are manually referenced in individual `.aspx` pages or `master pages`. The developer explicitly controls script load order and dependency resolution.

In Blazor, scripts and styles are served as static web assets from the NuGet package and are referenced once at the application level in the `App.razor` file. This centralized approach ensures consistent theming and eliminates duplicate references across pages.

**Web Forms approach:**

{% tabs %}
{% highlight html tabtitle=".aspx" %}

<link href="Content/ej/web/default-theme/ej.web.all.min.css" rel="stylesheet" />
<script src='<%= Page.ResolveClientUrl("~/Scripts/jquery-3.3.1.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveClientUrl("~/Scripts/jsrender.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveClientUrl("~/Scripts/ej/ej.web.all.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveClientUrl("~/Scripts/ej/ej.webform.min.js")%>' type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

**Blazor equivalent:**

{% tabs %}
{% highlight html tabtitle="App.razor" %}

<link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

### Add Syncfusion® DataGrid component

**Migration overview**

In Web Forms, most [DataGrid](https://help.syncfusion.com/aspnet/grid/overview) features such as paging, sorting, filtering, and grouping are executed on the server and rely on ViewState to preserve UI state across postback.

In [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid), the same features are implemented through component configuration and executed at runtime within the grid itself. This removes the dependency on postbacks and reduces payload size. The grid provides significantly better responsiveness while still supporting remote data operations through `SfDataManager` when required.

| Aspect   | Web Forms (`ej:Grid`)   | Blazor (`SfGrid / SfGrid<TValue>`)                               |
| --- | --- | ---|
| **Package (NuGet)** | [Syncfusion.AspNet](https://www.nuget.org/packages/Syncfusion.AspNet) | [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid)  |
| **Namespace**               | ASPX: `<%@ Register Assembly="Syncfusion.EJ.Web" %>`   | Razor: `@using Syncfusion.Blazor.Grids`  |
| **Component declaration**   | `<ej:Grid runat="server">` (ASPX)  | `<SfGrid>` / `<SfGrid TValue="T">` (Razor)   |
| **Data binding**   | `DataSource` property set in `Page_Load` or callbacks  | `DataSource="@..."` bound during component initialization  |
| **Collection type**  | `DataTable`, `IEnumerable`, server-managed collections | `List<T>` / `IEnumerable<T>`; UI updated via `StateHasChanged()` |
| **Columns** | `<ej:Column Field="..." HeaderText="..." />` | `<GridColumn Field="..." HeaderText="..." Format="..." />`  |
| **Editing & API** | [EditSettings](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.GridProperties.html#Syncfusion_JavaScript_Models_GridProperties_EditSettings) | [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html), [GridEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html), `@ref` async APIs  |
| **Events & commands**   | Server events (postback / AJAX callbacks)   | `EventCallback<T>`-based async handlers   |
| **Theming & assets**   | CSS/JS referenced in `.aspx` or Master Page  | CSS theme files + Syncfusion JS; `AddSyncfusionBlazor()`         |
| **Paging / virtualization** |  [AllowPaging](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.GridProperties.html#Syncfusion_JavaScript_Models_GridProperties_AllowPaging), [ScrollSettings](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.GridProperties.html#Syncfusion_JavaScript_Models_GridProperties_ScrollSettings) | [AllowPaging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowPaging), [GridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html), [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization) |
| **Filtering** | [AllowFiltering](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.GridProperties.html#Syncfusion_JavaScript_Models_GridProperties_AllowFiltering) | [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowFiltering) |
| **Grouping** | [AllowGrouping](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.GridProperties.html#Syncfusion_JavaScript_Models_GridProperties_AllowGrouping)  | [AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowGrouping)|
| **Lifecycle & refs**        | `Page_Load`, control IDs (`ID`)                        | `OnInitialized[Async]`, DI, `@ref` and async methods

This mapping demonstrates that all commonly used Web Forms DataGrid features are fully supported in Blazor, while delivering measurable improvements in performance, responsiveness, and long-term maintainability.

**Component rendering**

In Web Forms, the DataGrid is a server control declared in markup with data assigned in the code-behind during the page lifecycle. In Blazor, the DataGrid is a Razor component bound to in-memory data, with no server postback required.

**Web Forms approach:**

{% tabs %}
{% highlight html tabtitle="Default.aspx" %}

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
{% highlight c# tabtitle="Default.aspx.cs" %}

using System.Web.UI;
namespace WebFormsGrid
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Data is assigned on each page load/postback
            List<Person> Persons = new List<Person>
            {
                new Person() { FirstName = "John", LastName = "Beckett", Email = "john@syncfusion.com" },
                new Person() { FirstName = "Ben", LastName = "Beckett", Email = "ben@syncfusion.com" },
                new Person() { FirstName = "Andrew", LastName = "Beckett", Email = "andrew@syncfusion.com" }
            };

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

**Blazor equivalent:**

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/"
@rendermode InteractiveServer

<SfGrid TValue="Person" DataSource="@Persons">
    <GridColumns>
        <GridColumn Field="@nameof(Person.FirstName)" HeaderText="First Name" />
        <GridColumn Field="@nameof(Person.LastName)" HeaderText="Last Name" />
        <GridColumn Field="@nameof(Person.Email)" HeaderText="Email" />
    </GridColumns>
</SfGrid>

@code {
    // Component state - data persists in memory during component lifetime
    List<Person> Persons = new()
    {
        new Person { FirstName = "John", LastName = "Beckett", Email = "john@syncfusion.com" },
        new Person { FirstName = "Ben", LastName = "Beckett", Email = "ben@syncfusion.com" },
        new Person { FirstName = "Andrew", LastName = "Beckett", Email = "andrew@syncfusion.com" }
    };

    class Person
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

**Key differences:**

Web Forms grids depend on postback and ViewState to persist UI state. Blazor grids receive data through component parameters such as DataSource and maintain both data and UI state in memory within the component instance. When this state changes, Blazor automatically re-renders the grid without postback, avoiding page refreshes and minimizing payload size.

### Add Syncfusion® Scheduler component

**Migration overview**

In Web Forms, the [Scheduler](https://help.syncfusion.com/aspnet/schedule/overview) control relies on server-side rendering, callbacks, and page lifecycle events to manage views, navigation, and appointment data. Appointment state is preserved across postback and refreshed whenever the view or date range changes.

| Aspect  | Web Forms (`ej:Schedule`) | Blazor (`SfSchedule<TValue>`)  |
| --- | --- | --- |
| **Package (NuGet)**       | [Syncfusion.AspNet](https://www.nuget.org/packages/Syncfusion.AspNet)   | [Syncfusion.Blazor.Schedule](https://www.nuget.org/packages/Syncfusion.Blazor.Schedule)  |
| **Namespace**   | ASPX: `<%@ Register Assembly="Syncfusion.EJ.Web" %>` | Razor: `@using Syncfusion.Blazor.Schedule`  |
| **Component declaration** | `<ej:Schedule runat="server">` (ASPX) | `<SfSchedule TValue="T">` (Razor)   |
| **Data binding**          | `DataSource` set during `Page_Load` or callbacks     | `DataSource="@..."` via `ScheduleEventSettings`          |
| **Appointment model**     | [AppointmentSettings](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.ScheduleProperties.html#Syncfusion_JavaScript_Models_ScheduleProperties_AppointmentSettings)  | [ScheduleEventSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEventSettings-1.html)   |
| **Views configuration**   | [CurrentView](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.ScheduleProperties.html#Syncfusion_JavaScript_Models_ScheduleProperties_CurrentView) property  | [`<ScheduleViews>`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleView.html) collection    |
| **Theming & assets**  | CSS/JS referenced in ASPX or Master Page  | CSS theme files + Syncfusion JS; `AddSyncfusionBlazor()` |
| **Lifecycle & refs**      | `Page_Load`, control `ID`  | `OnInitialized[Async]`, DI, `@ref` async APIs   |

**Component rendering**

In Web Forms, the Scheduler is defined as a server control and configured using properties such as `CurrentView` and server-side appointment objects. Data is refreshed during postbacks when navigating between dates or views.

**Web Forms approach:**

{% tabs %}
{% highlight html tabtitle="Default.aspx" %}

<ej:Schedule ID="Schedule1" runat="server" CurrentView="Week">
</ej:Schedule>

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight c# tabtitle="Default.aspx.cs" %}

using System;
using System.Collections.Generic;
using System.Web.UI;

namespace WebFormsScheduler
{
    public partial class _Default : Page
    {
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
    }

    public class Appointment
    {
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

**Blazor equivalent:**

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
        public string? Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }

}

{% endhighlight %}
{% endtabs %}

N> The event class (`Meeting` in this example) property names match the Scheduler's default field mappings. Alternatively, you can add an explicit `Fields` configuration in `ScheduleEventSettings` to map custom property names.

**Key differences:**

Web Forms Scheduler depends on postbacks and server callbacks to update views and appointments. Blazor Scheduler relies on component parameters, in-memory data, and automatic re-rendering, providing smoother navigation and improved scalability.

### Add Syncfusion® Rich Text Editor component

**Migration overview**

In Web Forms, the [Rich Text Editor](https://help.syncfusion.com/aspnet/richtexteditor/overview) is rendered as a server control and relies on server callbacks and postbacks to load, edit, and persist content. The editor content is typically processed on the server, and UI state is restored on each page lifecycle execution.

| Aspect  | Web Forms (`ej:RTE`)  | Blazor (`SfRichTextEditor`)   |
| --- | --- | ---|
| **Package (NuGet)**       | [Syncfusion.AspNet](https://www.nuget.org/packages/Syncfusion.AspNet)  | [Syncfusion.Blazor.RichTextEditor](https://www.nuget.org/packages/Syncfusion.Blazor.RichTextEditor) |
| **Namespace**   | ASPX: `<%@ Register Assembly="Syncfusion.EJ.Web" %>` | Razor: `@using Syncfusion.Blazor.RichTextEditor`     |
| **Component declaration** | `<ej:RTE runat="server">` (ASPX)  | `<SfRichTextEditor>` (Razor)  |
| **Content binding**       | `Value` property set during page lifecycle   | `Value` / `@bind-Value` bound to component state  |
| **Toolbar configuration** | [ToolsList](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.RTEproperties.html#Syncfusion_JavaScript_Models_RTEproperties_ToolsList), [Tools](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.RTEproperties.html#Syncfusion_JavaScript_Models_RTEproperties_Tools)  | [ToolbarSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorToolbarSettings.html) with predefined/custom items           |
| **Theming & assets**      | CSS/JS referenced per page | CSS theme files + Syncfusion JS; `AddSyncfusionBlazor()` |
| **Lifecycle & refs**      | `Page_Load`, control `ID` | `OnInitialized[Async]`, DI, `@ref` async APIs  |

**Component rendering**

In Web Forms, the Rich Text Editor is declared as a server control and content is typically processed on the server during postback. Any change to the content triggers a round trip to persist or restore state.

**Web Forms approach:**

{% tabs %}
{% highlight html tabtitle="Default.aspx" %}

<ej:RTE ID="Editor" runat="server">
</ej:RTE>

{% endhighlight %}
{% endtabs %}

{% tabs %}
{% highlight c# tabtitle="Default.aspx.cs" %}

protected void Page_Load(object sender, EventArgs e)
{
    Editor.Value = "<p>Welcome to Syncfusion Rich Text Editor</p>";
}

{% endhighlight %}
{% endtabs %}

**Blazor equivalent:**

{% tabs %}
{% highlight razor tabtitle="Editor.razor" %}

@page '/rte'

<SfRichTextEditor @bind-Value="Content" Height="400px"></SfRichTextEditor>

@code {
    private string Content = "<p>Welcome to Syncfusion Rich Text Editor</p>";
}

{% endhighlight %}
{% endtabs %}

**Key differences:**

Web Forms Rich Text Editors depend on postback and ViewState to persist content. Blazor Rich Text Editors rely on component parameters, in-memory state, and automatic UI re-rendering, providing smoother editing experience and improved performance.

### Run the application

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application.

Alternatively, run the application using the following .NET CLI command from the project root directory.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet run

{% endhighlight %}
{% endtabs %}

## See also

* [Getting started with Blazor Server App](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)
* [Getting started with Blazor DataGrid](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-server-app)
* [Getting started with Blazor Scheduler](https://blazor.syncfusion.com/documentation/scheduler/getting-started-with-server-app)
* [Getting started with Blazor Rich Text Editor](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started-with-server-app)
