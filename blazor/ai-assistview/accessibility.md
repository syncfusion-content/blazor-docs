---
layout: post
title: Accessibility in Blazor AI AssistView Component | Syncfusion
description: Checkout and learn about Accessibility and Keyboard interaction with Blazor AI AssistView component and more details.
platform: Blazor
control: AI AssistView
documentation: ug
---

# Accessibility in the Blazor AI AssistView component

The Blazor AI AssistView component follows established accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The component’s accessibility compliance is summarized below.

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
| `role=button` | Indicates that the element is clickable and triggers an action when activated by the user. |
| `role=toolbar` | Specifies that the element is a toolbar. |
| `aria-label` | Provides an accessible name for interactive elements (for example, buttons, toolbar, or prompt input). |
| `aria-orientation` | Specifies the orientation of the toolbar. |
| `aria-disabled` | Indicates whether the toolbar or element is currently disabled and not interactive. |
| `aria-multiline` | Indicates that a textbox accepts multiple lines of input or only a single line. |

## Keyboard interaction

The following keyboard shortcuts are supported by the AI AssistView component.

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Select the focused item. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Move focus forward through interactive elements. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Move focus backward through interactive elements. |
<b>AI AssistView toolbar</b>|||
| <kbd>←</kbd> | <kbd>←</kbd> | Move focus to the previous toolbar element.  |
| <kbd>→</kbd> | <kbd>→</kbd> | Move focus to the next toolbar element. |
| <kbd>Enter</kbd> / <kbd>Space</kbd> | <kbd>Enter</kbd> / <kbd>Space</kbd> | Select the focused item or activate the selected option. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | Move focus to the first toolbar element. |
| <kbd>End</kbd> | <kbd>End</kbd> | Move focus to the last toolbar element. |

## Ensuring accessibility

The Blazor AI AssistView component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with playwright tests.

## See also

* Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components (https://blazor.syncfusion.com/documentation/common/accessibility)