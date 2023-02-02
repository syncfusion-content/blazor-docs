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

### ExpandoObject binding 

The Blazor TreeView is a generic component that is strongly bound to a specific model type, but in cases where the model type is unknown at compile time, the TreeView can be bound to a list of ExpandoObjects using the `DataSource` property. This allows the TreeView to perform all supported data operations.

```cshtml
@using Syncfusion.Blazor.Navigations
@using System.Dynamic
<SfTreeView TValue="ExpandoObject">
    <TreeViewFieldsSettings TValue="ExpandoObject" Id="ID" DataSource="@TreeData" Text="Name" ParentID="ParentID" HasChildren="ChildRecordID" Expanded="Expanded"></TreeViewFieldsSettings>
</SfTreeView>

@code {
    SfTreeView<ExpandoObject> TreeGrid;
    public List<ExpandoObject> TreeData { get; set; }
    protected override void OnInitialized()
    {
        this.TreeData = GetData().ToList();
    }
    public static List<ExpandoObject> Data = new List<ExpandoObject>();
    public static int ParentRecordID { get; set; }
    public static int ChildRecordID { get; set; }
    public static List<ExpandoObject> GetData()
    {
        Data.Clear();
        ParentRecordID = 0;
        ChildRecordID = 0;
        for (var i = 1; i <= 3; i++)
        {
            dynamic ParentRecord = new ExpandoObject();
            ParentRecord.ID = ++ParentRecordID;
            ParentRecord.Name = "Parent " + i;
            ParentRecord.ParentID = null;
            ParentRecord.Expanded = true;
            Data.Add(ParentRecord);
            AddChildRecords(ParentRecordID);
        }
        return Data;
    }
    public static void AddChildRecords(int ParentId)
    {
        for (var i = 1; i < 3; i++)
        {
            dynamic ChildRecord = new ExpandoObject();
            ChildRecord.ID = ++ParentRecordID;
            ChildRecord.Name = "Child item" + ++ChildRecordID;
            ChildRecord.ParentID = ParentId;
            Data.Add(ChildRecord);
        }
    }
}

```

### DynamicObject binding

The Blazor TreeView is a generic component that is strongly bound to a specific model type, but in cases where the model type is unknown at compile time, the data can be bound to the TreeView as a list of DynamicObjects. The TreeView can also perform all supported data operations on DynamicObjects when they are assigned to the DataSource property.

```cshtml
@using Syncfusion.Blazor.Navigations
@using System.Dynamic
<SfTreeView TValue="DynamicDictionary" AllowEditing="true">
    <TreeViewFieldsSettings TValue="DynamicDictionary" Id="ID" DataSource="@TreeData" Text="Name" ParentID="ParentID" HasChildren="ChildRecordID" Expanded="Expanded"></TreeViewFieldsSettings>
</SfTreeView>

@code {
    SfTreeView<DynamicDictionary> TreeView;
    public List<DynamicDictionary> TreeData { get; set; }
    protected override void OnInitialized()
    {
        this.TreeData = GetData().ToList();
    }
    public static List<DynamicDictionary> Data = new List<DynamicDictionary>();
    public static int ParentRecordID { get; set; }
    public static int ChildRecordID { get; set; }

    public static List<DynamicDictionary> GetData()
    {
        Data.Clear();
        ParentRecordID = 0;
        ChildRecordID = 0;
        for (var i = 1; i <= 3; i++)
        {
            dynamic ParentRecord = new DynamicDictionary();
            ParentRecord.ID = ++ParentRecordID;
            ParentRecord.Name = "Parent " + i;
            ParentRecord.ParentID = null;
            ParentRecord.Expanded = true;
            Data.Add(ParentRecord);
            AddChildRecords(ParentRecordID);
        }
        return Data;
    }
    public static void AddChildRecords(int ParentId)
    {
        for (var i = 1; i < 3; i++)
        {
            dynamic ChildRecord = new DynamicDictionary();
            ChildRecord.ID = ++ParentRecordID;
            ChildRecord.Name = "Child Item " + ++ChildRecordID;
            ChildRecord.ParentID = ParentId;
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

```

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

### Binding with OData services

In the following example, `ODataAdaptor` is  used to fetch data from remote services. The **EmployeeID**, **FirstName**, and **EmployeeID** columns from Employees table have been mapped to **Id**, **Text**, and **HasChildren** fields respectively for first level nodes.

