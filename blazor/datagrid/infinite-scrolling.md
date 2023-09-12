---
layout: post
title: Infinite Scrolling in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Infinite Scrolling in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Infinite Scrolling in Blazor DataGrid Component

The Infinite Scrolling feature in the DataGrid efficiently manages large data sets without affecting the grid performance. It operates on a "load-on-demand" concept, fetching the buffered data only when necessary, typically in the default infinite scrolling mode, a block of data accumulates every time the scrollbar reaches the end of the scroller.
To enable infinite scrolling, you need to define
[EnableInfiniteScrolling](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableInfiniteScrolling) as true and content height by [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Height) property.

N> In this feature, the Grid will not initiate a new data request when revisiting the same page.

N> The [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Height)  property must be specified when enabling `EnableInfiniteScrolling`.

```csharp

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" ID="Grid" DataSource="@Orders" Height="300" EnableInfiniteScrolling="true">
    <GridPageSettings PageSize="20"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey=true Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="ShipCountry" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }
    public SfGrid<Order> Grid { get; set; }
    protected override void OnInitialized()
    {
        Orders = GetAllRecords();
    }
    public List<Order> GetAllRecords()
    {
        List<Order> data = new List<Order>();
        int count = 0;
        int id = 10;
        for (int i = 0; i < 200; i++)
        {
            data.Add(new Order() { OrderID = count + 1, CustomerID = "ANTON", OrderDate = new DateTime(1995, 05, 15), Freight = 25.7 * 2, ShipCountry = "USA" });
            data.Add(new Order() { OrderID = count + 2, CustomerID = "BOLID", OrderDate = new DateTime(1994, 04, 04), Freight = 26.7 * 2, ShipCountry = "UK" });
            data.Add(new Order() { OrderID = count + 3, CustomerID = "BLONP", OrderDate = new DateTime(1993, 03, 10), Freight = 27.7 * 2, ShipCountry = "RUSSIA" });
            data.Add(new Order() { OrderID = count + 4, CustomerID = "ANATR", OrderDate = new DateTime(1992, 02, 14), Freight = 28.7 * 2, ShipCountry = "CHINA" });
            data.Add(new Order() { OrderID = count + 5, CustomerID = "ALFKI", OrderDate = new DateTime(1991, 01, 18), Freight = 29.7 * 2, ShipCountry = "JAPAN" });
            count += 5;
            id += 5;
        }
        return data;
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
    }
}
```

The following GIF represents the infinite scrolling functionality in DataGrid

![Infinite Scrolling in Blazor DataGrid](./images/blazor-datagrid-infinite-scrolling.gif)

## Initial Blocks

The number of blocks initially rendered when the Grid loads corresponds to the Grid's page size. This results in the rendering of a specific number of `tr` elements.
You can define the initial loading pages count by using [InitialBlocks](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridInfiniteScrollSettings.html) property of [GridInfiniteScrollSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridInfiniteScrollSettings.html) class. By default, this property loads three pages during the initial rendering. Subsequently, additional data is buffered and loaded based on either the page size or the number of rows rendered within the provided height.

In the below demo, we have changed this property value to load four page records instead of three.
```csharp

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" ID="Grid" DataSource="@Orders" Height="300" EnableInfiniteScrolling="true">
    <GridPageSettings PageSize="20"></GridPageSettings>
    <GridInfiniteScrollSettings InitialBlocks="4"></GridInfiniteScrollSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey=true Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="ShipCountry" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }
    public SfGrid<Order> Grid { get; set; }
    protected override void OnInitialized()
    {
        Orders = GetAllRecords();
    }
    public List<Order> GetAllRecords()
    {
        List<Order> data = new List<Order>();
        int count = 0;
        int id = 10;
        for (int i = 0; i < 200; i++)
        {
            data.Add(new Order() { OrderID = count + 1, CustomerID = "ANTON", OrderDate = new DateTime(1995, 05, 15), Freight = 25.7 * 2, ShipCountry = "USA" });
            data.Add(new Order() { OrderID = count + 2, CustomerID = "BOLID", OrderDate = new DateTime(1994, 04, 04), Freight = 26.7 * 2, ShipCountry = "UK" });
            data.Add(new Order() { OrderID = count + 3, CustomerID = "BLONP", OrderDate = new DateTime(1993, 03, 10), Freight = 27.7 * 2, ShipCountry = "RUSSIA" });
            data.Add(new Order() { OrderID = count + 4, CustomerID = "ANATR", OrderDate = new DateTime(1992, 02, 14), Freight = 28.7 * 2, ShipCountry = "CHINA" });
            data.Add(new Order() { OrderID = count + 5, CustomerID = "ALFKI", OrderDate = new DateTime(1991, 01, 18), Freight = 29.7 * 2, ShipCountry = "JAPAN" });
            count += 5;
            id += 5;
        }
        return data;
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
    }
}
```

