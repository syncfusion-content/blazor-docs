---
layout: post
title: Right-To-Left in Blazor RadioButton Component | Syncfusion
description: Checkout and learn here all about Right-To-Left in Syncfusion Blazor RadioButton component and more.
platform: Blazor
control: Radio Button
documentation: ug
---

# Right-To-Left in Blazor RadioButton Component

The RadioButton component supports right-to-left (RTL) layout, Enable RTL by setting the [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Buttons.SfInputBase-1.html#Syncfusion_Blazor_Buttons_SfInputBase_1_EnableRtl) as `true`.

The following example illustrates enabling right-to-left support in the RadioButton component. RTL can also be configured globally for all Syncfusion components during service registration.

```cshtml
@using Syncfusion.Blazor.Buttons

<SfRadioButton Label="Default" EnableRtl="true" Value="Default" @bind-Checked="stringChecked"></SfRadioButton>

@code {
    private string stringChecked = "Default";
}

```

![Right to left in Blazor RadioButton](./../images/blazor-radiobutton-right-to-left.png)