---
layout: post
title: Templates in Blazor TreeGrid Component | Syncfusion
description: Checkout and learn here all about templates in Syncfusion Blazor TreeGrid component and much more details.
platform: Blazor
control: TreeGrid
documentation: ug
---

# Templates in Syncfusion Blazor TreeGrid Component

Blazor provides templated components that accept one or more UI fragments to render during component execution. The TreeGrid is a templated Razor component that enables customizing multiple parts of the UI through template parameters. It supports rendering custom content or components based on application logic.

The available template options in TreeGrid are as follows,

* [Column template](./columns/column-template) - Used to customize cell content.
* [Header template](./columns/columns#header-template) - Used to customize header cell content.
* [Row template](./rows/row-template) - Used to customize row content.
* [Detail template](./rows/detail-template) - Used to customize the detail cell content.

## Template ModelType

To use templates, bind the TreeGrid to a named model. Specify the model type using the `ModelType` property of the TreeGrid component. This informs the template about the underlying data type, enabling strong typing and IntelliSense within templates.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data
@using Syncfusion.Blazor.TreeGrid;

<SfTreeGrid ModelType="@model" Height="400" DataSource="@TreeData" IdMapping="EmployeeID" ParentIdMapping="ParentId" TreeColumnIndex="0">
    <TreeGridColumns>
        <TreeGridColumn Field="Name" HeaderText="Name" Width="160">
            <HeaderTemplate>
                <div class="rating">
                    <span class="star"></span> DOB
                </div>
            </HeaderTemplate>
        </TreeGridColumn>
        <TreeGridColumn Field="Designation" HeaderText="Designation" Width="120"></TreeGridColumn>
        <TreeGridColumn Field="EmpID" HeaderText="Progress" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Country" HeaderText="Priority" Width="100"></TreeGridColumn>
        </TreeGridColumns>
</SfTreeGrid>

<style>
    .rating .star:before {
        content: '★';
    }
</style>

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

            DataCollection.Add(new Employee { Name = "Robert King",FullName = "RobertKing",Designation = "Chief Executive Officer",EmployeeID = 1,EmpID = "EMP001",Country = "USA",DOB = new DateTime(1963, 2, 15),ParentId = null,Treedata = new TreeData() { ID = 21}});
            DataCollection.Add(new Employee { Name = "David william",FullName = "DavidWilliam",Designation = "Vice President",EmployeeID = 2,EmpID = "EMP004",Country = "USA",DOB = new DateTime(1971, 5, 20),ParentId = 1,Treedata = new TreeData() { ID = 21 }});
            DataCollection.Add(new Employee { Name = "Nancy Davolio",FullName = "NancyDavolio",Designation = "Marketing Executive",EmployeeID = 3,EmpID = "EMP035",Country = "USA",DOB = new DateTime(1966, 3, 19),ParentId = 1,Treedata = new TreeData() { ID = 21 }});
            DataCollection.Add(new Employee { Name = "Andrew Fuller",FullName = "AndrewFuller",Designation = "Sales Representative",EmployeeID = 4,EmpID = "EMP045",Country = "UK",DOB = new DateTime(1980, 9, 20),ParentId = 1,Treedata = new TreeData() { ID = 21 }});
            DataCollection.Add(new Employee { Name = "Anne Dodsworth",FullName = "AnneDodsworth",Designation = "Sales Representative",EmployeeID = 5,EmpID = "EMP091",Country = "USA",ParentId = null,Treedata = new TreeData() { ID = 21 }});
            DataCollection.Add(new Employee { Name = "Michael Suyama",FullName = "MichaelSuyama",Designation = "Sales Representative",EmployeeID = 6,EmpID = "EMP110",Country = "UK",ParentId = 5,Treedata = new TreeData() { ID = 21 }});
            return DataCollection;
        }
    }
}

{% endhighlight %}

{% endtabs %}

![Blazor TreeGrid with Model Template](images/blazor-treegrid-model-template.png)

## Template Context

