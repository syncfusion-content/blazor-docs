---
layout: post
title: Blazor Charts DateTime Axis Examples | Syncfusion®
description: Learn how to use the DateTime axis in Syncfusion Blazor Charts. Plot date-time values with a configurable label format such as yyyy or MMM.
platform: Blazor
control: Charts
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Blazor Charts DateTime Axis

## DateTime Axis

The [DateTime](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ValueType.html#Syncfusion_Blazor_Charts_ValueType_DateTime) axis uses a date-time scale and displays date-time values as axis labels in the specified format.

A detailed walkthrough for customizing the DateTime axis is provided in the video below.

{% youtube "youtube:https://www.youtube.com/watch?v=vi1nzev22Uc" %}

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReports" XName="XValue" YName="YValue" Type="ChartSeriesType.Line">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> WeatherReports = new List<ChartData>
    {
        new ChartData { XValue = new DateTime(2005, 01, 01), YValue = 21 },
        new ChartData { XValue = new DateTime(2006, 01, 01), YValue = 24 },
        new ChartData { XValue = new DateTime(2007, 01, 01), YValue = 36 },
        new ChartData { XValue = new DateTime(2008, 01, 01), YValue = 38 },
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hZhxDnCrJWRuHHpe?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage"[Blazor Chart with DateTime Axis](images/datetime/blazor-line-chart-datetime-axis.webp)" %}

## DateTime Category Axis

The [DateTime Category](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ValueType.html#Syncfusion_Blazor_Charts_ValueType_DateTimeCategory) axis is used to display date-time values with non-linear intervals. For example, only business days in a week can be plotted while skipping weekends.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis LabelFormat="d MMM yyyy" ValueType="Syncfusion.Blazor.Charts.ValueType.DateTimeCategory">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@BusinessDays" XName="XValue" YName="YValue" Type="ChartSeriesType.Line">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> BusinessDays = new List<ChartData>
    {
        new ChartData { XValue = new DateTime(2024, 03, 04), YValue = 32 },
        new ChartData { XValue = new DateTime(2024, 03, 05), YValue = 35 },
        new ChartData { XValue = new DateTime(2024, 03, 06), YValue = 30 },
        new ChartData { XValue = new DateTime(2024, 03, 07), YValue = 38 },
        new ChartData { XValue = new DateTime(2024, 03, 08), YValue = 41 },
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hjVxZviKTctDLXGm?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage"[Blazor Line Chart with DateTime Category Axis](images/datetime/blazor-line-chart-with-datetime-axis.webp)" %}

### Range

The axis range will be calculated automatically based on the provided data; however, the axis range can also be customized using [Minimum](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_Minimum), [Maximum](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_Maximum), and [Interval](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_Interval) properties.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis Minimum="new DateTime(2016, 04, 01)"
                       Maximum="new DateTime(2016, 11, 01)"
                       Interval="2"
                       IntervalType="IntervalType.Months"
                       ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReports" XName="XValue" YName="YValue" Type="ChartSeriesType.Line">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> WeatherReports = new List<ChartData>
    {
        new ChartData { XValue = new DateTime(2016, 4, 1), YValue = 21 },
        new ChartData { XValue = new DateTime(2016, 5, 1), YValue = 24 },
        new ChartData { XValue = new DateTime(2016, 6, 1), YValue = 36 },
        new ChartData { XValue = new DateTime(2016, 7, 1), YValue = 38 },
        new ChartData { XValue = new DateTime(2016, 8, 1), YValue = 46 },
        new ChartData { XValue = new DateTime(2016, 9, 1), YValue = 28 },
        new ChartData { XValue = new DateTime(2016, 10, 1), YValue = 68 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rjLnDbsKTwMsDYom?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage"[Blazor Line Chart DateTime Axis with Custom Range](images/datetime/blazor-line-chart-axis-based-on-range.webp)" %}

### Interval Customization

The [Interval](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_Interval) and [IntervalType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_IntervalType) properties of the [Axis](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html) can be used to customize date-time intervals. When interval is set to **2** and interval type is set to **Months**, it considers 2 months to be the interval. The following interval types are supported by the DateTime axis:

* Auto
* Years
* Months
* Days
* Hours
* Minutes
* Seconds

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis Interval="2" IntervalType="IntervalType.Months" ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReports" XName="XValue" YName="YValue" Type="ChartSeriesType.Line">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> WeatherReports = new List<ChartData>
    {
        new ChartData { XValue = new DateTime(2016, 4, 1), YValue = 21 },
        new ChartData { XValue = new DateTime(2016, 5, 1), YValue = 24 },
        new ChartData { XValue = new DateTime(2016, 6, 1), YValue = 36 },
        new ChartData { XValue = new DateTime(2016, 7, 1), YValue = 38 },
        new ChartData { XValue = new DateTime(2016, 8, 1), YValue = 46 },
        new ChartData { XValue = new DateTime(2016, 9, 1), YValue = 28 },
        new ChartData { XValue = new DateTime(2016, 10, 1), YValue = 68 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VNVxNdMLfWvMcOcG?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage"[Blazor Line Chart DateTime Axis with Custom Interval](images/datetime/blazor-line-chart-axis-based-on-interval.webp)" %}

### Range Padding

The [RangePadding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_RangePadding) property can be used to apply padding to the minimum and maximum extremes of the range. The following types of padding are supported by the DateTime axis:

* None
* Round
* Additional

#### None

When the [RangePadding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_RangePadding) is set to **None**, the minimum and maximum of the axis are based on the data.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis RangePadding="ChartRangePadding.None" ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReports" XName="XValue" YName="YValue" Type="ChartSeriesType.Line">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> WeatherReports = new List<ChartData>
    {
        new ChartData { XValue = new DateTime(2005, 01, 01), YValue = 21 },
        new ChartData { XValue = new DateTime(2006, 01, 01), YValue = 24 },
        new ChartData { XValue = new DateTime(2007, 01, 01), YValue = 36 },
        new ChartData { XValue = new DateTime(2008, 01, 01), YValue = 38 },
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXhRjHiBzMFGgGhA?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage"[Blazor Line Chart with RangePadding None](images/datetime/blazor-line-chart-axis-based-on-range.webp)" %}

#### Round

When the [RangePadding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_RangePadding) property is set to **Round**, the minimum and maximum are rounded to the nearest interval boundary.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis RangePadding="ChartRangePadding.Round"
                       Interval="1"
                       IntervalType="IntervalType.Years"
                       ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReports" XName="XValue" YName="YValue" Type="ChartSeriesType.Line">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> WeatherReports = new List<ChartData>
    {
        new ChartData { XValue = new DateTime(2005, 01, 01), YValue = 21 },
        new ChartData { XValue = new DateTime(2006, 01, 01), YValue = 24 },
        new ChartData { XValue = new DateTime(2007, 01, 01), YValue = 36 },
        new ChartData { XValue = new DateTime(2008, 01, 01), YValue = 38 },
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VNLnDbMgfcVPshAT?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage"[Blazor Line Chart with RangePadding Round](images/datetime/blazor-line-chart-axis-with-round-range-padding.webp)" %}

#### Additional

When the [RangePadding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_RangePadding) property is set to **Additional**, an extra interval is padded beyond the minimum and maximum of the axis.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis RangePadding="ChartRangePadding.Additional"
                       Interval="1"
                       IntervalType="IntervalType.Years"
                       ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReports" XName="XValue" YName="YValue" Type="ChartSeriesType.Line" />
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> WeatherReports = new List<ChartData>
    {
        new ChartData { XValue = new DateTime(2005, 01, 01), YValue = 21 },
        new ChartData { XValue = new DateTime(2006, 01, 01), YValue = 24 },
        new ChartData { XValue = new DateTime(2007, 01, 01), YValue = 36 },
        new ChartData { XValue = new DateTime(2008, 01, 01), YValue = 38 },
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VZVxXvCqTmGJZjJD?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage="[Blazor Line Chart with RangePadding Additional](images/datetime/blazor-line-chart-axis-with-additional-range-padding.webp)" %}

## Label Format

Using the [LabelFormat](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_LabelFormat) property on an axis, it is possible to format and parse the date to all globalize formats.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis LabelFormat="d" ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime"/>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReports" XName="XValue" YName="YValue" Type="ChartSeriesType.Line" />
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> WeatherReports = new List<ChartData>
    {
        new ChartData { XValue = new DateTime(2005, 01, 01), YValue = 21 },
        new ChartData { XValue = new DateTime(2006, 01, 01), YValue = 24 },
        new ChartData { XValue = new DateTime(2007, 01, 01), YValue = 36 },
        new ChartData { XValue = new DateTime(2008, 01, 01), YValue = 38 },
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hDVntnMLpqjGHWfF?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage"[Axis Label Formatting in Blazor Line Chart](images/datetime/blazor-line-chart-axis-label-format.webp)" %}

The following table shows the results of applying various popular date and time formats to the [LabelFormat](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_LabelFormat) property. Results depend on the application culture; see [globalization](./internationalization) for details.

<!-- markdownlint-disable MD033 -->

<table>
<tr>
<th>Group</th>
<th>Label Value</th>
<th>Label Format Property Value</th>
<th>Result</th>
<th>Description</th>
</tr>
<tr>
<td>Day</td>
<td>new DateTime(2000, 3, 10)</td>
<td>EEEE</td>
<td>Monday</td>
<td>The date is displayed in day format.</td>
</tr>
<tr>
<td>Date</td>
<td>new DateTime(2000, 3, 10)</td>
<td>yMd</td>
<td>04/10/2000</td>
<td>The date is displayed in month/date/year format.</td>
</tr>
<tr>
<td>Month</td>
<td>new DateTime(2000, 3, 10)</td>
<td>MMM</td>
<td>Apr</td>
<td>The shorthand month for the date is displayed.</td>
</tr>
<tr>
<td>Time</td>
<td>new DateTime(2000, 3, 10)</td>
<td>hm</td>
<td>12:00 AM</td>
<td>Time of the date value is displayed as label.</td>
</tr>
<tr>
<td>Time</td>
<td>new DateTime(2000, 3, 10)</td>
<td>hms</td>
<td>12:00:00 AM</td>
<td>The label is displayed in hours:minutes:seconds format.</td>
</tr>
</table>

<!-- markdownlint-disable MD033 -->

N> For an overview of supported axis types, see the [Getting Started](./getting-started) page. To explore time-dependent data examples with equal intervals, see the [Blazor Line Chart demo](https://blazor.syncfusion.com/demos/chart/line?theme=fluent2).

## See also

* [Category Axis](./category-axis)
* [Numeric Axis](./numeric-axis)
* [Logarithmic Axis](./logarithmic-axis)
* [Data Label](./data-labels)
* [Tooltip](./tool-tip)
* [Marker](./data-markers)
* [Range Padding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartRangePadding.html)