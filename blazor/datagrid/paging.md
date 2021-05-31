---
layout: post
title: Syncfusion
description: Checkout
platform: Blazor
component: DataGrid
documentation: ug
---

# Paging

[Paging](https://www.syncfusion.com/blazor-components/blazor-datagrid/paging) provides an option to display DataGrid data in page segments. To enable paging, set the [`AllowPaging`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowPaging) to true. When paging is enabled, pager component renders at the bottom of the datagrid.
Paging options can be configured through the [`GridPageSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PageSettings) component.

In the below sample, [`PageSize`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageSize) is calculated based on the datagrid height by using the [`OnLoad`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html) event.

{% tabs %}

{% highlight c# %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="DefaultGrid" DataSource="@Orders" AllowPaging="true" Height="200">
    <GridEvents OnLoad="Load" TValue="Order"></GridEvents>
    <GridPageSettings PageCount="2"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Visible="false" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;
    public int GridHeight;
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

    public void Load(object args)
    {
        var RowHeight = 37; //height of the each row
        Int32.TryParse(this.DefaultGrid.Height, out GridHeight); //datagrid height
        var PageSize = (this.DefaultGrid.PageSettings as GridPageSettings).PageSize; //initial page size
        decimal PageResize = ((GridHeight) - (PageSize * RowHeight)) / RowHeight; //new page size is obtained here
        #pragma warning disable BL0005
        (this.DefaultGrid.PageSettings as GridPageSettings).PageSize = PageSize + (int)Math.Round(PageResize);
        #pragma warning restore BL0005
    }
}


{% endhighlight %}

{% endtabs %}

> You can achieve better performance by using datagrid paging to fetch only a pre-defined number of records from the data source.

## Pager with page size dropdown

The pager dropdown allows you to change the number of records in the DataGrid dynamically. It can be enabled by defining the [`PageSizes`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridPageSettings.html#Syncfusion_Blazor_Grids_GridPageSettings_PageSizes) property of **GridPageSettings** as true.

> By default, dropdown list will show values as **new int[]{ 5, 10, 12, 20 }**. You can customize the dropdown values using the **PageSizes** property itself.

{% tabs %}

{% highlight c# %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true">
    <GridPageSettings PageSizes="true"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
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

    public class Order {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}

{% endhighlight %}

{% endtabs %}

> You can refer to our [Blazor Grid Paging](https://www.syncfusion.com/blazor-components/blazor-datagrid/paging) Feature tour page to know about paging and  its feature representations.
> You can refer to our [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap4) to understand how to present and manipulate data.
