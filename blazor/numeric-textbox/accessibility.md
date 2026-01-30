---
layout: post
title: Accessibility in Blazor Numeric TextBox Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor Numeric TextBox component and more.
platform: Blazor
control: Numeric TextBox
documentation: ug
---

# Accessibility in Blazor Numeric TextBox Component

The [Blazor NumericTextBox](https://www.syncfusion.com/blazor-components/blazor-numeric-textbox) component follows accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Numeric TextBox component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | AAA |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |

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

The Blazor Numeric TextBox provides comprehensive WAI-ARIA support to improve accessibility for screen readers and other assistive technologies. It is designed with reference to the  [WAI ARAI Accessibility practices](https://www.w3.org/WAI/ARIA/apg/#spinbutton).

The Numeric TextBox uses the role="spin button" and the following ARIA properties to convey state to assistive technologies.

| **Property** | **Functionality** |
| --- | --- |
| aria-live | Indicates the priority of updates to a live region |
| aria-valuemin | Specifies the minimum allowable range of the NumericTextBox.|
| aria-valuemax | Specifies the maximum allowable range of the NumericTextBox. |
| aria-disabled | Indicates disabled state of the NumericTextBox. |
| aria-readonly | Indicates the read-only state of the NumericTextBox. |
| aria-valuenow | Specifies the current value of the NumericTextBox. |
| aria-invalid | Indicates that the user input is incorrect or not within acceptable ranges. |
| aria-label | Indicates a string value that labels the NumericTextBox. |

## Keyboard interaction

Keyboard interaction of the Blazor Numeric TextBox component is designed based on the [WAI-ARIA Practices](https://www.w3.org/WAI/ARIA/apg/#spinbutton) for spinbutton behavior. The input must have focus for the shortcuts to apply.

The following table shows shortcut keys and their corresponding actions.

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Decrements the value. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Increments the value. |

```cshtml
@using Syncfusion.Blazor.Inputs

<SfNumericTextBox TValue="int?" Value=10></SfNumericTextBox>
```

![Accessibility in Blazor NumericTextBox](./images/blazor-numerictextbox-component.png)

## Ensuring accessibility

The Blazor Numeric TextBox component's accessibility levels are validated through an [axe-core](https://www.npmjs.com/package/axe-core) software tool during automated testing.

The accessibility compliance of the Numeric TextBox component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/numerictextbox) in a new window to evaluate the accessibility of the Numeric TextBox component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> components](../common/accessibility)