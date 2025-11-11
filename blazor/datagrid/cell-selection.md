---
layout: post
title: Cell Selection in Blazor DataGrid | Syncfusion
description: Learn how to use cell selection in Syncfusion Blazor DataGrid including single and multiple selection, selection modes, external controls, and events.
platform: Blazor
control: DataGrid
documentation: ug
---

# Cell Selection in Blazor DataGrid

Cell selection in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid enables interactive selection of specific cells or ranges of cells using mouse clicks or keyboard navigation (arrow keys). This feature is useful for highlighting, manipulating, or performing actions on individual cells within the Grid.

> To enable cell selection, set the [GridSelectionSettings.Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Mode) property to either **Cell** or **Both**. This determines the selection mode of the Grid.

## Single cell selection

Single cell selection allows selecting one cell at a time within the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid. This is useful for focusing on a specific cell or performing actions on individual cell values.

To enable single cell selection:

- Set the [GridSelectionSettings.Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Mode) property to **Cell**.
- Set the [GridSelectionSettings.Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Type) property to **Single**.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" AllowSelection="true" AllowPaging="true">
    <GridSelectionSettings Type="SelectionType.Single" Mode="SelectionMode.Cell"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText=" Order Date" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" TextAlign="TextAlign.Right" Width="120" Format="C2"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShippedDate) HeaderText="Shipped Date" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
}

{% endhighlight %}

