---
layout: post
title: Accessibility in Blazor Color Picker Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor Color Picker component and more.
platform: Blazor
control: Color Picker
documentation: ug
---

# Accessibility in Blazor Color Picker Component

The Blazor Color Picker component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Color Picker component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">  |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) |<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/intermediate.png" alt="Intermediate"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/no.png" alt="No"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

The Blazor Color Picker component followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/alert/) patterns to meet the accessibility. The following ARIA attributes are used in the Blazor ColorPicker component:

| Attributes | Purpose |
| --- | --- |
| `role` | Indicates the Color Picker component as `color`and the tiles as `gridcell` in the color palette. |
| `aria-label` | Indicates the accessible name for the tiles. |
| `aria-selected` | Indicates the current selected state of the tile. |
| `aria-haspopup` | Indicates the availability of the popup element. |
| `aria-expanded` | Indicates whether the popup can be expanded or collapsed, as well as indicates whether its current state is expanded or collapsed. |
| `aria-owns` | Identifies an elements in order to define a visual, functional, or contextual parent/child relationship between DOM elements where the DOM hierarchy cannot be used to represent the relationship. |
| `aria-disabled` | Indicates that the element is perceivable but disabled, so it is not editable or otherwise operable. |

## Keyboard interaction

The Blazor Color Picker component followed the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/alert/#keyboardinteraction) guideline, making it easy for people who use assistive technologies (AT) and those who completely rely on keyboard navigation. The following keyboard shortcuts are supported by the Blazor ColorPicker component.

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Moves the handler/tile up from the current position. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Moves the handler/tile down from the current position. |
| <kbd>←</kbd> | <kbd>←</kbd> | Moves the handler/tile left from the current position. |
| <kbd>→</kbd> | <kbd>→</kbd> | Moves the handler/tile right from the current position. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Apply the selected color value. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | To focus the next focusable element in the ColorPicker popup. |

## Ensuring accessibility

The Blazor Color Picker component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with playwright tests.

The accessibility compliance of the Blazor Color Picker component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/color-picker) in a new window to evaluate the accessibility of the Color Picker Blazor component with accessibility tools.

{% previewsample "https://ej2.syncfusion.com/accessibility/color-picker.html" %}

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)