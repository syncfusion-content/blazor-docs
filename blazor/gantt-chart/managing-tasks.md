---
layout: post
title: Managing Tasks in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about Managing Tasks in Syncfusion Blazor Gantt Chart component and more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Managing Tasks in Blazor Gantt Chart Component

Task management is a crucial feature in the [Blazor Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart), enabling the dynamic insertion, deletion, and updating of tasks. This functionality enhances project planning and tracking by allowing project managers to modify task details directly within the Gantt Chart.

Example Scenario: In a software development project, a project manager can easily add new tasks, update existing ones, or remove completed tasks as the project progresses. This ensures the Gantt Chart always reflects the current state of the project.

### Primary key column

To manage tasks and perform CRUD operations, it is necessary to define the primary key column. Set the `GanttColumn.IsPrimaryKey` property to `true` for the relevant column in the Gantt Chart configuration.

 ```cshtml
 
<GanttColumn Field="CustomId" HeaderText="Custom ID" IsPrimaryKey="true"></GanttColumn>
  
```

## Troubleshoot: Editing only works when a primary key column is defined

The editing feature in the Blazor Gantt Chart requires a primary key column to enable CRUD (Create, Read, Update, and Delete) operations. When defining columns using the `GanttColumns` property, at least one column must be marked as the primary key to ensure data consistency and proper task identification.
By default, the `Id` column serves as the primary key if it is defined.
If the Id column is not defined, set the `IsPrimaryKey` property to true for any one of the columns specified in the `GanttColumns` property.

## See Also

For more detailed information and advanced usage scenarios, refer to the Syncfusion Blazor Gantt Chart documentation.

* [Adding New Tasks](adding-new-tasks.md) - Learn how to add new tasks to your Gantt Chart using the toolbar, context menu, or programmatically.
* [Editing Tasks](editing-tasks.md) - Explore various methods for editing tasks, including cell editing, dialog editing, and taskbar editing. Discover how to customize the edit dialog and manage task dependencies.
* [Deleting Tasks](deleting-tasks.md) - Understand how to delete tasks via the toolbar, programmatically, and enable delete confirmation.

For more detailed information and advanced usage scenarios, refer to the [Syncfusion Blazor Gantt Chart documentation](https://blazor.syncfusion.com/documentation/gantt-chart/getting-started).