---
layout: post
title: WBS Column in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about WBS Column in Syncfusion Blazor Gantt Chart component and much more details.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Work Breakdown Structure (WBS) in Blazor Gantt component

The Work Breakdown Structure (WBS) organizes project tasks hierarchically in the Gantt component by assigning unique codes to each task. This system enhances visualization and management by clearly reflecting task relationships and levels through a structured numbering scheme (1, 1.1, 1.1.1, etc.). It proves especially valuable in complex environments like construction projects or enterprise-scale software development.

WBS provides a structured coding system for tasks, enabling clear hierarchy and predecessor relationships. The automatic code generation ensures efficient task organization, while auto-updates maintain accuracy during sorting, filtering, editing, and row operations. This enhances project tracking in hierarchical structures with event-driven control for performance optimization.

## Configuration and implementation

To enable WBS in the Blazor Gantt component, set the [ShowWbsColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ShowWbsColumn) property to `true`. This displays the WBS column in the treegrid area of the Gantt chart. 

The [AutoGenerateWbs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AutoGenerateWbs) property handles WBS code generation automatically. When enabled, the component creates WBS codes based on the task hierarchy and maintains updated codes when tasks are added, deleted, moved, edited, indented, outdented, sorted, filtered, or searched.

To render the WBS and WBS Predecessor columns, you need to bind the `WbsCode` and `WbsPredecessor` fields in `GanttTaskFields`.

The WBS code generation follows a hierarchical numbering pattern where parent tasks receive sequential numbers (1, 2, 3), and child tasks append decimal notation (1.1, 1.2, 1.1.1). This automatic generation recalculates codes whenever the task hierarchy changes through operations like indenting, outdenting, or reordering tasks.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" 
         Height="450px" 
         Width="100%" 
         ShowWbsColumn="true"
         AutoGenerateWbs="true">
    <GanttTaskFields Id="TaskID" 
                     Name="TaskName" 
                     StartDate="StartDate" 
                     EndDate="EndDate" 
                     Duration="Duration" 
                     Progress="Progress" 
                     ParentID="ParentID"
                     Dependency="Predecessor"
                     WbsCode="WbsCode"
                     WbsPredecessor="WbsPredecessor">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="WbsCode" HeaderText="WBS" Width="100"></GanttColumn>
        <GanttColumn Field="TaskID" HeaderText="Task ID" Width="80"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Task Name" Width="250"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date" Width="150"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration" Width="100"></GanttColumn>
        <GanttColumn Field="Progress" HeaderText="Progress" Width="100"></GanttColumn>
        <GanttColumn Field="WbsPredecessor" HeaderText="WBS Predecessor" Width="150"></GanttColumn>
    </GanttColumns>
</SfGantt>

