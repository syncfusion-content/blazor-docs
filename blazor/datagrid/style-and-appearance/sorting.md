---
layout: post
title: Sorting Icon Styling in Blazor DataGrid | Syncfusion
description: Learn how to style sorting icons in Syncfusion Blazor DataGrid using CSS, with tips on theme icon codes and CSS isolation.
platform: Blazor
control: DataGrid
documentation: ug
---

# Sorting customization in Syncfusion Blazor DataGrid

Customize the appearance of sorting icons and multi-sorting badges in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid using CSS. Icon code points vary by theme; obtain the correct glyph values from Theme Studio, the theme’s icon font CSS, or by inspecting computed styles in the browser dev tools. When using CSS isolation (.razor.css), ensure styles reach internal Grid elements by using the :deep(...) or ::deep(...) combinator (depending on tooling), or scope selectors with a wrapper class or Grid ID to increase specificity if the theme overrides custom CSS. For production, prefer CSS isolation or a site-wide stylesheet over inline styles.

## Customizing the Blazor DataGrid sorting icon

To customize the sorting icon that appears in the Grid header when sorting is applied, use the following CSS:

```css
.e-grid .e-icon-ascending::before {
    content: '\e7a3'; /* Icon code for ascending order */
}
.e-grid .e-icon-descending::before {
    content: '\e7b6'; /* Icon code for descending order */
}
```
In this example, the `.e-icon-ascending::before` selector targets the icon for ascending order, and `.e-icon-descending::before` targets the icon for descending order. Update the `content` values to match the selected theme’s icon set. Ensure the icon font family used by the theme is available and applied; overriding `content` without the correct font family can result in missing glyphs. In CSS isolation, apply selectors via `:deep(.e-grid .e-icon-ascending::before)` and `:deep(.e-grid .e-icon-descending::before)` if required. Verify icon appearance in both left-to-right and right-to-left layouts.

![Grid sorting icon](../images/style-and-appearance/grid-sorting-icons.png)

## Customizing the Blazor DataGrid multi sorting icon

To customize the multi-sorting badge that appears in the Grid header when multiple columns are sorted, use the following CSS:

```css
.e-grid .e-sortnumber {
    background-color: #deecf9;
    font-family: cursive;
}
```

In this example, the `.e-sortnumber` selector customizes the background color and font family of the multi-sorting badge. Modify `background-color` and `font-family` to align with design requirements. Maintain sufficient color contrast and do not remove focus indicators to preserve accessibility. In isolated CSS, scope the rule with `:deep(.e-grid .e-sortnumber)` or use a wrapper/ID to limit the impact to a specific Grid instance.

![Grid multi sorting icon](../images/style-and-appearance/grid-multi-sorting-icon.png)

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" Height="315" AllowSorting="true" AllowPaging="true">
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    .e-grid .e-sortnumber {
        background-color: #deecf9;
        font-family: cursive;
    }
    .e-grid .e-icon-ascending::before {
        content: '\e7a3'; /* Icon code for ascending order */
    }
    .e-grid .e-icon-descending::before {
        content: '\e7b6'; /* Icon code for descending order */
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtBSXoDhUccZrPyZ?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5" %}