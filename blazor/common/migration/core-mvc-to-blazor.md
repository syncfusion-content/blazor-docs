---
layout: post
title: Migrating ASP.NET Core MVC to Blazor | Syncfusion
description: Learn how to migrate ASP.NET Core MVC controls to Blazor components, including key concepts and a detailed migration approach.
platform: Blazor
control: Common
documentation: ug
---

# Migrating ASP.NET Core MVC Controls to Blazor

Migrating enterprise applications from [ASP.NET Core MVC](https://learn.microsoft.com/en-us/aspnet/core/mvc/overview) to [Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/) represents a transition from a controller driven, request response framework to a modern, component based web UI model built on .NET. This guide provides a step-by-step migration path for [ASP.NET Core MVC controls](https://www.syncfusion.com/aspnet-mvc-ui-controls) to their [Blazor equivalents](https://www.syncfusion.com/blazor-components).

## Why migrate from ASP.NET Core MVC to Blazor?

[ASP.NET Core MVC](https://learn.microsoft.com/en-us/aspnet/core/mvc/overview) applications follow a request response model, where user requests are handled by controllers and rendered using views. UI updates often require full page reloads or additional techniques such as partial views or AJAX, which can increase complexity as applications become more interactive.

[Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/) introduces a component based, event driven UI model, where user interactions trigger updates directly within components rather than full page reloads. It enables reusable UI components and aligns closely with modern .NET development practices.

| Aspect | ASP.NET Core MVC | Blazor |
| --- | --- | --- |
| Execution model | Stateless request response | Blazor Web App (Server / WebAssembly / Auto render modes) |
| UI technology | Razor Views (`.cshtml`) with HTML and Tag Helpers | Razor components (`.razor`) with HTML and C# |
| Code structure | Controllers and ViewModels | `@code {}` block or `.razor.cs` file |
| Lifecycle model | Request based (per HTTP request) | Component lifecycle (`OnInitialized`, `OnParametersSet`, `OnAfterRender`, `Dispose`) |
| State management | Stateless and session based options | Component state, cascading parameters, and DI services |
| User interaction | Full page reload or AJAX callback | Event driven UI updates |
| Event handling | Form post and AJAX | `EventCallback<T>` and delegates |
| Dependency injection | Built-in (controller centric) | Built-in (component centric) |
| Routing and navigation | Controller based routing | SPA style routing using `@page` |
| Scalability | Limited by concurrent requests and vertical scaling typical | Server: scales to concurrent SignalR connections. WebAssembly: client-side execution eliminates server load |
| Application updates | Requires redeployment | Blazor Server: Live UI updates over SignalR. WebAssembly: Requires page refresh after redeployment. |

## Prerequisites for Blazor

* [.NET 8 SDK or later](https://dotnet.microsoft.com/en-us/download/dotnet)
* [Visual Studio](https://visualstudio.microsoft.com/downloads/) 2022 or later, or [Visual Studio Code](https://code.visualstudio.com/) with [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension

## Project structure comparison

The following table maps common [ASP.NET Core MVC](https://learn.microsoft.com/en-us/aspnet/core/mvc/overview) application artifacts to their [Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/) equivalents, highlighting how application structure transitions from a request driven model to a component based architecture.

| Concept  | ASP.NET Core MVC artifact  | Blazor equivalent      |
| -----| ------ | ----- |
| UI definition  | Razor Views (`Views/*.cshtml`) | Razor components (`Components/Pages/*.razor`)  |
| Request handling logic    | `Controllers/*.cs`  | Component code (`@code {}` or `.razor.cs`) |
| Application startup | `Program.cs` (MVC middleware)  | `Program.cs` (Blazor hosting & services)            |
| Layout              | `_Layout.cshtml`   | `MainLayout.razor`      |
| Reusable UI         | Partial Views | Razor components                     |
| Static assets       | `wwwroot`     | `wwwroot`          |
| State handling      | TempData / ViewData / Session  |  Component state, cascading values, DI services     |
| Routing    | `MapControllerRoute`, attributes | `@page` directive        |
| Business & data layer  | Models, Services, Repositories |  Reused via dependency injection |

## Migrating Components from ASP.NET Core MVC to Blazor

Create a [Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/) project using one of the following getting started guides.

* [Getting Started with Blazor Web App](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)
* [Getting Started with Blazor Server App](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)
* [Getting Started with Blazor WebAssembly App](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)

The following shared setup applies to all components and covers the common configuration required before proceeding to the [component specific migration steps](#component-specific-migration-steps).

### Package installation

In [ASP.NET Core MVC](https://learn.microsoft.com/en-us/aspnet/core/mvc/overview), controls are typically installed using a single combined package, such as [Syncfusion.EJ2.AspNet.Core](https://www.nuget.org/packages/Syncfusion.EJ2.AspNet.Core). 

In [Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/) applications, using individual component packages improves performance and reduces application size. For the complete list of available packages, refer to the [Blazor NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages).

Additionally, install the [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes) NuGet package for styling support.

### Service registration

In [ASP.NET Core MVC](https://learn.microsoft.com/en-us/aspnet/core/mvc/overview), UI components are rendered as part of the view, and additional scripts and styles are included manually. There is no  dependency injection (DI) based registration model specifically for UI components.

In [Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/), components rely on the built-in dependency injection (DI) system. UI libraries like Syncfusion must be registered in the service container so that required services (such as rendering, localization, and [JavaScript interop](https://learn.microsoft.com/en-us/aspnet/core/blazor/javascript-interoperability/?view=aspnetcore-10.0)) are available to components.

In the `Program.cs` file, add the Blazor namespace and register services.

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

### Add import namespaces

**ASP.NET Core MVC approach**

Namespaces are imported into Razor views using `~/_ViewImports.cshtml`, primarily to enable Tag Helpers and HTML helper extensions.

{% tabs %}
{% highlight cshtml tabtitle="~/_ViewImports.cshtml" %}

@using WebApplication1
@using WebApplication1.Models
@using Syncfusion.EJ2
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers

{% endhighlight %}
{% endtabs %}

**Blazor equivalent**

In [Blazor](https://learn.microsoft.com/en-us/aspnet/core/blazor/), `~/_Imports.razor` serves a similar purpose but applies to Razor components. It allows components to access namespaces globally without requiring repeated `@using` statements in each `.razor` file.

Import the required namespaces in the `~/_Imports.razor` file.

{% tabs %}
{% highlight razor tabtitle="_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Schedule
@using Syncfusion.Blazor.RichTextEditor

{% endhighlight %}
{% endtabs %}

The preceding code sample lists the namespaces for all components covered in this guide. Import only the namespaces required for the components you use.

### Theme and script configuration

**ASP.NET Core MVC approach**

Scripts and styles are manually referenced in the shared layout (`_Layout.cshtml`). In addition, controls require the `@Html.EJS().ScriptManager()` helper, which initializes the required JavaScript controls at runtime.

{% tabs %}
{% highlight html tabtitle="_Layout.cshtml" %}

<head>
    ...
    <!-- ASP.NET Core MVC controls styles -->
    <link rel="stylesheet" href="https://cdn.syncfusion.com/ej2/{{ site.releaseversion }}/fluent2.css" />
    <!-- ASP.NET Core MVC controls scripts -->
    <script src="https://cdn.syncfusion.com/ej2/{{ site.releaseversion }}/dist/ej2.min.js"></script>
</head>

{% endhighlight %}
{% endtabs %}

Also, register the script manager `EJS().ScriptManager()` at the end of `<body>` in the `~/Views/Shared/_Layout.cshtml` file as follows.

{% tabs %}
{% highlight cshtml tabtitle="~/_Layout.cshtml" %}

<body>
    ...
    <!-- Script Manager -->
    @Html.EJS().ScriptManager()
</body>

{% endhighlight %}
{% endtabs %}

**Blazor equivalent**

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the [stylesheet](https://blazor.syncfusion.com/documentation/appearance/themes) and [script references](https://blazor.syncfusion.com/documentation/common/adding-script-references) in the **App.razor** file.

{% tabs %}
{% highlight html tabtitle="App.razor" %}

<head>
    ...
    <!-- Theme stylesheet -->
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
    ...
</head>
<body>
    ...
    <!-- Blazor component script (required for UI components) -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"></script>
    ...
</body>

{% endhighlight %}
{% endtabs %}

## Component specific migration steps

### Migrate to Blazor DataGrid component

[ASP.NET Core MVC DataGrid](https://www.syncfusion.com/aspnet-mvc-ui-controls/grid) uses HTML helpers for rendering data, while [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) provides a modern, feature rich component for building interactive data-driven user interfaces.

For additional details, refer to the [Blazor DataGrid getting started guide](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-server-app) and [ASP.NET Core MVC DataGrid getting started guide](https://ej2.syncfusion.com/aspnetmvc/documentation/grid/getting-started-mvc).

| Aspect | MVC (`Grid` - ASP.NET Core wrappers)   | Blazor (`SfGrid / SfGrid<TValue>`) |
| -------- | --------- | ---------- |
| Package (NuGet)       | [Syncfusion.EJ2.AspNet.Core](https://www.nuget.org/packages/Syncfusion.EJ2.AspNet.Core/) | [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid) |
| Namespace | Views: Tag Helpers / HTML Helpers (`@addTagHelper`, `@using`) | Razor: `@using Syncfusion.Blazor.Grids` |
| Component declaration | HTML Helper (`@Html.EJS().Grid()`)                         | Razor component (`<SfGrid>`)                      |
| Data binding | Model / ViewBag / DataManager | Bound to component property (`DataSource="@..."`) |
| Collection type       | Server-side models (`IEnumerable`, ViewModel)              | `List<>` / `IEnumerable<>`                |
| Events & interactions | JavaScript based client events | `EventCallback<T>` and async handlers |
| UI refresh            | Client-side rendering       | Automatic (component re-rendering)                      |
| Columns | Defined using (`.Columns(col => { ... })`) | `<GridColumn Field="..." HeaderText="..." />` |
| Editing & API | [EditSettings](https://help.syncfusion.com/cr/aspnetmvc-js2/Syncfusion.EJ2.Grids.Grid.html#Syncfusion_EJ2_Grids_Grid_EditSettings) | [EditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EditSettings), [GridEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html), `@ref` async APIs |
| Paging / virtualization API |[AllowPaging](https://help.syncfusion.com/cr/aspnetmvc-js2/Syncfusion.EJ2.Grids.Grid.html#Syncfusion_EJ2_Grids_Grid_AllowPaging), [PageSettings](https://help.syncfusion.com/cr/aspnetmvc-js2/Syncfusion.EJ2.Grids.Grid.html#Syncfusion_EJ2_Grids_Grid_PageSettings), [EnableVirtualization](https://help.syncfusion.com/cr/aspnetmvc-js2/Syncfusion.EJ2.Grids.Grid.html#Syncfusion_EJ2_Grids_Grid_EnableVirtualization) | [AllowPaging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowPaging), [PageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PageSettings), [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization) |
| Filtering API | [AllowFiltering](https://help.syncfusion.com/cr/aspnetmvc-js2/Syncfusion.EJ2.Grids.Grid.html#Syncfusion_EJ2_Grids_Grid_AllowFiltering) | [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowFiltering)  |
| Grouping API | [AllowGrouping](https://help.syncfusion.com/cr/aspnetmvc-js2/Syncfusion.EJ2.Grids.Grid.html#Syncfusion_EJ2_Grids_Grid_AllowGrouping), [GroupSettings](https://help.syncfusion.com/cr/aspnetmvc-js2/Syncfusion.EJ2.Grids.Grid.html#Syncfusion_EJ2_Grids_Grid_GroupSettings)  | [AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowGrouping), [GroupSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GroupSettings) |
| Lifecycle & refs | Controller actions, model binding, HTTP lifecycle | `OnInitialized[Async]`, DI, `@ref`, component lifecycle |

#### Component configuration for DataGrid

**MVC approach**

The [ASP.NET Core MVC DataGrid](https://www.syncfusion.com/aspnet-mvc-ui-controls/grid) is defined using HTML Helper APIs, where [Columns](https://help.syncfusion.com/cr/aspnetmvc-js2/Syncfusion.EJ2.Grids.Grid.html#Syncfusion_EJ2_Grids_Grid_Columns) are configured through properties during component initialization.

{% tabs %}
{% highlight cshtml tabtitle="Index.cshtml" %}

@(Html.EJS().Grid("Grid").DataSource((IEnumerable<object>)Model).Columns(col =>
{
    col.Field("OrderID").HeaderText("Order ID").Width("120").TextAlign(Syncfusion.EJ2.Grids.TextAlign.Right).Add();
    col.Field("CustomerID").HeaderText("Customer Name").Width("150").Add();
    col.Field("OrderDate").HeaderText("Order Date").Width("130").TextAlign(Syncfusion.EJ2.Grids.TextAlign.Right).Format("yMd").Add();
    col.Field("ShipCountry").HeaderText("Ship Country").Width("120").Add();
}).Render())

{% endhighlight %}

{% highlight cs tabtitle="HomeController.cs" %}

public class HomeController : Controller
{
    public ActionResult Index()
    {
        return View(OrdersDetails.GetAllRecords());
    }
}
public class OrdersDetails
{
    public static List<OrdersDetails> order = new List<OrdersDetails>();
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
    public static List<OrdersDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            int code = 10000;
            for (int i = 1; i < 5; i++)
            {
                order.Add(new OrdersDetails(code + 1, "ALFKI", i + 0, 2.3 * i, false, new DateTime(1991, 05, 15), "Berlin", "Simons bistro", "Denmark", new DateTime(1996, 7, 16), "Kirchgasse 6"));
                order.Add(new OrdersDetails(code + 2, "ANATR", i + 2, 3.3 * i, true, new DateTime(1990, 04, 04), "Madrid", "Queen Cozinha", "Brazil", new DateTime(1996, 9, 11), "Avda. Azteca 123"));
                order.Add(new OrdersDetails(code + 3, "ANTON", i + 1, 4.3 * i, true, new DateTime(1957, 11, 30), "Cholchester", "Frankenversand", "Germany", new DateTime(1996, 10, 7), "Carrera 52 con Ave. Bolívar #65-98 Llano Largo"));
                order.Add(new OrdersDetails(code + 4, "BLONP", i + 3, 5.3 * i, false, new DateTime(1930, 10, 22), "Marseille", "Ernst Handel", "Austria", new DateTime(1996, 12, 30), "Magazinweg 7"));
                order.Add(new OrdersDetails(code + 5, "BOLID", i + 4, 6.3 * i, true, new DateTime(1953, 02, 18), "Tsawassen", "Hanari Carnes", "Switzerland", new DateTime(1997, 12, 3), "1029 - 12th Ave. S."));
                code += 5;
            }
        }
        return order;
    }
    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public int? EmployeeID { get; set; }
    public double? Freight { get; set; }
    public string ShipCity { get; set; }
    public bool Verified { get; set; }
    public DateTime OrderDate { get; set; }
    public string ShipName { get; set; }
    public string ShipCountry { get; set; }
    public DateTime ShippedDate { get; set; }
    public string ShipAddress { get; set; }
}

{% endhighlight %}

{% endtabs %}

**Blazor equivalent**

The [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) component is defined in Razor markup, and its structure is built using declarative [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Columns) while binding to data through the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/grid"
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@orderData" TValue="OrdersDetails">
  <GridColumns>
    <GridColumn Field="@nameof(OrdersDetails.OrderID)" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    <GridColumn Field="@nameof(OrdersDetails.CustomerID)" HeaderText="Customer Name" Width="150"></GridColumn>
    <GridColumn Field="@nameof(OrdersDetails.OrderDate)" HeaderText="Order Date" Format="yMd" TextAlign="TextAlign.Right" Width="130"></GridColumn>
    <GridColumn Field="@nameof(OrdersDetails.ShipCountry)" HeaderText="Ship Country" Width="120"></GridColumn>
  </GridColumns>
</SfGrid>

@code {
    private List<OrdersDetails> orderData = new();

    protected override void OnInitialized()
    {
        orderData = OrdersDetails.GetAllRecords();
    }
    public class OrdersDetails
    {
        public static List<OrdersDetails> order = new List<OrdersDetails>();
        
        public static List<OrdersDetails> GetAllRecords()
        {
            if (order.Count == 0)
            {
                int code = 10000;
                for (int i = 1; i < 5; i++)
                {
                    order.Add(new OrdersDetails { OrderID = code + 1, CustomerID = "ALFKI", EmployeeID = i + 0, Freight = 2.3 * i, Verified = false, OrderDate = new DateTime(1991, 05, 15), ShipCity = "Berlin", ShipName =  "Simons bistro", ShipCountry = "Denmark", ShippedDate = new DateTime(1996, 7, 16), ShipAddress = "Kirchgasse 6" });
                    order.Add(new OrdersDetails { OrderID = code + 2, CustomerID = "ANATR", EmployeeID = i + 2, Freight = 3.3 * i, Verified = true, OrderDate = new DateTime(1990, 04, 04), ShipCity = "Madrid", ShipName = "Queen Cozinha", ShipCountry = "Brazil", ShippedDate = new DateTime(1996, 9, 11), ShipAddress = "Avda. Azteca 123" });
                    order.Add(new OrdersDetails { OrderID = code + 3, CustomerID = "ANTON", EmployeeID = i + 1, Freight = 4.3 * i, Verified = true, OrderDate = new DateTime(1957, 11, 30), ShipCity = "Cholchester", ShipName = "Frankenversand", ShipCountry = "Germany", ShippedDate = new DateTime(1996, 10, 7), ShipAddress = "Carrera 52 con Ave. Bolívar #65-98 Llano Largo" });
                    order.Add(new OrdersDetails { OrderID = code + 4, CustomerID = "BLONP", EmployeeID = i + 3, Freight = 5.3 * i, Verified = false, OrderDate = new DateTime(1930, 10, 22), ShipCity = "Marseille", ShipName = "Ernst Handel", ShipCountry = "Austria", ShippedDate = new DateTime(1996, 12, 30), ShipAddress = "Magazinweg 7" });
                    order.Add(new OrdersDetails { OrderID = code + 5, CustomerID = "BOLID", EmployeeID = i + 4, Freight = 6.3 * i, Verified = true, OrderDate = new DateTime(1953, 02, 18), ShipCity = "Tsawassen", ShipName = "Hanari Carnes", ShipCountry = "Switzerland", ShippedDate = new DateTime(1997, 12, 3), ShipAddress = "1029 - 12th Ave. S." });
                    code += 5;
                }
            }
            return order;
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

The [ASP.NET Core MVC Scheduler](https://www.syncfusion.com/aspnet-mvc-ui-controls/scheduler) is a comprehensive event calendar for managing time-based activities, while  [Blazor Scheduler](https://www.syncfusion.com/scheduler-sdk/blazor-scheduler) provides a modern, high performance component for building interactive scheduling user interfaces.

For detailed explanation, refer to the [Blazor Scheduler getting started guide](https://blazor.syncfusion.com/documentation/scheduler/getting-started-with-server-app) and [ASP.NET Core MVC Scheduler getting started guide](https://ej2.syncfusion.com/aspnetmvc/documentation/schedule/getting-started).

| Aspect   | MVC (`Schedule` – ASP.NET Core wrappers)     | Blazor (`SfSchedule<TValue>`)      |
| ---- | ----- | ---- |
| Package (NuGet)       | [Syncfusion.EJ2.AspNet.Core](https://www.nuget.org/packages/Syncfusion.EJ2.AspNet.Core)                   | [Syncfusion.Blazor.Schedule](https://www.nuget.org/packages/Syncfusion.Blazor.Schedule)                           |
| Namespace             |  `@using Syncfusion.EJ2`               |  `@using Syncfusion.Blazor.Schedule`            |
| Component declaration | HTML Helper (`@Html.EJS().Schedule()`)       | Razor component (`<SfSchedule TValue="T">`)           |
| Appointment model API    | [EventSettings](https://help.syncfusion.com/cr/aspnetmvc-js2/Syncfusion.EJ2.Schedule.Schedule.html#Syncfusion_EJ2_Schedule_Schedule_EventSettings)   | [ScheduleEventSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEventSettings-1.html)                              |
| Views configuration API | [CurrentView](https://help.syncfusion.com/cr/aspnetmvc-js2/Syncfusion.EJ2.Schedule.Schedule.html#Syncfusion_EJ2_Schedule_Schedule_CurrentView), [Views](https://help.syncfusion.com/cr/aspnetmvc-js2/Syncfusion.EJ2.Schedule.Schedule.html#Syncfusion_EJ2_Schedule_Schedule_Views)     | [`<ScheduleViews>`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleView.html) collection                          |
| Events & interactions | Client-side events with optional server calls (AJAX) | `EventCallback<T>` and component events |
| State management      | Stateless (per request)                      | Stateful component instance                           |
| UI refresh            | AJAX refresh or full reload                  | Automatic component re-rendering                      |
| Lifecycle & refs      | Controller lifecycle, HTTP requests          | `OnInitialized[Async]`, DI, `@ref` APIs               |

#### Component configuration for Scheduler

**ASP.NET Core MVC approach**

The [ASP.NET Core MVC Scheduler](https://www.syncfusion.com/aspnet-mvc-ui-controls/scheduler) is configured with [Views](https://help.syncfusion.com/cr/aspnetmvc-js2/Syncfusion.EJ2.Schedule.Schedule.html#Syncfusion_EJ2_Schedule_Schedule_Views) options such as Day, Week, and Month, and [EventSettings](https://help.syncfusion.com/cr/aspnetmvc-js2/Syncfusion.EJ2.Schedule.Schedule.html#Syncfusion_EJ2_Schedule_Schedule_EventSettings) are applied to control how appointments are displayed and managed.

{% tabs %}
{% highlight cshtml tabtitle="Index.cshtml" %}

@using Syncfusion.EJ2

<div>
    @(Html.EJS().Schedule("Schedule")
        .Height("650px")
        .CurrentView(Syncfusion.EJ2.Schedule.View.Week)
        .EventSettings(e => e.DataSource(ViewBag.Meeting))
        .Render())
</div>

{% endhighlight %}

{% highlight c# tabtitle="HomeController.cs" %}

using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.Meeting = new List<Meeting>
        {
            new Meeting
            {
                Id = 1,
                Subject = "Meeting",
                StartTime = DateTime.Now,
                EndTime = DateTime.Now.AddHours(1)
            }
        };

        return View();
    }
}

public class Meeting
{
    public int Id { get; set; }
    public string Subject { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
}

{% endhighlight %}
{% endtabs %}

**Blazor equivalent**

The [Blazor Scheduler](https://www.syncfusion.com/blazor-components/blazor-scheduler) component defines views using the [ScheduleViews](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleViews.html) collection and binds event data through [ScheduleEventSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEventSettings-1.html) to handle appointments within the component.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/schedule"

@using Syncfusion.Blazor.Schedule

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
        public string? Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

N> The `Meeting` class uses the default property names expected by the Scheduler. If your data uses different field names, you can map them using the `Fields` property in `ScheduleEventSettings`.

### Migrate to Blazor Rich Text Editor component

The [ASP.NET Core MVC Rich Text Editor](https://www.syncfusion.com/aspnet-mvc-ui-controls/wysiwyg-rich-text-editor) is a feature-rich WYSIWYG HTML and Markdown editor, while [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-rich-text-editor) provides a modern, feature rich component for building interactive and dynamic text editing user interfaces.

For detailed explanation, refer to the [Blazor Rich Text Editor getting started guide](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started-with-server-app) and [ASP.NET Core MVC Rich Text Editor getting started guide](https://ej2.syncfusion.com/aspnetmvc/documentation/rich-text-editor/getting-started).

| Aspect        | MVC (`RichTextEditor` – ASP.NET Core wrappers) | Blazor (`SfRichTextEditor`)    |
| ---------- | ------ | --------- |
| Package (NuGet)       | [Syncfusion.EJ2.AspNet.Core](https://www.nuget.org/packages/Syncfusion.EJ2.AspNet.Core)                     | [Syncfusion.Blazor.RichTextEditor](https://www.nuget.org/packages/Syncfusion.Blazor.RichTextEditor)                               |
| Namespace             |  `@using Syncfusion.EJ2`                 |`@using Syncfusion.Blazor.RichTextEditor`               |
| Component declaration | HTML Helper (`@Html.EJS().RichTextEditor()`)   | Razor component (`<SfRichTextEditor>`)                         |
| Content binding       | Model, ViewBag, or form post (`Value`)         | [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_Value) / `@bind-Value` bound to component state               |
| Toolbar configuration | [ToolbarSettings](https://help.syncfusion.com/cr/aspnetmvc-js2/Syncfusion.EJ2.RichTextEditor.RichTextEditor.html#Syncfusion_EJ2_RichTextEditor_RichTextEditor_ToolbarSettings)               | [`<RichTextEditorToolbarSettings>`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorToolbarSettings.html) with predefined/custom items |
| Events & interactions | Form post or AJAX callbacks                    | `EventCallback<>` and component events                         |
| State management      | Stateless (per request)                        | Stateful component instance                                    |
| Lifecycle & refs      | Controller lifecycle, HTTP requests            | `OnInitialized[Async]`, DI, `@ref` APIs                        |

#### Component configuration for Rich Text Editor

**ASP.NET Core MVC approach**

The [ASP.NET Core MVC Rich Text Editor](https://www.syncfusion.com/aspnet-mvc-ui-controls/wysiwyg-rich-text-editor) is initialized with configurable [ToolbarSettings](https://help.syncfusion.com/cr/aspnetmvc-js2/Syncfusion.EJ2.RichTextEditor.RichTextEditor.html#Syncfusion_EJ2_RichTextEditor_RichTextEditor_ToolbarSettings) and supports content formatting through predefined tools and customization options.

{% tabs %}
{% highlight cshtml tabtitle="Index.cshtml" %}

@using Syncfusion.EJ2

@Html.EJS().RichTextEditor("editor").Value(ViewBag.Value).Render()

{% endhighlight %}

{% highlight c# tabtitle="HomeController.cs" %}

using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public ActionResult Index()
    {
        ViewBag.Value = @"<p>Welcome to Rich Text Editor</p>";
        return View();
    }
}

{% endhighlight %}
{% endtabs %}

**Blazor equivalent**

The [Blazor Rich Text Editor](https://www.syncfusion.com/blazor-components/blazor-rich-text-editor) component is defined in Razor markup, where content is managed using the [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.SfRichTextEditor.html#Syncfusion_Blazor_RichTextEditor_SfRichTextEditor_Value) or `@bind-Value` property and toolbar items can be customized declaratively.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/rte"
@using Syncfusion.Blazor.RichTextEditor

<SfRichTextEditor @bind-Value="Content" Height="400px"></SfRichTextEditor>

@code {
    private string Content = "<p>Welcome to Blazor Rich Text Editor</p>";
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

* [Getting started with Blazor Server App](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio)
* [Getting started with Blazor DataGrid](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-server-app)
* [Getting started with Blazor Scheduler](https://blazor.syncfusion.com/documentation/scheduler/getting-started-with-server-app)
* [Getting started with Blazor Rich Text Editor](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started-with-server-app)
