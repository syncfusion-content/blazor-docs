---
layout: post
title: DateTime Axis in Blazor 3D Chart Component | Syncfusion
description: Checkout and learn here all about DateTime Axis in Syncfusion Blazor 3D Chart component and much more.
platform: Blazor
control: 3D Chart
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# DateTime Axis in Blazor 3D Chart Component

## DateTime axis

`DateTime` axis uses date time scale and displays the date time values as axis labels in the specified format.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.DateTime">
    </Chart3DPrimaryXAxis>

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@WeatherReports" XName="XValue" YName="YValue" Type="Chart3DSeriesType.Column">
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Chart3DData
    {
        public DateTime XValue { get; set;}
        public double YValue {get; set;}
    }
	
    public List<Chart3DData> WeatherReports = new List<Chart3DData>
	{
		new Chart3DData { XValue = new DateTime(2000, 4, 1), YValue = 10 },
		new Chart3DData { XValue = new DateTime(2002, 5, 1), YValue = 30 },
		new Chart3DData { XValue = new DateTime(2004, 6, 1), YValue = 15 },
		new Chart3DData { XValue = new DateTime(2006, 7, 1), YValue = 65 },
		new Chart3DData { XValue = new DateTime(2008, 8, 1), YValue = 90 },
		new Chart3DData { XValue = new DateTime(2010, 9, 1), YValue = 85 }
	};
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hjhTZHirphUnPCqM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor 3D Chart with DateTime Axis](images/datetime/blazor-column-chart-datetime-axis.png)

## DateTime category axis

The `DateTimeCategory` axis is used to display the date time values with non-linear intervals. For example, the business days alone have been depicted in a week here.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.DateTimeCategory">
    </Chart3DPrimaryXAxis>

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@WeatherReports" XName="XValue" YName="YValue">
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Chart3DData
    {
        public DateTime XValue { get; set;}
        public double YValue {get; set;}
    }
	
    public List<Chart3DData> WeatherReports = new List<Chart3DData>
	{
        new Chart3DData { XValue = new DateTime(2005, 01, 01), YValue = 21 },
		new Chart3DData { XValue = new DateTime(2006, 02, 01), YValue = 24 },
		new Chart3DData { XValue = new DateTime(2007, 03, 01), YValue = 36 },
		new Chart3DData { XValue = new DateTime(2008, 04, 01), YValue = 38 }
	};
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hXLpjHiVJrKOIbbu?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Column 3D Chart with DateTime Axis](images/datetime/blazor-column-chart-with-datetime-axis.png)

### Range

