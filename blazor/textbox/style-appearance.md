---
layout: post
title: Style and appearance in Blazor TextBox Component | Syncfusion
description: Checkout and learn here all about Style and appearance in Syncfusion Blazor TextBox component and more.
platform: Blazor
control: TextBox
documentation: ug
---

# Style and appearance in Blazor TextBox Component

The following content provides the exact CSS structure that can be used to modify the control's appearance based on the user preference.

## Customizing the appearance of TextBox container element

Use the following CSS to customize the appearance of TextBox container element.

```css
/* To specify height and font size */
.e-input:not(:valid), .e-input:valid, .e-float-input.e-control-wrapper input:not(:valid), .e-float-input.e-control-wrapper input:valid, .e-float-input input:not(:valid), .e-float-input input:valid, .e-input-group input:not(:valid), .e-input-group input:valid, .e-input-group.e-control-wrapper input:not(:valid), .e-input-group.e-control-wrapper input:valid, .e-float-input.e-control-wrapper textarea:not(:valid), .e-float-input.e-control-wrapper textarea:valid, .e-float-input textarea:not(:valid), .e-float-input textarea:valid, .e-input-group.e-control-wrapper textarea:not(:valid), .e-input-group.e-control-wrapper textarea:valid, .e-input-group textarea:not(:valid), .e-input-group textarea:valid {
        font-size: 30px;
        height: 40px;
}
```

## Customizing the TextBox placeholder

Use the following CSS to customize the TextBox placeholder

```css
/* To specify font size and color */
.e-float-input.e-control-wrapper:not(.e-error) input:valid ~ label.e-float-text, .e-float-input.e-control-wrapper:not(.e-error) input ~ label.e-label-top.e-float-text {
        color: #343a40;
        font-size: 15px;
}
```

## See also

* [Adding icons to the Textbox](https://blazor.syncfusion.com/documentation/textbox/getting-started#adding-icons-to-the-textbox)
* [Customize the Floating Label Color of the TextBox](https://blazor.syncfusion.com/documentation/textbox/how-to/change-the-floating-label-color-of-the-textbox)
* [Customize the Color of the Text Based on its Value](https://blazor.syncfusion.com/documentation/textbox/how-to/change-the-color-of-the-textbox-based-on-its-value)
* [Customize the Background and Text Color in TextBox](https://blazor.syncfusion.com/documentation/textbox/how-to/customize-the-textbox-background-color-and-text-color)