## Cache Mode

In Grid Cache mode, visited data blocks are cached, enabling the reuse of previously loaded block data when revisiting the same block. This reduces the need for frequent data requests while navigating within the same block. Additionally, this mode manages row elements in the DOM based on the [MaximumBlocks](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridInfiniteScrollSettings.html) count value. When this limit is exceeded, it will remove a block of row elements from the DOM to accommodate the generation of new rows.
To enable maximum blocks, you need to define
`MaximumBlocks` count of [GridInfiniteScrollSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridInfiniteScrollSettings.html) class, By default this property value is three.
To enable cache mode, you need to define
[EnableCache](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridInfiniteScrollSettings.html) property of `GridInfiniteScrollSettings` class as true.

In the below demo, we have enabled `EnableCache` in `GridInfiniteScrollSettings`, here three pages of records get loaded for each request.
```csharp

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" ID="Grid" DataSource="@Orders" Height="300" EnableInfiniteScrolling=true>
    <GridPageSettings PageSize="20"></GridPageSettings>
    <GridInfiniteScrollSettings EnableCache="true"></GridInfiniteScrollSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey=true Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="ShipCountry" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }
    public SfGrid<Order> Grid { get; set; }
    protected override void OnInitialized()
    {
        Orders = GetAllRecords();
    }
    
    public List<Order> GetAllRecords()
    {
        List<Order> data = new List<Order>();
        int count = 0;
        int id = 10;
        for (int i = 0; i < 200; i++)
        {
            data.Add(new Order() { OrderID = count + 1, CustomerID = "ANTON", OrderDate = new DateTime(1995, 05, 15), Freight = 25.7 * 2, ShipCountry = "USA" });
            data.Add(new Order() { OrderID = count + 2, CustomerID = "BOLID", OrderDate = new DateTime(1994, 04, 04), Freight = 26.7 * 2, ShipCountry = "UK" });
            data.Add(new Order() { OrderID = count + 3, CustomerID = "BLONP", OrderDate = new DateTime(1993, 03, 10), Freight = 27.7 * 2, ShipCountry = "RUSSIA" });
            data.Add(new Order() { OrderID = count + 4, CustomerID = "ANATR", OrderDate = new DateTime(1992, 02, 14), Freight = 28.7 * 2, ShipCountry = "CHINA" });
            data.Add(new Order() { OrderID = count + 5, CustomerID = "ALFKI", OrderDate = new DateTime(1991, 01, 18), Freight = 29.7 * 2, ShipCountry = "JAPAN" });
            count += 5;
            id += 5;
        }
        return data;
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
        public string ShipCountry { get; set; }
    }
}
```
The following GIF represents the infinite scrolling with cache mode functionality in DataGrid

![Infinite Scrolling Cache Mode in Blazor DataGrid](./images/blazor-datagrid-infinite-scrolling-cachemode.gif)

## Limitations for Infinite Scrolling

* Due to the element height limitation in browsers, the maximum number of records loaded by the grid is limited due to the browser capability.

* The combined height of the initially loaded rows must exceed the height of the viewport.

* Infinite scrolling is not compatible with batch editing, detail template and hierarchy features.

* Cell selection will not be persisted in cache mode.

* In normal grouping, infinite scrolling is not supported for child items when performing expand and collapse actions on caption rows. All child items are loaded when the caption rows are expanded or collapsed in grid.

* The aggregated information and total group items are displayed based on the current view items.

* In Lazy-Load Grouping with infinite scrolling, cache mode is not supported, and infinite scrolling mode is only available for parent-level caption rows in Lazy-Load Grouping.

* Programmatic selection using the [SelectRowsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SelectRowsAsync_System_Int32___) and [SelectRowAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SelectRowAsync_System_Int32_System_Nullable_System_Boolean__)  method is not supported in infinite scrolling.

## See also

* [Infinite scrolling with Lazy load grouping in DataGrid](https://https://blazor.syncfusion.com/documentation/datagrid/lazy-load-grouping)