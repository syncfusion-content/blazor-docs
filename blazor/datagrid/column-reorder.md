---
layout: post
title: Column Reorder in Blazor DataGrid Component | Syncfusion
description: Learn how to reorder columns in Syncfusion Blazor DataGrid using methods and events for single, multiple, and interactive reordering.
platform: Blazor
control: DataGrid
documentation: ug
---

# Column Reorder in Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows columns to be reordered by dragging and dropping a column header from one position to another within the Grid.

To enable column reordering, set the [AllowReordering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowReordering) property of the [SfGrid](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html) component to **true**.

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

> * To disable reordering for a specific column, set the [AllowReordering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowReordering) property of the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) to **false**.
> * When columns are reordered, the position of the corresponding column data also changes. Ensure that any logic dependent on column order is updated accordingly.

## Prevent reordering for particular column

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows all columns to be reordered by dragging and dropping their headers. However, certain columns are intended to remain fixed in position.

To disable reordering for a specific column, set the [AllowReordering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowReordering) property of that [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) to **false**.

In this configuration, reordering is disabled for the **ShipCity** column.

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

## Reorder columns via programmatically

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows columns to be reordered programmatically using built-in methods. Columns can be moved based on index or field name, enabling dynamic layout control through external UI elements such as buttons.

> To reorder columns externally, set the  [AllowReordering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowReordering) property of the [SfGrid](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html) component to **true**.

### Reorder column by index

To reorder columns by their current index, use the [ReorderColumnByIndexAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ReorderColumnByIndexAsync_System_Int32_System_Int32_) method.

| Parameter   | Type | Description                                      |
|-------------|------|--------------------------------------------------|
| fromIndex   | int  | Current index of the column to be moved.         |
| toIndex     | int  | Target index where the column should be placed.  |

In this configuration, the column at index **1** is moved to index **2**.

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

### Reorder column by target index

To reorder a column by its field name and target index, use the [ReorderColumnByTargetIndexAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ReorderColumnByTargetIndexAsync_System_String_System_Int32_) method.


| Parameter   | Type   | Description                                      |
|-------------|--------|--------------------------------------------------|
| FieldName   | string | Field name of the column to be moved.           |
| toIndex     | int    | Target index where the column should be placed. |


In this configuration, the column with field name **OrderID** is moved to index **3**.

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

### Reorder column by field names

Columns can be reordered programmatically by specifying the field names of the columns to move and the target position. This functionality supports both single-column and multi-column reordering.

**Reorder a single column**

The [ReorderColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ReorderColumnAsync_System_String_System_String_) method reorders a single column by specifying its current field name and the target column's field name.


| Parameter        | Type     | Description                                                              |
|------------------|----------|--------------------------------------------------------------------------|
| fromFieldName  | string | Field name of the column to be moved.                                   |
| toFieldName    | string | Field name of the column before which the column should be placed.      |


**Reorder multiple columns**

The [ReorderColumnsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ReorderColumnsAsync_System_Collections_Generic_List_System_String__System_String_) method reorders multiple columns simultaneously by providing a list of field names and the target column's field name.


| Parameter         | Type            | Description                                                              |
|-------------------|-----------------|--------------------------------------------------------------------------|
| fromFieldNames  | List&lt;string&gt;  | Field names of the columns to be moved.                                  |
| toFieldName     | string        | Field name of the column before which the group should be placed.        |

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

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides events to handle column reordering interactions. These events allow executing custom logic during drag-and-drop operations.

1. [ColumnReordering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_ColumnReordering): Triggered while a column header is being dragged.
2. [ColumnReordered](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_ColumnReordered): Triggered when a column header is dropped on the target column.

### ColumnReordering

The `ColumnReordering` event is triggered while a column header is being dragged during a reordering operation. This event can be used to inspect the column being moved and optionally cancel the reordering based on custom logic.

**Event Arguments**

The event uses the [ColumnReorderingEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnReorderingEventArgs.html) class, which includes the following properties:

| Event Argument     | Type                   | Description                                                                 |
|--------------------|------------------------|------------------------------------------------------------------------------|
| ReorderingColumns | List&lt;GridColumn&gt;     | Represents the columns being dragged.                                       |
| Cancel           | bool                 | Set to **true** to cancel the reordering operation.                         |


### ColumnReordered

The `ColumnReordered` event is triggered after a column header is dropped on the target column during a reordering operation. This event allows executing custom logic after the reordering is completed, such as updating UI elements or logging changes.

**Event Arguments**

The event uses the [ColumnReorderedEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnReorderedEventArgs.html) class, which includes the following properties:

| Parameter            | Type                   | Description                                                                 |
|----------------------|------------------------|-----------------------------------------------------------------------------|
| ReorderingColumns  | List&lt;GridColumn&gt;     | Represents the columns that were reordered.                                 |
| ToColumn           | GridColumn           | Destination column where the reordered columns are placed.                 |


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