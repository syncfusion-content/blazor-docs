---
layout: post
title: Chart Dimensions in Blazor 3D Chart Component | Syncfusion
description: Checkout and learn here all about Chart Dimensions in Syncfusion Blazor 3D Chart component and much more.
platform: Blazor
control: 3D Chart
documentation: ug
---

# Dimensions in Blazor 3D Chart Component

## Size for container

The 3D chart can be rendered to its container size and it can be set via inline or CSS as demonstrated below.

```cshtml

@using Syncfusion.Blazor.Chart3D

<div style="width:650px; height:350px">
    <SfChart3D Title="Inflation - Consumer Price" EnableRotation="true" RotationAngle="22" Depth="100">
        <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category"></Chart3DPrimaryXAxis>

        <Chart3DSeriesCollection>
            <Chart3DSeries DataSource="@ConsumerDetails" XName="X" YName="YValue" Type="Chart3DSeriesType.Column">
            </Chart3DSeries>
        </Chart3DSeriesCollection>
    </SfChart3D>
</div>

@code{
    public class Chart3DData
    {
        public string X { get; set; }
        public double YValue { get; set; }
    }
	
    public List<Chart3DData> ConsumerDetails = new List<Chart3DData>
    {
        new Chart3DData { X = "USA", YValue = 46 },
        new Chart3DData { X = "GBR", YValue = 27 },
        new Chart3DData { X = "CHN", YValue = 26 },
        new Chart3DData { X = "UK", YValue = 36 },
        new Chart3DData { X = "AUS", YValue = 15 },
        new Chart3DData { X = "IND", YValue = 55 },
        new Chart3DData { X = "DEN", YValue = 40 },
        new Chart3DData { X = "MEX", YValue = 30 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VtrJtdsrpsPezXYL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Changing Blazor 3D Chart Size as Fit to Container](images/chart-dimensions/blazor-chart-size-for-container.png)" %}

## Size for chart

The size of the 3D chart can be set directly through `Width` and `Height` properties.

### In Pixel

The size of the 3D chart can be set in pixel as demonstrated below.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D Title="Inflation - Consumer Price" Width="650px" Height="350px" EnableRotation="true" RotationAngle="22" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category"></Chart3DPrimaryXAxis>

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@ConsumerDetails" XName="X" YName="YValue" Type="Chart3DSeriesType.Column">
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Chart3DData
    {
        public string X { get; set; }
        public double YValue { get; set; }
    }
	
    public List<Chart3DData> ConsumerDetails = new List<Chart3DData>
	{
        new Chart3DData { X = "USA", YValue = 46 },
        new Chart3DData { X = "GBR", YValue = 27 },
        new Chart3DData { X = "CHN", YValue = 26 },
        new Chart3DData { X = "UK", YValue = 36 },
        new Chart3DData { X = "AUS", YValue = 15 },
        new Chart3DData { X = "IND", YValue = 55 },
        new Chart3DData { X = "DEN", YValue = 40 },
        new Chart3DData { X = "MEX", YValue = 30 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rZLTZdCrpWvYfGmi?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Changing Blazor 3D Chart Size in Pixel](images/chart-dimensions/blazor-chart-size-in-pixel.png)" %}

### In Percentage

By setting the value in percentage, the 3D Chart gets its dimension with respect to its container. For example, when the `Height` is set to **50%**, the 3D Chart renders to half of the container height.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D Title="Inflation - Consumer Price" Width="80%" Height="90%" EnableRotation="true" RotationAngle="22" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Chart3D.ValueType.Category"></Chart3DPrimaryXAxis>

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@ConsumerDetails" XName="X" YName="YValue" Type="Chart3DSeriesType.Column">
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Chart3DData
    {
        public string X { get; set; }
        public double YValue { get; set; }
    }
	
    public List<Chart3DData> ConsumerDetails = new List<Chart3DData>
	{
        new Chart3DData { X = "USA", YValue = 46 },
        new Chart3DData { X = "GBR", YValue = 27 },
        new Chart3DData { X = "CHN", YValue = 26 },
        new Chart3DData { X = "UK", YValue = 36 },
        new Chart3DData { X = "AUS", YValue = 15 },
        new Chart3DData { X = "IND", YValue = 55 },
        new Chart3DData { X = "DEN", YValue = 40 },
        new Chart3DData { X = "MEX", YValue = 30 }
    };
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDVJDxMrpsargarf?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Changing Blazor 3D Chart Size in Percentage](images/chart-dimensions/blazor-chart-size-in-percentage.png)" %}
