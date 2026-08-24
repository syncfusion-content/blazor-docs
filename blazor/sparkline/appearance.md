---
layout: post
title: Blazor Sparkline Charts Appearance Examples | Syncfusion®
description: Learn how to customize the appearance of Syncfusion Blazor Sparkline, including RTL, padding, border, and background options.
platform: Blazor
control: Sparkline Charts
documentation: ug
---

# Blazor Sparkline Charts Appearance

The rendering direction and visual appearance of the Sparkline can be customized using padding, border, and background settings.

## Right-to-Left (RTL)

Right-to-left (RTL) rendering is supported and can be enabled by setting the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SfSparkline-1.html#Syncfusion_Blazor_Charts_SfSparkline_1_EnableRtl) property to **true**.

```cshtml

@using Syncfusion.Blazor.Charts

<SfSparkline DataSource="new double[]{ 300.00, 600.00, 400.21, 100.20, 300.70, 200.04, 500.00 }" Height="200px" Width="350px" Format="c2" EnableRtl="true">
    <SparklineDataLabelSettings Visible="new List<VisibleType> { VisibleType.All }" EdgeLabelMode="EdgeLabelMode.Shift"></SparklineDataLabelSettings>
    <SparklinePadding Top="25"></SparklinePadding>
</SfSparkline>

```

![Right to Left in Blazor Sparkline Chart](images/Appearance/blazor-sparkline-right-to-left.webp)

## Border

The border can be enabled and customized by specifying the [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BorderSettings.html#Syncfusion_Blazor_Charts_BorderSettings_Color) and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.BorderSettings.html#Syncfusion_Blazor_Charts_BorderSettings_Width) properties of [SparklineContainerAreaBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineContainerAreaBorder.html). This border surrounds the container area. To customize the border around the Sparkline itself, use [SparklineBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineBorder.html).

```cshtml

@using Syncfusion.Blazor.Charts

<SfSparkline DataSource="new int[]{ 3, 6, 4, 1, 3, 2, 5 }" Type="SparklineType.Area" Height="200px" Width="350px" Fill="#b2cfff" LineWidth="1">
    <SparklineContainerArea>
        <SparklineContainerAreaBorder Color="#033e96" Width="1"></SparklineContainerAreaBorder>
    </SparklineContainerArea>
</SfSparkline>

```

![Blazor Sparkline Chart with Border](images/Appearance/blazor-sparkline-with-border.webp)

## Padding

Padding between the container and the component is supported using [SparklinePadding](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklinePadding.html). The following example sets the top, right, bottom, and left padding to 20.

```cshtml

@using Syncfusion.Blazor.Charts

<SfSparkline DataSource="new int[]{ 3, 6, 4, 1, 3, 2, 5 }" Type="SparklineType.Area" Height="200px" Width="350px" Fill="#b2cfff" LineWidth="1">
    <SparklineContainerArea>
        <SparklineContainerAreaBorder Color="#033e96" Width="2"></SparklineContainerAreaBorder>
    </SparklineContainerArea>
    <SparklineBorder Color="#033e96" Width="1"></SparklineBorder>
    <SparklinePadding Left="20" Right="20" Bottom="20" Top="20"></SparklinePadding>
</SfSparkline>

```

![Blazor Sparkline Chart with Padding](images/Appearance/blazor-sparkline-with-padding.webp)

## Background

The background color of the Sparkline container area can be changed using the [Background](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineContainerArea.html#Syncfusion_Blazor_Charts_SparklineContainerArea_Background) property of [SparklineContainerArea](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Charts.SparklineContainerArea.html). By default, the background color is **Transparent**. The example also configures the container-area and Sparkline borders to distinguish the padded region.

```cshtml

@using Syncfusion.Blazor.Charts

<SfSparkline DataSource="new int[]{ 3, 6, 4, 1, 3, 2, 5 }" Type="SparklineType.Area" Height="200px" Width="350px" Fill="#b2cfff" LineWidth="1">
    <SparklineContainerArea Background="#eff1f4">
        <SparklineContainerAreaBorder Color="#033e96" Width="2">
        </SparklineContainerAreaBorder>
    </SparklineContainerArea>
    <SparklineBorder Color="#033e96" Width="1"></SparklineBorder>
    <SparklinePadding Left="20" Right="20" Bottom="20" Top="20"></SparklinePadding>
</SfSparkline>

```

![Blazor Sparkline Chart with Custom Background](images/Appearance/blazor-sparkline-custom-background.webp)
