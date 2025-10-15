---
layout: post
title: Excel Like Filter in Blazor Gantt Chart | Syncfusion
description: Checkout and learn here all about Excel like filter in Syncfusion Blazor Gantt Chart and much more details.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Excel like filter in Blazor Gantt Chart component

The Excel-like filter in Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Gantt Chart component enables column-level filtering similar to Microsoft Excel. It supports sorting, clearing filters, and applying advanced conditions through a submenu available in each column header. This feature is highly effective for working with large datasets and applying multiple filter criteria.

To enable this feature, configure [GanttFilterSettings.FilterType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttFilterSettings.html#Syncfusion_Blazor_Gantt_GanttFilterSettings_FilterType) as **Excel** and set [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AllowFiltering) to **true**.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="900px" AllowFiltering="true">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttFilterSettings FilterType="Syncfusion.Blazor.Gantt.FilterType.Excel"></GanttFilterSettings>
</SfGantt>

@code {
    private List<TaskData> TaskCollection { get; set; } = new();

    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
    }

    private static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 7), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentID = 1, },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 10), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentID = 5, },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentID = 5, },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentID = 5, }
        };
        return Tasks;
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
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LNLosDjqgkPbKMzW?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> * The Excel-like filter feature supports various filter conditions, including text-based filters for task names, number-based filters for task Id and progress, and date-based filters for project timelines.
> * The filter dialog provides additional options, such as searching for specific task values, and clearing applied project filters.

## Customize the filter choice count

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Gantt Chart component displays up to 1000 distinct values per column in the filter dialog by default. These values are taken from the first 1000 records bound to the component and shown as checkbox list items to maintain optimal performance. Additional values can be accessed using the search option within the filter dialog.

