---
layout: post
title: Column pinning (Frozen) in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about column pinning (Frozen) in the Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Column Pinning (Frozen) in Blazor DataGrid component

In the Syncfusion Blazor DataGrid component, you have the capability to **freeze** columns, ensuring they remain visible as you scroll through extensive datasets. This functionality significantly improves user experience by keeping critical information constantly within view, even when navigating through large volumes of data. This means that important columns remain fixed in their positions, making it easier to access and reference key data points while working with the grid.

In the following example, the [FrozenColumns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FrozenColumns) property is set to **2**. This configuration freezes the left two columns of the grid, and they will remain fixed in their positions while the rest of the columns grid can be scrolled horizontally.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<div style="margin-bottom:10px">
    <label style="padding: 30px 17px 0 0">Change the frozen columns:</label>
    <SfNumericTextBox Width="120px" Min=0 Max=5 Decimals="0" ValidateDecimalOnType="true" Format="n" Value="@value" TValue="int?">
        <NumericTextBoxEvents TValue="int?" ValueChange="@ValueChangeHandler"></NumericTextBoxEvents>
    </SfNumericTextBox>
    <SfButton @onclick="@UpdateValue">Update</SfButton>
</div>

<SfGrid ID="Grid" AllowSelection="false" FrozenColumns="@FrozenColumns" EnableHover="false" DataSource="@OrderData" Height="100%">                
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="160"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.EmployeeID) HeaderText="Employee ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipName) HeaderText="Ship Name" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipAddress) HeaderText="Ship Address" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipRegion) HeaderText="Ship Region" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipPostalCode) HeaderText="Ship Postal Code" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="150"></GridColumn>        
    </GridColumns>
</SfGrid>

