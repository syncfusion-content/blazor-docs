---
layout: post
title: Define events in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about defining events programmatically in the Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Define the GridEvents Programmatically in DataGrid

In the Syncfusion Blazor DataGrid, events are typically defined using the GridEvents child Razor component. As an alternative, Grid events can also be configured programmatically by accessing the Grid instance through a component reference. This method is useful when events need to be assigned dynamically during the application lifecycle.

To define events programmatically, a reference to the Grid is set using the `@ref` directive. After the Grid is rendered, the `GridEvents` property can be assigned within the `OnAfterRenderAsync` lifecycle method. The event handlers are created using the `EventCallbackFactory`, which ensures the handlers are properly bound.

The following example demonstrates how to configure the [OnActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnActionBegin) event programmatically to prevent editing a record when the **ShipCountry** field value is **Germany**. In this example, the Grid allows editing, adding, and deleting records, but cancels the edit action conditionally based on the row data.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
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

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZrSXTBPKfxfVRJl?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}