To customize this behavior, the [FilterChoiceCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.FilterDialogOpeningEventArgs.html#Syncfusion_Blazor_Gantt_FilterDialogOpeningEventArgs_FilterChoiceCount) property can be configured within the[FilterDialogOpening](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_FilterDialogOpening) event to increase or decrease the number of distinct values displayed, depending on the dataset size and filtering requirements.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids

<SfGantt DataSource="@TaskCollection" AllowFiltering="true" Height="450px" Width="900px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttFilterSettings FilterType="Syncfusion.Blazor.Gantt.FilterType.Excel"></GanttFilterSettings>
    <GanttEvents FilterDialogOpening="FilterDialogOpeningHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    private List<TaskData> TaskCollection { get; set; } = new();
    SfGantt<TaskData> Gantt { get; set; }

    public void FilterDialogOpeningHandler(FilterDialogOpeningEventArgs args)
    {
        args.FilterChoiceCount = 100;
    }

    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
    }

    private List<TaskData> GetTaskCollection()
    {
        List<TaskData> tasks = new List<TaskData>();
        int TaskID = 1;

        // Generate larger dataset for demonstration.
        for (int i = 1; i <= 50; i++)
        {
            tasks.Add(new TaskData() { TaskID = TaskID++, TaskName = $"Project Phase {i}", StartDate = new DateTime(2023, 04, 02), Duration = 10, Progress = 25, ParentID = null });
            tasks.Add(new TaskData() { TaskID = TaskID++, TaskName = $"Task A-{i}", StartDate = new DateTime(2023, 04, 02), Duration = 3, Progress = 50, ParentID = TaskID - 2 });
            tasks.Add(new TaskData() { TaskID = TaskID++, TaskName = $"Task B-{i}", StartDate = new DateTime(2023, 04, 05), Duration = 4, Progress = 75, ParentID = TaskID - 3 });
            tasks.Add(new TaskData() { TaskID = TaskID++, TaskName = $"Task C-{i}", StartDate = new DateTime(2023, 04, 09), Duration = 3, Progress = 30, ParentID = TaskID - 4 });
        }

        return tasks;
    }

    public class TaskData
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentID { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjLSCDjUzNLJlHUQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> The specified filter choice count value determines the display of unique items as a checkbox list in the Excel type filter dialog. This can result in a delay in rendering these checkbox items when opening the filter dialog. Therefore, it is advisable to set a restricted filter choice count value for optimal project management performance.

## Show customized text in filter dialog

You can customize the text shown in the filter dialog of the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Gantt Chart compoenent by using the [FilterItemTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html#Syncfusion_Blazor_Gantt_GanttColumn_FilterItemTemplate) property. This feature allows you to present meaningful labels based on the values of a specific column.

In the example below, the filter checkbox list for the **Status** column is customized by defining a `FilterItemTemplate` within the column configuration. The **FilterItemTemplateContext** is used to conditionally render descriptive labels: **Completed** when the value is **true**, and **In Progress** when the value is **false**.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids

<SfGantt DataSource="@TaskCollection" AllowFiltering="true" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate"
                     Duration="Duration" Progress="Progress" ParentID="ParentID" />
    <GanttFilterSettings FilterType="Syncfusion.Blazor.Gantt.FilterType.Excel" />
    <GanttColumns>
        <GanttColumn Field="TaskID" HeaderText="Task ID" Width="100" />
        <GanttColumn Field="TaskName" HeaderText="Task Name" Width="200" />
        <GanttColumn Field="IsCompleted" HeaderText="Status" Width="120" DisplayAsCheckBox="true">
            <FilterItemTemplate>
                @{
                    var filterContext = context as FilterItemTemplateContext;
                    var value = filterContext?.Value?.ToString();
                    var itemTemplateValue = value == "True" ? "Completed" : "In Progress";
                }
                @itemTemplateValue
            </FilterItemTemplate>
        </GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration" Width="120" />
    </GanttColumns>
</SfGantt>

@code {
    private List<TaskData> TaskCollection { get; set; } = new();

    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
    }

    private List<TaskData> GetTaskCollection()
    {
        return new List<TaskData>
        {
            new TaskData { TaskID = 1, TaskName = "Project Management", StartDate = new DateTime(2023, 04, 03), EndDate = new DateTime(2023, 04, 03), Duration = 10, Progress = 40, IsCompleted = true },
            new TaskData { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2023, 04, 03), EndDate = new DateTime(2023, 04, 03), Duration = 4, Progress = 100, IsCompleted = true, ParentID = 1 },
            new TaskData { TaskID = 3, TaskName = "Perform Soil test", StartDate = new DateTime(2023, 04, 03), EndDate = new DateTime(2023, 04, 03), Duration = 4, Progress = 50, IsCompleted = true, ParentID = 1 },
            new TaskData { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2023, 04, 03), EndDate = new DateTime(2023, 04, 03), Duration = 4, Progress = 100, IsCompleted = true, ParentID = 1 },
            new TaskData { TaskID = 5, TaskName = "Project Estimation", StartDate = new DateTime(2023, 04, 04), EndDate = new DateTime(2023, 04, 04), Duration = 8, Progress = 60, IsCompleted = false },
            new TaskData { TaskID = 6, TaskName = "Develop floor plan", StartDate = new DateTime(2023, 04, 04), EndDate = new DateTime(2023, 04, 04), Duration = 3, Progress = 100, IsCompleted = false, ParentID = 5 },
            new TaskData { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2023, 04, 04), EndDate = new DateTime(2023, 04, 04), Duration = 3, Progress = 40, IsCompleted = false, ParentID = 5 }
        };
    }

    public class TaskData
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public int Progress { get; set; }
        public bool IsCompleted { get; set; }
        public int? ParentID { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BthSCjNqzrNWxSym?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Customize the Excel filter using CSS

In the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Gantt Chart, there is flexibility to enhance the visual presentation of the Excel filter dialog. This can be achieved by utilizing CSS styles to modify the dialog's appearance according to specific project management needs and application aesthetics.

### Removing context menu option

The Excel filter dialog includes several features such as **context menu**, **search box**, and **checkbox list** that may not be required in some project management scenarios. 

To remove the context menu from the filter dialog, apply the following CSS rule to the Gantt Chart:

```cshtml
<style>
    .e-excelfilter .e-contextmenu-container.e-sfcontextmenu.e-grid-filter-menu {
        display: none;
    }
</style>
```

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="900px" AllowSorting="true" AllowFiltering="true">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttFilterSettings FilterType="Syncfusion.Blazor.Gantt.FilterType.Excel"></GanttFilterSettings>
</SfGantt>

<style>
    .e-excelfilter .e-contextmenu-container.e-sfcontextmenu.e-grid-filter-menu {
        display: none;
    }
</style>

@code {
    private List<TaskData> TaskCollection { get; set; } = new();

    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
    }

    private static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 7), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentID = 1, },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 10), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentID = 5, },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentID = 5, },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentID = 5, }
        };
        return Tasks;
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
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rjLyMtZUJqmzHKur?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Customize the height and width of filter dialog