@code {
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }

    public int? value { get; set; } = 2;
    public int FrozenColumns { get; set; } = 2;
        
    public void ValueChangeHandler(Syncfusion.Blazor.Inputs.ChangeEventArgs<int?> args)
    {
        if (args.Value != null && args.Value != 0)
        {
            value = args.Value;
        }
    }

    public void UpdateValue()
    {       
        FrozenColumns = (int)value;
    }
        
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails()
    {

    }
    public OrderDetails(int OrderID, string CustomerId, int EmployeeId, double Freight, DateTime OrderDate, string ShipCity, string ShipName, string ShipCountry, string ShipAddress, string shipRegion, string shipPostalCode)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.EmployeeID = EmployeeId;
        this.Freight = Freight;
        this.ShipCity = ShipCity;
        this.OrderDate = OrderDate;
        this.ShipName = ShipName;
        this.ShipCountry = ShipCountry;
        this.ShipAddress = ShipAddress;
        this.ShipRegion = shipRegion; 
        this.ShipPostalCode = shipPostalCode; 

    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET",  5,  32.38, new DateTime(1996, 7, 4), "Reims", "Vins et alcools Chevalier", "Australia",  "59 rue de l Abbaye", "51100", "CJ"));
            order.Add(new OrderDetails(10249, "TOMSP",  6,  11.61, new DateTime(1996, 7, 5), "Münster", "Toms Spezialitäten", "Australia", "Luisenstr. 48",  "44087", "CJ"));
            order.Add(new OrderDetails(10250, "HANAR",  4,  65.83,new DateTime(1996, 7, 8), "Rio de Janeiro", "Hanari Carnes", "United States", "Rua do Paço, 67",  "05454-876", "RJ"));
            order.Add(new OrderDetails(10251, "VICTE",  3, 41.34, new DateTime(1996, 7, 8), "Lyon", "Victuailles en stock", "Australia", "2, rue du Commerce","69004", "CJ"));
            order.Add(new OrderDetails(10252, "SUPRD",  4, 51.3, new DateTime(1996, 7, 9), "Charleroi", "Suprêmes délices", "United States", "Boulevard Tirou, 255", "B-6000", "CJ"));
            order.Add(new OrderDetails(10253, "HANAR",  3,  58.17, new DateTime(1996, 7, 10), "Rio de Janeiro", "Hanari Carnes", "United States", "Rua do Paço, 67", "05454-876", "RJ"));
            order.Add(new OrderDetails(10254, "CHOPS",  5,  22.98, new DateTime(1996, 7, 11), "Bern", "Chop-suey Chinese", "Switzerland", "Hauptstr. 31", "3012", "CJ"));
            order.Add(new OrderDetails(10255, "RICSU",  9,  148.33,  new DateTime(1996, 7, 12), "Genève", "Richter Supermarkt", "Switzerland", "Starenweg 5", "1204", "CJ"));
            order.Add(new OrderDetails(10256, "WELLI",  3,  13.97, new DateTime(1996, 7, 15), "Resende", "Wellington Importadora", "Brazil",  "Rua do Mercado, 12", "08737-363", "SP"));
            order.Add(new OrderDetails(10257, "HILAA",  4,  81.91, new DateTime(1996, 7, 16), "San Cristóbal", "HILARION-Abastos", "Venezuela", "Carrera 22 con Ave. Carlos Soublette #8-35", "5022", "Táchira"));
            order.Add(new OrderDetails(10258, "ERNSH",  1,  140.51, new DateTime(1996, 7, 17), "Graz", "Ernst Handel", "Austria", "Kirchgasse 6", "8010", "CJ"));
            order.Add(new OrderDetails(10259, "CENTC",  4, 3.25, new DateTime(1996, 7, 18), "México D.F.", "Centro comercial Moctezuma", "Mexico", "Sierras de Granada 9993", "05022", "CJ"));
            order.Add(new OrderDetails(10260, "OTTIK",  4, 55.09, new DateTime(1996, 7, 19), "Köln", "Ottilies Käseladen", "Germany", "Mehrheimerstr. 369", "50739", "CJ"));
            order.Add(new OrderDetails(10261, "QUEDE",  4, 3.05, new DateTime(1996, 7, 19), "Rio de Janeiro", "Que Delícia", "Brazil", "Rua da Panificadora, 12", "02389-673", "RJ"));
            order.Add(new OrderDetails(10262, "RATTC", 8, 48.29, new DateTime(1996, 7, 22), "Albuquerque", "Rattlesnake Canyon Grocery", "USA", "2817 Milton Dr.", "87110", "NM"));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public int EmployeeID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
    public DateTime OrderDate { get; set; }
    public string ShipName { get; set; }
    public string ShipCountry { get; set; }
    public string ShipAddress { get; set; }
    public string ShipRegion { get; set; } 
    public string ShipPostalCode { get; set; } 
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDhfWsCbfiSSvvZz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * Frozen columns should not be set outside the grid view port.
> * Frozen Grid support column virtualization feature, which helps to improve the Grid performance while loading a large dataset.
> * The frozen feature is supported only for the columns that are visible in the current view.
> * You can use both `FrozenColumns` property and [FrozenRows](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FrozenRows) property in the same application.

## Freeze particular columns

The Syncfusion Blazor DataGrid provides a valuable feature that enables you to freeze specific columns, significantly enhancing data visibility and improving your overall user experience. This functionality allows you to select particular columns and freeze them by positioning them at the leftmost side of the grid, ensuring they remain fixed in place while the remaining grid columns can still be scrolled horizontally. While the `FrozenColumns` property freezes columns in the order they are initialized in the grid, you can also use the `IsFrozen` property at the column level to freeze a specific column at any desired index on the left side, offering flexibility in managing which columns are frozen.

To freeze a particular column in the grid, you can utilize the [IsFrozen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsFrozen) property of the grid component as **true**.

The following example demonstrates how to freeze particular column in grid using `IsFrozen` property. This is achieved by the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_ValueChange) event of the `DropDownList` component. Within the change event, you can modify the `IsFrozen` property of the selected column using the [GetColumnByFieldAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetColumnByFieldAsync_System_String_) method. Afterward, you can use the [RefreshColumnsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RefreshColumnsAsync) method to update the displayed columns based on your interaction.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<div style="margin-bottom:10px">   
    <label>Change the frozen column: </label>
    <SfDropDownList TValue="string" TItem="Columns" Width="300px" Placeholder="Select a Column" DataSource="@LocalData" @bind-Value="@DropDownValue">
        <DropDownListEvents TItem="Columns" TValue="string"  ValueChange="ChangeColumn"></DropDownListEvents>
        <DropDownListFieldSettings Value="ID" Text="Value"></DropDownListFieldSettings>
    </SfDropDownList>
