---
layout: post
title: Series Label in Blazor Charts Component | Syncfusion
description: Checkout and learn here all about the Series label in Syncfusion Blazor Charts component and much more.
platform: Blazor
control: Chart
documentation: ug
---

# Series Label in Blazor Charts Component

The series label displays the name of each series inline, positioned near the end of the series path or the last visible data point. This helps identify each series without referring to the legend.

## Overview

Enable series labels using the `SeriesLabelSettings` property within the series configuration. Set the `visible` property to **true** to display the label.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Country Values by Year">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartPrimaryYAxis Title="Value"></ChartPrimaryYAxis>
    <ChartLegendSettings Visible="true"></ChartLegendSettings>
    <ChartTooltipSettings Enable="true"></ChartTooltipSettings>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@VietnamData" XName="X" YName="Y"
            Name="Vietnam" Type="ChartSeriesType.Line" Width="2">
            <ChartMarker Visible="true" Width="7" Height="7"
                Shape="ChartShape.Circle" IsFilled="true">
            </ChartMarker>
            <SeriesLabelSettings Visible="true" ></SeriesLabelSettings>
        </ChartSeries>
        <ChartSeries DataSource="@IndonesiaData" XName="X" YName="Y"
        Name="Indonesia" Type="ChartSeriesType.Line" Width="2">
            <ChartMarker Visible="true" Width="5" Height="5" 
                Shape="ChartShape.Rectangle" IsFilled="true">
            </ChartMarker>
            <SeriesLabelSettings Visible="true" > </SeriesLabelSettings>
        </ChartSeries>
        <ChartSeries DataSource="@FranceData" XName="X" YName="Y"
            Name="France" Type="ChartSeriesType.Line" Width="2">
            <ChartMarker Visible="true" Width="5" Height="5"
                Shape="ChartShape.Rectangle" IsFilled="true">
            </ChartMarker>
            <SeriesLabelSettings Visible="true" ></SeriesLabelSettings>
        </ChartSeries>
        <ChartSeries DataSource="@PolandData" XName="X" YName="Y"
            Name="Poland" Type="ChartSeriesType.Line" Width="2">
            <ChartMarker Visible="true" Width="5" Height="5" Shape="ChartShape.Rectangle" IsFilled="true">
            </ChartMarker>
            <SeriesLabelSettings Visible="true" ></SeriesLabelSettings>
        </ChartSeries>
        <ChartSeries DataSource="@MexicoData" XName="X" YName="Y"
            Name="Mexico" Type="ChartSeriesType.Line" Width="2">
            <ChartMarker Visible="true" Width="5" Height="5"
                Shape="ChartShape.Rectangle" IsFilled="true">
            </ChartMarker>
            <SeriesLabelSettings Visible="true" ></SeriesLabelSettings>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; } = string.Empty;
        public double Y { get; set; }
    }

    public List<ChartData> VietnamData = new()
    {
        new() { X = "2016", Y = 7.8 },
        new() { X = "2017", Y = 10.3 },
        new() { X = "2018", Y = 15.5 },
        new() { X = "2019", Y = 17.5 },
        new() { X = "2020", Y = 19.5 },
        new() { X = "2021", Y = 23.0 },
        new() { X = "2022", Y = 20.0 },
        new() { X = "2023", Y = 19.0 },
        new() { X = "2024", Y = 22.1 }
    };

    public List<ChartData> IndonesiaData = new()
    {
        new() { X = "2016", Y = 4.8 },
        new() { X = "2017", Y = 5.2 },
        new() { X = "2018", Y = 6.2 },
        new() { X = "2019", Y = 7.8 },
        new() { X = "2020", Y = 9.3 },
        new() { X = "2021", Y = 14.3 },
        new() { X = "2022", Y = 15.6 },
        new() { X = "2023", Y = 16.0 },
        new() { X = "2024", Y = 17.0 }
    };

    public List<ChartData> FranceData = new()
    {
        new() { X = "2016", Y = 14.6 },
        new() { X = "2017", Y = 15.5 },
        new() { X = "2018", Y = 15.4 },
        new() { X = "2019", Y = 14.4 },
        new() { X = "2020", Y = 11.6 },
        new() { X = "2021", Y = 13.9 },
        new() { X = "2022", Y = 12.1 },
        new() { X = "2023", Y = 10.0 },
        new() { X = "2024", Y = 10.8 }
    };

    public List<ChartData> PolandData = new()
    {
        new() { X = "2016", Y = 8.9 },
        new() { X = "2017", Y = 10.3 },
        new() { X = "2018", Y = 10.8 },
        new() { X = "2019", Y = 9.0 },
        new() { X = "2020", Y = 7.9 },
        new() { X = "2021", Y = 8.5 },
        new() { X = "2022", Y = 7.4 },
        new() { X = "2023", Y = 6.4 },
        new() { X = "2024", Y = 7.1 }
    };

    public List<ChartData> MexicoData = new()
    {
        new() { X = "2016", Y = 19.0 },
        new() { X = "2017", Y = 20.0 },
        new() { X = "2018", Y = 20.2 },
        new() { X = "2019", Y = 18.4 },
        new() { X = "2020", Y = 16.8 },
        new() { X = "2021", Y = 18.5 },
        new() { X = "2022", Y = 18.4 },
        new() { X = "2023", Y = 16.3 },
        new() { X = "2024", Y = 13.7 }
    };
}

