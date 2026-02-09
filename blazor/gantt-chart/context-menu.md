---
layout: post
title: Context Menu in Blazor Gantt Chart Component | Syncfusion
description: Check out and learn here all about Context Menu in Syncfusion Blazor Gantt Chart component and much more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Context Menu in Blazor Gantt Chart Component

The Blazor Gantt Chart component provides quick access to actions through a context menu. On right-click, context menu options are displayed based on the clicked element.

To enable this feature, set the [EnableContextMenu](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_EnableContextMenu) to **true**.  The context menu options can be customized using the [ContextMenuItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ContextMenuItems) property.

The default items are listed in the following table:

Items| Description
----|----
`AutoFit`| Auto-fits the current column.
`AutoFitAll` | Auto-fits all columns.
`SortAscending` | Sorts the current column in ascending order.
`SortDescending` | Sorts the current column in descending order.
`TaskInformation`| Edits the current task.
`Add` | Adds a new row to the Gantt.
`Indent` | Indent the selected record to one level.
`Outdent` | Outdent the selected record to one level.
`DeleteTask` | Deletes the current task.
`Save` | Saves the edited task.
`Cancel` | Cancels the edited task.
`DeleteDependency` | Deletes the current dependency task link.
`Convert` | Converts current task to a milestone or vice-versa.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" EnableContextMenu="true" AllowSorting="true" AllowResizing="true" Width="900px" HighlightWeekends="true">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress"
        Dependency="Predecessor" ParentID="ParentID"></GanttTaskFields>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true"></GanttEditSettings>
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
        public double Progress { get; set; }
        public string Predecessor { get; set; }
        public int? ParentID { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 08) },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "3", Progress = 30, Predecessor = "2", ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 04, 11) },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 07), Duration = "3", Progress = 40, ParentID = 5 },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 07), Duration = "0", Progress = 30, Predecessor = "6", ParentID = 5 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjrysNNEKfEGDaMK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Custom context menu items

You can configure custom context menu items by assigning a collection of `ContextMenuItemModel` to the [ContextMenuItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ContextMenuItems) property. To define actions for these items, use the [ContextMenuItemClicked](https://blazor.syncfusion.com/documentation/gantt-chart/events#contextmenuitemclicked) event.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids

<SfGantt @ref="GanttInstance" DataSource="@TaskCollection" Height="450px" Width="700px" ContextMenuItems="@contextMenuItems">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttEvents ContextMenuItemClicked=ContextMenuItemClickedHandler TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    public List<TaskData> TaskCollection { get; set; }
    private SfGantt<TaskData> GanttInstance;

    private List<ContextMenuItemModel> contextMenuItems = new List<ContextMenuItemModel>()
    {
        new ContextMenuItemModel(){Text="Refresh", Target=".e-content",Id="Refresh"}
    };

    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    private async void ContextMenuItemClickedHandler(ContextMenuClickEventArgs<TaskData> args)
    {
        if(args.Item.Id == "Refresh")
        {
            await  GanttInstance.RefreshAsync();
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
        new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 04), EndDate = new DateTime(2022, 04, 08)},
        new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 04), Duration = "4", Progress = 30, ParentID = 1 },
        new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 04), Duration = "4", Progress = 40, ParentID = 1 },
        new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 04), Duration = "5", Progress = 30, ParentID = 1 },
        new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 12), EndDate = new DateTime(2022, 05, 17) },
        new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 12), Duration = "3", Progress = 30, ParentID = 5 },
        new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 05, 13), Duration = "3", Progress = 40, ParentID = 5 },
        new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 05, 16), Duration = "0", Progress = 30, ParentID = 5 }
    };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjBoitjaKesTwsYr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Built-in and custom context menu items

