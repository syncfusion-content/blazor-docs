---
layout: postStacked Bar
title: Stacked Bar in Blazor 3D Chart Component | Syncfusion
description: Checkout and learn here all about Stacked Bar Chart in Syncfusion Blazor 3D Chart component and much more.
platform: Blazor
control: 3D Chart
documentation: ug
---

# Stacked Bar in Blazor 3D Chart Component

## Stacked Bar

To render a Stacked Bar series, use series [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Type) as `StackingBar`.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></Chart3DPrimaryXAxis>

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@MedalDetails" XName="X" YName="YValue" Type="Chart3DSeriesType.StackingBar">
        </Chart3DSeries>
        <Chart3DSeries DataSource="@MedalDetails" XName="X" YName="YValue1" Type="Chart3DSeriesType.StackingBar">
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Chart3DData
    {
        public string X { get; set; }
        public double YValue { get; set; }
        public double YValue1 { get; set; }
    }
	
    public List<Chart3DData> MedalDetails = new List<Chart3DData>
	{
        new Chart3DData { X= "USA", YValue= 46, YValue1=56 },
        new Chart3DData { X= "GBR", YValue= 27, YValue1=17 },
        new Chart3DData { X= "CHN", YValue= 26, YValue1=36 },
        new Chart3DData { X= "UK", YValue= 56,  YValue1=16 },
        new Chart3DData { X= "AUS", YValue= 12, YValue1=46 },
        new Chart3DData { X= "IND", YValue= 26, YValue1=16 },
        new Chart3DData { X= "DEN", YValue= 26, YValue1=12 },
        new Chart3DData { X= "MEX", YValue= 34, YValue1=32},
    };
}

``` 
{% previewsample "https://blazorplayground.syncfusion.com/embed/LXVqWLrRzHvzyQHq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Stacked Bar 3D Chart](../images/chart-types-images/blazor-stacked-Bar-chart.png)

## Stacking group

To group the Stacked Bar, the [StackingGroup](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_StackingGroup) property can be used. The columns with same group name are stacked on top of each other.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></Chart3DPrimaryXAxis>

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@DataSource" StackingGroup="Group1" XName="X" YName="YValue" Type="Chart3DSeriesType.StackingBar">
        </Chart3DSeries>
        <Chart3DSeries DataSource="@DataSource" StackingGroup="Group1" XName="X" YName="YValue1" Type="Chart3DSeriesType.StackingBar">
        </Chart3DSeries>
        <Chart3DSeries DataSource="@DataSource" StackingGroup="Group2" XName="X" YName="YValue2" Type="Chart3DSeriesType.StackingBar">
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Chart3DData
    {
        public string X { get; set; }
        public double YValue { get; set; }
        public double YValue1 { get; set; }
        public double YValue2 { get; set; }
    }

    public List<Chart3DData> DataSource = new List<Chart3DData>
	{
        new Chart3DData { X= "USA", YValue= 46, YValue1=56, YValue2=26},
        new Chart3DData { X= "GBR", YValue= 27, YValue1=17, YValue2=37},
        new Chart3DData { X= "CHN", YValue= 26, YValue1=36, YValue2=56},
        new Chart3DData { X= "UK", YValue= 56,  YValue1=16, YValue2=36},
        new Chart3DData { X= "AUS", YValue= 12, YValue1=46, YValue2=26},
        new Chart3DData { X= "IND", YValue= 26, YValue1=16, YValue2=76},
        new Chart3DData { X= "DEN", YValue= 26, YValue1=12, YValue2=42},
        new Chart3DData { X= "MEX", YValue= 34, YValue1=32, YValue2=82 },
    };
}


``` 

![Grouping in Blazor Stacked Bar 3D Chart](../images/chart-types-images/blazor-stacked-bar-chart-with-grouping.png)

## Cylindrical column chart

