---
layout: post
title: How to Add Remove in Blazor Chart Component | Syncfusion
description: Checkout and learn about Add Remove in Blazor Chart component of Syncfusion, and more details.
platform: Blazor
control: Chart
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Add or remove a series from the chart dynamically

You can add or remove the chart series dynamically.

To add or remove the series dynamically, follow the given steps:

**Step 1**:

 Render the series using Collection.

```razor
    <SfChart>
        <ChartSeriesCollection>
            @foreach (SeriesData series in SeriesCollection)
            {
                <ChartSeries XName=@series.XName YName=@series.YName DataSource=@series.Data>
                </ChartSeries>
            }
        </ChartSeriesCollection>
    </SfChart>
  ```

**Step 2**:

To add the new series to the chart dynamically, follow the below code.

 ```razor
    void ChartSeriesAdd()
    {
        SeriesCollection.Add(new SeriesData
        {
          XName = nameof(LineChartData.XValue),
          YName = nameof(LineChartData.YValue),
          Data = GetChartData()
        });
    }
 ```

**Step 3**:

To remove a series from the chart dynamically, follow the below code.

 ```razor
    void ChartSeriesRemove()
    {
      SeriesCollection.Remove(SeriesCollection[SeriesCollection.Count - 1]);
    }
 ```

{% aspTab template="chart/how-to/add-remove", sourceFiles="add-remove.razor" %}

{% endaspTab %}

> Note: You can refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations. You can also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to knows various chart types and how to represent time-dependent data, showing trends in data at equal intervals.