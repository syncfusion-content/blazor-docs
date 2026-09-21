---
layout: post
title: Blazor Charts Data Label Template Examples | Syncfusion®
description: Learn how to customize data labels in Syncfusion Blazor Charts. Use a Template that casts context to ChartDataPointInfo for inline values.
platform: Blazor
control: Charts
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Blazor Charts Data Label Template

Additional information for a point can be bound from a data source other than the x and y values. The implicit parameter `context` exposes the data point details inside the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Template). To access these details, type cast the context as [ChartDataPointInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataPointInfo.html).

## Available context members

The following members are available on the [ChartDataPointInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataPointInfo.html) instance inside the template:

| Member | Description |
| --- | --- |
| `X` | X value of the data point. |
| `Y` | Y value of the data point. |
| `Text` | Value mapped through the `Name` property of `ChartDataLabel`. |
| `SeriesName` | Name of the series the point belongs to. |
| `SeriesIndex` | Index of the series the point belongs to. |
| `PointIndex` | Index of the point within the series. |

Use a template when the default label content is insufficient—for example, when you need to combine multiple values, apply rich formatting, or render inline HTML. Otherwise, use the built-in `Format`, `Name`, or `Template` placeholder options documented in [Blazor Charts Data Labels](data-labels.md).

## Renaming the context parameter

The `Template` exposes the implicit parameter as `context` by default. Set `Context` on `Template` to use a different name in your markup, as shown below.

```cshtml
<ChartDataLabel Visible="true" Name="Text">
    <Template>
        @{
            var data = context as ChartDataPointInfo;
            <table>
                <tr><td align="center"> @data.Text</td></tr>
            </table>
        }
    </Template>
</ChartDataLabel>

```

The following complete sample renders a styled two-cell label that shows the mapped `Text` value alongside the y value.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart>
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />

    <ChartSeriesCollection>
        <ChartSeries DataSource="@SalesReports" XName="X" YName="Y">
            <ChartMarker>
                <ChartDataLabel Visible="true" Name="Text">
                    <Template>
                        @{
                            var data = context as ChartDataPointInfo;
                        }
                        <table>
                            <tr>
                                <td align="center" style="background-color: #C1272D; font-size: 14px; color: #E7C554; font-weight: bold; padding: 5px"> @data.Text :</td>
                                <td align="center" style="background-color: #C1272D; font-size: 14px; color: whitesmoke; font-weight: bold; padding: 5px"> @data.Y</td>
                            </tr>
                        </table>
                    </Template>
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

    public List<Data> SalesReports = new List<Data>
    {
        new Data{ X= "Jan", Y= 3, Text= "January" },
        new Data{ X= "Feb", Y= 3.5, Text= "February" },
        new Data{ X= "Mar", Y= 7, Text= "March" },
        new Data{ X= "Apr", Y= 13.5, Text= "April" }
    };
}

```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXVntbWqzMDXOvXH?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Chart Label with Template](images/data-label/blazor-chart-label-template.webp)" %}

## See also

* [Blazor Charts Data Labels](data-labels.md)
* [ChartDataLabel API reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html)
* [ChartDataPointInfo API reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataPointInfo.html)
