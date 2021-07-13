---
title: "Effectively add a range of items into ObservableCollection"
component: "DataGrid"
description: "Learn how to add a range of items into ObservableCollection data bind to Blazor DataGrid component"
---

# Effectively add a range of items into ObservableCollection

By default, you can use `Add` method to add a single item into `ObservableCollection`. To add a range of items you can call the Add method multiple times using `foreach` statement. For every single add action into ObservableCollection, Grid will be refreshed to display the DataSource changes. So calling Add repeatedly inside foreach might have performance impact in Grid.

So, to effectively add a range of items into ObservableCollection bind to Grid, you can extend `ObservableCollection<T>` class and define an AddRange method. You can use this AddRange method to add a range of items and handle the `OnCollectionChanged` call occur one time for the multiple add actions.

This is demonstrated in the below sample code,

```csharp
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons
@using System.Collections.ObjectModel
@using System.Collections.Specialized

<SfButton OnClick="AddRangeItems">Add Range of Items</SfButton>

<SfGrid @ref="Grid" DataSource="@GridData" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrdersDetailsObserveData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetailsObserveData.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetailsObserveData.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrdersDetailsObserveData.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>
@code{
    SfGrid<OrdersDetailsObserveData> Grid;
    public SmartObservableCollection<OrdersDetailsObserveData> GridData = new SmartObservableCollection<OrdersDetailsObserveData>();
    public void AddRangeItems()
    {
        GridData.AddRange(Orders);
    }
    public class SmartObservableCollection<T> : ObservableCollection<T>
    {
        private bool _preventNotification = false;
        protected override void OnCollectionChanged(NotifyCollectionChangedEventArgs e)
        {
            if (!_preventNotification)
                base.OnCollectionChanged(e);
        }
        public void AddRange(IEnumerable<T> list)
        {
            _preventNotification = true;
            foreach (T item in list)
                Add(item);
            _preventNotification = false;
            OnCollectionChanged(new NotifyCollectionChangedEventArgs(NotifyCollectionChangedAction.Reset));
        }
    }
    IEnumerable<OrdersDetailsObserveData> Orders = Enumerable.Range(1, 10000).Select(x => new OrdersDetailsObserveData()
    {
        OrderID = 1000 + x,
        CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
        Freight = 2.1 * x,
        OrderDate = DateTime.Now.AddDays(-x),
    }).ToList();
    public class OrdersDetailsObserveData
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```
