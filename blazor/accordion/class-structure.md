---
layout: post
title: Blazor Accordion CSS classes and their descriptions | Syncfusion
description: Check out and learn all about CSS classes and their descriptions in the Syncfusion Blazor Accordion component.
platform: Blazor
control: Accordion
documentation: ug
---

# CSS Classes in Blazor Accordion Component

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor [Accordion](https://www.syncfusion.com/blazor-components/blazor-accordion) component is a vertically collapsible container that organizes content into headers and expandable panels. It supports single- or multi-panel expansion, nested accordions, RTL layout, and keyboard accessibility. This document lists the component's CSS classes, explains their purpose, and shows how to customize the visual appearance via CSS overrides.

## Root and Item Classes

| CSS Class | Description |
|-----------|-------------|
| `.e-accordion` | Applied to the root container element of the Accordion component. Defines the base block-level display and relative positioning. |
| `.e-acrdn-item` | Applied to each Accordion item wrapper. Contains both the header and content panel. Controls item-level spacing, borders, margin, padding, and overflow behavior. |
| `.e-acrdn-item:first-child` | Applied to the first Accordion item in the component. Removes top margin and applies specific border-radius and border styling for the top edge. |
| `.e-acrdn-item:last-child` | Applied to the last Accordion item in the component. Applies specific border and border-radius styling for the bottom edge to complete the component's visual boundaries. |

## Header Classes

| CSS Class | Description |
|-----------|-------------|
| `.e-acrdn-header` | Applied to the header element of an Accordion item. Includes styles for padding, line-height, min-height, border-radius, text overflow handling, and cursor behavior for interactive items. |
| `.e-acrdn-header-content` | Applied to the element containing the header text or content. Controls font size, font weight, and line height of the header content. |
| `.e-acrdn-header-icon` | Applied to the wrapper element that contains custom icons in the header (separate from the toggle icon). Positioned with inline-block display and specific padding. |

### Header Interaction States

| CSS Class with State | Description |
|---------------------|-------------|
| `.e-acrdn-header:hover` | Applied when the pointer hovers over the header. Provides visual feedback for interactive headers, typically changing background color or text styling. |
| `.e-acrdn-header:active` | Applied when the header is being clicked/pressed. Provides immediate visual feedback during the click action, usually with a distinct background or text color. |
| `.e-acrdn-header:focus` | Applied when the header receives keyboard focus. Ensures accessibility by providing visual indication for keyboard navigation, typically with outline or background changes. |

## Toggle Icon Classes

| CSS Class | Description |
|-----------|-------------|
| `.e-toggle-icon` | Applied to the container that holds the expand/collapse indicator icon. Positioned absolutely on the right side (or left in RTL mode) of the header with specific height and width constraints. |
| `.e-tgl-collapse-icon` | Applied to the actual icon element inside `.e-toggle-icon`. Uses table-cell display with center alignment for proper vertical positioning. |
| `.e-tgl-collapse-icon.e-icons` | Combined class applied to the collapse icon element. Sets display to table-cell with vertical-align middle and text-align center for proper icon positioning within the toggle container. |
| `.e-toggle-animation` | Applied to elements that animate during expand/collapse transitions. Defines a 0.5s ease transition for smooth animations. |
| `.e-acrdn-icons` | Applied to icon elements within the Accordion. Controls icon font size and appearance. |
| `.e-acrdn-icons.e-icons` | Combined class applied to header icon elements. Controls the font size using the accordion item arrow icon font size variable. |
| `.e-icons` | Base icon class used in combination with `.e-acrdn-icons` and `.e-tgl-collapse-icon`. Provides core icon font styling and rendering properties for Syncfusion icon fonts. |

## Panel and Content Classes

| CSS Class | Description |
|-----------|-------------|
| `.e-acrdn-panel` | Applied to the collapsible content container of an Accordion item. Sets width to 100%, controls overflow-y behavior, and manages font size for content. |
| `.e-acrdn-content` | Applied to the inner content wrapper within the panel. Handles padding, line-height, text overflow, and actual content display. |

## State Classes

| CSS Class | Description |
|-----------|-------------|
| `.e-acrdn-item.e-select` | Applied to Accordion items that are interactive and can be expanded/collapsed. Items with this class show pointer cursor on hover and have hover/focus text decoration effects. |
| `.e-acrdn-item.e-selected` | Applied to currently expanded Accordion items. Used to differentiate active items with specific styling like adjusted padding and modified font weight for header content. |
| `.e-acrdn-item.e-expand-state` | Applied to Accordion items in their expanded state. Used in combination with `.e-selected` to identify items that are currently opened and displaying their content panel. |
| `.e-acrdn-item.e-active` | Applied to the Accordion item that is currently active. Typically used to track the most recently interacted item, which may differ from the selected/expanded state. |
| `.e-acrdn-item.e-item-focus` | Applied to Accordion items when they receive keyboard focus. Provides visual indication for keyboard navigation and accessibility. Used to style focused items differently from selected or hovered items. |
| `.e-acrdn-item.e-overlay` | Applied to Accordion items during height calculation and animation. Sets height to auto for proper measurement. |
| `.e-acrdn-item.e-hide` | Applied to Accordion items that should be completely hidden from display using `display: none`. |
| `.e-content-hide` | Applied to content elements to hide them without affecting the item structure. |

## Nested Accordion Classes

| CSS Class | Description |
|-----------|-------------|
| `.e-acrdn-panel.e-nested` | Applied to panels that host a nested Accordion. Removes inner padding and adjusts padding, borders, and spacing to ensure correct alignment and rendering of nested headers and content across nesting levels. |

## RTL (Right-to-Left) Classes

| CSS Class | Description |
|-----------|-------------|
| `.e-rtl` | Applied to the root `.e-accordion` element when the component is in right-to-left mode. Flips the layout by positioning the toggle icon on the left side and adjusting all padding values accordingly. |

## Special Class Combinations

The following class combinations have specific styling behaviors:

| Class Combination | Description |
|-------------------|-------------|
| `.e-acrdn-item.e-select.e-selected:first-child` | Applied to the first selected item. Controls top border styling for the first expanded item. |
| `.e-acrdn-item.e-select.e-selected:last-child` | Applied to the last selected item. Controls bottom border styling for the last expanded item. |
| `.e-acrdn-item.e-select.e-selected.e-expand-state` | Applied to Accordion items that are selectable, currently selected, and in expanded state. Represents the complete expanded item state with all relevant modifiers. |
