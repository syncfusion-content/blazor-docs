---
layout: post
title: How to Disable Color Picker in Blazor Color Picker Component | Syncfusion
description: Checkout and learn about Disable Color Picker in Blazor Color Picker component of Syncfusion, and more details.
platform: Blazor
control: Color Picker
documentation: ug
---

# Disable Color Picker

To achieve disabled state in Color Picker, set the [`Disabled`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfColorPicker.html#Syncfusion_Blazor_Inputs_SfColorPicker_Disabled) property to `true`. The Color Picker pop-up cannot be accessed in disabled state.

The following example shows the `Disabled` state of Color Picker component.

```csharp
@using Syncfusion.Blazor.Inputs

<h4>Choose a color</h4>
<SfColorPicker Disabled="true"></SfColorPicker>
```

Output be like
![color-picker](./../images/disable.png)