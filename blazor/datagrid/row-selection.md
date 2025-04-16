---
layout: post
title: Row selection in Blazor DataGrid | Syncfusion
description: Checkout and learn here all about Row selection in Syncfusion Blazor DataGrid and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Row selection in Blazor DataGrid

Row selection in the Grid allows you to interactively select specific rows or ranges of rows within the Grid. This selection can be done effortlessly through mouse clicks or arrow keys (up, down, left, and right). This feature is useful when you want to highlight, manipulate, or perform actions on specific row within the Grid.

> To enable row selection, set the [GridSelectionSettings.Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Mode) property to either **Row** or **Both**. This property determines the selection mode of the Grid.

## Single row selection 

Single row selection allows you to select a single row at a time within the Grid. This feature is useful when you want to focus on specific rows or perform actions on the data within a particular row.

To enable single row selection, set the [GridSelectionSettings.Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Mode) property to **Row** and the [GridSelectionSettings.Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Type) property to **Single**. This configuration allows you to select a only one row at a time within the grid.

Here's an example of how to enable single row selection using properties:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" AllowSelection="true">
    <GridSelectionSettings Mode="SelectionMode.Row" Type="SelectionType.Single"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShippedDate) HeaderText="Shipped Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="150"></GridColumn>
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

{% highlight c# tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails() { }
    public OrderDetails(int orderID, string customerId, string shipCountry, double freight, DateTime orderDate, DateTime shippedDate)
    {
        this.OrderID = orderID;
        this.CustomerID = customerId;
        this.ShipCountry = shipCountry;
        this.Freight = freight;
        this.OrderDate = orderDate;
        this.ShippedDate = shippedDate;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", "France", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 7, 16)));
            order.Add(new OrderDetails(10249, "TOMSP", "Germany", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 7, 10)));
            order.Add(new OrderDetails(10250, "HANAR", "Brazil", 65.83, new DateTime(1996, 7, 8), new DateTime(1996, 7, 12)));
            order.Add(new OrderDetails(10251, "VICTE", "France", 41.34, new DateTime(1996, 7, 8), new DateTime(1996, 7, 15)));
            order.Add(new OrderDetails(10252, "SUPRD", "Belgium", 51.3, new DateTime(1996, 7, 9), new DateTime(1996, 7, 11)));
            order.Add(new OrderDetails(10253, "HANAR", "Brazil", 58.17, new DateTime(1996, 7, 10), new DateTime(1996, 7, 16)));
            order.Add(new OrderDetails(10254, "CHOPS", "Switzerland", 22.98, new DateTime(1996, 7, 11), new DateTime(1996, 7, 23)));
            order.Add(new OrderDetails(10255, "RICSU", "Switzerland", 148.33, new DateTime(1996, 7, 12), new DateTime(1996, 7, 24)));
            order.Add(new OrderDetails(10256, "WELLI", "Brazil", 13.97, new DateTime(1996, 7, 15), new DateTime(1996, 7, 25)));
            order.Add(new OrderDetails(10257, "HILAA", "Venezuela", 81.91, new DateTime(1996, 7, 16), new DateTime(1996, 7, 30)));
            order.Add(new OrderDetails(10258, "ERNSH", "Austria", 140.51, new DateTime(1996, 7, 17), new DateTime(1996, 7, 29)));
            order.Add(new OrderDetails(10259, "CENTC", "Mexico", 3.25, new DateTime(1996, 7, 18), new DateTime(1996, 7, 31)));
            order.Add(new OrderDetails(10260, "OTTIK", "Germany", 55.09, new DateTime(1996, 7, 19), new DateTime(1996, 8, 1)));
            order.Add(new OrderDetails(10261, "QUEDE", "Brazil", 3.05, new DateTime(1996, 7, 19), new DateTime(1996, 8, 2)));
            order.Add(new OrderDetails(10262, "RATTC", "USA", 48.29, new DateTime(1996, 7, 22), new DateTime(1996, 8, 5)));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCountry { get; set; }
    public double Freight { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime ShippedDate { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZLSXBNpsPDFTpMg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Multiple row selection 

Multiple row selection allows you to select multiple rows within the Grid. This feature is valuable when you need to perform actions on several rows simultaneously or focus on specific data areas.

To enable multiple row selection, set the [GridSelectionSettings.Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Mode) property to **Row** and the [GridSelectionSettings.Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Type) property to **Multiple**. This configuration allows you to select a multiple rows at a time within the Grid.

Here's an example of how to enable multiple rows selection using properties:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" AllowSelection="true">
    <GridSelectionSettings Mode="SelectionMode.Row" Type="SelectionType.Multiple"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShippedDate) HeaderText="Shipped Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="150"></GridColumn>
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

{% highlight c# tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails() { }
    public OrderDetails(int orderID, string customerId, string shipCountry, double freight, DateTime orderDate, DateTime shippedDate)
    {
        this.OrderID = orderID;
        this.CustomerID = customerId;
        this.ShipCountry = shipCountry;
        this.Freight = freight;
        this.OrderDate = orderDate;
        this.ShippedDate = shippedDate;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", "France", 32.38, new DateTime(1996, 7, 4), new DateTime(1996, 7, 16)));
            order.Add(new OrderDetails(10249, "TOMSP", "Germany", 11.61, new DateTime(1996, 7, 5), new DateTime(1996, 7, 10)));
            order.Add(new OrderDetails(10250, "HANAR", "Brazil", 65.83, new DateTime(1996, 7, 8), new DateTime(1996, 7, 12)));
            order.Add(new OrderDetails(10251, "VICTE", "France", 41.34, new DateTime(1996, 7, 8), new DateTime(1996, 7, 15)));
            order.Add(new OrderDetails(10252, "SUPRD", "Belgium", 51.3, new DateTime(1996, 7, 9), new DateTime(1996, 7, 11)));
            order.Add(new OrderDetails(10253, "HANAR", "Brazil", 58.17, new DateTime(1996, 7, 10), new DateTime(1996, 7, 16)));
            order.Add(new OrderDetails(10254, "CHOPS", "Switzerland", 22.98, new DateTime(1996, 7, 11), new DateTime(1996, 7, 23)));
            order.Add(new OrderDetails(10255, "RICSU", "Switzerland", 148.33, new DateTime(1996, 7, 12), new DateTime(1996, 7, 24)));
            order.Add(new OrderDetails(10256, "WELLI", "Brazil", 13.97, new DateTime(1996, 7, 15), new DateTime(1996, 7, 25)));
            order.Add(new OrderDetails(10257, "HILAA", "Venezuela", 81.91, new DateTime(1996, 7, 16), new DateTime(1996, 7, 30)));
            order.Add(new OrderDetails(10258, "ERNSH", "Austria", 140.51, new DateTime(1996, 7, 17), new DateTime(1996, 7, 29)));
            order.Add(new OrderDetails(10259, "CENTC", "Mexico", 3.25, new DateTime(1996, 7, 18), new DateTime(1996, 7, 31)));
            order.Add(new OrderDetails(10260, "OTTIK", "Germany", 55.09, new DateTime(1996, 7, 19), new DateTime(1996, 8, 1)));
            order.Add(new OrderDetails(10261, "QUEDE", "Brazil", 3.05, new DateTime(1996, 7, 19), new DateTime(1996, 8, 2)));
            order.Add(new OrderDetails(10262, "RATTC", "USA", 48.29, new DateTime(1996, 7, 22), new DateTime(1996, 8, 5)));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public string ShipCountry { get; set; }
    public double Freight { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime ShippedDate { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjVIXBNJCPSpibPz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Select row at initial rendering 

You can select a specific row during the initial rendering of the Grid. This feature is particularly useful when you want to highlight or pre-select a specific row in the Grid. To achieve this, use the [SelectedRowIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SelectedRowIndex) property provided by the Grid.

The following example demonstrates how to select a row during the initial rendering:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" AllowSelection="true" SelectedRowIndex="1">
    <GridSelectionSettings Mode="SelectionMode.Row" Type="SelectionType.Multiple"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipName) HeaderText="Ship Name" Width="150"></GridColumn>
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

{% highlight c# tabtitle="OrderDetails.cs" %}

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXVStrjfsuosZEoz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Multiple row selection by single click on row 

The DataGrid allows you to perform multiple row selections by simply clicking on rows one by one without pressing the CTRL or SHIFT keys. This means that when you click on a row, it will be selected, and clicking on another row will add it to the selection without deselecting the previously selected rows. To deselect a previously selected row, you can click on the row again, and it will be unselected.

To enable simple multiple row selection, you need to set the [GridSelectionSettings.EnableSimpleMultiRowSelection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_EnableSimpleMultiRowSelection) property to **true**.

The following example demonstrates how to enable multiple row selection with a single click on the Grid row using the `EnableSimpleMultiRowSelection` property:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="display:flex;gap: 5px; margin-bottom:5px">
    <label >Enable/Disable simple multiple row selection</label>
    <SfSwitch ValueChange="toggleRowSelection" TChecked="bool"></SfSwitch>
</div>
<SfGrid @ref="Grid" DataSource="@OrderData" AllowSelection="true" Height="315">
    <GridSelectionSettings EnableSimpleMultiRowSelection="@SimpleMultiRowSelectionValue" Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderDetails> Grid;
    public bool SimpleMultiRowSelectionValue { get; set; }
    public List<OrderDetails> OrderData { get; set; }

    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    private void toggleRowSelection(Syncfusion.Blazor.Buttons.ChangeEventArgs<bool> args)
    {
        SimpleMultiRowSelectionValue = args.Checked;
        Grid.Refresh();
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderDetails.cs" %}

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNrIjfWoTqSCQLJr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Select rows externally 

You can perform single row selection, multiple row selection, and a range of row selection externally in a Grid using built-in methods. This feature allows you to interact with specific rows within the Grid. The following topic demonstrates how you can achieve these selections using methods.

### Single row selection

Single row selection allows you to select a single row at a time within the Grid. This feature is useful when you want to focus on specific rows or perform actions on the data within a particular row.

To achieve single row selection, you can use the [SelectRowAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SelectRowAsync_System_Int32_System_Nullable_System_Boolean__) method. This method allows you to programmatically select a specific row within the Grid by specifying its index.

The following example demonstrates how to select a single row within the Grid by obtaining the selected row index through a textbox and passing this row index as an argument to the `SelectRowAsync` method. When the button event is triggered by clicking the **Select Row** button, a single row is selected within the Grid:

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
    <SfButton OnClick="SelectRow">Select Row</SfButton>
</div>
<SfGrid @ref="Grid" DataSource="@OrderData" AllowSelection="true" Height="315">
    <GridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple" Mode="Syncfusion.Blazor.Grids.SelectionMode.Row"></GridSelectionSettings>
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
    public async Task SelectRow()
    {
        await Grid.SelectRowAsync(RowIndexValue);
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LthetJCezkFWiJjM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Range of rows selection 

Range of row selection in the Grid enables you to select a continuous range of rows within the grid. This feature is particularly useful when you want to perform actions on multiple rows simultaneously or focus on a specific range of data.

To achieve range of row selection, you can use the [selectRowsByRange](https://ej2.syncfusion.com/angular/documentation/api/grid/selection/#selectcolumnsbyrange) method. This method selects a range of rows from start and end row indexes.
 
The following example, demonstrates how to select a range of rows within the Grid by obtaining the selected rows start index and end index through textbox. Then, pass these start index and end index as arguments to the `selectRowsByRange` method. When you trigger the button event by clicking the **Select Rows** button, a range of rows is selected within the Grid.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Inputs

<div style="margin-bottom:5px">
    <label style="margin: 5px 5px 0 0"> Enter the start row index:</label>
    <SfNumericTextBox TValue="int" @bind-Value="@StartRowIndexValue" Width="150px"></SfNumericTextBox>
</div>
<div style="margin-bottom:5px">
    <label style="margin: 5px 5px 0 0"> Enter the end row index:</label>
    <SfNumericTextBox TValue="int" @bind-Value="@EndRowIndexValue" Width="150px"></SfNumericTextBox>
</div>
<div style="margin-bottom:5px">
    <SfButton OnClick="SelectRows">Select Rows</SfButton>
</div>
<SfGrid @ref="Grid" DataSource="@OrderData" AllowSelection="true" Height="315">
    <GridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple" Mode="Syncfusion.Blazor.Grids.SelectionMode.Row"></GridSelectionSettings>
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
    public int StartRowIndexValue;
    public int EndRowIndexValue;
    public async Task SelectRows()
    {
        await Grid.SelectRowsByRangeAsync(StartRowIndexValue, EndRowIndexValue);
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNhINfiIdMXhvlal?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}