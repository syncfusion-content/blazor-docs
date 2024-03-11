---
layout: post
title: Accessibility in Blazor Charts Component | Syncfusion
description: Checkout and learn here all about Accessibility using Keyboard navigation in Syncfusion Blazor Charts component and more.
platform: Blazor
control: Chart
documentation: ug
---

# Accessibility in Blazor Chart Component

Accessibility is achieved in the Chart component through WAI-ARIA standard and keyboard navigation. The chart features can be effectively accessed through assistive technologies such as screen readers.

The Chart control followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Chart control is outlined below.

|Accessibility Criteria | Compatibility|
-----|-----
|[WCAG 2.2](https://www.w3.org/TR/WCAG22/) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">  |
|[Section 508](https://www.section508.gov/) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">  |
|Screen Reader Support| <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">  |
|Right-To-Left Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">  |
|Color Contrast | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">  |
|Mobile Device Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">  |
|[Accessibility Checker](https://www.npmjs.com/package/accessibility-checker) Validation | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">  |
|[Axe-core](https://www.npmjs.com/package/axe-core) Accessibility Validation | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">  |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>
<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="No"> - The component does not meet the requirement.</div>

## WAI-ARIA

WAI-ARIA(Accessibility Initiative - Accessible Rich Internet Applications) defines a way to increase the accessibility of web pages, dynamic content, and user interface components developed with AJAX, HTML, Javascript, and related technologies. ARIA provides additional semantics to describe the role, state, and functionality of web components.

Element |Default description
-----|-----
Datalabel |Reads the Point y value.
Legend |Click to show or hide the series.
Axis Title |Reads the axis title.
Chart Title |Reads the chart title.
Series Points |Reads the Point x: Point y value.

The Chart control followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/alert/) patterns to meet the accessibility. The following ARIA attributes are used in the Chart control:

* img (role)
* button (role)
* region (role)
* aria-label (attribute)
* aria-hidden (attribute)
* aria-pressed (attribute)

## Keyboard navigation

Chart functionalities can be interactive with keyboard shortcuts.

The following keyboard shortcuts are supported by Chart.

Interaction Keys |Description
-----|-----
<kbd>Alt + J</kbd> | Moves the focus to the chart element. 
<kbd>Tab</kbd> |Moves the focus to the next element in the chart.
<kbd>Shift + Tab</kbd> |Moves the focus to the previous element in the chart.
<kbd>DownArrow</kbd> |Moves the focus to the data point right side from the selected point.
<kbd>UpArrow</kbd> |Moves the focus to the data point right side from the selected point.
<kbd>Left Arrow</kbd> |Moves the focus to the next series in our Chart component.
<kbd>Right Arrow</kbd> |Moves the focus to the previous series in our Chart component.
<kbd>ESC</kbd> |Cancel the tooltip for the data point.
<kbd>Enter/Space</kbd> |Selects the data point in the series
<kbd>Down/Left Arrow</kbd> |Moves the focus to the legend left side from the selected legend.
<kbd>Up/Right Arrow</kbd> | Moves the focus to the legend right side from the selected legend.
<kbd>Enter/Space</kbd> |Toggles the visibility of the corresponding series.
<kbd>Ctrl + +</kbd> |Zoom in the chart.
<kbd>Ctrl + -</kbd> |Zoom out the chart.
<kbd>Down/Up Arrow</kbd> |Pans the chart vertically.
<kbd>Left/Right Arrow</kbd> |Pans the chart horizontally.
<kbd>R</kbd> |Reset the zoomed chart.
<kbd>Ctrl + P</kbd> |Prints the Chart.

## Ensuring accessibility

The Chart control's accessibility levels are ensured through an [accessibility-checker](https://www.npmjs.com/package/accessibility-checker) and [axe-core](https://www.npmjs.com/package/axe-core) software tools during automated testing.

The accessibility compliance of the Chart control is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/demos/chart/line?theme=fluent) in a new window to evaluate the accessibility of the Chart control with accessibility tools.


## See also

* [Accessibility in Syncfusion Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)