</div>

<SfGrid @ref="Grid" ID="Grid" AllowSelection="false" EnableHover="false" DataSource="@OrderData" Height="100%">                
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" IsFrozen="true" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="160"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.EmployeeID) HeaderText="Employee ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipName) HeaderText="Ship Name" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipAddress) HeaderText="Ship Address" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipRegion) HeaderText="Ship Region" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipPostalCode) HeaderText="Ship Postal Code" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="150"></GridColumn>        
    </GridColumns>
</SfGrid>

@code {
    public SfGrid<OrderDetails> Grid { get; set; }

    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }
    public string DropDownValue { get; set; } = "CustomerID";
    public class Columns
    {
        public string ID { get; set; }
        public string Value { get; set; }
    }
    List<Columns> LocalData = new List<Columns>
    {
        
        new Columns() { ID= "CustomerID", Value= "CustomerID" },
        new Columns() { ID= "OrderID", Value= "OrderID" },
        new Columns() { ID= "OrderDate", Value= "OrderDate" },
        new Columns() { ID= "EmployeeID", Value= "EmployeeID" },
        new Columns() { ID= "ShipName", Value= "ShipName" },
        new Columns() { ID= "ShipAddress", Value= "ShipAddress" },
        new Columns() { ID= "ShipCity", Value= "ShipCity" },
        new Columns() { ID= "ShipCountry", Value= "ShipCountry" },
        new Columns() { ID= "ShipRegion", Value= "ShipRegion" },
        new Columns() { ID= "ShipPostalCode", Value= "ShipPostalCode" },
        new Columns() { ID= "Freight", Value= "Freight" },
    };
    private async Task ChangeColumn(ChangeEventArgs<string, Columns> args)
    {        
        // Unfreeze all columns in the grid
         foreach (var column in Grid.Columns)
        {
            if (column.IsFrozen)
            {
                column.IsFrozen = false;           
            }            
        }
        // Freeze the selected column, if it exists
        var selectedColumn = await Grid.GetColumnByFieldAsync(args.Value);        
        {
            selectedColumn.IsFrozen = true;
        }
        // Refresh the grid to apply column changes
        await Grid.RefreshColumnsAsync();        
    }       
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails()
    {

    }
    public OrderDetails(int OrderID, string CustomerId, int EmployeeId, double Freight, DateTime OrderDate, string ShipCity, string ShipName, string ShipCountry, string ShipAddress, string shipRegion, string shipPostalCode)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.EmployeeID = EmployeeId;
        this.Freight = Freight;
        this.ShipCity = ShipCity;
        this.OrderDate = OrderDate;
        this.ShipName = ShipName;
        this.ShipCountry = ShipCountry;
        this.ShipAddress = ShipAddress;
        this.ShipRegion = shipRegion; 
        this.ShipPostalCode = shipPostalCode; 

    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET",  5,  32.38, new DateTime(1996, 7, 4), "Reims", "Vins et alcools Chevalier", "Australia",  "59 rue de l Abbaye", "51100", "CJ"));
            order.Add(new OrderDetails(10249, "TOMSP",  6,  11.61, new DateTime(1996, 7, 5), "Münster", "Toms Spezialitäten", "Australia", "Luisenstr. 48",  "44087", "CJ"));
            order.Add(new OrderDetails(10250, "HANAR",  4,  65.83,new DateTime(1996, 7, 8), "Rio de Janeiro", "Hanari Carnes", "United States", "Rua do Paço, 67",  "05454-876", "RJ"));
            order.Add(new OrderDetails(10251, "VICTE",  3, 41.34, new DateTime(1996, 7, 8), "Lyon", "Victuailles en stock", "Australia", "2, rue du Commerce","69004", "CJ"));
            order.Add(new OrderDetails(10252, "SUPRD",  4, 51.3, new DateTime(1996, 7, 9), "Charleroi", "Suprêmes délices", "United States", "Boulevard Tirou, 255", "B-6000", "CJ"));
            order.Add(new OrderDetails(10253, "HANAR",  3,  58.17, new DateTime(1996, 7, 10), "Rio de Janeiro", "Hanari Carnes", "United States", "Rua do Paço, 67", "05454-876", "RJ"));
            order.Add(new OrderDetails(10254, "CHOPS",  5,  22.98, new DateTime(1996, 7, 11), "Bern", "Chop-suey Chinese", "Switzerland", "Hauptstr. 31", "3012", "CJ"));
            order.Add(new OrderDetails(10255, "RICSU",  9,  148.33,  new DateTime(1996, 7, 12), "Genève", "Richter Supermarkt", "Switzerland", "Starenweg 5", "1204", "CJ"));
            order.Add(new OrderDetails(10256, "WELLI",  3,  13.97, new DateTime(1996, 7, 15), "Resende", "Wellington Importadora", "Brazil",  "Rua do Mercado, 12", "08737-363", "SP"));
            order.Add(new OrderDetails(10257, "HILAA",  4,  81.91, new DateTime(1996, 7, 16), "San Cristóbal", "HILARION-Abastos", "Venezuela", "Carrera 22 con Ave. Carlos Soublette #8-35", "5022", "Táchira"));
            order.Add(new OrderDetails(10258, "ERNSH",  1,  140.51, new DateTime(1996, 7, 17), "Graz", "Ernst Handel", "Austria", "Kirchgasse 6", "8010", "CJ"));
            order.Add(new OrderDetails(10259, "CENTC",  4, 3.25, new DateTime(1996, 7, 18), "México D.F.", "Centro comercial Moctezuma", "Mexico", "Sierras de Granada 9993", "05022", "CJ"));
            order.Add(new OrderDetails(10260, "OTTIK",  4, 55.09, new DateTime(1996, 7, 19), "Köln", "Ottilies Käseladen", "Germany", "Mehrheimerstr. 369", "50739", "CJ"));
            order.Add(new OrderDetails(10261, "QUEDE",  4, 3.05, new DateTime(1996, 7, 19), "Rio de Janeiro", "Que Delícia", "Brazil", "Rua da Panificadora, 12", "02389-673", "RJ"));
            order.Add(new OrderDetails(10262, "RATTC", 8, 48.29, new DateTime(1996, 7, 22), "Albuquerque", "Rattlesnake Canyon Grocery", "USA", "2817 Milton Dr.", "87110", "NM"));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public int EmployeeID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
    public DateTime OrderDate { get; set; }
    public string ShipName { get; set; }
    public string ShipCountry { get; set; }
    public string ShipAddress { get; set; }
    public string ShipRegion { get; set; } 
    public string ShipPostalCode { get; set; } 
}
{% endhighlight %}
{% endtabs %}

