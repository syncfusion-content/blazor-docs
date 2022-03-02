---
layout: post
title: Column Reorder in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about column reorder in the Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Column Reorder in Blazor DataGrid

Reordering can be done by drag and drop of a particular column header from one index to another index within the DataGrid. To enable reordering, set the [AllowReordering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowReordering) property to true.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Height="315" AllowReordering="true" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

The following represents Reordering of columns
![Reordering Columns in Blazor DataGrid](images/blazor-datagrid-reorder-column.gif)

> You can disable reordering a particular column by setting the [AllowReordering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_AllowReordering) property of **GridColumn** as false.

## Reorder single column

DataGrid has option to reorder single column either by Interaction or by using the [ReorderColumns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ReorderColumns_System_Collections_Generic_List_System_String__System_String_) method. In the following sample, **Freight** column is reordered to last column position by using the method.

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

<SfButton OnClick="ReorderBtn" CssClass="e-primary" IsPrimary="true" Content="Reorder Freight"></SfButton>
<SfGrid @ref="DefaultGrid" DataSource="@Orders" AllowReordering="true" AllowPaging="true" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerName) TextAlign="TextAlign.Center" HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Center" MinWidth="10" Width="120" MaxWidth="200"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" TextAlign="TextAlign.Center" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;

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

    public void ReorderBtn()
    {
        this.DefaultGrid.ReorderColumns("Freight", "OrderDate");
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerName { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

The following GIF represents Reordering column **Freight** by using method,
![Reordering Single Column in Blazor DataGrid](images/blazor-datagrid-reorder-single-column.gif)

## Reorder multiple columns

User can reorder a single column at a time by Interaction. Sometimes, you need to reorder multiple columns at the same time. This can be achieved programmatically by using the [ReorderColumns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ReorderColumns_System_Collections_Generic_List_System_String__System_String_) method.

In the following sample, **Customer Name** and **Freight** columns are reordered to last column position by using this method on button click.

```cshtml
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Grids

<SfButton OnClick="ReorderBtn" CssClass="e-primary" IsPrimary="true" Content="Reorder Customer Name and Freight"></SfButton>
<SfGrid @ref="DefaultGrid" DataSource="@Orders" AllowReordering="true" AllowPaging="true" Height="315">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerName) TextAlign="TextAlign.Center" HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Center" MinWidth="10" Width="120" MaxWidth="200"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" TextAlign="TextAlign.Center" Width="130" Type="ColumnType.Date"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> DefaultGrid;

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

    public void ReorderBtn()
    {
        this.DefaultGrid.ReorderColumns(new string[] {"CustomerName", "Freight"}, "OrderDate");
    }

    public class Order {
        public int? OrderID { get; set; }
        public string CustomerName { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```

The following GIF represents Reordering Columns **Freight** and **OrderDate** by using method
![Reordering Multiple Columns in Blazor DataGrid](images/blazor-datagrid-reorder-multiple-columns.gif)

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