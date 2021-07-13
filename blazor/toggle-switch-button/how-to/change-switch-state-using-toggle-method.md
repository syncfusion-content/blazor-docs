---
layout: post
title: How to Change Switch State Using Toggle Method in Blazor Toggle Switch Button  Component | Syncfusion
description: Checkout and learn about Change Switch State Using Toggle Method in Blazor Toggle Switch Button  component of Syncfusion, and more details.
platform: Blazor
control: Toggle Switch Button 
documentation: ug
---

# Change Toggle Switch Button state using toggle method

This section explains about how to toggle between the Toggle Switch Button states using [`Toggle`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSwitch-1.html) method.

```csharp

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

Output be like

![Switch Sample](./../images/switch-toggle.png)

> Switch triggers [`OnChange`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfSwitch-1.html) event on every state stage to perform custom operations.