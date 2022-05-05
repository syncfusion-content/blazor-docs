---
layout: post
title: Numeric Axis in Blazor Charts Component | Syncfusion
description: Checkout and learn here all about the Numeric Axis in Syncfusion Blazor Charts component and much more.
platform: Blazor
control: Chart
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Numeric Axis in Blazor Charts Component

Numeric axis can be used to represent numeric values in a chart. The [ValueType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonAxis.html#Syncfusion_Blazor_Charts_ChartCommonAxis_ValueType) of an axis is [Double](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ValueType.html#Syncfusion_Blazor_Charts_ValueType_Double) by default.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Data" XName="XValue" YName="YValue">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public double XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> Data = new List<ChartData>
	{
		new ChartData { XValue = 10, YValue = 21 },
		new ChartData { XValue = 20, YValue = 24 },
		new ChartData { XValue = 30, YValue = 36 },
		new ChartData { XValue = 40, YValue = 38 },
		new ChartData { XValue = 50, YValue = 54 },
		new ChartData { XValue = 60, YValue = 57 },
		new ChartData { XValue = 70, YValue = 70 },
	};
}

```

![Blazor Line Chart with Numeric Axis](images/numeric-axis/blazor-line-chart-numeric-axis.png)

## Range and interval

The axis range will be calculated automatically based on the provided data; however, the axis range can also be customized using [Minimum](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonAxis.html#Syncfusion_Blazor_Charts_ChartCommonAxis_Minimum), [Maximum](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonAxis.html#Syncfusion_Blazor_Charts_ChartCommonAxis_Maximum), and [Interval](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonAxis.html#Syncfusion_Blazor_Charts_ChartCommonAxis_Interval) properties.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis Minimum="5" Maximum="50" Interval="2"/>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@Data" XName="XValue" YName="YValue"/>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public double XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> Data = new List<ChartData>
	{
		new ChartData { XValue = 10, YValue = 21 },
		new ChartData { XValue = 20, YValue = 24 },
		new ChartData { XValue = 30, YValue = 36 },
		new ChartData { XValue = 40, YValue = 38 },
		new ChartData { XValue = 50, YValue = 54 },
		new ChartData { XValue = 60, YValue = 57 },
		new ChartData { XValue = 70, YValue = 70 },
	};
}

```

![Changing Blazor Line Chart Axis based on Range](images/numeric-axis/blazor-line-chart-axis-range.png)

## Range padding

