---
layout: post
title: Accessibility in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor Gantt Chart component and more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Accessibility in Blazor Gantt Chart Component

The Blazor Gantt component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the Blazor Gantt component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) |<img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Yes"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Yes"> - All features of the component meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate"> - Some features of the component do not meet the requirement.</div>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="No"> - The component does not meet the requirement.</div>

## WAI-ARIA

The Blazor Gantt component followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/) patterns to meet the accessibility. The following ARIA attributes are used in the Blazor Gantt component:

The following ARIA attributes are used in Blazor Gantt:


| **Attributes** | **Description** |
| --- | --- |
| `treegrid (role)` | Used to convey a significant and contextual message to the user. This attribute is added to the `e-table` element present in the Gantt, which represents Grid part. |
| `gridcell (role)` | This attribute is added to the `td` elements present within the `e-table`, which represents the work cells of Gantt .|
| `columnheader (role)` | This attribute is added to the `th` elements within the `e-table`, which represents the header cells of Grid table. |
| `separator (role)` | This attribute is added to the `e-split-bar` element, which represents the splitter between the Grid table and Chart. |
| `dialog (role)` | This attribute is added to the `e-dialog` element, which represents the pop-up dialog. |
| `toolbar (role)` | This attribute is added to the `e-gantt-toolbar` element, which represents the toolbars of Gantt. |
| `aria-label` | It indicates the element's information`<br>`. It is assigned to the Gantt UI elements such as timeline cell, taskbar, left label, right label, dependency line, and event markers. |
| `aria-selected` | This attribute is assigned to the Gantt chart row and is set to `false` by default. The value is changed to `true` when the user selects a grid cell or task. |
| `aria-expanded` | This attribute is assigned to the Gantt chart parent task row. The value is changed to `true` when the user clicks a parent taskbar to expand. After the user clicked a parent taskbar to collapse, the attribute value is changed to `false`. |
| `aria-grabbed` | This attribute is assigned to the taskbars of Gantt when the user tries to achieve taskbar editing. |

## Keyboard navigation

The Gantt component follows the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/) guideline, ensuring accessibility for users of assistive technologies (AT) and those who rely solely on keyboard navigation. The following keyboard shortcuts are supported by the Gantt component:

<b>Focus Elements</b>

**Windows**  | **MAC** | **To do this**
-----|----- | -----
<kbd>Alt + J</kbd> | <kbd>Alt + J</kbd> | Moves the focus to the entire gantt chart.
<kbd>Home</kbd> | <kbd>Fn + Left Arrow</kbd> | Moves the focus to the first cell of the focused row.
<kbd>End</kbd> | <kbd>Fn + Right Arrow</kbd> | Moves the focus to the last cell of the focused row.
<kbd>Ctrl + Home</kbd> | <kbd>Command + Fn + Left Arrow</kbd> | Moves the focus to the first Cell of the first row in the gantt chart.
<kbd>Ctrl + End</kbd> | <kbd>Command +  Fn + Right Arrow</kbd> | Moves the focus to the last Cell of the last row in the gantt chart.
<kbd>Up Arrow</kbd> | <kbd>Up Arrow</kbd> | Moves the cell focus upward from the focused cell.
<kbd>Down Arrow</kbd> | <kbd>Down Arrow</kbd> |  Moves the cell focus downward from the focused cell.
<kbd>Right Arrow</kbd> | <kbd>Right Arrow</kbd> | Moves the cell focus right side from the focused cell.
<kbd>Left Arrow</kbd> | <kbd>Left Arrow</kbd> |  Moves the cell focus left side from the focused cell.
<kbd>Alt + W</kbd> | <kbd>Alt + W</kbd> | Moves the focus to the gantt content element.

<b>Expand/Collapse</b>

