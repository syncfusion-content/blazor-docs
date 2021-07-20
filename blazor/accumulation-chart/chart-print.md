---
layout: post
title: Chart Print in Blazor Accumulation Chart Component | Syncfusion 
description: Learn about Chart Print in Blazor Accumulation Chart component of Syncfusion, and more details.
platform: Blazor
control: Accumulation Chart
documentation: ug
---

# Print and Export

## Print

The rendered chart can be printed directly from the browser by calling the public method print.

```csharp



@using Syncfusion.Blazor.Charts
@using Syncfusion.Blazor.Buttons

<SfAccumulationChart @ref="ChartObj" Title="Mobile Browser Statistics" EnableSmartLabels="true">
    <AccumulationChartLegendSettings Visible="false"></AccumulationChartLegendSettings>

    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users" Name="RIO" GroupTo="10">
            <AccumulationDataLabelSettings Visible="true" Name="Text" Position="AccumulationLabelPosition.Outside">
            </AccumulationDataLabelSettings>
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
</SfAccumulationChart>


<SfButton ID="button" Content="Print" @onclick="@Click" IsPrimary="true" CssClass="e-flat"></SfButton>

@code{
    SfAccumulationChart ChartObj;

    private void Click()
    {
        ChartObj.Print();
    }

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

## Export

The rendered chart can be exported to `Image`(jpeg or png) or `SVG` or `PDF` format by using the export method. Input parameters for this method are `Export` Type for `format` and `FileName` of result.

```csharp

@page "/"

@using Syncfusion.Blazor.Charts
@using Syncfusion.Blazor.Buttons

<SfAccumulationChart @ref="ChartObj" Title="Mobile Browser Statistics" EnableSmartLabels="true">
    <AccumulationChartLegendSettings Visible="false"></AccumulationChartLegendSettings>

    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users" Name="RIO" GroupTo="10">
            <AccumulationDataLabelSettings Visible="true" Name="Text" Position="AccumulationLabelPosition.Outside">
            </AccumulationDataLabelSettings>
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
</SfAccumulationChart>


<SfButton ID="button" Content="Export" @onclick="@Click" IsPrimary="true" CssClass="e-flat"></SfButton>

@code{
    SfAccumulationChart ChartObj;

    private void Click()
    {
        ChartObj.Export(ExportType.JPEG, "chart");
    }

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
        new Statistics { Browser = "Android", Users = 12 },
    };

}

```