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
| `CssClass` | Adds one or more custom CSS classes to the component's root element for styling. | Accordion, Button, Card, AppBar, Scheduler, Toolbar, Sidebar, ContextMenu, DropDownTree, Chat UI, AI AssistView |
| `Width` | Sets the component width as pixels or a percentage. | Chart, DataGrid, Gantt Chart, Diagram, Sidebar, Kanban, Stock Chart, Pivot Table, Splitter |
| `Height` | Sets the component height as pixels or a percentage. | Chart, DataGrid, Gantt Chart, Diagram, Sidebar, Kanban, Stock Chart, Pivot Table, Splitter, TreeGrid |
| `Visible` | Shows or hides the component without destroying its state. | Sidebar, Toolbar, Card, Kanban, Scheduler, Progress Bar, Chip, FloatingActionButton, SpeedDial, Rating, chart legends, data labels, and column/item models |
| `Enabled` | Enables or disables user interaction with the component. | Button, Chip, Calendar, DatePicker, TimePicker, DateTimePicker, DateRangePicker, DropDownList, MultiSelect, AutoComplete, ListBox, ListView, RangeNavigator (period selector), Rich Text Editor, Splitter, TextBox, FileUpload, Dashboard Layout (panel) |
| `Theme` | Applies a built-in theme such as Material, Bootstrap5, Fluent, Tailwind, or HighContrast. | Chart, Accumulation Chart, Bullet Chart, Sparkline, TreeMap, Maps, Image Editor, Linear Gauge, Circular Gauge, Chart Wizard, Stock Chart, 3D Chart |
| `EnableRtl` | Enables right-to-left rendering to support Arabic, Hebrew, and other RTL languages. | Chart, Accumulation Chart, 3D Chart, Bullet Chart, Sparkline, TreeMap, Maps, Scheduler, Kanban, DataGrid, Gantt Chart, TreeGrid, Pivot Table, ListView, Menu Bar, Toolbar, Sidebar, Splitter, Dashboard Layout, Rich Text Editor, Dialog, Progress Bar, Query Builder, Range Navigator, Toast, AI AssistView, Chat UI, Block Editor, Sankey, Calendar, DatePicker, TimePicker, DateTimePicker, DateRangePicker, AutoComplete, ComboBox, DropDownList, MultiSelect, Image Editor, Data Form |

## 2) Common value and selection APIs

These APIs are widely used in input-style controls and interactive widgets.

| API name | Purpose | Components that commonly use it |
| --- | --- | --- |
| `Value` | Gets or sets the current value and supports two-way binding through `@bind-Value`. | TextBox, NumericTextBox, DatePicker, ComboBox, DropDownList, AutoComplete, MultiSelect, RangeSlider, Rating, Rich Text Editor |
| `Placeholder` | Shows hint text inside an input when no value is entered. | TextBox, ComboBox, DropDownList, AutoComplete, MultiSelect, DatePicker, TimePicker, DateTimePicker, DateRangePicker, MultiColumn ComboBox, NumericTextBox, InputMask, TextArea |
| `AllowMultiSelection` | Enables selecting multiple items or nodes at once. | File Manager, TreeView, DropDownTree |
| `AllowSelection` | Enables or disables item, row, or data-point selection. | DataGrid, TreeGrid, Gantt Chart, Chart, Accumulation Chart, 3D Chart, HeatMap |
| `AllowFiltering` | Enables the built-in filter UI, such as a filter bar or search box, to narrow down data. | DataGrid, TreeGrid, Gantt Chart, AutoComplete, ComboBox, DropDownList, MultiSelect, ListBox, MultiColumn ComboBox |
| `ShowCheckBox` | Displays checkboxes in front of items or nodes for multi-item selection. | TreeView, ListView, TreeGrid (column), ListBox (selection settings), DropDownTree |
| `AllowResizing` | Enables resizing of columns, panels, dialogs, or appointments by dragging. | DataGrid, TreeGrid, Gantt Chart, Dashboard Layout, Dialog, Scheduler (appointment resizing), File Manager (details view) |
| `AllowDragAndDrop` | Enables dragging items, cards, nodes, or appointments between locations. | TreeView, Kanban, Scheduler, File Manager, Query Builder, Pivot Table |

## 3) Common data and binding APIs

These APIs help components connect to local collections or remote data sources.

