---
layout: post
title: Columns in Blazor Gantt Chart Component | Syncfusion®
description: Checkout and learn here all the features about Columns in Blazor Gantt Chart component and much more details.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Columns in Blazor Gantt component

The Blazor Gantt Chart component displays task data in a tabular format using columns. Columns organize task data efficiently and enable user interactions such as sorting, filtering, and formatting within the Gantt chart.

Each column is defined using the [Field](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html#Syncfusion_Blazor_Gantt_GanttColumn_Field) property, which maps values from the data source. This mapping ensures accurate data binding and enables formatting and customization for each column.

> If the column `Field` is not specified in the data source, the column values will be empty.

## Defining columns

You can define columns using the [GanttColumns](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumns.html) property along with the mapped fields in the [GanttTaskFields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTaskFields.html) property. If no columns are explicitly defined, the component automatically renders default columns based on the mapped fields in `GanttTaskFields`. To create additional columns, define additional columns that are not included in `GanttTaskFields`.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskId" Width="150"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Job Name" Width="150"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date" Width="150"></GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date" Width="150"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration" Width="150"></GanttColumn>
        <GanttColumn Field="Progress" HeaderText="Progress" Width="150"></GanttColumn>
        <GanttColumn Field="StartDateOnly" HeaderText="Start Date Only" Format="d" Type="Syncfusion.Blazor.Grids.ColumnType.DateOnly" Width="152" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="StartTimeOnly" HeaderText="Start Time Only" Type="Syncfusion.Blazor.Grids.ColumnType.TimeOnly" Width="150" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="Status" HeaderText="Status" Width="150" ></GanttColumn>
        <GanttColumn Field="WorkersCount" HeaderText="Workers Count" Width="150" ></GanttColumn>
    </GanttColumns>
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
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 21), Status="Progress", WorkersCount=20, StartDateOnly = new DateOnly(2026, 03, 02), StartTimeOnly = new TimeOnly(10, 00, 00)},
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 5, Status="Progress", WorkersCount=10, ParentId = 1, StartDateOnly = new DateOnly(2026, 03, 04), StartTimeOnly = new TimeOnly(11, 30, 00)},
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 09), Progress = 10, Status="Hold", WorkersCount=15, ParentId = 1, StartDateOnly = new DateOnly(2026, 03, 06), StartTimeOnly = new TimeOnly(12, 00, 00)},
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, Status="PostPoned", WorkersCount=5, ParentId = 1, StartDateOnly = new DateOnly(2026, 03, 08), StartTimeOnly = new TimeOnly(13, 30, 00)},
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 21), Status="Progress", WorkersCount=25,StartDateOnly = new DateOnly(2026, 07, 10), StartTimeOnly = new TimeOnly(14, 00, 00) },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 30, Status="PostPoned", WorkersCount=10, ParentId = 5 , StartDateOnly = new DateOnly(2026, 10, 12), StartTimeOnly = new TimeOnly(16, 00, 00)},
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 04, 07),EndDate = new DateTime(2026, 04, 09), Progress = 40, Status="Progress", WorkersCount=5, ParentId = 5, StartDateOnly = new DateOnly(2026, 10, 14), StartTimeOnly = new TimeOnly(17, 30, 00) },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 04, 07), Duration = "0", Progress = 30, Status="Progress", WorkersCount=10, ParentId = 5,StartDateOnly = new DateOnly(2026, 10, 16), StartTimeOnly = new TimeOnly(18, 00, 00) }
        };
        return Tasks;
    }

    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateOnly? StartDateOnly { get; set; }
        public TimeOnly? StartTimeOnly { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public string Status { get; set; }
        public int WorkersCount { get; set; }
        public int? ParentId { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hXhxXxWpyYhnqSEo?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Column types

The Blazor Gantt component lets you specify the data type for each column using the [GanttColumn.Type](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html#Syncfusion_Blazor_Gantt_GanttColumn_Type) property. This ensures that values are rendered with appropriate formatting, such as numeric or date formats, based on the column's data type.

**Gantt supports the following column types:**

- **String:**  Text-based column.  
- **Decimal:** Decimal number column.  
- **Double:** Double-precision number column. 
- **Integer:** Integer number column.  
- **Long:** Long integer column.  
- **Boolean:** Checkbox for true/false.  
- **Date:**  Standard date column.  
- **DateTime:**  Date and time column.  
- **DateOnly:** Custom column for date.  
- **TimeOnly:** Custom column for time.  
- **Checkbox:** Displays checkbox only.
- **None:** Represents a column that binds to None data.

> The `DateOnly` and `TimeOnly` formats are supported in additional columns in the Gantt Chart.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskId" Width="150"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Job Name" Type="Syncfusion.Blazor.Grids.ColumnType.String" Width="150"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date" Format="dd/MM/yyyy hh:mm" Width="150" Type="Syncfusion.Blazor.Grids.ColumnType.DateTime"></GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date" Width="150"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration" Width="150"></GanttColumn>
        <GanttColumn Field="Progress" HeaderText="Progress"  Type="Syncfusion.Blazor.Grids.ColumnType.Integer" Format="P2" Width="150"></GanttColumn>
        <GanttColumn Field="StartDateOnly" HeaderText="Start Date Only" Format="d" Type="Syncfusion.Blazor.Grids.ColumnType.DateOnly" Width="152" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="StartTimeOnly" HeaderText="Start Time Only" Type="Syncfusion.Blazor.Grids.ColumnType.TimeOnly" Width="150" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="Status" HeaderText="Status" Type="Syncfusion.Blazor.Grids.ColumnType.Boolean" Width="150"></GanttColumn>
        <GanttColumn Field="WorkersCount" HeaderText="Workers Count" Width="150"></GanttColumn>
    </GanttColumns>
</SfGantt>

@code{
    public List<TaskData> TaskCollection { get; set; }
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() 
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 21), Status="Progress", WorkersCount=20, StartDateOnly = new DateOnly(2026, 03, 02), StartTimeOnly = new TimeOnly(10, 00, 00)},
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 5, Status="Progress", WorkersCount=10, ParentId = 1, StartDateOnly = new DateOnly(2026, 03, 04), StartTimeOnly = new TimeOnly(11, 30, 00)},
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 09), Progress = 10, Status="Hold", WorkersCount=15, ParentId = 1, StartDateOnly = new DateOnly(2026, 03, 06), StartTimeOnly = new TimeOnly(12, 00, 00)},
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, Status="PostPoned", WorkersCount=5, ParentId = 1, StartDateOnly = new DateOnly(2026, 03, 08), StartTimeOnly = new TimeOnly(13, 30, 00)},
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 21), Status="Progress", WorkersCount=25,StartDateOnly = new DateOnly(2026, 07, 10), StartTimeOnly = new TimeOnly(14, 00, 00) },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 30, Status="PostPoned", WorkersCount=10, ParentId = 5 , StartDateOnly = new DateOnly(2026, 10, 12), StartTimeOnly = new TimeOnly(16, 00, 00)},
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 04, 07),EndDate = new DateTime(2026, 04, 09), Progress = 40, Status="Progress", WorkersCount=5, ParentId = 5, StartDateOnly = new DateOnly(2026, 10, 14), StartTimeOnly = new TimeOnly(17, 30, 00) },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 04, 07), Duration = "0", Progress = 30, Status="Progress", WorkersCount=10, ParentId = 5,StartDateOnly = new DateOnly(2026, 10, 16), StartTimeOnly = new TimeOnly(18, 00, 00) }
        };
        return Tasks;
    }

    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateOnly? StartDateOnly { get; set; }
        public TimeOnly? StartTimeOnly { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public string Status { get; set; }
        public int WorkersCount { get; set; }
        public int? ParentId { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjLRjdsTyuTrylpp?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Column formatting

The Gantt Chart component for Blazor supports column formatting to customize data presentation. You can format numbers, dates, or apply templates based on specific requirements. Use the [GanttColumn.Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html#Syncfusion_Blazor_Gantt_GanttColumn_Format) property to define the desired format for each column.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskId" Width="150"></GanttColumn>
        <GanttColumn Field="TaskName" Width="150"></GanttColumn>
        <GanttColumn Field="Progress" Format="@NumberFormat" Width="250"></GanttColumn>
        <GanttColumn Field="StartDate" Format="yyyy/MM/dd" Width="250"></GanttColumn>
    </GanttColumns>
</SfGantt>

@code{
    public List<TaskData> TaskCollection { get; set; }
    private string NumberFormat = "C";
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
        List<TaskData> Tasks = new List<TaskData>() 
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 21), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 09), Progress = 40, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 21), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 30, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 40, ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 04, 07), Duration = "0", Progress = 30, ParentId = 5 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rtBxDnMTIEFlCWDJ?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

