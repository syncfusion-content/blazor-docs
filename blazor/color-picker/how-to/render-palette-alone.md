---
layout: post
title: Render palette alone in Blazor Color Picker Component | Syncfusion
description: Checkout and learn here all about Render palette alone in Syncfusion Blazor Color Picker component and more.
platform: Blazor
control: Color Picker
documentation: ug
---

# Render palette alone in Blazor Color Picker Component

Render only the palette in the Color Picker by setting the [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_Mode) property to `Palette` and disabling the [ModeSwitcher](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_ModeSwitcher) to prevent switching to the picker view.

In the following sample, the [ShowButtons](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_ShowButtons) property is set to `false` to hide the control buttons, so only the palette area is displayed and color selection applies immediately.

```cshtml
@using Syncfusion.Blazor.Inputs

<h4>Choose a color</h4>
<SfColorPicker Mode="ColorPickerMode.Palette" ModeSwitcher="false" ShowButtons="false"></SfColorPicker>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LtLKiLLGUoxTFJzx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Rendering Palette Alone in Blazor ColorPicker](./../images/blazor-colorpicker-with-palette-alone.png)" %}

N> To display the palette embedded in the page instead of in a popup, set `Inline="true"`. To render `Picker` alone, specify the [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_Mode) property as 'Picker'.