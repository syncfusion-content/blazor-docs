---
layout: post
title: Entity Framework in Blazor TreeGrid Component | Syncfusion
description: Learn how to integrate Entity Framework with the Syncfusion Blazor TreeGrid component and much more details.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Entity Framework in Blazor TreeGrid Component

This section builds on the code explained in the Entity Framework data binding section. Review the [Entity Framework data binding](https://blazor.syncfusion.com/documentation/treegrid/data-binding#entity-framework) topic before continuing with this section.

### Handle CRUD in data access layer class

Add the methods **AddTask**, **UpdateTask**, and **DeleteTask** in the file **TasksDataAccessLayer.cs** to handle the create, update, and delete operations, respectively. **CRUD** record details are bound to the **Tasks** parameter.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TreeGridWebApiEFSample.Shared.Models;
using Microsoft.EntityFrameworkCore;

namespace TreeGridWebApiEFSample.Shared.DataAccess
{
    public class TasksDataAccessLayer
    {
        TasksContext treedb = new TasksContext();

        //To Get all Task details  
        public IEnumerable<Shared.Models.Task> GetAllRecords()
        {
            try
            {
                return treedb.Tasks.ToList();
            }
            catch
            {
                throw;
            }
        }

        //To Add new Tasks record  
        public void AddTask(Shared.Models.Task task)
        {
            try
            {
                treedb.Tasks.Add(task);
                treedb.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
        //To Update the records of a particular Tasks
        public void UpdateTask(Shared.Models.Task task)
        {
            try
            {
                treedb.Entry(task).State = EntityState.Modified;
                treedb.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        //Get the details of a particular Tasks
        public Shared.Models.Task GetTaskData(int id)
        {
            try
            {
                Shared.Models.Task task = treedb.Tasks.Find(id);
                return task;
            }
            catch
            {
                throw;
            }
        }

        //To Delete the record of a particular Tasks
        public void DeleteTask(int id)
        {
            try
            {
                Shared.Models.Task emp = treedb.Tasks.Find(id);
                treedb.Tasks.Remove(emp);
                treedb.SaveChanges();
            }
            catch
            {
                throw;
            }
        }
    }
}
```

### Enable CRUD in Web API

Create new **POST**, **PUT**, and **DELETE** methods in the Web API controller to perform CRUD operations and return the appropriate results. **SfDataManager** makes requests to these actions based on the configured route.

```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TreeGridWebApiEFSample.Shared.Models;
using TreeGridWebApiEFSample.Shared.DataAccess;
using Microsoft.Extensions.Primitives;
using System.Web;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json.Linq;


namespace TreeGridWebApiEFSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class TreeGridController : ControllerBase
    {
        TasksDataAccessLayer db = new TasksDataAccessLayer();

        // GET: api/<TreeGridController>
        [HttpGet]
        public object Get()
        {
            var queryString = Request.Query;
            IQueryable<TreeGridWebApiEFSample.Shared.Models.Task> data1 = db.GetAllRecords().AsQueryable();
            if (queryString.Keys.Contains("$filter") && !queryString.Keys.Contains("$top"))
            {
                StringValues filter;
                queryString.TryGetValue("$filter", out filter);
                int fltr = Int32.Parse(filter[0].ToString().Split("eq")[1]);
                data1 = data1.Where(f => f.ParentID == fltr).AsQueryable();

                return new { Items = data1, Count = data1.Count() };
            }
            if (queryString.Keys.Contains("$select"))
            {
                data1 = (from ord in data1
                         select new TreeGridWebApiEFSample.Shared.Models.Task
                         {
                             ParentID = ord.ParentID
                         }
                        );
                return data1;
            }

            data1 = data1.Where(p => p.ParentID == null);
            var count = data1.Count();

            if (queryString.Keys.Contains("$inlinecount"))
            {
                StringValues Skip;
                StringValues Take;
                int skip = (queryString.TryGetValue("$skip", out Skip)) ? Convert.ToInt32(Skip[0]) : 0;
                int top = (queryString.TryGetValue("$top", out Take)) ? Convert.ToInt32(Take[0]) : data1.Count();
                return new { Items = data1.Skip(skip).Take(top), Count = count };
            }
            else
            {
                return data1;
            }
        }

        // GET api/<TreeGridController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        public object Post([FromBody]TreeGridWebApiEFSample.Shared.Models.Task Task)
        {
            IQueryable<TreeGridWebApiEFSample.Shared.Models.Task> data1 = db.GetAllRecords().AsQueryable();
            var i = 0;
            // For loop for finding the parent record and setting its "HasChildMapping"(here it is "IsParent") to true
            for (; i < data1.ToList().Count; i++)
            {
                if (data1.ToList()[i].TaskID == Task.ParentID)
                {
                    if (data1.ToList()[i].IsParent == null)
                    {
                        data1.ToList()[i].IsParent = true;
                    }
                    break;

                }
            }
            db.AddTask(Task);
            return Task;

        }
        public int FindChildRecords(int? id)
        {
            var count = 0;
            IQueryable<TreeGridWebApiEFSample.Shared.Models.Task> data1 = db.GetAllRecords().AsQueryable();
            for (var i = 0; i < data1.ToList().Count; i++)
            {
                if (data1.ToList()[i].ParentID == id)
                {
                    count++;
                    count += FindChildRecords(data1.ToList()[i].TaskID);
                }
            }
            return count;
        }

        [HttpPut]
        public object Put([FromBody]TreeGridWebApiEFSample.Shared.Models.Task Task)
        {
            IQueryable<TreeGridWebApiEFSample.Shared.Models.Task> data2 = db.GetAllRecords().AsQueryable();
            TreeGridWebApiEFSample.Shared.Models.Task val = data2.Where(or => or.TaskID == Task.TaskID).FirstOrDefault();
            val.TaskID = Task.TaskID;
            val.TaskName = Task.TaskName;
            val.Duration = Task.Duration;
            val.Progress = Task.Progress;
            db.UpdateTask(val);
            return val;
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            db.DeleteTask(id);
        }
    }
}
```

### Configure the TreeGrid to perform CRUD operations

Use SfDataManager with the WebApiAdaptor to connect the TreeGrid to the Web API controller and enable editing settings for create, update, and delete operations.

```cshtml
@using Syncfusion.Blazor.Grids
@using Syncfusion.Blazor.Data
@using Syncfusion.Blazor.Buttons
@using Syncfusion.Blazor.TreeGrid
@using Shared.Models

<SfTreeGrid TValue="Shared.Models.Task"  @ref="treeGrid" IdMapping="TaskID" AllowPaging="true"
            ParentIdMapping="ParentID" HasChildMapping="IsParent"
            TreeColumnIndex="0" Toolbar="Toolbaritems">
    <SfDataManager Url="api/TreeGrid" Adaptor="Adaptors.WebApiAdaptor" CrossDomain="true"></SfDataManager>
    <TreeGridEditSettings AllowEditing="true"
                            AllowAdding="true"
                            AllowDeleting="true"
                            Mode="Syncfusion.Blazor.TreeGrid.EditMode.Row"
                            NewRowPosition="Syncfusion.Blazor.TreeGrid.RowPosition.Child"></TreeGridEditSettings>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskID" HeaderText="Task ID" Width="80" IsPrimaryKey="true" Type=ColumnType.Number></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="160" Type=ColumnType.String></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="160" Type=ColumnType.Number></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="160" Type=ColumnType.Number></TreeGridColumn>

    </TreeGridColumns>
</SfTreeGrid>

@code{

    SfTreeGrid<Shared.Models.Task> treeGrid { get; set; }

    private List<Object> Toolbaritems = new List<Object>() { "Add", "Edit", "Delete", "Update", "Cancel" };

}
```

N> A fully working sample is available [on GitHub](https://github.com/SyncfusionExamples/Blazor-TreeGrid-With-EntityFramework).