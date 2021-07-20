---
layout: post
title: How to Lazy Loading in Blazor Chart Component | Syncfusion
description: Checkout and learn about Lazy Loading in Blazor Chart component of Syncfusion, and more details.
platform: Blazor
control: Chart
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Lazy loading

Lazy loading allows you to load data for chart on demand. Chart will fire the [`OnScrollChanged`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnScrollChanged) event, in that we can get the minimum and maximum range of the axis, based on this, we can upload the data to chart.

```
   <ChartEvents OnScrollChanged="@ScrollChange"></ChartEvents>

  void ScrollChange(ScrollEventArgs e)
    {
        this.dataSource = GetRangeData(Convert.ToInt32(e.CurrentRange.Minimum), Convert.ToInt32(e.CurrentRange.Maximum));
        this.StateHasChanged();
    }

```

```csharp

@using Syncfusion.Blazor.Charts
@using System.Collections.ObjectModel

@if (dataSource != null)
{
    <SfChart Title="Lazy Loading Chart" @ref="chartObj">
        <ChartEvents OnScrollChanged="@ScrollChange"></ChartEvents>
        <ChartPrimaryXAxis>
            <ChartAxisScrollbarSettings Enable="true" PointsLength="1000"></ChartAxisScrollbarSettings>
        </ChartPrimaryXAxis>
        <ChartSeriesCollection>
            <ChartSeries DataSource="@dataSource" Fill="@color" XName="x" YName="y" Type="ChartSeriesType.Line">
            </ChartSeries>
        </ChartSeriesCollection>
    </SfChart>
}
else
{
    <p>Chart Loading</p>
}

@code {

    public SfChart chartObj;
    int count = 1;
    public string color = "blue";
    Random random = new Random();
    ObservableCollection<ColumnChartData> dataSource;
    protected override void OnInitialized()
    {
        dataSource = this.GetData();
    }
    void ScrollChange(ScrollEventArgs e)
    {
        this.dataSource = GetRangeData(Convert.ToInt32(e.CurrentRange.Minimum), Convert.ToInt32(e.CurrentRange.Maximum));
    }
    ObservableCollection<ColumnChartData>
    GetRangeData(int min, int max)
    {
        ObservableCollection<ColumnChartData> data = new ObservableCollection<ColumnChartData>();
        for (; min <= max; min++)
        {
            data.Add(new ColumnChartData { x = min, y = random.Next(10, 100) });
        }
        return data;
    }
    public class ColumnChartData
    {
        public double x { get; set; }
        public double y { get; set; }
    }
    ObservableCollection<ColumnChartData> GetData()
    {
        ObservableCollection<ColumnChartData> data = new ObservableCollection<ColumnChartData>();
        for (; count <= 100; count++)
        {
            data.Add(new ColumnChartData { x = count++, y = random.Next(10, 100) });
        }
        return data;
    }
}


```

> Note: You can refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations. You can also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to knows various chart types and how to represent time-dependent data, showing trends in data at equal intervals.