---
layout: post
title: Critical Path in Blazor Gantt Chart Component | Syncfusion
description: Learn here all about Critical path in Syncfusion Blazor Gantt Chart component and much more details.
platform: Blazor
component: Gantt Chart
documentation: ug
---

# Critical Path in Blazor Gantt Chart component

The critical path represents the longest sequence of dependent tasks that determines the minimum project duration. Tasks on the critical path have zero or negative [SlackValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttCriticalPathSettings.html#Syncfusion_Blazor_Gantt_GanttCriticalPathSettings_SlackValue) (float), meaning any delay in these tasks directly impacts the overall project completion date. The Blazor Gantt Chart component automatically calculates and highlights critical tasks in red with emphasized dependency connector lines when the [EnableCriticalPath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_EnableCriticalPath) property is enabled. Critical path analysis helps identify which tasks require immediate attention and cannot be delayed without affecting project deadlines.

## Understanding critical path calculation

The component uses Critical Path Method (CPM) principles to identify critical tasks through a comprehensive calculation process that analyzes task dependencies, timing relationships, and slack values to determine which tasks have no scheduling flexibility. A task becomes critical when it has zero or negative slack, meaning any delay (even by a minute) shifts the entire project end date. This occurs because critical tasks are linked through dependencies, creating a chain reaction where delays propagate across the dependency network, ultimately affecting the project completion date.

**Project end date determination**: The calculation begins by determining the overall project end date. If the [ProjectEndDate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ProjectEndDate) property is provided, it uses that value as the project completion reference. If `ProjectEndDate` is not specified, the component automatically calculates the project end date by examining all task end dates in the data source to find the latest completion point. This reference point determines how much delay each task can tolerate without affecting project completion.

**Slack value calculation**: For each task, the component calculates slack by measuring the time difference between the task's end date and the project end date. Slack represents how much time a task can be delayed without affecting the project completion:
- **Zero slack**: The task must finish exactly on time. Any delay will push back the project end date, making it critical
- **Negative slack**: The task is already behind schedule or creates scheduling conflicts. This occurs when a task's end date is beyond the project end date, or when dependency relationships create impossible timing constraints.

**Parent-Child task relationships**: In projects with hierarchical tasks, the critical path calculation focuses on dependencies rather than the parent-child structure used for task organization. For example, if Task 1.1 (a child task) depends on Task 2 (a parent task), only the tasks directly linked by the dependency are evaluated for criticality based on their timing. A parent task like Task 2 being critical does not automatically make its child tasks (e.g., Task 2.1, Task 2.2) critical, nor does a critical child task imply a critical parent. The component evaluates each task’s slack independently, ensuring that only tasks with zero or negative slack, driven by their dependency constraints, are marked as critical. This distinction allows precise identification of critical tasks without conflating organizational hierarchy with scheduling dependencies.

**Dependency-based analysis**: The component analyzes different dependency relationship types to determine slack impacts:
- **Finish-to-Start**: When a predecessor task ends after its successor should start, negative slack results from the timing conflict
- **Start-to-Start**: When a predecessor starts after its successor should start, the component calculates negative slack based on scheduling impossibility  
- **Finish-to-Finish** and **Start-to-Finish**: These relationships can also produce negative slack when timing conflicts exist between connected tasks
- **Offset and scheduling mode handling**: When dependencies include time offsets (e.g., "+2 days" or "-1 hour"), the component adjusts slack calculations by factoring in the offset duration. The calculation differs for automatically scheduled versus manually scheduled tasks: automatic tasks use forward and backward pass algorithms to compute slack, while manual tasks compare their end dates directly against the project completion date.

**Progress consideration**: The component considers task completion progress. Only tasks with less than 100% progress can be marked as critical, since completed tasks cannot cause future delays. Tasks that end on or beyond the project end date automatically become critical regardless of their dependency relationships, as they directly determine the project completion timing.

## Critical path setup and configuration

The Critical Path feature in the Blazor Gantt component highlights tasks that directly impact the overall project completion date. To enable this functionality, ensure that the data source must contain tasks with valid start dates, end dates, and task dependencies properly mapped through the [Dependency](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTaskFields.html#Syncfusion_Blazor_Gantt_GanttTaskFields_Dependency) field in [TaskFields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTaskFields.html).

Enable critical path display by setting [EnableCriticalPath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_EnableCriticalPath) to **true**, or add the `CriticalPath` option to the [Toolbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_Toolbar) array to allow interactive toggling. The [GetCriticalTasks](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_Toolbar) method retrieves all tasks identified as critical at runtime.

The critical path recalculates automatically when task properties change, including start and end dates, duration modifications, dependency updates, or progress adjustments. This ensures the visualization remains accurate throughout project management workflows.

The following example demonstrates enabling critical path analysis:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt DataSource="@TaskCollection" EnableCriticalPath Toolbar="@(new List<string>() { "Add", "Cancel", "Delete", "Edit","CriticalPath" })" Height="450px" Width="900px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
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
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentID { get; set; }
    }

    private static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentID = 1, },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentID = 5, },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentID = 5, },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentID = 5, }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNByNksaVeNllBzB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Critical path settings in Gantt Chart Component

