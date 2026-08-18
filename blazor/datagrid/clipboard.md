---
layout: post
title: Blazor Grid Clipboard | Syncfusion
description: Learn how to use clipboard features in Blazor Data Grid, including copy, paste, autofill, keyboard shortcuts, toolbar actions, and batch editing support.
platform: Blazor
control: DataGrid
documentation: ug
---

# Clipboard in Blazor Data Grid

The **clipboard** feature in the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) supports copying selected rows or cells with keyboard shortcuts or programmatic methods. Data can be sent to external applications such as spreadsheets or text editors.
To use keyboard shortcuts, selection must be enabled and the grid must be focused.

## Copying Data

Copy data from the DataGrid with keyboard shortcuts or programmatic methods.

### Keyboard shortcuts

To enable clipboard functionality, configure the DataGrid with the required [GridSelectionSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html). If the selection mode is **Row**, entire rows are copied. If the selection mode is **Cell**, only the highlighted cells are copied.

| Windows | Mac | Action |
|---------|-----|----------|
| <kbd>Ctrl + C</kbd> | <kbd>Command + C</kbd> | Copy selected rows or cells to the clipboard |
| <kbd>Ctrl + Shift + H</kbd> | <kbd>Command + Shift + H</kbd> | Copy selected rows or cells with headers to the clipboard |

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowSelection="true" Height="348">
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDhRNGZCfsUftPWT?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

### Programmatic copy

Clipboard actions can also be triggered with external buttons or programmatic methods when UI controls are preferred over shortcut keys.

The [`CopyAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_CopyAsync_System_Nullable_System_Boolean__) method copies selected rows or cells:

- Pass **true** to copy the selected rows or cells with headers.
- Pass **false** or omit the parameter to copy without headers.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="margin-bottom: 10px;">
    <SfButton OnClick="Copy" Content="Copy" CssClass="e-outline"></SfButton>
    <SfButton OnClick="CopyHeader" Content="Copy With Header" CssClass="e-outline" Style="margin-left: 10px;"></SfButton>
</div>
<SfGrid @ref="Grid" DataSource="@Orders" AllowSelection="true" Height="348">
    <GridSelectionSettings Type="SelectionType.Multiple"></GridSelectionSettings>
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXhxjGXCTCUxIVsj?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

---

## AutoFill

The AutoFill feature supports quick data entry by dragging a handle to copy cell values into adjacent cells. When enabled, the AutoFill handle appears in the bottom-right corner of the selected cell range. Drag the handle to fill values into neighboring cells, similar to spreadsheet applications.

To enable AutoFill, set the [EnableAutoFill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableAutoFill) property to **true** and use [Batch editing](https://blazor.syncfusion.com/documentation/datagrid/batch-editing) to copy values across multiple cells. Copied values remain in batch mode until the **Update** button is clicked to apply changes to the data source.

### Steps to use AutoFill

1. Select the cells to copy in the DataGrid.
2. After selection, a small square appears in the bottom-right corner of the selection border. When the pointer hovers over the handle, the cursor changes to a crosshair.
3. Click and drag the AutoFill handle to the target cells where the values must be copied. A highlighted area displays the target range while dragging.
4. Release the mouse button to populate the target cells with the copied data.

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZrnDcXszsUECbja?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

### AutoFill Limitations

- **Data Type Conversion:** AutoFill does not convert string values to numeric or date types. Copying strings into numeric cells results in **NaN**, and copying strings into date cells results in an **empty cell**.
- **Value Copying**: AutoFill copies values directly from the source range without generating non-linear or sequential series.
- **Virtualization**: AutoFill is not supported with virtual scrolling or column virtualization.
- **Infinite Scrolling**: With infinite scrolling, AutoFill applies only to cells within the current viewport.


---

## Pasting Data

The **Paste** feature in the Blazor DataGrid allows pasting data that was previously copied from the DataGrid by pressing <kbd>Ctrl + V</kbd>.

To enable pasting, ensure `GridEditSettings` is configured with `Mode="EditMode.Batch"` and `AllowEditing="true"`. Pasted values remain in batch mode until the **Update** button is clicked to apply changes to the data source.

### Steps to paste data

1. Select the cell to copy.
2. Press <kbd>Ctrl + C</kbd> to copy the content.
3. Select the target cell.
4. Press <kbd>Ctrl + V</kbd> to paste the copied content.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowSelection="true" Toolbar="@(new List<string>() { "Add", "Update", "Cancel" })" Height="348">
    <GridSelectionSettings CellSelectionMode="CellSelectionMode.Box" Mode="SelectionMode.Cell"></GridSelectionSettings>
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXrRjlWeSzwPgceN?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

> To paste DataGrid content, set selection [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Mode) to **Cell**, set [CellSelectionMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_CellSelectionMode) to **Box**, and enable [Batch editing](https://blazor.syncfusion.com/documentation/datagrid/batch-editing).

> **Data Type Conversion:** Pasting does not convert string values to numeric or date types. Pasting strings into numeric cells results in **NaN**, and pasting strings into date cells results in an **empty cell**. Ensure that the pasted values are compatible with the target column's data type.
