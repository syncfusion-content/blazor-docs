<!-- markdownlint-disable MD036 -->

# Lazy loading

Lazy loading allows you to load data for chart on demand. Chart will fire the [`OnScrollChanged`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnScrollChanged) event, in that we can get the minimum and maximum range of the axis, based on this, we can upload the data to chart.

```razor
   <ChartEvents OnScrollChanged="@ScrollChange"></ChartEvents>

  void ScrollChange(ScrollEventArgs e)
    {
        this.dataSource = GetRangeData(Convert.ToInt32(e.CurrentRange.Minimum), Convert.ToInt32(e.CurrentRange.Maximum));
        this.StateHasChanged();
    }

```

{% aspTab template="chart/how-to/lazy-loading", sourceFiles="lazy-loading.razor" %}

{% endaspTab %}

> Note: You can refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations. You can also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to knows various chart types and how to represent time-dependent data, showing trends in data at equal intervals.