---
layout: post
title: Accessibility in Blazor Range Selector Component | Syncfusion
description: Check out and learn about accessibility, keyboard navigation, and compliance in the Syncfusion Blazor Range Selector component.
platform: Blazor
control: Range Selector
documentation: ug
---

# Accessibility in Blazor Range Selector Component

The Blazor Range Selector component follows accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/), and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles).

The table below outlines accessibility compliance for the Blazor Range Selector component.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
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


## WAI-ARIA Attributes

The component follows [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/alert/) patterns for accessibility. The following ARIA attributes are used:

* img (role)
* region (role)
* aria-label (attribute)
* aria-hidden (attribute)

## Keyboard Interaction

The component supports [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/alert/#keyboardinteraction) guidelines, making it accessible for users relying on assistive technologies or keyboard navigation. Supported keyboard shortcuts:

| Windows | Mac | Description |
| --- | --- | --- |
| <kbd>Alt + J</kbd> | <kbd>⌥</kbd> + <kbd>J</kbd> | Moves focus to the Range Selector element. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Moves focus to the Range Selector element. |
| <kbd>Shift + Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Moves focus to the previous element in the Range Selector. |
| <kbd>Ctrl + P</kbd> | <kbd>⌘</kbd> + <kbd>P</kbd> | Prints the Range Selector. |

## Ensuring Accessibility

Accessibility is validated using [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with Playwright tests.

Evaluate accessibility in the Blazor Range Selector component by opening the [sample](https://blazor.syncfusion.com/accessibility/range-selector) in a new window and using accessibility tools.

## See Also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)
