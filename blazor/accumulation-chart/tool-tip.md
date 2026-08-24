---
layout: post
title: Blazor Accumulation Chart Tooltip Examples | Syncfusion®
description: Learn how to enable and customize tooltips in Syncfusion Blazor Accumulation Chart, including format, template, and styling.
platform: Blazor
control: Accumulation Chart
documentation: ug
---

# Blazor Accumulation Chart Tooltip

The [Enable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartTooltipSettings.html#Syncfusion_Blazor_Charts_AccumulationChartTooltipSettings_Enable) property in [AccumulationChartTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartTooltipSettings.html) can be set to **true** to enable the tooltip.

```cshtml 

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics">
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users" Name="Browser">
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
    <AccumulationChartLegendSettings Visible="false"></AccumulationChartLegendSettings>
    <AccumulationChartTooltipSettings Enable="true"></AccumulationChartTooltipSettings>
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDLdjcBNUGJVcxJU?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Accumulation Chart displays ToolTip](images/tool-tip/blazor-accumulation-chart-tooltip.webp)" %}

## Header

The [Header](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartTooltipSettings.html#Syncfusion_Blazor_Charts_AccumulationChartTooltipSettings_Header) property in [AccumulationChartTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartTooltipSettings.html) can be used to specify the tooltip's header.

```cshtml 

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics">
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users" Name="Browser">
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
    <AccumulationChartLegendSettings Visible="false"></AccumulationChartLegendSettings>
    <AccumulationChartTooltipSettings Enable="true" Header="Mobile Browser"></AccumulationChartTooltipSettings>
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNVxZQhXgwmACcLQ?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Accumulation Chart displays ToolTip for Header](images/tool-tip/blazor-accumulation-chart-header-tooltip.webp)" %}

## Tooltip Format

By default, the tooltip shows information about the x and y values of points. In addition, further customization can be done in the tooltip. For example, the format `${point.x} : <b>${point.y}%</b>` shows the point's x value and a customized point's y value.

```cshtml 

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics">
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users" Name="Browser">
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
    <AccumulationChartLegendSettings Visible="false"></AccumulationChartLegendSettings>
    <AccumulationChartTooltipSettings Enable="true" Format="${point.x} -> <b>${point.y} users</b>"></AccumulationChartTooltipSettings>
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDrRDQBjAGGupkey?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Customizing ToolTip Format in Blazor Accumulation Chart](images/tool-tip/blazor-accumulation-chart-tooltip-format.webp)" %}

## Tooltip Customization

The [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartTooltipSettings.html#Syncfusion_Blazor_Charts_AccumulationChartTooltipSettings_Fill) and [AccumulationChartTooltipBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartTooltipBorder.html) are used to customize the background color and the border of the tooltip respectively. The [AccumulationChartTooltipTextStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartTooltipTextStyle.html) in the tooltip is used to customize the font size of the tooltip text. The [HighlightColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfAccumulationChart.html#Syncfusion_Blazor_Charts_SfAccumulationChart_HighlightColor) property can be used to change the color of the data point when hovering.

```cshtml 

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics" HighlightColor="#9933ff">
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users" Name="Browser">
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
    <AccumulationChartLegendSettings Visible="false"></AccumulationChartLegendSettings>
    <AccumulationChartTooltipSettings Enable="true" Format="${point.x} : <b>${point.y}</b>" Fill="#7bb4eb">
        <AccumulationChartTooltipBorder Color="red" Width="2"></AccumulationChartTooltipBorder>
    </AccumulationChartTooltipSettings>
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZrHXmhjgcYZRwkM?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Customizing Tooltip in Blazor Accumulation Chart](images/tool-tip/blazor-accumulation-chart-tooltip-customization.webp)" %}

## Tooltip Text Mapping

