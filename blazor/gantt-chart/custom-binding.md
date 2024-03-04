---
layout: post
title: Custom Binding in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about Custom Binding in Syncfusion Blazor Gantt Chart component and more.
platform: Blazor
control: Gantt Chart
documentation: ug
---

# Custom Binding in Blazor Gantt Chart Component

The [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) has custom adaptor support which allows you to perform manual operations on the data. This can be utilized for implementing custom data binding and editing operations in the Gantt component.

For implementing custom data binding in Gantt, the **DataAdaptor** class is used. This abstract class acts as a base class for the custom adaptor. The **DataAdaptor** abstract class has both synchronous and asynchronous method signatures which can be overridden in the custom adaptor. Following are the method signatures present in this class,

```csharp
public abstract class DataAdaptor
{
    /// <summary>
    /// Performs data Read operation synchronously.
    /// </summary>
    public virtual object Read(DataManagerRequest dataManagerRequest, string key = null)

    /// <summary>
    /// Performs data Read operation asynchronously.
    /// </summary>
    public virtual Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)

    /// <summary>
    /// Performs Insert operation synchronously.
    /// </summary>
    public virtual object Insert(DataManager dataManager, object data, string key)
    /// <summary>
    /// Performs Insert operation asynchronously.
    /// </summary>
    public virtual Task<object> InsertAsync(DataManager dataManager, object data, string key)

    /// <summary>
    /// Performs Remove operation synchronously.
    /// </summary>
    public virtual object Remove(DataManager dataManager, object data, string keyField, string key)

    /// <summary>
    /// Performs Remove operation asynchronously.
    /// </summary>
    public virtual Task<object> RemoveAsync(DataManager dataManager, object data, string keyField, string key)

    /// <summary>
    /// Performs Update operation synchronously.
    /// </summary>
    public virtual object Update (DataManager dataManager, object data, string keyField, string key)

    /// <summary>
    /// Performs Update operation asynchronously.
    /// </summary>
    public virtual Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)

    /// <summary>
    /// Performs Batch CRUD operations synchronously.
    /// </summary>
    public virtual object BatchUpdate(DataManager dataManager, object changedRecords, object addedRecords, object deletedRecords, string keyField, string key, int? dropIndex)

    /// <summary>
    /// Performs Batch CRUD operations asynchronously.
    /// </summary>
    public virtual Task<object> BatchUpdateAsync(DataManager dataManager, object changedRecords, object addedRecords, object deletedRecords, string keyField, string key, int? dropIndex)
}
```

## Data binding

The custom data binding can be performed in the Gantt component by providing the custom adaptor class and overriding the **Read** or **ReadAsync** method of the **DataAdaptor** abstract class.

The following sample code demonstrates implementing custom data binding using custom adaptor,

