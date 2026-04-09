---
layout: post
title: Row in Blazor DataGrid | Syncfusion
description: Learn how to set row styles, heights, hover effects, pinning, and more in the Syncfusion Blazor DataGrid component for enhanced row customization.
control: DataGrid
documentation: ug
---

# Row in Blazor DataGrid

Each row typically represents a single record or item from a data source. Rows in a DataGrid are used to present data in a tabular format. Each row displays a set of values representing the fields of an individual data record. Rows allow interaction with the data in the DataGrid. Rows can be selected, edited, sorted, filtered, and configured to trigger events based on actions.

## Styling rows

Customizing the styles of rows in a Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows modification of row appearance to meet specific design requirements. This feature is useful when highlighting certain rows or changing the font style, background color, and other properties of the row to enhance the visual appeal of the DataGrid. To customize the row styles in the DataGrid, the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides CSS, properties, methods, and event support.

### Using event

The [RowDataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowDataBound) event triggers for every row when it is bound to the data source. In the event handler, the [RowDataBoundEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.RowDataBoundEventArgs-1.html) object contains details of the row. This object can be used to modify the row's appearance, add custom elements, or perform other customizations.

Here's an example of customizing the row styles based on the value of the **"Freight"** column using the `RowDataBound` event. This example involves checking the value of the **"Freight"** column for each row and adding a CSS class to the row based on the value. The CSS classes "below-30", "below-80", and "above-80" can be defined in the stylesheet to apply the desired styles to the rows.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders">
    <GridEvents TValue="OrderData" RowDataBound="RowBound"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="80"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="ShipCity" Width="130"></GridColumn>
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
    private SfGrid<OrderData> Grid;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZLpWjrbKtniHxws?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> The [QueryCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_QueryCellInfo) event can also be used to customize cells and is triggered for every cell in the DataGrid. Use it when styling is required at the cell level based on conditions.

### Using CSS

Row styles can be applied using CSS selectors. The DataGrid provides a class name for each row element, which can be used to apply styles to that specific row. 

**Customize alternate rows**

The appearance of alternate rows can be customized using CSS. This can be useful for improving the readability of the data and making it easier to distinguish between rows. By default, DataGrid provides the CSS class `.e-altrow` to style the alternate rows. This default style can be customized by overriding the `.e-altrow` class with custom CSS styles. 

