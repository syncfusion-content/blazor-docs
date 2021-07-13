---
title: "Stacked Area Chart in Blazor Charts component | Syncfusion"

component: "Charts"

description: "Learn here all about Stacked Area Chart of Syncfusion Charts (SfCharts) component and more."
---
# Stacked Area Chart in Blazor Charts (SfCharts)

## Stacked Area

[`Blazor Stacked Area Chart`](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/stacked-area-chart) is a chart with Y values stacked over one another in the series order. Shows the relation between individual values to the total sum of the points. To render a [`Stacked Area`](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/stacked-area-chart) series, use series [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Charts.ChartSeries~Type.html) as [`StackingArea`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_StackingArea).

{% aspTab template="chart/series/area-charts/stackedarea", sourceFiles="stackedarea.razor" %}

{% endaspTab %}

![Stacked Area](../images/chart-types-images/stackedarea.png)

> Refer to our [`Blazor Stacked Area Chart`](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/stacked-area-chart) feature tour page to know about its other groundbreaking feature representations. Explore our [`Blazor Stacked Area Chart Example`](https://blazor.syncfusion.com/demos/chart/stacked-area?theme=bootstrap4) to know how to to render and configure the Stacked Area type charts

## Series Customization

The following properties can be used to customize the [`Stacked Area`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_StackingArea) series.

* [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) – Specifies the color of the series.
* [`Opacity`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Opacity) – Specifies the opacity of [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill).
* [`DashArray`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DashArray) – Specifies the dashes of series border.
* [`ChartSeriesBorder`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesBorder.html) – Specifies the [`Color`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonBorder.html#Syncfusion_Blazor_Charts_ChartCommonBorder_Color) and [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonBorder.html#Syncfusion_Blazor_Charts_ChartCommonBorder_Width) of series border.

{% aspTab template="chart/series/area-charts/stackedarea", sourceFiles="custom-stackedarea.razor" %}

{% endaspTab %}

![Custom Stacked Area](../images/chart-types-images/custom-stacked-area.png)

> Refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See Also

* [Data Label](../data-labels)
* [Tooltip](../tool-tip)