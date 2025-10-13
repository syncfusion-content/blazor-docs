---
layout: post
title: Syncfusion Blazor DataGrid Styling Guide with CSS and Theme Studio
description: Learn to customize the Syncfusion Blazor DataGrid using CSS and Theme Studio, including headers, rows, alternate rows, and grid lines.
platform: Blazor
control: DataGrid
documentation: ug
---

# Style and appearance in Syncfusion Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports extensive visual customization using CSS and theme-based styling. Styling can be applied to various elements such as header cells, data rows, alternate rows, and grid lines.

N> - When using CSS isolation (.razor.css), use the **::deep(...)** selector to reach internal parts of the DataGrid, or place the grid inside a custom wrapper class and apply styles to that wrapper for better control.
- Use component-level styles in the .razor.css file for production scenarios. Inline styles within the Razor page are suitable for quick demonstrations.

**Default CSS Overrides:**

Override default Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid styles, such as colors, typography, spacing, and borders, using custom CSS. Use browser developer tools to inspect the rendered HTML and identify relevant selectors and class names. Where possible, utilize CSS variables or theme tokens to ensure consistency across components and themes.

```css
/* In your control's CSS file */
.e-grid .e-headercell {
    background-color: #333; /* Override the header background color */
    color: #fff;
}
```

Style properties such as `background-color`, `color`, `font-family`, and `padding` can be adjusted to align with the desired design.

![Change header background](../images/style-and-appearance/header-background.png)

**Using Theme Studio**

Syncfusion Theme Studio offers a unified approach to style all components, including the Blazor DataGrid, with consistent theming.

