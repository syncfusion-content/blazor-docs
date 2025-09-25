---
layout: post
title: Candle Chart in Blazor Charts Component | Syncfusion
description: Checkout and learn how to configure and customize the Candle Chart in Syncfusion Blazor Charts component.
platform: Blazor
control: Chart
documentation: ug
---

# Candle Chart in Blazor Charts Component

## Candle Chart

The [Candle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Candle) series is similar to Hilo Open Close and represents **Low**, **High**, **Open**, and **Close** prices over time. It is commonly used in financial charts to visualize stock price movements.

You can also learn how to create a candle chart using Blazor Charts by watching the video below.

{% youtube "youtube:https://www.youtube.com/watch?v=KDOI77kV34Q" %}

To render a [`Candle`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Candle) series in your chart, you need to follow a few steps to configure it correctly. Here's a concise guide on how to do this:

1. **Set the series type**: Define the series [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Type) as [`Candle`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Candle) in your chart configuration. This indicates that the data should be represented as a candle chart, providing a detailed view of stock price fluctuations by displaying the high, low, open, and close values for each time period.

2. **Provide high, low, open, and close values**: The [`Candle`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Candle) series requires five fields (x, high, low, open, and close) to accurately display the stock's high, low, open, and close prices. Ensure that your data source includes these fields to create a detailed representation of stock price movements over time.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@StockDetails" XName="X" High="High" Low="Low" Open="Open" Close="Close" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Candle">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class Data
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
    }

    public List<Data> StockDetails = new List<Data>
    {
        new Data { X = "Jan", Open = 120, High = 160, Low = 100, Close = 140 },
        new Data { X = "Feb", Open = 150, High = 190, Low = 130, Close = 170 },
        new Data { X = "Mar", Open = 130, High = 170, Low = 110, Close = 150 },
        new Data { X = "Apr", Open = 160, High = 180, Low = 120, Close = 140 },
        new Data { X = "May", Open = 150, High = 170, Low = 110, Close = 130 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VjVpZFLtJkIBDGOn?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Candle Chart](../images/financial-types/blazor-candle-chart.png)

## Binding data with series

Bind data to the chart using the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) property in the series configuration. The [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) value can be set using either [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) or a list of business objects. For more information, see [Working with Data](../working-with-data). Map the data fields to the chart series' [`XName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_XName), [`High`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_High), [`Low`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Low), [`Open`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Open), and [`Close`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Close) properties.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@StockDetails" XName="X" High="High" Low="Low" Open="Open" Close="Close" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Candle">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class Data
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
    }

    public List<Data> StockDetails = new List<Data>
    {
        new Data { X = "Jan", Open = 120, High = 160, Low = 100, Close = 140 },
        new Data { X = "Feb", Open = 150, High = 190, Low = 130, Close = 170 },
        new Data { X = "Mar", Open = 130, High = 170, Low = 110, Close = 150 },
        new Data { X = "Apr", Open = 160, High = 180, Low = 120, Close = 140 },
        new Data { X = "May", Open = 150, High = 170, Low = 110, Close = 130 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VjVpZFLtJkIBDGOn?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Hollow candle

The [Candle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Candle) series allows visual comparison of the current price with the previous price by customizing its appearance. Candles are filled or left hollow based on the following criteria:

<!-- markdownlint-disable MD033 -->
<table>
<tr>
<td><b>States</b></td>
<td><b>Description </b></td>
</tr>
<tr>
<td>Filled</td>
<td>Candle sticks are filled when the close value is less than the open value.</td>
</tr>
<tr>
<td>Unfilled</td>
<td>Candle sticks are unfilled when the close value is greater than the open value.</td>
</tr>
</table>

The color of the candle is defined by comparing with previous values. [BullFillColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_BullFillColor) is applied when the current closing value is greater than the previous closing value, and [BearFillColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_BearFillColor) is applied when the current closing value is less than the previous closing value. By default, [BullFillColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_BullFillColor) is **green** and [BearFillColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_BearFillColor) is **red**.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@StockDetails" XName="X" High="High" BearFillColor="#e56590" BullFillColor="#f8b883"
                     Low="Low" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Candle" Open="Open" Close="Close">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class Data
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
    }

    public List<Data> StockDetails = new List<Data>
    {
        new Data { X = "Jan", Open = 120, High = 160, Low = 100, Close = 140 },
        new Data { X = "Feb", Open = 150, High = 190, Low = 130, Close = 170 },
        new Data { X = "Mar", Open = 130, High = 170, Low = 110, Close = 150 },
        new Data { X = "Apr", Open = 160, High = 180, Low = 120, Close = 140 },
        new Data { X = "May", Open = 150, High = 170, Low = 110, Close = 130 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/hZhTtlrZzYcERtLX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Solid candles

Use the [EnableSolidCandles](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_EnableSolidCandles) property to enable or disable solid candles. By default, it is set to **false**. The fill color of the candle is defined by its opening and closing values. [BearFillColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_BearFillColor) is applied when the opening value is less than the closing value, and [BullFillColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_BullFillColor) is applied when the opening value is greater than the closing value.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@StockDetails" XName="X" High="High" BearFillColor="#e56590" BullFillColor="#f8b883" EnableSolidCandles="true"
                     Low="Low" Type="ChartSeriesType.Candle" Open="Open" Close="Close">
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
        public double Open { get; set; }
        public double Close { get; set; }
    }

    public List<Data> StockDetails = new List<Data>
	{
        new Data { X = "Jan", Open = 120, High = 160, Low = 100, Close = 140 },
        new Data { X = "Feb", Open = 150, High = 190, Low = 130, Close = 170 },
        new Data { X = "Mar", Open = 130, High = 170, Low = 110, Close = 150 },
        new Data { X = "Apr", Open = 160, High = 180, Low = 120, Close = 140 },
        new Data { X = "May", Open = 150, High = 170, Low = 110, Close = 130 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/hXrJZPrNfEvwlPNT?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Empty points

Data points with `null`, `double.NaN`, or `undefined` values are considered empty and are not plotted.

**Mode**

Use the [`Mode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Mode) property to specify how empty or missing data points are handled. The default mode is [`Gap`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.EmptyPointMode.html#Syncfusion_Blazor_Charts_EmptyPointMode_Gap).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@StockDetails" XName="X" High="High" Low="Low" Open="Open" Close="Close" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Candle">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Gap"></ChartEmptyPointSettings>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class Data
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
    }

    public List<Data> StockDetails = new List<Data>
    {
        new Data { X = "Jan", Open = 120, High = 160, Low = 100, Close = 140 },
        new Data { X = "Feb", Open = 150, High = 190, Low = 130, Close = 170 },
        new Data { X = "Mar", Open = double.NaN, High = double.NaN, Low = double.NaN, Close = double.NaN },
        new Data { X = "Apr", Open = 160, High = 180, Low = 120, Close = 140 },
        new Data { X = "May", Open = 150, High = 170, Low = 110, Close = 130 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VNrJNvhZyNKfjiBM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Fill**

Customize the fill color of empty points using the [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Fill) property.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@StockDetails" XName="X" High="High" Low="Low" Open="Open" Close="Close" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Candle">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Average" Fill="#FFDE59"></ChartEmptyPointSettings>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class Data
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
    }

    public List<Data> StockDetails = new List<Data>
    {
        new Data { X = "Jan", Open = 120, High = 160, Low = 100, Close = 140 },
        new Data { X = "Feb", Open = 150, High = 190, Low = 130, Close = 170 },
        new Data { X = "Mar", Open = double.NaN, High = double.NaN, Low = double.NaN, Close = double.NaN },
        new Data { X = "Apr", Open = 160, High = 180, Low = 120, Close = 140 },
        new Data { X = "May", Open = 150, High = 170, Low = 110, Close = 130 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDBTZFLjSjxgzXQt?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Events

### Series render

The [`OnSeriesRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnSeriesRender) event enables customization of series properties, such as [Data](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Data), [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Fill), and [Series](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Series), before rendering.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnSeriesRender="SeriesRender" />
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
    <ChartSeriesCollection>
        <ChartSeries DataSource="@StockDetails" XName="X" High="High" Low="Low" Open="Open" Close="Close" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Candle" />
    </ChartSeriesCollection>
</SfChart>

@code {
    public class Data
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
    }

    public void SeriesRender(SeriesRenderEventArgs args)
    {
        args.Series.BearFillColor = "blue";
        args.Series.BullFillColor = "orange";
    }

    public List<Data> StockDetails = new List<Data>
    {
        new Data { X = "Jan", Open = 120, High = 160, Low = 100, Close = 140 },
        new Data { X = "Feb", Open = 150, High = 190, Low = 130, Close = 170 },
        new Data { X = "Mar", Open = 130, High = 170, Low = 110, Close = 150 },
        new Data { X = "Apr", Open = 160, High = 180, Low = 120, Close = 140 },
        new Data { X = "May", Open = 150, High = 170, Low = 110, Close = 130 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BtBpXbhjyNwaIvNz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Point render

The [`OnPointRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnPointRender) event allows customization of each data point before rendering.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnPointRender="PointRender" />
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
    <ChartSeriesCollection>
        <ChartSeries DataSource="@StockDetails" XName="X" High="High" Low="Low" Open="Open" Close="Close" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Candle" />
    </ChartSeriesCollection>
</SfChart>

@code {
    public class Data
    {
        public string X { get; set; }
        public double Y { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Open { get; set; }
        public double Close { get; set; }
    }

    public void PointRender(PointRenderEventArgs args)
    {
        args.Series.BearFillColor = args.Point.X.ToString() == "Mar" ? "#E91E63" : "#3F51B5";
        args.Series.BullFillColor = args.Point.X.ToString() == "Mar" ? "#E91E63" : "#3F51B5";
    }

    public List<Data> StockDetails = new List<Data>
    {
        new Data { X = "Jan", Open = 120, High = 160, Low = 100, Close = 140 },
        new Data { X = "Feb", Open = 150, High = 190, Low = 130, Close = 170 },
        new Data { X = "Mar", Open = 130, High = 170, Low = 110, Close = 150 },
        new Data { X = "Apr", Open = 160, High = 180, Low = 120, Close = 140 },
        new Data { X = "May", Open = 150, High = 170, Low = 110, Close = 130 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXrfZbVDoNPkKESJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See also

* [Data label](../data-labels)
* [Tooltip](../tool-tip)
