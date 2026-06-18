---
layout: post
title: Excel Like Filter in Blazor Gantt Chart | Syncfusion®
description: Checkout and learn here all the features about Excel like filter in Blazor Gantt Chart and much more details.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Filter menu in Blazor Gantt Chart component

The Blazor Gantt Chart component provides a filter menu for each column, allowing filtering based on data type and supported operators. 

To enable this feature, configure [GanttFilterSettings.FilterType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttFilterSettings.html#Syncfusion_Blazor_Gantt_GanttFilterSettings_FilterType) as **Menu** and set [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AllowFiltering) to **true**.

## Custom component in filter menu 

You can customize the filter menu in the Blazor Gantt Chart component using the [FilterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html#Syncfusion_Blazor_Gantt_GanttColumn_FilterTemplate) property. This allows you to replace the default filter controls with custom components such as dropdowns or textboxes for specific columns. By default, the Gantt Chart uses Autocomplete for string columns, NumericTextBox for number columns, DatePicker for date columns, and DropDownList for boolean column.

Here is a sample code demonstrating how to render a [DropDownList](https://blazor.syncfusion.com/documentation/dropdown-list/getting-started-with-web-app) for the **TaskName** column:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.DropDowns

<SfGantt DataSource="@TaskCollection" AllowFiltering="true" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttFilterSettings FilterType="Syncfusion.Blazor.Gantt.FilterType.Menu"></GanttFilterSettings>
    <GanttColumns>
        <GanttColumn Field="TaskId" HeaderText="Task ID" Width="100">
        </GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Task Name" Width="200">
            <FilterTemplate>
                @{
                    var contextModel = context as PredicateModel<string>;
                }
                <SfDropDownList TValue="string" TItem="TaskData" Placeholder="Select Task Name"
                                DataSource="@TaskCollection"
                                @bind-Value="contextModel.Value"
                                ID="TaskNameFilter">
                    <DropDownListFieldSettings Value="TaskName" Text="TaskName"></DropDownListFieldSettings>
                </SfDropDownList>
            </FilterTemplate>
        </GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration" Width="120">
        </GanttColumn>
    </GanttColumns>
</SfGantt>

@code {
    public List<TaskData> TaskCollection { get; set; } = new();

    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 01, 05), EndDate = new DateTime(2026, 01, 08), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 01, 05), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 01, 05), EndDate = new DateTime(2026, 01, 08), Progress = 40, ParentId = 1, },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 01, 05), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 01, 05), EndDate = new DateTime(2026, 01, 10), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 01, 07), EndDate = new DateTime(2026, 01, 09), Progress = 30, ParentId = 5, },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 01, 07), EndDate = new DateTime(2026, 01, 09), Progress = 40, ParentId = 5, },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 01, 07), Duration = "0", Progress = 30, ParentId = 5, }
        };
        return Tasks;
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
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LXhHZnMIeldTdqLq?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Hide default filter icon while perform filtering through method

To remove the default filter icon from the UI, apply the following CSS: 
 
```css
.e-filtermenudiv.e-icons.e-icon-filter {
    display: none;
}

```

You can perform filtering programmatically using the [FilterByColumnAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_FilterByColumnAsync_System_String_System_String_System_String_System_String_System_Nullable_System_Boolean__System_Nullable_System_Boolean__) method, and reset it using [ClearFilteringAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ClearFilteringAsync) through button actions.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Buttons

<div style="margin-bottom: 10px; display: flex; gap: 20px;">
    <SfButton ID="performFilter" CssClass="e-primary" OnClick="PerformFilter">Filter Task Name Column</SfButton>
    <SfButton ID="clearFilter" CssClass="e-outline" OnClick="ClearFilter">Clear Filter</SfButton>
</div>

<SfGantt @ref="Gantt" DataSource="@TaskCollection" AllowFiltering="true" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttFilterSettings FilterType="Syncfusion.Blazor.Gantt.FilterType.Menu"></GanttFilterSettings>
    <GanttColumns>
        <GanttColumn Field="TaskId" HeaderText="Task ID" Width="100"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Task Name" Width="200"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration" Width="120"></GanttColumn>
    </GanttColumns>
</SfGantt>

<style>
    .e-filtermenudiv.e-icons.e-icon-filter {
      display: none;
    }
</style>

