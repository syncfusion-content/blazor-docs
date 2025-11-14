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

The `Localization` library allows you to localize default text content of the Color Picker. The Color Picker component has static text for control buttons (apply / cancel) and mode switcher that can be changed to other cultures (Arabic, Deutsch, French, etc.) by defining the locale value and translation object. You can refer [How to enable Localization in Blazor application](https://blazor.syncfusion.com/documentation/common/localization#how-to-enable-localization-in-blazor-application) page for the introduction and configuring the localization.

You can modify the default value in `.res` file added to Resource folder. Enter the key value (Locale Keywords) in the `Name` column and the translated string in the `Value` column. The following list of keys and their values are used in the Color Picker.

| **Locale key** | **en-US (default culture)** | **de (Deutsch culture)** |
| ------------ | ----------------------- | --------------------|
| `ColorPicker_Apply`  | `Apply` | `Anwenden` |
| `ColorPicker_Cancel`  | `Cancel` | `Abbrechen` |
| `ColorPicker_ModeSwitcher` | `Switch Mode` | `Modus wechseln` |

```cshtml

@using Syncfusion.Blazor.Inputs

<SfColorPicker></SfColorPicker>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LZhKsVVwqSUTjofI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Localization in Blazor ColorPicker](./images/blazor-colorpicker-localization.png)" %}

## RTL

Color Picker component has `RTL` support. It helps to render the Color Picker from right-to-left direction. It improves the user experiences and accessibility for users who use right-to-left languages(Arabic, Farsi, Urdu, etc). This can be achieved by setting the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_EnableRtl) property to true.

In the following example, Color Picker component is rendered in RTL mode with `arabic` locale.

```cshtml

@using Syncfusion.Blazor.Inputs

<SfColorPicker EnableRtl="true"></SfColorPicker>

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LZBUsrLmqSKnHwGP?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Right to Left in Blazor ColorPicker](./images/blazor-colorpicker-right-to-left.png)" %}