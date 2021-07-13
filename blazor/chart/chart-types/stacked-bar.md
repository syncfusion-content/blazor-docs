---
layout: post
title: Stacked Bar in Blazor Chart Component | Syncfusion 
description: Learn about Stacked Bar in Blazor Chart component of Syncfusion, and more details.
platform: Blazor
control: Chart
documentation: ug
---

---
title: "Stacked Bar Chart in Blazor Charts component | Syncfusion"

component: "Charts"

description: "Learn here all about Stacked Bar Chart of Syncfusion Charts (SfCharts) component and more."
---
# Stacked Bar Chart in Blazor Charts (SfCharts)

## Stacked Bar

[`Blazor Stacked Bar Chart`](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/stacked-bar-chart) is a chart with Y values stacked over one another in the series order. Shows the relation between individual values to the total sum of the points. To render a [`Stacked Bar`](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/stacked-bar-chart) series, use series [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Charts.ChartSeries~Type.html) as [`StackingBar`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_StackingBar).

{% aspTab template="chart/series/bar-charts/stackedbar", sourceFiles="stackedbar.razor" %}

{% endaspTab %}

![Stacked Bar](../images/chart-types-images/stackedbar.png)

> Refer to our [`Blazor Stacked Bar Chart`](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/stacked-bar-chart) feature tour page to know about its other groundbreaking feature representations. Explore our [`Blazor Stacked Bar Chart Example`](https://blazor.syncfusion.com/demos/chart/stacked-bar?theme=bootstrap4) to know how to to render and configure the Stacked Bar type charts

## Stacking Group

[`StackingGroup`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_StackingGroup) property is used to group the stacked bar and 100% stacked bar. Columns with same group name are stacked on top of each other.

{% aspTab template="chart/series/bar-charts/group", sourceFiles="group.razor" %}

{% endaspTab %}

![Stacking Group](../images/chart-types-images/groupbar.png)

## Series Customization

The following properties can be used to customize the [`Stacked Bar`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_StackingBar) series.

* [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) – Specifies the color of the series.
* [`Opacity`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Opacity) – Specifies the opacity of [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill).
* [`DashArray`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DashArray) – Specifies the dashes of series border.
* [`ChartSeriesBorder`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesBorder.html) – Specifies the [`Color`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonBorder.html#Syncfusion_Blazor_Charts_ChartCommonBorder_Color) and [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonBorder.html#Syncfusion_Blazor_Charts_ChartCommonBorder_Width) of series border.

{% aspTab template="chart/series/bar-charts/custom-bar", sourceFiles="custom-stacked-bar.razor" %}

{% endaspTab %}

![Custom Stacked bar](../images/chart-types-images/custom-stacked-bar.png)

> Refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See Also

* [Data Label](../data-labels)
* [Tooltip](../tool-tip)