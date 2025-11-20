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

[Hilo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Hilo) series illustrates the price movements in stock using the higher and lower values and it can be rendered by specifying the series [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Type) as [Hilo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Hilo).

To learn how to create a Hilo chart, you can watch this video.

{% youtube "youtube:https://www.youtube.com/watch?v=KDOI77kV34Q" %}

This indicates that the data should be represented as a hilo chart, which shows the high and low values for each data point, illustrating price movements in stocks and providing a clear visualization of price ranges. The [Hilo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Hilo) series requires two y-values for each data point, you need to specify both the high and low values. The high value represents the maximum price, while the low value represents the minimum price of the stock.

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/rZrzNPLjzSqgHuAy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Hilo Chart](../images/financial-types/blazor-hilo-chart.png)" %}

N> Refer to our [Blazor Hilo Chart](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/hilo-chart) feature tour page to know about its other groundbreaking feature representations and also explore our [Blazor Hilo Chart Example](https://blazor.syncfusion.com/demos/chart/hilo) to know how to render and configure the Hilo type series.

## Binding data with series

You can bind data to the chart using the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) property within the series configuration. The [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) value can be set using either [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) property values or a list of business objects. More information on data binding can be found [here](../working-with-data). To display the data correctly, map the fields from the data to the chart series' [`XName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_XName), [`High`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_High) and [`Low`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Low) properties.

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/rZrzNPLjzSqgHuAy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/BXBpjPVXpydPcQUK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

The [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) property can be used to apply a gradient color to the hilo series. By configuring this property with gradient values, you can create a visually appealing effect in which the color transitions smoothly from one shade to another.

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/hXrJjvrjpyuiQFNZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Opacity**

The [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Opacity) property specifies the transparency level of the [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill). Adjusting this property allows you to control how opaque or transparent the fill color of the series appears.

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/VDBJXPhtpxNMtCrv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Empty points

Data points with `null`, `double.NaN` or `undefined` values are considered empty. Empty data points are ignored and not plotted on the chart.

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/BNVJtFVjpRrQLAvc?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXhJXvVDTnpBHPCo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/rXLpNvLXpxyGcrgZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

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
{% previewsample "https://blazorplayground.syncfusion.com/embed/hthTXPBZzRmJfCpW?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See also

* [Data Label](../data-labels)
* [Tooltip](../tool-tip)