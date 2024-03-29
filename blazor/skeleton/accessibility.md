---
layout: post
title: Accessibility in Blazor Skeleton Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor Skeleton component and much more.
platform: Blazor
control: Skeleton
documentation: ug
---

# Accessibility in Blazor Skeleton component

The Blazor Skeleton component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Skeleton component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) ||
| [Section 508 Support](../common/accessibility#accessibility-standards) ||
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) ||
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) ||
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) ||
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

## ARIA attributes

The Skeleton component characterized with complete ARIA accessibility support that helps to be accessible by on-screen readers and other assistive technology devices. The following ARIA attributes are applicable for Skeleton component.

| Properties | Functionality |
| ------------ | ----------------------- |
| `role` | This attribute is added to the input element to describe the actual role. |
| `aria-label` | Attribute provides the text label with some default description for the Skeleton. |
| `aria-live` | The aria-live attribute indicates the priority of updates to a live region. |
| `aria-busy` | This attribute is set to true when component is shown. |

## Ensuring accessibility

The Blazor Skeleton component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with playwright tests.

The accessibility compliance of the Blazor Skeleton component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/skeleton) in a new window to evaluate the accessibility of the Blazor Skeleton component with accessibility tools.

## See also

* [Accessibility in Syncfusion Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)