---
layout: post
title: Column Menu in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about column menu in the Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Column Menu in Blazor DataGrid

The column menu in the Syncfusion Blazor Grid component provides options to enable features such as sorting, grouping, filtering, column chooser, and autofit. When users click on the column header’s menu icon, a menu will be displayed with these integrated features. To enable the column menu, you need to set the [ShowColumnMenu](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ShowColumnMenu) property to true in the Grid configuration.

The default menu items are displayed in the following table,

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
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" Height="315" AllowGrouping="true" ColumnMenuItems=@MenuItems AllowFiltering="true" ShowColumnMenu="true" AllowPaging="true">
    <GridFilterSettings Type="FilterType.CheckBox"></GridFilterSettings>
    <GridGroupSettings ShowGroupedColumn="true"></GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150" TextAlign="TextAlign.Center" ShowColumnMenu="false"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" TextAlign="TextAlign.Center" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public string[] MenuItems = new string[] { "Group", "Ungroup", "ColumnChooser", "Filter" };
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
        public OrderData(int? OrderID, string CustomerID, DateTime OrderDate, double Freight,string ShipCity)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.Freight = Freight;
            this.ShipCity = ShipCity;          
        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "ALFKI",33.32, "Reims"));
                    Orders.Add(new OrderData(10249, "ANANTR",34.32, "Münster"));
                    Orders.Add(new OrderData(10250, "ANTON", 36.32, "Rio de Janeiro"));
                    Orders.Add(new OrderData(10251, "BLONP", 54.31, "Lyon"));
                    Orders.Add(new OrderData(10252, "BOLID",35.36, "Charleroi"));
                    Orders.Add(new OrderData(10253, "ANTON", 37.35, "Lyon"));
                    Orders.Add(new OrderData(10254, "BLONP", 33.32, "Rio de Janeiro"));
                    Orders.Add(new OrderData(10255, "BOLID", 76.74, "Münster"));
                    Orders.Add(new OrderData(10256, "ALFKI",55.43, "Reims"));                   
                    code += 5;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public double? Freight { get; set; }
        public string ShipCity { get; set; }

    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXrUsijhhkfMyNWj?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> *  You can disable column menu for a particular column by defining the column's [ShowColumnMenu](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ShowColumnMenu) property as false.
> * You can customize the default menu items by defining the [ColumnMenuItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ContextMenuItems) with the required items.

## Prevent column menu for particular column

The Syncfusion Blazor DataGrid component provides the ability to prevent the appearance of the column menu for specific columns. This feature is useful when you want to restrict certain columns from being customizable through the column menu.

To prevent the column menu for a particular column, you can set the [ShowColumnMenu](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_ShowColumnMenu) property to **false** for that specific column configuration. This will disable the column menu options specifically for the designated column, while other columns will have the column menu enabled.

The following example demonstrates how to prevent the column menu for a specific column. In this example, the column menu is disabled for the **OrderID** column by setting the `showColumnMenu` property to **false**.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" Height="315" AllowSorting="true" AllowGrouping="true" AllowFiltering="true" ShowColumnMenu="true" AllowPaging="true">
    <GridFilterSettings Type="FilterType.CheckBox"></GridFilterSettings>
    <GridGroupSettings ShowGroupedColumn="true"></GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" ShowColumnMenu="false" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name"  Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    public List<OrderDetails> OrderData { get; set; }    
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    
    public OrderDetails(int OrderID, string CustomerId, string Shipcity,  string Shipcountry, double Freight)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.ShipCity = Shipcity;
        this.ShipCountry = Shipcountry;
        this.Freight = Freight; 
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", "Reims", "France",  32.38));
            order.Add(new OrderDetails(10249, "TOMSP", "Münster", "Germany",  11.61));
            order.Add(new OrderDetails(10250, "HANAR", "Rio de Janeiro", "Brazil",  65.83));
            order.Add(new OrderDetails(10251, "VICTE", "Lyon", "France", 41.34));
            order.Add(new OrderDetails(10252, "SUPRD", "Charleroi", "Belgium", 51.3));
            order.Add(new OrderDetails(10253, "HANAR", "Rio de Janeiro", "Brazil",  58.17));
            order.Add(new OrderDetails(10254, "CHOPS", "Bern", "Switzerland",  22.98));
            order.Add(new OrderDetails(10255, "RICSU", "Genève", "Switzerland",  148.33));
            order.Add(new OrderDetails(10256, "WELLI",  "Resende", "Brazil",  13.97));
            order.Add(new OrderDetails(10257, "HILAA", "San Cristóbal", "Venezuela",  81.91));
            order.Add(new OrderDetails(10258, "ERNSH", "Graz", "Austria",  140.51));
            order.Add(new OrderDetails(10259, "CENTC", "México D.F.", "Mexico", 3.25));
            order.Add(new OrderDetails(10260, "OTTIK", "Köln",  "Germany", 55.09));
            order.Add(new OrderDetails(10261, "QUEDE", "Rio de Janeiro", "Brazil", 3.05));
            order.Add(new OrderDetails(10262, "RATTC", "Albuquerque", "USA", 48.29));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
    public double Freight { get; set; } 
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDBfiCVHTnFFingT?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Add custom column menu item

