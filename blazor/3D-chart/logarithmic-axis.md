---
layout: post
title: Logarithmic Axis in Blazor 3D Chart Component | Syncfusion
description: Checkout and learn here all about Logarithmic Axis in Syncfusion Blazor 3D Chart component and much more.
platform: Blazor
control: 3D Chart
documentation: ug
---

# Logarithmic Axis in Blazor 3D Chart Component

<!-- markdownlint-disable MD033 -->

Logarithmic axis uses logarithmic scale and it is very useful in visualizing data, when it has numerical values in both lower order of magnitude (eg: 10<sup>-6</sup>) and higher order of magnitude (eg: 10<sup>6</sup>).

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.DateTime"></Chart3DPrimaryXAxis>

    <Chart3DPrimaryYAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.Logarithmic"/>    

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@Data" XName="XValue" YName="YValue" />        
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Chart3DData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<Chart3DData> Data = new List<Chart3DData> 
	{
		new Chart3DData { XValue = new DateTime(1995, 01, 01), YValue = 80 },
		new Chart3DData { XValue = new DateTime(1996, 01, 01), YValue = 200 },
		new Chart3DData { XValue = new DateTime(1997, 01, 01), YValue = 400 }, 
		new Chart3DData { XValue = new DateTime(1998, 01, 01), YValue = 600 },
		new Chart3DData { XValue = new DateTime(1999, 01, 01), YValue = 700 }, 
		new Chart3DData { XValue = new DateTime(2000, 01, 01), YValue = 1400 },
		new Chart3DData { XValue = new DateTime(2001, 01, 01), YValue = 2000 }, 
		new Chart3DData { XValue = new DateTime(2002, 01, 01), YValue = 4000 },
		new Chart3DData { XValue = new DateTime(2003, 01, 01), YValue = 6000 }, 
		new Chart3DData { XValue = new DateTime(2004, 01, 01), YValue = 8000 },
		new Chart3DData { XValue = new DateTime(2005, 01, 01), YValue = 11000 }
	};
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rZrJtnsUsBeKhZTc?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor 3D Chart with Logarithmic Axis](images/logarithmic-axis/blazor-chart-logarithmic-axis.png)" %}

## Range

The range of an axis will be calculated automatically based on the provided data and it can also be customized by using the `Minimum`, `Maximum` and `Interval` properties of the axis.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.DateTime"></Chart3DPrimaryXAxis>

    <Chart3DPrimaryYAxis Minimum="100" Maximum="10000" ValueType="Syncfusion.Blazor.Chart3D.ValueType.Logarithmic"/>    

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@Data" XName="XValue" YName="YValue" />        
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Chart3DData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<Chart3DData> Data = new List<Chart3DData> 
	{
		new Chart3DData { XValue = new DateTime(1995, 01, 01), YValue = 80 },
		new Chart3DData { XValue = new DateTime(1996, 01, 01), YValue = 200 },
		new Chart3DData { XValue = new DateTime(1997, 01, 01), YValue = 400 }, 
		new Chart3DData { XValue = new DateTime(1998, 01, 01), YValue = 600 },
		new Chart3DData { XValue = new DateTime(1999, 01, 01), YValue = 700 }, 
		new Chart3DData { XValue = new DateTime(2000, 01, 01), YValue = 1400 },
		new Chart3DData { XValue = new DateTime(2001, 01, 01), YValue = 2000 }, 
		new Chart3DData { XValue = new DateTime(2002, 01, 01), YValue = 4000 },
		new Chart3DData { XValue = new DateTime(2003, 01, 01), YValue = 6000 }, 
		new Chart3DData { XValue = new DateTime(2004, 01, 01), YValue = 8000 },
		new Chart3DData { XValue = new DateTime(2005, 01, 01), YValue = 11000 }
	};
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BZhzZnCUCBSddGpF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Changing Blazor Column 3D Chart Logarithmic Axis based on Range](images/logarithmic-axis/blazor-column-chart-axis-based-on-range.png)" %}

