---
layout: post
title: Row selection in Blazor DataGrid | Syncfusion
description: Learn how to use row selection in Syncfusion Blazor DataGrid including single/multiple selection, paging, initial selection, and programmatic control.
platform: Blazor
control: DataGrid
documentation: ug
---

# Row Selection in Blazor DataGrid

Row selection in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid enables interactive selection of individual rows or ranges of rows. Selection can be performed using mouse clicks or keyboard navigation (arrow keys). This feature is useful for highlighting, manipulating, or performing actions on specific rows within the grid.

> To enable row selection, set the [GridSelectionSettings.Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Mode) property to **Row** or **Both**. This property determines the selection mode of the grid.

## Single row selection

Single row selection in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid enables selection of one row at a time. This feature is useful for focusing on specific rows or performing actions on the data within a particular row.

To enable single row selection, set the [GridSelectionSettings.Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Mode) property to **Row** and the [GridSelectionSettings.Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Type)  property to **Single**. This configuration allows only one row to be selected at a time.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" AllowPaging="true" AllowSelection="true">
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

{% highlight cs tabtitle="OrderDetails.cs" %}

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtBeNytTxjBLpwCY?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Multiple row selection

Multiple row selection in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows selection of multiple rows within the grid. This feature is valuable when actions need to be performed on several rows simultaneously or when focusing on specific data segments.

To enable multiple row selection, set the [GridSelectionSettings.Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Mode)  property to **Row** and the [GridSelectionSettings.Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Type) property to **Multiple**. This configuration allows multiple rows to be selected at a time.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" AllowPaging="true" AllowSelection="true">
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

{% highlight cs tabtitle="OrderDetails.cs" %}

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BthIjeZfHjHdCEwD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Select row at initial rendering

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows selection of a specific row during the initial rendering of the grid. This feature is useful for highlighting or pre-selecting a particular row when the grid loads. To achieve this, use the [SelectedRowIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SelectedRowIndex) property.
The following example demonstrates how to select a row during the initial rendering:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@OrderData" AllowSelection="true" SelectedRowIndex="1" Height="315">
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BtroXSZfRWMkkcaW?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Select rows in any page based on index value

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows selection of rows across different pages based on their index value. This feature is useful for performing actions such as highlighting, styling, or executing operations on rows regardless of their location within the paginated grid.

To achieve this, use the [SelectRowsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SelectRowAsync_System_Int32_System_Nullable_System_Boolean__System_Boolean_) method with the `selectAcrossPages` parameter set to true. This enables row selection across different pages. By handling the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_ValueChange) event of [DropDownList](https://blazor.syncfusion.com/documentation/dropdown-list/getting-started-with-web-app), logic can be implemented to navigate to the desired page and select the row based on its index.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<div style="display:flex; margin-bottom:5px;">
    <label style="margin: 5px 5px 0 0"> Select Row :</label>
    <SfDropDownList TValue="int" TItem="DropDownOrder" Width="150px" Placeholder="Select Row Index" DataSource="@DropDownData">
        <DropDownListEvents TItem="DropDownOrder" TValue="int" ValueChange="@ValueChange"></DropDownListEvents>
        <DropDownListFieldSettings Text="Text" Value="Value"></DropDownListFieldSettings>
    </SfDropDownList>
</div>
<SfGrid @ref="Grid" DataSource="@Orders" AllowSelection="true" AllowPaging="true" Height="315">
    <GridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple" Mode="Syncfusion.Blazor.Grids.SelectionMode.Row"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" Width="120"></GridColumn> 
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<Order> Grid;
    public List<Order> Orders { get; set; }
    protected override void OnInitialized()
    {
        Orders = Order.GetAllRecords();
    }
    public class DropDownOrder
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
    private List<DropDownOrder> DropDownData = new()
    {
        new() { Text = "1", Value = "1" },
        new() { Text = "2", Value = "2" },
        new() { Text = "30", Value = "30" },
        new() { Text = "80", Value = "80" },
        new() { Text = "110", Value = "110" },
        new() { Text = "120", Value = "120" },
        new() { Text = "210", Value = "210" },
        new() { Text = "310", Value = "310" },
        new() { Text = "410", Value = "410" },
        new() { Text = "230", Value = "230" }
    };
    private async Task ValueChange(ChangeEventArgs<int, DropDownOrder> Args)
    {
        int seletedrowIndex = Args.Value-1;
        await Grid.SelectRowAsync(seletedrowIndex, selectAcrossPages: true);        
    }    
}

