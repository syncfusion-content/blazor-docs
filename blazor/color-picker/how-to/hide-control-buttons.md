---
layout: post
title: Hide control buttons in Blazor Color Picker Component | Syncfusion
description: Checkout and learn here all about Hide control buttons in Syncfusion Blazor Color Picker component and more.
platform: Blazor
control: Color Picker
documentation: ug
---

# Hide control buttons in Blazor Color Picker Component

Color Picker can be rendered without control buttons (Apply/Cancel). In this case, while selecting a color, the Color Picker pop-up is closed and selected color can be applied directly. To hide control buttons, set the [ShowButtons](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_ShowButtons) property to `false`.

```cshtml
@using Syncfusion.Blazor.Inputs

<h4>Choose a color</h4>
<SfColorPicker ShowButtons="false"></SfColorPicker>
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hDhAWLBcqoIBqnae?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Hide Control Buttons in Blazor ColorPicker](./../images/blazor-colorpicker-hide-control.png)" %}