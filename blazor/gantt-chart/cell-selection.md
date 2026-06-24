---
layout: post
title: Cell Selection in Blazor Gantt Chart Component | Syncfusion
description: Learn how to configure and customize cell selection in the Syncfusion Blazor Gantt Chart, including single, multiple, and dynamic selection.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Cell selection in Blazor Gantt Chart component

Cell selection in the Gantt Chart component enables interactive selection of specific cells or ranges of cells within the grid. You may select cells using mouse clicks or arrow keys (up, down, left, right). This is useful for highlighting, manipulating, or performing operations on particular gantt chart cells.

## Single cell selection

Single cell selection in the Gantt chart is enabled by setting [GanttSelectionSettings.Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttSelectionSettings.html#Syncfusion_Blazor_Gantt_GanttSelectionSettings_Mode) to **Cell** and [GanttSelectionSettings.Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttSelectionSettings.html#Syncfusion_Blazor_Gantt_GanttSelectionSettings_Type) to **Single**. This allows selecting only one cell at a time.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids

<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttSelectionSettings Mode="Syncfusion.Blazor.Grids.SelectionMode.Cell" Type="Syncfusion.Blazor.Grids.SelectionType.Single"></GanttSelectionSettings>
</SfGantt>

@code {
    public List<TaskData> TaskCollection { get; set; }

    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 01, 05), EndDate = new DateTime(2026, 01, 17), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 01, 05), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 01, 05), EndDate = new DateTime(2026, 01, 08), Progress = 40, ParentId = 1, },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 01, 05), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 01, 05), EndDate = new DateTime(2026, 01, 17), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 01, 06), EndDate = new DateTime(2026, 01, 08), Progress = 30, ParentId = 5, },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 01, 06),EndDate = new DateTime(2026, 01, 08), Progress = 40, ParentId = 5, },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 01, 06), Duration = "0", Progress = 30, ParentId = 5, }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDBxXxsLVGYfkbeE?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}
  
## Multiple cell selection

Multiple cell selection in the Gantt Chart is enabled by setting [GanttSelectionSettings.Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttSelectionSettings.html#Syncfusion_Blazor_Gantt_GanttSelectionSettings_Mode) to **Cell** and [GanttSelectionSettings.Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttSelectionSettings.html#Syncfusion_Blazor_Gantt_GanttSelectionSettings_Type) to **Multiple**. This allows selecting multiple cells at a time by holding the <kbd>Ctrl</kbd> key while clicking on each desired cell.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids

<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttSelectionSettings Mode="Syncfusion.Blazor.Grids.SelectionMode.Cell" Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GanttSelectionSettings>
</SfGantt>

@code {
    public List<TaskData> TaskCollection { get; set; }

    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 01, 05), EndDate = new DateTime(2026, 01, 17), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 01, 05), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 01, 05), EndDate = new DateTime(2026, 01, 08), Progress = 40, ParentId = 1, },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 01, 05), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 01, 05), EndDate = new DateTime(2026, 01, 17), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 01, 06), EndDate = new DateTime(2026, 01, 08), Progress = 30, ParentId = 5, },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 01, 06),EndDate = new DateTime(2026, 01, 08), Progress = 40, ParentId = 5, },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 01, 06), Duration = "0", Progress = 30, ParentId = 5, }
        };
        return Tasks;
    }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXLnNRWhBbvFjObA?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}
  
> **Note**: Multiple cell selection requires <kbd>Ctrl</kbd> + click on Windows or <kbd>Cmd</kbd> + click on Mac. Ensure selections are visible on smaller screens for mobile responsiveness.

## Single cell selection dynamically

Select a specific cell in the Gantt Chart by calling the  [SelectCellAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_SelectCellAsync_System_ValueTuple_System_Int32_System_Int32__System_Nullable_System_Boolean__) method and providing the desired row and column indexes as arguments.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton Content="Select Cell" OnClick="SelectCellAsync"></SfButton>
<SfGantt @ref="Gantt" DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttSelectionSettings Mode="Syncfusion.Blazor.Grids.SelectionMode.Cell"></GanttSelectionSettings>
</SfGantt>

