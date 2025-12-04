---
layout: post
title: Accessibility in Blazor DataGrid | Syncfusion
description: Learn how to make the Syncfusion Blazor DataGrid accessible with WCAG 2.2 and Section 508 support, ARIA roles, keyboard navigation, and screen reader support.
platform: Blazor
control: DataGrid
documentation: ug
---

# Accessibility in Blazor DataGrid

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid is built to support widely accepted accessibility standards. These standards help ensure that the component is usable by individuals with varying abilities, including those using assistive technologies.
Supported guidelines include:

- [Americans with Disabilities Act (ADA)]((https://www.ada.gov/))
- [Section 508](https://www.section508.gov/)
- [Web Content Accessibility Guidelines (WCAG) 2.2](https://www.w3.org/TR/WCAG22/)
- [ARIA roles](https://www.w3.org/TR/wai-aria/#roles) for semantic structure and screen reader compatibility

| Accessibility Criteria | Compatibility | Description |
|-----------------------|---------------|-------------|
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> | Supports most WCAG 2.2 guidelines, such as color contrast (1.4.3) and keyboard accessibility (2.1.1), with some limitations in complex interactions. |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> | Complies with most Section 508 requirements, with minor gaps in advanced interactive elements. |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> | Implements ARIA roles (e.g., `role="grid"`, `aria-label`) for compatibility with screen readers like JAWS and NVDA. |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> | Supports right-to-left (RTL) layouts for languages like Arabic and Hebrew using the `EnableRtl` property. |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> | Meets WCAG 2.2 minimum contrast ratios for text and visual elements. |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> | Ensures touch-based navigation and compatibility with mobile screen readers. |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> | Supports standard keyboard interactions (e.g., Tab, Arrow keys), with limitations in some advanced features like filtering. |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> | Passes most Axe-core checks, with minor issues in specific ARIA configurations. |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>
**Support Level Indicators:**

<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> - All features meet the accessibility requirement..</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> - Some features meet the requirement; others may need improvement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="No"> - The feature does not meet the requirement.</div>

## WAI-ARIA attributes

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid implements the [WAI-ARIA grid pattern](https://www.w3.org/WAI/ARIA/apg/patterns/grid/) to support accessibility requirements. This ensures compatibility with assistive technologies such as screen readers, including **JAWS** and **NVDA**. WAI-ARIA (Web Accessibility Initiative – Accessible Rich Internet Applications) attributes define roles, states, and properties that make the DataGrid accessible to individuals with disabilities.

| Attribute | Purpose |
|-----------|---------|
| `role=grid` | Identifies the element as a grid container. |
| `role=row` | Defines a row containing cells within the grid. |
| `role=rowgroup` | Groups multiple rows, such as in grouped or hierarchical grids. |
| `role=columnheader` | Specifies a header cell providing column information. |
| `role=gridcell` | Indicates a data cell within the grid. |
| `role=button` | Represents interactive elements that function as buttons. |
| `role=search` | Identifies search regions, such as in the toolbar. |
| `role=presentation` | Hides elements from assistive technologies when not relevant. |
| `role=navigation` | Defines pager elements for page navigation. |
| `aria-colindex` | Specifies the column index relative to the total number of columns. |
| `aria-rowindex` | Specifies the row index relative to the total number of rows. |
| `aria-rowspan` | Indicates the number of rows spanned by a cell. |
| `aria-colspan` | Indicates the number of columns spanned by a cell. |
| `aria-selected` | Indicates the selection state of rows or cells. |
| `aria-expanded` | Shows whether expand/collapse icons are expanded in hierarchical or grouped grids. |
| `aria-sort` | Indicates sorting order (ascending or descending) for columns. |
| `aria-owns` | Defines relationships between elements for visual or functional context. |
| `aria-hidden` | Hides elements from assistive technologies. |
| `aria-labelledby` | Provides accessible names for elements like checkboxes in filters or dialogs. |
| `aria-describedby` | Describes features enabled in a header cell when it receives focus. |

The Grid uses a two-table structure for header and content. ARIA roles and attributes are applied to parent and child elements to enhance screen reader support. This structure may trigger warnings in automated accessibility tools, but it does not affect how screen readers interpret the content.

Accessibility checker tools may report the following known issues:

* **aria-required-children:** Appears when rendering the Grid without certain features or when toolbar and grouping are enabled. Ensure required child roles are present and suppress false positives if the structure is intentional.
* **color-contrast:** Can occur when the search item is enabled in the toolbar. Adjust theme variables or apply custom CSS to meet WCAG 2.2 AA contrast requirements.
* **Invalid explicit ARIA roles on <tr>, <th>, <td>:** These warnings result from applying roles like row, columnheader, and gridcell to support assistive technologies. Confirm that navigation remains functional and document exceptions for audits.
* **Role inheritance conflicts (role="button" with rowgroup descendants):** May appear when toolbar cells contain buttons. Maintain DOM hierarchy and verify focus order manually.
* **Content not within a landmark element:** Add page-level landmarks (<header>, <main>, <nav>) to scope interactive regions.
* **Multiple elements with role="search" lacking unique labels:** Assign unique aria-label or aria-labelledby attributes to each search region.
* **Text contrast 4.10:** Improve contrast ratio to at least 4.5:1 using CSS for standard text.
*** Grid lacks a programmatic name:** Set aria-label or aria-labelledby on the main Grid container.
* **role="rowgroup" not owned by a grid:** Ensure grouped content remains within the element that has role="grid".

To improve accessibility, apply page landmarks, assign unique labels to search regions, and verify that color contrast meets WCAG 2.2 AA standards. When customizing styles, maintain visible focus indicators and a logical focus order.

## Keyboard interaction

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid supports keyboard navigation based on the ARIA grid [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/grid/#keyboard-interaction) guidelines. This enables efficient navigation for scenarios involving keyboard input or assistive technologies.

The supported keyboard shortcuts are listed below.

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

> On Mac devices, the <kbd>Command</kbd> and <kbd>Control</kbd> keys can be interchanged based on system settings. When this switch is active, use the <kbd>Command</kbd> key in place of <kbd>Control</kbd>, and <kbd>Control</kbd> in place of <kbd>Command</kbd> for keyboard interactions.
For example:

- To group columns when a header is focused, use <kbd>Command + Space</kbd>.
- To expand visible groups, use <kbd>Ctrl + Down Arrow</kbd>.

## Ensuring accessibility

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor DataGrid is validated for accessibility using [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) integrated with Playwright tests.
Accessibility compliance can be evaluated using the interactive [sample](https://blazor.syncfusion.com/accessibility/datagrid), which demonstrates the Grid's behavior with accessibility tools and validation steps.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor](https://blazor.syncfusion.com/documentation/common/accessibility)