## Freeze direction

In the Syncfusion Blazor DataGrid, the "freeze direction" feature serves to reposition frozen columns either to the left, right, or in a fixed position, while still allowing the remaining columns to be horizontally movable. This feature is designed to optimize user experience by ensuring that critical information remains visible even during horizontal scrolling. By default, when you set the `FrozenColumns` property of the grid or the `IsFrozen` property of individual columns, it results in freezing those columns on the left side of the grid. This helps in keeping important data readily accessible as you navigate through your dataset.

To achieve this, you can utilize the [Column.Freeze](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Freeze) property. This property is used to specify the freeze direction for individual columns. The grid will adjust the column positions based on the `Column.Freeze` value.

The types of the `Column.Freeze` directions:

* **Left**: When you set the `Column.Freeze` property to **Left**, specific columns will be frozen on the left side of the grid. The remaining columns will be movable.

* **Right**: When you set the `Column.Freeze` property to **Right**, certain columns will be frozen on the right side of the grid, while the rest of the columns remain movable.

* **Fixed**: The Fixed direction locks a column at a fixed position within the grid. This ensures that the column is always visible during horizontal scroll.

In the following example, the **ShipCountry** column is frozen on the left side, the **CustomerID** column is frozen on the right side and the **Freight** column is frozen on the fixed of the content table. Additionally, you can modify the `Column.Freeze` property to **Left**, **Right** and **Fixed** based on the selected column by utilizing the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.DropDownListEvents-2.html#Syncfusion_Blazor_DropDowns_DropDownListEvents_2_ValueChange) event of the `DropDownList` component.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<div style="display:flex;">
    <label style="padding: 10px 20px 0 0"> ChangeColumn:</label>
    <SfDropDownList TValue="string" TItem="Columns" Width="300px" Placeholder="Select a Column" DataSource="@LocalData" @bind-Value="@DropDownValue">
        <DropDownListFieldSettings Value="ID" Text="Value"></DropDownListFieldSettings>
    </SfDropDownList>
