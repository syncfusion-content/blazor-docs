---
layout: post
title: Hide chart part in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about Hide chart part in Syncfusion Blazor Gantt Chart component and more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Hide Chart Part in Blazor Gantt Chart Component

In the Gantt Chart component, you can hide chart part and display Tree Grid part alone by setting the value of [GanttSplitterSettings.View](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttSplitterSettings.html#Syncfusion_Blazor_Gantt_GanttSplitterSettings_View) property as `Grid`.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
    <SfGantt DataSource="@TaskCollection" Height="230px" Width="700px">
        <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
        </GanttTaskFields>
        <GanttSplitterSettings View="SplitterView.Grid"></GanttSplitterSettings>
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
            List<TaskData> Tasks = new List<TaskData>() {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 07), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 50, ParentID = 1, },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 50, ParentID = 1, }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjVetkLHARucneHx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}