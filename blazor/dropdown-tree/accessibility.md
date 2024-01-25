---
layout: post
title: Accessibility in Blazor Dropdown Tree Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor Dropdown Tree component and more.
platform: Blazor
control: Dropdown Tree
documentation: ug
---

# Accessibility in Dropdown Tree 

The Dropdown Tree component has been designed, keeping in mind the `WAI-ARIA` specifications, and applied the WAI-ARIA roles, states, and properties along with `keyboard support`. This component is characterized by complete keyboard interaction support and ARIA accessibility support that makes it easy for people who use assistive technologies (AT) or those who completely rely on keyboard navigation.

## ARIA attributes

The Dropdown Tree component uses the `Combobox` role. The following `ARIA attributes` denote the Dropdown Tree state.

| **Properties** | **Functionalities** |
| --- | --- |
| `aria-haspopup` | Indicates the availability and type of interactive popup element |
| `aria-expanded` | Indicates whether the popup list has expanded or not. |
| `aria-selected` | Indicates the selected tree item. |
| `aria-disabled` | Indicates whether the Dropdown Tree component is in a disabled state or not. |
| `aria-controls` | This attribute contains the ID of the popup list to indicate this element is controlled by the popup list element |

## Keyboard interaction

You can use the following key shortcuts to access the Dropdown Tree without interruptions:

| **Keyboard shortcuts** | **Actions** |
| --- | --- |
|**Input Navigation**|
| <kbd>Alt + Down arrow</kbd> | Opens the popup and move focus to TreeView. |
| <kbd>Alt + Up arrow</kbd> | Closes the popup. |
| <kbd>Tab</kbd> | Focuses on the next TabIndex element on the page when the popup is closed. Otherwise, closes the popup list and remains the focus of the component. |
| <kbd>Shift + tab </kbd> | Focuses on the previous TabIndex element on the page when the popup is closed. Otherwise, closes the popup list and remains the focus of the component. |
|**Popup Navigation**|
| <kbd>Esc(Escape)</kbd> | Closes the popup when it is in an open state. |
| <kbd>Arrow Up</kbd> | Goes to the previous item in the popup. |
| <kbd>Arrow Down</kbd> | Goes to the next item in the popup. |
| <kbd>Arrow Right</kbd> | Expands the current item. |
| <kbd>Arrow Left</kbd> | Collapses the current item in the popup. |
| <kbd>Home</kbd> | Goes to the first item in the popup. |
| <kbd>End</kbd> | Goes to the last item in the popup. |
| <kbd>Enter</kbd> | Selects the focused item in the popup. |
| <kbd>Space</kbd> | Checks the current item in the popup. |
|**Over All Checkbox**|
| <kbd>Space</kbd> | Checks all the items in popup |