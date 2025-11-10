---
layout: post
title: Numeric Axis in Blazor 3D Chart Component | Syncfusion
description: Checkout and learn here all about the Numeric Axis in Syncfusion Blazor 3D Chart component and much more.
platform: Blazor
control: 3D Chart
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Numeric Axis in Blazor 3D Chart Component

The numeric axis can be used to represent the numeric values of data in 3D chart. By default, the `ValueType` of an axis is `Double`.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@Data" XName="XValue" YName="YValue" ColumnSpacing="0.1">
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Chart3DData
    {
        public double XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<Chart3DData> Data = new List<Chart3DData>
	{
		new Chart3DData { XValue = 10, YValue = 21 },
		new Chart3DData { XValue = 20, YValue = 24 },
		new Chart3DData { XValue = 30, YValue = 36 },
		new Chart3DData { XValue = 40, YValue = 38 },
		new Chart3DData { XValue = 50, YValue = 54 },
		new Chart3DData { XValue = 60, YValue = 57 },
		new Chart3DData { XValue = 70, YValue = 70 }
	};
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDhJjRsUMqZPMXVt?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Column 3D Chart with Numeric Axis](images/numeric-axis/blazor-column-chart-numeric-axis.png)" %}

## Range

The range of an axis will be calculated automatically based on the provided data, and it can also be customized by using the `Minimum`, `Maximum`, and `Interval` properties of the axis.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis Minimum="5" Maximum="75" Interval="10"/>

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@Data" XName="XValue" YName="YValue" ColumnSpacing="0.1"/>
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Chart3DData
    {
        public double XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<Chart3DData> Data = new List<Chart3DData>
	{
		new Chart3DData { XValue = 10, YValue = 21 },
		new Chart3DData { XValue = 20, YValue = 24 },
		new Chart3DData { XValue = 30, YValue = 36 },
		new Chart3DData { XValue = 40, YValue = 38 },
		new Chart3DData { XValue = 50, YValue = 54 },
		new Chart3DData { XValue = 60, YValue = 57 },
		new Chart3DData { XValue = 70, YValue = 70 }
	};
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hNVJZHCACUsVDOLk?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Changing Column 3D Chart Axis based on Range](images/numeric-axis/blazor-column-chart-axis-range.png)" %}

## Range padding

Padding can be applied to the minimum and maximum extremes of an axis range by using the `RangePadding` property. Numeric axis supports the following types of padding.
The following types of padding are supported by the numeric axis:

* None
* Round
* Additional
* Normal
* Auto

**Numeric - None**

When the `RangePadding` is set to **None**, the minimum and maximum of an axis is based on the data.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryYAxis RangePadding="Syncfusion.Blazor.Chart3D.ChartRangePadding.None"/>

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@Data" XName="XValue" YName="YValue" ColumnSpacing="0.1"/>
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Chart3DData
    {
        public double XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<Chart3DData> Data = new List<Chart3DData>
	{
		new Chart3DData { XValue = 10, YValue = 21 },
		new Chart3DData { XValue = 20, YValue = 24 },
		new Chart3DData { XValue = 30, YValue = 36 },
		new Chart3DData { XValue = 40, YValue = 38 },
		new Chart3DData { XValue = 50, YValue = 54 },
		new Chart3DData { XValue = 60, YValue = 57 },
		new Chart3DData { XValue = 70, YValue = 70 }
	};
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LDLpDnMqCKVVDIJp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Column 3D Chart without RangePadding](images/numeric-axis/blazor-column-chart-range-without-padding.png)" %}

**Numeric - Round**

When the `RangePadding` is set to **Round**, the minimum and maximum will be rounded to the nearest possible value divisible by interval. For example, when the minimum is 3.5 and the interval is 1, then the minimum will be rounded to 3.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryYAxis RangePadding="Syncfusion.Blazor.Chart3D.ChartRangePadding.Round"/>

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@Data" XName="XValue" YName="YValue" ColumnSpacing="0.1"/>
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Chart3DData
    {
        public double XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<Chart3DData> Data = new List<Chart3DData>
	{
		new Chart3DData { XValue = 10, YValue = 21 },
		new Chart3DData { XValue = 20, YValue = 24 },
		new Chart3DData { XValue = 30, YValue = 36 },
		new Chart3DData { XValue = 40, YValue = 38 },
		new Chart3DData { XValue = 50, YValue = 54 },
		new Chart3DData { XValue = 60, YValue = 57 },
		new Chart3DData { XValue = 70, YValue = 70 }
	};
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rthTtHiUMKhdGTjA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Column 3D Chart with Round RangePadding](images/numeric-axis/blazor-column-chart-round-range-padding.png)" %}

