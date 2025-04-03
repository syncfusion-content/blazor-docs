---
layout: post
title: Table in Tooltip in Blazor Charts Component | Syncfusion
description: Checkout and learn here all about Table in Tooltip in Syncfusion Blazor Charts component and much more.
platform: Blazor
control: Chart
documentation: ug
---

# Table in Tooltip in Blazor Charts Component

A table type tooltip can be created using the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html#Syncfusion_Blazor_Charts_ChartTooltipSettings_Template) property in [ChartTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html). Follow the steps below to display a table inside the tooltip.

**Step 1:**

Render a chart with the required series using [ChartSeriesCollection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesCollection.html).

```cshtml
<SfChart Title="Weather condition JPN vs DEU">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReports" XName="X" YName="Y" Type="ChartSeriesType.Column" />
    </ChartSeriesCollection>
</SfChart>
```

**Step 2:**

The tooltip can be enabled using the [Enable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html#Syncfusion_Blazor_Charts_ChartTooltipSettings_Enable) property as **true** in [ChartTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html).

```cshtml
...
<ChartTooltipSettings Enable="true">
...
```

**Step 3:**

Construct a HTML table as per the requirement and place the implicit named parameter context to access the aggregate values within the template. To retrieve aggregate values inside the template, type cast the context as [ChartTooltipInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipInfo.html).

```cshtml
...
<ChartTooltipSettings Enable="true">
    <Template>
        @{
            var data = context as ChartTooltipInfo;
            <table border="5" bgcolor="lightblue">
                <tr style="border: 1px solid black">
                    <td style="border: 1px solid black">Month: </td>
                    <td style="border: 1px solid black">@data.X</td>
                </tr>
                <tr style="border: 1px solid black">
                    <td style="border: 1px solid black">Value: </td>
                    <td style="border: 1px solid black">@data.Y</td>
                </tr>
            </table>
        }
    </Template>
</ChartTooltipSettings>
...
```

**Action**

When the mouse is moved over the chart series points, the tooltip is displayed in table format. The complete code snippet for the preceding steps is available below.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Weather condition JPN vs DEU">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReports" XName="X" YName="Y" Type="ChartSeriesType.Column" />
    </ChartSeriesCollection>
    <ChartTooltipSettings Enable="true">
        <Template>
            @{
                var data = context as ChartTooltipInfo;
                <table border="2" bgcolor="lightblue" cellpadding="5">
                    <tr style="border: .1px solid black">
                        <td style="border: 1px solid black">Month: </td>
                        <td style="border: 1px solid black"> @data.X</td>
                    </tr>
                    <tr style="border: .1px solid black">
                        <td style="border: 1px solid black">Value: </td>
                        <td style="border: 1px solid black"> @data.Y</td>
                    </tr>
                </table>
            }
        </Template>
    </ChartTooltipSettings>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double Y { get; set; }
    }

    public List<ChartData> WeatherReports = new List<ChartData>
    {
         new ChartData{ X= "Jan", Y= 15 },
         new ChartData{ X= "Feb", Y= 20 },
         new ChartData{ X= "Mar", Y= 35 },
         new ChartData{ X= "Apr", Y= 40 },
         new ChartData{ X= "May", Y= 80 },
         new ChartData{ X= "Jun", Y= 70 },
         new ChartData{ X= "Jul", Y= 65 },
         new ChartData{ X= "Aug", Y= 55 },
         new ChartData{ X= "Sep", Y= 50 },
         new ChartData{ X= "Oct", Y= 30 },
         new ChartData{ X= "Nov", Y= 35 },
         new ChartData{ X= "Dec", Y= 35 }
    };
}

```

N> Refer to our [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap5) to know various chart types and how to represent time-dependent data, showing trends at equal intervals.
