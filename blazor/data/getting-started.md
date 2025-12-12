---
layout: post
title: Getting Started with Blazor DataManager Component | Syncfusion
description: Learn how to configure and use the Syncfusion Blazor DataManager component in a Blazor WebAssembly application.
platform: Blazor
control: DataManager
documentation: ug
---

# Getting Started with Blazor DataManager Component

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component provides a robust data access layer for Blazor applications. It enables seamless interaction with both **local** and **remote** data sources and supports essential operations such as **querying**, **sorting**, **filtering**, and **CRUD** actions. The component is designed to work in conjunction with Syncfusion<sup style="font-size:70%">&reg;</sup> data-bound controls, ensuring efficient data management across the application.

This guide explains how to configure and use the `DataManager` component in a **Blazor WebAssembly** application using [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/), and the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

{% tabcontents %}

{% tabcontent Visual Studio %}

## Prerequisites

* Ensure the development environment meets the [system requirements for Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/system-requirements) before proceeding with the setup.

## Create a new Blazor WebAssembly App in Visual Studio

A **Blazor WebAssembly App** can be created using **Visual Studio** with the built-in [Microsoft templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

1. Open **Visual Studio 2022** (v17.8 or later).
2. Select **Create a new project**.
3. Choose **Blazor WebAssembly Standalone App** from the list of templates and click **Next**.
4. Configure the **project name**, **location**, and **solution settings**, then click **Next**.
5. Select the **target framework** as **.NET 9.0 or later** (choose the latest installed version available on the system).
6. Click **Create** to generate the project.

N> For detailed steps, refer to [Microsoft Blazor tooling documentation](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-9.0&pivots=vs).

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor NuGet Packages

To integrate the Blazor **DataManager** component, install the required NuGet packages in the **Blazor WebAssembly** project:

1. Open **NuGet Package Manager** in Visual Studio:

    *Tools → NuGet Package Manager → Manage NuGet Packages for Solution*.

2. Search and install the following packages:

    - [Syncfusion.Blazor.Data](https://www.nuget.org/packages/Syncfusion.Blazor.Data)
    - [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/)

3. Alternatively, use the **Package Manager Console**:

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

## Create a new Blazor App in Visual Studio Code

A **Blazor WebAssembly App** can be created using **Visual Studio Code** with the built-in [Microsoft templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc) or the [Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project).

1. Open **Visual Studio Code**.
2. Open the **integrated terminal** (**Ctrl + `**).
3. Run the following commands to create a new **Blazor WebAssembly** project:

{% tabs %}

{% highlight c# tabtitle="Blazor WASM App" %}

dotnet new blazorwasm -o BlazorApp
cd BlazorApp

{% endhighlight %}

{% endtabs %}

4. Open the **project folder** in **Visual Studio Code**.

## Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Data and Themes NuGet in the App

1. Press <kbd>Ctrl</kbd>+<kbd>`</kbd> to open the integrated terminal in Visual Studio Code.
2. Ensure the terminal is in the project root directory where the **.csproj** file is located.
3. Run the following commands to install the required NuGet packages:

    - [Syncfusion.Blazor.Data](https://www.nuget.org/packages/Syncfusion.Blazor.Data)
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

{% tabcontent .NET CLI %}

### Prerequisites

Install the latest version of [.NET SDK](https://dotnet.microsoft.com/en-us/download). If the .NET SDK was previously installed, determine the installed version by running the following command in a command prompt (Windows), terminal (macOS), or command shell (Linux).

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet --version

{% endhighlight %}
{% endtabs %}

### Create a Blazor WebAssembly App using .NET CLI

Run the following command to create a new Blazor WebAssembly App in a command prompt (Windows) or terminal (macOS) or command shell (Linux). For detailed instructions, refer to [this Blazor WASM App Getting Started](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app?tabcontent=.net-cli) documentation.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet new blazorwasm -o BlazorApp
cd BlazorApp

{% endhighlight %}
{% endtabs %}

### Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Data and Themes NuGet in the App

To add the **Blazor DataManager** component to the application, run the following commands in a command prompt (Windows), command shell (Linux), or terminal (macOS) to install the [Syncfusion.Blazor.Data](https://www.nuget.org/packages/Syncfusion.Blazor.Data/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet packages. See [Install and manage packages using the dotnet CLI](https://learn.microsoft.com/en-us/nuget/consume-packages/install-use-packages-dotnet-cli) for more details.

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Data -Version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}
dotnet restore

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the available NuGet packages list with component details.

{% endtabcontent %}

{% endtabcontents %}

## Add Import Namespaces

Open the **~/_Imports.razor** file and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Data` namespaces.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data

{% endhighlight %}
{% endtabs %}

## Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Service

Register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service in the **~/Program.cs** file:

{% tabs %}
{% highlight C# tabtitle="~/Program.cs" hl_lines="3 11" %}

using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Syncfusion.Blazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

builder.Services.AddSyncfusionBlazor();
await builder.Build().RunAsync();
....

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

The theme stylesheet and script files are provided through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-asset) in the NuGet packages. Include these references in the **<head>** section of the **~/wwwroot/index.html** file:

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>
```

N>
* Refer to [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) for various methods to reference themes in a Blazor application:

    * [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets)
    * [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference)
    * [Custom Resource Generator (CRG)](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)

* For script reference options, see [Adding Script References](https://blazor.syncfusion.com/documentation/common/adding-script-references).

## Add Blazor DataManager component

The [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component is designed to work with Syncfusion<sup style="font-size:70%">&reg;</sup> data-bound components that support data operations. It serves as a gateway for both local and remote data, enabling interaction with the data source based on the configured query.

### Binding to JSON data

Local **JSON** data can be bound to the [DataGrid](https://blazor.syncfusion.com/documentation/datagrid/getting-started) component by assigning a collection of objects to the [Json](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Json) property of the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component.

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Grids

<SfGrid TValue="EmployeeData" ID="Grid">
    <SfDataManager Json="@Employees"></SfDataManager>
    <GridColumns>
        <GridColumn Field="@nameof(EmployeeData.EmployeeID)" TextAlign="TextAlign.Center" HeaderText="Employee ID" Width="120"></GridColumn>
        <GridColumn Field="@nameof(EmployeeData.Name)" HeaderText="First Name" Width="130"></GridColumn>
        <GridColumn Field="@nameof(EmployeeData.Title)" HeaderText="Title" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public class EmployeeData
    {
        public int EmployeeID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
    }

    public List<EmployeeData> Employees = new()
    {
        new EmployeeData { EmployeeID = 1, Name = "Nancy Fuller", Title = "Vice President" },
        new EmployeeData { EmployeeID = 2, Name = "Steven Buchanan", Title = "Sales Manager" },
        new EmployeeData { EmployeeID = 3, Name = "Janet Leverling", Title = "Sales Representative" },
        new EmployeeData { EmployeeID = 4, Name = "Andrew Davolio", Title = "Inside Sales Coordinator" },
        new EmployeeData { EmployeeID = 5, Name = "Steven Peacock", Title = "Inside Sales Coordinator" },
        new EmployeeData { EmployeeID = 6, Name = "Janet Buchanan", Title = "Sales Representative" },
        new EmployeeData { EmployeeID = 7, Name = "Andrew Fuller", Title = "Inside Sales Coordinator" },
        new EmployeeData { EmployeeID = 8, Name = "Steven Davolio", Title = "Inside Sales Coordinato" },
        new EmployeeData { EmployeeID = 9, Name = "Janet Davolio", Title = "Sales Representative" },
        new EmployeeData { EmployeeID = 10, Name = "Andrew Buchanan", Title = "Sales Representative" }
    };
}

{% endhighlight %}
{% endtabs %}

### Binding to OData

Remote data can be bound to the [DataGrid](https://blazor.syncfusion.com/documentation/datagrid/getting-started) component by configuring the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Url) property and specifying the appropriate adaptor using the [Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Adaptor) property of the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component.

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BtVyMWMEFjOIhipK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Data Binding in Blazor DataManager Component](./images/blazor-datamanager-data-binding.png)" %}

N> [View Sample on GitHub](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/DataManager).