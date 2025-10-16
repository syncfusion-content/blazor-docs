---
layout: post
title: Set disabled state in Blazor Toggle Switch Button | Syncfusion
description: Learn here all about how to set disabled state in Syncfusion Blazor Toggle Switch Button component and more.
platform: Blazor
control: Toggle Switch Button 
documentation: ug
---

# Set disabled state in Blazor Toggle Switch Button Component

Toggle Switch Button can be disabled by setting the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSwitch-1.html) property to `true`.

The following example illustrates how to disable the Toggle Switch Button component.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfSwitch Disabled="true" @bind-Checked="isChecked"></SfSwitch>

@code {
    private bool isChecked = false;
}

```

![Blazor Toggle Switch Button in disabled state](./../images/blazor-toggle-switch-button-disable-state.png)