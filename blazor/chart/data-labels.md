---
layout: post
title: Blazor Charts Data Labels Examples | Syncfusion®
description: Learn how to show data labels on Syncfusion Blazor Charts. Enable ChartDataLabel Visible to display point values with auto-arrange.
platform: Blazor
control: Charts
documentation: ug
---

# Blazor Charts Data Labels

A [data label](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html) can be added to a [ChartSeries](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html) by setting the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Visible) property of the [ChartDataLabel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html) component to **true**. Configure the label through its [Position](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Position), [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Format), [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Fill), and [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Name) properties.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"/>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReports" XName="X" YName="Y" Type="ChartSeriesType.Column">
            <ChartMarker>
                <ChartDataLabel Visible="true"/>
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class Data
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public List<Data> WeatherReports = new List<Data>
    {
        new Data { X = "Jan", Y = 3 },
        new Data { X = "Feb", Y = 3.5 },
        new Data { X = "Mar", Y = 7 },
        new Data { X = "Apr", Y = 13.5 }
    };
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BtLRtvWgzhTsADNy?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Column chart with default data labels above each bar](images/data-label/blazor-chart-data-label.webp)" %}

## Position

Use the [Position](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Position) property of [ChartDataLabel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html) to place the label. The available values are [Top](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LabelPosition.html#Syncfusion_Blazor_Charts_LabelPosition_Top), [Middle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LabelPosition.html#Syncfusion_Blazor_Charts_LabelPosition_Middle), [Bottom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LabelPosition.html#Syncfusion_Blazor_Charts_LabelPosition_Bottom), and [Outer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.LabelPosition.html#Syncfusion_Blazor_Charts_LabelPosition_Outer). When `Position` is not set, the chart selects a location automatically based on the series type.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReports" XName="X" YName="Y" Type="ChartSeriesType.Column">
            <ChartMarker>
                <ChartDataLabel Visible="true" Position="Syncfusion.Blazor.Charts.LabelPosition.Middle" />
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class Data
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public List<Data> WeatherReports = new List<Data>
    {
        new Data { X = "Jan", Y = 3 },
        new Data { X = "Feb", Y = 3.5 },
        new Data { X = "Mar", Y = 7 },
        new Data { X = "Apr", Y = 13.5 }
    };
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjVxDPWqTBoDPtmd?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Column chart with data labels positioned in the middle of each bar](images/data-label/blazor-chart-label-position.webp)" %}

To place the label outside the bar, set `Position` to `Outer`:

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReports" XName="X" YName="Y" Type="ChartSeriesType.Column">
            <ChartMarker>
                <ChartDataLabel Visible="true" Position="Syncfusion.Blazor.Charts.LabelPosition.Outer" />
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class Data
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public List<Data> WeatherReports = new List<Data>
    {
        new Data { X = "Jan", Y = 3 },
        new Data { X = "Feb", Y = 3.5 },
        new Data { X = "Mar", Y = 7 },
        new Data { X = "Apr", Y = 13.5 }
    };
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rthxXbMKffiORJPe?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Column chart with data labels positioned outside each bar](images/data-label/blazor-chart-label-position-outer.webp)" %}

N> The position `Outer` applies only to column and bar series.

## Template

Render arbitrary content for each label â€” including multiple values, rich formatting, or inline HTML â€” by using the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Template) option. Inside the template, the implicit `context` exposes the data point details; cast it to [ChartDataPointInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataPointInfo.html) to access `X`, `Y`, `Text`, and other members.

See [Data Label Template](data-label-template.md) for a full example and a reference of available members.

## Text mapping

The [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Name) property maps a field from the data source to each data label, replacing the default point value.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReports" XName="X" YName="Y" Type="ChartSeriesType.Column">
            <ChartMarker>
                <ChartDataLabel Visible="true" Name="Text"></ChartDataLabel>
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class Data
    {
        public string X { get; set; }
        public double Y { get; set; }
        public string Text { get; set; }
    }

    public List<Data> WeatherReports = new List<Data>
    {
        new Data { X = "Jan", Y = 3, Text = "January" },
        new Data { X = "Feb", Y = 3.5, Text = "February" },
        new Data { X = "Mar", Y = 7, Text = "March" },
        new Data { X = "Apr", Y = 13.5, Text = "April" }
    };
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDBdXFsUpLwTLcLC?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Column chart with data labels showing the mapped month name from the Text field](images/data-label/blazor-chart-label-with-text-mapping.webp)" %}

