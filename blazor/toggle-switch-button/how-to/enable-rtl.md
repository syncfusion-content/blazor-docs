---
layout: post
title: How to Enable Rtl in Blazor Toggle Switch Button  Component | Syncfusion
description: Checkout and learn about Enable Rtl in Blazor Toggle Switch Button  component of Syncfusion, and more details.
platform: Blazor
control: Toggle Switch Button 
documentation: ug
---

# Enable RTL

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