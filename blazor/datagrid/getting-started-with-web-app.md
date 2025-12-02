---
layout: post
title: Getting Started with Syncfusion Blazor DataGrid in Web App
description: Checkout and learn about the documentation for getting started with Syncfusion Blazor DataGrid in Blazor Web App.
platform: Blazor
component: DataGrid
documentation: ug
---

# Getting Started with Blazor DataGrid in Web App

The [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) is a feature-rich component designed for displaying and managing data in Blazor applications. It supports essential functionalities such as **data binding**, **sorting**, **filtering**, **paging**, and **grouping**, enabling the **creation of interactive** and **responsive data-driven interfaces**.

This guide provides detailed instructions for integrating the DataGrid into a **Blazor Web App** using [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/), or the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/). It includes setup steps, configuration details, and usage examples to assist in building robust applications.

> For advanced integration assistance, refer to [AI Coding Assistant Overview](https://blazor.syncfusion.com/documentation/ai-coding-assistant/overview).

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* [System requirements for Blazor component](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a Blazor Web App in Visual Studio 2022

A **Blazor Web App** can be created using **Visual Studio** with the built-in [Microsoft templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

1. Open **Visual Studio 2022** (version 17.8 or later).
2. Select **Create a new project**.
3. Choose **Blazor Web App** from the list of templates and click **Next**.
4. Specify the **project name**, **location**, and **solution settings**, then click **Next**.
5. Select the **target framework** as **.NET 8.0 or later** (choose the latest installed version available on the system).
6. Choose the [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-9.0#render-modes)(Server, WebAssembly, or Auto) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-9.0&pivots=vs).
7. Review the remaining options and click **Create** to generate the project.

![Create Blazor Web App](images/blazor-create-web-app.png)

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet Packages

To integrate the Blazor DataGrid component, install the required Syncfusion<sup style="font-size:70%">&reg;</sup> NuGet packages in the solution:

1. Open **NuGet Package Manager** in Visual Studio:

    *Tools → NuGet Package Manager → Manage NuGet Packages for Solution*.

2. Search and install the following packages:

    - [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid/)
    - [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

3. For projects using **WebAssembly** or **Auto** interactive render modes, ensure these packages are installed in the **Client** project.

4. Alternatively, use the **Package Manager Console**:

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Grid -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). For a complete list of packages, refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages).

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

* [System requirements for Blazor components](https://blazor.syncfusion.com/documentation/system-requirements)

## Create a new Blazor Web App in Visual Studio Code

1. Install the latest **.NET SDK** that supports **.NET 8.0 or later**.
2. Open **Visual Studio Code**.
3. Press **Ctrl + `** to open the integrated terminal.
4. Execute the following command to create a **Blazor Web App** with **Auto** [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-10.0#render-modes):

{% tabs %}
{% highlight c# tabtitle="Blazor Web App" %}

dotnet new blazor -o BlazorWebApp -int Auto
cd BlazorWebApp
cd BlazorWebApp.Client

{% endhighlight %}
{% endtabs %}

N> For other **interactive render modes** and **interactivity locations**, refer to Render Modes [documentation](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=visual-studio-code#render-interactive-modes).

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet Packages in Visual Studio Code

To integrate the Blazor DataGrid component, install the required Syncfusion<sup style="font-size:70%">&reg;</sup> NuGet packages using the **integrated terminal**:

1. Press **Ctrl + `** to open the integrated terminal in Visual Studio Code.
2. Navigate to the directory containing the **.csproj** file.
3. Run the following commands to install the packages:

* [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid)
* [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Grid -Version {{site.releaseversion}}
Install-Package Syncfusion.Blazor.Themes -Version {{site.releaseversion}}

{% endhighlight %}

{% endtabs %}

4. For projects using **WebAssembly** or **Auto** interactive render modes, ensure these packages are installed in the **Client** project.

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). For a complete list of packages, refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages).

{% endtabcontent %}

{% tabcontent .NET CLI %}

## Prerequisites

1. Install the latest [.NET SDK](https://dotnet.microsoft.com/en-us/download) that supports .NET 8.0 or later.
2. Verify the installed version by running the following command in a command prompt (Windows), terminal (macOS), or shell (Linux):

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet --version

{% endhighlight %}
{% endtabs %}

## Create a Blazor Web App using .NET CLI

1. Open a **command prompt**, **terminal**, or **shell**.
2. Navigate to the directory where the project should be created.
3. Run the following command to create a new **Blazor Web App** with **Auto** interactive render mode:

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet new blazor -o BlazorApp -int Auto
cd BlazorApp
cd BlazorApp.Client

{% endhighlight %}
{% endtabs %}

4. Configure the appropriate [interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-9.0#render-modes) and [interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-9.0&pivots=vs) when setting up the application. For more details, see [Render Mode documentation](https://blazor.syncfusion.com/documentation/common/interactive-render-mode).
5. This command creates a new **Blazor Web App** in a directory named **BlazorApp** inside the current location.

> For additional details, refer to:
>* [Blazor Web App Getting Started (.NET CLI)](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app?tabcontent=.net-cli)
>* [dotnet new CLI command](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new)
>* [Create Blazor App Tutorial](https://dotnet.microsoft.com/en-us/learn/aspnet/blazor-tutorial/create)

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet Packages using .NET CLI

To integrate the Blazor DataGrid component in a **Blazor Web App** using the **.NET CLI**:

1. Open a **command prompt**, **terminal**, or **shell**.
2. Navigate to the directory containing the **.csproj** file.
3. Run the following commands to install the required NuGet packages:

    - [Syncfusion.Blazor.Grid](https://www.nuget.org/packages/Syncfusion.Blazor.Grid/)
    - [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Grid --version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes --version {{ site.releaseversion }}
dotnet restore

{% endhighlight %}
{% endtabs %}

4. For projects using **WebAssembly** or **Auto** interactive render modes, ensure these packages are installed in the **Client** project.

N> For more details, refer to:

> * [Install and manage packages using the dotnet CLI](https://learn.microsoft.com/en-us/nuget/consume-packages/install-use-packages-dotnet-cli)
> * Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). For a complete list of packages, refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages).

{% endtabcontent %}

{% endtabcontents %}

## Add Import Namespaces

1. Open the **~/_Imports.razor** file in the **Client** project.
2. Add the following namespaces:

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

{% endhighlight %}
{% endtabs %}

- For **WebAssembly** or **Auto** interactive render modes, update this file in the **Client** project.
- For **Server** interactive render mode, update this file in the **Components** folder.

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service must be registered in the **Program.cs** file.

**Server Render Mode**

For **Server** interactive render mode, register the service in the **Program.cs** file of the **Server** project:

{% tabs %}
{% highlight c# tabtitle="Server(~/_Program.cs)" hl_lines="3 11" %}

using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSyncfusionBlazor();
var app = builder.Build()
....

{% endhighlight %}
{% endtabs %}

**Auto or WebAssembly Render Mode**

For **Auto** or **WebAssembly** interactive render modes, register the service in both **Server** and **Client** projects:
{% tabs %}
{% highlight c# tabtitle="Server(~/_Program.cs)" hl_lines="3 11" %}

...
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents()
    .AddInteractiveWebAssemblyComponents();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
....

{% endhighlight %}
{% highlight c# tabtitle="Client(~/_Program.cs)" hl_lines="2 5" %}

...
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.Services.AddSyncfusionBlazor();

await builder.Build().RunAsync();

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor themes and scripts are available through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Add the following references in the **~/Components/App.razor** file:

**In the &lt;head&gt; section:**

```html
<head>
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>
```

**At the end of the &lt;body&gt; section:**

```html
<body>
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>
```

N>
* Refer to [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) for various methods to reference themes in a Blazor application:

>* [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets)
>* [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference)
>* [Custom Resource Generator (CRG)](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)

>* For script reference options, see [Adding Script References](https://blazor.syncfusion.com/documentation/common/adding-script-references).

## Add Blazor DataGrid 

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can be added to a Razor page in the **Pages** folder (for example, **Pages/Home.razor**) in either the **Server** or **Client** project.

**1. Define Render Mode**

To use the **DataGrid** component in a **Blazor Web App**, set the **render mode** at the top of the **.razor** file.

{% tabs %}
{% highlight razor %}

@rendermode InteractiveAuto

{% endhighlight %}
{% endtabs %}

**Available Render Modes**

| Mode                       | Syntax                                  | Description                                                   |
|---------------------------|----------------------------------------|--------------------------------------------------------------|
| **InteractiveAuto**       | `@rendermode InteractiveAuto`         | Automatically selects the appropriate mode based on the hosting environment. |
| **InteractiveWebAssembly**| `@rendermode InteractiveWebAssembly`  | Executes component logic on the client using WebAssembly.    |
| **InteractiveServer**     | `@rendermode InteractiveServer`       | Executes component logic on the server using SignalR.        |

**Interactivity Location**

* **Global**: Render mode is configured in **App.razor** and applies to the entire application by default.
* **Per page/component**: Render mode is set at the top of the specific **Razor** file (for example, **Pages/Index.razor**).

2. **Add DataGrid component**

Add the **DataGrid** tag to the **Razor** page:

{% tabs %}
{% highlight razor %}

<SfGrid></SfGrid>

{% endhighlight %}
{% endtabs %}

## Defining row data

The DataGrid requires a data source to display records. A collection implementing **IEnumerable<T>** can be assigned to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property. Alternatively, data can be provided through a [DataManager](https://blazor.syncfusion.com/documentation/data/getting-started-with-web-app) instance for **remote binding**.

Data binding is typically performed in the [OnInitialized](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.componentbase.oninitialized?view=aspnetcore-10.0) lifecycle method of the component.

{% tabs %}
{% highlight razor %}


<SfGrid DataSource="@Orders">
</SfGrid>

@code {
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x)
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

* Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to run the application. The DataGrid will render and display the collection.

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtLSMLthxegYrbQD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Defining columns

The DataGrid automatically generates columns when no explicit column definitions are provided. For greater control over column behavior and appearance, use the [GridColumns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumns.html) component along with individual [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) elements to define columns explicitly.

**Common Column Properties**

* [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field): Maps the column to a property in the bound collection.
* [HeaderText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_HeaderText): Specifies the column header title.
* [TextAlign](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_TextAlign): Aligns text within the column. Default alignment is Left; set to Right for numeric values.
* [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Format): Applies standard or custom formatting for numeric and date values.
* [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Type): Defines the column type, such as ColumnType.Date for date fields.
* [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Width): Sets the column width in pixels or percentage to control layout consistency.

{% tabs %}
{% highlight razor %}


<SfGrid DataSource="@Orders">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

{% endhighlight %}
{% endtabs %}

## Enable paging

[Paging](https://blazor.syncfusion.com/documentation/datagrid/paging) allows the DataGrid to display records in a paged view, improving performance and readability for large datasets. Enable paging by setting the [AllowPaging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowPaging) property to **true**. Paging behavior can be customized using the [GridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html) component.

{% tabs %}
{% highlight razor %}

<SfGrid DataSource="@Orders" AllowPaging="true">
    <GridPageSettings PageSize="5"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

{% endhighlight %}
{% endtabs %}

## Enable sorting

[Sorting](https://blazor.syncfusion.com/documentation/datagrid/sorting) allows the DataGrid to arrange records based on column values. Enable this feature by setting the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) property to **true**. Sorting behavior can be customized using the [GridSortSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSortSettings.html) component.

{% tabs %}
{% highlight razor %}

<SfGrid DataSource="@Orders" AllowPaging="true" AllowSorting="true">
 <GridPageSettings PageSize="5"></GridPageSettings>
   <GridColumns>
     <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
     <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
     <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
     <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
   </GridColumns>
</SfGrid>

{% endhighlight %}
{% endtabs %}

## Enable filtering

[Filtering](https://blazor.syncfusion.com/documentation/datagrid/filtering) allows the DataGrid to display a subset of records based on specified criteria. Enable filtering by setting the [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowFiltering) property to **true**. Filtering behavior can be customized using the [GridFilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridFilterSettings.html) component.

{% tabs %}
{% highlight razor %}

<SfGrid DataSource="@Orders" AllowPaging="true" AllowSorting="true" AllowFiltering="true">
 <GridPageSettings PageSize="5"></GridPageSettings>
   <GridColumns>
     <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
     <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
     <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
     <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
   </GridColumns>
</SfGrid>

{% endhighlight %}
{% endtabs %}

## Enable grouping

[Grouping](https://blazor.syncfusion.com/documentation/datagrid/grouping) organizes records into logical groups based on column values. Enable grouping by setting the [AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowGrouping) property to **true**. Grouping behavior can be customized using the [GridGroupSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html) component.

{% tabs %}
{% highlight razor %}

<SfGrid DataSource="@Orders" AllowPaging="true" AllowSorting="true" AllowFiltering="true" AllowGrouping="true">
    <GridPageSettings PageSize="5"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtBfDWBkLabNleSQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor DataGrid](images/blazor-datagrid.gif)" %}

## Handling exceptions

Exceptions that occur during DataGrid operations can be captured without interrupting the application flow. Use the [OnActionFailure](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnActionFailure) event to retrieve error details and handle them gracefully.

**Key Points**:

* **TValue**: Specifies the row data type for the grid (for example, Order). This ensures strong typing for templates and event arguments.
* **GridEvents**: When using [GridEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#), set the same `TValue` on both [SfGrid](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#) and `GridEvents` for proper event argument binding.

N> Binding the `OnActionFailure` event during development helps identify issues early. Exception details can be logged or displayed for troubleshooting.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Data

<span class="error">@ErrorDetails</span>

<SfGrid TValue="Order" AllowPaging="true">
    <GridEvents TValue="Order" OnActionFailure="@ActionFailure"></GridEvents>
    <GridPageSettings PageSize="10"></GridPageSettings>
    <SfDataManager Url="https://some.com/invalidUrl" Adaptor="Adaptors.WebApiAdaptor"></SfDataManager>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    .error {
        color: red;
    }
</style>

@code {
    public string ErrorDetails = "";

    public class Order {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }

    public void ActionFailure(FailureEventArgs args) {
        ErrorDetails = "Server exception: 404 Not Found";
        StateHasChanged();
    }
}

{% endhighlight %}
{% endtabs %}

N> [View Sample in GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/DataGrid).

## See also

1. [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for client-side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-dotnet-cli)
2. [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for client-side in Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-visual-studio)
3. [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for server-side in .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-dotnet-cli)

