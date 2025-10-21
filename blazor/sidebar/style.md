---
layout: post
title: Styles and Appearance in Blazor Sidebar Component | Syncfusion
description: Checkout and learn here all about styles and appearance in Syncfusion Blazor Sidebar component and more.
platform: Blazor
control: Sidebar
documentation: ug
---

# Styles and Appearance in Blazor Sidebar Component

This section provides the CSS structure that can be used to modify the component's appearance based on user preferences.

## Customizing the Sidebar

Use the below CSS to customize the Sidebar root element.

```css

.e-sidebar {
    background: #898b2b
}

```

## Customizing the Sidebar based on the Positions

Use the below CSS to customize the left positioned sidebar.

```css

.e-sidebar.e-left {
    border-right: 2px solid red;
}

```

Use the below CSS to customize the right positioned sidebar.

```css

.e-sidebar.e-right {
    border-left: 2px solid red;
}

```

## Customizing the Sidebar based on the active state

Use the below CSS to customize the open state of the left positioned sidebar.

```css

.e-sidebar.e-left.e-open {
    transition: transform 2.5s ease;
}

```

Use the below CSS to customize the open state of the right positioned sidebar.

```css

.e-sidebar.e-right.e-open {
     transition: transform 2.5s ease;
}

```

Use the below CSS to customize the closed state of the left positioned sidebar.

```css

.e-sidebar.e-left.e-transition.e-close {
    transition: transform 2.5s ease, visibility 1200ms;
}

```

Use the below CSS to customize the closed state of the right positioned sidebar.

```css

.e-sidebar.e-right.e-transition.e-close {
    transition: transform 2.5s ease, visibility 1200ms;
}

```

## Customizing the Sidebar with Dock State

When the Dock support is enabled, the "e-dock" class will be added to the root element. Based on that class, all the above stated customization can also be done. Use the following CSS to customize the Sidebar element with a dock state.

```css

.e-sidebar.e-dock {
    background: #2d323e;
}

```

## Customizing the Different types of Sidebar

Use the below CSS to customize the auto type sidebar.

```css

.e-sidebar.e-left.e-auto {
    background-color: pink;
}

```

Use the below CSS to customize the push type sidebar.

```css

.e-sidebar.e-left.e-push {
    background-color: beige;
}

```

Use the below CSS to customize the over type sidebar.

```css

.e-sidebar.e-left.e-over {
    background-color: aqua;
}

```

Use the below CSS to customize the slide type sidebar.

```css

.e-sidebar.e-left.e-slide {
    background-color: green;
}

```

## Customizing the Backdrop of the Sidebar

Use the below CSS to customize the backdrop of the sidebar.

```css

.e-sidebar-overlay {
    background-color: aqua;
}

```

## Customizing the Sidebar in the RTL Direction

When the RTL (right to left direction) support is enabled, the "e-rtl" class will be added to the root element. Based on that class, all the above stated customization can also be done. Use the following CSS to customize the Sidebar element in the RTL (right to left direction) mode.

```css

.e-sidebar.e-left.e-rtl {
    background-color: antiquewhite;
}

```