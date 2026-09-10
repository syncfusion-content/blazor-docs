---
layout: post
title: How to Update Live Data in Blazor Charts | Syncfusion®
description: Learn how to update a Blazor Chart with live data using Syncfusion. Use a timer to refresh the DataSource and re-render the chart at intervals.
platform: Blazor
control: Charts
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# How to Update Live Data in Blazor Charts

A Blazor Chart can be updated with real-time data by using a `System.Timers.Timer` to periodically update the data source and refresh the chart. Follow the steps below to display live data updates in a Blazor Server or Blazor WebAssembly application using Syncfusion® Blazor Charts v20.x or later.
 
Live updates are achieved by modifying the data in an `ObservableCollection` that is bound to the chart. Since `ObservableCollection` notifies the UI when items are added, removed, or updated, the chart automatically reflects those changes when updates are performed on the renderer's dispatch context.

**Step 1: Render the chart**

Start by rendering the chart with the required series using [ChartSeriesCollection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesCollection.html). The X axis uses `ValueType.DateTime` because the live samples will be timestamped in seconds.

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

**Step 2: Format the axis labels**

Labels of the axes can be customized with the [LabelFormat](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_LabelFormat) property of [ChartAxis](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html). Because the chart updates every second, the [LabelFormat](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_LabelFormat) is set to **mm:ss** on the [ChartPrimaryXAxis](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartPrimaryXAxis.html) so labels show minutes and seconds. The [ChartPrimaryYAxis](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartPrimaryYAxis.html) uses `{value}%` as shown below.

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

**Step 3: Update the chart on a timer**

Add a timer that updates the chart every 500 milliseconds. The `AddData` callback removes the oldest data point from the `ObservableCollection` and adds a new one. Because the chart is bound to an `ObservableCollection`, it is automatically notified when the data changes. The chart is then refreshed on the renderer's dispatch context by using `InvokeAsync`.

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

    // Start the live update timer.
    timer = new Timer(500);
    timer.Elapsed += OnTimerElapsed;
    timer.AutoReset = true;
    timer.Enabled = true;
}

private async void OnTimerElapsed(object source, ElapsedEventArgs e)
{
    if (liveChart == null)
    {
        return;
    }

    await InvokeAsync(() =>
    {
        dataLength++;
        DataPoints.RemoveAt(0);
        DataPoints.Add(new ChartDataPoint
        {
            Time = DateTime.Now.AddSeconds(dataLength + 10),
            CPU_Usage = randomNum.Next(30, 80)
        });
    });
}

public void Dispose()
{
    if (timer != null)
    {
        timer.Elapsed -= OnTimerElapsed;
        timer.Dispose();
        timer = null;
    }
}
```

The complete code snippet for the preceding steps is available below.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Charts
@using System.Collections.ObjectModel
@using System.Timers

<div class="control-section" align="center">
    <SfChart @ref="liveChart" Title="CPU Usage" Width="100%">
        <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime" LabelFormat="mm:ss" Title="Time (mm:ss)">
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

@implements IDisposable
@code {

    private Timer timer;
    private SfChart liveChart;
    private double dataLength = 100;
    private readonly Random randomNum = new Random();
    public ObservableCollection<ChartDataPoint> DataPoints = new ObservableCollection<ChartDataPoint>();

    protected override void OnInitialized()
    {
        // Provide the chart with initial data during page load.
        for (int i = 0; i < dataLength; i++)
            DataPoints.Add(new ChartDataPoint
            {
                Time = DateTime.Now.AddSeconds(i + 10),
                CPU_Usage = randomNum.Next(30, 80)
            });

        // Start the live update timer.
        timer = new Timer(500);
        timer.Elapsed += OnTimerElapsed;
        timer.AutoReset = true;
        timer.Enabled = true;
    }

    private async void OnTimerElapsed(object source, ElapsedEventArgs e)
    {
        if (liveChart == null)
            return;

        await InvokeAsync(() =>
        {
            dataLength++;
            DataPoints.RemoveAt(0);
            DataPoints.Add(new ChartDataPoint
            {
                Time = DateTime.Now.AddSeconds(dataLength + 10),
                CPU_Usage = randomNum.Next(30, 80)
            });
        });
    }

    public void Dispose()
    {
        if (timer != null)
        {
            timer.Elapsed -= OnTimerElapsed;
            timer.Dispose();
            timer = null;
        }
    }

    public class ChartDataPoint
    {
        public DateTime Time { get; set; }
        public double CPU_Usage { get; set; }
    }
}
```

N> Refer to the [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore the [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=fluent2) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.
