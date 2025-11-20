---
layout: post
title: ObservableCollection and INotifyPropertyChanged in Syncfusion Blazor
description: Learn how Syncfusion Blazor components automatically update with ObservableCollection and INotifyPropertyChanged, eliminating manual refresh.
platform: Blazor
component: Common
documentation: ug
---

# Data updates with Interface

Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components provide automatic UI updates when the bound data source uses `ObservableCollection` and implements [INotifyCollectionChanged](https://learn.microsoft.com/en-us/dotnet/api/system.collections.specialized.inotifycollectionchanged?view=net-10.0) or [INotifyPropertyChanged](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=net-10.0). These interfaces enable real-time synchronization between the data model and the component without requiring explicit refresh calls.

**Key Difference:** 

- Use `ObservableCollection` with `INotifyCollectionChanged` for **collection-level changes** such as adding or removing items.  
- Use `INotifyPropertyChanged` for **property-level changes** within individual items, such as updating an existing record.

## ObservableCollection

Data-bound components such as `DataGrid`, `Kanban`, and `Scheduler` support automatic UI updates when an `ObservableCollection` is used as the data source. These components handle operations like **Add**, **Remove**, and **Clear** performed on the collection without requiring additional refresh calls. `ObservableCollection` achieves this by implementing the [INotifyCollectionChanged](https://learn.microsoft.com/en-us/dotnet/api/system.collections.specialized.inotifycollectionchanged) interface, which raises notifications whenever the collection is modified.

```cshtml
@using System.Collections.ObjectModel
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="AddRecord">Add Record</SfButton>
<SfButton OnClick="DeleteRecord">Delete Record</SfButton>

<SfGrid DataSource="@observableData">
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" Width="120"></GridColumn>
        <GridColumn Field="CustomerName" HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field="Freight" HeaderText="Freight" Width="100" Format="C2"></GridColumn>
        <GridColumn Field="OrderDate" HeaderText="Order Date" Width="150" Format="d"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    private ObservableCollection<DataOrder> observableData = new ObservableCollection<DataOrder>();

    private int uniqueId;

    protected override void OnInitialized()
    {
        observableData = new ObservableCollection<DataOrder>(
            Enumerable.Range(1, 5).Select(x => new DataOrder
            {
                OrderID = 10000 + x,
                CustomerName = new[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" }[new Random().Next(5)],
                Freight = 2.1 * x,
                OrderDate = DateTime.Now.AddDays(-x)
            })
        );
    }

    private void AddRecord()
    {
        observableData.Add(new DataOrder
        {
            OrderID = 10010 + ++uniqueId,
            CustomerName = "VINET",
            Freight = 30.35,
            OrderDate = new DateTime(1991, 05, 15)
        });
    }

    private void DeleteRecord()
    {
        if (observableData.Count > 0)
        {
            observableData.Remove(observableData.First());
        }
    }

    private class DataOrder
    {
        public int OrderID { get; set; }
        public string? CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public double Freight { get; set; }
    }
}
```

### List of Syncfusion<sup style="font-size:70%">&reg;</sup> Components supports ObservableCollection

* AutoComplete
* Breadcrumb
* Bullet Chart
* Charts
* ComboBox
* ContextMenu
* DataGrid
* Diagram
* Diagram Native
* Dropdown List
* HeatMap Chart
* Kanban
* ListBox
* ListView
* Maps
* Menu Bar
* MultiSelect Dropdown
* Pivot Table
* QueryBuilder
* Scheduler
* Smith Chart
* Sparkline
* Stock Chart
* TreeGrid
* TreeMap
* TreeView

## INotifyPropertyChanged

Data-bound components such as `DataGrid`, `Kanban`, and `Scheduler` automatically refresh the UI when the underlying data type implements [INotifyPropertyChanged](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged). The interface raises the [PropertyChanged](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged.propertychanged?view=net-10.0) event whenever a property value changes, allowing the component to re-render without an explicit refresh call.

```cshtml
@using System.Collections.ObjectModel;
@using System.ComponentModel;
@using Syncfusion.Blazor.Grids;
@using Syncfusion.Blazor.Buttons;

<SfButton OnClick="UpdateRecord">Update Data</SfButton>

<SfGrid DataSource="@observableData">
    <GridColumns>
        <GridColumn Field="OrderID" HeaderText="Order ID" Width="120"></GridColumn>
        <GridColumn Field="CustomerName" HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field="Freight" HeaderText="Freight" Width="100" Format="C2"></GridColumn>
        <GridColumn Field="OrderDate" HeaderText="Order Date" Width="150" Format="d"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    private ObservableCollection<DataOrder> observableData = new ObservableCollection<DataOrder>();
    private int uniqueId;

    protected override void OnInitialized()
    {
        observableData = new ObservableCollection<DataOrder>(
            Enumerable.Range(1, 5).Select(x => new DataOrder
            {
                OrderID = 10000 + x,
                CustomerName = new[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" }[new Random().Next(5)],
                Freight = 2.1 * x,
                OrderDate = DateTime.Now.AddDays(-x)
            })
        );
    }

    private void UpdateRecord()
    {
        if (observableData.Count > 0)
        {
            var firstRecord = observableData.First();
            firstRecord.CustomerName = "Record Updated";
        }
    }

    private class DataOrder : INotifyPropertyChanged
    {
        public int OrderID { get; set; }
        private string? customerName;

        public string? CustomerName
        {
            get => customerName;
            set
            {
                if (customerName != value)
                {
                    customerName = value;
                    NotifyPropertyChanged(nameof(CustomerName));
                }
            }
        }

        public DateTime OrderDate { get; set; }
        public double Freight { get; set; }

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
```