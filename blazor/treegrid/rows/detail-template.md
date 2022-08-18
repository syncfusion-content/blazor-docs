---
layout: post
title: Detail Template in Blazor Tree Grid Component | Syncfusion
description: Checkout and learn here all about Detail Template in Syncfusion Blazor Tree Grid component and much more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Detail Template in Blazor Tree Grid Component

The detail template provides additional information about a particular row. By expanding the parent row the child rows are expanded along with their detail template. The [DetailTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.SfTreeGrid~DetailTemplate.html) property accepts either the template string or HTML elements.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data
@using Syncfusion.Blazor.TreeGrid;
@inject Microsoft.AspNetCore.Components.NavigationManager UriHelper

<SfTreeGrid Height="400" DataSource="@TreeData" IdMapping="EmployeeID" ParentIdMapping="ParentId" TreeColumnIndex="0">
    <TreeGridTemplates>
        <DetailTemplate>
            <div style="position: relative; display: inline-block; float: left; font-weight: bold; width: 10%;padding:5px 4px 2px 27px;;">
                <img src="@UriHelper.ToAbsoluteUri($"images/"+ (context as Employee).Name +".png")" />
            </div>
            <div style="padding-left: 10px; display: inline-block; width: 66%; text-wrap: normal;font-size:13px;font-family:'Segoe UI';">
                <div class="e-description" style="word-wrap: break-word;">
                    <b>@((context as Employee).Name)</b> was lives at @((context as Employee).Address), @((context as Employee).Country). @((context as Employee).Name) holds a position of <b>@((context as Employee).Designation)</b> in our WA department, (Seattle USA).
                </div>
                <div class="e-description" style="word-wrap: break-word;margin-top:5px;">
                    <b style="margin-right:10px;">Contact:</b>@((context as Employee).Contact)
                </div>
            </div>
        </DetailTemplate>
    </TreeGridTemplates>
    <TreeGridColumns>
        <TreeGridColumn Field="Name" HeaderText="Name" Width="160"></TreeGridColumn>
        <TreeGridColumn Field="DOB" HeaderText="DOB" Width="10" Type="Syncfusion.Blazor.Grids.ColumnType.Date" Format="yMd"></TreeGridColumn>
        <TreeGridColumn Field="Designation" HeaderText="Designation" Width="120"></TreeGridColumn>
        <TreeGridColumn Field="EmpID" HeaderText="Employee ID" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Country" HeaderText="Country" Width="100"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>


