---
layout: post
title: Grouping customization in Blazor DataGrid | Syncfusion
description: Learn here all about grouping customization in Syncfusion Blazor DataGrid component and more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Grouping in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid

You can customize the appearance of grouping elements in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid using CSS. Here are examples of how to customize the group header, group expand/collapse icons, group caption row, and grouping indent cell.

## Customizing the group header

To customize the appearance of the group header element, you can use the following CSS code:

```css
.e-grid .e-groupdroparea {
    background-color: #132f49;
}

```
In this example, the **.e-groupdroparea** class targets the group header element. You can modify the `background-color` property to change the color of the group header.

![Group header](../images/style-and-appearance/group-header.png)

## Customizing the group expand or collapse icons

To customize the appearance of the group expand/collapse icons in the Grid, you can use the following CSS code:

```css
.e-grid .e-icon-gdownarrow::before{
    content:'\e7c9'
    }
.e-grid .e-icon-grightarrow::before{
    content:'\e80f'
}
```

In this example, the **.e-icon-gdownarrow** and **.e-icon-grightarrow** classes target the expand and collapse icons, respectively. You can modify the `content` property to change the icon displayed. You can use the available [Syncfusion<sup style="font-size:70%">&reg;</sup> icons](https://blazor.syncfusion.com/documentation/appearance/icons) based on your theme.

![Group expand or collapse icons](../images/style-and-appearance/group-expand-or-collapse-icons.png)

## Customizing the group caption row

To customize the appearance of the group caption row and the icons indicating record expansion or collapse, you can use the following CSS code:

```css
.e-grid .e-groupcaption {
    background-color: #deecf9;
}

.e-grid .e-recordplusexpand,
.e-grid .e-recordpluscollapse {
    background-color: #deecf9;
}
```

In this example, the **.e-groupcaption** class targets the group caption row element, and the **.e-recordplusexpand** and **.e-recordpluscollapse** classes target the icons indicating record expansion or collapse. You can modify the `background-color` property to change the color of these elements.

![Group caption row](../images/style-and-appearance/group-caption-row.png)

## Customizing the grouping indent cell

To customize the appearance of the grouping indent cell element, you can use the following CSS code:

```css
.e-grid .e-indentcell {
    background-color: #deecf9;
}
```

In this example, the **.e-indentcell** class targets the grouping indent cell element. You can modify the `background-color` property to change the color of the indent cell.

![Grouping indent cell](../images/style-and-appearance/indent-cell.png)

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" Height="315" AllowGrouping="true" AllowPaging="true">
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridGroupSettings Columns="@Initial"></GridGroupSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
   .e-grid .e-groupdroparea {
        background-color: #132f49;
    }
    .e-grid .e-icon-gdownarrow::before{
        content:'\e7c9'
    }
    .e-grid .e-icon-grightarrow::before{
        content:'\e80f'
    }
    .e-grid .e-groupcaption {
        background-color: #deecf9;
    }
    .e-grid .e-recordplusexpand,
    .e-grid .e-recordpluscollapse {
        background-color: #deecf9;
    }
    .e-grid .e-indentcell {
        background-color: #deecf9;
    }
</style>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }
    public string[] Initial = (new string[] { "CustomerID" });

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

    public OrderData(int orderID, string customerID, string shipCity, string shipName)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.ShipCity = shipCity;
        this.ShipName = shipName;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevalier"));
            Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
            Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
            Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
            Orders.Add(new OrderData(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Orders.Add(new OrderData(10254, "CHOPS", "Bern", "Chop-suey Chinese"));
            Orders.Add(new OrderData(10255, "RICSU", "Genève", "Richter Supermarkt"));
            Orders.Add(new OrderData(10256, "WELLI", "Resende", "Wellington Import Export"));
            Orders.Add(new OrderData(10257, "HILAA", "San Cristóbal", "Hila Alimentos"));
            Orders.Add(new OrderData(10258, "ERNSH", "Graz", "Ernst Handel"));
            Orders.Add(new OrderData(10259, "CENTC", "México D.F.", "Centro comercial"));
            Orders.Add(new OrderData(10260, "OTTIK", "Köln", "Ottilies Käseladen"));
            Orders.Add(new OrderData(10261, "QUEDE", "Rio de Janeiro", "Que delícia"));
            Orders.Add(new OrderData(10262, "RATTC", "Albuquerque", "Rattlesnake Canyon Grocery"));
        }

        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDBeXyjLAcEEhVUs?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}