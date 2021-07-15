---
layout: post
title: Internationalization in Blazor Chart Component | Syncfusion 
description: Learn about Internationalization in Blazor Chart component of Syncfusion, and more details.
platform: Blazor
control: Chart
documentation: ug
---

# Internationalization

Chart provide supports for internationalization for below chart elements.

* Datalabel.
* Axis label.
* Tooltip.

<!-- markdownlint-disable MD036 -->
**Globalization**

Globalization is the process of designing and developing an component that works in different
cultures/locales.  Internationalization  library is used to globalize number, date, time values in
chart component using [`LabelFormat`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartCommonAxis.html#Syncfusion_Blazor_Charts_ChartCommonAxis_LabelFormat) property in axis.

**Numeric Format**

In the below example, axis, point  and tooltip labels are globalized to EUR.

```csharp

@using Syncfusion.Blazor.Charts

<SfChart Title="Average Sales Comparison">
    <ChartPrimaryXAxis Title="Year"></ChartPrimaryXAxis>

    <ChartPrimaryYAxis LabelFormat="c" Title="Sales Amount in Millions">
    </ChartPrimaryYAxis>

    <ChartTooltipSettings Enable="true" Format="${series.name} <br>${point.x} : ${point.y}">
    </ChartTooltipSettings>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y" Type="ChartSeriesType.Column" Name="Product X">
            <ChartMarker>
                <ChartDataLabel Visible="true"></ChartDataLabel>
            </ChartMarker>
        </ChartSeries>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y1" Type="ChartSeriesType.Column" Name="Product Y">
            <ChartMarker>
                <ChartDataLabel Visible="true"></ChartDataLabel>
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Y1 { get; set; }
    }

    public List<ChartData> SalesReports = new List<ChartData>
{
         new ChartData {X= 1900, Y= 4, Y1= 2.6 },
         new ChartData{ X= 1920, Y= 3.0, Y1= 2.8 },
         new ChartData{ X= 1940, Y= 3.8, Y1= 2.6},
         new ChartData{ X= 1960, Y= 3.4, Y1= 3 },
         new ChartData{ X= 1980, Y= 3.2, Y1= 3.6 },
         new ChartData{ X= 2000, Y= 3.9, Y1= 3 }
    };
}


```

![Globalization](images/internationalization.png)

> Note: You can refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations. You can also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to knows various chart types and how to represent time-dependent data, showing trends in data at equal intervals.

## See Also

* [Data label](./data-labels)
* [Tooltip](./tool-tip)
* [Legend](./legend)
* [Marker](./data-markers)