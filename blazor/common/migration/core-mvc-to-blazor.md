---
layout: post
title: Migrating Syncfusion ASP.NET Core MVC to Blazor | Syncfusion
description: Learn how to migrate Syncfusion ASP.NET Core MVC controls to Blazor components, including key concepts and a detailed migration approach.
platform: Blazor
control: Common
documentation: ug
---

# Migrating Syncfusion® ASP.NET Core MVC Controls to Blazor

Migrating enterprise applications from **ASP.NET Core MVC** to **Blazor** represents a transition from a controller driven, request response framework to a modern, component based web UI model built on .NET. This guide provides a **structured, step-by-step migration path** for [Syncfusion® ASP.NET Core MVC controls](https://www.syncfusion.com/aspnet-mvc-ui-controls) to their [Syncfusion® Blazor equivalents](https://www.syncfusion.com/blazor-components).

## Why migrate from ASP.NET Core MVC to Blazor?

ASP.NET Core MVC applications rely on **server-side request handling**, **partial views**, and **AJAX callbacks** to update UI content. While this architecture is robust and well established, it can become increasingly complex to manage as applications grow more interactive and UI logic becomes distributed across controllers, views, and client scripts.

Blazor replaces the traditional request response interaction model with **event driven UI updates**, enables **reusable components**, and aligns closely with modern .NET development practices. Blazor provides a modern alternative for applications that require rich interactivity and component driven UI patterns, making it a strong choice for long term application modernization.

| Aspect | ASP.NET Core MVC | Blazor |
| --- | --- | --- |
| **Execution model** | Stateless request response | Blazor Web App (Server / WebAssembly / Auto render modes) |
| **UI technology** | Razor Views (`.cshtml`) with HTML and Tag Helpers | Razor components (`.razor`) with HTML and C# |
| **UI definition** | Views and partial views | Component based UI structure |
| **Code structure** | Controllers and ViewModels | `@code {}` block or `.razor.cs` file |
| **Lifecycle model** | Request based (per HTTP request) | Component lifecycle (`OnInitialized`, `OnParametersSet`, `OnAfterRender`, `Dispose`) |
| **State management** | TempData, ViewData, Session | Component state, cascading parameters, and DI services |
| **User interaction** | Full page reload or AJAX callback | Event driven UI updates |
| **Event handling** | Form post and AJAX | `EventCallback<T>` and delegates |
| **Dependency injection** | Built-in (controller centric) | Built-in (component centric) |
| **Routing and navigation** | Controller based routing | SPA style routing using `@page` |
| **Scalability** | Depends on server request handling | Depends on hosting model (Server: connection based, WASM: client-side scalable) |
| **Application updates** | Requires redeployment | Blazor Server: Instant updates. WebAssembly: Requires client refresh/version update |

## Development Environment Setup

### Prerequisites

* [.NET 8 SDK or later](https://dotnet.microsoft.com/en-us/download/dotnet)
* [Visual Studio](https://visualstudio.microsoft.com/downloads/) 2022 or later, or [Visual Studio Code](https://code.visualstudio.com/) with [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension

Verify installation using the following .NET CLI command, and ensure the .NET version is 8.0.0 or later.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet --version
dotnet --info

{% endhighlight %}
{% endtabs %}

### Project structure comparison

The following table maps common **ASP.NET Core MVC application artifacts** to their **Blazor equivalents**, highlighting how application structure transitions from a controller centric model to a component based architecture.

| Concept                 | ASP.NET Core MVC artifact      | Blazor equivalent                          |
| ----------------------- | ------------------------------ | ------------------------------------------ |
| **UI definition**       | Razor Views (`Views/*.cshtml`) | Razor components (`Pages/*.razor`)         |
| **Controller logic**    | `Controllers/*.cs`             | Component code (`@code {}` or `.razor.cs`) |
| **Application startup** | `Program.cs` (MVC middleware)  | `Program.cs` (Razor components)            |
| **Layout**              | `_Layout.cshtml`               | `App.razor`      |
| **Reusable UI**         | Partial Views                  | Razor child components                     |
| **Static assets**       | `wwwroot`                      | `wwwroot`          |
| **State handling**      | TempData / ViewData / Session  | Component fields and injected services     |
| **Routing**             | `MapControllerRoute`, attributes | `@page` directive        |
| **Business & data layer**  | Models, Services, Repositories |  Reused via dependency injection |

N> Existing domain models, data access layers, and business services can typically be reused in Blazor. However, code tightly coupled to MVC features such as controllers, HttpContext, or TempData may require refactoring.

## Creating a Blazor project

### Creating a Blazor Web App with Interactive Server

For ASP.NET Core MVC migrations, create a **Blazor Web App with Interactive Server** option, which runs server-side and preserves the familiar server hosted execution model with real time interactivity via SignalR.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet new blazor -n MyBlazorApp --interactivity Server
cd MyBlazorApp

{% endhighlight %}
{% endtabs %}

N> The `--interactivity Server` flag configures SignalR based interactivity providing immediate UI updates.

## Migrating Syncfusion® Components from ASP.NET Core MVC to Blazor

The following shared setup applies to all Syncfusion components and covers the common configuration required before proceeding to the [component specific migration steps](#add-syncfusion-datagrid-component).

### Package installation

Use the following commands to install the required packages for each component.

| Component | ASP.NET Core MVC packages | Blazor packages |
|---|---|---|
| DataGrid | [Syncfusion.EJ2.AspNet.Core](https://www.nuget.org/packages/Syncfusion.EJ2.AspNet.Core) |[Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid)  |
| Scheduler | [Syncfusion.EJ2.AspNet.Core](https://www.nuget.org/packages/Syncfusion.EJ2.AspNet.Core) | [Syncfusion.Blazor.Schedule](https://www.nuget.org/packages/Syncfusion.Blazor.Schedule) |
| RichTextEditor | [Syncfusion.EJ2.AspNet.Core](https://www.nuget.org/packages/Syncfusion.EJ2.AspNet.Core) | [Syncfusion.Blazor.RichTextEditor](https://www.nuget.org/packages/Syncfusion.Blazor.RichTextEditor) |
| Themes | — | [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes) |

N> Install `Syncfusion.Blazor.Themes` once at the application level. This package is required for the Blazor components used in this migration guide.

### Service registration

ASP.NET Core MVC initializes Syncfusion controls as part of the view rendering lifecycle. There is no dependency injection based service registration model for UI components. Instead, controls are made available through script and style references, along with the required `ScriptManager` configuration in the layout.

Blazor uses dependency injection (DI) from the ground up. Syncfusion components must be registered in the service container. So, the framework can resolve rendering engines, localization providers, and JavaScript interop services required for each component to function correctly.

In the `Program.cs` file, add the Syncfusion namespace and register services.

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

In ASP.NET Core MVC, namespaces are imported into Razor views using `~/_ViewImports.cshtml`, primarily to enable Tag Helpers and HTML helper extensions.

Add the Syncfusion namespace in `~/_ViewImports.cshtml`.

{% tabs %}
{% highlight cshtml tabtitle="~/_ViewImports.cshtml" %}

@using WebApplication1
@using WebApplication1.Models
@using Syncfusion.EJ2
@addTagHelper *, Microsoft.AspNetCore.Mvc.TagHelpers

{% endhighlight %}
{% endtabs %}

In Blazor, `~/_Imports.razor` serves a similar purpose but applies to Razor components. It allows components to access namespaces globally without requiring repeated `@using` statements in each `.razor` file.

Import the required Syncfusion namespaces in the `~/_Imports.razor` file.

| Component | Required namespaces |
|---|---|
| DataGrid | `@using Syncfusion.Blazor`<br>`@using Syncfusion.Blazor.Grids` |
| Scheduler | `@using Syncfusion.Blazor`<br>`@using Syncfusion.Blazor.Schedule` |
| RichTextEditor | `@using Syncfusion.Blazor`<br>`@using Syncfusion.Blazor.RichTextEditor` |

### Theme and script configuration

In ASP.NET Core MVC, Syncfusion scripts and styles are manually referenced in the shared layout (`_Layout.cshtml`). In addition, Syncfusion components require the `@Html.EJS().ScriptManager()` helper, which initializes the required JavaScript components at runtime.

In Blazor, scripts and styles are provided as static web assets from the NuGet package and are typically referenced once at the application level (for example, in `App.razor`). This centralized approach avoids duplication, ensures consistent theming, and simplifies dependency management.

**ASP.NET Core MVC approach:**

{% tabs %}
{% highlight html tabtitle="_Layout.cshtml" %}

<head>
    ...
    <!-- Syncfusion ASP.NET Core controls styles -->
    <link rel="stylesheet" href="https://cdn.syncfusion.com/ej2/{{ site.releaseversion }}/material.css" />
    <!-- Syncfusion ASP.NET Core controls scripts -->
    <script src="https://cdn.syncfusion.com/ej2/{{ site.releaseversion }}/dist/ej2.min.js"></script>
</head>

{% endhighlight %}
{% endtabs %}

Also, register the script manager `EJS().ScriptManager()` at the end of `<body>` in the `~/Views/Shared/_Layout.cshtml` file as follows.

{% tabs %}
{% highlight cshtml tabtitle="~/_Layout.cshtml" %}

<body>
    ...
    <!-- Syncfusion Script Manager -->
    @Html.EJS().ScriptManager()
</body>

{% endhighlight %}
{% endtabs %}

**Blazor equivalent:**

{% tabs %}
{% highlight html tabtitle="App.razor" %}

<head>
    ...
    <!-- Syncfusion theme stylesheet -->
    <link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
    ...
</head>
<body>
    ...
    <!-- Syncfusion Blazor core script (required for UI components) -->
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js"></script>
    ...
</body>

{% endhighlight %}
{% endtabs %}

### Add Syncfusion® DataGrid component

**Migration overview**

For detailed explanation, refer to the [ASP.NET Core MVC DataGrid getting started guide](https://ej2.syncfusion.com/aspnetcore/documentation/grid/getting-started-core) and [Blazor DataGrid getting started guide](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-server-app).

| Aspect         | MVC (`Grid` - ASP.NET Core wrappers)         | Blazor (`SfGrid / SfGrid<TValue>`)                |
| -------- | --------- | ---------- |
| **Package (NuGet)**       | [Syncfusion.EJ2.AspNet.Core](https://www.nuget.org/packages/Syncfusion.EJ2.AspNet.Core/) | [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid) |
| **Namespace** | Views: Tag Helpers / HTML Helpers (`@addTagHelper`, `@using`) | Razor: `@using Syncfusion.Blazor.Grids` |
| **Component declaration** | HTML Helper (`@Html.EJS().Grid()`)                         | Razor component (`<SfGrid>`)                      |
| **Data binding**          | Model, ViewBag, or remote data via `DataManager`     | Bound to component state (`@DataSource`)                |
| **Collection type**       | Server-side models (`IEnumerable`, ViewModel)              | `List<>` / `IEnumerable<>`                |
| **Events & interactions** | Client-side events     | `EventCallback<>` based handlers                 |
| **UI refresh**            | Client-side rendering       | Automatic (component re-rendering)                      |
| **Columns** | Defined using (`Columns(...)`) | `<GridColumn Field="..." HeaderText="..." />` |
| **Editing & API** | [EditSettings](https://help.syncfusion.com/cr/aspnetcore-js2/Syncfusion.EJ2.Grids.Grid.html#Syncfusion_EJ2_Grids_Grid_EditSettings) | [EditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EditSettings), [GridEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html), `@ref` async APIs |
| **Theming & assets** | Scripts and styles in `_Layout.cshtml` | Static web assets via `_content`, service registration (`AddSyncfusionBlazor`) |
| **Paging / virtualization** |[AllowPaging](https://help.syncfusion.com/cr/aspnetcore-js2/Syncfusion.EJ2.Grids.Grid.html#Syncfusion_EJ2_Grids_Grid_AllowPaging), [PageSettings](https://help.syncfusion.com/cr/aspnetcore-js2/Syncfusion.EJ2.Grids.Grid.html#Syncfusion_EJ2_Grids_Grid_PageSettings), [EnableVirtualization](https://help.syncfusion.com/cr/aspnetcore-js2/Syncfusion.EJ2.Grids.Grid.html#Syncfusion_EJ2_Grids_Grid_EnableVirtualization) | [AllowPaging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowPaging), [PageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PageSettings), [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableVirtualization) |
| **Filtering** | [AllowFiltering](https://help.syncfusion.com/cr/aspnetcore-js2/Syncfusion.EJ2.Grids.Grid.html#Syncfusion_EJ2_Grids_Grid_AllowFiltering) | [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowFiltering)  |
| **Grouping** | [AllowGrouping](https://help.syncfusion.com/cr/aspnetcore-js2/Syncfusion.EJ2.Grids.Grid.html#Syncfusion_EJ2_Grids_Grid_AllowGrouping), [GroupSettings](https://help.syncfusion.com/cr/aspnetcore-js2/Syncfusion.EJ2.Grids.Grid.html#Syncfusion_EJ2_Grids_Grid_GroupSettings)  | [AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowGrouping), [GroupSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GroupSettings) |
| **Lifecycle & refs** | Controller actions, model binding, HTTP lifecycle | `OnInitialized[Async]`, DI, `@ref`, component lifecycle |

**Component rendering**

In ASP.NET Core MVC, the DataGrid is declared using HTML helper methods in the view and bound to a model returned from the controller.

In Blazor, the DataGrid is defined as a Razor component and bound to an in-memory data collection. The data is initialized within the component, and the UI updates automatically when the data changes during user interaction.

**MVC approach:**

{% tabs %}
{% highlight cshtml %}

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

**Blazor equivalent:**

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/grid"
@using Syncfusion.Blazor.Grids
@rendermode InteractiveServer

<SfGrid DataSource="@orderData">
    <GridColumns>
        <GridColumn Field="@nameof(OrdersDetails.OrderID)" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field="@nameof(OrdersDetails.CustomerID)" HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field="@nameof(OrdersDetails.ShipCity)" HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field="@nameof(OrdersDetails.ShipName)" HeaderText="Ship Name" Width="120"></GridColumn>
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
}

{% endhighlight %}
{% endtabs %}

**Key differences**

The key difference is that MVC follows a request based model. Data is passed from the controller to the view. In contrast, Blazor uses a stateful, component driven approach. Data is maintained within the component, and the UI updates dynamically without requiring full page reloads.

### Add Syncfusion® Scheduler component

**Migration overview**

For detailed explanation, refer to the [ASP.NET Core MVC Scheduler getting started guide](https://ej2.syncfusion.com/aspnetcore/documentation/schedule/getting-started) and [Blazor Scheduler getting started guide](https://blazor.syncfusion.com/documentation/scheduler/getting-started-with-server-app).

| Aspect                    | MVC (`Schedule` – ASP.NET Core wrappers)     | Blazor (`SfSchedule<TValue>`)                         |
| ------------------------- | -------------------------------------------- | ----------------------------------------------------- |
| **Package (NuGet)**       | [Syncfusion.EJ2.AspNet.Core](https://www.nuget.org/packages/Syncfusion.EJ2.AspNet.Core)                   | [Syncfusion.Blazor.Schedule](https://www.nuget.org/packages/Syncfusion.Blazor.Schedule)                           |
| **Namespace**             | Views: `@using Syncfusion.EJ2`               | Razor: `@using Syncfusion.Blazor.Schedule`            |
| **Component declaration** | HTML Helper (`@Html.EJS().Schedule()`)       | Razor component (`<SfSchedule TValue="T">`)           |
| **Appointment model**     | [EventSettings](https://help.syncfusion.com/cr/aspnetcore-js2/Syncfusion.EJ2.Schedule.Schedule.html#Syncfusion_EJ2_Schedule_Schedule_EventSettings)   | [ScheduleEventSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEventSettings-1.html)                              |
| **Views configuration**   | [CurrentView](https://help.syncfusion.com/cr/aspnetcore-js2/Syncfusion.EJ2.Schedule.Schedule.html#Syncfusion_EJ2_Schedule_Schedule_CurrentView), [Views](https://help.syncfusion.com/cr/aspnetcore-js2/Syncfusion.EJ2.Schedule.Schedule.html#Syncfusion_EJ2_Schedule_Schedule_Views)     | [`<ScheduleViews>`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleView.html) collection                          |
| **Events & interactions** | AJAX callbacks to controller actions         | `EventCallback<>`, component events                   |
| **State management**      | Stateless (per request)                      | Stateful component instance                           |
| **UI refresh**            | AJAX refresh or full reload                  | Automatic component re-rendering                      |
| **Theming & assets**      | CSS/JS + `ScriptManager` in `_Layout.cshtml` | Static assets via `_content`, service registration (`AddSyncfusionBlazor`) |
| **Lifecycle & refs**      | Controller lifecycle, HTTP requests          | `OnInitialized[Async]`, DI, `@ref` APIs               |

**Component rendering**

In ASP.NET Core MVC, the Scheduler is defined using an HTML helper in the view and configured with data provided from the controller using `ViewBag`.

In Blazor, the Scheduler is defined as a Razor component and bound to an in-memory data collection. The data is maintained within the component, allowing it to persist and update dynamically during user interaction.

**ASP.NET Core MVC approach**

{% tabs %}
{% highlight cshtml %}

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

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/schedule"

@using Syncfusion.Blazor.Schedule
@rendermode InteractiveServer

<SfSchedule TValue="Meeting" Height="650px">
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

N> The event class (`Meeting`) uses default field names expected by the Scheduler. Custom property names can be mapped using the `Fields` property in `ScheduleEventSettings`.

**Key differences**

The key difference is that MVC follows a request based model. Data is passed from the controller to the view and rendered on each request. In contrast, Blazor uses a stateful, component driven approach. Data is stored in the component, and the UI updates automatically without full page reloads.

### Add Syncfusion® Rich Text Editor component

**Migration overview**

For detailed explanation, refer to the [ASP.NET Core MVC Rich Text Editor getting started guide](https://ej2.syncfusion.com/aspnetcore/documentation/rich-text-editor/getting-started) and [Blazor Rich Text Editor getting started guide](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started-with-server-app).

| Aspect                    | MVC (`RichTextEditor` – ASP.NET Core wrappers) | Blazor (`SfRichTextEditor`)                                    |
| ---------- | ------ | --------- |
| **Package (NuGet)**       | [Syncfusion.EJ2.AspNet.Core](https://www.nuget.org/packages/Syncfusion.EJ2.AspNet.Core)                     | [Syncfusion.Blazor.RichTextEditor](https://www.nuget.org/packages/Syncfusion.Blazor.RichTextEditor)                               |
| **Namespace**             | Views: `@using Syncfusion.EJ2`                 | Razor: `@using Syncfusion.Blazor.RichTextEditor`               |
| **Component declaration** | HTML Helper (`@Html.EJS().RichTextEditor()`)   | Razor component (`<SfRichTextEditor>`)                         |
| **Content binding**       | Model, ViewBag, or form post (`Value`)         | `Value` / `@bind-Value` bound to component state               |
| **Toolbar configuration** | [ToolbarSettings](https://help.syncfusion.com/cr/aspnetcore-js2/Syncfusion.EJ2.RichTextEditor.RichTextEditor.html#Syncfusion_EJ2_RichTextEditor_RichTextEditor_ToolbarSettings)               | [`<RichTextEditorToolbarSettings>`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorToolbarSettings.html) with predefined/custom items |
| **Events & interactions** | Form post or AJAX callbacks                    | `EventCallback<>` and component events                         |
| **State management**      | Stateless (per request)                        | Stateful component instance                                    |
| **Theming & assets**      | CSS/JS + `ScriptManager` in `_Layout.cshtml`   | Static assets via `_content`, service registration (`AddSyncfusionBlazor`)         |
| **Lifecycle & refs**      | Controller lifecycle, HTTP requests            | `OnInitialized[Async]`, DI, `@ref` APIs                        |

**Component rendering**

In ASP.NET Core MVC, the Rich Text Editor is defined using an HTML helper in the view and its value is set using `ViewBag` from the controller.

In Blazor, the Rich Text Editor is defined as a Razor component and its value is bound to a variable using two way binding. The content is managed within the component and persists during user interactions.

**ASP.NET Core MVC approach**

{% tabs %}
{% highlight cshtml %}

@using Syncfusion.EJ2

@Html.EJS().RichTextEditor("editor").Value(ViewBag.Value).Render()

{% endhighlight %}

{% highlight c# tabtitle="HomeController.cs" %}

using Microsoft.AspNetCore.Mvc;

public class HomeController : Controller
{
    public ActionResult Index()
    {
        ViewBag.Value = @"<p>Welcome to Syncfusion Rich Text Editor</p>";
        return View();
    }
}

{% endhighlight %}
{% endtabs %}

**Blazor equivalent**

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@page "/rte"
@using Syncfusion.Blazor.RichTextEditor
@rendermode InteractiveServer

<SfRichTextEditor @bind-Value="Content" Height="400px"></SfRichTextEditor>

@code {
    private string Content = "<p>Welcome to Syncfusion Rich Text Editor</p>";
}

{% endhighlight %}
{% endtabs %}


**Key differences**

The key difference is that ASP.NET Core MVC follows a request based model. The editor content is provided from the controller.

In contrast, Blazor uses a stateful, component driven approach. The content is maintained within the component and updates automatically through data binding without requiring full page reloads.

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
