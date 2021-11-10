---
layout: post
title: Rows in Blazor TreeGrid Component | Syncfusion
description: Checkout and learn here all about rows in Syncfusion Blazor TreeGrid component and much more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Rows in Blazor TreeGrid Component

The row represents record details fetched from the data source.

## Customize rows

The appearance of a row can be customized by using the [RowDataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.SfTreeGrid~RowDataBound.html) event. The [RowDataBound](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.SfTreeGrid~RowDataBound.html) event triggers for every row. In the event handler, the **args** is achieved which contains the details of the row.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data
@using Syncfusion.Blazor.TreeGrid;

 <SfTreeGrid DataSource="@TreeGridData" ParentIdMapping="ParentId" IdMapping="TaskId" TreeColumnIndex="1">
    <TreeGridEvents RowDataBound="OnRowDataBound" TValue="TreeData"></TreeGridEvents>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="90" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="100"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Priority" HeaderText="Priority" Width="100"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

<style>
    .equal-5 {
        background-color: #336c12;
    }

    .above-6 {
        background-color: #7b2b1d;
    }

</style>

@code{
    public List<TreeData> TreeGridData { get; set; }

    protected override void OnInitialized()
    {
        this.TreeGridData = TreeData.GetSelfDataSource().ToList();
    }

    private void OnRowDataBound(RowDataBoundEventArgs<TreeData> args)
    {
        if (args.Data.Duration == 5)
        {
             args.Row.AddClass(new string[] { "equal-5" });
        }
        else if (args.Data.Duration > 6)
        {
            args.Row.AddClass(new string[] { "above-6" });
        }
    }
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
            public int? Progress { get; set;}
            public string Priority { get; set;}
            public int? ParentId { get; set;}
       
        public static List<TreeData> GetSelfDataSource()
        {
            List<TreeData> TreeDataCollection = new List<TreeData>();
            TreeDataCollection.Add(new TreeData() { TaskId = 1,TaskName = "Parent Task 1",Duration = 10,Progress = 70,Priority = "Critical",ParentId = null });
            TreeDataCollection.Add(new TreeData() { TaskId = 2,TaskName = "Child task 1",Duration = 5,Progress = 80,Priority = "Low",ParentId = 1 });
            TreeDataCollection.Add(new TreeData() { TaskId = 3,TaskName = "Child Task 2",Duration = 5,Progress = 65,Priority = "Critical",ParentId = 2 });
            TreeDataCollection.Add(new TreeData() { TaskId = 4,TaskName = "Child task 3",Duration = 6,Priority = "High",Progress = 77,ParentId = 3 });
            TreeDataCollection.Add(new TreeData() { TaskId = 5,TaskName = "Parent Task 2",Duration = 10,Progress = 70,Priority = "Critical",ParentId = null});
            TreeDataCollection.Add(new TreeData() { TaskId = 6,TaskName = "Child task 1",Duration = 4,Progress = 80,Priority = "Critical",ParentId = 5});
            TreeDataCollection.Add(new TreeData() { TaskId = 7,TaskName = "Child Task 2",Duration = 5,Progress = 65,Priority = "Low",ParentId = 5});
            TreeDataCollection.Add(new TreeData() { TaskId = 8,TaskName = "Child task 3",Duration = 6,Progress = 77,Priority = "High",ParentId = 5});
            TreeDataCollection.Add(new TreeData() { TaskId = 9,TaskName = "Child task 4",Duration = 6,Progress = 77,Priority = "Low",ParentId = 5});
            return TreeDataCollection;
        }
    }
}

{% endhighlight %}

{% endtabs %}

![Customizing Blazor TreeGrid Rows](images/blazor-treegrid-row-customization.png)

## Styling alternate rows

 The tree grid's alternative rows' background color can be changed by overriding the **.e-altrow** class.

```css
.e-treegrid .e-altrow {
    background-color: #fafafa;
}
```

Please refer to the following example.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data
@using Syncfusion.Blazor.TreeGrid;

<SfTreeGrid DataSource="@TreeGridData" ParentIdMapping="ParentId"  IdMapping="TaskId" TreeColumnIndex="1">
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="160"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{
    public List<TreeData.BusinessObject> TreeGridData { get; set; }
    protected override void OnInitialized()
    {
        this.TreeGridData = TreeData.GetSelfDataSource().ToList();
    }
}

<style>
    .e-treegrid .e-altrow {
        background-color: #fafafa;
    }
</style>

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent.Data {

public class TreeData
    {
        public class BusinessObject
        {
            public int TaskId { get; set;}
            public string TaskName { get; set;}
            public int? Duration { get; set;}
            public int? Progress { get; set;}
            public int? ParentId { get; set;}
        }

        public static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 1,TaskName = "Parent Task 1",Duration = 10,Progress = 70,ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 2,TaskName = "Child task 1",Duration = 6,Progress = 80,ParentId = 1 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 3,TaskName = "Child Task 2",Duration = 5,Progress = 65,ParentId = 2 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 4,TaskName = "Child task 3",Duration = 6,Progress = 77,ParentId = 3 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 5,TaskName = "Parent Task 2",Duration = 10,Progress = 70,ParentId = null});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 6,TaskName = "Child task 1",Duration = 4,Progress = 80,ParentId = 5});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 7,TaskName = "Child Task 2",Duration = 5,Progress = 65,ParentId = 5});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 8,TaskName = "Child task 3",Duration = 6,Progress = 77,ParentId = 5});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 9,TaskName = "Child task 4",Duration = 6,Progress = 77,ParentId = 5});
            return BusinessObjectCollection;
        }
    }
}

