---
layout: post
title: Blazor Linear Gauge Internationalization | Syncfusion®
description: Learn how to localize the Blazor Linear Gauge for global audiences by configuring numeric formats, currency, and percentage on labels and tooltips.
platform: Blazor
control: Linear Gauge
documentation: ug
---

# Blazor Linear Gauge Internationalization

The localization allows to localize the default text content in the Blazor component. For more information about localization, refer [here](https://blazor.syncfusion.com/documentation/common/localization).

## Globalization

Globalization is the process of designing and developing a component that works in different cultures. Internationalization is used to globalize the number content in Linear Gauge component using [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.SfLinearGauge.html#Syncfusion_Blazor_LinearGauge_SfLinearGauge_Format) property in [SfLinearGauge](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.SfLinearGauge.html). It has static text on some features such as,

* Axis label
* Tooltip

The static text on above features can be changed to any culture such as Arabic, Deutsch and French.

### Numeric Format

The text in axis labels and tooltip can be displayed in the numeric format such as currency, percentage and so on. To know more about the numeric formats in axis labels, refer [here](axis/#displaying-numeric-format-in-labels). In the below example, the axis label is displayed in the currency format.

```cshtml
@using Syncfusion.Blazor.LinearGauge

<SfLinearGauge Format="c">
    <LinearGaugeAxes>
        <LinearGaugeAxis>
            <LinearGaugePointers>
                <LinearGaugePointer></LinearGaugePointer>
            </LinearGaugePointers>
        </LinearGaugeAxis>
    </LinearGaugeAxes>
</SfLinearGauge>
```

![Blazor Linear Gauge with Localization](images/blazor-linear-gauge-localization.webp)