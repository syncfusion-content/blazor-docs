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
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Section 508 Support](../common/accessibility#accessibility-standards) |<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="No"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

The Blazor Rating component followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/slider/) patterns to meet the accessibility. The following ARIA attributes are used in the Blazor Rating component:

| Attributes | Purpose |
| ------------ | ----------------------- |
| `role=slider` | It defines an input where the user selects a value from within a specified range. |
| `role=button` | Specifies that the reset is a clickable element that resets the rating to its minimum value. |
| `aria-label` | Provides an accessible name for Rating. |
| `aria-valuemin` | It defines the minimum value of rating. |
| `aria-valuemax` | It defines the maximum value of rating. |
| `aria-valuenow` | It defines the current value of rating. |
| `aria-hidden` | It specifies whether the reset button is interactive or not. |

## Keyboard interaction

The Blazor Rating component followed the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/slider/#keyboardinteraction) guideline, making it easy for people who use assistive technologies (AT) and those who completely rely on keyboard navigation. The following keyboard shortcuts are supported by the Blazor Rating component.

| Windows | Mac | Actions |
|------------|-------------------| ---|
| <kbd>Space</kbd> | <kbd>Space</kbd> | When **Reset Button** is focused, resets to `min` value. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Increases the value. |
| <kbd>←</kbd> | <kbd>←</kbd> | Decreases the value; in RTL mode, increases the value. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Decreases the value. |
| <kbd>→</kbd> | <kbd>→</kbd> | Increases the value; in RTL mode, decreases the value. |

## Ensuring accessibility

The Blazor Rating component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with playwright tests.

The accessibility compliance of the Blazor Rating component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/rating) in a new window to evaluate the accessibility of the Blazor Rating component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)