By default, the tooltip shows information about the x and y values of points. In addition, by using the [TooltipMappingName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartSeries.html#Syncfusion_Blazor_Charts_AccumulationChartSeries_TooltipMappingName), more information from the data source can be displayed in the tooltip. To display the specified tooltip content, **$point.tooltip** can be used as a placeholder.

```cshtml 

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Sales Analysis">
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="XValue" YName="YValue" TooltipMappingName="Text">
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
    <AccumulationChartLegendSettings Visible="false"></AccumulationChartLegendSettings>
    <AccumulationChartTooltipSettings Enable="true" Format="${point.tooltip}" ></AccumulationChartTooltipSettings>
</SfAccumulationChart>

@code{
    public class ChartData
    {
        public string XValue { get; set; }
        public double YValue { get; set; }
        public string Text { get; set; }
    }

    public List<ChartData> StatisticsDetails = new List<ChartData>
    {
       new ChartData { XValue = "Jan", YValue = 3, Text= "Jan: 3M" },
       new ChartData { XValue = "Feb", YValue = 3.5, Text= "Feb: 3.5M" },
       new ChartData { XValue = "Mar", YValue = 7, Text= "Mar: 7M" },
       new ChartData { XValue = "Apr", YValue = 3.5, Text= "Apr: 13.5M" },
       new ChartData { XValue = "May", YValue = 19, Text= "May: 19M" },
       new ChartData { XValue = "Jun", YValue = 23.5, Text= "Jun: 23.5M" },
       new ChartData { XValue = "Jul", YValue = 26, Text= "Jul: 26M" },
       new ChartData { XValue = "Aug", YValue = 25, Text= "Aug: 25M" },
       new ChartData { XValue = "Sep", YValue = 21, Text= "Sep: 21M" },
       new ChartData { XValue = "Oct", YValue = 15, Text= "Oct: 15M" },
       new ChartData { XValue = "Nov", YValue = 9, Text= "Nov: 9M" },
       new ChartData { XValue = "Dec", YValue = 3.5, Text= "Dec: 3.5M" }
   };
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNBdZmLDKlhVVFzn?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[ToolTip Text Mapping in Blazor Accumulation Chart](images/tool-tip/blazor-accumulation-chart-tooltip-mapping.webp)" %}

N> Refer to the [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore the [Blazor Accumulation Chart Example](https://blazor.syncfusion.com/demos/chart/pie?theme=fluent2) to know about the various features of accumulation charts and how it is used to represent numeric proportional data.

## Tooltip Template

For a fully customized tooltip body, set the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartTooltipSettings.html#Syncfusion_Blazor_Charts_AccumulationChartTooltipSettings_Template) property of the [AccumulationChartTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.AccumulationChartTooltipSettings.html) to a `RenderFragment` (or, in older APIs, to a string of HTML). The template receives an `AccumulationChartDataPointInfo` context from which you can read the data row fields via `Data` and the formatted Y value via `Y`. Templates are useful when you want to embed images, custom HTML, multiple data fields, or a localized layout that the standard `Format` placeholder cannot express.

```cshtml

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics">
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@StatisticsDetails" XName="Browser" YName="Users" Name="Browser">
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
    <AccumulationChartLegendSettings Visible="false"></AccumulationChartLegendSettings>
    <AccumulationChartTooltipSettings Enable="true">
        <Template>
            @{
                var info = context as AccumulationChartDataPointInfo;
            }

            <div class="chart-tooltip">
                <div class="tooltip-header">
                    @info?.Data.PointX
                </div>

                <div class="tooltip-content">
                    <div class="tooltip-row">
                        <span>Users</span>
                        <span class="value">@info?.Data.PointY</span>
                    </div>

                    <div class="tooltip-row">
                        <span>Share</span>
                        <span class="value">@info?.Y%</span>
                    </div>
                </div>
            </div>
        </Template>
    </AccumulationChartTooltipSettings>
</SfAccumulationChart>
<style>
    .chart-tooltip {
        min-width: 160px;
        background: #ffffff;
        border-radius: 12px;
        overflow: hidden;
        box-shadow: 0 8px 24px rgba(0,0,0,.15);
        border: 1px solid #e5e7eb;
        font-family: "Segoe UI", sans-serif;
    }
    .tooltip-header {
        background: linear-gradient(135deg, #6366f1, #8b5cf6);
        color: white;
        padding: 10px 14px;
        font-size: 14px;
        font-weight: 600;
    }
    .tooltip-content {
        padding: 12px 14px;
    }
    .tooltip-row {
        display: flex;
        justify-content: space-between;
        align-items: center;
        margin-bottom: 6px;
        font-size: 13px;
        color: #4b5563;
    }
    .tooltip-row:last-child {
        margin-bottom: 0;
    }

    .tooltip-row .value {
        font-weight: 600;
        color: #111827;
    }
</style>
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
        new Statistics { Browser = "Android", Users = 12 },
    };
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZrdjFBTKlGPYDWf?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[ToolTip Template in Blazor Accumulation Chart](images/tool-tip/blazor-accumulation-chart-tooltip-template.webp)" %}

## See also

* [Grouping](./grouping)
* [Data label](./data-label)