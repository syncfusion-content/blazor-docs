---
layout: post
title: WebMCP Supported Blazor Components and Tools | Syncfusion
description: Browse built-in WebMCP tools for Data Grid, Scheduler, Chart, Gantt, Diagram, and the other supported Blazor components.
platform: Blazor
control: WebMCP
documentation: ug
---

# WebMCP Supported Components

The components below support WebMCP. Each one uses the same settings, tools, and event pattern, with its own command enum. The tool counts in the table are a guide. Call `GetWebMcpToolsAsync` to see what a component instance registers.

| Component | Command enum | Built-in tools |
| --- | --- | --- |
| Data Grid | `GridWebMcpToolCommand` | 79 |
| Scheduler | `ScheduleWebMcpToolCommand` | 5 |
| Chart | `ChartWebMcpToolCommand` | 37 |
| Gantt | `GanttWebMcpToolCommand` | 64 |
| Diagram | `DiagramWebMcpToolCommand` | 18 |
| File Manager | `FileManagerWebMcpToolCommand` | 17 |
| Rich Text Editor | `RichTextEditorWebMcpToolCommand` | 20 |
| PDF Viewer | `PdfViewerWebMcpToolCommand` | 32 |
| Document Editor | `DocumentEditorWebMcpToolCommand` | 61 |
| Spreadsheet | `SpreadsheetWebMcpToolCommand` | 49 |

Select a built-in tool with its command enum, for example `Command="GridWebMcpToolCommand.NavigateToPage"`. See [Tools](./tools) for how to enable, disable, rename, or replace a command.

## Data Grid

| Group | Tools |
| --- | --- |
| Read data | `GetSelectedRecords`, `GetSelectedRowIndexes`, `GetSelectedRowCellIndexes`, `GetFilteredRecords`, `GetCurrentViewRecords`, `GetCellValue` |
| Read edit state | `GetEditState`, `IsDirty` |
| Read columns | `GetColumnByField`, `GetColumnByUid`, `GetVisibleColumns`, `GetHiddenColumns`, `GetColumnFieldNames`, `GetColumnIndexByField`, `GetUidByColumnField` |
| Paging | `NavigateToPage`, `UpdatePageSize` |
| Scroll and focus | `ScrollIntoView`, `FocusGrid` |
| Search | `FindAndHighlight`, `SearchText` |
| Sort | `SortByColumn`, `SortColumns`, `SortColumnsWithClear`, `ClearSorting`, `ClearSortingByFields` |
| Filter | `FilterByColumn`, `ClearFiltering` |
| Select rows | `SelectRows`, `SelectRowsByRange`, `ClearSelection` |
| Select cells | `SelectCell`, `SelectCells`, `SelectCellsByRange`, `ClearCellSelection` |
| Edit cells | `SetCellValue`, `SetRowData`, `EditCell`, `SaveCell` |
| Edit rows | `DeleteRow`, `CrudLifecycle`, `BatchEditWorkflow`, `UpdateGridData`, `ReorderRow` |
| History | `UndoRedoHistory` |
| Group | `GroupByColumn`, `UngroupColumn`, `ClearGrouping` |
| Expand groups | `ExpandAllGroups`, `CollapseAllGroups` |
| Column visibility | `ShowColumns`, `HideColumns`, `OpenColumnChooser` |
| Reorder columns | `ReorderColumn`, `ReorderColumns`, `ReorderColumnByIndex`, `ReorderColumnByTargetIndex`, `AutoFitColumns` |
| Detail rows | `ExpandCollapseDetailRow`, `ExpandAllDetailRows`, `CollapseAllDetailRows` |
| Merge cells | `MergeCells`, `MergeCellsBulk`, `UnmergeCells`, `UnmergeCellsBulk`, `UnmergeAll` |
| Export | `ExcelExport`, `PdfExport` |
| Print | `PrintGrid` |
| Clipboard | `CopyToClipboard`, `PasteFromClipboard` |
| Rendering | `PreventRender`, `ShowSpinner`, `HideSpinner`, `RefreshGrid`, `RefreshColumns`, `RefreshHeader` |
| State | `PersistGridState`, `UpdateExternalMessage` |


## Scheduler

| Group | Tools |
| --- | --- |
| Events and navigation | `CreateEvent`, `UpdateEvent`, `DeleteEvent`, `ChangeView`, `NavigateDate` |


## Chart

