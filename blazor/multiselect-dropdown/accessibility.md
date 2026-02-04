---
layout: post
title: Accessibility in Blazor MultiSelect Dropdown Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor MultiSelect Dropdown component and more.
platform: Blazor
control: MultiSelect Dropdown
documentation: ug
---

# Accessibility in Blazor MultiSelect Dropdown Component

The [Blazor MultiSelect Dropdown](https://www.syncfusion.com/blazor-components/blazor-multiselect-dropdown) component is designed in accordance with WAI-ARIA specifications and applies appropriate roles, states, and properties along with full keyboard support. It offers complete keyboard interaction and ARIA support to ensure usability for people who use assistive technologies or rely on keyboard navigation.

The Blazor MultiSelect Dropdown component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor MultiSelect Dropdown component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | AAA |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Right-to-left support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
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

The Blazor MultiSelect Dropdown component follows the `Listbox` role, and each list item has an `option` role. The following `ARIA attributes` denotes the MultiSelect state:

| **Properties** | **Functionalities** |
| --- | --- |
| aria-haspopup | Indicates that the input has a popup listbox. |
| aria-expanded | Indicates whether the popup list is expanded. |
| aria-selected | Indicates the selected option. |
| aria-readonly | Indicates the read-only state of the MultiSelect element. |
| aria-disabled | Indicates whether the MultiSelect component is disabled. |
| aria-activedescendant | Holds the ID of the active list item to expose the focused descendant. |
| aria-owns | Contains the ID of the popup list to reference it as a child when it is not a DOM descendant. |

## Keyboard interaction

Use the following key shortcuts to access the Blazor MultiSelect Dropdown without interruptions:

| Windows | Mac | Actions |
| --- | --- | --- |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Sets focus to the first item when no item is selected; otherwise moves focus to the next item. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Moves focus to the previous item. |
| <kbd>Page Down</kbd> | <kbd>Page Down</kbd> | Scrolls down one page and sets focus to the first visible item when the popup is open. |
| <kbd>Page Up</kbd> | <kbd>Page Up</kbd> | Scrolls up one page and sets focus to the first visible item when the popup is open. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Selects the focused item; when closed, opens the popup list. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Moves focus to the next element in the tab order when the popup is closed; otherwise closes the popup and retains focus on the component. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Moves focus to the previous element in the tab order when the popup is closed; otherwise closes the popup and retains focus on the component. |
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | Opens the popup list. |
| <kbd>Alt</kbd> + <kbd>↑</kbd> | <kbd>⌥</kbd> + <kbd>↑</kbd> | Closes the popup list. |
| <kbd>Escape</kbd> | <kbd>Escape</kbd> | Closes the popup list when open; the current selection remains unchanged. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | Sets focus to the first item. |
| <kbd>End</kbd> | <kbd>End</kbd> | Sets focus to the last item. |

## Ensuring accessibility

The Blazor MultiSelect Dropdown component's accessibility levels are validated using the [axe-core](https://www.npmjs.com/package/axe-core) tool during automated testing.

The accessibility compliance of the MultiSelect Dropdown component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/multiselect) in a new window to evaluate the accessibility of the MultiSelect Dropdown component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> components](../common/accessibility)