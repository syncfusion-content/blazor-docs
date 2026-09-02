---
layout: post
title: Accessibility in Blazor Input Mask | Syncfusion
description: Learn how Blazor Input Mask supports accessibility standards, keyboard navigation, screen readers, and ARIA attributes.
platform: Blazor
control: Input Mask
documentation: ug
---

# Accessibility in Blazor Input Mask

The [Blazor Input Mask](https://www.syncfusion.com/blazor-components/blazor-input-mask) component follows the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Input Mask component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | AA |
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

The Blazor Input Mask component includes comprehensive WAI-ARIA support to ensure compatibility with screen readers and other assistive technologies. This component is designed with reference to the WAI-ARIA Authoring Practices.

The Blazor Input Mask component uses the textbox role and the following ARIA properties, based on state and configuration:

| **Property** | **Functionality** |
| --- | --- |
| aria-label / aria-labelledby | Provides an accessible name for the Blazor Input Mask component. |
| aria-describedby | Associates helper or error text with the Blazor Input Mask component for screen reader announcement. |
| aria-invalid | Indicates that the current value fails validation. |
| aria-required | Indicates that input is required. |
| aria-disabled | Indicates that the Blazor Input Mask component is disabled. |
| aria-readonly | Indicates that the value cannot be changed by the user. |
| aria-multiline | Indicates whether the textbox supports multiple lines (typically false for Blazor Input Mask component). |

## Ensuring accessibility

The Blazor Input Mask component's accessibility levels are ensured through an [axe-core](https://www.npmjs.com/package/axe-core) software tool during automated testing.

The accessibility compliance of the Blazor Input Mask component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/maskedtextbox) in a new window to evaluate the accessibility of the Blazor Input Mask component with accessibility tools.

## See also

* [Accessibility in Blazor components](../common/accessibility)