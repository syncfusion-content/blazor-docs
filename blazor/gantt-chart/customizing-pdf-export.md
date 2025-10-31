---
layout: post
title: Customize PDF exporting in Blazor Gantt Chart component | Syncfusion
description: Learn here all about Customize PDF exporting in Syncfusion Blazor Gantt Chart component and much more.
platform: Blazor
control: Customize pdf export
documentation: ug
---

# To customize PDF export

Customizing PDF export in the Blazor Gantt Chart component allows tailoring exported documents for specific needs, using [GanttPdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportProperties.html) to adjust file names, page orientation, size, columns, headers, footers, timelines, and templates. Ensuring focused content like selected rows or styled taskbars and [AllowPdfExport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AllowPdfExport) enabled. Use [PdfExporting](https://blazor.syncfusion.com/documentation/gantt-chart/events#pdfexporting) and [PdfExported](https://blazor.syncfusion.com/documentation/gantt-chart/events#pdfexported) events for pre-export and post-export modifications, and [PdfQueryTaskbarInfo](https://blazor.syncfusion.com/documentation/gantt-chart/events#pdfquerytaskbarinfo) for taskbar styling.

## Customize file name

Set the exported PDF file name using the [FileName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_FileName) property in [GanttPdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportProperties.html), such as **ProjectSchedule.pdf**, for personalized document naming.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Navigations

<SfGantt @ref="Gantt" ID="GanttExport" DataSource="@TaskCollection" Height="450px" Width="900px" AllowPdfExport="true" Toolbar="toolbarItem">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Dependency="Predecessor"
                     Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttEvents OnToolbarClick="ToolbarClickHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    private List<TaskData> TaskCollection { get; set; }
    private SfGantt<TaskData> Gantt;
    private List<object> toolbarItem = new List<Object>() { new Syncfusion.Blazor.Navigations.ToolbarItem() { Text = "PDF Export", TooltipText = "PDF Export", Id = "PdfExport", PrefixIcon = "e-pdfexport" } };
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }
    public async void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "PdfExport")
        {
            GanttPdfExportProperties exportProperties = new GanttPdfExportProperties();
            exportProperties.FileName = "ProjectSchedule.pdf";
            await Gantt.ExportToPdfAsync(exportProperties);
        }
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
        public string Predecessor { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 08), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentID = 1, Predecessor = "2" },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 , Predecessor = "3" },
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjBSCZNAhALZXWKG?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## How to change the page orientation

You can customize the page orientation of the exported PDF document in the Blazor Gantt chart by using the [PageOrientation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_PageOrientation) property in the [GanttPdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportProperties.html) class.
This property allows you to choose between [Portrait](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PageOrientation.html#Syncfusion_Blazor_Grids_PageOrientation_Portrait) (default) and [Landscape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PageOrientation.html#Syncfusion_Blazor_Grids_PageOrientation_Landscape) orientations based on your layout requirements. Use `Portrait` for documents that require more vertical space, and `Landscape` when you need to fit more columns or wider taskbars.

The following code snippet demonstrates how to set the page orientation to `Landscape` for the exported PDF document:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Navigations

<SfGantt @ref="Gantt" ID="GanttExport" DataSource="@TaskCollection" Height="450px" Width="900px" AllowPdfExport="true" Toolbar="toolbarItem">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Dependency="Predecessor"
                     Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttEvents OnToolbarClick="ToolbarClickHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    private List<TaskData> TaskCollection { get; set; }
    private SfGantt<TaskData> Gantt;
    private List<object> toolbarItem = new List<Object>() { new Syncfusion.Blazor.Navigations.ToolbarItem() { Text = "PDF Export", TooltipText = "PDF Export", Id = "PdfExport", PrefixIcon = "e-pdfexport" } };
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }
    public async void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "PdfExport")
        {
            GanttPdfExportProperties exportProperties = new GanttPdfExportProperties();
            exportProperties.PageOrientation = Syncfusion.Blazor.Grids.PageOrientation.Landscape;
            await Gantt.ExportToPdfAsync(exportProperties);
        }
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
        public string Predecessor { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 08), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentID = 1, Predecessor = "2" },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 , Predecessor = "3" },
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BtVyMjNgBzDbCnDU?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customize page size

Page size can be customized for the exported document using the [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfPageSize.html) property in [GanttPdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportProperties.html).
The supported page sizes are:

* Letter
* Note
* Legal
* A0 to A9
* B0 to B5
* Archa
* Archb
* Archc
* Archd
* Arche
* Flsa
* HalfLetter
* Letter11x17
* Ledger

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Navigations

