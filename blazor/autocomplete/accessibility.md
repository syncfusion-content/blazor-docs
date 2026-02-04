---
layout: post
title: Accessibility in Blazor AutoComplete Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor AutoComplete component and more.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Accessibility in Blazor AutoComplete Component

The [Blazor AutoComplete](https://www.syncfusion.com/blazor-components/blazor-autocomplete) component is designed with [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/) guidance in mind and applies semantic roles, states, and properties along with comprehensive keyboard support. It provides strong screen reader and keyboard navigation support to assist users of assistive technologies (AT) and those who rely on the keyboard.

The Blazor AutoComplete component follows accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/), and [WAI-ARIA](https://www.w3.org/TR/wai-aria/) specifications commonly used to evaluate accessibility.

The accessibility compliance for the Blazor AutoComplete component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | AAA |
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

The AutoComplete uses the `combobox` role for its input and the `listbox` role for its popup list; each list item has an `option` role. The following ARIA attributes convey state and relationships:

| **Property** | **Functionalities** |
| --- | --- |
| `aria-haspopup` | Indicates that the input (combobox) has an associated popup list. |
| `aria-expanded` | Reflects whether the popup list is open (`true`) or closed (`false`). |
| `aria-selected` | Indicates the selected option within the listbox. |
| `aria-readonly` | Indicates the read-only state of the input. |
| `aria-disabled` | Indicates whether the component is disabled. |
| `aria-activedescendant` | Identifies the ID of the active (focused) option within the listbox. |
| `aria-owns` | References the ID of the popup listbox the combobox controls. |
| `aria-autocomplete` | Indicates the autocomplete behavior; typically `list` or `both` when inline completion is shown along with a list. |

## Keyboard interaction

Use the following key shortcuts to operate the AutoComplete with the keyboard:

| Windows | Mac | Actions |
| --- | --- | --- |
|**Focus**| | |
|<kbd>Alt</kbd> + <kbd>J</kbd> | <kbd>⌥</kbd> + <kbd>J</kbd> | Focuses the first component in the sample. |
|**Input Navigation**| | |
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | Opens the popup list. |
| <kbd>Alt</kbd> + <kbd>↑</kbd> | <kbd>⌥</kbd> + <kbd>↑</kbd> | Closes the popup list. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Focuses on the next TabIndex element on the page when the popup is closed. Otherwise, closes the popup list and remains the focus of the component. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Focuses on the previous TabIndex element on the page when the popup is closed. Otherwise, closes the popup list and remains the focus of the component. |
|**Selection**| | |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Selects the focused item; when closed, toggles or confirms the value based on context. |
|**Popup Navigation**| | |
| <kbd>Esc</kbd> | <kbd>Escape</kbd> | Closes the popup list; the current selection remains unchanged. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | When no item is selected, moves to the first item; otherwise, moves to the next item. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Moves to the previous item. |
| <kbd>Page Down</kbd> | <kbd>Page Down</kbd> | Scrolls down a page and focuses the first visible item. |
| <kbd>Page Up</kbd> | <kbd>Page Up</kbd> | Scrolls up a page and focuses the first visible item. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | Moves focus to the first item. |
| <kbd>End</kbd> | <kbd>End</kbd> | Moves focus to the last item. |

N> In the following sample, pressing the <kbd>t</kbd> key toggles the disabled state of the AutoComplete. This is a sample-specific behavior, not a built-in shortcut.

{% highlight cshtml %}

{% include_relative code-snippet/accessibility/accessibility.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtLUCrMzKHwTMpln?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Ensuring accessibility

The Blazor AutoComplete component’s accessibility levels are validated using the [axe-core](https://www.npmjs.com/package/axe-core) tool during automated testing.

The accessibility compliance of the AutoComplete component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/autocomplete) in a new window to evaluate the AutoComplete component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> components](../common/accessibility)