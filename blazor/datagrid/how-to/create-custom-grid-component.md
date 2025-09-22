---
layout: post
title: Create a custom Grid component in Blazor DataGrid | Syncfusion
description: Learn how to build a reusable custom Grid component that wraps SfGrid in Blazor to share default paging, sorting, and layout settings across your application.
platform: Blazor
control: DataGrid
documentation: ug
---

# Create custom Blazor DataGrid

Create a reusable custom Grid component by wrapping the `SfGrid` in a Razor component. This approach helps apply consistent defaults (for example, paging and sorting) and common settings across multiple Grids without repeating configuration.

The following example creates a `CustomGrid` wrapper that renders `SfGrid` with default properties such as `GridPageSettings`. Any unmatched attributes passed to `CustomGrid` are forwarded to the inner `SfGrid`, and content placed inside `CustomGrid` is projected as columns via `ChildContent`.

CustomGrid.razor

```cshtml
@using Syncfusion.Blazor.Grids
@typeparam TItem

<SfGrid TItem="TItem"
        DataSource="DataSource"
        AllowSorting="AllowSorting"
        AllowPaging="AllowPaging"
        @attributes="AdditionalAttributes">
    <GridPageSettings PageCount="@PAGE_COUNT"
                      PageSize="@DEFAULT_PAGE_SIZE"
                      PageSizes="PageSizes">
    </GridPageSettings>
    @ChildContent
</SfGrid>
```

CustomGrid.razor.cs

```csharp
using Microsoft.AspNetCore.Components;
using Syncfusion.Blazor.Grids;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SF_Grid_Inheritance.Shared
{
    public partial class CustomGrid<TItem> : ComponentBase
    {
        public const int PAGE_COUNT = 5;
        public const int DEFAULT_PAGE_SIZE = 10;

        [Parameter] public IEnumerable<TItem>? DataSource { get; set; }
        [Parameter] public bool AllowPaging { get; set; } = true;
        [Parameter] public bool AllowSorting { get; set; } = true;
        [Parameter] public string[] PageSizes { get; set; } = new[] { "10", "20", "50" };
        [Parameter] public RenderFragment? ChildContent { get; set; }

        // Forwards any additional attributes/events to the inner SfGrid
        [Parameter(CaptureUnmatchedValues = true)]
        public IReadOnlyDictionary<string, object>? AdditionalAttributes { get; set; }
    }
}
```

Index.razor

```razor
@using SF_Grid_Inheritance.Shared
@using Syncfusion.Blazor.Grids

<CustomGrid DataSource="Orders" TItem="Order">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
    </GridColumns>
</CustomGrid>

@code{
    public List<Order> Orders { get; set; } = new();
    private static readonly Random _random = new Random();

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[_random.Next(5)],
            Freight = Math.Round(2.1 * x, 2),
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