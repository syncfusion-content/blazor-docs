---
layout: post
title: PDF Export in Blazor Gantt Chart Component | Syncfusion
description: Export Gantt charts to PDF in Syncfusion Blazor Gantt with blob objects, single-page layouts, themes, and advanced customization options.
platform: Blazor
control: PDF export
documentation: ug
---

# PDF Export in Blazor Gantt Chart Component

The PDF export feature enables exporting Blazor Gantt chart data to a PDF document. To perform the export, use the [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ExportToPdfAsync_Syncfusion_Blazor_Gantt_GanttPdfExportProperties_) method. Ensure that PDF export is enabled in the Gantt chart component by setting the [AllowPdfExport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AllowPdfExport) property to true.
PDF export in the Blazor Gantt Chart component enables exporting project data to PDF documents for sharing or archiving, using the [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ExportToPdfAsync_Syncfusion_Blazor_Gantt_GanttPdfExportProperties_) method. with [AllowPdfExport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AllowPdfExport) set to **true**. This feature supports exporting timelines, tasks, and dependencies, with options for indicators via `base64` images, blob objects for previews, single-page layouts, multiple Gantt instances in one file, and themes like Material or Bootstrap. Focus on auto-scheduled tasks for accurate export, as manual scheduling is not currently supported.

## Export basic Gantt data

Export Gantt data to PDF by setting [AllowPdfExport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AllowPdfExport) to**true** and calling [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ExportToPdfAsync_Syncfusion_Blazor_Gantt_GanttPdfExportProperties_), which generates a document with the chart and tree-grid data.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Navigations

<SfGantt @ref="Gantt" ID="GanttExport" DataSource="@TaskCollection" Height="450px" Width="900px" AllowPdfExport="true" Toolbar="toolbarItem">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" 
                     Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttEvents OnToolbarClick="ToolbarClickHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    public List<TaskData> TaskCollection { get; set; }
    public SfGantt<TaskData> Gantt;
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
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 09), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30,  ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 09), ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 04, 13), EndDate = new DateTime(2026, 04, 21), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 30,ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 04, 07), Duration = "0", ParentId = 5 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BjVnjxWxUvLyVuIn?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Events triggered during exporting

When exporting the Gantt chart to a PDF document, a series of events are triggered in a specific order, allowing for advanced customization of the export process. Understanding this flow is essential for effectively controlling and modifying the exported content. Below is the sequence of events that occur during PDF export in the Gantt chart:

* [PdfExporting](https://blazor.syncfusion.com/documentation/gantt-chart/events#pdfexporting)

* [PdfQueryTimelineCellInfo](https://blazor.syncfusion.com/documentation/gantt-chart/events#pdfquerytimelinecellinfo)

* [PdfColumnHeaderQueryCellInfo](https://blazor.syncfusion.com/documentation/gantt-chart/events#pdfcolumnheaderquerycellinfo)

* [PdfQueryCellInfo](https://blazor.syncfusion.com/documentation/gantt-chart/events#pdfquerycellinfo)

* [PdfQueryTaskbarInfo](https://blazor.syncfusion.com/documentation/gantt-chart/events#pdfquerytaskbarinfo)

* [PdfExported](https://blazor.syncfusion.com/documentation/gantt-chart/events#pdfexported)