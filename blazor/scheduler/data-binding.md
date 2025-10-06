---
layout: post
title: Data Binding in Blazor Scheduler Component | Syncfusion
description: This section includes the data binding topics explaining how to bind various data sources to Syncfusion Blazor Scheduler component using DataManager adaptors.
platform: Blazor
control: Scheduler
documentation: ug
---

# Data Binding in Blazor Scheduler Component

The Scheduler component utilizes [`DataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html) to handle data binding, supporting both RESTful data service binding and direct data source collections. The [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEventSettings-1.html#Syncfusion_Blazor_Schedule_ScheduleEventSettings_1_DataSource) property within `ScheduleEventSettings` can be assigned either an instance of `DataManager` or a list of data source collections.

The Scheduler supports the following primary methods for data binding:
*   List Binding
*   Remote Data Binding

Please take a moment to watch this video to learn about data binding in the Blazor Scheduler.

{% youtube
"youtube:https://www.youtube.com/watch?v=EwfxPrqxma8"%}

## List Binding

To bind data from a local list to the Scheduler, simply assign a collection of data objects (implementing `IEnumerable`) to the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEventSettings-1.html#Syncfusion_Blazor_Schedule_ScheduleEventSettings_1_DataSource) property within the `<ScheduleEventSettings>` tag. The list data source can also be provided as an instance of [`SfDataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html) or by directly using the `<SfDataManager>` component.

```cshtml
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" SelectedDate="@(new DateTime(2020, 2, 12))">
    <ScheduleEventSettings DataSource="@DataSource"></ScheduleEventSettings>
</SfSchedule>

@code{
    List<AppointmentData> DataSource = new List<AppointmentData>
    {
        new AppointmentData { Id = 1, Subject = "Testing", StartTime = new DateTime(2020, 2, 13, 9, 30, 0) , EndTime = new DateTime(2020, 2, 13, 10, 30, 0)},
        new AppointmentData { Id = 2, Subject = "Conference", StartTime = new DateTime(2020, 2, 11, 10, 30, 0) , EndTime = new DateTime(2020, 2, 11, 12, 0, 0)},
        new AppointmentData { Id = 3, Subject = "Meeting", StartTime = new DateTime(2020, 2, 9, 9, 30, 0) , EndTime = new DateTime(2020, 2, 9, 11, 30, 0)},
        new AppointmentData { Id = 4, Subject = "Vacation", StartTime = new DateTime(2020, 2, 14, 11, 30, 0) , EndTime = new DateTime(2020, 2, 14, 13, 0, 0)}
    };
    public class AppointmentData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public bool IsAllDay { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/rNVyMXtdUlEzkzNP?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
![List data in Blazor Scheduler](images/list-data.png)

N> By default, `DataManager` uses `BlazorAdaptor` for binding local data.

> Different field names can be bound to the default event fields, and additional `custom fields` to the event object collection which can be referred [here](./appointments#event-fields).

### ExpandoObject Binding

The Scheduler is a generic component that is strongly bound to a model type. However, for scenarios where the model type is unknown at compile-time or runtime, **ExpandoObject** binding can be used. This allows data to be bound as a list of dynamic objects.

**ExpandoObject** implements the `IDictionary<string, object>` interface, enabling the addition of properties and values dynamically at runtime, similar to a dictionary. This provides a flexible way to bind data without requiring a predefined class or strict data structure, particularly useful for data sources with varying structures.

To bind data using `ExpandoObject`, create a list of `ExpandoObject` instances and set it as the `DataSource` property of the Scheduler's `ScheduleEventSettings` component. The Scheduler supports all data operations and editing functionalities with `ExpandoObject` binding.

```csharp
@using System.Dynamic
@using Syncfusion.Blazor.Schedule
<SfSchedule TValue="ExpandoObject" @bind-SelectedDate="@CurrentDate" Width="100%" Height="550px">
    <ScheduleEventSettings DataSource="@EventsCollection" AllowEditFollowingEvents="true"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>
