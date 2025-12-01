---
layout: post
title: Disable Color Picker in Blazor Color Picker Component | Syncfusion
description: Checkout and learn here all about Disable Color Picker in Syncfusion Blazor Color Picker component and more.
platform: Blazor
control: Color Picker
documentation: ug
---

# Disable Color Picker in Blazor Color Picker Component

Set the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_Disabled) property to `true` to disable the Color Picker. In the disabled state, the input and popup cannot receive focus or user interaction.

The following example shows the `Disabled` state of the Color Picker component.

```cshtml
@using Syncfusion.Blazor.Inputs

<h4>Choose a color</h4>
<SfColorPicker Disabled="true"></SfColorPicker>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/htLKsLrGgeJFrvZn?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Disable State in Blazor ColorPicker](./../images/blazor-colorpicker-disable-state.png)" %}