| Group | Tools |
| --- | --- |
| Read | `InspectChart`, `GetSeriesData`, `GetChartPoint`, `GetSelectedChartData`, `GetChartAxes`, `GetChartIndicators`, `GetChartStriplines`, `GetChartAnnotations`, `GetChartLegend` |
| Series and data | `AddChartSeries`, `UpdateChartSeries`, `RemoveChartSeries`, `ClearChartSeries`, `ToggleChartSeriesVisibility`, `UpdateChartDataSource`, `AppendChartData`, `UpdateChartPoint`, `RemoveChartPoints` |
| Axes and annotations | `AddChartAxis`, `UpdateChartAxis`, `RemoveChartAxis`, `AddChartAnnotation`, `UpdateChartAnnotation`, `RemoveChartAnnotation` |
| Interaction | `ShowChartTooltip`, `HideChartTooltip`, `ShowChartCrosshair`, `HideChartCrosshair`, `ConfigureChartZoom`, `ResetChartZoom`, `SelectChartPoints`, `ClearChartSelection`, `AnimateChart` |
| Appearance and output | `UpdateChartTitle`, `UpdateChartProperties`, `ExportChart`, `PrintChart` |


## Gantt

| Group | Tools |
| --- | --- |
| Read | `GetData`, `GetSelectedRecords`, `GetSelectedRowIndexes`, `GetSelectedRowCellIndexes`, `GetCurrentViewRecords`, `GetFilteredRecords`, `GetTaskById`, `GetRowTaskModel`, `GetCriticalTasks`, `GetColumns`, `GetColumnIndexByField`, `GetPersistedData` |
| Sort, filter, search | `SortByColumn`, `ClearSorting`, `FilterByColumn`, `ClearFiltering`, `Search` |
| Select | `SelectRow`, `SelectRows`, `SelectRowRange`, `SelectCell`, `ClearSelection` |
| Tasks | `AddTask`, `UpdateTask`, `DeleteTask`, `SplitTask`, `MergeTask`, `ConvertToMilestone`, `IndentTask`, `OutdentTask`, `ReorderRow`, `UpdateProjectDates` |
| Dependencies | `AddPredecessor`, `UpdatePredecessor`, `RemovePredecessor` |
| Expand and collapse | `ExpandAll`, `CollapseAll`, `ExpandAtLevel`, `CollapseAtLevel`, `ExpandByKey`, `CollapseByKey` |
| Timeline | `ZoomIn`, `ZoomOut`, `ZoomToFit`, `ResetZoom`, `ScrollToTimeline`, `ScrollToTaskbar`, `NavigateToNextTimeSpan`, `NavigateToPreviousTimeSpan` |
| Dialogs and layout | `OpenAddDialog`, `OpenEditDialog`, `CancelEdit`, `SetSplitterPosition`, `ShowColumn`, `HideColumn`, `ReorderColumns`, `OpenColumnChooser` |
| State and rendering | `SetPersistedData`, `ResetPersistedData`, `Refresh`, `RefreshColumns`, `ShowSpinner`, `HideSpinner`, `CopyToClipboard` |


## Diagram

| Group | Tools |
| --- | --- |
| Read | `GetDiagramCatalog` |
| Nodes and connectors | `CreateDiagramNode`, `CreateDiagramConnector`, `DragNode`, `DeleteFromDiagram` |
| Selection and editing | `ManageNodeSelection`, `EnableEditingMode`, `ArrangeAndAlignObjects`, `ArrangeZOrder` |
| Groups, labels, and ports | `ManageGroupsAndHierarchies`, `ManageAnnotationsAndLabels`, `ManagePorts` |
| History and clipboard | `ManageUndoRedo`, `ManageClipboardOperations` |
| Layout and navigation | `ApplyLayoutToNodes`, `NavigateAndZoomDiagram`, `ExportAndImportDiagrams`, `CreateUmlSequenceDiagram` |


## File Manager

| Group | Tools |
| --- | --- |
| Read and select | `GetSelectedFiles`, `SelectAll`, `ClearSelection`, `FilterFiles` |
| Navigate | `OpenFile`, `TraverseBackward`, `RefreshFiles`, `RefreshLayout` |
| File operations | `CreateFolder`, `RenameFile`, `DeleteFiles`, `UploadFiles`, `DownloadFiles` |
| Menu and toolbar | `EnableMenuItems`, `DisableMenuItems`, `EnableToolbarItems`, `DisableToolbarItems` |


