---
layout: post
title: Clipboard in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about clipboard in Syncfusion Blazor Gantt Chart component and much more details.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Clipboard in Blazor Gantt Chart component

The clipboard provides an option to copy selected rows or cell data into the clipboard.

The following list of keyboard shortcuts is supported in the Gantt Chart to copy selected rows or cells data into the clipboard.

Interaction keys |Description
-----|-----
<kbd>Ctrl + C</kbd> |Copy selected rows or cells data into clipboard.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="1000px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" Dependency="Predecessor" ParentID="ParentID">
    </GanttTaskFields>
</SfGantt>

@code{
    private List<TaskData> TaskCollection { get; set; }
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
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2019, 04, 05), EndDate = new DateTime(2019, 04, 10), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2019, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2019, 04, 05), Duration = "4", Progress = 40, Predecessor = "2", ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2019, 04, 05), Duration = "0", Progress = 30, Predecessor = "3", ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2019, 04, 06), EndDate = new DateTime(2019, 04, 18) },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2019, 04, 06), Duration = "3", Progress = 30, Predecessor = "4" , ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2019, 04, 06), Duration = "3", Progress = 40, Predecessor = "6" , ParentID = 5 },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2019, 04, 06), Duration = "0", Progress = 30, Predecessor = "7" , ParentID = 5 },
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNBSNEVJgLymNZrA?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Copy to clipboard by external buttons

To copy the data of the selected rows or cells into the clipboard with the help of external buttons, invoke the [CopyAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_CopyAsync) method.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Navigations
<SfGantt DataSource="@TaskCollection" @ref="GanttObject" Height="450px" Width="1000px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" Dependency="Predecessor" ParentID="ParentID">
    </GanttTaskFields>
    <SfToolbar ID="Gantt_Gantt_Toolbar">
        <ToolbarItems>
            <ToolbarItem Id="copyHeader" Text="Copy With Header" OnClick="ToolbarClick" PrefixIcon="e-copy"></ToolbarItem>
            <ToolbarItem Id="copy" Text="Copy" OnClick="ToolbarClick" PrefixIcon="e-copy"></ToolbarItem>
        </ToolbarItems>
    </SfToolbar>
</SfGantt>
@code{
    private List<TaskData> TaskCollection { get; set; }
    private SfGantt<TaskData> GanttObject;
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    public async void ToolbarClick(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        var SelectedRecords = await this.GanttObject.GetSelectedRecordsAsync();
        if (SelectedRecords.Count() > 0)
        {
            var WithHeader = false;
            if (args.Item.Id == "copyHeader")
            {
                WithHeader = true;
            }
            await this.GanttObject.CopyAsync(WithHeader);
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
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2019, 04, 05), EndDate = new DateTime(2019, 04, 10), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2019, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2019, 04, 05), Duration = "4", Progress = 40, Predecessor = "2", ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2019, 04, 05), Duration = "0", Progress = 30, Predecessor = "3", ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2019, 04, 06), EndDate = new DateTime(2019, 04, 18) },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2019, 04, 06), Duration = "3", Progress = 30, Predecessor = "4" , ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2019, 04, 06), Duration = "3", Progress = 40, Predecessor = "6" , ParentID = 5 },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2019, 04, 06), Duration = "0", Progress = 30, Predecessor = "7" , ParentID = 5 },
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXhIDOBJqrnnaTje?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Copy hierarchy modes

Gantt Chart provides support for a set of copy modes with the [CopyHierarchyMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.CopyHierarchyType.html) property. The following are the type of filter modes available in the Gantt Chart.

* **Parent**: This is the default copy hierarchy mode in the Gantt Chart. The clipboard value will have the selected records with its parent records, if the selected records do not have any parent record, then the selected record will be in the clipboard.

* **Child**: Clipboard value will have the selected records with its child record. If the selected records do not have any child record, then the selected records will be in the clipboard.

