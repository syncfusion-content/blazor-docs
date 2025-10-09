---
layout: post
title: Resource View in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about Resource view in Syncfusion Blazor Gantt Chart component and more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Resource view in Blazor Gantt Chart Component

To visualize tasks assigned to each resource in a hierarchical manner, you can set the [ViewType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ViewType) property to [ResourceView](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.ViewType.html#Syncfusion_Blazor_Gantt_ViewType_ResourceView) during initialization of the Gantt Chart. This view represents resources as parent records and their corresponding tasks as child records. You can refer to this [link](https://blazor.syncfusion.com/documentation/gantt-chart/resources.html) for detailed instructions on binding resources data within a Gantt Chart.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using BlazorGanttChart.Data

<SfGantt @ref="ganttInstance" DataSource="@TaskCollection" ViewType="Syncfusion.Blazor.Gantt.ViewType.ResourceView" Height="450px" Width="850px" TreeColumnIndex="1" WorkUnit="WorkUnit.Hour"
         Toolbar="@(new List<string>(){ "Add", "Edit", "Update", "Delete", "Cancel", "ExpandAll", "CollapseAll"})">
    <GanttTaskFields Id="@nameof(GanttModel.TaskInfoModel.Id)" Name="@nameof(GanttModel.TaskInfoModel.Name)" StartDate="@nameof(GanttModel.TaskInfoModel.StartDate)" EndDate="@nameof(GanttModel.TaskInfoModel.EndDate)" Duration="@nameof(GanttModel.TaskInfoModel.Duration)"
                     ParentID="@nameof(GanttModel.TaskInfoModel.ParentID)" Work="@nameof(GanttModel.TaskInfoModel.Work)" TaskType="@nameof(GanttModel.TaskInfoModel.TaskType)" Progress="@nameof(GanttModel.TaskInfoModel.Progress)">
    </GanttTaskFields>
    <GanttResource DataSource="ResourceCollection" Id="@nameof(GanttModel.ResourceInfoModel.Id)" Name="@nameof(GanttModel.ResourceInfoModel.Name)" MaxUnits="@nameof(GanttModel.ResourceInfoModel.MaxUnit)" TValue="GanttModel.TaskInfoModel" TResources="GanttModel.ResourceInfoModel"></GanttResource>
    <GanttAssignmentFields DataSource="AssignmentCollection" PrimaryKey="@nameof(GanttModel.AssignmentModel.PrimaryId)" TaskID="@nameof(GanttModel.AssignmentModel.TaskID)" ResourceID="@nameof(GanttModel.AssignmentModel.ResourceId)" Units="@nameof(GanttModel.AssignmentModel.Unit)" TValue="GanttModel.TaskInfoModel" TAssignment="GanttModel.AssignmentModel">
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
            public string Name { get; set; }
            public double MaxUnit { get; set; }
        }

        public class TaskInfoModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string TaskType { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string Duration { get; set; }
            public int Progress { get; set; }
            public int? ParentID { get; set; }
            public double? Work { get; set; }
        }

        public class AssignmentModel
        {
            public int PrimaryId { get; set; }
            public int TaskID { get; set; }
            public int ResourceId { get; set; }
            public double? Unit { get; set; }
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
                new AssignmentModel(){ PrimaryId=1, TaskID = 2 , ResourceId=1, Unit=70},
                new AssignmentModel(){ PrimaryId=2, TaskID = 3 , ResourceId=1, Unit=70},
                new AssignmentModel(){ PrimaryId=3, TaskID = 4 , ResourceId=3},
                new AssignmentModel(){ PrimaryId=4, TaskID = 6 , ResourceId=2},
                new AssignmentModel(){ PrimaryId=5, TaskID = 7 , ResourceId=4, Unit=30},
                new AssignmentModel(){ PrimaryId=6, TaskID = 8 , ResourceId=8},
                new AssignmentModel(){ PrimaryId=7, TaskID = 9 , ResourceId=11},
            };
            return assignments;
        }

        public static List<TaskInfoModel> GetTaskCollection()
        {
            return new List<TaskInfoModel>()
            {
                new TaskInfoModel() { Id = 1, Name = "Project initiation", StartDate = new DateTime(2021, 03, 28), EndDate = new DateTime(2021, 07, 28), TaskType ="FixedDuration", Work=128, Duration="4" },
                new TaskInfoModel() { Id = 2, Name = "Identify site location", StartDate = new DateTime(2021, 03, 29), Progress = 30, ParentID = 1, Duration="3", TaskType ="FixedDuration", Work=16 },
                new TaskInfoModel() { Id = 3, Name = "Perform soil test", StartDate = new DateTime(2021, 03, 29), ParentID = 1, Work=96, Duration="4", TaskType="FixedWork" },
                new TaskInfoModel() { Id = 4, Name = "Soil test approval", StartDate = new DateTime(2021, 03, 29), Duration = "4", Progress = 30, ParentID = 1, Work=16, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 5, Name = "Project estimation", StartDate = new DateTime(2021, 03, 29), EndDate = new DateTime(2021, 04, 2), TaskType="FixedDuration", Duration="4" },
                new TaskInfoModel() { Id = 6, Name = "Develop floor plan for estimation", StartDate = new DateTime(2021, 03, 29), Duration = "3", Progress = 30, ParentID = 5, Work=30, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 7, Name = "List materials", StartDate = new DateTime(2021, 04, 01), Duration = "3", Progress = 30, ParentID = 5, TaskType="FixedWork", Work=48 },
                new TaskInfoModel() { Id = 8, Name = "Estimation approval", StartDate = new DateTime(2021, 04, 01), Duration = "4", ParentID = 5, Work=60, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 9, Name = "Sign contract", StartDate = new DateTime(2021, 03, 31), EndDate = new DateTime(2021, 04, 01), Duration="4", TaskType="FixedWork", Work=24 },
            };
        }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZVyCDZqqMPafknB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * In the resource view, records are ordered based on the assigning of task resources. If a task does not have any assigned resources, it is placed under the **Unassigned Tasks** parent record. 
> * The delete operation in the resource view functions differently: if you delete any task under a resource, the task is first moved under the **Unassigned Tasks** parent record. If you subsequently delete the same record again, it is completely removed from the task collection. 
> * There is not support for Indent/Outdent in resource view Gantt Chart.

## Resource overallocation

