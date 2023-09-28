---
layout: post
title: Histogram in Blazor Charts Component | Syncfusion
description: Checkout and learn here all about the Histogram Chart in Syncfusion Blazor Charts component and more.
platform: Blazor
control: Chart
documentation: ug
---

# Histogram in Blazor Charts Component

## Histogram

[Histogram Chart](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/histogram-chart) can provide a visual display of large amounts of data that are difficult to understand in a tabular or spreadsheet form and it can be rendered by specifying the series [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Type) to [Histogram](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Histogram).

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

![Blazor Histogram Chart](../images/othertypes/blazor-histogram-chart.png)

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See also

* [Data Label](../data-labels)
* [Tooltip](../tool-tip)
