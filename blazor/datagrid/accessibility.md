---
layout: post
title: Accessibility in Blazor DataGrid Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor DataGrid component and much more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Accessibility in Blazor DataGrid Component

Accessibility is achieved in the DataGrid component through WAI-ARIA standard and keyboard navigations. The DataGrid features can be effectively accessed through assistive technologies such as screen readers.

## WAI-ARIA

WAI-ARIA (Accessibility Initiative – Accessible Rich Internet Applications) defines a way to increase the accessibility of web pages, dynamic content, and user interface components developed with Ajax, HTML, JavaScript, and related technologies. ARIA provides additional semantics to describe the role, state, and functionality of web components.

The following ARIA attributes are used in the DataGrid:

| Attributes | Purpose |
| --- | --- |
| `role=grid` | To represent the element containing the grid component. |
| `role=row` | To represent the element containing the cells of the row in the grid. |
| `role=rowgroup` | To represent the group of rows in the grid. |
| `role=columnheader` | To represent the cell in a row contains header information for a column in the grid. |
| `role=gridcell` | To represent a cell in the grid component. |
| `role=button` | To represent the element that acts as a button in the grid. |
| `role=searchbox` | To represent the element that acts as a search region in the grid. |
| `role=presentation` | To represent the element to be not available for accessibility concerns. |
| `role=navigation` | To represent the element containing pager elements to navigate from one page to another. |
| `aria-colindex` | Defines the column index of the column with respect to the total number of columns within the grid. |
| `aria-rowindex` | Defines row index of the row with respect to the total number of rows within the grid.  |
| `rowspan` | Defines the number of rows spanned by a cell within the grid.  |
| `colspan` | Defines the number of columns spanned by a cell within the grid. |
| `aria-selected` | Indicates the current "selected" state of the rows and cells in the grid. |
| `aria-expanded` | Indicate if the expand icon in the hierarchy grid or grouped grid or detail grid is expanded or collapsed |
| `aria-sort` | Indicates whether the data in the grid are sorted in ascending or descending order. |
| `aria-hidden` | Hides the element from accessibility concerns. |
| `aria-labelledby` | Provides an accessible name for the checkbox labels in excel filter, checkbox filter and column chooser dialog.  |
| `aria-describedby` | Provides an description about the features enabled in the header when the grid header cell is focused. |

## Keyboard navigation

DataGrid functionalities can be interactive with keyboard shortcuts.

The following keyboard shortcuts are supported by DataGrid.

Interaction Keys |Description
-----|-----
<kbd>PageDown</kbd> |Goes to the next page.
<kbd>PageUp</kbd> |Goes to the previous page.
<kbd>Ctrl + Alt +PageDown</kbd> |Goes to the last page.
<kbd>Ctrl + Alt + PageUp</kbd> |Goes to the first page.
<kbd>Alt + PageDown</kbd> |Goes to the next page.
<kbd>Alt + PageUp</kbd> |Goes to the previous page.
<kbd>Home</kbd> |Goes to the first cell.
<kbd>End</kbd> |Goes to the last cell.
<kbd>Ctrl + Home</kbd> |Goes to the first row.
<kbd>Ctrl + End</kbd> |Goes to the last row.
<kbd>DownArrow</kbd> |Moves the cell focus downward.
<kbd>UpArrow</kbd> |Moves the cell focus upward.
<kbd>LeftArrow</kbd> |Moves the cell focus left side.
<kbd>RightArrow</kbd> |Moves the cell focus right side.
<kbd>Shift + DownArrow</kbd> |Extends the row/cell selection downwards.
<kbd>Shift + UpArrow</kbd> |Extends the row/cell selection upwards.
<kbd>Shift + LeftArrow</kbd> |Extends the cell selection to the left side.
<kbd>Shift + RightArrow</kbd> |Extends the cell selection to the right side.
<kbd>Enter</kbd> | Moves the row/cell selection downward. If current cell is in edit state, then completes the editing. If the current cell is a header then performs sorting. If the current cell is an expand/collapse cell then expands/collapses the current group/detailrow/childgrid. If the current cell is a detailrow, child datagrid or command column then the focus will be moved to the focusable element inside the cell.
<kbd>Shift + Enter</kbd> | Moves the row/cell selection upward. If the current cell is a header then clears sorting for the selected column.
<kbd>Ctrl + Enter</kbd> | If the current cell is a header then performs multi-sorting.
<kbd>Tab</kbd> | Moves the cell selection right side.
<kbd>Shift + Tab</kbd> | Moves the cell selection left side.
<kbd>Esc</kbd> |Deselects all the rows/cells.
<kbd>Ctrl + A</kbd> |Selects all the rows/cells.
<kbd>UpArrow</kbd> |Moves up a row/cell selection.
<kbd>DownArrow</kbd> |Moves down a row/cell selection.
<kbd>RightArrow</kbd> |Moves to the right cell selection.
<kbd>LeftArrow</kbd> |Moves to the left cell selection.
<kbd>Alt + DownArrow</kbd> |Expands the selected group.
<kbd>Ctrl + DownArrow</kbd> |Expands all the visible groups.
<kbd>Alt + UpArrow</kbd> |Collapses the selected group.
<kbd>Ctrl + UpArrow</kbd> |Collapses all the visible groups.
<kbd>Ctrl + P</kbd> |Prints the DataGrid.
<kbd>Ctrl + C</kbd> |Copy selected rows or cells data into clipboard
<kbd>Ctrl + Shift + H</kbd> |Copy selected rows or cells data with header into clipboard