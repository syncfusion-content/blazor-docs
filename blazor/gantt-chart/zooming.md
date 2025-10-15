---
layout: post
title: Zooming in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about Zooming timespan levels in Syncfusion Blazor Gantt Chart component and much more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Zooming in Blazor Gantt Chart Component

Gantt Chart has 25 predefined zooming timespan levels from year timespan to hour timespan. This support enables you to view the tasks in a project clearly from minute to decade timespan. To enable the zooming features, define the `ZoomIn`, `ZoomOut`, and `ZoomToFit` items to toolbar items collections. The following zooming options are available to view the project:

## Zoom in

This support is used to increase the timeline width and timeline unit from years to minutes timespan. When the `ZoomIn` icon was clicked, the timeline cell width is increased when the cell size exceeds the specified range and the timeline unit is changed based on the current zoom levels.

## Zoom out

This support is used to increase the timeline width and timeline unit from minutes to years timespan. When the `ZoomOut` icon was clicked, the timeline cell width is decreased when the cell size falls behind the specified range and the timeline view mode is changed based on the current zooming levels.

## Zoom to fit

This support is used to view all the tasks available in a project to specific timespan which is compatible with available area on the chart part of Gantt Chart. When users click the `ZoomToFit` icon, then all the tasks are rendered within the available chart container width.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt DataSource="@TaskCollection" Toolbar="@(new List<string>() { "ZoomIn", "ZoomOut", "ZoomToFit" })" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID" Dependency="Predecessor">
    </GanttTaskFields>
    <GanttLabelSettings LeftLabel="TaskName" TValue="TaskData"></GanttLabelSettings>
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
        public string Predecessor { get; set; }
        public int? ParentID { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 21), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, Predecessor = "2", ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, Predecessor = "3", ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 04, 21), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, Predecessor = "4", ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 40, Predecessor = "6", ParentID = 5 },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0", Progress = 30, Predecessor = "7", ParentID = 5 },
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZLyitiyhqavpBUf?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Zoom action by methods

Zooming action also can be performed on external actions such as button click using the `ZoomIn()`, `ZoomOut()`, and `ZoomToFitAsync()` built-in methods.

## Customizing zooming levels

In the Gantt chart, the zoom-in and zoom-out actions are performed based on the predefined zooming Levels. You can customize the zooming actions by defining the required zooming levels to the [CustomZoomingLevels](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_CustomZoomingLevels) property.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt @ref="Gantt" DataSource="@TaskCollection" CustomZoomingLevels=zoomingLevel Toolbar="@(new List<string>() { "ZoomIn", "ZoomOut", "ZoomToFit" })" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID" Dependency="Predecessor">
    </GanttTaskFields>
</SfGantt>