@code {
    DateTime CurrentDate = new DateTime(2021, 8, 10);
    public List<ExpandoObject> EventsCollection = new List<ExpandoObject>() { };
    protected override void OnInitialized()
    {
        DateTime scheduleStart = new DateTime(2021, 8, 8, 10, 0, 0);
        EventsCollection = Enumerable.Range(1, 5).Select((x) =>
        {
            scheduleStart = scheduleStart.AddDays(1);
            dynamic d = new ExpandoObject();
            d.Id = 1000 + x;
            d.Subject = (new string[] { "Project Discussion", "Work Flow Analysis", "Report", "Meeting", "Project Demo" })[new Random().Next(5)];
            d.StartTime = scheduleStart;
            d.EndTime = scheduleStart.AddHours(1);
            d.IsAllDay = false;
            d.RecurrenceRule = null;
            d.RecurrenceException = null;
            d.RecurrenceID = null;
            return d;
        }).Cast<ExpandoObject>().ToList<ExpandoObject>();
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BXVIMjjxguCLKwbx?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### DynamicObject Binding

**DynamicObject** binding offers another method for data binding when the model type is unknown at compile time. This approach leverages the `dynamic` keyword, allowing variables to hold objects that can dynamically add or manage properties at runtime.

To bind data using `DynamicObject`, create a list of custom `DynamicObject` instances and set it as the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEventSettings-1.html#Syncfusion_Blazor_Schedule_ScheduleEventSettings_1_DataSource) property of the Scheduler's `ScheduleEventSettings` component. This enables the use of the Scheduler's built-in data operations and editing features with dynamically behaving objects.

**DynamicObject** implements the `IDynamicMetaObjectProvider` interface, which allows overriding member access operations like `GetMember` and `SetMember` for custom logic. This is particularly useful for scenarios where object behavior is determined at runtime.

N> The [`GetDynamicMemberNames`](https://learn.microsoft.com/en-us/dotnet/api/system.dynamic.dynamicobject.getdynamicmembernames?view=net-7.0) method of DynamicObject class must be overridden and return the property names to perform data operation and editing while using DynamicObject.

```csharp
@using System.Dynamic
@using System.Text.Json
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="DynamicDictionary" @bind-SelectedDate="@CurrentDate" Width="100%" Height="550px">
    <ScheduleEventSettings DataSource="@EventsCollection"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>
@code {
    DateTime CurrentDate = new DateTime(2021, 8, 10);
    public List<DynamicDictionary> EventsCollection = new List<DynamicDictionary>() { };
    protected override void OnInitialized()
    {
        DateTime scheduleStart = new DateTime(2021, 8, 8, 10, 0, 0);
        EventsCollection = Enumerable.Range(1, 5).Select((x) =>
        {
            scheduleStart = scheduleStart.AddDays(1);
            dynamic d = new DynamicDictionary();
            d.Id = 1000 + x;
            d.Subject = (new string[] { "Project Discussion", "Work Flow Analysis", "Report", "Meeting", "Project Demo" })[new Random().Next(5)];
            d.StartTime = scheduleStart;
            d.EndTime = scheduleStart.AddHours(1);
            d.RecurrenceRule = null;
            d.RecurrenceException = null;
            d.RecurrenceID = null;
            return d;
        }).Cast<DynamicDictionary>().ToList<DynamicDictionary>();
    }
    public class DynamicDictionary : System.Dynamic.DynamicObject
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
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LXLIstjRqEMwIAdI?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

## ObservableCollection

Utilizing [`ObservableCollection`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1?view=net-7.0) (a dynamic data collection) provides notifications when items are added, removed, or moved. This collection implements [`INotifyCollectionChanged`](https://learn.microsoft.com/en-us/dotnet/api/system.collections.specialized.inotifycollectionchanged?view=net-7.0), informing the Scheduler of dynamic changes such as additions, removals, moves, or clearing of items. Furthermore, the `AppointmentData` class implements [`INotifyPropertyChanged`](https://learn.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=net-7.0), which notifies the UI when a property value (e.g., `Subject`) has changed on the client side.

Here, AppointmentData class implements the interface of **INotifyPropertyChanged** and it raises the event when Subject property value was changed.

```csharp
@using Syncfusion.Blazor.Schedule
@using Syncfusion.Blazor.Buttons
@using System.Collections.ObjectModel
@using System.ComponentModel

<SfButton @onclick="AddRecord">Add Data</SfButton>
<SfButton @onclick="UpdateRecord" Disabled="ObservableData.Count == 0">Update Data</SfButton>
<SfButton @onclick="DeleteRecord" Disabled="ObservableData.Count == 0">Delete Data</SfButton>

<SfSchedule TValue="AppointmentData" @bind-SelectedDate="@CurrentDate" Width="100%" Height="550px">
    <ScheduleEventSettings DataSource="@ObservableData"></ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code{
    DateTime CurrentDate = new DateTime(2020, 3, 10);
    public ObservableCollection<AppointmentData> ObservableData { get; set; }
    List<AppointmentData> EventsCollection = new List<AppointmentData>();
    int uniqueid = 1;
    protected override void OnInitialized()
    {
        EventsCollection = Enumerable.Range(1, 4).Select(x => new AppointmentData()
        {
            Id = x,
            Subject = (new string[] { "Project Discussion", "Work Flow Analysis", "Report", "Meeting", "Project Demo" })[new Random().Next(5)],
            StartTime = new DateTime(2020, 3, 8 + x, 9, 0, 0),
            EndTime = new DateTime(2020, 3, 8 + x, 11, 0, 0)
        }).ToList();
        ObservableData = new ObservableCollection<AppointmentData>(EventsCollection);
    }
    public void AddRecord()
    {
        uniqueid++;
        ObservableData.Add(new AppointmentData() { Id = uniqueid, Subject = "Meeting", StartTime = new DateTime(2020, 3, 13, 9, 0, 0), EndTime = new DateTime(2020, 3, 13, 11, 0, 0) });
    }
    public void DeleteRecord()
    {
        if (ObservableData.Count != 0)
        {
            ObservableData.Remove(ObservableData.First());
        }
    }
    public void UpdateRecord()
    {
        if (ObservableData.Count != 0)
        {
            var data = ObservableData.First();
            data.Subject = "Event Updated";
        }
    }
    public class AppointmentData : INotifyPropertyChanged
    {
        public int Id { get; set; }
        private string subject { get; set; }
        public string Subject
        {
            get { return subject; }
            set
            {
                this.subject = value;
                NotifyPropertyChanged("Subject");
            }
        }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public bool IsAllDay { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
        public string StartTimezone { get; set; }
        public string EndTimezone { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LXLIMjXdAOVvBGfh?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}
![Blazor Scheduler](images/observablecollectiondata.png)

## Custom Binding

It is possible to create a custom `DataAdaptor` by extending the built-in `DataAdaptor` class. This allows for binding data from a custom service and performing CRUD operations using the methods of the [DataAdaptor](https://blazor.syncfusion.com/documentation/data/custom-binding) abstract class.

The following example demonstrates the usage of a custom adaptor to bind data with a custom service. The `CustomAdaptor` overrides methods like `ReadAsync`, `InsertAsync`, `UpdateAsync`, and `RemoveAsync` to interact with a local `List<AppointmentData>`.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Schedule
@using Syncfusion.Blazor.Data

<SfSchedule TValue="AppointmentData" Width="100%" Height="650px" SelectedDate="@(new DateTime(2020, 1, 9))">
    <ScheduleResources>
        <ScheduleResource TItem="ResourceData" TValue="int" DataSource="@ProjectData" Field="ProjectId" Title="Choose Project" Name="Projects" TextField="Text" IdField="Id" ColorField="Color">
        </ScheduleResource>
    </ScheduleResources>
    <ScheduleEventSettings TValue="AppointmentData">
        <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    </ScheduleEventSettings>
</SfSchedule>

@code {
    public class CustomAdaptor : DataAdaptor
    {
        List<AppointmentData> EventData = DataList();
        public async override Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null)
        {
            await Task.Delay(100); //To mimic asynchronous operation, we delayed this operation using Task.Delay
            return dataManagerRequest.RequiresCounts ? new DataResult() { Result = EventData, Count = EventData.Count() } : (object)EventData;
        }
        public async override Task<object> InsertAsync(DataManager dataManager, object data, string key)
        {
            await Task.Delay(100); //To mimic asynchronous operation, we delayed this operation using Task.Delay
            EventData.Insert(0, data as AppointmentData);
            return data;
        }
        public async override Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key)
        {
            await Task.Delay(100); //To mimic asynchronous operation, we delayed this operation using Task.Delay
            var val = (data as AppointmentData);
            var appointment = EventData.Where((AppointmentData) => AppointmentData.Id == val.Id).FirstOrDefault();
            if (appointment != null)
            {
                appointment.Id = val.Id;
                appointment.Subject = val.Subject;
                appointment.StartTime = val.StartTime;
                appointment.EndTime = val.EndTime;
                appointment.Location = val.Location;
                appointment.Description = val.Description;
                appointment.IsAllDay = val.IsAllDay;
                appointment.ProjectId = val.ProjectId;
                appointment.RecurrenceException = val.RecurrenceException;
                appointment.RecurrenceID = val.RecurrenceID;
                appointment.RecurrenceRule = val.RecurrenceRule;
            }
            return data;
        }
        public async override Task<object> RemoveAsync(DataManager dataManager, object data, string keyField, string key) //triggers on appointment deletion through public method DeleteEvent
        {
            await Task.Delay(100); //To mimic asynchronous operation, we delayed this operation using Task.Delay
            int value = (int)data;
            EventData.Remove(EventData.Where((AppointmentData) => AppointmentData.Id == value).FirstOrDefault());
            return data;
        }
        public async override Task<object> BatchUpdateAsync(DataManager dataManager, object changedRecords, object addedRecords, object deletedRecords, string keyField, string key, int? dropIndex)
        {
            await Task.Delay(100); //To mimic asynchronous operation, we delayed this operation using Task.Delay
            object records = deletedRecords;
            List<AppointmentData> deleteData = deletedRecords as List<AppointmentData>;
            foreach (var data in deleteData)
            {
                EventData.Remove(EventData.Where((AppointmentData) => AppointmentData.Id == data.Id).FirstOrDefault());
            }
            List<AppointmentData> addData = addedRecords as List<AppointmentData>;
            foreach (var data in addData)
            {
                EventData.Insert(0, data as AppointmentData);
                records = addedRecords;
            }
            List<AppointmentData> updateData = changedRecords as List<AppointmentData>;
            foreach (var data in updateData)
            {
                var val = (data as AppointmentData);
                var appointment = EventData.Where((AppointmentData) => AppointmentData.Id == val.Id).FirstOrDefault();
                if (appointment != null)
                {
                    appointment.Id = val.Id;
                    appointment.Subject = val.Subject;
                    appointment.StartTime = val.StartTime;
                    appointment.EndTime = val.EndTime;
                    appointment.Location = val.Location;
                    appointment.Description = val.Description;
                    appointment.IsAllDay = val.IsAllDay;
                    appointment.ProjectId = val.ProjectId;
                    appointment.RecurrenceException = val.RecurrenceException;
                    appointment.RecurrenceID = val.RecurrenceID;
                    appointment.RecurrenceRule = val.RecurrenceRule;
                }
                records = changedRecords;
            }
            return records;
        }
    }
    private static List<AppointmentData> DataList()
    {
        List<AppointmentData> eventDatas = new List<AppointmentData>
        {
            new AppointmentData { Id = 1, Subject = "Meeting", StartTime = new DateTime(2020, 1, 5, 10, 0, 0) , EndTime = new DateTime(2020, 1, 5, 11, 0, 0), ProjectId = 1, RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=5;"},
            new AppointmentData { Id = 2, Subject = "Project Discussion", StartTime = new DateTime(2020, 1, 6, 11, 30, 0) , EndTime = new DateTime(2020, 1, 6, 13, 0, 0), ProjectId = 2},
            new AppointmentData { Id = 3, Subject = "Work Flow Analysis", StartTime = new DateTime(2020, 1, 7, 12, 0, 0) , EndTime = new DateTime(2020, 1, 7, 13, 0, 0), ProjectId = 2, RecurrenceRule = "FREQ=DAILY;INTERVAL=1;COUNT=3;"},
            new AppointmentData { Id = 4, Subject = "Report", StartTime = new DateTime(2020, 1, 10, 11, 30, 0) , EndTime = new DateTime(2020, 1, 10, 13, 0, 0), ProjectId = 2}
        };
        return eventDatas;
    }
    List<ResourceData> ProjectData = ResourceList();
    private static List<ResourceData> ResourceList()
    {
        List<ResourceData> resourceDatas = new List<ResourceData>
        {
            new ResourceData { Text = "PROJECT 1", Id = 1, Color = "#cb6bb2" },
            new ResourceData { Text = "PROJECT 2", Id = 2, Color = "#56ca85" }
        };
        return resourceDatas;
    }
    public class AppointmentData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Location { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Description { get; set; }
        public bool IsAllDay { get; set; }
        public string RecurrenceRule { get; set; }
        public string RecurrenceException { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
        public int ProjectId { get; set; }
    }
    public class ResourceData
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Color { get; set; }
    }
}
```

N> You can find the complete procedures to perform CRUD actions with the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Scheduler using CustomAdaptor [here](https://github.com/SyncfusionExamples/Blazor-Scheduler-CRUD-using-custom-adaptor).

## Remote Data Binding

Any type of remote data services can be bound to the Scheduler. To achieve this, provide the service URL to the `Url` option of `SfDataManager` within the `<ScheduleEventSettings>` tag.

### Binding with OData Services

[OData](https://www.odata.org/documentation/odata-version-3-0/) ((Open Data Protocol)) is a widely used protocol for creating and consuming RESTful APIs over various transport protocols such as HTTP, HTTPS, and others. It offers a standardized way for creating, retrieving, updating, and deleting data across various platforms and devices. OData provides a uniform way for interacting with data, which simplifies the task of developing and consuming RESTful APIs.

Data can be retrieved from an OData service using `SfDataManager`. Refer to the following code example for remote data binding using an OData service.


```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Schedule
@using Syncfusion.Blazor.Data

<SfSchedule TValue="Restful_Crud.Models.EventData" Height="550px" SelectedDate="@(new DateTime(2020, 3, 11))">
    <ScheduleEventSettings TValue="Restful_Crud.Models.EventData" Query="@QueryData">
        <SfDataManager Url="http://localhost:25255/odata" Adaptor="Adaptors.ODataAdaptor"></SfDataManager>
    </ScheduleEventSettings>
</SfSchedule>

@code{
    public Query QueryData = new Query().From("EventDatas");
}
```

### Binding with OData v4 Services

[ODataV4](https://www.odata.org/documentation/) is the latest version of the OData protocol, which offers more features and better performance than its predecessors. It provides support for advanced query options, data validation, and data shaping. The ODataV4 protocol is based on the JSON format, which makes it more lightweight and easier to use.

Refer to the following code example to retrieve the data from ODataV4 service using the DataManager. To connect with ODataV4 service end points, it is necessary to make use of `ODataV4Adaptor` within `DataManager`.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Schedule
@using Syncfusion.Blazor.Data

<SfSchedule TValue="Restful_Crud.Models.EventData" Height="550px" SelectedDate="@(new DateTime(2020, 3, 11))">
    <ScheduleEventSettings TValue="Restful_Crud.Models.EventData" Query="@QueryData">
        <SfDataManager Url="http://localhost:25255/odata" Adaptor="Adaptors.ODataV4Adaptor"></SfDataManager>
    </ScheduleEventSettings>
</SfSchedule>

@code{
    public Query QueryData = new Query().From("EventDatas");
}
```

N> A working sample demonstrating integration with OData can be found [here](https://github.com/SyncfusionExamples/Blazor-Scheduler-CRUD-using-ODATA-adaptor).

### Filtering Events Using the In-built Query

To enable server-side filtering operations based on predetermined conditions, the [`IncludeFiltersInQuery`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEventSettings-1.html#Syncfusion_Blazor_Schedule_ScheduleEventSettings_1_IncludeFiltersInQuery) API can be set to `true`. This constructs a filter query using the start date, end date, and recurrence rule, allowing the request to be filtered accordingly.

This method significantly improves the component's performance by reducing the amount of data transferred to the client side, thereby enhancing efficiency and responsiveness. However, it is important to consider the potential for longer query strings, which might exceed maximum URL lengths or server limitations.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data;
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" @bind-SelectedDate="@currentDate">
    <ScheduleEventSettings TValue="AppointmentData" Query="@QueryData" IncludeFiltersInQuery="true">
        <ScheduleViews>
            <ScheduleView Option="View.Month"></ScheduleView>
        </ScheduleViews>
        <SfDataManager Url="https://services.odata.org/V4/Northwind/Northwind.svc/Orders/" Adaptor="Adaptors.ODataV4Adaptor">
        </SfDataManager>
        <ScheduleField Id="Id">
            <FieldSubject Name="ShipName"></FieldSubject>
            <FieldLocation Name="ShipCountry"></FieldLocation>
            <FieldDescription Name="ShipAddress"></FieldDescription>
            <FieldStartTime Name="OrderDate"></FieldStartTime>
            <FieldEndTime Name="RequiredDate"></FieldEndTime>
            <FieldRecurrenceRule Name="ShipRegion"></FieldRecurrenceRule>
        </ScheduleField>
    </ScheduleEventSettings>
</SfSchedule>

@code {

    DateTime currentDate = new DateTime(1996, 7, 9);
    public Query QueryData = new Query();

    public class AppointmentData
    {
        public int Id { get; set; }
        public string? ShipName { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime RequiredDate { get; set; }
        public string? ShipCountry { get; set; }
        public string? ShipAddress { get; set; }
        public string? ShipRegion { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BZLyCNjHqazFgUHF?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

The following image represents how the parameters are passed using ODataV4 filter.
![ODataV4 filter](images/blazor-odatav4-filter.jpg)

### Web API Adaptor

Web API data can be bound to the Scheduler using [`WebApiAdaptor`](https://blazor.syncfusion.com/documentation/data/adaptors#web-api-adaptor). The following sample code demonstrates binding remote services to the Scheduler component.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data;
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" @bind-SelectedDate="@currentDate" Readonly="true">
    <ScheduleEventSettings TValue="AppointmentData" >
        <ScheduleViews>
            <ScheduleView Option="View.Month"></ScheduleView>
        </ScheduleViews>
       <SfDataManager Url="https://blazor.syncfusion.com/services/production/api/schedule" Adaptor="Adaptors.WebApiAdaptor">
       </SfDataManager>
    </ScheduleEventSettings>
</SfSchedule>

@code {
    DateTime currentDate = new DateTime(2023, 1, 6);

    public class AppointmentData
    {
            public int Id { get; set; }
            public string Subject { get; set; }
            public string Location { get; set; }
            public string Description { get; set; }
            public DateTime StartTime { get; set; }
            public DateTime EndTime { get; set; }
            public Nullable<bool> IsAllDay { get; set; }
            public string CategoryColor { get; set; }
            public string RecurrenceRule { get; set; }
            public Nullable<int> RecurrenceID { get; set; }
            public Nullable<int> FollowingID { get; set; }
            public string RecurrenceException { get; set; }
            public string StartTimezone { get; set; }
            public string EndTimezone { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/LDrosjXdUuSITIaj?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Url Adaptor

The [`UrlAdaptor`](https://blazor.syncfusion.com/documentation/data/adaptors#url-adaptor) of `SfDataManager` is used to bind remote data sources. During the initial load of the Scheduler, data is fetched from the remote service via the  [Url](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Url) property of `SfDataManager` and bound to the Scheduler.

CRUD operations in the Scheduler can be mapped to server-side controller actions by using the properties [InsertUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_InsertUrl), [RemoveUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_RemoveUrl), [UpdateUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_UpdateUrl), and [CrudUrl](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_CrudUrl).

*   `InsertUrl` – Specifies the URL for a single insertion operation on the server-side.
*   `UpdateUrl` – Specifies the URL for updating a single data record on the server-side.
*   `RemoveUrl` – Specifies the URL for removing a single data record on the server-side.
*   `CrudUrl` – Specifies the URL for performing bulk data operations (batch CRUD) on the server-side.

The following sample code demonstrates binding data to the Scheduler component through the SfDataManager using UrlAdaptor.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data;
@using Syncfusion.Blazor.Schedule
@using Url_Adaptor.Data
@using Url_Adaptor.Models
@using Url_Adaptor.Pages

<SfSchedule TValue="Event" Height="550px" @bind-SelectedDate="@currentDate" AllowMultiDrag="true">
    <ScheduleEventSettings TValue="Event">
        <SfDataManager Url="api/Default" UpdateUrl="/api/Default/Update" RemoveUrl="/api/Default/Delete" InsertUrl="/api/Default/Add" CrudUrl="/api/Default/Batch" Adaptor="Adaptors.UrlAdaptor">
        </SfDataManager>
    </ScheduleEventSettings>
    <ScheduleViews>
        <ScheduleView Option="View.Month"></ScheduleView>
    </ScheduleViews>
</SfSchedule>

@code {
    DateTime currentDate = new DateTime(2022, 12, 6);
}
```

The server-side controller code to handle the CRUD operations is as follows.

```cshtml
namespace Url_Adaptor.Controller
{
    [ApiController]
    public class DefaultController : ControllerBase
    {
        private readonly EventsContext dbContext;


        public DefaultController(EventsContext dbContext)
        {
            this.dbContext = dbContext;

            if (this.dbContext.Events.Count() == 0)
            {
                foreach (var b in DataSource.GetEvents())
                {
                    dbContext.Events.Add(b);
                }

                dbContext.SaveChanges();
            }
        }

        [HttpPost]
        [Route("api/[controller]")]
        public IActionResult Get()
        {
            var events = dbContext.Events.ToList();
            return Ok(events);
        }


        [HttpPost]
        [Route("api/Default/Add")]
        public void Add([FromBody] CRUDModel<Event> args)
        {
            dbContext.Events.Add(args.Value);
            dbContext.SaveChangesAsync();
        }

        [HttpPost]
        [Route("api/Default/Update")]
        public async Task Update(CRUDModel<Event> args)
        {
            var entity = await dbContext.Events.FindAsync(args.Value.Id);
            if (entity != null)
            {
                dbContext.Entry(entity).CurrentValues.SetValues(args.Value);
                await dbContext.SaveChangesAsync();
            }
        }

        [HttpPost]
        [Route("api/Default/Delete")]
        public async Task Delete(CRUDModel<Event> args)
        {
            var key = Convert.ToInt32(Convert.ToString(args.Key));
            var app = dbContext.Events.Find(key);
            if (app != null)
            {
                dbContext.Events.Remove(app);
                await dbContext.SaveChangesAsync();
            }
        }

        [HttpPost]
        [Route("api/Default/Batch")]
        public async Task Batch([FromBody] CRUDModel<Event> args)
        {
            if (args.Changed.Count > 0)
            {
                foreach (Event appointment in args.Changed)
                {
                    var entity = await dbContext.Events.FindAsync(appointment.Id);
                    if (entity != null)
                    {
                        dbContext.Entry(entity).CurrentValues.SetValues(appointment);
                    }
                }
            }
            if (args.Added.Count > 0)
            {
                foreach (Event appointment in args.Added)
                {
                    dbContext.Events.Add(appointment);

                }
            }
            if (args.Deleted.Count > 0)
            {
                foreach (Event appointment in args.Deleted)
                {
                    var app = dbContext.Events.Find(appointment.Id);
                    if (app != null)
                    {
                        dbContext.Events.Remove(app);
                    }
                }
            }
            await dbContext.SaveChangesAsync();
        }
    }
}
```

### Sending Additional Parameters to the Server

To send an additional custom parameter to the server-side post, make use of the `AddParams` method of [`Query`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEventSettings-1.html#Syncfusion_Blazor_Schedule_ScheduleEventSettings_1_Query). Now, assign this [`Query`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEventSettings-1.html#Syncfusion_Blazor_Schedule_ScheduleEventSettings_1_Query) object with additional parameters to the [`Query`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEventSettings-1.html#Syncfusion_Blazor_Schedule_ScheduleEventSettings_1_Query) property of Scheduler.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Schedule
@using Syncfusion.Blazor.Data

<SfSchedule TValue="Restful_Crud.Models.EventData" Height="550px" SelectedDate="@(new DateTime(2020, 3, 11))">
    <ScheduleEventSettings TValue="Restful_Crud.Models.EventData" Query="@QueryData">
        <SfDataManager Url="http://localhost:25255/odata" Adaptor="Adaptors.ODataV4Adaptor"></SfDataManager>
    </ScheduleEventSettings>
</SfSchedule>

@code{
    public Query QueryData = new Query().From("EventDatas").AddParams("Readonly", true);
}
```

The value passed to the additional parameter is shown in the following image.

![Passing Additional Parameters in Blazor Scheduler](./images/blazor-scheduler-additional-parameters.png)

N> The parameters added using the [`Query`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEventSettings-1.html#Syncfusion_Blazor_Schedule_ScheduleEventSettings_1_Query) property will be sent along with the data request sent to the server on every scheduler actions.

### Authorization and Authentication

It is common to have authorization configured on the server to prevent anonymous access to data services. `SfDataManager` can consume data from such protected remote services by including the proper bearer token in the request. The access token or bearer token can be utilized by `SfDataManager` in one of the following ways:

*   **Using a pre-configured `HttpClient`:** Register a pre-configured `HttpClient` with the access token or an authentication message handler before calling `AddSyncfusionBlazor()` in `Program.cs`. This ensures that `SfDataManager` uses the already configured `HttpClient` instead of creating its own.
*  **Setting access token in `HttpClient.DefaultRequestHeaders`:** Inject `HttpClient` into the Blazor component and set the access token in `DefaultRequestHeaders`.

```csharp

@inject HttpClient _httpClient

. . . .

@code {

    . . .

    protected override async Task OnInitializedAsync()
    {
        . . . .
        _httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {tokenValue}");

        await base.OnInitializedAsync();
    }
}
```

* Setting the access token in the **Headers** property of the **SfDataManager**. See [here](#setting-custom-headers) for adding headers.

Getting the bearer token may vary with access token providers. More information on configuring HttpClient with authentication can be found on the official page [here](https://learn.microsoft.com/en-us/aspnet/core/blazor/security/webassembly/additional-scenarios?view=aspnetcore-7.0).


### Setting Custom Headers

To add custom headers to the data request, use the [Headers](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DataManager.html#Syncfusion_Blazor_DataManager_Headers) property of the [SfDataManager](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html).

The following sample code demonstrates adding custom headers to the `SfDataManager` request,

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data;
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="AppointmentData" Height="550px" @bind-SelectedDate="@currentDate" Readonly="true">
    <ScheduleEventSettings TValue="AppointmentData">
        <ScheduleViews>
            <ScheduleView Option="View.Month"></ScheduleView>
        </ScheduleViews>
        <SfDataManager Headers=@HeaderData Url="https://blazor.syncfusion.com/services/production/api/schedule" Adaptor="Adaptors.WebApiAdaptor">
        </SfDataManager>
    </ScheduleEventSettings>
</SfSchedule>

@code {
    DateTime currentDate = new DateTime(2023, 1, 6);
    private IDictionary<string, string> HeaderData = new Dictionary<string, string>();

    public class AppointmentData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Nullable<bool> IsAllDay { get; set; }
        public string CategoryColor { get; set; }
        public string RecurrenceRule { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
        public Nullable<int> FollowingID { get; set; }
        public string RecurrenceException { get; set; }
        public string StartTimezone { get; set; }
        public string EndTimezone { get; set; }
    }
}
```

{% previewsample "https://blazorplayground.syncfusion.com/embed/VthysjZnqYRnFOwi?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" %}

### Handling HTTP Errors

During server interaction from the Scheduler, sometimes server-side exceptions might occur. These error messages or exception details can be acquired in client-side using the [OnActionFailure](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEvents-1.html#Syncfusion_Blazor_Schedule_ScheduleEvents_1_OnActionFailure) event.

The argument passed to the [OnActionFailure](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEvents-1.html#Syncfusion_Blazor_Schedule_ScheduleEvents_1_OnActionFailure) event contains the error details returned from the server.

The following sample code demonstrates notifying user when server-side exception has occurred,

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data;
@using Syncfusion.Blazor.Schedule

<span class="error">@ErrorDetails</span>

<SfSchedule TValue="AppointmentData" Height="550px" @bind-SelectedDate="@currentDate" Readonly="true">
    <ScheduleEventSettings TValue="AppointmentData">
        <ScheduleEvents TValue="AppointmentData" OnActionFailure="@ActionFailure"></ScheduleEvents>
        <ScheduleViews>
            <ScheduleView Option="View.Month"></ScheduleView>
        </ScheduleViews>
        <SfDataManager Url="https://some.com/invalidUrl" Adaptor=" Adaptors.WebApiAdaptor">
        </SfDataManager>
    </ScheduleEventSettings>
</SfSchedule>

<style>
    .error {
        color: red;
    }
</style>

@code {
    DateTime currentDate = new DateTime(2023, 1, 6);
    public string ErrorDetails = "";

    public class AppointmentData
    {
        public int Id { get; set; }
        public string Subject { get; set; }
        public string Location { get; set; }
        public string Description { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public Nullable<bool> IsAllDay { get; set; }
        public string CategoryColor { get; set; }
        public string RecurrenceRule { get; set; }
        public Nullable<int> RecurrenceID { get; set; }
        public Nullable<int> FollowingID { get; set; }
        public string RecurrenceException { get; set; }
        public string StartTimezone { get; set; }
        public string EndTimezone { get; set; }
    }

    public void ActionFailure(ActionEventArgs<AppointmentData> args)
    {
        this.ErrorDetails = "Server exception: 404 Not found";
        StateHasChanged();
    }
}
```
## Load on Demand

The Scheduler supports implementing data loading on demand, which helps minimize data transfer over the network, particularly with large volumes of data. This is achieved by filtering appointments on the server side based on the currently requested `StartDate` and `EndDate`.

```cshtml
        public async Task<List<AppointmentData>> Get(DateTime StartDate, DateTime EndDate)
        {
            return await _appointmentDataContext.AppointmentDatas.Where(evt => evt.StartTime >= StartDate && evt.EndTime <= EndDate).ToListAsync();
        }
```

The following code example describes the behavior of the Load on demand using custom adaptor.

{% tabs %}

{% highlight razor %}

@using Syncfusion.Blazor.Schedule
@using Syncfusion.Blazor.Data
@using syncfusion_blazor_app.Data

<SfSchedule TValue="AppointmentData" Width="100%" Height="600px" @bind-SelectedDate="@SelectedDate">
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
    <ScheduleEventSettings TValue="AppointmentData">
        <SfDataManager AdaptorInstance="@typeof(AppointmentDataAdaptor)" Adaptor="Adaptors.CustomAdaptor">
        </SfDataManager>
    </ScheduleEventSettings>
</SfSchedule>

@code {
    DateTime SelectedDate { get; set; } = new DateTime(2023, 5, 10);
}

{% endhighlight %}

{% highlight c# tabtitle="AppointmentDataAdaptor.cs" %}

using Syncfusion.Blazor;
using Syncfusion.Blazor.Data;

namespace syncfusion_blazor_app.Data {
    public class AppointmentDataAdaptor : DataAdaptor {
        private readonly AppointmentDataService _appService;
        public AppointmentDataAdaptor(AppointmentDataService appService) {
            _appService = appService;
        }

        List<AppointmentData>? EventData;
        public override async Task<object> ReadAsync(DataManagerRequest dataManagerRequest, string key = null) {
            System.Collections.Generic.IDictionary<string, object> Params = dataManagerRequest.Params;
            DateTime start =  (DateTime)Params["StartDate"];
            DateTime end = (DateTime)Params["EndDate"];
            EventData = await _appService.Get(start, end);
            return dataManagerRequest.RequiresCounts ? new DataResult() { Result = EventData, Count = EventData.Count() } : EventData;
        }
        public async override Task<object> InsertAsync(DataManager dataManager, object data, string key) {
            await _appService.Insert(data as AppointmentData);
            return data;
        }
        public async override Task<object> UpdateAsync(DataManager dataManager, object data, string keyField, string key) {
            await _appService.Update(data as AppointmentData);
            return data;
        }
        public async override Task<object> RemoveAsync(DataManager dataManager, object data, string keyField, string key) //triggers on appointment deletion through public method DeleteEvent
        {
            var app = await _appService.GetByID((int)data);
            await _appService.Delete(app);
            return data;
        }
        public async override Task<object> BatchUpdateAsync(DataManager dataManager, object changedRecords, object addedRecords, object deletedRecords, string keyField, string key, int? dropIndex) {
            object records = deletedRecords;
            List<AppointmentData>? deleteData = deletedRecords as List<AppointmentData>;
            if(deleteData != null) {
                foreach (var data in deleteData) {
                    await _appService.Delete(data as AppointmentData);
                }
            }
            List<AppointmentData>? addData = addedRecords as List<AppointmentData>;
            if(addData != null) {
                foreach (var data in addData) {
                    await _appService.Insert(data as AppointmentData);
                    records = addedRecords;
                }
            }
            List<AppointmentData>? updateData = changedRecords as List<AppointmentData>;
            if (updateData != null) {
                foreach (var data in updateData) {
                    await _appService.Update(data as AppointmentData);
                    records = changedRecords;
                }
            }
            return records;
        }
    }
}

{% endhighlight %}

{% highlight c# tabtitle="AppointmentDataService.cs" %}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Syncfusion.Blazor;
using Microsoft.EntityFrameworkCore;

namespace syncfusion_blazor_app.Data
{
    public class AppointmentDataService
    {
        private readonly AppointmentDataContext _appointmentDataContext;

        public AppointmentDataService(AppointmentDataContext appDBContext)
        {
            _appointmentDataContext = appDBContext;
        }

        public async Task<List<AppointmentData>> Get(DateTime StartDate, DateTime EndDate)
        {
            return await _appointmentDataContext.AppointmentDatas.Where(evt => evt.StartTime >= StartDate && evt.EndTime <= EndDate).ToListAsync();
        }

        public async Task Insert(AppointmentData appointment)
        {
            var app = new AppointmentData();
            app.Id = appointment.Id;
            app.UserID = appointment.UserID;
            app.Subject = appointment.Subject;
            app.StartTime = appointment.StartTime;
            app.EndTime = appointment.EndTime;
            app.IsAllDay = appointment.IsAllDay;
            app.Location = appointment.Location;
            app.Description = appointment.Description;
            app.RecurrenceRule = appointment.RecurrenceRule;
            app.RecurrenceID = appointment.RecurrenceID;
            app.RecurrenceException = appointment.RecurrenceException;
            app.StartTimezone = appointment.StartTimezone;
            app.EndTimezone = appointment.EndTimezone;
            app.IsReadOnly = appointment.IsReadOnly;
            await _appointmentDataContext.AppointmentDatas.AddAsync(app);
            await _appointmentDataContext.SaveChangesAsync();
        }

        public async Task<AppointmentData> GetByID(int Id)
        {
            var app = await _appointmentDataContext.AppointmentDatas.FirstAsync(c => c.Id == Id);
            return app;
        }

        public async Task Update(AppointmentData appointment)
        {
            var app = await _appointmentDataContext.AppointmentDatas.FirstAsync(c => c.Id == appointment.Id);

            if (app != null)
            {
                app.UserID = appointment.UserID;
                app.Subject = appointment.Subject;
                app.StartTime = appointment.StartTime;
                app.EndTime = appointment.EndTime;
                app.IsAllDay = appointment.IsAllDay;
                app.Location = appointment.Location;
                app.Description = appointment.Description;
                app.RecurrenceRule = appointment.RecurrenceRule;
                app.RecurrenceID = appointment.RecurrenceID;
                app.RecurrenceException = appointment.RecurrenceException;
                app.StartTimezone = appointment.StartTimezone;
                app.EndTimezone = appointment.EndTimezone;
                app.IsReadOnly = appointment.IsReadOnly;

                _appointmentDataContext.AppointmentDatas?.Update(app);
                await _appointmentDataContext.SaveChangesAsync();
            }
        }

        public async Task Delete(AppointmentData appointment)
        {
            var app = await _appointmentDataContext.AppointmentDatas.FirstAsync(c => c.Id == appointment.Id);

            if (app != null)
            {
                _appointmentDataContext.AppointmentDatas?.Remove(app);
                await _appointmentDataContext.SaveChangesAsync();
            }
        }
    }
}

{% endhighlight %}

{% endtabs %}

The complete working sample for load on demand can be downloaded from [GitHub](https://github.com/SyncfusionExamples/blazor-scheduler-load-appointments-on-demand).

## SQL Server Data Binding (SQL Client)

The following examples demonstrate how to consume data from SQL Server using Microsoft SqlClient and bind it to the Blazor Scheduler. This requirement can be achieved by using a [Custom Adaptor](./custom-binding#custom-adaptor-as-component).

Before implementation, add the required NuGet packages like **Microsoft.Data.SqlClient** and **Syncfusion.Blazor** to the application. In the following sample, the `CustomAdaptor` is created as a Blazor component. In its `Read` method, filter appointments are retrieved using `DataManagerRequest`.

Based on the `DataManagerRequest`, an SQL query string is formed and executed. The `SqlDataAdapter` then retrieves data from the database. The Fill method of the **DataAdapter** is used to populate a **DataSet** with the results of the **SelectCommand** of the DataAdapter, then convert the DataSet into List and return **Result** and **Count** pair object in **Read** method to bind the data to Scheduler.

```cshtml
@using Syncfusion.Blazor.Schedule
@using Syncfusion.Blazor.Data
@using syncfusion_blazor_app.Data
@using syncfusion_blazor_app.Shared

<SfSchedule TValue="AppointmentData" Width="100%" Height="600px" @bind-SelectedDate="@SelectedDate">
    <ScheduleViews>
        <ScheduleView Option="View.Day"></ScheduleView>
        <ScheduleView Option="View.Week"></ScheduleView>
        <ScheduleView Option="View.WorkWeek"></ScheduleView>
        <ScheduleView Option="View.Month"></ScheduleView>
        <ScheduleView Option="View.Agenda"></ScheduleView>
    </ScheduleViews>
    <ScheduleEventSettings TValue="AppointmentData">
        <SfDataManager Adaptor="Adaptors.CustomAdaptor">
            <CustomAdaptorComponent></CustomAdaptorComponent>
        </SfDataManager>
    </ScheduleEventSettings>
</SfSchedule>

@code {
    DateTime SelectedDate { get; set; } = new DateTime(2023, 5, 10);
}
```

```cshtml
@using Syncfusion.Blazor;
@using Syncfusion.Blazor.Data;
@using static syncfusion_blazor_app.Pages.Sql;
@using Microsoft.Data.SqlClient;
@using System.Data;
@using System.IO;
@using Microsoft.AspNetCore.Hosting;
@using System.Text.Json.Serialization;
@using syncfusion_blazor_app.Data;
@inject IHostingEnvironment _env

@inherits DataAdaptor<AppointmentData>

<CascadingValue Value="@this">
    @ChildContent
</CascadingValue>

@code {
    [Parameter]
    [JsonIgnore]
    public RenderFragment ChildContent { get; set; }

    public static DataSet CreateCommand(string queryString, string connectionString)
    {
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            SqlDataAdapter adapter = new SqlDataAdapter(queryString, connection);
            DataSet dt = new DataSet();
            try
            {
                connection.Open();
                adapter.Fill(dt); // Using sqlDataAdapter, we process the query string and fill the data into the dataset
            }
            catch (SqlException se)
            {
                Console.WriteLine(se.ToString());
            }
            finally
            {
                connection.Close();
            }
            return dt;
        }
    }

    // Performs data Read operation
    public override object Read(DataManagerRequest DataManagerReq, string Key = null)
    {
        string AppData = _env.ContentRootPath;
        string DatabasePath = Path.Combine(AppData, "App_Data\\AppointmentDataDB.mdf");
        var connectionString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=" + Directory.GetCurrentDirectory() + "\\AppData\\AppointmentDataDB.mdf;Integrated Security=True";
        string QueryStr = "SELECT * FROM dbo.AppointmentDatas";
        DataSet Data = CreateCommand(QueryStr, connectionString);
        Appointment = Data.Tables[0].AsEnumerable().Select(r => new AppointmentData
            {
                Id = r.Field<int>("Id"),
                Subject = r.Field<string>("Subject"),
                StartTime = r.Field<DateTime>("StartTime"),
                EndTime = r.Field<DateTime>("EndTime")
            }).ToList();  // Here, we convert dataset into list
        IEnumerable<AppointmentData> DataSource = Appointment;
        SqlConnection Con = new SqlConnection(connectionString);
        Con.Open();
        SqlCommand Cmd = new SqlCommand("SELECT COUNT(*) FROM dbo.AppointmentDatas", Con);
        Int32 Count = (Int32)Cmd.ExecuteScalar();
        return DataManagerReq.RequiresCounts ? new DataResult() { Result = DataSource, Count = Count } : (object)DataSource;
    }
}
```

You can download a complete working sample from [GitHub](https://github.com/SyncfusionExamples/blazor-scheduler-sql-server-databinding).

## Performing CRUD using Entity Framework

To consume data from **Entity Framework Core** in the Scheduler component, follow these steps. For a quick visual guide on CRUD actions with Entity Framework, watch this video:

{% youtube
"youtube:https://www.youtube.com/watch?v=QlzdcZTmOrU-0"%}

### Create DBContext Class

The first step is to create a DBContext class called **ScheduleDataContext** to connect to a Microsoft SQL Server database.

```csharp
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Restful_Services.Models
{
    public partial class ScheduleDataContext : DbContext
    {
        public ScheduleDataContext()
        {
        }

        public ScheduleDataContext(DbContextOptions<ScheduleDataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<EventData> EventData { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=D:\\SchedulerCRUD\\Restful_Services\\App_Data\\ScheduleData.mdf;Integrated Security=True;MultipleActiveResultSets=True;Application Name=EntityFramework;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EventData>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
                entity.Property(e => e.EndTime).HasColumnType("datetime");
                entity.Property(e => e.RecurrenceID).HasColumnName("RecurrenceID");
                entity.Property(e => e.StartTime).HasColumnType("datetime");
            });
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
```

### Creating OData Controller

 A OData Controller has to be created which allows Scheduler directly to consume data from the Entity Framework. The following code example shows how to perform CRUD operations using Entity Framework.

```csharp
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.ModelBinding;
using Microsoft.AspNet.OData;
using Restful_Services.Models;

namespace Restful_Services.Controllers
{
    public class ODataV4Controller : ODataController
    {
        private ScheduleDataContext db = new ScheduleDataContext();

        // GET: odata/ODataV4
        [EnableQuery]
        [AcceptVerbs("GET")]
        public IQueryable<EventData> GetODataV4()
        {
            return db.EventData;
        }

        // GET: odata/ODataV4(5)
        [EnableQuery]
        [AcceptVerbs("GET")]
        public IQueryable<EventData> GetODataV4(string StartDate, string EndDate)
        {
            DateTime start = DateTime.Parse(StartDate);
            DateTime end = DateTime.Parse(EndDate);
            return db.EventData.Where(evt => evt.StartTime >= start && evt.EndTime <= end);
        }

        // POST: odata/ODataV4
        [AcceptVerbs("POST", "OPTIONS")]
        public void Post([FromBody]EventData eventData)
        {
            if (ModelState.IsValid)
            {
                EventData insertData = new EventData();
                insertData.Id = (db.EventData.ToList().Count > 0 ? db.EventData.ToList().Max(p => p.Id) : 1) + 1;
                insertData.Subject = eventData.Subject;
                insertData.StartTime = Convert.ToDateTime(eventData.StartTime);
                insertData.EndTime = Convert.ToDateTime(eventData.EndTime);
                insertData.StartTimezone = eventData.StartTimezone;
                insertData.EndTimezone = eventData.EndTimezone;
                insertData.Location = eventData.Location;
                insertData.Description = eventData.Description;
                insertData.IsAllDay = eventData.IsAllDay;
                insertData.IsBlock = eventData.IsBlock;
                insertData.IsReadOnly = eventData.IsReadOnly;
                insertData.FollowingID = eventData.FollowingID;
                insertData.RecurrenceID = eventData.RecurrenceID;
                insertData.RecurrenceRule = eventData.RecurrenceRule;
                insertData.RecurrenceException = eventData.RecurrenceException;
                db.EventData.Add(insertData);
                db.SaveChanges();
            }
        }

        // PATCH: odata/ODataV4(5)
        [AcceptVerbs("PATCH", "MERGE", "OPTIONS")]
        public void Patch([FromBody]EventData eventData)
        {
            if (ModelState.IsValid)
            {
                EventData updateData = db.EventData.First(i => i.Id == Convert.ToInt32(eventData.Id));
                if (updateData != null)
                {
                    updateData.Subject = eventData.Subject;
                    updateData.StartTime = Convert.ToDateTime(eventData.StartTime);
                    updateData.EndTime = Convert.ToDateTime(eventData.EndTime);
                    updateData.StartTimezone = eventData.StartTimezone;
                    updateData.EndTimezone = eventData.EndTimezone;
                    updateData.Location = eventData.Location;
                    updateData.Description = eventData.Description;
                    updateData.IsAllDay = eventData.IsAllDay;
                    updateData.IsBlock = eventData.IsBlock;
                    updateData.IsReadOnly = eventData.IsReadOnly;
                    updateData.FollowingID = eventData.FollowingID;
                    updateData.RecurrenceID = eventData.RecurrenceID;
                    updateData.RecurrenceRule = eventData.RecurrenceRule;
                    updateData.RecurrenceException = eventData.RecurrenceException;
                    db.SaveChanges();
                }
            }
        }

        // DELETE: odata/ODataV4(5)
        [AcceptVerbs("DELETE", "OPTIONS")]
        public void Delete([FromODataUri]int key)
        {
            if (ModelState.IsValid)
            {
                EventData removeData = db.EventData.First(i => i.Id == key);
                if (removeData != null)
                {
                    db.EventData.Remove(removeData);
                    db.SaveChanges();
                }
            }
        }
    }
}
```

### Configure Scheduler Component Using ODataV4Adaptor

Now, the Scheduler can be configured using the `SfDataManager` to interact with the created OData service and consume the data appropriately. To interact with OData, use `ODataV4Adaptor`.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Schedule
@using Syncfusion.Blazor.Data

<SfSchedule TValue="Restful_Services.Models.EventData" Height="550px" SelectedDate="@(new DateTime(2020, 04, 14))" >
    <ScheduleEventSettings TValue="Restful_Services.Models.EventData" Query="@QueryData" >
        <SfDataManager Url="http://localhost:9876/odata/" Adaptor="Adaptors.ODataV4Adaptor"></SfDataManager>
    </ScheduleEventSettings>
</SfSchedule>
@code {
    public Query QueryData = new Query().From("ODataV4");
}
```

N> You can find the working sample on Entity framework [here](https://github.com/SyncfusionExamples/blazor-scheduler-crud-using-restful-service).

## Configuring Scheduler with Google API Service

The Scheduler can be configured to retrieve events from a Google Calendar API service. The data obtained from Google services would typically be assigned to the Scheduler's `DataSource` within the [`OnInitializedAsync`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.SfSchedule-1.html#Syncfusion_Blazor_Schedule_SfSchedule_1_OnInitializedAsync) method. And, the CRUD actions are performed within the [`ActionCompleted`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Schedule.ScheduleEvents-1.html#Syncfusion_Blazor_Schedule_ScheduleEvents_1_ActionCompleted) event.

A custom service would need to be implemented to connect and retrieve events from the Google Calendar API.

N> A runnable sample demonstrating Google Calendar synchronization with Blazor Scheduler is available [here](https://github.com/SyncfusionExamples/google-calendar-synchronization-with-blazor-scheduler).

## See Also

* [How to Access Microsoft Graph Calendar Events with Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor Scheduler](https://www.syncfusion.com/blogs/post/how-to-access-microsoft-graph-calendar-events-with-syncfusion-blazor-scheduler.aspx )
* [Easy Steps to Synchronize JIRA Calendar Tasks with the Blazor Scheduler](https://www.syncfusion.com/blogs/post/easy-steps-to-synchronize-jira-calendar-tasks-with-the-blazor-scheduler.aspx)