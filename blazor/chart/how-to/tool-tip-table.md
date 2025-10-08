---
layout: post
title: Table in Tooltip in Blazor Charts Component | Syncfusion
description: Check out and learn how to display a table in tooltips using templates in Syncfusion Blazor Charts component.
platform: Blazor
control: Chart
documentation: ug
---

# Table in Tooltip in Blazor Charts Component

A table-style tooltip can be created using the [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html#Syncfusion_Blazor_Charts_ChartTooltipSettings_Template) property in [ChartTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html). Follow these steps to display a table inside the tooltip.

## Step 1: Render the Chart Series

Render a chart with the required series using [ChartSeriesCollection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesCollection.html).

```cshtml

<SfChart Title="Weather condition JPN vs DEU">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category" />
    <ChartSeriesCollection>
        <ChartSeries DataSource="@WeatherReports" XName="X" YName="Y" Type="ChartSeriesType.Column" />
    </ChartSeriesCollection>
</SfChart>

```

## Step 2: Enable the Tooltip

Enable the tooltip by setting the [Enable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html#Syncfusion_Blazor_Charts_ChartTooltipSettings_Enable) property to true in [ChartTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html).

```cshtml

...
    <ChartTooltipSettings Enable="true">
...

```

## Step 3: Add a Table Template to the Tooltip

Construct an HTML table and use the implicit named parameter context to access aggregate values within the template. Type cast the context as [ChartTooltipInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipInfo.html) to retrieve values inside the template.

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

## Action

When the mouse is moved over chart series points, the tooltip is displayed in table format. The complete code sample is shown below.

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

@code {
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
