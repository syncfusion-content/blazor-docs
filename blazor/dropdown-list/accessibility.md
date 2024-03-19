---
layout: post
title: Accessibility in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor DropDown List component and more.
platform: Blazor
control: DropDown List
documentation: ug
---

# Accessibility in DropDown List 

The DropDownList component has been designed, keeping in mind the `WAI-ARIA` specifications, and applied the WAI-ARIA roles, states, and properties along with `keyboard support`. This component is characterized by complete keyboard interaction support and ARIA accessibility support that makes it easy for people who use assistive technologies (AT) or those who completely rely on keyboard navigation.

The DropDownList component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the DropDownList component is outlined below.

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

The DropDownList component uses the `Combobox` role. The following `ARIA attributes` denote the DropDownList state.

| **Properties** | **Functionalities** |
| --- | --- |
| `aria-haspopup` | Indicates whether the DropDownList input element has a popup list or not. |
| `aria-expanded` | Indicates whether the popup list has expanded or not. |
| `aria-selected` | Indicates the selected option. |
| `aria-readonly` | Indicates the readonly state of the DropDownList element. |
| `aria-disabled` | Indicates whether the DropDownList component is in a disabled state or not. |
| `aria-activedescendent` | This attribute holds the ID of the active list item to focus its descendant child element. |
| `aria-owns` | This attribute contains the ID of the popup list to indicate popup as a child element. |

## Keyboard interaction

You can use the following key shortcuts to access the DropDownList without interruptions:

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
| <kbd>Down arrow</kbd> | Selects the first item in the DropDownList when no item is selected. Otherwise, selects the item next to the currently selected item. |
| <kbd>Up arrow</kbd> | Selects the item previous to the currently selected one. |
| <kbd>Page down</kbd> | Scrolls down to the next page and selects the first item when the popup list opens. |
| <kbd>Page up</kbd> | Scrolls up to the previous page and selects the first item when the popup list opens. |
| <kbd>Home</kbd> | Selects the first item. |
| <kbd>End</kbd> | Selects the last item. |

## Ensuring accessibility

The DropDownList component's accessibility levels are ensured through an [accessibility-checker](https://www.npmjs.com/package/accessibility-checker) and [axe-core](https://www.npmjs.com/package/axe-core) software tools during automated testing.

The accessibility compliance of the DropDownList component is shown in the following sample. Open the [sample](https://ej2.syncfusion.com/accessibility/drop-down-list.html) in a new window to evaluate the accessibility of the DropDownList component with accessibility tools.

{% previewsample "https://ej2.syncfusion.com/accessibility/drop-down-list.html" %}

## See also

* [Accessibility in Syncfusion components](../common/accessibility)