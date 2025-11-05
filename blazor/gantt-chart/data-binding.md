---
layout: post
title: Data Binding in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about Data Binding in Syncfusion Blazor Gantt Chart component and much more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Data Binding in Blazor Gantt Chart Component

Data binding connects the Blazor Gantt component to project data sources, enabling dynamic visualization and management of project information. The component supports both local and remote data integration through the  [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_DataSource) property, which accepts either a list of business objects or a [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) instance.

It supports the following kinds of data binding method:

* List binding
* Remote data

N> When using `DataSource` as `IEnumerable<T>`, component type(TValue) will be inferred from its value. When using [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) for data binding, the **TValue** must be provided explicitly in the Gantt component.

## List binding

To bind list binding to the Gantt component, you can assign a IEnumerable object to the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_DataSource) property. The list data source can also be provided as an instance of the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) or by using `SfDataManager` component.

### Hierarchical data Binding

Hierarchical data binding organizes complex parent-child relationships through nested object structures. Each parent task contains multiple child tasks through the `Child` field mapping, creating natural tree structures that represent project hierarchies.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt

<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" Child="SubTasks">
    </GanttTaskFields>
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
        public List<TaskData> SubTasks { get; set; }
    }

    public static List<TaskData> GetTaskCollection()
    {
        List<TaskData> Tasks = new List<TaskData>() {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 21), SubTasks = (new List <TaskData> () { new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, }, new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, }, new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30 }, }) },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 04, 21), SubTasks = (new List <TaskData> () { new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, }, new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 40 }, new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0", Progress = 30, } }) }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BXryWDrzgHBfdbbx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

N> * Indent/Outdent is not supported for hierarchy data.
<br/> * ExpandCollapse state maintenance is not supported for hierarchy data.
<br/> * Row drag and drop feature is not supported for hierarchy data.

### Self-referential data structure

Self-referential data binding uses flat data structures where tasks reference their relationships through ID fields. Map unique task identifiers to the [Id](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTaskFields.html#Syncfusion_Blazor_Gantt_GanttTaskFields_Id) field and parent identifiers to the [ParentID](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTaskFields.html#Syncfusion_Blazor_Gantt_GanttTaskFields_ParentID) field of [GanttTaskFields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTaskFields.html) to establish task hierarchies without nested objects.

This approach enables the component to reconstruct hierarchical tree structures from relational data, making it ideal for database-driven applications where parent-child relationships are maintained through foreign key references.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
<SfGantt DataSource="@TaskCollection" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
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
        List<TaskData> Tasks = new List<TaskData>() {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2021, 04, 05), EndDate = new DateTime(2021, 04, 21), },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2021, 04, 05), Duration = "4", Progress = 50, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2021, 04, 05), Duration = "4", Progress = 50, ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Prepare product sketch and notes", StartDate = new DateTime(2021, 04, 05), Duration = "2", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Concept approval", StartDate = new DateTime(2021, 04, 08), EndDate = new DateTime(2021, 04, 08), Duration="0", ParentID = 1 }
        };
        return Tasks;
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hjhSCDrpKdvgSTeD?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### DynamicObject binding

To handle scenarios where the data model is not defined at compile time, the Gantt Chart can be bound to a list of **DynamicObject** using the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_DataSource) property. This enables full support for data operations and editing without requiring a strongly typed model.

