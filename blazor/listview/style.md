---
layout: post
title: CSS Structure in Blazor ListView Component | Syncfusion®
description: Checkout and learn here all the features about CSS Structure in Blazor ListView component and much more details.
platform: Blazor
control: Listview
documentation: ug
---

# Styles and Appearances in Blazor ListView Component

Customize the appearance of the ListView by overriding the component's default CSS. The following table lists commonly used CSS selectors and the corresponding UI areas they affect. For consistent theming across applications, consider generating a custom theme with [Theme Studio](https://blazor.syncfusion.com/themestudio/?theme=material).

| CSS Class | Purpose of Class |
| ----- | ----- |
| .e-listview | Customize the ListView container. |
| .e-listview .e-list-item | Customize the ListView list item. |
| .e-listview .e-list-header | Customize the ListView header. |
| .e-listview .e-list-group-item | Customize the ListView group header item. |
| .e-listview .e-list-text | Customize the ListView item text. |
| .e-listview .e-text-content | Customize the ListView text content wrapper. |
| .e-listview .e-list-item.e-selected | Customize the selected ListView item. |
| .e-listview .e-list-item.e-hover | Customize the ListView item hover state. |
| .e-listview .e-list-item.e-focused | Customize the ListView focused item. |
| .e-listview .e-list-item.e-checklist | Customize the ListView checklist item. |

## ListView Container Customization

The outermost wrapper rendered by `ListView` carries the `.e-listview` class. Override its `background`, `border`, and `border-radius` to control the overall surface of the component.

```css
.e-listview {
    background-color: #f5f7fb;
    border: 1px solid #c3cad6;
    border-radius: 10px;
}
```

## List Container Customization

The inner container that holds the list items uses `.e-list-container`. Adjust its background, padding, and border to control the breathing room around the list.

```css
.e-listview .e-list-container {
    background-color: #ffffff;
    border: 1px solid #d6dce5;
    padding: 8px 12px;
}
```

## List Item Customization

Each list item is wrapped in `.e-list-item`. Override its background, border, and padding to give each item a distinct card-like appearance.

```css
.e-listview .e-list-item {
    background-color: #ffffff;
    border: 1px solid #d6dce5;
    border-radius: 4px;
    padding: 10px 12px;
}

.e-listview .e-list-item:hover {
    background-color: #eef2f7;
    border-color: #0d6efd;
}
```

## List Item Text Customization

The text content inside each list item uses `.e-list-text`. Style the font, color, and size to customize the text appearance.

```css
.e-listview .e-list-text {
    color: #2c547b;
    font-size: 14px;
    font-weight: 500;
}

.e-listview .e-list-item:hover .e-list-text {
    color: #0d6efd;
}
```

## List Header Customization

The header of the ListView component uses `.e-list-header`. Override its background, border, and padding to customize the header appearance.

```css
.e-listview .e-list-header {
    background-color: #eef2f7;
    border-bottom: 1px solid #d6dce5;
    padding: 12px 16px;
    color: #2c547b;
    font-weight: 600;
}
```

## Group Header Customization

The group header in a grouped ListView carries the `.e-list-group-item` class. Override its background, border, and padding to give each group header a distinct appearance.

```css
.e-listview .e-list-group-item {
    background-color: #eef2f7;
    border: 1px solid #d6dce5;
    border-radius: 4px;
    padding: 10px 12px;
}
```

## Group Header Text Customization

The text content inside each group header uses `.e-list-text`. Style the font, color, and size to customize the group header text appearance.

```css
.e-listview .e-list-group-item .e-list-text {
    color: #2c547b;
    font-size: 14px;
    font-weight: 600;
    text-transform: uppercase;
}
```

## Group Header Hover Customization

Override the group header hover state to customize the appearance when hovering over group headers.

```css
.e-listview .e-list-group-item:hover {
    background-color: #dce4ed;
    border-color: #0d6efd;
}

.e-listview .e-list-group-item:hover .e-list-text {
    color: #0d6efd;
}
```

## Nested Group Header Customization

For nested or hierarchical group headers, qualify the selector with `.e-level-2` to apply specific styling at different levels.

```css
.e-listview .e-list-group-item.e-level-2 {
    background-color: #f5f7fb;
    padding-left: 24px;
}

.e-listview .e-list-group-item.e-level-2 .e-list-text {
    font-size: 13px;
    color: #495057;
}
```

## Group Item Separator Customization

The separator between groups can be customized using the `::after` pseudo-element of the group container.

```css
.e-listview .e-list-group-item::after {
    border-bottom: 2px solid #0d6efd;
    display: block;
    content: "";
    margin-top: 8px;
}
```

## List Item Selection Customization

The selected list item carries the `.e-selected` class. Override its background and text color to customize the selected state.

```css
.e-listview .e-list-item.e-selected {
    background-color: #0d6efd;
    border-color: #0d6efd;
    color: #ffffff;
}

.e-listview .e-list-item.e-selected .e-list-text {
    color: #ffffff;
}
```

