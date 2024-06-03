---
layout: post
title: Filtering in Blazor Dropdown Tree Component | Syncfusion
description: Checkout and learn here all about Filtering in Syncfusion Blazor Dropdown Tree component and much more.
platform: Blazor
control: Dropdown Tree
documentation: ug
---

# Filtering in Dropdown Tree

The Dropdown Tree has built-in support to filter data items when [AllowFiltering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfDropDownTree-2.html#Syncfusion_Blazor_Navigations_SfDropDownTree_2_AllowFiltering) is enabled. The filter operation starts as soon as you start typing characters in the search box.  Default value of AllowFiltering is `false`.

## List data

The following code demonstrates the filtering functionality with local data in the Dropdown Tree component.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfDropDownTree TItem="EmployeeData" TValue="string" Placeholder="Select an employee" Width="500px" AllowFiltering="true">
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

![Blazor Dropdown Tree with local data filtering](./images/filter/blazor-dropdowntree-local-filter.png)

## Remote data

The following code demonstrates the filtering functionality with remote data in the Dropdown Tree component.

```cshtml
<SfDropDownTree TValue="int?" TItem="TreeData" Placeholder="Select an employee" Width="500px" AllowFiltering="true">
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

## Filter type

You can use [FilterType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfDropDownTree-2.html#Syncfusion_Blazor_Navigations_SfDropDownTree_2_FilterType) property to specify on which filter type needed to be considered on the search action of the component. The available `FilterType` and its supported data types are:

FilterType     | Description
------------ | -------------
  [StartsWith](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.FilterType.html#Syncfusion_Blazor_DropDowns_FilterType_StartsWith)       | Checks whether a value begins with the specified value.
  [EndsWith](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.FilterType.html#Syncfusion_Blazor_DropDowns_FilterType_EndsWith)     | Checks whether a value ends with specified value.
  [Contains](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.DropDowns.FilterType.html#Syncfusion_Blazor_DropDowns_FilterType_Contains)      | Checks whether a value contained with specified value.

In the following example, `Contains` filter type has been mapped to the [FilterType](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfDropDownTree-2.html#Syncfusion_Blazor_Navigations_SfDropDownTree_2_FilterType) property.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.DropDowns

<SfDropDownTree TItem="EmployeeData" TValue="string" Placeholder="Select an employee" Width="500px" AllowFiltering="true" FilterType="FilterType.Contains">
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

## Case sensitive filtering

The Data items can be filtered with or without case sensitivity using the [IgnoreCase](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfDropDownTree-2.html#Syncfusion_Blazor_Navigations_SfDropDownTree_2_IgnoreCase) property. By default, the `IgnoreCase` is set to false.

## Filter textbox placeholder 

You can use [FilterBarPlaceholder](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfDropDownTree-2.html#Syncfusion_Blazor_Navigations_SfDropDownTree_2_FilterBarPlaceholder) to accept the value to be displayed as a watermark text on the filter bar TextBox. `FilterBarPlaceholder` is applicable when `AllowFiltering` is used as true. `FilterBarPlaceholder` is depends on `AllowFiltering` property.

![Blazor Dropdown Tree with local data filtering](./images/filter/blazor-dropdowntree-placeholder.png)

## Minimum filter length

When filtering the tree items, you can set the minimum characters after which the filtering must occur. This can be done by checking the text length using the [Filtering event arguments](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.DdtFilteringEventArgs.html#Syncfusion_Blazor_Navigations_DdtFilteringEventArgs_Text) within the [Filtering](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.Navigations.SfDropDownTree-2.html#Syncfusion_Blazor_Navigations_SfDropDownTree_2_Filtering) event handler.

In the following example, the limit is set to 2.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfDropDownTree TItem="Listdata" TValue="string" ID="filter" Placeholder="Select a country" PopupHeight="230px" AllowFiltering="true" FilterBarPlaceholder="Search" Filtering="OnFiltering">
    <DropDownTreeField TItem="Listdata" DataSource="@ListDataSource" ID="Id" ParentID="Pid" Text="Name" HasChildren="HasChild" Expanded="Expanded"></DropDownTreeField>
</SfDropDownTree>

@code {
    List<Listdata> ListDataSource = new List<Listdata>
    {
        new Listdata { Id = "1", Name = "Australia", HasChild = true, Expanded = true },
        new Listdata { Id = "2", Pid = "1", Name = "New South Wales" },
        new Listdata { Id = "3", Pid = "1", Name = "Victoria" },
        new Listdata { Id = "4", Pid = "1", Name = "South Australia" },
        new Listdata { Id = "6", Pid = "1", Name = "Western Australia" },
        new Listdata { Id = "7", Name = "Brazil", HasChild = true },
        new Listdata { Id = "8", Pid = "7", Name = "Parana" },
        new Listdata { Id = "9", Pid = "7", Name = "Ceara" },
        new Listdata { Id = "10", Pid = "7", Name = "Acre" },
        new Listdata { Id = "11", Name = "China", HasChild = true },
        new Listdata { Id = "12", Pid = "11", Name = "Guangzhou" },
        new Listdata { Id = "13", Pid = "11", Name = "Shanghai" },
        new Listdata { Id = "14", Pid = "11", Name = "Beijing" },
        new Listdata { Id = "15", Pid = "11", Name = "Shantou" },
        new Listdata { Id = "16", Name = "France", HasChild = true },
        new Listdata { Id = "17", Pid = "16", Name = "Pays de la Loire" },
        new Listdata { Id = "18", Pid = "16", Name = "Aquitaine" },
        new Listdata { Id = "19", Pid = "16", Name = "Brittany" },
        new Listdata { Id = "20", Pid = "16", Name = "Lorraine" },
        new Listdata { Id = "21", Name = "India", HasChild = true },
        new Listdata { Id = "22", Pid = "21", Name = "Assam" },
        new Listdata { Id = "23", Pid = "21", Name = "Bihar" },
        new Listdata { Id = "24", Pid = "21", Name = "Tamil Nadu" }
    };

    void OnFiltering(DdtFilteringEventArgs args)
    {
        if(args.Text?.Length < 2 && args.Text?.Length != 0)
        {
            args.Cancel = true;
        }
    }

    class Listdata
    {
        public string Id { get; set; }
        public string Pid { get; set; }
        public string Name { get; set; }
        public bool HasChild { get; set; }
        public bool Expanded { get; set; }
    }
}
```