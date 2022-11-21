---
layout: post
title: Data Binding in Blazor TreeView Component | Syncfusion
description: Checkout and learn here all about Data Binding in Syncfusion Blazor TreeView component and much more.
platform: Blazor
control: TreeView
documentation: ug
---

# Data Binding in Blazor TreeView Component

The Blazor TreeView component provides the option to load data either from the local data sources or from remote data services. This can be done through `DataSource` property that is a member of the `Fields` property. The `DataSource` property supports list of objects and `DataManager`. It also supports different kinds of data services such as OData, OData V4, Web API, URL, and JSON with the help of `DataManager` adaptors.

Blazor TreeView has `load on demand` (Lazy load), by default. It reduces the bandwidth size when consuming huge data. It loads first level nodes initially, and when parent node is expanded, loads the child nodes based on the `ParentID/Child` member.

By default, the `LoadOnDemand` is set to true. By disabling this property, all the tree nodes are rendered at the beginning itself. The `DataBound` event can be used to perform actions. This event will be triggered once the data source is populated in the TreeView.

## Local data

To bind local data to the Blazor TreeView, assign a list of objects to the `DataSource` property. The Blazor TreeView component requires three fields (Id, Text, and ParentID) to render local data source. When mapper fields are not specified, it takes the default values as the mapping fields. Local data source can also be provided as an instance of the `DataManager`. It supports two kinds of local data binding methods.

* Hierarchical data

* Self-referential data

### Hierarchical data

Blazor TreeView can be populated with hierarchical data source that contains nested list of objects. A hierarchical data can be directly assigned to the `DataSource` property, and map all the field members with corresponding keys from the hierarchical data to `Fields` property.

In the following example, **Id**, **FolderName**, and **SubFolders** columns from hierarchical data have been mapped to **Id**, **Text**, and **Child** fields, respectively.

```cshtml
@using Syncfusion.Blazor.Navigations
<SfTreeView TValue="MailItem">
    <TreeViewFieldsSettings TValue="MailItem" Id="Id" Text="FolderName" Child="SubFolders" DataSource="@MyFolder" Expanded="Expanded"></TreeViewFieldsSettings>
</SfTreeView>

@code{
    public class MailItem
    {
        public string Id { get; set; }
        public string FolderName { get; set; }
        public bool Expanded { get; set; }
        public List<MailItem> SubFolders { get; set; }
    }
    List<MailItem> MyFolder = new List<MailItem>();
    protected override void OnInitialized()
    {
        base.OnInitialized();
        List<MailItem> Folder1 = new List<MailItem>();
        MyFolder.Add(new MailItem
        {
            Id = "01",
            FolderName = "Inbox",
            SubFolders = Folder1
        });

        List<MailItem> Folder2 = new List<MailItem>();

        Folder1.Add(new MailItem
        {
            Id = "01-01",
            FolderName = "Categories",
            SubFolders = Folder2
        });
        Folder2.Add(new MailItem
        {
            Id = "01-02",
            FolderName = "Primary"
        });
        Folder2.Add(new MailItem
        {
            Id = "01-03",
            FolderName = "Social"
        });
        Folder2.Add(new MailItem
        {
            Id = "01-04",
            FolderName = "Promotions"
        });

        List<MailItem> Folder3 = new List<MailItem>();

        MyFolder.Add(new MailItem
        {
            Id = "02",
            FolderName = "Others",
            Expanded = true,
            SubFolders = Folder3
        });
        Folder3.Add(new MailItem
        {
            Id = "02-01",
            FolderName = "Sent Items"
        });
        Folder3.Add(new MailItem
        {
            Id = "02-02",
            FolderName = "Delete Items"
        });
        Folder3.Add(new MailItem
        {
            Id = "02-03",
            FolderName = "Drafts"
        });
        Folder3.Add(new MailItem
        {
            Id = "02-04",
            FolderName = "Archive"
        });
    }
}

```

![Blazor TreeView with Hierarchical Data](./images/blazor-treeview-hierarchical-data.png)

### Self-referential data

Blazor TreeView can be populated from self-referential data structure that contains list of objects with `ParentID` mapping. The self-referential data can be directly assigned to the `DataSource` property, and map all the field members with corresponding keys from self-referential data to `Fields` property.

