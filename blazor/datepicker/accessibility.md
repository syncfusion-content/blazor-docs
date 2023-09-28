---
layout: post
title: Accessibility in Blazor DatePicker Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor DatePicker component and much more.
platform: Blazor
control: DatePicker
documentation: ug
---

# Accessibility in Blazor DatePicker Component

The web accessibility defines a way to make web content and web applications more accessible to disabled people. It especially helps the dynamic content change and advanced user interface components developed with Ajax, HTML, JavaScript, and related technologies.

The DatePicker provides built-in compliance with the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/) specifications. WAI-ARIA supports can be achieved through the attributes like `aria-expanded`, `aria-disabled`, and `aria-activedescendant` applied to the input element.

To learn more about the accessibility of Calendar, refer to the Calendar's [Accessibility](../calendar/accessibility/) section.

It provides information about the widget for assistive technology to the disabled person in screen reader.

* **aria-expanded**: Attribute indicates the state of a collapsible element.

* **aria-disabled**: Attribute indicates the disabled state of this DatePicker component.

* **aria-activedescendent**: Attribute helps in managing the current active child of the DatePicker component.

## Keyboard interaction

You can use the following keys to interact with the DatePicker. The component implements the keyboard navigation support by following the [WAI-ARIA practices](https://www.w3.org/WAI/ARIA/apg/).

It supports the following list of shortcut keys:

### Input navigation

Before opening the pop-up, use the following list of keys to control the pop-up element:

| **Keys** | **Description** |
| --- | --- |
| <kbd>Alt +  Down Arrow</kbd> | Opens the popup. |
| <kbd>Alt +  Upper Arrow</kbd> | Closes the popup.|
| <kbd>Esc</kbd> | Closes the popup. |

### Calendar navigation

Use the following list of keys to navigate the Calendar after the pop-up has been opened:

| **keys** | **Description** |
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
| <kbd>Control + Upper Arrow</kbd>  | Moves into the inner level of view like month-year and year-decade |
| <kbd>Control + Down Arrow</kbd>  | Moves out from the depth level view like decade-year and year-month |
| <kbd>Control +Home</kbd>  | Focuses the starting date in the current year. |
| <kbd>Control +End</kbd>  | Focuses the ending date in the current year. |

N> To focus out the DatePicker component, use the `t` keys. For additional information about native event, [click](./native-events/) here.

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
