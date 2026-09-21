---
layout: post
title: API consistency in Blazor components | Syncfusion®
description: Learn the common API names shared across Syncfusion Blazor components, including appearance, value, data binding, event, and method APIs to help you move between components easily.
platform: Blazor
control: Common
documentation: ug
---

# Syncfusion Blazor Component API Consistency

This document lists common API names that appear across multiple Syncfusion Blazor components. It helps new users recognize familiar property and event patterns when moving between components, so knowledge from one component can be applied to another. Each table groups shared APIs and explains what each API does before you review the individual component documentation.

## 1) Common appearance and layout APIs

These APIs are commonly used to control size, styling, and layout behavior.

| API name | Purpose | Components that commonly use it |
| --- | --- | --- |
| `CssClass` | Adds one or more custom CSS classes to the component's root element for styling. | Accordion, Button, Card, AppBar, Scheduler, Toolbar, Sidebar, Context Menu, Dropdown Tree, Chat UI, AI AssistView |
| `Width` | Sets the component width as pixels or a percentage. | Charts, DataGrid, Gantt Chart, Diagram, Sidebar, Kanban, Stock Chart, Pivot Table, Splitter |
| `Height` | Sets the component height as pixels or a percentage. | Charts, DataGrid, Gantt Chart, Diagram, Sidebar, Kanban, Stock Chart, Pivot Table, Splitter, Tree Grid |
| `Visible` | Shows or hides the component without destroying its state. | Sidebar, Toolbar, Card, Kanban, Scheduler, Progress Bar, Chips, Floating Action Button, Speed Dial, Rating, chart legends, data labels, and column/item models |
| `Enabled` | Enables or disables user interaction with the component. | Button, Chips, Calendar, DatePicker, TimePicker, DateTime Picker, DateRangePicker, Dropdown List, MultiSelect Dropdown, AutoComplete, ListBox, ListView, Range Selector (period selector), Rich Text Editor, Splitter, TextBox, File Upload, Dashboard (panel) |
| `Theme` | Applies a built-in theme such as Material, Bootstrap5, Fluent, Tailwind, or HighContrast. | Charts, Accumulation Chart, Bullet Chart, Sparkline Charts, TreeMap, Map, Image Editor, Linear Gauge, Circular Gauge, Chart Wizard, Stock Chart, 3D Charts |
| `EnableRtl` | Enables right-to-left rendering to support Arabic, Hebrew, and other RTL languages. | Charts, Accumulation Chart, 3D Charts, Bullet Chart, Sparkline Charts, TreeMap, Map, Scheduler, Kanban, DataGrid, Gantt Chart, Tree Grid, Pivot Table, ListView, Menu Bar, Toolbar, Sidebar, Splitter, Dashboard, Rich Text Editor, Dialog, Progress Bar, Query Builder, Range Selector, Toast, AI AssistView, Chat UI, Block Editor, Sankey Diagram, Calendar, DatePicker, TimePicker, DateTime Picker, DateRangePicker, AutoComplete, ComboBox, Dropdown List, MultiSelect Dropdown, Image Editor, Data Form |

## 2) Common value and selection APIs

These APIs are widely used in input-style controls and interactive widgets.

| API name | Purpose | Components that commonly use it |
| --- | --- | --- |
| `Value` | Gets or sets the current value and supports two-way binding through `@bind-Value`. | TextBox, Numeric Textbox, DatePicker, ComboBox, Dropdown List, AutoComplete, MultiSelect Dropdown, Range Slider, Rating, Rich Text Editor |
| `Placeholder` | Shows hint text inside an input when no value is entered. | TextBox, ComboBox, Dropdown List, AutoComplete, MultiSelect Dropdown, DatePicker, TimePicker, DateTime Picker, DateRangePicker, MultiColumn ComboBox, Numeric Textbox, Input Mask, TextArea |
| `AllowMultiSelection` | Enables selecting multiple items or nodes at once. | File Manager, TreeView, Dropdown Tree |
| `AllowSelection` | Enables or disables item, row, or data-point selection. | DataGrid, Tree Grid, Gantt Chart, Charts, Accumulation Chart, 3D Charts, HeatMap Chart |
| `AllowFiltering` | Enables the built-in filter UI, such as a filter bar or search box, to narrow down data. | DataGrid, Tree Grid, Gantt Chart, AutoComplete, ComboBox, Dropdown List, MultiSelect Dropdown, ListBox, MultiColumn ComboBox |
| `ShowCheckBox` | Displays checkboxes in front of items or nodes for multi-item selection. | TreeView, ListView, Tree Grid (column), ListBox (selection settings), Dropdown Tree |
| `AllowResizing` | Enables resizing of columns, panels, dialogs, or appointments by dragging. | DataGrid, Tree Grid, Gantt Chart, Dashboard, Dialog, Scheduler (appointment resizing), File Manager (details view) |
| `AllowDragAndDrop` | Enables dragging items, cards, nodes, or appointments between locations. | TreeView, Kanban, Scheduler, File Manager, Query Builder, Pivot Table |

