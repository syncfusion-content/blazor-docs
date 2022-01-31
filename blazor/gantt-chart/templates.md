---
layout: post
title: Templates in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about templates in Syncfusion Blazor Gantt Chart component and much more details.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Templates in Blazor Gantt Chart Component

Blazor has templated components thats accepts one or more UI segments as input that can be rendered as part of the component during component rendering. Gantt Chart is a templated razor component, that allows customizing various part of the UI using template parameters. It allows rendering custom components or content based on its logic.

The available template options in Gantt Chart are as follows,
* [Column template](./columns/#column-template) - Used to customize cell content.
* [Header template](./columns/#header-template) - Used to customize header cell content.

## Template context

Most of the templates used by the Gantt Chart are of type `RenderFragment<T>` and they will be passed with parameters. The parameters passed can be accessed to the templates using implicit parameter named `context`. This implicit parameter name can also be changed using the `Context` attribute.

For example, the data of the column template can be accessed using `context` as follows.


## GanttChartTemplates component

If a component contains any `RenderFragment` type property then it does not allow any child components other than the render fragment property, which is [by design in Blazor](https://github.com/aspnet/AspNetCore/issues/10836).

This prevents from directly specifying templates such as `TaskbarTemplate` and `MilestoneTemplate` as descendant of the Gantt Chart component. Hence the templates such as `TaskbarTemplate` and `MilestoneTemplate` should be wrapped around a component named `GanttTemplates` as follows.

### Taskbar template

You can design your taskbars to view the tasks in Gantt Chart Chart by using `GanttTemplates.TaskbarTemplate` property. It is also possible to customize the parent taskbars and milestones with custom templates by using `GanttTemplates.ParentTaskbarTemplate` and `GanttTemplates.MilestoneTemplate` properties.

```cshtml
@using Syncfusion.Blazor.Gantt
<SfGantt RowHeight="75" TaskbarHeight="50"
            ProjectStartDate="@ProjectStart" ProjectEndDate="@ProjectEnd" DurationUnit="DurationUnit.Minute"
            DateFormat="hh:mm tt" DataSource="@TaskCollection" Height="450px" Width="100%">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Dependency="Predecessor" ParentID="ParentId"></GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskId" HeaderText="Event Id"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Event Name" Width="150"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Time"></GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Time"></GanttColumn>
        <GanttColumn Field="Winner" HeaderText="Winner"></GanttColumn>
        <GanttColumn Field="Movie" HeaderText="Movie"></GanttColumn>
        <GanttColumn Field="Performance" HeaderText=" Performance" Width="200"></GanttColumn>
    </GanttColumns>
    <GanttLabelSettings LeftLabel="TaskName" TValue="TaskbarTemplateData.TaskbarData">
    </GanttLabelSettings>
    <GanttSplitterSettings Position="30%"> </GanttSplitterSettings>
    <GanttTemplates TValue="TaskbarTemplateData.TaskbarData">
        <TaskbarTemplate>
            @if ((context as TaskbarTemplateData.TaskbarData).TaskName == "Oscar moments")
            {
                <div class="e-gantt-child-taskbar e-custom-moments" style="height:50px;border-radius:5px;">
                    @if (Convert.ToInt64((context as TaskbarTemplateData.TaskbarData).Duration) < 4)
                    {
                        <img class="moments" height="32" width="44" />
                    }
                </div>
            }
            else if ((context as TaskbarTemplateData.TaskbarData).TaskName == "Oscar performance")
            {
                <div class="e-gantt-child-taskbar e-custom-performance" style="height:50px;border-radius:5px;">
                    @if (Convert.ToInt64((context as TaskbarTemplateData.TaskbarData).Duration) <= 5)
                    {
                        <img class="face-mask" height="32" width="32" />
                    }
                </div>
            }
            else
            {
                <div class="e-gantt-parent-taskbar e-custom-parent" style="height:50px;border-radius:5px;text-overflow:ellipsis;">
                    @if (Convert.ToInt64((context as TaskbarTemplateData.TaskbarData).Duration) < 4)
                    {
                        <img class="oscar" height="32" width="32" />
                    }
                    else
                    {
                        @if (!string.IsNullOrEmpty(((context as TaskbarTemplateData.TaskbarData).Winner)) && !string.IsNullOrEmpty(((context as TaskbarTemplateData.TaskbarData).Movie)))
                        {
                            <img class="oscar" height="32" width="32" />
                            <span class="e-task-label" style="position:absolute; top:13px;font-size:14px;">@((context as TaskbarTemplateData.TaskbarData).Winner)</span>
                            <span class="e-task-label" style="position:absolute;top:33px;font-size:10px;text-overflow:ellipsis;">@((context as TaskbarTemplateData.TaskbarData).Movie)</span>
                        }
                        else if (!string.IsNullOrEmpty(((context as TaskbarTemplateData.TaskbarData).Movie)))
                        {
                            <img class="oscar" height="32" width="32" />
                            <span class="e-task-label" style="position:absolute; top:18px;font-size:12px;text-overflow:ellipsis;">@((context as TaskbarTemplateData.TaskbarData).Movie)</span>
                        }
                        else
                        {
                            <span class="e-task-label"></span>
                        }
                    }
                </div>
            }
        </TaskbarTemplate>
        <MilestoneTemplate>
            <div style="margin-top:-7px;">
                <div class="e-gantt-milestone" style="position:absolute;">
                    <img class="moments" height="24" width="48" />
                    <div class="e-milestone-top" style="border-right-width:26px; margin-top: -24px;border-left-width:26px;border-bottom-width:26px;"></div>
                    <div class="e-milestone-bottom" style="top:26px;border-right-width:26px; border-left-width:26px; border-top-width:26px;"></div>
                </div>
            </div>
        </MilestoneTemplate>
    </GanttTemplates>
    <GanttTimelineSettings TimelineUnitSize="75">
        <GanttTopTierSettings Unit="TimelineViewMode.Hour" Format="MMM dd, yyyy"></GanttTopTierSettings>
        <GanttBottomTierSettings Unit="TimelineViewMode.Minutes" Count="15" Format="h:mm tt"></GanttBottomTierSettings>
    </GanttTimelineSettings>
    <GanttDayWorkingTimeCollection>
        <GanttDayWorkingTime From="0" To="24"></GanttDayWorkingTime>
    </GanttDayWorkingTimeCollection>
</SfGantt>

@code{
    public DateTime ProjectStart = new DateTime(2018, 3, 5, 18, 0, 0);
    public DateTime ProjectEnd = new DateTime(2018, 3, 6, 18, 0, 0);
    public List<TaskbarTemplateData.TaskbarData> TaskCollection { get; set; }
    protected override void OnInitialized()
    {
        this.TaskCollection = TaskbarTemplateData.TaskTemplateData();
    }
    public class TaskbarTemplateData
    {
        public class TaskData
        {
            public int TaskId { get; set; }
            public string TaskName { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime EndDate { get; set; }
            public string Duration { get; set; }
            public int Progress { get; set; }
            public string Predecessor { get; set; }
            public int? ParentId { get; set; }
        }
        public class TaskProperties
        {
            public string TaskName { get; set; }
            public double Duration { get; set; }
        }
        public class TaskbarData : TaskData
        {
            public string Performance { get; set; }
            public string Winner { get; set; }
            public string Movie { get; set; }
            public TaskProperties GanttProperties { get; set; }
        }
        public static List<TaskbarData> TaskTemplateData()
        {
            List<TaskbarData> TaskDataCollection = new List<TaskbarData> {
             new TaskbarData() { TaskId = 1, TaskName = "Product concept", StartDate = new DateTime(2018, 03, 05, 18, 0, 0), EndDate = new DateTime(2018, 03, 05, 18, 15, 0) },
             new TaskbarData() { TaskId = 2, TaskName = "Oscar moments", StartDate = new DateTime(2018, 03, 05, 18, 30, 0), EndDate = new DateTime(2018, 03, 05, 18, 45, 0), Winner = "", Performance = "90th Academy awards kicks-off and Jimmy kimmel hosts the show", ParentId=1 },
            new TaskbarData() { TaskId = 3, TaskName = "Actor in a supporting role", StartDate = new DateTime(2018, 03, 05, 18, 36, 0), EndDate = new DateTime(2018, 03, 05, 18, 42, 0), Predecessor = "1",Winner = "Sam Rockwell", Movie = "Three Billboards Outside Ebbing, Missouri.", ParentId=1 },
             new TaskbarData() { TaskId = 4, TaskName = "Hair and makeup", StartDate = new DateTime(2018, 03, 05, 18, 33, 0), EndDate = new DateTime(2018, 03, 05, 18, 40, 0), Predecessor = "2", Movie = "Darkest Hour", ParentId=1 },
            new TaskbarData() { TaskId = 5, TaskName = "Product release", StartDate = new DateTime(2018, 03, 05, 18, 41, 0), EndDate = new DateTime(2018, 03, 05, 18, 52, 0) },
            new TaskbarData() { TaskId = 6, TaskName = "Costume design", StartDate = new DateTime(2018, 03, 05, 18, 59, 0), EndDate = new DateTime(2018, 03, 05, 19, 10, 0), Predecessor = "3", Winner = "Mark Bridges", Movie = "Phantom Thread", ParentId = 5 },
            new TaskbarData() { TaskId = 7, TaskName = "Documentary feature", StartDate = new DateTime(2018, 03, 05, 19, 11, 0), EndDate = new DateTime(2018, 03, 05, 19, 15, 0), Predecessor = "4", Winner = "Bryan Fogel", Movie = "Icarus", ParentId = 5 },
             new TaskbarData() { TaskId = 8, TaskName = "Best sound editing and sound mixing", StartDate = new DateTime(2018, 03, 05, 19, 16, 0), EndDate = new DateTime(2018, 03, 05, 19, 23, 0), Predecessor = "5", Winner = "Richard King and Alex Gibson", Movie = "Dunkirk", ParentId = 5 }
             };
            return TaskDataCollection;
        }
    }
}
<style>
    .e-custom-parent {
        background-color: #6d619b;
        border: 1px solid #3f51b5;
    }
    .e-custom-performance {
        background-color: #ad7a66;
        border: 1px solid #3f51b5;
    }
    .e-custom-moments {
        background-color: #7ab748;
        border: 1px solid #3f51b5;
    }
    .moments, .face-mask, .oscar {
        position: relative;
        top: 2px;
        bottom: 2px;
        left: 5px;
        padding-right: 4px;
    }
    .e-milestone-top {
        border-bottom-color: #7ab748 !important;
        border-bottom: 1px solid #3f51b5;
    }
    .e-milestone-bottom {
        border-top-color: #7ab748 !important;
        border-top: 1px solid #3f51b5;
    }
</style>
```

![Blazor Gantt Chart with Taskbar Template](images/blazor-gantt-chart-taskbar-template.png)
