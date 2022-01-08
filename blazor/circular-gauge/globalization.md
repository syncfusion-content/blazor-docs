---
layout: post
title: Globalization in Blazor Circular Gauge Component | Syncfusion
description: Checkout and learn here all about Globalization in Syncfusion Blazor Circular Gauge component and more.
platform: Blazor
control: Circular Gauge
documentation: ug
---

# Globalization in Blazor Circular Gauge Component

Circular Gauge provides internationalization support for below elements.

* Axis label.
* Tooltip.

Globalization is the process of designing and developing a component that works in different cultures or locales. The Format property is used to globalize number, date, and time values in the CircularGauge component.

In the following code example, axis labels are `globalized` to EUR.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.CircularGauge

<SfCircularGauge>
    <CircularGaugeAxes>
        <CircularGaugeAxis>
            <CircularGaugeAxisLabelStyle Format='c' Position="Position.Inside">
            </CircularGaugeAxisLabelStyle>
        </CircularGaugeAxis>
    </CircularGaugeAxes>
</SfCircularGauge>

```

![Localization in Blazor Circular Gauge](./images/blazor-circulargauge-localization.png)