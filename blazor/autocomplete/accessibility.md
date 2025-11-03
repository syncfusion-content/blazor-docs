---
layout: post
title: Accessibility in Blazor AutoComplete Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor AutoComplete component and more.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Accessibility in Blazor AutoComplete Component

The [Blazor AutoComplete](https://www.syncfusion.com/blazor-components/blazor-autocomplete) component has been designed, keeping in mind the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/) specifications, and applies the `WAI-ARIA` roles, states, and properties along with `keyboard support`. This component is characterized by complete keyboard interaction support and ARIA accessibility support that makes it easy for people who use assistive technologies (AT) or those who completely rely on keyboard navigation.

The Blazor AutoComplete component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

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

You can use the following key shortcuts to access the AutoComplete without interruptions:

| Windows | Mac | Actions |
| --- | --- | --- |
|**Focus**| | |
|<kbd>Alt</kbd> + <kbd>J</kbd> | <kbd>⌥</kbd> + <kbd>J</kbd> | Focuses on the first component of the sample. |
|**Input Navigation**| | |
| <kbd>Alt</kbd> +<kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | Opens the popup list. |
| <kbd>Alt</kbd> + <kbd>↑</kbd> | <kbd>⌥</kbd> + <kbd>↑</kbd> | Closes the popup list. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Focuses on the next TabIndex element on the page when the popup is closed. Otherwise, closes the popup list and remains the focus of the component. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Focuses on the previous TabIndex element on the page when the popup is closed. Otherwise, closes the popup list and remains the focus of the component. |
|**Selection**| | |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Selects the focused item, and when it is in open state, the popup list closes. Otherwise, toggles the popup list. |
|**Popup Navigation**| | |
| <kbd>Esc(Escape)</kbd> | <kbd>Escape</kbd> | Closes the popup list when it is in an open state and the currently selected item remains the same. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Selects the first item in the AutoComplete when no item is selected. Otherwise, selects the item next to the currently selected item. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Selects the item previous to the currently selected one. |
| <kbd>Page down</kbd> | <kbd>Page down</kbd> | Scrolls down to the next page and selects the first item when the popup list opens. |
| <kbd>Page up</kbd> | <kbd>Page up</kbd> | Scrolls up to the previous page and selects the first item when the popup list opens. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | Selects the first item. |
| <kbd>End</kbd> | <kbd>End</kbd> | Selects the last item. |

N> In the following sample, disable the AutoComplete component using <kbd>t</kbd> keys.

{% highlight cshtml %}

{% include_relative code-snippet/accessibility/accessibility.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtLUCrMzKHwTMpln?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Ensuring accessibility

The Blazor AutoComplete component's accessibility levels are ensured through an [axe-core](https://www.npmjs.com/package/axe-core) software tool during automated testing.

The accessibility compliance of the AutoComplete component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/autocomplete) in a new window to evaluate the accessibility of the AutoComplete component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> components](../common/accessibility)