---
layout: post
title: Resources in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about Resources in Syncfusion Blazor Gantt Chart component and much more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Resources in Blazor Gantt Chart Component

In [Blazor Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart), the resources are represented by staff, equipment, materials, and so on. It allows for the allocation of resources, such as human resources, to each task.

## Binding data source for resource collection and assigning resource to tasks

Resources are a list of `TResources` objects, mapped to the Gantt Chart component using the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttResource-1.html#Syncfusion_Blazor_Gantt_GanttResource_1_DataSource) property in [GanttResource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttResource-1.html). To link the resource collection with task collection, the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttAssignmentFields-1.html#Syncfusion_Blazor_Gantt_GanttAssignmentFields_1_DataSource) property of the [GanttAssignmentFields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttAssignmentFields-1.html) component is essential to use. It is crucial to structure this collection thoughtfully to establish a strong foreign key relationship. This involves linking the [TaskId](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttAssignmentFields-1.html#Syncfusion_Blazor_Gantt_GanttAssignmentFields_1_TaskId) and [ResourceId](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttAssignmentFields-1.html#Syncfusion_Blazor_Gantt_GanttAssignmentFields_1_ResourceId) properties of `GanttAssignmentFields` with the [ID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTaskFields.html#Syncfusion_Blazor_Gantt_GanttTaskFields_Id) property value of [GanttTaskFields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTaskFields.html) for tasks and the [Id](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttResource-1.html#Syncfusion_Blazor_Gantt_GanttResource_1_Id) property of `GanttResource` for resources.

Also, the following properties of `GanttResource` component needs to be configured
1. [Name](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttAssignmentFields-1.html#Syncfusion_Blazor_Gantt_GanttAssignmentFields_1_Name) - Maps the resource name
2. [MaxUnits](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttAssignmentFields-1.html#Syncfusion_Blazor_Gantt_GanttAssignmentFields_1_MaxUnits) - resource’s maximum capacity or availability per day.

The following code snippets show resource collection and how it is assigned to the Gantt Chart component. 

{% tabs %}

{% highlight razor %}


@using Syncfusion.Blazor.Gantt
@using BlazorGanttChart.Data

<SfGantt DataSource="@TaskCollection" Height="450px" Width="850px" TreeColumnIndex="1" ProjectStartDate="@ProjectStart" ProjectEndDate="@ProjectEnd" WorkUnit="WorkUnit.Hour"
         Toolbar="@(new List<string>(){ "Add", "Edit", "Update", "Delete", "Cancel", "ExpandAll", "CollapseAll"})">
    <GanttTaskFields Id="@nameof(GanttModel.TaskInfoModel.Id)" Name="@nameof(GanttModel.TaskInfoModel.Name)" StartDate="@nameof(GanttModel.TaskInfoModel.StartDate)" EndDate="@nameof(GanttModel.TaskInfoModel.EndDate)" Duration="@nameof(GanttModel.TaskInfoModel.Duration)" Progress="@nameof(GanttModel.TaskInfoModel.Progress)"
                     ParentID="@nameof(GanttModel.TaskInfoModel.ParentId)" Work="@nameof(GanttModel.TaskInfoModel.Work)" TaskType="@nameof(GanttModel.TaskInfoModel.TaskType)">
    </GanttTaskFields>
    <GanttResource DataSource="ResourceCollection" Id="@nameof(GanttModel.ResourceInfoModel.Id)" Name="@nameof(GanttModel.ResourceInfoModel.Name)" MaxUnits="@nameof(GanttModel.ResourceInfoModel.MaxUnit)" TValue="GanttModel.TaskInfoModel" TResources="GanttModel.ResourceInfoModel"></GanttResource>
    <GanttAssignmentFields DataSource="AssignmentCollection" PrimaryKey="@nameof(GanttModel.AssignmentModel.PrimaryId)" TaskID="@nameof(GanttModel.AssignmentModel.TaskId)" ResourceID="@nameof(GanttModel.AssignmentModel.ResourceId)" Units="@nameof(GanttModel.AssignmentModel.Unit)" TValue="GanttModel.TaskInfoModel" TAssignment="GanttModel.AssignmentModel">
    </GanttAssignmentFields>
    <GanttLabelSettings RightLabel="Resources" TValue="GanttModel.TaskInfoModel"></GanttLabelSettings>
    <GanttEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" AllowTaskbarEditing="true"
                       ShowDeleteConfirmDialog="true"></GanttEditSettings>
    <GanttColumns>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.Id)" HeaderText="ID"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.Name)" HeaderText="Event Name" Width="250px"></GanttColumn>
        <GanttResourceColumn HeaderText="Event Resources" Width="300px"></GanttResourceColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.Work)" HeaderText="Work"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.Duration)" HeaderText="Duration"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.TaskType)" HeaderText="Task Type"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.StartDate)" HeaderText="Start Date"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.EndDate)" HeaderText="End Date"></GanttColumn>
    </GanttColumns>
    <GanttSplitterSettings Position="28%"> </GanttSplitterSettings>
</SfGantt>

@code {
    private DateTime ProjectStart = new DateTime(2021, 3, 28);
    private DateTime ProjectEnd = new DateTime(2021, 7, 28);
    private List<GanttModel.TaskInfoModel> TaskCollection { get; set; } = new();
    private List<GanttModel.ResourceInfoModel> ResourceCollection { get; set; } = new();
    private static List<GanttModel.AssignmentModel> AssignmentCollection { get; set; } = new();
    protected override void OnInitialized()
    {
        TaskCollection = GanttModel.GetTaskCollection();
        ResourceCollection = GanttModel.GetResources;
        AssignmentCollection = GanttModel.GetAssignmentCollection();
    }
}

{% endhighlight %}

{% highlight c# tabtitle="GanttModel.cs" %}

namespace BlazorGanttChart.Data
{
    public class GanttModel
    {
        public class ResourceInfoModel
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public double MaxUnit { get; set; }
        }

        public class TaskInfoModel
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? TaskType { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string? Duration { get; set; }
            public int Progress { get; set; }
            public int? ParentId { get; set; }
            public double? Work { get; set; }
        }

        public class AssignmentModel
        {
            public int PrimaryId { get; set; }
            public int TaskId { get; set; }
            public int ResourceId { get; set; }
            public double Unit { get; set; }
        }

        public static List<ResourceInfoModel> GetResources = new List<ResourceInfoModel>()
        {
            new ResourceInfoModel() { Id= 1, Name= "Martin Tamer" ,MaxUnit=70},
            new ResourceInfoModel() { Id= 2, Name= "Rose Fuller" },
            new ResourceInfoModel() { Id= 3, Name= "Margaret Buchanan" },
            new ResourceInfoModel() { Id= 4, Name= "Fuller King", MaxUnit = 100},
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
                new AssignmentModel(){ PrimaryId=1, TaskId = 2 , ResourceId=1, Unit=70},
                new AssignmentModel(){ PrimaryId=2, TaskId = 2 , ResourceId=6},
                new AssignmentModel(){ PrimaryId=3, TaskId = 3 , ResourceId=2},
                new AssignmentModel(){ PrimaryId=4, TaskId = 3 , ResourceId=3},
                new AssignmentModel(){ PrimaryId=5, TaskId = 3 , ResourceId=6},
                new AssignmentModel(){ PrimaryId=6, TaskId = 4 , ResourceId=8},
                new AssignmentModel(){ PrimaryId=7, TaskId = 4 , ResourceId=9},
                new AssignmentModel(){ PrimaryId=8, TaskId = 6 , ResourceId=4},
                new AssignmentModel(){ PrimaryId=9, TaskId = 7 , ResourceId=4},
                new AssignmentModel(){ PrimaryId=10, TaskId = 7 , ResourceId=8},
                new AssignmentModel(){ PrimaryId=11, TaskId = 8 , ResourceId=12},
                new AssignmentModel(){ PrimaryId=12, TaskId = 8 , ResourceId=5},
                new AssignmentModel(){ PrimaryId=13, TaskId = 9 , ResourceId=12},
                new AssignmentModel(){ PrimaryId=14, TaskId = 9 , ResourceId=5}
            };
            return assignments;
        }

        public static List<TaskInfoModel> GetTaskCollection()
        {
            return new List<TaskInfoModel>()
            {
                new TaskInfoModel() { Id = 1, Name = "Project initiation", StartDate = new DateTime(2021, 03, 28), EndDate = new DateTime(2021, 07, 28), TaskType ="FixedDuration", Work=128, Duration="4" },
                new TaskInfoModel() { Id = 2, Name = "Identify site location", StartDate = new DateTime(2021, 03, 29), Progress = 30, ParentId = 1, Duration="2", TaskType ="FixedDuration", Work=16 },
                new TaskInfoModel() { Id = 3, Name = "Perform soil test", StartDate = new DateTime(2021, 03, 29), ParentId = 1, Work=96, Duration="4", TaskType="FixedWork" },
                new TaskInfoModel() { Id = 4, Name = "Soil test approval", StartDate = new DateTime(2021, 03, 29), Duration = "1", Progress = 30, ParentId = 1, Work=16, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 5, Name = "Project estimation", StartDate = new DateTime(2021, 03, 29), EndDate = new DateTime(2021, 04, 2), TaskType="FixedDuration", Duration="4" },
                new TaskInfoModel() { Id = 6, Name = "Develop floor plan for estimation", StartDate = new DateTime(2021, 03, 29), Duration = "3", Progress = 30, ParentId = 5, Work=30, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 7, Name = "List materials", StartDate = new DateTime(2021, 04, 01), Duration = "3", Progress = 30, ParentId = 5, TaskType="FixedWork", Work=48 },
                new TaskInfoModel() { Id = 8, Name = "Estimation approval", StartDate = new DateTime(2021, 04, 01), Duration = "2", ParentId = 5, Work=60, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 9, Name = "Sign contract", StartDate = new DateTime(2021, 03, 31), EndDate = new DateTime(2021, 04, 01), Duration="1", TaskType="FixedWork", Work=24 },
            };
        }
    }
}

