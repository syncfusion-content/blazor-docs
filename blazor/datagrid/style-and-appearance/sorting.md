---
layout: post
title: Sorting Icon Styling in Blazor DataGrid | Syncfusion
description: Learn how to style sorting icons in Syncfusion Blazor DataGrid using CSS, with tips on theme icon codes and CSS isolation.
platform: Blazor
control: DataGrid
documentation: ug
---

# Sorting customization in Syncfusion Blazor DataGrid

The appearance of sorting indicators in the Syncfusion Blazor DataGrid can be customized using CSS. Styling options are available for:

- **Ascending and descending sort icons:** Visual indicators that appear in column headers to show the current sort direction.
- **Multi-sorting order indicators:** Numeric badges that display the order of sorting when multiple columns are sorted.

N> - Enable sorting by setting the [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowSorting) property.  
- Ensure that the required theme stylesheet is referenced so that pager UI elements are displayed correctly.
- Icon glyph codes (such as `\e7a2`, `\e7a3`) vary depending on the theme and version. Confirm the correct glyph values by inspecting the icon font used in the current setup.
- When using CSS isolation (.razor.css), use the **::deep** selector to reach internal parts of the DataGrid, or place the grid inside a custom wrapper class and apply styles to that wrapper for better control.
- Class names may change slightly depending on the theme or version. Inspect the DOM to confirm selectors before applying styles.
- Maintain strong color contrast and clear focus indicators to support accessibility and improve readability.

## Customize sorting icons

The **.e-icon-ascending** and **.e-icon-descending** classes define the icons shown in the DataGrid header when a column is sorted in `ascending` or `descending` order. Use CSS to adjust its appearance:

```css
.e-grid .e-icon-ascending::before {
    content: '\e7a3'; /* Ascending icon code */
}

.e-grid .e-icon-descending::before {
    content: '\e7b6'; /* Descending icon code */
}
```

Adjust properties such as **content**, **color**, **font-size**, and **margin** to match the grid design. Ensure the correct icon font family is loaded to display the icons properly.

![Grid sorting icon](../images/style-and-appearance/grid-sorting-icons.png)

## Customize multi-sorting indicators

The **.e-sortnumber** class styles the numeric indicator shown when multiple columns are sorted. Apply CSS to change their appearance:

```css
.e-grid .e-sortnumber {
    background-color: #deecf9;
    font-family: cursive;
}
```

Modify properties such as **background-color**, **font-family**, **font-size**, and **border-radius** to align with the grid layout. Ensure accessibility by maintaining clear contrast and focus styles.

![Grid multi sorting icon](../images/style-and-appearance/grid-multi-sorting-icon.png)

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" Height="315" AllowSorting="true" AllowPaging="true">
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Width="100" TextAlign="TextAlign.Right"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    /* Multi-sorting order badge (e.g., 1, 2, 3) */
    .e-grid .e-sortnumber {
        background-color: #deecf9;
        color: #0b6aa2;
        font-family: cursive;
        border-radius: 10px;
        padding: 0 6px;
        min-width: 18px;
        text-align: center;
        line-height: 18px;
        height: 18px;
        display: inline-block;
        margin-left: 4px;
    }

    /* Override sorting icons (ensure correct icon font family) */
    .e-grid .e-icon-ascending::before,
    .e-grid .e-icon-descending::before {
        font-family: 'e-icons' !important; /* required for glyphs to render */
        font-weight: normal;
        speak: none;
    }
    .e-grid .e-icon-ascending::before {
        content: '\e7a3'; /* Ascending icon code (verify for your theme/version) */
    }
    .e-grid .e-icon-descending::before {
        content: '\e7b6'; /* Descending icon code (verify for your theme/version) */
    }

    /* Optional: emphasize sorted header and provide better focus visibility */
    .e-grid .e-headercell[aria-sort] {
        background-color: #f3f9ff;
    }
    .e-grid .e-headercell:focus-visible {
        outline: 2px solid #005a9e;
        outline-offset: -2px;
    }
</style>

@code {
    private SfGrid<OrderData> Grid;
    private List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

internal sealed class OrderData
{
    private static readonly List<OrderData> Data = new();

    public OrderData(int orderID, string customerID, double freight, DateTime orderDate)
    {
        OrderID = orderID;
        CustomerID = customerID;
        Freight = freight;
        OrderDate = orderDate;
    }

    internal static List<OrderData> GetAllRecords()
    {
        if (Data.Count == 0)
        {
            Data.Add(new OrderData(10248, "VINET", 32.38, new DateTime(2024, 1, 10)));
            Data.Add(new OrderData(10249, "TOMSP", 11.61, new DateTime(2024, 1, 11)));
            Data.Add(new OrderData(10250, "HANAR", 65.83, new DateTime(2024, 1, 12)));
            Data.Add(new OrderData(10251, "VICTE", 41.34, new DateTime(2024, 1, 13)));
            Data.Add(new OrderData(10252, "SUPRD", 51.3, new DateTime(2024, 1, 14)));
            Data.Add(new OrderData(10253, "HANAR", 58.17, new DateTime(2024, 1, 15)));
            Data.Add(new OrderData(10254, "CHOPS", 22.98, new DateTime(2024, 1, 16)));
            Data.Add(new OrderData(10255, "RICSU", 148.33, new DateTime(2024, 1, 17)));
            Data.Add(new OrderData(10256, "WELLI", 13.97, new DateTime(2024, 1, 18)));
            Data.Add(new OrderData(10257, "HILAA", 81.91, new DateTime(2024, 1, 19)));
        }

        return Data;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public DateTime OrderDate { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXreCDMeBDUtgbSZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}