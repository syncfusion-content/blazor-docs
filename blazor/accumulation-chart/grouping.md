---
layout: post
title: Grouping in Blazor Accumulation Chart Component | Syncfusion
description: Check out and learn how to group and visualize data points in Syncfusion Blazor Accumulation Chart component.
platform: Blazor
control: Accumulation Chart
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Grouping in Blazor Accumulation Chart Component

## Grouping

The [GroupTo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_GroupTo) property can be used to group points in the series. Points with a value less than `GroupTo` are grouped and displayed as a single point labeled **Others**. The property value can also be set as a percentage of the total data points value.

```cshtml

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Sales Analysis" EnableSmartLabels="true">
    <AccumulationChartLegendSettings Visible="false" />

    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@DataSource" XName="XValue" YName="YValue" Name="Sales" GroupTo="10">
            <AccumulationDataLabelSettings Visible="true" Name="Text" Position="AccumulationLabelPosition.Outside">
            </AccumulationDataLabelSettings>
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
</SfAccumulationChart>

@code {
    public class ChartData
    {
        public string XValue { get; set; }
        public double YValue { get; set; }
        public string Text { get; set; }
    }

    public List<ChartData> DataSource = new List<ChartData>
    {
       new ChartData { XValue = "Jan", YValue = 3, Text= "Jan: 3M" },
       new ChartData { XValue = "Feb", YValue = 3.5, Text= "Feb: 3.5M" },
       new ChartData { XValue = "Mar", YValue = 7, Text= "'Mar: 7M" },
       new ChartData { XValue = "Apr", YValue = 13.5, Text= "Apr: 13.5M" },
       new ChartData { XValue = "May", YValue = 19, Text= "May: 19M" },
       new ChartData { XValue = "Jun", YValue = 23.5, Text= "Jun: 23.5M" },
       new ChartData { XValue = "Jul", YValue = 26, Text= "Jul: 26M" },
       new ChartData { XValue = "Aug", YValue = 25, Text= "Aug: 25M" },
       new ChartData { XValue = "Sep", YValue = 21, Text= "Sep: 21M" },
       new ChartData { XValue = "Oct", YValue = 15, Text= "Oct: 15M" },
       new ChartData { XValue = "Nov", YValue = 9, Text= "Nov: 9M" },
       new ChartData { XValue = "Dec", YValue = 3.5, Text= "Dec: 3.5M" }
   };
}

```

