---
layout: post
title: Dimensions in Blazor Circular Gauge Component | Syncfusion®
description: Checkout and learn here all the features about Dimensions in Blazor Circular Gauge component and more.
platform: Blazor
control: Circular Gauge
documentation: ug
---

# Dimensions in Blazor Circular Gauge Component

The **Blazor Circular Gauge component** provides flexible options for defining its size and layout, making it suitable for a variety of user interface designs. Whether you are building dashboards, monitoring systems, or data visualization components, controlling the gauge's dimensions plays a significant role in ensuring clarity and responsiveness.

This section explains how to configure the **width and height** of the Circular Gauge using different units such as pixels and percentages, along with best practices to ensure optimal rendering across devices.


## Size for Circular Gauge


The size of the Circular Gauge can be directly controlled using two key properties:

- [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_Width)
- [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.CircularGauge.SfCircularGauge.html#Syncfusion_Blazor_CircularGauge_SfCircularGauge_Height) 

These properties are part of the `SfCircularGauge` component and accept string values. This allows you to define dimensions using various units such as **pixels (`px`)** or **percentage (`%`)**, giving you flexibility in designing both fixed and responsive layouts.


### In pixel

You can specify the size of the Circular Gauge using **pixel values** when you need precise and consistent dimensions. This method is ideal for fixed layouts where the component must maintain the same size regardless of the screen or container.

You can set the size of the Circular Gauge in pixel as demonstrated below.

```cshtml
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge Width= "200px" Height= "200px">
    <CircularGaugeAxes>
        <CircularGaugeAxis>
            <CircularGaugePointers>
                <CircularGaugePointer/>
            </CircularGaugePointers>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hthItOWmVBPpLJbl?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Changing Blazor Circular Gauge Size in Pixel](./images/blazor-circulargauge-size.webp)" %}

#### Key Highlights

- Width="200px" defines a fixed width of 200 pixels.
- Height="200px" defines a fixed height of 200 pixels.
- The gauge maintains its exact size regardless of its container or screen size.
- Useful for layouts where alignment and spacing are tightly controlled.

### In percentage

You can also define the size of the Circular Gauge using percentage values, allowing it to adapt dynamically to the size of its parent container. This approach is essential for creating responsive layouts that adjust seamlessly across different devices and screen sizes.
When percentage values are used:

The gauge's size is calculated relative to its parent container.
The component becomes responsive and adjusts automatically when the container resizes.

Example: Percentage-Based Dimensions
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDVetOicVLudqTfx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Changing Blazor Circular Gauge Size in Percentage](./images/blazor-circulargauge-size.webp)" %}

#### Key Highlights

- Width="50%" makes the gauge take half the width of its parent container.
- Height="50%" makes it occupy half the height of the parent container.
- The parent <div> must have explicit dimensions for percentage sizing to work correctly.
- Ideal for responsive dashboards and flexible UI designs.

### Default Dimensions
If no explicit width or height is provided:

- The default height of the Circular Gauge is 450 pixels.
- The default width adjusts automatically based on the available window or parent container width.


This default behavior ensures that the gauge is displayed properly even without manual configuration, making it easier to get started quickly.

The Blazor Circular Gauge component offers powerful and flexible dimension controls through its Width and Height properties. By leveraging these options effectively, you can create gauges that are either fixed in size or fully responsive.

- Use pixel values for precise control and fixed layouts.
- Use percentage values for adaptive and responsive interfaces.
- Ensure proper parent container sizing when using percentage units.
- Understand default sizing behavior to avoid unexpected results.

With these techniques, you can seamlessly integrate the Circular Gauge into your Blazor applications while maintaining both visual consistency and optimal responsiveness.

N> When you do not specify the size, it takes `450` pixels as the height and window size as its width.