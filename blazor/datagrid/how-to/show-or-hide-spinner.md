---
layout: post
title: Show or Hide spinner in Blazor DataGrid | Syncfusion
description: Learn here all about Show or Hide spinner in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# How to hide default spinner and show customize spinner

It is possible to hide the default spinner in Grid and show the customized spinner in Grid. You can hide the default spinner in Grid using the below CSS style.

```cshtml
<style> 
    .e-grid .e-spinner-pane{ // Hide the Grid spinner.
          display:none; 
     } 
</style>
```

You can show or hide the customized spinner based on the specific actions like initial load or data bind or performing any data operations. These actions can be performed by using the [OnLoad](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnLoad), [DataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_DataBound), and [OnActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnActionBegin) events.

The `ShowAsync` and `HideAsync` methods of the `SfSpinner` have been used in the `OnLoad`, `DataBound`, and `OnActionBegin` events of the Grid to show and hide the customized spinner in the following sample.

```cshtml
@using Syncfusion.Blazor.Spinner
@using Syncfusion.Blazor.Grids

<SfSpinner @ref="SpinnerObj" CssClass="e-spin-overlay">    
</SfSpinner>

<SfGrid DataSource="@Orders" AllowPaging="true" AllowSorting="true" Height="315">
    <GridEvents OnLoad="OnLoad" DataBound="DataBound" OnActionBegin="OnActionBegin" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }
    SfSpinner SpinnerObj;
    public async void OnLoad()
    {
        SpinnerObj.ShowAsync(); // Show the spinner using initial Grid load.   
    }
    public async void DataBound()
    {
       SpinnerObj.HideAsync(); // Hide the spinner after the data is bound to Grid(during data operations also this will be triggered).
    }
    public void OnActionBegin(ActionEventArgs<Order> args)
    {
        if (args.RequestType.ToString() == "Sorting") // Based on request type, show the spinner when sorting action starts.
        {
            SpinnerObj.ShowAsync();
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

<style>
    .e-grid .e-spinner-pane {
        display: none;
    }
</style>

```