{% endhighlight %}

{% endtabs %}

![Resource allocation](images/blazor-gantt-chart-resource.png)

## Resource unit

When defining the resource unit within the resource collection, it indicates the amount of work that a specific resource will perform per day for a task. This concept is reflected in both the [Units](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttAssignmentFields-1.html#Syncfusion_Blazor_Gantt_GanttAssignmentFields_1_Units) property in `GanttAssignmentFields` and the [MaxUnits](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttResource-1.html#Syncfusion_Blazor_Gantt_GanttResource_1_MaxUnits) property in `GanttResource`. The `Units` property specifies the work amount done per day by a resource for a task, while `MaxUnits` sets the resource's maximum capacity or availability for any task.

To illustrate this concept, the following code snippet demonstrates how to assign resources to specific tasks and map them in the Gantt chart, providing a clear overview of how resource units and maximum capacities are managed in task allocation. For more detailed information about work and resource units, you can refer to the [link](https://blazor.syncfusion.com/documentation/gantt-chart/work).

{% tabs %}

{% highlight razor %}


@using Syncfusion.Blazor.Gantt
@using BlazorGanttChart.Data

<SfGantt DataSource="@TaskCollection" Height="450px" Width="850px" TreeColumnIndex="1" ProjectStartDate="@ProjectStart" ProjectEndDate="@ProjectEnd" WorkUnit="WorkUnit.Hour"
         Toolbar="@(new List<string>(){ "Add", "Edit", "Update", "Delete", "Cancel", "ExpandAll", "CollapseAll"})">
    <GanttTaskFields Id="@nameof(GanttModel.TaskInfoModel.Id)" Name="@nameof(GanttModel.TaskInfoModel.Name)" StartDate="@nameof(GanttModel.TaskInfoModel.StartDate)" EndDate="@nameof(GanttModel.TaskInfoModel.EndDate)" Duration="@nameof(GanttModel.TaskInfoModel.Duration)" Progress="@nameof(GanttModel.TaskInfoModel.Progress)"
                     ParentID="@nameof(GanttModel.TaskInfoModel.ParentId)" Work="@nameof(GanttModel.TaskInfoModel.Work)" TaskType="@nameof(GanttModel.TaskInfoModel.TaskType)">
    </GanttTaskFields>
    <GanttResource DataSource="ResourceCollection" Id="@nameof(GanttModel.ResourceInfoModel.Id)" Name="@nameof(GanttModel.ResourceInfoModel.Name)" MaxUnits="@nameof(GanttModel.ResourceInfoModel.MaxUnit)" TValue="GanttModel.TaskInfoModel" TResources="GanttModel.ResourceInfoModel"></GanttResource>
    <GanttAssignmentFields DataSource="AssignmentCollection" PrimaryKey="@nameof(GanttModel.AssignmentModel.PrimaryId)" TaskID="@nameof(GanttModel.AssignmentModel.TaskId)" ResourceID="@nameof(GanttModel.AssignmentModel.ResourceId)" Units="@nameof(GanttModel.AssignmentModel.Unit)" TValue="GanttModel.TaskInfoModel" TAssignment="GanttModel.AssignmentModel">
    </GanttAssignmentFields>
    <GanttLabelSettings RightLabel="Resources" TValue="GanttModel.TaskInfoModel"></GanttLabelSettings>
    <GanttEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" AllowTaskbarEditing="true"
                       ShowDeleteConfirmDialog="true"></GanttEditSettings>
    <GanttColumns>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.Id)" HeaderText="ID"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.Name)" HeaderText="Event Name" Width="250px"></GanttColumn>
        <GanttResourceColumn HeaderText="Event Resources" Width="300px"></GanttResourceColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.Work)" HeaderText="Work"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.Duration)" HeaderText="Duration"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.TaskType)" HeaderText="Task Type"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.StartDate)" HeaderText="Start Date"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.EndDate)" HeaderText="End Date"></GanttColumn>
    </GanttColumns>
    <GanttSplitterSettings Position="28%"> </GanttSplitterSettings>
</SfGantt>

@code {
    private DateTime ProjectStart = new DateTime(2021, 3, 28);
    private DateTime ProjectEnd = new DateTime(2021, 7, 28);
    private List<GanttModel.TaskInfoModel> TaskCollection { get; set; } = new();
    private List<GanttModel.ResourceInfoModel> ResourceCollection { get; set; } = new();
    private static List<GanttModel.AssignmentModel> AssignmentCollection { get; set; } = new();
    protected override void OnInitialized()
    {
        TaskCollection = GanttModel.GetTaskCollection();
        ResourceCollection = GanttModel.GetResources;
        AssignmentCollection = GanttModel.GetAssignmentCollection();
    }
}

{% endhighlight %}

{% highlight c# tabtitle="GanttModel.cs" %}

namespace BlazorGanttChart.Data
{
    public class GanttModel
    {
        public class ResourceInfoModel
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public double MaxUnit { get; set; }
        }

        public class TaskInfoModel
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? TaskType { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string? Duration { get; set; }
            public int Progress { get; set; }
            public int? ParentId { get; set; }
            public double? Work { get; set; }
        }

        public class AssignmentModel
        {
            public int PrimaryId { get; set; }
            public int TaskId { get; set; }
            public int ResourceId { get; set; }
            public double Unit { get; set; }
        }

        public static List<ResourceInfoModel> GetResources = new List<ResourceInfoModel>()
        {
            new ResourceInfoModel() { Id= 1, Name= "Martin Tamer" ,MaxUnit=70},
            new ResourceInfoModel() { Id= 2, Name= "Rose Fuller" },
            new ResourceInfoModel() { Id= 3, Name= "Margaret Buchanan" },
            new ResourceInfoModel() { Id= 4, Name= "Fuller King", MaxUnit = 100},
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
                new AssignmentModel(){ PrimaryId=1, TaskId = 2 , ResourceId=1, Unit=70},
                new AssignmentModel(){ PrimaryId=2, TaskId = 2 , ResourceId=6},
                new AssignmentModel(){ PrimaryId=3, TaskId = 3 , ResourceId=2},
                new AssignmentModel(){ PrimaryId=4, TaskId = 3 , ResourceId=3},
                new AssignmentModel(){ PrimaryId=5, TaskId = 3 , ResourceId=6},
                new AssignmentModel(){ PrimaryId=6, TaskId = 4 , ResourceId=8},
                new AssignmentModel(){ PrimaryId=7, TaskId = 4 , ResourceId=9},
                new AssignmentModel(){ PrimaryId=8, TaskId = 6 , ResourceId=4},
                new AssignmentModel(){ PrimaryId=9, TaskId = 7 , ResourceId=4},
                new AssignmentModel(){ PrimaryId=10, TaskId = 7 , ResourceId=8},
                new AssignmentModel(){ PrimaryId=11, TaskId = 8 , ResourceId=12},
                new AssignmentModel(){ PrimaryId=12, TaskId = 8 , ResourceId=5},
                new AssignmentModel(){ PrimaryId=13, TaskId = 9 , ResourceId=12},
                new AssignmentModel(){ PrimaryId=14, TaskId = 9 , ResourceId=5}
            };
            return assignments;
        }

        public static List<TaskInfoModel> GetTaskCollection()
        {
            return new List<TaskInfoModel>()
            {
                new TaskInfoModel() { Id = 1, Name = "Project initiation", StartDate = new DateTime(2021, 03, 28), EndDate = new DateTime(2021, 07, 28), TaskType ="FixedDuration", Work=128, Duration="4" },
                new TaskInfoModel() { Id = 2, Name = "Identify site location", StartDate = new DateTime(2021, 03, 29), Progress = 30, ParentId = 1, Duration="2", TaskType ="FixedDuration", Work=16 },
                new TaskInfoModel() { Id = 3, Name = "Perform soil test", StartDate = new DateTime(2021, 03, 29), ParentId = 1, Work=96, Duration="4", TaskType="FixedWork" },
                new TaskInfoModel() { Id = 4, Name = "Soil test approval", StartDate = new DateTime(2021, 03, 29), Duration = "1", Progress = 30, ParentId = 1, Work=16, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 5, Name = "Project estimation", StartDate = new DateTime(2021, 03, 29), EndDate = new DateTime(2021, 04, 2), TaskType="FixedDuration", Duration="4" },
                new TaskInfoModel() { Id = 6, Name = "Develop floor plan for estimation", StartDate = new DateTime(2021, 03, 29), Duration = "3", Progress = 30, ParentId = 5, Work=30, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 7, Name = "List materials", StartDate = new DateTime(2021, 04, 01), Duration = "3", Progress = 30, ParentId = 5, TaskType="FixedWork", Work=48 },
                new TaskInfoModel() { Id = 8, Name = "Estimation approval", StartDate = new DateTime(2021, 04, 01), Duration = "2", ParentId = 5, Work=60, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 9, Name = "Sign contract", StartDate = new DateTime(2021, 03, 31), EndDate = new DateTime(2021, 04, 01), Duration="1", TaskType="FixedWork", Work=24 },
            };
        }
    }
}

