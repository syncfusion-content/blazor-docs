---
layout: post
title: Column Chooser in Blazor Gantt Chart Component | Syncfusion
description: Learn how to dynamically show or hide columns using the column chooser in the Syncfusion Blazor Gantt Chart, including custom templates.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Column Chooser in Blazor Gantt Chart Component

The column chooser feature in the Syncfusion Blazor Gantt Chart allows users to show or hide columns dynamically. Enable it by setting the [ShowColumnChooser](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ShowColumnChooser) property to `true`. Open the chooser using [OpenColumnChooser](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_OpenColumnChooser_System_Nullable_System_Double__System_Nullable_System_Double_) for custom positioning. This guide covers basic column chooser usage and custom templates.

## Column chooser

Dynamically show or hide columns using the column chooser, enabled by setting `ShowColumnChooser` to `true`. Use a toolbar button to open the chooser at a specific position with `OpenColumnChooser`.

```cshtml
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Navigations

<SfGantt DataSource="@TaskCollection" Toolbar="@ToolbarItems" ShowColumnChooser="true" ProjectStartDate="new DateTime(2022, 4, 1)" Height="450px" Width="1200px" @ref="Gantt" HighlightWeekends="true" AllowReordering="true" TreeColumnIndex="1" GridLines="Syncfusion.Blazor.Gantt.GridLine.None">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" Dependency="Predecessor" ParentID="ParentId"></GanttTaskFields>
    <GanttEvents OnToolbarClick="ToolbarClickAsync" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    public SfGantt<TaskData> Gantt { get; set; }
    private List<TaskData> TaskCollection { get; set; }
    public List<Object> ToolbarItems = new List<Object>() {new Syncfusion.Blazor.Navigations.ToolbarItem() { Text = "Column Chooser", TooltipText = "Column Chooser", Id = "columnchooser"}};

    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    public async Task ToolbarClickAsync(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        if (args.Item.Id == "columnchooser")
        {
            await Gantt.OpenColumnChooserAsync(100, 50);
        }
    }

    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public string Predecessor { get; set; }
        public int? ParentId { get; set; }
        public bool IsExpanded { get; set; }
        public string Done { get; set; }
        public bool IsMilestone { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 21), IsExpanded = false, Done = "Yes" },
            new TaskData() { TaskId = 2, TaskName = "Identify site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentId = 1, IsExpanded = true, Done = "No" },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentId = 1, Predecessor = "2", IsExpanded = true, Done = "No", IsMilestone = true },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "3", Progress = 30, ParentId = 1, Predecessor = "3", IsExpanded = true, Done = "No" },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 04, 21), IsExpanded = true, Done = "Yes" },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, ParentId = 5, IsExpanded = true, Done = "No" },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 40, ParentId = 5, IsExpanded = true, Done = "No" },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0", Progress = 30, ParentId = 5, IsExpanded = true, Done = "No" },
            new TaskData() { TaskId = 9, TaskName = "Sign contract", StartDate = new DateTime(2022, 04, 06), Duration = "1", Predecessor = "8", Progress = 30, ParentId = 5, IsExpanded = true, Done = "No" },
            new TaskData() { TaskId = 10, TaskName = "Identify structural needs", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, ParentId = 5, IsExpanded = true, Done = "No" }
        };
        return Tasks;
    }
}
```

> **Note**: Use <kbd>Tab</kbd> and arrow keys for keyboard navigation in the chooser. Test on mobile devices for responsiveness.

## Custom component in column chooser template