The custom column menu item feature allows you to add additional menu items to the column menu in the Syncfusion Grid. These custom menu items can be defined using the [ColumnMenuItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ColumnMenuItems) property, which accepts a collection of [ColumnMenuItemModel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnMenuItemModel.html) class.You can define the actions for these custom items in the [ColumnMenuItemClicked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_ColumnMenuItemClicked) event.

In the following sample, Order ID, Order Date, and Freight columns are sorted at initial rendering. When clicking the custom column menu item in the OrderID column, sorting will be cleared using the [ClearSortingAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ClearSortingAsync_System_Collections_Generic_List_System_String__) method in the `ColumnMenuItemClicked` event.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid @ref="Grid" DataSource="@Orders" Height="315" ColumnMenuItems="@(new List<ColumnMenuItemModel>() { new ColumnMenuItemModel { Text = "Clear Sorting", Id = "OrderID" } })" ShowColumnMenu="true" AllowPaging="true" AllowSorting="true">
    <GridSortSettings>
        <GridSortColumns>
            <GridSortColumn Field="OrderID" Direction="SortDirection.Ascending"></GridSortColumn>
            <GridSortColumn Field="OrderDate" Direction="SortDirection.Ascending"></GridSortColumn>
            <GridSortColumn Field="Freight" Direction="SortDirection.Descending"></GridSortColumn>
        </GridSortColumns>
    </GridSortSettings>
    <GridEvents ColumnMenuItemClicked="ColumnMenuItemClickedHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150" TextAlign="TextAlign.Center" ShowColumnMenu="false"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Center" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Center" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code {
    private SfGrid<OrderData> Grid;
    public List<string> columns = new List<string>() { "OrderID" };

    public List<OrderData> Orders { get; set; }
   
    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
    public void ColumnMenuItemClickedHandler(ColumnMenuClickEventArgs args)
    {
        Grid.ClearSortingAsync(columns);
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
        public OrderData(int? OrderID, string CustomerID, DateTime OrderDate, double Freight,string ShipCity)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.OrderDate = OrderDate;
            this.Freight = Freight;
            this.ShipCity = ShipCity;        

        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "ALFKI",new DateTime(1996,07,08),33.32));
                    Orders.Add(new OrderData(10249, "ANANTR", new DateTime(1996,07,09),34.32));
                    Orders.Add(new OrderData(10250, "ANTON", new DateTime(1996,07,10),36.32));
                    Orders.Add(new OrderData(10251, "BLONP", new DateTime(1996,07,11),54.31));
                    Orders.Add(new OrderData(10252, "BOLID", new DateTime(1996,07,12),35.36));
                    Orders.Add(new OrderData(10253, "ANTON", new DateTime(1996,07,13),37.35));
                    Orders.Add(new OrderData(10254, "BLONP", new DateTime(1996,07,14),33.32));
                    Orders.Add(new OrderData(10255, "BOLID", new DateTime(1996,07,15),76.74));
                    Orders.Add(new OrderData(10256, "ALFKI",new DateTime(1996,07,16),55.43));                   
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXhUXdrXJoJxsVyK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Render nested column menu

The nested column menu feature provides an extended menu option in the grid column headers, allows you to access additional actions and options related to the columns.

To enable the nested column menu feature, you need to define the **ColumnMenuItems** property in your component. The `ColumnMenuItems` property is an array that contains the items for the column menu. Each item can be a string representing a built-in menu item or an object defining a custom menu item.

Here is an example of how to configure the `ColumnMenuItems` property to include a nested menu:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using BlazorApp1.Data

<SfGrid @ref="DefaultGrid" DataSource="@Orders" Height="315" AllowGrouping="true" ShowColumnChooser="true" AllowSorting="true" ShowColumnMenu="true" ColumnMenuItems=@menuItem>
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
        
       
        public OrderData()
        {

        }
        public OrderData(int? OrderID, string CustomerID, double Freight,string ShipCity)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.Freight = Freight;
            this.ShipCountry = ShipCity;        

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

To customize the column menu icon, you need to override the default grid class `.e-icons.e-columnmenu` with a custom CSS property called **content**. By specifying a Unicode character or an icon font’s CSS class, you can change the icon displayed in the column menu.

1.Add the necessary CSS code to override the default grid class:

