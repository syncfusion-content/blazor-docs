---
layout: post
title: Accessibility in Blazor Toolbar Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor Toolbar component and much more.
platform: Blazor
control: Toolbar
documentation: ug
---

# Accessibility in Blazor Toolbar Component

The [Blazor Toolbar](https://www.syncfusion.com/blazor-components/blazor-toolbar) component has been designed, keeping in mind the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/) specifications, and applying the WAI-ARIA roles, states and properties along with keyboard support for people who use assistive devices. WAI-ARIA accessibility support is achieved through attributes like `aria-label` and `aria-orientation`, It provides information about elements in a document for assistive technology. The component implements keyboard navigation support by following the [WAI-ARIA practices](https://www.w3.org/WAI/ARIA/apg/), and has been tested in major screen readers.

The Blazor Toolbar component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Toolbar component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2](https://www.w3.org/TR/WCAG22/) Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Section 508](https://www.section508.gov/) Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| Screen Reader Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Right-To-Left Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Color Contrast |  |
| Mobile Device Support |  |
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

Blazor Toolbar component is designed by considering [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/) standard. Toolbar is supported with ARIA Accessibility which is accessible by on-screen readers, and other assistive technology devices.

The following list of attributes are added in the Toolbar.

| **Attributes** | **Purpose** |
| --- | --- |
| role="toolbar" | Attribute is set to the ToolBar element describes the actual role of the element. |
| aria-orientation |  Attribute is set to the ToolBar element to indicates the ToolBar orientation. Default value is `horizontal`. |
| aria-label | Attribute is set to ToolBar element describes the purpose of the set of toolbar. |
| aria-expanded | Attribute is set to the ToolBar Popup  element to indicates the expanded state of the popup.|
| aria-haspopup | Attribute is set to the popup element to indicates the popup mode of the Toolbar. Default value is false. When popup mode is enabled, attribute value has to be changed to `true`. |
| aria-disabled | Attribute set to the ToolBar element to indicates the disabled state of the ToolBar. |

## Keyboard interaction

Keyboard navigation is enabled, by default. Possible keys are:

| Keyboard shortcuts | Actions |
|-------- | ------|
| <kbd>Left</kbd>    | Focuses the previous element. |
| <kbd>Right</kbd>   | Focuses the next element. |
| <kbd>Enter</kbd> | When focused on a ToolBar command, clicking the key triggers the click of Toolbar element. When popup drop-down icon is focused, the popup opens. |
| <kbd>Esc(Escape)</kbd> | Closes popup. |
| <kbd>Down</kbd> | Focuses the next popup element.  |
| <kbd>Up</kbd> | Focuses the previous popup element. |

## Ensuring accessibility

The Blazor Toolbar component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) software tool during automated testing.

The accessibility compliance of the Toolbar component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/toolbar) in a new window to evaluate the accessibility of the Toolbar component with accessibility tools.

## See also

* [Accessibility in Syncfusion Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)