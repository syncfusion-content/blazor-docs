---
layout: post
title: WebAssembly Performance in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about webAssembly performance in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# WebAssembly Performance in Blazor DataGrid

This section provides performance guidelines for using Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid efficiently in Blazor WebAssembly application. The general framework Blazor WebAssembly performance best practice/guidelines can be found [here](https://learn.microsoft.com/en-us/aspnet/core/blazor/performance?view=aspnetcore-7.0).

N> You can refer to our Getting Started with [Blazor Server-Side DataGrid](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio) and [Blazor WebAssembly Grid](https://blazor.syncfusion.com/documentation/datagrid/how-to/blazor-webassembly-datagrid-using-visual-studio) documentation pages for configuration specifications.

## Avoid unnecessary component renders

During Blazor diffing algorithm, every cell of the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid and its child component will be checked for re-rendering. For instance, having **EventCallBack** on the application or Grid will check every child component once event callback is completed.

You can have fine-grained control over Grid rendering. [PreventRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PreventRender_System_Boolean_) method help you to avoid unnecessary re-rendering of the Grid. This method internally overrides the [ShouldRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ShouldRender) method of the Grid to prevent rendering. 

In the following example:

* `PreventRender` method is called in the **IncrementCount** method which is a click callback.
* Now Grid will not be a part of the rendering which happens as result of the click event and **currentCount** alone will get updated.

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

>* `PreventRender` method accepts boolean argument that accepts true or false to disable or enable rendering respectively.
>* `PreventRender` method can be used only after Grid completed initial rendering. Calling this method during initial rendering will not have any effect.

## Avoid unnecessary component renders after Blazor DataGrid events

When a callback method is assigned to the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid events, then the **StateHasChanged** will be called in parent component of the Grid automatically once the event is completed.

You can prevent this re-rendering of the Grid by setting [PreventRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_PreventRender_System_Boolean_) property of the corresponding event argument as true.

In the following example:

* [RowSelected](https://blazor.syncfusion.com/documentation/datagrid/events#rowselected) event is bound with a callback method, so once row selection event is completed the **StateHasChanged** will be invoked for the parent component.
* `RowSelectEventArgs<Order>.PreventRender` is set as **true** so now Grid will not be part of the **StateHasChanged** invoked as result of the Grid.

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

>* `PreventRender` property internally overrides the [ShouldRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ShouldRender) method of the Grid to prevent rendering.
>* It is recommended to set `PreventRender` as true for user interactive events such as [RowSelected](https://blazor.syncfusion.com/documentation/datagrid/events#rowselected), [RowSelecting](https://blazor.syncfusion.com/documentation/datagrid/events#rowselecting) etc. for better performance.
>* For events without any argument such as [DataBound](https://blazor.syncfusion.com/documentation/datagrid/events#databound), you can use `PreventRender` method of the Grid to disable rendering.

## Use paging or virtualization to load only visible rows

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid renders each row and cell as individual component and loading large number of rows and cells in view will have performance impact on both memory consumption and CPU processing.

To use Grid without such performance impacts, you can load reduced set of rows in the Grid using [Paging](./paging) and [Virtualization](./virtual-scrolling) features.

N> Even though with `Paging` or `Virtualization` feature enabled, having hundreds of rows in single Grid page will again introduce performance lag in the application, so you need to set reasonable page size.