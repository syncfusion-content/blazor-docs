---
layout: post
title: Clipboard in Blazor DataGrid Component | Syncfusion
description: Learn how to copy, paste, and autofill data in the Syncfusion Blazor DataGrid using keyboard shortcuts, buttons, and batch editing.
platform: Blazor
control: DataGrid
documentation: ug
---

# Clipboard in Syncfusion Blazor DataGrid

The **clipboard** feature in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows copying selected rows or cells using keyboard shortcuts or programmatic methods. This helps transfer data to external applications such as spreadsheets or text editors.
To use keyboard shortcuts, selection must be enabled and the grid must be focused.

| Windows | Mac | Actions |
|---------|-----|---------|
| <kbd>Ctrl + C</kbd> | <kbd>Command + C</kbd> | Copy selected rows or cells to the clipboard |
| <kbd>Ctrl + Shift + H</kbd> | <kbd>Command + Shift + H</kbd> | Copy selected rows or cells with headers to the clipboard |

To enable clipboard functionality, configure the DataGrid with the required [GridSelectionSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html). If the selection mode is `Row`, entire rows are copied. If it is `Cell`, only the highlighted cells are copied.

### Example: Enabling Clipboard Support

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="348">
    <GridSelectionSettings Type="SelectionType.Multiple"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120" IsPrimaryKey="true" />
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150" />
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150" />
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="150" />
    </GridColumns>
