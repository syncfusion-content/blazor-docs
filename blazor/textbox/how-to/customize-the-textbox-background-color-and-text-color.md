---
layout: post
title: Customize the Background & Text Color in Blazor TextBox | Syncfusion
description: Learn here all about customizing the TextBox Background Color and Text Color in Syncfusion Blazor TextBox component and more.
platform: Blazor
control: TextBox
documentation: ug
---

# Customize background and text color in Blazor TextBox component

To customize the background and text color of the Blazor TextBox component, you can use custom CSS styles along with the Syncfusion Blazor TextBox component. Below are the steps to achieve this customization:

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

N> Use custom CSS classes if you wish to apply the styles conditionally to specific TextBox components.