---
layout: post
title: Index in Blazor Gantt Chart Component | Syncfusion
description: Explore the overview of the Syncfusion Blazor Gantt Chart component, covering key concepts, functionalities, and usage guidelines.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Index in Blazor Gantt component

The Gantt Chart in Blazor offers a project management interface similar to Microsoft Project, designed for scheduling and managing projects. It provides an intuitive way to visually manage tasks, their relationships, and project resources.

## Key features

**1. Data & Handling** 
Supports flexible data integration and efficient processing through structured field mapping, remote data connectivity, and performance-optimized rendering for large datasets.
   * [Data Binding](https://blazor.syncfusion.com/documentation/gantt-chart/data-binding): The Gantt component supports both **hierarchical** and **self-referential** JSON structures. It also integrates seamlessly with remote data sources using the DataManager component, enabling RESTful API connections, OData, and other services. This flexibility allows dynamic data loading. 
   * [Task Field Mapping](https://blazor.syncfusion.com/documentation/gantt-chart/getting-started-with-web-app#binding-gantt-chart-with-data-and-mapping-task-fields): Maps specific data fields to Gantt chart properties using the `GanttTaskFields` configuration. Required fields include id, name, and startDate, with optional fields like duration, progress, and parentID to define task hierarchy and scheduling.
   * [Large Data](https://blazor.syncfusion.com/documentation/gantt-chart/data-binding#load-child-on-demand): Optimized for large datasets using **virtualization** and **load-on-demand** techniques. Improves performance by rendering only visible rows and timeline cells during scroll operations.

**2. Task Management** 
Provides comprehensive tools for creating, scheduling, and modifying tasks, including support for dependencies,  milestones, and dynamic updates to reflect real-time project changes.
  * [Tasks](https://blazor.syncfusion.com/documentation/gantt-chart/scheduling-tasks): Supports both scheduled and unscheduled tasks. Scheduled tasks include start and end dates, durations, and dependencies, with flexible duration units such as days, hours, or minutes. Unscheduled tasks can be defined with only one or none of these values, allowing placeholders or milestones to be represented without fixed dates. This setup enables precise control over task planning and visibility within the project timeline.
  * [Milestones](https://blazor.syncfusion.com/documentation/gantt-chart/scheduling-tasks#milestone): Represents tasks with zero duration that require both a start and end date. Milestones are used to mark key events in the project and are included in the timeline, impacting scheduling and progress tracking.
  * [Split Tasks](https://blazor.syncfusion.com/documentation/gantt-chart/split-task#split-and-merge-tasks-dynamically) : Allows tasks to be divided into segments with gaps, useful for modeling interruptions or phased work.
  * [Editing](https://blazor.syncfusion.com/documentation/gantt-chart/editing-tasks): Task details can be modified using different methods such as cell editing, dialog forms, and taskbar adjustments. Tasks can be changed by entering new values or by dragging and resizing directly on the timeline. 
  * [Row Drag/Drop](https://blazor.syncfusion.com/documentation/gantt-chart/resource-view#taskbar-drag-and-drop-between-resources): Allows tasks to be reordered or moved to a different position within the task hierarchy using drag-and-drop actions. 
  * [Dependencies](https://blazor.syncfusion.com/documentation/gantt-chart/task-dependencies): Defines relationships between tasks to control their sequence and timing. Supports standard dependency types such as Finish-to-Start (FS), Start-to-Finish (SF), Start-to-Start (SS), and Finish-to-Finish (FF). These relationships help maintain logical task flow and ensure accurate scheduling.
  * [Critical Path](https://blazor.syncfusion.com/documentation/gantt-chart/criticalpath): Identifies and highlights tasks that directly affect the overall project completion timeline, aiding in risk and delay analysis.
  * [Auto-Scheduling](https://blazor.syncfusion.com/documentation/gantt-chart/scheduling-tasks#automatically-scheduled-tasks): Automatically adjusts task start and end dates based on dependencies, constraints, working hours, holidays, and weekends. When enabled, parent tasks are scheduled according to the earliest start and latest end dates of their child tasks. Any updates to child tasks will automatically reflect in the parent task’s schedule and progress.

**3. Timeline** 
Enables time-based planning through configurable views, scalable timelines, and working time settings, supporting precise scheduling across various time units and calendar structures. 
  * [Views](https://blazor.syncfusion.com/documentation/gantt-chart/resources): Provides task visualization from different perspectives, including project-focused and resource-focused views. Helps in analyzing task progress, resource usage, and allocation based on the selected context.
  * [Timeline](https://blazor.syncfusion.com/documentation/gantt-chart/time-line): Displays the project duration using time units such as minutes, days, or years. Supports single or dual-tier layouts, with each cell representing a specific time unit and format for scheduling tasks.
  * [Work Hours](https://blazor.syncfusion.com/documentation/gantt-chart/scheduling-tasks#working-time-range): Defines daily working time ranges for accurate task scheduling. 
  * [Workweek](https://blazor.syncfusion.com/documentation/gantt-chart/scheduling-tasks#weekend-or-non-working-days):Configures which weekdays are considered working and which are non-working. This setup influences task planning and progress calculations.
  * [Non-Working Time](https://blazor.syncfusion.com/documentation/gantt-chart/scheduling-tasks#weekend-or-non-working-days): Excludes specific hours or days from scheduling calculations. 
  * [Holidays](https://blazor.syncfusion.com/documentation/gantt-chart/holidays): Defines non-working dates within the project timeline to reflect organizational calendars. These dates are excluded from task scheduling and progress calculations.
  * [Timezone](https://blazor.syncfusion.com/documentation/gantt-chart/timezone): Configures task scheduling based on a specific time zone. By default, it aligns with the system time zone, but can be set to follow any defined time zone to ensure accurate timeline alignment across different regions.
  * [Zooming](https://blazor.syncfusion.com/documentation/gantt-chart/zooming): Adjusts the timeline scale by modifying cell width and switching between time units. Supports viewing task schedules across various time ranges, from minute-level detail to long-term planning.
 
**4. Visualization** 
Supports customizable visual elements for task representation, including taskbars, indicators, event markers, and timeline templates, enabling clear tracking and styling through themes and layout configurations.
  * [Taskbars](https://blazor.syncfusion.com/documentation/gantt-chart/taskbar): Displays various task types including scheduled, unscheduled, split, and milestone. Supports visual enhancements like baselines, tooltips, and interactive drag-and-drop. 
  * [Event Markers](https://blazor.syncfusion.com/documentation/gantt-chart/event-markers): Adds vertical indicators to highlight specific dates such as milestones or deadlines. 
  * [Indicators](https://blazor.syncfusion.com/documentation/gantt-chart/data-markers): Shows visual cues like icons, flags, or badges to represent task status or priority.
  * [Templates](https://blazor.syncfusion.com/documentation/gantt-chart/taskbar#tooltip-template): Enables customization of taskbar tooltips using `GanttTooltipSettings.TaskbarTemplate`, allowing display of specific task details in a user-defined format when hovering over tasks.
  * [Timeline Template](https://blazor.syncfusion.com/documentation/gantt-chart/time-line#template): Allows customization of timeline cells for enhanced visual representation.
  * [Themes](https://blazor.syncfusion.com/documentation/appearance/theme-studio#common-variables): Supports multiple design systems including Fluent, Tailwind, Bootstrap, and Material. Theme Studio enables branding and style customization.

**5. Grid Setup** 
Defines the tabular structure of the Gantt chart, allowing customization of columns, rows, and selection behavior to support readable layouts and interactive data handling.
  * [Columns](https://blazor.syncfusion.com/documentation/gantt-chart/columns):  Defines the structure and layout of the grid by specifying which task fields are displayed. Supports reordering and resizing to allow users to adjust column positions and widths. Templates can be used to customize both cell and header content for advanced formatting. Includes support for WBS columns to represent hierarchical task numbering and frozen columns to keep key fields visible during horizontal scrolling. Column rendering is optimized for performance, and a column chooser is available to control visibility dynamically.
  * [Rows](https://blazor.syncfusion.com/documentation/gantt-chart/rows): Allows customization of row appearance, including styling and height adjustments to suit layout and readability requirements.
  * [Selection](https://blazor.syncfusion.com/documentation/gantt-chart/selection): Provides functionality for selecting rows or individual cells within the grid. Supports both single and multiple selection modes.

**6. Resources** 
Handles resource planning and tracking through effort-based work mapping and allocation management, including detection of overallocation across personnel and assets.
  * [Work Mapping](https://blazor.syncfusion.com/documentation/gantt-chart/work): Maps effort units to tasks using the `work` field, allowing precise control over resource allocation and planning based on assigned hours or workload.
  * [Allocation](https://blazor.syncfusion.com/documentation/gantt-chart/resource-view#resource-overallocation): Resources such as personnel, equipment, and materials can be assigned to tasks. If a resource is given more work than its available capacity for a day, it is marked as over allocation. This helps maintain balanced workloads and prevents scheduling conflicts.

**7. Interaction** 
Enables user-driven control through filtering, toolbar actions, drag-and-drop, context menus, and keyboard navigation, supporting efficient task manipulation and grid operations.
  * [Filtering](https://blazor.syncfusion.com/documentation/gantt-chart/filtering):  Helps organize and focus task data using column Menu filters, Excel-style filtering, and toolbar search. These options make it easier to view specific tasks or values within the Gantt chart. 
  * [Toolbar](https://blazor.syncfusion.com/documentation/gantt-chart/tool-bar): Includes built-in and customizable command buttons for performing various actions related to task and chart management.
  * [Drag and Drop](https://blazor.syncfusion.com/documentation/gantt-chart/drag-and-drop): Allows tasks and rows to be moved interactively for reordering and rescheduling within the Gantt chart.
  * [Context Menu](https://blazor.syncfusion.com/documentation/gantt-chart/context-menu): Enables quick access to task and column operations through right-click interaction. Menu options vary based on the selected element, such as task rows, column headers, or chart areas.
  * [Keyboard](https://blazor.syncfusion.com/documentation/gantt-chart/accessibility#keyboard-navigation): Enables efficient interaction through keyboard shortcuts for navigating tasks, editing values, and selecting rows or cells within the Gantt chart.

**8. Performance**
Optimizes rendering and responsiveness through virtual scrolling, loading animations, and read-only configurations for handling large datasets effectively.
  * [Virtual Scrolling](https://blazor.syncfusion.com/documentation/gantt-chart/virtualization): Enhances rendering efficiency by loading only the visible rows during scroll operations, which significantly improves responsiveness when handling large datasets.
  * [Shimmer Effect](https://ej2.syncfusion.com/angular/documentation/gantt/loading-animation): Displays a loading animation while data is being fetched or rendered. 

**9. Globalization**
Supports internationalization and accessibility through localization, right-to-left layout rendering, and compliance with accessibility standards like WCAG and ADA.
  * [Localization](https://blazor.syncfusion.com/documentation/gantt-chart/globalization#localization): Automatically adjusts date formats, currencies, and textual labels based on the selected language and regional settings, using built-in internationalization support.  
  * [RTL](https://blazor.syncfusion.com/documentation/gantt-chart/globalization#right-to-left-rtl): Supports right-to-left layout rendering for languages such as Arabic, ensuring proper alignment and readability across UI components.  
  * [Accessibility](https://blazor.syncfusion.com/documentation/gantt-chart/accessibility): Complies with WCAG 2.2, Section 508, and ADA standards. Includes ARIA attributes and screen reader compatibility.

**10. Export & Events**
Enables structured data export to Excel, CSV, and PDF formats, and provides event hooks for customizing chart behavior during rendering, editing, and user interactions.
  * **Export:**  
    * [Excel and CSV](https://blazor.syncfusion.com/documentation/gantt-chart/excel-export): Enables exporting Gantt chart data to Excel and CSV formats, simplifying structured data handling for reporting and offline analysis.  
    * [PDF](https://blazor.syncfusion.com/documentation/gantt-chart/pdf-export): Allows exporting the chart as a PDF document, with support for single-page layout to generate compact and printable visual summaries.
  * [Event Hooks](https://blazor.syncfusion.com/documentation/gantt-chart/events): Provides lifecycle events that enable customization of chart behavior during rendering, editing, and user interactions (e.g., dataBound, taskbarEdited).

