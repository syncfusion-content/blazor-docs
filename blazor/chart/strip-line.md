---
layout: post
title: Stripline in Blazor Charts Component | Syncfusion
description: Learn here all about Stripline in Syncfusion Blazor Charts component and more.
platform: Blazor
control: Chart
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Stripline in Blazor Charts Component

<!-- markdownlint-disable MD036 -->

Blazor chart supports horizontal and vertical strip lines and customization of stripline in both orientation.

## Horizontal Striplines

You can create horizontal stripline by adding the [`ChartStripline`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisModel.html#Syncfusion_Blazor_Charts_AxisModel_StripLines) in the vertical axis.
Striplines are rendered in the specified start to end range and you can add more than one stripline for an axis.

```csharp

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"/>    

    <ChartPrimaryYAxis>
        <ChartStriplines>
            <ChartStripline Start="20" End="25" Color="red"/>
            <ChartStripline Start="32" End="35" Color="blue"/>
        </ChartStriplines>
    </ChartPrimaryYAxis>

    <ChartSeriesCollection>
        <ChartSeries Type="ChartSeriesType.Column" DataSource="@WeatherReports" XName="X" YName="Y">
        </ChartSeries>
    </ChartSeriesCollection>

</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> WeatherReports = new List<ChartData>
{
    new ChartData { X = "Sun", Y = 28 },
    new ChartData { X = "Mon", Y = 27 },
    new ChartData { X = "Tue", Y = 33 },
    new ChartData { X = "Wed", Y = 36 },
    new ChartData { X = "Thu", Y = 28 },
    new ChartData { X = "Fri", Y = 30 },
    new ChartData { X = "Sat", Y = 31 }
    };
}

```

![Horizontal Strip lines](images/strip-line/horizontal.png)

## Vertical Striplines

You can create vertical stripline by adding the [`ChartStripline`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AxisModel.html#Syncfusion_Blazor_Charts_AxisModel_StripLines) in the horizontal axis. Striplines are rendered in the specified start to end range and you can add more than one stripline for an axis.

```csharp

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
        <ChartStriplines>
            <ChartStripline Start="2" End="3" Color="#EEFFCC" />
            <ChartStripline Start="4" End="5" Color="pink" />
        </ChartStriplines>
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries Type="ChartSeriesType.Column" DataSource="@WeatherReports" XName="X" YName="Y">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> WeatherReports = new List<ChartData>
    {
    new ChartData { X = "Sun", Y = 28 },
    new ChartData { X = "Mon", Y = 27 },
    new ChartData { X = "Tue", Y = 33 },
    new ChartData { X = "Wed", Y = 36 },
    new ChartData { X = "Thu", Y = 28 },
    new ChartData { X = "Fri", Y = 30 },
    new ChartData { X = "Sat", Y = 31 }
    };

}

```

![Vertical Striplines](images/strip-line/vertical.png)

## Customize the strip line

Starting value in specific strip line can be customized by [`Start`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonStripLines.html#Syncfusion_Blazor_Charts_ChartCommonStripLines_Start) property in strip line. Similarly, end value
is customized by [`End`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonStripLines.html#Syncfusion_Blazor_Charts_ChartCommonStripLines_End).
Size and border of the strip line can be customized by [`Size`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonStripLines.html#Syncfusion_Blazor_Charts_ChartCommonStripLines_Size) and  [`Border`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonStripLines.html#Syncfusion_Blazor_Charts_ChartCommonStripLines_Border) properties.
Order of the strip line such that whether it should be rendered  behind or over the series elements
can be customized by [`ZIndex`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonStripLines.html#Syncfusion_Blazor_Charts_ChartCommonStripLines_ZIndex) property.

```csharp

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
        <ChartStriplines>
            <ChartStripline StartFromAxis="true" Size="4" ZIndex="ZIndex.Behind" Opacity="0.5" Color="green"/>
        </ChartStriplines>
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries Type="ChartSeriesType.Column" DataSource="@WeatherReports" XName="X" YName="Y">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{

    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> WeatherReports = new List<ChartData>
{
    new ChartData { X = "Sun", Y = 28 },
    new ChartData { X = "Mon", Y = 27 },
    new ChartData { X = "Tue", Y = 33 },
    new ChartData { X = "Wed", Y = 36 },
    new ChartData { X = "Thu", Y = 28 },
    new ChartData { X = "Fri", Y = 30 },
    new ChartData { X = "Sat", Y = 31 }
};

}

```

![Customize the strip line](images/strip-line/custom-stripline.png)

## Customize the stripline text

You can customize and rotate the text rendered in stripline by [`TextStyle`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonStripLines.html#Syncfusion_Blazor_Charts_ChartCommonStripLines_TextStyle) and [`Rotation`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartStripLine.html) properties.
Horizontal and Vertical alignment of stripline text can be customized by [`HorizontalAlignment`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonStripLines.html#Syncfusion_Blazor_Charts_ChartCommonStripLines_HorizontalAlignment) and [`VerticalAlignment`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonStripLines.html#Syncfusion_Blazor_Charts_ChartCommonStripLines_VerticalAlignment) property.

```csharp

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
        <ChartStriplines>
            <ChartStripline StartFromAxis="true" Size="4" ZIndex="ZIndex.Behind" Opacity="0.5" Color="green" Text="Good"
                            HorizontalAlignment="Anchor.Middle" VerticalAlignment="Anchor.Middle">
                <ChartStriplineTextStyle Size="15px"/>
            </ChartStripline>
        </ChartStriplines>
    </ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries Type="ChartSeriesType.Column" DataSource="@WeatherReports" XName="X" YName="Y">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{

    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> WeatherReports = new List<ChartData>
{
    new ChartData { X = "Sun", Y = 28 },
    new ChartData { X = "Mon", Y = 27 },
    new ChartData { X = "Tue", Y = 33 },
    new ChartData { X = "Wed", Y = 36 },
    new ChartData { X = "Thu", Y = 28 },
    new ChartData { X = "Fri", Y = 30 },
    new ChartData { X = "Sat", Y = 31 }
};

}

```

![Customize the strip line](images/strip-line/custom-striptext.png)

> Note: You can refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations. You can also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to knows various chart types and how to represent time-dependent data, showing trends in data at equal intervals.

## See Also

* [Data label](./data-labels)
* [Tooltip](./tool-tip)
* [Marker](./data-markers)