# Custom Binding

The [`SfDataManager`](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor~Syncfusion.Blazor.Data.SfDataManager.html) has custom adaptor support which allows you to perform manual operations on the data. This can be utilized for implementing custom data binding and editing operations in the Gantt component.

For implementing custom data binding in Gantt, the **DataAdaptor** class is used. This abstract class acts as a base class for the custom adaptor.

The **DataAdaptor** abstract class has both synchronous and asynchronous method signatures which can be overridden in the custom adaptor. Following are the method signatures present in this class,

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
    /// Performs Remove operation asynchronously..
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

```csharp
@using Syncfusion.Blazor.Gantt;
@using Syncfusion.Blazor.Data;
@using Syncfusion.Blazor;

<SfGantt TValue="TaskData" Height="450px" Width="1000px">
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
        public string Duration { get; set; }
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
                Random ran = new Random();
                string math = (ran.Next() % 3) == 0 ? "High" : (ran.Next() % 2) == 0 ? "Release Breaker" : "Critical";
                root++;
                int rootItem = gantt.Count + root + 1;
                gantt.Add(new TaskData() { TaskID = rootItem, TaskName = "Parent Task " + rootItem.ToString(), StartDate = new DateTime(1992, 06, 07), EndDate = new DateTime(1994, 08, 25), Progress = (ran.Next(10, 100)), ParentID = null, Duration = (ran.Next(1, 50)).ToString() });
                int parent = gantt.Count;
                for (var c = 0; c < 3; c++)
                {
                    root++;
                    string val = ((parent + c + 1) % 3 == 0) ? "Low" : "Critical";
                    int parn = parent + c + 1;
                    int iD = gantt.Count + root + 1;
                    gantt.Add(new TaskData() { TaskID = iD, TaskName = "Child Task " + iD.ToString(), StartDate = new DateTime(1992, 06, 07), EndDate = new DateTime(1994, 08, 25), Progress = (ran.Next(10, 100)), ParentID = rootItem, Duration = (ran.Next(1, 50)).ToString() });
                    if ((((parent + c + 1) % 3) == 0))
                    {
                        int immParent = gantt.Count;
                        for (var s = 0; s <= 1; s++)
                        {
                            root++;
                            gantt.Add(new TaskData() { TaskID = gantt.Count + root + 1, TaskName = "Sub Task " + (gantt.Count + root + 1).ToString(), StartDate = new DateTime(1992, 06, 07), EndDate = new DateTime(1994, 08, 25), Progress = (ran.Next(10, 100)), ParentID = iD, Duration = (ran.Next(1, 50)).ToString()});
                        }
                    }
                }
            }
        }
        return gantt;
    }

    // Implementing custom adaptor by extending the DataAdaptor class
    public class CustomAdaptor : DataAdaptor
    {
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
                DataSource = DataOperations.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
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

> If the **DataManagerRequest.RequiresCounts** value is **true**, then the Read/ReadAsync return value must be of **DataResult** with properties **Result** whose value is a collection of records and **Count** whose value is the total number of records. If the **DataManagerRequest.RequiresCounts** is **false**, then simply send the collection of records.
> If the Read/ReadAsync method is not overridden in the custom adaptor then it will be handled by the default read handler.

## Inject service into Custom Adaptor

If you want to inject some of your service into Custom Adaptor and use the service, then you can achieve your requirement by using below way.

Initially you need to add CustomAdaptor class as AddScoped in `StartUp.cs` file.

```csharp
    public void ConfigureServices(IServiceCollection services)
    {
        ...
        services.AddSingleton<TaskDataAccessLayer>();
        services.AddScoped<CustomAdaptor>();
        services.AddScoped<ServiceClass>();
    }
```

The following sample code demonstrates injecting service into Custom Adaptor,

```csharp
@using Syncfusion.Blazor.Gantt;
@using Syncfusion.Blazor.Data;
@using Syncfusion.Blazor;

