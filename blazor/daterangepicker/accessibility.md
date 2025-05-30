---
layout: post
title: Accessibility in Blazor DateRangePicker Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor DateRangePicker component and more.
platform: Blazor
control: DateRangePicker
documentation: ug
---

# Accessibility in Blazor DateRangePicker Component

The [Blazor DateRangePicker](https://www.syncfusion.com/blazor-components/blazor-daterangepicker) component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor DateRangePicker component is outlined below.

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

The web accessibility makes web content and web applications more accessible for people with disabilities. It especially helps in dynamic content change and development of advanced user interface controls with AJAX, HTML, JavaScript, and related technologies. DateRangePicker provides built-in compliance with [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/) specifications. WAI-ARIA
support is achieved through the attributes like `aria-expanded`, `aria-disabled`, and `aria-activedescendant` applied as an input element.

To learn about the accessibility of Calendar, refer to the Calendar's [Accessibility](https://blazor.syncfusion.com/documentation/calendar/accessibility) section.

It helps people with disabilities by providing information about the widget for assistive technology in the screen readers. DateRangePicker component contains grid role and grid cell for each day cell.

* **aria-expanded**: Indicates the currently selected date of the DateRangePicker component.

* **aria-disabled**: Indicates the disabled state of the DateRangePicker component.

## Keyboard interaction

Use the following keys to interact with the DateRangePicker. This component implements the keyboard navigation support by following the  [WAI-ARIA practices](https://www.w3.org/WAI/ARIA/apg/).

It supports the following list of shortcut keys:

### Input navigation

Before opening the popup, use the following list of keys to control the popup element.

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | Opens the popup. |
| <kbd>Alt</kbd> + <kbd>↑</kbd> | <kbd>⌥</kbd> + <kbd>↑</kbd> | Closes the popup.|
| <kbd>Esc</kbd> | <kbd>Esc</kbd> | Closes the popup. |

### Calendar navigation

Use the following list of keys to navigate the currently focused Calendar after the popup has opened:

| Windows | Mac | Actions |
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
| <kbd>Shift</kbd> + <kbd>Page Up</kbd> | <kbd>⇧</kbd> + <kbd>Page Up</kbd> | Focuses the same date for the previous year. |
| <kbd>Shift</kbd> + <kbd>Page Down</kbd> | <kbd>⇧</kbd> + <kbd>Page Down</kbd> | Focuses the same date for the next year. |
| <kbd>Ctrl</kbd> + <kbd>Home</kbd> | <kbd>⌘</kbd> + <kbd>Home</kbd> | Focuses the first date of the current year. |
| <kbd>Ctrl</kbd> + <kbd>End</kbd> | <kbd>⌘</kbd> + <kbd>End</kbd> | Focuses the last date of the current year. |
| <kbd>Alt</kbd> + <kbd>→</kbd> | <kbd>⌥</kbd> + <kbd>→</kbd> | Focuses through out the pop-up container in forward direction. |
| <kbd>Alt</kbd> + <kbd>←</kbd> | <kbd>⌥</kbd> + <kbd>←</kbd> | Focuses through out the pop-up container in backward direction. |

N> To focus out the DateRangePicker component, use the `t` keys. For additional information about native event, [click](https://blazor.syncfusion.com/documentation/daterangepicker/native-events) here.

```cshtml
@using Syncfusion.Blazor.Calendars

<SfDateRangePicker TValue="DateTime?" @onkeypress="@(e => KeyPressed(e))" @ref="RangeObj"></SfDateRangePicker>

@code {
    public SfDateRangePicker RangeObj;
    public void KeyPressed(KeyboardEventArgs args)
    {
        if (args.Key == "t")
        {
            this.RangeObj.FocusOutAsync();
        }
    }
}
```

N> You can refer to our [Blazor Date Range Picker](https://www.syncfusion.com/blazor-components/blazor-daterangepicker) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Date Range Picker example](https://blazor.syncfusion.com/demos/daterangepicker/default-functionalities?theme=bootstrap4) to understand how to present and manipulate data.

## Ensuring accessibility

The Blazor DateRangePicker component's accessibility levels are ensured through an [axe-core](https://www.npmjs.com/package/axe-core) software tool during automated testing.

The accessibility compliance of the DateRangePicker component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/daterangepicker) in a new window to evaluate the accessibility of the DateRangePicker component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> components](../common/accessibility)