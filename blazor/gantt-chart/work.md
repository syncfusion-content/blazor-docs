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

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt @ref="Gantt" DataSource="@TaskCollection" Height="450px" Width="1000px" WorkUnit="WorkUnit.Hour" ProjectStartDate="@ProjectStart" ProjectEndDate="@ProjectEnd">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
                     ParentID="ParentID" Work="Work"></GanttTaskFields>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true" ShowDeleteConfirmDialog="true"></GanttEditSettings>
    <GanttResource DataSource="ResourceCollection" Id="Id" Name="Name" TValue="TaskInfoModel" TResources="ResourceInfoModel"></GanttResource>
    <GanttAssignmentFields DataSource="AssignmentCollection" PrimaryKey="PrimaryId" TaskID="TaskID" ResourceID="ResourceId" Units="Unit" TValue="TaskInfoModel" TAssignment="AssignmentModel">
    </GanttAssignmentFields>
    <GanttLabelSettings TValue="TaskInfoModel" RightLabel="Resources"></GanttLabelSettings>
</SfGantt>

@code {
    public SfGantt<TaskInfoModel> Gantt;
    private DateTime ProjectStart = new DateTime(2022, 03, 25);
    private DateTime ProjectEnd = new DateTime(2022, 05, 10);
    private List<TaskInfoModel> TaskCollection { get; set; }
    private List<ResourceInfoModel> ResourceCollection { get; set; }
    private static List<AssignmentModel> AssignmentCollection { get; set; } = new();
    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
        ResourceCollection = GetResources;
        AssignmentCollection = GetAssignmentCollection();
    }

    public class TaskInfoModel
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public string TaskType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentID { get; set; }
        public double? Work { get; set; }
    }
    public class ResourceInfoModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
    public class AssignmentModel
    {
        public int PrimaryId { get; set; }
        public int TaskID { get; set; }
        public int ResourceId { get; set; }
        public double? Unit { get; set; }
    }

    List<ResourceInfoModel> GetResources = new List<ResourceInfoModel>() {
        new ResourceInfoModel() { Id= 1, Name= "Martin Tamer"},
        new ResourceInfoModel() { Id= 2, Name= "Rose Fuller" },
        new ResourceInfoModel() { Id= 3, Name= "Margaret Buchanan" },
        new ResourceInfoModel() { Id= 4, Name= "Fuller King" },
        new ResourceInfoModel() { Id= 5, Name= "Davolio Fuller" },
        new ResourceInfoModel() { Id= 6, Name= "Van Jack" },
        new ResourceInfoModel() { Id= 7, Name= "Fuller Buchanan" },
        new ResourceInfoModel() { Id= 8, Name= "Jack Davolio" },
        new ResourceInfoModel() { Id= 9, Name= "Tamer Vinet" },
        new ResourceInfoModel() { Id= 10, Name= "Vinet Fuller" },
        new ResourceInfoModel() { Id= 11, Name= "Bergs Anton" },
        new ResourceInfoModel() { Id= 12, Name= "Construction Supervisor" }
    };

    public static List<AssignmentModel> GetAssignmentCollection()
    {
        List<AssignmentModel> assignments = new List<AssignmentModel>()
        {
            new AssignmentModel(){ PrimaryId=1, TaskID = 2, ResourceId=1, Unit=70},
            new AssignmentModel(){ PrimaryId=2, TaskID = 2, ResourceId=6},
            new AssignmentModel(){ PrimaryId=3, TaskID = 3, ResourceId=2},
            new AssignmentModel(){ PrimaryId=4, TaskID = 3, ResourceId=3},
            new AssignmentModel(){ PrimaryId=5, TaskID = 3, ResourceId=5},
            new AssignmentModel(){ PrimaryId=6, TaskID = 4, ResourceId=8},
            new AssignmentModel(){ PrimaryId=7, TaskID = 4, ResourceId=9},
            new AssignmentModel(){ PrimaryId=8, TaskID = 6, ResourceId=4},
            new AssignmentModel(){ PrimaryId=9, TaskID = 7, ResourceId=6},
            new AssignmentModel(){ PrimaryId=10, TaskID = 7, ResourceId=8},
            new AssignmentModel(){ PrimaryId=11, TaskID = 8, ResourceId=12},
            new AssignmentModel(){ PrimaryId=12, TaskID = 8, ResourceId=5},
        };
        return assignments;
    }
    public static List<TaskInfoModel> GetTaskCollection()
    {
        List<TaskInfoModel> Tasks = new List<TaskInfoModel>() {
        new TaskInfoModel() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 03, 29), EndDate = new DateTime(2022, 04, 21), TaskType ="FixedDuration" },
        new TaskInfoModel() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 03, 29), Progress = 30, ParentID = 1, Work=16 },
        new TaskInfoModel() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 03, 29), ParentID = 1, Work=96 },
        new TaskInfoModel() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 03, 29), Duration = "1", Progress = 30, ParentID = 1, Work=16 },
        new TaskInfoModel() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 03, 29), EndDate = new DateTime(2022, 04, 21) },
        new TaskInfoModel() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 03, 29), Duration = "3", Progress = 30, ParentID = 5, Work=30 },
        new TaskInfoModel() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 01), Duration = "3", Progress = 30, ParentID = 5, Work=48 },
        new TaskInfoModel() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 01), Duration = "2", ParentID = 5, Work=60 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNLSjaCaWPubJKsb?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Task type

