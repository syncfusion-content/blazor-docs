---
layout: post
title: Syncfusion Blazor DataGrid Styling Guide with CSS and Theme Studio
description: Learn to customize the Syncfusion Blazor DataGrid using CSS and Theme Studio, including headers, rows, alternate rows, and grid lines.
platform: Blazor
control: DataGrid
documentation: ug
---

# Style and appearance in Syncfusion Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports extensive visual customization with CSS and theme-based styling. The following guidance focuses on practical CSS overrides and theme-driven approaches for headers, rows, alternate rows, and grid lines. When using CSS isolation (.razor.css), ensure styles reach internal Grid elements by using the :deep(...) or ::deep(...) combinator (depending on tooling), or increase specificity by scoping rules with a wrapper class or Grid ID if theme styles override custom CSS.

**Default CSS overrides:**

Use custom CSS to override default Grid styles such as colors, typography, spacing, and borders. Inspect the rendered HTML with browser developer tools to identify relevant selectors and class names. Prefer CSS variables/theme tokens where available to keep styling consistent across components and themes.

Here is a basic example that overrides the header background color:

```css
/* In your control's CSS file */
.e-grid .e-headercell {
    background-color: #333; /* Override the header background color */
    color: #fff;
}
```

![Change header background](../images/style-and-appearance/header-background.png)

**Using theme studio:**

Syncfusion Theme Studio provides a consistent, theme-based styling workflow for all components, including the DataGrid.

1. Open the [Syncfusion<sup style="font-size:70%">&reg;</sup> Theme Studio](https://blazor.syncfusion.com/themestudio/?theme=material3).
2. Select Grid in the left panel.
3. Customize colors, typography, spacing, and other visual tokens.
4. Download the generated CSS and include it in the Blazor project (site stylesheet or theme bundle).

## Customizing the Blazor DataGrid root element

To customize the appearance of the Grid root element, apply CSS selectors to the root container. The following example modifies the font family:

```css
.e-grid {
      font-family: cursive;
}

```

![Grid root element](../images/style-and-appearance/style-font-family.png)

In this example, the .e-grid selector targets the Grid root element and applies a cursive font. For isolated styles, wrap the selector with :deep(.e-grid) in the component’s .razor.css file, or scope with a wrapper/ID to restrict the change to a specific Grid instance. For accessibility, verify that font choices and color combinations meet contrast guidelines.

In the following sample, the Grid content uses the cursive font family, and the background color of rows, selected rows, alternate rows, and row hover state is customized using the CSS shown. The hover rule uses !important; consider increasing selector specificity instead of relying on !important in production.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" Height="315" AllowPaging="true">
   <GridSelectionSettings Type="SelectionType.Multiple"></GridSelectionSettings>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="100"></GridColumn>
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
    public bool IsEncode { get; set; } = true;
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
    public OrderData()
    {

    }

    public OrderData(int? OrderID, string CustomerId, double? Freight, string ShipCity)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.Freight = Freight;
        this.ShipCity= ShipCity;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            int code = 10;
            for (int i = 1; i < 2; i++)
            {
                Orders.Add(new OrderData(10248, "VINET",32.38, "Reims"));
                Orders.Add(new OrderData(10249, "TOMSP", 11.61, "Münster"));
                Orders.Add(new OrderData(10250, "HANAR", 65.83, "Rio de Janeiro"));
                Orders.Add(new OrderData(10251, "VICTE", 41.34, "Lyon"));
                Orders.Add(new OrderData(10252, "SUPRD", 51.30, "Charleroi"));
                Orders.Add(new OrderData(10253, "CHOPS", 58.17, "Bern"));
                Orders.Add(new OrderData(10254, "RICSU", 22.98, "Genève"));
                Orders.Add(new OrderData(10255, "WELLI", 13.97, "San Cristóbal"));
                Orders.Add(new OrderData(10256, "HILAA", 81.91, "Graz"));
                code += 5;
            }
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public double? Freight { get; set; }
    public string ShipCity { get; set; }
}
 
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BtrStpWnJrFIGhRs?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customizing alternate row with Frozen columns

