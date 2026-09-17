---
layout: post
title: Supported Syncfusion A2UI Components for Blazor | Syncfusion
description: Reference guide to all Syncfusion A2UI for Blazor adapters, grouped by category with A2UI catalog IDs and brief descriptions.
control: Supported Components
platform: Blazor
documentation: ug
domainurl: ##DomainURL##
---

# Supported Syncfusion A2UI Components

The Syncfusion A2UI for Blazor package ships a catalog of **64 Syncfusion EJ2 Blazor adapters** in `Syncfusion.Blazor.A2UI.SyncfusionComponents.SyncfusionComponentFactory`. When the 18 A2UI primitives from `Syncfusion.Blazor.A2UI.Catalog.BasicComponentFactory` are included, the catalog exposes **82 schemas in a single** `"syncfusion-a2ui-catalog"` for the agent to pick from.

Every adapter implements the A2UI v0.9 component contract, so an agent can stream any of them as part of a `createSurface` or `updateComponents` message and have it rendered by `<SyncfusionA2UIProvider>` with no extra wiring. The widgets come from the Syncfusion EJ2 Blazor library (e.g. `Syncfusion.Blazor.Grid`, `Syncfusion.Blazor.Charts`) and inherit the components' built-in theming, accessibility, and event surface.

This page is the reference. Use it when you need to know the exact adapter id to put inside an A2UI component payload, or when you want to see the full shape of the catalog at a glance. The tutorial lives on [Getting Started](./getting-started).

<!-- The Syncfusion widgets are gated by the `USE_SYNCFUSION_COMPONENTS` compile constant. -->
N> Component ids shown below follow the pattern `Syncfusion<ComponentName>` and are published as part of the `0.1.0-beta.0` Blazor renderer. The factory list is the source of truth — if your build of the package has been extended locally, the order and entries below may not match. The first stable release locks both the catalog id (`"syncfusion-a2ui-catalog"`) and the schema names.

## Data Grid & Trees

Tabular grid components for displaying, editing, and navigating structured row data.

| Component | Description |
| --- | --- |
| `SyncfusionDataGrid` | Paged, sortable, filterable, editable, virtualised data grid (SfGrid). |
| `SyncfusionTreeGrid` | Hierarchical grid with parent/child mapping (SfTreeGrid). |
| `SyncfusionSpreadsheet` | Excel-like grid with formulas, cell formatting, sheets, named ranges, and selection (SfSpreadsheet). |

## Charts & Visualization

Charting, mapping, and diagram components for rendering quantitative, geographic, and node-link visuals.

| Component | Description |
| --- | --- |
| `SyncfusionChart` | 30+ chart types — line, bar, area, spline, stacking, radar, polar, bubble, range, hilo, waterfall, histogram (SfChart). |
| `Syncfusion3DChart` | 3D column / bar variants (SfChart3D). |
| `SyncfusionHeatMap` | Heat map for density, matrix, or risk visualization (SfHeatMap). |
| `SyncfusionDiagram` | Node-link diagramming — org charts, flowcharts, network maps, BPMN, and related shapes (SfDiagram). |
| `SyncfusionMaps` | Geographic / choropleth map with markers, bubbles, legends, and geographic data layers (SfMaps). |
| `SyncfusionKanban` | Kanban board with swimlanes, columns, and WIP limits (SfKanban). |
| `SyncfusionQueryBuilder` | Visual query builder with rule groups, conditions, and SQL preview (SfQueryBuilder). |

## Scheduling & Planning

Components for visualizing appointments and tasks across calendar and timeline views.

| Component | Description |
| --- | --- |
| `SyncfusionScheduler` | Day, week, work-week, month, and agenda views with appointments, resources, and recurrence (SfScheduler). |
| `SyncfusionGanttChart` | Gantt view with tasks, dependencies, baselines, and resource scheduling (SfGantt). |

## Navigation & Layout

Components that help users move through an app's sections, views, and pages, plus layout containers.

| Component | Description |
| --- | --- |
| `SyncfusionAccordion` | Vertically stacked collapsible items (SfAccordion). |
| `SyncfusionAppBar` | Top application bar with title, leading icon, and overflow menu (SfAppBar). |
| `SyncfusionTabs` | Horizontal / vertical tab strip with closable and lazy-loaded panes (SfTabs). |
| `SyncfusionStepper` | Linear / non-linear progress indicator for multi-step flows (SfStepper). |
| `SyncfusionToolbar` | Toolbar of buttons, toggles, and inputs grouped by purpose (SfToolbar). |
| `SyncfusionBreadcrumb` | Hierarchical breadcrumb of links for the current location (SfBreadcrumb). |
| `SyncfusionMenu` | Vertical / horizontal menu with sub-menus, icons, and shortcuts (SfMenu). |
| `SyncfusionPager` | Numeric / previous-next pager for list or grid pagination (SfPager). |
| `SyncfusionCard` | Container with header, body, and footer blocks for grouped content (SfCard). |
| `SyncfusionTreeView` | Hierarchical tree view with expand/collapse, drag and drop, and selection (SfTreeView). |
| `SyncfusionListView` | Vertical list of items with template, grouping, and selection (SfListView). |