```

![Series Label in Blazor Line Chart](images/series-label/blazor-line-chart-series-label.webp)

## Customization

Customize the appearance of series labels using the following properties:

* `Text` – Custom text for the label. By default, the series name is used.
* `Background` – Background color of the label.
* `Opacity` – Specifies the transparency of the label.
* `ShowOverlapText` – When set to `false`, overlapping labels are hidden.
* `SeriesLabelFont` – Used to customize the label font such as size, family, weight, and color.
* `SeriesLabelBorder` – Used to customize the border width and color.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>
    <ChartPrimaryYAxis Title="Value"></ChartPrimaryYAxis>
    <ChartLegendSettings Visible="true"></ChartLegendSettings>
    <ChartTooltipSettings Enable="true"></ChartTooltipSettings>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@VietnamData" XName="X" YName="Y"
            Name="Vietnam" Type="ChartSeriesType.Line" Width="2">
            <ChartMarker Visible="true" Width="7" Height="7" Shape="ChartShape.Circle" IsFilled="true">
            </ChartMarker>
            <SeriesLabelSettings Visible="true" Text="Vietnam" Background="#E8F5E9" Opacity="0.9"
                ShowOverlapText="true">
                <SeriesLabelFont Size="12px" FontFamily="Segoe UI" FontWeight="600" Color="#2E7D32" />
                <SeriesLabelBorder Width="2" Color="#2E7D32" />
            </SeriesLabelSettings>
        </ChartSeries>
        <ChartSeries DataSource="@IndonesiaData" XName="X" YName="Y"
            Name="Indonesia" Type="ChartSeriesType.Line" Width="2">
            <ChartMarker Visible="true" Width="5" Height="5" Shape="ChartShape.Rectangle" IsFilled="true">
            </ChartMarker>
            <SeriesLabelSettings Visible="true" Text="Indonesia" Background="#E8F5E9" Opacity="0.9"
                ShowOverlapText="true">
                <SeriesLabelFont Size="12px" FontFamily="Segoe UI" FontWeight="600" Color="#2E7D32" />
                <SeriesLabelBorder Width="2" Color="#2E7D32" />
            </SeriesLabelSettings>
        </ChartSeries>
        <ChartSeries DataSource="@FranceData" XName="X" YName="Y"
            Name="France" Type="ChartSeriesType.Line" Width="2">
            <ChartMarker Visible="true" Width="5" Height="5" Shape="ChartShape.Rectangle" IsFilled="true">
            </ChartMarker>
            <SeriesLabelSettings Visible="true" Text="France" Background="#E8F5E9" Opacity="0.9"  
                ShowOverlapText="true">
                <SeriesLabelFont Size="12px" FontFamily="Segoe UI" FontWeight="600" Color="#2E7D32" />
                <SeriesLabelBorder Width="2" Color="#2E7D32" />
            </SeriesLabelSettings>
        </ChartSeries>
        <ChartSeries DataSource="@PolandData" XName="X" YName="Y"
            Name="Poland" Type="ChartSeriesType.Line" Width="2">
            <ChartMarker Visible="true" Width="5" Height="5" Shape="ChartShape.Rectangle" IsFilled="true">
            </ChartMarker>
            <SeriesLabelSettings Visible="true" Text="Poland" Background="#E8F5E9" Opacity="0.9"
                ShowOverlapText="true">
                <SeriesLabelFont Size="12px" FontFamily="Segoe UI" FontWeight="600" Color="#2E7D32" />
                <SeriesLabelBorder Width="2" Color="#2E7D32" />
            </SeriesLabelSettings>
        </ChartSeries>

        <ChartSeries DataSource="@MexicoData" XName="X" YName="Y"
            Name="Mexico" Type="ChartSeriesType.Line" Width="2">
            <ChartMarker Visible="true" Width="5" Height="5" Shape="ChartShape.Rectangle" IsFilled="true">
            </ChartMarker>
            <SeriesLabelSettings Visible="true" Text="Mexico" Background="#E8F5E9" Opacity="0.9"
                ShowOverlapText="true">
                <SeriesLabelFont Size="12px" FontFamily="Segoe UI" FontWeight="600" Color="#2E7D32" />
                <SeriesLabelBorder Width="2" Color="#2E7D32" />
            </SeriesLabelSettings>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; } = string.Empty;
        public double Y { get; set; }
    }

    public List<ChartData> VietnamData = new()
    {
        new() { X = "2016", Y = 7.8 },
        new() { X = "2017", Y = 10.3 },
        new() { X = "2018", Y = 15.5 },
        new() { X = "2019", Y = 17.5 },
        new() { X = "2020", Y = 19.5 },
        new() { X = "2021", Y = 23.0 },
        new() { X = "2022", Y = 20.0 },
        new() { X = "2023", Y = 19.0 },
        new() { X = "2024", Y = 22.1 }
    };

    public List<ChartData> IndonesiaData = new()
    {
        new() { X = "2016", Y = 4.8 },
        new() { X = "2017", Y = 5.2 },
        new() { X = "2018", Y = 6.2 },
        new() { X = "2019", Y = 7.8 },
        new() { X = "2020", Y = 9.3 },
        new() { X = "2021", Y = 14.3 },
        new() { X = "2022", Y = 15.6 },
        new() { X = "2023", Y = 16.0 },
        new() { X = "2024", Y = 17.0 }
    };

    public List<ChartData> FranceData = new()
    {
        new() { X = "2016", Y = 14.6 },
        new() { X = "2017", Y = 15.5 },
        new() { X = "2018", Y = 15.4 },
        new() { X = "2019", Y = 14.4 },
        new() { X = "2020", Y = 11.6 },
        new() { X = "2021", Y = 13.9 },
        new() { X = "2022", Y = 12.1 },
        new() { X = "2023", Y = 10.0 },
        new() { X = "2024", Y = 10.8 }
    };

    public List<ChartData> PolandData = new()
    {
        new() { X = "2016", Y = 8.9 },
        new() { X = "2017", Y = 10.3 },
        new() { X = "2018", Y = 10.8 },
        new() { X = "2019", Y = 9.0 },
        new() { X = "2020", Y = 7.9 },
        new() { X = "2021", Y = 8.5 },
        new() { X = "2022", Y = 7.4 },
        new() { X = "2023", Y = 6.4 },
        new() { X = "2024", Y = 7.1 }
    };

    public List<ChartData> MexicoData = new()
    {
        new() { X = "2016", Y = 19.0 },
        new() { X = "2017", Y = 20.0 },
        new() { X = "2018", Y = 20.2 },
        new() { X = "2019", Y = 18.4 },
        new() { X = "2020", Y = 16.8 },
        new() { X = "2021", Y = 18.5 },
        new() { X = "2022", Y = 18.4 },
        new() { X = "2023", Y = 16.3 },
        new() { X = "2024", Y = 13.7 }
    };
}

```

![Series Label in Blazor Line Chart Customization](images/series-label/blazor-line-chart-series-label-customization.webp)

## See also

* [Data Label](./data-labels)
* [Legend](./legend)

N> Refer to the [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore the [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.



