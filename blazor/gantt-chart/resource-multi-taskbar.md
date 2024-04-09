---
layout: post
title: Resource Multi Taskbar in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about Resource view in Syncfusion Blazor Gantt Chart component and more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Resource Multi Taskbar in Blazor Gantt Chart Component

Resource Multi-Taskbar in a Gantt Chart is a feature that allows you to visualize multiple tasks assigned to each resource within a row when the records are collapsed. To enable this feature, set the `EnableMultiTaskbar` property within `GanttTaskbarSettings` to `true`.

 Resource Multi-Taskbar not only helps with visualization but also allows you to edit the task scheduling, even in the collapsed state. Hover over the specific taskbar you want to edit. The taskbar you are interacting with will be brought to the forefront, making it clear which task you are working on. You can easily drag it to the desired position on the timeline to adjust the task's start and end dates and also change the duration of the task by resizing the taskbar. Resource Multi-Taskbar also supports [overallocation](https://blazor.syncfusion.com/documentation/gantt-chart/resource-view#resource-overallocation).

```cshtml

@using Syncfusion.Blazor.Gantt

<SfGantt @ref="ganttInstance" ShowOverallocation="true" TreeColumnIndex="1" RowHeight="38" DataSource="@taskCollection" Height="450px" Width="850px" ViewType="ViewType.ResourceView" CollapseAllParentTasks=true
         Toolbar="@(new List<Object>() { "Add", "Cancel", "Update" , "Delete", "Edit", "CollapseAll", "ExpandAll" })" AllowResizing="true">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
                     ParentID="ParentId" Work="Work" ResourceInfo="Resources" Dependency="Predecessor">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskId" Visible=false></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Name" Width="250"></GanttColumn>
        <GanttColumn Field="Work" HeaderText="Work"></GanttColumn>
        <GanttColumn Field="Progress"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date"></GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
    </GanttColumns>
    <GanttResourceFields Group="ResourceGroup" Resources="@resourceCollection" Id="ResourceId" Name="ResourceName" Unit="Unit" TResources="ResourceAlloacteData"></GanttResourceFields>
    <GanttLabelSettings TaskLabel="TaskName" TValue="TaskData"></GanttLabelSettings>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true"></GanttEditSettings>
    <GanttTaskbarSettings EnableMultiTaskbar="true" AllowTaskbarDragAndDrop="true"></GanttTaskbarSettings>
    <GanttSplitterSettings Position="30%"></GanttSplitterSettings>
</SfGantt>

@code {
    private SfGantt<TaskData> ganttInstance;
    private DateTime projectStart = new DateTime(2022, 03, 25);
    private DateTime ProjectEnd = new DateTime(2022, 05, 10);
    private List<TaskData> taskCollection { get; set; }
    private List<ResourceAlloacteData> resourceCollection { get; set; }
    protected override void OnInitialized()
    {
        this.taskCollection = GetTaskCollection();
        this.resourceCollection = GetResources;
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
                new TaskData() {
                    TaskId = 1,
                    TaskName = "Project initiation",
                    StartDate = new DateTime(2019, 03, 29),
                    EndDate = new DateTime(2019, 04, 21),
                    TaskType ="FixedDuration",
                    Work=128,
                    Duration="4",
                },
                new TaskData() {
                    TaskId = 2,
                    TaskName = "Identify Site location",
                    StartDate = new DateTime(2019, 03, 29),
                    Progress = 30,
                    ParentId = 1,
                    Duration="3",
                    Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=1, Unit=70,} },
                },
                new TaskData() {
                    TaskId = 3,
                    TaskName = "Perform soil test",
                    StartDate = new DateTime(2019, 04, 03),
                    Progress = 50,
                    ParentId = 1,
                    Duration="5",
                    Work=16,
                    Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=1, Unit=70, } },
                    Predecessor="2",
                },
                new TaskData() {
                    TaskId = 4,
                    TaskName = "Soil test approval",
                    StartDate = new DateTime(2019, 04, 09),
                    Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=1, } },
                    ParentId = 1,
                    Work=96,
                    Duration="3",
                    TaskType="FixedWork",
                    Predecessor="3",
                    Progress=40,
                },
                new TaskData() {
                    TaskId = 5,
                    TaskName = "Project estimation",
                    StartDate = new DateTime(2019, 03, 29),
                    EndDate = new DateTime(2019,04,21),
                    Progress = 30,
                    Work=16,
                    TaskType="FixedWork",
                },
                new TaskData() {
                    TaskId = 6,
                    TaskName = "Develop floor plan for estimation",
                    StartDate = new DateTime(2019, 04, 01),
                    TaskType="FixedDuration",
                    Duration="5",
                    Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=2,} },
                    Progress=40,
                    Work=50,
                },
                new TaskData() {
                    TaskId = 7,
                    TaskName = "List materials",
                    StartDate = new DateTime(2019, 04, 04),
                    Duration = "4",
                    Progress = 30,
                    ParentId = 5,
                    Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=2, Unit=30} },
                    Work=30,
                    TaskType="FixedDuration",
                    Predecessor= "6FS-2",
                },
                new TaskData() {
                    TaskId = 8,
                    TaskName = "Estimation approval",
                    StartDate = new DateTime(2019, 04, 09),
                    Duration = "4",
                    Progress = 30,
                    ParentId = 5,
                    TaskType="FixedWork",
                    Work=48,
                    Resources = new List<ResourceAlloacteData>(){new ResourceAlloacteData() { ResourceId=2} },
                    Predecessor = "7FS-1",
                },
                new TaskData() {
                    TaskId = 9,
                    TaskName = "Site work",
                    Progress=30,
                    StartDate = new DateTime(2019, 04, 04),
                    EndDate = new DateTime(2019,04,21),
                    Work=60,
                    TaskType="FixedUnit",
                },
                new TaskData() {
                    TaskId = 10,
                    TaskName = "Install temporary power service",
                    StartDate = new DateTime(2019, 04, 01),
                    Duration = "14",
                    ParentId = 9,
                    Work=60,
                    Progress=50,
                    TaskType="FixedWork",
                    Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=3, Unit=70} },
                },
                new TaskData() {
                    TaskId = 11,
                    TaskName = "Clear the building site",
                    StartDate = new DateTime(2019, 04, 08),
                    Duration = "9",
                    ParentId = 9,
                    Work=60,
                    Progress=40,
                    Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=3} },
                    TaskType="FixedDuration",
                    Predecessor = "10FS-9",
                },
                new TaskData() {
                    TaskId = 12,
                    TaskName = "Sign contract",
                    StartDate = new DateTime(2019, 04, 12),
                    Duration = "5",
                    ParentId = 9,
                    Work=60,Progress=40,
                    TaskType="FixedDuration",
                    Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=3} },
                    Predecessor = "11FS-5",
                },
                new TaskData() {
                    TaskId = 13,
                    TaskName = "Foundation",
                    StartDate = new DateTime(2022, 04, 04),
                    EndDate = new DateTime(2019,04,28),
                    Work=60,
                    Progress=40,
                    TaskType="FixedDuration",
                },
                new TaskData() {
                    TaskId = 14,
                    TaskName = "Excavate for foundations",
                    StartDate = new DateTime(2019, 04, 01),
                    Duration = "2",
                    ParentId = 13,
                    Work=60,
                    Progress=40,
                    TaskType="FixedDuration",
                    Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=4,} },
                },
                new TaskData() {
                    TaskId = 15,
                    TaskName = "Dig footer",
                    StartDate = new DateTime(2019, 04, 04),
                    Duration = "2",
                    ParentId = 13,
                    Work=60,
                    Progress=40,
                    TaskType="FixedDuration",
                    Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=4} },
                    Predecessor = "14FS + 1",
                },
                new TaskData() {
                    TaskId = 16,
                    TaskName = "Install plumbing grounds",
                    StartDate = new DateTime(2019, 04, 08),
                    Duration = "2",
                    ParentId = 13,
                    Work=60,
                    Progress=40,
                    TaskType="FixedDuration",
                    Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=4} },
                    Predecessor = "15FS"
                },
                new TaskData() {
                    TaskId = 17,
                    TaskName = "Framing",
                    StartDate = new DateTime(2019, 04, 04),
                    EndDate = new DateTime(2019,04,28),
                    Work=60,
                    Progress=40,
                    TaskType="FixedDuration",
                },
                new TaskData() {
                    TaskId = 18,
                    TaskName = "Add load-bearing structure",
                    StartDate = new DateTime(2019, 04, 03),
                    Duration = "2",
                    ParentId = 17,
                    Work=60,
                    Progress=20,
                    TaskType="FixedDuration",
                    Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=5} },
                },
                new TaskData() {
                    TaskId = 19,
                    TaskName = "Natural gas utilities",
                    StartDate = new DateTime(2019, 04, 08),
                    Duration = "5",
                    ParentId = 17,
                    Work=60,
                    Progress=40,
                    TaskType="FixedDuration",
                    Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=5} },
                    Predecessor = "18",
                },
                new TaskData() {
                    TaskId = 20,
                    TaskName = "Electrical utilities",
                    StartDate = new DateTime(2022, 04, 01),
                    Duration = "4",
                    ParentId = 17,
                    Work=60,
                    Progress=50,
                    TaskType="FixedWork",
                    Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=5} },
                    Predecessor = "19FS + 1",
                },
                new TaskData() {
                    TaskId = 21,
                    TaskName = "Plumbing test",
                    StartDate = new DateTime(2019, 04, 04),
                    Duration = "4",
                    Work=60,
                    Progress=50,
                    TaskType="FixedWork",
                    Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=6} },
                },
                new TaskData() {
                    TaskId = 22,
                    TaskName = "Electrical test",
                    StartDate = new DateTime(2019, 04, 04),
                    Duration = "4",
                    Work=60,
                    Progress=50,
                    TaskType="FixedWork",
                    Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=6} },
                    Predecessor = "21"
                },
                new TaskData() {
                    TaskId = 23,
                    TaskName = "First floor initiation",
                    StartDate = new DateTime(2019, 04, 06),
                    Duration = "4",
                    Work=60,
                    Progress=50,
                    TaskType="FixedWork",
                    Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=7} },
                },
                new TaskData() {
                    TaskId = 24,
                    TaskName = "Interior work",
                    StartDate = new DateTime(2019, 04, 04),
                    Duration = "4",
                    Work=60,
                    Progress=50,
                    TaskType="FixedWork",
                    Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=7} },
                    Predecessor="23"
                },
                new TaskData() {
                    TaskId = 25,
                    TaskName = "First floor tile work initation",
                    StartDate = new DateTime(2019, 04, 10),
                    Duration = "4",
                    Work=60,
                    Progress=50,
                    TaskType="FixedWork",
                    Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=8} },
                },
                new TaskData() {
                    TaskId = 26,
                    TaskName = "Tile test",
                    StartDate = new DateTime(2019, 04, 04),
                    Duration = "4",
                    Work=60,
                    Progress=50,
                    TaskType="FixedWork",
                    Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=8} },
                },
                new TaskData() {
                    TaskId = 27,
                    TaskName = "Second floor initiation",
                    StartDate = new DateTime(2019, 04, 10),
                    Duration = "4",
                    Work=60,
                    Progress=50,
                    TaskType="FixedWork",
                    Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=9} },
                },
                new TaskData() {
                    TaskId = 28,
                    TaskName = "Second floor tile work initation",
                    StartDate = new DateTime(2019, 04, 06),
                    Duration = "4",
                    Work=60,
                    Progress=50,
                    TaskType="FixedWork",
                    Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=9} },
                    Predecessor="27FS - 1"
                },
                new TaskData() {
                    TaskId = 29,
                    TaskName = "Exterior work initation",
                    StartDate = new DateTime(2019, 04, 12),
                    Duration = "4",
                    Work=60,
                    Progress=50,
                    TaskType="FixedWork",
                    Resources = new List<ResourceAlloacteData>(){ new ResourceAlloacteData() { ResourceId=10} },
                },
                new TaskData() {
                    TaskId = 30,
                    TaskName = "Building test",
                    StartDate = new DateTime(2019, 04, 08),
                    Duration = "4",
                    Work=60,
                    Progress=50,
                    TaskType="FixedWork",
                },
            };
        return Tasks;
    }
}

```

![Resource multi-taskbar in Blazor Gantt Chart](images/blazor-gantt-chart-resource-multi-taskbar.png)

<!-- {% previewsample "https://blazorplayground.syncfusion.com/embed/htrgNbsvgLcAiQsa?appbar=true&editor=true&result=true&errorlist=true&theme=bootstrap5" %} -->


