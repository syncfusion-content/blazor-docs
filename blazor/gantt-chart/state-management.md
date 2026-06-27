---
layout: post
title: State Management in Blazor Gantt Chart Component | Syncfusion
description: Check out and learn all about State Management in Syncfusion Blazor Gantt Chart component and more here.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# State Management in Blazor Gantt Chart Component

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Gantt Chart component supports state management by retaining its configuration and data in browser local storage after a refresh within the same session. It also provides options to save and load the Gantt state manually.

The properties below can be saved and loaded into a Gantt chart:

Property|
-----|
Columns |
TreeColumnIndex |
GanttFilterSettings |
GanttSortSettings |
GanttSplitterSettings |
GanttTimelineSettings |
ProjectStartDate |
ProjectEndDate |

## Enabling persistence

You can enable persistence to maintain the Gantt chart’s current state in the browser’s local storage. This helps retain settings such as expanded rows and selected tasks after a page reload. To enable this behavior, set the [EnablePersistence](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_EnablePersistence) property to **true**.

N> The state will be persisted based on the **ID** property. So, it is recommended to explicitly set the **ID** property for the Gantt chart.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Gantt


<SfGantt DataSource="@TaskCollection" Width="750px" AllowReordering="true" AllowFiltering="true" AllowSorting="true" AllowResizing="true" ShowColumnMenu="true" EnablePersistence="true">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
                     ParentID="ParentId"></GanttTaskFields>
</SfGantt>
@code {

    public List<TaskData>? TaskCollection { get; set; }
    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
    }
    public class TaskData
    {
        public int TaskId { get; set; }
        public string? TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
    }
    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 21), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 09), Progress = 50, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 09), Progress = 50, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Prepare product sketch and notes", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 08), Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Concept approval", StartDate = new DateTime(2026, 04, 08), EndDate = new DateTime(2026, 04, 08), Duration="0", ParentId = 1 }
        };
        return Tasks;
    }
}


{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjBHtxWkJXadAlhg?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Handling gantt state manually

To manually manage the Gantt chart’s persisted state, use the following methods to save the current state, load a previously stored one, and reset the chart to its default configuration:

* [GetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_GetPersistDataAsync) - Saves the current chart state as a string, suitable for transmission or storage.
* [SetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_SetPersistDataAsync_System_String_) - Loads a previously saved state into the chart.
* [ResetPersistDataAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ResetPersistDataAsync) -  Resets the chart by clearing stored data and restoring its default configuration.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Navigations

<SfGantt @ref="Gantt" DataSource="@TaskCollection" Width="750px"
         Toolbar="Toolbaritems" AllowReordering="true" AllowFiltering="true" AllowSorting="true"
         AllowResizing="true" ShowColumnMenu="true" EnablePersistence="true">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
                     Dependency="Predecessor" ParentID="ParentId"></GanttTaskFields>
    <GanttEvents OnToolbarClick="ToolbarClickHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

<style>
    .e-savestate::before {
        content: '\e74d';
    }

    .e-setstate::before {
        content: '\e75d';
    }

    .e-resetstate::before {
        content: '\e710';
    }
</style>
@code {
    public SfGantt<TaskData>? Gantt;
    public List<TaskData>? TaskCollection { get; set; }
    private string? PersistedState = null;
    private List<Object> Toolbaritems = new List<Object>() {
         "ZoomIn", "ZoomOut", "ZoomToFit",
         new ToolbarItem() { Text = "Save state", TooltipText = "Save state", Id = "GetPersistence", PrefixIcon= "e-savestate" },
         new ToolbarItem() { Text = "Load state", TooltipText = "Load state", Id = "SetPersistence", PrefixIcon= "e-setstate" },
         new ToolbarItem() { Text = "Reset state", TooltipText = "Reset state", Id = "ClearPersistence", PrefixIcon= "e-resetstate" }
    };
    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
    }
    private async void ToolbarClickHandler(ClickEventArgs args)
    {
        if (args.Item.Id == "GetPersistence" && Gantt!=null)
        {
            PersistedState = await Gantt.GetPersistDataAsync();
        }
        else if (args.Item.Id == "SetPersistence" && Gantt != null && PersistedState!=null)
        {
            await Gantt.SetPersistDataAsync(PersistedState);
        }
        else if (args.Item.Id == "ClearPersistence" && Gantt != null)
        {
            await Gantt.ResetPersistDataAsync();
        }
    }
    public class TaskData
    {
        public int TaskId { get; set; }
        public string? TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
    }
    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 21), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 09), Progress = 50, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 09), Progress = 50, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Prepare product sketch and notes", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 08), Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Concept approval", StartDate = new DateTime(2026, 04, 08), EndDate = new DateTime(2026, 04, 08), Duration="0", ParentId = 1 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hDLntxWapiiwjpeN?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

N> You can refer to our [Blazor Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Gantt Chart example](https://blazor.syncfusion.com/demos/gantt-chart/default-functionalities?theme=bootstrap4) to know how to render and configure the Gantt.