---
layout: post
title: Right-To-Left in Blazor CheckBox Component | Syncfusion
description: Checkout and learn here all about Right-To-Left in Syncfusion Blazor CheckBox component and much more.
platform: Blazor
control: Checkbox
documentation: ug
---

# Right-To-Left in Blazor CheckBox Component

Checkbox component has RTL support. This can be achieved by setting [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfCheckBox-1.html) as `true`.

The following example illustrates how to enable right-to-left support in Checkbox component.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfCheckBox Label="Default" @bind-Checked="isChecked" EnableRtl="true"></SfCheckBox>

@code {
    private bool isChecked = true;
}

```


![Right to Left in Blazor CheckBox](./../images/blazor-checkbox-right-to-left.png)