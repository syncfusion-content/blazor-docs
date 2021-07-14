---
layout: post
title: Range Column Chart in Blazor Charts component | Syncfusion
description: Learn here all about Range Column Chart of Syncfusion Charts (SfCharts) component and more.
platform: Blazor
control: Chart
documentation: ug
---

# Range Column Chart in Blazor Charts (SfCharts)

## Range Column

[`Range Column Chart`](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/range-column-chart) visualizes the variations in the data values for a given time using vertical bars. To render a [`Range Column Chart`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_RangeColumn), use series [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Charts.ChartSeries~Type.html) as [`RangeColumn`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_RangeColumn).

{% aspTab template="chart/series/column-charts/rangecolumn", sourceFiles="rangecolumn.razor" %}

{% endaspTab %}

![Range Column](../images/chart-types-images/rangecolumn.png)

> Refer to our [`Blazor Range Column Chart`](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/range-column-chart) feature tour page to know about its other groundbreaking feature representations. Explore our [`Blazor Range Column Chart Example`](https://blazor.syncfusion.com/demos/chart/range-column?theme=bootstrap4) to know how to show variations in the data values for a given time.

## Series Customization

The following properties can be used to customize the [`Range Column`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_RangeColumn) series.

* [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) – Specifies the color of the series.
* [`Opacity`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Opacity) – Specifies the opacity of [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill).
* [`DashArray`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DashArray) – Specifies the dashes of series border.
* [`ChartSeriesBorder`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesBorder.html) – Specifies the [`Color`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonBorder.html#Syncfusion_Blazor_Charts_ChartCommonBorder_Color) and [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonBorder.html#Syncfusion_Blazor_Charts_ChartCommonBorder_Width) of series border.
* [`ColumnSpacing`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_ColumnSpacing) – Specifies the space between the series segments.

{% aspTab template="chart/series/column-charts/rangecolumn", sourceFiles="custom-rangecolumn.razor" %}

{% endaspTab %}

![Custom Range Column](../images/chart-types-images/custom-range-column.png)

> Refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See Also

* [Data Label](../data-labels)

* [Tooltip](../tool-tip)