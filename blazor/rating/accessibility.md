---
layout: post
title: Accessibility in Blazor Rating Component | Syncfusion
description: Checkout and learn here all about accessibility and keyboard interaction in Syncfusion Rating component and much more.
platform: Blazor
control: Rating
documentation: ug
---

# Accessibility in Blazor Rating component

The Blazor Rating component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Rating component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | AAA |
| [Section 508 Support](../common/accessibility#accessibility-standards) |<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Full support"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Full support"> |
| [Right-To-left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Full support"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Full support"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Full support"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Full support"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Full support"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Full support"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial support"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="Not supported"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

The Blazor Rating component follows the [WAI-ARIA slider pattern](https://www.w3.org/WAI/ARIA/apg/patterns/slider/) to meet accessibility requirements. The following ARIA attributes are used in the Blazor Rating component:

| Attributes | Purpose |
| ------------ | ----------------------- |
| `role=slider` | Defines an input where the user selects a value from within a specified range. |
| `role=button` | Indicates that the reset control is clickable and resets the rating to its minimum value. |
| `aria-label` | Provides an accessible name for the Rating component. |
| `aria-valuemin` | Defines the minimum rating value. |
| `aria-valuemax` | Defines the maximum rating value. |
| `aria-valuenow` | Announces the current rating value. |
| `aria-hidden` | Hides the element from assistive technologies when present. |

## Keyboard interaction

The Blazor Rating component follows the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/slider/#keyboardinteraction) guideline, improving accessibility for people who use assistive technologies and those who rely on keyboard navigation. The following keyboard shortcuts are supported by the Blazor Rating component.

| Windows | Mac | Actions |
|------------|-------------------| ---|
| <kbd>Space</kbd> | <kbd>Space</kbd> | When the Reset button is focused, resets to the `min` value. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Increases the value. |
| <kbd>←</kbd> | <kbd>←</kbd> | Decreases the value; in right-to-left mode, increases the value. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Decreases the value. |
| <kbd>→</kbd> | <kbd>→</kbd> | Increases the value; in right-to-left mode, decreases the value. |

## Ensuring accessibility

The Blazor Rating component’s accessibility is verified using [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with Playwright tests.

The accessibility compliance of the Blazor Rating component is demonstrated in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/rating) in a new window to evaluate the component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)