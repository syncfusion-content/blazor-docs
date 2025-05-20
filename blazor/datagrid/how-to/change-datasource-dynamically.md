---
layout: post
title: Change datasource dynamically in Syncfusion Blazor DataGrid
description: Learn here all about change datasource dynamically in Syncfusion Blazor DataGrid and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Change Datasource Dynamically in Blazor DataGrid

The Syncfusion Blazor DataGrid allows to change the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) of the Grid  dynamically through an external button. This feature is useful to display different sets of data based on specific actions.

To implement this:

* Bind the Grid's `DataSource` property to a public list (e.g., Orders).

* Create a method that replaces this list with a new set of data.

* Trigger this method through a button or any other user interaction.

* The Grid automatically detects the data change and re-renders with the new content.

The following example demonstrates how to change the `DataSource` of the Grid dynamically:


{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfButton OnClick="ChangeDataSource">Change Data Source</SfButton>

<SfGrid @ref="grid" DataSource="@Orders" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="Syncfusion.Blazor.Grids.ColumnType.Date" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
  </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> grid;
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    private void ChangeDataSource()
    {
        // Replace the DataSource with a new list of records.
        Orders = OrderData.GetNewRecords();
    }
}

{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData() { }

    public OrderData(int orderID, string customerID, double freight, DateTime? orderDate)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.Freight = freight;
        this.OrderDate = orderDate;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", 32.38, new DateTime(1996, 7, 4)));
            Orders.Add(new OrderData(10249, "TOMSP", 11.61, new DateTime(1996, 7, 5)));
            Orders.Add(new OrderData(10250, "HANAR", 65.83, new DateTime(1996, 7, 6)));
            Orders.Add(new OrderData(10251, "VINET", 41.34, new DateTime(1996, 7, 7)));
            Orders.Add(new OrderData(10252, "SUPRD", 151.30, new DateTime(1996, 7, 8)));
            Orders.Add(new OrderData(10253, "HANAR", 58.17, new DateTime(1996, 7, 9)));
            Orders.Add(new OrderData(10254, "CHOPS", 22.98, new DateTime(1996, 7, 10))); 
        }
        return Orders;
    }

    public static List<OrderData> GetNewRecords()
    {
        return new List<OrderData>
        {
            new OrderData(20001, "ALFKI", 21.50, DateTime.Now.AddDays(-1)),
            new OrderData(20002, "ANATR", 42.75, DateTime.Now.AddDays(-2)),
            new OrderData(20003, "ANTON", 17.00, DateTime.Now.AddDays(-3)),
            new OrderData(20004, "BERGS", 65.20, DateTime.Now.AddDays(-4))
        };
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public DateTime? OrderDate { get; set; }
}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDhIXeCHJywphWgL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Changing Datasource Dynamically in Blazor DataGrid](../images/blazor-datagrid-dynamic-datasource.gif)
