---
layout: post
title: Pointers in Blazor Linear Gauge Component | Syncfusion
description: Learn here all about Pointers in Syncfusion Blazor Linear Gauge component (SfLinearGauge) and more.
platform: Blazor
control: Linear Gauge
documentation: ug
---

# Pointers in Blazor Linear Gauge Component (SfLinearGauge)

Pointers are used to indicate values on an axis. The value of the pointer can be modified using the [`PointerValue`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_PointerValue) property in [`LinearGaugePointer`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html) class.

```csharp
@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeAxes>
        <LinearGaugeAxis>
            <LinearGaugePointers>
                <LinearGaugePointer PointerValue="80">
                </LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>
```

![Linear Gauge with Pointer Sample](images/pointer.png)

## Types of pointer

The Linear Gauge supports the following types of pointers:

* Bar
* Marker

The type of pointer can be modified by using the [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_Type) property in [`LinearGaugePointer`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html) class.

### Marker pointer

A marker pointer is a shape that can be used to mark the pointer value in the Linear Gauge.

<b>Types of marker shapes</b>

By default, the marker shape for the pointer is "**InvertedTriangle**". To change the shape of the pointer, use the [`MarkerType`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_MarkerType) property in [`LinearGaugePointer`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html) class. The following marker types are available in Linear Gauge.

* Circle
* Rectangle
* Triangle
* InvertedTriangle
* Diamond
* Image

An image can be rendered instead of rendering a shape as a pointer. It can be achieved by setting the [`MarkerType`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_MarkerType) property to "**Image**" and setting the source URL of image to [`ImageUrl`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_ImageUrl) property in [`LinearGaugePointer`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html) class.

```csharp
@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeAxes>
        <LinearGaugeAxis>
            <LinearGaugePointers>
                <LinearGaugePointer PointerValue="60" MarkerType="MarkerType.Circle">
                </LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>
```

![Linear Gauge with MarkerType as circle Sample](images/marker.png)

<b>Marker pointer customization</b>

The marker pointer can be customized using the following properties and class.

* [`Height`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_Height) - To set the height of the pointer.
* [`Position`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_Position) - The position of the pointer can be changed by setting the value as "[**Inside**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Position.html#Syncfusion_Blazor_LinearGauge_Position_Inside)","[**Outside**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Position.html#Syncfusion_Blazor_LinearGauge_Position_Outside)", "[**Cross**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Position.html#Syncfusion_Blazor_LinearGauge_Position_Cross)", or "[**Auto**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Position.html#Syncfusion_Blazor_LinearGauge_Position_Auto)".
* [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_Width) - To set the width of the pointer.
* [`Color`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_Color) - To set the color of the pointer.
* [`Placement`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_Placement) - To place the pointer in the specified position. By default, the pointer is placed "[**Far**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Placement.html#Syncfusion_Blazor_LinearGauge_Placement_Far)" from the axis. To change the placement, set the [`Placement`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_Placement) property as "[**Near**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Placement.html#Syncfusion_Blazor_LinearGauge_Placement_Near)", "[**Center**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Placement.html#Syncfusion_Blazor_LinearGauge_Placement_Center)", or "[**None**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Placement.html#Syncfusion_Blazor_LinearGauge_Placement_None)".
* [`Offset`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_Offset) - To place the pointer with specified distance from the axis.
* [`Opacity`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_Opacity) - To set the opacity of the pointer.
* [`AnimationDuration`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_AnimationDuration) - To specify the duration of the animation in pointer.
* [`LinearGaugePointerBorder`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointerBorder.html) - To set the color and width for the border of the pointer.

```csharp
@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeAxes>
        <LinearGaugeAxis>
            <LinearGaugePointers>
                <LinearGaugePointer PointerValue="60" MarkerType="MarkerType.Circle" Height="15" Width="15" Position="Position.Outside" Color="#cd41f4">
                </LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>
```

![Linear Gauge with Marker pointer customization Sample](images/marker-custom.png)

### Bar pointer

The bar pointer is used to track the axis value. The bar pointer starts from the beginning of the gauge and ends at the pointer value. To enable bar pointer set the [`Type`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_Type) property in [`LinearGaugePointer`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html) class as "[**Bar**](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Point.html#Syncfusion_Blazor_LinearGauge_Point_Bar)".

