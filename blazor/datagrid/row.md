---
layout: post
title: Blazor Grid Row Customization | Syncfusion
description: Learn how to customize rows in Blazor Data Grid with row styles, heights, hover effects, pinning, and advanced row settings.
documentation: ug
---

# Row Customization in Blazor Data Grid

Each row represents a single record from a data source and displays values for the fields of that record in a tabular format. Rows in the [Blazor Data Grid](https://www.syncfusion.com/blazor-components/blazor-datagrid) support interaction such as selection, editing, sorting, filtering, and event-driven behaviors.

## Customize row styles

Customizing row styles helps emphasize important data, align with application themes, and improve readability. The Blazor Data Grid supports styling through CSS, properties, methods, and events.

### Using event

Customize row appearance using the [RowDataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowDataBound) event, which triggers for each row when it is bound to data. The [RowDataBoundEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.RowDataBoundEventArgs-1.html) provides the `Row` object with methods like `AddClass()` to apply custom classes, along with the bound data for conditional styling.

The `RowDataBound` handler applies CSS classes to rows based on the value of the `Freight` column. Define the CSS classes `below-30`, `below-80`, and `above-80` in the stylesheet to apply the corresponding styles:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders">
    <GridEvents TValue="OrderData" RowDataBound="RowBound"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="80"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>
<style>
    .below-30 {
        background-color: rgb(211, 225, 248);
    }
    .below-80 {
        background-color: rgb(163, 236, 217);
    }
    .above-80 {
        background-color: rgb(220, 248, 177);
    }
</style>

@code {
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
    public void RowBound(RowDataBoundEventArgs<OrderData> args)
    {
        if (args.Data.Freight < 30)
        {
            args.Row.AddClass(new string[] { "below-30" });
        }
        else if (args.Data.Freight < 80)
        {
            args.Row.AddClass(new string[] { "below-80" });
        }
        else
        {
            args.Row.AddClass(new string[] { "above-80" });
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData() { }

    public OrderData(int? OrderID, string CustomerID, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims"));
            Orders.Add(new OrderData(10249, "TOMSP", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster"));
            Orders.Add(new OrderData(10250, "HANAR", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro"));
            Orders.Add(new OrderData(10251, "VINET", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon"));
            Orders.Add(new OrderData(10252, "SUPRD", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi"));
            Orders.Add(new OrderData(10253, "HANAR", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern"));
            Orders.Add(new OrderData(10254, "CHOPS", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève"));
            Orders.Add(new OrderData(10255, "VINET", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende"));
            Orders.Add(new OrderData(10256, "HANAR", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris"));
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string ShipCity { get; set; } 
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNhnjbrAyzHOCGFB?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

> The [QueryCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_QueryCellInfo) event customizes individual cells and triggers for every cell. Use it when styling is required at the cell level based on conditions.

### Using CSS

Apply styles to rows using CSS selectors. Each row element exposes class names that can be targeted for customization.

**Customize alternate rows**

Alternate rows can be styled to enhance readability. The Data Grid applies the CSS class `.e-altrow` to alternate rows. Override this class to apply custom styles.

To change the background color of alternate rows, add the following CSS:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="80"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>
<style>
    .e-grid .e-altrow {
        background-color: #aaf1eb;
    }
</style>

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

    public OrderData() { }

    public OrderData(int? OrderID, string CustomerID, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims"));
            Orders.Add(new OrderData(10249, "TOMSP", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster"));
            Orders.Add(new OrderData(10250, "HANAR", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro"));
            Orders.Add(new OrderData(10251, "VINET", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon"));
            Orders.Add(new OrderData(10252, "SUPRD", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi"));
            Orders.Add(new OrderData(10253, "HANAR", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern"));
            Orders.Add(new OrderData(10254, "CHOPS", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève"));
            Orders.Add(new OrderData(10255, "VINET", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende"));
            Orders.Add(new OrderData(10256, "HANAR", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris"));
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string ShipCity { get; set; } 
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjBHDvhqSTGTezjK?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

**Customize selected row**

Customize the selected row using CSS to clearly highlight the active selection. Override the default `.e-selectionbackground` class to apply custom styles.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid ID="CustomGrid" DataSource="@Orders">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="80"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    #CustomGrid .e-selectionbackground {
        background-color: #f9920b;
    }
</style>


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

    public OrderData() { }

    public OrderData(int? OrderID, string CustomerID, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims"));
            Orders.Add(new OrderData(10249, "TOMSP", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster"));
            Orders.Add(new OrderData(10250, "HANAR", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro"));
            Orders.Add(new OrderData(10251, "VINET", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon"));
            Orders.Add(new OrderData(10252, "SUPRD", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi"));
            Orders.Add(new OrderData(10253, "HANAR", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern"));
            Orders.Add(new OrderData(10254, "CHOPS", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève"));
            Orders.Add(new OrderData(10255, "VINET", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende"));
            Orders.Add(new OrderData(10256, "HANAR", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris"));
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string ShipCity { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDVxNlrAepvnjpmk?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Row height

The Blazor DataGrid supports customizing row height to display more or less content as needed. Use the [RowHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RowHeight) property to change the height of all rows in the Grid.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div>
    <SfButton class="e-btn e-small" @onclick="() => ChangeRowHeight(20)">Change height 20px</SfButton>
    <SfButton class="e-btn e-small" @onclick="() => ChangeRowHeight(42)">Default height 42px</SfButton>
    <SfButton class="e-btn e-small" @onclick="() => ChangeRowHeight(60)">Change height 60px</SfButton>
</div>

<div style="padding-top:20px">
    <SfGrid @ref="Grid" DataSource="@Orders" RowHeight="@RowHeightValue" Height="400">
        <GridColumns>
            <GridColumn Field="OrderID" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
            <GridColumn Field="CustomerID" HeaderText="Customer Name" Width="150"></GridColumn>
            <GridColumn Field="OrderDate" HeaderText="Order Date" Width="130" Type="ColumnType.Date" Format="dd/MM/yyyy" TextAlign="TextAlign.Right"></GridColumn>
            <GridColumn Field="Freight" HeaderText="Freight" Width="120" Format="C2" TextAlign="TextAlign.Right"></GridColumn>
            <GridColumn Field="ShippedDate" HeaderText="Shipped Date" Width="140" Type="ColumnType.Date" Format="dd/MM/yyyy" TextAlign="TextAlign.Right"></GridColumn>
            <GridColumn Field="ShipCountry" HeaderText="Ship Country" Width="150"></GridColumn>
        </GridColumns>
    </SfGrid>
</div>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
    public int RowHeightValue { get; set; } = 42; // Default height.

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    private async Task ChangeRowHeight(int height)
    {
        RowHeightValue = height;
        await Grid.Refresh();
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData() { }

    public OrderData(int? OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipName = ShipName;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France"));
            Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany"));
            Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "Brazil"));
            Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France"));
            Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium"));
            Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland"));
            Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland"));
            Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "Brazil"));
            Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France"));
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipName { get; set; } 
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDLRNcZxBjNTyCNC?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

> The `RowHeight` property sets the height for all Data Grid rows. It does not configure individual cell heights.
> Row height for a specific row can be customized by adding a row-level CSS class in the [RowDataBound](https://blazor.syncfusion.com/documentation/datagrid/events#rowdatabound) event.

### Customize row height for particular row

Customize the row height for a specific row when rows require additional space, for example, to accommodate multi-line content. Use the [RowHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RowHeight) property in combination with the [RowDataBound](https://blazor.syncfusion.com/documentation/datagrid/events#rowdatabound) event to apply a CSS class conditionally.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" Height="315px">
    <GridEvents TValue="OrderData" RowDataBound="RowBound"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="90" IsPrimaryKey="true"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
       <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Width="80"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>

    </GridColumns>
</SfGrid>
<style>
    .row-height {
        height: 90px;
    }
</style>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
    public void RowBound(RowDataBoundEventArgs<OrderData> args)
    {
        if (args.Data.OrderID == 10249)
        {
            args.Row.AddClass(new string[] { "row-height" });
        }
    }
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

    public OrderData() { }

    public OrderData(int? OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipName = ShipName;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France"));
            Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany"));
            Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "Brazil"));
            Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France"));
            Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium"));
            Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland"));
            Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland"));
            Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "Brazil"));
            Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France"));
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipName { get; set; } 
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjVRXlLgezkvoVUA?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Row hover

The row hover feature applies a visual effect when the mouse pointer is over a row, improving readability and helping to identify the focused record. Enable or disable the effect using the [EnableHover](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableHover) property.

By default, `EnableHover` is **true**. Set it to **false** to disable row hover.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="padding:20px">
    <label>Enable/Disable Row Hover</label>
    <SfSwitch @bind-Checked="isChecked" TChecked="bool"></SfSwitch>
</div>
<SfGrid @ref="Grid" DataSource="@Orders" Height="400" EnableHover="@isChecked">
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="CustomerID" HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field="ShipCity" HeaderText="Ship City" Width="150"></GridColumn>
        <GridColumn Field="ShipName" HeaderText="Ship Name" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
    private bool isChecked = true;

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

    public OrderData() { }

    public OrderData(int? OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipName = ShipName;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France"));
            Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany"));
            Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "Brazil"));
            Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France"));
            Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium"));
            Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland"));
            Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland"));
            Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "Brazil"));
            Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France"));
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipName { get; set; } 
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXLRtmtnBjLWvIBj?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

> The `EnableHover` property applies to the entire Data Grid rather than to specific rows or columns.

## Row pinning (Frozen)

The Blazor Data Grid provides an option to freeze rows, keeping them visible while scrolling vertically through large datasets. This feature helps maintain important information in view for better readability.

{% youtube "youtube:https://www.youtube.com/watch?v=L2NvKyBomhM"%}

The [FrozenRows](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FrozenRows) property is set to `2`. The top two rows remain fixed while the rest of the Data Grid scrolls vertically:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="display: flex; align-items: center; padding-bottom: 20px;">
    <label style="padding-right: 10px; font-weight: bold;">Change the frozen rows:</label>
    <SfNumericTextBox @bind-Value="NumericValue" TValue="int" Min="1" Max="5" Decimals="0"
    ValidateDecimalOnType="true" Width="150px">
    </SfNumericTextBox>
</div>

<SfGrid @ref="Grid" DataSource="@Orders" AllowSelection="false" EnableHover="false"
        FrozenRows="@NumericValue" Height="315px">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" TextAlign="TextAlign.Right" Width="100" Type="ColumnType.Date" Format="dd/MM/yyyy"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="130"></GridColumn>
       <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Width="100"></GridColumn>
       <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Width="80"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
    public int NumericValue { get; set; } = 2;

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

    public OrderData() { }

    public OrderData(int? OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipName = ShipName;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France"));
            Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany"));
            Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "Brazil"));
            Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France"));
            Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium"));
            Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland"));
            Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland"));
            Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "Brazil"));
            Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France"));
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipName { get; set; } 
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXhdjPrKeSeYyupt?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

> Frozen rows should remain within the Data Grid viewport.
> Frozen Data Grid supports row virtualization to improve performance with large datasets.
> The frozen feature applies to rows visible in the current view.
> [FrozenColumns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FrozenColumns) and [FrozenRows](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FrozenRows) can be used together in the same Data Grid.
> The `FrozenRows` value must not exceed the number of visible data rows.

### Change default frozen rows line color

The frozen row background color in the Blazor Data Grid can be customized by applying CSS styles, allowing alignment with the application's theme.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfGrid @ref="Grid" DataSource="@Orders" AllowSelection="false" EnableHover="false"
        FrozenRows="3" Height="315px">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" TextAlign="TextAlign.Right" Width="100" Type="ColumnType.Date" Format="dd/MM/yyyy"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="130"></GridColumn>
       <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Width="100"></GridColumn>
       <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Width="80"></GridColumn>
    </GridColumns>
</SfGrid>
<style>
    .e-grid .e-frozenrow-border {
        background-color: rgb(5, 114, 47);
    }
</style>

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

    public OrderData() { }

    public OrderData(int? OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipName = ShipName;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France"));
            Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany"));
            Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "Brazil"));
            Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France"));
            Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium"));
            Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland"));
            Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland"));
            Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "Brazil"));
            Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France"));
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipName { get; set; } 
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjBxjmZHrjmdCCjF?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

> When a validation message is displayed in a frozen column area (Left, Right, or Fixed), scrolling is blocked until the message is cleared. For details, see [Frozen columns](https://blazor.syncfusion.com/documentation/datagrid/frozen-column).

### Limitations

Frozen row is not compatible with the Autofill feature.

## Adding a new row programmatically

The Blazor Data Grid supports programmatically adding new rows using the [AddRecordAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AddRecordAsync) method. This is useful when inserting records without manual entry through the UI.

The `AddRecordAsync` method supports overloads with the following parameters:

 - The **data** object representing the new row to be added  
 - The optional **index** at which the new row should be inserted. If no index is specified, the new row is added at the end.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="padding: 0px 0px 20px 0px">
    <SfButton CssClass="e-primary" @onclick="AddRow">Add New Row</SfButton>
</div>

<SfGrid @ref="Grid" DataSource="@Orders">
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field="@nameof(OrderData.OrderID)" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100" IsPrimaryKey="true"></GridColumn>
        <GridColumn Field="@nameof(OrderData.CustomerID)" HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field="@nameof(OrderData.ShipCity)" HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field="@nameof(OrderData.Freight)" HeaderText="Freight" TextAlign="TextAlign.Right" Format="C" Width="100"></GridColumn>
        <GridColumn Field="@nameof(OrderData.ShipName)" HeaderText="Ship Name" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
    private static readonly Random _random = new Random();

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    public async Task AddRow()
    {
        var newRecord = new OrderData
            {
                OrderID = GenerateOrderId(),
                CustomerID = GenerateCustomerId(),
                ShipCity = GenerateShipCity(),
                Freight = GenerateFreight(),
                ShipName = GenerateShipName()
            };

        // Add the new record to the Grid.
        await Grid.AddRecordAsync(newRecord, 0);
    }

    private int GenerateOrderId()
    {
        return _random.Next(10000, 99999); // Random Order ID.
    }

    private string GenerateCustomerId()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        return new string(Enumerable.Repeat(chars, 5).Select(s => s[_random.Next(s.Length)]).ToArray());
    }

    private string GenerateShipCity()
    {
        string[] cities = { "London", "Paris", "New York", "Tokyo", "Berlin" };
        return cities[_random.Next(cities.Length)];
    }

    private double GenerateFreight()
    {
        return _random.NextDouble() * 100; // Random Freight value.
    }

    private string GenerateShipName()
    {
        string[] names = { "Que Delícia", "Bueno Foods", "Island Trading", "Laughing Bacchus Winecellars" };
        return names[_random.Next(names.Length)];
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData() { }

    public OrderData(int? OrderID, string CustomerID, string ShipName, double Freight, DateTime? OrderDate, DateTime? ShippedDate, bool? IsVerified, string ShipCity, string ShipCountry)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.ShipName = ShipName;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShippedDate = ShippedDate;
        this.IsVerified = IsVerified;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Vins et alcools Chevalier", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 08, 07), true, "Reims", "France"));
            Orders.Add(new OrderData(10249, "TOMSP", "Toms Spezialitäten", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 08, 07), false, "Münster", "Germany"));
            Orders.Add(new OrderData(10250, "HANAR", "Hanari Carnes", 65.83, new DateTime(1996, 7, 6), new DateTime(1996, 08, 07), true, "Rio de Janeiro", "Brazil"));
            Orders.Add(new OrderData(10251, "VINET", "Vins et alcools Chevalier", 41.34, new DateTime(1996, 7, 7), new DateTime(1996, 08, 07), false, "Lyon", "France"));
            Orders.Add(new OrderData(10252, "SUPRD", "Suprêmes délices", 151.30, new DateTime(1996, 7, 8), new DateTime(1996, 08, 07), true, "Charleroi", "Belgium"));
            Orders.Add(new OrderData(10253, "HANAR", "Hanari Carnes", 58.17, new DateTime(1996, 7, 9), new DateTime(1996, 08, 07), false, "Bern", "Switzerland"));
            Orders.Add(new OrderData(10254, "CHOPS", "Chop-suey Chinese", 22.98, new DateTime(1996, 7, 10), new DateTime(1996, 08, 07), true, "Genève", "Switzerland"));
            Orders.Add(new OrderData(10255, "VINET", "Vins et alcools Chevalier", 148.33, new DateTime(1996, 7, 11), new DateTime(1996, 08, 07), false, "Resende", "Brazil"));
            Orders.Add(new OrderData(10256, "HANAR", "Hanari Carnes", 13.97, new DateTime(1996, 7, 12), new DateTime(1996, 08, 07), true, "Paris", "France"));
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipName { get; set; } 
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public DateTime? ShippedDate { get; set; }
    public bool? IsVerified { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDVRtmXRLDPXXeAX?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

> When working with remote data, adding a new row between existing rows is not supported.
> To insert a new record at the beginning, pass 0 as the second parameter to `AddRecordAsync`.
> If no index is specified, the new row is added at the end.

## Get row indexes

The Blazor Data Grid exposes methods to retrieve row indexes for custom operations. The row-index methods use zero-based indexes.

1. [GetRowIndexByPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetRowIndexByPrimaryKeyAsync_System_Object_): Retrieves a `Task<int>` containing the row index for a primary key value or row data. The method returns `-1` when no matching row exists.

```cs
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton id="GetRowIndexByPrimaryKey" @onclick="GetDataHandler">Get Row Index</SfButton>
<SfGrid @ref="Grid" DataSource="@Orders">
    <!-- Add GridColumn declarations here. -->
</SfGrid>
@code{
    private SfGrid<OrderData> Grid;
    private List<OrderData> Orders = new() { new OrderData { OrderID = 10250 } };

    private async Task GetDataHandler()
    {
        int rowIndex = await Grid.GetRowIndexByPrimaryKeyAsync(10250);
    }

    private class OrderData
    {
        public int OrderID { get; set; }
    }
}
```

2. [GetSelectedRowIndexesAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetSelectedRowIndexesAsync): Retrieves a `Task<List<int>>` containing the collection of selected row indexes.

```cs
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton id="GetSelectedRowIndexes" @onclick="GetDataHandler">Get Selected Row Indexes</SfButton>
<SfGrid @ref="Grid" DataSource="@Orders">
    <!-- Add GridColumn declarations here. -->
</SfGrid>
@code{
    private SfGrid<OrderData> Grid;
    private List<OrderData> Orders = new() { new OrderData { OrderID = 10250 } };

    private async Task GetDataHandler()
    {
        List<int> selectedRowIndexes = await Grid.GetSelectedRowIndexesAsync();
    }

    private class OrderData
    {
        public int OrderID { get; set; }
    }
}
```

## Master Detail Data Grid

The Blazor Data Grid can display related details in another Data Grid using a master-detail layout. Selecting a row in the master Data Grid loads related records in the detail Data Grid.

Use the [RowSelected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowSelected) event on the master Data Grid to obtain the selected record. Apply a filter through the [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Query) property of the detail Data Grid and bind the resulting collection to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource). The `Query` property accepts a `Query` object with methods like `Where()` to apply filter conditions.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data

<SfGrid SelectedRowIndex=2 DataSource="@Employees">                
    <GridEvents RowSelected="RowSelecthandler" TValue="EmployeeData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.CustomerName) HeaderText="Customer Name" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(EmployeeData.CompanyName) HeaderText="Company Name" Width="110"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Address) Width="110"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Country) Width="110"></GridColumn>
    </GridColumns>
</SfGrid>
<br>
<div class='e-statustext'>Showing orders of Customer: <b>@SelectedCustomer</b></div>

<SfGrid DataSource="@GridData" Query="@(new Query().Where("EmployeeID", "equal", RowIndex))">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(Order.ShipName) HeaderText="Ship Name" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipAddress) HeaderText="Ship Address" Width="110"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public IEnumerable<Order> GridData { get; set; }
    public string SelectedCustomer { get; set; }
    public int? RowIndex { get; set; } = 1003;

    public void RowSelecthandler(RowSelectEventArgs<EmployeeData> Args)
    {
        SelectedCustomer = Args.Data.CustomerName;
        RowIndex = Args.Data.EmployeeID;
    }

    List<EmployeeData> Employees = new List<EmployeeData>
    {
        new EmployeeData() {EmployeeID = 1001, CustomerName="Thomas Hardy", CompanyName="Around the Horn", Address="120 Hanover Sq.", Country="UK"},
        new EmployeeData() {EmployeeID = 1002, CustomerName="Christina Berglund", CompanyName="Berglunds snabbköp", Address="Berguvsvägen 8", Country="Sweden"},
        new EmployeeData() {EmployeeID = 1003, CustomerName="Frédérique Citeaux", CompanyName="Blondesddsl père et fils", Address="24, place Kléber", Country="France"},
        new EmployeeData() {EmployeeID = 1004, CustomerName="Yang Wang", CompanyName="Chop-suey Chinese", Address="Hauptstr. 29", Country="Switzerland"},
        new EmployeeData() {EmployeeID = 1005, CustomerName="Roland Mendel", CompanyName="Ernst Handel", Address="Kirchgasse 6", Country="Austria"},
    };
    List<Order> Orders = new List<Order> {
        new Order() {EmployeeID = 1001, OrderID=1, ShipName="Around the Horn", ShipCountry="UK", ShipAddress="Brook Farm Stratford St. Mary"},
        new Order() {EmployeeID = 1001, OrderID=2, ShipName="Around the Horn", ShipCountry="UK", ShipAddress="Brook Farm Stratford St. Mary"},
        new Order() {EmployeeID = 1001, OrderID=3, ShipName="Around the Horn", ShipCountry="UK", ShipAddress="Brook Farm Stratford St. Mary"},
        new Order() {EmployeeID = 1001, OrderID=4, ShipName="Around the Horn", ShipCountry="UK", ShipAddress="Brook Farm Stratford St. Mary"},
        new Order() {EmployeeID = 1001, OrderID=5, ShipName="Around the Horn", ShipCountry="UK", ShipAddress="Brook Farm Stratford St. Mary"},
        new Order() {EmployeeID = 1002, OrderID=6, ShipName="Berglunds snabbköp", ShipCountry="Sweden", ShipAddress="Berguvsvägen 8"},
        new Order() {EmployeeID = 1002, OrderID=7, ShipName="Berglunds snabbköp", ShipCountry="Sweden", ShipAddress="Berguvsvägen 8"},
        new Order() {EmployeeID = 1002, OrderID=8, ShipName="Berglunds snabbköp", ShipCountry="Sweden", ShipAddress="Berguvsvägen 8"},
        new Order() {EmployeeID = 1002, OrderID=9, ShipName="Berglunds snabbköp", ShipCountry="Sweden", ShipAddress="Berguvsvägen 8"},
        new Order() {EmployeeID = 1002, OrderID=10, ShipName="Berglunds snabbköp", ShipCountry="Sweden", ShipAddress="Berguvsvägen 8"},
        new Order() {EmployeeID = 1003, OrderID=11, ShipName="Blondel père et fils", ShipCountry="France", ShipAddress="24, place Kléber"},
        new Order() {EmployeeID = 1003, OrderID=12, ShipName="Blondel père et fils", ShipCountry="France", ShipAddress="24, place Kléber"},
        new Order() {EmployeeID = 1003, OrderID=13, ShipName="Blondel père et fils", ShipCountry="France", ShipAddress="24, place Kléber"},
        new Order() {EmployeeID = 1003, OrderID=14, ShipName="Blondel père et fils", ShipCountry="France", ShipAddress="24, place Kléber"},
        new Order() {EmployeeID = 1003, OrderID=15, ShipName="Blondel père et fils", ShipCountry="France", ShipAddress="24, place Kléber"},
        new Order() {EmployeeID = 1004, OrderID=16, ShipName="Chop-suey Chinese", ShipCountry="Switzerland", ShipAddress="Hauptstr. 31"},
        new Order() {EmployeeID = 1004, OrderID=17, ShipName="Chop-suey Chinese", ShipCountry="Switzerland", ShipAddress="Hauptstr. 31"},
        new Order() {EmployeeID = 1004, OrderID=18, ShipName="Chop-suey Chinese", ShipCountry="Switzerland", ShipAddress="Hauptstr. 31"},
        new Order() {EmployeeID = 1004, OrderID=19, ShipName="Chop-suey Chinese", ShipCountry="Switzerland", ShipAddress="Hauptstr. 31"},
        new Order() {EmployeeID = 1004, OrderID=20, ShipName="Chop-suey Chinese", ShipCountry="Switzerland", ShipAddress="Hauptstr. 31"},
        new Order() {EmployeeID = 1005, OrderID=21, ShipName="Ernst Handel", ShipCountry="Austria", ShipAddress="Kirchgasse 6"},
        new Order() {EmployeeID = 1005, OrderID=22, ShipName="Ernst Handel", ShipCountry="Austria", ShipAddress="Kirchgasse 6"},
        new Order() {EmployeeID = 1005, OrderID=23, ShipName="Ernst Handel", ShipCountry="Austria", ShipAddress="Kirchgasse 6"},
        new Order() {EmployeeID = 1005, OrderID=24, ShipName="Ernst Handel", ShipCountry="Austria", ShipAddress="Kirchgasse 6"},
        new Order() {EmployeeID = 1005, OrderID=25, ShipName="Ernst Handel", ShipCountry="Austria", ShipAddress="Kirchgasse 6"},
    };

    protected override void OnInitialized()
    {
        GridData = this.Orders;
    }
    public class EmployeeData
    {
        public int? EmployeeID { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
    }
    public class Order
    {
        public int? EmployeeID { get; set; }
        public int? OrderID { get; set; }
        public string ShipName { get; set; }
        public string ShipCountry { get; set; }
        public string ShipAddress { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZLRDwZRVNPHhdNx?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## See also

* [Row template](https://blazor.syncfusion.com/documentation/datagrid/row-template)
* [Row drag and drop](https://blazor.syncfusion.com/documentation/datagrid/row-drag-and-drop)
* [Row selection](https://blazor.syncfusion.com/documentation/datagrid/row-selection)