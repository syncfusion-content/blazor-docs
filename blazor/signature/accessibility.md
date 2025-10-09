---
layout: post
title: Accessibility with Blazor Signature Component | Syncfusion
description: Learn about accessibility in the Syncfusion Blazor Signature component, including WCAG 2.2 and Section 508 compliance, keyboard navigation, screen reader considerations, color contrast, and validation with axe-core.
platform: Blazor
control: Signature
documentation: ug
---

# Accessibility in Blazor Signature Component

The Blazor Signature component follows accessibility guidelines and standards, including ADA, Section 508, and WCAG 2.2. It supports screen readers, keyboard navigation, and color contrast customization. For component details, see the Signature documentation and API reference in the Syncfusion Blazor docs.

The accessibility compliance for the Blazor Signature component is outlined below.

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

## Keyboard interaction

The Blazor Signature component follows keyboard navigation guidance to support users of assistive technologies and those who rely on the keyboard. The following keyboard shortcuts are supported by the Blazor Signature component (shortcuts may require handling in application code, depending on the hosting page and focus management). See the keyboard navigation guidance at [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support).

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>Ctrl + Z</kbd> | <kbd>⌘</kbd> + <kbd>Z</kbd> | Undo the last action. |
| <kbd>Ctrl + Y</kbd> | <kbd>⌘</kbd> + <kbd>Y</kbd> | Redo the last action. |
| <kbd>Ctrl + S</kbd> | <kbd>⌘</kbd> + <kbd>S</kbd> | Save the signature. |
| <kbd>Delete</kbd> | <kbd>Delete</kbd> | Erases all signature strokes entered by the user. |

## Ensuring accessibility

The Blazor Signature component's accessibility levels are validated using [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with Playwright tests.

The accessibility compliance of the Blazor Signature component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/signature) in a new window to evaluate the accessibility of the Blazor Signature component with accessibility tools.

{% previewsample "https://ej2.syncfusion.com/accessibility/signature.html" %}

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)