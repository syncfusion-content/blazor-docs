---
layout: post
title: Saving a new row at a particular index of the grid page
description: Learn how to save the newly added row at a particular index of the grid page in Blazor DataGrid component
platform: Blazor
component: DataGrid
documentation: ug
---

# Saving a new row at a particular index of the grid page

By default, a newly added row will be saved at the top of the datagrid. You can change it by setting the `args.Index` in [`OnActionBegin`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html) handler.

The following sample code demonstrates changing the save index of the new row that gets added in the DataGrid component,

{% tabs %}

{% highlight C# %}

@using Syncfusion.Blazor.Grids
@using Action = Syncfusion.Blazor.Grids.Action

<SfGrid @ref="GridInstance" AllowPaging="true" DataSource="@Orders" Toolbar="@(new List<string>() { "Add","Edit","Delete","Update","Cancel" })">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" NewRowPosition="NewRowPosition.Bottom"></GridEditSettings>
    <GridEvents OnActionBegin="OnActionBegin" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" EditType="EditType.NumericEdit" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" EditType="EditType.DropDownEdit" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    SfGrid<Order> GridInstance { get; set; }
    public List<Order> Orders { get; set; }
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
    public void OnActionBegin(ActionEventArgs<Order> args)
    {
        if (args.RequestType.Equals(Action.Save) && args.Action == "Add")
        {
            //Here you can set the custom index for the saved new row. Below calculation save the new row as last row of current page.
            args.Index = (GridInstance.PageSettings.CurrentPage * GridInstance.PageSettings.PageSize) - 1;
        }
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

{% endtabs  %}