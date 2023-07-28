---
layout: post
title:  Custom aggregate in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Custom aggregate in Syncfusion Blazor DataGrid component and much more details.
platform: Blazor
control: DataGrid
documentation: ug
---

# Custom aggregate

The custom aggregate feature in Syncfusion’s Blazor Grid component allows you to calculate aggregate values using your own aggregate function. This feature can be useful in scenarios where the built-in aggregate functions do not meet your specific requirements. To use the custom aggregate option, follow the steps below:

* Set the **AggregateType** as Custom in **GridAggregateColumn** directive.

* Provide your custom aggregate function in the **customAggregate** property.

The custom aggregate function will be invoked differently for total and group aggregations:

**Total Aggregation:** The custom aggregate function will be called with the whole dataset and the current aggregate column object as arguments.

**Group Aggregation:** The custom aggregate function will be called with the current group details and the aggregate column object as arguments.

Here’s an example that demonstrates how to use the custom aggregate feature in the Blazor Grid component:

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid @ref="Grid" DataSource="@Products" AllowPaging="true">
    <GridAggregates>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(Product.TotalSales) Type="AggregateType.Custom">
                    <FooterTemplate>
                        @{
                            <div>
                                <p>Custom: @GetWeightedAggregate()</p>
                            </div>
                        }
                    </FooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
    </GridAggregates>
    <GridColumns>
        <GridColumn Field=@nameof(Product.ProductName) HeaderText="Product Name" TextAlign="TextAlign.Right" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Product.QuantityPerUnit) HeaderText="Quantity Per Unit" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Product.TotalSales) HeaderText="TotalSales" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Product.TotalCosts) HeaderText="TotalCosts" TextAlign="TextAlign.Right" Width="180"></GridColumn>
    </GridColumns>
</SfGrid>

@code{
    SfGrid<Product> Grid { get; set; }
    public List<Product> Products { get; set; }
    public string GetWeightedAggregate()
    {
        // Here, you can calculate custom aggregate operations and return the result.
        return Queryable.Sum(Products.Select(x => (x.TotalSales + x.TotalCosts) / x.TotalSales).AsQueryable()).ToString();
    }
    protected override void OnInitialized()
    {
        Products = Enumerable.Range(1, 5).Select(x => new Product
        {
            ProductName = (new string[] { "Chai", "Chang", "Aniseed Syrup", "Chef Anton's Cajun Seasoning", "Chef Anton's Gumbo Mix" })[new Random().Next(5)],
            QuantityPerUnit = (new string[] { "10 boxes x 20 bags", "24 - 12 oz bottles", "12 - 550 ml bottles", "48 - 6 oz jars", "36 boxes" })[new Random().Next(5)],
            TotalSales = 100 * x,
            TotalCosts = 200 * x,
            Discontinued = (new bool[] { true, false })[new Random().Next(2)]
        }).ToList();
    }

    public class Product
    {
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public int TotalSales { get; set; }
        public int TotalCosts { get; set; }
        public bool Discontinued { get; set; }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDBKjdhnWQHwbucf?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> To access the custom aggregate value inside template, use the key as Custom

> You can refer to the [Blazor DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid) feature tour page for its groundbreaking feature representations. You can also explore [Blazor DataGrid example](https://blazor.syncfusion.com/demos/datagrid/overview?theme=bootstrap4) to understand how to present and manipulate data.