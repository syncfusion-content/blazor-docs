---
layout: post
title: Accessibility in Blazor DropDown List Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor DropDown List component and more.
platform: Blazor
control: DropDownList
documentation: ug
---

# Accessibility in DropDown List 

The [Blazor DropDownList](https://www.syncfusion.com/blazor-components/blazor-dropdown-list) component is built to align with WAI-ARIA specifications, applying appropriate roles, states, and properties alongside comprehensive keyboard support. It provides full keyboard interaction and ARIA compatibility to ensure a consistent experience for users of assistive technologies and for those who rely on keyboard navigation.

The Blazor DropDownList component follows recognized accessibility standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) commonly used to evaluate accessibility.

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
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>
<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> - Some features of the component do not fully meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="No"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

The Blazor DropDownList component uses the combobox pattern. The following ARIA attributes convey the component’s state and relationships:

| **Properties** | **Functionalities** |
| --- | --- |
| `aria-haspopup` | Indicates that the input has an associated popup list. |
| `aria-expanded` | Indicates whether the popup list is expanded. |
| `aria-selected` | Indicates the selected option in the list. |
| `aria-readonly` | Indicates the readonly state of the input. |
| `aria-disabled` | Indicates whether the component is disabled. |
| `aria-activedescendant` | Holds the ID of the active list item to identify the focused descendant. |
| `aria-owns` | Contains the ID of the popup list to indicate the popup as a child element. |


## Keyboard interaction

Use the following keys to operate the Blazor DropDownList by keyboard:

| Windows | Mac | Actions |
| --- | --- | --- |
|**Focus**| | |
|<kbd>Alt</kbd> + <kbd>J</kbd> | <kbd>⌥</kbd> + <kbd>J</kbd> | Focuses on the first component of the sample (sample-page shortcut; availability may vary). |
|**Input Navigation**| | |
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | Opens the popup list. |
| <kbd>Alt</kbd> + <kbd>↑</kbd> | <kbd>⌥</kbd> + <kbd>↑</kbd> | Closes the popup list. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Focuses on the next TabIndex element on the page when the popup is closed. Otherwise, closes the popup list and remains the focus of the component. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Focuses on the previous TabIndex element on the page when the popup is closed. Otherwise, closes the popup list and remains the focus of the component. |
|**Selection**| | |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Selects the focused item. When the popup is open, it closes after selection; otherwise, toggles the popup. |
|**Popup Navigation**| | |
| <kbd>Escape</kbd> | <kbd>Esc</kbd> | Closes the popup when it is open; the current selection remains unchanged. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Selects the first item if none is selected; otherwise selects the next item. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Selects the previous item. |
| <kbd>Page Down</kbd> | <kbd>Page Down</kbd> | Scrolls down one page and selects the first visible item when the popup is open. |
| <kbd>Page Up</kbd> | <kbd>Page Up</kbd> | Scrolls up one page and selects the first visible item when the popup is open. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | Selects the first item. |
| <kbd>End</kbd> | <kbd>End</kbd> | Selects the last item. |

## Ensuring accessibility

The Blazor DropDownList component’s accessibility is validated using the [axe-core](https://www.npmjs.com/package/axe-core) tool during automated testing.

The accessibility compliance of the DropDownList component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/dropdownlist) in a new window to evaluate the accessibility of the DropDownList component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> components](../common/accessibility)