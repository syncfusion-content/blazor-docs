---
layout: post
title: Last Value Label in Blazor Charts Component | Syncfusion
description: Checkout and learn here all about the Last Value Label in Syncfusion Blazor Charts component and much more.
platform: Blazor
control: Chart
documentation: ug
---

# Last Value Label in Blazor Charts Component

The Last Value Label feature in `ChartLastDataLabel` allows you to easily display the value of the last data point in a series. This provides an intuitive way to highlight the most recent or final value in your chart.

## Enable Last Value Label

To show the last value label, ensure that the `ShowLabel` property inside `ChartLastDataLabel` is set to **true** within the series configuration.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Efficiency of oil-fired power production" Width="70%">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" Title="Year"></ChartPrimaryXAxis>
    <ChartPrimaryYAxis Title="Efficiency" LabelFormat="{value}%"></ChartPrimaryYAxis>
    <ChartTooltipSettings Enable="true"></ChartTooltipSettings>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ProductionDetails" XName="X" YName="Y" Type="ChartSeriesType.Column">
            <ChartLastDataLabel ShowLabel="true"></ChartLastDataLabel>
            <ChartMarker>
                <ChartDataLabel Visible="true"></ChartDataLabel>
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> ProductionDetails = new List<ChartData>
    {
        new ChartData { X = "2005", Y = 28 }, 
        new ChartData { X = "2006", Y = 25 }, 
        new ChartData { X = "2007", Y = 26 }, 
        new ChartData { X = "2008", Y = 27 },
        new ChartData { X = "2009", Y = 32 }, 
        new ChartData { X = "2010", Y = 35 }, 
        new ChartData { X = "2011", Y = 40 }
    };
}

```

![Last Value Label in Blazor Column Chart](images/last-value/blazor-column-chart-last-value-label.png)

## Last Value Label Customization

The appearance of the last value label can be customized using various style properties defined across different configuration settings. The background color, line color, line width, dash pattern, and corner radius of the label can be adjusted using properties such as **Background**, **LineColor**, **LineWidth**, **DashArray**, **Rx**, and **Ry** within `ChartLastDataLabel`. You can customize the color and width of the label’s border through `ChartLastDataLabelBorder` by setting the **Color** and **Width** properties. To style the label’s text, `ChartLastDataLabelFont` provides options to specify the font color, font family, font style, font weight, and size. These settings allow you to create a visually distinct and well-integrated label that enhances the clarity and aesthetics of your chart.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Efficiency of oil-fired power production" Width="70%">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" Title="Year"></ChartPrimaryXAxis>
    <ChartPrimaryYAxis Title="Efficiency" LabelFormat="{value}%"></ChartPrimaryYAxis>
    <ChartTooltipSettings Enable="true"></ChartTooltipSettings>
    <ChartSeriesCollection>
        <ChartSeries DataSource="@ProductionDetails" XName="X" YName="Y" Type="ChartSeriesType.Column">
            <ChartLastDataLabel ShowLabel="true" Background="#748574" LineColor="blue" LineWidth="2" DashArray="5" Rx="10" Ry="10">
                <ChartLastDataLabelBorder Color="red" Width="2"></ChartLastDataLabelBorder>
                <ChartLastDataLabelFont Color="#F0E68C" FontFamily="Arial" FontStyle="Italic" FontWeight="bold" Size="12px"></ChartLastDataLabelFont>
            </ChartLastDataLabel>
            <ChartMarker>
                <ChartDataLabel Visible="true"></ChartDataLabel>
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> ProductionDetails = new List<ChartData>
    {
        new ChartData { X = "2005", Y = 28 },
        new ChartData { X = "2006", Y = 25 },
        new ChartData { X = "2007", Y = 26 },
        new ChartData { X = "2008", Y = 27 },
        new ChartData { X = "2009", Y = 32 },
        new ChartData { X = "2010", Y = 35 },
        new ChartData { X = "2011", Y = 40 }
    };
}

```

![Last Value Label in Blazor Column Chart Customization](images/last-value/blazor-column-chart-last-value-label-customization.png)

## See also

* [Data Label](./data-labels)
* [Tooltip](./tool-tip)
* [Marker](./data-markers)

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.