> The [GetDynamicMemberNames](https://learn.microsoft.com/en-us/dotnet/api/system.dynamic.dynamicobject.getdynamicmembernames?view=net-8.0) method of the `DynamicObject` class must be overridden to return the property names required for rendering, data operations, editing, and other related functionalities when using **DynamicObject** with the Gantt Chart.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using System.Dynamic

<SfGantt DataSource="@GanttDynamicData" Height="500px" Width="100%" HighlightWeekends="true">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" Progress="Progress" Duration="Duration" ParentID="ParentID"></GanttTaskFields>
    <GanttColumns>
        <GanttColumn Field="TaskID" HeaderText="Task ID" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right" Width="100"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Task Name" Width="250"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date" Width="250"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration" Width="250"></GanttColumn>
        <GanttColumn Field="Progress" HeaderText="Progress" Format="@NumberFormat" Width="250"></GanttColumn>
    </GanttColumns>
    <GanttEditSettings AllowAdding="true" AllowEditing="true" AllowDeleting="true" AllowTaskbarEditing="true" ShowDeleteConfirmDialog="true"></GanttEditSettings>
</SfGantt>

@code {
    private string NumberFormat = "C";
    private static List<DynamicDictionary> Data = new List<DynamicDictionary>();
    private List<DynamicDictionary> GanttDynamicData { get; set; }
    private static int ParentRecordID { get; set; }
    private static int ChildRecordID { get; set; }

    protected override void OnInitialized()
    {
        this.GanttDynamicData = GetData().ToList();
    }

    public static List<DynamicDictionary> GetData()
    {
        Data.Clear();
        ParentRecordID = 0;
        ChildRecordID = 0;
        for (var i = 1; i <= 10; i++)
        {
            Random ran = new Random();
            DateTime start = new DateTime(2022, 01, 07);
            int range = (DateTime.Today - start).Days;
            DateTime startingDate = start.AddDays(ran.Next(range));
            dynamic ParentRecord = new DynamicDictionary();
            ParentRecord.TaskID = ++ParentRecordID;
            ParentRecord.TaskName = "Parent Task " + i;
            ParentRecord.StartDate = startingDate;
            ParentRecord.Progress = ran.Next(10, 100);
            ParentRecord.Duration = ParentRecordID % 2 == 0 ? (32).ToString() : (76).ToString();
            ParentRecord.ParentID = null;
            Data.Add(ParentRecord);
            AddChildRecords(ParentRecordID);
        }
        return Data;
    }

    public static void AddChildRecords(int ParentID)
    {
        for (var i = 1; i < 4; i++)
        {
            Random ran = new Random();
            DateTime start = new DateTime(2022, 01, 07);
            int range = (DateTime.Today - start).Days;
            DateTime startingDate = start.AddDays(ran.Next(range));
            dynamic ChildRecord = new DynamicDictionary();
            ChildRecord.TaskID = ++ParentRecordID;
            ChildRecord.TaskName = "Child Task " + ++ChildRecordID;
            ChildRecord.StartDate = startingDate;
            ChildRecord.Progress = ran.Next(10, 100);
            ChildRecord.Duration = ParentRecordID % 3 == 0 ? (64).ToString() : (98).ToString();
            ChildRecord.ParentID = ParentID;
            Data.Add(ChildRecord);
        }
    }

    public class DynamicDictionary : DynamicObject
    {
        Dictionary<string, object> dictionary = new Dictionary<string, object>();
        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            string name = binder.Name;
            return dictionary.TryGetValue(name, out result);
        }

        public override bool TrySetMember(SetMemberBinder binder, object value)
        {
            dictionary[binder.Name] = value;
            return true;
        }

        public override System.Collections.Generic.IEnumerable<string> GetDynamicMemberNames()
        {
            return this.dictionary?.Keys;
        }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/rZLIsjrfgbLmeSRq?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### ExpandoObject Binding

To handle scenarios where the model type is unknown at compile time, the Gantt Chart can be bound to a list of **ExpandoObject** using the [DataSource](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_DataSource) property. This enables full support for rendering, data operations, editing, and other related functionalities without requiring a strongly typed model.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using System.Dynamic

<SfGantt TValue="ExpandoObject" DataSource="@TreeData" @ref="Gantt" Height="450px" Width="700px">
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" Duration="Duration"
        Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true"></GanttEditSettings>
</SfGantt>

@code {
    SfGantt<ExpandoObject> Gantt;
    private List<ExpandoObject> TreeData { get; set; }

    protected override void OnInitialized()
    {
        this.TreeData = GetData().ToList();
    }
    private static List<ExpandoObject> Data = new List<ExpandoObject>();
    private static int ParentRecordID { get; set; }
    private static int ChildRecordID { get; set; }
    public static List<ExpandoObject> GetData()
    {
        Data.Clear();
        ParentRecordID = 0;
        ChildRecordID = 0;
        for (var i = 1; i <= 60; i++)
        {
            Random ran = new Random();
            DateTime start = new DateTime(2022, 03, 07);
            int range = (DateTime.Today - start).Days;
            DateTime startingDate = start.AddDays(ran.Next(range));
            dynamic ParentRecord = new ExpandoObject();
            ParentRecord.TaskID = ++ParentRecordID;
            ParentRecord.TaskName = "Parent Task " + i;
            ParentRecord.StartDate = startingDate;
            ParentRecord.Progress = ran.Next(10, 100);
            ParentRecord.Duration = ParentRecordID % 2 == 0 ? (32).ToString() : (76).ToString();
            ParentRecord.ParentID = null;
            Data.Add(ParentRecord);
            AddChildRecords(ParentRecordID);
        }
        return Data;
    }
    public static void AddChildRecords(int ParentID)
    {
        for (var i = 1; i < 4; i++)
        {
            Random ran = new Random();
            DateTime start = new DateTime(2022, 03, 07);
            int range = (DateTime.Today - start).Days;
            DateTime startingDate = start.AddDays(ran.Next(range));
            dynamic ChildRecord = new ExpandoObject();
            ChildRecord.TaskID = ++ParentRecordID;
            ChildRecord.TaskName = "Child Task " + ++ChildRecordID;
            ChildRecord.StartDate = startingDate;
            ChildRecord.Progress = ran.Next(10, 100);
            ChildRecord.Duration = ParentRecordID % 3 == 0 ? (64).ToString() : (98).ToString();
            ChildRecord.ParentID = ParentID;
            Data.Add(ChildRecord);
        }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LtVyWNrfUFwbmcnX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Observable collection and INotifyPropertyChanged

The Gantt chart supports to automatically update data based on `INotifyCollectionChanged` and `INotifyPropertyChanged` interface.

### Observable collection

To handle dynamic changes in the data source, the Gantt Chart supports binding to an [ObservableCollection](https://learn.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1?view=net-6.0). This collection implements the [INotifyCollectionChanged](https://learn.microsoft.com/en-us/dotnet/api/system.collections.specialized.inotifycollectionchanged?view=net-6.0) interface, which automatically notifies the UI when items are added, removed, moved, or cleared.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Buttons
@using System.Collections.ObjectModel
@using System.Collections.Specialized

<div>
    <div style="padding-bottom:20px">
        <SfButton style="margin-right:20px" ID="add" @onclick="AddRecord">Add Data</SfButton>
        <SfButton ID="del" @onclick="DeleteRecord">Delete Data</SfButton>
    </div>
    <div style="padding-bottom:10px;text-align:center; font-weight:bold; color:#0078D4;">
        @StatusMessage
    </div>
    <SfGantt DataSource="@ObservableData" Toolbar="@(new List<string>() { "Add", "Delete" })">
        <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
        </GanttTaskFields>
        <GanttEditSettings AllowAdding="true" AllowDeleting="true"></GanttEditSettings>
    </SfGantt>
</div>

@code {
    public ObservableCollection<TaskData> ObservableData { get; set; }
    public string StatusMessage { get; set; } = "";

    protected override void OnInitialized()
    {
        ObservableData = ProjectNewData();
        ObservableData.CollectionChanged += Records_CollectionChanged;
    }

    public void AddRecord()
    {
        int newId = ObservableData.Any() ? ObservableData.Max(t => t.TaskID) + 1 : 1;
        Random rand = new Random();

        int randomProgress = rand.Next(0, 101);
        int randomDuration = rand.Next(1, 6);

        ObservableData.Add(new TaskData()
        {
            TaskID = newId,
            TaskName = $"New Task {newId}",
            StartDate = DateTime.Now,
            Duration = randomDuration.ToString(),
            Progress = randomProgress
        });
    }

    public void DeleteRecord()
    {
        if (ObservableData.Count != 0)
        {
            int deleteRecordTaskID = ObservableData.First().TaskID;
            ObservableData.Remove(ObservableData.First());
            RemoveChild(deleteRecordTaskID);
        }
    }

    public void RemoveChild(int id)
    {
        var childRecords = ObservableData.Where(t => t.ParentID == id).ToList();
        foreach (var child in childRecords)
        {
            RemoveChild(child.TaskID);
            ObservableData.Remove(child);
        }
    }

    public ObservableCollection<TaskData> ProjectNewData()
    {
        return new ObservableCollection<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 08) },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 04, 08) },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 40, ParentID = 5 },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0", Progress = 30, ParentID = 5 }
        };
    }

    public void Records_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
        switch (e.Action)
        {
            case NotifyCollectionChangedAction.Add:
                StatusMessage = $"Task added: {((TaskData)e.NewItems[0]).TaskName}";
                break;
            case NotifyCollectionChangedAction.Remove:
                StatusMessage = $"Task removed: {((TaskData)e.OldItems[0]).TaskName}";
                break;
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
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/LjVeMXhmBmWiglpH?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### INotifyPropertyChanged

The Gantt chart provides support to update its data automatically when an item's property value changes, if the item implements the [INotifyPropertyChanged](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=net-6.0) interface.

This interface is used to notify that a property value has changed. For example, `TaskData` raises the `PropertyChanged` event when **TaskName** is updated, allowing Gantt to reflect the change without a manual refresh.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Buttons
@using System.Collections.ObjectModel
@using System.ComponentModel

<div>
    <div style="padding-bottom:20px">
        <SfButton ID="update" @onclick="UpdateRecord">Update Data</SfButton>
    </div>

    <SfGantt DataSource="@ObservableData" Toolbar="@(new List<string>() { "Cancel", "Edit", "Update" })">
        <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentID">
        </GanttTaskFields>
        <GanttEditSettings AllowEditing="true"></GanttEditSettings>
    </SfGantt>
</div>

@code {
    public ObservableCollection<TaskData> ObservableData { get; set; }

    protected override void OnInitialized()
    {
        ObservableData = ProjectNewData();
    }

    public void UpdateRecord()
    {
        if (ObservableData.Count != 0)
        {
            var firstTask = ObservableData.First();
            firstTask.TaskName = "Record Updated";
        }
    }

    public ObservableCollection<TaskData> ProjectNewData()
    {
        return new ObservableCollection<TaskData>()
        {
            new TaskData() { TaskID = 1, TaskName = "Project initiation", StartDate = new DateTime(2022, 04, 05), EndDate = new DateTime(2022, 04, 08) },
            new TaskData() { TaskID = 2, TaskName = "Identify Site location", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 3, TaskName = "Perform soil test", StartDate = new DateTime(2022, 04, 05), Duration = "4", Progress = 40, ParentID = 1 },
            new TaskData() { TaskID = 4, TaskName = "Soil test approval", StartDate = new DateTime(2022, 04, 05), Duration = "0", Progress = 30, ParentID = 1 },
            new TaskData() { TaskID = 5, TaskName = "Project estimation", StartDate = new DateTime(2022, 04, 06), EndDate = new DateTime(2022, 04, 08) },
            new TaskData() { TaskID = 6, TaskName = "Develop floor plan for estimation", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 30, ParentID = 5 },
            new TaskData() { TaskID = 7, TaskName = "List materials", StartDate = new DateTime(2022, 04, 06), Duration = "3", Progress = 40, ParentID = 5 },
            new TaskData() { TaskID = 8, TaskName = "Estimation approval", StartDate = new DateTime(2022, 04, 06), Duration = "0", Progress = 30, ParentID = 5 }
        };
    }

    public class TaskData : INotifyPropertyChanged
    {
        public int TaskID { get; set; }

        private string taskName;
        public string TaskName
        {
            get => taskName;
            set
            {
                if (taskName != value)
                {
                    taskName = value;
                    NotifyPropertyChanged(nameof(TaskName));
                }
            }
        }

        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentID { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
        }
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/BDVysjVQBwoWOmGQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## Remote Data

The Syncfusion Blazor component enables remote data binding by connecting UI components to server-side data sources. This approach facilitates fetching, displaying, and manipulating data stored on remote servers.

To bind remote data to the Gantt component, assign service data as an instance of [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) to the `DataSource` property or use the `SfDataManager` component.Set the service endpoint using the **Url** property to enable data operations.

 N> When using `SfDataManager` for data binding,  the **TValue** must be provided explicitly in the Gantt component.
<br/> By default, `SfDataManager` uses **ODataAdaptor** for remote data-binding.

### Web API adaptor

The Gantt Chart component utilizes the **WebApiAdaptor**, an extension of the **ODataAdaptor**, for seamless integration with Web API services, including OData V4 endpoints. This adaptor supports efficient data retrieval and operations such as sorting, filtering, searching, and paging. It communicates with Web API endpoints using HTTP requests in JSON format, ensuring compatibility with OData-formatted queries for stable connectivity to remote data sources.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Data

<SfGantt TValue="GanttRemoteData" Height="450px">
    <SfDataManager Url="https://blazor.syncfusion.com/services/production/api/GanttData" Adaptor="Adaptors.WebApiAdaptor" CrossDomain="true"></SfDataManager>
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" Duration="Duration" Progress="Progress" Dependency="Predecessor" Child="SubTasks">
    </GanttTaskFields>
</SfGantt>

@code{
    public class GanttRemoteData
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public int? Duration { get; set; }
        public int Progress { get; set; }
        public string Predecessor { get; set; }
        public List<GanttRemoteData>SubTasks { get; set; }
    }
}
{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/hZVoMXhzJQuKjqpZ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### ODataV4 adaptor

The Gantt Chart component seamlessly integrates with OData V4 services via the **ODataV4Adaptor**., enabling efficient data retrieval and operations like sorting, filtering, searching, and paging using a queryable Entity Data Model (EDM), ensuring compatibility with the advanced features offered by the OData V4 protocol. For more details on OData v4 services, refer to the [OData documentation](http://docs.oasis-open.org/odata/odata/v4.0/errata03/os/complete/part1-protocol/odata-v4.0-errata03-os-part1-protocol-complete.html#_Toc453752197).

{% tabs %}

{% highlight razor %}

@using ODataAdap.Models
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor

<SfGantt TValue="TaskDatum" Height="450px" Width="100%" HighlightWeekends="true" AllowFiltering="true" AllowSorting="true" Toolbar="@(new List<string>(){ "Add", "Edit", "Update", "Delete", "Cancel", "ExpandAll", "CollapseAll","Indent","Outdent"})" AllowSelection="true" GridLines="GridLine.Both"
TreeColumnIndex="1">
    <SfDataManager Url="odata/Gantt" Adaptor="Adaptors.ODataV4Adaptor"></SfDataManager>
    <GanttTaskFields Id="TaskId" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration" Progress="Progress" ParentID="ParentId"></GanttTaskFields>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true" ShowDeleteConfirmDialog="true"></GanttEditSettings>
    <GanttColumns>
        <GanttColumn Field="TaskId" Width="100"></GanttColumn>
        <GanttColumn Field="TaskName" HeaderText="Job Name" Width="250" ClipMode="Syncfusion.Blazor.Grids.ClipMode.EllipsisWithTooltip"></GanttColumn>
        <GanttColumn Field="StartDate" HeaderText="Start Date"></GanttColumn>
        <GanttColumn Field="EndDate" HeaderText="End Date"></GanttColumn>
        <GanttColumn Field="Duration" HeaderText="Duration"></GanttColumn>
    </GanttColumns>
    <GanttLabelSettings LeftLabel="TaskName" TValue="TaskDatum">
    </GanttLabelSettings>
    <GanttSplitterSettings Position="40%"> </GanttSplitterSettings>
</SfGantt>

{% endhighlight %}

{% highlight c# tabtitle="TaskDatum.cs" %}

namespace ODataAdap.Models;

public partial class TaskDatum
{
    public long Id { get; set; }
    public int TaskId { get; set; }
    public string? TaskName { get; set; }
    public DateTime? StartDate { get; set; }
    public DateTime? EndDate { get; set; }
    public int? ParentId { get; set; }
    public int? Progress { get; set; }
    public int? Duration { get; set; }
}

{% endhighlight %}

{% highlight c# tabtitle="GanttController.cs" %}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Formatter;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using ODataAdap.Models;

namespace ODataAdap.Controllers
{
    [Route("api/[controller]")]
    public class GanttController : ODataController
    {
        private OdataContext _db;
        public GanttController(OdataContext context)
        {
            _db = context;
        }
        [HttpGet]
        [EnableQuery]
        public IActionResult Get()
        {
            return Ok(_db.TaskData);
        }
        [EnableQuery]
        public async Task<IActionResult> Post([FromBody] TaskDatum data)
        {
            _db.TaskData.Add(data);
            _db.SaveChanges();
            return Created(data);
        }
        [EnableQuery]
        public async Task<IActionResult> Patch([FromODataUri] long key, [FromBody] Delta<TaskDatum> data)
        {
            var entity = await _db.TaskData.FindAsync(key);
            data.Patch(entity);
            await _db.SaveChangesAsync();
            return Updated(entity);
        }
        [EnableQuery]
        public long Delete([FromODataUri] long key)
        {
            var deleterow = _db.TaskData.Find(key);
            _db.TaskData.Remove(deleterow);
            _db.SaveChanges();
            return key;
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="Program.cs" %}

using Microsoft.AspNetCore.OData;
using Microsoft.EntityFrameworkCore;
using Microsoft.OData.Edm;
using Microsoft.OData.ModelBuilder;
using ODataAdap.Data;
using ODataAdap.Models;
using Syncfusion.Blazor;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
static IEdmModel GetEdmModel()
{
    ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
    var datas = builder.EntitySet<TaskDatum>("Gantt");
    FunctionConfiguration myFirstFunction = datas.EntityType.Collection.Function("MyFirstFunction");
    myFirstFunction.ReturnsCollectionFromEntitySet<TaskDatum>("Gantt");
    return builder.GetEdmModel();
}
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddSyncfusionBlazor();

builder.Services.AddDbContext<OdataContext>(option =>
                option.UseSqlServer(builder.Configuration.GetConnectionString("GanttDatabase")));

builder.Services.AddControllers().AddOData(opt => opt.AddRouteComponents("odata", GetEdmModel()).Count().Filter().OrderBy().Expand().Select().SetMaxTop(null));
builder.Services.AddControllersWithViews();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseRouting();
app.MapControllers();
app.UseMvcWithDefaultRoute();
app.MapBlazorHub();
app.MapFallbackToPage("/_Host");

app.Run();

{% endhighlight %}

{% endtabs %}

N>You can find the sample for load on demand [here](https://github.com/SyncfusionExamples/BlazorGantt-OData-Adaptor-sample).

### Load child on demand


To load child records dynamically, set the remote service URL in `SfDataManager.Url` and configure the [GanttTaskFields.HasChildMapping](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttTaskFields.html#Syncfusion_Blazor_Gantt_GanttTaskFields_HasChildMapping) property.

The `HasChildMapping` property identifies whether a record contains child items, allowing Gantt to display the expand icon and fetch child data on demand.

The [LoadChildOnDemand](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_LoadChildOnDemand) property, when disabled, renders all root nodes in a collapsed state initially. You can expand a node to fetch its children from the server.

The [EnableVirtualization](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.SfGantt-1.html#Syncfusion_Blazor_Gantt_SfGantt_1_EnableVirtualization) property, when enabled along with `LoadChildOnDemand` disabled, renders only the visible root nodes in a collapsed state.

You can expand a root node to load its children, which are then cached locally. On subsequent expand/collapse actions, child records are loaded from the local cache instead of from the remote server.

The `LoadChildOnDemand` property, when enabled, renders parent records in an expanded state by default.

{% tabs %}

{% highlight razor %}

@using WebAPI.Data
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Gantt

<SfGantt TValue="TaskData" Height="450px" Width="1000px" LoadChildOnDemand="false">
   <SfDataManager Url="api/Default" Adaptor="Adaptors.WebApiAdaptor"></SfDataManager>
   <GanttTaskFields Id="ID" Name="TaskName" StartDate="StartDate" EndDate="EndDate"
        Duration="Duration" Dependency="Predecessor" ParentID="ParentId" HasChildMapping="isParent">
   </GanttTaskFields>
</SfGantt>

{% endhighlight %}

{% highlight c# tabtitle="TaskData.cs" %}

namespace WebAPI.Data
{
    public class TaskData
    {
        public static List<TaskData> tree = new List<TaskData>();
        [JsonPropertyName("ID")]
        public int ID { get; set; }
        [JsonPropertyName("TaskName")]
        public string TaskName { get; set; }
        [JsonPropertyName("StartDate")]
        public DateTime StartDate { get; set; }
        [JsonPropertyName("EndDate")]
        public DateTime EndDate { get; set; }
        [JsonPropertyName("Duration")]
        public string Duration { get; set; }
        [JsonPropertyName("Progress")]
        public int Progress { get; set; }
        [JsonPropertyName("ParentId")]
        public int? ParentId { get; set; }
        [JsonPropertyName("Predecessor")]
        public string Predecessor { get; set; }
        [JsonPropertyName("isParent")]
        public bool? isParent { get; set; }
        public TaskData() { }
        public static List<TaskData> GetTree()
        {
            if (tree.Count == 0)
            {
                Random rand = new Random();
                var x = 0;
                int duration = 0;
                DateTime startDate = new DateTime(2000, 1, 3, 08, 00, 00);
                for (var i = 1; i <= 50; i++)
                {
                    startDate = startDate.AddDays(i == 1 ? 0 : 7);
                    DateTime childStartDate = startDate;
                    TaskData Parent = new TaskData()
                    {
                        ID = ++x,
                        TaskName = "Task " + x,
                        StartDate = startDate,
                        EndDate = startDate.AddDays(26),
                        Duration = "20",
                        Progress = rand.Next(100),
                        Predecessor = null,
                        isParent = true,
                        ParentId = null
                    };
                    tree.Add(Parent);
                    for (var j = 1; j <= 4; j++)
                    {
                        childStartDate = childStartDate.AddDays(j == 1 ? 0 : duration + 2);
                        duration = 5;
                        tree.Add(new TaskData()
                        {
                            ID = ++x,
                            TaskName = "Task " + x,
                            StartDate = childStartDate,
                            EndDate = childStartDate.AddDays(5),
                            Duration = duration.ToString(),
                            Progress = rand.Next(100),
                            ParentId = Parent.ID,
                            Predecessor = j > 1 ? (x - 1) + "FS" : "",
                            isParent = false
                        });
                    }
                }
            }
            return tree;
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="DefaultController.cs" %}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using WebAPI.Data;
using Syncfusion.Blazor.Data;
using System.Collections;

namespace WebAPI.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {

        public static List<TaskData> DataList = new List<TaskData>();
        private static DataRequest req = null;
        [HttpGet]
        public async Task<object> Get(int? code)
        {
            DataList.Clear();
            IQueryCollection queryString = Request.Query;
            req = QueryGenerator(queryString);
            if (TaskData.tree.Count == 0)
                TaskData.GetTree();
            if (req.filter != "" && !req.filter.Contains("null"))
            {
                int fltr = Int32.Parse(req.filter.Split("eq")[1]);
                IQueryable<TaskData> data1 = TaskData.tree.Where(f => f.ParentId == fltr).AsQueryable();
                if (queryString.Keys.Contains("$orderby"))
                {
                    string srt;
                    srt = req.orderby.Replace("desc", "descending");
                    data1 = SortingExtend.Sort(data1, srt);
                }
                return new { result = data1.ToList(), items = data1.ToList(), count = data1.Count() };
            }
            List<TaskData> data = TaskData.tree.ToList();
            if (req.orderby != "")
            {
                string srt;
                srt = req.orderby.Replace("desc", "descending");
                IQueryable<TaskData> data1 = SortingExtend.Sort(data.AsQueryable(), srt);
                data = data1.ToList();
            }
            if (queryString.Keys.Contains("$select"))
            {
                data = (from rec in TaskData.tree
                        select new TaskData
                        {
                            ParentId = rec.ParentId
                        }
                        ).ToList();
                return data;
            }
            data = data.Where(p => p.ParentId == null).ToList();
            int count = data.Count;
            if (req.inlinecount)
            {
                if (req.skip == null && req.take == null)
                    DataList = data;
                else
                    DataList = data.Skip((int)req.skip).Take((int)req.take).ToList();
                if (req.loadchild)
                {
                    var GroupData = TaskData.tree.ToList().GroupBy(rec => rec.ParentId)
                                .Where(g => g.Key != null).ToDictionary(g => g.Key?.ToString(), g => g.ToList());
                    foreach (var Record in DataList.ToList())
                    {
                        if (GroupData.ContainsKey(Record.ID.ToString()))
                        {
                            var ChildGroup = GroupData[Record.ID.ToString()];
                            if (ChildGroup?.Count > 0)
                                AppendChildren(ChildGroup, Record, GroupData);
                        }
                    }
                }
                if (req.skip == null && req.take == null)
                    return new { result = DataList, items = DataList, count = count };
                return new { result = DataList, items = DataList, count = count };
            }
            else
            {
                return TaskData.GetTree();
            }
        }
        public DataRequest QueryGenerator(IQueryCollection queryString)
        {
            DataRequest req = new DataRequest();
            StringValues Skip;
            StringValues Take;
            StringValues filter;
            StringValues orderby;
            StringValues loadchild;
            req.loadchild = queryString.TryGetValue("loadchildondemand", out loadchild) ? Convert.ToBoolean(loadchild[0]) : false;
            req.skip = queryString.TryGetValue("$skip", out Skip) ? Convert.ToInt32(Skip[0]) : (Nullable<int>)null;
            req.take = (queryString.TryGetValue("$top", out Take)) ? Convert.ToInt32(Take[0]) : (Nullable<int>)null;
            req.filter = queryString.TryGetValue("$filter", out filter) ? filter[0].ToString() : "";
            req.inlinecount = queryString.Keys.Contains("$inlinecount") ? true : false;
            req.orderby = queryString.TryGetValue("$orderby", out orderby) ? orderby[0].ToString() : "";
            return req;
        }

        private void AppendChildren(List<TaskData> ChildRecords, TaskData ParentItem, Dictionary<string, List<TaskData>> GroupData)
        {
            var queryString = Request.Query;
            string TaskId = ParentItem.ID.ToString();
            if (queryString.Keys.Contains("$orderby"))
            {
                StringValues srt;
                queryString.TryGetValue("$orderby", out srt);
                srt = srt.ToString().Replace("desc", "descending");
                List<TaskData> SortedChildRecords = SortingExtend.Sort(ChildRecords.AsQueryable(), srt).ToList();
                var index = DataList.IndexOf(ParentItem);
                foreach (var Child in SortedChildRecords)
                {
                    string ParentId = Child.ParentId.ToString();
                    if (TaskId == ParentId)
                    {
                        if (DataList.IndexOf(Child) == -1)
                            ((IList)DataList).Insert(++index, Child);
                        if (GroupData.ContainsKey(Child.ID.ToString()))
                        {
                            var DeepChildRecords = GroupData[Child.ID.ToString()];
                            if (DeepChildRecords?.Count > 0)
                                AppendChildren(DeepChildRecords, Child, GroupData);
                        }
                    }
                }
            }
            else
            {
                var index = DataList.IndexOf(ParentItem);
                foreach (var Child in ChildRecords)
                {
                    string ParentId = Child.ParentId.ToString();
                    if (TaskId == ParentId)
                    {
                        if (DataList.IndexOf(Child) == -1)
                            ((IList)DataList).Insert(++index, Child);
                        if (GroupData.ContainsKey(Child.ID.ToString()))
                        {
                            var DeepChildRecords = GroupData[Child.ID.ToString()];
                            if (DeepChildRecords?.Count > 0)
                                AppendChildren(DeepChildRecords, Child, GroupData);
                        }
                    }
                }
            }
        }
        public class DataRequest
        {
            public Nullable<int> skip { get; set; }
            public Nullable<int> take { get; set; }
            public Boolean inlinecount { get; set; }
            public string filter { get; set; }
            public string orderby { get; set; }
            public bool loadchild { get; set; }
            public DateTime startDate { get; set; }
            public DateTime endDate { get; set; }
        }
    }
    public static class SortingExtend
    {
        public static IQueryable<T> Sort<T>(this IQueryable<T> source, string sortBy)
        {
            if (source == null)
                throw new ArgumentNullException("source");
            if (string.IsNullOrEmpty(sortBy))
                throw new ArgumentNullException("sortBy");
            source = (IQueryable<T>)source.OrderBy(sortBy);
            return source;
        }
    }
}

{% endhighlight %}

{% endtabs %}

> * Filtering and searching are not supported in load on demand.
> * Only Self-Referential type data is supported with remote data binding in Gantt Chart.
> * Load-on-demand supports only the validated data source.

N>You can find the sample for load on demand [here](https://github.com/SyncfusionExamples/Lazy-Loading-in-Blazor-Gantt-Chart).

### Sending additional parameters to the server

To specify custom parameters in a data request, use the `addParams` method of the `Query` class. The configured `Query` object with additional parameters should be assigned to the Gantt component’s [Query](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.Query.html) property to include them in server communication.

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Gantt

<SfGantt TValue="TaskData" Height="450px" Width="700px" Query=@GanttQuery>
     <SfDataManager Url="/Home/UrlDatasource" Adaptor="Adaptors.UrlAdaptor"></SfDataManager>
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration"
        Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true"></GanttEditSettings>
</SfGantt>

@code{
    private string ParamValue = "true";
    private Query GanttQuery { get; set; }

    protected override void OnInitialized() {
        GanttQuery = new Query().AddParams("ej2gantt", ParamValue);
    }

    public class TaskData
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentID { get; set; }
    }
}

{% endhighlight %}
{% endtabs %}

### Handling HTTP error

Exceptions triggered during Gantt operations can be handled effectively without interrupting the application. These errors are captured using the [OnActionFailure](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Gantt.GanttEvents-1.html#Syncfusion_Blazor_Gantt_GanttEvents_1_OnActionFailure) event, which provides detailed information returned from the server. This allows for appropriate handling, logging, or user notification without affecting the overall workflow.

The following sample code demonstrates notifying user when server-side exception has occurred during data operation:

{% tabs %}
{% highlight razor %}

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Grids

<label class="error" style="display:block; color: red; margin-bottom: 20px;">@ErrorDetails</label>
<SfGantt TValue="TaskData" Height="450px" Width="700px">
     <SfDataManager Url="https://some.com/invalidUrl" Adaptor="Adaptors.UrlAdaptor"></SfDataManager>
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Duration="Duration"
        Progress="Progress" ParentID="ParentID">
    </GanttTaskFields>
    <GanttEvents TValue="TaskData" OnActionFailure="ActionFailure"></GanttEvents>
</SfGantt>

@code{
    private string ErrorDetails = "";
    public class TaskData
    {
        public int TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Duration { get; set; }
        public int Progress { get; set; }
        public int? ParentID { get; set; }
    }

    public void ActionFailure(Syncfusion.Blazor.Grids.FailureEventArgs args)
    {
        this.ErrorDetails = args.Error.Message.ToString();
        StateHasChanged();
    }
}

{% endhighlight %}
{% endtabs %}

{% previewsample "https://blazorplayground.syncfusion.com/embed/VXrosNrTBJxCLRgJ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}