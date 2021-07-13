---
layout: post
title: Stack Bar in Blazor Chart Component | Syncfusion 
description: Learn about Stack Bar in Blazor Chart component of Syncfusion, and more details.
platform: Blazor
control: Chart
documentation: ug
---

---
title: "100% Stacked Bar Chart in Blazor Charts component | Syncfusion"

component: "Charts"

description: "Learn here all about 100% Stacked Bar Chart of Syncfusion Charts (SfCharts) component and more."
---
# 100% Stacked Bar Chart in Blazor Charts (SfCharts)

## 100% Stacked Bar

[`100% Stacked Bar Chart`](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/100-stacked-bar-chart) displays multiple series of data as stacked areas, ensuring that the cumulative proportion of each stacked element always totals 100%. The y-axis will hence always be rendered with the range 0–100%. To render a [`100% Stacked Bar`](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/100-stacked-bar-chart) series, use series [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Charts.ChartSeries~Type.html) as [`StackingBar100`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_StackingBar100).

{% aspTab template="chart/series/bar-charts/100%stackedbar", sourceFiles="stackedbar100.razor" %}

{% endaspTab %}

![100% Stacked Bar](../images/chart-types-images/stackedbar100.png)

> Refer to our [`Blazor 100% Stacked Bar Chart`](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/100-stacked-bar-chart) feature tour page to know about its other groundbreaking feature representations. You can also explore our [`Blazor 100% Stacked Bar Chart Example`](https://blazor.syncfusion.com/demos/chart/percent-stacked-bar?theme=bootstrap4) to know how to render and configure the 100% Stacked Bar type chart.

## Series Customization

The following properties can be used to customize the [`100% Stacked Bar`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_StackingBar100) series.

* [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) – Specifies the color of the series.
* [`Opacity`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Opacity) – Specifies the opacity of [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill).
* [`DashArray`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DashArray) – Specifies the dashes of series border.
* [`ChartSeriesBorder`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesBorder.html) – Specifies the [`Color`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonBorder.html#Syncfusion_Blazor_Charts_ChartCommonBorder_Color) and [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonBorder.html#Syncfusion_Blazor_Charts_ChartCommonBorder_Width) of series border.

{% aspTab template="chart/series/bar-charts/custom-bar", sourceFiles="custom-bar.razor" %}

{% endaspTab %}

![Custom 100% Stacked Bar](../images/chart-types-images/custom-stacked-bar-100.png)

> Refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See Also

* [Data Label](../data-labels)
* [Tooltip](../tool-tip)