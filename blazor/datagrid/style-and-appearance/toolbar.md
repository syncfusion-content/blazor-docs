---
layout: post
title: Toolbar customization in Syncfusion Blazor DataGrid
description: Learn how to customize the Syncfusion Blazor DataGrid toolbar using CSS—style the container, buttons, and apply CSS isolation tips.
platform: Blazor
control: DataGrid
documentation: ug
---

# Toolbar customization in Syncfusion Blazor DataGrid

Customize the appearance of the toolbar in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid using CSS. The following examples demonstrate styling the toolbar root element and toolbar buttons. When using CSS isolation (.razor.css), target Grid internals with the ::deep combinator or wrap the Grid with a custom class to increase selector specificity if theme styles override custom CSS. For functional configuration of toolbar items, see the DataGrid toolbar documentation.

## Customizing the toolbar root element

To customize the appearance of the toolbar root element, use the following CSS:

```css
.e-grid .e-toolbar-items {
    background-color: #deecf9;
}
```

In this example, the `.e-toolbar-items` selector targets the toolbar container. Modify the `background-color` value to change the toolbar background.

![Grid toolbar root element](../images/style-and-appearance/grid-toolbar-root-element.png)

## Customizing the toolbar button element

To customize the appearance of toolbar buttons, use the following CSS:

```css
.e-grid .e-toolbar .e-btn {
    background-color: #deecf9;
}
```

In this example, the `.e-toolbar .e-btn` selector targets toolbar button elements. Modify the `background-color` value to change the button background. Depending on the theme, hover, active, and focus states may require additional selectors for complete styling.

![Grid toolbar button element](../images/style-and-appearance/grid-toolbar-button-element.png)


{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" Height="315" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update" })" AllowPaging="true">
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
   .e-grid .e-toolbar-items {
        background-color: #deecf9;
    }
   .e-grid .e-toolbar .e-btn {
        background-color: #c8ddf1;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZLIZeXhqQdjJsjY?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}