{% endhighlight %}

{% endtabs %}

![Customizing Alternate Rows in Blazor TreeGrid](images/blazor-treegrid-alternate-rows-customization.png)

## Row height

The row height of tree grid rows can be customized through the [RowHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.SfTreeGrid~RowHeight.html) property. The [RowHeight](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.SfTreeGrid~RowHeight.html) property is used to change the row height of the entire tree grid rows.

In the below example, the **RowHeight** is set as *60px*.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data
@using Syncfusion.Blazor.TreeGrid;

<SfTreeGrid DataSource="@TreeGridData" ParentIdMapping="ParentId"  IdMapping="TaskId" RowHeight="60" TreeColumnIndex="1">
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="160"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{
    public List<TreeData.BusinessObject> TreeGridData { get; set; }
    protected override void OnInitialized()
    {
        this.TreeGridData = TreeData.GetSelfDataSource().ToList();
    }
}

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent.Data {

public class TreeData
    {
        public class BusinessObject
        {
            public int TaskId { get; set;}
            public string TaskName { get; set;}
            public int? Duration { get; set;}
            public int? Progress { get; set;}
            public int? ParentId { get; set;}
        }

        public static List<BusinessObject> GetSelfDataSource()
        {
            List<BusinessObject> BusinessObjectCollection = new List<BusinessObject>();
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 1,TaskName = "Parent Task 1",Duration = 10,Progress = 70,ParentId = null });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 2,TaskName = "Child task 1",Duration = 6,Progress = 80,ParentId = 1 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 3,TaskName = "Child Task 2",Duration = 5,Progress = 65,ParentId = 2 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 4,TaskName = "Child task 3",Duration = 6,Progress = 77,ParentId = 3 });
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 5,TaskName = "Parent Task 2",Duration = 10,Progress = 70,ParentId = null});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 6,TaskName = "Child task 1",Duration = 4,Progress = 80,ParentId = 5});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 7,TaskName = "Child Task 2",Duration = 5,Progress = 65,ParentId = 5});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 8,TaskName = "Child task 3",Duration = 6,Progress = 77,ParentId = 5});
            BusinessObjectCollection.Add(new BusinessObject() { TaskId = 9,TaskName = "Child task 4",Duration = 6,Progress = 77,ParentId = 5});
            return BusinessObjectCollection;
        }
    }
}

{% endhighlight %}

{% endtabs %}

![Blazor TreeGrid with Custom Row Height](images/blazor-treegrid-custom-row-height.png)

## Row template

To know about Row Template in Blazor tree grid Component, you can check this video.

{% youtube
"youtube:https://www.youtube.com/watch?v=cB4NjwFya_U"%}

The **RowTemplate** has an option to customize the look and behavior of the tree grid rows. The [RowTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.SfTreeGrid~RowTemplate.html) property accepts either the **template** string or HTML elements.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data
@using Syncfusion.Blazor.TreeGrid;
@inject Microsoft.AspNetCore.Components.NavigationManager UriHelper

<SfTreeGrid Height="335" DataSource="@TreeData" IdMapping="EmployeeID" ParentIdMapping="ParentId" TreeColumnIndex="0" RowHeight="83" GridLines="Syncfusion.Blazor.Grids.GridLine.Vertical">
    <TreeGridTemplates>
        <RowTemplate>
            <td style='padding-left:18px; border-bottom: 0.5px solid #e0e0e0;'>
                <RowTemplateTreeColumn>
                    @{
                        var cntxt = context as Employee;
                        <div>@(cntxt.EmpID)</div>
                    }
                </RowTemplateTreeColumn>
            </td>
            <td style='padding: 10px 0px 0px 20px; border-bottom: 0.5px solid #e0e0e0;'>
                <div style="font-size:14px;">
                    @((context as Employee).FullName)
                </div>
            </td>
            <td style="border-bottom: 0.5px solid #e0e0e0;">
                <div>
                    <div style="position:relative;display:inline-block;">
                        <img src="@UriHelper.ToAbsoluteUri($"images/TreeGrid/"+ (context as Employee).Name +".png")" alt=@((context as Employee).Name) />
                    </div>
                    <div style="display:inline-block;">
                        <div style="padding:5px;">@((context as Employee).Address)</div>
                        <div style="padding:5px;">@((context as Employee).Country)</div>
                        <div style="padding:5px;font-size:12px;">@((context as Employee).Contact)</div>
                    </div>
                </div>
            </td>
            <td style='padding-left: 20px; border-bottom: 0.5px solid #e0e0e0;'>
                <div>@((context as Employee).Designation)</div>
            </td>
        </RowTemplate>
    </TreeGridTemplates>
    <TreeGridColumns>
        <TreeGridColumn Field="EmpID" HeaderText="Employee ID" Width="160"></TreeGridColumn>
        <TreeGridColumn Field="Name" HeaderText="Employee Name"></TreeGridColumn>
        <TreeGridColumn Field="Address" HeaderText="Employee Details" Width="340" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
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

