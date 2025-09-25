---
layout: post
title: Scrolling in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about scrolling in Syncfusion Blazor Gantt Chart component and much more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Scrolling in Blazor Gantt Component

The scrollbar will be displayed in the Gantt when the content exceeds the element [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_Width) or [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_Height). The vertical and horizontal scrollbars will be displayed based on the following criteria:

The vertical scrollbar appears when the total height of rows present in the Gantt exceeds its element height. The horizontal scrollbar appears when the sum of the columns' width exceeds the Gantt element width. The [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_Height) and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_Width) are used to set the Gantt height and width, respectively.

N> The default value for [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_Height) and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_Width) is **auto**.

## Set width and height

To specify the [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_Height) and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_Width) of the scroller in the pixel, set the pixel value to a number.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt @ref="Gantt" DataSource="@TaskCollection" Height="450px" Width="900px" Toolbar="@(new List<string>() { "Add","Edit" })">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskID" Width="100"></GanttColumn>
        <GanttColumn Field="TaskName" Width="250" AllowEditing="false"></GanttColumn>
        <GanttColumn Field="StartDate"></GanttColumn>
        <GanttColumn Field="Duration"></GanttColumn>
        <GanttColumn Field="Progress"></GanttColumn>
    </GanttColumns>
    <GanttEditSettings AllowEditing="true" AllowAdding="true"></GanttEditSettings>
</SfGantt>

@code{
    public SfGantt<TaskData> Gantt;
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
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 08), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 04, 08), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 40, ParentID = 5 },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0", Progress = 30, ParentID = 5 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjLeNEVIVpUHKMmN?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Responsive with the parent container

Specify the [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_Height) and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_Width) as **100%** to make the Gantt element fill its parent container. Setting the `Height` to **100%** requires the Gantt parent element to have explicit height or you can use viewport height to set explicit height based on the browser layout.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<div class="gantt">
    <SfGantt DataSource="@TaskCollection" Toolbar="@(new List<string>() { "Add" })" Height="100%" Width="100%">
        <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
        </GanttTaskFields>
        <GanttEditSettings AllowAdding="true"></GanttEditSettings>
    </SfGantt>
</div>
<style>
    .gantt {
        height: 100vh;
        width: 100vw;
        border: 2px solid;
        padding: 20px;
        resize: both;
        overflow: auto;
    }
</style>
@code{
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
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 08), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 04, 08), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 40, ParentID = 5 },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0", Progress = 30, ParentID = 5 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNVotaVoLTJVFSsi?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Auto scroll to taskbar

Taskbar that is not visible in the viewport can be auto scrolled to make it visible when selecting the row, by setting the [ScrollToTaskbarOnClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ScrollToTaskbarOnClick) property to true.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px" ScrollToTaskbarOnClick="true">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
</SfGantt>

@code {
    public List<TaskData> TaskCollection { get; set; }
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
        new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 02), EndDate = new DateTime(2022, 04, 08)},
        new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 02), Duration = "4", Progress = 30, ParentID = 1 },
        new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 02), Duration = "4", Progress = 40, ParentID = 1 },
        new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 02), Duration = "5", Progress = 30, ParentID = 1 },
        new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 12), EndDate = new DateTime(2022, 05, 17) },
        new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 12), Duration = "3", Progress = 30, ParentID = 5 },
        new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 05, 13), Duration = "3", Progress = 40, ParentID = 5 },
        new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 05, 16), Duration = "0", Progress = 30, ParentID = 5 }
    };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXBejaVoVfoSMdbx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Scroll the content by external button