Range of an axis will be calculated automatically based on the provided data. You can also customize the range of an axis using `Minimum`, `Maximum`, and `Interval` properties.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis Interval="1" Minimum="@minimum" Maximum="@maximum" ValueType="Syncfusion.Blazor.Chart3D.ValueType.DateTime">
    </Chart3DPrimaryXAxis>
    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@WeatherReports" XName="XValue" YName="YValue">
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code {
    public DateTime minimum = new DateTime(2000, 3, 1);
    public DateTime maximum = new DateTime(2010, 10, 1);
    public class Chart3DData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<Chart3DData> WeatherReports = new List<Chart3DData>
    {
        new Chart3DData { XValue = new DateTime(2000, 4, 1), YValue = 21 },
        new Chart3DData { XValue = new DateTime(2002, 5, 1), YValue = 24 },
        new Chart3DData { XValue = new DateTime(2004, 6, 1), YValue = 36 },
        new Chart3DData { XValue = new DateTime(2006, 7, 1), YValue = 38 },
        new Chart3DData { XValue = new DateTime(2008, 8, 1), YValue = 46 },
        new Chart3DData { XValue = new DateTime(2010, 9, 1), YValue = 28 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VDrJXdCLzhJLRmjw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Changing Blazor Column 3D Chart DateTime Axis based on Range](images/datetime/blazor-column-chart-axis-based-on-range.png)

### Interval customization

Date time intervals can be customized by using the `Interval` and `IntervalType` properties of the `Axis`. For example, when you set `Interval` as **2** and `IntervalType` as **Years**, it considers 2 years as interval. DateTime axis supports following interval types,

* Auto
* Years
* Months
* Days
* Hours
* Minutes
* Seconds

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis Interval="1" IntervalType="Syncfusion.Blazor.Chart3D.IntervalType.Months" ValueType="Syncfusion.Blazor.Chart3D.ValueType.DateTime">
    </Chart3DPrimaryXAxis>
    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@WeatherReports" XName="XValue" YName="YValue">
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Chart3DData
    {
        public DateTime XValue { get; set;}
        public double YValue {get; set;}
    }
	
    public List<Chart3DData> WeatherReports = new List<Chart3DData>
	{
		new Chart3DData { XValue = new DateTime(2016, 4, 1), YValue = 21 },
		new Chart3DData { XValue = new DateTime(2016, 5, 1), YValue = 24 },
		new Chart3DData { XValue = new DateTime(2016, 6, 1), YValue = 36 },
		new Chart3DData { XValue = new DateTime(2016, 7, 1), YValue = 38 },
		new Chart3DData { XValue = new DateTime(2016, 8, 1), YValue = 46 },
		new Chart3DData { XValue = new DateTime(2016, 9, 1), YValue = 28 }
	};
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LNBpDdirTBfmVqNO?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Changing Blazor Column 3D Chart DateTime Axis based on Interval](images/datetime/blazor-column-chart-axis-based-on-interval.png)

**Applying padding to the Range**

The `RangePadding` property can be used to apply padding to the minimum and maximum extremes of range. The following types of padding are supported by the DateTime axis:

* None
* Round
* Additional

**DateTime - None**

When the `RangePadding` is set to **None**, the minimum and maximum of the axis is based on the data.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis RangePadding="Syncfusion.Blazor.Chart3D.ChartRangePadding.None" ValueType="Syncfusion.Blazor.Chart3D.ValueType.DateTime">
    </Chart3DPrimaryXAxis>

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@WeatherReports" XName="XValue" YName="YValue">
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code {
    public class Chart3DData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<Chart3DData> WeatherReports = new List<Chart3DData>
    {
        new Chart3DData { XValue = new DateTime(2017, 11, 20), YValue = 21 },
        new Chart3DData { XValue = new DateTime(2017, 11, 21), YValue = 24 },
        new Chart3DData { XValue = new DateTime(2017, 11, 22), YValue = 24 },
        new Chart3DData { XValue = new DateTime(2017, 11, 26), YValue = 70 },
        new Chart3DData { XValue = new DateTime(2017, 11, 27), YValue = 75 },
        new Chart3DData { XValue = new DateTime(2017, 11, 29), YValue = 82 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LNrptHMhfBIrZRdV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Column 3D Chart without RangePadding](images/datetime/blazor-column-chart-axis-based-on-range-none.png)

**DateTime - Round**

When the `RangePadding` is set to `Round`, minimum and maximum will be rounded to the nearest possible value, which is divisible by interval. For example, when the minimum is **15th Jan**, interval is **1** and interval type is **Month**, then the axis minimum will be **Jan 1st**.


```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis RangePadding="Syncfusion.Blazor.Chart3D.ChartRangePadding.Round" ValueType="Syncfusion.Blazor.Chart3D.ValueType.DateTime">
    </Chart3DPrimaryXAxis>

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@WeatherReports" XName="XValue" YName="YValue">
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Chart3DData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }
	
    public List<Chart3DData> WeatherReports = new List<Chart3DData>
	{
		new Chart3DData { XValue = new DateTime(2017, 11, 20), YValue = 21 },
        new Chart3DData { XValue = new DateTime(2017, 11, 21), YValue = 24 },
        new Chart3DData { XValue = new DateTime(2017, 11, 22), YValue = 24 },
        new Chart3DData { XValue = new DateTime(2017, 11, 26), YValue = 70 },
        new Chart3DData { XValue = new DateTime(2017, 11, 27), YValue = 75 },
        new Chart3DData { XValue = new DateTime(2017, 11, 29), YValue = 82 }
    };                                             
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rthpZRWBJVSnflQi?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Column 3D Chart with Round RangePadding](images/datetime/blazor-column-chart-axis-based-on-range-round.png)

**DateTime - Additional**

When the `RangePadding` property is set to **Additional**, the interval of an axis will be padded to the minimum and maximum of the axis.

```cshtml

@using Syncfusion.Blazor.Chart3D
 
<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis RangePadding="Syncfusion.Blazor.Chart3D.ChartRangePadding.Additional" ValueType="Syncfusion.Blazor.Chart3D.ValueType.DateTime">
    </Chart3DPrimaryXAxis>

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@WeatherReports" XName="XValue" YName="YValue">
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Chart3DData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }
	
    public List<Chart3DData> WeatherReports = new List<Chart3DData>
    {
        new Chart3DData { XValue = new DateTime(2017, 11, 20), YValue = 21 },
        new Chart3DData { XValue = new DateTime(2017, 11, 21), YValue = 24 },
        new Chart3DData { XValue = new DateTime(2017, 11, 22), YValue = 24 },
        new Chart3DData { XValue = new DateTime(2017, 11, 26), YValue = 70 },
        new Chart3DData { XValue = new DateTime(2017, 11, 27), YValue = 75 },
        new Chart3DData { XValue = new DateTime(2017, 11, 29), YValue = 82 }
    };                                            
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BXBTjdsrfrxMZeIc?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Column 3D Chart with Additional RangePadding](images/datetime/blazor-column-chart-axis-based-on-range-Additional.png)

## Label format

The date can be formatted and parsed to all globalize format using the `LabelFormat` property in an axis.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis LabelFormat="dd/MM" ValueType="Syncfusion.Blazor.Chart3D.ValueType.DateTime">
    </Chart3DPrimaryXAxis>

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@WeatherReports" XName="XValue" YName="YValue">
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Chart3DData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }
	
    public List<Chart3DData> WeatherReports = new List<Chart3DData>
	{
		new Chart3DData { XValue = new DateTime(2017, 11, 20), YValue = 21 },
		new Chart3DData { XValue = new DateTime(2017, 11, 21), YValue = 24 },
        new Chart3DData { XValue = new DateTime(2017, 11, 22), YValue = 24 },
		new Chart3DData { XValue = new DateTime(2017, 11, 26), YValue = 70 },
		new Chart3DData { XValue = new DateTime(2017, 11, 27), YValue = 75 }, 
		new Chart3DData { XValue = new DateTime(2017, 12, 02), YValue = 82 },
		new Chart3DData { XValue = new DateTime(2017, 12, 03), YValue = 53 }, 
		new Chart3DData { XValue = new DateTime(2017, 12, 04), YValue = 54 },
		new Chart3DData { XValue = new DateTime(2017, 12, 05), YValue = 53 }, 
		new Chart3DData { XValue = new DateTime(2017, 12, 08), YValue = 45 }
    };                                             
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VZLftHshTUyFcIMA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Axis Label Formatting in Blazor Column 3D Chart](images/datetime/blazor-column-chart-axis-label-format.png)

