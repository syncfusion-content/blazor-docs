---
layout: post
title: Accessibility in Blazor Calendar Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor Calendar component and much more.
platform: Blazor
control: Calendar
documentation: ug
---

# Accessibility in Blazor Calendar Component

The web accessibility makes web content and web applications more accessible for disabled people. It especially helps in dynamic content change and development of advanced user interface components with AJAX, HTML, JavaScript, and related technologies.

The [Blazor Calendar](https://www.syncfusion.com/blazor-components/blazor-calendar) component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Calendar component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |

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


Blazor Calendar provides built-in compliance with [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/) specifications. WAI-ARIA support is achieved through attributes like `aria-label`, `aria-selected`, `aria-disabled`, and `aria-activedescendant` applied for navigation buttons, and disable and active day cells.

It helps disabled persons by providing information about the widget for assistive technology in the screen readers. Calendar component contains grid role and grid cell for each day cell.

* **aria-label**: Provides text labels for an object for the previous and next month's elements. It helps the screen reader object to read.

* **aria-selected**: Indicates the currently selected date of the Calendar component.

* **aria-disabled**: Indicates the disabled state of the Calendar component.

* **aria-activedescendent**: Helps in managing the current active child of the Calendar component.

* **role**: Gives information to assistive technologies about how to handle each element in a widget.

* **grid-cell**: Defines the individual cell that can be focused and selected.

## Keyboard interaction

You can use the following keys to interact with the Calendar. This control implements keyboard navigation support by following the [WAI-ARIA practices](https://www.w3.org/WAI/ARIA/apg/).

It supports the following list of shortcut keys:

| **Keys** | **Description** |
| --- | --- |
| <kbd>Upper Arrow</kbd>  | Focuses the same day of the previous week. |
| <kbd>Down Arrow</kbd>  | Focuses the same day of the next week. |
| <kbd>Left Arrow</kbd>  | Focuses the previous day. |
| <kbd>Right Arrow</kbd>  | Focuses the next day. |
| <kbd>Home</kbd>  | Focuses the first day of the month. |
| <kbd>End</kbd>  | Focuses the last day of the month. |
| <kbd>Page Up</kbd>  | Focuses the same date of the previous month. |
| <kbd>Page Down</kbd>  | Focuses the same date of the next month. |
| <kbd>Enter</kbd>  | Selects the currently focused date. |
| <kbd>Shift + Page Up</kbd>  | Focuses the same date for the previous year. |
| <kbd>Shift + Page Down</kbd>  | Focuses the same date for the next year. |
| <kbd>Control + Upper Arrow</kbd>  | Moves to the inner level of view like month to year and year to decade. |
| <kbd>Control + Down Arrow</kbd>  | Moves out from the depth level view like decade to year and year to month. |
| <kbd>Control + Home</kbd>  | Focuses the first date of the current year. |
| <kbd>Control + End</kbd>  | Focuses the last date of the current year. |

## Ensuring accessibility

The Blazor Calendar component's accessibility levels are ensured through an [axe-core](https://www.npmjs.com/package/axe-core) software tool during automated testing.

The accessibility compliance of the Calendar component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/calendar) in a new window to evaluate the accessibility of the Calendar component with accessibility tools.

## See also

* [Accessibility in Syncfusion components](../common/accessibility)