Most templates used by the TreeGrid are of type `RenderFragment<T>` and receive parameters at runtime. Access these parameters through the implicit `context` parameter within the template. The implicit parameter name can be customized using the `Context` attribute when needed.

For example, access column template data through `context` as shown below.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data
@using Syncfusion.Blazor.TreeGrid;
@inject Microsoft.AspNetCore.Components.NavigationManager UriHelper

<SfTreeGrid ModelType="@model" Height="400" DataSource="@TreeData" IdMapping="EmployeeID" ParentIdMapping="ParentId" TreeColumnIndex="0">
    <TreeGridColumns>
        <TreeGridColumn Field="Name" HeaderText="Name" Width="160"></TreeGridColumn>
        <TreeGridColumn HeaderText="Employee Image" Width="80">
            <Template>
                @{
                    var employee = (context as Employee);
                    <div class="image">
                        <img src="@UriHelper.ToAbsoluteUri($"images/TreeGrid/{employee.Name}.png")" alt="@employee.EmployeeID" />
                    </div>
                }
            </Template>
        </TreeGridColumn>
        <TreeGridColumn Field="DOB" HeaderText="DOB" Width="10" Type="Syncfusion.Blazor.Grids.ColumnType.Date" Format="yMd"></TreeGridColumn>
        <TreeGridColumn Field="Designation" HeaderText="Designation" Width="120"></TreeGridColumn>
        <TreeGridColumn Field="EmpID" HeaderText="Progress" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Country" HeaderText="Priority" Width="100"></TreeGridColumn>
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

![Blazor TreeGrid with Column Template](images/blazor-treegrid-column-template.png)

## TreeGridTemplates component

If a component contains any RenderFragment type property, it does not allow arbitrary child components other than the render fragment property, which is [by design in Blazor](https://github.com/dotnet/aspnetcore/issues/10836). This restriction prevents directly specifying templates such as RowTemplate and DetailTemplate as descendants of the TreeGrid root.

Wrap such templates in the TreeGridTemplates component to define `RowTemplate` and `DetailTemplate`, as shown below.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data
@using Syncfusion.Blazor.TreeGrid;
@inject Microsoft.AspNetCore.Components.NavigationManager UriHelper

<SfTreeGrid ModelType="@model" Height="335" DataSource="@TreeData" IdMapping="EmployeeID" ParentIdMapping="ParentId" TreeColumnIndex="0" RowHeight="83" GridLines="@GridLine.Vertical">
    <TreeGridTemplates>
        <RowTemplate>
           @{
            var employee = (context as Employee);

            <td style='padding-left:18px; border-bottom: 0.5px solid #e0e0e0;'>
                <div>@employee.EmpID</div>
            </td>
            <td style='padding: 10px 0px 0px 20px; border-bottom: 0.5px solid #e0e0e0;'>
                <div style="font-size:14px;">
                    @employee.FullName
                </div>
            </td>
            <td style="border-bottom: 0.5px solid #e0e0e0;">
                <div>
                    <div style="position:relative;display:inline-block;">
                        <img src="@UriHelper.ToAbsoluteUri($"images/" + employee.Name + ".png")" alt="@employee.Name" />
                    </div>
                    <div style="display:inline-block;">
                        <div style="padding:5px;">@employee.Address</div>
                        <div style="padding:5px;">@employee.Country</div>
                        <div style="padding:5px;font-size:12px;">@employee.Contact</div>
                    </div>
                </div>
            </td>
            <td style='padding-left: 20px; border-bottom: 0.5px solid #e0e0e0;'>
                <div>@employee.Designation</div>
            </td>
          }
        </RowTemplate>
    </TreeGridTemplates>
    <TreeGridColumns>
        <TreeGridColumn Field="EmpID" HeaderText="Employee ID" Width="160"></TreeGridColumn>
        <TreeGridColumn Field="Name" HeaderText="Employee Name"></TreeGridColumn>
        <TreeGridColumn Field="Address" HeaderText="Employee Details" Width="340" TextAlign="@TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Designation" HeaderText="Designation"></TreeGridColumn>
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
        public DateTime? DOB { get; set; }
        public string Designation { get; set; }
        public string EmpID { get; set; }
        public string Country { get; set; }
        public int? ParentId { get; set; }
        public TreeData Treedata { get; set; }

        public static List<Employee> GetTemplateData()
        {
            List<Employee> DataCollection = new List<Employee>();
            DataCollection.Add(new Employee { Name = "Robert King",Designation = "Chief Executive Officer",EmpID = "EMP001",Country = "USA",DOB = new DateTime(1963, 2, 15),ParentId = null,Treedata = new TreeData() { ID = 21}});
            DataCollection.Add(new Employee { Name = "David william",Designation = "Vice President",EmpID = "EMP004",Country = "USA",DOB = new DateTime(1971, 5, 20),ParentId = 1,Treedata = new TreeData() { ID = 21 }});
            DataCollection.Add(new Employee { Name = "Nancy Davolio",Designation = "Marketing Executive",EmpID = "EMP035",Country = "USA",DOB = new DateTime(1966, 3, 19),ParentId = 1,Treedata = new TreeData() { ID = 21 }});
            DataCollection.Add(new Employee { Name = "Andrew Fuller",Designation = "Sales Representative",EmpID = "EMP045",Country = "UK",DOB = new DateTime(1980, 9, 20),ParentId = 1,Treedata = new TreeData() { ID = 21 }});
            return DataCollection;
        }
    }
}

