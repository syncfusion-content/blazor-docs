---
layout: post
title: Scatter Chart in Blazor Charts component | Syncfusion
description: Learn about Scatter in Blazor Chart component of Syncfusion, and more details.
platform: Blazor
control: Chart
documentation: ug
---

# Scatter Chart in Blazor Charts (SfCharts)

## Scatter

[`Scatter Chart`](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/scatter-chart) plots data with two numeric parameters. To render a [`Scatter Chart`](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/scatter-chart), use series [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.Charts.ChartSeries~Type.html) as [`Scatter`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Scatter).

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart DataSource="@MedalDetails">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries XName="X" YName="YValue" Type="ChartSeriesType.Scatter">
        </ChartSeries>
        <ChartSeries XName="X" YName="YValue1" Type="ChartSeriesType.Scatter">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double YValue { get; set; }
        public double YValue1 { get; set; }
    }
    public List<ChartData> MedalDetails = new List<ChartData>
{
        new ChartData { X= "USA", YValue= 46, YValue1=56 },
        new ChartData { X= "GBR", YValue= 27, YValue1=17 },
        new ChartData { X= "CHN", YValue= 26, YValue1=36 },
        new ChartData { X= "UK", YValue= 56,  YValue1=16 },
        new ChartData { X= "AUS", YValue= 12, YValue1=46 },
        new ChartData { X= "IND", YValue= 26, YValue1=16 },
        new ChartData { X= "DEN", YValue= 26, YValue1=12 },
        new ChartData { X= "MEX", YValue= 34, YValue1=32},
    };
}

{% endhighlight %}

![Scatter Charts](../images/chart-types-images/scatter.png)

> Refer to our [`Blazor Scatter Chart`](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/scatter-chart) feature tour page to know about its other groundbreaking feature representations. Explore our [`Blazor Scatter Chart Example`](https://blazor.syncfusion.com/demos/chart/scatter?theme=bootstrap4) to know how to plot data with two numeric parameters.

## Series Customization

The following properties can be used to customize the [`Scatter`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Scatter) series.

* [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) – Specifies the color of the series.
* [`Opacity`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Opacity) – Specifies the opacity of [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill).
* [`Shape`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartShape.html) - Specifies the shape of the scatter series.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart DataSource="@MedalDetails">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries XName="X" YName="YValue" Type="ChartSeriesType.Scatter" Fill="blue" Opacity="0.5">
            <ChartMarker Height="10" Width="10" Shape="ChartShape.Circle">
            </ChartMarker>
        </ChartSeries>
        <ChartSeries XName="X" YName="YValue1" Type="ChartSeriesType.Scatter" Fill="red" Opacity="0.5">
            <ChartMarker Height="10" Width="10" Shape="ChartShape.Diamond">
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double YValue { get; set; }
        public double YValue1 { get; set; }
    }
    public List<ChartData> MedalDetails = new List<ChartData>
	{
        new ChartData { X= "USA", YValue= 46, YValue1=56 },
        new ChartData { X= "GBR", YValue= 27, YValue1=17 },
        new ChartData { X= "CHN", YValue= 26, YValue1=36 },
        new ChartData { X= "UK", YValue= 56,  YValue1=16 },
        new ChartData { X= "AUS", YValue= 12, YValue1=46 },
        new ChartData { X= "IND", YValue= 26, YValue1=16 },
        new ChartData { X= "DEN", YValue= 26, YValue1=12 },
        new ChartData { X= "MEX", YValue= 34, YValue1=32},
    };
}

{% endhighlight %}

![Custom Scatter Charts](../images/chart-types-images/custom-scatter.png)

> Refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See Also

* [Data Label](../data-labels)
* [Tooltip](../tool-tip)