```css
.e-grid .e-columnheader .e-icons.e-columnmenu::before {
   content: "\e99a";
}
```
2.Import the required icon stylesheets. You can use either the material or bootstrap5 style, depending on your preference. Add the following code to import the stylesheets:

```css
<link href="https://cdn.syncfusion.com/ej2/ej2-icons/styles/material.css" rel="stylesheet" />
<link href="https://cdn.syncfusion.com/ej2/ej2-icons/styles/bootstrap5.css" rel="stylesheet" />
```
Here is an example that demonstrates how to customize the column menu icon in the Syncfusion Grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

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
        
       
        public OrderData()
        {

        }
        public OrderData(int? OrderID, string CustomerID, double Freight,string ShipCity)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.Freight = Freight;
            this.ShipName = ShipCity;         

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
                    Orders.Add(new OrderData(10252, "BOLID", 35.36, "Switzerland"));
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
        public string ShipName { get; set; }
    }
{% endhighlight %}
{% endtabs %}

 {% previewsample "https://blazorplayground.syncfusion.com/embed/LXrgCMDHftqrDkea?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}



<!-- Column menu events

The grid component triggers the below events when column menu operations are performed,

1. [`ColumnMenuOpen`]   -  Triggers before the column menu opens
2. [`ColumnMenuItemClicked`]  -  Triggers when a column menu is clicked

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" ShowColumnMenu="true" AllowGrouping="true" AllowFiltering="true" AllowPaging="true" Height ="315">
<GridEvents ColumnMenuOpen="OnMenuOpen" ColumnMenuItemClicked="OnMenuClick" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerName) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" MinWidth="10" Width="120" MaxWidth="200"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
    </GridColumns>
</SfGrid>

@code{

    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerName = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public void OnMenuOpen() {
        // Perform required operations here
    }

    public void OnMenuClick() {
        // Perform required operations here
    }

    public class Order {
        public int? OrderID { get; set; }
        public string CustomerName { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
``` -->

<!-- Custom column menu item

Custom column menu items can be added by defining the [`ColumnMenuItems`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Type) as a collection of the [`ColumnMenuItemModel`](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Grids.ColumnMenuItemModel.html).

Actions for the customized items can be defined in the [`ColumnMenuItemClicked`] event.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations

<SfGrid @ref="Grid" DataSource="@Orders" Height="315" ColumnMenuItems=@MenuItems AllowSorting="true" ShowColumnMenu="true" AllowPaging="true">
    <GridEvents ColumnMenuItemClicked="OnMenuClick" TValue="Order"></GridEvents>
    <GridSortSettings Columns=@SortSettings></GridSortSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150" TextAlign="TextAlign.Center" ShowColumnMenu="false"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Center" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Center" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{

    private SfGrid<Order> Grid;

    public List<ColumnMenuItemModel> MenuItems = new List<ColumnMenuItemModel>()
    {
        new ColumnMenuItemModel() { Text = "Clear Sorting", Id = "gridclearsorting" }
    };

    public List<SortDescriptorModel> SortSettings = new List<SortDescriptorModel>()
    {
        new SortDescriptorModel() { Direction = SortDirection.Ascending, Field = "OrderID" }
    };

    public class SortSetting
    {
        public string Direction { get; set; }
        public string Field { get; set; }
    }

    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }

    public void OnMenuClick(MenuEventArgs args)
    {
        if (args.Item.Id == "gridclearsorting") {
            this.Grid.ClearSorting();
        }
    }

}
``` 

The following GIF shows the sorting cleared on clicking the custom column menu item in Grid
-->

<!-- Customize menu items for particular columns

Sometimes, you may need to hide an item from column menu for particular columns alone. For this case, you need to set the [`Hide`] property of the [`ColumnMenuOpenEventArgs`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ColumnMenuOpenEventArgs.html#Syncfusion_Blazor_Grids_ColumnMenuOpenEventArgs__ctor) as true in the [`ColumnMenuOpen`] event.

In the following sample code, Filter item is hidden in column menu for the OrderID column.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315" AllowSorting="true" AllowFiltering="true" AllowGrouping="true"  ShowColumnMenu="true" AllowPaging="true">
    <GridEvents ColumnMenuOpen="OnMenuOpen" TValue="Order"></GridEvents>
    <GridFilterSettings Type=FilterType.Menu></GridFilterSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150" TextAlign="TextAlign.Center" ShowColumnMenu="false"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Center" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Center" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }

    public void OnMenuOpen(MenuEventArgs args)
    {
        foreach (ColumnMenuItemModel Item in args.Items) {
            if (Item.Text == "Filter" && args.Column.Field == "OrderID") {
                Item.Hide = true;
            } else {
                Item.Hide = false;
            }
        }
    }
}
``` 

The following GIF shows the customized column menu item for particular column in Grid -->

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