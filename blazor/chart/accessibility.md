---
layout: post
title: Accessibility in Blazor Charts Component | Syncfusion
description: Check out and learn here all about Accessibility using Keyboard navigation in Syncfusion Blazor Charts component.
platform: Blazor
control: Chart
documentation: ug
---

# Accessibility in Blazor Chart Component

Syncfusion Blazor Chart components comply with accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) and [WAI-ARIA roles](https://www.w3.org/TR/wai-aria/#roles) to ensure inclusive user experiences.

## Accessibility Compliance Overview

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

WAI-ARIA (Web Accessibility Initiative – Accessible Rich Internet Applications) increases the accessibility of web pages and UI components. The Blazor Chart component uses the following ARIA roles and attributes:

* img (role)
* button (role)
* region (role)
* aria-label (attribute)
* aria-hidden (attribute)
* aria-pressed (attribute)

| Element | Description |
|---------|-------------|
| Data label | Reads the Point y value. |
| Legend | Click to show or hide the series. |
| Axis Title | Reads the axis title. |
| Chart Title | Reads the chart title. |
| Series Points | Reads the Point x: Point y value. |

## Keyboard Navigation

Syncfusion Blazor Charts support keyboard navigation for users relying on assistive technologies. The following keyboard shortcuts are available:

| Windows | Mac | Description |
|-----|-----|---|
|<kbd>Alt + J</kbd> | <kbd>⌥</kbd> + <kbd>J</kbd> | Moves the focus to the chart element.|
|<kbd>Tab</kbd> | <kbd>Tab</kbd> | Moves the focus to the next element in the chart.|
|<kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Moves the focus to the previous element in the chart.|
| <kbd>↓</kbd> | <kbd>↓</kbd> | Moves the focus to the data point right side from the selected point.|
| <kbd>↑</kbd> | <kbd>↑</kbd> | Moves the focus to the data point right side from the selected point.|
| <kbd>←</kbd> | <kbd>←</kbd> | Moves the focus to the next series in the Chart component.|
| <kbd>→</kbd> | <kbd>→</kbd> | Moves the focus to the previous series in the Chart component.|
|<kbd>Enter</kbd> / <kbd>Space</kbd> | <kbd>Enter</kbd> / <kbd>Space</kbd> | Selects the data point in the series|
| <kbd>↓</kbd> , <kbd>←</kbd> | <kbd>↓</kbd> / <kbd>←</kbd> | Moves the focus to the legend left side from the selected legend.|
| <kbd>↑</kbd> , <kbd>→</kbd> | <kbd>↑</kbd> / <kbd>→</kbd> | Moves the focus to the legend right side from the selected legend.|
| <kbd>Enter</kbd> / <kbd>Space</kbd> | <kbd>Enter</kbd> / <kbd>Space</kbd> |Toggles the visibility of the corresponding series.|
| <kbd>Ctrl</kbd> + <kbd>+</kbd> | <kbd>⌘</kbd> + <kbd>+</kbd> | Zoom in the chart.|
| <kbd>Ctrl</kbd> + <kbd>-</kbd> | <kbd>⌘</kbd> + <kbd>-</kbd> | Zoom out the chart.|
| <kbd>↓</kbd> / <kbd>↑</kbd> | <kbd>↓</kbd> / <kbd>↑</kbd> | Pans the chart vertically.|
| <kbd>←</kbd> / <kbd>→</kbd> | <kbd>←</kbd> / <kbd>→</kbd> | Pans the chart horizontally.|
|<kbd>R</kbd> | <kbd>R</kbd> | Reset the zoomed chart.|
|<kbd>Ctrl + P</kbd> | <kbd>⌘</kbd> + <kbd>P</kbd> | Prints the Chart.|

## Ensuring Accessibility

Accessibility levels are validated using [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) and Playwright tests.

Evaluate accessibility in the [Blazor Chart accessibility sample](https://blazor.syncfusion.com/accessibility/chart) using accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)

* [Accessibility Customization in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](./advanced-accessibility-configuration.md)
