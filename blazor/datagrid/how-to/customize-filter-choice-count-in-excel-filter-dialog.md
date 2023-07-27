---
layout: post
title: Items count for Excel filter in Blazor DataGrid | Syncfusion
description: Learn here all about customizing filter choice items count for Excel filter dialog in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Filter Choice Items Count for Excel filter in Blazor DataGrid

For better performance, excel filter will take only the first 1000 records for filter choices item list. So, the distinct values of first thousand records will only be displayed in excel filter dialog as filter choices.

To overcome this default behavior, you can customize the count of filter choice items to be displayed in Excel filter dialog by setting the `FilterChoiceCount` in [OnActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html) event handler.

This is demonstrated in the following sample code,

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid @ref="GridInstance" AllowFiltering="true" AllowPaging="true" DataSource="@Orders">
    <GridFilterSettings Type="FilterType.Excel"></GridFilterSettings>
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
        if (args.RequestType.ToString() == "FilterChoiceRequest")
        {
            args.FilterChoiceCount = 2;    //here you can override the default take count
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
```

<!-- {% previewsample "https://blazorplayground.syncfusion.com/embed/VDBKtxhwzVqLwlZk?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %} -->