* **Both**: Clipboard value will have the selected records with both parent and child records. If the selected records do not have any parent and child records, then the selected records alone are copied to the clipboard.

* **None**: Only the selected records will be in the clipboard.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.DropDowns;

<SfDropDownList TValue="string" TItem="DropdownData" @bind-Value="@CopyMode" DataSource="@CopyModes" Width=200px>
    <DropDownListEvents TValue="string" TItem="DropdownData" ValueChange="OnTypeChange"></DropDownListEvents>
    <DropDownListFieldSettings Text="Mode" Value="Id"></DropDownListFieldSettings>
</SfDropDownList>
<SfGantt DataSource="@TaskCollection" @ref="GanttObject" CopyHierarchyMode="@CopyType"  Height="450px" Width="1000px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
    Dependency="Predecessor" ParentID="ParentID"></GanttTaskFields>
    <SfToolbar ID="Gantt_Gantt_Toolbar">
        <ToolbarItems>
            <ToolbarItem Id="copyHeader" Text="Copy With Header" OnClick="ToolbarClick" PrefixIcon="e-copy"></ToolbarItem>
            <ToolbarItem Id="copy" Text="Copy" OnClick="ToolbarClick" PrefixIcon="e-copy"></ToolbarItem>
        </ToolbarItems>
    </SfToolbar>
</SfGantt>
@code{
    private List<TaskData> TaskCollection { get; set; }
    private SfGantt<TaskData> GanttObject;
    public string CopyMode { get; set; } = "Parent";
    public CopyHierarchyType CopyType { get; set; } = CopyHierarchyType.Parent;
    public List<DropdownData> CopyModes { get; set; } = new List<DropdownData>();
    public class DropdownData
    {
        public string Id { get; set; }
        public string Mode { get; set; }
    }
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
        this.CopyModes.Add(new DropdownData() { Id = "Parent", Mode = "Parent" });
        this.CopyModes.Add(new DropdownData() { Id = "Child", Mode = "Child" });
        this.CopyModes.Add(new DropdownData() { Id = "Both", Mode = "Both" });
        this.CopyModes.Add(new DropdownData() { Id = "None", Mode = "None" });
    }

    private async void OnTypeChange(Syncfusion.Blazor.DropDowns.ChangeEventArgs<string, DropdownData> Args)
    {
        if (Args.Value == "Parent")
        {
            CopyType = CopyHierarchyType.Parent;
        }
        else if (Args.Value == "Child")
        {
            CopyType = CopyHierarchyType.Child;
        }
        else if (Args.Value == "Both")
        {
            CopyType = CopyHierarchyType.Both;
        }
        else if(Args.Value == "None")
        {
            CopyType = CopyHierarchyType.None;
        }
    }

    public async void ToolbarClick(Syncfusion.Blazor.Navigations.ClickEventArgs args)
    {
        var SelectedRecords = await this.GanttObject.GetSelectedRecordsAsync();
        if (SelectedRecords.Count() > 0)
        {
            var WithHeader = false;
            if (args.Item.Id == "copyHeader")
            {
                WithHeader = true;
            }
            await this.GanttObject.CopyAsync(WithHeader);
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
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2019, 04, 05), EndDate = new DateTime(2019, 04, 10), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2019, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2019, 04, 05), Duration = "4", Progress = 40, Predecessor = "2", ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2019, 04, 05), Duration = "0", Progress = 30, Predecessor = "3", ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2019, 04, 06), EndDate = new DateTime(2019, 04, 18) },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2019, 04, 06), Duration = "3", Progress = 30, Predecessor = "4" , ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2019, 04, 06), Duration = "3", Progress = 40, Predecessor = "6" , ParentID = 5 },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2019, 04, 06), Duration = "0", Progress = 30, Predecessor = "7" , ParentID = 5 },
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtreZYhfgVwQdJtr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Paste

The content of a row/cells can be copied by selecting the rows/cells and pressing the <kbd>Ctrl + C</kbd> shortcut key to copy data and paste it by pressing <kbd>Ctrl + V</kbd> shortcut key.

