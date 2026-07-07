---
layout: post
title: Migrating ASP.NET Core Razor Pages to Blazor | Syncfusion
description: Learn how to migrate ASP.NET Core Razor Pages controls to Blazor components, including key concepts and a detailed migration approach.
platform: Blazor
control: Common
documentation: ug
---

# Migrating ASP.NET Core Razor Pages to Blazor

Migrating applications from [ASP.NET Core Razor Pages](https://learn.microsoft.com/en-us/aspnet/core/razor-pages/) to [Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/) represents a shift from a page centric, request response model to a modern, component based UI framework built on .NET. This guide explains how to migrate commonly used [ASP.NET Core Razor Pages controls](https://www.syncfusion.com/aspnet-core-ui-controls) to their [Blazor equivalents](https://www.syncfusion.com/blazor-components).

## Why migrate from ASP.NET Core Razor Pages to Blazor?

[ASP.NET Core Razor Pages](https://learn.microsoft.com/en-us/aspnet/core/razor-pages/) simplify the MVC pattern by combining UI and logic at the page level. However, for highly interactive applications, developers often rely on JavaScript, partial rendering, and additional client-side logic to manage dynamic UI behavior.

[Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/) provides a modern approach by enabling component based UI development in C#, along with built-in state management and event driven updates. This reduces dependency on external JavaScript frameworks and improves maintainability, scalability, and developer productivity.

| Aspect     | Razor Pages      | Blazor         |
| --- | ---| --- |
| Execution model   | Request response (page based)  | Blazor Server (SignalR) or WebAssembly (client-side)     |
| Hosting & deployment      | IIS, Azure App Service  | Cloud, containers, IIS, static hosting (WebAssembly)    |
| UI definition            | Page + PageModel (`.cshtml`, `.cshtml.cs`) | Component based (`.razor` with optional `.razor.cs`)  |
| Lifecycle model    | `OnGet`, `OnPost`, handler methods | `OnInitialized{Async}`, `OnParametersSet{Async}`, `OnAfterRender{Async}` |
| State management  | Stateless per request. Uses `TempData`, `ViewData`, or `Session`   |  Component scoped fields/properties. Supports cascading values, services, and state containers      |
| User interaction          | Page reload or partial updates with JS     | Event driven UI updates without reload    |
| Event handling            | Handler methods (`OnPost`, form submit)    | `EventCallback<T>`, C# delegates   |
| Dependency injection      | Supported via constructor injection        | Built-in and deeply integrated      |
| Navigation model          | File based routing (`Pages/*.cshtml`)      | SPA style routing using `@page`       |
| Rendering model           | Server rendered HTML with optional JS      | Interactive rendering using server or client execution    |
| Component reuse           | Limited (partials, tag helpers)            | Strong component reusability     |
| JavaScript dependency     | Often required for interactivity           | Minimal (optional via [JS interop](https://learn.microsoft.com/en-us/aspnet/core/blazor/javascript-interoperability/?view=aspnetcore-10.0))      |
| Scalability               | Depends on server rendering                | Depends on hosting model      |

## Prerequisites for Blazor

* [.NET 8 SDK or later](https://dotnet.microsoft.com/en-us/download/dotnet)
* [Visual Studio](https://visualstudio.microsoft.com/downloads/) 2022 or later, or [Visual Studio Code](https://code.visualstudio.com/) with [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension

## Project structure comparison

[ASP.NET Core Razor Pages](https://learn.microsoft.com/en-us/aspnet/core/razor-pages/) and [Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/) Web Apps follow different architectural patterns. The following table shows the functional equivalents between Razor Pages artifacts and Blazor, along with their roles in a Blazor Web App.

| Razor Pages Artifact  | Blazor Web App Equivalent     | Description           |
| --- | --- | --- |
| `Pages/*.cshtml`    | `Components/Pages/*.razor`   | Defines the UI page and route entry point  |
| `.cshtml.cs` (PageModel) | `@code {}` block or `.razor.cs` code-behind file | Contains page logic, event handling, and data binding |
| `_Layout.cshtml`   | `MainLayout.razor`   | Provides shared layout structure across pages           |
| Partial Pages     | Razor components (`.razor`)   | Enables reusable UI components                          |
| File based routing   | `@page` directive        | Defines routes directly in components                   |
| `wwwroot`      | `wwwroot`            | Stores static files like CSS, JS, and images            |
| PageModel state (`TempData`, `ViewData`) | Component state (fields/properties)   | Maintains UI state within the component |
| Handler methods (`OnGet`, `OnPost`) | `OnInitialized{Async}` (data load); `EventCallback` / `EditForm` `OnValidSubmit` (form submit) | Controls execution flow, data initialization, and user-triggered actions |
| JavaScript based updates   | Event driven UI updates (C#)  | Handles user interaction without page reload            |
| Services / Models    | Reused via DI (Dependency Injection) | Shares business logic and data access across components |

N> Business logic, POCO models, and stateless services from Razor Pages can typically be reused in Blazor with minimal changes. For EF Core, consider using `IDbContextFactory<T>` to avoid `DbContext` lifetime issues in Blazor Server apps. See [EF Core with Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/blazor-ef-core).

## Migrating components from ASP.NET Core Razor Pages to Blazor

Create a [Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/) project using one of the following getting started guides.

* [Getting Started with Blazor Web App](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)
* [Getting Started with Blazor Server App](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)
* [Getting Started with Blazor WebAssembly App](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)

The following shared setup applies to all components and covers the common configuration required before proceeding to the [component specific migration steps](#component-specific-migration-steps).

### Package installation

In [ASP.NET Core Razor Pages](https://learn.microsoft.com/en-us/aspnet/core/razor-pages/), controls are typically installed using a single combined package, such as [Syncfusion.EJ2.AspNet.Core](https://www.nuget.org/packages/Syncfusion.EJ2.AspNet.Core). 

In [Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/) applications, using individual component packages improves performance and reduces application size. For the complete list of available packages, refer to the [Blazor NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages).

Additionally, install the [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes) NuGet package for styling support.

### Service registration

In [ASP.NET Core Razor Pages](https://learn.microsoft.com/en-us/aspnet/core/razor-pages/), controls are configured through script and stylesheet references in the layout, rather than through DI service registration.

[Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/), on the other hand, uses dependency injection by default. Components must be registered in the service container so the framework can provide the required functionality, such as rendering and JavaScript interaction.

In the `Program.cs` file, add the Blazor namespace and register the required services.

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}

using Syncfusion.Blazor;
...
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddSyncfusionBlazor();  // Register services
var app = builder.Build();
...

{% endhighlight %}
{% endtabs %}

### Add required namespaces

**ASP.NET Core Razor Pages approach**

The namespaces are imported into Razor views using `~/_ViewImports.cshtml`, primarily to enable Tag Helpers and HTML helper extensions.

Add the `Syncfusion.EJ2` TagHelper in `~/_ViewImports.cshtml`.

{% tabs %}
{% highlight cshtml tabtitle="~/_ViewImports.cshtml" %}

@addTagHelper *, Syncfusion.EJ2

{% endhighlight %}
{% endtabs %}

**Blazor equivalent**

In Blazor, `~/_Imports.razor` serves a similar purpose but applies to Razor components. It allows components to access namespaces globally without requiring repeated `@using` statements in each `.razor` file.

Import the required namespaces in the `~/_Imports.razor` file.

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

**ASP.NET Core Razor Pages approach**

Scripts and styles are manually referenced in the shared layout (`_Layout.cshtml`). In addition controls require the `<ejs-scripts>` helper, which initializes the required JavaScript controls at runtime.

{% tabs %}
{% highlight html tabtitle="_Layout.cshtml" %}

<head>
    ...
    <!-- ASP.NET Core control styles -->
    <link rel="stylesheet" href="https://cdn.syncfusion.com/ej2/{{ site.releaseversion }}/fluent2.css" />
    <!-- ASP.NET Core control scripts -->
    <script src="https://cdn.syncfusion.com/ej2/{{ site.releaseversion }}/dist/ej2.min.js"></script>
</head>

{% endhighlight %}
{% endtabs %}

Also, register the script manager `<ejs-scripts>` at the end of `<body>` in the `~/Pages/Shared/_Layout.cshtml` file as follows.

{% tabs %}
{% highlight cshtml tabtitle="~/_Layout.cshtml" %}

<body>
    ...
    <!-- Script Manager -->
    <ejs-scripts></ejs-scripts>
</body>

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
    <!-- Blazor core script (required for UI components) -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"></script>
    ...
</body>

{% endhighlight %}
{% endtabs %}

## Component specific migration steps

### Migrate to Blazor DataGrid component

The [ASP.NET Core Razor Pages DataGrid](https://www.syncfusion.com/aspnet-core-ui-controls/grid) is a feature rich control for displaying data in a tabular format, while [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) provides a modern, feature rich component for building interactive data-driven user interfaces.

For detailed guidance, refer to the [Blazor DataGrid getting started guide](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-server-app) and the [ASP.NET Core Razor DataGrid getting started guide](https://help.syncfusion.com/aspnet/grid/getting-started).

| Aspect         | Razor Pages (`ejs-grid`)        | Blazor (`SfGrid` / `SfGrid<TValue>`)        |
| --- | --- | --- |
| Package (NuGet)       | [Syncfusion.EJ2.AspNet.Core](https://www.nuget.org/packages/Syncfusion.EJ2.AspNet.Core) | [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid) |
| Component declaration | `<ejs-grid>` helper in `.cshtml`   | `<SfGrid>` / `<SfGrid TValue="T">`      |
| Data binding   | Data passed via `PageModel` (`OnGet`) or `dataSource` property  | `DataSource="@..."` bound in component   |
| Collection type   | `IEnumerable<T>` / server-side model  | `List<T>` / `IEnumerable<T>`  |
| Columns   | Column builder API   | `<GridColumn>` elements   |
| Paging API   | [AllowPaging](https://help.syncfusion.com/cr/aspnetcore-js2/Syncfusion.EJ2.Grids.Grid.html#Syncfusion_EJ2_Grids_Grid_AllowPaging), [PageSettings](https://help.syncfusion.com/cr/aspnetcore-js2/Syncfusion.EJ2.Grids.Grid.html#Syncfusion_EJ2_Grids_Grid_PageSettings)   | [AllowPaging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowPaging), [PageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PageSettings)    |
| Filtering API   | [AllowFiltering](https://help.syncfusion.com/cr/aspnetcore-js2/Syncfusion.EJ2.Grids.Grid.html#Syncfusion_EJ2_Grids_Grid_AllowFiltering)   | [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowFiltering)                      |
| Grouping API  | [AllowGrouping](https://help.syncfusion.com/cr/aspnetcore-js2/Syncfusion.EJ2.Grids.Grid.html#Syncfusion_EJ2_Grids_Grid_AllowGrouping)      | [AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowGrouping)          |
| Lifecycle    | `OnGet`, `OnPost`  | `OnInitialized() / OnInitializedAsync()`  |
| Component Reference   | Model binding / helpers  | `@ref`    |

#### Component configuration for DataGrid

**Razor Pages approach**

The Razor Pages [DataGrid](https://www.syncfusion.com/aspnet-core-ui-controls/grid) binds a dataset from the `PageModel` and defines [columns](https://help.syncfusion.com/cr/aspnetcore-js2/Syncfusion.EJ2.Grids.Grid.html#Syncfusion_EJ2_Grids_Grid_Columns) using helper configuration in the view.

{% tabs %}
{% highlight cshtml tabtitle="Index.cshtml" %}

@page
@model IndexModel
@{
    ViewData["Title"] = "Home page";
}

<div class="text-center">
    <ejs-grid id="Grid" dataSource="@Model.Orders" allowPaging="true" allowSorting="true" allowFiltering="true" allowGrouping="true">
        <e-grid-pagesettings pageSize="5"></e-grid-pagesettings>
        <e-grid-columns>
            <e-grid-column field="OrderID" headerText="Order ID" textAlign="Right" width="120"></e-grid-column>
            <e-grid-column field="CustomerID" headerText="Customer ID"  width="150"></e-grid-column>
            <e-grid-column field="OrderDate" headerText="Order Date" width="130" textAlign="Right" format="yMd"></e-grid-column>
            <e-grid-column field="ShipCountry" headerText="Ship Country" width="120"></e-grid-column>
        </e-grid-columns>
    </ejs-grid>
</div>

{% endhighlight %}

{% highlight cs tabtitle="Index.cshtml.cs" %}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GridSample.Pages
{
    public class IndexModel : PageModel
    {
        public List<OrdersDetails> Orders { get; set; } = new();
        public void OnGet()
        {
            if (Orders.Count == 0)
            {
                int code = 10000;
                for (int i = 1; i < 5; i++)
                {
                    Orders.Add(new OrdersDetails(code + 1, "ALFKI", i + 7, 2.3 * i, false, new DateTime(1991, 05, 15), "Berlin", "Simons bistro", "Denmark", new DateTime(1996, 7, 16), "Kirchgasse 6"));
                    Orders.Add(new OrdersDetails(code + 2, "ANATR", i + 2, 3.3 * i, true, new DateTime(1990, 04, 04), "Madrid", "Queen Cozinha", "Brazil", new DateTime(1996, 9, 11), "Avda. Azteca 123"));
                    Orders.Add(new OrdersDetails(code + 3, "ANTON", i + 1, 4.3 * i, true, new DateTime(1957, 11, 30), "Cholchester", "Frankenversand", "Germany", new DateTime(1996, 10, 7), "Carrera 52 con Ave. Bolivar #65-98 Llano Largo"));
                    Orders.Add(new OrdersDetails(code + 4, "BLONP", i + 3, 5.3 * i, false, new DateTime(1930, 10, 22), "Marseille", "Ernst Handel", "Austria", new DateTime(1996, 12, 30), "Magazinweg 7"));
                    Orders.Add(new OrdersDetails(code + 5, "BOLID", i + 4, 6.3 * i, true, new DateTime(1953, 02, 18), "Tsawassen", "Hanari Carnes", "Switzerland", new DateTime(1997, 12, 3), "1029 - 12th Ave. S."));
                    code += 5;
                }
            }    
        }
    }
    public class OrdersDetails
    {
        public OrdersDetails()
        {

        }
        public OrdersDetails(int OrderID, string CustomerId, int EmployeeId, double Freight, bool Verified, DateTime OrderDate, string ShipCity, string ShipName, string ShipCountry, DateTime ShippedDate, string ShipAddress)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerId;
            this.EmployeeID = EmployeeId;
            this.Freight = Freight;
            this.ShipCity = ShipCity;
            this.Verified = Verified;
            this.OrderDate = OrderDate;
            this.ShipName = ShipName;
            this.ShipCountry = ShipCountry;
            this.ShippedDate = ShippedDate;
            this.ShipAddress = ShipAddress;
        }
        public int? OrderID { get; set; }
        public string? CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public double? Freight { get; set; }
        public string? ShipCity { get; set; }
        public bool Verified { get; set; }
        public DateTime OrderDate { get; set; }
        public string? ShipName { get; set; }
        public string? ShipCountry { get; set; }
        public DateTime ShippedDate { get; set; }
        public string? ShipAddress { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

**Blazor approach**

The [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) component binds to a local collection and declares [columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Columns) with `<GridColumn>` elements, enabling direct control through component state.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@page "/"
@using Syncfusion.Blazor.Grids

<h3>Orders Grid</h3>

<SfGrid DataSource="@Orders" TValue="OrdersDetails"
        AllowPaging="true"
        AllowSorting="true"
        AllowFiltering="true"
        AllowGrouping="true" >

    <GridPageSettings PageSize="5"></GridPageSettings>

    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="CustomerID" HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field="OrderDate" HeaderText="Order Date" Format="yMd" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field="ShipCountry" HeaderText="Ship Country" Width="120"></GridColumn>
    </GridColumns>

</SfGrid>

@code {

    public List<OrdersDetails> Orders { get; set; } = new();

    protected override void OnInitialized()
    {
       
        int code = 10000;

        for (int i = 1; i < 5; i++)
        {
            Orders.Add(new OrdersDetails(code + 1, "ALFKI", i + 7, 2.3 * i, false, new DateTime(1991, 05, 15), "Berlin", "Simons bistro", "Denmark", new DateTime(1996, 7, 16), "Kirchgasse 6"));
            Orders.Add(new OrdersDetails(code + 2, "ANATR", i + 2, 3.3 * i, true, new DateTime(1990, 04, 04), "Madrid", "Queen Cozinha", "Brazil", new DateTime(1996, 9, 11), "Avda. Azteca 123"));
            Orders.Add(new OrdersDetails(code + 3, "ANTON", i + 1, 4.3 * i, true, new DateTime(1957, 11, 30), "Cholchester", "Frankenversand", "Germany", new DateTime(1996, 10, 7), "Carrera 52 con Ave. Bolivar #65-98 Llano Largo"));
            Orders.Add(new OrdersDetails(code + 4, "BLONP", i + 3, 5.3 * i, false, new DateTime(1930, 10, 22), "Marseille", "Ernst Handel", "Austria", new DateTime(1996, 12, 30), "Magazinweg 7"));
            Orders.Add(new OrdersDetails(code + 5, "BOLID", i + 4, 6.3 * i, true, new DateTime(1953, 02, 18), "Tsawassen", "Hanari Carnes", "Switzerland", new DateTime(1997, 12, 3), "1029 - 12th Ave. S."));

            code += 5;
        }
    }

    public class OrdersDetails
    {
        public OrdersDetails() { }

        public OrdersDetails(int OrderID, string CustomerId, int EmployeeId, double Freight,
            bool Verified, DateTime OrderDate, string ShipCity, string ShipName,
            string ShipCountry, DateTime ShippedDate, string ShipAddress)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerId;
            this.EmployeeID = EmployeeId;
            this.Freight = Freight;
            this.Verified = Verified;
            this.OrderDate = OrderDate;
            this.ShipCity = ShipCity;
            this.ShipName = ShipName;
            this.ShipCountry = ShipCountry;
            this.ShippedDate = ShippedDate;
            this.ShipAddress = ShipAddress;
        }

        public int? OrderID { get; set; }
        public string? CustomerID { get; set; }
        public int? EmployeeID { get; set; }
        public double? Freight { get; set; }
        public string? ShipCity { get; set; }
        public bool Verified { get; set; }
        public DateTime OrderDate { get; set; }
        public string? ShipName { get; set; }
        public string? ShipCountry { get; set; }
        public DateTime ShippedDate { get; set; }
        public string? ShipAddress { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

### Migrate to Blazor Scheduler component

The [ASP.NET Core Razor Pages Scheduler](https://www.syncfusion.com/aspnet-core-ui-controls/scheduler), is a fully featured event calendar component that helps users manage their time efficiently. The [Blazor Scheduler](https://www.syncfusion.com/scheduler-sdk/blazor-scheduler) is a flexible and high-performance event calendar component built for managing time-based data and resources in Blazor applications.

For detailed guidance, refer to the [Blazor Scheduler getting started guide](https://blazor.syncfusion.com/documentation/scheduler/getting-started-with-server-app) and the [ASP.NET Core Razor Scheduler getting started guide](https://ej2.syncfusion.com/aspnetcore/documentation/schedule/getting-started).

| Aspect         | Razor Pages (`<ejs-schedule>`)     | Blazor (`SfSchedule<TValue>`)        |
| --- | --- | --- |
| Package (NuGet)   | [Syncfusion.EJ2.AspNet.Core](https://www.nuget.org/packages/Syncfusion.EJ2.AspNet.Core)   | [Syncfusion.Blazor.Schedule](https://www.nuget.org/packages/Syncfusion.Blazor.Schedule) |
| Component declaration | `<ejs-schedule>`   | `<SfSchedule TValue="T">`    |
| Data binding   | Data via `PageModel`    | `ScheduleEventSettings DataSource="@..."`   |
| Appointment model  | Model classes mapped in server  | Strongly typed model in component    |
| Views configuration  | [CurrentView](https://help.syncfusion.com/cr/aspnetcore-js2/Syncfusion.EJ2.Schedule.Schedule.html#Syncfusion_EJ2_Schedule_Schedule_CurrentView) property   | [ScheduleView](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleView.html) collection   |
| Lifecycle & refs | `OnGet`, handlers  | `OnInitialized` / `OnInitializedAsync`, `@ref` |

#### Component configuration for Scheduler

**Razor Pages approach**

The Razor Pages [Scheduler](https://www.syncfusion.com/aspnet-core-ui-controls/scheduler) renders appointments supplied from the `PageModel` using schedule [EventSettings](https://help.syncfusion.com/cr/aspnetcore-js2/Syncfusion.EJ2.Schedule.Schedule.html#Syncfusion_EJ2_Schedule_Schedule_EventSettings).

{% tabs %}
{% highlight cshtml tabtitle="Index.cshtml" %}

@page
@model IndexModel
@{
    ViewData["Title"] = "Home page";
}

<div class="text-center">
    <ejs-schedule id="schedule" height="550"
                  selectedDate="@(new DateTime(2026, 6, 15))">
        <e-schedule-eventsettings dataSource="@Model.Appointments">
        </e-schedule-eventsettings>

    </ejs-schedule>
</div>

{% endhighlight %}

{% highlight cs tabtitle="Index.cshtml.cs" %}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ScheduleSample.Pages
{
    public class IndexModel : PageModel
    {
        public List<AppointmentData> Appointments { get; set; } = new();

        public void OnGet()
        {
            Appointments = new List<AppointmentData>
            {
                new AppointmentData { Id = 1, Subject = "Explosion of Betelgeuse Star", StartTime = new DateTime(2026, 6, 11, 9, 30, 0), EndTime = new DateTime(2026, 6, 11, 11, 0, 0) },
                new AppointmentData { Id = 2, Subject = "Thule Air Crash Report", StartTime = new DateTime(2026, 6, 12, 12, 0, 0), EndTime = new DateTime(2026, 6, 12, 14, 0, 0) },
                new AppointmentData { Id = 3, Subject = "Blue Moon Eclipse", StartTime = new DateTime(2026, 6, 13, 9, 30, 0), EndTime = new DateTime(2026, 6, 13, 11, 0, 0) },
                new AppointmentData { Id = 4, Subject = "Meteor Showers in 2026", StartTime = new DateTime(2026, 6, 14, 13, 0, 0), EndTime = new DateTime(2026, 6, 14, 14, 30, 0) },
                new AppointmentData { Id = 5, Subject = "Milky Way as Melting pot", StartTime = new DateTime(2026, 6, 15, 12, 0, 0), EndTime = new DateTime(2026, 6, 15, 14, 0, 0) }
            };
        }
    }
    public class AppointmentData
    {
        public int Id { get; set; }
        public string? Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

**Blazor approach**

The [Blazor Scheduler](https://www.syncfusion.com/scheduler-sdk/blazor-scheduler) uses [ScheduleEventSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEventSettings-1.html) to bind a local event list, allowing the component to handle updates internally.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@page "/"
@using Syncfusion.Blazor.Schedule

<h3>Schedule</h3>

<SfSchedule TValue="AppointmentData"
            Height="550px"
            SelectedDate="@(new DateTime(2026, 6, 15))">
    <ScheduleEventSettings DataSource="@Appointments"></ScheduleEventSettings>
</SfSchedule>

@code {

    public List<AppointmentData> Appointments { get; set; } = new();

    protected override void OnInitialized()
    {
        Appointments = new List<AppointmentData>
        {
            new AppointmentData
            {
                Id = 1,
                Subject = "Explosion of Betelgeuse Star",
                StartTime = new DateTime(2026, 6, 11, 9, 30, 0),
                EndTime = new DateTime(2026, 6, 11, 11, 0, 0)
            },
            new AppointmentData
            {
                Id = 2,
                Subject = "Thule Air Crash Report",
                StartTime = new DateTime(2026, 6, 12, 12, 0, 0),
                EndTime = new DateTime(2026, 6, 12, 14, 0, 0)
            },
            new AppointmentData
            {
                Id = 3,
                Subject = "Blue Moon Eclipse",
                StartTime = new DateTime(2026, 6, 13, 9, 30, 0),
                EndTime = new DateTime(2026, 6, 13, 11, 0, 0)
            },
            new AppointmentData
            {
                Id = 4,
                Subject = "Meteor Showers in 2026",
                StartTime = new DateTime(2026, 6, 14, 13, 0, 0),
                EndTime = new DateTime(2026, 6, 14, 14, 30, 0)
            },
            new AppointmentData
            {
                Id = 5,
                Subject = "Milky Way as Melting pot",
                StartTime = new DateTime(2026, 6, 15, 12, 0, 0),
                EndTime = new DateTime(2026, 6, 15, 14, 0, 0)
            }
        };
    }

    public class AppointmentData
    {
        public int Id { get; set; }
        public string? Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

### Migrate to Blazor Rich Text Editor component

The [ASP.NET Core Razor Pages Rich Text Editor](https://www.syncfusion.com/aspnet-core-ui-controls/wysiwyg-rich-text-editor) is a feature-rich WYSIWYG HTML editor and WYSIWYG Markdown editor. [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-rich-text-editor) provides a modern, feature rich component for building interactive and dynamic text editing user interfaces.

For detailed guidance, refer to the [Blazor Rich Text Editor getting started guide](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started-with-server-app) and the [ASP.NET Core Razor Rich Text Editor getting started guide](https://ej2.syncfusion.com/aspnetcore/documentation/rich-text-editor/getting-started).

| Aspect   | Razor Pages (`<ejs-richtexteditor>`)  | Blazor (`SfRichTextEditor`)  |
| --- | --- | --- |
| Package (NuGet)       | [Syncfusion.EJ2.AspNet.Core](https://www.nuget.org/packages/Syncfusion.EJ2.AspNet.Core) | [Syncfusion.Blazor.RichTextEditor](https://www.nuget.org/packages/Syncfusion.Blazor.RichTextEditor) |
| Component declaration | `<ejs-richtexteditor>` | `<SfRichTextEditor>` |
| Content binding       | `Value` set via `PageModel` | `@bind-Value`  |
| Toolbar configuration | [RichTextEditorToolbarSettings](https://help.syncfusion.com/cr/aspnetcore-js2/Syncfusion.EJ2.RichTextEditor.RichTextEditorToolbarSettings.html)   | [RichTextEditorToolbarSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorToolbarSettings.html)  |
| Theming & assets | Scripts/styles in layout | CSS + `AddSyncfusionBlazor()` |
| Lifecycle & refs  | `OnGet`, handlers     | `OnInitialized[Async]`, `@ref` |

#### Component configuration for Rich Text Editor

**Razor Pages approach**

The Razor Pages [Rich Text Editor](https://www.syncfusion.com/aspnet-core-ui-controls/wysiwyg-rich-text-editor) configures toolbar options and content directly within the view markup.

{% tabs %}
{% highlight cshtml tabtitle="Index.cshtml" %}
@page
@model IndexModel
@{
    ViewData["Title"] = "Home page";
    var image = new[] {
        "Replace", "Align", "Caption", "Remove", "InsertLink", "OpenImageLink", "-",
        "EditImageLink", "RemoveImageLink", "Display", "AltText", "Dimension"
            };
    var tools = new[] {
        "Bold", "Italic", "Underline", "StrikeThrough",
        "FontName", "FontSize", "FontColor", "BackgroundColor",
        "LowerCase", "UpperCase", "|",
        "Formats", "Alignments", "OrderedList", "UnorderedList",
        "Outdent", "Indent", "|",
        "CreateLink", "Image", "CreateTable", "|", "ClearFormat", "Print",
        "SourceCode", "FullScreen", "|", "Undo", "Redo"
            };
}

<div class="text-center">
    <ejs-richtexteditor id="image">
        <e-richtexteditor-quicktoolbarsettings image="image"></e-richtexteditor-quicktoolbarsettings>
        <e-richtexteditor-toolbarsettings items="tools"></e-richtexteditor-toolbarsettings>
        <e-content-template>
            <p>
                The Rich Text Editor control is a WYSIWYG ('what you see is what you get') editor that provides the best user experience to create and update the content.
                Users can format their content using standard toolbar commands.
            </p>
            <p><b>Key features:</b></p>
            <ul>
                <li><p>Provides &lt; IFRAME &gt; and &lt; DIV &gt; modes </p></li>
                <li><p>Capable of handling markdown editing.</p></li>
                <li><p>Contains a modular library to load the necessary functionality on demand.</p></li>
                <li><p>Provides a fully customizable toolbar.</p></li>
                <li><p>Provides HTML view to edit the source directly for developers.</p></li>
                <li><p>Allows preview of modified content before saving it.</p></li>
                <li><p>Handles images, hyperlinks, video, uploads, etc.</p></li>
                <li><p>Contains undo / redo manager.</p></li>
                <li><p>Creates bulleted and numbered lists.</p></li>
            </ul>
        </e-content-template>
    </ejs-richtexteditor>
</div>
{% endhighlight %}

{% highlight cs tabtitle="Index.cshtml.cs" %}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RichTextEditorSample.Pages
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {

        }
    }
}

{% endhighlight %}
{% endtabs %}

**Blazor approach**

The [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-rich-text-editor) binds editor content to a variable and configures tools using component settings for interactive editing.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@page "/"
@using Syncfusion.Blazor.RichTextEditor

<h3>Rich Text Editor</h3>

<SfRichTextEditor @bind-Value="EditorContent">
    <RichTextEditorToolbarSettings Items="@ToolbarItems"></RichTextEditorToolbarSettings>
</SfRichTextEditor>

@code {

    private object[] ToolbarItems = new object[]
    {
        "Bold", "Italic", "Underline", "StrikeThrough", "|",
        "FontName", "FontSize", "FontColor", "BackgroundColor", "|",
        "LowerCase", "UpperCase", "|",
        "Formats", "Alignments", "OrderedList", "UnorderedList", "|",
        "Outdent", "Indent", "|",
        "CreateLink", "Image", "CreateTable", "|",
        "ClearFormat", "Print", "SourceCode", "FullScreen", "|",
        "Undo", "Redo"
    };

    private string EditorContent { get; set; } = @"
        <p>
            The Rich Text Editor control is a WYSIWYG editor that provides the best experience to create content.
        </p>
        <p><b>Key features:</b></p>
        <ul>
            <li>IFRAME and DIV modes</li>
            <li>Markdown editing</li>
            <li>Custom toolbar</li>
            <li>Source code editing</li>
            <li>Undo / Redo support</li>
        </ul>
    ";
}

{% endhighlight %}
{% endtabs %}

## Run the application

Press <kbd>Ctrl</kbd> + <kbd>F5</kbd> (Windows) or <kbd>⌘</kbd> + <kbd>F5</kbd> (macOS) to launch the application.

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

