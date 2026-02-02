---
layout: post
title: Excel Export in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about Excel Export in Syncfusion Blazor Gantt Chart component and much more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Excel Export in Blazor Gantt Chart Component

The Syncfusion Blazor Gantt Chart component supports exporting project data to Excel and CSV formats, enabling seamless sharing, reporting, and offline analysis.  
 
To enable Excel or CSV export functionality, set the [AllowExcelExport](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AllowExcelExport) property to **true**.

You can trigger export operations using the [ExportToExcelAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ExportToExcelAsync_Syncfusion_Blazor_Grids_ExcelExportProperties_) or [ExportToCsvAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ExportToCsvAsync_Syncfusion_Blazor_Grids_ExcelExportProperties_) methods, typically within the [OnToolbarClick](https://blazor.syncfusion.com/documentation/gantt-chart/events#ontoolbarclick) event.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt ID="GanttContainer" @ref="Gantt" AllowExcelExport="true" Toolbar="@(new List<string>() { "ExcelExport", "CsvExport" })" DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" Dependency="Predecessor" ParentID="ParentID"></GanttTaskFields>
    <GanttEvents OnToolbarClick="ToolbarClickHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

@code{
    public SfGantt<TaskData> Gantt;
    private List<TaskData> TaskCollection { get; set; }

    public void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "GanttContainer_excelexport")
        {
            this.Gantt.ExportToExcelAsync();
        }
        else if (args.Item.Id == "GanttContainer_csvexport")
        {
            this.Gantt.ExportToCsvAsync();
        }
    }
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    public class TaskData
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public string Predecessor { get; set; }
        public int? ParentID { get; set; }
        public int[] ResourceId { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 07), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentID = 1, Predecessor="2", },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, Predecessor="3", },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 10), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentID = 5, Predecessor="4", },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentID = 5, Predecessor="6", },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentID = 5, Predecessor="7", }
        };
        return Tasks;
    }
}   

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjLSWtCyhZLeNCwH?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Binding custom data source while exporting

You can bind a custom data source for Excel or CSV export in the Blazor Gantt component by assigning it dynamically before the export begins. To achieve this, set the required data to the `DataSource` property within the [ExcelExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ExportToExcelAsync_Syncfusion_Blazor_Grids_ExcelExportProperties_) configuration.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Navigations

<SfGantt ID="GanttContainer" @ref="Gantt" AllowExcelExport="true" Toolbar="@(new List<string>() { "ExcelExport", "CsvExport" })"
DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
    Dependency="Predecessor" ParentID="ParentID">
    </GanttTaskFields>
    <GanttEvents OnToolbarClick="ToolbarClickHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    public SfGantt<TaskData> Gantt;
    private List<TaskData> TaskCollection { get; set; }

    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
    }

    private async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "GanttContainer_excelexport" || args.Item.Id == "GanttContainer_csvexport")
        {
            ExcelExportProperties exportProperties = new ExcelExportProperties
            {
                DataSource = TaskCollection.Take(4).ToList()
            };

            if (args.Item.Id == "GanttContainer_excelexport")
            {
                await Gantt.ExportToExcelAsync(exportProperties);
            }
            else if (args.Item.Id == "GanttContainer_csvexport")
            {
                await Gantt.ExportToCsvAsync(exportProperties);
            }
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
        public string Predecessor { get; set; }
        public int? ParentID { get; set; }
        public int[] ResourceId { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 07), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentID = 1, Predecessor="2", },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, Predecessor="3", },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 10), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentID = 5, Predecessor="4", },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentID = 5, Predecessor="6", },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentID = 5, Predecessor="7", }
        };
        return Tasks;
    }
}   

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjBIsjBvUszGyDBd?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


## Export Gantt Chart Data

To export either the records visible on the current page or all records from the Gantt Chart to Excel or CSV, set the `ExcelExportProperties.ExportType` property.

- **CurrentPage**: Exports only the records displayed on the current Gantt page.
- **AllPages**: Exports all records from the Gantt Chart.

In the following example, [EnableRowVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_EnableRowVirtualization) is enabled, and the export type is applied based on the selected value from a dropdown.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.DropDowns


<div style="display: flex; align-items: center; margin-bottom: 15px;font-weight: bold">
    <label style="padding-right: 10px;">Change export type:</label>
    <SfDropDownList TValue="string" TItem="DropDownOrder" @bind-Value="SelectedExportType" DataSource="@DropDownValue" Width="150px">
        <DropDownListFieldSettings Text="Text" Value="Value" />
    </SfDropDownList>