The table below shows the results of applying various popular date and time formats to the `LabelFormat` property.

<!-- markdownlint-disable MD033 -->

<table>
<tr>
<td><b>Label Value</b></td>
<td><b>Label Format Property Value</b></td>
<td><b>Result </b></td>
<td><b>Description </b></td>
</tr>
<tr>
<td>new Date(2000, 03, 10)</td>
<td>EEEE</td>
<td>Monday</td>
<td>The date is displayed in day format.</td>
</tr>
<tr>
<td>new Date(2000, 03, 10)</td>
<td>yMd</td>
<td>04/10/2000</td>
<td>The date is displayed in month/date/year format.</td>
</tr>
<tr>
<td>new Date(2000, 03, 10)</td>
<td> MMM </td>
<td>Apr</td>
<td>The shorthand month for the date is displayed.</td>
</tr>
<tr>
<td>new Date(2000, 03, 10)</td>
<td>hm</td>
<td>12:00 AM</td>
<td>Time of the date value is displayed as label.</td>
</tr>
<tr>
<td>new Date(2000, 03, 10)</td>
<td>hms</td>
<td>12:00:00 AM</td>
<td>The label is displayed in hours:minutes:seconds format.</td>
</tr>
</table>

<!-- markdownlint-disable MD033 -->
