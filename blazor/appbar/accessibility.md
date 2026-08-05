---
layout: post
title: Accessibility in Blazor AppBar Component | Syncfusion®
description: Checkout and learn about the accessibility features of the Blazor AppBar component, including ARIA support and keyboard navigation.
platform: Blazor
control: AppBar
documentation: ug
---

# Accessibility in Blazor AppBar Component

The [Blazor AppBar](https://www.syncfusion.com/blazor-components/blazor-appbar) component follows the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor AppBar component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2](https://www.w3.org/TR/WCAG22/) Support | NA |
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

## Keyboard interaction

The Blazor AppBar component provides focus element navigation based on the tab key order. Keyboard navigation is enabled by default. The following keyboard shortcuts are supported by the Blazor AppBar component.

| Windows | Mac | Description |
| --- | --- | --- |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Focuses the next focusable element in the AppBar. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>Shift</kbd> + <kbd>Tab</kbd> | Focuses the previous focusable element in the AppBar. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Activates the focused AppBar item. |

## Ensuring Accessibility

The accessibility levels of the Blazor AppBar component are ensured through automated testing using the [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) software tool.

The accessibility compliance of the AppBar component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/appbar) in a new window to evaluate the accessibility of the AppBar component with accessibility tools.

{% previewsample "https://ej2.syncfusion.com/accessibility/appbar.html" %}

## See Also

* [Accessibility in Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)