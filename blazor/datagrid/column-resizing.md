---
layout: post
title: Column Resizing in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about column resizing in the Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Column Resizing in Blazor DataGrid component

Grid component provides an intuitive user interface for resizing columns to fit their content. This feature allows users to easily adjust the width of the columns to improve readability and aesthetics of the data presented. To enable column resizing, set the [AllowResizing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowResizing) property of the grid to true.

Once column resizing is enabled, columns width can be resized by clicking and dragging at the right edge of the column header. While dragging the column, the width of the respective column will be resized immediately.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" AllowResizing="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipAddress) HeaderText="Ship Address" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
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
        public OrderData(int? OrderID,string CustomerID, string ShipCity, string ShipName,string ShipCountry,string ShipAddress,double Freight)
        {
           this.OrderID = OrderID;
           this.CustomerID = CustomerID;
           this.ShipCity = ShipCity;   
           this.ShipName = ShipName;
           this.ShipCountry = ShipCountry;
           this.ShipAddress = ShipAddress;
           this.Freight = Freight;            
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcool", "France", "59 rue de l Abbaye",33.33));
                    Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten", "Germany", "Luisenstr. 48",89.76));
                    Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes", "Brazil", "Rua do Paço, 67",78.67));
                    Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock", "Belgium", "2, rue du Commerce",55.65));
                    Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices", "Venezuela", "Boulevard Tirou, 255",11.09));
                    Orders.Add(new OrderData(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes", "Venezuela", "Boulevard Tirou, 255",98.98));
                    Orders.Add(new OrderData(10254, "VINET", "Reims", "Vins et alcool", "Belgium", "Rua do Paço, 67",78.75));
                    Orders.Add(new OrderData(10255,"TOMSP", "Münster", "Toms Spezialitäten", "Germany", "Luisenstr. 48",44.07));
                    Orders.Add(new OrderData(10256, "TOMSP", "Münster", "Toms Spezialitäten", "France", "59 rue de l Abbaye",67.74));
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipName { get; set; }
        public string ShipCountry { get; set; }
        public string ShipAddress { get; set; }
        public double Freight { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZhKsCXsTYapJQWa?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> You can disable resizing for a particular column by setting the [AllowResizing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowResizing) property of **GridColumn** component to false.
<br/> In RTL mode, you can click and drag the left edge of the header cell to resize the column.
<br/>The width property of the column can be set initially to define the default width of the column. However, when column resizing is enabled, you can override the default width by manually resizing the columns.

## Restrict the resizing based on minimum and maximum width

The Grid component allows you to restrict the column width resizing between a minimum and maximum width. This can be useful when you want to ensure that your grid’s columns stay within a certain range of sizes.

To enable this feature, you can define the [MinWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_MinWidth) and [MaxWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_MaxWidth) properties of the columns directive for the respective column.

In the below code, **OrderID**, **Ship Name** and **Ship Country** columns are defined with minimum and maximum width. The **OrderID** column is set to have a minimum width of 100 pixels and a maximum width of 250 pixels. Similarly, the **ShipName** column is set to have a minimum width of 150 pixels and a maximum width of 300 pixels. The **ShipCountry** column is set to have a minimum width of 120 pixels and a maximum width of 280 pixels.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" AllowResizing="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" MinWidth="100" MaxWidth="250" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" MinWidth="150" MaxWidth="300" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCountry) HeaderText="Ship Country" MinWidth="120" MaxWidth="280" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipAddress) HeaderText="Ship Address" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
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
        public OrderData(int? OrderID,string CustomerID, string ShipCity, string ShipName,string ShipCountry,string ShipAddress,double Freight)
        {
           this.OrderID = OrderID;
           this.CustomerID = CustomerID;
           this.ShipCity = ShipCity;   
           this.ShipName = ShipName;
           this.ShipCountry = ShipCountry;
           this.ShipAddress = ShipAddress;
           this.Freight = Freight;            
        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcool", "France", "59 rue de l Abbaye",33.33));
                    Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten", "Germany", "Luisenstr. 48",89.76));
                    Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes", "Brazil", "Rua do Paço, 67",78.67));
                    Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock", "Belgium", "2, rue du Commerce",55.65));
                    Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices", "Venezuela", "Boulevard Tirou, 255",11.09));
                    Orders.Add(new OrderData(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes", "Venezuela", "Boulevard Tirou, 255",98.98));
                    Orders.Add(new OrderData(10254, "VINET", "Reims", "Vins et alcool", "Belgium", "Rua do Paço, 67",78.75));
                    Orders.Add(new OrderData(10255,"TOMSP", "Münster", "Toms Spezialitäten", "Germany", "Luisenstr. 48",44.07));
                    Orders.Add(new OrderData(10256, "TOMSP", "Münster", "Toms Spezialitäten", "France", "59 rue de l Abbaye",67.74));
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipName { get; set; }
        public string ShipCountry { get; set; }
        public string ShipAddress { get; set; }
        public double Freight { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/htBqWiNMoNGwHpfz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

>  The [MinWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_MinWidth) and [MaxWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_MaxWidth)     properties will be considered only when the user resizes the column. When resizing the window, these properties will not be considered. This is because columns cannot be re-rendered when resizing the window.
<br/>  When setting the MinWidth and MaxWidth properties, ensure that the values are appropriate for your data and layout requirements.
<br/> The specified MinWidth and MaxWidth values take precedence over any user-initiated resizing attempts that fall outside the defined range.

## Prevent resizing for particular column

The Grid component provides the ability to prevent resizing for a particular column. This can be useful if you want to maintain a consistent column width or prevent users from changing the width of a column.

You can disable resizing for a particular column by setting the [AllowResizing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowResizing) property of the column to false. The following example demonstrates, how to disabled resize for Customer ID column.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" AllowResizing="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" MinWidth="100" MaxWidth="250" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" AllowResizing="false" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
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
        public OrderData(int? OrderID,string CustomerID, string ShipCity,double Freight)
        {
           this.OrderID = OrderID;
           this.CustomerID = CustomerID;
           this.ShipCity = ShipCity;   
           this.Freight = Freight;            
        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", "Reims",33.33));
                    Orders.Add(new OrderData(10249, "TOMSP", "Münster",89.76));
                    Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro",78.67));
                    Orders.Add(new OrderData(10251, "VICTE", "Lyon",55.65));
                    Orders.Add(new OrderData(10252, "SUPRD", "Charleroi",11.09));
                    Orders.Add(new OrderData(10253, "HANAR", "Rio de Janeiro",98.98));
                    Orders.Add(new OrderData(10254, "VINET", "Reims",78.75));
                    Orders.Add(new OrderData(10255,"TOMSP", "Münster",44.07));
                    Orders.Add(new OrderData(10256, "TOMSP", "Münster",67.74));
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public double Freight { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjhqsiDQVjBIavlN?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Resize stacked header column

Grid component allows to resize stacked columns by clicking and dragging the right edge of the stacked column header. During the resizing action, the width of the child columns is resized at the same time. You can disable resize for any particular stacked column by setting [AllowResizing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowResizing) as false to its columns.

In this below code, we have disabled resize for ShipCountry column.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid DataSource="@Orders" AllowResizing="true"  Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn HeaderText=" Order Details">
            <GridColumns>
                <GridColumn Field=@nameof(OrderData.OrderDate) Width="130" HeaderText="Order Date" Format="d" TextAlign="TextAlign.Right" AllowResizing="false" MinWidth="10"></GridColumn>
                <GridColumn Field=@nameof(OrderData.Freight) Width="135" HeaderText="Freight($)" Format="C2" TextAlign="TextAlign.Right" MinWidth="10" AllowResizing=false></GridColumn>
            </GridColumns>
        </GridColumn>
        <GridColumn HeaderText=" Ship Details">
            <GridColumns>
                <GridColumn Field=@nameof(OrderData.ShipCity) Width="130" HeaderText="Ship City" TextAlign="TextAlign.Right" AllowResizing="false" MinWidth="10"></GridColumn>
                <GridColumn Field=@nameof(OrderData.ShipCountry) Width="135" HeaderText="Ship Country" TextAlign="TextAlign.Right" MinWidth="10" AllowResizing=false></GridColumn>
            </GridColumns>
        </GridColumn>
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
        public OrderData(int? OrderID, string ShipCity, string ShipCountry,double Freight,DateTime OrderDate)
        {
           this.OrderID = OrderID;
           this.ShipCity = ShipCity;   
           this.ShipCountry = ShipCountry;
           this.Freight = Freight;
           this.OrderDate = OrderDate;            
        }
        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "Reims", "France", 33.33,new DateTime(1996,07,07)));
                    Orders.Add(new OrderData(10249, "Münster",  "Germany", 89.76, new DateTime(1996, 07, 12)));
                    Orders.Add(new OrderData(10250, "Rio de Janeiro", "Brazil", 78.67, new DateTime(1996, 07, 13)));
                    Orders.Add(new OrderData(10251, "Lyon", "Belgium",55.65, new DateTime(1996, 07, 14)));
                    Orders.Add(new OrderData(10252, "Charleroi", "Venezuela", 11.09, new DateTime(1996, 07, 15)));
                    Orders.Add(new OrderData(10253, "Rio de Janeiro", "Venezuela", 98.98, new DateTime(1996, 07, 16)));
                    Orders.Add(new OrderData(10254, "Reims", "Belgium", 78.75, new DateTime(1996, 07, 17)));
                    Orders.Add(new OrderData(10255, "Münster", "Germany", 44.07, new DateTime(1996, 07, 18)));
                    Orders.Add(new OrderData(10256, "Münster", "France", 67.74, new DateTime(1996, 07, 19)));
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }
        public string ShipCity { get; set; }
        public string ShipCountry { get; set; }
        public double Freight { get; set; }
        public DateTime OrderDate { get; set; }
    }
{% endhighlight %}
{% endtabs %}

Resizing of stacked header is shown below

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNVqMsXsSATGJPmY?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Touch interaction

Grid component provides support for touch interactions to enable users to interact with the grid using their mobile devices. Users can resize columns in the grid by tapping and dragging the floating handler, and can also use the Column menu to autofit columns.

**Resizing Columns on Touch Devices**

To resize columns on a touch device:

1.Tap on the right edge of the header cell of the column that you want to resize.

2.A floating handler will appear over the right border of the column

3.Tap and drag the floating handler to resize the column to the desired width.

The following screenshot represents the column resizing in touch device.

![Blazor DataGrid column resizing in touch interaction.](./images/blazor-datagrid-column-resizing.jpg)

<!-- Resize events

During the resizing action the grid component triggers the below events,

1. [`ResizeStart`]  -  Triggers when a column resize starts.
2. [`Resizing`]     -  Triggers when a column is getting resized continuously.
3. [`ResizeStop`]   -  Triggers when a column resize stops.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowResizing="true" AllowPaging="true" Height ="315">
<GridEvents ResizeStart="OnResizeStart" Resizing="OnResizing" ResizeStop="OnResizeStop" TValue="Order"></GridEvents>
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

    public void OnResizeStart() {
        // Perform required operations here
    }

    public void OnResizing() {
        // Perform required operations here
    }

    public void OnResizeStop() {
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