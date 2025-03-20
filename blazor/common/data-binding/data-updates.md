---
layout: post
title: Observable Collection and INotifyPropertyChanged in Syncfusion Blazor
description: Check out the documentation for the Observable Collection support in the Syncfusion Blazor Components.
platform: Blazor
component: Common
documentation: ug
---

# Observable Collection and INotifyPropertyChanged in Blazor

Syncfusion Blazor components supports to automatically update data based on `INotifyCollectionChanged` (`ObservableCollection`) and `INotifyPropertyChanged` interfaces. 

## Observable Collection

The data-bound components (like DataGrid, Kanban, Scheduler) provides support to update its data without any additional refresh call when using `ObservableCollection` as data source and perform add, remove, clear actions in collection. ObservableCollection notifies the collection changes using [INotifyCollectionChanged](https://learn.microsoft.com/en-us/dotnet/api/system.collections.specialized.inotifycollectionchanged?view=net-7.0) interface.  

In the following code example, DataGrid automatically updates its data when add, remove items in the `ObservableCollection`.

```cshtml
@using System.Collections.ObjectModel;
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton ID="add" @onclick="AddRecord">Add Record</SfButton>
<SfButton ID="del" CssClass="deleteBtn" @onclick="DeleteRecord">Delete Record</SfButton>
<br /><br />
<SfGrid DataSource="@observableData" AllowPaging="true">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(DataOrder.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="@TextAlign.Center" HeaderTextAlign="@TextAlign.Center" Width="140"></GridColumn>
        <GridColumn Field=@nameof(DataOrder.CustomerName) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(DataOrder.Freight) HeaderText="Freight" EditType="EditType.NumericEdit" Format="C2" Width="140" TextAlign="@TextAlign.Right" HeaderTextAlign="@TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(DataOrder.OrderDate) HeaderText="Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Type="ColumnType.Date" Width="160"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private ObservableCollection<DataOrder> observableData { get; set; }
    private int uniqueId;

    protected override void OnInitialized()
    {
        observableData = new ObservableCollection<DataOrder>(Enumerable.Range(1, 5).Select(x => new DataOrder()
        {
            OrderID = 10000 + x,
            CustomerName = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }));
    }

    private void AddRecord()
    {
        observableData.Add(new DataOrder() { OrderID = 10010 + ++uniqueId, CustomerName = "VINET", Freight = 30.35, OrderDate = new DateTime(1991, 05, 15) });
    }

    private void DeleteRecord()
    {
        if (observableData.Count() != 0)
        {
            observableData.Remove(observableData.First());
        }
    }

    public class DataOrder
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public DateTime OrderDate { get; set; }
        public double Freight { get; set; }
    }
}
```

### List of Syncfusion Components supports ObservableCollection

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

The data-bound components (like DataGrid, Kanban, Scheduler) provides support to update its data without any additional refresh call when changing property value of item if an item implements [INotifyPropertyChanged ](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=net-7.0) interface. `INotifyPropertyChanged` interface is used to notify, that a property value has changed.

In the below example, `DataOrder` implements `INotifyPropertyChanged` interface and raises a [PropertyChanged](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged.propertychanged?view=net-7.0) event when property values are changed. DataGrid automatically updates its property values are changed in data object by listening to `PropertyChanged` event.

```cshtml
@using System.Collections.ObjectModel;
@using System.ComponentModel;
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton ID="update" @onclick="UpdateRecord">Update Data</SfButton>
<br /><br />
<SfGrid DataSource="@observableData" AllowPaging="true">
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridColumns>
        <GridColumn Field=@nameof(DataOrder.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="@TextAlign.Center" HeaderTextAlign="@TextAlign.Center" Width="140"></GridColumn>
        <GridColumn Field=@nameof(DataOrder.CustomerName) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(DataOrder.Freight) HeaderText="Freight" EditType="EditType.NumericEdit" Format="C2" Width="140" TextAlign="@TextAlign.Right" HeaderTextAlign="@TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(DataOrder.OrderDate) HeaderText="Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Type="ColumnType.Date" Width="160"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private ObservableCollection<DataOrder> observableData { get; set; }
    private int uniqueId;

    protected override void OnInitialized()
    {
        observableData = new ObservableCollection<DataOrder>(Enumerable.Range(1, 5).Select(x => new DataOrder()
        {
            OrderID = 10000 + x,
            CustomerName = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }));
    }

    private void UpdateRecord()
    {
        if (observableData.Count() != 0)
        {
            var name = observableData.First();
            name.CustomerName = "Record Updated";
        }
    }

    public class DataOrder : INotifyPropertyChanged
    {
        public int OrderID { get; set; }
        private string customerID { get; set; }
        public string CustomerName
        {
            get { return customerID; }
            set
            {
                this.customerID = value;
                NotifyPropertyChanged("CustomerID");
            }
        }
        public DateTime OrderDate { get; set; }
        public double Freight { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
```