To render the root level nodes, specify the ParentID as null or no need to specify the ParentID in `DataSource`. In the following example, **Id**, **Pid**, **HasSubFolders**, and **FolderName** columns from self-referential data have been mapped to **Id**, **ParentId**, **HasChildren**, and **Text** fields, respectively.

```cshtml
@using Syncfusion.Blazor.Navigations
<SfTreeView TValue="MailItem">
    <TreeViewFieldsSettings TValue="MailItem" Id="Id" DataSource="@MyFolder" Text="FolderName" ParentID="ParentId" HasChildren="HasSubFolders" Expanded="Expanded"></TreeViewFieldsSettings>
</SfTreeView>

@code{
    public class MailItem
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string FolderName { get; set; }
        public bool Expanded { get; set; }
        public bool HasSubFolders { get; set; }
    }
    List<MailItem> MyFolder = new List<MailItem>();
    protected override void OnInitialized()
    {
        base.OnInitialized();
        MyFolder.Add(new MailItem
        {
            Id = "1",
            FolderName = "Inbox",
            HasSubFolders = true,
        });
        MyFolder.Add(new MailItem
        {
            Id = "2",
            ParentId = "1",
            HasSubFolders = true,
            FolderName = "Categories"
        });
        MyFolder.Add(new MailItem
        {
            Id = "3",
            ParentId = "2",
            FolderName = "Primary"
        });
        MyFolder.Add(new MailItem
        {
            Id = "4",
            ParentId = "2",
            FolderName = "Social"
        });
        MyFolder.Add(new MailItem
        {
            Id = "5",
            ParentId = "2",
            FolderName = "Promotions"
        });
        MyFolder.Add(new MailItem
        {
            Id = "6",
            FolderName = "Others",
            HasSubFolders = true,
            Expanded = true
        });
        MyFolder.Add(new MailItem
        {
            Id = "7",
            ParentId = "6",
            FolderName = "Sent Items"
        });
        MyFolder.Add(new MailItem
        {
            Id = "8",
            ParentId = "6",
            FolderName = "Delete Items"
        });
        MyFolder.Add(new MailItem
        {
            Id = "9",
            ParentId = "6",
            FolderName = "Drafts"
        });
        MyFolder.Add(new MailItem
        {
            Id = "10",
            ParentId = "6",
            FolderName = "Archive"
        });

    }
}

```

![Blazor TreeView with Self-Referential Data](./images/blazor-treeview-hierarchical-data.png)

## Remote data

Blazor TreeView can also be populated from a remote data service with the help of `DataManager` component and `Query` property. It supports different kinds of data services such as OData, OData V4, Web API, URL, and JSON with the help of `DataManager` adaptors. A service data can be assigned as an instance of `DataManager` to the `DataSource` property. To interact with remote data source, provide the endpoint `url`.

The `DataManager` that acts as an interface between the service endpoint and the TreeView requires the following information to interact with service endpoint properly.

* `DataManager->url`: Defines the service endpoint to fetch data.

* `DataManager->adaptor`: Defines the adaptor option. By default, ODataAdaptor is used for remote binding.

Adaptor is responsible for processing response and request from/to the service endpoint. The `Syncfusion.Blazor.Data` provides some predefined adaptors designed to interact with service endpoints. They are,

* `UrlAdaptor`: Used to interact with remote services. This is the base adaptor for all remote based adaptors.

* `ODataAdaptor`: Used to interact with OData endpoints.

* `ODataV4Adaptor`: Used to interact with OData V4 endpoints.

* `WebApiAdaptor`: Used to interact with Web API created under OData standards.

* `WebMethodAdaptor`: Used to interact with web methods.

In the following example, `ODataV4Adaptor` is  used to fetch data from remote services. The **EmployeeID**, **FirstName**, and **EmployeeID** columns from Employees table have been mapped to **Id**, **Text**, and **HasChildren** fields respectively for first level nodes.

