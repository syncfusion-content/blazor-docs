---
layout: post
title:  Accessibility in Blazor TimePicker Component | Syncfusion
description: Checkout and learn here all about  Accessibility in Syncfusion Blazor TimePicker component and more.
platform: Blazor
control: TimePicker
documentation: ug
---

#  Accessibility in Blazor TimePicker Component

The web accessibility makes web applications and its content more accessible to people with disabilities
without any barriers. It especially
tracks the dynamic value changes and DOM changes.

The TimePicker component has covered the [WAI-ARIA](http://www.w3.org/WAI/PF/aria-practices)
specifications with the following list of WAI-ARIA
attributes: `aria-haspopup`, `aria-selected`, `aria-disabled`, `aria-activedescendant`,
`aria-expanded`, `aria-owns`, and `aria-autocomplete`.

In TimePicker, the `combobox` plays the role of input element, and the `listbox` plays the role of popup element.

* **aria-haspopup**: Provides the information about whether this element display a pop-up window or not.

* **aria-selected**: Indicates the current selected value of the TimePicker component.

* **aria-disabled**: Indicates disabled state of the TimePicker component.

* **aria-expanded**: Indicates the expanded state of the popup.

* **aria-autocomplete**: Indicates whether user input completion suggestions are provided or not.

* **aria-owns**: Creates a parent/child relationship between two DOM element in the accessibility layer.

* **aria-activedescendent**: Helps in managing the current active child of the TimePicker component.

* **role**: Gives assistive technology information for handling each element in a widget.

## Keyboard interaction

Keyboard accessibility is one of the most important aspects of web accessibility. Disabled people like blind and those who have motor disabilities or birth defects use keyboard shortcuts more than the mouse.

The TimePicker component has built-in keyboard accessibility support by following the
[WAI-ARIA practices](http://www.w3.org/WAI/PF/aria-practices).

> It supports the following list of shortcut keys to interact with the TimePicker component:

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

> To focusout the TimePicker component, use the `t` keys. For additional information about native event, [click](./native-events/) here.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfTimePicker TValue="DateTime?" @onkeypress="@(e => KeyPressed(e))" @ref="TimeObj"></SfTimePicker>

@code {
    public SfTimePicker<DateTime?> TimeObj;
    public void KeyPressed(KeyboardEventArgs args)
    {
        if (args.Key == "t")
        {
            this.TimeObj.FocusOutAsync();
        }
    }
}
```