{% endhighlight %}

{% endtabs %}

![Resource unit](images/blazor-gantt-chart-resource.png)

## Managing resources assignments in project view

In the Gantt Chart, you can enable dynamic resources assignments by setting the [AllowEditing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEditSettings.html#Syncfusion_Blazor_Gantt_GanttEditSettings_AllowEditing) properties to **true** in the [GanttEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEditSettings.html) component. These actions can be performed using the following three methods:

### Through cell edit

To edit resources directly through [cell editing](https://blazor.syncfusion.com/documentation/gantt-chart/editing-tasks#cell-editing), you can use the [GanttResourceColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttResourceColumn.html) within the [GanttColumns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumns.html) of the Blazor Gantt Chart. The following code snippet demonstrates the cell edit functionality in the Gantt chart.


{% tabs %}

{% highlight razor %}


@using Syncfusion.Blazor.Gantt
@using BlazorGanttChart.Data

<SfGantt DataSource="@TaskCollection" Height="450px" Width="850px" TreeColumnIndex="1" ProjectStartDate="@ProjectStart" ProjectEndDate="@ProjectEnd" WorkUnit="WorkUnit.Hour"
         Toolbar="@(new List<string>(){ "Add", "Edit", "Update", "Delete", "Cancel", "ExpandAll", "CollapseAll"})">
    <GanttTaskFields Id="@nameof(GanttModel.TaskInfoModel.Id)" Name="@nameof(GanttModel.TaskInfoModel.Name)" StartDate="@nameof(GanttModel.TaskInfoModel.StartDate)" EndDate="@nameof(GanttModel.TaskInfoModel.EndDate)" Duration="@nameof(GanttModel.TaskInfoModel.Duration)" Progress="@nameof(GanttModel.TaskInfoModel.Progress)"
                     ParentID="@nameof(GanttModel.TaskInfoModel.ParentId)" Work="@nameof(GanttModel.TaskInfoModel.Work)" TaskType="@nameof(GanttModel.TaskInfoModel.TaskType)">
    </GanttTaskFields>
    <GanttResource DataSource="ResourceCollection" Id="@nameof(GanttModel.ResourceInfoModel.Id)" Name="@nameof(GanttModel.ResourceInfoModel.Name)" MaxUnits="@nameof(GanttModel.ResourceInfoModel.MaxUnit)" TValue="GanttModel.TaskInfoModel" TResources="GanttModel.ResourceInfoModel"></GanttResource>
    <GanttAssignmentFields DataSource="AssignmentCollection" PrimaryKey="@nameof(GanttModel.AssignmentModel.PrimaryId)" TaskID="@nameof(GanttModel.AssignmentModel.TaskId)" ResourceID="@nameof(GanttModel.AssignmentModel.ResourceId)" Units="@nameof(GanttModel.AssignmentModel.Unit)" TValue="GanttModel.TaskInfoModel" TAssignment="GanttModel.AssignmentModel">
    </GanttAssignmentFields>
    <GanttLabelSettings RightLabel="Resources" TValue="GanttModel.TaskInfoModel"></GanttLabelSettings>
    <GanttEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" AllowTaskbarEditing="true"
                       ShowDeleteConfirmDialog="true"></GanttEditSettings>
    <GanttColumns>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.Id)" HeaderText="ID"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.Name)" HeaderText="Event Name" Width="250px"></GanttColumn>
        <GanttResourceColumn HeaderText="Event Resources" Width="300px"></GanttResourceColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.Work)" HeaderText="Work"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.Duration)" HeaderText="Duration"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.TaskType)" HeaderText="Task Type"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.StartDate)" HeaderText="Start Date"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.EndDate)" HeaderText="End Date"></GanttColumn>
    </GanttColumns>
    <GanttSplitterSettings Position="28%"> </GanttSplitterSettings>
</SfGantt>

@code {
    private DateTime ProjectStart = new DateTime(2021, 3, 28);
    private DateTime ProjectEnd = new DateTime(2021, 7, 28);
    private List<GanttModel.TaskInfoModel> TaskCollection { get; set; } = new();
    private List<GanttModel.ResourceInfoModel> ResourceCollection { get; set; } = new();
    private static List<GanttModel.AssignmentModel> AssignmentCollection { get; set; } = new();
    protected override void OnInitialized()
    {
        TaskCollection = GanttModel.GetTaskCollection();
        ResourceCollection = GanttModel.GetResources;
        AssignmentCollection = GanttModel.GetAssignmentCollection();
    }
}

{% endhighlight %}

{% highlight c# tabtitle="GanttModel.cs" %}

namespace BlazorGanttChart.Data
{
    public class GanttModel
    {
        public class ResourceInfoModel
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public double MaxUnit { get; set; }
        }

        public class TaskInfoModel
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? TaskType { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string? Duration { get; set; }
            public int Progress { get; set; }
            public int? ParentId { get; set; }
            public double? Work { get; set; }
        }

        public class AssignmentModel
        {
            public int PrimaryId { get; set; }
            public int TaskId { get; set; }
            public int ResourceId { get; set; }
            public double Unit { get; set; }
        }

        public static List<ResourceInfoModel> GetResources = new List<ResourceInfoModel>()
        {
            new ResourceInfoModel() { Id= 1, Name= "Martin Tamer" ,MaxUnit=70},
            new ResourceInfoModel() { Id= 2, Name= "Rose Fuller" },
            new ResourceInfoModel() { Id= 3, Name= "Margaret Buchanan" },
            new ResourceInfoModel() { Id= 4, Name= "Fuller King", MaxUnit = 100},
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
                new AssignmentModel(){ PrimaryId=1, TaskId = 2 , ResourceId=1, Unit=70},
                new AssignmentModel(){ PrimaryId=2, TaskId = 2 , ResourceId=6},
                new AssignmentModel(){ PrimaryId=3, TaskId = 3 , ResourceId=2},
                new AssignmentModel(){ PrimaryId=4, TaskId = 3 , ResourceId=3},
                new AssignmentModel(){ PrimaryId=5, TaskId = 3 , ResourceId=6},
                new AssignmentModel(){ PrimaryId=6, TaskId = 4 , ResourceId=8},
                new AssignmentModel(){ PrimaryId=7, TaskId = 4 , ResourceId=9},
                new AssignmentModel(){ PrimaryId=8, TaskId = 6 , ResourceId=4},
                new AssignmentModel(){ PrimaryId=9, TaskId = 7 , ResourceId=4},
                new AssignmentModel(){ PrimaryId=10, TaskId = 7 , ResourceId=8},
                new AssignmentModel(){ PrimaryId=11, TaskId = 8 , ResourceId=12},
                new AssignmentModel(){ PrimaryId=12, TaskId = 8 , ResourceId=5},
                new AssignmentModel(){ PrimaryId=13, TaskId = 9 , ResourceId=12},
                new AssignmentModel(){ PrimaryId=14, TaskId = 9 , ResourceId=5}
            };
            return assignments;
        }

        public static List<TaskInfoModel> GetTaskCollection()
        {
            return new List<TaskInfoModel>()
            {
                new TaskInfoModel() { Id = 1, Name = "Project initiation", StartDate = new DateTime(2021, 03, 28), EndDate = new DateTime(2021, 07, 28), TaskType ="FixedDuration", Work=128, Duration="4" },
                new TaskInfoModel() { Id = 2, Name = "Identify site location", StartDate = new DateTime(2021, 03, 29), Progress = 30, ParentId = 1, Duration="2", TaskType ="FixedDuration", Work=16 },
                new TaskInfoModel() { Id = 3, Name = "Perform soil test", StartDate = new DateTime(2021, 03, 29), ParentId = 1, Work=96, Duration="4", TaskType="FixedWork" },
                new TaskInfoModel() { Id = 4, Name = "Soil test approval", StartDate = new DateTime(2021, 03, 29), Duration = "1", Progress = 30, ParentId = 1, Work=16, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 5, Name = "Project estimation", StartDate = new DateTime(2021, 03, 29), EndDate = new DateTime(2021, 04, 2), TaskType="FixedDuration", Duration="4" },
                new TaskInfoModel() { Id = 6, Name = "Develop floor plan for estimation", StartDate = new DateTime(2021, 03, 29), Duration = "3", Progress = 30, ParentId = 5, Work=30, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 7, Name = "List materials", StartDate = new DateTime(2021, 04, 01), Duration = "3", Progress = 30, ParentId = 5, TaskType="FixedWork", Work=48 },
                new TaskInfoModel() { Id = 8, Name = "Estimation approval", StartDate = new DateTime(2021, 04, 01), Duration = "2", ParentId = 5, Work=60, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 9, Name = "Sign contract", StartDate = new DateTime(2021, 03, 31), EndDate = new DateTime(2021, 04, 01), Duration="1", TaskType="FixedWork", Work=24 },
            };
        }
    }
}