![Blazor TreeGrid with Row Template](images/blazor-treegrid-row-template.png)

### Row template with formatting

If [RowTemplate](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.SfTreeGrid~RowTemplate.html) is used, the value cannot be  formatted  inside the template using the [Format](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridColumn~Format.html) property. In that case, a function should be defined globally to format the value and invoke it inside the template.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data
@using Syncfusion.Blazor.TreeGrid;
@inject Microsoft.AspNetCore.Components.NavigationManager UriHelper

<SfTreeGrid ID="TreeGrid" Height="335" DataSource="@TreeData" IdMapping="EmployeeID" ParentIdMapping="ParentId" TreeColumnIndex="0" RowHeight="83" GridLines="Syncfusion.Blazor.Grids.GridLine.Vertical">
    <TreeGridTemplates>
        <RowTemplate>
            <td style='padding-left:18px; border-bottom: 0.5px solid #e0e0e0;'>
                <RowTemplateTreeColumn>
                                @{
                                    var cntxt = context as Employee;
                                    <div>@(cntxt.EmpID)</div>
                                }
                            </RowTemplateTreeColumn>
            </td>
            <td style='padding: 10px 0px 0px 20px; border-bottom: 0.5px solid #e0e0e0;'>
                <div style="font-size:14px;">
                    @((context as Employee).FullName)
                </div>
            </td>
            <td style="border-bottom: 0.5px solid #e0e0e0;">
                <div>
                    <div style="position:relative;display:inline-block;">
                        <img src="@UriHelper.ToAbsoluteUri($"images/TreeGrid/"+ (context as Employee).Name +".png")" alt=@((context as Employee).Name) />
                    </div>
                    <div style="display:inline-block;">
                        <div style="padding:5px;">@((context as Employee).Address)</div>
                        <div style="padding:5px;">@((context as Employee).Country)</div>
                        <div style="padding:5px;font-size:12px;">@((context as Employee).Contact)</div>
                    </div>
                </div>
            </td>
            <td style='padding-left: 20px; border-bottom: 0.5px solid #e0e0e0;'>
                <div>@Format((context as Employee).DOB))</div>
            </td>
        </RowTemplate>
    </TreeGridTemplates>
    <TreeGridColumns>
        <TreeGridColumn Field="EmpID" HeaderText="Employee ID" Width="160"></TreeGridColumn>
        <TreeGridColumn Field="Name" HeaderText="Employee Name"></TreeGridColumn>
        <TreeGridColumn Field="Address" HeaderText="Employee Details" Width="340" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="DOB" HeaderText="DOB"></TreeGridColumn>
        </TreeGridColumns>
</SfTreeGrid>

