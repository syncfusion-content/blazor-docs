---
layout: post
title: Annotations in Blazor Circular Gauge Component | Syncfusion
description: Checkout and learn here all about Annotations in Syncfusion Blazor Circular Gauge component and more.
platform: Blazor
control: Circular Gauge
documentation: ug
---

# Annotations in Blazor Circular Gauge Component

Annotations are used to mark a specific area of interest in the Circular Gauge with texts, shapes, or images.

## Customization

You can place any custom element on the axis area using [ContentTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeAnnotation.html#Syncfusion_Blazor_CircularGauge_CircularGaugeAnnotation_ContentTemplate) in the [CircularGaugeAnnotation](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeAnnotation.html).

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge Height="250px" Width="250px">
    <CircularGaugeAxes>
        <CircularGaugeAxis>
            <CircularGaugePointers>
                <CircularGaugePointer Value="50"></CircularGaugePointer>
            </CircularGaugePointers>
            <CircularGaugeAnnotations>
                <CircularGaugeAnnotation Angle="195" ZIndex="1">
                    <ContentTemplate>
                        <div class="custom-annotation">50</div>
                    </ContentTemplate>
                </CircularGaugeAnnotation>
            </CircularGaugeAnnotations>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
<style type="text/css">
    .custom-annotation {
        color: white;
        background-color: blue;
        height: 30px;
        width: 30px;
        border-radius: 15px;
        padding: 4px 0 0 6px;
        font-weight: bold;
    }
</style>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VtLgWrBGKhmauxQC?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Circular Gauge with Annotation](./images/blazor-circulargauge-annotation.png)" %}

## Positioning the annotation

Annotations can be placed around an axis using the [Radius](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeAnnotation.html#Syncfusion_Blazor_CircularGauge_CircularGaugeAnnotation_Radius) and [Angle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeAnnotation.html#Syncfusion_Blazor_CircularGauge_CircularGaugeAnnotation_Angle) properties. For example, if the angle is 90 degrees and the radius is 110%, then the annotation will be placed at the right of the axis.

The radius of an annotation takes values either in pixel or in percentage. By setting value in percentage, annotation gets its position with respect to its axis radius.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge Height="250px" Width="250px">
    <CircularGaugeAxes>
        <CircularGaugeAxis>
            <CircularGaugePointers>
                <CircularGaugePointer Value="50"></CircularGaugePointer>
            </CircularGaugePointers>
            <CircularGaugeAnnotations>
                <CircularGaugeAnnotation Angle="90"
                                         Radius="110%"
                                         ZIndex="1">
                    <ContentTemplate>
                        <div class="custom-annotation">50</div>
                    </ContentTemplate>
                </CircularGaugeAnnotation>
            </CircularGaugeAnnotations>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
<style type="text/css">
    .custom-annotation {
        color: white;
        background-color: blue;
        height: 30px;
        width: 30px;
        border-radius: 15px;
        padding: 4px 0 0 6px;
        font-weight: bold;
    }
</style>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LZBgsrVcKVvLKeKB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Changing Annotation Position in Blazor Circular Gauge](./images/blazor-circulargauge-annotation-position.png)" %}

## Multiple annotations

Using [CircularGaugeAnnotation](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.CircularGauge.CircularGaugeAnnotation.html), you can add multiple annotations to the circular gauge and each annotation content can be customized separately.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge Height="250px" Width="250px">
    <CircularGaugeAxes>
        <CircularGaugeAxis>
            <CircularGaugeRanges>
                <CircularGaugeRange Start="35"
                                    End="70"
                                    Color="blue"
                                    Opacity="0.2">
                </CircularGaugeRange>
            </CircularGaugeRanges>
            <CircularGaugePointers>
                <CircularGaugePointer Value="50"></CircularGaugePointer>
            </CircularGaugePointers>
            <CircularGaugeAnnotations>
                <CircularGaugeAnnotation Angle="325" Radius="150%" ZIndex="1">
                    <ContentTemplate>
                        <div class="custom-annotation">Speed to get higher milage</div>
                    </ContentTemplate>
                </CircularGaugeAnnotation>
                <CircularGaugeAnnotation Angle="195" ZIndex="1">
                    <ContentTemplate>
                        <div class="speed">50</div>
                    </ContentTemplate>
                </CircularGaugeAnnotation>
            </CircularGaugeAnnotations>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
<style type="text/css">
    .speed {
        color: white;
        background-color: blue;
        height: 30px;
        width: 30px;
        border-radius: 15px;
        padding: 4px 0 0 6px;
        font-weight: bold;
    }

    .custom-annotation {
        background-color: lightgray;
        width: 100%;
        padding: 1px;
    }
</style>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BjVKWrBQqrFpJXLX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Circular Gauge with Multiple Annotation](./images/blazor-circulargauge-multiple-annotation.png)" %}

## See also

* [Tooltip for Annotation](user-interaction#tooltip-for-annotations)