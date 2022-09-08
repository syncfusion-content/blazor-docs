---
layout: post
title: Accessibility in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about Accessibility in Syncfusion Blazor Gantt Chart component and more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Accessibility in Blazor Gantt Chart Component

Accessibility is achieved in the Gantt component through the WAI-ARIA standard and keyboard navigations. The Gantt features can be effectively accessed through assistive technologies such as screen readers. It is also available with a built-in keyboard navigation support; it makes accessibility easier for the people who use assistive technologies or who completely rely on the Keyboard support.

## WAI-ARIA

WAI-ARIA (Accessibility Initiative – Accessible Rich Internet Applications) defines a way to increase the accessibility of web pages, dynamic content, and user interface components developed with Ajax, HTML, JavaScript, and related technologies. ARIA provides additional semantics to describe the role, state, and functionality of web components. It helps to provide information about elements in a document for assistive technology.

The following ARIA attributes are used in Gantt:

| **Attributes** | **Description** |
| --- | --- |
| grid (role) | This attribute is added to the `e-table` element present in the Gantt, which represents Grid part. |
| gridcell (role) | This attribute is added to the `td` elements present within the `e-table`, which represents the work cells of Gantt .|
| columnheader (role) | This attribute is added to the `th` elements within the `e-table`, which represents the header cells of Grid table. |
| separator (role) | This attribute is added to the `e-split-bar` element, which represents the splitter between the Grid table and Chart. |
| dialog (role) | This attribute is added to the `e-dialog` element, which represents the pop-up dialog. |
| toolbar (role) | This attribute is added to the `e-gantt-toolbar` element, which represents the toolbars of Gantt. |
| aria-label | It indicates the element's information`<br>`. It is assigned to the Gantt UI elements such as timeline cell, taskbar, left label, right label, dependency line, and event markers. |
| aria-selected | This attribute is assigned to the Gantt chart row and is set to `false` by default. The value is changed to `true` when the user selects a grid cell or task. |
| aria-expanded | This attribute is assigned to the Gantt chart parent task row. The value is changed to `true` when the user clicks a parent taskbar to expand. After the user clicked a parent taskbar to collapse, the attribute value is changed to `false`. |
| aria-grabbed | This attribute is assigned to the taskbars of Gantt when the user tries to achieve taskbar editing. |

## Keyboard navigation

Gantt functionalities can be interactive with keyboard shortcuts.

The following keyboard shortcuts are supported by Gantt.

Interaction Keys |Description
-----|-----
<kbd>Home</kbd> |Selects the first row.
<kbd>End</kbd> |Selects the last row.
<kbd>DownArrow</kbd> |Moves the cell focus/row or cell selection downward.
<kbd>UpArrow</kbd> |Moves the cell focus/row or cell selection upward.
<kbd>LeftArrow</kbd> |Moves the cell focus/row or cell selection left side.
<kbd>RightArrow</kbd> |Moves the cell focus/row or cell selection right side.
<kbd>Ctrl + Up Arrow</kbd> |Collapses all tasks.
<kbd>Ctrl + Down Arrow</kbd> |Expands all tasks.
<kbd>Ctrl + Shift + Up Arrow</kbd> |Collapses the selected row.
<kbd>Ctrl + Shift + Down Arrow</kbd> |Expands the selected row.
<kbd>Enter</kbd> |Saves request.
<kbd>Esc</kbd> |Cancels request.
<kbd>Insert</kbd> |Adds a new row.
<kbd>Ctrl + Insert</kbd> |Opens addRowDialog.
<kbd>Ctrl + F2</kbd> |Opens editRowDialog.
<kbd>Delete</kbd> |Deletes the selected row.
<kbd>Shift + F5</kbd> |FocusTask
<kbd>Ctrl + Shift + F</kbd> |Focus search
<kbd>Shift + DownArrow</kbd> |Extends the row/cell selection downwards.
<kbd>Shift + UpArrow</kbd> |Extends the row/cell selection upwards.
<kbd>Shift + LeftArrow</kbd> |Extends the cell selection to the left side.
<kbd>Shift + RightArrow</kbd> |Extends the cell selection to the right side.

> You can refer to our [Blazor Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Gantt Chart example](https://blazor.syncfusion.com/demos/gantt-chart/default-functionalities?theme=bootstrap4) to know how to render and configure the Gantt.

## How to bind native events

Include the native events and attributes in the Blazor Gantt chart.

In the following example, the KeyDown and KeyUp method is called every time any key is down and up, and the action is customized using the following keys.

Interaction Keys |Description
-----|-----
<kbd>Ctrl + X</kbd> | It is used to cut the selected records from Gantt.
<kbd>Ctrl + C</kbd> | It is used to copy the selected records from Gantt..
<kbd>DownArrow</kbd> | Moves the cell focus/row or cell selection downward.
<kbd>Ctrl + V</kbd> | It is used to paste the copied or cut records in the selected position..
<kbd>Ctrl + D</kbd> | Used to duplicate a selected record.
<kbd>Enter</kbd> | It is used to open the add dialog.

### Example

```cshtml
<SfGantt @ref=Gantt DataSource="@TaskCollection" @onkeydown="KeyDown" @onkeyup="KeyUp" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttSelectionSettings Mode="SelectionMode.Row" Type="SelectionType.Multiple"></GanttSelectionSettings>
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
        //remove the maintained value while deselecting the records
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
                            TaskCollection.Remove(TaskCollection.Where(x => x.TaskId == i.TaskId).FirstOrDefault());
                        }
                        Gantt.RefreshAsync();
                    }
                }
            }
        }
        if (Args.Key == "Enter")
        {
            //call add record method to insert the empty add row.
            await Gantt.OpenAddDialogAsync();
        }
        if (Args.CtrlKey && Args.Code == "KeyD")
        {
            SelectedRecords.TaskId = TaskCollection.Count + 1;
            //insert the duplicate record here
            TaskCollection.Insert((int)SelectedIndex + 1, SelectedRecords);
            // refresh the Gantt data.
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
                    var parentID = TaskCollection[(int)SelectedIndex].ParentId;
                    for (var i = CopiedRecords.Count; i > 0; i--)
                    {
                        CopiedRecords[i - 1].TaskId = TaskCollection.Count + 1;
                        CopiedRecords[i - 1].ParentId = parentID;
                        TaskCollection.Insert((int)SelectedIndex, CopiedRecords[i - 1]);
                    }
                    for (var i = ClonedRecords.Count; i > 0; i--)
                    {
                        ClonedRecords[i - 1].ParentId = parentID;
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
            // refresh the Gantt data.
            await Gantt.RefreshAsync();
            await Gantt.ClearSelectionAsync();
            CopiedRecords = new List<TaskData>();
            ClonedRecords = new List<TaskData>();
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
        new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 21) },
        new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentId = 1 },
        new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentId = 1 },
        new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentId = 1 },
        new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 04, 21) },
        new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, ParentId = 5 },
        new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 40, ParentId = 5 },
        new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0", Progress = 30, ParentId = 5 }
    };
        return Tasks;
    }
}
```
