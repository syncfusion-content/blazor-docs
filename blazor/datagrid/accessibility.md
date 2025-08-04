---
layout: post
title: Accessibility in Blazor DataGrid | Syncfusion
description: Checkout and learn here all about accessibility features in Syncfusion Blazor DataGrid, including keyboard navigation, screen reader support, and more.
platform: Blazor
control: DataGrid
documentation: ug
---

# Accessibility in Blazor DataGrid

The Syncfusion Blazor DataGrid followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Grid is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes">  |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) |<img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |

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

The Syncfusion Blazor DataGrid followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/grid/) patterns to meet the accessibility. The following ARIA attributes are used in the Grid:

| Attributes | Purpose |
| --- | --- |
| `role=grid` | To represent the element containing the Grid. |
| `role=row` | To represent the element containing the cells of the row in the Grid. |
| `role=rowgroup` | To represent the group of rows in the Grid. |
| `role=columnheader` | To represent the cell in a row contains header information for a column in the Grid. |
| `role=gridcell` | To represent a cell in the Grid. |
| `role=button` | To represent the element that acts as a button in the Grid. |
| `role=search` | To represent the element that acts as a search region in the Grid. |
| `role=presentation` | To represent the element to be not available for accessibility concerns. |
| `role=navigation` | To represent the element containing pager elements to navigate from one page to another. |
| `aria-colindex` | Defines the column index of the column with respect to the total number of columns within the Grid. |
| `aria-rowindex` | Defines row index of the row with respect to the total number of rows within the Grid.  |
| `aria-rowspan` | Defines the number of rows spanned by a cell within the Grid.  |
| `aria-colspan` | Defines the number of columns spanned by a cell within the Grid. |
| `aria-rowcount` | Defines the total number of rows in the Grid.  |
| `aria-colcount` | Defines the total number of columns in the Grid. |
| `aria-selected` | Indicates the current "selected" state of the rows and cells in the Grid. |
| `aria-expanded` | Indicate if the expand icon in the hierarchy Grid or grouped Grid or detail Grid is expanded or collapsed |
| `aria-sort` | Indicates whether the data in the Grid are sorted in ascending or descending order. |
| `aria-busy` | Indicates an element is being modified and that assistive technologies may want to wait until the changes are complete before informing the user about the update. |
| `aria-owns` | Identifies an element in order to define a visual, functional, or contextual relationship between a parent and its child elements. |
| `aria-hidden` | Hides the element from accessibility concerns. |
| `aria-labelledby` | Provides an accessible name for the checkbox labels in excel filter, checkbox filter and column chooser dialog.  |
| `aria-describedby` | Provides an description about the features enabled in the header when the Grid header cell is focused. |

The Grid is structured with a two-table architecture for its header and content. To enhance accessibility for screen readers, roles and ARIA attributes are incorporated for both the Grid parent and all its child elements. Although this architectural approach may have some limitations with accessibility checker tools. It's important to note that these limitations do not affect the readability of the Grid content over screen readers.

The accessibility checker tools highlights the following known issues:

* aria-required-children: This warning appears when rendering the Grid without any features, as it contains textarea and Grid content. Additionally, it appears when enabling features such as the toolbar and grouping.

* color-contrast: This warning appears when you are enabling the search item in the Grid's toolbar.

* An explicit ARIA 'role' is not valid for `<tr>` element within an ARIA role 'Grid' per the ARIA in HTML specification.

* An explicit ARIA 'role' is not valid for `<th>` element within an ARIA role 'Grid' per the ARIA in HTML specification.

* An explicit ARIA 'role' is not valid for `<td>` element within an ARIA role 'Grid' per the ARIA in HTML specification.

* The element with role "button" contains descendants with roles "rowgroup" which are ignored by browsers.

* Content is not within a landmark element.

* Multiple elements with "search" role do not have unique labels.

* Text contrast of 4.10 with its background is less than the WCAG AA minimum requirements for text of size 13px and weight of 400.

* Interactive with ARIA role 'Grid' does not have a programmatically associated name.

* The element with role "rowgroup" is not contained in or owned by an element with one of the following roles: "Grid, table, treeGrid".

## Keyboard interaction

The Syncfusion Blazor DataGrid followed the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/alert/#keyboardinteraction) guideline, making it easy for people who use assistive technologies (AT) and those who completely rely on keyboard navigation. The following keyboard shortcuts are supported by the Grid.

<b>Pager</b>

