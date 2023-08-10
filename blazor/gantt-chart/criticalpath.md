---
layout: post
title: Critical Path in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about critical path in Syncfusion Blazor Gantt Chart component and much more details.
platform: Blazor
component: Gantt Chart
documentation: ug
---

# Critical Path in Blazor Gantt Chart component

The critical path in a project is indicated by a single task or a series of tasks. If a task in critical path is delayed, the entire project will be delayed. A task is considered to be critical if any delay to this task would affect the project end date.

The critical path can be enabled in Gantt by using the built-in toolbar button or [EnableCriticalPath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_EnableCriticalPath) property.

The following code example shows how to display the critical path in the Gantt control:

```cshtml
@using Syncfusion.Blazor.Gantt
<SfGantt DataSource="@TaskCollection" EnableCriticalPath Toolbar="@(new List<string>() { "Add", "Cancel", "Delete", "Edit","CriticalPath" })" Height="450px" Width="900px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate"
                     Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true">
    </GanttEditSettings>
</SfGantt>

@code{
    private List<TaskData> TaskCollection { get; set; }
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
    }

    private static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentId = 1, },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentId = 5, },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentId = 5, },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentId = 5, }
        };
        return Tasks;
    }
}
```
![Blazor Gantt Chart with Critical Path](images/blazor-gantt-chart-critical-path.png)
<!-- {% previewsample "https://blazorplayground.syncfusion.com/embed/VZBAXcBjWdxxCvVg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %} -->

## Critical Path Settings in Gantt Chart Component

The critical path settings in the Gantt Chart component determine the default slack value and validate it. Here is an example of how to add slack value to the Gantt Chart component.

Slack is a measure of how many days a task can be delayed without affecting the project's completion. By default, tasks with zero or negative slack values are critical, while tasks with positive slack values are non-critical. If a task's end date is the same as the project's end date, the slack value is 0, and the task is considered critical.

You can change the default behavior of critical tasks by using the slackValue property of `GanttCriticalPathSettings`. This property defines how many days a task can be delayed before it is considered critical. For instance, in the following code example, tasks with two days of slack are shown on the critical path, so potential issues can be detected earlier.

By adjusting the slackValue, you can control which tasks are critical and ensure that potential issues are identified and addressed in a timely manner.

```cshtml
@using Syncfusion.Blazor.Gantt
<SfGantt DataSource="@TaskCollection" EnableCriticalPath Toolbar="@(new List<string>() { "Add", "Cancel", "Delete", "Edit","CriticalPath" })" Height="450px" Width="900px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate"
                     Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true">
    </GanttEditSettings>
    <GanttCriticalPathSettings SlackValue="2" ></GanttCriticalPathSettings>
</SfGantt>

@code{
    private List<TaskData> TaskCollection { get; set; }
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
    }

    private static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentId = 1, },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentId = 5, },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "2", Progress = 40, ParentId = 5, },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentId = 5, }
        };
        return Tasks;
    }
}
```
![Critical Path with slack value](images/blazor-gantt-chart-critical-path-with-slack-value.png)
<!-- {% previewsample "https://blazorplayground.syncfusion.com/embed/hNrADGLNCRwYxGye?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %} -->

## Customize taskbar in critical path

The taskbar in critical path can be customized by using [QueryChartRowInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_QueryChartRowInfo) event. The [GanttTaskModel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.QueryChartRowInfoEventArgs-1.html#Syncfusion_Blazor_Gantt_QueryChartRowInfoEventArgs_1_GanttTaskModel) in the event argument is used to retrieve taskbar information.

The following code example shows how to customize the critical path taskbar in the Gantt control:

```cshtml
@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" EnableCriticalPath="true" Toolbar="@(new List<string>() { "Add", "Cancel", "Delete", "Edit","CriticalPath" })" Height="450px" Width="900px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate"
                     Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true">
    </GanttEditSettings>
    <GanttEvents QueryChartRowInfo="QueryChartRowInfo" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    private List<TaskData> TaskCollection { get; set; }
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    public void QueryChartRowInfo(QueryChartRowInfoEventArgs<TaskData> args)
    {
        if(args.GanttTaskModel.IsCritical && !args.GanttTaskModel.HasChildRecords)
        {
            args.Row.AddClass(new string[] { "taskbar-critical progress-critical" });
        }
    }
    
    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
        
    }

    private static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 7), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentId = 1, },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 7), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentId = 5, },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentId = 5, },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentId = 5, }
        };
        return Tasks;
    }
}
<style>
    .taskbar-critical .e-gantt-child-taskbar {
        background-color: #06DFF9 !Important;
        outline: 1px solid #06DFF9 !Important;
    }
    .progress-critical .e-gantt-child-progressbar {
        background-color: #049cae !Important;
    }
</style>
```
![Customize taskbar](images/blazor-gantt-chart-critical-path-customize-taskbar.png)
<!-- {% previewsample "https://blazorplayground.syncfusion.com/embed/VDLKDGhZCHYtznzW?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %} -->
