---
layout: post
title: Undo and Redo in Blazor Gantt Chart Component | Syncfusion
description: Learn how to enable, configure, and handle undo and redo actions in the Syncfusion Blazor Gantt Chart, including keyboard shortcuts and supported actions.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Undo and Redo in Blazor Gantt Chart Component

The Syncfusion® Blazor Gantt Chart component includes built-in undo and redo functionality to revert or restore recent changes. This support improves editing efficiency, reduces errors, and supports quick recovery from accidental modifications.

## Enable undo and redo

The **Undo** in the Blazor Gantt Chart reverts the most recent action, such as modifications to tasks, dependencies, and other supported operations, while the **Redo** reapplies an action that was previously undone using the **Undo** option. This functionality can be enabled by setting the [EnableUndoRedo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_EnableUndoRedo) property in the Gantt Chart component. When enabled, undo and redo operations can be performed using the built-in toolbar items, and the [OnUndoRedo](https://blazor.syncfusion.com/documentation/gantt-chart/events#onundoredo) event is triggered after each undo or redo operation is completed.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt ID="GanttChart" DataSource="@TaskCollection" Height="500px" Width="100%" HighlightWeekends="true" EnableUndoRedo="true" UndoRedoActions="@undoRedoActions"
            Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Undo", "Redo", "ZoomIn", "ZoomOut", "ZoomToFit", "PrevTimeSpan", "NextTimeSpan" })"
        TreeColumnIndex="1" EnableContextMenu="true" AllowSorting="true" ShowColumnMenu="true" AllowResizing="true" AllowReordering="true" AllowFiltering="true">
        <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
            Dependency="Predecessor" ParentID="ParentID"></GanttTaskFields>
        <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true"></GanttEditSettings>
        <GanttColumns>
            <GanttColumn Field="TaskID" HeaderText="ID"></GanttColumn>
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
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public string Predecessor { get; set; }
        public int? ParentID { get; set; }
    }
    public static List<TaskModel> GetUndoRedoData()
    {
        List<TaskModel> Tasks = new List<TaskModel>
        {
            new TaskModel { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2025, 11, 01), EndDate = new DateTime(2025, 11, 02), Duration = "2", Progress = 100 },
            new TaskModel { TaskID = 2, TaskName = "Identify site location", StartDate = new DateTime(2025, 11, 01), EndDate = new DateTime(2025, 11, 03), Duration = "3", Progress = 100, ParentID = 1 },
            new TaskModel { TaskID = 3, TaskName = "Site analyze", StartDate = new DateTime(2025, 11, 02), EndDate = new DateTime(2025, 11, 03), Duration = "2", Progress = 90, ParentID = 1, },
            new TaskModel { TaskID = 4, TaskName = "Perform soil test", StartDate = new DateTime(2025, 11, 03), EndDate = new DateTime(2025, 11, 05), Duration = "3", Progress = 0, },
            new TaskModel { TaskID = 5, TaskName = "Soil test approval", StartDate = new DateTime(2025, 11, 03), EndDate = new DateTime(2025, 11, 04), Duration = "2", Progress = 0, ParentID = 4 },
            new TaskModel { TaskID = 6, TaskName = "Project estimation", StartDate = new DateTime(2025, 11, 05), EndDate = new DateTime(2025, 11, 05), Duration = "0", Progress = 0, ParentID = 4},
            new TaskModel { TaskID = 7, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2025, 11, 06), EndDate = new DateTime(2025, 11, 09), Duration = "4", Progress = 0},
            new TaskModel { TaskID = 8, TaskName = "List materials", StartDate = new DateTime(2025, 11, 06), EndDate = new DateTime(2025, 11, 07), Duration = "2", Progress = 0, ParentID = 7 },
            new TaskModel { TaskID = 9, TaskName = "Estimation approval", StartDate = new DateTime(2025, 11, 08), EndDate = new DateTime(2025, 11, 09), Duration = "2", Progress = 0, ParentID = 7 },
            new TaskModel { TaskID = 10, TaskName = "Building approval", StartDate = new DateTime(2025, 11, 10), EndDate = new DateTime(2025, 11, 16), Duration = "7", Progress = 0 },
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZhysVLnUOLGhknU?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> Define actions in the [UndoRedoActions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_UndoRedoActions) property to record them in the **Undo/Redo** history. Only actions defined in this property will be recorded.

## Configure undo and redo actions

