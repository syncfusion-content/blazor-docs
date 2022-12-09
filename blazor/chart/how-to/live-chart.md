---
layout: post
title: Live Chart in Blazor Charts Component | Syncfusion
description: Checkout and learn here all about Live Chart in Syncfusion Blazor Charts component and much more details.
platform: Blazor
control: Chart
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Live Chart in Blazor Charts Component

Live update in a chart can be achieved using the timer to update the datasource with real-time data and refresh the chart. Follow the steps below to update a chart with real-time data.

**Step 1:**

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

**Step 2:**

Labels of the axes can be formatted based on our need using the [LabelFormat](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonAxis.html#Syncfusion_Blazor_Charts_ChartCommonAxis_Format) property of the [ChartAxis](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html). Since the chart will be updated in seconds, the [LabelFormat](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonAxis.html#Syncfusion_Blazor_Charts_ChartCommonAxis_Format) has been set as **mm:ss** for the [ChartPrimaryXAxis](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartPrimaryXAxis.html) to display minutes and second in the axis labels. Similarly [ChartPrimaryYAxis](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartPrimaryYAxis.html) labels can also be formatted as shown below using its [LabelFormat](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonAxis.html#Syncfusion_Blazor_Charts_ChartCommonAxis_Format) property.

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

**Step 3:**

Add a timer to automatically update the chart every 500 milliseconds by calling the **AddData** function, which removes the first data from the data points collection, which is of the `ObservableCollection` type, and adds a new data to it. Since this `ObservableCollection` type is used as the data source, it is triggered whenever there is a data update within it.

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

The complete code snippet for the preceding steps is available below.

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

@code{

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
