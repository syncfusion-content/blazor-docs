---
layout: post
title: How to Hide Control Buttons in Blazor Color Picker Component | Syncfusion
description: Checkout and learn about Hide Control Buttons in Blazor Color Picker component of Syncfusion, and more details.
platform: Blazor
control: Color Picker
documentation: ug
---

# Hide control buttons

Color Picker can be rendered without control buttons (Apply/Cancel). In this case, while selecting a color, the
Color Picker pop-up is closed and selected color can be applied directly. To hide control buttons, set the [`ShowButtons`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_ShowButtons) property to `false`.

```cshtml
@using Syncfusion.Blazor.Inputs

<h4>Choose a color</h4>
<SfColorPicker ShowButtons="false"></SfColorPicker>
```

Output be like
![color-picker](./../images/hide-control.png)