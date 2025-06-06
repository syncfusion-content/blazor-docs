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

The [Blazor DatePicker](https://www.syncfusion.com/blazor-components/blazor-datepicker) component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor DatePicker component is outlined below.

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

The Blazor DatePicker provides built-in compliance with the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/) specifications. WAI-ARIA supports can be achieved through the attributes like `aria-expanded`, `aria-disabled`, and `aria-activedescendant` applied to the input element.

To learn more about the accessibility of Calendar, refer to the Calendar's [Accessibility](../calendar/accessibility) section.

It provides information about the widget for assistive technology to the disabled person in screen reader.

* **aria-expanded**: Attribute indicates the state of a collapsible element.

* **aria-disabled**: Attribute indicates the disabled state of this DatePicker component.

* **aria-activedescendent**: Attribute helps in managing the current active child of the DatePicker component.

## Keyboard interaction

You can use the following keys to interact with the Blazor DatePicker. The component implements the keyboard navigation support by following the [WAI-ARIA practices](https://www.w3.org/WAI/ARIA/apg/).

It supports the following list of shortcut keys:

### Input navigation

Before opening the pop-up, use the following list of keys to control the pop-up element:

| Windows | Mac | Description |
| --- | --- | --- |
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | Opens the popup. |
| <kbd>Alt</kbd> + <kbd>↑</kbd> | <kbd>⌥</kbd> + <kbd>↑</kbd> | Closes the popup.|
| <kbd>Esc</kbd> | <kbd>Esc</kbd> | Closes the popup. |

### Calendar navigation

Use the following list of keys to navigate the Calendar after the pop-up has been opened:

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
| <kbd>Shift</kbd> + <kbd>Page Down</kbd> | <kbd>⇧</kbd> + <kbd>Page Down</kbd> | Focuses the same date in the previous year. |
| <kbd>Ctrl</kbd> + <kbd>↑</kbd> | <kbd>⌘</kbd> + <kbd>↑</kbd> | Moves into the inner level of view like month-year and year-decade |
| <kbd>Ctrl</kbd> + <kbd>↓</kbd> | <kbd>⌘</kbd> + <kbd>↓</kbd> | Moves out from the depth level view like decade-year and year-month |
| <kbd>Control</kbd> + <kbd>Home</kbd> | <kbd>⌘</kbd> | Focuses the starting date in the current year. |
| <kbd>Ctrl</kbd> + <kbd>End</kbd> | <kbd>⌘</kbd> + <kbd>End</kbd> | Focuses the ending date in the current year. |

N> To focus out the DatePicker component, use the `t` keys. For additional information about native event, [click](https://blazor.syncfusion.com/documentation/datepicker/native-events) here.

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

The Blazor DatePicker component's accessibility levels are ensured through an [axe-core](https://www.npmjs.com/package/axe-core) software tool during automated testing.

The accessibility compliance of the DatePicker component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/datepicker) in a new window to evaluate the accessibility of the DatePicker component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> components](../common/accessibility)