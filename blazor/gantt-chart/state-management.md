---
layout: post
title: State Management in Blazor Gantt Chart Component | Syncfusion
description: Check out and learn all about State Management in Syncfusion Blazor Gantt Chart component and more here.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# State Management in Blazor Gantt Chart Component

Gantt Chart component retains its state using local storage on browser reload. Also, it allows users to save and load the Gantt state manually. The Gantt will use a user-provided state to render instead of its properties provided declaratively.

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

State persistence allows the Gantt chart to retain the current Gantt state in the browser's local storage for state maintenance. This action is handled through the [EnablePersistence](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_EnablePersistence) property, which is disabled by default. When it is enabled, some properties of the Gantt will be retained even after refreshing the page.

N> The state will be persisted based on the **ID** property. So, it is recommended to explicitly set the **ID** property for the Gantt chart.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Navigations

<SfGantt ID="Persist" @ref="Gantt" DataSource="@TaskCollection" Width="750px" AllowReordering="true" AllowFiltering="true" AllowSorting="true"
                AllowResizing="true" ShowColumnMenu="true" EnablePersistence="true">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
                     ParentID="ParentID"></GanttTaskFields>
    
</SfGantt>
@code{
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
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentID { get; set; }
    }
    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2021, 04, 05), EndDate = new DateTime(2021, 04, 21), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2021, 04, 05), Duration = "4", Progress = 50, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2021, 04, 05), Duration = "4", Progress = 50, ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Prepare product sketch and notes", StartDate = new DateTime(2021, 04, 05), Duration = "2", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Concept approval", StartDate = new DateTime(2021, 04, 08), EndDate = new DateTime(2021, 04, 08), Duration="0", ParentID = 1 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZLosXtaAqKJScjD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Handling gantt state manually

You can manually handle the Gantt chart’s state by using built-in state persistence methods. You can use `GetPersistDataAsync`, `SetPersistDataAsync`, and `ResetPersistDataAsync` methods of the Gantt chart to save, load, and reset the Gantt chart's persisted state, respectively.

* `GetPersistData` - Returns Gantt chart properties as a string value, which is suitable for sending them over a network and storing them in databases.
* `SetPersistData` - Loads already saved state of the Gantt chart.
* `ResetPersistData` - Clears persisted data in window local storage and renders the Gantt chart with its original property values.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Navigations

<SfGantt ID="Persist" @ref="Gantt" DataSource="@TaskCollection" Width="750px"
                Toolbar="Toolbaritems" AllowReordering="true" AllowFiltering="true" AllowSorting="true"
                AllowResizing="true" ShowColumnMenu="true" EnablePersistence="true">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
                    Dependency="Predecessor" ParentID="ParentID"></GanttTaskFields>
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
@code{
    private SfGantt<TaskData> Gantt;
    private List<TaskData> TaskCollection { get; set; }
    private string PersistedState = null; 
    private List<Object> Toolbaritems = new List<Object>() {
         "ZoomIn", "ZoomOut", "ZoomToFit",
         new ToolbarItem() { Text = "Save state", TooltipText = "Save state", Id = "GetPersistence", PrefixIcon= "e-savestate" },
         new ToolbarItem() { Text = "Load state", TooltipText = "Load state", Id = "SetPersistence", PrefixIcon= "e-setstate" },
         new ToolbarItem() { Text = "Reset state", TooltipText = "Reset state", Id = "ClearPersistence", PrefixIcon= "e-resetstate" }
    };
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }
    private async void ToolbarClickHandler(ClickEventArgs args)
    {
        if (args.Item.Id == "GetPersistence")
        {
            PersistedState = await Gantt.GetPersistDataAsync();
        }
        else if (args.Item.Id == "SetPersistence")
        {
            await Gantt.SetPersistDataAsync(PersistedState);  
        }
        else if (args.Item.Id == "ClearPersistence")
        {
            await Gantt.ResetPersistDataAsync();  
        }
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
        List<TaskData> Tasks = new List<TaskData>() {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2021, 04, 05), EndDate = new DateTime(2021, 04, 21), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2021, 04, 05), Duration = "4", Progress = 50, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2021, 04, 05), Duration = "4", Progress = 50, ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Prepare product sketch and notes", StartDate = new DateTime(2021, 04, 05), Duration = "2", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Concept approval", StartDate = new DateTime(2021, 04, 08), EndDate = new DateTime(2021, 04, 08), Duration="0", ParentID = 1 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXLysDXYUAfEzjAE?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> You can refer to our [Blazor Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Gantt Chart example](https://blazor.syncfusion.com/demos/gantt-chart/default-functionalities?theme=bootstrap4) to know how to render and configure the Gantt.