<SfGantt TValue="TaskData" Height="450px" Width="1000px">
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
        public string Duration { get; set; }
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
                Random ran = new Random();
                string math = (ran.Next() % 3) == 0 ? "High" : (ran.Next() % 2) == 0 ? "Release Breaker" : "Critical";
                root++;
                int rootItem = gantt.Count + root + 1;
                gantt.Add(new TaskData() { TaskID = rootItem, TaskName = "Parent Task " + rootItem.ToString(), StartDate = new DateTime(1992, 06, 07), EndDate = new DateTime(1994, 08, 25), Progress = (ran.Next(10, 100)), ParentID = null, Duration = (ran.Next(1, 50)).ToString() });
                int parent = gantt.Count;
                for (var c = 0; c < 3; c++)
                {
                    root++;
                    string val = ((parent + c + 1) % 3 == 0) ? "Low" : "Critical";
                    int parn = parent + c + 1;
                    int iD = gantt.Count + root + 1;
                    gantt.Add(new TaskData() { TaskID = iD, TaskName = "Child Task " + iD.ToString(), StartDate = new DateTime(1992, 06, 07), EndDate = new DateTime(1994, 08, 25), Progress = (ran.Next(10, 100)), ParentID = rootItem, Duration = (ran.Next(1, 50)).ToString() });
                    if ((((parent + c + 1) % 3) == 0))
                    {
                        int immParent = gantt.Count;
                        for (var s = 0; s <= 1; s++)
                        {
                            root++;
                            gantt.Add(new TaskData() { TaskID = gantt.Count + root + 1, TaskName = "Sub Task " + (gantt.Count + root + 1).ToString(), StartDate = new DateTime(1992, 06, 07), EndDate = new DateTime(1994, 08, 25), Progress = (ran.Next(10, 100)), ParentID = iD, Duration = (ran.Next(1, 50)).ToString()});
                        }
                    }
                }
            }
        }
        return gantt;
    }

    // Implementing custom adaptor by extending the DataAdaptor class
    public class CustomAdaptor : DataAdaptor
    {
        //here you can inject your service
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
                DataSource = DataOperations.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
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

> While using batch editing in Gantt, use BatchUpdate/BatchUpdateAsync method to handle the corresponding CRUD operation

The following sample code demonstrates implementing CRUD operations for the custom bounded data,

```csharp
@using Syncfusion.Blazor.Gantt;
@using Syncfusion.Blazor.Data;
@using Syncfusion.Blazor;

<SfGantt TValue="TaskData" Height="450px" Width="1000px" AllowFiltering="true" AllowSorting="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel", "Search" })">
     <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GanttTaskFields Id="TaskID" Name="TaskName" StartDate="StartDate" EndDate="EndDate" Progress="Progress" Duration="Duration"  ParentID="ParentID">
    </GanttTaskFields>
     <GanttEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true"></GanttEditSettings>
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
        public string Duration { get; set; }
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
                Random ran = new Random();
                string math = (ran.Next() % 3) == 0 ? "High" : (ran.Next() % 2) == 0 ? "Release Breaker" : "Critical";
                root++;
                int rootItem = gantt.Count + root + 1;
                gantt.Add(new TaskData() { TaskID = rootItem, TaskName = "Parent Task " + rootItem.ToString(), StartDate = new DateTime(1992, 06, 07), EndDate = new DateTime(1994, 08, 25), Progress = (ran.Next(10, 100)), ParentID = null, Duration = (ran.Next(1, 50)).ToString() });
                int parent = gantt.Count;
                for (var c = 0; c < 3; c++)
                {
                    root++;
                    string val = ((parent + c + 1) % 3 == 0) ? "Low" : "Critical";
                    int parn = parent + c + 1;
                    int iD = gantt.Count + root + 1;
                    gantt.Add(new TaskData() { TaskID = iD, TaskName = "Child Task " + iD.ToString(), StartDate = new DateTime(1992, 06, 07), EndDate = new DateTime(1994, 08, 25), Progress = (ran.Next(10, 100)), ParentID = rootItem, Duration = (ran.Next(1, 50)).ToString() });
                    if ((((parent + c + 1) % 3) == 0))
                    {
                        int immParent = gantt.Count;
                        for (var s = 0; s <= 1; s++)
                        {
                            root++;
                            gantt.Add(new TaskData() { TaskID = gantt.Count + root + 1, TaskName = "Sub Task " + (gantt.Count + root + 1).ToString(), StartDate = new DateTime(1992, 06, 07), EndDate = new DateTime(1994, 08, 25), Progress = (ran.Next(10, 100)), ParentID = iD, Duration = (ran.Next(1, 50)).ToString()});
                        }
                    }
                }
            }
        }
        return gantt;
    }

    // Implementing custom adaptor by extending the DataAdaptor class
    public class CustomAdaptor : DataAdaptor
    {
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
                DataSource = DataOperations.PerformFiltering(DataSource, dm.Where, dm.Where[0].Operator);
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
            GanttData.Insert(0, value as TaskData);
            return value;
        }

        // Performs Remove operation
        public override object Remove(DataManager dm, object value, string keyField, string key)
        {
            GanttData.Remove(GanttData.Where(or => or.TaskID == int.Parse(value.ToString())).FirstOrDefault());
            return value;
        }

        // Performs Update operation
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

> `Note:` You can refer to our [`Blazor Gantt Chart`](https://www.syncfusion.com/blazor-components/blazor-gantt-chart) feature tour page for its groundbreaking feature representations. You can also explore our [`Blazor Gantt Chart example`](https://blazor.syncfusion.com/demos/gantt-chart/default-functionalities?theme=bootstrap4) to knows how to render and configure the gantt.