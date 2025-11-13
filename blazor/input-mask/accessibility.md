---
layout: post
title: Accessibility in Blazor Input Mask Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor Input Mask component and much more.
platform: Blazor
control: Input Mask
documentation: ug
---

# Accessibility in Blazor Input Mask Component

The [Blazor MaskedTextBox](https://www.syncfusion.com/blazor-components/blazor-input-mask) component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor MaskedTextBox component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Fully supported"> |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Fully supported"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Fully supported"> |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Fully supported"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Fully supported"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Fully supported"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Fully supported"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Fully supported"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>
<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Fully supported"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partially supported"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="Not supported"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

The Blazor MaskedTextBox includes comprehensive WAI-ARIA support to ensure compatibility with screen readers and other assistive technologies. This component is designed with reference to the WAI-ARIA Authoring Practices.

The MaskedTextBox uses the textbox role and the following ARIA properties, based on state and configuration:

| **Property** | **Functionality** |
| --- | --- |
| aria-label / aria-labelledby | Provides an accessible name for the MaskedTextBox. |
| aria-describedby | Associates helper or error text with the MaskedTextBox for screen reader announcement. |
| aria-invalid | Indicates that the current value fails validation. |
| aria-required | Indicates that input is required. |
| aria-disabled | Indicates that the MaskedTextBox is disabled. |
| aria-readonly | Indicates that the value cannot be changed by the user. |
| aria-multiline | Indicates whether the textbox supports multiple lines (typically false for MaskedTextBox). |

## Ensuring accessibility

The Blazor MaskedTextBox component's accessibility levels are ensured through an [axe-core](https://www.npmjs.com/package/axe-core) software tool during automated testing.

The accessibility compliance of the MaskedTextBox component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/maskedtextbox) in a new window to evaluate the accessibility of the MaskedTextBox component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> components](../common/accessibility)