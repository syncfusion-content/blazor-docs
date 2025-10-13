---
layout: post
title: Tooltip in Blazor Smith Chart Component | Syncfusion
description: Check out and learn how to configure and customize tooltip in Syncfusion Blazor Smith Chart component.
platform: Blazor
control: Smith Chart
documentation: ug
---

# Tooltip in Blazor Smith Chart Component

When the mouse pointer hovers over a point in the Smith Chart, a tooltip appears displaying information about that point. By default, the tooltip is disabled. To enable it, set the [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesTooltip.html#Syncfusion_Blazor_Charts_SmithChartSeriesTooltip_Visible) property to **true** in [SmithChartSeriesTooltip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesTooltip.html).

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
        new SmithChartData { Resistance = 10, Reactance = 25 },
        new SmithChartData { Resistance = 6, Reactance = 4.5 },
        new SmithChartData { Resistance = 3.5, Reactance = 1.6 },
        new SmithChartData { Resistance = 2, Reactance = 1.2 },
        new SmithChartData { Resistance = 1, Reactance = 0.8 },
        new SmithChartData { Resistance = 0, Reactance = 0.2 }
    };
}

```

![Blazor Smith Chart with Tooltip](./images/Tooltip/blazor-smith-chart-tooltip.png)

## Tooltip Customization

The tooltip can be customized for each series using the following properties:

* [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesTooltip.html#Syncfusion_Blazor_Charts_SmithChartSeriesTooltip_Fill) – Changes the tooltip's fill color.
* [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesTooltip.html#Syncfusion_Blazor_Charts_SmithChartSeriesTooltip_Opacity) – Controls the tooltip's opacity.
* [SmithChartSeriesTooltipBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartSeriesTooltipBorder.html) – Customizes the border's width and color using [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartCommonBorder.html#Syncfusion_Blazor_Charts_SmithChartCommonBorder_Width) and [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartCommonBorder.html#Syncfusion_Blazor_Charts_SmithChartCommonBorder_Color).

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
        new SmithChartData { Resistance = 10, Reactance = 25 },
        new SmithChartData { Resistance = 6, Reactance = 4.5 },
        new SmithChartData { Resistance = 3.5, Reactance = 1.6 },
        new SmithChartData { Resistance = 2, Reactance = 1.2 },
        new SmithChartData { Resistance = 1, Reactance = 0.8 },
        new SmithChartData { Resistance = 0, Reactance = 0.2 }
    };
}

```

![Blazor Smith Chart with Custom Tooltip](./images/Tooltip/blazor-smith-chart-custom-tooltip.png)

## Tooltip Template

To display custom content in the tooltip, use a template. The implicit named parameter `context` can be typecast as [SmithChartPoint](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SmithChartPoint.html) to access aggregate values within the template.

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
                    <div style="background-color: blue">@data.Resistance: @data.Reactance</div>
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
        new SmithChartData { Resistance = 10, Reactance = 25 },
        new SmithChartData { Resistance = 6, Reactance = 4.5 },
        new SmithChartData { Resistance = 3.5, Reactance = 1.6 },
        new SmithChartData { Resistance = 2, Reactance = 1.2 },
        new SmithChartData { Resistance = 1, Reactance = 0.8 },
        new SmithChartData { Resistance = 0, Reactance = 0.2 }
    };
}

```

![Blazor Smith Chart with Tooltip Template](./images/Tooltip/blazor-smith-chart-tooltip-template.png)