{% endhighlight %}

{% endtabs %}

![Blazor TreeGrid with Row Template](images/blazor-treegrid-row-template.png)

## Customize the empty record template in Blazor TreeGrid

The empty record template feature in the Syncfusion<sup style="font-size:70%">&reg;</sup> Blazor TreeGrid allows displaying custom content such as images, text, or other components when the TreeGrid has no records to show. It replaces the default message of **No records to display.**

To enable this, set the `EmptyRecordTemplate` of the TreeGrid. The EmptyRecordTemplate accepts an HTML element or a function that returns an HTML element.

The following example demonstrates rendering an image and descriptive text as the empty record template:

{% tabs %}
{% highlight razor tabtitle="Index.razor" %}

@using TreeGridComponent.Data
@using Syncfusion.Blazor.TreeGrid

<SfTreeGrid DataSource="@TreeGridData" IdMapping="TaskID" ParentIdMapping="ParentID" HasChildMapping="IsParent" TreeColumnIndex="1" AllowPaging="true" Toolbar="@(new List<string>() { "Add", "Edit", "Delete", "Update", "Cancel" })">
    <TreeGridPageSettings PageCount="5"></TreeGridPageSettings>
    <TreeGridEditSettings AllowEditing="true" AllowAdding="true" AllowDeleting="true"/>
    <TreeGridTemplates>
        <EmptyRecordTemplate>
            <div class="emptyRecordTemplate text-center">
                <img src="@ImageUrl" class="e-emptyRecord" alt="No record" />
                <span>There is no data available to display at the moment.</span>
            </div>
        </EmptyRecordTemplate>
    </TreeGridTemplates>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskID" HeaderText="Task ID" Width="120" IsPrimaryKey="true" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="200"></TreeGridColumn>
        <TreeGridColumn Field="StartDate" HeaderText="Start Date" Width="130" Format="d" TextAlign="TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="TextAlign.Right"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{
    public List<TreeData> TreeGridData { get; set; }

    protected override void OnInitialized()
    {
        this.TreeGridData = TreeData.GetSelfDataSource().ToList();
    }

    public string ImageUrl = "data:image/svg+xml;base64...."
   
}

{% endhighlight %}
{% highlight c# %}

namespace TreeGridComponent.Data {

public class TreeData
    {
        public int TaskId { get; set;}
        public string TaskName { get; set;}
        public DateTime? StartDate { get; set;}
        public int? Duration { get; set;}
       
        public static List<TreeData> GetSelfDataSource()
        {
            List<TreeData> TreeDataCollection = new List<TreeData>();
            return TreeDataCollection;
        }
    }
}

{% endhighlight %}
{% endtabs %}

![Blazor TreeGrid with Empty Record Template](images/empty-record-template.png)
