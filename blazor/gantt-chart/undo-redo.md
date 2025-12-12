---
layout: post
title: Undo and redo in Blazor Gantt Chart Component | Syncfusion
description: Learn how to enable, configure, and handle undo and redo actions in the Syncfusion Blazor Gantt Chart component, including keyboard shortcuts and supported actions.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Undo and redo in Blazor Gantt Chart Component

## Overview

The Syncfusion® Blazor Gantt component includes built-in undo and redo functionality to revert or restore recent changes. This feature improves editing efficiency, reduces errors, and supports quick recovery from accidental modifications.

## Enable undo and redo

The Undo feature reverts the most recent action performed in the Blazor Gantt Chart, including changes to tasks, dependencies, and other supported operations.

The Redo feature can reapply an action that was previously undone using the Undo feature.

The undo redo feature can be enabled in Gantt by using the [EnableUndoRedo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_EnableUndoRedo) property.

Use the built-in toolbar items to perform undo and redo actions.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt ID="GanttChart" DataSource="@TaskCollection" Height="500px"        Width="100%" HighlightWeekends="true" EnableUndoRedo="true" UndoRedoActions="@undoRedoActions"
            Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Undo", "Redo", "ZoomIn", "ZoomOut", "ZoomToFit", "PrevTimeSpan", "NextTimeSpan" })"
        TreeColumnIndex="1" EnableContextMenu="true" AllowSorting="true" ShowColumnMenu="true" AllowResizing="true" AllowReordering="true" AllowFiltering="true">
        <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
            Dependency="Predecessor" ParentID="ParentId"></GanttTaskFields>
        <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true"></GanttEditSettings>
        <GanttColumns>
            <GanttColumn Field="TaskId" HeaderText="ID"></GanttColumn>
            <GanttColumn Field="TaskName" HeaderText="Task Name" Width="250" ClipMode="Syncfusion.Blazor.Grids.ClipMode.EllipsisWithTooltip"></GanttColumn>
            <GanttColumn Field="StartDate" HeaderText="Start Date"></GanttColumn>
            <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
            <GanttColumn Field="Duration" HeaderText="Duration"></GanttColumn>
            <GanttColumn Field="Progress" HeaderText="Progress"></GanttColumn>
        </GanttColumns>
        <GanttSplitterSettings ColumnIndex="2"></GanttSplitterSettings>
    <GanttLabelSettings RightLabel="TaskName" TValue="TaskModel"></GanttLabelSettings>
