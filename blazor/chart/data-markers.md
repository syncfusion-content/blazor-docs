---
layout: post
title: Markers in Blazor Charts Component | Syncfusion
description: Checkout and learn here all about the available Markers in Syncfusion Blazor Charts component and much more.
platform: Blazor
control: Chart
documentation: ug
---

# Markers in Blazor Charts Component

[Data markers](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonMarker.html) are used to provide information about the data points in a series. Each data point can be adorned with a shape.

<!-- markdownlint-disable MD036 -->

## Markers

<!-- markdownlint-disable MD036 -->

Markers can be added to the points by enabling the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonMarker.html#Syncfusion_Blazor_Charts_ChartCommonMarker_Visible) property to **true** of [ChartMarker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartMarker.html).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ConsumerReports" XName="X" YName="Y" Type="ChartSeriesType.Line">
            <ChartMarker Visible="true" Height="10" Width="10"/>            
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> ConsumerReports = new List<ChartData>
	{
		new ChartData{ X= 2005, Y= 28 },
		new ChartData{ X= 2006, Y= 25 },
		new ChartData{ X= 2007, Y= 26 },
		new ChartData{ X= 2008, Y= 27 },
		new ChartData{ X= 2009, Y= 32 },
		new ChartData{ X= 2010, Y= 35 },
		new ChartData{ X= 2011, Y= 30 }
	};
}

```

![Data Markers in Blazor Line Chart](images/marker/blazor-line-chart-data-marker.png)

## Shape

Markers can be assigned with different shapes such as [Rectangle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartShape.html#Syncfusion_Blazor_Charts_ChartShape_Rectangle), [Circle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartShape.html#Syncfusion_Blazor_Charts_ChartShape_Circle), [Diamond](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartShape.html#Syncfusion_Blazor_Charts_ChartShape_Diamond) etc. using the [Shape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonMarker.html#Syncfusion_Blazor_Charts_ChartCommonMarker_Shape) property.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ConsumerReports" XName="X" YName="Y" Type="ChartSeriesType.Line">
            <ChartMarker Visible="true" Height="10" Width="10" Shape="ChartShape.Diamond"/>            
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> ConsumerReports = new List<ChartData>
	{
		new ChartData{ X= 2005, Y= 28 },
		new ChartData{ X= 2006, Y= 25 },
		new ChartData{ X= 2007, Y= 26 },
		new ChartData{ X= 2008, Y= 27 },
		new ChartData{ X= 2009, Y= 32 },
		new ChartData{ X= 2010, Y= 35 },
		new ChartData{ X= 2011, Y= 30 }
	};
}

```

![Blazor Line Chart with Diamond Marker](images/marker/blazor-line-chart-diamond-marker.png)

## Auto marker shape

By default, the chart [marker shape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonMarker.html#Syncfusion_Blazor_Charts_ChartCommonMarker_Shape) is set to [Auto](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartShape.html#Syncfusion_Blazor_Charts_ChartShape_Auto). When **Auto** is set and marker is enabled in the chart at the same time, each series is rendered with a unique marker shape.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart ID="container">    
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.DateTimeCategory" Format="yyyy"></ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries Name="Series1" DataSource="@ConsumerReports" XName="X" YName="Y1" Type="ChartSeriesType.Line">
            <ChartMarker Visible="true" Height="10" Width="10" IsFilled="true"/>
        </ChartSeries>
        <ChartSeries Name="Series2" DataSource="@ConsumerReports" XName="X" YName="Y2" Type="ChartSeriesType.Line">
            <ChartMarker Visible="true" Height="10" Width="10" IsFilled="true" />
        </ChartSeries>
        <ChartSeries Name="Series3" DataSource="@ConsumerReports" XName="X" YName="Y3" Type="ChartSeriesType.Line">
            <ChartMarker Visible="true" Height="10" Width="10" IsFilled="true" />
        </ChartSeries>
        <ChartSeries Name="Series4" DataSource="@ConsumerReports" XName="X" YName="Y4" Type="ChartSeriesType.Line">
            <ChartMarker Visible="true" Height="10" Width="10" IsFilled="true" />
        </ChartSeries>
        <ChartSeries Name="Series5" DataSource="@ConsumerReports" XName="X" YName="Y5" Type="ChartSeriesType.Line">
            <ChartMarker Visible="true" Height="10" Width="10" IsFilled="true" />
        </ChartSeries>
        <ChartSeries Name="Series6" DataSource="@ConsumerReports" XName="X" YName="Y6" Type="ChartSeriesType.Line">
            <ChartMarker Visible="true" Height="10" Width="10" IsFilled="true" />
        </ChartSeries>       
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public DateTime X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
        public double Y2 { get; set; }
        public double Y3 { get; set; }
        public double Y4 { get; set; }
        public double Y5 { get; set; }
        public double Y6 { get; set; }       
    }

    public List<ChartData> ConsumerReports = new List<ChartData>
    {
        new ChartData{ X= new DateTime(2005,01,01), Y1 = 100, Y2 = 190, Y3 = 40, Y4 = 125, Y5 = 160, Y6 = 80 },
        new ChartData{ X= new DateTime(2006,01,01), Y1 = 120, Y2 = 140, Y3 = 100, Y4 = 190, Y5 = 170, Y6 = 30 },
        new ChartData{ X= new DateTime(2007,01,01), Y1 = 110, Y2 = 80, Y3 = 60, Y4 = 125, Y5 = 140, Y6 = 40 },
        new ChartData{ X= new DateTime(2008,01,01), Y1 = 40, Y2 = 120, Y3 = 75, Y4 = 180, Y5 = 150, Y6 = 90 },
        new ChartData{ X= new DateTime(2009,01,01), Y1 = 170, Y2 = 80, Y3 = 30, Y4 = 125, Y5 = 140, Y6 = 100 },
    };     
}