The **OrderID**, **EmployeeID**, and **ShipName** columns from orders table have been mapped to **Id**, **ParentID**, and **Text** fields respectively for second level nodes.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Data
<SfTreeView TValue="TreeData" >
    <TreeViewFieldsSettings TValue="TreeData" Query="@Query" Id="EmployeeID" Text="FirstName" HasChildren="EmployeeID">
        <SfDataManager Url="http://services.odata.org/Northwind/Northwind.svc" Adaptor="@Syncfusion.Blazor.Adaptors.ODataAdaptor" CrossDomain="true"></SfDataManager>
        <TreeViewFieldChild TValue="TreeData" Query="@SubQuery" Id="OrderID" Text="ShipName" ParentID="EmployeeID">
            <SfDataManager Url="http://services.odata.org/Northwind/Northwind.svc" Adaptor="@Syncfusion.Blazor.Adaptors.ODataAdaptor" CrossDomain="true"></SfDataManager>
        </TreeViewFieldChild>
    </TreeViewFieldsSettings>
</SfTreeView>

@code {
    public Query Query = new Query().From("Employees").Select(new List<string> { "EmployeeID", "FirstName" }).Take(3).RequiresCount();
    public Query SubQuery = new Query().From("Orders").Select(new List<string> { "OrderID", "EmployeeID", "ShipName" }).Take(2).RequiresCount();
    public class TreeData
    {
        public int? EmployeeID { get; set; }
        public int OrderID { get; set; }
        public string ShipName { get; set; }
        public string FirstName { get; set; }
    }
}

```

### Binding with OData V4 services

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

### Web API Adaptor

The Blazor TreeView component retrieves data from the server as needed, such as when expanding a parent node to fetch its child nodes, using the DataManager component.

In the following example, `WebApiAdaptor` is  used to fetch data from server side.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Data
<div class="col-lg-12 control-section">
    <div class="control_wrapper">
        <SfTreeView TValue="NodeResult">
            <TreeViewFieldsSettings TValue="NodeResult"
                                    Id="ProductID"
                                    Text="ProductName"
                                    ParentID="pid"
                                    HasChildren="haschild"
                                    Query="TreeViewQuery">
                <SfDataManager Url="api/Nodes" CrossDomain="true" Adaptor="Syncfusion.Blazor.Adaptors.WebApiAdaptor"></SfDataManager>
            </TreeViewFieldsSettings>
        </SfTreeView>
    </div>
</div>

@code
{
    public Query TreeViewQuery = new Query();
    public class NodeResult
    {
        public int? ProductID { get; set; }
        public string? ProductName { get; set; }
        public int? pid { get; set; }
        public bool haschild { get; set; }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace BlazorTreeView.Controller
{
    [Route("api/[controller]")]
    public class NodesController : ControllerBase
    {      
        [HttpGet]
        public IEnumerable<NodeResult> Get()
        {
           
            List<NodeResult> localData = new List<NodeResult>();
            localData.Add(new NodeResult(1, "Parent", null, true));
            localData.Add(new NodeResult(2, "Child1" , 1, false));
            localData.Add(new NodeResult(3, "Child2" , 1, true));
            localData.Add(new NodeResult(4, "Child3" , 1, false));
            localData.Add(new NodeResult(8, "SubChild1" , 3, false));
            localData.Add(new NodeResult(9, "SubChild2" , 3, false));
            var data = localData.ToList();
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
        public class NodeResult
        {
            public NodeResult(int? ProductID, string ProductName, int? pid, bool haschild)
            {
                this.ProductID = ProductID;
                this.ProductName = ProductName;
                this.pid = pid;
                this.haschild = haschild;
            }
            public int? ProductID { get; set; }
            public string ProductName { get; set; }
            public int? pid { get; set; }
            public bool haschild { get; set; } 
        }
       
    }
}

```

### Sending additional parameters to the server

To add custom parameters to the data request in the Blazor TreeView component, use the addParams method of the Query class and assign the Query object with additional parameters to the TreeView's **Query** property, as demonstrated in the following sample code.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Data
<div class="control_wrapper">
    <SfTreeView TValue="MailItem" @ref="treeview" >
        <TreeViewFieldsSettings TValue="MailItem" Query="Query" Id="ID" DataSource="@MyFolder" Text="FolderName" ParentID="ParentId" HasChildren="HasSubFolders" Expanded="Expanded"></TreeViewFieldsSettings>
    </SfTreeView>
