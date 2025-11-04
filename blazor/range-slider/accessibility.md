---
layout: post
title: Accessibility in Blazor Range Slider Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor Range Slider component and more.
platform: Blazor
control: Range Slider
documentation: ug
---

# Accessibility in Blazor Range Slider Component

The [Blazor Range Slider](https://www.syncfusion.com/blazor-components/blazor-range-slider) is characterized with complete [WAI-ARIA](https://www.w3.org/TR/wai-aria-practices/#slider) Accessibility support that helps to access by on-screen readers and other assistive technology devices. This component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The Blazor Range Slider component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Range Slider component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2](https://www.w3.org/TR/WCAG22/) Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Section 508](https://www.section508.gov/) Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| Screen Reader Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Right-To-Left Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Color Contrast | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Mobile Device Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Keyboard Navigation Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) Accessibility Validation | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/no.png" alt="No"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

The Blazor Range Slider component followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/slider/) patterns to meet the accessibility. The following ARIA attributes are used in the Range Slider component:

| **Attributes** | **Purpose** |
| --- | --- |
| `aria-valuenow` | It indicates the current value of the slider. |
| `aria-valuetext`| It returns the current text of the slider. |
| `aria-valuemin` | It indicates the minimum value of the slider. |
| `aria-valuemax` | It indicates the maximum value of the slider. |
| `aria-orientation` | It indicates the Slider Orientation. |
| `aria-label` | Slider left and right button label text (increment and decrement). |
| `aria-labelledby` | It indicates the name of the Slider. |

## Keyboard interaction

The Keyboard interaction of the Blazor Range Slider component is designed based on the [WAI-ARIA Practices](https://www.w3.org/TR/wai-aria-practices/#slider) described for Slider. Users can use the following shortcut keys to interact with the Slider.

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>↑</kbd> or <kbd>→</kbd> | <kbd>↑</kbd> or <kbd>→</kbd> | Increase the Slider value.|
| <kbd>↓</kbd> , <kbd>←</kbd> | <kbd>↓</kbd> or <kbd>←</kbd> | Decrease the Slider value. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | Moves to the start value (for Range Slider when the second thumb is focused and the Home key is pressed, it moves to the first thumb value). |
| <kbd>End</kbd> | <kbd>End</kbd> | Moves to the end value (for Range Slider when the first thumb is focused and the End key is pressed, it moves to the second thumb value). |
| <kbd>Page Up</kbd> | <kbd>Page Up</kbd> | Increases the Slider by `LargeStep` value. |
| <kbd>Page Down</kbd> | <kbd>Page Down</kbd> | Decreases the Slider by `LargeStep` value. |

## Ensuring accessibility

The Blazor Range Slider component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) software tool during automated testing.

The accessibility compliance of the Range Slider component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/slider) in a new window to evaluate the accessibility of the Range Slider component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)
