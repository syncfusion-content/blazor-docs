---
layout: post
title: Row Selection in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about row Selection in Syncfusion Blazor Gantt Chart component and much more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Row selection in  Blazor Gantt Chart Component

The  Blazor Gantt Chart Component supports row selection using mouse clicks or keyboard navigation (arrow keys). This enables users to highlight, manipulate, or trigger actions on selected task rows.

## Enable single row selection

You can enable single row selection in the Gantt Chart component by setting [SelectionSettings.Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SelectionMode.html) to **Row** and [SelectionSettings.Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SelectionType.html) to **Single**. This allows you to select only one task row at a time.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px" AllowSelection="true">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttSelectionSettings Mode="Syncfusion.Blazor.Grids.SelectionMode.Row" Type="Syncfusion.Blazor.Grids.SelectionType.Single"></GanttSelectionSettings>
</SfGantt>

@code {
    public List<TaskData>? TaskCollection { get; set; }

    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
    }

    public class TaskData
    {
        public int TaskId { get; set; }
        public string? TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 08), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 04, 02), EndDate = new DateTime(2026, 04, 06), Progress = 40, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 08), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 08), Progress = 30, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 08), Progress = 40, ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 5 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VNVdjHCbSdDNlUmQ?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

N> `Row` selection is the default type of Gantt Chart selection mode.

## Enable multiple row selection

You can enable multiple row selection in the Gantt Chart component by setting  [SelectionSettings.Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SelectionMode.html) to **Row** and [SelectionSettings.Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SelectionType.html) to **Multiple**. This allows selection of more than one task row at a time by holding down the **Ctrl** key while clicking on multiple rows.


{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px" AllowSelection="true">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttSelectionSettings Mode="Syncfusion.Blazor.Grids.SelectionMode.Row" Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GanttSelectionSettings>
</SfGantt>

@code {
    public List<TaskData>? TaskCollection { get; set; }

    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
    }

    public class TaskData
    {
        public int TaskId { get; set; }
        public string? TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 08), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 04, 02), EndDate = new DateTime(2026, 04, 06), Progress = 40, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 08), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 08), Progress = 30, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 08), Progress = 40, ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 5 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjVdZdWvenMJmblu?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Select row at initial rendering

You can highlight or pre-select a specific row during the initial rendering of the Gantt Chart component by setting the [SelectedRowIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_SelectedRowIndex) property. This selects the row at the specified index when the Gantt Chart loads.

The following example selects the row at index 3 during initial load:

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px" AllowSelection="true" SelectedRowIndex="3">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
</SfGantt>

@code {
    public List<TaskData>? TaskCollection { get; set; }

    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
    }

    public class TaskData
    {
        public int TaskId { get; set; }
        public string? TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 08), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 04, 02), EndDate = new DateTime(2026, 04, 06), Progress = 40, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 08), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 08), Progress = 30, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 08), Progress = 40, ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 5 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDVnjRWbynVFPPdV?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}


## Select rows externally

You can programmatically or dynamically select single rows, multiple rows, or a range of rows in the Blazor Gantt Chart component.

### Single row selection

Select a single row in the Gantt Chart component by calling the [SelectRowAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_SelectRowAsync_System_Int32_System_Boolean_) method with the desired row index.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.Inputs

<div style="margin-bottom:15px; display: flex; align-items: center; gap: 10px;">
    <label style="margin: 0;">Enter the row index:</label>
    <SfNumericTextBox TValue="int" @bind-Value="@RowIndexValue" Width="150px"></SfNumericTextBox>
    <SfButton OnClick="SelectRow">Select Row</SfButton>
</div>
<div style="margin-top:20px; padding:10px;">
    <SfGantt @ref="Gantt" SelectedRowIndex="0" DataSource="@TaskCollection" Height="450px" Width="700px">
        <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
        </GanttTaskFields>
        <GanttSelectionSettings Mode="Syncfusion.Blazor.Grids.SelectionMode.Row" Type="Syncfusion.Blazor.Grids.SelectionType.Single"></GanttSelectionSettings>
    </SfGantt>
</div>

@code {
    public SfGantt<TaskData>? Gantt;
    public int RowIndexValue;
    private List<TaskData>? TaskCollection { get; set; }

    public async Task SelectRow()
    {
        if(Gantt!=null)
        {
            await Gantt.SelectRowAsync(RowIndexValue);
        }
        
    }

    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
    }

    public class TaskData
    {
        public int TaskId { get; set; }
        public string? TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 08), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 04, 02), EndDate = new DateTime(2026, 04, 06), Progress = 40, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 08), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 08), Progress = 30, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 08), Progress = 40, ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 5 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNBnjxCvIxUuOZvE?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

### Multiple rows selection

Select multiple rows in the Gantt Chart component by using the [SelectRowsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_SelectRowsAsync_System_Int32___) method with an array of row indexes.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Buttons

<div style="padding: 10px 0px 20px 0px">
    <SfButton CssClass="btn" OnClick="() => SelectMultipleRows(new[] { 1, 3 })">Select [1, 3]</SfButton>
    <SfButton CssClass="btn" OnClick="() => SelectMultipleRows(new[] { 0, 2 })">Select [0, 2]</SfButton>
    <SfButton CssClass="btn" OnClick="() => SelectMultipleRows(new[] { 2, 4 })">Select [2, 4]</SfButton>
    <SfButton CssClass="btn" OnClick="() => SelectMultipleRows(new[] { 0, 5 })">Select [0, 5]</SfButton>
    <SfButton CssClass="btn" OnClick="() => SelectMultipleRows(new[] { 1, 6 })">Select [1, 6]</SfButton>
