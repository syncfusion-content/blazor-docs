---
layout: post
title: Accessibility in Blazor Smith Chart Component | Syncfusion
description: Checkout and learn here all about Accessibility using Keyboard navigation in Syncfusion Blazor Smith Chart component and more.
platform: Blazor
control: Smith Chart
documentation: ug
---

# Accessibility in Blazor Smith Chart Component

The Smith chart control followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Smith chart control is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2](https://www.w3.org/TR/WCAG22/) Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Section 508](https://www.section508.gov/) Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| Screen Reader Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
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

The Smith chart control followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/alert/) patterns to meet the accessibility. The following ARIA attributes are used in the Smith chart control:

* img (role)
* button (role)
* region (role)
* aria-label (attribute)
* aria-hidden (attribute)
* aria-pressed (attribute)

## Keyboard interaction

The Smith chart control followed the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/alert/#keyboardinteraction) guideline, making it easy for people who use assistive technologies (AT) and those who completely rely on keyboard navigation. The following keyboard shortcuts are supported by the Smith chart control.

| **Press** | **To do this** |
| --- | --- |
| <kbd>Tab</kbd> | Moves the focus to the next element in the Smith chart. |
| <kbd>Shift + Tab</kbd> | Moves the focus to the previous element in the Smith chart. |
| <kbd>DownArrow</kbd> | Moves the focus to the data point right side from the selected point. |
| <kbd>UpArrow</kbd> | Moves the focus to the data point right side from the selected point. |
| <kbd>Left Arrow</kbd> | Moves the focus to the next series in our Chart component. |
| <kbd>Right Arrow</kbd> | Moves the focus to the previous series in our Chart component. |
| <kbd>Down/Left Arrow</kbd> | Moves the focus to the legend left side from the selected legend. |
| <kbd>Up/Right Arrow</kbd> | Moves the focus to the legend right side from the selected legend. |
| <kbd>Enter/Space</kbd> | Toggles the visibility of the corresponding series. |
| <kbd>Ctrl + P</kbd> | Prints the Smith chart. |

## Ensuring accessibility

The Smith chart control's accessibility levels are ensured through an [accessibility-checker](https://www.npmjs.com/package/accessibility-checker) and [axe-core](https://www.npmjs.com/package/axe-core) software tools during automated testing.

The accessibility compliance of the Smith chart control is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/smith-chart) in a new window to evaluate the accessibility of the Smith chart control with accessibility tools.


## See also

* [Accessibility in Syncfusion Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)