---
layout: post
title: Frozen columns in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about frozen columns in Syncfusion Blazor Gantt Chart component and more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Frozen columns in Blazor Gantt Component

The frozen columns feature in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Gantt Chart allows specific columns to stay fixed on the left side while scrolling horizontally. This enhances readability and simplifies navigation across wide dataset

To enable frozen columns, use the [FrozenColumns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_FrozenColumns) property in the Gantt component. 

The following example demonstrates setting the `FrozenColumns` value to 2, which keeps the first two columns fixed during horizontal scrolling.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px" FrozenColumns="2">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttSplitterSettings Position ="70%"></GanttSplitterSettings>
</SfGantt>

@code {
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
        List<TaskData> Tasks = new List<TaskData>() {
        new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2023, 02, 06), EndDate = new DateTime(2022, 02, 09) },
        new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2023, 02, 06), Duration = "0", Progress = 30, ParentID = 1 },
        new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2023, 02, 06), Duration = "4", Progress = 40, ParentID = 1 },
        new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2023, 02, 06), Duration = "0", Progress = 30, ParentID = 1 },
        new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2023, 02, 06), EndDate = new DateTime(2023, 02, 08) },
        new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2023, 02, 06), Duration = "3", Progress = 30, ParentID = 5 },
        new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2023, 02, 06), Duration = "3", Progress = 40, ParentID = 5 },
        new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2023, 02, 06), Duration = "0", Progress = 30, ParentID = 5 }
    };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDByMDNKfZcGKCks?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Freeze particular column

To freeze a specific column in the Gantt Chart, set the [IsFrozen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html#Syncfusion_Blazor_Gantt_GanttColumn_IsFrozen) property to **true** on the corresponding [GanttColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html) component.

The following example demonstrates that the **TaskID** and **TaskName** columns are frozen.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px" >
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskID" IsFrozen=true></GanttColumn>
        <GanttColumn Field="TaskName" IsFrozen=true></GanttColumn>
        <GanttColumn Field="StartDate"></GanttColumn>
        <GanttColumn Field="EndDate"></GanttColumn>
        <GanttColumn Field="Duration"></GanttColumn>
        <GanttColumn Field="Progress"></GanttColumn>
    </GanttColumns>
    <GanttSplitterSettings Position="70%"></GanttSplitterSettings>
</SfGantt>

@code {
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
        List<TaskData> Tasks = new List<TaskData>() {
        new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2023, 02, 06), EndDate = new DateTime(2022, 02, 09) },
        new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2023, 02, 06), Duration = "0", Progress = 30, ParentID = 1 },
        new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2023, 02, 06), Duration = "4", Progress = 40, ParentID = 1 },
        new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2023, 02, 06), Duration = "0", Progress = 30, ParentID = 1 },
        new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2023, 02, 06), EndDate = new DateTime(2023, 02, 08) },
        new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2023, 02, 06), Duration = "3", Progress = 30, ParentID = 5 },
        new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2023, 02, 06), Duration = "3", Progress = 40, ParentID = 5 },
        new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2023, 02, 06), Duration = "0", Progress = 30, ParentID = 5 }
    };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZryittgJXbfxAFs?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Freeze direction

You can freeze a column on either the left or right side of the grid while the remaining columns remain movable by using the [Freeze](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html#Syncfusion_Blazor_Gantt_GanttColumn_Freeze) property in the `GanttColumn` component. To apply this, the [IsFrozen](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html#Syncfusion_Blazor_Gantt_GanttColumn_IsFrozen) property must also be set to **true**.

The following two freeze direction options are supported:

- [FreezeDirection.Left](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.FreezeDirection.html#Syncfusion_Blazor_Grids_FreezeDirection_Left) – Freezes the column on the left side.
- [FreezeDirection.Right](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Grids.FreezeDirection.html#Syncfusion_Blazor_Grids_FreezeDirection_Right) – Freezes the column on the right side.

The following example demonstrates that the **TaskID** column is frozen on the left and the **TaskName** column is frozen on the right.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px" >
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskID" IsFrozen=true Freeze="Syncfusion.Blazor.Grids.FreezeDirection.Left"></GanttColumn>
        <GanttColumn Field="TaskName" IsFrozen=true Freeze="Syncfusion.Blazor.Grids.FreezeDirection.Right"></GanttColumn>
        <GanttColumn Field="StartDate"></GanttColumn>
        <GanttColumn Field="EndDate"></GanttColumn>
        <GanttColumn Field="Duration"></GanttColumn>
        <GanttColumn Field="Progress"></GanttColumn>
    </GanttColumns>
    <GanttSplitterSettings Position="50%"></GanttSplitterSettings>
</SfGantt>

@code {
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
        List<TaskData> Tasks = new List<TaskData>() {
        new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2023, 02, 06), EndDate = new DateTime(2022, 02, 09) },
        new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2023, 02, 06), Duration = "0", Progress = 30, ParentID = 1 },
        new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2023, 02, 06), Duration = "4", Progress = 40, ParentID = 1 },
        new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2023, 02, 06), Duration = "0", Progress = 30, ParentID = 1 },
        new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2023, 02, 06), EndDate = new DateTime(2023, 02, 08) },
        new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2023, 02, 06), Duration = "3", Progress = 30, ParentID = 5 },
        new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2023, 02, 06), Duration = "3", Progress = 40, ParentID = 5 },
        new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2023, 02, 06), Duration = "0", Progress = 30, ParentID = 5 }
    };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/htBICttKJXuJjOKE?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Add or remove frozen columns by dragging the column separator

