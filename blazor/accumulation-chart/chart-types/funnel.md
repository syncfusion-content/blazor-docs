---
layout: post
title: Funnel in Blazor Accumulation Chart Component | Syncfusion 
description: Learn about Funnel in Blazor Accumulation Chart component of Syncfusion, and more details.
platform: Blazor
control: Accumulation Chart
documentation: ug
---

# Funnel Chart

To render a funnel series, use the series [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_Type)
as `Funnel`.

{% aspTab template="chart/accumulation-charts/funnel/default", sourceFiles="default.razor" %}

{% endaspTab %}

![Funnel Chart](../images/funnel/default-razor.png)

## Size

The size of the funnel chart can be customized by using the  [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_Width) and [`Height`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_Height) properties.

{% aspTab template="chart/accumulation-charts/funnel/size", sourceFiles="size.razor" %}

{% endaspTab %}

![Size](../images/funnel/size-razor.png)

> Note: You can also explore our [`Blazor Funnel Chart`](https://blazor.syncfusion.com/demos/chart/funnel) example to knows how to render and configure the funnel chart.

## Neck Size

The neck size can be customized by using the [`NeckWidth`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_NeckWidth) and [`NeckHeight`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_NeckHeight) properties.

{% aspTab template="chart/accumulation-charts/funnel/neck-size", sourceFiles="neck-size.razor" %}

{% endaspTab %}

![Neck Size](../images/funnel/neck-size-razor.png)

## Gap Between the Segments

[`Funnel chart`](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/funnel-chart) provides options to customize the space between the segments by using the [`GapRatio`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_GapRatio) property of the
series. It takes values from 0 to 1.

{% aspTab template="chart/accumulation-charts/funnel/gap", sourceFiles="gap.razor" %}

{% endaspTab %}

![Gap Between the Segments](../images/funnel/gap-razor.png)

## Explode

Points can be exploded on mouse click by setting the [`Explode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_Explode) property to **true**. You can also explode the point
on load using [`ExplodeIndex`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_ExplodeIndex). Explode distance can be set by using [`ExplodeOffset`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_ExplodeOffset) property.

{% aspTab template="chart/accumulation-charts/funnel/explode", sourceFiles="explode.razor" %}

{% endaspTab %}

![Explode](../images/funnel/explode-razor.png)

## Smart Data Label

Arrange the data label smartly on left side of the funnel and pyramid chart, when they overlaps with each other.

{% aspTab template="chart/accumulation-charts/funnel/smart-data-label", sourceFiles="smart-data-label.razor" %}

{% endaspTab %}

![Smart Data Label](../images/funnel/smart-data-label-razor.png)

## See Also

* [Data label](../data-label/)
* [Grouping](../grouping/)
