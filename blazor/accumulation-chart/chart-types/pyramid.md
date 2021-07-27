---
title: "Pyramid Chart in Blazor Accumulation Charts component | Syncfusion"

component: "Accumulation Charts"

description: "Learn here all about Pyramid Chart of Syncfusion Accumulation Charts (SfAccumulationChart) component and more."
---

# Pyramid Chart

The [`Pyramid Chart`](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/pyramid-chart) used to visualize the hierarchical data in upside triangle shape with horizontally divided section. To render the [`Pyramid Chart`](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/pyramid-chart), set the series [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_Type) as [`Pyramid`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationType.html#Syncfusion_Blazor_Charts_AccumulationType_Pyramid).

{% aspTab template="chart/accumulation-charts/pyramid/default", sourceFiles="default.razor" %}

{% endaspTab %}

![Pyramid Chart](../images/pyramid/default-razor.png)

## Pyramid Mode

The [`Pyramid Chart`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationType.html#Syncfusion_Blazor_Charts_AccumulationType_Pyramid) can be rendered in both [`Linear`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.PyramidMode.html#Syncfusion_Blazor_Charts_PyramidMode_Linear) and [`Surface`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.PyramidMode.html#Syncfusion_Blazor_Charts_PyramidMode_Surface) modes. The [`PyramidMode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_PyramidMode)'s default type is [`Linear`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.PyramidMode.html#Syncfusion_Blazor_Charts_PyramidMode_Linear).

{% aspTab template="chart/accumulation-charts/pyramid/mode", sourceFiles="mode.razor" %}

{% endaspTab %}

![Pyramid Mode](../images/pyramid/mode-razor.png)

## Size

The size of the pyramid chart can be customized by using the [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_Width) and [`Height`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_Height) properties.

{% aspTab template="chart/accumulation-charts/pyramid/size", sourceFiles="size.razor" %}

{% endaspTab %}

![Pyramid Size](../images/pyramid/size-razor.png)

## Gap Between Pyramid Segments

The [`Pyramid Chart`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationType.html#Syncfusion_Blazor_Charts_AccumulationType_Pyramid) provides options to customize the space between the segments by using the [`GapRatio`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_GapRatio) property of the
series. It accepts values ranging from 0 to 1.

{% aspTab template="chart/accumulation-charts/pyramid/gap", sourceFiles="gap.razor" %}

{% endaspTab %}

![Gap Between Pyramid Segments](../images/pyramid/gap-razor.png)

## Pyramid Explode

By setting the [`Explode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_Explode) property to **true**, points can be exploded on mouse click. Using the [`ExplodeIndex`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_ExplodeIndex) property, expand the point on load. The [`ExplodeOffset`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_ExplodeOffset) property can be used to set the distance between explosions.

{% aspTab template="chart/accumulation-charts/pyramid/explode", sourceFiles="explode.razor" %}

{% endaspTab %}

![Pyramid Explode](../images/pyramid/explode-razor.png)

> Refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [`Blazor Accumulation Chart Example`](https://blazor.syncfusion.com/demos/chart/pyramid?theme=bootstrap4) to know various features of accumulation charts and how it is used to represent numeric proportional data.

## See Also

* [Data label](../data-label/)
* [Grouping](../grouping/)