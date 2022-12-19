---
layout: post
title: Clipboard in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about clipboard in Syncfusion Blazor Gantt Chart component and much more details.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Clipboard in Blazor Gantt Chart component

The clipboard provides an option to copy selected rows or cells data into the clipboard.

The following list of keyboard shortcuts is supported in the Gantt Chart to copy selected rows or cells data into the clipboard.

Interaction keys |Description
-----|-----
<kbd>Ctrl + C</kbd> |Copy selected rows or cells data into clipboard.

```cshtml

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="1000px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" Dependency="Predecessor" ParentID="ParentId">
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
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public string Predecessor { get; set; }
        public int? ParentId { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2019, 04, 05), EndDate = new DateTime(2019, 04, 21), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2019, 04, 05), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2019, 04, 05), Duration = "4", Progress = 40, Predecessor = "2", ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2019, 04, 05), Duration = "0", Progress = 30, Predecessor = "3", ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2019, 04, 06), EndDate = new DateTime(2019, 04, 21) },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2019, 04, 06), Duration = "3", Progress = 30, Predecessor = "4" , ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2019, 04, 06), Duration = "3", Progress = 40, Predecessor = "6" , ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2019, 04, 06), Duration = "0", Progress = 30, Predecessor = "7" , ParentId = 5 },
        };
        return Tasks;
    }
}
```

## Copy to clipboard by external buttons

To copy the data of the selected rows or cells into the clipboard with the help of external buttons, invoke the [CopyAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_CopyAsync) method.

```cshtml

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Navigations
<SfGantt DataSource="@TaskCollection" @ref="GanttObject" Height="450px" Width="1000px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate"      Duration="Duration" Progress="Progress" Dependency="Predecessor" ParentID="ParentId">
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
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public string Predecessor { get; set; }
        public int? ParentId { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2019, 04, 05), EndDate = new DateTime(2019, 04, 21), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2019, 04, 05), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2019, 04, 05), Duration = "4", Progress = 40, Predecessor = "2", ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2019, 04, 05), Duration = "0", Progress = 30, Predecessor = "3", ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2019, 04, 06), EndDate = new DateTime(2019, 04, 21) },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2019, 04, 06), Duration = "3", Progress = 30, Predecessor = "4" , ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2019, 04, 06), Duration = "3", Progress = 40, Predecessor = "6" , ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2019, 04, 06), Duration = "0", Progress = 30, Predecessor = "7" , ParentId = 5 },
        };
        return Tasks;
    }
}
```

## Copy Hierarchy Modes

Gantt Chart provides support for a set of copy modes with [CopyHierarchyMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.CopyHierarchyType.html) property. The below are the type of filter mode available in the Tree Grid.

* **Parent** : This is the default copy hierarchy mode in the Tree Grid. Clipboard value will have the selected records with its parent records, if the selected records does not have any parent record then the selected record will be in clipboard.

* **Child** : Clipboard value will have the selected records with its child record. If the selected records do not have any child record then the selected records will be in clipboard.

* **Both** : Clipboard value will have the selected records with its both parent and child record. If the selected records do not have any parent and child record then the selected records alone are copied to the clipboard.

* **None** : Only the selected records will be in the clipboard.

```cshtml
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.DropDowns;

<SfDropDownList TValue="string" TItem="DropdownData" @bind-Value="@CopyMode" DataSource="@CopyModes">
    <DropDownListEvents TValue="string" TItem="DropdownData" ValueChange="OnTypeChange"></DropDownListEvents>
    <DropDownListFieldSettings Text="Mode" Value="Id"></DropDownListFieldSettings>
</SfDropDownList>
<SfGantt DataSource="@TaskCollection" @ref="GanttObject" CopyHierarchyMode="@CopyType"  Height="450px" Width="1000px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
    Dependency="Predecessor" ParentID="ParentId"></GanttTaskFields>
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
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public string Predecessor { get; set; }
        public int? ParentId { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2019, 04, 05), EndDate = new DateTime(2019, 04, 21), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2019, 04, 05), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2019, 04, 05), Duration = "4", Progress = 40, Predecessor = "2", ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2019, 04, 05), Duration = "0", Progress = 30, Predecessor = "3", ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2019, 04, 06), EndDate = new DateTime(2019, 04, 21) },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2019, 04, 06), Duration = "3", Progress = 30, Predecessor = "4" , ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2019, 04, 06), Duration = "3", Progress = 40, Predecessor = "6" , ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2019, 04, 06), Duration = "0", Progress = 30, Predecessor = "7" , ParentId = 5 },
        };
        return Tasks;
    }
}
```