## 3) Common data and binding APIs

These APIs help components connect to local collections or remote data sources.

| API name | Purpose | Components that commonly use it |
| --- | --- | --- |
| `DataSource` | Binds the component to an `IEnumerable` collection or a `SfDataManager` for remote data. | Charts, Accumulation Chart, DataGrid, Tree Grid, Gantt Chart, Scheduler, Kanban, ListView, TreeView, Menu Bar, Breadcrumb, Map, Stepper, File Manager, 3D Charts |
| `Query` | Passes extra query options, such as filtering or sorting, to `DataManager`-based sources. | Charts, Accumulation Chart, DataGrid, Tree Grid, Gantt Chart, Kanban, Scheduler, ListView, Range Selector, File Manager, Pivot Table |
| `Fields` | Configures data field mappings such as ID, text, parent ID, and child fields. | ListView, TreeView, Menu Bar, Breadcrumb, Accordion, AutoComplete, ComboBox, Dropdown List |

## 4) Common interaction and event APIs

These APIs are useful for tracking user actions and component state changes.

| API name | Purpose | Components that commonly use it |
| --- | --- | --- |
| `Created` | Fires once after the component is fully created and ready for interaction. | DataGrid, Charts, Scheduler, Sidebar, Toolbar, Accordion, Kanban, Tree Grid, Rich Text Editor, Image Editor |
| `Destroyed` | Fires when the component is about to be removed from the DOM. | Charts, Accumulation Chart, Sidebar, Toolbar, Kanban, Tree Grid, Diagram, Rich Text Editor |
| `ValueChange` | Fires when the component value changes due to user interaction or programmatic updates. | TextBox, Numeric Textbox, DatePicker, TimePicker, DateTime Picker, DateRangePicker, ComboBox, Dropdown List, AutoComplete, MultiSelect Dropdown, Range Slider, Rating, Radio Button, Toggle Switch Button, Calendar |
| `OnDataBound` | Fires when data is bound and ready for rendering or adjustments. | DataGrid, Tree Grid, Gantt Chart, ListView, Scheduler, Kanban, Dropdown List, Stepper |
| `Opened` | Fires when a popup or dropdown interface is opened. | Dropdown List, ComboBox, AutoComplete, MultiSelect Dropdown, DatePicker, TimePicker, DateTime Picker, DateRangePicker, Dialog, Sidebar, Menu Bar |
| `Closed` | Fires when a popup or overlay is closed. | Dropdown List, ComboBox, AutoComplete, MultiSelect Dropdown, DatePicker, TimePicker, DateTime Picker, Dialog, Sidebar, Menu Bar |
| `RowSelected` / `RowSelecting` | Fires after or before a grid row is selected. | DataGrid, Tree Grid, Gantt Chart |

## 5) Common configuration APIs for component behavior

These APIs often control runtime behavior and user experience.

| API name | Purpose | Components that commonly use it |
| --- | --- | --- |
| `Readonly` | Makes the component display-only and prevents users from changing the value. | TextBox, Numeric Textbox, DatePicker, ComboBox, Dropdown List, AutoComplete, MultiSelect Dropdown, Range Slider, Rating, Block Editor, Rich Text Editor |
| `Disabled` | Disables the component or an individual item so it ignores user interaction. | Button, Button Group, Checkbox, Radio Button, Toggle Switch Button, Floating Action Button, Speed Dial, Progress Button, Split Button, Dropdown Menu item, Accordion item, ListView items |
| `ShowClearButton` | Renders a clear button to reset the component value with one click. | TextBox, Dropdown List, ComboBox, AutoComplete, DatePicker, TimePicker, DateTime Picker, DateRangePicker, MultiSelect Dropdown, Numeric Textbox, Input Mask |
| `AllowEditing` | Enables editing of records, cells, or annotations. | DataGrid (`GridEditSettings`), Tree Grid, Gantt Chart (`GanttEditSettings`), Kanban, Scheduler, File Manager |
| `AllowSorting` | Enables sorting records by clicking column headers. | DataGrid, Tree Grid, Gantt Chart |
| `AllowGrouping` | Enables drag-and-drop grouping of records by column. | DataGrid, Tree Grid, Gantt Chart |
| `AllowPaging` | Splits large datasets into pages. | DataGrid, Tree Grid, Gantt Chart, File Manager, 3D Charts (legend paging) |
| `AllowTextWrap` | Wraps long cell, header, or node text into multiple lines. | DataGrid, Tree Grid, TreeView |
| `AllowReordering` | Enables dragging column headers to change their order. | DataGrid, Tree Grid, Gantt Chart |
| `ShowColumnMenu` | Shows a menu on column headers with options such as sort, filter, and autofit. | DataGrid, Tree Grid, Gantt Chart |
| `EnableContextMenu` | Shows a right-click context menu. | DataGrid, Tree Grid, Gantt Chart |
| `EnablePersistence` | Saves component state to browser `localStorage` so it survives page reloads. | DataGrid, Tree Grid, Gantt Chart, Scheduler, Kanban, ListView, Map, Sidebar, Splitter, Dashboard, Pivot Table, Dialog, Rich Text Editor, Radio Button, Toggle Switch Button, Calendar, DatePicker, TimePicker, Color Picker, Signature |
| `EnableVirtualization` | Renders only visible rows or items for smooth scrolling through large datasets. | DataGrid, Tree Grid, Gantt Chart, ListView, TreeView, Dropdown Tree, File Manager |
| `ShowTooltip` | Shows a tooltip on hover to display additional information. | DataGrid, Gantt Chart (timeline cells), Scheduler (events), Pivot Table, Rating, Stepper, Speech To Text, Rich Text Editor, Smart Rich Text Editor |
| `EnableHover` | Highlights the row or item under the mouse cursor. | DataGrid, Tree Grid |
| `EnableHtmlSanitizer` | Sanitizes HTML content to prevent cross-site scripting attacks. | Rich Text Editor, Smart Rich Text Editor, Gantt Chart |
| `AllowRowDragAndDrop` | Enables dragging and dropping rows to reorder or move them. | DataGrid, Tree Grid, Gantt Chart |
| `Tooltip` | Configures tooltip content and appearance for chart elements. | Charts, Accumulation Chart, 3D Charts, Sparkline Charts, Stock Chart |

