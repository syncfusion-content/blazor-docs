---
layout: post
title: Accessibility in Blazor Floating Action Button | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor Floating Action Button component and much more.
platform: Blazor
control: Floating Action Button
documentation: ug
---

# Accessibility in Blazor Floating Action Button component

The Blazor Floating Action Button component follows accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Floating Action Button component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | AA |
| [Section 508 Support](../common/accessibility#accessibility-standards) |<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Supported"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Supported"> |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Supported"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Supported"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Supported"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Supported"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Supported"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>
<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Supported"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partially supported"> - Some features of the component do not fully meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="Not supported"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

The Blazor Floating Action Button component follows the [WAI-ARIA button pattern](https://www.w3.org/WAI/ARIA/apg/patterns/button/) to meet accessibility requirements. The following ARIA attribute is used in the Blazor Floating Action Button component:

| Attributes | Purpose |
| --- | --- |
| `aria-label` | Provides an accessible name for an icon-only floating action button. |

## Keyboard interaction

The Blazor Floating Action Button component follows the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/button/#keyboardinteraction) guideline, making it accessible to people who use assistive technologies and those who rely on keyboard navigation. The following keyboard shortcuts are supported by the Blazor Floating Action Button component.


| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>Space</kbd> | <kbd>Space</kbd> | When the floating action button has focus, activates the button (fires click). |

## Ensuring accessibility

The Blazor Floating Action Button component's accessibility levels are ensured through [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with Playwright tests.

The accessibility compliance of the Blazor Floating Action Button component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/fab) in a new window to evaluate the accessibility of the Blazor Floating Action Button component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)