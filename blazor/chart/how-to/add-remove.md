---
layout: post
title: How to Add or Remove Series in Blazor Charts | Syncfusion®
description: Learn how to add or remove chart series dynamically in Blazor Charts using Syncfusion. Modify ChartSeriesCollection at runtime with simple code changes.
platform: Blazor
control: Charts
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# How to Add or Remove Series in Blazor Charts

The chart series can be dynamically added to or removed from a chart by updating the [`ChartSeriesCollection`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesCollection.html) Follow the steps below to add or remove a series at runtime.

**Step 1:**

Render a series by iterating your data and adding it to the [`ChartSeriesCollection`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesCollection.html) of the chart.

```cshtml
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

**Step 2:**

Create two buttons that call the `AddChartSeries` and `RemoveChartSeries` methods to add and remove a series from the chart.

```cshtml
<SfButton @onclick="AddChartSeries">Add Chart Series</SfButton>
<SfButton @onclick="RemoveChartSeries">Remove Chart Series</SfButton>
```

**Step 3:**

Inside `AddChartSeries`, append a new entry to the `SeriesCollection` list. The [`ChartSeriesCollection`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesCollection.html) re-renders automatically when the list notifies it of a change.

```c#
public void AddChartSeries()
{
    SeriesCollection.Add(new SeriesData
    {
        XName = nameof(LineChartData.XValue),
        YName = nameof(LineChartData.YValue),
        Data = GetChartData()
    });
}
```

**Step 4:**

To remove a series from the chart dynamically, use the code below in the **RemoveChartSeries** method. This code removes a series data from the series list named **SeriesCollection** mapped to the [ChartSeriesCollection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesCollection.html).

```c#
public void RemoveChartSeries()
{
    if (SeriesCollection.Count > 0)
    {
        SeriesCollection.Remove(SeriesCollection[SeriesCollection.Count - 1]);
    }
}
```

**Action:**

Clicking **Add Chart Series** appends a new series to the chart. Clicking **Remove Chart Series** removes the last series from the chart. The complete code snippet for the preceding steps is below.

```cshtml

@using Syncfusion.Blazor.Charts
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="AddChartSeries">Add Chart Series</SfButton>
<SfButton @onclick="RemoveChartSeries">Remove Chart Series</SfButton>

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

    List<SeriesData> SeriesCollection;

    // Here, the chart series has been added by adding series data to the "SeriesCollection" list.
    public void AddChartSeries()
    {
        SeriesCollection.Add(new SeriesData
        {
            XName = nameof(LineChartData.XValue),
            YName = nameof(LineChartData.YValue),
            Data = GetChartData()
        });
    }

    // Here, the chart series has been removed by removing the series data in the "SeriesCollection" list.
    public void RemoveChartSeries()
    {
        if (SeriesCollection.Count > 0)
        {
            SeriesCollection.Remove(SeriesCollection[SeriesCollection.Count - 1]);
        }
    }

    protected override void OnInitialized()
    {
        base.OnInitialized();
        SeriesCollection = new List<SeriesData>() {
            new SeriesData {
                XName = nameof(LineChartData.XValue),
                    YName = nameof(LineChartData.YValue),
                    Data = GetChartData()
            }
        };
    }

    private List<LineChartData> GetChartData()
    {
        int count = 20;
        double value = 0;
        List<LineChartData> data = new List<LineChartData>();
        Random random = new Random();
        for (int i = 0; i < count; i++)
        {
            if (i % 3 == 0)
            {
                value = value - (random.Next(0, 100) / 3) * 4;
            }
            else if (i % 2 == 0)
            {
                value = value + (random.Next(0, 100) / 3) * 4;
            }
            data.Add(new LineChartData()
            {
                XValue = i,
                YValue = value
            });
        }
        return data;
    }

    public class SeriesData
    {
        public string XName
        {
            get;
            set;
        }
        public string YName
        {
            get;
            set;
        }
        public List<LineChartData> Data
        {
            get;
            set;
        }
    }

    public class LineChartData
    {
        public double XValue
        {
            get;
            set;
        }
        public double YValue
        {
            get;
            set;
        }
    }

}
```

N> Refer to the [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations, and explore the [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=fluent2) to learn about various chart types and how to represent time-dependent data showing trends at equal intervals.

## See also

* [Binding data with series](../working-with-data)
* [Chart series](../chart-series)
* [Data labels](../data-labels)
* [Tooltip](../tool-tip)
* [Events](../events)