<SfGantt @ref="Gantt" ID="GanttExport" DataSource="@TaskCollection" Height="450px" Width="900px" AllowPdfExport="true" Toolbar="toolbarItem">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Dependency="Predecessor"
                     Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttEvents OnToolbarClick="ToolbarClickHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    private List<TaskData> TaskCollection { get; set; }
    private SfGantt<TaskData> Gantt;
    private List<object> toolbarItem = new List<Object>() { new Syncfusion.Blazor.Navigations.ToolbarItem() { Text = "PDF Export", TooltipText = "PDF Export", Id = "PdfExport", PrefixIcon = "e-pdfexport" } };
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }
    public async void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "PdfExport")
        {
            GanttPdfExportProperties exportProperties = new GanttPdfExportProperties();
            exportProperties.PageSize = Syncfusion.Blazor.Grids.PdfPageSize.A4;
            await Gantt.ExportToPdfAsync(exportProperties);
        }
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
        public string Predecessor { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 08), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentID = 1, Predecessor = "2" },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 , Predecessor = "3" },
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNhyiZZKhzLBWLhu?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Export current view records

The PDF export functionality allows you to export only the records that are currently visible on the Gantt chart to a PDF document. This can be achieved by enabling the [IsCurrentViewExport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.PdfExportEventArgs.html#Syncfusion_Blazor_Gantt_PdfExportEventArgs_IsCurrentViewExport) boolean property in the [PdfExporting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_PdfExporting) event.

> Exporting current view records is only applicable when the virtualization feature is enabled, and it does not retain the state of collapsed rows during export.

The following code demonstrates how to use the `PdfExporting` event to export the current view data of the Gantt chart to a PDF document:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Navigations

<SfGantt @ref="Gantt" DataSource="@TaskCollection" Height="450px" Width="100%" AllowPdfExport="true" TreeColumnIndex="1" EnableRowVirtualization="true"  Toolbar="@toolbarItem" ScrollToTaskbarOnClick="true">
    <GanttLabelSettings LeftLabel="TaskName" TValue="TaskData"></GanttLabelSettings>
    <GanttTaskFields ParentID="ParentID" Work="Work" Id="ID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" TaskType="TaskType" Dependency="Predecessor">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="ID" HeaderText="Task Id" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Task Name"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date"></GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration"></GanttColumn>
        <GanttColumn Field="Assignee" HeaderText="Assignee"></GanttColumn>
        <GanttColumn Field="Reporter" HeaderText="Reporter"></GanttColumn>
        <GanttColumn Field="Progress" HeaderText="Progress" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center"></GanttColumn>
    </GanttColumns>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" Mode="Syncfusion.Blazor.Gantt.EditMode.Auto" ShowDeleteConfirmDialog="true">
    </GanttEditSettings>
    <GanttEvents OnToolbarClick="ToolbarClickHandler" PdfExporting=" PdfExportingHandler" TValue="TaskData"></GanttEvents>
    <GanttSplitterSettings Position="40%"></GanttSplitterSettings>
</SfGantt>
@code {
    private SfGantt<TaskData> Gantt { get; set; }
    private List<object> toolbarItem = new List<Object>() { new Syncfusion.Blazor.Navigations.ToolbarItem() { Text = "PDF Export", TooltipText = "PDF Export", Id = "PdfExport", PrefixIcon = "e-pdfexport" } };
    private List<TaskData> TaskCollection { get; set; }
    protected override void OnInitialized()
    {
        this.TaskCollection = VirtualData.GetTreeVirtualData(30);
    }
    public async void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "PdfExport")
        {
            await Gantt.ExportToPdfAsync();
        }
    }
    public void PdfExportingHandler(PdfExportEventArgs args)
    {
        args.IsCurrentViewExport = true;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjhyWjtqBfpHsisd?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## How to export Gantt chart with custom timeline range

The PDF export functionality allows you to export a specific timeline range of the Gantt chart to a PDF document. To define the custom range, set the [RangeStart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.PdfExportEventArgs.html#Syncfusion_Blazor_Gantt_PdfExportEventArgs_RangeStart) and [RangeEnd](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.PdfExportEventArgs.html#Syncfusion_Blazor_Gantt_PdfExportEventArgs_RangeEnd) properties within the [PdfExporting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_PdfExporting) event.

The `RangeStart` property specifies the start date, and the `RangeEnd` property specifies the end date of the timeline range to be exported.

The following code demonstrates how to use the `PdfExporting` event to export a custom timeline range of the Gantt chart to a PDF document:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Navigations

<SfGantt @ref="Gantt" DataSource="@TaskCollection" Height="450px" Width="100%" AllowPdfExport="true" TreeColumnIndex="1"  Toolbar="@toolbarItem">
    <GanttLabelSettings LeftLabel="TaskName" TValue="TaskData"></GanttLabelSettings>
    <GanttTaskFields ParentID="ParentID" Work="Work" Id="ID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" TaskType="TaskType" Dependency="Predecessor">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="ID" HeaderText="Task Id" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Task Name"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date"></GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration"></GanttColumn>
        <GanttColumn Field="Assignee" HeaderText="Assignee"></GanttColumn>
        <GanttColumn Field="Reporter" HeaderText="Reporter"></GanttColumn>
        <GanttColumn Field="Progress" HeaderText="Progress" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Center"></GanttColumn>
    </GanttColumns>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" Mode="Syncfusion.Blazor.Gantt.EditMode.Auto" ShowDeleteConfirmDialog="true">
    </GanttEditSettings>
    <GanttEvents OnToolbarClick="ToolbarClickHandler" PdfExporting=" PdfExportingHandler" TValue="TaskData"></GanttEvents>
    <GanttSplitterSettings Position="40%"></GanttSplitterSettings>
</SfGantt>
@code {
    private SfGantt<TaskData> Gantt { get; set; }
    private List<object> toolbarItem = new List<Object>() { new Syncfusion.Blazor.Navigations.ToolbarItem() { Text = "PDF Export", TooltipText = "PDF Export", Id = "PdfExport", PrefixIcon = "e-pdfexport" } };
    private List<TaskData> TaskCollection { get; set; }
    protected override void OnInitialized()
    {
        this.TaskCollection = VirtualData.GetTreeVirtualData(30);
    }
    public async void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "PdfExport")
        {
            await Gantt.ExportToPdfAsync();
        }
    }
    public void PdfExportingHandler(PdfExportEventArgs args)
    {
        args.RangeStart = new DateTime(2000, 1, 14);
        args.RangeEnd = new DateTime(2000, 05, 12);
    }
    public class VirtualData
    {
        public static List<TaskData> GetTreeVirtualData(int count)
        {
            List<TaskData> DataCollection = new List<TaskData>();
            var x = 0;
            int duration = 0;
            DateTime startDate = new DateTime(2000, 1, 5);
            DateTime endDate = new DateTime(2000, 1, 12);
            string[] assignee = { "Allison Janney", "Bryan Fogel", "Richard King", "Alex Gibson" };
            string[] reporter = { "James Ivory", "Jordan Peele", "Guillermo del Toro", "Gary Oldman" };
            for (var i = 1; i <= count / 5; i++)
            {
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtByWjjUrpHrtFIB?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Export hidden columns

PDF export provides an option to export hidden columns of Gantt by defining the [IncludeHiddenColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_IncludeHiddenColumn) to **true**.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Navigations

<SfGantt @ref="Gantt" ID="GanttExport" DataSource="@TaskCollection" Height="450px" Width="900px" AllowPdfExport="true" Toolbar="toolbarItem">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Dependency="Predecessor"
                     Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskID" HeaderText="Task Id" Width="100" HeaderTextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Task Name" Visible="false"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration"></GanttColumn>
        <GanttColumn Field="Predecessor" HeaderText="Dependency"></GanttColumn>
    </GanttColumns>
    <GanttEvents OnToolbarClick="ToolbarClickHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    private List<TaskData> TaskCollection { get; set; }
    private SfGantt<TaskData> Gantt;
    private List<object> toolbarItem = new List<Object>() { new Syncfusion.Blazor.Navigations.ToolbarItem() { Text = "PDF Export", TooltipText = "PDF Export", Id = "PdfExport", PrefixIcon = "e-pdfexport" } };
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }
    public async void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "PdfExport")
        {
            GanttPdfExportProperties exportProperties = new GanttPdfExportProperties();
            exportProperties.IncludeHiddenColumn = true;
            await Gantt.ExportToPdfAsync(exportProperties);
        }
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
        public string Predecessor { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 08), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentID = 1, Predecessor = "2" },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 , Predecessor = "3" },
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtreCNXgVTcKHkcY?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customize column width in exported PDF document

