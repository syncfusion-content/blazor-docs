---
layout: post
title: How to render palette alone in Blazor Color Picker | Syncfusion®
description: Render only the palette in the Blazor Color Picker by setting Mode to Palette and disabling the ModeSwitcher to prevent switching to the picker.
platform: Blazor
control: Color Picker
documentation: ug
---

# How to render palette alone in Blazor Color Picker

Render only the palette in the Color Picker by setting the [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_Mode) property to `ColorPickerMode.Palette` and disabling the [ModeSwitcher](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_ModeSwitcher) to prevent switching to the picker view.

In the following sample, the [ShowButtons](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_ShowButtons) property is set to `false` to hide the control buttons, so only the palette area is displayed and color selection applies immediately.

```cshtml
@using Syncfusion.Blazor.Inputs

<h4>Choose a color</h4>
<SfColorPicker Mode="ColorPickerMode.Palette" ModeSwitcher="false" ShowButtons="false"></SfColorPicker>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hZrnDnskffXetUxr?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Rendering Palette Alone in Blazor ColorPicker](./../images/blazor-colorpicker-with-palette-alone.webp)" %}

N> To display the palette embedded in the page instead of in a popup, set `Inline="true"`. To render `Picker` alone, specify the [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_Mode) property as 'Picker'.

## Render the palette inline

To display the palette embedded in the page (instead of in a popup), set `Inline="true"`. The following example shows an inline palette that fills its parent container.

```cshtml
@using Syncfusion.Blazor.Inputs

<h4>Choose a color</h4>
<SfColorPicker Mode="ColorPickerMode.Palette" ModeSwitcher="false" ShowButtons="false" Inline="true"></SfColorPicker>
```

## Render the picker view alone

To render only the picker view without the palette, set the [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_Mode) property to `ColorPickerMode.Picker` and disable the [ModeSwitcher](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_ModeSwitcher) so users cannot switch back to the palette.

```cshtml
@using Syncfusion.Blazor.Inputs

<h4>Choose a color</h4>
<SfColorPicker Mode="ColorPickerMode.Picker" ModeSwitcher="false" ShowButtons="false" Inline="true"></SfColorPicker>
```

## See also

* [Blazor Color Picker Getting Started](https://blazor.syncfusion.com/documentation/color-picker/getting-started)
* [Blazor Color Picker Property Customizations](https://blazor.syncfusion.com/documentation/color-picker/property-customizations)
* [Blazor Color Picker Customizations](https://blazor.syncfusion.com/documentation/color-picker/how-to/customize-color-picker)