**Numeric - Additional**

When the `RangePadding` is set to **Additional**, interval of an axis will be padded to the minimum and maximum of the axis.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryYAxis RangePadding="Syncfusion.Blazor.Chart3D.ChartRangePadding.Additional"/>

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@Data" XName="XValue" YName="YValue" ColumnSpacing="0.1"/>
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Chart3DData
    {
        public double XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<Chart3DData> Data = new List<Chart3DData>
	{
		new Chart3DData { XValue = 10, YValue = 21 },
		new Chart3DData { XValue = 20, YValue = 24 },
		new Chart3DData { XValue = 30, YValue = 36 },
		new Chart3DData { XValue = 40, YValue = 38 },
		new Chart3DData { XValue = 50, YValue = 54 },
		new Chart3DData { XValue = 60, YValue = 57 },
		new Chart3DData { XValue = 70, YValue = 70 }
	};
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LjhpZxMAiUKXQVEl?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Column 3D Chart with Additional RangePadding](images/numeric-axis/blazor-column-chart-additional-range-padding.png)" %}

**Numeric - Normal**

When the `RangePadding` is set to **Normal**, padding is applied to the axis based on default range calculation.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryYAxis RangePadding="Syncfusion.Blazor.Chart3D.ChartRangePadding.Normal"/>

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@Data" XName="XValue" YName="YValue" ColumnSpacing="0.1"/>
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Chart3DData
    {
        public double XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<Chart3DData> Data = new List<Chart3DData>
	{
		new Chart3DData { XValue = 10, YValue = 21 },
		new Chart3DData { XValue = 20, YValue = 24 },
		new Chart3DData { XValue = 30, YValue = 36 },
		new Chart3DData { XValue = 40, YValue = 38 },
		new Chart3DData { XValue = 50, YValue = 54 },
		new Chart3DData { XValue = 60, YValue = 57 },
		new Chart3DData { XValue = 70, YValue = 70 }
	};
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BjBTjdsUigqzLKgV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Column 3D Chart with Normal RangePadding](images/numeric-axis/blazor-column-chart-normal-range-padding.png)" %}

**Numeric - Auto**

When the `RangePadding` is set to **Auto**, horizontal numeric axis takes **None** as padding calculation, while the vertical numeric axis takes **Normal** as padding calculation.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryYAxis RangePadding="Syncfusion.Blazor.Chart3D.ChartRangePadding.Auto"/>
    <Chart3DPrimaryXAxis RangePadding="Syncfusion.Blazor.Chart3D.ChartRangePadding.Auto"/>

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@Data" XName="XValue" YName="YValue" ColumnSpacing="0.1"/>
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Chart3DData
    {
        public double XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<Chart3DData> Data = new List<Chart3DData>
	{
		new Chart3DData { XValue = 10, YValue = 21 },
		new Chart3DData { XValue = 20, YValue = 24 },
		new Chart3DData { XValue = 30, YValue = 36 },
		new Chart3DData { XValue = 40, YValue = 38 },
		new Chart3DData { XValue = 50, YValue = 54 },
		new Chart3DData { XValue = 60, YValue = 57 },
		new Chart3DData { XValue = 70, YValue = 70 }
	};
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rtBJNHWUiAgPWmCw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Column 3D Chart with Auto RangePadding](images/numeric-axis/blazor-column-chart-auto-rangepadding.png)" %}

## Label format

**Numeric label format**

