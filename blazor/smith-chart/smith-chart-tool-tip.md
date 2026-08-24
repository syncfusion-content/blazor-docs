---
layout: post
title: Blazor Smith Chart Tooltip Examples | Syncfusion®
description: Learn how to enable and customize tooltips in Syncfusion Blazor Smith Chart, including format, template, and styling options.
platform: Blazor
control: Smith Chart
documentation: ug
---

# Blazor Smith Chart Tooltip

When the pointer moves over a point in the Smith Chart, a tooltip appears displaying information about the point. By default, the tooltip is disabled. To enable the tooltip, set the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesTooltip.html#Syncfusion_Blazor_Charts_SmithChartSeriesTooltip_Visible) property to **true** in the [SmithChartSeriesTooltip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesTooltip.html).

```cshtml
@using Syncfusion.Blazor.Charts

<SfSmithChart>
    <SmithChartSeriesCollection>
        <SmithChartSeries Name="First transmission" DataSource='TransmissionData' Reactance="Reactance" Resistance="Resistance">
            <SmithChartSeriesMarker Visible='true'></SmithChartSeriesMarker>
            <SmithChartSeriesTooltip Visible='true'></SmithChartSeriesTooltip>
        </SmithChartSeries>
    </SmithChartSeriesCollection>
</SfSmithChart>

@code {
    public class SmithChartData
    {
        public double? Resistance { get; set; }
        public double? Reactance { get; set; }
    };
    public List<SmithChartData> TransmissionData = new List<SmithChartData> {
        new SmithChartData { Resistance= 10, Reactance= 25 },
        new SmithChartData { Resistance= 6, Reactance= 4.5 },
        new SmithChartData { Resistance= 3.5, Reactance= 1.6 },
        new SmithChartData { Resistance= 2, Reactance= 1.2 },
        new SmithChartData { Resistance= 1, Reactance= 0.8 },
        new SmithChartData { Resistance= 0, Reactance= 0.2 }
    };
}
```

![Blazor Smith Chart with Tooltip](./images/Tooltip/blazor-smith-chart-tooltip.webp)

## Tooltip Customization

The tooltip can be customized for each series using the following properties.

* [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesTooltip.html#Syncfusion_Blazor_Charts_SmithChartSeriesTooltip_Fill) - Used to change the fill color of the tooltip.
* [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesTooltip.html#Syncfusion_Blazor_Charts_SmithChartSeriesTooltip_Opacity) - Used to control the opacity of the tooltip.
* [SmithChartSeriesTooltipBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesTooltipBorder.html) - Nested component used to customize the border width and color using the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartCommonBorder.html#Syncfusion_Blazor_Charts_SmithChartCommonBorder_Width) and [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartCommonBorder.html#Syncfusion_Blazor_Charts_SmithChartCommonBorder_Color) properties.
* [TooltipMappingName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeries.html#Syncfusion_Blazor_Charts_SmithChartSeries_TooltipMappingName) - Specifies the data-source field used for the tooltip content.

```cshtml
@using Syncfusion.Blazor.Charts

<SfSmithChart>
    <SmithChartSeriesCollection>
        <SmithChartSeries Name="Transmission" DataSource='TransmissionData' Reactance="Reactance" Resistance="Resistance">
            <SmithChartSeriesMarker Visible='true'></SmithChartSeriesMarker>
            <SmithChartSeriesTooltip Visible='true' Fill="red" Opacity="0.5">
                <SmithChartSeriesTooltipBorder Color="blue" Width="2"></SmithChartSeriesTooltipBorder>
            </SmithChartSeriesTooltip>
        </SmithChartSeries>
    </SmithChartSeriesCollection>
</SfSmithChart>

@code {
    public class SmithChartData
    {
        public double? Resistance { get; set; }
        public double? Reactance { get; set; }
    };
    public List<SmithChartData> TransmissionData = new List<SmithChartData> {
        new SmithChartData { Resistance= 10, Reactance= 25 },
        new SmithChartData { Resistance= 6, Reactance= 4.5 },
        new SmithChartData { Resistance= 3.5, Reactance= 1.6 },
        new SmithChartData { Resistance= 2, Reactance= 1.2 },
        new SmithChartData { Resistance= 1, Reactance= 0.8 },
        new SmithChartData { Resistance= 0, Reactance= 0.2 }
    };
}
```

![Blazor Smith Chart with Custom Tooltip](./images/Tooltip/blazor-smith-chart-custom-tooltip.webp)

## Tooltip Template

To access the point values inside the template, use the implicit `context` parameter. The context can be typecast as the [SmithChartPoint](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartPoint.html) to access the point's resistance and reactance values. The following example uses the context in a tooltip template.

```cshtml
@using Syncfusion.Blazor.Charts

<SfSmithChart>
    <SmithChartSeriesCollection>
        <SmithChartSeries Name="Transmission" DataSource='TransmissionData' Reactance="Reactance" Resistance="Resistance">
            <SmithChartSeriesMarker Visible='true'></SmithChartSeriesMarker>
            <SmithChartSeriesTooltip Visible='true'>
                <Template>
                    @{
                        var data = context as SmithChartPoint;
                    }
                    <div style="background-color: blue">@data?.Resistance: @data?.Reactance</div>
                </Template>
            </SmithChartSeriesTooltip>
        </SmithChartSeries>
    </SmithChartSeriesCollection>
</SfSmithChart>

@code {
    public class SmithChartData
    {
        public double? Resistance { get; set; }
        public double? Reactance { get; set; }
    };
    public List<SmithChartData> TransmissionData = new List<SmithChartData> {
        new SmithChartData { Resistance= 10, Reactance= 25 },
        new SmithChartData { Resistance= 6, Reactance= 4.5 },
        new SmithChartData { Resistance= 3.5, Reactance= 1.6 },
        new SmithChartData { Resistance= 2, Reactance= 1.2 },
        new SmithChartData { Resistance= 1, Reactance= 0.8 },
        new SmithChartData { Resistance= 0, Reactance= 0.2 }
    };
}
```

![Blazor Smith Chart with Tooltip Template](./images/Tooltip/blazor-smith-chart-tooltip-template.webp)

## Troubleshooting

If the tooltip does not appear, verify that `Visible="true"` is set on `SmithChartSeriesTooltip` and that the series contains valid `Resistance` and `Reactance` mappings. For setup requirements, see [Getting Started with Blazor Smith Chart](getting-started.md).