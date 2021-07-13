---
layout: post
title: Aggregate in Blazor Tree Grid Component | Syncfusion 
description: Learn about Aggregate in Blazor Tree Grid component of Syncfusion, and more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Aggregates

Aggregate values are displayed in the Tree Grid footer and in parent row footer for child row aggregate values. It can be configured through [`TreeGridAggregateColumn`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridAggregateColumn.html) property.
 [`Field`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridAggregateColumn~Field.html) and [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridAggregateColumn~Type.html)
 are the minimum properties required to represent an aggregate column.

By default, the aggregate value can be displayed in the Tree Grid footer, and footer of child rows. To show the aggregate value in one of the cells, use the [`FooterTemplate`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridAggregateColumn~FooterTemplate.html).

## Built-in aggregate types

The aggregate type should be specified in the [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridAggregateColumn~Type.html) property to configure an aggregate column.

The built-in aggregates are,
* Sum
* Average
* Min
* Max
* Count
* Truecount
* Falsecount

> * Multiple aggregates can be used for an aggregate column by setting the [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridAggregateColumn~Type.html) property with an array of aggregate types.
> * Multiple types for a column is supported only when one of the aggregate templates is used.

## Footer aggregate

Footer aggregate value is calculated for all the rows, and it is displayed in the footer cells. Use the [`FooterTemplate`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridAggregateColumn~FooterTemplate.html) to render the aggregate value in footer cells.

{% aspTab template="tree-grid/aggregate/footeraggregate", sourceFiles="index.razor,TreeGriddata.cs" %}

{% endaspTab %}

The following output is displayed as a result of the above code example.

![Footer Aggregate](images/summary.png)

> The aggregate values must be accessed inside the template using their corresponding `AggregateType`.

## How to format aggregate value

You can format the aggregate value result by using the [`Format`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridAggregateColumn~Format.html) property.

{% aspTab template="tree-grid/aggregate/formataggregate", sourceFiles="index.razor,TreeGriddata.cs" %}

{% endaspTab %}

The following output is displayed as a result of the above code example.

![Format Aggregate](images/aggregateformat.png)

<!-- Custom aggregate

To calculate the aggregate value with your own aggregate functions, use the custom aggregate option. To use custom aggregation, specify the [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridAggregateColumn~Type.html) as `Custom`, and provide the custom aggregate function in the [`CustomAggregate`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridAggregateColumn~CustomAggregate.html) property.

> To access the custom aggregate value inside the template, use the key as `Custom`.

-->

## Limitations

* By default, Footer Aggregate or total aggregate will be shown only for the current page records and not for the dataSource. To aggregate for all page records, set adaptor in **SfDataManager**.
