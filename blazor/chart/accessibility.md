---
layout: post
title: Blazor Charts Accessibility Compliance and Examples | Syncfusion®
description: Learn about Syncfusion Blazor Charts accessibility compliance. Review WCAG 2.2, Section 508, screen reader, and keyboard navigation support.
platform: Blazor
control: Charts
documentation: ug
---

# Blazor Charts Accessibility Compliance

The [Blazor Chart](https://www.syncfusion.com/blazor-components/blazor-charts) component follows widely used accessibility guidelines, including [WCAG 2.2](https://www.w3.org/TR/WCAG22/), [Section 508](https://www.section508.gov/), and [ADA](https://www.ada.gov/) standards. The chart is also tested with assistive technologies to ensure that screen readers and keyboard-only users can interact with the data and chart elements.

The accessibility compliance for the Blazor Chart component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | AA |
| [ADA Support](https://www.ada.gov/) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">  |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) |<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |

<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="No"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

WAI-ARIA (Web Accessibility Initiative - Accessible Rich Internet Applications) defines a way to increase the accessibility of web pages, dynamic content, and user interface components developed with AJAX, HTML, JavaScript, and related technologies. ARIA provides additional semantics to describe the role, state, and functionality of web components.

The Blazor Chart component follows the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/alert/) patterns to meet the accessibility requirements.

### Element descriptions

Element | Default description
-----|-----
Data Label | Reads the Point y value.
Legend | Click to show or hide the series.
Axis Title | Reads the axis title.
Chart Title | Reads the chart title.
Series Points | Reads the Point x, Point y value.

### Roles and attributes

The following ARIA roles and attributes are used in the Blazor Chart component:

* img (role)
* button (role)
* region (role)
* aria-label (attribute)
* aria-hidden (attribute)
* aria-pressed (attribute)

## Keyboard navigation

The Blazor Chart component follows the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/alert/#keyboardinteraction) guideline, making it easy for people who use assistive technologies (AT) and those who completely rely on keyboard navigation. The following keyboard shortcuts are supported by the Blazor Chart component.

### Focus

| Windows | Mac | Description |
|-----|-----|---|
|<kbd>Alt + J</kbd> | <kbd>⌥</kbd> + <kbd>J</kbd> | Moves the focus to the chart element. |
|<kbd>Tab</kbd> | <kbd>Tab</kbd> | Moves the focus to the next element in the chart. |
|<kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Moves the focus to the previous element in the chart. |

### Data point navigation

| Windows | Mac | Description |
|-----|-----|---|
| <kbd>↓</kbd> | <kbd>↓</kbd> | Moves the focus to the data point below the selected point. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Moves the focus to the data point above the selected point. |
| <kbd>→</kbd> | <kbd>→</kbd> | Moves the focus to the next series in the chart. |
| <kbd>←</kbd> | <kbd>←</kbd> | Moves the focus to the previous series in the chart. |
| <kbd>Enter</kbd> / <kbd>Space</kbd> | <kbd>Enter</kbd> / <kbd>Space</kbd> | Selects the data point in the series. |

### Legend navigation

| Windows | Mac | Description |
|-----|-----|---|
| <kbd>←</kbd> | <kbd>←</kbd> | Moves the focus to the legend on the left of the selected legend. |
| <kbd>→</kbd> | <kbd>→</kbd> | Moves the focus to the legend on the right of the selected legend. |
| <kbd>Enter</kbd> / <kbd>Space</kbd> | <kbd>Enter</kbd> / <kbd>Space</kbd> | Toggles the visibility of the corresponding series. |

### Zooming and panning

| Windows | Mac | Description |
|-----|-----|---|
| <kbd>Ctrl</kbd> + <kbd>+</kbd> | <kbd>⌘</kbd> + <kbd>+</kbd> | Zooms in the chart (when the chart has focus). |
| <kbd>Ctrl</kbd> + <kbd>-</kbd> | <kbd>⌘</kbd> + <kbd>-</kbd> | Zooms out the chart (when the chart has focus). |
| <kbd>↓</kbd> / <kbd>↑</kbd> | <kbd>↓</kbd> / <kbd>↑</kbd> | Pans the chart vertically. |
| <kbd>←</kbd> / <kbd>→</kbd> | <kbd>←</kbd> / <kbd>→</kbd> | Pans the chart horizontally. |
| <kbd>R</kbd> | <kbd>R</kbd> | Resets the zoomed chart. |

### Miscellaneous

| Windows | Mac | Description |
|-----|-----|---|
| <kbd>Ctrl + P</kbd> | <kbd>⌘</kbd> + <kbd>P</kbd> | Prints the chart. |

## Ensuring accessibility

The Blazor Chart component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with playwright tests.

The accessibility compliance of the Blazor Chart component is demonstrated in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/chart) in a new window to evaluate the accessibility of the Blazor Chart component with assistive technologies such as screen readers, keyboard-only navigation, and contrast analyzers.

## See also

* [Accessibility in Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)
* [Accessibility Customization in Blazor components](./advanced-accessibility-configuration.md)

