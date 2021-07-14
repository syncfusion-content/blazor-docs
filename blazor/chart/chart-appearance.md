---
layout: post
title: Appearance in Blazor Charts component | Syncfusion
description: Learn here all about Appearance of Syncfusion Charts (SfCharts) component and more.
platform: Blazor
control: Chart
documentation: ug
---

# Appearance in Blazor Charts (SfCharts)

## Custom Color Palette

The default colour of series or points can be changed by providing a custom colour palette to the [`Palettes`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_Palettes) property .

{% aspTab template="chart/series/column/custom", sourceFiles="custom.razor" %}

{% endaspTab %}

![Custom Color Palette](images/appearance/custom-razor.png)

<!-- markdownlint-disable MD036 -->

## Chart Customization

<!-- markdownlint-disable MD036 -->

**Chart Background**

<!-- markdownlint-disable MD013 -->

The chart's background colour and border can be changed using the [`Background`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_Background) and [`Border`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartBorder.html) properties.

{% aspTab template="chart/series/column/area", sourceFiles="area.razor" %}

{% endaspTab %}

![Customize the Chart Background](images/appearance/area-razor.png)

**Chart Margin**

The [`Margin`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartMargin.html) property allows you to set the chart's margin from its container.

{% aspTab template="chart/series/column/margin", sourceFiles="margin.razor" %}

{% endaspTab %}

**Chart Area Background**

The chart area background can be customized by using the [`Background`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartArea.html#Syncfusion_Blazor_Charts_ChartArea_Background)
property in the [`ChartArea`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartArea.html).

{% aspTab template="chart/series/column/background", sourceFiles="background.razor" %}

{% endaspTab %}

## Animation

The [`Animation`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Animation) property allows you to customize animation for a certain series. The [`Enable`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartCommonAnimation.html#Syncfusion_Blazor_Charts_StockChartCommonAnimation_Enable) property can be used to enable or disable the series' animation. The duration of the animation is specified by [`Duration`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartCommonAnimation.html#Syncfusion_Blazor_Charts_StockChartCommonAnimation_Duration), and [`Delay`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.StockChartCommonAnimation.html#Syncfusion_Blazor_Charts_StockChartCommonAnimation_Delay) allows to start the animation at a specific moment.

{% aspTab template="chart/series/column/animation", sourceFiles="animation.razor" %}

{% endaspTab %}

## Chart Title

The [`Title`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_Title) property can be used to give a title to a chart in order to provide information about the data shown.

{% aspTab template="chart/series/column/title", sourceFiles="title.razor" %}

{% endaspTab %}

![Chart Title](images/appearance/title-razor.png)

## Chart SubTitle

The [`SubTitle`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_SubTitle) property can be used to provide a chart a subtitle that displays information about the data shown.

{% aspTab template="chart/series/column/subtitle", sourceFiles="subtitle.razor" %}

{% endaspTab %}

![Chart SubTitle](images/appearance/subtitle-razor.png)

> Refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See Also

* [Data Label](./data-labels)
* [Tooltip](./tool-tip)