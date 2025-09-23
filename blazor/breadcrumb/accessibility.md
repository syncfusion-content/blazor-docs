---
layout: post
title: Accessibility in Blazor Breadcrumb Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor Breadcrumb component and much more.
platform: Blazor
control: Button
documentation: ug
---

# Accessibility in Blazor Breadcrumb component

The Blazor Breadcrumb component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Breadcrumb component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2](https://www.w3.org/TR/WCAG22/) Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Section 508](https://www.section508.gov/) Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Screen Reader Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Right-To-Left Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Color Contrast | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Mobile Device Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Keyboard Navigation Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Axe-core](https://www.npmjs.com/package/axe-core) Accessibility Validation | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>
<div><img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/intermediate.png" alt="Intermediate"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/no.png" alt="No"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

The Blazor Breadcrumb component implements [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/breadcrumb/) patterns to meet accessibility requirements. The following ARIA attributes are used in the Blazor Breadcrumb component:

| Attributes | Purpose |
| --- | --- |
| `aria-label` | Indicates the breadcrumb item text. |
| `aria-disabled` | Indicates the disabled state of a breadcrumb item. |

## Keyboard interaction

The Blazor Breadcrumb component follows the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/breadcrumb/#keyboardinteraction) guideline, facilitating navigation for individuals who use assistive technologies (AT) and those who rely solely on keyboard navigation. The following keyboard shortcuts are supported by the Blazor Breadcrumb component.

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Navigate to the next item and also next item in the popup of menu type overflow. |
| <kbd>Shift + Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Navigate to the previous item also previous item in the popup of menu type overflow. |
| <kbd>Enter</kbd> key in normal mode | <kbd>Enter</kbd> key in normal mode | Select the breadcrumb item. |
| <kbd>Enter</kbd> key in normal mode | <kbd>Enter</kbd> key in normal mode | To open the popup of menu type overflow mode when you press enter on collapsed button and It will expand the items of collapsed type overflow mode when you press enter on collapsed button. |

## Ensuring accessibility

The accessibility levels of the Blazor Breadcrumb component are ensured through automated testing using [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with playwright tests.

The accessibility compliance of the Blazor Breadcrumb component is demonstrated in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/breadcrumb) in a new window to evaluate the accessibility of the Blazor Breadcrumb component with accessibility tools.

{% previewsample "https://ej2.syncfusion.com/accessibility/breadcrumb.html" %}

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)
