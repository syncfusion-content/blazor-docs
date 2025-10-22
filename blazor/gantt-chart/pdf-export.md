---
layout: post
title: PDF Export in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about PDF Export in Syncfusion Blazor Gantt Chart component and much more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# PDF Export in Blazor Gantt Chart Component

The PDF export feature enables exporting Gantt chart data to a PDF document. To perform the export, use the [ExportToPdfAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ExportToPdfAsync) method. Ensure that PDF export is enabled in the Gantt chart component by setting the [AllowPdfExport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AllowPdfExport) property to true.

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
            await Gantt.ExportToPdfAsync();
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZLIsjZgrAtEMygE?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customize the PDF export

The PDF export functionality in the Syncfusion<sup style="font-size:70%">&reg;</sup> Gantt Chart provides extensive customization options through the [GanttPdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportProperties.html) class. By configuring the properties within this class, you can control the layout, format, and content of the exported PDF. This customization ensures that the PDF accurately represents the Gantt chart's structure and allows for tailored exports.

### Customize file name for exported document
The PDF export functionality in the Syncfusion<sup style="font-size:70%">&reg;</sup> Gantt Chart allows you to customize the file name of the exported document. By configuring the [FileName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_FileName) property within the [GanttPdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportProperties.html) class, you can assign a specific name to the generated PDF. This is especially useful for keeping your exported documents organized and easily identifiable.

In this example, the exported PDF will be saved as `ProjectSchedule.pdf`.

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

### How to add a text in header/footer

The PDF export functionality of the Gantt Chart allows you to add and style custom text in the header or footer of the exported PDF document. This customization can be achieved using the [Header](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_Header) and [Footer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_Footer) properties of the [GanttPdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportProperties.html) class. By configuring these properties, you can include important information, such as titles, project names, or other relevant details, to enhance the exported document.

