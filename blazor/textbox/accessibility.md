---
layout: post
title: Accessibility in Blazor TextBox Component | Syncfusion
description: Discover Syncfusion Blazor TextBox Components accessibility features—easy to learn, implement, and use for all.
platform: Blazor
control: TextBox
documentation: ug
---

# Accessibility in Blazor TextBox Component

The [Blazor TextBox](https://www.syncfusion.com/blazor-components/blazor-textbox) follows accessibility guidelines and standards commonly used to evaluate UI accessibility, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/), and [WAI‑ARIA](https://www.w3.org/TR/wai-aria/).

The accessibility compliance for the Blazor TextBox component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | AAA |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>
<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> - All features of the component meet the requirement.</div>
<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partially meets requirement"> - Some features of the component do not meet the requirement.</div>
<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="Not supported"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

The Blazor TextBox is characterized with complete ARIA Accessibility support that helps to access through the on-screen readers and other assistive technology devices. This component is designed with the reference of the guidelines document given in [WAI ARAI Accessibility practices](https://www.w3.org/TR/wai-aria/#textbox).

The TextBox uses the `textbox` role and following ARIA properties for its element based on its state.

| **Property** | **Functionality** |
| --- | --- |
| aria-placeholder | The `aria-placeholder` is a short hint to help the users with data entry when the Textbox has no value. |
| aria-labelledby | The `aria-labelledby` property indicates the floating label element of the Textbox. |

## Ensuring accessibility

The Blazor TextBox component’s accessibility is validated with the [axe-core](https://www.npmjs.com/package/axe-core) tool during automated testing.

The accessibility compliance of the TextBox component is demonstrated in the following sample. Open the [accessibility sample for TextBox](https://blazor.syncfusion.com/accessibility/textbox) in a new window to evaluate accessibility with your preferred tools. The component also supports right-to-left (RTL) rendering and high-contrast themes for improved readability and usability.

## See also

- [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> components](../common/accessibility)