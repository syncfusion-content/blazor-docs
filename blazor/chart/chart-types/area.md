---
layout: post
title: Area in Blazor Charts Component | Syncfusion
description: Checkout and learn here all about the Area Chart in Syncfusion Blazor Charts component and much more.
platform: Blazor
control: Chart
documentation: ug
---

# Area in Blazor Charts Component

## Area

[Area Chart](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/area-chart) is like Line Chart, that represents time-dependent data and shows the trends at equal intervals, but it fills the area below the line. To render an area series, specify the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Type) property as [Area](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Area) and the [ValueType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonAxis.html#Syncfusion_Blazor_Charts_ChartCommonAxis_ValueType) of the plot data can be [Category](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ValueType.html#Syncfusion_Blazor_Charts_ValueType_Category), [DateTime](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ValueType.html#Syncfusion_Blazor_Charts_ValueType_DateTime), [DateTimeCategory](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ValueType.html#Syncfusion_Blazor_Charts_ValueType_DateTimeCategory), [Double](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ValueType.html#Syncfusion_Blazor_Charts_ValueType_Double) or [Logarithmic](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ValueType.html#Syncfusion_Blazor_Charts_ValueType_Logarithmic).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>

    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"/>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y" Type="ChartSeriesType.Area">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }
    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData { X= "South Korea", Y= 39.4 },
        new ChartData { X= "India", Y= 61.3 },
        new ChartData { X= "Pakistan", Y= 20.4 },
        new ChartData { X= "Germany", Y= 65.1 },
        new ChartData { X= "Australia", Y= 15.8 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/BjrUsrVRVybSLVPC?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Area Chart](../images/chart-types-images/blazor-area-chart.png)

N> Refer to our [Blazor Area Charts](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/area-chart) feature tour page to know about its other groundbreaking feature representations. Explore our [Blazor Area Chart Example](https://blazor.syncfusion.com/demos/chart/area?theme=bootstrap4) to know how to represent time-dependent data, showing trends at equal intervals.

## Multicolored area

To render a multicolored area series, specify the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Type) property as [MultiColoredArea](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_MultiColoredArea) in [ChartSeries](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html). Here, the individual color of the segment can be mapped by using the [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSegment.html#Syncfusion_Blazor_Charts_ChartSegment_Color) property in [ChartSegment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSegment.html).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Width="60%">
    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReports" XName="X" YName="Y" Type="ChartSeriesType.MultiColoredArea">
            <ChartSegments>
                <ChartSegment Value="2007" Color="blue"/>
                <ChartSegment Value="2009" Color="red"/>
                <ChartSegment Color="green"></ChartSegment>
            </ChartSegments>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> WeatherReports = new List<ChartData>
	{
        new ChartData{ X= 2005, Y= 28 },
        new ChartData{ X= 2006, Y= 25},
        new ChartData{ X= 2007, Y= 26 },
        new ChartData{ X= 2008, Y= 27 },
        new ChartData{ X= 2009, Y= 32},
        new ChartData{ X= 2010, Y= 35 },
        new ChartData{ X= 2011, Y= 25 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/rNLUirLdBevFgeZv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Multicolored Area Chart](../images/chart-types-images/blazor-multicolor-area-chart.png)

## Series customization

The following properties can be used to customize the [Area](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Area) series.

* [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) – Specifies the color of the area series.
* [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Opacity) – Specifies the opacity of [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill).
* [DashArray](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DashArray) – Specifies the dashes of series.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y" Opacity="0.3" Fill="blue" Type="ChartSeriesType.Area">
            <ChartSeriesBorder Width="0"></ChartSeriesBorder>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData { X= "South Korea", Y= 39.4 },
        new ChartData { X= "India", Y= 61.3 },
        new ChartData { X= "Pakistan", Y= 20.4 },
        new ChartData { X= "Germany", Y= 65.1 },
        new ChartData { X= "Australia", Y= 15.8 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rXrACLrdrokDGazV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Area Chart with Custom Series](../images/chart-types-images/blazor-area-chart-fill.png)

## Area Border

The following properties in the [ChartSeriesBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesBorder.html) can be used to customize the border of the Area Chart.

* [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesBorder.html#Syncfusion_Blazor_Charts_ChartSeriesBorder_Width) - Specifies the width for the border of the Area Chart.
* [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesBorder.html#Syncfusion_Blazor_Charts_ChartSeriesBorder_Color) - Specifies the Color for the border of the Area Chart.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="Y" Opacity="0.5" Type="ChartSeriesType.Area">
            <ChartSeriesBorder Width="2"></ChartSeriesBorder>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData { X= "South Korea", Y= 39.4 },
        new ChartData { X= "India", Y= 61.3 },
        new ChartData { X= "Pakistan", Y= 20.4 },
        new ChartData { X= "Germany", Y= 65.1 },
        new ChartData { X= "Australia", Y= 15.8 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDLKiLVdhnoffMQB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Area Chart with Border](../images/chart-types-images/blazor-area-border.png)

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See also

* [Data Label](../data-labels)
* [Tooltip](../tool-tip)