## Format

Format each data label by setting the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Format) property of [ChartDataLabel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html). Use standard format specifiers such as `N1`, `P1`, and `C1` for numeric, percentage, and currency values.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReports" XName="X" YName="Y" Type="ChartSeriesType.Line">
            <ChartMarker>
                <ChartDataLabel Visible="true" Format="N1" />
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class Data
    {
        public string X { get; set; }
        public double Y { get; set; }
        public string Text { get; set; }
    }

    public List<Data> WeatherReports = new List<Data>
    {
        new Data { X = "Jan", Y = 3, Text = "January" },
        new Data { X = "Feb", Y = 3.5, Text = "February" },
        new Data { X = "Mar", Y = 7, Text = "March" },
        new Data { X = "Apr", Y = 13.5, Text = "April" }
    };
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNrRDlWUpULaRzTj?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Line chart with data labels formatted to one decimal place](images/data-label/blazor-chart-label-with-format.webp)" %}

## Margin

Use the [Margin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Margin) child of [ChartDataLabel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html) to add space around the label.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReports" XName="X" YName="Y" Type="ChartSeriesType.Column">
            <ChartMarker>
                <ChartDataLabel Visible="true" Name="Text">
                    <ChartDataLabelBorder Width="2" Color="red" />
                    <ChartDataLabelMargin Left="15" Right="15" Top="15" Bottom="15" />
                </ChartDataLabel>
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class Data
    {
        public string X { get; set; }
        public double Y { get; set; }
        public string Text { get; set; }
    }

    public List<Data> WeatherReports = new List<Data>
    {
        new Data { X = "Jan", Y = 3, Text = "January" },
        new Data { X = "Feb", Y = 3.5, Text = "February" },
        new Data { X = "Mar", Y = 7, Text = "March" },
        new Data { X = "Apr", Y = 13.5, Text = "April" }
    };
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjhnjbiATUqYMUNH?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Column chart with data labels that have a red border and custom margin](images/data-label/blazor-chart-label-with-margin.webp)" %}

## Customization

Customize the appearance of each label by setting the [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Fill) property on [ChartDataLabel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html). Use the [ChartDataLabelBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabelBorder.html) child to set the border color and width, and use the [Rx](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Rx) and [Ry](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Ry) properties to control the corner radii of the label background.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReports" XName="X" YName="Y" Type="ChartSeriesType.Column">
            <ChartMarker>
                <ChartDataLabel Visible="true" Name="Text" Rx="10" Ry="10" Fill="#e91e63">
                    <ChartDataLabelFont Color="#ffffff" FontWeight="600" />
                    <ChartDataLabelBorder Width="2" Color="red"></ChartDataLabelBorder>
                </ChartDataLabel>
            </ChartMarker>
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code {
    public class Data
    {
        public string X { get; set; }
        public double Y { get; set; }
        public string Text { get; set; }
    }

    public List<Data> WeatherReports = new List<Data>
    {
        new Data { X = "Jan", Y = 3, Text = "January" },
        new Data { X = "Feb", Y = 3.5, Text = "February" },
        new Data { X = "Mar", Y = 7, Text = "March" },
        new Data { X = "Apr", Y = 13.5, Text = "April" }
    };
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNrntPiUzgfQuWQx?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Column chart with custom data labels showing pink fill, white bold font, and red border](images/data-label/blazor-chart-custom-label.webp)" %}

N> Refer to the [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore the [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=fluent2) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.

## See also

* [Tooltip](./tool-tip)
* [Legend](./legend)
* [Data Label Template](./data-label-template)
* [Last Data Label](./last-data-label)
* [ChartDataLabel API reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html)