{% endhighlight %}

{% highlight cs tabtitle="Order.cs" %}

public class Order
{
    public static List<Order> Orders = new List<Order>();
    public Order() { }
    public Order(int orderID, string customerID, double freight, DateTime orderDate, string shipCountry)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.Freight = freight;
        this.OrderDate = orderDate;
        this.ShipCountry = shipCountry;
    }
    public static List<Order> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            string[] customerIDs = { "VINET", "TOMSP", "HANAR", "SUPRD", "CHOPS", "RATTC", "ERNSH", "FOLKO", "BLONP", "WARTH" };
            string[] countries = { "France", "Germany", "Brazil", "Belgium", "Switzerland", "USA", "Canada", "Mexico", "Italy", "UK" };
            Random rand = new Random();
            DateTime startDate = new DateTime(2020, 1, 1);
            for (int i = 0; i < 500; i++)
            {
                int orderId = 10248 + i;
                string customerId = customerIDs[rand.Next(customerIDs.Length)];
                double freight = Math.Round(rand.NextDouble() * 500, 2); 
                DateTime orderDate = startDate.AddDays(rand.Next(0, 1000));
                string shipCountry = countries[rand.Next(countries.Length)];
                Orders.Add(new Order(orderId, customerId, freight, orderDate, shipCountry));
            }
        }
        return Orders;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public DateTime OrderDate { get; set; }
    public string ShipCountry { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjBHZWBkhogLsJDN?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Multiple row selection by single click on row

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows multiple row selection by clicking on rows individually, without using the **Ctrl** or **Shift** keys. When a row is clicked, it is added to the selection. Clicking another row adds it to the selection without deselecting previously selected rows. To deselect a row, click on it again.

To enable simple multiple row selection, set the [GridSelectionSettings.EnableSimpleMultiRowSelection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_EnableSimpleMultiRowSelection) property to **true**.

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNrIjfWoTqSCQLJr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Select row via programmatically

Single row selection, multiple row selection, and range selection can be performed externally in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid using built-in methods. This feature enables interaction with specific rows programmatically.

### Single row selection

Single row selection in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows selection of one row at a time. This is useful for focusing on specific rows or performing actions on the data within a particular row.

To achieve single row selection, use the [SelectRowAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SelectRowAsync_System_Int32_System_Nullable_System_Boolean__) method. This method allows programmatic selection of a specific row by specifying its index.

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

### Multiple rows selection

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows selection of multiple rows simultaneously. This feature is valuable when actions or operations need to be performed on several rows at once or when focusing on specific areas of data.

To achieve multiple row selection, use the [SelectRowsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SelectRowsAsync_System_Int32___) method. This method enables selection of a collection of rows by specifying their indexes, allowing interaction with multiple rows together.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="padding: 10px 0px 20px 0px">
    <SfButton CssClass="btn" OnClick="() => SelectMultipleRows(new[] { 1,3 })">Select [1, 3]</SfButton>
    <SfButton CssClass="btn" OnClick="() => SelectMultipleRows(new[] { 0, 2 })">Select [0, 2]</SfButton>
    <SfButton CssClass="btn" OnClick="() => SelectMultipleRows(new[] { 2, 4 })">Select [2, 4]</SfButton>
    <SfButton CssClass="btn" OnClick="() => SelectMultipleRows(new[] { 0, 5 })">Select [0, 5]</SfButton>
    <SfButton CssClass="btn" OnClick="() => SelectMultipleRows(new[] { 1, 6 })">Select [1, 6]</SfButton>
</div>
<div style="padding: 10px 0px 20px 0px">
    <SfButton CssClass="btn" OnClick="() => SelectMultipleRows(new[] { 0, 7, 8 })">Select [0, 7, 8]</SfButton>
    <SfButton CssClass="btn" OnClick="() => SelectMultipleRows(new[] { 1, 9, 10 })">Select [1, 9, 10]</SfButton>
    <SfButton CssClass="btn" OnClick="() => SelectMultipleRows(new[] { 4, 7, 12 })">Select [4, 7, 12]</SfButton>
    <SfButton CssClass="btn" OnClick="() => SelectMultipleRows(new[] { 2, 5, 6 })">Select [2, 5, 6]</SfButton>
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
    public async Task SelectMultipleRows(int[] rowIndexes)
    {
        await Grid.SelectRowsAsync(rowIndexes);
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXBejJCxVytqWHSm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Range of rows selection

Range selection in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid enables selection of a continuous set of rows within the grid. This feature is useful for performing actions on multiple rows simultaneously or focusing on a specific range of data.

To achieve range selection, use the [SelectRowsByRangeAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SelectRowsByRangeAsync_System_Int32_System_Nullable_System_Int32__) method. This method selects rows between the specified start and end indexes.

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

## Select Grid rows based on certain condition

Specific rows in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid can be programmatically selected based on custom conditions. This feature is useful for dynamically highlighting or manipulating rows based on data-driven logic.
To implement conditional row selection, use the [SelectRowsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SelectRowsAsync_System_Int32___) method within the DataBound event of the grid.

The [GetCurrentViewRecords](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetCurrentViewRecordsAsync)  method is used to retrieve the current page records. A condition is applied to these records, and rows that meet the condition are selected during initial rendering.

In the following example, rows are selected only when the **EmployeeID** column value is greater than **3**.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@OrderData" AllowSelection="true" AllowPaging="true" Height="315">
    <GridSelectionSettings Type="SelectionType.Multiple"></GridSelectionSettings>
    <GridEvents DataBound="DataBound" TValue="OrderDetails"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.EmployeeID) HeaderText="Employee ID" Width="100" TextAlign="TextAlign.Right" />
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" Type="ColumnType.Date" Format="yMd" Width="110" TextAlign="TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" Width="100" TextAlign="TextAlign.Right"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderDetails> Grid;
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    public List<int> SelectIndex { get; set; }
    public async Task DataBound()
    {
        var currentViewData = await Grid.GetCurrentViewRecordsAsync();
        var indexNum = 0;
        SelectIndex = new List<int>();
        foreach (var record in currentViewData)
        {
            if (record.EmployeeID > 3)
            {
                SelectIndex.Add(indexNum);
            }
            indexNum++;
        }
        await Grid.SelectRowsAsync(SelectIndex.ToArray());
    }
}

