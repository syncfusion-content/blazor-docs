---
layout: post
title: Accessibility in Blazor Linear Gauge Component | Syncfusion 
description: Learn about Accessibility in Blazor Linear Gauge component of Syncfusion, and more details.
platform: Blazor
control: Linear Gauge
documentation: ug
---

# Accessibility in Blazor Linear Gauge (SfLinearGauge)

Linear Gauge provides built-in compliance with the [WAI-ARIA](http://www.w3.org/WAI/PF/aria-practices/) specifications. The WAI-ARIA accessibility support is achieved through the attribute like `aria-label` in the SVG element. It helps to provide information about elements in a document for assistive technology. This attribute sets the text label with some default descriptions for the following elements in the Linear Gauge.

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

To change this default description, use the [`Description`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.SfLinearGauge.html#Syncfusion_Blazor_LinearGauge_SfLinearGauge_Description) property available in [`LinearGaugePointer`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.LinearGaugePointer.html#Syncfusion_Blazor_LinearGauge_LinearGaugePointer_Description) and the [`SfLinearGauge`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.LinearGauge.SfLinearGauge.html#Syncfusion_Blazor_LinearGauge_SfLinearGauge_Description) class. It helps the screen reader to read for an assistive purpose.