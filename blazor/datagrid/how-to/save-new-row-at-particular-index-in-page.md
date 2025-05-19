---
layout: post
title: Saving a new row at a particular index of Blazor DataGrid | Syncfusion
description: Learn here all about saving a new row at a particular index of the Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Saving a new row at a particular index in Blazor DataGrid

By default, when a new row is added to the Syncfusion Blazor DataGrid, it is inserted and saved at the top of the Grid’s data source. However, certain use cases may require saving the newly added row at a different position—for example, at the end of the current page or a custom index based on business logic.

To achieve this customization, the `args.Index` property can be set during the [OnActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html) event of the Grid. This allows the developer to define the exact position where the new row should be saved in the underlying data source.

The following sample code demonstrates changing the save index of the new row that gets added in the Grid. Using `ActionBegin` event, `args.Index` property can be used to set the custom index for the saved new row. This allows the users to define the exact position where the new row should be saved in the underlying data source. 

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
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
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDByNfVYAhjTFmxS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}