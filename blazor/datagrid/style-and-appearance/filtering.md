---
layout: post
title: Filtering customization in Blazor DataGrid | Syncfusion
description: Learn how to style and customize the Syncfusion Blazor DataGrid filter UI using CSS—filter bar, dialog, icons, buttons, and menus.
platform: Blazor
control: DataGrid
documentation: ug
---

# Filtering customization in Syncfusion Blazor DataGrid

The appearance of filtering UI elements in the Syncfusion Blazor DataGrid can be customized using CSS. The following examples demonstrate how to style the filter bar, input focus states, clear and filter icons, filter dialog content and footer, dialog inputs and buttons, and Excel filter dialog menu visuals.

## Customizing the filter bar cell element

To customize the appearance of the filter bar cell element in the Grid header, apply CSS similar to the following:

```css

.e-grid .e-filterbarcell {
    background-color: #045fb4;
}

```
In this example, the `.e-filterbarcell` class targets the filter bar cell in the header row. Modify `background-color` to change the cell’s background color.

![Blazor DataGrid filter bar cell with custom background color](../images/style-and-appearance/filter-bar-cell-element.png)

## Customizing the filter bar input element

To customize the appearance of the filter bar input element in the Grid header, apply CSS similar to the following:

```css

.e-grid .e-filterbarcell .e-input-group input.e-input{
    font-family: cursive;
}

```
Here, `.e-filterbarcell` targets the filter bar cell and .`e-input` targets the input within the cell. Modify `font-family` to change the font used by the filter bar input.

![Blazor DataGrid filter bar input styled with custom font](../images/style-and-appearance/filter-bar-input-element.png)

## Customizing the filter bar input focus

To customize the focus highlight of the filter bar input element, apply CSS similar to the following:

```css

.e-grid .e-filterbarcell .e-input-group.e-input-focus{
    background-color: #deecf9;
}

```
In this example, `.e-input-group.e-input-focus` targets the focused input group. Modify background-color to adjust the focus highlight color. For accessibility, ensure sufficient contrast with the surrounding UI.

![Blazor DataGrid filter bar input with custom focus background](../images/style-and-appearance/filter-bar-input-element-focus.png)

## Customizing the filter bar input clear icon

To customize the clear icon in the filter bar input element, apply CSS similar to the following:

```css

.e-grid .e-filterbarcell .e-input-group .e-clear-icon::before {
    content: '\e72c';
}

```
The `.e-clear-icon` selector targets the clear icon within the input group. Change the `content` value to switch the displayed glyph. Confirm the glyph code against the current theme’s icon set.

![Blazor DataGrid filter bar input with customized clear icon](../images/style-and-appearance/filter-bar-input-clear-icon.png)

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" Height="315" AllowFiltering="true" AllowPaging="true">
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    .e-grid .e-filterbarcell .e-input-group.e-input-focus{
        background-color: #deecf9;
    }
    .e-grid .e-filterbarcell .e-input-group .e-clear-icon::before {
        content: '\e72c';
    }
    .e-grid .e-filterbarcell .e-input-group input.e-input{
        font-family: cursive;
    }
    .e-grid .e-filterbarcell {
        background-color: #045fb4;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDryXIXVUYyWnGdg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customizing the Blazor DataGrid filtering icon

To customize the appearance of the Grid’s filtering icon in the header, apply CSS similar to the following:

```css

.e-grid .e-icon-filter::before{
    content: '\e81e';
}

```
In this example, `.e-icon-filter` targets the filtering icon. Modify the `content` value to change the glyph. Validate the glyph value against the current theme’s icon font.

![Blazor DataGrid header with customized filter icon](../images/style-and-appearance/grid-filtering-icon.png)

## Customizing the filter dialog content

To customize the content area of the filter dialog, apply CSS similar to the following:

```css

.e-grid .e-filter-popup .e-dlg-content {
    background-color: #deecf9;
}

```
Here, `.e-filter-popup .e-dlg-content` targets the dialog content container. Modify `background-color` to change the dialog content background.

![Blazor DataGrid filter dialog with custom content background](../images/style-and-appearance/filter-dialog-content.png)

## Customizing the filter dialog footer

To customize the footer area of the filter dialog, apply CSS similar to the following:

```css

.e-grid .e-filter-popup .e-footer-content {
    background-color: #deecf9;
}

```
Here, `.e-filter-popup .e-footer-content` targets the dialog footer container. Modify `background-color` to change the footer background.

![Blazor DataGrid filter dialog with custom footer background](../images/style-and-appearance/filter-dialog-footer.png)

## Customizing the filter dialog input element

To customize input elements inside the filter dialog, apply CSS similar to the following:

```css

.e-grid .e-filter-popup .e-input-group input.e-input{
    font-family: cursive;
}

```
In this example, `.e-filter-popup` targets the filter dialog and `.e-input` targets the input elements inside it. Modify `font-family` to change the input font.

![Blazor DataGrid filter dialog input styled with custom font](../images/style-and-appearance/filter-dialog-input-element.png)

## Customizing the filter dialog button element

To customize buttons inside the filter dialog, apply CSS similar to the following:

```css

.e-grid .e-filter-popup .e-btn{
    font-family: cursive;
}

```
Here, `.e-filter-popup` targets the filter dialog and .`e-btn` targets the buttons within it. Modify `font-family` to change the button font.

![Blazor DataGrid filter dialog buttons styled with custom font](../images/style-and-appearance/filter-dialog-button-element.png)

## Customizing the excel filter dialog number filters element

To customize the appearance of number filters in the Excel filter dialog, apply CSS similar to the following:

```css

.e-grid .e-filter-popup .e-contextmenu-container ul{
    background-color: #deecf9;
}

```
In this example, `.e-filter-popup .e-contextmenu-container` targets the Excel filter menu container, and the ul element targets the list. Modify `background-color` to change the menu background.

![Blazor DataGrid Excel filter dialog number filters with custom background](../images/style-and-appearance/excel-filter-dialog-number-filters-element.png)

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" Height="315" AllowFiltering="true" AllowPaging="true">
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridFilterSettings Type="Syncfusion.Blazor.Grids.FilterType.Menu"></GridFilterSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    .e-grid .e-icon-filter::before{
        content: '\e81e';
    }
    .e-grid .e-filter-popup .e-contextmenu-container ul{
        background-color: #deecf9;
    }
    .e-grid .e-filter-popup .e-btn{
        font-family: cursive;
    }
    .e-grid .e-filter-popup .e-input-group input.e-input{
        font-family: cursive;
    }
    .e-grid .e-filter-popup .e-footer-content {
        background-color: #deecf9;
    }
    .e-grid .e-filter-popup .e-dlg-content {
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXBSjyjhAkUzNonV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}