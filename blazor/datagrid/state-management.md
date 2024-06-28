---
layout: post
title: State Management in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about State Management in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# State Management in Blazor DataGrid Component

State management allows users to save and load grid state. The grid will use user-provided state to render instead of its properties provided declaratively.

Below properties can be saved and loaded into grid later.

Property|
-----|
Columns |
GridFilterSettings |
GridSortSettings |
GridGroupSettings |
GridPageSettings |

## Enabling persistence in Grid

State persistence allows the Grid to retain the current grid state in the browser local storage for state maintenance. This action is handled through the `EnablePersistence` property which is set to false by default. When it is set to true, some properties of the Grid will be retained even after refreshing the page.

N> The state will be persisted based on **ID** property. So, it is recommended to explicitly set the **ID** property for Grid.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid ID="Grid" DataSource="@Orders" Height="315" EnablePersistence="true" AllowPaging="true" AllowFiltering="true" AllowGrouping="true" AllowSorting="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

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

You can use [ResetPersistData](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ResetPersistData) method to reset grid state to its original state. This will clear persisted data in window local storage and renders grid with its original property values.

## Handling grid state manually

You can handle the grid's state manually by using in-built state persistence methods. You can use [GetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetPersistDataAsync), [SetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SetPersistDataAsync_System_String_), [ResetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_ResetPersistDataAsync) methods of grid to save, load and reset the Grid's persisted state manually. [GetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_GetPersistDataAsync) method will return grid current state as a string value, which is suitable for sending them over network and storing in data bases.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="@(async () => _state = await Grid.GetPersistDataAsync())">Save State</SfButton>
<SfButton OnClick="@(async() => await Grid.SetPersistDataAsync(_state))">Set State</SfButton>
<SfButton OnClick="@(async() =>await Grid.ResetPersistDataAsync())">Reset State</SfButton>

<SfGrid @ref="Grid" ID="GridOneTwo" DataSource="@Orders" Height="315" AllowPaging="true" AllowFiltering="true" AllowGrouping="true" AllowSorting="true">
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    SfGrid<Order> Grid;

    public List<Order> Orders { get; set; }

    public string _state;

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

N> You can refer to our [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap4) to understand how to present and manipulate data.