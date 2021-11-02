---
layout: post
title: Markers in Blazor Sparkline Component | Syncfusion
description: Checkout and learn here all about markers in Syncfusion Blazor Sparkline component and much more details.
platform: Blazor
control: Sparkline Charts
documentation: ug
---

# Markers in Blazor Sparkline Component

Data markers are used to provide information about the data points in the Sparkline series.

## Adding markers

The [Visible](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineMarkerSettings.html#Syncfusion_Blazor_Charts_SparklineMarkerSettings_Visible) property in the [SparklineMarkerSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineMarkerSettings.html) can be used to enable a marker by specifying a collection of special points. The following code example shows how to enable markers for all points.

```cshtml
@using Syncfusion.Blazor.Charts

<SfSparkline DataSource="new int[]{ 0, 6, 4, 1, 3, 2, 5 }" Type="SparklineType.Line" Height="200px" Width="350px">
    <SparklineMarkerSettings Visible="new List<VisibleType> { VisibleType.All }"></SparklineMarkerSettings>
    <SparklineAxisSettings MinX="-1" MaxX="7" MaxY="7" MinY="-1"></SparklineAxisSettings>
</SfSparkline>
```

![Blazor Sparkline Chart with Marker](./images/marker/blazor-sparkline-marker.png)

## Adding special point markers

The markers can be enabled for specific points as a collection. The following special points are applicable for markers.

* [All](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.VisibleType.html#Syncfusion_Blazor_Charts_VisibleType_All) - Markers for all points are enabled.
* [Start](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.VisibleType.html#Syncfusion_Blazor_Charts_VisibleType_Start) - Markers for start points are enabled.
* [End](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.VisibleType.html#Syncfusion_Blazor_Charts_VisibleType_End) - Markers for end points are enabled.
* [High](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.VisibleType.html#Syncfusion_Blazor_Charts_VisibleType_High) - Markers for high points are enabled.
* [Low](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.VisibleType.html#Syncfusion_Blazor_Charts_VisibleType_Low) - Markers for low points are enabled.
* [Negative](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.VisibleType.html#Syncfusion_Blazor_Charts_VisibleType_Negative) - Markers for negative points are enabled.
* [None](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.VisibleType.html#Syncfusion_Blazor_Charts_VisibleType_None) - Markers for all points are disabled.


```cshtml
@using Syncfusion.Blazor.Charts

<SfSparkline DataSource="new int[]{ 0, 6, 4, 1, 3, 2, 5 }" Type="SparklineType.Line" Height="200px" Width="350px" HighPointColor="Blue" LowPointColor="Red">
    <SparklineMarkerSettings Visible="new List<VisibleType> { VisibleType.High, VisibleType.Low }"></SparklineMarkerSettings>
    <SparklineAxisSettings MinX="-1" MaxX="7" MaxY="7" MinY="-1"></SparklineAxisSettings>
</SfSparkline>
```

![Displaying High and Low Points Marker in Blazor Sparkline Chart](./images/marker/blazor-sparkline-high-low-point-marker.png)

## Markers customization

The following properties can be used to customize markers:

* [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineMarkerSettings.html#Syncfusion_Blazor_Charts_SparklineMarkerSettings_Fill) - Specifies fill color for marker.
* [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineMarkerSettings.html#Syncfusion_Blazor_Charts_SparklineMarkerSettings_Opacity) - Specifies opacity of [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineMarkerSettings.html#Syncfusion_Blazor_Charts_SparklineMarkerSettings_Fill) color for marker.
* [Size](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineMarkerSettings.html#Syncfusion_Blazor_Charts_SparklineMarkerSettings_Size) - Specifies marker size.
* [SparklineMarkerBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineMarkerBorder.html) - Specifies color and width for marker border.

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
