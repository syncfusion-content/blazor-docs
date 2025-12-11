---
layout: post
title: Column Spanning in Blazor DataGrid Component | Syncfusion
description: Learn how to use the column spanning in Syncfusion Blazor DataGrid.
platform: Blazor
control: DataGrid
documentation: ug
---

# Column Spanning in Blazor DataGrid

The Syncfusion Blazor DataGrid introduces automatic column spanning, a feature that merges adjacent cells with identical values vertically within the same column. This enhancement improves readability by consolidating duplicate values into a single unified cell, resulting in a cleaner and more organized presentation.

Column spanning is controlled through the AutoSpanMode enumeration, which provides flexible options for enabling or disabling spanning behavior at both the grid and column levels.


## Enabling Column Spanning

To enable vertical merging of cells, set the AutoSpan property of the SfGrid component to AutoSpanMode.Column. This instructs the grid to automatically merge stacked cells that share identical values within the same column.


{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid TValue="Order" DataSource="@Orders" AutoSpan="AutoSpanMode.Column" AllowPaging="true">
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" Width="120" />
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer ID" Width="150" />
        <GridColumn Field="@nameof(Order.Freight)" HeaderText="Freight" Format="C2" Width="120" />
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = new List<Order>()
        {
            new Order { OrderID = 10001, CustomerID = "ALFKI", Freight = 32.38 },
            new Order { OrderID = 10002, CustomerID = "ALFKI", Freight = 32.38 },
            new Order { OrderID = 10003, CustomerID = "ALFKI", Freight = 32.38 },
            new Order { OrderID = 10004, CustomerID = "ANATR", Freight = 11.61 },
            new Order { OrderID = 10005, CustomerID = "ANATR", Freight = 11.61 },
            new Order { OrderID = 10006, CustomerID = "ANATR", Freight = 11.61 },
            new Order { OrderID = 10007, CustomerID = "BERGS", Freight = 45.12 },
            new Order { OrderID = 10008, CustomerID = "BERGS", Freight = 45.12 },
            new Order { OrderID = 10009, CustomerID = "BERGS", Freight = 45.12 },
            new Order { OrderID = 10010, CustomerID = "BLAUS", Freight = 18.77 },
            new Order { OrderID = 10011, CustomerID = "BLAUS", Freight = 18.77 },
            new Order { OrderID = 10012, CustomerID = "BLAUS", Freight = 18.77 },
            new Order { OrderID = 10013, CustomerID = "BONAP", Freight = 67.23 },
            new Order { OrderID = 10014, CustomerID = "BONAP", Freight = 67.23 },
            new Order { OrderID = 10015, CustomerID = "BONAP", Freight = 67.23 },
            new Order { OrderID = 10016, CustomerID = "CACTU", Freight = 22.45 },
            new Order { OrderID = 10017, CustomerID = "CACTU", Freight = 22.45 },
            new Order { OrderID = 10018, CustomerID = "CACTU", Freight = 22.45 },
            new Order { OrderID = 10019, CustomerID = "FRANK", Freight = 39.99 },
            new Order { OrderID = 10020, CustomerID = "FRANK", Freight = 39.99 },
            new Order { OrderID = 10021, CustomerID = "FRANK", Freight = 39.99 },
            new Order { OrderID = 10022, CustomerID = "HUNGO", Freight = 55.50 },
            new Order { OrderID = 10023, CustomerID = "HUNGO", Freight = 55.50 },
            new Order { OrderID = 10024, CustomerID = "HUNGO", Freight = 55.50 },
            new Order { OrderID = 10025, CustomerID = "LILAS", Freight = 27.80 },
            new Order { OrderID = 10026, CustomerID = "LILAS", Freight = 27.80 },
            new Order { OrderID = 10027, CustomerID = "LILAS", Freight = 27.80 },
            new Order { OrderID = 10028, CustomerID = "SEVES", Freight = 14.65 },
            new Order { OrderID = 10029, CustomerID = "SEVES", Freight = 14.65 },
            new Order { OrderID = 10030, CustomerID = "SEVES", Freight = 14.65 }
        };
    }

    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public double Freight { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}