In the following code example, selected rows are copied by using the [BeforeCopy](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_BeforeCopy) event and pasted by using the [AddRecordAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AddRecordAsync__0_System_Nullable_System_Double__System_Nullable_Syncfusion_Blazor_Gantt_RowPosition__) method and by binding keyboard events `onkeyup`.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
<SfGantt @ref=GanttChart DataSource="@TaskCollection" @onkeyup="KeyUp" Height="350px" Width="750px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration"
        ParentID="ParentID">
    </GanttTaskFields>
    <GanttSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GanttSelectionSettings>
    <GanttEditSettings AllowAdding="true"> </GanttEditSettings>
    <GanttEvents BeforeCopy="BeforeCopyHandler" RowSelected="RowSelect" RowDeselected="RowDeselect" TValue="TaskData">
    </GanttEvents>
</SfGantt>

@code {
    private SfGantt<TaskData> GanttChart;
    private List<TaskData> TaskCollection { get; set; }
    public List<TaskData> CopiedRecords { get; set; } = new List<TaskData>();
    public double SelectedIndex { get; set; }
    public void RowDeselect(RowDeselectEventArgs<TaskData> Args)
    {
        SelectedIndex = -1;
    }
    private async void BeforeCopyHandler(Syncfusion.Blazor.Gantt.BeforeCopyEventArgs args)
    {
        var columns = GanttChart.GetColumnsAsync().Result;
        var clip = args.ClipboardText;
        if (clip != "" || clip != null)
        {
            var record = clip.Split("\n");
            int index = 0;
            foreach (var rec in record)
            {
                var colVal = rec.Split("\t");
                int colIndex = 0;
                int id = TaskCollection.Max(a => a.TaskID) + 1;
                TaskData ganttData = new TaskData() { };
                foreach (var col in columns)
                {
                    if (col.Field == GanttChart.TaskFields.Id)
                    {
                        ganttData.GetType().GetProperty(col.Field).SetValue(ganttData, id + index);
                    }
                    else if (col.Type == Syncfusion.Blazor.Grids.ColumnType.Date)
                    {
                        ganttData.GetType().GetProperty(col.Field).SetValue(ganttData, Convert.ToDateTime(colVal[colIndex]));
                    }
                    else if (col.Type == Syncfusion.Blazor.Grids.ColumnType.String)
                    {
                        ganttData.GetType().GetProperty(col.Field).SetValue(ganttData, colVal[colIndex]);
                    }
                    colIndex++;
                }
                index++;
                CopiedRecords.Add(ganttData);
            }
        }
    }
    public void RowSelect(RowSelectEventArgs<TaskData> Args)
    {
        SelectedIndex = Args.RowIndex;
    }
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }
    private async Task KeyUp(KeyboardEventArgs Args)
    {
        if (Args.CtrlKey && Args.Code == "KeyV" && CopiedRecords.Count > 0 && SelectedIndex > -1)
        {
            var parentID = TaskCollection[(int)SelectedIndex].ParentID;
            for (var i = 0; i < CopiedRecords.Count; i++)
            {
                CopiedRecords[i].ParentID = parentID;
                GanttChart.AddRecordAsync(CopiedRecords[i],(int)SelectedIndex, Syncfusion.Blazor.Gantt.RowPosition.Above);
            }
            CopiedRecords = new List<TaskData>();
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
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new
            DateTime(2022, 04, 08) },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration =
            "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4",
            Progress = 40, ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0",
            Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new
            DateTime(2022, 04, 08) },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06),
            Duration = "3", Progress = 30, ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3",
            Progress = 40, ParentID = 5 },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0",
            Progress = 30, ParentID = 5 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNLoXOLIWYbFyAtl?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

