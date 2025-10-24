---
layout: post
title: Top tier and bottom tier in Blazor Gantt Chart Component | Syncfusion
description: Learn how to configure top and bottom tiers in the Syncfusion Blazor Gantt Chart component using timeline settings such as unit, format, count, and formatter.
platform: Blazor
control: Top tier and bottom tier
documentation: ug
---

# Top tier and bottom tier in Blazor Gantt Chart component

The Blazor Gantt Chart component supports a two-tier timeline layout, enabling customization of both the top and bottom tiers through specific configuration options.

- [TopTier](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTimelineSettings.html#Syncfusion_Blazor_Gantt_GanttTimelineSettings_TopTier) and [BottomTier](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTimelineSettings.html#Syncfusion_Blazor_Gantt_GanttTimelineSettings_BottomTier): Define the structure and visibility of each timeline tier.
- [Unit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTimelineTierSettings.html#Syncfusion_Blazor_Gantt_GanttTimelineTierSettings_Unit): Specifies the time unit for each tier, such as day, week, or month.
- [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTimelineTierSettings.html#Syncfusion_Blazor_Gantt_GanttTimelineTierSettings_Format): Determines the date format displayed in timeline cells.
- [Count](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTimelineTierSettings.html#Syncfusion_Blazor_Gantt_GanttTimelineTierSettings_Count): Combines multiple time units into a single timeline cell.
- [Formatter](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTimelineTierSettings.html#Syncfusion_Blazor_Gantt_GanttTimelineTierSettings_Formatter): Applies a custom method to format the timeline cell values programmatically.

These properties allow precise control over how time intervals are displayed, enhancing the readability and usability of the Gantt chart across various project scales.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate"
               Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttTimelineSettings>
        <GanttTopTierSettings Unit="TimelineViewMode.Month" Format="MMM"></GanttTopTierSettings>
        <GanttBottomTierSettings Unit="TimelineViewMode.Day" Count="2"></GanttBottomTierSettings>
    </GanttTimelineSettings>
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
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentID { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 21), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 04, 21), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 40, ParentID = 5 },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0", Progress = 30, ParentID = 5 },
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtrSWXicLfvvejyd?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Combining timeline cells

In the Blazor Gantt Chart component, timeline cells in the top and bottom tiers can be merged by grouping multiple time units into a single cell. This behavior is controlled using the `Count` property in both `TopTier` and `BottomTier` configurations.

- [TopTier.count](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTimelineTierSettings.html#Syncfusion_Blazor_Gantt_GanttTimelineTierSettings_Count): Specifies the number of time units to combine in each top-tier cell.
- [BottomTier.count](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTimelineTierSettings.html#Syncfusion_Blazor_Gantt_GanttTimelineTierSettings_Count): Specifies the number of time units to combine in each bottom-tier cell.

By adjusting these values, the timeline can display broader or more granular intervals, improving visibility for long-term or short-term project views.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate"
            Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttTimelineSettings TimelineUnitSize="100">
        <GanttTopTierSettings Unit="TimelineViewMode.Year"></GanttTopTierSettings>
        <GanttBottomTierSettings Unit="TimelineViewMode.Month" Format="MMM" Count="6"></GanttBottomTierSettings>
    </GanttTimelineSettings>
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
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentID { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 08, 21), },
            new TaskData() { TaskID = 2, TaskName = "Identify site location", StartDate = new DateTime(2022, 04, 05), Duration = "150", Progress = 70, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "150", Progress = 50, ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "150", Progress = 50, ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 05, 06), EndDate = new DateTime(2022, 09, 21), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 05, 06), Duration = "150", Progress = 70, ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 05, 06), Duration = "150", Progress = 50, ParentID = 5 },
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXVeMjsmrILGXGvG?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Format value of timeline cell

In the Blazor Gantt Chart component, the values displayed in the top and bottom timeline cells can be formatted using either standard date format strings or custom formatter methods.

- [TopTier.Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTimelineTierSettings.html#Syncfusion_Blazor_Gantt_GanttTimelineTierSettings_Format) and [BottomTier.Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTimelineTierSettings.html#Syncfusion_Blazor_Gantt_GanttTimelineTierSettings_Format): Define the date format for timeline cells using predefined format strings.
- [TopTier.formatter](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTimelineTierSettings.html#Syncfusion_Blazor_Gantt_GanttTimelineTierSettings_Formatter) and [BottomTier.formatter](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTimelineTierSettings.html#Syncfusion_Blazor_Gantt_GanttTimelineTierSettings_Formatter): Apply custom logic to format timeline cell values programmatically.

These options provide flexibility in presenting timeline data according to project requirements or localization needs.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px" ProjectStartDate="@ProjectStart" ProjectEndDate="@ProjectEnd">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttTimelineSettings TimelineUnitSize=50>
        <GanttTopTierSettings Unit="TimelineViewMode.Month" Count="3">
           <FormatterTemplate >
               @{
                   @if(context.Tier=="top"){
                       @this.Formatter((context.Date))
                   }
               }
           </FormatterTemplate>
        </GanttTopTierSettings>
        <GanttBottomTierSettings Unit="TimelineViewMode.Month" Format="MMM"></GanttBottomTierSettings>
    </GanttTimelineSettings>
</SfGantt>

@code{
    private DateTime ProjectStart = new DateTime(2022, 01, 10);
    private DateTime ProjectEnd = new DateTime(2022, 12, 10);
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
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentID { get; set; }
    }
    public string Formatter(DateTime? date) {
        DateTime dateTime=(DateTime)(date);
        var month = dateTime.Month;
        if (month >= 0 && month <= 2) {
            return "Q1";
        } else if (month >= 3 && month <= 5) {
            return "Q2";
        } else if (month >= 6 && month <= 8) {
            return "Q3";
        } else {
            return "Q4";
        }
    }
    public static List <TaskData> GetTaskCollection() {
    List <TaskData> Tasks = new List <TaskData> () {
        new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 06, 08) },
        new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "20", Progress = 30, ParentID = 1 },
        new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "24", Progress = 40, ParentID = 1 },
        new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 05, 05), Duration = "25", Progress = 30, ParentID = 1 },
        new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 06, 06), EndDate = new DateTime(2022, 09, 02) },
        new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 06, 06), Duration = "33", Progress = 30, ParentID = 5 },
        new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 07, 06), Duration = "23", Progress = 40, ParentID = 5 },
        new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 08, 06), Duration = "20", Progress = 30, ParentID = 5 }
    };
    return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZrSsNimUskhhuZd?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Timeline cell width

