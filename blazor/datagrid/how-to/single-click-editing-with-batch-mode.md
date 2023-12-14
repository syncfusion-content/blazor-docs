---
layout: post
title: Single click editing with Batch mode in Blazor DataGrid | Syncfusion
description: Learn here all about Single click editing with Batch mode in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Single Click Editing with Batch Mode in Blazor DataGrid Component

You can make a cell editable on a single click with a [Batch](https://blazor.syncfusion.com/documentation/datagrid/editing#batch) mode of editing in DataGrid by using the [EditCell](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EditCell_System_Double_System_String_) method.

Set the [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_Mode) property of **GridSelectionSettings** component to **Both** and bind the [CellSelected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_CellSelected) event to DataGrid. In the [CellSelected](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_CellSelected) event handler, call the [EditCell](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EditCell_System_Double_System_String_) method based on the clicked cell.

This is demonstrated in the following sample code,

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid @ref="GridInstance" AllowPaging="true" DataSource="@Orders" Toolbar="@(new List<string>() { "Cancel", "Update" })">
    <GridSelectionSettings Mode="Syncfusion.Blazor.Grids.SelectionMode.Both"></GridSelectionSettings>
    <GridEditSettings AllowEditing="true" Mode="EditMode.Batch"></GridEditSettings>
    <GridEvents CellSelected="CellSelectHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true"  TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    SfGrid<Order> GridInstance { get; set; }
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
            ShipCountry = (new string[] { "USA", "UK", "CHINA", "RUSSIA", "INDIA" })[new Random().Next(5)]
        }).ToList();
    }
    public async Task CellSelectHandler(CellSelectEventArgs<Order> args)
    {
        //get selected cell index
        var CellIndexes = await GridInstance.GetSelectedRowCellIndexes();

        //get the row and cell index
        var CurrentEditRowIndex = CellIndexes[0].Item1;
        var CurrentEditCellIndex = (int)CellIndexes[0].Item2;

        //get the available fields
        var fields = await GridInstance.GetColumnFieldNames();
        // edit the selected cell using the cell index and column name
        await GridInstance.EditCell(CurrentEditRowIndex, fields[CurrentEditCellIndex]);
    }
    public List<Order> Orders { get; set; }
    public class Order {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
    }
}
```
