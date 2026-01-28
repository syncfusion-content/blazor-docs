---
layout: post
title: Column Menu in Blazor DataGrid Component | Syncfusion
description: Learn how to use and customize the column menu in Syncfusion Blazor DataGrid, including events, actions, and advanced options for better control.
platform: Blazor
control: DataGrid
documentation: ug
---

# Column Menu in Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports a column menu that provides quick access to features such as sorting, grouping, filtering, column chooser, and autofit. Clicking the column header’s menu icon displays a contextual menu with these options.

To enable the column menu, set the [ShowColumnMenu](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ShowColumnMenu) property to **true** in the [Grid](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html) configuration.

The default column menu items are listed in the table:

| Item | Description |
|-----|-----|
| **SortAscending** | Sort the current column in ascending order. |
| **SortDescending** | Sort the current column in descending order. |
| **Group** | Groups the current column. |
| **Ungroup** | Ungroups the current column. |
| **AutoFit** | Adjusts the width of the current column to fit its content. |
| **AutoFitAll** | Adjusts the width of all columns to fit their content. |
| **ColumnChooser** | Opens the column chooser to manage column visibility. |
| **Filter** | Displays the filter option as defined in the [FilterSettings.Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridFilterSettings.html#Syncfusion_Blazor_Grids_GridFilterSettings_Type) property. |

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315" AllowGrouping="true" AllowSorting="true" AllowFiltering="true" ShowColumnMenu="true" AllowPaging="true">
    <GridFilterSettings Type="FilterType.CheckBox"></GridFilterSettings>
    <GridGroupSettings ShowGroupedColumn="true"></GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="120"></GridColumn>
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
    public static List<OrderData> Order = new List<OrderData>();
    public OrderData(int OrderID, double Freight, string CustomerId, string ShipCity)
    {
        this.OrderID = OrderID;
        this.Freight = Freight;
        this.CustomerID = CustomerId;
        this.ShipCity = ShipCity;
    }
    public static List<OrderData> GetAllRecords()
    {
        if (Order.Count == 0)
        {
            Order.Add(new OrderData(10248, 32.38, "VINET", "Reims"));
            Order.Add(new OrderData(10249, 11.61, "TOMSP", "Münster"));
            Order.Add(new OrderData(10250, 65.83, "HANAR", "Rio de Janeiro"));
            Order.Add(new OrderData(10251, 41.34, "VICTE", "Lyon"));
            Order.Add(new OrderData(10252, 51.3, "SUPRD", "Charleroi"));
            Order.Add(new OrderData(10253, 58.17, "HANAR", "Rio de Janeiro"));
            Order.Add(new OrderData(10254, 22.98, "CHOPS", "Bern"));
            Order.Add(new OrderData(10255, 148.33, "RICSU", "Genève"));
            Order.Add(new OrderData(10256, 13.97, "WELLI", "Resende"));
            Order.Add(new OrderData(10257, 81.91, "HILAA", "San Cristóbal"));
            Order.Add(new OrderData(10258, 140.51, "ERNSH", "Graz"));
            Order.Add(new OrderData(10259, 3.25, "CENTC", "México D.F."));
            Order.Add(new OrderData(10260, 55.09, "OTTIK", "Köln"));
            Order.Add(new OrderData(10261, 3.05, "QUEDE", "Rio de Janeiro"));
            Order.Add(new OrderData(10262, 48.29, "RATTC", "Albuquerque"));
        }
        return Order;
    }
    public int OrderID { get; set; }
    public double Freight { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXLzMLWLKTPWHQcg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * To disable the column menu for a specific column, set the [ShowColumnMenu](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ShowColumnMenu) property of the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) to **false**.
> * To customize the menu items, define the [ColumnMenuItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ColumnMenuItems) property with the required options.

## Disable column menu for specific column

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides the ability to prevent the column menu from appearing for specific columns. This is useful when certain columns should not be customizable through the column menu.

To disable the column menu for a specific column, set the [ShowColumnMenu](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ShowColumnMenu) property of the [GridColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html) to **false**.

The column menu is disabled for the **OrderID** column:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315" AllowSorting="true" AllowGrouping="true" AllowFiltering="true" ShowColumnMenu="true" AllowPaging="true">
    <GridFilterSettings Type="FilterType.CheckBox"></GridFilterSettings>
    <GridGroupSettings ShowGroupedColumn="true"></GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" ShowColumnMenu="false" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
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
    public static List<OrderData> Order = new List<OrderData>();    
    public OrderData(int OrderID, string CustomerId, string Shipcity, double Freight)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.ShipCity = Shipcity;
        this.Freight = Freight; 
    }
    public static List<OrderData> GetAllRecords()
    {
        if (Order.Count == 0)
        {
            Order.Add(new OrderData(10248, "VINET", "Reims", 32.38));
            Order.Add(new OrderData(10249, "TOMSP", "Münster", 11.61));
            Order.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", 65.83));
            Order.Add(new OrderData(10251, "VICTE", "Lyon", 41.34));
            Order.Add(new OrderData(10252, "SUPRD", "Charleroi", 51.3));
            Order.Add(new OrderData(10253, "HANAR", "Rio de Janeiro", 58.17));
            Order.Add(new OrderData(10254, "CHOPS", "Bern", 22.98));
            Order.Add(new OrderData(10255, "RICSU", "Genève", 148.33));
            Order.Add(new OrderData(10256, "WELLI", "Resende", 13.97));
            Order.Add(new OrderData(10257, "HILAA", "San Cristóbal", 81.91));
            Order.Add(new OrderData(10258, "ERNSH", "Graz", 140.51));
            Order.Add(new OrderData(10259, "CENTC", "México D.F.", 3.25));
            Order.Add(new OrderData(10260, "OTTIK", "Köln", 55.09));
            Order.Add(new OrderData(10261, "QUEDE", "Rio de Janeiro", 3.05));
            Order.Add(new OrderData(10262, "RATTC", "Albuquerque", 48.29));
        }
        return Order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public double Freight { get; set; } 
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDBfiCVHTnFFingT?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Add custom column menu item

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports adding custom items to the column menu using the [ColumnMenuItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ColumnMenuItems) property. This property accepts a collection of [ColumnMenuItemModel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnMenuItemModel.html) objects.

Custom actions for these items can be defined in the [ColumnMenuItemClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_ColumnMenuItemClicked) event.

In this configuration, two custom column menu items are added to clear sorting and grouping using the [ClearSortingAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ClearSortingAsync_System_Collections_Generic_List_System_String__) and [ClearGroupingAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ClearGroupingAsync) methods:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" Height="315" ColumnMenuItems="@MenuItems" ShowColumnMenu="true" AllowGrouping="true" AllowPaging="true" AllowSorting="true">
    <GridSortSettings>
        <GridSortColumns>
            <GridSortColumn Field="OrderID" Direction="SortDirection.Ascending"></GridSortColumn>
        </GridSortColumns>
    </GridSortSettings>
    <GridGroupSettings ShowGroupedColumn="true" Columns=@InitialGrouping></GridGroupSettings>
    <GridEvents ColumnMenuItemClicked="ColumnMenuItemClickedHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Center" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="120" ShowColumnMenu="false"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Center" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    private SfGrid<OrderData> Grid;
    public string[] InitialGrouping = (new string[] { "Freight" });
    public List<ColumnMenuItemModel> MenuItems = new List<ColumnMenuItemModel>() { 
        new ColumnMenuItemModel { Text = "Clear Sorting", Id = "sort" },
        new ColumnMenuItemModel { Text = "Clear Grouping", Id = "group" }
    };
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
    public void ColumnMenuItemClickedHandler(ColumnMenuClickEventArgs args)
    {
        switch (args.Item.Id)
        {
            case "sort":
                Grid.ClearSortingAsync();
                break;
            case "group":
                Grid.ClearGroupingAsync();
                break;
        }
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
public class OrderData
{
    public static List<OrderData> Order = new List<OrderData>();
    public OrderData(int OrderID, double Freight, string CustomerId, string ShipCity)
    {
        this.OrderID = OrderID;
        this.Freight = Freight;
        this.CustomerID = CustomerId;
        this.ShipCity = ShipCity;
    }
    public static List<OrderData> GetAllRecords()
    {
        if (Order.Count == 0)
        {
            Order.Add(new OrderData(10248, 32.38, "VINET", "Reims"));
            Order.Add(new OrderData(10249, 11.61, "TOMSP", "Münster"));
            Order.Add(new OrderData(10250, 65.83, "HANAR", "Rio de Janeiro"));
            Order.Add(new OrderData(10251, 41.34, "VICTE", "Lyon"));
            Order.Add(new OrderData(10252, 51.3, "SUPRD", "Charleroi"));
            Order.Add(new OrderData(10253, 58.17, "HANAR", "Rio de Janeiro"));
            Order.Add(new OrderData(10254, 22.98, "CHOPS", "Bern"));
            Order.Add(new OrderData(10255, 148.33, "RICSU", "Genève"));
            Order.Add(new OrderData(10256, 13.97, "WELLI", "Resende"));
            Order.Add(new OrderData(10257, 81.91, "HILAA", "San Cristóbal"));
            Order.Add(new OrderData(10258, 140.51, "ERNSH", "Graz"));
            Order.Add(new OrderData(10259, 3.25, "CENTC", "México D.F."));
            Order.Add(new OrderData(10260, 55.09, "OTTIK", "Köln"));
            Order.Add(new OrderData(10261, 3.05, "QUEDE", "Rio de Janeiro"));
            Order.Add(new OrderData(10262, 48.29, "RATTC", "Albuquerque"));
        }
        return Order;
    }
    public int OrderID { get; set; }
    public double Freight { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/htVJMrMgCLBDWpXz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customize menu items for specific columns

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows customizing the visibility of column menu items for specific columns. This is useful when certain actions, such as filtering or grouping, should not be available for specific columns.

To hide a menu item for a specific column, set the [MenuItem.Hidden](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuItem.html#Syncfusion_Blazor_Navigations_MenuItem_Hidden) property to **true** in the [OnColumnMenuOpen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnColumnMenuOpen) event.

The **Filter** item is hidden when the column menu is opened for the **OrderID** column.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" Height="315" AllowFiltering="true" AllowGrouping="true" ShowColumnChooser="true" AllowSorting="true" ShowColumnMenu="true">
    <GridEvents OnColumnMenuOpen="OnColumnMenuOpenHandler" TValue="OrderData"></GridEvents>
    <GridFilterSettings Type="FilterType.Menu"></GridFilterSettings>
    <GridGroupSettings ShowGroupedColumn="true"></GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    private SfGrid<OrderData> DefaultGrid;
    public List<OrderData> Orders { get; set; }
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
    public void OnColumnMenuOpenHandler(ColumnMenuOpenEventArgs args)
    {
        foreach (var item in args.Items)
        {
            // Hide the "Filter" option for the "OrderID" column
            if (item.Text == "Filter" && args.Column.Field == "OrderID")
            {
                item.Hidden = true;
            }
            else
            {
                item.Hidden = false;
            }
        }
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
public class OrderData
{
    public static List<OrderData> Order = new List<OrderData>();
    public OrderData(int OrderID, double Freight, string CustomerId, string ShipCity, string ShipCountry)
    {
        this.OrderID = OrderID;
        this.Freight = Freight;
        this.ShipCity = ShipCity;
        this.CustomerID = CustomerId;
        this.ShipCountry = ShipCountry;
    }
    public static List<OrderData> GetAllRecords()
    {
        if (Order.Count == 0)
        {
            Order.Add(new OrderData(10248, 32.38, "VINET", "Reims", "Australia"));
            Order.Add(new OrderData(10249, 11.61, "TOMSP", "Münster", "Australia"));
            Order.Add(new OrderData(10250, 65.83, "HANAR", "Rio de Janeiro", "United States"));
            Order.Add(new OrderData(10251, 41.34, "VICTE", "Lyon", "Australia"));
            Order.Add(new OrderData(10252, 51.3, "SUPRD", "Charleroi","United States"));
            Order.Add(new OrderData(10253, 58.17, "HANAR", "Rio de Janeiro","United States"));
            Order.Add(new OrderData(10254, 22.98, "CHOPS", "Bern", "Switzerland"));
            Order.Add(new OrderData(10255, 148.33, "RICSU", "Genève", "Switzerland"));
            Order.Add(new OrderData(10256, 13.97, "WELLI", "Resende", "Brazil"));
            Order.Add(new OrderData(10257, 81.91, "HILAA", "San Cristóbal", "Venezuela"));
            Order.Add(new OrderData(10258, 140.51, "ERNSH", "Graz", "Austria"));
            Order.Add(new OrderData(10259, 3.25, "CENTC", "México D.F.", "Mexico"));
            Order.Add(new OrderData(10260, 55.09, "OTTIK", "Köln", "Germany"));
            Order.Add(new OrderData(10261, 3.05, "QUEDE", "Rio de Janeiro", "Brazil"));
            Order.Add(new OrderData(10262, 48.29, "RATTC", "Albuquerque", "USA"));
        }
        return Order;
    }
    public int OrderID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
    public string CustomerID { get; set; }
    public string ShipCountry { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtrJWVWUgqiNTWDr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Render nested column menu

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports rendering a nested column menu that provides extended options within the column header menu. This feature allows organizing related actions under submenus for better usability.

To enable a nested column menu, define the [ColumnMenuItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ColumnMenuItems) property. This property accepts a collection of [ColumnMenuItemModel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnMenuItemModel.html) objects, where each item can include a submenu by specifying its [Items](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnMenuItemModel.html#Syncfusion_Blazor_Grids_ColumnMenuItemModel_Items) property.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations

<SfGrid @ref="DefaultGrid" DataSource="@Orders" Height="315" AllowGrouping="true" ShowColumnChooser="true" AllowSorting="true" ShowColumnMenu="true" AllowFiltering="true" ColumnMenuItems=@menuItem>
    <GridEvents ColumnMenuItemClicked="ColumnMenuItemClickedHandler" TValue="Order"></GridEvents>
    <GridFilterSettings Type="FilterType.CheckBox"></GridFilterSettings>
    <GridGroupSettings ShowGroupedColumn="true"></GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150" TextAlign="TextAlign.Center"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" TextAlign="TextAlign.Center" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    private SfGrid<OrderData> DefaultGrid;
    public List<ColumnMenuItemModel> menuItem = new List<ColumnMenuItemModel> { new ContextMenuItemModel { Text = "Group", Id = "group" }, new ContextMenuItemModel { Text = "UnGroup", Id = "UnGroup" }, new ContextMenuItemModel { Text = "ColumnChooser", Id = "ColumnChooser" }, new ContextMenuItemModel { Text = "SubMenu", Id = "SubMenu", Items = (new List<MenuItem> { new MenuItem { Text = "Option1", Id = "Uniq", Items = (new List<MenuItem> { new MenuItem { Text = "Nested", Id = "New" } }) } }) } };

    public List<OrderData> Orders { get; set; }
   
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
    public void ColumnMenuItemClickedHandler(ColumnMenuClickEventArgs args)
    {
        if (args.Item.Text == "Group")
        {
            DefaultGrid.GroupColumnAsync("CustomerID");
        }
        else if (args.Item.Text == "UnGroup")
        {
            DefaultGrid.UngroupColumnAsync("CustomerID");
        }
        else if (args.Item.Text == "ColumnChooser")
        {
            DefaultGrid.OpenColumnChooserAsync(10, 10);
        }
        else if (args.Item.Text == "Option1")
        {
             // custom function
            // Here, you can customize your code.
        }
        else
        {
            // Here, you can customize your code.
        }
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();
    public OrderData(int? OrderID, string CustomerID, double Freight,string ShipCountry)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.Freight = Freight;
        this.ShipCountry = ShipCountry;
    }
    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            int code = 10;
            for (int i = 1; i < 2; i++)
            {
                Orders.Add(new OrderData(10248, "ALFKI",33.32, "France"));
                Orders.Add(new OrderData(10249, "ANANTR", 34.32, "Germany"));
                Orders.Add(new OrderData(10250, "ANTON", 36.32, "Brazil"));
                Orders.Add(new OrderData(10251, "BLONP", 54.31, "Belgium"));
                Orders.Add(new OrderData(10252, "BOLID",35.36, "Switzerland"));
                Orders.Add(new OrderData(10253, "ANTON", 37.35, "Switzerland"));
                Orders.Add(new OrderData(10254, "BLONP", 33.32, "Germany"));
                Orders.Add(new OrderData(10255, "BOLID", 76.74, "Germany"));
                Orders.Add(new OrderData(10256, "ALFKI",55.43, "Belgium"));                   
                code += 5;
            }
        }
        return Orders;
    }
    public int? OrderID { get; set; }
    public string CustomerID { get; set; }      
    public double? Freight { get; set; }
    public string ShipCountry { get; set; }
}
{% endhighlight %}
{% endtabs %}

## Customize the icon of column menu

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows customizing the column menu icon by overriding the default CSS class **.e-icons.e-columnmenu**. This is achieved by applying a custom CSS rule with the **content** property to display a different icon or Unicode character.

**Steps to customize the icon:**

1. Override the default CSS class:

```css
.e-grid .e-columnheader .e-icons.e-columnmenu::before {
   content: "\e99a";
}
```
2. Import the icon stylesheet based on the selected theme preference:

```css
<link href="https://cdn.syncfusion.com/ej2/ej2-icons/styles/material.css" rel="stylesheet" />
<link href="https://cdn.syncfusion.com/ej2/ej2-icons/styles/bootstrap5.css" rel="stylesheet" />
```

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" ShowColumnMenu="true">
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" TextAlign="TextAlign.Center" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
<style>
    .e-grid .e-columnheader .e-icons.e-columnmenu::before {
       content: "\e99a";
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

    public OrderData(int OrderID, string CustomerID, double Freight, string ShipName)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;
        this.Freight = Freight;
        this.ShipName = ShipName; 
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "ALFKI", 33.32, "Ever Given"));
            Orders.Add(new OrderData(10249, "ANANTR", 34.32, "Queen Mary 2"));
            Orders.Add(new OrderData(10250, "ANTON", 36.32, "Maersk Alabama"));
            Orders.Add(new OrderData(10251, "BLONP", 54.31, "Titanic"));
            Orders.Add(new OrderData(10252, "BOLID", 35.36, "Santa Maria"));
            Orders.Add(new OrderData(10253, "ANTON", 37.35, "Black Pearl"));
            Orders.Add(new OrderData(10254, "BLONP", 33.32, "Sea Cloud"));
            Orders.Add(new OrderData(10255, "BOLID", 76.74, "Symphony of the Seas"));
            Orders.Add(new OrderData(10256, "ALFKI", 55.43, "Aurora"));
        }
        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipName { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNrnZiBlzsPHBORW?appbar=false&editor=false&result=true&errorlist=false&theme=material" %}

## Column menu events

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides events that are triggered during column menu interactions. These events allow execution of custom logic before the menu opens and after an item is clicked, enabling customization and UI updates.

1. [OnColumnMenuOpen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnColumnMenuOpen): Triggered before the column menu opens.
2. [ColumnMenuItemClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_ColumnMenuItemClicked): Triggered when a column menu item is clicked.

### OnColumnMenuOpen

The `OnColumnMenuOpen` event is triggered before the column menu opens. This event can be used to inspect or modify the menu or cancel its opening based on custom logic.

**Event Arguments**

The event uses the [ColumnMenuOpenEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnMenuOpenEventArgs.html) class, which includes:

| Property          | Type                                | Description                                                                                     |
|-------------------|-------------------------------------|-------------------------------------------------------------------------------------------------|
| Cancel          | bool                             | Indicates whether to prevent the column menu from opening. Set to **true** to cancel opening. |
| Column          | GridColumn                       | Represents the grid column where the column menu is currently open.                           |
| ColumnMenuIndex | int                              | Indicates the level of the menu item within the menu hierarchy. Starts from 0 for top-level. |
| Items           | List&lt;MenuItem&gt;                   | The list of menu items displayed in the column menu.                                          |
| Left            | double                           | The left position of the column menu relative to the document or container.                  |
| ParentItem`      | MenuItem                         | The parent menu item of the currently clicked sub-menu item. Null if no parent exists.       |
| Top             | double                           | The top position of the column menu relative to the document or container.                   |

### ColumnMenuItemClicked

The `ColumnMenuItemClicked` event is triggered when a column menu item is clicked. This event can be used to perform actions based on the selected menu item.

**Event Arguments**

The event uses the [ColumnMenuClickEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnMenuClickEventArgs.html) class, which includes:

| Property | Type | Description |
|----------|------|-------------|
| Column   | GridColumn | The grid column associated with the column menu popup. |
| Element  | ElementReference | The DOM element that triggered the event. |
| Event    | System.EventArgs | Provides event details for the column menu interaction. |
| Item     | Navigations.MenuItemModel | The menu item that was clicked in the column menu. |


{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<div style="text-align: center; color: red">
    <span>@ColumnMenuMessage</span>
</div>
<SfGrid @ref="Grid" DataSource="@Orders" Height="315" ShowColumnMenu="true" AllowFiltering="true" AllowGrouping="true" AllowPaging="true" AllowSorting="true">
    <GridFilterSettings Type="FilterType.Excel"></GridFilterSettings>
    <GridGroupSettings ShowGroupedColumn="true"></GridGroupSettings>
    <GridEvents ColumnMenuItemClicked="ColumnMenuItemClickedHandler" OnColumnMenuOpen="OnColumnMenuOpenHandler" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Center" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Center" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    private SfGrid<OrderData> Grid;
    public string ColumnMenuMessage;    
    public List<OrderData> Orders { get; set; }
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
    public void OnColumnMenuOpenHandler(ColumnMenuOpenEventArgs args)
    {
        ColumnMenuMessage= "OnColumnMenuOpen event triggered";
    }
    public void ColumnMenuItemClickedHandler(ColumnMenuClickEventArgs args)
    {
        ColumnMenuMessage= "ColumnMenuItemClicked event triggered";    
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
public class OrderData
{
    public static List<OrderData> Order = new List<OrderData>();
    public OrderData(int OrderID, double Freight, string CustomerId, string ShipCity)
    {
        this.OrderID = OrderID;
        this.Freight = Freight;
        this.CustomerID = CustomerId;
        this.ShipCity = ShipCity;
    }
    public static List<OrderData> GetAllRecords()
    {
        if (Order.Count == 0)
        {
            Order.Add(new OrderData(10248, 32.38, "VINET", "Reims"));
            Order.Add(new OrderData(10249, 11.61, "TOMSP", "Münster"));
            Order.Add(new OrderData(10250, 65.83, "HANAR", "Rio de Janeiro"));
            Order.Add(new OrderData(10251, 41.34, "VICTE", "Lyon"));
            Order.Add(new OrderData(10252, 51.3, "SUPRD", "Charleroi"));
            Order.Add(new OrderData(10253, 58.17, "HANAR", "Rio de Janeiro"));
            Order.Add(new OrderData(10254, 22.98, "CHOPS", "Bern"));
            Order.Add(new OrderData(10255, 148.33, "RICSU", "Genève"));
            Order.Add(new OrderData(10256, 13.97, "WELLI", "Resende"));
            Order.Add(new OrderData(10257, 81.91, "HILAA", "San Cristóbal"));
            Order.Add(new OrderData(10258, 140.51, "ERNSH", "Graz"));
            Order.Add(new OrderData(10259, 3.25, "CENTC", "México D.F."));
            Order.Add(new OrderData(10260, 55.09, "OTTIK", "Köln"));
            Order.Add(new OrderData(10261, 3.05, "QUEDE", "Rio de Janeiro"));
            Order.Add(new OrderData(10262, 48.29, "RATTC", "Albuquerque"));
        }
        return Order;
    }
    public int OrderID { get; set; }
    public double Freight { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rthfMhiKzNimycPe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
