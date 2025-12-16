---
layout: post
title: Mode and Value in Blazor Color Picker Component | Syncfusion
description: Checkout and learn here all about Mode and Value in Syncfusion Blazor Color Picker component and more.
platform: Blazor
control: Color Picker
documentation: ug
---

# Mode and Value in Blazor Color Picker Component

## Rendering palette at initial load

By default, the `Picker` view is shown initially. To display the palette view when opening the Color Picker popup, set the [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_Mode) property to `Palette`.

In the following example, the palette is displayed at initial load.

```cshtml
@using Syncfusion.Blazor.Inputs

<h4>Choose a color</h4>
<SfColorPicker Mode="ColorPickerMode.Palette"></SfColorPicker>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZhgshBQKIhHYIMT?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor ColorPicker with Palette](./images/blazor-colorpicker-with-palette.png)" %}

## Color value

The [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_Value) property can be used to specify the color value to the Color Picker. It supports either `three` or `six` digit hex codes. To include `opacity`, set the color value as `four` or `eight` digit hex code.

In the following example, a 4-digit hex value is used, where the last digit represents the opacity.

```cshtml
@using Syncfusion.Blazor.Inputs

<h4>Choose a color</h4>
<SfColorPicker Value="035a" ModeSwitcher="false"></SfColorPicker>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjVUCBBQUeLkCZYv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Changing Blazor ColorPicker value](./images/blazor-colorpicker-value.png)" %}

N> The [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_Value) property supports hex codes with or without the `#` prefix.