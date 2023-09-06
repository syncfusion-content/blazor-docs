---
layout: post
title:  Custom aggregate in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Custom aggregate in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Custom aggregate in Blazor Grid component

The custom aggregate feature in Syncfusion’s Blazor Grid component allows you to calculate aggregate values using your own aggregate function. This feature can be useful in scenarios where the built-in aggregate functions do not meet your specific requirements. To use the custom aggregate option, follow the steps below:

* Set the **AggregateType** as Custom in **GridAggregateColumn** directive.

* Provide your custom aggregate function in the **customAggregate** property.

The custom aggregate function will be invoked differently for total and group aggregations:

**Total Aggregation:** The custom aggregate function will be called with the whole dataset and the current aggregate column object as arguments.

**Group Aggregation:** The custom aggregate function will be called with the current group details and the aggregate column object as arguments.

Here’s an example that demonstrates how to use the custom aggregate feature in the Blazor Grid component:

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" AllowPaging="true">
   <GridAggregates>
    <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(Order.ShipCountry) Type="AggregateType.Custom" >
                    <FooterTemplate>
                        @{

                                <div>
                                    <p>Brazil Count: @CustomAggregateFunction()</p>
                                </div>
                        }
                    </FooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
    </GridAggregates>
    
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    SfGrid<Order> Grid { get; set; }
    public List<Order> Orders { get; set; }

    private int CustomAggregateFunction()
    {
        int Count = Queryable.Count(Orders.Where(x => x.ShipCountry.Contains("Brazil")).AsQueryable());
        return Count;
    }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 12).Select(x => new Order()
            {
                OrderID = 10255 + x,
                CustomerID = (new string[] { "WELLI", "HILAA", "ERNSH", "CENTC", "OTTIK" })[new Random().Next(5)],
                Freight = 2.1 * x,
                ShipCountry = (new string[] { "Brazil", "Venezuela", "Austria", "Mexico", "Germany" })[new Random().Next(5)],
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCountry { get; set; }
        public double? Freight { get; set; }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNVgXvBErgMHWvUW?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> To access the custom aggregate value inside template, use the key as **Custom**

**Show the count of distinct values in aggregate row**

You can calculate the count of distinct values in an aggregate row by using custom aggregate functions. By specifying the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_Type) as **Custom** and providing a custom aggregate function in the `CustomAggregate` property, you can achieve this behavior.

Here’s an example that demonstrates how to show the count of distinct values for the **ShipCountry** column using a custom aggregate.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" AllowPaging="true">
   <GridAggregates>
    <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(Order.ShipCountry) Type="AggregateType.Custom" >
                    <FooterTemplate>
                        @{

                                <div>
                                    <p>Distinct Count: @CustomAggregateFunction()</p>
                                </div>
                        }
                    </FooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
    </GridAggregates>
    
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    SfGrid<Order> Grid { get; set; }
    public List<Order> Orders { get; set; }

    private int CustomAggregateFunction()
    {
        int Count = Orders.Where(item => item.ShipCountry != null).Select(item => item.ShipCountry).Distinct().Count();
        return Count;
    }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 12).Select(x => new Order()
            {
                OrderID = 10255 + x,
                CustomerID = (new string[] { "WELLI", "HILAA", "ERNSH", "CENTC", "OTTIK" })[new Random().Next(5)],
                Freight = 2.1 * x,
                ShipCountry = (new string[] { "Brazil", "Venezuela", "Austria", "Mexico", "Germany" })[new Random().Next(5)],
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCountry { get; set; }
        public double? Freight { get; set; }
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BZVUDvBkVInESEoB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> To display the aggregate value of the current column in another column, you can use the [ColumnName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_ColumnName) property. If the `ColumnName` property is not defined, the field name value will be assigned to the `ColumnName` property.


> You can refer to the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap4) to understand how to present and manipulate data.