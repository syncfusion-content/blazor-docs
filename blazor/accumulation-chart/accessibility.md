---
layout: post
title: Accessibility in Blazor Accumulation Chart Component | Syncfusion
description: Check out and learn here all about Accessibility using Keyboard navigation in Syncfusion Blazor Accumulation Chart component.
platform: Blazor
control: Accumulation Chart
documentation: ug
---

# Accessibility in Blazor Accumulation Chart Component

The Blazor Accumulation Chart component adheres to accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) commonly used to evaluate accessibility.

Accessibility compliance for the Blazor Accumulation Chart component is outlined below.

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

<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> - All features of the component meet the requirement.</div>
<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> - Some features of the component do not meet the requirement.</div>
<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="No"> - The component does not meet the requirement.</div>

## WAI-ARIA Attributes

The Blazor Accumulation Chart component follows [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/alert/) patterns to ensure accessibility. The following ARIA attributes are used:

* img (role)
* button (role)
* region (role)
* aria-label (attribute)
* aria-hidden (attribute)
* aria-pressed (attribute)

## Keyboard Interaction

The component supports [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/alert/#keyboardinteraction) guidelines, making navigation easy for users of assistive technologies and those relying on keyboard navigation. The following keyboard shortcuts are supported:

| Windows | Mac | Description |
| --- | --- | --- |
| <kbd>Alt</kbd> + <kbd>J</kbd> | <kbd>⌥</kbd> + <kbd>J</kbd> | Moves focus to the Accumulation Chart element. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Moves focus to the next element in the Accumulation Chart. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Moves focus to the previous element in the Accumulation Chart. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Moves focus to the data point left side from the selected point. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Moves focus to the data point right side from the selected point. |
| <kbd>↓</kbd> / <kbd>←</kbd> | <kbd>↓</kbd> / <kbd>←</kbd> | Moves focus to the legend left side from the selected legend. |
| <kbd>↑</kbd> / <kbd>→</kbd> | <kbd>↑</kbd> / <kbd>→</kbd> | Moves focus to the legend right side from the selected legend. |
| <kbd>Enter</kbd> / <kbd>Space</kbd> | <kbd>Enter</kbd> / <kbd>Space</kbd> | Toggles visibility of the corresponding series. |
| <kbd>ESC</kbd> | <kbd>Esc</kbd> | Cancels the tooltip for the data point. |
| <kbd>Ctrl + P</kbd> | <kbd>⌘</kbd> + <kbd>P</kbd> | Prints the Accumulation Chart. |

## Ensuring Accessibility

Accessibility levels are validated using [accessibility-checker](https://www.npmjs.com/package/accessibility-checker) and [axe-core](https://www.npmjs.com/package/axe-core) tools during automated testing.

Accessibility compliance for the Blazor Accumulation Chart component can be evaluated in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/accumulation-chart) in a new window to review accessibility features with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)
