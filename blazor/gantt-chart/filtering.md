---
layout: post
title: Filtering in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about Filtering in Syncfusion Blazor Gantt Chart component and much more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Filtering in Blazor Gantt Component

Filtering allows you to view specific or related records based on defined criteria. The Gantt component supports options like filter menu, Excel-like filtering, and toolbar search to narrow down visible data.

To enable filtering, set [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AllowFiltering) to **true** in the Gantt configuration. You can define filter options using `GanttFilterSettings` and configure toolbar search using `GanttSearchSettings` property.

> The  filtering UI is rendered based on the column type, allowing data to be filtered using appropriate operators.
> The filter menu is enabled by default. To disable the filtering option for a specific column, set the `AllowFiltering` property of the `GanttColumn` to **false**.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Width="900px" AllowFiltering="true">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
</SfGantt>

@code{
    private List<TaskData> TaskCollection { get; set; }
    
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    private static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 7), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentID = 1, },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 10), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentID = 5, },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentID = 5, },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentID = 5, }
        };
        return Tasks;
    }

    public class TaskData
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentID { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDLIWDNALLvvHCTa?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Filter hierarchy modes

The Blazor Gantt component supports multiple filtering modes, which can be configured using the [GanttFilterSettings.HierarchyMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttFilterSettings.html#Syncfusion_Blazor_Gantt_GanttFilterSettings_HierarchyMode) property. The available modes are:

- **Parent**: This is the default mode. Filtered records are displayed along with their parent records. If no parent exists, only the filtered records are shown.

- **Child**: Displays filtered records along with their child records. If no child exists, only the filtered records are shown.

- **Both**: Displays filtered records along with both parent and child records. If neither exists, only the filtered records are shown.

- **None**: Displays only the filtered records without any parent or child context.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.DropDowns

<label>Hierarchy Mode</label>
<SfDropDownList TValue="string" TItem="DropDownItem" Width="150px" DataSource="@filterModesData" Placeholder="Select Mode" @bind-Value="@SelectedMode">
    <DropDownListFieldSettings Text="mode" Value="id" />
    <DropDownListEvents TValue="string" TItem="DropDownItem" ValueChange="OnModeChange" />
</SfDropDownList>

<SfGantt @ref="GanttObject" DataSource="@TaskCollection" Height="450px" Width="900px" AllowFiltering="true">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID" />
    <GanttFilterSettings HierarchyMode="@HierarchyMode" />
</SfGantt>

@code {
    private SfGantt<TaskData> GanttObject;
    public List<TaskData> TaskCollection { get; set; }
    public string SelectedMode { get; set; } = "None";
    public Syncfusion.Blazor.Gantt.FilterHierarchyMode HierarchyMode { get; set; } = Syncfusion.Blazor.Gantt.FilterHierarchyMode.None;

    public List<DropDownItem> filterModesData = new List<DropDownItem>
    {
        new DropDownItem { id = "None", mode = "None" },
        new DropDownItem { id = "Parent", mode = "Parent" },
        new DropDownItem { id = "Child", mode = "Child" },
        new DropDownItem { id = "Both", mode = "Both" },
    };

    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
    }

   private void OnModeChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs< string, DropDownItem> args)
   {
        SelectedMode = args.Value;
        HierarchyMode = Enum.Parse<Syncfusion.Blazor.Gantt.FilterHierarchyMode>(SelectedMode);
        GanttObject.ClearFilteringAsync();
    }

    private List<TaskData> GetTaskCollection()
    {
        return new List<TaskData>
        {
            new TaskData { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 07) },
            new TaskData { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentID = 1 },
            new TaskData { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 10) },
            new TaskData { TaskID = 6, TaskName = "Develop floor plan", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentID = 5 },
            new TaskData { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentID = 5 },
            new TaskData { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentID = 5 }
        };
    }

    public class TaskData
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentID { get; set; }
    }

    public class DropDownItem
    {
        public string id { get; set; }
        public string mode { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZreMDZgBRIFoGWX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Initial filter

To apply filtering during the initial render of the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Gantt component, define the filter conditions using a collection of `PredicateModel` objects within the [GanttFilterSettings.Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttFilterSettings.html#Syncfusion_Blazor_Gantt_GanttFilterSettings_Columns) property.

The following sample demonstrates how to apply an initial filter where **TaskName** starts with **Identify** and **TaskID** equals **2**, using a `Predicate` condition set to **and**.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Grids

<SfGantt DataSource="@TaskCollection" Height="450px" Width="900px" AllowFiltering="true">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttFilterSettings Columns="@FilterColumns"></GanttFilterSettings>
</SfGantt>

@code {
    private List<TaskData> TaskCollection { get; set; }
    public List<PredicateModel> FilterColumns { get; set; } = new List<PredicateModel>
    {
        new PredicateModel() { Field = "TaskName", MatchCase = false, Operator = Operator.StartsWith, Predicate = "and", Value = "Identify" },
        new PredicateModel() { Field = "TaskID", MatchCase = false, Operator = Operator.Equal, Predicate = "and", Value = 2 }
    };

    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    private List<TaskData> GetTaskCollection()
    {
        return new List<TaskData>
        {
            new TaskData { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 07) },
            new TaskData { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentID = 1 },
            new TaskData { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 10) },
            new TaskData { TaskID = 6, TaskName = "Develop floor plan", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentID = 5 },
            new TaskData { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentID = 5 },
            new TaskData { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentID = 5 }
        };
    }

    public class TaskData
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentID { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/htLosjNKhcBcgFMa?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Filter operators

Filter operators can be set using the [GanttFilterSettings.Columns.Operator](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttFilterSettings.html#Syncfusion_Blazor_Gantt_GanttFilterSettings_Operators) property to define the comparison logic for each column.

The available operators and their supported data types are:

| Operator             | Description                                         | Supported Types                  |
|----------------------|-----------------------------------------------------|----------------------------------|
| startswith           | Matches values beginning with the specified value.   | String                           |
| endswith             | Matches values ending with the specified value.      | String                           |
| contains             | Matches values that include the specified value.     | String                           |
| equal                | Matches values exactly equal to the specified value. | String, Number, Boolean, Date    |
| notequal             | Matches values not equal to the specified value.     | String, Number, Boolean, Date    |
| greaterthan          | Matches values greater than the specified value.    | Number, Date                     |
| greaterthanorequal   | Matches values greater than or equal to the value.  | Number, Date                     |
| lessthan             | Matches values less than the specified value.       | Number, Date                     |
| lessthanorequal      | Matches values less than or equal to the value.     | Number, Date                     |

N> By default, the `GanttFilterSettings.Columns.Operator` value is `equal`

## Diacritics

By default, the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Gantt component ignores diacritic characters during filtering. To enable filtering with diacritic sensitivity, set the [GanttFilterSettings.IgnoreAccent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttFilterSettings.html#Syncfusion_Blazor_Gantt_GanttFilterSettings_IgnoreAccent) property to **true**.

The following sample demonstrates this behavior: when filtering the **TaskName** column, entries containing diacritic characters (e.g., “Próject”, “Projéct”) will be matched if you enter the base text **Project**.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="900px" AllowFiltering="true">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttFilterSettings IgnoreAccent="true"></GanttFilterSettings>
</SfGantt>

@code {
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
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Projéct initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 21), },
            new TaskData() { TaskId = 2, TaskName = "Identify site locàtion", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perförm soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil tëst appröval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Próject estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 04, 21), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 40, ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0", Progress = 30, ParentId = 5 },
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNBoMXDALFmDenyb?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Filtering a specific column by method

You can filter columns dynamically in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Gantt component by using the [FilterByColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_FilterByColumnAsync_System_String_System_String_System_String_) method.

The example below demonstrates how to filter the **TaskName** and **TaskID** columns using a single value. Filtering is triggered by an external button click, which invokes the `FilterByColumnAsync` method.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Buttons

<SfButton style="margin-bottom:20px" @onclick="Filter">Filter Column</SfButton>
<SfGantt @ref="GanttInstance" DataSource="@TaskCollection" Height="450px" Width="900px" AllowFiltering="true">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
</SfGantt>

@code{
    public SfGantt<TaskData> GanttInstance;
    private List<TaskData> TaskCollection { get; set; }

    public async void Filter()
    {
        await this.GanttInstance.FilterByColumnAsync("TaskName", "startswith", "Iden", "or", true, false);
    }
    
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    private static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 7), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentID = 1, },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 10), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentID = 5, },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentID = 5, },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentID = 5, }
        };
        return Tasks;
    }

    public class TaskData
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentID { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjLSMDXKrEDLyEcy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Clear filtered columns

You can clear all the filtering conditions applied in the Gantt component by using the [ClearFilteringAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ClearFilteringAsync) method.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<SfButton style="margin-bottom:20px" @onclick="ClearFilter">Clear Filter</SfButton>
<SfGantt @ref="GanttInstance" DataSource="@TaskCollection" Height="450px" Width="700px" AllowFiltering="true">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttFilterSettings Columns="@FilterColumns"></GanttFilterSettings>
</SfGantt>

@code{
    public SfGantt<TaskData> GanttInstance;
    private List<TaskData> TaskCollection { get; set; }
    public List<PredicateModel> FilterColumns { get; set; } = new List<PredicateModel>
    {
        new PredicateModel() { Field = "TaskName", MatchCase = false, Operator = Operator.StartsWith, Predicate = "and", Value = "Identify" },
        new PredicateModel() { Field = "TaskID", MatchCase = false, Operator = Operator.Equal, Predicate = "and", Value = 2 }
    };
    
    public async Task ClearFilter()
    {
        await GanttInstance.ClearFilteringAsync();
    }
   
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    private static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 7), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentID = 1, },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 10), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentID = 5, },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentID = 5, },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentID = 5, }
        };
        return Tasks;
    }

    public class TaskData
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentID { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNheWDXKBOdpyoxD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Enable different filter for a column

You can enable different filter types for individual columns in the Syncfusion<sup style="font-size:70%">&reg;</sup> Gantt component by setting the[GanttColumn.FilterSettings.Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.FilterSettings.html#Syncfusion_Blazor_Grids_FilterSettings_Type) property.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Grids

<div style="margin-bottom:20px">
    <label style="font-weight:bold">Select Column</label>
    <SfDropDownList TValue="string" TItem="string" Width="130px" Placeholder="Eg: TaskID" DataSource="@ColumnData">
        <DropDownListEvents TValue="string" TItem="string" ValueChange="onFieldChange"></DropDownListEvents>
    </SfDropDownList>

    <label style="font-weight:bold">Select Filter Type</label>
    <SfDropDownList TValue="string" TItem="string" Width="130px" Placeholder="Eg: Menu" Enabled="@flag" DataSource="@LocalData">
        <DropDownListEvents TValue="string" TItem="string" ValueChange="onTypeChange"></DropDownListEvents>
    </SfDropDownList>
</div>
<SfGantt @ref="GanttInstance" DataSource="@TaskCollection" Height="450px" Width="100%" AllowFiltering="true">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID" />
    <GanttColumns>
        <GanttColumn Field="TaskID" HeaderText="Task ID" Width="100" FilterSettings="@TaskIDFilterSettings" />
        <GanttColumn Field="TaskName" HeaderText="Task Name" Width="150" FilterSettings="@TaskNameFilterSettings" />
        <GanttColumn Field="StartDate" HeaderText="Start Date" Width="120" Format="d" FilterSettings="@StartDateFilterSettings" />
        <GanttColumn Field="EndDate" HeaderText="End Date" Width="120" Format="d" FilterSettings="@EndDateFilterSettings" />
        <GanttColumn Field="Duration" HeaderText="Duration" Width="100" FilterSettings="@DurationFilterSettings" />
        <GanttColumn Field="Progress" HeaderText="Progress" Width="100" FilterSettings="@ProgressFilterSettings" />
    </GanttColumns>
    <GanttFilterSettings FilterType="Syncfusion.Blazor.Gantt.FilterType.Menu"></GanttFilterSettings>
</SfGantt>

@code {
    public SfGantt<TaskData> GanttInstance;
    private List<TaskData> TaskCollection { get; set; } = GetTaskCollection();
    public bool flag = false;
    public string SelectedColumn { get; set; }
    public string SelectedOperator { get; set; }
    List<string> LocalData = new List<string>() { "Menu", "Excel" };
    List<string> ColumnData = new List<string>() { "TaskID", "TaskName", "StartDate", "EndDate", "Duration", "Progress", "ParentID" };

    // Filter settings for each column.
    FilterSettings TaskIDFilterSettings = new FilterSettings { Type = Syncfusion.Blazor.Grids.FilterType.Menu };
    FilterSettings TaskNameFilterSettings = new FilterSettings { Type = Syncfusion.Blazor.Grids.FilterType.Menu };
    FilterSettings StartDateFilterSettings = new FilterSettings { Type = Syncfusion.Blazor.Grids.FilterType.Menu };
    FilterSettings EndDateFilterSettings = new FilterSettings { Type = Syncfusion.Blazor.Grids.FilterType.Menu };
    FilterSettings DurationFilterSettings = new FilterSettings { Type = Syncfusion.Blazor.Grids.FilterType.Menu };
    FilterSettings ProgressFilterSettings = new FilterSettings { Type = Syncfusion.Blazor.Grids.FilterType.Menu };
    FilterSettings ParentIDFilterSettings = new FilterSettings { Type = Syncfusion.Blazor.Grids.FilterType.Menu };

    public void onFieldChange(ChangeEventArgs<string, string> args)
    {
        SelectedColumn = args.Value;
        flag = true;
    }

    public async Task onTypeChange(ChangeEventArgs<string, string> args)
    {
        SelectedOperator = args.Value;
        await onSingleValueFilter();
    }

    public async Task onSingleValueFilter()
    {
        Enum.TryParse(SelectedOperator, out Syncfusion.Blazor.Grids.FilterType filterType);

        switch (SelectedColumn)
        {
            case "TaskID":
                TaskIDFilterSettings.Type = filterType;
                break;
            case "TaskName":
                TaskNameFilterSettings.Type = filterType;
                break;
            case "StartDate":
                StartDateFilterSettings.Type = filterType;
                break;
            case "EndDate":
                EndDateFilterSettings.Type = filterType;
                break;
            case "Duration":
                DurationFilterSettings.Type = filterType;
                break;
            case "Progress":
                ProgressFilterSettings.Type = filterType;
                break;
        }

        await GanttInstance.RefreshAsync();
     }

    private static List<TaskData> GetTaskCollection()
    {
        return new List<TaskData>
        {
            new TaskData { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 07) },
            new TaskData { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentID = 1 },
            new TaskData { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 10) },
            new TaskData { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentID = 5 },
            new TaskData { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentID = 5 },
            new TaskData { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentID = 5 }
        };
    }

    public class TaskData
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentID { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXrSijtKAOZnzpjS?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Get filtered records

You can retrieve filtered records from the Gantt component using the [GetFilteredRecordsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_GetFilteredRecordsAsync) method. 

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<div style="margin-bottom: 20px;">
    <SfButton OnClick="click" CssClass="e-primary" style="margin-right: 10px;">Get Filtered Records</SfButton>
    <SfButton OnClick="clear" CssClass="e-danger">Clear Filters</SfButton>
</div>

@if (!string.IsNullOrEmpty(message))
{
    <div style="margin-bottom: 20px; color: red; text-align: center;">
        <strong>@message</strong>
    </div>
}

<SfGantt @ref="GanttInstance" DataSource="@TaskCollection" Height="450px" Width="100%" AllowFiltering="true" ProjectStartDate="@(new DateTime(2022, 01, 02))" ProjectEndDate="@(new DateTime(2022, 01, 15))">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID" />
    <GanttFilterSettings FilterType="@CurrentFilterType"></GanttFilterSettings>
    <GanttEvents Filtering="FilteringHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

@if (showRecords)
{
    <h3 style="margin-top: 30px;">Filtered Records</h3>
    <SfGantt DataSource="@FilteredTasks" Height="450px" Width="100%" ProjectStartDate="@(new DateTime(2022, 01, 02))" ProjectEndDate="@(new DateTime(2022, 01, 15))">
        <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID" />
    </SfGantt>
}

@code {
    public SfGantt<TaskData> GanttInstance;
    private List<TaskData> TaskCollection { get; set; } = GetTaskCollection();
    public List<TaskData> FilteredTasks { get; set; } = new();
    public bool showRecords = false;
    public string message = string.Empty;
    public bool flag = false;

    public Syncfusion.Blazor.Gantt.FilterType CurrentFilterType { get; set; } = Syncfusion.Blazor.Gantt.FilterType.Menu;

    public async Task click()
    {
        if (flag)
        {
            var filteredRecords = await GanttInstance.GetFilteredRecordsAsync();
            FilteredTasks = filteredRecords.Cast<TaskData>().ToList();
            showRecords = true;
            message = string.Empty;
        }
        else
        {
            showRecords = false;
            message = "No Records is filtered ";
        }
    }

    public void FilteringHandler(Syncfusion.Blazor.Grids.FilteringEventArgs args)
    {
        flag = args.FilterPredicates != null && args.FilterPredicates.Any();
    }

    public async Task clear()
    {
        await GanttInstance.ClearFilteringAsync();
        showRecords = false;
        message = string.Empty;
        flag = false;
    }

    private static List<TaskData> GetTaskCollection()
    {
        return new List<TaskData>
        {
            new TaskData { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 07), Duration = "3", Progress = 50 },
            new TaskData { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentID = 1 },
            new TaskData { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 10), Duration = "6", Progress = 60 },
            new TaskData { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentID = 5 },
            new TaskData { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentID = 5 },
            new TaskData { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentID = 5 }
        };
    }

    public class TaskData
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentID { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDrSCDNSodAFQiMa?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customize filtering action

You can customize the filtering behavior in the Gantt component using the [FilterDialogOpening](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_FilterDialogOpening), [FilterDialogOpened](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_FilterDialogOpened), [Filtering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_Filtering), and [Filtered](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_Filtered) events.

The following `Filtering` event cancels the filter action for the **TaskName** column.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@page "/"
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids

@if (Show)
{
    <div style="text-align: center; color: red">
        <span>@BeginMessage</span>
        <br /><br />
        <span>@CompleteMessage</span>
    </div>
    <br />
}

<SfGantt @ref="Gantt" DataSource="@TaskCollection" AllowFiltering="true" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttFilterSettings FilterType="Syncfusion.Blazor.Gantt.FilterType.Menu"></GanttFilterSettings>
    <GanttEvents TValue="TaskData" Filtering="FilteringHandler" Filtered="FilteredHandler" FilterDialogOpening="FilterDialogOpeningHandler">
    </GanttEvents>
    <GanttColumns>
        <GanttColumn Field="TaskId" HeaderText="Task ID" Width="100"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Task Name" Width="200"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration" Width="120"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date" Width="150" Format="d" Type="Syncfusion.Blazor.Grids.ColumnType.DateOnly"></GanttColumn>
        <GanttColumn Field="Progress" HeaderText="Progress" Width="100"></GanttColumn>
    </GanttColumns>
</SfGantt>

@code {
    private SfGantt<TaskData> Gantt;
    private List<TaskData> TaskCollection { get; set; } = new();
    private bool Show = false;
    private string BeginMessage = string.Empty;
    private string CompleteMessage = string.Empty;

    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
    }

    public Task FilteringHandler(Syncfusion.Blazor.Grids.FilteringEventArgs args)
    {
        Show = true;
        if (args.ColumnName == "TaskName")
        {
            args.Cancel = true;
            BeginMessage = "Filtering is not allowed for TaskName column.";
        }
        else
        {
            BeginMessage = $"Filtering started for column: {args.ColumnName}";
        }
        return Task.CompletedTask;
    }

    public Task FilteredHandler(FilteredEventArgs args)
    {
        CompleteMessage = $"Filtering completed for column: {args.ColumnName}";
        return Task.CompletedTask;
    }

    public Task FilterDialogOpeningHandler(FilterDialogOpeningEventArgs args)
    {
        Show = true;
        BeginMessage = $"Filter dialog opened for column: {args.ColumnName}";
        return Task.CompletedTask;
    }

    public static List<TaskData> GetTaskCollection()
    {
        return new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 21) },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 04, 21) },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 40, ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0", Progress = 30, ParentId = 5 },
        };
    }

    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BtByCDDyykKaWddG?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