Customize the column chooser with a template using [GanttColumnChooserSettings.Template](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumnChooserSettings.html#Syncfusion_Blazor_Gantt_GanttColumnChooserSettings_Template) to render a ListView for grouped column selection. Include a search box for filtering columns.

```cshtml
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids

<div style="height: 100%; width: 100%">
    <div style="position: relative;border:1px solid red; height: 100%;width:100%;min-height: 450px;min-width:800px">
        <SfGantt DataSource="@Orders" ShowColumnChooser="true" ProjectStartDate="new DateTime(2022,4,1)" ID="GanttChart" Width="1200px" Height="450px" @ref="Gantt" HighlightWeekends="true" AllowReordering="true" TreeColumnIndex="1" GridLines="Syncfusion.Blazor.Gantt.GridLine.None">
            <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" ParentID="ParentId" Dependency="Predecessor"></GanttTaskFields>
            <GanttColumnChooserSettings>
                <Template>
                    @{
                        var ct = context as ColumnChooserTemplateContext;
                        <CustomColumnChooser @ref="ins" ActionCompleted="ActionCompleted" @key="ct.Columns.Count" ColumnContext="ct" CustomGantt="Gantt"></CustomColumnChooser>
                    }
                </Template>
                <FooterTemplate></FooterTemplate>
            </GanttColumnChooserSettings>
            <GanttColumns>
                <GanttColumn Field=@nameof(TaskData.TaskId) HeaderText="TaskID" TextAlign="TextAlign.Right" Width="120">
                    <HeaderTemplate>
                        @{
                            var a = "TaskId";
                        }
                        <span style="width:20px;height:20px;border-color:red" @onclick="(e)=>onclick(e,a)" class="e-icons e-plus-icon"></span>@a
                    </HeaderTemplate>
                </GanttColumn>
                <GanttColumn Field=@nameof(TaskData.TaskName) HeaderText="TaskName" Width="150">
                    <HeaderTemplate>
                        @{
                            var a = "TaskName";
                        }
                        <span style="width:20px;height:20px;border-color:red" @onclick="(e)=>onclick(e,a)" class="e-icons e-plus-icon"></span>@a
                    </HeaderTemplate>
                </GanttColumn>
                <GanttColumn Field=@nameof(TaskData.StartDate) HeaderText="StartDate" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130">
                    <HeaderTemplate>
                        @{
                            var a = "StartDate";
                        }
                        <span style="width:20px;height:20px;border-color:red" @onclick="(e)=>onclick(e,a)" class="e-icons e-plus-icon"></span>@a
                    </HeaderTemplate>
                </GanttColumn>
                <GanttColumn Field=@nameof(TaskData.EndDate) HeaderText="EndDate" Format="C2" TextAlign="TextAlign.Right" Width="120">
                    <HeaderTemplate>
                        @{
                            var a = "EndDate";
                        }
                        <span style="width:20px;height:20px;border-color:red" @onclick="(e)=>onclick(e,a)" class="e-icons e-plus-icon"></span>@a
                    </HeaderTemplate>
                </GanttColumn>
                <GanttColumn Field=@nameof(TaskData.Duration) HeaderText="Duration" TextAlign="TextAlign.Right" Width="120">
                    <HeaderTemplate>
                        @{
                            var a = "Duration";
                        }
                        <span style="width:20px;height:20px;border-color:red" @onclick="(e)=>onclick(e,a)" class="e-icons e-plus-icon"></span>@a
                    </HeaderTemplate>
                </GanttColumn>
                <GanttColumn Field=@nameof(TaskData.Progress) HeaderText="Progress" Width="150">
                    <HeaderTemplate>
                        @{
                            var a = "Progress";
                        }
                        <span style="width:20px;height:20px;border-color:red" @onclick="(e)=>onclick(e,a)" class="e-icons e-plus-icon"></span>@a
                    </HeaderTemplate>
                </GanttColumn>
                <GanttColumn Field=@nameof(TaskData.Predecessor) HeaderText="Predecessor" Format="d" Type="ColumnType.Date" TextAlign="TextAlign.Right" Width="130">
                    <HeaderTemplate>
                        @{
                            var a = "Predecessor";
                        }
                        <span style="width:20px;height:20px;border-color:red" @onclick="(e)=>onclick(e,a)" class="e-icons e-plus-icon"></span>@a
                    </HeaderTemplate>
                </GanttColumn>
                <GanttColumn Field=@nameof(TaskData.Done) HeaderText="Done" TextAlign="TextAlign.Right" Width="120">
                    <HeaderTemplate>
                        @{
                            var a = "Done";
                        }
                        <span style="width:20px;height:20px;border-color:red" @onclick="(e)=>onclick(e,a)" class="e-icons e-plus-icon"></span>@a
                    </HeaderTemplate>
                </GanttColumn>
            </GanttColumns>
        </SfGantt>
    </div>
</div>

<style>
    #treeGridGanttChart .e-cc-searchdiv {
        display: none;
    }

    #treeGridGanttChart .e-dlg-content {
        margin-top: 0px;
    }

    #treeGridGanttChart div.e-footer-content {
        display: none;
    }

    .e-list-item.e-level-1.e-checklist.e-focused {
        background-color: none;
    }

    #treeGridGanttChart_gridcontrol_ccdlg .e-content {
        overflow-y: unset;
    }

    .e-plus-icon::before {
        content: '\e759';
    }
</style>

@code {
    public List<TaskData> Orders { get; set; }
    public List<GanttColumn> VisibleCols { get; set; }
    public SfGantt<TaskData> Gantt;
    public int currentColIndex;

    public CustomColumnChooser ins { get; set; }

    public async Task onclick(MouseEventArgs e, string ColName)
    {
        var cols = Gantt.Columns;
        VisibleCols = Gantt.Columns;
        await ins.loadData();
        if (VisibleCols.IndexOf(cols.Where(x => x.Field == ColName).FirstOrDefault()) == (VisibleCols.Count - 1))
        {
            await this.Gantt.OpenColumnChooser(e.ClientX - 450, e.ClientY - 100);
        }
        else
        {
            await this.Gantt.OpenColumnChooser(e.ClientX - 300, e.ClientY - 100);
        }
        var colsList = Gantt.Columns;
        currentColIndex = VisibleCols.Select(x => x.Field).ToList().IndexOf(ColName);
    }

    public async void ActionCompleted(string columnField)
    {
        var newcols = Gantt.Columns;
        var clickedCol = newcols[currentColIndex];
        await Gantt.ReorderColumnsAsync(new List<string>() { columnField }, clickedCol.Field);
    }

    protected override void OnInitialized()
    {
        this.Orders = GetTaskCollection();
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 21), IsExpanded = false, Done = "Yes" },
            new TaskData() { TaskId = 2, TaskName = "Identify site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentId = 1, IsExpanded = true, Done = "No" },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentId = 1, Predecessor = "2", IsExpanded = true, Done = "No", IsMilestone = true },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "3", Progress = 30, ParentId = 1, Predecessor = "3", IsExpanded = true, Done = "No" },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 04, 21), IsExpanded = true, Done = "Yes" },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, ParentId = 5, IsExpanded = true, Done = "No" },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 40, ParentId = 5, IsExpanded = true, Done = "No" },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0", Progress = 30, ParentId = 5, IsExpanded = true, Done = "No" },
            new TaskData() { TaskId = 9, TaskName = "Sign contract", StartDate = new DateTime(2022, 04, 06), Duration = "1", Predecessor = "8", Progress = 30, ParentId = 5, IsExpanded = true, Done = "No" },
            new TaskData() { TaskId = 10, TaskName = "Identify structural needs", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, ParentId = 5, IsExpanded = true, Done = "No" }
        };
        return Tasks;
    }
}
```

CustomColumnChooser.razor

```cshtml
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Lists
@using Syncfusion.Blazor.Inputs

<SfTextBox Placeholder="Search" ShowClearButton="true" Input="OnInputAsync"></SfTextBox>
<SfListView @ref="ListView" ID="ListViewCtl" Height="100%" ShowCheckBox="true" DataSource="@DataSourceCopy">
    <ListViewFieldSettings TValue="DataModel" Id="Id" Text="Text" GroupBy="Type"></ListViewFieldSettings>
    <ListViewEvents Clicked="OnClickedAsync" TValue="DataModel"></ListViewEvents>
</SfListView>

@code {
    public List<DataModel> DataSourceCopy { get; set; } = new List<DataModel>();

    [Parameter]
    public SfGantt<TaskData> CustomGantt { get; set; }

    [Parameter]
    public Action<string> ActionCompleted { get; set; }

    [Parameter]
    public ColumnChooserTemplateContext ColumnContext { get; set; }

    public SfListView<DataModel> ListView { get; set; }

    private async Task OnInputAsync(InputEventArgs eventArgs)
    {
        DataSourceCopy = DataSource.Where(e => e.Text.ToLower().StartsWith(eventArgs.Value.ToLower())).ToList();
        await Task.Delay(100);
        await PreselectAsync();
    }

    protected override async Task OnInitializedAsync()
    {
        DataSourceCopy = DataSource;
        await Task.Delay(100);
        await PreselectAsync();
    }

    static List<DataModel> DataSource = new List<DataModel>
    {
        new DataModel() { Text = nameof(TaskData.TaskId), Id = nameof(TaskData.TaskId), Type = "Task" },
        new DataModel() { Text = nameof(TaskData.TaskName), Id = nameof(TaskData.TaskName), Type = "Task" },
        new DataModel() { Text = nameof(TaskData.StartDate), Id = nameof(TaskData.StartDate), Type = "Date" },
        new DataModel() { Text = nameof(TaskData.EndDate), Id = nameof(TaskData.EndDate), Type = "Date" },
        new DataModel() { Text = nameof(TaskData.Progress), Id = nameof(TaskData.Progress), Type = "status" },
        new DataModel() { Text = nameof(TaskData.Duration), Id = nameof(TaskData.Duration), Type = "Date" },
        new DataModel() { Text = nameof(TaskData.Predecessor), Id = nameof(TaskData.Predecessor), Type = "status" },
        new DataModel() { Text = nameof(TaskData.Done), Id = nameof(TaskData.Done), Type = "status" }
    };

    public async Task loadData()
    {
        await PreselectAsync();
    }

    public async Task PreselectAsync()
    {
        var cols = ColumnContext.Columns.Where(x => x.Visible).ToList();
        var selectlist = new List<DataModel>();
        foreach (var column in cols)
        {
            selectlist.Add(DataSource.FirstOrDefault(x => x.Text == column.Field));
        }
        if (selectlist.Count > 0 && ListView != null)
        {
            await ListView.CheckItemsAsync(selectlist);
        }
    }

    public async Task OnClickedAsync(ClickEventArgs<DataModel> args)
    {
        if (args.IsChecked)
        {
            await CustomGantt.HideColumnAsync(args.Text, "field");
        }
        else
        {
            await CustomGantt.ShowColumnAsync(args.Text, "field");
            await Task.Delay(500);
            ActionCompleted.Invoke(args.Text);
        }
    }
}
```

Model.cs

```cshtml
public class DataModel
{
    public string Id { get; set; }
    public string Text { get; set; }
    public string Type { get; set; }
}

public class TaskData
{
    public int TaskId { get; set; }
    public string TaskName { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Duration { get; set; }
    public int Progress { get; set; }
    public string Predecessor { get; set; }
    public int? ParentId { get; set; }
    public bool IsExpanded { get; set; }
    public string Done { get; set; }
    public bool IsMilestone { get; set; }
}
```

![Blazor Gantt Chart with custom column chooser using ListView for grouped columns](images/blazor-gantt-chart-custom-column-chooser.png)

## See also

- [Accessibility in Blazor Gantt Chart](https://blazor.syncfusion.com/documentation/gantt-chart/accessibility)
- [Blazor Gantt Chart Feature Tour](https://www.syncfusion.com/blazor-components/blazor-gantt-chart)
- [Blazor Gantt Chart Example](https://blazor.syncfusion.com/demos/gantt-chart/default-functionalities?theme=bootstrap5)