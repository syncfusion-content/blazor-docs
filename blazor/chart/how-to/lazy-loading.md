---
layout: post
title: Lazy Loading in Blazor Charts Component | Syncfusion
description: Check out and learn here all about Lazy Loading in Syncfusion Blazor Charts component and much more.
platform: Blazor
control: Chart
documentation: ug
---

# Lazy Loading in Blazor Charts Component

Lazy loading enables charts to load data on demand, improving performance and responsiveness. The [OnScrollChanged](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnScrollChanged) event is triggered by the chart, allowing retrieval of the minimum and maximum axis ranges to update the chart data accordingly.

```cshtml
<ChartEvents OnScrollChanged="@ScrollChange" />

private void ScrollChange(ScrollEventArgs e)
{
    this.dataSource = GetRangeData(Convert.ToInt32(e.CurrentRange.Minimum), Convert.ToInt32(e.CurrentRange.Maximum));
    this.StateHasChanged();
}

```

The following code demonstrates lazy loading in Blazor Charts.

```cshtml
@using Syncfusion.Blazor.Charts
@using System.Collections.ObjectModel

@if (dataSource != null)
{
    <SfChart Title="Lazy Loading Chart">
        <ChartEvents OnScrollChanged="@ScrollChange"></ChartEvents>
        <ChartPrimaryXAxis>
            <ChartAxisScrollbarSettings Enable="true" PointsLength="1000"></ChartAxisScrollbarSettings>
        </ChartPrimaryXAxis>
        <ChartSeriesCollection>
            <ChartSeries DataSource="@dataSource" Fill="blue" XName="x" YName="y" Type="ChartSeriesType.Line">
            </ChartSeries>
        </ChartSeriesCollection>
    </SfChart>
}
else
{
    <p>Chart Loading</p>
}

@code {
    int count = 1;
    Random random = new Random();
    public ObservableCollection < ColumnChartData > dataSource;

    protected override void OnInitialized() {
        dataSource = this.GetData();
    }

    public void ScrollChange(ScrollEventArgs e) {
        this.dataSource = GetRangeData(Convert.ToInt32(e.CurrentRange.Minimum), Convert.ToInt32(e.CurrentRange.Maximum));
        this.StateHasChanged();
    }

    public ObservableCollection < ColumnChartData > GetRangeData(int min, int max) {
        ObservableCollection < ColumnChartData > data = new ObservableCollection < ColumnChartData > ();
        for (; min <= max; min++) {
            data.Add(new ColumnChartData {
                x = min, y = random.Next(10, 100)
            });
        }
        return data;
    }

    public ObservableCollection < ColumnChartData > GetData() {
        ObservableCollection < ColumnChartData > data = new ObservableCollection < ColumnChartData > ();
        for (; count <= 100; count++) {
            data.Add(new ColumnChartData {
                x = count, y = random.Next(10, 100)
            });
        }
        return data;
    }

    public class ColumnChartData {
        public double x {
            get;
            set;
        }
        public double y {
            get;
            set;
        }
    }
}

```

![LazyLoad Line](../images/lazyload-line.png)

### Line

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjVpZhLxzguqSeHM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![LazyLoad Column](../images/lazyload-column.png)

### Column

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZrTXBLdpqQSSsSy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.
