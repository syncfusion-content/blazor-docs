---
layout: post
title: Hide the command column button on specific record | Syncfusion
description: Learn here how to hide command column in specific record based on its detail record in Syncfusion Blazor DataGrid.
platform: Blazor
control: DataGrid
documentation: ug
---

# Hide the Command Column Button in a Specific Record

In the Syncfusion Blazor DataGrid, command columns are used to perform CRUD operations on records, such as editing or deleting. Sometimes, you may want to hide the command buttons for specific records based on certain conditions. This can be done by using the [`RowDataBound`](https://blazor.syncfusion.com/documentation/datagrid/events#rowdatabound) event, which is triggered every time a row is created or updated in the Grid.

Inside the `RowDataBound` event, you can check the data of each record and conditionally add a class to the row. For example, if a record is marked as "Verified," you can add a class to hide the Edit button for that row. Similarly, you can add another class to hide the Delete button for unverified records.

To hide the buttons, you can use CSS to target the added class and apply the **display: none** style to the buttons. This method gives you control over which buttons are shown or hidden for each record, depending on the data. This way, you can easily prevent editing or deleting certain rows based on your application's requirements.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
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
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXLetprbTsENCfsy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}