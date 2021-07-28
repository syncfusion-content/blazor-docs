---
layout: post
title: Globalization in Blazor Linear Gauge Component | Syncfusion
description: Learn here all about Globalization in Syncfusion Blazor Linear Gauge component (SfLinearGauge) and more.
platform: Blazor
control: Linear Gauge
documentation: ug
---

# Internationalization in Blazor Linear Gauge Component (SfLinearGauge)

The localization allows to localize the default text content in the Blazor component. For more information about localization, refer [here](https://blazor.syncfusion.com/documentation/common/localization/).

## Globalization

Globalization is the process of designing and developing a component that works in different cultures. Internationalization is used to globalize the number content in Linear Gauge component using [`Format`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.SfLinearGauge.html#Syncfusion_Blazor_LinearGauge_SfLinearGauge_Format) property in [`SfLinearGauge`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.SfLinearGauge.html). It has static text on some features such as

* Axis label
* Tooltip

The static text on above features can be changed to any culture such as Arabic, Deutsch and French.

### Numeric Format

The text in axis labels and tooltip can be displayed in the numeric format such as currency, percentage and so on. To know more about the numeric formats in axis labels, refer [here](axis/#displaying-numeric-format-in-labels). In the below example, the axis label is displayed in the currency format.

```csharp
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

![Linear Gauge with Internationalization Sample](images/locale.png)