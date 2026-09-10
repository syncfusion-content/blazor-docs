---
layout: post
title: Blazor Charts Dimensions and Sizing | Syncfusion®
description: Learn how to set Blazor Charts dimensions with Width and Height properties. Use percentages and a CDN script to avoid layout redraws.
platform: Blazor
control: Charts
documentation: ug
---

# Blazor Charts Dimensions

N> 
* When no size is specified, the default height and width are 450px and 600px, respectively.
* When the chart's size is set in [percentages](#in-percentage) or through [parent element styles](#size-for-container), the chart is first rendered at the default size and then redrawn responsively. Add the following CDN script to the page header to suppress this redraw.

## Avoid layout redraws

When the chart is sized in percentages or via a parent element's style, the chart is initially rendered at the default size and then resized. Add the following CDN script to the page header to suppress this initial redraw:

```html
<head>
    ...
   <!-- Add the CDN link below to suppress the initial redraw. -->
   <script src="https://cdn.syncfusion.com/blazor/syncfusion-blazor-base.min.js"></script>
</head>
```

## Size for container

The chart can be scaled to fit its container. The following example sets the size using CSS on the parent element.

```cshtml
@using Syncfusion.Blazor.Charts

<div style="width:350px; height:350px;">
    <SfChart Title="Inflation - Consumer Price">
        <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>

        <ChartSeriesCollection>
            <ChartSeries DataSource="@ConsumerDetails" XName="X" YName="YValue" Type="ChartSeriesType.Column">
            </ChartSeries>
        </ChartSeriesCollection>
    </SfChart>
</div>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double YValue { get; set; }
    }
	
    public List<ChartData> ConsumerDetails = new List<ChartData>
    {
        new ChartData { X= "USA", YValue= 46 },
        new ChartData { X= "GBR", YValue= 27 },
        new ChartData { X= "CHN", YValue= 26 },
        new ChartData { X= "UK", YValue= 36 },
        new ChartData { X= "AUS", YValue= 15 },
        new ChartData { X= "IND", YValue= 55 },
        new ChartData { X= "DEN", YValue= 40 },
        new ChartData { X= "MEX", YValue= 30 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hXLRjlCKKorjdRXQ?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Changing Blazor Chart Size as Fit to Container](images/chart-dimensions/blazor-chart-size-for-container.webp)" %}

## Size for chart

The [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_Height) properties specify the size of the chart in pixels or percentages directly.

### In pixel

The [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_Height) properties can be set in pixels, as shown in the following example.

```cshtml

@using Syncfusion.Blazor.Charts

<SfChart Title="Inflation - Consumer Price" Width="650px" Height="250px">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@ConsumerDetails" XName="X" YName="YValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double YValue { get; set; }
    }
	
    public List<ChartData> ConsumerDetails = new List<ChartData>
	{
        new ChartData { X= "USA", YValue= 46 },
        new ChartData { X= "GBR", YValue= 27 },
        new ChartData { X= "CHN", YValue= 26 },
        new ChartData { X= "UK", YValue= 36 },
        new ChartData { X= "AUS", YValue= 15 },
        new ChartData { X= "IND", YValue= 55 },
        new ChartData { X= "DEN", YValue= 40 },
        new ChartData { X= "MEX", YValue= 30 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXVHZdWBKOuiSdXp?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Changing Blazor Chart Size in Pixel](images/chart-dimensions/blazor-chart-size-in-pixel.webp)" %}

### In percentage

By setting the values of [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_Height) in percentage, the chart's dimensions scale with respect to its container. For example, when the [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html#Syncfusion_Blazor_Charts_SfChart_Height) is set to **50%**, the chart is half the height of its container.

```cshtml
@using Syncfusion.Blazor.Charts

<SfChart Title="Inflation - Consumer Price" Width="60%" Height="90%">
    <ChartPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></ChartPrimaryXAxis>

    <ChartSeriesCollection>
        <ChartSeries DataSource="@ConsumerDetails" XName="X" YName="YValue" Type="ChartSeriesType.Column">
        </ChartSeries>
    </ChartSeriesCollection>
</SfChart>

@code{
    public class ChartData
    {
        public string X { get; set; }
        public double YValue { get; set; }
    }
	
    public List<ChartData> ConsumerDetails = new List<ChartData>
	{		
        new ChartData { X= "USA", YValue= 46 },
        new ChartData { X= "GBR", YValue= 27 },
        new ChartData { X= "CHN", YValue= 26 },
        new ChartData { X= "UK", YValue= 36 },
        new ChartData { X= "AUS", YValue= 15 },
        new ChartData { X= "IND", YValue= 55 },
        new ChartData { X= "DEN", YValue= 40 },
        new ChartData { X= "MEX", YValue= 30 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LXVRjniVKOYcqiis?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Changing Blazor Chart Size in Percentage](images/chart-dimensions/blazor-chart-size-in-percentage.webp)" %}

N> For a full list of supported properties, see the [SfChart API reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfChart.html). To see how different chart types render across sizing options, explore the [Blazor Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=fluent2).

## See also

* [Chart Appearance](./chart-appearance)
* [Adaptive Layout](./adaptive-layout)
* [Chart Print](./chart-print)