The work, duration and resource unit fields of a task depends upon each other and will change automatically on editing any one of these fields. But you can also set these field’s values as constant using the [TaskType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTaskFields.html#Syncfusion_Blazor_Gantt_GanttTaskFields_TaskType) property. `FixedUnit` is the default `TaskType`. The following values can be set to the `TaskType` property.

* [FixedDuration](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.TaskType.html#Syncfusion_Blazor_Gantt_TaskType_FixedDuration) - Duration task field will remain constant while updating resource unit or work field.
* [FixedWork](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.TaskType.html#Syncfusion_Blazor_Gantt_TaskType_FixedWork) - Work field will remain constant while updating resource unit or duration fields.
* [FixedUnit](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.TaskType.html#Syncfusion_Blazor_Gantt_TaskType_FixedUnit) - Resource units will remain constant while updating duration or work field.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt @ref="Gantt" DataSource="@TaskCollection" Height="450px" Width="1000px" WorkUnit="WorkUnit.Hour" ProjectStartDate="@ProjectStart" ProjectEndDate="@ProjectEnd">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
                     ParentID="ParentID" Work="Work" TaskType="TaskType"></GanttTaskFields>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true" ShowDeleteConfirmDialog="true"></GanttEditSettings>
    <GanttResource DataSource="ResourceCollection" Id="Id" Name="Name" TValue="TaskInfoModel" TResources="ResourceInfoModel"></GanttResource>
    <GanttAssignmentFields DataSource="AssignmentCollection" PrimaryKey="PrimaryId" TaskID="TaskID" ResourceID="ResourceId" Units="Unit" TValue="TaskInfoModel" TAssignment="AssignmentModel">
    </GanttAssignmentFields>
    <GanttLabelSettings TValue="TaskInfoModel" RightLabel="Resources"></GanttLabelSettings>
</SfGantt>

@code {
    public SfGantt<TaskInfoModel> Gantt;
    private DateTime ProjectStart = new DateTime(2022, 03, 25);
    private DateTime ProjectEnd = new DateTime(2022, 05, 10);
    private List<TaskInfoModel> TaskCollection { get; set; }
    private List<ResourceInfoModel> ResourceCollection { get; set; }
    private static List<AssignmentModel> AssignmentCollection { get; set; } = new();
    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
        ResourceCollection = GetResources;
        AssignmentCollection = GetAssignmentCollection();
    }

    public class TaskInfoModel
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public TaskType TaskType { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public double Progress { get; set; }
        public int? ParentID { get; set; }
        public string Notes { get; set; }
        public double? Work { get; set; }
    }

    public class ResourceInfoModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
    }
    public class AssignmentModel
    {
        public int PrimaryId { get; set; }
        public int TaskID { get; set; }
        public int ResourceId { get; set; }
        public double? Unit { get; set; }
    }

    List<ResourceInfoModel> GetResources = new List<ResourceInfoModel>() {
        new ResourceInfoModel() { Id= 1, Name= "Martin Tamer"},
        new ResourceInfoModel() { Id= 2, Name= "Rose Fuller" },
        new ResourceInfoModel() { Id= 3, Name= "Margaret Buchanan" },
        new ResourceInfoModel() { Id= 4, Name= "Fuller King" },
        new ResourceInfoModel() { Id= 5, Name= "Davolio Fuller" },
        new ResourceInfoModel() { Id= 6, Name= "Van Jack" },
        new ResourceInfoModel() { Id= 7, Name= "Fuller Buchanan" },
        new ResourceInfoModel() { Id= 8, Name= "Jack Davolio" },
        new ResourceInfoModel() { Id= 9, Name= "Tamer Vinet" },
        new ResourceInfoModel() { Id= 10, Name= "Vinet Fuller" },
        new ResourceInfoModel() { Id= 11, Name= "Bergs Anton" },
        new ResourceInfoModel() { Id= 12, Name= "Construction Supervisor" }
    };

    public static List<AssignmentModel> GetAssignmentCollection()
    {
        List<AssignmentModel> assignments = new List<AssignmentModel>()
        {
            new AssignmentModel(){ PrimaryId=1, TaskID = 2, ResourceId=1, Unit=70},
            new AssignmentModel(){ PrimaryId=2, TaskID = 2, ResourceId=6},
            new AssignmentModel(){ PrimaryId=3, TaskID = 3, ResourceId=2},
            new AssignmentModel(){ PrimaryId=4, TaskID = 3, ResourceId=3},
            new AssignmentModel(){ PrimaryId=5, TaskID = 3, ResourceId=5},
            new AssignmentModel(){ PrimaryId=6, TaskID = 4, ResourceId=8},
            new AssignmentModel(){ PrimaryId=7, TaskID = 4, ResourceId=9},
            new AssignmentModel(){ PrimaryId=8, TaskID = 6, ResourceId=4},
            new AssignmentModel(){ PrimaryId=9, TaskID = 7, ResourceId=6},
            new AssignmentModel(){ PrimaryId=10, TaskID = 7, ResourceId=8},
            new AssignmentModel(){ PrimaryId=11, TaskID = 8, ResourceId=12},
            new AssignmentModel(){ PrimaryId=12, TaskID = 8, ResourceId=5},
        };
        return assignments;
    }
    public static List<TaskInfoModel> GetTaskCollection()
    {
        List<TaskInfoModel> Tasks = new List<TaskInfoModel>() {
            new TaskInfoModel() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 03, 28), EndDate = new DateTime(2022, 07, 28), TaskType = TaskType.FixedDuration, Work=128, Duration="4" },
            new TaskInfoModel() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 03, 29), Progress = 30, ParentID = 1, Duration="2", Work=16, TaskType = TaskType.FixedWork },
            new TaskInfoModel() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 03, 29), ParentID = 1, Work=96, Duration="4", TaskType = TaskType.FixedWork },
            new TaskInfoModel() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 03, 29), Duration = "1", Progress = 30, ParentID = 1, Work=16, TaskType = TaskType.FixedWork },
            new TaskInfoModel() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 02), EndDate = new DateTime(2022, 04, 06), TaskType = TaskType.FixedDuration, Duration="4" },
            new TaskInfoModel() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 02), Duration = "3", Progress = 30, ParentID = 5, Work=30, TaskType = TaskType.FixedWork },
            new TaskInfoModel() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 03), Duration = "3", Progress = 30, ParentID = 5, TaskType = TaskType.FixedWork, Work=48 },
            new TaskInfoModel() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 03), Duration = "2", ParentID = 5, Work=60, TaskType = TaskType.FixedWork }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNBIDEsasEsvevVE?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

The following table explains how the work, duration, and resource unit fields will get updated on changing any of the fields

Task Type | Changes in Duration | Changes in work | Changes in Resource Units
-----|-----|-----|-----
Fixed Duration | Updates work value | Updates Resource unit | Updates work value
Fixed Work | Updates Resource unit. Note: For manually scheduled task work will be updated.| Updates Duration value. Note: For manually scheduled task resource unit updates. | Updates Duration value. Note: For manually scheduled task work field updates.
Fixed Unit | Updates work value | Updates Duration value. Note: For manually scheduled task resource unit updates.| Updates Duration value. Note: For manually scheduled task work field updates.

N> Fixed Unit is the default TaskType in Gantt. The above calculations are not applicable for Milestones.

You can refer to our [Blazor Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Gantt Chart example](https://blazor.syncfusion.com/demos/gantt-chart/default-functionalities?theme=bootstrap4) to know how to render and configure the Gantt.