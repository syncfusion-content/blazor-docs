---
layout: post
title: Accessibility in Blazor Color Picker Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor Color Picker component and more.
platform: Blazor
control: Color Picker
documentation: ug
---

# Accessibility in Blazor Color Picker Component

## ARIA attributes

The web accessibility makes web content and web applications more accessible for people with disabilities. It especially helps in dynamic content change and development of advanced user interface controls with AJAX, HTML, JavaScript, and related technologies. It helps to provide information about the widget for assistive technology to the disabled person in screen reader.

Color Picker provides built-in compliance with the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/) specifications. WAI-ARIA support is achieved through the attributes like `aria-label`and `aria-selected` applied to the color palette tiles.

| Properties | Functionality |
| ------------ | ----------------------- |
| role | Specified as `gridcell` for the tiles in the color palette. |
| aria-label | Holds the color of the tile. |
| aria-selected | Indicates the current selected state of the tile. |

## Keyboard interaction

The following list of keys can be used to interact with the Color Picker after the popup has opened.

| **Press** | **To do this** |
| --- | --- |
| <kbd>Upper Arrow</kbd>  | Moves the handler/tile up from the current position. |
| <kbd>Down Arrow</kbd>  | Moves the handler/tile down from the current position. |
| <kbd>Left Arrow</kbd>  | Moves the handler/tile left from the current position. |
| <kbd>Right Arrow</kbd>  | Moves the handler/tile right from the current position. |
| <kbd>Enter</kbd>  | Apply the selected color value. |
| <kbd>Tab</kbd>  | To focus the next focusable element in the Color Picker popup.  |