You can adjust the height and width of the filter dialog for each column using CSS styles within the  [FilterDialogOpening](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_FilterDialogOpening) event. This event is triggered before the filter dialog opens, allowing you to apply styles conditionally based on the column name.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids

<SfGantt ID="Gantt" AllowFiltering="true" DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttEvents FilterDialogOpening="FilterDialogOpeningHandler" TValue="TaskData"></GanttEvents>
    <GanttFilterSettings FilterType="Syncfusion.Blazor.Gantt.FilterType.Excel"></GanttFilterSettings>
</SfGantt>

@if (IsLarge)
{
    <style>
        #Gantt .e-excelfilter.e-popup.e-popup-open {
            height: 400px;
            width: 350px !important;
        }
    </style>
}
@if (IsSmall)
{
    <style>
        #Gantt .e-excelfilter.e-popup.e-popup-open {
            height: 450px;
            width: 280px !important;
        }
    </style>
}

@code {
    private List<TaskData> TaskCollection { get; set; } = new();
    public bool IsLarge;
    public bool IsSmall;
    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
    }

    public void FilterDialogOpeningHandler(FilterDialogOpeningEventArgs args)
    {
        if (args.ColumnName == "TaskName")
        {
            IsLarge = true;
            IsSmall = false;
        }
        else if (args.ColumnName == "TaskId")
        {
            IsSmall = true;
            IsLarge = false;
        }
        else
        {
            IsLarge = false;
            IsSmall = false;
        }
    }
    
    private static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 7), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentID = 1, },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 10), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentID = 5, },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentID = 5, },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentID = 5, }
        };
        return Tasks;
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
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXhoCtXgzJXiUzEe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Customize filter icon for filtered columns

When a column is filtered, the Gantt Chart displays a default icon with predefined styles. You can customize this icon using the **.e-gantt .e-filtered::before** CSS class for enhanced project visualization.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids

<SfGantt ID="Gantt" AllowFiltering="true" DataSource="@TaskCollection" Height="450px" Width="900px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttEvents FilterDialogOpening="FilterDialogOpeningHandler" TValue="TaskData"></GanttEvents>
    <GanttFilterSettings FilterType="Syncfusion.Blazor.Gantt.FilterType.Excel"></GanttFilterSettings>
</SfGantt>

@if (IsLarge)
{
    <style>
        #Gantt .e-excelfilter.e-popup.e-popup-open {
            height: 400px;
            width: 350px !important;
        }
    </style>
}
@if (IsSmall)
{
    <style>
        #Gantt .e-excelfilter.e-popup.e-popup-open {
            height: 450px;
            width: 280px !important;
        }
    </style>
}

@code {
    private List<TaskData> TaskCollection { get; set; } = new();
    public bool IsLarge;
    public bool IsSmall;
    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
    }

    public void FilterDialogOpeningHandler(FilterDialogOpeningEventArgs args)
    {
        if (args.ColumnName == "TaskName")
        {
            IsLarge = true;
            IsSmall = false;
        }
        else if (args.ColumnName == "TaskId")
        {
            IsSmall = true;
            IsLarge = false;
        }
        else
        {
            IsLarge = false;
            IsSmall = false;
        }
    }

    private static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 7), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentID = 1, },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 10), },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentID = 5, },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentID = 5, },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentID = 5, }
        };
        return Tasks;
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
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDBSWNtATpopODgg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

> The [Blazor Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart) feature tour page provides comprehensive feature representations. The [Blazor Gantt Chart example](https://blazor.syncfusion.com/demos/gantt-chart/overview?theme=bootstrap4) demonstrates how to present and manipulate project data effectively.