## List Item Hover State Customization

Override the list item hover state to customize the appearance when hovering over list items.

```css
.e-listview .e-list-item.e-hover {
    background-color: #eef2f7;
    border-color: #0d6efd;
}

.e-listview .e-list-item.e-hover .e-list-text {
    color: #0d6efd;
}
```

## List Item Focused State Customization

The focused list item carries the `.e-focused` class. Override its background and text color to customize the focused state.

```css
.e-listview .e-list-item.e-focused {
    background-color: #0d6efd;
    border-color: #0d6efd;
    color: #ffffff;
}

.e-listview .e-list-item.e-focused .e-list-text {
    color: #ffffff;
}
```

## Checklist Item Hover State Customization

Customize the list item when hovering with the checkbox checked using the `.e-hover.e-active.e-checklist` class combination.

```css
.e-listview .e-list-item.e-hover.e-active.e-checklist {
    background-color: #eef2f7;
    border-color: #0d6efd;
    color: #2c547b;
}
```

## Checklist Item Selection Customization

Customize the selected list item with the checkbox checked using the `.e-checklist.e-focused.e-active` class combination.

```css
.e-listview .e-list-item.e-checklist.e-focused.e-active {
    background-color: #0d6efd;
    border-color: #0d6efd;
    color: #ffffff;
}
```

## Text Content Wrapper Customization

The `.e-text-content` wrapper holds the text. Adjust its display, alignment, and padding to control the layout of content within each list item.

```css
.e-listview .e-text-content {
    display: flex;
    align-items: center;
    padding: 4px 8px;
}
```

## Group Items vs Regular Items Differentiation

Differentiate group header items from regular list items using the `.e-list-group-item` class.

```css
.e-listview .e-list-item {
    background-color: #ffffff;
    border: 1px solid #d6dce5;
    border-radius: 4px;
    padding: 10px 12px;
}

.e-listview .e-list-group-item {
    background-color: #eef2f7;
    border: 1px solid #d6dce5;
    border-radius: 4px;
    padding: 10px 12px;
    font-weight: 600;
}
```

## ListView Container Customization

The outermost wrapper rendered by `ListView` carries the `.e-listview` class. Override its `background`, `border`, and `border-radius` to control the overall surface of the component.

```css
.e-listview {
    background-color: #f5f7fb;
    border: 1px solid #c3cad6;
    border-radius: 10px;
}
```

## List Container Customization

The inner container that holds the list items uses `.e-list-container`. Adjust its background, padding, and border to control the breathing room around the list.

```css
.e-listview .e-list-container {
    background-color: #ffffff;
    border: 1px solid #d6dce5;
    padding: 8px 12px;
}
```

## Group Header Customization

The group header in a grouped ListView carries the `.e-list-group-item` class. Override its background, border, and padding to give each group header a distinct appearance.

```css
.e-listview .e-list-group-item {
    background-color: #eef2f7;
    border: 1px solid #d6dce5;
    border-radius: 4px;
    padding: 10px 12px;
}
```

## Group Header Text Customization

The text content inside each group header uses `.e-list-text`. Style the font, color, and size to customize the group header text appearance.

```css
.e-listview .e-list-group-item .e-list-text {
    color: #2c547b;
    font-size: 14px;
    font-weight: 600;
    text-transform: uppercase;
}
```

## Group Header Hover Customization

Override the group header hover state to customize the appearance when hovering over group headers.

```css
.e-listview .e-list-group-item:hover {
    background-color: #dce4ed;
    border-color: #0d6efd;
}

.e-listview .e-list-group-item:hover .e-list-text {
    color: #0d6efd;
}
```

## Nested Group Header Customization

For nested or hierarchical group headers, qualify the selector with `.e-level-2` to apply specific styling at different levels.

```css
.e-listview .e-list-group-item.e-level-2 {
    background-color: #f5f7fb;
    padding-left: 24px;
}

.e-listview .e-list-group-item.e-level-2 .e-list-text {
    font-size: 13px;
    color: #495057;
}
```

## Group Item Separator Customization

The separator between groups can be customized using the `::after` pseudo-element of the group container.

```css
.e-listview .e-list-group-item::after {
    border-bottom: 2px solid #0d6efd;
    display: block;
    content: "";
    margin-top: 8px;
}
```

## Group Items vs Regular Items Differentiation

Differentiate group header items from regular list items using the `.e-list-group-item` class.

```css
.e-listview .e-list-item {
    background-color: #ffffff;
    border: 1px solid #d6dce5;
    border-radius: 4px;
    padding: 10px 12px;
}

.e-listview .e-list-group-item {
    background-color: #eef2f7;
    border: 1px solid #d6dce5;
    border-radius: 4px;
    padding: 10px 12px;
    font-weight: 600;
}
```
## Group Header Customization

