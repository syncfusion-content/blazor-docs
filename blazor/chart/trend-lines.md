---
layout: post
title: Trend Lines in Blazor Chart Component | Syncfusion 
description: Learn about Trend Lines in Blazor Chart component of Syncfusion, and more details.
platform: Blazor
control: Chart
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Trendlines

Trendlines are used to show the direction and speed of price.

Trendlines can be generated for Cartesian type series (Line, Column, Scatter, Area, Candle, Hilo etc.)
except bar type series. You can add more than one trendline to a series.

Chart supports 6 types of trendlines.

## Linear

A linear trendline is a best fit straight line that is used with simpler data sets. To render a linear trendline,
use trendline [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTrendline.html#Syncfusion_Blazor_Charts_ChartTrendline_Type) as **Linear**.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart Title="Historical Indian Rupee Rate (INR USD)">
    <ChartArea><ChartAreaBorder Width="0"></ChartAreaBorder></ChartArea>
    <ChartPrimaryXAxis LabelFormat="yyyy" ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime" EdgeLabelPlacement="EdgeLabelPlacement.Shift">
        <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
    </ChartPrimaryXAxis>
    <ChartPrimaryYAxis Title="Rupees against Dollars">
        <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
        <ChartAxisMajorTickLines Width="0"></ChartAxisMajorTickLines>
    </ChartPrimaryYAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@Data" XName="XValue" YName="YValue" Type="ChartSeriesType.Spline">
            <ChartMarker Visible="true">
            </ChartMarker>
            <ChartTrendlines>
                <ChartTrendline Type="TrendlineTypes.Linear" Width="3" Name="Linear" Fill="#C64A75">
                </ChartTrendline>
            </ChartTrendlines>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> Data = new List<ChartData>
{
        new ChartData { XValue = new DateTime(2000, 2, 11), YValue = 14 },
        new ChartData { XValue = new DateTime(2001, 9, 4), YValue = 20 },
        new ChartData { XValue = new DateTime(2002, 2, 11), YValue = 25 },
        new ChartData { XValue = new DateTime(2003, 9, 16), YValue = 21 },
        new ChartData { XValue = new DateTime(2004, 2, 7), YValue = 13},
        new ChartData { XValue = new DateTime(2005, 9, 7), YValue = 18 },
        new ChartData { XValue = new DateTime(2006, 2, 11), YValue = 24 },
        new ChartData { XValue = new DateTime(2007, 9, 14), YValue = 23 },
        new ChartData { XValue = new DateTime(2008, 2, 6), YValue = 19 },
        new ChartData { XValue = new DateTime(2009, 9, 6), YValue = 31 },
        new ChartData { XValue = new DateTime(2010, 2, 11), YValue = 39},
        new ChartData { XValue = new DateTime(2011, 9, 11), YValue = 50 },
        new ChartData { XValue = new DateTime(2012, 2, 11), YValue = 24 },
    };

}

{% endhighlight %}

![Linear](images/trend-lines/linear-razor.png)

## Exponential

Exponential trendline is a curved line that is most useful when data values rise or fall
at increasingly higher rates. You cannot create an exponential trendline, if your data contains zero or negative values.

