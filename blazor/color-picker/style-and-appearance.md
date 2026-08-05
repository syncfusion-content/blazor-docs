---
layout: post
title: Styles and Appearances in Blazor Color Picker Component | Syncfusion®
description: Checkout and learn here all the features about Styles and Appearances in Blazor Color Picker component and much more.
platform: Blazor
control: Color Picker
documentation: ug
---

# Styles and Appearances in Blazor Color Picker Component

Customize the Color Picker appearance by overriding its default CSS. The following table lists the key CSS classes and the corresponding UI sections in the Color Picker. For broader, theme-level changes, create a custom theme using [Theme Studio](https://blazor.syncfusion.com/themestudio/?theme=material).

## CSS classes

| CSS Class | Purpose of Class |
| --- | --- |
| `.e-colorpicker-popup .e-container .e-handler` | Customizes the Color Picker selection handler. |
| `.e-colorpicker-popup .e-container.e-color-picker` | Customizes the Color Picker container. |
| `.e-colorpicker-popup .e-container .e-palette .e-tile` | Customizes the Color Picker palette item. |
| `.e-colorpicker-popup .e-container .e-switch-ctrl-btn` | Customizes the Color Picker switch control. |
| `.e-colorpicker-popup .e-container .e-slider-preview` | Customizes the Color Picker slider control. |

## Applying custom CSS

To apply custom styles, add a CSS file to your Blazor project and link it after the Syncfusion theme stylesheet so that your rules take precedence. For example, place the required rules in `wwwroot/css/color-picker.css` and reference the file of the project.

```html
<link rel="stylesheet" href="css/color-picker.css" />
```

The following example shows how to change the selection handler size, the tile border radius, and the switch control background using the CSS classes listed above.

```css
/* filepath: wwwroot/css/color-picker.css */
/* Increase the size of the selection handler */
.e-colorpicker-popup .e-container .e-handler {
    height: 18px;
    width: 18px;
    border: 2px solid #ffffff;
    box-shadow: 0 0 0 1px #003366;
}

/* Round the palette tiles */
.e-colorpicker-popup .e-container .e-palette .e-tile {
    border-radius: 50%;
    margin: 2px;
}

/* Tint the switch control bar */
.e-colorpicker-popup .e-container .e-switch-ctrl-btn {
    background-color: #f5f5f5;
}
```

## See also

* [Blazor Color Picker Getting Started](https://blazor.syncfusion.com/documentation/color-picker/getting-started)
* [Blazor Color Picker Customizations](https://blazor.syncfusion.com/documentation/color-picker/how-to/customize-color-picker)
* [Syncfusion<sup style="font-size:70%">&reg;</sup> Theme Studio](https://blazor.syncfusion.com/themestudio/)