</SfGrid>

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

    internal OrderData(int orderID, string customerID, string shipCity, string shipName)
    {
        OrderID = orderID;
        CustomerID = customerID;
        ShipCity = shipCity;
        ShipName = shipName;
    }

    internal static List<OrderData> GetAllRecords()
    {
        if (Data.Count == 0)
        {
            Data.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevalier"));
            Data.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
            Data.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Data.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
            Data.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
            Data.Add(new OrderData(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Data.Add(new OrderData(10254, "CHOPS", "Bern", "Chop-suey Chinese"));
            Data.Add(new OrderData(10255, "RICSU", "Genève", "Richter Supermarkt"));
            Data.Add(new OrderData(10256, "WELLI", "Resende", "Wellington Import Export"));
            Data.Add(new OrderData(10257, "HILAA", "San Cristóbal", "Hila Alimentos"));
            Data.Add(new OrderData(10258, "ERNSH", "Graz", "Ernst Handel"));
            Data.Add(new OrderData(10259, "CENTC", "México D.F.", "Centro comercial"));
            Data.Add(new OrderData(10260, "OTTIK", "Köln", "Ottilies Käseladen"));
            Data.Add(new OrderData(10261, "QUEDE", "Rio de Janeiro", "Que delícia"));
            Data.Add(new OrderData(10262, "RATTC", "Albuquerque", "Rattlesnake Canyon Grocery"));
        }

        return Data;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXLosNWcpKkBYKnF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Copy to Clipboard Using External Buttons

Clipboard actions can be triggered using external buttons when using UI controls is preferred over shortcut keys.

The [CopyAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_CopyAsync_System_Nullable_System_Boolean__) method programmatically copies selected rows or cells:

- Pass `true` to include column headers in the copied content.
- Pass `false` or omit the parameter to copy without headers.

**Example: Copy to Clipboard with External Buttons**

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
    private List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    private async Task Copy()
    {
        await Grid.CopyAsync();
    }

    private async Task CopyHeader()
    {
        await Grid.CopyAsync(true);
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

internal sealed class OrderData
{
    private static readonly List<OrderData> Data = new List<OrderData>();

    internal OrderData(int orderID, string customerID, string shipCity, string shipName)
    {
        OrderID = orderID;
        CustomerID = customerID;
        ShipCity = shipCity;
        ShipName = shipName;
    }

    internal static List<OrderData> GetAllRecords()
    {
        if (Data.Count == 0)
        {
            Data.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevalier"));
            Data.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
            Data.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Data.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
            Data.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
            Data.Add(new OrderData(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Data.Add(new OrderData(10254, "CHOPS", "Bern", "Chop-suey Chinese"));
            Data.Add(new OrderData(10255, "RICSU", "Genève", "Richter Supermarkt"));
            Data.Add(new OrderData(10256, "WELLI", "Resende", "Wellington Import Export"));
            Data.Add(new OrderData(10257, "HILAA", "San Cristóbal", "Hila Alimentos"));
            Data.Add(new OrderData(10258, "ERNSH", "Graz", "Ernst Handel"));
            Data.Add(new OrderData(10259, "CENTC", "México D.F.", "Centro comercial"));
            Data.Add(new OrderData(10260, "OTTIK", "Köln", "Ottilies Käseladen"));
            Data.Add(new OrderData(10261, "QUEDE", "Rio de Janeiro", "Que delícia"));
            Data.Add(new OrderData(10262, "RATTC", "Albuquerque", "Rattlesnake Canyon Grocery"));
        }

        return Data;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BthSsjCcfTtZWPnL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## AutoFill

The AutoFill feature in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows quick data entry by copying values from selected cells and filling them into adjacent cells using a drag handle.

**Steps to Use AutoFill Feature**

1. Select the desired cells to copy.
2. Hover over the bottom-right corner of the selection to display the autofill handle.
3. Drag the handle to the target cells.
4. Release the mouse to populate the target cells with the copied data.

To enable AutoFill, set the [EnableAutoFill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableAutoFill) property to `true` and use [batch editing](https://blazor.syncfusion.com/documentation/datagrid/batch-editing) to allow copying values across multiple cells.

**Example: AutoFill with Batch Editing**

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" EnableAutoFill="true" AllowSelection="true" Toolbar="@(new List<string>() { "Add", "Update", "Cancel" })" Height="348">
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

    public OrderData(int orderID, string customerID, string shipCity, string shipName)
    {
        OrderID = orderID;
        CustomerID = customerID;
        ShipCity = shipCity;
        ShipName = shipName;
    }

    internal static List<OrderData> GetAllRecords()
    {
        if (Data.Count == 0)
        {
            Data.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevalier"));
            Data.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
            Data.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Data.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
            Data.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
            Data.Add(new OrderData(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Data.Add(new OrderData(10254, "CHOPS", "Bern", "Chop-suey Chinese"));
            Data.Add(new OrderData(10255, "RICSU", "Genève", "Richter Supermarkt"));
            Data.Add(new OrderData(10256, "WELLI", "Resende", "Wellington Import Export"));
            Data.Add(new OrderData(10257, "HILAA", "San Cristóbal", "Hila Alimentos"));
            Data.Add(new OrderData(10258, "ERNSH", "Graz", "Ernst Handel"));
            Data.Add(new OrderData(10259, "CENTC", "México D.F.", "Centro comercial"));
            Data.Add(new OrderData(10260, "OTTIK", "Köln", "Ottilies Käseladen"));
            Data.Add(new OrderData(10261, "QUEDE", "Rio de Janeiro", "Que delícia"));
            Data.Add(new OrderData(10262, "RATTC", "Albuquerque", "Rattlesnake Canyon Grocery"));
        }

        return Data;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXVIsNicJTjOUEma?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * When [EnableAutoFill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableAutoFill) is set to `true`, the autofill handle appears on cell selection.
> * AutoFill requires selection [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Mode) set to `Cell`, [CellSelectionMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_CellSelectionMode) set to `Box`, and [EditMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.EditMode.html#fields) set to `Batch`.

### Limitations

- **Data Type Conversion**: AutoFill does not convert string values to numeric or date types. Copying strings into numeric cells results in `NaN`, and copying strings into date cells results in an `empty cell`.
- **Value Copying**: AutoFill copies values directly from the source range without generating non-linear or sequential series.
- **Virtualization**: AutoFill is not supported with virtual scrolling or column virtualization.
- **Infinite Scrolling**: With infinite scrolling, AutoFill applies only to cells within the current viewport.

## Paste

The Paste feature in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows copying content from selected cells and pasting it into another range using <kbd>Ctrl + C</kbd> and <kbd>Ctrl + V</kbd>.

**To paste data within the grid:**

1. Select the cells to copy.
2. Press <kbd>Ctrl + C</kbd> to copy the content.
3. Select the target cells.
4. Press <kbd>Ctrl + V</kbd> to paste the copied content.

**Example: Paste with Batch Editing**

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" EnableAutoFill="true" AllowSelection="true" Toolbar="@(new List<string>() { "Add", "Update", "Cancel" })" Height="348">
    <GridSelectionSettings CellSelectionMode="CellSelectionMode.Box" Mode="SelectionMode.Cell" Type="SelectionType.Multiple"></GridSelectionSettings>
    <GridEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" Mode="EditMode.Batch"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Visible="false" Width="120" IsPrimaryKey="true" />
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150" />
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="150" />
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="150" />
    </GridColumns>
</SfGrid>

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

    public OrderData(int orderID, string customerID, string shipCity, string shipName)
    {
        OrderID = orderID;
        CustomerID = customerID;
        ShipCity = shipCity;
        ShipName = shipName;
    }

    internal static List<OrderData> GetAllRecords()
    {
        if (Data.Count == 0)
        {
            Data.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevalier"));
            Data.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
            Data.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Data.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
            Data.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
            Data.Add(new OrderData(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            Data.Add(new OrderData(10254, "CHOPS", "Bern", "Chop-suey Chinese"));
            Data.Add(new OrderData(10255, "RICSU", "Genève", "Richter Supermarkt"));
            Data.Add(new OrderData(10256, "WELLI", "Resende", "Wellington Import Export"));
            Data.Add(new OrderData(10257, "HILAA", "San Cristóbal", "Hila Alimentos"));
            Data.Add(new OrderData(10258, "ERNSH", "Graz", "Ernst Handel"));
            Data.Add(new OrderData(10259, "CENTC", "México D.F.", "Centro comercial"));
            Data.Add(new OrderData(10260, "OTTIK", "Köln", "Ottilies Käseladen"));
            Data.Add(new OrderData(10261, "QUEDE", "Rio de Janeiro", "Que delícia"));
            Data.Add(new OrderData(10262, "RATTC", "Albuquerque", "Rattlesnake Canyon Grocery"));
        }

        return Data;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDBoWNsGJziFNQMu?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> To paste content, set selection [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Mode) to `Cell`, set [CellSelectionMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_CellSelectionMode) to `Box`, and enable [Batch editing](https://blazor.syncfusion.com/documentation/datagrid/batch-editing).

### Limitations

- **Data Type Conversion**: Pasting does not convert string values to numeric or date types. Pasting strings into numeric cells results in `NaN`; pasting strings into date cells results in an `empty cell`. Ensure that the pasted values are compatible with the target column's data type.