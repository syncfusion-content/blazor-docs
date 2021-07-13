---
layout: post
title: Accessibility in Blazor File Manager Component | Syncfusion 
description: Learn about Accessibility in Blazor File Manager component of Syncfusion, and more details.
platform: Blazor
control: File Manager
documentation: ug
---

# Accessibility

The File Manager component has been designed with keeping the `WAI-ARIA` specifications in mind, and applying the `WAI-ARIA` roles, states, and properties along with `keyboard support`. This component is characterized by complete keyboard interaction support and ARIA accessibility support, which makes navigation easy for people who use assistive technologies (AT) or for users who completely rely on keyboard navigation.

## ARIA attributes

 The following `ARIA` Attributes denote the state of File Manager.

 | **Property** | **Functionalities** |
| --- | --- |
| aria-disabled | Indicates whether the File Manager component is in disabled state.|
| aria-haspopup | Indicates whether the Toolbar element has a suggestion list. |
| aria-orientation | Indicates whether the File Manager element is oriented horizontally or vertically. |
| aria-expanded | Indicates whether the Treeview node has been expanded. |
| aria-owns | Contains the ID of the suggestion list to indicate popup as a child element. |
| aria-activedescendent | Holds the ID of the active list item to focus its descendant child element. |
| aria-level | Specifies the level of the element in Treeview Structure. |
| aria-selected | Indicates whether a particular node is in selected state. |
| aria-placeholder | Represents a hint (word or phrase) to the user about what to enter in the text field |
| aria-label |  Defines a string that labels the current element. |
| aria-checked | Indicates whether the checkbox is in checked state. |
| aria-labelledby | Labels the dialog. Often, the value of the aria-labelledby attribute will be the id of the element, which is used to title the dialog |
| aria-describedby | Describes the contents of the dialog. |
| aria-modal | Indicates whether an element is a modal when display. |
| aria-colcount | Specifies the number of columns in full table. |
| aria-colindexnt | Defines the number of columns within a grid. |
| aria-rowspan | Defines the number of rows a cell spanned within a grid. |
| aria-colspan | Defines the number of columns a cell spanned within a grid. |
| aria-sort | Indicates whether items in the grid or table are sorted in ascending or descending order. |
| aria-grabbed | This attribute is set to true, and it has been selected for dragging. If this element is set to false, the element can be grabbed for a drag-and-drop operation, but will not currently be selected. |
| aria-busy | This attribute is set to false when grid content is loaded. |
| aria-multiselectable | Defines more than one item has been selected. |

## Keyboard interaction

You can use the following key shortcuts to access the File Manager without interruptions.

| **Keyboard shortcuts** | **Actions** |
| --- | --- |
| <kbd>Page Down</kbd> | Scrolls down to the next folder or file and selects the first item when files are loaded. |
| <kbd>Page Up</kbd> | Scrolls up to previous folder and select the first item when files are loaded. |
| <kbd>Enter</kbd> | Selects the focused item and navigate through the child elements. |
| <kbd>Tab</kbd> | Focuses on the first element of toolbar and navigates through the next tab indexed element. |
| <kbd>Esc(Escape)</kbd> | Closes the image when it is in open state. |
| <kbd>Alt+N</kbd> | Creates a new folder dialog.|
| <kbd>F5</kbd> | Refresh the file manager element. |
| <kbd>Ctrl+Shift+1</kbd> | Changes the file manager layout to Grid view. |
| <kbd>Ctrl+Shift+2</kbd> | Changes the file manager layout to Details view. |