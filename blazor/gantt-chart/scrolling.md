---
layout: post
title: Scrolling in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about scrolling in Syncfusion Blazor Gantt Chart component and much more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Scrolling in Blazor Gantt Chart component

Scrolling in the Blazor Gantt Chart component enables smooth navigation across extensive project datasets and long timelines. It ensures taskbars, grid rows, and timeline cells remain visible within the viewport. Scrollbars automatically appear when content exceeds the component’s defined [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_Height) and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_Width), supporting vertical scrolling for rows, horizontal scrolling for columns, and timeline scrolling for extended chart areas.

Virtual scrolling enhances performance by rendering only the visible portion of the dataset. Scrollbars are equipped with ARIA labels for accessibility, making them compatible with screen readers. They also adapt to responsive layouts, although horizontal scrolling may be required on narrow screens with wide timelines.

> By default, both `height` and `width` are set to **auto**.

## Configure scrollbar display

Scrollbars appear based on content size:

- **Vertical scrollbar:** Triggers when task row height exceeds the component’s height.
- **Horizontal scrollbar:** Triggers when column width exceeds the tree grid pane.
- **Timeline scrollbar:** Triggers when the timeline exceeds the chart area.

For precise layout control, set fixed dimensions using pixel values for both [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_Height) and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_Width).

The following example sets fixed dimensions:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="900px" Toolbar="@(new List<string>() { "Add","Edit" })">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskID" Width="100"></GanttColumn>
        <GanttColumn Field="TaskName" Width="250" AllowEditing="false"></GanttColumn>
        <GanttColumn Field="StartDate"></GanttColumn>
        <GanttColumn Field="Duration"></GanttColumn>
        <GanttColumn Field="Progress"></GanttColumn>
    </GanttColumns>
    <GanttEditSettings AllowEditing="true" AllowAdding="true"></GanttEditSettings>
</SfGantt>

@code{
    private List<TaskData> TaskCollection { get; set; }

    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
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
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjLeNEVIVpUHKMmN?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Configure responsive scrolling

You can make the Gantt Chart component responsive by setting its [Height](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_Height) and [Width](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_Width) to **100%**, allowing it to fully occupy the parent container. When height is set to **100%**, the parent element must have a defined `Height` to support proper layout rendering. The Gantt will automatically adjust when the container is resized.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<div Height="600px" class="gantt">
    <SfGantt DataSource="@TaskCollection" Toolbar="@(new List<string>() { "Add" })" Height="100%" Width="100%">
        <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
        </GanttTaskFields>
        <GanttEditSettings AllowAdding="true"></GanttEditSettings>
    </SfGantt>
</div>

<style>
    .gantt {
        border: 2px solid;
        resize: both;
        overflow: auto;
    }
</style>

@code{
    private List<TaskData> TaskCollection { get; set; }
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
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
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNrosXCAgfwPOfeT?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


## Auto focus taskbar on row click 

You can enable automatic scrolling to the corresponding taskbar in the timeline when a row is clicked in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Gantt chart by using the [ScrollToTaskbarOnClick](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ScrollToTaskbarOnClick) property. This feature ensures that the selected task is brought into view within the timeline area, improving navigation and focus during interaction.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<div class="controls">
      <ejs-checkbox #checkbox label="Enable / Disable Auto-focus Tasks" (change)="onCheckBoxChange($event)" [checked]="true">
      </ejs-checkbox>
    </div>
<SfGantt #ganttInstance DataSource="@TaskCollection" Height="450px" Width="700px" ScrollToTaskbarOnClick="true">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
</SfGantt>

@code {
    public List<TaskData> TaskCollection { get; set; }
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

    public onCheckBoxChange(args: ChangeEventArgs): void {
     this.ganttInstance.ScrollToTaskbarOnClick = (args.checked as boolean);
  }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() {
        new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 02), EndDate = new DateTime(2022, 04, 08)},
        new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 02), Duration = "4", Progress = 30, ParentID = 1 },
        new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 02), Duration = "4", Progress = 40, ParentID = 1 },
        new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 02), Duration = "5", Progress = 30, ParentID = 1 },
        new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 12), EndDate = new DateTime(2022, 05, 17) },
        new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 12), Duration = "3", Progress = 30, ParentID = 5 },
        new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 05, 13), Duration = "3", Progress = 40, ParentID = 5 },
        new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 05, 16), Duration = "0", Progress = 30, ParentID = 5 }
    };
        return Tasks;
    }
}
https://blazorplayground.syncfusion.com/rDhIWZCKJRbZhRRf
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXBejaVoVfoSMdbx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Programmatically scroll to task row and timeline

