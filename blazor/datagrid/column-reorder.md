---
layout: post
title: Column Reorder in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about column reorder in the Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Column Reorder in Blazor DataGrid component

The Syncfusion Blazor Grid component allows to reorder columns by drag and drop of a particular column header from one index to another index within the grid.

To reorder the columns, set the [AllowReordering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowReordering) property to true in the grid.

Here’s an example for column reordering in your Grid component:

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315" AllowReordering="true" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipName) HeaderText="Ship Name" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD" })[new Random().Next(5)],
                ShipCity = (new string[] { "Reims", "Münster", "Rio de Janeiro", "Lyon", "Charleroi" })[new Random().Next(5)],
                ShipName = (new string[] { "Vins et alcool", "Toms Spezialitäten", "Hanari Carnes", "Victuailles en stock", "Suprêmes délices" })[new Random().Next(5)]
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipName { get; set; }
    }
}
```

The following represents Reordering of columns

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDrKjPqjiHRYBUgm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * You can disable reordering a particular column by setting the [AllowReordering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowReordering) property of **GridColumn** as false.
<br/> * When columns are reordered, the position of the corresponding column data will also be changed. As a result, you should ensure that any additional code or logic that relies on the order of the column data is updated accordingly.

## Prevent reordering for particular column

By default, all columns in the Syncfusion Blazor Grid can be reordered by dragging and dropping their headers to another location within the grid. However, there may be certain columns that you do not want to be reordered. In such cases, you can set the [AllowReordering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowReordering) property of that particular column to false. Here is an example that demonstrates how to prevent reordering for a specific column:

In this example, the **ShipCity** column is prevented from being reordered by setting the `AllowReordering` property to **false**.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315" AllowReordering="true" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" AllowReordering="false" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipName) HeaderText="Ship Name" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD" })[new Random().Next(5)],
                ShipCity = (new string[] { "Reims", "Münster", "Rio de Janeiro", "Lyon", "Charleroi" })[new Random().Next(5)],
                ShipName = (new string[] { "Vins et alcool", "Toms Spezialitäten", "Hanari Carnes", "Victuailles en stock", "Suprêmes délices" })[new Random().Next(5)]
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipName { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BNrAjPKtCQvJlPJv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Reorder columns externally

The Syncfusion Blazor Grid allows you to reorder columns externally, which means that using methods you can programmatically move columns around within the grid, based on their index or target index, or by using their field name.

### Reorder column based on index

You can use the [ReorderColumnByIndexAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ReorderColumnByIndexAsync_System_Int32_System_Int32_) method to reorder columns based on their current index. This method takes two arguments:

* **fromIndex** : Current index of the column to be reordered.
* **toIndex** : New index of the column after the reordering.

Here is an example of how to use the `ReorderColumnByIndexAsync` method:

In this example, we are moving the column at index 1 to index 2.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="reOrder">REORDER COLUMN BY INDEX</SfButton>

<SfGrid @ref="Grid" DataSource="@Orders" Height="315" AllowReordering="true" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipRegion) HeaderText="Ship Region" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipName) HeaderText="Ship Name" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<Order> Grid;
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD" })[new Random().Next(5)],
                ShipCity = (new string[] { "Reims", "Münster", "Rio de Janeiro", "Lyon", "Charleroi" })[new Random().Next(5)],
                ShipRegion = (new string[] { "CJ", "SP", "RJ", "Táchira", "NM" })[new Random().Next(5)],
                ShipName = (new string[] { "Vins et alcool", "Toms Spezialitäten", "Hanari Carnes", "Victuailles en stock", "Suprêmes délices" })[new Random().Next(5)]
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipName { get; set; }
    }

    public void reOrder()
    {
        this.Grid.ReorderColumnByIndexAsync(1, 2);
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hNLqXFUjMvoSvMXo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Reorder column based on target index

You can also use the [ReorderColumnByTargetIndexAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ReorderColumnByTargetIndexAsync_System_String_System_Int32_) method to reorder column columns based on the target index. This method takes two arguments:

* **FieldName** : Field name of the column to be reordered
* **toIndex** : New index of the column after the reordering

Here is an example of how to use the `ReorderColumnByTargetIndexAsync` method to reorder column based on target index:

```cshtml 
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="singleColumn">REORDER SINGLE COLUMN </SfButton>


<SfGrid @ref="Grid" DataSource="@Orders" Height="315" AllowReordering="true" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipRegion) HeaderText="Ship Region" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipName) HeaderText="Ship Name" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<Order> Grid;
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD" })[new Random().Next(5)],
                ShipCity = (new string[] { "Reims", "Münster", "Rio de Janeiro", "Lyon", "Charleroi" })[new Random().Next(5)],
                ShipRegion = (new string[] { "CJ", "SP", "RJ", "Táchira", "NM" })[new Random().Next(5)],
                ShipName = (new string[] { "Vins et alcool", "Toms Spezialitäten", "Hanari Carnes", "Victuailles en stock", "Suprêmes délices" })[new Random().Next(5)]
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipName { get; set; }
    }

    public void singleColumn()
    {
        this.Grid.ReorderColumnByTargetIndexAsync("OrderID", 3);
    }

}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hXLqDFqNMbELbJgC?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Reorder column based on field names

