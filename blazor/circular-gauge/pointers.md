---
layout: post
title: Pointers in Blazor Circular Gauge Component | Syncfusion
description: Checkout and learn here all about Pointers in Syncfusion Blazor Circular Gauge component and much more.
platform: Blazor
control: Circular Gauge
documentation: ug
---

# Pointers in Blazor Circular Gauge Component

Pointers are used to indicate values on an axis. The value of a pointer can be modified using the [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugePointer.html#Syncfusion_Blazor_CircularGauge_CircularGaugePointer_Value) property.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge>
    <CircularGaugeAxes>
        <CircularGaugeAxis>
            <CircularGaugePointers>
                <CircularGaugePointer Value="90">
                </CircularGaugePointer>
            </CircularGaugePointers>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BtrqshBwUVzsUfys?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Circular Gauge with Pointer](./images/blazor-circulargauge-with-pointer.png)

The Circular Gauge supports three types of pointers such as [Needle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.PointerType.html#Syncfusion_Blazor_CircularGauge_PointerType_Needle), [RangeBar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.PointerType.html#Syncfusion_Blazor_CircularGauge_PointerType_RangeBar), and [Marker](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.PointerType.html#Syncfusion_Blazor_CircularGauge_PointerType_Marker). You can choose any pointer using the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugePointer.html#Syncfusion_Blazor_CircularGauge_CircularGaugePointer_Type) property.

## Needle pointer

The circular gauge's default pointer type will be needle. A needle point contains three parts, a needle, a cap/knob, and a tail.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge>
    <CircularGaugeAxes>
        <CircularGaugeAxis>
            <CircularGaugePointers>
                <CircularGaugePointer Value="90">
                </CircularGaugePointer>
            </CircularGaugePointers>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hXLgCVhcghfqMkfw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Circular Gauge with Needle Pointer](./images/blazor-circulargauge-needle-pointer.png)

### Customization

The needle, tail and cap of the pointer can be customized with the following properties.

