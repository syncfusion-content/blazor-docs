---
layout: post
title: How to Axis Hide in Blazor Chart Component | Syncfusion
description: Checkout and learn about Axis Hide in Blazor Chart component of Syncfusion, and more details.
platform: Blazor
control: Chart
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Hide axis line when clicking the legend

By using the [`OnLegendClick`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnLegendClick) event, you can hide the axis in the chart.

To hide the axis through legend click, follow the given steps:

**Step 1**:

Create a chart with multiple axes.

Using the series name in `OnLegendClick` event, you can hide the axis associated with the series.

```razor
<ChartEvents OnLegendClick="LegendClick"></ChartEvents>
 void LegendClick(LegendClickEventArgs args)
    {
        if (args.Series.Name == "England")
        {
            this.AxisVisible1 = this.SeriesVisible1 = !this.SeriesVisible1;
        }
        else if(args.Series.Name == "US")
        {
            this.AxisVisible2 = this.SeriesVisible2 = !this.SeriesVisible2;
        }
        else if(args.Series.Name == "West Indies")
        {
            this.AxisVisible3 = this.SeriesVisible3 = !this.SeriesVisible3;
        }
    }

  ```

```csharp

@using Syncfusion.Blazor.Charts

<SfChart @ref="ChartObj" ID="chart" Title="England vs West Indies">
    <ChartMargin Left="100" Right="100"></ChartMargin>
    <ChartTooltipSettings Enable="true" Format="${point.x}th Over : <b>${point.y} Runs</b>"></ChartTooltipSettings>
    <ChartEvents OnLegendClick="LegendClick"></ChartEvents>
    <ChartPrimaryYAxis Visible="AxisVisible1"></ChartPrimaryYAxis>
    <ChartAxes>
        <ChartAxis OpposedPosition="true" RowIndex="0" Name="yAxis" Visible="AxisVisible2">
            <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
        </ChartAxis>
        <ChartAxis OpposedPosition="true" RowIndex="0" Name="yAxis1" Visible="AxisVisible3">
            <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
        </ChartAxis>
    </ChartAxes>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@Data" XName="XValue" YName="YValue" Width="2" Name="England" Fill="#1e90ff" Type="ChartSeriesType.Column">
        </ChartSeries>

        <ChartSeries DataSource="@Data" XName="XValue" YName="YValue2" Width="2" Name="US" Fill="green" YAxisName="yAxis" Type="ChartSeriesType.Column">
        </ChartSeries>

        <ChartSeries DataSource="@Data" XName="XValue" YName="YValue3" Width="2" Name="West Indies" Fill="#b22222" YAxisName="yAxis1" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>


@code{
    SfChart ChartObj;
    private bool AxisVisible1 { get; set; } = true;
    private bool AxisVisible2 { get; set; } = true;
    private bool AxisVisible3 { get; set; } = true;
    private bool SeriesVisible1 { get; set; } = true;
    private bool SeriesVisible2 { get; set; } = true;
    private bool SeriesVisible3 { get; set; } = true;
    public class ChartData
    {
        public double XValue { get; set; }
        public double YValue { get; set; }
        public double YValue2 { get; set; }
        public double YValue3{ get; set; }
    }
    void LegendClick(LegendClickEventArgs args)
    {
        if (args.Series.Name == "England")
        {
            this.AxisVisible1 = this.SeriesVisible1 = !this.SeriesVisible1;
        }
        else if(args.Series.Name == "US")
        {
            this.AxisVisible2 = this.SeriesVisible2 = !this.SeriesVisible2;
        }
        else if(args.Series.Name == "West Indies")
        {
            this.AxisVisible3 = this.SeriesVisible3 = !this.SeriesVisible3;
        }
    }
   
    public List<ChartData> Data = new List<ChartData>
    {
            new ChartData { XValue = 16, YValue = 2, YValue2 = 12, YValue3 = 7 },
            new ChartData { XValue = 17, YValue = 14, YValue2 = 10, YValue3 = 7 },
            new ChartData { XValue = 18, YValue = 7, YValue2 = 17, YValue3 = 11 },
            new ChartData { XValue = 19, YValue = 7, YValue2 = 20, YValue3 = 8 },
            new ChartData { XValue = 20, YValue = 10, YValue2 = 16, YValue3 = 24 },
    };
}



```

> Note: You can refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations. You can also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to knows various chart types and how to represent time-dependent data, showing trends in data at equal intervals.