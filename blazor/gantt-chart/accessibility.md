---
layout: post
title: Accessibility in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor Gantt Chart component and more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Accessibility in Blazor Gantt Chart Component

The Syncfusion Blazor Gantt Chart component adheres to accessibility guidelines, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/), and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) standards, ensuring compatibility with assistive technologies, including those relying on assistive technologies.

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

The Blazor Gantt component implements [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/) patterns to enhance accessibility. The following ARIA attributes are applied:

The following ARIA attributes are used in Blazor Gantt:

| Attributes | Description |
|------------|-------------|
| `treegrid (role)` | Applied to the `e-table` element in the Gantt's grid section to indicate a treegrid structure. |
| `gridcell (role)` | Added to `td` elements within the `e-table` to represent work cells in the Gantt grid. |
| `columnheader (role)` | Assigned to `th` elements within the `e-table` to denote header cells in the grid. |
| `separator (role)` | Used for the `e-split-bar` element, representing the splitter between the grid and chart sections. |
| `dialog (role)` | Applied to the `e-dialog` element for pop-up dialogs in the Gantt. |
| `toolbar (role)` | Assigned to the `e-gantt-toolbar` element to indicate the toolbar. |
| `aria-label` | Provides descriptive information for UI elements, such as timeline cells, taskbars, labels, dependency lines, and event markers. |
| `aria-selected` | Indicates selection state for chart rows, set to **false** by default and `true` when a cell or task is selected. |
| `aria-expanded` | Used for parent task rows, set to `true` when expanded and **false** when collapsed. |
| `aria-grabbed` | Applied to taskbars during editing to indicate drag-and-drop interaction. |

## Keyboard navigation

The Gantt component follows the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/) guideline, ensuring accessibility for users of assistive technologies (AT) and those who rely solely on keyboard navigation. The following keyboard shortcuts are supported by the Gantt component:

### Focus elements

| Windows | MAC | Actions |
| ----- | ----- | ----- |
| <kbd>Alt</kbd> + <kbd>J</kbd> | <kbd>⌥</kbd> + <kbd>J</kbd> | Moves the focus to the entire gantt chart. |
| <kbd>Home</kbd> | <kbd>Fn</kbd> + <kbd>←</kbd> | Moves the focus to the first cell of the focused row. |
| <kbd>End</kbd> | <kbd>Fn</kbd> + <kbd>→</kbd> | Moves the focus to the last cell of the focused row. |
| <kbd>Ctrl</kbd> + <kbd>Home</kbd> | <kbd>⌘</kbd> + <kbd>Fn</kbd> + <kbd>←</kbd> | Moves the focus to the first Cell of the first row in the gantt chart. |
| <kbd>Ctrl</kbd> + <kbd>End</kbd> | <kbd>⌘</kbd> + <kbd>Fn</kbd> + <kbd>→</kbd> | Moves the focus to the last Cell of the last row in the gantt chart. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Moves the cell focus upward from the focused cell. |
| <kbd>↓</kbd> | <kbd>↓</kbd> |  Moves the cell focus downward from the focused cell. |
| <kbd>→</kbd> | <kbd>→</kbd> | Moves the cell focus right side from the focused cell. |
| <kbd>←</kbd> | <kbd>←</kbd> |  Moves the cell focus left side from the focused cell. |
| <kbd>Alt</kbd> + <kbd>W</kbd> | <kbd>⌥</kbd> + <kbd>W</kbd> | Moves the focus to the gantt content element. |

### Expand/Collapse

| Windows | MAC | Actions |
| ----- | ----- | ----- |
| <kbd>Ctrl</kbd> + <kbd>↓</kbd> | <kbd>⌘</kbd> + <kbd>↓</kbd> | Expands all tasks. |
| <kbd>Ctrl</kbd> + <kbd>↑</kbd> | <kbd>⌘</kbd> + <kbd>↑</kbd> | Collapses all tasks. |
| <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>↑</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>↑</kbd> | Collapse the selected row. |
| <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>↓</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>←</kbd> | Expands the selected row. |

### Selection

| Windows | MAC | Actions |
| ----- | ----- | ----- |
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

### Clipboard

| Windows | Mac | Action |
|---------|-----|--------|
| <kbd>Ctrl</kbd> + <kbd>C</kbd> | <kbd>⌘</kbd> + <kbd>C</kbd> | Copies selected rows or cells to the clipboard. |
| <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>H</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>H</kbd> | Copies selected rows or cells with headers to the clipboard. |

### Context menu

