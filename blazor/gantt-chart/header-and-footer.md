---
layout: post
title: PDF Headers and Footers in Syncfusion Blazor Gantt Chart Component
description: Learn how to customize headers and footers in PDF exports of the Syncfusion Blazor Gantt Chart component with text, lines, page numbers, and images.
platform: Blazor
control: header and footer of PDF exporting
documentation: ug
---

# Header and Footer of PDF Exporting in Blazor Gantt Chart Component

Customizing headers and footers in PDF exports of the Blazor Gantt Chart component allows adding text, lines, page numbers, and images to enhance document professionalism for projects. Use [GanttPdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportProperties.html) with [Header](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_Header) and [Footer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_Footer) to define content arrays, specifying `Type` (e.g., Text, Line), `Value`, `Position`, `Style`, or `Src` for images with `Base64` encoding.

## Adding text in header and footer

The Syncfusion Blazor Gantt Chart allows you to add custom text to the header and footer sections when exporting the Gantt content to PDF.

* The **header** appears at the top of each exported page and is typically used to display a document title, company branding, logos, dates, or other identifying information.
* The **footer** appears at the bottom of each page and commonly includes page numbers, copyright notices, disclaimers, or similar supporting details.

Header and footer text can be customized using the [Header](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_Header) and [Footer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_Footer) properties available in [GanttPdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportProperties.html). To display text within the header or footer:

- Set the `Type` property to `Text` to indicate that the element displays textual content.
- Use the `Value` property to define the text you want to show, such as titles, page labels, or metadata.
- Set the `Position` property to specify the **X** and **Y** coordinates for the text placement inside the header or footer area.

### Styling the text

The appearance of the header or footer text can be customized using the `Style` property. The following styling options are supported:

* **DashStyle**: Defines the dash pattern applied to the text element.
* **FontSize**: Specifies the size of the text.
* **HAlign**: Determines the horizontal alignment of the text. Supported values include `Left`, `Center`, `Right`, and `Justify`.
* **VAlign**: Determines the vertical alignment of the text. Supported values include `Top`, `Middle`, and `Bottom`.
* **PenColor**: Sets the color of the pen used to outline the text.
* **PenSize**: Sets the thickness of the pen used for outlining.
* **TextBrushColor**: Specifies the fill color used to render the text.
* **TextPenColor**: Specifies the outline color applied to the text.

These style options allow full control over text color, size, alignment, and appearance. The [HAlign](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfContentStyle.html#Syncfusion_Blazor_Grids_PdfContentStyle_HAlign) property is especially useful for aligning text horizontally within the header or footer area, ensuring a consistent and professional layout in the exported PDF.

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
        new PdfHeaderFooterContent() { Type = ContentType.Text, Value = "Gantt Chart PDF Export Header", Position = new PdfPosition() { X = 0, Y = 50 }, Style = new PdfContentStyle() { TextBrushColor = "#000000", FontSize = 13, HAlign = PdfHorizontalAlign.Center } }
    };
    public List<PdfHeaderFooterContent> FooterContent = new List<PdfHeaderFooterContent>
    {
        new PdfHeaderFooterContent() { Type = ContentType.Text, Value = "Gantt Chart PDF Export Footer", Position = new PdfPosition() { X = 0, Y = 350 }, Style = new PdfContentStyle() { TextBrushColor = "#000000", FontSize = 13, HAlign = PdfHorizontalAlign.Center } }
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

## Draw a line in header and footer

Customize lines in headers or footers using the [Header](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_Header) and [Footer](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.PdfExportPropertiesBase.html#Syncfusion_Blazor_Grids_PdfExportPropertiesBase_Footer) properties in [GanttPdfExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttPdfExportProperties.html). To draw a line:

* Set the `Type` property to **Line**.
* Use the `Points` property to define the start and end coordinates of the line.
* Specify the `PageNumberType` property to determine where the line should appear.
* Configure the `Style` property to customize color, width, and dash pattern.
 
These options provide flexibility for adding separators or visual structure to the header and footer areas in the exported PDF.

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

## See also
- [How to export to PDF?](https://blazor.syncfusion.com/documentation/gantt-chart/pdf-export)
- [How to manage task dependencies?](https://blazor.syncfusion.com/documentation/gantt-chart/task-dependencies)