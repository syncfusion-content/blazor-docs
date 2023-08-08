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

## Group footer aggregates

Group footer aggregates are displayed in the footer cells of each group. These cells appear at the bottom of each group and provide aggregate values based on the grouped data. To display group footer aggregates, you need to provide a template using the `GroupFooterTemplate` property. The template will be used to render the aggregate values in the group footer cells.

Here’s an example that demonstrates how to use group footer aggregates in the Syncfusion Blazor Grid component:

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Products" AllowGrouping="true" AllowPaging="true">
    <GridGroupSettings Columns=@Units></GridGroupSettings>
    <GridAggregates>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(Product.UnitsInStock) Type="AggregateType.Sum">
                    <GroupFooterTemplate>
                        @{
                            var aggregate = (context as AggregateTemplateContext);
                            <div>
                                <p>Total units: @aggregate.Sum</p>
                            </div>
                        }
                    </GroupFooterTemplate>
                </GridAggregateColumn>
                <GridAggregateColumn Field=@nameof(Product.Discontinued) Type="AggregateType.TrueCount">
                    <GroupFooterTemplate>
                        @{
                            var aggregate = (context as AggregateTemplateContext);
                            <div>
                                <p>Truecount: @aggregate.TrueCount</p>
                            </div>
                        }
                    </GroupFooterTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
    </GridAggregates>
    <GridColumns>
        <GridColumn Field=@nameof(Product.ProductName) HeaderText="Product Name" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Product.QuantityPerUnit) HeaderText="Quantity Per Unit" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Product.UnitsInStock) HeaderText="Units In Stock" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Product.Discontinued) HeaderText="Discontinued" TextAlign="TextAlign.Right" DisplayAsCheckBox="true" Type="ColumnType.Boolean"></GridColumn>
    </GridColumns>
</SfGrid>

@code{

    public List<Product> Products { get; set; }
    private string[] Units = (new string[] { "QuantityPerUnit" });
    protected override void OnInitialized()
    {
        Products = Enumerable.Range(1, 10).Select(x => new Product
        {
            ProductName = (new string[] { "Chai", "Chang", "Aniseed Syrup", "Chef Anton's Cajun Seasoning", "Chef Anton's Gumbo Mix" })[new Random().Next(5)],
            QuantityPerUnit = (new string[] { "10 boxes x 20 bags", "24 - 12 oz bottles", "12 - 550 ml bottles", "48 - 6 oz jars", "36 boxes" })[new Random().Next(5)],
            UnitsInStock = x,
            Discontinued = (new bool[] { true, false})[new Random().Next(2)]
        }).ToList();
    }

    public class Product
    {
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public int UnitsInStock { get; set; }
        public bool Discontinued { get; set; }
    }
}
```

The following image represents the Group and Caption template with aggregates.

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZBqXvZvHAPgoKxN?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * Use the template reference variable name as #GroupFooterTemplate to specify the group footer template and as #GroupCaptionTemplate to specify the group caption template.

> * The aggregate values must be accessed inside the template using their corresponding [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridAggregateColumn.html#Syncfusion_Blazor_Grids_GridAggregateColumn_Type) name.

## Group caption aggregates

Group caption aggregates are displayed in the caption cells of each group. These cells appear at the top of each group and provide a summary of the grouped data. To display group caption aggregates, you can use the **GroupCaptionTemplate** property. This property allows you to define a template that will be used to display the aggregate values in the group caption cells.

Here’s an example that demonstrates how to use group and caption aggregates in the Syncfusion Blazor Grid component:

```cshtml
@using Syncfusion.Blazor.Grids

<SfGrid DataSource="@Products" AllowGrouping="true" AllowPaging="true">
    <GridGroupSettings Columns=@Units></GridGroupSettings>
    <GridAggregates>
        <GridAggregate>
            <GridAggregateColumns>
                <GridAggregateColumn Field=@nameof(Product.UnitsInStock) Type="AggregateType.Max">
                    <GroupCaptionTemplate>
                        @{
                            var aggregate = (context as AggregateTemplateContext);
                            <div>
                                <p>Maximum: @aggregate.Max</p>
                            </div>
                        }
                    </GroupCaptionTemplate>
                </GridAggregateColumn>
            </GridAggregateColumns>
        </GridAggregate>
    </GridAggregates>
    <GridColumns>
        <GridColumn Field=@nameof(Product.ProductName) HeaderText="Product Name" TextAlign="TextAlign.Right" Width="120"></GridColumn>
        <GridColumn Field=@nameof(Product.QuantityPerUnit) HeaderText="Quantity Per Unit" Width="150"></GridColumn>
        <GridColumn Field=@nameof(Product.UnitsInStock) HeaderText="Units In Stock" TextAlign="TextAlign.Right" Width="130"></GridColumn>
        <GridColumn Field=@nameof(Product.Discontinued) HeaderText="Discontinued" TextAlign="TextAlign.Right" DisplayAsCheckBox="true" Type="ColumnType.Boolean"></GridColumn>
    </GridColumns>
</SfGrid>

@code {

    public List<Product> Products { get; set; }
    private string[] Units = (new string[] { "QuantityPerUnit" });
    protected override void OnInitialized()
    {
        Products = Enumerable.Range(1, 10).Select(x => new Product
            {
                ProductName = (new string[] { "Chai", "Chang", "Aniseed Syrup", "Chef Anton's Cajun Seasoning", "Chef Anton's Gumbo Mix" })[new Random().Next(5)],
                QuantityPerUnit = (new string[] { "10 boxes x 20 bags", "24 - 12 oz bottles", "12 - 550 ml bottles", "48 - 6 oz jars", "36 boxes" })[new Random().Next(5)],
                UnitsInStock = x,
                Discontinued = (new bool[] { true, false })[new Random().Next(2)]
            }).ToList();
    }

    public class Product
    {
        public string ProductName { get; set; }
        public string QuantityPerUnit { get; set; }
        public int UnitsInStock { get; set; }
        public bool Discontinued { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hNrgNvZvRUHRUSQq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> The group total summary in Syncfusion Grid is calculated based on the current page records for each group by default.