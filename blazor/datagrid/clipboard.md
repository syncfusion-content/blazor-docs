---
layout: post
title: Clipboard in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Clipboard in the Syncfusion Blazor DataGrid component and much more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Clipboard in Blazor DataGrid

The clipboard feature in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides an easy way to copy selected rows or cells data into the clipboard. You can use keyboard shortcuts to perform the copy operation. The following list of keyboard shortcuts is supported in the Grid to copy selected rows or cells data into clipboard.

Interaction keys |Description
-----|-----
<kbd>Ctrl + C</kbd> |Copy selected rows or cells data into clipboard.
<kbd>Ctrl + Shift + H</kbd> |Copy selected rows or cells data with header into clipboard.

By using these keyboard shortcuts, you can quickly copy data from the Grid to the clipboard, making it easy to paste the data into other applications or documents.

To enable the clipboard feature, you can use the Grid with your data source and selection property. 

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid  DataSource="@Orders" Height="348">
    <GridSelectionSettings Type="SelectionType.Multiple"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" IsPrimaryKey="true" />
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150" />
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150" />
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="150" />
    </GridColumns>
</SfGrid>

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtrSsMMTUwjEIPln?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


## Copy to clipboard by external buttons

Copying data to the clipboard by using external buttons in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to programmatically trigger the copy operation, making it more friendly, especially for those who may not be familiar with keyboard shortcuts or manual copying.

To copy selected rows or cells data into the clipboard with the help of external buttons, you can utilize the [CopyAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_CopyAsync_System_Nullable_System_Boolean__) method available in the Grid. This is demonstrated in the following example,

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="margin-bottom: 10px;">
    <SfButton OnClick="Copy" Content="Copy" CssClass="e-outline"></SfButton>
    <SfButton OnClick="CopyHeader" Content="Copy With Header" CssClass="e-outline" Style="margin-left: 10px;"></SfButton>
</div>
<SfGrid @ref="Grid" DataSource="@Orders" Height="348">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" IsPrimaryKey="true" />
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150" />
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150" />
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="150" />
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    public async Task Copy()
    {
        await Grid.CopyAsync();
    }

    public async Task CopyHeader()
    {
        await Grid.CopyAsync(true);
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjVICiipKwCFoRBf?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## AutoFill

The AutoFill feature in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows you to copy the data of selected cells and paste it into other cells by simply dragging the autofill icon of the selected cells to the desired cells. This feature provides a convenient way to quickly populate data in a grid.

**how to use the autofill feature**

1. Select the cells from which you want to copy data.

2. Hover over the bottom-right corner of the selection to reveal the autofill icon.

3. Click and hold the autofill icon, then drag it to the target cells where you want to paste the copied data.

4. Release the mouse to complete the autofill action, and the data from the source cells will be copied and pasted into the target cells.

This feature is enabled by defining [EnableAutoFill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableAutoFill) property as **true**.

The following example demonstrates how to enable the autofill feature in the Grid.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" EnableAutoFill="true" AllowSelection="true" Toolbar="@(new List<string>() { "Add", "Update","Cancel" })" Height="348">
    <GridSelectionSettings CellSelectionMode="CellSelectionMode.Box" Mode="SelectionMode.Cell" Type="SelectionType.Multiple"></GridSelectionSettings>
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" Mode="EditMode.Batch"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" IsPrimaryKey="true" />
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150" />
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150" />
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="150" />
    </GridColumns>
</SfGrid>

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtresCsJgQVIUhQZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * If [EnableAutoFill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableAutoFill) is set to **true**, then the autofill icon will be displayed on cell selection to copy cells.
> * It requires the selection [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Mode) to be **Cell**,  [CellSelectionMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_CellSelectionMode) to be **Box** and also [EditMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.EditMode.html#fields) to be **Batch**. 


### Limitations

* AutoFill does not automatically convert string values to number or date types. If the selected cells contain string data and are dragged to number-type cells, the target cells will display **NaN**. Similarly, when dragging string-type cells to date-type cells, the target cells will display as an **empty cell**. It is important to ensure data types are compatible before using autofill to avoid unexpected results.

* The AutoFill feature does not support generating non-linear series or sequential data automatically. Cannot create complex series or patterns by simply dragging cells with non-sequential data. The autofill feature is designed for copying and pasting data from a selected range of cells.

* The AutoFill feature does not support virtual scrolling or column virtualization in the Grid.

* The Auto Fill feature can only be applied to the viewport cell when enabling the features of infinite scrolling in the Grid.

## Paste

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides a paste feature that allows you to copy the content of a cell or a group of cells and paste it into another set of cells. This feature allows you to quickly copy and paste content within the grid, making it convenient for data entry and manipulation.

Follow the steps below to use the Paste feature in the grid:

1. Select the cells from which you want to copy the content.

2. Press the <kbd>Ctrl + C</kbd> shortcut key to copy the selected cells' content to the clipboard.

3. Select the target cells where you want to paste the copied content.

4. Press the <kbd>Ctrl + V</kbd> shortcut key to paste the copied content into the target cells.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" EnableAutoFill="true" AllowSelection="true" Toolbar="@(new List<string>() { "Add", "Update","Cancel" })" Height="348">
    <GridSelectionSettings CellSelectionMode="CellSelectionMode.Box" Mode="SelectionMode.Cell" Type="SelectionType.Multiple"></GridSelectionSettings>
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" Mode="EditMode.Batch"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Visible='false' Width="120" IsPrimaryKey="true" />
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150" />
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150" />
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="150" />
    </GridColumns>
</SfGrid>

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjBIMiifKmAylQzo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


> To perform paste functionality, it requires the selection **mode** to be **Cell**,  **cellSelectionMode** to be **Box** and also Batch Editing should be enabled.

### Limitations

* The Paste feature does not automatically convert string values to number or date types. If the selected cells contain string data and are dragged to number-type cells, the target cells will display **NaN**. Similarly, when dragging string-type cells to date-type cells, the target cells will display as an **empty cell**. It is important to ensure data types are compatible before using AutoFill to avoid unexpected results.