</div>
<br />

<div style="display:flex;">
    <label style="padding: 10px 17px 0 0"> Change freeze direction:</label>
    <SfDropDownList TValue="Syncfusion.Blazor.Grids.FreezeDirection" TItem="string" DataSource="@EnumValues" @bind-Value="@DropDownDirection" Width="300px">
        <DropDownListFieldSettings Value="ID" Text="Value"></DropDownListFieldSettings>
    </SfDropDownList>
</div>
<br />
<div style="display:flex;">
    <Syncfusion.Blazor.Buttons.SfButton OnClick="ChangeColumn">Update</Syncfusion.Blazor.Buttons.SfButton>
</div>

<SfGrid @ref="Grid" ID="Grid" AllowSelection="false" EnableHover="false" DataSource="@OrderData" Height="100%">                
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Freeze="FreezeDirection.Fixed" IsFrozen="true" Format="C2" TextAlign="TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Freeze="FreezeDirection.Right" IsFrozen="true" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="160"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipName) HeaderText="Ship Name" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipAddress) HeaderText="Ship Address" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Freeze="FreezeDirection.Left" IsFrozen="true" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public SfGrid<OrderDetails> Grid { get; set; }

    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }

    public string DropDownValue { get; set; } = "ShipCountry";

    public string[] EnumValues = Enum.GetNames(typeof(Syncfusion.Blazor.Grids.FreezeDirection));

    public FreezeDirection DropDownDirection { get; set; } = Syncfusion.Blazor.Grids.FreezeDirection.Left;

    public class Columns
    {
        public string ID { get; set; }
        public string Value { get; set; }
    }
    public class Direction
    {
        public string ID { get; set; }
        public string Value { get; set; }
    }
    List<Columns> LocalData = new List<Columns>    {
        new Columns() { ID= "ShipCountry", Value= "ShipCountry" },
        new Columns() { ID= "OrderID", Value= "OrderID" },
        new Columns() { ID= "Freight", Value= "Freight" },
        new Columns() { ID= "CustomerID", Value= "CustomerID" },
        new Columns() { ID= "OrderDate", Value= "OrderDate" },
        new Columns() { ID= "ShipName", Value= "ShipName" },
        new Columns() { ID= "ShipAddress", Value= "ShipAddress" },
        new Columns() { ID= "ShipCity", Value= "ShipCity" },        
    };
    List<Direction> LocalData1 = new List<Direction>
    {
        new Direction() { ID= "Left", Value= "Left" },
        new Direction() { ID= "Right", Value= "Right" },
        new Direction() { ID= "Fixed", Value= "Fixed" },

    };  
    public async Task ChangeColumn()
    {
        // Await the column object from the asynchronous method
        var column = await Grid.GetColumnByFieldAsync(DropDownValue);
        if (column != null)
        {
            column.Freeze = DropDownDirection;
            column.IsFrozen = true;
            await Grid.RefreshColumnsAsync();
        }
    }
}
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails()
    {

    }
    public OrderDetails(int OrderID, string CustomerId, int EmployeeId, double Freight, DateTime OrderDate, string ShipCity, string ShipName, string ShipCountry, string ShipAddress, string shipRegion, string shipPostalCode)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.EmployeeID = EmployeeId;
        this.Freight = Freight;
        this.ShipCity = ShipCity;
        this.OrderDate = OrderDate;
        this.ShipName = ShipName;
        this.ShipCountry = ShipCountry;
        this.ShipAddress = ShipAddress;
        this.ShipRegion = shipRegion; 
        this.ShipPostalCode = shipPostalCode; 

    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET",  5,  32.38, new DateTime(1996, 7, 4), "Reims", "Vins et alcools Chevalier", "Australia",  "59 rue de l Abbaye", "51100", "CJ"));
            order.Add(new OrderDetails(10249, "TOMSP",  6,  11.61, new DateTime(1996, 7, 5), "Münster", "Toms Spezialitäten", "Australia", "Luisenstr. 48",  "44087", "CJ"));
            order.Add(new OrderDetails(10250, "HANAR",  4,  65.83,new DateTime(1996, 7, 8), "Rio de Janeiro", "Hanari Carnes", "United States", "Rua do Paço, 67",  "05454-876", "RJ"));
            order.Add(new OrderDetails(10251, "VICTE",  3, 41.34, new DateTime(1996, 7, 8), "Lyon", "Victuailles en stock", "Australia", "2, rue du Commerce","69004", "CJ"));
            order.Add(new OrderDetails(10252, "SUPRD",  4, 51.3, new DateTime(1996, 7, 9), "Charleroi", "Suprêmes délices", "United States", "Boulevard Tirou, 255", "B-6000", "CJ"));
            order.Add(new OrderDetails(10253, "HANAR",  3,  58.17, new DateTime(1996, 7, 10), "Rio de Janeiro", "Hanari Carnes", "United States", "Rua do Paço, 67", "05454-876", "RJ"));
            order.Add(new OrderDetails(10254, "CHOPS",  5,  22.98, new DateTime(1996, 7, 11), "Bern", "Chop-suey Chinese", "Switzerland", "Hauptstr. 31", "3012", "CJ"));
            order.Add(new OrderDetails(10255, "RICSU",  9,  148.33,  new DateTime(1996, 7, 12), "Genève", "Richter Supermarkt", "Switzerland", "Starenweg 5", "1204", "CJ"));
            order.Add(new OrderDetails(10256, "WELLI",  3,  13.97, new DateTime(1996, 7, 15), "Resende", "Wellington Importadora", "Brazil",  "Rua do Mercado, 12", "08737-363", "SP"));
            order.Add(new OrderDetails(10257, "HILAA",  4,  81.91, new DateTime(1996, 7, 16), "San Cristóbal", "HILARION-Abastos", "Venezuela", "Carrera 22 con Ave. Carlos Soublette #8-35", "5022", "Táchira"));
            order.Add(new OrderDetails(10258, "ERNSH",  1,  140.51, new DateTime(1996, 7, 17), "Graz", "Ernst Handel", "Austria", "Kirchgasse 6", "8010", "CJ"));
            order.Add(new OrderDetails(10259, "CENTC",  4, 3.25, new DateTime(1996, 7, 18), "México D.F.", "Centro comercial Moctezuma", "Mexico", "Sierras de Granada 9993", "05022", "CJ"));
            order.Add(new OrderDetails(10260, "OTTIK",  4, 55.09, new DateTime(1996, 7, 19), "Köln", "Ottilies Käseladen", "Germany", "Mehrheimerstr. 369", "50739", "CJ"));
            order.Add(new OrderDetails(10261, "QUEDE",  4, 3.05, new DateTime(1996, 7, 19), "Rio de Janeiro", "Que Delícia", "Brazil", "Rua da Panificadora, 12", "02389-673", "RJ"));
            order.Add(new OrderDetails(10262, "RATTC", 8, 48.29, new DateTime(1996, 7, 22), "Albuquerque", "Rattlesnake Canyon Grocery", "USA", "2817 Milton Dr.", "87110", "NM"));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public int EmployeeID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
    public DateTime OrderDate { get; set; }
    public string ShipName { get; set; }
    public string ShipCountry { get; set; }
    public string ShipAddress { get; set; }
    public string ShipRegion { get; set; } 
    public string ShipPostalCode { get; set; } 
}
{% endhighlight %}
{% endtabs %}

