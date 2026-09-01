---
layout: post
title: Blazor Grid Define events programmatically | Syncfusion
description: Learn how to define GridEvents programmatically in Blazor Data Grid using component references and EventCallbackFactory for dynamic event binding.
platform: Blazor
control: DataGrid
documentation: ug
---

# Define events programmatically in Blazor Data Grid

In the [Blazor Data Grid](https://www.syncfusion.com/blazor-components/blazor-datagrid), events are typically defined using the [GridEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html) child Razor component. For scenarios where Data Grid events must be assigned dynamically during the application lifecycle, a component reference can be used to access the Data Grid instance and assign the `GridEvents` property from code.

> Note: Assigning **Grid.GridEvents** programmatically replaces any events declared via the `<GridEvents>` markup for that Data Grid instance.

To define events programmatically:

- Set a reference to the Data Grid by using the **@ref** directive.
- Assign the **GridEvents** property inside **OnAfterRenderAsync**, guarded by checking the **firstRender** parameter.
- Use **EventCallbackFactory** to bind handlers to the current component context.

> Columns in the following example are auto-generated from the **Order** model when the `Data Grid` renders, so `<GridColumns>` markup is not required.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@inject IJSRuntime JS

<SfGrid @ref="Grid" DataSource="@Orders">
</SfGrid>

@code {
    SfGrid<Order> Grid { get; set; }
    public List<Order> Orders { get; set; }

    protected override Task OnAfterRenderAsync(bool firstRender)
    {
        if (firstRender && Grid != null)
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
        await JS.InvokeVoidAsync("alert", "Grid data loaded successfully.");
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
        public string ShipCountry { get; set; }
    }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZBHjGjsskxheQCa?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## See also

* [Events in Blazor Data Grid](https://blazor.syncfusion.com/documentation/datagrid/events)
* [GridEvents<TValue> API reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html)