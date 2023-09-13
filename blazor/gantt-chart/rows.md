---
layout: post
title: Rows in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about Rows in Syncfusion Blazor Gantt Chart component and much more details.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Rows in Blazor Gantt Chart Component

Row represents task information from the data source, and it is possible to perform the following actions in Gantt Chart rows.

## Row height

It is possible to change the height of the row in Gantt Chart by setting row height in pixels to the [RowHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.IGantt.html#Syncfusion_Blazor_Gantt_IGantt_RowHeight) property. The following code example explains how to change the row height in Gantt Chart at load time.

```cshtml
@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" RowHeight=60 Height="450px" Width="900px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate"
                     Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
</SfGantt>

@code{
    private List<TaskData> TaskCollection { get; set; }

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
        public int? ParentId { get; set; }
    }

    private static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentId = 1, },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentId = 5, },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentId = 5, },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentId = 5, }
        };
        return Tasks;
    }
}
```

![Changing Row Height in Blazor Gantt Chart](images/blazor-gantt-chart-row-height.png)
<!-- {% previewsample "https://blazorplayground.syncfusion.com/embed/BjhqNQsaBGGDPqHn?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %} -->

## Expand or collapse row

In Gantt Chart, parent tasks are expanded/collapsed by using expand/collapse icons, expand all/collapse all toolbar items, and public methods. By default, all tasks in Gantt Chart are rendered in expanded state, but you can change this status using the properties below.

### Collapse all tasks at Gantt chart load

All tasks available in Gantt Chart are rendered in collapsed state by setting the [CollapseAllParentTasks](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_CollapseAllParentTasks) property as `true`. The following code example shows how to use this property.

```cshtml
@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" CollapseAllParentTasks="true" Height="450px" Width="900px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate"
                     Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
</SfGantt>

@code{
    private List<TaskData> TaskCollection { get; set; }

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
        public int? ParentId { get; set; }
    }

    private static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentId = 1, },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentId = 5, },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentId = 5, },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentId = 5, }
        };
        return Tasks;
    }
}
```

![Blazor Gantt Chart with Collapsed Row](images/blazor-gantt-chart-with-collapse-row.png)
<!-- {% previewsample "https://blazorplayground.syncfusion.com/embed/LZrgtwiarbjdKsDK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %} -->

### Define Expand/Collapse Status of Tasks

In Gantt Chart, you can render some tasks in collapsed state and some tasks in expanded state by defining expand status of the task in the data source. This value was mapped to Gantt Chart component by using [GanttTaskFields.ExpandState](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTaskFields.html#Syncfusion_Blazor_Gantt_GanttTaskFields_ExpandState) property. The following code example shows how to use this property.

```cshtml
@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" CollapseAllParentTasks="true" Height="450px" Width="900px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate"
                     Duration="Duration" Progress="Progress" ParentID="ParentId" ExpandState="isExpand">
    </GanttTaskFields>
</SfGantt>

@code{
    private List<TaskData> TaskCollection { get; set; }

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
        public int? ParentId { get; set; }
        public bool isExpand { get; set; }
    }

    private static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), isExpand = true },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentId = 1, },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), isExpand = false },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentId = 5, },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentId = 5, },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentId = 5, }
        };
        return Tasks;
    }
}
```

![Alt text](images/expandState.png) 

### Customize expand and collapse action

You can use [GanttEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html) to handle on expand action, `Expanding` and `Expanded` events will be triggered with current expanding row’s information. Similarly, on collapse action, `Collapsing` and `Collapsed` events will be triggered. Using these events and their arguments, you can customize the expand/collapse action. The following code example shows how to prevent the particular row from expand/collapse action using the `Expanding` and `Collapsing` events.

```cshtml
@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="900px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate"
                     Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttEvents Collapsing="Collapsing" Expanding="Expanding" TValue="TaskData"></GanttEvents>
</SfGantt>

@code{

    public void Collapsing(Syncfusion.Blazor.TreeGrid.RowCollapsingEventArgs<TaskData> args)
    {
        if (args.Data.TaskId == 1)
        {
            args.Cancel = true;
        }
    }
    public void Expanding(Syncfusion.Blazor.TreeGrid.RowExpandingEventArgs<TaskData> args)
    {
        if (args.Data.TaskId == 5)
        {
            args.Cancel = true;
        }
    }

    private List<TaskData> TaskCollection { get; set; }

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
        public int? ParentId { get; set; }
    }


    private static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentId = 1, },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentId = 5, },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentId = 5, },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentId = 5, }
        };
        return Tasks;
    }
}
```

<!-- {% previewsample "https://blazorplayground.syncfusion.com/embed/VthqtGskVldAZfVB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %} -->

## Drag and drop

You can dynamically rearrange the rows in the Gantt Chart component by using the [AllowRowDragAndDrop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AllowRowDragAndDrop) property. Using this property, row drag and drop can be enabled or disabled in Gantt. Using this feature, rows can be dropped above and below as a sibling or child to the existing rows.

```cshtml
@using Syncfusion.Blazor.Gantt
<SfGantt DataSource="@TaskCollection" Height="450px" Width="900px" TreeColumnIndex="1" AllowRowDragAndDrop="true">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
                     ParentID="ParentId">
    </GanttTaskFields>
</SfGantt>

@code{

    public void Collapsing(Syncfusion.Blazor.TreeGrid.RowCollapsingEventArgs<TaskData> args)
    {
        if (args.Data.TaskId == 1)
        {
            args.Cancel = true;
        }
    }
    public void Expanding(Syncfusion.Blazor.TreeGrid.RowExpandingEventArgs<TaskData> args)
    {
        if (args.Data.TaskId == 5)
        {
            args.Cancel = true;
        }
    }

    private List<TaskData> TaskCollection { get; set; }

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
        public int? ParentId { get; set; }
    }


    private static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentId = 1, },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentId = 5, },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentId = 5, },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentId = 5, }
        };
        return Tasks;
    }
}
```

<!-- {% previewsample "https://blazorplayground.syncfusion.com/embed/VtBgjmiuBOgQjTMd?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %} -->

### Multiple row drag and drop

Gantt also supports dragging multiple rows at a time and dropping them on any rows above, below, or at child positions. In Gantt, you can enable the multiple drag and drop by setting the [GanttSelectionSettings.Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttSelectionSettings.html) to `Multiple` and you should enable the [AllowRowDragAndDrop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AllowRowDragAndDrop) property.

```cshtml
@using Syncfusion.Blazor.Gantt
<SfGantt DataSource="@TaskCollection" Height="450px" Width="900px" TreeColumnIndex="1" AllowRowDragAndDrop="true">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
                     ParentID="ParentId">
    </GanttTaskFields>
    <GanttSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GanttSelectionSettings>
</SfGantt>

@code{

    public void Collapsing(Syncfusion.Blazor.TreeGrid.RowCollapsingEventArgs<TaskData> args)
    {
        if (args.Data.TaskId == 1)
        {
            args.Cancel = true;
        }
    }
    public void Expanding(Syncfusion.Blazor.TreeGrid.RowExpandingEventArgs<TaskData> args)
    {
        if (args.Data.TaskId == 5)
        {
            args.Cancel = true;
        }
    }

    private List<TaskData> TaskCollection { get; set; }

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
        public int? ParentId { get; set; }
    }


    private static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentId = 1, },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentId = 5, },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentId = 5, },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentId = 5, }
        };
        return Tasks;
    }
}
```

<!-- {% previewsample "https://blazorplayground.syncfusion.com/embed/BDBgZcWOrknhlxWj?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %} -->

### Drag and drop events

Several events are available to customize the row drag and drop action. The following table explains about the available events and their details.

Event Name |Description
-----|-----
`OnRowDragStart`  |Triggers when drag action starts in Gantt.
`RowDropped`  |Triggers when a drag row was dropped on the target row.

<!-- Customize row drag and drop action

In Gantt, the `OnRowDragStart` and `RowDropped` events are triggered on row drag and drop action. Using this event, you can prevent dragging of particular record, validate the drop position, and cancel the drop action based on the target record and dragged record. The following topics explains about this.

 Prevent dragging of particular record

You can prevent drag action of the particular record by setting the `Cancel` property to `true`, which is available in the `OnRowDragStart` event argument based on our requirement. In the following sample, drag action was restricted for first parent record and its child records.

```cshtml
@using Syncfusion.Blazor.Gantt
<SfGantt DataSource="@TaskCollection" Height="450px" Width="900px" TreeColumnIndex="1" AllowRowDragAndDrop="true">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
            ParentID="ParentId">
    </GanttTaskFields>
    <GanttEvents OnRowDragStart="rowDrag" TValue="TaskData"></GanttEvents>
</SfGantt>

@code{
    public List<TaskData> TaskCollection { get; set; }
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }
    public void rowDrag(RowDragEventArgs<TaskData> args) {
        if(args.Data[0].TaskId == 4) {
            args.Cancel = true;
        }
    }
    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
    }
    public static List <TaskData> GetTaskCollection() {
        List <TaskData> Tasks = new List <TaskData> () {
            new TaskData() {
                TaskId = 1,
                TaskName = "Project initiation",
                StartDate = new DateTime(2019, 03, 28),
                EndDate = new DateTime(2019, 07, 28),
                Duration="4"
            },
            new TaskData() {
                TaskId = 2,
                TaskName = "Identify Site location",
                StartDate = new DateTime(2019, 03, 29),
                Progress = 30,
                ParentId = 1,
                Duration="2",
            },
            new TaskData() {
                TaskId = 3,
                TaskName = "Perform soil test",
                StartDate = new DateTime(2019, 03, 29),
                ParentId = 1,
                Duration="4"
            },
            new TaskData() {
                TaskId = 4,
                TaskName = "Soil test approval",
                StartDate = new DateTime(2019, 03, 29),
                Duration = "4",
                Progress = 30,
                ParentId = 1
            },
            new TaskData() {
                TaskId = 5,
                TaskName = "Project estimation",
                StartDate = new DateTime(2019, 03, 29),
                EndDate = new DateTime(2019, 04, 2),
                Duration="4",
            },
            new TaskData() {
                TaskId = 6,
                TaskName = "Develop floor plan for estimation",
                StartDate = new DateTime(2019, 03, 29),
                Duration = "3",
                Progress = 30,
                ParentId = 5
            },
            new TaskData() {
                TaskId = 7,
                TaskName = "List materials",
                StartDate = new DateTime(2019, 04, 01),
                Duration = "3",
                Progress = 30,
                ParentId = 5
            },
            new TaskData() {
                TaskId = 8,
                TaskName = "Estimation approval",
                StartDate = new DateTime(2019, 04, 01),
                Duration = "2",
                ParentId = 5
            }
        };
        return Tasks;
    }
}
``` -->

### Perform row drag and drop action programmatically

Gantt provides option to perform row drag and drop action programmatically by using the [ReorderRowsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ReorderRowAsync_System_Double_System_Double_System_String_) method. This method can be used for any external actions like button click.
The following arguments are used to specify the positions to drag and drop a row:

* `FromIndexes`: Index value of source(dragging) row.
* `ToIndex`: Value of target index.
* `Position`: Drop positions such as above, below, or child.

The following code example shows how to drag and drop a row on button click action.

```cshtml
@using Syncfusion.Blazor.Gantt
<button @onclick="drag">Dynamic drag and drop</button>
<SfGantt @ref="Gantt" DataSource="@TaskCollection" Height="450px" Width="900px" TreeColumnIndex="1" AllowRowDragAndDrop="true">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
                     ParentID="ParentId">
    </GanttTaskFields>
</SfGantt>

@code{
    public SfGantt<TaskData> Gantt;
    private List<TaskData> TaskCollection { get; set; }
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }
    public void drag()
    {
        this.Gantt.ReorderRowAsync(2, 6, "Below");
    }
    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
    }

    private static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentId = 1, },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentId = 5, },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentId = 5, },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentId = 5, }
        };
        return Tasks;
    }
}
```

<!-- {% previewsample "https://blazorplayground.syncfusion.com/embed/LjhUXmWuKNUDGGVK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %} -->

### Dynamically hide rowdragdrop icons

By default, it renders all records with a rowdragdrop icon. In this guide, we'll show you how to dynamically conditionally hide the rowdragdrop icon based on specific conditions using the [`RowDataBound`](https://blazor.syncfusion.com/documentation/gantt-chart/events#rowdatabound) event.

#### Event handling

You can dynamically hide the rowdragdrop icon based on specific conditions using event handling. Here's how you can achieve this:

```csharp

private async void DataBoundHandler(Syncfusion.Blazor.Grids.RowDataBoundEventArgs<TaskData> args)
{
    if (args.Data.TaskId >= 1 && args.Data.TaskId <= 3)
    {
        args.Row.AddClass(new string[] { "e-notdraggable" });
    }
}

```

#### CSS styling

To visually hide the rowdragdrop icon, you can apply CSS styles:

```html

<style>
    .e-notdraggable .e-rowcelldrag {
        display: none;
    }
    .e-notdraggable .e-rowdragdrop {
        pointer-events: none;
    }
</style>

```

The following code snippet dynamically hide rowdragdrop icons in a Gantt control.

```cshtml
@using Syncfusion.Blazor.Gantt

<SfGantt @ref="Gantt" DataSource="@TaskCollection" Height="450px" Width="900px" HighlightWeekends="true"
          TreeColumnIndex="1" AllowRowDragAndDrop="true">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
         ParentID="ParentId" Dependency="Predecessor"></GanttTaskFields>
    <GanttEvents RowDataBound="DataBoundHandler" TValue="TaskData"></GanttEvents>
</SfGantt>
   
<style>
    .e-notdraggable .e-rowcelldrag {
        display: none;
    }
    .e-notdraggable .e-rowdragdrop {
        pointer-events: none;
    }
</style>
@code {
    SfGantt<TaskData> Gantt;
    private List<TaskData> TaskCollection { get; set; }
    
    private async void DataBoundHandler(Syncfusion.Blazor.Grids.RowDataBoundEventArgs<TaskData> args)
    {
        if (args.Data.TaskId >= 1 && args.Data.TaskId <= 3)
        {
            args.Row.AddClass(new string[] { "e-notdraggable" });
        }
    }

    protected override void OnInitialized()
    {
        this.TaskCollection = ProjectNewData();
    }
    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public string Predecessor { get; set; }
        public int? ParentId { get; set; }
    }
    public static List<TaskData> ProjectNewData()
    {
        List<TaskData> Tasks = new List<TaskData>() 
        {
            new TaskData() { TaskId = 1, TaskName = "Product concept ", StartDate = new DateTime(2021, 04, 02), EndDate = new DateTime(2021, 04, 08), Duration = "5days" },
            new TaskData() { TaskId = 2, TaskName = "Define the product usage", StartDate = new DateTime(2021, 04, 02), EndDate = new DateTime(2021, 04, 08), Duration = "3", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Define the target audience", EndDate = new DateTime(2021, 04, 04), Progress = 40, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Prepare product sketch and notes", StartDate = new DateTime(2021, 04, 05), Duration = "2", Progress = 30, ParentId = 1, Predecessor="2" },
            new TaskData() { TaskId = 5, TaskName = "Concept approval", StartDate = new DateTime(2021, 04, 08), EndDate = new DateTime(2021, 04, 08), Duration="0", Predecessor="3,4" },
            new TaskData() { TaskId = 6, TaskName = "Market research", StartDate = new DateTime(2021, 04, 09), EndDate = new DateTime(2021, 04, 18), Duration = "4", Progress = 30 },
            new TaskData() { TaskId = 7, TaskName = "Demand analysis", Duration = "4", Progress = 40, ParentId = 6 },
            new TaskData() { TaskId = 8, TaskName = "Customer strength", StartDate = new DateTime(2021, 04, 09), EndDate = new DateTime(2021, 04, 12), Duration = "4", Progress = 30, ParentId = 7, Predecessor="5", },
            new TaskData() { TaskId = 9, TaskName = "Market opportunity analysis", StartDate = new DateTime(2021, 04, 09), EndDate = new DateTime(2021, 04, 012), Duration="4", ParentId= 7, Predecessor="5" },
            new TaskData() { TaskId = 10, TaskName = "Competitor analysis", StartDate = new DateTime(2021, 04, 15), EndDate = new DateTime(2021, 04, 18), Duration = "4", Progress = 30, ParentId= 6, Predecessor="7,8" },
            new TaskData() { TaskId = 11, TaskName = "Product strength analysis", StartDate = new DateTime(2021, 04, 15), EndDate = new DateTime(2021, 04, 18), Duration = "4", Progress = 40, ParentId = 6, Predecessor="9" },
            new TaskData() { TaskId = 12, TaskName = "Research completed", StartDate = new DateTime(2021, 04, 18), EndDate = new DateTime(2021, 04, 18), Duration = "0", Progress = 30, ParentId = 6, Predecessor="10" },
            new TaskData() { TaskId = 13, TaskName = "Product design and development", StartDate = new DateTime(2021, 04, 19), EndDate = new DateTime(2021, 05, 16), Duration="20" },
            new TaskData() { TaskId = 14, TaskName = "Functionality design", StartDate = new DateTime(2021, 04, 19), EndDate = new DateTime(2021, 04, 23), Duration = "3", Progress = 30, ParentId = 13, Predecessor="12" },
            new TaskData() { TaskId = 15, TaskName = "Quality design", StartDate = new DateTime(2021, 04, 19), EndDate = new DateTime(2021, 04, 23), Duration = "3", Progress = 40, ParentId = 13, Predecessor="12" }
        };
        return Tasks;
    }
}
```

<!-- {% previewsample "https://blazorplayground.syncfusion.com/embed/VXLqDEiqWkUHmegJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %} -->


## Customize rows

You can use [GanttEvents](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html) to customize the appearance of a row on the grid side by using the `RowDataBound` event and on the chart side by using the `QueryChartRowInfo` event.

```cshtml
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids

<SfGantt DataSource="@TaskCollection" Height="450px" Width="900px" TreeColumnIndex="1">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
                     ParentID="ParentId">
    </GanttTaskFields>
    <GanttEvents RowDataBound="rowBound" QueryChartRowInfo="queryChart" TValue="TaskData"></GanttEvents>
</SfGantt>
<style>
    .rowcustom {
        background-color: orangered;
    }
</style>
@code{
    private List<TaskData> TaskCollection { get; set; }
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }
    public void rowBound(RowDataBoundEventArgs<TaskData> args)
    {
        if (args.Data.TaskId == 4)
        {
            args.Row.AddClass(new string[] { "rowcustom" });
        }
    }
    public void queryChart(QueryChartRowInfoEventArgs<TaskData> args)
    {
        if (args.Data.TaskId == 4)
        {
            args.Row.AddClass(new string[] { "rowcustom" });
        }
    }

    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
    }

    private static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentId = 1, },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentId = 5, },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentId = 5, },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentId = 5, }
        };
        return Tasks;
    }
}
```

![Customizing Rows in Blazor Gantt Chart](images/blazor-gantt-chart-row-customization.png)
<!-- {% previewsample "https://blazorplayground.syncfusion.com/embed/LXBqDQMagDcXFrkZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %} -->

## Styling alternate rows

 You can change the background colour of alternative rows in Gantt chart by overriding the class as shown below.

```css
.e-altrow, tr.e-chart-row:nth-child(odd)  {
    background-color: #f2f2f2;
}
```

```cshtml
@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="900px" TreeColumnIndex="1">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
                     ParentID="ParentId">
    </GanttTaskFields>
</SfGantt>
<style>
    .e-altrow, tr.e-chart-row:nth-child(odd) {
        background-color: #f2f2f2;
    }
</style>
@code{
    private List<TaskData> TaskCollection { get; set; }
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
        public int? ParentId { get; set; }
    }

    private static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentId = 1, },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentId = 5, },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentId = 5, },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentId = 5, }
        };
        return Tasks;
    }
}
```

![Changing Row Style in Blazor Gantt Chart](images/blazor-gantt-chart-row-style.png)
<!-- {% previewsample "https://blazorplayground.syncfusion.com/embed/hNBKjmsYUCxvmRCQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %} -->

## Accessing row task model information programmatically

The Blazor Gantt Chart Component provides a method called [GetRowTaskModel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_GetRowTaskModel__0_) that can be used to obtain the values associated with task model details. These details include the level, expanded status, task width, task left, task progress width and more. 

This is demonstrated in the below sample code, where the [GetRowTaskModel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_GetRowTaskModel__0_) method is called on selecting the row, which returns the value of the task model details of the selected record. 

```cshtml
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids;
<div>
    <div style="font-weight:bold;">Task Model Properties:</div>
    <div style="display:flex;visibility:@Visible">
        <div>
            <span class="showhide">Level: @Level </span>
            <span class="showhide">Expanded: @ExpandStatus </span>
            <span class="showhide">HasChildRecord: @ChildRecords </span>
            <span class="showhide">IsCritical: @IsCritical </span>
            <span class="showhide">Slack: @Slack </span>
            <span class="showhide">Progress width: @ProgressWidth </span>
        </div>
    </div>
</div>
    <SfGantt @ref=Gantt DataSource="@TaskCollection" Height="450px" Width="900px" TreeColumnIndex="1" EnableCriticalPath="true">
        <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
                         ParentID="ParentId">
        </GanttTaskFields>
        <GanttEvents TValue="TaskData" RowSelected="RowSelect"></GanttEvents>
    </SfGantt>

<style>
    .showhide {
        padding: 10px;
    }
</style>
@code {
    private SfGantt<TaskData> Gantt;
    private List<TaskData> TaskCollection { get; set; }
    private int Level{ get; set; } 
    private bool ExpandStatus{ get; set; }
    private bool ChildRecords{ get; set; }
    private bool IsCritical{ get; set; }
    private double? Slack { get; set; }
    private double ProgressWidth { get; set; }
    private string Visible { get; set; } = "hidden";
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }
    public void RowSelect(RowSelectEventArgs<TaskData> args)
    {
        var ganttItem = Gantt.GetRowTaskModel(args.Data);
        Level = ganttItem.Level;
        ExpandStatus = ganttItem.IsExpanded;
        ChildRecords = ganttItem.HasChildRecords;
        IsCritical = ganttItem.IsCritical;
        Slack = ganttItem.Slack;
        ProgressWidth = ganttItem.ProgressWidth;
        Visible = "visible";
    }
    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
    }

    private static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentId = 1, },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 14), Duration = "3", Progress = 30, ParentId = 5, },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 14), Duration = "3", Progress = 40, ParentId = 5, },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 14), Duration = "0", Progress = 30, ParentId = 5, }
        };
        return Tasks;
    }
}
```
![Row Task Model Properties](images/blazor-gantt-chart-GetRowTaskModel.png)

N> You can refer to our [Blazor Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Gantt Chart example](https://blazor.syncfusion.com/demos/gantt-chart/default-functionalities?theme=bootstrap4) to know how to render and configure the Gantt.