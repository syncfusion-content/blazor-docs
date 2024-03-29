---
layout: post
title: Accessibility in Blazor SpeedDial Component | Syncfusion
description: Checkout and learn here all about accessibility and keyboard in Syncfusion Speed Dial component and much more.
platform: Blazor
control: SpeedDial
documentation: ug
---

# Accessibility in Blazor SpeedDial Component

The Blazor Speed Dial component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Speed Dial component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) ||
| [Section 508 Support](../common/accessibility#accessibility-standards) ||
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) ||
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

## Keyboard interaction

The Blazor Speed Dial component followed the keyboard interaction guideline, making it easy for people who use assistive technologies (AT) and those who completely rely on keyboard navigation. The following keyboard shortcuts are supported by the Blazor Speed Dial component.

| Keyboard shortcuts | Actions |
|------------|-------------------|
| <kbd>Enter</kbd> | Open/close the menu. If a SpeedDial item is focused, should triggers the clicked event for the item. |
| <kbd>ArrowUp</kbd> | Navigates up or to the previous menu item. |
| <kbd>ArrowLeft</kbd> | Navigates left or to the previous menu item. |
| <kbd>ArrowDown-</kbd> | Navigates down or to the previous menu item. |
| <kbd>ArrowRight</kbd> | Navigates right or to the previous menu item. |
| <kbd>Home</kbd> | Navigates to the first menu item. |
| <kbd>End</kbd> | Navigates to the last menu item. |
| <kbd>Esc</kbd> | Closes the menu. |

## WAI-ARIA attributes

The Blazor Speed Dial component followed the WAI-ARIA patterns to meet the accessibility. The following ARIA attributes are used in the Blazor Speed Dial component:

| Properties | Functionality |
| ------------ | ----------------------- |
| `role` | This attribute is added to the input element to describe the actual role. |
| `aria-label` | Attribute provides the text label with some default description for the SpeedDial and its items. |
| `aria-expanded` | It indicates whether the SpeedDial current state is expanded or collapsed. |
| `aria-haspopup` | It indicates whether the SpeedDial has popup items or not. |
| `aria-controls` | Attribute is set to the SpeedDial button and it points to the corresponding content. |
| `aria-disabled` | It indicates the disabled state of the SpeedDial and its items. |

## Ensuring accessibility

The Blazor Speed Dial component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with playwright tests.

The accessibility compliance of the Blazor Speed Dial component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/speeddial) in a new window to evaluate the accessibility of the Blazor Speed Dial component with accessibility tools.

## See also

* [Accessibility in Syncfusion Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)