---
layout: post
title: Accessibility in Blazor Pager Component | Syncfusion
description: Checkout here and learn about accessibility in Syncfusion Blazor Pager component and much more details.
platform: Blazor
control: Pager
documentation: ug
---

# Accessibility in Blazor Pager Component

The Blazor Pager component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Pager component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) ||
| [Section 508 Support](../common/accessibility#accessibility-standards) ||
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">  |
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

## WAI-ARIA

The Blazor Pager component followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/) patterns to meet the accessibility. The following ARIA attributes are used in the Blazor Pager component:

* pager (role)
* link (role)
* aria-label (Attribute)
* aria-selected (Attribute)

## Keyboard navigation

The Blazor Pager component followed the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/alert/#keyboardinteraction) guideline, making it easy for people who use assistive technologies (AT) and those who completely rely on keyboard navigation. The following keyboard shortcuts are supported by the Blazor Pager component.

Interaction Keys |Description
-----|-----
<kbd>Page down / Right arrow |Navigates to the next page.
<kbd>Page up / Left arrow |Navigates to the previous page.
<kbd>Enter / Space |Select the currently focused page.
<kbd>Tab</kbd> |Focus on the next pager item.
<kbd>Shift + Tab</kbd> |Focus on the previous pager item.
<kbd>Home</kbd> |Navigates to the first page.
<kbd>End</kbd> |Navigates to the last page.
<kbd>Alt + Page up</kbd> |Navigates to the previous pager.
<kbd>Alt + Page down</kbd> |Navigates to the next pager.

## Ensuring accessibility

The Blazor Pager component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with playwright tests.

The accessibility compliance of the Blazor Pager component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/pager) in a new window to evaluate the accessibility of the Blazor Pager component with accessibility tools.

## See also

* [Accessibility in Syncfusion Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)
