---
layout: post
title:  Reactive aggregate in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Reactive aggregate in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Reactive aggregate

The Syncfusion Blazor Grid component provides support for reactive aggregates, which allow you to update the aggregate values dynamically as the data changes. Reactive aggregates automatically recalculate their values when there are changes in the underlying data, providing real-time updates to the aggregate values in the grid.

## Auto update aggregate value in batch editing

When the grid is in batch editing mode, the aggregate values in the footer, group footer, and group caption are automatically refreshed every time a cell is saved. This ensures that the aggregate values accurately reflect the edited data.

Here’s an example code snippet demonstrating how to auto update aggregate value in batch editing:

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Orders" AllowPaging="true" AllowGrouping=true Toolbar="@ToolbarItems">
    <GridEditSettings AllowDeleting="true" AllowEditing="true" Mode="EditMode.Batch"></GridEditSettings>
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
                <GridAggregateColumn Field=@nameof(Order.Freight) Type="AggregateType.Sum" Format="C2">
                    <FooterTemplate>
                        @{
                            var aggregate = (context as AggregateTemplateContext);
                            <div>
                                <p>Sum: @aggregate.Sum</p>
                            </div>
                        }
                    </FooterTemplate>
                </GridAggregateColumn>
               
                <GridAggregateColumn Field=@nameof(Order.Freight) Type="AggregateType.Average" Format="C2">
                    <GroupCaptionTemplate>
                        @{
                            var aggregate = (context as AggregateTemplateContext);
                            <div>
                                <p>Average: @aggregate.Average</p>
                            </div>
                        }
                    </GroupCaptionTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
    </GridAggregates>
    
    <GridColumns>
         <GridColumn Field=@nameof(Order.OrderID) HeaderText="Order ID" IsPrimaryKey=true TextAlign="TextAlign.Right" Width="120"></GridColumn>
         <GridColumn Field=@nameof(Order.CustomerID) HeaderText="Customer Name" Width="150"></GridColumn>
         <GridColumn Field=@nameof(Order.Freight) HeaderText="Freight" Format="C2" TextAlign="TextAlign.Right" Width="120"></GridColumn>
         <GridColumn Field=@nameof(Order.OrderDate) HeaderText=" Order Date" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130"></GridColumn>
         <GridColumn Field=@nameof(Order.ShipCountry) HeaderText="Ship Country" Width="140"></GridColumn>
   </GridColumns>
</SfGrid>

@code
{
    private List<string> ToolbarItems = new List<string>(){ "Update","Cancel", "Delete"};
    public List<Order> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = Enumerable.Range(1, 8).Select(x => new Order()
        {
            OrderID = 1000 + x,
            CustomerID = (new string[] { "ALFKI", "ANANTR", "ANTON", "BLONP", "BOLID", "AROUT", "BERGS", "BLAUS" })[new Random().Next(8)],
            Freight = 2.1 * x,
            OrderDate = DateTime.Now.AddDays(-x),
            ShipCountry = (new string[] { "Sweden", "Germany", "Argentina", "Mexico", "Denmark", "Finland", "Switzerland", "UK" })[new Random().Next(8)],
        }).ToList();
    }

    public class Order 
    {
        public int? OrderID { get; set; }
        public string CustomerID { get; set; }
        public DateTime? OrderDate { get; set; }
        public string ShipCountry {  get;  set; }
        public double? Freight { get; set; }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjhqjnLdMmPzOYOi?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> Adding a new record to the grouped grid will not refresh the aggregate values.



