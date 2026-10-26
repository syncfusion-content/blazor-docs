---
layout: post
title: Accessibility in Blazor Signature | Syncfusion
description: Learn how Blazor Signature supports accessibility with WCAG 2.2, keyboard navigation, and screen readers.
platform: Blazor
control: Signature
documentation: ug
---

# Accessibility in Blazor Signature

The Blazor Signature component follows the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Signature component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | AA |
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

The Blazor Signature component follows the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/practices/keyboard-interface/) guideline, making it easy for people who use assistive technologies (AT) and people who rely entirely on keyboard navigation. The following keyboard shortcuts are supported by the Blazor Signature component.

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>Ctrl + Z</kbd> | <kbd>⌘</kbd> + <kbd>Z</kbd> | Undo the last action. |
| <kbd>Ctrl + Y</kbd> | <kbd>⌘</kbd> + <kbd>Y</kbd> | Redo the last action. |
| <kbd>Ctrl + S</kbd> | <kbd>⌘</kbd> + <kbd>S</kbd> | To save the signature. |
| <kbd>delete</kbd> | <kbd>delete</kbd> | Erases all the signature strokes signed by the user. |

## Ensuring accessibility

The Blazor Signature component's accessibility levels are ensured through [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with Playwright tests.

The accessibility compliance of the Blazor Signature component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/signature) in a new window to evaluate the accessibility of the Blazor Signature component with accessibility tools.

{% previewsample "https://blazor.syncfusion.com/accessibility/signature" %}

## See also

* [Accessibility in Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)