By default, all supported actions are tracked for undo and redo operations. To restrict the actions that are recorded, such as including only edits and deletions, the [UndoRedoActions](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_UndoRedoActions) property can be configured.

The following table lists the built-in actions that can be included for undo and redo functionality:

| Built-in Undo/Redo Items | Actions                                                                                    |
| ------------------------ | ------------------------------------------------------------------------------------------ |
| Edit                     | Restores changes made during record edits (cell or dialog).                                |
| Delete                   | Restores deleted records.                                                                  |
| Add                      | Restores newly added records.                                                              |
| ColumnReorder            | Restores column reorder operations.                                                        |
| Indent                   | Restores indent operations on records.                                                     |
| Outdent                  | Restores outdent operations on records.                                                    |
| ColumnResize             | Restores column width changes.                                                             |
| Sort                     | Restores column sorting changes.                                                           |
| Filter                   | Restores applied or cleared filters.                                                       |
| Search                   | Restores applied or cleared search text.                                                   |
| ZoomIn                   | Restores zoom-in actions on the timeline.                                                  |
| ZoomOut                  | Restores zoom-out actions on the timeline.                                                 |
| ZoomToFit                | Restores zoom-to-fit actions on the timeline.                                              |
| ColumnState              | Restores show/hide column visibility changes.                                              |
| RowDragAndDrop           | Restores row drag-and-drop reorder operations.                                             |
| TaskbarDragAndDrop       | Restores taskbar drag-and-drop operations.                                                 |
| PreviousTimeSpan         | Restores navigation to the previous timespan.                                              |
| NextTimeSpan             | Restores navigation to the next timespan.                                                  |
| SplitterResize           | Restores splitter position changes.                                                        |
| ColumnFreeze             | Restores column freeze or unfreeze changes.                                                |
| TaskbarEdit              | Restores taskbar edits such as move, resize, progress update, and connector modifications. |
| Expand                   | Restores expand state changes on records.                                                  |
| Collapse                 | Restores collapse state changes on records.                                                |


{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt ID="GanttChart" DataSource="@TaskCollection" Height="500px" Width="100%" HighlightWeekends="true" EnableUndoRedo="true" UndoRedoActions="@undoRedoActions"
            Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Undo", "Redo", "ZoomIn", "ZoomOut", "ZoomToFit", "PrevTimeSpan", "NextTimeSpan" })"
        TreeColumnIndex="1" EnableContextMenu="true"  AllowFiltering="true">
        <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
            Dependency="Predecessor" ParentID="ParentID"></GanttTaskFields>
        <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true"></GanttEditSettings>
        <GanttColumns>
            <GanttColumn Field="TaskID" HeaderText="ID"></GanttColumn>
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
        public int TaskID { get; set; }
        public string? TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Duration { get; set; }
        public int Progress { get; set; }
        public string? Predecessor { get; set; }
        public int? ParentID { get; set; }
    }
    public static List<TaskModel> GetUndoRedoData()
    {
        List<TaskModel> Tasks = new List<TaskModel>
        {
            new TaskModel { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2025, 11, 01), EndDate = new DateTime(2025, 11, 02), Duration = "2", Progress = 100 },
            new TaskModel { TaskID = 2, TaskName = "Identify site location", StartDate = new DateTime(2025, 11, 01), EndDate = new DateTime(2025, 11, 03), Duration = "3", Progress = 100, ParentID = 1 },
            new TaskModel { TaskID = 3, TaskName = "Site analyze", StartDate = new DateTime(2025, 11, 02), EndDate = new DateTime(2025, 11, 03), Duration = "2", Progress = 90, ParentID = 1, },
            new TaskModel { TaskID = 4, TaskName = "Perform soil test", StartDate = new DateTime(2025, 11, 03), EndDate = new DateTime(2025, 11, 05), Duration = "3", Progress = 0, },
            new TaskModel { TaskID = 5, TaskName = "Soil test approval", StartDate = new DateTime(2025, 11, 03), EndDate = new DateTime(2025, 11, 04), Duration = "2", Progress = 0, ParentID = 4 },
            new TaskModel { TaskID = 6, TaskName = "Project estimation", StartDate = new DateTime(2025, 11, 05), EndDate = new DateTime(2025, 11, 05), Duration = "0", Progress = 0, ParentID = 4},
            new TaskModel { TaskID = 7, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2025, 11, 06), EndDate = new DateTime(2025, 11, 09), Duration = "4", Progress = 0},
            new TaskModel { TaskID = 8, TaskName = "List materials", StartDate = new DateTime(2025, 11, 06), EndDate = new DateTime(2025, 11, 07), Duration = "2", Progress = 0, ParentID = 7 },
            new TaskModel { TaskID = 9, TaskName = "Estimation approval", StartDate = new DateTime(2025, 11, 08), EndDate = new DateTime(2025, 11, 09), Duration = "2", Progress = 0, ParentID = 7 },
            new TaskModel { TaskID = 10, TaskName = "Building approval", StartDate = new DateTime(2025, 11, 10), EndDate = new DateTime(2025, 11, 16), Duration = "7", Progress = 0 },
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXLeCVVdgOKzYnpL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Configure undo redo step count

