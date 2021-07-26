---
layout: post
title: How to Set The Rounded Corner in Blazor TextBox Component | Syncfusion
description: Checkout and learn about Set The Rounded Corner in Blazor TextBox component of Syncfusion, and more details.
platform: Blazor
control: TextBox
documentation: ug
---

# Set the rounded corner

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