When a resource is assigned more work than they can complete within their available time in a day, it is referred to as overallocation. The available working time for resources to complete tasks in a day is calculated based on the [GanttDayWorkingTime](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttDayWorkingTimeCollection.html#Syncfusion_Blazor_Gantt_GanttDayWorkingTimeCollection_DayWorkingTime) property and the [resource unit](https://blazor.syncfusion.com/documentation/gantt-chart/resources.html#resource-unit).

You can indicate overallocation date ranges with square brackets by enabling the feature through the [ShowOverallocation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ShowOverallocation) property.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using BlazorGanttChart.Data

<SfGantt @ref="ganttInstance" ShowOverallocation="true" DataSource="@TaskCollection" ViewType="Syncfusion.Blazor.Gantt.ViewType.ResourceView" Height="450px" Width="850px" TreeColumnIndex="1" WorkUnit="WorkUnit.Hour"
         Toolbar="@(new List<string>(){ "Add", "Edit", "Update", "Delete", "Cancel", "ExpandAll", "CollapseAll"})">
    <GanttTaskFields Id="@nameof(GanttModel.TaskInfoModel.Id)" Name="@nameof(GanttModel.TaskInfoModel.Name)" StartDate="@nameof(GanttModel.TaskInfoModel.StartDate)" EndDate="@nameof(GanttModel.TaskInfoModel.EndDate)" Duration="@nameof(GanttModel.TaskInfoModel.Duration)"
                     ParentID="@nameof(GanttModel.TaskInfoModel.ParentID)" Work="@nameof(GanttModel.TaskInfoModel.Work)" TaskType="@nameof(GanttModel.TaskInfoModel.TaskType)" Progress="@nameof(GanttModel.TaskInfoModel.Progress)">
    </GanttTaskFields>
    <GanttResource DataSource="ResourceCollection" Id="@nameof(GanttModel.ResourceInfoModel.Id)" Name="@nameof(GanttModel.ResourceInfoModel.Name)" MaxUnits="@nameof(GanttModel.ResourceInfoModel.MaxUnit)" TValue="GanttModel.TaskInfoModel" TResources="GanttModel.ResourceInfoModel"></GanttResource>
    <GanttAssignmentFields DataSource="AssignmentCollection" PrimaryKey="@nameof(GanttModel.AssignmentModel.PrimaryId)" TaskID="@nameof(GanttModel.AssignmentModel.TaskID)" ResourceID="@nameof(GanttModel.AssignmentModel.ResourceId)" Units="@nameof(GanttModel.AssignmentModel.Unit)" TValue="GanttModel.TaskInfoModel" TAssignment="GanttModel.AssignmentModel">
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
            public string Name { get; set; }
            public double MaxUnit { get; set; }
        }

        public class TaskInfoModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string TaskType { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string Duration { get; set; }
            public int Progress { get; set; }
            public int? ParentID { get; set; }
            public double? Work { get; set; }
        }

        public class AssignmentModel
        {
            public int PrimaryId { get; set; }
            public int TaskID { get; set; }
            public int ResourceId { get; set; }
            public double? Unit { get; set; }
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
                new AssignmentModel(){ PrimaryId=1, TaskID = 2 , ResourceId=1, Unit=70},
                new AssignmentModel(){ PrimaryId=2, TaskID = 3 , ResourceId=1, Unit=70},
                new AssignmentModel(){ PrimaryId=3, TaskID = 4 , ResourceId=2},
                new AssignmentModel(){ PrimaryId=4, TaskID = 6 , ResourceId=2},
                new AssignmentModel(){ PrimaryId=5, TaskID = 7 , ResourceId=3, Unit=30},
                new AssignmentModel(){ PrimaryId=6, TaskID = 8 , ResourceId=4},
                new AssignmentModel(){ PrimaryId=7, TaskID = 9 , ResourceId=11},
            };
            return assignments;
        }

        public static List<TaskInfoModel> GetTaskCollection()
        {
            return new List<TaskInfoModel>()
            {
                new TaskInfoModel() { Id = 1, Name = "Project initiation", StartDate = new DateTime(2021, 03, 28), EndDate = new DateTime(2021, 07, 28), TaskType ="FixedDuration", Work=128, Duration="4" },
                new TaskInfoModel() { Id = 2, Name = "Identify site location", StartDate = new DateTime(2021, 03, 29), Progress = 30, ParentID = 1, Duration="8", TaskType ="FixedDuration", Work=16 },
                new TaskInfoModel() { Id = 3, Name = "Perform soil test", StartDate = new DateTime(2021, 03, 29), ParentID = 1, Work=96, Duration="9", TaskType="FixedWork" },
                new TaskInfoModel() { Id = 4, Name = "Soil test approval", StartDate = new DateTime(2021, 03, 29), Duration = "8", Progress = 30, ParentID = 1, Work=16, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 5, Name = "Project estimation", StartDate = new DateTime(2021, 03, 29), EndDate = new DateTime(2021, 04, 2), TaskType="FixedDuration", Duration="4" },
                new TaskInfoModel() { Id = 6, Name = "Develop floor plan for estimation", StartDate = new DateTime(2021, 03, 29), Duration = "8", Progress = 30, ParentID = 5, Work=30, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 7, Name = "List materials", StartDate = new DateTime(2021, 04, 01), Duration = "8", Progress = 30, ParentID = 5, TaskType="FixedWork", Work=48 },
                new TaskInfoModel() { Id = 8, Name = "Estimation approval", StartDate = new DateTime(2021, 04, 01), Duration = "9", ParentID = 5, Work=60, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 9, Name = "Sign contract", StartDate = new DateTime(2021, 03, 31), EndDate = new DateTime(2021, 04, 01), Duration="9", TaskType="FixedWork", Work=24 },
            };
        }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjBesjDUULLCVRCX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Unassigned task

Unassigned tasks in the Gantt Chart refer to tasks that have not been assigned to any particular resource. These tasks are categorized under the parent row **Unassigned Tasks** and appears at the bottom of the Gantt Chart's data collection.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using BlazorGanttChart.Data

