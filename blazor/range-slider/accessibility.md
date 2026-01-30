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
| [WCAG 2.2](https://www.w3.org/TR/WCAG22/) Support | AAA |
| [Section 508](https://www.section508.gov/) Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Full support"> |
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

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Full support"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial support"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/no.png" alt="Not supported"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

The Blazor Range Slider component follows the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/slider/) pattern to meet accessibility requirements. The following ARIA attributes are used in the Range Slider component:

| **Attributes** | **Purpose** |
| --- | --- |
| `aria-valuenow` | Indicates the current value of the slider. |
| `aria-valuetext`| Provides a human-readable text alternative for the current value. |
| `aria-valuemin` | Indicates the minimum value of the slider. |
| `aria-valuemax` | Indicates the maximum value of the slider. |
| `aria-orientation` | Indicates the slider orientation. |
| `aria-label` | Defines an accessible name for controls (for example, increment or decrement). |
| `aria-labelledby` | References the element that provides the accessible name for the slider. |

## Keyboard interaction

Keyboard interaction of the Blazor Range Slider component is based on the [WAI-ARIA Practices](https://www.w3.org/TR/wai-aria-practices/#slider) described for sliders. Use the following shortcut keys to interact with the slider.

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>↑</kbd> or <kbd>→</kbd> | <kbd>↑</kbd> or <kbd>→</kbd> | Increase the slider value. |
| <kbd>↓</kbd> or <kbd>←</kbd> | <kbd>↓</kbd> or <kbd>←</kbd> | Decrease the slider value. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | Move to the start value (for range sliders, when the second thumb is focused and Home is pressed, it moves to the first thumb’s value). |
| <kbd>End</kbd> | <kbd>End</kbd> | Move to the end value (for range sliders, when the first thumb is focused and End is pressed, it moves to the second thumb’s value). |
| <kbd>Page Up</kbd> | <kbd>Page Up</kbd> | Increase by the `LargeStep` value. |
| <kbd>Page Down</kbd> | <kbd>Page Down</kbd> | Decrease by the `LargeStep` value. |

## Ensuring accessibility

The Blazor Range Slider component’s accessibility is validated using the [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) tool during automated testing.

The accessibility compliance of the Range Slider component is demonstrated in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/slider) in a new window to evaluate the Range Slider component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)