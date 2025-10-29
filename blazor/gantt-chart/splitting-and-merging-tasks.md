---
layout: post
title: Splitting and merging tasks in Blazor Gantt Chart component | Syncfusion
description: Learn how to split and merge tasks in the Syncfusion Blazor Gantt Chart component for flexible task management in project timelines.
platform: Blazor
control: Splitting and merging tasks
documentation: ug
---

# Splitting and merging tasks in Angular Gantt component

Splitting and merging tasks in the Blazor Gantt Chart component enhances project management by allowing tasks to be divided into segments or recombined, representing breaks or continuous work periods. This feature enables dividing a task or pausing work when necessary, whether planned or unexpected, and adds dynamism to the timeline view for better visualization.

The divided parts of a taskbar are referred to as **segments**. Tasks can be split at load time using [GanttSegmentFields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttSegmentFields-2.html), ensuring segments fit within the task's start and end dates. Dynamic splitting is supported via the dialog's Segments tab or the context menu's Split Task option, which requires valid [GanttTaskFields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTaskFields.html) mappings.

Merging can be done using the context menu's Merge Task option or by dragging segments together in the UI. To enable these actions, set the [EnableContextMenu](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_EnableContextMenu) property to **true**. Tasks must have sufficient width relative to the timeline unit and must not be parent or milestone tasks. Avoid using split tasks with multi-taskbar features to maintain compatibility.

## Binding segments data source

