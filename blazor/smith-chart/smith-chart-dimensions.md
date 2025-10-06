---
layout: post
title: Dimensions in Blazor Smith Chart Component | Syncfusion
description: Check out and learn how to set and customize dimensions in Syncfusion Blazor Smith Chart component.
platform: Blazor
control: Smith Chart
documentation: ug
---

# Dimensions in Blazor Smith Chart Component

The dimensions of the Smith Chart can be modified in the following ways.

* Using CSS
* Using API

## Using CSS

To set the chart size with CSS, assign an [ID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfSmithChart.html#Syncfusion_Blazor_Charts_SfSmithChart_ID) to the `SfSmithChart` tag and define the width and height in a style block, as shown below.

```cshtml

@using Syncfusion.Blazor.Charts

<SfSmithChart ID="smChart">
    <SmithChartSeriesCollection>
        <SmithChartSeries DataSource='TransmissionData' Reactance="Reactance" Resistance="Resistance">
        </SmithChartSeries>
    </SmithChartSeriesCollection>
</SfSmithChart>

<style>
    #smChart {
        height: 300px !important;
        width: 300px !important;
    }
</style>

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

![Dimensions in Blazor Smith Chart via CSS](./images/Dimension/blazor-smith-chart-dimensions.png)

## Using API

The width and height can also be set directly using the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfSmithChart.html#Syncfusion_Blazor_Charts_SfSmithChart_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfSmithChart.html#Syncfusion_Blazor_Charts_SfSmithChart_Height) properties. These values may be specified in pixels or as a percentage.

### In Pixels

Set the `Width` and `Height` properties in pixels to define the exact size of the chart.

```cshtml

@using Syncfusion.Blazor.Charts

<SfSmithChart Height="300px" Width="300px">
    <SmithChartSeriesCollection>
        <SmithChartSeries DataSource='TransmissionData' Reactance="Reactance" Resistance="Resistance">
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

![Changing Blazor Smith Chart Dimensions in pixel](./images/Dimension/blazor-smith-chart-dimensions.png)

### In Percentage

The `Width` and `Height` properties may also be specified as percentages. In this case, the chart scales relative to its container.

```cshtml

@using Syncfusion.Blazor.Charts

<div style="height:600px; width:600px">
    <SfSmithChart Height="50%" Width="50%">
        <SmithChartSeriesCollection>
            <SmithChartSeries DataSource='FirstTransmissionData' Reactance="Reactance" Resistance="Resistance">
            </SmithChartSeries>
        </SmithChartSeriesCollection>
    </SfSmithChart>
</div>

@code {
    public class SmithChartData
    {
        public double? Resistance { get; set; }
        public double? Reactance { get; set; }
    };
    
    public List<SmithChartData> FirstTransmissionData = new List<SmithChartData> {
        new SmithChartData { Resistance = 10, Reactance = 25 },
        new SmithChartData { Resistance = 6, Reactance = 4.5 },
        new SmithChartData { Resistance = 3.5, Reactance = 1.6 },
        new SmithChartData { Resistance = 2, Reactance = 1.2 },
        new SmithChartData { Resistance = 1, Reactance = 0.8 },
        new SmithChartData { Resistance = 0, Reactance = 0.2 }
    };
}

```

![Changing Blazor Smith Chart Dimensions in Percentage](./images/Dimension/blazor-smith-chart-dimensions.png)