</SfGantt>
@code{
    public List<TaskModel> TaskCollection { get; set; } = new();
    private List<GanttUndoRedoAction> undoRedoActions = new List<GanttUndoRedoAction> {
        GanttUndoRedoAction.Sort, GanttUndoRedoAction.Add, GanttUndoRedoAction.ColumnReorder, GanttUndoRedoAction.TaskbarEdit,
        GanttUndoRedoAction.ColumnState, GanttUndoRedoAction.Edit, GanttUndoRedoAction.Filter, GanttUndoRedoAction.NextTimeSpan, GanttUndoRedoAction.PreviousTimeSpan, GanttUndoRedoAction.Search,GanttUndoRedoAction.Delete,
        GanttUndoRedoAction.ZoomIn, GanttUndoRedoAction.ZoomOut, GanttUndoRedoAction.ZoomToFit,GanttUndoRedoAction.Collapse,GanttUndoRedoAction.Expand,GanttUndoRedoAction.SplitterResize
    };
    protected override void OnInitialized()
    {
        this.TaskCollection = GetUndoRedoData();
    }
    public class TaskModel
    {
        public int TaskId { get; set; }
        public string? TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Duration { get; set; }
        public int Progress { get; set; }
        public string? Predecessor { get; set; }
        public int? ParentId { get; set; }
    }
    public static List<TaskModel> GetUndoRedoData()
    {
        List<TaskModel> Tasks = new List<TaskModel>
        {
            new TaskModel { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2025, 11, 01), EndDate = new DateTime(2025, 11, 02), Duration = "2", Progress = 100 },
            new TaskModel { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2025, 11, 01), EndDate = new DateTime(2025, 11, 03), Duration = "3", Progress = 100, ParentId = 1 },
            new TaskModel { TaskId = 3, TaskName = "Site Analyze", StartDate = new DateTime(2025, 11, 02), EndDate = new DateTime(2025, 11, 03), Duration = "2", Progress = 90, ParentId = 1, },
            new TaskModel { TaskId = 4, TaskName = "Perform soil test", StartDate = new DateTime(2025, 11, 03), EndDate = new DateTime(2025, 11, 05), Duration = "3", Progress = 0, },
            new TaskModel { TaskId = 5, TaskName = "Soil test approval", StartDate = new DateTime(2025, 11, 03), EndDate = new DateTime(2025, 11, 04), Duration = "2", Progress = 0, ParentId = 4 },
            new TaskModel { TaskId = 6, TaskName = "Project estimation", StartDate = new DateTime(2025, 11, 05), EndDate = new DateTime(2025, 11, 05), Duration = "0", Progress = 0, ParentId = 4},
            new TaskModel { TaskId = 7, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2025, 11, 06), EndDate = new DateTime(2025, 11, 09), Duration = "4", Progress = 0},
            new TaskModel { TaskId = 8, TaskName = "List materials", StartDate = new DateTime(2025, 11, 06), EndDate = new DateTime(2025, 11, 07), Duration = "2", Progress = 0, ParentId = 7 },
            new TaskModel { TaskId = 9, TaskName = "Estimation approval", StartDate = new DateTime(2025, 11, 08), EndDate = new DateTime(2025, 11, 09), Duration = "2", Progress = 0, ParentId = 7 },
            new TaskModel { TaskId = 10, TaskName = "Building approval", StartDate = new DateTime(2025, 11, 10), EndDate = new DateTime(2025, 11, 16), Duration = "7", Progress = 0 },
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZrIsLirBDkKyVlQ?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5" %}

## Configure undo and redo actions

By default, all supported actions are tracked. To limit which actions are recorded (for example, only edits and deletions), specify them via the [UndoRedoActions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_UndoRedoActions).

The following table shows built-in undo/redo actions:

| Built-in Undo/Redo Items | Actions |
|---------------------------|---------|
| Edit                     | Restores changes made during record edits (cell or dialog). |
| Delete                   | Restores deleted records. |
| Add                      | Restores newly added records. |
| ColumnReorder            | Restores column reorder operations. |
| Indent                   | Restores indent operations on records. |
| Outdent                  | Restores outdent operations on records. |
| ColumnResize             | Restores column width changes. |
| Sort                     | Restores column sorting changes. |
| Filter                   | Restores applied or cleared filters. |
| Search                   | Restores applied or cleared search text. |
| ZoomIn                   | Restores zoom-in actions on the timeline. |
| ZoomOut                  | Restores zoom-out actions on the timeline. |
| ZoomToFit                | Restores zoom-to-fit actions on the timeline. |
| ColumnState              | Restores show/hide column visibility changes. |
| RowDragAndDrop           | Restores row drag-and-drop reorder operations. |
| TaskbarDragAndDrop       | Restores taskbar drag-and-drop operations. |
| PreviousTimeSpan         | Restores navigation to the previous timespan. |
| NextTimeSpan             | Restores navigation to the next timespan. |
| SplitterResize           | Restores splitter position changes. |
| ColumnFreeze             | Restores column freeze or unfreeze changes. |
| TaskbarEdit              | Restores taskbar edits such as move, resize, progress update, and connector modifications. |
| Expand                   | Restores expand state changes on records. |
| Collapse                   | Restores collapse state changes on records. |


