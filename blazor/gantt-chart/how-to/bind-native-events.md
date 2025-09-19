---
layout: post
title: Bind the native events in Blazor Gantt Chart Component | Syncfusion
description: Learn here to bind the native events and customize the key interaction in Syncfusion Blazor Gantt Chart component.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Bind native events in Gantt Chart

There are default keyboard shortcuts available to perform actions in the Gantt Chart. Refer to the Gantt Chart default keyboard shortcuts [here](https://blazor.syncfusion.com/documentation/gantt-chart/accessibility#keyboard-navigation). Now, you can create custom shortcut keys to perform your own actions in Gantt Chart by binding the native events like onkeydown, onkeyup, onkeypress, etc.

In the following Gantt Chart example, some of the actions can be performed by using `onkeydown` and `onkeyup` events.

Interaction Keys |Description
-----|-----
<kbd>Ctrl + X</kbd> | Used to cut the selected records from Gantt.
<kbd>Ctrl + C</kbd> | Used to copy the selected records from Gantt.
<kbd>Ctrl + V</kbd> | Used to paste the copied or cut records in the selected position.
<kbd>Ctrl + D</kbd> | Used to duplicate a selected record.
<kbd>Alt + O</kbd> | Used to open the add dialog.

### Example

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

<SfGantt @ref=Gantt DataSource="@TaskCollection" @onkeydown="KeyDown" @onkeyup="KeyUp" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttSelectionSettings Mode="Syncfusion.Blazor.Grids.SelectionMode.Row" Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GanttSelectionSettings>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true"></GanttEditSettings>
    <GanttEvents RowSelected="RowSelect" RowDeselected="RowDeselect" TValue="TaskData"></GanttEvents>
</SfGantt>
@code {
    private SfGantt<TaskData> Gantt;
    private List<TaskData> TaskCollection { get; set; }
    public List<TaskData> CopiedRecords { get; set; } = new List<TaskData>();
    public List<TaskData> ClonedRecords { get; set; } = new List<TaskData>();
    public TaskData SelectedRecords { get; set; }
    public double SelectedIndex { get; set; }
    public void RowDeselect(RowDeselectEventArgs<TaskData> Args)
    {
        //Remove the maintained value while deselecting the records
        SelectedIndex = -1;
        SelectedRecords = new TaskData();
    }
    public void RowSelect(RowSelectEventArgs<TaskData> Args)
    {
        SelectedRecords = Args.Data;
        SelectedIndex = Args.RowIndex;
    }
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }
    private async Task KeyDown(KeyboardEventArgs Args)
    {
        if (Args.CtrlKey && (Args.Code == "KeyC" || Args.Code == "KeyX"))
        {
            var selectedCount = await Gantt.GetSelectedRowIndexesAsync();
            if (selectedCount.Count > 0)
            {
                if (Args.Code == "KeyC")
                {
                    ClonedRecords = new List<TaskData>();
                    CopiedRecords = await Gantt.GetSelectedRecordsAsync();
                }
                else if (Args.Code == "KeyX")
                {
                    CopiedRecords = new List<TaskData>();
                    ClonedRecords = await Gantt.GetSelectedRecordsAsync();
                    if (ClonedRecords.Count > 0)
                    {
                        foreach (var i in ClonedRecords)
                        {
                            TaskCollection.Remove(TaskCollection.Where(x => x.TaskID == i.TaskID).FirstOrDefault());
                        }
                        Gantt.RefreshAsync();
                    }
                }
            }
        }
        if (Args.AltKey && Args.Code == "KeyO")
        {
            //Call add record method to insert the empty add row.
            await Gantt.OpenAddDialogAsync();
        }
        if (Args.CtrlKey && Args.Code == "KeyD")
        {
            SelectedRecords.TaskID = TaskCollection.Count + 1;
            //Insert the duplicate record here
            TaskCollection.Insert((int)SelectedIndex + 1, SelectedRecords);
            //Refresh the Gantt data.
            Gantt.RefreshAsync();
        }
    }
    private async Task KeyUp(KeyboardEventArgs Args)
    {
        if (Args.CtrlKey && Args.Code == "KeyV")
        {
            if (CopiedRecords.Count > 0 || ClonedRecords.Count > 0)
            {
                if (SelectedIndex > -1)
                {
                    var ParentID = TaskCollection[(int)SelectedIndex].ParentID;
                    for (var i = CopiedRecords.Count; i > 0; i--)
                    {
                        CopiedRecords[i - 1].TaskID = TaskCollection.Count + 1;
                        CopiedRecords[i - 1].ParentID = ParentID;
                        TaskCollection.Insert((int)SelectedIndex, CopiedRecords[i - 1]);
                    }
                    for (var i = ClonedRecords.Count; i > 0; i--)
                    {
                        ClonedRecords[i - 1].ParentID = ParentID;
                        TaskCollection.Insert((int)SelectedIndex, ClonedRecords[i - 1]);
                    }
                }
                else
                {
                    foreach (var rec in CopiedRecords)
                    {
                        TaskCollection.Insert((int)TaskCollection.Count, rec);
                    }
                    foreach (var rec in ClonedRecords)
                    {
                        TaskCollection.Insert((int)TaskCollection.Count, rec);
                    }
                }
            }
            // Refresh the Gantt data.
            await Gantt.RefreshAsync();
            await Gantt.ClearSelectionAsync();
            CopiedRecords = new List<TaskData>();
            ClonedRecords = new List<TaskData>();
        }
    }
    public class TaskData
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentID { get; set; }
    }
    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() {
        new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 21) },
        new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
        new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentID = 1 },
        new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
        new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 04, 21) },
        new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, ParentID = 5 },
        new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 40, ParentID = 5 },
        new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0", Progress = 30, ParentID = 5 }
    };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNBItEsOCFSkkvLg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}