---
layout: post
title: Accessibility in Blazor Toolbar Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor Toolbar component and much more.
platform: Blazor
control: Toolbar
documentation: ug
---

# Accessibility in Blazor Toolbar Component

The [Blazor Toolbar](https://www.syncfusion.com/blazor-components/blazor-toolbar) component is designed with [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/practices/) specifications, applying WAI-ARIA roles, states, and properties, along with keyboard support for assistive devices. WAI-ARIA accessibility support, achieved through attributes like `aria-label` and `aria-orientation`, provides information about elements in a document for assistive technology. The component implements keyboard navigation support by following [WAI-ARIA practices](https://www.w3.org/WAI/ARIA/apg/practices/), and has been tested in major screen readers.

The Blazor Toolbar component adheres to  accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) commonly used for accessibility evaluation.

The accessibility compliance for the Blazor Toolbar component is outlined below.

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

## WAI-ARIA Attributes

The Blazor Toolbar component is designed considering the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/) standard. ARIA Accessibility support ensures the Toolbar is accessible by screen readers and other assistive technology devices.

The following list of attributes are added in the Toolbar.

| **Attributes** | **Purpose** |
| --- | --- |
| role="toolbar" | Attribute is set to the ToolBar element describes the actual role of the element. |
| aria-orientation |  Attribute is set to the ToolBar element to indicates the ToolBar orientation. Default value is `horizontal`. |
| aria-label | Attribute is set to ToolBar element describes the purpose of the set of toolbar. |
| aria-expanded | Attribute is set to the ToolBar Popup  element to indicates the expanded state of the popup.|
| aria-haspopup | Attribute is set to the popup element to indicates the popup mode of the Toolbar. Default value is false. When popup mode is enabled, attribute value has to be changed to `true`. |
| aria-disabled | Attribute set to the ToolBar element to indicates the disabled state of the ToolBar. |

## Keyboard Interaction

Keyboard navigation is enabled, by default. Possible keys are:

| Windows | Mac | Actions |
|-------- | ------ | ------|
| <kbd>←</kbd> | <kbd>←</kbd> | Focuses the previous element. |
| <kbd>→</kbd> | <kbd>→</kbd> | Focuses the next element. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | When focused on a ToolBar Item, clicking the key triggers the click of Toolbar element. When popup drop-down icon is focused, the popup opens. |
| <kbd>Esc(Escape)</kbd> | <kbd>Esc</kbd> | Closes popup. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Focuses the next popup element.  |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Focuses the previous popup element. |

## Ensuring Accessibility

The accessibility levels of the Blazor Toolbar component are ensured through automated testing using the [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) 
software tool.

The accessibility compliance of the Toolbar component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/toolbar) in a new window to evaluate the accessibility of the Toolbar component with accessibility tools.

## See Also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)