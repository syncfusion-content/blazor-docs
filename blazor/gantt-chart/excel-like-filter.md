---
layout: post
title: Excel Like Filter in Blazor Gantt Chart | Syncfusion
description: Checkout and learn here all about Excel like filter in Syncfusion Blazor Gantt Chart and much more details.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Excel like filter in Blazor Gantt Chart

The Syncfusion Blazor Gantt Chart offers an Excel-like filter feature, providing a familiar and intuitive interface for filtering project data within the Gantt Chart. This feature simplifies complex filtering operations on specific columns, allowing for quick task location and manipulation, similar to Microsoft Excel. Excel like filtering is especially useful when dealing with large project datasets and complex filtering requirements for project management scenarios.

Here is an example that showcasing how to render the Excel like filter within the Gantt Chart:

```cshtml
@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px" AllowFiltering="true">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttFilterSettings FilterType="Syncfusion.Blazor.Gantt.FilterType.Excel"></GanttFilterSettings>
</SfGantt>

@code {
    private List<TaskData> TaskCollection { get; set; } = new();

    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
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

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 21), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 04, 21), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 40, ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0", Progress = 30, ParentId = 5 },
        };
        return Tasks;
    }
}
```

> * The Excel-like filter feature supports various filter conditions, including text-based filters for task names, number-based filters for duration and progress, and date-based filters for project timelines.
> * The filter dialog provides additional options, such as searching for specific task values, and clearing applied project filters.

## Customize the filter choice count

By default, the filter choice count is set to 1000, which means that the filter dialog will display a maximum of 1000 distinct values for each column as a checkbox list data. This default value ensures that the filter operation remains efficient, even with large project datasets. Additionally, the filter dialog retrieves and displays distinct data from the first 1000 task records bound to the Syncfusion Blazor Gantt Chart to optimize performance, while the remaining records are returned as a result of the search option within the filter dialog.

The Gantt Chart allows customization of the number of distinct data displayed in the checkbox list of the Excel/Checkbox type filter dialog. This can be useful when working with large project datasets and wanting to customize the default filter choice count values.

