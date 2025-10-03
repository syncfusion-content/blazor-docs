---
layout: post
title: State Persistence in Blazor - Syncfusion
description: Learn how to enable state persistence using the browser's localStorage for supported Syncfusion Blazor components and which properties are saved.
platform: Blazor
control: Common
documentation: ug
---

# State Persistence in Blazor

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor library supports persisting a component's state across page refreshes and navigation. To enable this feature, set the `EnablePersistence` property to `true` on the target component. The component's state is saved to the browser's `localStorage` when the page unloads. The following example enables persistence for the Grid component.

N> The state of a component will be retained during navigation or refreshment based on the ID. Make sure to set an ID for the component to store the component's state in the browser.

{% tabs %}
{% highlight razor %}
@using Syncfusion.Blazor.Grids

<SfGrid  ID="grid" EnablePersistence="true" AllowPaging="true" DataSource="@Orders">
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Width="100"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) Format="C2" Width="120"></GridColumn>
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

## State persistence supported components and properties

The following table lists the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components that support state persistence and the properties saved in `localStorage`.

<!-- markdownlint-disable MD033 -->
<table>
<tr>
<td><b>Component Name</b></td>
<td><b>Properties</b></td>
</tr>
<tr>
<td>SfGrid</td>
<td>
<ul>
<li>Columns</li>
<li>FilterSettings</li>
<li>SortSettings</li>
<li>GroupSettings</li>
<li>PageSettings</li>
<li>SearchSettings</li>
</ul>
</td>
</tr>
<tr>
<td>SfMaps</td>
<td>
<ul>
<li>ZoomSettings</li>
<li>CenterPosition</li>
</ul>
</td>
</tr>
<tr>
<td>SfPivotView</td>
<td>
<ul>
<li>DataSourceSettings</li>
<li>GridSettings</li>
<li>ChartSettings</li>
<li>DisplayOptions</li>
</ul>
</td>
</tr>
<tr>
<td>SfTreeGrid</td>
<td>
<ul>
<li>Columns</li>
<li>FilterSettings</li>
<li>PageSettings</li>
<li>SearchSettings</li>
<li>SortSettings</li>
</ul>
</td>
</tr>
</table>
<!-- markdownlint-enable MD033 -->