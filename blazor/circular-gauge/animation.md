---
layout: post
title: Blazor Circular Gauge Animation | Syncfusion®
description: Learn how to animate the Blazor Circular Gauge elements sequentially using the AnimationDuration property to render axis, ticks, labels, and pointers.
platform: Blazor
control: Circular Gauge
documentation: ug
---

# Blazor Circular Gauge Animation

All the elements in the Circular Gauge, such as axis lines, ticks, labels, ranges, pointers, and annotations, can be animated sequentially using the [AnimationDuration](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_AnimationDuration) property. Set the `AnimationDuration` property to an appropriate value, in milliseconds, to enable a smooth rendering effect for the component; the default value is **0**, which disables the animation. When the animation is enabled, the component will render its elements in the following order.

1. Axis line, in the rendering direction (clockwise or anticlockwise).
2. Each tick line and label.
3. Ranges, if available.
4. Pointers, if available, animated as described in [pointer animation](https://blazor.syncfusion.com/documentation/circular-gauge/pointers#pointer-animation).
5. Annotations, if available.

## Animation duration

Set [AnimationDuration](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_AnimationDuration) on the [SfCircularGauge](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html) tag to a positive double value (in milliseconds). Use **0** to disable the animation.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge AnimationDuration="2000">
    <CircularGaugeAxes>
        <CircularGaugeAxis Radius="80%" StartAngle="230" EndAngle="130">
            <CircularGaugeAxisLabelStyle Offset="-1">
                <CircularGaugeAxisLabelFont FontFamily="inherit"></CircularGaugeAxisLabelFont>
            </CircularGaugeAxisLabelStyle>
            <CircularGaugeAxisLineStyle Width="8" Color="#E0E0E0" />
            <CircularGaugeAxisMajorTicks Offset="5" />
            <CircularGaugeAxisMinorTicks Offset="5" />
            <CircularGaugePointers>
                <CircularGaugePointer Value="60" Radius="60%" PointerWidth="7" Color="#c06c84">
                    <CircularGaugePointerAnimation Duration="500" />
                    <CircularGaugeCap Radius="8" Color="#c06c84">
                        <CircularGaugeCapBorder Width="0" />
                    </CircularGaugeCap>
                    <CircularGaugeNeedleTail Length="0%" />
                </CircularGaugePointer>
            </CircularGaugePointers>
            <CircularGaugeRanges>
                <CircularGaugeRange Color="#E63B86" Start="0" End="30" StartWidth="22" EndWidth="22" Radius="60%">
                    <LinearGradient StartValue="0%" EndValue="100%">
                        <ColorStops>
                            <ColorStop Opacity="1" Offset="0%" Color="#9e40dc" />
                            <ColorStop Opacity="1" Offset="70%" Color="#d93c95" />
                        </ColorStops>
                    </LinearGradient>
                </CircularGaugeRange>
                <CircularGaugeRange Color="#E0E0E0" Start="30" End="60" StartWidth="22" EndWidth="22" Radius="60%" />
            </CircularGaugeRanges>
            <CircularGaugeAnnotations>
                <CircularGaugeAnnotation Angle="165" Radius="35%" ZIndex="1">
                    <ContentTemplate>
                        <div style="font-size:18px;margin-left: -20px;margin-top: -12px; color:#9DD55A">60</div>
                    </ContentTemplate>
                </CircularGaugeAnnotation>
            </CircularGaugeAnnotations>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/cjBSjshRrgGPmZbb?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Circular Gauge Animation](./images/blazor-circulargauge-animation.webp)" %}

![Blazor Circular Gauge Animation](./images/blazor-circulargauge-animation.webp)

N> Only the pointer of the Circular Gauge can be animated individually; the axis lines, ticks, labels, ranges, and annotations cannot. Refer to the [pointer animation](https://blazor.syncfusion.com/documentation/circular-gauge/pointers#pointer-animation) section to animate only the pointer.

## See also

* [Blazor Circular Gauge Pointers](https://blazor.syncfusion.com/documentation/circular-gauge/pointers)
* [Blazor Circular Gauge Ranges](https://blazor.syncfusion.com/documentation/circular-gauge/ranges)
* [Blazor Circular Gauge Annotations](https://blazor.syncfusion.com/documentation/circular-gauge/annotations)

