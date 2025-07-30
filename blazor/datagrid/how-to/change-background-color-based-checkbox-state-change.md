---
layout: post
title: Change row background color based on checkbox state in Blazor DataGrid | Syncfusion
description: Checkout and learn here all about Change row background color based on checkbox state in Syncfusion Blazor DataGrid and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Change row background color based on checkbox state

The Syncfusion Blazor DataGrid allows you to customize the appearance of rows by changing their background color when a checkbox is checked or unchecked.

This is helpful when you want to visually separate rows based on their status. For example, you can highlight rows in green when a checkbox is checked to indicate approval, and in red when unchecked to show that action is still needed.

The following example demonstrates how to render a checkbox inside a column template and apply conditional row styling using the [RowDataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_RowDataBound) event:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfGrid DataSource="@Orders" @ref="Grid" Height="315" >
    <GridEvents RowDataBound="OnRowDataBound" TValue="OrderData"></GridEvents>
    <GridColumns>
        <GridColumn HeaderText="Select" Width="100">
            <Template>
                @{
                    var item = (context as OrderData);
                }
                <SfCheckBox @bind-Checked="item.MakeFrom" @onchange="@(e => ChangeCheckbox(e, item))"></SfCheckBox>
            </Template>
        </GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="90"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" TextAlign="TextAlign.Right" Format="C2" Width="130"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" Width="130"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    .e-true {
        background-color: lightgreen;
    }

    .e-false {
        background-color: lightcoral;
    }
</style>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }

    private void ChangeCheckbox(ChangeEventArgs e, OrderData item)
    {
        Grid.Refresh(); // Refresh to apply row style.
    }

    public void OnRowDataBound(RowDataBoundEventArgs<OrderData> args)
    {
        if (args.Data.MakeFrom)
        {
            args.Row.AddClass(new[] { "e-true" });
        }
        else
        {
            args.Row.AddClass(new[] { "e-false" });
        }
    }
}


{% endhighlight %}

{% highlight cs tabtitle="OrderDetails.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData() { }

    public OrderData(int? orderID, string customerID, double freight, DateTime? orderDate, bool makeFrom)
    {
        OrderID = orderID;
        CustomerID = customerID;
        Freight = freight;
        OrderDate = orderDate;
        MakeFrom = makeFrom;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", 32.38, new DateTime(1996, 7, 4), false));
            Orders.Add(new OrderData(10249, "TOMSP", 11.61, new DateTime(1996, 7, 5), true));
            Orders.Add(new OrderData(10250, "HANAR", 65.83, new DateTime(1996, 7, 6), false));
            Orders.Add(new OrderData(10251, "VINET", 41.34, new DateTime(1996, 7, 7), true));
            Orders.Add(new OrderData(10252, "SUPRD", 51.30, new DateTime(1996, 7, 8), false));
            Orders.Add(new OrderData(10253, "HANAR", 58.17, new DateTime(1996, 7, 9), true));
            Orders.Add(new OrderData(10254, "CHOPS", 22.98, new DateTime(1996, 7, 10), false));
            Orders.Add(new OrderData(10255, "VINET", 148.33, new DateTime(1996, 7, 11), true));
            Orders.Add(new OrderData(10256, "HANAR", 13.97, new DateTime(1996, 7, 12), false));
            Orders.Add(new OrderData(10257, "SUPRD", 45.00, new DateTime(1996, 7, 13), true));
            Orders.Add(new OrderData(10258, "CHOPS", 29.99, new DateTime(1996, 7, 14), false));
            Orders.Add(new OrderData(10259, "TOMSP", 39.99, new DateTime(1996, 7, 15), true));
            Orders.Add(new OrderData(10260, "HANAR", 59.99, new DateTime(1996, 7, 16), false));
            Orders.Add(new OrderData(10261, "VINET", 69.99, new DateTime(1996, 7, 17), true));
            Orders.Add(new OrderData(10262, "SUPRD", 79.99, new DateTime(1996, 7, 18), false));
        }

        return Orders;
    }

    public int? OrderID { get; set; }
    public string CustomerID { get; set; }
    public double? Freight { get; set; }
    public DateTime? OrderDate { get; set; }
    public bool MakeFrom { get; set; } 
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNroDGKthTySXTup?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}