---
layout: post
title: Accessibility in Blazor Timeline Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor Timeline component and more details.
platform: Blazor
control: Timeline
documentation: ug
---

# Accessibility in Blazor Timeline component

The Blazor Timeline component adheres to accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards. It incorporates [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) commonly used for accessibility evaluation.

The accessibility compliance for the Blazor Timeline component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Section 508 Support](../common/accessibility#accessibility-standards) |<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) | N/A |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | N/A |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="No"> - The component does not meet the requirement.</div>

## WAI-ARIA Attributes

The following ARIA attributes are used in the Timeline component:

| Attributes | Purpose |
| --- | --- |
| `role=navigation` | Specified its purpose as a navigational element. |
| `aria-label` | Provides an accessibile name for an element when a visible label is not present |

## Ensuring Accessibility

The accessibility levels of the Blazor Timeline component are verified through [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with Playwright tests.

The accessibility compliance of the Blazor Timeline component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/timeline) in a new window to evaluate the accessibility of the Blazor Timeline component with accessibility tools.

## See Also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)