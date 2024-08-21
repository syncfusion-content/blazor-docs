---
layout: post
title: 100% Stacked Area in Blazor Charts Component | Syncfusion
description: Checkout and learn here all about 100% Stacked Area Chart in Syncfusion Blazor Charts component and more.
platform: Blazor
control: Chart
documentation: ug
---

# 100% Stacked Area in Blazor Charts Component

## 100% Stacked Area Chart

[100% Stacked Area Chart](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/100-stacked-area-chart) displays multiple series of data as stacked areas, ensuring that the cumulative proportion of each stacked element always totals 100%. Hence, the y-axis will always be rendered with the range 0–100%. To render a [100% stacked area](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/100-stacked-area-chart) series in your chart, define the series [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Type) as [`StackingArea100`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_StackingArea100) in your chart configuration. This indicates that the data should be represented as a 100% stacked area chart, where the cumulative values for each data point are expressed as a percentage of the total. This ensures that the sum of all series at each point is always 100%.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"/>
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y" Type="ChartSeriesType.StackingArea100"/>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y1" Type="ChartSeriesType.StackingArea100"/>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y2" Type="ChartSeriesType.StackingArea100"/>
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
	
    public List<ChartData> MedalDetails = new List<ChartData>
	{
        new ChartData{ X=2000, Y= 0.61, Y1= 0.03, Y2= 0.48},
        new ChartData{ X=2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
        new ChartData{ X=2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
        new ChartData{ X=2003, Y= 1, Y1= 0.09, Y2= 0.61 },
        new ChartData{ X=2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
        new ChartData{ X=2005, Y= 1.47, Y1= 0.20, Y2= 0.64 },
        new ChartData{ X=2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
        new ChartData{ X=2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
        new ChartData{ X=2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
        new ChartData{ X=2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/rNBAiVhnTxBScRGk?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Stacked Area100 Chart](../images/chart-types-images/blazor-stacked-area-100-chart.png)

N> Refer to our [Blazor 100% Stacked Area Chart](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/100-stacked-area-chart) feature tour page to know about its other groundbreaking feature representations. Explore our [Blazor 100% Stacked Area Chart Example](https://blazor.syncfusion.com/demos/chart/percent-stacked-area?theme=bootstrap5) to know how to render and configure the 100% Stacked Area type chart.

## Binding data with series

You can bind data to the chart using the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) property within the series configuration. The [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) value can be set using either [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) property values or a list of business objects. More information on data binding can be found [here](https://blazor.syncfusion.com/documentation/chart/working-with-data). To display the data correctly, map the fields from the data to the chart series' [`XName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_XName) and [`YName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_YName) properties.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"/>
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y" Type="ChartSeriesType.StackingArea100"/>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y1" Type="ChartSeriesType.StackingArea100"/>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y2" Type="ChartSeriesType.StackingArea100"/>
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
	
    public List<ChartData> MedalDetails = new List<ChartData>
	{
        new ChartData{ X=2000, Y= 0.61, Y1= 0.03, Y2= 0.48},
        new ChartData{ X=2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
        new ChartData{ X=2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
        new ChartData{ X=2003, Y= 1, Y1= 0.09, Y2= 0.61 },
        new ChartData{ X=2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
        new ChartData{ X=2005, Y= 1.47, Y1= 0.20, Y2= 0.64 },
        new ChartData{ X=2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
        new ChartData{ X=2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
        new ChartData{ X=2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
        new ChartData{ X=2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/rNBAiVhnTxBScRGk?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Series customization

The following properties can be used to customize the [100% Stacked Area](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_StackingArea100) series.

**Fill**

The [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) property determines the color applied to the series.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y" Fill="red" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100" />
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y1" Fill="blue" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100" />
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y2" Fill="green" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100" />
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

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData{ X=2000, Y= 0.61, Y1= 0.03, Y2= 0.48},
        new ChartData{ X=2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
        new ChartData{ X=2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
        new ChartData{ X=2003, Y= 1, Y1= 0.09, Y2= 0.61 },
        new ChartData{ X=2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
        new ChartData{ X=2005, Y= 1.47, Y1= 0.20, Y2= 0.64 },
        new ChartData{ X=2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
        new ChartData{ X=2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
        new ChartData{ X=2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
        new ChartData{ X=2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rjBztPikzoCgUnJJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

The [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) property can be used to apply a gradient color to the 100% stacked area series. By configuring this property with gradient values, you can create a visually appealing effect in which the color transitions smoothly from one shade to another.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y" Fill="url(#grad1)" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100" />
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y1" Fill="url(#grad2)" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100" />
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y2" Fill="url(#grad3)" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100" />
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

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData{ X=2000, Y= 0.61, Y1= 0.03, Y2= 0.48},
        new ChartData{ X=2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
        new ChartData{ X=2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
        new ChartData{ X=2003, Y= 1, Y1= 0.09, Y2= 0.61 },
        new ChartData{ X=2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
        new ChartData{ X=2005, Y= 1.47, Y1= 0.20, Y2= 0.64 },
        new ChartData{ X=2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
        new ChartData{ X=2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
        new ChartData{ X=2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
        new ChartData{ X=2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BXVfjFsEJyUoObkx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Opacity**

The [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Opacity) property specifies the transparency level of the [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill). Adjusting this property allows you to control how opaque or transparent the fill color of the series appears.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y" Fill="red" Opacity="0.5" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100" />
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y1" Fill="blue" Opacity="0.5" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100" />
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y2" Fill="green" Opacity="0.5" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100" />
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

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData{ X=2000, Y= 0.61, Y1= 0.03, Y2= 0.48},
        new ChartData{ X=2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
        new ChartData{ X=2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
        new ChartData{ X=2003, Y= 1, Y1= 0.09, Y2= 0.61 },
        new ChartData{ X=2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
        new ChartData{ X=2005, Y= 1.47, Y1= 0.20, Y2= 0.64 },
        new ChartData{ X=2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
        new ChartData{ X=2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
        new ChartData{ X=2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
        new ChartData{ X=2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LXhpZFskTeJApMPq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**DashArray**

The [DashArray](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DashArray) property determines the dashes of series border.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y" Fill="pink" Opacity="0.7" DashArray="5,5" Type="ChartSeriesType.StackingArea100">
            <ChartSeriesBorder Width="2" Color="black"></ChartSeriesBorder>
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y1" Fill="blue" Opacity="0.7" DashArray="5,5" Type="ChartSeriesType.StackingArea100">
            <ChartSeriesBorder Width="2" Color="black"></ChartSeriesBorder>
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y2" Fill="green" Opacity="0.7" DashArray="5,5" Type="ChartSeriesType.StackingArea100">
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
	
    public List<ChartData> MedalDetails = new List<ChartData>
	{
          new ChartData{ X=2000, Y= 0.61, Y1= 0.03, Y2= 0.48},
          new ChartData{ X=2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
          new ChartData{ X=2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
          new ChartData{ X=2003, Y= 1, Y1= 0.09, Y2= 0.61 },
          new ChartData{ X=2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
          new ChartData{ X=2005, Y= 1.47, Y1= 0.20, Y2= 0.64 },
          new ChartData{ X=2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
          new ChartData{ X=2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
          new ChartData{ X=2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
          new ChartData{ X=2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/LtLpNvCEpoorqjBb?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Series Border**

The [ChartSeriesBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesBorder.html) property determines the [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesBorder.html#Syncfusion_Blazor_Charts_ChartSeriesBorder_Color) and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesBorder.html#Syncfusion_Blazor_Charts_ChartSeriesBorder_Width) of series border.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y" Fill="pink" Opacity="0.7" DashArray="5,5" Type="ChartSeriesType.StackingArea100">
            <ChartSeriesBorder Width="2" Color="black"></ChartSeriesBorder>
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y1" Fill="blue" Opacity="0.7" DashArray="5,5" Type="ChartSeriesType.StackingArea100">
            <ChartSeriesBorder Width="2" Color="black"></ChartSeriesBorder>
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y2" Fill="green" Opacity="0.7" DashArray="5,5" Type="ChartSeriesType.StackingArea100">
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
	
    public List<ChartData> MedalDetails = new List<ChartData>
	{
        new ChartData{ X=2000, Y= 0.61, Y1= 0.03, Y2= 0.48},
        new ChartData{ X=2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
        new ChartData{ X=2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
        new ChartData{ X=2003, Y= 1, Y1= 0.09, Y2= 0.61 },
        new ChartData{ X=2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
        new ChartData{ X=2005, Y= 1.47, Y1= 0.20, Y2= 0.64 },
        new ChartData{ X=2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
        new ChartData{ X=2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
        new ChartData{ X=2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
        new ChartData{ X=2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/LXLAiBrHpHBFoZcx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Stacked Area100 Chart with Custom Series](../images/chart-types-images/blazor-stacked-area-100-custom-series.png)

## Empty points

Data points with `null` or `undefined` values are considered empty. Empty data points are ignored and not plotted on the chart.

**Mode**

Use the [`Mode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Mode) property to define how empty or missing data points are handled in the series. The default mode for empty points is [`Gap`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.EmptyPointMode.html#Syncfusion_Blazor_Charts_EmptyPointMode_Gap).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Gap"></ChartEmptyPointSettings>
            <ChartMarker Visible="true" Height="10" Width="10"></ChartMarker>
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y1"  Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Gap"></ChartEmptyPointSettings>
            <ChartMarker Visible="true" Height="10" Width="10"></ChartMarker>
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Gap"></ChartEmptyPointSettings>
            <ChartMarker Visible="true" Height="10" Width="10"></ChartMarker>
        </ChartSeries>
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

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData{ X=2000, Y= 0.61, Y1= 0.03, Y2= 0.48},
        new ChartData{ X=2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
        new ChartData{ X=2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
        new ChartData{ X=2003, Y= 1, Y1= 0.09, Y2= 0.61 },
        new ChartData{ X=2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
        new ChartData{ X=2005, Y= double.NaN, Y1= double.NaN, Y2= double.NaN },
        new ChartData{ X=2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
        new ChartData{ X=2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
        new ChartData{ X=2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
        new ChartData{ X=2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BtrTjbsYJSxliLTf?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Fill**

Use the [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Fill) property to customize the fill color of empty points in the series.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Average" Fill="blue" ></ChartEmptyPointSettings>
            <ChartMarker Visible="true" Height="10" Width="10"></ChartMarker>
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y1" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Average" Fill="green"></ChartEmptyPointSettings>
            <ChartMarker Visible="true" Height="10" Width="10"></ChartMarker>
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Average" Fill="orange"></ChartEmptyPointSettings>
            <ChartMarker Visible="true" Height="10" Width="10"></ChartMarker>
        </ChartSeries>
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

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData{ X=2000, Y= 0.61, Y1= 0.03, Y2= 0.48},
        new ChartData{ X=2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
        new ChartData{ X=2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
        new ChartData{ X=2003, Y= 1, Y1= 0.09, Y2= 0.61 },
        new ChartData{ X=2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
        new ChartData{ X=2005, Y= double.NaN, Y1= double.NaN, Y2= double.NaN },
        new ChartData{ X=2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
        new ChartData{ X=2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
        new ChartData{ X=2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
        new ChartData{ X=2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rXBpXPsOTymnKvxa?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Border**

Use the [`Border`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Border) property to customize the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointBorder.html#Syncfusion_Blazor_Charts_ChartEmptyPointBorder_Width) and [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointBorder.html#Syncfusion_Blazor_Charts_ChartEmptyPointBorder_Color) of the border for empty points.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Average" Fill="blue" >
                <ChartEmptyPointBorder  Width="2" Color="#FF0000"></ChartEmptyPointBorder>
            </ChartEmptyPointSettings>
            <ChartMarker Visible="true" Height="10" Width="10"></ChartMarker>
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y1" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Average" Fill="green">
                <ChartEmptyPointBorder Width="2" Color="#FF0000"></ChartEmptyPointBorder>
            </ChartEmptyPointSettings>
            <ChartMarker Visible="true" Height="10" Width="10"></ChartMarker>
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Average" Fill="orange">
                <ChartEmptyPointBorder Width="2" Color="#FF0000"></ChartEmptyPointBorder>
            </ChartEmptyPointSettings>
            <ChartMarker Visible="true" Height="10" Width="10"></ChartMarker>
        </ChartSeries>
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

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData{ X=2000, Y= 0.61, Y1= 0.03, Y2= 0.48},
        new ChartData{ X=2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
        new ChartData{ X=2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
        new ChartData{ X=2003, Y= 1, Y1= 0.09, Y2= 0.61 },
        new ChartData{ X=2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
        new ChartData{ X=2005, Y= double.NaN, Y1= double.NaN, Y2= double.NaN },
        new ChartData{ X=2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
        new ChartData{ X=2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
        new ChartData{ X=2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
        new ChartData{ X=2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LZBTjPWOfSbBPtOe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Events

### Series render

The [`OnSeriesRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnSeriesRender) event allows you to customize series properties, such as [Data](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Data), [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Fill), and [Series](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Series), before they are rendered on the chart.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
    <ChartEvents OnSeriesRender="SeriesRender"></ChartEvents>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="X" Name="Series1" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100" />
        <ChartSeries DataSource="@MedalDetails" XName="X" Name="Series2" YName="Y1" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100" />
        <ChartSeries DataSource="@MedalDetails" XName="X" Name="Series3" YName="Y2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100" />
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

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData{ X=2000, Y= 0.61, Y1= 0.03, Y2= 0.48},
        new ChartData{ X=2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
        new ChartData{ X=2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
        new ChartData{ X=2003, Y= 1, Y1= 0.09, Y2= 0.61 },
        new ChartData{ X=2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
        new ChartData{ X=2005, Y= 1.47, Y1= 0.20, Y2= 0.64 },
        new ChartData{ X=2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
        new ChartData{ X=2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
        new ChartData{ X=2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
        new ChartData{ X=2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDhztliaTolOBJmw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Point render

The [`OnPointRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnPointRender) event allows you to customize each data point before it is rendered on the chart.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
    <ChartEvents OnPointRender="PointRender"></ChartEvents>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="X" Name="Series1" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartMarker Visible="true" Height="10" Width="10" />    
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" XName="X" Name="Series2" YName="Y1" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
            <ChartMarker Visible="true" Height="10" Width="10" />
        </ChartSeries>
        <ChartSeries DataSource="@MedalDetails" XName="X" Name="Series3" YName="Y2" Type="Syncfusion.Blazor.Charts.ChartSeriesType.StackingArea100">
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
        args.Fill = args.Point.X.ToString() == "2005" ? "#E91E63" : "#3F51B5";
    }

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData{ X=2000, Y= 0.61, Y1= 0.03, Y2= 0.48},
        new ChartData{ X=2001, Y= 0.81, Y1= 0.05, Y2= 0.53 },
        new ChartData{ X=2002, Y= 0.91, Y1= 0.06, Y2= 0.57 },
        new ChartData{ X=2003, Y= 1, Y1= 0.09, Y2= 0.61 },
        new ChartData{ X=2004, Y= 1.19, Y1= 0.14, Y2= 0.63 },
        new ChartData{ X=2005, Y= 1.47, Y1= 0.20, Y2= 0.64 },
        new ChartData{ X=2006, Y= 1.74, Y1= 0.29, Y2= 0.66 },
        new ChartData{ X=2007, Y= 1.98, Y1= 0.46, Y2= 0.76 },
        new ChartData{ X=2008, Y= 1.99, Y1= 0.64, Y2= 0.77 },
        new ChartData{ X=2009, Y= 1.70, Y1= 0.75, Y2= 0.55 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VjLzNPsaToESIFVt?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See also

* [Data Label](../data-labels)
* [Tooltip](../tool-tip)