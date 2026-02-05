---
layout: post
title: Multi-Page PDF Export with Scaling in Syncfusion Blazor Gantt Chart
description: Describes how to export the Blazor Gantt Chart to a multi-page PDF using various scaling modes.
platform: Blazor
control: Multi-Page with scaling in PDF Export
documentation: ug
---

# Multi-Page PDF Export with Scaling in Blazor Gantt Chart

Multi-page PDF export supports flexible scaling options, allowing the Gantt Chart to be distributed across multiple pages with precise control over how content is resized and paginated. Multi-page export and scaling behavior can be configured using the [GanttPdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportProperties.html) class.

## Enabling Multi-Page PDF Export

To export the Gantt Chart across multiple PDF pages, set the `enableMultiPage` property to `true` when calling the [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ExportToPdfAsync_Syncfusion_Blazor_Gantt_GanttPdfExportProperties_System_Boolean_) method.

- **Default behavior:** `enableMultiPage = false` exports the entire chart as a single-page PDF.
- **When enabled:** Content is automatically split across pages based on the selected scaling mode and page settings.

## Scaling

`Scaling` determines how the Gantt Chart is resized during PDF export to optimize visual presentation. It includes two different scaling modes.

- [FitToPages](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportScaleMode.html) – Compresses content to fit within a specified total number of PDF pages.  
  - Use this when you need the exported PDF to fit within a fixed page budget (e.g., 2 pages) for reporting or sharing.  
  - The exporter automatically computes a uniform scale factor so that the content fits within the target page count, preserving aspect ratio.  
  - If the specified number of pages is too small for legible output, text and UI elements may appear smaller.
- [Percentage](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportScaleMode.html) – Applies a percentage-based uniform scale to the entire chart before pagination.  
  - Use this when you want predictable downscaling (e.g., scale to 80%) while still allowing content to flow onto multiple pages as needed.  
  - Horizontal and vertical dimensions scale proportionally to the specified percentage.  
  - Pagination occurs after scaling is applied.

> **Notes**
> - `Percentage` prioritizes a known visual scale; page count is a result of content size and page settings.  
> - `FitToPages` prioritizes a known page count; scale is computed automatically to satisfy the target.  
> - Page size, orientation, and margins directly affect both scaling results and pagination.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations

<SfGantt @ref="GanttInstance" DataSource="@TaskCollection" Height="450px" Width="100%" AllowPdfExport="true" Toolbar="toolbarItem">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttEvents OnToolbarClick="ToolbarClickHandler" TValue="TaskData"></GanttEvents>
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
}

{% endhighlight %}
{% endtabs %}

## To export Gantt Chart with Scaling property

### Through FitToPages

Scale the Gantt Chart so that columns fit across a specified number of pages, while rows flow vertically across multiple pages. This approach is ideal for scenarios with large time ranges or a high number of columns, where horizontal scrolling should be avoided and column widths must be preserved.

To enable this behavior during PDF export:

- Set [ScaleMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.PdfMultiPageSettings.html#Syncfusion_Blazor_Gantt_PdfMultiPageSettings_ScaleMode) to [FitToPages](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportScaleMode.html) using [GanttPdfExportScaleMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportScaleMode.html) in [PdfExportEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.PdfExportEventArgs.html).
- Use [PageWide](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.PdfMultiPageSettings.html#Syncfusion_Blazor_Gantt_PdfMultiPageSettings_PageWide) to specify the target number of pages across which the chart should fit horizontally.
- Use [PageTall](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.PdfMultiPageSettings.html#Syncfusion_Blazor_Gantt_PdfMultiPageSettings_PageTall) to specify the target number of pages over which the content should span vertically.

These properties provide precise control over how the Gantt Chart is scaled and paginated during multi-page PDF export.

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

### Through Percentage

This scaling mode applies a fixed percentage to shrink or enlarge the rendered Gantt Chart before pagination. It is useful when minor size adjustments are required or when predictable, manual scaling is preferred over automatic fitting.

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

## Limitations

- Split tasks are not supported.
- Unscheduled tasks are not supported.
- Multi task bars are not supported.