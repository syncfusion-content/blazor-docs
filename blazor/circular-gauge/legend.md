---
layout: post
title: Blazor Circular Gauge Legend | Syncfusion®
description: Learn how to display a Blazor Circular Gauge legend to identify axis ranges, then customize its shape, position, alignment, and absolute location.
platform: Blazor
control: Circular Gauge
documentation: ug
---


# Blazor Circular Gauge Legend

The legend provides valuable information for interpreting what the circular gauge axis range displays. It can be represented in various colors, shapes, and other identifiers based on the data, giving a breakdown of what each symbol represents in the axis range of the circular gauge.

You can add a legend for circular gauge ranges by setting the `Visible` property of `CircularGaugeLegendSettings` to `true`.

<!-- markdownlint-disable MD036 -->

## Legend customization

You can customize the legend shape, alignment, position, and appearance.

## Position and alignment

The position is used to place the legend in various positions. You can use the `Position` property of `CircularGaugeLegendSettings`. Based on the position, the legend item will be aligned accordingly. The following options are available to customize the legend position:

* Top
* Bottom
* Left
* Right
* Custom
* Auto

The legend alignment is used to align the legend items in a specific location. You can use the `Alignment` property in `CircularGaugeLegendSettings` to align the legend items. The following options are available to customize the legend alignment:

* Near
* Center
* Far

The legend can also be positioned at an absolute location using the `Location` property of `CircularGaugeLegendSettings`, which contains `X` and `Y` values.

### Legend size

The legend size can be modified using the `Height` and `Width` properties in `CircularGaugeLegendSettings`.

### Legend opacity

To specify the transparency of the legend shape, set the `Opacity` property of `CircularGaugeLegendSettings` to a value between `0` and `1`.

### Legend shape

To change the legend item shape, set the `Shape` property of the legend. By default, the shape of the legend is `Circle`.

It also supports the following shapes:

* Circle
* Rectangle
* Diamond
* Triangle
* InvertedTriangle
* Image

You can customize the size of each legend item using the `ShapeWidth` and `ShapeHeight` properties.

### Legend padding

You can control the spacing between the legend items using the `Padding` option of the legend. The default value of padding is `5` (in pixels).

### Legend border

You can customize the legend border using the `CircularGaugeLegendBorder` option, which exposes the `Color` and `Width` properties.

## Font of the legend text

The `Font` of the legend item text can be customized using the following properties:

* FontFamily
* FontStyle
* FontWeight
* Opacity
* Color
* Size

The following code example shows how to add a legend to the gauge.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge>
<CircularGaugeLegendSettings Visible="true" ShapeWidth="30" ShapeHeight="30" Padding="15">
    <CircularGaugeLegendBorder Color="green" Width="3"></CircularGaugeLegendBorder>
</CircularGaugeLegendSettings>
<CircularGaugeAxes>
    <CircularGaugeAxis Minimum="0" Maximum="100">
        <CircularGaugePointers><CircularGaugePointer Value="0"></CircularGaugePointer></CircularGaugePointers>
        <CircularGaugeAxisMajorTicks UseRangeColor="true">
        </CircularGaugeAxisMajorTicks>
        <CircularGaugeAxisMinorTicks UseRangeColor="true">
        </CircularGaugeAxisMinorTicks>
        <CircularGaugeAxisLabelStyle UseRangeColor="true">
        </CircularGaugeAxisLabelStyle>
        <CircularGaugeRanges>
            <CircularGaugeRange Start="0" End="25" Radius="108%"></CircularGaugeRange>
            <CircularGaugeRange Start="25" End="50" Radius="108%"></CircularGaugeRange>
            <CircularGaugeRange Start="50" End="75" Radius="108%"></CircularGaugeRange>
            <CircularGaugeRange Start="75" End="100" Radius="108%"></CircularGaugeRange>
        </CircularGaugeRanges>
    </CircularGaugeAxis>
</CircularGaugeAxes>
</SfCircularGauge>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VtBnZdhxVoipsluO?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Legend in Blazor Circular Gauge](./images/blazor-circulargauge-legend.webp)" %}

## Toggle option in legend

The legend supports a toggle option. When you toggle a legend item, the corresponding range color is hidden or shown in the circular gauge. Enable the toggle option using the `ToggleVisibility` property of `CircularGaugeLegendSettings`.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge>
<CircularGaugeLegendSettings Visible="true" ToggleVisibility="true">
    <CircularGaugeLegendBorder Color="green" Width="3"></CircularGaugeLegendBorder>