@code {
    public SfGantt<TaskData> Gantt;

    public async Task SelectCellAsync()
    {
        await Gantt.SelectCellAsync(new ValueTuple<int, int>(1, 2));
    }

    public List<TaskData> TaskCollection { get; set; }

    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 01, 05), EndDate = new DateTime(2026, 01, 17), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 01, 05), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 01, 05), EndDate = new DateTime(2026, 01, 08), Progress = 40, ParentId = 1, },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 01, 05), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 01, 05), EndDate = new DateTime(2026, 01, 17), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 01, 06), EndDate = new DateTime(2026, 01, 08), Progress = 30, ParentId = 5, },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 01, 06),EndDate = new DateTime(2026, 01, 08), Progress = 40, ParentId = 5, },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 01, 06), Duration = "0", Progress = 30, ParentId = 5, }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDBnjnMVLagJBEnG?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Customize cell selection action

You may customize cell selection behavior in the Gantt Chart using [CellSelecting](https://blazor.syncfusion.com/documentation/gantt-chart/events#cellselecting), [CellSelected](https://blazor.syncfusion.com/documentation/gantt-chart/events#cellselected), [CellDeselecting](https://blazor.syncfusion.com/documentation/gantt-chart/events#celldeselecting), and [CellDeselected](https://blazor.syncfusion.com/documentation/gantt-chart/events#celldeselected) events.

The following sample demonstrates selection is canceled in the `cellSelecting` event when the **TaskName** is **Perform Soil test**. 

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids

@if (showMessage)
{
    <div style="margin-top:10px; font-weight:bold;color:red">@message</div>
}
<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
 <GanttSelectionSettings Mode="Syncfusion.Blazor.Grids.SelectionMode.Cell" Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GanttSelectionSettings>
    <GanttEvents TValue="TaskData" CellSelecting="CellSelectingAsync" CellSelected="CellSelectedAsync" CellDeselecting="CellDeselectingAsync" CellDeselected="CellDeselectedAsync">
    </GanttEvents>
</SfGantt>

@code {
    public List<TaskData> TaskCollection { get; set; }
    private string message;
    private bool showMessage;

    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
    }

    public Task CellSelectedAsync(CellSelectEventArgs<TaskData> args)
    {
        showMessage = true;
        message = $"CellSelected: RowIndex={args.RowIndex}, CellIndex={args.CellIndex}";
        return Task.CompletedTask;
    }

    public Task CellSelectingAsync(CellSelectingEventArgs<TaskData> args)
    {
        showMessage = true;
        message = $"CellSelecting: RowIndex={args.RowIndex}, CellIndex={args.CellIndex}";

        if (args.Data?.TaskName == "Perform soil test")
        {
            args.Cancel = true;
            message += " Selection canceled for 'Perform soil test'";
        }

        return Task.CompletedTask;
    }

    public Task CellDeselectingAsync(CellDeselectEventArgs<TaskData> args)
    {
        showMessage = true;
        message = $"CellDeselecting: RowIndex={args.RowIndex}, CellIndex={args.CellIndex}";

        return Task.CompletedTask;
    }

    public Task CellDeselectedAsync(CellDeselectEventArgs<TaskData> args)
    {
        showMessage = true;
        message = $"CellDeselected: RowIndex={args.RowIndex}, CellIndex={args.CellIndex}";

        return Task.CompletedTask;
    }

    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        return new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 01, 05), EndDate = new DateTime(2026, 01, 17), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 01, 05), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 01, 05), EndDate = new DateTime(2026, 01, 08), Progress = 40, ParentId = 1, },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 01, 05), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 01, 05), EndDate = new DateTime(2026, 01, 17), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 01, 06), EndDate = new DateTime(2026, 01, 08), Progress = 30, ParentId = 5, },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 01, 06),EndDate = new DateTime(2026, 01, 08), Progress = 40, ParentId = 5, },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 01, 06), Duration = "0", Progress = 30, ParentId = 5, }
        };
    }
}


{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/htVdjdMVKNWUHUit?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

> **Note**: Use `CellSelecting` to restrict selections based on task properties. Log selected cell details with `CellSelected` for custom actions. Ensure selections are accessible via keyboard (e.g., <kbd>Shift</kbd> + arrow keys for range selection).

## See Also

- [Accessibility in Blazor Gantt Chart](https://blazor.syncfusion.com/documentation/gantt-chart/accessibility)
- [Blazor Gantt Chart Feature Tour](https://www.syncfusion.com/blazor-components/blazor-gantt-chart)
- [Blazor Gantt Chart Example](https://blazor.syncfusion.com/demos/gantt-chart/default-functionalities?theme=bootstrap5)