<SfGantt @ref="ganttInstance" DataSource="@TaskCollection" ViewType="Syncfusion.Blazor.Gantt.ViewType.ResourceView" Height="450px" Width="850px" TreeColumnIndex="1" WorkUnit="WorkUnit.Hour"
         Toolbar="@(new List<string>(){ "Add", "Edit", "Update", "Delete", "Cancel", "ExpandAll", "CollapseAll"})">
    <GanttTaskFields Id="@nameof(GanttModel.TaskInfoModel.Id)" Name="@nameof(GanttModel.TaskInfoModel.Name)" StartDate="@nameof(GanttModel.TaskInfoModel.StartDate)" EndDate="@nameof(GanttModel.TaskInfoModel.EndDate)" Duration="@nameof(GanttModel.TaskInfoModel.Duration)"
                     ParentID="@nameof(GanttModel.TaskInfoModel.ParentID)" Work="@nameof(GanttModel.TaskInfoModel.Work)" TaskType="@nameof(GanttModel.TaskInfoModel.TaskType)" Progress="@nameof(GanttModel.TaskInfoModel.Progress)">
    </GanttTaskFields>
    <GanttResource DataSource="ResourceCollection" Id="@nameof(GanttModel.ResourceInfoModel.Id)" Name="@nameof(GanttModel.ResourceInfoModel.Name)" MaxUnits="@nameof(GanttModel.ResourceInfoModel.MaxUnit)" TValue="GanttModel.TaskInfoModel" TResources="GanttModel.ResourceInfoModel"></GanttResource>
    <GanttAssignmentFields DataSource="AssignmentCollection" PrimaryKey="@nameof(GanttModel.AssignmentModel.PrimaryId)" TaskID="@nameof(GanttModel.AssignmentModel.TaskID)" ResourceID="@nameof(GanttModel.AssignmentModel.ResourceId)" Units="@nameof(GanttModel.AssignmentModel.Unit)" TValue="GanttModel.TaskInfoModel" TAssignment="GanttModel.AssignmentModel">
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
            public string Name { get; set; }
            public double MaxUnit { get; set; }
        }

        public class TaskInfoModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string TaskType { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string Duration { get; set; }
            public int Progress { get; set; }
            public int? ParentID { get; set; }
            public double? Work { get; set; }
        }

        public class AssignmentModel
        {
            public int PrimaryId { get; set; }
            public int TaskID { get; set; }
            public int ResourceId { get; set; }
            public double? Unit { get; set; }
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
                new AssignmentModel(){ PrimaryId=1, TaskID = 2 , ResourceId=1, Unit=70},
                new AssignmentModel(){ PrimaryId=2, TaskID = 3 , ResourceId=1, Unit=70},
                new AssignmentModel(){ PrimaryId=3, TaskID = 4 , ResourceId=2}
            };
            return assignments;
        }

        public static List<TaskInfoModel> GetTaskCollection()
        {
            return new List<TaskInfoModel>()
            {
                new TaskInfoModel() { Id = 1, Name = "Project initiation", StartDate = new DateTime(2021, 03, 28), EndDate = new DateTime(2021, 07, 28), TaskType ="FixedDuration", Work=128, Duration="4" },
                new TaskInfoModel() { Id = 2, Name = "Identify site location", StartDate = new DateTime(2021, 03, 29), Progress = 30, ParentID = 1, Duration="8", TaskType ="FixedDuration", Work=16 },
                new TaskInfoModel() { Id = 3, Name = "Perform soil test", StartDate = new DateTime(2021, 03, 29), ParentID = 1, Work=96, Duration="9", TaskType="FixedWork" },
                new TaskInfoModel() { Id = 4, Name = "Soil test approval", StartDate = new DateTime(2021, 03, 29), Duration = "8", Progress = 30, ParentID = 1, Work=16, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 5, Name = "Project estimation", StartDate = new DateTime(2021, 03, 29), EndDate = new DateTime(2021, 04, 2), TaskType="FixedDuration", Duration="4" },
                new TaskInfoModel() { Id = 6, Name = "Develop floor plan for estimation", StartDate = new DateTime(2021, 03, 29), Duration = "8", Progress = 30, ParentID = 5, Work=30, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 7, Name = "List materials", StartDate = new DateTime(2021, 04, 01), Duration = "8", Progress = 30, ParentID = 5, TaskType="FixedWork", Work=48 },
                new TaskInfoModel() { Id = 8, Name = "Estimation approval", StartDate = new DateTime(2021, 04, 01), Duration = "9", ParentID = 5, Work=60, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 9, Name = "Sign contract", StartDate = new DateTime(2021, 03, 31), EndDate = new DateTime(2021, 04, 01), Duration="9", TaskType="FixedWork", Work=24 },
            };
        }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNrosNjUUfnyXZum?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Multi-taskbar