## 6) Common method APIs (shared method names)

These methods often share the same name across components, mostly exposed as `Async` methods in Blazor.

| API name | Purpose | Components that commonly use it |
| --- | --- | --- |
| `RefreshAsync` | Re-renders the component after external state or data changes. | Charts, DataGrid, Circular Gauge, Linear Gauge, Dashboard, Image Editor, Kanban, Pivot Table, Toolbar, ListView, Accordion |
| `FocusAsync` | Sets keyboard focus to the component. | TextBox, Numeric Textbox, DatePicker, ComboBox, Dropdown List, AutoComplete, MultiSelect Dropdown, Button, Checkbox, Chips, Floating Action Button, Chat UI, Accumulation Chart, Toolbar, Rich Text Editor |
| `PrintAsync` | Triggers the browser print dialog with the component content. | Charts, Accumulation Chart, 3D Charts, Bullet Chart, Circular Gauge, Linear Gauge, DataGrid, Tree Grid, Gantt Chart, Scheduler, Map, Pivot Table, Diagram, Stock Chart, TreeMap, Block Editor |
| `ExportAsync` | Exports the component to an image, PDF, or other file format. | Charts, Accumulation Chart, 3D Charts, Circular Gauge, Linear Gauge, Sankey Diagram, HeatMap Chart, DataGrid, Tree Grid, Gantt Chart, Scheduler, Pivot Table, Stock Chart, Image Editor, Diagram, Block Editor |
| `SelectRowsAsync` | Selects specific grid rows programmatically. | DataGrid, Tree Grid, Gantt Chart |
| `ClearSelectionAsync` | Clears the current selection. | DataGrid, Tree Grid, Gantt Chart, HeatMap Chart, ListView, TreeView |
| `ExpandAllAsync` / `CollapseAllAsync` | Expands or collapses all groups, rows, or nodes. | TreeView, Tree Grid, Gantt Chart |
| `HideAsync` / `ShowAsync` | Programmatically hides or shows a component. | Dialog, Toast, Sidebar, Speed Dial, Message |
| `OpenAsync` / `CloseAsync` | Programmatically opens or closes a popup-style component or loads an image. | Dialog, Tooltip, Sidebar, Image Editor (`OpenAsync` loads an image) |
| `GetPersistDataAsync` | Gets the current state as a JSON string for manual persistence management. | DataGrid, Tree Grid, Gantt Chart, Pivot Table, Dashboard |

## Notes for new users

- Many Syncfusion Blazor components use the same property names, even when the underlying behavior is slightly different.
- The `Allow*` prefix usually turns a feature on, `Enable*` usually controls runtime behavior, and `Show*` usually makes a UI element visible. Learning these patterns makes many APIs easier to understand.
- Data-oriented controls often share `DataSource`, `Query`, and `Fields`.
- Interaction-heavy components usually expose familiar event names such as `Created`, `Destroyed`, and `ValueChange`.
- Grid family components such as DataGrid, Tree Grid, and Gantt Chart often share the same API names for sorting, filtering, grouping, resizing, and paging.
- When in doubt, check the component-specific API reference to confirm whether a property behaves the same way across components.