{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt ID="GanttChart" DataSource="@TaskCollection" Height="500px" Width="100%" HighlightWeekends="true" EnableUndoRedo="true" UndoRedoActions="@undoRedoActions"
            Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Undo", "Redo", "ZoomIn", "ZoomOut", "ZoomToFit", "PrevTimeSpan", "NextTimeSpan" })"
        TreeColumnIndex="1" EnableContextMenu="true"  AllowFiltering="true">
        <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
            Dependency="Predecessor" ParentID="ParentId"></GanttTaskFields>
        <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true"></GanttEditSettings>
        <GanttColumns>
            <GanttColumn Field="TaskId" HeaderText="ID"></GanttColumn>
            <GanttColumn Field="TaskName" HeaderText="Task Name" Width="250" ClipMode="Syncfusion.Blazor.Grids.ClipMode.EllipsisWithTooltip"></GanttColumn>
            <GanttColumn Field="StartDate" HeaderText="Start Date"></GanttColumn>
            <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
            <GanttColumn Field="Duration" HeaderText="Duration"></GanttColumn>
            <GanttColumn Field="Progress" HeaderText="Progress"></GanttColumn>
        </GanttColumns>
        <GanttSplitterSettings ColumnIndex="2"></GanttSplitterSettings>
    <GanttLabelSettings RightLabel="TaskName" TValue="TaskModel"></GanttLabelSettings>
</SfGantt>
@code{
    public List<TaskModel> TaskCollection { get; set; } = new();
    private List<GanttUndoRedoAction> undoRedoActions = new List<GanttUndoRedoAction> { GanttUndoRedoAction.Add, GanttUndoRedoAction.TaskbarEdit,
        GanttUndoRedoAction.Edit, GanttUndoRedoAction.Filter, GanttUndoRedoAction.NextTimeSpan, GanttUndoRedoAction.PreviousTimeSpan,GanttUndoRedoAction.Delete,
        GanttUndoRedoAction.ZoomIn, GanttUndoRedoAction.ZoomOut, GanttUndoRedoAction.ZoomToFit,GanttUndoRedoAction.Collapse,GanttUndoRedoAction.Expand, GanttUndoRedoAction.SplitterResize
    };
    protected override void OnInitialized()
    {
        this.TaskCollection = GetUndoRedoData();
    }
    public class TaskModel
    {
        public int TaskId { get; set; }
        public string? TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Duration { get; set; }
        public int Progress { get; set; }
        public string? Predecessor { get; set; }
        public int? ParentId { get; set; }
    }
    public static List<TaskModel> GetUndoRedoData()
    {
        List<TaskModel> Tasks = new List<TaskModel>
        {
            new TaskModel { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2025, 11, 01), EndDate = new DateTime(2025, 11, 02), Duration = "2", Progress = 100 },
            new TaskModel { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2025, 11, 01), EndDate = new DateTime(2025, 11, 03), Duration = "3", Progress = 100, ParentId = 1 },
            new TaskModel { TaskId = 3, TaskName = "Site Analyze", StartDate = new DateTime(2025, 11, 02), EndDate = new DateTime(2025, 11, 03), Duration = "2", Progress = 90, ParentId = 1, },
            new TaskModel { TaskId = 4, TaskName = "Perform soil test", StartDate = new DateTime(2025, 11, 03), EndDate = new DateTime(2025, 11, 05), Duration = "3", Progress = 0, },
            new TaskModel { TaskId = 5, TaskName = "Soil test approval", StartDate = new DateTime(2025, 11, 03), EndDate = new DateTime(2025, 11, 04), Duration = "2", Progress = 0, ParentId = 4 },
            new TaskModel { TaskId = 6, TaskName = "Project estimation", StartDate = new DateTime(2025, 11, 05), EndDate = new DateTime(2025, 11, 05), Duration = "0", Progress = 0, ParentId = 4},
            new TaskModel { TaskId = 7, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2025, 11, 06), EndDate = new DateTime(2025, 11, 09), Duration = "4", Progress = 0},
            new TaskModel { TaskId = 8, TaskName = "List materials", StartDate = new DateTime(2025, 11, 06), EndDate = new DateTime(2025, 11, 07), Duration = "2", Progress = 0, ParentId = 7 },
            new TaskModel { TaskId = 9, TaskName = "Estimation approval", StartDate = new DateTime(2025, 11, 08), EndDate = new DateTime(2025, 11, 09), Duration = "2", Progress = 0, ParentId = 7 },
            new TaskModel { TaskId = 10, TaskName = "Building approval", StartDate = new DateTime(2025, 11, 10), EndDate = new DateTime(2025, 11, 16), Duration = "7", Progress = 0 },
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjVoiBMLhDblevvL?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5" %}

## Configure undo redo step count

The Syncfusion® Blazor Gantt component allows limiting the number of undo and redo actions stored in the history of the Gantt chart. Control the number of stored history entries using [MaxUndoRedoSteps](
https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_MaxUndoRedoSteps).
The default capacity is 20. When the count exceeds this value, the oldest entry is discarded and the newest action is appended, maintaining consistent memory usage.

The following example demonstrates configuring the maximum number of undo and redo steps.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt ID="GanttChart" DataSource="@TaskCollection" Height="500px" Width="100%" HighlightWeekends="true" EnableUndoRedo="true" UndoRedoActions="@undoRedoActions"
            Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Undo", "Redo", "ZoomIn", "ZoomOut", "ZoomToFit", "PrevTimeSpan", "NextTimeSpan" })"
         TreeColumnIndex="1" EnableContextMenu="true" AllowFiltering="true" MaxUndoRedoSteps="5">
        <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
            Dependency="Predecessor" ParentID="ParentId"></GanttTaskFields>
        <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true"></GanttEditSettings>
        <GanttColumns>
            <GanttColumn Field="TaskId" HeaderText="ID"></GanttColumn>
            <GanttColumn Field="TaskName" HeaderText="Task Name" Width="250" ClipMode="Syncfusion.Blazor.Grids.ClipMode.EllipsisWithTooltip"></GanttColumn>
            <GanttColumn Field="StartDate" HeaderText="Start Date"></GanttColumn>
            <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
            <GanttColumn Field="Duration" HeaderText="Duration"></GanttColumn>
            <GanttColumn Field="Progress" HeaderText="Progress"></GanttColumn>
        </GanttColumns>
        <GanttSplitterSettings ColumnIndex="2"></GanttSplitterSettings>
    <GanttLabelSettings RightLabel="TaskName" TValue="TaskModel"></GanttLabelSettings>
</SfGantt>
@code{
    public List<TaskModel> TaskCollection { get; set; } = new();
    private List<GanttUndoRedoAction> undoRedoActions = new List<GanttUndoRedoAction> { GanttUndoRedoAction.Add, GanttUndoRedoAction.TaskbarEdit,
        GanttUndoRedoAction.Edit, GanttUndoRedoAction.Filter, GanttUndoRedoAction.NextTimeSpan, GanttUndoRedoAction.PreviousTimeSpan,GanttUndoRedoAction.Delete,
        GanttUndoRedoAction.ZoomIn, GanttUndoRedoAction.ZoomOut, GanttUndoRedoAction.ZoomToFit,GanttUndoRedoAction.Collapse,GanttUndoRedoAction.Expand, GanttUndoRedoAction.SplitterResize
    };
    protected override void OnInitialized()
    {
        this.TaskCollection = GetUndoRedoData();
    }
    public class TaskModel
    {
        public int TaskId { get; set; }
        public string? TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Duration { get; set; }
        public int Progress { get; set; }
        public string? Predecessor { get; set; }
        public int? ParentId { get; set; }
    }
    public static List<TaskModel> GetUndoRedoData()
    {
        List<TaskModel> Tasks = new List<TaskModel>
        {
            new TaskModel { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2025, 11, 01), EndDate = new DateTime(2025, 11, 02), Duration = "2", Progress = 100 },
            new TaskModel { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2025, 11, 01), EndDate = new DateTime(2025, 11, 03), Duration = "3", Progress = 100, ParentId = 1 },
            new TaskModel { TaskId = 3, TaskName = "Site Analyze", StartDate = new DateTime(2025, 11, 02), EndDate = new DateTime(2025, 11, 03), Duration = "2", Progress = 90, ParentId = 1, },
            new TaskModel { TaskId = 4, TaskName = "Perform soil test", StartDate = new DateTime(2025, 11, 03), EndDate = new DateTime(2025, 11, 05), Duration = "3", Progress = 0, },
            new TaskModel { TaskId = 5, TaskName = "Soil test approval", StartDate = new DateTime(2025, 11, 03), EndDate = new DateTime(2025, 11, 04), Duration = "2", Progress = 0, ParentId = 4 },
            new TaskModel { TaskId = 6, TaskName = "Project estimation", StartDate = new DateTime(2025, 11, 05), EndDate = new DateTime(2025, 11, 05), Duration = "0", Progress = 0, ParentId = 4},
            new TaskModel { TaskId = 7, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2025, 11, 06), EndDate = new DateTime(2025, 11, 09), Duration = "4", Progress = 0},
            new TaskModel { TaskId = 8, TaskName = "List materials", StartDate = new DateTime(2025, 11, 06), EndDate = new DateTime(2025, 11, 07), Duration = "2", Progress = 0, ParentId = 7 },
            new TaskModel { TaskId = 9, TaskName = "Estimation approval", StartDate = new DateTime(2025, 11, 08), EndDate = new DateTime(2025, 11, 09), Duration = "2", Progress = 0, ParentId = 7 },
            new TaskModel { TaskId = 10, TaskName = "Building approval", StartDate = new DateTime(2025, 11, 10), EndDate = new DateTime(2025, 11, 16), Duration = "7", Progress = 0 },
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNrSMrMVVXPqZxza?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5" %}

## Programmatic undo and redo

Undo Redo actions can be triggered dynamically or through external controls using the following methods:

* **Undo** – Use `UndoAsync` when an external Undo button is clicked. This method reverts the most recent tracked change from the undo collection, restoring the previous state of the Gantt chart.

* **Redo** – Use `RedoAsync` when an external Redo button is clicked. This method reapplies the most recently undone change from the redo collection, restoring the state before the undo action.

The following example demonstrates configuring the undo redo public methods.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<button @onclick="@UndoMethod">Undo</button>
<button @onclick="@RedoMethod">Redo</button>
<SfGantt ID="GanttChart" @ref="GanttInstance" DataSource="@TaskCollection" Height="500px" Width="100%" HighlightWeekends="true" EnableUndoRedo="true" UndoRedoActions="@undoRedoActions"
            Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Undo", "Redo", "ZoomIn", "ZoomOut", "ZoomToFit", "PrevTimeSpan", "NextTimeSpan" })"
         TreeColumnIndex="1" EnableContextMenu="true" AllowFiltering="true" MaxUndoRedoSteps="5">
        <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
            Dependency="Predecessor" ParentID="ParentId"></GanttTaskFields>
        <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true"></GanttEditSettings>
        <GanttColumns>
            <GanttColumn Field="TaskId" HeaderText="ID"></GanttColumn>
            <GanttColumn Field="TaskName" HeaderText="Task Name" Width="250" ClipMode="Syncfusion.Blazor.Grids.ClipMode.EllipsisWithTooltip"></GanttColumn>
            <GanttColumn Field="StartDate" HeaderText="Start Date"></GanttColumn>
            <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
            <GanttColumn Field="Duration" HeaderText="Duration"></GanttColumn>
            <GanttColumn Field="Progress" HeaderText="Progress"></GanttColumn>
        </GanttColumns>
        <GanttSplitterSettings ColumnIndex="2"></GanttSplitterSettings>
    <GanttLabelSettings RightLabel="TaskName" TValue="TaskModel"></GanttLabelSettings>
</SfGantt>
@code{
    private SfGantt<TaskModel> GanttInstance;
    public List<TaskModel> TaskCollection { get; set; } = new();
    private List<GanttUndoRedoAction> undoRedoActions = new List<GanttUndoRedoAction> { GanttUndoRedoAction.Add, GanttUndoRedoAction.TaskbarEdit,
        GanttUndoRedoAction.Edit, GanttUndoRedoAction.Filter, GanttUndoRedoAction.NextTimeSpan, GanttUndoRedoAction.PreviousTimeSpan,GanttUndoRedoAction.Delete,
        GanttUndoRedoAction.ZoomIn, GanttUndoRedoAction.ZoomOut, GanttUndoRedoAction.ZoomToFit,GanttUndoRedoAction.Collapse,GanttUndoRedoAction.Expand, GanttUndoRedoAction.SplitterResize
    };
    protected override void OnInitialized()
    {
        this.TaskCollection = GetUndoRedoData();
    }
    private async Task UndoMethod()
    {
        await GanttInstance.UndoAsync();
    }
    private async Task RedoMethod()
    {
        await GanttInstance.RedoAsync();
    }
    public class TaskModel
    {
        public int TaskId { get; set; }
        public string? TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Duration { get; set; }
        public int Progress { get; set; }
        public string? Predecessor { get; set; }
        public int? ParentId { get; set; }
    }
    public static List<TaskModel> GetUndoRedoData()
    {
        List<TaskModel> Tasks = new List<TaskModel>
        {
            new TaskModel { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2025, 11, 01), EndDate = new DateTime(2025, 11, 02), Duration = "2", Progress = 100 },
            new TaskModel { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2025, 11, 01), EndDate = new DateTime(2025, 11, 03), Duration = "3", Progress = 100, ParentId = 1 },
            new TaskModel { TaskId = 3, TaskName = "Site Analyze", StartDate = new DateTime(2025, 11, 02), EndDate = new DateTime(2025, 11, 03), Duration = "2", Progress = 90, ParentId = 1, },
            new TaskModel { TaskId = 4, TaskName = "Perform soil test", StartDate = new DateTime(2025, 11, 03), EndDate = new DateTime(2025, 11, 05), Duration = "3", Progress = 0, },
            new TaskModel { TaskId = 5, TaskName = "Soil test approval", StartDate = new DateTime(2025, 11, 03), EndDate = new DateTime(2025, 11, 04), Duration = "2", Progress = 0, ParentId = 4 },
            new TaskModel { TaskId = 6, TaskName = "Project estimation", StartDate = new DateTime(2025, 11, 05), EndDate = new DateTime(2025, 11, 05), Duration = "0", Progress = 0, ParentId = 4},
            new TaskModel { TaskId = 7, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2025, 11, 06), EndDate = new DateTime(2025, 11, 09), Duration = "4", Progress = 0},
            new TaskModel { TaskId = 8, TaskName = "List materials", StartDate = new DateTime(2025, 11, 06), EndDate = new DateTime(2025, 11, 07), Duration = "2", Progress = 0, ParentId = 7 },
            new TaskModel { TaskId = 9, TaskName = "Estimation approval", StartDate = new DateTime(2025, 11, 08), EndDate = new DateTime(2025, 11, 09), Duration = "2", Progress = 0, ParentId = 7 },
            new TaskModel { TaskId = 10, TaskName = "Building approval", StartDate = new DateTime(2025, 11, 10), EndDate = new DateTime(2025, 11, 16), Duration = "7", Progress = 0 },
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjLyiBMhrNQxdzjs?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5" %}

## Notes

>* `EnableUndoRedo` must be set to **true** for keyboard shortcuts and programmatic APIs to operate.
>* Only actions listed in `UndoRedoActions` are recorded in history.
>* History length is constrained by `MaxUndoRedoSteps`; older entries are discarded when the limit is exceeded.

## See Also

* [How to add undo/redo events?]()
* [What are the keys used for undo/redo?]()