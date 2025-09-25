---
layout: post
title: Paging customization in Syncfusion Blazor DataGrid
description: Learn how to style the Syncfusion Blazor DataGrid paging UI using CSS—pager container, navigation buttons, numeric items, and page indicator.
platform: Blazor
control: DataGrid
documentation: ug
---

# Paging customization in Syncfusion Blazor DataGrid

The appearance of paging elements in the Syncfusion Blazor DataGrid can be customized using CSS. The following examples show how to style the pager root, pager container, navigation buttons, numeric page links, and the current page indicator.

## Customizing the Blazor DataGrid pager root element

To customize the Grid pager root element, apply CSS like the following:

```css
.e-grid .e-gridpager {
    font-family: cursive;
    background-color: #deecf9;
}
```
In this example, the `.e-gridpager` class targets the pager root element. Modify `font-family` to change the typography and `background-color` to change the pager background.
![Blazor DataGrid pager root with custom background and font](../images/style-and-appearance/grid-pager-root-element.png)

## Customizing the Blazor DataGrid pager container element

To customize the Grid pager container element, apply CSS like the following:

```css
.e-grid .e-pagercontainer {
    border: 2px solid #00b5ff;
    font-family: cursive;
}
```

In this example, the `.e-pagercontainer` class targets the pager container. Modify the `border` and `font-family` properties to adjust the border style and typography.

![Blazor DataGrid pager container with custom border and font](../images/style-and-appearance/grid-pager-container-element.png)

## Customizing the Blazor DataGrid pager navigation elements

To customize the Grid pager navigation elements, apply CSS like the following:

```css
.e-grid .e-gridpager .e-prevpagedisabled,
.e-grid .e-gridpager .e-prevpage,
.e-grid .e-gridpager .e-nextpage,
.e-grid .e-gridpager .e-nextpagedisabled,
.e-grid .e-gridpager .e-lastpagedisabled,
.e-grid .e-gridpager .e-lastpage,
.e-grid .e-gridpager .e-firstpage,
.e-grid .e-gridpager .e-firstpagedisabled {
    background-color: #deecf9;
}
```

In this example, the classes `.e-prevpagedisabled`, .`e-prevpage`, `.e-nextpage`, `.e-nextpagedisabled`, .`e-lastpagedisabled`, `.e-lastpage`, `.e-firstpage`, and .`e-firstpagedisabled` target the navigation buttons. Modify `background-color` to change the button backgrounds.

![Blazor DataGrid pager navigation buttons with custom background](../images/style-and-appearance/grid-pager-navigation-element.png)

## Customizing the Blazor DataGrid pager page numeric link elements

To customize the Grid pager page numeric link elements, apply CSS like the following:

```css
.e-grid .e-gridpager .e-numericitem {
    background-color: #5290cb;
    color: #ffffff;
    cursor: pointer;
    }
    
.e-grid .e-gridpager .e-numericitem:hover {
    background-color: white;
    color:  #007bff;
}
```

In this example, the `.e-numericitem` class targets the numeric page links. Modify `background-color` and `color` to adjust the default and hover styles.

![Blazor DataGrid pager numeric links with custom default and hover styles](../images/style-and-appearance/pager-page-numeric-link-elements.png)

## Customizing the Blazor DataGrid pager current page numeric element

To customize the Grid pager current page numeric element, apply CSS like the following:

```css
.e-grid .e-gridpager .e-currentitem {
    background-color: #0078d7;
    color: #fff;
}
```

In this example, the `.e-currentitem` class targets the current page. Modify `background-color` and `color` to adjust the highlight and text color.

![Blazor DataGrid current page indicator with custom background and text color](../images/style-and-appearance/grid-pager-current-page-numeric-element.png)


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
    .e-grid .e-gridpager .e-currentitem {
        background-color: #0078d7;
        color: #fff;
    }
    .e-grid .e-gridpager .e-numericitem {
        background-color: #5290cb;
        color: #ffffff;
        cursor: pointer;
        }
        
    .e-grid .e-gridpager .e-numericitem:hover {
        background-color: white;
        color:  #007bff;
    }
    .e-grid .e-gridpager .e-prevpagedisabled,
    .e-grid .e-gridpager .e-prevpage,
    .e-grid .e-gridpager .e-nextpage,
    .e-grid .e-gridpager .e-nextpagedisabled,
    .e-grid .e-gridpager .e-lastpagedisabled,
    .e-grid .e-gridpager .e-lastpage,
    .e-grid .e-gridpager .e-firstpage,
    .e-grid .e-gridpager .e-firstpagedisabled {
        background-color: #deecf9;
    }
    .e-grid .e-pagercontainer {
        border: 2px solid #00b5ff;
        font-family: cursive;
    }
    .e-grid .e-gridpager {
        font-family: cursive;
        background-color: #deecf9;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDVejyDhUQlhxJtR?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}