## Rich Text Editor

| Group | Tools |
| --- | --- |
| Read | `GetContent`, `GetSelectedHtml`, `SelectAllContent` |
| Insert | `InsertContent`, `InsertLink`, `InsertTable`, `InsertImage`, `InsertBR` |
| Format | `FormatSelectedContent`, `SetBlockType`, `SetTextAlignment`, `SetCodeBlock`, `ApplyNumberedListFormat`, `ApplyBulletedListFormat`, `ClearFormatting` |
| Dialogs and history | `ShowDialog`, `CloseDialog`, `UndoLastAction`, `RedoLastAction`, `PrintContent` |


## PDF Viewer

| Group | Tools |
| --- | --- |
| Read state | `GetViewerState`, `GetPageDetails`, `GetDocumentInfo` |
| Read content (off by default) | `GetBookmarks`, `GetAnnotations`, `GetFormFields`, `GetSearchTextPositions`, `GetPageText` |
| Navigate and view | `GoToPage`, `GoToBookmark`, `SetZoom`, `FitToPage` |
| Search | `SearchText`, `SearchNext` |
| Annotations | `AddAnnotation`, `EditAnnotation`, `DeleteAnnotations`, `Redact`, `UndoRedo` |
| Form fields | `AddFormFields`, `UpdateFormFields`, `DeleteFormFields`, `ImportFormFields`, `ExportFormFields` |
| Pages | `RotatePages`, `MovePages`, `InsertBlankPages`, `DeletePages`, `DuplicatePages`, `ExtractPages` |
| Output | `Print`, `Download` |


## Document Editor

| Group | Tools |
| --- | --- |
| Document | `SaveDocument`, `Print`, `GetPageCount`, `GoToPage` |
| Selection | `SelectAll`, `SelectCurrentWord`, `SelectParagraph`, `GetSelectedText`, `GetSelectedContent` |
| Find and insert | `FindAll`, `InsertText`, `Paste`, `InsertImage`, `InsertHyperlink`, `InsertEditingRegion` |
| Bookmarks | `GetBookmarks`, `InsertBookmark`, `SelectBookmark` |
| Character format | `Get` and `Set` pairs for `CharacterFormatBold`, `Italic`, `Underline`, `Strikethrough`, `FontFamily`, `FontSize`, `FontColor`, `BaselineAlignment`, `HighlightColor` |
| Paragraph format | `Get` and `Set` pairs for `ParagraphFormatTextAlignment`, `LeftIndent`, `RightIndent`, `FirstLineIndent`, `BeforeSpacing`, `AfterSpacing`, `LineSpacing`, `LineSpacingType`, `ListLevelNumber`, `OutlineLevel`, `ContextualSpacing`. `GetParagraphFormatListText` is read-only |


## Spreadsheet

| Group | Tools |
| --- | --- |
| Read | `GetActiveSheet`, `GetSelection`, `GetCellValue`, `GetWorkbookInfo`, `Find`, `FindAll`, `ListCharts`. `GetRangeData` is opt-in |
| Edit cells | `UpdateCell`, `UpdateCells`, `ClearRange`, `Replace`, `Autofill`, `SelectRange` |
| Format | `SetCellFormat`, `SetNumberFormat`, `SetBorders`, `MergeCells`, `UnmergeCells`, `SetColumnWidth`, `SetRowHeight` |
| Sort and filter | `SortRange`, `FilterByCellValue`, `ClearFilter`, `ClearAllFilters`, `ReapplyFilters` |
| Rules and names | `AddConditionalFormat`, `ClearConditionalFormats`, `AddDataValidation`, `RemoveDataValidation`, `AddDefinedName`, `RemoveDefinedName` |
| Links and charts | `AddHyperlink`, `RemoveHyperlink`, `InsertChart`, `DeleteChart` |
| Rows, columns, sheets | `InsertRow`, `InsertColumn`, `InsertSheet`, `DeleteSheet`, `DuplicateSheet`, `MoveSheet`, `ProtectSheet`, `UnprotectSheet` |
| Workbook | `Calculate`, `Refresh`, `Undo`, `Redo`, `Save` |


## See also

* [Getting started with WebMCP](./getting-started) shows how to enable registration and inspect the tools for one instance.
* [Configure WebMCP tools](./tools) shows how to enable, disable, or rename a command from the lists above.
* [Security and best practices](./security) explains how to limit write tools before an agent can call them.