@code{
    public Employee model = new Employee();
    public IEnumerable<Employee> TreeData { get; set; }
    protected override void OnInitialized()
    {
        this.TreeData = Employee.GetTemplateData();
    }
    public object Format(DateTime? DOB) {
        return DOB.Value.ToLocalTime();
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

![Blazor TreeGrid Row Template with Formatting](images/blazor-treegrid-row-template-formatting.png)

### Limitations

Row template feature is not compatible with all the features which are available in the tree grid and it has limited features support. Here the features which are compatible with row template feature are listed out.

* Filtering
* Paging
* Sorting
* Scrolling
* Searching
* Rtl
* Context Menu
* State Persistence

## Detail template

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

![Blazor TreeGrid with Detail Template](images/blazor-treegrid-detail-template.png)

<!-- Customize row height for particular row

Grid row height for particular row can be customized using the [`RowDataBound`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.SfTreeGrid~RowDataBound.html)
event by setting the [`RowHeight`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.SfTreeGrid~RowHeight.html) in arguments for each row based on the requirement.

In the below example, the row height for the row with Task ID as 3 is set as 90px using the [`RowDataBound`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.SfTreeGrid~RowDataBound.html) event.

```csharp

@using TreeGridComponent.Data
@using Syncfusion.Blazor.Grids;
@using Syncfusion.Blazor.Data;

<SfTreeGrid ChildMapping="Children" TreeColumnIndex="1" RowDataBound="@onRowDataBound">
    <SfDataManager Json="@TreeGridData" Adaptor="Syncfusion.Blazor.Adaptors.JsonAdaptor"></SfDataManager>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="160"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>

@code{
    public List<TreeData.BusinessObject> TreeGridData { get; set; }

    protected override void OnInitialized()
    {
        this.TreeGridData = TreeData.GetDefaultData().ToList();
    }
    private void onRowDataBound(RowDataBoundEventArgs args)
    {
        int val = int.Parse(args.Data.GetType().GetProperty("TaskId").GetValue(args.Data, null).ToString());
        if (val == 3)
        {
            args.RowHeight = 90;
        }
    }
}

```
-->

### See Also

* [TreeGridTemplates component](./templates/#treegridtemplates-component)

## Drag and drop

The Tree Grid rows can be reordered, dropped to another Tree Grid or custom control by enabling the [AllowRowDragAndDrop](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridModel%601~AllowRowDragAndDrop.html) to true.

### Drag and drop within TreeGrid

The Tree Grid row drag and drop allows to drag and drop Tree Grid rows on the same Tree Grid using drag icon. To enable row drag and drop, set the [AllowRowDragAndDrop](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridModel%601~AllowRowDragAndDrop.html) to true. It provides the way to drop the row above, below or child to the target row with respective to the target row position.

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid;

 <SfTreeGrid DataSource="@TreeGridData" AllowRowDragAndDrop="true" TreeColumnIndex="1" IdMapping="TaskId" ParentIdMapping="ParentId" AllowPaging="true">
                <TreeGridPageSettings PageSize="2"></TreeGridPageSettings>
                <TreeGridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></TreeGridSelectionSettings>
                <TreeGridColumns>
                    <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="80" IsPrimaryKey="true" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
                    <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="240"></TreeGridColumn>
                    <TreeGridColumn Field="StartDate" HeaderText="Start Date" Format="d" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
                    <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
                    <TreeGridColumn Field="Progress" HeaderText="Progress" Width="100"></TreeGridColumn>
                </TreeGridColumns>
            </SfTreeGrid>
       
@code{

    public List<WrapData> TreeGridData { get; set; }

    protected override void OnInitialized()
    {
        TreeGridData = WrapData.GetWrapData();
    }
}

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent.Data {

public class WrapData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Duration { get; set; }
        public String Progress { get; set; }
        public string Priority { get; set; }
        public bool Approved { get; set; }
        public int Resources { get; set; }
        public int? ParentId { get; set; }
        public static List<WrapData> GetWrapData()
        {
            List<WrapData> BusinessObjectCollection = new List<WrapData>();
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 1,
                TaskName = "Planning",
                StartDate = new DateTime(2017, 03, 02),
                EndDate = new DateTime(2017, 07, 03),
                Progress = "Open",
                Duration = 5,
                Priority = "Normal",
                Resources = 6,
                Approved = false,
                ParentId = null
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 2,
                TaskName = "Plan timeline",
                StartDate = new DateTime(2017, 03, 04),
                EndDate = new DateTime(2017, 07, 05),
                Progress = "Inprogress",
                Duration = 5,
                Resources = 4,
                Priority = "Normal",
                Approved = false,
                ParentId = 1
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 3,
                TaskName = "Plan budget",
                StartDate = new DateTime(2017, 03, 06),
                EndDate = new DateTime(2017, 07, 07),
                Duration = 5,
                Progress = "Started",
                Approved = true,
                Resources = 6,
                Priority = "Low",
                ParentId = 1
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 4,
                TaskName = "Allocate resources",
                StartDate = new DateTime(2017, 03, 08),
                EndDate = new DateTime(2017, 07, 09),
                Duration = 5,
                Progress = "Open",
                Priority = "Critical",
                ParentId = 1,
                Resources = 3,
                Approved = false
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 5,
                TaskName = "Planning complete",
                StartDate = new DateTime(2017, 07, 10),
                EndDate = new DateTime(2017, 07, 11),
                Duration = 1,
                Progress = "Open",
                Priority = "Low",
                Resources = 5,
                ParentId = 1,
                Approved = true
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 6,
                TaskName = "Design",
                StartDate = new DateTime(2017, 10, 12),
                EndDate = new DateTime(2017, 02, 13),
                Progress = "Inprogress",
                Duration = 3,
                Priority = "High",
                Resources = 4,
                Approved = false,
                ParentId = null
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 7,
                TaskName = "Software Specification",
                StartDate = new DateTime(2017, 10, 14),
                EndDate = new DateTime(2017, 02, 15),
                Duration = 3,
                Progress = "Started",
                Resources = 3,
                Priority = "Normal",
                ParentId = 6,
                Approved = false
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 8,
                TaskName = "Develop prototype",
                StartDate = new DateTime(2017, 10, 16),
                EndDate = new DateTime(2017, 02, 17),
                Duration = 3,
                Progress = "Inprogress",
                Resources = 2,
                Priority = "Critical",
                ParentId = 6,
                Approved = false
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 9,
                TaskName = "Get approval from customer",
                StartDate = new DateTime(2017, 02, 18),
                EndDate = new DateTime(2017, 02, 19),
                Duration = 2,
                Progress = "Inprogress",
                Resources = 3,
                Priority = "Low",
                Approved = true,
                ParentId = 6
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 10,
                TaskName = "Design complete",
                StartDate = new DateTime(2017, 02, 20),
                EndDate = new DateTime(2017, 02, 21),
                Duration = 1,
                Progress = "Inprogress",
                Resources = 6,
                Priority = "Normal",
                ParentId = 6,
                Approved = true
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 12,
                TaskName = "Implementation Phase",
                StartDate = new DateTime(2017, 02, 22),
                EndDate = new DateTime(2017, 02, 23),
                Priority = "Normal",
                Approved = false,
                Duration = 11,
                Resources = 5,
                Progress = "Started",
                ParentId = null
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 13,
                TaskName = "Phase 1",
                StartDate = new DateTime(2017, 02, 24),
                EndDate = new DateTime(2017, 02, 25),
                Priority = "High",
                Approved = false,
                Duration = 11,
                Progress = "Open",
                Resources = 4,
                ParentId = 12
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 14,
                TaskName = "Implementation Module 1",
                StartDate = new DateTime(2017, 02, 26),
                EndDate = new DateTime(2017, 02, 27),
                Priority = "Normal",
                Duration = 11,
                Progress = "Started",
                Resources = 3,
                Approved = false,
                ParentId = 13
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 15,
                TaskName = "Development Task 1",
                StartDate = new DateTime(2017, 06, 18),
                EndDate = new DateTime(2017, 06, 19),
                Duration = 3,
                Progress = "Inprogress",
                Priority = "High",
                Resources = 2,
                ParentId = 14,
                Approved = false
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 16,
                TaskName = "Development Task 2",
                StartDate = new DateTime(2017, 02, 13),
                EndDate = new DateTime(2017, 03, 01),
                Duration = 3,
                Progress = "Closed",
                Priority = "Low",
                Resources = 5,
                ParentId = 14,
                Approved = true
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 17,
                TaskName = "Testing",
                StartDate = new DateTime(2017, 03, 02),
                EndDate = new DateTime(2017, 03, 03),
                Duration = 2,
                Progress = "Closed",
                Priority = "Normal",
                ParentId = 14,
                Resources = 1,
                Approved = true
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 18,
                TaskName = "Bug fix",
                StartDate = new DateTime(2017, 03, 04),
                EndDate = new DateTime(2017, 03, 05),
                Duration = 2,
                Progress = "Validated",
                Priority = "Critical",
                ParentId = 14,
                Resources = 6,
                Approved = false
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 19,
                TaskName = "Customer review meeting",
                StartDate = new DateTime(2017, 03, 06),
                EndDate = new DateTime(2017, 03, 07),
                Duration = 2,
                Progress = "Open",
                Priority = "High",
                ParentId = 14,
                Resources = 6,
                Approved = false
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 20,
                TaskName = "Phase 1 complete",
                StartDate = new DateTime(2017, 04, 27),
                EndDate = new DateTime(2017, 07, 27),
                Duration = 2,
                Progress = "Closed",
                Priority = "Low",
                ParentId = 14,
                Resources = 5,
                Approved = true
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 21,
                TaskName = "Phase 2",
                StartDate = new DateTime(2017, 07, 17),
                EndDate = new DateTime(2017, 09, 28),
                Priority = "High",
                Approved = false,
                Progress = "Open",
                ParentId = 12,
                Resources = 3,
                Duration = 12,
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 22,
                TaskName = "Implementation Module 2",
                StartDate = new DateTime(2017, 01, 17),
                EndDate = new DateTime(2017, 02, 28),
                Priority = "Critical",
                Approved = false,
                Progress = "Inprogress",
                ParentId = 21,
                Resources = 3,
                Duration = 12
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 23,
                TaskName = "Development Task 1",
                StartDate = new DateTime(2017, 08, 17),
                EndDate = new DateTime(2017, 09, 20),
                Duration = 4,
                Progress = "Closed",
                Priority = "Normal",
                ParentId = 22,
                Resources = 2,
                Approved = true,
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 24,
                TaskName = "Development Task 2",
                StartDate = new DateTime(2017, 04, 17),
                EndDate = new DateTime(2017, 03, 20),
                Duration = 4,
                Progress = "Closed",
                Priority = "Critical",
                ParentId = 22,
                Resources = 5,
                Approved = true,
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 25,
                TaskName = "Testing",
                StartDate = new DateTime(2017, 01, 21),
                EndDate = new DateTime(2017, 01, 24),
                Duration = 2,
                Progress = "Open",
                Priority = "High",
                ParentId = 22,
                Resources = 3,
                Approved = false,
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 26,
                TaskName = "Bug fix",
                StartDate = new DateTime(2017, 03, 25),
                EndDate = new DateTime(2017, 08, 26),
                Duration = 2,
                Progress = "Validated",
                Priority = "Low",
                Approved = false,
                Resources = 6,
                ParentId = 22
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 27,
                TaskName = "Customer review meeting",
                StartDate = new DateTime(2017, 07, 27),
                EndDate = new DateTime(2017, 06, 28),
                Duration = 2,
                Progress = "Inprogress",
                Priority = "Critical",
                ParentId = 22,
                Resources = 4,
                Approved = true,
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 28,
                TaskName = "Phase 2 complete",
                StartDate = new DateTime(2017, 07, 19),
                EndDate = new DateTime(2017, 05, 28),
                Duration = 2,
                Priority = "Normal",
                Progress = "Open",
                ParentId = 22,
                Resources = 3,
                Approved = false,
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 29,
                TaskName = "Phase 3",
                StartDate = new DateTime(2017, 07, 17),
                EndDate = new DateTime(2017, 02, 12),
                Priority = "Normal",
                Approved = false,
                Duration = 11,
                Progress = "Inprogress",
                Resources = 4,
                ParentId = 12
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 30,
                TaskName = "Implementation Module 3",
                StartDate = new DateTime(2017, 08, 17),
                EndDate = new DateTime(2017, 09, 27),
                Priority = "High",
                Approved = false,
                Duration = 11,
                Resources = 5,
                Progress = "Validated",
                ParentId = 29,
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 31,
                TaskName = "Development Task 1",
                StartDate = new DateTime(2017, 11, 17),
                EndDate = new DateTime(2017, 12, 19),
                Duration = 3,
                Progress = "Closed",
                Priority = "Low",
                Approved = true,
                Resources = 3,
                ParentId = 30
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 32,
                TaskName = "Development Task 2",
                StartDate = new DateTime(2017, 12, 17),
                EndDate = new DateTime(2017, 02, 19),
                Duration = 3,
                Progress = "Closed",
                Priority = "Normal",
                Approved = false,
                Resources = 2,
                ParentId = 30
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 33,
                TaskName = "Testing",
                StartDate = new DateTime(2017, 01, 01),
                EndDate = new DateTime(2017, 07, 21),
                Duration = 2,
                Progress = "Closed",
                Priority = "Critical",
                ParentId = 30,
                Resources = 4,
                Approved = true,
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 34,
                TaskName = "Bug fix",
                StartDate = new DateTime(2017, 01, 24),
                EndDate = new DateTime(2017, 01, 25),
                Duration = 2,
                Progress = "Open",
                Priority = "High",
                Approved = false,
                Resources = 3,
                ParentId = 30
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 35,
                TaskName = "Customer review meeting",
                StartDate = new DateTime(2017, 12, 26),
                EndDate = new DateTime(2017, 12, 27),
                Duration = 2,
                Progress = "Inprogress",
                Priority = "Normal",
                ParentId = 30,
                Resources = 6,
                Approved = true,
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 36,
                TaskName = "Phase 3 complete",
                StartDate = new DateTime(2017, 05, 27),
                EndDate = new DateTime(2017, 05, 27),
                Duration = 2,
                Priority = "Critical",
                Progress = "Open",
                Resources = 5,
                ParentId = 30,
                Approved = false,
            });
            return BusinessObjectCollection;
        }
    }
}