## Disable column spanning for specific column

Column spanning can also be disabled at the column level by setting the AutoSpan property of the GridColumn component to AutoSpanMode.None. This allows fine-grained control when spanning is required globally but should be excluded for specific columns.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}


@using Syncfusion.Blazor.Grids

<SfGrid TValue="Order" DataSource="@Orders" AutoSpan="AutoSpanMode.Column" AllowPaging="true">
    <GridColumns>
        <GridColumn Field="@nameof(Order.OrderID)" HeaderText="Order ID" Width="120" />
        <GridColumn Field="@nameof(Order.CustomerID)" HeaderText="Customer ID" Width="150" />
        <GridColumn Field="@nameof(Order.Freight)" HeaderText="Freight" AutoSpan="AutoSpanMode.None" Format="C2" Width="120" />
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = new List<Order>()
        {
            new Order { OrderID = 10001, CustomerID = "ALFKI", Freight = 32.38 },
            new Order { OrderID = 10002, CustomerID = "ALFKI", Freight = 32.38 },
            new Order { OrderID = 10003, CustomerID = "ALFKI", Freight = 32.38 },
            new Order { OrderID = 10004, CustomerID = "ANATR", Freight = 11.61 },
            new Order { OrderID = 10005, CustomerID = "ANATR", Freight = 11.61 },
            new Order { OrderID = 10006, CustomerID = "ANATR", Freight = 11.61 },
            new Order { OrderID = 10007, CustomerID = "BERGS", Freight = 45.12 },
            new Order { OrderID = 10008, CustomerID = "BERGS", Freight = 45.12 },
            new Order { OrderID = 10009, CustomerID = "BERGS", Freight = 45.12 },
            new Order { OrderID = 10010, CustomerID = "BLAUS", Freight = 18.77 },
            new Order { OrderID = 10011, CustomerID = "BLAUS", Freight = 18.77 },
            new Order { OrderID = 10012, CustomerID = "BLAUS", Freight = 18.77 },
            new Order { OrderID = 10013, CustomerID = "BONAP", Freight = 67.23 },
            new Order { OrderID = 10014, CustomerID = "BONAP", Freight = 67.23 },
            new Order { OrderID = 10015, CustomerID = "BONAP", Freight = 67.23 },
            new Order { OrderID = 10016, CustomerID = "CACTU", Freight = 22.45 },
            new Order { OrderID = 10017, CustomerID = "CACTU", Freight = 22.45 },
            new Order { OrderID = 10018, CustomerID = "CACTU", Freight = 22.45 },
            new Order { OrderID = 10019, CustomerID = "FRANK", Freight = 39.99 },
            new Order { OrderID = 10020, CustomerID = "FRANK", Freight = 39.99 },
            new Order { OrderID = 10021, CustomerID = "FRANK", Freight = 39.99 },
            new Order { OrderID = 10022, CustomerID = "HUNGO", Freight = 55.50 },
            new Order { OrderID = 10023, CustomerID = "HUNGO", Freight = 55.50 },
            new Order { OrderID = 10024, CustomerID = "HUNGO", Freight = 55.50 },
            new Order { OrderID = 10025, CustomerID = "LILAS", Freight = 27.80 },
            new Order { OrderID = 10026, CustomerID = "LILAS", Freight = 27.80 },
            new Order { OrderID = 10027, CustomerID = "LILAS", Freight = 27.80 },
            new Order { OrderID = 10028, CustomerID = "SEVES", Freight = 14.65 },
            new Order { OrderID = 10029, CustomerID = "SEVES", Freight = 14.65 },
            new Order { OrderID = 10030, CustomerID = "SEVES", Freight = 14.65 }
        };
    }

    public class Order
    {
        public int OrderID { get; set; }
        public string CustomerID { get; set; }
        public double Freight { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}