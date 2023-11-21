---
layout: post
title: How to get filter,sort, and group column details using the OnActionComplete event in Blazor Grid | Syncfusion 
description: Learn here all about how to Get Filter, Sort, and Group Column Details using the OnActionComplete Event in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---
# How to Get Filter, Sort, and Group Column Details in the Grid using the OnActionComplete Event 

The [OnActionComplete](https://blazor.syncfusion.com/documentation/datagrid/events#onactioncomplete) event of Syncfusion DataGrid provides a convenient way to obtain filter, sort, and group column details after performing corresponding operations. The `OnActionComplete` event will be triggered once certain actions have been completed. By handling this event and accessing the event arguments, you can retrieve the necessary information about the performed actions.

The RequestType parameter in the event arguments indicates the type of operation that has been performed. Here are the different RequestType values and when they occur:

**Filtering:** Occurs after the filtering operation is completed.

**Sorting :** Occurs after the sorting operation is completed.

**Grouping:** Occurs after the grouping operation is completed.

The following example demonstrates how to retrieve filter, sort, and group column details using the [OnActionComplete](https://blazor.syncfusion.com/documentation/datagrid/events#onactioncomplete) event by accessing the RequestType parameter,

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@GridData" AllowFiltering="true" AllowGrouping="true" AllowSorting="true" Height="267px">
    <GridEvents OnActionComplete="ActionComplete" TValue="OrderData"></GridEvents>
      <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipCity) HeaderText="Ship City" Width="100"></GridColumn>
        <GridColumn Field=@nameof(OrderData.ShipName) HeaderText="Ship Name" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>


@code {
    public List<OrderData> GridData { get; set; }

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }

    public void ActionComplete(ActionEventArgs<OrderData> args)
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
            var sortdirection = args.Direction;
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
{% endhighlight %}
{% highlight c# tabtitle="OrderData.cs" %}
 public class OrderData
    {
        public static List<OrderData> Orders = new List<OrderData>();


        public OrderData()
        {

        }
        public OrderData(int? OrderID, string CustomerID, string ShipCity, string ShipName)
        {
            this.OrderID = OrderID;
            this.CustomerID = CustomerID;
            this.ShipCity = ShipCity;
            this.ShipName = ShipName;

        }

        public static List<OrderData> GetAllRecords()
        {
            if (Orders.Count() == 0)
            {
                int code = 10;
                for (int i = 1; i < 2; i++)
                {
                    Orders.Add(new OrderData(10248, "VINET", "Reims", "Vins et alcools Chevali"));
                    Orders.Add(new OrderData(10249, "TOMSP", "Münster", "Toms Spezialitäten"));
                    Orders.Add(new OrderData(10250, "HANAR", "Rio de Janeiro", "Hanari Carnes"));
                    Orders.Add(new OrderData(10251, "VICTE", "Lyon", "Victuailles en stock"));
                    Orders.Add(new OrderData(10252, "SUPRD", "Charleroi", "Suprêmes délices"));
                    Orders.Add(new OrderData(10253, "HANAR", "Lyon", "Hanari Carnes"));
                    Orders.Add(new OrderData(10254, "CHOPS", "Rio de Janeiro", "Chop-suey Chinese"));
                    Orders.Add(new OrderData(10255, "RICSU", "Münster", "Richter Supermarkt"));
                    Orders.Add(new OrderData(10256, "WELLI", "Reims", "Wellington Import"));
                    code += 5;
                }
            }
            return Orders;
        }

        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCity { get; set; }
        public string ShipName { get; set; }


    }
{% endhighlight %}
{% endtabs %}