You can configure built-in and custom context menu items at the same time in the Gantt Chart by assigning a collection of `ContextMenuItemModel` to the [ContextMenuItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ContextMenuItems) property. The corresponding actions for custom items are handled through the [ContextMenuItemClicked](https://blazor.syncfusion.com/documentation/gantt-chart/events#contextmenuitemclicked) event.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids

<SfGantt @ref="GanttInstance" DataSource="@TaskCollection" Height="450px" Width="700px" 
    ContextMenuItems="@(new List<Object>() { "Add", new ContextMenuItemModel { Text = "Copy with headers", Target = ".e-content", Id = "copywithheader" } })">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate"
        Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttEditSettings AllowAdding="true"></GanttEditSettings>
    <GanttEvents ContextMenuItemClicked=ContextMenuItemClickedHandler TValue="TaskData">
    </GanttEvents>
</SfGantt>

@code {
    public List<TaskData> TaskCollection { get; set; }
    private SfGantt<TaskData> GanttInstance;

    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    private async void ContextMenuItemClickedHandler(ContextMenuClickEventArgs<TaskData> args)
    {
        if (args.Item.Id == "copywithheader")
        {
            await GanttInstance.CopyAsync(true);
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
        new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 04), EndDate = new DateTime(2022, 04, 08)},
        new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 04), Duration = "4", Progress = 30, ParentID = 1 },
        new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 04), Duration = "4", Progress = 40, ParentID = 1 },
        new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 04), Duration = "5", Progress = 30, ParentID = 1 },
        new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 12), EndDate = new DateTime(2022, 05, 17) },
        new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 12), Duration = "3", Progress = 30, ParentID = 5 },
        new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 05, 13), Duration = "3", Progress = 40, ParentID = 5 },
        new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 05, 16), Duration = "0", Progress = 30, ParentID = 5 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNLoWNWHhsckRdfz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Sub context menu items

To configure nested context menu items (sub-menus) in the Blazor Gantt Chart, follow these steps:

1. Define a list of `ContextMenuItemModel` objects using the [ContextMenuItems](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ContextMenuItems) property.
2. Add sub-items by assigning a collection of `MenuItems` to the `Items` property within each `ContextMenuItemModel`.
3. Use the [ContextMenuItemClicked](https://blazor.syncfusion.com/documentation/gantt-chart/events#contextmenuitemclicked) event to handle actions for individual menu items.

The following example demonstrates how to configure a sub-context menu titled **Gantt Action**, which includes the sub-items **Copy with headers** and **Edit**.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations

<SfGantt @ref="Gantt" DataSource="@TaskCollection" Height="450px" Width="700px" ContextMenuItems="@contextMenuItems">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttEditSettings AllowEditing="true"></GanttEditSettings>
    <GanttEvents ContextMenuItemClicked=ContextMenuItemClickedHandler TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    public List<TaskData> TaskCollection { get; set; }
    private SfGantt<TaskData> Gantt;
    private List<ContextMenuItemModel> contextMenuItems = new List<ContextMenuItemModel>()
    {
        new ContextMenuItemModel{
            Text="Gantt Action",Target=".e-content",Id="GanttAction",
            Items=new List<MenuItem>(){
                new MenuItem {Text="Copy with headers",Id= "copywithheader"},
                new MenuItem {Text="Edit",Id= "Edit"} 
            } 
        }
    };

    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    public async void ContextMenuItemClickedHandler(ContextMenuClickEventArgs<TaskData> args)
    {
        if (args.Item.Id == "copywithheader")
        {
            await Gantt.CopyAsync(true);
        }
        if (args.Item.Id == "Edit")
        {
            await Gantt.OpenEditDialogAsync();
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
        new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 04), EndDate = new DateTime(2022, 04, 08)},
        new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 04), Duration = "4", Progress = 30, ParentID = 1 },
        new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 04), Duration = "4", Progress = 40, ParentID = 1 },
        new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 04), Duration = "5", Progress = 30, ParentID = 1 },
        new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 12), EndDate = new DateTime(2022, 05, 17) },
        new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 12), Duration = "3", Progress = 30, ParentID = 5 },
        new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 05, 13), Duration = "3", Progress = 40, ParentID = 5 },
        new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 05, 16), Duration = "0", Progress = 30, ParentID = 5 }
    };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZLSMDsnBVFIKLRF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Disable the context menu for specific columns

