---
layout: post
title: WebAssembly Performance in Blazor Gantt Component | Syncfusion
description: Checkout and learn here all about WebAssembly Performance in Syncfusion Blazor Gantt component and more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# WebAssembly Performance in Blazor Gantt Component

This guide outlines performance optimization strategies for using the Syncfusion<sup style="font-size:70%">&reg;</sup> Gantt Chart component efficiently in the Blazor WebAssembly application. The general framework Blazor WebAssembly performance guidelines can be found [here](https://learn.microsoft.com/en-us/aspnet/core/blazor/performance?view=aspnetcore-7.0).

N> Refer to the Getting Started with [Blazor Server-Side Gantt](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio) and [Blazor WebAssembly Gantt](https://blazor.syncfusion.com/documentation/gantt-chart/how-to/blazor-webassembly-gantt-using-visual-studio) documentation pages for configuration specifications.

## Avoid unnecessary component renders

During Blazor's diffing algorithm, every cell of the Gantt Chart component and its child components is evaluated for re-rendering. For example, using [EventCallBack](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.eventcallback?view=aspnetcore-6.0) in the application or Gantt Chart causes all child components to be checked once the callback completes.

To avoid unnecessary re-rendering, use the [PreventRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_PreventRender_System_Boolean_) method. This method internally overrides [ShouldRender](https://learn.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.componentbase.shouldrender?view=aspnetcore-6.0) to control the rendering process.

In the following example:

* The [PreventRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_PreventRender_System_Boolean_) method is called in the **IncrementCount** method which is a click callback.

* As a result, the Gantt Chart component will be excluded from the rendering triggered by the click event and **currentCount** alone will get updated.

```cshtml
@using Syncfusion.Blazor.Gantt

<h1>Counter</h1>

<p>Current count: @currentCount</p>

<button class="btn btn-primary" @onclick="IncrementCount">Click me</button>

<SfGantt @ref="Gantt" DataSource="@TaskCollection" Height="450px" Width="800px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
</SfGantt>

@code{
    public SfGantt<TaskData> Gantt;
    private int currentCount = 0;
    private void IncrementCount()
    {
        Gantt.PreventRender();
        currentCount++;
    }

    public List<TaskData> TaskCollection { get; set; }

    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
    }
    
    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
            {
                new TaskData() { TaskId = 1, TaskName = "Product concept", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 21), Duration = "5days" },
                new TaskData() { TaskId = 2, TaskName = "Defining the product usage", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 21), Duration = "3", Progress = 30, ParentId = 1 },
                new TaskData() { TaskId = 3, TaskName = "Defining the Target audience", EndDate = new DateTime(2022, 01, 10), Progress = 40, ParentId = 1 },
                new TaskData() { TaskId = 4, TaskName = "Prepare product sketch and notes", StartDate = new DateTime(2022, 01, 04), Duration = "2", Progress = 30, ParentId = 1 },
                new TaskData() { TaskId = 5, TaskName = "Concept approval", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 21), Duration="0" },
                new TaskData() { TaskId = 6, TaskName = "Market Research", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 21), Duration = "4", Progress = 30 },
                new TaskData() { TaskId = 7, TaskName = "Demand Analysis", Duration = "4", Progress = 40, ParentId = 6 },
                new TaskData() { TaskId = 8, TaskName = "Customer Strength", StartDate = new DateTime(2022, 01, 10), EndDate = new DateTime(2022, 01, 21), Duration = "4", Progress = 30, ParentId = 7 },
                new TaskData() { TaskId = 9, TaskName = "Market Opportunity analysis", StartDate = new DateTime(2022, 01, 10), EndDate = new DateTime(2022, 01, 21), Duration="4", ParentId= 7 }
            };
        return Tasks;
    }
}
```

N> The [PreventRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_PreventRender_System_Boolean_) method accepts the Boolean argument that accepts true or false to disable or enable rendering respectively.
This method can be used only after the Gantt component completed the initial rendering. Calling this method during initial rendering will not have any effect.

## Avoid unnecessary initial auto-scheduling validation

The Blazor Gantt Chart uses [auto-scheduling](https://blazor.syncfusion.com/documentation/gantt-chart/scheduling-tasks#automatically-scheduled-tasks) by default, which includes initial validation of the data source. If the data source is already validated, repeating this validation during load is unnecessary and affects performance.

To improve load time, set [AutoCalculateDateScheduling](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AutoCalculateDateScheduling) to **false** to disable date scheduling validation, and [EnablePredecessorValidation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_EnablePredecessorValidation) to **false** to disable dependency validation. These validations can be enabled later during dynamic actions using the [Created](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_Created) event.

```cshtml
@using Syncfusion.Blazor.Gantt
<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px" AutoCalculateDateScheduling=@autoCalculateDateScheduling EnablePredecessorValidation=@enablePredecessorValidation>
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId" Dependency="Predecessor">
    </GanttTaskFields>
    <GanttEditSettings AllowEditing="true" AllowTaskbarEditing="true"></GanttEditSettings>
    <GanttEvents Created="GanttCreated" TValue="TaskData"></GanttEvents>
</SfGantt>
@code {
    private bool autoCalculateDateScheduling { get; set; } = false;
    private bool enablePredecessorValidation { get; set; } = false;
    private void GanttCreated()
    {
        autoCalculateDateScheduling = true;
        enablePredecessorValidation = true;
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
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public string Predecessor { get; set; }
        public int? ParentId { get; set; }
    }
    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2019, 04, 05), EndDate = new DateTime(2019, 04, 10), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2019, 04, 05), EndDate = new DateTime(2019, 04, 05),Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2019, 04, 05), EndDate = new DateTime(2019, 04, 10), Duration = "4", Progress = 40, Predecessor = "2", ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2019, 04, 05), Duration = "0", Progress = 30,  ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2019, 04, 11), EndDate = new DateTime(2019, 04, 18), Predecessor = "1FS", },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2019, 04, 11),EndDate = new DateTime(2019, 04, 15), Duration = "3", Progress = 30, Predecessor = "4" , ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2019, 04, 16),EndDate = new DateTime(2019, 04, 18), Duration = "3", Progress = 40, Predecessor = "6" , ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2019, 04, 18), EndDate = new DateTime(2019, 04, 18),Duration = "0", Progress = 30, Predecessor = "7" , ParentId = 5 },
        };
        return Tasks;
    }
}
```
