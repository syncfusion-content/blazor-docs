---
layout: post
title: Annotations in Blazor Linear Gauge Component | Syncfusion
description: Checkout and learn here all about Annotations in Syncfusion Blazor Linear Gauge component and much more.
platform: Blazor
control: Linear Gauge
documentation: ug
---

# Annotations in Blazor Linear Gauge Component

Annotations are used to mark the specific area of interest in the Linear Gauge with text, HTML elements, or images. Any number of annotations can be added to the Linear Gauge component.

## Adding annotation

To render the custom HTML elements in the Linear Gauge component, use the [ContentTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAnnotation.html#Syncfusion_Blazor_LinearGauge_LinearGaugeAnnotation_ContentTemplate) property in the [LinearGaugeAnnotation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAnnotation.html). The [Content](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAnnotation.html#Syncfusion_Blazor_LinearGauge_LinearGaugeAnnotation_Content) property in [LinearGaugeAnnotation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAnnotation.html) can be used to render the element as an annotation in the Linear Gauge.

```cshtml
@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeAnnotations>
        <LinearGaugeAnnotation AxisValue="0" ZIndex="1">
            <ContentTemplate>
                <div class="custom-annotation">40</div>
            </ContentTemplate>
        </LinearGaugeAnnotation>
    </LinearGaugeAnnotations>
    <LinearGaugeAxes>
        <LinearGaugeAxis>
            <LinearGaugePointers>
                <LinearGaugePointer PointerValue="40"></LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>

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

![Blazor Linear Gauge with Annotation](images/blazor-linear-gauge-annotation.png)

## Customization

The following properties are used to customize the annotation.

* [ZIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAnnotation.html#Syncfusion_Blazor_LinearGauge_LinearGaugeAnnotation_ZIndex) - Bring the annotation to the front or back, when annotation overlaps with another element.
* [AxisValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAnnotation.html#Syncfusion_Blazor_LinearGauge_LinearGaugeAnnotation_AxisValue) - To place the annotation in the specified axis value with respect to the provided axis index.
* [AxisIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAnnotation.html#Syncfusion_Blazor_LinearGauge_LinearGaugeAnnotation_AxisIndex) - To place the annotation in the specified axis with respect to the provided axis value.
* [HorizontalAlignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAnnotation.html#Syncfusion_Blazor_LinearGauge_LinearGaugeAnnotation_HorizontalAlignment) - To place the annotation horizontally.
* [VerticalAlignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAnnotation.html#Syncfusion_Blazor_LinearGauge_LinearGaugeAnnotation_VerticalAlignment) - To place the annotation vertically.
* [X](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAnnotation.html#Syncfusion_Blazor_LinearGauge_LinearGaugeAnnotation_X), [Y](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAnnotation.html#Syncfusion_Blazor_LinearGauge_LinearGaugeAnnotation_Y) - To place the annotation in the specified location.

<!-- markdownlint-disable MD036 -->

### Changing the z-index

To change the stack order of an annotation element, the [ZIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAnnotation.html#Syncfusion_Blazor_LinearGauge_LinearGaugeAnnotation_ZIndex) property of the [LinearGaugeAnnotation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAnnotation.html) can be used.

```cshtml
@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeAnnotations>
        <LinearGaugeAnnotation AxisValue="0" ZIndex="1">
            <ContentTemplate>
                <div class="custom-annotation">40</div>
            </ContentTemplate>
        </LinearGaugeAnnotation>
    </LinearGaugeAnnotations>
    <LinearGaugeAxes>
        <LinearGaugeAxis>
            <LinearGaugePointers>
                <LinearGaugePointer PointerValue="40"></LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>

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

![Blazor Linear Gauge with Annotation in Z Index](images/blazor-linear-gauge-annotation.png)
<!-- markdownlint-disable MD036 -->

### Positioning an annotation

The annotation can be placed anywhere in the Linear Gauge by setting the pixel value to the [X](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAnnotation.html#Syncfusion_Blazor_LinearGauge_LinearGaugeAnnotation_X) and [Y](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAnnotation.html#Syncfusion_Blazor_LinearGauge_LinearGaugeAnnotation_Y) properties in the [LinearGaugeAnnotation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAnnotation.html).

```cshtml
@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeAnnotations>
        <LinearGaugeAnnotation AxisValue="0" ZIndex="1" X="50" Y="-100">
            <ContentTemplate>
                <div class="custom-annotation">40</div>
            </ContentTemplate>
        </LinearGaugeAnnotation>
    </LinearGaugeAnnotations>
    <LinearGaugeAxes>
        <LinearGaugeAxis>
            <LinearGaugePointers>
                <LinearGaugePointer PointerValue="40"></LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>

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

![Blazor Linear Gauge with Annotation in Custom Position](images/blazor-linear-gauge-annotation-in-custom-position.png)

### Alignment of annotation

The annotation can be aligned horizontally and vertically by using the [HorizontalAlignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAnnotation.html#Syncfusion_Blazor_LinearGauge_LinearGaugeAnnotation_HorizontalAlignment) and [VerticalAlignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAnnotation.html#Syncfusion_Blazor_LinearGauge_LinearGaugeAnnotation_VerticalAlignment) properties respectively. The possible values can be [Center](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Placement.html#Syncfusion_Blazor_LinearGauge_Placement_Center), [Far](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Placement.html#Syncfusion_Blazor_LinearGauge_Placement_Far), [Near](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Placement.html#Syncfusion_Blazor_LinearGauge_Placement_Near), and [None](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.Placement.html#Syncfusion_Blazor_LinearGauge_Placement_None). The [HorizontalAlignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAnnotation.html#Syncfusion_Blazor_LinearGauge_LinearGaugeAnnotation_HorizontalAlignment) and [VerticalAlignment](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAnnotation.html#Syncfusion_Blazor_LinearGauge_LinearGaugeAnnotation_VerticalAlignment)  properties are not applicable when the [X](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAnnotation.html#Syncfusion_Blazor_LinearGauge_LinearGaugeAnnotation_X) and [Y](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAnnotation.html#Syncfusion_Blazor_LinearGauge_LinearGaugeAnnotation_Y) properties are set in the [LinearGaugeAnnotation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAnnotation.html).

```cshtml
@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeAnnotations>
        <LinearGaugeAnnotation ZIndex="1"
                               HorizontalAlignment="Placement.Center"
                               VerticalAlignment="Placement.Center">
            <ContentTemplate>
                <div class="custom-annotation">40</div>
            </ContentTemplate>
        </LinearGaugeAnnotation>
    </LinearGaugeAnnotations>
    <LinearGaugeAxes>
        <LinearGaugeAxis>
            <LinearGaugePointers>
                <LinearGaugePointer PointerValue="40"></LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>

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

![Changing Annotation Alignment in Blazor Linear Gauge](images/blazor-linear-gauge-annotation-alignment.png)

## Multiple annotations

Multiple annotations can be added to the Linear Gauge component by adding the multiple [LinearGaugeAnnotation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAnnotation.html) in the [LinearGaugeAnnotations](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAnnotations.html) and customization for the annotation can be done with the [LinearGaugeAnnotation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugeAnnotation.html).

```cshtml
@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge>
    <LinearGaugeAnnotations>
        <LinearGaugeAnnotation ZIndex="1" AxisValue="100"
                               X="-110" Y="-35">
            <ContentTemplate>
                <div class="custom-annotation">Speed to get higher milage</div>
            </ContentTemplate>
        </LinearGaugeAnnotation>
        <LinearGaugeAnnotation AxisValue="0" ZIndex="1">
            <ContentTemplate>
                <div class="speed">40</div>
            </ContentTemplate>
        </LinearGaugeAnnotation>
    </LinearGaugeAnnotations>
    <LinearGaugeAxes>
        <LinearGaugeAxis>
            <LinearGaugePointers>
                <LinearGaugePointer PointerValue="40"></LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>

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
        width: 210px;
        padding: 2px 5px;
    }
</style>
```

![Blazor Linear Gauge with Multiple Annotations](images/blazor-linear-gauge-multiple-annotations.png)