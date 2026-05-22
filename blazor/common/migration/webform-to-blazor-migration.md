---
layout: post
title: Migrate ASP.NET Web Forms Controls to Blazor Components | Syncfusion
description: Step-by-step guide to migrate ASP.NET Web Forms controls including DataGrid, Scheduler, and Rich Text Editor to Blazor components targeting .NET 8 or later.
platform: Blazor
control: Common
documentation: ug
---

# Migrate ASP.NET Web Forms Controls to Blazor Components

Migrating enterprise applications from [ASP.NET Web Forms](https://learn.microsoft.com/en-us/aspnet/web-forms/) to [Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-10.0) represents a significant architectural shift from a page-centric, postback-based framework to a modern, component-driven framework built on .NET. This guide provides a **structured, step-by-step migration approach** for [ASP.NET Web Forms controls](https://help.syncfusion.com/aspnet/overview) to their corresponding [Blazor components](https://blazor.syncfusion.com/documentation/introduction).

## Why migrate from Web Forms to Blazor?

ASP.NET Web Forms follows a **server-side page model** that uses ViewState, postback, and a tightly coupled page lifecycle to process requests and maintain UI state across interactions.

Blazor uses a component-based architecture with reusable Razor components and **event-driven UI updates**, where user interactions trigger handlers that refresh the UI without full page reloads. This modern approach improves maintainability, scalability, and testability, making Blazor the preferred choice for migrating and modernizing Web Forms applications.

| Aspect | Web Forms | Blazor |
| --- | --- | --- |
| Execution model | Server-centric (page postback) | Blazor Server (SignalR) or Blazor WebAssembly |
| Hosting & deployment | IIS hosted only | Cloud, containers, IIS, or static hosting |
| UI technology | `.aspx` pages with server controls | Razor components (`.razor`, HTML + C#) |
| UI definition | Separate markup and code-behind (`.aspx`, `.aspx.cs`) | Component-based (`.razor` with optional `.razor.cs`) |
| Lifecycle model | `Page_Load`, postback events, `Page_Unload` | `OnInitialized{Async}`, `OnParametersSet{Async}`, `OnAfterRender{Async}`, `Dispose` |
| State management | ViewState (hidden fields, page level) | Component state (in-memory, persisted per connection in Blazor Server) |
| User interaction | Full or partial postback (page reload) | Event-driven UI updates (real-time in Blazor Server via SignalR) |
| Event handling | Server callbacks (AutoPostBack) | `EventCallback<T>` and delegates |
| Dependency injection | Limited or manual | Built-in with `IServiceCollection` |
| Navigation model | Page based navigation (`.aspx`) | SPA-style routing using `@page` |
| Tooling support | Visual Studio | Visual Studio and Visual Studio Code |
| Scalability | Limited by server resources | Cloud native and horizontally scalable |
| Application updates | Requires restart for assembly changes | Blazor Server: immediate; WebAssembly: versioned deployment |

## Prerequisites for Blazor

* [.NET 8 SDK or later](https://dotnet.microsoft.com/en-us/download/dotnet)
* [Visual Studio](https://visualstudio.microsoft.com/downloads/) 2022 or later or [Visual Studio Code](https://code.visualstudio.com/) with [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension

## Project Structure Comparison

ASP.NET Web Forms and Blazor Web Apps follow different application architectures. The following table maps common Web Forms artifacts to their Blazor equivalents and describes their roles in a Blazor Web App.

| Web Forms Artifact | Blazor Web App Equivalent | Description |
| --- | --- | --- |
| `Default.aspx` | `Components/Pages/Home.razor` | Represents the UI page and route entry point |
| `Default.aspx.cs` | `@code {}` block or `.razor.cs` file | Contains UI logic and event handling |
| `Global.asax` | `Program.cs` | Configures application startup, services, and middleware |
| `web.config` | `appsettings.json` | Stores configuration and environment settings |
| Master Page (`Site.Master`) | `MainLayout.razor` | Defines shared layout and structure across pages |
| ViewState | Component state (fields/properties) | Maintains UI state in memory instead of hidden fields |
| CSS references (`<link>`) | `wwwroot/css`, `App.razor` or layout files | Defines global styles and static assets |
| Script references (`<script>`) | `wwwroot/js`, `App.razor` or layout files | Includes JavaScript files and interop scripts |
| Routing (`*.aspx`) | `@page` directive in `.razor` files | Enables route-based navigation |
| Session / Application state | Scoped / Singleton services | Manages shared application state |

## Migrating Components from Web Forms to Blazor

Create a Blazor project using one of the following getting started guides.

* [Getting Started with Blazor Web App](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)
* [Getting Started with Blazor Server App](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)
* [Getting Started with Blazor WebAssembly App](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)

The following shared setup applies to all components and covers the common configuration required before proceeding to the [component specific migration steps](#component-specific-migration-steps).

### Package installation

In Web Forms applications, components are typically installed using a single package, [Syncfusion.AspNet](https://www.nuget.org/packages/Syncfusion.AspNet).

In Blazor applications, using individual component packages improves performance and reduces application size. For the complete list of available packages, refer to the [Blazor NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages).

Additionally, install the [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes) NuGet package for styling support.

### Service registration

ASP.NET Web Forms initializes controls automatically as part of the page lifecycle, without requiring explicit service registration.

Blazor uses dependency injection (DI), where components must be registered in the service container to enable required functionality such as rendering and interaction.

In the `Program.cs` file, add the following namespace and register the required services.

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}

using Syncfusion.Blazor;
...
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSyncfusionBlazor();  // Register Blazor services
var app = builder.Build();
...

{% endhighlight %}
{% endtabs %}

### Add required namespace

After packages are installed and services are registered, import the required namespaces in the `_Imports.razor` file.

{% tabs %}
{% highlight razor tabtitle="_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Schedule
@using Syncfusion.Blazor.RichTextEditor

{% endhighlight %}
{% endtabs %}

The above lists the namespaces for all components covered in this guide. Import only the namespaces required for the components you use.

### Theme and script configuration

In Web Forms, scripts and styles are added manually in individual `.aspx` pages or `Site.Master` pages.

In Blazor, scripts and styles are included once at the application level (such as in `App.razor` file) and are served from static web assets. This approach ensures consistent styling and avoids duplicate references across pages.

**Web Forms approach**

{% tabs %}
{% highlight html tabtitle=".aspx" %}

<link href="Content/ej/web/default-theme/ej.web.all.min.css" rel="stylesheet" />
<script src='<%= Page.ResolveClientUrl("~/Scripts/jquery-3.3.1.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveClientUrl("~/Scripts/jsrender.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveClientUrl("~/Scripts/ej/ej.web.all.min.js")%>' type="text/javascript"></script>
<script src='<%= Page.ResolveClientUrl("~/Scripts/ej/ej.webform.min.js")%>' type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

**Blazor equivalent**

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
    <!-- Blazor script (required for UI components) -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"></script>
    ...
</body>

{% endhighlight %}
{% endtabs %}

## Component specific migration steps

### Add Blazor DataGrid component

For detailed explanation, refer to the [Blazor DataGrid getting started guide](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-server-app) and [Web Forms DataGrid getting started guide](https://help.syncfusion.com/aspnet/grid/getting-started).

| Aspect   | Web Forms (`ej:Grid`)   | Blazor (`SfGrid / SfGrid<TValue>`)                               |
| --- | --- | ---|
| Package (NuGet) | [Syncfusion.AspNet](https://www.nuget.org/packages/Syncfusion.AspNet) | [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid)  |
| Namespace               | ASPX: `<%@ Register Assembly="Syncfusion.EJ.Web" %>`   | Razor: `@using Syncfusion.Blazor.Grids`  |
| Component declaration   | `<ej:Grid runat="server">` (ASPX)  | `<SfGrid>` / `<SfGrid TValue="T">` (Razor)   |
| Data binding   | [DataSource](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.GridProperties.html#Syncfusion_JavaScript_Models_GridProperties_DataSource) property set in `Page_Load` or callbacks  | [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property bound during component initialization  |
| Collection type  | `DataTable`, `IEnumerable`, server managed collections | `List<T>` / `IEnumerable<T>`. UI updated via `StateHasChanged()` |
| Columns | [Columns](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.GridProperties.html#Syncfusion_JavaScript_Models_GridProperties_Columns) property defined using `<ej:Column Field="..." HeaderText="..." />`  | [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Columns) property defined by using `<GridColumn Field="..." HeaderText="..." Format="..." />`  |
| Editing & API | [EditSettings](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.GridProperties.html#Syncfusion_JavaScript_Models_GridProperties_EditSettings) | [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html), [GridEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html), `@ref` async APIs  |
| Events & commands   | Server events (postback / AJAX callbacks)   | `EventCallback<T>` based async handlers   |
| Theming & assets   | CSS/JS referenced in `.aspx` or Master Page  | CSS theme files + JS and `AddSyncfusionBlazor()`         |
| Paging / virtualization |  [AllowPaging](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.GridProperties.html#Syncfusion_JavaScript_Models_GridProperties_AllowPaging), [ScrollSettings](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.GridProperties.html#Syncfusion_JavaScript_Models_GridProperties_ScrollSettings) | [AllowPaging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowPaging), [GridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html), [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization) |
| Filtering | [AllowFiltering](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.GridProperties.html#Syncfusion_JavaScript_Models_GridProperties_AllowFiltering) | [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowFiltering) |
| Grouping | [AllowGrouping](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.GridProperties.html#Syncfusion_JavaScript_Models_GridProperties_AllowGrouping)  | [AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowGrouping)|
| Lifecycle & refs        | `Page_Load`, control IDs (`ID`)                        | `OnInitialized{Async}`, DI, `@ref` and async methods |

#### Component configuration for DataGrid

In Web Forms, the DataGrid is defined using server controls, and the [DataSource](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.GridProperties.html#Syncfusion_JavaScript_Models_GridProperties_DataSource) is assigned in the code-behind during the page lifecycle (for example, in the `Page_Load` method).

In Blazor, the [DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) component is declared in Razor markup and binds data directly to a component property using the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property.

#### Web Forms approach for DataGrid

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

{% highlight c# tabtitle="Default.aspx.cs" %}

using System.Web.UI;
namespace WebFormsGrid
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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

#### Blazor equivalent of DataGrid

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

<SfGrid TValue="Person" DataSource="@Persons">
    <GridColumns>
        <GridColumn Field="@nameof(Person.FirstName)" HeaderText="First Name" />
        <GridColumn Field="@nameof(Person.LastName)" HeaderText="Last Name" />
        <GridColumn Field="@nameof(Person.Email)" HeaderText="Email" />
    </GridColumns>
</SfGrid>

@code {
    private List<Person> Persons = new()
    {
        new Person { FirstName = "John", LastName = "Beckett", Email = "john@syncfusion.com" },
        new Person { FirstName = "Ben", LastName = "Beckett", Email = "ben@syncfusion.com" },
        new Person { FirstName = "Andrew", LastName = "Beckett", Email = "andrew@syncfusion.com" }
    };

    public class Person
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

### Add Blazor Scheduler component

For detailed explanation, refer to the [Blazor Scheduler getting started guide](https://blazor.syncfusion.com/documentation/scheduler/getting-started-with-server-app) and [Web Forms Scheduler getting started guide](https://help.syncfusion.com/aspnet/schedule/getting-started).

| Aspect  | Web Forms (`ej:Schedule`) | Blazor (`SfSchedule<TValue>`)  |
| --- | --- | --- |
| Package (NuGet)      | [Syncfusion.AspNet](https://www.nuget.org/packages/Syncfusion.AspNet)   | [Syncfusion.Blazor.Schedule](https://www.nuget.org/packages/Syncfusion.Blazor.Schedule)  |
| Namespace   | ASPX: `<%@ Register Assembly="Syncfusion.EJ.Web" %>` | Razor: `@using Syncfusion.Blazor.Schedule`  |
| Component declaration | `<ej:Schedule runat="server">` (ASPX) | `<SfSchedule TValue="T">` (Razor)   |
| Data binding          | [DataSource](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.ScheduleFields.html#Syncfusion_JavaScript_Models_ScheduleFields_DataSource) set during `Page_Load` or callbacks     | `DataSource="@..."` via [ScheduleEventSettings.DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEventSettings-1.html#Syncfusion_Blazor_Schedule_ScheduleEventSettings_1_DataSource)      |
| Appointment model    | [AppointmentSettings](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.ScheduleProperties.html#Syncfusion_JavaScript_Models_ScheduleProperties_AppointmentSettings)  | [ScheduleEventSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEventSettings-1.html)   |
| Views configuration   | [CurrentView](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.ScheduleProperties.html#Syncfusion_JavaScript_Models_ScheduleProperties_CurrentView) property  | [ScheduleViews](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleView.html) collection    |
| Theming & assets  | CSS/JS referenced in ASPX or Master Page  | CSS theme files + JS and `AddSyncfusionBlazor()` |
| Lifecycle & refs      | `Page_Load`, control `ID`  | `OnInitialized{Async}`, DI, `@ref` async APIs   |

#### Component configuration for Scheduler

In Web Forms, the Scheduler is defined using server controls, where configuration is set through control properties and appointment data is assigned programmatically in the code-behind during page execution.

In Blazor, the [Scheduler](https://www.syncfusion.com/blazor-components/blazor-scheduler) is implemented as a Razor component, where views and event settings are defined declaratively in markup, and appointment data is bound directly using the [ScheduleEventSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEventSettings-1.html) property.

#### Web Forms approach for Scheduler

{% tabs %}
{% highlight html tabtitle="Default.aspx" %}

<ej:Schedule ID="Schedule1" runat="server" CurrentView="Week">
</ej:Schedule>

{% endhighlight %}

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
            Schedule1.AppointmentSettings.DataSource = new List<Appointment>
            {
                new Appointment
                {
                    Id = 1,
                    Subject = "Meeting",
                    StartTime = DateTime.Now,
                    EndTime = DateTime.Now.AddHours(1)
                }
            };
            Schedule1.AppointmentSettings.Id = "Id";
            Schedule1.AppointmentSettings.Subject = "Subject";
            Schedule1.AppointmentSettings.StartTime = "StartTime";
            Schedule1.AppointmentSettings.EndTime = "EndTime";
        }
    }

    public class Appointment
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

#### Blazor equivalent of Scheduler

{% tabs %}
{% highlight razor tabtitle="Schedule.razor" %}

<SfSchedule TValue="Meeting" Height="650px" CurrentView="View.Week">
    <ScheduleViews>
        <ScheduleView Option="View.Day" />
        <ScheduleView Option="View.Week" />
        <ScheduleView Option="View.Month" />
    </ScheduleViews>
    <ScheduleEventSettings DataSource="@Meetings" />
</SfSchedule>

@code {
    private List<Meeting> Meetings = new()
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
        public string Subject { get; set; } = string.Empty;
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

N> The event class (`Meeting` in this example) property names match the Scheduler's default field mappings. Alternatively, you can add an explicit [Fields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleField.html) configuration in `ScheduleEventSettings` to map custom property names.

### Add Blazor Rich Text Editor component

For detailed explanation, refer to the [Blazor Rich Text Editor getting started guide](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started-with-server-app) and [Web Forms Rich Text Editor getting started guide](https://help.syncfusion.com/aspnet/richtexteditor/getting-started).

| Aspect  | Web Forms (`ej:RTE`)  | Blazor (`SfRichTextEditor`)   |
| --- | --- | ---|
| Package (NuGet)       | [Syncfusion.AspNet](https://www.nuget.org/packages/Syncfusion.AspNet)  | [Syncfusion.Blazor.RichTextEditor](https://www.nuget.org/packages/Syncfusion.Blazor.RichTextEditor) |
| Namespace   | ASPX: `<%@ Register Assembly="Syncfusion.EJ.Web" %>` | Razor: `@using Syncfusion.Blazor.RichTextEditor`     |
| Component declaration | `<ej:RTE runat="server">` (ASPX)  | `<SfRichTextEditor>` (Razor)  |
| Content binding       | [Value](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.RTEproperties.html#Syncfusion_JavaScript_Models_RTEproperties_Value) property set during page lifecycle   | [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_Value) / `@bind-Value` bound to component state  |
| Toolbar configuration | [ToolsList](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.RTEproperties.html#Syncfusion_JavaScript_Models_RTEproperties_ToolsList), [Tools](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.RTEproperties.html#Syncfusion_JavaScript_Models_RTEproperties_Tools)  | [ToolbarSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorToolbarSettings.html) with predefined/custom items |
| Theming & assets      | CSS/JS referenced per page | CSS theme files/JS and `AddSyncfusionBlazor()` |
| Lifecycle & refs      | `Page_Load`, control `ID` | `OnInitialized{Async}`, DI, `@ref` async APIs  |

#### Component configuration for Rich Text Editor

In Web Forms, the Rich Text Editor content is defined directly within the markup using the `RTEContent` section, with content embedded as static HTML.

In Blazor, the [Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-rich-text-editor) is implemented as a Razor component, where content is bound dynamically using the [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_Value) property with two-way binding.

#### Web Forms approach for Rich Text Editor

{% tabs %}
{% highlight html tabtitle="Default.aspx" %}

<ej:RTE ID="RTE" Height="400px" runat="server">
    <RTEContent>
        <p>Welcome to Blazor Rich Text Editor</p>
    </RTEContent>
</ej:RTE>

{% endhighlight %}
{% endtabs %}

#### Blazor equivalent of Rich Text Editor

{% tabs %}
{% highlight razor tabtitle="Editor.razor" %}

<SfRichTextEditor @bind-Value="Content" Height="400px"></SfRichTextEditor>

@code {
    private string? Content = "<p>Welcome to Blazor Rich Text Editor</p>";
}

{% endhighlight %}
{% endtabs %}

## Run the application

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application.

Alternatively, run the application using the following .NET CLI command from the project root directory.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet run

{% endhighlight %}
{% endtabs %}

## See also

* [Getting started with Blazor DataGrid](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-server-app)
* [Getting started with Blazor Scheduler](https://blazor.syncfusion.com/documentation/scheduler/getting-started-with-server-app)
* [Getting started with Blazor Rich Text Editor](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started-with-server-app)