To customize column widths in the exported PDF document, set the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html#Syncfusion_Blazor_Gantt_GanttColumn_Width) property for each column using the [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportProperties.html#Syncfusion_Blazor_Gantt_GanttPdfExportProperties_Columns) property of the [GanttPdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportProperties.html) class.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using Syncfusion.PdfExport

<SfGantt @ref="Gantt" ID="GanttExport" DataSource="@TaskCollection" Height="450px" Width="900px" AllowPdfExport="true" Toolbar="toolbarItem">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Dependency="Predecessor"
                     Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskID" HeaderText="Task Id" Width="100" HeaderTextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Task Name"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration"></GanttColumn>
        <GanttColumn Field="Predecessor" HeaderText="Dependency"></GanttColumn>
    </GanttColumns>
    <GanttEvents OnToolbarClick="ToolbarClickHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    private List<TaskData> TaskCollection { get; set; }
    private SfGantt<TaskData> Gantt;
    private List<object> toolbarItem = new List<Object>() { new Syncfusion.Blazor.Navigations.ToolbarItem() { Text = "PDF Export", TooltipText = "PDF Export", Id = "PdfExport", PrefixIcon = "e-pdfexport" } };
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }
    public async void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "PdfExport")
        {
            GanttPdfExportProperties exportProperties = new GanttPdfExportProperties();
            exportProperties.Columns = new List<GanttColumn>()
            {
                new GanttColumn(){ Field = "TaskID", HeaderText = "Task Id", Width = "200" },
                new GanttColumn(){ Field = "TaskName", HeaderText = "Task Name", Width = "250"},
                new GanttColumn(){ Field = "StartDate", HeaderText = "Start Date", Width = "150"},
            };
            await Gantt.ExportToPdfAsync(exportProperties);
        }
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
        public string Predecessor { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 08), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentID = 1, Predecessor = "2" },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 , Predecessor = "3" },
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtBostXgrIjeKZvL?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## How to export Gantt chart with specific columns

