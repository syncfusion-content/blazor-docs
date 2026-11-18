---
layout: post
title: How to set the rounded corner in Blazor TextBox | Syncfusion
description: Apply rounded corners to Blazor TextBox using a custom CSS class applied through the CssClass property.
platform: Blazor
control: TextBox
documentation: ug
---

# How to set the rounded corner in Blazor TextBox

Render the Blazor TextBox with rounded corners by applying a custom CSS class via the component’s [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox_CssClass) property and styling the input wrapper.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Placeholder='First Name' CssClass="e-corner"></SfTextBox>
<style>
    .e-input-group.e-corner {
        border-radius: 4px;
    }
</style>
```