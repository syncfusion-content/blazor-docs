---
layout: post
title: CSS Structure in Blazor Chips | Syncfusion®
description: Override the Blazor Chips default CSS structure to customize avatar, leading icon, trailing icon, selection, and deletion state styles.
platform: Blazor
control: Chips
documentation: ug
---

# CSS Structure in Blazor Chips

Use the following CSS to customize the appearance of the Blazor Chip component. 

| Class / Element | Applies to | Purpose |
| -- | -- | -- |
| `.e-chip` | Each individual chip. | The root element of a single chip. |
| `.e-chip-list` | The wrapper that contains all chips. | The root element of the ChipList. |
| `.e-chip-text` | The text inside a chip. | Customize font and color. |
| `.e-chip-icon` | The leading or trailing icon element. | Customize icon background and opacity. |
| `.e-chip-delete` | The delete (X) button. | Customize the delete button. |
| `.e-outline` | Outline chips. | Add a border with a transparent background. |
| `.e-active` | The selected chip. | Customize the active/selected appearance. |
| `.e-selection` | A ChipList in single-selection mode. | Differentiate single-selection styling. |
| `.e-chip-avatar` | The avatar leading content. | Style the leading avatar area. |

## Customizing the chip text

The `.e-chip-text` element wraps the chip label. Use the following CSS to customize its font, color, and weight.

```css
.e-chip .e-chip-text {
    font-size: 20px;
    color: black;
    font-weight: normal;
}
```

## Customizing the chip icon

The `.e-chip-icon` element renders the leading or trailing icon set via the `LeadingIconCss` / `TrailingIconCss` properties. Use the following CSS to customize the icon background.

```css
.e-chip .e-chip-icon {
    background-image: url('https://ej2.syncfusion.com/demos/src/chips/images/laura.png');
    opacity: 0.8;
}
```

## Customizing the chip delete button

The `.e-chip-delete` element renders the delete icon shown when `EnableDelete` is `true`. Use the following CSS to customize the delete button.

```css
.e-chip-list .e-chip .e-chip-delete.e-dlt-btn {
    color: #e3165b;
    font-size: 12px;
}
```

## Customizing the chip outline

The `.e-outline` class is applied to each `ChipItem` to render an outlined chip. Use the following CSS to customize the chip outline.

```css
.e-chip-list .e-chip.e-outline {
    border-color: #e3165b;
    border-width: 3px;
}
```

## Customizing the chip on selection

The `.e-active` class is applied to a selected chip. The `.e-selection` class is applied to a ChipList in single-selection mode. Use the following CSS to customize the selected chip.

```css
/* To customize single chip on selection */
.e-chip-list.e-selection .e-chip.e-active {
    background-color: #ffca1c;
    color: #e3165b;
}

/* To customize multiple chip on selection */
.e-chip-list .e-chip.e-active {
    background-color: #e3165b;
    color: white;
}
```

## Customizing the chip avatar text

The `.e-chip-avatar` element is the leading content area of an avatar chip. Use the following CSS to customize the chip avatar text properties.

```css
.e-chip-list .e-chip .e-chip-avatar {
    background-color: #d51a1a;
    color: #fafafa;
}

## See also

* [Getting Started with Blazor Chip](getting-started.md)
* [Types in Blazor Chip](types.md)
* [Customization in Blazor Chip](customization.md)