In the Blazor Gantt Chart component, the width of timeline cells can be configured using the [TimelineSettings.TimelineUnitSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTimelineSettings.html#Syncfusion_Blazor_Gantt_GanttTimelineSettings_TimelineUnitSize) property within [TimelineSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTimelineSettings.html). This value directly sets the width of the bottom tier cells.

The width of the top tier cells is automatically calculated based on the bottom tier's unit and the specified `TimelineUnitSize`. This ensures consistent scaling across both tiers while maintaining clarity in the timeline view.

- [TimelineSettings.TimelineUnitSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTimelineSettings.html#Syncfusion_Blazor_Gantt_GanttTimelineSettings_TimelineUnitSize): Defines the pixel width of each bottom-tier timeline cell.
- [TopTier.Unit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTimelineTierSettings.html#Syncfusion_Blazor_Gantt_GanttTimelineTierSettings_Unit): Determines how the top-tier cell width is derived relative to the bottom tier.

This configuration allows precise control over the visual density of the timeline, supporting both detailed and high-level project views.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt DataSource="@TaskCollection" Height="450px" Width="1000px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate"
              Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttTimelineSettings TimelineUnitSize=150></GanttTimelineSettings>
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
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentID { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 08), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 04, 08), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 40, ParentID = 5 },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0", Progress = 30, ParentID = 5 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZBSMZCQKVggEfTc?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}