---
layout: post
title: Virtualization in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about Virtualization in Syncfusion Blazor Gantt Chart component and more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Virtualization in Blazor Gantt Chart Component

Gantt Chart allows you to load a large amount of data without performance degradation.

## Row virtualization

The `EnableRowVirtualization` property allows you to render only the rows that are visible in the content viewport at load time. Rows are loaded while scrolling vertically, which optimizing memory usage by rendering only the rows that are visible, resulting in faster rendering and scrolling and efficiently handling large datasets in your Gantt chart without sacrificing performance or user experience. To enable row virtualization using this API, simply set [EnableRowVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_EnableRowVirtualization) to true.

The number of records displayed in the Gantt chart is determined implicitly by the height of the content area.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="100%" AutoCalculateDateScheduling="@autoCalculateDateScheduling" TreeColumnIndex="1" EnableRowVirtualization="true" ProjectStartDate="ProjectStartDate" ProjectEndDate="ProjectEndDate" Toolbar="@(new List<string>() { "Add", "Delete", "Edit", "ZoomIn", "ZoomOut" })" ScrollToTaskbarOnClick="true">
    <GanttLabelSettings LeftLabel="TaskName" TValue="TaskData"></GanttLabelSettings>
    <GanttTaskFields ParentID="ParentID" Work="Work" Id="ID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" TaskType="TaskType" Dependency="Predecessor">
    </GanttTaskFields>
    <GanttColumns>
    <GanttColumn Field="ID" HeaderText="TaskId" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center"></GanttColumn>
    <GanttColumn Field="TaskName" HeaderText="TaskName"></GanttColumn>
    <GanttColumn Field="StartDate" HeaderText="Start Date"></GanttColumn>
    <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
    <GanttColumn Field="Duration" HeaderText="Duration"></GanttColumn>
    <GanttColumn Field="Assignee" HeaderText="Assignee"></GanttColumn>
    <GanttColumn Field="Reporter" HeaderText="Reporter"></GanttColumn>
    <GanttColumn Field="Progress" HeaderText="Progress" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center"></GanttColumn>
    </GanttColumns>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" Mode="Syncfusion.Blazor.Gantt.EditMode.Auto" ShowDeleteConfirmDialog="true">
    </GanttEditSettings>
    <GanttSplitterSettings Position="40%"></GanttSplitterSettings>
