---
layout: post
title: Selection in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about Selection in Syncfusion Blazor Gantt Chart component and much more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Selection in Blazor Gantt Chart Component

The Selection feature provides the ability to highlight a row or cell in the Gantt component. Selection can be performed using arrow keys or mouse clicks.

By default, selection is enabled. To disable selection, set the [AllowSelection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AllowSelection) property to **false**.

The Gantt component supports two types of selection that can be set by using the [SelectionSettings.Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SelectionType.html) property. They are:

* **Single:** Allows selection of only one row or cell at a time. This is the default behavior.
* **Multiple:** Enables selection of multiple rows or cells. To perform multi-selection, press and hold the **Ctrl** key (on Windows/Linux) or **Cmd** key (on macOS) while clicking the desired rows or cells.

## Selection mode

The Syncfusion Blazor Gantt Chart component supports three selection modes, configured using [SelectionSettings.Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.SelectionMode.html) property. They are:

- **Row:** Selects only rows. This is the default mode.
- **Cell:** Selects only individual cells.
- **Both:** Enables selection of both rows and cells at the same time.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<div style="margin-bottom:5px">
    <label style="padding: 30px 2px 0 0;font-weight:bold"> Choose selection mode: </label>
    <SfDropDownList TValue="Syncfusion.Blazor.Grids.SelectionMode" TItem="DropDownOrder" @bind-Value="@SelectionModeValue" DataSource="@DropDownData" Width="100px">
        <DropDownListFieldSettings Text="Text" Value="Value"></DropDownListFieldSettings>
        <DropDownListEvents ValueChange="@OnChange" TValue="Syncfusion.Blazor.Grids.SelectionMode" TItem="DropDownOrder"></DropDownListEvents>
    </SfDropDownList>
</div>

<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID"></GanttTaskFields>
    <GanttSelectionSettings Mode="@SelectionModeValue"></GanttSelectionSettings>
</SfGantt>

@code {
    private List<TaskData> TaskCollection { get; set; }
    public Syncfusion.Blazor.Grids.SelectionMode SelectionModeValue { get; set; } = Syncfusion.Blazor.Grids.SelectionMode.Both;
    public class DropDownOrder
    {
        public string Text { get; set; }
        public Syncfusion.Blazor.Grids.SelectionMode Value { get; set; }
    }
    List<DropDownOrder> DropDownData = new List<DropDownOrder>
    {
        new DropDownOrder() { Text = "Both", Value = Syncfusion.Blazor.Grids.SelectionMode.Both },
        new DropDownOrder() { Text = "Row", Value = Syncfusion.Blazor.Grids.SelectionMode.Row },
        new DropDownOrder() { Text = "Cell", Value = Syncfusion.Blazor.Grids.SelectionMode.Cell },
    };

    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    public void OnChange(ChangeEventArgs<Syncfusion.Blazor.Grids.SelectionMode, DropDownOrder> Args)
    {
        SelectionModeValue = Args.Value;
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
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 08) },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 04, 08) },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 40, ParentID = 5 },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 07), Duration = "0", Progress = 30, ParentID = 5 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjresXWoKPmfErzv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Toggle selection

Toggle selection allows you to select and deselect a specific row or cell with repeated clicks. To enable this feature, set the [EnableToggle](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.GridSelectionSettings.html#Syncfusion_Blazor_Grids_GridSelectionSettings_EnableToggle) property of `SelectionSettings` to **true**.

When enabled, clicking a selected row or cell will deselect it, and clicking it again will reselect it—vice versa. By default, the `EnableToggle` property is set to **false**.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons

<div style="padding-bottom:20px">
  <SfButton @onclick="ToggleSelection">@buttonText</SfButton>
</div>
<SfGantt @ref="Gantt" DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttSelectionSettings Mode="Syncfusion.Blazor.Grids.SelectionMode.Row" Type="Syncfusion.Blazor.Grids.SelectionType.Multiple" EnableToggle="@toggle"></GanttSelectionSettings>
</SfGantt>

@code{
    public SfGantt<TaskData> Gantt;
    private bool toggle = true;
    private string buttonText = "Disable Toggle";

    private void ToggleSelection()
    {
        toggle = !toggle;
        buttonText = toggle ? "Disable Toggle" : "Enable Toggle";
    }

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
        public int? ParentID { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() 
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 08), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "3", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXLICXCdiRznIEHP?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Drag selection

The Gantt Chart component allows to select range of cells or rows by mouse or touch dragging. To enable this, set [GanttSelectionSettings.AllowDragSelection](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttSelectionSettings.html#Syncfusion_Blazor_Gantt_GanttSelectionSettings_AllowDragSelection) to **true** and [GanttSelectionSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttSelectionSettings.html) to **Multiple**.

>* Drag selection is supported in all selection modes, configurable using the [Mode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttSelectionSettings.html#Syncfusion_Blazor_Gantt_GanttSelectionSettings_Mode) property.

>* When cell selection is enabled, it works with both **Flow** and **Box** types defined by [CellSelectionMode](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttSelectionSettings.html#Syncfusion_Blazor_Gantt_GanttSelectionSettings_CellSelectionMode) property.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids

<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttSelectionSettings  Mode="Syncfusion.Blazor.Grids.SelectionMode.Row" Type="Syncfusion.Blazor.Grids.SelectionType.Multiple" AllowDragSelection="true"></GanttSelectionSettings>
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
        public int? ParentID { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() 
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 08), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjrSsDjuLxoffvJy?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Clear selection

To clear selected rows and cells in the Gantt component, use the [ClearSelectionAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ClearSelectionAsync) method.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Buttons


<div style="margin-bottom: 16px;">
    <SfButton @onclick="select" style="margin-right: 12px;">Select Rows</SfButton>
    <SfButton @onclick="clear">Clear Selection</SfButton>
</div>
<SfGantt @ref="GanttInstance" DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttSelectionSettings Mode="Syncfusion.Blazor.Grids.SelectionMode.Row" Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GanttSelectionSettings>
</SfGantt>

@code{
    public SfGantt<TaskData> GanttInstance;
    private List<TaskData> TaskCollection { get; set; }

    public void select()
    {
        this.GanttInstance.SelectRowsAsync(new int[] {1,2,3});
    }
    public void clear() {
        this.GanttInstance.ClearSelectionAsync();
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
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 08), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "3", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZryWDMeJjRDhaTI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Touch interaction

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Gantt Chart component supports touch interaction, allowing you to intuitively navigate and interact with chart elements on touch-enabled devices like smart phones and tablets. This feature enhances usability by allowing intuitive gestures for selecting and managing tasks.

[Single Row selection](selection#selection-mode): Tapping a row on a touch screen automatically selects it, offering a straightforward way to interact with the chart.

[Multiple Row selection](selection#multiple-row-selection): To select multiple rows, tap a row to display a popup that activates multi-selection mode. After tapping the popup, continue tapping the desired rows to select them. This allows you to select multiple rows simultaneously, as illustrated below:

![Multiple selection in Blazor Gantt Chart](images/blazor-gantt-chart-multiple-selection.PNG)