---
layout: post
title: State Persistance in Blazor - Syncfusion
description: Check out the documentation for State Persistance in Blazor
platform: Blazor
component: Common
documentation: ug
---

# State Persistence

The Syncfusion Blazor library supports persisting a component's state across page refreshes or navigation. To enable this feature, set the `EnablePersistence` property to `true` to the required component. This will store the component's state in the browser’s `localStorage` object on-page `unload` event. For example, persistence has been enabled to the grid component in the following code.

> The state of a component will be retained during navigation or refreshment based on the ID. Make sure to set an ID for the component to store the component's state in the browser.

```cshtml
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
```

## State Persistance Supported Components and Properties

The following table demonstrates the list of Syncfusion Blazor components that are supported with state persistence and describes the list of properties stored in the `localStorage`.

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
<li>GridFilterSettings</li>
<li>GridSortSettings</li>
<li>GridGroupSettings</li>
<li>GridPageSettings</li>
</ul>
</td>
</tr>
</table>
<!-- markdownlint-enable MD033 -->