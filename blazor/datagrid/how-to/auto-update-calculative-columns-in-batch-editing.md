---
layout: post
title: Update Calculative Columns in Blazor DataGrid Component | Syncfusion
description: Learn here all about how to auto-update calculative columns while using batch editing in the Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# How to Auto-Update the Calculative Columns While Using Batch Editing

A calculative column can be defined in Grid using the cell or column [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridColumn.html#Syncfusion_Blazor_Grids_GridColumn_Template) feature of Grid. Calculative columns can be auto-updated based on respective column value changes. You can update the column value based on another column's edited value in batch mode by using the [CellSaved](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_CellSaved) event and the [UpdateCell](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_UpdateCellAsync_System_Double_System_String_System_Object_) method of the Grid.

Also, the add operation is handled while performing batch editing using the boolean variable in [OnBatchAdd](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnBatchAdd) and [OnBatchSave](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnBatchSave) events of the Grid. In the following demo, the **Amount** and **Sum** column values are updated based on the **Quantity** and **UnitPrice** column values while batch editing.

```csharp
@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Delete", "Update", "Cancel" })" Height="315">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Batch">
    </GridEditSettings>
    <GridEvents CellSaved="CellSavedHandler" OnBatchAdd="BatchAddHandler" OnBatchSave="BatchSaveHandler" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" ValidationRules="@(new ValidationRules { Required = true })" Type="ColumnType.Number" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" ValidationRules="@(new ValidationRules{ Required=true})" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.Quantity) HeaderText="Quantity" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.UnitPrice) HeaderText="UnitPrice" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.Amount) HeaderText="Amount" Format="C2" AllowEditing="false" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120">
            <Template>
                @{
                    var value = (context as Order);
                    var res = value.Quantity * value.UnitPrice;
                    value.Amount = value.Quantity * value.UnitPrice;
                    <span>@value.Amount</span>
                }
            </Template>
        </GridColumn>
        <GridColumn Field=@nameof(Order.Sum) HeaderText="Sum" Format="C2" AllowEditing="false" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120">
            <Template>
                @{
                    var value = (context as Order);
                    var res = value.Quantity + value.UnitPrice;
                    value.Sum = value.Quantity + value.UnitPrice;
                    <span>@value.Sum</span>
                }
            </Template>
        </GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    SfGrid<Order> Grid;
    bool IsAdd { get; set; }
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Verified = (new bool[] { true, false })[new Random().Next(2)],
            Quantity = 1 * x,
            UnitPrice = 2 * x,
            OrderDate = DateTime.Now.AddDays(-x),
            ShipCountry = (new string[] { "USA", "UK", "CHINA", "RUSSIA", "INDIA" })[new Random().Next(5)]
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public int? Quantity { get; set; }
        public double? UnitPrice { get; set; }
        public double? Amount { get; set; }
        public double? Sum { get; set; }
        public string ShipCountry { get; set; }
        public bool Verified { get; set; }
    }
    public async Task CellSavedHandler(CellSaveArgs<Order> args)
    {
        var index = await Grid.GetRowIndexByPrimaryKey(args.RowData.OrderID);
        if (args.ColumnName == "Quantity")
        {
            if (IsAdd)
            {
                args.RowData.Quantity = (int?)args.Value;
                await Grid.UpdateCell(index, "Amount", Convert.ToInt32(args.Value) * 1);
                await Grid.UpdateCell(index, "Sum", Convert.ToInt32(args.Value) + 0);
            }
            await Grid.UpdateCell(index, "Amount", Convert.ToInt32(args.Value) * args.RowData.UnitPrice);
            await Grid.UpdateCell(index, "Sum", Convert.ToInt32(args.Value) + args.RowData.UnitPrice);
        }
        else if (args.ColumnName == "UnitPrice")
        {
            if (IsAdd)
            {
                args.RowData.UnitPrice = (double?)args.Value;
                await Grid.UpdateCell(index, "Amount", Convert.ToDouble(args.Value) * 1);
                await Grid.UpdateCell(index, "Sum", Convert.ToDouble(args.Value) + 0);
            }
            await Grid.UpdateCell(index, "Amount", Convert.ToDouble(args.Value) * args.RowData.Quantity);
            await Grid.UpdateCell(index, "Sum", Convert.ToDouble(args.Value) + args.RowData.Quantity);
        }
    }

    public void BatchAddHandler(BeforeBatchAddArgs<Order> args)
    {
        IsAdd = true;
    }
    public void BatchSaveHandler(BeforeBatchSaveArgs<Order> args)
    {
        IsAdd = false;
    }
}

```