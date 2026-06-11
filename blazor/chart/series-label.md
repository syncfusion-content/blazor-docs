---
layout: post
title: Series Label in Blazor Charts Component | Syncfusion
description: Check out and learn here all about the Series label in the Syncfusion Blazor Charts component and much more.
platform: Blazor
control: Chart
documentation: ug
keywords: Blazor Chart series label, series label, chart labels, inline series labels, chart series customization, SeriesLabelSettings
---

# Series Label in Blazor Charts Component

The series label feature displays the name of each series directly within the chart area. This improves readability by helping users identify series inline and reduces reliance on the legend.

This feature is especially useful in multi-series visualizations and exported charts, where quick in-chart identification is important. It is currently supported for Line , Area, scatter , Column, and Bar series, as well as Polar Line and Radar Line series. Series labels can be enabled and customized using the `SeriesLabelSettings` property.

## Enable series label

To display series labels, set the `Visible` property of `SeriesLabelSettings` to `true` for the required series.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Startup Growth Metrics Over 6 Months" Width="100%" Height="450px">
    <ChartArea>
        <ChartAreaBorder Width="0" />
    </ChartArea>
    <ChartMargin Left="10" Right="10" Top="20" Bottom="20" />
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" Title="Month">
        <ChartAxisMajorGridLines Width="0" />
        <ChartAxisMajorTickLines Width="0" />
    </ChartPrimaryXAxis>
    <ChartPrimaryYAxis Title="Count / Score" Minimum="0" Maximum="600" Interval="100">
        <ChartAxisLineStyle Width="0" />
        <ChartAxisMajorTickLines Width="0" />
    </ChartPrimaryYAxis>
    <ChartTooltipSettings Enable="true" Header="<b>${series.name}</b>" Format="${point.x} : <b>${point.y}</b>" />
    <ChartLegendSettings Visible="true" Position="LegendPosition.Bottom" />
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ActiveUsersData" Name="Active Users" XName="Month" YName="Value" Type="ChartSeriesType.Line" Width="3" Fill="#4F65F1">
            <ChartMarker Visible="true" Width="10" Height="10" IsFilled="true" Shape="ChartShape.Circle" />
            <SeriesLabelSettings Visible="true"> </SeriesLabelSettings>
        </ChartSeries>
        <ChartSeries DataSource="@SupportTicketsData" Name="Support Tickets" XName="Month" YName="Value" Type="ChartSeriesType.Line" Width="3" Fill="#E6951A">
            <ChartMarker Visible="true" Width="10" Height="10" IsFilled="true" Shape="ChartShape.Diamond" />
            <SeriesLabelSettings Visible="true"> </SeriesLabelSettings>
        </ChartSeries>
        <ChartSeries DataSource="@FeatureRequestsData" Name="Feature Requests" XName="Month" YName="Value" Type="ChartSeriesType.Line" Width="3" Fill="#2DBE60">
            <ChartMarker Visible="true" Width="10" Height="10" IsFilled="true" Shape="ChartShape.Triangle" />
            <SeriesLabelSettings Visible="true"> </SeriesLabelSettings>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class MetricData
    {
        public string Month { get; set; }
        public double Value { get; set; }
    }

    public List<MetricData> ActiveUsersData = new()
    {
        new MetricData { Month = "Feb", Value = 420 },
        new MetricData { Month = "Mar", Value = 460 },
        new MetricData { Month = "Apr", Value = 445 },
        new MetricData { Month = "May", Value = 495 },
        new MetricData { Month = "Jun", Value = 535 }
    };

    public List<MetricData> SupportTicketsData = new()
    {
        new MetricData { Month = "Feb", Value = 210 },
        new MetricData { Month = "Mar", Value = 240 },
        new MetricData { Month = "Apr", Value = 225 },
        new MetricData { Month = "May", Value = 260 },
        new MetricData { Month = "Jun", Value = 275 }
    };

    public List<MetricData> FeatureRequestsData = new()
    {
        new MetricData { Month = "Feb", Value = 65 },
        new MetricData { Month = "Mar", Value = 78 },
        new MetricData { Month = "Apr", Value = 72 },
        new MetricData { Month = "May", Value = 95 },
        new MetricData { Month = "Jun", Value = 108 }
    };
}

