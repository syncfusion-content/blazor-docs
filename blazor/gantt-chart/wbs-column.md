---
layout: post
title: WBS Column in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about WBS Column in Syncfusion Blazor Gantt Chart component and much more details.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Work Breakdown Structure (WBS) in Blazor Gantt Component

The Work Breakdown Structure (WBS) organizes tasks hierarchically by assigning structured codes to each item. This improves task visibility and management by clearly representing relationships and levels using a numbering format (e.g., 1, 1.1, 1.1.1). It is especially useful in complex scenarios such as construction or enterprise-scale software projects.

WBS provides a structured coding system for tasks, enabling clear hierarchy and predecessor relationships. The automatic code generation ensures efficient task organization, while auto-updates maintain accuracy during sorting, filtering, editing, and row operations. This enhances project tracking in hierarchical structures with event-driven control for performance optimization.

## Configuration and Implementation

To display the WBS column in the Gantt treegrid, set the [ShowWbsColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ShowWbsColumn) property to **true**.

To automatically generate and maintain WBS codes based on task hierarchy, enable the [AutoGenerateWbs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AutoGenerateWbs) property. WBS codes are updated when tasks are added, deleted, moved, edited, indented, outdented, sorted, filtered, or searched.

To render WBS and WBS Predecessor columns, bind the [WbsCode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTaskFields.html#Syncfusion_Blazor_Gantt_GanttTaskFields_WbsCode) and [WbsPredecessor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTaskFields.html#Syncfusion_Blazor_Gantt_GanttTaskFields_WbsPredecessor) fields in `GanttTaskFields`.

WBS codes follow a hierarchical structure: parent tasks use sequential numbers (e.g., 1, 2, 3), and child tasks use decimal notation (e.g., 1.1, 1.2, 1.1.1). Codes are recalculated automatically when the task hierarchy changes due to operations like indenting, outdenting, or reordering.

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
        public int Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentID { get; set; }
        public string Predecessor { get; set; }
        public string WbsCode { get; set; }
        public string WbsPredecessor { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZLoDEroBqxKFzeJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> The WBS column in Gantt chart currently supports string data types for both WBS codes and WBS predecessor values, ensuring consistent text-based representation across all project hierarchy levels and dependency relationships.

## Performance Optimization with Conditional Updates

To improve performance with large datasets, control WBS code recalculation using the [DataBound](https://blazor.syncfusion.com/documentation/gantt-chart/events#databound) and [RowDropped](https://blazor.syncfusion.com/documentation/gantt-chart/events#rowdropped) events. This approach ensures updates occur only when necessary, such as during drag-and-drop operations.

The example below demonstrates how WBS auto-update is conditionally triggered during row drag-and-drop, avoiding unnecessary recalculations during other interactions.

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
    private bool IsRowDragged { get; set; }
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
        public int Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentID { get; set; }
        public string WbsCode { get; set; }
        public string WbsPredecessor { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZryNEBeVUcysGjr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Limitations

The WBS feature has a few limitations in the Gantt component:

* Editing of the WBS code and WBS predecessor columns is not supported.
* Load on demand is not supported with the WBS feature.
* WBS Code and WBS Predecessor fields cannot be mapped directly from the data source as they are generated dynamically by the component based on task hierarchy.

## See Also
- [How to define columns manually in Blazor Gantt Chart?](https://blazor.syncfusion.com/documentation/gantt-chart/columns)
- [How to customize column headers in Blazor Gantt Chart?](https://blazor.syncfusion.com/documentation/gantt-chart/column-template)
- [How to use the column menu in Blazor Gantt Chart?](https://blazor.syncfusion.com/documentation/gantt-chart/column-menu)
- [How to reorder columns in Blazor Gantt Chart?](https://ej2.syncfusion.com/blazor/documentation/gantt-chart/columns/column-reorder)
- [How to resize columns in Blazor Gantt Chart?](https://ej2.syncfusion.com/blazor/documentation/gantt-chart/columns/column-resizing)
- [How to use column templates in Blazor Gantt Chart?](https://blazor.syncfusion.com/documentation/gantt-chart/column-template)