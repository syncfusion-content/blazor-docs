---
layout: post
title: Accessibility in Blazor Gantt Chart Component | Syncfusion
description: Learn about accessibility features in the Syncfusion Blazor Gantt Chart component, including WCAG 2.2, Section 508, and keyboard navigation support.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Accessibility in Blazor Gantt Chart Component

The Syncfusion Blazor Gantt Chart component adheres to accessibility guidelines, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/), and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) standards, ensuring compatibility with assistive technologies, including those relying on assistive technologies.

## Accessibility Compliance

The table below summarizes the accessibility compliance of the Blazor Gantt Chart component.

| Accessibility Criteria | Compatibility |
|------------------------|---------------|
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate compatibility"> |
| [Section 508 Support](../common/accessibility#accessibility-standards) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Full compatibility"> |
| [Screen Reader Support](../common/accessibility#screen-reader-support) | <img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate compatibility"> |
| [Right-To-Left Support](../common/accessibility#right-to-left-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Full compatibility"> |
| [Color Contrast](../common/accessibility#color-contrast) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Full compatibility"> |
| [Mobile Device Support](../common/accessibility#mobile-device-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Full compatibility"> |
| [Keyboard Navigation Support](../common/accessibility#keyboard-navigation-support) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Full compatibility"> |
| [Axe-core Accessibility Validation](../common/accessibility#ensuring-accessibility) | <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" alt="Full compatibility"> |

<style>
    .post .post-content img {
        display: inline-block;
        margin: 0.5em 0;
    }
</style>

<div><img src="https://cdn.syncfusion.com/content/images/documentation/full.png" alt="Full compatibility"> - All features meet the requirement.</div>
<div><img src="https://cdn.syncfusion.com/content/images/documentation/partial.png" alt="Intermediate compatibility"> - Some features do not fully meet the requirement.</div>
<div><img src="https://cdn.syncfusion.com/content/images/documentation/not-supported.png" alt="No compatibility"> - The component does not meet the requirement.</div>

## WAI-ARIA attributes

The Blazor Gantt Chart component implements [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/) patterns to enhance accessibility. The following ARIA attributes are applied:

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

The Blazor Gantt Chart component supports comprehensive [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/) for users relying on keyboards or assistive technologies. Below are the supported keyboard shortcuts, organized by functionality.

### Focus elements

| Windows | Mac | Action |
|---------|-----|--------|
| <kbd>Alt</kbd> + <kbd>J</kbd> | <kbd>⌥</kbd> + <kbd>J</kbd> | Focuses the entire Gantt chart. |
| <kbd>Home</kbd> | <kbd>Fn</kbd> + <kbd>←</kbd> | Moves focus to the first cell of the current row. |
| <kbd>End</kbd> | <kbd>Fn</kbd> + <kbd>→</kbd> | Moves focus to the last cell of the current row. |
| <kbd>Ctrl</kbd> + <kbd>Home</kbd> | <kbd>⌘</kbd> + <kbd>Fn</kbd> + <kbd>←</kbd> | Moves focus to the first cell of the first row. |
| <kbd>Ctrl</kbd> + <kbd>End</kbd> | <kbd>⌘</kbd> + <kbd>Fn</kbd> + <kbd>→</kbd> | Moves focus to the last cell of the last row. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Moves focus to the cell above the current cell. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Moves focus to the cell below the current cell. |
| <kbd>→</kbd> | <kbd>→</kbd> | Moves focus to the cell to the right. |
| <kbd>←</kbd> | <kbd>←</kbd> | Moves focus to the cell to the left. |
| <kbd>Alt</kbd> + <kbd>W</kbd> | <kbd>⌥</kbd> + <kbd>W</kbd> | Focuses the Gantt content element. |

### Expand/Collapse

| Windows | Mac | Action |
|---------|-----|--------|
| <kbd>Ctrl</kbd> + <kbd>↓</kbd> | <kbd>⌘</kbd> + <kbd>↓</kbd> | Expands all tasks. |
| <kbd>Ctrl</kbd> + <kbd>↑</kbd> | <kbd>⌘</kbd> + <kbd>↑</kbd> | Collapses all tasks. |
| <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>↑</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>↑</kbd> | Collapses the selected row. |
| <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>↓</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>↓</kbd> | Expands the selected row. |

### Selection

| Windows | Mac | Action |
|---------|-----|--------|
| <kbd>↑</kbd> | <kbd>↑</kbd> | Selects the row or cell above the current selection. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Selects the row or cell below the current selection. |
| <kbd>→</kbd> | <kbd>→</kbd> | Selects the cell to the right of the current selection. |
| <kbd>←</kbd> | <kbd>←</kbd> | Selects the cell to the left of the current selection. |
| <kbd>Shift</kbd> + <kbd>↑</kbd> | <kbd>⇧</kbd> + <kbd>↑</kbd> | Extends selection upward. |
| <kbd>Shift</kbd> + <kbd>↓</kbd> | <kbd>⇧</kbd> + <kbd>↓</kbd> | Extends selection downward. |
| <kbd>Shift</kbd> + <kbd>→</kbd> | <kbd>⇧</kbd> + <kbd>→</kbd> | Extends cell selection to the right. |
| <kbd>Shift</kbd> + <kbd>←</kbd> | <kbd>⇧</kbd> + <kbd>←</kbd> | Extends cell selection to the left. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Selects the row or cell below the current selection. |
| <kbd>Shift</kbd> + <kbd>Enter</kbd> | <kbd>⇧</kbd> + <kbd>Enter</kbd> | Selects the row or cell above the current selection. |
| <kbd>Esc</kbd> | <kbd>Esc</kbd> | Clears all selections. |
| <kbd>Ctrl</kbd> + <kbd>A</kbd> | <kbd>⌘</kbd> + <kbd>A</kbd> | Selects all rows or cells on the current page. |

### Clipboard

| Windows | Mac | Action |
|---------|-----|--------|
| <kbd>Ctrl</kbd> + <kbd>C</kbd> | <kbd>⌘</kbd> + <kbd>C</kbd> | Copies selected rows or cells to the clipboard. |
| <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>H</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>H</kbd> | Copies selected rows or cells with headers to the clipboard. |

### Context menu

| Windows | Mac | Action |
|---------|-----|--------|
| <kbd>Esc</kbd> | <kbd>Esc</kbd> | Closes the context menu. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Selects the focused menu item. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Navigates to the previous menu item. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Navigates to the next menu item. |
| <kbd>←</kbd> | <kbd>←</kbd> | Closes the current submenu and navigates to the parent menu. |
| <kbd>→</kbd> | <kbd>→</kbd> | Opens the next submenu. |

### Cell editing

| Windows | Mac | Action |
|---------|-----|--------|
| <kbd>F2</kbd> | <kbd>F2</kbd> | Initiates editing of the selected row or cell. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Saves the current cell. |
| <kbd>Insert</kbd> | <kbd>⌘</kbd> + <kbd>Enter</kbd> | Opens a form to add a new row. |
| <kbd>Delete</kbd> | <kbd>Delete</kbd> | Deletes the selected record. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Saves the current cell and moves to the next editable cell. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Saves the current cell and moves to the previous editable cell. |
| <kbd>Shift</kbd> + <kbd>Enter</kbd> | <kbd>⇧</kbd> + <kbd>Enter</kbd> | Saves the current cell and edits the cell in the previous row. |

### Filtering

| Windows | Mac | Action |
|---------|-----|--------|
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | Opens the filter menu for the focused header. |

### Column Menu

| Windows | Mac | Action |
|---------|-----|--------|
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | Opens the column menu for the focused header. |

### Reordering

| Windows | Mac | Action |
|---------|-----|--------|
| <kbd>Ctrl</kbd> + <kbd>←</kbd> / <kbd>→</kbd> | <kbd>⌘</kbd> + <kbd>←</kbd> / <kbd>→</kbd> | Moves the focused column to the left or right. |

### Sorting

| Windows | Mac | Action |
|---------|-----|--------|
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Sorts the focused column (ascending or descending). |
| <kbd>Ctrl</kbd> + <kbd>Enter</kbd> | <kbd>⌘</kbd> + <kbd>Enter</kbd> | Applies multi-column sorting. |
| <kbd>Shift</kbd> + <kbd>Enter</kbd> | <kbd>⇧</kbd> + <kbd>Enter</kbd> | Clears sorting for the focused column. |

### Toolbar

| Windows | Mac | Action |
|---------|-----|--------|
| <kbd>←</kbd> | <kbd>←</kbd> | Focuses the previous toolbar element. |
| <kbd>→</kbd> | <kbd>→</kbd> | Focuses the next toolbar element. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Activates the focused toolbar element. |

### Tooltip

| Windows | Mac | Action |
|---------|-----|--------|
| <kbd>Esc</kbd> | <kbd>Esc</kbd> | Closes the tooltip. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Opens the tooltip on focus and closes it on focus out. |

### Dialog editing

| Windows | Mac | Action |
|---------|-----|--------|
| <kbd>Ctrl</kbd> + <kbd>Insert</kbd> | <kbd>⌘</kbd> + <kbd>Insert</kbd> | Opens the add row dialog. |
| <kbd>Ctrl</kbd> + <kbd>F2</kbd> | <kbd>⌘</kbd> + <kbd>F2</kbd> | Opens the edit row dialog. |
| <kbd>Del</kbd> | <kbd>Del</kbd> | Deletes the selected record. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Saves the current row. |
| <kbd>Esc</kbd> | <kbd>Esc</kbd> | Closes the dialog. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Saves the current cell and moves to the next editable cell in the dialog. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Saves the current cell and moves to the previous editable cell in the dialog. |

## Validate Accessibility Compliance

Accessibility is validated using [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with Playwright tests to ensure compliance with WCAG 2.2 and other standards. Evaluate the accessibility of the Blazor Gantt Chart component using the [sample](https://blazor.syncfusion.com/accessibility/gantt-chart) in a new window with accessibility tools.

## Related Resources

- [Accessibility in Syncfusion Blazor Components](https://blazor.syncfusion.com/documentation/common/accessibility)
- [Blazor Gantt Chart Feature Tour](https://www.syncfusion.com/blazor-components/blazor-gantt-chart)
- [Blazor Gantt Chart Example](https://blazor.syncfusion.com/demos/gantt-chart/default-functionalities?theme=bootstrap5)