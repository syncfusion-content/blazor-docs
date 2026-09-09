---
layout: post
title: Background and Text Color in Blazor TextBox | Syncfusion
description: Customize Blazor TextBox background and text colors using custom CSS applied through the CssClass property.
platform: Blazor
control: TextBox
documentation: ug
---

# How to customize background and text color in Blazor TextBox

To customize the background and text color of the Blazor TextBox component, you can use custom CSS styles. Below are the steps to achieve this customization:

```cshtml
@using Syncfusion.Blazor.Inputs

<SfTextBox Placeholder='Name'></SfTextBox>

<style>
    .e-input-group input.e-input, .e-input-group.e-control-wrapper input.e-input, .e-float-input input, .e-float-input.e-control-wrapper input, .e-input-group textarea.e-input, .e-input-group.e-control-wrapper textarea.e-input, .e-float-input textarea, .e-float-input.e-control-wrapper textarea, .e-input-group .e-input[disabled], .e-input-group.e-control-wrapper .e-input[disabled], .e-input-group.e-disabled input.e-input, .e-input-group.e-control-wrapper.e-disabled input.e-input, .e-input-group.e-disabled textarea.e-input, .e-input-group.e-control-wrapper.e-disabled textarea.e-input {
        background-color: orange;
        color: white;
    }
</style>
```

N> Use custom CSS classes if you wish to apply the styles conditionally to specific Blazor TextBox components.