The **OrderID**, **EmployeeID**, and **ShipName** columns from orders table have been mapped to **Id**, **ParentID**, and **Text** fields respectively for second level nodes.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Data
<SfTreeView TValue="TreeData">
    <TreeViewFieldsSettings TValue="TreeData" Query="@Query" Id="EmployeeID" Text="FirstName" HasChildren="EmployeeID">
        <SfDataManager Url="http://services.odata.org/V4/Northwind/Northwind.svc" Adaptor="@Syncfusion.Blazor.Adaptors.ODataV4Adaptor" CrossDomain="true"></SfDataManager>
        <TreeViewFieldChild TValue="TreeData" Query="@SubQuery" Id="OrderID" Text="ShipName" ParentID="EmployeeID">
            <SfDataManager Url="http://services.odata.org/V4/Northwind/Northwind.svc" Adaptor="@Syncfusion.Blazor.Adaptors.ODataV4Adaptor" CrossDomain="true"></SfDataManager>
        </TreeViewFieldChild>
    </TreeViewFieldsSettings>
</SfTreeView>

@code{
    public Query Query = new Query().From("Employees").Select(new List<string> { "EmployeeID", "FirstName" }).Take(5).RequiresCount();
    public Query SubQuery = new Query().From("Orders").Select(new List<string> { "OrderID", "EmployeeID", "ShipName" }).Take(5).RequiresCount();
    public class TreeData
    {
        public int? EmployeeID { get; set; }
        public int OrderID { get; set; }
        public string ShipName { get; set; }
        public string FirstName { get; set; }
    }
}

```

![Blazor TreeView with Remote Data](./images/blazor-treeview-remote-data.png)

### Custom adaptor 

Sometimes the built-in adaptors do not meet your requirements, and in such cases, you can create your own adaptor.

To create and use a custom adaptor, please follow the following steps:

* Create a class that extended from the DataAdaptor class. DataAdaptor class will act as a base class for your custom adaptor.
* Override the desired method to achieve your requirement.
* Assign the custom adaptor class to the **AdaptorInstance** property of the SfDataManager component.

```cshtml
@using Syncfusion.Blazor.Navigations
<SfTreeView TValue="MailItem" @ref="treeObj">
    <TreeViewFieldsSettings TValue="MailItem" Id="Id" Query="@DataQuery" Text="FolderName" ParentID="ParentId" HasChildren="HasSubFolders" Expanded="Expanded">
    <SfDataManager @ref="DataManagerRef" AdaptorInstance="@typeof(CustomAdaptor)"
                   Adaptor="Adaptors.CustomAdaptor">
    </SfDataManager>
    </TreeViewFieldsSettings>

</SfTreeView>
 <button @onclick="GetAllData">@content</button>

