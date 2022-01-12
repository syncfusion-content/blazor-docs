---
layout: post
title: Observable Collection in Blazor - Syncfusion
description: Check out the documentation for Observable Collection support in the Syncfusion Blazor Components.
platform: Blazor
component: Common
documentation: ug
---

# Observable Collection Data

Observable Collection is a dynamic datasource collection, provides notification when the component datasource items are added, removed and cleared. The [ObservableCollection](https://docs.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1?view=net-6.0) notifies the collection changes using the [INotifyCollectionChanged](https://docs.microsoft.com/en-us/dotnet/api/system.collections.specialized.inotifycollectionchanged?view=net-6.0) interface so the data-bound components can update without any additional refresh call.

The Observable collections trigger the [CollectionChanged](https://docs.microsoft.com/en-us/dotnet/api/system.collections.specialized.inotifycollectionchanged.collectionchanged?view=net-6.0) event when dynamic changes of add, remove and clear the collection.

## Observable Collection data-binding in Syncfusion Blazor Datagrid Component

The following code snippet demonstrates how to use an ObservableCollection object as a datasource for the Syncfusion Blazor Datagrid component.

```cshtml

@using System.Collections.ObjectModel;
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton ID="add" @onclick="AddRecord">Add Record</SfButton>
<SfButton ID="del" CssClass="deleteBtn" @onclick="DeleteRecord">Delete Record</SfButton>
<br /><br />
<SfGrid DataSource="@observableData" AllowPaging="true">
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
