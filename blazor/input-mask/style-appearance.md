---
layout: post
title: Style and Appearance in Blazor Input Mask | Syncfusion
description: Customize the appearance of Blazor Input Mask with CSS selectors for the input wrapper, hover states, and isolated styles.
platform: Blazor
control: Input Mask
documentation: ug
---

# Style and Appearance in Blazor Input Mask

The following sections describe the CSS selector patterns you can target to modify the control's appearance based on user preferences. The MaskedTextBox renders a wrapper element and an input element; styles can be applied to either. For scoped customization, assign a custom `CssClass` to the component and define styles for that class, or use CSS isolation (`.razor.css`). Refer to the [SfMaskedTextBox CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfMaskedTextBox.html#Syncfusion_Blazor_Inputs_SfMaskedTextBox_CssClass) API and the [Themes and Appearance](https://blazor.syncfusion.com/documentation/appearance/themes) documentation for additional guidance.

### Customizing with a custom CSS class

To scope the styling to a single instance, set the `CssClass` parameter and target that class in your stylesheet.

```cshtml
@using Syncfusion.Blazor.Inputs

<SfMaskedTextBox Mask="00000" CssClass="custom-mask" @bind-Value="@MaskValue"></SfMaskedTextBox>
```

```css
/* Scoped style for the custom CssClass */
.custom-mask.e-input-group input.e-input {
    font-size: 20px;
    border: 2px solid red;
}
```

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
/* To specify border on hover */
.e-input-group input.e-input,
.e-input-group input.e-input:hover:not(.e-success):not(.e-warning):not(.e-error):not([disabled]):not(:focus),
.e-input-group.e-control-wrapper input.e-input,
.e-input-group.e-control-wrapper input.e-input:hover:not(.e-success):not(.e-warning):not(.e-error):not([disabled]):not(:focus) {
    border: 3px solid red;
}
```

## Available CSS classes

| CSS Class | Description |
| --- | --- |
| `.e-input-group` | Wraps the MaskedTextBox input and adornments. |
| `.e-input-group .e-input` | The inner input element. |
| `.e-float-input` | Applied when `FloatLabelType` is used. |
| `.e-success` / `.e-warning` / `.e-error` | Validation states. |

## Customizing the focused state

Use the following CSS to customize the border color when the MaskedTextBox is focused.

```css
.e-input-group.e-control-wrapper input.e-input:focus,
.e-input-group input.e-input:focus {
    border-color: #2563eb;
    box-shadow: 0 0 0 2px rgba(37, 99, 235, 0.2);
}
```

## See also

* [Themes and Appearance](https://blazor.syncfusion.com/documentation/appearance/themes)
* [SfMaskedTextBox API reference](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfMaskedTextBox.html)
