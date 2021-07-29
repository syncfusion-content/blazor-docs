---
layout: post
title: Baseline in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about Baseline in Syncfusion Blazor Gantt Chart component and much more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Baseline in Blazor Gantt Chart Component

The baseline feature enables users to view the deviation between the planned dates and actual dates of the tasks in a project. Baseline dates or planned dates of a task may or may not be same as the actual task dates. The baseline can be enabled by setting the `RenderBaseline` property to `true` and the baseline color can be changed using the `BaselineColor` property. To render the baseline, you should map the baseline start and end date values from the data source. This can be done using the `GanttTaskFields.BaselineStartDate` and `GanttTaskFields.BaselineEndDate` properties. The following code example shows how to enable a baseline in the Gantt Chart component.

```cshtml
@using Syncfusion.Blazor.Gantt
<SfGantt DataSource="@TaskCollection" RenderBaseline="true"
        ProjectStartDate="@ProjectStart" ProjectEndDate="@ProjectEnd" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate"
          Duration="Duration" Progress="Progress" Child="SubTasks" BaselineStartDate="BaselineStartDate"
          BaselineEndDate="BaselineEndDate">
    </GanttTaskFields>
</SfGantt>

@code{
    public DateTime ProjectStart = new DateTime(2019, 04, 01);
    public DateTime ProjectEnd = new DateTime(2019, 04, 30);
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
        public DateTime EndDate { get; set; }
        public DateTime BaselineStartDate { get; set; }
        public DateTime BaselineEndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public List<TaskData> SubTasks { get; set; }
    }

    public static List <TaskData> GetTaskCollection() {
    List <TaskData> Tasks = new List <TaskData> () {
        new TaskData() {
            TaskId = 1,
            TaskName = "Project initiation",
            StartDate = new DateTime(2019, 04, 02),
            EndDate = new DateTime(2019, 04, 21),
            SubTasks = (new List <TaskData> () {
                new TaskData() {
                    TaskId = 2,
                    TaskName = "Identify site location",
                    StartDate = new DateTime(2019, 04, 02),
                    BaselineStartDate = new DateTime(2019, 04, 02),
                    BaselineEndDate = new DateTime(2019, 04, 02),
                    Duration = "0",
                    Progress = 70
                },
                new TaskData() {
                    TaskId = 3,
                    TaskName = "Perform soil test",
                    StartDate = new DateTime(2019, 04, 02),
                    BaselineStartDate = new DateTime(2019, 04, 04),
                    BaselineEndDate = new DateTime(2019, 04, 09),
                    Duration = "8",
                    Progress = 50
                },
                new TaskData() {
                    TaskId = 4,
                    TaskName = "Soil test approval",
                    StartDate = new DateTime(2019, 04, 02),
                    BaselineStartDate = new DateTime(2019, 04, 08),
                    BaselineEndDate = new DateTime(2019, 04, 12),
                    Duration = "4",
                    Progress = 50
                },
            })
        },
        new TaskData() {
            TaskId = 5,
            TaskName = "Project estimation",
            StartDate = new DateTime(2019, 04, 02),
            EndDate = new DateTime(2019, 04, 21),
            SubTasks = (new List <TaskData> () {
                new TaskData() {
                    TaskId = 6,
                    TaskName = "Develop floor plan for estimation",
                    StartDate = new DateTime(2019, 04, 04),
                    BaselineStartDate = new DateTime(2019, 04, 08),
                    BaselineEndDate = new DateTime(2019, 04, 12),
                    Duration = "4",
                    Progress = 70
                },
                new TaskData() {
                    TaskId = 7,
                    TaskName = "List materials",
                    StartDate = new DateTime(2019, 04, 04),
                    BaselineStartDate = new DateTime(2019, 04, 02),
                    BaselineEndDate = new DateTime(2019, 04, 02),
                    Duration = "0",
                    Progress = 50
                },
            })
        }
    };

    return Tasks;
}
}
```

The following screenshot shows the baselines in Gantt Chart component.

![Alt text](images/baseline.png)

> You can refer to our [Blazor Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Gantt Chart example](https://blazor.syncfusion.com/demos/gantt-chart/default-functionalities?theme=bootstrap4) to knows how to render and configure the gantt.