>* The Gantt uses the `Internalization` library to format values based on the specified format and culture.
>* By default, the number and date values are formatted in **en-US** locale. You can localize the currency and date to a different locale as explained [here](https://www.syncfusion.com/blazor-components/blazor-gantt-chart).
>* The available format codes may vary depending on the data type of the column.
>* You can also customize the formatting further by providing a custom function to the `GanttColumn.Format` property, instead of a format string.
>* Make sure that the format string is valid and compatible with the data type of the column, to avoid unexpected results.

### Number formatting

The Gantt Chart component for Blazor supports number formatting through the [GanttColumn.Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html#Syncfusion_Blazor_Gantt_GanttColumn_Format) property, where standard format strings define numeric value presentation including currency, percentage, and decimal formats. The following standard format strings are available:

| Format | Description        | Remarks                                                                 |
|--------|--------------------|-------------------------------------------------------------------------|
| N      | Numeric format     | Use `N2`, `N3`, etc., to set the number of decimal places.              |
| C      | Currency format    | Use `C2`, `C3`, etc., to define precision for currency values.          |
| P      | Percentage format  | Input should be between 0 and 1; `P2`, `P3`, etc., control precision.   |


The following example code demonstrates the formatting of data for the **TaskID** column using the **N2** format, the **Progress** column using the **P2** format.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskId" Width="150" Format="N2"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Job Name" Width="250"></GanttColumn>
        <GanttColumn Field="StartDate"></GanttColumn>
        <GanttColumn Field="Progress" Format="P2" Width="250"></GanttColumn>
        <GanttColumn Field="Duration"></GanttColumn>
    </GanttColumns>
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
        List<TaskData> Tasks = new List<TaskData>() 
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 21), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 09), Progress = 40, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 21), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 30, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 40, ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 04, 07), Duration = "0", Progress = 30, ParentId = 5 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZBxXRspokkvVqGo?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