For a compact view, multiple tasks assigned to each resource can be visualized in the parent row itself, when it is in collapsed state. To enable this feature, you can set the [EnableMultiTaskbar](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTaskbarSettings.html#Syncfusion_Blazor_Gantt_GanttTaskbarSettings_EnableMultiTaskbar) property of [GanttTaskbarSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTaskbarSettings.html). Taskbar editing is also supported, allowing you to adjust task scheduling directly from the collapsed view for enhanced task management.

> When a resource has multiple tasks scheduled on the same date, these tasks will be overlapped on each other, and overallocation indicator will be shown when [ShowOverallocation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ShowOverallocation) property is enabled.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using BlazorGanttChart.Data

<SfGantt @ref="ganttInstance" DataSource="@TaskCollection" ViewType="Syncfusion.Blazor.Gantt.ViewType.ResourceView" CollapseAllParentTasks=true Height="450px" Width="850px" TreeColumnIndex="1" WorkUnit="WorkUnit.Hour"
         Toolbar="@(new List<string>(){ "Add", "Edit", "Update", "Delete", "Cancel", "ExpandAll", "CollapseAll"})">
    <GanttTaskFields Id="@nameof(GanttModel.TaskInfoModel.Id)" Name="@nameof(GanttModel.TaskInfoModel.Name)" StartDate="@nameof(GanttModel.TaskInfoModel.StartDate)" EndDate="@nameof(GanttModel.TaskInfoModel.EndDate)" Duration="@nameof(GanttModel.TaskInfoModel.Duration)"
                     ParentID="@nameof(GanttModel.TaskInfoModel.ParentID)" Work="@nameof(GanttModel.TaskInfoModel.Work)" TaskType="@nameof(GanttModel.TaskInfoModel.TaskType)" Progress="@nameof(GanttModel.TaskInfoModel.Progress)">
    </GanttTaskFields>
    <GanttResource DataSource="ResourceCollection" Id="@nameof(GanttModel.ResourceInfoModel.Id)" Name="@nameof(GanttModel.ResourceInfoModel.Name)" MaxUnits="@nameof(GanttModel.ResourceInfoModel.MaxUnit)" TValue="GanttModel.TaskInfoModel" TResources="GanttModel.ResourceInfoModel"></GanttResource>
    <GanttAssignmentFields DataSource="AssignmentCollection" PrimaryKey="@nameof(GanttModel.AssignmentModel.PrimaryId)" TaskID="@nameof(GanttModel.AssignmentModel.TaskID)" ResourceID="@nameof(GanttModel.AssignmentModel.ResourceId)" Units="@nameof(GanttModel.AssignmentModel.Unit)" TValue="GanttModel.TaskInfoModel" TAssignment="GanttModel.AssignmentModel">
    </GanttAssignmentFields>
    <GanttLabelSettings RightLabel="Resources" TValue="GanttModel.TaskInfoModel"></GanttLabelSettings>
    <GanttTaskbarSettings EnableMultiTaskbar="true"></GanttTaskbarSettings>
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
            public string Name { get; set; }
            public double MaxUnit { get; set; }
        }

        public class TaskInfoModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string TaskType { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string Duration { get; set; }
            public int Progress { get; set; }
            public int? ParentID { get; set; }
            public double? Work { get; set; }
            public string Predecessor { get; set; }
        }

        public class AssignmentModel
        {
            public int PrimaryId { get; set; }
            public int TaskID { get; set; }
            public int ResourceId { get; set; }
            public double? Unit { get; set; }
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
                new AssignmentModel(){ PrimaryId=1, TaskID = 2 , ResourceId=1, Unit=70},
                new AssignmentModel(){ PrimaryId=2, TaskID = 3 , ResourceId=1, Unit=70},
                new AssignmentModel(){ PrimaryId=3, TaskID = 4 , ResourceId=1},
                new AssignmentModel(){ PrimaryId=4, TaskID = 6 , ResourceId=2},
                new AssignmentModel(){ PrimaryId=6, TaskID = 8 , ResourceId=2},
                new AssignmentModel(){ PrimaryId=7, TaskID = 10 , ResourceId=3},
                new AssignmentModel(){ PrimaryId=8, TaskID = 11, ResourceId=3},
                new AssignmentModel(){ PrimaryId=9, TaskID = 12 , ResourceId=3},
                new AssignmentModel(){ PrimaryId=10, TaskID = 14 , ResourceId=4},
                new AssignmentModel(){ PrimaryId=11, TaskID = 15 , ResourceId=4},
                new AssignmentModel(){ PrimaryId=12, TaskID = 16 , ResourceId=4},
                new AssignmentModel(){ PrimaryId=13, TaskID = 18 , ResourceId=5},
                new AssignmentModel(){ PrimaryId=14, TaskID = 19 , ResourceId=5},
                new AssignmentModel(){ PrimaryId=15, TaskID = 20 , ResourceId=5},
                new AssignmentModel(){ PrimaryId=16, TaskID = 21 , ResourceId=6},
                new AssignmentModel(){ PrimaryId=17, TaskID = 22 , ResourceId=6},
                new AssignmentModel(){ PrimaryId=18, TaskID = 23 , ResourceId=7},
                new AssignmentModel(){ PrimaryId=19, TaskID = 24 , ResourceId=7},
                new AssignmentModel(){ PrimaryId=20, TaskID = 25 , ResourceId=8},
                new AssignmentModel(){ PrimaryId=21, TaskID = 26 , ResourceId=8},
                new AssignmentModel(){ PrimaryId=22, TaskID = 27 , ResourceId=9},
                new AssignmentModel(){ PrimaryId=23, TaskID = 28 , ResourceId=9},
                new AssignmentModel(){ PrimaryId=24, TaskID = 29 , ResourceId=10},
            };
            return assignments;
        }

        public static List<TaskInfoModel> GetTaskCollection()
        {
            List<TaskInfoModel> Tasks = new List<TaskInfoModel>()
            {
                new TaskInfoModel() { Id = 1, Name = "Project initiation", StartDate = new DateTime(2019, 03, 29), EndDate = new DateTime(2019, 04, 21), TaskType = "FixedDuration", Work = 128, Duration = "4" },
                new TaskInfoModel() { Id = 2, Name = "Identify Site location", StartDate = new DateTime(2019, 03, 29), Progress = 30, ParentID = 1, Duration = "2" },
                new TaskInfoModel() { Id = 3, Name = "Perform soil test", StartDate = new DateTime(2019, 04, 03), Progress = 50, ParentID = 1, Duration = "3", Work = 16 },
                new TaskInfoModel() { Id = 4, Name = "Soil test approval", StartDate = new DateTime(2019, 04, 09), ParentID = 1, Work = 96, Duration = "2", TaskType = "FixedWork", Predecessor = "3", Progress = 40 },
                new TaskInfoModel() { Id = 5, Name = "Project estimation", StartDate = new DateTime(2019, 03, 29), EndDate = new DateTime(2019, 04, 21), Progress = 30, Work = 16, TaskType = "FixedWork" },
                new TaskInfoModel() { Id = 6, Name = "Develop floor plan for estimation", StartDate = new DateTime(2019, 04, 01), TaskType = "FixedDuration", Duration = "5", Progress = 40, Work = 50 },
                new TaskInfoModel() { Id = 7, Name = "List materials", StartDate = new DateTime(2019, 04, 04), Duration = "2", Progress = 30, ParentID = 5, Work = 30, TaskType = "FixedDuration", Predecessor = "6FS-2" },
                new TaskInfoModel() { Id = 8, Name = "Estimation approval", StartDate = new DateTime(2019, 04, 09), Duration = "2", Progress = 30, ParentID = 5, TaskType = "FixedWork", Work = 48, Predecessor = "7FS-1" },
                new TaskInfoModel() { Id = 9, Name = "Site work", Progress = 30, StartDate = new DateTime(2019, 04, 04), EndDate = new DateTime(2019, 04, 21), Work = 60, TaskType = "FixedUnit" },
                new TaskInfoModel() { Id = 10, Name = "Install temporary power service", StartDate = new DateTime(2019, 04, 01), Duration = "4", ParentID = 9, Work = 60, Progress = 50, TaskType = "FixedWork" },
                new TaskInfoModel() { Id = 11, Name = "Clear the building site", StartDate = new DateTime(2019, 04, 08), Duration = "3", ParentID = 9, Work = 60, Progress = 40, TaskType = "FixedDuration", Predecessor = "10FS-9" },
                new TaskInfoModel() { Id = 12, Name = "Sign contract", StartDate = new DateTime(2019, 04, 12), Duration = "3", ParentID = 9, Work = 60, Progress = 40, TaskType = "FixedDuration", Predecessor = "11FS-5" },
                new TaskInfoModel() { Id = 13, Name = "Foundation", StartDate = new DateTime(2022, 04, 04), EndDate = new DateTime(2019, 04, 28), Work = 60, Progress = 40, TaskType = "FixedDuration" },
                new TaskInfoModel() { Id = 14, Name = "Excavate for foundations", StartDate = new DateTime(2019, 04, 01), Duration = "2", ParentID = 13, Work = 60, Progress = 40, TaskType = "FixedDuration" },
                new TaskInfoModel() { Id = 15, Name = "Dig footer", StartDate = new DateTime(2019, 04, 04), Duration = "2", ParentID = 13, Work = 60, Progress = 40, TaskType = "FixedDuration", Predecessor = "14FS + 1" },
                new TaskInfoModel() { Id = 16, Name = "Install plumbing grounds", StartDate = new DateTime(2019, 04, 08), Duration = "2", ParentID = 13, Work = 60, Progress = 40, TaskType = "FixedDuration", Predecessor = "15FS" }, new TaskInfoModel() { Id = 17, Name = "Framing", StartDate = new DateTime(2019, 04, 04), EndDate = new DateTime(2019, 04, 28), Work = 60, Progress = 40, TaskType = "FixedDuration" },
                new TaskInfoModel() { Id = 18, Name = "Add load-bearing structure", StartDate = new DateTime(2019, 04, 03), Duration = "2", ParentID = 17, Work = 60, Progress = 20, TaskType = "FixedDuration" },
                new TaskInfoModel() { Id = 19, Name = "Natural gas utilities", StartDate = new DateTime(2019, 04, 08), Duration = "3", ParentID = 17, Work = 60, Progress = 40, TaskType = "FixedDuration", Predecessor = "18" },
                new TaskInfoModel() { Id = 20, Name = "Electrical utilities", StartDate = new DateTime(2022, 04, 01), Duration = "2", ParentID = 17, Work = 60, Progress = 50, TaskType = "FixedWork", Predecessor = "19FS + 1" },
                new TaskInfoModel() { Id = 21, Name = "Plumbing test", StartDate = new DateTime(2019, 04, 04), Duration = "3", Work = 60, Progress = 50, TaskType = "FixedWork" },
                new TaskInfoModel() { Id = 22, Name = "Electrical test", StartDate = new DateTime(2019, 04, 04), Duration = "3", Work = 60, Progress = 50, TaskType = "FixedWork", Predecessor = "21" },
                new TaskInfoModel() { Id = 23, Name = "First floor initiation", StartDate = new DateTime(2019, 04, 06), Duration = "3", Work = 60, Progress = 50, TaskType = "FixedWork" },
                new TaskInfoModel() { Id = 24, Name = "Interior work", StartDate = new DateTime(2019, 04, 04), Duration = "1", Work = 60, Progress = 50, TaskType = "FixedWork", Predecessor = "23" },
                new TaskInfoModel() { Id = 25, Name = "First floor tile work initation", StartDate = new DateTime(2019, 04, 10), Duration = "4", Work = 60, Progress = 50, TaskType = "FixedWork" },
                new TaskInfoModel() { Id = 26, Name = "Tile test", StartDate = new DateTime(2019, 04, 04), Duration = "3", Work = 60, Progress = 50, TaskType = "FixedWork" },
                new TaskInfoModel() { Id = 27, Name = "Second floor initiation", StartDate = new DateTime(2019, 04, 15), Duration = "3", Work = 60, Progress = 50, TaskType = "FixedWork" },
                new TaskInfoModel() { Id = 28, Name = "Second floor tile work initation", StartDate = new DateTime(2019, 04, 06), Duration = "3", Work = 60, Progress = 50, TaskType = "FixedWork", Predecessor = "27FS - 1" },
                new TaskInfoModel() { Id = 29, Name = "Exterior work initation", StartDate = new DateTime(2019, 04, 12), Duration = "3", Work = 60, Progress = 50, TaskType = "FixedWork" },
                new TaskInfoModel() { Id = 30, Name = "Building test", StartDate = new DateTime(2019, 04, 08), Duration = "3", Work = 60, Progress = 50, TaskType = "FixedWork" }
            };
            return Tasks;
        }
    }
}


