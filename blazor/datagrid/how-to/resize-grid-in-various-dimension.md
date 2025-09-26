---
layout: post
title: Resize the Blazor DataGrid in various dimensions | Syncfusion
description: Learn how to resize the Blazor DataGrid by adjusting its parent container using NumericTextBox inputs and a button.
platform: Blazor
control: DataGrid
documentation: ug
---

# Resize the Blazor DataGrid in various dimensions

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid fills its parent container. Therefore, changing the parent’s dimensions adjusts the Grid size automatically. This example shows how to resize the Grid externally using inputs and a button to modify the parent container’s width and height.

> - When using `Height="100%"` for the Grid, ensure the parent container has an explicit height (pixels or a resolved flex height).
> - Setting `Width="100%"` on the Grid ensures it follows the parent width exactly.

The following example demonstrates resizing the Grid on an external button click based on the provided inputs:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<div style="display:flex; gap: 8px;">
    <div style="padding: 5px">
        <label for="widthBox" style="padding: 30px 17px 0 0">Enter the width (px):</label>
        <SfNumericTextBox id="widthBox" @ref="WidthTextBox" Min="400" Max="650" Placeholder="400" Step="5" Width="120px" TValue="int"></SfNumericTextBox>
    </div>
    <div style="padding: 5px">
        <label for="heightBox" style="padding: 30px 17px 0 0">Enter the height (px):</label>
        <SfNumericTextBox id="heightBox" @ref="HeightTextBox" Min="200" Max="600" Placeholder="200" Step="5" Width="120px" TValue="int"></SfNumericTextBox>
    </div>
    <div style="padding: 5px">
        <SfButton CssClass="e-outline" style="margin:28px 0 5px 5px" OnClick="ResizeGrid">Resize</SfButton>
    </div>
</div>

<div id="parent" style="@ParentStyle">
    <SfGrid @ref="Grid" DataSource="@Orders" Height="100%" Width="100%">
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

    private string ParentStyle = "padding: 5px; width: 400px; height: 200px;";

    protected override void OnInitialized()
    {
         Orders = OrderDetails.GetAllRecords();
    }

    private void ResizeGrid()
    {
        var width = WidthTextBox?.Value ?? 400;
        var height = HeightTextBox?.Value ?? 200;
        ParentStyle = $"padding: 5px; width: {width}px; height: {height}px;";
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