{% endhighlight %}

{% endtabs %}


![Resource edit in cell editing](images/blazor-gantt-chart-resource-cell-edit.png)

### Through dialog box

In the resource tab of the [add/edit dialog box](https://blazor.syncfusion.com/documentation/gantt-chart/editing-tasks#dialog-editing) within the Gantt chart, resources can be conveniently added or removed using the checkboxes provided in the grid rows of the resource tab. Clicking on a checkbox item in a grid row adds the corresponding resource to the task, while unchecking it removes the resource. Also, the resource tab allows editing the unit value for individual resources.

{% tabs %}

{% highlight razor %}


@using Syncfusion.Blazor.Gantt
@using BlazorGanttChart.Data

<SfGantt DataSource="@TaskCollection" Height="450px" Width="850px" TreeColumnIndex="1" ProjectStartDate="@ProjectStart" ProjectEndDate="@ProjectEnd" WorkUnit="WorkUnit.Hour"
         Toolbar="@(new List<string>(){ "Add", "Edit", "Update", "Delete", "Cancel", "ExpandAll", "CollapseAll"})">
    <GanttTaskFields Id="@nameof(GanttModel.TaskInfoModel.Id)" Name="@nameof(GanttModel.TaskInfoModel.Name)" StartDate="@nameof(GanttModel.TaskInfoModel.StartDate)" EndDate="@nameof(GanttModel.TaskInfoModel.EndDate)" Duration="@nameof(GanttModel.TaskInfoModel.Duration)" Progress="@nameof(GanttModel.TaskInfoModel.Progress)"
                     ParentID="@nameof(GanttModel.TaskInfoModel.ParentId)" Work="@nameof(GanttModel.TaskInfoModel.Work)" TaskType="@nameof(GanttModel.TaskInfoModel.TaskType)">
    </GanttTaskFields>
    <GanttResource DataSource="ResourceCollection" Id="@nameof(GanttModel.ResourceInfoModel.Id)" Name="@nameof(GanttModel.ResourceInfoModel.Name)" MaxUnits="@nameof(GanttModel.ResourceInfoModel.MaxUnit)" TValue="GanttModel.TaskInfoModel" TResources="GanttModel.ResourceInfoModel"></GanttResource>
    <GanttAssignmentFields DataSource="AssignmentCollection" PrimaryKey="@nameof(GanttModel.AssignmentModel.PrimaryId)" TaskID="@nameof(GanttModel.AssignmentModel.TaskId)" ResourceID="@nameof(GanttModel.AssignmentModel.ResourceId)" Units="@nameof(GanttModel.AssignmentModel.Unit)" TValue="GanttModel.TaskInfoModel" TAssignment="GanttModel.AssignmentModel">
    </GanttAssignmentFields>
    <GanttLabelSettings RightLabel="Resources" TValue="GanttModel.TaskInfoModel"></GanttLabelSettings>
    <GanttEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" AllowTaskbarEditing="true"
                       ShowDeleteConfirmDialog="true"></GanttEditSettings>
    <GanttColumns>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.Id)" HeaderText="ID"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.Name)" HeaderText="Event Name" Width="250px"></GanttColumn>
        <GanttResourceColumn HeaderText="Event Resources" Width="300px"></GanttResourceColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.Work)" HeaderText="Work"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.Duration)" HeaderText="Duration"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.TaskType)" HeaderText="Task Type"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.StartDate)" HeaderText="Start Date"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.EndDate)" HeaderText="End Date"></GanttColumn>
    </GanttColumns>
    <GanttSplitterSettings Position="28%"> </GanttSplitterSettings>
</SfGantt>

@code {
    private DateTime ProjectStart = new DateTime(2021, 3, 28);
    private DateTime ProjectEnd = new DateTime(2021, 7, 28);
    private List<GanttModel.TaskInfoModel> TaskCollection { get; set; } = new();
    private List<GanttModel.ResourceInfoModel> ResourceCollection { get; set; } = new();
    private static List<GanttModel.AssignmentModel> AssignmentCollection { get; set; } = new();
    protected override void OnInitialized()
    {
        TaskCollection = GanttModel.GetTaskCollection();
        ResourceCollection = GanttModel.GetResources;
        AssignmentCollection = GanttModel.GetAssignmentCollection();
    }
}

{% endhighlight %}

{% highlight c# tabtitle="GanttModel.cs" %}

using System.ComponentModel.DataAnnotations;

namespace BlazorGanttChart.Data
{
    public class GanttModel
    {
        public class ResourceInfoModel
        {
            [Display(Name ="ID")]
            public int Id { get; set; }
            [Display(ShortName ="Name")]
            public string? Name { get; set; }
            [Display(ShortName = "Unit")]
            public double MaxUnit { get; set; }
        }

        public class TaskInfoModel
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? TaskType { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string? Duration { get; set; }
            public int Progress { get; set; }
            public int? ParentId { get; set; }
            public double? Work { get; set; }
        }

        public class AssignmentModel
        {
            public int PrimaryId { get; set; }
            public int TaskId { get; set; }
            public int ResourceId { get; set; }
            public double Unit { get; set; }
        }

        public static List<ResourceInfoModel> GetResources = new List<ResourceInfoModel>()
        {
            new ResourceInfoModel() { Id= 1, Name= "Martin Tamer" ,MaxUnit=70},
            new ResourceInfoModel() { Id= 2, Name= "Rose Fuller" },
            new ResourceInfoModel() { Id= 3, Name= "Margaret Buchanan" },
            new ResourceInfoModel() { Id= 4, Name= "Fuller King", MaxUnit = 100},
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
                new AssignmentModel(){ PrimaryId=1, TaskId = 2 , ResourceId=1, Unit=70},
                new AssignmentModel(){ PrimaryId=2, TaskId = 2 , ResourceId=6},
                new AssignmentModel(){ PrimaryId=3, TaskId = 3 , ResourceId=2},
                new AssignmentModel(){ PrimaryId=4, TaskId = 3 , ResourceId=3},
                new AssignmentModel(){ PrimaryId=5, TaskId = 3 , ResourceId=6},
                new AssignmentModel(){ PrimaryId=6, TaskId = 4 , ResourceId=8},
                new AssignmentModel(){ PrimaryId=7, TaskId = 4 , ResourceId=9},
                new AssignmentModel(){ PrimaryId=8, TaskId = 6 , ResourceId=4},
                new AssignmentModel(){ PrimaryId=9, TaskId = 7 , ResourceId=4},
                new AssignmentModel(){ PrimaryId=10, TaskId = 7 , ResourceId=8},
                new AssignmentModel(){ PrimaryId=11, TaskId = 8 , ResourceId=12},
                new AssignmentModel(){ PrimaryId=12, TaskId = 8 , ResourceId=5},
                new AssignmentModel(){ PrimaryId=13, TaskId = 9 , ResourceId=12},
                new AssignmentModel(){ PrimaryId=14, TaskId = 9 , ResourceId=5}
            };
            return assignments;
        }

        public static List<TaskInfoModel> GetTaskCollection()
        {
            return new List<TaskInfoModel>()
            {
                new TaskInfoModel() { Id = 1, Name = "Project initiation", StartDate = new DateTime(2021, 03, 28), EndDate = new DateTime(2021, 07, 28), TaskType ="FixedDuration", Work=128, Duration="4" },
                new TaskInfoModel() { Id = 2, Name = "Identify site location", StartDate = new DateTime(2021, 03, 29), Progress = 30, ParentId = 1, Duration="2", TaskType ="FixedDuration", Work=16 },
                new TaskInfoModel() { Id = 3, Name = "Perform soil test", StartDate = new DateTime(2021, 03, 29), ParentId = 1, Work=96, Duration="4", TaskType="FixedWork" },
                new TaskInfoModel() { Id = 4, Name = "Soil test approval", StartDate = new DateTime(2021, 03, 29), Duration = "1", Progress = 30, ParentId = 1, Work=16, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 5, Name = "Project estimation", StartDate = new DateTime(2021, 03, 29), EndDate = new DateTime(2021, 04, 2), TaskType="FixedDuration", Duration="4" },
                new TaskInfoModel() { Id = 6, Name = "Develop floor plan for estimation", StartDate = new DateTime(2021, 03, 29), Duration = "3", Progress = 30, ParentId = 5, Work=30, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 7, Name = "List materials", StartDate = new DateTime(2021, 04, 01), Duration = "3", Progress = 30, ParentId = 5, TaskType="FixedWork", Work=48 },
                new TaskInfoModel() { Id = 8, Name = "Estimation approval", StartDate = new DateTime(2021, 04, 01), Duration = "2", ParentId = 5, Work=60, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 9, Name = "Sign contract", StartDate = new DateTime(2021, 03, 31), EndDate = new DateTime(2021, 04, 01), Duration="1", TaskType="FixedWork", Work=24 },
            };
        }
    }
}

