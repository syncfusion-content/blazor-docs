---
layout: post
title: Rows Drag and Drop in Blazor Gantt Chart Component | Syncfusion®
description: Checkout and learn here all about Row Drag and Drop in Blazor Gantt Chart component and much more details.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Row drag and drop in Blazor Gantt Chart component

The Blazor Gantt Chart component includes built-in support for row drag and drop, enabling rows to be rearranged within the Gantt chart or dropped into custom components. 

To enable this feature, set the [AllowRowDragAndDrop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AllowRowDragAndDrop) property to **true**.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="900px" TreeColumnIndex="1" AllowRowDragAndDrop="true">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
</SfGantt>

@code{
    public List<TaskData> TaskCollection { get; set; }

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
        public int? ParentId { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        return new List<TaskData>
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 09), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 09), Progress = 40, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 08), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 30, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 40, ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 04, 07), Duration = "0", Progress = 30, ParentId = 5 }
        };
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VZrxNdsoVdWZEBWj?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Multiple row drag and drop

You can drag and drop multiple rows simultaneously in the Gantt Chart component. To enable this functionality, set the [GanttSelectionSettings.Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttSelectionSettings.html#Syncfusion_Blazor_Gantt_GanttSelectionSettings_Type) property to **SelectionType.Multiple** , and set the [AllowRowDragAndDrop](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AllowRowDragAndDrop) property is set to **true**.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="900px" TreeColumnIndex="1" AllowRowDragAndDrop="true">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></GanttSelectionSettings>
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
        public int? ParentId { get; set; }
    }


    private static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 09), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 09), Progress = 40, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 08), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 30, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 40, ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 04, 07), Duration = "0", Progress = 30, ParentId = 5 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjBdjnioBxCGTTPX?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Perform row drag and drop action programmatically

To rearrange rows programmatically in the Gantt Chart component, use the [ReorderRowAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ReorderRowAsync_System_Int32_System_Int32_System_String_) method. This method accepts the following parameters: 

- **FromIndexes**: Indexes of the rows to be dragged.  
- **ToIndex**: Target index for placement.  
- **Position**: Drop positions such as above, below, or child.

In the example below, the row at index 2 is moved below the row at index 6 using a button `onclick` event.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Buttons

<div style="margin-bottom: 20px;">
    <SfButton CssClass="e-primary" Content="Dynamic drag and drop" OnClick="drag"></SfButton>
</div>
<SfGantt @ref="Gantt" DataSource="@TaskCollection" Height="450px" Width="900px" TreeColumnIndex="1" AllowRowDragAndDrop="true">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
    ParentID="ParentId">
    </GanttTaskFields>
</SfGantt>

@code{
    public SfGantt<TaskData> Gantt;
    public List<TaskData> TaskCollection { get; set; }

    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    public void drag()
    {
        this.Gantt.ReorderRowAsync(2, 6, "Below");
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

    private static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 09), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 09), Progress = 40, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 08), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 30, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 40, ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 04, 07), Duration = "0", Progress = 30, ParentId = 5 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rDhdNnieBHrErOgh?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Customize the drag and drop action

Customize the drag and drop behavior in the Gantt component using the [RowDragStarting](https://blazor.syncfusion.com/documentation/gantt-chart/events#rowdragstarting), [RowDropping](https://blazor.syncfusion.com/documentation/gantt-chart/events#rowdropping), [RowDropped](https://blazor.syncfusion.com/documentation/gantt-chart/events#rowdropped) events. These events provide control over the drag lifecycle, allowing precise handling of row interactions.

In this example, the row drop action is canceled when the **TaskID** is 2.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids

<div style="margin-bottom: 10px; margin-left: 180px;">
    <p style="color:red">@message</p>
</div>

<SfGantt @ref="Gantt" DataSource="@TaskCollection" Height="450px" Width="900px" AllowRowDragAndDrop="true">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttEditSettings AllowTaskbarEditing="true"></GanttEditSettings>
    <GanttEvents RowDropping="RowDropping" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    public SfGantt<TaskData> Gantt;
    public List<TaskData> TaskCollection { get; set; }
    private string message = string.Empty;

    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
    }

    public void RowDropping(RowDroppingEventArgs<TaskData> args)
    {
        var draggedTask = args.Data.FirstOrDefault();
        if (draggedTask != null && draggedTask.TaskId == 2)
        {
            message = $"Drop cancelled for Task: {draggedTask.TaskName} (ID: {draggedTask.TaskId})";
            args.Cancel = true;
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
    }

    private static List<TaskData> GetTaskCollection()
    {
        return new List<TaskData>
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 09), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 09), Progress = 40, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 08), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 30, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 40, ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 04, 07), Duration = "0", Progress = 30, ParentId = 5 }
        };
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXrdNxMSLRfZkiDJ?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}