```cshtml
@using Syncfusion.Blazor.Gantt;
@using Syncfusion.Blazor.Data;
@using Syncfusion.Blazor;

<SfGantt TValue="TaskData" Height="450px" Width="1000px" LoadChildOnDemand="true">
     <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Progress="Progress" Duration="Duration"  ParentID="ParentID">
    </GanttTaskFields>
</SfGantt>

@code{
    public static List<TaskData> GanttData { get; set; }
    public static List<TaskData> gantt = new List<TaskData>();
    public class TaskData
    {
        public int? TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Progress { get; set; }
        public int Duration { get; set; }
        public int? ParentID { get; set; }
        public TaskData() { }
    }
    public static List<TaskData> GetGantt()
    {
        if (gantt.Count == 0)
        {
            int root = -1;
            for (var t = 1; t <= 8; t++)
            {
                string math = (20 % 3) == 0 ? "High" : (20 % 2) == 0 ? "Release Breaker" : "Critical";
                root++;
                int rootItem = gantt.Count + root + 1;
                gantt.Add(new TaskData() { TaskID = rootItem, TaskName = "Parent Task " + rootItem.ToString(), StartDate = new DateTime(2022, 06, 07), EndDate = new DateTime(2022, 08, 25), Progress = 70, ParentID = null, Duration = 20 });
                int parent = gantt.Count;
                for (var c = 0; c < 3; c++)
                {
                    root++;
                    string val = ((parent + c + 1) % 3 == 0) ? "Low" : "Critical";
                    int parn = parent + c + 1;
                    int iD = gantt.Count + root + 1;
                    gantt.Add(new TaskData() { TaskID = iD, TaskName = "Child Task " + iD.ToString(), StartDate = new DateTime(2022, 06, 07), EndDate = new DateTime(2022, 08, 25), Progress = 30, ParentID = rootItem, Duration = 5 });
                    if ((((parent + c + 1) % 3) == 0))
                    {
                        int immParent = gantt.Count;
                        for (var s = 0; s <= 1; s++)
                        {
                            root++;
                            gantt.Add(new TaskData() { TaskID = gantt.Count + root + 1, TaskName = "Sub Task " + (gantt.Count + root + 1).ToString(), StartDate = new DateTime(2022, 06, 07), EndDate = new DateTime(2022, 08, 25), Progress = 50, ParentID = iD, Duration = 8 });
                        }
                    }
                }
            }
        }
        return gantt;
    }

    // Implementing custom adaptor by extending the DataAdaptor class.
    public class CustomAdaptor : DataAdaptor
    {
        // Performs data Read operation.
        public override object Read(DataManagerRequest dm, string key = null)
        {
            IEnumerable<TaskData> DataSource = GanttData;
            if (dm.Search != null && dm.Search.Count > 0)
            {
                // Searching
                DataSource = DataOperations.PerformSearching(DataSource, dm.Search);
            }
            if (dm.Sorted != null && dm.Sorted.Count > 0)
            {
                // Sorting
                DataSource = DataOperations.PerformSorting(DataSource, dm.Sorted);
            }
            if (dm.Where != null && dm.Where.Count > 0)
            {
                // Filtering
                if (dm.Where[0].Field != null && dm.Where[0].Field == "ParentID"){}
                else
                {
                    DataSource = DataOperations.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
                }
            }
            int count = DataSource.Cast<TaskData>().Count();
            if (dm.Skip != 0)
            {
                //Paging
                DataSource = DataOperations.PerformSkip(DataSource, dm.Skip);
            }
            if (dm.Take != 0)
            {
                DataSource = DataOperations.PerformTake(DataSource, dm.Take);
            }
            return dm.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
        }
    }
    protected override void OnInitialized()
    {
        GanttData = GetGantt().ToList();
    }
}
```

N> If the **DataManagerRequest.RequiresCounts** value is **true**, then the Read/ReadAsync return value must be of **DataResult** with properties **Result** whose value is a collection of records and **Count** whose value is the total number of records. If the **DataManagerRequest.RequiresCounts** is **false**, then simply send the collection of records.
<br/> <br /> If the Read/ReadAsync method is not overridden in the custom adaptor then it will be handled by the default read handler.

## Inject service into custom adaptor

If you want to inject some of your service into Custom Adaptor and use the service, then you can achieve your requirement by using below way.

Initially you need to add CustomAdaptor class as AddScoped in `Program.cs` file.

```csharp
builder.Services.AddSingleton<TaskDataAccessLayer>();
builder.Services.AddScoped<CustomAdaptor>();
builder.Services.AddScoped<ServiceClass>();
```

The following sample code demonstrates injecting service into Custom Adaptor,