{% endhighlight %}

{% endtabs %}

![Resource edit in dialogbox](images/blazor-gantt-chart-resource-dialogbox.gif)

### Through method

You can manipulate task resources programmatically by using the following methods:

* [AddResourceAssignmentAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AddResourceAssignmentAsync): This method adds a new resource to a specific task in the Gantt chart.
* [DeleteResourceAssignmentAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_DeleteResourceAssignmentAsync): Use this method to remove a resource from an existing task in the Gantt chart.
* [UpdateResourceAssignmentAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_UpdateResourceAssignmentAsync): This method updates an existing resource assignment for a task, allowing you to modify resource allocations as needed within the Gantt chart.

Additionally, you can retrieve assigned resources and resource assignments through the following methods:

* [GetResources](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_GetResources): Retrieves the list of resources.
* [GetResourceAssignments](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_GetResourceAssignments): Retrieves the list of resource assignments.

* [AddRecordAsync]() - This method is utilized to add a new task to the Gantt chart. The fourth argument in this method is used for adding resources to the task.

These methods offer a convenient way to add, remove, and update task resources in your Gantt chart efficiently. In the code snippet below, upon clicking an external button, the following actions are performed:

* Add a resource to the 7th index record.
* Update the resource of the 3rd index record.
* Delete the resource of the 1st index record.
* Retrieve the resource of the 1st index record.
* Retrieve the resource assignments of the 1st index record.

{% tabs %}

{% highlight razor %}

@using Syncfusion.Blazor.Gantt
@using BlazorGanttChart.Data

<button @onclick="AddAssignment">Add Assignment</button>
<button @onclick="UpdateAssignment">Update Assignment</button>
<button @onclick="DeleteAssignment">Delete Assignment</button>
<button @onclick="GetResource">GetResource</button>
<button @onclick="GetAssignment">GetAssignments</button>
<button @onclick="AddNewRecord">AddRecord</button>

<SfGantt @ref="ganttInstance" DataSource="@TaskCollection" Height="450px" Width="850px" TreeColumnIndex="1" ProjectStartDate="@ProjectStart" ProjectEndDate="@ProjectEnd" WorkUnit="WorkUnit.Hour"
         Toolbar="@(new List<string>(){ "Add", "Edit", "Update", "Delete", "Cancel", "ExpandAll", "CollapseAll"})">
    <GanttTaskFields Id="@nameof(GanttModel.TaskInfoModel.Id)" Name="@nameof(GanttModel.TaskInfoModel.Name)" StartDate="@nameof(GanttModel.TaskInfoModel.StartDate)" EndDate="@nameof(GanttModel.TaskInfoModel.EndDate)" Duration="@nameof(GanttModel.TaskInfoModel.Duration)" Progress="@nameof(GanttModel.TaskInfoModel.Progress)"
                     ParentID="@nameof(GanttModel.TaskInfoModel.ParentId)" Work="@nameof(GanttModel.TaskInfoModel.Work)" TaskType="@nameof(GanttModel.TaskInfoModel.TaskType)">
    </GanttTaskFields>
    <GanttResource DataSource="ResourceCollection" Id="@nameof(GanttModel.ResourceInfoModel.Id)" Name="@nameof(GanttModel.ResourceInfoModel.Name)" MaxUnits="@nameof(GanttModel.ResourceInfoModel.MaxUnit)" TValue="GanttModel.TaskInfoModel" TResources="GanttModel.ResourceInfoModel"></GanttResource>
    <GanttAssignmentFields DataSource="AssignmentCollection" PrimaryKey="@nameof(GanttModel.AssignmentModel.PrimaryId)" TaskID="@nameof(GanttModel.AssignmentModel.TaskId)" ResourceID="@nameof(GanttModel.AssignmentModel.ResourceId)" Units="@nameof(GanttModel.AssignmentModel.Unit)" TValue="GanttModel.TaskInfoModel" TAssignment="GanttModel.AssignmentModel">
    </GanttAssignmentFields>
    <GanttLabelSettings RightLabel="Resources" TValue="GanttModel.TaskInfoModel"></GanttLabelSettings>
    <GanttEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" AllowTaskbarEditing="true"
                       ShowDeleteConfirmDialog="true"></GanttEditSettings>
    <GanttColumns>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.Id)" HeaderText="ID"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.Name)" HeaderText="Event Name" Width="250px"></GanttColumn>
        <GanttResourceColumn HeaderText="Event Resources" Width="300px"></GanttResourceColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.Work)" HeaderText="Work"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.Duration)" HeaderText="Duration"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.TaskType)" HeaderText="Task Type"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.StartDate)" HeaderText="Start Date"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.EndDate)" HeaderText="End Date"></GanttColumn>
    </GanttColumns>
    <GanttSplitterSettings Position="28%"> </GanttSplitterSettings>
</SfGantt>

@code {
    private SfGantt<GanttModel.TaskInfoModel> ganttInstance { get; set; } = new();
    private DateTime ProjectStart = new DateTime(2021, 3, 28);
    private DateTime ProjectEnd = new DateTime(2021, 7, 28);
    private List<GanttModel.TaskInfoModel> TaskCollection { get; set; } = new();
    private List<GanttModel.ResourceInfoModel> ResourceCollection { get; set; } = new();
    private static List<GanttModel.AssignmentModel> AssignmentCollection { get; set; } = new();
    protected override void OnInitialized()
    {
        TaskCollection = GanttModel.GetTaskCollection();
        ResourceCollection = GanttModel.GetResources;
        AssignmentCollection = GanttModel.GetAssignmentCollection();
    }
    private async void AddAssignment()
    {
        var record = new GanttModel.AssignmentModel() { PrimaryId = 15, TaskId = 8, ResourceId = 8 };
        await ganttInstance.AddResourceAssignmentAsync(record);
    }
    private async void UpdateAssignment()
    {
        var record = new GanttModel.AssignmentModel() { PrimaryId = 7, TaskId = 4, ResourceId = 3, Unit = 50 };
        await ganttInstance.UpdateResourceAssignmentAsync(record);
    }
    private async void DeleteAssignment()
    {
        var record = new GanttModel.AssignmentModel() { TaskId = 2, ResourceId = 6 };
        await ganttInstance.DeleteResourceAssignmentAsync(record);
    }

    private void GetResource()
    {
        GanttModel.TaskInfoModel data = new GanttModel.TaskInfoModel() { Id = 2 };
        var resources = ganttInstance.GetResources<GanttModel.ResourceInfoModel>(data);
    }
    private void GetAssignment()
    {
        GanttModel.TaskInfoModel data = new GanttModel.TaskInfoModel() { Id = 2 };
        var assignments = ganttInstance.GetResourceAssignments<GanttModel.AssignmentModel>(data);
    }
    private async void AddNewRecord()
    {
        var record = new GanttModel.AssignmentModel() { PrimaryId = 19, TaskId = 10, ResourceId = 8 };
        GanttModel.TaskInfoModel data = new GanttModel.TaskInfoModel() { Id = 10, Name = "NewRecord", StartDate = new DateTime(2021, 03, 29), Duration = "2", };
        await ganttInstance.AddRecordAsync(data, 0, null, record);
    }
}

