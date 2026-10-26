---
layout: post
title: API consistency in Blazor components | Syncfusion®
description: Learn the common API names (appearance, value, data binding, event, configuration, and method) shared across Syncfusion Blazor components.
platform: Blazor
control: Common
documentation: ug
---

# API consistency in Syncfusion Blazor components

This topic lists common API names that appear across multiple [Syncfusion Blazor components](https://www.syncfusion.com/blazor-components). It helps new users recognize familiar property, event, and method patterns when moving between components, so knowledge from one component can be applied to another.

Each table lists APIs that share a name and shows which components expose them. The lists include the Syncfusion Blazor components in this topic. A component that is not listed might still expose the API, so check its API reference. Behavior, accepted values, and event arguments can differ by component.

The guide begins with the naming conventions shared across components, followed by these sections:

- [Common appearance and layout APIs](#1-common-appearance-and-layout-apis)
- [Common value and selection APIs](#2-common-value-and-selection-apis)
- [Common data binding APIs](#3-common-data-binding-apis)
- [Common interaction and event APIs](#4-common-interaction-and-event-apis)
- [Common configuration APIs](#5-common-configuration-apis)
- [Common method APIs](#6-common-method-apis)

## Naming conventions

Syncfusion Blazor components follow shared naming patterns, so the purpose of an API can often be recognized from its name alone. The tables in this topic follow these conventions.

### Properties

| Pattern | Meaning | Examples |
| --- | --- | --- |
| `Allow*` | Turns on a user-facing interaction or feature. | `AllowFiltering`, `AllowPaging`, `AllowResizing`, `AllowSorting` |
| `Enable*` | Turns on a rendering mode or component behavior. | `EnableAdaptiveUI`, `EnableHtmlSanitizer`, `EnablePersistence`, `EnableRtl` |
| `Show*` | Shows or hides a specific part of the UI. | `ShowClearButton`, `ShowColumnChooser`, `ShowTodayButton`, `ShowTooltip` |
| `Popup*` | Configures the popup surface of dropdown-style components. | `PopupHeight`, `PopupWidth`, `PopupContent`, `PopupDisplayMode` |
| `*Settings` | Groups related options into a child component or configuration object. | `EditSettings`, `FilterSettings`, `KeySettings`, `SelectionSettings`, `SearchSettings`, `SortSettings`, `PageSettings` |
| `*Attributes` | Passes additional HTML attributes to the rendered element. | `HtmlAttributes`, `InputAttributes` |

These patterns are guidelines. Some APIs use other names, for example `WeekNumber`, `FullScreen`, `StrictMode`, `LoadOnDemand`, and `Visible`. `AllowEdit` lets users type in a picker input, and `AllowEditing` enables editing in components such as Spreadsheet and TreeView. Use the tables in this topic to find the exact name.

### Events

| Pattern | Meaning | Examples |
| --- | --- | --- |
| Names ending in `ing` | Fires before an action occurs. These events can often be canceled through the event arguments. | `Expanding`, `Collapsing`, `Filtering`, `Resizing`, `RowCreating`, `RowSelecting`, `CellSelecting`, `RowDeleting`, `RowEditing` |
| Names ending in `ed` | Fires after an action has completed. | `Created`, `Destroyed`, `DataBound`, `RowSelected` |
| `On*` / `*ed` pair | `On*` fires when an action starts. The matching past-tense event fires after the action completes. | `OnOpen` / `Opened`, `OnClose` / `Closed` |
| `OnActionBegin` / `OnActionComplete` | Fires before and after a data operation or component action. | `OnActionBegin`, `OnActionComplete` |

Some events, such as `Focus`, `Blur`, and `ValueChange`, are named for the action itself.

### Methods

| Pattern | Meaning | Examples |
| --- | --- | --- |
| `*Async` | Public methods are asynchronous and return a `Task`. Await them. | `ClearSelectionAsync`, `FocusAsync`, `RefreshAsync` |
| Paired verbs | Opposite operations use matching verb pairs. | `ShowAsync` / `HideAsync`, `ExpandAllAsync` / `CollapseAllAsync`, `ShowPopupAsync` / `HidePopupAsync`, `AddEventAsync` / `DeleteEventAsync` |

## 1. Common appearance and layout APIs

| API name | Purpose | Supported components |
| --- | --- | --- |
| `CssClass` | Adds one or more custom CSS classes to the component root element for styling. | Accordion, AppBar, AutoComplete, Breadcrumb, Button, Calendar, Carousel, CheckBox, Chip, ColorPicker, ComboBox, ContextMenu, Dialog, DropDownList, DropDownTree, FileManager, ImageEditor, InPlaceEditor, Kanban, ListBox, ListView, MaskedTextBox, Mention, Menu, Message, MultiColumnComboBox, MultiSelect, NumericTextBox, OtpInput, Pager, ProgressButton, QueryBuilder, RadioButton, Rating, Ribbon, RichTextEditor, Schedule, Sidebar, Signature, Skeleton, Slider, SpeechToText, SpeedDial, SplitButton, Splitter, Spreadsheet, Stepper, Switch, Tab, TextArea, TextBox, Timeline, TimePicker, Toast, Toolbar, Tooltip, TreeView, Uploader |
| `Width` | Sets the component width. The accepted unit and default value vary by component. | Accordion, BlockEditor, Carousel, AutoComplete, ComboBox, DatePicker, DateRangePicker, DateTimePicker, Dialog, DocumentEditor, DocumentEditorContainer, DropDownList, DropDownTree, FileManager, Gantt, Grid, ImageEditor, Kanban, ListView, MaskedTextBox, MultiColumnComboBox, MultiSelect, PivotView, ProgressBar, QueryBuilder, Ribbon, RichTextEditor, Schedule, Sidebar, Skeleton, Slider, Splitter, Spreadsheet, Tab, TextArea, TextBox, TimePicker, Toast, Toolbar, Tooltip, TreeGrid, TreeMap |
| `Height` | Sets the component height. The accepted unit and default value vary by component. | Accordion, BlockEditor, Carousel, Dialog, DocumentEditor, DocumentEditorContainer, FileManager, Gantt, Grid, ImageEditor, Kanban, ListBox, ListView, PivotView, ProgressBar, QueryBuilder, RichTextEditor, Skeleton, Splitter, Spreadsheet, Tab, Toast, Toolbar, Tooltip, TreeView |
| `EnableRtl` | Enables right-to-left rendering. | Accordion, AppBar, AutoComplete, Breadcrumb, Button, Calendar, Carousel, CheckBox, Chip, ColorPicker, ContextMenu, DashboardLayout, DatePicker, DateRangePicker, DateTimePicker, Dialog, DocumentEditor, DocumentEditorContainer, ComboBox, DropDownList, DropDownTree, FileManager, Gantt, Grid, InPlaceEditor, Kanban, ListBox, ListView, MaskedTextBox, Menu, MultiSelect, NumericTextBox, PivotView, ProgressBar, QueryBuilder, RadioButton, RichTextEditor, Sidebar, Slider, Splitter, Switch, Tab, TextArea, TextBox, TimePicker, Toast, Toolbar, Tooltip, TreeView, Uploader |

## 2. Common value and selection APIs

| API name | Purpose | Supported components |
| --- | --- | --- |
| `Value` | Gets or sets the current value. Use `@bind-Value` for two-way binding. For CheckBox, RadioButton, and Switch, use `Checked` for the checked state. | Calendar, CheckBox, Chip, ColorPicker, AutoComplete, ComboBox, DatePicker, DateTimePicker, DropDownList, DropDownTree, InPlaceEditor, ListBox, MaskedTextBox, MultiColumnComboBox, MultiSelect, NumericTextBox, OtpInput, ProgressBar, RadioButton, Rating, RichTextEditor, Slider, Switch, TextArea, TextBox, TimePicker |
| `Placeholder` | Shows hint text when no value is entered or selected. | DatePicker, DateRangePicker, DateTimePicker, AutoComplete, ComboBox, DropDownList, DropDownTree, MaskedTextBox, MultiColumnComboBox, MultiSelect, OtpInput, RichTextEditor, TextArea, TextBox, TimePicker |
| `FilterBarPlaceholder` | Shows placeholder text inside a filter or search box. | AutoComplete, ComboBox, DropDownList, DropDownTree, ListBox, MultiSelect, QueryBuilder |
| `DebounceDelay` | Sets how long, in milliseconds, the component waits after the user stops typing before it filters. This reduces the number of filter requests. | AutoComplete, ComboBox, DropDownList, MultiColumnComboBox, MultiSelect |
| `FilterType` | Controls how text matches are evaluated during filtering or search. | AutoComplete, ComboBox, DropDownList, DropDownTree, Mention, MultiColumnComboBox |
| `IgnoreCase` | Controls whether case is ignored during filtering or search. | AutoComplete, ComboBox, DropDownList, DropDownTree, MultiColumnComboBox |
| `Min` / `Max` | Sets the minimum and maximum allowed value. Depending on the component, the value is a date, time, or number. | Calendar, DatePicker, DateRangePicker, DateTimePicker, NumericTextBox, Slider, TimePicker |
| `FirstDayOfWeek` | Sets the first day of the week used in calendar views. | Calendar, DatePicker, DateRangePicker, DateTimePicker, Schedule |
| `CalendarMode` | Switches the calendar system between Gregorian and Islamic. | Calendar, DatePicker, DateRangePicker, DateTimePicker |
| `ShowTodayButton` | Shows or hides the Today button in calendar-based pickers. | Calendar, DatePicker, DateRangePicker, DateTimePicker |
| `WeekNumber` | Shows or hides week numbers in calendar-based pickers. | Calendar, DatePicker, DateRangePicker, DateTimePicker |
| `AllowMultiSelection` | Enables multiple-item selection. | FileManager, DropDownTree, TreeView |
| `AllowSelection` | Enables row, cell, or item selection depending on the component. | Gantt, Grid, TreeGrid |
| `AllowFiltering` | Enables built-in filtering or search UI. | AutoComplete, ComboBox, DropDownList, DropDownTree, Gantt, Grid, ListBox, MultiColumnComboBox, MultiSelect, Spreadsheet, TreeGrid |
| `ShowCheckBox` | Displays checkboxes in items or nodes for multi-selection. | DropDownTree, ListView, TreeView |
| `AllowResizing` | Lets users resize panels, columns, rows, or events by dragging, depending on the component. | DashboardLayout, Gantt, Grid, Schedule, Spreadsheet, TreeGrid |
| `AllowDragAndDrop` | Lets users move items, nodes, cards, events, or tabs by dragging them. | FileManager, Kanban, ListBox, QueryBuilder, Schedule, Tab, TreeView |

## 3. Common data binding APIs

| API name | Purpose | Supported components |
| --- | --- | --- |
| `DataSource` | Binds the component to local data or a `SfDataManager`/remote source when supported. | AutoComplete, ComboBox, DropDownList, Gantt, Grid, Kanban, ListView, MultiColumnComboBox, QueryBuilder, Spreadsheet |

## 4. Common interaction and event APIs

| API name | Purpose | Supported components |
| --- | --- | --- |
| `Created` | Fires after the component is created or rendered. | Accordion, AppBar, AutoComplete, Breadcrumb, Button, Calendar, CheckBox, Chip, ColorPicker, ComboBox, DashboardLayout, DatePicker, DateRangePicker, DateTimePicker, Dialog, DocumentEditor, DocumentEditorContainer, DropDownList, DropDownTree, Gantt, Grid, ImageEditor, InPlaceEditor, Kanban, ListBox, ListView, MaskedTextBox, Mention, Menu, MultiColumnComboBox, MultiSelect, NumericTextBox, OtpInput, Pager, PivotView, QueryBuilder, RadioButton, Rating, Ribbon, RichTextEditor, Sidebar, Signature, Slider, SpeechToText, SpeedDial, Splitter, Stepper, Switch, Tab, TextArea, TextBox, Timeline, TimePicker, Toast, Toolbar, Tooltip, TreeView, Uploader |
| `Destroyed` | Fires when the component is disposed or destroyed. | Accordion, AppBar, AutoComplete, Calendar, CheckBox, Chip, ColorPicker, ComboBox, DashboardLayout, DatePicker, DateRangePicker, DateTimePicker, Dialog, DocumentEditor, DocumentEditorContainer, DropDownList, DropDownTree, Gantt, Grid, ImageEditor, InPlaceEditor, Kanban, ListBox, ListView, MaskedTextBox, Mention, MultiColumnComboBox, MultiSelect, NumericTextBox, PivotView, QueryBuilder, RichTextEditor, Sidebar, Slider, Splitter, Tab, TextArea, TextBox, TimePicker, Toast, Toolbar, Tooltip, TreeView |
| `Blur` | Fires when the component loses focus. | AutoComplete, BlockEditor, ComboBox, DatePicker, DateRangePicker, DateTimePicker, DropDownList, MaskedTextBox, MultiColumnComboBox, MultiSelect, NumericTextBox, RichTextEditor, TextArea, TextBox, TimePicker |
| `Focus` | Fires when the component gains focus. | AutoComplete, BlockEditor, ComboBox, DatePicker, DateRangePicker, DateTimePicker, DropDownList, MaskedTextBox, MultiColumnComboBox, MultiSelect, NumericTextBox, RichTextEditor, TextArea, TextBox, TimePicker |
| `ValueChange` | Fires when the component value changes. Use `@bind-Value` for two-way binding. Use `ValueChange` to run code when the value changes. The event payload and timing differ by component. | AutoComplete, Calendar, CheckBox, ColorPicker, ComboBox, DatePicker, DateRangePicker, DateTimePicker, DropDownList, InPlaceEditor, ListBox, MaskedTextBox, MultiColumnComboBox, MultiSelect, NumericTextBox, RadioButton, RichTextEditor, Slider, Switch, TextArea, TextBox, TimePicker, Uploader |
| `DataBound` | Fires after data binding is complete. | AutoComplete, ComboBox, DropDownList, Gantt, Grid, MultiSelect, PivotView, QueryBuilder, TreeView |
| `OnActionBegin` | Fires before a data operation or component action begins. | AutoComplete, ComboBox, DropDownList, Gantt, Grid, InPlaceEditor, ListBox, ListView, Mention, MultiColumnComboBox, MultiSelect, PivotView, RichTextEditor, Schedule, TreeGrid |
| `OnActionComplete` | Fires after a data operation or component action completes. | AutoComplete, ComboBox, DropDownList, Gantt, Grid, InPlaceEditor, ListBox, ListView, Mention, MultiColumnComboBox, MultiSelect, PivotView, RichTextEditor, TreeGrid |
| `RowCreating` | Fires before a row is created. | Gantt, Grid, TreeGrid |
| `RowCreated` | Fires after a row is created. | Gantt, Grid, TreeGrid |
| `OnOpen` / `Opened` | Fires when a popup, dialog, tooltip, sidebar, or menu-like overlay is opened or about to open. | AutoComplete, ColorPicker, ComboBox, DatePicker, DateRangePicker, DateTimePicker, Dialog, DropDownButton, DropDownList, Menu, MultiSelect, Sidebar, SplitButton, SpeedDial, Toast, Tooltip |
| `OnClose` / `Closed` | Fires when a popup, dialog, tooltip, sidebar, or overlay is closed or about to close. | AutoComplete, ColorPicker, ComboBox, DatePicker, DateRangePicker, DateTimePicker, Dialog, DropDownButton, DropDownList, Menu, MultiSelect, Sidebar, SplitButton, SpeedDial, Toast, Tooltip |
| `RowSelected` / `RowSelecting` | Fires after or before row selection. | Gantt, Grid, TreeGrid, PivotView |
| `RowDataBound` | Fires after a row has been bound with data. | Gantt, Grid, TreeGrid |

## 5. Common configuration APIs

| API name | Purpose | Supported components |
| --- | --- | --- |
| `AllowEdit` | Allows the user to type a value directly instead of using only the popup or picker surface. | DatePicker, DateRangePicker, DateTimePicker, TimePicker |
| `FullScreen` | Enables full-screen popup rendering on mobile or tablet devices. | DatePicker, DateRangePicker, DateTimePicker, TimePicker |
| `OpenOnFocus` | Opens the popup automatically when the input receives focus. | DatePicker, DateRangePicker, DateTimePicker, TimePicker |
| `EnableMask` | Enables masked input behavior. | DatePicker, DateTimePicker, TimePicker |
| `FloatLabelType` | Configures floating label behavior. | AutoComplete, ComboBox, DropDownList, DatePicker, DateRangePicker, DateTimePicker, DropDownTree, MaskedTextBox, MultiSelect, MultiColumnComboBox, NumericTextBox, TextArea, TextBox, TimePicker |
| `Format` | Configures display formatting for the selected value. | Calendar, DatePicker, DateRangePicker, DateTimePicker, TimePicker |
| `InputFormats` | Configures accepted input parsing formats. | DatePicker, DateRangePicker, DateTimePicker, TimePicker |
| `HtmlAttributes` | Provides additional HTML attributes for the component root element or wrapper. | Accordion, AppBar, AutoComplete, Breadcrumb, Button, Calendar, Carousel, CheckBox, Chip, ColorPicker, ComboBox, ContextMenu, DatePicker, DateRangePicker, DateTimePicker, Dialog, DropDownButton, DropDownList, DropDownTree, FileManager, ImageEditor, InPlaceEditor, ListBox, ListView, MaskedTextBox, MultiColumnComboBox, MultiSelect, OtpInput, ProgressButton, RadioButton, Rating, Sidebar, Signature, SpeechToText, SplitButton, Splitter, Switch, TextArea, TextBox, TimePicker, Tooltip, Uploader |
| `InputAttributes` | Provides additional HTML attributes for the input element. | DatePicker, DateRangePicker, DateTimePicker, AutoComplete, ComboBox, DropDownList, MaskedTextBox, MultiColumnComboBox, MultiSelect, TextArea, TextBox, TimePicker, Uploader |
| `PopupHeight` | Controls the height of popup surfaces used by dropdown-style components. | AutoComplete, ComboBox, DropDownButton, DropDownList, DropDownTree, Mention, MultiColumnComboBox, MultiSelect |
| `PopupWidth` | Controls the width of popup surfaces used by dropdown-style components. | AutoComplete, ComboBox, DropDownButton, DropDownList, DropDownTree, Mention, MultiColumnComboBox, MultiSelect |
| `TabIndex` | Controls keyboard tab order. | Calendar, DatePicker, DateRangePicker, DateTimePicker, TimePicker |
| `ZIndex` | Controls popup stacking order. | DatePicker, DateRangePicker, DateTimePicker, TimePicker |
| `IconCss` | Supplies an icon CSS class for buttons, menu items, or items that render icons. | Breadcrumb, Button, DropDownButton, ProgressButton, SpeedDialItem, SplitButton |
| `IconPosition` | Controls where the icon appears relative to text. | Button, DropDownButton, ProgressButton, SpeedDial, SplitButton |
| `ShowClearButton` | Displays a clear button. | AutoComplete, ComboBox, DatePicker, DateRangePicker, DateTimePicker, DropDownList, DropDownTree, MaskedTextBox, MultiColumnComboBox, MultiSelect, TextArea, TextBox, TimePicker |
| `LoadOnDemand` | Delays loading or rendering content until it is expanded or requested. | Accordion, DropDownTree, TreeView |
| `StrictMode` | Restricts user input to valid values within the configured range. | DatePicker, DateRangePicker, DateTimePicker, TimePicker |
| `AllowEditing` | Enables editing where the component supports it. | Spreadsheet, TreeView |
| `AllowSorting` | Enables sorting. | Gantt, Grid, MultiColumnComboBox, Spreadsheet, TreeGrid |
| `AllowMultiSorting` | Enables multi-column or multi-field sorting. | Gantt, Grid, MultiColumnComboBox, TreeGrid |
| `AllowGrouping` | Enables grouping or grouping UI. | Grid, PivotView |
| `AllowPaging` | Enables paging. | FileManager, Grid, MultiColumnComboBox, TreeGrid |
| `AllowTextWrap` | Enables text wrapping. | Grid, TreeGrid, TreeView |
| `AllowReordering` | Enables reordering of columns or tab items. | Gantt, Grid, Tab |
| `AllowExcelExport` | Enables Excel export. | Gantt, Grid, PivotView, TreeGrid |
| `AllowPdfExport` | Enables PDF export. | Gantt, Grid, PivotView, TreeGrid, TreeMap |
| `ShowColumnMenu` | Displays a column menu. | Gantt, Grid, TreeGrid |
| `ShowColumnChooser` | Displays the column chooser UI. | Gantt, Grid, TreeGrid |
| `EnableAdaptiveUI` | Renders a layout optimized for small screens. | Gantt, Grid, Schedule, TreeGrid |
| `EnableContextMenu` | Enables the context menu. | DocumentEditor, Gantt, Spreadsheet |
| `EnablePersistence` | Persists state across page reloads. The persisted state differs by component. | Accordion, Breadcrumb, Calendar, Carousel, CheckBox, ColorPicker, DashboardLayout, DatePicker, DateRangePicker, DateTimePicker, Dialog, DocumentEditor, DocumentEditorContainer, AutoComplete, ComboBox, DropDownList, DropDownTree, FileManager, Gantt, Grid, InPlaceEditor, Kanban, ListBox, ListView, MaskedTextBox, NumericTextBox, Pager, PivotView, QueryBuilder, RadioButton, Ribbon, RichTextEditor, Sidebar, Signature, Slider, Splitter, Switch, Tab, TextArea, TextBox, TimePicker, TreeView, Uploader |
| `EnableVirtualization` | Enables virtualization for large data sets. | AutoComplete, ComboBox, DropDownList, DropDownTree, FileManager, Grid, ListView, MultiColumnComboBox, MultiSelect, PivotView, TreeGrid, TreeView |
| `ShowTooltip` | Toggles whether tooltips are displayed by the component. | FileManager, Grid, PivotView, Rating, RichTextEditor, SpeechToText, Stepper |
| `EnableHtmlSanitizer` | Sanitizes HTML content to help prevent cross-site scripting (XSS) attacks. It does not replace server-side validation. | BlockEditor, FileManager, PivotView, RichTextEditor, Uploader |
| `AllowRowDragAndDrop` | Enables row drag-and-drop or row reordering. | Gantt, Grid, TreeGrid |
| `Orientation` | Controls horizontal or vertical layout/orientation. | Menu, Slider, Splitter, Stepper, Timeline |
| `Visible` | Controls whether the component is shown or hidden. | Dialog, Message, ProgressBar, Rating, Skeleton, SpeedDial, Splitter |
| `GridLines` | Controls whether or how grid lines are displayed. | Gantt, Grid, MultiColumnComboBox, TreeGrid |
| `OverscanCount` | Controls the extra rendered items beyond the visible viewport during virtualization. | Gantt, Grid, TreeGrid |
| `SelectionSettings` | Configures selection behavior and selection mode. | Gantt, Grid, TreeGrid |

## 6. Common method APIs

| API name | Purpose | Supported components |
| --- | --- | --- |
| `RefreshAsync` | Re-renders or refreshes the component so that pending state changes are applied. | DashboardLayout, DropDownTree, Gantt, Kanban, Pager, PivotView, Signature, Tab, Toast, Toolbar, Tooltip, TreeMap |
| `FocusAsync` | Sets keyboard focus to the component. | Button, ColorPicker, AutoComplete, ComboBox, DatePicker, DateRangePicker, DateTimePicker, DocumentEditor, DropDownList, MaskedTextBox, MultiColumnComboBox, MultiSelect, NumericTextBox, ProgressButton, RichTextEditor, TextArea, TextBox, TimePicker |
| `PrintAsync` | Invokes printing for the component or its content. | BlockEditor, DocumentEditor, RichTextEditor, TreeMap |
| `ExportAsync` | Exports the component or its content when supported. | ImageEditor, TreeMap |
| `ClearSelectionAsync` | Clears the current selection. | FileManager, Gantt, Grid, ImageEditor, TreeGrid |
| `ExpandAllAsync` / `CollapseAllAsync` | Expands or collapses all relevant nodes or rows. | Gantt, TreeView, TreeGrid |
| `ShowAsync` / `HideAsync` | Shows or hides a popup-style component or overlay. | Dialog, SpeedDial, Toast |
| `GetPersistDataAsync` | Retrieves the persisted state payload. | Calendar, DatePicker, DateTimePicker, DashboardLayout, Gantt, Grid, MaskedTextBox, PivotView, TextArea, TextBox, TimePicker, TreeGrid |

## See also

- [Blazor Web App getting started guide](https://blazor.syncfusion.com/documentation/getting-started/blazor-web-app)
- [API reference](https://help.syncfusion.com/cr/blazor)
