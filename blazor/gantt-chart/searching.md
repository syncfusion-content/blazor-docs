---
layout: post
title: Searching in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about searching in Syncfusion Blazor Gantt Chart component and much more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Search in Blazor Gantt Component

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Gantt component allows quick filtering of records based on search input, improving access to relevant data in large datasets.

To enable this feature, add the **Search** option to the `Toolbar` configuration.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="900px" Toolbar="@(new List<string>() { "Search" })">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
</SfGantt>

@code{
    private List<TaskData> TaskCollection { get; set; }
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/BZrSWZZSJQLgfUSZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Initial search

The Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Gantt compoenent allows applying search criteria during initial load using the [GanttSearchSettings](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttSearchSettings.html) property.  

To configure this feature, define the following properties:

| Property      | Description                                                                                  |
|---------------|----------------------------------------------------------------------------------------------|
| `Fields`      | Defines the fields where the search should be applied.                                       |
| `Operator`    | Sets the condition for matching (e.g., `Contains`, `Equals`).                                |
| `Key`         | Specifies the value to search for.                                                            |
| `IgnoreCase`  | Determines if the search should be case-insensitive.                                         |
| `IgnoreAccent`| Ignores diacritic characters or accents during the search.


The following sample demonstrates an initial search where `Fields` is set to **TaskName**, `Operator` is **Contains**, `Key` is **Product**, and `IgnoreCase` is **true**.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="900px" Toolbar="@(new List<string>() { "Search" })">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttSearchSettings Fields="@(new string[] { "TaskName" })" Operator="Operator.Contains" Key="Perförm" IgnoreCase="true" IgnoreAccent="true"></GanttSearchSettings>
</SfGantt>

@code{
    private List<TaskData> TaskCollection { get; set; }

    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    private static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 7), },
            new TaskData() { TaskID = 2, TaskName = "Identify site locàtion", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
            new TaskData() { TaskID = 3, TaskName = "Perförm soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentID = 1, },
            new TaskData() { TaskID = 4, TaskName = "Soil tëst appröval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1, },
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjLyiDDSIBEAoMzK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Search operators

Search operators specify the type of comparison used during a search. These are configured through the [GanttSearchSettings.Operator](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttSearchSettings.html#Syncfusion_Blazor_Gantt_GanttSearchSettings_Operator) property.

The following operators are supported in searching:

| Operator     | Description                                      |
|--------------|--------------------------------------------------|
| startsWith   | Matches values that begin with the specified text. |
| endsWith     | Matches values that end with the specified text.   |
| contains     | Matches values that include the specified text.    |
| equal        | Matches values that exactly match the specified text. |
| notEqual     | Matches values that do not match the specified text. |

> The default value for `GanttSearchSettings.Operator` is `contains`.


{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.DropDowns

<PageTitle>Gantt Search Operator</PageTitle>

<div style="margin-bottom: 20px;font-weight:bold">
    <label style="margin-right: 10px;">Change the search operator:</label>
    <SfDropDownList Width="150px" TValue="Syncfusion.Blazor.Operator" TItem="DropDownOrder" Value="@SearchOperator" DataSource="@DropDownData">
        <DropDownListFieldSettings Value="Value" Text="Text"></DropDownListFieldSettings>
        <DropDownListEvents TValue="Syncfusion.Blazor.Operator" TItem="DropDownOrder" ValueChange="OnValueChange">
        </DropDownListEvents>
    </SfDropDownList>
</div>

<SfGantt DataSource="@TaskCollection" Height="450px" Width="100%" Toolbar="@(new List<string>() { "Search" })" SearchSettings="@(new GanttSearchSettings { Operator = SearchOperator })">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
</SfGantt>

@code {
    private List<TaskData> TaskCollection { get; set; }
    public Syncfusion.Blazor.Operator SearchOperator { get; set; } = Syncfusion.Blazor.Operator.StartsWith;

    public class DropDownOrder
    {
        public string Text { get; set; }
        public Syncfusion.Blazor.Operator Value { get; set; }
    }

    List<DropDownOrder> DropDownData = new List<DropDownOrder>
    {
        new DropDownOrder(){Text="StartsWith",Value= Syncfusion.Blazor.Operator.StartsWith },
        new DropDownOrder(){Text="EndsWith",Value=Syncfusion.Blazor.Operator.EndsWith},
        new DropDownOrder(){Text="Contains",Value=Syncfusion.Blazor.Operator.Contains},
        new DropDownOrder(){Text="Equal",Value=Syncfusion.Blazor.Operator.Equal}
    };

    public void OnValueChange(ChangeEventArgs<Syncfusion.Blazor.Operator, DropDownOrder> args)
    {
        SearchOperator = args.Value;
    }

    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
    }

    private static List<TaskData> GetTaskCollection()
    {
        return new List<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 07) },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 10) },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentID = 5 },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentID = 5 }
        };
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDhyCXDyyrZiOnqz?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Search by external button

