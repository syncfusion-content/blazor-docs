---
layout: post
title: Row Drag and Drop in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Row Drag and Drop in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Row Drag and Drop in Blazor DataGrid Component

The grid row drag and drop allows you to drag and drop grid rows to another grid or custom component. To enable row drag and drop, set the [AllowRowDragAndDrop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowRowDragAndDrop) to true. The target component where the grid rows are to be dropped can be set by using the [TargetID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridRowDropSettings.html#Syncfusion_Blazor_Grids_GridRowDropSettings_TargetID).

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" id="Grid"  AllowSelection="true"  AllowRowDragAndDrop="true">
    <GridRowDropSettings TargetID="DestGrid"></GridRowDropSettings>
    <GridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" Width="110" IsPrimaryKey="true"> </GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Width="110" Type="ColumnType.Date"></GridColumn>
    </GridColumns>
</SfGrid>
<br>
<SfGrid DataSource="@SecondGrid"  id="DestGrid" AllowRowDragAndDrop="true" AllowSelection="true">
    <GridRowDropSettings TargetID="Grid"></GridRowDropSettings>
    <GridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" Width="110" IsPrimaryKey="true"> </GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Width="110" Type="ColumnType.Date"></GridColumn>
    </GridColumns>
</SfGrid>


@code {

    public List<Order> Orders { get; set; }
    public List<Order> SecondGrid { get; set; } = new List<Order>();

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 8).Select(x => new Order()
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

![Row Drag and Drop in Blazor DataGrid](./images/blazor-datagrid-row-drag-and-drop.gif)
<!-- {% previewsample "https://blazorplayground.syncfusion.com/embed/rjBgXxLMBrvcBuZj?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %} -->

N> * Selection feature must be enabled for row drag and drop.
<br/> * Multiple rows can be selected by clicking and dragging inside the grid. For multiple row selection, the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Type) property must be set to multiple.

## Drag and drop within Grid

The grid row drag and drop allows you to drag and drop grid rows on the same grid using drag icon. To enable row drag and drop, set the [AllowRowDragAndDrop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AllowRowDragAndDrop) to true.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" id="Grid"  AllowSelection="true"  AllowRowDragAndDrop="true">
 <GridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" Width="110" IsPrimaryKey="true"> </GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Width="110" Type="ColumnType.Date"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public List<Order> Orders { get; set; }
    public List<Order> SecondGrid { get; set; } = new List<Order>();

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 8).Select(x => new Order()
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

![Drag and Drop within Blazor DataGrid](./images/drag-and-drop-within-blazor-datagrid.gif)
<!-- {% previewsample "https://blazorplayground.syncfusion.com/embed/hXBqXdBiVAjFZkeZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %} -->

## Drag and Drop Between Two Grids with Different TValues

The DataGrid row drag and drop feature allow to drag and drop grid rows between two grids that have different TValues. Specify the target component for grid row dropping using the TargetID property .When TargetID property of GridRowDropSettings is defined, drag and drop within Grid cannot be performed. Handle the `RowDropped` event to perform operations when rows are dropped. In the RowDropped event handler, dropped records details can be accessed and manipulate the records as per the dropped Grid datatype.

Following a code example to how to implement drag and drop between two grids with different TValues using the between two DataGrid component.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid @ref="OGrid" DataSource="@Orders" ID="Grid" AllowSelection="true" Width="700" AllowRowDragAndDrop="true">
    <GridRowDropSettings TargetID="DestGrid"></GridRowDropSettings>
    <GridEvents RowDropped="OrderDropped" TValue="Order"></GridEvents>
    <GridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" Width="110" IsPrimaryKey="true"> </GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" Width="110"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Width="110" Type="ColumnType.Date"></GridColumn>
    </GridColumns>
</SfGrid>
<br>
<SfGrid @ref="DGrid" DataSource="@SecondGrid" ID="DestGrid" AllowRowDragAndDrop="true" Width="700" AllowSelection="true">
    <GridRowDropSettings TargetID="Grid"></GridRowDropSettings>
    <GridEvents RowDropped="EmployeeDropped" TValue="OrdersDetails"></GridEvents>
    <GridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Field=@nameof(OrdersDetails.ID) HeaderText="ID" Width="110" IsPrimaryKey="true"> </GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.Name) HeaderText="Name" Width="110"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.City) HeaderText="City" Width="110"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.Shipment) HeaderText="Shipment" Format="C2" Width="110"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetails.Date) HeaderText="Date" Format="d" Width="110" Type="ColumnType.Date"></GridColumn>
    </GridColumns>
</SfGrid>


@code {

    SfGrid<Order> OGrid { get; set; }
    SfGrid<OrdersDetails> DGrid { get; set; }

    public List<Order> Orders { get; set; }
    public List<OrdersDetails> SecondGrid { get; set; } = new List<OrdersDetails>();

    public async Task OrderDropped(RowDroppedEventArgs<Order> Args)
    {
        foreach (var val in Args.Data)
        {
            SecondGrid.Add(new OrdersDetails() { ID = val.OrderID, Name = val.CustomerID, Shipment = val.Freight, Date = val.OrderDate, City = val.ShipCity });
        }
       await DGrid.Refresh();
    }

    public async Task EmployeeDropped(RowDroppedEventArgs<OrdersDetails> Args)
    {
        foreach (var val in Args.Data)
        {
            Orders.Add(new Order() { OrderID = val.ID, CustomerID = val.Name, Freight = val.Shipment, OrderDate = val.Date, ShipCity = val.City });
        }
       await OGrid.Refresh();
    }
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 8).Select(x => new Order()
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
    public class OrdersDetails
    {
        public int? ID { get; set; }
        public string Name { get; set; }
        public string  City { get; set; }
        public DateTime? Date { get; set; }
        public double? Shipment { get; set; }
    }
}

```
![Drag and Drop Between Two Grids with Different TValues](./images/drag-and-drop-between-two-grids-with-different-TValues.gif)

## Drag and drop events

The following events are triggered while drag and drop the grid rows.

`RowDragStarting`  - Triggers when starts to drag the grid row.<br/>
`RowDropped`  -  Triggers when a drag element is dropped on the target element.<br/>
`RowDropping` - Triggers when the dragged elements are being dropped on the target element.

N> For performing row drag and drop action on the datagrid, any one of the columns should be defined as a primary key using the [IsPrimaryKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_IsPrimaryKey) property.

## Limitations

* Multiple rows can be drag and drop in the row selections basis.
* Single row is able to drag and drop in same grid without enable the row selection.
* Row drag and drop feature is not having built in support with sorting, filtering, hierarchy grid, row template and grouping features of grid.