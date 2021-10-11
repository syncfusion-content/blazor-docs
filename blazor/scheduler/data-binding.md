---
layout: post
title: Data Binding in Blazor Scheduler Component | Syncfusion
description: This section includes the data binding topics explaining how to bind various data sources to Syncfusion Blazor Scheduler component using DataManager adaptors.
platform: Blazor
control: Scheduler
documentation: ug
---

# Data Binding in Blazor Scheduler Component

The Scheduler uses `DataManager`, which supports both RESTful data service binding and datasource collections. The `DataSource` property of Scheduler can be assigned either with the instance of `DataManager` or List of datasource collection, as it supports the following two kind of data binding methods:

* Local data
* Remote data

You can check out the following video to bind the appointments in the Blazor Scheduler.

{% youtube
"youtube:https://www.youtube.com/watch?v=EwfxPrqxma8"%}

## Binding local data

To bind local data to the Scheduler, you can simply assign a List of datasource collections to the `DataSource` option of the scheduler within the `ScheduleEventSettings` tag. The local data source can also be provided as an instance of the `DataManager`.

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

> By default, `DataManager` uses `BlazorAdaptor` for binding local data.

You can also bind different field names to the default event fields as well as include additional custom fields to the event object collection which can be referred [here](./appointments/#event-fields).

## Binding remote data

Any kind of remote data services can be bound to the Scheduler. To do so, provide the service URL to the `Url` option of `SfDataManager` within `ScheduleEventSettings` tag.

### Using ODataV4Adaptor

[ODataV4](https://www.odata.org/documentation/) is a standardized protocol for creating and consuming data. Refer to the following code example to retrieve the data from ODataV4 service using the DataManager. To connect with ODataV4 service end points, it is necessary to make use of `ODataV4Adaptor` within `DataManager`.

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

### Using custom adaptor

It is possible to create your own `CustomAdaptor` by extending the built-in available adaptors. The following example demonstrates the custom adaptor usage and how to bind the data with custom service and the CRUD operations for custom bounded data is performed using the methods of [DataAdaptor](https://blazor.syncfusion.com/documentation/data/custom-binding/) abstract class.

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

## Binding ExpandoObject

Scheduler is a generic component which is strongly bound to a model type. There are cases when the model type is unknown during compile type. In such cases you can bound data to the scheduler as list of  **ExpandoObject**.

**ExpandoObject** can be bound to the `DataSource` option of the scheduler within the `ScheduleEventSettings` tag. Scheduler can also perform all kind of supported data operations and editing in ExpandoObject.

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

## Binding DynamicObject

Scheduler is a generic component which is strongly bound to a model type. There are cases when the model type is unknown during compile type. In such cases you can bound data to the scheduler as list of  **DynamicObject**.

**DynamicObject** can be bound to the `DataSource` option of the scheduler within the `ScheduleEventSettings` tag. Scheduler can also perform all kind of supported data operations and editing in DynamicObject.

> The [`GetDynamicMemberNames`](https://docs.microsoft.com/en-us/dotnet/api/system.dynamic.dynamicobject.getdynamicmembernames?view=netcore-3.1) method of DynamicObject class must be overridden and return the property names to perform data operation and editing while using DynamicObject.

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

## Binding ObservableCollection

This [ObservableCollection](https://docs.microsoft.com/en-us/dotnet/api/system.collections.objectmodel.observablecollection-1?view=netframework-4.8)(dynamic data collection) provides notifications when items added, removed and moved. The implement [INotifyCollectionChanged](https://docs.microsoft.com/en-us/dotnet/api/system.collections.specialized.inotifycollectionchanged?view=netframework-4.8) notifies when dynamic changes of add,remove, move and clear the collection. The implement [INotifyPropertyChanged](https://docs.microsoft.com/en-us/dotnet/api/system.componentmodel.inotifypropertychanged?view=netframework-4.8) notifies when property value has changed in client side.
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

## Performing CRUD using Entity Framework

You need to follow the below steps to consume data from the **Entity Framework** in our Scheduler component.

### Create DBContext class

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

### Configure Scheduler component using ODataV4Adaptor

Now you can configure the Scheduler using the `SfDataManager` to interact with the created OData service and consume the data appropriately. To interact with OData, you need to use `ODataV4Adaptor`.

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

> You can find the working sample [here](https://github.com/SyncfusionExamples/blazor-scheduler-crud).

## Passing additional parameters to the server

To send an additional custom parameter to the server-side post, you need to make use of the `AddParams` method of `Query`. Now, assign this `Query` object with additional parameters to the `Query` property of Scheduler.

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

> The parameters added using the `Query` property will be sent along with the data request sent to the server on every scheduler actions.

## Scheduler CRUD actions

The CRUD (Create, Read, Update and Delete) actions can be performed easily on Scheduler appointments using the various adaptors available within the `DataManager`. Most preferably, we will be using `ODataV4Adaptor` for performing CRUD actions on scheduler appointments.

```cshtml
@using Syncfusion.Blazor
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Schedule

<SfSchedule TValue="Restful_Crud.Models.EventData" SelectedDate="@(DateTime.Now.Date)">
    <ScheduleEventSettings TValue="Restful_Crud.Models.EventData" Query="@QueryData">
        <SfDataManager Url="http://localhost:25255/odata" Adaptor="Adaptors.ODataV4Adaptor"></SfDataManager>
    </ScheduleEventSettings>
</SfSchedule>

@code{
    public Query QueryData { get; set; } = new Query().From("EventDatas");
}
```

The server-side controller code to handle the CRUD operations are as follows.

```sh
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using System.Web.Http.OData;
using System.Web.Http.OData.Routing;
using Restful_Crud.Models;

namespace Restful_Crud.Controllers
{
    public class EventDatasController : ODataController
    {
        private ScheduleDataEntities1 db = new ScheduleDataEntities1();

        // GET: odata/EventDatas
        [EnableQuery]
        [AcceptVerbs("GET")]
        public IQueryable<EventData> GetEventDatas()
        {
            return db.EventDatas;
        }

        // GET: odata/EventDatas(5)
        [EnableQuery]
        [AcceptVerbs("GET")]
        public IQueryable<EventData> GetEventDatas(string StartDate, string EndDate, bool ReadOnly)
        {
            DateTime start = DateTime.Parse(StartDate);
            DateTime end = DateTime.Parse(EndDate);
            return db.EventDatas.Where(evt => evt.StartTime >= start && evt.EndTime <= end);
        }

        // POST: odata/EventDatas
        [AcceptVerbs("POST", "OPTIONS")]
        public void Post([FromBody]CrudData eventData)
        {
            EventData insertData = new EventData();
            insertData.Id = (db.EventDatas.ToList().Count > 0 ? db.EventDatas.ToList().Max(p => p.Id) : 1) + 1;
            insertData.StartTime = Convert.ToDateTime(eventData.StartTime).ToLocalTime();
            insertData.EndTime = Convert.ToDateTime(eventData.EndTime).ToLocalTime();
            insertData.Subject = eventData.Subject;
            insertData.IsAllDay = eventData.IsAllDay;
            insertData.Location = eventData.Location;
            insertData.Description = eventData.Description;
            insertData.RecurrenceRule = eventData.RecurrenceRule;
            insertData.RecurrenceID = eventData.RecurrenceID;
            insertData.RecurrenceException = eventData.RecurrenceException;
            insertData.StartTimezone = eventData.StartTimezone;
            insertData.EndTimezone = eventData.EndTimezone;

            db.EventDatas.Add(insertData);
            db.SaveChanges();
        }

        // PATCH: odata/EventDatas(5)
        [AcceptVerbs("PATCH", "MERGE", "OPTIONS")]
        public void Patch([FromBody]CrudData eventData)
        {
            EventData updateData = db.EventDatas.Find(Convert.ToInt32(eventData.Id));
            if (updateData != null)
            {
                updateData.StartTime = Convert.ToDateTime(eventData.StartTime).ToLocalTime();
                updateData.EndTime = Convert.ToDateTime(eventData.EndTime).ToLocalTime();
                updateData.Subject = eventData.Subject;
                updateData.IsAllDay = eventData.IsAllDay;
                updateData.Location = eventData.Location;
                updateData.Description = eventData.Description;
                updateData.RecurrenceRule = eventData.RecurrenceRule;
                updateData.RecurrenceID = eventData.RecurrenceID;
                updateData.RecurrenceException = eventData.RecurrenceException;
                updateData.StartTimezone = eventData.StartTimezone;
                updateData.EndTimezone = eventData.EndTimezone;

                db.SaveChanges();
            }
        }

        // DELETE: odata/EventDatas(5)
        [AcceptVerbs("DELETE", "OPTIONS")]
        public void Delete([FromODataUri]int key)
        {
            EventData removeData = db.EventDatas.Find(key);
            if (removeData != null)
            {
                db.EventDatas.Remove(removeData);
                db.SaveChanges();
            }
        }
    }
}
```

## Configuring Scheduler with Google API service

We have assigned the dataSource that is retrieved from the Google services within the `OnInitializedAsync` method. And, the CRUD actions are performed within the `ActionCompleted` event.

We have to write our own service to connect retrieve the events from the Google calendar.

> The runnable sample for the above code will be available [here](https://github.com/SyncfusionExamples/google-calendar-synchronization-with-blazor-scheduler).