@code{
    public string content = "See All";
    SfTreeView<MailItem> treeObj;
    public bool isFirstClick = false;
    public SfDataManager DataManagerRef { get; set; }
    public static List<MailItem> MyFolder = new List<MailItem>
    {
        new MailItem
        {
            Id = "1",
            FolderName = "Inbox",
            HasSubFolders = false,
            Expanded = true
        },
        new MailItem
        {
            Id = "2",
            FolderName = "Categories",
            Expanded = true,
            HasSubFolders = false
        },
        new MailItem
        {
            Id = "3",
            FolderName = "Primary"
        },
        new MailItem
        {
            Id = "4",
            FolderName = "Social"
        },
        new MailItem
        {
            Id = "5",
            FolderName = "Promotions"
        }
    };
    public class MailItem
    {
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string FolderName { get; set; }
        public bool Expanded { get; set; }
        public bool HasSubFolders { get; set; }
    }
    public Query DataQuery { get; set; }
    public Query InitialDataQuery = new Query().Take(3);
    public Query UpdatedDataQuery = new Query().Take(5);
    protected override void OnInitialized()
    {
        base.OnInitialized();
        DataQuery = InitialDataQuery;
    }
    public void GetAllData()
    {
        if (!isFirstClick)
        {
            DataQuery = new Query().Take(5);
            //StateHasChanged();
            isFirstClick = true;
            content = "See less";
            treeObj.Refresh();
        }
        else
        {
            DataQuery = new Query().Take(3);
            content = "See All";
            isFirstClick = false;
        }
    }
    public class CustomAdaptor : DataAdaptor
    {
        // Performs data Read operation
        public override object Read(DataManagerRequest dm, string key = null)
        {
            IEnumerable<MailItem> DataSource = MyFolder;
            int count = DataSource.Cast<MailItem>().Count();
            DataSource = DataOperations.Execute<MailItem>(DataSource, dm);
            return dm.RequiresCounts ? new DataResult() { Result = DataSource, Count = count } : (object)DataSource;
        }
    }

}
```
### Web API adaptor with CRUD operations

The `WebApiAdaptor` to interact with web APIs created with OData endpoints. The `WebApiAdaptor` is an extension of the `ODataAdaptor`. Hence, to use `WebApiAdaptor`, the endpoint should understand the OData-formatted queries sent along with the request.

To enable OData query option for Web API, refer to this [documentation](https://learn.microsoft.com/en-us/aspnet/web-api/overview/odata-support-in-aspnet-web-api/supporting-odata-query-options).

The following sample code demonstrates binding remote data to the TreeView component through the [SfDataManager](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor.Data.SfDataManager.html) using Web API service,

```cshtml
@using Syncfusion.Blazor;
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Data
@using BlazorApp1.Data
<div id="treeview">
    <SfTreeView @ref="_tree" TValue="NodeResult" AllowEditing="true">
        <TreeViewFieldsSettings TValue="NodeResult"
                                Id="ProductID"
                                Text="ProductName"
                                ParentID="pid"
                                HasChildren="haschild"
                                Query="TreeQuery">
            <SfDataManager @ref="AutoDM" Url="api/Nodes" CrossDomain="true" Adaptor="Syncfusion.Blazor.Adaptors.WebApiAdaptor"></SfDataManager>
        </TreeViewFieldsSettings>
        <TreeViewEvents TValue="NodeResult"
                        NodeSelected="NodeSelected"
                        NodeClicked="NodeClicked"
                        DataBound="DataBound">
        </TreeViewEvents>
        <SfContextMenu @ref="_menu"
                       Target="#treeview"
                       Items="MenuItems">
            <MenuEvents TValue="MenuItem"
                        ItemSelected="@SelectedHandler">
            </MenuEvents>
            <MenuItems>

                <MenuItem Text="Edit"></MenuItem>

                <MenuItem Text="Add"></MenuItem>

                <MenuItem Text="Remove"></MenuItem>

            </MenuItems>
        </SfContextMenu>
    </SfTreeView>
</div>

@code
 {
    public Query TreeQuery = new Query();
    public static SfDataManager AutoDM { get; set; }
    SfTreeView<NodeResult> _tree;
    SfContextMenu<MenuItem> _menu;
    // Datasource for menu items
    public List<MenuItem> MenuItems = new List<MenuItem>{
        new MenuItem { Text = "Edit" },
        new MenuItem { Text = "Remove" },
        new MenuItem { Text = "Add" }
    };

    public class CustomWebApiNodeAdaptor : WebApiAdaptor
    {
        public CustomWebApiNodeAdaptor(DataManager dataManager) : base(dataManager)
        {
        }
        public override string GetName()
        {
            return base.GetName();
        }
        public override bool IsRemote()
        {
            return base.IsRemote();
        }
        public override object Insert(DataManager dataManager, object data, string tableName = null, Query query = null, int position = 0)
        {
            return base.Insert(dataManager, data, tableName, query, position);
        }
        public override object Remove(DataManager dataManager, string keyField, object value, string tableName = null, Query query = null)
        {
            return base.Remove(dataManager, keyField, value, tableName, query);
        }
        public override object Update(DataManager dataManager, string keyField, object data, string tableName = null, Query query = null, object original = null, IDictionary<string, object> updateProperties = null)
        {
            return base.Update(dataManager, keyField, data, tableName, query, original, updateProperties);
        }
        public override void BeforeSend(HttpRequestMessage request)
        {
            base.BeforeSend(request);
        }
        public override object ProcessQuery(DataManagerRequest queries)
        {
            return base.ProcessQuery(queries);
        }
        public override Task<object> ProcessResponse<T>(object data, DataManagerRequest queries)
        {
            return base.ProcessResponse<T>(data, queries);
        }
        public override Task<object> ProcessCrudResponse<T>(object data, DataManagerRequest queries)
        {
            return base.ProcessCrudResponse<T>(data, queries);
        }
    }
    public void NodeSelected(NodeSelectEventArgs args) { this.selectedId = args.NodeData.Id; }
    public void NodeClicked(NodeClickEventArgs args) { this.selectedId = args.NodeData.Id; }
    string selectedId;
    private void SelectedHandler(MenuEventArgs<MenuItem> args)

    {

        string selectedText;
        selectedText = args.Item.Text;
        if (selectedText == "Edit")
        {
            this.RenameNodes();
        }
        else if (selectedText == "Remove")
        {
            this.RemoveNodes();
        }
        else if (selectedText == "Add")
        {
            // this.AddNodes();
        }

    }

    void RemoveNodes()
    {
        string[] removeNode = new string[] { this.selectedId };
        this._tree.RemoveNodes(removeNode);
    }

    async void RenameNodes()
    {
        await _tree.BeginEdit(this.selectedId);
    }

    public void DataBound(DataBoundEventArgs<NodeResult> args)
    {
        if (AutoDM != null)
        {
#pragma warning disable BL0005
            AutoDM.DataAdaptor = new CustomWebApiNodeAdaptor(AutoDM);
#pragma warning restore BL0005
        }
    }

}

