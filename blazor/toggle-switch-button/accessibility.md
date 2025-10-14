---
layout: post
title: Accessibility in Blazor Toggle Switch Button Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor Toggle Switch Button component and more.
platform: Blazor
control: Toggle Switch Button
documentation: ug
---

# Accessibility in Blazor Toggle Switch Button Component

The Blazor Toggle Switch Button component follows accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

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

The Blazor Toggle Switch Button component follows the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/switch/) pattern to meet accessibility requirements. The following ARIA attributes are used in the Blazor Toggle Switch Button component. The component uses the switch role and reflects its state to assistive technologies. Ensure a clear, accessible label is provided via visible text, `aria-label`, or `aria-labelledby` as appropriate.

| Attributes | Purpose |
| --- | --- |
| `role` | Identifies the element as a switch control. |
| `aria-disabled` | Indicates that the element is disabled and is not operable. |

## Keyboard interaction

The Blazor Toggle Switch Button component follows the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/switch/#keyboardinteraction) guideline, making it usable for people who rely on assistive technologies (AT) and keyboard navigation. The following keyboard shortcuts are supported.

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>Space</kbd> | <kbd>Space</kbd> | When the toggle switch has focus, pressing Space toggles the switch state. |

## Ensuring accessibility

The Blazor Toggle Switch Button component’s accessibility levels are validated using [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with Playwright tests.

The accessibility compliance of the Blazor Toggle Switch Button component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/switch) in a new window to evaluate the accessibility of the Blazor Toggle Switch Button component with accessibility tools.

{% previewsample "https://ej2.syncfusion.com/accessibility/switch.html" %}

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)