| Windows | MAC | Actions |
|-----|----- | -----|
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Focus on the next pager item.|
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Focus on the previous pager item.|
| <kbd>Enter</kbd> / <kbd>Space</kbd> | <kbd>Enter</kbd> / <kbd>Space</kbd> | Select the currently focused page.|
|<kbd>PageUp</kbd> / <kbd>←</kbd> | <kbd>←</kbd> | Navigate to previous page.|
|<kbd>PageDown</kbd> / <kbd>→</kbd> | <kbd>→</kbd> | Navigate to next page.|
| <kbd>Home</kbd> / <kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>PageUp</kbd> | <kbd>Fn</kbd> + <kbd>←</kbd> | Navigate to first page.|
| <kbd>End</kbd> / <kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>PageDown</kbd> | <kbd>Fn</kbd> + <kbd>→</kbd> | Navigate to last page.|

<b>Focus Elements</b>

| Windows  | MAC | Actions |
|-----|----- | -----|
| <kbd>Home</kbd> | <kbd>Fn</kbd> + <kbd>←</kbd> | Moves the focus to the first cell of the focused row.|
| <kbd>End</kbd> | <kbd>Fn</kbd> + <kbd>→</kbd> | Moves the focus to the last cell of the focused row.|
| <kbd>Ctrl</kbd> + <kbd>Home</kbd> | <kbd>⌘</kbd> + <kbd>Fn</kbd> + <kbd>←</kbd> | Moves the focus to the first Cell of the first row in the Grid.|
| <kbd>Ctrl</kbd> + <kbd>End</kbd> | <kbd>⌘</kbd> + <kbd>Fn</kbd> + <kbd>→</kbd> | Moves the focus to the last Cell of the last row in the Grid.|
| <kbd>↑</kbd> | <kbd>↑</kbd> | Moves the cell focus upward from the focused cell.|
| <kbd>↓</kbd> | <kbd>↓</kbd> |  Moves the cell focus downward from the focused cell.|
| <kbd>→</kbd> | <kbd>→</kbd> | Moves the cell focus right side from the focused cell.|
| <kbd>←</kbd> | <kbd>←</kbd> |  Moves the cell focus left side from the focused cell.|
| <kbd>Alt</kbd> + <kbd>J</kbd> | <kbd>⌥</kbd> + <kbd>J</kbd> | Moves the focus to the entire Grid.|
| <kbd>Alt</kbd> + <kbd>W</kbd> | <kbd>⌥</kbd> + <kbd>W</kbd> | Move the focus to the Grid content element.|

<b>Selection</b>

| Windows  | MAC | Actions |
| -----|----- | ----- |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Moves up a row/cell selection from the selected row/cell. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Moves down a row/cell selection from the selected row/cell. |
| <kbd>→</kbd> | <kbd>→</kbd> | Moves to the right cell selection from the selected cell. |
| <kbd>←</kbd> | <kbd>←</kbd> | Moves to the left cell selection from the selected cell. |
| <kbd>Shift</kbd> + <kbd>↑</kbd> | <kbd>⇧</kbd> + <kbd>↑</kbd> | Extends the row/cell selection upwards from the selected row/cell. |
| <kbd>Shift</kbd> + <kbd>↓</kbd> | <kbd>⇧</kbd> + <kbd>↓</kbd> | Extends the row/cell selection downwards from the selected row/cell. |
| <kbd>Shift</kbd> + <kbd>→</kbd> | <kbd>⇧</kbd> + <kbd>→</kbd> | Extends the cell selection to the right side from the selected cell. |
| <kbd>Shift</kbd> + <kbd>←</kbd> | <kbd>⇧</kbd> + <kbd>←</kbd> | Extends the cell selection to the left side from the selected cell. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Moves the row/cell selection downward from the selected cell/row. |
| <kbd>Shift</kbd> + <kbd>Enter</kbd> | <kbd>⇧</kbd> + <kbd>Enter</kbd> | Moves the row/cell selection upward. |
| <kbd>Esc</kbd> | <kbd>Esc</kbd> | Deselects all the selected row/cells. |
| <kbd>Ctrl</kbd> + <kbd>A</kbd> | <kbd>⌘</kbd> + <kbd>A</kbd> | Select all the row/cells in the current page. |

<b>Grouping</b>

