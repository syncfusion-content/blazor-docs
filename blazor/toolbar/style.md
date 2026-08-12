---
layout: post
title: Style and Appearance in Blazor Toolbar | Syncfusion
description: Customize Blazor Toolbar background, border, and item styles using CSS selectors and properties.
platform: Blazor
control: Toolbar
documentation: ug
---

# Style and Appearance in Blazor Toolbar

This document provides CSS structures for modifying the control’s appearance based on user preference. 

## Customizing the Toolbar

Use the following CSS to customize the Toolbar.

```CSS

.e-toolbar {
    border: 5px solid rgb(173, 255, 47);
}

```

## Customizing the Toolbar Items

Use the following CSS to customize the items of the Toolbar.

```CSS

 .e-toolbar .e-toolbar-item {
    background: #add8e6;
    border: 1px solid #5a70cc;
}

```

Use the following CSS to customize the button in the items of the Toolbar.

```CSS

.e-toolbar .e-tbar-btn {
    background: #add8e6;
    border: 1px solid #5a70cc;
}

```

## Customizing the Toolbar's Item Icon

Use the following CSS to customize the item icon of the Toolbar control.

```CSS

.e-toolbar .e-tbar-btn .e-icons {
    background: #185655;
    color: #d7f9d4;
}

```

## Customizing the Hover State of the Toolbar

Use the following CSS to customize the toolbar item when hovering.

```CSS

.e-toolbar .e-tbar-btn:hover {
    background: #c0e3a1;
    border: 1px solid green;
}

```

## Customizing the Selected Item of the Toolbar

Use the following CSS to customize the selected toolbar item.

```CSS

.e-toolbar .e-tbar-btn:focus {
    background: #add8e6;
    border: 1px solid #5a70cc;
}

```