---
layout: post
title: Multipage and Scaling for PDF Export in Syncfusion Blazor Gantt Chart
description: Specification for enabling multipage PDF export, scaling modes, and header/footer alignment in the Blazor Gantt Chart PDF export.
platform: Blazor
control: PDF export scaling and multipage
documentation: ug
---

# Multipage and Scaling for PDF Export in Blazor Gantt Chart Component

This document outlines the proposed API and implementation details for enabling multi-page PDF export, flexible scaling, and header/footer alignment in the Blazor Gantt Chart component. These enhancements introduce a structured multi-page export workflow along with two scaling modes, providing greater control over how the Gantt chart is resized and paginated during PDF export using [GanttPdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportProperties.html).
To enable multi-page PDF export, set the `enableMultiPage` property to `true` when invoking the [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ExportToPdfAsync_Syncfusion_Blazor_Gantt_GanttPdfExportProperties_) method. By default, the enableMultiPage property is set to false, and the Gantt chart is exported as a single-page PDF.

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
    private List<object> toolbarItem = new List<Object>() { new Syncfusion.Blazor.Navigations.ToolbarItem() { Text = "PDF Export", TooltipText = "PDF Export", Id = "PdfExport", PrefixIcon = "e-pdfexport" } };
    private bool isFitToPage = true;
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

    public async Task ToolbarClickHandler(ClickEventArgs args)
    {
        if (args?.Item?.Id == "PdfExport")
        {
            var headerContent = new PdfHeaderFooterContent
            {
                Type = ContentType.Text,
                Value = "Gantt Chart PDF Export Header",
                Position = new PdfPosition { X = 0, Y = 20 },
                Style = new PdfContentStyle { FontSize = 14, HAlign = PdfHorizontalAlign.Center }
            };
            var footerContent = new PdfHeaderFooterContent
            {
                Type = ContentType.Text,
                Value = "Gantt Chart PDF Export Footer",
                Position = new PdfPosition { X = 0, Y = 20 },
                Style = new PdfContentStyle { FontSize = 12, HAlign = PdfHorizontalAlign.Center }
            };

            GanttPdfExportProperties pdfExportProperties = new GanttPdfExportProperties
            {
                Header = new PdfHeader { FromTop = 0, Height = 60, Contents = new List<PdfHeaderFooterContent> { headerContent } },
                Footer = new PdfFooter { FromBottom = 30, Height = 60, Contents = new List<PdfHeaderFooterContent> { footerContent } }
            };

            await GanttInstance.ExportToPdfAsync(pdfExportProperties, true);
        }
    }

    public async Task PdfExportingHandler(PdfExportEventArgs args)
    {
        if (isFitToPage)
        {
            if (args.MultiPageSettings?.TotalPages > 5)
            {
                args.MultiPageSettings.ScaleMode = GanttPdfExportScaleMode.FitToPages;
                args.MultiPageSettings.PageTall = 4;
                args.MultiPageSettings.PageWide = 2;
            }
        }
        else
        {
            args.MultiPageSettings.ScaleMode = GanttPdfExportScaleMode.Percentage;
            args.MultiPageSettings.ScalePercentage = 50;
        }
        await Task.CompletedTask;
    }
}

{% endhighlight %}
{% endtabs %}

## How to export Gantt chart with Scaling property

### Through FitToPages

Scale the Gantt chart so that columns fit across a specified number of pages, while rows flow vertically across multiple pages. This approach is ideal for scenarios with large time ranges or a high number of columns, where horizontal scrolling should be avoided and column widths must be preserved.

To enable this behavior during PDF export:

- Set `ScaleMode` to `FitToPages` using `GanttPdfExportScaleMode` in [PdfExportEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.PdfExportEventArgs.html).
- Use `PageWide` to specify the target number of pages across which the chart should fit horizontally.
- Use `PageTall` to specify the target number of pages over which the content should span vertically.