| Windows | MAC | Actions |
| ----- | ----- | ----- |
| <kbd>Esc</kbd> | <kbd>Esc</kbd> | Closes the opened sub menu. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Selects the focused item. |
| <kbd>Up</kbd> | <kbd>Up</kbd> | Navigates up or to the previous menu item. |
| <kbd>Down</kbd> |  <kbd>Down</kbd> | Navigates down or to the next menu item. |
| <kbd>Left</kbd> | <kbd>Left</kbd> | Close the current sub menu and navigates to the parent menu. |
| <kbd>Right</kbd> | <kbd>Right</kbd> | Navigates and open the next sub menu. |

### Cell editing

| Windows | MAC | Actions |
| ----- | ----- | ----- |
| <kbd>F2</kbd> | <kbd>F2</kbd> | Starts editing of selected Row/cell. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Saves current cell. |
| <kbd>Insert</kbd> | <kbd>⌘</kbd> + <kbd>Enter</kbd> | Creates a new add form based on the new row position. |
| <kbd>Delete</kbd> | <kbd>Delete</kbd> | Deletes the current selected record. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Navigates to the next editable cell, saves the current cell, and starts editing the next cell. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Navigates to the previous editable cell, saves the current cell, and starts editing the previous cell. |
| <kbd>Shift</kbd> + <kbd>Enter</kbd> | <kbd>⇧</kbd> + <kbd>Enter</kbd> | Saves the current cell and starts editing the previous row cell. |

### Filtering

| Windows | MAC | Actions |
| ----- | ----- | ----- |
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | Opens the filter menu when its header element is in focused state. |

### Column Menu

| Windows | MAC | Actions |
| ----- | ----- | ----- |
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | Opens column menu when its header element is in focused state. |

### Reordering

| Windows | MAC | Actions |
| ----- | ----- | ----- |
| <kbd>Ctrl</kbd> + <kbd>←</kbd> / <kbd>→</kbd> | <kbd>⌘</kbd> + <kbd>←</kbd> / <kbd>→</kbd> | Reorders the focused header column to the left or right side. |

### Sorting

| Windows | MAC | Actions |
| ----- | ----- | ----- |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Performs sorting(ascending/descending) on a column when its header element is in focused state. |
| <kbd>Ctrl</kbd> + <kbd>Enter</kbd> | <kbd>⌘</kbd> + <kbd>Enter</kbd> | Performs multi-sorting on a column when its header element is in focused state. |
| <kbd>Shift</kbd> + <kbd>Enter</kbd> | <kbd>⇧</kbd> + <kbd>Enter</kbd> | Clears sorting for the focused header column. |

### Toolbar

| Windows | MAC | Actions |
| ----- | ----- | ----- |
| <kbd>←</kbd> | <kbd>←</kbd> | Focuses the previous element. |
| <kbd>→</kbd> | <kbd>→</kbd> | Focuses the next element. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Performs the focused toolbar element action. |

### Tooltip

| Windows | MAC | Actions |
| ----- | ----- | ----- |
| <kbd>Escape</kbd> | <kbd>Escape</kbd> | Closes or dismisses the tooltip. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | A form control receiving focus (say through tab key), opens the tooltip, and on focus out closes it. |

### Dialog editing

| Windows | MAC | Actions |
| ----- | ----- | ----- |
| <kbd>Ctrl</kbd> + <kbd>Insert</kbd> | <kbd>⌘</kbd> + <kbd>Insert</kbd> | Opens the add row dialog popup. |
| <kbd>Ctrl</kbd> + <kbd>F2</kbd> | <kbd>⌘ + F2</kbd> | Opens the edit row dialog popup. |
| <kbd>Del</kbd> | <kbd>Del</kbd> | Deletes the currently selected record. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Saves the current row. |
| <kbd>Esc</kbd> | <kbd>Esc</kbd> | Closes the dialog. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Navigates to the next editable cell, saves the current cell, and starts editing the next cell in the dialog elements. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Navigates to the previous editable cell, saves the current cell, and starts editing the previous cell in the dialog elements. |

## Validate Accessibility Compliance

Accessibility is validated using [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with Playwright tests to ensure compliance with WCAG 2.2 and other standards. Evaluate the accessibility of the Blazor Gantt Chart component using the [sample](https://blazor.syncfusion.com/accessibility/gantt-chart) in a new window with accessibility tools.

## Related Resources

- [Accessibility in Syncfusion Blazor Components](https://blazor.syncfusion.com/documentation/common/accessibility)
- [Blazor Gantt Chart Feature Tour](https://www.syncfusion.com/blazor-components/blazor-gantt-chart)
- [Blazor Gantt Chart Example](https://blazor.syncfusion.com/demos/gantt-chart/default-functionalities?theme=bootstrap5)