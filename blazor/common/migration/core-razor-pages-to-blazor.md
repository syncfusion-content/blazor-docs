---
layout: post
title: Migrating Syncfusion ASP.NET Core Razor Pages to Blazor | Syncfusion
description: Learn how to migrate Syncfusion ASP.NET Core Razor Pages controls to Blazor components, including key concepts and a detailed migration approach.
platform: Blazor
control: Common
documentation: ug
---

# Migrating Syncfusion® ASP.NET Core Razor Pages Controls to Blazor

Migrating applications from **ASP.NET Core Razor Pages** to **Blazor** represents a shift from a page centric, request response model to a modern, component based UI framework built on .NET. This guide explains how to migrate commonly used [Syncfusion® ASP.NET Core Razor page controls](https://www.syncfusion.com/aspnet-core-ui-controls) to their [Syncfusion® Blazor equivalents](https://www.syncfusion.com/blazor-components).

## Why migrate from ASP.NET Core Razor Pages to Blazor?

ASP.NET Core Razor Pages simplify the MVC pattern by combining UI and logic at the page level. However, for highly interactive applications, developers often rely on **JavaScript**, **partial rendering**, and additional client-side logic to manage dynamic UI behavior.

Blazor provides a modern approach by enabling **component based UI development in C#**, along with built-in **state management** and **event driven updates**. This reduces dependency on external JavaScript frameworks and improves maintainability, scalability, and developer productivity.

The following table highlights the key architectural and functional differences between Razor Pages and Blazor.

| Aspect     | Razor Pages      | Blazor         |
| --- | ---| --- |
| **Execution model**           | Request response (page based)              | Blazor Server (SignalR) or WebAssembly (client-side)                     |
| **Hosting & deployment**      | IIS, Azure App Service                     | Cloud, containers, IIS, static hosting (WASM)                            |
| **UI technology**             | `.cshtml` Razor Pages                      | Razor components (`.razor`)                                              |
| **UI definition**             | Page + PageModel (`.cshtml`, `.cshtml.cs`) | Component based (`.razor` with optional `.razor.cs`)                     |
| **Lifecycle model**           | `OnGet`, `OnPost`, handler methods         | `OnInitialized{Async}`, `OnParametersSet{Async}`, `OnAfterRender{Async}` |
| **State management**          | PageModel, TempData, Session               | Component state (in-memory), DI services                                 |
| **User interaction**          | Page reload or partial updates with JS     | Event driven UI updates without reload                                   |
| **Event handling**            | Handler methods (`OnPost`, form submit)    | `EventCallback<T>`, C# delegates                                         |
| **Dependency injection**      | Supported via constructor injection        | Built-in and deeply integrated                                           |
| **Navigation model**          | File based routing (`Pages/*.cshtml`)      | SPA style routing using `@page`                                          |
| **Rendering model**           | Server rendered HTML with optional JS      | Interactive rendering (real time or client-side)                         |
| **Component reuse**           | Limited (partials, tag helpers)            | Strong component reusability                                             |
| **JavaScript dependency**     | Often required for interactivity           | Minimal (optional via JS interop)                                        |
| **Testing & maintainability** | Moderate                                   | Improved due to component isolation                                      |
| **Scalability**               | Depends on server rendering                | Supports modern, scalable architectures                                  |

## Development environment setup

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

## Project Structure Comparison

ASP.NET Core Razor Pages and Blazor Web Apps follow different architectural patterns. The following table shows the functional equivalents between Razor Pages artifacts and Blazor, along with their roles in a Blazor Web App.

| Razor Pages Artifact                     | Blazor Web App Equivalent        | Description           |
| --- | --- | --- |
| `Pages/*.cshtml`                         | `Components/Pages/*.razor`                             | Defines the UI page and route entry point               |
| `.cshtml.cs` (PageModel)                 | `@code {}` block or `.razor.cs` file                   | Contains page logic, event handling, and data binding   |
| `_Layout.cshtml`                         | `MainLayout.razor`                                     | Provides shared layout structure across pages           |
| Partial Pages                            | Razor components (`.razor`)                            | Enables reusable UI components                          |
| File based routing                       | `@page` directive                                      | Defines routes directly in components                   |
| `wwwroot`                                | `wwwroot`                                              | Stores static files like CSS, JS, and images            |
| PageModel state (`TempData`, `ViewData`) | Component state (fields/properties)                    | Maintains UI state within the component                 |
| Handler methods (`OnGet`, `OnPost`)      | Lifecycle methods (`OnInitialized`, `OnParametersSet`) | Controls execution flow and data initialization         |
| JavaScript based updates                 | Event driven UI updates (C#)                           | Handles user interaction without page reload            |
| Services / Models                        | Reused via DI (Dependency Injection)                   | Shares business logic and data access across components |

N> Business logic, EF Core models, and services from Razor Pages can be reused directly in Blazor without modification.

## Creating a Blazor project

### Creating a Blazor Web App with Interactive Server

For ASP.NET Core Razor migrations, create a **Blazor Web App with Interactive Server** option, which runs server-side and preserves the familiar server hosted execution model with real time interactivity via SignalR.

{% tabs %}
{% highlight bash tabtitle=".NET CLI" %}

dotnet new blazor -n MyBlazorApp --interactivity Server
cd MyBlazorApp

{% endhighlight %}
{% endtabs %}

N> The `--interactivity Server` flag configures SignalR based interactivity providing immediate UI updates.

## Migrating Syncfusion® Components from ASP.NET Core Razor pages to Blazor

The following shared setup applies to all Syncfusion components and covers the common configuration required before proceeding to the [component specific migration steps](#add-syncfusion-datagrid-component).

### Package installation

Use the following commands to install the required packages for each component.

| Component | ASP.NET Core Razor packages | Blazor packages |
|---|---|---|
| DataGrid | [Syncfusion.EJ2.AspNet.Core](https://www.nuget.org/packages/Syncfusion.EJ2.AspNet.Core) | [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid)  |
| Scheduler | [Syncfusion.EJ2.AspNet.Core](https://www.nuget.org/packages/Syncfusion.EJ2.AspNet.Core) | [Syncfusion.Blazor.Schedule](https://www.nuget.org/packages/Syncfusion.Blazor.Schedule) |
| RichTextEditor | [Syncfusion.EJ2.AspNet.Core](https://www.nuget.org/packages/Syncfusion.EJ2.AspNet.Core) | [Syncfusion.Blazor.RichTextEditor](https://www.nuget.org/packages/Syncfusion.Blazor.RichTextEditor) |
| Themes | — | [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes) |

N> Install `Syncfusion.Blazor.Themes` once at the application level. This package is required for the Blazor components used in this migration guide.

### Service registration

ASP.NET Core Razor initializes Syncfusion controls as part of the view rendering lifecycle. There is no dependency injection based service registration model for UI components. Instead, controls are made available through script and style references, along with the required `ScriptManager` configuration in the layout.

Blazor uses dependency injection (DI) from the ground up. Syncfusion components must be registered in the service container so the framework can resolve rendering engines, localization providers, and JavaScript interop services required for each component to function correctly.

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

In ASP.NET Core Razor, namespaces are imported into Razor views using `~/_ViewImports.cshtml`, primarily to enable Tag Helpers and HTML helper extensions.

Add the `Syncfusion.EJ2` TagHelper in `~/_ViewImports.cshtml`.

{% tabs %}
{% highlight cshtml tabtitle="~/_ViewImports.cshtml" %}

@addTagHelper *, Syncfusion.EJ2

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

In ASP.NET Core Razor, Syncfusion scripts and styles are manually referenced in the shared layout (`_Layout.cshtml`). In addition, Syncfusion components require the `<ejs-script>` helper, which initializes the required JavaScript components at runtime.

In Blazor, scripts and styles are provided as static web assets from the NuGet package and are typically referenced once at the application level (for example, in `App.razor`). This centralized approach avoids duplication, ensures consistent theming, and simplifies dependency management.

**ASP.NET Core Razor approach:**

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

Also, register the script manager `<ejs-script>` at the end of `<body>` in the `~/Pages/Shared/_Layout.cshtml` file as follows.

{% tabs %}
{% highlight cshtml tabtitle="~/_Layout.cshtml" %}

<body>
    ...
    <!-- Syncfusion Script Manager -->
    <ejs-scripts></ejs-scripts>
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

For detailed explanation, refer to the [ASP.NET Core Razor DataGrid getting started guide](https://help.syncfusion.com/aspnet/grid/getting-started) and [Blazor DataGrid getting started guide](https://blazor.syncfusion.com/documentation/datagrid/getting-started-with-server-app).

| Aspect         | Razor Pages (`ejs-grid`)        | Blazor (`SfGrid` / `SfGrid<TValue>`)        |
| --- | --- | --- |
| **Package (NuGet)**       | [Syncfusion.EJ2.AspNet.Core](https://www.nuget.org/packages/Syncfusion.EJ2.AspNet.Core) | [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid) |
| **Component declaration** | `<ejs-grid>` helper in `.cshtml`   | `<SfGrid>` / `<SfGrid TValue="T">`      |
| **Data binding**   | Data passed via `PageModel` (`OnGet`) or `dataSource` property  | `DataSource="@..."` bound in component   |
| **Collection type**   | `IEnumerable<T>` / server-side model  | `List<T>` / `IEnumerable<T>`  |
| **Columns**   | Column builder API   | `<GridColumn>` elements   |
| **Paging**   | [AllowPaging](https://help.syncfusion.com/cr/aspnetcore-js2/Syncfusion.EJ2.Grids.Grid.html#Syncfusion_EJ2_Grids_Grid_AllowPaging), [PageSettings](https://help.syncfusion.com/cr/aspnetcore-js2/Syncfusion.EJ2.Grids.Grid.html#Syncfusion_EJ2_Grids_Grid_PageSettings)   | [AllowPaging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowPaging), [PageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PageSettings)    |
| **Filtering**    | [AllowFiltering](https://help.syncfusion.com/cr/aspnetcore-js2/Syncfusion.EJ2.Grids.Grid.html#Syncfusion_EJ2_Grids_Grid_AllowFiltering)   | [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowFiltering)                      |
| **Grouping**   | [AllowGrouping](https://help.syncfusion.com/cr/aspnetcore-js2/Syncfusion.EJ2.Grids.Grid.html#Syncfusion_EJ2_Grids_Grid_AllowGrouping)      | [AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowGrouping)          |
| **Lifecycle**    | `OnGet`, `OnPost`  | `OnInitialized() / OnInitializedAsync()`  |
| **Component Reference**   | Model binding / helpers  | `@ref`    |
| **Theming & Assets**      | Scripts & CSS in layout   | `AddSyncfusionBlazor()` + theme CSS   |

**Component rendering**

In the Razor Pages approach, the DataGrid is defined using an HTML helper in the `.cshtml` page. The data is provided from the `PageModel` using handler methods like `OnGet`, and it is rendered during the request.

In the Blazor approach, the DataGrid is defined as a Razor component and bound to an in-memory data source. The data is maintained within the component and updated dynamically during user interaction.

**Razor page approach**

{% tabs %}
{% highlight cshtml tabtitle="Index.cshtml" %}

@page
@model IndexModel
@{
    ViewData["Title"] = "Home page";
    List<OrdersDetails> order = new List<OrdersDetails>();
    if (order.Count() == 0)
    {
        int code = 10000;
        for (int i = 1; i < 5; i++)
        {
            order.Add(new OrdersDetails(code + 1, "ALFKI", i + 0, 2.3 * i, false, new DateTime(1991, 05, 15), "Berlin", "Simons bistro", "Denmark", new DateTime(1996, 7, 16), "Kirchgasse 6"));
            order.Add(new OrdersDetails(code + 2, "ANATR", i + 2, 3.3 * i, true, new DateTime(1990, 04, 04), "Madrid", "Queen Cozinha", "Brazil", new DateTime(1996, 9, 11), "Avda. Azteca 123"));
            order.Add(new OrdersDetails(code + 3, "ANTON", i + 1, 4.3 * i, true, new DateTime(1957, 11, 30), "Cholchester", "Frankenversand", "Germany", new DateTime(1996, 10, 7), "Carrera 52 con Ave. Bolivar #65-98 Llano Largo"));
            order.Add(new OrdersDetails(code + 4, "BLONP", i + 3, 5.3 * i, false, new DateTime(1930, 10, 22), "Marseille", "Ernst Handel", "Austria", new DateTime(1996, 12, 30), "Magazinweg 7"));
            order.Add(new OrdersDetails(code + 5, "BOLID", i + 4, 6.3 * i, true, new DateTime(1953, 02, 18), "Tsawassen", "Hanari Carnes", "Switzerland", new DateTime(1997, 12, 3), "1029 - 12th Ave. S."));
            code += 5;
        }
    }
}

<div class="text-center">
    <ejs-grid id="Grid" dataSource="@order" allowPaging="true" allowSorting="true" allowFiltering="true" allowGrouping="true">
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
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

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

**Blazor approach:**

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@page "/"
@using Syncfusion.Blazor.Grids

<h3>Orders Grid</h3>

<SfGrid DataSource="@Orders"
        AllowPaging="true"
        AllowSorting="true"
        AllowFiltering="true"
        AllowGrouping="true">

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
        if (Orders.Count == 0)
        {
            int code = 10000;

            for (int i = 1; i < 5; i++)
            {
                Orders.Add(new OrdersDetails(code + 1, "ALFKI", i + 0, 2.3 * i, false, new DateTime(1991, 05, 15), "Berlin", "Simons bistro", "Denmark", new DateTime(1996, 7, 16), "Kirchgasse 6"));
                Orders.Add(new OrdersDetails(code + 2, "ANATR", i + 2, 3.3 * i, true, new DateTime(1990, 04, 04), "Madrid", "Queen Cozinha", "Brazil", new DateTime(1996, 9, 11), "Avda. Azteca 123"));
                Orders.Add(new OrdersDetails(code + 3, "ANTON", i + 1, 4.3 * i, true, new DateTime(1957, 11, 30), "Cholchester", "Frankenversand", "Germany", new DateTime(1996, 10, 7), "Carrera 52"));
                Orders.Add(new OrdersDetails(code + 4, "BLONP", i + 3, 5.3 * i, false, new DateTime(1930, 10, 22), "Marseille", "Ernst Handel", "Austria", new DateTime(1996, 12, 30), "Magazinweg 7"));
                Orders.Add(new OrdersDetails(code + 5, "BOLID", i + 4, 6.3 * i, true, new DateTime(1953, 02, 18), "Tsawassen", "Hanari Carnes", "Switzerland", new DateTime(1997, 12, 3), "1029 - 12th Ave"));

                code += 5;
            }
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

The key difference is that Razor Pages follows a request based model. In contrast, Blazor uses a stateful, component driven approach. Data is stored within the component, and the UI updates automatically without requiring full page reloads.

### Add Syncfusion® Scheduler component

For detailed explanation, refer to the [ASP.NET Core Razor Scheduler getting started guide](https://ej2.syncfusion.com/aspnetcore/documentation/schedule/getting-started) and [Blazor Scheduler getting started guide](https://blazor.syncfusion.com/documentation/scheduler/getting-started-with-server-app).

**Migration overview**

| Aspect         | Razor Pages (`<ejs-schedule>`)     | Blazor (`SfSchedule<TValue>`)        |
| --- | --- | --- |
| **Package (NuGet)**   | [Syncfusion.EJ2.AspNet.Core](https://www.nuget.org/packages/Syncfusion.EJ2.AspNet.Core)   | [Syncfusion.Blazor.Schedule](https://www.nuget.org/packages/Syncfusion.Blazor.Schedule) |
| **Component declaration** | `<ejs-schedule>`   | `<SfSchedule TValue="T">`    |
| **Data binding**   | Data via `PageModel`    | `ScheduleEventSettings DataSource="@..."`   |
| **Appointment model**  | Model classes mapped in server  | Strongly typed model in component    |
| **Views configuration**  | [CurrentView](https://help.syncfusion.com/cr/aspnetcore-js2/Syncfusion.EJ2.Schedule.Schedule.html#Syncfusion_EJ2_Schedule_Schedule_CurrentView) property   | [<ScheduleView>](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleView.html) collection   |
| **Lifecycle & refs** | `OnGet`, handlers  | `OnInitialized[Async]`, `@ref` |

**Component rendering**

In the Razor Pages approach, the Scheduler is defined using an HTML helper in the `.cshtml` page. The data is provided from the `PageModel` and rendered during the request lifecycle.

In the Blazor approach, the Scheduler is defined as a Razor component and bound to an in-memory collection. This data is maintained within the component and updated dynamically during user interaction.

**Razor pages approach**

{% tabs %}
{% highlight cshtml tabtitle="Index.cshtml" %}

@page
@model IndexModel
@{
    ViewData["Title"] = "Home page";
    List<AppointmentData> appData = new List<AppointmentData>();
    appData.Add(new AppointmentData
    { Id = 1, Subject = "Explosion of Betelgeuse Star", StartTime = new DateTime(2022, 2, 11, 9, 30, 0), EndTime = new DateTime(2022, 2, 11, 11, 0, 0) });
    appData.Add(new AppointmentData
    { Id = 2, Subject = "Thule Air Crash Report", StartTime = new DateTime(2022, 2, 12, 12, 0, 0), EndTime = new DateTime(2022, 2, 12, 14, 0, 0) });
    appData.Add(new AppointmentData
    { Id = 3, Subject = "Blue Moon Eclipse", StartTime = new DateTime(2022, 2, 13, 9, 30, 0), EndTime = new DateTime(2022, 2, 13, 11, 0, 0) });
    appData.Add(new AppointmentData
    { Id = 4, Subject = "Meteor Showers in 2022", StartTime = new DateTime(2022, 2, 14, 13, 0, 0), EndTime = new DateTime(2022, 2, 14, 14, 30, 0) });
    appData.Add(new AppointmentData
    { Id = 5, Subject = "Milky Way as Melting pot", StartTime = new DateTime(2022, 2, 15, 12, 0, 0), EndTime = new DateTime(2022, 2, 15, 14, 0, 0) });
}

<div class="text-center">
    <ejs-schedule id="schedule" height="550" selectedDate="@(new DateTime(2022, 2, 15))">
        <e-schedule-eventsettings dataSource="appData"></e-schedule-eventsettings>
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
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
    public class AppointmentData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

**Blazor approach**

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@page "/"
@using Syncfusion.Blazor.Schedule

<h3>Schedule</h3>

<SfSchedule TValue="AppointmentData"
            Height="550px"
            SelectedDate="new DateTime(2022, 2, 15)">

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
                StartTime = new DateTime(2022, 2, 11, 9, 30, 0),
                EndTime = new DateTime(2022, 2, 11, 11, 0, 0)
            },
            new AppointmentData
            {
                Id = 2,
                Subject = "Thule Air Crash Report",
                StartTime = new DateTime(2022, 2, 12, 12, 0, 0),
                EndTime = new DateTime(2022, 2, 12, 14, 0, 0)
            },
            new AppointmentData
            {
                Id = 3,
                Subject = "Blue Moon Eclipse",
                StartTime = new DateTime(2022, 2, 13, 9, 30, 0),
                EndTime = new DateTime(2022, 2, 13, 11, 0, 0)
            },
            new AppointmentData
            {
                Id = 4,
                Subject = "Meteor Showers in 2022",
                StartTime = new DateTime(2022, 2, 14, 13, 0, 0),
                EndTime = new DateTime(2022, 2, 14, 14, 30, 0)
            },
            new AppointmentData
            {
                Id = 5,
                Subject = "Milky Way as Melting pot",
                StartTime = new DateTime(2022, 2, 15, 12, 0, 0),
                EndTime = new DateTime(2022, 2, 15, 14, 0, 0)
            }
        };
    }

    public class AppointmentData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

**Key differences**

The key difference is that Razor Pages uses a request based model. In contrast, Blazor uses a stateful model. Data persists in memory, and the UI updates automatically without full page reloads.

### Add Syncfusion® Rich Text Editor component

For detailed explanation, refer to the [ASP.NET Core Razor Rich Text Editor getting started guide](https://ej2.syncfusion.com/aspnetcore/documentation/rich-text-editor/getting-started) and [Blazor Rich Text Editor getting started guide](https://blazor.syncfusion.com/documentation/rich-text-editor/getting-started-with-server-app).

**Migration overview**

| Aspect   | Razor Pages (`<ejs-richtexteditor>`)  | Blazor (`SfRichTextEditor`)  |
| --- | --- | --- |
| **Package (NuGet)**       | [Syncfusion.EJ2.AspNet.Core](https://www.nuget.org/packages/Syncfusion.EJ2.AspNet.Core) | [Syncfusion.Blazor.RichTextEditor](https://www.nuget.org/packages/Syncfusion.Blazor.RichTextEditor) |
| **Component declaration** | `<ejs-richtexteditor>` | `<SfRichTextEditor>` |
| **Content binding**       | `Value` set via `PageModel` | `@bind-Value`  |
| **Toolbar configuration** | [RichTextEditorToolbarSettings](https://help.syncfusion.com/cr/aspnetcore-js2/Syncfusion.EJ2.RichTextEditor.RichTextEditorToolbarSettings.html)   | [RichTextEditorToolbarSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.RichTextEditor.RichTextEditorToolbarSettings.html)  |
| **Theming & assets** | Scripts/styles in layout | CSS + `AddSyncfusionBlazor()` |
| **Lifecycle & refs**  | `OnGet`, handlers     | `OnInitialized[Async]`, `@ref` |

**Component rendering**

In the Razor Pages approach, the Rich Text Editor is defined using an HTML helper in the `.cshtml` page. Its content is provided from the `PageModel` and rendered during the request.

In the Blazor approach, the Rich Text Editor is defined as a Razor component and its value is bound to a variable. The content is maintained within the component and updated dynamically as part of the page state.

**Razor pages approach**

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
            <p><b> Key features:</b></p>
            <ul>
                <li><p> Provides &lt; IFRAME &gt; and &lt; DIV &gt; modes </p></li>
                <li><p> Capable of handling markdown editing.</p></li>
                <li><p> Contains a modular library to load the necessary functionality on demand.</p></li>
                <li><p> Provides a fully customizable toolbar.</p></li>
                <li><p> Provides HTML view to edit the source directly for developers.</p></li>
                <li><p> Supports third - party library integration.</p></li>
                <li><p> Allows preview of modified content before saving it.</p></li>
                <li><p> Handles images, hyperlinks, video, hyperlinks, uploads, etc.</p></li>
                <li><p> Contains undo / redo manager.</p></li>
                <li><p> Creates bulleted and numbered lists.</p></li>
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
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }
    public class RichTextEditorValue
    {
        public string text { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

**Blazor approach**

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@page "/"
@using Syncfusion.Blazor.RichTextEditor

<h3>Rich Text Editor</h3>

<SfRichTextEditor @bind-Value="EditorContent">
    <RichTextEditorToolbarSettings Items="@ToolbarItems"></RichTextEditorToolbarSettings>
    <RichTextEditorQuickToolbarSettings Image="@ImageToolbarItems"></RichTextEditorQuickToolbarSettings>
</SfRichTextEditor>

@code {

    public List<ToolbarItemModel> ToolbarItems = new()
    {
        new ToolbarItemModel() { Command = ToolbarCommand.Bold },
        new ToolbarItemModel() { Command = ToolbarCommand.Italic },
        new ToolbarItemModel() { Command = ToolbarCommand.Underline },
        new ToolbarItemModel() { Command = ToolbarCommand.StrikeThrough },

        new ToolbarItemModel() { Command = ToolbarCommand.FontName },
        new ToolbarItemModel() { Command = ToolbarCommand.FontSize },
        new ToolbarItemModel() { Command = ToolbarCommand.FontColor },
        new ToolbarItemModel() { Command = ToolbarCommand.BackgroundColor },

        new ToolbarItemModel() { Command = ToolbarCommand.LowerCase },
        new ToolbarItemModel() { Command = ToolbarCommand.UpperCase },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },

        new ToolbarItemModel() { Command = ToolbarCommand.Formats },
        new ToolbarItemModel() { Command = ToolbarCommand.Alignments },
        new ToolbarItemModel() { Command = ToolbarCommand.OrderedList },
        new ToolbarItemModel() { Command = ToolbarCommand.UnorderedList },

        new ToolbarItemModel() { Command = ToolbarCommand.Outdent },
        new ToolbarItemModel() { Command = ToolbarCommand.Indent },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },

        new ToolbarItemModel() { Command = ToolbarCommand.CreateLink },
        new ToolbarItemModel() { Command = ToolbarCommand.Image },
        new ToolbarItemModel() { Command = ToolbarCommand.CreateTable },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },

        new ToolbarItemModel() { Command = ToolbarCommand.ClearFormat },
        new ToolbarItemModel() { Command = ToolbarCommand.Print },
        new ToolbarItemModel() { Command = ToolbarCommand.SourceCode },
        new ToolbarItemModel() { Command = ToolbarCommand.FullScreen },
        new ToolbarItemModel() { Command = ToolbarCommand.Separator },

        new ToolbarItemModel() { Command = ToolbarCommand.Undo },
        new ToolbarItemModel() { Command = ToolbarCommand.Redo }
    };

    // Correct type for image toolbar
    public List<ImageToolbarItemModel> ImageToolbarItems = new()
    {
        new ImageToolbarItemModel() { Command = ImageToolbarCommand.Replace },
        new ImageToolbarItemModel() { Command = ImageToolbarCommand.Align },
        new ImageToolbarItemModel() { Command = ImageToolbarCommand.Caption },
        new ImageToolbarItemModel() { Command = ImageToolbarCommand.Remove },
        new ImageToolbarItemModel() { Command = ImageToolbarCommand.InsertLink },
        new ImageToolbarItemModel() { Command = ImageToolbarCommand.OpenImageLink },
        new ImageToolbarItemModel() { Command = ImageToolbarCommand.Separator },
        new ImageToolbarItemModel() { Command = ImageToolbarCommand.EditImageLink },
        new ImageToolbarItemModel() { Command = ImageToolbarCommand.RemoveImageLink },
        new ImageToolbarItemModel() { Command = ImageToolbarCommand.Display },
        new ImageToolbarItemModel() { Command = ImageToolbarCommand.AltText },
        new ImageToolbarItemModel() { Command = ImageToolbarCommand.Dimension }
    };

    // Correct way to set content (NO RichTextEditorValue tag)
    public string EditorContent = @"
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

**Key differences**

The key difference is that Razor Pages relies on a request based model. In contrast, Blazor uses a stateful, data binding approach. The content persists in memory and updates automatically without requiring full page reloads.

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

