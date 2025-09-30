---
layout: post
title: WebAssembly Performance in Blazor DataGrid Component | Syncfusion
description: Improve Blazor WebAssembly performance with the Syncfusion Blazor DataGrid using PreventRender, event-argument PreventRender, paging, virtualization, and key optimization practices.
platform: Blazor
control: DataGrid
documentation: ug
---

# WebAssembly performance in Blazor DataGrid

This section outlines performance guidelines for using the Syncfusion Blazor DataGrid efficiently in Blazor WebAssembly applications. General Blazor WebAssembly performance guidance is available in the [Microsoft documentation](https://learn.microsoft.com/aspnet/core/blazor/performance).

N> Refer to Getting Started for configuration details: [Blazor Server DataGrid](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio) and [Blazor WebAssembly DataGrid](https://blazor.syncfusion.com/documentation/datagrid/how-to/blazor-webassembly-datagrid-using-visual-studio)  using Visual Studio.

## Avoid unnecessary component renders

During the Blazor diffing process, each DataGrid cell and child component is evaluated for re-rendering. `Event callbacks` can trigger additional renders across the component tree. Fine-grained control over DataGrid rendering helps avoid unnecessary work.

Use [PreventRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PreventRender_System_Boolean_) on the DataGrid instance to skip participation in the next render cycle. This method internally affects the DataGrid’s [ShouldRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ShouldRender) behavior.

In the following example:

- PreventRender is called in a click callback.
- The DataGrid is excluded from the render cycle caused by the click, and only currentCount updates.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
<h1>Counter</h1>

<p>Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

<SfGrid @ref="grid" DataSource="@Orders" AllowPaging="true">
    <GridColumns>
        <GridColumn Type="ColumnType.CheckBox" Width="50"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="@nameof(OrderData.Verified)" DisplayAsCheckBox="true" Width="70"></GridColumn>
    </GridColumns>
</SfGrid>


@code {
    SfGrid<OrderData> grid { get; set; }
    private int currentCount = 0;
       public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }   

    private void IncrementCount()
    {
        grid.PreventRender();
        currentCount++;
    }
}

{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData() { }

    public OrderData(int orderID, string customerID, double freight, DateTime? orderDate)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.Freight = freight;
        this.OrderDate = orderDate;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", 32.38, new DateTime(1996, 7, 4)));
            Orders.Add(new OrderData(10249, "TOMSP", 11.61, new DateTime(1996, 7, 5)));
            Orders.Add(new OrderData(10250, "HANAR", 65.83, new DateTime(1996, 7, 6)));
            Orders.Add(new OrderData(10251, "VINET", 41.34, new DateTime(1996, 7, 7)));
            Orders.Add(new OrderData(10252, "SUPRD", 151.30, new DateTime(1996, 7, 8)));
            Orders.Add(new OrderData(10253, "HANAR", 58.17, new DateTime(1996, 7, 9)));
            Orders.Add(new OrderData(10254, "CHOPS", 22.98, new DateTime(1996, 7, 10)));
            Orders.Add(new OrderData(10255, "VINET", 148.33, new DateTime(1996, 7, 11)));
            Orders.Add(new OrderData(10256, "HANAR", 13.97, new DateTime(1996, 7, 12)));
        }
        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public bool Verified { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXVIZyWdAaNWlsFx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> - `PreventRender` accepts a Boolean argument to disable (true) or enable (false) participation in rendering.
> - Call `PreventRender` only after the DataGrid completes its initial render; calling during initial render has no effect.

## Avoid unnecessary component renders after Blazor DataGrid events

When callback methods are assigned to DataGrid events, the parent component re-renders once the event completes. To prevent re-rendering of the DataGrid in that cycle, set the [PreventRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.RowSelectEventArgs-1.html#Syncfusion_Blazor_Grids_RowSelectEventArgs_1_PreventRender) property on the corresponding event args to true (when available).

In the following example:

- [RowSelected](https://blazor.syncfusion.com/documentation/datagrid/events#rowselected) invokes a callback that would normally trigger `StateHasChanged` in the parent.
- Setting `RowSelectEventArgs<Order>.PreventRender` to `true` prevents the DataGrid from participating in that re-render.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
<p>Selected OrderID: <span style="color:red">@SelectedOrder.OrderID</span></p>

<SfGrid @ref="grid" DataSource="@Orders">
    <GridSelectionSettings PersistSelection="true"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Type="ColumnType.CheckBox" Width="50"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderID) IsPrimaryKey="true" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="@nameof(OrderData.Verified)" DisplayAsCheckBox="true" Width="70"></GridColumn>
    </GridColumns>
    <GridEvents TValue="OrderData" RowSelected="OnRowSelected"></GridEvents>
</SfGrid>


@code {
    SfGrid<OrderData> grid { get; set; }
    OrderData SelectedOrder = new OrderData { };

    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    } 

    private void OnRowSelected(RowSelectEventArgs<OrderData> args)
    {
        args.PreventRender = true; //Without this, you may see noticeable delay in selection with rows in Grid.
        SelectedOrder = args.Data;
    }
}

{% endhighlight %}
{% highlight c# tabtitle="OrderDetails.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData() { }

    public OrderData(int orderID, string customerID, double freight, DateTime? orderDate)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.Freight = freight;
        this.OrderDate = orderDate;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", 32.38, new DateTime(1996, 7, 4)));
            Orders.Add(new OrderData(10249, "TOMSP", 11.61, new DateTime(1996, 7, 5)));
            Orders.Add(new OrderData(10250, "HANAR", 65.83, new DateTime(1996, 7, 6)));
            Orders.Add(new OrderData(10251, "VINET", 41.34, new DateTime(1996, 7, 7)));
            Orders.Add(new OrderData(10252, "SUPRD", 151.30, new DateTime(1996, 7, 8)));
            Orders.Add(new OrderData(10253, "HANAR", 58.17, new DateTime(1996, 7, 9)));
            Orders.Add(new OrderData(10254, "CHOPS", 22.98, new DateTime(1996, 7, 10)));
            Orders.Add(new OrderData(10255, "VINET", 148.33, new DateTime(1996, 7, 11)));
            Orders.Add(new OrderData(10256, "HANAR", 13.97, new DateTime(1996, 7, 12)));
        }
        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public bool Verified { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjBoDIWnqvasLQsp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> - `args.PreventRender` affects rendering only for the event-triggered cycle and does not change component state beyond that cycle.
> - Prefer setting `PreventRender` to true for user-interactive events (for example, [RowSelected](https://blazor.syncfusion.com/documentation/datagrid/events#rowselected), [RowSelecting](https://blazor.syncfusion.com/documentation/datagrid/events#rowselecting)) to reduce UI latency. For events without args (for example, [DataBound](https://blazor.syncfusion.com/documentation/datagrid/events#databound)), call the grid’s `PreventRender` method.

## Use paging or virtualization to load only visible rows

The DataGrid renders each row and cell as a component. Rendering a large number of elements can impact memory and CPU. Load only what is visible using [Paging](./paging) or [Virtualization](./virtualization). Keep page sizes reasonable to avoid reintroducing performance bottlenecks even with these features enabled.

## Blazor WebAssembly optimization checklist

- Build for Release and enable optimizations; test with production builds for realistic performance.
- Consider ahead-of-time (AOT) compilation for CPU-bound workloads (trade-off: larger download size).
- Enable trimming and linker optimizations to reduce download size; remove unused assemblies and resources.
- Minimize re-renders:
  - Avoid frequent StateHasChanged; debounce or throttle input-driven updates.
  - Use ShouldRender/PreventRender patterns to control rendering.
  - Split large components; isolate frequently changing parts.
- Reduce DataGrid work per frame:
  - Prefer paging or virtualization over loading large datasets.
  - Limit number of visible columns and expensive templates; simplify cell templates where possible.
  - Avoid heavy synchronous work in rendering/event handlers; offload to async flows.
- Efficient data handling:
  - Reuse and cache data where feasible; avoid recreating large lists on every render.
  - Use immutable patterns carefully to avoid excessive allocations; update in place when appropriate.
- JS interop:
  - Batch calls; avoid chatty interop inside tight loops.
  - Defer non-critical interop to OnAfterRenderAsync.
- Networking and assets:
  - Enable response compression and HTTP caching for static assets.
  - Avoid shipping unnecessary resources; consider lazy-loading features or pages.
- Diagnostics:
  - Use browser dev tools and dotnet counters/tracing to identify bottlenecks.
  - Measure before and after changes; optimize based on evidence.

N> Even with paging or virtualization, very large page sizes can still cause performance issues. Choose sizes that balance usability and responsiveness.