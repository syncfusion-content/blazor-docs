---
layout: post
title: Style and appearance in Blazor Toast Component | Syncfusion
description: Check out and learn about style and appearance in Syncfusion Blazor Toast component.
platform: Blazor
control: Toast
documentation: ug
---

# Style and appearance in Blazor Toast Component

The following content provides the exact CSS structure that can be used to modify the control's appearance based on the user preference.

## Customizing the toast title

Use the following CSS to customize the toast title properties such as font family, font size, and color.

```css
/* To change color, font family and font size */
.e-toast-container .e-toast .e-toast-message .e-toast-title {
    color: red;
    font-size: 18px;
    font-weight: bold;
}
```

## Customizing the toast content

Use the following CSS to customize the toast content properties such as font family, font size, and color.

```css
/* To change color, font family and font size */
.e-toast-container .e-toast .e-toast-message .e-toast-content {
    color: aqua;
    font-size: 13px;
    font-weight: normal;
}
```

## Customizing the toast icon

Use the following CSS to customize the default toast icon color. Increase selector specificity or scope by ID if a theme rule takes precedence.

```css
/* To change icon color */
.e-toast-container .e-toast .e-toast-icon {
    color: yellow;
}
```

## Customizing the toast background

Use the following CSS to customize the toast background color. Consider contrast requirements for accessibility when choosing colors.

```css
/* To change background color */
.e-toast-container .e-toast {
    background-color: navy;
}
```