---
layout: post
title:  Accessibility in Blazor TimePicker Component | Syncfusion
description: Checkout and learn here all about the accessibility in Syncfusion Blazor TimePicker component and much more.
platform: Blazor
control: TimePicker
documentation: ug
---

#  Accessibility in Blazor TimePicker Component

Web accessibility ensures that applications and their content are usable by people with disabilities. It includes support for dynamic value updates and DOM changes that assistive technologies can detect.

The [Blazor TimePicker](https://www.syncfusion.com/blazor-components/blazor-timepicker) follows widely recognized accessibility standards and guidelines, including the Americans with Disabilities Act[ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WAI-ARIA  roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor TimePicker is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |
| [Color Contrast](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>
<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partially meets requirement"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="Does not meet requirement"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

The Blazor TimePicker aligns with [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/) practices. The input is presented with a `role="combobox"` and the popup list with a `role="listbox"`. Depending on configuration, the component may include the following ARIA attributes: `aria-haspopup`, `aria-selected`, `aria-disabled`, `aria-activedescendant`, `aria-expanded`, `aria-owns`, and `aria-autocomplete`.

In the TimePicker, the `combobox` plays the role of input element, and the `listbox` plays the role of popup element.

* **aria-haspopup**: Provides the information about whether this element display a pop-up window or not.

* **aria-selected**: Indicates the current selected value of the TimePicker component.

* **aria-disabled**: Indicates disabled state of the TimePicker component.

* **aria-expanded**: Indicates the expanded state of the popup.

* **aria-autocomplete**: Indicates whether user input completion suggestions are provided or not.

* **aria-owns**: Creates a parent/child relationship between two DOM element in the accessibility layer.

* **aria-activedescendent**: Helps in managing the current active child of the TimePicker component.

* **role**: Gives assistive technology information for handling each element in a widget.

## Keyboard interaction

Keyboard accessibility enables efficient interaction without a mouse and is essential for users who rely on keyboards or assistive technologies.

The Blazor TimePicker includes built-in keyboard support following the [WAI-ARIA practices](https://www.w3.org/WAI/ARIA/apg/).

N> It supports the following shortcut keys to interact with the TimePicker:

| Windows | Mac | **Description** |
| --- | --- | --- |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Navigates and selects the previous item. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Navigates and selects the next item. |
| <kbd>←</kbd> | <kbd>←</kbd> | Moves the cursor in the direction of the arrow key pressed. |
| <kbd>→</kbd> | <kbd>→</kbd> | Moves the cursor in the direction of the arrow key pressed. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | Navigates and selects the first item. |
| <kbd>End</kbd> | <kbd>End</kbd> | Navigates and selects the last item. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Selects the currently focused item and closes the popup. |
| <kbd>Alt</kbd> + <kbd>↑</kbd> | <kbd>⌥</kbd> + <kbd>↑</kbd> | Closes the popup. |
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | Opens the popup. |
| <kbd>Esc</kbd> | <kbd>Esc</kbd> | Closes the popup. |

N> To move focus out of the TimePicker, press the `t` key. For additional information about handling native events, see the [native events documentation](https://blazor.syncfusion.com/documentation/timepicker/native-events).

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

## Ensuring accessibility

The Blazor TimePicker’s accessibility is validated using the [axe-core](https://www.npmjs.com/package/axe-core) tool during automated testing.

The accessibility compliance of the TimePicker is demonstrated in the following sample. Open the [TimePicker accessibility sample](https://blazor.syncfusion.com/accessibility/timepicker) in a new window to evaluate the component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> components](../common/accessibility)