```

![Blazor Chart with different marker shapes](images/marker/blazor-line-chart-with-different-marker.png)

## Images

Apart from shapes, one can also add custom images to mark the data point using the [ImageUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonMarker.html#Syncfusion_Blazor_Charts_ChartCommonMarker_ImageUrl) property by specifying [Image](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartShape.html#Syncfusion_Blazor_Charts_ChartShape_Image) shape for marker.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ConsumerReports" XName="X" YName="Y" Type="ChartSeriesType.Line">
            <ChartMarker Visible="true" Shape="ChartShape.Image" Height="20" Width="20" ImageUrl="https://ej2.syncfusion.com/demos/src/chart/images/cloud.png">
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> ConsumerReports = new List<ChartData>
	{
		new ChartData{ X= 2005, Y= 28 },
		new ChartData{ X= 2006, Y= 25 },
		new ChartData{ X= 2007, Y= 26 },
		new ChartData{ X= 2008, Y= 27 },
		new ChartData{ X= 2009, Y= 32 },
		new ChartData{ X= 2010, Y= 35 },
		new ChartData{ X= 2011, Y= 30 }
	};
}

```

![Blazor Chart with image marker shape](images/marker/blazor-line-chart-image-marker.png)

## Fill marker with series color

Marker can be filled with the series color by setting [IsFilled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonMarker.html#Syncfusion_Blazor_Charts_ChartCommonMarker_IsFilled) property to **true** of [ChartMarker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartMarker.html).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ConsumerReports" XName="X" YName="Y" Type="ChartSeriesType.Line">
            <ChartMarker Visible="true" Height="10" Width="10" IsFilled="true">
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> ConsumerReports = new List<ChartData>
	{
		new ChartData{ X= 2005, Y= 28 },
		new ChartData{ X= 2006, Y= 25 },
		new ChartData{ X= 2007, Y= 26 },
		new ChartData{ X= 2008, Y= 27 },
		new ChartData{ X= 2009, Y= 32 },
		new ChartData{ X= 2010, Y= 35 },
		new ChartData{ X= 2011, Y= 30 }
	};
}

```

![Blazor Line Chart with Custom Markers](images/marker/blazor-line-chart-filled-marker.png)

## Customization

Markers color can be customized using [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonMarker.html#Syncfusion_Blazor_Charts_ChartCommonMarker_Fill) property and the border color and width can be customized based on the specified value in [ChartMarkerBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartMarkerBorder.html).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@ConsumerReports" XName="X" YName="Y" Type="ChartSeriesType.Line">
            <ChartMarker Visible="true" Height="10" Width="10" Fill="red">
                <ChartMarkerBorder Width="2" Color="blue"></ChartMarkerBorder>
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> ConsumerReports = new List<ChartData>
	{
		new ChartData{ X= 2005, Y= 28 },
		new ChartData{ X= 2006, Y= 25 },
		new ChartData{ X= 2007, Y= 26 },
		new ChartData{ X= 2008, Y= 27 },
		new ChartData{ X= 2009, Y= 32 },
		new ChartData{ X= 2010, Y= 35 },
		new ChartData{ X= 2011, Y= 30 }
	};
}

```

![Blazor Line Chart with Custom Markers](images/marker/blazor-line-chart-custom-marker.png)

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See also

* [Tooltip](./tool-tip)
* [Legend](./legend)
