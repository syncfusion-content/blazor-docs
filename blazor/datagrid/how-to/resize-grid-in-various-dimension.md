---
layout: post
title: Resize the Blazor DataGrid in various dimension | Syncfusion
description: Learn here all about resize the Grid in various dimension in Syncfusion Blazor DataGrid components and more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Resize the Blazor DataGrid in various dimension

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid offers a friendly way to resize the Grid, allowing you to adjust its width and height for improved data visualization.

To resize the Grid externally, you can use an external button to modify the width of the parent element that contains the Grid. This will effectively resize the Grid along with its parent container.

The following example demonstrates how to resize the Grid on external button click based on input:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<div style="display: flex;">
    <div style="padding: 5px">
        <label style="padding: 30px 17px 0 0">Enter the width:</label>
        <SfNumericTextBox @ref="WidthTextBox" Min="400" Max="650" Placeholder="400" Step="5" Width="120px" TValue="int"></SfNumericTextBox>
    </div>
    <div style="padding: 5px">
        <label style="padding: 30px 17px 0 0">Enter the height:</label>
        <SfNumericTextBox @ref="HeightTextBox" Min="200" Max="600" Placeholder="200" Step="5" Width="120px" TValue="int"></SfNumericTextBox>
    </div>
    <div style="padding: 5px">
        <SfButton CssClass="e-outline" Style="margin:28px 0 5px 5px" OnClick="ResizeGrid">Resize</SfButton>
    </div>
</div>

<div id="parent" style="@ParentStyle">
    <SfGrid @ref="Grid" DataSource="@Orders" Height="100%">
        <GridColumns>
            <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="90"></GridColumn>
            <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
            <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="100"></GridColumn>
            <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Width="80"></GridColumn>
        </GridColumns>
    </SfGrid>
</div>

@code {
    private SfGrid<OrderDetails> Grid;
    public List<OrderDetails> Orders { get; set; }
    private SfNumericTextBox<int> WidthTextBox;
    private SfNumericTextBox<int> HeightTextBox;

    private string ParentStyle;

    protected override void OnInitialized()
    {
         Orders = OrderDetails.GetAllRecords();
    }

    private void ResizeGrid()
    {
        var width = WidthTextBox?.Value ?? 400;
        var height = HeightTextBox?.Value ?? 200;
        ParentStyle = $"padding: 5px 5px; width: {width}px; height: {height}px;";
    }

}

{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();

    public OrderDetails(int orderId, string customerId, string shipCity, string shipName, double freight, DateTime orderDate, string shipCountry)
    {
        this.OrderID = orderId;
        this.CustomerID = customerId;
        this.ShipCity = shipCity;
        this.ShipName = shipName;
        this.Freight = freight;
        this.OrderDate = orderDate;
        this.ShipCountry = shipCountry;
    }

    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", "Reims", "Vins et alcools Chevalier", 32.38, new DateTime(2024, 1, 5), "France"));
            order.Add(new OrderDetails(10249, "TOMSP", "Münster", "Toms Spezialitäten", 11.61, new DateTime(2024, 1, 7), "Germany"));
            order.Add(new OrderDetails(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes", 65.83, new DateTime(2024, 1, 10), "Brazil"));
            order.Add(new OrderDetails(10251, "VICTE", "Lyon", "Victuailles en stock", 41.34, new DateTime(2024, 1, 12), "France"));
            order.Add(new OrderDetails(10252, "SUPRD", "Charleroi", "Suprêmes délices", 51.30, new DateTime(2024, 1, 14), "Belgium"));
            order.Add(new OrderDetails(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes", 58.17, new DateTime(2024, 1, 16), "Brazil"));
            order.Add(new OrderDetails(10254, "CHOPS", "Bern", "Chop-suey Chinese", 22.98, new DateTime(2024, 1, 18), "Switzerland"));
            order.Add(new OrderDetails(10255, "RICSU", "Genève", "Richter Supermarkt", 148.33, new DateTime(2024, 1, 20), "Switzerland"));
            order.Add(new OrderDetails(10256, "WELLI", "Resende", "Wellington Importadora", 13.97, new DateTime(2024, 1, 22), "Brazil"));
            order.Add(new OrderDetails(10257, "HILAA", "San Cristóbal", "HILARION-Abastos", 81.91, new DateTime(2024, 1, 24), "Venezuela"));
        }
        return order;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
    public double Freight { get; set; }
    public DateTime OrderDate { get; set; }
    public string ShipCountry { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNVeDJrpLMwucNtH?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}