### Through property

The PDF export functionality enables you to export only specific columns from the Gantt chart, rather than exporting all columns by default. To achieve this, set the [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportProperties.html#Syncfusion_Blazor_Gantt_GanttPdfExportProperties_Columns) property of the [GanttPdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportProperties.html) class. This allows you to tailor the exported PDF to include only the columns that are relevant to your needs.

The following code snippet demonstrates how to configure the `Columns` property to export specific columns from the Gantt chart to a PDF document:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using Syncfusion.PdfExport

<SfGantt @ref="Gantt" ID="GanttExport" DataSource="@TaskCollection" Height="450px" Width="900px" AllowPdfExport="true" Toolbar="toolbarItem">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Dependency="Predecessor"
                     Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskID" HeaderText="Task Id" Width="100" HeaderTextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Task Name"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration"></GanttColumn>
        <GanttColumn Field="Predecessor" HeaderText="Dependency"></GanttColumn>
    </GanttColumns>
    <GanttEvents OnToolbarClick="ToolbarClickHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    private List<TaskData> TaskCollection { get; set; }
    private SfGantt<TaskData> Gantt;
    private List<object> toolbarItem = new List<Object>() { new Syncfusion.Blazor.Navigations.ToolbarItem() { Text = "PDF Export", TooltipText = "PDF Export", Id = "PdfExport", PrefixIcon = "e-pdfexport" } };
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }
    public async void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "PdfExport")
        {
            GanttPdfExportProperties exportProperties = new GanttPdfExportProperties();
            exportProperties.Columns = new List<GanttColumn>()
            {
                new GanttColumn(){ Field = "TaskID", HeaderText = "Task Id", Width = "100" },
                new GanttColumn(){ Field = "TaskName", HeaderText = "Task Name", Width = "200"},
                new GanttColumn(){ Field = "StartDate", HeaderText = "Start Date", Width = "150"},
            };
            await Gantt.ExportToPdfAsync(exportProperties);
        }
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
        public string Predecessor { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 08), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentID = 1, Predecessor = "2" },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 , Predecessor = "3" },
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXhIiXZAVoCQueAU?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Through event

The PDF export functionality allows you to export only specific columns from the Gantt chart, rather than exporting all columns by default. This can be achieved by using the `Columns` argument in the [PdfExporting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_PdfExporting) event.

The following code demonstrates how to use the `PdfExporting` event to export specific columns of the Gantt chart to a PDF document,

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using Syncfusion.PdfExport

<SfGantt @ref="Gantt" ID="GanttExport" DataSource="@TaskCollection" Height="450px" Width="900px" AllowPdfExport="true" Toolbar="toolbarItem">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Dependency="Predecessor"
                     Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskID" HeaderText="Task Id" Width="100" HeaderTextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Task Name"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration"></GanttColumn>
        <GanttColumn Field="Predecessor" HeaderText="Dependency"></GanttColumn>
    </GanttColumns>
    <GanttEvents OnToolbarClick="ToolbarClickHandler" PdfExporting=" PdfExportingHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    private List<TaskData> TaskCollection { get; set; }
    private SfGantt<TaskData> Gantt;
    private List<object> toolbarItem = new List<Object>() { new Syncfusion.Blazor.Navigations.ToolbarItem() { Text = "PDF Export", TooltipText = "PDF Export", Id = "PdfExport", PrefixIcon = "e-pdfexport" } };
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }
    public async void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "PdfExport")
        {
            await Gantt.ExportToPdfAsync();
        }
    }
    public void PdfExportingHandler(PdfExportEventArgs args)
    {
        args.Columns = new List<GanttColumn>()
            {
                new GanttColumn(){ Field = "TaskID", HeaderText = "Task Id", Width = "100" },
                new GanttColumn(){ Field = "TaskName", HeaderText = "Task Name", Width = "200"},
                new GanttColumn(){ Field = "StartDate", HeaderText = "Start Date", Width = "150"},
            };
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
        public string Predecessor { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 08), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentID = 1, Predecessor = "2" },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 , Predecessor = "3" },
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXVoCjXAVSBmCcUQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customizing taskbar appearance

You can customize the appearance of taskbars in the exported PDF document using either properties or events, based on your requirements.

### Through property