</div>
<div style="padding: 10px 0px 20px 0px">
    <SfButton CssClass="btn" OnClick="() => SelectMultipleRows(new[] { 0, 2, 7 })">Select [0, 2, 7]</SfButton>
    <SfButton CssClass="btn" OnClick="() => SelectMultipleRows(new[] { 1, 3, 4 })">Select [1, 3, 4]</SfButton>
    <SfButton CssClass="btn" OnClick="() => SelectMultipleRows(new[] { 4, 5, 6 })">Select [4, 5, 6]</SfButton>
    <SfButton CssClass="btn" OnClick="() => SelectMultipleRows(new[] { 2, 5, 6 })">Select [2, 5, 6]</SfButton>
</div>
<SfGantt @ref="Gantt" DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttSelectionSettings Mode="Syncfusion.Blazor.Grids.SelectionMode.Row" Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GanttSelectionSettings>
</SfGantt>

@code {
    public SfGantt<TaskData>? Gantt;
    public List<TaskData>? TaskCollection { get; set; }

    public async Task SelectMultipleRows(int[] rowIndexes)
    {
        if(Gantt!=null)
        {
            await Gantt.SelectRowsAsync(rowIndexes);
        }
        
    }

    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
    }

    public class TaskData
    {
        public int TaskId { get; set; }
        public string? TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 08), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 04, 02), EndDate = new DateTime(2026, 04, 06), Progress = 40, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 08), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 08), Progress = 30, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 08), Progress = 40, ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 5 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXVRtHsbodyXvaxe?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Get selected row information

To access selected row details in the Blazor Gantt Chart component:

- [GetSelectedRowIndexesAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_GetSelectedRowIndexesAsync) – Returns an array of index positions of the selected rows.
- [GetSelectedRecordsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_GetSelectedRecordsAsync) – Returns an array of data objects corresponding to the selected rows.

{% tabs %}
{% highlight razor tabtitle="Home.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom:20px">
    <SfButton CssClass="action-button" @onclick="GetSelectedRowInfo">Show Selected Tasks</SfButton>
</div>
@if (SelectedRecords?.Count > 0 && SelectedIndexes?.Count > 0)
{
    <div class="table-container">
        <table class="task-table">
            <thead>
                <tr>
                    <th>Index</th>
                    <th>Task Details</th>
                </tr>
            </thead>
            <tbody>
                @for (int i = 0; i < Math.Min(SelectedRecords.Count, SelectedIndexes.Count); i++)
                {
                    var record = SelectedRecords[i];
                    var index = SelectedIndexes[i];
                    <tr>
                        <td>@index</td>
                        <td>
                            <div><strong>Task ID:</strong> @record.TaskId</div>
                            <div><strong>Task Name:</strong> @record.TaskName</div>
                            <div><strong>Start Date:</strong> @record.StartDate.ToString("MM/dd/yyyy")</div>
                            <div><strong>Duration:</strong> @(record.Duration ?? "N/A")</div>
                            <div><strong>Progress:</strong> @record.Progress %</div>
                        </td>
                    </tr>
                }
            </tbody>
        </table>
    </div>
}

<SfGantt @ref="Gantt" DataSource="@TaskCollection" Height="450px" Width="100%" AllowSelection="true">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate"
                     Duration="Duration" Progress="Progress" ParentID="ParentId" />
  <GanttSelectionSettings Mode="Syncfusion.Blazor.Grids.SelectionMode.Row" Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GanttSelectionSettings></SfGantt>

<style>
    .table-container {
        margin: 20px auto;
        width: 90%;
        max-width: 960px;
    }

    .task-table {
        width: 100%;
        border-collapse: collapse;
        font-family: Arial, sans-serif;
        font-size: 14px;
        box-shadow: 0 2px 6px rgba(0, 0, 0, 0.1);
    }

    .task-table th,
    .task-table td {
        padding: 10px 14px;
        border: 1px solid #ddd;
        text-align: left;
    }

    .task-table th {
        background-color: #f0f0f0;
        font-weight: bold;
        color: #333;
    }
    
    .task-table td div {
        margin-bottom: 4px;
    }
</style>

@code {
    public SfGantt<TaskData>? Gantt;
    public List<TaskData>? TaskCollection { get; set; }
    public List<TaskData> SelectedRecords { get; set; } = new();
    public List<int> SelectedIndexes { get; set; } = new();

    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
    }

    private async Task GetSelectedRowInfo()
    {
        if(Gantt!=null)
        {
            SelectedIndexes = await Gantt.GetSelectedRowIndexesAsync();
            SelectedRecords = await Gantt.GetSelectedRecordsAsync();
        }
        
    }

    public class TaskData
    {
        public int TaskId { get; set; }
        public string? TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string? Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        return new List<TaskData>
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 08), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 04, 02), EndDate = new DateTime(2026, 04, 06), Progress = 40, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 08), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 08), Progress = 30, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 08), Progress = 40, ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 5 }
        };
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LthdNHMloHwZEHBM?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}
