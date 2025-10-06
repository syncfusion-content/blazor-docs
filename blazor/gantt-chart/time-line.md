---
layout: post
title: Time Line in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about Time Line in Syncfusion Blazor Gantt Chart component and much more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Time Line in Blazor Gantt Chart Component

In the [Blazor Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart) component, timeline is used to represent the project duration as individual cells with defined unit and formats.

## Timeline view modes

Gantt Chart contains the following in-built timeline view modes:

* Hour
* Week
* Month
* Year

Timescale mode in Gantt Chart can be defined by using [GanttTimelineSettings.TimelineViewMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTimelineSettings.html#Syncfusion_Blazor_Gantt_GanttTimelineSettings_TimelineViewMode) property and also you can define timescale mode of top tier and bottom tier by using `GanttTopTierSettings.Unit` and `GanttBottomTierSettings.Unit` properties.

Following table explains how top tier and bottom tier unit changes as per `GanttTimelineSettings.TimelineViewMode` property.

Timeline ViewMode | Top tier Unit | Bottom tier Unit
-----|-----|-----
Year | Year | Month
Month | Month | Week
Week | Week | Day
Day | Day | Hour
Hour | Hour | Minute

### Week timeline mode

In the `Week` timeline mode, top tier of the schedule header displays the weeks, where as bottom tier of the header displays the days. Refer the following code example.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt DataSource="@TaskCollection" Height="450px" Width="900px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate"
              Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttTimelineSettings TimelineViewMode="TimelineViewMode.Week"></GanttTimelineSettings>
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
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 11), },
            new TaskData() { TaskID = 2, TaskName = "Identify site location", StartDate = new DateTime(2022, 04, 05), Duration = "5", Progress = 70, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "5", Progress = 50, ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "5", Progress = 50, ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 04, 12), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "5", Progress = 70, ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "5", Progress = 50, ParentID = 5 },
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDBIturSzTRBPHsC?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Month timeline mode

In the `Month` timeline mode, top tier of the schedule header displays the months, whereas bottom tier of the schedule header displays its corresponding weeks. Refer the following code example.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt DataSource="@TaskCollection" Height="450px" Width="900px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate"
               Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttTimelineSettings TimelineUnitSize=120 TimelineViewMode="TimelineViewMode.Month"></GanttTimelineSettings>
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
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 05, 02), },
            new TaskData() { TaskID = 2, TaskName = "Identify site location", StartDate = new DateTime(2022, 04, 05), Duration = "20", Progress = 70, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "20", Progress = 50, ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "20", Progress = 50, ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 05, 03), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "20", Progress = 70, ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "20", Progress = 50, ParentID = 5 },
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNLoXuheJyqkWrNI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor Gantt Chart with Month Timeline Mode](images/blazor-gantt-chart-month-mode.png)

### Year timeline mode

In the `Year` timeline mode, top tier of the schedule header displays the years, where as bottom tier of the schedule header displays its corresponding months. Refer the following code example.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt DataSource="@TaskCollection" Height="450px" Width="900px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate"
                Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttTimelineSettings TimelineUnitSize=75 TimelineViewMode="TimelineViewMode.Year">
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
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 13), },
            new TaskData() { TaskID = 2, TaskName = "Identify site location", StartDate = new DateTime(2022, 04, 05), Duration = "50", Progress = 70, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "50", Progress = 50, ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "50", Progress = 50, ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 05, 06), EndDate = new DateTime(2022, 09, 14), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 05, 06), Duration = "50", Progress = 70, ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 05, 06), Duration = "50", Progress = 50, ParentID = 5 },
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LZBeDkLIzSdLmoht?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Day timeline mode

