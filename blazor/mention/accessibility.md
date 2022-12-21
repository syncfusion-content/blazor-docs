---
layout: post
title: Accessibility in Blazor Mention Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor Mention component and much more details.  
platform: Blazor
control: Mention
documentation: ug
---

# Accessibility in Blazor Mention Component

The Mention component is designed to be compliant with `WAI-ARIA` (Web Accessibility Initiative - Accessible Rich Internet Applications) specifications, which provide guidelines and standards for making web content more accessible to people with disabilities. To achieve `WAI-ARIA` support, the Mention uses attributes such as `aria-selected` and `aria-activedescendent`. 

The `aria-selected` attribute is used to indicate that an element is currently selected or has been selected in the past, while the `aria-activedescendent` attribute is used to indicate the currently active descendant element of a composite widget.

## ARIA attributes

The Mention component uses the `Listbox` role and `Option` role to implement the mention functionality. The `Listbox` role represents a list of options, and the `Option` role represents a single item in the list. 

It uses the various `ARIA attributes` (Accessible Rich Internet Applications) to denote the state of the component and provide additional information to assistive technologies such as screen readers. These attributes can help users who rely on assistive technologies to understand and interact with the Mention component more easily.

Here are some of the `ARIA attributes` that might be used to denote the state of a mention list item:

| **Properties** | **Functionalities** |
| --- | --- |
| `aria-selected` | Indicates the currently selected option in the list of mention suggestions |
| `aria-activedescendent` | This attribute holds the ID of the active list item to focus its descendant child element. |
| `aria-owns` | Indicate that the Mention component owns or controls the popup list of mention suggestions. |

## Keyboard interaction

You can use the following key shortcuts to access the Mention without interruptions. It allows users to quickly perform actions or navigate through an application using keyboard input.

| **Keyboard shortcuts** | **Actions** |
| --- | --- |

| <kbd>Down arrow</kbd> | Focus the first item in the Mention list. Otherwise, focus the item next to the currently focused item. |
| <kbd>Up arrow</kbd> | Focus the item previous to the currently focused one. |
| <kbd>Esc(Escape)</kbd> | Closes the popup list when it is in an open state. |
| <kbd>Enter</kbd> | Selects the focused item, and when it is in an open state the popup list closes. |
| <kbd>Tab</kbd> | Focuses on the next tabindex element on the page when the popup is closed. Otherwise, inserts the selected popup list item and closes the popup list. |

{% highlight razor %}

{% include_relative code-snippet/accessibility.razor %}

{% endhighlight %}