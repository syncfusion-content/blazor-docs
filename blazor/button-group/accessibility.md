---
layout: post
title: Accessibility in Blazor Button Group | Syncfusion®
description: Learn how Blazor Button Group meets WCAG 2.2, Section 508, and ADA standards with WAI-ARIA roles, keyboard navigation, and screen reader support.
platform: Blazor
control: Button Group
documentation: ug
---

# Accessibility in Blazor Button Group

The Blazor Button Group component follows widely accepted accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility. This document summarizes the compliance level of the component, its supported keyboard interactions, and the validation tools used to verify accessibility.

The accessibility compliance for the Blazor Button Group component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | AA |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">  |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
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

The Blazor Button Group component follows the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/button/#keyboardinteraction) guideline, making it easy for people who use assistive technologies (AT) and those who completely rely on keyboard navigation. The behavior of the keyboard shortcuts depends on the `Mode` of the Button Group (single, multiple, or default/command mode).

The following keyboard shortcuts are supported by the Blazor Button Group component.

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Focuses the next button in the Blazor Button Group. |
| <kbd>Shift + Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Focuses the previous button in the Blazor Button Group. |
| Arrows (<kbd>↑</kbd> , <kbd>→</kbd> , <kbd>↓</kbd> , <kbd>←</kbd>) | Arrows (<kbd>↑</kbd> , <kbd>→</kbd> , <kbd>↓</kbd> , <kbd>←</kbd>) | In `SelectionMode.Single`, moves focus and selects the next/previous button. In `SelectionMode.Multiple`, moves focus only; press <kbd>Space</kbd> to toggle the focused button. |
| <kbd>Space</kbd> | <kbd>Space</kbd> | Activates the focused button in the default Blazor Button Group, or toggles selection of the focused button in `SelectionMode.Multiple`. |

## Ensuring accessibility

The Blazor Button Group component's accessibility levels are ensured through [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with Playwright tests.

The accessibility compliance of the Blazor Button Group component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/button-group) in a new window to evaluate the accessibility of the Blazor Button Group component with accessibility tools.

{% previewsample "https://blazor.syncfusion.com/accessibility/button-group" %}

## See also

* [Accessibility in Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)
* [Getting Started with Blazor Button Group](getting-started.md)
* [Types and Styles in Blazor Button Group](types-and-styles.md)
* [Selection and Nesting in Blazor Button Group](selection-and-nesting.md)
* [Keyboard interaction (WAI-ARIA Authoring Practices)](https://www.w3.org/WAI/ARIA/apg/patterns/button/#keyboardinteraction)