<style>
    .control_wrapper {
        max-width: 500px;
        margin: auto;
        border: 1px solid #dddddd;
        border-radius: 3px;
    }
</style>

```
```csharp
namespace BlazorApp1.Data
{
    public class DataModel
    {
        public string Text { get; set; }
        public string ID { get; set; }
        public int IDD { get; set; }
        public string Category { get; set; }
    }
    public class NodeResult
    {
        public int? ProductID { get; set; }
        public string ProductName { get; set; }
        public int? pid { get; set; }
        public bool haschild { get; set; }
    }
}
```
```csharp
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace BlazorApp1.Controller
{
 
    [Route("api/[controller]")]
    public class NodesController : ControllerBase
    {
        List<NodeResult> data = NodeResult.GetAllRecords().ToList();

        [HttpGet]
        public IEnumerable<NodeResult> Get()
        {
            
            var queryString = Request.Query;
            if (queryString.Keys.Contains("$filter"))
            {

                string filter = string.Join("", queryString["$filter"].ToString().Split(' ').Skip(2)); // get filter from querystring
                // filter the data based on the expand node id.
                data = data.Where(d => d.pid.ToString() == filter).ToList();
                return data;
            }
            else
            {
                // if the parent id is null.
                data = data.Where(d => d.pid == null).ToList();
                return data;
            }
            return data;
        }

        // Remove nodes
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            NodeResult item = data.Where(x => x.ProductID.Equals(id)).FirstOrDefault();
            data.Remove(item);
        }

        // Node update
        [HttpPut]
        public object Put([FromBody] NodeResult item)
        {
            NodeResult _item = data.Where(x => x.ProductID.Equals(item.ProductID)).FirstOrDefault();
            _item.ProductName = item.ProductName;
            return _item;
        }

        public class NodeResult
        {
            public NodeResult(int? ProductID, string ProductName, int? pid, bool haschild)
            {
                this.ProductID = ProductID;
                this.ProductName = ProductName;
                this.pid = pid;
                this.haschild = haschild;
            }

            public static List<NodeResult> GetAllRecords()
            {
                List<NodeResult> localData = new List<NodeResult>();
                localData.Add(new NodeResult(1, "MyFolder", null, true));
                localData.Add(new NodeResult(2, "Child1", 1, false));
                localData.Add(new NodeResult(3, "Child2", 1, true));
                localData.Add(new NodeResult(4, "Child3", 1, false));
                localData.Add(new NodeResult(8, "SubChild1", 3, false));
                localData.Add(new NodeResult(9, "SubChild2", 3, false));
                return localData;

            }
            public int? ProductID { get; set; }
            public string ProductName { get; set; }
            public int? pid { get; set; }
            public bool haschild { get; set; }
        }
       
    } 
}

```
## Entity Framework

The following steps must be followed to consume data from the **Entity Framework** in the TreeView component.

### Create DBContext class

The first step is to create a DBContext class called **OrganizationContext** to connect to the Microsoft SQL Server database.

```csharp
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLTreeView.Shared.Models;
using SQLTreeView.Data;