@code{
    public Employee model = new Employee();
    public IEnumerable<Employee> TreeData { get; set; }
    protected override void OnInitialized()
    {
        this.TreeData = Employee.GetTemplateData();
    }
}

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent.Data {

public class Employee
    {
        public string Name { get; set; }
        public string FullName { get; set; }
        public DateTime? DOB { get; set; }
        public string Designation { get; set; }
        public string EmpID { get; set; }
        public int? EmployeeID { get; set; }
        public string Country { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public int? ParentId { get; set; }
        public TreeData Treedata { get; set; }

        public static List<Employee> GetTemplateData()
        {
            List<Employee> DataCollection = new List<Employee>();

            DataCollection.Add(new Employee { Name = "Robert King",FullName = "RobertKing",Designation = "Chief Executive Officer",EmployeeID = 1,EmpID = "EMP001",Address = "507 - 20th Ave. E.Apt. 2A, Seattle",Contact = "(206) 555-9857",Country = "USA",DOB = new DateTime(1963, 2, 15),ParentId = null,Treedata = new TreeData() { ID = 21}});
            DataCollection.Add(new Employee { Name = "David william",FullName = "DavidWilliam",Designation = "Vice President",EmployeeID = 2,EmpID = "EMP004",Address = "722 Moss Bay Blvd., Kirkland",Contact = "(206) 555-3412",Country = "USA",DOB = new DateTime(1971, 5, 20),ParentId = 1,Treedata = new TreeData() { ID = 21 }});
            DataCollection.Add(new Employee { Name = "Nancy Davolio",FullName = "NancyDavolio",Designation = "Marketing Executive",EmployeeID = 3,EmpID = "EMP035",Address = "4110 Old Redmond Rd., Redmond",Contact = "(206) 555-8122",Country = "USA",DOB = new DateTime(1966, 3, 19),ParentId = 1,Treedata = new TreeData() { ID = 21 }});
            DataCollection.Add(new Employee { Name = "Andrew Fuller",FullName = "AndrewFuller",Designation = "Sales Representative",EmployeeID = 4,EmpID = "EMP045",Country = "UK",DOB = new DateTime(1980, 9, 20),ParentId = 1,Treedata = new TreeData() { ID = 21 }});
            return DataCollection;
        }
    }
}

{% endhighlight %}

{% endtabs %}

![Blazor Tree Grid with Detail Template](../images/blazor-treegrid-detail-template.png)

## Rendering custom component

To render the custom component inside the detail row, define the template in the [DetailTemplate](../templates/#detailtemplates-component) and render the custom component in any of the detail row element.

In the following sample, tree grid component is rendered as a detailed template of the row.

```cshtml
@using Syncfusion.Blazor.TreeGrid
@using Syncfusion.Blazor.Data

<SfTreeGrid DataSource="@Employees" Height="315px" IdMapping="EmployeeID" ParentIdMapping="ParentId" TreeColumnIndex="0">
    <TreeGridTemplates>
        <DetailTemplate>
            @{
                var employee = (context as EmployeeData);
                <SfTreeGrid DataSource="@Orders" IdMapping="OrderID" ParentIdMapping="ParentId" Query="@(new Query().Where("EmployeeID", "equal", employee.EmployeeID))">
                    <TreeGridColumns>
                        <TreeGridColumn Field=@nameof(Order.OrderID) HeaderText="First Name" Width="110"> </TreeGridColumn>
                        <TreeGridColumn Field=@nameof(Order.CustomerName) HeaderText="Last Name" Width="110"></TreeGridColumn>
                        <TreeGridColumn Field=@nameof(Order.ShipCountry) HeaderText="Title" Width="110"></TreeGridColumn>
                    </TreeGridColumns>
                </SfTreeGrid>
            }
        </DetailTemplate>
    </TreeGridTemplates>
    <TreeGridColumns>
        <TreeGridColumn Field=@nameof(EmployeeData.FirstName) HeaderText="First Name" Width="110"> </TreeGridColumn>
        <TreeGridColumn Field=@nameof(EmployeeData.LastName) HeaderText="Last Name" Width="110"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(EmployeeData.Title) HeaderText="Title" Width="110"></TreeGridColumn>
        <TreeGridColumn Field=@nameof(EmployeeData.Country) HeaderText="Country" Width="110"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{
    List<EmployeeData> Employees = new List<EmployeeData> {
        new EmployeeData() {EmployeeID = 1, FirstName="Nancy", LastName="Fuller", Title="Sales Representative", Country="USA", ParentId = null},
        new EmployeeData() {EmployeeID = 2, FirstName="Andrew", LastName="Davolio", Title="Vice President", Country="UK", ParentId = 1},
        new EmployeeData() {EmployeeID = 3, FirstName="Janet", LastName="Leverling", Title="Sales", Country="UK", ParentId = 1},
        new EmployeeData() {EmployeeID = 4, FirstName="Margaret", LastName="Peacock", Title="Sales Manager", Country="UAE", ParentId = null},
        new EmployeeData() {EmployeeID = 5, FirstName="Steven", LastName="Buchanan", Title="Inside Sales Coordinator", Country="USA", ParentId = 4},
        new EmployeeData() {EmployeeID = 6, FirstName="Smith", LastName="Steven", Title="HR Manager", Country="UAE", ParentId = 4},
    };

    List<Order> Orders = new List<Order> {
        new Order() {EmployeeID = 1, OrderID=1, CustomerName="Nancy", ShipCountry="USA", ParentId = null},
        new Order() {EmployeeID = 1, OrderID=2, CustomerName="Steven", ShipCountry="UR", ParentId = 1},
        new Order() {EmployeeID = 2, OrderID=3, CustomerName="Smith", ShipCountry="UK", ParentId = null},
        new Order() {EmployeeID = 2, OrderID=4, CustomerName="Smith", ShipCountry="USA", ParentId = 3},
        new Order() {EmployeeID = 3, OrderID=5, CustomerName="Nancy", ShipCountry="ITA", ParentId = null},
        new Order() {EmployeeID = 3, OrderID=6, CustomerName="Nancy", ShipCountry="UK", ParentId = 5},
        new Order() {EmployeeID = 3, OrderID=7, CustomerName="Steven", ShipCountry="GER", ParentId = 5},
        new Order() {EmployeeID = 4, OrderID=8, CustomerName="Andrew", ShipCountry="GER", ParentId = null},
        new Order() {EmployeeID = 5, OrderID=9, CustomerName="Fuller", ShipCountry="USA", ParentId = null},
        new Order() {EmployeeID = 6, OrderID=10, CustomerName="Leverling", ShipCountry="UAE", ParentId = null},
        new Order() {EmployeeID = 6, OrderID=11, CustomerName="Margaret", ShipCountry="KEN", ParentId = 10},
        new Order() {EmployeeID = 7, OrderID=12, CustomerName="Buchanan", ShipCountry="GER", ParentId = null},
        new Order() {EmployeeID = 8, OrderID=13, CustomerName="Nancy", ShipCountry="USA", ParentId = null},
        new Order() {EmployeeID = 6, OrderID=14, CustomerName="Andrew", ShipCountry="UAE", ParentId = 10},
    };

    public class EmployeeData
    {
        public int? EmployeeID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Title { get; set; }
        public string Country { get; set; }
        public int? ParentId { get; set; }
    }

    public class Order
    {
        public int? EmployeeID { get; set; }
        public int? OrderID { get; set; }
        public string CustomerName { get; set; }
        public string ShipCountry { get; set; }
        public int? ParentId { get; set; }
    }
}
```

![Rendering Custom Component in Blazor Tree Grid Row](../images/blazor-treegrid-row-with-custom-component.png)