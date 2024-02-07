---
layout: post
title: Adaptive Layout in Blazor DataGrid Component | Syncfusion
description: The Blazor DataGrid will render the adaptive UI filter, sort, and edit dialogs in full screen for a better user experience.
platform: Blazor
control: DataGrid
documentation: ug
---

# Adaptive UI Layout in Blazor DataGrid Component

The DataGrid user interface (UI) was redesigned to provide an optimal viewing experience and improve usability on small screens. This interface will render the filter, sort, and edit dialogs adaptively and have an option to render the DataGrid row elements in the vertical direction.

## Render adaptive dialog

To render adaptive dialog UI in the DataGrid, set the [EnableAdaptiveUI](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableAdaptiveUI) property to true. The DataGrid will render the filter, sort, and edit dialogs in full screen for a better user experience.

```csharp

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="position:relative; min-height: 500px;">
    <SfGrid DataSource="@Orders" AllowSorting="true" AllowFiltering="true" EnableAdaptiveUI="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update", "Search" })" Height="100%" Width="100%" AllowPaging="true">
        <GridFilterSettings Type="@FilterType.Excel"></GridFilterSettings>
        <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Dialog"></GridEditSettings>
        <GridColumns>
            <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" Width="80" ValidationRules="@(new ValidationRules{ Required= true })"></GridColumn>
            <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
            <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" Width="130"></GridColumn>
            <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" Width="120"></GridColumn>
        </GridColumns>
    </SfGrid>
</div>

@code{
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

![Blazor DataGrid with Adaptive UI](./images/blazor-datagrid-render-adaptive-dialog.gif)

N> 1. This UI is common for both horizontal and vertical mode of rendering when EnableAdaptiveUI is enabled.

## Vertical mode

The DataGrid will render the row elements vertically while setting the [RowRenderingMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RowRenderingMode) property value as **Vertical**.

```csharp

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

@{
    var RenderingMode = RowDirection.Vertical;
}

<div style="position:relative; min-height: 500px;">
    <SfGrid DataSource="@Orders" AllowSorting="true" AllowFiltering="true" EnableAdaptiveUI="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update", "Search" })" RowRenderingMode="@RenderingMode" Height="100%" Width="100%" AllowPaging="true">
        <GridFilterSettings Type="@FilterType.Excel"></GridFilterSettings>
        <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Dialog"></GridEditSettings>
         <GridAggregates>
            <GridAggregate>
                <GridAggregateColumns>
                    <GridAggregateColumn Field=@nameof(Order.Freight) Type="AggregateType.Sum" Format="C2">
                        <FooterTemplate>
                            @{
                                var aggregate = (context as AggregateTemplateContext);
                                <div>
                                    <p>Sum: @aggregate.Sum</p>
                                </div>
                            }
                        </FooterTemplate>
                    </GridAggregateColumn>
                </GridAggregateColumns>
            </GridAggregate>
        </GridAggregates>
        <GridColumns>
            <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" Width="80"></GridColumn>
            <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
            <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" Width="130"></GridColumn>
            <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" Width="120"></GridColumn>
        </GridColumns>
    </SfGrid>
</div>

