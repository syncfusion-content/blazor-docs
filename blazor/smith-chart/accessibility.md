---
layout: post
title: Blazor Smith Chart Accessibility Examples | Syncfusion®
description: Learn how to enable accessibility in Syncfusion Blazor Smith Chart with keyboard navigation, screen reader support, and WCAG 2.2 compliance.
platform: Blazor
control: Smith Chart
documentation: ug
---

# Blazor Smith Chart Accessibility

The Blazor Smith Chart component follows accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/), and [WAI-ARIA roles](https://www.w3.org/TR/wai-aria/#roles).

The accessibility compliance for the Blazor Smith Chart component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | AA |
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


## WAI-ARIA attributes

The Blazor Smith Chart component follows [WAI-ARIA](https://www.w3.org/TR/wai-aria/) patterns to improve accessibility. The following roles and ARIA attributes are used in the Blazor Smith Chart component:

* img (role)
* button (role)
* region (role)
* aria-label (attribute)
* aria-hidden (attribute)
* aria-pressed (attribute)

## Keyboard interaction

The Blazor Smith Chart component supports keyboard interaction, making it easier for people who use assistive technologies (AT) and those who rely on keyboard navigation. The following keyboard shortcuts are supported by the Blazor Smith Chart component.

| Windows | Mac | Description |
| --- | --- | --- |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Moves the focus to the next element in the Smith Chart. |
| <kbd>Shift + Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Moves the focus to the previous element in the Smith Chart. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Moves the focus to the data point below the selected point. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Moves the focus to the data point above the selected point. |
| <kbd>←</kbd> | <kbd>←</kbd> | Moves the focus to the previous series in the Smith Chart. |
| <kbd>→</kbd> | <kbd>→</kbd> | Moves the focus to the next series in the Smith Chart. |
| <kbd>↓</kbd> or <kbd>←</kbd> | <kbd>↓</kbd> or <kbd>←</kbd> | Moves the focus to the legend item on the left of the selected legend item. |
| <kbd>↑</kbd> or <kbd>→</kbd> | <kbd>↑</kbd> or <kbd>→</kbd> | Moves the focus to the legend item on the right of the selected legend item. |
| <kbd>Enter</kbd> or <kbd>Space</kbd> | <kbd>Enter</kbd> or <kbd>Space</kbd> | Toggles the visibility of the corresponding series. |
| <kbd>Ctrl + P</kbd> | <kbd>⌘</kbd> + <kbd>P</kbd> | Prints the Smith Chart. |

## Ensuring accessibility

The Blazor Smith Chart component's accessibility is validated with [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) and Playwright tests.

The accessibility compliance of the Blazor Smith Chart component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/smith-chart) in a new window to evaluate the accessibility of the Blazor Smith Chart component with accessibility tools.

## See also

* [Accessibility in Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)