The Blazor Gantt Chart component provides built-in support for automatically scrolling to specific tasks and timeline positions, which is especially useful when working with large datasets.

To scroll vertically to a specific task row, use the [SelectRowAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_SelectRowsAsync_System_Int32___) method to select the desired task and apply [ScrollIntoViewAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ScrollIntoViewAsync_System_Int32_System_Int32_) to bring the selected row into view.

To scroll horizontally to a specific timeline date, use the [ScrollToTimelineAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ScrollToTimelineAsync_System_DateTime_) method. This helps focus the timeline on a particular point in time.

To scroll directly to a specific task within the timeline, use the [ScrollToTaskbarAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ScrollToTaskbarAsync_System_String_) method with the task ID. This ensures the task is visible within the timeline view.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<div style="display: flex; gap: 15px; margin-bottom: 20px;">
    <!-- Scroll Position -->
    <div>
        <label style="font-weight:20px" for="columnIndex">Scroll Row:</label> 
        <div style="display: flex; align-items: center; gap: 10px; margin-top: 5px;">
            <SfTextBox @bind-Value="ColumnIndex" Placeholder="Column Index (e.g., 1)"  Width="160px" />
            <SfTextBox @bind-Value="RowIndex" Placeholder="Row Index (e.g., 1)" Width="150px" />
            <SfButton OnClick="SelectRow">Scroll Position</SfButton>
        </div>
    </div>
    <!-- Scroll to Date -->
    <div>
        <label style="font-weight:20px" for="scrollDate">Scroll to Timeline Date:</label>
        <div style="display: flex; align-items: center; gap: 10px; margin-top: 5px;">
            <SfTextBox @bind-Value="ScrollDate" Placeholder="MM/DD/YYYY" Width="150px" />
            <SfButton OnClick="ScrollToDate">Scroll Date</SfButton>
        </div>
    </div>

    <!-- Scroll to Task -->
    <div>
        <label style="font-weight:20px" for="taskId">Scroll to Task:</label>
        <div style="display: flex; align-items: center; gap: 10px; margin-top: 5px;">
            <SfTextBox @bind-Value="ScrollTaskId" Placeholder="e.g., 3" Width="150px" />
            <SfButton OnClick="ScrollToTask">Scroll Task</SfButton>
        </div>
    </div>
</div>

<SfGantt @ref="GanttInstance" ID="Gantt" DataSource="@TaskCollection" Height="350px" Width="100%">
    <GanttTaskFields Id="ProjectId" Name="ProjectName" StartDate="ProjectStartDate" EndDate="ProjectEndDate" Duration="ProjectDuration" Progress="ProjectProgress" Dependency="Predecessor" ParentID="ParentID" />
    <GanttColumns>
        <GanttColumn Field="ProjectId" HeaderText="Task ID" />
        <GanttColumn Field="ProjectName" HeaderText="Task Name" />
        <GanttColumn Field="ProjectStartDate" HeaderText="Start Date" />
        <GanttColumn Field="ProjectEndDate" HeaderText="End Date" />
        <GanttColumn Field="ProjectDuration" HeaderText="Duration" />
        <GanttColumn Field="Field1" HeaderText="Rebounds" />
        <GanttColumn Field="FIELD2" HeaderText="Year" />
        <GanttColumn Field="FIELD3" HeaderText="Stint" />
        <GanttColumn Field="FIELD4" HeaderText="TMID" />
        <GanttColumn Field="FIELD5" HeaderText="LGID" />
        <GanttColumn Field="FIELD6" HeaderText="GP" />
        <GanttColumn Field="Field7" HeaderText="GS" />
        <GanttColumn Field="Field8" HeaderText="Minutes" />
        <GanttColumn Field="Field9" HeaderText="Points" />
        <GanttColumn Field="Field10" HeaderText="ORebounds" />
        <GanttColumn Field="Field11" HeaderText="DRebounds" />
    </GanttColumns>
