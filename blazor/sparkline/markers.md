---
layout: post
title: Markers in Blazor Sparkline Component | Syncfusion
description: Check out and learn about marker options and customization in the Syncfusion Blazor Sparkline component.
platform: Blazor
control: Sparkline Charts
documentation: ug
---

# Markers in Blazor Sparkline Component

Data markers provide information about data points in the Sparkline series.

## Adding Markers

The [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineMarkerSettings.html#Syncfusion_Blazor_Charts_SparklineMarkerSettings_Visible) property in [SparklineMarkerSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineMarkerSettings.html) enables markers by specifying a collection of special points. The following example shows how to enable markers for all points.

```cshtml

@using Syncfusion.Blazor.Charts

<SfSparkline DataSource="new int[]{ 0, 6, 4, 1, 3, 2, 5 }" Type="SparklineType.Line" Height="200px" Width="350px">
    <SparklineMarkerSettings Visible="new List<VisibleType> { VisibleType.All }"></SparklineMarkerSettings>
    <SparklineAxisSettings MinX="-1" MaxX="7" MaxY="7" MinY="-1"></SparklineAxisSettings>
</SfSparkline>

```

![Blazor Sparkline Chart with Marker](./images/marker/blazor-sparkline-marker.png)

## Adding Special Point Markers

Markers can be enabled for specific points as a collection. The following special points are applicable:

* [All](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.VisibleType.html#Syncfusion_Blazor_Charts_VisibleType_All) – Markers for all points
* [Start](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.VisibleType.html#Syncfusion_Blazor_Charts_VisibleType_Start) – Markers for start points
* [End](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.VisibleType.html#Syncfusion_Blazor_Charts_VisibleType_End) – Markers for end points
* [High](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.VisibleType.html#Syncfusion_Blazor_Charts_VisibleType_High) – Markers for high points
* [Low](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.VisibleType.html#Syncfusion_Blazor_Charts_VisibleType_Low) – Markers for low points
* [Negative](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.VisibleType.html#Syncfusion_Blazor_Charts_VisibleType_Negative) – Markers for negative points
* [None](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.VisibleType.html#Syncfusion_Blazor_Charts_VisibleType_None) – Markers for all points are disabled

```cshtml

@using Syncfusion.Blazor.Charts

<SfSparkline DataSource="new int[]{ 0, 6, 4, 1, 3, 2, 5 }" Type="SparklineType.Line" Height="200px" Width="350px" HighPointColor="Blue" LowPointColor="Red">
    <SparklineMarkerSettings Visible="new List<VisibleType> { VisibleType.High, VisibleType.Low }"></SparklineMarkerSettings>
    <SparklineAxisSettings MinX="-1" MaxX="7" MaxY="7" MinY="-1"></SparklineAxisSettings>
</SfSparkline>

```

![Displaying High and Low Points Marker in Blazor Sparkline Chart](./images/marker/blazor-sparkline-high-low-point-marker.png)

## Markers Customization

The following properties can be used to customize markers:

* [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineMarkerSettings.html#Syncfusion_Blazor_Charts_SparklineMarkerSettings_Fill) - Specifies fill color for marker
* [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineMarkerSettings.html#Syncfusion_Blazor_Charts_SparklineMarkerSettings_Opacity) - Specifies opacity of marker [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineMarkerSettings.html#Syncfusion_Blazor_Charts_SparklineMarkerSettings_Fill) color
* [Size](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineMarkerSettings.html#Syncfusion_Blazor_Charts_SparklineMarkerSettings_Size) - Specifies marker size
* [SparklineMarkerBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineMarkerBorder.html) - Specifies color and width for marker border

```cshtml

@using Syncfusion.Blazor.Charts

<SfSparkline DataSource="new int[]{ 0, 6, 4, 1, 3, 2, 5 }" Type="SparklineType.Line" Height="200px" Width="450px">
    <SparklineMarkerSettings Visible="new List<VisibleType> { VisibleType.All }" Fill="yellow" Opacity="0.4" Size="8">
        <SparklineMarkerBorder Color="green" Width="1">
        </SparklineMarkerBorder>
    </SparklineMarkerSettings>
    <SparklineAxisSettings MinX="-1" MaxX="7" MaxY="7" MinY="-1"></SparklineAxisSettings>
</SfSparkline>

```

![Blazor Sparkline Chart with Custom Marker](./images/marker/blazor-sparkline-custom-marker.png)