The PDF export functionality allows you to customize the appearance of taskbars in the exported PDF document using the [TaskbarColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.PdfGanttStyle.html#Syncfusion_Blazor_Gantt_PdfGanttStyle_TaskbarColor) property in the [GanttPdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportProperties.html) class. This property lets you define custom colors for different types of taskbars, including:

* Parent Taskbars
* Child Taskbars
* Milestones
* Critical Paths
* Manual Taskbars
* Baselines

The following code snippet demonstrates how to customize taskbar colors in the exported PDF document:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using Syncfusion.PdfExport

<SfGantt @ref="Gantt" ID="GanttExport" DataSource="@TaskCollection" Height="450px" Width="900px" AllowPdfExport="true" Toolbar="toolbarItem" EnableCriticalPath="true"
                     RenderBaseline="true">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" BaselineStartDate="BaselineStartDate" BaselineEndDate="BaselineEndDate"
                     Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskID" HeaderText="Task Id" Width="100" HeaderTextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Task Name"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration"></GanttColumn>
    </GanttColumns>
    <GanttEvents OnToolbarClick="ToolbarClickHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    private List<TaskData> TaskCollection { get; set; }
    private SfGantt<TaskData> Gantt;
    private List<object> toolbarItem = new List<Object>() { new Syncfusion.Blazor.Navigations.ToolbarItem() { Text = "PDF Export", TooltipText = "PDF Export", Id = "PdfExport", PrefixIcon = "e-pdfexport" } };
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }
    public async void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "PdfExport")
        {
            GanttPdfExportProperties pdfExport = new GanttPdfExportProperties();
            pdfExport.Style = new PdfGanttStyle();
            pdfExport.Style.TaskbarColor = new PdfTaskbarColor();
            pdfExport.Style.TaskbarColor.ParentTaskbarColor = new PdfColor(220, 118, 51);
            pdfExport.Style.TaskbarColor.ParentProgressColor = new PdfColor(203, 67, 53);
            pdfExport.Style.TaskbarColor.ChildProgressColor = new PdfColor(35, 155, 86);
            pdfExport.Style.TaskbarColor.ChildTaskbarColor = new PdfColor(130, 224, 170);
            pdfExport.Style.TaskbarColor.CriticalPathTaskbarColor = new PdfColor(173, 121, 64);
            pdfExport.Style.TaskbarColor.CriticalPathProgressColor = new PdfColor(145, 76, 0);
            pdfExport.Style.TaskbarColor.BaselineColor = new PdfColor(179, 38, 30);
            pdfExport.Style.TaskbarColor.MilestoneColor = new PdfColor(141, 124, 187);
            await Gantt.ExportToPdfAsync(pdfExport);
        }
    }
    
    public class TaskData
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime? BaselineStartDate { get; set; }
        public DateTime? BaselineEndDate { get; set; }
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
            new TaskData() { TaskID = 1, TaskName = "Project initiation", BaselineStartDate = new DateTime(2021, 04, 02), BaselineEndDate = new DateTime(2021, 04, 04), StartDate = new DateTime(2021, 04, 02), EndDate = new DateTime(2021, 04, 08) },
            new TaskData() { TaskID = 2, TaskName = "Identify site location", StartDate = new DateTime(2021, 04, 02), EndDate = new DateTime(2021, 04, 02), Duration = "0", BaselineStartDate = new DateTime(2021, 04, 02), BaselineEndDate = new DateTime(2021, 04, 02), Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2021, 04, 02), Duration = "5", Progress = 40, BaselineStartDate = new DateTime(2021, 04, 02), BaselineEndDate = new DateTime(2021, 04, 06), ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2021, 04, 08), Duration = "0", EndDate = new DateTime(2021, 04, 08), BaselineStartDate = new DateTime(2021, 04, 08), BaselineEndDate = new DateTime(2021, 04, 08), Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Project initiation", StartDate = new DateTime(2021, 04, 02), EndDate = new DateTime(2021, 04, 08) },
            new TaskData() { TaskID = 6, TaskName = "Identify site location", StartDate = new DateTime(2021, 04, 02), Duration = "2", Progress = 30, ParentID = 5, BaselineStartDate = new DateTime(2021, 04, 02), BaselineEndDate = new DateTime(2021, 04, 02) },
            new TaskData() { TaskID = 7, TaskName = "Perform soil test", StartDate = new DateTime(2021, 04, 02), Duration = "4", Progress = 40, ParentID = 5, BaselineStartDate = new DateTime(2021, 04, 02), BaselineEndDate = new DateTime(2021, 04, 03) },
            new TaskData() { TaskID = 8, TaskName = "Soil test approval", StartDate = new DateTime(2021, 04, 02), Duration = "5", Progress = 30, ParentID = 5, BaselineStartDate = new DateTime(2021, 04, 02), BaselineEndDate = new DateTime(2021, 04, 04) }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXVyijDKBofOIgSk?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Through event 

The PDF export functionality allows you to customize the appearance of taskbars in the exported PDF document using the [PdfQueryTaskbarInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_PdfQueryTaskbarInfo) event. This event provides flexibility to format various taskbar types, including parent taskbars, individual taskbars, and milestone templates.

The following code snippet demonstrates how to use the `PdfQueryTaskbarInfo` event to customize taskbar appearance in the exported PDF document:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using Syncfusion.PdfExport

