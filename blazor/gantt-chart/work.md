---
layout: post
title: Work in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about Work in Syncfusion Blazor Gantt Chart component and much more details.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Work in Blazor Gantt Chart Component

## Work

The work is the total hours required to complete a task. Work can be mapped from the data source field using the property [GanttTaskFields.Work](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTaskFields.html#Syncfusion_Blazor_Gantt_GanttTaskFields_Work). Work can be measured in `Hour`, `Day`, `Minute`. By default, work is measured in `Hour` and it can be changed by using the property `WorkUnit`.

N> When the work field is mapped from the data source, the default task type will be `FixedWork`.

```cshtml
@using Syncfusion.Blazor.Gantt
<SfGantt @ref="Gantt" DataSource="@TaskCollection" Height="450px" Width="1000px" WorkUnit="WorkUnit.Hour" ProjectStartDate="@ProjectStart" ProjectEndDate="@ProjectEnd">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
        ParentID="ParentId" Work="Work" ResourceInfo="Resources"></GanttTaskFields>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true" ShowDeleteConfirmDialog="true"></GanttEditSettings>
    <GanttResourceFields Resources="GetResources" Id="ResourceId" Name="ResourceName" Unit="Unit" TResources="ResourceData"></GanttResourceFields>
    <GanttLabelSettings TValue="TaskData" RightLabel="Resources"></GanttLabelSettings>
</SfGantt>

@code{
    public SfGantt<TaskData> Gantt;
    private DateTime ProjectStart = new DateTime(2022, 03, 25);
    private DateTime ProjectEnd = new DateTime(2022, 05, 10);
    private List<TaskData> TaskCollection { get; set; }
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }
    public class ResourceData
    {
        public int ResourceId { get; set; }
        public string ResourceName { get; set; }
        public double Unit { get; set; }

    }
    List<ResourceData> GetResources = new List<ResourceData>() {  
        new ResourceData() { ResourceId= 1, ResourceName= "Martin Tamer" ,Unit=70},
        new ResourceData() { ResourceId= 2, ResourceName= "Rose Fuller" },
        new ResourceData() { ResourceId= 3, ResourceName= "Margaret Buchanan" },
        new ResourceData() { ResourceId= 4, ResourceName= "Fuller King" },
        new ResourceData() { ResourceId= 5, ResourceName= "Davolio Fuller" },
        new ResourceData() { ResourceId= 6, ResourceName= "Van Jack" },
        new ResourceData() { ResourceId= 7, ResourceName= "Fuller Buchanan" },
        new ResourceData() { ResourceId= 8, ResourceName= "Jack Davolio" },
        new ResourceData() { ResourceId= 9, ResourceName= "Tamer Vinet" },
        new ResourceData() { ResourceId= 10, ResourceName= "Vinet Fuller" },
        new ResourceData() { ResourceId= 11, ResourceName= "Bergs Anton" },
        new ResourceData() { ResourceId= 12, ResourceName= "Construction Supervisor" }
    };
    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public string TaskType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
        public double? Work { get; set; }
        public List<ResourceData> Resources { get; set; }
    }
    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() {
        new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 03, 29), EndDate = new DateTime(2022, 04, 21), TaskType ="FixedDuration" },
        new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 03, 29), Progress = 30, ParentId = 1, Work=16, Resources = new List<ResourceData>(){ new ResourceData() { ResourceId=1,Unit=70} ,new ResourceData() { ResourceId=6} } },
        new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 03, 29), Resources = new List<ResourceData>(){ new ResourceData() { ResourceId=2} ,new ResourceData() { ResourceId=3} ,new ResourceData() { ResourceId=5} }, ParentId = 1, Work=96 },
        new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 03, 29), Duration = "1", Progress = 30, ParentId = 1, Resources = new List<ResourceData>(){ new ResourceData() { ResourceId=8} ,new ResourceData() { ResourceId=9} }, Work=16 },
        new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 03, 29), EndDate = new DateTime(2022, 04, 21) },
        new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 03, 29), Duration = "3", Progress = 30, ParentId = 5, Resources = new List<ResourceData>(){ new ResourceData() { ResourceId=4} }, Work=30 },
        new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 01), Duration = "3", Progress = 30, ParentId = 5, Work=48, Resources = new List<ResourceData>(){ new ResourceData() { ResourceId=6},new ResourceData() { ResourceId=8} }, },
        new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 01), Duration = "2", ParentId = 5, Work=60, Resources = new List<ResourceData>(){ new ResourceData() { ResourceId= 12},new ResourceData() { ResourceId= 5} } }
    };
        return Tasks;
    }
}
```

## Task type

The work, duration and resource unit fields of a task depends upon each other and will change automatically on editing any one of these fields. But you can also set these field’s values as constant using the [TaskType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTaskFields.html#Syncfusion_Blazor_Gantt_GanttTaskFields_TaskType) property. `FixedUnit` is the default `TaskType`. The following values can be set to the `TaskType` property.

* [FixedDuration](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.TaskType.html#Syncfusion_Blazor_Gantt_TaskType_FixedDuration) - Duration task field will remain constant while updating resource unit or work field.
* [FixedWork](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.TaskType.html#Syncfusion_Blazor_Gantt_TaskType_FixedWork) - Work field will remain constant while updating resource unit or duration fields.
* [FixedUnit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.TaskType.html#Syncfusion_Blazor_Gantt_TaskType_FixedUnit) - Resource units will remain constant while updating duration or work field.

```cshtml
@using Syncfusion.Blazor.Gantt
<SfGantt @ref="Gantt" DataSource="@TaskCollection" Height="450px" Width="900px" HighlightWeekends="true" ProjectStartDate="@ProjectStart" ProjectEndDate="@ProjectEnd">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId"
        Work="Work" ResourceInfo="Resources" TaskType="TaskType"></GanttTaskFields>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true"></GanttEditSettings>
    <GanttResourceFields Resources="@ResourceCollection" Id="ResourceId" Name="ResourceName" Unit="Unit" TResources="ResourceAlloacteData"></GanttResourceFields>
    <GanttLabelSettings TValue="TaskData" RightLabel="Resources"></GanttLabelSettings>
</SfGantt>

@code{
    private DateTime ProjectStart = new DateTime(2022, 03, 25);
    private DateTime ProjectEnd = new DateTime(2022, 05, 10);
    public SfGantt<TaskData> Gantt;
    private List<TaskData> TaskCollection { get; set; }
    private List<ResourceAlloacteData> ResourceCollection { get; set; }
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
        this.ResourceCollection = GetResources;
    }
    public class ResourceAlloacteData
    {
        public int ResourceId { get; set; }
        public string ResourceName { get; set; }
        public double Unit { get; set; }
    }
    public static List<ResourceAlloacteData> GetResources = new List<ResourceAlloacteData>()
    {
        new ResourceAlloacteData() { ResourceId= 1, ResourceName= "Martin Tamer"},
        new ResourceAlloacteData() { ResourceId= 2, ResourceName= "Rose Fuller" },
        new ResourceAlloacteData() { ResourceId= 3, ResourceName= "Margaret Buchanan" },
        new ResourceAlloacteData() { ResourceId= 4, ResourceName= "Fuller King" },
        new ResourceAlloacteData() { ResourceId= 5, ResourceName= "Davolio Fuller" },
        new ResourceAlloacteData() { ResourceId= 7, ResourceName= "Fuller Buchanan" },
        new ResourceAlloacteData() { ResourceId= 8, ResourceName= "Jack Davolio" },
        new ResourceAlloacteData() { ResourceId= 9, ResourceName= "Tamer Vinet" },
        new ResourceAlloacteData() { ResourceId= 10, ResourceName= "Vinet Fuller" },
        new ResourceAlloacteData() { ResourceId= 11, ResourceName= "Bergs Anton" },
        new ResourceAlloacteData() { ResourceId= 12, ResourceName= "Construction Supervisor" }
    };

    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public TaskType TaskType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public double Progress { get; set; }
        public int? ParentId { get; set; }
        public string Notes { get; set; }
        public double? Work { get; set; }
        public List<ResourceAlloacteData> Resources { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 03, 28), EndDate = new DateTime(2022, 07, 28), TaskType = TaskType.FixedDuration, Work=128, Duration="4" },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 03, 29), Progress = 30, ParentId = 1, Duration="2", Work=16, TaskType = TaskType.FixedWork, Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=1, Unit=70} ,new ResourceAlloacteData() { ResourceId=6} } },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 03, 29), Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=2} ,new ResourceAlloacteData() { ResourceId=3} }, ParentId = 1, Work=96, Duration="4", TaskType = TaskType.FixedWork },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 03, 29), Duration = "1", Progress = 30, ParentId = 1, Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=8} ,new ResourceAlloacteData() { ResourceId=9} }, Work=16, TaskType = TaskType.FixedWork },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 02), EndDate = new DateTime(2022, 04, 06), TaskType = TaskType.FixedDuration, Duration="4" },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 02), Duration = "3", Progress = 30, ParentId = 5, Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=4} }, Work=30, TaskType = TaskType.FixedWork },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 03), Duration = "3", Progress = 30, ParentId = 5, TaskType = TaskType.FixedWork, Work=48, Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=4},new ResourceAlloacteData() { ResourceId=8} }, },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 03), Duration = "2", ParentId = 5, Work=60, TaskType = TaskType.FixedWork, Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId= 12},new ResourceAlloacteData() { ResourceId= 5} }, }
        };
        return Tasks;
    }
}
```

The following table explains how the work, duration, and resource unit fields will get updated on changing any of the fields

Task Type | Changes in Duration | Changes in work | Changes in Resource Units
-----|-----|-----|-----
Fixed Duration | Updates work value | Updates Resource unit | Updates work value
Fixed Work | Updates Resource unit. Note: For manually scheduled task work will be updated.| Updates Duration value. Note: For manually scheduled task resource unit updates. | Updates Duration value. Note: For manually scheduled task work field updates.
Fixed Unit | Updates work value | Updates Duration value. Note: For manually scheduled task resource unit updates.| Updates Duration value. Note: For manually scheduled task work field updates.

N> Fixed Unit is the default TaskType in Gantt. The above calculations are not applicable for Milestones.

You can refer to our [Blazor Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Gantt Chart example](https://blazor.syncfusion.com/demos/gantt-chart/default-functionalities?theme=bootstrap4) to know how to render and configure the Gantt.