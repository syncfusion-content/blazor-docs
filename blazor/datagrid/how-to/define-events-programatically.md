---
layout: post
title: Define the events programmatically in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Define the events programmatically in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Define the GridEvents programmatically in DataGrid

GridEvents will be defined as child razor component to Grid component. Instead we can define the GridEvents programmatically using the Grid reference.

In the below demo, We have programmatically defined the [OnActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnActionBegin) event to prevent the edit action for certain records.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" Toolbar=@ToolbarItems>
    <GridEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true"></GridEditSettings>
</SfGrid> 
 
@code{
    SfGrid<Order> Grid { get; set; } 
    public List<Order> Orders { get; set; }
    public string[] ToolbarItems = new string[] { "Add", "Edit", "Delete", "Update", "Cancel" };

    protected override Task OnAfterRenderAsync(bool firstRender) 
    { 
        if (Grid != null) 
        { 
            Grid.GridEvents = new GridEvents<Order>() { OnActionBegin = new EventCallbackFactory().Create<ActionEventArgs<Order>>(this.Grid, ActionBeginHandler)}; 
        } 
        return base.OnAfterRenderAsync(firstRender); 
    } 
    public void ActionBeginHandler(ActionEventArgs<Order> args) 
    { 
        if (args.RequestType == Syncfusion.Blazor.Grids.Action.BeginEdit) 
        {
            if (args.RowData.ShipCountry == "Germany") {
                args.Cancel = true;
            }
        } 
    } 
    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 9).Select(x => new Order()
        {
            OrderID = 1000 + x,
            EmployeeID = x,
            OrderDate = DateTime.Now.AddDays(-x),
            ShipCountry = (new string[] { "Sweden", "Germany", "Argentina", "Mexico", "Denmark", "Finland", "Switzerland", "UK" })[new Random().Next(8)],
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public int? EmployeeID { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ShipCountry {  get;  set; }
    }
    }
```