This section shows you how to invoke a [ScrollIntoViewAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ScrollIntoViewAsync_System_Int32_System_Int32_) method to scroll the Gantt chart content programmatically by passing column index or row index as parameter.

 {% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Buttons

ColumnIndex : <input @bind-value = "@ColumnIndex" />
<SfButton @onclick="Scroll" Content="Scroll Horizontally"></SfButton>
<br><br>
RowIndex : <input @bind-value = "@RowIndex" />
<SfButton @onclick="Scroll" Content="Scroll Vertically"></SfButton>
<SfGantt @ref="Gantt" ID="Gantt" DataSource="@TaskCollection" 
    EnableVirtualization="true" EnableColumnVirtualization="true"  Height="350px" Width="650px">
    <GanttTaskFields Id="ProjectId" Name="ProjectName" StartDate="ProjectStartDate" EndDate="ProjectEndDate" Duration="ProjectDuration" Progress="ProjectProgress" Dependency="Predecessor" ParentID="ParentID">
    </GanttTaskFields>
     <GanttColumns>
        <GanttColumn Field="ProjectId" HeaderText="Task ID"></GanttColumn>
        <GanttColumn Field="ProjectName" HeaderText="Task Name"> </GanttColumn>
        <GanttColumn Field="ProjectStartDate" HeaderText="Start Date"></GanttColumn>
        <GanttColumn Field="ProjectEndDate" HeaderText="End Date"></GanttColumn>
        <GanttColumn Field="ProjectDuration" HeaderText="Duration"></GanttColumn>
        <GanttColumn Field="Field1" HeaderText="Rebounds"></GanttColumn>
        <GanttColumn Field="FIELD2" HeaderText="Year"></GanttColumn>
        <GanttColumn Field="FIELD3" HeaderText="Stint"></GanttColumn>
        <GanttColumn Field="FIELD4" HeaderText="TMID"> </GanttColumn>
        <GanttColumn Field="FIELD5" HeaderText="LGID"></GanttColumn>
        <GanttColumn Field="FIELD6" HeaderText="GP"></GanttColumn>
        <GanttColumn Field="Field7" HeaderText="GS"></GanttColumn>
        <GanttColumn Field="Field8" HeaderText="Minutes"></GanttColumn>
        <GanttColumn Field="Field9" HeaderText="Points"></GanttColumn>
        <GanttColumn Field="Field10" HeaderText="ORebounds"></GanttColumn>
        <GanttColumn Field="Field11" HeaderText="DRebounds"></GanttColumn>
    </GanttColumns>
</SfGantt>
@code {
    public SfGantt<TaskData> Gantt;
    public List<TaskData> TaskCollection { get; set; }

    public int ColumnIndex { get; set; } = -1;
    public int RowIndex { get; set; } = -1;
    protected override void OnInitialized()
    {
        this.TaskCollection = VirtualData.GetTreeVirtualData();
    }
    public async Task Scroll()
    {
        await Gantt.ScrollIntoViewAsync(ColumnIndex, RowIndex);
    }
    public class VirtualData
    {
        public static List<TaskData> GetTreeVirtualData()
        {
            string[] Names = new string[] { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD", "HANAR", "CHOPS", "RICSU", "WELLI", "HILAA", "ERNSH", "CENTC", "OTTIK", "QUEDE", "RATTC", "ERNSH", "FOLKO", "BLONP", "WARTH", "FRANK", "GROSR", "WHITC", "WARTH", "SPLIR", "RATTC", "QUICK", "VINET", "MAGAA", "TORTU", "MORGK", "BERGS", "LEHMS", "BERGS", "ROMEY", "ROMEY", "LILAS", "LEHMS", "QUICK", "QUICK", "RICAR", "REGGC", "BSBEV", "COMMI", "QUEDE", "TRADH", "TORTU", "RATTC", "VINET", "LILAS", "BLONP", "HUNGO", "RICAR", "MAGAA", "WANDK", "SUPRD", "GODOS", "TORTU", "OLDWO", "ROMEY", "LONEP", "ANATR", "HUNGO", "THEBI", "DUMON", "WANDK", "QUICK", "RATTC", "ISLAT", "RATTC", "LONEP", "ISLAT", "TORTU", "WARTH", "ISLAT", "PERIC", "KOENE", "SAVEA", "KOENE", "BOLID", "FOLKO", "FURIB", "SPLIR", "LILAS", "BONAP", "MEREP", "WARTH", "VICTE", "HUNGO", "PRINI", "FRANK", "OLDWO", "MEREP", "BONAP", "SIMOB", "FRANK", "LEHMS", "WHITC", "QUICK", "RATTC", "FAMIA" };
            List<TaskData> DataCollection = new List<TaskData>();
            var x = 0;
            for (var i = 1; i <= 100; i++)
            {
                TaskData Parent = new TaskData()
                {
                    ProjectId = ++x,
                    ProjectName = "Task " + x,
                    ProjectStartDate = new DateTime(2022, 1, 9),
                    ProjectEndDate = new DateTime(2022, 1, 13),
                    ProjectDuration = "10",
                    ProjectProgress =  x + 20,
                    ParentID = null,
                    Predecessor = null,
                };
                DataCollection.Add(Parent);
                for (var j = 1; j <= 50; j++)
                {
                    DataCollection.Add(new TaskData()
                    {
                        ProjectId = ++x,
                        ProjectName = "Task " + x,
                        ProjectStartDate = new DateTime(2022, 1, 9),
                        ProjectEndDate = new DateTime(2022, 1, 13),
                        ProjectDuration = "10",
                        ProjectProgress = x + 20,
                        ParentID = Parent.ProjectId,
                        Predecessor = i + "FS",
                        Field1 = Names[x % Names.Length],
                        FIELD2 = 1967 + x + 10,
                        FIELD3 = 395 + x + 10,
                        FIELD4 = 87 + x + 10,
                        FIELD5 = 410 + x + 10,
                        FIELD6 = 67 + x + 10,
                        Field7 = (x + 10 * 100),
                        Field8 = (x + 10 * 10),
                        Field9 = (x + 10 * 10),
                        Field10 = (x + 10 * 100),
                        Field11 = (x + 10 * 100),
                        Field12 = (x + 10 * 1000),
                    });
                }
            }
            return DataCollection;
        }
    }
    public class TaskData
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime? ProjectStartDate { get; set; }
        public DateTime? ProjectEndDate { get; set; }
        public string ProjectDuration { get; set; }
        public int ProjectProgress { get; set; }
        public int? ParentID { get; set; }
        public string Predecessor { get; set; }
        public string Field1 { get; set; }
        public int FIELD2 { get; set; }
        public int FIELD3 { get; set; }
        public int FIELD4 { get; set; }
        public int FIELD5 { get; set; }
        public int FIELD6 { get; set; }
        public int Field7 { get; set; }
        public int Field8 { get; set; }
        public int Field9 { get; set; }
        public int Field10 { get; set; }
        public int Field11 { get; set; }
        public int Field12 { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXhSNEsGpuhjkdoy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

* You can also programmatically scroll to the taskbar using  [ScrollToTaskbarAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ScrollToTaskbarAsync_System_Int32_) method and scroll to the timeline using [ScrollToTimelineAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ScrollToTimelineAsync_System_DateTime_).