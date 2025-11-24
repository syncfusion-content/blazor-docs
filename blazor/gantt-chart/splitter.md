---
layout: post
title: Splitter in Blazor Gantt Chart Component | Syncfusion
description: Learn how to configure the splitter in the Syncfusion Blazor Gantt Chart component for flexible TreeGrid and Chart panel sizing.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Splitter in Blazor Gantt Chart Component

The splitter in the Blazor Gantt Chart component divides the TreeGrid (task data table) and Chart (timeline with taskbars) panels, enabling flexible width allocation for project visualization. Configured via the [GanttSplitterSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttSplitterSettings.html) property, the splitter supports pixel or percentage-based positioning, column-based alignment, and predefined view modes. The [SetSplitterPosition](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_SetSplitterPositionAsync_System_Int32_) method adjusts positioning dynamically, while the [SplitterResizeStart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_SplitterResizeStart), [SplitterResizing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_SplitterResizing), and [SplitterResized](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_SplitterResized) events handle resize interactions. The splitter includes ARIA labels for accessibility, ensuring screen reader compatibility, and adapts to responsive designs, though narrow screens may limit visible columns or timeline segments. By default, both panels are visible with equal width.

## Configure splitter position

Set the splitter position using [GanttSplitterSettings.Position](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttSplitterSettings.html#Syncfusion_Blazor_Gantt_GanttSplitterSettings_Position) with pixel (e.g., "300px") or percentage (e.g., "30%") values to define the TreeGrid pane width, or align to a column edge with [GanttSplitterSettings.ColumnIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttSplitterSettings.html#Syncfusion_Blazor_Gantt_GanttSplitterSettings_ColumnIndex).

The following example sets a percentage-based splitter position. This configuration allocates 80% width to the TreeGrid panel.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="800px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttSplitterSettings Position="80%"></GanttSplitterSettings>
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
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 07), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentId = 1, },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 10), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentId = 5, },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentId = 5, },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentId = 5, }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtBIWNNaArlKXynp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Adjust splitter position dynamically

Change the splitter position using the [SetSplitterPositionAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_SetSplitterPositionAsync_System_Int32_) method with pixel, percentage, or column index values, triggered by events like window resizing or button clicks.

The following example adjusts the splitter dynamically:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.DropDowns

<button @onclick="UpdateSplitterByPosition">Update splitter by position</button>
<button @onclick="UpdateSplitterByIndex">Update splitter by index</button>
<SfDropDownList TValue="string" TItem="SplitterView" DataSource="@SplitterViews" Width="200px">
    <DropDownListFieldSettings Value="ID" Text="Text"></DropDownListFieldSettings>
    <DropDownListEvents TValue="string" TItem="SplitterView" ValueChange="OnChange"></DropDownListEvents>
</SfDropDownList>
<SfGantt @ref="Gantt" DataSource="@TaskCollection" Height="450px" Width="800px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" Child="SubTasks">
    </GanttTaskFields>
</SfGantt>

@code{
    public SfGantt<TaskData> Gantt;
    public class SplitterView
    {
        public string ID { get; set; }
        public string Text { get; set; }
    }
    public List<SplitterView> SplitterViews = new List<SplitterView>
{
        new SplitterView() { ID= "Default", Text= "Default" },
        new SplitterView() { ID= "Grid", Text= "Grid" },
        new SplitterView() { ID= "Chart", Text= "Chart" },
    };
    public void OnChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, SplitterView> args)
    {
        if (args.Value == "Grid")
        {
            this.Gantt.SetSplitterPositionAsync(Syncfusion.Blazor.Gantt.SplitterView.Grid);
        }
        else if (args.Value == "Chart")
        {
            this.Gantt.SetSplitterPositionAsync(Syncfusion.Blazor.Gantt.SplitterView.Chart);
        }
        else
        {
            this.Gantt.SetSplitterPositionAsync(Syncfusion.Blazor.Gantt.SplitterView.Default);
        }
    }
    public void UpdateSplitterByPosition()
    {
        this.Gantt.SetSplitterPositionAsync("70%");
    }
    public void UpdateSplitterByIndex()
    {
        this.Gantt.SetSplitterPositionAsync(0);
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
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 07), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentId = 1, },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 10), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentId = 5, },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentId = 5, },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentId = 5, }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZVoiXXaAhuibSQZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}