</CircularGaugeLegendSettings>
<CircularGaugeAxes>
    <CircularGaugeAxis Minimum="0" Maximum="100">
        <CircularGaugePointers><CircularGaugePointer Value="0"></CircularGaugePointer></CircularGaugePointers>
        <CircularGaugeAxisMajorTicks UseRangeColor="true">
        </CircularGaugeAxisMajorTicks>
        <CircularGaugeAxisMinorTicks UseRangeColor="true">
        </CircularGaugeAxisMinorTicks>
        <CircularGaugeAxisLabelStyle UseRangeColor="true">
        </CircularGaugeAxisLabelStyle>
        <CircularGaugeRanges>
            <CircularGaugeRange Start="0" End="25" Radius="108%"></CircularGaugeRange>
            <CircularGaugeRange Start="25" End="50" Radius="108%"></CircularGaugeRange>
            <CircularGaugeRange Start="50" End="75" Radius="108%"></CircularGaugeRange>
            <CircularGaugeRange Start="75" End="100" Radius="108%"></CircularGaugeRange>
        </CircularGaugeRanges>
    </CircularGaugeAxis>
</CircularGaugeAxes>
</SfCircularGauge>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BtBnXdBnBIZlTtMp?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Circular Gauge Legend with Toggle Option](./images/blazor-circulargauge-legend-with-toggle-option.webp)" %}

## Paging Support in Legend

By default, paging will be enabled if the legend items exceed the legend bounds. You can view each legend item by navigating between the pages using navigation buttons.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge>
<CircularGaugeLegendSettings Visible="true" Height="50">
    <CircularGaugeLegendBorder Color="green" Width="3"></CircularGaugeLegendBorder>
</CircularGaugeLegendSettings>
<CircularGaugeAxes>
    <CircularGaugeAxis Minimum="0" Maximum="100">
        <CircularGaugePointers><CircularGaugePointer Value="0"></CircularGaugePointer></CircularGaugePointers>
        <CircularGaugeAxisMajorTicks UseRangeColor="true">
        </CircularGaugeAxisMajorTicks>
        <CircularGaugeAxisMinorTicks UseRangeColor="true">
        </CircularGaugeAxisMinorTicks>
        <CircularGaugeAxisLabelStyle UseRangeColor="true">
        </CircularGaugeAxisLabelStyle>
        <CircularGaugeRanges>
            <CircularGaugeRange Start="0" End="25" Radius="108%"></CircularGaugeRange>
            <CircularGaugeRange Start="25" End="50" Radius="108%"></CircularGaugeRange>
            <CircularGaugeRange Start="50" End="75" Radius="108%"></CircularGaugeRange>
            <CircularGaugeRange Start="75" End="100" Radius="108%"></CircularGaugeRange>
        </CircularGaugeRanges>
    </CircularGaugeAxis>
</CircularGaugeAxes>
</SfCircularGauge>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDhxDxBHhpHNtYid?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor Circular Gauge Legend with Paging](./images/blazor-circulargauge-legend-paging.webp)" %}

## Legend Text Customization

You can customize the legend text using `LegendText` property in `CircularGaugeRange`.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge>
<CircularGaugeLegendSettings Visible="true" Height="125">
    <CircularGaugeLegendBorder Color="green" Width="3"></CircularGaugeLegendBorder>
</CircularGaugeLegendSettings>
<CircularGaugeAxes>
    <CircularGaugeAxis Minimum="0" Maximum="100">
        <CircularGaugePointers><CircularGaugePointer Value="0"></CircularGaugePointer></CircularGaugePointers>
        <CircularGaugeAxisMajorTicks UseRangeColor="true">
        </CircularGaugeAxisMajorTicks>
        <CircularGaugeAxisMinorTicks UseRangeColor="true">
        </CircularGaugeAxisMinorTicks>
        <CircularGaugeAxisLabelStyle UseRangeColor="true">
        </CircularGaugeAxisLabelStyle>
        <CircularGaugeRanges>
            <CircularGaugeRange Start="0" End="25" Radius="108%" LegendText="Light air">
            </CircularGaugeRange>
            <CircularGaugeRange Start="25" End="50" Radius="108%" LegendText="Light breeze">
            </CircularGaugeRange>
            <CircularGaugeRange Start="50" End="75" Radius="108%" LegendText="Gentle breeze">
            </CircularGaugeRange>
            <CircularGaugeRange Start="75" End="100" Radius="108%" LegendText="Moderate breeze">
            </CircularGaugeRange>
        </CircularGaugeRanges>
    </CircularGaugeAxis>
</CircularGaugeAxes>
</SfCircularGauge>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BXVHNFVGUkWmsuQV?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Customizing Legend Text in Blazor Circular Gauge](./images/blazor-circulargauge-legend-text.webp)" %}

## See also

* [Blazor Circular Gauge Ranges](ranges.md)
* [Blazor Circular Gauge Annotations](annotations.md)
* [Blazor Circular Gauge Axes and Pointers](axes.md)
