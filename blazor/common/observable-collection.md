---
layout: post
title: Observable Collection in Blazor - Syncfusion
description: Check out the documentation for Observable Collection in Blazor
platform: Blazor
component: Common
documentation: ug
---

# Observable Collection

Observable Collection is a dynamic datasource collection, provides notification when the datasource items are added, removed or updated. The Observable collection triggers the [PropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged.propertychanged?view=net-5.0) event only when their Add, Remove and Clear methods are called.

# How to implement Observable Collection in Syncfusion Blazor Component

Implement the [INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=netframework-4.8) interface to model class. The `INotifyPropertyChanged` interface notifies when the property value has been changed through [PropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged.propertychanged?view=net-5.0) event in the client-side and updates its value.

The following code snippet demonstrates how to use Observable Collections in the Syncfusion Blazor DataGrid component.

```cshtml

@using System.Collections.ObjectModel;
@using System.ComponentModel
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton ID="add" @onclick="AddRecord">Add Record</SfButton>
<SfButton ID="del" CssClass="deleteBtn" @onclick="DeleteRecord">Delete Record</SfButton>
<SfButton ID="update" @onclick="UpdateRecord">Update Record</SfButton>
<br /><br />
<SfGrid DataSource="@ObservableData" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(DataOrder.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="@TextAlign.Center" HeaderTextAlign="@TextAlign.Center" Width="140"></GridColumn>
        <GridColumn Field=@nameof(DataOrder.CustomerName) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(DataOrder.Freight) HeaderText="Freight" EditType="EditType.NumericEdit" Format="C2" Width="140" TextAlign="@TextAlign.Right" HeaderTextAlign="@TextAlign.Right"></GridColumn>
        <GridColumn Field=@nameof(DataOrder.OrderDate) HeaderText="Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Type="ColumnType.Date" Width="160"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public ObservableCollection<DataOrder> ObservableData { get; set; }
    List<DataOrder> Orders = new List<DataOrder>();
    int uniqueId;

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 5).Select(x => new DataOrder()
        {
            OrderID = 10000 + x,
            CustomerName = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID" })[new Random().Next(5)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
        }).ToList();
        ObservableData = new ObservableCollection<DataOrder>(Orders);
    }

    public void AddRecord()
    {
        ObservableData.Add(new DataOrder() { OrderID = 10010 + ++uniqueId, CustomerName = "VINET", Freight = 30.35, OrderDate = new DateTime(1991, 05, 15) });
    }

    public void DeleteRecord()
    {
        if (ObservableData.Count() != 0)
        {
            ObservableData.Remove(ObservableData.First());
        }
    }

    public void UpdateRecord()
    {
        if (ObservableData.Count() != 0)
        {
            var name = ObservableData.First();
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
                NotifyPropertyChanged("CustomerName");
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
