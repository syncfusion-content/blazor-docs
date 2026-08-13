---
layout: post
title: Change Blazor Toggle SwitchButton state | Syncfusion®
description: Learn here all about changing button state using toggle method in Blazor Toggle Switch Button component and more.
platform: Blazor
control: Toggle Switch Button 
documentation: ug
---

# Change Blazor Toggle Switch Button state

This section explains how to programmatically toggle the state of the Toggle Switch Button by flipping the value bound to the [Checked](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfInputBase-1.html#Syncfusion_Blazor_Buttons_SfInputBase_1_Checked) property.

```cshtml

@using Syncfusion.Blazor.Buttons

<SfSwitch @bind-Checked="isChecked" OffLabel="OFF" OnLabel="ON" TChecked="bool"></SfSwitch>
<br />
<SfButton Content="Toggle Switch State" OnClick="ToggleState"></SfButton>

@code{
    private bool isChecked = false;
    private void ToggleState()
    {
        isChecked = !isChecked;
    }
}

```

![Changing Blazor Toggle Switch Button State](./../images/blazor-toggle-switch-button-state.webp)

N> The Switch triggers the [ValueChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSwitch-1.html#Syncfusion_Blazor_Buttons_SfSwitch_1_ValueChange) event on every state change to perform custom operations.