These properties provide precise control over how the Gantt chart is scaled and paginated during multi-page PDF export.

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
    private List<object> toolbarItem = new List<Object>() { new Syncfusion.Blazor.Navigations.ToolbarItem() { Text = "PDF Export", TooltipText = "PDF Export", Id = "PdfExport", PrefixIcon = "e-pdfexport" } };
    private bool isFitToPage = true;
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

    public async Task ToolbarClickHandler(ClickEventArgs args)
    {
        if (args?.Item?.Id == "PdfExport")
        {
            var headerContent = new PdfHeaderFooterContent
            {
                Type = ContentType.Text,
                Value = "Gantt Chart PDF Export Header",
                Position = new PdfPosition { X = 0, Y = 20 },
                Style = new PdfContentStyle { FontSize = 14, HAlign = PdfHorizontalAlign.Center }
            };
            var footerContent = new PdfHeaderFooterContent
            {
                Type = ContentType.Text,
                Value = "Gantt Chart PDF Export Footer",
                Position = new PdfPosition { X = 0, Y = 20 },
                Style = new PdfContentStyle { FontSize = 12, HAlign = PdfHorizontalAlign.Center }
            };

            GanttPdfExportProperties pdfExportProperties = new GanttPdfExportProperties
            {
                Header = new PdfHeader { FromTop = 0, Height = 60, Contents = new List<PdfHeaderFooterContent> { headerContent } },
                Footer = new PdfFooter { FromBottom = 30, Height = 60, Contents = new List<PdfHeaderFooterContent> { footerContent } }
            };

            await GanttInstance.ExportToPdfAsync(pdfExportProperties, true);
        }
    }

    public async Task PdfExportingHandler(PdfExportEventArgs args)
    {
        if (isFitToPage)
        {
            if (args.MultiPageSettings?.TotalPages > 5)
            {
                args.MultiPageSettings.ScaleMode = GanttPdfExportScaleMode.FitToPages;
                args.MultiPageSettings.PageTall = 4;
                args.MultiPageSettings.PageWide = 2;
            }
        }
        await Task.CompletedTask;
    }
}

{% endhighlight %}
{% endtabs %}

### Through Percentage

This scaling mode applies a fixed percentage to shrink or enlarge the rendered Gantt chart before pagination. It is useful when minor size adjustments are required or when predictable, manual scaling is preferred over automatic fitting.

To configure percentage-based scaling during PDF export:

- Set ScaleMode to Percentage using `GanttPdfExportScaleMode` through [PdfExportEventArgs](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.PdfExportEventArgs.html).
- Specify the desired scaling factor using the ScalePercentage property.

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
    private List<object> toolbarItem = new List<Object>() { new Syncfusion.Blazor.Navigations.ToolbarItem() { Text = "PDF Export", TooltipText = "PDF Export", Id = "PdfExport", PrefixIcon = "e-pdfexport" } };
    private bool isPercentage = true;
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

    public async Task ToolbarClickHandler(ClickEventArgs args)
    {
        if (args?.Item?.Id == "PdfExport")
        {
            var headerContent = new PdfHeaderFooterContent
            {
                Type = ContentType.Text,
                Value = "Gantt Chart PDF Export Header",
                Position = new PdfPosition { X = 0, Y = 20 },
                Style = new PdfContentStyle { FontSize = 14, HAlign = PdfHorizontalAlign.Center }
            };
            var footerContent = new PdfHeaderFooterContent
            {
                Type = ContentType.Text,
                Value = "Gantt Chart PDF Export Footer",
                Position = new PdfPosition { X = 0, Y = 20 },
                Style = new PdfContentStyle { FontSize = 12, HAlign = PdfHorizontalAlign.Center }
            };

            GanttPdfExportProperties pdfExportProperties = new GanttPdfExportProperties
            {
                Header = new PdfHeader { FromTop = 0, Height = 60, Contents = new List<PdfHeaderFooterContent> { headerContent } },
                Footer = new PdfFooter { FromBottom = 30, Height = 60, Contents = new List<PdfHeaderFooterContent> { footerContent } }
            };

            await GanttInstance.ExportToPdfAsync(pdfExportProperties, true);
        }
    }

    public async Task PdfExportingHandler(PdfExportEventArgs args)
    {
        if (isPercentage)
        {
            args.MultiPageSettings.ScaleMode = GanttPdfExportScaleMode.Percentage;
            args.MultiPageSettings.ScalePercentage = 50;
        }
        await Task.CompletedTask;
    }
}

{% endhighlight %}
{% endtabs %}