```cshtml
@using Syncfusion.Blazor.Gantt;
@using Syncfusion.Blazor.Data;
@using Syncfusion.Blazor;

<SfGantt TValue="TaskData" Height="450px" Width="1000px" LoadChildOnDemand="true">
     <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Progress="Progress" Duration="Duration"  ParentID="ParentID">
    </GanttTaskFields>
</SfGantt>

@code{
    public static List<TaskData> GanttData { get; set; }
    public static List<TaskData> gantt = new List<TaskData>();
    public class TaskData
    {
        public int? TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Progress { get; set; }
        public int Duration { get; set; }
        public int? ParentID { get; set; }
        public TaskData() { }
    }
    public static List<TaskData> GetGantt()
    {
        if (gantt.Count == 0)
        {
            int root = -1;
            for (var t = 1; t <= 8; t++)
            {
                string math = (60 % 3) == 0 ? "High" : (60 % 2) == 0 ? "Release Breaker" : "Critical";
                root++;
                int rootItem = gantt.Count + root + 1;
                gantt.Add(new TaskData() { TaskID = rootItem, TaskName = "Parent Task " + rootItem.ToString(), StartDate = new DateTime(2022, 06, 07), EndDate = new DateTime(2022, 08, 25), Progress = 70, ParentID = null, Duration = 20 });
                int parent = gantt.Count;
                for (var c = 0; c < 3; c++)
                {
                    root++;
                    string val = ((parent + c + 1) % 3 == 0) ? "Low" : "Critical";
                    int parn = parent + c + 1;
                    int iD = gantt.Count + root + 1;
                    gantt.Add(new TaskData() { TaskID = iD, TaskName = "Child Task " + iD.ToString(), StartDate = new DateTime(2022, 06, 07), EndDate = new DateTime(2022, 08, 25), Progress = 30, ParentID = rootItem, Duration = 5 });
                    if ((((parent + c + 1) % 3) == 0))
                    {
                        int immParent = gantt.Count;
                        for (var s = 0; s <= 1; s++)
                        {
                            root++;
                            gantt.Add(new TaskData() { TaskID = gantt.Count + root + 1, TaskName = "Sub Task " + (gantt.Count + root + 1).ToString(), StartDate = new DateTime(2022, 06, 07), EndDate = new DateTime(2022, 08, 25), Progress = 50, ParentID = iD, Duration = 8 });
                        }
                    }
                }
            }
        }
        return gantt;
    }

    // Implementing custom adaptor by extending the DataAdaptor class.
    public class CustomAdaptor : DataAdaptor
    {
        //Here, you can inject your service.
        [Inject]
        public TaskDataAccessLayer context { get; set; } = new TaskDataAccessLayer();
        // Performs data Read operation
        public override object Read(DataManagerRequest dm, string key = null)
        {
            IEnumerable<TaskData> DataSource = GanttData;
            if (dm.Search != null && dm.Search.Count > 0)
            {
                // Searching
                DataSource = DataOperations.PerformSearching(DataSource, dm.Search);
            }
            if (dm.Sorted != null && dm.Sorted.Count > 0)
            {
                // Sorting
                DataSource = DataOperations.PerformSorting(DataSource, dm.Sorted);
            }
            if (dm.Where != null && dm.Where.Count > 0)
            {
                // Filtering
                if (dm.Where[0].Field != null && dm.Where[0].Field == "ParentID"){}
                else
                {
                    DataSource = DataOperations.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
                }
            }
            int count = DataSource.Cast<TaskData>().Count();
            if (dm.Skip != 0)
            {
                //Paging
                DataSource = DataOperations.PerformSkip(DataSource, dm.Skip);
            }
            if (dm.Take != 0)
            {
                DataSource = DataOperations.PerformTake(DataSource, dm.Take);
            }
            return dm.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
        }
    }
    protected override void OnInitialized()
    {
        GanttData = GetGantt().ToList();
    }
}
```

## CRUD operation

The CRUD operations for the custom bounded data in the Gantt component can be implemented by overriding the following CRUD methods of the **DataAdaptor** abstract class,

* **Insert/InsertAsync**
* **Remove/RemoveAsync**
* **Update/UpdateAsync**
* **BatchUpdate/BatchUpdateAsync**

N> While using batch editing in Gantt, use BatchUpdate/BatchUpdateAsync method to handle the corresponding CRUD operation.

The following sample code demonstrates implementing CRUD operations for the custom bounded data,