### Date formatting

The Gantt component for Blazor supports date formatting in columns using the [GanttColumn.Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html#Syncfusion_Blazor_Gantt_GanttColumn_Format) property, where format strings such as **d**, **D**, **MMM dd, yyyy** can be applied. Both built-in formats like **yMd** and custom formats are supported to define the layout and detail of date and time values based on column requirements. The following custom formats and their corresponding output are listed below:

Format | Formatted value
-----|-----
{ type:'date', format:'dd/MM/yyyy' } | 04/07/2022
{ type:'date', format:'dd.MM.yyyy' } | 04.07.2022
{ type:'date', skeleton:'short' } | 7/4/22
{ type: 'dateTime', format: 'dd/MM/yyyy hh:mm tt' } | 04/07/2022 12:00 AM
{ type: 'dateTime', format: 'MM/dd/yyyy hh:mm:ss tt' } | 07/04/2022 12:00:00 AM

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskId" Width="150"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Job Name" Width="250"></GanttColumn>
        <GanttColumn Field="StartDate" Format="@DateFormat"></GanttColumn>
        <GanttColumn Field="Duration"></GanttColumn>
    </GanttColumns>
</SfGantt>

@code{
    public List<TaskData> TaskCollection { get; set; }
    private string DateFormat = "MM/dd/yyyy";

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
        List<TaskData> Tasks = new List<TaskData>() 
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 21), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 09), Progress = 40, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 21), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 30, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 40, ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 04, 07), Duration = "0", Progress = 30, ParentId = 5 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDhxDxsJxXLWcTii?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## AutoFit columns

