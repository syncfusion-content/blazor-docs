---
layout: post
title: How to DataGrid customization in Blazor DataGrid component - Syncfusion
description: Checkout and learn about DataGrid customization in Blazor DataGrid component of Syncfusion, and more details
platform: Blazor
component: DataGrid
documentation: ug
---

# DataGrid customization

It is possible to customize the default styles of the DataGrid component. This can be achieved by adding class dynamically to the columns using the `AddClass` method of the [`QueryCellInfo`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DashArray) event. Then the required styles are added to this class.

This is demonstrated in the below sample code,

{% tabs %}

{% highlight C# %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true">
    <GridEvents QueryCellInfo="QueryCellInfoHandler" TValue="Order"></GridEvents>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type=ColumnType.Date TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    .e-grid .e-gridcontent .e-rowcell.above-40 {
        color: green;
    }

    .e-grid .e-gridcontent .e-rowcell.above-20 {
        color: blue;
    }

    .e-grid .e-gridcontent .e-rowcell.below-20 {
        color: red;
    }
</style>

@code{
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 12 * x,
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

    public void QueryCellInfoHandler(QueryCellInfoEventArgs<Order> args) {
        if (args.Data.Freight > 40)
        {
            args.Cell.AddClass(new string[] { "above-40" });
        }
        else if (args.Data.Freight > 20 && args.Data.Freight <= 40)
        {
            args.Cell.AddClass(new string[] { "above-20" });
        }
        else
        {
            args.Cell.AddClass(new string[] { "below-20" });
        }
    }
}

{% endhighlight %}

{% endtabs  %}

<!-- You can also apply style directly to the DataGrid using the `SetAttribute` method in the [`QueryCellInfo`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DashArray) event. But, this will override the default styles of the grid.

This is demonstrated in the below sample code,

{% tabs %}

{% highlight C# %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true">
    <GridEvents QueryCellInfo="QueryCellInfoHandler" TValue="Order"></GridEvents>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type=ColumnType.Date TextAlign="TextAlign.Right" Width="120"></GridColumn>
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
            Freight = 12 * x,
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

    public void QueryCellInfoHandler(QueryCellInfoEventArgs<Order> args) {
        if (args.Data.Freight > 40)
        {
            args.Cell.SetAttribute("style", "color:green; text-align: right");
        }
        else if (args.Data.Freight > 20 && args.Data.Freight <= 40)
        {
            args.Cell.SetAttribute("style", "color:blue; text-align: right");
        }
        else
        {
            args.Cell.SetAttribute("style", "color:red; text-align: right");
        }
    }
}

{% endhighlight %}

{% endtabs  %} -->

The following image represents customized datagrid columns,
![`Grid Customization`](../images/grid-customization.png)