{% endhighlight %}

{% endtabs %}

![Drag and Drop within Blazor TreeGrid Rows](images/blazor-treegrid-drag-and-drop-rows.png)

> Selection feature must be enabled for row drag and drop.
> For multiple row selection, the type property must be set to multiple.

### Drag and drop to another TreeGrid

To drag and drop between two Tree Grid, enable the [AllowRowDragAndDrop](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridModel%601~AllowRowDragAndDrop.html) property and specify the target Tree Grid ID in [TargetID](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridRowDropSettings~TargetID.html) property of [RowDropSettings](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridRowDropSettings).

{% tabs %}

{% highlight razor %}

@using TreeGridComponent.Data;
@using Syncfusion.Blazor.TreeGrid;
<div id='container'>
        <div>
            <div style="float: left;  width:49%" id="Grid">
<SfTreeGrid ID="Grid" DataSource="@TreeGridData" AllowRowDragAndDrop="true" AllowSelection="true" AllowPaging="true" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1">
    <TreeGridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></TreeGridSelectionSettings>
    <TreeGridRowDropSettings TargetID="DestGrid"></TreeGridRowDropSettings>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="160"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>
</div>
 <div style="float: right; width:49%">
<SfTreeGrid ID="DestGrid" DataSource="@SecondGrid" AllowRowDragAndDrop="true" AllowSelection="true" AllowPaging="true" IdMapping="TaskId" ParentIdMapping="ParentId" TreeColumnIndex="1">
    <TreeGridSelectionSettings Type="Syncfusion.Blazor.Grids.SelectionType.Multiple"></TreeGridSelectionSettings>
    <TreeGridRowDropSettings TargetID="Grid"></TreeGridRowDropSettings>
    <TreeGridColumns>
        <TreeGridColumn Field="TaskId" HeaderText="Task ID" Width="80" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
        <TreeGridColumn Field="TaskName" HeaderText="Task Name" Width="160"></TreeGridColumn>
        <TreeGridColumn Field="Duration" HeaderText="Duration" Width="100" TextAlign="Syncfusion.Blazor.Grids.TextAlign.Right"></TreeGridColumn>
    </TreeGridColumns>