## Text Inputs

Single-line and constrained-format input controls for capturing short text and numeric values.

| Component | Description |
| --- | --- |
| `SyncfusionTextBox` | Single-line text input with validation, icons, and floating label (SfTextBox). |
| `SyncfusionTextArea` | Multi-line text input with resizing and character counter (SfTextArea). |
| `SyncfusionNumericTextBox` | Numeric input with min, max, step, and format options (SfNumericTextBox). |
| `SyncfusionMaskedTextBox` | Masked input for fixed-format strings — phone, zip, serial, etc. (SfMaskedTextBox). |

N>The previous draft listed `SyncfusionOTPInput` here. It has moved to **Specialized Inputs** below — see the corresponding table.

## Specialized Inputs

Selection, rating, and content-capture controls beyond plain text.

| Component | Description |
| --- | --- |
| `SyncfusionColorPicker` | Color selection with palette, RGB / HSL / HEX modes, and opacity (SfColorPicker). |
| `SyncfusionSlider` | Single-thumb or range slider with tick marks and tooltip (SfSlider). |
| `SyncfusionOTPInput` | One-time-passcode input with separate boxes per digit (SfOTPInput). |
| `SyncfusionRating` | Star / symbol rating input with precision and read-only mode (SfRating). |
| `SyncfusionSignature` | Signature pad with brush and color (SfSignature). |
| `SyncfusionSpeechToText` | Browser microphone capture that streams recognized text into the DataModel (SfSpeechToText). |
| `SyncfusionUploader` | Drag-and-drop file uploader with chunked upload and progress (SfUploader). |
| `SyncfusionChip` (a.k.a. `SyncfusionChipList`) | Tag / pill list for selections, filters, or removable tokens (SfChip). |

N>The factory registration uses the id `SyncfusionChip`. The alias `SyncfusionChipList` from earlier drafts was renamed when the chip and chip-list widgets merged; pick `SyncfusionChip` in new payloads.

## Date & Time

Date and time picker components for selecting single values, ranges, or times in standard formats.

| Component | Description |
| --- | --- |
| `SyncfusionCalendar` | Month, year, and decade view for picking a single date (SfCalendar). |
| `SyncfusionDatePicker` | Text input + popup calendar for selecting a single date (SfDatePicker). |
| `SyncfusionDateRangePicker` | Two linked date inputs for selecting a start and end date (SfDateRangePicker). |
| `SyncfusionDateTimePicker` | Date picker with editable time spinner (SfDateTimePicker). |
| `SyncfusionTimePicker` | Time-only picker with hour, minute, second, and format options (SfTimePicker). |

## Buttons & Action Triggers

Clickable and action-triggering button components for invoking commands, menu, or asynchronous operations.

| Component | Description |
| --- | --- |
| `SyncfusionButton` | Standard click button with icon, primary / secondary styling, and toggle mode (SfButton). |
| `SyncfusionDropDownButton` | Button whose click opens a menu of actions (SfDropDownButton). |
| `SyncfusionSplitButton` | Primary action plus an attached dropdown of secondary actions (SfSplitButton). |
| `SyncfusionProgressButton` | Button that shows a spinner / progress fill while an async action runs (SfProgressButton). |
| `SyncfusionSpeedDial` | Floating action button that expands into a stack of related actions (SfSpeedDial). |
| `SyncfusionFloatingActionButton` | Material-style FAB anchored to a corner with a single primary action (SfFab). |

## Feedback & Notifications

Inline messaging and overlay components for surfacing loading, status, notifications, and contextual counts.

| Component | Description |
| --- | --- |
| `SyncfusionMessage` | Inline informational, warning, error, or success banner (SfMessage). |
| `SyncfusionToast` | Auto-dismissing notification toast with severity and actions (SfToast). |
| `SyncfusionSpinner` | Indeterminate or determinate progress spinner overlay (SfSpinner). |
| `SyncfusionSkeleton` | Placeholder shimmer for content that is still loading (SfSkeleton). |
| `SyncfusionBadge` | Numeric or text badge overlaid on a target element (SfBadge). |
| `SyncfusionAvatar` | Initials / image / icon avatar with shape and size variants (SfAvatar). |

## Editors

Rich-content and inline editors for authoring formatted text, blocks, and quick field updates.

| Component | Description |
| --- | --- |
| `SyncfusionRichTextEditor` | WYSIWYG rich-text editor with toolbar, formatting, and paste-from-Word (SfRichTextEditor). |
| `SyncfusionBlockEditor` | Block-based content editor for structured rich content (SfBlockEditor). |
| `SyncfusionInPlaceEditor` | Click-to-edit inline editor with built-in input modes (SfInPlaceEditor). |

## Selection Controls

