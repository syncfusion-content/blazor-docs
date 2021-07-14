---
layout: post
title: High Low Open Close Chart in Blazor Charts component | Syncfusion
description: Learn here all about High Low Open Close Chart of Syncfusion Charts (SfCharts) component and more.
platform: Blazor
control: Chart
documentation: ug
---

# High Low Open Close Chart in Blazor Charts (SfCharts)

## High Low Open Close

[`HiloOpenClose`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_HiloOpenClose) series is used to represent the **Low**, **High**, **Open** and **Closing** values over time and it can be rendered by specifying the series [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Charts.ChartSeries~Type.html) as [`HiloOpenClose`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_HiloOpenClose).

{% aspTab template="chart/series/financial-charts/hilo-openclose", sourceFiles="hilo-openclose.razor" %}

{% endaspTab %}

## Series Customization

In [`HiloOpenClose`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_HiloOpenClose) series, [`BullFillColor`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_BullFillColor) property is used to fill the segment when the open value is greater than the close value and [`BearFillColor`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_BearFillColor) property is used to fill the segment when the open
value is less than the close value. By default, [`BullFillColor`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_BullFillColor) is set as **Red** and [`BearFillColor`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_BearFillColor) is set as **Green**.

{% aspTab template="chart/series/financial-charts/custom-openclose", sourceFiles="custom-openclose.razor" %}

{% endaspTab %}

![HiloOpenClose with Series Customization](../images/financial-types/custom.png)

> Refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See Also

* [Data Label](../data-labels)
* [Tooltip](../tool-tip)