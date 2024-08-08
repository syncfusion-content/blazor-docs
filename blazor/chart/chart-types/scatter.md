---
layout: post
title: Scatter in Blazor Charts Component | Syncfusion
description: Checkout and learn here all about the Scatter Chart in Syncfusion Blazor Charts component and much more.
platform: Blazor
control: Chart
documentation: ug
---

# Scatter in Blazor Charts Component

## Scatter

[Scatter Chart](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/scatter-chart) is used to visualize the relationship between two Cartesian parameters. To render a [Scatter Chart](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/scatter-chart), set the series [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Type) as [Scatter](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Scatter).

```cshtml

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

``` 

![Blazor Scatter Chart](../images/chart-types-images/blazor-scatter-chart.png)

N> Refer to our [Blazor Scatter Chart](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/scatter-chart) feature tour page to know about its other groundbreaking feature representations. Explore our [Blazor Scatter Chart Example](https://blazor.syncfusion.com/demos/chart/scatter?theme=bootstrap4) to know how to plot data with two numeric parameters.

## Series customization

The following properties can be used to customize the [Scatter](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Scatter) series.

* [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) – Specifies the color of the series.
* [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Opacity) – Specifies the opacity of [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill).
* [Shape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartShape.html) - Specifies the shape of the scatter series.

```cshtml

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

``` 

![Blazor Scatter Chart with Custom Series](../images/chart-types-images/blazor-scatter-chart-custom-series.png)

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See also

* [Data Label](../data-labels)
* [Tooltip](../tool-tip)