---
layout: post
title: Enable RTL in Blazor Toggle Switch Button Component | Syncfusion
description: Checkout and learn here all about how to enable RTL in Syncfusion Blazor Toggle Switch Button component and more.
platform: Blazor
control: Toggle Switch Button 
documentation: ug
---

# Enable RTL in Blazor Toggle Switch Button Component

Toggle Switch Button component has RTL support. This can be achieved by setting [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSwitch-1.html) as `true`.

The following example illustrates how to enable right-to-left support in Toggle Switch Button component.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfSwitch EnableRtl="true" @bind-Checked="isChecked"></SfSwitch>

@code {
  private bool isChecked = false;
}

```

![Right to Left in Blazor Toggle Switch Button](./../images/blazor-toggle-switch-button-in-right-to-left.png)