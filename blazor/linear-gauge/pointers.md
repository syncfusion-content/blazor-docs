---
layout: post
title: Pointers in Blazor Linear Gauge Component | Syncfusion
description: Check out and learn here all about pointers in Syncfusion Blazor Linear Gauge component and much more.
platform: Blazor
control: Linear Gauge
documentation: ug
---

# Pointers in Blazor Linear Gauge Component

Pointers indicate values on an axis. The pointer value can be modified using the [PointerValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_PointerValue) property in [LinearGaugePointer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html).

```cshtml

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

![Blazor Linear Gauge with Pointer Value](images/blazor-linear-gauge-with-pointer-value.png)

## Types of pointers

The Linear Gauge supports the following pointer types:

* Bar
* Marker

The pointer type can be modified using the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_Type) property in [LinearGaugePointer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html).

### Marker pointer

A marker pointer is a shape that marks the pointer value in the Linear Gauge.

<b>Marker shape types</b>

By default, the marker shape is **InvertedTriangle**. To change the shape, use the [MarkerType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_MarkerType) property in [LinearGaugePointer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html). The following marker types are available:

* Circle
* Rectangle
* Triangle
* InvertedTriangle
* Diamond
* Image
* Text

```cshtml

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

![Blazor Linear Gauge with Marker Pointer](images/blazor-linear-gauge-marker-pointer.png)

An image can be rendered instead of a shape for the pointer. Set the [MarkerType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_MarkerType) property to **Image** and set the image source URL using the [ImageUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_ImageUrl) property in [LinearGaugePointer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html).

```cshtml

@using Syncfusion.Blazor.LinearGauge;

<SfLinearGauge Orientation="Orientation.Horizontal">
    <LinearGaugeAxes>
        <LinearGaugeAxis>
            <LinearGaugeMajorTicks Position="Position.Outside">
            </LinearGaugeMajorTicks>
            <LinearGaugeMinorTicks Position="Position.Outside">
            </LinearGaugeMinorTicks>
            <LinearGaugeAxisLabelStyle Position="Position.Outside"></LinearGaugeAxisLabelStyle>
            <LinearGaugePointers>
                <LinearGaugePointer PointerValue="60" Offset="-27" Height="40" Width="40" MarkerType="MarkerType.Image" ImageUrl="https://blazor.syncfusion.com/demos/_content/blazor_server_common_net8/images/linear-gauge/step-count.png">
                </LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>

```
![Blazor Linear Gauge with Image Pointer](images/blazor-linear-gauge-image-pointer.png)

Text can be rendered instead of a shape as a pointer. Set the [MarkerType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_MarkerType) property to **Text**, and set the text content using the [Text](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_Text) property in [LinearGaugePointer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html).

The following properties in the [LinearGaugeMarkerTextStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeMarkerTextStyle.html#properties) tag can be used to style the text pointer:

* [FontFamily](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeMarkerTextStyle.html#Syncfusion_Blazor_LinearGauge_LinearGaugeMarkerTextStyle_FontFamily) - It is used to set the font family for the text pointer.
* [FontStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeMarkerTextStyle.html#Syncfusion_Blazor_LinearGauge_LinearGaugeMarkerTextStyle_FontStyle) - It is used to set the font style for the text pointer.
* [FontWeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeMarkerTextStyle.html#Syncfusion_Blazor_LinearGauge_LinearGaugeMarkerTextStyle_FontWeight) - It is used to set the font weight for the text pointer.
* [Size](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeMarkerTextStyle.html#Syncfusion_Blazor_LinearGauge_LinearGaugeMarkerTextStyle_Size) - It is used to set the font size for the text pointer.

```cshtml

@using Syncfusion.Blazor.LinearGauge;

<SfLinearGauge Orientation="Orientation.Horizontal">
    <LinearGaugeAxes>
        <LinearGaugeAxis Minimum="0" Maximum="100" OpposedPosition="true">
            <LinearGaugeLine Width="5" />
            <LinearGaugeMajorTicks Interval="20" Height="7" Width="1" Position="Position.Inside" />
            <LinearGaugeMinorTicks Interval="10" Height="3" Position="Position.Inside" />
            <LinearGaugeAxisLabelStyle Position="Position.Inside">
                <LinearGaugeAxisLabelFont FontFamily="inherit" />
            </LinearGaugeAxisLabelStyle>
            <LinearGaugePointers>
                <LinearGaugePointer PointerValue="13" MarkerType="MarkerType.Text" Text="Low" Color="Black" Offset="-55">
                    <LinearGaugeMarkerTextStyle Size="18px" FontWeight="Bold"></LinearGaugeMarkerTextStyle>
                </LinearGaugePointer>
                <LinearGaugePointer PointerValue="48" MarkerType="MarkerType.Text" Text="Moderate" Color="Black" Offset="-55">
                    <LinearGaugeMarkerTextStyle Size="18px" FontWeight="Bold"></LinearGaugeMarkerTextStyle>
                </LinearGaugePointer>
                <LinearGaugePointer PointerValue="83" MarkerType="MarkerType.Text" Text="High" Color="Black" Offset="-55">
                    <LinearGaugeMarkerTextStyle Size="18px" FontWeight="Bold"></LinearGaugeMarkerTextStyle>
                </LinearGaugePointer>
            </LinearGaugePointers>
            <LinearGaugeRanges>
                <LinearGaugeRange Start="0" End="30" StartWidth="50" EndWidth="50" Color="#6FC78A" Position="Position.Inside" />
                <LinearGaugeRange Start="30" End="65" StartWidth="50" EndWidth="50" Color="#ECC85B" Position="Position.Inside" />
                <LinearGaugeRange Start="65" End="100" StartWidth="50" EndWidth="50" Color="#FB7D55" Position="Position.Inside" />
            </LinearGaugeRanges>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>

```

![Blazor Linear Gauge with text pointer](images/blazor-linear-gauge-text-pointer.png)

<b>Marker pointer customization</b>

The marker pointer can be customized using the following properties and component:

* [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_Height) – Sets the pointer height.
* [Position](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_Position) – Sets the pointer position: [Inside](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Position.html#Syncfusion_Blazor_LinearGauge_Position_Inside), [Outside](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Position.html#Syncfusion_Blazor_LinearGauge_Position_Outside), [Cross](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Position.html#Syncfusion_Blazor_LinearGauge_Position_Cross), or [Auto](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Position.html#Syncfusion_Blazor_LinearGauge_Position_Auto).
* [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_Width) – Sets the pointer width.
* [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_Color) – Sets the pointer color.
* [Placement](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_Placement) – Sets the pointer placement. By default, the pointer is placed [Far](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Placement.html#Syncfusion_Blazor_LinearGauge_Placement_Far) from the axis. To change the placement, set [Placement](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_Placement) to [Near](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Placement.html#Syncfusion_Blazor_LinearGauge_Placement_Near), [Center](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Placement.html#Syncfusion_Blazor_LinearGauge_Placement_Center), or [None](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Placement.html#Syncfusion_Blazor_LinearGauge_Placement_None).
* [Offset](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_Offset) – Sets the distance of the pointer from the axis.
* [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_Opacity) – Sets the pointer opacity.
* [AnimationDuration](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_AnimationDuration) – Sets the pointer animation duration.
* [LinearGaugePointerBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointerBorder.html) – Sets the border color and width of the pointer.

```cshtml

@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeAxes>
        <LinearGaugeAxis>
            <LinearGaugePointers>
                <LinearGaugePointer PointerValue="60" MarkerType="MarkerType.Circle"
                                    Height="15" Width="15" Color="#cd41f4"
                                    Position="Position.Outside">
                </LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>

```

![Customizing Marker Pointer in Blazor Linear Gauge](images/blazor-linear-gauge-custom-marker-pointer.png)

### Bar pointer

The bar pointer is used to track the axis value. It starts from the beginning of the gauge and ends at the pointer value. To enable a bar pointer, set the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_Type) property in [LinearGaugePointer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html) to [Bar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Point.html#Syncfusion_Blazor_LinearGauge_Point_Bar).

```cshtml

@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeAxes>
        <LinearGaugeAxis>
            <LinearGaugePointers>
                <LinearGaugePointer PointerValue="60" Type="Point.Bar"
                                    Color="#a6a6a6">
                </LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>

```

![Blazor Linear Gauge with Bar Pointer](images/blazor-linear-gauge-with-bar-pointer.png)

<b>Bar pointer customization</b>

The bar pointer can be customized using the following properties and component:

* [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_Width) – Sets the thickness of the bar pointer.
* [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_Color) – Sets the color of the bar pointer.
* [Offset](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_Offset) – Sets the distance of the bar pointer from its default position.
* [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_Opacity) – Sets the opacity of the bar pointer.
* [RoundedCornerRadius](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_RoundedCornerRadius) – Sets the corner radius of the bar pointer.
* [LinearGaugePointerBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointerBorder.html) – Sets the border color and width of the pointer.
* [AnimationDuration](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_AnimationDuration) – Sets the duration of the bar pointer animation.

N> The Placement property is not applicable to the bar pointer.

```cshtml

@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeAxes>
        <LinearGaugeAxis>
            <LinearGaugePointers>
                <LinearGaugePointer PointerValue="80" Type="Point.Bar" Width="20"
                                    Color="#f44141">
                </LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>

```

![Customizing Bar Pointer in Blazor Linear Gauge](images/blazor-linear-gauge-custom-bar-pointer.png)

## Multiple pointers

Multiple pointers can be added to the Linear Gauge by including multiple [LinearGaugePointer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html) elements inside [LinearGaugePointers](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointers.html). Each pointer can be customized using [LinearGaugePointer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html) properties.

```cshtml

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

![Blazor Linear Gauge with Multiple Pointers](images/blazor-linear-gauge-multiple-pointer.png)

## Pointer animation

When the gauge is initially loaded or when the pointer value changes dynamically, the pointer is animated. The [AnimationDuration](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_AnimationDuration) property in [LinearGaugePointer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html) customizes the animation duration in milliseconds. NOTE: When the pointer is dragged, the animation does not run.

```cshtml

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

![Blazor Linear Gauge with Pointer Animation](./images/blazor-linear-gauge-pointer-animation.gif)

## Gradient Color

Gradient support allows multiple colors to be applied to pointers in the Linear Gauge. The following gradient types are supported:

* Linear gradient
* Radial gradient

### Linear Gradient

With a linear gradient, colors are applied in a linear progression. The start value is set using [StartValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeLinearGradient.html#Syncfusion_Blazor_LinearGauge_LinearGaugeLinearGradient_StartValue). The end value is set using [EndValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeLinearGradient.html#Syncfusion_Blazor_LinearGauge_LinearGaugeLinearGradient_EndValue). Color stop values such as [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.ColorStop.html#Syncfusion_Blazor_LinearGauge_ColorStop_Color), [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.ColorStop.html#Syncfusion_Blazor_LinearGauge_ColorStop_Opacity) and [Offset](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.ColorStop.html#Syncfusion_Blazor_LinearGauge_ColorStop_Offset) are set using the [ColorStop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.ColorStop.html) property.

```cshtml

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
                    <LinearGaugePointer PointerValue="80" Height="25" Width="35"
                                Offset="-40" MarkerType="MarkerType.Triangle"
                                Placement="Syncfusion.Blazor.LinearGauge.Placement.Near">
                        <LinearGradient StartValue="1%" EndValue="99%">
                            <ColorStops>
                                <ColorStop Opacity="1" Color= "#fef3f9" Offset="1%">
                                </ColorStop>
                                <ColorStop Opacity="1" Color= "#f54ea2" Offset="100%">
                                </ColorStop>
                            </ColorStops>
                        </LinearGradient>
                    </LinearGaugePointer>
                </LinearGaugePointers>
                <LinearGaugeRanges>
                    <LinearGaugeRange Color="#f54ea2" Start="0" End="80"
                                      StartWidth="30" EndWidth="30" Offset="30">
                    </LinearGaugeRange>
                </LinearGaugeRanges>
            </LinearGaugeAxis>
        </LinearGaugeAxes>
    </LinearGaugeContainer>
</SfLinearGauge>

```

![Blazor Linear Gauge with Linear Gradient Pointer](images/blazor-linear-gauge-with-linear-pointer.png)

### Radial Gradient

With a radial gradient, colors are applied in a circular progression. The inner-circle position is set using [InnerPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.InnerPosition.html). The outer circle position is set using [OuterPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.OuterPosition.html). Color stop values such as [Color](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.ColorStop.html#Syncfusion_Blazor_LinearGauge_ColorStop_Color), [Opacity](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.ColorStop.html#Syncfusion_Blazor_LinearGauge_ColorStop_Opacity) and [Offset](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.ColorStop.html#Syncfusion_Blazor_LinearGauge_ColorStop_Offset) are set using the [ColorStop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.ColorStop.html) property.

```cshtml

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
                    <LinearGaugePointer PointerValue="80" Height="25" Width="35"
                                Offset="-40" MarkerType="MarkerType.Triangle"
                                Placement="Syncfusion.Blazor.LinearGauge.Placement.Near">
                        <RadialGradient Radius="60%">
                            <InnerPosition X="50%" Y="50%"></InnerPosition>
                            <OuterPosition X="50%" Y="50%"></OuterPosition>
                            <ColorStops>
                                <ColorStop Opacity="0.9" Color="#fff5f5" Offset="1%">
                                </ColorStop>
                                <ColorStop Opacity="1" Color="#f54ea2" Offset="99%">
                                </ColorStop>
                            </ColorStops>
                        </RadialGradient>
                    </LinearGaugePointer>
                </LinearGaugePointers>
                <LinearGaugeRanges>
                    <LinearGaugeRange Color="#f54ea2" Start="0" End="80"
                                      StartWidth="30" EndWidth="30" Offset="30">
                    </LinearGaugeRange>
                </LinearGaugeRanges>
            </LinearGaugeAxis>
        </LinearGaugeAxes>
    </LinearGaugeContainer>
</SfLinearGauge>

```

![Blazor Linear Gauge with Radial Gradient Pointer](images/blazor-linear-gauge-with-radial-pointer.png)

N> If both gradients are set, only the linear gradient is rendered. If the [StartValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeLinearGradient.html#Syncfusion_Blazor_LinearGauge_LinearGaugeLinearGradient_StartValue) and [EndValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeLinearGradient.html#Syncfusion_Blazor_LinearGauge_LinearGaugeLinearGradient_EndValue) of [LinearGradient](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeLinearGradient.html) are empty strings, the radial gradient is rendered on the pointer in the Linear Gauge.