Frozen columns can be added or removed by dragging the column separator in the Gantt Chart.This separator is a draggable vertical line that separates frozen columns from non-frozen ones.

To enable this feature, set the [AllowFreezeLineMoving](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AllowFreezeLineMoving) property to **true**.  If no columns are configured as frozen, the separator appears at both the left and right edges of the grid.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px" AllowFreezeLineMoving=true>
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskID" IsFrozen=true Freeze="Syncfusion.Blazor.Grids.FreezeDirection.Left"></GanttColumn>
        <GanttColumn Field="TaskName" IsFrozen=true Freeze="Syncfusion.Blazor.Grids.FreezeDirection.Right"></GanttColumn>
        <GanttColumn Field="StartDate"></GanttColumn>
        <GanttColumn Field="EndDate"></GanttColumn>
        <GanttColumn Field="Duration"></GanttColumn>
        <GanttColumn Field="Progress"></GanttColumn>
    </GanttColumns>
    <GanttSplitterSettings Position="70%"></GanttSplitterSettings>
</SfGantt>

@code {
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
        List<TaskData> Tasks = new List<TaskData>() {
        new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2023, 02, 06), EndDate = new DateTime(2022, 02, 09) },
        new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2023, 02, 06), Duration = "0", Progress = 30, ParentID = 1 },
        new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2023, 02, 06), Duration = "4", Progress = 40, ParentID = 1 },
        new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2023, 02, 06), Duration = "0", Progress = 30, ParentID = 1 },
        new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2023, 02, 06), EndDate = new DateTime(2023, 02, 08) },
        new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2023, 02, 06), Duration = "3", Progress = 30, ParentID = 5 },
        new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2023, 02, 06), Duration = "3", Progress = 40, ParentID = 5 },
        new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2023, 02, 06), Duration = "0", Progress = 30, ParentID = 5 }
    };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXLeMZZKfMsDAtUw?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Change default frozen line color
  
You can customize the color of the default frozen line in the Gantt Chart by applying custom CSS styles.

The following example demonstrates how to change the frozen line color to blue.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px" FrozenColumns="2" AllowFreezeLineMoving=true>
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttSplitterSettings Position="60%"></GanttSplitterSettings>
</SfGantt>

<style>
    .e-grid .e-frozenrow-border {
        background-color: blue;
    }

    .e-grid.e-lib .e-leftfreeze.e-freezeleftborder {
        border-right-color: blue;
    }
</style>

@code {
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
        List<TaskData> Tasks = new List<TaskData>() {
        new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2023, 02, 06), EndDate = new DateTime(2022, 02, 09) },
        new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2023, 02, 06), Duration = "0", Progress = 30, ParentID = 1 },
        new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2023, 02, 06), Duration = "4", Progress = 40, ParentID = 1 },
        new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2023, 02, 06), Duration = "0", Progress = 30, ParentID = 1 },
        new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2023, 02, 06), EndDate = new DateTime(2023, 02, 08) },
        new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2023, 02, 06), Duration = "3", Progress = 30, ParentID = 5 },
        new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2023, 02, 06), Duration = "3", Progress = 40, ParentID = 5 },
        new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2023, 02, 06), Duration = "0", Progress = 30, ParentID = 5 }
    };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtrIMXtqJMKqKddi?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Limitations

- The [Freeze](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html#Syncfusion_Blazor_Gantt_GanttColumn_Freeze) and [FrozenColumns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_FrozenColumns) properties cannot be used together as they are incompatible.

- The Gantt Chart does not support Right-to-Left (RTL) mode when using frozen columns.