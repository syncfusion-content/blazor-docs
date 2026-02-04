---
layout: post
title: Accessibility in Blazor Pivot Table Component | Syncfusion
description: Checkout and learn here all about accessibility in Syncfusion Blazor Pivot Table component and more.
platform: Blazor
control: Pivot Table
documentation: ug
---

# Accessibility in Blazor Pivot Table component

The pivot table component followed the accessibility guidelines and standards, including [ADA](https://www.ada.gov/), [Section 508](https://www.section508.gov/), [WCAG 2.2](https://www.w3.org/TR/WCAG22/) standards, and [WCAG roles](https://www.w3.org/TR/wai-aria/#roles) that are commonly used to evaluate accessibility.

The accessibility compliance for the pivot table component is outlined below.

| Accessibility Criteria | Compatibility |
| -- | -- |
| [WCAG 2.2 Support](../common/accessibility#accessibility-standards) | AA |
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

The pivot table component followed the [WAI-ARIA](https://www.w3.org/WAI/ARIA/apg/patterns/table/) patterns to meet the accessibility. The following ARIA attributes are used in the pivot table component:

| Attributes | Purpose |
| --- | --- |
| `role=grid` | Attribute added to identify the grid component element within the pivot table element. |
| `role=region` | Attribute added to identify the chart component element within the pivot table element. |
| `role=button` | This attribute is added to the pager navigation buttons as well as the buttons in the dialog popup such as field list, calculated field, member editor, conditional formatting of pivot table component to indicate that it is a clickable element. |
| `role=table` | This attribute is added to each conditional formatting style container element to denote it as a table. |
| `role=tableItems` | This attribute is added to the container element that appears inside the number formatting popup to indicate it as a table. |
| `aria-disabled` | The buttons within the dialog popups, such as field list, calculated field and member editor, will be disabled based on their usability. To indicate its disabled state, we will add this attribute with the values `true`. By default, the attribute value is set to `false`. |
| `aria-label` | This attribute is added to label elements that are placed inside the pager, member editor popup, and calculated field popup to identify them as label elements. |
| `aria-selected` | This attribute is added to the selected treeview item in the calculated field popup with the value as `true` to denote that it is a selected element. |
| `aria-colspan` | This attribute is added to the `th` elements in the `e-table`, which represent the column span value. |
| `aria-rowspan` | This attribute is added to the `th` elements in the `e-table`, which represent the row span value. |
| `data-type` | This attribute is added to the treeview item in the calculated field popup, as well as the buttons in the grouping bar and field list. It represents the aggregate type for the specified field. |
| `data-caption` | This attribute is added to the treeview item in the calculated field popup, as well as the buttons in the grouping bar and field list. It represents the caption for the specified field. |
| `data-basefield` | This attribute is added to the treeview item in the calculated field popup, as well as the buttons in the grouping bar and field list. It denotes the base field for the specified field, which is used to display the values for aggregation types such as **DifferenceFrom**, **PercentageOfDifferenceFrom**, and **PercentageOfParentTotal**. |
| `data-baseitem` | This attribute is added to the treeview item in the calculated field popup, as well as the buttons in the grouping bar and field list. It denotes the base item for the specified field, which is used to display the values for aggregation types such as **DifferenceFrom**, **PercentageOfDifferenceFrom**, and **PercentageOfParentTotal**. |
| `data-field` | This attribute is added to the treeview item in the calculated field popup. It denotes the name of the specified field. |
| `data-membertype` | This attribute is added to the treeview item in the calculated field popup. It denotes the member type of the selected OLAP calculated field. |
| `data-hierarchy` | This attribute is added to the treeview item in the calculated field popup. It denotes the parent hierarchy unique name of the selected OLAP calculated field. |
| `data-formula` | This attribute is added to the treeview item in the calculated field popup. It denotes the formula used for the specified calculated field. |
| `data-formatString` | This attribute is added to the treeview item in the calculated field popup. It denotes the format string used for the specified calculated field. |
| `data-customformatstring` | This attribute is added to the treeview item in the calculated field popup. It denotes the custom format string used for the specified calculated field. |

## Keyboard Navigation

The pivot table component followed the [keyboard interaction](https://www.w3.org/WAI/ARIA/apg/patterns/alert/#keyboardinteraction) guideline, making it easy for people who use assistive technologies (AT) and those who completely rely on keyboard navigation. The following keyboard shortcuts are supported by the pivot table component.

### Pivot Table

| Windows | Mac | Actions |
| ----- | ----- | ----- |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Moves the cell focus right side. If no cells are focused, it moves to the next active element in the browser page. |
| <kbd>Shift + Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Moves the cell focus left side. If no cells are focused, it moves to the previous active element in the browser page. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Moves the cell focus downwards. If the selection is enabled in the pivot table, then it will move downwards to select next row or column or individual cell. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Moves the cell focus upwards. If the selection is enabled in the pivot table, then it will move upwards to select previous row or column or individual cell. |
| <kbd>←</kbd> | <kbd>←</kbd> | Moves the cell focus left side. If the selection is enabled in the pivot table, then it will move left side to select previous row or column or individual cell. |
| <kbd>→</kbd> | <kbd>→</kbd> | Moves the cell focus right side. If the selection is enabled in the pivot table, then it will move right side to select next row or column or individual cell. |
| <kbd>Shift</kbd> + <kbd>↓</kbd> | <kbd>⇧</kbd> + <kbd>↓</kbd> | Extends the cell selection downwards. |
| <kbd>Shift</kbd> + <kbd>↑</kbd> | <kbd>⇧</kbd> + <kbd>↑</kbd> | Extends the cell selection selection upwards. |
| <kbd>Shift</kbd> + <kbd>←</kbd> | <kbd>⇧</kbd> + <kbd>←</kbd> | Extends the cell selection to the left side. |
| <kbd>Shift</kbd> + <kbd>→</kbd> | <kbd>⇧</kbd> + <kbd>→</kbd> | Extends the cell selection to the right side. |
| <kbd>Ctrl</kbd> + <kbd>A</kbd> | <kbd>⌘</kbd> + <kbd>A</kbd> | Selects all cells. |
| <kbd>Esc</kbd> | <kbd>Esc</kbd> | Deselects all cells. If the current active element is a context menu, then the context menu popup will be closed. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | Goes to the first cell in the current row. |
| <kbd>End</kbd> | <kbd>End</kbd> | Goes to the last cell in the current row. |
| <kbd>Ctrl + Home</kbd> | <kbd>⌘</kbd> + <kbd>Home</kbd> | Goes to the first cell in the table. |
| <kbd>Ctrl + End</kbd> | <kbd>⌘</kbd> + <kbd>End</kbd> | Goes to the last cell in the table. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | If the current cell is an expand/collapse cell, it performs expand/collapse operation (drill operation). If the current row/column header is in value sort state, it performs value sorting. If the current cell is in selection state, it moves to the next row, column or individual cell. If drill-through or editing is enabled in the pivot table, the drill-through dialog will be opened based on the selected value cell. If the current active element is a context menu popup, menu selection will be performed. |
| <kbd>Shift</kbd> + <kbd>Enter</kbd> | <kbd>⇧</kbd> + <kbd>Enter</kbd> | If value sorting is enabled in the pivot table and the current cell is a header with respect to its value axis, it performs value sorting to either ascending or descending order. If the current cell is in selection state, it moves to the previous row, column or individual cell. |
| <kbd>Ctrl</kbd> + <kbd>Enter</kbd> | <kbd>⌘</kbd> + <kbd>Enter</kbd> | If hyperlink is enabled in the current cell, it performs hyperlink selection. |
| <kbd>Shift</kbd> + <kbd>F10</kbd> or <kbd>Menu</kbd> | <kbd>⇧</kbd> + <kbd>F10</kbd> | If context menu is enabled in the pivot table, the context menu popup will be opened in the current cell. |

### Field List

| Windows | Mac | Actions |
| ----- | ----- | ---- |
| <kbd>Shift</kbd> + <kbd>Ctrl</kbd> + <kbd>F</kbd> | <kbd>⇧</kbd> + <kbd>⌘</kbd> + <kbd>F</kbd> | If the popup field list is enabled in either the pivot table or the pivot chart, the field list dialog will be opened. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Moves to the next active element in the field list. If no active elements are present, it moves to the next active element in the browser page. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Moves to the previous active element in the field list. If no active elements are present, it moves to the previous active element in the browser page. |
| <kbd>Shift</kbd> + <kbd>F</kbd> | <kbd>⇧</kbd> + <kbd>F</kbd> | If the current active element is a field's button and if it has a filter icon, the filter dialog will open to perform filtering. |
| <kbd>Shift</kbd> + <kbd>S</kbd> | <kbd>⇧</kbd> + <kbd>S</kbd> | If the current active element is a field's button and if it has a sort icon, the sorting will be performed to the selected field. |
| <kbd>Shift</kbd> + <kbd>E</kbd> | <kbd>⇧</kbd> + <kbd>E</kbd> | If the current active element is a calculated field's button and if it has an edit icon, the calculated field dialog will be opened to edit the selected calculated field. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Performs the selection operation of the current active element. If the current active element is a field's button and it has a dropdown icon, the aggregation menu will open to perform calculations using aggregation options to the selected value field. |
| <kbd>Delete</kbd> | <kbd>Delete</kbd> | If the current active element is a field's button, the selected field will be removed from the current report. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | If the current active element is a tree node, it moves to the next node. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | If the current active element is a tree node, it moves to the previous node. |
| <kbd>←</kbd> | <kbd>←</kbd> | If the current active element is a tree node, it collapses the current node. |
| <kbd>→</kbd> | <kbd>→</kbd> | If the current active element is a tree node, it expands the current node. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | If the current active element is a tree node, it goes to the first node. |
| <kbd>End</kbd> | <kbd>End</kbd> | If the current active element is a tree node, it goes to the last node. |
| <kbd>Space</kbd> | <kbd>Space</kbd> | If the current active element is a tree node or a checkbox element, it will be either checked or unchecked. |
| <kbd>Esc</kbd> or <kbd>Escape</kbd> | <kbd>Escape</kbd> | Closes the popup field list dialog. |

### Grouping Bar

| Windows | Mac | Actions |
----- | ----- | --- |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Moves to the next active element (field's button) in the grouping bar. If no active elements are present, it moves to the next active element in the browser page. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Moves to the previous active element (field's button) in the grouping bar. If no active elements are present, it moves to the previous active element in the browser page. |
| <kbd>Shift</kbd> + <kbd>F</kbd> | <kbd>⇧</kbd> + <kbd>F</kbd> | If the current active element is a field's button and if it has a filter icon, the filter dialog will be opened to perform filtering. |
| <kbd>Shift</kbd> + <kbd>S</kbd> | <kbd>⇧</kbd> + <kbd>S</kbd> | If the current active element is a field's button and if it has a sort icon, the sorting will be performed to the selected field. |
| <kbd>Shift</kbd> + <kbd>E</kbd> | <kbd>⇧</kbd> + <kbd>E</kbd> | If the current active element is a calculated field's button and if it has an edit icon, the calculated field dialog will be opened to perform editing the selected calculated field. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Performs the selection operation of the current active element. If the current active element is a field's button and if it has a dropdown icon, the aggregation menu will be opened to perform calculations using aggregation options to the selected value field. |
| <kbd>Delete</kbd> | <kbd>Delete</kbd> | If the current active element is a field's button, the selected field will be removed from the current report. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | If the current active element is a dropdown list, the next item will be selected. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | If the current active element is a dropdown list, the previous item will be selected. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | If the current active element is a dropdown list, the first item will be selected. |
| <kbd>End</kbd> | <kbd>End</kbd> | If the current active element is a dropdown list, the last item will be selected. |
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | If the current active element is a dropdown list, the popup will be opened. |
| <kbd>Alt</kbd> + <kbd>↑</kbd> | <kbd>⌥</kbd> + <kbd>↑</kbd> | If the current active element is a dropdown list, the popup will be closed. |
| <kbd>Esc</kbd> or <kbd>Escape</kbd> | <kbd>Escape</kbd> | Closes the dropdown list. |

### Filter Dialog

| Windows | Mac | Actions |
----- | ----- | ---- |
| <kbd>Shift</kbd> + <kbd>F</kbd> | <kbd>⇧</kbd> + <kbd>F</kbd> | If the current active element is a field's button and if it has a filter icon in either the field list or grouping bar UI, the filter dialog will be opened to perform filtering. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Moves to the next active element in the filter dialog. If no active elements present, it moves to the next active element in the browser page. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Moves to the previous active element in the filter dialog. If no active elements present, it moves to the previous active element in the browser page. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | If the current active element is a tree node, it moves to the next node. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | If the current active element is a tree node, it moves to the previous node. |
| <kbd>←</kbd> | <kbd>←</kbd> | If the current active element is a tree node, it collapses the current node. If the current active element is a tab, it moves focus to the previous tab element. |
| <kbd>→</kbd> | <kbd>→</kbd> | If the current active element is a tree node, it expands the current node. If the current active element is a tab, it moves focus to the next tab element. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | If the current active element is a tree node, it goes to the first node. |
| <kbd>End</kbd> | <kbd>End</kbd> | If the current active element is a tree node, it goes to the last node. |
| <kbd>Space</kbd> | <kbd>Space</kbd> | If the current active element is a tree node or a checkbox element, it will be either checked or unchecked. |
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | If the current active element is a DropDownList or DatePicker or DateTimePicker, the popup will be opened. |
| <kbd>Alt</kbd> + <kbd>↑</kbd> | <kbd>⌥</kbd> + <kbd>↑</kbd> | If the current active element is a DropDownList or DatePicker or DateTimePicker, the popup will be closed. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Performs the selection operation of the current active element. If the current active element is a tab, the current tab element will be selected. If the current active element is a tree node, the current node will be either checked or unchecked. If the current active element is DropDownList, the focus item will be selected, and the popup list will close when it is open. Otherwise, toggles the popup list. |
| <kbd>Esc</kbd> or <kbd>Escape</kbd> | <kbd>Escape</kbd> | Closes the filter dialog. |

### Calculated Field Dialog

| Windows | Mac | Actions |
----- | ----- | --- |
| <kbd>Shift + E</kbd> | <kbd>⇧</kbd> + <kbd>E</kbd> | If the current active element is a field's button and if it has an edit icon in either the field list or grouping bar UI, the calculated field dialog will be opened to perform editing the selected calculated field. |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Moves to the next active element in the calculated field dialog. If no active elements present, it moves to the next active element in the browser page. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Moves to the previous active element in the calculated field dialog. If no active elements present, it moves to the previous active element in the browser page. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | If the current active element is a tree node, it moves to the next node. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | If the current active element is a tree node, it moves to the previous node. |
| <kbd>←</kbd> | <kbd>←</kbd> | If the current active element is a tree node, it collapses the current node. |
| <kbd>→</kbd> | <kbd>→</kbd> | If the current active element is a tree node, it expands the current node. If the current active element is a tree node and has a menu icon, the aggregation menu will be opened to select appropriate aggregation type to the selected field. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | If the current active element is a tree node, it goes to the first node. |
| <kbd>End</kbd> | <kbd>End</kbd> | If the current active element is a tree node, it goes to the last node. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Performs the selection operation of the current active element. If the current active element is a tree node, it copies the selected field name/formula to the formula text area to perform calculations. |
| <kbd>Esc</kbd> or <kbd>Escape</kbd> | <kbd>Escape</kbd> | Closes the calculated field dialog. |

### Formatting Dialog

| Windows | Mac | Actions |
----- | ----- | --- |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Moves to the next active element in the formatting dialog. If no active elements present, it moves to the next active element in the browser page. |
| <kbd>Shift + Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Moves to the previous active element in the formatting dialog. If no active elements present, it moves to the previous active element in the browser page. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | If the current active element is a DropDownList, the next item will be selected. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | If the current active element is a DropDownList, the previous item will be selected. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | If the current active element is a DropDownList, the first item will be selected. |
| <kbd>End</kbd> | <kbd>End</kbd> | If the current active element is a DropDownList, the last item will be selected. |
| <kbd>Alt</kbd> + <kbd>↓</kbd> | <kbd>⌥</kbd> + <kbd>↓</kbd> | If the current active element is a DropDownList or ColorPicker, the popup will be opened. |
| <kbd>Alt</kbd> + <kbd>↑</kbd> | <kbd>⌥</kbd> + <kbd>↑</kbd> | If the current active element is a DropDownList or ColorPicker, the popup will be closed. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Performs the selection operation of the current active element. |
| <kbd>Esc or Escape</kbd> | <kbd>Escape</kbd> | Closes the formatting dialog. |

### Toolbar

| Windows | Mac | Actions |
----- | ----- | --- |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Moves to the next active option in the toolbar. If no active elements present, it moves to the next active element in the browser page. |
| <kbd>Shift + Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Moves to the previous active option in the toolbar. If no active elements present, it moves to the previous active element in the browser page. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Performs the selection operation of the current active element. |

### Drill-Through Dialog

| Windows | Mac | Actions |
----- | ----- | --- |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Moves to the next active element in the drill-through dialog. If the current active element is a Grid cell, it moves the cell focus to right side. If no active elements present, then it moves to the next active element in the browser page. |
| <kbd>Shift</kbd> + <kbd>Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Moves to the previous active element in the drill-through dialog. If the current active element is a Grid cell, it moves the cell focus to left side. If no active elements present, then it moves to the previous active element in the browser page. |
| <kbd>↓</kbd> | <kbd>↓</kbd> | Moves the row/cell focus downwards. |
| <kbd>↑</kbd> | <kbd>↑</kbd> | Moves the row/cell focus upwards. |
| <kbd>←</kbd> | <kbd>←</kbd> | Moves the cell focus left side. |
| <kbd>→</kbd> | <kbd>→</kbd> | Moves the cell focus right side. |
| <kbd>Home</kbd> | <kbd>Home</kbd> | Goes to the first cell in the current row. |
| <kbd>End</kbd> | <kbd>End</kbd>  | Goes to the last cell in the current row. |
| <kbd>Ctrl</kbd> + <kbd>Home</kbd> | <kbd>⌘</kbd> + <kbd>Home</kbd> | Goes to the first cell in the table. |
| <kbd>Ctrl</kbd> + <kbd>End</kbd> | <kbd>⌘</kbd> + <kbd>End</kbd> | Goes to the last cell in the table. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | Performs the selection operation of the current active element. |
| <kbd>Esc</kbd> or <kbd>Escape</kbd> | <kbd>Escape</kbd> | If the cell is in selected state, then it deselects all rows/cells. If the row/cell is in edit state, it cancels the current entries in the row/cell. If the current active element is not a row/cell, it closes the drill-through dialog. |
| <kbd>F2</kbd> | <kbd>F2</kbd> | Initiate editing a row/cell in the data grid. |
| <kbd>Insert</kbd> | <kbd>Insert</kbd> | Adds a new row/cell in the data grid. |
| <kbd>Delete</kbd> | <kbd>Delete</kbd> | Removes the selected row in the data grid. |

Some commonly used applicable key combinations and their relative functionalities in all dialogs are listed below.

| Windows | Mac | Actions |
| ----- | ----- | --- |
| <kbd>Tab</kbd> | <kbd>Tab</kbd> | Moves to the next active element in the dialog. If either no active elements present in the dialog or an overlay is not present in the dialog, it moves to the next active element in the browser page. |
| <kbd>Shift + Tab</kbd> | <kbd>⇧</kbd> + <kbd>Tab</kbd> | Moves to the previous active element in the dialog. If either no active elements present in the dialog or an overlay is not present in the dialog, it moves to the previous active element in the browser page. |
| <kbd>Space</kbd> | <kbd>Space</kbd> | If the current active element is a tree node or a checkbox element, it will be either checked or unchecked. |
| <kbd>Enter</kbd> | <kbd>Enter</kbd> | When the Dialog button or any input (except text area) is in focus state, when pressing the <kbd>Enter</kbd> key, the click event associated with the primary button or button will be triggered. The <kbd>Enter</kbd> key will not be worked, when the dialog content contains any text area with initial focus. |
| <kbd>Esc</kbd> or <kbd>Escape</kbd> | <kbd>Escape</kbd> | Closes the dialog. |

## Ensuring accessibility

The pivot table component's accessibility levels are ensured through an [axe-core](https://www.nuget.org/packages/Deque.AxeCore.Playwright) with playwright tests.

The accessibility compliance of the pivot table component is shown in the following sample. Open the [sample](https://blazor.syncfusion.com/accessibility/pivot-table) in a new window to evaluate the accessibility of the pivot table component with accessibility tools.

## See also

* [Accessibility in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor components](https://blazor.syncfusion.com/documentation/common/accessibility)
