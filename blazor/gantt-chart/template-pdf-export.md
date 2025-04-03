---
layout: post
title: PDF Export with templates in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about PDF Exporting with templates in Syncfusion Blazor Gantt Chart component and much more.
platform: Blazor
control: Gantt Chart
documentation: ug
---


# Exporting PDF with templates

The Gantt chart export functionality allows you to export both column and header templates to a PDF document. These templates can include various customizations such as images, formatted text, and custom cell styles within the header and columns. 

## Exporting with column template

The PDF export functionality allows for advanced customization of Gantt chart columns, including the inclusion of images, background colors, and custom text. This can be achieved using the [PdfQueryCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_PdfQueryCellInfo) event. By handling this event, you can define how individual cells in the Gantt chart are rendered in the exported PDF.

The following code snippet demonstrates how to use the `PdfQueryCellInfo` event to export Gantt columns with custom text and different cell background colors,

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
        <GanttColumn Field="TaskId" HeaderText="Task Id" Width="100" HeaderTextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
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

## Exporting with column header template

The PDF export functionality allows for customization of Gantt chart columns header, including the inclusion of images, background colors, and custom text. This can be achieved using the [PdfColumnHeaderQueryCellInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_PdfColumnHeaderQueryCellInfo) event. By handling this event, you can define how each column header in the Gantt chart is rendered in the exported PDF.

The following code snippet demonstrates how to use the `PdfColumnHeaderQueryCellInfo` event to export Gantt columns header with custom text and image on the task name column header,

``` cshtml
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using Syncfusion.PdfExport
@using System.Net

<SfGantt @ref="Gantt" ID="GanttExport" DataSource="@TaskCollection" Height="450px" Width="900px" AllowPdfExport="true" Toolbar="toolbarItem">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Dependency="Predecessor"
                     Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskId" HeaderText="Task Id" Width="100" HeaderTextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Task Name"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration"></GanttColumn>
        <GanttColumn Field="Predecessor" HeaderText="Dependency"></GanttColumn>
    </GanttColumns>
    <GanttEvents OnToolbarClick="ToolbarClickHandler" PdfColumnHeaderQueryCellInfo="PdfHeaderQueryCellInfoHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    private List<TaskData> TaskCollection { get; set; }
    private SfGantt<TaskData> Gantt;
    private List<object> toolbarItem = new List<Object>() { new ToolbarItem() { Text = "PDF Export", TooltipText = "PDF Export", Id = "PdfExport", PrefixIcon = "e-pdfexport" } };
    private static WebClient webClient = new WebClient();
    private static byte[] imageBytes = webClient.DownloadData("https://cdn.syncfusion.com/content/images/landing-page/yes.png");
    private static MemoryStream imageStream = new MemoryStream(imageBytes);
    public static PdfImage image = PdfImage.FromStream(imageStream);
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
    public void PdfHeaderQueryCellInfoHandler(Syncfusion.Blazor.Gantt.PdfHeaderQueryCellInfoEventArgs args)
    {
        if (args.Column.Field == "TaskName")
        {
            args.Cell.Value = "Updated Value";
            args.Cell.CellStyle = new PdfElementStyle() { Image = image};
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
## Custom label for Gantt Chart PDF export

The PDF export feature of the Gantt chart allows for detailed customization of labels such as right label, left label, and task label. This functionality includes the ability to include images, change background colors, and add custom text. These customizations are managed using the [PdfQueryTaskbarInfo](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_PdfQueryTaskbarInfo) event. By handling this event, you can specify how each label in the Gantt chart will appear in the exported PDF. 

The following example demonstrates how to implement the `PdfQueryTaskbarInfo` event to customize the PDF export of Gantt chart labels with specific text and images,
``` cshtml
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations
@using Syncfusion.PdfExport
@using System.Net

