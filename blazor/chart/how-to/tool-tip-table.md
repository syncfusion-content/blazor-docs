---
layout: post
title: How to Tool Tip Table in Blazor Chart Component | Syncfusion
description: Checkout and learn about Tool Tip Table in Blazor Chart component of Syncfusion, and more details.
platform: Blazor
control: Chart
documentation: ug
---

<!-- markdownlint-disable MD036 -->

# Create a table in tooltip

You can show the tooltip as table by using [`Template`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html#Syncfusion_Blazor_Charts_ChartTooltipSettings_Template) property in [`ChartTooltipSettings`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipSettings.html).

To access the aggregate values inside the Template, you can use the implicit named parameter context. You can type cast the context as [`ChartTooltipInfo`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartTooltipInfo.html) to get aggregate values inside template

```
            <ChartTooltipSettings Enable="true">
                <Template>
                    @{
                        var data = context as ChartTooltipInfo;
                        <table>
                            <tr><td>Point Value: </td><td>@data.X : @data.Y</td></tr>
                            <tr><td><div id="chart_cloud"><img src="https://ej2.syncfusion.com/demos/src/chart/images/cloud.png" style="width: 41px; height: 41px" /></div></td></tr>
                        </table>
                    }
                </Template>
            </ChartTooltipSettings>

```

```csharp

@using Syncfusion.Blazor.Charts

<div class="row">
    <div class="col-md-8">
        <SfChart Title="Profit Comparison of A and B">
            <ChartPrimaryXAxis>
                <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
            </ChartPrimaryXAxis>
            <ChartPrimaryYAxis Minimum="0" Maximum="100" Interval="25" Title="Sales">
                <ChartAxisMajorGridLines Width="0"></ChartAxisMajorGridLines>
            </ChartPrimaryYAxis>
            <ChartSeriesCollection>
                <ChartSeries DataSource="@dataSource" Name="Product A" XName="x" Opacity="1" YName="y1" Type="ChartSeriesType.Column">
                </ChartSeries>
                <ChartSeries DataSource="@dataSource" Name="Product B" XName="x" Opacity="1" YName="y2" Type="ChartSeriesType.Column">
                </ChartSeries>
            </ChartSeriesCollection>
            <ChartArea>
                <ChartAreaBorder Width="0"></ChartAreaBorder>
            </ChartArea>
            <ChartTooltipSettings Enable="true">
                <Template>
                    @{
                        var data = context as ChartTooltipInfo;
                        <table style="border: 1px solid black">
                            <tr style="border: 1px solid black"><td style="border: 1px solid black">Point Value: </td><td style="border: 1px solid black">@data.X : @data.Y</td></tr>
                            <tr style="border: 1px solid black"><td style="border: 1px solid black"><div id="chart_cloud"><img src="https://ej2.syncfusion.com/demos/src/chart/images/cloud.png" style="width: 41px; height: 41px" /></div></td></tr>
                        </table>
                    }
                </Template>
            </ChartTooltipSettings>
        </SfChart>
    </div>
</div>
@code
{
    public class ChartTooltipData
    {
        public double x { get; set; }
        public double y1 { get; set; }
        public double y2 { get; set; }
    }
    public class SelectionData
    {
        public double x { get; set; }
        public double y { get; set; }
    }

    private Random rnd = new Random();
    public List<ChartTooltipData> dataSource = new List<ChartTooltipData>();

    protected override void OnInitialized()
    {
        for (int i = 0; i < 5; i++)
        {
            dataSource.Add(new ChartTooltipData { x = 1971 + i, y1 = rnd.Next(10, 100), y2 = rnd.Next(10, 100) });
        }
    }
}

```

> Note: You can refer to our [`Blazor Charts`](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations. You can also explore our [`Blazor Chart example`](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to knows various chart types and how to represent time-dependent data, showing trends in data at equal intervals.