## Change default frozen line color

You can customize the frozen line borders of frozen columns in the Syncfusion DataGrid component by applying custom CSS styles to the specific frozen column. This allows you to change the border color of the left frozen columns, right frozen columns, and fixed frozen columns to match your application's design and theme.

To change default frozen line color, use the following class name and apply the border color based on your requirement.

For left frozen columns: 

```css
.e-grid .e-leftfreeze.e-freezeleftborder {
    border-right-color: rgb(198, 30, 204);
}
```
For right frozen columns:

```css
.e-grid .e-rightfreeze.e-freezerightborder {
    border-left-color: rgb(19, 228, 243);
}
```
For fixed frozen columns, you need to specify both left and right border as mentioned below

```css
.e-grid .e-fixedfreeze.e-freezeleftborder{
    border-left-color: rgb(9, 209, 9); 
}

.e-grid .e-fixedfreeze.e-freezerightborder{
    border-right-color: rgb(10, 224, 10);
}
```
The following example demonstrates how to change the default frozen line color using CSS.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" AllowSelection="false" EnableHover="false" DataSource="@OrderData" Height="100%">                
    <GridColumns>
        <GridColumn Field=@nameof(OrderDetails.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.CustomerID) HeaderText="Customer ID" Freeze="FreezeDirection.Left" IsFrozen="true" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="160"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.EmployeeID) HeaderText="Employee ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipName) HeaderText="Ship Name" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipAddress) HeaderText="Ship Address" Freeze="FreezeDirection.Fixed" IsFrozen="true" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCity) HeaderText="Ship City" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipCountry) HeaderText="Ship Country" Freeze="FreezeDirection.Right" IsFrozen="true" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipRegion) HeaderText="Ship Region" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.ShipPostalCode) HeaderText="Ship Postal Code" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderDetails.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="150"></GridColumn>        
    </GridColumns>
