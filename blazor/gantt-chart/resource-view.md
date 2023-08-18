---
layout: post
title: Resource View in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about Resource view in Syncfusion Blazor Gantt Chart component and more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Resource view in Blazor Gantt Chart Component

To visualize tasks assigned to each resource in a hierarchical manner, you can set the [ViewType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ViewType) property to `ResourceView` during initialization of the Gantt Chart. This view represents resources as parent records and their corresponding tasks as child records.

## Unassigned task

Unassigned tasks in the Gantt Chart refer to tasks that have not been assigned to any particular resource. These tasks are categorized under the label `Unassigned Task` and appear at the bottom of the Gantt Chart's data collection. The Gantt Chart's default behavior is to validate unassigned tasks during record creation, based on the task's [Resources](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttResourceFields-1.html#Syncfusion_Blazor_Gantt_GanttResourceFields_1_Resources) mapping property in the data source. If a resource is subsequently assigned to an unassigned task, the task will be repositioned as a child task under the assigned resource.

## Resource task
A task assigned to a resource is termed a resource task and is displayed as a child task under the corresponding resource in the Gantt chart.

N> There is not support for Indent/Oudent in resource view Gantt Chart.

```cshtml
@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="800px" AllowRowDragAndDrop="true"
            Toolbar="@(new List<Object>() { "Add", "Cancel", "Update" , "Delete", "Edit", "CollapseAll", "ExpandAll" })" ViewType="ViewType.ResourceView">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
                        ParentID="ParentId" Work="Work" ResourceInfo="Resources" Dependency="Predecessor">
    </GanttTaskFields>
    <GanttResourceFields Group="ResourceGroup" Resources="@ResourceCollection" Id="ResourceId" Name="ResourceName" Unit="Unit" TResources="ResourceAlloacteData"></GanttResourceFields>
    <GanttLabelSettings RightLabel="Resources" TaskLabel="Progress" TValue="TaskData"></GanttLabelSettings>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true"></GanttEditSettings>
</SfGantt>
@code {
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
        public string? ResourceGroup { get; set; }
    }
    public static List<ResourceAlloacteData> GetResources = new List<ResourceAlloacteData>()
    {
        new ResourceAlloacteData() { ResourceId= 1, ResourceName= "Martin Tamer", ResourceGroup="Planning Team"},
        new ResourceAlloacteData() { ResourceId= 2, ResourceName= "Rose Fuller", ResourceGroup="Testing Team" },
        new ResourceAlloacteData() { ResourceId= 3, ResourceName= "Margaret Buchanan", ResourceGroup="Approval Team" },
        new ResourceAlloacteData() { ResourceId= 4, ResourceName= "Fuller King", ResourceGroup="Development Team" },
        new ResourceAlloacteData() { ResourceId= 5, ResourceName= "Davolio Fuller", ResourceGroup="Approval Team" },
    };
    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
        public string Predecessor { get; set; }
        public string Notes { get; set; }
        public double? Work { get; set; }
        public string TaskType { get; set; }
        public List<ResourceAlloacteData> Resources { get; set; }
    }
    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 03, 28), EndDate = new DateTime(2022, 07, 28), TaskType ="FixedDuration", Work=128, Duration="4" },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 03, 29), Progress = 30, ParentId = 1, Duration="5", Work=16, Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=1, Unit=70} } },
            new TaskData() { TaskId = 3, TaskName = "Site Analyze", StartDate = new DateTime(2022, 03, 29), Progress = 50, ParentId = 1, Duration="5", Work=16, Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=1, Unit=70} } },
            new TaskData() { TaskId = 4, TaskName = "Perform soil test", StartDate = new DateTime(2022, 03, 29), Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=3} }, ParentId = 1, Work=96, Duration="6", TaskType="FixedWork", Predecessor="2FS", Progress=40 },
            new TaskData() { TaskId = 5, TaskName = "Soil test approval", StartDate = new DateTime(2022, 03, 29), Duration="4", Progress = 30, ParentId = 1, Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=4} }, Work=16, TaskType="FixedWork" },
            new TaskData() { TaskId = 6, TaskName = "Project estimation", StartDate = new DateTime(2022, 03, 29), EndDate = new DateTime(2022, 04, 2), TaskType="FixedDuration", Duration="7", Progress=40, Work=50 },
            new TaskData() { TaskId = 7, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 03, 29), Duration = "9", Progress = 30, ParentId = 5, Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=4, Unit=30} }, Work=30, TaskType="FixedDuration",  Predecessor= "4FS" },
            new TaskData() { TaskId = 8, TaskName = "List materials", StartDate = new DateTime(2022, 04, 01), Duration = "6", Progress = 30, ParentId = 5, TaskType="FixedWork", Work=48, Resources = new List<ResourceAlloacteData>(){new ResourceAlloacteData() { ResourceId=5} },  },
       };
        return Tasks;
    }
}
```

