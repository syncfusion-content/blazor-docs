---
layout: post
title: Accessibility in Blazor ListBox Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor ListBox component and much more.
platform: Blazor
control: List Box
documentation: ug
---

# Accessibility in Blazor ListBox Component

The Blazor ListBox component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), and [WCAG 2.2](https://www.w3.org/TR/WCAG22/). It also implements appropriate  [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) to support assistive technologies.

The following table summarizes the accessibility compliance of the Blazor ListBox component.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | AAA |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Meets requirement"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Meets requirement">  |
| [Right-to-left support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Meets requirement"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Meets requirement"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Meets requirement"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) |<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Meets requirement"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Meets requirement"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Meets requirement"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/intermediate.png" alt="Partially meets requirement"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/no.png" alt="Does not meet requirement"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

The Blazor ListBox component follows the [WAI-ARIA listbox pattern](https://www.w3.org/WAI/ARIA/apg/patterns/listbox/) to meet accessibility requirements. The following ARIA attributes are used in the Blazor ListBox component:

| Attributes | Purpose |
| --- | --- |
| `role` | Indicates the ListBox component wrapper element as `listbox`, the `ul` element as `presentation`, and each list item as `option`. |
| `aria-label` | Provides an accessible name for the ListBox component. |
| `aria-multiselectable` | Applied to the element with the `listbox` role to indicate that multiple selection is supported. This is applied when multiple selection is enabled (default behavior). |
| `aria-selected` | Applied to elements with the `option` role that are visually styled as selected to inform assistive technologies that the options are selected. |

## Keyboard interaction

The Blazor ListBox component follows the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/listbox/#keyboardinteraction) guidelines, supporting users of assistive technologies and those who rely on keyboard navigation. The following keyboard shortcuts are supported by the Blazor ListBox component.
| Windows | Mac| Actions |
| --- | --- | --- |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Moves focus to the previous option. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Moves focus to the next option. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | Moves focus to the first option. |
| <kbd>End</kbd> | <kbd>End</kbd> | Moves focus to the last option. |
| <kbd>Space</kbd> | <kbd>Space</kbd> | Toggles the selection state of the focused option. |
| <kbd>Ctrl + A</kbd> | <kbd>⌘</kbd> + <kbd>A</kbd> | Selects all options in the list. |
| <kbd>Ctrl + Shift + Home</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>Home</kbd> | Selects the focused option and all options up to the first option. |
| <kbd>Ctrl + Shift + End</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>End</kbd> | Selects the focused option and all options down to the last option. |
| <kbd>Ctrl</kbd> + <kbd>↑</kbd> or <kbd>↓</kbd> | <kbd>⌘</kbd> + <kbd>↑</kbd> or <kbd>↓</kbd> | Moves focus without changing the current selection. Use Ctrl/Cmd with mouse click to toggle individual items. |

## Ensuring accessibility

The Blazor ListBox component's accessibility levels are validated using [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with Playwright tests.

The accessibility compliance of the Blazor ListBox component is demonstrated in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/listbox) in a new window to evaluate the component with accessibility tools.

{% previewsample "https://ej2.syncfusion.com/accessibility/list-box.html" %}

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)