The group header in a grouped ListView carries the `.e-list-group-item` class. Override its background, border, and padding to give each group header a distinct appearance.

```css
.e-listview .e-list-group-item {
    background-color: #eef2f7;
    border: 1px solid #d6dce5;
    border-radius: 4px;
    padding: 10px 12px;
}
```

## Group Header Text Customization

The text content inside each group header uses `.e-list-text`. Style the font, color, and size to customize the group header text appearance.

```css
.e-listview .e-list-group-item .e-list-text {
    color: #2c547b;
    font-size: 14px;
    font-weight: 600;
    text-transform: uppercase;
}
```

## Group Header Hover Customization

Override the group header hover state to customize the appearance when hovering over group headers.

```css
.e-listview .e-list-group-item:hover {
    background-color: #dce4ed;
    border-color: #0d6efd;
}

.e-listview .e-list-group-item:hover .e-list-text {
    color: #0d6efd;
}
```

## Nested Group Header Customization

For nested or hierarchical group headers, qualify the selector with `.e-level-2` to apply specific styling at different levels.

```css
.e-listview .e-list-group-item.e-level-2 {
    background-color: #f5f7fb;
    padding-left: 24px;
}

.e-listview .e-list-group-item.e-level-2 .e-list-text {
    font-size: 13px;
    color: #495057;
}
```

## Group Container Customization

The container that holds grouped items uses `.e-list-container`. Adjust its background and padding to control the overall group appearance.

```css
.e-listview .e-list-container {
    background-color: #ffffff;
    border: 1px solid #d6dce5;
    padding: 8px 12px;
}
```

## Group Item Separator Customization

The separator between groups can be customized using the `::after` pseudo-element of the group container.

```css
.e-listview .e-list-group-item::after {
    border-bottom: 2px solid #0d6efd;
    display: block;
    content: "";
    margin-top: 8px;
}
```

## Group Items vs Regular Items Differentiation

Differentiate group header items from regular list items using the `.e-list-group-item` class.

```css
.e-listview .e-list-item {
    background-color: #ffffff;
    border: 1px solid #d6dce5;
    border-radius: 4px;
    padding: 10px 12px;
}

.e-listview .e-list-group-item {
    background-color: #eef2f7;
    border: 1px solid #d6dce5;
    border-radius: 4px;
    padding: 10px 12px;
    font-weight: 600;
}
```

## ListView Container Customization

The outermost wrapper rendered by `ListView` carries the `.e-listview` class. Override its `background`, `border`, and `border-radius` to control the overall surface of the component.

```css
.e-listview {
    background-color: #f5f7fb;
    border: 1px solid #c3cad6;
    border-radius: 10px;
}
```

## List Item Customization

Each list item is wrapped in `.e-list-item`. Override its background, border, and padding to give each item a distinct card-like appearance.

```css
.e-listview .e-list-item {
    background-color: #ffffff;
    border: 1px solid #d6dce5;
    border-radius: 4px;
    padding: 10px 12px;
}

.e-listview .e-list-item:hover {
    background-color: #eef2f7;
    border-color: #0d6efd;
}
```

## List Item Text Customization

The text content inside each list item uses `.e-list-text`. Style the font, color, and size to customize the text appearance.

```css
.e-listview .e-list-text {
    color: #2c547b;
    font-size: 14px;
    font-weight: 500;
}

.e-listview .e-list-item:hover .e-list-text {
    color: #0d6efd;
}
```

## List Item Selection Customization

The selected list item carries the `.e-selected` class. Override its background and text color to customize the selected state.

```css
.e-listview .e-list-item.e-selected {
    background-color: #0d6efd;
    border-color: #0d6efd;
    color: #ffffff;
}

.e-listview .e-list-item.e-selected .e-list-text {
    color: #ffffff;
}
```

## Text Content Wrapper Customization

The `.e-text-content` wrapper holds the text. Adjust its display, alignment, and padding to control the layout of content within each list item.

```css
.e-listview .e-text-content {
    display: flex;
    align-items: center;
    padding: 4px 8px;
}
```

## Customizing ListView hover state with the checkbox checked

```CSS

.e-listview .e-list-item.e-hover.e-active.e-checklist {
    color: rgb(83, 5, 79);
    background-color: rgb(173, 255, 47);
}

```

## Customizing ListView hover state

```CSS

.e-listview .e-list-item.e-hover {
    color:red;
    background-color: rgb(173, 255, 47);
}

```

## Customizing ListView's selected item with the checkbox checked

```CSS

.e-listview .e-list-item.e-checklist.e-focused.e-active {
    color: rgb(83, 5, 79);
    background-color: rgb(0, 15, 100);
}

```

## Customizing ListView's selected item

```CSS

.e-listview .e-list-item.e-focused {
    color: #2fa1ff;
    background-color: rgb(0, 15, 100);
}

```
