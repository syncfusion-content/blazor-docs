---
layout: post
title: Style And Appearance in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about style and appearance in Syncfusion Blazor Gantt Chart component and more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Style and Appearance in Blazor Gantt Chart Component

To modify the Gantt Chart appearance, you need to override the default CSS of Gantt Chart. Find the list of CSS classes and their corresponding section in Gantt Chart. Also, you have an option to create your own custom theme for all the JavaScript controls using our [Theme Studio](https://blazor.syncfusion.com/documentation/appearance/theme-studio/).

|Section | CSS Class | Purpose of Class |
|-----|-----|-----|
|**Root**|e-gantt|This class is in the root element (div) of the gantt chart control. |
|**Header**|e-gridheader|This class is added in the root element of header element. In this class, You can override thin line between header and content of the gantt chart. |
| | e-table | This class is added at 'table' of the gantt chart header. This CSS class makes table width as 100 %. |
| |e-columnheader|This class is added at 'tr' of the gantt chart header. |
|**Grid Content**|e-gridcontent|This class is added at root of body content. This is to override background color of the body.
| |e-table|This class is added to table of content. This CSS class makes table width as 100 %.
| |e-row|This class is added to rows of gantt chart.
| |e-altrow|This class is added to alternate rows of gantt chart. This is to override alternate row color of the gantt chart.
| |e-rowcell|This class is added to all cells in the gantt chart. This is to override cells appearance and styling.
|**Chart Content**|e-gantt-chart|This class is added to the chart side of the gantt chart.
| |e-chart-row|This class is added to rows of gantt chart.
|**Timeline**|e-timeline-header-container|This class is added to timeline of the gantt chart.
| |e-header-cell-label|This class is added to the header cell of the timeline.
| |e-weekend-header-cell|This class is added to the weekend cells.
|**Taskbar**|e-taskbar-main-container|This class is added to taskbar of the gantt chart.
| |e-gantt-parent-taskbar|This class is added to the parent task bar of the gantt chart.
| |e-gantt-milestone|This class is added to the milestone tasks of the gantt chart.
| |e-gantt-unscheduled-taskbar|This class is added to the unscheduled tasks.
| |e-gantt-manualparenttaskbar|This class is added to the manual scheduled parent taskbar.
| |e-gantt-child-manualtaskbar|This class is added to the manual scheduled child taskbar.
| |e-gantt-unscheduled-manualtask|This class is added to the manual unscheduled tasks.
|**Splitter**|e-split-bar|This class is added to the gantt chart splitter.
| |e-resize-handler|This class is added to the resize handler of the gantt chart splitter.
| |e-arrow-left|This class is added to the left arrow of the resize handler.
| |e-arrow-right|This class is added to the right arrow of the resize handler.
|**Connector Lines**|e-connector-line|This class is added to the connector lines.
| |e-connector-line-arrow|This class is added to the arrow of the connector line.
|**Labels**|e-task-label|This class is added to the task labels.
| |e-right-label-container|This class is added to the right label.
| |e-left-label-container|This class is added to the left label.
|**Event Markers**|e-event-markers|This class is added to the event markers.
|**Baseline**|e-baseline-bar|This class is added to the baseline.
| |e-baseline-gantt-milestone-container|This class is added to the baseline of milestone tasks.
|**Tooltip**|e-gantt-tooltip|This class is added to the tooltip.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt DataSource="@TaskCollection" Height="450px" Width="1000px" RenderBaseline="true">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" Dependency="Predecessor" ParentID="ParentID" BaselineStartDate="BaselineStartDate"
                     BaselineEndDate="BaselineEndDate">
    </GanttTaskFields>
    <GanttLabelSettings RightLabel="TaskName" TValue="TaskData"></GanttLabelSettings>
    <GanttEventMarkers>
        <GanttEventMarker Day="@Event" Label="Project approval and kick-off"></GanttEventMarker>
    </GanttEventMarkers>
</SfGantt>
<style>
     .e-split-bar, .e-headercell {
        background: #add8e6 !important; /* Set splitter and header cell background color */
    }

    .e-timeline-header-container, .e-weekend-header-cell {
        background: #add8e6 !important; /* Set timeline header and weekend cell background color */
    }

    .e-gantt-parent-taskbar-inner-div {
        background-color: #7ab748 !important; /* Set parent taskbar color */
    }

    .e-gantt-parent-progressbar-inner-div {
        background-color: #4b732a !important; /* Set parent progress bar color */
    }

    .e-gantt-milestone {
        background-color: #ad7a66 !important; /* Set milestone color */
    }

    .e-gantt-child-taskbar-inner-div {
        background-color: #6d619b !important; /* Set child taskbar color */
    }

    .e-gantt-child-progressbar-inner-div {
        background-color: #4e466e !important; /* Set child progress bar color */
    }

    .e-tooltip-wrap {
        background: #a9e0f4 !important; /* Set tooltip background color */
    }

    .e-event-markers {
        border-left-color: #05088f !important; /* Set event marker color */
    }

    .e-event-markers .e-span-label {
        background-color: #f3e5f5 !important; /* Set event marker label background color */
        color: #6a1b9a !important; /* Set event marker label text color */
    }

    .e-baseline-gantt-milestone-container{
        background-color: #fdb9c9 !important; /* Set baseline milestone color */
    }

    .e-baseline-bar {
        background-color: #fdb9c9 !important; /* Set baseline bar color */
    }

    .e-label {
        color: #1e74ca !important; /* Set label text color */
    }

    .e-connector-line {
        stroke: #ab6060fc !important; /* Set line color */
    }

    .e-connector-line-arrow {
        fill: #ab6060fc !important; /* Set arrow color */
    }
</style>
@code {
    private List<TaskData> TaskCollection { get; set; }
    public DateTime Event = new DateTime(2022, 01, 16);

    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    public class TaskData
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public DateTime? BaselineStartDate { get; set; }
        public DateTime? BaselineEndDate { get; set; }
        public string Predecessor { get; set; }
        public int? ParentID { get; set; }
    }

    private static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 07), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), BaselineStartDate = new DateTime(2022, 01, 04), BaselineEndDate = new DateTime(2022, 01, 07), Duration = "4", Progress = 40, ParentID = 1, Predecessor="2", },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", BaselineStartDate = new DateTime(2022, 01, 05, 08, 00, 00), BaselineEndDate = new DateTime(2022, 01, 05, 08, 00, 00), Progress = 30, ParentID = 1, Predecessor="3", },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentID = 5, Predecessor="4", },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), BaselineStartDate = new DateTime(2022, 01, 09), BaselineEndDate = new DateTime(2022, 01, 14), Duration = "3", Progress = 40, ParentID = 5, Predecessor="6", },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentID = 5, Predecessor="7", }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXLeNaVoAMMmqlIy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Grid lines

In the Gantt Chart component, you can show or hide the grid lines in the Tree Grid side and chart side by using the `GridLines` property.

The following options are available in the Gantt Chart component for rendering the grid lines:

* Horizontal: The horizontal grid lines alone will be visible.
* Vertical: The vertical grid lines alone will be visible.
* Both: Both the horizontal and vertical grid lines will be visible on the Tree Grid and chart sides.
* None: Gridlines will not be visible on Tree Grid and chart sides.

N> By default, the `GridLines` property is set to `Horizontal` type.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="800px" GridLines="Syncfusion.Blazor.Gantt.GridLine.Both">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
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
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentID { get; set; }
    }

    private static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 7), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentID = 1, },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 10), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentID = 5, },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentID = 5, },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentID = 5, }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDhoDEBoAspFJHca?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## See also

* [Customizing the Blazor Gantt Chart’s Taskbar](https://www.syncfusion.com/blogs/post/customizing-the-blazor-gantt-charts-taskbar-an-overview.aspx)

N> You can refer to our [Blazor Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Gantt Chart example](https://blazor.syncfusion.com/demos/gantt-chart/default-functionalities?theme=bootstrap5) to know how to render and configure the Gantt.