To render a exponential trendline,
use trendline [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTrendline.html#Syncfusion_Blazor_Charts_ChartTrendline_Type) as **Exponential**.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart Title="Historical Indian Rupee Rate (INR USD)">
    <ChartArea><ChartAreaBorder Width="0"></ChartAreaBorder></ChartArea>

    <ChartPrimaryXAxis LabelFormat="yyyy" ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime" EdgeLabelPlacement="EdgeLabelPlacement.Shift">
        <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
    </ChartPrimaryXAxis>

    <ChartPrimaryYAxis Title="Rupees against Dollars">
        <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
        <ChartAxisMajorTickLines Width="0"></ChartAxisMajorTickLines>
    </ChartPrimaryYAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@Data" XName="XValue" YName="YValue" Type="ChartSeriesType.Spline">
            <ChartMarker Visible="true">
            </ChartMarker>
            <ChartTrendlines>
                <ChartTrendline Type="TrendlineTypes.Exponential" Width="3" Name="Exponential" Fill="#C64A75">
                </ChartTrendline>
            </ChartTrendlines>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> Data = new List<ChartData>
{
        new ChartData { XValue = new DateTime(2000, 2, 11), YValue = 14 },
        new ChartData { XValue = new DateTime(2001, 9, 4), YValue = 20 },
        new ChartData { XValue = new DateTime(2002, 2, 11), YValue = 25 },
        new ChartData { XValue = new DateTime(2003, 9, 16), YValue = 21 },
        new ChartData { XValue = new DateTime(2004, 2, 7), YValue = 13},
        new ChartData { XValue = new DateTime(2005, 9, 7), YValue = 18 },
        new ChartData { XValue = new DateTime(2006, 2, 11), YValue = 24 },
        new ChartData { XValue = new DateTime(2007, 9, 14), YValue = 23 },
        new ChartData { XValue = new DateTime(2008, 2, 6), YValue = 19 },
        new ChartData { XValue = new DateTime(2009, 9, 6), YValue = 31 },
        new ChartData { XValue = new DateTime(2010, 2, 11), YValue = 39},
        new ChartData { XValue = new DateTime(2011, 9, 11), YValue = 50 },
        new ChartData { XValue = new DateTime(2012, 2, 11), YValue = 24 },
    };

}

{% endhighlight %}

## Logarithmic

A logarithmic trendline is a best-fit curved line that is most useful when the rate of change
in the data increases or decreases quickly and then levels out.

A logarithmic trendline can use negative and/or positive values.

To render a logarithmic trendline, use trendline [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTrendline.html#Syncfusion_Blazor_Charts_ChartTrendline_Type) as **Logarithmic**.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart Title="Historical Indian Rupee Rate (INR USD)">
    <ChartArea><ChartAreaBorder Width="0"></ChartAreaBorder></ChartArea>

    <ChartPrimaryXAxis LabelFormat="yyyy" ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime" EdgeLabelPlacement="EdgeLabelPlacement.Shift">
        <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
    </ChartPrimaryXAxis>

    <ChartPrimaryYAxis Title="Rupees against Dollars">
        <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
        <ChartAxisMajorTickLines Width="0"></ChartAxisMajorTickLines>
    </ChartPrimaryYAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@Data" XName="XValue" YName="YValue" Type="ChartSeriesType.Spline">
            <ChartMarker Visible="true">
            </ChartMarker>
            <ChartTrendlines>
                <ChartTrendline Type="TrendlineTypes.Logarithmic" Width="3" Name="Logarithmic" Fill="#C64A75">
                </ChartTrendline>
            </ChartTrendlines>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> Data = new List<ChartData>
{
        new ChartData { XValue = new DateTime(2000, 2, 11), YValue = 14 },
        new ChartData { XValue = new DateTime(2001, 9, 4), YValue = 20 },
        new ChartData { XValue = new DateTime(2002, 2, 11), YValue = 25 },
        new ChartData { XValue = new DateTime(2003, 9, 16), YValue = 21 },
        new ChartData { XValue = new DateTime(2004, 2, 7), YValue = 13},
        new ChartData { XValue = new DateTime(2005, 9, 7), YValue = 18 },
        new ChartData { XValue = new DateTime(2006, 2, 11), YValue = 24 },
        new ChartData { XValue = new DateTime(2007, 9, 14), YValue = 23 },
        new ChartData { XValue = new DateTime(2008, 2, 6), YValue = 19 },
        new ChartData { XValue = new DateTime(2009, 9, 6), YValue = 31 },
        new ChartData { XValue = new DateTime(2010, 2, 11), YValue = 39},
        new ChartData { XValue = new DateTime(2011, 9, 11), YValue = 50 },
        new ChartData { XValue = new DateTime(2012, 2, 11), YValue = 24 },
    };

}

{% endhighlight %}

## Polynomial

A polynomial trendline is a curved line that is used when data fluctuates.