**Windows**  | **MAC** | **To do this**
-----|----- | -----
<kbd>Ctrl + Down arrow</kbd> | <kbd>Ctrl + Down arrow</kbd> | Expands all tasks.
<kbd>Ctrl + Up arrow</kbd> | <kbd>Ctrl + Up arrow</kbd> | Collapses all tasks.
<kbd>Ctrl + Shift + Up arrow</kbd> | <kbd>Ctrl + Shift + Up arrow</kbd> | Collapse the selected row.
<kbd>Ctrl + Shift + Down arrow</kbd> | <kbd>Ctrl + Shift + Down arrow</kbd> | Expands the selected row.

<b>Selection</b>

**Windows**  | **MAC** | **To do this**
-----|----- | -----
<kbd>Up Arrow</kbd> | <kbd>Up Arrow</kbd> | Moves up a row/cell selection from the selected row/cell.
<kbd>Down Arrow</kbd> | <kbd>Down Arrow</kbd> | Moves down a row/cell selection from the selected row/cell.
<kbd>Right Arrow</kbd> | <kbd>Right Arrow</kbd> | Moves to the right cell selection from the selected cell.
<kbd>Left Arrow</kbd> | <kbd>Left Arrow</kbd> | Moves to the left cell selection from the selected cell.
<kbd>Shift + Up Arrow</kbd> | <kbd>Shift + Up Arrow</kbd> | Extends the row/cell selection upwards from the selected row/cell.
<kbd>Shift + Down Arrow</kbd> | <kbd>Shift + Down Arrow</kbd> | Extends the row/cell selection downwards from the selected row/cell.
<kbd>Shift + Right Arrow</kbd> | <kbd>Shift + Right Arrow</kbd> | Extends the cell selection to the right side from the selected cell.
<kbd>Shift + Left Arrow</kbd> | <kbd>Shift + Left Arrow</kbd> | Extends the cell selection to the left side from the selected cell.
<kbd>Enter</kbd> | <kbd>Enter</kbd> | Moves the row/cell selection downward from the selected cell/row.
<kbd>Shift + Enter</kbd> | <kbd>Shift + Enter</kbd> | Moves the row/cell selection upward.
<kbd>Esc</kbd> | <kbd>Esc</kbd> | Deselects all the selected row/cells.
<kbd>Ctrl + A</kbd> | <kbd>Ctrl + A</kbd> | Select all the row/cells in the current page.

<b>Clipboard</b>

**Windows**  | **MAC** | **To do this**
-----|----- | -----
<kbd>Ctrl + C</kbd> | <kbd>Command + C</kbd> | Copies selected rows or cells data into the clipboard.
<kbd>Ctrl + Shift + H</kbd> | <kbd>Ctrl + Shift + H</kbd> | Copies selected rows or cells data with header into clipboard.
 
<b>Context Menu</b>

**Windows**  | **MAC** | **To do this**
-----|----- | -----
<kbd>Esc</kbd> | <kbd>Esc</kbd> | Closes the opened sub menu.
<kbd>Enter</kbd> | <kbd>Enter</kbd> | Selects the focused item. 
<kbd>Up</kbd> | <kbd>Up</kbd> | Navigates up or to the previous menu item.
<kbd>Down</kbd> |  <kbd>Down</kbd> | Navigates down or to the next menu item.
<kbd>Left</kbd> | <kbd>Left</kbd> | Close the current sub menu and navigates to the parent menu.
<kbd>Right</kbd> | <kbd>Right</kbd> | Navigates and open the next sub menu.

<b>Cell Editing</b>

**Windows**  | **MAC** | **To do this**
-----|----- | -----
<kbd>F2</kbd> | <kbd>F2</kbd> | Starts editing of selected Row/cell.
<kbd>Enter</kbd> | <kbd>Enter</kbd> | Saves current cell.
<kbd>Insert</kbd> | <kbd>Ctrl + Command + Enter<kbd> | Creates a new add form based on the new row position.
<kbd>Delete</kbd> | <kbd>Delete</kbd> | Deletes the current selected record.
<kbd>Tab</kbd> | <kbd>Tab</kbd> | Navigates to the next editable cell, saves the current cell, and starts editing the next cell.
<kbd>Shift + Tab</kbd> | <kbd>Shift + Tab</kbd> | Navigates to the previous editable cell, saves the current cell, and starts editing the previous cell.
<kbd>Shift + Enter</kbd> | <kbd>Shift + Enter</kbd> | Saves the current cell and starts editing the previous row cell.

