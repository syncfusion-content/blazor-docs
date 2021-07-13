---
layout: post
title: Waterfall in Blazor Chart Component | Syncfusion 
description: Learn about Waterfall in Blazor Chart component of Syncfusion, and more details.
platform: Blazor
control: Chart
documentation: ug
---

---
title: "Waterfall Chart in Blazor Charts component | Syncfusion"

component: "Charts"

description: "Learn here all about Waterfall Chart of Syncfusion Charts (SfCharts) component and more."
---
# Waterfall Chart in Blazor Charts (SfCharts)

## Waterfall

[`Blazor Waterfall Chart`](https://blazor.syncfusion.com/demos/chart/waterfall?theme=bootstrap4) helps to understand the cumulative effect of the sequentially introduced positive and negative values. To render a [`Waterfall`](https://blazor.syncfusion.com/demos/chart/waterfall?theme=bootstrap4) series, use series [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Charts.ChartSeries~Type.html) as [`Waterfall`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Waterfall). [`IntermediateSumIndexes`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_IntermediateSumIndexes) property of waterfall is used to represent the in between sum values and [`SumIndexes`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_SumIndexes) property is used to represent the cumulative sum values.

{% aspTab template="chart/series/other-types/waterfall", sourceFiles="waterfall.razor" %}

{% endaspTab %}

![Waterfall Chart](../images/othertypes/waterfall.png)

> Explore our [`Blazor Waterfall Chart Example`](https://blazor.syncfusion.com/demos/chart/waterfall?theme=bootstrap4) to know how to render a Waterfall series.

## Series Customization

The negative changes of [`Waterfall Chart`](https://blazor.syncfusion.com/demos/chart/waterfall?theme=bootstrap4) is represented by using [`NegativeFillColor`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Charts.ChartSeries~NegativeFillColor.html) and the summary changes are represented by using [`SummaryFillColor`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Charts.ChartSeries~SummaryFillColor.html) properties. By default, the  [`NegativeFillColor`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Charts.ChartSeries~NegativeFillColor.html) is **#E94649** and the [`SummaryFillColor`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Charts.ChartSeries~SummaryFillColor.html) is **#4E81BC**.

{% aspTab template="chart/series/other-types/custom-waterfall", sourceFiles="custom-waterfall.razor" %}

{% endaspTab %}

![Waterfall with series customization](../images/othertypes/waterfall-custom.png)

> Refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See Also

* [Data Label](../data-labels)
* [Tooltip](../tool-tip)