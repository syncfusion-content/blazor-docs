---
layout: post
title: Data Markers in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about Data Markers in Syncfusion Blazor Gantt Chart component and much more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Data Markers in Blazor Gantt Chart Component

[Data markers](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttIndicator.html) are a set of events used to represent the schedule events for a task. Data markers are defined in data source as array of objects, and this value is mapped to the Gantt Chart component using the `GanttTaskFields.Indicators` property. You can represent more than one data marker in a task.

Data markers can be defined using the following properties:

* `Date` : Defines the date of indicator.
* `IconClass` : Defines the icon class of indicator.
* `Name` : Defines the name of indicator.
* `Tooltip` : Defines the tooltip of indicator.

N> Data Marker `Tooltip` will be rendered only if tooltip property has value.

The following code example demonstrates how to implement data markers in the Gantt chart.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}


@using Syncfusion.Blazor.Gantt
<SfGantt @ref="Gantt" DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration"
                     Progress="Progress" ParentID="ParentID" Indicators="Indicators">
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
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentID { get; set; }
        public List<GanttIndicator> Indicators { get; set; }
    }
   
    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 10), Indicators=(new List<GanttIndicator>()
            {
                    new GanttIndicator() { Name="product", IconClass="e-btn-icon e-notes-info e-icons e-icon-left e-gantt e-notes-info::before", Date=new DateTime(2022, 01, 11), Tooltip="sales"}
                })
            },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "2", Progress = 30, ParentID = 1, Indicators=(new List<GanttIndicator>()
            {
                    new GanttIndicator(){ Name="customer", IconClass="e-btn-icon e-notes-info e-icons e-icon-left e-gantt e-notes-info::before", Date=new DateTime(2022, 01, 11), Tooltip="people" },
                    new GanttIndicator(){ Name="product", IconClass="e-btn-icon e-notes-info e-icons e-icon-left e-gantt e-notes-info::before", Date=new DateTime(2022, 01, 8), Tooltip="sales" }
                })
            },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 10), Duration = "5", Progress = 40, ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "5", EndDate = new DateTime(2022, 01, 05), Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 07) },
            new TaskData() { TaskID = 6, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "2", Progress = 30, ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentID = 5 },
            new TaskData() { TaskID = 8, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "5", Progress = 30, ParentID = 5 },
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtBIMjZOUHePgDUE?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> You can refer to our [Blazor Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Gantt Chart example](https://blazor.syncfusion.com/demos/gantt-chart/default-functionalities?theme=bootstrap5) to know how to render and configure the Gantt.