In the following code example, selected cells are copied and pasted by using the [UpdateRecordByIDAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_UpdateRecordByIDAsync__0_) method and by binding keyboard events `onkeydown` and `onkeyup.`

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
<SfGantt @ref=GanttChart DataSource="@TaskCollection" @onkeydown="KeyDown" @onkeyup="KeyUp" Height="450px" Width="1000px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttSelectionSettings Mode="Syncfusion.Blazor.Grids.SelectionMode.Cell" Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GanttSelectionSettings>
    <GanttEditSettings AllowEditing="true"> </GanttEditSettings>
    <GanttEvents CellSelected="CellSelected" CellDeselected="CellDeSelected" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    private SfGantt<TaskData> GanttChart;
    private List<TaskData> TaskCollection { get; set; }
    public int SelectedIndex { get; set; }
    private List<ValueTuple<int, int>> clonedRecordIndex;

    public void CellDeSelected(CellDeselectEventArgs<TaskData> Args)
    {
        SelectedIndex = -1;
    }
    public async void CellSelected(CellSelectEventArgs<TaskData> Args)
    {
        SelectedIndex = Convert.ToInt32(Args.RowIndex);
    }
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }
    private async Task KeyDown(KeyboardEventArgs Args)
    {
        if (Args.CtrlKey && Args.Code == "KeyC")
        {
            clonedRecordIndex = await GanttChart.GetSelectedRowCellIndexesAsync();
        }
    }
    private async Task KeyUp(KeyboardEventArgs Args)
    {
        if (Args.CtrlKey && Args.Code == "KeyV" && clonedRecordIndex.Count>0 && SelectedIndex > -1)
        {
            var columns = GanttChart.GetColumnsAsync().Result;
            var currentRecords = GanttChart.GetCurrentViewRecords();
            IDictionary<double, List<double>> clonedRecords = new Dictionary<double, List<double>>(); ;
            for (int i = 0; i < clonedRecordIndex.Count; i++)
            {
                if (!clonedRecords.ContainsKey(clonedRecordIndex[i].Item1))
                {
                    List<double> cellIndex = new List<double>();
                    cellIndex.Add(clonedRecordIndex[i].Item2);
                    clonedRecords[clonedRecordIndex[i].Item1] = cellIndex;
                }
                else
                {
                    List<double> cellIndex = (List<double>)clonedRecords[clonedRecordIndex[i].Item1];
                    cellIndex.Add(clonedRecordIndex[i].Item2);
                }
            }
            for (int i = 0; i < clonedRecords.Count; i++)
            {
                double clonedRecRowIndex = clonedRecords.ElementAt(i).Key;
                List<double> clonedRecCellIndex = clonedRecords.ElementAt(i).Value;
                TaskData clonedRec = currentRecords[Convert.ToInt32(clonedRecRowIndex)];
                if (SelectedIndex + i < currentRecords.Count)
                {
                    TaskData updatedRec = currentRecords[SelectedIndex + i];
                    for (int j = 0; j < clonedRecCellIndex.Count; j++)
                    {
                        GanttColumn col = columns[Convert.ToInt32(clonedRecCellIndex[j])];
                        if (!col.IsPrimaryKey)
                        {
                            var clonedValue = clonedRec.GetType().GetProperty(col.Field).GetValue(clonedRec);
                            updatedRec.GetType().GetProperty(col.Field).SetValue(updatedRec, clonedValue);
                        }
                    }
                    GanttChart.UpdateRecordByIDAsync(updatedRec);
                }
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
        public int? ParentID { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new
            DateTime(2022, 04, 08) },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration =
            "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4",
            Progress = 40, ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0",
            Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new
            DateTime(2022, 04, 08) },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06),
            Duration = "3", Progress = 30, ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3",
            Progress = 40, ParentID = 5 },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0",
            Progress = 30, ParentID = 5 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/htheZYBSrtNqqEsO?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Autofill functionality in Gantt Chart

To achieve the autofill functionality in the Gantt chart, the drag selection feature must be enabled, and the keyup event must be bound.

The following properties have been configured in the [GanttSelectionSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttSelectionSettings.html) to enable the drag selection feature:

