---
layout: post
title: Accessibility in Blazor SpeedDial Component | Syncfusion
description: Checkout and learn here all about accessibility and keyboard in Syncfusion Speed Dial component and much more.
platform: Blazor
control: SpeedDial
documentation: ug
---

# Accessibility in Blazor Speed Dial component

The Blazor Speed Dial component follows accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Speed Dial component is outlined below. The badges indicate whether each criterion is fully supported.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | AAA |
| [Section 508 Support](../common/accessibility#accessibility-standards) |<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Meets requirement"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Meets requirement"> |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Meets requirement"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Meets requirement"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Meets requirement"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Meets requirement"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Meets requirement"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partially meets requirement"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="Does not meet requirement"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

The Blazor Speed Dial component follows relevant [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/menubar/) patterns to meet accessibility requirements. The following ARIA attributes are used in the Blazor Speed Dial component:

| Attributes | Purpose  |
| ------------ | ----------------------- |
| `role=menu` | Identifies the popup that contains the Speed Dial action items. |
| `role=menuitem` | Identifies an actionable item within the Speed Dial popup. |
| `aria-label` | Provides an accessible name for the Speed Dial popup or items. |
| `aria-expanded` | Indicates whether the Speed Dial popup is expanded or collapsed. |
| `aria-haspopup` | Indicates that the trigger button opens a popup with menu items. |
| `aria-controls` | References the popup element controlled by the trigger button. |
| `aria-disabled` | Indicates that a menu item is disabled and unavailable for interaction. |

## Keyboard interaction

The Blazor Speed Dial component follows the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/menubar/#keyboardinteraction) guidelines, making it accessible for users of assistive technologies and those who rely on keyboard navigation. The following keyboard shortcuts are supported:

| Windows | Mac | Actions |
|------------|-------------------| --- |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Open/close the menu. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Focuses the next menu item. |
| <kbd>←</kbd> | <kbd>←</kbd> | Focuses the previous menu item. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Focuses the previous menu item. |
| <kbd>→</kbd> | <kbd>→</kbd> | Focuses the next menu item. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | Focuses the first menu item. |
| <kbd>End</kbd> | <kbd>End</kbd> | Focuses the last menu item. |
| <kbd>Esc</kbd> | <kbd>Esc</kbd> | Closes the menu. |

## Ensuring accessibility

The Blazor Speed Dial component’s accessibility is validated using [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with Playwright-based automated tests.

The accessibility compliance of the Blazor Speed Dial component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/speeddial) in a new window to evaluate the accessibility of the Blazor Speed Dial component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)