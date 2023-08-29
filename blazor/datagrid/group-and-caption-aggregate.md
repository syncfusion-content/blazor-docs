---
layout: post
title:  Group and caption aggregate in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Group and caption aggregate in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Group and caption aggregate

Group footer and caption aggregates in the Syncfusion Blazor Grid component allow you to calculate aggregate values based on the current group items. These aggregate values can be displayed in the group footer cells and group caption cells, respectively. To achieve this, you can use the **GroupFooterTemplate** and **GroupCaptionTemplate** properties of the **GridAggregateColumn** directive.

> When working with group aggregates in Syncfusion Grid, it is important to set the property **AllowGrouping** of the column to true.

To maintain grouped columns in the grid after grouping, set [showGroupedColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridGroupSettings.html#Syncfusion_Blazor_Grids_GridGroupSettings_ShowGroupedColumn) to true.

## Group footer aggregates

Group footer aggregates are displayed in the footer cells of each group. These cells appear at the bottom of each group and provide aggregate values based on the grouped data. To display group footer aggregates, you need to provide a template using the `GroupFooterTemplate` property. The template will be used to render the aggregate values in the group footer cells.

Here’s an example that demonstrates how to use group footer aggregates in the Syncfusion Blazor Grid component:

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" AllowGrouping="true">
    <GridPageSettings PageSize="5"></GridPageSettings>
    <GridGroupSettings Columns=@Units></GridGroupSettings>
     <GridAggregates>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(Order.Freight) Type="AggregateType.Sum">
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
     </GridAggregates>
    <GridColumns>
        <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.DateOnly" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCoutry) HeaderText="Ship Coutry" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }
    private string[] Units = (new string[] { "ShipCoutry" });

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 10).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "HANAR", "WELLI", "QUEDE", "VINET", "VICTE" })[new Random().Next(5)],
                Freight = 2.1 * x,
                OrderDate = new DateOnly(2023, 2, x),
                ShipCoutry=(new string[]{"France","Germany","US","Belgium","Australia"})[new Random().Next(5)]
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateOnly? OrderDate { get; set; }
        public string ShipCoutry { get; set; }
        public double? Freight { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LDhUDbLeUVuCRFWL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * Use the template reference variable name as #GroupFooterTemplate to specify the group footer template and as #GroupCaptionTemplate to specify the group caption template.

> * The aggregate values must be accessed inside the template using their corresponding [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_Type) name.

## Group caption aggregates

Group caption aggregates are displayed in the caption cells of each group. These cells appear at the top of each group and provide a summary of the grouped data. To display group caption aggregates, you can use the **GroupCaptionTemplate** property. This property allows you to define a template that will be used to display the aggregate values in the group caption cells.

Here’s an example that demonstrates how to use group and caption aggregates in the Syncfusion Blazor Grid component:

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" AllowGrouping="true">
    <GridPageSettings PageSize="5"></GridPageSettings>
    <GridGroupSettings Columns=@Units></GridGroupSettings>
     <GridAggregates>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(Order.Freight) Type="AggregateType.Max">
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
        <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Order.OrderDate) HeaderText="Order Date" Format="d" Type="ColumnType.DateOnly" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Order.ShipCoutry) HeaderText="Ship Coutry" Width="150"></GridColumn>
    </GridColumns>
</SfGrid>

@code {
    public List<Order> Orders { get; set; }
    private string[] Units = (new string[] { "ShipCoutry" });

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 10).Select(x => new Order()
            {
                OrderID = 1000 + x,
                CustomerID = (new string[] { "HANAR", "WELLI", "QUEDE", "VINET", "VICTE" })[new Random().Next(5)],
                Freight = 2.1 * x,
                OrderDate = new DateOnly(2023, 2, x),
                ShipCoutry=(new string[]{"France","Germany","US","Belgium","Australia"})[new Random().Next(5)]
            }).ToList();
    }

    public class Order
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateOnly? OrderDate { get; set; }
        public string ShipCoutry { get; set; }
        public double? Freight { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hXVgDbLSqzxvvitG?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> The group total summary in Syncfusion Grid is calculated based on the current page records for each group by default.