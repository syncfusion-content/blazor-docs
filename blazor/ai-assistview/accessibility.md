---
layout: post
title: Accessibility in Blazor AI AssistView Component | Syncfusion
description: Checkout and learn about Accessibility and Keyboard interaction with Blazor AI AssistView component and more details.
platform: Blazor
control: AI AssistView
documentation: ug
---

# Accessibility in Blazor AI AssistView component

The Blazor AI AssistView component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor AI AssistView component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Section 508 Support](../common/accessibility#accessibility-standards) |<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="No"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

The following ARIA attributes are used in the AI AssistView component:

| Attributes | Purpose |
| ------------ | ----------------------- |
| `role=button` | Used to convey it is clickable element that trigger a response when activated by the user. |
| `role=toolbar` | Attribute is set to the AssistView ToolBar element describes the actual role of the element. |
| `aria-label` | Defines a string value that labels an interactive element for accessibility. |
| `aria-orientation` | Attribute is set to the AssistView ToolBar element to indicates the ToolBar orientation. Default value is `horizontal`. |
| `aria-disabled` | Attribute set to the AssistView ToolBar element to indicates the disabled state of the ToolBar. |

## Keyboard interaction

The following keyboard shortcuts are supported by the AI AssistView component.

| **Press** | **To do this** |
| --- | --- |
| <kbd>Enter</kbd> | Select the appropriate item. |
| <kbd>Tab</kbd> | To Move focus through the interactive elements. |
| <kbd>Shift + Tab</kbd> | To Move focus through the interactive elements. |
<b>AI AssistView Toolbar / AI AssistView Header</b>||
| <kbd>Left Arrow</kbd> | Focuses the previous element.  |
| <kbd>Right Arrow</kbd> | Focuses the next element. |
| <kbd>Enter / Space</kbd> | When focused on a ToolBar element, clicking the key triggers the click of Toolbar element. |
| <kbd>Home</kbd> | Moves focus to the first Toolbar. |
| <kbd>End</kbd> | Moves focus to the last Toolbar. |
| <kbd>Tab</kbd> | To Move focus through the interactive elements. |
| <kbd>Shift + Tab</kbd> | To Move focus through the interactive elements.  |

## Ensuring accessibility

The Blazor AI AssistView component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with playwright tests.

## See also

* [Accessibility in Syncfusion Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)