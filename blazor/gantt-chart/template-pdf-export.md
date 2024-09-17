---
layout: post
title: PDF Exporting with templates in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about PDF Exporting with templates in Syncfusion Blazor Gantt Chart component and much more.
platform: Blazor
control: Gantt Chart
documentation: ug
---


# Exporting PDF with templates

## Exporting with column template

The PDF export functionality allows exporting Grid columns that include images, background color, and custom text to a PDF document using the [PdfQueryCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_PdfQueryCellInfo) event.

In the following sample, custom text and different cell background colors are exported to PDF using the `Font` and `FillBackgroundColor` properties in the `PdfQueryCellInfo` event.

```cshtml
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using Syncfusion.PdfExport

<SfGantt @ref="Gantt" ID="GanttExport" DataSource="@TaskCollection" Height="450px" Width="900px" AllowPdfExport="true" Toolbar="toolbarItem">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Dependency="Predecessor"
                     Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskId" HeaderText="TaskId" Width="100" HeaderTextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="TaskName"></GanttColumn>
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
    private List<object> toolbarItem = new List<Object>() { new ToolbarItem() { Text = "PDF Export", TooltipText = "PDF Export", Id = "PdfExport", PrefixIcon = "e-pdfexport" } };
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
        if (args.Column.Field == "TaskName" && args.Data.TaskId == 5)
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
            args.Cell.CellStyle.Border = new PdfBorder()
            {
                Color = "Black",
                DashStyle = Syncfusion.Blazor.Grids.PdfDashStyle.Dot,
                Width = 0.1
            };
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
        public string Predecessor { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 21), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentId = 1, Predecessor = "2" },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentId = 1 , Predecessor = "3" },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 04, 21), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 40, ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0", Progress = 30, ParentId = 5 }
        };
        return Tasks;
    }
}
```

## Exporting with taskbar template with event

The PDF export functionality allows to export taskbar templates to an PDF document using [PdfQueryTaskbarInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_PdfQueryTaskbarInfo) event. Taskbar in the exported PDF document can be customized or formatted using the pdfQueryTaskbarInfo event for parent taskbar template, taskbar templates and milestone templates.

``` cshtml
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using Syncfusion.PdfExport

<SfGantt @ref="Gantt" ID="GanttExport" DataSource="@TaskCollection" Height="450px" Width="900px" AllowPdfExport="true" Toolbar="toolbarItem">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Dependency="Predecessor"
                     Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskId" HeaderText="TaskId" Width="100" HeaderTextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="TaskName"></GanttColumn>
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
    private List<object> toolbarItem = new List<Object>() { new ToolbarItem() { Text = "PDF Export", TooltipText = "PDF Export", Id = "PdfExport", PrefixIcon = "e-pdfexport" } };
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
        if (args.Data.TaskId == 3)
        {
            args.TaskbarStyle.Color = new PdfTaskbarColor();
            args.TaskbarStyle.Color.ChildProgressColor = new Syncfusion.PdfExport.PdfColor(103, 80, 164);
            args.TaskbarStyle.Color.ChildTaskbarColor = new Syncfusion.PdfExport.PdfColor(141, 124, 187);
        }
        if (args.Data.TaskId == 4)
        {
            args.TaskbarStyle.Color = new PdfTaskbarColor();
            args.TaskbarStyle.Color.MilestoneColor = new Syncfusion.PdfExport.PdfColor(103, 80, 164);
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
        public string Predecessor { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 21), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentId = 1, Predecessor = "2" },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentId = 1 , Predecessor = "3" },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 04, 21), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 40, ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0", Progress = 30, ParentId = 5 }
        };
        return Tasks;
    }
}
```

## Exporting with taskbar template with export properties

The PDF export functionality allows exporting taskbar templates to a PDF document using the `TaskbarColor` export property. The taskbar in the exported PDF document can be customized or formatted using the `TaskbarColor` property in `GanttPdfExportProperties` for parent taskbar color, child taskbar color, milestone color, critical path color, manual taskbar color, and baseline color.

``` cshtml
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using Syncfusion.PdfExport

<SfGantt @ref="Gantt" ID="GanttExport" DataSource="@TaskCollection" Height="450px" Width="900px" AllowPdfExport="true" Toolbar="toolbarItem" EnableCriticalPath="true"
                     RenderBaseline="true">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" BaselineStartDate="BaselineStartDate" BaselineEndDate="BaselineEndDate"
                     Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskId" HeaderText="TaskId" Width="100" HeaderTextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="TaskName"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration"></GanttColumn>
    </GanttColumns>
    <GanttEvents OnToolbarClick="ToolbarClickHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    private List<TaskData> TaskCollection { get; set; }
    private SfGantt<TaskData> Gantt;
    private List<object> toolbarItem = new List<Object>() { new ToolbarItem() { Text = "PDF Export", TooltipText = "PDF Export", Id = "PdfExport", PrefixIcon = "e-pdfexport" } };
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
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime? BaselineStartDate { get; set; }
        public DateTime? BaselineEndDate { get; set; }
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
            new TaskData() { TaskId = 1, TaskName = "Project initiation", BaselineStartDate = new DateTime(2021, 04, 02), BaselineEndDate = new DateTime(2021, 04, 04), StartDate = new DateTime(2021, 04, 02), EndDate = new DateTime(2021, 04, 06) },
            new TaskData() { TaskId = 2, TaskName = "Identify site location", StartDate = new DateTime(2021, 04, 02), EndDate = new DateTime(2021, 04, 02), Duration = "0", BaselineStartDate = new DateTime(2021, 04, 02), BaselineEndDate = new DateTime(2021, 04, 02), Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2021, 04, 02), Duration = "5", Progress = 40, BaselineStartDate = new DateTime(2021, 04, 02), BaselineEndDate = new DateTime(2021, 04, 06), ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2021, 04, 08), Duration = "0", EndDate = new DateTime(2021, 04, 08), BaselineStartDate = new DateTime(2021, 04, 08), BaselineEndDate = new DateTime(2021, 04, 08), Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project initiation", StartDate = new DateTime(2021, 04, 02), EndDate = new DateTime(2021, 04, 08) },
            new TaskData() { TaskId = 6, TaskName = "Identify site location", StartDate = new DateTime(2021, 04, 02), Duration = "2", Progress = 30, ParentId = 5, BaselineStartDate = new DateTime(2021, 04, 02), BaselineEndDate = new DateTime(2021, 04, 02) },
            new TaskData() { TaskId = 7, TaskName = "Perform soil test", StartDate = new DateTime(2021, 04, 02), Duration = "4", Progress = 40, ParentId = 5, BaselineStartDate = new DateTime(2021, 04, 02), BaselineEndDate = new DateTime(2021, 04, 03) },
            new TaskData() { TaskId = 8, TaskName = "Soil test approval", StartDate = new DateTime(2021, 04, 02), Duration = "5", Progress = 30, ParentId = 5, BaselineStartDate = new DateTime(2021, 04, 02), BaselineEndDate = new DateTime(2021, 04, 04) }
        };
        return Tasks;
    }
}
```