Mutually exclusive and toggleable boolean selections that pair with `data/checkbox` bindings.

| Component | Description |
| --- | --- |
| `SyncfusionCheckBox` | Tri-state boolean control for binary on / off choices (SfCheckBox). |
| `SyncfusionRadioButton` | Mutually exclusive single-choice control with optional label (SfRadioButton). |
| `SyncfusionSwitch` | On / off toggle for boolean settings (SfSwitch). |

## Dropdowns & Pickers

Selection controls for picking one or many values from lists with search, grouping, and tagging support.

| Component | Description |
| --- | --- |
| `SyncfusionDropDownList` | Single-select dropdown with search, grouping, and templating (SfDropDownList). |
| `SyncfusionComboBox` | Editable, searchable, single-select combobox with autocomplete (SfComboBox). |
| `SyncfusionMultiSelect` | Multi-value selection with chips, tagging, and search (SfMultiSelect). |

## File & Barcode

Generators for QR, Data Matrix, and 1D barcodes used for identification, tracking, and scanning workflows.

| Component | Description |
| --- | --- |
| `SyncfusionQRCode` | QR code generator with size, error-correction, and color options (SfQRCode). |
| `SyncfusionDataMatrix` | Data Matrix (ECC200) 2D barcode generator (SfDataMatrix). |
| `SyncfusionBarcodeGenerator` | 1D barcode generator — Code128, Code39, EAN, UPC, etc. (SfBarcodeGenerator). |

## Document Authoring & Review

Components for composing, viewing, and reviewing full documents and PDFs in the browser.

| Component | Description |
| --- | --- |
| `SyncfusionDocumentEditorContainer` | Full-featured Word-compatible document editor with ribbon, comments, track changes, and layout (SfDocumentEditor). |
| `SyncfusionPdfViewer` | PDF viewer with paging, search, zoom, and form filling (SfPdfViewer). |

## A2UI primitives (HTML fallbacks)

These 18 IDs are registered by the base `BlazorSyncfusionCatalog`. They are not Syncfusion widgets — each is a Blazor-rendered-fragment implementation in `Syncfusion.Blazor.A2UI.Components` — but they ship in the same package and can be referenced from any agent surface, including ones that opted out of Syncfusion widgets via `<UseSyncfusionComponents>false</UseSyncfusionComponents>`.

| Catalog id | A2UI primitive | Renderer |
| --- | --- | --- |
| `Text` | Display string with optional heading variant/level. | `Text.razor` |
| `Image` | Inline image. | `Image.razor` |
| `Icon` | Material symbol or `{svgPath}`. | `Icon.razor` |
| `Video` | Inline `<video controls>`. | `Video.razor` |
| `AudioPlayer` | Inline `<audio controls>`. | `AudioPlayer.razor` |
| `Row` | Flex row container; children come from `props.children`. | `Row.razor` |
| `Column` | Flex column container; children come from `props.children`. | `Column.razor` |
| `List` | Scrollable vertical/horizontal list. | `List.razor` |
| `Card` | Custom container with inner child. | `Card.razor` |
| `Tabs` | Tab strip; tabs have `{title, child: id[]}`. | `Tabs.razor` |
| `Modal` | Trigger + content via two component ids and an `open` flag. | `Modal.razor` |
| `Divider` | Horizontal/vertical rule. | `Divider.razor` |
| `Button` | Label + optional `action` for adapter-side dispatch. | `Button.razor` |
| `TextField` | Label + dynamic value + checks. | `TextField.razor` |
| `CheckBox` | Label + bool value + checks. | `CheckBox.razor` |
| `ChoicePicker` | Options + dynamic value + `variant` / `displayStyle` / `filterable`. | `ChoicePicker.razor` |
| `Slider` | Label + dynamic value + min/max + checks. | `Slider.razor` |
| `DateTimeInput` | Dynamic value + `enableDate` / `enableTime` + min/max + label + checks. | `DateTimeInput.razor` |

N>The Syncfusion-prefixed equivalents above (`SyncfusionButton`, `SyncfusionCheckBox`, `SyncfusionSlider`, `SyncfusionTabs`) are the Syncfusion-widget-backed adapters in `SyncfusionComponentFactory`; the bare-id versions in this table are HTML-fallback adapters in `BasicComponentFactory`. Pick one of the two — do not emit both in the same `createSurface`.

## Counts at a glance

| Source | Adapter count | Notes |
| --- | --- | --- |
| `SyncfusionComponentFactory.AllSchemas` | **64** | Syncfusion EJ2 Blazor adapters. |
| `BasicComponentFactory.All` | **18** | A2UI v0.9 primitives as HTML render fragments. |
| Total in a `BlazorSyncfusionCatalog.Combine(...)` registry | **82** | Ready for `MessageProcessor`. |

## See also

- [Overview](./overview)
- [Getting Started](./getting-started)
- [AI Integration](./ai-integration)
- [A2UI v0.9 protocol](https://a2ui.org/specification/v0.9-a2ui/)