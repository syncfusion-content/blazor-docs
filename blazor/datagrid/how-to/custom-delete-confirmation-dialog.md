---
layout: post
title: Custom delete confirmation dialog in Blazor DataGrid | Syncfusion
description: Learn here all about Custom delete confirmation dialog in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Custom delete confirmation dialog in Blazor DataGrid Component

You can customize the appearance and contents of delete confirmation dialog by rendering a customized [`SfDialog`](https://blazor.syncfusion.com/documentation/dialog/getting-started/) instead of the default grid delete confirmation dialog.

This is demonstrated in the below sample code,

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Popups

<SfDialog @ref="Dialog" Width="250px" Visible="false" ShowCloseIcon="true" IsModal="true">
    <DialogEvents Closed="Closed"></DialogEvents>
    <DialogTemplates>
        @*Here you can customize the Header and Content of delete confirmation dialog*@
        <Header> Delete Record</Header>
        <Content> You are about to Delete a Record @SelectedData ?</Content>
    </DialogTemplates>
    <DialogButtons>
        <DialogButton OnClick="@OkClick">
            <DialogButtonModel Content="OK" IsPrimary="true"></DialogButtonModel>
        </DialogButton>
        <DialogButton OnClick="@CancelClick">
            <DialogButtonModel Content="Cancel"></DialogButtonModel>
        </DialogButton>
    </DialogButtons>
</SfDialog>

<SfGrid @ref="Grid" DataSource="@Orders" AllowPaging="true" Toolbar="@(new List<string>() { "Delete" })" Height="315">
    <GridEvents OnActionBegin="OnActionBegin" RowSelected="RowSelectHandler" TValue="Order"></GridEvents>
    <GridEditSettings AllowDeleting="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    SfGrid<Order> Grid;
    SfDialog Dialog;
    public List<Order> Orders { get; set; }
    public object SelectedData;
    public bool flag = true;
    public void Closed()
    {
        flag = true;
    }
    public void OnActionBegin(ActionEventArgs<Order> Args)
    {
        if (Args.RequestType.ToString() == "Delete" && flag)
        {
            Args.Cancel = true;  //cancel default delete action
            Dialog.Show();
            flag = false;
        }
    }
    public void RowSelectHandler(RowSelectEventArgs<Order> Args)
    {
        SelectedData = Args.Data.OrderID;
    }
    private void OkClick()
    {
        Grid.DeleteRecord();   //delete the record programatically while clikcing OK button
        Dialog.Hide();
    }
    private void CancelClick()
    {
        Dialog.Hide();
    }
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
    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
    }
}
```