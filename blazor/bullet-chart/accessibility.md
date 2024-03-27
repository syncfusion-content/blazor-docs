---
layout: post
title: Accessibility in Blazor Bullet Chart Component | Syncfusion
description: Checkout and learn here all about Accessibility using Keyboard navigation in Syncfusion Blazor Bullet Chart component and more.
platform: Blazor
control: Bullet Chart
documentation: ug
---

# Accessibility in Blazor Bullet Chart Component

The Blazor Bullet Chart component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Bullet Chart component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2](https://www.w3.org/TR/WCAG22/) Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Section 508](https://www.section508.gov/) Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| Screen Reader Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| Right-To-Left Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| Color Contrast | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| Mobile Device Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| Keyboard Navigation Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
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

The Blazor Bullet Chart component followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/alert/) patterns to meet the accessibility. The following ARIA attributes are used in the Blazor Bullet Chart component:

* img (role)
* button (role)
* region (role)
* aria-label (attribute)
* aria-pressed (attribute)

## Keyboard interaction

The Blazor Bullet Chart component followed the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/alert/#keyboardinteraction) guideline, making it easy for people who use assistive technologies (AT) and those who completely rely on keyboard navigation. The following keyboard shortcuts are supported by the Blazor Bullet Chart component.

Interaction Keys |Description
| --- | --- |
|<kbd>Alt + J</kbd> | Moves the focus to the Bullet Chart element. |
| <kbd>Tab</kbd> | Moves the focus to the next element in the Bullet Chart. |
| <kbd>Shift + Tab</kbd> | Moves the focus to the previous element in the Bullet Chart. |
|<kbd>UpArrow/Right Arrow</kbd> |Moves the focus to the legend right side from the selected legend. |
|<kbd>DownArrow/Left Arrow</kbd> |Moves the focus to the legend left side from the selected legend. |
| <kbd>Ctrl + P</kbd> | Prints the Bullet Chart. |

## Ensuring accessibility

The Blazor Bullet Chart component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with playwright tests.

The accessibility compliance of the Blazor Bullet Chart component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/bullet-chart) in a new window to evaluate the accessibility of the Blazor Bullet Chart component with accessibility tools.

## See also

* [Accessibility in Syncfusion Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)