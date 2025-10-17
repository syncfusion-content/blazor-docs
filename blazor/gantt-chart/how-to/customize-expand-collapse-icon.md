---
layout: post
title: Expand and Collapse Icon in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about Customize Expand and Collapse Icon in Syncfusion Blazor Gantt Chart component and more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Customize Expand and Collapse Icon in Blazor Gantt Chart Component

In the Gantt Chart component, you can customize the expand and collapse icons by overriding the default icon classes `.e-treegridexpand` and `.e-treegridcollapse` with the `content` property. The below sample code demonstrates the customization of the expand and collapse icons.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt DataSource="@TaskCollection" Height="450px" Width="1000px" HighlightWeekends="true"
         Toolbar="@(new List<string>(){ "Add", "Edit", "Update", "Delete", "Cancel", "ExpandAll", "CollapseAll", "Indent", "Outdent"})"
         AllowSelection="true" TreeColumnIndex="1"
         ProjectStartDate="@ProjectStart" ProjectEndDate="@ProjectEnd">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
                     Dependency="Predecessor" ParentID="ParentID"></GanttTaskFields>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true" ShowDeleteConfirmDialog="true"></GanttEditSettings>
    <GanttColumns>
        <GanttColumn Field="TaskID" Width="100"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Job Name" Width="250" ClipMode="Syncfusion.Blazor.Grids.ClipMode.EllipsisWithTooltip"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date"></GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration"></GanttColumn>
        <GanttColumn Field="Progress" HeaderText="Progress"></GanttColumn>
        <GanttColumn Field="Predecessor" HeaderText="Dependency"></GanttColumn>
    </GanttColumns>
    <GanttLabelSettings LeftLabel="TaskName" TValue="GanttData.TaskData">
    </GanttLabelSettings>
    <GanttSplitterSettings Position="40%"></GanttSplitterSettings>
</SfGantt>

