---
layout: post
title: Blazor Circular Gauge User Interaction | Syncfusion®
description: Learn how to show pointer details on hover in the Blazor Circular Gauge by enabling the tooltip and customizing its fill, border, and text style.
platform: Blazor
control: Circular Gauge
documentation: ug
---

# Blazor Circular Gauge User Interaction

## Tooltip for pointers

The Circular Gauge displays the pointer details in a tooltip when the mouse hovers over a pointer. This is configured through the [CircularGaugeTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeTooltipSettings.html) component.

### Formatting the tooltip

By default, the tooltip is not visible. You can enable the tooltip by setting the [Enable](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeTooltipSettings.html#Syncfusion_Blazor_CircularGauge_CircularGaugeTooltipSettings_Enable) property to true. Use the following properties to customize the tooltip.

* [CircularGaugeTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeTooltipSettings.html)
    * [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeTooltipSettings.html#Syncfusion_Blazor_CircularGauge_CircularGaugeTooltipSettings_Fill) - Specifies the fill color of the tooltip.
    * [EnableAnimation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeTooltipSettings.html#Syncfusion_Blazor_CircularGauge_CircularGaugeTooltipSettings_EnableAnimation) - Enables or disables the open/close animation.
    * [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeTooltipSettings.html#Syncfusion_Blazor_CircularGauge_CircularGaugeTooltipSettings_Format) - Customizes the tooltip content using tokens such as `{value}`.
* [CircularGaugeTooltipBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeTooltipBorder.html)
    * `Color` - Specifies the tooltip border color.
    * `Width` - Specifies the tooltip border width.
* [CircularGaugeTooltipTextStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeTooltipTextStyle.html)
    * `Color` - Specifies the tooltip text color.
    * `FontStyle` - Specifies the font style.
    * `FontWeight` - Specifies the font weight.
    * `FontFamily` - Specifies the font family.
    * `Opacity` - Specifies the text opacity.
    * `Size` - Specifies the font size.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge>
    <CircularGaugeAxes>
        <CircularGaugeAxis>
            <CircularGaugePointers>
                <CircularGaugePointer Value="50">
                </CircularGaugePointer>
            </CircularGaugePointers>
            <CircularGaugeTooltipSettings Enable="true"
                                          Fill="lightgray"
                                          EnableAnimation="true"
                                          Format="Speed: {value}">
                <CircularGaugeTooltipBorder Color="blue"
                                            Width="1">
                </CircularGaugeTooltipBorder>
                <CircularGaugeTooltipTextStyle Color="blue"
                                               FontStyle="italic"
                                               FontWeight="bold"
                                               Size="15px">
                </CircularGaugeTooltipTextStyle>
            </CircularGaugeTooltipSettings>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LNhdNRhHUjENPFFU?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Circular Gauge displays ToolTip](./images/blazor-circulargauge-tooltip.webp)" %}

### Showing tooltip at mouse position

By default, the tooltip is shown on the axis. To show the tooltip at the cursor position instead, set the [ShowAtMousePosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeTooltipSettings.html#Syncfusion_Blazor_CircularGauge_CircularGaugeTooltipSettings_ShowAtMousePosition) property to `true`.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge>
    <CircularGaugeAxes>
        <CircularGaugeAxis>
            <CircularGaugePointers>
                <CircularGaugePointer Value="50">
                </CircularGaugePointer>
            </CircularGaugePointers>
            <CircularGaugeTooltipSettings Enable="true" ShowAtMousePosition="true">
            </CircularGaugeTooltipSettings>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hNBdjdVRqDOKaEOm?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Displaying Blazor Circular Gauge ToolTip at Cursor Position](./images/blazor-circulargauge-tooltip-at-cursor-position.webp)" %}

## Tooltip for ranges

The Circular Gauge can display a tooltip when the mouse hovers over a range. To enable it, add `"Range"` to the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeTooltipSettings.html#Syncfusion_Blazor_CircularGauge_CircularGaugeTooltipSettings_Type) array of `CircularGaugeTooltipSettings` on `SfCircularGauge`.

### Tooltip customization for ranges

Configure the range tooltip through [CircularGaugeRangeTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeRangeTooltipSettings.html) inside `CircularGaugeTooltipSettings`. The following options are available to customize the range tooltip:

* [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeRangeTooltipSettings.html#Syncfusion_Blazor_CircularGauge_CircularGaugeRangeTooltipSettings_Fill) - Specifies the fill color of the range tooltip.
* [CircularGaugeRangeTooltipTextStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeRangeTooltipTextStyle.html) - Specifies the range tooltip text style.
* [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeRangeTooltipSettings.html#Syncfusion_Blazor_CircularGauge_CircularGaugeRangeTooltipSettings_Format) - Specifies the range tooltip content format.
* [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeRangeTooltipSettings.html#Syncfusion_Blazor_CircularGauge_CircularGaugeRangeTooltipSettings_Template) - Specifies a custom template for the tooltip content.
* [EnableAnimation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeRangeTooltipSettings.html#Syncfusion_Blazor_CircularGauge_CircularGaugeRangeTooltipSettings_EnableAnimation) - Enables or disables the open/close animation.
* [CircularGaugeRangeTooltipBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeRangeTooltipBorder.html) - Specifies the tooltip border.
* [ShowAtMousePosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeRangeTooltipSettings.html#Syncfusion_Blazor_CircularGauge_CircularGaugeRangeTooltipSettings_ShowAtMousePosition) - Displays the tooltip at the cursor position.

## Tooltip for annotations

The Circular Gauge can display a tooltip when the mouse hovers over an annotation. To enable it, add `"Annotation"` to the [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeTooltipSettings.html#Syncfusion_Blazor_CircularGauge_CircularGaugeTooltipSettings_Type) array of `CircularGaugeTooltipSettings` on `SfCircularGauge`.

### Tooltip customization for annotations

Configure the annotation tooltip through [CircularGaugeAnnotationTooltipSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeAnnotationTooltipSettings.html) inside `CircularGaugeTooltipSettings`. The following options are available to customize the annotation tooltip:

* [Fill](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeAnnotationTooltipSettings.html#Syncfusion_Blazor_CircularGauge_CircularGaugeAnnotationTooltipSettings_Fill) - Specifies the annotation tooltip fill color.
* [CircularGaugeAnnotationTooltipTextStyle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeAnnotationTooltipTextStyle.html) - Specifies the annotation tooltip text style.
* [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeAnnotationTooltipSettings.html#Syncfusion_Blazor_CircularGauge_CircularGaugeAnnotationTooltipSettings_Format) - Specifies the annotation tooltip content format.
* [Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeAnnotationTooltipSettings.html#Syncfusion_Blazor_CircularGauge_CircularGaugeAnnotationTooltipSettings_Template) - Specifies a custom template for the tooltip content.
* [EnableAnimation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeAnnotationTooltipSettings.html#Syncfusion_Blazor_CircularGauge_CircularGaugeAnnotationTooltipSettings_EnableAnimation) - Enables or disables the open/close animation.
* [CircularGaugeAnnotationTooltipBorder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeAnnotationTooltipBorder.html) - Specifies the tooltip border.

The following code example shows the tooltip for pointers, ranges, and annotations.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge EnablePointerDrag="true">
    <CircularGaugeTooltipSettings Enable="true" Type="@TooltipType">
        <CircularGaugeAnnotationTooltipSettings Format="Circulargauge">
        </CircularGaugeAnnotationTooltipSettings>
        <CircularGaugeRangeTooltipSettings Fill="red">
        </CircularGaugeRangeTooltipSettings>
    </CircularGaugeTooltipSettings>
    <CircularGaugeAxes>
        <CircularGaugeAxis StartAngle="240" EndAngle="120" Minimum="0" Maximum="120" Radius="90%">
            <CircularGaugePointers>
                <CircularGaugePointer Value="70" Radius="60%" Color="#33BCBD">
                    <CircularGaugeCap Radius="10" Color="white">
                        <CircularGaugeCapBorder Width="5" Color="#33BCBD"></CircularGaugeCapBorder>
                    </CircularGaugeCap>
                    <CircularGaugePointerAnimation Enable="false">
                    </CircularGaugePointerAnimation>
                </CircularGaugePointer>
            </CircularGaugePointers>
            <CircularGaugeAxisMajorTicks Color="white" Height="12" Offset="-5">
            </CircularGaugeAxisMajorTicks>
            <CircularGaugeAxisMinorTicks Color="transparent" Width="0">
            </CircularGaugeAxisMinorTicks>
            <CircularGaugeAxisLabelStyle UseRangeColor="true">
                <CircularGaugeAxisLabelFont Color="#424242" Size="13px" FontFamily="Roboto">
                </CircularGaugeAxisLabelFont>
            </CircularGaugeAxisLabelStyle>
            <CircularGaugeAxisLineStyle Width="0">
            </CircularGaugeAxisLineStyle>
            <CircularGaugeRanges>
                <CircularGaugeRange Start="0" End="50" Radius="102%">
                </CircularGaugeRange>
                <CircularGaugeRange Start="50" End="120" Radius="102%">
                </CircularGaugeRange>
            </CircularGaugeRanges>
            <CircularGaugeAnnotations>
                <CircularGaugeAnnotation Angle="180" ZIndex="1">
                    <ContentTemplate>
                        <div>Circulargauge</div>
                    </ContentTemplate>
                </CircularGaugeAnnotation>
            </CircularGaugeAnnotations>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
@code {
public string[] TooltipType = new string[] { "Range", "Annotation", "Pointer"};
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rXVdNdhHqDOcWXTn?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Circular Gauge displays ToolTip for Annotation](./images/blazor-circulargauge-tooltip-annotation.webp)" %}

## Dragging pointer

The pointers can be dragged over the axis values by clicking and dragging the pointer. To enable or disable the pointer drag, use the [EnablePointerDrag](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_EnablePointerDrag) property.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge EnablePointerDrag="true">
    <CircularGaugeAxes >
        <CircularGaugeAxis>
            <CircularGaugePointers>
                <CircularGaugePointer Value="50">
                </CircularGaugePointer>
            </CircularGaugePointers>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LZhdXdrxAjOaGlpH?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Circular Gauge with Dragging Pointer](./images/blazor-circulargauge-dragging-pointer.webp)" %}

## Dragging range

The ranges can be dragged over the axis values by clicking and dragging the range. To enable or disable the range drag, use the [EnableRangeDrag](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_EnableRangeDrag) property.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge EnableRangeDrag="true">
    <CircularGaugeAxes>
        <CircularGaugeAxis>
            <CircularGaugePointers>
                <CircularGaugePointer Value="50">
                </CircularGaugePointer>
            </CircularGaugePointers>
            <CircularGaugeRanges>
                <CircularGaugeRange Start="0" End="80" Radius="108%" Color="#30B32D" StartWidth="8" EndWidth="8">
                </CircularGaugeRange>
            </CircularGaugeRanges>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hNBHtnBHgMNUWDpV?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Circular Gauge with Dragging Range](./images/blazor-circulargauge-dragging-range.webp)" %}