---
layout: post
title: How to Set Disabled State in Blazor Toggle Switch Button  Component | Syncfusion
description: Checkout and learn about Set Disabled State in Blazor Toggle Switch Button  component of Syncfusion, and more details.
platform: Blazor
control: Toggle Switch Button 
documentation: ug
---

# Set disabled state

Toggle Switch Button can be disabled by setting the [`Disabled`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSwitch-1.html) property to true.

The following example illustrates how to disable support in Toggle Switch Button component.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfSwitch Disabled="true" @bind-Checked="isChecked"></SfSwitch>

@code {
    private bool isChecked = false;
}

```

Output be like

![Switch Sample](./../images/switch-disabled.png)