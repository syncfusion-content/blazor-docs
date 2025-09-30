---
layout: post
title: Data Binding in Blazor Dropdown Tree Component | Syncfusion
description: Checkout and learn here all about Data Binding in Syncfusion Blazor Dropdown Tree component and much more.
platform: Blazor
control: Dropdown Tree
documentation: ug
---

# Data Binding in Blazor Dropdown Tree Component

The Blazor Dropdown Tree component offers flexible options for loading data from various sources, including local data collections and remote data services. Data binding is configured primarily through the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.DropDownTreeField-1.html#Syncfusion_Blazor_Navigations_DropDownTreeField_1_DataSource) property, which is part of the [`DropDownTreeField`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.DropDownTreeField-1.html#constructors) tag. The `DataSource` supports lists of objects and [`DataManager`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Data.SfDataManager.html), enabling connectivity to diverse data services like OData, OData V4, Web API, URL, and JSON through `DataManager` adaptors.

## Binding Local Data

To bind local data, assign a list of objects to the `DataSource` property. The Blazor Dropdown Tree component requires specific fields for rendering: [`ID`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.DropDownTreeField-1.html#Syncfusion_Blazor_Navigations_DropDownTreeField_1_ID), [`Text`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.DropDownTreeField-1.html#Syncfusion_Blazor_Navigations_DropDownTreeField_1_Text), and typically [`ParentID`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.DropDownTreeField-1.html#Syncfusion_Blazor_Navigations_DropDownTreeField_1_ParentID) or [`Child`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.DropDownTreeField-1.html#Syncfusion_Blazor_Navigations_DropDownTreeField_1_Child) for hierarchical structures. If mapper fields are not explicitly specified, the component uses default values for mapping. Local data can be structured in two primary ways:

* Hierarchical Data

* Self-Referential Data

### Hierarchical Data

The Blazor Dropdown Tree can be populated using a hierarchical data source, which contains a nested list of objects. This type of data can be directly assigned to the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.DropDownTreeField-1.html#Syncfusion_Blazor_Navigations_DropDownTreeField_1_DataSource) property. Map the object's members to the corresponding fields within the [DropDownTreeField](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.DropDownTreeField-1.html#constructors) properties.

In the following example, **Id**, **FolderName**, and **SubFolders** columns from hierarchical data have been mapped to [`ID`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.DropDownTreeField-1.html#Syncfusion_Blazor_Navigations_DropDownTreeField_1_ID), [`Text`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.DropDownTreeField-1.html#Syncfusion_Blazor_Navigations_DropDownTreeField_1_Text), and [`Child`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.DropDownTreeField-1.html#Syncfusion_Blazor_Navigations_DropDownTreeField_1_Child) fields, respectively.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfDropDownTree TValue="string" TItem="MailItem" Placeholder="Select a Folder" Width="500px">
    <DropDownTreeField TItem="MailItem" ID="Id" Text="FolderName" Child="SubFolders" DataSource="@MyFolder" Expanded="Expanded"></DropDownTreeField>
</SfDropDownTree>

@code {
    public class MailItem
    {
        public string? Id { get; set; }
        public string? FolderName { get; set; }
        public bool Expanded { get; set; }
        public List<MailItem>? SubFolders { get; set; }
    }

    List<MailItem> MyFolder = new List<MailItem>()
    {
        new MailItem
        {
            Id = "01",
            FolderName = "Inbox",
            SubFolders = new List<MailItem>()
            {
                new MailItem
                {
                    Id = "01-01",
                    FolderName = "Categories",
                    SubFolders = new List<MailItem>()
                    {
                        new MailItem
                        {
                            Id = "01-02",
                            FolderName = "Primary"
                        },
                        new MailItem
                        {
                            Id = "01-03",
                            FolderName = "Social"
                        },
                        new MailItem
                        {
                            Id = "01-04",
                            FolderName = "Promotions"
                        }
                    }
                }
            }
        },
        new MailItem
        {
            Id = "02",
            FolderName = "Others",
            Expanded = true,
            SubFolders = new List<MailItem>()
            {
                new MailItem
                {
                    Id = "02-01",
                    FolderName = "Sent Items"
                },
                new MailItem
                {
                    Id = "02-02",
                    FolderName = "Delete Items"
                },
                new MailItem
                {
                    Id = "02-03",
                    FolderName = "Drafts"
                }
            }
        }
    };
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BXLojaLHUqxyGYsX?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Dropdown Tree Component](./images/hierarchical-data.png)" %}

### Self-Referential Data

Blazor Dropdown Tree can be populated from self-referential data structure that contains list of objects with [`ParentID`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.DropDownTreeField-1.html#Syncfusion_Blazor_Navigations_DropDownTreeField_1_ParentID) mapping. The self-referential data can be directly assigned to the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.DropDownTreeField-1.html#Syncfusion_Blazor_Navigations_DropDownTreeField_1_DataSource) property, and map all the field members with corresponding keys from self-referential data to [`Fields`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.DropDownTreeField-1.html#constructors) property.

To correctly render the root-level nodes, ensure their `ParentID` is either `null` or not specified in the `DataSource`. In the following example, the **Id**, **ParentId**, **HasSubFolders**, and **FolderName** columns are mapped to [`ID`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.DropDownTreeField-1.html#Syncfusion_Blazor_Navigations_DropDownTreeField_1_ID), [`ParentID`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.DropDownTreeField-1.html#Syncfusion_Blazor_Navigations_DropDownTreeField_1_ParentID), [`HasChildren`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.DropDownTreeField-1.html#Syncfusion_Blazor_Navigations_DropDownTreeField_1_HasChildren), and [`Text`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.DropDownTreeField-1.html#Syncfusion_Blazor_Navigations_DropDownTreeField_1_Text) fields, respectively.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfDropDownTree TValue="string" TItem="MailItem" Placeholder="Select a Folder" Width="500px">
    <DropDownTreeField TItem="MailItem" ID="Id" DataSource="@MyFolder" Text="FolderName" ParentID="ParentId" HasChildren="HasSubFolders" Expanded="Expanded"></DropDownTreeField>
</SfDropDownTree>

@code {
    List<MailItem> MyFolder = new List<MailItem>
    {
        new MailItem { Id = "1", FolderName = "Inbox", HasSubFolders = true, Expanded = false },
        new MailItem { Id = "2", ParentId = "1", FolderName = "Categories", HasSubFolders = true, Expanded = false },
        new MailItem { Id = "3", ParentId = "2", FolderName = "Primary", HasSubFolders = false, Expanded = false },
        new MailItem { Id = "4", ParentId = "2", FolderName = "Social", HasSubFolders = false, Expanded = false },
        new MailItem { Id = "5", ParentId = "2", FolderName = "Promotions", HasSubFolders = false, Expanded = false },
        new MailItem { Id = "6", FolderName = "Others", HasSubFolders = true, Expanded = true },
        new MailItem { Id = "7", ParentId = "6", FolderName = "Sent Items", HasSubFolders = false, Expanded = false },
        new MailItem { Id = "8", ParentId = "6", FolderName = "Delete Items", HasSubFolders = false, Expanded = false },
        new MailItem { Id = "9", ParentId = "6", FolderName = "Drafts", HasSubFolders = false, Expanded = false },
        new MailItem { Id = "10", ParentId = "6", FolderName = "Archive", HasSubFolders = false, Expanded = false }
    };

    public class MailItem
    {
        public string? Id { get; set; }
        public string? ParentId { get; set; }
        public string? FolderName { get; set; }
        public bool Expanded { get; set; }
        public bool HasSubFolders { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/VjBojYrnUUbOEdzK?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Dropdown Tree Component](./images/hierarchical-data.png)" %}

### ExpandoObject Binding

The Blazor Dropdown Tree is a generic component typically strongly bound to a specific model type. However, when the model structure is unknown at compile time, the Dropdown Tree can be bound to a list of `ExpandoObjects` instances using the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.DropDownTreeField-1.html#Syncfusion_Blazor_Navigations_DropDownTreeField_1_DataSource) property. This allows the Dropdown Tree to perform all supported data operations.

```cshtml
@using Syncfusion.Blazor.Navigations
@using System.Dynamic

<SfDropDownTree TValue="string" TItem="ExpandoObject" Placeholder="Select a Item">
    <DropDownTreeField TItem="ExpandoObject" ID="ID" DataSource="@TreeData" Text="Name" ParentID="ParentID" HasChildren="HasChildren" Expanded="Expanded"></DropDownTreeField>
</SfDropDownTree>

@code {
    public List<ExpandoObject>? TreeData { get; set; }

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
            ParentRecord.HasChildren = true;
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
{% previewsample "https://blazorplayground.syncfusion.com/embed/hjhIjkVxKTtLGsfj?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Dropdown Tree Component](./images/expand-object.png)" %}

### DynamicObject Binding

Similar to `ExpandoObject`, when the model type is not known at compile time, data can be bound to the Dropdown Tree as a list of `DynamicObject` instances. The Dropdown Tree supports all data operations on `DynamicObject` when they are assigned to the `DataSource` property.

```cshtml
@using Syncfusion.Blazor.Navigations
@using System.Dynamic

<SfDropDownTree TValue="string" TItem="DynamicDictionary" Placeholder="Select a Item">
    <DropDownTreeField TItem="DynamicDictionary" ID="ID" DataSource="@TreeData" Text="Name" ParentID="ParentID" HasChildren="HasChildren" Expanded="Expanded"></DropDownTreeField>
</SfDropDownTree>

@code {
    public List<DynamicDictionary>? TreeData { get; set; }
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
            ParentRecord.HasChildren = true;
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
{% previewsample "https://blazorplayground.syncfusion.com/embed/hZByZuLdqTizPGFQ?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Dropdown Tree Component](./images/expand-object.png)" %}

## Binding Remote Data

The Blazor Dropdown Tree can also be populated from a remote data service using the [`DataManager`](https://blazor.syncfusion.com/documentation/data/getting-started) component and [`Query`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.DropDownTreeField-1.html#Syncfusion_Blazor_Navigations_DropDownTreeField_1_Query) property. It supports various data services such as OData, OData V4, Web API, URL, and JSON through `DataManager` adaptors. To interact with a remote data source, assign a `DataManager` instance to the [`DataSource`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.DropDownTreeField-1.html#Syncfusion_Blazor_Navigations_DropDownTreeField_1_DataSource) property. To interact with remote data source, provide the endpoint `url`.

The `DataManager` acts as an interface between the service endpoint and the Dropdown Tree, requiring the following information for proper interaction:

* `DataManager->url`: Defines the service endpoint to fetch data.

* `DataManager->adaptor`: Defines the adaptor option. By default, ODataAdaptor is used for remote binding.

Adaptors are responsible for processing requests to and responses from the service endpoint. `Syncfusion.Blazor.Data` provides several predefined adaptors:

* `UrlAdaptor`: Used for interacting with general remote services. This is the base adaptor for all remote-based adaptors.

* `ODataAdaptor`: Specifically designed for interacting with OData endpoints.

* `ODataV4Adaptor`: Specifically designed for interacting with OData V4 endpoints.

* `WebApiAdaptor`: Used for interacting with Web APIs that adhere to OData standards.

* `WebMethodAdaptor`: Used for interacting with web methods.

### Binding with OData Services

In the following example, `ODataAdaptor` is used to fetch data from a remote OData service. The entire data set will be returned in the initial request.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Data

<SfDropDownTree TValue="int?" TItem="TreeData" Placeholder="Select an employee" Width="500px">
    <DropDownTreeField TItem="TreeData" Query="@Query" ID="EmployeeID" Text="FirstName" ParentID="ReportsTo" HasChildren="HasChildren">
        <SfDataManager Url="https://blazor.syncfusion.com/services/production/odata/DropDownTreeOData" Adaptor="@Syncfusion.Blazor.Adaptors.ODataAdaptor" CrossDomain="true"></SfDataManager>
    </DropDownTreeField>
</SfDropDownTree>

@code {
    public Query Query = new Query();
    public class TreeData
    {
        public string EmployeeID { get; set; }
        public string ReportsTo { get; set; }
        public string FirstName { get; set; }
        public string Designation { get; set; }
        public string Country { get; set; }
        public bool HasChildren { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/hZByjarHgTBChoLg?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Dropdown Tree Component](./images/odata-service.png)" %}

### Binding with OData V4 Services

In the following example, `ODataV4Adaptor` is used to fetch data from a remote OData V4 service. The entire data set will be returned in the initial request.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Data

<SfDropDownTree TValue="int?" TItem="TreeData" Placeholder="Select an employee" Width="500px">
    <DropDownTreeField TItem="TreeData" Query="@Query" ID="EmployeeID" Text="FirstName" ParentID="ReportsTo" HasChildren="HasChildren">
        <SfDataManager Url="https://blazor.syncfusion.com/services/production/odata/DropDownTreeODataV4" Adaptor="@Syncfusion.Blazor.Adaptors.ODataV4Adaptor" CrossDomain="true"></SfDataManager>
    </DropDownTreeField>
</SfDropDownTree>

@code {
    public Query Query = new Query();
    public class TreeData
    {
        public string EmployeeID { get; set; }
        public string ReportsTo { get; set; }
        public string FirstName { get; set; }
        public string Designation { get; set; }
        public string Country { get; set; }
        public bool HasChildren { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rZLINaBdgzAiVpSe?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Dropdown Tree Component](./images/odata-service.png)" %}

### Web API Adaptor

In the following example, `WebApiAdaptor` is  used to fetch data from server side. In the initial request, entire data will be returned.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Data

<SfDropDownTree TValue="int?" TItem="NodeResult" Placeholder="Select an employee" Width="500px">
    <DropDownTreeField TItem="NodeResult" Query="@TreeViewQuery" ID="ProductID" Text="ProductName" ParentID="pid" HasChildren="haschild">
        <SfDataManager Url="api/Nodes" CrossDomain="true" Adaptor="Syncfusion.Blazor.Adaptors.WebApiAdaptor"></SfDataManager>
    </DropDownTreeField>
</SfDropDownTree>

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
```

```csharp
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace DropDownTreeSample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NodesController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<NodeResult> Get()
        {
            List<NodeResult> localData = new List<NodeResult>()
            {
                new NodeResult { ProductID = 1, ProductName = "Parent", pid = null, haschild = true },
                new NodeResult { ProductID = 2, ProductName = "Child1", pid = 1, haschild = false },
                new NodeResult { ProductID = 3, ProductName = "Child2", pid = 1, haschild = true },
                new NodeResult { ProductID = 4, ProductName = "Child3", pid = 1, haschild = false },
                new NodeResult { ProductID = 5, ProductName = "SubChild1", pid = 3, haschild = false },
                new NodeResult { ProductID = 6, ProductName = "SubChild2", pid = 3, haschild = false },
            };
            var data = localData.ToList();
            return data;
        }

        public class NodeResult
        {
            public int? ProductID { get; set; }
            public string ProductName { get; set; }
            public int? pid { get; set; }
            public bool haschild { get; set; }
        }
    }
}
```

## Observable Collection

The Blazor Dropdown Tree component supports `ObservableCollection` for dynamic updates. An `ObservableCollection` provides notifications of changes to the collection, such as when items are added, removed, or updated. It implements `INotifyCollectionChanged` to notify dynamic changes to the collection and `INotifyPropertyChanged` to notify property value changes on the client side.

```cshtml
@using Syncfusion.Blazor.Navigations
@using System.Collections.ObjectModel
@using DropDownTreeSample.Data

<div class="control_wrapper">
    <SfDropDownTree TValue="string" TItem="ObservableDatas" Placeholder="Select a Item" ValueChanging="TreeNodeClick">
        <DropDownTreeField TItem="ObservableDatas" DataSource="@ObservableData" ID="@nameof(ObservableDatas.Id)" Child="@nameof(ObservableDatas.Children)" Text="@nameof(ObservableDatas.Name)" HasChildren="@nameof(ObservableDatas.HasChild)" Expanded="@nameof(ObservableDatas.Expanded)"></DropDownTreeField>
    </SfDropDownTree>
</div>

@if (SelectedUnderlyingData != null)
{
    <ObservableDatasView Value="@SelectedUnderlyingData" OnNodeAddition="NodeAdded" />
}

@code {

    public ObservableCollection<ObservableDatas> ObservableData { get; set; }

    private int UniqueId { get; set; } = 10;
    public string SelectedNode { get; set; }
    public ObservableDatas SelectedUnderlyingData { get; set; }
    public SfTreeView<ObservableDatas> TreeView;

    protected override void OnInitialized()
    {
        ObservableData = ObservableDatas.GetRecords();
    }

    public void TreeNodeClick(DdtChangeEventArgs<string> args)
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
        if (fromData.Children == null)
            return null;
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
@using DropDownTreeSample.Data
@using Syncfusion.Blazor.Inputs
@using Syncfusion.Blazor.Buttons

<div class="col-lg-4 property-section property-custom">
    <div class="property-panel-section">
        <div id="observable" class="property-panel-content">
            <div class="buttonEle">
                <label>Node name:</label>
                <SfTextBox @bind-Value=@Value.Name />
                <SfButton @onclick="AddNode">Add Child</SfButton>
            </div>
        </div>
    </div>
</div>

@code {

    [Parameter]
    public ObservableDatas Value { get; set; }

    [Parameter]
    public EventCallback<ObservableDatas> OnNodeAddition { get; set; }

    private int UniqueId = 0;

    public async Task AddNode()
    {
        var newId = $"{Value.Id}-{UniqueId++}";
        if (Value.Children == null)
        {
            Value.Children = new List<ObservableDatas>();
        }
        Value.Children.Add(new ObservableDatas
        {
            Id = newId,
            Name = $"New node {newId}"
        });

        await OnNodeAddition.InvokeAsync(Value);
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

using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace DropDownTreeSample.Data
{
    public class ObservableDatas : INotifyPropertyChanged
    {
        public List<ObservableDatas> Children { get; set; }
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

### Entity Framework

Follow these steps to consume data from the [Entity Framework](https://blazor.syncfusion.com/documentation/common/data-binding/bind-entity-framework) in the Dropdown Tree component.

#### Create DBContext Class

First, create a `AppDBContext` class to establish a connection to a Microsoft SQL Server database.

```csharp
using Microsoft.EntityFrameworkCore;

namespace DBTree.Data
{
    public class AppDBContext : DbContext
    {
        public AppDBContext()
        {
        }

        public AppDBContext(DbContextOptions<AppDBContext> options)
            : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                // To make the sample runnable, replace your DB name here
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=DBTree;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>().HasData(
                new Employee() { Id = 1, Name = "Steven Buchanan", Job = "General Manager", HasChild = true, Expanded = true },
                new Employee() { Id = 2, PId = 1, Name = "Laura Callahan", Job = "Product Manager", HasChild = true },
                new Employee() { Id = 3, PId = 2, Name = "Andrew Fuller", Job = "Team Lead", HasChild = true },
                new Employee() { Id = 4, PId = 3, Name = "Anne Dodsworth", Job = "Developer" },
                new Employee() { Id = 10, PId = 3, Name = "Lilly", Job = "Developer" },
                new Employee() { Id = 5, PId = 1, Name = "Nancy Davolio", Job = "Product Manager", HasChild = true },
                new Employee() { Id = 6, PId = 5, Name = "Michael Suyama", Job = "Team Lead", HasChild = true },
                new Employee() { Id = 7, PId = 6, Name = "Robert King", Job = "Developer" },
                new Employee() { Id = 11, PId = 6, Name = "Mary", Job = "Developer" },
                new Employee() { Id = 9, PId = 1, Name = "Janet Leverling", Job = "HR" }
            );
        }
    }
}
```

#### Create Data Access Layer to Perform Data Operation

Next, create an `EmployeeDataAccessLayer` class to act as a data access layer for retrieving records from the database.

```csharp
using Microsoft.EntityFrameworkCore;

namespace DBTree.Data
{
    public class EmployeeDataAccessLayer
    {
        AppDBContext db = new();

        // returns the employee data from the data base
        public DbSet<Employee> GetAllEmployees()
        {
            try
            {
                return db.Employees;
            }
            catch
            {
                throw;
            }
        }
    }
}
```

#### Create Web API Controller

Create a Web API Controller that allows the Dropdown Tree to directly consume data from Entity Framework. In the initial request, the entire data set will be returned.

```csharp
using DBTree.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Primitives;

namespace DBTree.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        EmployeeDataAccessLayer db = new EmployeeDataAccessLayer();
        [HttpGet("{id}")]
        public object Get()
        {
            // Get the DataSource from Database
            var data = db.GetAllEmployees().ToList();
            return data;
        }
    }
}
```

#### Configure Blazor Dropdown Tree component using Web API Adaptor

Finally, configure the Blazor Dropdown Tree component using `SfDataManager` to interact with the created Web API and consume the data appropriately. Use `WebApiAdaptor` for this purpose.

```csharp

@using Syncfusion.Blazor
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Data

<SfDropDownTree TValue="int" TItem="Employee" Placeholder="Select a Employee">
    <DropDownTreeField TItem="Employee" ID="Id" Text="Name" ParentID="PId" HasChildren="HasChild" Expanded="Expanded">
        <SfDataManager Url="api/Default" Adaptor="Adaptors.WebApiAdaptor" CrossDomain="true"></SfDataManager>
    </DropDownTreeField>
</SfDropDownTree>

@code {
    public class Employee
    {
        public int Id { get; set; }
        public int? PId { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public bool HasChild { get; set; }
        public bool Expanded { get; set; }
    }
}

```

## Adding New Items

Dropdown Tree items can be added or removed dynamically by modifying the **DataSource** collection.

In the following demo, initially, five tree items are rendered. Clicking the `Add Data` button adds a new item to the **DataSource**, which the Dropdown Tree then reflects.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons

<SfButton OnClick="AddData">Add Data</SfButton>
<SfDropDownTree TItem="EmployeeData" TValue="string" Placeholder="Select an employee" Width="500px" LoadOnDemand="true">
    <DropDownTreeField TItem="EmployeeData" DataSource="Data" ID="Id" Text="Name" HasChildren="HasChild" ParentID="PId"></DropDownTreeField>
</SfDropDownTree>

@code {
    List<EmployeeData> Data = new List<EmployeeData>
    {
        new EmployeeData() { Id = "1", Name = "Steven Buchanan", Job = "General Manager", HasChild = true, Expanded = true },
        new EmployeeData() { Id = "2", PId = "1", Name = "Laura Callahan", Job = "Product Manager" },
        new EmployeeData() { Id = "3", Name = "Andrew Fuller", Job = "Team Lead", HasChild = true },
        new EmployeeData() { Id = "4", PId = "3", Name = "Anne Dodsworth", Job = "Developer" },
        new EmployeeData() { Id = "10", PId = "3", Name = "Lilly", Job = "Developer" }
    };

    void AddData()
    {
        Data.Add(new EmployeeData() { Id = "5", PId = "3", Name = "Jack", Job = "Developer" });
    }
    class EmployeeData
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Job { get; set; }
        public bool HasChild { get; set; }
        public bool Expanded { get; set; }
        public string? PId { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rZLoXYhdUfdfPZGN?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Dropdown Tree Component](./images/add-newitem.png)" %}

## Load On Demand

The Blazor Dropdown Tree features `load on demand` (lazy loading) capability, which significantly reduces bandwidth usage when dealing with large datasets. It initially loads only the first-level nodes. Child nodes are then loaded dynamically only when their parent node is expanded, based on the `ParentID`/`Child` member. By default, `LoadOnDemand` is set to `false`.

In the following example, the [LoadOnDemand](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfDropDownTree-2.html#Syncfusion_Blazor_Navigations_SfDropDownTree_2_LoadOnDemand) property is enabled.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfDropDownTree TItem="EmployeeData" TValue="string" Placeholder="Select an employee" Width="500px" LoadOnDemand="true">
    <DropDownTreeField TItem="EmployeeData" DataSource="Data" ID="Id" Text="Name" HasChildren="HasChild" ParentID="PId"></DropDownTreeField>
</SfDropDownTree>

@code {
    List<EmployeeData> Data = new List<EmployeeData>
    {
        new EmployeeData() { Id = "1", Name = "Steven Buchanan", Job = "General Manager", HasChild = true, Expanded = true },
        new EmployeeData() { Id = "2", PId = "1", Name = "Laura Callahan", Job = "Product Manager", HasChild = true },
        new EmployeeData() { Id = "3", PId = "2", Name = "Andrew Fuller", Job = "Team Lead", HasChild = true },
        new EmployeeData() { Id = "4", PId = "3", Name = "Anne Dodsworth", Job = "Developer" },
        new EmployeeData() { Id = "10", PId = "3", Name = "Lilly", Job = "Developer" },
        new EmployeeData() { Id = "5", PId = "1", Name = "Nancy Davolio", Job = "Product Manager", HasChild = true },
        new EmployeeData() { Id = "6", PId = "5", Name = "Michael Suyama", Job = "Team Lead", HasChild = true },
        new EmployeeData() { Id = "7", PId = "6", Name = "Robert King", Job = "Developer" },
        new EmployeeData() { Id = "11", PId = "6", Name = "Mary", Job = "Developer" },
        new EmployeeData() { Id = "9", PId = "1", Name = "Janet Leverling", Job = "HR"}
    };

    class EmployeeData
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Job { get; set; }
        public bool HasChild { get; set; }
        public bool Expanded { get; set; }
        public string? PId { get; set; }
    }
}
```
{% previewsample "https://blazorplayground.syncfusion.com/embed/rZBetOBxqzwmeBTp?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Dropdown Tree Component](./images/loadon-demand.png)" %}

## Retrieving Tree View Data

The [GetTreeViewData](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfDropDownTree-2.html#Syncfusion_Blazor_Navigations_SfDropDownTree_2_GetTreeViewData_System_String_) method can be used to retrieve the complete node details of the tree rendered in the Dropdown Tree popup or to retrieve specific node details by passing its corresponding ID.

In the example below, clicking the `Get Tree Data` button retrieves the `Name` and `Job` details associated with the `Id` '11' and displays them.

```cshtml

@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Buttons
<SfButton OnClick="GetData">Get TreeData</SfButton>

<SfDropDownTree @ref="tree" TItem="EmployeeData" TValue="string" Placeholder="Select an employee" Width="500px">
    <DropDownTreeField TItem="EmployeeData" DataSource="Data" ID="Id" Text="Name" HasChildren="HasChild" ParentID="PId" Selected="Selected" IsChecked="IsChecked"></DropDownTreeField>

</SfDropDownTree>
<span>@EmployeeList</span>

@code {
    SfDropDownTree<string, EmployeeData>? tree;
    List<EmployeeData> Data = new List<EmployeeData>
    {
        new EmployeeData() { Id = "1", Name = "Steven Buchanan", Job = "General Manager", HasChild = true, Expanded = true},
        new EmployeeData() { Id = "2", PId = "1", Name = "Laura Callahan", Job = "Product Manager", HasChild = true },
        new EmployeeData() { Id = "3", PId = "2", Name = "Andrew Fuller", Job = "Team Lead", HasChild = true },
        new EmployeeData() { Id = "4", PId = "3", Name = "Anne Dodsworth", Job = "Developer" },
        new EmployeeData() { Id = "10", PId = "3", Name = "Lilly", Job = "Developer" },
        new EmployeeData() { Id = "5", PId = "1", Name = "Nancy Davolio", Job = "Product Manager", HasChild = true },
        new EmployeeData() { Id = "6", PId = "5", Name = "Michael Suyama", Job = "Team Lead", HasChild = true },
        new EmployeeData() { Id = "7", PId = "6", Name = "Robert King", Job = "Developer" },
        new EmployeeData() { Id = "11", PId = "6", Name = "Mary", Job = "Developer" },
        new EmployeeData() { Id = "9", PId = "1", Name = "Janet Leverling", Job = "HR"}
    };
    string EmployeeList { get; set; } = "";

    public void GetData()
    {
        List<EmployeeData> employees = tree.GetTreeViewData("11");

        // Concatenate the names of employees into a single string
        EmployeeList = string.Join(", ", employees.Select(e => $"{e.Name} ({e.Job})"));
    }
    class EmployeeData
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public string? Job { get; set; }
        public bool HasChild { get; set; }
        public bool Expanded { get; set; }
        public bool Selected { get; set; }
        public bool IsChecked { get; set; }
        public string? PId { get; set; }
    }
}

```
{% previewsample "https://blazorplayground.syncfusion.com/embed/BtBotEVRKzkXAApr?appbar=false&editor=false&result=true&errorlist=false&theme=bootstrap5" backgroundimage "[Blazor Dropdown Tree Component](./images/retrieve-data.png)" %}