</SfTreeGrid>
</div>  
</div>
@code{
    public List<TreeData.BusinessObject> TreeGridData { get; set; }
    public List<TreeData.BusinessObject> SecondGrid { get; set; } = new List<TreeData.BusinessObject>();
    protected override void OnInitialized()
    {       
        this.TreeGridData = TreeData.GetSelfDataSource().ToList();
    }
}

{% endhighlight %}

{% highlight c# %}

namespace TreeGridComponent.Data {

public class WrapData
    {
        public int TaskId { get; set; }
        public string TaskName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Duration { get; set; }
        public String Progress { get; set; }
        public string Priority { get; set; }
        public bool Approved { get; set; }
        public int Resources { get; set; }
        public int? ParentId { get; set; }
        public static List<WrapData> GetWrapData()
        {
            List<WrapData> BusinessObjectCollection = new List<WrapData>();
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 1,
                TaskName = "Planning",
                StartDate = new DateTime(2017, 03, 02),
                EndDate = new DateTime(2017, 07, 03),
                Progress = "Open",
                Duration = 5,
                Priority = "Normal",
                Resources = 6,
                Approved = false,
                ParentId = null
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 2,
                TaskName = "Plan timeline",
                StartDate = new DateTime(2017, 03, 04),
                EndDate = new DateTime(2017, 07, 05),
                Progress = "Inprogress",
                Duration = 5,
                Resources = 4,
                Priority = "Normal",
                Approved = false,
                ParentId = 1
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 3,
                TaskName = "Plan budget",
                StartDate = new DateTime(2017, 03, 06),
                EndDate = new DateTime(2017, 07, 07),
                Duration = 5,
                Progress = "Started",
                Approved = true,
                Resources = 6,
                Priority = "Low",
                ParentId = 1
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 4,
                TaskName = "Allocate resources",
                StartDate = new DateTime(2017, 03, 08),
                EndDate = new DateTime(2017, 07, 09),
                Duration = 5,
                Progress = "Open",
                Priority = "Critical",
                ParentId = 1,
                Resources = 3,
                Approved = false
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 5,
                TaskName = "Planning complete",
                StartDate = new DateTime(2017, 07, 10),
                EndDate = new DateTime(2017, 07, 11),
                Duration = 1,
                Progress = "Open",
                Priority = "Low",
                Resources = 5,
                ParentId = 1,
                Approved = true
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 6,
                TaskName = "Design",
                StartDate = new DateTime(2017, 10, 12),
                EndDate = new DateTime(2017, 02, 13),
                Progress = "Inprogress",
                Duration = 3,
                Priority = "High",
                Resources = 4,
                Approved = false,
                ParentId = null
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 7,
                TaskName = "Software Specification",
                StartDate = new DateTime(2017, 10, 14),
                EndDate = new DateTime(2017, 02, 15),
                Duration = 3,
                Progress = "Started",
                Resources = 3,
                Priority = "Normal",
                ParentId = 6,
                Approved = false
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 8,
                TaskName = "Develop prototype",
                StartDate = new DateTime(2017, 10, 16),
                EndDate = new DateTime(2017, 02, 17),
                Duration = 3,
                Progress = "Inprogress",
                Resources = 2,
                Priority = "Critical",
                ParentId = 6,
                Approved = false
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 9,
                TaskName = "Get approval from customer",
                StartDate = new DateTime(2017, 02, 18),
                EndDate = new DateTime(2017, 02, 19),
                Duration = 2,
                Progress = "Inprogress",
                Resources = 3,
                Priority = "Low",
                Approved = true,
                ParentId = 6
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 10,
                TaskName = "Design complete",
                StartDate = new DateTime(2017, 02, 20),
                EndDate = new DateTime(2017, 02, 21),
                Duration = 1,
                Progress = "Inprogress",
                Resources = 6,
                Priority = "Normal",
                ParentId = 6,
                Approved = true
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 12,
                TaskName = "Implementation Phase",
                StartDate = new DateTime(2017, 02, 22),
                EndDate = new DateTime(2017, 02, 23),
                Priority = "Normal",
                Approved = false,
                Duration = 11,
                Resources = 5,
                Progress = "Started",
                ParentId = null
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 13,
                TaskName = "Phase 1",
                StartDate = new DateTime(2017, 02, 24),
                EndDate = new DateTime(2017, 02, 25),
                Priority = "High",
                Approved = false,
                Duration = 11,
                Progress = "Open",
                Resources = 4,
                ParentId = 12
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 14,
                TaskName = "Implementation Module 1",
                StartDate = new DateTime(2017, 02, 26),
                EndDate = new DateTime(2017, 02, 27),
                Priority = "Normal",
                Duration = 11,
                Progress = "Started",
                Resources = 3,
                Approved = false,
                ParentId = 13
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 15,
                TaskName = "Development Task 1",
                StartDate = new DateTime(2017, 06, 18),
                EndDate = new DateTime(2017, 06, 19),
                Duration = 3,
                Progress = "Inprogress",
                Priority = "High",
                Resources = 2,
                ParentId = 14,
                Approved = false
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 16,
                TaskName = "Development Task 2",
                StartDate = new DateTime(2017, 02, 13),
                EndDate = new DateTime(2017, 03, 01),
                Duration = 3,
                Progress = "Closed",
                Priority = "Low",
                Resources = 5,
                ParentId = 14,
                Approved = true
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 17,
                TaskName = "Testing",
                StartDate = new DateTime(2017, 03, 02),
                EndDate = new DateTime(2017, 03, 03),
                Duration = 2,
                Progress = "Closed",
                Priority = "Normal",
                ParentId = 14,
                Resources = 1,
                Approved = true
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 18,
                TaskName = "Bug fix",
                StartDate = new DateTime(2017, 03, 04),
                EndDate = new DateTime(2017, 03, 05),
                Duration = 2,
                Progress = "Validated",
                Priority = "Critical",
                ParentId = 14,
                Resources = 6,
                Approved = false
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 19,
                TaskName = "Customer review meeting",
                StartDate = new DateTime(2017, 03, 06),
                EndDate = new DateTime(2017, 03, 07),
                Duration = 2,
                Progress = "Open",
                Priority = "High",
                ParentId = 14,
                Resources = 6,
                Approved = false
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 20,
                TaskName = "Phase 1 complete",
                StartDate = new DateTime(2017, 04, 27),
                EndDate = new DateTime(2017, 07, 27),
                Duration = 2,
                Progress = "Closed",
                Priority = "Low",
                ParentId = 14,
                Resources = 5,
                Approved = true
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 21,
                TaskName = "Phase 2",
                StartDate = new DateTime(2017, 07, 17),
                EndDate = new DateTime(2017, 09, 28),
                Priority = "High",
                Approved = false,
                Progress = "Open",
                ParentId = 12,
                Resources = 3,
                Duration = 12,
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 22,
                TaskName = "Implementation Module 2",
                StartDate = new DateTime(2017, 01, 17),
                EndDate = new DateTime(2017, 02, 28),
                Priority = "Critical",
                Approved = false,
                Progress = "Inprogress",
                ParentId = 21,
                Resources = 3,
                Duration = 12
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 23,
                TaskName = "Development Task 1",
                StartDate = new DateTime(2017, 08, 17),
                EndDate = new DateTime(2017, 09, 20),
                Duration = 4,
                Progress = "Closed",
                Priority = "Normal",
                ParentId = 22,
                Resources = 2,
                Approved = true,
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 24,
                TaskName = "Development Task 2",
                StartDate = new DateTime(2017, 04, 17),
                EndDate = new DateTime(2017, 03, 20),
                Duration = 4,
                Progress = "Closed",
                Priority = "Critical",
                ParentId = 22,
                Resources = 5,
                Approved = true,
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 25,
                TaskName = "Testing",
                StartDate = new DateTime(2017, 01, 21),
                EndDate = new DateTime(2017, 01, 24),
                Duration = 2,
                Progress = "Open",
                Priority = "High",
                ParentId = 22,
                Resources = 3,
                Approved = false,
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 26,
                TaskName = "Bug fix",
                StartDate = new DateTime(2017, 03, 25),
                EndDate = new DateTime(2017, 08, 26),
                Duration = 2,
                Progress = "Validated",
                Priority = "Low",
                Approved = false,
                Resources = 6,
                ParentId = 22
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 27,
                TaskName = "Customer review meeting",
                StartDate = new DateTime(2017, 07, 27),
                EndDate = new DateTime(2017, 06, 28),
                Duration = 2,
                Progress = "Inprogress",
                Priority = "Critical",
                ParentId = 22,
                Resources = 4,
                Approved = true,
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 28,
                TaskName = "Phase 2 complete",
                StartDate = new DateTime(2017, 07, 19),
                EndDate = new DateTime(2017, 05, 28),
                Duration = 2,
                Priority = "Normal",
                Progress = "Open",
                ParentId = 22,
                Resources = 3,
                Approved = false,
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 29,
                TaskName = "Phase 3",
                StartDate = new DateTime(2017, 07, 17),
                EndDate = new DateTime(2017, 02, 12),
                Priority = "Normal",
                Approved = false,
                Duration = 11,
                Progress = "Inprogress",
                Resources = 4,
                ParentId = 12
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 30,
                TaskName = "Implementation Module 3",
                StartDate = new DateTime(2017, 08, 17),
                EndDate = new DateTime(2017, 09, 27),
                Priority = "High",
                Approved = false,
                Duration = 11,
                Resources = 5,
                Progress = "Validated",
                ParentId = 29,
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 31,
                TaskName = "Development Task 1",
                StartDate = new DateTime(2017, 11, 17),
                EndDate = new DateTime(2017, 12, 19),
                Duration = 3,
                Progress = "Closed",
                Priority = "Low",
                Approved = true,
                Resources = 3,
                ParentId = 30
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 32,
                TaskName = "Development Task 2",
                StartDate = new DateTime(2017, 12, 17),
                EndDate = new DateTime(2017, 02, 19),
                Duration = 3,
                Progress = "Closed",
                Priority = "Normal",
                Approved = false,
                Resources = 2,
                ParentId = 30
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 33,
                TaskName = "Testing",
                StartDate = new DateTime(2017, 01, 01),
                EndDate = new DateTime(2017, 07, 21),
                Duration = 2,
                Progress = "Closed",
                Priority = "Critical",
                ParentId = 30,
                Resources = 4,
                Approved = true,
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 34,
                TaskName = "Bug fix",
                StartDate = new DateTime(2017, 01, 24),
                EndDate = new DateTime(2017, 01, 25),
                Duration = 2,
                Progress = "Open",
                Priority = "High",
                Approved = false,
                Resources = 3,
                ParentId = 30
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 35,
                TaskName = "Customer review meeting",
                StartDate = new DateTime(2017, 12, 26),
                EndDate = new DateTime(2017, 12, 27),
                Duration = 2,
                Progress = "Inprogress",
                Priority = "Normal",
                ParentId = 30,
                Resources = 6,
                Approved = true,
            });
            BusinessObjectCollection.Add(new WrapData()
            {
                TaskId = 36,
                TaskName = "Phase 3 complete",
                StartDate = new DateTime(2017, 05, 27),
                EndDate = new DateTime(2017, 05, 27),
                Duration = 2,
                Priority = "Critical",
                Progress = "Open",
                Resources = 5,
                ParentId = 30,
                Approved = false,
            });
            return BusinessObjectCollection;
        }
    }
}


{% endhighlight %}

{% endtabs %}

![Drag and Drop Row between Different Blazor TreeGrid](images/blazor-treegrid-drag-drop-row.png)

### Drag and drop events

The following events are triggered while drag and drop the tree grid rows.

[OnRowDragStart](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_OnRowDragStart) -Triggers when starts to drag the tree grid row.

[RowDropped](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_RowDropped) - Triggers when a drag element is dropped on the target element.
