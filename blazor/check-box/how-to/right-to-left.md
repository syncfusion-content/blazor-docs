---
layout: post
title: Right-To-Left in Blazor CheckBox Component | Syncfusion
description: Learn here all about Right-To-Left in Syncfusion Blazor CheckBox component and more.
platform: Blazor
control: Checkbox
documentation: ug
---

# Right-To-Left in Blazor CheckBox Component

Checkbox component has RTL support. This can be achieved by setting [`EnableRtl`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfCheckBox-1.html) as `true`.

The following example illustrates how to enable right-to-left support in Checkbox component.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfCheckBox Label="Default" @bind-Checked="isChecked" EnableRtl="true"></SfCheckBox>

@code {
    private bool isChecked = true;
}

```

Output be like

![Button Sample](./../images/cb-rtl.png)