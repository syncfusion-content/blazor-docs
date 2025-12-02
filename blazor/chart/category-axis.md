---
layout: post
title: Category Axis in Blazor Charts Component | Syncfusion
description: Checkout and learn here all about Category Axis in Syncfusion Blazor Charts component and much more.
platform: Blazor
control: Chart
documentation: ug
---

# Category Axis in Blazor Charts Component

The category axis is used to represent string values instead of integers.

You can learn how to customize the category axis by watching the video below.

{% youtube "youtube:https://www.youtube.com/watch?v=Mv6MS6fbcNE" %}

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="YValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> MedalDetails = new List<ChartData>
	{
        new ChartData { X= "USA", YValue= 46 },
        new ChartData { X= "GBR", YValue= 27 },
        new ChartData { X= "CHN", YValue= 26 },
        new ChartData { X= "UK", YValue= 23 },
        new ChartData { X= "AUS", YValue= 16 },
        new ChartData { X= "IND", YValue= 36 },
        new ChartData { X= "DEN", YValue= 12 },
        new ChartData { X= "MEX", YValue= 20 },
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rZLgWrhVAEwCkOWl?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Column Chart with Default Axis](images/category-axis/blazor-chart-default-axis.png)" %}

## Labels placement

The category labels are positioned between ticks by default, but the [LabelPlacement](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_LabelPlacement) property allows them to be placed on the ticks as well. The available options are [BetweenTicks](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LabelPlacement.html#Syncfusion_Blazor_Charts_LabelPlacement_BetweenTicks) (default) and [OnTicks](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LabelPlacement.html#Syncfusion_Blazor_Charts_LabelPlacement_OnTicks).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis LabelPlacement="LabelPlacement.OnTicks" ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="YValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double YValue { get; set; }
    }
	
    public List<ChartData> MedalDetails = new List<ChartData>
	{
        new ChartData { X= "USA", YValue= 46 },
        new ChartData { X= "GBR", YValue= 27 },
        new ChartData { X= "CHN", YValue= 26 },
        new ChartData { X= "UK", YValue= 23 },
        new ChartData { X= "AUS", YValue= 16 },
        new ChartData { X= "IND", YValue= 36 },
        new ChartData { X= "DEN", YValue= 12 },
        new ChartData { X= "MEX", YValue= 20 },
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rtLgWVrBgOQpAjdB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Changing Labels Position in Blazor Chart](images/category-axis/blazor-diagram-label-position.png)" %}

## Range and interval

The [Minimum](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_Minimum), [Maximum](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_Maximum), and [Interval](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_Interval) properties can be used to customize the range of the [Category](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ValueType.html#Syncfusion_Blazor_Charts_ValueType_Category) axis.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis Maximum="5" Minimum="1" Interval="2" ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="X" YName="YValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double YValue { get; set; }
    }
	
    public List<ChartData> MedalDetails = new List<ChartData>
	{
        new ChartData { X= "USA", YValue= 46 },
        new ChartData { X= "GBR", YValue= 27 },
        new ChartData { X= "CHN", YValue= 26 },
        new ChartData { X= "UK", YValue= 23 },
        new ChartData { X= "AUS", YValue= 16 },
        new ChartData { X= "IND", YValue= 36 },
        new ChartData { X= "DEN", YValue= 12 },
        new ChartData { X= "MEX", YValue= 20 },
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LXLqWrrhTtLJCSXT?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Changing Blazor Column Chart Axis based on Range and Interval](images/category-axis/blazor-chart-axis-range-and-interval.png)" %}

## Indexed category axis

The category axis can also be rendered using the data source index values. This can be achieved by setting the [IsIndexed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_IsIndexed) property in the axis to **true**.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis IsIndexed="true" ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReports1" XName="X" YName="Y" Type="ChartSeriesType.Column">
        </ChartSeries>
        <ChartSeries DataSource="@WeatherReports2" XName="X" YName="Y" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class WeatherData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public List<WeatherData> WeatherReports1 = new List<WeatherData>
	{
        new WeatherData{ X= "Myanmar", Y= 7.3 },
        new WeatherData{ X= "India", Y= 7.9 },
        new WeatherData{ X= "Bangladesh", Y= 6.8 },
        new WeatherData{ X= "Cambodia", Y=7.0 },
        new WeatherData{ X= "China", Y= 6.9 }
    };

    public List<WeatherData> WeatherReports2 = new List<WeatherData>
	{
        new WeatherData{ X= "Poland", Y=2.7 },
        new WeatherData{ X= "Australia", Y=2.5 },
        new WeatherData{ X= "Singapore", Y=2.0 },
        new WeatherData{ X= "Canada", Y=1.4 },
        new WeatherData{ X= "Germany", Y=1.8 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hjVAiVrVTDrcDBLL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Chart with Indexed Category Axis](images/category-axis/blazor-chart-index-category-axis.png)" %}

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to knows various chart types and how to represent time-dependent data, showing trends in data at equal intervals.

## See also

* [Data Label](./data-labels)
* [Tooltip](./tool-tip)
* [Marker](./data-markers)
* [Sort Series Points on Category Axis](https://support.syncfusion.com/kb/article/21383/how-to-sort-series-points-on-category-axis-in-blazor-chart-component)