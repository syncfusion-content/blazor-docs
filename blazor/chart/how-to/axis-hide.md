---
layout: post
title: Hiding Axis in Blazor Charts Component | Syncfusion
description: Checkout and learn here all about Hiding Axis in Syncfusion Blazor Charts component and much more details.
platform: Blazor
control: Chart
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Hiding Axis in Blazor Charts Component

The axis associated with the series can be hidden by toggling the legend item of the relevant series. Follow the steps below to hide the measure axis associated with the series.

**Step 1:**

Render a chart with three series and three axis using [ChartSeriesCollection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesCollection.html) and [ChartAxes](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxes.html) properties of the chart. Map each series to a measure axis using [YAxisName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_YAxisName) property of the [ChartSeries](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html).

```cshtml
<SfChart>
    <ChartAxes>
        <ChartAxis Name="yAxis1" />
        <ChartAxis OpposedPosition="true" Name="yAxis2" />
        <ChartAxis OpposedPosition="true" Name="yAxis3" />
    </ChartAxes>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@DataPoints" XName="XValue" YName="YValue1" Name="England" YAxisName="yAxis1" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@DataPoints" XName="XValue" YName="YValue2" Name="US" Fill="green" YAxisName="yAxis2" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@DataPoints" XName="XValue" YName="YValue3" Name="West Indies" Fill="#b22222" YAxisName="yAxis3" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
    
</SfChart>
```

**Step 2:**

In the [ChartLegendSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartLegendSettings.html), configure the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartLegendSettings.html#Syncfusion_Blazor_Charts_ChartLegendSettings_Visible) property to display the legend and the [ToggleVisibility](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartLegendSettings.html#Syncfusion_Blazor_Charts_ChartLegendSettings_ToggleVisibility) property to enable legend item toggling to control the visibility of the associated series.

```cshtml
<SfChart>
    ...
    <ChartLegendSettings Visible="true" ToggleVisibility="true" />
    ...
</SfChart>
```

**Action:**

By clicking the legend items, one can now toggle the visibility of the associated series. Once the series has been removed, the associated axis will be removed from the chart. If the legend item is toggled again to show the series, the associated axis with the series will be added to the chart. The complete code snippet for the preceding steps is available below.

```cshtml
@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartAxes>
        <ChartAxis Name="yAxis1" />
        <ChartAxis OpposedPosition="true" Name="yAxis2" />
        <ChartAxis OpposedPosition="true" Name="yAxis3" />
    </ChartAxes>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@DataPoints" XName="XValue" YName="YValue1" Name="England" YAxisName="yAxis1" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@DataPoints" XName="XValue" YName="YValue2" Name="US" Fill="green" YAxisName="yAxis2" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@DataPoints" XName="XValue" YName="YValue3" Name="West Indies" Fill="#b22222" YAxisName="yAxis3" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
    <ChartLegendSettings Visible="true" ToggleVisibility="true" />
</SfChart>


@code{

    public List<ChartData> DataPoints = new List<ChartData>
    {
        new ChartData { XValue = 16, YValue1 = 2, YValue2 = 12, YValue3 = 7 },
        new ChartData { XValue = 17, YValue1 = 14, YValue2 = 10, YValue3 = 7 },
        new ChartData { XValue = 18, YValue1 = 7, YValue2 = 17, YValue3 = 11 },
        new ChartData { XValue = 19, YValue1 = 7, YValue2 = 20, YValue3 = 8 },
        new ChartData { XValue = 20, YValue1 = 10, YValue2 = 16, YValue3 = 24 },
    };

    public class ChartData
    {
        public double XValue { get; set; }
        public double YValue1 { get; set; }
        public double YValue2 { get; set; }
        public double YValue3 { get; set; }
    }

}
```

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.
