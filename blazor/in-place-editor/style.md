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

To get started quickly with customizing the Blazor In-place Editor, watch the following video or explore the [GitHub](https://github.com/SyncfusionExamples/how-to-customize-the-blazor-in-place-editor-component) sample:

{% youtube "youtube:https://www.youtube.com/watch?v=YWRsFm32Rso"%}

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

## Customizing In-place editor outer style like material filled

Use the following CSS to customize the In-place editor outer style like material filled text fields.

```css
/* To remove the default bottom underline */
.e-inplaceeditor .e-editable-value-container .e-editable-value {
    border-bottom: none;
}
/* To change background color and border radius of in-place editor container */
.e-inplaceeditor .e-editable-value-container {
    background: #e9ecef;
    border-radius: 4px;
}
/* To show the edit icon */
.e-inplaceeditor .e-editable-value-container .e-editable-overlay-icon {
    visibility: visible;
}

```

![Blazor In-place Editor outer style like material filled](./images/outer-style-like-material-filled.png)
