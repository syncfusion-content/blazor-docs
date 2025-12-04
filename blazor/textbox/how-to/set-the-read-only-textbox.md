---
layout: post
title: Set the Read-only TextBox in Blazor TextBox Component | Syncfusion
description: Checkout and learn here all about how to set the read-only TextBox in Syncfusion Blazor TextBox component and more.
platform: Blazor
control: TextBox
documentation: ug
---

# Set the Read-only TextBox in Blazor TextBox Component

Set the TextBox to read-only to prevent editing while still allowing focus and selection. This can be achieved using the [Readonly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox_Readonly) property.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Placeholder='First Name' Readonly=true></SfTextBox>
```

![Blazor TextBox in Readonly Mode](../images/blazor-textbox-disable-state.png)