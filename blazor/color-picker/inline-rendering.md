---
layout: post
title: Inline Rendering in Blazor Color Picker Component | Syncfusion
description: Checkout and learn here all about Inline Rendering in Syncfusion Blazor Color Picker component and more.
platform: Blazor
control: Color Picker
documentation: ug
---

# Inline Rendering in Blazor Color Picker Component

By default, the ColorPicker will be rendered using SplitButton and open the pop-up to access the ColorPicker. To render the ColorPicker container alone and to access it directly, render it as inline. It can be achieved by setting the [Inline](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_Inline) property to `true`.

The following sample shows the inline type rendering of ColorPicker.

```cshtml
@using Syncfusion.Blazor.Inputs

<h4>Choose a color</h4>
<SfColorPicker Value="035a" Inline="true" ShowButtons="false"></SfColorPicker>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNVKsVrQgIVKJnGz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Inline Rendering in Blazor ColorPicker](./images/blazor-colorpicker-inline-rendering.png)

N> The `ShowButtons` property is disabled in this sample because the control buttons are not needed for inline type. To know about the control buttons functionality, refer to the [ShowButtons](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_ShowButtons).
