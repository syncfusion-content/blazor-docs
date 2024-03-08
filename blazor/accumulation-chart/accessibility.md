---
layout: post
title: Accessibility in Blazor Accumulation Chart Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor Accumulation Chart component and more.
platform: Blazor
control: Accumulation Chart
documentation: ug
---

# Accessibility in Blazor Accumulation Chart Component

The Accumulation chart control followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Accumulation chart control is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2](https://www.w3.org/TR/WCAG22/) Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Section 508](https://www.section508.gov/) Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| Screen Reader Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| Right-To-Left Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| Color Contrast | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| Mobile Device Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| Keyboard Navigation Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Accessibility Checker](https://www.npmjs.com/package/accessibility-checker) Validation | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Axe-core](https://www.npmjs.com/package/axe-core) Accessibility Validation | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>
<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> - All features of the control meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> - Some features of the control do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="No"> - The control does not meet the requirement.</div>


## WAI-ARIA attributes

The Accumulation chart control followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/alert/) patterns to meet the accessibility. The following ARIA attributes are used in the Accumulation chart control:

* img (role)
* button (role)
* region (role)
* aria-label (attribute)
* aria-hidden (attribute)
* aria-pressed (attribute)

## Keyboard interaction

The Accumulation chart control followed the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/alert/#keyboardinteraction) guideline, making it easy for people who use assistive technologies (AT) and those who completely rely on keyboard navigation. The following keyboard shortcuts are supported by the Accumulation chart control.

| **Press** | **To do this** |
| --- | --- |
| <kbd>Alt + J</kbd> | Moves the focus to the Accumulation chart element. |
| <kbd>Tab</kbd> | Moves the focus to the next element in the Accumulation chart. |
| <kbd>Shift + Tab</kbd> | Moves the focus to the previous element in the Accumulation chart. |
| <kbd>Down Arrow</kbd> | Moves the focus to the data point left side from the selected point. |
| <kbd>Up Arrow</kbd> | Moves the focus to the data point right side from the selected point. |
| <kbd>Down/Left Arrow</kbd> | Moves the focus to the legend left side from the selected legend. |
| <kbd>Up/Right Arrow</kbd> | Moves the focus to the legend right side from the selected legend. |
| <kbd>Enter/Space</kbd> | Toggles the visibility of the corresponding series. |
| <kbd>Ctrl + P</kbd> | Prints the Accumulation chart. |

## Ensuring accessibility

The Accumulation chart control's accessibility levels are ensured through an [accessibility-checker](https://www.npmjs.com/package/accessibility-checker) and [axe-core](https://www.npmjs.com/package/axe-core) software tools during automated testing.

The accessibility compliance of the Accumulation chart control is shown in the following sample. Open the [sample](https://ej2.syncfusion.com/accessibility/accumulation-chart.html) in a new window to evaluate the accessibility of the Accumulation chart control with accessibility tools.


## See also

* [Data Label](./data-labels)
* [Tooltip](./tool-tip)
* [Legend](./legend)