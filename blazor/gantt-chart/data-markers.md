---
layout: post
title: Data Markers in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about Data Markers in Syncfusion Blazor Gantt Chart component and much more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Data Markers in Blazor Gantt Chart Component

Data markers are visual indicators that highlight significant events, milestones, or important dates within individual project tasks. These markers provide immediate visual context about critical moments in task timelines, enabling effective identification of key dates and tracking of important events at the task level. Understanding data markers implementation ensures effective project visualization and milestone tracking throughout project development cycles.

Data markers utilize specific properties to define their appearance, positioning, and interactive behavior within task timelines:

**Date specification**: The [Date](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttIndicator.html#Syncfusion_Blazor_Gantt_GanttIndicator_Date) property establishes the exact timeline position where the marker appears. This date value determines marker placement relative to the task's start and end dates, ensuring accurate event representation.

**Visual styling**: The [IconClass](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttIndicator.html#Syncfusion_Blazor_Gantt_GanttIndicator_IconClass) property defines the CSS class that controls marker visual appearance. This property enables custom styling through icon fonts, background images, or CSS-based graphics to distinguish different marker types.

**Identification**: The [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttIndicator.html#Syncfusion_Blazor_Gantt_GanttIndicator_Name) property provides unique identification for each marker. This name serves as an internal reference and can be used for programmatic marker manipulation or event handling.

**Interactive content**: The [Tooltip](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttIndicator.html#Syncfusion_Blazor_Gantt_GanttIndicator_Tooltip) property supplies descriptive text that displays when users hover over markers. This property enhances user experience by providing detailed context about marker significance and related event information.

**Tooltip Rendering Requirements**: Data marker tooltips render only when the tooltip property contains valid content values. Empty or undefined tooltip properties result in no tooltip display, maintaining clean visual presentation for markers without additional descriptions.

## Data mapping and configuration properties

Data markers represent schedule events for specific tasks through visual indicators positioned at designated dates within task timelines. The component renders markers as icon-based elements that display at precise timeline locations, providing instant visual reference for important task-related events.

**Data structure requirements**: Data markers are defined in the data source as arrays of objects containing marker specifications. Each marker object includes date information, visual styling, identification details, and optional tooltip content for enhanced user interaction.

**Mapping configuration**: The marker array connects to the Gantt component through the [GanttTaskFields.Indicators](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTaskFields.html#Syncfusion_Blazor_Gantt_GanttTaskFields_Indicators) property mapping. This configuration establishes the relationship between data source marker definitions and component rendering logic.

**Multiple marker support**: Tasks can display multiple data markers simultaneously, allowing comprehensive event tracking within individual task contexts. Each marker maintains independent configuration while sharing the same task timeline space.
The following implementation demonstrates comprehensive data marker integration within a Gantt chart, showcasing multiple markers per task with varied styling and tooltip configurations:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}


@using Syncfusion.Blazor.Gantt
<SfGantt @ref="Gantt" DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration"
                     Progress="Progress" ParentID="ParentID" Indicators="Indicators">
    </GanttTaskFields>
</SfGantt>

@code{
    public SfGantt<TaskData> Gantt;
    public List<TaskData> TaskCollection { get; set; }
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }
    public class TaskData
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentID { get; set; }
        public List<GanttIndicator> Indicators { get; set; }
    }
   
    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 10), Indicators=(new List<GanttIndicator>()
            {
                    new GanttIndicator() { Name="product", IconClass="e-btn-icon e-notes-info e-icons e-icon-left e-gantt e-notes-info::before", Date=new DateTime(2022, 01, 11), Tooltip="sales"}
                })
            },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "2", Progress = 30, ParentID = 1, Indicators=(new List<GanttIndicator>()
            {
                    new GanttIndicator(){ Name="customer", IconClass="e-btn-icon e-notes-info e-icons e-icon-left e-gantt e-notes-info::before", Date=new DateTime(2022, 01, 11), Tooltip="people" },
                    new GanttIndicator(){ Name="product", IconClass="e-btn-icon e-notes-info e-icons e-icon-left e-gantt e-notes-info::before", Date=new DateTime(2022, 01, 8), Tooltip="sales" }
                })
            },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 10), Duration = "5", Progress = 40, ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "5", EndDate = new DateTime(2022, 01, 05), Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 07) },
            new TaskData() { TaskID = 6, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "2", Progress = 30, ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentID = 5 },
            new TaskData() { TaskID = 8, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "5", Progress = 30, ParentID = 5 },
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtBIMjZOUHePgDUE?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> You can refer to our [Blazor Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Gantt Chart example](https://blazor.syncfusion.com/demos/gantt-chart/default-functionalities?theme=bootstrap5) to know how to render and configure the Gantt.