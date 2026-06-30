---
layout: post
title: Getting Started with Blazor DataManager in Blazor Web App | Syncfusion
description: Checkout and learn about the documentation for getting started with Blazor DataManager Component in Blazor Web App.
platform: Blazor
component: DataManager
documentation: ug
---

# Getting Started with Blazor DataManager Component in Blazor Web App

This section briefly explains about how to include Blazor DataManager component in your Blazor Web App using [Visual Studio](https://visualstudio.microsoft.com/vs/), [Visual Studio Code](https://code.visualstudio.com/), and the [.NET CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/).

## Create a new Blazor Web App

{% tabcontents %}

{% tabcontent Visual Studio %}

Create a **Blazor Web App** using Visual Studio via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) or the [Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-integration/template-studio).

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Run the following command to create a new Blazor Web App.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet new blazor -o BlazorWebApp --interactivity Auto
cd BlazorWebApp
cd BlazorWebApp.Client

{% endhighlight %}
{% endtabs %}

Alternatively, create a **Blazor Web App** using Visual Studio Code via [Microsoft Templates](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vsc), the [Blazor Extension](https://blazor.syncfusion.com/documentation/visual-studio-code-integration/create-project), or the [C# Dev Kit](https://marketplace.visualstudio.com/items?itemName=ms-dotnettools.csdevkit) extension.

{% endtabcontent %}

{% tabcontent .NET CLI %}

Run the following command to create a new Blazor Web App.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

dotnet new blazor -o BlazorWebApp --interactivity Auto
cd BlazorWebApp
cd BlazorWebApp.Client

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

N> Configure the appropriate [Interactive render mode](https://learn.microsoft.com/en-us/aspnet/core/blazor/components/render-modes?view=aspnetcore-10.0#render-modes) and [Interactivity location](https://learn.microsoft.com/en-us/aspnet/core/blazor/tooling?view=aspnetcore-10.0&pivots=vs) while creating a Blazor Web App. For detailed information, refer to the [interactive render mode documentation](https://blazor.syncfusion.com/documentation/common/interactive-render-mode).

## Install the required Blazor packages

Install the [Syncfusion.Blazor.Data](https://www.nuget.org/packages/Syncfusion.Blazor.Data/) and [Syncfusion.Blazor.Themes](https://www.nuget.org/packages/Syncfusion.Blazor.Themes/) NuGet packages. All Syncfusion Blazor packages are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). See the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for details. If using the `WebAssembly` or `Auto` render modes in the Blazor Web App, install these packages in the `.Client` project.

{% tabcontents %}

{% tabcontent Visual Studio %}

1. Go to *Tools → NuGet Package Manager → Manage NuGet Packages for Solution*.
2. Search the required NuGet packages (`Syncfusion.Blazor.Data` and `Syncfusion.Blazor.Themes`) and install them.

Alternatively, you can install the same packages using the Package Manager Console with the following commands.

{% tabs %}
{% highlight razor tabtitle="Package Manager Console" %}

Install-Package Syncfusion.Blazor.Data -Version {{ site.releaseversion }}
Install-Package Syncfusion.Blazor.Themes -Version {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Open the terminal and run the following commands.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

dotnet add package Syncfusion.Blazor.Data -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent .NET CLI %}

Open the command prompt and run the following commands.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}


dotnet add package Syncfusion.Blazor.Data -v {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes -v {{ site.releaseversion }}

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

## Add import namespaces

After the packages are installed, open the **~/_Imports.razor** file in the `.Client` project and import the `Syncfusion.Blazor` and `Syncfusion.Blazor.Data` namespaces.

{% tabs %}
{% highlight C# tabtitle="~/_Imports.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data

{% endhighlight %}
{% endtabs %}

## Register the Blazor service

Open the **Program.cs** file in Blazor Web App and register the Blazor service. If the **Interactive Render Mode** is set to `WebAssembly` or `Auto`, register the Blazor service in **Program.cs** files of both the server and client projects in your Blazor Web App.

{% tabs %}
{% highlight c# tabtitle="Program.cs" %}

....
using Syncfusion.Blazor;
....
builder.Services.AddSyncfusionBlazor();
....

{% endhighlight %}
{% endtabs %}

## Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Include the [stylesheet](https://blazor.syncfusion.com/documentation/appearance/themes) and [script references](https://blazor.syncfusion.com/documentation/common/adding-script-references) in the **App.razor** file.

{% tabs %}
{% highlight html tabtitle="App.razor" %}

...
<link href="_content/Syncfusion.Blazor.Themes/fluent2.css" rel="stylesheet" />
...
<script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>

{% endhighlight %}
{% endtabs %}

## Add Blazor DataManager component

Open a Razor file located in the **~/Pages/*.razor** (for example, **Home.razor**) and add the Blazor DataManager component inside the razor file.

N> If the interactivity location is set to `Per page/component` in the Web App, define a render mode at the top of the razor file. (For example, `InteractiveServer`, `InteractiveWebAssembly` or `InteractiveAuto`). If the **Interactivity** is set to `Global` with `Auto` or `WebAssembly`, the render mode is automatically configured in the `App.razor` file by default.

The [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component acts as a data gateway for Blazor components that support data binding. It enables interaction with local or remote data sources using queries.

## Binding to JSON data

Local [JSON](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Json) data can be bound to the [DataGrid](https://blazor.syncfusion.com/documentation/datagrid/getting-started) component by assigning a collection of objects to the `Json` property of the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@rendermode InteractiveAuto
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

**Run the application**

{% tabcontents %}

{% tabcontent Visual Studio %}

Press <kbd>Ctrl</kbd>+<kbd>F5</kbd> (Windows) or <kbd>⌘</kbd>+<kbd>F5</kbd> (macOS) to launch the application. The Blazor DataManager component will render in your default web browser.

{% endtabcontent %}

{% tabcontent Visual Studio Code %}

Open the terminal and navigate to the main project folder (for example, `BlazorWebApp`) and run the following command.

{% tabs %}
{% highlight razor tabtitle="Terminal" %}

cd ..
cd BlazorWebApp
dotnet run

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% tabcontent .NET CLI %}

Open the command prompt and navigate to the main project folder (for example, `BlazorWebApp`) and run the following command.

{% tabs %}
{% highlight razor tabtitle="Command Prompt" %}

cd ..
cd BlazorWebApp
dotnet run

{% endhighlight %}
{% endtabs %}

{% endtabcontent %}

{% endtabcontents %}

## Binding to OData

Remote data can be bound by setting the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Url) property and specifying the appropriate adaptor using the [Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Adaptor) property of the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

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

@code 
{
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

The Blazor [DataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) component can be integrated with any data-bound component to manage local or remote data operations.

This configuration demonstrates how the `DataManager` is bound to the [SfDropDownList](https://blazor.syncfusion.com/documentation/dropdown-list/getting-started) component to enable consistent interaction with local or remote data sources.

## Local data binding

Local data can be bound to components such as `SfDropDownList` by assigning a collection of objects to the [Json](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Json) property of the `SfDataManager` component.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.DropDowns

<SfDropDownList Placeholder="e.g. Australia" TItem="Country" TValue="string">
    <SfDataManager Json="@Countries"></SfDataManager>
    <DropDownListFieldSettings Value="Name"></DropDownListFieldSettings>
</SfDropDownList>

@code 
{
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZLeCWWaPtlNQoPM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Binding DropDownList Item in Blazor DataManager Component](./images/blazor-datamanager-binding-dropdown-item.webp)" %}

## Remote data binding

Remote data can be bound by setting the [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Url) property and specifying the appropriate adaptor using the [Adaptor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Adaptor) property of the `SfDataManager` component.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.DropDowns

<SfDropDownList Placeholder="Name" TItem="Contact" TValue="Contact">
    <SfDataManager Url="https://services.odata.org/V4/Northwind/Northwind.svc/Customers" Adaptor="Adaptors.ODataV4Adaptor"></SfDataManager>
    <DropDownListFieldSettings Value="CustomerID" Text="ContactName"></DropDownListFieldSettings>
</SfDropDownList>

@code 
{
    
    public class Contact
    {
        public string? ContactName { get; set; }
        public string? CustomerID { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZheWWWamGlqvaaF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Data Binding in Blazor DataManager Component](./images/blazor-datamanager-data-binding.webp)" %}

N> [View the complete sample on GitHub.](https://github.com/SyncfusionExamples/Blazor-Getting-Started-Examples/tree/main/DataManager).

## See also

1. [Getting Started with Blazor Web Assembly App in Visual Studio or .NET CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-webassembly-app)
2. [Getting Started with Blazor Web App in Visual Studio or .NET CLI](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)