@code {
    private List<TaskData> TaskCollection { get; set; } = new();

    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
    }

    private List<TaskData> GetTaskCollection()
    {
        return new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project Management", StartDate = new DateTime(2023, 04, 02), Duration = 5, Progress = 40, ParentID = null },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2023, 04, 02), Duration = 4, Progress = 50, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform Soil test", StartDate = new DateTime(2023, 04, 02), Duration = 4, Progress = 50, ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2023, 04, 02), Duration = 4, Progress = 50, ParentID = 1, Predecessor = "3FS" },
            new TaskData() { TaskID = 5, TaskName = "Project Estimation", StartDate = new DateTime(2023, 04, 02), Duration = 5, Progress = 40, ParentID = null },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2023, 04, 04), Duration = 3, Progress = 30, ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2023, 04, 04), Duration = 3, Progress = 40, ParentID = 5, Predecessor = "6FS" }
        };
    }

    public class TaskData
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentID { get; set; }
        public string Predecessor { get; set; }
        public string? WbsCode { get; set; }
        public string? WbsPredecessor { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNLyZkCcgEDXhRzE?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> The WBS column in Gantt chart currently supports string data types for both WBS codes and WBS predecessor values, ensuring consistent text-based representation across all project hierarchy levels and dependency relationships.

## Performance optimization with conditional updates

For enhanced performance in large datasets, controlling when WBS codes are recalculated by through the [DataBound](https://blazor.syncfusion.com/documentation/gantt-chart/events#databound) and [RowDropped](https://blazor.syncfusion.com/documentation/gantt-chart/events#rowdropped) events. This approach optimizes performance during intensive operations like drag-and-drop by enabling auto-update only when necessary.

The following example demonstrates conditional WBS auto-update activation specifically during row drag and drop operations, preventing unnecessary recalculations during other interactions.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids

<SfGantt @ref="GanttRef"
         DataSource="@TaskCollection"
         Height="450px"
         Width="100%"
         ShowWbsColumn="true"
         AutoGenerateWbs="@EnableAutoUpdate"
         AllowRowDragAndDrop="true">
    <GanttTaskFields Id="TaskID"
                     Name="TaskName"
                     StartDate="StartDate"
                     EndDate="EndDate"
                     Duration="Duration"
                     Progress="Progress"
                     ParentID="ParentID"
                     WbsCode="WbsCode"
                     WbsPredecessor="WbsPredecessor">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="WbsCode" HeaderText="WBS" Width="100"></GanttColumn>
        <GanttColumn Field="TaskID" HeaderText="Task ID" Width="80"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Task Name" Width="250"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date" Width="150"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration" Width="100"></GanttColumn>
        <GanttColumn Field="Progress" HeaderText="Progress" Width="100"></GanttColumn>
        <GanttColumn Field="WbsPredecessor" HeaderText="WBS Predecessor" Width="150"></GanttColumn>
    </GanttColumns>
    <GanttEvents DataBound="DataBoundHandler" RowDragStarting="RowDragStartHandler"
                 TValue="TaskData">
    </GanttEvents>
</SfGantt>

@code {
    private SfGantt<TaskData> GanttRef;
    private List<TaskData> TaskCollection { get; set; } = new();
    private bool EnableAutoUpdate { get; set; } = true;
    private bool IsRowDragged{ get; set; }
    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
    }

    private void DataBoundHandler()
    {
        // Disable auto-update after row drag operation completes
        if (IsRowDragged)
        {
            EnableAutoUpdate = false;
            IsRowDragged = false;
        }

    }

    private void RowDragStartHandler(RowDragStartingEventArgs<TaskData> args)
    {
        // Enable auto-update when row drag begins
        EnableAutoUpdate = true;
        IsRowDragged = true;
    }

    private List<TaskData> GetTaskCollection()
    {
        return new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project Management", StartDate = new DateTime(2023, 04, 02), Duration = 5, Progress = 40, ParentID = null },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2023, 04, 02), Duration = 4, Progress = 50, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform Soil test", StartDate = new DateTime(2023, 04, 02), Duration = 4, Progress = 50, ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2023, 04, 02), Duration = 4, Progress = 50, ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Project Estimation", StartDate = new DateTime(2023, 04, 02), Duration = 5, Progress = 40, ParentID = null },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2023, 04, 04), Duration = 3, Progress = 30, ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2023, 04, 04), Duration = 3, Progress = 40, ParentID = 5 }
        };
    }

    public class TaskData
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentID { get; set; }
        public string? WbsCode { get; set; }
        public string? WbsPredecessor { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDVeZkMcgEtlnXEw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Limitations

The WBS feature has a few limitations in the Gantt component:

* Editing of the WBS code and WBS predecessor columns is not supported.
* Load on demand is not supported with the WBS feature.
* WBS Code and WBS Predecessor fields cannot be mapped directly from the data source as they are generated dynamically by the component based on task hierarchy.

## See Also
- [How to define columns manually in Blazor Gantt Chart](https://ej2.syncfusion.com/blazor/documentation/gantt-chart/columns/column)
- [How to customize column headers in Blazor Gantt Chart](https://ej2.syncfusion.com/blazor/documentation/gantt-chart/columns/column-headers)
- [How to use the column menu in Blazor Gantt Chart](https://ej2.syncfusion.com/blazor/documentation/gantt-chart/columns/column-menu)
- [How to reorder columns in Blazor Gantt Chart](https://ej2.syncfusion.com/blazor/documentation/gantt-chart/columns/column-reorder)
- [How to resize columns in Blazor Gantt Chart](https://ej2.syncfusion.com/blazor/documentation/gantt-chart/columns/column-resizing)
- [How to use column templates in Blazor Gantt Chart](https://ej2.syncfusion.com/blazor/documentation/gantt-chart/columns/column-template)