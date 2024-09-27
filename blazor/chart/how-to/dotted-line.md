---
layout: post
title: Dotted Line in Blazor Charts Component | Syncfusion
description: Checkout and learn here all about Dotted Line in Syncfusion Blazor Charts component and much more details.
platform: Blazor
control: Chart
documentation: ug
---
<!-- markdownlint-disable MD036 -->

# Dotted Line in Blazor Chart Component.

By using ``Annotation``, you can add dotted lines in the chart.

To add dotted lines in the chart, follow the given steps:

Step 1:

Initialize the custom elements by using the [ChartAnnotations](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAnnotations.html#Syncfusion_Blazor_Charts_ChartAnnotations__ctor) property.

By setting [CoordinateUnits](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartAnnotation.html#Syncfusion_Blazor_Charts_ChartAnnotation_CoordinateUnits) value as [Point](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.Units.html#Syncfusion_Blazor_Charts_Units_Point) in annotation object you can placed dotted lines in the chart based on point x and y values.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Olympic Medals">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category">
    </ChartPrimaryXAxis>
    <ChartAnnotations>
        <ChartAnnotation X="@Country" Y="65" Region="Regions.Series" CoordinateUnits="Units.Point">
            <ContentTemplate >
                <div id="test" style="border-top:3px dashed grey;border-top-width: 2px; width: 10000px"></div>
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
        new ChartData{ Country= "USA", Gold=50  },
        new ChartData{ Country= "China", Gold=40 },
        new ChartData{ Country= "Japan", Gold=70 },
        new ChartData{ Country= "Australia", Gold=60},
        new ChartData{ Country= "France", Gold=50 },
        new ChartData{ Country= "Germany", Gold=40 },
        new ChartData{ Country= "Italy", Gold=40 },
        new ChartData{ Country= "Sweden", Gold=30 }
    };
}
```
![Blazor Chart With Dottedline](../images/how-to/blazor-chart-with-dottedline.png)

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.
