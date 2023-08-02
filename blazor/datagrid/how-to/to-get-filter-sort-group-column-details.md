---
layout: post
title: How to get filter,sort, and group column details using the OnActionComplete event in Blazor Grid | Syncfusion
description: Learn here all about how to Get Filter, Sort, and Group Column Details using the OnActionComplete Event in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# How to Get Filter, Sort, and Group Column Details in the Grid using the OnActionComplete Event

The [OnActionComplete](https://blazor.syncfusion.com/documentation/datagrid/events#onactioncomplete) event in Syncfusion Grid provides a convenient way to obtain filter, sort, and group column details after performing corresponding operations. By handling this event and accessing the event arguments, you can retrieve the necessary information about the performed actions.

The RequestType parameter in the event arguments indicates the type of operation that has been performed. Here are the different RequestType values and when they occur:

**Filtering:** Occurs after the filtering operation is completed.

**Sorting :** Occurs after the sorting operation is completed.

**Grouping:** Occurs after the grouping operation is completed.

The following example demonstrates how to retrieve filter, sort, and group column details using the [OnActionComplete](https://blazor.syncfusion.com/documentation/datagrid/events#onactioncomplete) event by accessing the RequestType parameter,

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" AllowFiltering="true" AllowGrouping="true" AllowSorting="true"  Height="315">
    <GridEvents  OnActionComplete="ActionComplete" TValue="Order"></GridEvents>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" EditType="EditType.DatePickerEdit" Format="d" TextAlign="TextAlign.Right" Width="130" Type="ColumnType.Date"></GridColumn>
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

    public void ActionComplete(ActionEventArgs<Order> args)
    {
       if (args.RequestType == Syncfusion.Blazor.Grids.Action.Filtering)
        {
            // Here you can get the filtercolumn name
            var filtercolumn = args.CurrentFilteringColumn;
            //Here you can get the filter column details 
            var filterdetails = args.CurrentFilterObject;

        }
        else if (args.RequestType == Syncfusion.Blazor.Grids.Action.Sorting)
        {
            // Here you can get the direction of sort column
            var sortdirection =   args.Direction;
            //Here you can get the  sort column name
            var sortcolumn = args.ColumnName;

        }
        else if (args.RequestType == Syncfusion.Blazor.Grids.Action.Grouping)
        {
            //Here you can get the groupcolumn name
            var groupcolumn = args.ColumnName;

        }       
    }
}
```