The Syncfusion<sup style="font-size:70%">®</sup> Gantt component for Blazor supports automatic column width adjustment based on content. Double-clicking the column header resizer adjusts the width to fit the maximum content, ensuring clear data visibility without wrapping. To enable this feature, set [AllowResizing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AllowResizing) to **true**.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px" AllowResizing="true">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskId" Width="150"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Job Name" Width="150"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date" Width="150"></GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date" Width="150"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration" Width="150"></GanttColumn>
        <GanttColumn Field="Progress" HeaderText="Progress" Width="150"></GanttColumn>
        <GanttColumn Field="StartDateOnly" HeaderText="Start Date Only" Format="d" Type="Syncfusion.Blazor.Grids.ColumnType.DateOnly" Width="152" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="StartTimeOnly" HeaderText="Start Time Only" Type="Syncfusion.Blazor.Grids.ColumnType.TimeOnly" Width="150" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="Status" HeaderText="Status" Width="150"></GanttColumn>
        <GanttColumn Field="WorkersCount" HeaderText="Workers Count" Width="150"></GanttColumn>
    </GanttColumns>
</SfGantt>

@code {
    
    public List<TaskData> TaskCollection { get; set; }

    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }
   
    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 21), Status="Progress", WorkersCount=20, StartDateOnly = new DateOnly(2026, 03, 02), StartTimeOnly = new TimeOnly(10, 00, 00)},
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 5, Status="Progress", WorkersCount=10, ParentId = 1, StartDateOnly = new DateOnly(2026, 03, 04), StartTimeOnly = new TimeOnly(11, 30, 00)},
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 09), Progress = 10, Status="Hold", WorkersCount=15, ParentId = 1, StartDateOnly = new DateOnly(2026, 03, 06), StartTimeOnly = new TimeOnly(12, 00, 00)},
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, Status="PostPoned", WorkersCount=5, ParentId = 1, StartDateOnly = new DateOnly(2026, 03, 08), StartTimeOnly = new TimeOnly(13, 30, 00)},
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 21), Status="Progress", WorkersCount=25,StartDateOnly = new DateOnly(2026, 07, 10), StartTimeOnly = new TimeOnly(14, 00, 00) },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 30, Status="PostPoned", WorkersCount=10, ParentId = 5 , StartDateOnly = new DateOnly(2026, 10, 12), StartTimeOnly = new TimeOnly(16, 00, 00)},
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 40, Status="Progress", WorkersCount=5, ParentId = 5, StartDateOnly = new DateOnly(2026, 10, 14), StartTimeOnly = new TimeOnly(17, 30, 00) },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 04, 07), Duration = "0", Progress = 30, Status="Progress", WorkersCount=10, ParentId = 5,StartDateOnly = new DateOnly(2026, 10, 16), StartTimeOnly = new TimeOnly(18, 00, 00) }
        };
        return Tasks;
    }

    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateOnly? StartDateOnly { get; set; }
        public TimeOnly? StartTimeOnly { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public string Status { get; set; }
        public int WorkersCount { get; set; }
        public int? ParentId { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjVHNnMoWhmSlfXI?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

### Resizing a column to fit its content using method

You can resize a column in Gantt Chart to fit its content using the [AutoFitColumnsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_AutoFitColumnsAsync_System_String___) method. This adjusts the column width based on the widest cell without wrapping. To apply this during initial rendering, call the method in the [DataBound](https://blazor.syncfusion.com/documentation/gantt-chart/events#databound) event.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt @ref="Gantt" DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskId" Width="150"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Job Name" Width="150"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date" Width="150"></GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date" Width="150"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration" Width="150"></GanttColumn>
        <GanttColumn Field="Progress" HeaderText="Progress" Width="150"></GanttColumn>
        <GanttColumn Field="StartDateOnly" HeaderText="Start Date Only" Format="d" Type="Syncfusion.Blazor.Grids.ColumnType.DateOnly" Width="152" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="StartTimeOnly" Format="HH:mm:ss" HeaderText="Start Time Only" Type="Syncfusion.Blazor.Grids.ColumnType.TimeOnly" Width="150" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></GanttColumn>
        <GanttColumn Field="Status" HeaderText="Status" Width="150" EditType=Syncfusion.Blazor.Grids.EditType.DefaultEdit></GanttColumn>
        <GanttColumn Field="WorkersCount" HeaderText="Workers Count" Width="150" EditType=Syncfusion.Blazor.Grids.EditType.NumericEdit></GanttColumn>
    </GanttColumns>
    <GanttEvents DataBound="DataBoundHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

@code {
    public SfGantt<TaskData> Gantt;
    public List<TaskData> TaskCollection { get; set; }
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    private async void DataBoundHandler(object args)
    {
        await Gantt.AutoFitColumnsAsync(new string[] { "TaskName", "StartDate", "EndDate" });
    }

    public class TaskData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public DateOnly? StartDateOnly { get; set; }
        public TimeOnly? StartTimeOnly { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public string Status { get; set; }
        public int WorkersCount { get; set; }
        public int? ParentId { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 21), Status="Progress", WorkersCount=20, StartDateOnly = new DateOnly(2026, 03, 02), StartTimeOnly = new TimeOnly(10, 00, 00)},
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 5, Status="Progress", WorkersCount=10, ParentId = 1, StartDateOnly = new DateOnly(2026, 03, 04), StartTimeOnly = new TimeOnly(11, 30, 00)},
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 09), Progress = 10, Status="Hold", WorkersCount=15, ParentId = 1, StartDateOnly = new DateOnly(2026, 03, 06), StartTimeOnly = new TimeOnly(12, 00, 00)},
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, Status="PostPoned", WorkersCount=5, ParentId = 1, StartDateOnly = new DateOnly(2026, 03, 08), StartTimeOnly = new TimeOnly(13, 30, 00)},
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 21), Status="Progress", WorkersCount=25,StartDateOnly = new DateOnly(2026, 07, 10), StartTimeOnly = new TimeOnly(14, 00, 00) },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 30, Status="PostPoned", WorkersCount=10, ParentId = 5 , StartDateOnly = new DateOnly(2026, 10, 12), StartTimeOnly = new TimeOnly(16, 00, 00)},
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 40, Status="Progress", WorkersCount=5, ParentId = 5, StartDateOnly = new DateOnly(2026, 10, 14), StartTimeOnly = new TimeOnly(17, 30, 00) },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 04, 07), Duration = "0", Progress = 30, Status="Progress", WorkersCount=10, ParentId = 5,StartDateOnly = new DateOnly(2026, 10, 16), StartTimeOnly = new TimeOnly(18, 00, 00) }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDBntnCSCUtNsRxM?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Change tree column