namespace SQLTreeView.Shared.DataAccess
{
    public class OrganizationContext : DbContext
    {
        public virtual DbSet<OrganizationDetails> Organization { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // To make the sample runnable, replace your local file path of the MDF file here
                optionsBuilder.UseSqlServer(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename= D:\Blazor\TreeView\SQLTreeView\Shared\App_Data\NORTHWND.MDF';Integrated Security=True;Connect Timeout=30");
            }
        }
    }
}

```

### Create data access layer to perform CRUD operation

Now, create a class named **OrganizationDataAccessLayer**, which act as the data access layer for retrieving the records from the database table. Also, add methods such as **AddEmployee**, **UpdateEmployee**, **DeleteEmployee** in the **“OrganizationDataAccessLayer.cs”** to handle the insert, update, and remove operations respectively.

```csharp

using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SQLTreeView.Shared.Models;
using SQLTreeView.Data;
using SQLTreeView.Shared.DataAccess;
namespace SQLTreeView.Shared.DataAccess
{
    public class OrganizationDataAccessLayer
    {
        OrganizationContext db = new OrganizationContext();
        List<OrganizationDetails> EmployeeList = new List<OrganizationDetails>();
        // returns the organization data from the data base
        public DbSet<OrganizationDetails> GetAllEmployees()
        {
            try
            {
                return db.Organization;
            }
            catch
            {
                throw;
            }
        }