</SfGrid>

@code {
    public List<OrderDetails> OrderData { get; set; }
    protected override void OnInitialized()
    {
        OrderData = OrderDetails.GetAllRecords();
    }    
}

<style>
.e-grid .e-leftfreeze.e-freezeleftborder {
    border-right-color: rgb(198, 30, 204) !important;
}

.e-grid .e-rightfreeze.e-freezerightborder {
    border-left-color: rgb(19, 228, 243) !important;
}

.e-grid .e-fixedfreeze.e-freezeleftborder{
    border-left-color: rgb(9, 209, 9) !important; 
}

.e-grid .e-fixedfreeze.e-freezerightborder{
    border-right-color: rgb(10, 224, 10) !important;
}
</style>
{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}
   public class OrderDetails
{
    public static List<OrderDetails> order = new List<OrderDetails>();
    public OrderDetails()
    {

    }
    public OrderDetails(int OrderID, string CustomerId, int EmployeeId, double Freight, DateTime OrderDate, string ShipCity, string ShipName, string ShipCountry, string ShipAddress, string shipRegion, string shipPostalCode)
    {
        this.OrderID = OrderID;
        this.CustomerID = CustomerId;
        this.EmployeeID = EmployeeId;
        this.Freight = Freight;
        this.ShipCity = ShipCity;
        this.OrderDate = OrderDate;
        this.ShipName = ShipName;
        this.ShipCountry = ShipCountry;
        this.ShipAddress = ShipAddress;
        this.ShipRegion = shipRegion; 
        this.ShipPostalCode = shipPostalCode; 

    }
    public static List<OrderDetails> GetAllRecords()
    {
        if (order.Count == 0)
        {
            order.Add(new OrderDetails(10248, "VINET",  5,  32.38, new DateTime(1996, 7, 4), "Reims", "Vins et alcools Chevalier", "Australia",  "59 rue de l Abbaye", "51100", "CJ"));
            order.Add(new OrderDetails(10249, "TOMSP",  6,  11.61, new DateTime(1996, 7, 5), "Münster", "Toms Spezialitäten", "Australia", "Luisenstr. 48",  "44087", "CJ"));
            order.Add(new OrderDetails(10250, "HANAR",  4,  65.83,new DateTime(1996, 7, 8), "Rio de Janeiro", "Hanari Carnes", "United States", "Rua do Paço, 67",  "05454-876", "RJ"));
            order.Add(new OrderDetails(10251, "VICTE",  3, 41.34, new DateTime(1996, 7, 8), "Lyon", "Victuailles en stock", "Australia", "2, rue du Commerce","69004", "CJ"));
            order.Add(new OrderDetails(10252, "SUPRD",  4, 51.3, new DateTime(1996, 7, 9), "Charleroi", "Suprêmes délices", "United States", "Boulevard Tirou, 255", "B-6000", "CJ"));
            order.Add(new OrderDetails(10253, "HANAR",  3,  58.17, new DateTime(1996, 7, 10), "Rio de Janeiro", "Hanari Carnes", "United States", "Rua do Paço, 67", "05454-876", "RJ"));
            order.Add(new OrderDetails(10254, "CHOPS",  5,  22.98, new DateTime(1996, 7, 11), "Bern", "Chop-suey Chinese", "Switzerland", "Hauptstr. 31", "3012", "CJ"));
            order.Add(new OrderDetails(10255, "RICSU",  9,  148.33,  new DateTime(1996, 7, 12), "Genève", "Richter Supermarkt", "Switzerland", "Starenweg 5", "1204", "CJ"));
            order.Add(new OrderDetails(10256, "WELLI",  3,  13.97, new DateTime(1996, 7, 15), "Resende", "Wellington Importadora", "Brazil",  "Rua do Mercado, 12", "08737-363", "SP"));
            order.Add(new OrderDetails(10257, "HILAA",  4,  81.91, new DateTime(1996, 7, 16), "San Cristóbal", "HILARION-Abastos", "Venezuela", "Carrera 22 con Ave. Carlos Soublette #8-35", "5022", "Táchira"));
            order.Add(new OrderDetails(10258, "ERNSH",  1,  140.51, new DateTime(1996, 7, 17), "Graz", "Ernst Handel", "Austria", "Kirchgasse 6", "8010", "CJ"));
            order.Add(new OrderDetails(10259, "CENTC",  4, 3.25, new DateTime(1996, 7, 18), "México D.F.", "Centro comercial Moctezuma", "Mexico", "Sierras de Granada 9993", "05022", "CJ"));
            order.Add(new OrderDetails(10260, "OTTIK",  4, 55.09, new DateTime(1996, 7, 19), "Köln", "Ottilies Käseladen", "Germany", "Mehrheimerstr. 369", "50739", "CJ"));
            order.Add(new OrderDetails(10261, "QUEDE",  4, 3.05, new DateTime(1996, 7, 19), "Rio de Janeiro", "Que Delícia", "Brazil", "Rua da Panificadora, 12", "02389-673", "RJ"));
            order.Add(new OrderDetails(10262, "RATTC", 8, 48.29, new DateTime(1996, 7, 22), "Albuquerque", "Rattlesnake Canyon Grocery", "USA", "2817 Milton Dr.", "87110", "NM"));
        }
        return order;
    }
    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public int EmployeeID { get; set; }
    public double Freight { get; set; }
    public string ShipCity { get; set; }
    public DateTime OrderDate { get; set; }
    public string ShipName { get; set; }
    public string ShipCountry { get; set; }
    public string ShipAddress { get; set; }
    public string ShipRegion { get; set; } 
    public string ShipPostalCode { get; set; } 
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjhqsiDQVjBIavlN?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Limitations of Frozen Columns and Freeze Direction  

The frozen columns and freeze direction features in Syncfusion Blazor DataGrid have the following limitations:

### General Limitations for Frozen Columns  

* Row Template  
* Detail Template  
* Hierarchy DataGrid  

### Additional Limitations for Freeze Direction  

* Infinite scroll in cache mode is not supported.  
* Freeze direction in the stacked header is incompatible with column reordering.  
* Using a cell template or text wrap in any one of the panels may cause variable row heights between the panels. The height is recalculated based on the DOM offset height and applied uniformly across all rows to maintain consistency. This can lead to visual glitches. You can resolve this problem by setting static values for the [RowHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RowHeight) property in `SfGrid`.  
* The [Freeze](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Freeze) and [FrozenColumns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_FrozenColumns) properties are incompatible and cannot be used simultaneously.  

> You can refer to our [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap4) to understand how to present and manipulate data.