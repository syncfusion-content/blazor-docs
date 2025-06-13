---
layout: post
title: Accessibility in Blazor Dropdown Tree Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor Dropdown Tree component and more.
platform: Blazor
control: Dropdown Tree
documentation: ug
---

# Accessibility in Blazor Dropdown Tree Component

The [Blazor Dropdown Tree](https://www.syncfusion.com/blazor-components/blazor-dropdowntree) component has been designed, keeping in mind the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/) specifications, and applied the WAI-ARIA roles, states, and properties along with `keyboard support`. This component is characterized by complete keyboard interaction support and ARIA accessibility support that makes it easy for people who use assistive technologies (AT) or those who completely rely on keyboard navigation.

The Blazor Dropdown Tree component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Dropdown Tree component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2](https://www.w3.org/TR/WCAG22/) Support | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial"> |
| [Section 508](https://www.section508.gov/) Support | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial"> |
| Screen Reader Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Right-To-Left Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Color Contrast | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Mobile Device Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| Keyboard Navigation Support | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) Accessibility Validation | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Partial"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/landing-page/no.png" alt="No"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

The Blazor Dropdown Tree component followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/) patterns to meet the accessibility. The following ARIA attributes are used in the Dropdown Tree component:

| **Attributes** | **Purpose** |
| --- | --- |
| `aria-haspopup` | Indicates the availability and type of interactive popup element |
| `aria-expanded` | Indicates whether the popup list has expanded or not. |
| `aria-selected` | Indicates the selected tree item. |
| `aria-disabled` | Indicates whether the Dropdown Tree component is in a disabled state or not. |
| `aria-controls` | This attribute contains the ID of the popup list to indicate this element is controlled by the popup list element |

## Keyboard interaction

You can use the following key shortcuts to access the Dropdown Tree without interruptions:

| Windows | Mac | Actions |
| --- | --- | --- |
|**Input Navigation**| | |
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | Opens the popup and move focus to TreeView. |
| <kbd>Alt</kbd> + <kbd>↑</kbd> | <kbd>⌥</kbd> + <kbd>↑</kbd> | Closes the popup. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Focuses on the next TabIndex element on the page when the popup is closed. Otherwise, closes the popup list and remains the focus of the component. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Focuses on the previous TabIndex element on the page when the popup is closed. Otherwise, closes the popup list and remains the focus of the component. |
|**Popup Navigation**| | |
| <kbd>Esc(Escape)</kbd> | <kbd>Esc</kbd> | Closes the popup when it is in an open state. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Goes to the previous item in the popup. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Goes to the next item in the popup. |
| <kbd>→</kbd> | <kbd>→</kbd> | Expands the current item. |
| <kbd>←</kbd> | <kbd>←</kbd> | Collapses the current item in the popup. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | Goes to the first item in the popup. |
| <kbd>End</kbd> | <kbd>End</kbd> | Goes to the last item in the popup. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Selects the focused item in the popup. |
| <kbd>Space</kbd> | <kbd>Space</kbd> | Checks the current item in the popup. |
|**Over All Checkbox**| | |
| <kbd>Space</kbd> | <kbd>Space</kbd> | Checks all the items in popup |

## Ensuring accessibility

The Blazor Dropdown Tree component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) software tool during automated testing.

The accessibility compliance of the Dropdown Tree component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/dropdowntree) in a new window to evaluate the accessibility of the Dropdown Tree component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)