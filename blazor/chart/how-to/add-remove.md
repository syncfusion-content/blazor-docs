---
layout: post
title: Add or Remove Series in Blazor Charts Component | Syncfusion
description: Learn to dynamically add or remove series in Syncfusion Blazor Charts component to update visualizations based on user input.
platform: Blazor
control: Chart
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Add or Remove Series in Blazor Charts Component

Syncfusion Blazor Charts allow dynamic addition and removal of chart series using the [ChartSeriesCollection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesCollection.html). Follow these steps to update chart series at runtime:

## Step 1: Render Series Dynamically

Render chart series by iterating over a collection mapped to the [ChartSeriesCollection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesCollection.html).

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

## Step 2: Add and Remove Controls

Create buttons to trigger methods for adding or removing series from the chart.

```cshtml

<SfButton @onclick="AddChartSeries">Add Chart Series</SfButton>
<SfButton @onclick="RemoveChartSeries">Remove Chart Series</SfButton>

```

## Step 3: Add Series Method

Add a new series to the chart by appending data to the series collection.

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

## Step 4: Remove Series Method

Remove a series from the chart by deleting the last item in the series collection.

```c#

public void RemoveChartSeries()
{
    if (SeriesCollection.Count > 0)
    {
        SeriesCollection.Remove(SeriesCollection[SeriesCollection.Count - 1]);
    }
}

```

## Action

Click **Add Chart Series** to insert a new series, or **Remove Chart Series** to delete the last series from the chart. The complete code sample is shown below.

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

@code {
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

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.
