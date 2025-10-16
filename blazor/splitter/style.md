---
layout: post
title: Style and Appearance in Blazor Splitter Component | Syncfusion
description: Checkout and learn here all about style and appearance in Syncfusion Blazor Splitter component and more.
platform: Blazor
control: Splitter
documentation: ug
---

# Style and Appearance in Blazor Splitter Component

The following content provides the exact CSS structure that can be used to modify the control's appearance based on the user preference.

## Customizing the Split Bar

Use the following CSS to customize the split bar properties.

### Horizontal Split Bar

```css
/* default split bar color */
.e-splitter .e-split-bar.e-split-bar-horizontal{
   background: blue;
}

/* split bar color in hover and active state */
.e-splitter .e-split-bar.e-split-bar-horizontal.e-split-bar-hover,
.e-splitter .e-split-bar.e-split-bar-horizontal.e-split-bar-active {
   background: green;
}
```

### Vertical Split Bar

```css
/* default split bar color */
.e-splitter .e-split-bar.e-split-bar-vertical {
    background: blue;
}

/* split bar color in hover and active state */
.e-splitter .e-split-bar.e-split-bar-vertical.e-split-bar-hover,
.e-splitter .e-split-bar.e-split-bar-vertical.e-split-bar-active {
    background: green;
}
```

## Customizing the Split Bar Resize Handle

Use the following CSS to customize the split bar resize handle.

### Horizontal Split Bar Resize Handle

```css
/* default split bar resize handle color */
.e-splitter .e-split-bar.e-split-bar-horizontal .e-resize-handler {
    color: rgba(20, 27, 233, 0.54);
}

/* default split bar resize handle color in hover and active state */
.e-splitter .e-split-bar.e-split-bar-horizontal.e-split-bar-hover .e-resize-handler {
    color: green;
}
```

### Vertical Split Bar Resize Handle

```css
/* default split bar resize handle color */
.e-splitter .e-split-bar.e-split-bar-vertical .e-resize-handler {
    color: rgba(20, 27, 233, 0.54);
}

/* default split bar resize handle color in hover and active state */
.e-splitter .e-split-bar.e-split-bar-vertical.e-split-bar-hover .e-resize-handler {
    color: green;
}
```

## Customizing the Split Bar Arrows

Use the following CSS to customize the split bar arrows.

### Horizontal Split Bar Resize Arrows

```css
/* split bar arrows */
.e-splitter .e-split-bar.e-split-bar-horizontal.e-split-bar-hover .e-navigate-arrow.e-arrow-left::before, .e-splitter .e-split-bar.e-split-bar-horizontal.e-split-bar-active .e-navigate-arrow.e-arrow-left::before, .e-splitter .e-split-bar.e-split-bar-horizontal.e-split-bar-hover .e-navigate-arrow.e-arrow-left::after, .e-splitter .e-split-bar.e-split-bar-horizontal.e-split-bar-active .e-navigate-arrow.e-arrow-left::after, .e-splitter .e-split-bar.e-split-bar-horizontal.e-split-bar-hover .e-navigate-arrow.e-arrow-right::before, .e-splitter .e-split-bar.e-split-bar-horizontal.e-split-bar-active .e-navigate-arrow.e-arrow-right::before, .e-splitter .e-split-bar.e-split-bar-horizontal.e-split-bar-hover .e-navigate-arrow.e-arrow-right::after, .e-splitter .e-split-bar.e-split-bar-horizontal.e-split-bar-active .e-navigate-arrow.e-arrow-right::after {
    background-color: green;
}

/* split bar arrows - circular border */
.e-splitter .e-split-bar.e-split-bar-horizontal.e-split-bar-hover .e-navigate-arrow.e-arrow-left, .e-splitter .e-split-bar.e-split-bar-horizontal.e-split-bar-hover .e-navigate-arrow.e-arrow-right {
    border-color: rgba(33, 227, 22, 0.5);
}
```

### Vertical Split Bar Resize Arrows

```css
/* split bar arrows */
.e-splitter .e-split-bar.e-split-bar-vertical.e-split-bar-hover .e-navigate-arrow.e-arrow-up::before, .e-splitter .e-split-bar.e-split-bar-vertical.e-split-bar-active .e-navigate-arrow.e-arrow-up::before, .e-splitter .e-split-bar.e-split-bar-vertical.e-split-bar-hover .e-navigate-arrow.e-arrow-up::after, .e-splitter .e-split-bar.e-split-bar-vertical.e-split-bar-active .e-navigate-arrow.e-arrow-up::after, .e-splitter .e-split-bar.e-split-bar-vertical.e-split-bar-hover .e-navigate-arrow.e-arrow-down::before, .e-splitter .e-split-bar.e-split-bar-vertical.e-split-bar-active .e-navigate-arrow.e-arrow-down::before, .e-splitter .e-split-bar.e-split-bar-vertical.e-split-bar-hover .e-navigate-arrow.e-arrow-down::after, .e-splitter .e-split-bar.e-split-bar-vertical.e-split-bar-active .e-navigate-arrow.e-arrow-down::after {
    background-color: green;
}

/* split bar arrows - circular border */
.e-splitter .e-split-bar.e-split-bar-vertical.e-split-bar-hover .e-navigate-arrow.e-arrow-up, .e-splitter .e-split-bar.e-split-bar-vertical.e-split-bar-hover .e-navigate-arrow.e-arrow-down {
    border-color: rgba(33, 227, 22, 0.5);
}
```

## Hide the Resize Handle in Splitter

Use the following CSS to hide the resize handler in the split bar

### Hide the Horizontal Split Bar Resize Arrow

```CSS
.e-splitter .e-split-bar.e-split-bar-horizontal .e-resize-handler {
    display: none;
}
```

### Hide the Vertical Split Bar Resize Arrow

```CSS
.e-splitter .e-split-bar.e-split-bar-vertical .e-resize-handler {
    display: none;
}
```