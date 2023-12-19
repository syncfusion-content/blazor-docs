---
layout: post
title: Data Binding in Blazor Dropdown Tree Component | Syncfusion
description: Checkout and learn here all about Data Binding in Syncfusion Blazor Dropdown Tree component and much more.
platform: Blazor
control: Dropdown Tree
documentation: ug
---

# Data Binding in Blazor Dropdown Tree Component

The Blazor Dropdown Tree component provides the option to load data either from the local data sources or from remote data services. This can be done through `DataSource` property that is a member of the [Fields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.DropDownTreeField-1.html#constructors) property. The `DataSource` property supports list of objects and `DataManager`. It also supports different kinds of data services such as OData, OData V4, Web API, URL, and JSON with the help of `DataManager` adaptors.

## Binding local data 

To bind local data to the Blazor Dropdown Tree, assign a list of objects to the `DataSource` property. The Blazor Dropdown Tree component requires three fields (Id, Text, and ParentID) to render local data source. When mapper fields are not specified, it takes the default values as the mapping fields. Local data source can also be provided as an instance of the `DataManager`. It supports two kinds of local data binding methods.

* Hierarchical data

* Self-referential data

### Hierarchical data

Blazor Dropdown Tree can be populated with hierarchical data source that contains nested list of objects. A hierarchical data can be directly assigned to the `DataSource` property, and map all the field members with corresponding keys from the hierarchical data to [Fields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.DropDownTreeField-1.html#constructors) property.

In the following example, **Id**, **FolderName**, and **SubFolders** columns from hierarchical data have been mapped to **ID**, **Text**, and **Child** fields, respectively.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfDropDownTree TValue="string" TItem="MailItem" Placeholder="Select a Folder" Width="500px">
    <DropDownTreeField TItem="MailItem" ID="Id" Text="FolderName" Child="SubFolders" DataSource="@MyFolder" Expanded="Expanded"></DropDownTreeField>
</SfDropDownTree>

@code {
    public class MailItem
    {
        public string Id { get; set; }
        public string FolderName { get; set; }
        public bool Expanded { get; set; }
        public List<MailItem> SubFolders { get; set; }
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

### Self-referential data

Blazor Dropdown Tree can be populated from self-referential data structure that contains list of objects with `ParentID` mapping. The self-referential data can be directly assigned to the `DataSource` property, and map all the field members with corresponding keys from self-referential data to [Fields](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.DropDownTreeField-1.html#constructors) property.

To render the root level nodes, specify the ParentID as null or no need to specify the ParentID in `DataSource`. In the following example, **Id**, **Pid**, **HasSubFolders**, and **FolderName** columns from self-referential data have been mapped to **ID**, **ParentId**, **HasChildren**, and **Text** fields, respectively.

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
        public string Id { get; set; }
        public string ParentId { get; set; }
        public string FolderName { get; set; }
        public bool Expanded { get; set; }
        public bool HasSubFolders { get; set; }
    }
}
```

## Remote data

Blazor Dropdown Tree can also be populated from a remote data service with the help of `DataManager` component and `Query` property. It supports different kinds of data services such as OData, OData V4, Web API, URL, and JSON with the help of `DataManager` adaptors. A service data can be assigned as an instance of `DataManager` to the `DataSource` property. To interact with remote data source, provide the endpoint `url`.

The `DataManager` that acts as an interface between the service endpoint and the Dropdown Tree requires the following information to interact with service endpoint properly.

* `DataManager->url`: Defines the service endpoint to fetch data.

* `DataManager->adaptor`: Defines the adaptor option. By default, ODataAdaptor is used for remote binding.

Adaptor is responsible for processing response and request from/to the service endpoint. The `Syncfusion.Blazor.Data` provides some predefined adaptors designed to interact with service endpoints. They are,

* `UrlAdaptor`: Used to interact with remote services. This is the base adaptor for all remote based adaptors.

* `ODataAdaptor`: Used to interact with OData endpoints.

* `ODataV4Adaptor`: Used to interact with OData V4 endpoints.

* `WebApiAdaptor`: Used to interact with Web API created under OData standards.

* `WebMethodAdaptor`: Used to interact with web methods.

### Binding with OData services

In the following example, `ODataAdaptor` is  used to fetch data from remote services. The **EmployeeID**, **FirstName**, and **EmployeeID** columns from Employees table have been mapped to **ID**, **Text**, and **HasChildren** fields respectively for first level nodes.

The **OrderID**, **EmployeeID**, and **ShipName** columns from orders table have been mapped to **ID**, **ParentID**, and **Text** fields respectively for second level nodes.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Data

<SfDropDownTree TValue="int?" TItem="TreeData" Placeholder="Select an employee" Width="500px">
    <DropDownTreeField TItem="TreeData" Query="@Query" ID="EmployeeID" Text="FirstName" HasChildren="EmployeeID">
        <SfDataManager Url="http://services.odata.org/Northwind/Northwind.svc" Adaptor="@Syncfusion.Blazor.Adaptors.ODataAdaptor" CrossDomain="true"></SfDataManager>
    </DropDownTreeField>
    <DropDownTreeField TItem="TreeData" Query="@SubQuery" ID="OrderID" Text="ShipName" ParentID="EmployeeID">
        <SfDataManager Url="http://services.odata.org/Northwind/Northwind.svc" Adaptor="@Syncfusion.Blazor.Adaptors.ODataAdaptor" CrossDomain="true"></SfDataManager>
    </DropDownTreeField>
</SfDropDownTree>

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

In the following example, `ODataV4Adaptor` is  used to fetch data from remote services. The **EmployeeID**, **FirstName**, and **EmployeeID** columns from Employees table have been mapped to **ID**, **Text**, and **HasChildren** fields respectively for first level nodes.

The **OrderID**, **EmployeeID**, and **ShipName** columns from orders table have been mapped to **ID**, **ParentID**, and **Text** fields respectively for second level nodes.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Data

<SfDropDownTree TValue="int?" TItem="TreeData" Placeholder="Select an employee" Width="500px">
    <DropDownTreeField TItem="TreeData" Query="@Query" ID="EmployeeID" Text="FirstName" HasChildren="EmployeeID">
        <SfDataManager Url="http://services.odata.org/V4/Northwind/Northwind.svc" Adaptor="@Syncfusion.Blazor.Adaptors.ODataV4Adaptor" CrossDomain="true"></SfDataManager>
    </DropDownTreeField>
    <DropDownTreeField TItem="TreeData" Query="@SubQuery" ID="OrderID" Text="ShipName" ParentID="EmployeeID">
        <SfDataManager Url="http://services.odata.org/V4/Northwind/Northwind.svc" Adaptor="@Syncfusion.Blazor.Adaptors.ODataV4Adaptor" CrossDomain="true"></SfDataManager>
    </DropDownTreeField>
</SfDropDownTree>

@code {
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

### Web API Adaptor

In the following example, `WebApiAdaptor` is  used to fetch data from server side.

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

## Load On Demand

Blazor Dropdown Tree has `load on demand` (Lazy load). It reduces the bandwidth size when consuming huge data. It loads first level nodes initially, and when parent node is expanded, loads the child nodes based on the `ParentID/Child` member. By default, the `LoadOnDemand` is set to false.

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
        public string Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public bool HasChild { get; set; }
        public bool Expanded { get; set; }
        public string PId { get; set; }
    }
}
```
