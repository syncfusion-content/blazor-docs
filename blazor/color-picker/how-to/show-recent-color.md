---
layout: post
title: Show Recent color in Blazor Color Picker Component | Syncfusion
description: Checkout and learn here all about Show Recent color in Syncfusion Blazor Color Picker component and more.
platform: Blazor
control: Color Picker
documentation: ug
---

# Show Recent color in Blazor Color Picker Component

The [showRecentColors](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_ShowRecentColors) property enables the display of recently selected colors in the ColorPicker when in palette mode. This feature helps users quickly access their most frequently used colors.

>Note: The [`showRecentColors`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_ShowRecentColors) feature displays up to 10 recent colors as tiles and is available only in `palette` mode.

In the following sample, the [`showRecentColors`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_ShowRecentColors) property is enabled to display recent colors in the `palette` area.

```cshtml
@using Syncfusion.Blazor.Inputs

<h4>Choose a color</h4>
<SfColorPicker ShowRecentColors="true"></SfColorPicker>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LtLKiLLGUoxTFJzx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Rendering Show Recent color in Blazor ColorPicker](./../images/blazor-colorpicker-with-palette-alone.png)