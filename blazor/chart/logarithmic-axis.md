---
layout: post
title: Blazor Charts Logarithmic Axis Examples | Syncfusion®
description: Learn how to use the logarithmic axis in Syncfusion Blazor Charts. Visualize data spanning many orders of magnitude in a single readable view.
platform: Blazor
control: Charts
documentation: ug
---

# Blazor Charts Logarithmic Axis

<!-- markdownlint-disable MD033 -->

When data spans many orders of magnitude (e.g., 10<sup>-6</sup> to 10<sup>6</sup>), a logarithmic axis is highly useful for visualizing it on a single, readable scale.

Watch the video below for a walkthrough of the options covered in this article.

{% youtube "youtube:https://www.youtube.com/watch?v=_67hCchVOu4" %}

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime"/>    

    <ChartPrimaryYAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Logarithmic"/>    

    <ChartSeriesCollection>
        <ChartSeries DataSource="@Data" XName="XValue" YName="YValue" />        
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> Data = new List<ChartData> 
	{
		new ChartData { XValue = new DateTime(2005, 01, 01), YValue = 100   },
		new ChartData { XValue = new DateTime(2006, 01, 01), YValue = 200   },
		new ChartData { XValue = new DateTime(2007, 01, 01), YValue = 500   },
		new ChartData { XValue = new DateTime(2008, 01, 01), YValue = 1000  },
		new ChartData { XValue = new DateTime(2009, 01, 01), YValue = 8000  },
		new ChartData { XValue = new DateTime(2010, 01, 01), YValue = 90000 },
		new ChartData { XValue = new DateTime(2011, 01, 01), YValue = 99000 },
	};
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rZLHNRMBJKWGoOWk?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Chart with Logarithmic Axis](images/logarithmic-axis/blazor-chart-logarithmic-axis.webp)" %}

## Range

The axis range is calculated automatically from the provided data. Use [Minimum](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_Minimum) and [Maximum](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_Maximum) to override the range. The label spacing along the range is controlled by the [Interval](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_Interval) property, which is covered separately in the [Logarithmic interval](#logarithmic-interval) section.

N> A logarithmic axis requires strictly positive values. Set `Minimum` and `Maximum` to positive numbers; values of `0` or negative numbers are not rendered.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime"/>
    
    <ChartPrimaryYAxis Minimum="100" Maximum="10000" ValueType="Syncfusion.Blazor.Charts.ValueType.Logarithmic"/>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@Data" XName="XValue" YName="YValue"/>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> Data = new List<ChartData> 
	{
		new ChartData { XValue = new DateTime(2005, 01, 01), YValue = 100   },
		new ChartData { XValue = new DateTime(2006, 01, 01), YValue = 200   },
		new ChartData { XValue = new DateTime(2007, 01, 01), YValue = 500   },
		new ChartData { XValue = new DateTime(2008, 01, 01), YValue = 1000  },
		new ChartData { XValue = new DateTime(2009, 01, 01), YValue = 8000  },
		new ChartData { XValue = new DateTime(2010, 01, 01), YValue = 90000 },
		new ChartData { XValue = new DateTime(2011, 01, 01), YValue = 99000 },
	};
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rDhxXdWVpqLMgDHe?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Changing Blazor Line Chart Logarithmic Axis based on Range](images/logarithmic-axis/blazor-line-chart-axis-based-on-range.webp)" %}

## Logarithmic base

Logarithmic base can be customized using the [LogBase](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_LogBase) property of the axis. When `LogBase` is `2`, the axis values are 2<sup>-2</sup>, 2<sup>-1</sup>, 2<sup>0</sup>, 2<sup>1</sup>, 2<sup>2</sup> and so on.

N> `LogBase` must be greater than `1`.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime"/>    

    <ChartPrimaryYAxis LogBase="2" ValueType="Syncfusion.Blazor.Charts.ValueType.Logarithmic"/>    

    <ChartSeriesCollection>
        <ChartSeries DataSource="@Data" XName="XValue" YName="YValue" />        
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> Data = new List<ChartData> 
	{
		new ChartData { XValue = new DateTime(2005, 01, 01), YValue = 100   },
		new ChartData { XValue = new DateTime(2006, 01, 01), YValue = 200   },
		new ChartData { XValue = new DateTime(2007, 01, 01), YValue = 500   },
		new ChartData { XValue = new DateTime(2008, 01, 01), YValue = 1000  },
		new ChartData { XValue = new DateTime(2009, 01, 01), YValue = 8000  },
		new ChartData { XValue = new DateTime(2010, 01, 01), YValue = 90000 },
		new ChartData { XValue = new DateTime(2011, 01, 01), YValue = 99000 },
	};
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hXhHZdMhTKqNmdhS?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Line Chart Logarithmic Axis with Base](images/logarithmic-axis/blazor-line-chart-logarithmic-axis-with-base.webp)" %}

## Logarithmic interval

