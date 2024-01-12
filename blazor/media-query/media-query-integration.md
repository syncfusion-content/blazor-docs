---
layout: post
title: Media Query component Integration with other components | Syncfusion
description: Checkout and learn here all about how to integrate the Media Query with other component like Chart and much more details.
platform: Blazor
control: Media Query
documentation: ug
---

# Integrate Media Query with other components

You can integrate various components, such as the Chart and Grid, with `Media Query` to improve responsiveness. In the example below, the Grid component is utilized in conjunction with a Media Query to demonstrate its responsiveness. This is achieved by dynamically adjusting the `RowRenderingMode` property of the Grid based on the `activeBreakpoint` when the browser size is changed.

```cshtml

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

@{
    var RenderingMode = RowDirection.Horizontal;
    if (activeBreakPoint == "Small" || activeBreakPoint == "Medium")
    {
        RenderingMode = RowDirection.Vertical;
    }
    else
    {
        RenderingMode = RowDirection.Horizontal;
    }
}
<SfMediaQuery @bind-ActiveBreakpoint="activeBreakPoint"></SfMediaQuery>
<div style="position:relative; min-height: 500px;">
    <SfGrid DataSource="@Orders" RowRenderingMode="@RenderingMode" EnableAdaptiveUI=true Height="100%" Width="100%">
        <GridColumns>
            <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" Width="80"></GridColumn>
            <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
            <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" Width="130"></GridColumn>
            <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" Width="120"></GridColumn>
        </GridColumns>
    </SfGrid>
</div>

@code{
    private string activeBreakPoint { get; set; }
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 5).Select(x => new Order()
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

![Blazor Media Query integration in Grid](images/blazor-media-query-with-grid.gif)