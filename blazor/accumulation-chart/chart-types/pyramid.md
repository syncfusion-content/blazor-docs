---
layout: post
title: Pyramid in Blazor Accumulation Chart Component | Syncfusion
description: Check out and learn how to configure and customize Pyramid Chart in Syncfusion Blazor Accumulation Chart component.
platform: Blazor
control: Accumulation Chart
documentation: ug
---

# Pyramid in Blazor Accumulation Chart Component

The [Pyramid Chart](https://www.syncfusion.com/blazor-components/blazor-charts/chart-types/pyramid-chart) visualizes hierarchical data in an upside triangle shape with horizontally divided sections. To render a Pyramid Chart, set the series [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_Type) as `Pyramid`.

```cshtml

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics">
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users" Name="Browser"
								 Type="AccumulationType.Pyramid">
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>

    <AccumulationChartLegendSettings Visible="false"></AccumulationChartLegendSettings>
</SfAccumulationChart>

@code {
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
        new Statistics { Browser = "Others", Users = 4 },
        new Statistics { Browser = "Opera", Users = 11 },
        new Statistics { Browser = "Android", Users = 12 }
    };
}

```

![Blazor Pyramid Chart](../images/pyramid/blazor-pyramid-chart.png)
{% previewsample "https://blazorplayground.syncfusion.com/embed/rtBKiBiKfsBiJKAT?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Pyramid mode

Render the Pyramid Chart in `Linear` or `Surface` modes using the [PyramidMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_PyramidMode) property.

```cshtml

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics">
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users" Name="Browser"
								 Type="AccumulationType.Pyramid" PyramidMode="PyramidMode.Surface">
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>

    <AccumulationChartLegendSettings Visible="false"></AccumulationChartLegendSettings>
</SfAccumulationChart>

@code {
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
        new Statistics { Browser = "Others", Users = 4 },
        new Statistics { Browser = "Opera", Users = 11 },
        new Statistics { Browser = "Android", Users = 12 }
    };
}

```

![Blazor Pyramid Chart with Surface Mode](../images/pyramid/blazor-pyramid-chart-with-surface-mode.png)
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXrAiBsKJsKsjaYg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Pyramid size

Customize the pyramid chart size using the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_Height) properties.

```cshtml

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics">
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users"
                                 Name="Browser" Type="AccumulationType.Pyramid" Width="60%" Height="80%">
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>

    <AccumulationChartLegendSettings Visible="false"></AccumulationChartLegendSettings>
</SfAccumulationChart>

@code {
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
        new Statistics { Browser = "Android", Users = 12 }
    };
}

```

![Customizing Pyramid Size in Blazor Pyramid Chart](../images/pyramid/blazor-pyramid-chart-size.png)
{% previewsample "https://blazorplayground.syncfusion.com/embed/VZBAMLiAzszQHxDQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Gap between pyramid segments

Customize the space between segments using the [GapRatio](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_GapRatio) property. It accepts values ranging from 0 to 1.

```cshtml

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics">
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users" Name="Browser"
								 Type="AccumulationType.Pyramid" GapRatio="0.2">
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>

    <AccumulationChartLegendSettings Visible="false"></AccumulationChartLegendSettings>
</SfAccumulationChart>

@code {
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
        new Statistics { Browser = "Others", Users = 4 },
        new Statistics { Browser = "Opera", Users = 11 },
        new Statistics { Browser = "Android", Users = 12 }
    };
}

```

![Blazor Pyramid Chart with Gap](../images/pyramid/blazor-pyramid-chart-with-gap.png)
{% previewsample "https://blazorplayground.syncfusion.com/embed/rXVUWhiKJsShBUhS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Pyramid explode

Explode points on mouse click by setting the [Explode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_Explode) property to **true**. Use [ExplodeIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_ExplodeIndex) and [ExplodeOffset](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_ExplodeOffset) for further customization.

```cshtml

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics">
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users" Name="Browser"
                                 Type="AccumulationType.Pyramid" ExplodeIndex="2" Explode="true" ExplodeOffset="10">
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>

    <AccumulationChartLegendSettings Visible="false"></AccumulationChartLegendSettings>
</SfAccumulationChart>

@code {
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
        new Statistics { Browser = "Others", Users = 4 },
        new Statistics { Browser = "Opera", Users = 11 },
        new Statistics { Browser = "Android", Users = 12 }
    };
}

```

![Explode in Blazor Pyramid Chart](../images/pyramid/blazor-pyramid-chart-explode.png)
{% previewsample "https://blazorplayground.syncfusion.com/embed/BthAMBMATgJWwkNT?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Border radius

The corners of the first data point and last data point in the pyramid chart series can be rounded using the [BorderRadius](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_BorderRadius) property within the [AccumulationChartSeries](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html).

```cshtml

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Food Consumption Pyramid">
    <AccumulationChartLegendSettings Visible="false">
    </AccumulationChartLegendSettings>
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@PyramidChartPoints" XName="Foods" YName="Percentage" Type="AccumulationType.Pyramid" Width="45%" Height="80%" BorderRadius="8">
            <AccumulationDataLabelSettings Visible="true" Position="AccumulationLabelPosition.Outside" Name="DataLabelMappingName">
            </AccumulationDataLabelSettings>
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
</SfAccumulationChart>

@code {
    public class PyramidData
    {
        public string Foods { get; set; }
        public double Percentage { get; set; }
        public string DataLabelMappingName { get; set; }
    }

    public List<PyramidData> PyramidChartPoints { get; set; } = new List<PyramidData>
    {
          new PyramidData { Foods = "Oils", Percentage = 2, DataLabelMappingName = "Oils: 2%" },
          new PyramidData { Foods = "Nuts", Percentage = 10, DataLabelMappingName = "Nuts: 10%" },
          new PyramidData { Foods = "Fruits", Percentage = 15, DataLabelMappingName = "Fruits: 15%" },
          new PyramidData { Foods = "Dairy", Percentage = 23, DataLabelMappingName = "Dairy: 23%" },
          new PyramidData { Foods = "Vegetables", Percentage = 23, DataLabelMappingName = "Vegetables: 23%" },
          new PyramidData { Foods = "Grains", Percentage = 27, DataLabelMappingName = "Grains: 27%"}
    };
}

```

![Blazor Pyramid Chart with border radius applied.](../images/pyramid/blazor-pyramid-border-radius.png)
{% previewsample "https://blazorplayground.syncfusion.com/embed/LthyDHBRqlAFfKbF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> Refer to the [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore the [Blazor Accumulation Chart Example](https://blazor.syncfusion.com/demos/chart/pyramid?theme=bootstrap5) to know various features of accumulation charts and how it is used to represent numeric proportional data.

## See also

* [Data label](../data-label)
* [Grouping](../grouping)
