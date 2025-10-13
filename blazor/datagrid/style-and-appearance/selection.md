---
layout: post
title: Selection styling with CSS in Blazor DataGrid | Syncfusion
description: Learn how to style row and cell selection in Syncfusion Blazor DataGrid using CSS, with tips on isolation and selector specificity.
platform: Blazor
control: DataGrid
documentation: ug
---

# Selection customization in Syncfusion Blazor DataGrid

The appearance of selection elements in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can be styled using CSS. Styling options are available for different selection states:

- Row selection background
- Cell selection background

N> - Ensure that the required theme stylesheet is referenced so that selection-related UI elements are displayed correctly.
- When using CSS isolation (.razor.css), use the ::deep selector to reach internal parts of the DataGrid, or place the grid inside a custom wrapper class and apply styles to that wrapper for better control.
- Class names may change slightly depending on the theme or version. Inspect the DOM to confirm selectors before applying styles.
- Maintain strong color contrast and clear focus indicators to support accessibility and improve readability.

## Customizing Row Selection Background

The **.e-selectionbackground** class is used to style the background of selected row cells in the Blazor DataGrid. To modify its appearance, apply CSS:

```css
.e-grid td.e-selectionbackground {
    background-color: #00b7ea;
}
```

Properties such as `background-color`, `color`, `border`, or `font-weight` can be modified to match the overall design of the grid layout.

![Row selection](../images/style-and-appearance/row-selection.png)

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" Height="315"  AllowPaging="true">
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridSelectionSettings  Mode="SelectionMode.Row" Type="SelectionType.Multiple"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    .e-grid td.e-selectionbackground {
        background-color: #00b7ea;
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
    private static readonly List<OrderData> Data = new List<OrderData>();

    internal OrderData(int orderId, string customerId, double freight, DateTime orderDate)
    {
        OrderID = orderId;
        CustomerID = customerId;
        Freight = freight;
        OrderDate = orderDate;
    }

    public static List<OrderData> GetAllRecords()
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjhyijCZSrZDvETW?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customizing Cell Selection Background

The **.e-cellselectionbackground** class is used to style the background of selected cells in the Blazor DataGrid. To modify its appearance, apply CSS:

```css
.e-grid td.e-cellselectionbackground {
    background-color: #00b7ea;
}
```

Properties such as `background-color`, `color`, `border`, or `font-weight` can be modified to match the overall design of the grid layout.

![Cell selection](../images/style-and-appearance/cell-selection.png)

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" Height="315"  AllowPaging="true">
    <GridPageSettings PageSize="8"></GridPageSettings>
     <GridSelectionSettings  Mode="Syncfusion.Blazor.Grids.SelectionMode.Cell" Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    .e-grid td.e-cellselectionbackground {
        background-color: #00b7ea;
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
    private static readonly List<OrderData> Data = new List<OrderData>();

    internal OrderData(int orderId, string customerId, double freight, DateTime orderDate)
    {
        OrderID = orderId;
        CustomerID = customerId;
        Freight = freight;
        OrderDate = orderDate;
    }

    public static List<OrderData> GetAllRecords()
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjhSWNMjyBCKUHjL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}