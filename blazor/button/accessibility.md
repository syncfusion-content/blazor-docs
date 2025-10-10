---
layout: post
title: Accessibility in Blazor Button Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor Button component and much more.
platform: Blazor
control: Button
documentation: ug
---

# Accessibility in Blazor Button component

The Blazor Button component follows accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WAI-ARIA roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Button component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
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

## WAI-ARIA attributes

The Blazor Button component follows the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/button/) patterns to meet accessibility requirements. The following ARIA attributes are used in the Blazor Button component:

| Attributes | Purpose |
| --- | --- |
| `aria-label` | Provides an accessible name for an icon-only button. |
| `aria-pressed` | Indicates the pressed (toggled) state when a button is used as a toggle. |
| `aria-describedby` | References additional descriptive content that provides more context for the button’s purpose. |

## Keyboard interaction

The Blazor Button component follows the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/button/#keyboardinteraction) guideline, making it accessible for users of assistive technologies (AT) and those who rely on keyboard navigation. The following keyboard shortcuts are supported by the Blazor Button component.

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>Space</kbd> | <kbd>Space</kbd> | When the button has focus, activates the button (or toggles the pressed state for toggle buttons). |
| <kbd>Enter</kbd> | <kbd>Return</kbd> | When the button has focus, activates the button (or toggles the pressed state for toggle buttons). |

## Ensuring accessibility

The Blazor Button component’s accessibility levels are validated using [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with Playwright tests.

The accessibility compliance of the Blazor Button component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/button) in a new window to evaluate the accessibility of the Blazor Button component with accessibility tools.

{% previewsample "https://ej2.syncfusion.com/accessibility/button.html" %}

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)