In the Blazor Gantt Chart, the [GanttSegmentFields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttSegmentFields-2.html) component plays a vital role in managing segmented tasks. The [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttSegmentFields-2.html#Syncfusion_Blazor_Gantt_GanttSegmentFields_2_DataSource) property of `GanttSegmentFields` defines the segment data source collection.
This collection must be structured so that the [ForeignKey](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttSegmentFields-2.html#Syncfusion_Blazor_Gantt_GanttSegmentFields_2_ForeignKey) property of `GanttSegmentFields` and the [Id](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTaskFields.html#Syncfusion_Blazor_Gantt_GanttTaskFields_Id) property of [GanttTaskFields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTaskFields.html) form a foreign key relationship between the task collection `DataSource` and the segment collection `DataSource`.
Additionally, the start date, end date, and duration field mappings of the segment collection can be defined using the corresponding properties in `GanttSegmentFields`.

The following code snippet demonstrates how to visualize task segments in the Gantt Chart.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt TValue="TaskData" DataSource="@taskCollection" Height="450px" Width="100%" TreeColumnIndex="1" RowHeight="37" ProjectStartDate="projectStart" ProjectEndDate="projectEnd">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID" Dependency="Predecessor">
    </GanttTaskFields>
    <GanttSegmentFields PrimaryKey="Id" ForeignKey="TaskID" StartDate="SegmentStartDate" EndDate="SegmentEndDate" Duration="SegmentDuration" TValue="TaskData" TSegments="SegmentModel" DataSource="segmentCollection"></GanttSegmentFields>
    <GanttLabelSettings LeftLabel="TaskName" TValue="TaskData"></GanttLabelSettings>
    <GanttColumns>
        <GanttColumn Field="TaskID" Width="100" Visible="false"></GanttColumn>
        <GanttColumn Field="TaskName" Width="250" ClipMode="Syncfusion.Blazor.Grids.ClipMode.EllipsisWithTooltip"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date"></GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration"></GanttColumn>
        <GanttColumn Field="Progress" HeaderText="Progress"></GanttColumn>
        <GanttColumn Field="Predecessor" HeaderText="Dependency"></GanttColumn>
    </GanttColumns>
</SfGantt>

@code {
    private DateTime projectStart = new DateTime(2022, 03, 23);
    private DateTime projectEnd = new DateTime(2022, 05, 10);
    private List<TaskData> taskCollection { get; set; }
    private List<SegmentModel> segmentCollection { get; set; }
    protected override void OnInitialized()
    {
        this.taskCollection = GetTaskCollection();
        this.segmentCollection = GetSegmentCollection();
    }
    public class SegmentModel
    {
        public int Id { get; set; }
        public int TaskID { get; set; }
        public DateTime SegmentStartDate { get; set; }
        public DateTime SegmentEndDate { get; set; }
        public string SegmentDuration { get; set; }
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
        public string Predecessor { get; set; }
    }
    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 03, 29), EndDate = new DateTime(2022, 04, 19), Duration="4" },
            new TaskData() { TaskID = 2, TaskName = "Identify site location", StartDate = new DateTime(2022, 03, 29), Progress = 30, ParentID = 1, Duration="8", },
            new TaskData() { TaskID = 3, TaskName = "Site analyze", StartDate = new DateTime(2022, 03, 29),  Progress = 50, ParentID = 1, Duration="8"},
            new TaskData() { TaskID = 4, TaskName = "Perform soil test", StartDate = new DateTime(2022, 03, 29), ParentID = 1, Duration="5", Predecessor="2FS", Progress=40, },
            new TaskData() { TaskID = 5, TaskName = "Soil test approval", StartDate = new DateTime(2022, 03, 29), Duration="4", Progress = 30 },
            new TaskData() { TaskID = 6, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 08), Duration="8", Progress=40, ParentID=1 },
            new TaskData() { TaskID = 7, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 03, 29), Duration = "0", Progress = 30, ParentID = 5, Predecessor= "4FS" },
            new TaskData() { TaskID = 8, TaskName = "List materials", StartDate = new DateTime(2022, 04, 01), Duration = "6", Progress = 30, ParentID = 5 },
            new TaskData() { TaskID = 9, TaskName = "Estimation approval",Progress=30, StartDate = new DateTime(2022, 04, 01), Duration = "4", ParentID = 5, Predecessor="8FS" },
            new TaskData() { TaskID = 10, TaskName = "Building approval", StartDate = new DateTime(2022, 04, 12), Duration = "5", ParentID = 5 },
            new TaskData() { TaskID = 11, TaskName = "Construction initiation", StartDate = new DateTime(2022, 04, 01), Duration = "5", Progress=40 },
            new TaskData() { TaskID = 12, TaskName = "Ground floor initiation", StartDate = new DateTime(2022, 04, 05), Duration = "5", ParentID = 11, Progress=40},
            new TaskData() { TaskID = 13, TaskName = "First floor initiation", StartDate = new DateTime(2022, 04, 05), Duration = "7",ParentID = 11, Progress=40},
            new TaskData() { TaskID = 14, TaskName = "Electric work initiation", StartDate = new DateTime(2022, 04, 01), Duration = "5", ParentID = 11, Progress=40, },
            new TaskData() { TaskID = 15, TaskName = "Plumbing work", StartDate = new DateTime(2022, 04, 02), Duration = "5", ParentID = 11, Progress=40 },
       };
        return Tasks;
    }
    private List<SegmentModel> GetSegmentCollection()
    {
        List<SegmentModel> segments = new List<SegmentModel>();
        segments.Add(new SegmentModel() { Id = 1, TaskID = 2, SegmentStartDate = new DateTime(2022, 04, 01), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 2, TaskID = 2, SegmentStartDate = new DateTime(2022, 03, 29), SegmentEndDate = new DateTime(2022, 03, 31) });
        segments.Add(new SegmentModel() { Id = 3, TaskID = 3, SegmentStartDate = new DateTime(2022, 04, 01), SegmentDuration = "2" });
        segments.Add(new SegmentModel() { Id = 4, TaskID = 3, SegmentStartDate = new DateTime(2022, 03, 29), SegmentEndDate = new DateTime(2022, 03, 31) });
        segments.Add(new SegmentModel() { Id = 5, TaskID = 3, SegmentStartDate = new DateTime(2022, 04, 04), SegmentDuration = "3" });
        segments.Add(new SegmentModel() { Id = 6, TaskID = 4, SegmentStartDate = new DateTime(2022, 04, 01), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 7, TaskID = 4, SegmentStartDate = new DateTime(2022, 03, 29), SegmentEndDate = new DateTime(2022, 03, 31) });
        segments.Add(new SegmentModel() { Id = 8, TaskID = 8, SegmentStartDate = new DateTime(2022, 04, 01), SegmentEndDate = new DateTime(2022, 04, 03) });
        segments.Add(new SegmentModel() { Id = 9, TaskID = 8, SegmentStartDate = new DateTime(2022, 04, 05), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 10, TaskID = 9, SegmentStartDate = new DateTime(2022, 03, 29), SegmentEndDate = new DateTime(2022, 03, 31) });
        segments.Add(new SegmentModel() { Id = 11, TaskID = 9, SegmentStartDate = new DateTime(2022, 04, 01), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 12, TaskID = 12, SegmentStartDate = new DateTime(2022, 04, 05), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 13, TaskID = 12, SegmentStartDate = new DateTime(2022, 04, 07), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 14, TaskID = 14, SegmentStartDate = new DateTime(2022, 04, 01), SegmentEndDate = new DateTime(2022, 04, 02) });
        segments.Add(new SegmentModel() { Id = 15, TaskID = 14, SegmentStartDate = new DateTime(2022, 04, 04), SegmentDuration = "2" });
        return segments;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZLeWDtuqMccqoYp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Split and merge tasks dynamically

In the Gantt Chart, dynamic splitting and merging of segments can be enabled by setting the [AllowTaskbarEditing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEditSettings.html#Syncfusion_Blazor_Gantt_GanttEditSettings_AllowTaskbarEditing) and [AllowEditing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEditSettings.html#Syncfusion_Blazor_Gantt_GanttEditSettings_AllowEditing) properties to true in the [GanttEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEditSettings.html) component. Tasks or segments can be dynamically split into multiple segments, and existing segments can be merged. Merging can be performed by dragging a segment and dropping it over another segment of the same task. Additionally, split and merge actions can be performed in the Gantt Chart using the following three methods:

### Through context menu

To split and merge tasks using the context menu, set the [EnableContextMenu](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_EnableContextMenu) property to **true** in the `SfGantt` component. Once enabled, context menu items such as **Split Task** and **Merge Task** allow taskbars to be split and merged directly from the UI.

Right-clicking on a taskbar or segment element in the Gantt Chart displays the context menu with the **Split Task** option. Selecting this option divides the taskbar or segment at the timeline cell where the right-click occurred.

Segmented taskbars can be merged using the **Merge Task** context menu item. Its sub-menu includes **Right** and **Left** options. Selecting **Right** merges the current segment with the one to its right, while selecting **Left** merges it with the segment to its left.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt TValue="TaskData" EnableContextMenu="true" DataSource="@taskCollection" Height="450px" Width="100%" TreeColumnIndex="1" Toolbar="@(new List<Object>() { "Add", "Cancel", "Update" , "Delete", "Edit", "CollapseAll", "ExpandAll", "ZoomIn", "ZoomOut", "ZoomToFit" })" RowHeight="37" ProjectStartDate="projectStart" ProjectEndDate="projectEnd">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID" Dependency="Predecessor">
    </GanttTaskFields>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true"></GanttEditSettings>
    <GanttSegmentFields PrimaryKey="Id" ForeignKey="TaskID" StartDate="SegmentStartDate" EndDate="SegmentEndDate" Duration="SegmentDuration" TValue="TaskData" TSegments="SegmentModel" DataSource="segmentCollection"></GanttSegmentFields>
    <GanttLabelSettings LeftLabel="TaskName" TValue="TaskData"></GanttLabelSettings>
    <GanttColumns>
        <GanttColumn Field="TaskID" Width="100" Visible="false"></GanttColumn>
        <GanttColumn Field="TaskName" Width="250" ClipMode="Syncfusion.Blazor.Grids.ClipMode.EllipsisWithTooltip"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date"></GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration"></GanttColumn>
        <GanttColumn Field="Progress" HeaderText="Progress"></GanttColumn>
        <GanttColumn Field="Predecessor" HeaderText="Dependency"></GanttColumn>
    </GanttColumns>
</SfGantt>

@code {
    private DateTime projectStart = new DateTime(2022, 03, 23);
    private DateTime projectEnd = new DateTime(2022, 05, 10);
    private List<TaskData> taskCollection { get; set; }
    private List<SegmentModel> segmentCollection { get; set; }
    protected override void OnInitialized()
    {
        this.taskCollection = GetTaskCollection();
        this.segmentCollection = GetSegmentCollection();
    }
    public class SegmentModel
    {
        public int Id { get; set; }
        public int TaskID { get; set; }
        public DateTime SegmentStartDate { get; set; }
        public DateTime SegmentEndDate { get; set; }
        public string SegmentDuration { get; set; }
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
        public string Predecessor { get; set; }
    }
    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 03, 28), EndDate = new DateTime(2022, 04, 19), Duration="4" },
            new TaskData() { TaskID = 2, TaskName = "Identify site location", StartDate = new DateTime(2022, 03, 29), Progress = 30, ParentID = 1, Duration="8", },
            new TaskData() { TaskID = 3, TaskName = "Site analyze", StartDate = new DateTime(2022, 03, 29),  Progress = 50, ParentID = 1, Duration="8"},
            new TaskData() { TaskID = 4, TaskName = "Perform soil test", StartDate = new DateTime(2022, 03, 29), ParentID = 1, Duration="5", Predecessor="2FS", Progress=40, },
            new TaskData() { TaskID = 5, TaskName = "Soil test approval", StartDate = new DateTime(2022, 03, 29), Duration="4", Progress = 30 },
            new TaskData() { TaskID = 6, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 08), Duration="8", Progress=40, ParentID=1 },
            new TaskData() { TaskID = 7, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 03, 29), Duration = "0", Progress = 30, ParentID = 5, Predecessor= "4FS" },
            new TaskData() { TaskID = 8, TaskName = "List materials", StartDate = new DateTime(2022, 04, 01), Duration = "6", Progress = 30, ParentID = 5 },
            new TaskData() { TaskID = 9, TaskName = "Estimation approval",Progress=30, StartDate = new DateTime(2022, 04, 01), Duration = "4", ParentID = 5, Predecessor="8FS" },
            new TaskData() { TaskID = 10, TaskName = "Building approval", StartDate = new DateTime(2022, 04, 12), Duration = "5", ParentID = 5 },
            new TaskData() { TaskID = 11, TaskName = "Construction initiation", StartDate = new DateTime(2022, 04, 01), Duration = "5", Progress=40 },
            new TaskData() { TaskID = 12, TaskName = "Ground floor initiation", StartDate = new DateTime(2022, 04, 05), Duration = "5", ParentID = 11, Progress=40},
            new TaskData() { TaskID = 13, TaskName = "First floor initiation", StartDate = new DateTime(2022, 04, 05), Duration = "7",ParentID = 11, Progress=40},
            new TaskData() { TaskID = 14, TaskName = "Electric work initiation", StartDate = new DateTime(2022, 04, 01), Duration = "5", ParentID = 11, Progress=40, },
            new TaskData() { TaskID = 15, TaskName = "Plumbing work", StartDate = new DateTime(2022, 04, 02), Duration = "5", ParentID = 11, Progress=40 },
       };
        return Tasks;
    }
    private List<SegmentModel> GetSegmentCollection()
    {
        List<SegmentModel> segments = new List<SegmentModel>();
        segments.Add(new SegmentModel() { Id = 1, TaskID = 2, SegmentStartDate = new DateTime(2022, 04, 01), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 2, TaskID = 2, SegmentStartDate = new DateTime(2022, 03, 29), SegmentEndDate = new DateTime(2022, 03, 31) });
        segments.Add(new SegmentModel() { Id = 3, TaskID = 3, SegmentStartDate = new DateTime(2022, 04, 01), SegmentDuration = "2" });
        segments.Add(new SegmentModel() { Id = 4, TaskID = 3, SegmentStartDate = new DateTime(2022, 03, 29), SegmentEndDate = new DateTime(2022, 03, 31) });
        segments.Add(new SegmentModel() { Id = 5, TaskID = 3, SegmentStartDate = new DateTime(2022, 04, 04), SegmentDuration = "3" });
        segments.Add(new SegmentModel() { Id = 6, TaskID = 4, SegmentStartDate = new DateTime(2022, 04, 01), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 7, TaskID = 4, SegmentStartDate = new DateTime(2022, 03, 29), SegmentEndDate = new DateTime(2022, 03, 31) });
        segments.Add(new SegmentModel() { Id = 8, TaskID = 8, SegmentStartDate = new DateTime(2022, 04, 01), SegmentEndDate = new DateTime(2022, 04, 03) });
        segments.Add(new SegmentModel() { Id = 9, TaskID = 8, SegmentStartDate = new DateTime(2022, 04, 05), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 10, TaskID = 9, SegmentStartDate = new DateTime(2022, 03, 29), SegmentEndDate = new DateTime(2022, 03, 31) });
        segments.Add(new SegmentModel() { Id = 11, TaskID = 9, SegmentStartDate = new DateTime(2022, 04, 01), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 12, TaskID = 12, SegmentStartDate = new DateTime(2022, 04, 05), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 13, TaskID = 12, SegmentStartDate = new DateTime(2022, 04, 07), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 14, TaskID = 14, SegmentStartDate = new DateTime(2022, 04, 01), SegmentEndDate = new DateTime(2022, 04, 02) });
        segments.Add(new SegmentModel() { Id = 15, TaskID = 14, SegmentStartDate = new DateTime(2022, 04, 04), SegmentDuration = "2" });
        return segments;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZLyCtDOAsPRdxGQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Through dialog box

In the segments tab of the [add/edit dialog](https://blazor.syncfusion.com/documentation/gantt-chart/editing-tasks#dialog-editing), taskbars can be split or merged by providing segments details such as the start date, end date, and duration. However, It is important to note that a segment's start and end dates must fall within the task's overall start and end dates..

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using System.ComponentModel.DataAnnotations

<SfGantt TValue="TaskData" EnableContextMenu="true" DataSource="@taskCollection" Height="450px" Width="850px" TreeColumnIndex="1" Toolbar="@(new List<Object>() { "Add", "Cancel", "Update" , "Delete", "Edit", "CollapseAll", "ExpandAll", "ZoomIn", "ZoomOut", "ZoomToFit" })" RowHeight="37" ProjectStartDate="projectStart" ProjectEndDate="projectEnd">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID" Dependency="Predecessor">
    </GanttTaskFields>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true"></GanttEditSettings>
    <GanttSegmentFields PrimaryKey="Id" ForeignKey="TaskID" StartDate="SegmentStartDate" EndDate="SegmentEndDate" Duration="SegmentDuration" TValue="TaskData" TSegments="SegmentModel" DataSource="segmentCollection"></GanttSegmentFields>
    <GanttLabelSettings LeftLabel="TaskName" TValue="TaskData"></GanttLabelSettings>
    <GanttColumns>
        <GanttColumn Field="TaskID" Width="100" Visible="false"></GanttColumn>
        <GanttColumn Field="TaskName" Width="250" ClipMode="Syncfusion.Blazor.Grids.ClipMode.EllipsisWithTooltip"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date"></GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration"></GanttColumn>
        <GanttColumn Field="Progress" HeaderText="Progress"></GanttColumn>
        <GanttColumn Field="Predecessor" HeaderText="Dependency"></GanttColumn>
    </GanttColumns>
</SfGantt>

@code {
    private DateTime projectStart = new DateTime(2022, 03, 23);
    private DateTime projectEnd = new DateTime(2022, 05, 10);
    private List<TaskData> taskCollection { get; set; }
    private List<SegmentModel> segmentCollection { get; set; }
    protected override void OnInitialized()
    {
        this.taskCollection = GetTaskCollection();
        this.segmentCollection = GetSegmentCollection();
    }
    public class SegmentModel
    {
        public int Id { get; set; }
        public int TaskID { get; set; }
        [Display(Name = "Start Date")]
        public DateTime SegmentStartDate { get; set; }
        [Display(Name = "End Date")]
        public DateTime SegmentEndDate { get; set; }
        [Display(Name = "Duration")]
        public string SegmentDuration { get; set; }
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
        public string Predecessor { get; set; }
    }
    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 03, 28), EndDate = new DateTime(2022, 04, 19), Duration="4" },
            new TaskData() { TaskID = 2, TaskName = "Identify site location", StartDate = new DateTime(2022, 03, 29), Progress = 30, ParentID = 1, Duration="8", },
            new TaskData() { TaskID = 3, TaskName = "Site analyze", StartDate = new DateTime(2022, 03, 29),  Progress = 50, ParentID = 1, Duration="8"},
            new TaskData() { TaskID = 4, TaskName = "Perform soil test", StartDate = new DateTime(2022, 03, 29), ParentID = 1, Duration="5", Predecessor="2FS", Progress=40, },
            new TaskData() { TaskID = 5, TaskName = "Soil test approval", StartDate = new DateTime(2022, 03, 29), Duration="4", Progress = 30 },
            new TaskData() { TaskID = 6, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 08), Duration="8", Progress=40, ParentID=1 },
            new TaskData() { TaskID = 7, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 03, 29), Duration = "0", Progress = 30, ParentID = 5, Predecessor= "4FS" },
            new TaskData() { TaskID = 8, TaskName = "List materials", StartDate = new DateTime(2022, 04, 01), Duration = "6", Progress = 30, ParentID = 5 },
            new TaskData() { TaskID = 9, TaskName = "Estimation approval",Progress=30, StartDate = new DateTime(2022, 04, 01), Duration = "4", ParentID = 5, Predecessor="8FS" },
            new TaskData() { TaskID = 10, TaskName = "Building approval", StartDate = new DateTime(2022, 04, 12), Duration = "5", ParentID = 5 },
            new TaskData() { TaskID = 11, TaskName = "Construction initiation", StartDate = new DateTime(2022, 04, 01), Duration = "5", Progress=40 },
            new TaskData() { TaskID = 12, TaskName = "Ground floor initiation", StartDate = new DateTime(2022, 04, 05), Duration = "5", ParentID = 11, Progress=40},
            new TaskData() { TaskID = 13, TaskName = "First floor initiation", StartDate = new DateTime(2022, 04, 05), Duration = "7",ParentID = 11, Progress=40},
            new TaskData() { TaskID = 14, TaskName = "Electric work initiation", StartDate = new DateTime(2022, 04, 01), Duration = "5", ParentID = 11, Progress=40, },
            new TaskData() { TaskID = 15, TaskName = "Plumbing work", StartDate = new DateTime(2022, 04, 02), Duration = "5", ParentID = 11, Progress=40 },
       };
        return Tasks;
    }
    private List<SegmentModel> GetSegmentCollection()
    {
        List<SegmentModel> segments = new List<SegmentModel>();
        segments.Add(new SegmentModel() { Id = 1, TaskID = 2, SegmentStartDate = new DateTime(2022, 04, 01), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 2, TaskID = 2, SegmentStartDate = new DateTime(2022, 03, 29), SegmentEndDate = new DateTime(2022, 03, 31) });
        segments.Add(new SegmentModel() { Id = 3, TaskID = 3, SegmentStartDate = new DateTime(2022, 04, 01), SegmentDuration = "2" });
        segments.Add(new SegmentModel() { Id = 4, TaskID = 3, SegmentStartDate = new DateTime(2022, 03, 29), SegmentEndDate = new DateTime(2022, 03, 31) });
        segments.Add(new SegmentModel() { Id = 5, TaskID = 3, SegmentStartDate = new DateTime(2022, 04, 04), SegmentDuration = "3" });
        segments.Add(new SegmentModel() { Id = 6, TaskID = 4, SegmentStartDate = new DateTime(2022, 04, 01), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 7, TaskID = 4, SegmentStartDate = new DateTime(2022, 03, 29), SegmentEndDate = new DateTime(2022, 03, 31) });
        segments.Add(new SegmentModel() { Id = 8, TaskID = 8, SegmentStartDate = new DateTime(2022, 04, 01), SegmentEndDate = new DateTime(2022, 04, 03) });
        segments.Add(new SegmentModel() { Id = 9, TaskID = 8, SegmentStartDate = new DateTime(2022, 04, 05), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 10, TaskID = 9, SegmentStartDate = new DateTime(2022, 03, 29), SegmentEndDate = new DateTime(2022, 03, 31) });
        segments.Add(new SegmentModel() { Id = 11, TaskID = 9, SegmentStartDate = new DateTime(2022, 04, 01), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 12, TaskID = 12, SegmentStartDate = new DateTime(2022, 04, 05), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 13, TaskID = 12, SegmentStartDate = new DateTime(2022, 04, 07), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 14, TaskID = 14, SegmentStartDate = new DateTime(2022, 04, 01), SegmentEndDate = new DateTime(2022, 04, 02) });
        segments.Add(new SegmentModel() { Id = 15, TaskID = 14, SegmentStartDate = new DateTime(2022, 04, 04), SegmentDuration = "2" });
        return segments;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXrIiXXYArMJMGcN?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Through method 

Taskbars can be split or merged externally using the [SplitTaskAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_SplitTaskAsync_System_Int32_System_Collections_Generic_List_System_DateTime__) and [MergeTaskAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_MergeTaskAsync_System_Int32_System_Collections_Generic_List_System_ValueTuple_System_Int32_System_Int32___) methods. These provide a programmatic way to perform efficient splitting and merging operations on taskbars.

In the following code snippet, clicking an external button merges the segments of the taskbar at index 1 into a single segment and splits the taskbar at index 2 into two segments.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Buttons

<SfButton IsPrimary OnClick="MergeTaskHandler">Merge Task</SfButton>
 <SfButton IsPrimary OnClick="SplitTaskHandler">Split Task</SfButton>

 <SfGantt @ref="ganttInstance" TValue="TaskData" DataSource="@taskCollection" Height="450px" Width="100%" TreeColumnIndex="1" Toolbar="@(new List<Object>() { "Add", "Cancel", "Update" , "Delete", "Edit", "CollapseAll", "ExpandAll", "ZoomIn", "ZoomOut", "ZoomToFit" })" EnableContextMenu="true" RowHeight="37" ProjectStartDate="projectStart" ProjectEndDate="projectEnd">
     <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID" Dependency="Predecessor">
     </GanttTaskFields>
     <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true"></GanttEditSettings>
     <GanttSegmentFields PrimaryKey="Id" ForeignKey="TaskID" StartDate="SegmentStartDate" EndDate="SegmentEndDate" Duration="SegmentDuration" TValue="TaskData" TSegments="SegmentModel" DataSource="segmentCollection"></GanttSegmentFields>
     <GanttLabelSettings LeftLabel="TaskName" TValue="TaskData"></GanttLabelSettings>
     <GanttColumns>
         <GanttColumn Field="TaskID" Width="100" Visible="false"></GanttColumn>
         <GanttColumn Field="TaskName" Width="250" ClipMode="Syncfusion.Blazor.Grids.ClipMode.EllipsisWithTooltip"></GanttColumn>
         <GanttColumn Field="StartDate" HeaderText="Start Date"></GanttColumn>
         <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
         <GanttColumn Field="Duration" HeaderText="Duration"></GanttColumn>
         <GanttColumn Field="Progress" HeaderText="Progress"></GanttColumn>
         <GanttColumn Field="Predecessor" HeaderText="Dependency"></GanttColumn>
     </GanttColumns>
 </SfGantt>

 @code {
    private SfGantt<TaskData> ganttInstance { get; set; }
    private DateTime projectStart = new DateTime(2022, 03, 23);
    private DateTime projectEnd = new DateTime(2022, 05, 10);
    private List<TaskData> taskCollection { get; set; }
    private List<SegmentModel> segmentCollection { get; set; }

    private async Task MergeTaskHandler()
    {
        List<ValueTuple<int, int>> mergeIndexes = new List<ValueTuple<int, int>>();
        mergeIndexes.Add((0, 1));
        await ganttInstance.MergeTaskAsync(2, mergeIndexes);
    }
    private async Task SplitTaskHandler()
    {
        await ganttInstance.SplitTaskAsync(3, new List<DateTime> { new DateTime(2022, 04, 08) });
    }

    protected override void OnInitialized()
    {
        this.taskCollection = GetTaskCollection();
        this.segmentCollection = GetSegmentCollection();
    }
    public class SegmentModel
    {
        public int Id { get; set; }
        public int TaskID { get; set; }
        public DateTime SegmentStartDate { get; set; }
        public DateTime SegmentEndDate { get; set; }
        public string SegmentDuration { get; set; }
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
        public string Predecessor { get; set; }
    }
    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 03, 28), EndDate = new DateTime(2022, 04, 19), Duration="4" },
            new TaskData() { TaskID = 2, TaskName = "Identify site location", StartDate = new DateTime(2022, 03, 29), Progress = 30, ParentID = 1, Duration="8", },
            new TaskData() { TaskID = 3, TaskName = "Site analyze", StartDate = new DateTime(2022, 03, 29),  Progress = 50, ParentID = 1, Duration="8"},
            new TaskData() { TaskID = 4, TaskName = "Perform soil test", StartDate = new DateTime(2022, 03, 29), ParentID = 1, Duration="5", Predecessor="2FS", Progress=40, },
            new TaskData() { TaskID = 5, TaskName = "Soil test approval", StartDate = new DateTime(2022, 03, 29), Duration="4", Progress = 30 },
            new TaskData() { TaskID = 6, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 08), Duration="8", Progress=40, ParentID=1 },
            new TaskData() { TaskID = 7, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 03, 29), Duration = "0", Progress = 30, ParentID = 5, Predecessor= "4FS" },
            new TaskData() { TaskID = 8, TaskName = "List materials", StartDate = new DateTime(2022, 04, 01), Duration = "6", Progress = 30, ParentID = 5 },
            new TaskData() { TaskID = 9, TaskName = "Estimation approval",Progress=30, StartDate = new DateTime(2022, 04, 01), Duration = "4", ParentID = 5, Predecessor="8FS" },
            new TaskData() { TaskID = 10, TaskName = "Building approval", StartDate = new DateTime(2022, 04, 12), Duration = "5", ParentID = 5 },
            new TaskData() { TaskID = 11, TaskName = "Construction initiation", StartDate = new DateTime(2022, 04, 01), Duration = "5", Progress=40 },
            new TaskData() { TaskID = 12, TaskName = "Ground floor initiation", StartDate = new DateTime(2022, 04, 05), Duration = "5", ParentID = 11, Progress=40},
            new TaskData() { TaskID = 13, TaskName = "First floor initiation", StartDate = new DateTime(2022, 04, 05), Duration = "7",ParentID = 11, Progress=40},
            new TaskData() { TaskID = 14, TaskName = "Electric work initiation", StartDate = new DateTime(2022, 04, 01), Duration = "5", ParentID = 11, Progress=40, },
            new TaskData() { TaskID = 15, TaskName = "Plumbing work", StartDate = new DateTime(2022, 04, 02), Duration = "5", ParentID = 11, Progress=40 },
       };
        return Tasks;
    }
    private List<SegmentModel> GetSegmentCollection()
    {
        List<SegmentModel> segments = new List<SegmentModel>();
        segments.Add(new SegmentModel() { Id = 1, TaskID = 2, SegmentStartDate = new DateTime(2022, 04, 01), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 2, TaskID = 2, SegmentStartDate = new DateTime(2022, 03, 29), SegmentEndDate = new DateTime(2022, 03, 31) });
        segments.Add(new SegmentModel() { Id = 3, TaskID = 3, SegmentStartDate = new DateTime(2022, 04, 01), SegmentDuration = "2" });
        segments.Add(new SegmentModel() { Id = 4, TaskID = 3, SegmentStartDate = new DateTime(2022, 03, 29), SegmentEndDate = new DateTime(2022, 03, 31) });
        segments.Add(new SegmentModel() { Id = 5, TaskID = 3, SegmentStartDate = new DateTime(2022, 04, 04), SegmentDuration = "3" });
        segments.Add(new SegmentModel() { Id = 6, TaskID = 4, SegmentStartDate = new DateTime(2022, 04, 01), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 7, TaskID = 4, SegmentStartDate = new DateTime(2022, 03, 29), SegmentEndDate = new DateTime(2022, 03, 31) });
        segments.Add(new SegmentModel() { Id = 8, TaskID = 8, SegmentStartDate = new DateTime(2022, 04, 01), SegmentEndDate = new DateTime(2022, 04, 03) });
        segments.Add(new SegmentModel() { Id = 9, TaskID = 8, SegmentStartDate = new DateTime(2022, 04, 05), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 10, TaskID = 9, SegmentStartDate = new DateTime(2022, 03, 29), SegmentEndDate = new DateTime(2022, 03, 31) });
        segments.Add(new SegmentModel() { Id = 11, TaskID = 9, SegmentStartDate = new DateTime(2022, 04, 01), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 12, TaskID = 12, SegmentStartDate = new DateTime(2022, 04, 05), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 13, TaskID = 12, SegmentStartDate = new DateTime(2022, 04, 07), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 14, TaskID = 14, SegmentStartDate = new DateTime(2022, 04, 01), SegmentEndDate = new DateTime(2022, 04, 02) });
        segments.Add(new SegmentModel() { Id = 15, TaskID = 14, SegmentStartDate = new DateTime(2022, 04, 04), SegmentDuration = "2" });
        return segments;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXresXZYqLhJtdVC?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Segment event

The [SegmentChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttSegmentFields-2.html#Syncfusion_Blazor_Gantt_GanttSegmentFields_2_SegmentChanging) event is triggered in the Blazor Gantt chart when split and merge actions occur, or when there are changes in the scheduling dates of tasks. Using this event, any custom actions can be performed or even the split or merge action can be canceled by setting the [Cancel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SegmentEventArgs-1.html#Syncfusion_Blazor_Gantt_SegmentEventArgs_1_Cancel) property of the even argument to `true`.

In the below code snippet, using the `SegmentChanging` event a customized message is displayed when doing split or merge actions. Moreover, segment deletion is prevented to the 1st index task.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<span class="text-primary">@segmetEventMessage</span
<SfGantt TValue="TaskData" DataSource="@taskCollection" Height="450px" Width="800px" TreeColumnIndex="1" Toolbar="@(new List<Object>() { "Add", "Cancel", "Update" , "Delete", "Edit", "CollapseAll", "ExpandAll", "ZoomIn", "ZoomOut", "ZoomToFit" })" EnableContextMenu="true" RowHeight="37" ProjectStartDate="projectStart" ProjectEndDate="projectEnd">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID" Dependency="Predecessor">
    </GanttTaskFields>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true"></GanttEditSettings>
    <GanttSegmentFields PrimaryKey="Id" ForeignKey="TaskID" StartDate="SegmentStartDate" EndDate="SegmentEndDate" Duration="SegmentDuration" TValue="TaskData" TSegments="SegmentModel" DataSource="segmentCollection" SegmentChanging="SegmentEventHandler"></GanttSegmentFields>
    <GanttLabelSettings LeftLabel="TaskName" TValue="TaskData"></GanttLabelSettings>
    <GanttColumns>
        <GanttColumn Field="TaskID" Width="100" Visible="false"></GanttColumn>
        <GanttColumn Field="TaskName" Width="250" ClipMode="Syncfusion.Blazor.Grids.ClipMode.EllipsisWithTooltip"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date"></GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration"></GanttColumn>
        <GanttColumn Field="Progress" HeaderText="Progress"></GanttColumn>
        <GanttColumn Field="Predecessor" HeaderText="Dependency"></GanttColumn>
    </GanttColumns>
</SfGantt>

@code {
    private DateTime projectStart = new DateTime(2022, 03, 23);
    private DateTime projectEnd = new DateTime(2022, 05, 10);
    private List<TaskData> taskCollection { get; set; }
    private List<SegmentModel> segmentCollection { get; set; }
    private string segmetEventMessage { get; set; }

    private async Task SegmentEventHandler(SegmentEventArgs<SegmentModel> args)
    {
        if (args.UpdatedSegments != null && args.UpdatedSegments.Any())
        {
            segmetEventMessage = "The segment details are updated!";
        }
        if (args.DeletedSegments != null && args.DeletedSegments.Any())
        {
            foreach(SegmentModel segment in args.DeletedSegments)
            {
                if (segment.TaskID == 2)
                {
                    segmetEventMessage = "The deleted segment action is canceled!";
                    args.Cancel = true;
                }
            }
        }
        if (args.AddedSegments != null && args.AddedSegments.Any())
        {
            segmetEventMessage = "New segment is added!";
        }
        await Task.CompletedTask;
    }

    protected override void OnInitialized()
    {
        this.taskCollection = GetTaskCollection();
        this.segmentCollection = GetSegmentCollection();
    }
    public class SegmentModel
    {
        public int Id { get; set; }
        public int TaskID { get; set; }
        public DateTime SegmentStartDate { get; set; }
        public DateTime SegmentEndDate { get; set; }
        public string SegmentDuration { get; set; }
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
        public string Predecessor { get; set; }
    }
    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 03, 28), EndDate = new DateTime(2022, 04, 19), Duration="4" },
            new TaskData() { TaskID = 2, TaskName = "Identify site location", StartDate = new DateTime(2022, 03, 29), Progress = 30, ParentID = 1, Duration="8", },
            new TaskData() { TaskID = 3, TaskName = "Site analyze", StartDate = new DateTime(2022, 03, 29),  Progress = 50, ParentID = 1, Duration="8"},
            new TaskData() { TaskID = 4, TaskName = "Perform soil test", StartDate = new DateTime(2022, 03, 29), ParentID = 1, Duration="5", Predecessor="2FS", Progress=40, },
            new TaskData() { TaskID = 5, TaskName = "Soil test approval", StartDate = new DateTime(2022, 03, 29), Duration="4", Progress = 30 },
            new TaskData() { TaskID = 6, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 08), Duration="8", Progress=40, ParentID=1 },
            new TaskData() { TaskID = 7, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 03, 29), Duration = "0", Progress = 30, ParentID = 5, Predecessor= "4FS" },
            new TaskData() { TaskID = 8, TaskName = "List materials", StartDate = new DateTime(2022, 04, 01), Duration = "6", Progress = 30, ParentID = 5 },
            new TaskData() { TaskID = 9, TaskName = "Estimation approval",Progress=30, StartDate = new DateTime(2022, 04, 01), Duration = "4", ParentID = 5, Predecessor="8FS" },
            new TaskData() { TaskID = 10, TaskName = "Building approval", StartDate = new DateTime(2022, 04, 12), Duration = "5", ParentID = 5 },
            new TaskData() { TaskID = 11, TaskName = "Construction initiation", StartDate = new DateTime(2022, 04, 01), Duration = "5", Progress=40 },
            new TaskData() { TaskID = 12, TaskName = "Ground floor initiation", StartDate = new DateTime(2022, 04, 05), Duration = "5", ParentID = 11, Progress=40},
            new TaskData() { TaskID = 13, TaskName = "First floor initiation", StartDate = new DateTime(2022, 04, 05), Duration = "7",ParentID = 11, Progress=40},
            new TaskData() { TaskID = 14, TaskName = "Electric work initiation", StartDate = new DateTime(2022, 04, 01), Duration = "5", ParentID = 11, Progress=40, },
            new TaskData() { TaskID = 15, TaskName = "Plumbing work", StartDate = new DateTime(2022, 04, 02), Duration = "5", ParentID = 11, Progress=40 },
    };
        return Tasks;
    }
    private List<SegmentModel> GetSegmentCollection()
    {
        List<SegmentModel> segments = new List<SegmentModel>();
        segments.Add(new SegmentModel() { Id = 1, TaskID = 2, SegmentStartDate = new DateTime(2022, 04, 01), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 2, TaskID = 2, SegmentStartDate = new DateTime(2022, 03, 29), SegmentEndDate = new DateTime(2022, 03, 31) });
        segments.Add(new SegmentModel() { Id = 3, TaskID = 3, SegmentStartDate = new DateTime(2022, 04, 01), SegmentDuration = "2" });
        segments.Add(new SegmentModel() { Id = 4, TaskID = 3, SegmentStartDate = new DateTime(2022, 03, 29), SegmentEndDate = new DateTime(2022, 03, 31) });
        segments.Add(new SegmentModel() { Id = 5, TaskID = 3, SegmentStartDate = new DateTime(2022, 04, 04), SegmentDuration = "3" });
        segments.Add(new SegmentModel() { Id = 6, TaskID = 4, SegmentStartDate = new DateTime(2022, 04, 01), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 7, TaskID = 4, SegmentStartDate = new DateTime(2022, 03, 29), SegmentEndDate = new DateTime(2022, 03, 31) });
        segments.Add(new SegmentModel() { Id = 8, TaskID = 8, SegmentStartDate = new DateTime(2022, 04, 01), SegmentEndDate = new DateTime(2022, 04, 03) });
        segments.Add(new SegmentModel() { Id = 9, TaskID = 8, SegmentStartDate = new DateTime(2022, 04, 05), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 10, TaskID = 9, SegmentStartDate = new DateTime(2022, 03, 29), SegmentEndDate = new DateTime(2022, 03, 31) });
        segments.Add(new SegmentModel() { Id = 11, TaskID = 9, SegmentStartDate = new DateTime(2022, 04, 01), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 12, TaskID = 12, SegmentStartDate = new DateTime(2022, 04, 05), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 13, TaskID = 12, SegmentStartDate = new DateTime(2022, 04, 07), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 14, TaskID = 14, SegmentStartDate = new DateTime(2022, 04, 01), SegmentEndDate = new DateTime(2022, 04, 02) });
        segments.Add(new SegmentModel() { Id = 15, TaskID = 14, SegmentStartDate = new DateTime(2022, 04, 04), SegmentDuration = "2" });
        return segments;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDBeWXXuKBUVtmvc?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Segment customization with template

In the Blazor Gantt Chart, the appearance of segments can be customized by using the [TaskbarTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTemplates-1.html#Syncfusion_Blazor_Gantt_GanttTemplates_1_TaskbarTemplate) property. By passing the template context to the `GetRowTaskModel`, the collection of [Segments](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.IGanttTaskModel-1.html#Syncfusion_Blazor_Gantt_IGanttTaskModel_1_Segments) is obtained, which contains details  like left position, width, and progress width for each segment. The segments can be rendered at the appropriate timeline position and dimensions within the template container using these details.

In the code snippet below, the segments are customized based on template context data, and the segment count text is added inside each segment. 

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt @ref="gantt" TValue="TaskData" DataSource="@taskCollection" Height="450px" Width="100%" TreeColumnIndex="1" Toolbar="@(new List<Object>() { "Add", "Cancel", "Update" , "Delete", "Edit", "CollapseAll", "ExpandAll", "ZoomIn", "ZoomOut", "ZoomToFit" })" EnableContextMenu="true" RowHeight="37" ProjectStartDate="projectStart" ProjectEndDate="projectEnd">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID" Dependency="Predecessor">
    </GanttTaskFields>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true"></GanttEditSettings>
    <GanttSegmentFields PrimaryKey="Id" ForeignKey="TaskID" StartDate="SegmentStartDate" EndDate="SegmentEndDate" Duration="SegmentDuration" TValue="TaskData" TSegments="SegmentModel" DataSource="segmentCollection"></GanttSegmentFields>
    <GanttLabelSettings LeftLabel="TaskName" TValue="TaskData"></GanttLabelSettings>
    <GanttColumns>
        <GanttColumn Field="TaskID" Width="100" Visible="false"></GanttColumn>
        <GanttColumn Field="TaskName" Width="250" ClipMode="Syncfusion.Blazor.Grids.ClipMode.EllipsisWithTooltip"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date"></GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration"></GanttColumn>
        <GanttColumn Field="Progress" HeaderText="Progress"></GanttColumn>
        <GanttColumn Field="Predecessor" HeaderText="Dependency"></GanttColumn>
    </GanttColumns>
    <GanttTemplates TValue="TaskData">
        <TaskbarTemplate>
            @{
                var task = (context as TaskData);
                if (task == null)
                {
                    return;
                }
                var taskModel = gantt.GetRowTaskModel(task);
                List<GanttSegmentData> segments = taskModel.Segments;
                @if (segments != null && segments.Count() > 1)
                {
                    foreach (var segment in segments)
                    {
                        string textContent = "Segment " + (segment.SegmentIndex + 1);
                        <div class="e-gantt-child-taskbar-inner-div e-gantt-child-taskbar e-segmented-taskbar" style=@("height:24px;position: absolute;left:" + segment.Left + "px; width:" + segment.Width + "px;") tabindex=-1 data-segment-index="@(segment.SegmentIndex)">
                            <div class="e-taskbar-left-resizer e-icon" style="margin-top: 5px; left:2px">
                            </div>
                            <div class="e-gantt-child-progressbar-inner-div e-gantt-child-progressbar" style="height:24px;width:@(segment.ProgressWidth + "px");border-radius: 0px;text-align: right;">
                                <div style=@("height:22px;position: absolute;line-height:21px;font-size: 11px;color: #fff;text-overflow:ellipsis;overflow-x:hidden;")>
                                    <span>@textContent</span>
                                </div>
                            </div>
                            <div class="e-taskbar-right-resizer e-icon" style="margin-top: 5px;left:@((segment.Width) - 15)px">
                            </div>
                        </div>
                    }
                }
                else
                {
                    <div class="e-gantt-child-taskbar e-gantt-child-taskbar-inner-div" style="height:24px;" tabindex=-1>
                        <div class="e-gantt-child-progressbar-inner-div e-gantt-child-progressbar" style="height:24px;width:@(taskModel.ProgressWidth + "px");text-align: right;border-radius: 0px;">
                        </div>
                    </div>
                }
            }
        </TaskbarTemplate>
    </GanttTemplates>
</SfGantt>
<style>
    .e-segmented-taskbar.e-gantt-clone-taskbar {
        top: 0px !important;
    }

    .e-segmented-taskbar .e-gantt-child-progressbar {
        background-color: #0056B3 !important;
    }

    .e-segmented-taskbar {
        background-color: #8553F1 !important;
        border: 1px solid #3f51b5 !important;
    }
</style>
@code {
    private SfGantt<TaskData> gantt;
    private DateTime projectStart = new DateTime(2022, 03, 23);
    private DateTime projectEnd = new DateTime(2022, 05, 10);
    private List<TaskData> taskCollection { get; set; }
    private List<SegmentModel> segmentCollection { get; set; }
    protected override void OnInitialized()
    {
        this.taskCollection = GetTaskCollection();
        this.segmentCollection = GetSegmentCollection();
    }
    public class SegmentModel
    {
        public int Id { get; set; }
        public int TaskID { get; set; }
        public DateTime SegmentStartDate { get; set; }
        public DateTime SegmentEndDate { get; set; }
        public string SegmentDuration { get; set; }
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
        public string Predecessor { get; set; }
    }
    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 03, 28), EndDate = new DateTime(2022, 04, 19), Duration="4" },
            new TaskData() { TaskID = 2, TaskName = "Identify site location", StartDate = new DateTime(2022, 03, 29), Progress = 30, ParentID = 1, Duration="8", },
            new TaskData() { TaskID = 3, TaskName = "Site analyze", StartDate = new DateTime(2022, 03, 29),  Progress = 50, ParentID = 1, Duration="8"},
            new TaskData() { TaskID = 4, TaskName = "Perform soil test", StartDate = new DateTime(2022, 03, 29), ParentID = 1, Duration="5", Predecessor="2FS", Progress=40, },
            new TaskData() { TaskID = 5, TaskName = "Soil test approval", StartDate = new DateTime(2022, 03, 29), Duration="4", Progress = 30 },
            new TaskData() { TaskID = 6, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 08), Duration="8", Progress=40, ParentID=1 },
            new TaskData() { TaskID = 7, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 03, 29), Duration = "0", Progress = 30, ParentID = 5, Predecessor= "4FS" },
            new TaskData() { TaskID = 8, TaskName = "List materials", StartDate = new DateTime(2022, 04, 01), Duration = "6", Progress = 30, ParentID = 5 },
            new TaskData() { TaskID = 9, TaskName = "Estimation approval",Progress=30, StartDate = new DateTime(2022, 04, 01), Duration = "4", ParentID = 5, Predecessor="8FS" },
            new TaskData() { TaskID = 10, TaskName = "Building approval", StartDate = new DateTime(2022, 04, 12), Duration = "5", ParentID = 5 },
            new TaskData() { TaskID = 11, TaskName = "Construction initiation", StartDate = new DateTime(2022, 04, 01), Duration = "5", Progress=40 },
            new TaskData() { TaskID = 12, TaskName = "Ground floor initiation", StartDate = new DateTime(2022, 04, 05), Duration = "5", ParentID = 11, Progress=40},
            new TaskData() { TaskID = 13, TaskName = "First floor initiation", StartDate = new DateTime(2022, 04, 05), Duration = "7",ParentID = 11, Progress=40},
            new TaskData() { TaskID = 14, TaskName = "Electric work initiation", StartDate = new DateTime(2022, 04, 01), Duration = "5", ParentID = 11, Progress=40, },
            new TaskData() { TaskID = 15, TaskName = "Plumbing work", StartDate = new DateTime(2022, 04, 02), Duration = "5", ParentID = 11, Progress=40 },
       };
        return Tasks;
    }
    private List<SegmentModel> GetSegmentCollection()
    {
        List<SegmentModel> segments = new List<SegmentModel>();
        segments.Add(new SegmentModel() { Id = 1, TaskID = 2, SegmentStartDate = new DateTime(2022, 04, 01), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 2, TaskID = 2, SegmentStartDate = new DateTime(2022, 03, 29), SegmentEndDate = new DateTime(2022, 03, 31) });
        segments.Add(new SegmentModel() { Id = 3, TaskID = 3, SegmentStartDate = new DateTime(2022, 04, 01), SegmentDuration = "2" });
        segments.Add(new SegmentModel() { Id = 4, TaskID = 3, SegmentStartDate = new DateTime(2022, 03, 29), SegmentEndDate = new DateTime(2022, 03, 31) });
        segments.Add(new SegmentModel() { Id = 5, TaskID = 3, SegmentStartDate = new DateTime(2022, 04, 04), SegmentDuration = "3" });
        segments.Add(new SegmentModel() { Id = 6, TaskID = 4, SegmentStartDate = new DateTime(2022, 04, 01), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 7, TaskID = 4, SegmentStartDate = new DateTime(2022, 03, 29), SegmentEndDate = new DateTime(2022, 03, 31) });
        segments.Add(new SegmentModel() { Id = 8, TaskID = 8, SegmentStartDate = new DateTime(2022, 04, 01), SegmentEndDate = new DateTime(2022, 04, 03) });
        segments.Add(new SegmentModel() { Id = 9, TaskID = 8, SegmentStartDate = new DateTime(2022, 04, 05), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 10, TaskID = 9, SegmentStartDate = new DateTime(2022, 03, 29), SegmentEndDate = new DateTime(2022, 03, 31) });
        segments.Add(new SegmentModel() { Id = 11, TaskID = 9, SegmentStartDate = new DateTime(2022, 04, 01), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 12, TaskID = 12, SegmentStartDate = new DateTime(2022, 04, 05), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 13, TaskID = 12, SegmentStartDate = new DateTime(2022, 04, 07), SegmentDuration = "1" });
        segments.Add(new SegmentModel() { Id = 14, TaskID = 14, SegmentStartDate = new DateTime(2022, 04, 01), SegmentEndDate = new DateTime(2022, 04, 02) });
        segments.Add(new SegmentModel() { Id = 15, TaskID = 14, SegmentStartDate = new DateTime(2022, 04, 04), SegmentDuration = "2" });
        return segments;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDBosXNaUBHuviBu?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Limitation

1. Parent and milestone tasks cannot be split into segments.
2. The task must have a width greater than the timeline unit cell in order to be split.
3. Split task is not supported with `Multi taskbar`.

## See also
- [How to bind data in Gantt?](https://blazor.syncfusion.com/documentation/gantt-chart/data-binding)
- [How to configure task editing?](https://blazor.syncfusion.com/documentation/gantt-chart/editing-tasks)
- [How to manage task dependencies?](https://blazor.syncfusion.com/documentation/gantt-chart/task-dependencies)