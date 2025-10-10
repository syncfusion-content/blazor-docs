---
layout: post
title: Live Chart in Blazor Charts Component | Syncfusion
description: Learn to implement live updating charts in Syncfusion Blazor Charts using real time data binding and refresh logic.
platform: Blazor
control: Chart
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Live Chart in Blazor Charts Component

Live updates in a chart can be achieved using a timer to refresh the data source with real-time values. Follow these steps to update a chart with live data.

## Step 1: Render the Chart Series

Render a chart with the required series using [ChartSeriesCollection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesCollection.html).

```cshtml

<SfChart @ref="liveChart" Title="CPU Usage" Width="100%" >
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime" Title="Time (s)">
        <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
    </ChartPrimaryXAxis>
    <ChartPrimaryYAxis Title="Usage" Minimum="0" Interval="20" Maximum="100" >
        <ChartAxisLineStyle Width="0" Color="transparent"></ChartAxisLineStyle>
    </ChartPrimaryYAxis>
    <ChartSeriesCollection>
        <ChartSeries Type="ChartSeriesType.Line" Width="2" DataSource="@DataPoints"
                        XName="Time" YName="CPU_Usage">
            <ChartSeriesAnimation Enable="false"></ChartSeriesAnimation>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

```

## Step 2: Format Axis Labels

Format axis labels using the [LabelFormat](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonAxis.html#Syncfusion_Blazor_Charts_ChartCommonAxis_Format) property. For real-time updates, set the X-axis format to **mm:ss** and the Y-axis format as needed.

```cshtml

<SfChart @ref="liveChart" Title="CPU Usage" Width="100%" >
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime" LabelFormat="mm:ss" Title="Time (s)">
        <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
    </ChartPrimaryXAxis>
    <ChartPrimaryYAxis Title="Usage" Minimum="0" Interval="20" Maximum="100" LabelFormat="{value}%">
        <ChartAxisLineStyle Width="0" Color="transparent"></ChartAxisLineStyle>
    </ChartPrimaryYAxis>
    <ChartSeriesCollection>
        <ChartSeries Type="ChartSeriesType.Line" Width="2" DataSource="@DataPoints"
                        XName="Time" YName="CPU_Usage">
            <ChartSeriesAnimation Enable="false"></ChartSeriesAnimation>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

```

## Step 3: Add a Timer for Live Updates

Use a timer to update the chart every 500 milliseconds by calling a function that removes the first data point and adds a new one to the collection. The `ObservableCollection` type triggers updates in the chart when its data changes.

```cshtml

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

```

The following code demonstrates how to implement a live updating chart in Blazor.

```cshtml

@using Syncfusion.Blazor.Charts
@using System.Collections.ObjectModel
@using System.Timers

<div class="control-section" align="center">
    <SfChart @ref="liveChart" Title="CPU Usage" Width="100%" >
        <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime" LabelFormat="mm:ss" Title="Time (s)">
            <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
        </ChartPrimaryXAxis>
        <ChartPrimaryYAxis Title="Usage" Minimum="0" Interval="20" Maximum="100" LabelFormat="{value}%">
            <ChartAxisLineStyle Width="0" Color="transparent"></ChartAxisLineStyle>
        </ChartPrimaryYAxis>
        <ChartSeriesCollection>
            <ChartSeries Type="ChartSeriesType.Line" Width="2" DataSource="@DataPoints"
                         XName="@nameof(ChartDataPoint.Time)" YName="@nameof(ChartDataPoint.CPU_Usage)">
                <ChartSeriesAnimation Enable="false"></ChartSeriesAnimation>
            </ChartSeries>
        </ChartSeriesCollection>
    </SfChart>
</div>

@code {
    private static Timer timer;
    private SfChart liveChart;
    private double dataLength = 100;
    private Random randomNum = new Random();
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
        if (liveChart == null)
            return;
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

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.
