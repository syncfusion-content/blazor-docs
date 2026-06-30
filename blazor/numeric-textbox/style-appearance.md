---
layout: post
title: Style and appearance in Blazor Numeric TextBox Component | Syncfusion®
description: Learn how to customize the style and appearance of Blazor Numeric TextBox with CSS for container elements, icons, and visual polish.
platform: Blazor
control: Numeric TextBox
documentation: ug
---

# Style and appearance in Blazor Numeric TextBox Component

The following content provides the exact CSS structure that can be used to modify the control's appearance based on the user preference.

## Customizing the appearance of Numeric TextBox container element

Use the following CSS to customize the appearance of the Numeric TextBox container element. This example adjusts the input’s height and font size. Note that the selectors shown apply to all inputs using the same theme classes; scope them with a custom class or the .e-numeric root to limit the impact to specific instances.

```css
/* To specify height and font size */
.e-input-group input.e-input, .e-input-group.e-control-wrapper input.e-input, .e-input-group textarea.e-input, .e-input-group.e-control-wrapper textarea.e-input {

        height: 40px;
        font-size: 20px;
}
```

## Customizing the Numeric TextBox icons

Use the following CSS to customize the Numeric TextBox icons. This selector adjusts the size and background of the spin button icons; for finer control, target .e-spin-up and .e-spin-down individually. Ensure sufficient color contrast and preserve visible focus/hover states for accessibility.

```css
/* To specify font size and background color */
.e-numeric.e-control-wrapper.e-input-group .e-input-group-icon {
        font-size: 20px;
        background-color: beige;
}
```