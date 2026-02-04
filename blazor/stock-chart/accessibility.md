---
layout: post
title: Accessibility in Blazor Stock Chart Component | Syncfusion
description: Check out and learn here all about Accessibility using Keyboard navigation in Syncfusion Blazor Stock Chart component and more.
platform: Blazor
control: Stock Chart
documentation: ug
---

# Accessibility in Blazor Stock Chart Component

The Blazor Stock Chart component follows accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Stock Chart component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | AAA |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
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

## WAI-ARIA attributes

The Blazor Stock Chart component follows the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/alert/) patterns to meet accessibility requirements. The following ARIA attributes are used in the Blazor Stock Chart component:

* img (role)
* button (role)
* region (role)
* aria-label (attribute)
* aria-hidden (attribute)
* aria-pressed (attribute)

## Keyboard interaction

The Blazor Stock Chart component follows the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/alert/#keyboardinteraction) guideline, enabling effective use with assistive technologies (AT) and full keyboard navigation. The following keyboard shortcuts are supported by the Blazor Stock Chart component.

| Windows | Mac | Description |
| --- | --- | --- |
| <kbd>Alt + J</kbd> | <kbd>⌥</kbd> + <kbd>J</kbd> | Moves focus to the Stock Chart element. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Moves focus to the next element in the stock chart. |
| <kbd>Shift + Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Moves focus to the previous element in the stock chart. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Moves focus to the data point to the left of the selected point. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Moves focus to the data point to the right of the selected point. |
| <kbd>↓</kbd> or <kbd>←</kbd> | <kbd>↓</kbd> or <kbd>←</kbd> | Moves focus to the legend item to the left of the selected legend. |
| <kbd>↑</kbd> or <kbd>→</kbd> | <kbd>↑</kbd> or <kbd>→</kbd> | Moves focus to the legend item to the right of the selected legend. |
| <kbd>Enter/Space</kbd> | <kbd>Enter/Space</kbd> | Toggles the visibility of the corresponding series. |
| <kbd>Esc</kbd> | <kbd>Esc</kbd> | Cancels the tooltip for the data point. |
| <kbd>Ctrl + P</kbd> | <kbd>⌘</kbd> + <kbd>P</kbd> | Prints the stock chart. |

## Ensuring accessibility

The Blazor Stock Chart component's accessibility levels are validated using [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with Playwright tests.

The accessibility compliance of the Blazor Stock Chart component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/stock-chart) in a new window to evaluate the accessibility of the Blazor Stock Chart component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)
