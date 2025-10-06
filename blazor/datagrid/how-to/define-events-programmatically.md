---
layout: post
title: Define events in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about defining events programmatically in the Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Define Grid events programmatically in Blazor DataGrid

In the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid, events are typically defined using the GridEvents child Razor component. As an alternative, Grid events can also be configured programmatically by accessing the Grid instance through a component reference. This method is useful when events need to be assigned dynamically during the application lifecycle.

To define events programmatically:

* Set a reference to the Grid using the `@ref` directive.
* After the Grid is rendered, assign the `GridEvents` property within the `OnAfterRenderAsync` lifecycle method.
* Use the `EventCallbackFactory` to create event handlers, ensuring they are correctly bound to the component context. 

The following example demonstrates how to configure the [DataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_DataBound) event programmatically to perform custom logic after the Grid's data has been populated:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders">
</SfGrid> 
@code{
    SfGrid<Order> Grid { get; set; } 
    public List<Order> Orders { get; set; }
    protected override Task OnAfterRenderAsync(bool firstRender) 
    { 
        if (Grid != null) 
        { 
            Grid.GridEvents = new GridEvents<Order>()
            {
                DataBound = new EventCallbackFactory().Create<object>(this, DataBoundHandler)
            };
        } 
        return base.OnAfterRenderAsync(firstRender); 
    } 
    public async Task DataBoundHandler()
    {
        await JS.InvokeVoidAsync("alert","Grid data loaded successfully.");
    }
    protected override void OnInitialized()
    {
        Orders = new List<Order>()
        {
            new Order() { OrderID = 1001, EmployeeID = 1, OrderDate = DateTime.Now.AddDays(-1), ShipCountry = "Sweden" },
            new Order() { OrderID = 1002, EmployeeID = 2, OrderDate = DateTime.Now.AddDays(-2), ShipCountry = "Germany" },
            new Order() { OrderID = 1003, EmployeeID = 3, OrderDate = DateTime.Now.AddDays(-3), ShipCountry = "Argentina" },
            new Order() { OrderID = 1004, EmployeeID = 4, OrderDate = DateTime.Now.AddDays(-4), ShipCountry = "Mexico" },
            new Order() { OrderID = 1005, EmployeeID = 5, OrderDate = DateTime.Now.AddDays(-5), ShipCountry = "Denmark" },
            new Order() { OrderID = 1006, EmployeeID = 6, OrderDate = DateTime.Now.AddDays(-6), ShipCountry = "Finland" },
            new Order() { OrderID = 1007, EmployeeID = 7, OrderDate = DateTime.Now.AddDays(-7), ShipCountry = "Switzerland" },
            new Order() { OrderID = 1008, EmployeeID = 8, OrderDate = DateTime.Now.AddDays(-8), ShipCountry = "UK" },
            new Order() { OrderID = 1009, EmployeeID = 9, OrderDate = DateTime.Now.AddDays(-9), ShipCountry = "Sweden" }
        };
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDVStoioTWEakEfK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}