</div>
<SfGantt ID="GanttContainer" @ref="Gantt" AllowExcelExport="true" EnableRowVirtualization="true" Toolbar="@(new List<string>() { "ExcelExport", "CsvExport" })"
DataSource="@TaskCollection" Height="450px" Width="700px">
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
    <GanttEvents OnToolbarClick="ToolbarClickHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    public SfGantt<TaskData> Gantt;
    private List<TaskData> TaskCollection { get; set; }
    private string SelectedExportType = "CurrentPage"; 
    List<DropDownOrder> DropDownValue = new List<DropDownOrder>
    {
        new DropDownOrder { Text = "CurrentPage", Value = "CurrentPage" },
        new DropDownOrder { Text = "AllPages", Value = "AllPages" },
    };

    private async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "GanttContainer_excelexport")
        {
            ExcelExportProperties exportProperties = new ExcelExportProperties
            {
                ExportType = SelectedExportType == "AllPages" ? Syncfusion.Blazor.Grids.ExportType.AllPages : Syncfusion.Blazor.Grids.ExportType.CurrentPage
            };

            await Gantt.ExportToExcelAsync(exportProperties);
        }
    }

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

    public class DropDownOrder
    {
        public string Text { get; set; }
        public string Value { get; set; }
    }
}   

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjBIiNBPgdsTpwjo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customize the excel export

You can customize the Excel or CSV export functionality in the Gantt Chart component using the [ExcelExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ExportToExcelAsync_Syncfusion_Blazor_Grids_ExcelExportProperties_) configuration object.

### Include hidden columns in export

To include hidden columns during Excel or CSV export in the Gantt Chart component, set [ExcelExportProperties.IncludeHiddenColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html#Syncfusion_Blazor_Grids_ExcelExportProperties_IncludeHiddenColumn) to **true** in the export configuration. This ensures that hidden columns are included in the exported data.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt ID="GanttContainer" @ref="Gantt" AllowExcelExport="true" Toolbar="@(new List<string>() { "ExcelExport", "CsvExport" })" DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID"></GanttTaskFields>
    <GanttEvents OnToolbarClick="ToolbarClickHandler" TValue="TaskData"></GanttEvents>
    <GanttColumns>
        <GanttColumn Field="TaskID" HeaderText="Task Id" Width="150"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Task Name" Width="250"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="StartDate" Width="250" Visible="false"></GanttColumn>
        <GanttColumn Field="Duration" Width="150" HeaderText="Duration" Visible="false"></GanttColumn>
        <GanttColumn Field="Progress" HeaderText="Progress" Width="250"></GanttColumn>
    </GanttColumns>
</SfGantt>

@code{
    public SfGantt<TaskData> Gantt;
    private List<TaskData> TaskCollection { get; set; }
    public void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        Syncfusion.Blazor.Grids.ExcelExportProperties ExportProperties = new Syncfusion.Blazor.Grids.ExcelExportProperties();
        ExportProperties.IncludeHiddenColumn = true;
        if (args.Item.Id == "GanttContainer_excelexport")
        {
            Console.WriteLine(args.Item.Id);
            this.Gantt.ExportToExcelAsync(ExportProperties);
        }
        else if (args.Item.Id == "GanttContainer_csvexport")
        {
            this.Gantt.ExportToCsvAsync(ExportProperties);
        }
    }
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
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
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentID = 1, },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentID = 5, },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentID = 5, },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentID = 5, }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXVoMtWIBjILrMBQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Add header and footer to export

