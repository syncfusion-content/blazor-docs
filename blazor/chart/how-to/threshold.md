---
layout: post
title: Threshold in Chart in Blazor Charts Component | Syncfusion
description: Checkout and learn here all about Threshold in Chart in Syncfusion Blazor Charts component and more.
platform: Blazor
control: Chart
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Threshold in Chart in Blazor Charts Component

The threshold level can be indicated in the chart using the [ChartStripline](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStripline.html). Follow the steps below to add a threshold to the chart.

**Step 1:**

Render a chart with the required series using [ChartSeriesCollection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesCollection.html).

```cshtml
<SfChart Title="Weather condition JPN vs DEU">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReports" XName="X" YName="Y" Type="ChartSeriesType.Column" />
    </ChartSeriesCollection>
</SfChart>
```

**Step 2:**

Since this threshold must be added to the measure axis, the [ChartStripline](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStripline.html) setting will be set to [ChartPrimaryYAxis](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartPrimaryYAxis.html#properties).
Using the [ChartStriplines](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStriplines.html) collection property of the axis, multiple thresholds can be added to a chart.

```cshtml
...
<ChartPrimaryYAxis>
    <ChartStriplines>
        <ChartStripline Start="30" Size="1" ></ChartStripline>
    </ChartStriplines>
</ChartPrimaryYAxis>
... 
```

**Step 3:**

To represent the severity of the threshold, a color can be set to the stripline using the [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonStripLines.html#Syncfusion_Blazor_Charts_ChartCommonStripLines_Color) property of the [ChartStripline](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStripline.html). 

```cshtml
...
<ChartPrimaryYAxis>
    <ChartStriplines>
        <ChartStripline Start="30" Size="1" Color="red" ></ChartStripline>
    </ChartStriplines>
</ChartPrimaryYAxis>
... 
```

**Step 4:**

The stripline's order, which determines whether it is rendered behind or above the series elements, can be customized by [ZIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonStripLines.html#Syncfusion_Blazor_Charts_ChartCommonStripLines_ZIndex) property of the [ChartStripline](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStripline.html). 

```cshtml
...
<ChartPrimaryYAxis>
    <ChartStriplines>
        <ChartStripline Start="30" Size="1" Color="red" ZIndex="ZIndex.Over"></ChartStripline>
    </ChartStriplines>
</ChartPrimaryYAxis>
... 
```

The complete code snippet for the preceding steps is available below.

```cshtml
@using Syncfusion.Blazor.Charts

<SfChart Title="Weather condition JPN vs DEU">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
    <ChartPrimaryYAxis>
        <ChartStriplines>
            <ChartStripline Start="30" Size="1" ZIndex="ZIndex.Over" Color="red"></ChartStripline>
        </ChartStriplines>
    </ChartPrimaryYAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReports" XName="X" YName="Y" Type="ChartSeriesType.Column" />
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
         new ChartData{ X= "Jan", Y= 15 },
         new ChartData{ X= "Feb", Y= 20 },
         new ChartData{ X= "Mar", Y= 35 },
         new ChartData{ X= "Apr", Y= 40 },
         new ChartData{ X= "May", Y= 80 },
         new ChartData{ X= "Jun", Y= 70 },
         new ChartData{ X= "Jul", Y= 65 },
         new ChartData{ X= "Aug", Y= 55 },
         new ChartData{ X= "Sep", Y= 50 },
         new ChartData{ X= "Oct", Y= 30 },
         new ChartData{ X= "Nov", Y= 35 },
         new ChartData{ X= "Dec", Y= 35 }
    };
}
```

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.
