---
layout: post
title: Hilo Chart in Blazor Charts Component | Syncfusion
description: Check out and learn how to configure and customize the Hilo Chart in Syncfusion Blazor Charts component.
platform: Blazor
control: Chart
documentation: ug
---

# Hilo Chart in Blazor Charts Component

## Hilo Chart

The [Hilo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Hilo) series illustrates price movements in stocks using higher and lower values. Render the series by setting the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Type) to [Hilo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Hilo).

Learn how to create a Hilo chart using Blazor Charts by watching the following video.

{% youtube "youtube:https://www.youtube.com/watch?v=KDOI77kV34Q" %}

This chart type displays high and low values for each data point, providing a clear visualization of price ranges. The Hilo series requires two y-values for each data point: high (maximum price) and low (minimum price).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" /> 

    <ChartSeriesCollection>
        <ChartSeries DataSource="@StockDetails" XName="X" High="High" Low="Low" Type="ChartSeriesType.Hilo">
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
        new Data { X = "Jan", Low = 87, High = 200 },
        new Data { X = "Feb", Low = 45, High = 135 },
        new Data { X = "Mar", Low = 19, High = 85 },
        new Data { X = "Apr", Low = 31, High = 108 },
        new Data { X = "May", Low = 27, High = 80 },
        new Data { X = "June", Low = 84, High = 130 },
        new Data { X = "Jul", Low = 77, High = 150 },
        new Data { X = "Aug", Low = 54, High = 125 },
        new Data { X = "Sep", Low = 60, High = 155 },
        new Data { X = "Oct", Low = 60, High = 180 },
        new Data { X = "Nov", Low = 88, High = 180 },
        new Data { X = "Dec", Low = 84, High = 230 }
	};
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/rZrzNPLjzSqgHuAy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Hilo Chart](../images/financial-types/blazor-hilo-chart.png)

Refer to the [Blazor Hilo Chart](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/hilo-chart) feature tour page for more feature details. Explore the [Blazor Hilo Chart Example](https://blazor.syncfusion.com/demos/chart/hilo) to learn how to render and configure the Hilo series with interactive examples.

## Binding data with series

Bind data to the chart using the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) property in the series configuration. The [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) value can be set using either [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) or a list of business objects. For more information, see [Working with Data](../working-with-data). Map the data fields to the chart series' [`XName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_XName), [`High`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_High), and [`Low`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Low) properties.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"/> 

    <ChartSeriesCollection>
        <ChartSeries DataSource="@StockDetails" XName="X" High="High" Low="Low" Type="ChartSeriesType.Hilo">
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
        new Data { X = "Jan", Low = 87, High = 200 },
        new Data { X = "Feb", Low = 45, High = 135 },
        new Data { X = "Mar", Low = 19, High = 85 },
        new Data { X = "Apr", Low = 31, High = 108 },
        new Data { X = "May", Low = 27, High = 80 },
        new Data { X = "June", Low = 84, High = 130 },
        new Data { X = "Jul", Low = 77, High = 150 },
        new Data { X = "Aug", Low = 54, High = 125 },
        new Data { X = "Sep", Low = 60, High = 155 },
        new Data { X = "Oct", Low = 60, High = 180 },
        new Data { X = "Nov", Low = 88, High = 180 },
        new Data { X = "Dec", Low = 84, High = 230 }
	};
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/rZrzNPLjzSqgHuAy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Series customization

Customize the [Hilo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Hilo) series using the following properties:

**Fill**

