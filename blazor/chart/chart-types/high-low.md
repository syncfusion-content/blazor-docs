---
layout: post
title: Hilo in Blazor Charts Component | Syncfusion
description: Checkout and learn here all about the Hilo Chart in Syncfusion Blazor Charts component and much more.
platform: Blazor
control: Chart
documentation: ug
---

# Hilo in Blazor Charts Component

## Hilo

[Hilo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Hilo) series illustrates the price movements in stock using the higher and lower values and it can be rendered by specifying the series [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Type) as [Hilo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Hilo). Hilo series requires three fields (XName, High and Low) to show the higher and lower price in the stock.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"/> 

    <ChartSeriesCollection>
        <ChartSeries DataSource="@StockDetails" XName="X" High="High" Low="Low" Type="ChartSeriesType.Hilo">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class Data
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
    }

    public List<Data> StockDetails = new List<Data> 
	{
		new Data{ X= "Jan", Low= 87, High= 200 },
		new Data{ X= "Feb", Low= 45, High= 135 },
		new Data{ X= "Mar", Low= 19, High= 85 },
		new Data{ X= "Apr", Low= 31, High= 108 },
		new Data{ X= "May", Low= 27, High= 80 },
		new Data{ X= "June",Low= 84, High= 130 },
		new Data{ X= "Jul", Low= 77, High=150 },
		new Data{ X= "Aug", Low= 54, High= 125 },
		new Data{ X= "Sep", Low= 60, High= 155 },
		new Data{ X= "Oct", Low= 60, High= 180 },
		new Data{ X= "Nov", Low= 88, High= 180 },
		new Data{ X= "Dec", Low= 84, High= 230 }
	};
}

``` 

![Blazor Hilo Chart](../images/financial-types/blazor-hilo-chart.png)

N> Refer to our [Blazor Hilo Chart](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/hilo-chart) feature tour page to know about its other groundbreaking feature representations and also explore our [Blazor Hilo Chart Example](https://blazor.syncfusion.com/demos/chart/hilo) to know how to render and configure the Hilo type series.

## Series customization

The following properties can be used to customize the [Hilo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Hilo) series.

* [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) – Specifies the color of the series.
* [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Opacity) – Specifies the opacity of [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@StockDetails" XName="X" High="High" Low="Low" Fill="blue" Type="ChartSeriesType.Hilo">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class Data
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
    }

    public List<Data> StockDetails = new List<Data> 
    {
        new Data{ X= "Jan", Low= 87, High= 200 },
        new Data{ X= "Feb", Low= 45, High= 135 },
        new Data{ X= "Mar", Low= 19, High= 85 },
        new Data{ X= "Apr", Low= 31, High= 108 },
        new Data{ X= "May", Low= 27, High= 80 },
        new Data{ X= "June",Low= 84, High= 130 },
        new Data{ X= "Jul", Low= 77, High=150 },
        new Data{ X= "Aug", Low= 54, High= 125 },
        new Data{ X= "Sep", Low= 60, High= 155 },
        new Data{ X= "Oct", Low= 60, High= 180 },
        new Data{ X= "Nov", Low= 88, High= 180 },
        new Data{ X= "Dec", Low= 84, High= 230 }
    };
}

```

![Blazor Hilo Chart with Custom Series](../images/chart-types-images/blazor-hilo-chart-custom-series.png)

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See Also

* [Data Label](../data-labels)
* [Tooltip](../tool-tip)