---
layout: post
title: Data Markers in Blazor Gantt Chart Component | Syncfusion
description: Learn here all about Data Markers in the Syncfusion Blazor Gantt Chart component and its properties for customization.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Data Markers in Blazor Gantt Chart Component

Data markers are a set of events used to represent the schedule events for a task. Data markers are defined in data source as array of objects, and this value is mapped to the Gantt Chart component using the `GanttTaskFields.Indicators` property. You can represent more than one data marker in a task.

Data markers can be defined using the following properties:

* `Date` : Defines the date of indicator.
* `IconClass` : Defines the icon class of indicator.
* `Name` : Defines the name of indicator.
* `Tooltip` : Defines the tooltip of indicator.

> Data Marker `Tooltip` will be rendered only if tooltip property has value.

The following code example demonstrates how to implement data markers in the Gantt chart.

```cshtml
@using Syncfusion.Blazor.Gantt
<SfGantt @ref="Gantt" DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration"
        Progress="Progress" ParentID="ParentId" Indicators="Indicators">
    </GanttTaskFields>
</SfGantt>

@code{
    public SfGantt<TaskData> Gantt;
    public List<TaskData> TaskCollection { get; set; }
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }
    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
        public List<GanttIndicator> Indicators { get; set; }
    }
    public class GanttIndicator
    {
        public string Name { get; set; }
        public string IconClass { get; set; }
        public DateTime Date { get; set; }
        public string Tooltip { get; set; }
    }
    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() {
            new TaskData() {
                TaskId = 1,
                TaskName = "Project initiation",
                StartDate = new DateTime(2019, 03, 27),
                EndDate = new DateTime(2019, 04, 06),
                Indicators=(new List<GanttIndicator>()
                {
                    new GanttIndicator()
                    {
                        Name="product",
                        IconClass="e-btn-icon e-notes-info e-icons e-icon-left e-gantt e-notes-info::before",
                        Date=new DateTime(2019, 04, 11),
                        Tooltip="sales"
                    }
                })
            },
            new TaskData() {
                TaskId = 2,
                TaskName = "Identify Site location",
                StartDate = new DateTime(2019, 04, 02),
                Duration = "2",
                Progress = 30,
                ParentId = 1,
                Indicators=(new List<GanttIndicator>()
                {
                    new GanttIndicator()
                    {
                        Name="customer",
                        IconClass="e-btn-icon e-notes-info e-icons e-icon-left e-gantt e-notes-info::before",
                        Date=new DateTime(2019, 04, 14),
                        Tooltip="people"
                    },
                    new GanttIndicator()
                    {
                        Name="product",
                        IconClass="e-btn-icon e-notes-info e-icons e-icon-left e-gantt e-notes-info::before",
                        Date=new DateTime(2019, 04, 17),
                        Tooltip="sales"
                    }
                })
            },
            new TaskData() {
                TaskId = 3,
                TaskName = "Perform soil test",
                StartDate = new DateTime(2019, 04, 02),
                EndDate = new DateTime(2019, 04, 06),
                Duration = "5",
                Progress = 40,
                ParentId = 1,
            },
            new TaskData() {
                TaskId = 4,
                TaskName = "Soil test approval",
                StartDate = new DateTime(2019, 04, 02),
                Duration = "5",
                EndDate = new DateTime(2019, 04, 06),
                Progress = 30,
                ParentId = 1
            },
            new TaskData() {
                TaskId = 5,
                TaskName = "Project initiation",
                StartDate = new DateTime(2019, 04, 02),
                EndDate = new DateTime(2019, 04, 08),
            },
            new TaskData() {
                TaskId = 6,
                TaskName = "Identify Site location",
                StartDate = new DateTime(2019, 04, 02),
                Duration = "2",
                Progress = 30,
                ParentId = 5,

            },
            new TaskData() {
                TaskId = 7,
                TaskName = "Perform soil test",
                StartDate = new DateTime(2019, 04, 02),
                Duration = "4",
                Progress = 40,
                ParentId = 5,
            },
            new TaskData() {
                TaskId = 8,
                TaskName = "Soil test approval",
                StartDate = new DateTime(2019, 04, 02),
                Duration = "5",
                Progress = 30,
                ParentId = 5
            },
        };
        return Tasks;
    }
}
```

> You can refer to our [Blazor Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Gantt Chart example](https://blazor.syncfusion.com/demos/gantt-chart/default-functionalities?theme=bootstrap4) to knows how to render and configure the gantt.