To render a polynomial trendline,
use trendline [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTrendline.html#Syncfusion_Blazor_Charts_ChartTrendline_Type) as **Polynomial**.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart Title="Historical Indian Rupee Rate (INR USD)">
    <ChartArea><ChartAreaBorder Width="0"></ChartAreaBorder></ChartArea>

    <ChartPrimaryXAxis LabelFormat="yyyy" ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime" EdgeLabelPlacement="EdgeLabelPlacement.Shift">
        <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
    </ChartPrimaryXAxis>

    <ChartPrimaryYAxis Title="Rupees against Dollars">
        <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
        <ChartAxisMajorTickLines Width="0"></ChartAxisMajorTickLines>
    </ChartPrimaryYAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@Data" XName="XValue" YName="YValue" Type="ChartSeriesType.Spline">
            <ChartMarker Visible="true">
            </ChartMarker>
            <ChartTrendlines>
                <ChartTrendline Type="TrendlineTypes.Polynomial" Width="3" Name="Polynomial" Fill="#C64A75">
                </ChartTrendline>
            </ChartTrendlines>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> Data = new List<ChartData>
{
        new ChartData { XValue = new DateTime(2000, 2, 11), YValue = 14 },
        new ChartData { XValue = new DateTime(2001, 9, 4), YValue = 20 },
        new ChartData { XValue = new DateTime(2002, 2, 11), YValue = 25 },
        new ChartData { XValue = new DateTime(2003, 9, 16), YValue = 21 },
        new ChartData { XValue = new DateTime(2004, 2, 7), YValue = 13},
        new ChartData { XValue = new DateTime(2005, 9, 7), YValue = 18 },
        new ChartData { XValue = new DateTime(2006, 2, 11), YValue = 24 },
        new ChartData { XValue = new DateTime(2007, 9, 14), YValue = 23 },
        new ChartData { XValue = new DateTime(2008, 2, 6), YValue = 19 },
        new ChartData { XValue = new DateTime(2009, 9, 6), YValue = 31 },
        new ChartData { XValue = new DateTime(2010, 2, 11), YValue = 39},
        new ChartData { XValue = new DateTime(2011, 9, 11), YValue = 50 },
        new ChartData { XValue = new DateTime(2012, 2, 11), YValue = 24 },
    };

}

{% endhighlight %}

## Power

A power trendline is a curved line that is best used with data sets that compare measurements that increase at a specific rate.

To render a power trendline, use trendline [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTrendline.html#Syncfusion_Blazor_Charts_ChartTrendline_Type) as **Power**.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart Title="Historical Indian Rupee Rate (INR USD)">
    <ChartArea><ChartAreaBorder Width="0"></ChartAreaBorder></ChartArea>

    <ChartPrimaryXAxis LabelFormat="yyyy" ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime" EdgeLabelPlacement="EdgeLabelPlacement.Shift">
        <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
    </ChartPrimaryXAxis>

    <ChartPrimaryYAxis Title="Rupees against Dollars">
        <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
        <ChartAxisMajorTickLines Width="0"></ChartAxisMajorTickLines>
    </ChartPrimaryYAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@Data" XName="XValue" YName="YValue" Type="ChartSeriesType.Spline">
            <ChartMarker Visible="true">
            </ChartMarker>
            <ChartTrendlines>
                <ChartTrendline Type="TrendlineTypes.Power" Width="3" Name="Power" Fill="#C64A75">
                </ChartTrendline>
            </ChartTrendlines>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> Data = new List<ChartData>
{
        new ChartData { XValue = new DateTime(2000, 2, 11), YValue = 14 },
        new ChartData { XValue = new DateTime(2001, 9, 4), YValue = 20 },
        new ChartData { XValue = new DateTime(2002, 2, 11), YValue = 25 },
        new ChartData { XValue = new DateTime(2003, 9, 16), YValue = 21 },
        new ChartData { XValue = new DateTime(2004, 2, 7), YValue = 13},
        new ChartData { XValue = new DateTime(2005, 9, 7), YValue = 18 },
        new ChartData { XValue = new DateTime(2006, 2, 11), YValue = 24 },
        new ChartData { XValue = new DateTime(2007, 9, 14), YValue = 23 },
        new ChartData { XValue = new DateTime(2008, 2, 6), YValue = 19 },
        new ChartData { XValue = new DateTime(2009, 9, 6), YValue = 31 },
        new ChartData { XValue = new DateTime(2010, 2, 11), YValue = 39},
        new ChartData { XValue = new DateTime(2011, 9, 11), YValue = 50 },
        new ChartData { XValue = new DateTime(2012, 2, 11), YValue = 24 },
    };

}

