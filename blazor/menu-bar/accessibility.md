---
layout: post
title: Accessibility in Blazor Menu Bar | Syncfusion
description: Learn how Blazor Menu Bar supports accessibility standards including keyboard navigation, screen readers, and ARIA roles.
platform: Blazor
control: Menu Bar
documentation: ug
---

# Accessibility in Blazor Menu Bar

The Blazor Menu Bar component follows the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The following table summarizes the Blazor Menu Bar component's accessibility compliance.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | AA |
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

The Blazor Menu Bar component follows the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/menubar/) patterns to meet the accessibility requirements. The following ARIA attributes are used in the Blazor Menu Bar component:

| Attributes | Purpose |
| --- | --- |
| `role` | Identifies the Menu Bar's root as `menubar`, the popup as `menu`, and each popup item as `menuitem`. |
| `aria-haspopup` | Indicates the availability and type of interactive popup element. |
| `aria-expanded` | Indicates whether the subtree is expanded or collapsed. |
| `aria-orientation` | Indicates whether the orientation is horizontal or vertical. The default orientation is horizontal. |
| `aria-label` | Provides an accessible name for the menu item. |
| `aria-disabled` | Indicates whether the menu item is disabled. |

## Keyboard interaction

The Blazor Menu Bar component follows the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/menubar/#keyboardinteraction) guideline, making it easy for people who use assistive technologies (AT) and those who completely rely on keyboard navigation. The following keyboard shortcuts are supported by the Blazor Menu Bar component.

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>Esc</kbd> | <kbd>Esc</kbd> | Closes the submenu that contains focus and returns focus to the parent element. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Opens the submenu if the focused menu item has one and places focus on its first item; otherwise, activates the item and closes the submenu. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Navigates to the previous menu item. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Navigates to the next menu item. |
| <kbd>←</kbd> | <kbd>←</kbd> | When a submenu is open, closes it and returns focus to the parent menu item. When focus is on a root menu item, moves focus to the previous root menu item. |
| <kbd>→</kbd> | <kbd>→</kbd> | When focus is on a root menu item that has a submenu, opens that submenu. When focus is on a root menu item without a submenu, moves focus to the next root menu item. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | Moves focus to the first menu item. |
| <kbd>End</kbd> | <kbd>End</kbd> | Moves focus to the last menu item. |

## Ensuring accessibility

The Blazor Menu Bar component's accessibility is validated with the [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) accessibility engine through Playwright tests.

The accessibility compliance of the Blazor Menu Bar component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/menu) in a new window to evaluate the accessibility of the Blazor Menu Bar component with accessibility tools.

{% previewsample "https://blazor.syncfusion.com/accessibility/menu" %}

## See also

* [Accessibility in Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)