To add header and footer content to exported Excel or CSV files in the Gantt component, configure the `Header` and `Footer` properties within [ExcelExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ExportToExcelAsync_Syncfusion_Blazor_Grids_ExcelExportProperties_) during the [OnToolbarClick](https://blazor.syncfusion.com/documentation/gantt-chart/events#ontoolbarclick) event. This allows you to define custom content that appears at the top and bottom of the exported document.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Navigations

<SfGantt ID="GanttContainer" @ref="Gantt" AllowExcelExport="true" Toolbar="@(new List<string>() { "ExcelExport", "CsvExport" })"
         DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
                     Dependency="Predecessor" ParentID="ParentID">
    </GanttTaskFields>
    <GanttEvents OnToolbarClick="ToolbarClickHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    public SfGantt<TaskData> Gantt;
    private List<TaskData> TaskCollection { get; set; }

    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
    }

    private async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args?.Item?.Id == "GanttContainer_excelexport")
        {
            var s20 = new ExcelStyle { FontColor = "#C67878", FontSize = 20, HAlign = ExcelHorizontalAlign.Center, Bold = true };
            var s15 = new ExcelStyle { FontColor = "#C67878", FontSize = 15, HAlign = ExcelHorizontalAlign.Center, Bold = true };
            var sCB = new ExcelStyle { HAlign = ExcelHorizontalAlign.Center, Bold = true };
            var sC = new ExcelStyle { HAlign = ExcelHorizontalAlign.Center };

            static ExcelRow R(params ExcelCell[] cells) => new() { Cells = (cells is { Length: > 0 }) ? new List<ExcelCell>(cells) : new List<ExcelCell>() };
            static ExcelCell C(string v, int span, ExcelStyle st) => new() { ColSpan = span, Value = v, Style = st };
            static ExcelCell L(string url, string? text, int span, ExcelStyle st) => new() { ColSpan = span, Hyperlink = new Hyperlink { Target = url, DisplayText = text }, Style = st };

            var header = new ExcelHeader
            {
                HeaderRows = 8,
                Rows = new List<ExcelRow>
                {
                    R(C("Northwind Traders", 4, s20)),
                    R(C("2501 Aerial Center Parkway", 4, s15)),
                    R(C("Suite 200 Morrisville, NC 27560 USA", 4, s15)),
                    R(C("Tel +1 888.936.8638 Fax +1 919.573.0306", 4, s15)),
                    R(L("https://www.northwind.com/", "www.northwind.com", 4, sC)),
                    R(L("mailto:support@northwind.com", null, 4, sC)),
                    R(), R()
                }
            };

            var footer = new ExcelFooter
            {
                FooterRows = 4,
                Rows = new List<ExcelRow>
                {
                    R(), R(),
                    R(C("Thank you for your business!", 4, sCB)),
                    R(C("!Visit Again!", 4, sCB))
                }
            };

            await Gantt.ExportToExcelAsync(new ExcelExportProperties { Header = header, Footer = footer });
        }
        else if (args?.Item?.Id == "GanttContainer_csvexport")
        {
            await Gantt.ExportToCsvAsync();
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
        public string Predecessor { get; set; }
        public int? ParentID { get; set; }
        public int[] ResourceId { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 07), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentID = 1, Predecessor="2", },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, Predecessor="3", },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 10), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentID = 5, Predecessor="4", },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentID = 5, Predecessor="6", },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentID = 5, Predecessor="7", }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BtLeMDVlqgbyewep?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Add additional worksheets to Excel document while exporting

To add additional worksheets during export, follow the steps below:

- Create a new instance of the **Workbook** class and assign it to the `Workbook` property of [ExcelExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ExportToExcelAsync_Syncfusion_Blazor_Grids_ExcelExportProperties_) .
- Use `Worksheets.Add` to append new worksheets to the workbook.
- Set the `GridSheetIndex` property to specify the worksheet index where the Gantt data should be placed.
- Trigger the export operation using [ExportToExcelAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ExportToExcelAsync_Syncfusion_Blazor_Grids_ExcelExportProperties_) or [ExportToCsvAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ExportToCsvAsync_Syncfusion_Blazor_Grids_ExcelExportProperties_).

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Navigations
@using Syncfusion.ExcelExport

<SfGantt ID="GanttContainer" @ref="Gantt" AllowExcelExport="true" Toolbar="@(new List<string>() { "ExcelExport", "CsvExport" })"
DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
    Dependency="Predecessor" ParentID="ParentID">
    </GanttTaskFields>
    <GanttEvents OnToolbarClick="ToolbarClickHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    public SfGantt<TaskData> Gantt;
    private List<TaskData> TaskCollection { get; set; }

    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
    }

    private async Task ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "GanttContainer_excelexport" || args.Item.Id == "GanttContainer_csvexport")
        {
            ExcelExportProperties exportProperties = new ExcelExportProperties();
            // Add a new workbook to the Excel document that contains only 1 worksheet.
            exportProperties.Workbook = new Workbook();
            // Add additional worksheets.
            exportProperties.Workbook.Worksheets.Add();
            exportProperties.Workbook.Worksheets.Add();
            // Define the Gridsheet index where Grid data must be exported.
            exportProperties.GridSheetIndex = 0;

            if (args.Item.Id == "GanttContainer_excelexport")
            {
                await Gantt.ExportToExcelAsync(exportProperties);
            }
            else if (args.Item.Id == "GanttContainer_csvexport")
            {
                await Gantt.ExportToCsvAsync(exportProperties);
            }
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
        public string Predecessor { get; set; }
        public int? ParentID { get; set; }
        public int[] ResourceId { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 07), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentID = 1, Predecessor="2", },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, Predecessor="3", },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 10), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentID = 5, Predecessor="4", },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentID = 5, Predecessor="6", },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentID = 5, Predecessor="7", }
        };
        return Tasks;
    }
}  

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNBoCjhPgJqqEzmg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Apply font and color themes

