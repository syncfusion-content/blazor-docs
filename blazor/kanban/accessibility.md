---
layout: post
title: Accessibility in Blazor Kanban Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor Kanban component and more.
platform: Blazor
control: Kanban
documentation: ug
---

# Accessibility in Blazor Kanban Component

The Kanban component has been designed, keeping in mind the WAI-ARIA specifications, and applies the WAI-ARIA roles, states, and properties. This component is characterized by complete ARIA accessibility support that makes it easy for people who use assistive technologies (AT) or those who completely rely on keyboard navigation.

The accessibility compliance for the Kanban component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| WCAG 2.2 Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Section 508 Support](../common/accessibility#section-508) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| Screen Reader Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| Right-To-Left Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| Color Contrast | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| Mobile Device Support | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| [Keyboard Navigation](../common/accessibility#keyboard-navigation) | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |
| Accessibility Checker Validation | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| Axe-core Accessibility Validation | <img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>
![Yes](https://cdn.syncfusion.com/content/images/documentation/full.png) - All features of the component meet the requirement.

![Intermediate](https://cdn.syncfusion.com/content/images/documentation/partial.png)  - Some features of the component do not meet the requirement.

![No](https://cdn.syncfusion.com/content/images/documentation/not-supported.png)  - The component does not meet the requirement.

## WAI-ARIA attributes

The Kanban component followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/alert/) patterns to meet the accessibility. The following ARIA attributes are used in the Kanban component:

| Attributes | Purpose |
| --- | --- |
| `aria-label` |  It helps to provides information about elements in a kanban component for assistive technology. |
| `aria-expanded` | Attributes indicate the state of a collapsible element. |
| `aria-selected` | This attribute is assigned to the Kanban component for the selection of elements, and its default value is `false`. The value changes to true when the user selects a Kanban card. |
| `aria-grabbed` | Indicates whether the attribute is set to true. It has been selected for dragging. If this attribute is set to false, the element can be grabbed for a drag-and-drop operation but will not be currently grabbed. |
| `aria-describedby` | This attribute contains the ID of the Kanban header column to indicate that the attribute establishes an association between the Kanban header column and the Kanban column body. |
| `aria-roledescription` | This attribute is assigned to the Kanban component and is used to provide alternative descriptions for card elements. |

## Keyboard interaction

The Kanban component followed the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/alert/#keyboardinteraction) guideline, making it easy for people who use assistive technologies (AT) and those who completely rely on keyboard navigation. The following keyboard shortcuts are supported by the Kanban component.

| **Press** | **To do this** |
| --- | --- |
| <kbd>Home</kbd> | To select the first card in the kanban |
| <kbd>End</kbd> | To select the last card in the kanban |
| <kbd>Arrow Up</kbd> | Select the card through the up arrow |
| <kbd>Arrow Down</kbd> | Select the card through the down arrow |
| <kbd>Arrow Right</kbd> | Move the column selection to the right |
| <kbd>Arrow Left</kbd> | Move the column selection to the left |
| <kbd>Ctrl</kbd> + <kbd>Enter</kbd> | Used to select the multi cards |
| <kbd>Ctrl</kbd> + <kbd>Space</kbd> | Used to select the multi cards |
| <kbd>Shift</kbd> + <kbd>Arrow Up</kbd> | Used to select the multiple cards towards up |
| <kbd>Shift</kbd> + <kbd>Arrow Down</kbd> | Used to select the multiple cards towards down |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | Reverse order of the tab action |
| <kbd>Enter</kbd> | Open the selected cards |
| <kbd>Tab</kbd> | To navigate the Kanban column |
| <kbd>Delete</kbd> | To delete the selected cards |
| <kbd>ESC</kbd> | Escape from the modified details |
| <kbd>Space</kbd> | Used to open the card edit dialog based on the column selection |

## Disable keyboard interaction

Disables all the functionalities in the Kanban board performed using keyboard by setting the `allowKeyboard` properties to `false`.

## Ensuring accessibility

The Kanban component's accessibility levels are ensured through an [accessibility-checker](https://www.npmjs.com/package/accessibility-checker) and [axe-core](https://www.npmjs.com/package/axe-core) software tools during automated testing.

The accessibility compliance of the Kanban component is shown in the following sample. Open the sample in a new window to evaluate the accessibility of the Kanban component with accessibility tools.

## See also

* [Accessibility in Syncfusion Blazor components](../common/accessibility)