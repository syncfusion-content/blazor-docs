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
         DateFormat="hh:mm tt" DataSource="@TaskCollection" Height="450px" Width="800px">
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
    public DateTime ProjectStart = new DateTime(2022, 3, 7, 18, 0, 0);
    public DateTime ProjectEnd = new DateTime(2022, 3, 11, 18, 0, 0);
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
        }
        public static List<TaskbarData> TaskTemplateData()
        {
            List<TaskbarData> TaskDataCollection = new List<TaskbarData>()
            {
                new TaskbarData(){ TaskId = 1, TaskName = "Oscar Moments", StartDate = new DateTime(2022, 03, 07, 18, 0, 0), EndDate = new DateTime(2022, 03, 08, 18, 15, 0), Winner = "", Performance = "90th Academy awards kicks-off and Jimmy Kimmel hosts the show" },
                new TaskbarData(){ TaskId = 2, TaskName = "Actor in Supporting Role", StartDate = new DateTime(2022, 03, 07, 18, 30, 0), EndDate = new DateTime(2022, 03, 07, 19, 20, 0), Winner = "Sam Rockwell", Movie = "Three Billboards Outside Ebbing, Missouri", ParentId = 1, },
                new TaskbarData(){ TaskId = 3, TaskName = "Hair and Makeup", StartDate = new DateTime(2022, 03, 07, 18, 36, 0), EndDate = new DateTime(2022, 03, 07, 19, 42, 0), Movie = "Darkest Hour", ParentId = 1, },
                new TaskbarData() { TaskId = 4, TaskName = "Costume Design", StartDate = new DateTime(2022, 03, 07, 18, 36, 0), EndDate = new DateTime(2022, 03, 07, 19, 50, 0), Winner = "Mark Bridges", Movie = "Phantom Thread", ParentId = 1, }
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
        top: 9px;
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

    .oscar {
        content: url('data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0idXRmLTgiPz4KPCEtLSBHZW5lcmF0b3I6IEFkb2JlIElsbHVzdHJhdG9yIDIyLjEuMCwgU1ZHIEV4cG9ydCBQbHVnLUluIC4gU1ZHIFZlcnNpb246IDYuMDAgQnVpbGQgMCkgIC0tPgo8c3ZnIHZlcnNpb249IjEuMSIgaWQ9IkxheWVyXzEiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgeG1sbnM6eGxpbms9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkveGxpbmsiIHg9IjBweCIgeT0iMHB4IgoJIHZpZXdCb3g9IjAgMCAzMiAzMiIgc3R5bGU9ImVuYWJsZS1iYWNrZ3JvdW5kOm5ldyAwIDAgMzIgMzI7IiB4bWw6c3BhY2U9InByZXNlcnZlIj4KPHN0eWxlIHR5cGU9InRleHQvY3NzIj4KCS5zdDB7ZmlsbDojRkZGRkZGO3N0cm9rZTojMDAwMDAwO3N0cm9rZS1taXRlcmxpbWl0OjEwO30KCS5zdDF7c3Ryb2tlOiMwMDAwMDA7c3Ryb2tlLW1pdGVybGltaXQ6MTA7fQoJLnN0MntmaWxsOiNGRkZGRkY7fQoJLnN0M3tmaWxsOm5vbmU7c3Ryb2tlOiMwMDAwMDA7c3Ryb2tlLW1pdGVybGltaXQ6MTA7fQoJLnN0NHtmaWxsOm5vbmU7c3Ryb2tlOiMwMDAwMDA7c3Ryb2tlLWxpbmVjYXA6cm91bmQ7c3Ryb2tlLWxpbmVqb2luOnJvdW5kO3N0cm9rZS1taXRlcmxpbWl0OjEwO30KCS5zdDV7ZmlsbDpub25lO3N0cm9rZTojMDAwMDAwO3N0cm9rZS1saW5lam9pbjpyb3VuZDtzdHJva2UtbWl0ZXJsaW1pdDoxMDt9Cgkuc3Q2e2ZpbGw6bm9uZTtzdHJva2U6IzAwMDAwMDtzdHJva2Utd2lkdGg6MjtzdHJva2UtbWl0ZXJsaW1pdDoxMDt9Cgkuc3Q3e3N0cm9rZTojRkZGRkZGO3N0cm9rZS1taXRlcmxpbWl0OjEwO30KCS5zdDh7ZmlsbDojRkZGRkZGO3N0cm9rZTojMDAwMDAwO3N0cm9rZS1saW5lam9pbjpyb3VuZDtzdHJva2UtbWl0ZXJsaW1pdDoxMDt9Cgkuc3Q5e3N0cm9rZTojMDAwMDAwO3N0cm9rZS1saW5lam9pbjpyb3VuZDtzdHJva2UtbWl0ZXJsaW1pdDoxMDt9Cgkuc3QxMHtmaWxsOm5vbmU7c3Ryb2tlOiMwMDAwMDA7c3Ryb2tlLXdpZHRoOjI7c3Ryb2tlLWxpbmVjYXA6cm91bmQ7c3Ryb2tlLWxpbmVqb2luOnJvdW5kO3N0cm9rZS1taXRlcmxpbWl0OjEwO30KCS5zdDExe2ZpbGw6bm9uZTtzdHJva2U6IzAwMDAwMDtzdHJva2Utd2lkdGg6MjtzdHJva2UtbGluZWNhcDpyb3VuZDtzdHJva2UtbWl0ZXJsaW1pdDoxMDt9Cgkuc3QxMntmaWxsOm5vbmU7c3Ryb2tlOiMwMDAwMDA7c3Ryb2tlLXdpZHRoOjM7c3Ryb2tlLWxpbmVjYXA6cm91bmQ7c3Ryb2tlLWxpbmVqb2luOnJvdW5kO3N0cm9rZS1taXRlcmxpbWl0OjEwO30KCS5zdDEze2ZpbGw6bm9uZTtzdHJva2U6I0RERERERDtzdHJva2UtbWl0ZXJsaW1pdDoxMDt9CgljaXJjbGUscGF0aHtmaWxsOiNGRkY7fQo8L3N0eWxlPgo8Zz4KCTxjaXJjbGUgY3g9IjE1LjciIGN5PSIyMS45IiByPSI4LjEiLz4KCTxwYXRoIGQ9Ik0yMywxNS40TDI5LDRoLTcuNGwtNC43LDguMkMxOS4zLDEyLjUsMjEuNCwxMy42LDIzLDE1LjR6Ii8+Cgk8cGF0aCBkPSJNMTQuOSwxMi4yTDEwLjIsNEgzbDUuNywxMS4xQzEwLjMsMTMuNSwxMi41LDEyLjQsMTQuOSwxMi4yeiIvPgo8L2c+Cjwvc3ZnPgo=');
    }

    .face-mask {
        content: url('data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0idXRmLTgiPz4KPCEtLSBHZW5lcmF0b3I6IEFkb2JlIElsbHVzdHJhdG9yIDIyLjEuMCwgU1ZHIEV4cG9ydCBQbHVnLUluIC4gU1ZHIFZlcnNpb246IDYuMDAgQnVpbGQgMCkgIC0tPgo8c3ZnIHZlcnNpb249IjEuMSIgaWQ9IkxheWVyXzEiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgeG1sbnM6eGxpbms9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkveGxpbmsiIHg9IjBweCIgeT0iMHB4IgoJIHZpZXdCb3g9IjAgMCAzMiAzMiIgc3R5bGU9ImVuYWJsZS1iYWNrZ3JvdW5kOm5ldyAwIDAgMzIgMzI7IiB4bWw6c3BhY2U9InByZXNlcnZlIj4KPHN0eWxlPgoJcGF0aHtmaWxsOiNGRkY7fQo8L3N0eWxlPgo8Zz4KCTxwYXRoIGQ9Ik0yNy40LDE0LjlsLTYuNS0yLjhjLTAuNy0wLjMtMS40LTAuMy0yLjEsMGMtMC41LDAuMy0wLjksMC42LTEuMiwxLjFjLTAuMS0xLTAuMy0xLjktMC44LTIuOGwtMi40LTQuOQoJCWMtMC42LTEuMy0yLjItMS44LTMuNS0xLjJsLTYuNCwzQzMuOSw3LjYsMy40LDguMiwzLjEsOC45Yy0wLjIsMC43LTAuMiwxLjMsMC4xLDJsMi40LDQuOWMxLjMsMi43LDQuMSw0LjQsNy4xLDQuNAoJCWMwLjYsMCwxLjEtMC4xLDEuNy0wLjJoMC4xbDAuMS0wLjFjMC4xLTAuMSwwLjItMC4yLDAuMy0wLjNjLTAuOCwzLDAuNCw2LjMsMyw4LjNMMTgsMjhoMC4xYzAuNCwwLDAuOSwwLDEuMywwCgkJYzMuMSwwLDYtMS44LDcuMi00LjdsMi4xLTVDMjkuNCwxNywyOC43LDE1LjUsMjcuNCwxNC45eiBNMTEuNSw4LjFjMC43LTAuMywxLjMtMC4zLDEuNSwwYzAuMiwwLjMtMC4zLDAuOS0xLDEuMnMtMS4zLDAuMy0xLjUsMAoJCVMxMC44LDguNSwxMS41LDguMXogTTYuMywxMS4zYy0wLjItMC4zLDAuMy0wLjgsMC45LTEuMmMwLjctMC4zLDEuMy0wLjMsMS41LDBjMC4yLDAuMy0wLjIsMC45LTAuOSwxLjIKCQlDNy4xLDExLjcsNi41LDExLjYsNi4zLDExLjN6IE04LjIsMTQuOWMwLDAsNC4xLDAuOCw2LjQtM0MxNC42LDExLjksMTQuNiwxOS41LDguMiwxNC45eiBNMjcuOSwxNy45bC0yLjEsNQoJCWMtMS4yLDIuOC00LjMsNC41LTcuNCw0Yy0yLjUtMi0zLjQtNS4zLTIuMi04LjFsMi4xLTVjMC4yLTAuNCwwLjUtMC43LDAuOS0wLjhjMC40LTAuMiwwLjktMC4yLDEuMywwbDYuNSwyLjgKCQlDMjcuOCwxNi4yLDI4LjIsMTcuMSwyNy45LDE3Ljl6Ii8+Cgk8cGF0aCBkPSJNMjQuOCwxNy44Yy0wLjctMC4zLTEuNC0wLjMtMS41LDAuMWMtMC4xLDAuMywwLjMsMC44LDEsMS4xczEuNCwwLjMsMS41LTAuMUMyNS45LDE4LjUsMjUuNSwxOC4xLDI0LjgsMTcuOHoiLz4KCTxwYXRoIGQ9Ik0xOS45LDE3LjJjMC43LDAuMywxLjQsMC4zLDEuNS0wLjFjMC4xLTAuMy0wLjMtMC44LTEtMS4xYy0wLjctMC4zLTEuNC0wLjMtMS41LDAuMUMxOC44LDE2LjQsMTkuMywxNi45LDE5LjksMTcuMnoiLz4KCTxwYXRoIGQ9Ik0xNy41LDE5LjhjMC43LDcuOCw2LjUsMi44LDYuNSwyLjhDMTkuNiwyMy41LDE3LjUsMTkuOCwxNy41LDE5Ljh6Ii8+CjwvZz4KPC9zdmc+Cg==');
    }

    .moments {
        content: url('data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0idXRmLTgiPz4KPCEtLSBHZW5lcmF0b3I6IEFkb2JlIElsbHVzdHJhdG9yIDIyLjEuMCwgU1ZHIEV4cG9ydCBQbHVnLUluIC4gU1ZHIFZlcnNpb246IDYuMDAgQnVpbGQgMCkgIC0tPgo8c3ZnIHZlcnNpb249IjEuMSIgaWQ9IkxheWVyXzEiIHhtbG5zPSJodHRwOi8vd3d3LnczLm9yZy8yMDAwL3N2ZyIgeG1sbnM6eGxpbms9Imh0dHA6Ly93d3cudzMub3JnLzE5OTkveGxpbmsiIHg9IjBweCIgeT0iMHB4IgoJIHZpZXdCb3g9IjAgMCAzMiAzMiIgc3R5bGU9ImVuYWJsZS1iYWNrZ3JvdW5kOm5ldyAwIDAgMzIgMzI7IiB4bWw6c3BhY2U9InByZXNlcnZlIj4KPHN0eWxlIHR5cGU9InRleHQvY3NzIj4KCS5zdDB7ZmlsbDojRkZGRkZGO3N0cm9rZTojMDAwMDAwO3N0cm9rZS1taXRlcmxpbWl0OjEwO30KCS5zdDF7c3Ryb2tlOiMwMDAwMDA7c3Ryb2tlLW1pdGVybGltaXQ6MTA7fQoJLnN0MntmaWxsOiNGRkZGRkY7fQoJLnN0M3tmaWxsOm5vbmU7c3Ryb2tlOiMwMDAwMDA7c3Ryb2tlLW1pdGVybGltaXQ6MTA7fQoJLnN0NHtmaWxsOm5vbmU7c3Ryb2tlOiMwMDAwMDA7c3Ryb2tlLWxpbmVjYXA6cm91bmQ7c3Ryb2tlLWxpbmVqb2luOnJvdW5kO3N0cm9rZS1taXRlcmxpbWl0OjEwO30KCS5zdDV7ZmlsbDpub25lO3N0cm9rZTojMDAwMDAwO3N0cm9rZS1saW5lam9pbjpyb3VuZDtzdHJva2UtbWl0ZXJsaW1pdDoxMDt9Cgkuc3Q2e2ZpbGw6bm9uZTtzdHJva2U6IzAwMDAwMDtzdHJva2Utd2lkdGg6MjtzdHJva2UtbWl0ZXJsaW1pdDoxMDt9Cgkuc3Q3e3N0cm9rZTojRkZGRkZGO3N0cm9rZS1taXRlcmxpbWl0OjEwO30KCS5zdDh7ZmlsbDojRkZGRkZGO3N0cm9rZTojMDAwMDAwO3N0cm9rZS1saW5lam9pbjpyb3VuZDtzdHJva2UtbWl0ZXJsaW1pdDoxMDt9Cgkuc3Q5e3N0cm9rZTojMDAwMDAwO3N0cm9rZS1saW5lam9pbjpyb3VuZDtzdHJva2UtbWl0ZXJsaW1pdDoxMDt9Cgkuc3QxMHtmaWxsOm5vbmU7c3Ryb2tlOiMwMDAwMDA7c3Ryb2tlLXdpZHRoOjI7c3Ryb2tlLWxpbmVjYXA6cm91bmQ7c3Ryb2tlLWxpbmVqb2luOnJvdW5kO3N0cm9rZS1taXRlcmxpbWl0OjEwO30KCS5zdDExe2ZpbGw6bm9uZTtzdHJva2U6IzAwMDAwMDtzdHJva2Utd2lkdGg6MjtzdHJva2UtbGluZWNhcDpyb3VuZDtzdHJva2UtbWl0ZXJsaW1pdDoxMDt9Cgkuc3QxMntmaWxsOm5vbmU7c3Ryb2tlOiMwMDAwMDA7c3Ryb2tlLXdpZHRoOjM7c3Ryb2tlLWxpbmVjYXA6cm91bmQ7c3Ryb2tlLWxpbmVqb2luOnJvdW5kO3N0cm9rZS1taXRlcmxpbWl0OjEwO30KCS5zdDEze2ZpbGw6bm9uZTtzdHJva2U6I0RERERERDtzdHJva2UtbWl0ZXJsaW1pdDoxMDt9CglwYXRoLGVsbGlwc2V7ZmlsbDojRkZGO30KPC9zdHlsZT4KPGc+Cgk8cGF0aCBkPSJNMzAuMSw2LjNjMC44LTAuNSwxLjEtMS41LDAuNy0yLjRzLTEuNS0xLjItMi4zLTAuN3MtMS4xLDEuNS0wLjcsMi40QzI4LjIsNi40LDI5LjMsNi43LDMwLjEsNi4zeiIvPgoJPHBhdGggZD0iTTMwLjMsNi45Yy0wLjcsMC40LTEuNiwwLjMtMi4zLTAuMkwyOC4yLDljLTAuMiwwLTAuNSwwLjEtMC43LDAuM2wtNS41LDQuM2wtNC4zLTIuOGMtMC4yLTAuMy0wLjUtMC42LTAuOS0wLjhMMTQsOWwtMyw2CgkJTDgsOWwtMi45LDEuMWMtMC4yLDAuMS0wLjQsMC4yLTAuNSwwLjNjLTAuMiwwLjEtMC40LDAuMy0wLjUsMC41bC0zLjYsNi40Yy0wLjIsMC4zLTAuMiwwLjctMC4yLDFsMS43LDguNEMyLjIsMjcuNSwyLjksMjgsMy42LDI4CgkJYzAuMSwwLDAuMiwwLDAuMywwYzAuMiwwLDAuMy0wLjEsMC41LTAuMkw0LDMwaDE0bC0xLjgtMTAuOWwxLjItNC45bDQsMi42YzAuMiwwLjIsMC41LDAuMiwwLjgsMC4yYzAuMywwLDAuNy0wLjEsMC45LTAuM2w1LjUtNC40CgkJYzAsMC4zLTAuMSwwLjYtMC4yLDAuOGMtMC4zLDAuNy0wLjYsMC42LTEuMiwwLjVjLTAuMSwwLTAuMSwwLTAuMiwwbDAsMC4zYzAuMSwwLDAuMiwwLDAuMiwwYzAuMywwLjEsMC43LDAuMSwxLDAKCQljMC4yLTAuMSwwLjQtMC4zLDAuNS0wLjdjMC4xLTAuMywwLjItMC43LDAuMi0xLjFjMC4xLDAsMC4zLTAuMSwwLjMtMC4zbDAsMGwwLjItMC4yYzAuNi0wLjUsMC43LTEuNCwwLjMtMmwwLjctMi44CgkJQzMwLjQsNi45LDMwLjMsNi45LDMwLjMsNi45eiBNNC44LDI1bC0xLjQtNi43bDEuNS0yLjdMNS44LDE5TDQuOCwyNXoiLz4KCTxlbGxpcHNlIGN4PSIxMSIgY3k9IjUiIHJ4PSIzLjUiIHJ5PSI0Ii8+CjwvZz4KPC9zdmc+Cg==');
    }
</style>
```

![Blazor Gantt Chart with Taskbar Template](images/blazor-gantt-chart-taskbar-template.png)