To perform a search from an external button in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Gantt component, call the `SearchAsync` method programmatically with the desired keyword.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<div style="margin-bottom: 10px; display: flex; gap: 10px; align-items: center;">
    <SfTextBox @bind-Value="SearchText" Placeholder="Search text" ShowClearButton="true" Width="200px" Change="OnTextChanged" />
    <SfButton @onclick="Search">Search</SfButton>
</div>

<SfGantt @ref="GanttInstance" DataSource="@TaskCollection" Height="450px" Width="700px" AllowFiltering="true">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID" />
</SfGantt>

@code {
    private SfGantt<TaskData> GanttInstance;
    private string SearchText { get; set; } = string.Empty;
    private List<TaskData> TaskCollection { get; set; }

    protected override void OnInitialized()
    {
        TaskCollection = GetTaskCollection();
    }

    private void Search()
    {
        this.GanttInstance?.SearchAsync(SearchText);
    }

    private void OnTextChanged(Syncfusion.Blazor.Inputs.ChangeEventArgs<string> args)
    {
        if (string.IsNullOrWhiteSpace(args?.Value))
        {
            this.GanttInstance?.SearchAsync("");
        }
    }

    private static List<TaskData> GetTaskCollection()
    {
        return new List<TaskData>
        {
            new TaskData { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 07) },
            new TaskData { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 01, 04), Duration = "4", Progress = 40, ParentID = 1 },
            new TaskData { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 01, 04), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 01, 04), EndDate = new DateTime(2022, 01, 10) },
            new TaskData { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 30, ParentID = 5 },
            new TaskData { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 01, 06), Duration = "3", Progress = 40, ParentID = 5 },
            new TaskData { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 01, 06), Duration = "0", Progress = 30, ParentID = 5 }
        };
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/hNLSWXtSfkTkIRvv?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> You should set the `AllowFiltering` property to `true` for searching the content externally.

## Search specific columns

To search specific columns in the Gantt component, use the [GanttSearchSettings.Fields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttSearchSettings.html#Syncfusion_Blazor_Gantt_GanttSearchSettings_Fields) property. This allows you to define which column fields should be included in the search, instead of searching across all columns by default.

This following sample demonstrates searching only within the **TaskName** and **Duration** columns.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="900px" Toolbar="@(new List<string>() { "Search" })">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttSearchSettings Fields="@(new string[] { "TaskName", "Duration" })">
    </GanttSearchSettings>
</SfGantt>
@code{
    private List<TaskData> TaskCollection { get; set; }
        
    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VDhIsjteTkwVEGvi?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %} 

N> In above sample, you can search only `TaskName` and `Duration` column values.

## Clear search by external button

To clear the search results in the Syncfusion<sup style="font-size:70%">&reg;</sup> Angular Gantt from an external button, set the [searchSettings.key](https://ej2.syncfusion.com/angular/documentation/api/gantt/searchSettings/#key) property to an empty string. 
 
Alternatively, you can invoke the `SearchAsync` method with an empty string to reset the search.


{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Buttons

<SfButton style="margin-bottom:20px" @onclick="Clear">Clear Search</SfButton>
<SfGantt @ref="GanttInstance" DataSource="@TaskCollection" Height="450px" Width="900px" Toolbar="@(new List<string>() { "Search" })">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttSearchSettings Fields="@(new string[] { "TaskName" })" Operator="Operator.Contains"
          Key="List" IgnoreCase="true"></GanttSearchSettings>
</SfGantt>

@code{
    public SfGantt<TaskData> GanttInstance;
    private List<TaskData> TaskCollection { get; set; }

    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    public void Clear()
    {
        this.GanttInstance?.SearchAsync("");
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjVIstNSeXFfGxal?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Search on each key stroke

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Buttons

<SfButton style="margin-bottom:20px" @onclick="Clear">Clear Search</SfButton>
<SfGantt @ref="GanttInstance" DataSource="@TaskCollection" Height="450px" Width="900px" Toolbar="@(new List<string>() { "Search" })">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttSearchSettings Fields="@(new string[] { "TaskName" })" Operator="Operator.Contains"
          Key="List" IgnoreCase="true"></GanttSearchSettings>
</SfGantt>

@code{
    public SfGantt<TaskData> GanttInstance;
    private List<TaskData> TaskCollection { get; set; }

    protected override void OnInitialized()
    {
        this.TaskCollection = GetTaskCollection();
    }

    public void Clear()
    {
        this.GanttInstance?.SearchAsync("");
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

{% previewsample "https://blazorplayground.syncfusion.com/embed/VjVIstNSeXFfGxal?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}


