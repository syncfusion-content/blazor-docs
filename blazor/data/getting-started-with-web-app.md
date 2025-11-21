---
layout: post
title: Getting Started with Syncfusion Blazor DataManager Component in WebApp
description: Checkout and learn about the documentation for getting started with Blazor DataManager Component in Blazor Web App.
platform: Blazor
component: DataManager
documentation: ug
---

# Getting Started with Blazor DataManager Component in Web App

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component acts as a data gateway for Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor controls that support data binding. It enables interaction with **local** or **remote** data sources using **queries** and **adaptors**. This guide provides step-by-step instructions to configure the component in a **Blazor Web App** created with [Visual Studio](https://visualstudio.microsoft.com/vs/) or [Visual Studio Code](https://code.visualstudio.com/).

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* Ensure the development environment meets the [system requirements for Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/system-requirements) before proceeding with the setup.

## Create a new Blazor Web App in Visual Studio

A **Blazor Web App** can be created using **Visual Studio** with the built-in [Microsoft templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

1. Open **Visual Studio 2022** (version 17.8 or later).
2. Select **Create a new project**.
3. Choose **Blazor Web App** from the template list and click **Next**.
4. Specify the **project name**, **location**, and **solution settings**, then click **Next**.
5. Select the **target framework** as **.NET 9.0 or later** (choose the latest installed version).
6. Choose the [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-10.0#render-modes)(Server, WebAssembly, or Auto) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs).
7. Review the remaining options and click **Create** to generate the project.

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Data and Themes NuGet in the Blazor Web App

To integrate the **Blazor DataManager** component, install the required Syncfusion<sup style="font-size:70%">&reg;</sup> NuGet packages in the solution:

1. Open **NuGet Package Manager** in Visual Studio:

    *Tools → NuGet Package Manager → Manage NuGet Packages for Solution*.

2. Search and install the following packages:

    - [Syncfusion.Blazor.Data](https://www.nuget.org/packages/Syncfusion.Blazor.Data/)
    - [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

3. For projects using **WebAssembly** or **Auto** interactive render modes, ensure these packages are installed in the **Client** project.

4. Alternatively, use the **Package Manager Console**:

{% tabs %}
{% highlight C# tabtitle="Package Manager" %}

Install-Package Syncfusion.Blazor.Data -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). For a complete list of packages, refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages).

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

## Prerequisites

* Ensure the development environment meets the [system requirements for Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/system-requirements) before proceeding with the setup.

## Create a new Blazor Web App in Visual Studio Code

A **Blazor Web App** can be created using **Visual Studio Code** with the built-in [Microsoft templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project).

1. Install the latest **.NET SDK** that supports **.NET 9 or later**.
2. Open **Visual Studio Code** and launch the integrated terminal (**Ctrl + `**).
3. Execute  the following command to create a **Blazor Web App** with **Auto** [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-10.0#render-modes):

{% tabs %}
{% highlight c# tabtitle="Blazor Web App" %}

dotnet new blazor -o BlazorWebApp -int Auto
cd BlazorWebApp
cd BlazorWebApp.Client

{% endhighlight %}
{% endtabs %}

N> For other interactive render modes and interactivity locations, refer to Render Modes [documentation](https://blazor.syncfusion.com/documentation/common/interactive-render-mode).

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Data and Themes NuGet in the App

To integrate the Blazor DataManager component, install the required Syncfusion<sup style="font-size:70%">&reg;</sup> NuGet packages using the **integrated terminal**:

1. Open the integrated terminal in Visual Studio Code (**Ctrl + `**).
2. Navigate to the directory containing the **.csproj** file.
3. Run the following commands to install the packages:

    - [Syncfusion.Blazor.Data](https://www.nuget.org/packages/Syncfusion.Blazor.Data/)
    - [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

{% tabs %}

{% highlight c# tabtitle="Package Manager" %}

dotnet add package Syncfusion.Blazor.Data -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}
dotnet restore

{% endhighlight %}

{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

{% endtabcontent %}

{% endtabcontents %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

1. Import the required namespaces in the **_Imports.razor** file:

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data

{% endhighlight %}
{% endtabs %}

- For **WebAssembly** or **Auto** interactive render modes, update this file in the **Client** project.
- For **Server** interactive render mode, update this file in the **Components** folder.

2. Register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in the **Program.cs** file:

**Auto or WebAssembly Render Mode**

Register the service in both **Server** and **Client** projects:

{% tabs %}
{% highlight c# tabtitle="Server(~/_Program.cs)" hl_lines="3 11" %}

...
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

**Server Render Mode**

For **Server** mode, register the service in the **Program.cs** file:

{% tabs %}
{% highlight c# tabtitle="~/_Program.cs" hl_lines="2 9" %}

...
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
....

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

    * [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets)
    * [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference)
    * [Custom Resource Generator (CRG)](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)

* For script reference options, see [Adding Script References](https://blazor.syncfusion.com/documentation/common/adding-script-references).

## Add Blazor DataManager component

The [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component acts as a data gateway for Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components that support data binding. It enables interaction with local or remote data sources using queries.

### Binding to JSON data

Local [JSON](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Json) data can be bound to the [DataGrid](https://blazor.syncfusion.com/documentation/datagrid/getting-started) component by assigning a collection of objects to the `Json` property of the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data

<SfGrid TValue="EmployeeData" ID="Grid">
    <SfDataManager Json="@Employees"></SfDataManager>
    <GridColumns>
        <GridColumn Field="@nameof(EmployeeData.EmployeeID)" TextAlign="TextAlign.Center" HeaderText="Employee ID" Width="120"></GridColumn>
        <GridColumn Field="@nameof(EmployeeData.Name)" HeaderText="First Name" Width="130"></GridColumn>
        <GridColumn Field="@nameof(EmployeeData.Title)" HeaderText="Title" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public List<EmployeeData> Employees { get; set; } = new()
    {
        new EmployeeData { EmployeeID = 1, Name = "Nancy Fuller", Title = "Vice President" },
        new EmployeeData { EmployeeID = 2, Name = "Steven Buchanan", Title = "Sales Manager" },
        new EmployeeData { EmployeeID = 3, Name = "Janet Leverling", Title = "Sales Representative" },
        new EmployeeData { EmployeeID = 4, Name = "Andrew Davolio", Title = "Inside Sales Coordinator" },
        new EmployeeData { EmployeeID = 5, Name = "Steven Peacock", Title = "Inside Sales Coordinator" },
        new EmployeeData { EmployeeID = 6, Name = "Janet Buchanan", Title = "Sales Representative" },
        new EmployeeData { EmployeeID = 7, Name = "Andrew Fuller", Title = "Inside Sales Coordinator" },
        new EmployeeData { EmployeeID = 8, Name = "Steven Davolio", Title = "Inside Sales Coordinator" },
        new EmployeeData { EmployeeID = 9, Name = "Janet Davolio", Title = "Sales Representative" },
        new EmployeeData { EmployeeID = 10, Name = "Andrew Buchanan", Title = "Sales Representative" }
    };

    public class EmployeeData
    {
        public int EmployeeID { get; set; }
        public string? Name { get; set; }
        public string? Title { get; set; }
    }
}
{% endhighlight %}
{% endtabs %}

### Binding to OData

Remote data can be bound by setting the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Url) property and specifying the appropriate adaptor using the [Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Adaptor) property of the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="Order" ID="Grid" AllowPaging="true">
    <SfDataManager Url="https://services.odata.org/Northwind/Northwind.svc/Orders"
                   Adaptor="Adaptors.ODataAdaptor">
    </SfDataManager>
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" IsPrimaryKey="true"
                    TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field="@nameof(Order.OrderDate)" HeaderText="Order Date" Format="d"
                    Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field="@nameof(Order.Freight)" HeaderText="Freight" Format="C2"
                    TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public class Order
    {
        public int? OrderID { get; set; }
        public string? CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

## Component binding

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component can be integrated with any Syncfusion<sup style="font-size:70%">&reg;</sup> data-bound component to manage local or remote data operations.

This configuration demonstrates how the `DataManager` is bound to the [SfDropDownList](https://blazor.syncfusion.com/documentation/dropdown-list/getting-started) component to enable consistent interaction with local or remote data sources.

### Local data binding

Local data can be bound to components such as `SfDropDownList` by assigning a collection of objects to the [Json](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Json) property of the `SfDataManager` component.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.DropDowns

<SfDropDownList Placeholder="e.g. Australia" TItem="Country" TValue="string">
    <SfDataManager Json="@Countries"></SfDataManager>
    <DropDownListFieldSettings Value="Name"></DropDownListFieldSettings>
</SfDropDownList>

@code {
    public class Country
    {
        public string? Name { get; set; }
        public string? Code { get; set; }
    }

    public List<Country> Countries = new()
    {
        new Country { Name = "Australia", Code = "AU" },
        new Country { Name = "Bermuda", Code = "BM" },
        new Country { Name = "Canada", Code = "CA" },
        new Country { Name = "Cameroon", Code = "CM" }
    };
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZLeCWWaPtlNQoPM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Binding DropDownList Item in Blazor DataManager Component](./images/blazor-datamanager-binding-dropdown-item.png)" %}

### Remote data binding

Remote data can be bound by setting the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Url) property and specifying the appropriate adaptor using the [Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Adaptor) property of the `SfDataManager` component.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.DropDowns

<SfDropDownList Placeholder="Name" TItem="Contact" TValue="Contact">
    <SfDataManager Url="https://services.odata.org/V4/Northwind/Northwind.svc/Customers" Adaptor="Adaptors.ODataV4Adaptor"></SfDataManager>
    <DropDownListFieldSettings Value="CustomerID" Text="ContactName"></DropDownListFieldSettings>
</SfDropDownList>

@code {
    
    public class Contact
    {
        public string? ContactName { get; set; }
        public string? CustomerID { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZheWWWamGlqvaaF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Data Binding in Blazor DataManager Component](./images/blazor-datamanager-data-binding.png)" %}

N> [View the complete sample on GitHub.](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/DataManager).

## See also

1. [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for client-side using .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-dotnet-cli)
2. [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for client-side using Visual Studio](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-visual-studio)
3. [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor for server-side using .NET Core CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-dotnet-cli)

