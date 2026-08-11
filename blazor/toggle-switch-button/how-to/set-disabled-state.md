---
layout: post
title: How to set disabled state in Blazor Toggle Switch Button | Syncfusion
description: Disable Blazor Toggle Switch Button interaction by setting the Disabled property to true.
platform: Blazor
control: Toggle Switch Button 
documentation: ug
---

# How to set disabled state in Blazor Toggle Switch Button

The Toggle Switch Button can be disabled by setting the [Disabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfInputBase-1.html#Syncfusion_Blazor_Buttons_SfInputBase_1_Disabled) property to `true`.

The following example illustrates how to disable the Toggle Switch Button component.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfSwitch Disabled="true" @bind-Checked="isChecked"></SfSwitch>

@code {
    private bool isChecked = false;
}

```

![Blazor Toggle Switch Button in Disable State](./../images/blazor-toggle-switch-button-disable-state.webp)

## Toggle the disabled state dynamically

You can also toggle the disabled state at runtime by using two-way binding on the `Disabled` property. The following example shows how to enable or disable the Toggle Switch Button from a button click.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfSwitch Disabled="isDisabled" @bind-Checked="isChecked"></SfSwitch>
<SfButton Content="@(isDisabled ? "Enable" : "Disable")" OnClick="@(() => isDisabled = !isDisabled)"></SfButton>

@code {
    private bool isChecked = false;
    private bool isDisabled = false;
}

```

## See also

* [Accessibility in Blazor Toggle Switch Button](../accessibility.md)