@code {
    private DateTime ProjectStart = new DateTime(2023, 04, 03);
    private DateTime ProjectEnd = new DateTime(2023, 04, 28);

    private List<GanttData.TaskData> TaskCollection { get; set; }

    protected override void OnInitialized()
    {
        this.TaskCollection = GanttData.EditingData().ToList();
    }

    public class GanttData
    {
        public class TaskData
        {
            public int TaskID { get; set; }
            public string TaskName { get; set; }
            public DateTime? StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string Duration { get; set; }
            public int Progress { get; set; }
            public string Predecessor { get; set; }
            public string Notes { get; set; }
            public int? ParentID { get; set; }
        }

        public static List<TaskData> EditingData()
        {
            List<TaskData> Tasks = new List<TaskData>()
            {
                new TaskData() { TaskID = 1, TaskName = "Product concept", StartDate = new DateTime(2023, 04, 03), EndDate = new DateTime(2023, 04, 07), Duration = "5 days", Progress = 30 },
                new TaskData() { TaskID = 2, TaskName = "Defining the product usage", StartDate = new DateTime(2023, 04, 03), EndDate = new DateTime(2023, 04, 05), Duration = "3", Progress = 30, ParentID = 1 },
                new TaskData() { TaskID = 3, TaskName = "Defining the target audience", StartDate = new DateTime(2023, 04, 03), EndDate = new DateTime(2023, 04, 05), Duration = "3", Progress = 40, ParentID = 1 },
                new TaskData() { TaskID = 4, TaskName = "Prepare product sketch and notes", StartDate = new DateTime(2023, 04, 06), EndDate = new DateTime(2023, 04, 07), Duration = "2", Progress = 30, ParentID = 1, Predecessor = "2" },
                new TaskData() { TaskID = 5, TaskName = "Concept approval", StartDate = new DateTime(2023, 04, 07), EndDate = new DateTime(2023, 04, 07), Duration = "0", Progress = 0, Predecessor = "3,4" },
                new TaskData() { TaskID = 6, TaskName = "Market research", StartDate = new DateTime(2023, 04, 10), EndDate = new DateTime(2023, 04, 14), Duration = "5", Progress = 30 },
                new TaskData() { TaskID = 7, TaskName = "Demand analysis", StartDate = new DateTime(2023, 04, 10), EndDate = new DateTime(2023, 04, 12), Duration = "3", Progress = 40, ParentID = 6 },
                new TaskData() { TaskID = 8, TaskName = "Customer strength", StartDate = new DateTime(2023, 04, 10), EndDate = new DateTime(2023, 04, 12), Duration = "3", Progress = 30, ParentID = 7, Predecessor = "5" },
                new TaskData() { TaskID = 9, TaskName = "Market opportunity analysis", StartDate = new DateTime(2023, 04, 10), EndDate = new DateTime(2023, 04, 12), Duration = "3", ParentID = 7, Predecessor = "5" },
                new TaskData() { TaskID = 10, TaskName = "Competitor analysis", StartDate = new DateTime(2023, 04, 13), EndDate = new DateTime(2023, 04, 14), Duration = "2", Progress = 30, ParentID = 6, Predecessor = "7,8" },
                new TaskData() { TaskID = 11, TaskName = "Product strength analysis", StartDate = new DateTime(2023, 04, 13), EndDate = new DateTime(2023, 04, 14), Duration = "2", Progress = 40, ParentID = 6, Predecessor = "9" },
                new TaskData() { TaskID = 12, TaskName = "Research completed", StartDate = new DateTime(2023, 04, 14), EndDate = new DateTime(2023, 04, 14), Duration = "0", Progress = 0, ParentID = 6, Predecessor = "10,11" },
                new TaskData() { TaskID = 13, TaskName = "Product design and development", StartDate = new DateTime(2023, 04, 17), EndDate = new DateTime(2023, 04, 28), Duration = "10", Progress = 30 },
                new TaskData() { TaskID = 14, TaskName = "Functionality design", StartDate = new DateTime(2023, 04, 17), EndDate = new DateTime(2023, 04, 19), Duration = "3", Progress = 30, ParentID = 13, Predecessor = "12" },
                new TaskData() { TaskID = 15, TaskName = "Quality design", StartDate = new DateTime(2023, 04, 17), EndDate = new DateTime(2023, 04, 19), Duration = "3", Progress = 40, ParentID = 13, Predecessor = "12" },
                new TaskData() { TaskID = 16, TaskName = "Define reliability", StartDate = new DateTime(2023, 04, 20), EndDate = new DateTime(2023, 04, 21), Duration = "2", Progress = 30, ParentID = 13, Predecessor = "15" },
                new TaskData() { TaskID = 17, TaskName = "Identifying raw materials", StartDate = new DateTime(2023, 04, 20), EndDate = new DateTime(2023, 04, 21), Duration = "2", Progress = 0, ParentID = 13, Predecessor = "15" },
                new TaskData() { TaskID = 18, TaskName = "Define cost plan", StartDate = new DateTime(2023, 04, 24), EndDate = new DateTime(2023, 04, 26), Duration = "3", Progress = 30, ParentID = 13, Predecessor = "17" },
                new TaskData() { TaskID = 19, TaskName = "Define manufacturing cost", StartDate = new DateTime(2023, 04, 24), EndDate = new DateTime(2023, 04, 26), Duration = "3", Progress = 40, ParentID = 18 },
                new TaskData() { TaskID = 20, TaskName = "Define selling cost", StartDate = new DateTime(2023, 04, 24), EndDate = new DateTime(2023, 04, 26), Duration = "3", Progress = 30, ParentID = 18, Predecessor = "17" }
            };
            return Tasks;
        }
    }
}

<style>
    .e-gantt .e-treegridcollapse::before {
        content: '\e81b' !important
    }

    .e-gantt .e-treegridexpand::before {
        content: '\e768' !important
    }
</style>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNBeWjNigogyJNzl?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5" %}