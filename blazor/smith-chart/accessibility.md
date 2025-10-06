---
layout: post
title: Accessibility in Blazor Smith Chart Component | Syncfusion
description: Check out and learn here all about Accessibility using Keyboard navigation in Syncfusion Blazor Smith Chart component and more.
platform: Blazor
control: Smith Chart
documentation: ug
---

# Accessibility in Blazor Smith Chart Component

The Blazor Smith Chart component is designed to meet major accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/), and [WAI-ARIA roles](https://www.w3.org/TR/wai-aria/#roles). These standards help ensure the component is usable by everyone, including people with disabilities.

## Accessibility Compliance

The table below summarizes the accessibility features supported by the Blazor Smith Chart component:

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes" /> |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes" /> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes" /> |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes" /> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes" /> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes" /> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes" /> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes" /> |

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

The Blazor Smith Chart component implements [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/alert/) patterns to enhance accessibility. The following ARIA roles and attributes are used:

- `img` (role)
- `button` (role)
- `region` (role)
- `aria-label` (attribute)
- `aria-hidden` (attribute)
- `aria-pressed` (attribute)

## Keyboard Interaction

The component supports [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/alert/#keyboardinteraction) guidelines, making it accessible for users who rely on assistive technologies or keyboard navigation. The following keyboard shortcuts are available:

| Windows | Mac | Description |
| --- | --- | --- |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Move focus to the next element in the Smith Chart. |
| <kbd>Shift + Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Move focus to the previous element in the Smith Chart. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Move focus to the data point to the right of the selected point. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Move focus to the data point to the right of the selected point. |
| <kbd>←</kbd> | <kbd>←</kbd> | Move focus to the next series in the Smith Chart. |
| <kbd>→</kbd> | <kbd>→</kbd> | Move focus to the previous series in the Smith Chart. |
| <kbd>↓</kbd> or <kbd>←</kbd> | <kbd>↓</kbd> or <kbd>←</kbd> | Move focus to the legend to the left of the selected legend. |
| <kbd>↑</kbd> or <kbd>→</kbd> | <kbd>↑</kbd> or <kbd>→</kbd> | Move focus to the legend to the right of the selected legend. |
| <kbd>Enter</kbd> or <kbd>Space</kbd> | <kbd>Enter</kbd> or <kbd>Space</kbd> | Toggle the visibility of the corresponding series. |
| <kbd>Ctrl + P</kbd> | <kbd>⌘</kbd> + <kbd>P</kbd> | Print the Smith Chart. |

## Ensuring Accessibility

Accessibility is validated using [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with Playwright tests.

You can evaluate the accessibility of the Blazor Smith Chart component using this [sample](https://blazor.syncfusion.com/accessibility/smith-chart) in a new window with accessibility tools.

## See Also

- [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)
