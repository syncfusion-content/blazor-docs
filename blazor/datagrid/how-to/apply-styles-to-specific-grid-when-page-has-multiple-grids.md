---
layout: post
title: Apply styles to the specific grid when the page has multiple DataGrid Component| Syncfusion
description: Checkout and learn here all about Apply styles to the specific grid when page the has multiple grids in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Apply styles to the specific grid when the page has multiple DataGrid Component

To apply specific styles to a particular DataGrid component when a page contains multiple grids, define the **ID** property of the Grid or specify a custom class name for the Grid component. Once the **ID** property or custom class name is assigned to Grid using CSS selectors, the DataGrid component can be identified and styles can be applied to it.

Following a code example to demonstrate how to apply a specific style to a header cell in a particular Grid component.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid class="custom-grid" DataSource="@Orders" AllowPaging="true">

    <GridPageSettings PageSize="5"></GridPageSettings>

    <GridColumns>

        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>

        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>

        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.DateOnly" TextAlign="TextAlign.Right" Width="130"></GridColumn>

        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>

    </GridColumns>

</SfGrid>

<SfGrid ID="Grid" DataSource="@Orders" AllowPaging="true">

    <GridPageSettings PageSize="5"></GridPageSettings>

    <GridColumns>

        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>

        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>

        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.DateOnly" TextAlign="TextAlign.Right" Width="130"></GridColumn>

        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>

    </GridColumns>

</SfGrid>

<style>
    /*add style to the header cell with grid id  */
    #Grid .e-headercelldiv {
        color: red;
    }
    
    /*add style to the header cell with a custom class name*/
    .e-grid.custom-grid .e-headercelldiv {
        color: blue;
    }

</style>

@code {
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
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
{% previewsample "https://blazorplayground.syncfusion.com/embed/LNBgtFZiBVRDgdee?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}