To adjust the alternate row style when [Frozen columns](https://blazor.syncfusion.com/documentation/datagrid/frozen-column) are enabled, apply CSS to the alternate row selector as shown below:

```css
.e-grid .e-altrow .e-rowcell {
    background-color: #E8EEFA;
}

```

In this example, the `.e-altrow .e-rowcell` selector targets the cells in alternate rows and applies a custom background color. If using CSS isolation, apply :deep(.e-grid .e-altrow .e-rowcell) within the component’s .razor.css file, or scope the selector with a wrapper/ID to limit the change to a single Grid. Verify the appearance in right-to-left layouts if the application supports RTL.

![Alternate row styling with frozen columns](../images/style-and-appearance/style-frozon.png)

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" Height="315" AllowPaging="true">
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsFrozen="true" TextAlign="TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="100"></GridColumn>
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
    public bool IsEncode { get; set; } = true;
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
    public OrderData()
    {

    }

    public OrderData(int? OrderID, string CustomerId, double? Freight, string ShipCity)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.Freight = Freight;
        this.ShipCity= ShipCity;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            int code = 10;
            for (int i = 1; i < 2; i++)
            {
                Orders.Add(new OrderData(10248, "VINET",32.38, "Reims"));
                Orders.Add(new OrderData(10249, "TOMSP", 11.61, "Münster"));
                Orders.Add(new OrderData(10250, "HANAR", 65.83, "Rio de Janeiro"));
                Orders.Add(new OrderData(10251, "VICTE", 41.34, "Lyon"));
                Orders.Add(new OrderData(10252, "SUPRD", 51.30, "Charleroi"));
                Orders.Add(new OrderData(10253, "CHOPS", 58.17, "Bern"));
                Orders.Add(new OrderData(10254, "RICSU", 22.98, "Genève"));
                Orders.Add(new OrderData(10255, "WELLI", 13.97, "San Cristóbal"));
                Orders.Add(new OrderData(10256, "HILAA", 81.91, "Graz"));
                code += 5;
            }
        }
        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public double? Freight { get; set; }
    public string ShipCity { get; set; }
}
 
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNLSNetLzivgmRSN?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customize the color of Grid lines

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows customization of Grid line appearance to match application design requirements.

To customize the color of Grid lines, apply CSS to structural elements such as header cells and row cells. This approach provides control over color, thickness, and style of borders between cells. Consider the GridLines property and theme defaults, as they also influence the presence and style of borders.

```css
    /* Customize the color of Grid lines */
    .e-grid .e-gridheader, .e-grid .e-headercell, .e-grid .e-rowcell, .e-grid {
        border-color: yellow;
        border-style: solid;
        border-width: 2px;
    }

```

![Grid lines with custom borders](../images/style-and-appearance/grid-line.png)
The following example demonstrates customizing Grid line color while using the [GridLines](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GridLines) property in the Grid. Use the minimal set of selectors required to achieve the desired effect to avoid unintended layout changes, and verify accessibility and contrast in high-contrast themes.

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
    public OrderData()
    {

    }
    public OrderData(int? OrderID, string CustomerID, double Freight,DateTime? OrderDate)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerID;   
        this.Freight = Freight;  
        this.OrderDate = OrderDate;           
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count() == 0)
        {
            int code = 10;
            for (int i = 1; i < 2; i++)
            {
                Orders.Add(new OrderData(10248, "VINET", 32.38,new DateTime(1996,7,4)));
                Orders.Add(new OrderData(10249, "TOMSP", 11.61, new DateTime(1996, 7, 5)));
                Orders.Add(new OrderData(10250, "HANAR", 65.83, new DateTime(1996, 7, 6)));
                Orders.Add(new OrderData(10251, "VINET", 41.34, new DateTime(1996, 7, 7)));
                Orders.Add(new OrderData(10252, "SUPRD", 51.30, new DateTime(1996, 7, 8)));
                Orders.Add(new OrderData(10253, "HANAR", 58.17, new DateTime(1996, 7, 9)));
                Orders.Add(new OrderData(10254, "CHOPS", 22.98, new DateTime(1996, 7, 10)));
                Orders.Add(new OrderData(10255, "VINET", 148.33, new DateTime(1996, 7, 11)));
                Orders.Add(new OrderData(10256, "HANAR", 13.97, new DateTime(1996, 7, 12)));
                code += 5;
            }
        }
        return Orders;
    }
    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }       
}
 
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjVeXGhOqfxsRDrR?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}