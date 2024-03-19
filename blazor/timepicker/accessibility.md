---
layout: post
title:  Accessibility in Blazor TimePicker Component | Syncfusion
description: Checkout and learn here all about the accessibility in Syncfusion Blazor TimePicker component and much more.
platform: Blazor
control: TimePicker
documentation: ug
---

#  Accessibility in Blazor TimePicker Component

The web accessibility makes web applications and its content more accessible to people with disabilities without any barriers. It especially tracks the dynamic value changes and DOM changes.

The TimePicker component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the TimePicker component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Accessibility Checker Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
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

The TimePicker component has covered the [WAI-ARIA](https://www.w3.org/TR/wai-aria-practices/) specifications with the following list of WAI-ARIA attributes: `aria-haspopup`, `aria-selected`, `aria-disabled`, `aria-activedescendant`, `aria-expanded`, `aria-owns`, and `aria-autocomplete`.

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

Keyboard accessibility is one of the most important aspects of web accessibility. Disabled people like blind and those who have motor disabilities or birth defects use keyboard shortcuts more than the mouse.

The TimePicker component has built-in keyboard accessibility support by following the [WAI-ARIA practices](https://www.w3.org/TR/wai-aria-practices/).

N> It supports the following list of shortcut keys to interact with the TimePicker component:

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

N> To focusout the TimePicker component, use the `t` keys. For additional information about native event, [click](./native-events/) here.

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

The TimePicker component's accessibility levels are ensured through an [accessibility-checker](https://www.npmjs.com/package/accessibility-checker) and [axe-core](https://www.npmjs.com/package/axe-core) software tools during automated testing.

The accessibility compliance of the TimePicker component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/timepicker) in a new window to evaluate the accessibility of the TimePicker component with accessibility tools.

{% previewsample "https://blazor.syncfusion.com/accessibility/timepicker" %}

## See also

* [Accessibility in Syncfusion components](../common/accessibility)