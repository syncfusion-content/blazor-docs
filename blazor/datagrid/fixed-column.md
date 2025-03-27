---
layout: post
title: Fixed Column in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about fixed column in the Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Fixed Column in Blazor DataGrid component

The Blazor DataGrid component allows you to fix specific columns, ensuring that they cannot be reordered or grouped in the UI. This feature is useful when you want to maintain certain columns in a fixed position while allowing modifications to other columns.

You can fix multiple columns at once, and they will appear in the same order as they are defined in the column collection.

To enable fixed columns in the DataGrid, set the [FixedColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_FixedColumn) property to true for the respective columns.

The following example demonstrates how to fix the **OrderID** and **OrderDate** columns in a Blazor DataGrid using the `FixedColumn` property. These columns cannot be moved or grouped.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" AllowPaging="true" AllowGrouping="true" AllowReordering="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" FixedColumn="true" TextAlign="TextAlign.Right" IsPrimaryKey="true" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" FixedColumn="true" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) Format="C2" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
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
    public OrderDetails() { }
    public OrderDetails(int OrderID, string CustomerId, double Freight, DateTime OrderDate, string ShipCity, string ShipCountry)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.Freight = Freight;
        this.OrderDate = OrderDate;
        this.ShipCity = ShipCity;
        this.ShipCountry = ShipCountry;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", 32.38, new DateTime(1996, 7, 4), "Reims", "Australia"));
            order.Add(new OrderDetails(10249, "TOMSP", 11.61, new DateTime(1996, 7, 5), "Münster", "Australia"));
            order.Add(new OrderDetails(10250, "HANAR", 65.83, new DateTime(1996, 7, 8), "Rio de Janeiro", "United States"));
            order.Add(new OrderDetails(10251, "VICTE", 41.34, new DateTime(1996, 7, 8), "Lyon", "Australia"));
            order.Add(new OrderDetails(10252, "SUPRD", 51.3, new DateTime(1996, 7, 9), "Charleroi", "United States"));
            order.Add(new OrderDetails(10253, "HANAR", 58.17, new DateTime(1996, 7, 10), "Rio de Janeiro", "United States"));
            order.Add(new OrderDetails(10254, "CHOPS", 22.98, new DateTime(1996, 7, 11), "Bern", "Switzerland"));
            order.Add(new OrderDetails(10255, "RICSU", 148.33, new DateTime(1996, 7, 12), "Genève", "Switzerland"));
            order.Add(new OrderDetails(10256, "WELLI", 13.97, new DateTime(1996, 7, 15), "Resende", "Brazil"));
            order.Add(new OrderDetails(10257, "HILAA", 81.91, new DateTime(1996, 7, 16), "San Cristóbal", "Venezuela"));
            order.Add(new OrderDetails(10258, "ERNSH", 140.51, new DateTime(1996, 7, 17), "Graz", "Austria"));
            order.Add(new OrderDetails(10259, "CENTC", 3.25, new DateTime(1996, 7, 18), "México D.F.", "Mexico"));
            order.Add(new OrderDetails(10260, "OTTIK", 55.09, new DateTime(1996, 7, 19), "Köln", "Germany"));
            order.Add(new OrderDetails(10261, "QUEDE", 3.05, new DateTime(1996, 7, 19), "Rio de Janeiro", "Brazil"));
            order.Add(new OrderDetails(10262, "RATTC", 48.29, new DateTime(1996, 7, 22), "Albuquerque", "USA"));
        }
        return order;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public DateTime OrderDate { get; set; }
    public string ShipCity { get; set; }
    public string ShipCountry { get; set; }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNLeNqrwKUBCSisL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}