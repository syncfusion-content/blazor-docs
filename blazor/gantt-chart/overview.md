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

* [**Data sources**](./data-binding/) - The Blazor Gantt Chart component can be integrated with various remote API service for data binding by using the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) or an enumerable collection of objects by using the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_DataSource) property.
* [**Large data binding**](./data-binding/) - Optimize performance when dealing with extensive datasets by initially loading only parent records. Child records are rendered dynamically upon expansion, reducing initial load times and improving user experience with large project structures.
* [**Editing**](./managing-tasks/): Directly edit task details such as duration, start and end dates, and dependencies within the Gantt Chart. Use the Edit dialog for structured input or interact with taskbars for a more visual editing approach.
* [**Task dependencies**](./task-dependencies/): Define and manage task relationships using various dependency types, including finish-to-start, start-to-finish, start-to-start, and finish-to-finish. This feature helps in accurately modeling project schedules and dependencies.
* [**Customizable timeline**](./time-line/): Adjust the timeline view to show time scales ranging from minutes to decades. The timeline can be customized to display specific intervals and custom text, and can be formatted in either one-tier or two-tier layouts.
* [**Taskbars**](./scheduling-tasks/): Customize the appearance of taskbars, including support for unscheduled tasks and the ability to display baselines. Taskbars visually represent the schedule and progress of tasks.
* [**Critical path**](./criticalpath/):  Identify the sequence of critical tasks that determine the project's finish date. Delays in tasks on the critical path will directly impact the overall project schedule, allowing for better focus on crucial tasks.
* [**Columns**](./columns/): Customize the grid columns to display specific information and add custom columns as needed. This allows for tailored views and enhanced data presentation.
* [**Resources**](./resources/): Allocate and manage resources such as personnel, equipment, and materials. This feature helps in tracking resource availability and ensuring that tasks are assigned appropriately.
* [**Filtering**](./filtering/): Filter tasks and data using individual column filters and a toolbar search box. This functionality helps users quickly locate and manage specific tasks within the Gantt Chart.
* [**Toolbar**](./tool-bar/): Use the toolbar to manage various aspects of the Gantt Chart, including data operations and chart settings. The toolbar provides quick access to essential functions and controls.
* [**Rows**](./rows/): Customize and add rows to the Gantt Chart both at initialization and dynamically. This feature allows for flexible data presentation and organization of tasks.
* [**Selection**](./selection/): Customize how rows and cells are selected within the Gantt Chart, both at initialization and dynamically. This enables precise selection and interaction with tasks.
* [**Data markers or indicators**](./data-markers/): Display visual indicators and flags alongside taskbars and labels to highlight important data points or statuses.
* [**Event markers**](./event-markers/): Use event markers to emphasize significant days or milestones within the project timeline, aiding in tracking important events and deadlines.
* [**Holidays**](./holidays/): Define and manage non-working days (holidays) within the project calendar. This ensures that project schedules account for holidays and non-working periods.