Numeric labels can be formatted by using the `LabelFormat` property. Also, it supports all globalize format.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D Title="Sales Comparison" WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryYAxis LabelFormat="c"/>    

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@Data" XName="X" YName="Y" Type="Chart3DSeriesType.Column"/>
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Chart3DData
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public List<Chart3DData> Data = new List<Chart3DData>
	{
        new Chart3DData { X = 10, Y =7000 },
        new Chart3DData { X = 20, Y = 1000 },
        new Chart3DData { X = 30, Y = 12000 },
        new Chart3DData { X = 40, Y = 14000 },
        new Chart3DData { X = 50, Y = 11000 },
        new Chart3DData { X = 60, Y = 5000 },
        new Chart3DData { X = 70, Y = 7300 },
        new Chart3DData { X = 80, Y = 9000 },
        new Chart3DData { X = 90, Y = 12000 },
        new Chart3DData { X = 100, Y = 14000 },
        new Chart3DData { X = 110, Y = 11000 },
        new Chart3DData { X = 120, Y = 5000 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LtVzDRCUsATCTBYJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Label Formatting in Blazor Column 3D Chart](images/numeric-axis/blazor-column-chart-label-format.png)" %}

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

## Grouping separator

To separate groups of thousands for numerical values, use the `UseGroupingSeparator` property set to true in the 3D chart to enable it. When this property is enabled, axis labels, data labels, and tooltips will display with a thousand separators.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D UseGroupingSeparator="true" WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.DateTimeCategory" LabelFormat="MMM yyyy" IntervalType="Syncfusion.Blazor.Chart3D.IntervalType.Months" EdgeLabelPlacement="Syncfusion.Blazor.Chart3D.EdgeLabelPlacement.Shift">
    </Chart3DPrimaryXAxis>
    <Chart3DTooltipSettings Enable="true" />
    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@Data" Name="Test" XName="PrdDate" YName="Amount">
            <Chart3DDataLabel Visible="true" />
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code {
    public class Chart3DData
    {
        public DateTime PrdDate { get; set; }
        public double Amount { get; set; }
    }
    public List<Chart3DData> Data = new List<Chart3DData>
    {
        new Chart3DData { PrdDate = new DateTime(2021,01,01), Amount = 1000 },
        new Chart3DData { PrdDate = new DateTime(2021,02,01), Amount = 4000 },
        new Chart3DData { PrdDate = new DateTime(2021,03,01), Amount = 5000 },
        new Chart3DData { PrdDate = new DateTime(2021,04,01), Amount = 6000 },
        new Chart3DData { PrdDate = new DateTime(2021,05,01), Amount = 2000 },
        new Chart3DData { PrdDate = new DateTime(2021,06,01), Amount = 3000 },
        new Chart3DData { PrdDate = new DateTime(2021,07,01), Amount = 8000 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LDLfZHiUMgzGZgqO?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Grouping Separator in Blazor Column 3D Chart](images/numeric-axis/blazor-column-chart-grouping-separator.png)" %}

## Custom label format

Axis also supports custom label format using placeholders such as {value}K, where the value represents the axis label, for example, 20K.

```cshtml

@using Syncfusion.Blazor.Chart3D

 <SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.DateTime" IntervalType="Syncfusion.Blazor.Chart3D.IntervalType.Months" EdgeLabelPlacement="Syncfusion.Blazor.Chart3D.EdgeLabelPlacement.Shift">
    </Chart3DPrimaryXAxis>
    <Chart3DPrimaryYAxis LabelFormat="${value}K">
    </Chart3DPrimaryYAxis>
    <Chart3DTooltipSettings Enable="true" />
    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@Data" Name="Test" XName="PrdDate" YName="Amount">
            <Chart3DDataLabel Visible="true" />
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code {
    public class Chart3DData
    {
        public DateTime PrdDate { get; set; }
        public double Amount { get; set; }
    }
    public List<Chart3DData> Data = new List<Chart3DData>
    {
        new Chart3DData { PrdDate = new DateTime(2021,01,01), Amount = 1000 },
        new Chart3DData { PrdDate = new DateTime(2021,02,01), Amount = 4000 },
        new Chart3DData { PrdDate = new DateTime(2021,03,01), Amount = 5000 },
        new Chart3DData { PrdDate = new DateTime(2021,04,01), Amount = 6000 },
        new Chart3DData { PrdDate = new DateTime(2021,05,01), Amount = 2000 },
        new Chart3DData { PrdDate = new DateTime(2021,06,01), Amount = 3000 },
        new Chart3DData { PrdDate = new DateTime(2021,07,01), Amount = 8000 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rZBztRiqiUoUFbWM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Column 3D Chart with Custom Label Format](images/numeric-axis/blazor-column-chart-custom-label-format.png)" %}
