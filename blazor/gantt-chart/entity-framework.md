---
layout: post
title: Entity frameWork in Blazor Gantt Chart Component | Syncfusion
description: Checkout and learn here all about Entity frameWork in Syncfusion Blazor Gantt Chart component and more.
platform: Blazor
control: Gantt Chart
documentation: ug
---


# Entity FrameWork in Blazor Gantt Chart Component

You need to follow the below steps to consume data from the **Entity Framework** in the Gantt Chart component.

**Step 1:** The first step is to create a SQL database in your Blazor project. Refer this [link](https://docs.microsoft.com/en-us/visualstudio/data-tools/create-a-sql-database-by-using-a-designer?view=vs-2019) to create SQL database.

**Step 2:** Install the below packages for Entity Framework Support using Nuget or Package manager console using the below command.

```bash
Install-Package Microsoft.EntityFrameworkCore.Tools

Install-Package Microsoft.EntityFrameworkCore.SqlServer

```

**Step 3:** Create a model class `GanttDataDetails.cs` for the existing database file.

```csharp

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System;

namespace MyBlazorApp.Data
{

    public class GanttDataDetails
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? Sdate { get; set; }
        public DateTime? Edate { get; set; }
        public string Progress { get; set; }
        public int? ParentId { get; set; }
        public string Duration { get; set; }
        public string ProjectName { get; set; }
        public DateTime? BaselineStartDate { get; set; }
        public DateTime? BaselineEndDate { get; set; }
        public string Predecessor { get; set; }
        public string Notes { get; set; }
        public string TaskType { get; set; }
        public List<TaskResources> ResourceId { get; set; }
        public string ProjectId { get; set; }
        public bool? IsExpand { get; set; }
    }
}

```

**Step 4:** Create a DB Context class to connect to the Microsoft SQL Server database using the below command in Package Manager Console.

```bash

Server=(localdb)\\MSSQLLocalDB;Database=master;Integrated Security=True

```

```csharp
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GanttEF.Models
{
    public partial class masterContext : DbContext
    {
        public masterContext()
        {
        }

        public masterContext(DbContextOptions<masterContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Table> Table { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=master;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Table>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Edate).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Progress)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.Sdate).HasColumnType("datetime");
            });
            OnModelCreatingPartial(modelBuilder);
        }
        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
```

**Step 5:** Update the connection string in the appsettings.json file.

```csharp

"ConnectionStrings": {
    "EmployeeDatabase": "Data Source=(LocalDB)\\\\MSSQLLocalDB;AttachDbFilename=\\\"D:\\client-side-gantt-chart-application-with-entity-framework\\Gantt_wasm_crud_sample1804339720\\Gantt_wasm_crud_sample\\Shared\\App_DataNORTHWND.MDF\\\";Integrated Security=True"
  }

```

The following sections will give details about the steps that need to be followed when working with server-side and client-side applications individually. You can also find samples attached at the end of each section for server-side applications and client-side applications.

## Entity framework in server-side application

You need to follow the following steps when working with a server-side application.

### Custom adaptor

In Gantt Chart, you can fetch data from the SQL database using `Entity Framework` Data Model and update the changes on CRUD action to the server by using `DataManager` support. To communicate with the remote data, `CustomAdaptor` of DataManager property is used to call the server method. Learn  know more about `CustomAdaptor` from [here](https://blazor.syncfusion.com/documentation/data/custom-binding/). You can populate the datasource in Gantt from the SQL table using Entity Framework using **Read** method. Check the following code snippet to assign the data source to Gantt.

```cshtml
@using GanttEF.Models
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor


<SfGantt ID="GanttExport" TValue="GanttData" Height="450px" Width="700px"
         Toolbar="@(new List<string>(){ "Add", "Edit", "Update", "Delete", "Cancel", "ExpandAll", "CollapseAll"})">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GanttColumns>
        <GanttColumn Field=@nameof(GanttData.Id) Width="100"></GanttColumn>
        <GanttColumn Field=@nameof(GanttData.Name) Width="250"></GanttColumn>
        <GanttColumn Field=@nameof(GanttData.Sdate)></GanttColumn>
        <GanttColumn Field=@nameof(GanttData.Edate)></GanttColumn>
        <GanttColumn Field=@nameof(GanttData.Progress)></GanttColumn>
    </GanttColumns>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true" ShowDeleteConfirmDialog="true" NewRowPosition="RowPosition.Child"></GanttEditSettings>
    <GanttTimelineSettings>
        <GanttTopTierSettings Unit="TimelineViewMode.Week" Format="MMM dd, y"></GanttTopTierSettings>
        <GanttBottomTierSettings Unit="TimelineViewMode.Day"></GanttBottomTierSettings>
    </GanttTimelineSettings>
    <GanttTaskFields Id="Id" Name="Name" StartDate="Sdate" EndDate="Edate" Progress="Progress"
                     ParentID="ParentId"></GanttTaskFields>
</SfGantt>

@code {
    // Implementing custom adaptor by extending the DataAdaptor class.
    public class CustomAdaptor : DataAdaptor
    {
        masterContext db = new masterContext();
        // Performs data Read operation.
        public override object Read(DataManagerRequest dm, string key = null)
        {
            IEnumerable<GanttData> DataSource = db.GanttData;
            int count = DataSource.Cast<GanttData>().Count();
            return dm.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
        }
        .../////

    }
}
```

### Perform CRUD operation in custom adaptor

All the CRUD operations in the Gantt Chart are done through DataManager. The DataManager has an option to bind all the CRUD related data in server-side.

You can do CRUD operations over Gantt data and save the changes into the database. By using **BatchUpdate** method of DataManager, You can communicate with the controller method to update the data source by CRUD operation. In Gantt Chart, the CRUD actions on a task are dependent on other tasks. For example, if you edit the child record on the chart side, the corresponding parent item also will get affected and predecessor dependency task as well get affected. So, all the CRUD operations in Gantt Chart are considered to be batch editing, where you will get all the affected records as collection.

This server method will be triggered for all the CRUD operations like adding, editing, and deleting actions. You can handle each operation separately inside this method with corresponding data received in this method argument.

The following sample code explains you about, how to implement CRUD operations for the custom bounded data.

```cshtml
@using GanttEF.Models
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor

<SfGantt ID="GanttExport" TValue="GanttData" Height="450px" Width="700px"
Toolbar="@(new List<string>(){ "Add", "Edit", "Update", "Delete", "Cancel", "ExpandAll", "CollapseAll"})">
    <SfDataManager AdaptorInstance="@typeof(CustomAdaptor)" Adaptor="Adaptors.CustomAdaptor"></SfDataManager>
    <GanttColumns>
        <GanttColumn Field=@nameof(GanttData.Id) Width="100"></GanttColumn>
        <GanttColumn Field=@nameof(GanttData.Name) Width="250"></GanttColumn>
        <GanttColumn Field=@nameof(GanttData.Sdate)></GanttColumn>
        <GanttColumn Field=@nameof(GanttData.Edate)></GanttColumn>
        <GanttColumn Field=@nameof(GanttData.Progress)></GanttColumn>
    </GanttColumns>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true" ShowDeleteConfirmDialog="true" NewRowPosition="RowPosition.Child"></GanttEditSettings>
    <GanttTimelineSettings>
        <GanttTopTierSettings Unit="TimelineViewMode.Week" Format="MMM dd, y"></GanttTopTierSettings>
        <GanttBottomTierSettings Unit="TimelineViewMode.Day"></GanttBottomTierSettings>
    </GanttTimelineSettings>
    <GanttTaskFields Id="Id" Name="Name" StartDate="Sdate" EndDate="Edate" Progress="Progress"
                     ParentID="ParentId"></GanttTaskFields>
</SfGantt>

@code {
    // Implementing custom adaptor by extending the DataAdaptor class.
    public class CustomAdaptor : DataAdaptor
    {
        masterContext db = new masterContext();
        // Performs data Read operation.
        public override object Read(DataManagerRequest dm, string key = null)
        {
            IEnumerable<GanttData> DataSource = db.GanttData;
            int count = DataSource.Cast<GanttData>().Count();
            return dm.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
        }

        // Performs CRUD operation.
        public override object BatchUpdate(DataManager dm, object changedRecords, object addedRecords, object deletedRecords, string keyField, string key, int? dropIndex)
        {
            List<GanttData> addRecord = addedRecords as List<GanttData>;
            List<GanttData> changed = changedRecords as List<GanttData>;
            List<GanttData> deleteRecord = deletedRecords as List<GanttData>;
            if (changed != null)
            {
                for (var i = 0; i < changed.Count(); i++)
                {
                    var value = changed[i];
                    GanttData result = db.GanttData.Where(or => or.Id == value.Id).FirstOrDefault();
                    result.Id = value.Id;
                    result.Name = value.Name;
                    result.Sdate = value.Sdate;
                    result.Edate = value.Edate;
                    result.Progress = value.Progress;
                    db.SaveChanges();
                }
            }
            if (deleteRecord != null)
            {
                for (var i = 0; i < deleteRecord.Count(); i++)
                {
                    db.GanttData.Remove(db.GanttData.Where(or => or.Id == deleteRecord[i].Id).FirstOrDefault());
                    db.SaveChanges();
                }
            }
            if (addRecord != null)
            {
                for (var i = 0; i < addRecord.Count(); i++)
                {
                    db.GanttData.Add(addRecord[i] as GanttData);
                    db.SaveChanges();
                }
            }
            return (new { addedRecords = addRecord, changedRecords = changed, deletedRecords = deleteRecord });
        }
    }
}
```

N>You can find the sample for server-side application using entity framework [here](https://github.com/SyncfusionExamples/Blazor-Gantt-Chart-with-Entity-framework).

## Entity framework in client-side application

You need to follow the following steps when working with a client-side application.

### Custom adaptor

In Gantt Chart, you can fetch data from the SQL database using `Entity Framework` Data Model and update the changes on CRUD action to the server by using `DataManager` support. To communicate with the
remote data, `CustomAdaptor` of DataManager property is used to call the server method. You can know more about `CustomAdaptor` from [here](https://blazor.syncfusion.com/documentation/data/custom-binding/). You can populate the datasource in Gantt from the SQL table using Entity Framework using **ReadAsync** method. Check the following code snippet to assign the data source to Gantt.

```cshtml
@using MyBlazorApp.Shared.DataAccess
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor
@using MyBlazorApp.Data

<SfGantt ID="GanttExport" TValue="GanttDataDetails" HighlightWeekends="true" RowHeight="75" DurationUnit="DurationUnit.Day"
         Toolbar="@(new List<string>(){ "Add", "Edit", "Update", "Delete", "Cancel", "ExpandAll", "CollapseAll"})">
    <SfDataManager Adaptor="Adaptors.CustomAdaptor" DataType="GanttDataDetails">
        <CustomDataAdaptor></CustomDataAdaptor>
    </SfDataManager>
    <GanttColumns>
        <GanttColumn Field=@nameof(GanttDataDetails.Id) Width="100"></GanttColumn>
        <GanttColumn Field=@nameof(GanttDataDetails.Name) Width="250"></GanttColumn>
        <GanttColumn Field=@nameof(GanttDataDetails.Sdate)></GanttColumn>
        <GanttColumn Field=@nameof(GanttDataDetails.Edate)></GanttColumn>
        <GanttColumn Field=@nameof(GanttDataDetails.Duration)></GanttColumn>
        <GanttColumn Field=@nameof(GanttDataDetails.Progress)></GanttColumn>
        <GanttColumn Field=@nameof(GanttDataDetails.ParentId)></GanttColumn>
    </GanttColumns>
    <GanttEditSettings AllowAdding="true" AllowDeleting="true" AllowEditing="true" AllowTaskbarEditing="true"></GanttEditSettings>
    <GanttTimelineSettings>
        <GanttTopTierSettings Unit="TimelineViewMode.Week" Format="MMM dd, y"></GanttTopTierSettings>
        <GanttBottomTierSettings Unit="TimelineViewMode.Day"></GanttBottomTierSettings>
    </GanttTimelineSettings>
    <GanttTaskFields Id="Id" Name="Name" StartDate="Sdate" EndDate="Edate" ParentID="ParentId" Progress="Progress" Duration="Duration"></GanttTaskFields>
</SfGantt>

@code {

    // Performs data Read operation.
    public override async Task<object> ReadAsync(DataManagerRequest dm, string key = null)

    {
        IEnumerable<object> data = await http.GetJsonAsync<IEnumerable<GanttDataDetails>>("api/GanttDataDetails") as IEnumerable<object>;

        return dm.RequiresCounts ? new DataResult() { Result = data, Count = data.Count() } : (object)data;
    }
        .../////
}

```

### Perform CRUD operation in custom adaptor

All the CRUD operations in the Gantt Chart are done through DataManager. The DataManager has an option to bind all the CRUD related data in server-side.

The following sample code explains you about, how to implement CRUD operations for the custom bounded data.

```csharp

@using Newtonsoft.Json
@using MyBlazorApp.Data
@using Syncfusion.Blazor.Gantt
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor
@using MyBlazorApp.Shared.DataAccess
@inject HttpClient http


@inherits DataAdaptor<GanttDataContext>

@code {


    // Performs data Read operation.
    public override async Task<object> ReadAsync(DataManagerRequest dm, string key = null)

    {
        IEnumerable<object> data = await http.GetJsonAsync<IEnumerable<GanttDataDetails>>("api/GanttDataDetails") as IEnumerable<object>;

        return dm.RequiresCounts ? new DataResult() { Result = data, Count = data.Count() } : (object)data;
    }

    // Performs CRUD operation.
    public override async Task<object> BatchUpdateAsync(DataManager dm, object changedRecords, object addedRecords, object deletedRecords, string keyField, string key, int? dropIndex)

    {

        List<GanttDataDetails> addRecord = addedRecords as List<GanttDataDetails>;
        List<GanttDataDetails> changed = changedRecords as List<GanttDataDetails>;
        List<GanttDataDetails> deleteRecord = deletedRecords as List<GanttDataDetails>;
        if (changed != null)
        {
            for (var i = 0; i < changed.Count(); i++)
            {

                var value = changed[i];
                await http.SendJsonAsync(HttpMethod.Put, "/api/GanttDataDetails/" + changed[i].Id, changed[i] as GanttDataDetails);
            }
        }
        if (deleteRecord != null)
        {
            for (var i = 0; i < deleteRecord.Count(); i++)
            {
                await http.DeleteAsync("api/GanttDataDetails/" + deleteRecord[i].Id);
            }
        }
        if (addRecord != null)
        {


            for (var i = 0; i < addRecord.Count(); i++)
            {
                await http.SendJsonAsync(HttpMethod.Post, "/api/GanttDataDetails", addRecord[i] as GanttDataDetails);
            }
        }
        return (new { addedRecords = addRecord, changedRecords = changed, deletedRecords = deleteRecord });
    }
}

```

You can find the sample for client-side application using entity framework [here](https://github.com/SyncfusionExamples/Blazor-Gantt-Chart-Client-Side-Application-with-EF).