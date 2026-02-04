---
layout: post
title: Accessibility in Blazor Stepper Component | Syncfusion
description: Checkout and learn about Accessibility and Keyboard interaction with Blazor Stepper component and more details.
platform: Blazor
control: Stepper
documentation: ug
---

# Accessibility in Blazor Stepper component

The Blazor Stepper component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Stepper component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | AAA |
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

The following ARIA attributes are used in the Stepper component:

| Attributes | Purpose |
| --- | --- |
| `aria-label` | Attribute provide a descriptive text that labels the interactive element for accessibility. |
| `aria-current` | Attribute denotes the currently active step in the Stepper. |
| `aria-disabled`| Indicates when the step is disabled and cannot be interacted. |

## Keyboard interaction

The following keyboard shortcuts are supported by the Stepper component.

| Windows | Mac | **To do this** |
| --- | --- | --- |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Focuses the previous step in a vertical Stepper. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Focuses the next step in a vertical Stepper. |
| <kbd>←</kbd> | <kbd>←</kbd> | Focuses the previous step in a horizontal Stepper. |
| <kbd>→</kbd> | <kbd>→</kbd> | Focuses the next step in a horizontal Stepper. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | Focuses on the first step of the Stepper. |
| <kbd>End</kbd> | <kbd>End</kbd> | Focuses on the last step of the Stepper. |
| <kbd>Enter / Space</kbd> | <kbd>Enter / Space</kbd> | Activates the currently focused step. |

## Ensuring accessibility

The Blazor Stepper component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with playwright tests.

The accessibility compliance of the Blazor Stepper component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/stepper) in a new window to evaluate the accessibility of the Blazor Stepper component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)