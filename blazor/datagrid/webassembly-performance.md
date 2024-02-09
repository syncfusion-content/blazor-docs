---
layout: post
title: WebAssembly Performance in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about WebAssembly Performance in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# WebAssembly Performance in Blazor DataGrid Component

This section provides performance guidelines for using Syncfusion data grid component efficiently in Blazor WebAssembly application. The general framework Blazor WebAssembly performance best practice/guidelines can be found [here](https://learn.microsoft.com/en-us/aspnet/core/blazor/performance?view=aspnetcore-7.0).

N> You can refer to our Getting Started with [Blazor Server-Side DataGrid](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio) and [Blazor WebAssembly DataGrid](https://blazor.syncfusion.com/documentation/datagrid/how-to/blazor-webassembly-datagrid-using-visual-studio) documentation pages for configuration specifications.

## Avoid unnecessary component renders

During Blazor diffing algorithm, every cell of the grid component and its child component will be checked for re-rendering. For instance, having **EventCallBack** on the application or grid will check every child component once event callback is completed.

You can have fine-grained control over grid component rendering. **PreventRender** method help you to avoid unnecessary re-rendering of the grid component. This method internally overrides the **ShouldRender** method of the grid to prevent rendering.

In the following example:

* **PreventRender** method is called in the **IncrementCount** method which is a click callback.
* Now grid component will not be a part of the rendering which happens as result of the click event and **currentCount** alone will get updated.

```cshtml
<h1>Counter</h1>

<p>Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

<SfGrid @ref="grid" DataSource="@Orders" AllowPaging="true">
    <GridColumns>
        <GridColumn Type="ColumnType.CheckBox" Width="50"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="@nameof(Order.Verified)" DisplayAsCheckBox="true" Width="70"></GridColumn>
    </GridColumns>
</SfGrid>


@code {
    SfGrid<Order> grid { get; set; }
    private int currentCount = 0;
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
            Verified = (new bool[] { true, false })[new Random().Next(2)]
        }).ToList();
    }

    private void IncrementCount()
    {
        grid.PreventRender();
        currentCount++;
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public bool Verified { get; set; }
    }

}
```

N> * **PreventRender** method accepts boolean argument that accepts true or false to disable or enable rendering respectively.
<br/> * **PreventRender** method can be used only after grid component completed initial rendering. Calling this method during initial rendering will not have any effect.

## Avoid unnecessary component renders after grid events

When a callback method is assigned to the grid events, then the **StateHasChanged** will be called in parent component of the grid automatically once the event is completed.

You can prevent this re-rendering of the grid component by setting **PreventRender** property of the corresponding event argument as true.

In the following example:

* **RowSelected** event is bound with a callback method, so once row selection event is completed the **StateHasChanged** will be invoked for the parent component.
* `RowSelectEventArgs<Order>.PreventRender` is set as **true** so now grid will not be part of the **StateHasChanged** invoked as result of the grid.

```cshtml
<p>Selected OrderID: <span style="color:red">@SelectedOrder.OrderID</span></p>

<SfGrid @ref="grid" DataSource="@Orders">
    <GridSelectionSettings PersistSelection="true"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Type="ColumnType.CheckBox" Width="50"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderID) IsPrimaryKey="true" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="@nameof(Order.Verified)" DisplayAsCheckBox="true" Width="70"></GridColumn>
    </GridColumns>
    <GridEvents TValue="Order" RowSelected="OnRowSelected"></GridEvents>
</SfGrid>


@code {
    SfGrid<Order> grid { get; set; }
    public List<Order> Orders { get; set; }
    Order SelectedOrder = new Order { };

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 75).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
            Verified = (new bool[] { true, false })[new Random().Next(2)]
        }).ToList();
    }

    private void OnRowSelected(RowSelectEventArgs<Order> args)
    {
        args.PreventRender = true; //without this, you may see noticeable delay in selection with 75 rows in grid.
        SelectedOrder = args.Data;
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public bool Verified { get; set; }
    }
}
```

N> * **PreventRender** property internally overrides the **ShouldRender** method of the grid to prevent rendering.
<br/> * It is recommended to set **PreventRender** as true for user interactive events such as RowSelected, RowSelecting etc. for better performance.
<br/> * For events without any argument such as **DataBound**, you can use **PreventRender** method of the grid to disable rendering.

## Use paging or virtualization to load only visible rows

Grid renders each row and cell as individual component and loading large number of rows and cells in view will have performance impact on both memory consumption and CPU processing.

To use grid without such performance impacts, you can load reduced set of rows in the grid using [paging](./paging) and [virtualization](./virtualization) features.

N> Even though with paging or virtualization feature enabled, having hundreds of rows in single grid page will again introduce performance lag in the application, so you need to set reasonable page size.