The Syncfusion® Blazor Gantt Chart component provides an option to limit the number of undo and redo actions stored in the history. The number of stored history entries can be controlled using the [MaxUndoRedoSteps](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_MaxUndoRedoSteps) property. The default capacity is `20`. When the count exceeds this value, the oldest entry is discarded and the newest action is appended, ensuring consistent memory usage.

The following example illustrates how to configure the maximum number of undo and redo steps.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt ID="GanttChart" DataSource="@TaskCollection" Height="500px" Width="100%" HighlightWeekends="true" EnableUndoRedo="true" UndoRedoActions="@undoRedoActions"
            Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Undo", "Redo", "ZoomIn", "ZoomOut", "ZoomToFit", "PrevTimeSpan", "NextTimeSpan" })"
         TreeColumnIndex="1" EnableContextMenu="true" AllowFiltering="true" MaxUndoRedoSteps="5">
        <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
            Dependency="Predecessor" ParentID="ParentID"></GanttTaskFields>
        <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true"></GanttEditSettings>
        <GanttColumns>
            <GanttColumn Field="TaskID" HeaderText="ID"></GanttColumn>
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
        public int TaskID { get; set; }
        public string? TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Duration { get; set; }
        public int Progress { get; set; }
        public string? Predecessor { get; set; }
        public int? ParentID { get; set; }
    }
    public static List<TaskModel> GetUndoRedoData()
    {
        List<TaskModel> Tasks = new List<TaskModel>
        {
            new TaskModel { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2025, 11, 01), EndDate = new DateTime(2025, 11, 02), Duration = "2", Progress = 100 },
            new TaskModel { TaskID = 2, TaskName = "Identify site location", StartDate = new DateTime(2025, 11, 01), EndDate = new DateTime(2025, 11, 03), Duration = "3", Progress = 100, ParentID = 1 },
            new TaskModel { TaskID = 3, TaskName = "Site analyze", StartDate = new DateTime(2025, 11, 02), EndDate = new DateTime(2025, 11, 03), Duration = "2", Progress = 90, ParentID = 1, },
            new TaskModel { TaskID = 4, TaskName = "Perform soil test", StartDate = new DateTime(2025, 11, 03), EndDate = new DateTime(2025, 11, 05), Duration = "3", Progress = 0, },
            new TaskModel { TaskID = 5, TaskName = "Soil test approval", StartDate = new DateTime(2025, 11, 03), EndDate = new DateTime(2025, 11, 04), Duration = "2", Progress = 0, ParentID = 4 },
            new TaskModel { TaskID = 6, TaskName = "Project estimation", StartDate = new DateTime(2025, 11, 05), EndDate = new DateTime(2025, 11, 05), Duration = "0", Progress = 0, ParentID = 4},
            new TaskModel { TaskID = 7, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2025, 11, 06), EndDate = new DateTime(2025, 11, 09), Duration = "4", Progress = 0},
            new TaskModel { TaskID = 8, TaskName = "List materials", StartDate = new DateTime(2025, 11, 06), EndDate = new DateTime(2025, 11, 07), Duration = "2", Progress = 0, ParentID = 7 },
            new TaskModel { TaskID = 9, TaskName = "Estimation approval", StartDate = new DateTime(2025, 11, 08), EndDate = new DateTime(2025, 11, 09), Duration = "2", Progress = 0, ParentID = 7 },
            new TaskModel { TaskID = 10, TaskName = "Building approval", StartDate = new DateTime(2025, 11, 10), EndDate = new DateTime(2025, 11, 16), Duration = "7", Progress = 0 },
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDVSihLnqYTVMXfX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Performing undo and redo actions via methods

