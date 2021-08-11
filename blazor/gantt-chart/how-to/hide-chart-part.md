---
layout: post
title: Hide chart part in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about Hide chart part in Syncfusion Blazor Gantt Chart component and more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Hide chart part in Blazor Gantt Chart Component

In the Gantt Chart component, you can hide chart part and display Tree Grid part alone by setting the value of `GanttSplitterSettings.View` property as `Grid`.

```cshtml
@using Syncfusion.Blazor.Gantt
    <SfGantt DataSource="@TaskCollection" Height="230px" Width="700px">
        <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" Child="SubTasks">
        </GanttTaskFields>
        <GanttSplitterSettings View="SplitterView.Grid"></GanttSplitterSettings>
    </SfGantt>

@code{
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
        public string Duration { get; set; }
        public int Progress { get; set; }
        public List<TaskData> SubTasks { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() {
        new TaskData() {
            TaskId = 1,
            TaskName = "Project initiation",
            StartDate = new DateTime(2019, 04, 02),
            EndDate = new DateTime(2019, 04, 21),
            SubTasks = (new List <TaskData> () {
                new TaskData() {
                    TaskId = 2,
                    TaskName = "Identify Site location",
                    StartDate = new DateTime(2019, 04, 02),
                    Duration = "4",
                    Progress = 50,
                },
                new TaskData() {
                    TaskId = 3,
                    TaskName = "Perform soil test",
                    StartDate = new DateTime(2019, 04, 02),
                    Duration = "4",
                    Progress = 50,
                }
            })
        }
    };

        return Tasks;
    }
}
```

The following screenshot shows the output of the above code snippet.

![Alt text](../images/hiding-chart-part.png)