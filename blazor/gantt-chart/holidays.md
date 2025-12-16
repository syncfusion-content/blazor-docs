---
layout: post
title: Holidays in Blazor Gantt Chart Component | Syncfusion
description: Learn how to configure holidays in the Syncfusion Blazor Gantt Chart component for accurate task scheduling with non-working days.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Holidays in Blazor Gantt Chart Component

The Blazor Gantt Chart component supports holidays to define non-working days, such as national holidays or company closures, that impact task scheduling and project timelines. Holidays override regular working time settings like [WorkWeek](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_WorkWeek) or [IncludeWeekend](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_IncludeWeekend), ensuring tasks do not progress during these periods. In the timeline, holidays appear as highlighted backgrounds with descriptive labels, creating visible gaps in taskbars to reflect scheduling adjustments. Custom CSS classes allow distinct styling for different holiday types (e.g., national vs. company holidays), enhancing visual clarity. Properly configured holidays ensure accurate duration calculations, dependency adjustments, and critical path analysis, aligning project timelines with resource availability and regional requirements.

## Understanding holiday effects on tasks

Holidays adjust task scheduling to reflect non-working periods:
- **Duration adjustments**: Task durations exclude holidays, extending end dates. For example, a task starting December 20, 2024, skips a December 25-26 holiday, adjusting its completion to account for these days.
- **Dependency management**: Successor tasks shift to maintain relationships (e.g., FS), ensuring no work occurs during holidays.
- **Critical path integration**: Holidays impact slack calculations when using [EnableCriticalPath](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_EnableCriticalPath), as tasks delayed by holidays may become critical.
- **Resource allocation**: Holidays reduce resource availability, pausing task progress during these periods.

The [ProjectStartDate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ProjectStartDate) and [ProjectEndDate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ProjectEndDate) properties provide context for scheduling, ensuring holidays align with the project timeline.

## Configure holidays

Holidays are defined using the [GanttHolidays](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttHolidays.html) property, which accepts an array of holiday objects specifying dates, labels, and styling. Holidays take precedence over settings like `WorkWeek` or `IncludeWeekend`, ensuring tasks do not progress during these periods.

**Holiday configuration properties**
- `From`: Sets the start date of the holiday (e.g., `new Date('2024-12-25')`).
- `To`: Defines the end date for multi-day holidays (optional for single-day holidays).
- `Label`: Provides a descriptive name (e.g., “Christmas Day”) displayed in the timeline.
- `CssClass`: Applies custom CSS classes for styling holiday appearances.

The following example configures single and multi-day holidays:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt DataSource="@TaskCollection" Height="450px" Width="900px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate"
             Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttHolidays>
        <GanttHoliday From="@Holiday1" To="@Holiday2" Label="Public holidays"
              CssClass="e-custom-holiday"></GanttHoliday>
        <GanttHoliday From="@Holiday3" To="@Holiday4" Label="Public holiday"
              CssClass="e-custom-holiday"></GanttHoliday>
    </GanttHolidays>
</SfGantt>
@code{
    private DateTime Holiday1 = new DateTime(2022, 04, 11);
    private DateTime Holiday2 = new DateTime(2022, 04, 12);
    private DateTime Holiday3 = new DateTime(2022, 04, 01);
    private DateTime Holiday4 = new DateTime(2022, 04, 01);
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

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 08), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 04, 08), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 40, ParentID = 5 },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0", Progress = 30, ParentID = 5 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjryCZgZfnCCBAeu?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> You can refer to our [Blazor Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Gantt Chart example](https://blazor.syncfusion.com/demos/gantt-chart/default-functionalities) to know how to render and configure the Gantt.