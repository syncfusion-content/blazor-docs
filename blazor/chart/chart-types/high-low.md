---
layout: post
title: Blazor Hilo Chart Examples and Documentation | Syncfusion®
description: Learn how to render Blazor Hilo Charts using Syncfusion. Plot stock high and low price movements over time for each data point.
platform: Blazor
control: Charts
documentation: ug
---

# Hilo Chart in Blazor

## Hilo

The [Hilo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Hilo) series illustrates stock price movements using the high and low values for each data point. To render a Hilo series, set the series [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Type) to [Hilo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Hilo) and map the [`High`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_High) and [`Low`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Low) properties to numeric fields on the data model. The high value represents the maximum price and the low value represents the minimum price for each data point.

A detailed demonstration of the process for creating a Hilo chart using Blazor Charts is presented in the video below.

{% youtube "youtube:https://www.youtube.com/watch?v=KDOI77kV34Q" %}


N> **Troubleshooting:** If the chart does not render, verify that the data model has both `High` and `Low` numeric fields and that each is mapped to the corresponding `ChartSeries` property. The X-axis `ValueType` must be `Category` (or `DateTime`/`DateTimeCategory`).

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/hZhxZdsozWHsAlYC?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Hilo Chart](../images/financial-types/blazor-hilo-chart.webp)" %}

N> Refer to the [Blazor Hilo Chart](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/hilo-chart) feature tour page to know about its other groundbreaking feature representations and also explore the [Blazor Hilo Chart Example](https://blazor.syncfusion.com/demos/chart/hilo?theme=fluent2) to know how to render and configure the Hilo type series.

## Binding data with series

You can bind data to the chart using the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) property within the series configuration. The [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) value can be set using either [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) property values or a list of business objects. More information on data binding is available in [Working with data](../working-with-data). To display the data correctly, map the fields from the data to the chart series' [`XName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_XName), [`High`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_High), and [`Low`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Low) properties.

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/VjVxtRiyTsxJclLp?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Series customization

The following properties can be used to customize the [Hilo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Hilo) series.

**Fill**

The [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) property determines the color applied to the series.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@StockDetails" XName="X" High="High" Low="Low" Fill="blue" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Hilo">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class Data
    {
        public string X { get; set; }
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
{% previewsample "https://blazorplayground.syncfusion.com/embed/VjrdNnCeTMnGqkcP?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

The [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) property can also apply a gradient color to the Hilo series. By configuring this property with gradient values, the color transitions smoothly from one shade to another.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@StockDetails" XName="X" High="High" Low="Low" Fill="url(#grad1)" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Hilo">
        </ChartSeries>
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

@code {
    public class Data
    {
        public string X { get; set; }
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
{% previewsample "https://blazorplayground.syncfusion.com/embed/hNrxNniozMGZWtxz?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

**Opacity**

The [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Opacity) property sets the transparency of the [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) color. Accepts a value between `0` (fully transparent) and `1` (fully opaque).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@StockDetails" XName="X" High="High" Low="Low" Fill="blue" Opacity="0.5" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Hilo">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>


@code {
    public class Data
    {
        public string X { get; set; }
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
{% previewsample "https://blazorplayground.syncfusion.com/embed/hDVRtHCoJMwKKiLF?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Empty points

Data points with `null`, `double.NaN`, or `undefined` values are considered empty. Empty data points are ignored and not plotted on the chart.

**Mode**

Use the [`Mode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Mode) property to define how empty or missing data points are handled in the series. The default mode for empty points is [`Gap`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.EmptyPointMode.html#Syncfusion_Blazor_Charts_EmptyPointMode_Gap).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@StockDetails" XName="X" High="High" Low="Low" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Hilo">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Gap"></ChartEmptyPointSettings>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class Data
    {
        public string X { get; set; }
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
        new Data{ X= "June",Low= double.NaN, High= double.NaN },
        new Data{ X= "Jul", Low= 77, High=150 },
        new Data{ X= "Aug", Low= 54, High= 125 },
        new Data{ X= "Sep", Low= 60, High= 155 },
        new Data{ X= "Oct", Low= 60, High= 180 },
        new Data{ X= "Nov", Low= 88, High= 180 },
        new Data{ X= "Dec", Low= 84, High= 230 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hNBdDxMoJMGRJTSn?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

**Fill**

Use the [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Fill) property to customize the fill color of empty points in the series.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@StockDetails" XName="X" High="High" Low="Low" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Hilo">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Average" Fill="#FFDE59"></ChartEmptyPointSettings>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>


@code {
    public class Data
    {
        public string X { get; set; }
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
        new Data{ X= "June",Low= double.NaN, High= double.NaN },
        new Data{ X= "Jul", Low= 77, High=150 },
        new Data{ X= "Aug", Low= 54, High= 125 },
        new Data{ X= "Sep", Low= 60, High= 155 },
        new Data{ X= "Oct", Low= 60, High= 180 },
        new Data{ X= "Nov", Low= 88, High= 180 },
        new Data{ X= "Dec", Low= 84, High= 230 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXrHXdCIfiQEAddE?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Events

### Series render

The [`OnSeriesRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnSeriesRender) event allows you to customize series properties, such as [Data](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Data), [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Fill), and [Series](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Series), before they are rendered on the chart.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
    <ChartEvents OnSeriesRender="SeriesRender"></ChartEvents>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@StockDetails" XName="X" High="High" Low="Low" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Hilo" />
    </ChartSeriesCollection>
</SfChart>

@code {
    public class Data
    {
        public string X { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
    }

    public void SeriesRender(SeriesRenderEventArgs args)
    {
        args.Fill = "#FF4081";
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
{% previewsample "https://blazorplayground.syncfusion.com/embed/LtBRNxCIfWvrJFiT?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

### Point render

The [`OnPointRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnPointRender) event allows you to customize each data point before it is rendered on the chart.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
    <ChartEvents OnPointRender="PointRender"></ChartEvents>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@StockDetails" XName="X" High="High" Low="Low" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Hilo" />
    </ChartSeriesCollection>
</SfChart>

@code {
    public class Data
    {
        public string X { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
    }

    public void PointRender(PointRenderEventArgs args)
    {
        args.Fill = args.Point.X.ToString() == "June" ? "#E91E63" : "#3F51B5";
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
{% previewsample "https://blazorplayground.syncfusion.com/embed/LXrHNxWofWPJmGDm?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

N> Refer to the [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and explore the [Blazor Hilo Chart Example](https://blazor.syncfusion.com/demos/chart/hilo?theme=fluent2) to learn how the chart visualizes stock price high and low values.

## See also

* [Hilo Open Close](./high-low-open-close)
* [Candle](./candle)
* [Data Label](../data-labels)
* [Tooltip](../tool-tip)
* [Data Marker](../data-markers)
* [Legend](../legend)