In the `Day` timeline mode, top tier of the schedule header displays the days, where as the bottom tier of the schedule header displays its corresponding hours. Refer the following code example.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt DataSource="@TaskCollection" DurationUnit="DurationUnit.Hour" Height="450px" Width="900px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate"
              Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttTimelineSettings TimelineViewMode="TimelineViewMode.Day"></GanttTimelineSettings>
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
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 05), },
            new TaskData() { TaskID = 2, TaskName = "Identify site location", StartDate = new DateTime(2022, 04, 05, 09, 0, 0), Duration = "5", Progress = 70, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05, 09, 0, 0), Duration = "5", Progress = 50, ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05, 09, 0, 0), Duration = "5", Progress = 50, ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 04, 06), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06, 11, 0, 0), Duration = "5", Progress = 70, ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06, 11, 0, 0), Duration = "5", Progress = 50, ParentID = 5 },
        };
        return Tasks;
    }   
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNLojOLSzeltwnos?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Hour timeline mode

An `Hour` timeline mode tracks the tasks in minutes scale. In this mode, the top tier of the schedule header displays hour scale and the bottom tier of the header displays its corresponding minutes.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt DataSource="@TaskCollection" DurationUnit="DurationUnit.Minute" Height="450px" Width="900px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate"
               Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttTimelineSettings TimelineViewMode="TimelineViewMode.Hour"></GanttTimelineSettings>
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
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 05), },
            new TaskData() { TaskID = 2, TaskName = "Identify site location", StartDate = new DateTime(2022, 04, 05, 8, 4, 0), Duration = "5", Progress = 70, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05, 8, 4, 0), Duration = "5", Progress = 50, ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05, 8, 4, 0), Duration = "5", Progress = 50, ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 04, 06), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06, 8, 10, 0), Duration = "5", Progress = 70, ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06, 8, 10, 0), Duration = "5", Progress = 50, ParentID = 5 },
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDLStaBezSOKXmrc?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Week start day customization

In the Gantt Chart component, you can customize the week start day using the `GanttTimelineSettings.WeekStartDay` property. By default,the `GanttTimelineSettings.WeekStartDay` is set to 0, which specifies the Sunday as a start day of the week. But, you can customize the week start day by using the following code example.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt DataSource="@TaskCollection" Height="450px" Width="1000px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate"
              Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttTimelineSettings WeekStartDay=3></GanttTimelineSettings>
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZhSDEhIzRdxRtsg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customize automatic timescale update action

In the Gantt Chart component, the schedule timeline will be automatically updated when the tasks date values are updated beyond the project start date and end date ranges. This can be enabled or disabled using the `GanttTimelineSettings.UpdateTimescaleView` property.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate"
             Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttEditSettings AllowEditing="true" AllowTaskbarEditing="true"></GanttEditSettings>
    <GanttTimelineSettings UpdateTimescaleView="false"></GanttTimelineSettings>
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rXLyZuLITGiVqlar?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Timeline cells tooltip

In the Gantt Chart component, you can enable or disable the mouse hover tooltip of timeline cells using the [GanttTimelineSettings.ShowTooltip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTimelineSettings.html#Syncfusion_Blazor_Gantt_GanttTimelineSettings_ShowTooltip) property. The default value of this property is true. The following code example shows how to enable the timeline cells tooltip in Gantt Chart.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate"
                     Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttTimelineSettings ShowTooltip="true"></GanttTimelineSettings>
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
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 07), },
            new TaskData() { TaskID = 2, TaskName = "Identify site location", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 70, ParentID = 1, },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 50, ParentID = 1, },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 50, ParentID = 1, },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 10), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 70, ParentID = 5, },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 04), Duration = "3", Progress = 50, ParentID = 5, }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDhotkVoJwAgwcxt?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Template