The Syncfusion<sup style="font-size:70%">®</sup> Blazor Gantt Chart component displays hierarchical task relationships using expand/collapse icons. These icons help users navigate parent and child tasks efficiently. To configure their position, set the [TreeColumnIndex](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_TreeColumnIndex) property to the index of the column where the icons should appear. By default, the value is **0**, which places them in the first column.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
    <SfGantt DataSource="@TaskCollection" TreeColumnIndex="2" Height="450px" Width="700px">
        <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate"
              Duration="Duration" Progress="Progress" ParentID="ParentId"></GanttTaskFields>
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
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() 
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 21), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 09), Progress = 40, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 21), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 30, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 40, ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 04, 07), Duration = "0", Progress = 30, ParentId = 5 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LDBxNRCIigrZolBz?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Show or hide columns

The Blazor Gantt Chart component allows dynamic control over column visibility using built-in properties and methods.

### Using methods

You can dynamically show or hide columns using the [ShowColumnsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_ShowColumnsAsync_System_String___System_String_) and [HideColumnsAsync](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_HideColumnsAsync_System_String___System_String_) methods. These methods accept either a single value or an array of values, and a second parameter to specify whether the value refers to the column's `HeaderText` or `Field`.

**Based on header text:**

To control visibility using the column's header text:

- Pass the header text (or array of header texts) as the first parameter.
- Specify `HeaderText` as the second parameter.

The following example demonstrates hiding and showing the **Duration** column using button clicks:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<div style="margin-bottom: 20px;">
    <button class="btn btn-primary" @onclick="show">Show Columns</button>
    <button class="btn btn-secondary" @onclick="hide" style="margin-left: 10px;">Hide Columns</button>
</div>
<SfGantt @ref="Gantt" DataSource="@TaskCollection" Height="450px" Width="900px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskId" Width="100"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Job Name" Width="250"></GanttColumn>
        <GanttColumn Field="StartDate"></GanttColumn>
        <GanttColumn Field="EndDate"></GanttColumn>
        <GanttColumn Field="Duration"></GanttColumn>
        <GanttColumn Field="Progress"></GanttColumn>
    </GanttColumns>
</SfGantt>

@code{
    public SfGantt<TaskData> Gantt;
    public List<TaskData> TaskCollection { get; set; }
    private string[] ColumnList = {"Duration"};

    public async Task show() {
        await Gantt.ShowColumnsAsync(ColumnList, "HeaderText");
    }

    public async Task hide() {
        await Gantt.HideColumnsAsync(ColumnList, "HeaderText");
    }

    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
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
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 21), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 09), Progress = 40, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 21), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 30, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 40, ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 04, 07), Duration = "0", Progress = 30, ParentId = 5 }   
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXrRjnCysUJRgosu?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

**Based on field:**

To control visibility using the column's field name:

- Pass the field name (or array of field names) as the first parameter.
- Specify `Field` as the second parameter.

The following example demonstrates hiding and showing the **TaskName** and **Duration** columns using button clicks:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<div style="margin-bottom: 20px;">
    <button class="btn btn-primary" @onclick="show">Show Columns</button>
    <button class="btn btn-secondary" @onclick="hide" style="margin-left: 10px;">Hide Columns</button>
</div>
<SfGantt @ref="Gantt" DataSource="@TaskCollection" Height="450px" Width="900px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskId" Width="100"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Task Name" Width="250"></GanttColumn>
        <GanttColumn Field="StartDate"></GanttColumn>
        <GanttColumn Field="EndDate"></GanttColumn>
        <GanttColumn Field="Duration"></GanttColumn>
        <GanttColumn Field="Progress"></GanttColumn>
    </GanttColumns>
</SfGantt>

@code{
    public SfGantt<TaskData> Gantt;
    public List<TaskData> TaskCollection { get; set; }
    private string[] ColumnList = {"TaskName", "Duration"};

    public void show() {
        this.Gantt.ShowColumnsAsync(ColumnList, "Field");
    }

    public void hide() {
        this.Gantt.HideColumnsAsync(ColumnList, "Field");
    }

    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
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
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 21), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 09), Progress = 40, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 21), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 30, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 40, ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 04, 07), Duration = "0", Progress = 30, ParentId = 5 }   
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/htBRZnCIWAekIlkZ?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Controlling Gantt actions

The Blazor Gantt Chart component allows fine-grained control over column-level actions such as editing, filtering, sorting, resizing, and reordering. These actions can be enabled or disabled individually using the following properties in the [GanttColumn](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html) configuration:

