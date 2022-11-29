---
layout: post
title: Style and appearance in Blazor In-place Editor Component | Syncfusion
description: Checkout and learn here all about style and appearance in Syncfusion Blazor In-place Editor component and more.
platform: Blazor
control: In Place Editor 
documentation: ug
---

# Style and Appearance in Blazor In-place Editor Component

The following content provides the exact CSS structure that can be used to modify the control's appearance based on the user preference.

## Customizing the In-place Editor text

Use the following CSS to customize the default In-place Editor's text content properties like font-family, font-size, color and border bottom.

```css
/* To change color, font family and font size */
.e-inplaceeditor .e-editable-value-wrapper .e-editable-value {
    border-bottom: 2px dotted green;
    color: red;
    font-size: 12px;
    font-family: Segoe UI
}
```

## Customizing the In-place Editor action buttons

Use the following CSS to customize the default In-place Editor's action buttons.

```css
/* To change icon color for save button */
.e-inplaceeditor .e-editable-action-buttons .e-btn-save.e-icon-btn .e-btn-icon.e-icons,
.e-inplaceeditor-tip .e-editable-action-buttons .e-btn-save.e-icon-btn .e-btn-icon.e-icons{
    color: green;
}

/* To change icon color for cancel button */
.e-inplaceeditor .e-editable-action-buttons .e-btn-cancel.e-icon-btn .e-btn-icon.e-icons,  .e-inplaceeditor-tip .e-editable-action-buttons .e-btn-cancel.e-icon-btn .e-btn-icon.e-icons {
    color: red;
}

/* To change background color for save button */
.e-inplaceeditor .e-editable-action-buttons .e-btn-save.e-icon-btn,
.e-inplaceeditor-tip .e-editable-action-buttons .e-btn-save.e-icon-btn {
    background-color: antiquewhite;
}

/* To change background color for cancel button */
.e-inplaceeditor .e-editable-action-buttons .e-btn-cancel.e-icon-btn,
.e-inplaceeditor-tip .e-editable-action-buttons .e-btn-cancel.e-icon-btn {
    background-color: antiquewhite;
}
```