To disable the context menu for specific columns in the Gantt Chart, use the [ContextMenuOpen](https://blazor.syncfusion.com/documentation/gantt-chart/events#contextmenuopen) event. This event is triggered before the context menu is displayed, and setting the `Cancel` argument to **false** will disable the menu for the targeted columns.

The following sample code demonstrates how to disable the context menu for the **Duration** column.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids

<SfGantt @ref="Gantt" DataSource="@TaskCollection" Height="450px" Width="700px" ContextMenuItems="@contextMenuItems">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttEvents ContextMenuOpen="OnContextMenuOpen" ContextMenuItemClicked=ContextMenuItemClickedHandler TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    public List<TaskData> TaskCollection { get; set; }
    private SfGantt<TaskData> Gantt;

    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    private List<ContextMenuItemModel> contextMenuItems = new List<ContextMenuItemModel>()
    {
        new ContextMenuItemModel(){Text="Refresh", Target=".e-content",Id="refresh"}
    };

    public void OnContextMenuOpen(ContextMenuOpenEventArgs<TaskData> Args)
    {
        if (Args.Column != null && Args.Column.Field == "Duration")
        {
            Args.Cancel = true; // To prevent the context menu from opening.
        }
    }

    private async void ContextMenuItemClickedHandler(ContextMenuClickEventArgs<TaskData> args)
    {
        if (args.Item.Id == "refresh")
        {
            await Gantt.RefreshAsync();
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
        new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 04), EndDate = new DateTime(2022, 04, 08)},
        new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 04), Duration = "4", Progress = 30, ParentID = 1 },
        new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 04), Duration = "4", Progress = 40, ParentID = 1 },
        new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 04), Duration = "5", Progress = 30, ParentID = 1 },
        new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 12), EndDate = new DateTime(2022, 05, 17) },
        new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 12), Duration = "3", Progress = 30, ParentID = 5 },
        new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 05, 13), Duration = "3", Progress = 40, ParentID = 5 },
        new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 05, 16), Duration = "0", Progress = 30, ParentID = 5 }
    };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXVeXaiOJCAcXLUo?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


## Disable context menu items dynamically 

To dynamically disable specific context menu items based on conditions, set the `Disabled` property to **true** within the [ContextMenuOpen](https://blazor.syncfusion.com/documentation/gantt-chart/events#contextmenuopen) event of the Gantt Chart.

The following sample code demonstrates how to disable the context menu items for the **Duration** column, while keeping it enabled for the remaining columns.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Navigations

<SfGantt @ref="Gantt" DataSource="@TaskCollection" Height="450px" Width="700px" ContextMenuItems="@contextMenuItems">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttEditSettings AllowEditing="true"></GanttEditSettings>
    <GanttEvents ContextMenuOpen="OnContextMenuOpen" ContextMenuItemClicked=ContextMenuItemClickedHandler TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    public List<TaskData> TaskCollection { get; set; }
    private SfGantt<TaskData> Gantt;
    private List<ContextMenuItemModel> contextMenuItems = new List<ContextMenuItemModel>()
    {
        new ContextMenuItemModel{Text="Gantt Action",Target=".e-content",Id="GanttAction",
            Items=new List<MenuItem>(){
                new MenuItem{Text="Refresh",Id="Refresh"},
                new MenuItem{Text="Edit",Id= "Edit"}
            }
        }
    };

    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    public async void ContextMenuItemClickedHandler(ContextMenuClickEventArgs<TaskData> args)
    {
        if (args.Item.Id == "Refresh")
        {
            await Gantt.RefreshAsync();
        }
        if (args.Item.Id == "Edit")
        {
            await Gantt.OpenEditDialogAsync();
        }
    }
    
    public void OnContextMenuOpen(ContextMenuOpenEventArgs<TaskData> Args)
    {
        if (Args.Column != null && Args.Column.Field == "Duration")  
        {
            Args.ContextMenu.Items[0].Disabled = true; // To disable edit context menu item.
        }
        else
        {
            Args.ContextMenu.Items[0].Disabled = false; // To enable edit context menu item.
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
        new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 04), EndDate = new DateTime(2022, 04, 08)},
        new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 04), Duration = "4", Progress = 30, ParentID = 1 },
        new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 04), Duration = "4", Progress = 40, ParentID = 1 },
        new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 04), Duration = "5", Progress = 30, ParentID = 1 },
        new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 12), EndDate = new DateTime(2022, 05, 17) },
        new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 12), Duration = "3", Progress = 30, ParentID = 5 },
        new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 05, 13), Duration = "3", Progress = 40, ParentID = 5 },
        new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 05, 16), Duration = "0", Progress = 30, ParentID = 5 }
    };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtroDkWYpCwXFEIM?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}