| API name | Purpose | Components that commonly use it |
| --- | --- | --- |
| `DataSource` | Binds the component to an `IEnumerable` collection or a `SfDataManager` for remote data. | Chart, Accumulation Chart, DataGrid, TreeGrid, Gantt Chart, Scheduler, Kanban, ListView, TreeView, Menu Bar, Breadcrumb, Maps, Stepper, File Manager, 3D Chart |
| `Query` | Passes extra query options, such as filtering or sorting, to `DataManager`-based sources. | Chart, Accumulation Chart, DataGrid, TreeGrid, Gantt Chart, Kanban, Scheduler, ListView, Range Navigator, File Manager, Pivot Table |
| `Fields` | Configures data field mappings such as ID, text, parent ID, and child fields. | ListView, TreeView, Menu Bar, Breadcrumb, Accordion, AutoComplete, ComboBox, DropDownList |

## 4) Common interaction and event APIs

These APIs are useful for tracking user actions and component state changes.

| API name | Purpose | Components that commonly use it |
| --- | --- | --- |
| `Created` | Fires once after the component is fully created and ready for interaction. | DataGrid, Chart, Scheduler, Sidebar, Toolbar, Accordion, Kanban, TreeGrid, Rich Text Editor, Image Editor |
| `Destroyed` | Fires when the component is about to be removed from the DOM. | Chart, Accumulation Chart, Sidebar, Toolbar, Kanban, TreeGrid, Diagram, Rich Text Editor |
| `ValueChange` | Fires when the component value changes due to user interaction or programmatic updates. | TextBox, NumericTextBox, DatePicker, TimePicker, DateTimePicker, DateRangePicker, ComboBox, DropDownList, AutoComplete, MultiSelect, RangeSlider, Rating, Radio Button, Toggle Switch, Calendar |
| `OnDataBound` | Fires when data is bound and ready for rendering or adjustments. | DataGrid, TreeGrid, Gantt Chart, ListView, Scheduler, Kanban, DropDownList, Stepper |
| `Opened` | Fires when a popup or dropdown interface is opened. | DropDownList, ComboBox, AutoComplete, MultiSelect, DatePicker, TimePicker, DateTimePicker, DateRangePicker, Dialog, Sidebar, Menu Bar |
| `Closed` | Fires when a popup or overlay is closed. | DropDownList, ComboBox, AutoComplete, MultiSelect, DatePicker, TimePicker, DateTimePicker, Dialog, Sidebar, Menu Bar |
| `RowSelected` / `RowSelecting` | Fires after or before a grid row is selected. | DataGrid, TreeGrid, Gantt Chart |

## 5) Common configuration APIs for component behavior

These APIs often control runtime behavior and user experience.

| API name | Purpose | Components that commonly use it |
| --- | --- | --- |
| `Readonly` | Makes the component display-only and prevents users from changing the value. | TextBox, NumericTextBox, DatePicker, ComboBox, DropDownList, AutoComplete, MultiSelect, RangeSlider, Rating, Block Editor, Rich Text Editor |
| `Disabled` | Disables the component or an individual item so it ignores user interaction. | Button, ButtonGroup, CheckBox, Radio Button, Toggle Switch, FloatingActionButton, Speed Dial, Progress Button, Split Button, DropDownMenuItem, Accordion Item, ListView items |
| `ShowClearButton` | Renders a clear button to reset the component value with one click. | TextBox, DropDownList, ComboBox, AutoComplete, DatePicker, TimePicker, DateTimePicker, DateRangePicker, MultiSelect, NumericTextBox, InputMask |
| `AllowEditing` | Enables editing of records, cells, or annotations. | DataGrid (`GridEditSettings`), TreeGrid, Gantt Chart (`GanttEditSettings`), Kanban, Scheduler, File Manager |
| `AllowSorting` | Enables sorting records by clicking column headers. | DataGrid, TreeGrid, Gantt Chart |
| `AllowGrouping` | Enables drag-and-drop grouping of records by column. | DataGrid, TreeGrid, Gantt Chart |
| `AllowPaging` | Splits large datasets into pages. | DataGrid, TreeGrid, Gantt Chart, File Manager, 3D Chart (legend paging) |
| `AllowTextWrap` | Wraps long cell, header, or node text into multiple lines. | DataGrid, TreeGrid, TreeView |
| `AllowReordering` | Enables dragging column headers to change their order. | DataGrid, TreeGrid, Gantt Chart |
| `ShowColumnMenu` | Shows a menu on column headers with options such as sort, filter, and autofit. | DataGrid, TreeGrid, Gantt Chart |
| `EnableContextMenu` | Shows a right-click context menu. | DataGrid, TreeGrid, Gantt Chart |
| `EnablePersistence` | Saves component state to browser `localStorage` so it survives page reloads. | DataGrid, TreeGrid, Gantt Chart, Scheduler, Kanban, ListView, Maps, Sidebar, Splitter, Dashboard Layout, Pivot Table, Dialog, Rich Text Editor, Radio Button, Toggle Switch, Calendar, DatePicker, TimePicker, ColorPicker, Signature |
| `EnableVirtualization` | Renders only visible rows or items for smooth scrolling through large datasets. | DataGrid, TreeGrid, Gantt Chart, ListView, TreeView, DropDownTree, File Manager |
| `ShowTooltip` | Shows a tooltip on hover to display additional information. | DataGrid, Gantt Chart (timeline cells), Scheduler (events), Pivot Table, Rating, Stepper, Speech-to-Text, Rich Text Editor, Smart Rich Text Editor |
| `EnableHover` | Highlights the row or item under the mouse cursor. | DataGrid, TreeGrid |
| `EnableHtmlSanitizer` | Sanitizes HTML content to prevent cross-site scripting attacks. | Rich Text Editor, Smart Rich Text Editor, Gantt Chart |
| `AllowRowDragAndDrop` | Enables dragging and dropping rows to reorder or move them. | DataGrid, TreeGrid, Gantt Chart |
| `Tooltip` | Configures tooltip content and appearance for chart elements. | Chart, Accumulation Chart, 3D Chart, Sparkline Charts, Stock Chart |