To apply a custom theme, set the [Theme](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html#Syncfusion_Blazor_Grids_ExcelExportProperties_Theme) property within [ExcelExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ExportToExcelAsync_Syncfusion_Blazor_Grids_ExcelExportProperties_). This allows customization of styles for the following sections in the exported file.

- **caption**: Defines the style for the caption, typically used for titles or descriptions at the top of the sheet.
- **header**: Specifies the styling for column headers.
- **record**: Applies formatting to the data rows exported from the Gantt Chart.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt ID="GanttContainer" @ref="Gantt" AllowExcelExport="true" Toolbar="@(new List<string>() { "ExcelExport" })" DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" Dependency="Predecessor" ParentID="ParentID"></GanttTaskFields>
    <GanttEvents OnToolbarClick="ToolbarClickHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

@code{
    public SfGantt<TaskData> Gantt;
    private List<TaskData> TaskCollection { get; set; }
    public void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        Syncfusion.Blazor.Grids.ExcelExportProperties ExportProperties = new Syncfusion.Blazor.Grids.ExcelExportProperties();
        Syncfusion.Blazor.Grids.ExcelTheme Theme = new Syncfusion.Blazor.Grids.ExcelTheme();

        Syncfusion.Blazor.Grids.ExcelStyle ThemeStyle = new Syncfusion.Blazor.Grids.ExcelStyle()
        {
            FontName = "Segoe UI",
            FontColor = "#666666",
            FontSize = 12
        };

        Theme.Header = ThemeStyle;
        Theme.Record = ThemeStyle;
        ExportProperties.Theme = Theme;
        if (args.Item.Id == "GanttContainer_excelexport")
        {
            this.Gantt.ExportToExcelAsync(ExportProperties);
        }
    }

    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    public class TaskData
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public string Predecessor { get; set; }
        public int? ParentID { get; set; }
        public int[] ResourceId { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 07), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentID = 1, Predecessor="2", },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, Predecessor="3", },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 10), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentID = 5, Predecessor="4", },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentID = 5, Predecessor="6", },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentID = 5, Predecessor="7", }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZLeMtWehZlqyHnz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> By default, material theme is applied to the exported Excel document.

### Set custom file name

To assign a custom name to the exported Excel or CSV file in the Gantt Chart component, set the [FileName](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.ExcelExportProperties.html#Syncfusion_Blazor_Grids_ExcelExportProperties_FileName) property within the [ExcelExportProperties](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ExportToExcelAsync_Syncfusion_Blazor_Grids_ExcelExportProperties_) configuration. This configuration determines the filename applied during the export process.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations

<div style="display: flex; align-items: center; padding: 0px 0 20px 0;">
    <label style="margin-right: 17px; white-space: nowrap; font-weight: bold;">Enter file name:</label>
    <SfTextBox @bind-Value="FileName" Placeholder="Enter file name" Width="120px"></SfTextBox>
</div>
<SfGantt ID="GanttContainer" @ref="Gantt" AllowExcelExport="true" Toolbar="@(new List<string>() { "ExcelExport", "CsvExport" })" DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" Dependency="Predecessor" ParentID="ParentID">
    </GanttTaskFields>
    <GanttEvents OnToolbarClick="ToolbarClickHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    public SfGantt<TaskData> Gantt;
    public string FileName { get; set; } = string.Empty;
    private List<TaskData> TaskCollection { get; set; }

    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
    }

    public void ToolbarClickHandler(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        var exportFileName = !string.IsNullOrWhiteSpace(FileName) ? FileName : "ExportedData";

        if (args.Item.Id == "GanttContainer_excelexport")
        {
            var exportProps = new ExcelExportProperties
            {
                FileName = $"{exportFileName}.xlsx"
            };
            Gantt.ExportToExcelAsync(exportProps);
        }
        else if (args.Item.Id == "GanttContainer_csvexport")
        {
            var exportProps = new ExcelExportProperties
            {
                FileName = $"{exportFileName}.csv"
            };
            Gantt.ExportToCsvAsync(exportProps);
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
        public string Predecessor { get; set; }
        public int? ParentID { get; set; }
        public int[] ResourceId { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 07), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentID = 1, Predecessor="2", },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, Predecessor="3", },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 10), EndDate = new DateTime(2022, 01, 17), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentID = 5, Predecessor="4", },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentID = 5, Predecessor="6", },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentID = 5, Predecessor="7", }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNBSijCGoXwGiALV?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


N> You can refer to our [Blazor Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Gantt Chart example](https://blazor.syncfusion.com/demos/gantt-chart/default-functionalities?theme=bootstrap4) to know how to render and configure the Gantt.