{% endhighlight %}

## Moving Average

A moving average trendline smoothen out fluctuations in data to show a pattern or trend more clearly.

To render a moving average trendline, use trendline [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTrendline.html#Syncfusion_Blazor_Charts_ChartTrendline_Type) as `MovingAverage`.

[`Period`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTrendline.html#Syncfusion_Blazor_Charts_ChartTrendline_Period) property defines the period to find the moving average.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart Title="Historical Indian Rupee Rate (INR USD)">
    <ChartArea><ChartAreaBorder Width="0"></ChartAreaBorder></ChartArea>

    <ChartPrimaryXAxis LabelFormat="yyyy" ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime" EdgeLabelPlacement="EdgeLabelPlacement.Shift">
        <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
    </ChartPrimaryXAxis>

    <ChartPrimaryYAxis Title="Rupees against Dollars">
        <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
        <ChartAxisMajorTickLines Width="0"></ChartAxisMajorTickLines>
    </ChartPrimaryYAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@Data" XName="XValue" YName="YValue" Type="ChartSeriesType.Spline">
            <ChartMarker Visible="true">
            </ChartMarker>
            <ChartTrendlines>
                <ChartTrendline Type="TrendlineTypes.MovingAverage" Width="3" Name="MovingAverage" Fill="#C64A75">
                </ChartTrendline>
            </ChartTrendlines>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> Data = new List<ChartData>
{
        new ChartData { XValue = new DateTime(2000, 2, 11), YValue = 14 },
        new ChartData { XValue = new DateTime(2001, 9, 4), YValue = 20 },
        new ChartData { XValue = new DateTime(2002, 2, 11), YValue = 25 },
        new ChartData { XValue = new DateTime(2003, 9, 16), YValue = 21 },
        new ChartData { XValue = new DateTime(2004, 2, 7), YValue = 13},
        new ChartData { XValue = new DateTime(2005, 9, 7), YValue = 18 },
        new ChartData { XValue = new DateTime(2006, 2, 11), YValue = 24 },
        new ChartData { XValue = new DateTime(2007, 9, 14), YValue = 23 },
        new ChartData { XValue = new DateTime(2008, 2, 6), YValue = 19 },
        new ChartData { XValue = new DateTime(2009, 9, 6), YValue = 31 },
        new ChartData { XValue = new DateTime(2010, 2, 11), YValue = 39},
        new ChartData { XValue = new DateTime(2011, 9, 11), YValue = 50 },
        new ChartData { XValue = new DateTime(2012, 2, 11), YValue = 24 },
    };

}

{% endhighlight %}

**Customization of Trendlines**

The [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTrendline.html#Syncfusion_Blazor_Charts_ChartTrendline_Fill)
and [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTrendline.html#Syncfusion_Blazor_Charts_ChartTrendline_Width)
properties are used to customize the appearance of the trendline.

## Forecasting

Trendlines forecasting is the prediction of future/past situations.

Forecasting can be classified into two types as follows

Forward Forecasting and Backward Forecasting

**Forward Forecasting**

The value set for [`ForwardForecast`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTrendline.html#Syncfusion_Blazor_Charts_ChartTrendline_ForwardForecast) is used to determine the distance moving towards the future trend.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart Title="Historical Indian Rupee Rate (INR USD)">
    <ChartArea><ChartAreaBorder Width="0"></ChartAreaBorder></ChartArea>

    <ChartPrimaryXAxis LabelFormat="yyyy" ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime" EdgeLabelPlacement="EdgeLabelPlacement.Shift">
        <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
    </ChartPrimaryXAxis>

    <ChartPrimaryYAxis Title="Rupees against Dollars">
        <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
        <ChartAxisMajorTickLines Width="0"></ChartAxisMajorTickLines>
    </ChartPrimaryYAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@Data" XName="XValue" YName="YValue" Type="ChartSeriesType.Spline">
            <ChartMarker Visible="true">
            </ChartMarker>
            <ChartTrendlines>
                <ChartTrendline Type="TrendlineTypes.Linear" Width="3" Name="Linear" Fill="#C64A75" ForwardForecast="5">
                </ChartTrendline>
            </ChartTrendlines>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> Data = new List<ChartData>
{
        new ChartData { XValue = new DateTime(2000, 2, 11), YValue = 14 },
        new ChartData { XValue = new DateTime(2001, 9, 4), YValue = 20 },
        new ChartData { XValue = new DateTime(2002, 2, 11), YValue = 25 },
        new ChartData { XValue = new DateTime(2003, 9, 16), YValue = 21 },
        new ChartData { XValue = new DateTime(2004, 2, 7), YValue = 13},
        new ChartData { XValue = new DateTime(2005, 9, 7), YValue = 18 },
        new ChartData { XValue = new DateTime(2006, 2, 11), YValue = 24 },
        new ChartData { XValue = new DateTime(2007, 9, 14), YValue = 23 },
        new ChartData { XValue = new DateTime(2008, 2, 6), YValue = 19 },
        new ChartData { XValue = new DateTime(2009, 9, 6), YValue = 31 },
        new ChartData { XValue = new DateTime(2010, 2, 11), YValue = 39},
        new ChartData { XValue = new DateTime(2011, 9, 11), YValue = 50 },
        new ChartData { XValue = new DateTime(2012, 2, 11), YValue = 24 },
    };

}

{% endhighlight %}

**Backward Forecasting**

The value set for the [`BackwardForecast`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTrendline.html#Syncfusion_Blazor_Charts_ChartTrendline_BackwardForecast) is used to determine the past trends.

{% highlight csharp %}

@using Syncfusion.Blazor.Charts

<SfChart Title="Historical Indian Rupee Rate (INR USD)">
    <ChartArea><ChartAreaBorder Width="0"></ChartAreaBorder></ChartArea>

    <ChartPrimaryXAxis LabelFormat="yyyy" ValueType="Syncfusion.Blazor.Charts.ValueType.DateTime" EdgeLabelPlacement="EdgeLabelPlacement.Shift">
        <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
    </ChartPrimaryXAxis>

    <ChartPrimaryYAxis Title="Rupees against Dollars">
        <ChartAxisLineStyle Width="0"></ChartAxisLineStyle>
        <ChartAxisMajorTickLines Width="0"></ChartAxisMajorTickLines>
    </ChartPrimaryYAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@Data" XName="XValue" YName="YValue" Type="ChartSeriesType.Spline">
            <ChartMarker Visible="true">
            </ChartMarker>
            <ChartTrendlines>
                <ChartTrendline Type="TrendlineTypes.Linear" Width="3" Name="Linear" Fill="#C64A75" BackwardForecast="5">
                </ChartTrendline>
            </ChartTrendlines>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public DateTime XValue { get; set; }
        public double YValue { get; set; }
    }

    public List<ChartData> Data = new List<ChartData>
{
        new ChartData { XValue = new DateTime(2000, 2, 11), YValue = 14 },
        new ChartData { XValue = new DateTime(2001, 9, 4), YValue = 20 },
        new ChartData { XValue = new DateTime(2002, 2, 11), YValue = 25 },
        new ChartData { XValue = new DateTime(2003, 9, 16), YValue = 21 },
        new ChartData { XValue = new DateTime(2004, 2, 7), YValue = 13},
        new ChartData { XValue = new DateTime(2005, 9, 7), YValue = 18 },
        new ChartData { XValue = new DateTime(2006, 2, 11), YValue = 24 },
        new ChartData { XValue = new DateTime(2007, 9, 14), YValue = 23 },
        new ChartData { XValue = new DateTime(2008, 2, 6), YValue = 19 },
        new ChartData { XValue = new DateTime(2009, 9, 6), YValue = 31 },
        new ChartData { XValue = new DateTime(2010, 2, 11), YValue = 39},
        new ChartData { XValue = new DateTime(2011, 9, 11), YValue = 50 },
        new ChartData { XValue = new DateTime(2012, 2, 11), YValue = 24 },
    };

}


{% endhighlight %}

> Note: You can refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations. You can also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to knows various chart types and how to represent time-dependent data, showing trends in data at equal intervals.

## See Also

* [Data label](./data-labels)
* [Tooltip](./tool-tip)
* [Marker](./data-markers)