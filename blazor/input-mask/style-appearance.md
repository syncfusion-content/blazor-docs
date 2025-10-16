---
layout: post
title: Style and appearance in Blazor Input Mask Component | Syncfusion
description: Checkout and learn here all about Style and appearance in Syncfusion Blazor Input Mask component and more.
platform: Blazor
control: Input Mask
documentation: ug
---

# Style and appearance in Blazor Input Mask Component

The following content provides the CSS selector patterns you can target to modify the control's appearance based on user preferences. The MaskedTextBox renders a wrapper element and an input element; styles can be applied to either. For scoped customization, assign a custom CssClass to the component and define styles for that class, or use CSS isolation (.razor.css). Refer to the SfMaskedTextBox CssClass API and the Themes and Appearance documentation for additional guidance.

## Customizing the appearance of Input Mask container element

Use the following CSS to customize the appearance of the Input Mask container (wrapper) and its input element.

```css
/* To specify height, font size, and border */
.e-input-group input.e-input, .e-input-group.e-control-wrapper input.e-input, .e-input-group textarea.e-input, .e-input-group.e-control-wrapper textarea.e-input {
        font-size: 20px;
        border-color: red;
        height: 40px;
        border: 2px solid;
  }
```

## Customizing the Input Mask element on hovering

Use the following CSS to customize the Input Mask element on hovering.

```css
/* To specify border */
.e-input-group input.e-input, .e-input-group input.e-input:hover:not(.e-success):not(.e-warning):not(.e-error):not([disabled]):not(:focus), .e-input-group.e-control-wrapper input.e-input,.e-input-group.e-control-wrapper input.e-input:hover:not(.e-success):not(.e-warning):not(.e-error):not([disabled]):no(:focus){
      border: 3px solid red;
}
```
