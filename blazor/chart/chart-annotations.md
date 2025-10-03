---
layout: post
title: Annotation in Blazor Charts Component | Syncfusion
description: Check out and learn how to configure and customize Annotation in Syncfusion Blazor Charts component.
platform: Blazor
control: Chart
documentation: ug
---

# Annotation in Blazor Charts Component

Annotations are texts, shapes, or images used to highlight specific regions of interest in a chart.

Learn how to add Annotations to Blazor Charts by watching the video below.

{% youtube "youtube:https://www.youtube.com/watch?v=TpUoXrYlCkU" %}

The [ChartAnnotations](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAnnotations.html) allows annotations to be added to the chart. The [Content](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAnnotation.html#Syncfusion_Blazor_Charts_ChartAnnotation_Content) property specifies the element to display in the chart area.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
	
    <ChartAnnotations>
        <ChartAnnotation X="@data" Y="65" CoordinateUnits="Units.Point">
            <ContentTemplate>
                <div style="color: firebrick; font-size: medium; font-style: italic">Highest Medal Count</div>
            </ContentTemplate>
        </ChartAnnotation>
    </ChartAnnotations>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="Country" YName="Gold" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    string data = "France";
	
    public class ChartData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
    }
	
    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData { Country = "USA", Gold = 50 },
        new ChartData { Country = "China", Gold = 40 },
        new ChartData { Country = "Japan", Gold = 70 },
        new ChartData { Country = "Australia", Gold = 60},
        new ChartData { Country = "France", Gold = 50 },
        new ChartData { Country = "Germany", Gold = 40 },
        new ChartData { Country = "Italy", Gold = 40 },
        new ChartData { Country = "Sweden", Gold = 30 }
    };
}

```

![Annotation in Blazor Column chart](images/annotation/blazor-column-chart-annotation.png)

## Region

Use the [Region](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAnnotation.html#Syncfusion_Blazor_Charts_ChartAnnotation_Region) property to position annotations relative to a series or the chart. By default, annotations are positioned with respect to the [Chart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.Regions.html#Syncfusion_Blazor_Charts_Regions_Chart).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartAnnotations>
        <ChartAnnotation X="@Country" Y="65" Region="Regions.Series" CoordinateUnits="Units.Point">
            <ContentTemplate>
                <div>Highest Medal Count</div>
            </ContentTemplate>
        </ChartAnnotation>
    </ChartAnnotations>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="Country" YName="Gold" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    string Country = "Australia";
	
    public class ChartData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
    }
	
    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData { Country = "USA", Gold = 50 },
        new ChartData { Country = "China", Gold = 40 },
        new ChartData { Country = "Japan", Gold = 70 },
        new ChartData { Country = "Australia", Gold = 60},
        new ChartData { Country = "France", Gold = 50 },
        new ChartData { Country = "Germany", Gold = 40 },
        new ChartData { Country = "Italy", Gold = 40 },
        new ChartData { Country = "Sweden", Gold = 30 }
    };
}

```

![Inserting Annotations using Region in Blazor Column Chart](images/annotation/blazor-column-chart-annotation-using-region.png)

## Coordinate units

Set the annotation's coordinate units using the [CoordinateUnits](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAnnotation.html#Syncfusion_Blazor_Charts_ChartAnnotation_CoordinateUnits) property. Choose between [Pixel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.Units.html#Syncfusion_Blazor_Charts_Units_Pixel) or [Point](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.Units.html#Syncfusion_Blazor_Charts_Units_Point).

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartAnnotations>
        <ChartAnnotation X="250" Y="100" CoordinateUnits="Units.Pixel">
            <ContentTemplate>
                <div>Annotation in Pixel</div>
            </ContentTemplate>
        </ChartAnnotation>
    </ChartAnnotations>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@MedalDetails" XName="Country" YName="Gold" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string Country { get; set; }
        public double Gold { get; set; }
    }
	
    public List<ChartData> MedalDetails = new List<ChartData>
    {
        new ChartData { Country = "USA", Gold = 50 },
        new ChartData { Country = "China", Gold = 40 },
        new ChartData { Country = "Japan", Gold = 70 },
        new ChartData { Country = "Australia", Gold = 60},
        new ChartData { Country = "France", Gold = 50 },
        new ChartData { Country = "Germany", Gold = 40 },
        new ChartData { Country = "Italy", Gold = 40 },
        new ChartData { Country = "Sweden", Gold = 30 }
    };
}

```

![Inserting Annotation using Coordinate in Blazor Column Chart](images/annotation/blazor-column-chart-coordinate-annotation.png)

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See also

* [Tooltip](./tool-tip)
* [Legend](./legend)
