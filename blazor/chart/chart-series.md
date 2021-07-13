---
title: "Chart Series in Blazor Charts component | Syncfusion"

component: "Charts"

description: "Learn here all about Chart Series of Syncfusion Charts (SfCharts) component and more."
---

# Chart Series in Blazor Charts (SfCharts)

## Multiple Series

The [`ChartSeries`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html) property allows to add multiple series to the chart. The series are rendered in the order they were added to the series array.

{% aspTab template="chart/series/multiple-series", sourceFiles="multiple-series.razor" %}

{% endaspTab %}

![Multiple Series](images/multiple-series/multiple-series-razor.png)

## Combination Series

A chart can be created by combining several types such as line, column, and so on.

>Bar series cannot be combined with any other series as the axis orientation is different from other series.

{% aspTab template="chart/series/combination", sourceFiles="combination.razor" %}

{% endaspTab %}

![Combination Series](images/multiple-series/combination-razor.png)

> Refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See Also

* [Data Label](./data-labels)
* [Tooltip](./tool-tip)
* [Legend](./legend)