---
layout: post
title: Row in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Row in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Row in Blazor DataGrid Component

Each row typically represents a single record or item from a data source. Rows in a grid are used to present data in a tabular format. Each row displays a set of values representing the fields of an individual data record. Rows allow users to interact with the data in the grid. Users can select rows, edit cell values, perform sorting or filtering operations, and trigger events based on actions.

## Customize row styles

Customizing the styles of rows in a Syncfusion Grid allows you to modify the appearance of rows to meet your design requirements. This feature is useful when you want to highlight certain rows or change the font style, background color, and other properties of the row to enhance the visual appeal of the grid. To customize the row styles in the grid, you can use CSS, properties, methods, or event support provided by the Syncfusion Blazor Grid component.

### Using event

You can customize the appearance of the rows by using the [RowDataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html) event. This event triggers for every row when it is bound to the data source. In the event handler, you can get the **RowDataBoundEventArgs** object, which contains details of the row. You can use this object to modify the row’s appearance, add custom elements, or perform any other customization.

Here’s an example of how you can use the `RowDataBound` event to customize the styles of rows based on the value of the Freight column. This example involves checking the value of the Freight column for each row and adding a CSS class to the row based on the value. The CSS classes below-25,below-35, and above-35 can then be defined in your stylesheet to apply the desired styles to the rows.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" EnableHover=false AllowSelection=false Height="280">
    <GridEvents TValue="Order" RowDataBound="RowBound"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Width="110" Type="ColumnType.Date"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    .below-25 {
        background-color: orangered;
    }

    .below-35 {
        background-color: yellow;
    }

    .above-35 {
        background-color: greenyellow
    }
</style>