* [CircularGaugePointer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugePointer.html) - Customize the pointer's needle.
    * [Radius](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugePointer.html#Syncfusion_Blazor_CircularGauge_CircularGaugePointer_Radius) - sets the needle length.
    * [PointerWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugePointer.html#Syncfusion_Blazor_CircularGauge_CircularGaugePointer_PointerWidth) - sets the needle width.
    * [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugePointer.html#Syncfusion_Blazor_CircularGauge_CircularGaugePointer_Color) - sets the needle color.
* [CircularGaugeNeedleTail](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeNeedleTail.html) -  Customize the pointer's tail.
    * [Length](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeNeedleTail.html#Syncfusion_Blazor_CircularGauge_CircularGaugeNeedleTail_Length) - sets pointer's tail length.
    * [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeNeedleTail.html#Syncfusion_Blazor_CircularGauge_CircularGaugeNeedleTail_Color) - sets pointer's tail color.
    * [CircularGaugeNeedleTailBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeNeedleTail.html#Syncfusion_Blazor_CircularGauge_CircularGaugeNeedleTail_Border) -  Sets pointer's tail border.
* [CircularGaugeCap](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeCap.html) -  Customize the pointer's cap.
    * [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeCap.html#Syncfusion_Blazor_CircularGauge_CircularGaugeCap_Color) - sets pointer's cap color.
    * [Radius](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeCap.html#Syncfusion_Blazor_CircularGauge_CircularGaugeCap_Radius) - sets pointer's cap radius.
    * [CircularGaugeCapBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeCap.html#Syncfusion_Blazor_CircularGauge_CircularGaugeCap_Border) - sets pointer's cap border.
    * [Position`] - specifies the position of the Pointer. Its possible values are 'PointerRangePosition.Inside', 'PointerRangePosition.Outside' and 'PointerRangePosition.Cross'.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge Height="250px" Width="250px">
    <CircularGaugeAxes>
        <CircularGaugeAxis>
            <CircularGaugePointers>
                <CircularGaugePointer Value="90"
                                      Radius="40%"
                                      PointerWidth="30"
                                      Color="#007DD1"
                                      Position="PointerRangePosition.Inside">
                    <CircularGaugeCap Radius="15"
                                      Color="white">
                        <CircularGaugeCapBorder Width="4"
                                                Color="#007DD1">
                        </CircularGaugeCapBorder>
                    </CircularGaugeCap>
                    <CircularGaugeNeedleTail Length="35%"
                                             Color="#007DD1">
                    </CircularGaugeNeedleTail>
                </CircularGaugePointer>
            </CircularGaugePointers>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LjBAMVBcgVpSKNFt?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Circular Gauge with Custom Pointer](./images/blazor-circulargauge-pointer-customization.png)

<!-- markdownlint-disable MD010 -->

The appearance of the needle pointer can be customized by using [NeedleStartWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugePointer.html#Syncfusion_Blazor_CircularGauge_CircularGaugePointer_NeedleStartWidth) and [NeedleEndWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugePointer.html#Syncfusion_Blazor_CircularGauge_CircularGaugePointer_NeedleEndWidth).

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge>
    <CircularGaugeAxes>
        <CircularGaugeAxis StartAngle="270" EndAngle="90" Radius="90%" Minimum="0" Maximum="100">
		<CircularGaugeAxisLineStyle Width="3" Color="#1E7145">
            </CircularGaugeAxisLineStyle>
			 <CircularGaugeAxisLabelStyle>
                <CircularGaugeAxisLabelFont Color="#1E7145" Size="0px">
                </CircularGaugeAxisLabelFont>
            </CircularGaugeAxisLabelStyle>
			<CircularGaugeAxisMajorTicks Interval="100"
                                         Height="0"
                                         Width="1">
            </CircularGaugeAxisMajorTicks>
            <CircularGaugeAxisMinorTicks Width="0"
                                         Height="0"
                                         >
            </CircularGaugeAxisMinorTicks>
            <CircularGaugePointers>
                <CircularGaugePointer Value="70"
                                      Radius="80%" Color="green" PointerWidth="2" NeedleStartWidth="4" NeedleEndWidth="4">
				 <CircularGaugeCap Radius="8" Color="green">
                    </CircularGaugeCap>
                    <CircularGaugeNeedleTail Length="0%">
                    </CircularGaugeNeedleTail>
                </CircularGaugePointer>
            </CircularGaugePointers>
			<CircularGaugeAnnotations>
                <CircularGaugeAnnotation Angle="180" ZIndex="1">
                    <ContentTemplate>
                        <div class="custom-annotation">Customized Needle</div>
                    </ContentTemplate>
                </CircularGaugeAnnotation>
            </CircularGaugeAnnotations>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
<style type="text/css">
    .custom-annotation {
        color: #757575;
        font-family:Roboto; font-size:14px;padding-top: 26px;
    }
</style>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rDBKMrrwqBTQnLVR?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Range bar pointer

The range bar pointer is like a range in an axis that can be placed on gauge to mark the pointer value. The range bar starts from the beginning of the gauge and ends at the pointer value. You can set the pointer type using `Type` property in `CircularGaugePointer`.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge>
    <CircularGaugeAxes>
        <CircularGaugeAxis>
            <CircularGaugePointers>
                <CircularGaugePointer Value="50"
                                      Type="PointerType.RangeBar">
                </CircularGaugePointer>
            </CircularGaugePointers>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LXVgWLLQqLfubBRJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Circular Gauge with Range Bar Pointer](./images/blazor-circulargauge-range-bar-pointer.png)

### Customization

You can customize the range bar using the following properties.

* [PointerWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugePointer.html#Syncfusion_Blazor_CircularGauge_CircularGaugePointer_PointerWidth) - Specifies the width of the range bar. 
* [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugePointer.html#Syncfusion_Blazor_CircularGauge_CircularGaugePointer_Color) - Specifies the color of the range bar.
* [Radius](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugePointer.html#Syncfusion_Blazor_CircularGauge_CircularGaugePointer_Radius) - Specifies the range bar radius
* [RoundedCornerRadius](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugePointer.html#Syncfusion_Blazor_CircularGauge_CircularGaugePointer_RoundedCornerRadius) - Specifies the rounded corner of the range bar.
* [CircularGaugePointerBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugePointerBorder.html) - Specifies the border of the range bar.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge>
    <CircularGaugeAxes>
        <CircularGaugeAxis>
            <CircularGaugePointers>
                <CircularGaugePointer Value="46"
                                      Type="PointerType.RangeBar"
                                      PointerWidth="8"
                                      Radius="95%"
                                      Color="lightgray">
                    <CircularGaugePointerBorder Color="darkgray"
                                                Width="2">
                    </CircularGaugePointerBorder>
                </CircularGaugePointer>
            </CircularGaugePointers>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXhUMhrwKBosYIXk?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Customizing Blazor Circular Gauge Range Bar](./images/blazor-circulargauge-range-customization.png)

### Rounded corners

The start and end pointers of a range bar in the Circular Gauge are rounded to form arc using the `RoundedCornerRadius` property.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge>
    <CircularGaugeAxes>
        <CircularGaugeAxis>
            <CircularGaugePointers>
                <CircularGaugePointer Value="46"
                                      RoundedCornerRadius="20"
                                      Type="PointerType.RangeBar">
                </CircularGaugePointer>
            </CircularGaugePointers>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDhgsrVGUhIpRJzK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Circular Gauge Range Bar with Rounded Corner](./images/blazor-circulargauge-range-with-round-corner.png)

## Marker pointer

The different types of marker shapes can be used to mark the pointer value in an axis. You can change the marker shape using the [MarkerShape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugePointer.html#Syncfusion_Blazor_CircularGauge_CircularGaugePointer_MarkerShape) property in pointer. The Circular Gauge supports the following marker shapes:

* Circle
* Rectangle
* Triangle
* InvertedTriangle
* Diamond

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge>
    <CircularGaugeAxes>
        <CircularGaugeAxis>
            <CircularGaugePointers>
                <CircularGaugePointer Value="90"
                                      Type="PointerType.Marker"
                                      MarkerShape="GaugeShape.Diamond"
                                      MarkerHeight="15"
                                      MarkerWidth="15">
                </CircularGaugePointer>
            </CircularGaugePointers>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BtBAshVGghyGCzzX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Circular Gauge with Marker Pointer](./images/blazor-circulargauge-marker-pointer.png)

### Customization

You can customize the marker pointer using the following properties.

* [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugePointer.html#Syncfusion_Blazor_CircularGauge_CircularGaugePointer_Color) - specifies marker pointer color.
* [MarkerWidth](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugePointer.html#Syncfusion_Blazor_CircularGauge_CircularGaugePointer_MarkerWidth)  - specifies marker pointer width.
* [MarkerHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugePointer.html#Syncfusion_Blazor_CircularGauge_CircularGaugePointer_MarkerHeight) - specifies marker pointer height.
* [Radius](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugePointer.html#Syncfusion_Blazor_CircularGauge_CircularGaugePointer_Radius) - specifies marker pointer radius.
* [CircularGaugePointerBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugePointerBorder.html) - specifies marker pointer's border color and width.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge>
    <CircularGaugeAxes>
        <CircularGaugeAxis>
            <CircularGaugePointers>
                <CircularGaugePointer Value="90"
                                      Type="PointerType.Marker"
                                      MarkerShape="GaugeShape.InvertedTriangle"
                                      MarkerHeight="15"
                                      MarkerWidth="15"
                                      Color="white"
                                      Radius="110%">
                    <CircularGaugePointerBorder Width="2" Color="#007DD1"></CircularGaugePointerBorder>
                </CircularGaugePointer>
            </CircularGaugePointers>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDhgCVhQUhRjXeXh?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Circular Gauge with Custom Marker Pointer](./images/blazor-circulargauge-custom-marker-pointer.png)

### Image marker pointer

You can use image instead of rendering marker shape to denote the pointer value. It can be achieved by setting [MarkerShape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugePointer.html#Syncfusion_Blazor_CircularGauge_CircularGaugePointer_MarkerShape) to 'GaugeShape.Image' and assigning image path to [ImageUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugePointer.html#Syncfusion_Blazor_CircularGauge_CircularGaugePointer_ImageUrl) as shown in following example.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge>
    <CircularGaugeAxes>
        <CircularGaugeAxis>
            <CircularGaugePointers>
                <CircularGaugePointer Value="90"
                                      Type="PointerType.Marker"
                                      MarkerShape="GaugeShape.Image"
                                      ImageUrl="football.png"
                                      MarkerHeight="20"
                                      MarkerWidth="20"
                                      Radius="100%">
                </CircularGaugePointer>
            </CircularGaugePointers>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
```

![Blazor Circular Gauge with Image Pointer](./images/blazor-circulargauge-pointer-with-image.png)

<!-- markdownlint-disable MD010 -->

## Dragging pointer

The pointers can be dragged over the axis values by clicking and dragging the same. To enable or disable the pointer drag, use the [EnablePointerDrag](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_EnablePointerDrag) property.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge EnablePointerDrag="true" Height="250px" Width="250px">
    <CircularGaugeAxes>
        <CircularGaugeAxis>
            <CircularGaugePointers>
                <CircularGaugePointer Value="50">
                </CircularGaugePointer>
            </CircularGaugePointers>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hthgCLBcqhdAvjZX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Circular Gauge with Dragging Pointer](./images/blazor-circulargauge-dragging-pointer.gif)

## Multiple pointers

In addition to the default pointer, you can add n number of pointers to an axis using the [CircularGaugePointers](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugePointers.html) tag.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge>
    <CircularGaugeAxes>
        <CircularGaugeAxis>
            <CircularGaugePointers>
                <CircularGaugePointer Value="90"
                                      MarkerShape="GaugeShape.InvertedTriangle"
                                      Radius="100%"
                                      MarkerHeight="15"
                                      MarkerWidth="15">
                </CircularGaugePointer>
                <CircularGaugePointer Value="90"
                                      Type="PointerType.RangeBar"
                                      Radius="60%"
                                      MarkerWidth="10">
                </CircularGaugePointer>
                <CircularGaugePointer Value="90"
                                      Radius="50%"
                                      PointerWidth="25"
                                      Color="#007DD1">
                    <CircularGaugeCap Radius="15">
                        <CircularGaugeCapBorder Width="5">
                        </CircularGaugeCapBorder>
                    </CircularGaugeCap>
                    <CircularGaugeNeedleTail Length="25%">
                    </CircularGaugeNeedleTail>
                </CircularGaugePointer>
            </CircularGaugePointers>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rXrgMBrGKBnvQyWB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Circular Gauge with Multiple Pointers](./images/blazor-circulargauge-multiple-pointers.png)

## Pointer animation

The pointers are animated on loading the gauge using the [CircularGaugePointerAnimation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugePointerAnimation.html) tag in pointer. The [Enable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugePointerAnimation.html#Syncfusion_Blazor_CircularGauge_CircularGaugePointerAnimation_Enable) property in animation allows you to enable or disable the animation. The [Duration](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugePointerAnimation.html#Syncfusion_Blazor_CircularGauge_CircularGaugePointerAnimation_Duration) property specifies the duration of the animation in milliseconds.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge Height="250px" Width="250px">
    <CircularGaugeAxes>
        <CircularGaugeAxis>
            <CircularGaugePointers>
                <CircularGaugePointer Value="70">
                    <CircularGaugePointerAnimation Enable="true" Duration="1500">
                    </CircularGaugePointerAnimation>
                </CircularGaugePointer>
            </CircularGaugePointers>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDhUWhVmqBcsUFix?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Circular Gauge with Pointer Animation](./images/blazor-circulargauge-pointer-animation.gif)

## Gradient color

Gradient support allows to add multiple colors in the ranges and pointers of the circular gauge. The following gradient types are supported in the circular gauge.

* Linear Gradient
* Radial Gradient

### Linear gradient

Using linear gradient, colors will be applied in a linear progression. The start value of the linear gradient can be set using the [StartValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeLinearGradient.html#Syncfusion_Blazor_CircularGauge_CircularGaugeLinearGradient_StartValue) property. The end value of the linear gradient will be set using the [EndValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeLinearGradient.html#Syncfusion_Blazor_CircularGauge_CircularGaugeLinearGradient_EndValue) property. The color stop values such as color, opacity and offset are set using [ColorStop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeLinearGradient.html#Syncfusion_Blazor_CircularGauge_CircularGaugeLinearGradient_ColorStop) property.

The linear gradient can be applied to all pointer types like marker, range bar, and needle. To do so, follow the below code sample.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge>
    <CircularGaugeAxes>
        <CircularGaugeAxis StartAngle="270" EndAngle="90" Radius="90%" Minimum="0" Maximum="100">
            <CircularGaugeAxisLineStyle Width="3" Color="#E63B86" />
            <CircularGaugeAxisLabelStyle>
                <CircularGaugeAxisLabelFont Size="0px" />
            </CircularGaugeAxisLabelStyle>
            <CircularGaugeAxisMajorTicks Height="0.01" />
            <CircularGaugeAxisMinorTicks Height="0.01" />
            <CircularGaugePointers>
                <CircularGaugePointer Value="80" Radius="80%" PointerWidth="10">
                    <LinearGradient StartValue="1%" EndValue="99%">
                        <ColorStops>
                            <ColorStop Opacity="0.9" Offset="0%" Color="#fef3f9"></ColorStop>
                            <ColorStop Opacity="0.9" Offset="100%" Color="#f54ea2"></ColorStop>
                        </ColorStops>
                    </LinearGradient>
                    <CircularGaugeCap Radius="8" Color="White">
                        <CircularGaugeCapBorder Color="#E63B86" Width="1" />
                    </CircularGaugeCap>
                    <CircularGaugeNeedleTail Length="20%">
                        <LinearGradient StartValue="1%" EndValue="99%">
                            <ColorStops>
                                <ColorStop Opacity="0.9" Offset="0%" Color="#fef3f9"></ColorStop>
                                <ColorStop Opacity="0.9" Offset="100%" Color="#f54ea2"></ColorStop>
                            </ColorStops>
                        </LinearGradient>
                        </CircularGaugeNeedleTail>
                        <CircularGaugePointerAnimation Enable="true" Duration="1000" />
                </CircularGaugePointer>
                <CircularGaugePointer Value="40" Radius="60%" MarkerWidth="5" MarkerHeight="5" PointerWidth="10">
                    <LinearGradient StartValue="1%" EndValue="99%">
                        <ColorStops>
                            <ColorStop Opacity="0.9" Offset="0%" Color="#fef3f9"></ColorStop>
                            <ColorStop Opacity="0.9" Offset="100%" Color="#f54ea2"></ColorStop>
                        </ColorStops>
                    </LinearGradient>
                    <CircularGaugeCap Radius="8" Color="White">
                        <CircularGaugeCapBorder Color="#E63B86" Width="1" />
                    </CircularGaugeCap>
                    <CircularGaugeNeedleTail Length="20%">
                        <LinearGradient StartValue="1%" EndValue="99%">
                            <ColorStops>
                                <ColorStop Opacity="0.9" Offset="0%" Color="#fef3f9"></ColorStop>
                                <ColorStop Opacity="0.9" Offset="100%" Color="#f54ea2"></ColorStop>
                            </ColorStops>
                        </LinearGradient>
                    </CircularGaugeNeedleTail>
                    <CircularGaugePointerAnimation Enable="true" Duration="1000" />
                </CircularGaugePointer>
            </CircularGaugePointers>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BNLKMVVGKhQgPmGy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Radial gradient

Using radial gradient, colors will be applied in circular progression. The inner circle position of the radial gradient will be set using the [InnerPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeRadialGradient.html#Syncfusion_Blazor_CircularGauge_CircularGaugeRadialGradient_InnerPosition) property. The outer circle position of the radial gradient can be set using the [OuterPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeRadialGradient.html#Syncfusion_Blazor_CircularGauge_CircularGaugeRadialGradient_OuterPosition) property. The color stop values such as color, opacity and offset are set using [ColorStop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeRadialGradient.html#Syncfusion_Blazor_CircularGauge_CircularGaugeRadialGradient_ColorStop) property.

The radial gradient can be applied to all pointer types like marker, range bar, and needle. To do so, follow the below code sample.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge>
    <CircularGaugeAxes>
        <CircularGaugeAxis StartAngle="270" EndAngle="90" Radius="90%" Minimum="0" Maximum="100">
            <CircularGaugeAxisLineStyle Width="3" Color="#E63B86" />
            <CircularGaugeAxisLabelStyle>
                <CircularGaugeAxisLabelFont Size="0px" />
            </CircularGaugeAxisLabelStyle>
            <CircularGaugeAxisMajorTicks Height="0.01" />
            <CircularGaugeAxisMinorTicks Height="0.01" />
            <CircularGaugePointers>
                <CircularGaugePointer Value="80" Radius="80%" PointerWidth="10">
                    <RadialGradient Radius="65%">
                        <InnerPosition X="60%" Y="60%"></InnerPosition>
                        <OuterPosition X="50%" Y="70%"></OuterPosition>
                        <ColorStops>
                            <ColorStop Opacity="0.9" Offset="5%" Color="#fff5f5"></ColorStop>
                            <ColorStop Opacity="0.9" Offset="99%" Color="#f54ea2"></ColorStop>
                        </ColorStops>
                    </RadialGradient>
                    <CircularGaugeCap Radius="8" Color="White">
                        <CircularGaugeCapBorder Color="#E63B86" Width="1" />
                    </CircularGaugeCap>
                    <CircularGaugeNeedleTail Length="20%">
                        <RadialGradient Radius="65%">
                            <InnerPosition X="60%" Y="60%"></InnerPosition>
                            <OuterPosition X="50%" Y="70%"></OuterPosition>
                            <ColorStops>
                                <ColorStop Opacity="0.9" Offset="5%" Color="#fff5f5"></ColorStop>
                                <ColorStop Opacity="0.9" Offset="99%" Color="#f54ea2"></ColorStop>
                            </ColorStops>
                        </RadialGradient>
                        </CircularGaugeNeedleTail>
                        <CircularGaugePointerAnimation Enable="true" Duration="1000" />
                </CircularGaugePointer>
                <CircularGaugePointer Value="40" Radius="60%" MarkerWidth="5" MarkerHeight="5" PointerWidth="10">
                    <RadialGradient Radius="65%">
                        <InnerPosition X="60%" Y="60%"></InnerPosition>
                        <OuterPosition X="50%" Y="70%"></OuterPosition>
                        <ColorStops>
                            <ColorStop Opacity="0.9" Offset="5%" Color="#fff5f5"></ColorStop>
                            <ColorStop Opacity="0.9" Offset="99%" Color="#f54ea2"></ColorStop>
                        </ColorStops>
                    </RadialGradient>
                    <CircularGaugeCap Radius="8" Color="White">
                        <CircularGaugeCapBorder Color="#E63B86" Width="1" />
                    </CircularGaugeCap>
                    <CircularGaugeNeedleTail Length="20%">
                        <RadialGradient Radius="65%">
                            <InnerPosition X="60%" Y="60%"></InnerPosition>
                            <OuterPosition X="50%" Y="70%"></OuterPosition>
                            <ColorStops>
                                <ColorStop Opacity="0.9" Offset="5%" Color="#fff5f5"></ColorStop>
                                <ColorStop Opacity="0.9" Offset="99%" Color="#f54ea2"></ColorStop>
                            </ColorStops>
                        </RadialGradient>
                        </CircularGaugeNeedleTail>
                        <CircularGaugePointerAnimation Enable="true" Duration="1000" />
                </CircularGaugePointer>
            </CircularGaugePointers>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LjhAWhLmghQyveia?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

<!-- markdownlint-disable MD010 -->