## Paste

The content of a row/cells can be copied by selecting the rows/cells and pressing <kbd>Ctrl + C</kbd> shortcut key to copy data and paste it by pressing <kbd>Ctrl + V</kbd> shortcut key.

In the below code example, selected rows are copied by using the [BeforeCopy](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_BeforeCopy) event and pasted by using the [AddRecordAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AddRecordAsync__0_System_Nullable_System_Double__System_Nullable_Syncfusion_Blazor_Gantt_RowPosition__) method and by binding keyboard events `onkeyup`.

```cshtml
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
<SfGantt @ref=GanttChart DataSource="@TaskCollection" @onkeyup="KeyUp" Height="350px" Width="750px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration"
        ParentID="ParentId">
    </GanttTaskFields>
    <GanttSelectionSettings Type="SelectionType.Multiple"></GanttSelectionSettings>
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
                int id = TaskCollection.Max(a => a.TaskId) + 1;
                TaskData ganttData = new TaskData() { };
                foreach (var col in columns)
                {
                    if (col.Field == GanttChart.TaskFields.Id)
                    {
                        ganttData.GetType().GetProperty(col.Field).SetValue(ganttData, id + index);
                    }
                    else if (col.Type == ColumnType.Date)
                    {
                        ganttData.GetType().GetProperty(col.Field).SetValue(ganttData, Convert.ToDateTime(colVal[colIndex]));
                    }
                    else if (col.Type == ColumnType.String)
                    {
                        ganttData.GetType().GetProperty(col.Field).SetValue(ganttData, colVal[colIndex]);
                    }
                    else if (col.Type == ColumnType.Number)
                    {
                        ganttData.GetType().GetProperty(col.Field).SetValue(ganttData, Convert.ToInt32(colVal[colIndex]));
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
            var parentID = TaskCollection[(int)SelectedIndex].ParentId;
            for (var i = 0; i < CopiedRecords.Count; i++)
            {
                CopiedRecords[i].ParentId = parentID;
                GanttChart.AddRecordAsync(CopiedRecords[i], SelectedIndex, RowPosition.Above);
            }
            CopiedRecords = new List<TaskData>();
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
        public int? ParentId { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new
            DateTime(2022, 04, 21) },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration =
            "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4",
            Progress = 40, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0",
            Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new
            DateTime(2022, 04, 21) },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06),
            Duration = "3", Progress = 30, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3",
            Progress = 40, ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0",
            Progress = 30, ParentId = 5 }
        };
        return Tasks;
    }
}
```
![Copy and paste in Blazor Gantt Chart](./images/copypaste_row.gif)

In the below code example, selected cells are copied and pasted by using the [UpdateRecordByIDAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_UpdateRecordByIDAsync__0_) method and by binding keyboard events `onkeydown` and `onkeyup`.

```cshtml
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
<SfGantt @ref=GanttChart DataSource="@TaskCollection" @onkeydown="KeyDown" @onkeyup="KeyUp" Height="450px" Width="1000px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttSelectionSettings Mode="SelectionMode.Cell" Type="SelectionType.Multiple"></GanttSelectionSettings>
    <GanttEditSettings AllowEditing="true"> </GanttEditSettings>
    <GanttEvents CellSelected="CellSelected" CellDeselected="CellDeSelected" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    private SfGantt<TaskData> GanttChart;
    private List<TaskData> TaskCollection { get; set; }
    public int SelectedIndex { get; set; }
    private List<ValueTuple<double, double>> clonedRecordIndex;

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
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new
            DateTime(2022, 04, 21) },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration =
            "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4",
            Progress = 40, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0",
            Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new
            DateTime(2022, 04, 21) },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06),
            Duration = "3", Progress = 30, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3",
            Progress = 40, ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0",
            Progress = 30, ParentId = 5 }
        };
        return Tasks;
    }
}
```
![Copy and paste in Blazor Gantt Chart](./images/copypaste_cell.gif)