<SfGantt @ref="Gantt" ID="GanttExport" DataSource="@TaskCollection" Height="450px" Width="900px" AllowPdfExport="true" Toolbar="toolbarItem">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Dependency="Predecessor"
                     Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskID" HeaderText="Task Id" Width="100" HeaderTextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Task Name"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration"></GanttColumn>
        <GanttColumn Field="Predecessor" HeaderText="Dependency"></GanttColumn>
    </GanttColumns>
    <GanttEvents OnToolbarClick="ToolbarClickHandler" PdfQueryTaskbarInfo="PdfQueryTaskbarInfoHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    private List<TaskData> TaskCollection { get; set; }
    private SfGantt<TaskData> Gantt;
    private List<object> toolbarItem = new List<Object>() { new Syncfusion.Blazor.Navigations.ToolbarItem() { Text = "PDF Export", TooltipText = "PDF Export", Id = "PdfExport", PrefixIcon = "e-pdfexport" } };
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }
    public async void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "PdfExport")
        {
            await Gantt.ExportToPdfAsync();
        }
    }
    public void PdfQueryTaskbarInfoHandler(PdfQueryTaskbarInfoEventArgs<TaskData> args)
    {
        if (args.Data.TaskID == 3)
        {
            args.TaskbarStyle.Color = new PdfTaskbarColor();
            args.TaskbarStyle.Color.ChildProgressColor = new Syncfusion.PdfExport.PdfColor(103, 80, 164);
            args.TaskbarStyle.Color.ChildTaskbarColor = new Syncfusion.PdfExport.PdfColor(141, 124, 187);
        }
        if (args.Data.TaskID == 4)
        {
            args.TaskbarStyle.Color = new PdfTaskbarColor();
            args.TaskbarStyle.Color.MilestoneColor = new Syncfusion.PdfExport.PdfColor(103, 80, 164);
        }

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
        public string Predecessor { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 08), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentID = 1, Predecessor = "2" },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 , Predecessor = "3" },
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDheittqhyxNSXIj?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Exporting with templates

### Exporting with column template

The PDF export functionality allows for advanced customization of Gantt chart columns, including the inclusion of images, background colors, and custom text. This can be achieved using the [PdfQueryCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_PdfQueryCellInfo) event. By handling this event, you can define how individual cells in the Gantt chart are rendered in the exported PDF.

The following code snippet demonstrates how to use the `PdfQueryCellInfo` event to export Gantt columns with custom text and different cell background colors,

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using Syncfusion.PdfExport

<SfGantt @ref="Gantt" ID="GanttExport" DataSource="@TaskCollection" Height="450px" Width="900px" AllowPdfExport="true" Toolbar="toolbarItem">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Dependency="Predecessor"
                     Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskID" HeaderText="Task Id" Width="100" HeaderTextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Task Name"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration"></GanttColumn>
        <GanttColumn Field="Predecessor" HeaderText="Dependency"></GanttColumn>
    </GanttColumns>
    <GanttEvents OnToolbarClick="ToolbarClickHandler" PdfQueryCellInfo="PdfQueryCellInfoHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    private List<TaskData> TaskCollection { get; set; }
    private SfGantt<TaskData> Gantt;
    private List<object> toolbarItem = new List<Object>() { new Syncfusion.Blazor.Navigations.ToolbarItem() { Text = "PDF Export", TooltipText = "PDF Export", Id = "PdfExport", PrefixIcon = "e-pdfexport" } };
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }
    public async void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "PdfExport")
        {
            await Gantt.ExportToPdfAsync();
        }
    }
    public void PdfQueryCellInfoHandler(Syncfusion.Blazor.Gantt.PdfQueryCellInfoEventArgs<TaskData> args)
    {
        if (args.Column.Field == "TaskName" && args.Data.TaskID == 5)
        {
            args.Cell.Value = "Updated Value";
            args.Cell.CellStyle = new PdfElementStyle()
            {
                FillBackgroundColor = "Orange",
                Font = new PdfGridFont()
                {
                    FontFamily = PdfFontFamily.TimesRoman,
                    FontSize = 6,
                    FontStyle = PdfFontStyle.Italic,
                    IsTrueType = false,
                    TextColor = "Red",
                    TextHighlightColor = "Green"
                }
            };
            args.Cell.CellStyle.Border = new Syncfusion.Blazor.Grids.PdfBorder()
            {
                Color = "Black",
                DashStyle = Syncfusion.Blazor.Grids.PdfDashStyle.Dot,
                Width = 0.1
            };
        }
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
        public string Predecessor { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 08), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentID = 1, Predecessor = "2" },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 , Predecessor = "3" },
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDLejELSpVTlPVsF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Exporting with column header template

The PDF export functionality allows to export header template that include `images` and `text` to an PDF document using [PdfColumnHeaderQueryCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_PdfColumnHeaderQueryCellInfo) event.