The interval can be customized using the [Interval](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_Interval) property of the logarithmic axis. The interval is expressed as a multiplier of the base: when `LogBase` is `2` and `Interval` is `2`, the axis labels are placed at 2<sup>2</sup>, 2<sup>4</sup>, 2<sup>6</sup> and so on. The default value of the interval is `1`.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime"/>    

    <ChartPrimaryYAxis Interval="2" LogBase="2" ValueType="Syncfusion.Blazor.Charts.ValueType.Logarithmic"/>    

    <ChartSeriesCollection>
        <ChartSeries DataSource="@Data" XName="XValue" YName="YValue" />        
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> Data = new List<ChartData> 
	{
		new ChartData { XValue = new DateTime(2005, 01, 01), YValue = 100   },
		new ChartData { XValue = new DateTime(2006, 01, 01), YValue = 200   },
		new ChartData { XValue = new DateTime(2007, 01, 01), YValue = 500   },
		new ChartData { XValue = new DateTime(2008, 01, 01), YValue = 1000  },
		new ChartData { XValue = new DateTime(2009, 01, 01), YValue = 8000  },
		new ChartData { XValue = new DateTime(2010, 01, 01), YValue = 90000 },
		new ChartData { XValue = new DateTime(2011, 01, 01), YValue = 99000 },
	};
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BXBnZxCVJgKJLgey?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Changing Blazor Line Chart Logarithmic Axis based on Interval](images/logarithmic-axis/blazor-line-chart-axis-based-on-range.webp)" %}

## Label format

Using the [LabelFormat](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_LabelFormat) property on an axis, it is possible to format the logarithmic labels to all globalize formats.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime"/>    

    <ChartPrimaryYAxis LabelFormat="P1" ValueType="Syncfusion.Blazor.Charts.ValueType.Logarithmic"/>    

    <ChartSeriesCollection>
        <ChartSeries DataSource="@Data" XName="XValue" YName="YValue" />        
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> Data = new List<ChartData> 
	{
		new ChartData { XValue = new DateTime(2005, 01, 01), YValue = 100   },
		new ChartData { XValue = new DateTime(2006, 01, 01), YValue = 200   },
		new ChartData { XValue = new DateTime(2007, 01, 01), YValue = 500   },
		new ChartData { XValue = new DateTime(2008, 01, 01), YValue = 1000  },
		new ChartData { XValue = new DateTime(2009, 01, 01), YValue = 8000  },
		new ChartData { XValue = new DateTime(2010, 01, 01), YValue = 90000 },
		new ChartData { XValue = new DateTime(2011, 01, 01), YValue = 99000 },
	};
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNVnXxCBJqqwxiXU?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Line Chart Logarithmic Axis with Label Format](images/logarithmic-axis/blazor-line-chart-axis-with-label-format.webp)" %}

The table below shows the results of applying some commonly used label formats to logarithmic values.

<!-- markdownlint-disable MD033 -->

<table>
<tr>
<td><b>Label Value</b></td>
<td><b>Label Format property value</b></td>
<td><b>Result</b></td>
<td><b>Description</b></td>
</tr>
<tr>
<td>1000</td>
<td>n1</td>
<td>1000.0</td>
<td>The value is rounded to 1 decimal place.</td>
</tr>
<tr>
<td>1000</td>
<td>n2</td>
<td>1000.00</td>
<td>The value is rounded to 2 decimal places.</td>
</tr>
<tr>
<td>1000</td>
<td>n3</td>
<td>1000.000</td>
<td>The value is rounded to 3 decimal places.</td>
</tr>
<tr>
<td>0.01</td>
<td>p1</td>
<td>1.0%</td>
<td>The value is converted to percentage with 1 decimal place.</td>
</tr>
<tr>
<td>0.01</td>
<td>p2</td>
<td>1.00%</td>
<td>The value is converted to percentage with 2 decimal places.</td>
</tr>
<tr>
<td>0.01</td>
<td>p3</td>
<td>1.000%</td>
<td>The value is converted to percentage with 3 decimal places.</td>
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

Axis also supports custom label formats using the `{value}` placeholder, which is replaced at render time with the actual axis label. For example, with `LabelFormat="${value}K"` a label value of `200` is rendered as `200K`.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime"/>    

    <ChartPrimaryYAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Logarithmic" LabelFormat="${value}K" RangePadding="ChartRangePadding.Auto"/>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@Data" XName="XValue" YName="YValue" />        
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> Data = new List<ChartData> 
	{
		new ChartData { XValue = new DateTime(2005, 01, 01), YValue = 100   },
		new ChartData { XValue = new DateTime(2006, 01, 01), YValue = 200   },
		new ChartData { XValue = new DateTime(2007, 01, 01), YValue = 500   },
		new ChartData { XValue = new DateTime(2008, 01, 01), YValue = 1000  },
		new ChartData { XValue = new DateTime(2009, 01, 01), YValue = 8000  },
		new ChartData { XValue = new DateTime(2010, 01, 01), YValue = 90000 },
		new ChartData { XValue = new DateTime(2011, 01, 01), YValue = 99000 },
	};
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXLHXRCVJgpHHeDg?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Line Chart Logarithmic Axis with Custom Label Format](images/logarithmic-axis/blazor-line-chart-axis-custom-label-format.webp)" %}

## See also

* [Data label](./data-labels)
* [Tooltip](./tool-tip)
* [Marker](./data-markers)
* [Numeric axis](./numeric-axis)
* [Date-time axis](./date-time-axis)
* [Logarithmic axis live demo](https://blazor.syncfusion.com/demos/chart/logarithmic-axis?theme=fluent2)