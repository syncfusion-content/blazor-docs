---
layout: post
title: Vertical Chart in Blazor Charts Component | Syncfusion
description: Check out and learn how to configure and customize Vertical Chart in Syncfusion Blazor Charts component.
platform: Blazor
control: Chart
documentation: ug
---

# Vertical Chart in Blazor Charts Component

## Vertical chart

Render a vertical chart by changing the axis orientation. All series types support this option. To display a chart vertically, set the [IsTransposed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_IsTransposed) property.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart IsTransposed="true">
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Type="ChartSeriesType.Spline">
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
{% previewsample "https://blazorplayground.syncfusion.com/embed/VtrzXFhjSvWwRZBo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Vertical Spline Chart](../images/othertypes/blazor-vertical-spline-chart.png)

## Binding data with series

Bind data to the chart using the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) property in the series configuration. The [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) value can be set using either [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) or a list of business objects. For more information, see [Working with Data](../working-with-data). Map the data fields to the chart series' [`XName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_XName) and [`YName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_YName) properties.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart IsTransposed="true">
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Type="ChartSeriesType.Spline">
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
{% previewsample "https://blazorplayground.syncfusion.com/embed/VtrzXFhjSvWwRZBo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Empty points

Data points with `null`, `double.NaN`, or `undefined` values are considered empty and are not plotted.

**Mode**

Use the [`Mode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Mode) property to define how empty points are handled. The default is [`Gap`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.EmptyPointMode.html#Syncfusion_Blazor_Charts_EmptyPointMode_Gap).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart IsTransposed="true">
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Spline">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Gap"></ChartEmptyPointSettings>
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

    public List<ChartData> SalesReports = new List<ChartData>
    {
        new ChartData { X = 2005, Y = 28 },
        new ChartData { X = 2006, Y = 25 },
        new ChartData { X = 2007, Y = 26 },
        new ChartData { X = 2008, Y = double.NaN },
        new ChartData { X = 2009, Y = 32 },
        new ChartData { X = 2010, Y = 35 },
        new ChartData { X = 2011, Y = 30 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VjLTXvhXoPpvTSiM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Fill**

Use the [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Fill) property to set the fill color for empty points.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart IsTransposed="true">
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Spline">
            <ChartEmptyPointSettings Fill="#FFDE59" Mode="EmptyPointMode.Average"></ChartEmptyPointSettings>
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

    public List<ChartData> SalesReports = new List<ChartData>
    {
        new ChartData { X = 2005, Y = 28 },
        new ChartData { X = 2006, Y = 25 },
        new ChartData { X = 2007, Y = 26 },
        new ChartData { X = 2008, Y = double.NaN },
        new ChartData { X = 2009, Y = 32 },
        new ChartData { X = 2010, Y = 35 },
        new ChartData { X = 2011, Y = 30 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rjBzDbhNyvnMrQhi?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Border**

Use the [`Border`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Border) property to customize the border's [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointBorder.html#Syncfusion_Blazor_Charts_ChartEmptyPointBorder_Width) and [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointBorder.html#Syncfusion_Blazor_Charts_ChartEmptyPointBorder_Color).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart IsTransposed="true">
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Spline">
            <ChartEmptyPointSettings Fill="#FFDE59" Mode="EmptyPointMode.Average">
                <ChartEmptyPointBorder Color="red" Width="2"></ChartEmptyPointBorder>
            </ChartEmptyPointSettings>
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

    public List<ChartData> SalesReports = new List<ChartData>
    {
        new ChartData { X = 2005, Y = 28 },
        new ChartData { X = 2006, Y = 25 },
        new ChartData { X = 2007, Y = 26 },
        new ChartData { X = 2008, Y = double.NaN },
        new ChartData { X = 2009, Y = 32 },
        new ChartData { X = 2010, Y = 35 },
        new ChartData { X = 2011, Y = 30 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/htBpXvrDyvQhZCyn?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Events

### Series render

The [`OnSeriesRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnSeriesRender) event enables customization of series properties, such as [Data](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Data), [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Fill), and [Series](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Series), before rendering.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart IsTransposed="true">
    <ChartEvents OnSeriesRender="SeriesRender" />
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Spline">
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
{% previewsample "https://blazorplayground.syncfusion.com/embed/rNLTDFLZSllvdqCl?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Point render

The [`OnPointRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnPointRender) event allows customization of each data point before rendering.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart IsTransposed="true">
    <ChartEvents OnPointRender="PointRender" />
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Type="Syncfusion.Blazor.Charts.ChartSeriesType.Spline">
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
{% previewsample "https://blazorplayground.syncfusion.com/embed/LXrztlLNoFEcaytl?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See also

* [Data label](../data-labels)
* [Tooltip](../tool-tip)
