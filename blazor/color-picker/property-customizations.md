---
layout: post
title: Property Customizations in Blazor Color Picker Component | Syncfusion
description: Checkout and learn here all about Property Customizations in Syncfusion Blazor Color Picker component and more.
platform: Blazor
control: Color Picker
documentation: ug
---

# Property Customizations in Blazor Color Picker Component

## Inline Rendering in Blazor Color Picker Component

By default, the Color Picker renders with a button that opens a popup to access the selector. To display the Color Picker directly on the page (without a popup), render it inline by setting the [Inline](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_Inline) property to `true`.

The following sample shows inline rendering of the Color Picker.

```cshtml
@using Syncfusion.Blazor.Inputs

<h4>Choose a color</h4>
<SfColorPicker Value="035a" Inline="true" ShowButtons="false"></SfColorPicker>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNLRtxsOpJfpxiQi?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Inline Rendering in Blazor ColorPicker](./images/blazor-colorpicker-inline-rendering.webp)" %}

N> The `ShowButtons` property is disabled in this sample because control buttons are not needed for inline rendering. For details about control buttons functionality, see [ShowButtons](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_ShowButtons).

## RTL in Blazor Color Picker Component

The Color Picker supports right-to-left (RTL) layout to improve usability for languages such as Arabic, Farsi, and Urdu. Enable RTL by setting the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_EnableRtl) property to `true`. RTL affects layout direction but does not translate text; use localization to provide translated strings.

In the following example, the Color Picker is rendered in RTL mode with an Arabic locale configured at the app level.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfColorPicker EnableRtl="true"></SfColorPicker>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hjrRZRCkppyUgqmJ?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Right to Left in Blazor ColorPicker](./images/blazor-colorpicker-right-to-left.webp)" %}


## Rendering palette at initial load

By default, the `Picker` view is shown initially. To display the palette view when opening the Color Picker popup, set the [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_Mode) property to `Palette`.

In the following example, the palette is displayed at initial load.

```cshtml
@using Syncfusion.Blazor.Inputs

<h4>Choose a color</h4>
<SfColorPicker Mode="ColorPickerMode.Palette"></SfColorPicker>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDhdZHiuJfEjVSHR?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Blazor ColorPicker with Palette](./images/blazor-colorpicker-with-palette.webp)" %}

## Color value in Blazor Color Picker Component

The [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_Value) property can be used to specify the color value to the Color Picker. It supports either `three` or `six` digit hex codes. To include `opacity`, set the color value as `four` or `eight` digit hex code.

In the following example, a 4-digit hex value is used, where the last digit represents the opacity.

```cshtml
@using Syncfusion.Blazor.Inputs

<h4>Choose a color</h4>
<SfColorPicker Value="035a" ModeSwitcher="false"></SfColorPicker>
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjBHjRskpzaPqqcU?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Changing Blazor ColorPicker value](./images/blazor-colorpicker-value.webp)" %}

N> The [Value](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_Value) property supports hex codes with or without the `#` prefix.


## Disable the Blazor Color Picker Component

Set the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_Disabled) property to `true` to disable the Color Picker. In the disabled state, the input and popup cannot receive focus or user interaction.

The following example shows the `Disabled` state of the Color Picker component.

```cshtml
@using Syncfusion.Blazor.Inputs

<h4>Choose a color</h4>
<SfColorPicker Disabled="true"></SfColorPicker>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VXhxZHCOpSNzTBZQ?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Disable State in Blazor ColorPicker](./images/blazor-colorpicker-disable-state.webp)" %}

## Hide control buttons in Blazor Color Picker Component

Render the Color Picker without control buttons (Apply/Cancel) by setting the [ShowButtons](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_ShowButtons) property to `false`.

```cshtml
@using Syncfusion.Blazor.Inputs

<h4>Choose a color</h4>
<SfColorPicker ShowButtons="false"></SfColorPicker>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BDhHtHiOpyWWBLFm?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Hide Control Buttons in Blazor ColorPicker](./images/blazor-colorpicker-hide-control.webp)" %}

## Show Recent color in Blazor Color Picker Component

The [ShowRecentColors](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_ShowRecentColors) property displays recently selected colors in the Color Picker when using palette mode. This feature helps users quickly reuse frequently chosen colors.

N> The [ShowRecentColors](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_ShowRecentColors) feature shows up to 10 recent colors as tiles and is available only in palette mode.

In the following sample, the [ShowRecentColors](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_ShowRecentColors) property is enabled to display recent colors in the palette area.

```cshtml
@using Syncfusion.Blazor.Inputs

<h4>Choose a color</h4>
<SfColorPicker ShowRecentColors="true"></SfColorPicker>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LZLHtxMuzoVXVRFv?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" backgroundimage "[Rendering Show Recent color in Blazor ColorPicker](./images/blazor-colorpicker-show-recent-color.webp)" %}