@code{
    private GanttZoomTimelineSettings[] zoomingLevel = new GanttZoomTimelineSettings[]
    {
            new GanttZoomTimelineSettings { TopTier = new GanttTopTierSettings { Unit = TimelineViewMode.Month, Format = "MMM yyyy", Count = 1 }, BottomTier = new GanttBottomTierSettings { Unit = TimelineViewMode.Week, Format = "MMM yy", Count = 1 }, TimelineUnitSize = 66, TimelineViewMode = TimelineViewMode.Month, WeekStartDay = 0, UpdateTimescaleView = true, WeekendBackground = null, ShowTooltip = true, Level = 0 },
            new GanttZoomTimelineSettings { TopTier = new GanttTopTierSettings { Unit = TimelineViewMode.Month, Format = "MMM yyyy", Count = 1 }, BottomTier = new GanttBottomTierSettings { Unit = TimelineViewMode.Week, Format = "dd MMM", Count = 1}, TimelineUnitSize = 99, TimelineViewMode = TimelineViewMode.Month, WeekStartDay = 0, UpdateTimescaleView = true, WeekendBackground = null, ShowTooltip = true, Level = 1 },
            new GanttZoomTimelineSettings { TopTier = new GanttTopTierSettings { Unit = TimelineViewMode.Week, Format = "MMM dd yyyy", Count = 1 }, BottomTier = new GanttBottomTierSettings { Unit = TimelineViewMode.Day, Format = "dd", Count = 1 }, TimelineUnitSize = 33, TimelineViewMode = TimelineViewMode.Month, WeekStartDay = 0, UpdateTimescaleView = true, WeekendBackground = null, ShowTooltip = true, Level = 2 },
            new GanttZoomTimelineSettings { TopTier = new GanttTopTierSettings { Unit = TimelineViewMode.Week, Format = "MMM dd yyyy", Count = 1 }, BottomTier = new GanttBottomTierSettings { Unit = TimelineViewMode.Day, Format = "dd", Count = 1 }, TimelineUnitSize = 66, TimelineViewMode = TimelineViewMode.Week, WeekStartDay = 0, UpdateTimescaleView = true, WeekendBackground = null, ShowTooltip = true, Level = 3 },
            new GanttZoomTimelineSettings { TopTier = new GanttTopTierSettings { Unit = TimelineViewMode.Week, Format = "MMM dd yyyy", Count = 1 }, BottomTier = new GanttBottomTierSettings { Unit = TimelineViewMode.Day, Format = "dd", Count = 1 }, TimelineUnitSize = 99, TimelineViewMode = TimelineViewMode.Week, WeekStartDay = 0, UpdateTimescaleView = true, WeekendBackground = null, ShowTooltip = true, Level = 4 },
            new GanttZoomTimelineSettings { TopTier = new GanttTopTierSettings { Unit = TimelineViewMode.Day, Format = "MMM dd yyyy", Count = 1 }, BottomTier = new GanttBottomTierSettings { Unit = TimelineViewMode.Hour, Format = "hh tt", Count = 12 }, TimelineUnitSize = 66, TimelineViewMode = TimelineViewMode.Day, WeekStartDay = 0, UpdateTimescaleView = true, WeekendBackground = null, ShowTooltip = true, Level = 5 },
            new GanttZoomTimelineSettings { TopTier = new GanttTopTierSettings { Unit = TimelineViewMode.Day, Format = "MMM dd yyyy", Count = 1 }, BottomTier = new GanttBottomTierSettings { Unit = TimelineViewMode.Hour, Format = "hh tt", Count = 6 }, TimelineUnitSize = 99, TimelineViewMode = TimelineViewMode.Day, WeekStartDay = 0, UpdateTimescaleView = true, WeekendBackground = null, ShowTooltip = true, Level = 6 },
    };
    private SfGantt<TaskData> Gantt;
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
        public string Predecessor { get; set; }
        public int? ParentID { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 08), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, Predecessor = "2", ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, Predecessor = "3", ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 11), EndDate = new DateTime(2022, 04, 18), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, Predecessor = "4", ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 40, Predecessor = "6", ParentID = 5 },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0", Progress = 30, Predecessor = "7", ParentID = 5 },
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXBSMXWyLTMdwIiS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Resetting zooming levels using method

In Gantt chart, you can reset the zoom level to its initial state, as configured during the initial rendering, after performing zooming actions like ZoomIn, ZoomOut, and ZoomToFit, using [ResetZoomAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ResetZoomAsync) method.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<button @onclick="ResetZoomingLevels">Reset Zoom</button>

<SfGantt @ref="Gantt" DataSource="@TaskCollection" Toolbar="@(new List<string>() { "ZoomIn", "ZoomOut", "ZoomToFit" })" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID" Dependency="Predecessor">
    </GanttTaskFields>
    <GanttLabelSettings LeftLabel="TaskName" TValue="TaskData"></GanttLabelSettings>
</SfGantt>

@code {
    private SfGantt<TaskData> Gantt;
    private List<TaskData> TaskCollection { get; set; }
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }
    private async void ResetZoomingLevels()
    {
        await Gantt.ResetZoomAsync();
    }
    public class TaskData
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public string Predecessor { get; set; }
        public int? ParentID { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 08), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, Predecessor = "2", ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, Predecessor = "3", ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 11), EndDate = new DateTime(2022, 04, 18), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, Predecessor = "4", ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 40, Predecessor = "6", ParentID = 5 },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0", Progress = 30, Predecessor = "7", ParentID = 5 },
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjByMjWIVfBRQRNW?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}