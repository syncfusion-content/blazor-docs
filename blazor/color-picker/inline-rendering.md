---
layout: post
title: Inline Rendering in Blazor Color Picker Component | Syncfusion
description: Checkout and learn here all about Inline Rendering in Syncfusion Blazor Color Picker component and more.
platform: Blazor
control: Color Picker
documentation: ug
---

# Inline Rendering in Blazor Color Picker Component

By default, the Color Picker renders with a button that opens a popup to access the selector. To display the Color Picker directly on the page (without a popup), render it inline by setting the [Inline](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_Inline) property to `true`.

The following sample shows inline rendering of the Color Picker.

```cshtml
@using Syncfusion.Blazor.Inputs

<h4>Choose a color</h4>
<SfColorPicker Value="035a" Inline="true" ShowButtons="false"></SfColorPicker>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNVKsVrQgIVKJnGz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Inline rendering in Blazor Color Picker](./images/blazor-colorpicker-inline-rendering.png)

N> The `ShowButtons` property is disabled in this sample because control buttons are not needed for inline rendering. For details about control buttons functionality, see [ShowButtons](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_ShowButtons).