```csharp
@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeAxes>
        <LinearGaugeAxis>
            <LinearGaugePointers>
                <LinearGaugePointer PointerValue="60" Type="Point.Bar" Color="#a6a6a6">
                </LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>
```

![Linear Gauge with Bar pointer](images/bar-pointer.png)

<b>Bar pointer customization</b>

The bar pointer can be customized using the following properties and class.

* [`Width`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_Width) - To set the thickness of the bar pointer.
* [`Color`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_Color) - To set the color of the bar pointer.
* [`Offset`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_Offset) - To place the bar pointer with the specified distance from it's default position.
* [`Opacity`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_Opacity) - To set the opacity of the bar pointer.
* [`RoundedCornerRadius`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_RoundedCornerRadius) - To set the corner radius of the bar pointer.
* [`LinearGaugePointerBorder`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointerBorder.html) - To set the color and width for the border of the pointer.
* [`AnimationDuration`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_AnimationDuration) - To set the duration of the animation in bar pointer.

> Note: The Placement property is not applicable for the bar pointer.

```csharp
@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeAxes>
        <LinearGaugeAxis>
            <LinearGaugePointers>
                <LinearGaugePointer PointerValue="80" Type="Point.Bar" Width="20" Color="#f44141">
                </LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>
```

![Linear Gauge with Bar Pointer customization](images/bar-pointer-custom.png)

## Multiple pointers

Multiple pointers can be added to the Linear Gauge by adding multiple [`LinearGaugePointer`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html) classes in the [`LinearGaugePointers`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointers.html) class and customization for the pointers can be done with [`LinearGaugePointer`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html) class.

```csharp
@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeAxes>
        <LinearGaugeAxis>
            <LinearGaugePointers>
                <LinearGaugePointer PointerValue="30" MarkerType="MarkerType.Circle">
                </LinearGaugePointer>
                <LinearGaugePointer PointerValue="60" MarkerType="MarkerType.Diamond">
                </LinearGaugePointer>
                <LinearGaugePointer PointerValue="80" AnimationDuration="1000">
                </LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>
```

![Linear Gauge with Multiple pointers](images/multiple-pointer.png)

## Pointer animation

Pointer is animated on loading the gauge. This can be handled using the [`AnimationDuration`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_AnimationDuration) property. The duration of the animation can be specified in milliseconds.

```csharp
@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeAxes>
        <LinearGaugeAxis>
            <LinearGaugePointers>
                <LinearGaugePointer PointerValue="80" AnimationDuration="1000">
                </LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>
```

![Linear gauge with Pointer animation](./images/pointr-animation.gif)

## Gradient Color

Gradient support allows the addition of multiple colors in the pointers of the Linear Gauge. The following gradient types are supported in the Linear Gauge.

* Linear Gradient
* Radial Gradient

### Linear Gradient