To render a cylindrical Stacked Bar chart, set the [`ColumnFacet`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeriesType.html#Syncfusion_Blazor_Charts_ChartSeriesType_Bar) property to `Cylinder` in the chart series.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></Chart3DPrimaryXAxis>

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@DataSource" XName="X" YName="YValue" ColumnFacet="Chart3DShapeType.Cylinder" Type="Chart3DSeriesType.StackingBar">
        </Chart3DSeries>
        <Chart3DSeries DataSource="@DataSource" XName="X" YName="YValue1" ColumnFacet="Chart3DShapeType.Cylinder" Type="Chart3DSeriesType.StackingBar">
        </Chart3DSeries>
        <Chart3DSeries DataSource="@DataSource" XName="X" YName="YValue2" ColumnFacet="Chart3DShapeType.Cylinder" Type="Chart3DSeriesType.StackingBar">
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Chart3DData
    {
        public string X { get; set; }
        public double YValue { get; set; }
        public double YValue1 { get; set; }
        public double YValue2 { get; set; }
    }

    public List<Chart3DData> DataSource = new List<Chart3DData>
	{
        new Chart3DData { X= "USA", YValue= 46, YValue1=56, YValue2=26},
        new Chart3DData { X= "GBR", YValue= 27, YValue1=17, YValue2=37},
        new Chart3DData { X= "CHN", YValue= 26, YValue1=36, YValue2=56},
        new Chart3DData { X= "UK", YValue= 56,  YValue1=16, YValue2=36},
        new Chart3DData { X= "AUS", YValue= 12, YValue1=46, YValue2=26},
        new Chart3DData { X= "IND", YValue= 26, YValue1=16, YValue2=76},
        new Chart3DData { X= "DEN", YValue= 26, YValue1=12, YValue2=42},
        new Chart3DData { X= "MEX", YValue= 34, YValue1=32, YValue2=82 },
    };
}

```

![Blazor Cylindrical Bar 3D Chart](../images/chart-types-images/blazor-cylindricaal-stacked-bar-chart.png)

## Series customization

The following properties can be used to customize the `Stacked Bar` series.

* [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) – Specifies the color of the series.
* [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Opacity) – Specifies the opacity of the [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.ChartSeries.html#Syncfusion_Blazor_Charts_ChartSeries_Fill) color.

```cshtml

@using Syncfusion.Blazor.Chart3D

<SfChart3D WallColor="transparent" EnableRotation="true" RotationAngle="7" TiltAngle="10" Depth="100">
    <Chart3DPrimaryXAxis ValueType="Syncfusion.Blazor.Charts.ValueType.Category"></Chart3DPrimaryXAxis>

    <Chart3DSeriesCollection>
        <Chart3DSeries DataSource="@DataSource" XName="X" YName="YValue" Fill="green" Type="Chart3DSeriesType.StackingBar">
        </Chart3DSeries>
        <Chart3DSeries DataSource="@DataSource" XName="X" YName="YValue1" Fill="red" Type="Chart3DSeriesType.StackingBar">
        </Chart3DSeries>
        <Chart3DSeries DataSource="@DataSource" XName="X" YName="YValue2" Fill="yellow" Type="Chart3DSeriesType.StackingBar">
        </Chart3DSeries>
    </Chart3DSeriesCollection>
</SfChart3D>

@code{
    public class Chart3DData
    {
        public string X { get; set; }
        public double YValue { get; set; }
        public double YValue1 { get; set; }
        public double YValue2 { get; set; }
    }

    public List<Chart3DData> DataSource = new List<Chart3DData>
	{
        new Chart3DData { X= "USA", YValue= 46, YValue1=56, YValue2=26},
        new Chart3DData { X= "GBR", YValue= 27, YValue1=17, YValue2=37},
        new Chart3DData { X= "CHN", YValue= 26, YValue1=36, YValue2=56},
        new Chart3DData { X= "UK", YValue= 56,  YValue1=16, YValue2=36},
        new Chart3DData { X= "AUS", YValue= 12, YValue1=46, YValue2=26},
        new Chart3DData { X= "IND", YValue= 26, YValue1=16, YValue2=76},
        new Chart3DData { X= "DEN", YValue= 26, YValue1=12, YValue2=42},
        new Chart3DData { X= "MEX", YValue= 34, YValue1=32, YValue2=82 },
    };
}

``` 

![Blazor Stacked Bar 3D Chart with Custom Series](../images/chart-types-images/blazor-stacked-bar-chart-custom-series.png)

N> Refer to our [Blazor 3D Chart](https://www.syncfusion.com/blazor-components/blazor-charts) feature tour page for its groundbreaking feature representations and also explore our [Blazor 3D Chart Example](https://blazor.syncfusion.com/demos/chart/line?theme=bootstrap4) to know various 3D Chart types and how to represent time-dependent data, showing trends at equal intervals.

## See also

* [Data Label](../data-labels)
* [Tooltip](../tool-tip)