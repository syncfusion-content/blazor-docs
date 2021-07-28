---
layout: post
title: Lazy loading in Blazor Chart Component | Syncfusion
description: Learn here all about how to achieve lazy loading in the Syncfusion Blazor Chart component step by step.
platform: Blazor
control: Chart
documentation: ug
---

# Lazy loading in Blazor Chart Component

The lazy loading loads data for the chart on demand. The  [`OnScrollChanged`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnScrollChanged) event will be fired by the chart, allowing us to get the minimum and maximum ranges of the axes and then upload the data to the chart.

```razor
<ChartEvents OnScrollChanged="@ScrollChange"></ChartEvents>

private void ScrollChange(ScrollEventArgs e)
{
    this.dataSource = GetRangeData(Convert.ToInt32(e.CurrentRange.Minimum), Convert.ToInt32(e.CurrentRange.Maximum));
    this.StateHasChanged();
}

```

{% aspTab template="chart/how-to/lazy-loading", sourceFiles="lazy-loading.razor" %}

{% endaspTab %}

> Refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [`Blazor Chart Example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.