The Blazor Gantt Chart supports performing undo and redo operations programmatically using the [UndoAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_UndoAsync) and [RedoAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_RedoAsync) methods. These methods provide an efficient way to revert or reapply changes through external controls.

In the following example, clicking an external button invokes the `UndoAsync` method to revert the most recent change and the `RedoAsync` method to restore the previously undone action.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Buttons

<SfButton @onclick="@UndoHandler">Undo</SfButton>
<SfButton @onclick="@RedoHandler">Redo</SfButton>
<SfGantt ID="GanttChart" @ref="GanttInstance" DataSource="@TaskCollection" Height="500px" Width="100%" HighlightWeekends="true" EnableUndoRedo="true" UndoRedoActions="@undoRedoActions"
            Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Undo", "Redo", "ZoomIn", "ZoomOut", "ZoomToFit", "PrevTimeSpan", "NextTimeSpan" })"
         TreeColumnIndex="1" EnableContextMenu="true" AllowFiltering="true" MaxUndoRedoSteps="5">
        <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
            Dependency="Predecessor" ParentID="ParentID"></GanttTaskFields>
        <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true"></GanttEditSettings>
        <GanttColumns>
            <GanttColumn Field="TaskID" HeaderText="ID"></GanttColumn>
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

    /// <summary>
    /// Handles the undo action by invoking the Gantt Chart component's asynchronous undo logic.
    /// </summary>
    private async Task UndoHandler()
    {
        await GanttInstance.UndoAsync();
    }

    /// <summary>
    /// Handles the redo action by invoking the Gantt Chart component's asynchronous redo logic.
    /// </summary>
    private async Task RedoHandler()
    {
        await GanttInstance.RedoAsync();
    }
    public class TaskModel
    {
        public int TaskID { get; set; }
        public string? TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Duration { get; set; }
        public int Progress { get; set; }
        public string? Predecessor { get; set; }
        public int? ParentID { get; set; }
    }
    public static List<TaskModel> GetUndoRedoData()
    {
        List<TaskModel> Tasks = new List<TaskModel>
        {
            new TaskModel { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2025, 11, 01), EndDate = new DateTime(2025, 11, 02), Duration = "2", Progress = 100 },
            new TaskModel { TaskID = 2, TaskName = "Identify site location", StartDate = new DateTime(2025, 11, 01), EndDate = new DateTime(2025, 11, 03), Duration = "3", Progress = 100, ParentID = 1 },
            new TaskModel { TaskID = 3, TaskName = "Site analyze", StartDate = new DateTime(2025, 11, 02), EndDate = new DateTime(2025, 11, 03), Duration = "2", Progress = 90, ParentID = 1, },
            new TaskModel { TaskID = 4, TaskName = "Perform soil test", StartDate = new DateTime(2025, 11, 03), EndDate = new DateTime(2025, 11, 05), Duration = "3", Progress = 0, },
            new TaskModel { TaskID = 5, TaskName = "Soil test approval", StartDate = new DateTime(2025, 11, 03), EndDate = new DateTime(2025, 11, 04), Duration = "2", Progress = 0, ParentID = 4 },
            new TaskModel { TaskID = 6, TaskName = "Project estimation", StartDate = new DateTime(2025, 11, 05), EndDate = new DateTime(2025, 11, 05), Duration = "0", Progress = 0, ParentID = 4},
            new TaskModel { TaskID = 7, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2025, 11, 06), EndDate = new DateTime(2025, 11, 09), Duration = "4", Progress = 0},
            new TaskModel { TaskID = 8, TaskName = "List materials", StartDate = new DateTime(2025, 11, 06), EndDate = new DateTime(2025, 11, 07), Duration = "2", Progress = 0, ParentID = 7 },
            new TaskModel { TaskID = 9, TaskName = "Estimation approval", StartDate = new DateTime(2025, 11, 08), EndDate = new DateTime(2025, 11, 09), Duration = "2", Progress = 0, ParentID = 7 },
            new TaskModel { TaskID = 10, TaskName = "Building approval", StartDate = new DateTime(2025, 11, 10), EndDate = new DateTime(2025, 11, 16), Duration = "7", Progress = 0 },
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtBSCBrRKaRSRqgS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## See Also
- [How to add undo/redo events?](https://blazor.syncfusion.com/documentation/gantt-chart/events#onundoredo)
- [What are the keys used for undo/redo?](https://blazor.syncfusion.com/documentation/gantt-chart/accessibility#undo-redo)