- [AllowDragSelection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttSelectionSettings.html#Syncfusion_Blazor_Gantt_GanttSelectionSettings_AllowDragSelection): `true`
- [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttSelectionSettings.html#Syncfusion_Blazor_Gantt_GanttSelectionSettings_Mode): [Cell](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SelectionMode.html#Syncfusion_Blazor_Grids_SelectionMode_Cell)
- [Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttSelectionSettings.html#Syncfusion_Blazor_Gantt_GanttSelectionSettings_Type): [Multiple](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SelectionType.html#Syncfusion_Blazor_Grids_SelectionType_Multiple)
- [CellSelectionMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttSelectionSettings.html#Syncfusion_Blazor_Gantt_GanttSelectionSettings_CellSelectionMode): [Box](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.CellSelectionMode.html#Syncfusion_Blazor_Grids_CellSelectionMode_Box)

Using these settings, the user can select multiple cells in the Gantt chart by dragging the mouse.

Then the native keyup event is bound to the Gantt chart in order to customize the keydown actions in the gantt chart. In the example provided, the Alt key is captured to fill the data while dragging the selection. For more information, please refer to this [page](https://blazor.syncfusion.com/documentation/gantt-chart/how-to/bind-native-events).

The value of first selected cell is captured in the [CellSelectedEvent](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_CellSelected) based on the cell index.

When the `Alt` key is pressed and released during a multiple cell selection, the [UpdateRecordByID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_UpdateRecordByIDAsync__0_) method is called in the Keyup event. This method updates the values of all selected rows with the value of the first selected cell, effectively copying the value of the first selected cell to all other cells in those rows that were selected. 

With this customization, users can easily and quickly update multiple cells in the Gantt chart, improving overall efficiency.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids

<SfGantt @ref=GanttChart DataSource="@TaskCollection" @onkeyup="KeyUp" Height="450px" Width="1000px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttSelectionSettings Mode="Syncfusion.Blazor.Grids.SelectionMode.Cell" Type="Syncfusion.Blazor.Grids.SelectionType.Multiple" AllowDragSelection="true" CellSelectionMode="CellSelectionMode.Box"></GanttSelectionSettings>
    <GanttEditSettings AllowEditing="true"> </GanttEditSettings>
    <GanttEvents CellSelected="CellSelectedHandler"  CellDeselected="CellDeSelectedHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    private SfGantt<TaskData> GanttChart;

    private List<TaskData> TaskCollection { get; set; }

    private object Value { get; set; }

    private string ColumnField { get; set; }

    private void CellSelectedHandler(CellSelectEventArgs<TaskData> args)
    {
        if (Value == null)
        {
            ColumnField = GanttChart.GetColumnsAsync().Result[Convert.ToInt32(args.CellIndex)].Field;
            Value = args.Data.GetType().GetProperty(ColumnField).GetValue(args.Data);
        }
    }

    private void CellDeSelectedHandler()
    {
        Value = null;
    }

    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    private async Task KeyUp(KeyboardEventArgs args)
    {
        if (args.Code == "AltLeft" || args.Code == "AltRight")
        {
            var data = GanttChart.GetSelectedRowCellIndexesAsync();
            List<TaskData> AutofillData = new List<TaskData>();
            for (var i = 0; i < data.Result.Count; i++)
            {
                TaskData currentRecord = GanttChart.GetCurrentViewRecords().ElementAt(Convert.ToInt32(data.Result[i].Item1));
                AutofillData.Add(currentRecord);
            }
            for (var j = 0; j < AutofillData.Count; j++)
            {
                AutofillData[j].GetType().GetProperty(ColumnField).SetValue(AutofillData[j], Value);
                await GanttChart.UpdateRecordByIDAsync(AutofillData[j]);
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
        public int? ParentID { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 08), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30,  ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 04, 08), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 40, ParentID = 5 },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0", Progress = 30,  ParentID = 5 },
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDVyXaBShXqAcAGK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}