In the following sample, header template with images and text are exported to PDF using [HeaderTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html#Syncfusion_Blazor_Gantt_GanttColumn_HeaderTemplate) properties in the `PdfColumnHeaderQueryCellInfo` event.

> PDF Export supports base64 string to export the images.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
@using Syncfusion.PdfExport
@using System.Net.Http
@using System.IO
@inject HttpClient Http

<SfGantt @ref="Gantt" ID="GanttExport" DataSource="@TaskCollection" Width="700px" Height="400px" AllowPdfExport="true" Toolbar="toolbarItem">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="Parent_Id"></GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskName" HeaderText="Job Name" Width="250">
            <HeaderTemplate>
                <div>
                    <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" width="20" height="20" style="margin-right: 8px">
                    @((context as GridColumn).HeaderText)
                </div>
            </HeaderTemplate>
        </GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date" Width="250">
            <HeaderTemplate>
                <div>
                    <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" width="20" height="20" style="margin-right: 8px">
                    @((context as GridColumn).HeaderText)
                </div>
            </HeaderTemplate>
        </GanttColumn>
    </GanttColumns>
    <GanttEvents OnToolbarClick="ToolbarClickHandler" PdfColumnHeaderQueryCellInfo="PdfHeaderQueryCellInfoHandler" TValue="TaskData"></GanttEvents>
</SfGantt>
@code{ 
    private List<TaskData> TaskCollection { get; set; }
    private SfGantt<TaskData> Gantt;
    private List<object> toolbarItem = new List<object>() {
        new Syncfusion.Blazor.Navigations.ToolbarItem() {
            Text = "PDF Export", TooltipText = "PDF Export", Id = "PdfExport", PrefixIcon = "e-pdfexport"
        }
    };

    public PdfImage image;    
    protected override async Task OnInitializedAsync()
    {
        TaskCollection = GetTaskCollection();
        var imageBytes = await Http.GetByteArrayAsync("https://cdn.syncfusion.com/content/images/landing-page/yes.png");
        using var imageStream = new MemoryStream(imageBytes);
        image = PdfImage.FromStream(imageStream);
    }


    public async void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "PdfExport")
        {
            await Gantt.ExportToPdfAsync();
        }
    }

    public void PdfHeaderQueryCellInfoHandler(Syncfusion.Blazor.Gantt.PdfHeaderQueryCellInfoEventArgs args)
    {
        args.Cell.CellStyle = new PdfElementStyle(){ Image = image };
    }

    public class TaskData
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? Parent_Id { get; set; }

    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
                {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 21)},
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, Parent_Id = 1},
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, Parent_Id = 1},
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, Parent_Id =1},
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 04, 21)},
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, Parent_Id =5},
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 40, Parent_Id =5},
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0", Progress = 30, Parent_Id =5}

        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtresXgMqlBQjXfl?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Exporting with task label template

The PDF export functionality allows to export task label template that include `images` and `text` to an PDF document using [PdfQueryTaskbarInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_PdfQueryTaskbarInfo) event.