The following sample code demonstrates how to add custom text and apply styling to the header and footer sections of the exported PDF document,

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
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
    public List<PdfHeaderFooterContent> HeaderContent = new List<PdfHeaderFooterContent>
    {
        new PdfHeaderFooterContent() { Type = ContentType.Text, Value = "Gantt Chart PDF Export Header", Position = new PdfPosition() { X = 0, Y = 50 }, Style = new PdfContentStyle() { TextBrushColor = "#000000", FontSize = 13 } }
    };
    public List<PdfHeaderFooterContent> FooterContent = new List<PdfHeaderFooterContent>
    {
        new PdfHeaderFooterContent() { Type = ContentType.Text, Value = "Gantt Chart PDF Export Footer", Position = new PdfPosition() { X = 0, Y = 350 }, Style = new PdfContentStyle() { TextBrushColor = "#000000", FontSize = 13 } }
    };
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }
    public async void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "PdfExport")
        {
            GanttPdfExportProperties exportProperties = new GanttPdfExportProperties();
            PdfHeader Header = new PdfHeader()
                {
                    FromTop = 0,
                    Height = 100,
                    Contents = HeaderContent
                };
            PdfFooter Footer = new PdfFooter()
                {
                    FromBottom = 250,
                    Height = 100,
                    Contents = FooterContent
                };
            exportProperties.Header = Header;
            exportProperties.Footer = Footer;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDhyiDXArUzpgPqb?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### How to draw a line in header/footer

You can add lines to the Header or Footer area of the exported PDF document using the [Header](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_Header) and [Footer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_Footer) properties in the [GanttPdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportProperties.html) class.

Supported line styles are,

* Dash
* Dot
* DashDot
* DashDotDot
* Solid

The following sample code demonstrates adding line in the Header and Footer section of the exported document,

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
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
    public List<PdfHeaderFooterContent> HeaderContent = new List<PdfHeaderFooterContent>
    {
        new PdfHeaderFooterContent() { Type = ContentType.Line, Points = new PdfPoints() { X1 = 0, Y1 = 4, X2 = 685, Y2 = 4 }, Style = new PdfContentStyle() { PenColor = "#000080", DashStyle = PdfDashStyle.Solid } }
    };
    public List<PdfHeaderFooterContent> FooterContent = new List<PdfHeaderFooterContent>
    {
        new PdfHeaderFooterContent() { Type = ContentType.Line, Points = new PdfPoints() { X1 = 0, Y1 = 350, X2 = 685, Y2 = 350 }, Style = new PdfContentStyle() { PenColor = "#000080", DashStyle = PdfDashStyle.Solid } }
    };
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }
    public async void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "PdfExport")
        {
            GanttPdfExportProperties exportProperties = new GanttPdfExportProperties();
            PdfHeader Header = new PdfHeader()
                {
                    FromTop = 0,
                    Height = 100,
                    Contents = HeaderContent
                };
            PdfFooter Footer = new PdfFooter()
                {
                    FromBottom = 250,
                    Height = 100,
                    Contents = FooterContent
                };
            exportProperties.Header = Header;
            exportProperties.Footer = Footer;
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZBIWtXKVKPSwLAW?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### How to change the page orientation

The PDF export functionality allows you to customize the page orientation of the exported document. By setting the [PageOrientation](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_PageOrientation) property in the [GanttPdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportProperties.html) class, you can choose between [Portrait](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PageOrientation.html#Syncfusion_Blazor_Grids_PageOrientation_Portrait) (default) and [Landscape](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PageOrientation.html#Syncfusion_Blazor_Grids_PageOrientation_Landscape) orientations based on your requirements.

The following code snippet demonstrates how to set the page orientation to Landscape for the exported PDF document,

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

### How to change the page size

The PDF export functionality allows you to customize the page size of the exported document to suit your needs. By setting the [PageSize](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfPageSize.html) property in the [GanttPdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportProperties.html) class, you can select from various standard page sizes. The default page size is Letter, but other options like A4, A3, and others.

Supported page sizes are:
* Letter
* Note
* Legal
* A0
* A1
* A2
* A3
* A5
* A6
* A7
* A8
* A9
* B0
* B1
* B2
* B3
* B4
* B5
* Archa
* Archb
* Archc
* Archd
* Arche
* Flsa
* HalfLetter
* Letter11x17
* Ledger

The following code demonstrates how to change the page size to A4 for the exported PDF document,

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

### Export current view records

The PDF export functionality allows you to export only the records that are currently in view on the Gantt chart to a PDF document. This can be achieved by enabling the [IsCurrentViewExport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.PdfExportEventArgs.html#Syncfusion_Blazor_Gantt_PdfExportEventArgs_IsCurrentViewExport) boolean argument in the [PdfExporting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_PdfExporting) event.

N> Exporting current view records is only applicable when the virtualization feature is enabled, and it does not retain the state of collapsed rows during export.

The following code demonstrates how to use the `PdfExporting` event to export current view data of the Gantt chart to a PDF document,

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

### How to export Gantt chart with custom timeline range

The PDF export functionality allows you to export with custom timeline range of the Gantt chart to the PDF document. To specify the range, set the [RangeStart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.PdfExportEventArgs.html#Syncfusion_Blazor_Gantt_PdfExportEventArgs_RangeStart) and [RangeEnd](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.PdfExportEventArgs.html#Syncfusion_Blazor_Gantt_PdfExportEventArgs_RangeEnd) arguments within the [PdfExporting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_PdfExporting) event. The `RangeStart` argument defines the start date, and the `RangeEnd` argument defines the end date of the timeline range.

The following code demonstrates how to use the `RangeStart` and `RangeEnd` arguments of the PdfExporting event to export a custom timeline range of the Gantt chart to a PDF document,

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

### Export hidden columns

The PDF export functionality allows you to include hidden columns from the Gantt chart in the exported PDF document. To achieve this, set the [IncludeHiddenColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_IncludeHiddenColumn) property to true within the [GanttPdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportProperties.html) class. This ensures that columns not visible in the Gantt chart are included in the PDF export.

The following code demonstrates how to export hidden columns in the Gantt chart to a PDF document,

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

### Customize column width in exported PDF document

The PDF export functionality allows you to customize the width of columns in the exported PDF document. This can be achieved using the [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html#Syncfusion_Blazor_Gantt_GanttColumn_Width) property in the [GanttColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html) class. By specifying the width for each column, you can tailor the appearance of the exported PDF to your requirements.

The following code snippet demonstrates how to customize column widths in the exported PDF document using the [Columns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportProperties.html#Syncfusion_Blazor_Gantt_GanttPdfExportProperties_Columns) property of the [GanttPdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportProperties.html) class,

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

### Through property

The PDF export functionality allows you to customize the appearance of taskbars in the exported PDF document using the [TaskbarColor](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.PdfGanttStyle.html#Syncfusion_Blazor_Gantt_PdfGanttStyle_TaskbarColor) property in the [GanttPdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportProperties.html) class. This property enables you to set colors for various types of taskbars, including:

* Parent Taskbars
* Child Taskbars
* Milestones
* Critical Paths
* Manual Taskbars
* Baselines

By configuring the TaskbarColor property, you can format these taskbars to match your desired color scheme. The following code snippet demonstrates how to use the `TaskbarColor` property to customize the colors of different taskbars in the exported PDF document,

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

The PDF export functionality allows you to customize the appearance of taskbars in the exported PDF document using the [PdfQueryTaskbarInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_PdfQueryTaskbarInfo) event. This event provides the flexibility to customize and format the appearance of taskbars, including parent taskbars, individual taskbars, and milestone templates.

The following code snippet demonstrates how to use the `PdfQueryTaskbarInfo` event to customize the appearance of taskbars in the exported PDF document,

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

## Events triggered during exporting

When exporting the Gantt chart to a PDF document, a series of events are triggered in a specific order, allowing for advanced customization of the export process. Understanding this flow is essential to control and modify the exported content effectively. Below is the flow of events that occur during PDF export in the Gantt chart:

* [PdfExporting](https://blazor.syncfusion.com/documentation/gantt-chart/events)
* [PdfQueryTimelineCellInfo](https://blazor.syncfusion.com/documentation/gantt-chart/events)
* [PdfColumnHeaderQueryCellInfo](https://blazor.syncfusion.com/documentation/gantt-chart/events)
* [PdfQueryCellInfo](https://blazor.syncfusion.com/documentation/gantt-chart/events)
* [PdfQueryTaskbarInfo](https://blazor.syncfusion.com/documentation/gantt-chart/events)
* [PdfExported](https://blazor.syncfusion.com/documentation/gantt-chart/events)