        // Adds the new entry to the data base
        public void AddEmployee(OrganizationDetails Employee)
        {
            try
            {
                db.Organization.Add(Employee);
                OrganizationDetails ParentDetails = db.Organization.Find(Employee.ParentId);
                if (ParentDetails != null)
                {
                    ParentDetails.HasTeam = true;
                }
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        // Update the existing data in the data base
        public void UpdateEmployee(OrganizationDetails Employee)
        {
            try
            {
                db.Entry(Employee).State = EntityState.Modified;
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        // To delete an entry from the data base
        public void DeleteEmployee(int id)
        {
            try
            {
                OrganizationDetails Employee = db.Organization.Find(id);
                db.Organization.Remove(Employee);
                DeleteChildEmployee(id);
                db.Organization.RemoveRange(EmployeeList);
                db.SaveChanges();
            }
            catch
            {
                throw;
            }
        }

        // To delete the nested child from the data base
        public void DeleteChildEmployee(int id)
        {
            try
            {
                var data = GetAllEmployees().ToList();
                for (int i = 0; i < data.Count(); i++)
                {
                    if (data[i].ParentId == id && EmployeeList.Contains(data[i]) == false)
                    {
                        EmployeeList.Add(data[i]);
                        if (data[i].HasTeam == true)
                        {
                            DeleteChildEmployee(data[i].Id);
                        }
                    }
                }
            }
            catch
            {
                throw;
            }
        }
    }
}

```

### Creating Web API Controller

A Web API Controller should be created which allows the TreeView directly to consume data from the Entity Framework. Also, create a new **Post**, **Put**, **Delete** method in the web API controller which will perform the CRUD operations and returns the appropriate resultant data. The **‘SfDataManager’** will make requests to this action based on the route name.

```csharp

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;
using SQLTreeView.Data;
using SQLTreeView.Shared.DataAccess;
using SQLTreeView.Shared.Models;


namespace WebApplication1.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        OrganizationDataAccessLayer db = new OrganizationDataAccessLayer();
        [HttpGet]
        public object Get()
        {
            // Get the DataSource from Database
            var data = db.GetAllEmployees().ToList();
            var queryString = Request.Query;
            if (queryString.Keys.Contains("$filter"))
            {
                StringValues Skip;
                StringValues Take;
                int skip = (queryString.TryGetValue("$skip", out Skip)) ? Convert.ToInt32(Skip[0]) : 0;
                int top = (queryString.TryGetValue("$top", out Take)) ? Convert.ToInt32(Take[0]) : data.Count();
                string filter = string.Join("", queryString["$filter"].ToString().Split(' ').Skip(2)); // get filter from querystring
                data = data.Where(d => d.ParentId.ToString() == filter).ToList();
                return data.Skip(skip).Take(top);
            }
            else
            {
                data = data.Where(d => d.ParentId == null).ToList();
                return data;
            }
        }

        [HttpGet("{id}")]
        public object GetIndex(string id)
        {
            // Get the DataSource from Database
            var data = db.GetAllEmployees().ToList();
            int index;
            var count = data.Count;
            if (count > 0)
            {
                index = (data[data.Count - 1].Id);
            } else
            {
                index = 0;
            }
            return index;
        }
        [HttpPost]
        public void Post([FromBody]OrganizationDetails employee)
        {
            db.AddEmployee(employee);
        }
        [HttpPut]
        public object Put([FromBody]OrganizationDetails employee)
        {
            db.UpdateEmployee(employee);
            return employee;
        }
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            db.DeleteEmployee(id);
        }
    }
}

```

### Configure Blazor TreeView component using Web API adaptor

Now, the Blazor TreeView can be configured using the **‘SfDataManager’** to interact with the created Web API and consume the data appropriately. To interact with web API, use web API adaptor.

> The CRUD operation has been performed in the TreeView component using the context menu.

```csharp

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Data
@using Newtonsoft.Json;
@inject HttpClient Http

<div id="treeview">
    <SfTreeView @ref="tree" TValue="Employee">
        <TreeViewFieldsSettings TValue="Employee" Id="Id" Text="Name" ParentID="ParentId" HasChildren="HasTeam" Expanded="IsExpanded">
            <SfDataManager Url="api/Default" Adaptor="Adaptors.WebApiAdaptor" CrossDomain="true"></SfDataManager>
        </TreeViewFieldsSettings>
        <TreeViewEvents TValue="Employee" NodeClicked="nodeClicked"></TreeViewEvents>
        <SfContextMenu TValue="MenuItem" @ref="menu" Target="#treeview" Items="@MenuItems">
            <ContextMenuEvents TValue="MenuItem" ItemSelected="MenuSelect"></ContextMenuEvents>
        </SfContextMenu>
    </SfTreeView>
</div>

@code{

    SfTreeView<Employee> tree;

    SfContextMenu<MenuItem> menu;

    string selectedId;
    int index;

    // Datasource for menu items
    public List<MenuItem> MenuItems = new List<MenuItem>{
        new MenuItem  { Text = "Edit" },
        new MenuItem  { Text = "Remove" },
        new MenuItem  { Text = "Add" }
    };

    public class Employee
    {
        public int Id { get; set; }
        public int? ParentId { get; set; }

        public bool? HasTeam { get; set; }

        public bool? IsExpanded { get; set; }

        public string Name { get; set; }
    }


    protected override async Task OnInitializedAsync()
    {
        // To get the last item index from the db
        var count = await Http.GetJsonAsync<int>("api/Default/index");
        this.index = count + 1;
    }

    // Triggers when TreeView node is clicked
    public async void nodeClicked(NodeClickEventArgs args)
    {
        this.selectedId = null;
        string eventString = JsonConvert.SerializeObject(args.Event);
        Dictionary<string, dynamic> eventParameters = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(eventString);
        if ((eventParameters["which"]).ToString() == "3")
        {
            // To get the selected node id upon context menu click
            this.selectedId = (await args.Node.GetAttribute("data-uid")).ToString();
        }
    }

    // To add a new node
    void AddNodes()
    {
        List<Employee> TreeData = new List<Employee>();
        TreeData.Add(new Employee
        {
            Id = this.index,
            Name = "New Entry",
            ParentId = Int32.Parse(this.selectedId)

        });
        this.tree.AddNodes(TreeData, this.selectedId);
        this.index = this.index + 1;
    }

    // To delete a tree node
    void RemoveNodes()
    {
        string[] removeNode = new string[] { this.selectedId };
        this.tree.RemoveNodes(removeNode);
    }

    // To edit a tree node
    async void RenameNodes()
    {
        tree.BeginEdit(this.selectedId);
    }

    // Triggers when context menu is selected
    public void MenuSelect(MenuEventArgs<MenuItem> args)
    {
        string selectedText = args.Item.Text;
        if (selectedText == "Edit")
        {
            this.RenameNodes();
        }
        else if (selectedText == "Remove")
        {
            this.RemoveNodes();
        }
        else if (selectedText == "Add")
        {
            this.AddNodes();
        }
        this.selectedId = null;
    }
}

```

> The fully working sample can be found [here](https://github.com/SyncfusionExamples/Blazor-treeview-entity-framework).