Using linear gradient, colors will be applied in a linear progression. The start value of the linear gradient can be set using the [`StartValue`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeLinearGradient.html#Syncfusion_Blazor_LinearGauge_LinearGaugeLinearGradient_StartValue) property. The end value of the linear gradient will be set using the [`EndValue`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeLinearGradient.html#Syncfusion_Blazor_LinearGauge_LinearGaugeLinearGradient_EndValue) property. The color stop values such as [`Color`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.ColorStop.html#Syncfusion_Blazor_LinearGauge_ColorStop_Color), [`Opacity`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.ColorStop.html#Syncfusion_Blazor_LinearGauge_ColorStop_Opacity), and [`Offset`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.ColorStop.html#Syncfusion_Blazor_LinearGauge_ColorStop_Offset) are set using [`ColorStop`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.ColorStop.html) property. The linear gradient can be rendered for the pointer in the Linear Gauge by using the below example.

```csharp
@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge Orientation="Orientation.Horizontal">
    <LinearGaugeContainer Width="30" Offset="30">
        <LinearGaugeContainerBorder Width="0" />
        <LinearGaugeAxes>
            <LinearGaugeAxis>
                <LinearGaugeAxisLabelStyle Offset="55">
                    <LinearGaugeAxisLabelFont Color="#424242" />
                </LinearGaugeAxisLabelStyle>
                <LinearGaugeLine Width="0.01" />
                <LinearGaugeMajorTicks Height="0.01" Interval="25" />
                <LinearGaugeMinorTicks Height="0.01" />
                <LinearGaugePointers>
                    <LinearGaugePointer PointerValue="80" Height="25" Width="35" Offset="-40" MarkerType="MarkerType.Triangle"
                                        Placement="Syncfusion.Blazor.LinearGauge.Placement.Near">
                        <LinearGradient StartValue="1%" EndValue="99%">
                            <ColorStops>
                                <ColorStop Opacity="1" Color= "#fef3f9" Offset="1%" ></ColorStop>
                                <ColorStop Opacity="1" Color= "#f54ea2" Offset="100%"></ColorStop>
                            </ColorStops>
                        </LinearGradient>
                    </LinearGaugePointer>
                </LinearGaugePointers>
                <LinearGaugeRanges>
                    <LinearGaugeRange Color="#f54ea2" Start="0" End="80" StartWidth="30" EndWidth="30" Offset="30">
                    </LinearGaugeRange>
                </LinearGaugeRanges>
            </LinearGaugeAxis>
        </LinearGaugeAxes>
    </LinearGaugeContainer>
</SfLinearGauge>
```

![Linear Gauge with Linear Gradient pointer](images/linear-pointer.png)

### Radial Gradient

Using radial gradient, colors will be applied in circular progression. The inner-circle position of the radial gradient will be set using the [`InnerPosition`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.InnerPosition.html) class. The outer circle position of the radial gradient can be set using the [`OuterPosition`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.OuterPosition.html) class. The color stop values such as [`Color`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.ColorStop.html#Syncfusion_Blazor_LinearGauge_ColorStop_Color), [`Opacity`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.ColorStop.html#Syncfusion_Blazor_LinearGauge_ColorStop_Opacity), and [`Offset`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.ColorStop.html#Syncfusion_Blazor_LinearGauge_ColorStop_Offset) are set using [`ColorStop`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.ColorStop.html) class. The radial gradient can be rendered for the pointer in the Linear Gauge by using the below example.

```csharp
@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge Orientation="Orientation.Horizontal">
    <LinearGaugeContainer Width="30" Offset="30">
        <LinearGaugeContainerBorder Width="0" />
        <LinearGaugeAxes>
            <LinearGaugeAxis>
                <LinearGaugeAxisLabelStyle Offset="55">
                    <LinearGaugeAxisLabelFont Color="#424242" />
                </LinearGaugeAxisLabelStyle>
                <LinearGaugeLine Width="0.01" />
                <LinearGaugeMajorTicks Height="0.01" Interval="25" />
                <LinearGaugeMinorTicks Height="0.01" />
                <LinearGaugePointers>
                    <LinearGaugePointer PointerValue="80" Height="25" Width="35" Offset="-40" MarkerType="MarkerType.Triangle"
                                        Placement="Syncfusion.Blazor.LinearGauge.Placement.Near">
                        <RadialGradient Radius="60%">
                            <InnerPosition X="50%" Y="50%"></InnerPosition>
                            <OuterPosition X="50%" Y="50%"></OuterPosition>
                            <ColorStops>
                                <ColorStop Opacity="0.9" Color="#fff5f5" Offset="1%"></ColorStop>
                                <ColorStop Opacity="1" Color="#f54ea2" Offset="99%"></ColorStop>
                            </ColorStops>
                        </RadialGradient>
                    </LinearGaugePointer>
                </LinearGaugePointers>
                <LinearGaugeRanges>
                    <LinearGaugeRange Color="#f54ea2" Start="0" End="80" StartWidth="30" EndWidth="30" Offset="30">
                    </LinearGaugeRange>
                </LinearGaugeRanges>
            </LinearGaugeAxis>
        </LinearGaugeAxes>
    </LinearGaugeContainer>
</SfLinearGauge>
```

![Linear Gauge with radial Gradient pointer](images/radial-pointer.png)

> Note: If we set both gradients, only the linear gradient gets rendered. If we set the [`StartValue`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeLinearGradient.html#Syncfusion_Blazor_LinearGauge_LinearGaugeLinearGradient_StartValue) and [`EndValue`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeLinearGradient.html#Syncfusion_Blazor_LinearGauge_LinearGaugeLinearGradient_EndValue) of the [`LinearGradient`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeLinearGradient.html) as empty strings, then the radial gradient gets rendered in the pointer of the Linear Gauge.