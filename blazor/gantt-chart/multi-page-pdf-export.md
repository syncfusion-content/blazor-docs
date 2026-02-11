---
layout: post
title: Multi-Page PDF Export with Scaling in Syncfusion Blazor Gantt Chart
description: Describes how to export the Blazor Gantt Chart to a multi-page PDF using various scaling modes.
platform: Blazor
control: Multi-Page with scaling in PDF Export
documentation: ug
---

# Multi-Page PDF Export with Scaling in Blazor Gantt Chart

The Syncfusion Blazor Gantt Chart provides support for exporting content across multiple PDF pages with configurable scaling options. These settings allow the chart layout to be distributed across pages while maintaining appropriate readability and structure. Multi‑page export behavior can be customized using the [GanttPdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportProperties.html) class.

## Enabling multi-page PDF export

The Blazor Gantt Chart supports exporting large or wide project timelines to PDF. By default, the export scales the entire chart to fit on a single page, which can reduce readability for extended projects. To improve this, enable multi-page export so the content automatically splits across multiple pages.

To export the Gantt Chart across multiple PDF pages, set the `enableMultiPage` property to **true** when calling the [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ExportToPdfAsync_Syncfusion_Blazor_Gantt_GanttPdfExportProperties_System_Boolean_) method.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids

<SfGantt @ref="GanttInstance" DataSource="@TaskCollection" Height="450px" Width="100%" AllowPdfExport="true" Toolbar="toolbarItem">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttEvents OnToolbarClick="ToolbarClickHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    public SfGantt<TaskData>? GanttInstance { get; set; } = new();
    private List<Syncfusion.Blazor.Navigations.ToolbarItem> toolbarItem = new List<Syncfusion.Blazor.Navigations.ToolbarItem>() { new Syncfusion.Blazor.Navigations.ToolbarItem() { Text = "PDF Export", TooltipText = "PDF Export", Id = "PdfExport", PrefixIcon = "e-pdfexport" } };
    private List<TaskData> TaskCollection = GetTaskCollection();

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

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args?.Item?.Id == "PdfExport")
        {
            GanttPdfExportProperties pdfExportProperties = new GanttPdfExportProperties{};
            // enables multi-page mode during PDF export.
            await GanttInstance.ExportToPdfAsync(pdfExportProperties, true); 
        }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXhnDBWiLWZgJOqk?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## PDF export scaling in Blazor Gantt Chart

The Syncfusion Blazor Gantt Chart supports two scaling options during PDF export to control how the chart content is resized to fit the generated PDF pages. These options are configured using the [GanttPdfExportScaleMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportScaleMode.html) enumeration.

* **FitToPages:** The [FitToPages](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportScaleMode.html) mode compresses the Gantt content so that it fits within a specified number of PDF pages.
  * This mode is used when the exported output must be restricted to a particular page count.
  * A uniform scale factor is automatically computed to ensure the content fits within the defined page limit while maintaining aspect ratio.
  * Using a very small page count results in reduced text and element sizes.

* **Percentage:** The [Percentage](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportScaleMode.html) mode applies a uniform percentage-based scale to the Gantt chart before pagination.
  * This mode is used when predictable downscaling is required, regardless of the number of pages generated.
  * The content is resized proportionally based on the specified percentage value.
  * After scaling, the content flows into multiple PDF pages if needed.

> * The `Percentage` scale mode maintains a fixed visual scaling factor. The final number of PDF pages is determined by the scaled content size and the configured page settings.
> * The `FitToPages` scale mode maintains a fixed page count. A suitable scale factor is automatically calculated to ensure the Gantt content fits within the specified number of pages.
> * Page size, orientation, and margin settings influence the scaling behavior and affect how the content is paginated in the exported PDF.

### Export Gantt Chart to PDF with page based scaling

The Blazor Gantt Chart supports scaling the exported PDF so that all columns fit within a specified number of pages horizontally, while rows continue across multiple pages vertically. This export mode is ideal when working with a large date range or many columns, where horizontal scrolling must be avoided and column widths need to remain readable.

To enable this behavior during PDF export:

- Set [ScaleMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.PdfMultiPageSettings.html#Syncfusion_Blazor_Gantt_PdfMultiPageSettings_ScaleMode) to [FitToPages](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportScaleMode.html) using [GanttPdfExportScaleMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportScaleMode.html) in [PdfExportEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.PdfExportEventArgs.html).
- Use [PageWide](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.PdfMultiPageSettings.html#Syncfusion_Blazor_Gantt_PdfMultiPageSettings_PageWide) to specify the target number of pages across which the chart should fit horizontally.
- Use [PageTall](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.PdfMultiPageSettings.html#Syncfusion_Blazor_Gantt_PdfMultiPageSettings_PageTall) to specify the target number of pages over which the content should span vertically.

These properties provide precise control over scaling and pagination, enabling clean and readable multi‑page PDF exports for large Gantt Charts.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations

<SfGantt @ref="GanttInstance" DataSource="@TaskCollection" Height="450px" Width="100%" AllowPdfExport="true" Toolbar="toolbarItem">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttEvents OnToolbarClick="ToolbarClickHandler" PdfExporting="PdfExportingHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    public SfGantt<TaskData>? GanttInstance { get; set; } = new();
    private List<ToolbarItem> toolbarItem = new List<ToolbarItem>() { new Syncfusion.Blazor.Navigations.ToolbarItem() { Text = "PDF Export", TooltipText = "PDF Export", Id = "PdfExport", PrefixIcon = "e-pdfexport" } };
    private List<TaskData> TaskCollection = GetTaskCollection();

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

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args?.Item?.Id == "PdfExport")
        {
            GanttPdfExportProperties pdfExportProperties = new GanttPdfExportProperties{};
            await GanttInstance.ExportToPdfAsync(pdfExportProperties, true);
        }
    }
    public async Task PdfExportingHandler(PdfExportEventArgs args)
    {
        if (args.MultiPageSettings?.TotalPages > 5)
        {
            args.MultiPageSettings.ScaleMode = GanttPdfExportScaleMode.FitToPages;
            args.MultiPageSettings.PageTall = 4;
            args.MultiPageSettings.PageWide = 2;
        }
        await Task.CompletedTask;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/htVnZrWChCgvrfHn?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Export Gantt Chart to PDF with custom scaling

The Blazor Gantt Chart supports percentage‑based scaling during PDF export, allowing the chart to be uniformly enlarged or reduced before pagination. This mode is useful when small, predictable adjustments to the chart size are required or when manual control over the scaling behavior is preferred instead of automatic fitting modes.

To configure percentage-based scaling during PDF export:

- Set [ScaleMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.PdfMultiPageSettings.html#Syncfusion_Blazor_Gantt_PdfMultiPageSettings_ScaleMode) to [Percentage](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportScaleMode.html) using [GanttPdfExportScaleMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportScaleMode.html) through [PdfExportEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.PdfExportEventArgs.html).
- Specify the desired scaling factor using the [ScalePercentage](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.PdfMultiPageSettings.html#Syncfusion_Blazor_Gantt_PdfMultiPageSettings_ScalePercentage) property.

This approach provides precise control over the overall chart size while preserving layout consistency across exported PDF pages.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations

<SfGantt @ref="GanttInstance" DataSource="@TaskCollection" Height="450px" Width="100%" AllowPdfExport="true" Toolbar="toolbarItem">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttEvents OnToolbarClick="ToolbarClickHandler" PdfExporting="PdfExportingHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    public SfGantt<TaskData>? GanttInstance { get; set; } = new();
    private List<ToolbarItem> toolbarItem = new List<ToolbarItem>() { new Syncfusion.Blazor.Navigations.ToolbarItem() { Text = "PDF Export", TooltipText = "PDF Export", Id = "PdfExport", PrefixIcon = "e-pdfexport" } };
    private List<TaskData> TaskCollection = GetTaskCollection();

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

    public async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args?.Item?.Id == "PdfExport")
        {
            GanttPdfExportProperties pdfExportProperties = new GanttPdfExportProperties{};
            await GanttInstance.ExportToPdfAsync(pdfExportProperties, true);
        }
    }
    public async Task PdfExportingHandler(PdfExportEventArgs args)
    {
        args.MultiPageSettings.ScaleMode = GanttPdfExportScaleMode.Percentage;
        args.MultiPageSettings.ScalePercentage = 50;
        await Task.CompletedTask;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VtrRNBMiLWxgQKBr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Limitations

* Split tasks are currently not exported.
* Unscheduled tasks are not included in the PDF output.
* Multiple taskbars for a single task are not supported in PDF export.