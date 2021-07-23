---
layout: post
title: How to Live Chart in Blazor Chart Component | Syncfusion
description: Checkout and learn about Live Chart in Blazor Chart component of Syncfusion, and more details.
platform: Blazor
control: Chart
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Live Data Update

You can update a chart with live data by using the Timer.

To update live data in a chart, follow the given steps:

**Step 1**:

 Render the series using Collection.

```
    <SfChart @ref="liveChart" Title="CPU Usage">
        <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime">
        </ChartPrimaryXAxis>

        <ChartSeriesCollection>
            <ChartSeries Type="ChartSeriesType.Line"  DataSource="@DataPoints"
                         XName="@nameof(ChartDataPoint.Time)" YName="@nameof(ChartDataPoint.CPU_Usage)">
            </ChartSeries>
        </ChartSeriesCollection>
    </SfChart>
  ```

**Step 2**:

Update the data to series at a specified interval using timer.

 ```
    protected override void OnInitialized()
    {
        // Starting live update in the chart.
        timer = new Timer(500);
        timer.Elapsed += AddData;
        timer.AutoReset = true;
        timer.Enabled = true;
    }
    private void AddData(Object source, ElapsedEventArgs e)
    {
        dataLength++;
        DataPoints.RemoveAt(0);
        DataPoints.Add(new ChartDataPoint
        {
            Time = DateTime.Now.AddSeconds(dataLength + 10),
            CPU_Usage = randomNum.Next(30, 80)
        });

    }
 ```

```csharp

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Charts
@using System.Collections.ObjectModel
@using System.Timers

<div class="control-section" align="center">
    <SfChart @ref="liveChart" Title="CPU Usage">
        <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime" LabelFormat="mm:ss" Title="Time (s)">
          
        </ChartPrimaryXAxis>
        
        <ChartPrimaryYAxis Title="Usage" Minimum="0" Interval="20" Maximum="100" LabelFormat="{value}%">
            
        </ChartPrimaryYAxis>
        <ChartSeriesCollection>
            <ChartSeries Type="ChartSeriesType.Line" Width="2" DataSource="@DataPoints"
                         XName="@nameof(ChartDataPoint.Time)" YName="@nameof(ChartDataPoint.CPU_Usage)">
                <ChartSeriesAnimation Enable="false"></ChartSeriesAnimation>
            </ChartSeries>
        </ChartSeriesCollection>
    </SfChart>
</div>
@code{
    private static Timer timer;
    private SfChart liveChart;
    private double dataLength = 100;
    private Random randomNum = new Random();
    private Theme theme { get; set; }
    public ObservableCollection<ChartDataPoint> DataPoints;
    protected override void OnInitialized()
    {
        // Provide the chart with initial data during page load.
        DataPoints = new ObservableCollection<ChartDataPoint>();
        for (int i = 0; i < dataLength; i++)
            DataPoints.Add(new ChartDataPoint
            {
                Time = DateTime.Now.AddSeconds(i + 10),
                CPU_Usage = randomNum.Next(30, 80)
            });
        // Starting live update in the chart.
        timer = new Timer(500);
        timer.Elapsed += AddData;
        timer.AutoReset = true;
        timer.Enabled = true;
    }
    private void AddData(Object source, ElapsedEventArgs e)
    {
        dataLength++;
        DataPoints.RemoveAt(0);
        DataPoints.Add(new ChartDataPoint
        {
            Time = DateTime.Now.AddSeconds(dataLength + 10),
            CPU_Usage = randomNum.Next(30, 80)
        });

    }
    public class ChartDataPoint
    {
        public DateTime Time { get; set; }
        public double CPU_Usage { get; set; }
    }
}

```

> You can refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations. You can also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to knows various chart types and how to represent time-dependent data, showing trends in data at equal intervals.