---
layout: post
title: Common APIs across Blazor Data Components | Syncfusion®
description: Learn the events, properties, and CSS classes that are shared across the Blazor DataGrid, TreeGrid, Gantt Chart, Pivot Table, and Scheduler components.
platform: Blazor
control: Common
documentation: ug
---

# Common APIs across Blazor Data Components

The Syncfusion® Blazor data components, including the [DataGrid](https://www.syncfusion.com/blazor-components/blazor-datagrid), [TreeGrid](https://www.syncfusion.com/blazor-components/blazor-tree-grid), [Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart), [Pivot Table](https://www.syncfusion.com/blazor-components/blazor-pivot-table), and [Scheduler](https://www.syncfusion.com/blazor-components/blazor-scheduler), share a common set of events, properties, and CSS conventions for component lifecycle management, action handling, appearance customization, and theming. Understanding these shared APIs helps you work more efficiently across components, apply configurations consistently, and quickly become familiar with other data components in the Syncfusion Blazor suite. 

Event handlers are defined through a single events child component for each control, such as `GridEvents`, `TreeGridEvents`, `GanttEvents`, `PivotViewEvents`, or `ScheduleEvents`, and require the corresponding TValue type to be specified.

## Common events

The following events are raised for the component lifecycle and for data-oriented actions such as sorting, filtering, searching, and editing.

| Description | DataGrid | TreeGrid | Gantt Chart | Pivot Table | Scheduler |
| --- | --- | --- | --- | --- | --- |
| Event when data finishes loading | [OnDataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnDataBound) | [OnDataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_OnDataBound) | [DataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_DataBound) | [DataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_DataBound) | [DataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEvents-1.html#Syncfusion_Blazor_Schedule_ScheduleEvents_1_DataBound) |
| Event before an action happens (editable, cancellable) | [OnActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnActionBegin) | [OnActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_OnActionBegin) | [OnActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_OnActionBegin) | [OnActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_OnActionBegin) | [OnActionBegin](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEvents-1.html#Syncfusion_Blazor_Schedule_ScheduleEvents_1_OnActionBegin) |
| Event after an action completes | [OnActionComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_OnActionComplete) | [OnActionComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_OnActionComplete) | [OnActionComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_OnActionComplete) | [OnActionComplete](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_OnActionComplete) | [ActionCompleted](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEvents-1.html#Syncfusion_Blazor_Schedule_ScheduleEvents_1_ActionCompleted) |
| Event when component is created | [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_Created) | [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_Created) | [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_Created) | [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_Created) | [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEvents-1.html#Syncfusion_Blazor_Schedule_ScheduleEvents_1_Created) |
| Event when component is destroyed | [Destroyed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridEvents-1.html#Syncfusion_Blazor_Grids_GridEvents_1_Destroyed) | [Destroyed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_Destroyed) | [Destroyed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_Destroyed) | [Destroyed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.PivotViewEvents-1.html#Syncfusion_Blazor_PivotView_PivotViewEvents_1_Destroyed) | [Destroyed](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEvents-1.html#Syncfusion_Blazor_Schedule_ScheduleEvents_1_Destroyed) |

`OnActionBegin` is raised before an action is performed and can be cancelled through its `Cancel` argument. The remaining events are raised after the corresponding lifecycle or action stage completes.

## Common properties

| Description | DataGrid | TreeGrid | Gantt Chart | Pivot Table | Scheduler |
| --- | --- | --- | --- | --- | --- |
| Property for custom CSS class | [CssClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_CssClass) | `CssClass` | `CssClass` | `CssClass` | `CssClass` |
| Property for component height | [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Height) | [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_Height) | [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_Height) | [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_Height) | [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.SfSchedule-1.html#Syncfusion_Blazor_Schedule_SfSchedule_1_Height) |
| Property for component width | [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Width) | [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_Width) | [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_Width) | [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_Width) | [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.SfSchedule-1.html#Syncfusion_Blazor_Schedule_SfSchedule_1_Width) |
| Property for locale/culture | [Locale](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_Locale) | `Locale` | `Locale` | `Locale` | `Locale` |
| Property for right-to-left support | [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_EnableRtl) | [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_EnableRtl) | [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_EnableRtl) | [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_EnableRtl) | [EnableRtl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.SfSchedule-1.html#Syncfusion_Blazor_Schedule_SfSchedule_1_EnableRtl) |
| Property for tooltip template | [TooltipTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridTemplates.html#Syncfusion_Blazor_Grids_GridTemplates_TooltipTemplate) | `TooltipTemplate` | `TooltipTemplate` | `TooltipTemplate` | — |
| Property for data source | [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SfGrid-1.html#Syncfusion_Blazor_Grids_SfGrid_1_DataSource) | [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.SfTreeGrid-1.html#Syncfusion_Blazor_TreeGrid_SfTreeGrid_1_DataSource) | [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_DataSource) | [DataSourceSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.PivotView.SfPivotView-1.html#Syncfusion_Blazor_PivotView_SfPivotView_1_DataSourceSettings) | EventSettings.DataSource |

The DataGrid, TreeGrid, and Gantt Chart accept the data collection directly through the `DataSource` property. The Pivot Table binds data through `PivotViewDataSourceSettings`, and the Scheduler binds events through `ScheduleEventSettings`.

## Common CSS class prefixes

Each component's root element is rendered with a component-specific CSS class prefix, which can be used as the scope for style overrides.

| Description | DataGrid | TreeGrid | Gantt Chart | Pivot Table | Scheduler |
| --- | --- | --- | --- | --- | --- |
| CSS class prefix | `e-grid` | `e-treegrid` | `e-gantt` | `e-pivotview` | `e-schedule` |

To override styles only for a specific instance, combine the prefix with the class assigned through `CssClass` (for example, `.e-grid.custom-class .e-row { ... }`).

## See also

* [Events in Blazor DataGrid](https://help.syncfusion.com/grid-sdk/blazor/data-grid/events)
* [Events in Blazor TreeGrid](https://help.syncfusion.com/grid-sdk/blazor/tree-grid/events)
* [Events in Blazor Gantt Chart](https://help.syncfusion.com/gantt-sdk/blazor/gantt-chart/events)
* [Events in Blazor Pivot Table](https://help.syncfusion.com/grid-sdk/blazor/pivot-table/events)
* [Events in Blazor Scheduler](https://help.syncfusion.com/scheduler-sdk/blazor/schedule/events)
