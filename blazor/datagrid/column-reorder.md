---
layout: post
title: Column Reorder in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about column reorder in the Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Column Reorder in Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows to reorder columns by drag and drop of a particular column header from one index to another index within the Grid.

To reorder the columns, set the [AllowReordering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowReordering) property to true in the Grid.

Here’s an example for column reordering in your Grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315" AllowReordering="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderDetails> Orders { get; set; }
   
    protected override void OnInitialized()
    {
        Orders = OrderDetails.GetAllRecords();
    }    
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();    
    public OrderDetails(int OrderID, string CustomerId, string ShipCity, string ShipName)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.ShipCity = ShipCity;
        this.ShipName = ShipName;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", "Reims", "Vins et alcools Chevalier"));
            order.Add(new OrderDetails(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
            order.Add(new OrderDetails(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            order.Add(new OrderDetails(10251, "VICTE", "Lyon", "Victuailles en stock"));
            order.Add(new OrderDetails(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
            order.Add(new OrderDetails(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            order.Add(new OrderDetails(10254, "CHOPS", "Bern", "Chop-suey Chinese"));
            order.Add(new OrderDetails(10255, "RICSU", "Genève", "Richter Supermarkt"));
            order.Add(new OrderDetails(10256, "WELLI",  "Resende", "Wellington Importadora"));
            order.Add(new OrderDetails(10257, "HILAA", "San Cristóbal", "HILARION-Abastos"));
            order.Add(new OrderDetails(10258, "ERNSH", "Graz", "Ernst Handel"));
            order.Add(new OrderDetails(10259, "CENTC", "México D.F.", "Centro comercial Moctezuma"));
            order.Add(new OrderDetails(10260, "OTTIK", "Köln",  "Ottilies Käseladen"));
            order.Add(new OrderDetails(10261, "QUEDE", "Rio de Janeiro", "Que Delícia"));
            order.Add(new OrderDetails(10262, "RATTC", "Albuquerque", "Rattlesnake Canyon Grocery"));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNrpMrXHLHHVDWpr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * You can disable reordering a particular column by setting the [AllowReordering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowReordering) property of [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) as **false**.
> * When columns are reordered, the position of the corresponding column data will also be changed. As a result, you should ensure that any additional code or logic that relies on the order of the column data is updated accordingly.

## Prevent reordering for particular column

By default, all columns in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can be reordered by dragging and dropping their headers to another location within the Grid. However, there may be certain columns that you do not want to be reordered. In such cases, you can set the [AllowReordering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowReordering) property of that particular column to false. Here is an example that demonstrates how to prevent reordering for a specific column:

In this example, the **ShipCity** column is prevented from being reordered by setting the `AllowReordering` property to **false**:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315" AllowReordering="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" AllowReordering="false" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {    
    public List<OrderDetails> Orders { get; set; }   
    protected override void OnInitialized()
    {
        Orders = OrderDetails.GetAllRecords();       
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();    
    public OrderDetails(int OrderID, string CustomerId, string ShipCity, string ShipName)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.ShipCity = ShipCity;
        this.ShipName = ShipName;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", "Reims", "Vins et alcools Chevalier"));
            order.Add(new OrderDetails(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
            order.Add(new OrderDetails(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            order.Add(new OrderDetails(10251, "VICTE", "Lyon", "Victuailles en stock"));
            order.Add(new OrderDetails(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
            order.Add(new OrderDetails(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            order.Add(new OrderDetails(10254, "CHOPS", "Bern", "Chop-suey Chinese"));
            order.Add(new OrderDetails(10255, "RICSU", "Genève", "Richter Supermarkt"));
            order.Add(new OrderDetails(10256, "WELLI",  "Resende", "Wellington Importadora"));
            order.Add(new OrderDetails(10257, "HILAA", "San Cristóbal", "HILARION-Abastos"));
            order.Add(new OrderDetails(10258, "ERNSH", "Graz", "Ernst Handel"));
            order.Add(new OrderDetails(10259, "CENTC", "México D.F.", "Centro comercial Moctezuma"));
            order.Add(new OrderDetails(10260, "OTTIK", "Köln",  "Ottilies Käseladen"));
            order.Add(new OrderDetails(10261, "QUEDE", "Rio de Janeiro", "Que Delícia"));
            order.Add(new OrderDetails(10262, "RATTC", "Albuquerque", "Rattlesnake Canyon Grocery"));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZBJWLjxrwmYsHAA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Reorder columns externally

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to reorder columns externally, which means that using methods you can programmatically move columns around within the Grid, based on their index or target index, or by using their field name.

> When reordering columns externally, you must set the [AllowReordering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowReordering) property of the Grid to **true**.

### Reorder column based on index

You can use the [ReorderColumnByIndexAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ReorderColumnByIndexAsync_System_Int32_System_Int32_) method to reorder columns based on their current index. This method takes two arguments:

* **fromIndex** : Current index of the column to be reordered.
* **toIndex** : New index of the column after the reordering.

Here is an example of how to use the `ReorderColumnByIndexAsync` method:

In this example, we are moving the column at index 1 to index 2.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="ReorderByIndex">REORDER COLUMN BY INDEX</SfButton>
<SfGrid @ref="Grid" DataSource="@Orders" Height="315" AllowReordering="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipRegion) HeaderText="Ship Region" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderDetails> Grid;
    public List<OrderDetails> Orders { get; set; }   
    protected override void OnInitialized()
    {
        Orders = OrderDetails.GetAllRecords();       
    }
    public void ReorderByIndex()
    {
        Grid.ReorderColumnByIndexAsync(1, 2);
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();    
    public OrderDetails(int OrderID, string CustomerId, string ShipCity, string ShipName, string ShipRegion)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.ShipCity = ShipCity;
        this.ShipName = ShipName;
        this.ShipRegion = ShipRegion;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", "Reims", "Vins et alcools Chevalier", "CJ"));
            order.Add(new OrderDetails(10249, "TOMSP", "Münster", "Toms Spezialitäten", "CJ"));
            order.Add(new OrderDetails(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes", "RJ"));
            order.Add(new OrderDetails(10251, "VICTE", "Lyon", "Victuailles en stock", "CJ"));
            order.Add(new OrderDetails(10252, "SUPRD", "Charleroi", "Suprêmes délices", "CJ"));
            order.Add(new OrderDetails(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes", "RJ"));
            order.Add(new OrderDetails(10254, "CHOPS", "Bern", "Chop-suey Chinese", "CJ"));
            order.Add(new OrderDetails(10255, "RICSU", "Genève", "Richter Supermarkt", "CJ"));
            order.Add(new OrderDetails(10256, "WELLI", "Resende", "Wellington Importadora", "SP"));
            order.Add(new OrderDetails(10257, "HILAA", "San Cristóbal", "HILARION-Abastos", "Táchira"));
            order.Add(new OrderDetails(10258, "ERNSH", "Graz", "Ernst Handel", "CJ"));
            order.Add(new OrderDetails(10259, "CENTC", "México D.F.", "Centro comercial Moctezuma", "CJ"));
            order.Add(new OrderDetails(10260, "OTTIK", "Köln",  "Ottilies Käseladen", "CJ"));
            order.Add(new OrderDetails(10261, "QUEDE", "Rio de Janeiro", "Que Delícia", "RJ"));
            order.Add(new OrderDetails(10262, "RATTC", "Albuquerque", "Rattlesnake Canyon Grocery", "NM"));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
    public string ShipRegion { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNLzChtxLaAoXrZm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Reorder column based on target index

You can also use the [ReorderColumnByTargetIndexAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ReorderColumnByTargetIndexAsync_System_String_System_Int32_) method to reorder column columns based on the target index. This method takes two arguments:

* **FieldName** : Field name of the column to be reordered
* **toIndex** : New index of the column after the reordering

Here is an example of how to use the `ReorderColumnByTargetIndexAsync` method to reorder column based on target index:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="ReorderByTargetIndex">REORDER COLUMN BY TARGET INDEX</SfButton>
<SfGrid @ref="Grid" DataSource="@Orders" Height="315" AllowReordering="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipRegion) HeaderText="Ship Region" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    private SfGrid<OrderDetails> Grid;
    public List<OrderDetails> Orders { get; set; }
   
    protected override void OnInitialized()
    {
        Orders = OrderDetails.GetAllRecords();       
    }
    public void ReorderByTargetIndex()
    {
        Grid.ReorderColumnByTargetIndexAsync("OrderID", 3);
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();    
    public OrderDetails(int OrderID, string CustomerId, string ShipCity, string ShipName, string ShipRegion)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.ShipCity = ShipCity;
        this.ShipName = ShipName;
        this.ShipRegion = ShipRegion;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", "Reims", "Vins et alcools Chevalier", "CJ"));
            order.Add(new OrderDetails(10249, "TOMSP", "Münster", "Toms Spezialitäten", "CJ"));
            order.Add(new OrderDetails(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes", "RJ"));
            order.Add(new OrderDetails(10251, "VICTE", "Lyon", "Victuailles en stock", "CJ"));
            order.Add(new OrderDetails(10252, "SUPRD", "Charleroi", "Suprêmes délices", "CJ"));
            order.Add(new OrderDetails(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes", "RJ"));
            order.Add(new OrderDetails(10254, "CHOPS", "Bern", "Chop-suey Chinese", "CJ"));
            order.Add(new OrderDetails(10255, "RICSU", "Genève", "Richter Supermarkt", "CJ"));
            order.Add(new OrderDetails(10256, "WELLI", "Resende", "Wellington Importadora", "SP"));
            order.Add(new OrderDetails(10257, "HILAA", "San Cristóbal", "HILARION-Abastos", "Táchira"));
            order.Add(new OrderDetails(10258, "ERNSH", "Graz", "Ernst Handel", "CJ"));
            order.Add(new OrderDetails(10259, "CENTC", "México D.F.", "Centro comercial Moctezuma", "CJ"));
            order.Add(new OrderDetails(10260, "OTTIK", "Köln",  "Ottilies Käseladen", "CJ"));
            order.Add(new OrderDetails(10261, "QUEDE", "Rio de Janeiro", "Que Delícia", "RJ"));
            order.Add(new OrderDetails(10262, "RATTC", "Albuquerque", "Rattlesnake Canyon Grocery", "NM"));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
    public string ShipRegion { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZhpCVZRUILkYtuK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Reorder column based on field names

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to programmatically reorder columns using the [ReorderColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ReorderColumnAsync_System_String_System_String_) and [ReorderColumnsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ReorderColumnsAsync_System_Collections_Generic_List_System_String__System_String_) methods. These methods provide flexibility for dynamically rearranging columns based on their field names.

1. `ReorderColumnAsync`: This method is used to reorder a single column by specifying its current field name and the target column's field name. It takes the following arguments:
    * **FromFieldName**: The field name of the column to be moved.
    * **ToFieldName**: The field name of the column you want to move the column to.
2. `ReorderColumnsAsync`: This method reorders multiple columns simultaneously by providing their field names in a list. It takes the following arguments:
    * **FromFieldName**: The field name of the column you want to move.
    * **ToFieldName** : The field name of the column you want to move the column to.

Here is an example demonstrating how to use the `ReorderColumnAsync` and `ReorderColumnsAsync` method to reorder single and multiple columns based on their field names:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="ReorderSingleColumn" CssClass="e-outline" Content="REORDER SINGLE COLUMN"></SfButton>
<SfButton OnClick="ReorderMultipleColumn" CssClass="e-outline" Content="REORDER MULTIPLE COLUMN"></SfButton>
<SfGrid @ref="Grid" DataSource="@Orders" Height="315" AllowReordering="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipRegion) HeaderText="Ship Region" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<string> ColumnName = (new List<string> { "ShipCity", "ShipRegion", "ShipName" });
    private SfGrid<OrderDetails> Grid;
    public List<OrderDetails> Orders { get; set; }   
    protected override void OnInitialized()
    {
        Orders = OrderDetails.GetAllRecords();
    }
    public void ReorderSingleColumn()
    {
        Grid.ReorderColumnAsync("ShipCity", "OrderID");
    }
    public void ReorderMultipleColumn()
    {
        Grid.ReorderColumnsAsync(ColumnName, "OrderID");
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();    
    public OrderDetails(int OrderID, string CustomerId, string ShipCity, string ShipName, string ShipRegion)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.ShipCity = ShipCity;
        this.ShipName = ShipName;
        this.ShipRegion = ShipRegion;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", "Reims", "Vins et alcools Chevalier", "CJ"));
            order.Add(new OrderDetails(10249, "TOMSP", "Münster", "Toms Spezialitäten", "CJ"));
            order.Add(new OrderDetails(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes", "RJ"));
            order.Add(new OrderDetails(10251, "VICTE", "Lyon", "Victuailles en stock", "CJ"));
            order.Add(new OrderDetails(10252, "SUPRD", "Charleroi", "Suprêmes délices", "CJ"));
            order.Add(new OrderDetails(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes", "RJ"));
            order.Add(new OrderDetails(10254, "CHOPS", "Bern", "Chop-suey Chinese", "CJ"));
            order.Add(new OrderDetails(10255, "RICSU", "Genève", "Richter Supermarkt", "CJ"));
            order.Add(new OrderDetails(10256, "WELLI", "Resende", "Wellington Importadora", "SP"));
            order.Add(new OrderDetails(10257, "HILAA", "San Cristóbal", "HILARION-Abastos", "Táchira"));
            order.Add(new OrderDetails(10258, "ERNSH", "Graz", "Ernst Handel", "CJ"));
            order.Add(new OrderDetails(10259, "CENTC", "México D.F.", "Centro comercial Moctezuma", "CJ"));
            order.Add(new OrderDetails(10260, "OTTIK", "Köln",  "Ottilies Käseladen", "CJ"));
            order.Add(new OrderDetails(10261, "QUEDE", "Rio de Janeiro", "Que Delícia", "RJ"));
            order.Add(new OrderDetails(10262, "RATTC", "Albuquerque", "Rattlesnake Canyon Grocery", "NM"));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
    public string ShipRegion { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXrTsBjxJZWsNAMx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Reorder events

When reordering columns in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, you may want to take some specific action in response to the drag and drop events. To handle these events, you can define event handlers for the following events:

1. The [ColumnReordering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_ColumnReordering) event triggers when column header element is dragged (moved) continuously.

2. The [ColumnReordered](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_ColumnReordered) event triggers when a column header element is dropped on the target column.

In the following example, we have implemented the `ColumnReordering` and `ColumnReordered` events in the Grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<div style="text-align: center; color: red">
    <span>@ReorderMessage</span>
</div>
<SfGrid @ref="Grid" DataSource="@OrderData" Height="315" AllowReordering="true">
    <GridEvents TValue="OrderDetails" ColumnReordered ="ColumnReordered" ColumnReordering ="ColumnReordering"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipRegion) HeaderText="Ship Region" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public SfGrid<OrderDetails> Grid { get; set; }
    public string ReorderMessage;
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }    
    public void ColumnReordering(ColumnReorderingEventArgs args)
    {
        if (args.ReorderingColumns[0].Field == "OrderID")
        {
            args.Cancel = true;
            ReorderMessage = "ColumnReordering event is triggered. Column Reordering cancelled for " + args.ReorderingColumns[0].HeaderText + " column ";
        }
    }
    public void ColumnReordered(ColumnReorderedEventArgs args)
    {
        ReorderMessage = "ColumnReordered event triggered. " + args.ReorderingColumns[0].HeaderText + " column is dragged to index " + args.ReorderingColumns[0].Index;
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();    
    public OrderDetails(int OrderID, string CustomerId, string ShipCity, string ShipName, string ShipRegion)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.ShipCity = ShipCity;
        this.ShipName = ShipName;
        this.ShipRegion = ShipRegion;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", "Reims", "Vins et alcools Chevalier", "CJ"));
            order.Add(new OrderDetails(10249, "TOMSP", "Münster", "Toms Spezialitäten", "CJ"));
            order.Add(new OrderDetails(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes", "RJ"));
            order.Add(new OrderDetails(10251, "VICTE", "Lyon", "Victuailles en stock", "CJ"));
            order.Add(new OrderDetails(10252, "SUPRD", "Charleroi", "Suprêmes délices", "CJ"));
            order.Add(new OrderDetails(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes", "RJ"));
            order.Add(new OrderDetails(10254, "CHOPS", "Bern", "Chop-suey Chinese", "CJ"));
            order.Add(new OrderDetails(10255, "RICSU", "Genève", "Richter Supermarkt", "CJ"));
            order.Add(new OrderDetails(10256, "WELLI", "Resende", "Wellington Importadora", "SP"));
            order.Add(new OrderDetails(10257, "HILAA", "San Cristóbal", "HILARION-Abastos", "Táchira"));
            order.Add(new OrderDetails(10258, "ERNSH", "Graz", "Ernst Handel", "CJ"));
            order.Add(new OrderDetails(10259, "CENTC", "México D.F.", "Centro comercial Moctezuma", "CJ"));
            order.Add(new OrderDetails(10260, "OTTIK", "Köln",  "Ottilies Käseladen", "CJ"));
            order.Add(new OrderDetails(10261, "QUEDE", "Rio de Janeiro", "Que Delícia", "RJ"));
            order.Add(new OrderDetails(10262, "RATTC", "Albuquerque", "Rattlesnake Canyon Grocery", "NM"));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
    public string ShipRegion { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNLfsBXHpgzuFInT?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

<!-- ## Lock columns

You can lock columns by using [`LockColumn`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_LockColumn) property. The locked columns will be moved to the first position and can’t be reordered.

In the following example, Order ID column is locked and its reordering functionality is disabled.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Employees" AllowReordering="true" Height="215">
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.EmployeeID) LockColumn="true" TextAlign="TextAlign.Center" HeaderText="Employee ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Name) HeaderText="First Name" Width="130"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Title) HeaderText="Title" Width="120"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.HireDate) HeaderText="Hire Date" Format="d" TextAlign="TextAlign.Right" Width="150" Type="ColumnType.Date"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<EmployeeData> Employees = new List<EmployeeData>
    {
        new EmployeeData() { EmployeeID = 1, Name = "Nancy Fuller", Title = "Vice President", HireDate = DateTime.Now.AddDays(-80) },
        new EmployeeData() { EmployeeID = 2, Name = "Steven Buchanan", Title = "Sales Manager", HireDate = DateTime.Now.AddDays(-60) },
        new EmployeeData() { EmployeeID = 3, Name = "Janet Leverling", Title = "Sales Representative", HireDate = DateTime.Now.AddDays(-34) },
        new EmployeeData() { EmployeeID = 4, Name = "Andrew Davolio", Title = "Inside Sales Coordinator", HireDate = DateTime.Now.AddDays(-22) },
        new EmployeeData() { EmployeeID = 5, Name = "Margaret Peacock", Title = "Sales", HireDate = DateTime.Now.AddDays(-12) },
    };

    public class EmployeeData
    {
        public int? EmployeeID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public DateTime HireDate { get; set; }
    }
}
``` -->