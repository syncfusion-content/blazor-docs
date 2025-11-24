---
layout: post
title: Accessibility in Blazor Toggle Switch Button Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor Toggle Switch Button component and more.
platform: Blazor
control: Toggle Switch Button
documentation: ug
---

# Accessibility in Blazor Toggle Switch Button Component

The Blazor Toggle Switch Button component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Toggle Switch Button component is outlined below.

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

The Blazor Toggle Switch Button component followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/switch/) patterns to meet the accessibility. The following ARIA attributes are used in the Blazor Toggle Switch Button component:

| Attributes | Purpose |
| --- | --- |
| `role` | Indicates the Toggle Switch Button component. |
| `aria-disabled` | Indicates that the element is perceivable but disabled, so it is not editable or otherwise operable. |

## Keyboard interaction

The Blazor Toggle Switch Button component followed the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/switch/#keyboardinteraction) guideline, making it easy for people who use assistive technologies (AT) and those who completely rely on keyboard navigation. The following keyboard shortcuts are supported by the Blazor Toggle Switch Button component.

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>Space</kbd> | <kbd>space</kbd> | When the Toggle Switch Button has focus, pressing the Space key changes the state of the Toggle Switch Button. |

## Ensuring accessibility

The Blazor Toggle Switch Button component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with playwright tests.

The accessibility compliance of the Blazor Toggle Switch Button component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/switch) in a new window to evaluate the accessibility of the Blazor Toggle Switch Button component with accessibility tools.

{% previewsample "https://ej2.syncfusion.com/accessibility/switch.html" %}

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)