## 6) Common method APIs (shared method names)

These methods often share the same name across components, mostly exposed as `Async` methods in Blazor.

| API name | Purpose | Components that commonly use it |
| --- | --- | --- |
| `RefreshAsync` | Re-renders the component after external state or data changes. | Chart, DataGrid, Circular Gauge, Linear Gauge, Dashboard Layout, Image Editor, Kanban, Pivot Table, Toolbar, ListView, Accordion |
| `FocusAsync` | Sets keyboard focus to the component. | TextBox, NumericTextBox, DatePicker, ComboBox, DropDownList, AutoComplete, MultiSelect, Button, CheckBox, Chip, FloatingActionButton, Chat UI, Accumulation Chart, Toolbar, Rich Text Editor |
| `PrintAsync` | Triggers the browser print dialog with the component content. | Chart, Accumulation Chart, 3D Chart, Bullet Chart, Circular Gauge, Linear Gauge, DataGrid, TreeGrid, Gantt Chart, Scheduler, Maps, Pivot Table, Diagram, Stock Chart, TreeMap, Block Editor |
| `ExportAsync` | Exports the component to an image, PDF, or other file format. | Chart, Accumulation Chart, 3D Chart, Circular Gauge, Linear Gauge, Sankey, HeatMap, DataGrid, TreeGrid, Gantt Chart, Scheduler, Pivot Table, Stock Chart, Image Editor, Diagram, Block Editor |
| `SelectRowsAsync` | Selects specific grid rows programmatically. | DataGrid, TreeGrid, Gantt Chart |
| `ClearSelectionAsync` | Clears the current selection. | DataGrid, TreeGrid, Gantt Chart, HeatMap, ListView, TreeView |
| `ExpandAllAsync` / `CollapseAllAsync` | Expands or collapses all groups, rows, or nodes. | TreeView, TreeGrid, Gantt Chart |
| `HideAsync` / `ShowAsync` | Programmatically hides or shows a component. | Dialog, Toast, Sidebar, Speed Dial, Message |
| `OpenAsync` / `CloseAsync` | Programmatically opens or closes a popup-style component or loads an image. | Dialog, Tooltip, Sidebar, Image Editor (`OpenAsync` loads an image) |
| `GetPersistDataAsync` | Gets the current state as a JSON string for manual persistence management. | DataGrid, TreeGrid, Gantt Chart, Pivot Table, Dashboard Layout |

## Notes for new users

- Many Syncfusion Blazor components use the same property names, even when the underlying behavior is slightly different.
- The `Allow*` prefix usually turns a feature on, `Enable*` usually controls runtime behavior, and `Show*` usually makes a UI element visible. Learning these patterns makes many APIs easier to understand.
- Data-oriented controls often share `DataSource`, `Query`, and `Fields`.
- Interaction-heavy components usually expose familiar event names such as `Created`, `Destroyed`, and `ValueChange`.
- Grid family components such as DataGrid, TreeGrid, and Gantt Chart often share the same API names for sorting, filtering, grouping, resizing, and paging.
- When in doubt, check the component-specific API reference to confirm whether a property behaves the same way across components.