In the following sample, task label template with images and text are exported to PDF using [LabelSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.PdfQueryTaskbarInfoEventArgs-1.html#Syncfusion_Blazor_Gantt_PdfQueryTaskbarInfoEventArgs_1_LabelSettings) properties in the [PdfQueryTaskbarInfoEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.PdfQueryTaskbarInfoEventArgs-1.html) event.

> PDF Export supports base64 string to export the images.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using Syncfusion.PdfExport
@using System.Net.Http
@using System.IO

<SfGantt @ref="Gantt" ID="GanttExport" DataSource="@TaskCollection" Height="450px" Width="900px" AllowPdfExport="true" Toolbar="toolbarItem"
         ProjectStartDate="new DateTime(2022,03,28)" ProjectEndDate="new DateTime(2022,04,17)">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Dependency="Predecessor"
                     Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskID" HeaderText="Task Id" Width="100" HeaderTextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Task Name"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration"></GanttColumn>
        <GanttColumn Field="Predecessor" HeaderText="Dependency"></GanttColumn>
    </GanttColumns>
    <GanttLabelSettings TValue="TaskData">
        <RightLabelTemplate>
            @{
                if ((context as TaskData).TaskID == 5)
                {
                    <div class="e-right-label-inner-div" style="height:22px;margin-top:7px;">
                        <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png           </div>
                }
                else
                {
                    <div class="e-right-label-inner-div" style="height:22px;margin-top:7px;">
                        <span class="e-label">@((context as TaskData).TaskName)</span>
                    </div>
                }
            }
        </RightLabelTemplate>
        <LeftLabelTemplate>
            @if ((context as TaskData).TaskID == 2)
            {
                <div class="e-left-label-inner-div" style="height:22px;margin-top:7px;">
                    <span class="e-label">Updated Value</span>
                </div>
            }
            else
            {
                <div class="e-left-label-inner-div" style="height:22px;margin-top:7px;">
                    <span class="e-label">@((context as TaskData).TaskName)</span>
                </div>
            }
        </LeftLabelTemplate>
        <TaskLabelTemplate>
            @if ((context as TaskData).TaskID == 3)
            {
                <div class="e-task-label-inner-div" style="line-height:21px; height:22px;">
                    <span class="e-label" style="color:white;">-@((context as TaskData).Progress)%</span>
                </div>
            }
            else
            {
                <div class="e-task-label-inner-div" style="line-height:21px; height:22px;">
                    <span class="e-label" style="color:white;">@((context as TaskData).Progress)%</span>
                </div>
            }
        </TaskLabelTemplate>
    </GanttLabelSettings>
    <GanttEvents OnToolbarClick="ToolbarClickHandler" PdfQueryTaskbarInfo="PdfQueryTaskbarInfoHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    private List<TaskData> TaskCollection { get; set; }
    private SfGantt<TaskData> Gantt;
    private List<object> toolbarItem = new List<object>()
    {
        new Syncfusion.Blazor.Navigations.ToolbarItem()
        {
            Text = "PDF Export",
            TooltipText = "PDF Export",
            Id = "PdfExport",
            PrefixIcon = "e-pdfexport"
        }
    };

    public static PdfImage image;

    protected override async Task OnInitializedAsync()
    {
        this.TaskCollection = GetTaskCollection();

        using var httpClient = new HttpClient();
        var imageBytes = await httpClient.GetByteArrayAsync("https://cdn.syncfusion.com/content/images/landing-page/yes.png");
        var imageStream = new MemoryStream(imageBytes);
        image = PdfImage.FromStream(imageStream);
    }

    public async void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "PdfExport")
        {
            await Gantt.ExportToPdfAsync();
        }
    }

    public void PdfQueryTaskbarInfoHandler(PdfQueryTaskbarInfoEventArgs<TaskData> args)
    {
        if (args.Data.TaskID == 2)
        {
            args.LabelSettings.LeftLabelValue = "Updated Value";
        }
        else
        {
            args.LabelSettings.LeftLabelValue = args.Data.TaskName;
        }

        if (args.Data.TaskID == 5)
        {
            args.LabelSettings.RightLabel = new PdfElementStyle() { Image = image };
        }
        else
        {
            args.LabelSettings.RightLabelValue = args.Data.TaskName;
        }

        if (args.Data.TaskID == 3)
        {
            args.LabelSettings.TaskbarLabelValue = $"-{args.Data.Progress}%";
        }
        else
        {
            args.LabelSettings.TaskbarLabelValue = $"{args.Data.Progress}%";
        }
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
        public string Predecessor { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        return new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 21) },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentID = 1, Predecessor = "2" },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 , Predecessor = "3" },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 04, 21) },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 40, ParentID = 5 },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0", Progress = 30, ParentID = 5 }
        };
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtLyNOhefKeOHrhh?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Best practices for exporting PDF with templates

- **Optimize PdfQueryCellInfo event usage**: Use the `PdfQueryCellInfo` event to customize individual cell appearances efficiently. Minimize complex logic to maintain performance.

- **Utilize PdfColumnHeaderQueryCellInfo effectively**: Apply the `PdfColumnHeaderQueryCellInfo` event for custom header styles and content, focusing on clarity and readability.
- **Accessibility and clarity**: Keep header elements simple and accessible. Use straightforward text and icons to convey column purposes clearly.

- **Efficient use of PdfQueryTaskbarInfo**: Utilize the `PdfQueryTaskbarInfo` event to apply label customizations based on task data conditions for effective communication of task statuses.
- **Consistent label styling**: Ensure consistent theme across labels with uniform font styles, colors, and sizes.

### Image handling across events
- **Base64 and MemoryStream**: Convert images to Base64 strings, then use `MemoryStream` to convert them to `PdfImage`. This avoids reliance on potentially inaccessible web links.
- **Height and width management**: Scale images to fit designated areas to prevent default resizing that reflects cell or row heights. Maintain a professional PDF layout.
- **Compression and optimization**: Compress images prior to Base64 conversion to reduce file size while maintaining quality, optimizing the final PDF document size.

### Troubleshooting PDF export

1. **Customizations not appearing in PDF**
   - **Check event handler**: Ensure that the `PdfQueryTaskbarInfo` event is correctly implemented and bound in your code. Double-check the event handler's logic to verify that conditions for customization are being met.
   - **Data matching**: Ensure that the task data (like `TaskID`) used in the event matches the data in the task collection. Mismatches can prevent customizations from applying.

2. **Images not displaying**
   - **Image URL**: Verify that the image URLs are correct and accessible. Ensure that external images are hosted on a server with public access rights.
   - **Supported formats**: Use compatible image formats such as JPG, PNG, or GIF. Unsupported formats may not render correctly in a PDF.

3. **Performance issues**
   - **Optimize resources**: Large images or complex styling may slow down the PDF export process. Consider optimizing image size and simplifying styles.

4. **Color code customization**
    - **Use valid color codes**: You can use HEX (`#RRGGBB`), or standard color names like `red`, `blue`, etc. Ensure all color codes or names used are supported and valid.
   - **Consistency across styles**: Maintain consistent use of color codes in the styles to avoid unexpected color changes or conflicts during PDF rendering.