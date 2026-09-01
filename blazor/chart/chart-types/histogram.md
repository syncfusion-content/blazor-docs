---
layout: post
title: Blazor Histogram Chart Examples and Documentation | Syncfusion®
description: Learn how to render Blazor Histogram Charts using Syncfusion. Display large data distributions visually with bin-based frequency aggregation.
platform: Blazor
control: Charts
documentation: ug
---

# Histogram Chart in Blazor

## Histogram

The [Histogram Chart](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/histogram-chart) displays the distribution of large datasets by grouping values into bins and plotting the frequency of each bin. This makes it easier to analyze data that may be difficult to interpret in a tabular or spreadsheet format. To render a histogram series, set the series [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Type) to [Histogram](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Histogram).

N> **Troubleshooting:** If the chart is empty, verify that the data source is bound to a numeric `YName` field and that the X-axis `Minimum`/`Maximum` covers the data range. Each data value must be non-null and not `double.NaN`.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Score of Final Examination">
    <ChartArea><ChartAreaBorder Width="0"></ChartAreaBorder></ChartArea>

    <ChartPrimaryXAxis Minimum="0" Maximum="100">
        <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
    </ChartPrimaryXAxis>

    <ChartPrimaryYAxis Minimum="0" Maximum="6" Interval="2" Title="Number of Students">
        <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
    </ChartPrimaryYAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@ExamScores" YName="Y" Type="ChartSeriesType.Histogram" BinInterval="20" ShowNormalDistribution="true" ColumnWidth="0.99">
            <ChartMarker Visible="true" Height="10" Width="10">
                <ChartDataLabel Visible="true" Position="Syncfusion.Blazor.Charts.LabelPosition.Top">
                    <ChartDataLabelFont Color="#ffffff" FontWeight="600"></ChartDataLabelFont>
                </ChartDataLabel>
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>

    <ChartTooltipSettings Enable="true"></ChartTooltipSettings>
</SfChart>

@code{

    public class Data
    {
        public double Y { get; set;}
    }

    public List<Data> ExamScores = new List<Data>
	{
       new Data { Y=5.250},
       new Data { Y=7.750},
       new Data { Y=8.275},
       new Data { Y=9.750},
       new Data { Y=36.250},
       new Data { Y=46.250},
       new Data { Y=56.250},
       new Data { Y=66.500},
       new Data { Y=76.625},
       new Data { Y=80.000},
       new Data { Y=97.750}
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/VDBdDdseJCEZMSUR?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Histogram Chart](../images/othertypes/blazor-histogram-chart.webp)" %}

## Events

### Series render

The [`OnSeriesRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnSeriesRender) event allows you to customize series properties, such as [Data](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Data), [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Fill), and [Series](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Series), before they are rendered on the chart.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Score of Final Examination">
    <ChartEvents OnSeriesRender="SeriesRender"></ChartEvents>

    <ChartArea><ChartAreaBorder Width="0"></ChartAreaBorder></ChartArea>

    <ChartPrimaryXAxis Minimum="0" Maximum="100">
        <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
    </ChartPrimaryXAxis>

    <ChartPrimaryYAxis Minimum="0" Maximum="6" Interval="2" Title="Number of Students">
        <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
    </ChartPrimaryYAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@ExamScores" YName="Y" Type=" Syncfusion.Blazor.Charts.ChartSeriesType.Histogram" BinInterval="20" ShowNormalDistribution="true" ColumnWidth="0.99">
            <ChartMarker Visible="true" Height="10" Width="10">
                <ChartDataLabel Visible="true" Position="Syncfusion.Blazor.Charts.LabelPosition.Top">
                    <ChartDataLabelFont Color="#ffffff" FontWeight="600"></ChartDataLabelFont>
                </ChartDataLabel>
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>

    <ChartTooltipSettings Enable="true"></ChartTooltipSettings>
</SfChart>

@code {

    public class Data
    {
        public double Y { get; set; }
    }

    public void SeriesRender(SeriesRenderEventArgs args)
    {
        args.Fill = "#FF4081";
    }

    public List<Data> ExamScores = new List<Data>
    {
       new Data { Y=5.250},
       new Data { Y=7.750},
       new Data { Y=8.275},
       new Data { Y=9.750},
       new Data { Y=36.250},
       new Data { Y=46.250},
       new Data { Y=56.250},
       new Data { Y=66.500},
       new Data { Y=76.625},
       new Data { Y=80.000},
       new Data { Y=97.750}
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BjBnXxWSTsYhgybd?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

### Point render

The [`OnPointRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnPointRender) event allows you to customize each data point before it is rendered on the chart.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Score of Final Examination">
    <ChartEvents OnPointRender="PointRender"></ChartEvents>

    <ChartArea><ChartAreaBorder Width="0"></ChartAreaBorder></ChartArea>

    <ChartPrimaryXAxis Minimum="0" Maximum="100">
        <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
    </ChartPrimaryXAxis>

    <ChartPrimaryYAxis Minimum="0" Maximum="6" Interval="2" Title="Number of Students">
        <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
    </ChartPrimaryYAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@ExamScores" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Histogram" BinInterval="20" ShowNormalDistribution="true" ColumnWidth="0.99">
            <ChartMarker Visible="true" Height="10" Width="10">
                <ChartDataLabel Visible="true" Position="Syncfusion.Blazor.Charts.LabelPosition.Top">
                    <ChartDataLabelFont Color="#ffffff" FontWeight="600"></ChartDataLabelFont>
                </ChartDataLabel>
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>

    <ChartTooltipSettings Enable="true"></ChartTooltipSettings>
</SfChart>

@code {

    public class Data
    {
        public double Y { get; set; }
    }

    public void PointRender(PointRenderEventArgs args)
    {
        args.Fill = System.Convert.ToDouble(args.Point.Y) == 2 ? "#E91E63" : "#3F51B5";
    }

    public List<Data> ExamScores = new List<Data>
    {
       new Data { Y=5.250},
       new Data { Y=7.750},
       new Data { Y=8.275},
       new Data { Y=9.750},
       new Data { Y=36.250},
       new Data { Y=46.250},
       new Data { Y=56.250},
       new Data { Y=66.500},
       new Data { Y=76.625},
       new Data { Y=80.000},
       new Data { Y=97.750}
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDVdZHiozMuzKIBX?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Series customization

The following properties control how the histogram aggregates values into bins and renders them:

* [BinInterval](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_BinInterval) - Sets the width of each bin along the X-axis. The default is `0`, which lets the chart choose an interval automatically.
* [ShowNormalDistribution](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_ShowNormalDistribution) - When `true`, overlays a normal distribution curve on the histogram. The default is `false`.
* [ColumnWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_ColumnWidth) - Sets the relative width of each column, from `0` to `1`. The default is `0.99` to remove the visual gap between bins.

N> Refer to the [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and explore the [Blazor Histogram Chart Example](https://blazor.syncfusion.com/demos/chart/histogram?theme=fluent2) to learn how the histogram aggregates values into bins.

## See also

* [Box and whisker](./box-whisker)
* [Scatter](./scatter)
* [Data Label](../data-labels)
* [Tooltip](../tool-tip)
* [Data Marker](../data-markers)
* [Legend](../legend)