To change the background color of alternate rows, add the following CSS:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="80"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="ShipCity" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>
<style>
    .e-grid .e-altrow {
        background-color: #aaf1eb;
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

    public OrderData(int? OrderID, string CustomerID, double Freight, DateTime? OrderDate, DateTime?ShippedDate, bool? IsVerified, string ShipCity)
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjBTCNBvAmQGVWzu?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Customize selected row**

The appearance of the selected row can be customized using CSS. This is useful when highlighting the currently selected row to improve the visual appeal of the DataGrid. By default, the DataGrid provides the CSS class `.e-selectionbackground` to style the selected row. This default style can be customized by overriding the `.e-selectionbackground` class with custom CSS styles.

To change the background color of the selected row, add the following CSS:

```css
#CustomGrid .e-selectionbackground {
    background-color: #f9920b;
}
```
{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid ID="CustomGrid" DataSource="@Orders">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="80"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="ShipCity" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    #CustomGrid .e-selectionbackground {
        background-color: #f9920b;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXLzMXVvTiZCSxLF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Row height

The DataGrid allows customization of the height of rows based on needs. This feature is useful when displaying more content in a row or when reducing the height of rows to fit content. This can be achieved by using the [RowHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RowHeight) property of the DataGrid. This property allows changing the height of the entire DataGrid row to a desired value.

The following example demonstrates dynamically changing the height of the rows using the `RowHeight` property.

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

    private void ChangeRowHeight(int height)
    {
        RowHeightValue = height;
        Grid.Refresh(); // Refresh the Grid to apply the new row height.
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZBJWDgtqYsIJUYQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> The `RowHeight` property sets the height for all DataGrid rows. It does not configure individual cell heights.
> The `RowHeight` setting applies to header and footer rows as well.
> Row height for a specific row can be customized by adding a row-level CSS class in the `RowDataBound` event.

### Customize row height for particular row

The row height for a particular row can be customized when displaying more content in a particular row, reducing the height of a row to fit content, or making a specific row stand out from the other rows in the grid. This can be achieved by using the `RowHeight` property of the DataGrid along with the [RowDataBound](https://blazor.syncfusion.com/documentation/datagrid/events#rowdatabound) event. This event triggers every time a request is made to access row information, element, or data, and before the row element is appended to the DataGrid element.

In the following example, the row height for the row with **“OrderID”** as **“10249”** is set as **‘90px’** using the `RowDataBound` event.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" AllowSelection="true" Height="315px">
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXhJMsNIiHrTRolf?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Row hover

The Row Hover feature in DataGrid provides a visual effect when the mouse pointer hovers over the rows, making it easy to highlight and identify the selected row. This feature can also improve the readability of data in the DataGrid. The row hover effect can be enabled or disabled using the [EnableHover](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableHover) property of the DataGrid.

By default, the `EnableHover` property is set to `true`, which means that the row hovering effect is enabled. To disable the row hover effect, set the `EnableHover` property to `false`.

Here is an example that demonstrates enabling or disabling the Row hover feature:

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDhpiDUZpjrcFKJP?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> The `EnableHover` property applies to the entire DataGrid rather than to specific rows or columns.

## Row pinning (Frozen)

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows freezing rows to keep them visible while scrolling vertically through large datasets. This feature enhances the experience by maintaining important information within view at all times.

{% youtube "youtube:https://www.youtube.com/watch?v=L2NvKyBomhM"%}

The [FrozenRows](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FrozenRows) property in the Blazor DataGrid is used to freeze a specified number of rows at the top of the DataGrid, keeping them fixed while the rest of the content scrolls vertically. 

In the following example, the `FrozenRows` property is set to `2`. This configuration freezes the top two rows of the DataGrid, and they will remain fixed in their positions while the rest of the DataGrid can be scrolled vertically.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="display: flex; align-items: center; padding-bottom: 20px;">
    <label style="padding-right: 10px; font-weight: bold;">Change the frozen rows:</label>
    <SfNumericTextBox @ref="NumericTextBox" TValue="int" Value="@NumericValue" Min="1" Max="5" Decimals="0"
    ValidateDecimalOnType="true" Width="150px">
    </SfNumericTextBox>
    <SfButton style="margin-left: 10px;" CssClass="e-primary" @onclick="FrozenRowsFn">
        Update Value
    </SfButton>
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
    private SfNumericTextBox<int> NumericTextBox;
    public List<OrderData> Orders { get; set; }
    public int NumericValue { get; set; } = 2;

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    public void FrozenRowsFn()
    {
        // Get the value from NumericTextBox and update FrozenRows.
        NumericValue = NumericTextBox.Value;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjrTMjUtTMnyFhpX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> Frozen rows should remain within the DataGrid viewport.
> Frozen DataGrid supports row virtualization to impro datasets.
> The frozen feature applies to rows visible in the current view.ve performance with large
> [FrozenColumns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FrozenColumns) and [FrozenRows](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FrozenRows) can be used together in the same DataGrid.

### Change default frozen rows line color

The frozen line background color of frozen rows in the DataGrid can be customized by applying custom CSS styles to the specific frozen row. This allows changing the background color of frozen rows to match the application's design and theme.

To change the default frozen rows line color, use the following CSS class:

```css
.e-grid .e-frozenrow-border {
    background-color: rgb(5, 114, 47);
}
```
By applying this CSS class, the background color of frozen rows can be set to the specified RGB color. The following example demonstrates changing the default frozen‑rows line color using CSS.

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZVpWNgjTWFRHyLC?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> When a validation message is displayed in the frozen area (Left, Right, or Fixed), scrolling is blocked until the message is cleared.

### Limitations

The Autofill feature is not compatible with frozen rows.

## Add a new row programmatically

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides a way to add a new row to the DataGrid programmatically. This feature is useful when adding a new record to the DataGrid without manually entering data. This can be done using the [AddRecordAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AddRecordAsync__0_System_Nullable_System_Int32__) method of the DataGrid.

The `AddRecordAsync` method takes two parameters:

 - The **data** object representing the new row to be added  
 - The **index** at which the new row should be inserted. If no index is specified, the new row is added at the end.

Here’s an example that demonstrates adding a new row using the `AddRecordAsync` method.

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
        return new Random().Next(10000, 99999); // Random Order ID.
    }

    private string GenerateCustomerId()
    {
        const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        return new string(Enumerable.Repeat(chars, 5).Select(s => s[new Random().Next(s.Length)]).ToArray());
    }

    private string GenerateShipCity()
    {
        string[] cities = { "London", "Paris", "New York", "Tokyo", "Berlin" };
        return cities[new Random().Next(cities.Length)];
    }

    private double GenerateFreight()
    {
        return new Random().NextDouble() * 100; // Random Freight value.
    }

    private string GenerateShipName()
    {
        string[] names = { "Que Delícia", "Bueno Foods", "Island Trading", "Laughing Bacchus Winecellars" };
        return names[new Random().Next(names.Length)];
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXhzsZKZJLyoxcEx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> When working with remote data, adding a new row between existing rows is not supported.
> To insert a new record at the beginning, pass 0 as the second parameter to `AddRecordAsync`.
> If no index is specified, the new row is added at the end.

## Get the row data and element

DataGrid provides several methods to retrieve row data and elements. This feature is useful when needing to access specific rows, perform custom operations, or manipulate the data displayed in the DataGrid.

1. [GetRowIndexByPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetRowIndexByPrimaryKeyAsync_System_Object_): Retrieves the row index based on a primary key value or row data.

```cs
<SfButton id="GetRowIndexByPrimaryKey" @onclick="GetDataHandler">GetRowIndexByPrimaryKey</SfButton>
<SfGrid @ref="grid" DataSource="@Orders">
 ........
</SfGrid>
@code{
   SfGrid<Order> grid;
    private async Task GetDataHandler()
    {
        var rowIndex = await Grid.GetRowIndexByPrimaryKeyAsync(10250);  // pass primary key value here.
    }
}
```

2. [GetSelectedRowIndexesAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetSelectedRowIndexesAsync): This method allows retrieval of the collection of indexes of the selected rows.

```cs
<SfButton id="GetSelectedRowIndexes " @onclick="GetDataHandler">GetSelectedRowIndexes </SfButton>
<SfGrid @ref="grid" DataSource="@Orders">
 ........
</SfGrid>
@code{
   SfGrid<Order> grid;
   private async Task GetDataHandler()
   {
        var SelectedRowIndexes = await grid.GetSelectedRowIndexesAsync();  
   }
}
```

## Master Detail DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can display related details in another DataGrid using a master-detail layout. Selecting a row in the master DataGrid loads related records in the detail DataGrid.

Use the [RowSelected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowSelected) event on the master DataGrid to obtain the selected record. Apply a filter through the [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Query) property of the detail DataGrid and bind the resulting collection to its [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource).

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
        new Order() {EmployeeID = 1001, OrderID=001, ShipName="Around the Horn", ShipCountry="UK", ShipAddress="Brook Farm Stratford St. Mary"},
        new Order() {EmployeeID = 1001, OrderID=002, ShipName="Around the Horn", ShipCountry="UK", ShipAddress="Brook Farm Stratford St. Mary"},
        new Order() {EmployeeID = 1001, OrderID=003, ShipName="Around the Horn", ShipCountry="UK", ShipAddress="Brook Farm Stratford St. Mary"},
        new Order() {EmployeeID = 1001, OrderID=004, ShipName="Around the Horn", ShipCountry="UK", ShipAddress="Brook Farm Stratford St. Mary"},
        new Order() {EmployeeID = 1001, OrderID=005, ShipName="Around the Horn", ShipCountry="UK", ShipAddress="Brook Farm Stratford St. Mary"},
        new Order() {EmployeeID = 1002, OrderID=006, ShipName="Berglunds snabbköp", ShipCountry="Sweden", ShipAddress="Berguvsvägen 8"},
        new Order() {EmployeeID = 1002, OrderID=007, ShipName="Berglunds snabbköp", ShipCountry="Sweden", ShipAddress="Berguvsvägen 8"},
        new Order() {EmployeeID = 1002, OrderID=008, ShipName="Berglunds snabbköp", ShipCountry="Sweden", ShipAddress="Berguvsvägen 8"},
        new Order() {EmployeeID = 1002, OrderID=009, ShipName="Berglunds snabbköp", ShipCountry="Sweden", ShipAddress="Berguvsvägen 8"},
        new Order() {EmployeeID = 1002, OrderID=010, ShipName="Berglunds snabbköp", ShipCountry="Sweden", ShipAddress="Berguvsvägen 8"},
        new Order() {EmployeeID = 1003, OrderID=011, ShipName="Blondel père et fils", ShipCountry="France", ShipAddress="24, place Kléber"},
        new Order() {EmployeeID = 1003, OrderID=012, ShipName="Blondel père et fils", ShipCountry="France", ShipAddress="24, place Kléber"},
        new Order() {EmployeeID = 1003, OrderID=013, ShipName="Blondel père et fils", ShipCountry="France", ShipAddress="24, place Kléber"},
        new Order() {EmployeeID = 1003, OrderID=014, ShipName="Blondel père et fils", ShipCountry="France", ShipAddress="24, place Kléber"},
        new Order() {EmployeeID = 1003, OrderID=015, ShipName="Blondel père et fils", ShipCountry="France", ShipAddress="24, place Kléber"},
        new Order() {EmployeeID = 1004, OrderID=016, ShipName="Chop-suey Chinese", ShipCountry="Switzerland", ShipAddress="Hauptstr. 31"},
        new Order() {EmployeeID = 1004, OrderID=017, ShipName="Chop-suey Chinese", ShipCountry="Switzerland", ShipAddress="Hauptstr. 31"},
        new Order() {EmployeeID = 1004, OrderID=018, ShipName="Chop-suey Chinese", ShipCountry="Switzerland", ShipAddress="Hauptstr. 31"},
        new Order() {EmployeeID = 1004, OrderID=019, ShipName="Chop-suey Chinese", ShipCountry="Switzerland", ShipAddress="Hauptstr. 31"},
        new Order() {EmployeeID = 1004, OrderID=020, ShipName="Chop-suey Chinese", ShipCountry="Switzerland", ShipAddress="Hauptstr. 31"},
        new Order() {EmployeeID = 1005, OrderID=021, ShipName="Ernst Handel", ShipCountry="Austria", ShipAddress="Kirchgasse 6"},
        new Order() {EmployeeID = 1005, OrderID=022, ShipName="Ernst Handel", ShipCountry="Austria", ShipAddress="Kirchgasse 6"},
        new Order() {EmployeeID = 1005, OrderID=023, ShipName="Ernst Handel", ShipCountry="Austria", ShipAddress="Kirchgasse 6"},
        new Order() {EmployeeID = 1005, OrderID=024, ShipName="Ernst Handel", ShipCountry="Austria", ShipAddress="Kirchgasse 6"},
        new Order() {EmployeeID = 1005, OrderID=025, ShipName="Ernst Handel", ShipCountry="Austria", ShipAddress="Kirchgasse 6"},
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXrzCCLcgeRbJEvv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}