---
layout: post
title: How to Change Size in Blazor Toggle Switch Button  Component | Syncfusion
description: Checkout and learn about Change Size in Blazor Toggle Switch Button  component of Syncfusion, and more details.
platform: Blazor
control: Toggle Switch Button 
documentation: ug
---

# Change Size

The different Toggle Switch Button sizes available are default and small. To reduce the size of default Toggle Switch Button to small,
set the [`CssClass`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSwitch-1.html) property to `e-small`.

```cshtml
@using Syncfusion.Blazor.Buttons

<label for='switch1'>Checked</label>
<SfSwitch CssClass="e-small" @bind-Checked="isSmallChecked"></SfSwitch>
<label for='switch2'>Unchecked</label>
<SfSwitch @bind-Checked="isChecked"></SfSwitch>

@code {
    private bool isSmallChecked = true;
    private bool isChecked = false;
}

```

Output be like

![Switch Sample](./../images/switch-size.png)