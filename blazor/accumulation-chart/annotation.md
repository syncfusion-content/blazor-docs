---
layout: post
title: Annotation in Blazor Accumulation Chart Component | Syncfusion 
description: Learn about Annotation in Blazor Accumulation Chart component of Syncfusion, and more details.
platform: Blazor
control: Accumulation Chart
documentation: ug
---

# Annotation

Annotations are used to mark the specific area of interest in the chart with texts, shapes or images. By using the [`Content`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartAnnotation.html#Syncfusion_Blazor_Charts_AccumulationChartAnnotation_Content) option of annotation property, you can specify the Id of the HTML element that needs to be displayed in the chart.

```csharp

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics">
    <AccumulationChartLegendSettings Visible="false"></AccumulationChartLegendSettings>

    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users" Name="Browser">
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>

    <AccumulationChartAnnotations>
        <AccumulationChartAnnotation X="iPhone" Y=19 CoordinateUnits="@Syncfusion.Blazor.Charts.Units.Point" Region="@Syncfusion.Blazor.Charts.Regions.Series">
            <ContentTemplate>
                <div style='border: 1px solid black;background-color:red;padding: 5px 5px 5px 5px'>19</div>
            </ContentTemplate>
        </AccumulationChartAnnotation>
    </AccumulationChartAnnotations>
</SfAccumulationChart>

@code{
    public class Statistics
    {
        public string Browser { get; set; }
        public double Users { get; set; }
    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
{
        new Statistics { Browser = "Chrome", Users = 37 },
        new Statistics { Browser = "UC Browser", Users = 17 },
        new Statistics { Browser = "iPhone", Users = 19 },
        new Statistics { Browser = "Others", Users = 4  },
        new Statistics { Browser = "Opera", Users = 11 },
        new Statistics { Browser = "Android", Users = 12 },
    };
}

```

![Annotation](images/annotation/annotation-razor.png)

## Region

The annotation can be placed with respect to `Series` or `Chart`.

```csharp

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics">
    <AccumulationChartLegendSettings Visible="false"></AccumulationChartLegendSettings>

    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users" Name="Browser">
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>

    <AccumulationChartAnnotations>
        <AccumulationChartAnnotation X=350 Y=180 CoordinateUnits="@Syncfusion.Blazor.Charts.Units.Pixel" Region="@Syncfusion.Blazor.Charts.Regions.Chart">
            <ContentTemplate>
                <div style='border: 1px solid black;background-color:red;padding: 5px 5px 5px 5px'>19</div>
            </ContentTemplate>
        </AccumulationChartAnnotation>
    </AccumulationChartAnnotations>
</SfAccumulationChart>

@code{
    public class Statistics
    {
        public string Browser { get; set; }
        public double Users { get; set; }
    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
{
        new Statistics { Browser = "Chrome", Users = 37 },
        new Statistics { Browser = "UC Browser", Users = 17 },
        new Statistics { Browser = "iPhone", Users = 19 },
        new Statistics { Browser = "Others", Users = 4  },
        new Statistics { Browser = "Opera", Users = 11 },
        new Statistics { Browser = "Android", Users = 12 },
    };
}

```

![Region](images/annotation/region-razor.png)

## Co-ordinate Units

Specifies the [`CoordinateUnits`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartAnnotation.html#Syncfusion_Blazor_Charts_AccumulationChartAnnotation_CoordinateUnits) of an annotation either in `Pixel` or `Point`.

```csharp

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics">
    <AccumulationChartLegendSettings Visible="false"></AccumulationChartLegendSettings>

    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users" Name="Browser">
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>

    <AccumulationChartAnnotations>
        <AccumulationChartAnnotation X="Chrome" Y="37" CoordinateUnits="@Syncfusion.Blazor.Charts.Units.Point" Region="@Syncfusion.Blazor.Charts.Regions.Series">
            <ContentTemplate>
                <div style='border: 1px solid black;background-color:red;padding: 5px 5px 5px 5px'>Chrome:37</div>
            </ContentTemplate>
        </AccumulationChartAnnotation>
    </AccumulationChartAnnotations>
</SfAccumulationChart>

@code{
    public class Statistics
    {
        public string Browser { get; set; }
        public double Users { get; set; }
    }

    public List<Statistics> StatisticsDetails = new List<Statistics>
{
        new Statistics { Browser = "Chrome", Users = 37 },
        new Statistics { Browser = "UC Browser", Users = 17 },
        new Statistics { Browser = "iPhone", Users = 19 },
        new Statistics { Browser = "Others", Users = 4  },
        new Statistics { Browser = "Opera", Users = 11 },
        new Statistics { Browser = "Android", Users = 12 },
    };
}

```

![Co-ordinate Units](images/annotation/co-ordinate-razor.png)