@code{
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

![Blazor DataGrid with Adaptive Vertical Mode](./images/blazor-datagrid-adaptive-vertical-rendering-mode.gif)

### Displaying grid in vertical row rendering mode with mobile device only

The Syncfusion Blazor DataGrid provides a feature to display the grid in [vertical](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.RowDirection.html#Syncfusion_Blazor_Grids_RowDirection_Vertical) row rendering mode specifically designed for mobile devices. This is achieved by using the [SfMediaQuery](https://blazor.syncfusion.com/documentation/media-query/break-points) component to switch between vertical and horizontal modes based on the screen size. The [@bind-ActiveBreakPoint](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.SfMediaQuery.html#Syncfusion_Blazor_SfMediaQuery_ActiveBreakpoint) property is used to activate the vertical rendering mode when the screen size is smaller than the specified height

Here’s an example code snippet illustrating the display of the grid in vertical row rendering mode exclusively for mobile devices using the Syncfusion Blazor DataGrid:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor

<div style="position:relative; min-height: 500px;">
    <SfMediaQuery @bind-ActiveBreakPoint="activeBreakpoint" />
    @if (activeBreakpoint == "Small")
    {
        IsEnableAdaptiveUI = true;
        rowDirection = Syncfusion.Blazor.Grids.RowDirection.Vertical;
    }
    else
    {
        IsEnableAdaptiveUI = false;
        rowDirection = Syncfusion.Blazor.Grids.RowDirection.Horizontal;

    }

    <SfGrid DataSource="@GridData" Height="100%" Width="100%" AllowPaging="true" RowRenderingMode="@rowDirection" EnableAdaptiveUI="@IsEnableAdaptiveUI">
        <GridColumns>
            <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" Width="120"></GridColumn>
            <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
            <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Ship City" Width="150"></GridColumn>
            <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Ship Name" Width="150"></GridColumn>
        </GridColumns>
    </SfGrid>
</div>
@code {

    public List<OrderData> GridData { get; set; }

    private string? activeBreakpoint { get; set; }

    public bool IsEnableAdaptiveUI { get; set; }

    private Syncfusion.Blazor.Grids.RowDirection rowDirection { get; set; }

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }
}
{% highlight c# tabtitle="Order.cs" %}
    public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();
        public OrderData()
        {

        }
        public OrderData( int? OrderID, string CustomerID, DateTime? OrderDate,double? Freight)
        {
           this.OrderID = OrderID;
           this.CustomerID = CustomerID;
           this.OrderDate = OrderDate;   
           this.Freight = Freight;
        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", new DateTime(1996,07,08), 32.38));
                    Orders.Add(new OrderData(10249, "TOMSP", new DateTime(1996, 07, 08),66.98));
                    Orders.Add(new OrderData(10248, "HANAR", new DateTime(1996, 07, 08),56.08));
                    Orders.Add(new OrderData(10248, "VICTE", new DateTime(1996, 07, 08),21.78));
                    Orders.Add(new OrderData(10248, "SUPRD", new DateTime(1996, 07, 08),87.56));
                    Orders.Add(new OrderData(10248, "HANAR", new DateTime(1996, 07, 08),32.56));
                    Orders.Add(new OrderData(10248, "CHOPS", new DateTime(1996, 07, 08),12.76));
                    Orders.Add(new OrderData(10248, "RICSU", new DateTime(1996, 07, 08),55.45));
                    Orders.Add(new OrderData(10248, "VINET", new DateTime(1996, 07, 08),11.94));                                                                                    
                    code += 5;
                }
            }
            return Orders;
        }
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZrfjBXcJhoKKuBS?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5" %}

### Supported features in vertical mode

The following features are only supported in vertical row rendering:

* Paging
* Sorting
* Filtering
* Selection
* Dialog Editing
* Aggregate
* Virtual scroll
* Toolbar

## Rendering an adaptive layout for smaller screens alone

By default, adaptive UI layout is rendered in both mobile devices and desktop mode too while setting the [EnableAdaptiveUI](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableAdaptiveUI) property as true. Now the DataGrid component has an option to render an adaptive layout only for mobile screen sizes. This can be achieved by specifying the [AdaptiveUIMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_AdaptiveUIMode) property value as `Mobile`. The default value of the `AdaptiveUIMode` property is "Both".

N> The [RowRenderingMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_RowRenderingMode) property is rendered on the adaptive layout based on the `AdaptiveUIMode` property.

```csharp
@using Syncfusion.Blazor.Grids

<div style="position:relative; min-height: 500px;">
    <SfGrid DataSource="@Orders" AllowSorting="true" AllowFiltering="true" EnableAdaptiveUI="true" AdaptiveUIMode="AdaptiveMode.Mobile" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Cancel", "Update", "Search" })" Height="100%" Width="100%" AllowPaging="true">
        <GridFilterSettings Type="@FilterType.Excel"></GridFilterSettings>
        <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" Mode="EditMode.Dialog"></GridEditSettings>
        <GridColumns>
            <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" Width="80"></GridColumn>
            <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
            <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" Width="130"></GridColumn>
            <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" Width="120"></GridColumn>
        </GridColumns>
    </SfGrid>
</div>

@code{
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

N> [View Sample in GitHub.](https://github.com/SyncfusionExamples/blazor-datagrid-render-adaptive-layout)