| Property | Description |
|----------|-------------|
| [AllowEditing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html#Syncfusion_Blazor_Gantt_GanttColumn_AllowEditing) | Enables or disables editing for a column. |
| [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html#Syncfusion_Blazor_Gantt_GanttColumn_AllowFiltering) | Enables or disables filtering for a column. |
| [AllowSorting](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html#Syncfusion_Blazor_Gantt_GanttColumn_AllowSorting) | Enables or disables sorting for a column. |
| [AllowReordering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html#Syncfusion_Blazor_Gantt_GanttColumn_AllowReordering) | Enables or disables reordering for a column. |
| [AllowResizing](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html#Syncfusion_Blazor_Gantt_GanttColumn_AllowResizing) | Enables or disables resizing for a column. |

> **Note:** These settings are applied per column and do not affect global Gantt behavior.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="900px" AllowSorting="true" AllowFiltering="true" AllowReordering="true"  AllowResizing="true">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId">
    </GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskId" Width="100" AllowResizing="false"></GanttColumn>
        <GanttColumn Field="TaskName" AllowReordering="false" Width="250"></GanttColumn>
        <GanttColumn Field="StartDate" AllowEditing="false"></GanttColumn>
        <GanttColumn Field="Duration" AllowSorting="false"></GanttColumn>
        <GanttColumn Field="Progress" AllowFiltering="false"></GanttColumn>
    </GanttColumns>
    <GanttEditSettings AllowEditing="true"></GanttEditSettings>
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
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public bool Verified { get; set; }
        public int? ParentId { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() 
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 21), Verified = true, },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 04, 06), Duration = "0", Verified = true, Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 09), Verified = false, Progress = 40, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 04, 02), Duration = "0", Verified = true, Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 21), Verified = false, },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Verified = true, Progress = 30, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Verified = false, Progress = 40, ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 04, 07), Duration = "0", Verified = true, Progress = 30, ParentId = 5 }, 
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNhdNxsoCUbQCdBB?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}

## Responsive columns

The  Blazor Gantt Chart component provides a built-in feature to control column visibility based on media queries using the [HideAtMedia](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttColumn.html#Syncfusion_Blazor_Gantt_GanttColumn_HideAtMedia) property in the column object. This method can be used to hide columns automatically when the screen width matches specified [media query](http://cssmediaqueries.com/what-are-css-media-queries.html) conditions.

The following example demonstrates a Gantt chart where the **Job Name** column is set to `(min-width: 700px)`, meaning it will be hidden when the browser width is less than or equal to 700px. Similarly, the **Duration** column is set to `(max-width: 500px)`, so it will be hidden when the browser width exceeds 500px.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate"
             Duration="Duration" Progress="Progress" ParentID="ParentId"></GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskId" Width="150" HideAtMedia="(min-width: 700px)"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Job Name" Width="250"></GanttColumn>
        <GanttColumn Field="StartDate"></GanttColumn>
        <GanttColumn Field="Duration" HideAtMedia="(min-width: 500px)"></GanttColumn>
    </GanttColumns>
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
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentId { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() 
        {
            new TaskData() { TaskId = 1, TaskName = "Project initiation", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 21), },
            new TaskData() { TaskId = 2, TaskName = "Identify Site location", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 3, TaskName = "Perform soil test", StartDate = new DateTime(2026, 04, 06), EndDate = new DateTime(2026, 04, 09), Progress = 40, ParentId = 1 },
            new TaskData() { TaskId = 4, TaskName = "Soil test approval", StartDate = new DateTime(2026, 04, 06), Duration = "0", Progress = 30, ParentId = 1 },
            new TaskData() { TaskId = 5, TaskName = "Project estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 21), },
            new TaskData() { TaskId = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 30, ParentId = 5 },
            new TaskData() { TaskId = 7, TaskName = "List materials", StartDate = new DateTime(2026, 04, 07), EndDate = new DateTime(2026, 04, 09), Progress = 40, ParentId = 5 },
            new TaskData() { TaskId = 8, TaskName = "Estimation approval", StartDate = new DateTime(2026, 04, 07), Duration = "0", Progress = 30, ParentId = 5 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZrHjRWeiTZDEQue?appbar=false&editor=false&result=true&errorlist=false&theme=fluent2" %}


