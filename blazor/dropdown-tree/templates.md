---
layout: post
title: Templates in Blazor Dropdown Tree Component | Syncfusion
description: Checkout and learn here all about Templates in Syncfusion Blazor Dropdown Tree component and much more.
platform: Blazor
control: Dropdown Tree
documentation: ug
---

# Templates in Dropdown Tree

The Dropdown Tree has been provided with several options to customize each list item, header, and footer elements.

## Item template

The content of each list item within the Dropdown Tree can be customized with the help of the `ItemTemplate` property.

In the following sample, the Dropdown Tree list items are customized with employee information such as **name** and **job** using the **ItemTemplate** property. 
The variable `context` holds the data of the current node.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfDropDownTree TItem="EmployeeData" TValue="string" Placeholder="Select an employee" Width="500px">
    <ChildContent>
        <DropDownTreeField TItem="EmployeeData" DataSource="Data" ID="Id" Text="Name" HasChildren="HasChild" ParentID="PId"></DropDownTreeField>
    </ChildContent>
    <ItemTemplate>
        <div>
            <span class="ename">@((context as EmployeeData).Name) - </span>
            <span class="ejob" style="opacity: .60">@((context as EmployeeData).Job)</span>
        </div>
    </ItemTemplate>
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

![Blazor DropDownTree with ItemTemplate](./images/template/blazor-dropdowntree-item-template.png)

## Header template

The header element is shown statically at the top of the popup list items within Dropdown Tree, and any custom element can be placed as a header element using the `HeaderTemplate` property.

In the following sample, the header is customized with the custom element.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfDropDownTree TItem="EmployeeData" TValue="string" Placeholder="Select an employee" Width="500px" CssClass="custom">
    <ChildContent>
        <DropDownTreeField TItem="EmployeeData" DataSource="Data" ID="Id" Text="Name" HasChildren="HasChild" ParentID="PId"></DropDownTreeField>
    </ChildContent>
    <HeaderTemplate>
        <div class="head"> Employee List </div>
    </HeaderTemplate>
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

<style>
    .custom .head {
        height: 40px;
        line-height: 40px;
        font-size: 14px;
        margin: 0 auto;
        width: 100%;
        padding: 0 20px;
        font-weight: bold;
        border-bottom: 1px solid #e0e0e0;
    }
</style>
```

![Blazor DropDownTree with HeaderTemplate](./images/template/blazor-dropdowntree-header-template.png)

## Footer template

The Dropdown Tree has options to show a footer element at the bottom of the list items in the popup list. Here, you can place any custom element as a footer element using the `FooterTemplate` property.

In the following sample, the footer element displays the total number of employees present in the Dropdown Tree.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfDropDownTree TItem="EmployeeData" TValue="string" Placeholder="Select an employee" Width="500px" CssClass="custom">
    <ChildContent>
        <DropDownTreeField TItem="EmployeeData" DataSource="Data" ID="Id" Text="Name" HasChildren="HasChild" ParentID="PId"></DropDownTreeField>
    </ChildContent>
    <FooterTemplate>
        <span class='foot'> Total number of employees:  @Data?.Count.ToString()</span>
    </FooterTemplate>
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

<style>
    .custom .foot {
        line-height: 40px;
        font-size: 14px;
        margin: 0 auto;
        padding: 0 20px;
        font-weight: bold;
    }

    .custom .e-ddt-footer {
        border-top: 1px solid #e0e0e0;
    }
</style>
```

![Blazor DropDownTree with Footer Template](./images/template/blazor-dropdowntree-footer-template.png)

## No records template

The Dropdown Tree is provided with support to custom design the popup list content when no data is found and no matches found on search with the help of `NoRecordsTemplate` property.

In the following sample, popup list content displays the notification of no data available.

```cshtml
@using Syncfusion.Blazor.Navigations

<SfDropDownTree TItem="EmployeeData" TValue="string" Placeholder="Select an employee" Width="500px" CssClass="custom">
    <ChildContent>
        <DropDownTreeField TItem="EmployeeData" DataSource="Data" ID="Id" Text="Name" HasChildren="HasChild" ParentID="PId"></DropDownTreeField>
    </ChildContent>
    <NoRecordsTemplate>
        <span > NO DATA AVAILABLE</span>
    </NoRecordsTemplate>
</SfDropDownTree>

@code {
    List<EmployeeData> Data = new List<EmployeeData> { };

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

![Blazor DropDownTree without Data](./images/template/blazor-dropdowntree-nodata-template.png)

## Action failure template

There is also an option to custom design the popup list content when the data fetch request fails at the remote server. This can be achieved using the `ActionFailureTemplate` property.

In the following sample, when the data fetch request fails, the Dropdown Tree displays the notification.

```cshtml
@using Syncfusion.Blazor.Navigations
@using Syncfusion.Blazor.Data

<SfDropDownTree TValue="int?" TItem="TreeData" ID="remote" Placeholder="Select a name" Width="500px">
    <ChildContent>
        <DropDownTreeField TItem="TreeData" Query="@employeeQuery" ID="EmployeeID" Text="FirstName" HasChildren="EmployeeID">
            <SfDataManager Url="https://services.odata.org/V4/Northwind/Northwind.svc" Adaptor="Syncfusion.Blazor.Adaptors.ODataV4Adaptor" CrossDomain="true"></SfDataManager>
        </DropDownTreeField>
        <DropDownTreeField TItem="TreeData" Level="1" Query="@orderQuery" Id="OrderID" Text="ShipName" ParentID="EmployeeID">
            <SfDataManager Url="https://services.odata.org/V4/Northwind/Northwind.svs" Adaptor="Syncfusion.Blazor.Adaptors.ODataV4Adaptor" CrossDomain="true"></SfDataManager>
        </DropDownTreeField>
    </ChildContent>
    <ActionFailureTemplate>
        <span>A request to fetch data is failed.</span>
    </ActionFailureTemplate>
</SfDropDownTree>

@code {
    List<string> EmployeeDetails { get; set; } = new List<string>() { "EmployeeID", "FirstName", "Title" };
    List<string> OrderDetails { get; set; } = new List<string>() { "OrderID", "EmployeeID", "ShipName" };
    Query employeeQuery;
    Query orderQuery;

    protected override void OnInitialized()
    {
        base.OnInitialized();
        employeeQuery = new Query().From("Employees").Select(EmployeeDetails).Take(5);
        orderQuery = new Query().From("Orders").Select(OrderDetails).Take(5);
    }
    
    class TreeData
    {
        public int? EmployeeID { get; set; }
        public int OrderID { get; set; }
        public string ShipName { get; set; }
        public string FirstName { get; set; }
    }
}
```

![Blazor DropDownTree with Action Failure Template](./images/template/blazor-dropdowntree-failure-template.png)