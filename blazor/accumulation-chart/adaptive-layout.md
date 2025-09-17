---
layout: post
title: Adaptive Layout in Blazor Accumulation Chart Component | Syncfusion
description: Checkout and learn here all about Adaptive Layout in Syncfusion Blazor Accumulation Chart component and more.
platform: Blazor
control: Accumulation Chart
documentation: ug
---

# Adaptive Layout in Blazor Accumulation Chart Component

When viewing the accumulation chart on a mobile device, some elements may not be displayed properly due to limited screen space. This is where the **Syncfusion<sup style="font-size:70%">&reg;</sup> Accumulation Chart Adaptive Layout** feature proves invaluable. Adaptive rendering dynamically adjusts chart elements to optimize their display based on the available screen size and orientation. By enabling the `EnableAdaptiveRendering` property, the chart automatically adapts to container size changes, ensuring clear alignment and proper visibility of elements such as the legend, data labels, chart title, and more.

```cshtml 

@using Syncfusion.Blazor.Charts

<SfAccumulationChart Title="Mobile Browser Statistics" SubTitle="Browser and Users" EnableAdaptiveRendering="true" Width="300px" Height="400px">
    <AccumulationChartBorder Color="black" Width="1"></AccumulationChartBorder>
    <AccumulationChartSeriesCollection>
        <AccumulationChartSeries DataSource="@PieChartPoints" Explode="true" XName="Browser" YName="Users" Name="Browser" Type="AccumulationType.Pie">
            <AccumulationDataLabelSettings Visible="true" Position="AccumulationLabelPosition.Inside" Name="DataLabelMappingName"></AccumulationDataLabelSettings>
        </AccumulationChartSeries>
    </AccumulationChartSeriesCollection>
    <AccumulationChartTooltipSettings Enable="true"></AccumulationChartTooltipSettings>
    <AccumulationChartLegendSettings Visible="true" Position="LegendPosition.Right"></AccumulationChartLegendSettings>
</SfAccumulationChart>

@code {
    public class PieData
    {
        public string Browser { get; set; }
        public double Users { get; set; }
        public string DataLabelMappingName { get; set; }
    }

    public List<PieData> PieChartPoints { get; set; } = new List<PieData>
    {
        new PieData { Browser = "Chrome", Users = 59.28, DataLabelMappingName = "Chrome: 59.28%" },
        new PieData { Browser = "UC Browser", Users = 4.37, DataLabelMappingName = "UC Browser: 4.37%" },
        new PieData { Browser = "Internet Explorer", Users = 6.12, DataLabelMappingName = "Internet Explorer: 6 12%" },
        new PieData { Browser = "Sogou Explorer", Users = 1.37, DataLabelMappingName = "Sogou Explorer: 1.37%" },
        new PieData { Browser = "QQ", Users = 3.96, DataLabelMappingName = "QQ: 3.96%" },
        new PieData { Browser = "Safari", Users = 4.73, DataLabelMappingName = "Safari: 4.73%" },
        new PieData { Browser = "Opera", Users = 3.12, DataLabelMappingName = "Opera: 3.12%" },
        new PieData { Browser = "Edge", Users = 7.48, DataLabelMappingName = "Edge: 7.48%" },
        new PieData { Browser = "Others", Users = 9.57, DataLabelMappingName = "Others: 9.57%" },
    };
}

```

![Adaptive Layout in Blazor Accumulation Chart](images/adaptive-layout/blazor-accumulation-chart-adaptive-layout.png)

The table below outlines the behavior of various chart elements under specific conditions determined by the chart's height and width:

| Element      | Size              | Behavior         |
|--------------|------------------  |---------------------|
| Title  | <kbd>Height &lt; 200</kbd> / <kbd>Width &lt; 200</kbd> | Accumulation chart title is disabled |
| Sutitle | <kbd>Height &lt; 300</kbd> / <kbd>Width &lt; 300</kbd> | Accumulation chart subtitle is disabled |
| Datalabel | <kbd>Radius &lt; 300</kbd> / <kbd>Radius &lt; 200</kbd> | Datalabel moves inside / Datalabel is disabled |
| Legend | <kbd>Height &lt; 300</kbd> / <kbd>Width &lt; 300 | Moves the bottom or top legend to the right if the width is greater than 200px; otherwise, it is disabled / Moves the right or left legend to the bottom if the height is greater than 200px; otherwise, it is disabled |

N> Refer to the [Blazor Charts](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore the [Blazor Accumulation Chart Example](https://blazor.syncfusion.com/demos/chart/pie?theme=bootstrap5) to know about the various features of accumulation charts and how it is used to represent numeric proportional data.

## See also

* [Data Label](./data-labels)
* [Tooltip](./tool-tip)
* [Legend](./legend)