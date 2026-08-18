---
layout: post
title: How to set the read-only TextBox in Blazor TextBox | Syncfusion
description: Set Blazor TextBox to read-only using the Readonly property while keeping focus and selection enabled.
platform: Blazor
control: TextBox
documentation: ug
---

# How to set the read-only TextBox in Blazor TextBox

Set the TextBox to read-only to prevent editing while still allowing focus and selection. This can be achieved using the [Readonly](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox_Readonly) property.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Placeholder='First Name' Readonly=true></SfTextBox>
```

![Blazor TextBox in Readonly Mode](../images/blazor-textbox-disable-state.webp)