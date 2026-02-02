---
layout: post
title: Accessibility in Syncfusion Blazor MultiColumn ComboBox
description: Checkout and learn here all about Accessibility in Syncfusion Blazor MultiColumn ComboBox component and much more.
platform: Blazor
control: MultiColumn ComboBox
documentation: ug
---

# Accessibility in Blazor MultiColumn ComboBox Component

The [Blazor MultiColumn ComboBox](https://www.syncfusion.com/blazor-components/blazor-multicolumn-combobox) is designed in accordance with WAI-ARIA specifications and applies appropriate roles, states, and properties, along with robust keyboard support. The component offers complete keyboard interaction and ARIA support to assist users who rely on assistive technologies (AT) or keyboard navigation.

The Blazor ComboBox component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor MultiColumn ComboBox component is outlined below.

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
<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Meets requirement"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partially meets requirement"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="Does not meet requirement"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

The Blazor MultiColumn ComboBox uses the combobox pattern with an input (textbox), a popup listbox, and list options. The input applies the combobox role, the popup uses the listbox role, and each list item uses the option role. The following ARIA attributes denote the component state and relationships:

| **Properties** | **Functionalities** |
| --- | --- |
| `aria-haspopup` | Indicates that the input element opens a popup list. |
| `aria-expanded` | Indicates whether the popup list is expanded. |
| `aria-selected` | Indicates the selected option in the list. |
| `aria-readonly` | Indicates the read-only state of the input element. |
| `aria-disabled` | Indicates whether the component is disabled. |
| `aria-activedescendant` | Holds the ID of the active list item to convey focus within the popup list. |
| `aria-owns` | Identifies the popup element associated with the input when it is not a DOM descendant. |
| `aria-autocomplete`  | Indicates the autocomplete behavior (for example, “both” to show a list of options and inline completion). |

Screen readers announce expanded and collapsed states, the active option while navigating, and the selected value when committed.

## Keyboard interaction

Use the following key shortcuts to interact with the Blazor MultiColumn ComboBox:

| Windows | Mac | Actions |
| --- | --- | --- |
|**Focus**| | |
|<kbd>Alt + J</kbd> | <kbd>⌥</kbd> + <kbd>J</kbd> | Focuses on the first component of the sample. |
|**Input Navigation**| | |
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | Opens the popup list. |
| <kbd>Alt</kbd> + <kbd>↑</kbd> | <kbd>⌥</kbd> + <kbd>↑</kbd> | Closes the popup list. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | Moves the cursor to the beginning of the input. |
| <kbd>End</kbd> | <kbd>End</kbd> | Moves the cursor to the end of the input. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Focuses on the previous TabIndex element on the page when the popup is closed. Otherwise, closes the popup list and remains the focus of the component. |
|**Selection**| | |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Selects the focused item. When the popup is open, confirms selection and closes the list; otherwise, toggles the popup. |
|**Popup Navigation** | | |
| <kbd>Esc(Escape)</kbd> | <kbd>Escape</kbd> | Closes the popup when open and preserves the current selection. |


## Ensuring accessibility

The Blazor MultiColumn ComboBox component’s accessibility is validated with the [axe-core](https://www.npmjs.com/package/axe-core) tool during automated testing.

The accessibility compliance of the MultiColumn ComboBox component is demonstrated in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/combobox) in a new window to evaluate accessibility with your preferred tools. The component also supports right-to-left (RTL) rendering and high-contrast themes for improved readability and usability.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> components](../common/accessibility)