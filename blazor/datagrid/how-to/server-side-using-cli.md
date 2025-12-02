---
layout: post
title: Add Syncfusion DataGrid to standalone Blazor Server app using .NET CLI
description: Add the Syncfusion Blazor DataGrid to a Blazor Server app using the .NET CLI on .NET 8/9, including setup, theme, scripts, and basic features.
platform: Blazor
control: DataGrid
documentation: ug
---

# Blazor DataGrid in a standalone Blazor Server app using .NET CLI

This article provides step-by-step instructions to build a standalone Blazor Server app with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid using the [.NET CLI](https://dotnet.microsoft.com/en-us/download/dotnet). The guidance aligns with .NET 8/9 Blazor Server project standards.

## Manually creating a project

This section explains how to manually create a Blazor Server app using the CLI.

### Prerequisites

Install the latest [.NET SDK](https://dotnet.microsoft.com/en-us/download) for .NET 8/9. To verify installed SDKs, run:

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet --list-sdks

{% endhighlight %}
{% endtabs %}

To check the current default .NET SDK version installed on a system, run the following command in a terminal or command prompt:

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet --version

{% endhighlight %}
{% endtabs %}

### Create a standalone Blazor Server side project using .NET Core CLI

To create a new standalone Blazor Server application using the .NET CLI, run the following command:

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet new blazorserver -o BlazorApp
cd BlazorApp

{% endhighlight %}
{% endtabs %}

This command creates a new standalone Blazor Server app and places it in a directory named BlazorApp within the current working location. For more details, refer to the [Create a Blazor app](https://dotnet.microsoft.com/en-us/learn/aspnet/blazor-tutorial/create) and [dotnet new CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new) documentation.

N> If multiple SDK versions are installed and a specific target framework (for example, net8.0/net9.0) is required, add the -f flag with the dotnet new blazorserver command. Refer to the [dotnet new options](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new) for available flags.

### Install Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid and Themes NuGet in the app

To add the `Syncfusion.Blazor.Grid` NuGet package to the application, use the following command in the command prompt (Windows) or terminal (Linux/macOS). For more details, refer to [Install and manage packages using the dotnet CLI](https://learn.microsoft.com/en-us/nuget/consume-packages/install-use-packages-dotnet-cli).

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Grid --version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes --version {{ site.releaseversion }}
dotnet restore

{% endhighlight %}
{% endtabs %}

N> Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components are available on [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to the [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for the list of available packages and component details. If a project requires a Syncfusion license key, see the [licensing](https://blazor.syncfusion.com/documentation/common/essential-studio/licensing/overview) topic to register it at startup.

### Register Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service

1. Import namespaces:

Open the **~/_Imports.razor** file and add the following namespaces:

```cshtml

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

```
2. Register the Syncfusion<sup style="font-size:70%">&reg;</sup> service:

In the **~/Program.cs** file, register the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor service as shown below:

{% tabs %}
{% highlight C# tabtitle="Blazor Server App" hl_lines="3 10" %}

using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();

var app = builder.Build();
....

{% endhighlight %}
{% endtabs %}

### Add stylesheet and script resources

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Reference the stylesheet and script in the `<head>` section of the main layout page as shown below:

* For **.NET 8 and .NET 9** Blazor Server apps, include them in the **~/Pages/_Host.cshtml** file.

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
</head>

<body>
    ....
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</body>

```
N> Review the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to learn various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in a Blazor application. Also, see [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) for approaches to add script references.

### Add Blazor DataGrid

Add the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid in the **~/Pages/Index.razor** file.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders"></SfGrid>

@code {
    public List<OrderData> Orders { get; set; }
       
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }   
}

{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();
    public OrderData()
    {

    }
    public OrderData( int? OrderID, string CustomerID)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
    }
    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            int code = 10;
            for (int i = 1; i < 2; i++)
            {
                Orders.Add(new OrderData(1, "ALFKI"));
                Orders.Add(new OrderData(2, "ALFKI"));
                Orders.Add(new OrderData(3, "ANANTR"));
                Orders.Add(new OrderData(4, "ANANTR"));
                Orders.Add(new OrderData(5, "ALFKI"));
                code += 5;
            }
        }
        return Orders;
    }
    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
}

{% endhighlight %}
{% endtabs %}

* To build and run the Blazor Server app, use the following command in the terminal or command prompt:

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet run

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjrIZoWghZXnoxDw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor DataGrid](../images/blazor-datagrid-component.png)" %}

### Defining row data

To bind data for the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, assign a `List<OrderData>` (or any collection that implements `IEnumerable<OrderData>`) to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property. The list data source can also be provided as an instance of the `DataManager`. The data source is typically assigned in the `OnInitialized` lifecycle method of the page.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders"></SfGrid>

@code {
    public List<OrderData> Orders { get; set; }
       
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }   
}

{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();
    public OrderData()
    {

    }
    public OrderData( int? OrderID, string CustomerID, DateTime? OrderDate, double? Freight)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.OrderDate = OrderDate;
        this.Freight = Freight;
    }
    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            int code = 10;
            for (int i = 1; i < 2; i++)
            {
                Orders.Add(new OrderData(10248, "VINET",new DateTime(1996,07,07), 32.38));
                Orders.Add(new OrderData(10249, "TOMSP", new DateTime(1996, 07, 07), 92.38));
                Orders.Add(new OrderData(10250, "HANAR", new DateTime(1996, 07, 07), 62.77));
                Orders.Add(new OrderData(10251, "VICTE", new DateTime(1996, 07, 07), 12.38));
                Orders.Add(new OrderData(10252, "SUPRD", new DateTime(1996, 07, 07), 82.38));
                Orders.Add(new OrderData(10253, "CHOPS", new DateTime(1996, 07, 07), 31.31));
                Orders.Add(new OrderData(10254, "RICSU", new DateTime(1996, 07, 07), 22.37));
                Orders.Add(new OrderData(10255, "WELLI", new DateTime(1996, 07, 07), 44.34));
                Orders.Add(new OrderData(10256, "RICSU", new DateTime(1996, 07, 07), 31.33));                                                                                    
                code += 5;
            }
        }
        return Orders;
    }
    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime? OrderDate { get; set; }
    public double? Freight { get; set; }
} 
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNrotoiKCoYkHoHn?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Defining columns

Columns are automatically generated when the column declaration is empty or undefined during initialization of the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid.

The Grid also supports defining columns using [GridColumns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumns.html). In `GridColumn`, several properties are available to customize column behavior.

Here are the key properties used in the example below:

* [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field) : Binds the column to a property in the data model.

* [HeaderText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_HeaderText) : Sets the displayed column title.

* [TextAlign](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_TextAlign) : Controls the horizontal alignment of cell text. By default, text is left-aligned; set this to `TextAlign.Right` to right-align.

* [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Format) : Applies standard or custom formatting to numeric and date values.

* [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Type) : Specifies the column data type.

* [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Width): Sets the column width.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="Syncfusion.Blazor.Grids.ColumnType.Date" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
   private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
       
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }       
}

{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();
    public OrderData()
    {

    }
    public OrderData( int? OrderID, string CustomerID, DateTime? OrderDate, double? Freight)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.OrderDate = OrderDate;
        this.Freight = Freight;
    }
    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            int code = 10;
            for (int i = 1; i < 2; i++)
            {
                Orders.Add(new OrderData(10248, "VINET",new DateTime(1996,07,07), 32.38));
                Orders.Add(new OrderData(10249, "TOMSP", new DateTime(1996, 07, 07), 92.38));
                Orders.Add(new OrderData(10250, "HANAR", new DateTime(1996, 07, 07), 62.77));
                Orders.Add(new OrderData(10251, "VICTE", new DateTime(1996, 07, 07), 12.38));
                Orders.Add(new OrderData(10252, "SUPRD", new DateTime(1996, 07, 07), 82.38));
                Orders.Add(new OrderData(10253, "CHOPS", new DateTime(1996, 07, 07), 31.31));
                Orders.Add(new OrderData(10254, "RICSU", new DateTime(1996, 07, 07), 22.37));
                Orders.Add(new OrderData(10255, "WELLI", new DateTime(1996, 07, 07), 44.34));
                Orders.Add(new OrderData(10256, "RICSU", new DateTime(1996, 07, 07), 31.33));                                                                                    
                code += 5;
            }
        }
        return Orders;
    }
    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime? OrderDate { get; set; }
    public double? Freight { get; set; }
} 
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNLyNosqiEMHcPrL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Enable paging

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can display records in a paged format. To enable paging, set the [AllowPaging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowPaging) property to **true**. Customize the pager using the [GridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PageSettings).

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true">
     <GridPageSettings PageSize="5"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="Syncfusion.Blazor.Grids.ColumnType.Date" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> Orders { get; set; }
       
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }       
}

{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();
    public OrderData()
    {

    }
    public OrderData( int? OrderID, string CustomerID, DateTime? OrderDate, double? Freight)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.OrderDate = OrderDate;
        this.Freight = Freight;
    }
    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            int code = 10;
            for (int i = 1; i < 2; i++)
            {
                Orders.Add(new OrderData(10248, "VINET",new DateTime(1996,07,07), 32.38));
                Orders.Add(new OrderData(10249, "TOMSP", new DateTime(1996, 07, 07), 92.38));
                Orders.Add(new OrderData(10250, "HANAR", new DateTime(1996, 07, 07), 62.77));
                Orders.Add(new OrderData(10251, "VICTE", new DateTime(1996, 07, 07), 12.38));
                Orders.Add(new OrderData(10252, "SUPRD", new DateTime(1996, 07, 07), 82.38));
                Orders.Add(new OrderData(10253, "CHOPS", new DateTime(1996, 07, 07), 31.31));
                Orders.Add(new OrderData(10254, "RICSU", new DateTime(1996, 07, 07), 22.37));
                Orders.Add(new OrderData(10255, "WELLI", new DateTime(1996, 07, 07), 44.34));
                Orders.Add(new OrderData(10256, "RICSU", new DateTime(1996, 07, 07), 31.33));                                                                                    
                code += 5;
            }
        }
        return Orders;
    }
    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime? OrderDate { get; set; }
    public double? Freight { get; set; }
} 
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNrejSMgCdnGAijD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Enable sorting

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can sort records in ascending or descending order. To enable sorting, set the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) property to **true**. Customize sorting using the [GridSortSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SortSettings).

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowSorting="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="Syncfusion.Blazor.Grids.ColumnType.Date" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> Orders { get; set; }
       
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }       
}

{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();
    public OrderData()
    {

    }
    public OrderData( int? OrderID, string CustomerID, DateTime? OrderDate, double? Freight)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.OrderDate = OrderDate;
        this.Freight = Freight;
    }
    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            int code = 10;
            for (int i = 1; i < 2; i++)
            {
                Orders.Add(new OrderData(10248, "VINET",new DateTime(1996,07,07), 32.38));
                Orders.Add(new OrderData(10249, "TOMSP", new DateTime(1996, 07, 07), 92.38));
                Orders.Add(new OrderData(10250, "HANAR", new DateTime(1996, 07, 07), 62.77));
                Orders.Add(new OrderData(10251, "VICTE", new DateTime(1996, 07, 07), 12.38));
                Orders.Add(new OrderData(10252, "SUPRD", new DateTime(1996, 07, 07), 82.38));
                Orders.Add(new OrderData(10253, "CHOPS", new DateTime(1996, 07, 07), 31.31));
                Orders.Add(new OrderData(10254, "RICSU", new DateTime(1996, 07, 07), 22.37));
                Orders.Add(new OrderData(10255, "WELLI", new DateTime(1996, 07, 07), 44.34));
                Orders.Add(new OrderData(10256, "RICSU", new DateTime(1996, 07, 07), 31.33));                                                                                    
                code += 5;
            }
        }
        return Orders;
    }
    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime? OrderDate { get; set; }
    public double? Freight { get; set; }
} 
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZhSXosACxQRZrki?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Enable filtering

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can filter records to display only those that meet specific criteria. To enable filtering, set the [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowFiltering) property to **true**. Customize filtering behavior using the [GridFilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FilterSettings).

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowFiltering="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="Syncfusion.Blazor.Grids.ColumnType.Date" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> Orders { get; set; }
       
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }       
}

{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();
    public OrderData()
    {

    }
    public OrderData( int? OrderID, string CustomerID, DateTime? OrderDate, double? Freight)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.OrderDate = OrderDate;
        this.Freight = Freight;
    }
    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            int code = 10;
            for (int i = 1; i < 2; i++)
            {
                Orders.Add(new OrderData(10248, "VINET",new DateTime(1996,07,07), 32.38));
                Orders.Add(new OrderData(10249, "TOMSP", new DateTime(1996, 07, 07), 92.38));
                Orders.Add(new OrderData(10250, "HANAR", new DateTime(1996, 07, 07), 62.77));
                Orders.Add(new OrderData(10251, "VICTE", new DateTime(1996, 07, 07), 12.38));
                Orders.Add(new OrderData(10252, "SUPRD", new DateTime(1996, 07, 07), 82.38));
                Orders.Add(new OrderData(10253, "CHOPS", new DateTime(1996, 07, 07), 31.31));
                Orders.Add(new OrderData(10254, "RICSU", new DateTime(1996, 07, 07), 22.37));
                Orders.Add(new OrderData(10255, "WELLI", new DateTime(1996, 07, 07), 44.34));
                Orders.Add(new OrderData(10256, "RICSU", new DateTime(1996, 07, 07), 31.33));                                                                                    
                code += 5;
            }
        }
        return Orders;
    }
    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime? OrderDate { get; set; }
    public double? Freight { get; set; }
} 

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDrIDoMqsHPeUEtz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Enable grouping

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can group records by one or more columns. To enable grouping, set the [AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowGrouping) property to **true**. Customize grouping behavior using the [GridGroupSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GroupSettings).

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowGrouping="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="Syncfusion.Blazor.Grids.ColumnType.Date" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderData> Orders { get; set; }
       
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }       
}

{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();
    public OrderData()
    {

    }
    public OrderData( int? OrderID, string CustomerID, DateTime? OrderDate, double? Freight)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.OrderDate = OrderDate;
        this.Freight = Freight;
    }
    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            int code = 10;
            for (int i = 1; i < 2; i++)
            {
                Orders.Add(new OrderData(10248, "VINET",new DateTime(1996,07,07), 32.38));
                Orders.Add(new OrderData(10249, "TOMSP", new DateTime(1996, 07, 07), 92.38));
                Orders.Add(new OrderData(10250, "HANAR", new DateTime(1996, 07, 07), 62.77));
                Orders.Add(new OrderData(10251, "VICTE", new DateTime(1996, 07, 07), 12.38));
                Orders.Add(new OrderData(10252, "SUPRD", new DateTime(1996, 07, 07), 82.38));
                Orders.Add(new OrderData(10253, "CHOPS", new DateTime(1996, 07, 07), 31.31));
                Orders.Add(new OrderData(10254, "RICSU", new DateTime(1996, 07, 07), 22.37));
                Orders.Add(new OrderData(10255, "WELLI", new DateTime(1996, 07, 07), 44.34));
                Orders.Add(new OrderData(10256, "RICSU", new DateTime(1996, 07, 07), 31.33));                                                                                    
                code += 5;
            }
        }
        return Orders;
    }
    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime? OrderDate { get; set; }
    public double? Freight { get; set; }
} 

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZBoZosUMRYBBVqA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor DataGrid](../images/blazor-datagrid.gif)" %}

> Find the sample in this [GitHub location](https://github.com/SyncfusionExamples/How-to-Getting-Started-Blazor-DataGrid-Samples/tree/master/BlazorServerApp).

## See also

* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> DataGrid in Blazor Server-Side using Visual Studio 2022](../getting-started-with-server-app.md)

* [Getting started with Syncfusion<sup style="font-size:70%">&reg;</sup> Data Grid in Blazor WebAssembly App using .NET Core CLI](./blazor-webassembly-data-grid-using-cli)

* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> DataGrid in Blazor WebAssembly using Visual Studio 2022](../getting-started.md)