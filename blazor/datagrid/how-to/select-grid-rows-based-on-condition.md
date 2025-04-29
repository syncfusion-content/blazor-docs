---
layout: post
title: Select rows based on certain condition in Blazor DataGrid | Syncfusion
description: Learn here all about Select datagrid rows based on certain condition in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Select Rows Based on Certain Condition in Blazor DataGrid Component

You can programmatically select specific rows in the Syncfusion Blazor DataGrid based on [SelectRows](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_SelectRows_System_Double___) method within the [DataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_DataBound) event of the Grid.

In the following example, rows where the **Freight** column value is greater than 10 are identified in the [RowDataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowDataBound) event, and their corresponding row indexes are stored. These indexes are then passed to the `SelectRows` method during the `DataBound` event to highlight the matching rows.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" Toolbar="@(new List<string>() { "Add", "Delete", "Edit","Update", "Cancel" })" AllowPaging="true">
    <GridEvents OnActionBegin="OnActionBegin" TValue="Order"></GridEvents>
    <GridEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true"></GridEditSettings>
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    private SfGrid<Order> Grid;
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Order.GetAllRecords();
    }

    public void OnActionBegin(ActionEventArgs<Order> args)
    {
        if (args.RequestType == Action.Add)
        {
            args.Cancel = true;
        }
    }
}

{% endhighlight %}
{% highlight c# tabtitle="Order.cs" %}

 public class Order
 {
     public static List<Order> Orders = new List<Order>();

     public Order(int orderID, string customerID, double freight, string shipCity, string shipName, string shipCountry)
     {
         this.OrderID = orderID;
         this.CustomerID = customerID;
         this.Freight = freight;
         this.ShipCity = shipCity;
         this.ShipName = shipName;
         this.ShipCountry = shipCountry;
     }

     public static List<Order> GetAllRecords()
     {
         if (Orders.Count == 0)
         {
             Orders.Add(new Order(10248, "VINET", 32.38, "Reims", "Vins et alcools Chevalier", "France"));
             Orders.Add(new Order(10249, "TOMSP", 11.61, "Münster", "Toms Spezialitäten", "Germany"));
             Orders.Add(new Order(10250, "HANAR", 65.83, "Rio de Janeiro", "Hanari Carnes", "Brazil"));
             Orders.Add(new Order(10251, "VICTE", 41.34, "Lyon", "Victuailles en stock", "France"));
             Orders.Add(new Order(10252, "SUPRD", 51.3, "Charleroi", "Suprêmes délices", "Belgium"));
             Orders.Add(new Order(10253, "HANAR", 58.17, "Rio de Janeiro", "Hanari Carnes", "Brazil"));
             Orders.Add(new Order(10254, "VICTE", 22.98, "Bern", "Chop-suey Chinese", "Switzerland"));
             Orders.Add(new Order(10255, "TOMSP", 148.33, "Genève", "Richter Supermarkt", "Switzerland"));
             Orders.Add(new Order(10256, "HANAR", 13.97, "Resende", "Wellington Import Export", "Brazil"));
             Orders.Add(new Order(10257, "VINET", 81.91, "San Cristóbal", "Hila Alimentos", "Venezuela"));
            
         }

         return Orders;
     }

     public int OrderID { get; set; }
     public string CustomerID { get; set; }
     public double Freight { get; set; }
     public string ShipCity { get; set; }
     public string ShipName { get; set; }
     public string ShipCountry { get; set; }
 }

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXhSZpVOJpckzofz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}