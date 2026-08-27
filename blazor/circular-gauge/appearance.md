---
layout: post
title: Blazor Circular Gauge Appearance | Syncfusion®
description: Learn how to customize the Blazor Circular Gauge title, position, and background using properties like Title, CenterX, CenterY, and Background.
platform: Blazor
control: Circular Gauge
documentation: ug
---

# Blazor Circular Gauge Appearance

## Circular gauge title

You can add a title to the Circular Gauge using the [Title](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_Title) property. The title can be customized using the [CircularGaugeTitleStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeTitleStyle.html) tag, which supports properties such as `Color`, `FontFamily`, `FontStyle`, `FontWeight`, and `Size`.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge Title="Speedometer">
    <CircularGaugeTitleStyle Color="blue" FontWeight="bold" Size="25"></CircularGaugeTitleStyle>
    <CircularGaugeAxes>
       <CircularGaugeAxis>
           <CircularGaugePointers>
              <CircularGaugePointer></CircularGaugePointer>
           </CircularGaugePointers>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BjLxDHLdBYmAiGzW?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Circular Gauge with Title](./images/blazor-circulargauge-title.webp)" %}

## Circular gauge position

The Circular Gauge can be positioned anywhere in the container using the [CenterX](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_CenterX) and [CenterY](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_CenterY) properties which accept values either in percentage or in pixels. The default value of the [CenterX](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_CenterX) and [CenterY](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_CenterY) properties are 50%, so the Circular Gauge is rendered at the center of the container.

### In pixels

You can set the center point of the Circular Gauge in pixels as shown below. Because the values place the gauge near the top-left of its container, part of the gauge may appear clipped at the edge.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge CenterX="20px" CenterY="20px">
    <CircularGaugeAxes>
        <CircularGaugeAxis StartAngle="90" EndAngle="180">
        <CircularGaugePointers><CircularGaugePointer Value="0"></CircularGaugePointer></CircularGaugePointers>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hjVxDdVHLVCdTrQv?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Changing Blazor Circular Gauge Position based on Pixel Value](./images/blazor-circulargauge-custom-position.webp)" %}

### In percentage

By setting the value in percentage, the Circular Gauge's center point is calculated relative to its plot area. For example, when setting the value of [CenterX](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_CenterX) to '1%' and the value of [CenterY](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_CenterY) to '50%', the gauge is positioned at the top-left corner of the plot area.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge CenterX="1%" CenterY="50%">
    <CircularGaugeAxes>
        <CircularGaugeAxis StartAngle="0" EndAngle="180">
        <CircularGaugePointers>
                <CircularGaugePointer Value="0"></CircularGaugePointer>
            </CircularGaugePointers></CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rXLRjxVdBnxgiTKs?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Changing Blazor Circular Gauge Position based on Percent Value](./images/blazor-circulargauge-position-based-on-percentage.webp)" %}

## Background customization

Using the [Background](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_Background) and [CircularGaugeBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeBorder.html) properties, you can change the background color and border of the Circular Gauge. The `CircularGaugeBorder` also supports `DashArray` for customizing the border stroke pattern.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge Background="skyblue">
    <CircularGaugeBorder Color="#FF0000"
                         Width="2">
    </CircularGaugeBorder>
    <CircularGaugeAxes>
        <CircularGaugeAxis>
            <CircularGaugeRanges>
                <CircularGaugeRange Start="1"
                                    End="50"
                                    Radius="110%">
                </CircularGaugeRange>
                <CircularGaugeRange Start="80"
                                    End="100"
                                    Radius="110%">
                </CircularGaugeRange>
            </CircularGaugeRanges>
            <CircularGaugePointers>
                <CircularGaugePointer Value="50"
                                      Radius="60%">
                </CircularGaugePointer>
            </CircularGaugePointers>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VjLHZHBdVkFWzIZn?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Changing Background and Border of Blazor Circular Gauge](./images/blazor-circulargauge-background-border-color.webp)" %}

## Radius calculation based on angles

You can render semi or quarter Circular Gauge by modifying the start and end angles. By enabling the radius based on angle option, the radius of circular gauge will be calculated based on the start and end angles to avoid excess white space.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge>
    <CircularGaugeAxes>
        <CircularGaugeAxis Radius="60%" StartAngle="270" EndAngle="90">
            <CircularGaugeAxisLineStyle Width="5">
            </CircularGaugeAxisLineStyle>
            <CircularGaugePointers><CircularGaugePointer Value="0"></CircularGaugePointer></CircularGaugePointers>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDVHNxVnLhJYJyGw?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Circular Gauge with Custom Radius and Angle](./images/blazor-circulargauge-custom-radius-angle.webp)" %}

## See also

* [Axes in Blazor Circular Gauge](axes.html)
* [Dimensions in Blazor Circular Gauge](dimensions.html)
* [Globalization in Blazor Circular Gauge](globalization.html)