@code {
    public List<TaskData> TaskCollection { get; set; } = new();
    public SfGantt<TaskData> Gantt;

    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
    }

    private async Task PerformFilter()
    {
        await Gantt.FilterByColumnAsync("TaskName", "startswith", "Project");
    }

    private async Task ClearFilter()
    {
        await Gantt.ClearFilteringAsync();
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 01, 05), EndDate = new DateTime(2026, 01, 08), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 01, 05), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 01, 05), EndDate = new DateTime(2026, 01, 08), Progress = 40, ParentId = 1, },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 01, 05), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 01, 05), EndDate = new DateTime(2026, 01, 10), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 01, 07), EndDate = new DateTime(2026, 01, 09), Progress = 30, ParentId = 5, },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 01, 07), EndDate = new DateTime(2026, 01, 09), Progress = 40, ParentId = 5, },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 01, 07), Duration = "0", Progress = 30, ParentId = 5, }
        };
        return Tasks;
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
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNVRjnioSFcOqMij?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Customize the default input component of filter menu dialog

You can customize the input components in the filter menu of the Blazor Gantt Chart by using the [FilterTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html#Syncfusion_Blazor_Gantt_GanttColumn_FilterTemplate) property in `GanttColumn`. This enables column-specific customization and precise control over the behavior of individual filter components.

| Column Type | Default component  |Customization  | API Reference     |
| ----------- | ------------------------------------------------------------------------------------------------- | ---------------------------------------- | --------------------------------------------------------------------------------------------------------- |
| String      | [AutoComplete](https://blazor.syncfusion.com/documentation/autocomplete/getting-started)    | Eg: Autofill="false" | [AutoComplete API](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfAutoComplete-2.html) |
| Number      | [NumericTextBox](https://blazor.syncfusion.com/documentation/numeric-textbox/getting-started) | Eg: ShowSpinButton="false" | [NumericTextBox API](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Inputs.SfNumericTextBox-1.html)                 |
| Boolean     | [DropDownList](https://blazor.syncfusion.com/documentation/dropdown-list/getting-started)   | Eg: SortOrder="SortOrder.Ascending"  | [DropDownList API](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.SfDropDownList-2.html)                   |
| Date        | [DatePicker](https://blazor.syncfusion.com/documentation/datepicker/getting-started)         | Eg: WeekNumber="true"    | [DatePicker API](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDatePicker-1.html)                         |
| DateTime    | [DateTimePicker](https://blazor.syncfusion.com/documentation/datetime-picker/getting-started) | Eg: ShowClearButton="true"  | [DateTimePicker API](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Calendars.SfDateTimePicker-1.html)                 |

The following sample demonstrates how to disable the autofill feature by setting the `Autofill` parameter to **false** for the **TaskName** column, and how to configure a `NumericTextBox` without a spin button (`ShowSpinButton` set to **false**) for the **TaskID** column.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.DropDowns
@using Syncfusion.Blazor.Grids

<SfGantt DataSource="@TaskCollection" AllowFiltering="true" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>

    <GanttFilterSettings FilterType="Syncfusion.Blazor.Gantt.FilterType.Menu"></GanttFilterSettings>

    <GanttColumns>
        <GanttColumn Field="TaskId" HeaderText="Task ID" Width="100">
            <FilterTemplate>
                @{
                    var contextModel = context as PredicateModel<int>;
                }
                <SfNumericTextBox TValue="int" ShowSpinButton="false" @bind-Value="contextModel.Value"></SfNumericTextBox>
            </FilterTemplate>
        </GanttColumn>

        <GanttColumn Field="TaskName" HeaderText="Task Name" Width="200">
            <FilterTemplate>
                @{
                    var contextModel = context as PredicateModel<string>;
                }
                <SfAutoComplete TValue="string" TItem="string" ID="TaskNameFilter" @bind-Value="contextModel.Value"
                Placeholder="Select Task Name" DataSource="@CustomerData">
                </SfAutoComplete>
            </FilterTemplate>
        </GanttColumn>

        <GanttColumn Field="Duration" HeaderText="Duration" Width="120"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date" Width="150" Format="d" Type="Syncfusion.Blazor.Grids.ColumnType.DateOnly"></GanttColumn>
        <GanttColumn Field="Progress" HeaderText="Progress" Width="100"></GanttColumn>
    </GanttColumns>
</SfGantt>

@code {
    public List<TaskData> TaskCollection { get; set; } = new();
    private List<string> CustomerData { get; set; } = new();

    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
        CustomerData = TaskCollection.Select(t => t.TaskName).Distinct().ToList();
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 01, 05), EndDate = new DateTime(2026, 01, 08), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 01, 05), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 01, 05), EndDate = new DateTime(2026, 01, 08), Progress = 40, ParentId = 1, },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 01, 05), Duration = "0", Progress = 30, ParentId = 1, },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 01, 05), EndDate = new DateTime(2026, 01, 10), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 01, 07), EndDate = new DateTime(2026, 01, 09), Progress = 30, ParentId = 5, },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 01, 07), EndDate = new DateTime(2026, 01, 09), Progress = 40, ParentId = 5, },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 01, 07), Duration = "0", Progress = 30, ParentId = 5, }
        };
        return Tasks;
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
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BNBnXHiISPYLYCKl?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}
