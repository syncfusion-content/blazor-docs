---
layout: post
title: Change Syncfusion Blazor Toggle SwitchButton state using toggle method
description: Learn here all about changing button state using toggle method in Syncfusion Blazor Toggle Switch Button component and more.
platform: Blazor
control: Toggle Switch Button 
documentation: ug
---

# Change Blazor Toggle Switch Button state using toggle method

This section explains about how to toggle between the Toggle Switch Button states using [Toggle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSwitch-1.html) method.

```cshtml

@using Syncfusion.Blazor.Buttons

<SfSwitch @bind-Checked="isChecked" OffLabel="OFF" OnLabel="ON" Created="create" @ref="SwitchObj" TChecked="bool"></SfSwitch>

@code{
    private bool isChecked = false;
    SfSwitch<bool> SwitchObj;
    private void create(object obj)
    {
        //SwitchObj.Toggle();
    }
}

```

![Changing Blazor Toggle Switch Button State](./../images/blazor-toggle-switch-button-state.png)

N> Switch triggers [OnChange](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSwitch-1.html) event on every state stage to perform custom operations.