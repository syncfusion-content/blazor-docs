---
layout: post
title: Accessibility in Blazor Datetime Picker Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor Datetime Picker component and more.
platform: Blazor
control: Datetime Picker 
documentation: ug
---

# Accessibility in Blazor Datetime Picker Component

The web accessibility defines a way to make web content and web applications more accessible to disabled people. It especially helps the dynamic content change and advanced user interface components developed with Ajax, HTML, JavaScript, and related technologies.

DateTimePicker provides built-in compliance with the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/) specifications. WAI-ARIA support is achieved through the attributes like `aria-expanded`, `aria-disabled`, `aria-activedescendant` applied to the input element.

To learn about the accessibility of Calendar, refer to the Calendar's [Accessibility](../calendar/accessibility) section.

It helps to provide information about the widget for assistive technology to the disabled person in screen reader.

* **aria-expanded**: Attribute indicates the state of a collapsible element.

* **aria-disabled**: Attribute indicates the disabled state of this DateTimePicker component.

* **aria-activedescendent**: Attribute helps in managing the current active child of the DateTimePicker component.

## Keyboard interaction

You can use the following keys to interact with the DateTimePicker. The component implements the keyboard navigation support by following the [WAI-ARIA practices](https://www.w3.org/WAI/ARIA/apg/).

DateTimePicker supports the below list of shortcut keys:

### Input navigation

Before opening the popup, use the following keys to control the popup element.

| **Keys** | **Description** |
| --- | --- |
| <kbd>Alt +  Down Arrow</kbd> | Opens the select popup |
| <kbd>Alt +  Down Arrow + Alt +  Down Arrow </kbd> | Toggles between two popups |

### Calendar navigation

Use the following keys to interact with the Calendar after the DatePicker popup has opened:

| **Keys** | **Description** |
| --- | --- |
| <kbd>Upper Arrow</kbd>  | Focuses the previous week date. |
| <kbd>Down Arrow</kbd>  | Focuses the next week date. |
| <kbd>Left Arrow</kbd>  | Focuses the previous date. |
| <kbd>Right Arrow</kbd>  | Focuses the next date. |
| <kbd>Home</kbd>  | Focuses the first date in the month. |
| <kbd>End</kbd>  | Focuses the last date in the month. |
| <kbd>Page Up</kbd>  | Focuses the same date in the previous month. |
| <kbd>Page Down</kbd>  | Focuses the same date in the next month. |
| <kbd>Enter</kbd>  | Selects the currently focused date. |
| <kbd>Shift + Page Up</kbd>  | Focuses the same date in the previous year. |
| <kbd>Shift + Page Down</kbd>  | Focuses the same date in the previous year. |
| <kbd>Control + Upper Arrow</kbd>  | Moves into the inner level of view like month-year, year-decade |
| <kbd>Control + Down Arrow</kbd>  | Moves out from the depth level view like decade-year, year-month |
| <kbd>Control +Home</kbd>  | Focuses the starting date in the current year. |
| <kbd>Control +End</kbd>  | Focuses the ending date in the current year. |

Use the following shortcut keys to interact with the TimePicker after the TimePicker Popup has opened:

| **Keys** | **Description** |
| --- | --- |
| <kbd>Upper Arrow</kbd> | Navigates and selects the previous item. |
| <kbd>Down Arrow</kbd> | Navigates and selects the next item. |
| <kbd>Left Arrow</kbd> | Moves the cursor towards arrow key pressed direction. |
| <kbd>Right Arrow</kbd> | Moves the cursor towards arrow key pressed direction. |
| <kbd>Home</kbd> | Navigates and selects the first item. |
| <kbd>End</kbd> | Navigates and selects the last item. |
| <kbd>Enter</kbd> | Selects the currently focused item and close the popup. |
| <kbd>Alt + Upper Arrow</kbd> | Closes the popup. |
| <kbd>Alt + Down Arrow</kbd> | Opens the popup. |
| <kbd>Esc</kbd> | Closes the popup. |

N> To focus out the DateTimePicker component, use the `t` keys. For additional information about native event, [click](./native-events/) here.

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
