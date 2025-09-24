---
layout: post
title: 100% Stacked Area in Blazor Charts Component | Syncfusion
description: Check out and learn how to configure and customize 100% Stacked Area Chart in Syncfusion Blazor Charts component.
platform: Blazor
control: Chart
documentation: ug
---

# 100% Stacked Area in Blazor Charts Component

## 100% Stacked Area Chart

[100% Stacked Area Chart](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/100-stacked-area-chart) displays multiple series as stacked areas where each stack represents a percentage of the total at that X value. The y-axis always ranges from 0 to 100%. To render a [100% stacked area](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/100-stacked-area-chart) series, set the series [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Type) to [`StackingArea100`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_StackingArea100). Values are normalized per point so the sum of all series at each X value is 100%. For accurate stacking, ensure that series share the same X values.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartDataList" XName="X" YName="Y" Type="ChartSeriesType.StackingArea100" />
        <ChartSeries DataSource="@ChartDataList" XName="X" YName="Y1" Type="ChartSeriesType.StackingArea100" />
        <ChartSeries DataSource="@ChartDataList" XName="X" YName="Y2" Type="ChartSeriesType.StackingArea100" />
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
    }
	
    public List<ChartData> ChartDataList = new List<ChartData>
	{
        new ChartData{ X= 2000, Y= 0.61, Y1= 0.03, Y2= 0.48 },
        new ChartData{ X= 2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
        new ChartData{ X= 2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
        new ChartData{ X= 2003, Y= 1, Y1= 0.09, Y2= 0.61 },
        new ChartData{ X= 2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
        new ChartData{ X= 2005, Y= 1.47, Y1= 0.20, Y2= 0.64 },
        new ChartData{ X= 2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
        new ChartData{ X= 2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
        new ChartData{ X= 2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
        new ChartData{ X= 2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/rNBAiVhnTxBScRGk?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Stacked Area 100 Chart](../images/chart-types-images/blazor-stacked-area-100-chart.png)

N> Refer to the [Blazor 100% Stacked Area Chart](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/100-stacked-area-chart) feature tour page for additional capabilities. Explore the [Blazor 100% Stacked Area Chart example](https://blazor.syncfusion.com/demos/chart/percent-stacked-area?theme=bootstrap5) to see rendering and configuration options.

## Binding data with series

Bind data to the chart using the series [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) property. The [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) can be provided via [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) or a list of business objects. For details, see [Working with data](../working-with-data). Map data fields to [`XName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_XName) and [`YName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_YName) to render points correctly.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartDataList" XName="X" YName="Y" Type="ChartSeriesType.StackingArea100" />
        <ChartSeries DataSource="@ChartDataList" XName="X" YName="Y1" Type="ChartSeriesType.StackingArea100" />
        <ChartSeries DataSource="@ChartDataList" XName="X" YName="Y2" Type="ChartSeriesType.StackingArea100" />
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
    }
	
    public List<ChartData> ChartDataList = new List<ChartData>
	{
        new ChartData{ X= 2000, Y= 0.61, Y1= 0.03, Y2= 0.48 },
        new ChartData{ X= 2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
        new ChartData{ X= 2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
        new ChartData{ X= 2003, Y= 1, Y1= 0.09, Y2= 0.61 },
        new ChartData{ X= 2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
        new ChartData{ X= 2005, Y= 1.47, Y1= 0.20, Y2= 0.64 },
        new ChartData{ X= 2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
        new ChartData{ X= 2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
        new ChartData{ X= 2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
        new ChartData{ X= 2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/rNBAiVhnTxBScRGk?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Series customization

The following properties can be used to customize the [100% Stacked Area](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_StackingArea100) series.

**Fill**

The [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) property sets the color used to paint the area for a series.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartDataList" XName="X" YName="Y" Fill="red" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100" />
        <ChartSeries DataSource="@ChartDataList" XName="X" YName="Y1" Fill="blue" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100" />
        <ChartSeries DataSource="@ChartDataList" XName="X" YName="Y2" Fill="green" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100" />
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
    }

    public List<ChartData> ChartDataList = new List<ChartData>
    {
        new ChartData{ X= 2000, Y= 0.61, Y1= 0.03, Y2= 0.48 },
        new ChartData{ X= 2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
        new ChartData{ X= 2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
        new ChartData{ X= 2003, Y= 1, Y1= 0.09, Y2= 0.61 },
        new ChartData{ X= 2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
        new ChartData{ X= 2005, Y= 1.47, Y1= 0.20, Y2= 0.64 },
        new ChartData{ X= 2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
        new ChartData{ X= 2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
        new ChartData{ X= 2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
        new ChartData{ X= 2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rjBztPikzoCgUnJJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

The [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) property also supports gradients. Use an SVG gradient reference to apply smooth color transitions.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartDataList" XName="X" YName="Y" Fill="url(#grad1)" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100" />
        <ChartSeries DataSource="@ChartDataList" XName="X" YName="Y1" Fill="url(#grad2)" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100" />
        <ChartSeries DataSource="@ChartDataList" XName="X" YName="Y2" Fill="url(#grad3)" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100" />
    </ChartSeriesCollection>
</SfChart>

<svg style="height: 0">
    <defs>
        <linearGradient id="grad1" x1="0%" y1="0%" x2="0%" y2="100%">
            <stop offset="20%" style="stop-color:orange;stop-opacity:1" />
            <stop offset="100%" style="stop-color:black;stop-opacity:1" />
        </linearGradient>
    </defs>
</svg>

<svg style="height: 0">
    <defs>
        <linearGradient id="grad2" x1="0%" y1="0%" x2="0%" y2="100%">
            <stop offset="20%" style="stop-color:blue;stop-opacity:1" />
            <stop offset="100%" style="stop-color:black;stop-opacity:1" />
        </linearGradient>
    </defs>
</svg>

<svg style="height: 0">
    <defs>
        <linearGradient id="grad3" x1="0%" y1="0%" x2="0%" y2="100%">
            <stop offset="20%" style="stop-color:green;stop-opacity:1" />
            <stop offset="100%" style="stop-color:black;stop-opacity:1" />
        </linearGradient>
    </defs>
</svg>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
    }

    public List<ChartData> ChartDataList = new List<ChartData>
    {
        new ChartData{ X= 2000, Y= 0.61, Y1= 0.03, Y2= 0.48},
        new ChartData{ X= 2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
        new ChartData{ X= 2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
        new ChartData{ X= 2003, Y= 1, Y1= 0.09, Y2= 0.61 },
        new ChartData{ X= 2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
        new ChartData{ X= 2005, Y= 1.47, Y1= 0.20, Y2= 0.64 },
        new ChartData{ X= 2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
        new ChartData{ X= 2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
        new ChartData{ X= 2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
        new ChartData{ X= 2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BXVfjFsEJyUoObkx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Opacity**

The [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Opacity) property controls the transparency of the series [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartDataList" XName="X" YName="Y" Fill="red" Opacity="0.5" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100" />
        <ChartSeries DataSource="@ChartDataList" XName="X" YName="Y1" Fill="blue" Opacity="0.5" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100" />
        <ChartSeries DataSource="@ChartDataList" XName="X" YName="Y2" Fill="green" Opacity="0.5" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100" />
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
    }

    public List<ChartData> ChartDataList = new List<ChartData>
    {
        new ChartData{ X= 2000, Y= 0.61, Y1= 0.03, Y2= 0.48 },
        new ChartData{ X= 2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
        new ChartData{ X= 2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
        new ChartData{ X= 2003, Y= 1, Y1= 0.09, Y2= 0.61 },
        new ChartData{ X= 2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
        new ChartData{ X= 2005, Y= 1.47, Y1= 0.20, Y2= 0.64 },
        new ChartData{ X= 2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
        new ChartData{ X= 2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
        new ChartData{ X= 2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
        new ChartData{ X= 2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LXhpZFskTeJApMPq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**DashArray**

The [DashArray](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DashArray) property defines the dash pattern of the series border. Provide a comma-separated sequence of lengths (for example, "5,5") to render dashed outlines.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartDataList" XName="X" YName="Y" Fill="pink" Opacity="0.7" DashArray="5,5" Type="ChartSeriesType.StackingArea100">
            <ChartSeriesBorder Width="2" Color="black"></ChartSeriesBorder>
        </ChartSeries>
        <ChartSeries DataSource="@ChartDataList" XName="X" YName="Y1" Fill="blue" Opacity="0.7" DashArray="5,5" Type="ChartSeriesType.StackingArea100">
            <ChartSeriesBorder Width="2" Color="black"></ChartSeriesBorder>
        </ChartSeries>
        <ChartSeries DataSource="@ChartDataList" XName="X" YName="Y2" Fill="green" Opacity="0.7" DashArray="5,5" Type="ChartSeriesType.StackingArea100">
            <ChartSeriesBorder Width="2" Color="black"></ChartSeriesBorder>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
    }
	
    public List<ChartData> ChartDataList = new List<ChartData>
	{
          new ChartData{ X= 2000, Y= 0.61, Y1= 0.03, Y2= 0.48 },
          new ChartData{ X= 2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
          new ChartData{ X= 2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
          new ChartData{ X= 2003, Y= 1, Y1= 0.09, Y2= 0.61 },
          new ChartData{ X= 2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
          new ChartData{ X= 2005, Y= 1.47, Y1= 0.20, Y2= 0.64 },
          new ChartData{ X= 2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
          new ChartData{ X= 2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
          new ChartData{ X= 2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
          new ChartData{ X= 2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/LtLpNvCEpoorqjBb?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Series Border**

The [ChartSeriesBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesBorder.html) property configures the border of the series area. Use [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesBorder.html#Syncfusion_Blazor_Charts_ChartSeriesBorder_Color) and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesBorder.html#Syncfusion_Blazor_Charts_ChartSeriesBorder_Width) to emphasize boundaries.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartDataList" XName="X" YName="Y" Fill="pink"  Type="ChartSeriesType.StackingArea100">
            <ChartSeriesBorder Width="2" Color="black"></ChartSeriesBorder>
        </ChartSeries>
        <ChartSeries DataSource="@ChartDataList" XName="X" YName="Y1" Fill="blue" Type="ChartSeriesType.StackingArea100">
            <ChartSeriesBorder Width="2" Color="black"></ChartSeriesBorder>
        </ChartSeries>
        <ChartSeries DataSource="@ChartDataList" XName="X" YName="Y2" Fill="green" Type="ChartSeriesType.StackingArea100">
            <ChartSeriesBorder Width="2" Color="black"></ChartSeriesBorder>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
    }
	
    public List<ChartData> ChartDataList = new List<ChartData>
	{
        new ChartData{ X= 2000, Y= 0.61, Y1= 0.03, Y2= 0.48},
        new ChartData{ X= 2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
        new ChartData{ X= 2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
        new ChartData{ X= 2003, Y= 1, Y1= 0.09, Y2= 0.61 },
        new ChartData{ X= 2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
        new ChartData{ X= 2005, Y= 1.47, Y1= 0.20, Y2= 0.64 },
        new ChartData{ X= 2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
        new ChartData{ X= 2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
        new ChartData{ X= 2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
        new ChartData{ X= 2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/LZBoZEBzhesBgrhE?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Empty points

Data points with `null`, `double.NaN` or `undefined` values are considered empty. Empty data points are ignored and not plotted on the chart.

**Mode**

Use the [`Mode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Mode) property to define how empty or missing points are handled. The default mode is [`Gap`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.EmptyPointMode.html#Syncfusion_Blazor_Charts_EmptyPointMode_Gap).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Family Expense for Month">
    <ChartPrimaryXAxis LabelRotation="90" ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Average"></ChartEmptyPointSettings>
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y1" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Gap"></ChartEmptyPointSettings>
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y3" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }
    }

    public List<ChartData> ExpenseReports = new List<ChartData>
    {
        new ChartData { X= "Food" , Y= 90, Y1= 40 , Y2= 70, Y3= 120 },
        new ChartData { X= "Transport", Y= 80, Y1= 90, Y2= 110, Y3= 70 },
        new ChartData { X= "Medical", Y= 50, Y1= 80, Y2= 120, Y3= 50 },
        new ChartData { X= "Clothes", Y= 70, Y1 = 30, Y2= 60, Y3= 180 },
        new ChartData { X= "Personal Care", Y= 30, Y1 = 80, Y2= 80, Y3= 30 },
        new ChartData { X= "Books", Y= double.NaN, Y1= 40, Y2= double.NaN, Y3= 270 },
        new ChartData { X= "Fitness", Y= 100, Y1= 30, Y2= 70, Y3= 40 },
        new ChartData { X= "Electricity", Y= 55, Y1= 95, Y2= 55, Y3= 75 },
        new ChartData { X= "Tax", Y= 20, Y1= 50, Y2= 40, Y3= 65 },
        new ChartData { X= "Pet Care", Y= 40, Y1= 20, Y2= 80, Y3= 95 },
        new ChartData { X= "Education", Y= 45, Y1= 15, Y2= 45, Y3= 195 },
        new ChartData { X= "Entertainment", Y= 75, Y1= 45, Y2= 65, Y3= 115 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hNrTZECqgmjYQlyI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Fill**

Use the [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Fill) property to customize the fill color of empty points.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Family Expense for Month">
    <ChartPrimaryXAxis LabelRotation="90" ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Average" Fill="red"></ChartEmptyPointSettings>
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y1" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Gap"></ChartEmptyPointSettings>
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y3" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }
    }

    public List<ChartData> ExpenseReports = new List<ChartData>
    {
        new ChartData { X= "Food" , Y= 90, Y1= 40 , Y2= 70, Y3= 120 },
        new ChartData { X= "Transport", Y= 80, Y1= 90, Y2= 110, Y3= 70 },
        new ChartData { X= "Medical", Y= 50, Y1= 80, Y2= 120, Y3= 50 },
        new ChartData { X= "Clothes", Y= 70, Y1 = 30, Y2= 60, Y3= 180 },
        new ChartData { X= "Personal Care", Y= 30, Y1 = 80, Y2= 80, Y3= 30 },
        new ChartData { X= "Books", Y= double.NaN, Y1= 40, Y2= double.NaN, Y3= 270 },
        new ChartData { X= "Fitness", Y= 100, Y1= 30, Y2= 70, Y3= 40 },
        new ChartData { X= "Electricity", Y= 55, Y1= 95, Y2= 55, Y3= 75 },
        new ChartData { X= "Tax", Y= 20, Y1= 50, Y2= 40, Y3= 65 },
        new ChartData { X= "Pet Care", Y= 40, Y1= 20, Y2= 80, Y3= 95 },
        new ChartData { X= "Education", Y= 45, Y1= 15, Y2= 45, Y3= 195 },
        new ChartData { X= "Entertainment", Y= 75, Y1= 45, Y2= 65, Y3= 115 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rZLfjOMAKcWwKCGj?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Border**

Use the [`Border`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Border) property to customize the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointBorder.html#Syncfusion_Blazor_Charts_ChartEmptyPointBorder_Width) and [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointBorder.html#Syncfusion_Blazor_Charts_ChartEmptyPointBorder_Color) of empty-point borders.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Family Expense for Month">
    <ChartPrimaryXAxis LabelRotation="90" ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Average" Fill="red">
                <ChartEmptyPointBorder Color="green" Width="2"></ChartEmptyPointBorder>
            </ChartEmptyPointSettings>
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y1" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Gap"></ChartEmptyPointSettings>
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" DataSource="@ExpenseReports" YName="Y3" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartMarker Visible="true"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }
    }

    public List<ChartData> ExpenseReports = new List<ChartData>
    {
        new ChartData { X= "Food" , Y= 90, Y1= 40 , Y2= 70, Y3= 120 },
        new ChartData { X= "Transport", Y= 80, Y1= 90, Y2= 110, Y3= 70 },
        new ChartData { X= "Medical", Y= 50, Y1= 80, Y2= 120, Y3= 50 },
        new ChartData { X= "Clothes", Y= 70, Y1 = 30, Y2= 60, Y3= 180 },
        new ChartData { X= "Personal Care", Y= 30, Y1 = 80, Y2= 80, Y3= 30 },
        new ChartData { X= "Books", Y= double.NaN, Y1= 40, Y2= double.NaN, Y3= 270 },
        new ChartData { X= "Fitness", Y= 100, Y1= 30, Y2= 70, Y3= 40 },
        new ChartData { X= "Electricity", Y= 55, Y1= 95, Y2= 55, Y3= 75 },
        new ChartData { X= "Tax", Y= 20, Y1= 50, Y2= 40, Y3= 65 },
        new ChartData { X= "Pet Care", Y= 40, Y1= 20, Y2= 80, Y3= 95 },
        new ChartData { X= "Education", Y= 45, Y1= 15, Y2= 45, Y3= 195 },
        new ChartData { X= "Entertainment", Y= 75, Y1= 45, Y2= 65, Y3= 115 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BjVpNasqqwTjdxmq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Stack labels

Stack labels display cumulative totals for each stack directly as data labels. If all values in a stack segment are negative, the label is displayed below the point.

The [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelSettings.html#Syncfusion_Blazor_Charts_ChartStackLabelSettings_Visible) property of [ChartStackLabelSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelSettings.html) enables stack labels when set to **true**.

```cshtml
@using Syncfusion.Blazor.Charts

<SfChart>

    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartDataList" XName="X" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartSeriesAnimation Enable="false" />
            <ChartMarker Visible="true"><ChartDataLabel Visible="true" /></ChartMarker>
        </ChartSeries>
        <ChartSeries DataSource="@ChartDataList" XName="X" YName="Y1" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartSeriesAnimation Enable="false" />
            <ChartMarker Visible="true"><ChartDataLabel Visible="true" /></ChartMarker>
        </ChartSeries>
        <ChartSeries DataSource="@ChartDataList" XName="X" YName="Y2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartSeriesAnimation Enable="false" />
            <ChartMarker Visible="true"><ChartDataLabel Visible="true" /></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>

    <ChartStackLabelSettings Visible="true"></ChartStackLabelSettings>
</SfChart>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
    }

    public List<ChartData> ChartDataList = new List<ChartData>
    {
        new ChartData{ X= 2000, Y= 0.61, Y1= 0.03, Y2= 0.48 },
        new ChartData{ X= 2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
        new ChartData{ X= 2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
        new ChartData{ X= 2003, Y= 1, Y1= 0.09, Y2= 0.61 },
        new ChartData{ X= 2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
        new ChartData{ X= 2005, Y= 1.47, Y1= 0.20, Y2= 0.64 },
        new ChartData{ X= 2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
        new ChartData{ X= 2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
        new ChartData{ X= 2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
        new ChartData{ X= 2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXByDxrngYpMFkxd?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Customization

Stack labels can be customized using `ChartStackLabelSettings`:

* [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelSettings.html#Syncfusion_Blazor_Charts_ChartStackLabelSettings_Fill) - Specifies the background color of the stack labels when border is set. The default value is **transparent**.
* [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelSettings.html#Syncfusion_Blazor_Charts_ChartStackLabelSettings_Format) - Specifies the format of the stack labels. It supports a placeholder `{value}` which will be replaced by the stack label value.
* [Rx](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelSettings.html#Syncfusion_Blazor_Charts_ChartStackLabelSettings_Rx) - Specifies the rounded corner radius along the X-axis (horizontal direction) for the stack label background. The default value is **5**.
* [Ry](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelSettings.html#Syncfusion_Blazor_Charts_ChartStackLabelSettings_Ry) - Specifies the rounded corner radius along the Y-axis (vertical direction) for the stack label background. The default value is **5**.
* [Angle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelSettings.html#Syncfusion_Blazor_Charts_ChartStackLabelSettings_Angle) - Specifies the rotation angle for stack labels in degrees. The default value is **0**.

Font customization for stack labels uses [ChartStackLabelFont](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelFont.html):

* [TextAlignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelFont.html#Syncfusion_Blazor_Charts_ChartStackLabelFont_TextAlignment) - Specifies the alignment of the text within the stack label.
* [FontFamily](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelFont.html#Syncfusion_Blazor_Charts_ChartStackLabelFont_FontFamily) - Specifies the font family for the stack label text.
* [Size](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelFont.html#Syncfusion_Blazor_Charts_ChartStackLabelFont_Size) - Specifies the font size of the stack label text.
* [FontStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDefaultFont.html#Syncfusion_Blazor_Charts_ChartDefaultFont_FontStyle) - Specifies the font style of the stack label text.
* [FontWeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelFont.html#Syncfusion_Blazor_Charts_ChartStackLabelFont_FontWeight) - Specifies the font weight of the stack label text.
* [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelFont.html#Syncfusion_Blazor_Charts_ChartStackLabelFont_Color) - Specifies the color of the stack label text.

Border customization uses [ChartStackLabelBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelBorder.html):

* [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelBorder.html#Syncfusion_Blazor_Charts_ChartStackLabelBorder_Width) - Specifies the width of the border around the stack label.
* [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDefaultBorder.html#Syncfusion_Blazor_Charts_ChartDefaultBorder_Color) - Specifies the color of the border around the stack label.

 To customize the margin, we can use the [ChartStackLabelMargin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelMargin.html) properties as given below:

* [Bottom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelMargin.html#Syncfusion_Blazor_Charts_ChartStackLabelMargin_Bottom) - Specifies the bottom margin of the stack label.
* [Top](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelMargin.html#Syncfusion_Blazor_Charts_ChartStackLabelMargin_Top) - Specifies the top margin of the stack label.
* [Right](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelMargin.html#Syncfusion_Blazor_Charts_ChartStackLabelMargin_Right) - Specifies the right margin of the stack label.
* [Left](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStackLabelMargin.html#Syncfusion_Blazor_Charts_ChartStackLabelMargin_Left) - Specifies the left margin of the stack label.

```cshtml
@using Syncfusion.Blazor.Charts

<SfChart Title="Stacked Area 100% with Stack labels">

    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartDataList" XName="X" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartSeriesAnimation Enable="false" />
            <ChartMarker Visible="true"><ChartDataLabel Visible="true" /></ChartMarker>
        </ChartSeries>
        <ChartSeries DataSource="@ChartDataList" XName="X" YName="Y1" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartSeriesAnimation Enable="false" />
            <ChartMarker Visible="true"><ChartDataLabel Visible="true" /></ChartMarker>
        </ChartSeries>
        <ChartSeries DataSource="@ChartDataList" XName="X" YName="Y2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartSeriesAnimation Enable="false" />
            <ChartMarker Visible="true"><ChartDataLabel Visible="true" /></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>

    <ChartStackLabelSettings Visible="true" Format="{value}" Fill="#ADD8E6" Rx="10" Ry="10" Angle="35">
        <ChartStackLabelFont TextAlignment="Syncfusion.Blazor.Charts.Alignment.Center" FontFamily="Roboto" Size="12px" FontStyle="bold" FontWeight="600" Color="blue" />
        <ChartStackLabelBorder Width="2" Color="#000000" />
        <ChartStackLabelMargin Bottom="10" Top="10" Right="10" Left="10" />
    </ChartStackLabelSettings>
</SfChart>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
    }

    public List<ChartData> ChartDataList = new List<ChartData>
    {
        new ChartData{ X= 2000, Y= 0.61, Y1= 0.03, Y2= 0.48 },
        new ChartData{ X= 2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
        new ChartData{ X= 2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
        new ChartData{ X= 2003, Y= 1, Y1= 0.09, Y2= 0.61 },
        new ChartData{ X= 2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
        new ChartData{ X= 2005, Y= 1.47, Y1= 0.20, Y2= 0.64 },
        new ChartData{ X= 2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
        new ChartData{ X= 2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
        new ChartData{ X= 2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
        new ChartData{ X= 2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BNBSZxVnqOcrRgBw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Events

### Series render

The [`OnSeriesRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnSeriesRender) event allows customization of series properties such as [Data](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Data), [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Fill), and [Series](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Series) before rendering.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
    <ChartEvents OnSeriesRender="SeriesRender"></ChartEvents>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartDataList" XName="X" Name="Series1" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100" />
        <ChartSeries DataSource="@ChartDataList" XName="X" Name="Series2" YName="Y1" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100" />
        <ChartSeries DataSource="@ChartDataList" XName="X" Name="Series3" YName="Y2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100" />
    </ChartSeriesCollection>
    <ChartLegendSettings Visible="false"></ChartLegendSettings>
</SfChart>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
    }

    public void SeriesRender(SeriesRenderEventArgs args)
    {
       if (args.Series.Name == "Series1")
       {
           args.Fill = "red";
       }
       else if (args.Series.Name == "Series2")
       {
           args.Fill = "green";
       }
       else if (args.Series.Name == "Series3")
       {
           args.Fill = "blue";
       }
    }

    public List<ChartData> ChartDataList = new List<ChartData>
    {
        new ChartData{ X= 2000, Y= 0.61, Y1= 0.03, Y2= 0.48 },
        new ChartData{ X= 2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
        new ChartData{ X= 2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
        new ChartData{ X= 2003, Y= 1, Y1= 0.09, Y2= 0.61 },
        new ChartData{ X= 2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
        new ChartData{ X= 2005, Y= 1.47, Y1= 0.20, Y2= 0.64 },
        new ChartData{ X= 2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
        new ChartData{ X= 2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
        new ChartData{ X= 2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
        new ChartData{ X= 2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDhztliaTolOBJmw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Point render

The [`OnPointRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnPointRender) event customizes individual data points before they are rendered.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
    <ChartEvents OnPointRender="PointRender"></ChartEvents>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ChartDataList" XName="X" Name="Series1" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartMarker Visible="true" Height="10" Width="10" />    
        </ChartSeries>
        <ChartSeries DataSource="@ChartDataList" XName="X" Name="Series2" YName="Y1" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartMarker Visible="true" Height="10" Width="10" />
        </ChartSeries>
        <ChartSeries DataSource="@ChartDataList" XName="X" Name="Series3" YName="Y2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartMarker Visible="true" Height="10" Width="10" />
        </ChartSeries>
    </ChartSeriesCollection>
    <ChartLegendSettings Visible="false"></ChartLegendSettings>
</SfChart>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
    }

    public void PointRender(PointRenderEventArgs args)
    {
        args.Fill = (args.Point.Index % 2 != 0) ? "#ff6347" : "#009cb8";
    }

    public List<ChartData> ChartDataList = new List<ChartData>
    {
        new ChartData{ X= 2000, Y= 0.61, Y1= 0.03, Y2= 0.48 },
        new ChartData{ X= 2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
        new ChartData{ X= 2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
        new ChartData{ X= 2003, Y= 1, Y1= 0.09, Y2= 0.61 },
        new ChartData{ X= 2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
        new ChartData{ X= 2005, Y= 1.47, Y1= 0.20, Y2= 0.64 },
        new ChartData{ X= 2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
        new ChartData{ X= 2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
        new ChartData{ X= 2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
        new ChartData{ X= 2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LXLTXuCUUmeoHyRh?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> Refer to the [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for an overview of features, and explore the [Blazor Chart example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) for additional chart types and time-dependent data visualization.

## See also

* [Data label](../data-labels)
* [Tooltip](../tool-tip)
