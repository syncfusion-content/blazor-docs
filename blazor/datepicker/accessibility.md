---
layout: post
title: Accessibility in Blazor DatePicker Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor DatePicker component and much more.
platform: Blazor
control: DatePicker
documentation: ug
---

# Accessibility in Blazor DatePicker Component

Web accessibility ensures that web content and applications are usable by people with disabilities. This is especially important for dynamic content and advanced UI components built with Ajax, HTML, and JavaScript.

The [Blazor DatePicker](https://www.syncfusion.com/blazor-components/blazor-datepicker) component follows accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/), and [WAI-ARIA roles](https://www.w3.org/TR/wai-aria/#roles) commonly used to evaluate accessibility.

The accessibility compliance for the Blazor DatePicker component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Right-to-left (RTL) support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
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

The Blazor DatePicker provides built-in compliance with the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/) specifications. Compliance is achieved through ARIA attributes such as `aria-expanded`, `aria-disabled`, and `aria-activedescendant` applied to the input, toggle button, and popup elements to convey state and relationships to assistive technologies.

To learn more about the accessibility of the Calendar component, refer to the Calendar [Accessibility](../calendar/accessibility) section.

These attributes expose the component’s state and behavior to assistive technologies used by people who rely on screen readers.

* **aria-expanded**: Indicates the expanded or collapsed state of the popup element.
* **aria-disabled**: Indicates the disabled state of the DatePicker component.
* **aria-activedescendant**: Identifies the currently active child element within the DatePicker popup.

## Keyboard interaction

Use the following keys to interact with the Blazor DatePicker. The component implements keyboard navigation support in line with the [WAI-ARIA practices](https://www.w3.org/WAI/ARIA/apg/).

It supports the following list of shortcut keys:

### Input navigation

Before opening the popup, use the following keys to control the popup element:

| Windows | Mac | Description |
| --- | --- | --- |
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | Opens the popup. |
| <kbd>Alt</kbd> + <kbd>↑</kbd> | <kbd>⌥</kbd> + <kbd>↑</kbd> | Closes the popup.|
| <kbd>Esc</kbd> | <kbd>Esc</kbd> | Closes the popup. |

### Calendar navigation

Use the following keys to navigate the calendar after the popup has been opened:

| Windows | Mac | Description |
| --- | --- | --- |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Focuses the previous week date. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Focuses the next week date. |
| <kbd>←</kbd> | <kbd>←</kbd> | Focuses the previous date. |
| <kbd>→</kbd> | <kbd>→</kbd> | Focuses the next date. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | Focuses the first date in the month. |
| <kbd>End</kbd> | <kbd>End</kbd> | Focuses the last date in the month. |
| <kbd>Page Up</kbd> | <kbd>Page Up</kbd> | Focuses the same date in the previous month. |
| <kbd>Page Down</kbd> | <kbd>Page Down</kbd> | Focuses the same date in the next month. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Selects the currently focused date. |
| <kbd>Shift</kbd> + <kbd>Page Up</kbd> | <kbd>⇧</kbd> + <kbd>Page Up</kbd> | Focuses the same date in the previous year. |
| <kbd>Shift</kbd> + <kbd>Page Down</kbd> | <kbd>⇧</kbd> + <kbd>Page Down</kbd> | Focuses the same date in the next year. |
| <kbd>Ctrl</kbd> + <kbd>↑</kbd> | <kbd>⌘</kbd> + <kbd>↑</kbd> | Moves to a higher-level view (month to year, year to decade). |
| <kbd>Ctrl</kbd> + <kbd>↓</kbd> | <kbd>⌘</kbd> + <kbd>↓</kbd> | Moves to a lower-level view (decade to year, year to month). |
| <kbd>Ctrl</kbd> + <kbd>Home</kbd> | <kbd>⌘</kbd> + <kbd>Home</kbd> | Focuses the starting date in the current year. |
| <kbd>Ctrl</kbd> + <kbd>End</kbd> | <kbd>⌘</kbd> + <kbd>End</kbd> | Focuses the ending date in the current year. |

N> To move focus out of the DatePicker component, press the `t` key. For details about handling native events in DatePicker, see [Native events in DatePicker](https://blazor.syncfusion.com/documentation/datepicker/native-events).

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDatePicker TValue="DateTime?" @onkeypress="@(e => KeyPressed(e))" @ref="DateObj"></SfDatePicker>

@code {
    public SfDatePicker<DateTime?> DateObj;
    public void KeyPressed(KeyboardEventArgs args)
    {
        if (args.Key == "t")
        {
            this.DateObj.FocusOutAsync();
        }
    }
}
```
## Ensuring accessibility

The Blazor DatePicker component's accessibility levels are validated using the [axe-core](https://www.npmjs.com/package/axe-core) tool during automated testing.

The accessibility compliance of the DatePicker component is demonstrated in the following sample. Open the [DatePicker accessibility sample](https://blazor.syncfusion.com/accessibility/datepicker) in a new window to evaluate the component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> components](../common/accessibility)