```

![Blazor line chart displaying inline series labels](images/series-label/blazor-line-chart-series-label.webp)

## Customization

You can customize the appearance of the series label using the following properties.

### SeriesLabelSettings Properties

Configure the main series label appearance:

* `Text`: Specifies the custom text to be displayed in the series label. If this property is not set, the label displays the corresponding series name by default.
* `Background`: Specifies the background color of the series label. This helps the label stand out clearly within the chart area.
* `Opacity`:  Specifies the transparency level of the series label. The accepted range is from 0 to 1, where 0 represents full transparency and 1 represents full opacity.
* `ShowOverlapText`: Determines whether overlapping series labels should be displayed. This is useful when labels overlap because the corresponding series are positioned close to one another.

In the `SeriesLabelBorder`:
* `Color`: Specifies the border color of the series label. This can be used to visually separate the label from the chart background.
* `Width`: Specifies the width of the border around the series label. A higher value makes the border more visible.

In the `SeriesLabelFont`:
* `Size`: Specifies the font size of the label text.
* `Color`: Specifies the font color of the label text.
* `FontFamily`: Specifies the font family of the label text.
* `FontWeight`: Specifies the font weight of the label text.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Startup Growth Metrics Over 6 Months" Width="100%" Height="450px">
    <ChartArea>
        <ChartAreaBorder Width="0" />
    </ChartArea>
    <ChartMargin Left="10" Right="10" Top="20" Bottom="20" />
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" Title="Month">
        <ChartAxisMajorGridLines Width="0" />
        <ChartAxisMajorTickLines Width="0" />
    </ChartPrimaryXAxis>
    <ChartPrimaryYAxis Title="Count / Score" Minimum="0" Maximum="600" Interval="100">
        <ChartAxisLineStyle Width="0" />
        <ChartAxisMajorTickLines Width="0" />
    </ChartPrimaryYAxis>
    <ChartTooltipSettings Enable="true" Header="<b>${series.name}</b>" Format="${point.x} : <b>${point.y}</b>" />
    <ChartLegendSettings Visible="true" Position="LegendPosition.Bottom" />
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ActiveUsersData" Name="Active Users" XName="Month" YName="Value" Type="ChartSeriesType.Line" Width="3" Fill="#4F65F1">
            <ChartMarker Visible="true" Width="10" Height="10" IsFilled="true" Shape="ChartShape.Circle" />
            <SeriesLabelSettings Visible="true" Background="#EEF2FF" Opacity="0.95" ShowOverlapText="true">
                <SeriesLabelFont Size="13px" FontFamily="Segoe UI" FontWeight="600" Color="#3347D6" />
                <SeriesLabelBorder Width="1.5" Color="#4F65F1" />
            </SeriesLabelSettings>
        </ChartSeries>
        <ChartSeries DataSource="@SupportTicketsData" Name="Support Tickets" XName="Month" YName="Value" Type="ChartSeriesType.Line" Width="3" Fill="#E6951A">
            <ChartMarker Visible="true" Width="10" Height="10" IsFilled="true" Shape="ChartShape.Diamond" />
            <SeriesLabelSettings Visible="true" Background="#FFF7E8" Opacity="0.95" ShowOverlapText="true">
                <SeriesLabelFont Size="13px" FontFamily="Segoe UI" FontWeight="600" Color="#B86A00" />
                <SeriesLabelBorder Width="1.5" Color="#E6951A" />
            </SeriesLabelSettings>
        </ChartSeries>
        <ChartSeries DataSource="@FeatureRequestsData" Name="Feature Requests" XName="Month" YName="Value" Type="ChartSeriesType.Line" Width="3" Fill="#2DBE60">
            <ChartMarker Visible="true" Width="10" Height="10" IsFilled="true" Shape="ChartShape.Triangle" />
            <SeriesLabelSettings Visible="true" Background="#EAFBF1" Opacity="0.95" ShowOverlapText="true">
                <SeriesLabelFont Size="13px" FontFamily="Segoe UI" FontWeight="600" Color="#1F8D47" />
                <SeriesLabelBorder Width="1.5" Color="#2DBE60" />
            </SeriesLabelSettings>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class MetricData
    {
        public string Month { get; set; }
        public double Value { get; set; }
    }

    public List<MetricData> ActiveUsersData = new()
    {
        new MetricData { Month = "Feb", Value = 420 },
        new MetricData { Month = "Mar", Value = 460 },
        new MetricData { Month = "Apr", Value = 445 },
        new MetricData { Month = "May", Value = 495 },
        new MetricData { Month = "Jun", Value = 535 }
    };

    public List<MetricData> SupportTicketsData = new()
    {
        new MetricData { Month = "Feb", Value = 210 },
        new MetricData { Month = "Mar", Value = 240 },
        new MetricData { Month = "Apr", Value = 225 },
        new MetricData { Month = "May", Value = 260 },
        new MetricData { Month = "Jun", Value = 275 }
    };

    public List<MetricData> FeatureRequestsData = new()
    {
        new MetricData { Month = "Feb", Value = 65 },
        new MetricData { Month = "Mar", Value = 78 },
        new MetricData { Month = "Apr", Value = 72 },
        new MetricData { Month = "May", Value = 95 },
        new MetricData { Month = "Jun", Value = 108 }
    };
}

```

![Blazor line chart with customized series label background, font, and border](images/series-label/blazor-line-chart-series-label-customization.webp)

## See also

* [Data Label](./data-labels)
* [Legend](./legend)

N> Refer to the [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page to explore the available chart features. You can also check the [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to learn how chart types are used to visualize data trends over equal intervals.