</SfGantt>

@code {
    public SfGantt<TaskData> GanttInstance;
    public List<TaskData> TaskCollection { get; set; } = new();
    public string RowIndex { get; set; }
    public string ScrollDate { get; set; }
    public string ScrollTaskId { get; set; }
    public string ColumnIndex { get; set; }

    protected override void OnInitialized()
    {
        TaskCollection = VirtualData.GetTreeVirtualData();
    }

    public async Task SelectRow()
    {
        if (int.TryParse(RowIndex, out var rowIndex) && int.TryParse(ColumnIndex, out var columnIndex))
        {
            await this.GanttInstance.SelectRowAsync(rowIndex);
            await this.GanttInstance.ScrollIntoViewAsync(columnIndex, rowIndex);
        }
    }


    public async Task ScrollToDate()
    {
        if (DateTime.TryParse(ScrollDate, out var date))
        {
            await this.GanttInstance.ScrollToTimelineAsync(date);
        }
    }

    public async Task ScrollToTask()
    {
        if (int.TryParse(ScrollTaskId, out var taskId))
        {
            await this.GanttInstance.ScrollToTaskbarAsync(taskId);
        }
    }

    public class VirtualData
    {
        public static List<TaskData> GetTreeVirtualData()
        {
            string[] Names = new string[] { "VINET", "TOMSP", "HANAR", "VICTE", "SUPRD" };
            List<TaskData> DataCollection = new();
            int x = 0;
            for (int i = 1; i <= 10; i++)
            {
                var parent = new TaskData
                {
                    ProjectId = ++x,
                    ProjectName = "Task " + x,
                    ProjectStartDate = new DateTime(2022, 1, 9),
                    ProjectEndDate = new DateTime(2022, 1, 13),
                    ProjectDuration = "10",
                    ProjectProgress = x + 20,
                    ParentID = null,
                    Predecessor = null,
                };
                DataCollection.Add(parent);

                for (int j = 1; j <= 5; j++)
                {
                    DataCollection.Add(new TaskData
                    {
                        ProjectId = ++x,
                        ProjectName = "Task " + x,
                        ProjectStartDate = new DateTime(2022, 1, 9),
                        ProjectEndDate = new DateTime(2022, 1, 13),
                        ProjectDuration = "10",
                        ProjectProgress = x + 20,
                        ParentID = parent.ProjectId,
                        Predecessor = i + "FS",
                        Field1 = Names[x % Names.Length],
                        FIELD2 = 1967 + x,
                        FIELD3 = 395 + x,
                        FIELD4 = 87 + x,
                        FIELD5 = 410 + x,
                        FIELD6 = 67 + x,
                        Field7 = x * 100,
                        Field8 = x * 10,
                        Field9 = x * 10,
                        Field10 = x * 100,
                        Field11 = x * 100,
                        Field12 = x * 1000,
                    });
                }
            }
            return DataCollection;
        }
    }

    public class TaskData
    {
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public DateTime? ProjectStartDate { get; set; }
        public DateTime? ProjectEndDate { get; set; }
        public string ProjectDuration { get; set; }
        public int ProjectProgress { get; set; }
        public int? ParentID { get; set; }
        public string Predecessor { get; set; }
        public string Field1 { get; set; }
        public int FIELD2 { get; set; }
        public int FIELD3 { get; set; }
        public int FIELD4 { get; set; }
        public int FIELD5 { get; set; }
        public int FIELD6 { get; set; }
        public int Field7 { get; set; }
        public int Field8 { get; set; }
        public int Field9 { get; set; }
        public int Field10 { get; set; }
        public int Field11 { get; set; }
        public int Field12 { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtrSWXCqfpIlMXnl?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}