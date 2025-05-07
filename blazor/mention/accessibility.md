---
layout: post
title: Accessibility in Blazor Mention Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor Mention component and much more details.  
platform: Blazor
control: Mention
documentation: ug
---

# Accessibility in Blazor Mention Component

Web accessibility makes web content and web applications more accessible for people with disabilities. Blazor Mention component provides built-in compliance with `WAI-ARIA` specifications. The `WAI-ARIA` support is achieved using the attributes such as `aria-selected` and `aria-activedescendent`.

The [Blazor Mention](https://www.syncfusion.com/blazor-components/blazor-mention) component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Mention component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
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

The Blazor Mention component is designed to be compliant with `WAI-ARIA` (Web Accessibility Initiative - Accessible Rich Internet Applications) specifications, which provide guidelines and standards for making web content more accessible to people with disabilities. To achieve `WAI-ARIA` support, the Mention uses attributes such as `aria-selected` and `aria-activedescendent`. 

The `aria-selected` attribute is used to indicate that an element is currently selected or has been selected in the past, while the `aria-activedescendent` attribute is used to indicate the currently active descendant element of a composite widget.

It uses the various `ARIA attributes` (Accessible Rich Internet Applications) to denote the state of the component and provide additional information to assistive technologies such as screen readers. These attributes can help users who rely on assistive technologies to understand and interact with the Mention component more easily.

Here are some of the `ARIA attributes` that might be used to denote the state of a mention list item:

| **Properties** | **Functionalities** |
| --- | --- |
| `aria-selected` | Indicates the currently selected option in the list of mention suggestions |
| `aria-activedescendent` | This attribute holds the ID of the active list item to focus its descendant child element. |
| `aria-owns` | Indicate that the Mention component owns or controls the popup list of mention suggestions. |

## Keyboard interaction

You can use the following key shortcuts to access the Blazor Mention without interruptions. It allows users to quickly perform actions or navigate through an application using keyboard input.

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Focus the first item in the Mention list. Otherwise, focus the item next to the currently focused item. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Focus the item previous to the currently focused one. |
| <kbd>Esc(Escape)</kbd> | <kbd>Esc(Escape)</kbd> | Closes the popup list when it is in an open state. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Selects the focused item, and when it is in an open state the popup list closes. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Focuses on the next tab index element on the page when the popup is closed. Otherwise, inserts the selected popup list item and closes the popup list. |


{% highlight razor %}

{% include_relative code-snippet/accessibility.razor %}

{% endhighlight %}

## Ensuring accessibility

The Blazor Mention component's accessibility levels are ensured through an [axe-core](https://www.npmjs.com/package/axe-core) software tool during automated testing.

The accessibility compliance of the Mention component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/mention) in a new window to evaluate the accessibility of the Mention component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> components](../common/accessibility)