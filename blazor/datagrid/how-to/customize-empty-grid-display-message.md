---
layout: post
title: Customize empty grid display message
description: Learn how to customize empty grid display message in Blazor DataGrid component
platform: Blazor
component: DataGrid
documentation: ug
---

# Customize empty grid display message

You can customize the message shown when rendering an empty grid by using the `EmptyRecordTemplate` feature.

This is demonstrated in the below sample code,

{% tabs %}

{% highlight C# %}

@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true">
    <GridTemplates>
        <EmptyRecordTemplate>
            <span>Custom no record message</span>
        </EmptyRecordTemplate>
    </GridTemplates>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type=ColumnType.Date TextAlign="TextAlign.Center" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Center" Width="120"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    public List<Order> Orders { get; set; }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}

{% endhighlight %}

{% endtabs %}