{% endhighlight %}

{% highlight c# tabtitle="GanttModel.cs" %}

namespace BlazorGanttChart.Data
{
    public class GanttModel
    {
        public class ResourceInfoModel
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public double MaxUnit { get; set; }
        }

        public class TaskInfoModel
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? TaskType { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string? Duration { get; set; }
            public int Progress { get; set; }
            public int? ParentId { get; set; }
            public double? Work { get; set; }
        }

        public class AssignmentModel
        {
            public int PrimaryId { get; set; }
            public int TaskId { get; set; }
            public int ResourceId { get; set; }
            public double Unit { get; set; }
        }

        public static List<ResourceInfoModel> GetResources = new List<ResourceInfoModel>()
        {
            new ResourceInfoModel() { Id= 1, Name= "Martin Tamer" ,MaxUnit=70},
            new ResourceInfoModel() { Id= 2, Name= "Rose Fuller" },
            new ResourceInfoModel() { Id= 3, Name= "Margaret Buchanan" },
            new ResourceInfoModel() { Id= 4, Name= "Fuller King", MaxUnit = 100},
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
                new AssignmentModel(){ PrimaryId=1, TaskId = 2 , ResourceId=1, Unit=70},
                new AssignmentModel(){ PrimaryId=2, TaskId = 2 , ResourceId=6},
                new AssignmentModel(){ PrimaryId=3, TaskId = 3 , ResourceId=2},
                new AssignmentModel(){ PrimaryId=4, TaskId = 3 , ResourceId=3},
                new AssignmentModel(){ PrimaryId=5, TaskId = 3 , ResourceId=6},
                new AssignmentModel(){ PrimaryId=6, TaskId = 4 , ResourceId=8},
                new AssignmentModel(){ PrimaryId=7, TaskId = 4 , ResourceId=9},
                new AssignmentModel(){ PrimaryId=8, TaskId = 6 , ResourceId=4},
                new AssignmentModel(){ PrimaryId=9, TaskId = 7 , ResourceId=4},
                new AssignmentModel(){ PrimaryId=10, TaskId = 7 , ResourceId=8},
                new AssignmentModel(){ PrimaryId=11, TaskId = 8 , ResourceId=12},
                new AssignmentModel(){ PrimaryId=12, TaskId = 8 , ResourceId=5},
                new AssignmentModel(){ PrimaryId=13, TaskId = 9 , ResourceId=12},
                new AssignmentModel(){ PrimaryId=14, TaskId = 9 , ResourceId=5}
            };
            return assignments;
        }

        public static List<TaskInfoModel> GetTaskCollection()
        {
            return new List<TaskInfoModel>()
            {
                new TaskInfoModel() { Id = 1, Name = "Project initiation", StartDate = new DateTime(2021, 03, 28), EndDate = new DateTime(2021, 07, 28), TaskType ="FixedDuration", Work=128, Duration="4" },
                new TaskInfoModel() { Id = 2, Name = "Identify site location", StartDate = new DateTime(2021, 03, 29), Progress = 30, ParentId = 1, Duration="2", TaskType ="FixedDuration", Work=16 },
                new TaskInfoModel() { Id = 3, Name = "Perform soil test", StartDate = new DateTime(2021, 03, 29), ParentId = 1, Work=96, Duration="4", TaskType="FixedWork" },
                new TaskInfoModel() { Id = 4, Name = "Soil test approval", StartDate = new DateTime(2021, 03, 29), Duration = "1", Progress = 30, ParentId = 1, Work=16, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 5, Name = "Project estimation", StartDate = new DateTime(2021, 03, 29), EndDate = new DateTime(2021, 04, 2), TaskType="FixedDuration", Duration="4" },
                new TaskInfoModel() { Id = 6, Name = "Develop floor plan for estimation", StartDate = new DateTime(2021, 03, 29), Duration = "3", Progress = 30, ParentId = 5, Work=30, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 7, Name = "List materials", StartDate = new DateTime(2021, 04, 01), Duration = "3", Progress = 30, ParentId = 5, TaskType="FixedWork", Work=48 },
                new TaskInfoModel() { Id = 8, Name = "Estimation approval", StartDate = new DateTime(2021, 04, 01), Duration = "2", ParentId = 5, Work=60, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 9, Name = "Sign contract", StartDate = new DateTime(2021, 03, 31), EndDate = new DateTime(2021, 04, 01), Duration="1", TaskType="FixedWork", Work=24 },
            };
        }
    }
}

{% endhighlight %}

{% endtabs %}

![Resource method in Gantt Chart](images/blazor-gantt-chart-resource-method.gif)

## Resource event

The [ResourceAssignmentChanging](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttAssignmentFields-1.html#Syncfusion_Blazor_Gantt_GanttAssignmentFields_1_ResourceAssignmentChanging) event is triggered in the Blazor Gantt chart when resource add, remove, and update actions occur. This event allows for custom actions to be performed, and it also provides the ability to cancel add, remove, or update actions by setting the [Cancel](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.ResourceAssignmentChangeEventArgs-1.html#Syncfusion_Blazor_Gantt_ResourceAssignmentChangeEventArgs_1_Cancel) property of the event argument to **true**.

In the code snippet below, the `ResourceAssignmentChanging` event is used to display a customized message when performing resource add, remove, and update actions. Additionally, it prevents resource deletion for the 1st index task.

{% tabs %}

{% highlight razor %}

@using Syncfusion.Blazor.Gantt
@using BlazorGanttChart.Data

<span class="text-primary">@assignmentEventMessage</span>
<SfGantt @ref="ganttInstance" DataSource="@TaskCollection" Height="450px" Width="850px" TreeColumnIndex="1" WorkUnit="WorkUnit.Hour"
         Toolbar="@(new List<string>(){ "Add", "Edit", "Update", "Delete", "Cancel", "ExpandAll", "CollapseAll"})">
    <GanttTaskFields Id="@nameof(GanttModel.TaskInfoModel.Id)" Name="@nameof(GanttModel.TaskInfoModel.Name)" StartDate="@nameof(GanttModel.TaskInfoModel.StartDate)" EndDate="@nameof(GanttModel.TaskInfoModel.EndDate)" Duration="@nameof(GanttModel.TaskInfoModel.Duration)"
                     ParentID="@nameof(GanttModel.TaskInfoModel.ParentId)" Work="@nameof(GanttModel.TaskInfoModel.Work)" TaskType="@nameof(GanttModel.TaskInfoModel.TaskType)" Progress="@nameof(GanttModel.TaskInfoModel.Progress)">
    </GanttTaskFields>
    <GanttResource DataSource="ResourceCollection" Id="@nameof(GanttModel.ResourceInfoModel.Id)" Name="@nameof(GanttModel.ResourceInfoModel.Name)" MaxUnits="@nameof(GanttModel.ResourceInfoModel.MaxUnit)" TValue="GanttModel.TaskInfoModel" TResources="GanttModel.ResourceInfoModel"></GanttResource>
    <GanttAssignmentFields DataSource="AssignmentCollection" PrimaryKey="@nameof(GanttModel.AssignmentModel.PrimaryId)" TaskID="@nameof(GanttModel.AssignmentModel.TaskId)" ResourceID="@nameof(GanttModel.AssignmentModel.ResourceId)" Units="@nameof(GanttModel.AssignmentModel.Unit)" ResourceAssignmentChanging="AssignmentHandler" TValue="GanttModel.TaskInfoModel" TAssignment="GanttModel.AssignmentModel"></GanttAssignmentFields>
    <GanttLabelSettings RightLabel="Resources" TValue="GanttModel.TaskInfoModel"></GanttLabelSettings>
    <GanttEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" AllowTaskbarEditing="true"
                       ShowDeleteConfirmDialog="true"></GanttEditSettings>
    <GanttColumns>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.Id)" HeaderText="ID"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.Name)" HeaderText="Event Name" Width="250px"></GanttColumn>
        <GanttResourceColumn HeaderText="Event Resources" Width="300px"></GanttResourceColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.Work)" HeaderText="Work"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.Duration)" HeaderText="Duration"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.TaskType)" HeaderText="Task Type"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.StartDate)" HeaderText="Start Date"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.EndDate)" HeaderText="End Date"></GanttColumn>
    </GanttColumns>
    <GanttSplitterSettings Position="28%"> </GanttSplitterSettings>