<SfGantt @ref="Gantt" ID="GanttExport" DataSource="@TaskCollection" Height="450px" Width="900px" AllowPdfExport="true" Toolbar="toolbarItem"
         ProjectStartDate="new DateTime(2022,03,28)" ProjectEndDate="new DateTime(2022,04,17)">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Dependency="Predecessor"
                     Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskId" HeaderText="Task Id" Width="100" HeaderTextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Task Name"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration"></GanttColumn>
        <GanttColumn Field="Predecessor" HeaderText="Dependency"></GanttColumn>
    </GanttColumns>
    <GanttLabelSettings TValue="TaskData">
        <RightLabelTemplate>
            @{
                @if ((context as TaskData).TaskId == 5)
                {
                    <div class="e-right-label-inner-div" style="height:22px;margin-top:7px;">
                        <img src="https://cdn.syncfusion.com/content/images/landing-page/yes.png" />
                    </div>
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
            @if ((context as TaskData).TaskId == 2)
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
            @if ((context as TaskData).TaskId == 3)
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
    private List<object> toolbarItem = new List<Object>() { new ToolbarItem() { Text = "PDF Export", TooltipText = "PDF Export", Id = "PdfExport", PrefixIcon = "e-pdfexport" } };
    private static WebClient webClient = new WebClient();
    private static byte[] imageBytes = webClient.DownloadData("https://cdn.syncfusion.com/content/images/landing-page/yes.png");
    private static MemoryStream imageStream = new MemoryStream(imageBytes);
    public static PdfImage image = PdfImage.FromStream(imageStream);
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
        if (args.Data.TaskId == 2)
        {
            args.LabelSettings.LeftLabelValue = "Updated Value";
        }
        else
        {
            args.LabelSettings.LeftLabelValue = args.Data.TaskName;
        }

        if (args.Data.TaskId == 5)
        {
            args.LabelSettings.RightLabel = new PdfElementStyle() { Image = image };
        }
        else
        {
            args.LabelSettings.RightLabelValue = args.Data.TaskName;
        }
        if (args.Data.TaskId == 3)
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
## Best practices for exporting PDF with templates

- **Optimize PdfQueryCellInfo event usage**: Use the `PdfQueryCellInfo` event to customize individual cell appearances efficiently. Minimize complex logic to maintain performance.

- **Utilize PdfColumnHeaderQueryCellInfo effectively**: Apply the `PdfColumnHeaderQueryCellInfo` event for custom header styles and content, focusing on clarity and readability.
- **Accessibility and clarity**: Keep header elements simple and accessible. Use straightforward text and icons to convey column purposes clearly.

- **Efficient use of PdfQueryTaskbarInfo**: Utilize the `PdfQueryTaskbarInfo` event to apply label customizations based on task data conditions for effective communication of task statuses.
- **Consistent label styling**: Ensure consistent theme across labels with uniform font styles, colors, and sizes.

## Image handling across events
- **Base64 and MemoryStream**: Convert images to Base64 strings, then use `MemoryStream` to convert them to `PdfImage`. This avoids reliance on potentially inaccessible web links.
- **Height and width management**: Scale images to fit designated areas to prevent default resizing that reflects cell or row heights. Maintain a professional PDF layout.
- **Compression and optimization**: Compress images prior to Base64 conversion to reduce file size while maintaining quality, optimizing the final PDF document size.

## Troubleshooting PDF export

1. **Customizations not appearing in PDF**
   - **Check event handler**: Ensure that the `PdfQueryTaskbarInfo` event is correctly implemented and bound in your code. Double-check the event handler's logic to verify that conditions for customization are being met.
   - **Data matching**: Ensure that the task data (like `TaskId`) used in the event matches the data in the task collection. Mismatches can prevent customizations from applying.

2. **Images not displaying**
   - **Image URL**: Verify that the image URLs are correct and accessible. Ensure that external images are hosted on a server with public access rights.
   - **Supported formats**: Use compatible image formats such as JPG, PNG, or GIF. Unsupported formats may not render correctly in a PDF.

3. **Performance issues**
   - **Optimize resources**: Large images or complex styling may slow down the PDF export process. Consider optimizing image size and simplifying styles.

4. **Color code customization**
    - **Use valid color codes**: You can use HEX (`#RRGGBB`), or standard color names like `red`, `blue`, etc. Ensure all color codes or names used are supported and valid.
   - **Consistency across styles**: Maintain consistent use of color codes in the styles to avoid unexpected color changes or conflicts during PDF rendering.