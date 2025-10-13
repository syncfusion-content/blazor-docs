---
layout: post
title: Style and appearance in Blazor DataGrid | Syncfusion
description: Checkout and learn here all about style and appearance in Syncfusion Blazor DataGrid and more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Style and appearance in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGri

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid offers various ways to customize its appearance using both default CSS and custom themes. Let's go over some common approaches:

**Default CSS overrides:**

You can use custom CSS to override the default styles of the Grid. This allows you to change colors, fonts, paddings, and more. You can inspect the generated HTML of the Grid using browser developer tools to identify the relevant CSS classes and styles.

Here's a basic example of how you can override the header background color of the Grid:

```css
/* In your control's CSS file */
.e-grid .e-headercell {
    background-color: #333; /* Override the header background color */
    color: #fff;
}
```

![Change header background](../images/style-and-appearance/header-background.png)

**Using theme studio:**

Syncfusion's Theme Studio tool allows you to create custom themes for all their controls, including the Grid. This is a more advanced approach that lets you define a comprehensive set of styles to achieve a consistent look and feel throughout your application.

1. Visit the [Syncfusion<sup style="font-size:70%">&reg;</sup> Theme Studio](https://blazor.syncfusion.com/themestudio/?theme=material3).
2. Select the Grid from the left panel.
3. Customize various aspects of the control's appearance, such as colors, typography, and spacing.
4. Once done, you can download the generated CSS file and include it in your Blazor project.

## Customizing the Blazor DataGrid root element

To customize the appearance of the root element of the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Grid, you can use CSS. Here's an example of how to modify the font family and row colors using CSS:

```css
.e-grid {
      font-family: cursive;
}

```

![Grid root element](../images/style-and-appearance/style-font-family.png)

The above code snippet, the **.e-grid** class targets the root element of the Grid, and the `font-family` property is set to cursive to change the font family of Grid.

In the following sample, the font family of Grid content is changed to **cursive**, and the background color of rows, selected rows, alternate rows, and row hovering color is modified using the below CSS styles.

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

To customize the alternate row style in the Grid when [Frozen columns](https://blazor.syncfusion.com/documentation/datagrid/frozen-column) are enabled, you can use the following CSS code:

```css
.e-grid .e-altrow .e-rowcell {
    background-color: #E8EEFA;
}

```

In this example, the **.e-altrow .e-rowcell** class targets the cells in alternate rows and applies a custom background color. 

![Grid root element](../images/style-and-appearance/style-frozon.png)

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

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to personalize the appearance of Grid lines to match your application's design.

To customize the color of Grid lines, you can apply CSS styles directly to the Grid’s structural elements such as header cells and row cells. This approach gives you full control over the color, thickness, and style of the borders between cells.

```css
    /* Customize the color of Grid lines */
    .e-grid .e-gridheader, .e-grid .e-headercell, .e-grid .e-rowcell, .e-grid {
        border-color: yellow;
        border-style: solid;
        border-width: 2px;
    }

```

![Grid Line](../images/style-and-appearance/grid-line.png)

The following example demonstrates how to customize the color of Grid lines while using [GridLines](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GridLines) property in Grid:

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