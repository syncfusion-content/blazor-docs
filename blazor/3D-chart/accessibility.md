---
layout: post
title: Accessibility in Blazor 3D Chart Component | Syncfusion
description: Check out and learn here all about Accessibility using Keyboard navigation in Syncfusion Blazor 3D Chart component and more.
platform: Blazor
control: 3D Chart
documentation: ug
---

# Accessibility in Blazor 3D Chart Component

The Blazor 3D Chart component follows accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/), and [WAI‑ARIA roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor 3D Chart component is outlined below.

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

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> - Some features of the component do not fully meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="No"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

WAI‑ARIA (Web Accessibility Initiative – Accessible Rich Internet Applications) enhances the accessibility of dynamic web content and UI components by defining semantic roles, states, and properties. ARIA attributes convey the role, state, and functionality of components to assistive technologies.

Element | Default description
-----|-----
Datalabel | Reads the point y-value.
Legend | Click to show or hide the series.
Axis Title | Reads the axis title.
Chart Title | Reads the chart title.
Series Points | Reads the point x and point y values.

The Blazor 3D Chart component follows [WAI‑ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/alert/) patterns to meet accessibility requirements. The following ARIA roles and attributes are used in the Blazor 3D Chart component:

* img (role)
* button (role)
* region (role)
* aria-label (attribute)
* aria-hidden (attribute)
* aria-pressed (attribute)

## Keyboard navigation

The Blazor 3D Chart component follows the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/alert/#keyboardinteraction) guidelines, enabling efficient navigation for assistive technology users and full keyboard operation. The following keyboard shortcuts are supported.

| Windows | Mac | Description |
|-----|-----|---|
|<kbd>Alt</kbd> + <kbd>J</kbd> | <kbd>⌥</kbd> + <kbd>J</kbd> | Moves focus to the chart element.|
|<kbd>Tab</kbd> | <kbd>Tab</kbd> | Moves focus to the next element in the chart.|
|<kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Moves focus to the previous element in the chart.|
| <kbd>↓</kbd> | <kbd>↓</kbd> | Moves focus to the data point on the right of the selected point.|
| <kbd>↑</kbd> | <kbd>↑</kbd> | Moves focus to the data point on the right of the selected point.|
| <kbd>←</kbd> | <kbd>←</kbd> | Moves focus to the next series in the chart.|
| <kbd>→</kbd> | <kbd>→</kbd> | Moves focus to the previous series in the chart.|
| <kbd>Enter</kbd> / <kbd>Space</kbd> | <kbd>Enter</kbd> / <kbd>Space</kbd> | Selects the data point in the series.|
| <kbd>↓</kbd> / <kbd>←</kbd> | <kbd>↓</kbd> / <kbd>←</kbd> | Moves focus to the legend item to the left of the selected legend.|
| <kbd>↑</kbd> / <kbd>→</kbd> | <kbd>↑</kbd> / <kbd>→</kbd> | Moves focus to the legend item to the right of the selected legend.|
| <kbd>Enter</kbd> / <kbd>Space</kbd> | <kbd>Enter</kbd> / <kbd>Space</kbd> | Toggles the visibility of the corresponding series.|
| <kbd>Ctrl</kbd> + <kbd>P</kbd> | <kbd>⌘</kbd> + <kbd>P</kbd> | Prints the chart.|

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)
