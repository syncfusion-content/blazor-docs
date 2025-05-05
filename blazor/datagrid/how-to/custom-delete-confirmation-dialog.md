---
layout: post
title: Custom delete confirmation dialog in Blazor DataGrid | Syncfusion
description: Learn here all about custom delete confirmation dialog in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Custom Delete Confirmation Dialog in Blazor DataGrid

You can replace the default delete confirmation dialog in the Syncfusion Blazor DataGrid with a custom dialog to control its content, appearance, and behavior. This allows you to customize the delete confirmation message and provide your own buttons for confirming or canceling the deletion.

To achieve this, use the [SfDialog](https://blazor.syncfusion.com/documentation/dialog/getting-started) from the Blazor Popups package. Inside the `SfDialog`, you can define the dialog header, content, and buttons using `DialogTemplates` and `DialogButtons`. The dialog should be initially hidden and only shown when the user triggers a delete action on a record.

In the `SfGrid`, enable the "Delete" option in the toolbar and set the `AllowDeleting` property to true to allow record deletion. You can then use the [OnActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnActionBegin) event to cancel the default delete action, display the custom dialog, and handle the user's response. When the user clicks the "OK" button on the dialog, the selected record is deleted programmatically.

Here is the code for implementing a custom delete confirmation dialog in a Grid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Popups

<SfDialog @ref="Dialog" Width="250px" Visible="@IsDialogVisible" ShowCloseIcon="true" IsModal="true">
    <DialogEvents Closed="Closed"></DialogEvents>
    <DialogTemplates>
        <Header>Delete Record</Header>
        <Content>You are about to delete the record @SelectedData ?</Content>
    </DialogTemplates>
    <DialogButtons>
        <DialogButton OnClick="@OkClick" Content="OK" IsPrimary="true"></DialogButton>
        <DialogButton OnClick="@CancelClick" Content="Cancel"></DialogButton>
    </DialogButtons>
</SfDialog>

<SfGrid @ref="Grid" DataSource="@Orders" AllowPaging="true" Toolbar="@(new List<string>() { "Delete" })" Height="315">
    <GridEvents OnActionBegin="OnActionBegin" RowSelected="RowSelectHandler" TValue="Order"></GridEvents>
    <GridEditSettings AllowDeleting="true" Mode="EditMode.Normal"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<Order> Grid;
    private SfDialog Dialog;
    private List<Order> Orders { get; set; }
    private object SelectedData;
    private bool flag = true;
    private bool IsDialogVisible = false;
    private void Closed()
    {
        flag = true;
    }
    private async Task OnActionBegin(ActionEventArgs<Order> Args)
    {
        if (Args.RequestType == Action.Delete && flag)
        {
            Args.Cancel = true;
            IsDialogVisible = true;
            StateHasChanged(); // Re-render to show dialog.
            flag = false;
        }
    }
    private void RowSelectHandler(RowSelectEventArgs<Order> Args)
    {
        SelectedData = Args.Data.OrderID;
    }
    private async Task OkClick()
    {
        await Grid.DeleteRecordAsync();
        IsDialogVisible = false;
        StateHasChanged();
    }
    private void CancelClick()
    {
        IsDialogVisible = false;
        StateHasChanged();
    }
    protected override void OnInitialized()
    {
        var random = new Random();
        Orders = Enumerable.Range(1, 75).Select(x => new Order
        {
            OrderID = 1000 + x,
            CustomerID = (new[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[random.Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
            ShipCountry = (new[] { "USA", "UK", "CHINA", "RUSSIA", "INDIA" })[random.Next(5)]
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
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXhejzVuAeUpKESj?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
