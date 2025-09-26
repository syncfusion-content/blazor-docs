---
layout: post
title: Data Label Template in Blazor Charts Component | Syncfusion
description: Check out and learn how to configure Data Label Template in Syncfusion Blazor Charts component.
platform: Blazor
control: Chart
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Data Label Template in Blazor Charts Component

Text and additional information for a data point can be bound from a datasource beyond the x and y values. Use the implicit named parameter context to access aggregate values within the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataLabel.html#Syncfusion_Blazor_Charts_ChartDataLabel_Template). To retrieve aggregate values inside the template, type cast the context as [ChartDataPointInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartDataPointInfo.html). You can also modify the name of this implicit parameter using the context attribute.

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
       new Data{ X = "Jan", Y = 3, Text = "January" },
       new Data{ X = "Feb", Y = 3.5, Text = "February" },
       new Data{ X = "Mar", Y = 7, Text = "March" },
       new Data{ X = "Apr", Y = 13.5, Text = "April" }
    };
}

```

![Blazor Chart Label with Template](images/data-label/blazor-chart-label-template.png)

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.
