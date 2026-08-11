---
layout: post
title:  Accessibility in Blazor TimePicker Component | Syncfusion®
description: Checkout and learn here all the features about the accessibility in Blazor TimePicker component and much more.
platform: Blazor
control: TimePicker
documentation: ug
---

#  Accessibility in Blazor TimePicker Component

Web accessibility makes web applications and their content more accessible to people with disabilities by removing barriers that can prevent interaction. The TimePicker is designed to surface dynamic value changes and DOM updates to assistive technologies in a predictable way.

The [Blazor TimePicker](https://www.syncfusion.com/blazor-components/blazor-timepicker) component follows accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor TimePicker component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | AA |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
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

The Blazor TimePicker component has covered the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/) specifications with the following list of WAI-ARIA attributes: `aria-haspopup`, `aria-selected`, `aria-disabled`, `aria-activedescendant`, `aria-expanded`, `aria-owns`, and `aria-autocomplete`.

In the TimePicker, the `combobox` plays the role of the input element, and the `listbox` plays the role of the popup element. For the full pattern specification, see the [WAI-ARIA Combobox Pattern](https://www.w3.org/WAI/ARIA/apg/patterns/combobox/).

* **aria-haspopup**: Indicates whether this element displays a pop-up window.

* **aria-selected**: Indicates the current selected value of the TimePicker component.

* **aria-disabled**: Indicates the disabled state of the TimePicker component.

* **aria-expanded**: Indicates the expanded state of the popup.

* **aria-autocomplete**: Indicates whether input completion suggestions are provided to the user.

* **aria-owns**: Creates a parent/child relationship between two DOM elements in the accessibility layer.

* **aria-activedescendant**: Helps in managing the current active child of the TimePicker component.

* **role**: Gives assistive technology information for handling each element in a widget.

## Keyboard interaction

Keyboard accessibility is one of the most important aspects of web accessibility. Many users, including people who are blind, have low vision, or have motor disabilities, rely on keyboard shortcuts rather than the mouse to interact with applications.

The Blazor TimePicker component has built-in keyboard accessibility support that follows the [WAI-ARIA Authoring Practices](https://www.w3.org/WAI/ARIA/apg/) for a combobox pattern.

N> The following table lists the built-in shortcut keys supported by the TimePicker component:

| Windows | Mac | **Description** |
| --- | --- | --- |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Navigates and selects the previous item. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Navigates and selects the next item. |
| <kbd>←</kbd> | <kbd>←</kbd> | Moves the cursor in the direction of the pressed arrow key. |
| <kbd>→</kbd> | <kbd>→</kbd> | Moves the cursor in the direction of the pressed arrow key. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | Navigates and selects the first item. |
| <kbd>End</kbd> | <kbd>End</kbd> | Navigates and selects the last item. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Selects the currently focused item and closes the popup. |
| <kbd>Alt</kbd> + <kbd>↑</kbd> | <kbd>⌥</kbd> + <kbd>↑</kbd> | Closes the popup. |
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | Opens the popup. |
| <kbd>Esc</kbd> | <kbd>Esc</kbd> | Closes the popup. |

N> The example below wires a native `onkeypress` event so that pressing the `t` key calls `FocusOutAsync()`. The `t` key is only the key checked in the sample handler and is not a built-in TimePicker shortcut — replace `"t"` in the handler to use a different key. For more information, see [Native Events in Blazor TimePicker](https://blazor.syncfusion.com/documentation/timepicker/native-events).

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

The Blazor TimePicker component's accessibility is verified through the [axe-core](https://www.npmjs.com/package/axe-core) software tool during automated testing.

The following sample demonstrates the accessibility compliance of the Blazor TimePicker component. Open the [sample](https://blazor.syncfusion.com/accessibility/timepicker) in a new window to evaluate the accessibility of the Blazor TimePicker component with accessibility tools.

## See also

* [Accessibility in Blazor components](../common/accessibility)
* [WAI-ARIA Authoring Practices Guide](https://www.w3.org/WAI/ARIA/apg/)
* [WCAG 2.2 Quick Reference](https://www.w3.org/WAI/WCAG22/quickref/)