The [RangePadding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonAxis.html#Syncfusion_Blazor_Charts_ChartCommonAxis_RangePadding) property can be used to apply padding to the minimum and maximum extremes of range. The following types of padding are supported by the numeric axis:

* None
* Round
* Additional
* Normal
* Auto

**Numeric - None**

When the [RangePadding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonAxis.html#Syncfusion_Blazor_Charts_ChartCommonAxis_RangePadding) is set to **None**, the minimum and maximum of an axis is based on the data.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryYAxis RangePadding="ChartRangePadding.None"/>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@Data" XName="XValue" YName="YValue"/>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public double XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> Data = new List<ChartData>
	{
		new ChartData { XValue = 10, YValue = 21 },
		new ChartData { XValue = 20, YValue = 24 },
		new ChartData { XValue = 30, YValue = 36 },
		new ChartData { XValue = 40, YValue = 38 },
		new ChartData { XValue = 50, YValue = 54 },
		new ChartData { XValue = 60, YValue = 57 },
		new ChartData { XValue = 70, YValue = 70 },
	};
}

```

![Blazor Line Chart without RangePadding](images/numeric-axis/blazor-line-chart-range-without-padding.png)

**Numeric - Round**

When the [RangePadding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonAxis.html#Syncfusion_Blazor_Charts_ChartCommonAxis_RangePadding) is set to **Round**, the minimum and maximum will be rounded to the nearest possible value divisible by interval. For example, when the minimum is 3.5 and the interval is 1, then the minimum will be rounded to 3.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryYAxis RangePadding="ChartRangePadding.Round"/>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@Data" XName="XValue" YName="YValue"/>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public double XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> Data = new List<ChartData>
	{
		new ChartData { XValue = 10, YValue = 21 },
		new ChartData { XValue = 20, YValue = 24 },
		new ChartData { XValue = 30, YValue = 36 },
		new ChartData { XValue = 40, YValue = 38 },
		new ChartData { XValue = 50, YValue = 54 },
		new ChartData { XValue = 60, YValue = 57 },
		new ChartData { XValue = 70, YValue = 70 },
	};
}

```

![Blazor Line Chart with Round RangePadding](images/numeric-axis/blazor-line-chart-round-range-padding.png)

**Numeric - Additional**

When the [RangePadding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonAxis.html#Syncfusion_Blazor_Charts_ChartCommonAxis_RangePadding) is set to **Additional**, interval of an axis will be padded to the minimum and maximum of the axis.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryYAxis RangePadding="ChartRangePadding.Additional"/>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@Data" XName="XValue" YName="YValue"/>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public double XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> Data = new List<ChartData>
	{
		new ChartData { XValue = 10, YValue = 21 },
		new ChartData { XValue = 20, YValue = 24 },
		new ChartData { XValue = 30, YValue = 36 },
		new ChartData { XValue = 40, YValue = 38 },
		new ChartData { XValue = 50, YValue = 54 },
		new ChartData { XValue = 60, YValue = 57 },
		new ChartData { XValue = 70, YValue = 70 },
	};
}

```

![Blazor Line Chart with Additional RangePadding](images/numeric-axis/blazor-line-chart-additional-range-padding.png)

**Numeric - Normal**

When the [RangePadding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonAxis.html#Syncfusion_Blazor_Charts_ChartCommonAxis_RangePadding) is set to **Normal**, padding is applied to the axis based on default range calculation.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryYAxis RangePadding="ChartRangePadding.Normal"/>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@Data" XName="XValue" YName="YValue"/>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public double XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> Data = new List<ChartData>
	{
		new ChartData { XValue = 10, YValue = 21 },
		new ChartData { XValue = 20, YValue = 24 },
		new ChartData { XValue = 30, YValue = 36 },
		new ChartData { XValue = 40, YValue = 38 },
		new ChartData { XValue = 50, YValue = 54 },
		new ChartData { XValue = 60, YValue = 57 },
		new ChartData { XValue = 70, YValue = 70 },
	};
}

```

![Blazor Line Chart with Normal RangePadding](images/numeric-axis/blazor-line-chart-normal-range-padding.png)

**Numeric - Auto**

When the [RangePadding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonAxis.html#Syncfusion_Blazor_Charts_ChartCommonAxis_RangePadding) is set to **Auto**, horizontal numeric axis takes **None** as padding calculation, while the vertical numeric axis takes **Normal** as padding calculation.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryYAxis RangePadding="ChartRangePadding.Auto"/>
    <ChartPrimaryXAxis RangePadding="ChartRangePadding.Auto"/>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@Data" XName="XValue" YName="YValue"/>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public double XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> Data = new List<ChartData>
	{
		new ChartData { XValue = 10, YValue = 21 },
		new ChartData { XValue = 20, YValue = 24 },
		new ChartData { XValue = 30, YValue = 36 },
		new ChartData { XValue = 40, YValue = 38 },
		new ChartData { XValue = 50, YValue = 54 },
		new ChartData { XValue = 60, YValue = 57 },
		new ChartData { XValue = 70, YValue = 70 },
	};
}

```

![Blazor Line Chart with Auto RangePadding](images/numeric-axis/blazor-line-chart-auto-rangepadding.png)

## Label format

Using the [LabelFormat](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonAxis.html#Syncfusion_Blazor_Charts_ChartCommonAxis_LabelFormat) property on an axis, it is possible to format the numeric labels to all globalize formats.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Sales Comparison">
    <ChartPrimaryYAxis LabelFormat="c"/>    

    <ChartSeriesCollection>
        <ChartSeries DataSource="@Data" XName="X" YName="Y" Type="ChartSeriesType.Column"/>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> Data = new List<ChartData>
	{
          new ChartData{ X= 10, Y=7000 },
          new ChartData{ X= 20, Y= 1000 },
          new ChartData{ X= 30, Y= 12000 },
          new ChartData{ X= 40, Y= 14000 },
          new ChartData{ X= 50, Y= 11000 },
          new ChartData{ X= 60, Y= 5000 },
          new ChartData{ X= 70, Y= 7300 },
          new ChartData{ X= 80, Y= 9000 },
          new ChartData{ X= 90, Y= 12000 },
          new ChartData{ X= 100, Y= 14000 },
          new ChartData{ X= 110, Y= 11000 },
          new ChartData{ X= 120, Y= 5000 }
    };
}

```

![Label Formatting in Blazor Line Chart](images/numeric-axis/blazor-line-chart-label-format.png)

The table below shows the results of applying various commonly used label formats to numeric data.

<!-- markdownlint-disable MD033 -->

<table>
<tr>
<td><b>Label Value</b></td>
<td><b>Label Format property value</b></td>
<td><b>Result </b></td>
<td><b>Description </b></td>
</tr>
<tr>
<td>1000</td>
<td>n1</td>
<td>1000.0</td>
<td>The number is rounded to 1 decimal place.</td>
</tr>
<tr>
<td>1000</td>
<td>n2</td>
<td>1000.00</td>
<td>The number is rounded to 2 decimal places.</td>
</tr>
<tr>
<td>1000</td>
<td>n3</td>
<td>1000.000</td>
<td>The number is rounded to 3 decimal places.</td>
</tr>
<tr>
<td>0.01</td>
<td>p1</td>
<td>1.0%</td>
<td>The number is converted to percentage with 1 decimal place.</td>
</tr>
<tr>
<td>0.01</td>
<td>p2</td>
<td>1.00%</td>
<td>The number is converted to percentage with 2 decimal places.</td>
</tr>
<tr>
<td>0.01</td>
<td>p3</td>
<td>1.000%</td>
<td>The number is converted to percentage with 3 decimal places.</td>
</tr>
<tr>
<td>1000</td>
<td>c1</td>
<td>$1000.0</td>
<td>The currency symbol is appended to number and number is rounded to 1 decimal place.</td>
</tr>
<tr>
<td>1000</td>
<td>c2</td>
<td>$1000.00</td>
<td>The currency symbol is appended to number and number is rounded to 2 decimal places.</td>
</tr>
</table>

## Custom label format

Axis also supports custom label format using placeholders such as {value}K, where the value represents the axis label, for example, 20K.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryYAxis LabelFormat="${value}K" RangePadding="ChartRangePadding.Auto"/>
    <ChartPrimaryXAxis RangePadding="ChartRangePadding.Auto"/>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@Data" XName="XValue" YName="YValue"/>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public double XValue { get; set; }
        public double YValue { get; set; }
    }
    public List<ChartData> Data = new List<ChartData>
	{
		new ChartData { XValue = 10, YValue = 21 },
		new ChartData { XValue = 20, YValue = 24 },
		new ChartData { XValue = 30, YValue = 36 },
		new ChartData { XValue = 40, YValue = 38 },
		new ChartData { XValue = 50, YValue = 54 },
		new ChartData { XValue = 60, YValue = 57 },
		new ChartData { XValue = 70, YValue = 70 },
	};
}

```

![Blazor Line Chart with Custom Label Format](images/numeric-axis/blazor-line-chart-custom-label-format.png)

> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See Also

* [Data label](./data-labels)
* [Tooltip](./tool-tip)
* [Marker](./data-markers)