| Windows | MAC | Actions |
|-----|----- | -----|
| <kbd>Ctrl</kbd> + <kbd>↑</kbd> | <kbd>⌘</kbd> + <kbd>↑</kbd> | Collapses all the visible groups. |
| <kbd>Ctrl</kbd> + <kbd>↓</kbd> | <kbd>⌘</kbd> + <kbd>↓</kbd> | Expands all the visible groups. |
| <kbd>Ctrl</kbd> + <kbd>Space</kbd> | <kbd>⌘</kbd> + <kbd>Space</kbd> | Performs grouping when focused on a header element. |
| <kbd>Alt</kbd> + <kbd>↑</kbd> | <kbd>⌥</kbd> + <kbd>↑</kbd> | Collapses the selected group. |
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | Expands the selected group. |

<b>Print</b>

| Windows | MAC | Actions |
|-----|----- | -----|
| <kbd>Ctrl</kbd> + <kbd>P</kbd> | <kbd>⌘</kbd> + <kbd>P</kbd> | Prints the Grid. |

<b>Clipboard</b>

| Windows | MAC | Actions |
|-----|----- | -----|
| <kbd>Ctrl</kbd> + <kbd>C</kbd> | <kbd>⌘</kbd> + <kbd>C</kbd> | Copies selected rows or cells data into the clipboard. |
| <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>H</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>H</kbd> | Copies selected rows or cells data with header into clipboard |

<b>Editing</b>

| Windows | MAC | Actions |
|-----|----- | -----|
| <kbd>F2</kbd> | <kbd>F2</kbd> | Starts editing of selected row if Mode is Normal/Dialog or Starts editing of selected cell if Mode is Batch. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Saves the current form it the Mode is Normal or Dialog / Saves the current cell and starts editing the next row cell if Mode is Batch. |
| <kbd>Insert</kbd> | <kbd>⌥</kbd> + <kbd>Enter</kbd> | Creates a new add form depending on the NewRowPosition. |
| <kbd>Delete</kbd> | <kbd>Delete</kbd> | Deletes the current selected record. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Navigates to the next editable cell if the Mode is Normal or Dialog / Saves the current cell and starts editing the next cell is Mode is Batch. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Navigates to the previous editable cell if the Mode is Normal or Dialog / Saves the current cell and starts editing the previous cell is Mode is Batch. |
| <kbd>Shift</kbd> + <kbd>Enter</kbd> | <kbd>⇧</kbd> + <kbd>Enter</kbd> | Saves the current cell and starts editing the previous row cell if Mode is Batch. |

<b>Filtering</b>

| Windows | MAC | Actions |
| ----- | ----- | ----- |
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | Opens the filter menu(excel, menu and checkbox filter) when its header element is in focused state. |

<b>Column Menu</b>

| Windows | MAC | Actions |
| ----- | ----- | ----- |
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>Alt</kbd> + <kbd>↓</kbd> | Opens column menu when its header element is in focused state. |

<b>Reordering</b>

| Windows | MAC | Actions |
| ----- | ----- | ----- |
| <kbd>Ctrl</kbd> + <kbd>←</kbd> / <kbd>→</kbd> | <kbd>⌘</kbd> + <kbd>←</kbd> / <kbd>→</kbd> | Reorders the focused header column to the left or right side. |

<b>Sorting</b>

| Windows | MAC | Actions |
| ----- | ----- | ----- |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Performs sorting(ascending/descending) on a column when its header element is in focused state. |
| <kbd>Ctrl</kbd> + <kbd>Enter</kbd> | <kbd>⌘</kbd> + <kbd>Enter</kbd> | Performs multi-sorting on a column when its header element is in focused state. |
| <kbd>Shift</kbd> + <kbd>Enter</kbd> | <kbd>⇧</kbd> + <kbd>Enter</kbd> | Clears sorting for the focused header column. |

<br>

> * The <kbd>Command</kbd> and <kbd>Control</kbd> keys on Mac devices can be interchanged. When this switch occurs, use the <kbd>Command</kbd> key in place of the <kbd>Control</kbd> key and the <kbd>Control</kbd> key in place of the <kbd>Command</kbd> key for the above listed key interactions with Mac devices. For example, after switching the keys to group the columns when the header element is focused use <kbd>Command + Space</kbd> and for expanding the visible groups use <kbd>Ctrl + Down Arrow</kbd>.

## Ensuring accessibility

The Syncfusion Blazor DataGrid's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with playwright tests.

The accessibility compliance of the Grid is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/datagrid) in a new window to evaluate the accessibility of the Grid with accessibility tools.

## See also

* [Accessibility in Syncfusion Blazor](https://blazor.syncfusion.com/documentation/common/accessibility)
