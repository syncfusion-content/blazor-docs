---
layout: post
title: Accessibility in Blazor SplitButton Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor SplitButton component and more.
platform: Blazor
control: Split Button
documentation: ug
---

# Accessibility in Blazor SplitButton Component

The Blazor SplitButton component follows accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor SplitButton component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | Not Applicable |
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

The Blazor SplitButton component applies WAI-ARIA patterns to meet accessibility requirements. The following ARIA attributes are used in the Blazor SplitButton component:

| Attributes | Purpose |
| --- | --- |
| `role` | Identifies the SplitButton as a `button`, the SplitButton popup as a `menu`, and popup action items as `menuitem`. |
| `aria-haspopup` | Indicates that the button opens an interactive SplitButton popup (menu). |
| `aria-expanded` | Reflects whether the SplitButton popup is currently expanded or collapsed. |
| `aria-owns` | Associates elements to define a parent/child relationship when it cannot be represented in the DOM hierarchy. |
| `aria-disabled` | Indicates that the element is perceivable but disabled and not operable. |

## Keyboard interaction

The Blazor SplitButton component follows keyboard interaction guidelines, making it usable for people who rely on assistive technologies (AT) and keyboard navigation. The following keyboard shortcuts are supported:

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>Esc</kbd> | <kbd>Esc</kbd> | Closes the opened popup. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Opens the popup, or activates the highlighted item and closes the popup. |
| <kbd>Space</kbd> | <kbd>Space</kbd> | Opens the popup. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Navigates up to the previous action item. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Navigates down to the next action item. |
| <kbd>Alt</kbd> + <kbd>↑</kbd> | <kbd>⌥</kbd> + <kbd>↑</kbd> | Closes the popup. |
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | Opens the popup. |

## Ensuring accessibility

The Blazor SplitButton component’s accessibility is validated using [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with Playwright tests.

The accessibility compliance of the Blazor SplitButton component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/split-button) in a new window to evaluate the accessibility of the Blazor SplitButton component with accessibility tools.

{% previewsample "https://ej2.syncfusion.com/accessibility/split-button.html" %}

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)