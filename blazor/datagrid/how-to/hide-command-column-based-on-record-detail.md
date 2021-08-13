---
layout: post
title: Hide the command column button on specific record | Syncfusion
description: Learn here how to hide command column in specific record based on its detail record in Syncfusion Blazor DataGrid.
platform: Blazor
control: DataGrid
documentation: ug
---

# Hide the command column button in a specific record

Command Columns can be used perform CRUD operation in Grid records. For some specific records, these editing actions can be prevented by hiding the command buttons. (i.e.) Some records can be prevented from edited, some records can be prevented from deleted. This can be achieved by hiding the command buttons in [`RowDataBound`](https://blazor.syncfusion.com/documentation/datagrid/events#rowdatabound) event of the DataGrid component.

This is demonstrated in the below sample code where the RowDataBound event is triggered when record is created. Based on record details, we can add specific class name to that row and hide the command buttons using CSS styles.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" Height="315">
    <GridEvents RowDataBound="RowBound" TValue="Order"></GridEvents>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn HeaderText="Manage Records" Width="150">
            <GridCommandColumns>
                <GridCommandColumn Type="CommandButtonType.Edit" ButtonOption="@(new CommandButtonOptions() { IconCss = "e-icons e-edit", CssClass = "e-flat" })"></GridCommandColumn>
                <GridCommandColumn Type="CommandButtonType.Delete" ButtonOption="@(new CommandButtonOptions() { IconCss = "e-icons e-delete", CssClass = "e-flat" })"></GridCommandColumn>
                <GridCommandColumn Type="CommandButtonType.Save" ButtonOption="@(new CommandButtonOptions() { IconCss = "e-icons e-update", CssClass = "e-flat" })"></GridCommandColumn>
                <GridCommandColumn Type="CommandButtonType.Cancel" ButtonOption="@(new CommandButtonOptions() { IconCss = "e-icons e-cancel-icon", CssClass = "e-flat" })"></GridCommandColumn>
            </GridCommandColumns>
        </GridColumn>
    </GridColumns>
</SfGrid>

<style>
    /*to remove the edit button alone*/
    .e-removeEditcommand .e-unboundcell .e-unboundcelldiv button.e-Editbutton {
        display: none;
    }

    /*to remove the delete button alone*/
    .e-removeDeletecommand .e-unboundcell .e-unboundcelldiv button.e-Deletebutton {
        display: none;
    }
</style>

@code{
    public List<Order> Orders { get; set; }
    public void RowBound(RowDataBoundEventArgs<Order> Args)
    {
        if (Args.Data.Verified)
        {
            Args.Row.AddClass(new string[] { "e-removeEditcommand" });
        }
        else
        {
            Args.Row.AddClass(new string[] { "e-removeDeletecommand" });
        }
    }
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
            Verified = (new bool[] { true, false })[new Random().Next(2)],
            ShipCountry = (new string[] { "USA", "UK", "CHINA", "RUSSIA", "INDIA" })[new Random().Next(5)]
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public bool Verified { get; set; }
        public string ShipCountry { get; set; }
    }
}
```