1. Open the [Syncfusion<sup style="font-size:70%">&reg;</sup> Theme Studio](https://blazor.syncfusion.com/themestudio/?theme=material3).
2. Select **Grid** in the left panel.
3. Customize colors, typography, spacing, and other visual tokens.
4. Download the generated CSS and include it in the Blazor project (site stylesheet or theme bundle).

## Customizing the Blazor DataGrid Root Element

The **.e-grid** class is used to style the root container of the Blazor DataGrid. To modify its appearance, apply CSS:

```css
.e-grid {
      font-family: cursive;
}

```

Style properties such as `font-family`, b`ackground-color`, `padding`, and `border` can be adjusted to match the desired design.

![Grid root element](../images/style-and-appearance/style-font-family.png)

This customization applies a cursive font to the grid content. Additional styling can be applied to rows, alternate rows, selected rows, and hover states. Avoid using `!important` for hover styles in production environments. Instead, increase selector specificity to maintain consistent styling control.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" Height="315" AllowPaging="true">
   <GridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GridSelectionSettings>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

<style>

    .e-grid {
        font-family: cursive;
    }

    .e-grid .e-row:hover .e-rowcell {
        background-color: rgb(204, 229, 255) !important;
    }

    .e-grid .e-rowcell.e-selectionbackground {
        background-color: rgb(230, 230, 250);
     }

    .e-grid .e-row.e-altrow {
        background-color: rgb(150, 212, 212);
     }

    .e-grid .e-row {
        background-color: rgb(180, 180, 180);
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

    public OrderData(int orderId, string customerId, double freight, string shipCity)
    {
        OrderID = orderId;
        CustomerID = customerId;
        Freight = freight;
        ShipCity = shipCity;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Data.Count == 0)
        {
            Data.Add(new OrderData(10248, "VINET", 32.38, "Reims"));
            Data.Add(new OrderData(10249, "TOMSP", 11.61, "Münster"));
            Data.Add(new OrderData(10250, "HANAR", 65.83, "Rio de Janeiro"));
            Data.Add(new OrderData(10251, "VICTE", 41.34, "Lyon"));
            Data.Add(new OrderData(10252, "SUPRD", 51.30, "Charleroi"));
            Data.Add(new OrderData(10253, "CHOPS", 58.17, "Bern"));
            Data.Add(new OrderData(10254, "RICSU", 22.98, "Genève"));
            Data.Add(new OrderData(10255, "WELLI", 13.97, "San Cristóbal"));
            Data.Add(new OrderData(10256, "HILAA", 81.91, "Graz"));
        }

        return Data;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZLIMXMNfRZbKGZC?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customizing Alternate Row with Frozen Columns

The **.e-altrow .e-rowcell** selector is used to style the cells in alternate rows when [Frozen columns](https://blazor.syncfusion.com/documentation/datagrid/frozen-columns) are enabled in the Blazor DataGrid.

```css
.e-grid .e-altrow .e-rowcell {
    background-color: #E8EEFA;
}

```

Style properties such as` background-color`, `font-family`, `font-size`, and `border` can be adjusted to match the desired design.

![Alternate row styling with frozen columns](../images/style-and-appearance/style-frozon.png)

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" Height="315" AllowPaging="true">
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsFrozen="true" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
    </GridColumns>
</SfGrid>

<style>

    .e-grid .e-altrow .e-rowcell {
        background-color: #E8EEFA;
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

    public OrderData(int orderId, string customerId, double freight, string shipCity)
    {
        OrderID = orderId;
        CustomerID = customerId;
        Freight = freight;
        ShipCity = shipCity;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Data.Count == 0)
        {
            Data.Add(new OrderData(10248, "VINET", 32.38, "Reims"));
            Data.Add(new OrderData(10249, "TOMSP", 11.61, "Münster"));
            Data.Add(new OrderData(10250, "HANAR", 65.83, "Rio de Janeiro"));
            Data.Add(new OrderData(10251, "VICTE", 41.34, "Lyon"));
            Data.Add(new OrderData(10252, "SUPRD", 51.30, "Charleroi"));
            Data.Add(new OrderData(10253, "CHOPS", 58.17, "Bern"));
            Data.Add(new OrderData(10254, "RICSU", 22.98, "Genève"));
            Data.Add(new OrderData(10255, "WELLI", 13.97, "San Cristóbal"));
            Data.Add(new OrderData(10256, "HILAA", 81.91, "Graz"));
        }

        return Data;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
}
 
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hthyMDsjpeYMriLk?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customizing the Color of Grid Lines

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid enables customization of grid lines to match application design requirements. Apply CSS to structural elements such as header cells, row cells, and the grid container to control the color, thickness, and border style. The [GridLines](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GridLines) property defines border visibility and supports options for `horizontal`, `vertical`, `both`, or `none`.

```css
    /* Customize the color of Grid lines */
    .e-grid .e-gridheader, .e-grid .e-headercell, .e-grid .e-rowcell, .e-grid {
        border-color: yellow;
        border-style: solid;
        border-width: 2px;
    }

```

![Grid lines with custom borders](../images/style-and-appearance/grid-line.png)

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315" GridLines="Syncfusion.Blazor.Grids.GridLine.Both">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Format="C2" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="Syncfusion.Blazor.Grids.ColumnType.Date" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    /* Customize the color of Grid lines */
    .e-grid .e-gridheader, .e-grid .e-headercell, .e-grid .e-rowcell, .e-grid {
        border-color: yellow;
        border-style: solid;
        border-width: 2px;
        
    }
</style>

@code {
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

    public OrderData(int orderId, string customerId, double freight, DateTime orderDate)
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
            Data.Add(new OrderData(10248, "VINET", 32.38, new DateTime(1996, 7, 4)));
            Data.Add(new OrderData(10249, "TOMSP", 11.61, new DateTime(1996, 7, 5)));
            Data.Add(new OrderData(10250, "HANAR", 65.83, new DateTime(1996, 7, 6)));
            Data.Add(new OrderData(10251, "VINET", 41.34, new DateTime(1996, 7, 7)));
            Data.Add(new OrderData(10252, "SUPRD", 51.30, new DateTime(1996, 7, 8)));
            Data.Add(new OrderData(10253, "HANAR", 58.17, new DateTime(1996, 7, 9)));
            Data.Add(new OrderData(10254, "CHOPS", 22.98, new DateTime(1996, 7, 10)));
            Data.Add(new OrderData(10255, "VINET", 148.33, new DateTime(1996, 7, 11)));
            Data.Add(new OrderData(10256, "HANAR", 13.97, new DateTime(1996, 7, 12)));
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtVyMtWtTlHHsAzL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}