</SfGantt>

@code {
    private SfGantt<GanttModel.TaskInfoModel> ganttInstance { get; set; } = new();
    private List<GanttModel.TaskInfoModel> TaskCollection { get; set; } = new();
    private List<GanttModel.ResourceInfoModel> ResourceCollection { get; set; } = new();
    private static List<GanttModel.AssignmentModel> AssignmentCollection { get; set; } = new();
    private string assignmentEventMessage { get; set; }
    protected override void OnInitialized()
    {
        TaskCollection = GanttModel.GetTaskCollection();
        ResourceCollection = GanttModel.GetResources;
        AssignmentCollection = GanttModel.GetAssignmentCollection();
    }
    private async Task AssignmentHandler(ResourceAssignmentChangeEventArgs<GanttModel.AssignmentModel> args)
    {
        if (args.AddedResources is not null && args.AddedResources.Any())
        {
            assignmentEventMessage = "New resource is added!";
        }
        if (args.UpdatedResources is not null && args.UpdatedResources.Any())
        {
            assignmentEventMessage = "The resource details are updated!";
        }
        if (args.DeletedResources is not null && args.DeletedResources.Any())
        {
            foreach(GanttModel.AssignmentModel assignment in args.DeletedResources)
            {
                if (assignment.TaskId == 2)
                {
                    assignmentEventMessage = "The deleted resource action is canceled!";
                    args.Cancel = true;
                }
            }
        }
        await Task.CompletedTask;
    }
}

{% endhighlight %}

{% highlight c# tabtitle="GanttModel.cs" %}

namespace BlazorGanttChart.Data
{
    public class GanttModel
    {
        public class ResourceInfoModel
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public double MaxUnit { get; set; }
        }

        public class TaskInfoModel
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? TaskType { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string? Duration { get; set; }
            public int Progress { get; set; }
            public int? ParentId { get; set; }
            public double? Work { get; set; }
        }

        public class AssignmentModel
        {
            public int PrimaryId { get; set; }
            public int TaskId { get; set; }
            public int ResourceId { get; set; }
            public double Unit { get; set; }
        }

        public static List<ResourceInfoModel> GetResources = new List<ResourceInfoModel>()
        {
            new ResourceInfoModel() { Id= 1, Name= "Martin Tamer" ,MaxUnit=70},
            new ResourceInfoModel() { Id= 2, Name= "Rose Fuller" },
            new ResourceInfoModel() { Id= 3, Name= "Margaret Buchanan" },
            new ResourceInfoModel() { Id= 4, Name= "Fuller King", MaxUnit = 100},
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
                new AssignmentModel(){ PrimaryId=1, TaskId = 2 , ResourceId=1, Unit=70},
                new AssignmentModel(){ PrimaryId=2, TaskId = 2 , ResourceId=6},
                new AssignmentModel(){ PrimaryId=3, TaskId = 3 , ResourceId=2},
                new AssignmentModel(){ PrimaryId=4, TaskId = 3 , ResourceId=3},
                new AssignmentModel(){ PrimaryId=5, TaskId = 3 , ResourceId=6},
                new AssignmentModel(){ PrimaryId=6, TaskId = 4 , ResourceId=8},
                new AssignmentModel(){ PrimaryId=7, TaskId = 4 , ResourceId=9},
                new AssignmentModel(){ PrimaryId=8, TaskId = 6 , ResourceId=4},
                new AssignmentModel(){ PrimaryId=9, TaskId = 7 , ResourceId=4},
                new AssignmentModel(){ PrimaryId=10, TaskId = 7 , ResourceId=8},
                new AssignmentModel(){ PrimaryId=11, TaskId = 8 , ResourceId=12},
                new AssignmentModel(){ PrimaryId=12, TaskId = 8 , ResourceId=5},
                new AssignmentModel(){ PrimaryId=13, TaskId = 9 , ResourceId=12},
                new AssignmentModel(){ PrimaryId=14, TaskId = 9 , ResourceId=5}
            };
            return assignments;
        }

        public static List<TaskInfoModel> GetTaskCollection()
        {
            return new List<TaskInfoModel>()
            {
                new TaskInfoModel() { Id = 1, Name = "Project initiation", StartDate = new DateTime(2021, 03, 28), EndDate = new DateTime(2021, 07, 28), TaskType ="FixedDuration", Work=128, Duration="4" },
                new TaskInfoModel() { Id = 2, Name = "Identify site location", StartDate = new DateTime(2021, 03, 29), Progress = 30, ParentId = 1, Duration="3", TaskType ="FixedDuration", Work=16 },
                new TaskInfoModel() { Id = 3, Name = "Perform soil test", StartDate = new DateTime(2021, 03, 29), ParentId = 1, Work=96, Duration="4", TaskType="FixedWork" },
                new TaskInfoModel() { Id = 4, Name = "Soil test approval", StartDate = new DateTime(2021, 03, 29), Duration = "4", Progress = 30, ParentId = 1, Work=16, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 5, Name = "Project estimation", StartDate = new DateTime(2021, 03, 29), EndDate = new DateTime(2021, 04, 2), TaskType="FixedDuration", Duration="4" },
                new TaskInfoModel() { Id = 6, Name = "Develop floor plan for estimation", StartDate = new DateTime(2021, 03, 29), Duration = "3", Progress = 30, ParentId = 5, Work=30, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 7, Name = "List materials", StartDate = new DateTime(2021, 04, 01), Duration = "3", Progress = 30, ParentId = 5, TaskType="FixedWork", Work=48 },
                new TaskInfoModel() { Id = 8, Name = "Estimation approval", StartDate = new DateTime(2021, 04, 01), Duration = "4", ParentId = 5, Work=60, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 9, Name = "Sign contract", StartDate = new DateTime(2021, 03, 31), EndDate = new DateTime(2021, 04, 01), Duration="4", TaskType="FixedWork", Work=24 },
            };
        }
    }
}

{% endhighlight %}

{% endtabs %}

![Resource event in Gantt Chart](images/blazor-gantt-chart-resource-event.gif)

## Custom taskbar styling using template