{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjreCNXUAQtgGkIm?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Taskbar drag and drop between resources

You can smoothly move taskbars vertically, enabling the seamless transfer of tasks between different resources. This capability simplifies task scheduling and enhances overall resource management. Whether you're reassigning tasks to different resources or optimizing resource allocation, you can achieve these tasks effortlessly.

Within the Gantt chart, taskbar repositioning tasks among different resources can be enabled by setting the [AllowTaskbarDragAndDrop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTaskbarSettings.html#Syncfusion_Blazor_Gantt_GanttTaskbarSettings_AllowTaskbarDragAndDrop) property within `GanttTaskbarSettings` to **true**.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using BlazorGanttChart.Data

<SfGantt @ref="ganttInstance" DataSource="@TaskCollection" ViewType="Syncfusion.Blazor.Gantt.ViewType.ResourceView" CollapseAllParentTasks=true Height="450px" Width="850px" TreeColumnIndex="1" WorkUnit="WorkUnit.Hour"
         Toolbar="@(new List<string>(){ "Add", "Edit", "Update", "Delete", "Cancel", "ExpandAll", "CollapseAll"})">
    <GanttTaskFields Id="@nameof(GanttModel.TaskInfoModel.Id)" Name="@nameof(GanttModel.TaskInfoModel.Name)" StartDate="@nameof(GanttModel.TaskInfoModel.StartDate)" EndDate="@nameof(GanttModel.TaskInfoModel.EndDate)" Duration="@nameof(GanttModel.TaskInfoModel.Duration)"
                     ParentID="@nameof(GanttModel.TaskInfoModel.ParentID)" Work="@nameof(GanttModel.TaskInfoModel.Work)" TaskType="@nameof(GanttModel.TaskInfoModel.TaskType)" Progress="@nameof(GanttModel.TaskInfoModel.Progress)">
    </GanttTaskFields>
    <GanttResource DataSource="ResourceCollection" Id="@nameof(GanttModel.ResourceInfoModel.Id)" Name="@nameof(GanttModel.ResourceInfoModel.Name)" MaxUnits="@nameof(GanttModel.ResourceInfoModel.MaxUnit)" TValue="GanttModel.TaskInfoModel" TResources="GanttModel.ResourceInfoModel"></GanttResource>
    <GanttAssignmentFields DataSource="AssignmentCollection" PrimaryKey="@nameof(GanttModel.AssignmentModel.PrimaryId)" TaskID="@nameof(GanttModel.AssignmentModel.TaskID)" ResourceID="@nameof(GanttModel.AssignmentModel.ResourceId)" Units="@nameof(GanttModel.AssignmentModel.Unit)" TValue="GanttModel.TaskInfoModel" TAssignment="GanttModel.AssignmentModel">
    </GanttAssignmentFields>
    <GanttLabelSettings RightLabel="Resources" TValue="GanttModel.TaskInfoModel"></GanttLabelSettings>
    <GanttTaskbarSettings EnableMultiTaskbar="true" AllowTaskbarDragAndDrop="true"></GanttTaskbarSettings>
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
            public string Name { get; set; }
            public double MaxUnit { get; set; }
        }

        public class TaskInfoModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string TaskType { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string Duration { get; set; }
            public int Progress { get; set; }
            public int? ParentID { get; set; }
            public double? Work { get; set; }
            public string Predecessor { get; set; }
        }

        public class AssignmentModel
        {
            public int PrimaryId { get; set; }
            public int TaskID { get; set; }
            public int ResourceId { get; set; }
            public double? Unit { get; set; }
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
                new AssignmentModel(){ PrimaryId=1, TaskID = 2 , ResourceId=1, Unit=70},
                new AssignmentModel(){ PrimaryId=2, TaskID = 3 , ResourceId=1, Unit=70},
                new AssignmentModel(){ PrimaryId=3, TaskID = 4 , ResourceId=1},
                new AssignmentModel(){ PrimaryId=4, TaskID = 6 , ResourceId=2},
                new AssignmentModel(){ PrimaryId=6, TaskID = 8 , ResourceId=2},
                new AssignmentModel(){ PrimaryId=7, TaskID = 10 , ResourceId=3},
                new AssignmentModel(){ PrimaryId=8, TaskID = 11, ResourceId=3},
                new AssignmentModel(){ PrimaryId=9, TaskID = 12 , ResourceId=3},
                new AssignmentModel(){ PrimaryId=10, TaskID = 14 , ResourceId=4},
                new AssignmentModel(){ PrimaryId=11, TaskID = 15 , ResourceId=4},
                new AssignmentModel(){ PrimaryId=12, TaskID = 16 , ResourceId=4},
                new AssignmentModel(){ PrimaryId=13, TaskID = 18 , ResourceId=5},
                new AssignmentModel(){ PrimaryId=14, TaskID = 19 , ResourceId=5},
                new AssignmentModel(){ PrimaryId=15, TaskID = 20 , ResourceId=5},
                new AssignmentModel(){ PrimaryId=16, TaskID = 21 , ResourceId=6},
                new AssignmentModel(){ PrimaryId=17, TaskID = 22 , ResourceId=6},
                new AssignmentModel(){ PrimaryId=18, TaskID = 23 , ResourceId=7},
                new AssignmentModel(){ PrimaryId=19, TaskID = 24 , ResourceId=7},
                new AssignmentModel(){ PrimaryId=20, TaskID = 25 , ResourceId=8},
                new AssignmentModel(){ PrimaryId=21, TaskID = 26 , ResourceId=8},
                new AssignmentModel(){ PrimaryId=22, TaskID = 27 , ResourceId=9},
                new AssignmentModel(){ PrimaryId=23, TaskID = 28 , ResourceId=9},
                new AssignmentModel(){ PrimaryId=24, TaskID = 29 , ResourceId=10},
            };
            return assignments;
        }

        public static List<TaskInfoModel> GetTaskCollection()
        {
            List<TaskInfoModel> Tasks = new List<TaskInfoModel>()
            {
                new TaskInfoModel() { Id = 1, Name = "Project initiation", StartDate = new DateTime(2019, 03, 29), EndDate = new DateTime(2019, 04, 21), TaskType = "FixedDuration", Work = 128, Duration = "4" },
                new TaskInfoModel() { Id = 2, Name = "Identify Site location", StartDate = new DateTime(2019, 03, 29), Progress = 30, ParentID = 1, Duration = "2" },
                new TaskInfoModel() { Id = 3, Name = "Perform soil test", StartDate = new DateTime(2019, 04, 03), Progress = 50, ParentID = 1, Duration = "3", Work = 16 },
                new TaskInfoModel() { Id = 4, Name = "Soil test approval", StartDate = new DateTime(2019, 04, 09), ParentID = 1, Work = 96, Duration = "2", TaskType = "FixedWork", Predecessor = "3", Progress = 40 },
                new TaskInfoModel() { Id = 5, Name = "Project estimation", StartDate = new DateTime(2019, 03, 29), EndDate = new DateTime(2019, 04, 21), Progress = 30, Work = 16, TaskType = "FixedWork" },
                new TaskInfoModel() { Id = 6, Name = "Develop floor plan for estimation", StartDate = new DateTime(2019, 04, 01), TaskType = "FixedDuration", Duration = "5", Progress = 40, Work = 50 },
                new TaskInfoModel() { Id = 7, Name = "List materials", StartDate = new DateTime(2019, 04, 04), Duration = "2", Progress = 30, ParentID = 5, Work = 30, TaskType = "FixedDuration", Predecessor = "6FS-2" },
                new TaskInfoModel() { Id = 8, Name = "Estimation approval", StartDate = new DateTime(2019, 04, 09), Duration = "2", Progress = 30, ParentID = 5, TaskType = "FixedWork", Work = 48, Predecessor = "7FS-1" },
                new TaskInfoModel() { Id = 9, Name = "Site work", Progress = 30, StartDate = new DateTime(2019, 04, 04), EndDate = new DateTime(2019, 04, 21), Work = 60, TaskType = "FixedUnit" },
                new TaskInfoModel() { Id = 10, Name = "Install temporary power service", StartDate = new DateTime(2019, 04, 01), Duration = "4", ParentID = 9, Work = 60, Progress = 50, TaskType = "FixedWork" },
                new TaskInfoModel() { Id = 11, Name = "Clear the building site", StartDate = new DateTime(2019, 04, 08), Duration = "3", ParentID = 9, Work = 60, Progress = 40, TaskType = "FixedDuration", Predecessor = "10FS-9" },
                new TaskInfoModel() { Id = 12, Name = "Sign contract", StartDate = new DateTime(2019, 04, 12), Duration = "3", ParentID = 9, Work = 60, Progress = 40, TaskType = "FixedDuration", Predecessor = "11FS-5" },
                new TaskInfoModel() { Id = 13, Name = "Foundation", StartDate = new DateTime(2022, 04, 04), EndDate = new DateTime(2019, 04, 28), Work = 60, Progress = 40, TaskType = "FixedDuration" },
                new TaskInfoModel() { Id = 14, Name = "Excavate for foundations", StartDate = new DateTime(2019, 04, 01), Duration = "2", ParentID = 13, Work = 60, Progress = 40, TaskType = "FixedDuration" },
                new TaskInfoModel() { Id = 15, Name = "Dig footer", StartDate = new DateTime(2019, 04, 04), Duration = "2", ParentID = 13, Work = 60, Progress = 40, TaskType = "FixedDuration", Predecessor = "14FS + 1" },
                new TaskInfoModel() { Id = 16, Name = "Install plumbing grounds", StartDate = new DateTime(2019, 04, 08), Duration = "2", ParentID = 13, Work = 60, Progress = 40, TaskType = "FixedDuration", Predecessor = "15FS" }, new TaskInfoModel() { Id = 17, Name = "Framing", StartDate = new DateTime(2019, 04, 04), EndDate = new DateTime(2019, 04, 28), Work = 60, Progress = 40, TaskType = "FixedDuration" },
                new TaskInfoModel() { Id = 18, Name = "Add load-bearing structure", StartDate = new DateTime(2019, 04, 03), Duration = "2", ParentID = 17, Work = 60, Progress = 20, TaskType = "FixedDuration" },
                new TaskInfoModel() { Id = 19, Name = "Natural gas utilities", StartDate = new DateTime(2019, 04, 08), Duration = "3", ParentID = 17, Work = 60, Progress = 40, TaskType = "FixedDuration", Predecessor = "18" },
                new TaskInfoModel() { Id = 20, Name = "Electrical utilities", StartDate = new DateTime(2022, 04, 01), Duration = "2", ParentID = 17, Work = 60, Progress = 50, TaskType = "FixedWork", Predecessor = "19FS + 1" },
                new TaskInfoModel() { Id = 21, Name = "Plumbing test", StartDate = new DateTime(2019, 04, 04), Duration = "3", Work = 60, Progress = 50, TaskType = "FixedWork" },
                new TaskInfoModel() { Id = 22, Name = "Electrical test", StartDate = new DateTime(2019, 04, 04), Duration = "3", Work = 60, Progress = 50, TaskType = "FixedWork", Predecessor = "21" },
                new TaskInfoModel() { Id = 23, Name = "First floor initiation", StartDate = new DateTime(2019, 04, 06), Duration = "3", Work = 60, Progress = 50, TaskType = "FixedWork" },
                new TaskInfoModel() { Id = 24, Name = "Interior work", StartDate = new DateTime(2019, 04, 04), Duration = "1", Work = 60, Progress = 50, TaskType = "FixedWork", Predecessor = "23" },
                new TaskInfoModel() { Id = 25, Name = "First floor tile work initation", StartDate = new DateTime(2019, 04, 10), Duration = "4", Work = 60, Progress = 50, TaskType = "FixedWork" },
                new TaskInfoModel() { Id = 26, Name = "Tile test", StartDate = new DateTime(2019, 04, 04), Duration = "3", Work = 60, Progress = 50, TaskType = "FixedWork" },
                new TaskInfoModel() { Id = 27, Name = "Second floor initiation", StartDate = new DateTime(2019, 04, 15), Duration = "3", Work = 60, Progress = 50, TaskType = "FixedWork" },
                new TaskInfoModel() { Id = 28, Name = "Second floor tile work initation", StartDate = new DateTime(2019, 04, 06), Duration = "3", Work = 60, Progress = 50, TaskType = "FixedWork", Predecessor = "27FS - 1" },
                new TaskInfoModel() { Id = 29, Name = "Exterior work initation", StartDate = new DateTime(2019, 04, 12), Duration = "3", Work = 60, Progress = 50, TaskType = "FixedWork" },
                new TaskInfoModel() { Id = 30, Name = "Building test", StartDate = new DateTime(2019, 04, 08), Duration = "3", Work = 60, Progress = 50, TaskType = "FixedWork" }
            };
            return Tasks;
        }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtLyCtZAKaGvrwhg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Managing resource assignments

