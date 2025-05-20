---
layout: post
title: Header customization in Blazor DataGrid | Syncfusion
description: Learn here all about header in Syncfusion Blazor DataGrid and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Header in Syncfusion Blazor DataGrid

You can customize the appearance of the header elements in the Syncfusion Blazor DataGrid using CSS. Here are examples of how to customize the Grid header, header cell, and header cell div element.

## Customizing the Blazor DataGrid header

To customize the appearance of the Grid header root element, you can use the following CSS code:

```css

.e-grid .e-gridheader {
    border: 2px solid green;
}
```
In this example, the **.e-gridheader** class targets the Grid header root element. You can modify the `border` property to change the style of the header border. This customization allows you to override the thin line between the header and content of the Grid.

![Grid header](../images/style-and-appearance/grid-header.png)

## Customizing the Blazor DataGrid header cell

To customize the appearance of the Grid header cell elements, you can use the following CSS code:

```css

.e-grid .e-headercell {
    color: #ffffff;
    background-color: #1ea8bd;
}

```
In this example, the **.e-headercell** class targets the header cell elements. You can modify the `color` and `background-color` properties to change the text color and background of the header cells.

![Grid header cell](../images/style-and-appearance/grid-header-cell.png)

## Customizing the Blazor DataGrid header cell div element

To customize the appearance of the Grid header cell div element, you can use the following CSS code:

```css

.e-grid .e-headercelldiv {
    font-size: 15px;
    font-weight: bold;
    color: darkblue;
}
```
In this example, the **.e-headercelldiv** class targets the div element within the header cell. You can modify the `font-size`, `font-weight`, `color` properties to change the font size, font-weight and color of the header text content.

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

## Hide DataGrid header in Blazor DataGrid

In the Syncfusion Blazor DataGrid, the header row (which displays the column titles) can be hidden using simple CSS styles.

Apply the following CSS to your application. This will completely hide the column headers of every Grid on the page:

```html
<style>
    .e-grid .e-gridheader .e-columnheader{
        display: none;
    }
</style>
```

N> If you want to hide the header for particular Grid, then you can apply the above styles to that Grid using the ID (#Grid.e-grid .e-gridheader .e-columnheader) property value.