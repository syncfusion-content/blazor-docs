---
title: "Stacked Column Chart in Blazor Charts component | Syncfusion"

component: "Charts"

description: "Learn here all about Stacked Column Chart of Syncfusion Charts (SfCharts) component and more."
---
# Stacked Column Chart in Blazor Charts (SfCharts)

## Stacked Column

[`Blazor Stacked Column Chart`](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/stacked-column-chart) is a chart with Y values stacked over one another in the series order. Shows the relation between individual values to the total sum of the points. To render a [`Stacked Column`](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/stacked-column-chart) series, use series [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Charts.ChartSeries~Type.html) as [`StackingColumn`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_StackingColumn).

{% aspTab template="chart/series/column-charts/stackedcolumn", sourceFiles="stackedcolumn.razor" %}

{% endaspTab %}

![Stacked Column](../images/chart-types-images/stacked-column.png)

> Refer to our [`Blazor Stacked Column Chart`](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/stacked-column-chart) feature tour page to know about its other groundbreaking feature representations. Explore our [`Blazor Stacked Column Chart Example`](https://blazor.syncfusion.com/demos/chart/stacked-column?theme=bootstrap4) to know how to render and configure the Stacked Column type chart.

## Stacking Group

[`StackingGroup`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_StackingGroup) property is used to group the stacked columns and 100% stacked columns. Columns with same group name are stacked on top of each other.

{% aspTab template="chart/series/column-charts/group", sourceFiles="group.razor" %}

{% endaspTab %}

![Stacking Group](../images/chart-types-images/groupcolumn.png)

## Series Customization

The following properties can be used to customize the [`Stacked Column`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_StackingColumn) series.

* [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) – Specifies the color of the series.
* [`Opacity`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Opacity) – Specifies the opacity of [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill).
* [`DashArray`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DashArray) – Specifies the dashes of series border.
* [`ChartSeriesBorder`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesBorder.html) – Specifies the [`Color`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonBorder.html#Syncfusion_Blazor_Charts_ChartCommonBorder_Color) and [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonBorder.html#Syncfusion_Blazor_Charts_ChartCommonBorder_Width) of series border.

{% aspTab template="chart/series/column-charts/custom-column", sourceFiles="custom-stacked-column.razor" %}

{% endaspTab %}

![Custom Stacked Column](../images/chart-types-images/custom-stacked-column.png)

> Refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See Also

* [Data Label](../data-labels)
* [Tooltip](../tool-tip)