![Grouping in Blazor Accumulation Chart](images/grouping/blazor-accumulation-chart-grouping.png)
{% previewsample "https://blazorplayground.syncfusion.com/embed/rNrqihiqTyhaAqqS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Pie Grouping

### Broken Slice

Grouped points appear as a single slice labeled **Others**, which explodes and breaks into separate slices when clicked.

```cshtml

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Sales Analysis" EnableSmartLabels="true">
    <AccumulationChartTooltipSettings Enable="true" />

    <AccumulationChartLegendSettings Visible="false" />

    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@DataSource" XName="XValue" YName="YValue" Explode="true" Radius="70%" GroupTo="15">
            <AccumulationDataLabelSettings Visible="true" Name="Text" Position="AccumulationLabelPosition.Outside">
                <AccumulationChartConnector Type="ConnectorType.Line" Length="5%"></AccumulationChartConnector>
                <AccumulationChartDataLabelFont Size="14px"></AccumulationChartDataLabelFont>
            </AccumulationDataLabelSettings>
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
</SfAccumulationChart>

@code {
    public class ChartData
    {
        public string XValue { get; set; }
        public double YValue { get; set; }
        public string Text { get; set; }
    }

    public List<ChartData> DataSource = new List<ChartData>
    {
       new ChartData { XValue = "Jan", YValue = 3, Text= "Jan: 3M" },
       new ChartData { XValue = "Feb", YValue = 3.5, Text= "Feb: 3.5M" },
       new ChartData { XValue = "Mar", YValue = 7, Text= "'Mar: 7M" },
       new ChartData { XValue = "Apr", YValue = 3.5, Text= "Apr: 13.5M" },
       new ChartData { XValue = "May", YValue = 19, Text= "May: 19M" },
       new ChartData { XValue = "Jun", YValue = 23.5, Text= "Jun: 23.5M" },
       new ChartData { XValue = "Jul", YValue = 26, Text= "Jul: 26M" },
       new ChartData { XValue = "Aug", YValue = 25, Text= "Aug: 25M" },
       new ChartData { XValue = "Sep", YValue = 21, Text= "Sep: 21M" },
       new ChartData { XValue = "Oct", YValue = 15, Text= "Oct: 15M" },
       new ChartData { XValue = "Nov", YValue = 9, Text= "Nov: 9M" },
       new ChartData { XValue = "Dec", YValue = 13.5, Text= "Dec: 3.5M" }
   };
}

```

![Blazor Accumulation Chart with Broken Slice](images/grouping/blazor-accumulation-chart-with-broken-slice.png)
{% previewsample "https://blazorplayground.syncfusion.com/embed/rZLqihMUfoqzKvcp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Group Mode

When [GroupMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_GroupMode) is set to [Point](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.GroupMode.html#Syncfusion_Blazor_Charts_GroupMode_Point), points are displayed as separate slices according to the `GroupTo` value. Remaining points are grouped into a single slice.

```cshtml

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Sales Analysis" EnableSmartLabels="true">
    <AccumulationChartTooltipSettings Enable="true" />

    <AccumulationChartLegendSettings Visible="false" />

    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@DataSource" XName="XValue" YName="YValue" GroupTo="9" GroupMode=GroupMode.Point>
            <AccumulationDataLabelSettings Visible="true" Name="Text" Position="AccumulationLabelPosition.Outside">
                <AccumulationChartConnector Type="ConnectorType.Line" Length="5%"></AccumulationChartConnector>
                <AccumulationChartDataLabelFont Size="14px"></AccumulationChartDataLabelFont>
            </AccumulationDataLabelSettings>
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
</SfAccumulationChart>

@code {
    public class ChartData
    {
        public string XValue { get; set; }
        public double YValue { get; set; }
        public string Text { get; set; }
    }

    public List<ChartData> DataSource = new List<ChartData>
    {
       new ChartData { XValue = "Jan", YValue = 3, Text= "Jan: 3M" },
       new ChartData { XValue = "Feb", YValue = 3.5, Text= "Feb: 3.5M" },
       new ChartData { XValue = "Mar", YValue = 7, Text= "'Mar: 7M" },
       new ChartData { XValue = "Apr", YValue = 13.5, Text= "Apr: 13.5M" },
       new ChartData { XValue = "May", YValue = 19, Text= "May: 19M" },
       new ChartData { XValue = "Jun", YValue = 23.5, Text= "Jun: 23.5M" },
       new ChartData { XValue = "Jul", YValue = 26, Text= "Jul: 26M" },
       new ChartData { XValue = "Aug", YValue = 25, Text= "Aug: 25M" },
       new ChartData { XValue = "Sep", YValue = 21, Text= "Sep: 21M" },
       new ChartData { XValue = "Oct", YValue = 15, Text= "Oct: 15M" },
       new ChartData { XValue = "Nov", YValue = 9, Text= "Nov: 9M" },
       new ChartData { XValue = "Dec", YValue = 3.5, Text= "Dec: 3.5M" }
   };
}

```

![Blazor Accumulation Chart with Group Mode](images/grouping/blazor-accumulation-chart-group-mode.png)
{% previewsample "https://blazorplayground.syncfusion.com/embed/BZrqiViApefsiZXo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> Refer to the [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore the [Blazor Accumulation Chart Example](https://blazor.syncfusion.com/demos/chart/pie?theme=bootstrap5) to know various features of accumulation charts and how it is used to represent numeric proportional data.

* [Data label](./data-labels)
* [Tooltip](./tool-tip)
* [Legend](./legend)