</SfGantt>
@code {
    private SfGantt<TaskData> Obj { get; set; }
    private DateTime ProjectStartDate = new DateTime(2000, 1, 1);
    private DateTime ProjectEndDate = new DateTime(2025, 12, 31);
    private bool autoCalculateDateScheduling = false;
    private List<TaskData> TaskCollection { get; set; }
    protected override void OnInitialized()
    {
        this.TaskCollection = VirtualData.GetTreeVirtualData(1000);
    }
    
    public class VirtualData
    {
        public static List<TaskData> GetTreeVirtualData(int count)
        {
            List<TaskData> DataCollection = new List<TaskData>();
            Random rand = new Random();
            var x = 0;
            int duration = 0;
            DateTime startDate = new DateTime(2000, 1, 5);
            DateTime endDate = new DateTime(2000, 1, 12);
            string[] assignee = { "Allison Janney", "Bryan Fogel", "Richard King", "Alex Gibson" };
            string[] reporter = { "James Ivory", "Jordan Peele", "Guillermo del Toro", "Gary Oldman" };
            for (var i = 1; i <= count / 5; i++)
            {
                var name = rand.Next(0, 100);
                TaskData Parent = new TaskData()
                    {
                        ID = ++x,
                        TaskName = "Task " + x,
                        StartDate = startDate,
                        EndDate = startDate.AddDays(26),
                        Duration = "20",
                        Assignee = "Mark Bridges",
                        Reporter = "Kobe Bryant",
                        Progress = 50,
                    };
                DataCollection.Add(Parent);
                for (var j = 1; j <= 4; j++)
                {
                    startDate = startDate.AddDays(j == 1 ? 0 : duration + 2);
                    duration = 5;
                    DataCollection.Add(new TaskData()
                        {
                            ID = ++x,
                            TaskName = "Task " + x,
                            StartDate = startDate,
                            EndDate = startDate.AddDays(5),
                            Duration = duration.ToString(),
                            Assignee = assignee[j - 1],
                            Reporter = reporter[j - 1],
                            Progress = 50,
                            ParentID = Parent.ID,
                        });
                }
            }
            return DataCollection;
        }
    }
    public class TaskData
    {
        public int ID { get; set; }
        public string TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public string Assignee { get; set; }
        public string Reporter { get; set; }
        public int Progress { get; set; }
        public int? ParentID { get; set; }
        public string Predecessor { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjBeDasmfrkOvUON?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Managing records count

<!-- Having doubt paging supported or not -->

By default, the number of records rendered per page will be twice the Gantt chart's height. You can customize the row rendering count using the [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_PageSize) and [OverscanCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_OverscanCount) properties. Here's an explanation of these properties:

* `PageSize`:
    •	The `PageSize` property determines the number of rows rendered per page in the Gantt Chart.
    •	It allows you to control how many rows are loaded and displayed at initial rendering and also while scrolling, helping to improve performance by reducing the number of DOM elements rendered.
* `OverscanCount`:
    •	The `OverscanCount` property is used to render additional rows before and after the Gantt Chart's current page rows.
    •	During both virtual scrolling and initial rendering, extra rows are rendered to provide a buffer around the current page area. This minimizes the need for frequent rendering during scrolling, providing a smoother user experience.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt @ref="GanttChart" PageSize="15" OverscanCount="5" ID="GanttContainer" EnableContextMenu="true" AllowFiltering="true" AllowSorting="true" DataSource="@TaskCollection" Height="450px" Width="100%" TreeColumnIndex="1" EnableRowVirtualization="true" EnableTimelineVirtualization="true" ProjectStartDate="ProjectStartDate" ProjectEndDate="ProjectEndDate"
         Toolbar="@(new List<string>() { "Add", "Delete", "Edit","Cancel","ExpandAll","CollapseAll" })" ScrollToTaskbarOnClick="true">
    <GanttLabelSettings LeftLabel="TaskName" TValue="TaskData"></GanttLabelSettings>
    <GanttTaskFields ParentID="ParentID" Work="Work" Id="ID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" TaskType="TaskType" Dependency="Predecessor">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="ID" HeaderText="TaskId" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="TaskName"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date"></GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration"></GanttColumn>
        <GanttColumn Field="Assignee" HeaderText="Assignee"></GanttColumn>
        <GanttColumn Field="Reporter" HeaderText="Reporter"></GanttColumn>
        <GanttColumn Field="Progress" HeaderText="Progress" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center"></GanttColumn>
    </GanttColumns>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" Mode="Syncfusion.Blazor.Gantt.EditMode.Dialog" AllowTaskbarEditing="true" ShowDeleteConfirmDialog="true">
    </GanttEditSettings>
    <GanttSplitterSettings Position="40%"></GanttSplitterSettings>
</SfGantt>       
         
 @code {
    SfGantt<TaskData> GanttChart { get; set; }
    private DateTime ProjectStartDate = new DateTime(2000, 1, 1);
    private DateTime ProjectEndDate = new DateTime(2021, 12, 31);
    public int Value { get; set; } = 1000;
    private List<TaskData> TaskCollection { get; set; }
    protected override void OnInitialized()
    {
        this.TaskCollection = VirtualData.GetTreeVirtualData(500);
    }

    public class VirtualData
    {
        public static List<TaskData> GetTreeVirtualData(int count)
        {
            List<TaskData> DataCollection = new List<TaskData>();
            Random rand = new Random();
            var x = 0;
            int duration = 0;
            DateTime startDate = new DateTime(2000, 1, 5);
            DateTime endDate = new DateTime(2000, 1, 12);
            string[] assignee = { "Allison Janney", "Bryan Fogel", "Richard King", "Alex Gibson" };
            string[] reporter = { "James Ivory", "Jordan Peele", "Guillermo del Toro", "Gary Oldman" };
            for (var i = 1; i <= count / 5; i++)
            {
                var name = rand.Next(0, 100);
                TaskData Parent = new TaskData()
                    {
                        ID = ++x,
                        TaskName = "Task " + x,
                        StartDate = startDate,
                        EndDate = startDate.AddDays(26),
                        Duration = "20",
                        Assignee = "Mark Bridges",
                        Reporter = "Kobe Bryant",
                        Progress = rand.Next(100),
                        Predecessor = null
                    };
                DataCollection.Add(Parent);
                for (var j = 1; j <= 4; j++)
                {
                    startDate = startDate.AddDays(j == 1 ? 0 : duration + 2);
                    duration = 5;
                    DataCollection.Add(new TaskData()
                        {
                            ID = ++x,
                            TaskName = "Task " + x,
                            StartDate = startDate,
                            EndDate = startDate.AddDays(5),
                            Duration = duration.ToString(),
                            Assignee = assignee[j - 1],
                            Reporter = reporter[j - 1],
                            Progress = rand.Next(100),
                            ParentID = Parent.ID,
                            Predecessor = j > 1 ? (x - 1) + "FS" : ""
                        });
                }
            }
            return DataCollection;
        }
    }
    public class TaskData
    {
        public int ID { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public string Assignee { get; set; }
        public string Reporter { get; set; }
        public int Progress { get; set; }
        public int? ParentID { get; set; }
        public string Predecessor { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZBSjuWwppImKWKv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Column virtualization

Column virtualization allows you to load more columns with high performance. It renders only the columns in the viewport, while other columns render on-demand during horizontal scrolling.

To enable the column virtualization, set the [EnableRowVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_EnableRowVirtualization) and [EnableColumnVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_EnableColumnVirtualization) properties as **true**.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt ID="Gantt" DataSource="@TaskCollection" 
    EnableRowVirtualization="true" EnableColumnVirtualization="true"  Height="450px" Width="1000px">
    <GanttTaskFields Id="ProjectId" Name="ProjectName" StartDate="ProjectStartDate" EndDate="ProjectEndDate" Duration="ProjectDuration" Progress="ProjectProgress" Dependency="Predecessor" ParentID="ParentID">
    </GanttTaskFields>
     <GanttColumns>
        <GanttColumn Field="ProjectId" HeaderText="Task ID"></GanttColumn>
        <GanttColumn Field="ProjectName" HeaderText="Task Name"> </GanttColumn>
        <GanttColumn Field="ProjectStartDate" HeaderText="Start Date"></GanttColumn>
        <GanttColumn Field="ProjectEndDate" HeaderText="End Date"></GanttColumn>
        <GanttColumn Field="ProjectDuration" HeaderText="Duration"></GanttColumn>
        <GanttColumn Field="Field1" HeaderText="Rebounds" Width="150"></GanttColumn>
        <GanttColumn Field="FIELD2" HeaderText="Year" Width="150"></GanttColumn>
        <GanttColumn Field="FIELD3" HeaderText="Stint" Width="150"></GanttColumn>
        <GanttColumn Field="FIELD4" HeaderText="TMID" Width="150"> </GanttColumn>
        <GanttColumn Field="FIELD5" HeaderText="LGID" Width="150"></GanttColumn>
        <GanttColumn Field="FIELD6" HeaderText="GP" Width="150"></GanttColumn>
        <GanttColumn Field="Field7" HeaderText="GS" Width="150"></GanttColumn>
        <GanttColumn Field="Field8" HeaderText="Minutes" Width="150"></GanttColumn>
        <GanttColumn Field="Field9" HeaderText="Points" Width="150"></GanttColumn>
        <GanttColumn Field="Field10" HeaderText="ORebounds" Width="150"></GanttColumn>
        <GanttColumn Field="Field11" HeaderText="DRebounds" Width="150"></GanttColumn>
    </GanttColumns>
</SfGantt>
@code {
    public List<TaskData> TaskCollection { get; set; }
    protected override void OnInitialized()
    {
        this.TaskCollection = VirtualData.GetTreeVirtualData();
    }
    public class VirtualData
    {
        public static List<TaskData> GetTreeVirtualData()
        {
            string[] Names = new string[] { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD", "HANAR", "CHOPS", "RICSU", "WELLI", "HILAA", "ERNSH", "CENTC", "OTTIK", "QUEDE", "RATTC", "ERNSH", "FOLKO", "BLONP", "WARTH", "FRANK", "GROSR", "WHITC", "WARTH", "SPLIR", "RATTC", "QUICK", "VINET", "MAGAA", "TORTU", "MORGK", "BERGS", "LEHMS", "BERGS", "ROMEY", "ROMEY", "LILAS", "LEHMS", "QUICK", "QUICK", "RICAR", "REGGC", "BSBEV", "COMMI", "QUEDE", "TRADH", "TORTU", "RATTC", "VINET", "LILAS", "BLONP", "HUNGO", "RICAR", "MAGAA", "WANDK", "SUPRD", "GODOS", "TORTU", "OLDWO", "ROMEY", "LONEP", "ANATR", "HUNGO", "THEBI", "DUMON", "WANDK", "QUICK", "RATTC", "ISLAT", "RATTC", "LONEP", "ISLAT", "TORTU", "WARTH", "ISLAT", "PERIC", "KOENE", "SAVEA", "KOENE", "BOLID", "FOLKO", "FURIB", "SPLIR", "LILAS", "BONAP", "MEREP", "WARTH", "VICTE", "HUNGO", "PRINI", "FRANK", "OLDWO", "MEREP", "BONAP", "SIMOB", "FRANK", "LEHMS", "WHITC", "QUICK", "RATTC", "FAMIA" };
            List<TaskData> DataCollection = new List<TaskData>();
            Random random = new Random();
            var x = 0;
            for (var i = 1; i <= 100; i++)
            {
                var name = random.Next(0, 100);
                TaskData Parent = new TaskData()
                {
                    ProjectId = ++x,
                    ProjectName = "Task " + x,
                    ProjectStartDate = new DateTime(2022, 1, 9),
                    ProjectEndDate = new DateTime(2022, 1, 13),
                    ProjectDuration = "10",
                    ProjectProgress = 50,
                    ParentID = null,
                    Predecessor = null,
                };
                DataCollection.Add(Parent);
                for (var j = 1; j <= 50; j++)
                {
                    var childName = random.Next(0, 100);
                    DataCollection.Add(new TaskData()
                    {
                        ProjectId = ++x,
                        ProjectName = "Task " + x,
                        ProjectStartDate = new DateTime(2022, 1, 9),
                        ProjectEndDate = new DateTime(2022, 1, 13),
                        ProjectDuration = "10",
                        ProjectProgress = 50,
                        ParentID = Parent.ProjectId,
                        Predecessor = i + "FS",
                        Field1 = Names[name],
                        FIELD2 = 1967 + 10,
                        FIELD3 = 395 + 600,
                        FIELD4 = 87 + 250,
                        FIELD5 = 410 + 600,
                        FIELD6 = 67 + 250,
                        Field7 = (int)Math.Floor(10 * 100.0),
                        Field8 = (int)Math.Floor(15 * 10.0),
                        Field9 = (int)Math.Floor(20 * 10.0),
                        Field10 = (int)Math.Floor(25 * 100.0),
                        Field11 = (int)Math.Floor(30 * 100.0),
                        Field12 = (int)Math.Floor(35 * 1000.0),
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDryXYCmpzdIEKPs?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> Column's [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html#Syncfusion_Blazor_Gantt_GanttColumn_Width) is required for column virtualization. If the column's width is not defined, then the Gantt Chart will consider its value as **150px**.

## Timeline virtualization

Timeline virtualization allows you to load data sources having a large timespan with high performance. Initially, it renders the timeline with twice the width of the gantt element, while other timeline cells render on-demand during horizontal scrolling. To enable timeline virtualization using this API, simply set [EnableTimelineVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_EnableTimelineVirtualization) to true.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt @ref="Gantt" Width="480px" Height="350px" ID="Gantt" DataSource="@TaskCollection"  Toolbar="@(new  List<string>() { "ZoomIn", "ZoomOut", "ZoomToFit"})" GridLines="Syncfusion.Blazor.Gantt.GridLine.Both" ProjectStartDate="@ProjectStart" ProjectEndDate="@ProjectEnd"
        EnableTimelineVirtualization="true" EnableColumnVirtualization="true">
    <GanttTaskFields Id="ProjectId" Name="ProjectName" StartDate="ProjectStartDate" EndDate="ProjectEndDate"     Duration="ProjectDuration" Progress="ProjectProgress"  Dependency="Predecessor" ParentID="ParentID">
    </GanttTaskFields>
      <GanttEditSettings 
        AllowTaskbarEditing="true" 
        AllowEditing="true" 
        AllowAdding="true" 
        AllowDeleting="true" 
        Mode="Syncfusion.Blazor.Gantt.EditMode.Auto" 
        ShowDeleteConfirmDialog="true"> </GanttEditSettings >
        <GanttSplitterSettings ColumnIndex=1></GanttSplitterSettings>
     <GanttColumns>
        <GanttColumn Field="ProjectId" HeaderText="Task ID"></GanttColumn>
        <GanttColumn Field="ProjectName" HeaderText="Task Name"> </GanttColumn>
        <GanttColumn Field="ProjectStartDate" HeaderText="Start Date"></GanttColumn>
        <GanttColumn Field="ProjectEndDate" HeaderText="End Date"></GanttColumn>
        <GanttColumn Field="ProjectDuration" HeaderText="Duration"></GanttColumn>
         <GanttColumn Field="Predecessor" HeaderText="Predecessor"></GanttColumn>
        <GanttColumn Field="Field1" HeaderText="Rebounds" Width="150"></GanttColumn>
        <GanttColumn Field="FIELD2" HeaderText="Year" Width="150"></GanttColumn>
        <GanttColumn Field="FIELD3" HeaderText="Stint" Width="150"></GanttColumn>
        <GanttColumn Field="FIELD4" HeaderText="TMID" Width="150"> </GanttColumn>
        <GanttColumn Field="FIELD5" HeaderText="LGID" Width="150"></GanttColumn>
        <GanttColumn Field="FIELD6" HeaderText="GP" Width="150"></GanttColumn>
        <GanttColumn Field="Field7" HeaderText="GS" Width="150"></GanttColumn>
        <GanttColumn Field="Field8" HeaderText="Minutes" Width="150"></GanttColumn>
        <GanttColumn Field="Field9" HeaderText="Points" Width="150"></GanttColumn>
        <GanttColumn Field="Field10" HeaderText="ORebounds" Width="150"></GanttColumn>
        <GanttColumn Field="Field11" HeaderText="DRebounds" Width="150"></GanttColumn>
    </GanttColumns>
</SfGantt>

@code {
    public SfGantt<TaskData> Gantt;
    public DateTime ProjectStart = new DateTime(2000, 2, 6);
    public DateTime ProjectEnd = new DateTime(2100, 12, 31);

    public List<TaskData> TaskCollection { get; set; }
    protected override void OnInitialized()
    {
        this.TaskCollection = VirtualData.GetTreeVirtualData();
    }
    public class VirtualData
    {
        public static List<TaskData> GetTreeVirtualData()
        {
            string[] Names = new string[] { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD", "HANAR", "CHOPS", "RICSU", "WELLI", "HILAA", "ERNSH", "CENTC", "OTTIK", "QUEDE", "RATTC", "ERNSH", "FOLKO", "BLONP", "WARTH", "FRANK", "GROSR", "WHITC", "WARTH", "SPLIR", "RATTC", "QUICK", "VINET", "MAGAA", "TORTU", "MORGK", "BERGS", "LEHMS", "BERGS", "ROMEY", "ROMEY", "LILAS", "LEHMS", "QUICK", "QUICK", "RICAR", "REGGC", "BSBEV", "COMMI", "QUEDE", "TRADH", "TORTU", "RATTC", "VINET", "LILAS", "BLONP", "HUNGO", "RICAR", "MAGAA", "WANDK", "SUPRD", "GODOS", "TORTU", "OLDWO", "ROMEY", "LONEP", "ANATR", "HUNGO", "THEBI", "DUMON", "WANDK", "QUICK", "RATTC", "ISLAT", "RATTC", "LONEP", "ISLAT", "TORTU", "WARTH", "ISLAT", "PERIC", "KOENE", "SAVEA", "KOENE", "BOLID", "FOLKO", "FURIB", "SPLIR", "LILAS", "BONAP", "MEREP", "WARTH", "VICTE", "HUNGO", "PRINI", "FRANK", "OLDWO", "MEREP", "BONAP", "SIMOB", "FRANK", "LEHMS", "WHITC", "QUICK", "RATTC", "FAMIA" };
            List<TaskData> DataCollection = new List<TaskData>();
            Random random = new Random();
            var x = 0;
            for (var i = 1; i <= 100; i++)
            {
                var name = random.Next(0, 100);
                TaskData Parent = new TaskData()
                {
                    ProjectId = ++x,
                    ProjectName = "Task " + x,
                    ProjectStartDate = new DateTime(2017, 1, 9),
                    ProjectEndDate = new DateTime(2017, 1, 13),
                    ProjectDuration = "10",
                    ProjectProgress = 50,
                    ParentID = null,
                    Predecessor = null,
                };
                DataCollection.Add(Parent);
                for (var j = 1; j <= 10; j++)
                {
                    var childName = random.Next(0, 100);
                    DataCollection.Add(new TaskData()
                    {
                        ProjectId = ++x,
                        ProjectName = "Task " + x,
                        ProjectStartDate = j <= 3 ? new DateTime(2000, 2, 10) : j > 3 && j <= 6 ? new DateTime(2031, 5, 1) : new DateTime(2061, 8, 1),
                        ProjectEndDate = new DateTime(2021, 1, 13),
                        ProjectDuration = "10650",
                        ProjectProgress = 50,
                        ParentID = Parent.ProjectId,
                        Field1 = Names[name],
                        FIELD2 = 1967 + 10,
                        FIELD3 = 395 + 600,
                        FIELD4 = 87 + 250,
                        FIELD5 = 410 + 600,
                        FIELD6 = 67 + 250,
                        Field7 = (int)Math.Floor(10 * 100.0),
                        Field8 = (int)Math.Floor(15 * 10.0),
                        Field9 = (int)Math.Floor(20 * 10.0),
                        Field10 = (int)Math.Floor(25 * 100.0),
                        Field11 = (int)Math.Floor(30 * 100.0),
                        Field12 = (int)Math.Floor(35 * 1000.0),
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZLSZYsmJzvPFSdf?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

![Blazor GanttChart with timeline virtualization](./images/timeline_virtual.gif)

## Limitations for virtualization

* Due to the element height limitation in browsers, the maximum number of records loaded by the Gantt chart is limited by the browser capability.
* It is necessary to mention the height of the Gantt in pixels when enabling Virtual Scrolling.
* Cell selection will not be persisted in a row.
* Programmatic selection using the **SelectRows** method is not supported in virtual scrolling.
* Collapse all and expand all actions are performed only for the current view-port data in virtual scrolling.
* While using column virtualization, column width should be in the pixel. Percentage values are not accepted.