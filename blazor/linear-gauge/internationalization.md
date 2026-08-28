---
layout: post
title: Blazor Linear Gauge Internationalization | Syncfusion®
description: Learn how to localize the Blazor Linear Gauge for global audiences by configuring numeric formats, currency, and percentage on labels and tooltips.
platform: Blazor
control: Linear Gauge
documentation: ug
---

# Blazor Linear Gauge Internationalization

Localization allows customizing the default text content of the Blazor component for different cultures. For more information about localization, refer [here](https://blazor.syncfusion.com/documentation/common/localization).

## Globalization

Globalization is the process of designing and developing a component that works in different cultures. In the Linear Gauge, the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.SfLinearGauge.html#Syncfusion_Blazor_LinearGauge_SfLinearGauge_Format) property of [SfLinearGauge](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.SfLinearGauge.html) is used to globalize the numeric content displayed in the following features:

* Axis label
* Tooltip

The text on these features can be localized for any culture, such as Arabic (`ar`), German (`de`), or French (`fr`).

N> The `Format` property follows the `CultureInfo.CurrentCulture` of the application, so the same format specifier (for example, `"c"`) renders differently for each culture. To apply a specific culture to the application, see the Blazor [Localization](https://blazor.syncfusion.com/documentation/common/localization) documentation.

### Numeric Format

The text in axis labels and tooltips can be displayed in numeric formats such as currency, percentage, and so on. To know more about the numeric formats in axis labels, refer [here](axis.md#displaying-numeric-format-in-labels). The following table describes the result of applying some commonly used label formats on numeric values.

<table>
<tr>
<td><b>Label Value</b></td>
<td><b>Label Format property value</b></td>
<td><b>Result </b></td>
<td><b>Description </b></td>
</tr>
<tr>
<td>1000</td>
<td>n1</td>
<td>1000.0</td>
<td>The number is rounded to 1 decimal place.</td>
</tr>
<tr>
<td>1000</td>
<td>n2</td>
<td>1000.00</td>
<td>The number is rounded to 2 decimal places.</td>
</tr>
<tr>
<td>0.01</td>
<td>p1</td>
<td>1.0%</td>
<td>The number is converted to percentage with 1 decimal place.</td>
</tr>
<tr>
<td>0.01</td>
<td>p2</td>
<td>1.00%</td>
<td>The number is converted to percentage with 2 decimal places.</td>
</tr>
<tr>
<td>1000</td>
<td>c1</td>
<td>$1,000.0</td>
<td>The currency symbol is appended to the number, and the number is rounded to 1 decimal place.</td>
</tr>
<tr>
<td>1000</td>
<td>c2</td>
<td>$1,000.00</td>
<td>The currency symbol is appended to the number, and the number is rounded to 2 decimal places.</td>
</tr>
</table>

The following example displays the axis labels in the currency format.

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

## See also

* [Blazor Localization](https://blazor.syncfusion.com/documentation/common/localization)
* [Displaying numeric format in axis labels](axis.md#displaying-numeric-format-in-labels)
* [Tooltip format](user-interaction.md#tooltip-format)
