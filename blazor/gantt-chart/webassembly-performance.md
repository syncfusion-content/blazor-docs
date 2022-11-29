---
layout: post
title: WebAssembly Performance in Blazor Gantt Component | Syncfusion
description: Checkout and learn here all about WebAssembly Performance in Syncfusion Blazor Gantt component and more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# WebAssembly Performance in Blazor Gantt Component

This section provides performance guidelines for using the Syncfusion Gantt Chart component efficiently in the Blazor WebAssembly application. The general framework Blazor WebAssembly performance guidelines can be found [here](https://docs.microsoft.com/en-us/aspnet/core/blazor/webassembly-performance-best-practices).

> Refer to the Getting Started with [Blazor Server-Side Gantt](https://blazor.syncfusion.com/documentation/getting-started/blazor-server-side-visual-studio/) and [Blazor WebAssembly Gantt](https://blazor.syncfusion.com/documentation/gantt-chart/how-to/blazor-webassembly-gantt-using-visual-studio/) documentation pages for configuration specifications.

## Avoid unnecessary component renders

During Blazor diffing algorithm, every cell of the Gantt Chart component and its child component will be checked for re-rendering. For instance, having [EventCallBack](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.eventcallback?view=aspnetcore-6.0) on the application or Gantt Chart will check every child component once the event callback is completed.

You can have fine-grained control over Gantt Chart component rendering. The [PreventRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_PreventRender_System_Boolean_) method helps you to avoid unnecessary re-rendering of the Gantt Chart component. This method internally overrides the [ShouldRender](https://docs.microsoft.com/en-us/dotnet/api/microsoft.aspnetcore.components.componentbase.shouldrender?view=aspnetcore-6.0) method of the Gantt Chart to prevent rendering.

In the following example:

* The [PreventRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_PreventRender_System_Boolean_) method is called in the **IncrementCount** method which is a click callback.

* Now, Gantt Chart component will not be a part of the rendering which happens because of the click event and **currentCount** alone will get updated.

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
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
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
> The [PreventRender](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_PreventRender_System_Boolean_) method accepts the Boolean argument that accepts true or false to disable or enable rendering respectively.
This method can be used only after the Gantt component completed the initial rendering. Calling this method during initial rendering will not have any effect.