{% highlight cs tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails() { }
    public OrderDetails(int orderID, string customerId, DateTime orderDate, double freight, DateTime shippedDate, string shipCountry)
    {
        this.OrderID = orderID;
        this.CustomerID = customerId;
        this.OrderDate = orderDate;
        this.Freight = freight;
        this.ShippedDate = shippedDate;
        this.ShipCountry = shipCountry;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", new DateTime(1996, 7, 4), 32.38, new DateTime(1996, 7, 16), "France"));
            order.Add(new OrderDetails(10249, "TOMSP", new DateTime(1996, 7, 5), 11.61, new DateTime(1996, 7, 10), "Germany"));
            order.Add(new OrderDetails(10250, "HANAR", new DateTime(1996, 7, 8), 65.83, new DateTime(1996, 7, 12), "Brazil"));
            order.Add(new OrderDetails(10251, "VICTE", new DateTime(1996, 7, 8), 41.34, new DateTime(1996, 7, 15), "France"));
            order.Add(new OrderDetails(10252, "SUPRD", new DateTime(1996, 7, 9), 51.3, new DateTime(1996, 7, 11), "Belgium"));
            order.Add(new OrderDetails(10253, "HANAR", new DateTime(1996, 7, 10), 58.17, new DateTime(1996, 7, 16), "Brazil"));
            order.Add(new OrderDetails(10254, "CHOPS", new DateTime(1996, 7, 11), 22.98, new DateTime(1996, 7, 23), "Switzerland"));
            order.Add(new OrderDetails(10255, "RICSU", new DateTime(1996, 7, 12), 148.33, new DateTime(1996, 7, 24), "Switzerland"));
            order.Add(new OrderDetails(10256, "WELLI", new DateTime(1996, 7, 15), 13.97, new DateTime(1996, 7, 25), "Brazil"));
            order.Add(new OrderDetails(10257, "HILAA", new DateTime(1996, 7, 16), 81.91, new DateTime(1996, 7, 30), "Venezuela"));
            order.Add(new OrderDetails(10258, "ERNSH", new DateTime(1996, 7, 17), 140.51, new DateTime(1996, 7, 29), "Austria"));
            order.Add(new OrderDetails(10259, "CENTC", new DateTime(1996, 7, 18), 3.25, new DateTime(1996, 7, 31), "Mexico"));
            order.Add(new OrderDetails(10260, "OTTIK", new DateTime(1996, 7, 19), 55.09, new DateTime(1996, 8, 1), "Germany"));
            order.Add(new OrderDetails(10261, "QUEDE", new DateTime(1996, 7, 19), 3.05, new DateTime(1996, 8, 2), "Brazil"));
            order.Add(new OrderDetails(10262, "RATTC", new DateTime(1996, 7, 22), 48.29, new DateTime(1996, 8, 5), "USA"));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime OrderDate { get; set; }
    public double? Freight { get; set; }
    public DateTime ShippedDate { get; set; }
    public string ShipCountry { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VthyWitGJmjjBhnr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Multiple cell selection

Multiple cell selection in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid enables selection of multiple cells within the Grid. This feature is beneficial for performing actions on several cells simultaneously or focusing on specific areas of the data.

To enable multiple cell selection:

- Set the [GridSelectionSettings.Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Mode) property to **Cell**.
- Set the [GridSelectionSettings.Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Type) property to **Multiple**.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" AllowSelection="true" AllowPaging="true">
    <GridSelectionSettings Type="SelectionType.Multiple" Mode="SelectionMode.Cell"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText=" Order Date" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" TextAlign="TextAlign.Right" Width="120" Format="C2"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShippedDate) HeaderText="Shipped Date" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
}

{% endhighlight %}

{% highlight cs tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails() { }
    public OrderDetails(int orderID, string customerId, DateTime orderDate, double freight, DateTime shippedDate, string shipCountry)
    {
        this.OrderID = orderID;
        this.CustomerID = customerId;
        this.OrderDate = orderDate;
        this.Freight = freight;
        this.ShippedDate = shippedDate;
        this.ShipCountry = shipCountry;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", new DateTime(1996, 7, 4), 32.38, new DateTime(1996, 7, 16), "France"));
            order.Add(new OrderDetails(10249, "TOMSP", new DateTime(1996, 7, 5), 11.61, new DateTime(1996, 7, 10), "Germany"));
            order.Add(new OrderDetails(10250, "HANAR", new DateTime(1996, 7, 8), 65.83, new DateTime(1996, 7, 12), "Brazil"));
            order.Add(new OrderDetails(10251, "VICTE", new DateTime(1996, 7, 8), 41.34, new DateTime(1996, 7, 15), "France"));
            order.Add(new OrderDetails(10252, "SUPRD", new DateTime(1996, 7, 9), 51.3, new DateTime(1996, 7, 11), "Belgium"));
            order.Add(new OrderDetails(10253, "HANAR", new DateTime(1996, 7, 10), 58.17, new DateTime(1996, 7, 16), "Brazil"));
            order.Add(new OrderDetails(10254, "CHOPS", new DateTime(1996, 7, 11), 22.98, new DateTime(1996, 7, 23), "Switzerland"));
            order.Add(new OrderDetails(10255, "RICSU", new DateTime(1996, 7, 12), 148.33, new DateTime(1996, 7, 24), "Switzerland"));
            order.Add(new OrderDetails(10256, "WELLI", new DateTime(1996, 7, 15), 13.97, new DateTime(1996, 7, 25), "Brazil"));
            order.Add(new OrderDetails(10257, "HILAA", new DateTime(1996, 7, 16), 81.91, new DateTime(1996, 7, 30), "Venezuela"));
            order.Add(new OrderDetails(10258, "ERNSH", new DateTime(1996, 7, 17), 140.51, new DateTime(1996, 7, 29), "Austria"));
            order.Add(new OrderDetails(10259, "CENTC", new DateTime(1996, 7, 18), 3.25, new DateTime(1996, 7, 31), "Mexico"));
            order.Add(new OrderDetails(10260, "OTTIK", new DateTime(1996, 7, 19), 55.09, new DateTime(1996, 8, 1), "Germany"));
            order.Add(new OrderDetails(10261, "QUEDE", new DateTime(1996, 7, 19), 3.05, new DateTime(1996, 8, 2), "Brazil"));
            order.Add(new OrderDetails(10262, "RATTC", new DateTime(1996, 7, 22), 48.29, new DateTime(1996, 8, 5), "USA"));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime OrderDate { get; set; }
    public double? Freight { get; set; }
    public DateTime ShippedDate { get; set; }
    public string ShipCountry { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNLyWMtQzmNlCgRz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Cell selection mode

The cell selection mode in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid enables interactive selection of specific cells or ranges of cells. This feature is particularly useful for performing actions on selected cells or retrieving data from targeted areas within the Grid.

The Grid supports three types of cell selection modes, configurable via the [GridSelectionSettings.CellSelectionMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_CellSelectionMode) property:

1. **Flow:** This is the default mode. It allows selection of a continuous range of cells between the start and end indexes, including all cells across rows in that range.
2. **Box:** Enables selection of a rectangular range of cells between specified start and end column indexes, including all rows within the defined range. Useful for column-specific selections.
3. **BoxWithBorder:** Similar to Box, but adds a visual border around the selected cell range for easier identification.

Cell selection requires the [GridSelectionSettings.Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Mode) to be set to **Cell** or **Both**, and the [GridSelectionSettings.Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Type) to be **Multiple**.

The following example demonstrates how to dynamically enable and change the `GridSelectionSettings.CellSelectionMode` using a  [DropDownList](https://blazor.syncfusion.com/documentation/dropdown-list/getting-started-with-web-app).

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<div style="display:flex; margin-bottom:5px;">
    <label style="margin: 5px 5px 0 0"> Choose cell selection mode :</label>
    <SfDropDownList TValue="CellSelectionMode" TItem="DropDownOrder" Width="120px" DataSource="@DropDownData" @bind-Value="@CellSelectionModeValue">
        <DropDownListEvents TItem="DropDownOrder" TValue="CellSelectionMode" ValueChange="@ValueChange"></DropDownListEvents>
        <DropDownListFieldSettings Text="Text" Value="Value"></DropDownListFieldSettings>
    </SfDropDownList>
</div>
<SfGrid @ref="Grid" DataSource="@OrderData" AllowSelection="true" Height="315">
    <GridSelectionSettings CellSelectionMode="@CellSelectionModeValue" Type="SelectionType.Multiple" Mode="SelectionMode.Cell"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderDetails> Grid;
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    public CellSelectionMode CellSelectionModeValue { get; set; } = Syncfusion.Blazor.Grids.CellSelectionMode.Box;
    public class DropDownOrder
    {
        public string Text { get; set; }
        public CellSelectionMode Value { get; set; }
    }
    List<DropDownOrder> DropDownData = new List<DropDownOrder>
    {
        new DropDownOrder() { Text = "Box", Value = Syncfusion.Blazor.Grids.CellSelectionMode.Box },
        new DropDownOrder() { Text = "Flow", Value = Syncfusion.Blazor.Grids.CellSelectionMode.Flow},
        new DropDownOrder() { Text = "Box With Border", Value = Syncfusion.Blazor.Grids.CellSelectionMode.BoxWithBorder }
    };
    public void ValueChange(ChangeEventArgs<CellSelectionMode, DropDownOrder> Args)
    {
        CellSelectionModeValue = Args.Value;
        Grid.Refresh();
    }
}

{% endhighlight %}

{% highlight cs tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails() { }
    public OrderDetails(int orderID, string customerId, string shipCity, string shipName)
    {
        this.OrderID = orderID;
        this.CustomerID = customerId;
        this.ShipCity = shipCity;
        this.ShipName = shipName;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", "Reims", "Vins et alcools Chevalier"));
            order.Add(new OrderDetails(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
            order.Add(new OrderDetails(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            order.Add(new OrderDetails(10251, "VICTE", "Lyon", "Victuailles en stock"));
            order.Add(new OrderDetails(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
            order.Add(new OrderDetails(10253, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
            order.Add(new OrderDetails(10254, "CHOPS", "Bern", "Chop-suey Chinese"));
            order.Add(new OrderDetails(10255, "RICSU", "Genève", "Richter Supermarkt"));
            order.Add(new OrderDetails(10256, "WELLI", "Resende", "Wellington Importadora"));
            order.Add(new OrderDetails(10257, "HILAA", "San Cristóbal", "HILARION-Abastos"));
            order.Add(new OrderDetails(10258, "ERNSH", "Graz", "Ernst Handel"));
            order.Add(new OrderDetails(10259, "CENTC", "México D.F.", "Centro comercial Moctezuma"));
            order.Add(new OrderDetails(10260, "OTTIK", "Köln", "Ottilies Käseladen"));
            order.Add(new OrderDetails(10261, "QUEDE", "Rio de Janeiro", "Que Delícia"));
            order.Add(new OrderDetails(10262, "RATTC", "Albuquerque", "Rattlesnake Canyon Grocery"));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCity { get; set; }
    public string ShipName { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjVeDSKXKGvShjyg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Select cells via programmatically

Single cell selection, multiple cell selection, and range-based cell selection can be performed externally in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid using built-in methods. These API's allow programmatic interaction with specific cells in the Grid.

### Single cell selection

To select a single cell programmatically, use the [SelectCellAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SelectCellAsync_System_ValueTuple_System_Int32_System_Int32__System_Nullable_System_Boolean__) method. This method selects a cell based on the specified row and column indexes.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Inputs

<div style="margin-bottom:5px">
    <label style="margin: 5px 5px 0 0"> Enter the row index:</label>
    <SfNumericTextBox TValue="int" @bind-Value="@RowIndexValue" Width="150px"></SfNumericTextBox>
</div>
<div style="margin-bottom:5px">
    <label style="margin: 5px 5px 0 0"> Enter the cell index:</label>
    <SfNumericTextBox TValue="int" @bind-Value="@CellIndexValue" Width="150px"></SfNumericTextBox>
</div>
<div style="margin-bottom:5px">
    <SfButton OnClick="SelectCells">Select Cell</SfButton>
</div>
<SfGrid @ref="Grid" DataSource="@OrderData" AllowSelection="true" Height="315">
    <GridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple" Mode="Syncfusion.Blazor.Grids.SelectionMode.Cell"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderDetails> Grid;
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    public int RowIndexValue;
    public int CellIndexValue;
    public async Task SelectCells()
    {
        await Grid.SelectCellAsync((RowIndexValue, CellIndexValue));
    }
}

{% endhighlight %}

{% highlight cs tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails() { }
    public OrderDetails(int orderID, string customerId, double freight, string shipCountry)
    {
        this.OrderID = orderID;
        this.CustomerID = customerId;
        this.Freight = freight;
        this.ShipCountry = shipCountry;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", 32.38, "France"));
            order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Germany"));
            order.Add(new OrderDetails(10250, "HANAR", 65.83, "Brazil"));
            order.Add(new OrderDetails(10251, "VICTE", 41.34, "France"));
            order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Belgium"));
            order.Add(new OrderDetails(10253, "HANAR", 58.17, "Brazil"));
            order.Add(new OrderDetails(10254, "CHOPS", 22.98, "Switzerland"));
            order.Add(new OrderDetails(10255, "RICSU", 148.33, "Switzerland"));
            order.Add(new OrderDetails(10256, "WELLI", 13.97, "Brazil"));
            order.Add(new OrderDetails(10257, "HILAA", 81.91, "Venezuela"));
            order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Austria"));
            order.Add(new OrderDetails(10259, "CENTC", 3.25, "Mexico"));
            order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Germany"));
            order.Add(new OrderDetails(10261, "QUEDE", 3.05, "Brazil"));
            order.Add(new OrderDetails(10262, "RATTC", 48.29, "USA"));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double? Freight { get; set; }
    public string ShipCountry { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hthojzsefOMTNQRS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Multiple cell selection

Multiple cell selection in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid enables selection of multiple cells within the Grid. This is useful for performing actions on several cells simultaneously or focusing on specific data regions.

To perform multiple cell selection programmatically, use the [SelectCellsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SelectCellsAsync_System_ValueTuple_System_Int32_System_Int32____) method. This method accepts a collection of row and column index pairs to define the target cells.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="padding: 0px 0px 20px 0px">
    <SfButton CssClass="btn" OnClick="() => SelectCell(1, 3)">Select [1, 3]</SfButton>
    <SfButton CssClass="btn" OnClick="() => SelectCell(2, 2)">Select [2, 2]</SfButton>
    <SfButton CssClass="btn" OnClick="() => SelectCell(0, 0)">Select [0, 0]</SfButton>
</div>
<div style="padding: 0px 0px 20px 0px">
    <SfButton CssClass="btn" OnClick="() => SelectCell(4, 2)">Select [4, 2]</SfButton>
    <SfButton CssClass="btn" OnClick="() => SelectCell(5, 1)">Select [5, 1]</SfButton>
    <SfButton CssClass="btn" OnClick="() => SelectCell(3, 3)">Select [3, 3]</SfButton>
</div>
<div style="padding: 0px 0px 20px 0px">
    <SfButton CssClass="btn" OnClick="() => SelectCell(0, 3)">Select [0, 3]</SfButton>
    <SfButton CssClass="btn" OnClick="() => SelectCell(8, 1)">Select [8, 1]</SfButton>
    <SfButton CssClass="btn" OnClick="() => SelectCell(8, 2)">Select [8, 2]</SfButton>
</div>

<SfGrid @ref="Grid" DataSource="@OrderData" AllowSelection="true" Height="315">
    <GridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple" Mode="Syncfusion.Blazor.Grids.SelectionMode.Cell"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderDetails> Grid;
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    public async Task SelectCell(int rowIndex, int columnIndex)
    {
        var selectedCells = new (int, int)[] { (rowIndex, columnIndex) };
        await Grid.SelectCellsAsync(selectedCells);
    }
}

{% endhighlight %}

{% highlight cs tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails() { }
    public OrderDetails(int orderID, string customerId, double freight, string shipCountry)
    {
        this.OrderID = orderID;
        this.CustomerID = customerId;
        this.Freight = freight;
        this.ShipCountry = shipCountry;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", 32.38, "France"));
            order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Germany"));
            order.Add(new OrderDetails(10250, "HANAR", 65.83, "Brazil"));
            order.Add(new OrderDetails(10251, "VICTE", 41.34, "France"));
            order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Belgium"));
            order.Add(new OrderDetails(10253, "HANAR", 58.17, "Brazil"));
            order.Add(new OrderDetails(10254, "CHOPS", 22.98, "Switzerland"));
            order.Add(new OrderDetails(10255, "RICSU", 148.33, "Switzerland"));
            order.Add(new OrderDetails(10256, "WELLI", 13.97, "Brazil"));
            order.Add(new OrderDetails(10257, "HILAA", 81.91, "Venezuela"));
            order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Austria"));
            order.Add(new OrderDetails(10259, "CENTC", 3.25, "Mexico"));
            order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Germany"));
            order.Add(new OrderDetails(10261, "QUEDE", 3.05, "Brazil"));
            order.Add(new OrderDetails(10262, "RATTC", 48.29, "USA"));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double? Freight { get; set; }
    public string ShipCountry { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNLSNfiHBoAvoKVp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> Cell selection requires the [GridSelectionSettings.Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Mode) to be set to **Cell** or **Both**, and the [GridSelectionSettings.Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Type) to be set to **Multiple**.

## Get selected row cell indexes

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides a method to retrieve the collection of selected row and cell indexes for the currently selected cells. This is useful for performing actions or applying logic based on selected cell positions.

To retrieve the selected indexes, use the [GetSelectedRowCellIndexesAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetSelectedRowCellIndexesAsync) method.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Popups

<div style="padding: 0px 0px 20px 0px">
    <SfButton CssClass="btn" OnClick="GetSelectedCellIndexes">Show Selected Cell Indexes</SfButton>
</div>
<SfDialog Width="350px" ShowCloseIcon="true" Header="Selected Cell Indexes" Visible="@DialogVisible">
    <DialogTemplates>
        <Content>
            <div>
                @foreach (var cell in SelectedCellIndexes)
                {
                    <p>Row: @cell.RowIndex, Cell: @cell.CellIndex</p>
                }
            </div>
        </Content>
    </DialogTemplates>
</SfDialog>
<SfGrid @ref="Grid" DataSource="@OrderData" AllowSelection="true" AllowPaging="true">
    <GridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple" Mode="Syncfusion.Blazor.Grids.SelectionMode.Cell"></GridSelectionSettings>
    <GridPageSettings PageSize="5"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderDetails> Grid;
    public List<OrderDetails> OrderData { get; set; }
    private bool DialogVisible { get; set; } = false;
    private List<(int RowIndex, int CellIndex)> SelectedCellIndexes = new();
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    public async Task GetSelectedCellIndexes()
    {
        if (Grid != null)
        {
            SelectedCellIndexes = await Grid.GetSelectedRowCellIndexesAsync();
            if (SelectedCellIndexes.Count > 0)
            {
                DialogVisible = true;
            }
        }
    }
}

{% endhighlight %}

{% highlight cs tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails() { }
    public OrderDetails(int orderID, string customerId, double freight, string shipCountry)
    {
        this.OrderID = orderID;
        this.CustomerID = customerId;
        this.Freight = freight;
        this.ShipCountry = shipCountry;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", 32.38, "France"));
            order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Germany"));
            order.Add(new OrderDetails(10250, "HANAR", 65.83, "Brazil"));
            order.Add(new OrderDetails(10251, "VICTE", 41.34, "France"));
            order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Belgium"));
            order.Add(new OrderDetails(10253, "HANAR", 58.17, "Brazil"));
            order.Add(new OrderDetails(10254, "CHOPS", 22.98, "Switzerland"));
            order.Add(new OrderDetails(10255, "RICSU", 148.33, "Switzerland"));
            order.Add(new OrderDetails(10256, "WELLI", 13.97, "Brazil"));
            order.Add(new OrderDetails(10257, "HILAA", 81.91, "Venezuela"));
            order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Austria"));
            order.Add(new OrderDetails(10259, "CENTC", 3.25, "Mexico"));
            order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Germany"));
            order.Add(new OrderDetails(10261, "QUEDE", 3.05, "Brazil"));
            order.Add(new OrderDetails(10262, "RATTC", 48.29, "USA"));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double? Freight { get; set; }
    public string ShipCountry { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNryZyZyzmehMywJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Clear selection via programmatically

Clearing cell selection programmatically in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid is useful when you need to remove existing cell selections based on user actions or application logic. This can be achieved using the [ClearCellSelectionAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ClearCellSelectionAsync) method.

The `ClearCellSelectionAsync` method is applicable when the [GridSelectionSettings.Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Type) property is set to **Multiple** or **Single**.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="margin-bottom: 10px">
    <SfButton CssClass="btn" OnClick="ClearCellSelection">Clear Cell Selection</SfButton>
</div>
<SfGrid @ref="Grid" DataSource="@OrderData" AllowSelection="true" AllowPaging="true">
    <GridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple" Mode="Syncfusion.Blazor.Grids.SelectionMode.Cell"></GridSelectionSettings>
    <GridPageSettings PageSize="5"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderDetails> Grid;
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    public async Task ClearCellSelection()
    {
       await Grid.ClearCellSelectionAsync();        
    }
}

{% endhighlight %}

{% highlight cs tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails() { }
    public OrderDetails(int orderID, string customerId, double freight, string shipCountry)
    {
        this.OrderID = orderID;
        this.CustomerID = customerId;
        this.Freight = freight;
        this.ShipCountry = shipCountry;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", 32.38, "France"));
            order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Germany"));
            order.Add(new OrderDetails(10250, "HANAR", 65.83, "Brazil"));
            order.Add(new OrderDetails(10251, "VICTE", 41.34, "France"));
            order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Belgium"));
            order.Add(new OrderDetails(10253, "HANAR", 58.17, "Brazil"));
            order.Add(new OrderDetails(10254, "CHOPS", 22.98, "Switzerland"));
            order.Add(new OrderDetails(10255, "RICSU", 148.33, "Switzerland"));
            order.Add(new OrderDetails(10256, "WELLI", 13.97, "Brazil"));
            order.Add(new OrderDetails(10257, "HILAA", 81.91, "Venezuela"));
            order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Austria"));
            order.Add(new OrderDetails(10259, "CENTC", 3.25, "Mexico"));
            order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Germany"));
            order.Add(new OrderDetails(10261, "QUEDE", 3.05, "Brazil"));
            order.Add(new OrderDetails(10262, "RATTC", 48.29, "USA"));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double? Freight { get; set; }
    public string ShipCountry { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXhStItSpmRvIpIy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Cell selection events

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides multiple events to customize and respond to cell selection behavior. These events allow developers to implement validation, control selection flow, and trigger actions based on user interaction.

* [CellSelecting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_CellSelecting): Triggered before a cell is selected. Use this event to implement custom logic or validation to control whether the cell should be selected.

* [CellSelected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_CellSelected): Triggered after a cell is successfully selected. This event is useful for executing actions or updating UI elements based on the selected cell.

* [CellDeselecting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_CellDeselecting): Triggered before a selected cell is deselected. Use this event to apply validation or logic to determine whether the deselection should proceed.

* [CellDeselected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_CellDeselected): Triggered after a selected cell is deselected. This event can be used to perform actions or cleanup tasks when a cell is no longer selected.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<div style="text-align: center; color: red">
    <span>@CellSelectionMessage</span>
</div>
<SfGrid @ref="Grid" DataSource="@OrderData" AllowSelection="true" Height="315">
    <GridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple" Mode="Syncfusion.Blazor.Grids.SelectionMode.Cell"></GridSelectionSettings>
    <GridEvents CellSelected="CellselectHandler" CellSelecting="CellselectingHandler" CellDeselected="CellDeselectHandler" CellDeselecting="CellDeselectingHandler" TValue="OrderDetails"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderDetails> Grid;
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    public string CellSelectionMessage;
    public void CellselectingHandler(CellSelectingEventArgs<OrderDetails> Args)
    {
        if (Args.Data.ShipCountry == "France")
        {
            Args.Cancel = true;
            CellSelectionMessage = "CellSelecting event triggered. Selection prevented for ShipCountry column France value.";
        }
    }
    public void CellselectHandler(CellSelectEventArgs<OrderDetails> Args)
    {
        CellSelectionMessage = "CellSelected triggered.";
    }
    public void CellDeselectingHandler(CellDeselectEventArgs<OrderDetails> Args)
    {
        if (Args.Data.OrderID % 2 == 0)
        {
            Args.Cancel = true;
            CellSelectionMessage = "CellDeselecting event triggered. Deselection prevented for OrderID column even values.";
        }
    }
    public void CellDeselectHandler(CellDeselectEventArgs<OrderDetails> Args)
    {
        CellSelectionMessage = "CellDeselected triggered.";        
    }
}

{% endhighlight %}

{% highlight cs tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails() { }
    public OrderDetails(int orderID, string customerId, double freight, string shipCountry)
    {
        this.OrderID = orderID;
        this.CustomerID = customerId;
        this.Freight = freight;
        this.ShipCountry = shipCountry;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", 32.38, "France"));
            order.Add(new OrderDetails(10249, "TOMSP", 11.61, "Germany"));
            order.Add(new OrderDetails(10250, "HANAR", 65.83, "Brazil"));
            order.Add(new OrderDetails(10251, "VICTE", 41.34, "France"));
            order.Add(new OrderDetails(10252, "SUPRD", 51.3, "Belgium"));
            order.Add(new OrderDetails(10253, "HANAR", 58.17, "Brazil"));
            order.Add(new OrderDetails(10254, "CHOPS", 22.98, "Switzerland"));
            order.Add(new OrderDetails(10255, "RICSU", 148.33, "Switzerland"));
            order.Add(new OrderDetails(10256, "WELLI", 13.97, "Brazil"));
            order.Add(new OrderDetails(10257, "HILAA", 81.91, "Venezuela"));
            order.Add(new OrderDetails(10258, "ERNSH", 140.51, "Austria"));
            order.Add(new OrderDetails(10259, "CENTC", 3.25, "Mexico"));
            order.Add(new OrderDetails(10260, "OTTIK", 55.09, "Germany"));
            order.Add(new OrderDetails(10261, "QUEDE", 3.05, "Brazil"));
            order.Add(new OrderDetails(10262, "RATTC", 48.29, "USA"));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double? Freight { get; set; }
    public string ShipCountry { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDLeCWtmyXmWvtqM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