<b>Filtering</b>

**Windows**  | **MAC** | **To do this**
-----|----- | -----
<kbd>Alt + Down arrow</kbd> | <kbd>Alt + Down arrow</kbd> | Opens the filter menu when its header element is in focused state.

<b>Column Menu</b>

**Windows**  | **MAC** | **To do this**
-----|----- | -----
<kbd>Alt + Down arrow</kbd> | <kbd>Alt + Down arrow</kbd> | Opens column menu when its header element is in focused state.

<b>Reordering</b>

**Windows**  | **MAC** | **To do this**
-----|----- | -----
<kbd>Ctrl + left arrow or right arrow</kbd> | <kbd>Command  + left arrow or right arrow</kbd> | Reorders the focused header column to the left or right side.

<b>Sorting</b>

**Windows**  | **MAC** | **To do this**
-----|----- | -----
<kbd>Enter</kbd> | <kbd>Enter</kbd> | Performs sorting(ascending/descending) on a column when its header element is in focused state.
<kbd>Ctrl + Enter</kbd> | <kbd>Command + Enter</kbd> | Performs multi-sorting on a column when its header element is in focused state.
<kbd>Shift + Enter</kbd> | <kbd>Shift + Enter</kbd> | Clears sorting for the focused header column.

<b>Toolbar</b>

**Windows**  | **MAC** | **To do this**
-----|----- | -----
<kbd>Left</kbd> | <kbd>Left</kbd> | Focuses the previous element.
<kbd>Right</kbd> | <kbd>Right</kbd> | Focuses the next element.
<kbd>Enter</kbd> | <kbd>Enter</kbd> | Performs the focused toolbar element action.

<b>Tooltip</b>

**Windows**  | **MAC** | **To do this**
-----|----- | -----
<kbd>Escape</kbd> | <kbd>Escape</kbd> | Closes or dismisses the tooltip.
<kbd>Tab</kbd> | <kbd>Tab</kbd> | A form control receiving focus (say through tab key), opens the tooltip, and on focus out closes it.

<b>Dialog Editing</b>

**Windows**  | **MAC** | **To do this**
-----|----- | -----
<kbd>Ctrl + Insert</kbd> | <kbd>Command + Insert</kbd> | Opens the add row dialog popup.
<kbd>Ctrl + F2</kbd> | <kbd>Command + F2</kbd> | Opens the edit row dialog popup.
<kbd>Del</kbd> | <kbd>Del</kbd> | Deletes the currently selected record.
<kbd>Enter</kbd> | <kbd>Enter</kbd> | Saves the current row.
<kbd>Esc</kbd> | <kbd>Esc</kbd> | Closes the dialog.
<kbd>Tab</kbd> | <kbd>Tab</kbd> | Navigates to the next editable cell, saves the current cell, and starts editing the next cell in the dialog elements.
<kbd>Shift + Tab</kbd> | <kbd>Shift + Tab</kbd> | Navigates to the previous editable cell, saves the current cell, and starts editing the previous cell in the dialog elements. 


## Ensuring accessibility

The Blazor Gantt component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with playwright tests.

The accessibility compliance of the Blazor Gantt component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/gantt-chart) in a new window to evaluate the accessibility of the Blazor Gantt component with accessibility tools.

N> You can refer to our [Blazor Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Gantt Chart example](https://blazor.syncfusion.com/demos/gantt-chart/default-functionalities?theme=bootstrap5) to know how to render and configure the Gantt.

## See also

* [Accessibility in Syncfusion Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)