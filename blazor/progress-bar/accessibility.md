---
layout: post
title: Blazor ProgressBar Accessibility | Syncfusion®
description: Learn about accessibility in Syncfusion Blazor ProgressBar, including ARIA attributes, keyboard interaction, and WCAG 2.2 compliance.
platform: Blazor
control: ProgressBar
documentation: ug
---

# Blazor ProgressBar Accessibility

The Blazor ProgressBar component follows the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor ProgressBar component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | AA |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) |<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
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


## Keyboard interaction

The Blazor ProgressBar component follows the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/meter/) guideline for the `progressbar` role, making it easier for people who use assistive technologies (AT) and those who completely rely on keyboard navigation.

### Accessibility attributes

The ProgressBar component exposes the following ARIA attributes so assistive technologies can announce its state:

| Attribute | Description |
| --- | --- |
| `role="progressbar"` | Identifies the element as a progress bar to assistive technologies. |
| `aria-valuenow` | Indicates the current progress value. |
| `aria-valuemin` | Indicates the minimum progress value. |
| `aria-valuemax` | Indicates the maximum progress value. |
| `aria-label` | Provides an accessible name when no visible label is present (recommended for indeterminate or decorative progress). |

### Keyboard interaction

The ProgressBar element is included in the page tab sequence so it can receive keyboard focus. The following keyboard shortcuts apply when the ProgressBar has focus:

| Windows | Mac | Description |
| --- | --- | --- |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Moves the focus to the ProgressBar element. |
| <kbd>Ctrl</kbd> + <kbd>P</kbd> | <kbd>⌘</kbd> + <kbd>P</kbd> | Opens the browser print dialog when the ProgressBar is focused. |

## Ensuring accessibility

The Blazor ProgressBar component's accessibility levels are validated through automated [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) checks performed with Playwright as part of the Syncfusion accessibility test pipeline.

The accessibility compliance of the Blazor ProgressBar component is demonstrated in the following sample. Open the [ProgressBar accessibility sample](https://blazor.syncfusion.com/accessibility/progress-bar) in a new window to evaluate the component with accessibility tools.

## See also

* [Accessibility in Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)
* [Blazor ProgressBar Getting Started](getting-started)
* [ARIA `progressbar` pattern (W3C)](https://www.w3.org/WAI/ARIA/apg/patterns/meter/)