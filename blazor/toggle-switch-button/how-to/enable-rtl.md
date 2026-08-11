---
layout: post
title: How to enable RTL in Blazor Toggle Switch Button | Syncfusion
description: Enable right-to-left layout for Blazor Toggle Switch Button using the EnableRtl property.
platform: Blazor
control: Toggle Switch Button 
documentation: ug
---

# How to enable RTL in Blazor Toggle Switch Button

The Toggle Switch Button component supports right-to-left (RTL) layout. This can be achieved by setting the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfInputBase-1.html#Syncfusion_Blazor_Buttons_SfInputBase_1_EnableRtl) property to `true`.

The following example illustrates how to enable right-to-left support in the Toggle Switch Button component.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfSwitch EnableRtl="true" @bind-Checked="isChecked"></SfSwitch>

@code {
  private bool isChecked = false;
}

```

![Right to Left in Blazor Toggle Switch Button](./../images/blazor-toggle-switch-button-in-right-to-left.webp)

## See also

* [Accessibility in Blazor Toggle Switch Button](../accessibility.md)