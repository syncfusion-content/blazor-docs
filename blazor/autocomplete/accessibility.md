---
layout: post
title: Accessibility in Blazor AutoComplete Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor AutoComplete component and more.
platform: Blazor
control: AutoComplete
documentation: ug
---

# Accessibility in Blazor AutoComplete Component

The [AutoComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html) component has been designed, keeping in mind the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/) specifications, and applies the `WAI-ARIA` roles, states, and properties along with `keyboard support`. This component is characterized by complete keyboard interaction support and ARIA accessibility support that makes it easy for people who use assistive technologies (AT) or those who completely rely on keyboard navigation.

## ARIA attributes

The AutoComplete component uses the `combobox` role and each list item has an `option` role. The following `ARIA Attributes` denotes the AutoComplete state:

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

| **Keyboard shortcuts** | **Actions** |
| --- | --- |
|**Focus**|
|<kbd>Alt + J</kbd> | Focuses on the first component of the sample. |
|**Input Navigation**|
| <kbd>Alt + Down arrow</kbd> | Opens the popup list. |
| <kbd>Alt + Up arrow</kbd> | Closes the popup list. |
| <kbd>Tab</kbd> | Focuses on the next TabIndex element on the page when the popup is closed. Otherwise, closes the popup list and remains the focus of the component. |
| <kbd>Shift + tab </kbd> | Focuses on the previous TabIndex element on the page when the popup is closed. Otherwise, closes the popup list and remains the focus of the component. |
|**Selection**|
| <kbd>Enter</kbd> | Selects the focused item, and when it is in open state, the popup list closes. Otherwise, toggles the popup list. |
|**Popup Navigation**|
| <kbd>Esc(Escape)</kbd> | Closes the popup list when it is in an open state and the currently selected item remains the same. |
| <kbd>Down arrow</kbd> | Selects the first item in the AutoComplete when no item is selected. Otherwise, selects the item next to the currently selected item. |
| <kbd>Up arrow</kbd> | Selects the item previous to the currently selected one. |
| <kbd>Page down</kbd> | Scrolls down to the next page and selects the first item when the popup list opens. |
| <kbd>Page up</kbd> | Scrolls up to the previous page and selects the first item when the popup list opens. |
| <kbd>Home</kbd> | Selects the first item. |
| <kbd>End</kbd> | Selects the last item. |

N> In the following sample, disable the AutoComplete component using <kbd>t</kbd> keys.

{% highlight cshtml %}

{% include_relative code-snippet/accessibility/accessibility.razor %}

{% endhighlight %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtLUCrMzKHwTMpln?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Accessibility in Blazor AutoComplete](./images/blazor-autocomplete-accessibility.png)