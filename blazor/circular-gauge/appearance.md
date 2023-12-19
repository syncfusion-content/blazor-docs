---
layout: post
title: Appearance in Blazor Circular Gauge Component | Syncfusion
description: Checkout and learn here all about Appearance in Syncfusion Blazor Circular Gauge component and more.
platform: Blazor
control: Circular Gauge
documentation: ug
---

# Appearance in Blazor Circular Gauge Component

## Circular gauge title

You can add a title to the Circular Gauge using the [Title](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_Title)  property. The title can be customized using the [CircularGaugeTitleStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeTitleStyle.html) tag.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge Title="Speedometer">
    <CircularGaugeTitleStyle Color="blue" FontWeight="bold" Size="25"></CircularGaugeTitleStyle>
</SfCircularGauge>
```

![Blazor Circular Gauge with Title](./images/blazor-circulargauge-title.png)

## Circular gauge position

The Circular Gauge can be positioned anywhere in the container using the [CenterX](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_CenterX) and [CenterY](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_CenterY) properties which accept values either in percentage or in pixels. The default value of the [CenterX](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_CenterX) and [CenterY](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_CenterY) properties are 50%, so the Circular Gauge will get rendered to the center of the container.

### In pixel

You can set the mid point of the Circular Gauge in pixel as shown below.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge CenterX="20px" CenterY="20px">
    <CircularGaugeAxes>
        <CircularGaugeAxis StartAngle="90" EndAngle="180"></CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
```

![Changing Blazor Circular Gauge Position based on Pixel Value](./images/blazor-circulargauge-custom-position.png)

### In percentage

By setting the value in percentage, Circular Gauge gets its mid point with respect to its plot area. For example, when setting the value of [CenterX](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_CenterX) to '1%' and the value of [CenterY](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_CenterY) to ‘50%’, the gauge will be positioned at the top-left corner of the plot area.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge CenterX="1%" CenterY="50%">
    <CircularGaugeAxes>
        <CircularGaugeAxis StartAngle="0" EndAngle="180"></CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
```

![changing Blazor Circular Gauge Position based on Percent Value](./images/blazor-circulargauge-position-based-on-percentage.png)

## Background customization

Using the [Background](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_Background) and [CircularGaugeBorder](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeBorder.html) properties, you can change the background color and border of the Circular Gauge.

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

![Changing Background and Border of Blazor Circular Gauge](./images/blazor-circulargauge-background-border-color.png)

## Radius calculation based on angles

You can render semi or quarter Circular Gauge by modifying the start and end angles. By enabling the radius based on angle option, the radius of circular gauge will be calculated based on the start and end angles to avoid excess white space.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge>
    <CircularGaugeAxes>
        <CircularGaugeAxis Radius="60%" StartAngle="270" EndAngle="90">
            <CircularGaugeAxisLineStyle Width="5">
            </CircularGaugeAxisLineStyle>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
```

![Blazor Circular Gauge with Custom Radius and Angle](./images/blazor-circulargauge-custom-radius-angle.png)

## Animating Circular Gauge completely

By setting the [AnimationDuration](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_AnimationDuration) property, all of the elements in the Circular Gauge, such as the axis lines, ticks, labels, ranges, pointers, and annotations, can be animated sequentially. When the `AnimationDuration` property is set to a value in milliseconds, the animation for the Circular Gauge is started, providing a smooth rendering effect for the component. The animation effect will not be started if the property is set to **0**, which is the default value. If this animation is enabled, the component will exhibit the following behavior.
1. The axis line will be animated in the direction of rendering (clockwise or anticlockwise).
2. After that, each tick line and label will be animated.
3. Ranges will be animated if they are available.
4. Pointers will be animated in the same way as [pointer animation](https://blazor.syncfusion.com/documentation/circular-gauge/pointers#pointer-animation) if they are available.
5. Annotations will be animated if they are available.

The animation of the Circular Gauge is demonstrated in the example below.

```cshtml

@using Syncfusion.Blazor.CircularGauge;

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
                    <CircularGaugePointer Value=60 Radius="60%" PointerWidth="7" Color="#c06c84">
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
                        <div style="font-size:18px;margin-left: -20px;margin-top: -12px; color:#9DD55A">@PointerValue</div>
                    </ContentTemplate>
                </CircularGaugeAnnotation>
            </CircularGaugeAnnotations>
            </CircularGaugeAxis>
        </CircularGaugeAxes>
    </SfCircularGauge>

@code {
    public double PointerValue = 60;
}

```

![Blazor Circular Gauge animation](./images/blazor-circulargauge-multiple-elements-animation.gif)


