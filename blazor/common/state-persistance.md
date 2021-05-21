---
layout: post
title: State Persistance in Blazor - Syncfusion
description: Check out the documentation for State Persistance in Blazor
platform: Blazor
component: Common
documentation: ug
---

# State Persistence

Syncfusion Blazor platform supports for persisting a component's state across page refreshes or navigation. To enable this feature, set the `EnablePersistence` property to true to the required component. This will store the component's state in the browser’s `localStorage` object on-page `unload` event. For example, persistence has been enabled to grid component in the following code.

{% tabs %}

{% highlight C# %}


@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" ID="grid" AllowPaging="true" AllowSorting="true" AllowFiltering="true" AllowGrouping="true" EnablePersistence="true">
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public List<Order> Orders { get; set; }

    protected override async Task OnInitializedAsync()
    {
        await base.OnInitializedAsync();
        Orders = Enumerable.Range(1, 25).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}



{% endhighlight %}

{% endtabs %}

> **Note:** The state of the component is retained during navigation or refreshment based on ID. Make sure to set an ID for the component to store the component's state in the browser.