<!-- {% previewsample "https://blazorplayground.syncfusion.com/embed/LjhgjQMvzyAZTxLH?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %} -->

## Resource OverAllocation

When a resource is assigned more work than they can complete within their available time in a day, it is referred to as overallocation. The available working time for resources to complete tasks in a day is calculated based on the [GanttDayWorkingTime](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttDayWorkingTimeCollection.html#Syncfusion_Blazor_Gantt_GanttDayWorkingTimeCollection_DayWorkingTime) property and the resource unit.

To highlight the range of overallocation dates with a square bracket, you can enable this feature by setting the [ShowOverallocation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ShowOverallocation) property to `true`.

```cshtml

@using Syncfusion.Blazor.Gantt

<SfGantt ShowOverallocation="true" DataSource="@TaskCollection" Height="450px" Width="800px" AllowRowDragAndDrop="true"
            Toolbar="@(new List<Object>() { "Add", "Cancel", "Update" , "Delete", "Edit", "CollapseAll", "ExpandAll" })" ViewType="ViewType.ResourceView">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
                        ParentID="ParentId" Work="Work" ResourceInfo="Resources" Dependency="Predecessor">
    </GanttTaskFields>
    <GanttResourceFields Group="ResourceGroup" Resources="@ResourceCollection" Id="ResourceId" Name="ResourceName" Unit="Unit" TResources="ResourceAlloacteData"></GanttResourceFields>
    <GanttLabelSettings RightLabel="Resources" TaskLabel="Progress" TValue="TaskData"></GanttLabelSettings>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true"></GanttEditSettings>
</SfGantt>

@code {
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
        public string? ResourceGroup { get; set; }
    }
    public static List<ResourceAlloacteData> GetResources = new List<ResourceAlloacteData>()
    {
        new ResourceAlloacteData() { ResourceId= 1, ResourceName= "Martin Tamer", ResourceGroup="Planning Team"},
        new ResourceAlloacteData() { ResourceId= 2, ResourceName= "Rose Fuller", ResourceGroup="Testing Team" },
        new ResourceAlloacteData() { ResourceId= 3, ResourceName= "Margaret Buchanan", ResourceGroup="Approval Team" },
        new ResourceAlloacteData() { ResourceId= 4, ResourceName= "Fuller King", ResourceGroup="Development Team" },
        new ResourceAlloacteData() { ResourceId= 5, ResourceName= "Davolio Fuller", ResourceGroup="Approval Team" },
    };
    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
        public string Predecessor { get; set; }
        public string Notes { get; set; }
        public double? Work { get; set; }
        public string TaskType { get; set; }
        public List<ResourceAlloacteData> Resources { get; set; }
    }
    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 03, 28), EndDate = new DateTime(2022, 07, 28), TaskType ="FixedDuration", Work=128, Duration="4" },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 03, 29), Progress = 30, ParentId = 1, Duration="5", Work=16, Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=1, Unit=70} } },
            new TaskData() { TaskId = 3, TaskName = "Site Analyze", StartDate = new DateTime(2022, 03, 29), Progress = 50, ParentId = 1, Duration="5", Work=16, Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=1, Unit=70} } },
            new TaskData() { TaskId = 4, TaskName = "Perform soil test", StartDate = new DateTime(2022, 03, 29), Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=3} }, ParentId = 1, Work=96, Duration="6", TaskType="FixedWork", Predecessor="2FS", Progress=40 },
            new TaskData() { TaskId = 5, TaskName = "Soil test approval", StartDate = new DateTime(2022, 03, 29), Duration="4", Progress = 30, ParentId = 1, Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=4} }, Work=16, TaskType="FixedWork" },
            new TaskData() { TaskId = 6, TaskName = "Project estimation", StartDate = new DateTime(2022, 03, 29), EndDate = new DateTime(2022, 04, 2), TaskType="FixedDuration", Duration="7", Progress=40, Work=50 },
            new TaskData() { TaskId = 7, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 03, 29), Duration = "9", Progress = 30, ParentId = 5, Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=4, Unit=30} }, Work=30, TaskType="FixedDuration",  Predecessor= "4FS" },
            new TaskData() { TaskId = 8, TaskName = "List materials", StartDate = new DateTime(2022, 04, 01), Duration = "6", Progress = 30, ParentId = 5, TaskType="FixedWork", Work=48, Resources = new List<ResourceAlloacteData>(){new ResourceAlloacteData() { ResourceId=5} },  },
       };
        return Tasks;
    }
}

```

<!-- {% previewsample "https://blazorplayground.syncfusion.com/embed/rXVqNQsPpofLwCPA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %} -->

## Resource Multi Taskbar

To visualize multiple tasks assigned to each resource in a row when the records are in the collapsed state. It can be enabled by setting the [EnableMultiTaskbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTaskbarSettings.html#Syncfusion_Blazor_Gantt_GanttTaskbarSettings_EnableMultiTaskbar) property of [GanttTaskbarSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTaskbarSettings) to `true`.

When a resource has multiple tasks scheduled on the same date, then the tasks will be overlapped one another. Taskbar editing is also possible to change the task scheduling on the collapsed state.

```cshtml

@using Syncfusion.Blazor.Gantt

<SfGantt @ref="Gantt" ShowOverallocation="true" TreeColumnIndex="1" RowHeight="38"  DataSource="@TaskCollection" Height="450px" Width="100%" ViewType="ViewType.ResourceView" CollapseAllParentTasks=true
                     Toolbar="@(new List<Object>() { "Add", "Cancel", "Update" , "Delete", "Edit", "CollapseAll", "ExpandAll" })" AllowResizing="true">
                <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId" Work="Work" ResourceInfo="Resources" Dependency="Predecessor" >
                </GanttTaskFields>
                <GanttColumns>
                    <GanttColumn Field="TaskId" Visible=false></GanttColumn>
                    <GanttColumn Field="ResourceId" Visible=false></GanttColumn>
                    <GanttColumn Field="TaskName" HeaderText="Name" Width="250"></GanttColumn>
                    <GanttColumn Field="ResourceName" HeaderText="Name" Width="250"></GanttColumn>
                    <GanttColumn Field="Work" HeaderText="Work"></GanttColumn>
                    <GanttColumn Field="Progress"></GanttColumn>
                    <GanttColumn Field="StartDate" HeaderText="Start Date"></GanttColumn>
                    <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
                </GanttColumns>
                <GanttResourceFields Group="ResourceGroup" Resources="@ResourceCollection" Id="ResourceId" Name="ResourceName" Unit="Unit" TResources="ResourceAlloacteData"></GanttResourceFields>
                <GanttLabelSettings TaskLabel="TaskName" TValue="TaskData"></GanttLabelSettings>
                <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true"></GanttEditSettings>
                <GanttTaskbarSettings EnableMultiTaskbar="true"></GanttTaskbarSettings>
                <GanttSplitterSettings  Position="30%"></GanttSplitterSettings>
            </SfGantt>

@code {
    public SfGantt<TaskData> Gantt;
    private DateTime ProjectStart = new DateTime(2022, 03, 25);
    private DateTime ProjectEnd = new DateTime(2022, 05, 10);
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
        public string? ResourceGroup { get; set; }
    }
    public static List<ResourceAlloacteData> GetResources = new List<ResourceAlloacteData>()
    {
        new ResourceAlloacteData() { ResourceId= 1, ResourceName= "Martin Tamer", ResourceGroup="Planning Team", },
        new ResourceAlloacteData() { ResourceId= 3, ResourceName= "Margaret Buchanan", ResourceGroup="Approval Team", },
        new ResourceAlloacteData() { ResourceId= 4, ResourceName= "Fuller King", ResourceGroup="Development Team",  },
        new ResourceAlloacteData() { ResourceId= 5, ResourceName= "Davolio Fuller", ResourceGroup="Approval Team", },
        new ResourceAlloacteData() { ResourceId= 6, ResourceName= "Fuller Buchanan", ResourceGroup="Development Team" },
        new ResourceAlloacteData() { ResourceId= 7, ResourceName= "Jack Davolio", ResourceGroup="Planning Team" },
        new ResourceAlloacteData() { ResourceId= 8, ResourceName= "Tamer Vinet", ResourceGroup="Testing Team" },
        new ResourceAlloacteData() { ResourceId= 9, ResourceName= "Vinet Fuller", ResourceGroup="Development Team" },
        new ResourceAlloacteData() { ResourceId= 10, ResourceName= "Bergs Anton", ResourceGroup="Testing Team" },
    };
    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
        public string Predecessor { get; set; }
        public string Notes { get; set; }
        public double? Work { get; set; }
        public string TaskType { get; set; }
        public List<ResourceAlloacteData> Resources { get; set; }
    }
    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() {
                new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2019, 03, 29), EndDate = new DateTime(2019, 04, 21),TaskType ="FixedDuration", Work=128, Duration="4" },

                new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2019, 03, 29), Progress = 30,ParentId = 1, Duration="3", Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=1, Unit=70,} } },

                new TaskData() { TaskId = 3, TaskName = "Perform soil test",StartDate = new DateTime(2019, 04, 03), Progress = 50, ParentId = 1, Duration="5",Work=16, Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=1, Unit=70, } },Predecessor="2" },

                new TaskData() { TaskId = 4,TaskName = "Soil test approval",StartDate = new DateTime(2019, 04, 09), Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=1, } },ParentId = 1,Work=96,Duration="3",TaskType="FixedWork", Predecessor="3", Progress=40 },

                new TaskData() { TaskId = 5, TaskName = "Project estimation",StartDate = new DateTime(2019, 03, 29),EndDate = new DateTime(2019,04,21), Progress = 30, Work=16,TaskType="FixedWork" },

                new TaskData() { TaskId = 6,TaskName = "Develop floor plan for estimation",StartDate = new DateTime(2019, 04, 01),TaskType="FixedDuration",Duration="5",Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=2,} },Progress=40,Work=50 },

                new TaskData() { TaskId = 7,TaskName = "List materials",StartDate = new DateTime(2019, 04, 04),Duration = "4",Progress = 30,ParentId = 5, Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=2, Unit=30} },Work=30, TaskType="FixedDuration",Predecessor= "6FS-2" },

                new TaskData() { TaskId = 8, TaskName = "Estimation approval",StartDate = new DateTime(2019, 04, 09), Duration = "4",Progress = 30, ParentId = 5, TaskType="FixedWork", Work=48, Resources = new List<ResourceAlloacteData>(){new ResourceAlloacteData() { ResourceId=2} },Predecessor = "7FS-1" },

                new TaskData() { TaskId = 9, TaskName = "Site work",Progress=30, StartDate = new DateTime(2019, 04, 04), EndDate = new DateTime(2019,04,21),Work=60, TaskType="FixedUnit" },

                new TaskData() { TaskId = 10, TaskName = "Install temporary power service",StartDate = new DateTime(2019, 04, 01),Duration = "14",ParentId = 9, Work=60,Progress=50, TaskType="FixedWork",Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=3, Unit=70} } },

                new TaskData() { TaskId = 11, TaskName = "Clear the building site",StartDate = new DateTime(2019, 04, 08),Duration = "9",ParentId = 9,Work=60,Progress=40,Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=3} },TaskType="FixedDuration",Predecessor = "10FS-9" },

                new TaskData() { TaskId = 12, TaskName = "Sign contract",StartDate = new DateTime(2019, 04, 12), Duration = "5",  ParentId = 9, Work=60,Progress=40, TaskType="FixedDuration",Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=3} },Predecessor = "11FS-5" },

                new TaskData() { TaskId = 13,TaskName = "Foundation",StartDate = new DateTime(2022, 04, 04),EndDate = new DateTime(2019,04,28),Work=60,Progress=40,TaskType="FixedDuration" },
                
                new TaskData() { TaskId = 14, TaskName = "Excavate for foundations", StartDate = new DateTime(2019, 04, 01),Duration = "2", ParentId = 13, Work=60,Progress=40, TaskType="FixedDuration",Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=4,} } },

                new TaskData() { TaskId = 15, TaskName = "Dig footer",StartDate = new DateTime(2019, 04, 04), Duration = "2", ParentId = 13, Work=60,Progress=40, TaskType="FixedDuration",Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=4} },Predecessor = "14FS + 1" },

                new TaskData() { TaskId = 16, TaskName = "Install plumbing grounds",StartDate = new DateTime(2019, 04, 08), Duration = "2", ParentId = 13, Work=60,Progress=40,TaskType="FixedDuration",Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=4} },Predecessor = "15FS" },

                new TaskData() { TaskId = 17,TaskName = "Framing",StartDate = new DateTime(2019, 04, 04), EndDate = new DateTime(2019,04,28),Work=60,Progress=40,TaskType="FixedDuration" },

                new TaskData() { TaskId = 18, TaskName = "Add load-bearing structure", StartDate = new DateTime(2019, 04, 03), Duration = "2",ParentId = 17,Work=60,Progress=20,TaskType="FixedDuration",Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=5} } },

                new TaskData() { TaskId = 19, TaskName = "Natural gas utilities",StartDate = new DateTime(2019, 04, 08),Duration = "5", ParentId = 17, Work=60, Progress=40, TaskType="FixedDuration",Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=5} },Predecessor = "18" },

                new TaskData() { TaskId = 20, TaskName = "Electrical utilities", StartDate = new DateTime(2022, 04, 01),Duration = "4",ParentId = 17,Work=60,Progress=50,TaskType="FixedWork",Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=5} },Predecessor = "19FS + 1" },

                new TaskData() { TaskId = 21, TaskName = "Plumbing test", StartDate = new DateTime(2019, 04, 04), Duration = "4", Work=60, Progress=50, TaskType="FixedWork",Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=6} } },

                new TaskData() { TaskId = 22, TaskName = "Electrical test",StartDate = new DateTime(2019, 04, 04),Duration = "4", Work=60, Progress=50, TaskType="FixedWork", Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=6} },Predecessor = "21" },

                new TaskData() { TaskId = 23,TaskName = "First floor initiation",StartDate = new DateTime(2019, 04, 06),Duration = "4",Work=60,Progress=50,TaskType="FixedWork",Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=7} } },

                new TaskData() { TaskId = 24, TaskName = "Interior work",StartDate = new DateTime(2019, 04, 04),  Duration = "4",Work=60, Progress=50,TaskType="FixedWork", Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=7} },Predecessor="23" },

                new TaskData() { TaskId = 25, TaskName = "First floor tile work initiation",StartDate = new DateTime(2019, 04, 10), Duration = "4", Work=60, Progress=50, TaskType="FixedWork", Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=8} } },

                new TaskData() { TaskId = 26,TaskName = "Tile test",StartDate = new DateTime(2019, 04, 04),Duration = "4",Work=60,Progress=50,TaskType="FixedWork", Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=8} } },

                new TaskData() { TaskId = 27,TaskName = "Second floor initiation",StartDate = new DateTime(2019, 04, 10), Duration = "4",Work=60,Progress=50, TaskType="FixedWork", Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=9} } },

                new TaskData() { TaskId = 28, TaskName = "Second floor tile work initiation",StartDate = new DateTime(2019, 04, 06), Duration = "4", Work=60, Progress=50,TaskType="FixedWork", Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=9} },Predecessor="27FS - 1"},

                new TaskData() { TaskId = 29,TaskName = "Exterior work initiation",StartDate = new DateTime(2019, 04, 12),Duration = "4",Work=60,Progress=50,TaskType="FixedWork",Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=10} }},

                new TaskData() { TaskId = 30,TaskName = "Building test",StartDate = new DateTime(2019, 04, 08),Duration = "4",Work=60, Progress=50,TaskType="FixedWork"},
            };
        return Tasks;
    }
}

```

<!-- {% previewsample "https://blazorplayground.syncfusion.com/embed/htrgNbsvgLcAiQsa?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5" %} -->

### Enable taskbar drag and drop

In Gantt, you can enable taskbar drag and drop between resources by using the [AllowTaskbarDragAndDrop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTaskbarSettings.html#Syncfusion_Blazor_Gantt_GanttTaskbarSettings_AllowTaskbarDragAndDrop) property of [GanttTaskbarSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTaskbarSettings) to `true`. This allows you to move a taskbar from one resource to another vertically, making it easier to schedule tasks and manage resources.

```cshtml

@using Syncfusion.Blazor.Gantt

<SfGantt @ref="Gantt" ShowOverallocation="true" TreeColumnIndex="1" RowHeight="38"  DataSource="@TaskCollection" Height="450px" Width="100%" ViewType="ViewType.ResourceView" CollapseAllParentTasks=true
                     Toolbar="@(new List<Object>() { "Add", "Cancel", "Update" , "Delete", "Edit", "CollapseAll", "ExpandAll" })" AllowResizing="true">
                <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId" Work="Work" ResourceInfo="Resources" Dependency="Predecessor" >
                </GanttTaskFields>
                <GanttColumns>
                    <GanttColumn Field="TaskId" Visible=false></GanttColumn>
                    <GanttColumn Field="ResourceId" Visible=false></GanttColumn>
                    <GanttColumn Field="TaskName" HeaderText="Name" Width="250"></GanttColumn>
                    <GanttColumn Field="ResourceName" HeaderText="Name" Width="250"></GanttColumn>
                    <GanttColumn Field="Work" HeaderText="Work"></GanttColumn>
                    <GanttColumn Field="Progress"></GanttColumn>
                    <GanttColumn Field="StartDate" HeaderText="Start Date"></GanttColumn>
                    <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
                </GanttColumns>
                <GanttResourceFields Group="ResourceGroup" Resources="@ResourceCollection" Id="ResourceId" Name="ResourceName" Unit="Unit" TResources="ResourceAlloacteData"></GanttResourceFields>
                <GanttLabelSettings TaskLabel="TaskName" TValue="TaskData"></GanttLabelSettings>
                <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true"></GanttEditSettings>
                <GanttTaskbarSettings EnableMultiTaskbar="true" AllowTaskbarDragAndDrop="true"></GanttTaskbarSettings>
                <GanttSplitterSettings  Position="30%"></GanttSplitterSettings>
            </SfGantt>

@code {
    public SfGantt<TaskData> Gantt;
    private DateTime ProjectStart = new DateTime(2022, 03, 25);
    private DateTime ProjectEnd = new DateTime(2022, 05, 10);
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
        public string? ResourceGroup { get; set; }
    }
    public static List<ResourceAlloacteData> GetResources = new List<ResourceAlloacteData>()
    {
        new ResourceAlloacteData() { ResourceId= 1, ResourceName= "Martin Tamer", ResourceGroup="Planning Team", },
        new ResourceAlloacteData() { ResourceId= 3, ResourceName= "Margaret Buchanan", ResourceGroup="Approval Team", },
        new ResourceAlloacteData() { ResourceId= 4, ResourceName= "Fuller King", ResourceGroup="Development Team",  },
        new ResourceAlloacteData() { ResourceId= 5, ResourceName= "Davolio Fuller", ResourceGroup="Approval Team", },
        new ResourceAlloacteData() { ResourceId= 6, ResourceName= "Fuller Buchanan", ResourceGroup="Development Team" },
        new ResourceAlloacteData() { ResourceId= 7, ResourceName= "Jack Davolio", ResourceGroup="Planning Team" },
        new ResourceAlloacteData() { ResourceId= 8, ResourceName= "Tamer Vinet", ResourceGroup="Testing Team" },
        new ResourceAlloacteData() { ResourceId= 9, ResourceName= "Vinet Fuller", ResourceGroup="Development Team" },
        new ResourceAlloacteData() { ResourceId= 10, ResourceName= "Bergs Anton", ResourceGroup="Testing Team" },
    };
    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
        public string Predecessor { get; set; }
        public string Notes { get; set; }
        public double? Work { get; set; }
        public string TaskType { get; set; }
        public List<ResourceAlloacteData> Resources { get; set; }
    }
    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() {
                new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2019, 03, 29), EndDate = new DateTime(2019, 04, 21),TaskType ="FixedDuration", Work=128, Duration="4" },

                new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2019, 03, 29), Progress = 30,ParentId = 1, Duration="3", Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=1, Unit=70,} } },

                new TaskData() { TaskId = 3, TaskName = "Perform soil test",StartDate = new DateTime(2019, 04, 03), Progress = 50, ParentId = 1, Duration="5",Work=16, Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=1, Unit=70, } },Predecessor="2" },

                new TaskData() { TaskId = 4,TaskName = "Soil test approval",StartDate = new DateTime(2019, 04, 09), Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=1, } },ParentId = 1,Work=96,Duration="3",TaskType="FixedWork", Predecessor="3", Progress=40 },

                new TaskData() { TaskId = 5, TaskName = "Project estimation",StartDate = new DateTime(2019, 03, 29),EndDate = new DateTime(2019,04,21), Progress = 30, Work=16,TaskType="FixedWork" },

                new TaskData() { TaskId = 6,TaskName = "Develop floor plan for estimation",StartDate = new DateTime(2019, 04, 01),TaskType="FixedDuration",Duration="5",Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=2,} },Progress=40,Work=50 },

                new TaskData() { TaskId = 7,TaskName = "List materials",StartDate = new DateTime(2019, 04, 04),Duration = "4",Progress = 30,ParentId = 5, Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=2, Unit=30} },Work=30, TaskType="FixedDuration",Predecessor= "6FS-2" },

                new TaskData() { TaskId = 8, TaskName = "Estimation approval",StartDate = new DateTime(2019, 04, 09), Duration = "4",Progress = 30, ParentId = 5, TaskType="FixedWork", Work=48, Resources = new List<ResourceAlloacteData>(){new ResourceAlloacteData() { ResourceId=2} },Predecessor = "7FS-1" },

                new TaskData() { TaskId = 9, TaskName = "Site work",Progress=30, StartDate = new DateTime(2019, 04, 04), EndDate = new DateTime(2019,04,21),Work=60, TaskType="FixedUnit" },

                new TaskData() { TaskId = 10, TaskName = "Install temporary power service",StartDate = new DateTime(2019, 04, 01),Duration = "14",ParentId = 9, Work=60,Progress=50, TaskType="FixedWork",Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=3, Unit=70} } },

                new TaskData() { TaskId = 11, TaskName = "Clear the building site",StartDate = new DateTime(2019, 04, 08),Duration = "9",ParentId = 9,Work=60,Progress=40,Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=3} },TaskType="FixedDuration",Predecessor = "10FS-9" },

                new TaskData() { TaskId = 12, TaskName = "Sign contract",StartDate = new DateTime(2019, 04, 12), Duration = "5",  ParentId = 9, Work=60,Progress=40, TaskType="FixedDuration",Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=3} },Predecessor = "11FS-5" },

                new TaskData() { TaskId = 13,TaskName = "Foundation",StartDate = new DateTime(2022, 04, 04),EndDate = new DateTime(2019,04,28),Work=60,Progress=40,TaskType="FixedDuration" },
                
                new TaskData() { TaskId = 14, TaskName = "Excavate for foundations", StartDate = new DateTime(2019, 04, 01),Duration = "2", ParentId = 13, Work=60,Progress=40, TaskType="FixedDuration",Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=4,} } },

                new TaskData() { TaskId = 15, TaskName = "Dig footer",StartDate = new DateTime(2019, 04, 04), Duration = "2", ParentId = 13, Work=60,Progress=40, TaskType="FixedDuration",Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=4} },Predecessor = "14FS + 1" },

                new TaskData() { TaskId = 16, TaskName = "Install plumbing grounds",StartDate = new DateTime(2019, 04, 08), Duration = "2", ParentId = 13, Work=60,Progress=40,TaskType="FixedDuration",Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=4} },Predecessor = "15FS" },

                new TaskData() { TaskId = 17,TaskName = "Framing",StartDate = new DateTime(2019, 04, 04), EndDate = new DateTime(2019,04,28),Work=60,Progress=40,TaskType="FixedDuration" },

                new TaskData() { TaskId = 18, TaskName = "Add load-bearing structure", StartDate = new DateTime(2019, 04, 03), Duration = "2",ParentId = 17,Work=60,Progress=20,TaskType="FixedDuration",Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=5} } },

                new TaskData() { TaskId = 19, TaskName = "Natural gas utilities",StartDate = new DateTime(2019, 04, 08),Duration = "5", ParentId = 17, Work=60, Progress=40, TaskType="FixedDuration",Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=5} },Predecessor = "18" },

                new TaskData() { TaskId = 20, TaskName = "Electrical utilities", StartDate = new DateTime(2022, 04, 01),Duration = "4",ParentId = 17,Work=60,Progress=50,TaskType="FixedWork",Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=5} },Predecessor = "19FS + 1" },

                new TaskData() { TaskId = 21, TaskName = "Plumbing test", StartDate = new DateTime(2019, 04, 04), Duration = "4", Work=60, Progress=50, TaskType="FixedWork",Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=6} } },

                new TaskData() { TaskId = 22, TaskName = "Electrical test",StartDate = new DateTime(2019, 04, 04),Duration = "4", Work=60, Progress=50, TaskType="FixedWork", Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=6} },Predecessor = "21" },

                new TaskData() { TaskId = 23,TaskName = "First floor initiation",StartDate = new DateTime(2019, 04, 06),Duration = "4",Work=60,Progress=50,TaskType="FixedWork",Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=7} } },

                new TaskData() { TaskId = 24, TaskName = "Interior work",StartDate = new DateTime(2019, 04, 04),  Duration = "4",Work=60, Progress=50,TaskType="FixedWork", Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=7} },Predecessor="23" },

                new TaskData() { TaskId = 25, TaskName = "First floor tile work initiation",StartDate = new DateTime(2019, 04, 10), Duration = "4", Work=60, Progress=50, TaskType="FixedWork", Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=8} } },

                new TaskData() { TaskId = 26,TaskName = "Tile test",StartDate = new DateTime(2019, 04, 04),Duration = "4",Work=60,Progress=50,TaskType="FixedWork", Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=8} } },

                new TaskData() { TaskId = 27,TaskName = "Second floor initiation",StartDate = new DateTime(2019, 04, 10), Duration = "4",Work=60,Progress=50, TaskType="FixedWork", Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=9} } },

                new TaskData() { TaskId = 28, TaskName = "Second floor tile work initiation",StartDate = new DateTime(2019, 04, 06), Duration = "4", Work=60, Progress=50,TaskType="FixedWork", Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=9} },Predecessor="27FS - 1"},

                new TaskData() { TaskId = 29,TaskName = "Exterior work initiation",StartDate = new DateTime(2019, 04, 12),Duration = "4",Work=60,Progress=50,TaskType="FixedWork",Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=10} }},

                new TaskData() { TaskId = 30,TaskName = "Building test",StartDate = new DateTime(2019, 04, 08),Duration = "4",Work=60, Progress=50,TaskType="FixedWork"},
            };
        return Tasks;
    }
}

```

<!-- {% previewsample "https://blazorplayground.syncfusion.com/embed/LjBKDvWFArPYJpHn?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5" %} -->

## Limitations

* The resource view in the Gantt Chart does not support assigning multiple resources to a single task.
* Editing of resource records is not supported in the resource view of the Gantt Chart.