@code {

    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            ShipCity = (new string[] { "Berlin", "Madrid", "Cholchester", "Marseille", "Tsawassen" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }

    public void RowBound(RowDataBoundEventArgs<Order> args)
    {
        if (args.Data.Freight < 25)
        {
            args.Row.AddClass(new string[] { "below-25" });
        }
        else if (args.Data.Freight < 35)
        {
            args.Row.AddClass(new string[] { "below-35" });
        }
        else
        {
            args.Row.AddClass(new string[] { "above-35" });
        }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNLUNxViMOVPHtVB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> The [QueryCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_QueryCellInfo) event can also be used to customize cells and is triggered for every cell in the grid. It can be useful when you need to customize cells based on certain conditions or criteria.

### Using CSS customize alternate rows

You can apply styles to the rows using CSS selectors. The Grid provides a class name for each row element, which you can use to apply styles to that specific row.

**Customize alternate rows**

You can customize the appearance of the alternate rows using CSS. This can be useful for improving the readability of the data and making it easier to distinguish between rows. By default, Syncfusion Grid provides the CSS class **.e-altrow** to style the alternate rows. You can customize this default style by overriding the **.e-altrow** class with your custom CSS styles.

To change the background color of the alternate rows, you can add the following CSS code to your application’s stylesheet:

```css
.e-grid .e-altrow {
    background-color: #fafafa;
}
```

Here’s an example of how to use the **.e-altrow** class to style alternate rows:

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="280">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Width="110" Type="ColumnType.Date"></GridColumn>
    </GridColumns>
</SfGrid>

<style type="text/css" class="cssStyles">
    .e-grid .e-altrow {
        background-color: #fafafa;
    }
</style>

@code {

    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            ShipCity = (new string[] { "Berlin", "Madrid", "Cholchester", "Marseille", "Tsawassen" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDLUtnLiCORYLWHV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Customize selected row**

You can customize the appearance of the selected row using CSS. This is useful when you want to highlight the currently selected row for improve the visual appeal of the Grid. By default, the Grid provides the CSS class **.e-selectionbackground** to style the selected row. You can customize this default style by overriding the **.e-selectionbackground** class with your own custom CSS styles.

To change the background color of the selected row, you can add the following CSS code to your application:

```css
 .e-grid .e-row .e-selectionbackground {
        background-color: #f9920b;
    }
```
Here’s an example of how to use the .e-selectionbackground class to style the selected row:

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="280" AllowSelection="true">
    <GridSelectionSettings Mode="SelectionMode.Row"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Width="110" Type="ColumnType.Date"></GridColumn>
    </GridColumns>
</SfGrid>

<style type="text/css" class="cssStyles">
    .e-grid .e-row .e-selectionbackground {
        background-color: #f9920b;
    }
</style>

@code {

    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
                ShipCity = (new string[] { "Berlin", "Madrid", "Cholchester", "Marseille", "Tsawassen" })[new Random().Next(5)],
                Freight = 2.1 * x,
                OrderDate = DateTime.Now.AddDays(-x),
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXBKDFMXVsvFHiJY?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Row Height 

The Syncfusion Grid allows you to customize the height of rows based on your needs. This feature can be useful when you need to display more content in a row or when you want to reduce the height of rows to fit its content. You can achieve this by using the [RowHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RowHeight) property of the Grid component. This property allows you to change the height of the entire grid row to your desired value.

In the below example, we will demonstrate how to dynamically change the height of the rows using the `RowHeight` property.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton Content="CHANGE HEIGHT 20PX" OnClick="ChangeHeight20PX" ></SfButton>
<SfButton Content="CHANGE HEIGHT 42PX" OnClick="ChangeHeight42PX" ></SfButton>
<SfButton Content="CHANGE HEIGHT 60PX" OnClick="ChangeHeight60PX" ></SfButton>

<SfGrid DataSource="@Orders" Height="280" RowHeight="@IsVar">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Width="110" Type="Syncfusion.Blazor.Grids.ColumnType.Date"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public List<Order> Orders { get; set; }
    public double IsVar { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
                ShipCity = (new string[] { "Berlin", "Madrid", "Cholchester", "Marseille", "Tsawassen" })[new Random().Next(5)],
                Freight = 2.1 * x,
                OrderDate = DateTime.Now.AddDays(-x),
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }

    public void ChangeHeight20PX()
    {
        IsVar = 20;
    }
    public void ChangeHeight42PX()
    {
        IsVar = 42;
    }
    public void ChangeHeight60PX()
    {
        IsVar = 60;
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXVAtbCjBfotEWRe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> The `RowHeight` property can only be used to set the height of the entire grid row. It cannot be used to set the height of individual cells within a row.
<br/> The `RowHeight` property applies the height to all rows in the grid, including the header and footer rows.
<br/> You can also set the height for a specific row using the `RowHeight` property of the corresponding row object in the `RowDataBound` event.

## Customize row height for particular row

Customizing the row height for a particular row can be useful when you want to display more content in a particular row, reduce the height of a row to fit its content, or make a specific row stand out from the other rows in the grid. This can be achieved by using the [RowHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RowHeight) property of the Grid component along with the [RowDataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowDataBound) event.

The `RowHeight` property of the Grid component allows you to set the height of all rows in the grid to a specific value. However, if you want to customize the row height for a specific row based on the row data, you can use the `RowDataBound` event. This event is triggered every time a request is made to access row information, element, or data, and before the row element is appended to the Grid element.

In the below example, the row height for the row with OrderID as '1003' is set as '90px' using the `RowDataBound` event.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="280">
    <GridEvents TValue="Order" RowDataBound="RowBound"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Width="110" Type="ColumnType.Date"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    .row-height {
        height: 90px;
    }
</style>

@code {

    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            ShipCity = (new string[] { "Berlin", "Madrid", "Cholchester", "Marseille", "Tsawassen" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }

    public void RowBound(RowDataBoundEventArgs<Order> args)
    {
        if (args.Data.OrderID == 1003)
        {
            args.Row.AddClass(new string[] { "row-height" });
        }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjrKtdhshtqkCytp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> In virtual scrolling mode, it is not applicable to set different row heights.
<br/> You can customize the row height of multiple rows by checking the relevant criteria in the `RowDataBound` event and setting the `RowHeight` property accordingly.
<br/> In the `RowDataBound` event handler, you can access the current row using the **args.row** property and set the `RowHeight` property for that row using the setAttribute method.

## How to get the row data and element

Grid provides several methods to retrieve row data and elements. This feature is useful when you need to access specific rows, perform custom operations, or manipulate the data displayed in the grid.

1.[GetRowIndexByPrimaryKeyAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetRowIndexByPrimaryKeyAsync_System_Object_): The method allows you to retrieve the row index based on a specific primary key value or row data.
```cshtml
var rowIndex =this.Grid.GetRowIndexByPrimaryKeyAsync(primaryKey);
```
2.[GetSelectedRowIndexesAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetSelectedRowIndexesAsync):This method returns an array of HTML elements representing the selected rows in the grid.By iterating over this array, you can access each row element.This way, you can access both the row elements and their associated data for the selected rows.
```cshtml
var selectedRowElements = this.Grid.GetSelectedRowIndexesAsync();
```


## Master Detail DataGrid

The DataGrid has an option to visualize details of a record in another DataGrid in a master and detail manner. By clicking the master DataGrid row, the detail DataGrid will be populated with the corresponding data. This can be achieved as follows:

Using the [RowSelected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowSelected) event of the Master DataGrid, get the selected record details. Based on these selected record details, filter the data using the [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Query) property of the Detail DataGrid and bind the resultant data to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) property of the Detail DataGrid.

In the following sample, click the row in the master DataGrid, which shows the details in another(detail) DataGrid.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data

<SfGrid SelectedRowIndex=2 DataSource="@Employees">                
    <GridEvents RowSelected="RowSelecthandler" TValue="EmployeeData"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.CustomerName) HeaderText="Customer Name" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(EmployeeData.CompanyName) HeaderText="Company Name" Width="110"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Address) Width="110"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Country) Width="110"></GridColumn>
    </GridColumns>
</SfGrid>
<br>
<div class='e-statustext'>Showing orders of Customer: <b>@SelectedCustomer</b></div>

<SfGrid DataSource="@GridData" Query="@(new Query().Where("EmployeeID", "equal", RowIndex))">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" Width="110"> </GridColumn>
        <GridColumn Field=@nameof(Order.ShipName) HeaderText="Ship Name" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipAddress) HeaderText="Ship Address" Width="110"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public IEnumerable<Order> GridData { get; set; }
    public string SelectedCustomer { get; set; }
    public int? RowIndex { get; set; } = 1003;

    public void RowSelecthandler(RowSelectEventArgs<EmployeeData> Args)
    {
        SelectedCustomer = Args.Data.CustomerName;
        RowIndex = Args.Data.EmployeeID;
    }

    List<EmployeeData> Employees = new List<EmployeeData>
    {
        new EmployeeData() {EmployeeID = 1001, CustomerName="Thomas Hardy", CompanyName="Around the Horn", Address="120 Hanover Sq.", Country="UK"},
        new EmployeeData() {EmployeeID = 1002, CustomerName="Christina Berglund", CompanyName="Berglunds snabbköp", Address="Berguvsvägen 8", Country="Sweden"},
        new EmployeeData() {EmployeeID = 1003, CustomerName="Frédérique Citeaux", CompanyName="Blondesddsl père et fils", Address="24, place Kléber", Country="France"},
        new EmployeeData() {EmployeeID = 1004, CustomerName="Yang Wang", CompanyName="Chop-suey Chinese", Address="Hauptstr. 29", Country="Switzerland"},
        new EmployeeData() {EmployeeID = 1005, CustomerName="Roland Mendel", CompanyName="Ernst Handel", Address="Kirchgasse 6", Country="Austria"},
    };
    List<Order> Orders = new List<Order> {
        new Order() {EmployeeID = 1001, OrderID=001, ShipName="Around the Horn", ShipCountry="UK", ShipAddress="Brook Farm Stratford St. Mary"},
        new Order() {EmployeeID = 1001, OrderID=002, ShipName="Around the Horn", ShipCountry="UK", ShipAddress="Brook Farm Stratford St. Mary"},
        new Order() {EmployeeID = 1001, OrderID=003, ShipName="Around the Horn", ShipCountry="UK", ShipAddress="Brook Farm Stratford St. Mary"},
        new Order() {EmployeeID = 1001, OrderID=004, ShipName="Around the Horn", ShipCountry="UK", ShipAddress="Brook Farm Stratford St. Mary"},
        new Order() {EmployeeID = 1001, OrderID=005, ShipName="Around the Horn", ShipCountry="UK", ShipAddress="Brook Farm Stratford St. Mary"},
        new Order() {EmployeeID = 1002, OrderID=006, ShipName="Berglunds snabbköp", ShipCountry="Sweden", ShipAddress="Berguvsvägen 8"},
        new Order() {EmployeeID = 1002, OrderID=007, ShipName="Berglunds snabbköp", ShipCountry="Sweden", ShipAddress="Berguvsvägen 8"},
        new Order() {EmployeeID = 1002, OrderID=008, ShipName="Berglunds snabbköp", ShipCountry="Sweden", ShipAddress="Berguvsvägen 8"},
        new Order() {EmployeeID = 1002, OrderID=009, ShipName="Berglunds snabbköp", ShipCountry="Sweden", ShipAddress="Berguvsvägen 8"},
        new Order() {EmployeeID = 1002, OrderID=010, ShipName="Berglunds snabbköp", ShipCountry="Sweden", ShipAddress="Berguvsvägen 8"},
        new Order() {EmployeeID = 1003, OrderID=011, ShipName="Blondel père et fils", ShipCountry="France", ShipAddress="24, place Kléber"},
        new Order() {EmployeeID = 1003, OrderID=012, ShipName="Blondel père et fils", ShipCountry="France", ShipAddress="24, place Kléber"},
        new Order() {EmployeeID = 1003, OrderID=013, ShipName="Blondel père et fils", ShipCountry="France", ShipAddress="24, place Kléber"},
        new Order() {EmployeeID = 1003, OrderID=014, ShipName="Blondel père et fils", ShipCountry="France", ShipAddress="24, place Kléber"},
        new Order() {EmployeeID = 1003, OrderID=015, ShipName="Blondel père et fils", ShipCountry="France", ShipAddress="24, place Kléber"},
        new Order() {EmployeeID = 1004, OrderID=016, ShipName="Chop-suey Chinese", ShipCountry="Switzerland", ShipAddress="Hauptstr. 31"},
        new Order() {EmployeeID = 1004, OrderID=017, ShipName="Chop-suey Chinese", ShipCountry="Switzerland", ShipAddress="Hauptstr. 31"},
        new Order() {EmployeeID = 1004, OrderID=018, ShipName="Chop-suey Chinese", ShipCountry="Switzerland", ShipAddress="Hauptstr. 31"},
        new Order() {EmployeeID = 1004, OrderID=019, ShipName="Chop-suey Chinese", ShipCountry="Switzerland", ShipAddress="Hauptstr. 31"},
        new Order() {EmployeeID = 1004, OrderID=020, ShipName="Chop-suey Chinese", ShipCountry="Switzerland", ShipAddress="Hauptstr. 31"},
        new Order() {EmployeeID = 1005, OrderID=021, ShipName="Ernst Handel", ShipCountry="Austria", ShipAddress="Kirchgasse 6"},
        new Order() {EmployeeID = 1005, OrderID=022, ShipName="Ernst Handel", ShipCountry="Austria", ShipAddress="Kirchgasse 6"},
        new Order() {EmployeeID = 1005, OrderID=023, ShipName="Ernst Handel", ShipCountry="Austria", ShipAddress="Kirchgasse 6"},
        new Order() {EmployeeID = 1005, OrderID=024, ShipName="Ernst Handel", ShipCountry="Austria", ShipAddress="Kirchgasse 6"},
        new Order() {EmployeeID = 1005, OrderID=025, ShipName="Ernst Handel", ShipCountry="Austria", ShipAddress="Kirchgasse 6"},
    };

    protected override void OnInitialized()
    {
        GridData = this.Orders;
    }
    public class EmployeeData
    {
        public int? EmployeeID { get; set; }
        public string CustomerName { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public string Country { get; set; }
    }
    public class Order
    {
        public int? EmployeeID { get; set; }
        public int? OrderID { get; set; }
        public string ShipName { get; set; }
        public string ShipCountry { get; set; }
        public string ShipAddress { get; set; }
    }
} 
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDrANnhMsulHCrDU?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> [View Sample.](https://blazor.syncfusion.com/demos/datagrid/master-details?theme=fluent)