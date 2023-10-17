---
layout: post
title: Accessibility in Blazor Linear Gauge Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor Linear Gauge component and more.
platform: Blazor
control: Linear Gauge
documentation: ug
---

# Accessibility in Blazor Linear Gauge Component

Linear Gauge provides built-in compliance with the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/practices/) specifications. The WAI-ARIA accessibility support is achieved through the attribute like `aria-label` in the SVG element. It helps to provide information about elements in a document for assistive technology. This attribute sets the text label with some default descriptions for the following elements in the Linear Gauge.
<!-- markdownlint-disable MD033 -->
<table>
<tr>
<td><b>Element</b></td>
<td><b>Default description</b></td>
</tr>
<tr>
<td>Gauge title</td>
<td>Specifies the title of the Linear gauge.</td>
</tr>
<tr>
<td>Pointer value</td>
<td>Specifies the value of the pointer in the Linear gauge.</td>
</tr>
</table>

To change this default description, use the [Description](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.SfLinearGauge.html#Syncfusion_Blazor_LinearGauge_SfLinearGauge_Description) property available in the [LinearGaugePointer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html) and the [SfLinearGauge](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.SfLinearGauge.html). It helps the screen reader to read for an assistive purpose.