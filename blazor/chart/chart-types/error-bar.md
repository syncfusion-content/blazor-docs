---
layout: post
title: Error Bar Chart in Blazor Charts Component | Syncfusion
description: Check out and learn how to configure and customize the Error Bar Chart in Syncfusion Blazor Charts component.
platform: Blazor
control: Chart
documentation: ug
---

# Error Bar Chart in Blazor Charts Component

## Error Bar Chart

Error bars visually represent data variability and indicate the error or uncertainty in reported measurements. To display error bars for a series, set the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartErrorBarSettings.html#Syncfusion_Blazor_Charts_ChartErrorBarSettings_Visible) property to **true** in [ChartErrorBarSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartErrorBarSettings.html).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Type="ChartSeriesType.Line">
            <ChartErrorBarSettings Visible="true">
            </ChartErrorBarSettings>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y {get; set; }
    }

    public List<ChartData> SalesReports = new List<ChartData>
	{
        new ChartData { X = 2005, Y = 28 },
        new ChartData { X = 2006, Y = 25 },
        new ChartData { X = 2007, Y = 26 },
        new ChartData { X = 2008, Y = 27 },
        new ChartData { X = 2009, Y = 32 },
        new ChartData { X = 2010, Y = 35 },
        new ChartData { X = 2011, Y = 30 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/hjrJXvLtoGKlZQco?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Line Chart with Error Bar](../images/othertypes/blazor-error-bar-chart.png)

## Error bar type

Change the error bar rendering type using the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartErrorBarSettings.html#Syncfusion_Blazor_Charts_ChartErrorBarSettings_Type) property. Adjust the error bar line length with the [VerticalError](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartErrorBarSettings.html#Syncfusion_Blazor_Charts_ChartErrorBarSettings_VerticalError) property.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Type="ChartSeriesType.Line">
            <ChartErrorBarSettings Visible="true" Type="ErrorBarType.Percentage" VerticalError="4">
            </ChartErrorBarSettings>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> SalesReports = new List<ChartData>
	{
        new ChartData { X = 2005, Y = 28 },
        new ChartData { X = 2006, Y = 25 },
        new ChartData { X = 2007, Y = 26 },
        new ChartData { X = 2008, Y = 27 },
        new ChartData { X = 2009, Y = 32 },
        new ChartData { X = 2010, Y = 35 },
        new ChartData { X = 2011, Y = 30 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXVptlLDSQfSIQbX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customizing error bar type

To customize the error bar type, set the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartErrorBarSettings.html#Syncfusion_Blazor_Charts_ChartErrorBarSettings_Type) property to [Custom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ErrorBarType.html#Syncfusion_Blazor_Charts_ErrorBarType_Custom). Then, use [HorizontalNegativeError](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartErrorBarSettings.html#Syncfusion_Blazor_Charts_ChartErrorBarSettings_HorizontalNegativeError) and [HorizontalPositiveError](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartErrorBarSettings.html#Syncfusion_Blazor_Charts_ChartErrorBarSettings_HorizontalPositiveError) to adjust error values.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Type="ChartSeriesType.Line">
            <ChartErrorBarSettings Visible="true" Type="ErrorBarType.Custom" Mode="ErrorBarMode.Both"
                                   VerticalPositiveError="2" HorizontalPositiveError="1" VerticalNegativeError="2" HorizontalNegativeError="1">
            </ChartErrorBarSettings>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> SalesReports = new List<ChartData>
	{
        new ChartData { X = 2005, Y = 28 },
        new ChartData { X = 2006, Y = 25 },
        new ChartData { X = 2007, Y = 26 },
        new ChartData { X = 2008, Y = 27 },
        new ChartData { X = 2009, Y = 32 },
        new ChartData { X = 2010, Y = 35 },
        new ChartData { X = 2011, Y = 30 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/BNVpjbVteQTEHUBm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Error bar mode

Define whether the error bar line is drawn horizontally, vertically, or on both sides using the [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartErrorBarSettings.html#Syncfusion_Blazor_Charts_ChartErrorBarSettings_Mode) property.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Type="ChartSeriesType.Line">
            <ChartErrorBarSettings Visible="true" Mode="ErrorBarMode.Horizontal">
            </ChartErrorBarSettings>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> SalesReports = new List<ChartData>
	{
        new ChartData { X = 2005, Y = 28 },
        new ChartData { X = 2006, Y = 25 },
        new ChartData { X = 2007, Y = 26 },
        new ChartData { X = 2008, Y = 27 },
        new ChartData { X = 2009, Y = 32 },
        new ChartData { X = 2010, Y = 35 },
        new ChartData { X = 2011, Y = 30 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/LtrJXlrZemozoWbI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Error bar direction

Set the error bar direction to plus, minus, or both sides using the [Direction](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartErrorBarSettings.html#Syncfusion_Blazor_Charts_ChartErrorBarSettings_Direction) property.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Type="ChartSeriesType.Line">
            <ChartErrorBarSettings Visible="true" Mode="ErrorBarMode.Both" Direction="ErrorBarDirection.Minus">
            </ChartErrorBarSettings>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> SalesReports = new List<ChartData>
	{
        new ChartData { X = 2005, Y = 28 },
        new ChartData { X = 2006, Y = 25 },
        new ChartData { X = 2007, Y = 26 },
        new ChartData { X = 2008, Y = 27 },
        new ChartData { X = 2009, Y = 32 },
        new ChartData { X = 2010, Y = 35 },
        new ChartData { X = 2011, Y = 30 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/VNVfjbBNSQIYbupQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customizing error bar cap

Customize the error bar cap's [Length](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartErrorBarCapSettings.html#Syncfusion_Blazor_Charts_ChartErrorBarCapSettings_Length), [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartErrorBarCapSettings.html#Syncfusion_Blazor_Charts_ChartErrorBarCapSettings_Width), and [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartErrorBarCapSettings.html#Syncfusion_Blazor_Charts_ChartErrorBarCapSettings_Color) properties in [ChartErrorBarCapSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartErrorBarCapSettings.html).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Type="ChartSeriesType.Line">
            <ChartErrorBarSettings Visible="true">
                <ChartErrorBarCapSettings Length="10" Width="10" Color="#0000ff"></ChartErrorBarCapSettings>
            </ChartErrorBarSettings>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> SalesReports = new List<ChartData>
	{
        new ChartData { X = 2005, Y = 28 },
        new ChartData { X = 2006, Y = 25 },
        new ChartData { X = 2007, Y = 26 },
        new ChartData { X = 2008, Y = 27 },
        new ChartData { X = 2009, Y = 32 },
        new ChartData { X = 2010, Y = 35 },
        new ChartData { X = 2011, Y = 30 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/VZVJXbVDIGdTeIOM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Events

### Series render

The [`OnSeriesRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnSeriesRender) event enables customization of series properties, such as [Data](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Data), [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Fill), and [Series](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Series), before rendering.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnSeriesRender="SeriesRender" />

    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Line">
            <ChartErrorBarSettings Visible="true">
            </ChartErrorBarSettings>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public void SeriesRender(SeriesRenderEventArgs args)
    {
        args.Fill = "#FF4081";
    }

    public List<ChartData> SalesReports = new List<ChartData>
    {
        new ChartData { X = 2005, Y = 28 },
        new ChartData { X = 2006, Y = 25 },
        new ChartData { X = 2007, Y = 26 },
        new ChartData { X = 2008, Y = 27 },
        new ChartData { X = 2009, Y = 32 },
        new ChartData { X = 2010, Y = 35 },
        new ChartData { X = 2011, Y = 30 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/htBJjPrtyQcdqASQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Point render

The [`OnPointRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnPointRender) event allows customization of each data point before rendering.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartEvents OnPointRender="PointRender" />

    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Line">
            <ChartErrorBarSettings Visible="true">
            </ChartErrorBarSettings>
            <ChartMarker Visible="true" Height="10" Width="10"></ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public void PointRender(PointRenderEventArgs args)
    {
        args.Fill = args.Point.X.ToString() == "2008" ? "#E91E63" : "#3F51B5";
    }

    public List<ChartData> SalesReports = new List<ChartData>
    {
        new ChartData { X = 2005, Y = 28 },
        new ChartData { X = 2006, Y = 25 },
        new ChartData { X = 2007, Y = 26 },
        new ChartData { X = 2008, Y = 27 },
        new ChartData { X = 2009, Y = 32 },
        new ChartData { X = 2010, Y = 35 },
        new ChartData { X = 2011, Y = 30 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rjVzXbhXScaLsKPU?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See also

* [Data label](../data-labels)
* [Tooltip](../tool-tip)
