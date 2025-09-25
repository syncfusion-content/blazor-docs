---
layout: post
title: Aggregate customization in Blazor DataGrid | Syncfusion
description: Learn how to customize aggregate rows in the Syncfusion Blazor DataGrid using CSS, including footer containers and summary cells.
platform: Blazor
control: DataGrid
documentation: ug
---

# Aggregate customization in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid

Aggregates render in the Grid footer as summary rows and can be styled with custom CSS. The examples below show how to customize the footer container (aggregate root element) and the individual summary cells. For API details, see Grid aggregates, GridAggregateColumn, AggregateType, and the FooterTemplate with AggregateTemplateContext.

- Grid aggregates: https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregates.html
- GridAggregateColumn: https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html
- AggregateType: https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.AggregateType.html
- FooterTemplate: https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_FooterTemplate
- AggregateTemplateContext: https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.AggregateTemplateContext.html

> Note: When using CSS isolation (.razor.css), target Grid internals with the ::deep combinator or wrap the Grid in a custom class and scope styles to that wrapper to increase selector specificity.

## Customizing the aggregate root element

To customize the appearance of the Grid footer’s aggregate root container, use the following CSS:

```css
.e-grid .e-gridfooter {
    font-family: cursive;
}
```

In this example, the e-gridfooter class represents the root container of the aggregate footer row. Adjust properties such as font-family, font-size, padding, or borders as needed.

![Customize aggregate root element](../images/style-and-appearance/aggregate-root-element.png)

## Customizing the aggregate cell elements

To customize the appearance of the summary row cells, use the following CSS:

```css
.e-grid .e-summaryrow .e-summarycell {
    background-color: #deecf9;
}
```

Here, the `e-summaryrow` class targets the summary row, and `e-summarycell` targets individual cells within that row. Modify properties such as background-color, color, text-align, or borders to achieve the desired style.

![Customize aggregate cell element](../images/style-and-appearance/aggregate-cell-element.png)

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Orders" Height="315" AllowPaging="true">
    <GridPageSettings PageSize="8"></GridPageSettings>
    <GridAggregates>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(OrderData.Freight) Type="AggregateType.Sum" >
                    <FooterTemplate>
                        @{
                            var aggregate = (context as AggregateTemplateContext);
                            <div>
                                <p>Sum: @aggregate.Sum</p>
                            </div>
                        }
                    </FooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(OrderData.Freight) Type="AggregateType.Max">
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
        <GridColumn Field=@nameof(OrderData.OrderID) HeaderText="Order ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="140"></GridColumn>
        <GridColumn Field=@nameof(OrderData.CustomerID) HeaderText="Customer ID" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.Freight) HeaderText="Freight" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(OrderData.OrderDate) HeaderText="Order Date" Format="d" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GridColumn>
    </GridColumns>
</SfGrid>

<style>
    .e-grid .e-gridfooter {
        font-family: cursive;
    }
    .e-grid .e-summaryrow .e-summarycell {
        background-color: #deecf9;
    }
</style>

@code {
    private SfGrid<OrderData> Grid;
    public List<OrderData> Orders { get; set; }

    protected override void OnInitialized()
    {
        Orders = OrderData.GetAllRecords();
    }
}

{% endhighlight %}

{% highlight c# tabtitle="OrderData.cs" %}

public class OrderData
{
    public static List<OrderData> Orders = new List<OrderData>();

    public OrderData(int orderID, string customerID, double freight, DateTime orderDate)
    {
        this.OrderID = orderID;
        this.CustomerID = customerID;
        this.Freight = freight;
        this.OrderDate = orderDate;
    }

    public static List<OrderData> GetAllRecords()
    {
        if (Orders.Count == 0)
        {
            Orders.Add(new OrderData(10248, "VINET", 32.38, new DateTime(2024, 1, 10)));
            Orders.Add(new OrderData(10249, "TOMSP", 11.61, new DateTime(2024, 1, 11)));
            Orders.Add(new OrderData(10250, "HANAR", 65.83, new DateTime(2024, 1, 12)));
            Orders.Add(new OrderData(10251, "VICTE", 41.34, new DateTime(2024, 1, 13)));
            Orders.Add(new OrderData(10252, "SUPRD", 51.3, new DateTime(2024, 1, 14)));
            Orders.Add(new OrderData(10253, "HANAR", 58.17, new DateTime(2024, 1, 15)));
            Orders.Add(new OrderData(10254, "CHOPS", 22.98, new DateTime(2024, 1, 16)));
            Orders.Add(new OrderData(10255, "RICSU", 148.33, new DateTime(2024, 1, 17)));
            Orders.Add(new OrderData(10256, "WELLI", 13.97, new DateTime(2024, 1, 18)));
            Orders.Add(new OrderData(10257, "HILAA", 81.91, new DateTime(2024, 1, 19)));
        }

        return Orders;
    }

    public int OrderID { get; set; }
    public string CustomerID { get; set; }
    public double Freight { get; set; }
    public DateTime OrderDate { get; set; }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/BNLoXStLKgmIIyaI" %}