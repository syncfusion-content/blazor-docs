---
layout: post
title: Rows in Blazor Tree Grid Component | Syncfusion 
description: Learn about Rows in Blazor Tree Grid component of Syncfusion, and more details.
platform: Blazor
control: Tree Grid
documentation: ug
---

# Row

The row represents record details fetched from data source.

## Customize rows

You can customize the appearance of a row by using the [`RowDataBound`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.SfTreeGrid~RowDataBound.html) event.
The [`RowDataBound`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.SfTreeGrid~RowDataBound.html) event triggers for every row. In the event handler, you can get the **args** which contains details of the row.

{% highlight csharp %}

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

The following output is displayed as a result of the above code example.

![Customize Rows](images/row-styling.png)

## Styling alternate rows

 You can change the tree grid's alternative rows' background color by overriding the **.e-altrow** class.

```css
.e-treegrid .e-altrow {
    background-color: #fafafa;
}
```

Please refer to the following example.

{% highlight csharp %}

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

The following output is displayed as a result of the above code example.

![Styling Alternate Rows](images/styaltrows.png)

## Row height

You can customize the row height of tree grid rows through the [`RowHeight`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.SfTreeGrid~RowHeight.html) property. The [`RowHeight`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.SfTreeGrid~RowHeight.html) property is used to change the row height of entire tree grid rows.

In the below example, the **RowHeight** is set as *60px*.

{% highlight csharp %}

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

The following output is displayed as a result of the above code example.

![Row Height](images/rowheight.png)

## Row template

The **RowTemplate** has an option to customise the look and behavior of the tree grid rows. The [`RowTemplate`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.SfTreeGrid~RowTemplate.html) property accepts either
the **template** string or HTML elements.

{% highlight csharp %}

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

The following output is displayed as a result of the above code example.

![Row Template](images/rowtemp.png)

### Row template with formatting

If [`RowTemplate`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.SfTreeGrid~RowTemplate.html) is used, the value cannot be  formatted  inside the template using the [`Format`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridColumn~Format.html) property. In that case, a function should be defined globally to format the value and invoke it inside the template.

{% highlight csharp %}

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

The following output is displayed as a result of the above code example.

![RowTemplate with Formatting](images/rowtempformat.png)

### Limitations

Row template feature is not compatible with all the features which are available in tree grid and it has limited features support. Here we have listed out the features which are compatible with row template feature.

* Filtering
* Paging
* Sorting
* Scrolling
* Searching
* Rtl
* Context Menu
* State Persistence

## Detail template

The detail template provides additional information about a particular row. By expanding the parent row the child rows are expanded along with their detail template. The [`DetailTemplate`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.SfTreeGrid~DetailTemplate.html) property accepts either the template string or HTML elements.

{% highlight csharp %}

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

The following output is displayed as a result of the above code example.

![Detail Template](images/dettemp.png)

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

The Tree Grid rows can be reordered, dropped to another Tree Grid or custom control by enabling the [`AllowRowDragAndDrop`](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridModel%601~AllowRowDragAndDrop.html) to true.

### Drag and drop within TreeGrid

The Tree Grid row drag and drop allows you to drag and drop Tree Grid rows on the same Tree Grid using drag icon. To enable row drag and drop, set the [`AllowRowDragAndDrop`](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridModel%601~AllowRowDragAndDrop.html) to true. It provides the way to drop the row above, below or child to the target row with respective to the target row position.

{% highlight csharp %}

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

The following output is displayed as a result of the above code example.

![Drag and drop within TreeGrid](images/draganddrop.gif)

> Selection feature must be enabled for row drag and drop.
> For multiple row selection, the type property must be set to multiple.

### Drag and drop to another TreeGrid

To drag and drop between two Tree Grid, enable the [`AllowRowDragAndDrop`](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridModel%601~AllowRowDragAndDrop.html) property and specify the target Tree Grid ID in [`TargetID`](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridRowDropSettings~TargetID.html) property of [`RowDropSettings`](https://help.syncfusion.com/cr/aspnetcore-blazor/Syncfusion.Blazor~Syncfusion.Blazor.TreeGrid.TreeGridRowDropSettings).

{% highlight csharp %}

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

The following output is displayed as a result of the above code example.

![ Drag and drop to another TreeGrid](images/dragdropanothergrid.gif)

### Drag and drop events

The following events are triggered while drag and drop the tree grid rows.

[`OnRowDragStart`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_OnRowDragStart) -Triggers when starts to drag the tree grid row.

[`RowDropped`](https://help.syncfusion.com/cr/blazor/Syncfusion.Blazor.TreeGrid.TreeGridEvents-1.html#Syncfusion_Blazor_TreeGrid_TreeGridEvents_1_RowDropped) - Triggers when a drag element is dropped on the target element.