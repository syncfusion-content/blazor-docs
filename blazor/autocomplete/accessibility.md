---
layout: post
title: Accessibility in Blazor AutoComplete Component | Syncfusion
description: Learn how the Syncfusion Blazor AutoComplete component implements accessibility, including WAI-ARIA roles and states, keyboard support, and compliance with WCAG and Section 508.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Accessibility in Blazor AutoComplete Component

The [Blazor AutoComplete](https://www.syncfusion.com/blazor-components/blazor-autocomplete) component is designed in accordance with the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/) specifications and applies appropriate WAI-ARIA roles, states, and properties alongside keyboard support. It provides complete keyboard interaction and ARIA support to assist users of assistive technologies (AT) and those who rely on keyboard navigation.

The Blazor AutoComplete component follows accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [ARIA roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor AutoComplete component is outlined below.

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

The Blazor AutoComplete component uses the `combobox` role and each list item has an `option` role. The following `ARIA Attributes` denotes the AutoComplete state:

| **Property** | **Functionalities** |
| --- | --- |
| `aria-haspopup`| Indicates whether the AutoComplete input element has a suggestion list or not. |
| `aria-expanded` | Indicates whether the suggestion list has expanded or not. |
| `aria-selected` | Indicates the selected option from the list. |
| `aria-readonly` | Indicates the readonly state of the AutoComplete element. |
| `aria-disabled` | Indicates whether the AutoComplete component is in disabled state or not.|
| `aria-activedescendent` | This attribute holds the ID of the active list item to focus its descendant child element. |
| `aria-owns` | This attribute contains the ID of the suggestion list to indicate popup as a child element. |
| `aria-autocomplete` | This attribute contains the ‘both’ to a list of options shows and the currently selected suggestion also shows inline. |

## Keyboard interaction

Use the following key shortcuts to access the AutoComplete. Some shortcuts (such as the initial focus hotkey) may be specific to the sample page.

| Windows | Mac | Actions |
| --- | --- | --- |
|**Focus**| | |
|<kbd>Alt</kbd> + <kbd>J</kbd> | <kbd>⌥</kbd> + <kbd>J</kbd> | Moves focus to the first component in the sample. |
|**Input Navigation**| | |
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | Opens the popup list. |
| <kbd>Alt</kbd> + <kbd>↑</kbd> | <kbd>⌥</kbd> + <kbd>↑</kbd> | Closes the popup list. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Moves focus to the next focusable element when the popup is closed; otherwise, closes the popup and retains focus on the component. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Moves focus to the previous focusable element when the popup is closed; otherwise, closes the popup and retains focus on the component. |
|**Selection**| | |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Selects the focused item. If the list is open, it closes after selection; otherwise, toggles the popup. |
|**Popup Navigation**| | |
| <kbd>Escape</kbd> | <kbd>Escape</kbd> | Closes the popup when it is open; the current selection remains unchanged. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Selects the first item when no item is selected; otherwise, moves to the next item. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Moves to the previous item. |
| <kbd>Page Down</kbd> | <kbd>Page Down</kbd> | Scrolls down one page and selects the first newly visible item when the popup is open. |
| <kbd>Page Up</kbd> | <kbd>Page Up</kbd> | Scrolls up one page and selects the first newly visible item when the popup is open. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | Selects the first item. |
| <kbd>End</kbd> | <kbd>End</kbd> | Selects the last item. |

N> In the following sample, press <kbd>T</kbd> to toggle the AutoComplete component’s disabled state.

{% highlight cshtml %}

{% include_relative code-snippet/accessibility/accessibility.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtLUCrMzKHwTMpln?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Ensuring accessibility

The Blazor AutoComplete component’s accessibility levels are validated using the [axe-core](https://www.npmjs.com/package/axe-core) tool during automated testing.

The accessibility compliance of the AutoComplete component is demonstrated in the following sample. Open the sample in a new window to evaluate the component with accessibility tools: [AutoComplete accessibility sample](https://blazor.syncfusion.com/accessibility/autocomplete).

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> components](../common/accessibility)