{% endhighlight %}

{% highlight cs tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();

    public OrderDetails() { }

    public OrderDetails(int orderID, string customerId, int employeeId, DateTime orderDate, double freight)
    {
        this.OrderID = orderID;
        this.CustomerID = customerId;
        this.EmployeeID = employeeId;
        this.OrderDate = orderDate;
        this.Freight = freight;
    }

    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", 5, new DateTime(1996, 7, 4), 32.38));
            order.Add(new OrderDetails(10249, "TOMSP", 6, new DateTime(1996, 7, 5), 11.61));
            order.Add(new OrderDetails(10250, "HANAR", 4, new DateTime(1996, 7, 8), 65.83));
            order.Add(new OrderDetails(10251, "VICTE", 3, new DateTime(1996, 7, 8), 41.34));
            order.Add(new OrderDetails(10252, "SUPRD", 4, new DateTime(1996, 7, 9), 51.3));
            order.Add(new OrderDetails(10253, "HANAR", 3, new DateTime(1996, 7, 10), 58.17));
            order.Add(new OrderDetails(10254, "CHOPS", 5, new DateTime(1996, 7, 11), 22.98));
            order.Add(new OrderDetails(10255, "RICSU", 9, new DateTime(1996, 7, 12), 148.33));
            order.Add(new OrderDetails(10256, "WELLI", 3, new DateTime(1996, 7, 15), 13.97));
            order.Add(new OrderDetails(10257, "HILAA", 4, new DateTime(1996, 7, 16), 81.91));
            order.Add(new OrderDetails(10258, "ERNSH", 1, new DateTime(1996, 7, 17), 140.51));
            order.Add(new OrderDetails(10259, "CENTC", 4, new DateTime(1996, 7, 18), 3.25));
            order.Add(new OrderDetails(10260, "OTTIK", 4, new DateTime(1996, 7, 19), 55.09));
            order.Add(new OrderDetails(10261, "QUEDE", 4, new DateTime(1996, 7, 19), 3.05));
            order.Add(new OrderDetails(10262, "RATTC", 8, new DateTime(1996, 7, 22), 48.29));
        }
        return order;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public int EmployeeID { get; set; }
    public DateTime OrderDate { get; set; }
    public double Freight { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtVeXIjeIHNkaocG?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## How to get selected row indexes 

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows retrieval of the indexes of currently selected rows. This feature is useful when performing actions or operations specifically on selected rows.

To achieve this, use the [GetSelectedRowIndexesAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetSelectedRowIndexesAsync) method. It returns an array of numbers representing the indexes of the selected rows.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="padding: 10px 0px 20px 0px">
    <SfButton CssClass="btn" OnClick="GetSelectedRowIndexes">Get selected row indexes</SfButton>
</div>
@if (ShowMessage)
{
    <p id="message">Selected row indexes: @string.Join(", ", SelectedRowIndexes)</p>
}
<SfGrid @ref="Grid" DataSource="@OrderData" AllowSelection="true" Height="315">
    <GridSelectionSettings Mode="Syncfusion.Blazor.Grids.SelectionMode.Row" Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipName) HeaderText="Ship Name" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderDetails> Grid;
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    private List<int> SelectedRowIndexes = new();
    private bool ShowMessage = false;
    public async Task GetSelectedRowIndexes()
    {
        if (Grid != null)
        {
            SelectedRowIndexes = await Grid.GetSelectedRowIndexesAsync();
            ShowMessage = SelectedRowIndexes.Count > 0;
        }
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNVSXojzHLZfAtKS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## How to get selected records on various pages 

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows retrieval of selected records even when navigating to different pages. This feature is useful when working with large datasets and enables actions to be performed on selected records across multiple pages.

To persist selection across pages, enable the [PersistSelection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_PersistSelection) property. By default, this property is set to **false**. To enable it, set the value to **true** in the [GridSelectionSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html) configuration.

To retrieve selected records from different pages, use the [GetSelectedRecordsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetSelectedRecordsAsync) method. This method returns an array of selected records.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Popups

<div style="margin-bottom: 10px">
    <SfButton OnClick="ShowSelectedRecords">Show Selected Records</SfButton>
</div>
<SfDialog Visible="@DialogVisible" Width="50%" ShowCloseIcon="true" Header="Selected Row Details">
    <DialogTemplates>
        <Content>
            @if (selectedRecords != null)
            {
                @foreach (var record in selectedRecords)
                {
                    <p><b>Order ID:</b>@record.OrderID</p>
                }                
            }
        </Content>
    </DialogTemplates>
</SfDialog>
<SfGrid @ref="Grid" DataSource="@OrderData" AllowSelection="true" AllowPaging="true">
    <GridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple" Mode="Syncfusion.Blazor.Grids.SelectionMode.Row" PersistSelection="true"></GridSelectionSettings>
    <GridPageSettings PageSize="5"></GridPageSettings>
    <GridColumns>
        <GridColumn Type="ColumnType.CheckBox" Width="50"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderDetails> Grid;
    public List<OrderDetails> OrderData { get; set; }
    private List<OrderDetails> selectedRecords;
    private bool DialogVisible { get; set; } = false;
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    private async Task ShowSelectedRecords()
    {
        selectedRecords = await Grid.GetSelectedRecordsAsync();
        DialogVisible = true;
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
            string[] customerIds = { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD", "CHOPS", "RICSU", "WELLI", "HILAA", "ERNSH" };
            string[] countries = { "France", "Germany", "Brazil", "USA", "Sweden", "Venezuela", "Mexico", "Austria", "Finland", "UK" };
            Random rand = new Random();
            for (int i = 1; i <= 50; i++)
            {
                int orderId = 10247 + i;
                string customerId = customerIds[rand.Next(customerIds.Length)];
                double freight = Math.Round(rand.NextDouble() * 200, 2); 
                string country = countries[rand.Next(countries.Length)];
                order.Add(new OrderDetails(orderId, customerId, freight, country));
            }
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjLyNotfnVyUShmR?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> To persist the Grid selection, it is necessary to define any one of the columns as a primary key using the [GridColumn.IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsPrimaryKey) property.

## How to get selected records  

The get selected records feature in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid allows retrieval of data from selected rows. This is useful when performing actions on selected data or displaying specific information based on selected rows.

To retrieve the selected records, use the [GetSelectedRecordsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetSelectedRecordsAsync) method. This method returns an array of objects representing the selected records.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="padding: 10px 0px 20px 0px">
    <SfButton CssClass="btn" OnClick="SelectedRecordsCount">Selected Records count</SfButton>
</div>
@if (ShowMessage)
{
    <p id="message">Selected record count: @string.Join(", ", SelectedRecordscount.Count)</p>
}
<SfGrid @ref="Grid" DataSource="@OrderData" AllowPaging="true" AllowSelection="true">
    <GridSelectionSettings Mode="Syncfusion.Blazor.Grids.SelectionMode.Row" Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText="Order Date" Format="d" TextAlign="TextAlign.Right" Width="130"></GridColumn>
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
    private List<OrderDetails> SelectedRecordscount = new();
    private bool ShowMessage = false;
    public async Task SelectedRecordsCount()
    {
        if (Grid != null)
        {
            SelectedRecordscount = await Grid.GetSelectedRecordsAsync();
            ShowMessage = SelectedRecordscount.Count > 0;
        }
    }
}
<style>
    #message {
        color: red;
        text-align: center;
        padding: 0px 0px 10px 0px;
    }
</style>

{% endhighlight %}

{% highlight cs tabtitle="OrderDetails.cs" %}

public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails() { }
    public OrderDetails(int orderID, string customerId, DateTime orderDate, double freight, string shipCountry)
    {
        this.OrderID = orderID;
        this.CustomerID = customerId;
        this.OrderDate = orderDate;
        this.Freight = freight;
        this.ShipCountry = shipCountry;
    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET", new DateTime(1996, 7, 4), 32.38, "France"));
            order.Add(new OrderDetails(10249, "TOMSP", new DateTime(1996, 7, 5), 11.61, "Germany"));
            order.Add(new OrderDetails(10250, "HANAR", new DateTime(1996, 7, 8), 65.83, "Brazil"));
            order.Add(new OrderDetails(10251, "VICTE", new DateTime(1996, 7, 8), 41.34, "France"));
            order.Add(new OrderDetails(10252, "SUPRD", new DateTime(1996, 7, 9), 51.3, "Belgium"));
            order.Add(new OrderDetails(10253, "HANAR", new DateTime(1996, 7, 10), 58.17, "Brazil"));
            order.Add(new OrderDetails(10254, "CHOPS", new DateTime(1996, 7, 11), 22.98, "Switzerland"));
            order.Add(new OrderDetails(10255, "RICSU", new DateTime(1996, 7, 12), 148.33, "Switzerland"));
            order.Add(new OrderDetails(10256, "WELLI", new DateTime(1996, 7, 15), 13.97, "Brazil"));
            order.Add(new OrderDetails(10257, "HILAA", new DateTime(1996, 7, 16), 81.91, "Venezuela"));
            order.Add(new OrderDetails(10258, "ERNSH", new DateTime(1996, 7, 17), 140.51, "Austria"));
            order.Add(new OrderDetails(10259, "CENTC", new DateTime(1996, 7, 18), 3.25, "Mexico"));
            order.Add(new OrderDetails(10260, "OTTIK", new DateTime(1996, 7, 19), 55.09, "Germany"));
            order.Add(new OrderDetails(10261, "QUEDE", new DateTime(1996, 7, 19), 3.05, "Brazil"));
            order.Add(new OrderDetails(10262, "RATTC", new DateTime(1996, 7, 22), 48.29, "USA"));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public DateTime OrderDate { get; set; }
    public double? Freight { get; set; }
    public string ShipCountry { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNhSjStfdJDnCgcQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Clear selection via programmatically 

Clearing row selection programmatically in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid is useful when removing existing row selections based on application logic or user actions. To achieve this, use the [ClearRowSelectionAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ClearRowSelectionAsync) method.

The `ClearRowSelectionAsync` method is applicable when the [GridSelectionSettings.Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Type) is set to **Multiple** or **Single**.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="margin-bottom: 10px">
    <SfButton CssClass="btn" OnClick="ClearRowSelection">Clear Row Selection</SfButton>
</div>
<SfGrid @ref="Grid" DataSource="@OrderData" AllowPaging="true" AllowSelection="true" SelectedRowIndex="2">
    <GridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple" Mode="Syncfusion.Blazor.Grids.SelectionMode.Row"></GridSelectionSettings>
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
    public async Task ClearRowSelection()
    {
       await Grid.ClearRowSelectionAsync();  
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDVIZoZTxRbhiIYw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Row selection events 

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid provides several events related to row selection that allow customization and control over row selection behavior. These events enable implementation of logic before and after selection or deselection actions.

* [RowSelecting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowSelecting): Triggered before a row is selected. Use this event to apply validation or logic to control whether the row should be selected.

* [RowSelected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowSelected): Triggered after a row is successfully selected. This event is useful for executing actions or updating UI elements based on the selected row.

* [RowDeselecting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowDeselecting): Triggered before a selected row is deselected. Use this event to apply validation or logic to determine whether the deselection should proceed.

* [RowDeselected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowDeselected):  Triggered after a selected row is deselected. This event can be used to perform actions or cleanup tasks when a row is no longer selected.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<div style="text-align: center; color: red">
    <span>@RowSelectionMessage</span>
</div>
<SfGrid @ref="Grid" DataSource="@OrderData" AllowSelection="true" EnableHover="false">
    <GridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple" Mode="Syncfusion.Blazor.Grids.SelectionMode.Row"></GridSelectionSettings>
    <GridEvents RowSelected="RowselectHandler" RowSelecting="RowselectingHandler" RowDeselected="RowDeselectHandler" RowDeselecting="RowDeselectingHandler" TValue="OrderDetails"></GridEvents>
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
    public string RowSelectionMessage;
    public void RowselectingHandler(RowSelectingEventArgs<OrderDetails> Args)
    {
        if (Args.Data.CustomerID == "VINET")
        {
            Args.Cancel = true;
            RowSelectionMessage = "RowSelecting event is triggered. Selection prevented for CustomerID column Vinet value.";
        }
    }
    public void RowselectHandler(RowSelectEventArgs<OrderDetails> Args)
    {
        RowSelectionMessage = "Trigger RowSelected.";
    }
    public void RowDeselectingHandler(RowDeselectEventArgs<OrderDetails> Args)
    {
        if ((Args.Data.OrderID)%2 == 0)
        {
            Args.Cancel = true;
            RowSelectionMessage = "RowDeSelecting event is triggered. DeSelection prevented for OrderID column even values";
        }
    }
    public void RowDeselectHandler(RowDeselectEventArgs<OrderDetails> Args)
    {
        RowSelectionMessage = "Trigger RowDeSelected.";        
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNBSDoDzHHtCzbSp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}