---
layout: post
title: Blazor Grid WebAssembly Performance | Syncfusion
description: Learn how to optimize Blazor Data Grid WebAssembly performance using PreventRender, paging, virtualization, and rendering best practices.
platform: Blazor
control: DataGrid
documentation: ug
---

# WebAssembly Performance in Blazor Data Grid

This section outlines performance guidelines for using the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) efficiently in Blazor WebAssembly applications. General Blazor WebAssembly performance guidance is available in the [Microsoft documentation](https://learn.microsoft.com/en-us/aspnet/core/blazor/performance/?view=aspnetcore-10.0).

N> **Hosting model applicability:** The `PreventRender` API and the paging/virtualization guidance apply to both Blazor Server and Blazor WebAssembly. The examples on this page emphasize WebAssembly because the Blazor diffing cost is most noticeable in WebAssmembly. For hosting-model-specific tuning, also review the general [Microsoft Blazor performance guide](https://learn.microsoft.com/en-us/aspnet/core/blazor/performance/?view=aspnetcore-10.0).

N> Refer to the Getting Started pages for configuration details: [Blazor WebAssembly DataGrid](https://blazor.syncfusion.com/documentation/datagrid/getting-started) using Visual Studio.

## Avoid unnecessary component renders

During the Blazor diffing process, each DataGrid cell and child component is evaluated for re-rendering. `Event callbacks` can trigger additional renders across the component tree. Fine-grained control over DataGrid rendering helps avoid unnecessary work.

Use [PreventRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PreventRender_System_Boolean_) on the DataGrid instance to skip participation in the next render cycle. This method internally affects the DataGrid’s [ShouldRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ShouldRender) behavior.

> `PreventRender` must be called from a parent component (typically a click handler or event callback in the same Blazor render cycle) before the DataGrid is re-rendered. Calling it after the render has already completed, or from a child component the DataGrid does not share a render scope with, has no effect on that cycle.

In the following example:

- PreventRender is called in a click callback.
- The DataGrid is excluded from the render cycle caused by the click, and only currentCount updates.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
<p>Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

<SfGrid @ref="Grid" DataSource="@Orders" AllowPaging="true">
    <GridColumns>
        <GridColumn Type="ColumnType.CheckBox" Width="50"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="@nameof(OrderData.Verified)" DisplayAsCheckBox="true" Width="70"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private SfGrid<OrderData> Grid { get; set; }
    private int currentCount = 0;
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    private void IncrementCount()
    {
        Grid.PreventRender(true);
        currentCount++;
    }
}

{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtrntmNHrYKBrMhu?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

> - Pass **true** to `PreventRender` to skip the DataGrid’s participation in the next render cycle; pass **false** to render normally. The default value is **true**, so `PreventRender()` and `PreventRender(true)` are equivalent.
> - Call `PreventRender` only after the DataGrid completes its initial render; calling during initial render has no effect.

## Avoid unnecessary component renders after Blazor DataGrid events

When callback methods are assigned to DataGrid events, the parent component re-renders once the event completes. To prevent re-rendering of the DataGrid in that cycle, set the [PreventRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.RowSelectEventArgs-1.html#Syncfusion_Blazor_Grids_RowSelectEventArgs_1_PreventRender) property on the corresponding event args to true (when available). The sample below uses the [RowSelected](https://blazor.syncfusion.com/documentation/datagrid/events#rowselected) event to demonstrate this approach.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
<p>Selected OrderID: <span style="color:red">@SelectedOrder.OrderID</span></p>

<SfGrid DataSource="@Orders">
    <GridSelectionSettings PersistSelection="true"></GridSelectionSettings>
    <GridColumns>
        <GridColumn Type="ColumnType.CheckBox" Width="50"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderID) IsPrimaryKey="true" HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field="@nameof(OrderData.Verified)" DisplayAsCheckBox="true" Width="70"></GridColumn>
    </GridColumns>
    <GridEvents TValue="OrderData" RowSelected="OnRowSelected"></GridEvents>
</SfGrid>

@code {
    OrderData SelectedOrder = new OrderData();
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    private void OnRowSelected(RowSelectEventArgs<OrderData> args)
    {
        // Without PreventRender, the DataGrid re-renders on every selection,
        // which can cause noticeable delay when many rows are involved.
        args.PreventRender = true;
        SelectedOrder = args.Data;
    }
}

{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}

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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZLRDGNxBEqcogXh?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

> - Use the args-level `PreventRender` property for events that expose a typed args object with that member, for example [RowSelectEventArgs&lt;OrderData&gt;](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.RowSelectEventArgs-1.html) used by [RowSelected](https://blazor.syncfusion.com/documentation/datagrid/events#rowselected). Set it to **true** to reduce UI latency; the property affects rendering only for the event-triggered cycle and does not change component state beyond that cycle.
> - For events whose args type does not expose `PreventRender` (for example, [DataBound](https://blazor.syncfusion.com/documentation/datagrid/events#databound), which uses `DataBoundEventArgs<TValue>`), call the DataGrid’s `PreventRender` method instead.

## Use paging or virtualization to load only visible rows

The DataGrid renders each row and cell as a component. Rendering a large number of elements can impact memory and CPU. Load only what is visible using [Paging](https://blazor.syncfusion.com/documentation/datagrid/paging) or [Virtual scrolling](https://blazor.syncfusion.com/documentation/datagrid/virtual-scrolling), and keep page sizes reasonable so these features do not reintroduce performance bottlenecks. Even with these features enabled, very large page sizes can still cause performance issues — choose sizes that balance usability and responsiveness.