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

```
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

 ```
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

 ```
    void ChartSeriesRemove()
    {
      SeriesCollection.Remove(SeriesCollection[SeriesCollection.Count - 1]);
    }
 ```

```csharp

@using Syncfusion.Blazor.Charts
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="ChartSeriesAdd">Add Chart Series</SfButton>
<SfButton @onclick="ChartSeriesRemove">Remove Chart Series</SfButton>

<div class="container">
    <SfChart>
        <ChartSeriesCollection>
            @foreach (SeriesData series in SeriesCollection)
            {
                <ChartSeries XName=@series.XName YName=@series.YName DataSource=@series.Data>
                </ChartSeries>
            }
        </ChartSeriesCollection>
    </SfChart>
</div>

@code{

    public class SeriesData
    {
        public string XName { get; set; }
        public string YName { get; set; }
        public List<LineChartData> Data { get; set; }
    }

    public class LineChartData
    {
        public double XValue { get; set; }
        public double YValue { get; set; }
    }

    List<SeriesData> SeriesCollection;
    SfChart ChartInstance;
    public Random random = new Random();
    List<LineChartData> DataChart;
    int count = 20;
    int index = 1;
    double value = 0;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        SeriesCollection = new List<SeriesData>()
        {
          new SeriesData {
                XName=nameof(LineChartData.XValue),
                YName=nameof(LineChartData.YValue),
                Data=GetChartData()
            }
        };
    }

    // here we have added the chart series by adding series data to the SeriesCollection list.
    void ChartSeriesAdd()
    {
        SeriesCollection.Add(new SeriesData
        {
            XName = nameof(LineChartData.XValue),
            YName = nameof(LineChartData.YValue),
            Data = GetChartData()
        });
    }

    // here we have removed the chart series by removing the series data in the SeriesCollection list.
    void ChartSeriesRemove()
    {
        if(SeriesCollection.Count > 0)
        SeriesCollection.Remove(SeriesCollection[SeriesCollection.Count - 1]);
    }

    List<LineChartData> GetChartData()
    {
        List<LineChartData> data = new List<LineChartData>();
        for (int i = 0; i < count; i++)
        {
            if (i % 3 == 0)
            {
                this.value = this.value - (random.Next(0, 100) / 3) * 4;
            }
            else if (i % 2 == 0)
            {
                this.value = this.value + (random.Next(0, 100) / 3) * 4;
            }
            data.Add(new LineChartData() { XValue = i, YValue = this.value });
        }
        return data;
    }

}

```

> Note: You can refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations. You can also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to knows various chart types and how to represent time-dependent data, showing trends in data at equal intervals.