</div>
@code {
    SfTreeView<MailItem> treeview;
    public string ParamValue = "true";
    public Query Query { get; set; }
    public class MailItem
    {
        public string ID { get; set; }
        public string ParentId { get; set; }
        public string FolderName { get; set; }
        public bool Expanded { get; set; }
        public bool HasSubFolders { get; set; }
    }
    List<MailItem> MyFolder = new List<MailItem>();
    protected override void OnInitialized()
    {
        base.OnInitialized();
        Query = new Query().AddParams("TreeView", ParamValue);
        MyFolder.Add(new MailItem
            {
                ID = "1",
                FolderName = "Inbox",
                HasSubFolders = true,
                Expanded = true
            });
        MyFolder.Add(new MailItem
            {
                ID = "2",
                ParentId = "1",
                FolderName = "Categories",
                Expanded = true,
                HasSubFolders = true
            });
        MyFolder.Add(new MailItem
            {
                ID = "3",
                ParentId = "2",
                FolderName = "Primary"
            });
        MyFolder.Add(new MailItem
            {
                ID = "4",
                ParentId = "2",
                FolderName = "Social"
            });
        MyFolder.Add(new MailItem
            {
                ID = "5",
                ParentId = "2",
                FolderName = "Promotions"
            });
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
## Observable collection

The Blazor TreeView component's ObservableCollection provides notifications of changes made to the collection, such as when items are added, removed, or updated. It implements INotifyCollectionChanged to notify of dynamic changes to the collection, and INotifyPropertyChanged to notify of changes to property values on the client side.

```cshtml
@using Syncfusion.Blazor.Navigations
@using System.Collections.ObjectModel
@using BlazorTreeView.Data

<div class="control_wrapper">
    <SfTreeView @ref="TreeView" TValue="ObservableDatas">
        <TreeViewFieldsSettings DataSource="@ObservableData" Id="@nameof(ObservableDatas.Id)" Child="@nameof(ObservableDatas.Children)" Text="@nameof(ObservableDatas.Name)" HasChildren="@nameof(ObservableDatas.HasChild)" Expanded="@nameof(ObservableDatas.Expanded)"></TreeViewFieldsSettings>
        <TreeViewEvents TValue="ObservableDatas" NodeClicked="TreeNodeClick"></TreeViewEvents>
    </SfTreeView>
</div>
@if (SelectedUnderlyingData != null)
{
    <ObservableDatasView Value="@SelectedUnderlyingData" OnNodeAddion="NodeAdded"/>
}

@code{

    public ObservableCollection<ObservableDatas> ObservableData { get; set; }

    private int UniqueId { get; set; } = 10;
    public string SelectedNode { get; set; }
    public ObservableDatas SelectedUnderlyingData { get; set; }
    public SfTreeView<ObservableDatas> TreeView;

    protected override void OnInitialized()
    {
        ObservableData = ObservableDatas.GetRecords();
    }

    public void TreeNodeClick(NodeClickEventArgs args)
    {
        SelectedNode = args.NodeData.Id;
        foreach (var data in ObservableData)
        {
            if (SelectedUnderlyingData?.Id == SelectedNode)
            {
                break;
            }
            SelectedUnderlyingData = RecurseFindData(data, SelectedNode);
        }
    }

    public void NodeAdded(ObservableDatas node)
    {
        StateHasChanged();
    }

    private ObservableDatas RecurseFindData(ObservableDatas fromData, string dataId)
    {
        if (fromData.Id == dataId)
        {
            return fromData;
        }
        foreach (var child in fromData.Children)
        {
            var result = RecurseFindData(child, dataId);
            if (result != null)
            {
                return result;
            }
        }
        return null;
    }

    private ObservableDatas RecurseFindParent(ObservableDatas potential, string childId)
    {
        foreach (var child in potential.Children)
        {
            if (child.Id == childId)
            {
                return potential;
            }
            else
            {
                var result = RecurseFindParent(child, childId);
                if (result != null)
                    return result;
            }
        }
        return null;
    }
}

<style>
.control_wrapper {
    max-width: 500px;
    margin: auto;
    border: 1px solid #dddddd;
    border-radius: 3px;
    max-height: 470px;
    overflow: auto;
}
</style>
```
```cshtml
@using BlazorTreeView.Data
@using Syncfusion.Blazor.Inputs 
@using Syncfusion.Blazor.Buttons

<div class="col-lg-4 property-section property-custom">
    <div class="property-panel-section">
        <div id="observable" class="property-panel-content">
            <div class="buttonEle">
                <label>Node name:</label> <SfTextBox @bind-Value=@Value.Name />
                <SfButton @onclick="AddNode">Add Child</SfButton>
            </div>
        </div>
    </div>
</div>

@code {

    [Parameter]
    public ObservableDatas Value { get; set; }

    [Parameter]
    public EventCallback<ObservableDatas> OnNodeAddion { get; set; }

    private int UniqueId = 0;

    public async Task AddNode()
    {
        var newId = $"{Value.Id}-{UniqueId++}";
        Value.Children.Add(new ObservableDatas {
            Id = newId,
            Name = $"New node {newId}"
        });

        await OnNodeAddion.InvokeAsync(Value);
    }
}
<style>
    .buttonEle {
        margin-left: 75px;
        margin-top: 10px;
    }
</style>
```
```csharp

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BlazorTreeView.Data
{
    public class ObservableDatas : INotifyPropertyChanged
    {
        public List<ObservableDatas> Children { get; set; } = new List<ObservableDatas>();
        public string Id { get; set; }

        private string _name { get; set; }
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                NotifyPropertyChanged();
            }
        }

        public bool HasChild { get; set; }

        private bool _expanded = false;

        public bool Expanded
        {
            get => _expanded;
            set
            {
                _expanded = value;
                NotifyPropertyChanged();
            }
        }

        public static ObservableCollection<ObservableDatas> GetRecords()
        {
            List<ObservableDatas> ListDataSource = new List<ObservableDatas>();
            List<ObservableDatas> Folder1 = new List<ObservableDatas>();
            ListDataSource.Add(new ObservableDatas
            {
                Id = "01",
                Name = "Inbox",
                Children = Folder1
            });

            List<ObservableDatas> Folder2 = new List<ObservableDatas>();

            Folder1.Add(new ObservableDatas
            {
                Id = "01-01",
                Name = "Categories",
                Children = Folder2
            });
            Folder2.Add(new ObservableDatas
            {
                Id = "01-02",
                Name = "Primary"
            });
            Folder2.Add(new ObservableDatas
            {
                Id = "01-03",
                Name = "Social"
            });
            Folder2.Add(new ObservableDatas
            {
                Id = "01-04",
                Name = "Promotions"
            });

            List<ObservableDatas> Folder3 = new List<ObservableDatas>();

            ListDataSource.Add(new ObservableDatas
            {
                Id = "02",
                Name = "Others",
                Expanded = true,
                Children = Folder3
            });
            List<ObservableDatas> Folder4 = new List<ObservableDatas>();
            Folder3.Add(new ObservableDatas
            {
                Id = "02-01",
                Name = "Sent Items",
                Expanded = true,
                Children = Folder4
            });
            
            Folder4.Add(new ObservableDatas
            {
                Id = "02-02",
                Name = "Delete Items"
            });
            Folder3.Add(new ObservableDatas
            {
                Id = "02-03",
                Name = "Drafts"
            });
            Folder3.Add(new ObservableDatas
            {
                Id = "02-04",
                Name = "Archive"
            });
            return new ObservableCollection<ObservableDatas>(ListDataSource);
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            var handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
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

N> The CRUD operation has been performed in the TreeView component using the context menu.

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

N> The fully working sample can be found [here](https://github.com/SyncfusionExamples/Blazor-treeview-entity-framework).

## Load on demand

The Blazor TreeView has **load on demand** ( lazy loading  ) enabled by default, which reduces the amount of data transmitted over the network when dealing with large amounts of data. It initially loads the first level nodes and, when a parent node is expanded, loads the child nodes based on the **ParentID/Child** member. The [LoadOnDemand](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTreeView-1.html#Syncfusion_Blazor_Navigations_SfTreeView_1_LoadOnDemand) property can be disabled to render all tree nodes at the start, and the [DataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.TreeViewEvents-1.html#Syncfusion_Blazor_Navigations_TreeViewEvents_1_DataBound) event can be used to perform actions after the TreeView's data source has been populated.

### Fetch data from web api on demand

The Blazor TreeView component retrieves data from the server as needed, such as when expanding a parent node to fetch its child nodes, using the DataManager component.

By default the [LoadOnDemand](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTreeView-1.html#Syncfusion_Blazor_Navigations_SfTreeView_1_LoadOnDemand) property is enabled.

In the following example, the `WebApiAdaptor` is used to fetch data from the server side when the load on demand feature is used.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Data
<div class="col-lg-12 control-section">
    <div class="control_wrapper">
        <SfTreeView TValue="NodeResult">
            <TreeViewFieldsSettings TValue="NodeResult"
                                    Id="ProductID"
                                    Text="ProductName"
                                    ParentID="pid"
                                    HasChildren="haschild"
                                    Query="TreeViewQuery">
                <SfDataManager Url="api/Nodes" CrossDomain="true" Adaptor="Syncfusion.Blazor.Adaptors.WebApiAdaptor"></SfDataManager>
            </TreeViewFieldsSettings>
        </SfTreeView>
    </div>
</div>

@code
{
    public Query TreeViewQuery = new Query();
    public class NodeResult
    {
        public int? ProductID { get; set; }
        public string? ProductName { get; set; }
        public int? pid { get; set; }
        public bool haschild { get; set; }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace BlazorTreeView.Controller
{
    [Route("api/[controller]")]
    public class NodesController : ControllerBase
    {      
        [HttpGet]
        public IEnumerable<NodeResult> Get()
        {
           
            List<NodeResult> localData = new List<NodeResult>();
            localData.Add(new NodeResult(1, "Parent", null, true));
            localData.Add(new NodeResult(2, "Child1" , 1, false));
            localData.Add(new NodeResult(3, "Child2" , 1, true));
            localData.Add(new NodeResult(4, "Child3" , 1, false));
            localData.Add(new NodeResult(8, "SubChild1" , 3, false));
            localData.Add(new NodeResult(9, "SubChild2" , 3, false));
            var data = localData.ToList();
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
        public class NodeResult
        {
            public NodeResult(int? ProductID, string ProductName, int? pid, bool haschild)
            {
                this.ProductID = ProductID;
                this.ProductName = ProductName;
                this.pid = pid;
                this.haschild = haschild;
            }
            public int? ProductID { get; set; }
            public string ProductName { get; set; }
            public int? pid { get; set; }
            public bool haschild { get; set; } 
        }
       
    }
}

```

### Disable load on demand

By default, the [LoadOnDemand](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTreeView-1.html#Syncfusion_Blazor_Navigations_SfTreeView_1_LoadOnDemand) property is enabled in the Blazor TreeView component, but when it is set to false, all the tree nodes are rendered at the initial rendering.

In the following example, the [LoadOnDemand](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfTreeView-1.html#Syncfusion_Blazor_Navigations_SfTreeView_1_LoadOnDemand) property is disabled.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Data
<div class="col-lg-12 control-section">
    <div class="control_wrapper">
        <SfTreeView TValue="NodeResult" LoadOnDemand="false">
            <TreeViewFieldsSettings TValue="NodeResult"
                                    Id="ProductID"
                                    Text="ProductName"
                                    ParentID="pid"
                                    HasChildren="haschild"
                                    Query="TreeViewQuery">
                <SfDataManager Url="api/Nodes" CrossDomain="true" Adaptor="Syncfusion.Blazor.Adaptors.WebApiAdaptor"></SfDataManager>
            </TreeViewFieldsSettings>
        </SfTreeView>
    </div>
</div>

@code
{
    public Query TreeViewQuery = new Query();
    public class NodeResult
    {
        public int? ProductID { get; set; }
        public string? ProductName { get; set; }
        public int? pid { get; set; }
        public bool haschild { get; set; }
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace BlazorTreeView.Controller
{
    [Route("api/[controller]")]
    public class NodesController : ControllerBase
    {      
        [HttpGet]
        public IEnumerable<NodeResult> Get()
        {
           
            List<NodeResult> localData = new List<NodeResult>();
            localData.Add(new NodeResult(1, "Parent", null, true));
            localData.Add(new NodeResult(2, "Child1" , 1, false));
            localData.Add(new NodeResult(3, "Child2" , 1, true));
            localData.Add(new NodeResult(4, "Child3" , 1, false));
            localData.Add(new NodeResult(8, "SubChild1" , 3, false));
            localData.Add(new NodeResult(9, "SubChild2" , 3, false));
            var data = localData.ToList();
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
        public class NodeResult
        {
            public NodeResult(int? ProductID, string ProductName, int? pid, bool haschild)
            {
                this.ProductID = ProductID;
                this.ProductName = ProductName;
                this.pid = pid;
                this.haschild = haschild;
            }
            public int? ProductID { get; set; }
            public string ProductName { get; set; }
            public int? pid { get; set; }
            public bool haschild { get; set; } 
        }
       
    }
}

```

### Render more nodes with more levels

By default, the TreeView component includes performance optimization features. Additionally, the LoadOnDemand feature can be used to enhance performance and reduce the amount of data transmitted when working with large amounts of data.

In this example, a tree node is being rendered with 25 levels of child nodes.

```cshtml
@using Syncfusion.Blazor.Navigations
<SfTreeView TValue="MailItem">
    <TreeViewFieldsSettings TValue="MailItem" Id="ID" DataSource="@MyFolder" Text="FolderName" ParentID="ParentId" HasChildren="HasSubFolders" Expanded="Expanded"></TreeViewFieldsSettings>
</SfTreeView>

@code {
    public class MailItem
    {
        public string ID { get; set; }
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
                ID = "1",
                FolderName = "Parent",
                HasSubFolders = true,
                Expanded = true
            });
        MyFolder.Add(new MailItem
            {
                ID = "2",
                ParentId = "1",
                FolderName = "Child 1",
                HasSubFolders = true,
                Expanded = true
            });
        MyFolder.Add(new MailItem
            {
                ID = "3",
                ParentId = "2",
                FolderName = "Child 2",
                HasSubFolders = true,
                Expanded = true
            });
        MyFolder.Add(new MailItem
            {
                ID = "4",
                ParentId = "3",
                FolderName = "Child 3",
                HasSubFolders = true,
                Expanded = true
            });
        MyFolder.Add(new MailItem
            {
                ID = "5",
                ParentId = "4",
                FolderName = "Child 4",
                HasSubFolders = true,
                Expanded = true
            });
        MyFolder.Add(new MailItem
            {
                ID = "6",
                ParentId = "5",
                FolderName = "Child 5",
                HasSubFolders = true,
                Expanded = true
            });
        MyFolder.Add(new MailItem
            {
                ID = "7",
                ParentId = "6",
                FolderName = "Child 6",
                HasSubFolders = true,
                Expanded = true
            });
        MyFolder.Add(new MailItem
            {
                ID = "8",
                ParentId = "7",
                FolderName = "Child 7",
                HasSubFolders = true,
                Expanded = true
            });
        MyFolder.Add(new MailItem
            {
                ID = "9",
                ParentId = "8",
                FolderName = "Child 8",
                HasSubFolders = true,
                Expanded = true
            });
        MyFolder.Add(new MailItem
            {
                ID = "10",
                ParentId = "9",
                FolderName = "Child 9",
                HasSubFolders = true,
                Expanded = true
            });
        MyFolder.Add(new MailItem
            {
                ID = "11",
                ParentId = "10",
                FolderName = "Child 10",
                HasSubFolders = true,
                Expanded = true
            });
        MyFolder.Add(new MailItem
            {
                ID = "12",
                ParentId = "11",
                FolderName = "Child 11",
                HasSubFolders = true,
                Expanded = true
            });
        MyFolder.Add(new MailItem
            {
                ID = "13",
                ParentId = "12",
                FolderName = "Child 12",
                HasSubFolders = true,
                Expanded = true
            });
        MyFolder.Add(new MailItem
            {
                ID = "14",
                ParentId = "13",
                FolderName = "Child 13",
                HasSubFolders = true,
                Expanded = true
            });
        MyFolder.Add(new MailItem
            {
                ID = "15",
                ParentId = "14",
                FolderName = "Child 14",
                HasSubFolders = true,
                Expanded = true
            });
        MyFolder.Add(new MailItem
            {
                ID = "16",
                ParentId = "15",
                FolderName = "Child 15",
                HasSubFolders = true,
                Expanded = true
            });
        MyFolder.Add(new MailItem
            {
                ID = "17",
                ParentId = "16",
                FolderName = "Child 16",
                HasSubFolders = true,
                Expanded = true
            });
        MyFolder.Add(new MailItem
            {
                ID = "18",
                ParentId = "17",
                FolderName = "Child 17",
                HasSubFolders = true,
                Expanded = true
            });
        MyFolder.Add(new MailItem
            {
                ID = "19",
                ParentId = "18",
                FolderName = "Child 18",
                HasSubFolders = true,
                Expanded = true
            });
        MyFolder.Add(new MailItem
            {
                ID = "20",
                ParentId = "19",
                FolderName = "Child 19",
                HasSubFolders = true,
                Expanded = true
            });
        MyFolder.Add(new MailItem
            {
                ID = "21",
                ParentId = "20",
                FolderName = "Child 20",
                HasSubFolders = true,
                Expanded = true
            });
        MyFolder.Add(new MailItem
            {
                ID = "22",
                ParentId = "21",
                FolderName = "Child 21",
                HasSubFolders = true,
                Expanded = true
            });
        MyFolder.Add(new MailItem
            {
                ID = "23",
                ParentId = "22",
                FolderName = "Child 22",
                HasSubFolders = true,
                Expanded = true
            });
        MyFolder.Add(new MailItem
            {
                ID = "24",
                ParentId = "23",
                FolderName = "Child 23",
                HasSubFolders = true,
                Expanded = true
            });
        MyFolder.Add(new MailItem
            {
                ID = "25",
                ParentId = "24",
                FolderName = "Child 24",
                HasSubFolders = true,
                Expanded = true
            });
        MyFolder.Add(new MailItem
            {
                ID = "26",
                ParentId = "25",
                FolderName = "Child 25",
            });
    }
}
```

## Render nodes with GUID

The Blazor TreeView component allows you to render tree nodes with a **GUID**. The Id field in the TreeView component is a string data type, so the GUID must be passed as a string.

```cshtml
@using Syncfusion.Blazor.Navigations
<SfTreeView TValue="DriveData" SelectedNodes="@SelectedNodes">
    <TreeViewFieldsSettings TValue="DriveData" Id="NodeId" Text="NodeText" Child="Children" DataSource="@Drive" Expanded="Expanded"></TreeViewFieldsSettings>
</SfTreeView>

@code {
    public string[] SelectedNodes = new string[] { "9245fe4a-d402-451c-b9ed-9c1a04247482" };
    public class DriveData
    {
        public Guid NodeId { get; set; }
        public string NodeText { get; set; }
        public bool Expanded { get; set; }
        public bool Selected { get; set; }
        public List<DriveData> Children;
    }

    object Child;
    List<DriveData> Drive = new List<DriveData>();
    protected override void OnInitialized()
    {
        base.OnInitialized();
        List<DriveData> Folder1 = new List<DriveData>();

        Drive.Add(new DriveData
            {
                NodeId = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247482"),
                NodeText = "Local Disk (C:)",
                Children = Folder1,
            });

        List<DriveData> File1 = new List<DriveData>();

        Folder1.Add(new DriveData
            {
                NodeId = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247483"),
                NodeText = "Program Files",
                Children = File1
            });
        File1.Add(new DriveData
            {
                NodeId = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247484"),
                NodeText = "Windows NT"
            });

        List<DriveData> File2 = new List<DriveData>();

        Folder1.Add(new DriveData
            {
                NodeId = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247485"),
                NodeText = "Users",
                Expanded = true,
                Children = File2
            });
        File2.Add(new DriveData
            {
                NodeId = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247486"),
                NodeText = "Smith"
            });

        List<DriveData> File3 = new List<DriveData>();

        Folder1.Add(new DriveData
            {
                NodeId = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247487"),
                NodeText = "Windows",
                Children = File3
            });
        File3.Add(new DriveData
            {
                NodeId = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247488"),
                NodeText = "Boot"
            });

        List<DriveData> Folder2 = new List<DriveData>();

        Drive.Add(new DriveData
            {
                NodeId = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247489"),
                NodeText = "Local Disk (D:)",
                Children = Folder2,
                Expanded = true,
            });

        List<DriveData> File4 = new List<DriveData>();

        Folder2.Add(new DriveData
            {
                NodeId = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247490"),
                NodeText = "Personals"
            });
        Folder2.Add(new DriveData
            {
                NodeId = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247491"),
                NodeText = "Projects"
            });
        Folder2.Add(new DriveData
            {
                NodeId = new Guid("9245fe4a-d402-451c-b9ed-9c1a04247492"),
                NodeText = "Office"
            });
    }
}

```
