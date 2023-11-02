---
layout: post
title: Create custom Grid column in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Create custom Grid column component in Syncfusion Blazor DataGrid component and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Create Custom GridColumn in Blazor DataGrid Component

To create custom Grid columns and maintain their display order, follow these steps:

In the following sample code, there are two custom columns defined inside the Grid. By extending the code in the below way will maintain the column displayed order.

Extend the GridColumn components in the below way and define your custom columns and their properties. These properties could include header text alignment, column type, text alignment, width, and more.



{% tabs %}
{% highlight razor tabtitle="Index.razor" %}
@using Syncfusion.Blazor.Grids
@using BlazorApp1.Data

<SfGrid DataSource="@GridData" AllowPaging="true">
    <GridColumns>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" IsPrimaryKey="true" TextAlign="@TextAlign.Center" HeaderTextAlign="@TextAlign.Center" Width="140"></GridColumn>
        <AlignmentLeftColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" TextAlign="@TextAlign.Left" HeaderTextAlign="@TextAlign.Left" Width="140"></AlignmentLeftColumn>
        <CustomerColumn></CustomerColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" Format="C2" Width="140" TextAlign="@TextAlign.Right" HeaderTextAlign="@TextAlign.Right"></GridColumn>
    </GridColumns>
</SfGrid>
@code{
    public List<OrderData> GridData { get; set; }
    SfGrid<OrderData> grid { get; set; }

    protected override void OnInitialized()
    {
        GridData = OrderData.GetAllRecords();
    }
}
{% endhighlight %}
{% highlight razor tabtitle="AlignmentLeftColumn.razor" %}
@using Syncfusion.Blazor.Grids

@inherits GridColumn

@ChildContent

@code {
    protected override void OnInitialized()
    {
        base.OnInitialized();

        HeaderTextAlign = TextAlign.Left;
        Type = ColumnType.String;
        TextAlign = TextAlign.Center;
        Width = "30";
    }
}
{% endhighlight %}
{% highlight razor tabtitle="CustomerColumn.razor" %}
@using Syncfusion.Blazor.Grids

@inherits GridColumn

@ChildContent

@code {
    protected override void OnInitialized()
    {
        base.OnInitialized();
        Field = "CustomerID";
        HeaderText = "Customer Name";
        Width = "150";
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
     public OrderData(int? OrderID,string CustomerID, DateTime OrderDate, double Freight)
     {
        this.OrderID = OrderID;    
        this.CustomerID = CustomerID;         
        this.OrderDate = OrderDate;
        this.Freight = Freight;
         
     }
     public static List<OrderData> GetAllRecords()
     {
         if (Orders.Count() == 0)
         {
             int code = 10;
             for (int i = 1; i < 2; i++)
             {
                 Orders.Add(new OrderData(10248, "VINET", new DateTime(1996, 04, 17), 32.38));
                 Orders.Add(new OrderData(10249, "TOMSP", new DateTime(1996, 05, 07), 11.61));
                 Orders.Add(new OrderData(10250, "HANAR", new DateTime(1996, 08, 07), 65.83));
                 Orders.Add(new OrderData(10251, "VICTE", new DateTime(1996, 08, 07), 41.34));
                 Orders.Add(new OrderData(10252, "SUPRD", new DateTime(1996, 09, 07), 51.30));
                 Orders.Add(new OrderData(10253, "HANAR", new DateTime(1996, 07, 10), 58.17));
                 Orders.Add(new OrderData(10254, "CHOPS", new DateTime(1996, 07, 11), 22.98));
                 Orders.Add(new OrderData(10255, "RICSU", new DateTime(1996, 07, 12), 148.33));
                 Orders.Add(new OrderData(10256, "WELLI", new DateTime(1996, 07, 15), 13.97));
                 code += 5;
             }
         }
         return Orders;
     }

     public int? OrderID { get; set; }
     public string CustomerID { get; set; }
     public DateTime OrderDate { get; set; }
     public double Freight { get; set; }
     public string ShipCity { get; set; }

 }
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjrKCsXVgRFsAigo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> While rendering the custom GridColumn in a separate razor page, the position or order of that specific column will not align properly unless if we extend or create the customized Grid column component by inheriting the GridColumn class in razor page.