The [ReorderColumnsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ReorderColumnAsync_System_String_System_String_) method of the Grid allows you to reorder list of columns based on their field names. This method takes two arguments:

* **fromFieldName**: The field name of the column you want to move.
* **toFieldName** : The field name of the column you want to move the column to.

Here is an example of how to use the `ReorderColumnsAsync` method to reorder multiple columns based on field names:

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="ReorderBtn" CssClass="e-primary" IsPrimary="true" Content="REORDER SINGLE COLUMN"></SfButton>
<SfButton OnClick="multipleColumn" CssClass="e-primary" IsPrimary="true" Content="REORDER MULTIPLE COLUMN"></SfButton>


<SfGrid @ref="Grid" DataSource="@Orders" Height="315" AllowReordering="true" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipRegion) HeaderText="Ship Region" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipName) HeaderText="Ship Name" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<string> IsVar = (new List<string> { "ShipCity", "ShipRegion", "ShipName" });
    private SfGrid<Order> Grid;
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD" })[new Random().Next(5)],
                ShipCity = (new string[] { "Reims", "Münster", "Rio de Janeiro", "Lyon", "Charleroi" })[new Random().Next(5)],
                ShipRegion = (new string[] { "CJ", "SP", "RJ", "Táchira", "NM" })[new Random().Next(5)],
                ShipName = (new string[] { "Vins et alcool", "Toms Spezialitäten", "Hanari Carnes", "Victuailles en stock", "Suprêmes délices" })[new Random().Next(5)]

            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipRegion { get; set; }
        public string ShipName { get; set; }
    }
    public void ReorderBtn()
    {
        this.Grid.ReorderColumns("ShipCity", "OrderID");
    }


    public void multipleColumn()
    {

        this.Grid.ReorderColumnsAsync(IsVar, "OrderID");
    }

}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LNVgDFUtBByNDPFg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

<!-- Reorder events

During the reorder action, the grid component triggers the below events,

1. [`ColumnDragStart`] -  Triggers when a column header element drag(move) starts.
2. [`ColumnDrag`]      -  Triggers when a column header element is dragged(moved) continuously.
3. [`ColumnDrop`]      -  Triggers when a column header element is dropped on the target column.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowReordering="true" AllowPaging="true" Height ="315">
<GridEvents ColumnDragStart="OnDragStart" ColumnDrag="OnDragging" ColumnDrop="OnDrop" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerName) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" MinWidth="10" Width="120" MaxWidth="200"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
    </GridColumns>
</SfGrid>

@code{

    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerName = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public void OnDragStart() {
        // Perform required operations here
    }

    public void OnDragging() {
        // Perform required operations here
    }

    public void OnDrop() {
        // Perform required operations here
    }

    public class Order {
        public int? OrderID { get; set; }
        public string CustomerName { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
``` -->

<!-- ## Lock columns

You can lock columns by using [`LockColumn`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_LockColumn) property. The locked columns will be moved to the first position and can’t be reordered.

In the following example, Order ID column is locked and its reordering functionality is disabled.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Employees" AllowReordering="true" Height="215">
    <GridColumns>
        <GridColumn Field=@nameof(EmployeeData.EmployeeID) LockColumn="true" TextAlign="TextAlign.Center" HeaderText="Employee ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Name) HeaderText="First Name" Width="130"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.Title) HeaderText="Title" Width="120"></GridColumn>
        <GridColumn Field=@nameof(EmployeeData.HireDate) HeaderText="Hire Date" Format="d" TextAlign="TextAlign.Right" Width="150" Type="ColumnType.Date"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<EmployeeData> Employees = new List<EmployeeData>
    {
        new EmployeeData() { EmployeeID = 1, Name = "Nancy Fuller", Title = "Vice President", HireDate = DateTime.Now.AddDays(-80) },
        new EmployeeData() { EmployeeID = 2, Name = "Steven Buchanan", Title = "Sales Manager", HireDate = DateTime.Now.AddDays(-60) },
        new EmployeeData() { EmployeeID = 3, Name = "Janet Leverling", Title = "Sales Representative", HireDate = DateTime.Now.AddDays(-34) },
        new EmployeeData() { EmployeeID = 4, Name = "Andrew Davolio", Title = "Inside Sales Coordinator", HireDate = DateTime.Now.AddDays(-22) },
        new EmployeeData() { EmployeeID = 5, Name = "Margaret Peacock", Title = "Sales", HireDate = DateTime.Now.AddDays(-12) },
    };

    public class EmployeeData
    {
        public int? EmployeeID { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }
        public DateTime HireDate { get; set; }
    }
}
``` -->