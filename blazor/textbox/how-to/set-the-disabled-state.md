---
layout: post
title: Set the Disabled State in Blazor TextBox Component | Syncfusion
description: Checkout and learn here all about how to set the disabled state in Syncfusion Blazor TextBox component and more.
platform: Blazor
control: TextBox
documentation: ug
---

# Set the Disabled State in Blazor TextBox Component

Disable the TextBox by setting its [Enabled](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfInputTextBase-1.html#Syncfusion_Blazor_Inputs_SfInputTextBase_1_Enabled) property to `false`. A disabled TextBox is non-interactive, excluded from keyboard focus (tab order), and does not raise input events.

The following example demonstrates the TextBox in a disabled state.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Placeholder='First Name' Enabled="false"></SfTextBox>
```

![Blazor TextBox in Disabled State](../images/blazor-textbox-disable-state.png)