---
layout: post
title: How to change size in Blazor Toggle Switch Button | Syncfusion
description: Change Blazor Toggle Switch Button size to small using the e-small CSS class via the CssClass property.
platform: Blazor
control: Toggle Switch Button 
documentation: ug
---

# How to change size in Blazor Toggle Switch Button

The different Blazor Toggle Switch Button sizes available are default and small. To reduce the size of the default Blazor Toggle Switch Button to small, set the [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfInputBase-1.html#Syncfusion_Blazor_Buttons_SfInputBase_1_CssClass) property to `e-small`.

```cshtml
@using Syncfusion.Blazor.Buttons

<label for='switch1'>Checked</label>
<SfSwitch Id="switch1" CssClass="e-small" @bind-Checked="isSmallChecked"></SfSwitch>
<label for='switch2'>Unchecked</label>
<SfSwitch Id="switch2" @bind-Checked="isChecked"></SfSwitch>

@code {
    private bool isSmallChecked = true;
    private bool isChecked = false;
}

```

![Changing Size of Blazor Toggle Switch Button](./../images/blazor-toggle-switch-button-size.webp)