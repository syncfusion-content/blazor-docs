---
layout: post
title: Column Menu in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about column menu in the Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Column Menu in Blazor DataGrid

The column menu in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides options to enable features such as sorting, grouping, filtering, column chooser, and autofit. When users click on the column header’s menu icon, a menu will be displayed with these integrated features. To enable the column menu, you need to set the [ShowColumnMenu](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ShowColumnMenu) property to true in the Grid configuration.

The default menu items are displayed in the following table:

| Item | Description |
|-----|-----|
| **SortAscending** | Sort the current column in ascending order. |
| **SortDescending** | Sort the current column in descending order. |
| **Group** | Group the current column. |
| **Ungroup** | Ungroup the current column. |
| **AutoFit** | Auto fit the current column. |
| **AutoFitAll** | Auto fit all columns. |
| **ColumnChooser** | Choose the column visibility. |
| **Filter** | Show the filter option as given in filterSettings [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridFilterSettings.html#Syncfusion_Blazor_Grids_GridFilterSettings_Type) property |

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

> *  You can disable column menu for a particular column by defining the column's [ShowColumnMenu](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ShowColumnMenu) property as false.
> * You can customize the default menu items by defining the [ColumnMenuItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ColumnMenuItems) with the required items.

## Prevent column menu for particular column

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides the ability to prevent the appearance of the column menu for specific columns. This feature is useful when you want to restrict certain columns from being customizable through the column menu.

To prevent the column menu for a particular column, you can set the [ShowColumnMenu](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ShowColumnMenu) property to **false** for that specific column configuration. This will disable the column menu options specifically for the designated column, while other columns will have the column menu enabled.

The following example demonstrates how to prevent the column menu for a specific column. In this example, the column menu is disabled for the **OrderID** column by setting the `ShowColumnMenu` property to **false**:

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

The custom column menu item feature allows you to add additional menu items to the column menu in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid. These custom menu items can be defined using the [ColumnMenuItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ColumnMenuItems) property, which accepts a collection of [ColumnMenuItemModel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnMenuItemModel.html) class.You can define the actions for these custom items in the [ColumnMenuItemClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_ColumnMenuItemClicked) event.

Consider the following example, which demonstrates how to add a custom column menu item to clear the sorting and grouping of the Grid using the [ClearSortingAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ClearSortingAsync_System_Collections_Generic_List_System_String__)  and [ClearGroupingAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ClearGroupingAsync) method in the `ColumnMenuItemClicked` event:

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

## Customize menu items for particular columns

Sometimes, you have a scenario that to hide an item from column menu for particular columns. In that case, you need to define the [MenuItem.Hidden](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.MenuItem.html#Syncfusion_Blazor_Navigations_MenuItem_Hidden) property as **true** in the [OnColumnMenuOpen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnColumnMenuOpen) event.

The following sample, **Filter** item was hidden in column menu when opens for the **OrderID** column:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid @ref="DefaultGrid" DataSource="@Orders" Height="315" AllowFiltering="true" AllowGrouping="true" ShowColumnChooser="true" AllowSorting="true" ShowColumnMenu="true">
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

The nested column menu feature provides an extended menu option in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid column headers, allows you to access additional actions and options related to the columns.

To enable the nested column menu feature, you need to define the [ColumnMenuItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ColumnMenuItems) property in your component. The `ColumnMenuItems` property is an array that contains the items for the column menu. Each item can be a string representing a built-in menu item or an object defining a custom menu item.

Here is an example of how to configure the `ColumnMenuItems` property to include a nested menu:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations

<SfGrid @ref="DefaultGrid" DataSource="@Orders" Height="315" AllowGrouping="true" ShowColumnChooser="true" AllowSorting="true" ShowColumnMenu="true" AllowFiltering="true" ColumnMenuItems=@menuItem>
    <GridEvents ColumnMenuItemClicked="ColumnMenuItemClickedHandler" TValue="OrderData"></GridEvents>
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

To customize the column menu icon, you need to override the default Grid class `.e-icons.e-columnmenu` with a custom CSS property called **content**. By specifying a Unicode character or an icon font’s CSS class, you can change the icon displayed in the column menu.

1. Add the necessary CSS code to override the default Grid class:

```css
.e-grid .e-columnheader .e-icons.e-columnmenu::before {
   content: "\e99a";
}
```
2. Import the required icon stylesheets. You can use either the material or bootstrap5 style, depending on your preference. Add the following code to import the stylesheets:

```css
<link href="https://cdn.syncfusion.com/ej2/ej2-icons/styles/material.css" rel="stylesheet" />
<link href="https://cdn.syncfusion.com/ej2/ej2-icons/styles/bootstrap5.css" rel="stylesheet" />
```
Here is an example that demonstrates how to customize the column menu icon in the Grid:

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LthetSqtfZnABCcg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Column menu events

The column menu in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides a set of events that allow customization of behavior and performing actions when the column menu is opened or clicked. The below events are helpful for adding additional functionality or implementing specific actions based on user interactions with the column menu.

1. The [OnColumnMenuOpen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnColumnMenuOpen) event triggers before the column menu opens.

2. The [ColumnMenuItemClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_ColumnMenuItemClicked) event triggers when the user clicks the column menu of the Grid.

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

<!-- Column spanning

The grid has option to span the adjacent cells. To achieve this, define the [`ColSpan`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.QueryCellInfoEventArgs-1.html#Syncfusion_Blazor_Grids_QueryCellInfoEventArgs_1_ColSpan) attribute in the [`QueryCellInfo`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_QueryCellInfo) event.

In the following demo, the cells have been spanned based on the employees schedule

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@MergeData" GridLines=GridLine.Both AllowTextWrap="true">
        <GridEvents TValue="@Merge" QueryCellInfo="QueryCellEvent"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Merge.EmployeeID) TextAlign="TextAlign.Right" HeaderText="Employee ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Merge.EmployeeName) HeaderText="Employee Name" Width="200"></GridColumn>
        <GridColumn Field=@nameof(Merge.Time900) HeaderText="9.00 AM" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Merge.Time930) HeaderText="9.30 AM" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Merge.Time1000) HeaderText="10.00 AM" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Merge.Time1030) HeaderText="10.30 AM" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Merge.Time1100) HeaderText="11.00 AM" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Merge.Time1130) HeaderText="11.30 AM" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Merge.Time1200) HeaderText="12.00 PM" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Merge.Time1230) HeaderText="12.30 PM" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Merge.Time100) HeaderText="1.00 PM" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Merge.Time130) HeaderText="1.30 PM" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Merge.Time200) HeaderText="2.00 PM" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Merge.Time230) HeaderText="2.30 PM" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Merge.Time300) HeaderText="3.00 PM" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Merge.Time330) HeaderText="3.30 PM" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Merge.Time400) HeaderText="4.00 PM" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Merge.Time430) HeaderText="4.30 PM" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Merge.Time500) HeaderText="5.00 PM" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    List<Merge> MergeData = new List<Merge>
    {
        new Merge() { Time900 = "Analysis Tasks", Time930 = "Analysis Tasks", Time1000 = "Team Meeting", Time1030 = "Testing", Time1100 = "Development", Time1130 = "Development", Time1200 = "Development", Time1230 = "Support", Time100 = "Lunch Break", Time130 = "Lunch Break", Time200 = "Lunch Break", Time230 = "Testing", Time300 = "Testing", Time330 = "Development", Time400 = "Conference", Time430 = "Team Meeting", Time500 = "Team Meeting", EmployeeID = 10001, EmployeeName = "Davolio" },
        new Merge() { Time900 = "Task Assign", Time930 = "Support", Time1000 = "Support", Time1030 = "Support", Time1100 = "Testing", Time1130 = "Testing", Time1200 = "Testing", Time1230 = "Testing", Time100 = "Lunch Break", Time130 = "Lunch Break", Time200 = "Lunch Break", Time230 = "Development", Time300 = "Development", Time330 = "Check Mail", Time400 = "Check Mail", Time430 = "Team Meeting", Time500 = "Team Meeting", EmployeeID = 10002, EmployeeName = "Buchanan" },
        new Merge() { Time900 = "Check Mail", Time930 = "Check Mail", Time1000 = "Check Mail", Time1030 = "Analysis Tasks", Time1100 = "Analysis Tasks", Time1130 = "Support", Time1200 = "Support", Time1230 = "Support", Time100 = "Lunch Break", Time130 = "Lunch Break", Time200 = "Lunch Break", Time230 = "Development", Time300 = "Development", Time330 = "Team Meeting", Time400 = "Team Meeting", Time430 = "Development", Time500 = "Development", EmployeeID = 10003, EmployeeName = "Fuller" },
        new Merge() { Time900 = "Testing", Time930 = "Check Mail", Time1000 = "Check Mail", Time1030 = "Support", Time1100 = "Testing", Time1130 = "Testing", Time1200 = "Testing", Time1230 = "Testing", Time100 = "Lunch Break", Time130 = "Lunch Break", Time200 = "Lunch Break", Time230 = "Development", Time300 = "Development", Time330 = "Check Mail", Time400 = "Conference", Time430 = "Conference", Time500 = "Team Meeting", EmployeeID = 10004, EmployeeName = "Leverling" },
        new Merge() { Time900 = "Task Assign", Time930 = "Task Assign", Time1000 = "Task Assign", Time1030 = "Task Assign", Time1100 = "Check Mail", Time1130 = "Support", Time1200 = "Support", Time1230 = "Support", Time100 = "Lunch Break", Time130 = "Lunch Break", Time200 = "Lunch Break", Time230 = "Development", Time300 = "Development", Time330 = "Team Meeting", Time400 = "Team Meeting", Time430 = "Testing", Time500 = "Testing", EmployeeID = 10005, EmployeeName = "Peacock" },
        new Merge() { Time900 = "Testing", Time930 = "Testing", Time1000 = "Support", Time1030 = "Support", Time1100 = "Support", Time1130 = "Team Meeting", Time1200 = "Team Meeting", Time1230 = "Team Meeting", Time100 = "Lunch Break", Time130 = "Lunch Break", Time200 = "Lunch Break", Time230 = "Development", Time300 = "Development", Time330 = "Team Meeting", Time400 = "Team Meeting", Time430 = "Development", Time500 = "Development", EmployeeID = 10006, EmployeeName = "Janet" },
        new Merge() { Time900 = "Analysis Tasks", Time930 = "Analysis Tasks", Time1000 = "Testing", Time1030 = "Development", Time1100 = "Development", Time1130 = "Testing", Time1200 = "Testing", Time1230 = "Testing", Time100 = "Lunch Break", Time130 = "Lunch Break", Time200 = "Lunch Break", Time230 = "Support", Time300 = "Build", Time330 = "Build", Time400 = "Check Mail", Time430 = "Check Mail", Time500 = "Check Mail", EmployeeID = 10007, EmployeeName = "Suyama" },
        new Merge() { Time900 = "Task Assign", Time930 = "Task Assign", Time1000 = "Task Assign", Time1030 = "Development", Time1100 = "Development", Time1130 = "Development", Time1200 = "Testing", Time1230 = "Support", Time100 = "Lunch Break", Time130 = "Lunch Break", Time200 = "Lunch Break", Time230 = "Check Mail", Time300 = "Check Mail", Time330 = "Check Mail", Time400 = "Team Meeting", Time430 = "Team Meeting", Time500 = "Build", EmployeeID = 10008, EmployeeName = "Robert" },
        new Merge() { Time900 = "Check Mail", Time930 = "Team Meeting", Time1000 = "Team Meeting", Time1030 = "Support", Time1100 = "Testing", Time1130 = "Development", Time1200 = "Development", Time1230 = "Development", Time100 = "Lunch Break", Time130 = "Lunch Break", Time200 = "Lunch Break", Time230 = "Check Mail", Time300 = "Check Mail", Time330 = "Check Mail", Time400 = "Team Meeting", Time430 = "Development", Time500 = "Development", EmployeeID = 10009, EmployeeName = "Andrew" },
        new Merge() { Time900 = "Task Assign", Time930 = "Task Assign", Time1000 = "Task Assign", Time1030 = "Analysis Tasks", Time1100 = "Analysis Tasks", Time1130 = "Development", Time1200 = "Development", Time1230 = "Development", Time100 = "Lunch Break", Time130 = "Lunch Break", Time200 = "Lunch Break", Time230 = "Testing", Time300 = "Testing", Time330 = "Testing", Time400 = "Build", Time430 = "Build", Time500 = "Build", EmployeeID = 10010, EmployeeName = "Michael" }
    };

    public class Merge
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public string Time900 { get; set; }
        public string Time930 { get; set; }
        public string Time1000 { get; set; }
        public string Time1030 { get; set; }
        public string Time1100 { get; set; }
        public string Time1130 { get; set; }
        public string Time1200 { get; set; }
        public string Time1230 { get; set; }
        public string Time100 { get; set; }
        public string Time130 { get; set; }
        public string Time200 { get; set; }
        public string Time230 { get; set; }
        public string Time300 { get; set; }
        public string Time330 { get; set; }
        public string Time400 { get; set; }
        public string Time430 { get; set; }
        public string Time500 { get; set; }
    }

    public void QueryCellEvent(QueryCellInfoEventArgs<Merge> args)
    {
        var Data = args.Data;
        switch (Data.EmployeeID) {
            case 10001:
                if(args.Column.Field == "Time900" || args.Column.Field == "Time230" || args.Column.Field == "Time430") {
                    args.ColSpan = 2;
                    StateHasChanged();
                } else if(args.Column.Field == "Time1100") {
                    args.ColSpan = 3;
                    StateHasChanged();
                }
                break;
            case 10002:
                if(args.Column.Field == "Time930" || args.Column.Field == "Time230" || args.Column.Field == "Time430") {
                    args.ColSpan = 3;
                    StateHasChanged();
                } else if(args.Column.Field == "Time1100") {
                    args.ColSpan = 4;
                    StateHasChanged();
                }
                break;
            case 10003:
                if(args.Column.Field == "Time900" || args.Column.Field == "Time1130") {
                    args.ColSpan = 3;
                    StateHasChanged();
                } else if(args.Column.Field == "Time1030" || args.Column.Field == "Time230" || args.Column.Field == "Time330" || args.Column.Field == "Time430") {
                    args.ColSpan = 2;
                    StateHasChanged();
                }
                break;
            case 10004:
                if(args.Column.Field == "Time900") {
                    args.ColSpan = 3;
                    StateHasChanged();
                } else if(args.Column.Field == "Time1100") {
                    args.ColSpan = 4;
                    StateHasChanged();
                } else if(args.Column.Field == "Time230" || args.Column.Field == "Time400") {
                    args.ColSpan = 2;
                    StateHasChanged();
                }
                break;
            case 10005:
                if(args.Column.Field == "Time900") {
                    args.ColSpan = 4;
                    StateHasChanged();
                } else if(args.Column.Field == "Time1130") {
                    args.ColSpan = 3;
                    StateHasChanged();
                } else if(args.Column.Field == "Time230" || args.Column.Field == "Time330" || args.Column.Field == "Time430") {
                    args.ColSpan = 2;
                    StateHasChanged();
                }
                break;
            case 10006:
                if(args.Column.Field == "Time900" || args.Column.Field == "Time230" || args.Column.Field == "Time330" || args.Column.Field == "Time430") {
                    args.ColSpan = 2;
                    StateHasChanged();
                } else if(args.Column.Field == "Time1000" || args.Column.Field == "Time1130") {
                    args.ColSpan = 3;
                    StateHasChanged();
                }
                break;
            case 10007:
                if(args.Column.Field == "Time900" || args.Column.Field == "Time1030" || args.Column.Field == "Time300") {
                    args.ColSpan = 2;
                    StateHasChanged();
                } else if(args.Column.Field == "Time1130" || args.Column.Field == "Time400") {
                    args.ColSpan = 3;
                    StateHasChanged();
                }
                break;
            case 10008:
                if(args.Column.Field == "Time900" || args.Column.Field == "Time1030" || args.Column.Field == "Time230") {
                    args.ColSpan = 3;
                    StateHasChanged();
                } else if(args.Column.Field == "Time400") {
                    args.ColSpan = 2;
                    StateHasChanged();
                }
                break;
            case 10009:
                if(args.Column.Field == "Time900" || args.Column.Field == "Time1130") {
                    args.ColSpan = 3;
                    StateHasChanged();
                } else if(args.Column.Field == "Time230" || args.Column.Field == "Time430") {
                    args.ColSpan = 2;
                    StateHasChanged();
                }
                break;
            case 100010:
                if(args.Column.Field == "Time900" || args.Column.Field == "Time1130" || args.Column.Field == "Time230" || args.Column.Field == "Time400") {
                    args.ColSpan = 3;
                    StateHasChanged();
                } else if(args.Column.Field == "Time1030") {
                    args.ColSpan = 2;
                    StateHasChanged();
                }
                break;
        }
    }
}
``` 

The following GIF shows the column spanning in Grid -->