In the Gantt Chart, you can enable dynamic resources assignments by setting the [AllowEditing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEditSettings.html#Syncfusion_Blazor_Gantt_GanttEditSettings_AllowEditing) properties to **true** in the [GanttEditSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEditSettings.html) component. These actions can be performed using the following two methods:

### Through dialog box

In the resource tab of the [add/edit dialog box](https://blazor.syncfusion.com/documentation/gantt-chart/editing-tasks#dialog-editing) within the Gantt chart, resources can be both added and removed.

In the resource view, you can easily change task resources. If the dialog box's resource tab has multiple resources, you can add one resource, make individual changes, or remove assigned resources as needed, all done efficiently.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using BlazorGanttChart.Data

<SfGantt @ref="ganttInstance" DataSource="@TaskCollection" ViewType="Syncfusion.Blazor.Gantt.ViewType.ResourceView" Height="450px" Width="850px" TreeColumnIndex="1" WorkUnit="WorkUnit.Hour"
         Toolbar="@(new List<string>(){ "Add", "Edit", "Update", "Delete", "Cancel", "ExpandAll", "CollapseAll"})">
    <GanttTaskFields Id="@nameof(GanttModel.TaskInfoModel.Id)" Name="@nameof(GanttModel.TaskInfoModel.Name)" StartDate="@nameof(GanttModel.TaskInfoModel.StartDate)" EndDate="@nameof(GanttModel.TaskInfoModel.EndDate)" Duration="@nameof(GanttModel.TaskInfoModel.Duration)"
                     ParentID="@nameof(GanttModel.TaskInfoModel.ParentID)" Work="@nameof(GanttModel.TaskInfoModel.Work)" TaskType="@nameof(GanttModel.TaskInfoModel.TaskType)" Progress="@nameof(GanttModel.TaskInfoModel.Progress)">
    </GanttTaskFields>
    <GanttResource DataSource="ResourceCollection" Id="@nameof(GanttModel.ResourceInfoModel.Id)" Name="@nameof(GanttModel.ResourceInfoModel.Name)" MaxUnits="@nameof(GanttModel.ResourceInfoModel.MaxUnit)" TValue="GanttModel.TaskInfoModel" TResources="GanttModel.ResourceInfoModel"></GanttResource>
    <GanttAssignmentFields DataSource="AssignmentCollection" PrimaryKey="@nameof(GanttModel.AssignmentModel.PrimaryId)" TaskID="@nameof(GanttModel.AssignmentModel.TaskID)" ResourceID="@nameof(GanttModel.AssignmentModel.ResourceId)" Units="@nameof(GanttModel.AssignmentModel.Unit)" TValue="GanttModel.TaskInfoModel" TAssignment="GanttModel.AssignmentModel">
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
            public string Name { get; set; }
            public double MaxUnit { get; set; }
        }

        public class TaskInfoModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string TaskType { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string Duration { get; set; }
            public int Progress { get; set; }
            public int? ParentID { get; set; }
            public double? Work { get; set; }
        }

        public class AssignmentModel
        {
            public int PrimaryId { get; set; }
            public int TaskID { get; set; }
            public int ResourceId { get; set; }
            public double? Unit { get; set; }
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
                new AssignmentModel(){ PrimaryId=1, TaskID = 2 , ResourceId=1, Unit=70},
                new AssignmentModel(){ PrimaryId=2, TaskID = 3 , ResourceId=1, Unit=70},
                new AssignmentModel(){ PrimaryId=3, TaskID = 4 , ResourceId=3},
                new AssignmentModel(){ PrimaryId=4, TaskID = 6 , ResourceId=2},
                new AssignmentModel(){ PrimaryId=5, TaskID = 7 , ResourceId=4, Unit=30},
                new AssignmentModel(){ PrimaryId=6, TaskID = 8 , ResourceId=8},
                new AssignmentModel(){ PrimaryId=7, TaskID = 9 , ResourceId=11},
            };
            return assignments;
        }

        public static List<TaskInfoModel> GetTaskCollection()
        {
            return new List<TaskInfoModel>()
            {
                new TaskInfoModel() { Id = 1, Name = "Project initiation", StartDate = new DateTime(2021, 03, 28), EndDate = new DateTime(2021, 07, 28), TaskType ="FixedDuration", Work=128, Duration="4" },
                new TaskInfoModel() { Id = 2, Name = "Identify site location", StartDate = new DateTime(2021, 03, 29), Progress = 30, ParentID = 1, Duration="3", TaskType ="FixedDuration", Work=16 },
                new TaskInfoModel() { Id = 3, Name = "Perform soil test", StartDate = new DateTime(2021, 03, 29), ParentID = 1, Work=96, Duration="4", TaskType="FixedWork" },
                new TaskInfoModel() { Id = 4, Name = "Soil test approval", StartDate = new DateTime(2021, 03, 29), Duration = "4", Progress = 30, ParentID = 1, Work=16, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 5, Name = "Project estimation", StartDate = new DateTime(2021, 03, 29), EndDate = new DateTime(2021, 04, 2), TaskType="FixedDuration", Duration="4" },
                new TaskInfoModel() { Id = 6, Name = "Develop floor plan for estimation", StartDate = new DateTime(2021, 03, 29), Duration = "3", Progress = 30, ParentID = 5, Work=30, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 7, Name = "List materials", StartDate = new DateTime(2021, 04, 01), Duration = "3", Progress = 30, ParentID = 5, TaskType="FixedWork", Work=48 },
                new TaskInfoModel() { Id = 8, Name = "Estimation approval", StartDate = new DateTime(2021, 04, 01), Duration = "4", ParentID = 5, Work=60, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 9, Name = "Sign contract", StartDate = new DateTime(2021, 03, 31), EndDate = new DateTime(2021, 04, 01), Duration="4", TaskType="FixedWork", Work=24 },
            };
        }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjVeMXtKfDslelzg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Through method

