---
layout: post
title: Accessibility in Blazor DateTimePicker Component | Syncfusion
description: Learn about accessibility in the Syncfusion Blazor DateTimePicker, including WCAG/Section 508 compliance, WAI-ARIA roles and attributes, and keyboard navigation for date and time pickers.
platform: Blazor
control: DateTimePicker
documentation: ug
---

# Accessibility in Blazor DateTimePicker Component

Web accessibility ensures that web content and applications are usable by people with disabilities, especially where dynamic content and advanced UI components are involved.

The [Blazor DateTimePicker](https://www.syncfusion.com/blazor-components/blazor-datetime-picker) component follows accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/), and [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/) practices commonly used to evaluate accessibility.

The accessibility compliance for the Blazor DateTimePicker component is outlined below.

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

The DateTimePicker provides built-in compliance with [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/) specifications to convey role, state, and property information to assistive technologies.

Common roles and attributes include:
- Roles: combobox/textbox (for the input), dialog or popup container, grid for the calendar, and gridcell for individual dates.
- `aria-expanded`: Indicates whether the popup (calendar/time list) is open or closed on the input/combobox element.
- `aria-disabled`: Conveys the disabled state of the DateTimePicker.
- `aria-activedescendant`: Identifies the currently focused date cell within the calendar grid or the focused item in the time list.

To learn about the accessibility of Calendar, refer to the Calendar's [Accessibility](https://blazor.syncfusion.com/documentation/calendar/accessibility) section.

## Keyboard interaction

Use the following keys to interact with the Blazor DateTimePicker. This component implements keyboard navigation support by following the [WAI-ARIA practices](https://www.w3.org/WAI/ARIA/apg/).

Blazor DateTimePicker supports the below list of shortcut keys:

### Input navigation

Before opening the popup, use the following keys to control the popup element.

| Windows | Mac | Description |
| --- | --- | --- |
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | Opens the popup. |
| <kbd>Alt</kbd> + <kbd>↑</kbd> | <kbd>⌥</kbd> + <kbd>↑</kbd> | Closes the popup. |

### Calendar navigation

Use the following keys to interact with the Calendar after the DatePicker popup has opened:

| Windows | Mac | Description |
| --- | --- | --- |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Focuses the same day of the previous week. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Focuses the same day of the next week. |
| <kbd>←</kbd> | <kbd>←</kbd> | Focuses the previous day. |
| <kbd>→</kbd> | <kbd>→</kbd> | Focuses the next day. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | Focuses the first day of the month. |
| <kbd>End</kbd> | <kbd>End</kbd> | Focuses the last day of the month. |
| <kbd>Page Up</kbd> | <kbd>Page Up</kbd> | Focuses the same date of the previous month. |
| <kbd>Page Down</kbd> | <kbd>Page Down</kbd> | Focuses the same date of the next month. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Selects the currently focused date. |
| <kbd>Shift</kbd> + <kbd>Page Up</kbd> | <kbd>⇧</kbd> + <kbd>Page Up</kbd> | Focuses the same date in the previous year. |
| <kbd>Shift</kbd> + <kbd>Page Down</kbd> | <kbd>⇧</kbd> + <kbd>Page Down</kbd> | Focuses the same date in the next year. |
| <kbd>Ctrl</kbd> + <kbd>↑</kbd> | <kbd>⌘</kbd> + <kbd>↑</kbd> | Moves up one view (month → year, year → decade). |
| <kbd>Ctrl</kbd> + <kbd>↓</kbd> | <kbd>⌘</kbd> + <kbd>↓</kbd> | Moves down one view (decade → year, year → month). |
| <kbd>Ctrl</kbd> + <kbd>Home</kbd> | <kbd>⌘</kbd> + <kbd>Home</kbd> | Focuses the first date of the current year. |
| <kbd>Ctrl</kbd> + <kbd>End</kbd> | <kbd>⌘</kbd> + <kbd>End</kbd> | Focuses the last date of the current year. |

Use the following shortcut keys to interact with the TimePicker after the TimePicker popup has opened:

| Windows | Mac | Description |
| --- | --- | --- |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Navigates and selects the previous item. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Navigates and selects the next item. |
| <kbd>←</kbd> | <kbd>←</kbd> | Moves the cursor toward the arrow direction. |
| <kbd>→</kbd> | <kbd>→</kbd> | Moves the cursor toward the arrow direction. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | Navigates and selects the first item. |
| <kbd>End</kbd> | <kbd>End</kbd> | Navigates and selects the last item. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Selects the focused item and closes the popup. |
| <kbd>Alt</kbd> + <kbd>↑</kbd> | <kbd>⌥</kbd> + <kbd>↑</kbd> | Closes the popup. |
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | Opens the popup. |
| <kbd>Esc</kbd> | <kbd>Esc</kbd> | Closes the popup. |

N> The “t” key behavior in the following example is custom to the sample and not a built-in shortcut. For additional information about native events, see the [Native events](https://blazor.syncfusion.com/documentation/datetime-picker/native-events) topic.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateTimePicker TValue="DateTime?" @onkeypress="@(e => KeyPressed(e))" @ref="DateTimeObj"></SfDateTimePicker>

@code {
    public SfDateTimePicker<DateTime?> DateTimeObj;
    public void KeyPressed(KeyboardEventArgs args)
    {
        if (args.Key == "t")
        {
            this.DateTimeObj.FocusOutAsync();
        }
    }
}
```

## Ensuring accessibility

The Blazor DateTimePicker component’s accessibility levels are validated using the [axe-core](https://www.npmjs.com/package/axe-core) tool during automated testing.

The accessibility compliance of the DateTimePicker component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/datetimepicker) in a new window to evaluate the DateTimePicker component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> components](../common/accessibility)