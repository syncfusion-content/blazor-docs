---
layout: post
title: Radar Chart in Blazor Charts Component | Syncfusion
description: Check out and learn how to configure and customize the Radar Chart in Syncfusion Blazor Charts component.
platform: Blazor
control: Chart
documentation: ug
---

# Radar Chart in Blazor Charts Component

## Radar Chart

The [Radar](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/radar-chart) series visualizes data using values and angles, providing options for visual comparison between quantitative or qualitative aspects.

You can also learn how to create a Radar chart using Blazor Charts by watching the video below.

{% youtube "youtube:https://www.youtube.com/watch?v=Q5odgrcbSO0" %}

To render a radar chart, set the series [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Type) to [Radar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Radar). For a [Line](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDrawType.html#Syncfusion_Blazor_Charts_ChartDrawType_Line) series in Radar Chart, set the [DrawType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DrawType) property to [Line](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDrawType.html#Syncfusion_Blazor_Charts_ChartDrawType_Line). The [IsClosed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_IsClosed) property determines whether to join the start and end points to form a closed path. The default value is **true**.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y"
                    Type="ChartSeriesType.Radar" DrawType="ChartDrawType.Line">
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
        new ChartData{ X = 2005, Y = 28 },
        new ChartData{ X = 2006, Y = 25 },
        new ChartData{ X = 2007, Y = 26 },
        new ChartData{ X = 2008, Y = 27 },
        new ChartData{ X = 2009, Y = 32 },
        new ChartData{ X = 2010, Y = 35 },
        new ChartData{ X = 2011, Y = 30 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/LjhfXbrXfzZtZPkh?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Radar Chart with Line Series](../images/polar-radar/blazor-radar-chart-line-series.png)

Refer to the [Blazor Radar Chart](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/radar-chart) feature tour page for more feature details. Explore the [Blazor Radar Chart Example](https://blazor.syncfusion.com/demos/chart/polar-line) to learn how to render and configure radar charts with interactive examples.

## Binding data with series

Bind data to the chart using the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) property in the series configuration. The [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DataSource) value can be set using either [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) or a list of business objects. For more information, see [Working with Data](../working-with-data). Map the data fields to the chart series' [`XName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_XName) and [`YName`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_YName) properties.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y"
                    Type="ChartSeriesType.Radar">
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
        new ChartData{ X = 2005, Y = 28 },
        new ChartData{ X = 2006, Y = 25 },
        new ChartData{ X = 2007, Y = 26 },
        new ChartData{ X = 2008, Y = 27 },
        new ChartData{ X = 2009, Y = 32 },
        new ChartData{ X = 2010, Y = 35 },
        new ChartData{ X = 2011, Y = 30 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/LjhfXbrXfzZtZPkh?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Draw type

Change the series plotting type using the [DrawType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_DrawType) property. Supported types include [Line](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDrawType.html#Syncfusion_Blazor_Charts_ChartDrawType_Line), [Column](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDrawType.html#Syncfusion_Blazor_Charts_ChartDrawType_Column), [Area](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDrawType.html#Syncfusion_Blazor_Charts_ChartDrawType_Area), [RangeColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDrawType.html#Syncfusion_Blazor_Charts_ChartDrawType_RangeColumn), [Spline](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDrawType.html#Syncfusion_Blazor_Charts_ChartDrawType_Spline), [Scatter](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDrawType.html#Syncfusion_Blazor_Charts_ChartDrawType_Scatter), [StackingArea](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDrawType.html#Syncfusion_Blazor_Charts_ChartDrawType_StackingArea), and [StackingColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDrawType.html#Syncfusion_Blazor_Charts_ChartDrawType_StackingColumn). The default is [Line](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDrawType.html#Syncfusion_Blazor_Charts_ChartDrawType_Line).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y"
                    Type="ChartSeriesType.Radar" DrawType="ChartDrawType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> SalesReports = new List<ChartData>
	{
        new ChartData{ X = 2005, Y = 28 },
        new ChartData{ X = 2006, Y = 25 },
        new ChartData{ X = 2007, Y = 26 },
        new ChartData{ X = 2008, Y = 27 },
        new ChartData{ X = 2009, Y = 32 },
        new ChartData{ X = 2010, Y = 35 },
        new ChartData{ X = 2011, Y = 30 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/rthetYLIVhbGOOBl?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Series customization

### Start angle

Customize the start angle of the Radar Chart using the [StartAngle](https://help.syncfusion.com/cr/blazor#Syncfusion_Blazor_Charts_ChartCommonAxis_StartAngle/Syncfusion.Blazor.html/Syncfusion.Blazor.html) property. The default value is **0**.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis StartAngle="270" ValueType="Syncfusion.Blazor.Charts.ValueType.Category />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y"
                     Type="ChartSeriesType.Radar" DrawType="ChartDrawType.Line">
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
        new ChartData{ X = 2005, Y = 28 },
        new ChartData{ X = 2006, Y = 25 },
        new ChartData{ X = 2007, Y = 26 },
        new ChartData{ X = 2008, Y = 27 },
        new ChartData{ X = 2009, Y = 32 },
        new ChartData{ X = 2010, Y = 35 },
        new ChartData{ X = 2011, Y = 30 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/LXBpZPhtzpLTqzjV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Coefficient in axis

Customize the radius of the Radar Chart using the [Coefficient](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAxis.html#Syncfusion_Blazor_Charts_ChartAxis_Coefficient) property. The default value is **100**.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis Coefficient="40" ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y"
                    Type="ChartSeriesType.Radar" DrawType="ChartDrawType.Line">
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
        new ChartData{ X = 2005, Y = 28 },
        new ChartData{ X = 2006, Y = 25 },
        new ChartData{ X = 2007, Y = 26 },
        new ChartData{ X = 2008, Y = 27 },
        new ChartData{ X = 2009, Y = 32 },
        new ChartData{ X = 2010, Y = 35 },
        new ChartData{ X = 2011, Y = 30 }
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/htLJNPVjfzqCoYbb?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

Refer to the [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for more feature details and explore the [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to learn about various chart types and time-dependent data representation.

## Empty points

Data points with `null`, `double.NaN`, or `undefined` values are considered empty and are not plotted.

**Mode**

Use the [`Mode`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Mode) property to specify how empty or missing data points are handled. The default mode is [`Gap`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.EmptyPointMode.html#Syncfusion_Blazor_Charts_EmptyPointMode_Gap).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" Width="2" YName="Y"
                    Type="Syncfusion.Blazor.Charts.ChartSeriesType.Radar">
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
        new ChartData{ X = 2005, Y = 28 },
        new ChartData{ X = 2006, Y = 25 },
        new ChartData{ X = 2007, Y = 26 },
        new ChartData{ X = 2008, Y = double.NaN },
        new ChartData{ X = 2009, Y = 32 },
        new ChartData{ X = 2010, Y = 35 },
        new ChartData{ X = 2011, Y = 30 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rjhpXlLtzzpCwIHl?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Fill**

Customize the fill color of empty points using the [`Fill`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Fill) property.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" Width="2" YName="Y"
                    Type="Syncfusion.Blazor.Charts.ChartSeriesType.Radar">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Average" Fill="#FFDE59" ></ChartEmptyPointSettings>
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
        new ChartData{ X = 2005, Y = 28 },
        new ChartData{ X = 2006, Y = 25 },
        new ChartData{ X = 2007, Y = 26 },
        new ChartData{ X = 2008, Y = double.NaN },
        new ChartData{ X = 2009, Y = 32 },
        new ChartData{ X = 2010, Y = 35 },
        new ChartData{ X = 2011, Y = 30 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXLftFLZzTzHMHqg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

**Border**

Customize the border width and color of empty points using the [`Border`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointSettings.html#Syncfusion_Blazor_Charts_ChartEmptyPointSettings_Border) property, including [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointBorder.html#Syncfusion_Blazor_Charts_ChartEmptyPointBorder_Width) and [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEmptyPointBorder.html#Syncfusion_Blazor_Charts_ChartEmptyPointBorder_Color).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" Width="2" YName="Y"
                    Type="Syncfusion.Blazor.Charts.ChartSeriesType.Radar">
            <ChartEmptyPointSettings Mode="EmptyPointMode.Average" Fill="#FFDE59" >
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
        new ChartData{ X = 2005, Y = 28 },
        new ChartData{ X = 2006, Y = 25 },
        new ChartData{ X = 2007, Y = 26 },
        new ChartData{ X = 2008, Y = double.NaN },
        new ChartData{ X = 2009, Y = 32 },
        new ChartData{ X = 2010, Y = 35 },
        new ChartData{ X = 2011, Y = 30 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LZBTDFBNpJSRZBjo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Events

### Series render

The [`OnSeriesRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnSeriesRender) event enables customization of series properties, such as [Data](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Data), [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Fill), and [Series](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SeriesRenderEventArgs.html#Syncfusion_Blazor_Charts_SeriesRenderEventArgs_Series), before rendering.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartSeriesCollection>
        <ChartEvents OnSeriesRender="SeriesRender" />
        <ChartSeries DataSource="@SalesReports" XName="X" Width="2" YName="Y"
                    Type="Syncfusion.Blazor.Charts.ChartSeriesType.Radar" />
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
        new ChartData{ X = 2005, Y = 28 },
        new ChartData{ X = 2006, Y = 25 },
        new ChartData{ X = 2007, Y = 26 },
        new ChartData{ X = 2008, Y = 27 },
        new ChartData{ X = 2009, Y = 32 },
        new ChartData{ X = 2010, Y = 35 },
        new ChartData{ X = 2011, Y = 30 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LXBJZFhjfzHWXEmy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Point render

The [`OnPointRender`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartEvents.html#Syncfusion_Blazor_Charts_ChartEvents_OnPointRender) event allows customization of each data point before rendering.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartSeriesCollection>
        <ChartEvents OnPointRender="PointRender" />
        <ChartSeries DataSource="@SalesReports" XName="X" Width="2" YName="Y"
                    Type="Syncfusion.Blazor.Charts.ChartSeriesType.Radar">
            <ChartMarker Visible="true" Width="10" Height="10"></ChartMarker>
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
        new ChartData{ X = 2005, Y = 28 },
        new ChartData{ X = 2006, Y = 25 },
        new ChartData{ X = 2007, Y = 26 },
        new ChartData{ X = 2008, Y = 27 },
        new ChartData{ X = 2009, Y = 32 },
        new ChartData{ X = 2010, Y = 35 },
        new ChartData{ X = 2011, Y = 30 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rNrpNlrjpJdmOFva?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See also

* [Data label](../data-labels)
* [Tooltip](../tool-tip)
