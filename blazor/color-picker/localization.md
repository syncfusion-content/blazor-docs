---
layout: post
title: Localization and RTL in Blazor Color Picker Component | Syncfusion
description: Checkout and learn here all about Localization and RTL in Syncfusion Blazor Color Picker component and more.
platform: Blazor
control: Color Picker
documentation: ug
---


# Localization and RTL in Blazor Color Picker Component

## Localization

[Blazor ColorPicker](https://www.syncfusion.com/blazor-components/blazor-color-picker) component can be localized. Refer to [Blazor Localization](https://blazor.syncfusion.com/documentation/common/localization) topic to localize Syncfusion Blazor components.

## RTL

Color Picker component has `RTL` support. It helps to render the Color Picker from right-to-left direction. It improves the user experiences and accessibility for users who use right-to-left languages(Arabic, Farsi, Urdu, etc). This can be achieved by setting the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_EnableRtl) property to true.

In the following example, Color Picker component is rendered in RTL mode with `arabic` locale.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfColorPicker EnableRtl="true"></SfColorPicker>

```


![Right to Left in Blazor ColorPicker](./images/blazor-colorpicker-right-to-left.png)