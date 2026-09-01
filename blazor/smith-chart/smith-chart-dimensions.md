---
layout: post
title: Blazor Smith Chart Dimensions and Sizing | Syncfusion®
description: Learn how to set the size of Syncfusion Blazor Smith Chart using CSS or the Width and Height API with code samples.
platform: Blazor
control: Smith Chart
documentation: ug
---

# Blazor Smith Chart Dimensions

The dimensions of the Smith Chart can be modified in the following ways:

* Using CSS
* Using the `Width` and `Height` API properties

## Using CSS

To set the size using CSS, add an [ID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfSmithChart.html#Syncfusion_Blazor_Charts_SfSmithChart_ID) to the `SfSmithChart` tag, and set the width and height of the Smith Chart in a `style` element as shown below. Use `::deep` before the selector when the style is in a `.razor.css` isolated stylesheet.

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
        new SmithChartData { Resistance= 10, Reactance= 25 },
        new SmithChartData { Resistance= 6, Reactance= 4.5 },
        new SmithChartData { Resistance= 3.5, Reactance= 1.6 },
        new SmithChartData { Resistance= 2, Reactance= 1.2 },
        new SmithChartData { Resistance= 1, Reactance= 0.8 },
        new SmithChartData { Resistance= 0, Reactance= 0.2 }
    };
}
```

![Dimensions in Blazor Smith Chart via CSS](./images/Dimension/blazor-smith-chart-dimensions.webp)

## Using API

The width and height of the Smith Chart can also be set directly using the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfSmithChart.html#Syncfusion_Blazor_Charts_SfSmithChart_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfSmithChart.html#Syncfusion_Blazor_Charts_SfSmithChart_Height) properties. Values can be specified in pixels or percentages. Set both properties explicitly when predictable dimensions are required. Ensure that the `Syncfusion.Blazor.Charts` package is installed and that its version supports `SfSmithChart`.

### In pixels

The [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfSmithChart.html#Syncfusion_Blazor_Charts_SfSmithChart_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfSmithChart.html#Syncfusion_Blazor_Charts_SfSmithChart_Height) properties can be specified in pixels, as shown below.

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
        new SmithChartData { Resistance= 10, Reactance= 25 },
        new SmithChartData { Resistance= 6, Reactance= 4.5 },
        new SmithChartData { Resistance= 3.5, Reactance= 1.6 },
        new SmithChartData { Resistance= 2, Reactance= 1.2 },
        new SmithChartData { Resistance= 1, Reactance= 0.8 },
        new SmithChartData { Resistance= 0, Reactance= 0.2 }
    };
}
```

![Changing Blazor Smith Chart Dimensions in pixel](./images/Dimension/blazor-smith-chart-dimensions.webp)

### In percentages

The Smith Chart's [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfSmithChart.html#Syncfusion_Blazor_Charts_SfSmithChart_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfSmithChart.html#Syncfusion_Blazor_Charts_SfSmithChart_Height) properties can be specified as percentages, as shown below. The component will be rendered as a percentage of its container size. The parent container must have an explicit size, especially an explicit height, for percentage values to resolve correctly.

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
        new SmithChartData { Resistance= 10, Reactance= 25 },
        new SmithChartData { Resistance= 6, Reactance= 4.5 },
        new SmithChartData { Resistance= 3.5, Reactance= 1.6 },
        new SmithChartData { Resistance= 2, Reactance= 1.2 },
        new SmithChartData { Resistance= 1, Reactance= 0.8 },
        new SmithChartData { Resistance= 0, Reactance= 0.2 }
    };
}
```

![Changing Blazor Smith Chart Dimensions in Percentage](./images/Dimension/blazor-smith-chart-dimensions.webp)