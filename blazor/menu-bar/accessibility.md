---
layout: post
title: Accessibility in Blazor Menu Bar Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor Menu Bar component and much more.
platform: Blazor
control: Menu Bar
documentation: ug
---

# Accessibility in Blazor Menu Bar Component

The Blazor Menu bar component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Menu bar component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">  |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) |<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |

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

The Blazor Menu bar component followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/menubar/) patterns to meet the accessibility. The following ARIA attributes are used in the Blazor Menu bar component:

| Attributes | Purpose |
| --- | --- |
| `role` | Indicates Menu bar component's root Menu bar as `menubar`, popup as `menu`, and the popup items as `menu item`. |
| `aria-haspopup` | Indicates the availability and type of interactive popup element. |
| `aria-expanded` | Indicates whether the subtree can be expanded or collapsed, and indicates whether its current state can be expanded or collapsed. |
| `aria-orientation` | Indicates whether the orientation is horizontal or vertical. The default orientation is horizontal. |
| `aria-label` | Indicates the menu item text. |
| `aria-disabled` | Indicates the state of menu item whether it is disabled. |

## Keyboard interaction

The Blazor Menu bar component followed the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/menubar/#keyboardinteraction) guideline, making it easy for people who use assistive technologies (AT) and those who completely rely on keyboard navigation. The following keyboard shortcuts are supported by the Blazor Menu Bar component.

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>Esc</kbd> | <kbd>Esc</kbd> | Closes the sub Menu that contains focus and returns focus to the parent element. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Opens the sub Menu if focused menu item has sub Menu, and places focus on its first item or activates the item and closes the sub menu. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Navigates up or to the previous menu item. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Navigates down or to the next menu item. |
| <kbd>←</kbd> | <kbd>←</kbd> | Closes the current sub menu and navigates to the parent menu. |
| <kbd>→</kbd> | <kbd>→</kbd> | Navigates and open the next sub menu. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | Focuses the first item. |
| <kbd>End</kbd> | <kbd>End</kbd> | Focuses the last item.

## Ensuring accessibility

The Blazor Menu Bar component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with playwright tests.

The accessibility compliance of the Blazor Menu Bar component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/menu) in a new window to evaluate the accessibility of the Blazor Menu Bar component with accessibility tools.

{% previewsample "https://ej2.syncfusion.com/accessibility/menu.html" %}

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)