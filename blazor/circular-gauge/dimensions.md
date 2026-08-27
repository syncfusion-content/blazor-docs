---
layout: post
title: Blazor Circular Gauge Dimensions | Syncfusion®
description: Learn how to set the Blazor Circular Gauge size in pixels or as a percentage of the container using the Width and Height properties.
platform: Blazor
control: Circular Gauge
documentation: ug
---

# Blazor Circular Gauge Dimensions

## Size for Circular Gauge

You can set the size of the Circular Gauge directly using the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_Height) properties. The size can be specified either in pixels or as a percentage of the parent container.

### Size in pixels

Set the size of the Circular Gauge in pixels using the following code example.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge Width="200px" Height="200px">
    <CircularGaugeAxes>
        <CircularGaugeAxis>
            <CircularGaugePointers>
                <CircularGaugePointer/>
            </CircularGaugePointers>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LjLHDRhHgZDMRRsQ?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Changing Blazor Circular Gauge Size in Pixels](./images/blazor-circulargauge-size.webp)" %}

### Size in percentage

When size is specified as a percentage, the Circular Gauge is rendered with respect to its parent container. For example, when the height is set to `50%`, the gauge occupies half of the container height.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<div style="height:450px; width:450px">
    <SfCircularGauge Width="50%" Height="50%">
        <CircularGaugeAxes>
            <CircularGaugeAxis>
                <CircularGaugePointers>
                    <CircularGaugePointer/>
                </CircularGaugePointers>
            </CircularGaugeAxis>
        </CircularGaugeAxes>
    </SfCircularGauge>
</div>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZVxtdrdKttYumKi?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Changing Blazor Circular Gauge Size in Percentage](./images/blazor-circulargauge-size.webp)" %}

N> When the size is not specified, the Circular Gauge takes `450` pixels as its height and the width of the container as its width.

## See also

* [Getting Started with Blazor Circular Gauge](https://blazor.syncfusion.com/documentation/circular-gauge/getting-started)
* [Axes in Blazor Circular Gauge](https://blazor.syncfusion.com/documentation/circular-gauge/axes)