---
layout: post
title: Enable RTL in Blazor Toggle Switch Button Component | Syncfusion
description: Learn here all about Enable RTL in Syncfusion Blazor Toggle Switch Button component and more.
platform: Blazor
control: Toggle Switch Button 
documentation: ug
---

# Enable RTL in Blazor Toggle Switch Button Component

Toggle Switch Button component has RTL support. This can be achieved by setting [`EnableRtl`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSwitch-1.html) as `true`.

The following example illustrates how to enable right-to-left support in Toggle Switch Button component.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfSwitch EnableRtl="true" @bind-Checked="isCheked"></SfSwitch>

@code {
  private bool isChecked = false;
}

```

  Output be like

![Switch Sample](./../images/switch-rtl.png)