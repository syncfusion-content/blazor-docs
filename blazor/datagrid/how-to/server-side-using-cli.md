---
layout: post
title: Add Blazor DataGrid to a Server-Side App via .NET CLI | Syncfusion
description: Check out the documentation for getting started with the Syncfusion Blazor DataGrid in a server-side app using the .NET CLI and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Blazor DataGrid in Server Side App using CLI

This article provides a step-by-step instructions to build a Blazor Server App with Syncfusion Blazor DataGrid using the [.NET CLI](https://dotnet.microsoft.com/en-us/download/dotnet).

## Manually creating a project

This section provides a brief explanation on how to manually create a Blazor Server App using CLI.

### Prerequisites

Ensure you have the latest version of the [.NET Core SDK](https://dotnet.microsoft.com/en-us/download) installed.
To check the installed version, run the following command in a command prompt (Windows), terminal (macOS), or shell (Linux):

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet --version

{% endhighlight %}
{% endtabs %}

### Create a Blazor Server side project using .NET Core CLI

To create a new Blazor Server application, open your terminal or command prompt and run:

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet new blazorserver -o BlazorApp
cd BlazorApp

{% endhighlight %}
{% endtabs %}

This command creates new Blazor app project and places it in a new directory called BlazorApp inside your current location. See [Create Blazor app topic](https://dotnet.microsoft.com/en-us/learn/aspnet/blazor-tutorial/create) and [dotnet new CLI](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new) command topics for more details.

N> If you have installed multiple SDK versions and need any specific framework version (net5.0/netcoreapp3.1) project, then add -f flag along with dotnet new blazorserver comment. Refer [here](https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-new) for the available options.

### Install Syncfusion Blazor DataGrid and Themes NuGet in the app

To add the `Syncfusion.Blazor.Grid` NuGet package to your application, use the following command in the command prompt (Windows) or terminal (Linux/macOS). For more details, refer to the [Install and manage packages using the dotnet CLI](https://learn.microsoft.com/en-us/nuget/consume-packages/install-use-packages-dotnet-cli).

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet add package Syncfusion.Blazor.Grid --version {{ site.releaseversion }}
dotnet add package Syncfusion.Blazor.Themes --version {{ site.releaseversion }}
dotnet restore

{% endhighlight %}
{% endtabs %}

N> Syncfusion Blazor components are available in [nuget.org](https://www.nuget.org/packages?q=syncfusion.blazor). Refer to [NuGet packages](https://blazor.syncfusion.com/documentation/nuget-packages) topic for available NuGet packages list with component details.

### Register Syncfusion Blazor service

1. Import namespaces:

Open the **~/_Imports.razor** file and add the following namespaces:

```cshtml

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

```
2. Register the Syncfusion service:

In your **~/Program.cs** file, register the Syncfusion Blazor service as shown below:

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

The theme stylesheet and script can be accessed from NuGet through [Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets). Reference the stylesheet and script in the `<head>` section of your main layout page as shown below:

* For **.NET 6** Blazor Server app, include it in **~/Pages/_Layout.cshtml** file.

* For **.NET 7,8,9 and 10** Blazor Server app, include it in the **~/Pages/_Host.cshtml** file.

```html
<head>
    ....
    <link href="_content/Syncfusion.Blazor.Themes/bootstrap5.css" rel="stylesheet" />
    <script src="_content/Syncfusion.Blazor.Core/scripts/syncfusion-blazor.min.js" type="text/javascript"></script>
</head>
```
N> Check out the [Blazor Themes](https://blazor.syncfusion.com/documentation/appearance/themes) topic to discover various methods ([Static Web Assets](https://blazor.syncfusion.com/documentation/appearance/themes#static-web-assets), [CDN](https://blazor.syncfusion.com/documentation/appearance/themes#cdn-reference), and [CRG](https://blazor.syncfusion.com/documentation/common/custom-resource-generator)) for referencing themes in your Blazor application. Also, check out the [Adding Script Reference](https://blazor.syncfusion.com/documentation/common/adding-script-references) topic to learn different approaches for adding script references in your Blazor application.

### Add Blazor DataGrid

Add the Syncfusion Blazor DataGrid in the **~/Pages/Index.razor** file.

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

* To build and run the Blazor Server App, use the following command in your terminal or command prompt:

{% tabs %}
{% highlight c# tabtitle=".NET CLI" %}

dotnet run

{% endhighlight %}
{% endtabs %}

![Blazor DataGrid](../images/blazor-datagrid-component.png)

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjrIZoWghZXnoxDw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Defining row data

To bind data for the Syncfusion Blazor DataGrid, assign a `List<OrderData>` (or any other collection that implements `IEnumerable<OrderData>`) to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property. The list data source can also be provided as an instance of the `DataManager`. You can assign the data source through the `OnInitialized` life cycle of the page.

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

The columns are automatically generated when columns declaration is empty or undefined while initializing the Syncfusion Blazor DataGrid.

The Grid has an option to define columns using [GridColumns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumns.html). In `GridColumn` we have properties to customize columns.

Here are the key properties used in the example below:

* [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Field) : Binds the column to a property on your data model.

* [HeaderText](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_HeaderText) : Sets the displayed column title.

* [TextAlign](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_TextAlign) : Controls the horizontal alignment of cell text. By default, text is left-aligned; set this to `TextAlign.Right` to right-align.

* [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Format) : Applies standard or custom formatting to numeric and date values.

* [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Type) : Specifies the column data type.

* [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Width): Sets the column’s width.

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

The Syncfusion Blazor DataGrid can display records in a paged format. To enable paging, set the [AllowPaging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowPaging) property to **true**. You can customize the pager using the [GridPageSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PageSettings).

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

The Syncfusion Blazor DataGrid can sort records in ascending or descending order. To enable sorting, set the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) property to **true**. You can customize the sorting using the [GridSortSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SortSettings).

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

The Syncfusion Blazor DataGrid can filter records to display only those that meet specific criteria. To enable filtering, set the [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowFiltering) property to **true**. You can customize the filtering behavior using the [GridFilterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FilterSettings).

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

The Syncfusion Blazor DataGrid can group records by one or more columns. To enable grouping, set the [AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowGrouping) property to **true**. You can customize grouping behavior using the [GridGroupSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GroupSettings).

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZBoZosUMRYBBVqA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor DataGrid](../images/blazor-datagrid.gif)

> Please find the sample in this [GitHub location](https://github.com/SyncfusionExamples/How-to-Getting-Started-Blazor-DataGrid-Samples/tree/master/BlazorServerApp).

## See also

* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> DataGrid in Blazor Server-Side using Visual Studio 2022](../getting-started)

* [Getting started with Syncfusion<sup style="font-size:70%">&reg;</sup> Data Grid in Blazor WebAssembly App using .NET Core CLI](./blazor-webassembly-data-grid-using-cli)

* [Getting Started with Syncfusion<sup style="font-size:70%">&reg;</sup> DataGrid in Blazor WebAssembly using Visual Studio 2022](./blazor-webassembly-datagrid-using-visual-studio)
