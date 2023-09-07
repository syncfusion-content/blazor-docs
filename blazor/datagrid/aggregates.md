---
layout: post
title: Aggregates in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Aggregates in the Syncfusion Blazor DataGrid component and much more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Aggregates in Blazor DataGrid Component

The Aggregates feature in the Syncfusion Blazor Grid component allows you to display aggregate values in the footer, group footer, and group caption of the grid. With this feature, you can easily perform calculations on specific columns and show summary information.This feature can be configured using the **GridAggregates** component.To represent an aggregate column, you need to specify the minimum required properties, such as [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_Field)  and  [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_Type).

**Displaying aggregate values**

By default, the aggregate values are displayed in the footer, group, and caption cells of the grid. However, you can choose to display the aggregate value in any of these cells by using the following properties:

* [FooterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_FooterTemplate): Use this property to display the aggregate value in the footer cell. You can define a custom template to format the aggregate value as per your requirements. 

* [GroupFooterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_GroupFooterTemplate): Use this property to display the aggregate value in the group footer cell. Similar to the footerTemplate, you can provide a custom template to format the aggregate value.

* [GroupCaptionTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_GroupCaptionTemplate): Use this property to display the aggregate value in the group caption cell. You can define a custom template to format the aggregate value.

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" AllowGrouping="true">
    <GridGroupSettings Columns=@Units></GridGroupSettings>
    <GridAggregates>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(Order.Freight) Type="AggregateType.Sum" Format="C2">
                    <GroupFooterTemplate>
                        @{
                            var aggregate = (context as AggregateTemplateContext);
                            <div>
                                <p>Sum: @aggregate.Sum</p>
                            </div>
                        }
                    </GroupFooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>  
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(Order.Freight) Type="AggregateType.Max" Format="C2">
                    <GroupCaptionTemplate>
                        @{
                            var aggregate = (context as AggregateTemplateContext);
                            <div>
                                <p>Max: @aggregate.Max</p>
                            </div>
                        }
                    </GroupCaptionTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
    </GridAggregates>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private string[] Units = (new string[] { "ShipCountry" });
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 15).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "ERNSH", "SUPRD", "HANAR", "WELLI", "QUEDE" })[new Random().Next(5)],
                Freight = 2.1 * x,
                OrderDate = DateTime.Now.AddDays(-x),
                ShipCountry = (new string[] { "France", "Germany", "Brazil", "Belgium", "Switzerland" })[new Random().Next(5)],
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCountry { get; set; }
        public DateTime OrderDate { get; set; }
        public double? Freight { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXhqZuDypsoZfCyy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * When using local data, the total summary is calculated based on the entire dataset available in the grid. The aggregate values will reflect calculations across all the rows in the grid.
> * When working with remote data, the total summary is calculated based on the current page records. This means that if you have enabled pagination and are displaying data in pages, the aggregate values in the footer will represent calculations only for the visible page.

## Built-in aggregate types

The Syncfusion Blazor Grid component provides several built-in aggregate types that can be specified in the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_Type) property to configure an aggregate column.

The available built-in aggregate types are :

* **Sum:** Calculates the sum of the values in the column.

* **Average:** Calculates the average of the values in the column.
* **Min:** Finds the minimum value in the column.
* **Max:** Finds the maximum value in the column.
* **Count:** Counts the number of values in the column.
* **TrueCount:** Counts the number of true values in the column.
* **FalseCount:** Counts the number of false values in the column.

Here is an example that demonstrates how to use built-in aggregates types in the Syncfusion Grid:

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" AllowGrouping="true">
    <GridGroupSettings Columns=@Units></GridGroupSettings>
    <GridAggregates>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(Order.ShippedDate) Type="Syncfusion.Blazor.Grids.AggregateType.Max" Format="d" >
                    <FooterTemplate>
                        @{
                            var aggregate = (context as AggregateTemplateContext);
                            <div>
                                <p>Max: @aggregate.Max</p>
                            </div>
                        }
                    </FooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(Order.OrderDate) Type="Syncfusion.Blazor.Grids.AggregateType.Min" Format="d" >
                    <FooterTemplate>
                        @{
                            var aggregate = (context as AggregateTemplateContext);
                            <div>
                                <p>Min: @aggregate.Min</p>
                            </div>
                        }
                    </FooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(Order.IsVerified) Type="Syncfusion.Blazor.Grids.AggregateType.TrueCount" >
                    <FooterTemplate>
                        @{
                            var aggregate = (context as AggregateTemplateContext);
                            <div>
                                <p>TrueCount: @aggregate.TrueCount</p>
                            </div>
                        }
                    </FooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(Order.Freight) Type="Syncfusion.Blazor.Grids.AggregateType.Max" Format="C2">
                    <FooterTemplate>
                        @{
                            var aggregate = (context as AggregateTemplateContext);
                            <div>
                                <p>Max: @aggregate.Max</p>
                            </div>
                        }
                    </FooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
    </GridAggregates>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer ID" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="Syncfusion.Blazor.Grids.ColumnType.Date" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShippedDate) HeaderText="Shipped Date" Format="d" Type="Syncfusion.Blazor.Grids.ColumnType.Date" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.IsVerified) HeaderText="Verified" Width="150" Type="ColumnType.Boolean"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCity) HeaderText="Ship City" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    private string[] Units = (new string[] { "ShipCountry" });
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 15).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "ERNSH", "SUPRD", "HANAR", "WELLI", "QUEDE" })[new Random().Next(5)],
                Freight = 2.1 * x,
                OrderDate = DateTime.Now.AddDays(-x),
                ShippedDate = DateTime.Now.AddDays(x),
                IsVerified=(new bool[]{true,false})[new Random().Next(2)],
                ShipCountry = (new string[] { "France", "Germany", "Brazil", "Belgium", "Switzerland" })[new Random().Next(5)],
                ShipCity = (new string[] { "Graz", "Charleroi", "Rio de Janeiro", "Resende", "	Lyon" })[new Random().Next(5)],
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public string ShipCountry { get; set; }
        public string ShipCity { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShippedDate { get; set; }
        public bool IsVerified { get; set; }
        public double? Freight { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDBAtOjITUNKaKqv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * Multiple types for a column are supported only when one of the aggregate templates is used.

## See also

* [Handling Aggregates in Custom Adaptor](https://blazor.syncfusion.com/documentation/datagrid/custom-binding#handling-aggregates-in-custom-adaptor)