The critical path settings in the Gantt Chart component determine the default slack value and validate it. Here is an example of how to add slack value to the Gantt Chart component.

Slack is a measure of how many days a task can be delayed without affecting the project's completion. By default, tasks with zero or negative slack values are critical, while tasks with positive slack values are non-critical. If a task's end date is the same as the project's end date, the slack value is 0, and the task is considered critical.

You can change the default behavior of critical tasks by using the [SlackValue](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttCriticalPathSettings.html#Syncfusion_Blazor_Gantt_GanttCriticalPathSettings_SlackValue) property of [GanttCriticalPathSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttCriticalPathSettings.html). This property defines how many days a task can be delayed before it is considered critical. For instance, in the following code example, tasks with two days of slack are shown on the critical path, so potential issues can be detected earlier.

By adjusting the `SlackValue`, you can control which tasks are critical and ensure that potential issues are identified and addressed in a timely manner.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt DataSource="@TaskCollection" EnableCriticalPath Toolbar="@(new List<string>() { "Add", "Cancel", "Delete", "Edit","CriticalPath" })" Height="450px" Width="900px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate"
                     Duration="Duration" Progress="Progress" ParentID="ParentID">
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
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentID { get; set; }
    }

    private static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentID = 1, },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentID = 5, },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "2", Progress = 40, ParentID = 5, },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentID = 5, }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDBoXYiarSGbgGOX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customize taskbar in critical path

The taskbar in critical path can be customized by using [QueryChartRowInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_QueryChartRowInfo) event. The [GanttTaskModel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.QueryChartRowInfoEventArgs-1.html#Syncfusion_Blazor_Gantt_QueryChartRowInfoEventArgs_1_GanttTaskModel) in the event argument is used to retrieve taskbar information.

The following code snippet demonstrates how to customize the appearance of critical path taskbars in a Gantt Chart:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" EnableCriticalPath="true" Toolbar="@(new List<string>() { "Add", "Cancel", "Delete", "Edit", "CriticalPath" })" Height="450px" Width="900px">
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
        if (args.GanttTaskModel.IsCritical && !args.GanttTaskModel.HasChildRecords)
        {
            args.Row.AddClass(new string[] { "taskbar-critical progress-critical" });
        }
    }

    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
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

{% endhighlight %}
{% endtabs %}

![Customize taskbar](images/blazor-gantt-chart-critical-path-customize-taskbar.png)

>If the [ProjectEndDate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ProjectEndDate) property is set in the `SfGantt`, any task that ends on or after this date is considered critical. If the `ProjectEndDate` is not set, the maximum end date from the task records is used to determine which tasks are critical.