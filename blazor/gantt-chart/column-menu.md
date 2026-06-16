---
layout: post
title: 	Column Menu in Blazor Gantt Chart Component | Syncfusion
description: Learn how to enable sorting, filtering, and autofit using the column menu in the Syncfusion Blazor Gantt Chart.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Column Menu in Blazor Gantt Chart Component

The column menu in the Blazor Gantt component offers built-in actions including sorting, filtering, column chooser, and autofit. It appears when the column header icon is clicked.

To enable this feature, set [ShowColumnMenu](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ShowColumnMenu) to **true** in the Gantt configuration. Also enable [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AllowSorting), [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AllowFiltering), and [AllowResizing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AllowResizing) to support the corresponding actions.

The following built-in column menu items are available:

| Item | Description |
|------|-------------|
| Sort Ascending | Sort the current column in ascending order. |
| Sort Descending | Sort the current column in descending order. |
| Auto Fit | Auto fit the current column. |
| Auto Fit All | Auto fit all columns. |
| Column Chooser | Choose column visibility. |
| Filter | Displays filtering options based on [FilterSettings.FilterType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttFilterSettings.html#Syncfusion_Blazor_Gantt_GanttFilterSettings_FilterType). |

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px" AllowResizing="true" ShowColumnMenu="true" AllowFiltering="true" AllowSorting="true">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId"></GanttTaskFields>
</SfGantt>

@code {
    public List<TaskData> TaskCollection { get; set; }

    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
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

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 21) },
            new TaskData() { TaskId = 2, TaskName = "Identify site location", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 09), Progress = 40, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 21) },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 30, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 40, ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 04, 07), Duration = "0", Progress = 30, ParentId = 5 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNBdjHiTUMjNVLQk?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

> **Note**: Disable the column menu for a specific column by setting [GanttColumn.ShowColumnMenu](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html#Syncfusion_Blazor_Gantt_GanttColumn_ShowColumnMenu) to **false**.

## See also

- [Accessibility in Blazor Gantt Chart](https://blazor.syncfusion.com/documentation/gantt-chart/accessibility)
- [Blazor Gantt Chart Feature Tour](https://www.syncfusion.com/blazor-components/blazor-gantt-chart)
- [Blazor Gantt Chart Example](https://blazor.syncfusion.com/demos/gantt-chart/default-functionalities?theme=bootstrap5)