The taskbar appearance can be customized by using the [TaskbarTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTemplates-1.html#Syncfusion_Blazor_Gantt_GanttTemplates_1_TaskbarTemplate) property. In the code snippet below, the child tasks are customized based on template context data, with the resource name added inside each child taskbar, and the taskbar colors are changed based on task resources.

{% tabs %}

{% highlight razor %}

@using Syncfusion.Blazor.Gantt
@using BlazorGanttChart.Data

<SfGantt @ref="ganttInstance" DataSource="@TaskCollection" Height="450px" Width="850px" TreeColumnIndex="1" WorkUnit="WorkUnit.Hour"
         Toolbar="@(new List<string>(){ "Add", "Edit", "Update", "Delete", "Cancel", "ExpandAll", "CollapseAll"})">
    <GanttTaskFields Id="@nameof(GanttModel.TaskInfoModel.Id)" Name="@nameof(GanttModel.TaskInfoModel.Name)" StartDate="@nameof(GanttModel.TaskInfoModel.StartDate)" EndDate="@nameof(GanttModel.TaskInfoModel.EndDate)" Duration="@nameof(GanttModel.TaskInfoModel.Duration)"
                     ParentID="@nameof(GanttModel.TaskInfoModel.ParentId)" Work="@nameof(GanttModel.TaskInfoModel.Work)" TaskType="@nameof(GanttModel.TaskInfoModel.TaskType)">
    </GanttTaskFields>
    <GanttResource DataSource="ResourceCollection" Id="@nameof(GanttModel.ResourceInfoModel.Id)" Name="@nameof(GanttModel.ResourceInfoModel.Name)" MaxUnits="@nameof(GanttModel.ResourceInfoModel.MaxUnit)" TValue="GanttModel.TaskInfoModel" TResources="GanttModel.ResourceInfoModel"></GanttResource>
    <GanttAssignmentFields DataSource="AssignmentCollection" PrimaryKey="@nameof(GanttModel.AssignmentModel.PrimaryId)" TaskID="@nameof(GanttModel.AssignmentModel.TaskId)" ResourceID="@nameof(GanttModel.AssignmentModel.ResourceId)" Units="@nameof(GanttModel.AssignmentModel.Unit)" TValue="GanttModel.TaskInfoModel" TAssignment="GanttModel.AssignmentModel">
    </GanttAssignmentFields>
    <GanttLabelSettings RightLabel="Resources" TValue="GanttModel.TaskInfoModel"></GanttLabelSettings>
    <GanttEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" AllowTaskbarEditing="true"
                       ShowDeleteConfirmDialog="true"></GanttEditSettings>
    <GanttTemplates TValue="GanttModel.TaskInfoModel">
        <TaskbarTemplate>
            @{
                var task = context as GanttModel.TaskInfoModel;
                if (task is null)
                {
                    return;
                }
                var taskModel = ganttInstance.GetRowTaskModel(task);
                string resource = GetResourceName(task);
                progressColor = "#5869c5";
                string backgroundColor = GetBGColor(resource);
                <div class="e-gantt-child-taskbar e-gantt-child-taskbar-inner-div" style="height:24px;background:@backgroundColor" tabindex=-1>
                    <div class="e-gantt-child-progressbar-inner-div e-gantt-child-progressbar" style="height:24px;width:@(taskModel.ProgressWidth + "px");text-align: right;border-radius: 0px;background:@progressColor">
                    </div>
                    <div style="position: absolute;font-size: 13px; top: 3px; color: #ffffff;left: 7px;overflow: hidden; width: @(taskModel.Width + "px"); text-wrap: nowrap;text-overflow: ellipsis;">
                        @resource
                    </div>
                </div>
            }
        </TaskbarTemplate>
    </GanttTemplates>
    <GanttColumns>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.Id)" HeaderText="ID"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.Name)" HeaderText="Event Name" Width="250px"></GanttColumn>
        <GanttResourceColumn HeaderText="Event Resources" Width="300px"></GanttResourceColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.Work)" HeaderText="Work"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.Duration)" HeaderText="Duration"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.TaskType)" HeaderText="Task Type"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.StartDate)" HeaderText="Start Date"></GanttColumn>
        <GanttColumn Field="@nameof(GanttModel.TaskInfoModel.EndDate)" HeaderText="End Date"></GanttColumn>
    </GanttColumns>
    <GanttSplitterSettings Position="28%"> </GanttSplitterSettings>
</SfGantt>

@code {
    private SfGantt<GanttModel.TaskInfoModel> ganttInstance { get; set; } = new();
    private List<GanttModel.TaskInfoModel> TaskCollection { get; set; } = new();
    private List<GanttModel.ResourceInfoModel> ResourceCollection { get; set; } = new();
    private static List<GanttModel.AssignmentModel> AssignmentCollection { get; set; } = new();
    private string progressColor = "#5869C5";
    protected override void OnInitialized()
    {
        TaskCollection = GanttModel.GetTaskCollection();
        ResourceCollection = GanttModel.GetResources;
        AssignmentCollection = GanttModel.GetAssignmentCollection();
    }

    private string GetResourceName(GanttModel.TaskInfoModel record)
    {
        var assignment = ganttInstance.GetResourceAssignments<GanttModel.AssignmentModel>(record);
        if (assignment is not null && assignment.Any())
        {
            var resourceId = (assignment[0] as GanttModel.AssignmentModel).ResourceId - 1;
            return (GanttModel.GetResources[(int)resourceId]).Name;
        }
        return string.Empty;
    }

    private string GetBGColor(string resource)
    {
        if (string.IsNullOrEmpty(resource))
        {
            return "#87B7FE";
        }
        string color = string.Empty;
        if (resource == "Martin Tamer")
        {
            color = "#5869C5";
            progressColor = "#AD7A66";
        }
        else if (resource == "Rose Fuller")
        {
            color = "#8553F1";
            progressColor = "#0056B3";
        }
        else if (resource == "Fuller King")
        {
            color = "#7AB748";
            progressColor = "#5869c5";
        }
        return color;
    }
}

{% endhighlight %}

{% highlight c# tabtitle="GanttModel.cs" %}

namespace BlazorGanttChart.Data
{
    public class GanttModel
    {
        public class ResourceInfoModel
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public double MaxUnit { get; set; }
        }

        public class TaskInfoModel
        {
            public int Id { get; set; }
            public string? Name { get; set; }
            public string? TaskType { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string? Duration { get; set; }
            public int Progress { get; set; }
            public int? ParentId { get; set; }
            public double? Work { get; set; }
        }

        public class AssignmentModel
        {
            public int PrimaryId { get; set; }
            public int TaskId { get; set; }
            public int ResourceId { get; set; }
            public double Unit { get; set; }
        }

        public static List<ResourceInfoModel> GetResources = new List<ResourceInfoModel>()
        {
            new ResourceInfoModel() { Id= 1, Name= "Martin Tamer" ,MaxUnit=70},
            new ResourceInfoModel() { Id= 2, Name= "Rose Fuller" },
            new ResourceInfoModel() { Id= 3, Name= "Margaret Buchanan" },
            new ResourceInfoModel() { Id= 4, Name= "Fuller King", MaxUnit = 100},
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
                new AssignmentModel(){ PrimaryId=1, TaskId = 2 , ResourceId=1, Unit=70},
                new AssignmentModel(){ PrimaryId=2, TaskId = 2 , ResourceId=6},
                new AssignmentModel(){ PrimaryId=3, TaskId = 3 , ResourceId=2},
                new AssignmentModel(){ PrimaryId=4, TaskId = 3 , ResourceId=3},
                new AssignmentModel(){ PrimaryId=5, TaskId = 3 , ResourceId=6},
                new AssignmentModel(){ PrimaryId=6, TaskId = 4 , ResourceId=8},
                new AssignmentModel(){ PrimaryId=7, TaskId = 4 , ResourceId=9},
                new AssignmentModel(){ PrimaryId=8, TaskId = 6 , ResourceId=4},
                new AssignmentModel(){ PrimaryId=9, TaskId = 7 , ResourceId=4},
                new AssignmentModel(){ PrimaryId=10, TaskId = 7 , ResourceId=8},
                new AssignmentModel(){ PrimaryId=11, TaskId = 8 , ResourceId=12},
                new AssignmentModel(){ PrimaryId=12, TaskId = 8 , ResourceId=5},
                new AssignmentModel(){ PrimaryId=13, TaskId = 9 , ResourceId=12},
                new AssignmentModel(){ PrimaryId=14, TaskId = 9 , ResourceId=5}
            };
            return assignments;
        }

        public static List<TaskInfoModel> GetTaskCollection()
        {
            return new List<TaskInfoModel>()
            {
                new TaskInfoModel() { Id = 1, Name = "Project initiation", StartDate = new DateTime(2021, 03, 28), EndDate = new DateTime(2021, 07, 28), TaskType ="FixedDuration", Work=128, Duration="4" },
                new TaskInfoModel() { Id = 2, Name = "Identify site location", StartDate = new DateTime(2021, 03, 29), Progress = 30, ParentId = 1, Duration="3", TaskType ="FixedDuration", Work=16 },
                new TaskInfoModel() { Id = 3, Name = "Perform soil test", StartDate = new DateTime(2021, 03, 29), ParentId = 1, Work=96, Duration="4", TaskType="FixedWork" },
                new TaskInfoModel() { Id = 4, Name = "Soil test approval", StartDate = new DateTime(2021, 03, 29), Duration = "4", Progress = 30, ParentId = 1, Work=16, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 5, Name = "Project estimation", StartDate = new DateTime(2021, 03, 29), EndDate = new DateTime(2021, 04, 2), TaskType="FixedDuration", Duration="4" },
                new TaskInfoModel() { Id = 6, Name = "Develop floor plan for estimation", StartDate = new DateTime(2021, 03, 29), Duration = "3", Progress = 30, ParentId = 5, Work=30, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 7, Name = "List materials", StartDate = new DateTime(2021, 04, 01), Duration = "3", Progress = 30, ParentId = 5, TaskType="FixedWork", Work=48 },
                new TaskInfoModel() { Id = 8, Name = "Estimation approval", StartDate = new DateTime(2021, 04, 01), Duration = "4", ParentId = 5, Work=60, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 9, Name = "Sign contract", StartDate = new DateTime(2021, 03, 31), EndDate = new DateTime(2021, 04, 01), Duration="4", TaskType="FixedWork", Work=24 },
            };
        }
    }
}

{% endhighlight %}

{% endtabs %}


![Custom taskbar styling in Gantt Chart](images/blazor-gantt-chart-resource-taskbar-custom.png)

## See also

* [CRUD operations on tasks](https://blazor.syncfusion.com/documentation/gantt-chart/managing-tasks)