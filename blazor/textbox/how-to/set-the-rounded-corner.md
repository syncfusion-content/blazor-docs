---
layout: post
title: Set the Rounded Corner in Blazor TextBox Component | Syncfusion
description: Checkout and learn here all about how to set the rounded corner in Syncfusion Blazor TextBox component and more.
platform: Blazor
control: TextBox
documentation: ug
---

# Set the Rounded Corner in Blazor TextBox Component

Render the TextBox with `rounded corner` by adding the `e-corner` class to the input parent element.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Placeholder='First Name' CssClass="e-corner"></SfTextBox>
<style>
    .e-input-group.e-corner {
        border-radius: 4px;
    }
</style>
```