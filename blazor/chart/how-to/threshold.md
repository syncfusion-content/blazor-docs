---
layout: post
title: How to Threshold in Blazor Chart Component | Syncfusion
description: Checkout and learn about Threshold in Blazor Chart component of Syncfusion, and more details.
platform: Blazor
control: Chart
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Mark a threshold in chart

You can mark a threshold in chart by using the [`ChartStripline`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisModel.html#Syncfusion_Blazor_Charts_AxisModel_StripLines).

To mark a threshold in chart, follow the given steps:

**Step 1**:

By using the [`Start`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonStripLines.html#Syncfusion_Blazor_Charts_ChartCommonStripLines_Start) and [`End`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonStripLines.html#Syncfusion_Blazor_Charts_ChartCommonStripLines_End) properties of [`ChartStripline`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisModel.html#Syncfusion_Blazor_Charts_AxisModel_StripLines) in vertical axis, you can mark the threshold
for y values of the data.

```razor
 <ChartPrimaryYAxis>
        <ChartStripLines>
            <ChartStripline Start="30" End="30.1" Color="red"></ChartStripline>
        </ChartStripLines>
  </ChartPrimaryYAxis>

  ```

```csharp

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartPrimaryYAxis>
        <ChartStriplines>
            <ChartStripline Start="30" End="30.1" Color="red"></ChartStripline>
        </ChartStriplines>
    </ChartPrimaryYAxis>

    <ChartSeriesCollection>
        <ChartSeries Type="ChartSeriesType.Line" DataSource="@WeatherReports" XName="X" YName="Y">
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> WeatherReports = new List<ChartData>
{
    new ChartData { X = "Sun", Y = 28 },
    new ChartData { X = "Mon", Y = 27 },
    new ChartData { X = "Tue", Y = 33 },
    new ChartData { X = "Wed", Y = 36 },
    new ChartData { X = "Thu", Y = 28 },
    new ChartData { X = "Fri", Y = 30 },
    new ChartData { X = "Sat", Y = 31 }
    };
}



```

> Note: You can refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations. You can also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to knows various chart types and how to represent time-dependent data, showing trends in data at equal intervals.