Customizing the timeline cell tooltip in a Gantt Chart using [GanttTooltipSettings.TimelineCellTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTooltipSettings-1.html#Syncfusion_Blazor_Gantt_GanttTooltipSettings_1_TimelineCellTemplate) allows you to display additional information and elements in a more visually appealing and informative way. By combining data bindings and CSS styles, you can create custom templates that suit your specific needs and use cases. The following code example shows how to customize the timeline cell tooltip in Gantt Chart.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt @ref="Gantt" DataSource="@TaskCollection" Height="450px" Width="1000px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration"
                     Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttTimelineSettings ShowTooltip="true"></GanttTimelineSettings>
    <GanttTooltipSettings TValue="TaskData">
       <TimelineCellTemplate> 
            @{ 
                var timelineCell = context as string; 
                <div>
                    <i class="app-icon-calendar"></i>
                    @timelineCell 
                </div>
         } 
        </TimelineCellTemplate>
    </GanttTooltipSettings>
</SfGantt>
@code {
    public SfGantt<TaskData> Gantt;
    public List<TaskData> TaskCollection { get; set; }
    private DateTime ProjectStartDate = new DateTime(2021, 04, 02);
    private DateTime ProjectEndDate = new DateTime(2022, 01, 01);
    protected override void OnInitialized()
    {
        this.TaskCollection = EditingData();
    }
    public class TaskData
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public string Predecessor { get; set; }
        public string Notes { get; set; }
        public int? ParentID { get; set; }
    }
    public static List<TaskData> EditingData()
    {
        List<TaskData> Tasks = new List<TaskData>() {
        new TaskData() { TaskID = 1, TaskName = "Product concept", StartDate = new DateTime(2021, 04, 29), EndDate = new DateTime(2021, 04, 08), Duration = "5 days" },
        new TaskData() { TaskID = 2, TaskName = "Defining the product usage", StartDate = new DateTime(2021, 04, 01), EndDate = new DateTime(2021, 04, 08), Duration = "3", Progress = 30, ParentID = 1 },
        new TaskData() { TaskID = 3, TaskName = "Defining the target audience", StartDate = new DateTime(2021, 04, 02), EndDate = new DateTime(2021, 04, 04), Duration = "3", Progress = 40, ParentID = 2 },
        new TaskData() { TaskID = 4, TaskName = "Prepare product sketch and notes", StartDate = new DateTime(2021, 03, 28), EndDate = new DateTime(2021, 04, 08), Duration = "2", Progress = 30, ParentID = 3, Predecessor="2" },
        new TaskData() { TaskID = 5, TaskName = "Concept approval", StartDate = new DateTime(2021, 04, 08), EndDate = new DateTime(2021, 04, 08), Duration="0",Predecessor="3,4" },
        new TaskData() { TaskID = 6, TaskName = "Market research", StartDate = new DateTime(2021, 04, 09), EndDate = new DateTime(2021, 04, 14), Predecessor="2", Duration = "4", Progress = 30 },
        new TaskData() { TaskID = 7, TaskName = "Demand analysis", StartDate = new DateTime(2021, 04, 09), EndDate = new DateTime(2021, 04, 12), Duration = "4", Progress = 40, ParentID = 6 },
        new TaskData() { TaskID = 8, TaskName = "Customer strength", StartDate = new DateTime(2021, 04, 09), EndDate = new DateTime(2021, 04, 12), Duration = "4", Progress = 30, ParentID = 7, Predecessor="5" },
    };
        return Tasks;
    }
}
<style>
    @@font-face {
        font-family: 'Gantt control icon';
        src: url(data:application/x-font-ttf;charset=utf-8;base64,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) format('truetype');
        font-weight: normal;
        font-style: normal;
    }

    i {
        font-family: 'Gantt control icon' !important;
        speak: none;
        vertical-align: sub;
        font-size: 18px;
        font-style: normal;
        font-weight: normal;
        font-variant: normal;
        text-transform: none;
        line-height: 1;
        -webkit-font-smoothing: antialiased;
        -moz-osx-font-smoothing: grayscale;
    }

    .app-icon-calendar:before {
        content: "\e700";
        width: 40px;
        height: 40px;
    }
</style>

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXreXkrIfwyMRUqR?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}