---
layout: post
title: Stack Line in Blazor Chart Component | Syncfusion 
description: Learn about Stack Line in Blazor Chart component of Syncfusion, and more details.
platform: Blazor
control: Chart
documentation: ug
---

---
title: "100% Stacked Line Chart in Blazor Charts component | Syncfusion"

component: "Charts"

description: "Learn here all about 100% Stacked Line Chart of Syncfusion Charts (SfCharts) component and more."
---
# 100% Stacked Line Chart in Blazor Charts (SfCharts)

## 100% Stacked Line

[`100% Stacked Line Chart`](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/100-stacked-line-chart) displays multiple series of data as stacked areas, ensuring that the cumulative proportion of each stacked element always totals 100%. The y-axis will hence always be rendered with the range 0–100%. To render a [`100% Stacked Line`](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/100-stacked-line-chart) series, use series [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Charts.ChartSeries~Type.html) as [`StackingLine100`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_StackingLine100).

{% aspTab template="chart/series/line-charts/stacked-line-100", sourceFiles="stacked-line-100.razor" %}

{% endaspTab %}

![100% Stacked Line](../images/chart-types-images/stacked-line-100.png)

> Refer to our [`Blazor 100% Stacked Line Chart`](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/100-stacked-line-chart) feature tour page to know about its other groundbreaking feature representations. Explore our [`Blazor 100% Stacked Line Chart Example`](https://blazor.syncfusion.com/demos/chart/percent-stacked-line?theme=bootstrap4) to know how to render and configure the 100% Stacked Line type chart.

## Series Customization

The following properties can be used to customize the [`100% Stacked Line`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_StackingLine100) series.

* [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) – Specifies the color of the series.
* [`Opacity`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Opacity) – Specifies the opacity of [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill).
* [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Charts.ChartSeries~Width.html) – Specifies the width of the line stroke.
* [`DashArray`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DashArray) – Specifies the dashes of line stroke.

{% aspTab template="chart/series/line-charts/stacked-line-100", sourceFiles="custom-stacked-line-100.razor" %}

{% endaspTab %}

![Custom 100% Stacked Line](../images/chart-types-images/custom-stacked-line-100.png)

> Refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See Also

* [Data Label](../data-labels)
* [Tooltip](../tool-tip)