You can manipulate task resources programmatically by using the following methods:

* [AddResourceAssignmentAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AddResourceAssignmentAsync__1___0_): Adds a new resource assignment to a task.
* [DeleteResourceAssignmentAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_DeleteResourceAssignmentAsync__1___0_): Removes a existing resource assignment from a task.
* [UpdateResourceAssignmentAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_UpdateResourceAssignmentAsync__1___0_): Updates an existing resource assignment for a task.

These methods offer a convenient way to efficiently manage task resources in your Gantt chart, allowing you to add, remove, and update resources as needed. In the following code snippet, when an external button is clicked, the following actions are performed: clicking the **Add Assignment** button adds resource ID 2 for task 9, the **Update Assignment** button updates the resource ID from 8 to 7 for task 9, and the **Delete Assignment** button removes the assigned resource 1 from task 3.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using BlazorGanttChart.Data

<button @onclick="AddAssignment">Add Assignment</button>
<button @onclick="UpdateAssignment">Update Assignment</button>
<button @onclick="DeleteAssignment">Delete Assignment</button>

<SfGantt @ref="ganttInstance" DataSource="@TaskCollection" ViewType="Syncfusion.Blazor.Gantt.ViewType.ResourceView" Height="450px" Width="850px" TreeColumnIndex="1" WorkUnit="WorkUnit.Hour"
         Toolbar="@(new List<string>(){ "Add", "Edit", "Update", "Delete", "Cancel", "ExpandAll", "CollapseAll"})">
    <GanttTaskFields Id="@nameof(GanttModel.TaskInfoModel.Id)" Name="@nameof(GanttModel.TaskInfoModel.Name)" StartDate="@nameof(GanttModel.TaskInfoModel.StartDate)" EndDate="@nameof(GanttModel.TaskInfoModel.EndDate)" Duration="@nameof(GanttModel.TaskInfoModel.Duration)"
                     ParentID="@nameof(GanttModel.TaskInfoModel.ParentID)" Work="@nameof(GanttModel.TaskInfoModel.Work)" TaskType="@nameof(GanttModel.TaskInfoModel.TaskType)" Progress="@nameof(GanttModel.TaskInfoModel.Progress)">
    </GanttTaskFields>
    <GanttResource DataSource="ResourceCollection" Id="@nameof(GanttModel.ResourceInfoModel.Id)" Name="@nameof(GanttModel.ResourceInfoModel.Name)" MaxUnits="@nameof(GanttModel.ResourceInfoModel.MaxUnit)" TValue="GanttModel.TaskInfoModel" TResources="GanttModel.ResourceInfoModel"></GanttResource>
    <GanttAssignmentFields DataSource="AssignmentCollection" PrimaryKey="@nameof(GanttModel.AssignmentModel.PrimaryId)" TaskID="@nameof(GanttModel.AssignmentModel.TaskID)" ResourceID="@nameof(GanttModel.AssignmentModel.ResourceId)" Units="@nameof(GanttModel.AssignmentModel.Unit)" TValue="GanttModel.TaskInfoModel" TAssignment="GanttModel.AssignmentModel">
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
        var record = new GanttModel.AssignmentModel() { PrimaryId = 8, TaskID = 9, ResourceId = 2 };
        await ganttInstance.AddResourceAssignmentAsync(record);
    }
    private async void UpdateAssignment()
    {
        var record = new GanttModel.AssignmentModel() { PrimaryId = 7, TaskID = 8, ResourceId = 7 };
        await ganttInstance.UpdateResourceAssignmentAsync(record);
    }
    private async void DeleteAssignment()
    {
        var record = new GanttModel.AssignmentModel() { TaskID = 3, ResourceId = 1 };
        await ganttInstance.DeleteResourceAssignmentAsync(record);
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
            public string Name { get; set; }
            public double MaxUnit { get; set; }
        }

        public class TaskInfoModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string TaskType { get; set; }
            public DateTime StartDate { get; set; }
            public DateTime? EndDate { get; set; }
            public string Duration { get; set; }
            public int Progress { get; set; }
            public int? ParentID { get; set; }
            public double? Work { get; set; }
        }

        public class AssignmentModel
        {
            public int PrimaryId { get; set; }
            public int TaskID { get; set; }
            public int ResourceId { get; set; }
            public double? Unit { get; set; }
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
                new AssignmentModel(){ PrimaryId=1, TaskID = 2 , ResourceId=1, Unit=70},
                new AssignmentModel(){ PrimaryId=2, TaskID = 3 , ResourceId=1, Unit=70},
                new AssignmentModel(){ PrimaryId=3, TaskID = 4 , ResourceId=3},
                new AssignmentModel(){ PrimaryId=4, TaskID = 6 , ResourceId=2},
                new AssignmentModel(){ PrimaryId=5, TaskID = 7 , ResourceId=4, Unit=30},
                new AssignmentModel(){ PrimaryId=6, TaskID = 8 , ResourceId=8},
                new AssignmentModel(){ PrimaryId=7, TaskID = 9 , ResourceId=11},
            };
            return assignments;
        }

        public static List<TaskInfoModel> GetTaskCollection()
        {
            return new List<TaskInfoModel>()
            {
                new TaskInfoModel() { Id = 1, Name = "Project initiation", StartDate = new DateTime(2021, 03, 28), EndDate = new DateTime(2021, 07, 28), TaskType ="FixedDuration", Work=128, Duration="4" },
                new TaskInfoModel() { Id = 2, Name = "Identify site location", StartDate = new DateTime(2021, 03, 29), Progress = 30, ParentID = 1, Duration="3", TaskType ="FixedDuration", Work=16 },
                new TaskInfoModel() { Id = 3, Name = "Perform soil test", StartDate = new DateTime(2021, 03, 29), ParentID = 1, Work=96, Duration="4", TaskType="FixedWork" },
                new TaskInfoModel() { Id = 4, Name = "Soil test approval", StartDate = new DateTime(2021, 03, 29), Duration = "4", Progress = 30, ParentID = 1, Work=16, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 5, Name = "Project estimation", StartDate = new DateTime(2021, 03, 29), EndDate = new DateTime(2021, 04, 2), TaskType="FixedDuration", Duration="4" },
                new TaskInfoModel() { Id = 6, Name = "Develop floor plan for estimation", StartDate = new DateTime(2021, 03, 29), Duration = "3", Progress = 30, ParentID = 5, Work=30, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 7, Name = "List materials", StartDate = new DateTime(2021, 04, 01), Duration = "3", Progress = 30, ParentID = 5, TaskType="FixedWork", Work=48 },
                new TaskInfoModel() { Id = 8, Name = "Estimation approval", StartDate = new DateTime(2021, 04, 01), Duration = "4", ParentID = 5, Work=60, TaskType="FixedWork" },
                new TaskInfoModel() { Id = 9, Name = "Sign contract", StartDate = new DateTime(2021, 03, 31), EndDate = new DateTime(2021, 04, 01), Duration="4", TaskType="FixedWork", Work=24 },
            };
        }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDhIiNjAzZTBGeeH?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Limitations

* The resource view in the Gantt Chart does not support assigning multiple resources to a single task.
* Editing of resource records(parent record) is not supported in the resource view of the Gantt Chart.
* CRUD operations are not supported when the [TaskMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_TaskMode) is set to [Manual](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.ScheduleMode.html#Syncfusion_Blazor_Gantt_ScheduleMode_Manual) or [Custom](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.ScheduleMode.html#Syncfusion_Blazor_Gantt_ScheduleMode_Custom) in the resource view.

## See also

* [Resource Unit](https://blazor.syncfusion.com/documentation/gantt-chart/resources.html#resource-unit)
* [Configure task duration using Work](https://blazor.syncfusion.com/documentation/gantt-chart/work)
* [Custom taskbar styling using template](https://blazor.syncfusion.com/documentation/gantt-chart/resources.html#binding-data-source-for-resource-collection-and-assigning-resource-to-tasks)