The [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) property sets the color for the series.

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
        new Data { X = "Jan", Low = 87, High = 200 },
        new Data { X = "Feb", Low = 45, High = 135 },
        new Data { X = "Mar", Low = 19, High = 85 },
        new Data { X = "Apr", Low = 31, High = 108 },
        new Data { X = "May", Low = 27, High = 80 },
        new Data { X = "June", Low = 84, High = 130 },
        new Data { X = "Jul", Low = 77, High = 150 },
        new Data { X = "Aug", Low = 54, High = 125 },
        new Data { X = "Sep", Low = 60, High = 155 },
        new Data { X = "Oct", Low = 60, High = 180 },
        new Data { X = "Nov", Low = 88, High = 180 },
        new Data { X = "Dec", Low = 84, High = 230 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BXBpjPVXpydPcQUK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

Apply a gradient color to the hilo series by configuring the [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) property with gradient values.

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
        new Data { X = "Jan", Low = 87, High = 200 },
        new Data { X = "Feb", Low = 45, High = 135 },
        new Data { X = "Mar", Low = 19, High = 85 },
        new Data { X = "Apr", Low = 31, High = 108 },
        new Data { X = "May", Low = 27, High = 80 },
        new Data { X = "June", Low = 84, High = 130 },
        new Data { X = "Jul", Low = 77, High = 150 },
        new Data { X = "Aug", Low = 54, High = 125 },
        new Data { X = "Sep", Low = 60, High = 155 },
        new Data { X = "Oct", Low = 60, High = 180 },
        new Data { X = "Nov", Low = 88, High = 180 },
        new Data { X = "Dec", Low = 84, High = 230 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hXrJjvrjpyuiQFNZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Opacity**

The [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Opacity) property controls the transparency of the [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) color, allowing adjustment of the series' appearance.

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
        new Data { X = "Jan", Low = 87, High = 200 },
        new Data { X = "Feb", Low = 45, High = 135 },
        new Data { X = "Mar", Low = 19, High = 85 },
        new Data { X = "Apr", Low = 31, High = 108 },
        new Data { X = "May", Low = 27, High = 80 },
        new Data { X = "June", Low = 84, High = 130 },
        new Data { X = "Jul", Low = 77, High = 150 },
        new Data { X = "Aug", Low = 54, High = 125 },
        new Data { X = "Sep", Low = 60, High = 155 },
        new Data { X = "Oct", Low = 60, High = 180 },
        new Data { X = "Nov", Low = 88, High = 180 },
        new Data { X = "Dec", Low = 84, High = 230 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VDBJXPhtpxNMtCrv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Empty points

Data points with `null`, `double.NaN`, or `undefined` values are considered empty and are not plotted.

**Mode**

Use the [`Mode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Mode) property to specify how empty or missing data points are handled. The default mode is [`Gap`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.EmptyPointMode.html#Syncfusion_Blazor_Charts_EmptyPointMode_Gap).

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
        new Data { X = "Jan", Low = 87, High = 200 },
        new Data { X = "Feb", Low = 45, High = 135 },
        new Data { X = "Mar", Low = 19, High = 85 },
        new Data { X = "Apr", Low = 31, High = 108 },
        new Data { X = "May", Low = 27, High = 80 },
        new Data { X = "June", Low = double.NaN, High = double.NaN },
        new Data { X = "Jul", Low = 77, High = 150 },
        new Data { X = "Aug", Low = 54, High = 125 },
        new Data { X = "Sep", Low = 60, High = 155 },
        new Data { X = "Oct", Low = 60, High = 180 },
        new Data { X = "Nov", Low = 88, High = 180 },
        new Data { X = "Dec", Low = 84, High = 230 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BNVJtFVjpRrQLAvc?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Fill**

Customize the fill color of empty points using the [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Fill) property.

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
        new Data { X = "Jan", Low = 87, High = 200 },
        new Data { X = "Feb", Low = 45, High = 135 },
        new Data { X = "Mar", Low = 19, High = 85 },
        new Data { X = "Apr", Low = 31, High = 108 },
        new Data { X = "May", Low = 27, High = 80 },
        new Data { X = "June", Low = double.NaN, High = double.NaN },
        new Data { X = "Jul", Low = 77, High = 150 },
        new Data { X = "Aug", Low = 54, High = 125 },
        new Data { X = "Sep", Low = 60, High = 155 },
        new Data { X = "Oct", Low = 60, High = 180 },
        new Data { X = "Nov", Low = 88, High = 180 },
        new Data { X = "Dec", Low = 84, High = 230 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXhJXvVDTnpBHPCo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Events

### Series render

The [`OnSeriesRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnSeriesRender) event enables customization of series properties, such as [Data](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Data), [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Fill), and [Series](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Series), before rendering.

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
        new Data { X = "Jan", Low = 87, High = 200 },
        new Data { X = "Feb", Low = 45, High = 135 },
        new Data { X = "Mar", Low = 19, High = 85 },
        new Data { X = "Apr", Low = 31, High = 108 },
        new Data { X = "May", Low = 27, High = 80 },
        new Data { X = "June", Low = 84, High = 130 },
        new Data { X = "Jul", Low = 77, High = 150 },
        new Data { X = "Aug", Low = 54, High = 125 },
        new Data { X = "Sep", Low = 60, High = 155 },
        new Data { X = "Oct", Low = 60, High = 180 },
        new Data { X = "Nov", Low = 88, High = 180 },
        new Data { X = "Dec", Low = 84, High = 230 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rXLpNvLXpxyGcrgZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Point render

The [`OnPointRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnPointRender) event allows customization of each data point before rendering.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnPointRender="PointRender" />
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
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
        new Data { X = "Jan", Low = 87, High = 200 },
        new Data { X = "Feb", Low = 45, High = 135 },
        new Data { X = "Mar", Low = 19, High = 85 },
        new Data { X = "Apr", Low = 31, High = 108 },
        new Data { X = "May", Low = 27, High = 80 },
        new Data { X = "June", Low = 84, High = 130 },
        new Data { X = "Jul", Low = 77, High = 150 },
        new Data { X = "Aug", Low = 54, High = 125 },
        new Data { X = "Sep", Low = 60, High = 155 },
        new Data { X = "Oct", Low = 60, High = 180 },
        new Data { X = "Nov", Low = 88, High = 180 },
        new Data { X = "Dec", Low = 84, High = 230 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hthTXPBZzRmJfCpW?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See also

* [Data label](../data-labels)
* [Tooltip](../tool-tip)
