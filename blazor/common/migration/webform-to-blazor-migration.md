---
layout: post
title: Migrate ASP.NET Web Forms Controls to Blazor Components | Syncfusion
description: Step-by-step guide to migrate ASP.NET Web Forms controls including DataGrid, Scheduler, and Rich Text Editor to Blazor components targeting .NET 8 or later.
platform: Blazor
control: Common
documentation: ug
---

# Migrate ASP.NET Web Forms Controls to Blazor Components

Migrating enterprise applications from [ASP.NET Web Forms](https://learn.microsoft.com/en-us/aspnet/web-forms/) to [Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-10.0) represents a significant architectural shift from a page centric, postback based framework to a modern, component driven framework built on .NET. This guide provides a structured, step-by-step migration approach for [ASP.NET Web Forms controls](https://help.syncfusion.com/aspnet/overview) to their corresponding [Blazor components](https://blazor.syncfusion.com/documentation/introduction).

## Why migrate from Web Forms to Blazor?

[ASP.NET Web Forms](https://learn.microsoft.com/en-us/aspnet/web-forms/) follows a **server-side page model** that uses ViewState, postback, and a tightly coupled page lifecycle to process requests and maintain UI state across interactions.

[Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-10.0) uses a component based architecture with reusable Razor components and **event driven UI updates**, where user interactions trigger handlers that refresh the UI without full page reloads. This modern approach improves maintainability, scalability, and testability, making Blazor the preferred choice for migrating and modernizing Web Forms applications.

| Aspect | Web Forms | Blazor |
| --- | --- | --- |
| Execution model | Server centric (page postback) | Blazor Server (SignalR) or Blazor WebAssembly |
| Hosting & deployment | IIS hosted only | Cloud, containers, IIS, or static hosting |
| UI definition | Separate markup and code-behind (`.aspx`, `.aspx.cs`) | Component based (`.razor` with optional `.razor.cs`) |
| Lifecycle model | `Page_Load`, postback events, `Page_Unload` | `OnInitialized{Async}`, `OnParametersSet{Async}`, `OnAfterRender{Async}`, `Dispose` |
| State management | ViewState (hidden fields, page level) | Component state (in-memory, persisted per connection in Blazor Server) |
| User interaction | Full or partial postback (page reload) | Event driven UI updates (real-time in Blazor Server via SignalR) |
| Event handling | Server callbacks (AutoPostBack) | `EventCallback<T>` and delegates |
| Dependency injection | Limited or manual | Built-in with `IServiceCollection` |
| Navigation model | Page based navigation (`.aspx`) | SPA style routing using `@page` |
| Application updates | Requires restart for assembly changes | Blazor Server: immediate; WebAssembly: versioned deployment |

## Prerequisites for Blazor

* [.NET 8 SDK or later](https://dotnet.microsoft.com/en-us/download/dotnet)
* [Visual Studio](https://visualstudio.microsoft.com/downloads/) 2022 or later or [Visual Studio Code](https://code.visualstudio.com/) with [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension

## Project structure comparison

[ASP.NET Web Forms](https://learn.microsoft.com/en-us/aspnet/web-forms/) and [Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-10.0) Web Apps follow different application architectures. The following table maps common Web Forms artifacts to their Blazor equivalents and describes their roles in a Blazor Web App.

| Web Forms Artifact | Blazor Web App Equivalent | Description |
| --- | --- | --- |
| `Default.aspx` | `Components/Pages/Home.razor` | Represents the UI page and route entry point |
| `Default.aspx.cs` | `@code {}` block or `.razor.cs` file | Contains UI logic and event handling |
| `Global.asax` | `Program.cs` | Configures application startup, services, and middleware |
| `web.config` | `appsettings.json` | Stores configuration and environment settings |
| Master Page (`Site.Master`) | `MainLayout.razor`, `App.razor` | Defines shared layout and structure across pages and defines script and style |
| ViewState | Component state (fields/properties) | Maintains UI state in memory instead of hidden fields |
| Routing (`*.aspx`) | `@page` directive in `.razor` files | Enables route based navigation |
| Session / Application state | Scoped / Singleton services | Manages shared application state |

## Migrating components from Web Forms to Blazor

Create a [Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-10.0) project using one of the following getting started guides.

* [Getting Started with Blazor Web App](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)
* [Getting Started with Blazor Server App](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)
* [Getting Started with Blazor WebAssembly App](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)

The following shared setup applies to all components and covers the common configuration required before proceeding to the [component specific migration steps](#component-specific-migration-steps).

### Package installation

In [ASP.NET Web Forms](https://learn.microsoft.com/en-us/aspnet/web-forms/) applications, components are typically installed using a single package, [Syncfusion.AspNet](https://www.nuget.org/packages/Syncfusion.AspNet).

In [Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-10.0) applications, using individual component packages improves performance and reduces application size. For the complete list of available packages, refer to the [Blazor NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages).

Additionally, install the [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes) NuGet package for styling support.

### Service registration

[ASP.NET Web Forms](https://learn.microsoft.com/en-us/aspnet/web-forms/) initializes controls automatically as part of the page lifecycle, without requiring explicit service registration.

[Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/?view=aspnetcore-10.0) uses dependency injection (DI), where components must be registered in the service container to enable required functionality such as rendering and interaction.

In the `Program.cs` file, add the following namespace and register the required services.

{% tabs %}
{% highlight csharp tabtitle="Program.cs" %}

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

### Add required namespaces

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

**Web Forms approach**

Scripts and styles are added manually in individual `.aspx` pages or `Site.Master` pages.

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

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the [stylesheet](https://blazor.syncfusion.com/documentation/appearance/themes) and [script references](https://blazor.syncfusion.com/documentation/common/adding-script-references) in the **App.razor** file.

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

### Migrate to Blazor DataGrid component

**ASP.NET Web Forms Grid** is a traditional control for displaying and managing tabular data in web applications while [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid)  is a modern component designed to provide a faster, more interactive, and responsive user experience. 

For additional details, refer to the [Blazor DataGrid getting started guide](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-server-app) and [Web Forms DataGrid getting started guide](https://help.syncfusion.com/aspnet/grid/getting-started).

| Aspect   | Web Forms (`ej:Grid`)   | Blazor (`SfGrid / SfGrid<TValue>`)                               |
| --- | --- | ---|
| Package (NuGet) | [Syncfusion.AspNet](https://www.nuget.org/packages/Syncfusion.AspNet) | [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid)  |
| Namespace               |  `<%@ Register Assembly="Syncfusion.EJ.Web" %>`   |  `@using Syncfusion.Blazor.Grids`  |
| Component declaration   | `<ej:Grid runat="server">`   | `<SfGrid>` / `<SfGrid TValue="T">`    |
| Data binding   | [DataSource](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.GridProperties.html#Syncfusion_JavaScript_Models_GridProperties_DataSource) property set in `Page_Load` or callbacks  | [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property bound during component initialization  |
| Collection type  | `DataTable`, `IEnumerable`, server managed collections | `List<T>` / `IEnumerable<T>` |
| Columns | [Columns](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.GridProperties.html#Syncfusion_JavaScript_Models_GridProperties_Columns) property defined using `<ej:Column Field="..." HeaderText="..." />`  | [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Columns) property defined by using `<GridColumn Field="..." HeaderText="..." Format="..." />`  |
| Editing & API | [EditSettings](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.GridProperties.html#Syncfusion_JavaScript_Models_GridProperties_EditSettings) | [GridEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEditSettings.html), [GridEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html), `@ref` async APIs  |
| Events & commands   | Server events (postback / AJAX callbacks)   | `EventCallback<T>` based async handlers   |
| Paging / virtualization API |  [AllowPaging](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.GridProperties.html#Syncfusion_JavaScript_Models_GridProperties_AllowPaging), [ScrollSettings](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.GridProperties.html#Syncfusion_JavaScript_Models_GridProperties_ScrollSettings) | [AllowPaging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowPaging), [GridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html),  [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization) |
| Filtering API | [AllowFiltering](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.GridProperties.html#Syncfusion_JavaScript_Models_GridProperties_AllowFiltering) | [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowFiltering) |
| Grouping API | [AllowGrouping](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.GridProperties.html#Syncfusion_JavaScript_Models_GridProperties_AllowGrouping)  | [AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowGrouping)|
| Lifecycle & refs        | `Page_Load`, control IDs (`ID`)                        | `OnInitialized{Async}`, DI, `@ref` and async methods |

#### Component configuration for DataGrid

**Web Forms approach**

The Grid control for ASP.NET is an efficient display engine for tabular data by defining [Columns](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.GridProperties.html#Syncfusion_JavaScript_Models_GridProperties_Columns) and linking them to `Fields` in a [DataSource](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.GridProperties.html#Syncfusion_JavaScript_Models_GridProperties_DataSource) property. In the example, a list of people is created and assigned to the Grid, which then automatically displays the data as rows and columns.

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

**Blazor equivalent**

The [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) component is declared in Razor markup and binds data directly to a component property using the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property.

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

### Migrate to Blazor Scheduler component

**ASP.NET Web Forms Scheduler** is used to organize and manage events across different calendar views in web applications, while [Blazor Scheduler](https://www.syncfusion.com/blazor-components/blazor-scheduler) is a modern component that offers a more dynamic and user friendly way to handle appointments and scheduling. 

For additional details, refer to the [Blazor Scheduler getting started guide](https://blazor.syncfusion.com/documentation/scheduler/getting-started-with-server-app) and [Web Forms Scheduler getting started guide](https://help.syncfusion.com/aspnet/schedule/getting-started).

| Aspect  | Web Forms (`ej:Schedule`) | Blazor (`SfSchedule<TValue>`)  |
| --- | --- | --- |
| Package (NuGet)      | [Syncfusion.AspNet](https://www.nuget.org/packages/Syncfusion.AspNet)   | [Syncfusion.Blazor.Schedule](https://www.nuget.org/packages/Syncfusion.Blazor.Schedule)  |
| Namespace   | `<%@ Register Assembly="Syncfusion.EJ.Web" %>` | `@using Syncfusion.Blazor.Schedule`  |
| Component declaration | `<ej:Schedule runat="server">` | `<SfSchedule TValue="T">`   |
| Data binding API        | [DataSource](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.ScheduleFields.html#Syncfusion_JavaScript_Models_ScheduleFields_DataSource) set during `Page_Load` or callbacks     | `DataSource="@..."` via [ScheduleEventSettings.DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEventSettings-1.html#Syncfusion_Blazor_Schedule_ScheduleEventSettings_1_DataSource)      |
| Appointment model API   | [AppointmentSettings](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.ScheduleProperties.html#Syncfusion_JavaScript_Models_ScheduleProperties_AppointmentSettings)  | [ScheduleEventSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEventSettings-1.html)   |
| Views configuration   | [CurrentView](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.ScheduleProperties.html#Syncfusion_JavaScript_Models_ScheduleProperties_CurrentView) property  | [ScheduleViews](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleView.html) collection    |
| Lifecycle & refs      | `Page_Load`, control `ID`  | `OnInitialized{Async}`, DI, `@ref` async APIs   |

#### Component configuration for Scheduler

**Web Forms approach**

The **Scheduler** is an event calendar that manages the list of various activities (events/appointments) in different available views (day, week, workweek, month and agenda) for various resources. It is simply a server-side wrapper of JS Scheduler component and all the features of JS platform are applicable in ASP Scheduler too. 

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

**Blazor equivalent**

The [Blazor Scheduler](https://www.syncfusion.com/blazor-components/blazor-scheduler) component is declared in Razor markup, where views are configured using child components, and appointment data is supplied through the [ScheduleEventSettings.Datasource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEventSettings-1.html) property.

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

### Migrate to Blazor Rich Text Editor component

**ASP.ET Web Forms Rich Text Editor**  is a component used for creating and formatting content such as text, images, tables, and links with various editing tools. [Blazor Rich Text Editor](https://www.syncfusion.com/rich-text-editor-sdk/blazor-rich-text-editor) is a modern component that offers a more dynamic and user-friendly way to create rich content with support for HTML, Markdown, and responsive design. 

For additional details, refer to the [Blazor Rich Text Editor getting started guide](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started-with-server-app) and [Web Forms Rich Text Editor getting started guide](https://help.syncfusion.com/aspnet/richtexteditor/getting-started).

| Aspect  | Web Forms (`ej:RTE`)  | Blazor (`SfRichTextEditor`)   |
| --- | --- | ---|
| Package (NuGet)       | [Syncfusion.AspNet](https://www.nuget.org/packages/Syncfusion.AspNet)  | [Syncfusion.Blazor.RichTextEditor](https://www.nuget.org/packages/Syncfusion.Blazor.RichTextEditor) |
| Namespace   | ASPX: `<%@ Register Assembly="Syncfusion.EJ.Web" %>` | Razor: `@using Syncfusion.Blazor.RichTextEditor`     |
| Component declaration | `<ej:RTE runat="server">` (ASPX)  | `<SfRichTextEditor>` (Razor)  |
| Content binding       | [Value](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.RTEproperties.html#Syncfusion_JavaScript_Models_RTEproperties_Value) property set during page lifecycle   | [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_Value) / `@bind-Value` bound to component state  |
| Toolbar configuration | [ToolsList](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.RTEproperties.html#Syncfusion_JavaScript_Models_RTEproperties_ToolsList), [Tools](https://help.syncfusion.com/cr/aspnet/Syncfusion.JavaScript.Models.RTEproperties.html#Syncfusion_JavaScript_Models_RTEproperties_Tools)  | [ToolbarSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorToolbarSettings.html) with predefined/custom items |
| Lifecycle & refs      | `Page_Load`, control `ID` | `OnInitialized{Async}`, DI, `@ref` async APIs  |

#### Component configuration for Rich Text Editor

**Web Forms approach**

The Rich Text Editor content is defined directly within the markup using the `RTEContent` section, with content embedded as static HTML.

{% tabs %}
{% highlight html tabtitle="Default.aspx" %}

<ej:RTE ID="RTE" Height="400px" runat="server">
    <RTEContent>
        <p>Welcome to Blazor Rich Text Editor</p>
    </RTEContent>
</ej:RTE>

{% endhighlight %}
{% endtabs %}

**Blazor equivalent**

The [Blazor Rich Text Editor](https://www.syncfusion.com/rich-text-editor-sdk/blazor-rich-text-editor) is implemented as a Razor component, where content is bound dynamically using the [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_Value) property with two-way binding.

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
