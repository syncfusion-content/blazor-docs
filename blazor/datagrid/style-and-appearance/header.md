---
layout: post
title: Header customization in Blazor DataGrid | Syncfusion
description: Learn how to customize Syncfusion Blazor DataGrid header with CSS—style header bar, cells, text, or hide it, with CSS isolation tips and cautions.
platform: Blazor
control: DataGrid
documentation: ug
---

# Header customization in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid

Customize the appearance of header elements in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid using CSS. The examples below show how to style the Grid header, header cells, and the header text container. Note: when using CSS isolation (.razor.css), target Grid internals with the ::deep combinator or apply a wrapper class to increase selector specificity if theme styles override custom CSS.

## Customizing the Blazor DataGrid header

To customize the appearance of the Grid header root element, use the following CSS:

```css

.e-grid .e-gridheader {
    border: 2px solid green;
}
```
In this example, the `.e-gridheader` selector targets the header container. Adjust properties such as border, padding, or background to match the application’s theme. This also allows overriding the default thin divider between the header and content.

![Grid header](../images/style-and-appearance/grid-header.png)

## Customizing the Blazor DataGrid header cell

To style the Grid header cell elements, use the following CSS:

```css

.e-grid .e-headercell {
    color: #ffffff;
    background-color: #1ea8bd;
}

```
Here, the `.e-headercell` selector targets individual header cells. Modify color and `background-color` (and optionally font, border, or alignment) to personalize header appearance.

![Grid header cell](../images/style-and-appearance/grid-header-cell.png)

## Customizing the Blazor DataGrid header cell div element

To style the header cell text container, use the following CSS:

```css

.e-grid .e-headercelldiv {
    font-size: 15px;
    font-weight: bold;
    color: darkblue;
}
```
The `.e-headercelldiv` selector targets the inner text container within each header cell. Adjust font-size, font-weight, and color to improve readability and emphasis.

![Grid header cell div element](../images/style-and-appearance/grid-header-cell-div-element.png)

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" Height="315" AllowPaging="true">
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    .e-grid .e-headercelldiv {
        font-size: 15px;
        font-weight: bold;
        color: darkblue;
    }
    .e-grid .e-headercell {
        color: #ffffff;
        background-color: #1ea8bd;
    }
    .e-grid .e-gridheader {
        border: 2px solid green;
    }
</style>

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

    public OrderData(int orderID, string customerID, double freight, DateTime orderDate)
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
            Orders.Add(new OrderData(10248, "VINET", 32.38, new DateTime(2024, 1, 10)));
            Orders.Add(new OrderData(10249, "TOMSP", 11.61, new DateTime(2024, 1, 11)));
            Orders.Add(new OrderData(10250, "HANAR", 65.83, new DateTime(2024, 1, 12)));
            Orders.Add(new OrderData(10251, "VICTE", 41.34, new DateTime(2024, 1, 13)));
            Orders.Add(new OrderData(10252, "SUPRD", 51.3, new DateTime(2024, 1, 14)));
            Orders.Add(new OrderData(10253, "HANAR", 58.17, new DateTime(2024, 1, 15)));
            Orders.Add(new OrderData(10254, "CHOPS", 22.98, new DateTime(2024, 1, 16)));
            Orders.Add(new OrderData(10255, "RICSU", 148.33, new DateTime(2024, 1, 17)));
            Orders.Add(new OrderData(10256, "WELLI", 13.97, new DateTime(2024, 1, 18)));
            Orders.Add(new OrderData(10257, "HILAA", 81.91, new DateTime(2024, 1, 19)));
        }

        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public DateTime OrderDate { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZBoNSXVUGazWuEg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Hide Blazor DataGrid header

In the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, the header row (column titles) can be hidden using CSS. Note: hiding headers also hides sort/filter cues and affects accessibility; consider alternative labels or tooltips if headers are hidden.

Apply the following CSS to hide the column headers of every Grid on the page:

```css
<style>
    .e-grid .e-gridheader .e-columnheader{
        display: none;
    }
</style>
```
{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" Format="d" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    .e-grid .e-gridheader .e-columnheader{
        display: none;
    }
</style>

@code {
    private SfGrid<OrderDetails> Grid;
    public List<OrderDetails> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderDetails.GetAllRecords();
    }
}

{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> Orders = new List<OrderDetails>();

    public OrderDetails(int orderID, string customerID, double freight, DateTime orderDate)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.Freight = freight;
        this.OrderDate = orderDate;
    }

    public static List<OrderDetails> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderDetails(10248, "VINET", 32.38, new DateTime(2024, 1, 10)));
            Orders.Add(new OrderDetails(10249, "TOMSP", 11.61, new DateTime(2024, 1, 11)));
            Orders.Add(new OrderDetails(10250, "HANAR", 65.83, new DateTime(2024, 1, 12)));
            Orders.Add(new OrderDetails(10251, "VICTE", 41.34, new DateTime(2024, 1, 13)));
            Orders.Add(new OrderDetails(10252, "SUPRD", 51.3, new DateTime(2024, 1, 14)));
            Orders.Add(new OrderDetails(10253, "HANAR", 58.17, new DateTime(2024, 1, 15)));
            Orders.Add(new OrderDetails(10254, "CHOPS", 22.98, new DateTime(2024, 1, 16)));
            Orders.Add(new OrderDetails(10255, "RICSU", 148.33, new DateTime(2024, 1, 17)));
            Orders.Add(new OrderDetails(10256, "WELLI", 13.97, new DateTime(2024, 1, 18)));
            Orders.Add(new OrderDetails(10257, "HILAA", 81.91, new DateTime(2024, 1, 19)));
        }

        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public DateTime OrderDate { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZVoDohZJpGSPqod?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> To hide the header for a particular Grid only, scope the selector using the Grid’s ID (for example, `#Grid.e-grid .e-gridheader .e-columnheader { display: none; }`).