## Logarithmic base

Logarithmic base can be customized by using the `LogBase` property of the axis. For example when the `LogBase` is **5**, the axis values follows 5<sup>-2</sup>, 5<sup>-1</sup>, 5<sup>0</sup>, 5<sup>1</sup>, 5<sup>2</sup> etc.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.DateTime"></Chart3DPrimaryXAxis>

    <Chart3DPrimaryYAxis LogBase="2" ValueType="Syncfusion.Blazor.Chart3D.ValueType.Logarithmic"/>    

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@Data" XName="XValue" YName="YValue" />        
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Chart3DData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<Chart3DData> Data = new List<Chart3DData> 
	{
		new Chart3DData { XValue = new DateTime(1995, 01, 01), YValue = 80 },
		new Chart3DData { XValue = new DateTime(1996, 01, 01), YValue = 200 },
		new Chart3DData { XValue = new DateTime(1997, 01, 01), YValue = 400 }, 
		new Chart3DData { XValue = new DateTime(1998, 01, 01), YValue = 600 },
		new Chart3DData { XValue = new DateTime(1999, 01, 01), YValue = 700 }, 
		new Chart3DData { XValue = new DateTime(2000, 01, 01), YValue = 1400 },
		new Chart3DData { XValue = new DateTime(2001, 01, 01), YValue = 2000 }, 
		new Chart3DData { XValue = new DateTime(2002, 01, 01), YValue = 4000 },
		new Chart3DData { XValue = new DateTime(2003, 01, 01), YValue = 6000 }, 
		new Chart3DData { XValue = new DateTime(2004, 01, 01), YValue = 8000 },
		new Chart3DData { XValue = new DateTime(2005, 01, 01), YValue = 11000 }
	};
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rDBTZdWqWhouoYOv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Column 3D Chart Logarithmic Axis with Base](images/logarithmic-axis/blazor-column-chart-logarithmic-axis-with-base.png)" %}

## Logarithmic interval

The interval of the logarithmic axis can be customized by using the `Interval` property in the axis. When the logarithmic base is 10 and logarithmic **interval** is 2, then the axis labels are placed at an interval of 10<sup>2</sup>. The default value of the `Interval` is **1**.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.DateTime"></Chart3DPrimaryXAxis>

    <Chart3DPrimaryYAxis Interval="2" LogBase="2" ValueType="Syncfusion.Blazor.Chart3D.ValueType.Logarithmic"/>    

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@Data" XName="XValue" YName="YValue" />        
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Chart3DData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<Chart3DData> Data = new List<Chart3DData> 
	{
		new Chart3DData { XValue = new DateTime(1995, 01, 01), YValue = 80 },
		new Chart3DData { XValue = new DateTime(1996, 01, 01), YValue = 200 },
		new Chart3DData { XValue = new DateTime(1997, 01, 01), YValue = 400 }, 
		new Chart3DData { XValue = new DateTime(1998, 01, 01), YValue = 600 },
		new Chart3DData { XValue = new DateTime(1999, 01, 01), YValue = 700 }, 
		new Chart3DData { XValue = new DateTime(2000, 01, 01), YValue = 1400 },
		new Chart3DData { XValue = new DateTime(2001, 01, 01), YValue = 2000 }, 
		new Chart3DData { XValue = new DateTime(2002, 01, 01), YValue = 4000 },
		new Chart3DData { XValue = new DateTime(2003, 01, 01), YValue = 6000 }, 
		new Chart3DData { XValue = new DateTime(2004, 01, 01), YValue = 8000 },
		new Chart3DData { XValue = new DateTime(2005, 01, 01), YValue = 11000 }
	};
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LDBTNniUMVdBYcdW?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Changing Blazor Column 3D Chart Logarithmic Axis based on Interval](images/logarithmic-axis/blazor-column-chart-axis-based-on-range-interval.png)" %}
