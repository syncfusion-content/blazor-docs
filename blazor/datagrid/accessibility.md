---
layout: post
title: Accessibility in Blazor DataGrid | Syncfusion
description: Learn how to make the Syncfusion Blazor DataGrid accessible with WCAG 2.2 and Section 508 support, ARIA roles, keyboard navigation, and screen reader support.
platform: Blazor
control: DataGrid
documentation: ug
---

# Accessibility in Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid follows accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), and [WCAG 2.2](https://www.w3.org/TR/WCAG22/), and uses appropriate [ARIA roles](https://www.w3.org/TR/wai-aria/#roles) commonly referenced for accessibility evaluations.

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

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid follows the [WAI-ARIA grid pattern](https://www.w3.org/WAI/ARIA/apg/patterns/grid/) to meet accessibility requirements. The following ARIA roles and attributes are used in the Grid:

| Attributes          | Purpose                                                                                                                       |
|---------------------|-------------------------------------------------------------------------------------------------------------------------------|
| `role=grid`         | Represents the element containing the Grid.                                                                                   |
| `role=row`          | Represents a row that contains cells in the Grid.                                                                             |
| `role=rowgroup`     | Represents a group of rows in the Grid.                                                                                       |
| `role=columnheader` | Represents a header cell that provides header information for a column in the Grid.                                           |
| `role=gridcell`     | Represents a data cell in the Grid.                                                                                           |
| `role=button`       | Represents an element that acts as a button in the Grid.                                                                      |
| `role=search`       | Represents an element that acts as a search region in the Grid.                                                               |
| `role=presentation` | Indicates an element is not exposed to assistive technologies.                                                                |
| `role=navigation`   | Represents the element containing pager elements to navigate between pages.                                                   |
| `aria-colindex`     | Defines the column index of a column relative to the total number of columns.                                                 |
| `aria-rowindex`     | Defines the row index relative to the total number of rows.                                                                   |
| `aria-rowspan`      | Defines the number of rows spanned by a cell.                                                                                 |
| `aria-colspan`      | Defines the number of columns spanned by a cell.                                                                              |
| `aria-rowcount`     | Defines the total number of rows in the Grid.                                                                                 |
| `aria-colcount`     | Defines the total number of columns in the Grid.                                                                              |
| `aria-selected`     | Indicates the selected state of rows and cells.                                                                               |
| `aria-expanded`     | Indicates whether the expand icon in a hierarchical, grouped, or detail Grid is expanded or collapsed.                        |
| `aria-sort`         | Indicates whether data in the Grid is sorted in ascending or descending order.                                                |
| `aria-busy`         | Indicates an element is being modified so assistive technologies may defer announcements until updates complete.              |
| `aria-owns`         | Identifies related elements to define visual, functional, or contextual relationships.                                        |
| `aria-hidden`       | Hides an element from assistive technologies.                                                                                 |
| `aria-labelledby`   | Provides an accessible name for elements such as checkbox labels in Excel filter, checkbox filter, and column chooser dialog. |
| `aria-describedby`  | Provides a description of features enabled in the header when a Grid header cell receives focus.                              |

The Grid uses a two-table structure for header and content. Roles and ARIA attributes are applied to the Grid parent and child elements to improve screen reader support. This architecture can trigger warnings in automated accessibility checkers; however, it does not affect how screen readers read Grid content.

Accessibility checker tools highlight the following known issues:

* aria-required-children: Appears when rendering the Grid without features (for example, with textarea and Grid content) and when enabling features such as the toolbar and grouping.
* color-contrast: May appear when the search item is enabled in the Grid toolbar, depending on theme colors.
* An explicit ARIA role is not valid for the `<tr>` element within a `role="grid"` context per ARIA in HTML.
* An explicit ARIA role is not valid for the `<th>` element within a `role="grid"` context per ARIA in HTML.
* An explicit ARIA role is not valid for the `<td>` element within a `role="grid"` context per ARIA in HTML.
* The element with role "button" contains descendants with role "rowgroup," which browsers ignore.
* Content is not within a landmark element.
* Multiple elements with the "search" role do not have unique labels.
* Text contrast of 4.10 with its background is less than the WCAG AA minimum for 13px/400 text.
* An interactive element with `role="grid"` does not have a programmatically associated name.
* The element with role "rowgroup" is not contained in or owned by an element with one of the following roles: grid, table, treegrid.

To address these, ensure appropriate landmarks (for example, header, main, nav) are used in the page layout, provide unique labels for multiple search regions (aria-label or aria-labelledby), and verify color contrast meets WCAG 2.2 AA. When customizing styles, retain visible focus indicators and a logical focus order.

## Keyboard interaction

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid follows the [ARIA grid keyboard interaction guidance](https://www.w3.org/WAI/ARIA/apg/patterns/grid/#keyboard-interaction), enabling efficient navigation for users of assistive technologies and those relying on keyboard input. The following keyboard shortcuts are supported by the Grid.

<b>Pager</b>

| Windows                                                                 | Mac                                 | Actions                                |
|-------------------------------------------------------------------------|-------------------------------------|----------------------------------------|
| <kbd>Tab</kbd>                                                          | <kbd>Tab</kbd>                      | Move focus to the next pager item.     |
| <kbd>Shift</kbd> + <kbd>Tab</kbd>                                       | <kbd>⇧</kbd> + <kbd>Tab</kbd>       | Move focus to the previous pager item. |
| <kbd>Enter</kbd> / <kbd>Space</kbd>                                     | <kbd>Enter</kbd> / <kbd>Space</kbd> | Select the currently focused page.     |
| <kbd>PageUp</kbd> / <kbd>←</kbd>                                        | <kbd>←</kbd>                        | Navigate to the previous page.         |
| <kbd>PageDown</kbd> / <kbd>→</kbd>                                      | <kbd>→</kbd>                        | Navigate to the next page.             |
| <kbd>Home</kbd> / <kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>PageUp</kbd>  | <kbd>Fn</kbd> + <kbd>←</kbd>        | Navigate to the first page.            |
| <kbd>End</kbd> / <kbd>Ctrl</kbd> + <kbd>Alt</kbd> + <kbd>PageDown</kbd> | <kbd>Fn</kbd> + <kbd>→</kbd>        | Navigate to the last page.             |

<b>Focus Elements</b>

| Windows                           | Mac                                         | Actions                                                    |
|-----------------------------------|---------------------------------------------|------------------------------------------------------------|
| <kbd>Home</kbd>                   | <kbd>Fn</kbd> + <kbd>←</kbd>                | Move focus to the first cell of the focused row.           |
| <kbd>End</kbd>                    | <kbd>Fn</kbd> + <kbd>→</kbd>                | Move focus to the last cell of the focused row.            |
| <kbd>Ctrl</kbd> + <kbd>Home</kbd> | <kbd>⌘</kbd> + <kbd>Fn</kbd> + <kbd>←</kbd> | Move focus to the first cell of the first row in the Grid. |
| <kbd>Ctrl</kbd> + <kbd>End</kbd>  | <kbd>⌘</kbd> + <kbd>Fn</kbd> + <kbd>→</kbd> | Move focus to the last cell of the last row in the Grid.   |
| <kbd>↑</kbd>                      | <kbd>↑</kbd>                                | Move the cell focus up from the focused cell.              |
| <kbd>↓</kbd>                      | <kbd>↓</kbd>                                | Move the cell focus down from the focused cell.            |
| <kbd>→</kbd>                      | <kbd>→</kbd>                                | Move the cell focus right from the focused cell.           |
| <kbd>←</kbd>                      | <kbd>←</kbd>                                | Move the cell focus left from the focused cell.            |
| <kbd>Alt</kbd> + <kbd>J</kbd>     | <kbd>⌥</kbd> + <kbd>J</kbd>                 | Move focus to the Grid.                                    |
| <kbd>Alt</kbd> + <kbd>W</kbd>     | <kbd>⌥</kbd> + <kbd>W</kbd>                 | Move focus to the Grid content element.                    |

<b>Selection</b>

| Windows                             | Mac                             | Actions                                    |
|-------------------------------------|---------------------------------|--------------------------------------------|
| <kbd>↑</kbd>                        | <kbd>↑</kbd>                    | Move the row/cell selection up.            |
| <kbd>↓</kbd>                        | <kbd>↓</kbd>                    | Move the row/cell selection down.          |
| <kbd>→</kbd>                        | <kbd>→</kbd>                    | Move the cell selection right.             |
| <kbd>←</kbd>                        | <kbd>←</kbd>                    | Move the cell selection left.              |
| <kbd>Shift</kbd> + <kbd>↑</kbd>     | <kbd>⇧</kbd> + <kbd>↑</kbd>     | Extend the row/cell selection upward.      |
| <kbd>Shift</kbd> + <kbd>↓</kbd>     | <kbd>⇧</kbd> + <kbd>↓</kbd>     | Extend the row/cell selection downward.    |
| <kbd>Shift</kbd> + <kbd>→</kbd>     | <kbd>⇧</kbd> + <kbd>→</kbd>     | Extend the cell selection to the right.    |
| <kbd>Shift</kbd> + <kbd>←</kbd>     | <kbd>⇧</kbd> + <kbd>←</kbd>     | Extend the cell selection to the left.     |
| <kbd>Enter</kbd>                    | <kbd>Enter</kbd>                | Move the row/cell selection down.          |
| <kbd>Shift</kbd> + <kbd>Enter</kbd> | <kbd>⇧</kbd> + <kbd>Enter</kbd> | Move the row/cell selection up.            |
| <kbd>Esc</kbd>                      | <kbd>Esc</kbd>                  | Deselect all selected rows/cells.          |
| <kbd>Ctrl</kbd> + <kbd>A</kbd>      | <kbd>⌘</kbd> + <kbd>A</kbd>     | Select all rows/cells on the current page. |

<b>Grouping</b>

| Windows                            | Mac                             | Actions                             |
|------------------------------------|---------------------------------|-------------------------------------|
| <kbd>Ctrl</kbd> + <kbd>↑</kbd>     | <kbd>⌘</kbd> + <kbd>↑</kbd>     | Collapse all visible groups.        |
| <kbd>Ctrl</kbd> + <kbd>↓</kbd>     | <kbd>⌘</kbd> + <kbd>↓</kbd>     | Expand all visible groups.          |
| <kbd>Ctrl</kbd> + <kbd>Space</kbd> | <kbd>⌘</kbd> + <kbd>Space</kbd> | Group by the focused header column. |
| <kbd>Alt</kbd> + <kbd>↑</kbd>      | <kbd>⌥</kbd> + <kbd>↑</kbd>     | Collapse the selected group.        |
| <kbd>Alt</kbd> + <kbd>↓</kbd>      | <kbd>⌥</kbd> + <kbd>↓</kbd>     | Expand the selected group.          |

<b>Print</b>

| Windows                        | Mac                         | Actions         |
|--------------------------------|-----------------------------|-----------------|
| <kbd>Ctrl</kbd> + <kbd>P</kbd> | <kbd>⌘</kbd> + <kbd>P</kbd> | Print the Grid. |

<b>Clipboard</b>

| Windows                                           | Mac                                        | Actions                                                    |
|---------------------------------------------------|--------------------------------------------|------------------------------------------------------------|
| <kbd>Ctrl</kbd> + <kbd>C</kbd>                    | <kbd>⌘</kbd> + <kbd>C</kbd>                | Copy selected rows or cells to the clipboard.              |
| <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>H</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>H</kbd> | Copy selected rows or cells with headers to the clipboard. |

<b>Editing</b>

| Windows                             | Mac                             | Actions                                                                                                                      |
|-------------------------------------|---------------------------------|------------------------------------------------------------------------------------------------------------------------------|
| <kbd>F2</kbd>                       | <kbd>F2</kbd>                   | Start editing the selected row (Normal/Dialog) or the selected cell (Batch).                                                 |
| <kbd>Enter</kbd>                    | <kbd>Enter</kbd>                | Save the form (Normal/Dialog) or save the current cell and start editing the next row cell (Batch).                          |
| <kbd>Insert</kbd>                   | <kbd>⌥</kbd> + <kbd>Enter</kbd> | Create a new add form based on the NewRowPosition.                                                                           |
| <kbd>Delete</kbd>                   | <kbd>Delete</kbd>               | Delete the selected record.                                                                                                  |
| <kbd>Tab</kbd>                      | <kbd>Tab</kbd>                  | Navigate to the next editable cell (Normal/Dialog) or save the current cell and start editing the next cell (Batch).         |
| <kbd>Shift</kbd> + <kbd>Tab</kbd>   | <kbd>⇧</kbd> + <kbd>Tab</kbd>   | Navigate to the previous editable cell (Normal/Dialog) or save the current cell and start editing the previous cell (Batch). |
| <kbd>Shift</kbd> + <kbd>Enter</kbd> | <kbd>⇧</kbd> + <kbd>Enter</kbd> | Save the current cell and start editing the previous row cell (Batch).                                                       |

<b>Filtering</b>

| Windows                       | Mac                         | Actions                                                                     |
|-------------------------------|-----------------------------|-----------------------------------------------------------------------------|
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | Open the filter menu (Excel, menu, or checkbox) when its header is focused. |

<b>Column Menu</b>

| Windows                       | Mac                           | Actions                                          |
|-------------------------------|-------------------------------|--------------------------------------------------|
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>Alt</kbd> + <kbd>↓</kbd> | Open the column menu when its header is focused. |

<b>Reordering</b>

| Windows | Mac | Actions |
| ----- | ----- | ----- |
| <kbd>Ctrl</kbd> + <kbd>←</kbd> / <kbd>→</kbd> | <kbd>⌘</kbd> + <kbd>←</kbd> / <kbd>→</kbd> | Reorder the focused header column to the left or right. |

<b>Sorting</b>

| Windows                                       | Mac                                        | Actions                                                 |
|-----------------------------------------------|--------------------------------------------|---------------------------------------------------------|
| <kbd>Ctrl</kbd> + <kbd>←</kbd> / <kbd>→</kbd> | <kbd>⌘</kbd> + <kbd>←</kbd> / <kbd>→</kbd> | Reorder the focused header column to the left or right. |
<br>

> The <kbd>Command</kbd> and <kbd>Control</kbd> keys on Mac devices can be interchanged. When this switch occurs, use the <kbd>Command</kbd> key in place of the <kbd>Control</kbd> key and the <kbd>Control</kbd> key in place of the <kbd>Command</kbd> key for the above key interactions. For example, after switching the keys, to group columns when a header is focused, use <kbd>Command + Space</kbd>, and to expand visible groups use <kbd>Ctrl + Down Arrow</kbd>.

## Ensuring accessibility

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid’s accessibility is validated using [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with Playwright tests.

The accessibility compliance of the Grid is demonstrated in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/datagrid) in a new window to evaluate the Grid with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor](https://blazor.syncfusion.com/documentation/common/accessibility)