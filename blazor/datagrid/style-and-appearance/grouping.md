---
layout: post
title: Customize grouping in Blazor DataGrid | Syncfusion
description: Learn how to style and customize the grouping UI in Syncfusion Blazor DataGrid—group headers, icons, caption rows, and indent cells with CSS tips.
platform: Blazor
control: DataGrid
documentation: ug
---

# Grouping customization in Syncfusion Blazor DataGrid

The appearance of grouping elements in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can be customized using CSS. Styling options are available for various parts of the grouping interface, including:

- Group header text and container
- Expand and collapse icons
- Group caption row
- Grouping indent cell

N> - Enable grouping by setting the [AllowGrouping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowGrouping) property. Ensure that the appropriate theme stylesheet is referenced so that grouping UI elements are displayed correctly.
- Icon glyph codes (such as '\e7a2', '\e7a3') vary depending on the theme and version. Confirm the correct glyph values by inspecting the icon font used in the current setup.
The provided CSS selectors apply to all DataGrid instances (.e-grid). To scope styles to a specific grid:
    - Wrap the DataGrid in a custom container and prefix selectors with that container’s class.
    - Alternatively, use CSS isolation with the ::deep combinator.
- Class names and selectors may differ slightly depending on the theme. Use browser inspection tools to verify the correct classes.
- Ensure sufficient color contrast and visible focus indicators to support accessibility standards.

## Customizing the Group Header

The **.e-groupdroparea** class is used to style the group header area in the Blazor Grid. To change its appearance, apply CSS as shown below:

```css
.e-grid .e-groupdroparea {
    background-color: #132f49;
}
```

Style properties such as background-color, padding, border, and font can be adjusted to match the desired design.

![Blazor DataGrid group header styled with a custom background color](../images/style-and-appearance/group-header.png)

## Customizing the Group Expand or Collapse Icons

The **.e-icon-gdownarrow** and **.e-icon-grightarrow** classes are used to style the expand and collapse icons in the Blazor Grid. To change their appearance, apply CSS as shown below:

```css
.e-grid .e-icon-gdownarrow::before{
    content:'\e7c9'
    }
.e-grid .e-icon-grightarrow::before{
    content:'\e80f'
}
```

The `content` property can be modified to replace the default icon. This helps match the icon with a custom icon set or improve visual clarity. Choose from available [Syncfusion<sup style="font-size:70%">&reg;</sup> icons](https://blazor.syncfusion.com/documentation/appearance/icons) based on the selected theme.

![Customized expand and collapse icons in Blazor DataGrid group rows using CSS before content](../images/style-and-appearance/group-expand-or-collapse-icons.png)

## Customizing the Group Caption Row

The **.e-groupcaption** class is used to style the caption row in the Blazor Grid. The **.e-recordplusexpand** and **.e-recordpluscollapse** classes target the record-level expand and collapse indicators. Apply CSS as shown below to modify their appearance:

```css
.e-grid .e-groupcaption {
    background-color: #deecf9;
}

.e-grid .e-recordplusexpand,
.e-grid .e-recordpluscollapse {
    background-color: #deecf9;
}
```

Style properties such as `background-color`, `padding`, `border`, and `font` can be adjusted to match the desired design.

![Blazor DataGrid group caption row styled with a custom background color](../images/style-and-appearance/group-caption-row.png)

## Customizing the Grouping Indent Cell

The **.e-indentcell** class is used to style the grouping indent cell in the Blazor Grid. Apply CSS as shown below to modify its appearance:

```css
.e-grid .e-indentcell {
    background-color: #deecf9;
}
```

Style properties such as `background-color`, `padding`, `border`, and `font` can be adjusted to match the desired design.

![Blazor DataGrid grouping indent cell styled with a custom background color](../images/style-and-appearance/indent-cell.png)

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