However, there is flexibility to increase or decrease the filter choice count based on specific project requirements. This can be achieved by adjusting the [FilterChoiceCount](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.FilterDialogOpeningEventArgs.html#Syncfusion_Blazor_Gantt_FilterDialogOpeningEventArgs_FilterChoiceCount) value in the filter dialog opening event.

The following example demonstrates how to customize the filter choice count in the checkbox list of the filter dialog. In the [FilterDialogOpening](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_FilterDialogOpening) event, the `FilterChoiceCount` property can be set to the desired value:

```cshtml
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids

<SfGantt DataSource="@TaskCollection" AllowFiltering="true" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttFilterSettings FilterType="Syncfusion.Blazor.Gantt.FilterType.Excel"></GanttFilterSettings>
    <GanttEvents FilterDialogOpening="FilterDialogOpeningHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    private List<TaskData> TaskCollection { get; set; } = new();
    SfGantt<TaskData>? Gantt { get; set; }

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
        int taskId = 1;

        // Generate larger dataset for demonstration
        for (int i = 1; i <= 50; i++)
        {
            tasks.Add(new TaskData() { TaskId = taskId++, TaskName = $"Project Phase {i}", StartDate = new DateTime(2023, 04, 02), Duration = 10, Progress = 25, ParentId = null });
            tasks.Add(new TaskData() { TaskId = taskId++, TaskName = $"Task A-{i}", StartDate = new DateTime(2023, 04, 02), Duration = 3, Progress = 50, ParentId = taskId - 2 });
            tasks.Add(new TaskData() { TaskId = taskId++, TaskName = $"Task B-{i}", StartDate = new DateTime(2023, 04, 05), Duration = 4, Progress = 75, ParentId = taskId - 3 });
            tasks.Add(new TaskData() { TaskId = taskId++, TaskName = $"Task C-{i}", StartDate = new DateTime(2023, 04, 09), Duration = 3, Progress = 30, ParentId = taskId - 4 });
        }

        return tasks;
    }

    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
    }
}
```

> The specified filter choice count value determines the display of unique items as a checkbox list in the Excel/Checkbox type filter dialog. This can result in a delay in rendering these checkbox items when opening the filter dialog. Therefore, it is advisable to set a restricted filter choice count value for optimal project management performance.

## Show customized text in filter dialog

The Syncfusion Blazor Gantt Chart provides flexibility to customize the text displayed in the Excel/Checkbox filtering options. This allows modification of the default text and provides more meaningful and contextual labels for project filtering, enhancing the project management experience.

To customize the text in the Excel/Checkbox filter, define a `FilterItemTemplate` and bind it to the desired column. The `FilterItemTemplate` property allows creation of custom templates for filter items. Any logic and HTML elements can be used within this template to display the desired text or content relevant to project management scenarios.

In the example below, customization of the text displayed in the filter checkbox list for a **Status** column is demonstrated. This is achieved by defining a `FilterItemTemplate` within the column element. Inside the template, FilterItemTemplateContext can be used to conditionally display **Completed** if the data value is true and **In Progress** if the value is false:

```cshtml
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids

<SfGantt DataSource="@TaskCollection" AllowFiltering="true" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttFilterSettings FilterType="Syncfusion.Blazor.Gantt.FilterType.Excel"></GanttFilterSettings>
    <GanttColumns>
        <GanttColumn Field="TaskId" HeaderText="Task ID" Width="90">
        </GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Task Name" Width="200"></GanttColumn>
        <GanttColumn Field="IsCompleted" HeaderText="Status" Width="120" DisplayAsCheckBox="true">
            <FilterItemTemplate>
                @{
                    var filterContext = (context as FilterItemTemplateContext);
                    var itemTemplateValue = "DefaultText";

                    if (filterContext.Value.ToString() == "False")
                    {
                        itemTemplateValue = "In Progress";
                    }
                    else
                    {
                        itemTemplateValue = "Completed";
                    }
                }
                @itemTemplateValue
            </FilterItemTemplate>
        </GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration" Width="100"></GanttColumn>
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
        return new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project Management", StartDate = new DateTime(2023, 04, 02), Duration = 10, Progress = 40, IsCompleted = true, ParentId = null },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2023, 04, 02), Duration = 4, Progress = 100, IsCompleted = true, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform Soil test", StartDate = new DateTime(2023, 04, 02), Duration = 4, Progress = 50, IsCompleted = true, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2023, 04, 02), Duration = 4, Progress = 100, IsCompleted = true, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project Estimation", StartDate = new DateTime(2023, 04, 02), Duration = 8, Progress = 60, IsCompleted = false, ParentId = null },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan", StartDate = new DateTime(2023, 04, 04), Duration = 3, Progress = 100, IsCompleted = false, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2023, 04, 04), Duration = 3, Progress = 40, IsCompleted = false, ParentId = 5 }
        };
    }

    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Duration { get; set; }
        public int Progress { get; set; }
        public bool IsCompleted { get; set; }
        public int? ParentId { get; set; }
    }
}
```

## Customize the Excel filter using CSS

In the Syncfusion Blazor Gantt Chart, there is flexibility to enhance the visual presentation of the Excel filter dialog. This can be achieved by utilizing CSS styles to modify the dialog's appearance according to specific project management needs and application aesthetics.

**1. Removing context menu option**

The Excel filter dialog includes several features such as **context menu**, **search box**, and **checkbox list** that may not be required in some project management scenarios. These options can be removed using CSS classes applied to the Gantt Chart.

```cshtml
<style>
    .e-excelfilter .e-contextmenu-container.e-sfcontextmenu.e-grid-filter-menu {
        display: none;
    }
</style>
```

The following example demonstrates how to remove the context menu option in the Excel filter dialog using the above mentioned CSS for the Gantt Chart:

```cshtml
@using Syncfusion.Blazor.Gantt

<SfGantt AllowFiltering="true" DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
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

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 21), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 04, 21), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 40, ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0", Progress = 30, ParentId = 5 },
        };
        return Tasks;
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
}
```

**2. Customize the height and width of filter dialog**

The height and width of each column's filter dialog can be customized using CSS styles in the [FilterDialogOpening](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_FilterDialogOpening) event.

Before opening a filter dialog for each column, the `FilterDialogOpening` event will be triggered. At that point, based on the column name, the height and width of the columns can be set using CSS styles in the following sample.

```cshtml
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
<SfGantt ID="Gantt" AllowFiltering="true" DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
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
    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 21), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 04, 21), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 40, ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0", Progress = 30, ParentId = 5 },
        };
        return Tasks;
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
}
```

**3. Customize filter icon for filtered columns**

After filtering the column, the Gantt Chart will display the built-in filtered icon with predefined styles by default. The filtered icon can also be customized using the `.e-gantt .e-filtered::before` class for enhanced project visualization.

```cshtml
@using Syncfusion.Blazor.Gantt

<SfGantt AllowFiltering="true" DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttFilterSettings FilterType="Syncfusion.Blazor.Gantt.FilterType.Excel"></GanttFilterSettings>
</SfGantt>

<style>
    .e-gantt .e-filtered::before {
        color: red; /* set the color to filtered icon */
        font-size: medium; /* set the font-size to filtered icon */
    }
</style>

@code {
    private List<TaskData> TaskCollection { get; set; } = new();

    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
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

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 21), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 04, 21), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 40, ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0", Progress = 30, ParentId = 5 },
        };
        return Tasks;
    }
}
```

> The [Blazor Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart) feature tour page provides comprehensive feature representations. The [Blazor Gantt Chart example](https://blazor.syncfusion.com/demos/gantt-chart/overview?theme=bootstrap4) demonstrates how to present and manipulate project data effectively.