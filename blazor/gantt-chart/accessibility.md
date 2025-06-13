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

<b>Expand/Collapse</b>

| Windows | MAC | Actions |
| ----- | ----- | ----- |
| <kbd>Ctrl</kbd> + <kbd>↓</kbd> | <kbd>⌘</kbd> + <kbd>↓</kbd> | Expands all tasks. |
| <kbd>Ctrl</kbd> + <kbd>↑</kbd> | <kbd>⌘</kbd> + <kbd>↑</kbd> | Collapses all tasks. |
| <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>↑</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>↑</kbd> | Collapse the selected row. |
| <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>↓</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>←</kbd> | Expands the selected row. |

<b>Selection</b>

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

<b>Clipboard</b>

| Windows | MAC | Actions |
| ----- | ----- | ----- |
| <kbd>Ctrl</kbd> + <kbd>C</kbd> | <kbd>⌘</kbd> + <kbd>C</kbd> | Copies selected rows or cells data into the clipboard. |
| <kbd>Ctrl</kbd> + <kbd>Shift</kbd> + <kbd>H</kbd> | <kbd>⌘</kbd> + <kbd>⇧</kbd> + <kbd>H</kbd> | Copies selected rows or cells data with header into clipboard. |
 
<b>Context Menu</b>

| Windows | MAC | Actions |
| ----- | ----- | ----- |
| <kbd>Esc</kbd> | <kbd>Esc</kbd> | Closes the opened sub menu. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Selects the focused item. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Navigates up or to the previous menu item. |
| <kbd>↓</kbd> |  <kbd>↓</kbd> | Navigates down or to the next menu item. |
| <kbd>←</kbd> | <kbd>←</kbd> | Close the current sub menu and navigates to the parent menu. |
| <kbd>→</kbd> | <kbd>→</kbd> | Navigates and open the next sub menu. |

<b>Cell Editing</b>

| Windows | MAC | Actions |
| ----- | ----- | ----- |
| <kbd>F2</kbd> | <kbd>F2</kbd> | Starts editing of selected Row/cell. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Saves current cell. |
| <kbd>Insert</kbd> | <kbd>⌘</kbd> + <kbd>Enter</kbd> | Creates a new add form based on the new row position. |
| <kbd>Delete</kbd> | <kbd>Delete</kbd> | Deletes the current selected record. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Navigates to the next editable cell, saves the current cell, and starts editing the next cell. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Navigates to the previous editable cell, saves the current cell, and starts editing the previous cell. |
| <kbd>Shift</kbd> + <kbd>Enter</kbd> | <kbd>⇧</kbd> + <kbd>Enter</kbd> | Saves the current cell and starts editing the previous row cell. |

<b>Filtering</b>

| Windows | MAC | Actions |
| ----- | ----- | ----- |
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | Opens the filter menu when its header element is in focused state. |

<b>Column Menu</b>

| Windows | MAC | Actions |
| ----- | ----- | ----- |
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | Opens column menu when its header element is in focused state. |

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

<b>Toolbar</b>

| Windows | MAC | Actions |
| ----- | ----- | ----- |
| <kbd>←</kbd> | <kbd>←</kbd> | Focuses the previous element. |
| <kbd>→</kbd> | <kbd>→</kbd> | Focuses the next element. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Performs the focused toolbar element action. |

<b>Tooltip</b>

| Windows | MAC | Actions |
| ----- | ----- | ----- |
| <kbd>Escape</kbd> | <kbd>Escape</kbd> | Closes or dismisses the tooltip. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | A form control receiving focus (say through tab key), opens the tooltip, and on focus out closes it. |

<b>Dialog Editing</b>

| Windows | MAC | Actions |
| ----- | ----- | ----- |
| <kbd>Ctrl</kbd> + <kbd>Insert</kbd> | <kbd>⌘</kbd> + <kbd>Insert</kbd> | Opens the add row dialog popup. |
| <kbd>Ctrl</kbd> + <kbd>F2</kbd> | <kbd>⌘</kbd> + <kbd>F2</kbd> | Opens the edit row dialog popup. |
| <kbd>Del</kbd> | <kbd>Del</kbd> | Deletes the currently selected record. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Saves the current row. |
| <kbd>Esc</kbd> | <kbd>Esc</kbd> | Closes the dialog. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Navigates to the next editable cell, saves the current cell, and starts editing the next cell in the dialog elements. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Navigates to the previous editable cell, saves the current cell, and starts editing the previous cell in the dialog elements. |


## Ensuring accessibility

The Blazor Gantt component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with playwright tests.

The accessibility compliance of the Blazor Gantt component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/gantt-chart) in a new window to evaluate the accessibility of the Blazor Gantt component with accessibility tools.

N> You can refer to our [Blazor Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Gantt Chart example](https://blazor.syncfusion.com/demos/gantt-chart/default-functionalities?theme=bootstrap5) to know how to render and configure the Gantt.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)