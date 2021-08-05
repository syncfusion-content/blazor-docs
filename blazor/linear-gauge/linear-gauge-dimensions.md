---
layout: post
title: Dimensions in Blazor Linear Gauge Component | Syncfusion
description: Checkout and learn here all about Dimensions in Syncfusion Blazor Linear Gauge component and much more.
platform: Blazor
control: Linear Gauge
documentation: ug
---

# Dimensions in Blazor Linear Gauge Component

## Size for Linear Gauge

The height and width of the Linear Gauge can be set using the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.SfLinearGauge.html#Syncfusion_Blazor_LinearGauge_SfLinearGauge_Width) and [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.SfLinearGauge.html#Syncfusion_Blazor_LinearGauge_SfLinearGauge_Height) properties in [SfLinearGauge](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.SfLinearGauge.html) class.

### In Pixel

The size of the Linear Gauge can be set in pixel as demonstrated below.

```cshtml
@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge Width="100px" Height="350px">
    <LinearGaugeAxes>
        <LinearGaugeAxis>
            <LinearGaugePointers>
                <LinearGaugePointer></LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>
```

![Linear Gauge with Size in Pixel](images/pixel.png)

### In Percentage

By setting value in percentage, Linear Gauge receives its dimension matching to its parent. For example, when the height is set as "**50%**", Linear Gauge renders to half of the parent height. The Linear Gauge will be responsive when the width is set as "**100%**".

```cshtml
@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge Width="100%" Height="50%">
    <LinearGaugeAxes>
        <LinearGaugeAxis>
            <LinearGaugePointers>
                <LinearGaugePointer></LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>
```

![Linear Gauge with Size in Percentage](images/percentage.png)

> When the component's size is not specified, the height will be "**450px**" and the width will be the same as the parent element's width.
