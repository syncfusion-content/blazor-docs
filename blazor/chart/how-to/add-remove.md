---
layout: post
title: Add or Remove Series in Blazor Charts Component | Syncfusion
description: Checkout and learn here all about Add or Remove Series in Syncfusion Blazor Charts component and more.
platform: Blazor
control: Chart
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Add or Remove Series in Blazor Charts Component

The chart series can be dynamically added or removed by adding and removing a series to the  [ChartSeriesCollection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesCollection.html). Follow the steps below to dynamically add or remove a series.

**Step 1:**

Render a series using [ChartSeriesCollection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesCollection.html) class of the chart.

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

Create buttons to call add and remove methods, which will add and remove a series from the chart respectively.

```cshtml
<SfButton @onclick="AddChartSeries">Add Chart Series</SfButton>
<SfButton @onclick="RemoveChartSeries">Remove Chart Series</SfButton>
```

**Step 3:**

To add a new series to the chart dynamically, use the code below in the **AddChartSeries** method. This code adds a new series data to the series list named **SeriesCollection** mapped to the [ChartSeriesCollection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesCollection.html). 

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

By clicking the **Add Chart Series** button a new series will be added to the chart and similarly by clicking the **Remove Chart Series** button the last series in the chart series collection will be removed from the chart. The complete code snippet for the preceding steps is available below.

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

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.