```cshtml
@using Syncfusion.Blazor.Gantt;
@using Syncfusion.Blazor.Data;
@using Syncfusion.Blazor;

<SfGantt TValue="TaskData" Height="450px" Width="1000px" LoadChildOnDemand="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })">
     <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Progress="Progress" Duration="Duration"  ParentID="ParentID">
    </GanttTaskFields>
     <GanttEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true"></GanttEditSettings>
     <GanttEvents RowUpdating="RowUpdatingHandler" TValue="TaskData"></GanttEvents>
</SfGantt>

@code{
    public static List<TaskData> GanttData { get; set; }
    public static List<TaskData> gantt = new List<TaskData>();
    public static int index = 0;
    
    public void RowUpdatingHandler(GanttRowUpdatingEventArgs<TaskData> args)
    {
        index = args.Index;
    }

    public class TaskData
    {
        public int? TaskID { get; set; }
        public string TaskName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Progress { get; set; }
        public int Duration { get; set; }
        public int? ParentID { get; set; }
        public TaskData() { }
    }

    protected override void OnInitialized()
    {
        GanttData = GetGantt().ToList();
    }
    public static List<TaskData> GetGantt()
    {
        if (gantt.Count == 0)
        {
            int root = -1;
            for (var t = 1; t <= 8; t++)
            {
                string math = (42 % 3) == 0 ? "High" : (42 % 2) == 0 ? "Release Breaker" : "Critical";
                root++;
                int rootItem = gantt.Count + root + 1;
                gantt.Add(new TaskData() { TaskID = rootItem, TaskName = "Parent Task " + rootItem.ToString(), StartDate = new DateTime(2022, 06, 07), EndDate = new DateTime(2022, 08, 25), Progress = 70, ParentID = null, Duration = 20 });
                int parent = gantt.Count;
                for (var c = 0; c < 3; c++)
                {
                    root++;
                    string val = ((parent + c + 1) % 3 == 0) ? "Low" : "Critical";
                    int parn = parent + c + 1;
                    int iD = gantt.Count + root + 1;
                    gantt.Add(new TaskData() { TaskID = iD, TaskName = "Child Task " + iD.ToString(), StartDate = new DateTime(2022, 06, 07), EndDate = new DateTime(2022, 08, 25), Progress = 30, ParentID = rootItem, Duration = 5 });
                    if ((((parent + c + 1) % 3) == 0))
                    {
                        int immParent = gantt.Count;
                        for (var s = 0; s <= 1; s++)
                        {
                            root++;
                            gantt.Add(new TaskData() { TaskID = gantt.Count + root + 1, TaskName = "Sub Task " + (gantt.Count + root + 1).ToString(), StartDate = new DateTime(2022, 06, 07), EndDate = new DateTime(2022, 08, 25), Progress = 50, ParentID = iD, Duration = 8 });
                        }
                    }
                }
            }
        }
        return gantt;
    }

    // Implementing custom adaptor by extending the DataAdaptor class.
    public class CustomAdaptor : DataAdaptor
    {
        // Performs data Read operation.
        public override object Read(DataManagerRequest dm, string key = null)
        {
            IEnumerable<TaskData> DataSource = GanttData;
            if (dm.Search != null && dm.Search.Count > 0)
            {
                // Searching
                DataSource = DataOperations.PerformSearching(DataSource, dm.Search);
            }
            if (dm.Sorted != null && dm.Sorted.Count > 0)
            {
                // Sorting
                DataSource = DataOperations.PerformSorting(DataSource, dm.Sorted);
            }
            if (dm.Where != null && dm.Where.Count > 0)
            {
                // Filtering
                if (dm.Where[0].Field != null && dm.Where[0].Field == "ParentID"){}
                else
                {
                    DataSource = DataOperations.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
                }
            }
            int count = DataSource.Cast<TaskData>().Count();
            if (dm.Skip != 0)
            {
                //Paging
                DataSource = DataOperations.PerformSkip(DataSource, dm.Skip);
            }
            if (dm.Take != 0)
            {
                DataSource = DataOperations.PerformTake(DataSource, dm.Take);
            }
            return dm.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
        }
        public override object Insert(DataManager dm, object value, string key)
        {
            GanttData.Insert(index, value as TaskData);
            return value;
        }

        // Performs Remove operation.
        public override object Remove(DataManager dm, object value, string keyField, string key)
        {
            GanttData.Remove(GanttData.Where(or => or.TaskID == int.Parse(value.ToString())).FirstOrDefault());
            return value;
        }

        // Performs Update operation.
        public override object Update(DataManager dm, object value, string keyField, string key)
        {
            var data = GanttData.Where(or => or.TaskID == (value as TaskData).TaskID).FirstOrDefault();
            if (data != null)
            {
                data.TaskID = (value as TaskData).TaskID;
                data.TaskName = (value as TaskData).TaskName;
                data.StartDate = (value as TaskData).StartDate;
                data.EndDate = (value as TaskData).EndDate;
                data.Duration = (value as TaskData).Duration;
                data.Progress = (value as TaskData).Progress;
            }
            return value;
        }
    }
}
```

N>You can find the sample for custom adaptor [here](https://github.com/SyncfusionExamples/Gantt-Chart-Custom-Adaptor-sample-using-Blazor-server-application).

N> You can refer to our [Blazor Gantt Chart](https://www.syncfusion.com/blazor-components/blazor-gantt-chart) feature tour page for its groundbreaking feature representations. You can also explore our [Blazor Gantt Chart example](https://blazor.syncfusion.com/demos/gantt-chart/default-functionalities?theme=bootstrap4) to know how to render and configure the Gantt.
