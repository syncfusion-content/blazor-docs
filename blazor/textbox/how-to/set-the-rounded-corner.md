---
layout: post
title: Set the Rounded Corner in Blazor TextBox Component | Syncfusion
description: Checkout and learn here all about how to set the rounded corner in Syncfusion Blazor TextBox component and more.
platform: Blazor
control: TextBox
documentation: ug
---

# Set the Rounded Corner in Blazor TextBox Component

Render the TextBox with rounded corners by applying a custom CSS class via the component’s [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfTextBox.html#Syncfusion_Blazor_Inputs_SfTextBox_CssClass) property and styling the input wrapper.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Placeholder='First Name' CssClass="e-corner"></SfTextBox>
<style>
    .e-input-group.e-corner {
        border-radius: 4px;
    }
</style>
```